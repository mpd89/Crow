Imports System.Data
Imports CommonForms.Classes
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Threading
Imports System.IO
Imports System.Drawing.Printing
Imports daqartDLL

Public Class XtraGridPrinting

    Private Enum printObject
        PrintGrid
        PrintPgInfo
        PrintGridPanel
    End Enum

    Private dgv As DevExpress.XtraGrid.GridControl
    Private Header As String
    Private ps As New PrintingSystem()
    Private pgInfo() As PrintUtils.InfoSetting
    Private ptObj As printObject
    Private PrintDoc As PrintDocument
    Private pgCtr As Integer
    Private DonePrinting As Boolean
    Private myPanel As Panel
    Private View1 As ColumnView
    Private Gridview1 As GridView

    Public Sub New(ByVal _Header As String, ByRef _dgv As DevExpress.XtraGrid.GridControl)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        dgv = _dgv
        Header = _Header
        ptObj = printObject.PrintGrid
    End Sub


    Public Sub New(ByVal _Header As String, ByVal _Panel As Panel, ByRef _dgv As DevExpress.XtraGrid.GridControl)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        dgv = _dgv
        myPanel = _Panel
        Header = _Header
        ptObj = printObject.PrintGridPanel
    End Sub


    Public Sub New(ByVal _pgInfo() As PrintUtils.InfoSetting)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        pgInfo = _pgInfo
        Header = pgInfo(0).Heading
        ptObj = printObject.PrintPgInfo
        Me.rdb_Email.Visible = False
        Me.rdb_HTML.Visible = False
        Me.rdb_PDF.Visible = False
        Me.rdb_Print.Visible = False
        Me.rdb_Xls.Visible = False
    End Sub


    Private Sub XtraPrinting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BringToFront()
        Me.Text = Header
        Dim wd As Integer = TextRenderer.MeasureText(Header, Me.lblHeader.Font).Width + Me.lblHeader.Location.X
        If wd > Me.Width Then
            Me.Width = wd + Me.lblHeader.Location.X * 2
            Me.lblHeader.AutoSize = True
        End If
        Me.lblHeader.Text = Header

        View1 = dgv.MainView
        Gridview1 = View1.ParentView
    End Sub


    Private Sub ExportToXls()
        SaveFileDialog1.Filter = "Xls files (*.xls)|*.xls|All files (*.*)|*.*"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.RestoreDirectory = True
        If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ps.ExportToXls(SaveFileDialog1.FileName)
        End If
    End Sub


    Private Sub ExportToPdf()
        SaveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.RestoreDirectory = True
        If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim fn As String = SaveFileDialog1.FileName
            ps.ExportToPdf(fn)
        End If
    End Sub


    Private Sub ExportToHtml()
        SaveFileDialog1.Filter = "Html files (*.Htm)|*.htm|All files (*.*)|*.*"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.RestoreDirectory = True

        If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim fn As String = SaveFileDialog1.FileName
            ps.ExportToHtml(fn)
        End If

    End Sub


    Private Sub DXPrint()

    End Sub


    Private Sub DXPrintPreview()

    End Sub


    Private Sub ExecuteGridPrint()
        Dim link As New PrintableComponentLink(ps)
        link.Component = dgv
        AddHandler link.CreateReportHeaderArea, AddressOf PrintableComponentLink1_CreateReportHeaderArea
        AddHandler link.CreateMarginalHeaderArea, AddressOf PrintableComponentLink1_CreateMarginalHeaderArea
        AddHandler link.CreateDetailHeaderArea, AddressOf PrintableComponentLink1_CreateInnerPageHeaderArea

        ' Generate the report.
        link.CreateDocument()
        ' Show the report.
        If Me.rdb_HTML.Checked Then ExportToHtml()

        If Me.rdb_PDF.Checked Then ExportToPdf()
        If Me.rdb_Print.Checked Then ps.Print()
        If Me.rdb_Xls.Checked Then ExportToXls()
        link.PrintingSystem.PageSettings.Landscape = True

        If Me.rdb_PrintPreview.Checked Then link.ShowPreview()
        'link.ShowPreview()
    End Sub


    Private Sub ExecutePgInfoPrint()
        If Not PrintDoc Is Nothing Then
            PrintDoc.Dispose()
        End If
        PrintDoc = New PrintDocument()
        DonePrinting = False
        pgCtr = -1
        Me.Cursor = Cursors.WaitCursor
        PrintDoc.DocumentName = "Print"
        Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()

        AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
        AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage

        Me.Cursor = Cursors.Default
        printDialog.Document = Me.PrintDoc
        printDialog.ShowDialog()
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Select Case ptObj
            Case printObject.PrintGrid
                ExecuteGridPrint()
            Case printObject.PrintPgInfo
                ExecutePgInfoPrint()
            Case printObject.PrintGridPanel
                ExecuteGridPrint()
        End Select
    End Sub


    Private Sub PrintableComponentLink1_CreateReportHeaderArea(ByVal sender As System.Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateReportHeaderArea
        'If ptObj = printObject.PrintGrid Then
        '    Dim reportHeader As String = Header '+ ControlChars.CrLf + Now().ToString
        '    e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        '    e.Graph.Font = New Font("Tahoma", 14, FontStyle.Bold)
        '    Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50)
        '    e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None)
        '    Dim link As PrintableComponentLink = sender
        'End If
        If ptObj = printObject.PrintGridPanel Then
            e.Graph.Font = New Font("Tahoma", 7, FontStyle.Bold)
            For Each ctrl As Windows.Forms.Control In myPanel.Controls
                If ctrl.GetType.Name = ("TextBox") Then
                    Dim tBox As TextBox = CType(ctrl, TextBox)
                    'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
                    'e.Graph.Font = New Font("Tahoma", 14, FontStyle.Bold)
                    Dim rec As RectangleF = New RectangleF(tBox.Location, tBox.Size)
                    e.Graph.DrawString(tBox.Text, Color.Black, rec, BorderSide.All)
                End If
                If ctrl.GetType.Name = ("Label") Then
                    Dim tBox As Label = CType(ctrl, Label)
                    'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
                    'e.Graph.Font = New Font("Tahoma", 14, FontStyle.Bold)
                    Dim rec As RectangleF = New RectangleF(tBox.Location, tBox.Size)
                    e.Graph.DrawString(tBox.Text, Color.Black, rec, BorderSide.None)
                End If
                If ctrl.GetType.Name = ("ComboBox") Then
                    Dim tBox As ComboBox = CType(ctrl, ComboBox)
                    'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
                    'e.Graph.Font = New Font("Tahoma", 14, FontStyle.Bold)
                    Dim rec As RectangleF = New RectangleF(tBox.Location, tBox.Size)
                    e.Graph.DrawString(tBox.Text, Color.Black, rec, BorderSide.All)
                End If
                If ctrl.GetType.Name = ("CheckBox") Then
                    Dim tBox As CheckBox = CType(ctrl, CheckBox)
                    'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Near)
                    'e.Graph.Font = New Font("Tahoma", 14, FontStyle.Bold)
                    Dim rec As RectangleF = New RectangleF(tBox.Location, tBox.Size)
                    If tBox.Checked Then
                        e.Graph.DrawString(tBox.Text, Color.Black, rec, BorderSide.All)
                    End If
                End If
            Next
        End If
        'link.Images(0)
        'e.Graph.DrawImage(img, New RectangleF(Convert.ToSingle(200 + (50 - img.Width) / 2), _
        '        Convert.ToSingle(Top + (50 - img.Height) / 2), img.Width, img.Height), _
        '        BorderSide.None, Color.Transparent)

    End Sub


    Private Sub PrintableComponentLink1_CreateMarginalHeaderArea(ByVal sender As System.Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalHeaderArea
        'Dim logoPath As String = runtime.AbsolutePath + "sites\images\logo128.jpg"
        'Dim img As Image = Image.FromFile(logoPath)
        Dim Format As String = "Page {0} of {1}"
        e.Graph.Font = e.Graph.DefaultFont
        e.Graph.BackColor = Color.Transparent

        Dim r As New RectangleF(0, 0, 0, e.Graph.Font.Height)

        Dim Brick As PageInfoBrick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, Format, _
            Color.Black, r, BorderSide.None)
        Brick.Alignment = BrickAlignment.Far
        Brick.AutoWidth = True

        Brick = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.Black, r, BorderSide.None)
        Brick.Alignment = BrickAlignment.Near
        Brick.AutoWidth = True
        'e.Graph.DrawImage(img, New RectangleF(0, Convert.ToSingle(0 + (50 - img.Height) / 2), img.Width, img.Height), _
        '                BorderSide.None, Color.Transparent)
        Dim reportHeader As String = Header '+ ControlChars.CrLf + Now().ToString
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 14, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50)
        e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None)
    End Sub


    Private Sub PrintableComponentLink1_CreateInnerPageHeaderArea(ByVal sender As System.Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)
        Dim reportHeader As String = Header '+ ControlChars.CrLf + Now().ToString
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("Tahoma", 14, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50)
        e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None)
    End Sub


    Private Sub PrintableComponentLink1_CreateMarginalFooterArea(ByVal sender As System.Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateMarginalFooterArea

    End Sub


    Private Sub PrintableComponentLink1_CreateReportFooterArea(ByVal sender As System.Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateReportFooterArea

    End Sub


    Private Sub PrintableComponentLink1_CreateDetailHeaderArea(ByVal sender As System.Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles PrintableComponentLink1.CreateDetailHeaderArea

    End Sub


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
        DonePrinting = True
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


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub


   
End Class