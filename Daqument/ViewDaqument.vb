Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing.Imaging
Imports DaqartDLL
Public Class ViewDaqument
    ''Dim workingImage As Image '= Image.FromFile("c:\Daqlite\3039-48D5-5001_0C_1_1.png")
    ''Dim bmp_Image As New Bitmap(workingImage)
    'Private Enum editMode
    '    none
    '    draging
    '    highlighting
    '    marking
    'End Enum



    'Dim ImageSize As Size
    'Dim NewImageSize As Size

    'Dim bm As Bitmap

    'Dim MousePos As Point
    'Dim StartingPoint As Point
    'Dim ImagePosition As New Point(0, 0)
    'Dim XOffset As Integer
    'Dim YOffset As Integer


    'Dim g As Graphics
    'Dim foreground As Graphics
    'Dim hilite As Graphics
    'Public Shared DocumentID As Integer
    'Dim DocumentName As String

    'Dim HiLiteColor As Color = Color.Red

    'Dim dwgMode As editMode
    'Dim MouseDown As Boolean
    'Dim ZoomFactor As Double = 1.0

    'Dim objects As List(Of Point)
    'Dim objectColor As List(Of Color)
    'Dim objectSize As List(Of Integer)
    ''Private OriginalDocImage As Image
    'Private _backBuffer As Bitmap

    'Dim TopLayerVisible As Boolean

    'Public Sub New(ByVal ThisDocument As Integer)
    '    Me.InitializeComponent()
    '    DocumentID = ThisDocument
    '    objects = New List(Of Point)
    '    objectColor = New List(Of Color)()
    '    objectSize = New List(Of Integer)()
    '    TopLayerVisible = True

    'End Sub
    'Private Sub ViewDaqument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Try
    '        Dim query As String = "select * from document_store  where DocumentMUID = '" + DocumentID + "'"
    '        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
    '        sqlDocUtils.OpenConnection()
    '        Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
    '        sqlDocUtils.CloseConnection()


    '        If dt Is Nothing Then Return
    '        If dt.Rows(0)("DocumentImage") Is Nothing Then Return


    '        'Dim content As Image
    '        'content = ds.DocumentImage
    '        If Not (dt.Rows(0)("DocumentImage") Is Nothing) Then
    '            Dim imagedata() As Byte
    '            Dim imageBytedata As IO.MemoryStream
    '            imagedata = dt.Rows(0)("DocumentImage")
    '            imageBytedata = New IO.MemoryStream(imagedata)
    '            'OriginalDocImage = Image.FromStream(imageBytedata)

    '            Dim workingImage As Image = Image.FromStream(imageBytedata) '= Image.FromFile("c:\Daqlite\3039-48D5-5001_0C_1_1.png")
    '            'workingImage = ds.DocumentImage
    '            Dim bmp_Image As New Bitmap(workingImage)
    '            'axImageViewer1.LoadImageFromPictureBox(ds.DocumentImage)

    '            ImageSize = bmp_Image.Size
    '            NewImageSize = bmp_Image.Size

    '            bm = New Bitmap(ImageSize.Width, ImageSize.Height)


    '            dwgPanel.AutoScrollMinSize = NewImageSize

    '            'SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
    '            MakeTransparent(bmp_Image, workingImage)
    '            StatusStrip1.Text = DocumentName
    '            Me.dwgPanel.BackgroundImage = bmp_Image

    '        Else
    '            MessageBox.Show("Image was not stored for the document")
    '        End If
    '    Catch ex As Exception
    '        Utilities.logErrorMessage("Daqument.ViewDaqument_Load-" + ex.Message)
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub
    'Private Sub MakeTransparent(ByVal bmp_image As Bitmap, ByVal workingImage As Image)
    '    bmp_image = workingImage
    '    bm = New Bitmap(ImageSize.Width, ImageSize.Height)
    '    foreground = Graphics.FromImage(bm)
    '    bmp_image.MakeTransparent(Color.White)
    '    foreground.DrawImage(bmp_image, 0, 0)
    'End Sub

    'Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
    '    Application.Exit()
    'End Sub

    'Private Sub picSrc_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dwgPanel.MouseDown
    '    MouseDown = True
    '    MousePos = e.Location
    '    If dwgMode = editMode.highlighting Then
    '        StartingPoint = New Point(e.X, e.Y)
    '    End If
    'End Sub


    'Private Sub dwgPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dwgPanel.MouseMove
    '    lab_XY.Text = "X: " & e.Location.X & "         Y:  " & e.Location.Y

    '    If MouseDown = True And dwgMode = editMode.draging Then
    '        Dim newPosition As New Point(e.X, e.Y)

    '        ImagePosition.X = ImagePosition.X + (newPosition.X - MousePos.X)
    '        ImagePosition.Y = ImagePosition.Y + (newPosition.Y - MousePos.Y)

    '        'keeps top and left from gray space
    '        If ImagePosition.X > 0 Then
    '            ImagePosition.X = 0
    '        End If
    '        If ImagePosition.Y > 0 Then
    '            ImagePosition.Y = 0
    '        End If

    '        'keeps right and bottom from gray space
    '        If (Me.ClientSize.Width - NewImageSize.Width) > (ImagePosition.X + 20) Then
    '            ImagePosition.X = Me.ClientSize.Width - NewImageSize.Width - 20
    '        End If
    '        If (Me.ClientSize.Height - NewImageSize.Height) > (ImagePosition.Y + 75) Then
    '            ImagePosition.Y = Me.ClientSize.Height - NewImageSize.Height - 75
    '        End If

    '        XOffset = 0 - ImagePosition.X
    '        YOffset = 0 - ImagePosition.Y

    '        dwgPanel.AutoScrollPosition = New Point(ImagePosition.X * -1, ImagePosition.Y * -1)
    '        dwgPanel.Location = New Point(XOffset, YOffset)
    '        dwgPanel.Update()
    '        'dwgPanel.Refresh()

    '    End If


    '    If MouseDown = True And dwgMode = editMode.highlighting Then
    '        Dim myPoint As Point = New Point(e.X, e.Y)
    '        Dim myPen As New Pen(Brushes.Blue, 1)
    '        foreground.DrawLine(myPen, StartingPoint, myPoint)
    '        StartingPoint = myPoint
    '        dwgPanel.Refresh()


    '    End If


    '    MousePos = e.Location

    'End Sub


    'Private Sub dwgPanel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dwgPanel.MouseUp
    '    Dim newPosition As New Point(e.X, e.Y)

    '    If dwgMode = editMode.draging Then
    '        dwgPanel.Update()
    '        'dwgPanel.Refresh()
    '    End If

    '    If dwgMode = editMode.highlighting Then
    '        Dim myPoint As Point = New Point(e.X, e.Y)
    '        ControlPaint.DrawReversibleLine(StartingPoint, myPoint, Color.Black)
    '        dwgPanel.Update()
    '        'dwgPanel.Refresh()
    '    End If


    '    MouseDown = False
    'End Sub


    'Private Sub dwgPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles dwgPanel.Paint

    '    If _backBuffer Is Nothing Then
    '        '           _backBuffer = New Bitmap(NewImageSize.Width, NewImageSize.Height)
    '    End If

    '    '      g = e.Graphics

    '    '        g.FillRectangle(New SolidBrush(Color.White), ImagePosition.X, ImagePosition.Y, NewImageSize.Width, NewImageSize.Height)

    '    If TopLayerVisible Then
    '        '           g.DrawImage(bm, ImagePosition.X, ImagePosition.Y, NewImageSize.Width, NewImageSize.Height)
    '    End If


    '    '        MyBase.OnPaint(e)


    'End Sub


    'Private Sub btnDrag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrag.Click

    '    dwgPanel.Cursor = Cursors.NoMove2D
    '    dwgMode = editMode.draging



    'End Sub


    'Private Sub dwgPanel_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dwgPanel.Scroll

    '    ImagePosition.X = dwgPanel.AutoScrollPosition.X
    '    ImagePosition.Y = dwgPanel.AutoScrollPosition.Y

    '    'dwgPanel.Refresh()
    '    dwgPanel.Update()



    'End Sub


    'Private Sub btnViewNormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewNormal.Click
    '    dwgPanel.Cursor = Cursors.Arrow
    '    dwgMode = editMode.none
    'End Sub


    'Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    dwgMode = editMode.highlighting
    '    dwgPanel.Cursor = Cursors.Cross

    'End Sub


    'Private Sub cbx_Zoom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_Zoom.LostFocus
    '    Dim ThisZoom As Double
    '    ThisZoom = CDbl(cbx_Zoom.Text.Replace("%", ""))
    '    cbx_Zoom.Text.Replace("%", "")
    '    cbx_Zoom.Text += "%"
    '    Zoom(ThisZoom)
    'End Sub


    'Private Sub cbx_Zoom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_Zoom.SelectedIndexChanged
    '    Dim ThisZoom As Double
    '    ThisZoom = CDbl(cbx_Zoom.Text.Replace("%", ""))
    '    Zoom(ThisZoom)
    'End Sub


    'Private Sub Zoom(ByVal ZF As Double)

    '    NewImageSize.Width = ImageSize.Width * ZF / 100
    '    NewImageSize.Height = ImageSize.Height * ZF / 100

    '    dwgPanel.AutoScrollMinSize = NewImageSize
    '    dwgPanel.Refresh()

    'End Sub


    'Private Sub HideTransparencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideTransparencyToolStripMenuItem.Click
    '    TopLayerVisible = False
    '    dwgPanel.Update()

    'End Sub


    'Private Sub ShowTransparencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowTransparencyToolStripMenuItem.Click
    '    TopLayerVisible = True
    '    dwgPanel.Update()

    'End Sub

    'Private Sub btnHighlite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHighlite.Click
    '    dwgPanel.Cursor = Cursors.UpArrow
    '    dwgMode = editMode.highlighting
    'End Sub
End Class