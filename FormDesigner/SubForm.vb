Imports System
Imports System.Data
Imports System.Data.SqlServerCe
Imports System.Windows.Forms
Imports daqartDLL

Public Class SubForm
    Private FormID As String

    Public Sub New(ByVal ThisID As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormID = ThisID
    End Sub


    Private Sub SubForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'Dim useProjectDB As String = "USE [" + runtime.selectedProject + "] "
            'Dim query As String = useProjectDB + "SELECT * FROM aux_subforms_fields WHERE FormID = '" + FormID.ToString + "'"
            Dim query = "SELECT NumberofElements FROM forms WHERE MUID = '" + FormID.ToString + "'"
            'Dim dt_form As New DataTable
            'dt_form = Utilities.ExecuteRemoteQuery(query, "project")

            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt_form As DataTable = sqlPrjUtils.ExecuteQuery(query)
            sqlPrjUtils.CloseConnection()

            If Not IsDBNull(dt_form.Rows(0)(0)) Then
                nud_Elements.Value = dt_form.Rows(0)(0)
            Else
                nud_Elements.Value = 0
            End If


            query = "SELECT * FROM aux_subforms_fields WHERE FormMUID = '" + FormID.ToString + "'"
            'dt = Utilities.ExecuteRemoteQuery(query, "project")
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

            'Dim FieldString As String
            'Dim FieldArray As Array

            dgv_FieldNames.Rows.Clear()

            For i As Integer = 0 To dt.Rows.Count - 1
                'FieldString = dt.Rows(i)(3)

                'FieldArray = FieldString.Split("&001")

                dgv_FieldNames.Rows.Add(dt.Rows(i)("FieldName"))
                dgv_FieldNames.Rows(i).Cells("FieldName").Tag = dt.Rows(i)("MUID")

            Next


            'query = useProjectDB + "SELECT FieldName FROM aux_subforms_fields WHERE FormID = '" + FormID.ToString + "'"
            'dt = Utilities.ExecuteRemoteQuery(query, "project")
            'Me.BindingSource1.DataSource = dt
            'dgv_FieldNames.DataSource = Me.BindingSource1
            'Me.BindingNavigator1.BindingSource = Me.BindingSource1
            'dgv_FieldNames.Refresh()


        Catch ex As Exception
            Utilities.logErrorMessage("FormDesigner.SubForm_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub

    Private Function CheckDuplicates() As Boolean

        For i As Integer = 0 To Me.dgv_FieldNames.Rows.Count - 2
            Dim name As String = Me.dgv_FieldNames.Rows(i).Cells(0).Value
            For j As Integer = i + 1 To Me.dgv_FieldNames.Rows.Count - 2
                If Me.dgv_FieldNames.Rows(j).Cells(0).Value = name Then
                    MessageBox.Show("Duplicate Field Names in the list")
                    dgv_FieldNames.Rows(i).DefaultCellStyle.BackColor = Color.Aqua
                    dgv_FieldNames.Rows(j).DefaultCellStyle.BackColor = Color.Aqua
                    Return True
                End If
            Next
        Next
        Return False
    End Function

    Private Function CheckBlanks() As Boolean
        For i As Integer = 0 To dgv_FieldNames.Rows.Count - 2
            Dim name As String = dgv_FieldNames.Rows(i).Cells(0).ToString
            If name = "" Then
                MessageBox.Show("Blank Field Names in the list")
                dgv_FieldNames.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                Return True
            End If
        Next
        Return False
    End Function


    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        If CheckDuplicates() Then Return
        If CheckBlanks() Then Return
        Dim useProjectDB As String = "USE [" + runtime.selectedProject + "] "
        Dim query As String
        query = "UPDATE forms SET TS=@TS, NumberofElements=@NumberofElements WHERE MUID=@MUID"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        Dim dt_param As DataTable = sqlPrjUtils.paramDT
        dt_param.Rows.Add("@TS", Now())
        dt_param.Rows.Add("@NumberofElements", nud_Elements.Value.ToString)
        dt_param.Rows.Add("@MUID", FormID.ToString)

        sqlPrjUtils.OpenConnection()
        sqlPrjUtils.ExecuteNonQuery(query, dt_param)

        For i As Integer = 0 To dgv_FieldNames.Rows.Count - 1
            If Not dgv_FieldNames.Rows(i).Cells(0).Value = "" Then
                If dgv_FieldNames.Rows(i).Cells(0).Tag = Nothing Then
                    Dim muid As String = idUtils.GetNextMUID("project", "aux_subforms_fields")
                    query = "INSERT INTO aux_subforms_fields (MUID,TS,FormMUID,FieldName) VALUES " & _
                        "(@MUID,@TS,@FormMUID,@FieldName)"

                    dt_param = sqlPrjUtils.paramDT
                    dt_param.Rows.Add("@MUID", muid)
                    dt_param.Rows.Add("@TS", Now())
                    dt_param.Rows.Add("@FormMUID", FormID.ToString)
                    dt_param.Rows.Add("@FieldName", dgv_FieldNames.Rows(i).Cells(0).Value)
                Else
                    query = "UPDATE aux_subforms_fields SET" & _
                    " TS = @TS, FieldName = @FieldName WHERE MUID = @MUID"

                    dt_param = sqlPrjUtils.paramDT
                    dt_param.Rows.Add("@MUID", dgv_FieldNames.Rows(i).Cells("FieldName").Tag.ToString)
                    dt_param.Rows.Add("@TS", Now())
                    dt_param.Rows.Add("@FieldName", dgv_FieldNames.Rows(i).Cells("FieldName").Value)
                End If

                sqlPrjUtils.ExecuteNonQuery(query, dt_param)
            End If

        Next
        sqlPrjUtils.CloseConnection()

        Me.Dispose()
    End Sub


End Class