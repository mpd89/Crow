'Imports System.Data.SqlClient
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Public Class FormSelect
    Public FormID As String
    Public FormName As String


    'Private connSQLServer As SqlConnection = daqartDLL.connections.serverRemoteConnect(connSQLServer)
    '    Private conn As SqlCeConnection
    Private usequery As String
    'Private useProjectDB As String = "USE [" + runtime.selectedProject + "] "


    Private Sub InitializeGridControl1()
        'usequery = "USE [" + runtime.selectedProject + "] "
        'connSQLServer.Open()
        'Dim query = usequery + "SELECT Name,ID FROM forms"

        'Dim dataSet11 As DataSet = New DataSet
        'Dim form_adapter As SqlDataAdapter = New SqlDataAdapter(query, connSQLServer)
        'form_adapter.Fill(dataSet11, "forms")
        'Dim keyColumn As DataColumn = dataSet11.Tables("forms").Columns("ID")
        'Me.GridControl1.DataSource = dataSet11.Tables("forms")
        'Dim View As ColumnView = GridControl1.MainView
        'Dim Column As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("ID")
        'Column.Visible = False
        'GridControl1.ForceInitialize()
        'Me.DataNavigator1.DataSource = dataSet11.Tables("forms")
        If Not Me.GridControl1.DataSource Is Nothing Then
            Me.GridControl1.DataSource.Dispose()
        End If
        'Dim query = useProjectDB + "SELECT Name,ID,Description FROM forms"
        'Me.GridControl1.DataSource = Utilities.ExecuteRemoteQuery(query, "Forms")

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim query = "SELECT Name,MUID,Description FROM forms ORDER BY Name ASC"
        sqlPrjUtils.OpenConnection()
        Me.GridControl1.DataSource = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Dim View As ColumnView = GridControl1.MainView
        Dim Column As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("MUID")
        Column.Visible = False
        GridControl1.ForceInitialize()


    End Sub


    Private Sub FormSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            InitializeGridControl1()
        Catch ex As Exception
            Utilities.logErrorMessage("FormDesigner.FormSelect_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub GridControl1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        If runtime.ConnectionMode = "OFFLINE" Then
            MessageBox.Show("Form can not be edited while System is offline")
            Return
        End If

        Cursor = Cursors.AppStarting

        Dim View As ColumnView = GridControl1.MainView
        Dim ParentView As GridView = View.ParentView

        If View.GetFocusedRowCellValue("MUID") Is Nothing Then
            Return
        End If
        FormID = View.GetFocusedRowCellValue("MUID")
        FormName = View.GetFocusedRowCellValue("Name")
        Dim qry = "SELECT FormImage FROM forms_image WHERE FormMUID ='" + FormID.ToString + "' ORDER By PageNumber;"
        'Dim dt As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        If dt.Rows.Count <= 0 Then
            MessageBox.Show("No image is available for this form")
            Return
        End If

        FormEditManager.OpenForm(View.GetFocusedRowCellValue("MUID"), View.GetFocusedRowCellValue("Name"))

        Cursor = Cursors.Default


        Me.Close()

    End Sub


    Private Sub btnAddNewForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewForm.Click
        If runtime.ConnectionMode = "OFFLINE" Then
            MessageBox.Show("Form may not be added while System is offline")
            Return
        End If
        Dim CreateForm As New FormAdd()
        CreateForm.ShowDialog()
        CreateForm.BringToFront()
        Me.Close()
    End Sub


    Private Sub btn_Import_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Import.Click
        Dim frm_Import As New FormImport
        frm_Import.ShowDialog()

        InitializeGridControl1()
    End Sub

    Private Sub btn_DeleteForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteForm.Click
        Dim frmID = GridView1.GetFocusedDataRow("MUID")
        Dim sqlUtils As DataUtils = New DataUtils("project")
        Dim qry = "SELECT equipment_type.TypeName, equipment_type.TypeDesc From requirements,equipment_type " + _
                " WHERE requirements.TypeMUID = equipment_type.MUID AND requirements.FormMUID = '" + frmID.ToString + "'"
        sqlUtils.OpenConnection()
        Dim dtt As DataTable = sqlUtils.ExecuteQuery(qry)
        If dtt.Rows.Count > 0 Then
            Dim msg As String = String.Format("Form may not be deleted, it is a required form for Equipment Type: {0}:{1}", dtt.Rows(0)(0), dtt.Rows(0)(1))
            MessageBox.Show(msg)
            Return
        End If

        qry = "SELECT * From forms_status WHERE FormMUID = " + frmID.ToString
        Dim dt As DataTable = sqlUtils.ExecuteQuery(qry)
        If dt.Rows.Count > 0 Then
            Dim ret = MessageBox.Show("This is an active form with variables; " + _
                "if you delete this form all references to " + _
                " the form will also be deleted. " + ControlChars.CrLf + "Do you wish to delete the form?", "Delete Form", MessageBoxButtons.YesNo)
            If ret = Windows.Forms.DialogResult.Yes Then
                Dim dt_param As DataTable = sqlUtils.paramDT
                dt_param.Rows.Add("@MUID", frmID.ToString)

                qry = "delete From forms_image WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From forms_me_status WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From forms_status WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From forms_storage WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From aux_forms_info WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From aux_subforms_fields WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From aux_subforms_info WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From forms WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)
            End If
        Else
            Dim ret = MessageBox.Show("Do you wish to delete this form?", "Delete Form", MessageBoxButtons.YesNo)
            If ret = Windows.Forms.DialogResult.Yes Then

                Dim dt_param As DataTable = sqlUtils.paramDT
                dt_param.Rows.Add("@MUID", frmID.ToString)

                qry = "delete From forms WHERE MUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From forms_image WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From forms_storage WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From aux_forms_info WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From aux_subforms_fields WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                qry = "delete From aux_subforms_info WHERE FormMUID=@MUID"
                sqlUtils.ExecuteNonQuery(qry, dt_param)

                InitializeGridControl1()
            End If
        End If
        sqlUtils.CloseConnection()

    End Sub

End Class