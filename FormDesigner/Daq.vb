Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing.Imaging
'Imports System.Data.SqlServerCe
Imports System.IO
Imports daqartDLL
Public Class Daq
    Private Action As FormDesigner.FormView.ActionType
    Private image As Image
    Private bmp As Bitmap
    Private startPoint As Point = New Point()
    Private _myForm As FormUtils
    Private CurrentOpaqueValue As Integer
    Private CurrentLineWidth As Integer
    Private Structure Vector
        Dim VectorType As Integer
        Dim StartPointX As Integer
        Dim StartPointY As Integer
        Dim endPointX As Integer
        Dim endPointY As Integer
        Dim lineWidth As Integer
        Dim lineEnd As Integer
        Dim penArgb As Integer
        Dim layer As Integer
        Dim VectorImage As Image
    End Structure
    Private Vectors As New List(Of Vector)
    Private tmpVectors As New List(Of Vector)
    Private VectorCounts As New List(Of Integer)
    Private SelectedBox As New List(Of TextBox)
    Private CurrentVectorPtr As Integer
    Private dragHandleRectangle As Rectangle

    Private VarCtr As Integer
    Private _FormImages As New List(Of Image)
    Private Enum layerType
        Highlite
        Marking
    End Enum
    Private Enum mode
        None
        BoxSelected
        InsertImage
        DragImage
        InsertText
        Drag
        FreeHand
    End Enum
    Dim daqMode As mode = mode.None
    Public Sub New()
        _myForm = New FormUtils(18, 0, 0, "Edit")

        InitializeComponent()
    End Sub
    Private Sub formSubmit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try

            _FormImages = _myForm.FormImages()
            startPoint = New Point(0, 0)
            PictureBox1.Size = _FormImages(0).Size
            bmp = New Bitmap(PictureBox1.Size.Width, PictureBox1.Size.Height)
            PictureBox1.Image = _FormImages(0).Clone
            CurrentOpaqueValue = 255
            btnLineWidth.Image = Global.FormDesigner.My.Resources.Resources.Width1
            CurrentLineWidth = 1
            VarCtr = 0
            CurrentVectorPtr = 0
            ' btnColorChoice.BackColor = Color.FromArgb(CurrentOpaqueValue, 255, 0, 0)
            btnColorChoice.BackColor = Color.FromArgb(100, 0, 255, 0)
            btnColorChoice.Text = "Marking"
            btnDrawOpaque.Checked = True
            PicBox2.Visible = False
            PicBoxDragHandle.Visible = False
            PicBoxDragDrawBoundry.Visible = False
            PicBoxDragXY.Visible = False
            PicBoxDragXLeft.Visible = False
            PicBoxDragXRight.Visible = False
            Dim img As Image = Global.FormDesigner.My.Resources.Resources.move.Clone
            Dim bm = New Bitmap(img)
            Dim backColor As Color = bm.GetPixel(1, 1)
            bm.MakeTransparent(backColor)
            PicBoxDragHandle.Image = bm
        Catch ex As Exception
            Utilities.logErrorMessage("FormDesigner.Daq.FormSubmit_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        startPoint = New Point(e.X, e.Y)
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        If daqMode = mode.FreeHand Then
            tmpVectors.Clear()
        End If
        If daqMode = mode.Drag Then
        End If
        If daqMode = mode.DragImage Then
            PicBoxDragHandle.Location = New Point(startPoint.X + 6, startPoint.Y)
            PicBox2.Location = New Point(startPoint.X + PicBoxDragHandle.Size.Width, startPoint.Y + PicBoxDragHandle.Size.Height)
            Me.PicBox2.Refresh()
            Me.PicBoxDragHandle.Refresh()
            PicBox2.BringToFront()
        End If

    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Dim myPoint As Point = New Point(e.X, e.Y)
        If daqMode = mode.FreeHand Then
            ' To draw an opaque line, set the alpha component of the color to 255
            ' To draw a semitransparent line, set the alpha component to any value from 1 through 254.
            Dim g As Graphics = Graphics.FromImage(Me.PictureBox1.Image)
            Dim myPen As New Pen(New SolidBrush(btnColorChoice.BackColor), CurrentLineWidth)
            myPen.EndCap = LineCap.Flat

            If btnDrawOpaque.Checked Then
                Dim myColor As Color = Color.FromArgb(CurrentOpaqueValue, btnColorChoice.BackColor.R, _
                btnColorChoice.BackColor.G, btnColorChoice.BackColor.B)
                myPen = New Pen(New SolidBrush(myColor), CurrentLineWidth)
                myPen.EndCap = LineCap.Round
            End If
            g.DrawLine(myPen, startPoint, myPoint)

            Dim myVector As Vector = New Vector
            myVector.StartPointX = startPoint.X : myVector.StartPointY = startPoint.Y
            myVector.endPointX = myPoint.X : myVector.endPointY = myPoint.Y
            '        myVector.penAlpha = myPen.Color.A
            '       myVector.penR = myPen.Color.R : myVector.penG = myPen.Color.G : myVector.penB = myPen.Color.B
            myVector.lineWidth = CurrentLineWidth
            myVector.penArgb = myPen.Color.ToArgb
            myVector.VectorType = daqMode
            myVector.lineEnd = myPen.EndCap
            tmpVectors.Add(myVector)
            startPoint = myPoint
            PictureBox1.Refresh()
        End If
        If daqMode = mode.Drag Then
            Dim picPoint As Point = PictureBox1.Location
            Dim diffX = myPoint.X - startPoint.X : Dim diffY = myPoint.Y - startPoint.Y

            PictureBox1.Location = New Point(picPoint.X + diffX, picPoint.Y + diffY)
            Me.PictureBox1.Refresh()
        End If
        If daqMode = mode.DragImage Then
            PicBoxDragDrawBoundry.Location = New Point(myPoint.X + PicBoxDragHandle.Size.Width - 4, myPoint.Y + PicBoxDragHandle.Size.Height - 4)
            PicBoxDragHandle.Location = New Point(myPoint.X + 6, myPoint.Y)
            PicBox2.Location = New Point(myPoint.X + PicBoxDragHandle.Size.Width, myPoint.Y + PicBoxDragHandle.Size.Height)
            Me.PicBox2.Refresh()
            Me.PicBoxDragHandle.Refresh()
            PicBox2.BringToFront()
        End If

    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If daqMode = mode.FreeHand Then
            'Dim myPoint As Point = New Point(e.X, e.Y)
            'ControlPaint.DrawReversibleLine(startPoint, myPoint, Color.Black)
            For Each vec As Vector In tmpVectors
                Vectors.Add(vec)
            Next
            If VectorCounts.Count > 0 Then
                VectorCounts.Add(tmpVectors.Count + VectorCounts(VectorCounts.Count - 1))
            Else
                VectorCounts.Add(tmpVectors.Count - 1)
            End If
            CurrentVectorPtr = VectorCounts.Count

        End If
    End Sub
    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint

    End Sub

    Private Sub btnLineDraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLineDraw.Click
        daqMode = mode.FreeHand
    End Sub

    Private Sub btnDrag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrag.Click
        daqMode = mode.Drag
        PictureBox1.Cursor = Cursors.NoMove2D
    End Sub

    Private Sub zoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles zoomOut.Click
        Using canvas As Graphics = Graphics.FromImage(_FormImages(0))
            canvas.ScaleTransform(_FormImages(0).Size.Width * 0.8, _FormImages(0).Size.Height * 0.8)
        End Using
        Me.PictureBox1.Refresh()
        Me.PictureBox1.Invalidate()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        daqMode = mode.None
        PictureBox1.Cursor = Cursors.Default
    End Sub



    Private Sub btnColorRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorRed.Click
        btnColorChoice.BackColor = Color.FromArgb(100, 255, 0, 0)
    End Sub

    Private Sub btnColorBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorBlue.Click
        btnColorChoice.BackColor = Color.FromArgb(100, 0, 0, 255)

    End Sub

    Private Sub btnColorGreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorGreen.Click
        btnColorChoice.BackColor = Color.FromArgb(100, 0, 255, 0)

    End Sub

    Private Sub btnDrawOpaque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrawOpaque.Click
        If btnDrawOpaque.Checked Then
            btnDrawOpaque.Checked = False
            CurrentOpaqueValue = 1
            btnColorChoice.Text = "Highlite"
        Else
            btnDrawOpaque.Checked = True
            CurrentOpaqueValue = 255
            btnColorChoice.Text = "Marking"
        End If
    End Sub

    Private Sub btnWidth1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth1.Click
        btnLineWidth.Image = Global.FormDesigner.My.Resources.Resources.Width1
        CurrentLineWidth = 1
    End Sub

    Private Sub btnWidth2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth2.Click
        btnLineWidth.Image = Global.FormDesigner.My.Resources.Resources.Width2
        CurrentLineWidth = 2
    End Sub

    Private Sub btnWidth3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth3.Click
        btnLineWidth.Image = Global.FormDesigner.My.Resources.Resources.Width3
        CurrentLineWidth = 4
    End Sub

    Private Sub btnWidth4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth4.Click
        btnLineWidth.Image = Global.FormDesigner.My.Resources.Resources.Width4
        CurrentLineWidth = 8
    End Sub

    Private Sub btnWidth5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth5.Click
        btnLineWidth.Image = Global.FormDesigner.My.Resources.Resources.Width5
        CurrentLineWidth = 15
    End Sub
    Private Sub Redraw()
        PictureBox1.Image.Dispose()
        Me.Invalidate()
        PictureBox1.Image = _FormImages(0).Clone
        If CurrentVectorPtr = 0 Then Return
        Dim g As Graphics = Graphics.FromImage(Me.PictureBox1.Image)
        For i As Integer = 0 To VectorCounts(CurrentVectorPtr - 1)
            'Dim clr As Color = Color.FromArgb(Vectors(i).penAlpha, Vectors(i).penR, Vectors(i).penG, Vectors(i).penB)
            If Vectors(i).VectorType = mode.FreeHand Then
                Dim clr As Color = Color.FromArgb(Vectors(i).penArgb)
                Dim myPen As Pen = New Pen(New SolidBrush(clr), Vectors(i).lineWidth)
                myPen.EndCap = Vectors(i).lineEnd
                Dim startPoint As Point = New Point(Vectors(i).StartPointX, Vectors(i).StartPointY)
                Dim endPoint As Point = New Point(Vectors(i).endPointX, Vectors(i).endPointY)
                g.DrawLine(myPen, startPoint, endPoint)
            End If
            If Vectors(i).VectorType = mode.InsertImage Then
                Dim myLocation As Point = New Point(Vectors(i).StartPointX, Vectors(i).StartPointY)
                Dim bm = New Bitmap(Vectors(i).VectorImage.Width, Vectors(i).VectorImage.Height)
                Using canvas As Graphics = Graphics.FromImage(PictureBox1.Image)
                    If Vectors(i).layer = layerType.Marking Then
                        canvas.DrawImage(Vectors(i).VectorImage, myLocation)
                    Else
                        Using picCanvas As Graphics = Graphics.FromImage(bm)
                            picCanvas.DrawImage(Vectors(i).VectorImage, 0, 0)
                            Dim backColor As Color = bm.GetPixel(1, 1)
                            bm.MakeTransparent(backColor)
                        End Using
                        canvas.DrawImage(bm, myLocation)
                    End If
                End Using
            End If
        Next
    End Sub
    Private Sub btnRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedo.Click
        If CurrentVectorPtr >= VectorCounts.Count Or VectorCounts.Count = 0 Then Return
        CurrentVectorPtr = CurrentVectorPtr + 1
        Redraw()
    End Sub

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        If CurrentVectorPtr <= 0 Then Return
        CurrentVectorPtr = CurrentVectorPtr - 1
        Redraw()

    End Sub
    Private Sub OLDMakeDragHandleImage()
        System.Windows.Forms.Cursor.Current = Cursors.SizeAll
        dragHandleRectangle = New Rectangle(0, 0, Cursor.Size.Width - 10, Cursor.Size.Height - 10)
        Using CursorImage As Bitmap = New Bitmap(dragHandleRectangle.Width, dragHandleRectangle.Height, PixelFormat.Format24bppRgb)
            Using canvas As Graphics = Graphics.FromImage(CursorImage)
                canvas.FillRectangle(Brushes.White, dragHandleRectangle)
                Cursor.Current.Draw(canvas, dragHandleRectangle)
                'Dim m As New MemoryStream
                'CursorImage.Save(m, ImageFormat.Jpeg)
                'DragHandleImg = System.Drawing.Image.FromStream(m)
            End Using
        End Using
    End Sub


    Private Sub btnInsertImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertImage.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "Image files (*.bmp)|*.bmp|(*.png)|*.png|(*.jpg)|*.jpg|(*.*)|*.*"
        openFileDialog1.FilterIndex = 1

        If openFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        PicBox2.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName)
        If PicBox2.Image.Size.Height = 0 Or PicBox2.Image.Size.Width = 0 Then Return
        If PicBox2.Image.Size.Height >= PictureBox1.Image.Size.Height Then Return
        If PicBox2.Image.Size.Width >= PictureBox1.Image.Size.Width Then Return
        PicBox2.Size = PicBox2.Image.Size
        PicBox2.Visible = True
        PicBox2.Location = New Point(0 + PicBoxDragHandle.Width, 0 + PicBoxDragHandle.Height)
        PicBoxDragHandle.Visible = True
        PicBoxDragHandle.Location = New Point(6, 0)
        PicBoxDragDrawBoundry.Size = New Size(PicBox2.Size.Width + 8, PicBox2.Size.Height + 8)
        Dim bm As New Bitmap(PicBoxDragDrawBoundry.Size.Width, PicBoxDragDrawBoundry.Size.Height)
        Dim canvas As Graphics = Graphics.FromImage(bm)
        Dim myPen As Pen = New Pen(New SolidBrush(Color.Black), 6)
        canvas.DrawRectangle(myPen, 0, 0, PicBoxDragDrawBoundry.Size.Width, PicBoxDragDrawBoundry.Size.Height)
        PicBoxDragDrawBoundry.Image = bm
        PicBoxDragDrawBoundry.Location = New Point(PicBox2.Location.X - 4, PicBox2.Location.Y - 4)
        PicBoxDragDrawBoundry.Visible = True
        PictureBox1.Controls.Add(PicBox2)
        PictureBox1.Controls.Add(PicBoxDragDrawBoundry)
        PictureBox1.Controls.Add(PicBoxDragHandle)

        PicBox2.BringToFront()
        '        PicBoxDragHandle.BringToFront()

        daqMode = mode.InsertImage
        '        Cursor.Position = PictureBox1.Location
        '       PictureBox1.Cursor = Cursors.NoMove2D
    End Sub

    Private Sub PicBox2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicBox2.DoubleClick
        If daqMode = mode.InsertImage Or daqMode = mode.DragImage Then
            Dim bm = New Bitmap(PicBox2.Image.Width, PicBox2.Image.Height)
            Using canvas As Graphics = Graphics.FromImage(PictureBox1.Image)
                If btnDrawOpaque.Checked Then
                    canvas.DrawImage(PicBox2.Image, PicBox2.Location)
                Else
                    Using picCanvas As Graphics = Graphics.FromImage(bm)
                        picCanvas.DrawImage(PicBox2.Image, 0, 0)
                        Dim backColor As Color = bm.GetPixel(1, 1)
                        bm.MakeTransparent(backColor)
                    End Using
                    canvas.DrawImage(bm, PicBox2.Location)
                End If
            End Using
            Dim myVector As Vector = New Vector
            myVector.StartPointX = PicBox2.Location.X : myVector.StartPointY = PicBox2.Location.Y
            myVector.endPointX = PicBox2.Location.X + PicBox2.Width : myVector.endPointY = PicBox2.Location.Y + PicBox2.Height
            myVector.VectorType = mode.InsertImage
            myVector.VectorImage = PicBox2.Image.Clone
            myVector.layer = IIf(btnDrawOpaque.Checked, layerType.Marking, layerType.Highlite)


            Vectors.Add(myVector)
            If VectorCounts.Count > 0 Then
                VectorCounts.Add(VectorCounts(VectorCounts.Count - 1) + 1)
            Else
                VectorCounts.Add(0)
            End If
            CurrentVectorPtr = VectorCounts.Count
            PicBox2.Visible = False
            PicBoxDragHandle.Visible = False
            PicBoxDragDrawBoundry.Visible = False
            daqMode = mode.None
            PictureBox1.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnInsertText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertText.Click
        If daqMode = mode.None Then
            daqMode = mode.InsertText
            Dim MyParent As FormMain = Me.ParentForm
            'Me.dwgPanel.Cursor.Current = Cursors.Cross
            Dim mBox = New TextBox()
            mBox.Name = "Field_" + VarCtr.ToString
            '            Panel1.Controls.Add(mBox)
            'mBox.Font = MyParent.FontSelect.Font
            mBox.Text = ""
            mBox.BringToFront()
            '            mBox.BackColor = MyParent.BkColor.BackColor
            SelectedBox.Clear()
            SelectedBox.Add(mBox)
            VarCtr = VarCtr + 1
            PictureBox1.Cursor = Cursors.Cross
            '            Me.Controls.Add(mBox)
            '                Me.Panel1.DoDragDrop(mBox, DragDropEffects.All)
            'Me.DoDragDrop(Me.Button1, DragDropEffects.All)
        End If
    End Sub
    Private Sub TextBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mBox As TextBox = sender
        Dim bm = New Bitmap(mBox.Bounds.Size.Width, mBox.Bounds.Size.Height)
        Dim picCanvas As Graphics = Graphics.FromImage(bm)
        Dim myBrush As Brush = New SolidBrush(mBox.ForeColor)
        picCanvas.DrawString(mBox.Text, mBox.Font, myBrush, 0, 0)
        If Not btnDrawOpaque.Checked Then
            bm.MakeTransparent(Color.White)
        End If
        Dim canvas As Graphics = Graphics.FromImage(PictureBox1.Image)
        canvas.DrawImage(bm, mBox.Bounds.Location)
        PictureBox1.Cursor = Cursors.Default
        mBox.Dispose()
    End Sub
    Private Sub AddTextBox(ByVal mBox As TextBox)
        If daqMode = mode.InsertText Then
            AddHandler mBox.DoubleClick, AddressOf TextBox1_DoubleClick
            PictureBox1.Controls.Add(mBox)
            mBox.BringToFront()
            '    Me.Invalidate() 
        End If
    End Sub

    Private Sub PictureBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        If daqMode = mode.InsertText Then
            '    mBox.Location = Me.Panel1.PointToClient(New Point(e.X, e.Y))
            For Each mbox As TextBox In SelectedBox
                mbox.Location = New Point(e.X, e.Y)
                AddTextBox(mbox)
            Next
        End If
    End Sub

    Private Sub PicBoxDragHandle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicBoxDragHandle.Click
        If daqMode = mode.InsertImage Then
            daqMode = mode.DragImage
            PictureBox1.Cursor = Cursors.NoMove2D
        End If
    End Sub
End Class