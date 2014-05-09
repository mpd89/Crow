Imports System.Drawing.Imaging
Imports System.Drawing.Printing
'Imports System.Collections
Imports System.IO
'Imports System.Data.SqlClient
Imports daqartDLL
Imports DevExpress.XtraGrid
'Imports DevExpress.XtraEditors.Repository
'Imports DevExpress.XtraGrid.Views.BandedGrid
'Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
'Imports DevExpress.XtraVerticalGrid
'Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.Utils
Public Class EditDaqumentInfo
    Public Shared ViewName As String = ""
    Private myViews As daqartDLL.DataGridViews
    Private showInfo As String = ""
    Private myDoc As EditDaqumentUtil
    Private selectedWeldTableIndex As Integer = -1
    Private FormInitialized As Boolean = False
    Private dataReadOnly As Boolean = True
    Private myGridLayoutTable As DataTable

    Public Sub New(ByVal _myDoc As EditDaqumentUtil, ByVal _showInfo As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        showInfo = _showInfo
        myDoc = _myDoc
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal _myDoc As EditDaqumentUtil, ByVal _showInfo As String, ByVal _WeldNo As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        showInfo = _showInfo
        myDoc = _myDoc
        ' Add any initialization after the InitializeComponent() call.
        selectedWeldTableIndex = _WeldNo
    End Sub
    Private Sub AddDropDownCombo()
        Dim myFields1() As String = {"ClassID", "WPS", "NDEPcntReq"}
        Dim pv1 As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        pv1.Columns("SVCSPEC").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields1, _
                "tblWeldWPSLookup", "ClassID", "ClassID")
        pv1.Columns("WPS").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields1, _
                "tblWeldWPSLookup", "WPS", "WPS")
        pv1.Columns("NDEPcntReq").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields1, _
                "tblWeldWPSLookup", "NDEPcntReq", "NDEPcntReq")



        Dim myFields() As String = {"InchesOfWeld", "PipeSize", "Diameter"}
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        pv.Columns("WeldInches").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields, _
                "tblWeldInchesEQLookup", "InchesOfWeld", "InchesOfWeld")
        pv.Columns("PipeSize").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields, _
                "tblWeldInchesEQLookup", "PipeSize", "PipeSize")

    End Sub


    Private Sub EditDaqumentInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            VGridControl1.DataSource = Nothing
            GridControl1.DataSource = Nothing
            Me.GridControl1.Visible = True
            Me.VGridControl1.Visible = False

            Select Case showInfo
                Case "Default Weld Properties"
                    lbl_Info.Text = "Weld Default Properties"
                    VGridControl1.DataSource = myDoc.GetDefaultWeldPointInfoTable()
                    GridControl1.DataSource = myDoc.GetDefaultWeldPointInfoTable()
                    AddDropDownCombo()
                    SetupGridControl()
                Case "Daqument Weld List"
                    lbl_Info.Text = "Daqument Weld List"
                    VGridControl1.DataSource = myDoc.WeldPointInfoTable
                    GridControl1.DataSource = myDoc.WeldPointInfoTable
                    AddDropDownCombo()
                    SetupGridControl()
                Case "Weld Properties"
                    Dim myTag As String = myDoc.WeldPointInfoTable.Rows(selectedWeldTableIndex)("TagNo")
                    lbl_Info.Text = "Weld Tag: " + myTag
                    VGridControl1.DataSource = myDoc.WeldPointInfoTable
                    GridControl1.DataSource = myDoc.WeldPointInfoTable
                    AddDropDownCombo()
                    SetupGridControl()
                    VGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
                    VGridControl1.MakeRecordVisible(selectedWeldTableIndex)

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        myViews = New daqartDLL.DataGridViews("Daqument", "EditDaqumentInfo", GridControl1)
        SelectToolStripMenuItem.DropDownItems.Clear()
        For Each s As String In myViews.GetViewNames()
            Dim ts As ToolStripMenuItem = New ToolStripMenuItem
            ts.Text = s
            SelectToolStripMenuItem.DropDownItems.Add(ts) ' LayerInfoTbl.Rows(i)(1))
            AddHandler ts.Click, AddressOf btnLayer_Click
        Next
        FixedColumnsToolStripMenuItem.DropDownItems.Clear()

        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = GridControl1.MainView
        For Each clmn As DevExpress.XtraGrid.Columns.GridColumn In View.Columns
            clmn.OptionsColumn.FixedWidth = True
            Dim ts As ToolStripMenuItem = New ToolStripMenuItem
            ts.Text = clmn.Caption
            FixedColumnsToolStripMenuItem.DropDownItems.Add(ts)
            AddHandler ts.Click, AddressOf btnFixedColumns_Click
        Next
        FormInitialized = True
    End Sub
    Private Sub btnFixedColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ts As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If ts.Checked Then
            myViews.fixedColumns.Remove(ts.Text)
            ts.Checked = False
        Else
            myViews.fixedColumns.Add(ts.Text)
            ts.Checked = True
        End If
        myViews.SetSelectedFixedColumns()
    End Sub
    Private Sub btnLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To SelectToolStripMenuItem.DropDownItems.Count - 1
            Dim tss As ToolStripMenuItem = SelectToolStripMenuItem.DropDownItems(i)
            tss.Checked = False
        Next
        Dim ts As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        ts.Checked = True
        myViews.GetThisView(ts.Text)
    End Sub

    Private Sub PopulateVGridCboEdit(ByVal rowName As String, ByVal riCboEdit As DevExpress.XtraEditors.Repository.RepositoryItemComboBox, ByVal qry As String)
        If qry > "" Then
            'Dim dt As DataTable = Nothing
            'dt = daqartDLL.Utilities.ExecuteQuery(qry, "project")
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()

            For i As Integer = 0 To dt.Rows.Count - 1
                riCboEdit.Items.Add(dt.Rows(i)(0))
            Next
            VGridControl1.Rows(rowName).Properties.RowEdit = riCboEdit
        End If
    End Sub
    Private Sub PopulateGridCboEdit(ByVal colName As String, ByVal riCboEdit As DevExpress.XtraEditors.Repository.RepositoryItemComboBox, ByVal qry As String)
        If qry > "" Then
            'Dim dt As DataTable = Nothing
            'dt = daqartDLL.Utilities.ExecuteQuery(qry, "project")
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
            'sqlPrjUtils.CloseConnection()

            For i As Integer = 0 To dt.Rows.Count - 1
                riCboEdit.Items.Add(dt.Rows(i)(0))
            Next
            Dim ParentView As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
            Try
                ParentView.Columns(colName).ColumnEdit = riCboEdit
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub
    Private Sub SetupVGridControl()
        VGridControl1.Tag = 0
        Try
            For Each riCboEdit As DevExpress.XtraEditors.Repository.RepositoryItemComboBox In VGridControl1.RepositoryItems
                Dim dt As DataTable = Nothing
                Dim qry = ""
                Select Case riCboEdit.Name
                    Case "vgcCboArea"
                        PopulateVGridCboEdit("rowArea", riCboEdit, "SELECT Area From tblWeldTracking")
                    Case "vgcCboPipeSize"
                        PopulateVGridCboEdit("rowArea", riCboEdit, "SELECT PipeSize From tblWeldInchesEQLookup")
                    Case "vgcCboSpools"
                        'PopulateVGridCboEdit("rowSpoolTo", riCboEdit, "SELECT TagNo From tblSpoolList")
                        'PopulateVGridCboEdit("rowSpoolFrom", riCboEdit, "SELECT TagNo From tblSpoolList")
                    Case "vgcCboWeldStn"
                        'PopulateVGridCboEdit("rowTagNo", riCboEdit, "SELECT TagNo From tblWeldersList")
                    Case "vgcCboForemanName"
                        PopulateVGridCboEdit("rowForemanName", riCboEdit, "SELECT ForemanName From tblWeldTracking")
                    Case "vgcCboSVCSPEC"
                        PopulateVGridCboEdit("rowSVCSPEC", riCboEdit, "SELECT SVCSPEC From tblWeldTracking")
                    Case "vgcCboNDEPcntReq"
                        PopulateVGridCboEdit("rowNDEPcntReq", riCboEdit, "SELECT NDEPcntReq From tblWeldTracking")
                    Case "vgcNDEType"
                        PopulateVGridCboEdit("rowNDEType", riCboEdit, "SELECT NDEType From tblWeldTracking")
                    Case "vgcCboWeldInches"
                        'PopulateVGridCboEdit("rowWeldInches", riCboEdit, "SELECT InchesOfWeld From tblWeldInchesEQLookup")
                End Select
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If Me.selectedWeldTableIndex >= 0 Then
            VGridControl1.MakeRecordVisible(selectedWeldTableIndex)
        End If
    End Sub
    Private Sub SetupGridControl()
        '    Dim ParentView As GridView = gdv_Info.DefaultView
        '    ParentView.ColumnsCustomization()
        '    ParentView.CustomizationForm.Hide()

        GridControl1.Tag = 0
        Try
            For Each riCboEdit As DevExpress.XtraEditors.Repository.RepositoryItemComboBox In GridControl1.RepositoryItems
                Dim dt As DataTable = Nothing
                Dim qry = ""
                Dim dd As String = riCboEdit.Name
                Try

                    Select Case riCboEdit.Name

                        Case "gcCboArea"
                            PopulateGridCboEdit("Area", riCboEdit, "SELECT Area From tblWeldTracking")
                        Case "gcCboPipeSize"
                            PopulateGridCboEdit("PipeSize", riCboEdit, "SELECT PipeSize From tblWeldInchesEQLookup")
                        Case "gcCboSpools"
                            'PopulateGridCboEdit("SpoolTo", riCboEdit, "SELECT TagNo From tblSpoolList")
                            'PopulateGridCboEdit("SpoolFrom", riCboEdit, "SELECT TagNo From tblSpoolList")
                        Case "gcCboWeldStn"
                            'PopulateGridCboEdit("WeldStn", riCboEdit, "SELECT TagNo From tblWeldersList")
                        Case "gcCboForemanName"
                            PopulateGridCboEdit("ForemanName", riCboEdit, "SELECT ForemanName From tblWeldTracking")
                        Case "gcCboSVCSpec"
                            'PopulateGridCboEdit("SVCSPEC", riCboEdit, "SELECT SVCSPEC From tblWeldTracking")
                        Case "gcCboNDEPcntReq"
                            'PopulateGridCboEdit("NDEPcntReq", riCboEdit, "SELECT NDEPcntReq From tblWeldTracking")
                        Case "gcCboNDEType"
                            PopulateGridCboEdit("NDEType", riCboEdit, "SELECT NDEType From tblWeldTracking")
                        Case "gcCboWeldInches"
                            'PopulateGridCboEdit("WeldInches", riCboEdit, "SELECT InchesOfWeld From tblWeldInchesEQLookup")
                    End Select
                Catch ex As Exception
                    MessageBox.Show(ex.Message + "---" + dd)
                End Try


            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Dim ParentView As GridView = Me.GridControl1.DefaultView
        ParentView.OptionsView.ColumnAutoWidth = False
        'For Each col As DevExpress.XtraGrid.Columns.GridColumn In ParentView.Columns
        '    If col.Caption = "TagNo" Then
        '        col.OptionsColumn.FixedWidth = True
        '        col.Fixed = Columns.FixedStyle.Left

        '    End If
        '    col.OptionsColumn.FixedWidth = True
        '    'col.BestFit()
        'Next
    End Sub



    Private Sub GridView1_ValidatingEditor(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        If dataReadOnly Then
            e.Valid = False
        Else
            e.Valid = True
        End If
    End Sub
    Private Sub GridView1_InvalidValueException(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles GridView1.InvalidValueException
        If dataReadOnly Then
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
            e.WindowCaption = "Input Error"
            e.ErrorText = "The values are readonly"
        Else
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore
        End If

        ' Destroying the editor and discarding the wrong changes made within the edited cell
        GridView1.HideEditor()
    End Sub

    Private Sub VGridControl1_InvalidValueException(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles VGridControl1.InvalidValueException
        If dataReadOnly Then
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
            e.WindowCaption = "Input Error"
            e.ErrorText = "The values are readonly"
        Else
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore
        End If

        ' Destroying the editor and discarding the wrong changes made within the edited cell
        VGridControl1.HideEditor()
    End Sub

    Private Sub VGridControl1_ValidatingEditor(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles VGridControl1.ValidatingEditor
        'If VGridControl1.FocusedRow.Name = "rowAnatomy" Or _
        '   VGridControl1.FocusedRow.Name = "rowBusiness" Or _
        '   VGridControl1.FocusedRow.Name = "rowDesign" Or _
        '   VGridControl1.FocusedRow.Name = "History" Then
        '    If Convert.ToInt32(e.Value) > 100000 Then
        '        e.Valid = False
        '    End If
        'End If
        If dataReadOnly Then
            e.Valid = False
        Else
            e.Valid = True
        End If
    End Sub
    Private Sub VGridControl1_RecordCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraVerticalGrid.Events.GetCustomRowCellStyleEventArgs)
        Try
            'Dim dg As DevExpress.XtraVerticalGrid.VGridControl = sender
            'If e.Row.Name <> "rowWeldStatus" Then Exit Sub
            'Dim st = Convert.ToInt32(VGridControl1.GetCellValue(e.Row, e.RecordIndex))
            'riCboEdit.Appearance.BackColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor1(st)
            ''riCboEdit.()
            'riCboEdit.Appearance.ForeColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor2(st)
            'riCboEdit.Appearance.BackColor2 = Color.AliceBlue

            'riCboEdit.Appearance.BorderColor = Color.BlanchedAlmond
            ''If e.Column.FieldName = "Count" Or e.Column.FieldName = "Unit Price" Then
            ''Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Category"))
            ''End If
            ''e.Appearance.Font = New Font(e.Appearance.Font.Name, _
            ''   e.Appearance.Font.Size, FontStyle.Bold)
        Catch ex As Exception

        End Try
    End Sub
    'Private Sub UpdateWeldPointToDataBase()
    '    For i As Integer = 0 To myDoc.WeldPointInfoTable.Rows.Count - 1
    '        Dim dr As DataRow = myDoc.WeldPointInfoTable.Rows(i)
    '        If dr("ID") = 0 Then Return
    '        Dim qry As String = " "
    '        Dim selectQry As String = " "
    '        Dim valQry As String = " "
    '        For Each clm As DataColumn In dr.Table.Columns
    '            If clm.ColumnName <> "ID" Then
    '                If clm.ColumnName = "DateEntered" Then
    '                    valQry = valQry + clm.ColumnName + " = '" + Now.Date() + "',"
    '                Else
    '                    valQry = valQry + clm.ColumnName + " = '" + dr(clm.ColumnName).ToString + "',"
    '                End If
    '            End If
    '        Next
    '        valQry = valQry.Remove(valQry.Length - 1, 1)
    '        qry = " Update tblWeldTracking SET " + valQry + " WHERE ID =" + _
    '             dr("ID").ToString
    '        daqartDLL.Utilities.ExecuteScalar(qry, "project")

    '    Next
    'End Sub
    Private Sub GridView2_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs)
        Dim View As GridView = sender
        Dim match As Boolean = False
        If e.Column.FieldName = "WeldStatus" Then
            Dim st = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, e.Column.FieldName))
            e.Appearance.BackColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor1(st)
            e.Appearance.ForeColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor2(st)
            'e.Appearance.Font = New Font(e.Appearance.Font.Name, _
            '   e.Appearance.Font.Size, FontStyle.Bold)
        End If
        'If e.Column.FieldName = "Count" Or e.Column.FieldName = "Unit Price" Then
        'Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Category"))
        'End If
    End Sub

    Private Sub rdbColView_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbColView.CheckedChanged
        If Not FormInitialized Then Return
        If rdbColView.Checked Then
            Me.VGridControl1.Visible = True
            Me.GridControl1.Visible = False
            SetupVGridControl()
        End If
    End Sub

    Private Sub rdbTblView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbTblView.CheckedChanged
        If Not FormInitialized Then Return
        If rdbTblView.Checked Then
            Me.VGridControl1.Visible = False
            Me.GridControl1.Visible = True
            'SetupGridControl()
        End If
    End Sub


    Private Sub ckbReadOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbReadOnly.CheckedChanged
        If ckbReadOnly.Checked Then
            dataReadOnly = True
        Else
            dataReadOnly = False
        End If
    End Sub

    Private Sub SaveAsNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsNewToolStripMenuItem.Click
        Dim myForm As Form = New Daqument.EditDaqumentViewName
        If myForm.ShowDialog = Windows.Forms.DialogResult.OK Then
            If ViewName > "" Then
                myViews.SaveAsNewView(ViewName)
            End If
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        myViews.ShowGridPreview(showInfo)
    End Sub

    Private Sub ExportToPDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToPDFToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Me.VGridControl1.Visible Then
                Me.VGridControl1.ExportToPdf(SaveFileDialog1.FileName)
            Else
                Me.GridControl1.ExportToPdf(SaveFileDialog1.FileName)
            End If
        End If
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Me.VGridControl1.Visible Then
                Me.VGridControl1.ExportToXls(SaveFileDialog1.FileName)
            Else
                Me.GridControl1.ExportToXls(SaveFileDialog1.FileName)
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub EditDaqumentInfo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.GridControl1.Tag = 1 Or Me.VGridControl1.Tag = 1 Then
            Select Case showInfo
                Case "Default Weld Properties"
                    Dim dt As DataTable = GridControl1.DataSource
                    Dim dr As DataRow = dt.NewRow
                    '    
                    Dim myView As GridView = GridControl1.DefaultView
                    For i As Integer = 0 To myView.Columns.Count - 1
                        Dim myVal As Object = myView.GetRowCellValue(0, myView.Columns(i))
                        'Dim col As String = myView.Columns(i).Caption

                        'dr(i) = myVal
                        If Not IsDBNull(myVal) Then
                            If Not myVal Is Nothing Then
                                dr(i) = myVal.ToString
                            End If
                        End If
                    Next
                    myDoc.SetDefaultWeldPointRegistryValues(dr)
                Case "Daqument Weld List"
                Case "Weld Properties"
            End Select
        End If

    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Me.GridControl1.Tag = 1
    End Sub
    Private Sub VGridControl1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VGridControl1.CellValueChanged
        CType(sender, DevExpress.XtraVerticalGrid.VGridControl).Tag = 1
    End Sub
    Private Sub dgvMenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles dgvMenuStrip.ItemClicked

    End Sub
    Private Sub GridView1_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim View As GridView = sender
        Dim match As Boolean = False
        If e.Column.FieldName = "WeldStatus" Then
            Dim st = View.GetRowCellValue(e.RowHandle, e.Column.FieldName)
            'e.Appearance.BackColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor1(st)
            Dim i As Integer = Convert.ToInt32(st)
            e.Appearance.BackColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor1(i)
            e.Appearance.ForeColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor2(i)
            'e.Appearance.Font = New Font(e.Appearance.Font.Name, _
            '   e.Appearance.Font.Size, FontStyle.Bold)
        End If
        'If e.Column.FieldName = "Count" Or e.Column.FieldName = "Unit Price" Then
        'Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Category"))
        'End If
    End Sub
End Class