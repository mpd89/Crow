Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Threading
'Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors



Public Class TagSelect
    'Private connSQLServer As SqlConnection = daqartDLL.connections.serverRemoteConnect(connSQLServer)
    'Private useProjectDB As String = "USE [" + runtime.selectedProject + "] "
    'Private useServerDB As String = "USE [" + runtime.SiteName + "_ServerDB] "
    Private AuxTable As DataTable
    Private AuxIDTable As DataTable
    Dim PkgNumList As New ArrayList()
    Dim TypeNameList As New ArrayList()
    Dim tableModified As Boolean = False
    Dim sqlPrjUtils As DataUtils
    Dim myVGrid As DevExpress.XtraVerticalGrid.VGridControl


    Private Sub TagSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'connSQLServer.Open()
            sqlPrjUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            GridControl_GroupByAllTags()

        Catch ex As Exception
            Utilities.logErrorMessage("TagSelect.TagSelect_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
        AddHandler GridView1.RowCellStyle, AddressOf GridView1_RowCellStyle



    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub



    Private Sub GridControl_AuxData(ByVal TagID As String, ByVal TypeID As String)
        Dim qry As String = ""
        If Not AuxTable Is Nothing Then
            AuxTable.Dispose()
        End If
        AuxTable = New DataTable("AuxData")
        If Not AuxIDTable Is Nothing Then
            AuxIDTable.Dispose()
        End If
        AuxIDTable = New DataTable("AuxID")
        qry = "SELECT TemplateMUID FROM aux_template_assoc" + _
            " WHERE AssocMUID = '" + TagID + "' AND SourceMUID = 'Tag'"
        Dim dtt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        Dim templateMUID As String = ""
        If dtt.Rows.Count > 0 Then
            templateMUID = dtt.Rows(0)("TemplateMUID")

            qry = "SELECT DISTINCT aux_fieldmap.MUID, aux_fieldmap.CustomName, aux_tags.auxData " + _
                            " FROM aux_fieldmap, aux_tags, aux_template_assoc " + _
                            " WHERE (aux_fieldmap.TemplateMUID = aux_template_assoc.TemplateMUID) AND " + _
                            " (aux_template_assoc.AssocMUID ='" + TagID.ToString + "') AND " + _
                            " (aux_template_assoc.SourceMUID = 'Tag') AND " + _
                            " (aux_tags.FieldmapMUID = aux_fieldmap.MUID) AND " + _
                            " ( aux_tags.TagMUID = '" + TagID.ToString + "')" + _
                            " AND aux_template_assoc.TemplateMUID = '" + templateMUID + "'"
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)

            If dt.Rows.Count < 1 Then Return
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim DataCol As DataColumn = New DataColumn()
                DataCol.DataType = System.Type.GetType("System.String")
                DataCol.ColumnName = dt.Rows(i)("CustomName")
                AuxTable.Columns.Add(DataCol)
                Dim IDCol As DataColumn = New DataColumn()
                IDCol.DataType = System.Type.GetType("System.String")
                IDCol.ColumnName = dt.Rows(i)("MUID")
                AuxIDTable.Columns.Add(IDCol)
            Next
            Dim rowData As DataRow = AuxTable.NewRow()
            Dim rowID As DataRow = AuxIDTable.NewRow()
            For i As Integer = 0 To dt.Rows.Count - 1
                rowData(i) = dt.Rows(i)("auxData")
                rowID(i) = dt.Rows(i)("MUID")
            Next
            AuxTable.Rows.Add(rowData)
            AuxIDTable.Rows.Add(rowID)
        End If

        AuxTable.AcceptChanges()
        AuxIDTable.AcceptChanges()

        If Not myVGrid Is Nothing Then
            myVGrid.Dispose()
        End If
        myVGrid = New DevExpress.XtraVerticalGrid.VGridControl()
        myVGrid.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        AddHandler myVGrid.CellValueChanged, AddressOf myVGridControl1_CellValueChanged
        myVGrid.DataSource = AuxTable
        Me.Panel1.Controls.Add(myVGrid)
        myVGrid.BringToFront()
        myVGrid.Show()

    End Sub

    Private Sub GridControl_GroupByAllTags()
        cboTypeID.DataSource = Nothing
        cboPkgNum.DataSource = Nothing
        Dim qry = " SELECT MUID, TagNumber,PackageMUID,TypeMUID From tags"
        Dim DisplayTable As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        Dim myHdr() As String = Split("PackageNumber TypeName", " ")
        For Each s As String In myHdr
            Dim ThisColumn As DataColumn = New DataColumn(s, GetType(String))
            ThisColumn.ColumnName = s
            DisplayTable.Columns.Add(ThisColumn)
        Next
        Try

            For Each drow As DataRow In DisplayTable.Rows
                qry = "SELECT PackageNumber From package WHERE MUID = '" + drow("PackageMUID").ToString + "'"
                Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                If dt.Rows.Count > 0 Then
                    drow("PackageNumber") = dt.Rows(0)("packageNumber")
                Else
                    drow("PackageNumber") = ""
                End If
                qry = "SELECT TypeName From equipment_type WHERE MUID = '" + drow("TypeMUID").ToString + "'"
                dt = sqlPrjUtils.ExecuteQuery(qry)
                If dt.Rows.Count > 0 Then
                    drow("TypeName") = sqlPrjUtils.ExecuteQuery(qry).Rows(0)("TypeName")
                Else
                    drow("TypeName") = ""
                End If
            Next

            Me.GridControl1.DataSource = DisplayTable
            Me.DataNavigator1.DataSource = DisplayTable

        Catch ex As Exception
            Utilities.logErrorMessage("PkgEdit.PackageSelect_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
        Dim View As ColumnView = GridControl1.MainView
        View.Columns("MUID").Visible = False
        View.Columns("PackageMUID").Visible = False
        'View.Columns("PackageNumber").OptionsColumn.AllowEdit = True
        View.Columns("TypeMUID").Visible = False
        GridControl1.ForceInitialize()

        qry = "SELECT PackageNumber, MUID FROM package ORDER By PackageNumber"
        Dim myPkgNumTbl As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        cboPkgNum.DataSource = myPkgNumTbl
        cboPkgNum.DisplayMember = myPkgNumTbl.Columns("PackageNumber").ToString
        cboPkgNum.ValueMember = myPkgNumTbl.Columns("MUID").ToString
        cboPkgNum.SelectedIndex = -1
        qry = "SELECT TypeName, MUID FROM equipment_type "
        Dim myTypeIDTbl As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        cboTypeID.DataSource = myTypeIDTbl
        cboTypeID.DisplayMember = myTypeIDTbl.Columns("TypeName").ToString
        cboTypeID.ValueMember = myTypeIDTbl.Columns("MUID").ToString
        cboTypeID.SelectedIndex = -1

        Dim pkgNumCombo As RepositoryItemComboBox = New RepositoryItemComboBox
        pkgNumCombo.AutoComplete = True
        If myPkgNumTbl.Rows.Count > 0 Then
            For i As Integer = 0 To myPkgNumTbl.Rows.Count - 1
                PkgNumList.Add(myPkgNumTbl.Rows(i)("PackageNumber"))
            Next
        End If
        pkgNumCombo.Items.AddRange(PkgNumList)
        GridControl1.RepositoryItems.Add(pkgNumCombo)
        View.Columns("PackageNumber").ColumnEdit = pkgNumCombo

        Dim TypeNameCombo As RepositoryItemComboBox = New RepositoryItemComboBox
        TypeNameCombo.AutoComplete = True
        If myTypeIDTbl.Rows.Count > 0 Then
            For i As Integer = 0 To myTypeIDTbl.Rows.Count - 1
                TypeNameList.Add(myTypeIDTbl.Rows(i)("TypeName"))
            Next
        End If
        TypeNameCombo.Items.AddRange(TypeNameList)
        GridControl1.RepositoryItems.Add(TypeNameCombo)
        View.Columns("TypeName").ColumnEdit = TypeNameCombo

    End Sub


    Private Sub GridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Dim View As ColumnView = GridControl1.MainView
        Dim ParentView As GridView = View.ParentView
        Dim Row As DataRow = View.GetDataRow(View.FocusedRowHandle)
        btnUpdateTags.Enabled = True
        GridControl_AuxData(Row("MUID"), Row("TypeMUID"))
        '    GridControl_AuxData(View.GetFocusedRowCellValue(2))
    End Sub
    Private Sub btnUpdateAuxVals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateAuxVals.Click
        Dim View As ColumnView = GridControl1.MainView
        Dim TagID As String = View.GetDataRow(View.FocusedRowHandle)("MUID")

        If TagID > "" Then
            For j As Integer = 0 To myVGrid.Rows.Count - 1
                Dim colVal As String = myVGrid.GetCellValue(myVGrid.Rows(j), 0)
                Dim colID As String = AuxIDTable.Rows(0)(j)
                Dim qry = " UPDATE aux_tags SET auxData = @auxData" + _
                                " WHERE  (FieldmapMUID =@FieldmapMUID) AND (" + _
                                " TagMUID = @TagMUID)"
                Dim dt_param As DataTable = sqlPrjUtils.paramDT

                dt_param.Rows.Add("@auxData", colVal)
                dt_param.Rows.Add("@FieldmapMUID", colID.ToString)
                dt_param.Rows.Add("@TagMUID", TagID.ToString)

                sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                'Utilities.ExecuteRemoteNonQuery(qry, "")
            Next
        End If

    End Sub

    'Private Sub btnUpdateAuxVals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateAuxVals.Click
    '    Dim View As ColumnView = GridControl1.MainView
    '    Dim R As DataRow = View.GetDataRow(View.FocusedRowHandle)
    '    Dim TagID As Integer = R("TagID")

    '    If TagID > 0 Then
    '        Dim str As String = ""
    '        Dim i As Integer
    '        For i = 0 To Me.VGridControl1.Rows.Count - 2
    '            Dim row As DevExpress.XtraVerticalGrid.Rows.EditorRow = Me.VGridControl1.Rows(i)
    '            str = str + Me.VGridControl1.GetCellValue(row, 0) + "&001"
    '        Next
    '        str = str + Me.VGridControl1.GetCellValue(Me.VGridControl1.Rows(i), 0)
    '        Dim qry = useProjectDB + " UPDATE aux_tags SET aux_tags.auxData = '" + str + _
    '                        "' WHERE  aux_tags.TagID =" + TagID.ToString
    '        Utilities.ExecuteRemoteNonQuery(qry, "")
    '    End If

    'End Sub

    Private Sub VGridControl1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs)
        btnUpdateAuxVals.Enabled = True
    End Sub
    Private Sub myVGridControl1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs)
        btnUpdateAuxVals.Enabled = True
    End Sub
    Private Sub DataNavigator1_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataNavigator1.ButtonClick
        Dim View As ColumnView = GridControl1.MainView
        Dim ID = View.GetFocusedRowCellValue("ID")

        Select Case e.Button.ButtonType
            Case NavigatorButtonType.CancelEdit
                'Me.Dispose()
            Case NavigatorButtonType.Append

            Case NavigatorButtonType.EndEdit
            Case NavigatorButtonType.Remove
            Case NavigatorButtonType.Edit
        End Select
    End Sub

    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs)
        Dim View As GridView = sender
        e.Appearance.BackColor = Color.Empty
        If e.Column.FieldName = "PackageNumber" Then
            Dim cellval As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("PackageNumber"))
            If cellval = "" Then
                e.Appearance.BackColor = Me.tbx_ColorBlank.BackColor
            End If
        End If
        If e.Column.FieldName = "TypeName" Then
            Dim cellval As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("TypeName"))
            If cellval = "" Then
                e.Appearance.BackColor = Me.tbx_ColorBlank.BackColor
            End If
        End If
    End Sub




    Private Function VerifyRowValues()
        Return 0
    End Function
    Private Sub UpdateSelectedRecords()
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        Dim View As ColumnView = GridControl1.FocusedView

        'Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        For i As Integer = 0 To View.RowCount - 1
            If View.IsRowSelected(i) Then
                Dim TagID = View.GetRowCellValue(i, "MUID")
                Dim TypeID As String = IIf(Me.cboTypeID.Text > "", Me.cboTypeID.SelectedValue, View.GetRowCellValue(i, "TypeMUID"))
                Dim PkgID As String = IIf(Me.cboPkgNum.Text > "", Me.cboPkgNum.SelectedValue, View.GetRowCellValue(i, "PackageMUID"))

                Dim qry1 = "UPDATE tags Set TagNumber = @TagNumber," + _
                            " packageMUID = @PackageMUID," + _
                            " TypeMUID = @TypeMUID" + _
                            " WHERE MUID = @MUID"
                Dim dt_param As DataTable = sqlPrjUtils.paramDT

                dt_param.Rows.Add("@TagNumber", View.GetRowCellValue(i, "TagNumber"))
                dt_param.Rows.Add("@TypeMUID", TypeID)
                dt_param.Rows.Add("@PackageMUID", PkgID)
                dt_param.Rows.Add("@MUID", TagID)

                sqlPrjUtils.ExecuteNonQuery(qry1, dt_param)
            End If
        Next


        GridControl_GroupByAllTags()

        Me.Cursor = Cursors.Default
        Me.Enabled = True
    End Sub
    Private Sub UpdateModifiedRecords()
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False
        Dim View As ColumnView = GridControl1.FocusedView

        For i As Integer = 0 To View.RowCount - 1
            Dim Row As DataRow = View.GetDataRow(i)
            If Row.RowState = DataRowState.Modified Then
                'Dim qry1 = "UPDATE tags Set TagNumber = '" + Row("TagNumber") + "'," + _
                '            " packageMUID = '" + Row("PackageMUID") + "'," + _
                '            " TypeMUID = '" + Row("TypeMUID") + "'" + _
                '            " WHERE MUID = '" + Row("MUID") + "'"
                Dim qry1 = "UPDATE tags Set TagNumber = @TagNumber," + _
                            " packageMUID = @PackageMUID," + _
                            " TypeMUID = @TypeMUID" + _
                            " WHERE MUID = @MUID"
                Dim dt_param As DataTable = sqlPrjUtils.paramDT

                dt_param.Rows.Add("@TagNumber", Row("TagNumber"))
                dt_param.Rows.Add("@TypeMUID", Row("TypeMUID"))
                dt_param.Rows.Add("@PackageMUID", Row("PackageMUID"))
                dt_param.Rows.Add("@MUID", Row("MUID"))

                sqlPrjUtils.ExecuteNonQuery(qry1, dt_param)
            End If
        Next
        GridControl_GroupByAllTags()
        tableModified = False
        Me.Cursor = Cursors.Default
        Me.Enabled = True

    End Sub

    Private Sub btnUpdateTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateTags.Click

        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False


        Dim result As Windows.Forms.DialogResult
        Dim msg As String
        Dim View As ColumnView = GridControl1.FocusedView
        If tableModified Then
            msg = "You have individually modied some records; would you like to update them?"
            result = MessageBox.Show(msg, "Package Update", MessageBoxButtons.YesNo)
            If result = Windows.Forms.DialogResult.Yes Then
                UpdateModifiedRecords()
                View.ClearSelection()
                Return
            End If
        End If

        msg = "Do you wish to update selected tag record?"
        result = MessageBox.Show(msg, "Tag Update", MessageBoxButtons.YesNo)
        If result <> Windows.Forms.DialogResult.Yes Then Return
        tableModified = False

        UpdateSelectedRecords()
        Me.Cursor = Cursors.Default
        Me.Enabled = True

        '           MessageBox.Show("You must close the form to see the refreshed values")
    End Sub


    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        Dim View As ColumnView = GridControl1.FocusedView
        View.SelectAll()
    End Sub


    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If MessageBox.Show("Are you sure you want to delete the selected records?  This cannot be undone.", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        Dim View As ColumnView = GridControl1.FocusedView
        For i As Integer = 0 To View.RowCount - 1
            If View.IsRowSelected(i) Then
                Dim TagID = View.GetRowCellValue(i, "MUID")
                DeleteTag(View.GetRowCellValue(i, "MUID"), View.GetRowCellValue(i, "tagNumber"))
            End If
        Next
        GridControl_GroupByAllTags()

        Me.Cursor = Cursors.Default
        Me.Enabled = True

    End Sub


    Private Sub DeleteTag(ByVal _TagID As String, ByVal _Tag As String)
        'Dim query As String = "DELETE FROM tags WHERE MUID = '" + _TagID.ToString + "'"
        Try
            Dim query As String = "DELETE FROM tags WHERE MUID = @MUID"

            Dim dt_param As DataTable = sqlPrjUtils.paramDT

            dt_param.Rows.Add("@MUID", _TagID.ToString)

            sqlPrjUtils.ExecuteNonQuery(query, dt_param)

            'Utilities.ExecuteRemoteNonQuery(query, "")

            'need more cleanup here


        Catch ex As Exception
            MessageBox.Show("There was a problem deleting the selected tag.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim View As ColumnView = GridControl1.MainView
        Dim Row As DataRow = View.GetDataRow(View.FocusedRowHandle)
        tableModified = True
        If e.Column.FieldName = "TagNumber" Then
            Dim query As String = "SELECT * FROM tags WHERE TagNumber='" + Row("TagNumber") + "'"
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            If dt.Rows.Count > 0 Then
                MessageBox.Show("Tag number already in use")
                'ValidateCellValue = False
                query = "SELECT TagNumber FROM tags WHERE MUID='" + Row("MUID") + "'"
                dt = sqlPrjUtils.ExecuteQuery(query)
                Row("TagNumber") = dt.Rows(0)("TagNumber")
                GridControl1.ForceInitialize()
                sqlPrjUtils.CloseConnection()
                Return
            End If
        End If
        If e.Column.FieldName = "TypeName" Then
            Dim query As String = "SELECT MUID FROM equipment_type WHERE TypeName ='" + Row("TypeName") + "'"
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            If dt.Rows.Count > 0 Then
                Row("TypeMUID") = dt.Rows(0)("MUID")
            End If
        End If
        If e.Column.FieldName = "PackageNumber" Then
            Dim query As String = "SELECT MUID FROM package WHERE PackageNumber ='" + Row("PackageNumber") + "'"
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            If dt.Rows.Count > 0 Then
                Row("PackageMUID") = dt.Rows(0)("MUID")
            End If
        End If


    End Sub


    Private Sub TagSelect_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If tableModified Then
            Dim ret As System.Windows.Forms.DialogResult = MessageBox.Show("Table entries have been modified; would you like to update records?", "Update Records", MessageBoxButtons.YesNo)
            If ret = Windows.Forms.DialogResult.No Then Return
            UpdateModifiedRecords()
        End If
        sqlPrjUtils.CloseConnection()
    End Sub
End Class