Imports System.ComponentModel
Imports System.Globalization
Imports System.Collections
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL

Public Class PrintUtils

    Public Enum Allign
        Left
        Center
        Right
    End Enum


    Public Enum pgContentType
        text
        line
        rect
        image
        docImage    'scaled according to paper size
        'panelTable
        'discrepancyObj
        'punchlistObj
        'documentImage
        'formImageFile
    End Enum


    Structure pgTextLine
        Dim str As String
        Dim mfont As Font
        Dim fsz As Integer
        Dim allign As Allign
    End Structure


    Structure pgBodyContents
        Dim obj As Object
        Dim loc As Point
        Dim eloc As Point
        Dim sz As Size
        Dim mfont As Font
        Dim foreColor As Color  'Integer
        Dim allign As Allign
        Dim contentType As pgContentType
    End Structure


    Structure InfoSetting
        Dim Landscape As Integer
        Dim PrintHdr As Boolean
        Dim PrintFooter As Boolean
        Dim Heading As String
        Dim SubHeading As String
        Dim pgBody() As pgBodyContents
        Dim PgNum As Integer
        Dim pSize As Size
        Dim pkSize As System.Drawing.Printing.PaperSize 'Size
        Dim pprKind As PaperKind
    End Structure

    'Public Shared pgInfo() As InfoSetting
    'Private pgCtr As Integer
    'Private f_body As Font = New Font("Times New Roman", 10)
    'Private f_title As Font = New Font("Times New Roman", 20, FontStyle.Bold)
    'Private f_main As Font = New Font("Times New Roman", 36, FontStyle.Bold)
    'Private f_heading1 As Font = New Font("Times New Roman", 16, FontStyle.Bold)
    'Private f_heading2 As Font = New Font("Times New Roman", 12, FontStyle.Bold)
    'Private LeftMargin As Integer = 70
    'Private PrintDoc As PrintDocument
    'Private logoImg As Image
    'Public Shared _DonePrinting As Boolean
    Public Shared myDefaultPaperKind As PaperKind = PaperKind.Letter
    Public Shared Sub ClearImageList()
        Dim dr As String = runtime.AbsolutePath + "sites\Forms\images\imgList"
        Dim fentries As String() = Directory.GetFiles(dr)
        Dim fs As String
        For Each fs In fentries
            File.Delete(fs)
        Next
    End Sub


    Public Shared Function GetNextImageFileName()
        Dim imgdir As String = runtime.AbsolutePath + "sites\Forms\images\imgList"
        'Dim fl() As String = Directory.GetFiles(imgdir)
        If Not Directory.Exists(imgdir) Then
            Directory.CreateDirectory(imgdir)
        End If
        Dim fl() As String = Directory.GetFiles(imgdir)

        Dim fileNum As Integer = 0
        For Each str As String In fl
            Dim fp() As String = Split(str, "\")
            Dim fileName As String = fp(fp.Length - 1)
            Dim filePart() As String = Split(fileName, "_")
            If filePart.Length > 0 Then
                If fileNum <= Convert.ToInt32(filePart(1)) Then
                    fileNum = Convert.ToInt32(filePart(1)) + 1
                End If
            End If
        Next
        Dim fn As String = imgdir + "\img_" + fileNum.ToString
        Return fn
    End Function


    Public Shared Function MakeTextLineObject(ByVal str As String, ByVal myAllign As Allign, ByVal myFont As Font)
        Dim myLine As PrintUtils.pgTextLine = New PrintUtils.pgTextLine
        myLine.str = str
        myLine.mfont = myFont
        myLine.allign = myAllign
        Return myLine
    End Function


    Public Shared Function MakeTextObject(ByVal str As String, ByVal loc As Point) As PrintUtils.pgBodyContents
        Dim f_body As Font = New Font("Times New Roman", 10)
        Dim tobj As PrintUtils.pgBodyContents = New PrintUtils.pgBodyContents
        tobj.allign = PrintUtils.Allign.Left : tobj.loc = loc : tobj.mfont = f_body : tobj.obj = str
        tobj.sz = TextRenderer.MeasureText(str, f_body)
        tobj.foreColor = Color.Black    'RGB(0, 0, 0)
        tobj.contentType = PrintUtils.pgContentType.text
        Return tobj
    End Function


    Public Shared Function MakeTextObject(ByVal str As String, ByVal loc As Point, ByVal myFont As Font, ByVal myColor As Color) As PrintUtils.pgBodyContents
        Dim tobj As PrintUtils.pgBodyContents = New PrintUtils.pgBodyContents
        tobj.allign = PrintUtils.Allign.Left : tobj.loc = loc : tobj.mfont = myFont : tobj.obj = str
        tobj.sz = TextRenderer.MeasureText(str, myFont)
        tobj.foreColor = myColor    'RGB(0, 0, 0)
        tobj.contentType = PrintUtils.pgContentType.text
        Return tobj
    End Function


    Public Shared Function MakeTextObject(ByVal tbx As TextBox, ByVal loc As Point) As PrintUtils.pgBodyContents
        'Dim f_body As Font = New Font("Times New Roman", 10)
        Dim str As String = ""
        For Each st As String In tbx.Lines()
            str = str + st + ControlChars.CrLf
        Next

        'For i As Integer = 0 To .tbx_Description.Lines.Length - 1
        '    Dim str() As String = .tbx_Description.Lines()
        '    For Each st As String In str
        '        bdCtr = bdCtr + 1 : ReDim Preserve pnlObj(bdCtr)
        '        pnlObj(bdCtr) = PrintUtils.MakeTextObject(st, New Point(X + 10, Y))
        '        Dim txtSize As Size = TextRenderer.MeasureText(st, f_body)
        '        Y = Y + txtSize.Height
        '    Next
        'Next

        Dim tobj As PrintUtils.pgBodyContents = New PrintUtils.pgBodyContents

        tobj.allign = PrintUtils.Allign.Left : tobj.loc = loc : tobj.mfont = tbx.Font : tobj.obj = str
        tobj.sz = New Size(tbx.DisplayRectangle.Width, tbx.DisplayRectangle.Height)
        tobj.foreColor = Color.Black    'RGB(0, 0, 0)
        tobj.contentType = PrintUtils.pgContentType.text
        Return tobj
    End Function


    Public Shared Function MakeImageObject(ByVal str As String, ByVal loc As Point) As PrintUtils.pgBodyContents
        Dim iobj As PrintUtils.pgBodyContents = New PrintUtils.pgBodyContents
        iobj.obj = str : iobj.loc = loc
        iobj.contentType = PrintUtils.pgContentType.image
        Return iobj
    End Function


    Public Shared Function MakeLineObject(ByVal s As Point, ByVal e As Point) As PrintUtils.pgBodyContents
        Dim lobj As PrintUtils.pgBodyContents = New PrintUtils.pgBodyContents
        lobj.eloc = e
        lobj.loc = s : lobj.contentType = PrintUtils.pgContentType.line
        Return lobj
    End Function


    Public Shared Function MakeRectObject(ByVal rct As Rectangle) As PrintUtils.pgBodyContents
        Dim robj As PrintUtils.pgBodyContents = New PrintUtils.pgBodyContents
        robj.obj = rct : robj.contentType = PrintUtils.pgContentType.rect
        Return robj
    End Function


    Public Shared Function MakeTextPage(ByVal s As Point, ByVal ml() As pgTextLine) As InfoSetting
        Dim myPage As InfoSetting = New InfoSetting
        Dim pgContents As PrintUtils.pgBodyContents = New PrintUtils.pgBodyContents
        Dim StartingTop = s.Y
        Dim LeftMargin = s.X
        For i As Integer = 0 To ml.Length - 1
            ReDim Preserve myPage.pgBody(i)
            Dim myPageSize As Size = GetDefaultPageSize()
            Dim txtSize As Size = TextRenderer.MeasureText(ml(i).str + "        ", ml(i).mfont)
            Dim ht As Integer = txtSize.Height
            Dim wd As Integer = txtSize.Width
            If txtSize.Width > myPageSize.Width - (LeftMargin * 2) Then
                ht = ((txtSize.Width / myPageSize.Width) + 2) * ht
                wd = myPageSize.Width - (LeftMargin * 2)
            End If
            Dim locX = LeftMargin
            If ml(i).allign = Allign.Center Then
                locX = (myPageSize.Width / 2 - wd / 2)
            End If
            If ml(i).allign = Allign.Right Then
                locX = LeftMargin + myPageSize.Width - wd
            End If
            Dim locY = StartingTop
            StartingTop = locY + ht + 5
            myPage.pgBody(i).contentType = PrintUtils.pgContentType.text
            myPage.pgBody(i).mfont = ml(i).mfont
            myPage.pgBody(i).obj = ml(i).str
            myPage.pgBody(i).loc = New Point(locX, locY)
            myPage.pgBody(i).foreColor = Color.Black
            myPage.pgBody(i).sz = New Size(wd, ht)
        Next

        Return myPage
    End Function


    Public Shared Function MakeTableListPages(ByRef dt As DataTable, ByVal clmWd() As Integer) As InfoSetting()
        Dim f_body As Font = New Font("Times New Roman", 10)
        Dim hdrclmTxt() As String = {"#"}
        Dim i As Integer = 0
        For i = 0 To dt.Columns.Count - 1
            ReDim Preserve hdrclmTxt(i + 1)
            hdrclmTxt(i + 1) = dt.Columns(i).ColumnName
        Next
        Dim ColumnCount As Integer = hdrclmTxt.Length
        Dim PnlList As New List(Of TableLayoutPanel)
        'Dim pnlTbl As TableLayoutPanel = MakeNewTablePanel(hdrclmTxt)
        Dim rowNo As Integer = 0
        Dim recNo As Integer = 1
        rowNo = rowNo + 1
        Dim newPnl As Boolean = True
        Dim pnlNum As Integer = -1
        For i = 0 To dt.Rows.Count - 1
            If newPnl Then
                PnlList.Add(MakeNewTablePanel(hdrclmTxt, clmWd))
                pnlNum = pnlNum + 1
                newPnl = False
            End If
            Dim ctrl(ColumnCount) As Control
            'pad with row #
            Dim clmTxt() As String = {(i + 1).ToString}
            For j As Integer = 0 To dt.Columns.Count - 1
                ReDim Preserve clmTxt(j + 1)
                clmTxt(j + 1) = dt.Rows(i)(j)
            Next
            Dim h As Integer = 0
            For k As Integer = 0 To ColumnCount - 1
                Dim cStyle As ColumnStyle = PnlList(pnlNum).ColumnStyles(k)
                Dim myLbl As Label = New Label
                myLbl.Width = cStyle.Width
                myLbl.Height = TextRenderer.MeasureText(clmTxt(k), f_body).Height + 5
                If h < myLbl.Height Then h = myLbl.Height
                myLbl.TextAlign = ContentAlignment.MiddleCenter
                myLbl.Text = clmTxt(k)
                myLbl.Tag = rowNo
                PnlList(pnlNum).Controls.Add(myLbl, k, rowNo)
            Next
            PnlList(pnlNum).Height = PnlList(pnlNum).Height + h
            rowNo = rowNo + 1
            recNo = recNo + 1
            If rowNo > 20 Then
                newPnl = True
            End If
        Next
        Dim pgInfo() As InfoSetting = Nothing
        Dim mypgCtr As Integer = -1
        For i = 0 To PnlList.Count - 1
            mypgCtr = mypgCtr + 1
            ReDim Preserve pgInfo(mypgCtr)
            pgInfo(mypgCtr).Landscape = False
            pgInfo(mypgCtr).PrintHdr = True
            pgInfo(mypgCtr).PrintFooter = True
            pgInfo(mypgCtr).Heading = " "
            pgInfo(mypgCtr).SubHeading = " "
            pgInfo(mypgCtr).pSize = GetDefaultPageSize()
            pgInfo(mypgCtr).pgBody = PrintUtils.MakeTableLayoutPanelPgContents(PnlList(i), New Point(70, 240))
            pgInfo(mypgCtr).pprKind = myDefaultPaperKind
        Next
        Return pgInfo
    End Function


    Public Shared Function MakeTableListPages(ByRef dt As DataTable) As InfoSetting()
        Dim f_body As Font = New Font("Times New Roman", 10)
        Dim hdrclmTxt() As String = {"#"}
        Dim clmWd() As Integer = {50}
        Dim i As Integer = 0
        Dim ttlWd = 0
        For i = 0 To dt.Columns.Count - 1
            ttlWd = ttlWd + dt.Columns(i).Caption.Length
        Next
        For i = 0 To dt.Columns.Count - 1
            ReDim Preserve hdrclmTxt(i + 1)
            hdrclmTxt(i + 1) = dt.Columns(i).Caption
            ReDim Preserve clmWd(i + 1)
            clmWd(i + 1) = 600 * dt.Columns(i).Caption.Length / ttlWd
        Next
        Dim ColumnCount As Integer = hdrclmTxt.Length
        Dim PnlList As New List(Of TableLayoutPanel)
        'Dim pnlTbl As TableLayoutPanel = MakeNewTablePanel(hdrclmTxt)
        Dim rowNo As Integer = 0
        Dim recNo As Integer = 1
        Dim rowCtr As Integer = 1
        rowNo = rowNo + 1
        Dim newPnl As Boolean = True
        Dim pnlNum As Integer = -1
        For i = 0 To dt.Rows.Count - 1
            If newPnl Then
                PnlList.Add(MakeNewTablePanel(hdrclmTxt, clmWd))
                pnlNum = pnlNum + 1
                newPnl = False
            End If
            Dim ctrl(ColumnCount) As Control
            'pad with row #
            Dim clmTxt() As String = {(i + 1).ToString}
            For j As Integer = 0 To dt.Columns.Count - 1
                ReDim Preserve clmTxt(j + 1)
                clmTxt(j + 1) = dt.Rows(i)(j)
            Next
            Dim h As Integer = 0
            For k As Integer = 0 To ColumnCount - 1
                Dim cStyle As ColumnStyle = PnlList(pnlNum).ColumnStyles(k)
                Dim myLbl As TextBox = New TextBox
                myLbl.Width = cStyle.Width
                myLbl.Height = TextRenderer.MeasureText(clmTxt(k), f_body).Height + 5
                If h < myLbl.Height Then h = myLbl.Height
                myLbl.TextAlign = HorizontalAlignment.Center
                myLbl.Text = clmTxt(k)
                myLbl.Tag = rowCtr
                PnlList(pnlNum).Controls.Add(myLbl, k, rowNo)
            Next
            PnlList(pnlNum).Height = PnlList(pnlNum).Height + h
            rowNo = rowNo + 1
            recNo = recNo + 1
            rowCtr = rowCtr + 1
            If rowCtr > 28 Then
                rowCtr = 1
                newPnl = True
            End If
        Next
        Dim pgInfo() As InfoSetting = Nothing
        Dim mypgCtr As Integer = -1
        For i = 0 To PnlList.Count - 1
            mypgCtr = mypgCtr + 1
            ReDim Preserve pgInfo(mypgCtr)
            pgInfo(mypgCtr).Landscape = False
            pgInfo(mypgCtr).PrintHdr = True
            pgInfo(mypgCtr).PrintFooter = True
            pgInfo(mypgCtr).Heading = " "
            pgInfo(mypgCtr).SubHeading = " "
            pgInfo(mypgCtr).pSize = GetDefaultPageSize()
            pgInfo(mypgCtr).pgBody = PrintUtils.MakeTableLayoutPanelPgContents(PnlList(i), New Point(70, 240))
            pgInfo(mypgCtr).pprKind = myDefaultPaperKind
        Next
        Return pgInfo
    End Function


    Public Shared Function GetDefaultPageSize() As Size
        Dim PrintDoc As PrintDocument = New PrintDocument
        Dim sz As Size
        For i As Integer = 0 To PrintDoc.PrinterSettings.PaperSizes.Count - 1
            Dim pSize As PaperSize = PrintDoc.PrinterSettings.PaperSizes.Item(i)
            Dim pKind As System.Drawing.Printing.PaperKind = PrintDoc.PrinterSettings.PaperSizes.Item(i).RawKind
            If pKind = myDefaultPaperKind Then
                sz = New Size(pSize.Width, pSize.Height)
                PrintDoc.Dispose()
                Return sz
            End If
        Next
        sz = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
                   PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
        PrintDoc.Dispose()
        Return sz
    End Function


    Public Shared Function GetPaperSize(ByVal pprKind As PaperKind) As PaperSize
        Dim PrintDoc As PrintDocument = New PrintDocument
        Dim sz As PaperSize
        For i As Integer = 0 To PrintDoc.PrinterSettings.PaperSizes.Count - 1
            Dim pSize As PaperSize = PrintDoc.PrinterSettings.PaperSizes.Item(i)
            Dim pKind As System.Drawing.Printing.PaperKind = PrintDoc.PrinterSettings.PaperSizes.Item(i).RawKind
            If pKind = pprKind Then
                sz = pSize
                PrintDoc.Dispose()
                Return sz
            End If
        Next
        sz = PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize
        PrintDoc.Dispose()
        Return sz
    End Function


    Public Shared Function GetPaperKind(ByVal wd As Integer, ByVal ht As Integer) As PaperKind
        Dim PrintDoc As PrintDocument = New PrintDocument
        For i As Integer = 0 To PrintDoc.PrinterSettings.PaperSizes.Count - 1
            Dim pSize As PaperSize = PrintDoc.PrinterSettings.PaperSizes.Item(i)
            Dim pKind As System.Drawing.Printing.PaperKind = PrintDoc.PrinterSettings.PaperSizes.Item(i).RawKind
            If pSize.Height = ht And pSize.Width = wd Then
                PrintDoc.Dispose()
                Return pKind
            End If
        Next
        If wd > ht Then
            If wd > 1100 Then
                Return PaperKind.Tabloid
            End If
        Else
            If ht > 1100 Then
                Return PaperKind.Tabloid
            End If
        End If
        Return myDefaultPaperKind
    End Function


    Public Shared bmp As Bitmap
    Public Shared g As Graphics
    Public Shared thisPageGlobal As InfoSetting
    Public Shared Sub PrintFullPage(ByVal e As PrintPageEventArgs, ByVal Heading As String, _
                 ByVal SubHeading As String, ByVal thisPage As InfoSetting, ByVal PgNum As Integer, ByVal ttlPgs As Integer)

        bmp = New Bitmap(thisPage.pSize.Width, thisPage.pSize.Height)
        g = Graphics.FromImage(bmp)
        thisPageGlobal = thisPage

        g.FillRectangle(Brushes.White, New Rectangle(0, 0, thisPage.pSize.Width, thisPage.pSize.Height))

        PrintPageHeader(e, Heading, SubHeading)

        PrintPageBody(e, thisPage)

        PrintPageFooter(e, PgNum, ttlPgs)

        bmp.Save(runtime.AbsolutePath + "\sites\forms\images\img_" + thisPage.PgNum.ToString + ".png", System.Drawing.Imaging.ImageFormat.Png)

    End Sub


    Public Shared Sub PrintPageHeader(ByVal e As PrintPageEventArgs, ByVal Heading As String, ByVal SubHeading As String)
        If Not thisPageGlobal.PrintHdr Then Return

        Dim logoPath = runtime.AbsolutePath + "sites\images\logo128.jpg"
        Dim logoImg As Image = Image.FromFile(logoPath)

        Dim f_title As Font = New Font("Times New Roman", 20, FontStyle.Bold)
        Dim PprSize As PaperSize = e.PageSettings.PaperSize
        e.Graphics.DrawRectangle(Pens.Blue, 50, 50, PprSize.Width - 100, PprSize.Height - 100)
        e.Graphics.DrawImage(logoImg, 600, 60, logoImg.Width, logoImg.Height)
        g.DrawRectangle(Pens.Blue, 50, 50, PprSize.Width - 100, PprSize.Height - 100)
        g.DrawImage(logoImg, 600, 60, logoImg.Width, logoImg.Height)

        Dim HdrX As Integer = 60 : Dim HdrY As Integer = 100
        e.Graphics.DrawString(Heading, f_title, Brushes.Black, HdrX, HdrY)
        g.DrawString(Heading, f_title, Brushes.Black, HdrX, HdrY)
        HdrY = HdrY + TextRenderer.MeasureText(SubHeading, f_title).Height + 5
        e.Graphics.DrawString(SubHeading, f_title, Brushes.Black, HdrX, HdrY)
        e.Graphics.DrawLine(Pens.Blue, 70, 200, PprSize.Width - 60, 200)
        g.DrawString(SubHeading, f_title, Brushes.Black, HdrX, HdrY)
        g.DrawLine(Pens.Blue, 70, 200, PprSize.Width - 60, 200)
        logoImg.Dispose()
    End Sub


    Public Shared Sub PrintPageBody(ByVal e As PrintPageEventArgs, ByVal thisPage As InfoSetting)
        If thisPage.pgBody.Length > 0 Then
            'e.Graphics.FillRectangle(Brushes.White, New Rectangle(0, 0, thisPage.pSize.Width, thisPage.pSize.Height))

            For Each obj As PrintUtils.pgBodyContents In thisPage.pgBody
                If obj.contentType = PrintUtils.pgContentType.text Then
                    Dim myRect As RectangleF = New RectangleF(obj.loc.X, obj.loc.Y, obj.sz.Width, obj.sz.Height)
                    Dim wd As Single = obj.sz.Width
                    Dim myBrush As System.Drawing.Brush = New SolidBrush(obj.foreColor)
                    e.Graphics.DrawString(obj.obj, obj.mfont, myBrush, myRect)
                    g.DrawString(obj.obj, obj.mfont, myBrush, myRect)
                ElseIf obj.contentType = PrintUtils.pgContentType.line Then
                    Dim st As Point = obj.loc : Dim en As Point = obj.eloc
                    e.Graphics.DrawLine(Pens.Black, st.X, st.Y, en.X, en.Y)
                    g.DrawLine(Pens.Black, st.X, st.Y, en.X, en.Y)
                ElseIf obj.contentType = PrintUtils.pgContentType.rect Then
                    Dim dobj As Rectangle = CType(obj.obj, Rectangle)
                    e.Graphics.DrawRectangle(Pens.Black, dobj)
                    g.DrawRectangle(Pens.Black, dobj)
                ElseIf obj.contentType = PrintUtils.pgContentType.image Then
                    Dim img As Image = Image.FromFile(obj.obj)
                    e.Graphics.DrawImage(img, New Rectangle(obj.loc.X, obj.loc.Y, img.Size.Width, img.Size.Height))
                    g.DrawImage(img, New Rectangle(obj.loc.X, obj.loc.Y, img.Size.Width, img.Size.Height))

                    img.Dispose()
                ElseIf obj.contentType = PrintUtils.pgContentType.docImage Then
                    Dim img As Image = Image.FromFile(obj.obj)
                    If img.Size.Width > img.Size.Height Then
                        e.Graphics.DrawImage(img, New Rectangle(obj.loc.X, obj.loc.Y, e.PageSettings.PaperSize.Height, e.PageSettings.PaperSize.Width))
                        g.DrawImage(img, New Rectangle(obj.loc.X, obj.loc.Y, e.PageSettings.PaperSize.Height, e.PageSettings.PaperSize.Width))
                    Else
                        e.Graphics.DrawImage(img, New Rectangle(obj.loc.X, obj.loc.Y, e.PageSettings.PaperSize.Width, e.PageSettings.PaperSize.Height))
                        g.DrawImage(img, New Rectangle(obj.loc.X, obj.loc.Y, e.PageSettings.PaperSize.Width, e.PageSettings.PaperSize.Height))
                    End If
                    img.Dispose()
                End If
            Next

        End If
    End Sub


    Public Shared Sub PrintPageFooter(ByVal e As PrintPageEventArgs, ByVal PgNum As Integer, ByVal ttlPgs As Integer)
        If Not thisPageGlobal.PrintFooter Then Return

        Dim f_body As Font = New Font("Times New Roman", 10)
        Dim LeftMargin As Integer = 70
        Dim PprSize As PaperSize = e.PageSettings.PaperSize
        Dim str As String = "Page " + (PgNum + 1).ToString + " of " + ttlPgs.ToString + "                      " + _
                            Now.Date.ToShortDateString
        e.Graphics.DrawString(str, f_body, Brushes.Black, LeftMargin, PprSize.Height - 30)
        g.DrawString(str, f_body, Brushes.Black, LeftMargin, PprSize.Height - 30)
    End Sub


    Public Shared Function MakeNewTablePanel(ByVal myColumnNames() As String, ByVal clmWd() As Integer) As TableLayoutPanel
        'Dim ColumnCount As Integer = hdrclmTxt.Length
        Dim f_body As Font = New Font("Times New Roman", 10)
        Dim pnlTbl As TableLayoutPanel = New TableLayoutPanel
        pnlTbl.ColumnCount = myColumnNames.Length
        pnlTbl.BackColor = Color.White
        pnlTbl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Dim myPnlWidth As Integer = 0
        For i As Integer = 0 To myColumnNames.Length - 1
            myPnlWidth = myPnlWidth + clmWd(i)
        Next
        Dim rowNo As Integer = 0
        Dim recNo As Integer = 1
        Dim h As Integer = 0
        For k As Integer = 0 To myColumnNames.Length - 1
            Dim myLbl As TextBox = New TextBox
            myLbl.Width = clmWd(k)
            myLbl.Height = TextRenderer.MeasureText(myColumnNames(k), f_body).Height + 5
            If h < myLbl.Height Then h = myLbl.Height
            myLbl.TextAlign = HorizontalAlignment.Center
            myLbl.Text = myColumnNames(k)
            myLbl.Tag = rowNo
            pnlTbl.Controls.Add(myLbl, k, rowNo)
            Dim cStyle As ColumnStyle = New ColumnStyle
            cStyle.Width = myLbl.Width
            pnlTbl.ColumnStyles.Add(cStyle)
            If h < myLbl.Height Then h = myLbl.Height
        Next
        Dim rS As RowStyle = New RowStyle
        rS.Height = h
        pnlTbl.RowStyles.Add(rS)
        pnlTbl.Height = h
        pnlTbl.Width = myPnlWidth
        Return pnlTbl
    End Function


    Public Shared Function MakeTableLayoutPanelPgContents(ByVal pnl As TableLayoutPanel, ByVal loc As Point)
        Dim X = loc.X
        Dim Y = loc.Y
        Dim pgContentsList() As PrintUtils.pgBodyContents
        Dim ctr As Integer = 0
        For Each ctrl As Control In pnl.Controls
            Dim rowNo = ctrl.Tag
            X = loc.X + ctrl.Location.X
            Y = loc.Y + rowNo * ctrl.Height
            ReDim Preserve pgContentsList(ctr)
            pgContentsList(ctr) = PrintUtils.MakeTextObject(ctrl.Text, New Point(X, Y))
            ctr = ctr + 1
            ReDim Preserve pgContentsList(ctr)
            pgContentsList(ctr) = PrintUtils.MakeRectObject(New Rectangle(X, Y, ctrl.Width + 7, ctrl.Height))
            ctr = ctr + 1
        Next
        Return pgContentsList
    End Function

    'Private Sub printDoc_BeginPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
    '    pgCtr = 0
    '    _DonePrinting = False
    '    If Not logoImg Is Nothing Then
    '        logoImg.Dispose()
    '    End If
    '    logoImg = Image.FromFile(runtime.AbsolutePath + "sites\images\logo128.jpg")
    '    'PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize = pgInfo(0).ppSize
    '    If pgInfo(pgCtr).Landscape Then
    '        PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = True
    '    Else
    '        PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = False
    '    End If
    'End Sub




    Public Shared Sub SaveImage(ByVal e As PrintPageEventArgs, ByVal pgCtr As Integer, ByVal thisPage As InfoSetting)
        Dim img As Image = New Bitmap(thisPage.pSize.Width, thisPage.pSize.Height, e.Graphics)
        img.Save("c:\formtest_" + pgCtr.ToString + ".png", System.Drawing.Imaging.ImageFormat.Png)

        img.Dispose()
    End Sub



    'Private Sub printDoc_EndPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
    '    _DonePrinting = True
    'End Sub


    'Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
    '    If pgInfo(pgCtr).PrintHdr Then
    '        PageHeader(e, pgInfo(pgCtr).Heading, pgInfo(pgCtr).SubHeading)
    '    End If
    '    If Not pgInfo(pgCtr).pgBody Is Nothing Then
    '        PageBody(e, pgCtr)
    '    End If
    '    If pgInfo(pgCtr).PrintFooter Then
    '        PageFooter(e, pgInfo(pgCtr).PgNum)
    '    End If
    '    pgCtr = pgCtr + 1
    '    If pgCtr < pgInfo.Length Then
    '        If Not pgInfo(pgCtr).pkSize Is Nothing Then
    '            e.PageSettings.PaperSize = pgInfo(pgCtr).pkSize
    '        End If
    '        If pgInfo(pgCtr).Landscape Then
    '            e.PageSettings.Landscape = True
    '        Else
    '            e.PageSettings.Landscape = False
    '        End If
    '        e.HasMorePages = True
    '    Else
    '        e.HasMorePages = False
    '    End If

    'End Sub

    'Public Shared PrintPreview(ByVal listPgInfo() As InfoSetting)
    '    pgInfo = listPgInfo
    '    _DonePrinting = False
    '    Cursor.Current = Cursors.WaitCursor
    '    If Not PrintDoc Is Nothing Then
    '        PrintDoc.Dispose()
    '    End If
    '    PrintDoc = New PrintDocument()
    '    If Directory.Exists(imgdir) Then
    '        Directory.Delete(imgdir, True)
    '    End If
    '    Directory.CreateDirectory(imgdir)
    '    PrintDoc.DocumentName = "Print Packages"
    'Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()

    '    AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
    '    AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
    '    AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage

    '    Cursor.Current = Cursors.Default
    '    printDialog.Document = Me.PrintDoc
    '    printDialog.ShowDialog()

    'End Sub


End Class
