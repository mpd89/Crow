Imports System.Data.SqlServerCe
Imports System.Drawing.Printing
Imports daqartDLL
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics


Public Class DiscrepancyPrintUtils
    Private pgInfo() As PrintUtils.InfoSetting
    Private pgCtr As Integer = -1
    Private f_body As Font = New Font("Times New Roman", 10)
    Private f_title As Font = New Font("Times New Roman", 20, FontStyle.Bold)
    Private f_main As Font = New Font("Times New Roman", 36, FontStyle.Bold)
    Private f_heading1 As Font = New Font("Times New Roman", 16, FontStyle.Bold)
    Private f_heading2 As Font = New Font("Times New Roman", 12, FontStyle.Bold)
    Private LeftMargin As Integer = 70
    Private _PageSize As Size
    Private _CoversheetPresent As Boolean
    Private _pixFormat As System.Drawing.Imaging.PixelFormat
    Private _BaseImage As System.Drawing.Image
    Private TopMargin As Integer = 300
    Private _StartingTop As Integer = TopMargin
    Private _StartingLeft As Integer = 50
    Public _DonePrinting As Boolean = False
    Private logoImg As Image
    Private PrintDoc As PrintDocument


    Public Sub New()
        'InitializeCoversheet()
        'Dim logoPath = runtime.AbsolutePath + "sites\images\logo128.jpg"
        'logoImg = Image.FromFile(logoPath)
    End Sub


    'Private Sub InitializeCoversheet()
    '    PrintDoc = New PrintDocument()
    '    _CoversheetPresent = False
    '    Try
    '        _PageSize = New Size(PrintDoc.DefaultPageSettings.PaperSize.Width, PrintDoc.DefaultPageSettings.PaperSize.Height)
    '        Dim bm As Bitmap = New Bitmap(_PageSize.Width, _PageSize.Height)
    '        Dim g As Graphics = Graphics.FromImage(bm)
    '        g.FillRectangle(Brushes.White, 0, 0, _PageSize.Width, _PageSize.Height)
    '        Dim m As New MemoryStream
    '        bm.Save(m, ImageFormat.Png)
    '        _BaseImage = System.Drawing.Image.FromStream(m)
    '        _pixFormat = _BaseImage.PixelFormat
    '        _CoversheetPresent = True
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub


    Public Shared Function MakeShortDiscrepancyPrintObjects(ByVal Discrepancy As DiscrepancyManager.ControlDiscrepancy, ByVal topLeft As Point)
        Dim ControlTop = topLeft.Y  'DiscrepancyObject.Top
        Dim ControlLeft = topLeft.X
        Dim f_body As Font = New Font("Times New Roman", 10)
        Dim dobj As DiscrepancyManager.ControlDiscrepancy = New DiscrepancyManager.ControlDiscrepancy
        Dim bm As Image = New Bitmap(dobj.Size.Width, dobj.Size.Height) ', _pixFormat)
        dobj.DrawToBitmap(bm, New Rectangle(New Point(0, 0), bm.Size))
        Dim fn As String = PrintUtils.GetNextImageFileName()
        bm.Save(fn)
        Dim bdCtr As Integer = 0
        Dim pnlObj() As PrintUtils.pgBodyContents
        ReDim Preserve pnlObj(bdCtr)
        pnlObj(bdCtr) = PrintUtils.MakeImageObject(fn, New Point(ControlLeft, ControlTop + 5))
        bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
        pnlObj(bdCtr) = PrintUtils.MakeRectObject(New Rectangle(ControlLeft, ControlTop + 5, bm.Size.Width, bm.Size.Height))

        'Dim mPts As Point = New Point(LeftMargin + 25, ControlTop + 20)
        Dim mPts As Point = New Point(ControlLeft + 30, ControlTop + 5)
        With Discrepancy
            Dim X As Single = mPts.X + .tbx_Title.Location.X : Dim Y As Single = mPts.Y + .tbx_Title.Location.Y
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.tbx_Title.Text, New Point(X, Y))
            X = mPts.X + .tbx_ListedBy.Location.X : Y = mPts.Y + .tbx_ListedBy.Location.Y
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.tbx_ListedBy.Text, New Point(X, Y))
            X = mPts.X + .tbx_ListedOn.Location.X : Y = mPts.Y + .tbx_ListedOn.Location.Y
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.tbx_ListedOn.Text, New Point(X, Y))
            X = mPts.X + .tbx_PackageID.Location.X : Y = mPts.Y + .tbx_PackageID.Location.Y
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.tbx_PackageID.Text, New Point(X, Y))
            X = mPts.X + .tbx_Status.Location.X : Y = mPts.Y + .tbx_Status.Location.Y
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.tbx_Status.Text, New Point(X, Y))
            X = mPts.X + .tbx_Description.Location.X : Y = mPts.Y + .tbx_Description.Location.Y
            'TextRenderer.DrawText(canvas, .tbx_Status.Text, .tbx_Status.Font, New Point(X, Y), Color.Black)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.tbx_Description, New Point(X + 10, Y))

            'For i As Integer = 0 To .tbx_Description.Lines.Length - 1
            '    Dim str() As String = .tbx_Description.Lines()
            '    For Each st As String In str
            '        bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            '        pnlObj(bdCtr) = PrintUtils.MakeTextObject(st, New Point(X + 10, Y))
            '        Dim txtSize As Size = TextRenderer.MeasureText(st, f_body)
            '        Y = Y + txtSize.Height
            '    Next
            'Next

            X = mPts.X + .tbx_Resolution.Location.X : Y = mPts.Y + .tbx_Resolution.Location.Y
            'TextRenderer.DrawText(canvas, .tbx_Status.Text, .tbx_Status.Font, New Point(X, Y), Color.Black)
            'canvas.DrawString(.tbx_Resolution.Text, Me.f_body, Brushes.Black, X + 10, Y)
            'For i As Integer = 0 To .tbx_Resolution.Lines.Length - 1
            '    Dim str() As String = .tbx_Resolution.Lines()
            '    For Each st As String In str
            '        bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            '        pnlObj(bdCtr) = PrintUtils.MakeTextObject(st, New Point(X + 10, Y))
            '        Dim txtSize As Size = TextRenderer.MeasureText(st, f_body)
            '        Y = Y + txtSize.Height
            '    Next
            'Next
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.tbx_Resolution, New Point(X + 10, Y))

            X = mPts.X + .tbx_ClosedOn.Location.X : Y = mPts.Y + .tbx_ClosedOn.Location.Y
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.tbx_ClosedOn.Text, New Point(X, Y))

            X = mPts.X + .tbx_ClosedBy.Location.X : Y = mPts.Y + .tbx_ClosedBy.Location.Y
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.tbx_ClosedBy.Text, New Point(X, Y))


            X = mPts.X + .lblClosedBy.Location.X() : Y = mPts.Y + .lblClosedBy.Location.Y()
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.lblClosedBy.Text, New Point(X, Y))

            X = mPts.X + .lblDate.Location.X() : Y = mPts.Y + .lblDate.Location.Y()
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.lblDate.Text, New Point(X, Y))

            X = mPts.X + .lblDescription.Location.X() : Y = mPts.Y + .lblDescription.Location.Y()
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.lblDescription.Text, New Point(X, Y))

            X = mPts.X + .lblListBy.Location.X() : Y = mPts.Y + .lblListBy.Location.Y()
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.lblListBy.Text, New Point(X, Y))

            X = mPts.X + .lblListedON.Location.X() : Y = mPts.Y + .lblListedON.Location.Y()
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.lblListedON.Text, New Point(X, Y))

            X = mPts.X + .lblManHours.Location.X() : Y = mPts.Y + .lblManHours.Location.Y()
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.lblManHours.Text, New Point(X, Y))

            X = mPts.X + .lblPackageID.Location.X() : Y = mPts.Y + .lblPackageID.Location.Y()
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.lblPackageID.Text, New Point(X, Y))

            X = mPts.X + .lblResolution.Location.X() : Y = mPts.Y + .lblResolution.Location.Y()
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.lblResolution.Text, New Point(X, Y))

            X = mPts.X + .lblStatus.Location.X() : Y = mPts.Y + .lblStatus.Location.Y()
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.lblStatus.Text, New Point(X, Y))

            X = mPts.X + .lblTitle.Location.X() : Y = mPts.Y + .lblTitle.Location.Y()
            bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
            pnlObj(bdCtr) = PrintUtils.MakeTextObject(.lblTitle.Text, New Point(X, Y))
        End With
        Return pnlObj
    End Function


    Public Shared Function MakeShortDiscrepancyPrintPages(ByVal IDList As DataTable) As PrintUtils.InfoSetting()
        Dim pgInfo() As PrintUtils.InfoSetting
        'Dim imgdir As String = runtime.AbsolutePath + "sites\Forms\images\imgList"
        ''Directory.Delete(imgdir)
        'For Each fl As String In Directory.GetFiles(imgdir)
        '    File.Delete(fl)
        'Next
        Dim pgCtr As Integer = -1
        Dim newPage As Boolean = True
        Dim RecordTop = 200
        Dim RecordLeft = 70
        For ii As Integer = 0 To IDList.Rows.Count - 1
            Dim DiscrepancyID As String = IDList.Rows(ii)("MUID")
            Dim qry = "select * from discrepancy WHERE discrepancy.MUID = '" + DiscrepancyID.ToString + "'"
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()
            If newPage Then
                RecordTop = 200
                RecordLeft = 70
                pgCtr = pgCtr + 1
                ReDim Preserve pgInfo(pgCtr)
                pgInfo(pgCtr).Landscape = False
                pgInfo(pgCtr).PrintHdr = True
                pgInfo(pgCtr).PrintFooter = True
                'pgInfo(pgCtr).Heading = "Discrepancy: " + Utilities.GetUserInfoByMUID(dt.Rows(0)("ListedBY")).Rows(0)("UserName") + "-" + Split(dt.Rows(0)("MUID"), "&001")(1)
                pgInfo(pgCtr).Heading = "Discrepancy List for Package: " + Utilities.GetPackageName(dt.Rows(0)("PackageMUID")) '"Discrepancy: " + Utilities.GetUserInfoByMUID(dt.Rows(0)("ListedBY")).Rows(0)("UserName") + "-" + Split(dt.Rows(0)("MUID"), "&001")(1)
                pgInfo(pgCtr).SubHeading = " "
                pgInfo(pgCtr).PgNum = pgCtr
                pgInfo(pgCtr).pSize = PrintUtils.GetDefaultPageSize()
                newPage = False
            End If

            'Dim UserTable = Utilities.GetUserInfo(dt.Rows(0)("ListedBy"))
            Dim Discrepancy As DiscrepancyManager.ControlDiscrepancy = New DiscrepancyManager.ControlDiscrepancy()

            With Discrepancy
                .Name = "DiscrepancyObject" & dt.Rows(0)("MUID").ToString
                .Tag = dt.Rows(0)("MUID")
                .Visible = True
                .Left = 10
                .Top = RecordTop
                .tbx_PackageID.Text = Utilities.GetUserInfoByMUID(dt.Rows(0)("ListedBY")).Rows(0)("UserName") + "-" + Split(dt.Rows(0)("MUID"), "&001")(1)
                .tbx_Title.Text = dt.Rows(0)("Title").ToString
                .tbx_Description.Text = dt.Rows(0)("Description").ToString
                .tbx_ListedBy.Text = Utilities.GetUserName(dt.Rows(0)("ListedBy").ToString)
                .tbx_ListedOn.Text = dt.Rows(0)("ListedOn").ToString
                .tbx_Resolution.Text = dt.Rows(0)("Resolution").ToString
                If dt.Rows(0)("PackageMUID").ToString > "" Then
                    .tbx_PackageID.Text = Utilities.GetPackageName(dt.Rows(0)("PackageMUID").ToString)
                End If
                .tbx_Status.Text = dt.Rows(0)("Status").ToString

                If dt.Rows(0)("ClosedBy").ToString > "" Then
                    .tbx_ClosedBy.Text = Utilities.GetUserName(dt.Rows(0)("ClosedBy").ToString)
                End If
                If (dt.Rows(0)("ClosedOn").ToString) > "" Then
                    .tbx_ClosedOn.Text = dt.Rows(0)("ClosedOn").ToString
                End If

            End With
            Dim pgbArray() As PrintUtils.pgBodyContents = MakeShortDiscrepancyPrintObjects(Discrepancy, New Point(RecordLeft, RecordTop))

            ' MakeDiscrepancyPanelObjects(Discrepancy, New Point(RecordLeft, RecordTop))
            For k As Integer = 0 To pgbArray.Length - 1
                Dim ub As Integer = -1
                If Not pgInfo(pgCtr).pgBody Is Nothing Then
                    ub = UBound(pgInfo(pgCtr).pgBody)
                End If
                ub = ub + 1
                ReDim Preserve pgInfo(pgCtr).pgBody(ub)
                pgInfo(pgCtr).pgBody(ub) = pgbArray(k)
            Next
            RecordTop += Discrepancy.Size.Height + 50 '300
            If RecordTop > (pgInfo(pgCtr).pSize.Height - (Discrepancy.Size.Height + 50)) And pgCtr < (IDList.Rows.Count - 1) Then
                newPage = True
            End If
        Next
        Return pgInfo

    End Function


    Private Sub PrintDiscrepancy(ByVal DiscrepancyObject As DiscrepancyManager.ControlDiscrepancy, _
                    ByVal canvas As Graphics)
        Dim ControlTop = DiscrepancyObject.Top

        Dim mleft() As Integer = {LeftMargin, LeftMargin + 70, LeftMargin + 260, _
                                LeftMargin + 350, LeftMargin + 410, LeftMargin + 500}
        Dim bm As Image = New Bitmap(_PageSize.Width, _PageSize.Height, _pixFormat)
        Dim dobj As DiscrepancyManager.ControlDiscrepancy = New DiscrepancyManager.ControlDiscrepancy
        dobj.DrawToBitmap(bm, New Rectangle(New Point(LeftMargin, ControlTop), bm.Size))
        canvas.DrawImage(bm, 0, 0)

        Dim mPts As Point = New Point(LeftMargin + 25, ControlTop + 15)
        With DiscrepancyObject
            Dim X As Single = mPts.X + .tbx_Title.Location.X : Dim Y As Single = mPts.Y + .tbx_Title.Location.Y
            'TextRenderer.DrawText(canvas, .tbx_Title.Text, .tbx_Title.Font, New Point(X, Y), Color.Black)
            canvas.DrawString(.tbx_Title.Text, Me.f_body, Brushes.Black, X, Y)
            X = mPts.X + .tbx_ListedBy.Location.X : Y = mPts.Y + .tbx_ListedBy.Location.Y
            'TextRenderer.DrawText(canvas, .tbx_ListedBy.Text, .tbx_ListedBy.Font, New Point(X, Y), Color.Black)
            canvas.DrawString(.tbx_ListedBy.Text, Me.f_body, Brushes.Black, X, Y)
            X = mPts.X + .tbx_ListedOn.Location.X : Y = mPts.Y + .tbx_ListedOn.Location.Y
            'TextRenderer.DrawText(canvas, .tbx_ListedOn.Text, .tbx_ListedOn.Font, New Point(X, Y), Color.Black)
            canvas.DrawString(.tbx_ListedOn.Text, Me.f_body, Brushes.Black, X, Y)
            X = mPts.X + .tbx_PackageID.Location.X : Y = mPts.Y + .tbx_PackageID.Location.Y
            'TextRenderer.DrawText(canvas, .tbx_PackageID.Text, .tbx_PackageID.Font, New Point(X, Y), Color.Black)
            canvas.DrawString(.tbx_PackageID.Text, Me.f_body, Brushes.Black, X, Y)
            X = mPts.X + .tbx_Status.Location.X : Y = mPts.Y + .tbx_Status.Location.Y
            'TextRenderer.DrawText(canvas, .tbx_Status.Text, .tbx_Status.Font, New Point(X, Y), Color.Black)
            canvas.DrawString(.tbx_Status.Text, Me.f_body, Brushes.Black, X, Y)

            X = mPts.X + .tbx_Description.Location.X : Y = mPts.Y + .tbx_Description.Location.Y
            'TextRenderer.DrawText(canvas, .tbx_Status.Text, .tbx_Status.Font, New Point(X, Y), Color.Black)
            For i As Integer = 0 To .tbx_Description.Lines.Length - 1
                Dim str() As String = .tbx_Description.Lines()
                For Each st As String In str
                    canvas.DrawString(st, Me.f_body, Brushes.Black, X + 10, Y)
                    Dim txtSize As Size = TextRenderer.MeasureText(st, Me.f_body)
                    Y = Y + txtSize.Height
                Next
            Next

            X = mPts.X + .tbx_Resolution.Location.X : Y = mPts.Y + .tbx_Resolution.Location.Y
            For i As Integer = 0 To .tbx_Resolution.Lines.Length - 1
                Dim str() As String = .tbx_Resolution.Lines()
                For Each st As String In str
                    canvas.DrawString(st, Me.f_body, Brushes.Black, X + 10, Y)
                    Dim txtSize As Size = TextRenderer.MeasureText(st, Me.f_body)
                    Y = Y + txtSize.Height
                Next
            Next

            X = mPts.X + .tbx_ClosedOn.Location.X : Y = mPts.Y + .tbx_ClosedOn.Location.Y
            canvas.DrawString(.tbx_ClosedOn.Text, Me.f_body, Brushes.Black, X + 10, Y)

            X = mPts.X + .tbx_ClosedBy.Location.X : Y = mPts.Y + .tbx_ClosedBy.Location.Y
            canvas.DrawString(.tbx_ClosedBy.Text, Me.f_body, Brushes.Black, X + 10, Y)


            X = mPts.X + .lblClosedBy.Location.X() : Y = mPts.Y + .lblClosedBy.Location.Y()
            canvas.DrawString(.lblClosedBy.Text, Me.f_body, Brushes.Black, X, Y)

            X = mPts.X + .lblDate.Location.X() : Y = mPts.Y + .lblDate.Location.Y()
            canvas.DrawString(.lblDate.Text, Me.f_body, Brushes.Black, X, Y)



            X = mPts.X + .lblDescription.Location.X() : Y = mPts.Y + .lblDescription.Location.Y()
            canvas.DrawString(.lblDescription.Text, Me.f_body, Brushes.Black, X, Y)

            X = mPts.X + .lblListBy.Location.X() : Y = mPts.Y + .lblListBy.Location.Y()
            canvas.DrawString(.lblListBy.Text, Me.f_body, Brushes.Black, X, Y)

            X = mPts.X + .lblListedON.Location.X() : Y = mPts.Y + .lblListedON.Location.Y()
            canvas.DrawString(.lblListedON.Text, Me.f_body, Brushes.Black, X, Y)

            X = mPts.X + .lblManHours.Location.X() : Y = mPts.Y + .lblManHours.Location.Y()
            canvas.DrawString(.lblManHours.Text, Me.f_body, Brushes.Black, X, Y)

            X = mPts.X + .lblPackageID.Location.X() : Y = mPts.Y + .lblPackageID.Location.Y()
            canvas.DrawString(.lblPackageID.Text, Me.f_body, Brushes.Black, X, Y)

            X = mPts.X + .lblResolution.Location.X() : Y = mPts.Y + .lblResolution.Location.Y()
            canvas.DrawString(.lblResolution.Text, Me.f_body, Brushes.Black, X, Y)

            X = mPts.X + .lblStatus.Location.X() : Y = mPts.Y + .lblStatus.Location.Y()
            canvas.DrawString(.lblStatus.Text, Me.f_body, Brushes.Black, X, Y)

            X = mPts.X + .lblTitle.Location.X() : Y = mPts.Y + .lblTitle.Location.Y()
            canvas.DrawString(.lblTitle.Text, Me.f_body, Brushes.Black, X, Y)
        End With
    End Sub


    'Private Function GetDiscrepancyPanelList(ByRef dt As DataTable) As List(Of TableLayoutPanel)
    '    Dim hdrclmTxt() As String = {"#"}
    '    Dim i As Integer = 0
    '    For i = 0 To dt.Columns.Count - 1
    '        ReDim Preserve hdrclmTxt(i + 1)
    '        hdrclmTxt(i + 1) = dt.Columns(i).ColumnName
    '    Next
    '    Dim ColumnCount As Integer = hdrclmTxt.Length
    '    Dim PnlList As New List(Of TableLayoutPanel)
    '    Dim pnlTbl As TableLayoutPanel = New TableLayoutPanel
    '    pnlTbl.ColumnCount = dt.Columns.Count + 1
    '    pnlTbl.BackColor = Color.White
    '    pnlTbl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
    '    Dim clmWd(ColumnCount) As Integer
    '    For i = 0 To ColumnCount - 1
    '        If i = 0 Then
    '            clmWd(i) = 40
    '        Else
    '            clmWd(i) = 100
    '        End If
    '    Next

    '    Dim rowNo As Integer = 0
    '    Dim recNo As Integer = 1
    '    Dim h As Integer = 0
    '    Dim hdrctrl(ColumnCount) As Control
    '    'Dim hdrclmTxt() As String = {"#", "Document Name", "Rev", "Date", "Sheet", "Image"}
    '    For k As Integer = 0 To ColumnCount - 1
    '        Dim lbl As Label = New Label
    '        lbl.Tag = rowNo
    '        hdrctrl(k) = lbl
    '        hdrctrl(k).Width = clmWd(k)
    '        hdrctrl(k).Text = hdrclmTxt(k)
    '        hdrctrl(k).ForeColor = Color.Black
    '        pnlTbl.Controls.Add(hdrctrl(k), k, rowNo)
    '        Dim cStyle As ColumnStyle = New ColumnStyle
    '        cStyle.Width = lbl.Width
    '        pnlTbl.ColumnStyles.Add(cStyle)
    '        If h < lbl.Height Then h = lbl.Height
    '    Next
    '    Dim rS As RowStyle = New RowStyle
    '    rS.Height = h
    '    pnlTbl.RowStyles.Add(rS)
    '    rowNo = rowNo + 1

    '    For i = 0 To dt.Rows.Count - 1
    '        Dim ctrl(ColumnCount) As Control
    '        'pad with row #
    '        Dim clmTxt() As String = {(i + 1).ToString}
    '        For j As Integer = 0 To dt.Columns.Count - 1
    '            ReDim Preserve clmTxt(j + 1)
    '            clmTxt(j + 1) = dt.Rows(i)(j)
    '        Next
    '        For k As Integer = 0 To ColumnCount - 1
    '            ctrl(k) = New Label
    '            ctrl(k).Width = clmWd(k)
    '            ctrl(k).Text = clmTxt(k)
    '            ctrl(k).Tag = rowNo
    '            pnlTbl.Controls.Add(ctrl(k), k, rowNo)
    '        Next
    '        Dim rStyle As RowStyle = New RowStyle
    '        rStyle.Height = 20
    '        pnlTbl.RowStyles.Add(rStyle)
    '        rowNo = rowNo + 1
    '        recNo = recNo + 1
    '        If rowNo > 20 Then
    '            pnlTbl.Size = New System.Drawing.Size(600, (rowNo + 2) * 30)
    '            PnlList.Add(pnlTbl)
    '            pnlTbl = New TableLayoutPanel
    '            pnlTbl.Size = New System.Drawing.Size(600, (rowNo + 2) * 30)
    '            pnlTbl.ColumnCount = dt.Columns.Count
    '            pnlTbl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
    '            rowNo = 0
    '        End If
    '    Next
    '    If rowNo > 0 Then
    '        pnlTbl.Size = New System.Drawing.Size(600, (rowNo + 2) * 20)
    '        PnlList.Add(pnlTbl)
    '    End If
    '    Return PnlList
    'End Function


    'Private Sub printDoc_EndPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
    '    _DonePrinting = True
    'End Sub


    'Private Sub printDoc_BeginPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
    '    pgCtr = 0
    '    If pgInfo(pgCtr).Landscape Then
    '        PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = True
    '    Else
    '        PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = False
    '    End If
    'End Sub


    'Private Sub PrintTableLayoutPanel(ByVal e As PrintPageEventArgs, ByVal pnl As TableLayoutPanel, ByVal loc As Point)

    '    Dim LeftMargin = loc.X
    '    Dim _StartingTop = loc.Y
    '    Dim ht As Integer = 30
    '    Dim X = LeftMargin
    '    Dim Y = _StartingTop
    '    For Each ctrl As Control In pnl.Controls
    '        Dim rowNo = ctrl.Tag
    '        X = LeftMargin + ctrl.Location.X
    '        Y = _StartingTop + rowNo * ht
    '        e.Graphics.DrawString(ctrl.Text, ctrl.Font, New SolidBrush(ctrl.ForeColor), X, Y)
    '    Next
    '    X = LeftMargin

    '    For i As Integer = 0 To pnl.ColumnCount - 1
    '        Dim clmStyle As ColumnStyle = pnl.ColumnStyles(i)
    '        e.Graphics.DrawLine(Pens.Black, X, _StartingTop, X, _StartingTop + pnl.RowStyles.Count * ht)
    '        X = X + pnl.ColumnStyles(i).Width + 6
    '    Next
    '    e.Graphics.DrawLine(Pens.Black, LeftMargin + pnl.Width, _StartingTop, _
    '           LeftMargin + pnl.Width, _StartingTop + pnl.RowStyles.Count * ht)
    '    X = LeftMargin
    '    Y = _StartingTop
    '    For i As Integer = 0 To pnl.RowStyles.Count - 1
    '        Dim rStyle As RowStyle = pnl.RowStyles(i)
    '        e.Graphics.DrawLine(Pens.Black, X, Y, X + pnl.Width, Y)
    '        Y = Y + ht
    '    Next
    '    e.Graphics.DrawLine(Pens.Black, X, Y, X + pnl.Width, Y)
    'End Sub


    'Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
    '    If pgInfo(pgCtr).PrintHdr Then
    '        PrintUtils.PrintPageHeader(e, pgInfo(pgCtr).Heading, pgInfo(pgCtr).SubHeading)
    '    End If
    '    If Not pgInfo(pgCtr).pgBody Is Nothing Then
    '        PrintUtils.PrintPageBody(e, pgInfo(pgCtr))
    '    End If
    '    If pgInfo(pgCtr).PrintFooter Then
    '        PrintUtils.PrintPageFooter(e, pgInfo(pgCtr).PgNum, pgInfo.Length)
    '    End If
    '    pgCtr = pgCtr + 1
    '    If pgCtr < pgInfo.Length Then
    '        e.HasMorePages = True
    '        e.PageSettings.PaperSize = pgInfo(pgCtr).pkSize
    '        If pgInfo(pgCtr).Landscape Then
    '            e.PageSettings.Landscape = True
    '        Else
    '            e.PageSettings.Landscape = False
    '        End If
    '    Else
    '        e.HasMorePages = False
    '    End If
    'End Sub


    'Public Sub PrintDiscrepancyPagePreview(ByVal DiscrepancyID As String)
    '    _DonePrinting = False
    '    If Not PrintDoc Is Nothing Then
    '        PrintDoc.Dispose()
    '    End If
    '    PrintDoc = New PrintDocument()
    '    pgCtr = -1

    '    'Always print coverpage
    '    _StartingTop = TopMargin
    '    PrintDoc.DocumentName = "Print Packages"
    '    Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()

    '    AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
    '    AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
    '    AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage

    '    printDialog.Document = Me.PrintDoc
    '    printDialog.ShowDialog()
    'End Sub


    'Public Sub PrintDiscrepancyListPreview(ByRef dt As DataTable)
    '    _DonePrinting = False
    '    If Not PrintDoc Is Nothing Then
    '        PrintDoc.Dispose()
    '    End If
    '    PrintDoc = New PrintDocument()
    '    pgCtr = -1

    '    'Always print coverpage
    '    _StartingTop = TopMargin
    '    PrintDoc.DocumentName = "Print Packages"
    '    Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()

    '    AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
    '    AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
    '    AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage

    '    printDialog.Document = Me.PrintDoc
    '    printDialog.ShowDialog()
    'End Sub

End Class
