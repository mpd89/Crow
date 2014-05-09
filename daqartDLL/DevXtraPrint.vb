Imports Microsoft.VisualBasic
Imports System.Drawing
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid
Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraLayout.Utils


Public Class DevXPrint1
    Inherits Link

    Public Sub New(ByVal ps As PrintingSystem)
        CreateDocument(ps)
        Me.fLandscape = True
    End Sub
End Class

'Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
'Handles button1.Click
'    Dim DevXPrint As New DevXPrint1(printingSystem1)
'    DevXPrint.ShowPreview()
'End Sub

'-----1--------------------------


Public Class DevXPrint2
    Inherits DevXPrint1

    Friend top As Integer = 0

    Public Sub New(ByVal ps As PrintingSystem)
        MyBase.New(ps)
    End Sub

    Public Overloads Overrides Sub CreateDocument(ByVal ps As PrintingSystem)
        If Not ps Is Nothing Then
            Dim g As BrickGraphics = ps.Graph

            ' Set the background color to White.
            g.BackColor = Color.White

            ' Set the border color to Black.
            g.BorderColor = Color.Black

            ' Set the font to the default font.
            g.Font = g.DefaultFont

            ' Set the line alignment.
            g.StringFormat = g.StringFormat.ChangeLineAlignment(StringAlignment.Near)

            MyBase.CreateDocument(ps)
        End If
    End Sub

    ' Add a text brick without borders with a "Hello World!" text.
    Protected Overrides Sub CreateDetail(ByVal graph As BrickGraphics)
        Dim r As RectangleF = New RectangleF(0, 0, 150, 50)
        Dim s As String = "Hello World!"
        graph.DrawString(s, Color.Black, r, BorderSide.None)
        Me.CreateReportHeader(graph)
    End Sub
End Class

'Private Sub button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
'Handles button2.Click
'    Dim DevXPrint As New DevXPrint2(printingSystem1)
'    DevXPrint.ShowPreview()
'End Sub

'----2-----------------------------

Public Class DevXPrint3
    Inherits DevXPrint2

    Public Sub New(ByVal ps As PrintingSystem)
        MyBase.New(ps)
    End Sub

    ' Set the background color to Deep Sky Blue.
    Protected Overrides Sub CreateDetail(ByVal graph As BrickGraphics)
        graph.BackColor = Color.DeepSkyBlue

        ' Set the border color to Midnight Blue.
        graph.BorderColor = Color.MidnightBlue

        ' Add a text brick with all borders and a "Hello World!" text.
        Dim r As RectangleF = New RectangleF(0, 0, 150, 50)
        Dim s As String = "Hello World!"
        graph.DrawString(s, Color.Red, r, BorderSide.All)
    End Sub
End Class

'Private Sub button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
'Handles button3.Click
'    Dim DevXPrint As New DevXPrint3(printingSystem1)
'    DevXPrint.ShowPreview()
'End Sub

'-------3-----------------------

Public Class DevXPrint4
    Inherits DevXPrint3
    Public Sub New(ByVal ps As PrintingSystem)
        MyBase.New(ps)
    End Sub

    ' Change the brick font name to Tahoma, size to 16, and set bold and italic attributes.
    Protected Overrides Sub CreateDetail(ByVal graph As BrickGraphics)
        graph.Font = New Font("Tahoma", 16, FontStyle.Bold Or FontStyle.Italic)
        MyBase.CreateDetail(graph)
    End Sub
End Class

'Private Sub button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
'Handles button4.Click
'    Dim DevXPrint As New DevXPrint4(printingSystem1)
'    DevXPrint.ShowPreview()
'End Sub


'------4---------------------

Public Class DevXPrint5
    Inherits DevXPrint4
    Public Sub New(ByVal ps As PrintingSystem)
        MyBase.New(ps)
    End Sub

    Protected Overrides Sub CreateDetail(ByVal graph As BrickGraphics)
        ' Center the text string.
        graph.StringFormat = graph.StringFormat.ChangeLineAlignment(StringAlignment.Center)

        MyBase.CreateDetail(graph)
        CreateRow(graph)
    End Sub

    Protected Overridable Sub CreateRow(ByVal graph As BrickGraphics)
        ' Set the brick font name to Arial, size to 14, and set the bold attribute.
        graph.Font = New Font("Arial", 14, FontStyle.Bold)

        top += 50

        ' Add a text brick with all borders to a specific location 
        ' with a "Good-bye!" text using the blue font color.
        graph.DrawString("Good-bye!", Color.Blue, _
            New RectangleF(0, top, 150, 50), BorderSide.All)
    End Sub
End Class

'Private Sub button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
'Handles button5.Click
'    Dim DevXPrint As New DevXPrint5(printingSystem1)
'    DevXPrint.ShowPreview()

'End Sub


'------5---------------------

Public Class DevXPrint6
    Inherits DevXPrint5
    Public Sub New(ByVal ps As PrintingSystem)
        MyBase.New(ps)
    End Sub

    Protected Overrides Sub CreateDetail(ByVal graph As BrickGraphics)
        ' Center the text string.
        graph.StringFormat = graph.StringFormat.ChangeLineAlignment(StringAlignment.Center)

        ' Add an unchecked check box brick with all borders 
        ' to a specific location using the Light Sky Blue background color.
        graph.DrawCheckBox(New RectangleF(150, 0, 50, 50), _
            BorderSide.All, Color.LightSkyBlue, False)

        ' Add an empty rectangle with all borders 
        ' to a specific location using the Light Lavender background color.
        graph.DrawRect(New RectangleF(200, 0, 50, 50), _
            BorderSide.All, Color.Lavender, graph.BorderColor)

        MyBase.CreateDetail(graph)
    End Sub

    Protected Overrides Sub CreateRow(ByVal graph As BrickGraphics)
        MyBase.CreateRow(graph)

        ' Add a checked check box brick with all borders 
        ' to a specific location using the Light Sky Blue background color.
        graph.DrawCheckBox(New RectangleF(150, top, 50, 50), _
            BorderSide.All, Color.LightSkyBlue, True)

    End Sub
End Class

'Private Sub button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
'Handles button6.Click
'    Dim DevXPrint As New DevXPrint6(printingSystem1)
'    DevXPrint.ShowPreview()
'End Sub


'------6---------------------

Public Class DevXPrint7
    Inherits DevXPrint6
    Private img As Bitmap
    Friend bkImageColor As Color = Color.Lavender

    Public Sub New(ByVal ps As PrintingSystem, ByVal img As Bitmap)
        MyBase.New(Nothing)
        Me.img = img
        CreateDocument(ps)
    End Sub

    Protected Overrides Sub CreateRow(ByVal graph As BrickGraphics)
        MyBase.CreateRow(graph)

        ' Add an empty rectangle with all borders 
        ' to a specific location using a Lavender background color.
        graph.DrawRect(New RectangleF(200, top, 50, 50), _
            BorderSide.All, bkImageColor, graph.BorderColor)

        ' Add an image without borders 
        ' to a specific location using a Transparent color.
        If Not img Is Nothing Then
            graph.DrawImage(img, New RectangleF(Convert.ToSingle(200 + (50 - img.Width) / 2), _
                Convert.ToSingle(top + (50 - img.Height) / 2), img.Width, img.Height), _
                BorderSide.None, Color.Transparent)
        End If
    End Sub

End Class

'Private Sub button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
'Handles button7.Click
'    Dim img As Bitmap = CType(Bitmap.FromFile("fish.bmp"), Bitmap)
'    img.MakeTransparent()

'    Dim DevXPrint As New DevXPrint7(printingSystem1, img)
'    DevXPrint.ShowPreview()
'End Sub


'-------7---------------

Public Class DevXPrint8
    Inherits DevXPrint7
    Public Sub New(ByVal ps As PrintingSystem, ByVal img As Bitmap)
        MyBase.New(ps, img)
    End Sub

    Protected Overrides Sub CreateDetailHeader(ByVal graph As BrickGraphics)
        ' Center a text string horizontally and vertically.
        graph.StringFormat = New BrickStringFormat(StringAlignment.Center, StringAlignment.Center)

        ' Set the brick font name to Comic Sans MS, size to 12.
        graph.Font = New Font("Comic Sans MS", 12)

        ' Set the background color to Light Green.
        graph.BackColor = Color.LightGreen

        ' Add a text brick with all borders to a specific location 
        ' with an "I" text string using a Green font color.
        graph.DrawString("I", Color.Green, New RectangleF(0, 0, 150, 25), BorderSide.All)

        ' Add a text brick with all borders to a specific location 
        ' with a "love" text string using a Green font color.
        graph.DrawString("love", Color.Green, New RectangleF(150, 0, 50, 25), BorderSide.All)

        ' Add a text brick with all borders to a specific location 
        ' with a "you" text string using a Green font color.
        graph.DrawString("you", Color.Green, New RectangleF(200, 0, 50, 25), BorderSide.All)

        ' Set the line alignment.
        graph.StringFormat = graph.StringFormat.ChangeAlignment(StringAlignment.Near)

    End Sub
End Class

'Private Sub button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
'Handles button8.Click
'    Dim img As Bitmap = CType(Bitmap.FromFile("fish.bmp"), Bitmap)
'    img.MakeTransparent()

'    Dim DevXPrint As New DevXPrint8(printingSystem1)
'    DevXPrint.ShowPreview()
'End Sub


'------8---------------------

Public Class DevXtraPrintGrid
    Inherits Link
    Private dg As DevExpress.XtraGrid.GridControl

    Public Sub New(ByVal _ps As PrintingSystem, ByVal _dg As DevExpress.XtraGrid.GridControl)
        ps = _ps
        dg = _dg
        Dim lView As Views.Layout.LayoutView = New Views.Layout.LayoutView(dg)
        '  Dim link As New PrintableComponentLink(ps)
        Using Link As PrintableComponentLink = New PrintableComponentLink


            Link.PrintingSystem.Begin()
            Dim gr As BrickGraphics = Link.PrintingSystem.Graph
            gr.Modifier = BrickModifier.InnerPageHeader
            Dim logoPath = runtime.AbsolutePath + "sites\images\logo128.jpg"
            Dim logoImg As Image = New Bitmap(System.Drawing.Image.FromFile(logoPath))
            Link.Images.Add(logoImg)
            Dim brick As LineBrick = gr.DrawLine(New PointF(0, 0), New PointF(500, 500), Color.Black, 5)
            Link.Landscape = True
            Link.Component = dg
            'link.PrintingSystem.PageSettings.TopMargin = 100
            Link.PrintingSystem.PageSettings.TopMargin = 20

            Dim phf As PageHeaderFooter = TryCast(Link.PageHeaderFooter, PageHeaderFooter)
            phf.Header.Content.Clear()
            phf.Header.Content.AddRange(New String() {"TTTT", "GGG", "[Image 0]"})
            phf.Header.Font = New Font("Times New Roman", 20)
            phf.Footer.Content.Clear()
            phf.Footer.Content.AddRange(New String() {"Pages: [Page # of Pages #]", " ", "Date: [Date Printed]"})
            phf.Footer.Font = New Font("Times New Roman", 12)
            'AddHandler link.CreateReportHeaderArea, AddressOf CreatemyDetailHeaderArea
            phf.Header.LineAlignment = BrickAlignment.Far
            Link.CreateDocument(ps)
            Link.PrintingSystem.End()
            Link.ShowPreview()
        End Using
    End Sub
    Private Sub CreatemyDetailHeaderArea(ByVal Sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)
        ' Center a text string horizontally and vertically.
        'e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center, StringAlignment.Center)

        ' Set the brick font name to Comic Sans MS, size to 12.
        e.Graph.Font = New Font("Comic Sans MS", 12)

        ' Set the background color to Light Green.
        e.Graph.BackColor = Color.LightGreen

        ' Add a text brick with all borders to a specific location 
        ' with an "I" text string using a Green font color.
        e.Graph.DrawString("I", Color.Green, New RectangleF(0, 0, 150, 25), BorderSide.All)

        ' Add a text brick with all borders to a specific location 
        ' with a "love" text string using a Green font color.
        e.Graph.DrawString("love", Color.Green, New RectangleF(150, 0, 50, 25), BorderSide.All)

        ' Add a text brick with all borders to a specific location 
        ' with a "you" text string using a Green font color.
        e.Graph.DrawString("you", Color.Green, New RectangleF(200, 0, 50, 25), BorderSide.All)

        ' Set the line alignment.
        'e.Graph.StringFormat = e.Graph.StringFormat.ChangeAlignment(StringAlignment.Near)

    End Sub

    'Private Sub CreateReportHeaderArea(ByVal sender As System.Object, ByVal e As CreateAreaEventArgs)
    '    Dim pgSize As SizeF = e.Graph.ClientPageSize
    '    Dim rec As RectangleF = New RectangleF(0, 0, pgSize.Width, 40)
    '    e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
    '    e.Graph.Font = New Font("TimesRoman", 24, FontStyle.Bold)
    '    e.Graph.DrawString(printPgHdr, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None)

    '    'e.Graph.Font = New Font("TimesRoman", 12, FontStyle.Bold)
    '    'Dim mydate As String = "Date: " + Now.Date()
    '    'Dim strSize As SizeF = e.Graph.MeasureString(mydate)
    '    'rec = New RectangleF(New Point(pgSize.Width - strSize.Width, 40), strSize)
    '    'e.Graph.DrawString(mydate, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None)

    '    'Dim mystr As String = "Requested By: " + Utilities.GetUserInfo(runtime.thisUser).Rows(0)(1)
    '    'strSize = e.Graph.MeasureString(mystr)
    '    'rec = New RectangleF(New Point(pgSize.Width - strSize.Width, 60), strSize)
    '    'e.Graph.DrawString(mystr, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None)
    '    'If Not logoPath Is Nothing Then
    '    '    Dim img As Image = Image.FromFile(logoPath)
    '    '    rec = New RectangleF(New Point(0, 0), img.Size)
    '    '    e.Graph.DrawImage(img, rec, DevExpress.XtraPrinting.BorderSide.None, Color.Violet)
    '    'End If

    'End Sub
End Class
Public Class DevXtraPrintImage
    Inherits DevXPrint8

    Public Sub New(ByVal ps As PrintingSystem, ByVal img As Bitmap)
        MyBase.New(ps, img)
    End Sub

    Protected Overrides Sub CreateRow(ByVal graph As BrickGraphics)
        ' Set the number of iterations for row creation.
        Dim c As Integer = 230

        Dim i As Integer
        For i = 0 To 49

            ' Set the background color using RGB.
            bkImageColor = Color.FromArgb(c, c, c + 20)

            MyBase.CreateRow(graph)
            If c - 4 > 0 Then
                c = c - 4
            Else
                c = c
            End If
        Next
    End Sub

    Protected Overrides Sub CreateMarginalHeader(ByVal graph As BrickGraphics)
        ' Set the format string for a page info brick.
        Dim format As String = "Page {0} of {1}"

        ' Set font to the default font.
        graph.Font = graph.DefaultFont

        ' Set the background color to Transparent.
        graph.BackColor = Color.Transparent

        ' Set the rectangle for drawing.
        Dim r As RectangleF = New RectangleF(0, 0, 0, graph.Font.Height)

        ' Add a page info brick without borders that displays
        ' the current page number from the total number of pages.
        Dim brick As PageInfoBrick = graph.DrawPageInfo(PageInfo.NumberOfTotal, _
            format, Color.Black, r, BorderSide.None)

        ' Set brick alignment.
        brick.Alignment = BrickAlignment.Far

        ' Enable auto width for a brick.
        brick.AutoWidth = True

        ' Add a page info brick without borders 
        ' that displays date and time.
        brick = graph.DrawPageInfo(PageInfo.DateTime, "", Color.Black, r, _
            BorderSide.None)

        ' Set brick alignment.
        brick.Alignment = BrickAlignment.Near

        ' Enable auto width for a brick.
        brick.AutoWidth = True
    End Sub

End Class


'Private Sub button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
'Handles button9.Click
'    Dim img As Bitmap = CType(Bitmap.FromFile("fish.bmp"), Bitmap)
'    img.MakeTransparent()

'    Dim DevXPrint As New DevXPrint9(printingSystem1)
'    DevXPrint.ShowPreview()
'End Sub










