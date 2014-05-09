Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.IO
Imports System.Data.SqlClient
Imports daqartDLL


Public Class TDraw
    Public Shared DocumentID As Integer
    Private myDoc As EditDaqumentUtil
    Dim OriginalImage As Image
    Dim WorkingImage As Image
    Dim LayerMode As layerType
    Dim DrawingMode As Daqument.EditDaqumentUtil.mode
    Dim CurrentColor As Color
    Dim CurrentWidth As Integer
    Dim BGImage As Image
    Dim MouseIsDown As Boolean = False
    Private theRectangle As New Rectangle(New Point(0, 0), New Size(0, 0))
    Dim Loading As Boolean = True

    'vectors info
    Private VectorIDCtr As Integer = 0
    Private Vectors As New List(Of EditDaqumentUtil.VectorMap)
    Private tmpVectors As New List(Of EditDaqumentUtil.Vector)



    'coordinate info
    Private StartPoint As Point = New Point()
    Private EndPoint As Point = New Point()
    Private LineStartPoint As Point = New Point()
    Private LineEndPoint As Point = New Point()
    Private ScreenOffsetX As Integer = 20
    Private ScreenOffsetY As Integer = 60
    Private PreviousAnchorPoint = New Point(0, 0)


    Private Enum layerType
        Highlite
        Marking
    End Enum


    Public Sub New(ByVal ThisDocument As Integer)
        Me.InitializeComponent()
        DocumentID = ThisDocument
    End Sub


    Private Sub TDraw_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            myDoc = New EditDaqumentUtil(DocumentID)

            pbx_Background.Controls.Add(pbx_Overlay)
            pbx_Overlay.Location = New Point(0, 0)
            pbx_Background.Location = New Point(ScreenOffsetX, ScreenOffsetY)
            pbx_Overlay.Image = myDoc.CurrentImage
            'pbx_Background.Image = pbx_Overlay.Image

            MakeOverlayTransparent()
            'Create_BGIMAGE()
            ResizePageWidth()

            'set default settings
            DrawingMode = EditDaqumentUtil.mode.None
            LayerMode = layerType.Highlite
            CurrentWidth = 10
            CurrentColor = Color.Yellow

            pbx_Background.Refresh()
            Loading = False
        Catch ex As Exception
            Utilities.logErrorMessage("Daqument.TDraw.TDraw_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        LayerMode = layerType.Highlite
        tsb_Colors.BackColor = CurrentColor
        CurrentWidth = 10
        tsb_Thin.Checked = False
        tsb_Normal.Checked = True
        tsb_Thick.Checked = False
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        LayerMode = layerType.Marking
        CurrentColor = Color.Red
        tsb_Colors.BackColor = CurrentColor
        CurrentWidth = 3
        tsb_Thin.Checked = False
        tsb_Normal.Checked = True
        tsb_Thick.Checked = False
    End Sub


    Private Sub tsb_Color1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Color1.Click
        If LayerMode = layerType.Highlite Then
            CurrentColor = Color.Yellow
        ElseIf LayerMode = layerType.Marking Then
            CurrentColor = Color.Red
        End If
        tsb_Colors.BackColor = CurrentColor
    End Sub


    Private Sub tsb_Color2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Color2.Click
        If LayerMode = layerType.Highlite Then
            CurrentColor = Color.PaleTurquoise
        ElseIf LayerMode = layerType.Marking Then
            CurrentColor = Color.Blue
        End If
        tsb_Colors.BackColor = CurrentColor
    End Sub


    Private Sub tsb_Color3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Color3.Click
        If LayerMode = layerType.Highlite Then
            CurrentColor = Color.Violet
        ElseIf LayerMode = layerType.Marking Then
            CurrentColor = Color.Green
        End If
        tsb_Colors.BackColor = CurrentColor
    End Sub


    Private Sub tsb_Thin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Thin.Click
        If LayerMode = layerType.Highlite Then
            CurrentWidth = 5
        ElseIf LayerMode = layerType.Marking Then
            CurrentWidth = 1
        End If
        tsb_Thin.Checked = True
        tsb_Normal.Checked = False
        tsb_Thick.Checked = False
    End Sub

    Private Sub tsb_Normal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Normal.Click
        If LayerMode = layerType.Highlite Then
            CurrentWidth = 10
        ElseIf LayerMode = layerType.Marking Then
            CurrentWidth = 3
        End If
        tsb_Thin.Checked = False
        tsb_Normal.Checked = True
        tsb_Thick.Checked = False
    End Sub

    Private Sub tsb_Thick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Thick.Click
        If LayerMode = layerType.Highlite Then
            CurrentWidth = 15
        ElseIf LayerMode = layerType.Marking Then
            CurrentWidth = 5
        End If
        tsb_Thin.Checked = False
        tsb_Normal.Checked = False
        tsb_Thick.Checked = True
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        DrawingMode = EditDaqumentUtil.mode.None
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        DrawingMode = EditDaqumentUtil.mode.FreeHand
        pbx_Overlay.Cursor = Cursors.Cross
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        DrawingMode = EditDaqumentUtil.mode.lineDraw
        pbx_Overlay.Cursor = Cursors.UpArrow
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        DrawingMode = EditDaqumentUtil.mode.InsertImage
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        DrawingMode = EditDaqumentUtil.mode.Drag
        pbx_Overlay.Cursor = Cursors.NoMove2D
        PreviousAnchorPoint = pbx_Background.Location
    End Sub

    Private Sub cbx_Zoom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_Zoom.LostFocus
        Dim ThisZoom As Double
        ThisZoom = CDbl(cbx_Zoom.Text.Replace("%", "")) / 100
        cbx_Zoom.Text.Replace("%", "")
        cbx_Zoom.Text += "%"
        ResizeDrawingView(ThisZoom, ThisZoom)
    End Sub


    Private Sub cbx_Zoom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_Zoom.SelectedIndexChanged
        If Loading Then Return
        If cbx_Zoom.Text = "Page" Then
            ResizePageWidth()
            Return
        End If
        Dim ThisZoom As Double
        ThisZoom = CDbl(cbx_Zoom.Text.Replace("%", "")) / 100
        ResizeDrawingView(ThisZoom, ThisZoom)
    End Sub


    Private Sub pbx_Overlay_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbx_Overlay.MouseDown
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Dim ScreenPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
        Dim ClientPoint As Point = Me.pbx_Overlay.PointToClient(ScreenPoint)

        StartPoint = e.Location
        tsl_Coordinates.Text = StartPoint.X.ToString + "," + StartPoint.Y.ToString

        If DrawingMode = EditDaqumentUtil.mode.FreeHand Then
            tmpVectors.Clear()
        ElseIf DrawingMode = EditDaqumentUtil.mode.lineDraw Then
            LineStartPoint = New Point(Control.MousePosition.X, Control.MousePosition.Y)
        End If

        Dim newPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
        theRectangle.Location = New Point(newPoint.X, newPoint.Y)
        theRectangle.Size = New Size(0, 0)
        ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)

        tmpVectors.Clear()
        MouseIsDown = True
    End Sub


    Private Sub pbx_Overlay_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbx_Overlay.MouseMove
        Dim myPoint As Point = New Point(e.X, e.Y)
        Dim ScreenPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
        'pbx_Background.Refresh()

        If MouseIsDown Then
            If DrawingMode = EditDaqumentUtil.mode.FreeHand Then
                Dim vec As EditDaqumentUtil.Vector = MakeNewLineVector(StartPoint, e.Location)

                If LayerMode = layerType.Highlite Then
                    vec.ObjectMode = "Highlite"
                ElseIf LayerMode = layerType.Marking Then
                    vec.ObjectMode = "Marking"
                End If

                tmpVectors.Add(vec)
                StartPoint = e.Location
                embedLayerObject(vec)
                pbx_Background.Refresh()

            ElseIf DrawingMode = EditDaqumentUtil.mode.lineDraw Then
                If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
                Dim newPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
                If e.Location.X > 0 And e.Location.Y > 0 Then
                    ControlPaint.DrawReversibleLine(LineStartPoint, Control.MousePosition, Color.Gray)
                    EndPoint = e.Location
                End If
            ElseIf DrawingMode = EditDaqumentUtil.mode.Drag Then
                If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
                Dim picPoint As Point = pbx_Background.Location
                Dim diffX = myPoint.X - StartPoint.X : Dim diffY = myPoint.Y - StartPoint.Y
                pbx_Background.Location = New Point(picPoint.X + diffX, picPoint.Y + diffY)
                ScreenOffsetX = ScreenOffsetX + diffX : ScreenOffsetY = ScreenOffsetY + diffY
                Me.pbx_Background.Refresh()
                'Me.pbx_Overlay.Refresh()
            End If

        End If

        'pbx_Background.Refresh()
    End Sub

    Private Sub pbx_Overlay_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbx_Overlay.MouseUp
        MouseIsDown = False

        If DrawingMode = EditDaqumentUtil.mode.FreeHand Then
            For Each vec As EditDaqumentUtil.Vector In tmpVectors
                Vectors.Add(New EditDaqumentUtil.VectorMap(vec))
            Next
        ElseIf DrawingMode = EditDaqumentUtil.mode.lineDraw And Not (StartPoint.X = e.X And StartPoint.Y = e.Y) Then

            Dim vec As EditDaqumentUtil.Vector = MakeNewLineVector(StartPoint, EndPoint)
            Vectors.Add(New EditDaqumentUtil.VectorMap(vec))
            embedLayerObject(vec)
            pbx_Overlay.Refresh()
            pbx_Background.Refresh()
        ElseIf DrawingMode = EditDaqumentUtil.mode.None Then
            'ClearAllSelectedItems()
            'ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
            'For Each vec As EditDaqumentUtil.VectorMap In Vectors
            '    If theRectangle.Contains(vectorScreenBoundRectangle(vec.thisVector)) Then
            '        AddBoundryBox(vec.thisVector)
            '        vec.itmSelected = True
            '    End If
            'Next
        End If

    End Sub

    'Private Sub pbx_Background_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbx_Background.Paint
    '    Dim g As Graphics = Nothing
    '    g = e.Graphics

    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        If vec.ObjectMode = "Highlite" Then
    '            If Not vec.ObjectDeleted Then

    '                If vec.VectorObjectType = "Text" Then

    '                    If Not vec.pBox.Image Is Nothing Then
    '                        g.DrawImage(vec.pBox.Image, New Point(vec.StartPointX, vec.StartPointY))
    '                    End If

    '                ElseIf vec.VectorObjectType = "Pic" Then

    '                    g.DrawImage(vec.pBox.Image, New Point(vec.StartPointX, vec.StartPointY))

    '                ElseIf vec.VectorObjectType = "Line" Then

    '                    Dim clr As Color = Color.FromArgb(vec.penArgb)

    '                    Dim myPen As Pen = New Pen(New SolidBrush(clr), vec.ScaledlineWidth)
    '                    myPen.EndCap = Drawing2D.LineCap.Round
    '                    Dim StartPoint As Point = New Point(vec.StartPointX, vec.StartPointY)
    '                    Dim EndPoint As Point = New Point(vec.endPointX, vec.endPointY)
    '                    g.DrawLine(myPen, StartPoint, EndPoint)

    '                End If
    '            End If
    '        End If
    '    Next

    'End Sub


    Public Sub embedLayerObject(ByVal vec As EditDaqumentUtil.Vector)
        Dim g As Graphics = Nothing
        If vec.ObjectMode = "Highlite" Then
            g = Graphics.FromImage(Me.pbx_Background.Image)
            'pbx_Background.Refresh()
            Return
            'g = Graphics.FromHwnd(Me.Handle)
            'g = Graphics.FromImage(Me.pbx_Overlay.Image)
        ElseIf vec.ObjectMode = "Marking" Then
            g = Graphics.FromImage(Me.pbx_Overlay.Image)
        End If

        If Not vec.ObjectDeleted Then

            If vec.VectorObjectType = "Text" Then

                If Not vec.pBox.Image Is Nothing Then
                    g.DrawImage(vec.pBox.Image, New Point(vec.StartPointX, vec.StartPointY))
                End If

            ElseIf vec.VectorObjectType = "Pic" Then

                g.DrawImage(vec.pBox.Image, New Point(vec.StartPointX, vec.StartPointY))

            ElseIf vec.VectorObjectType = "Line" Then

                Dim clr As Color = Color.FromArgb(vec.penArgb)
                Dim myPen As Pen = New Pen(New SolidBrush(clr), vec.ScaledLineWidth)
                myPen.EndCap = Drawing2D.LineCap.Round
                Dim StartPoint As Point = New Point(vec.StartPointX, vec.StartPointY)
                Dim EndPoint As Point = New Point(vec.endPointX, vec.endPointY)
                g.DrawLine(myPen, StartPoint, EndPoint)

            End If
        End If

    End Sub

    Private Function MakeNewLineVector(ByVal StartPt As Point, ByVal EndPt As Point) As EditDaqumentUtil.Vector
        Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector
        VectorIDCtr = VectorIDCtr + 1
        myVector.vectorID = VectorIDCtr
        myVector.StartPointX = StartPt.X : myVector.StartPointY = StartPt.Y
        myVector.endPointX = EndPt.X : myVector.endPointY = EndPt.Y
        myVector.OrgStartPointX = StartPt.X : myVector.OrgStartPointY = StartPt.Y
        myVector.OrgEndPointX = EndPt.X : myVector.OrgEndPointY = EndPt.Y
        myVector.DrawingID = DocumentID
        myVector.OrgLineWidth = CurrentWidth
        myVector.ScaledLineWidth = CurrentWidth
        Dim myPen As New Pen(New SolidBrush(CurrentColor), CurrentWidth)
        myPen.EndCap = Drawing2D.LineCap.Flat
        myVector.penArgb = myPen.Color.ToArgb
        myVector.VectorType = DrawingMode
        myVector.lineEnd = myPen.EndCap
        myVector.seqNumber = Vectors.Count + 1
        myVector.ObjectDeleted = False
        myVector.VectorObjectType = "Line"
        myVector.DateCreated = Now
        myVector.ObjectMode = LayerMode
        myVector.OrgScaleX = Convert.ToSingle(pbx_Overlay.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
        myVector.OrgScaleY = Convert.ToSingle(pbx_Overlay.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
        Return myVector
    End Function

    Private Sub ResizePageWidth()
        Dim picSize As Size = New Size(Me.ClientRectangle.Size.Width - 40, Me.ClientRectangle.Size.Height - 100)
        Dim orgSize As Size = myDoc.OriginalDrawingSize
        pbx_Background.Size = picSize
        pbx_Overlay.Size = picSize

        Dim magX As Single = (picSize.Width / orgSize.Width) : Dim magY As Single = (picSize.Height / orgSize.Height)
        ResizeDrawingView(magX, magY)
    End Sub

    Private Function ResizeDrawingView(ByVal MagX As Single, ByVal MagY As Single) As Boolean
        Dim sX As Integer = MagX * myDoc.OriginalDrawingSize.Width
        Dim sY As Integer = magY * myDoc.OriginalDrawingSize.Height
        If (sX * sY) > 20000000 Then
            MessageBox.Show("Not enough memory")
            Return False
        End If
        Dim newSize As Size = New Size(sX, sY)
        If Not pbx_Background.Image Is Nothing Then
            pbx_Background.Image.Dispose()
        End If
        If Not pbx_Overlay.Image Is Nothing Then
            pbx_Overlay.Image.Dispose()
        End If

        pbx_Overlay.Image = myDoc.ResizeImage(newSize)
        'pbx_Background.Image = pbx_Overlay.Image

        'Create_BGIMAGE()
        MakeOverlayTransparent()

        pbx_Background.Size = pbx_Overlay.Image.Size
        pbx_Overlay.Size = pbx_Overlay.Image.Size

        pbx_Overlay.Location = New Point(0, 0)

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            'ClearSelectedBoundryBox(vec)
            RescaleVector(vec, MagX, MagY)
            embedLayerObject(vec.thisVector)
        Next

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            embedLayerObject(vec.thisVector)
        Next

        pbx_Background.Location = New Point(ScreenOffsetX, ScreenOffsetY)
        pbx_Background.Refresh()
        pbx_Overlay.Refresh()

        Return True
    End Function

    Private Sub Create_BGIMAGE()
        BGImage = New Bitmap(pbx_Overlay.Image.Width, pbx_Overlay.Image.Height)
        pbx_Background.Image = BGImage
    End Sub

    Private Sub MakeOverlayTransparent()
        Dim bmp_Image As New Bitmap(pbx_Overlay.Image)
        For i As Integer = 0 To 5
            Dim backColor As Color = Color.FromArgb(255 - i, 255 - i, 255 - i)
            bmp_Image.MakeTransparent(backColor)
        Next

        If Not pbx_Overlay.Image Is Nothing Then
            pbx_Overlay.Image.Dispose()
        End If

        WorkingImage = bmp_Image
        pbx_Overlay.Image = WorkingImage
    End Sub

    Private Sub RescaleVector(ByVal vec As EditDaqumentUtil.VectorMap, ByVal MagX As Single, ByVal MagY As Single)
        Dim newScaleX = MagX / vec.OrgScaleX
        Dim newScaleY = magY / vec.OrgScaleY
        vec.StartPointX = vec.OrgStartPointX * newScaleX
        vec.StartPointY = vec.OrgStartPointY * newScaleY
        Dim newLoc As Point = New Point(vec.StartPointX, vec.StartPointY)
        If vec.VectorObjectType = "Line" Then
            vec.endPointX = vec.OrgEndPointX * newScaleX
            vec.endPointY = vec.OrgEndPointY * newScaleY
            vec.ScaledlineWidth = vec.OrglineWidth * newScaleY
        ElseIf vec.VectorObjectType = "Square" Then
            vec.endPointX = vec.OrgEndPointX * newScaleX
            vec.endPointY = vec.OrgEndPointY * newScaleY
            vec.ScaledlineWidth = vec.OrgLineWidth * newScaleY
        ElseIf vec.VectorObjectType = "Text" Then
            If Not vec.tBox Is Nothing Then
                If vec.tBox.Text > "" Then
                    Dim bm = New Bitmap(vec.tBox.Bounds.Size.Width, vec.tBox.Bounds.Size.Height)
                    Dim picCanvas As Graphics = Graphics.FromImage(bm)
                    picCanvas.FillRectangle(Brushes.White, 0, 0, vec.tBox.Bounds.Size.Width, vec.tBox.Bounds.Size.Height)
                    Dim myBrush As Brush = New SolidBrush(vec.tBox.ForeColor)
                    picCanvas.DrawString(vec.tBox.Text, vec.tBox.Font, myBrush, New Rectangle(New Point(0, 0), vec.tBox.Size))
                    Dim m As New MemoryStream
                    bm.Save(m, ImageFormat.Png)
                    If Not vec.vectorImage Is Nothing Then
                        vec.vectorImage.Dispose()
                    End If
                    'keep original image
                    vec.vectorImage = System.Drawing.Image.FromStream(m)
                    Dim tBoxRatio As Single = CType(vec.tBox.Size.Height, Single) / CType(vec.tBox.Size.Width, Single)
                    Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX) * newScaleX
                    Dim Height As Single = Width * tBoxRatio
                    vec.endPointX = vec.StartPointX + Width
                    vec.endPointY = vec.StartPointY + Height
                    vec.tBox.Location = newLoc
                    If Not vec.pBox.Image Is Nothing Then
                        vec.pBox.Image.Dispose()
                    End If
                    vec.pBox.Image = myDoc.ResizeImage(vec.vectorImage, vectorScreenBoundRectangle(vec.thisVector).Size)
                    vec.tBox.Visible = False
                    vec.VectorType = EditDaqumentUtil.mode.EmbedText
                    vec.itmSelected = False
                End If
            End If
        ElseIf vec.VectorObjectType = "Pic" Then
            If Not vec.pBox Is Nothing Then
                Dim pBoxRatio As Single = CType(vec.pBox.Size.Height, Single) / CType(vec.pBox.Size.Width, Single)
                Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX) * newScaleX
                Dim Height As Single = Width * pBoxRatio
                vec.endPointX = vec.StartPointX + Width
                vec.endPointY = vec.StartPointY + Height
                vec.pBox.Size = vectorScreenBoundRectangle(vec.thisVector).Size
                vec.pBox.Location = newLoc
                Dim img As Image = myDoc.ResizeImage(vec.vectorImage, New Size(Width, Height))
                vec.pBox.Image.Dispose()
                vec.pBox.Image = img
                vec.VectorType = EditDaqumentUtil.mode.EmbedImage
                vec.itmSelected = False
            End If
        ElseIf vec.VectorObjectType = "Overlay" Then
            If Not vec.pBox Is Nothing Then
                Dim pBoxRatio As Single = CType(vec.pBox.Size.Height, Single) / CType(vec.pBox.Size.Width, Single)
                Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX) * newScaleX
                Dim Height As Single = Width * pBoxRatio
                vec.endPointX = vec.StartPointX + Width
                vec.endPointY = vec.StartPointY + Height
                vec.pBox.Size = vectorScreenBoundRectangle(vec.thisVector).Size
                vec.pBox.Location = newLoc
                Dim img As Image = myDoc.ResizeImage(vec.vectorImage, New Size(Width, Height))
                vec.pBox.Image.Dispose()
                vec.pBox.Image = img
                vec.VectorType = EditDaqumentUtil.mode.EmbedImage
                vec.itmSelected = False
            End If
        End If
    End Sub

    Private Function vectorScreenBoundRectangle(ByVal vec As EditDaqumentUtil.Vector) As Rectangle
        Dim Width As Integer = Math.Abs(vec.StartPointX - vec.endPointX)
        Dim Height As Integer = Math.Abs(vec.StartPointY - vec.endPointY)

        Dim vecRectangle As Rectangle = New Rectangle(PointToScreen(New Point(vec.StartPointX + ScreenOffsetX, vec.StartPointY + ScreenOffsetY)), _
                New Size(Width, Height))
        Return vecRectangle
    End Function


    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        pbx_Background.Refresh()

    End Sub

End Class