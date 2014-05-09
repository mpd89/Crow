Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.IO
Imports System.Data.SqlClient
Imports daqartDLL


Public Class ImagePreview
    'Dim workingImage As Image = pbx_Image.Image
    'Dim bmp_Image As New Bitmap(workingImage)

    Dim OriginalImage As Image
    Dim ImageSize As Size
    Dim NewImageSize As Size

    Dim MousePos As Point
    Private localStartPoint As Point = New Point()
    Dim StartingPoint As Point
    Dim ImagePosition As New Point(0, 0)
    Dim XOffset As Integer
    Dim YOffset As Integer


    Dim dwgMode As Integer = 0
    Dim MouseDown As Boolean
    Dim ZoomFactor As Double = 1.0


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dwgMode = 0

        pbx_Image.Cursor = Cursors.Default
    End Sub


    Private Sub tsb_Pan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Pan.Click
        dwgMode = 1


    End Sub


    Private Sub tsb_ZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_ZoomIn.Click
        dwgMode = 2

        Dim ms As MemoryStream = New MemoryStream(My.Resources.ZoomIn)
        pbx_Image.Cursor = New Cursor(ms)


    End Sub


    Private Sub tsb_ZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_ZoomOut.Click
        dwgMode = 3

        Dim ms As MemoryStream = New MemoryStream(My.Resources.ZoomOut)
        pbx_Image.Cursor = New Cursor(ms)


    End Sub



    Private Sub pbx_Image_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbx_Image.MouseClick

        If dwgMode < 2 Then Return

        Dim ClickPos As Point = New Point(e.X, e.Y)
        Dim thisImg As Image = OriginalImage
        Dim newWidth As Integer
        Dim newHeight As Integer
        Dim newLocation As Point

        If dwgMode = 2 Then
            newWidth = CInt(pbx_Image.Image.Size.Width * 1.2)
            newHeight = CInt(pbx_Image.Image.Size.Height * 1.2)
            newLocation = New Point(pbx_Image.Location.X * 1.2, pbx_Image.Location.Y * 1.2)
        End If

        If dwgMode = 3 Then
            newWidth = CInt(pbx_Image.Image.Size.Width / 1.2)
            newHeight = CInt(pbx_Image.Image.Size.Height / 1.2)
            newLocation = New Point(pbx_Image.Location.X / 1.2, pbx_Image.Location.Y / 1.2)
        End If

        Dim bm As New Bitmap(thisImg)
        Dim thisBM As New Bitmap(newWidth, newHeight)
        Dim g As Graphics = Graphics.FromImage(thisBM)
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.DrawImage(bm, New Rectangle(0, 0, newWidth, newHeight), _
            New Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel)
        g.Dispose()


        pbx_Image.Image = thisBM
        pbx_Image.Height = pbx_Image.Image.Height
        pbx_Image.Width = pbx_Image.Image.Width

        pbx_Image.Location = newLocation

    End Sub


    Private Sub pbx_Image_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbx_Image.MouseDown
        MouseDown = True
        MousePos = New Point(e.X, e.Y)
        localStartPoint = New Point(e.X, e.Y)
    End Sub


    Private Sub pbx_Image_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbx_Image.MouseMove
        Dim myPoint As Point = New Point(e.X, e.Y)

        If MouseDown = True And dwgMode = 1 Then

            If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
            Dim picPoint As Point = pbx_Image.Location
            Dim diffX = myPoint.X - localStartPoint.X : Dim diffY = myPoint.Y - localStartPoint.Y

            pbx_Image.Location = New Point(picPoint.X + diffX, picPoint.Y + diffY)

            'Panel1.AutoScrollPosition = New Point(picPoint.X * -1, picPoint.Y * -1)
            Dim HScroll As Integer = 0 - pbx_Image.Location.X
            Dim VScroll As Integer = 0 - pbx_Image.Location.Y

            Panel1.AutoScrollPosition = New Point(HScroll, VScroll)

            Me.pbx_Image.Refresh()


        End If

    End Sub


    Public Sub ImageLoaded()

        OriginalImage = pbx_Image.Image
        ImageSize = pbx_Image.Image.Size

        pbx_Image.Height = ImageSize.Height
        pbx_Image.Width = ImageSize.Width


    End Sub


    Private Sub Panel1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Panel1.Scroll

        'If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
        '    pbx_Image.Location = New Point(pbx_Image.Location.X, pbx_Image.Location.Y + (e.NewValue - e.OldValue))
        'End If

        'If e.ScrollOrientation = ScrollOrientation.HorizontalScroll Then
        '    pbx_Image.Location = New Point(pbx_Image.Location.X + (e.NewValue - e.OldValue), pbx_Image.Location.Y)
        'End If
        'Me.pbx_Image.Refresh()

    End Sub





End Class
