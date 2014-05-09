Imports system.collections.generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports DataStreams.Csv
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports daqartDLL
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Layout
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports System.Drawing.Printing

Public Class WeldMain
    Private tblWeldListingsFields() As String = {"TagNo", "WeldStn", "WeldStatus", "System", "Area", "DWGNO", "TestPkgNo", "EnteredBy", _
                            "DateEntered", "SpoolTo", "SpoolFrom", "PipeSize", "ConstCode", "WeldInches", _
                            "ForemanName", "SVCSPEC", "WPS", "NDEPcntReq", "Material", "WallThk", "WeldType", "NDEType", _
                            "DateTested", "AdvancedTesting", "TestResult", "VisInspDate", "VisInspName", _
                            "PMIDate", "PMIResult", "RejInches", "PWHT", "BHN", "Comments", "Revision", "WeldID", _
                            "DrawingID", "Disc"}

    Private tblWeldersListFields() As String = {"TagNo", "Shift", "Craft", "Name", "SSNo", _
                            "DOH1", "DOR1", "CS_GTAW", "CS_SMAW", _
                            "CR_GTAW", "CR_SMAW", "SS_GTAW", "SS_SMAW", "INCO_GTAW", "INCO_SMAW", _
                            "TiGTAW", "SS_PLT_SMAW", "CS_PLT_SMAW", "CS_PLT_FCAW_BG", _
                            "W_WO_Backing", "Comments", "Disc"}
    Private tblSpoolListFields() As String = {"Disc", "TagNo", "System", _
                            "Area", "OriginalPieceMark", "Delivered", "LoadNumber", _
                            "Received", "ReceivedBy", "Accepted", "Rejected", _
                            "LayDownLocation", "Comments", "OnSite", "FieldReqdDate", _
                            "FieldIssuedDate", "RecdBy", "TotalCount", _
                            "TotalRcvdCount", "TotalAcceptedCount", "TotalRejectedCount", _
                            "IssuedToField", "NewSpools", "DeletedSpools", "revSpool"}
    Private tblWeldEQInchesLookupFields() As String = {"PipeSize", "InchesOfWeld", "Diameter"}
    Private tblWeldWPSLookupFields() As String = {"ClassID", "WPS", "NDEPcntReq"}
    Private tblWPSProceduresFields() As String = {"WPS_No", "WPS_CompanyName", "WPS_Date"}
    Private PrintDoc As PrintDocument
    Private pgInfo() As PrintUtils.InfoSetting
    Private pgCtr As Integer = -1
    Private _DonePrinting As Boolean = False

    Private myViews As daqartDLL.DataGridViews

    Dim dt As DataTable
    Dim stredit As String
    Dim docClientCode As String
    Dim strtemp As String
    Dim tempid As String
    Dim logoPath As String
    Private printPgHdr As String
    Private permissionToUpdate As Boolean = True

    Private hdrFont As Font = New Font("Arial", 16, FontStyle.Regular)
    Private bdyFont As Font = New Font("Arial", 12, FontStyle.Regular)
    Private dt_WeldersList As DataTable = New DataTable
    Private dt_WeldEQInchesLookup As DataTable = New DataTable
    Private dt_WeldWPSLookup As DataTable = New DataTable
    Private dt_WeldListings As DataTable = New DataTable
    Private dt_WPSProcedures As DataTable = New DataTable
    Private WeldParameterForm As Form
    Public Shared tbxViewName As TextBox = New TextBox


    Private Sub WeldMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GetCompanyLogo()
            LoadDocumentData()
            LoadWPSProcedures()
            OLDLoadDgvReport()
            ShowReport("NDE % Complete")
            LoadWeldListings()
            ToolStrip1.BringToFront()
        Catch ex As Exception
            Utilities.logErrorMessage("Daqument.WeldMain_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub ShowDataRow(ByVal dr As DataRow, ByVal fs As String, ByVal c As Color)
        Dim s As String = ""

        If Not dr Is Nothing Then
            Dim items As Object() = dr.ItemArray

            For Each o As Object In items
                If s = "" Then
                    s = ("") + o.ToString()
                    tempid = o.ToString
                Else
                    s = (s & "; ") + o.ToString()
                End If
            Next o
        End If
        stredit = ""
        docClientCode = dr(2).ToString
        stredit = dr(0).ToString
        'MessageBox.Show(stredit)
        strtemp = ""
        strtemp = "" '"Revision= " & dr(4).ToString & "Sheet " & dr(7).ToString & " of " & dr(8).ToString & " Sheets"
        'MessageBox.Show(fs & s & "temp" & tempid.ToString & dr(4).ToString)
    End Sub

    Private Sub DocumentGridControl_DoubleClick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentGridControl.DoubleClick

        Cursor = Cursors.AppStarting
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = DocumentGridView.CalcHitInfo((TryCast(sender, Control)).PointToClient(Control.MousePosition))

        Dim View As ColumnView = Me.DocumentGridControl.MainView

        Try
            If View.FocusedRowHandle >= 0 Then
                ShowDataRow(DocumentGridView.GetDataRow(View.FocusedRowHandle), "", Color.White)

                Dim query As String = "select * from document_store  where DocumentMUID = '" + stredit + "'"
                Dim sqlDocUtils As DataUtils = New DataUtils("Daqument001")
                sqlDocUtils.OpenConnection()
                Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
                sqlDocUtils.CloseConnection()


                If dt Is Nothing Then Return
                If Not (dt.Rows(0)("DocumentImage") Is Nothing) Then
                    Dim frm_DocumentViewer As New Daqument.EditDaqument(stredit, "", "Welds")
                    frm_DocumentViewer.Show()
                Else
                    MessageBox.Show("Image was not stored for the document")
                End If
            ElseIf DocumentGridView.FocusedRowHandle >= 0 Then
                ShowDataRow(DocumentGridView.GetDataRow(DocumentGridView.FocusedRowHandle), "Focused Row: ", Color.Yellow)
            Else
                ShowDataRow(Nothing, "Empty...", Color.DeepSkyBlue)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Cursor = Cursors.Default
    End Sub


    Public Sub LoadDocumentData()
        Dim query As String = "SELECT documents.MUID,documents.EngCode,documents.ClientCode," & _
            " documents.Description,documents.Revision AS Rev, documents.Sheet+'/'+ documents.Sheets AS Sht," & _
            " documents.DateLoaded, document_type.Code AS DocumentType " & _
            " FROM documents INNER JOIN" & _
            " drawing_layers ON documents.MUID = drawing_layers.DrawingMUID INNER JOIN" & _
            " document_type ON documents.DocumentTypeMUID = document_type.MUID" & _
            " WHERE (drawing_layers.layerDescription = N'Weld Tracking')" & _
            " AND ProjectMUID = '" & Utilities.GetProjectID(runtime.selectedProject).ToString & "'"

        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
        sqlDocUtils.OpenConnection()
        dt = sqlDocUtils.ExecuteQuery(query) 'DocumentDataManager.GetDataTable()

        For Each dr As DataRow In dt.Rows
            dr(4) = Utilities.TranslateRev(dr(4))
        Next
        dt.Columns(0).ColumnMapping = MappingType.Hidden
        dt.Columns(2).ColumnMapping = MappingType.Hidden
        dt.Columns(5).ColumnMapping = MappingType.Hidden

        DocumentGridControl.DataSource = Nothing
        If Not dt Is Nothing Then
            StatusStrip1.Items(2).Text = dt.Rows.Count
            DocumentGridControl.DataSource = dt
            'DataNavigator1.DataSource = dt
        End If
    End Sub
    Private Function GetTable(ByVal fieldStr() As String, ByVal tblName As String) As DataTable
        'Dim query As String = useServerDB + " SELECT EmployeeID, Last_Name + ', '+ First_Name + ' ' + Middle_Init AS display  FROM Employee ORDER BY Last_Name ASC,First_Name ASC, Middle_Init ASC"
        Dim qryFields As String = ""
        For i As Integer = 0 To fieldStr.Length - 1
            qryFields = qryFields + fieldStr(i) + ","
        Next
        qryFields = qryFields.Remove(qryFields.Length - 1, 1)
        Dim qry = "SELECT " + qryFields + " FROM " + tblName

        'Return (Utilities.ExecuteQuery(qry, "project"))
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()
        Return dt
    End Function

    Private Sub SetDGVDataSource(ByVal dt As DataTable, ByVal dgv As DevExpress.XtraGrid.GridControl)
        dgv.DataSource = Nothing
        dgv.DataSource = dt
        Dim View As ColumnView = dgv.MainView
        If View.Columns.Count > 0 Then
            View.Columns(0).Visible = False
            For i As Integer = 0 To View.Columns.Count - 1
                View.Columns(i).OptionsColumn.ReadOnly = True
            Next
        End If
        dgv.Refresh()
    End Sub
    Private Sub LoadWPSProcedures()
        dt_WPSProcedures.Dispose()
        Dim qry As String = "SELECT * FROM WPS_fields"

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        dt_WPSProcedures = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()


        'SetDGVDataSource(dt_WPSProcedures, Me.dgv_WPSProcedures)
        dgv_WPSProcedures.DataSource = Nothing
        dgv_WPSProcedures.DataSource = dt_WPSProcedures
        Dim View As ColumnView = dgv_WPSProcedures.MainView
        If View.Columns.Count > 0 Then
            For i As Integer = 0 To View.Columns.Count - 1
                View.Columns(i).Visible = False
                View.Columns(i).OptionsColumn.ReadOnly = True
            Next
        End If
        View.Columns("WPS_No").Visible = True
        View.Columns("WPS_CompanyName").Visible = True
        View.Columns("WPS_Date").Visible = True

        dgv_WPSProcedures.Refresh()
    End Sub


    Public Sub GetCompanyLogo()
        Dim qry = "SELECT DocumentImage FROM projectImages WHERE Name = 'Logo128'"
        'Dim table As DataTable = (Utilities.ExecuteQuery(qry, "project"))
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim table As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        'Specify general settings

        Dim dr As String = runtime.AbsolutePath + "sites\images\"
        IO.Directory.CreateDirectory(dr)
        logoPath = runtime.AbsolutePath + "sites\images\logo128.jpg"
        '        Dim fs As String = runtime.AbsolutePath + "sites\images\logo128.jpg"
        'File.Delete(fs)

        If (Not table.Rows(0)(0) Is Nothing) Then
            Dim buffer() As Byte = table.Rows(0)(0)
            Dim m As New MemoryStream(buffer)
            Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(m)
            Image.Save(logoPath, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub
    Sub ShowGridPreview(ByVal grid As GridControl)
        ' Check whether the GridControl can be previewed.
        If Not grid.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting.v7.2.dll' is not found", "Error")
            Return
        End If
        Dim lView As LayoutView = New LayoutView(grid)
        'grid.MainView = lView
        'lView.OptionsPrint.UsePrintStyles = True
        ' Enable the AppearancePrint.EvenRow property's settings.

        Dim ps As New PrintingSystem()
        ' Create a link that will print a control.
        Dim link As New PrintableComponentLink(ps)
        ' Specify the control to be printed.
        link.Component = grid
        ' Subscribe to the CreateReportHeaderArea event used to generate the report header.
        AddHandler link.CreateReportHeaderArea, AddressOf CreateReportHeaderArea
        ' Generate the report.
        link.CreateDocument()
        ' Show the report.
        link.ShowPreview()

        ' Opens the Preview window.
        '        grid.ShowPrintPreview()
    End Sub
    Private Sub CreateReportHeaderArea(ByVal sender As System.Object, ByVal e As CreateAreaEventArgs)
        Dim pgSize As SizeF = e.Graph.ClientPageSize
        Dim rec As RectangleF = New RectangleF(0, 0, pgSize.Width, 40)
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("TimesRoman", 24, FontStyle.Bold)
        e.Graph.DrawString(printPgHdr, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None)

        'e.Graph.Font = New Font("TimesRoman", 12, FontStyle.Bold)
        'Dim mydate As String = "Date: " + Now.Date()
        'Dim strSize As SizeF = e.Graph.MeasureString(mydate)
        'rec = New RectangleF(New Point(pgSize.Width - strSize.Width, 40), strSize)
        'e.Graph.DrawString(mydate, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None)

        'Dim mystr As String = "Requested By: " + Utilities.GetUserInfo(runtime.thisUser).Rows(0)(1)
        'strSize = e.Graph.MeasureString(mystr)
        'rec = New RectangleF(New Point(pgSize.Width - strSize.Width, 60), strSize)
        'e.Graph.DrawString(mystr, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None)
        'If Not logoPath Is Nothing Then
        '    Dim img As Image = Image.FromFile(logoPath)
        '    rec = New RectangleF(New Point(0, 0), img.Size)
        '    e.Graph.DrawImage(img, rec, DevExpress.XtraPrinting.BorderSide.None, Color.Violet)
        'End If

    End Sub

    'Private Sub tsmi_PrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_PrintPreview.Click
    '    Select Case Me.tabWPSProcedures.SelectedIndex
    '        Case 0
    '            printPgHdr = "Document List"
    '            ShowGridPreview(Me.DocumentGridControl)
    '        Case 1
    '            printPgHdr = "Weld WPS Lookup"
    '            ShowGridPreview(Me.dgv_EQInchesLookup)
    '        Case 2
    '            printPgHdr = "Weld EQ Inches Lookup"
    '            ShowGridPreview(Me.dgv_EQInchesLookup)
    '        Case 3
    '            printPgHdr = "Welders List"
    '            ShowGridPreview(Me.dgv_WeldersList)
    '        Case 4
    '            printPgHdr = "Weld Report"
    '            ShowGridPreview(Me.dgv_Report)
    '        Case 5

    '        Case Else
    '    End Select
    'End Sub
    Private Sub tsmi_PrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_PrintPreview.Click
        Select Case Me.tabWPSProcedures.SelectedIndex
            Case 0
                Dim logoPath = runtime.AbsolutePath + "sites\images\logo128.jpg"
                Dim logoImg As Image = New Bitmap(System.Drawing.Image.FromFile(logoPath))
                'logoImg.MakeTransparent()
                'Dim prtOption As New daqartDLL.DevXPrintOptions.PageHeaderStructure
                'prtOption.hdrText = "Weld Tracking" 'Me.tabWPSProcedures.SelectedTab.Text"
                'prtOption.hdrPrint = True

                'Dim pr As New daqartDLL.DevXPrintImage(PrintingSystem2, logoImg)
                'pr.printHeader = prtOption
                'pr.ShowPreview()

                'Dim pr As New daqartDLL.DevXtraPrintImage(PrintingSystem2, logoImg)
                'pr.printHeader = prtOption
                'pr.ShowPreview()
                Dim pr As New daqartDLL.DevXtraPrintGrid(PrintingSystem2, Me.DocumentGridControl)

                '    Dim img As Bitmap = CType(Bitmap.FromFile("fish.bmp"), Bitmap)
                '    img.MakeTransparent()

                '    Dim lesson As New Lesson9(printingSystem1)
                '    lesson.ShowPreview()
            Case 4
                printPgHdr = "Weld Report"
                'ShowGridPreview(Me.dgv_Report)
            Case 5

            Case Else
        End Select
    End Sub

    Private Sub UpdateRow(ByVal dgv As DevExpress.XtraGrid.GridControl, ByVal tblName As String, ByVal title As String)
        Dim View As ColumnView = dgv.MainView
        Dim sr() As Integer = View.GetSelectedRows()
        If sr.Length > 0 Then
            If View.IsDataRow(sr(0)) Then
                Dim dr As DataRow = View.GetDataRow(sr(0))
                Dim myForm As New WeldLookupTbl(dr, tblName, "Update", title)
                myForm.ShowDialog()
            End If
        End If
    End Sub
    Private Sub InsertRow(ByVal dgv As DevExpress.XtraGrid.GridControl, ByVal tblName As String, ByVal title As String)
        Dim dt As DataTable = dgv.DataSource
        Dim dr As DataRow = dt.NewRow
        Dim myForm As New WeldLookupTbl(dr, tblName, "Update", title)
        myForm.ShowDialog()
    End Sub
    Private Sub DeleteRow(ByVal dgv As DevExpress.XtraGrid.GridControl, ByVal tblName As String, ByVal title As String)
        Dim View As ColumnView = dgv.MainView
        Dim sr() As Integer = View.GetSelectedRows()
        If sr.Length > 0 Then
            If View.IsDataRow(sr(0)) Then
                Dim dr As DataRow = View.GetDataRow(sr(0))
                Dim myForm As New WeldLookupTbl(dr, tblName, "Delete", title)
                myForm.ShowDialog()
            End If
        End If
    End Sub


    'Private Sub btnReportWeldTracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.radioDailyWeldCount.Checked Then

    '        'Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()
    '        'If printDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        '    'PrintPackages()
    '        '    If Not PrintDoc Is Nothing Then
    '        '        PrintDoc.Dispose()
    '        '    End If
    '        '    PrintDoc = New PrintDocument()









    '        '    PrintDoc.DocumentName = "Print Packages"

    '        '    AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
    '        '    AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
    '        '    AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage

    '        '    Cursor.Current = Cursors.Default
    '        '    printDialog.Document = Me.PrintDoc
    '        '    printDialog.ShowDialog()
    '        'End If


    '        Dim query As String = "Select * FROM tblWeldTracking ORDER BY Area ASC, DWGNO ASC"
    '        Dim dt As New DataTable
    '        dt = Utilities.ExecuteQuery(query, "project")
    '        Me.dgv_Report.DataSource = dt

    '        Dim cView As ColumnView = Me.dgv_Report.DefaultView

    '        For i As Integer = 0 To cView.Columns.Count - 1
    '            cView.Columns(i).Visible = False
    '        Next

    '        cView.Columns("TagNo").Visible = True
    '        cView.Columns("DWGNO").Visible = True
    '        cView.Columns("Area").Visible = True
    '        cView.Columns("WeldStatus").Visible = True
    '        cView.Columns("WeldID").Visible = True

    '        Dim ParentView As GridView = Me.dgv_Report.DefaultView
    '        ParentView.ColumnsCustomization()

    '    End If


    'End Sub

    Private Sub printDoc_BeginPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        pgCtr = 0
        'PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize = pgInfo(0).ppSize
        If pgInfo(pgCtr).Landscape Then
            PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = True
        Else
            PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = False
        End If
    End Sub


    Private Sub printDoc_EndPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        _DonePrinting = True
    End Sub


    Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        If pgInfo(pgCtr).PrintHdr Then
            PrintUtils.PrintPageHeader(e, pgInfo(pgCtr).Heading, pgInfo(pgCtr).SubHeading)
        End If
        If Not pgInfo(pgCtr).pgBody Is Nothing Then
            PrintUtils.PrintPageBody(e, pgInfo(pgCtr))
        End If
        If pgInfo(pgCtr).PrintFooter Then
            PrintUtils.PrintPageFooter(e, pgInfo(pgCtr).PgNum, pgInfo.Length)
        End If
        pgCtr = pgCtr + 1
        If pgCtr < pgInfo.Length Then
            If Not pgInfo(pgCtr).pkSize Is Nothing Then
                e.PageSettings.PaperSize = pgInfo(pgCtr).pkSize
            End If
            If pgInfo(pgCtr).Landscape Then
                e.PageSettings.Landscape = True
            Else
                e.PageSettings.Landscape = False
            End If
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

    End Sub

    Private Sub SelectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SaveAsNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnAddNewWPSProcedure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewWPSProcedure.Click
        Dim myForm As New Daqument.WeldWPSProcFormView(0)
        myForm.ShowDialog()
        LoadWPSProcedures()
    End Sub

    Private Sub dgv_WPSProcedures_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_WPSProcedures.DoubleClick
        Dim View As ColumnView = Me.dgv_WPSProcedures.MainView
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = GridView6.CalcHitInfo((TryCast(sender, Control)).PointToClient(Control.MousePosition))

        Dim ParentView As GridView = View.ParentView

        Try
            'If hi.RowHandle >= 0 Then
            '    ShowDataRow(GridView6.GetDataRow(hi.RowHandle), "", Color.White)
            '    Dim myForm As New Daqument.WeldWPSProcFormView(View.GetFocusedRowCellValue("ID"))
            '    myForm.ShowDialog()
            '    LoadWPSProcedures()
            'ElseIf GridView6.FocusedRowHandle >= 0 Then
            '    ShowDataRow(GridView6.GetDataRow(GridView6.FocusedRowHandle), "Focused Row: ", Color.Yellow)
            'Else
            '    ShowDataRow(Nothing, "Empty...", Color.DeepSkyBlue)
            'End If


            Dim myForm As New Daqument.WeldWPSProcFormView(View.GetFocusedRowCellValue("ID"))
            myForm.ShowDialog()
            LoadWPSProcedures()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub



    Private Sub ImportNDEPercentTableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportNDEPercentTableToolStripMenuItem.Click
        Dim sysFields() As String = {"ClassID", "WPS", "NDEPcntReq"}
        Dim sysReqFields() As String = {"ClassID", "WPS", "NDEPcntReq"}
        'Dim myForm As Daqument.WeldImportInchesEQLookup = New Daqument.WeldImportInchesEQLookup()
        Dim myForm As CommonForms.ImportCSV = New CommonForms.ImportCSV("Import WPS/NDE % Requirement Table", runtime.selectedProject)
        myForm.sysTableFields = sysFields
        myForm.sysTableName = "tblWeldWPSLookup"
        myForm.requiredFields = sysReqFields
        myForm.uniqueField = "ClassID"
        myForm.Show()
    End Sub

    Private Sub ImportWeldersListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IImportWeldersListToolStripMenuItem.Click
        'Dim sysFields() As String = {"TagNo", "Shift", "Craft", "Name", "SSNo", "DOH1", "DOR1", _
        '        "CS_GTAW", "CS_SMAW", "CR_GTAW", "CR_SMAW", "INCO_GTAW", "INCO_SMAW", _
        '        "TiGTAW", " SS_PLT_SMAW", "CS_PLT_SMAW", " CS_PLT_FCAW_BG", _
        '        "W_WO_Backing", "Comments", "Disc", "Active"}
        Dim sysReqFields() As String = {"TagNo", "Name"}
        'Dim myForm As Daqument.WeldImportInchesEQLookup = New Daqument.WeldImportInchesEQLookup()
        Dim myForm As CommonForms.ImportCSV = New CommonForms.ImportCSV("Import Welders List", runtime.selectedProject)
        myForm.sysTableFields = tblWeldersListFields
        myForm.sysTableName = "tblWeldersList"
        myForm.requiredFields = sysReqFields
        myForm.uniqueField = "TagNo"
        myForm.Show()
    End Sub

    Private Sub ImportSpoolListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportSpoolListToolStripMenuItem.Click
        'Dim sysFields() As String = {"Disc", "TagNo", "System", _
        '        "Area", "OriginalPieceMark", "Deilvered", "LoadNumber", _
        '        "Received", "ReceivedBy", "Accepted", "Rejected", _
        '        "LayDownLocation", "Comments", "OnSite", "FieldReqdDate", _
        '        "FieldIssuedDate", "RecdBy", "TotalCount", _
        '        "TotalRcvdCount", "TotalAcceptedCount", "TotalRejectedCount", _
        '        "IssuedToField", "NewSpool", "DeletedSpools", "revSpool"}
        Dim sysReqFields() As String = {"TagNo"}
        'Dim myForm As Daqument.WeldImportInchesEQLookup = New Daqument.WeldImportInchesEQLookup()
        Dim myForm As CommonForms.ImportCSV = New CommonForms.ImportCSV("Import SpoolList", runtime.selectedProject)
        myForm.sysTableFields = tblSpoolListFields
        myForm.sysTableName = "tblSpoolList"
        myForm.requiredFields = sysReqFields
        myForm.uniqueField = "TagNo"
        myForm.Show()
    End Sub

    Private Sub ImportPipeInchesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        Dim sysFields() As String = {"PipeSize", "InchesOfWeld", "Diameter"}
        Dim sysReqFields() As String = {"PipeSize", "InchesOfWeld", "Diameter"}
        Dim myForm As CommonForms.ImportCSV = New CommonForms.ImportCSV("Import PipeInches/Diameter Conversion Table", runtime.selectedProject)
        myForm.sysTableFields = sysFields
        myForm.sysTableName = "tblWeldInchesEQLookup"
        myForm.requiredFields = sysReqFields
        myForm.uniqueField = "PipeSize"
        myForm.Show()
    End Sub
    ''' <summary>
    ''' ''''''''''''''''
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WPSNDELookupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WPSNDELookupToolStripMenuItem.Click
        Dim sysReqFields() As String = {"ClassID", "WPS", "NDEPcntReq"}
        Dim myForm As CommonForms.EditLookupTable = New CommonForms.EditLookupTable("WPS/NDE % Table")
        myForm.sysTableFields = tblWeldWPSLookupFields
        myForm.sysTableName = "tblWeldWPSLookup"
        myForm.requiredFields = sysReqFields
        myForm.uniqueField = "ClassID"
        myForm.Show()
    End Sub

    Private Sub SpoolListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpoolListToolStripMenuItem.Click
        'Dim sysFields() As String = {"Disc", "TagNo", "System", _
        '        "Area", "OriginalPieceMark", "Deilvered", "LoadNumber", _
        '        "Received", "ReceivedBy", "Accepted", "Rejected", _
        '        "LayDownLocation", "Comments", "OnSite", "FieldReqdDate", _
        '        "FieldIssuedDate", "RecdBy", "TotalCount", _
        '        "TotalRcvdCount", "TotalAcceptedCount", "TotalRejectedCount", _
        '        "IssuedToField", "NewSpool", "DeletedSpools", "revSpool"}
        Dim sysReqFields() As String = {"TagNo"}
        'Dim myForm As Daqument.WeldImportInchesEQLookup = New Daqument.WeldImportInchesEQLookup()
        Dim myForm As CommonForms.EditLookupTable = New CommonForms.EditLookupTable("SpoolList")
        myForm.sysTableFields = tblSpoolListFields
        myForm.sysTableName = "tblSpoolList"
        myForm.requiredFields = sysReqFields
        myForm.uniqueField = "TagNo"
        myForm.Show()
    End Sub

    Private Sub WeldersListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeldersListToolStripMenuItem.Click
        'Dim sysFields() As String = {"TagNo", "Shift", "Craft", "Name", "SSNo", "DOH1", "DOR1", _
        '        "CS_GTAW", "CS_SMAW", "CR_GTAW", "CR_SMAW", "INCO_GTAW", "INCO_SMAW", _
        '        "TiGTAW", " SS_PLT_SMAW", "CS_PLT_SMAW", " CS_PLT_FCAW_BG", _
        '        "W_WO_Backing", "Comments", "Disc", "Active"}
        Dim sysReqFields() As String = {"TagNo", "Name"}
        'Dim myForm As Daqument.WeldImportInchesEQLookup = New Daqument.WeldImportInchesEQLookup()
        Dim myForm As CommonForms.EditLookupTable = New CommonForms.EditLookupTable("Welders List")
        myForm.sysTableFields = tblWeldersListFields
        myForm.sysTableName = "tblWeldersList"
        myForm.requiredFields = sysReqFields
        myForm.uniqueField = "TagNo"
        myForm.Show()
    End Sub

    Private Sub ForemanNamesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForemanNamesToolStripMenuItem.Click
        Dim sysFields() As String = {"TSGroup", "ForemanName"}
        Dim sysReqFields() As String = {"TSGroup", "ForemanName"}
        Dim myForm As CommonForms.EditLookupTable = New CommonForms.EditLookupTable("Foreman Names")
        myForm.sysTableFields = sysFields
        myForm.sysTableName = "tblForemanName"
        myForm.requiredFields = sysReqFields
        myForm.uniqueField = "TSGroup"
        myForm.Show()
    End Sub

    Private Sub WeldInchesToDiameterConversionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeldInchesToDiameterConversionToolStripMenuItem.Click
        Dim sysFields() As String = {"PipeSize", "InchesOfWeld", "Diameter"}
        Dim sysReqFields() As String = {"PipeSize", "InchesOfWeld", "Diameter"}
        Dim myForm As CommonForms.EditLookupTable = New CommonForms.EditLookupTable("Weld PipeInches/Diameter Conversion Table")
        myForm.sysTableFields = sysFields
        myForm.sysTableName = "tblWeldInchesEQLookup"
        myForm.requiredFields = sysReqFields
        myForm.uniqueField = "PipeSize"
        myForm.Show()
    End Sub

    Private Sub DailyWeldCountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.lblReport.Text = "Daily Weld Count"

    End Sub
    Private Sub ReportQuery(ByVal ReportName As String)
        Dim qry As String = ""
        Select Case ReportName
            Case "NDE % Complete"
                qry = " SELECT TagNo, WeldStn, WeldStatus, System, Area, DWGNO, " + _
                    "WeldInches, SVCSPEC, WPS, NDEPcntReq, WeldType, NDEType, TestResult "
            Case "Weld Stencils"
                qry = " SELECT TagNo, WeldStn, WeldStatus, System, Area, DWGNO, " + _
                    "WeldInches, SVCSPEC, WPS, NDEPcntReq, WeldType, NDEType, TestResult"
            Case "Weld Status"
                qry = " SELECT TagNo, WeldStn, WeldStatus, System, Area, DWGNO, " + _
                    "WeldInches, SVCSPEC, WPS, NDEPcntReq, WeldType, NDEType, TestResult"
            Case "Daily NDE Report"
                qry = " SELECT TagNo, WeldStn, WeldStatus, System, Area, DWGNO, " + _
                    "WeldInches, SVCSPEC, WPS, NDEPcntReq, WeldType, NDEType, TestResult"
            Case "Daily Weld Count"
                qry = " SELECT TagNo, WeldStn, WeldStatus, System, Area, DWGNO, " + _
                    "WeldInches, SVCSPEC, WPS, NDEPcntReq, WeldType, NDEType, TestResult"
        End Select


        qry = qry + " FROM tblWeldTracking "
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()
        If Not GridControl1.DataSource Is Nothing Then
            GridControl1.DataSource.Dispose()
        End If
        GridControl1.DataSource = dt
        Dim View As GridView = GridControl1.FocusedView
        GridView1.SortInfo.ClearAndAddRange(New GridColumnSortInfo() { _
           New GridColumnSortInfo(View.Columns("NDEPcntReq"), DevExpress.Data.ColumnSortOrder.Ascending), _
           New GridColumnSortInfo(View.Columns("WeldStatus"), DevExpress.Data.ColumnSortOrder.Descending), _
           New GridColumnSortInfo(View.Columns("WPS"), DevExpress.Data.ColumnSortOrder.Ascending) _
        }, 2)


    End Sub
    Private Sub ShowReport(ByVal ReportName As String)
        ReportQuery(ReportName)
        GridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
        Me.lblReport.Text = ReportName
        GridView1.OptionsView.ShowFooter = True
        Dim itm As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm.SummaryType = DevExpress.Data.SummaryItemType.Count
        itm.DisplayFormat = "Total Weld Count {0}"
        itm.ShowInGroupColumnFooter = GridView1.Columns("TagNo")
        itm.Tag = 1
        itm.FieldName = "TagNo"

        Dim itm2 As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm2.SummaryType = DevExpress.Data.SummaryItemType.Custom
        itm2.DisplayFormat = "NDE % Complete {0}"
        itm2.ShowInGroupColumnFooter = GridView1.Columns("WeldStatus")
        itm2.Tag = 2
        itm2.FieldName = "WeldStatus"

        'GridView1.Columns("TagNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'GridView1.Columns("TagNo").SummaryItem.DisplayFormat = "Count {0}"
        'GridView1.Columns("WeldInches").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns("WeldInches").SummaryItem.DisplayFormat = "Count {0:n2}"
        'GridView1.Columns("RejInches").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
        'GridView1.Columns("RejInches").SummaryItem.DisplayFormat = "Count {0:n2}"
        GridView1.BestFitColumns()
    End Sub
    Private Sub OLDLoadDgvReport()
        GridControl1.DataSource = CommonForms.EditLookupTable.myDataTable(tblWeldListingsFields, "tblWeldTracking")

        Dim hideClms() As String = {"Disc", "System", "TestPkgNo", "EnteredBy", _
                            "SpoolTo", "SpoolFrom", "PipeSize", "ConstCode", _
                            "ForemanName", "SVCSPEC", "WPS", "NDEPcntReq", "Material", "WallThk", "WeldType", "NDEType", _
                            "DateTested", "AdvancedTesting", "VisInspDate", "VisInspName", _
                            "PMIDate", "PMIResult", "RejInches", "PWHT", "BHN", _
                            "DrawingID"}


        'For i As Integer = 0 To GridView1.Columns.Count - 1
        '    For Each s As String In hideClms
        '        If GridView1.Columns(i).Caption = s Then
        '            GridView1.Columns(i).Visible = False
        '        End If
        '    Next
        'Next
        'GridView1.Columns("WeldStatus").ColumnEdit = tblWeldStatusLookupEdit()

        'Dim myFields() As String = {"DateEntered", "WeldStn", "Area", "TestResult"}
        'For i As Integer = 0 To tblWeldListingsFields.Length - 1
        '    Dim itm As GridSummaryItem = GridView1.GroupSummary.Add()
        '    itm.FieldName = tblWeldListingsFields(i)
        '    itm.SummaryType = DevExpress.Data.SummaryItemType.Count
        '    itm.DisplayFormat = "Total Counts = {0}"

        'Next
        'Dim item1 As GridGroupSummaryItem = New GridGroupSummaryItem()
        'item1.FieldName = "TagNo"
        'item1.SummaryType = DevExpress.Data.SummaryItemType.Count
        'item1.DisplayFormat = "Total Welds = {0}"
        'item1.Tag = 1
        'item1.ShowInGroupColumnFooter = GridView1.Columns("TagNo")

        '' Customize the total summary.
        'GridView1.Columns("NDEPcntReq").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
        'GridView1.Columns("NDEPcntReq").SummaryItem.DisplayFormat = "NDE % Complete ={0:n2}%"
        'GridView1.Columns("NDEPcntReq").SummaryItem.Tag = 2
        'CType(GridView1.Columns("NDEPcntReq").View, GridView).OptionsView.ShowFooter = True
        'Dim item3 As GridGroupSummaryItem = New GridGroupSummaryItem()
        'item3.FieldName = "NDEPcntReq"
        'item3.SummaryType = DevExpress.Data.SummaryItemType.Custom
        'item3.DisplayFormat = "NDE % Complete ={0:n2}%"
        'item3.Tag = 2
        'item3.ShowInGroupColumnFooter = GridView1.Columns("WeldInches")

        'GridView1.GroupSummary.Add(item1)
        GridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways

        myViews = New daqartDLL.DataGridViews("Daqument", "EditDaqumentInfo", GridControl1)
        SelectToolStripMenuItem.DropDownItems.Clear()
        For Each s As String In myViews.GetViewNames()
            Dim ts As ToolStripMenuItem = New ToolStripMenuItem
            ts.Text = s
            SelectToolStripMenuItem.DropDownItems.Add(ts) ' LayerInfoTbl.Rows(i)(1))
            AddHandler ts.Click, AddressOf btnLayer_Click
        Next
        Me.lblReport.Text = "NDE % Complete"

        Dim myFields() As String = {"InchesOfWeld", "PipeSize", "Diameter"}
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView

        If pv.Columns.Count = 0 Then Return

        pv.Columns("WeldInches").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields, _
                "tblWeldInchesEQLookup", "InchesOfWeld", "InchesOfWeld")
        pv.Columns("PipeSize").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields, _
                "tblWeldInchesEQLookup", "PipeSize", "PipeSize")
        pv.Columns("WeldStatus").ColumnEdit = tblWeldStatusLookupEdit()


        'Dim mySpoolFields() As String = {"TagNo", "Area", "OriginalPieceMark"}
        'pv.Columns("SpoolTo").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(mySpoolFields, _
        '        "tblSpoolList", "TagNo", "TagNo")
        'pv.Columns("SpoolFrom").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(mySpoolFields, _
        '        "tblSpoolList", "TagNo", "TagNo")
        GridView1.OptionsView.ShowFooter = True
        Dim itm As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm.SummaryType = DevExpress.Data.SummaryItemType.Count
        itm.DisplayFormat = "Total Weld Count {0}"
        itm.ShowInGroupColumnFooter = GridView1.Columns("TagNo")
        itm.Tag = 1
        itm.FieldName = "TagNo"

        Dim itm2 As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm2.SummaryType = DevExpress.Data.SummaryItemType.Custom
        itm2.DisplayFormat = "NDE % Complete {0}"
        itm2.ShowInGroupColumnFooter = GridView1.Columns("WeldStatus")
        itm2.Tag = 2
        itm2.FieldName = "WeldStatus"

        'GridView1.Columns("TagNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        'GridView1.Columns("TagNo").SummaryItem.DisplayFormat = "Count {0}"
        'GridView1.Columns("WeldInches").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        'GridView1.Columns("WeldInches").SummaryItem.DisplayFormat = "Count {0:n2}"
        'GridView1.Columns("RejInches").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
        'GridView1.Columns("RejInches").SummaryItem.DisplayFormat = "Count {0:n2}"
        GridView1.BestFitColumns()
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

    Private Function tblWeldStatusLookupEdit()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("StatusCode", GetType(String)))
        dt.Columns.Add(New DataColumn("Status", GetType(String)))
        Dim stMsg() = {"WeldCreated", "WeldAssignedForWork", "WeldAssignedForInspection", _
                "WeldPassed", "WeldReject", "WeldReassigned"}
        For i As Integer = 0 To 5
            Dim dr As DataRow = dt.NewRow
            dr("StatusCode") = i.ToString : dr("Status") = stMsg(i)
            dt.Rows.Add(dr)
        Next
        Dim gridLookup As RepositoryItemGridLookUpEdit = New RepositoryItemGridLookUpEdit()
        gridLookup.DataSource = dt
        gridLookup.ValueMember = "StatusCode"
        gridLookup.DisplayMember = "Status"
        gridLookup.ShowDropDown = ShowDropDown.SingleClick
        gridLookup.View.BestFitColumns()
        Return gridLookup
    End Function
    Private Sub LoadWeldListings()
        'GridControl2.DataSource = CommonForms.EditLookupTable.myDataTable(tblWeldListingsFields, "tblWeldTracking")
        Dim qry As String = "SELECT * FROM tblWeldTracking "
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        If Not GridControl2.DataSource Is Nothing Then
            GridControl2.DataSource.Dispose()
        End If
        GridControl2.DataSource = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        Dim hideClms() As String = {"Disc", "System", "TestPkgNo", "EnteredBy", _
                        "SpoolTo", "SpoolFrom", "PipeSize", "ConstCode", _
                        "ForemanName", "Material", "WallThk", "WeldType", "NDEType", _
                        "DateTested", "AdvancedTesting", "VisInspDate", "VisInspName", _
                        "PMIDate", "PMIResult", "RejInches", "PWHT", "BHN", _
                        "DrawingID"}
        For i As Integer = 0 To GridView2.Columns.Count - 1
            For Each s As String In hideClms
                If GridView2.Columns(i).Caption = s Then
                    GridView2.Columns(i).Visible = False
                End If
            Next
        Next

        Dim myFields1() As String = {"ClassID", "WPS", "NDEPcntReq"}
        Dim pv1 As DevExpress.XtraGrid.Views.Grid.GridView = GridControl2.DefaultView
        pv1.Columns("SVCSPEC").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields1, _
                "tblWeldWPSLookup", "ClassID", "ClassID")
        pv1.Columns("WPS").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields1, _
                "tblWeldWPSLookup", "WPS", "WPS")
        pv1.Columns("NDEPcntReq").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields1, _
                "tblWeldWPSLookup", "NDEPcntReq", "NDEPcntReq")



        Dim myFields() As String = {"InchesOfWeld", "PipeSize", "Diameter"}
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl2.DefaultView
        pv.Columns("WeldInches").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields, _
                "tblWeldInchesEQLookup", "InchesOfWeld", "InchesOfWeld")
        pv.Columns("PipeSize").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(myFields, _
                "tblWeldInchesEQLookup", "PipeSize", "PipeSize")
        pv.Columns("WeldStatus").ColumnEdit = tblWeldStatusLookupEdit()
        'Dim mySpoolFields() As String = {"TagNo", "Area", "OriginalPieceMark"}
        'pv.Columns("SpoolTo").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(mySpoolFields, _
        '        "tblSpoolList", "TagNo", "TagNo")
        'pv.Columns("SpoolFrom").ColumnEdit = CommonForms.EditLookupTable.myGridLookupEdit(mySpoolFields, _
        '        "tblSpoolList", "TagNo", "TagNo")
        GridView2.OptionsView.ShowFooter = True
        GridView2.Columns("TagNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("TagNo").SummaryItem.DisplayFormat = "Count {0}"


    End Sub
   
    Private Sub GridView2_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        Dim View As GridView = sender
        Dim match As Boolean = False
        If e.Column.FieldName = "WeldStatus" Then
            Dim st = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, e.Column.FieldName))
            e.Appearance.BackColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor1(st)
            e.Appearance.ForeColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor2(st)
            'e.Appearance.Font = New Font(e.Appearance.Font.Name, _
            '   e.Appearance.Font.Size, FontStyle.Bold)
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim View As GridView = sender
        Dim match As Boolean = False
        If e.Column.FieldName = "WeldStatus" Then
            Dim st = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, e.Column.FieldName))
            e.Appearance.BackColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor1(st)
            e.Appearance.ForeColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor2(st)
            'e.Appearance.Font = New Font(e.Appearance.Font.Name, _
            '   e.Appearance.Font.Size, FontStyle.Bold)
        End If
    End Sub


    Private Sub SaveAsNewToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsNewToolStripMenuItem.Click
        Dim myForm As Form = New System.Windows.Forms.Form()
        myForm.Text = "Save Report"
        tbxViewName.Location = New Point(30, 30)
        myForm.Controls.Add(tbxViewName)
        Dim lbl As Label = New Label()
        lbl.Text = "Please enter Report Name"
        lbl.Location = New Point(10, 10)
        lbl.Size = New Size(200, 15)
        myForm.Controls.Add(lbl)
        Dim OK_Button As Button = New Button
        OK_Button.Location = New Point(20, 60)
        OK_Button.Text = "OK"
        AddHandler OK_Button.Click, AddressOf OK_Button_Click
        myForm.Controls.Add(OK_Button)
        Dim Cancel_Button As Button = New Button
        Cancel_Button.Location = New Point(100, 60)
        Cancel_Button.Text = "Cancel"
        AddHandler Cancel_Button.Click, AddressOf Cancel_Button_Click
        myForm.Controls.Add(Cancel_Button)

        myForm.ShowDialog()
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            If tbxViewName.Text > "" Then
                myViews.SaveAsNewView(tbxViewName.Text)
            Else
                MessageBox.Show("Invalid View Name")
            End If
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If tbxViewName.Text = "" Then
            MessageBox.Show("Invalid View Name")
            Return
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        CType(sender, Button).Parent.Dispose()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tbxViewName.Text = ""
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        CType(sender, Button).Parent.Dispose()
    End Sub

    Private Sub SaveToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click

    End Sub

    Private Sub SelectToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectToolStripMenuItem.Click

    End Sub

   
    ' Customize the total summary.
    'colUnitPrice.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
    'colUnitPrice.SummaryItem.DisplayFormat = "Custom Sum = {0:C2}"
    'colUnitPrice.SummaryItem.Tag = 1
    'CType(colUnitPrice.View, GridView).OptionsView.ShowFooter = True

    '    ' Create the group summary.
    '    Dim Item As New GridGroupSummaryItem
    'Item.FieldName = "Discontinued"
    'Item.SummaryType = DevExpress.Data.SummaryItemType.Custom
    'Item.DisplayFormat = "(Discontinued products = {0})"
    'Item.Tag = 2
    'GridView1.GroupSummary.Add(Item)

    '    ' The variables that will store summary values.
    Dim WeldPassed As Integer
    Dim TotalWelds As Integer
    Dim WeldInches As Double

    Private Sub GridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As _
     DevExpress.Data.CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        ' Get the summary ID.
        'Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        'Dim View As GridView = CType(sender, GridView)
        '' Initialization
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
        '    WeldPassed = 0
        '    TotalWelds = 0
        '    WeldInches = 0
        'End If

        '' Calculation
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
        '    Dim Inches As Object = View.GetRowCellValue(e.RowHandle, "WeldInches")
        '    Dim Status As Integer = CInt(View.GetRowCellValue(e.RowHandle, "WeldStatus"))
        '    TotalWelds += 1
        '    Select Case summaryID
        '        Case 1 ' 
        '            TotalWelds += 1
        '        Case 2 'The group summary calculated against the 'TagNo' column.
        '            If Status = 4 Then WeldPassed += 1
        '        Case 3 ' The group summary.
        '            WeldInches += IIf(Inches > "", Convert.ToDecimal(e.FieldValue), 0)
        '    End Select
        'End If
        '' Finalization
        'If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
        '    Select Case summaryID
        '        Case 1
        '            e.TotalValue = TotalWelds
        '        Case 2
        '            e.TotalValue = IIf((TotalWelds > 0), WeldPassed / TotalWelds, 0)
        '        Case 3
        '            e.TotalValue = WeldInches
        '    End Select
        'End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NDECompleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NDECompleteToolStripMenuItem.Click
        Me.lblReport.Text = "NDE % Complete"
        ShowWeldListings()

        GridView2.OptionsView.ShowFooter = True
        GridView2.Columns("TagNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("TagNo").SummaryItem.DisplayFormat = "Count {0}"
        GridView1.OptionsView.ShowFooter = True
        Dim itm As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm.SummaryType = DevExpress.Data.SummaryItemType.Count
        itm.DisplayFormat = "Total Weld Count {0}"
        itm.ShowInGroupColumnFooter = GridView1.Columns("TagNo")
        itm.Tag = 1
        itm.FieldName = "TagNo"

        Dim itm2 As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm2.SummaryType = DevExpress.Data.SummaryItemType.Custom
        itm2.DisplayFormat = "NDE % Complete {0}"
        itm2.ShowInGroupColumnFooter = GridView1.Columns("WeldStatus")
        itm2.Tag = 2
        itm2.FieldName = "WeldStatus"
        Dim View As GridView = GridControl1.FocusedView
        GridView1.SortInfo.ClearAndAddRange(New GridColumnSortInfo() { _
           New GridColumnSortInfo(View.Columns("NDEPcntReq"), DevExpress.Data.ColumnSortOrder.Ascending), _
           New GridColumnSortInfo(View.Columns("WeldStatus"), DevExpress.Data.ColumnSortOrder.Descending), _
           New GridColumnSortInfo(View.Columns("WPS"), DevExpress.Data.ColumnSortOrder.Ascending) _
        }, 2)

    End Sub
    Private Sub ShowWeldListings()
        Dim qry As String = "SELECT * FROM tblWeldTracking "
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        If Not GridControl2.DataSource Is Nothing Then
            GridControl2.DataSource.Dispose()
        End If
        GridControl2.DataSource = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        Dim hideClms() As String = {"Disc", "System", "TestPkgNo", "EnteredBy", _
                        "SpoolTo", "SpoolFrom", "PipeSize", "ConstCode", _
                        "ForemanName", "Material", "WallThk", "WeldType", _
                        "DateTested", "AdvancedTesting", "VisInspDate", "VisInspName", _
                        "PMIDate", "PMIResult", "RejInches", "PWHT", "BHN", _
                        "DrawingID"}
        For i As Integer = 0 To GridView2.Columns.Count - 1
            For Each s As String In hideClms
                If GridView2.Columns(i).Caption = s Then
                    GridView2.Columns(i).Visible = False
                End If
            Next
        Next
    End Sub
    Private Sub DailyWeldCountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyWeldCountsToolStripMenuItem.Click
        Me.lblReport.Text = "Daily Weld Count"
        ShowWeldListings()

        GridView2.OptionsView.ShowFooter = True
        GridView2.Columns("TagNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("TagNo").SummaryItem.DisplayFormat = "Count {0}"
        GridView1.OptionsView.ShowFooter = True
        Dim itm As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm.SummaryType = DevExpress.Data.SummaryItemType.Count
        itm.DisplayFormat = "Total Weld Count {0}"
        itm.ShowInGroupColumnFooter = GridView1.Columns("TagNo")
        itm.Tag = 1
        itm.FieldName = "TagNo"

        Dim itm2 As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm2.SummaryType = DevExpress.Data.SummaryItemType.Custom
        itm2.DisplayFormat = "NDE % Complete {0}"
        itm2.ShowInGroupColumnFooter = GridView1.Columns("WeldStatus")
        itm2.Tag = 2
        itm2.FieldName = "WeldStatus"
        Dim View As GridView = GridControl1.FocusedView
        GridView1.SortInfo.ClearAndAddRange(New GridColumnSortInfo() { _
           New GridColumnSortInfo(View.Columns("NDEPcntReq"), DevExpress.Data.ColumnSortOrder.Ascending), _
           New GridColumnSortInfo(View.Columns("WeldStatus"), DevExpress.Data.ColumnSortOrder.Descending), _
           New GridColumnSortInfo(View.Columns("WPS"), DevExpress.Data.ColumnSortOrder.Ascending) _
        }, 2)
    End Sub

    Private Sub DialyNDEReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DialyNDEReportToolStripMenuItem.Click
        Me.lblReport.Text = "Daily NDE Report"
        ShowWeldListings()

        GridView2.OptionsView.ShowFooter = True
        GridView2.Columns("TagNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("TagNo").SummaryItem.DisplayFormat = "Count {0}"
        GridView1.OptionsView.ShowFooter = True
        Dim itm As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm.SummaryType = DevExpress.Data.SummaryItemType.Count
        itm.DisplayFormat = "Total Weld Count {0}"
        itm.ShowInGroupColumnFooter = GridView1.Columns("TagNo")
        itm.Tag = 1
        itm.FieldName = "TagNo"

        Dim itm2 As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm2.SummaryType = DevExpress.Data.SummaryItemType.Custom
        itm2.DisplayFormat = "NDE % Complete {0}"
        itm2.ShowInGroupColumnFooter = GridView1.Columns("WeldStatus")
        itm2.Tag = 2
        itm2.FieldName = "WeldStatus"
        Dim View As GridView = GridControl1.FocusedView
        GridView1.SortInfo.ClearAndAddRange(New GridColumnSortInfo() { _
           New GridColumnSortInfo(View.Columns("NDEPcntReq"), DevExpress.Data.ColumnSortOrder.Ascending), _
           New GridColumnSortInfo(View.Columns("WeldStatus"), DevExpress.Data.ColumnSortOrder.Descending), _
           New GridColumnSortInfo(View.Columns("WPS"), DevExpress.Data.ColumnSortOrder.Ascending) _
        }, 2)

    End Sub

    Private Sub WeldStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeldStatusToolStripMenuItem.Click
        Me.lblReport.Text = "Weld Status"
        ShowWeldListings()

        GridView2.OptionsView.ShowFooter = True
        GridView2.Columns("TagNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("TagNo").SummaryItem.DisplayFormat = "Count {0}"
        GridView1.OptionsView.ShowFooter = True
        Dim itm As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm.SummaryType = DevExpress.Data.SummaryItemType.Count
        itm.DisplayFormat = "Total Weld Count {0}"
        itm.ShowInGroupColumnFooter = GridView1.Columns("TagNo")
        itm.Tag = 1
        itm.FieldName = "TagNo"

        Dim itm2 As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm2.SummaryType = DevExpress.Data.SummaryItemType.Custom
        itm2.DisplayFormat = "NDE % Complete {0}"
        itm2.ShowInGroupColumnFooter = GridView1.Columns("WeldStatus")
        itm2.Tag = 2
        itm2.FieldName = "WeldStatus"
        Dim View As GridView = GridControl1.FocusedView
        GridView1.SortInfo.ClearAndAddRange(New GridColumnSortInfo() { _
           New GridColumnSortInfo(View.Columns("NDEPcntReq"), DevExpress.Data.ColumnSortOrder.Ascending), _
           New GridColumnSortInfo(View.Columns("WeldStatus"), DevExpress.Data.ColumnSortOrder.Descending), _
           New GridColumnSortInfo(View.Columns("WPS"), DevExpress.Data.ColumnSortOrder.Ascending) _
        }, 2)
    End Sub

    Private Sub WeldStencilsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeldStencilsToolStripMenuItem.Click
        Me.lblReport.Text = "Weld Stencils"
        ShowWeldListings()

        GridView2.OptionsView.ShowFooter = True
        GridView2.Columns("TagNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("TagNo").SummaryItem.DisplayFormat = "Count {0}"
        GridView1.OptionsView.ShowFooter = True
        Dim itm As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm.SummaryType = DevExpress.Data.SummaryItemType.Count
        itm.DisplayFormat = "Total Weld Count {0}"
        itm.ShowInGroupColumnFooter = GridView1.Columns("TagNo")
        itm.Tag = 1
        itm.FieldName = "TagNo"

        Dim itm2 As GridGroupSummaryItem = GridView1.GroupSummary.Add()
        itm2.SummaryType = DevExpress.Data.SummaryItemType.Custom
        itm2.DisplayFormat = "NDE % Complete {0}"
        itm2.ShowInGroupColumnFooter = GridView1.Columns("WeldStatus")
        itm2.Tag = 2
        itm2.FieldName = "WeldStatus"
        Dim View As GridView = GridControl1.FocusedView
        GridView1.SortInfo.ClearAndAddRange(New GridColumnSortInfo() { _
           New GridColumnSortInfo(View.Columns("WeldStn"), DevExpress.Data.ColumnSortOrder.Ascending), _
           New GridColumnSortInfo(View.Columns("WeldStatus"), DevExpress.Data.ColumnSortOrder.Descending), _
           New GridColumnSortInfo(View.Columns("WPS"), DevExpress.Data.ColumnSortOrder.Ascending) _
        }, 2)
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click


        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim View As ColumnView = GridControl2.MainView
        sqlPrjUtils.OpenConnection()

        For i As Integer = 0 To GridView2.DataRowCount - 1
            Dim dr As DataRow = View.GetDataRow(i)
            If dr.RowState = DataRowState.Modified Then
                Dim qryFields As String = ""
                For j As Integer = 0 To tblWeldListingsFields.Length - 1
                    Dim fieldName As String = tblWeldListingsFields(j)
                    qryFields = qryFields + tblWeldListingsFields(j) + " = '" + dr(fieldName).ToString + "',"
                Next
                qryFields = qryFields.Remove(qryFields.Length - 1, 1)
                Dim qry = "UPDATE tblWeldTracking SET " + qryFields + " WHERE ID = '" + dr("ID").ToString + "'"

                Dim dt_param As DataTable = sqlPrjUtils.paramDT

                sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
            End If
        Next
        sqlPrjUtils.CloseConnection()
        'Dim View As ColumnView = GridControl2.MainView
        'Dim sr() As Integer = View.GetSelectedRows()
        'If sr.Length > 0 Then
        '    If View.IsDataRow(sr(0)) Then
        '        Dim dr As DataRow = View.GetDataRow(sr(0))
        '        dr.RowState
        '        Dim myForm As New WeldLookupTbl(dr, tblName, "Update", title)
        '        myForm.ShowDialog()
        '    End If
        'End If

    End Sub

    Private Sub GridView2_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) _
                            Handles GridView1.ValidateRow
        Dim view As ColumnView = CType(sender, ColumnView)
        Dim dr As DataRow = view.GetDataRow(e.RowHandle)
        dr.SetModified()
        'Dim column2 As GridColumn = view.Columns("EndTime")
        ''Get the value of the first column
        'Dim time1 As DateTime = CType(view.GetRowCellValue(e.RowHandle, column1), DateTime)
        ''Get the value of the second column
        'Dim time2 As DateTime = CType(view.GetRowCellValue(e.RowHandle, column2), DateTime)
        ''Validity criterion
        'If time1 >= time2 Then
        '    e.Valid = False
        '    'Set errors with specific descriptions for the columns
        '    view.SetColumnError(column1, "The value must be less than EndTime")
        '    view.SetColumnError(column2, "The value must be greater than StartTime")
        'End If
    End Sub

    Private Sub GridView1_InvalidRowException(ByVal sender As Object, _
    ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) _
    Handles GridView1.InvalidRowException
        'Suppress displaying the error message box
        e.ExceptionMode = ExceptionMode.NoAction
    End Sub

End Class

