Imports System.Drawing.Imaging
Imports System.Drawing.Printing
'Imports System.Collections
Imports System.IO
Imports System.Data.SqlClient
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraVerticalGrid
'Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.Utils


Public Class tlb_EditDaqument

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    'Private printDoc As PrintDocument = New PrintDocument()
    Private printDialog As PrintPreviewDialog
    Private intPageCounter As Integer
    Private PreviousAnchorPoint = New Point(0, 0)
    Private cms1Loc As Point = New Point(0, 0)
    'Private image As Image
    'Private bmp As Bitmap
    Private ScreenOffsetX As Integer = 20
    Private ScreenOffsetY As Integer = 60
    Private localStartPoint As Point = New Point()
    Private dragHandleStartPoint As Point = New Point()
    Private dragStartPoint As Point = New Point()
    Private dragEndPoint As Point = New Point()
    Private theRectangle As New Rectangle(New Point(0, 0), New Size(0, 0))
    Private lineStartPoint As Point = New Point()
    Private VectorIDCtr As Integer = 0
    Private lineEndPoint As Point = New Point()
    Private myDoc As EditDaqumentUtil
    Private PictureBox1ImageCopy As Image
    '    Private CurrentOpaqueValue As Integer
    Private CurrentLineWidth As Integer
    Private Vectors As New List(Of EditDaqumentUtil.VectorMap)
    Private BoundryBox As New List(Of PictureBox)
    '    Private Magnification As Single = 1
    Private tmpVectors As New List(Of EditDaqumentUtil.Vector)

    'Public Structure SeqControl
    '    Dim seqNumber As Integer
    '    Dim Ctrl As Control
    '    Dim vecID As Integer
    'End Structure

    'Private tmpControls As New List(Of SeqControl)
    'Private dragHandleRectangle As Rectangle

    ''    Private VarCtr As Integer
    'Private _PrintImages As New List(Of Image)
    'Private Enum layerType
    '    Highlite
    '    Marking
    'End Enum
    'Dim daqMode As EditDaqumentUtil.mode = EditDaqumentUtil.mode.None
    'Public Shared DocumentID As Integer
    'Public Sub New(ByVal ThisDocument As Integer)
    '    Me.InitializeComponent()
    '    DocumentID = ThisDocument
    'End Sub
    'Private Sub AddLayerTitles()
    '    btnViewLayers.DropDownItems.Clear()
    '    Dim infoTbl As DataTable = myDoc.LayerInfoTbl
    '    For i As Integer = 0 To infoTbl.Rows.Count - 1
    '        btnViewLayers.DropDownItems.Add(infoTbl.Rows(i)(1))
    '        Dim thisItem As ToolStripMenuItem = Me.btnViewLayers.DropDownItems(i)
    '        thisItem.CheckOnClick = True
    '    Next
    'End Sub
    'Private Sub EditDaqument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Try
    '        myDoc = New EditDaqumentUtil(DocumentID)

    '        Dim thisItem As ToolStripMenuItem = Me.btnViewLayers.DropDownItems(0)
    '        thisItem.Checked = True

    '        localStartPoint = New Point(0, 0)
    '        'Dim picSize = New Size(Me.ClientRectangle.Size.Width - 40, Me.ClientRectangle.Size.Height - 100)
    '        'PictureBox1.Size = picSize
    '        'PictureBox1.Image = myDoc.ResizeImage(PictureBox1.Size)
    '        ResizePageWidth()
    '        btnMarking.Checked = False
    '        btnColorChoice.Text = "Hilite"
    '        btnHiliting.Checked = True
    '        Dim myBackColor As Color = Color.FromArgb(80, 255, 0, 0)
    '        btnColorChoice.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)
    '        btnColorChoice.BackColor = myBackColor

    '        btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width1
    '        CurrentLineWidth = 1
    '        PicBox2.Visible = False
    '        picBoxDragHandle.Visible = False
    '        PictureBox1.Controls.Add(picBoxDragHandle)

    '        'pbx_Overlay.Controls.Add(picBoxDragHandle) 'tlb

    '        printDoc.DocumentName = "Printing Documents"
    '        AddHandler printDoc.BeginPrint, AddressOf printDoc_BeginPrint
    '        AddHandler printDoc.EndPrint, AddressOf printDoc_EndPrint
    '        AddHandler printDoc.PrintPage, AddressOf printDoc_PrintPage
    '        PictureBox1.Refresh()
    '        'pbx_Overlay.Refresh() 'tlb


    '        AddLayerTitles()
    '        '            Dim myLayerInfo As New Daqument.DcomentLayer(myDoc)
    '        '           myLayerInfo.Show()


    '        MakeNewOverlayVector() 'tlb
    '    Catch ex As Exception
    '        Utilities.logErrorMessage("Daqument.tlb_EditDaqument_Load-" + ex.Message)
    '        MessageBox.Show(ex.Message)
    '    End Try


    'End Sub

    'Public Sub embedLayerObject(ByVal vec As EditDaqumentUtil.Vector)
    '    Dim g As Graphics = Graphics.FromImage(Me.PictureBox1.Image)

    '    If Not vec.ObjectDeleted Then

    '        If vec.VectorObjectType = "Text" Then

    '            If Not vec.pBox.Image Is Nothing Then
    '                g.DrawImage(vec.pBox.Image, New Point(vec.StartPointX, vec.StartPointY))
    '            End If

    '        ElseIf vec.VectorObjectType = "Pic" Then

    '            g.DrawImage(vec.pBox.Image, New Point(vec.StartPointX, vec.StartPointY))

    '        ElseIf vec.VectorObjectType = "Line" Then

    '            Dim clr As Color = Color.FromArgb(vec.penArgb)
    '            Dim myPen As Pen = New Pen(New SolidBrush(clr), vec.ScaledLineWidth)
    '            myPen.EndCap = vec.lineEnd
    '            'set the line join property
    '            myPen.LineJoin = Drawing2D.LineJoin.Round
    '            Dim startPoint As Point = New Point(vec.StartPointX, vec.StartPointY)
    '            Dim endPoint As Point = New Point(vec.endPointX, vec.endPointY)
    '            g.DrawLine(myPen, startPoint, endPoint)

    '        ElseIf vec.VectorObjectType = "Square" Then

    '            Dim clr As Color = Color.FromArgb(vec.penArgb)
    '            Dim myPen As Pen = New Pen(New SolidBrush(clr), vec.ScaledLineWidth)
    '            myPen.EndCap = vec.lineEnd
    '            Dim startPoint As Point = New Point(vec.StartPointX, vec.StartPointY)
    '            'Dim endPoint As Point = New Point(vec.endPointX, vec.endPointY)
    '            Dim rect As New Rectangle(vec.StartPointX, vec.StartPointY, CurrentLineWidth, CurrentLineWidth)
    '            g.DrawRectangle(myPen, rect)

    '        End If

    '    End If


    'End Sub
    'Private Sub RescaleVector(ByVal vec As EditDaqumentUtil.VectorMap, ByVal MagX As Single, ByVal MagY As Single)
    '    Dim newScaleX = MagX / vec.OrgScaleX
    '    Dim newScaleY = magY / vec.OrgScaleY
    '    vec.StartPointX = vec.OrgStartPointX * newScaleX
    '    vec.StartPointY = vec.OrgStartPointY * newScaleY
    '    Dim newLoc As Point = New Point(vec.StartPointX, vec.StartPointY)
    '    If vec.VectorObjectType = "Line" Then
    '        vec.endPointX = vec.OrgEndPointX * newScaleX
    '        vec.endPointY = vec.OrgEndPointY * newScaleY
    '        vec.ScaledlineWidth = vec.OrglineWidth * newScaleY
    '    ElseIf vec.VectorObjectType = "Square" Then
    '        vec.endPointX = vec.OrgEndPointX * newScaleX
    '        vec.endPointY = vec.OrgEndPointY * newScaleY
    '        vec.ScaledlineWidth = vec.OrgLineWidth * newScaleY
    '    ElseIf vec.VectorObjectType = "Text" Then
    '        If Not vec.tBox Is Nothing Then
    '            If vec.tBox.Text > "" Then
    '                Dim bm = New Bitmap(vec.tBox.Bounds.Size.Width, vec.tBox.Bounds.Size.Height)
    '                Dim picCanvas As Graphics = Graphics.FromImage(bm)
    '                picCanvas.FillRectangle(Brushes.White, 0, 0, vec.tBox.Bounds.Size.Width, vec.tBox.Bounds.Size.Height)
    '                Dim myBrush As Brush = New SolidBrush(vec.tBox.ForeColor)
    '                picCanvas.DrawString(vec.tBox.Text, vec.tBox.Font, myBrush, New Rectangle(New Point(0, 0), vec.tBox.Size))
    '                Dim m As New MemoryStream
    '                bm.Save(m, ImageFormat.Png)
    '                If Not vec.vectorImage Is Nothing Then
    '                    vec.vectorImage.Dispose()
    '                End If
    '                'keep original image
    '                vec.vectorImage = System.Drawing.Image.FromStream(m)
    '                Dim tBoxRatio As Single = CType(vec.tBox.Size.Height, Single) / CType(vec.tBox.Size.Width, Single)
    '                Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX) * newScaleX
    '                Dim Height As Single = Width * tBoxRatio
    '                vec.endPointX = vec.StartPointX + Width
    '                vec.endPointY = vec.StartPointY + Height
    '                vec.tBox.Location = newLoc
    '                If Not vec.pBox.Image Is Nothing Then
    '                    vec.pBox.Image.Dispose()
    '                End If
    '                vec.pBox.Image = myDoc.ResizeImage(vec.vectorImage, vectorScreenBoundRectangle(vec.thisVector).Size)
    '                vec.tBox.Visible = False
    '                vec.VectorType = EditDaqumentUtil.mode.EmbedText
    '                vec.itmSelected = False
    '            End If
    '        End If
    '    ElseIf vec.VectorObjectType = "Pic" Then
    '        If Not vec.pBox Is Nothing Then
    '            Dim pBoxRatio As Single = CType(vec.pBox.Size.Height, Single) / CType(vec.pBox.Size.Width, Single)
    '            Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX) * newScaleX
    '            Dim Height As Single = Width * pBoxRatio
    '            vec.endPointX = vec.StartPointX + Width
    '            vec.endPointY = vec.StartPointY + Height
    '            vec.pBox.Size = vectorScreenBoundRectangle(vec.thisVector).Size
    '            vec.pBox.Location = newLoc
    '            Dim img As Image = myDoc.ResizeImage(vec.vectorImage, New Size(Width, Height))
    '            vec.pBox.Image.Dispose()
    '            vec.pBox.Image = img
    '            vec.VectorType = EditDaqumentUtil.mode.EmbedImage
    '            vec.itmSelected = False
    '        End If
    '    ElseIf vec.VectorObjectType = "Overlay" Then
    '        If Not vec.pBox Is Nothing Then
    '            Dim pBoxRatio As Single = CType(vec.pBox.Size.Height, Single) / CType(vec.pBox.Size.Width, Single)
    '            Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX) * newScaleX
    '            Dim Height As Single = Width * pBoxRatio
    '            vec.endPointX = vec.StartPointX + Width
    '            vec.endPointY = vec.StartPointY + Height
    '            vec.pBox.Size = vectorScreenBoundRectangle(vec.thisVector).Size
    '            vec.pBox.Location = newLoc
    '            Dim img As Image = myDoc.ResizeImage(vec.vectorImage, New Size(Width, Height))
    '            vec.pBox.Image.Dispose()
    '            vec.pBox.Image = img
    '            vec.VectorType = EditDaqumentUtil.mode.EmbedImage
    '            vec.itmSelected = False
    '        End If
    '    End If
    'End Sub
    'Private Function ResizeDrawingView(ByVal MagX As Single, ByVal MagY As Single) As Boolean
    '    Dim sX As Integer = MagX * myDoc.OriginalDrawingSize.Width
    '    Dim sY As Integer = magY * myDoc.OriginalDrawingSize.Height
    '    If (sX * sY) > 20000000 Then
    '        MessageBox.Show("Not enough memory")
    '        Return False
    '    End If
    '    Dim newSize As Size = New Size(sX, sY)
    '    If Not PictureBox1.Image Is Nothing Then
    '        PictureBox1.Image.Dispose()
    '    End If
    '    If Not PictureBox1.Image Is Nothing Then 'tlb
    '        PictureBox1.Image.Dispose()
    '    End If
    '    PictureBox1.Image = myDoc.ResizeImage(newSize)
    '    'pbx_Overlay.Image = myDoc.ResizeImage(newSize)

    '    If Not PictureBox1ImageCopy Is Nothing Then
    '        PictureBox1ImageCopy.Dispose()
    '    End If
    '    'PictureBox1ImageCopy = PictureBox1.Image.Clone
    '    PictureBox1.Size = PictureBox1.Image.Size

    '    PictureBox1ImageCopy = PictureBox1.Image.Clone
    '    'pbx_Overlay.Size = pbx_Overlay.Image.Size

    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        ClearSelectedBoundryBox(vec)
    '        RescaleVector(vec, MagX, MagY)
    '        embedLayerObject(vec.thisVector)
    '    Next
    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        'embedLayerObject(vec.thisVector)
    '    Next
    '    PictureBox1.Location = New Point(ScreenOffsetX, ScreenOffsetY)
    '    'pbx_Overlay.Location = New Point(ScreenOffsetX, ScreenOffsetY)
    '    PictureBox1.Refresh()
    '    'pbx_Overlay.Refresh()

    '    Return True
    'End Function
    'Private Sub ComputDragLocation(ByVal sender As System.Object, ByVal vec As EditDaqumentUtil.VectorMap)
    '    Dim dragX = Control.MousePosition.X - dragStartPoint.X
    '    Dim dragY = Control.MousePosition.Y - dragStartPoint.Y
    '    Dim W = Math.Abs(vec.StartPointX - vec.endPointX) : Dim H = Math.Abs(vec.StartPointY - vec.endPointY)
    '    Dim X = vec.StartPointX : Dim Y = vec.StartPointY
    '    ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
    '    Dim myControl As Control = sender
    '    Dim picPosition As String = Split(myControl.Name, "-")(2)
    '    If picPosition = "0" Then
    '        vec.StartPointX = vec.StartPointX + dragX : vec.StartPointY = vec.StartPointY + dragY
    '        vec.endPointX = vec.endPointX + dragX : vec.endPointY = vec.endPointY + dragY
    '        vec.OrgStartPointX = vec.StartPointX : vec.OrgStartPointY = vec.StartPointY
    '        vec.OrgEndPointX = vec.endPointX : vec.OrgEndPointY = vec.endPointY
    '        dragStartPoint = Control.MousePosition
    '        ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
    '        Return
    '    ElseIf picPosition = "1" Then
    '        Y = Y + dragY : H = H - dragY
    '        PictureBox1.Cursor = Cursors.SizeNS
    '    ElseIf picPosition = "2" Then
    '        Y = Y + dragY : H = H - dragY : W = W - dragY
    '        PictureBox1.Cursor = Cursors.SizeNESW
    '    ElseIf picPosition = "3" Then
    '        X = X + dragX : W = W - dragX
    '        PictureBox1.Cursor = Cursors.SizeWE
    '    ElseIf picPosition = "4" Then
    '        W = W + dragX
    '        PictureBox1.Cursor = Cursors.SizeWE
    '    ElseIf picPosition = "5" Then
    '        X = X + dragX : H = H + dragY : W = W - dragX
    '        PictureBox1.Cursor = Cursors.SizeNESW
    '    ElseIf picPosition = "6" Then
    '        H = H + dragY
    '        PictureBox1.Cursor = Cursors.SizeNS
    '    ElseIf picPosition = "7" Then
    '        H = H + dragY : W = W + dragY
    '        PictureBox1.Cursor = Cursors.SizeNWSE
    '    End If
    '    If H > 4 And W > 4 Then
    '        vec.StartPointX = X : vec.StartPointY = Y
    '        vec.endPointX = vec.endPointX + dragX : vec.endPointY = vec.endPointY + dragY
    '        vec.OrgStartPointX = vec.StartPointX : vec.OrgStartPointY = vec.StartPointY
    '        vec.OrgEndPointX = vec.endPointX : vec.OrgEndPointY = vec.endPointY
    '    End If
    '    dragStartPoint = Control.MousePosition
    '    ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)

    'End Sub
    'Private Sub MakeTextImage(ByVal vec As EditDaqumentUtil.VectorMap)
    '    Dim bm = New Bitmap(vec.tBox.Bounds.Size.Width, vec.tBox.Bounds.Size.Height)
    '    Dim picCanvas As Graphics = Graphics.FromImage(bm)
    '    picCanvas.FillRectangle(Brushes.White, 0, 0, vec.tBox.Bounds.Size.Width, vec.tBox.Bounds.Size.Height)
    '    Dim myBrush As Brush = New SolidBrush(vec.tBox.ForeColor)

    '    Dim tSize = TextRenderer.MeasureText(vec.tBox.Text, vec.tBox.Font)


    '    '        TextRenderer.DrawText(picCanvas, vec.tBox.Text, vec.tBox.Font, _
    '    '       New Rectangle(New Point(0, 0), vec.tBox.Size), SystemColors.ControlText, Color.AliceBlue, TextFormatFlags.SingleLine)

    '    'picCanvas.DrawString(vec.tBox.Text, vec.tBox.Font, myBrush, 0, 0)
    '    picCanvas.DrawString(vec.tBox.Text, vec.tBox.Font, myBrush, New Rectangle(New Point(0, 0), vec.tBox.Size))

    '    Dim currentScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
    '    Dim currentScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
    '    Dim newScaleX = currentScaleX / vec.OrgScaleX
    '    Dim newScaleY = currentScaleY / vec.OrgScaleY
    '    Dim m As New MemoryStream
    '    bm.Save(m, ImageFormat.Png)
    '    If Not vec.vectorImage Is Nothing Then
    '        vec.vectorImage.Dispose()
    '    End If
    '    'keep original image
    '    vec.vectorImage = System.Drawing.Image.FromStream(m)

    '    'keep the resize image
    '    If Not vec.pBox.Image Is Nothing Then
    '        vec.pBox.Image.Dispose()
    '    End If
    '    vec.pBox.Image = myDoc.ResizeImage(vec.vectorImage, New Size(vec.tBox.Bounds.Size.Width * newScaleX, vec.tBox.Bounds.Size.Height * newScaleY))
    'End Sub
    'Private Sub ResizePageWidth()
    '    Dim picSize As Size = New Size(Me.ClientRectangle.Size.Width - 40, Me.ClientRectangle.Size.Height - 100)
    '    Dim orgSize As Size = myDoc.OriginalDrawingSize
    '    PictureBox1.Size = picSize
    '    'pbx_Overlay.Size = picSize 'tlb

    '    Dim magX As Single = (picSize.Width / orgSize.Width) : Dim magY As Single = (picSize.Height / orgSize.Height)
    '    If ResizeDrawingView(magX, magY) Then
    '        Me.btnMaginfy.Text = String.Format("{0}%", CType((magX * 100), Integer))
    '    End If
    'End Sub
    'Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
    '    If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
    '    Dim ScreenPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
    '    Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)

    '    localStartPoint = New Point(e.X, e.Y)
    '    If daqMode = EditDaqumentUtil.mode.FreeHand Then
    '        tmpVectors.Clear()
    '    ElseIf daqMode = EditDaqumentUtil.mode.lineDraw Then

    '        lineStartPoint = New Point(Control.MousePosition.X, Control.MousePosition.Y)
    '        lineEndPoint = lineStartPoint
    '        tmpVectors.Clear()

    '    ElseIf daqMode = EditDaqumentUtil.mode.InsertText Then
    '        picBoxDragHandle.Visible = False
    '        MakeNewTextBoxVector(ClientPoint)
    '        daqMode = EditDaqumentUtil.mode.ObjectSelected
    '        PictureBox1.Cursor = Cursors.Default
    '    ElseIf daqMode = EditDaqumentUtil.mode.InsertImage Then
    '        picBoxDragHandle.Visible = False
    '        MakeNewPictureImageVector(ClientPoint)
    '        daqMode = EditDaqumentUtil.mode.ObjectSelected
    '        PictureBox1.Cursor = Cursors.Default
    '    End If
    '    Dim newPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
    '    theRectangle.Location = New Point(newPoint.X, newPoint.Y)
    '    theRectangle.Size = New Size(0, 0)
    '    ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)


    'End Sub
    'Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
    '    Dim myPoint As Point = New Point(e.X, e.Y)
    '    Dim ScreenPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
    '    '        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)

    '    If daqMode = EditDaqumentUtil.mode.FreeHand Then

    '        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return

    '        If CurrentLineWidth > 2 Then

    '            Dim vec As EditDaqumentUtil.Vector = MakeNewSquareVector(myPoint)
    '            tmpVectors.Add(vec)
    '            'localStartPoint = myPoint
    '            embedLayerObject(vec)

    '        Else
    '            Dim vec As EditDaqumentUtil.Vector = MakeNewLineVector(localStartPoint, myPoint)
    '            tmpVectors.Add(vec)
    '            localStartPoint = myPoint
    '            embedLayerObject(vec)
    '        End If

    '        PictureBox1.Refresh()


    '    ElseIf daqMode = EditDaqumentUtil.mode.Drag Then
    '        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
    '        Dim picPoint As Point = PictureBox1.Location
    '        Dim diffX = myPoint.X - localStartPoint.X : Dim diffY = myPoint.Y - localStartPoint.Y
    '        PictureBox1.Location = New Point(picPoint.X + diffX, picPoint.Y + diffY)
    '        ScreenOffsetX = ScreenOffsetX + diffX : ScreenOffsetY = ScreenOffsetY + diffY
    '        Me.PictureBox1.Refresh()
    '    ElseIf daqMode = EditDaqumentUtil.mode.lineDraw Then
    '        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
    '        Dim newPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
    '        If myPoint.X > 0 And myPoint.Y > 0 Then
    '            ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
    '            lineEndPoint = newPoint
    '            ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
    '        End If
    '    ElseIf daqMode = EditDaqumentUtil.mode.None Then
    '        If (e.Button = System.Windows.Forms.MouseButtons.Left) Then
    '            'ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
    '            Dim newPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
    '            If theRectangle.X = 0 Then
    '                theRectangle.Location = New Point(newPoint.X, newPoint.Y)
    '            Else
    '                Dim myWidth = newPoint.X - theRectangle.X : Dim myHeight = newPoint.Y - theRectangle.Y
    '                theRectangle.Size = New Size(Math.Abs(myWidth), Math.Abs(myHeight))
    '            End If
    '            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)

    '            PictureBox1.Refresh()
    '        End If
    '    ElseIf daqMode = EditDaqumentUtil.mode.InsertText Then
    '        picBoxDragHandle.Visible = True
    '        picBoxDragHandle.Location = New Point(e.X + 5, e.Y + 5)
    '    ElseIf daqMode = EditDaqumentUtil.mode.InsertImage Then
    '        picBoxDragHandle.Visible = True
    '        picBoxDragHandle.Location = New Point(e.X + 5, e.Y + 5)
    '    End If

    'End Sub

    'Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
    '    If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
    '    Dim ScreenPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
    '    Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)
    '    If daqMode = EditDaqumentUtil.mode.FreeHand Then
    '        For Each vec As EditDaqumentUtil.Vector In tmpVectors
    '            Vectors.Add(New EditDaqumentUtil.VectorMap(vec))
    '        Next
    '    ElseIf daqMode = EditDaqumentUtil.mode.lineDraw And Not (localStartPoint.X = e.X And localStartPoint.Y = e.Y) Then
    '        ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
    '        Dim vec As EditDaqumentUtil.Vector = MakeNewLineVector(localStartPoint, e.Location)
    '        Vectors.Add(New EditDaqumentUtil.VectorMap(vec))
    '        embedLayerObject(vec)
    '        PictureBox1.Refresh()
    '    ElseIf daqMode = EditDaqumentUtil.mode.None Then
    '        ClearAllSelectedItems()
    '        ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
    '        For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '            If theRectangle.Contains(vectorScreenBoundRectangle(vec.thisVector)) Then
    '                AddBoundryBox(vec.thisVector)
    '                vec.itmSelected = True
    '            End If
    '        Next
    '    End If
    'End Sub
    'Private Sub PictureBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
    '    If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
    '    Dim ScreenPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
    '    Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)
    '    If daqMode = EditDaqumentUtil.mode.lineDraw _
    '        Or daqMode = EditDaqumentUtil.mode.FreeHand _
    '        Or daqMode = EditDaqumentUtil.mode.Drag Then
    '        Return
    '    End If


    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        If Not vec.ObjectDeleted Then
    '            'Dim vecHeight As Integer = Math.Abs(vec.StartPointY - vec.endPointY)
    '            'Dim vecWidth As Integer = Math.Abs(vec.StartPointX - vec.endPointX)
    '            'Dim vecRect As Rectangle = New Rectangle(PointToScreen(New Point(vec.StartPointX, vec.StartPointY)), _
    '            '        New Size(vecWidth, vecHeight))
    '            If vectorScreenBoundRectangle(vec.thisVector).Contains(ScreenPoint) Then
    '                If vec.VectorType = EditDaqumentUtil.mode.EmbedText Then
    '                    daqMode = EditDaqumentUtil.mode.ObjectSelected
    '                    vec.VectorType = EditDaqumentUtil.mode.InsertText
    '                    vec.itmSelected = True
    '                    vec.tBox.Visible = True
    '                    'Redraw()
    '                    AddBoundryBox(vec.thisVector)
    '                    Exit Sub
    '                ElseIf vec.VectorType = EditDaqumentUtil.mode.EmbedImage Then
    '                    daqMode = EditDaqumentUtil.mode.ObjectSelected
    '                    '        vec.VectorType = EditDaqumentUtil.mode.InsertImage
    '                    vec.itmSelected = True
    '                    'vec.pBox.Visible = True
    '                    'Redraw()
    '                    AddBoundryBox(vec.thisVector)
    '                    Exit Sub
    '                End If
    '            End If

    '        End If
    '    Next
    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        If vec.itmSelected Then
    '            If vec.VectorObjectType = "Pic" Then
    '                ClearSelectedBoundryBox(vec)
    '                vec.pBox.Visible = False
    '                vec.itmSelected = False
    '                embedLayerObject(vec.thisVector)


    '            ElseIf vec.VectorObjectType = "Text" Then
    '                If vec.tBox.Text > "" Then
    '                    MakeTextImage(vec)
    '                    vec.VectorType = EditDaqumentUtil.mode.EmbedText
    '                    vec.tBox.Visible = False
    '                    vec.itmSelected = False
    '                    embedLayerObject(vec.thisVector)
    '                    ClearSelectedBoundryBox(vec)
    '                End If
    '            End If
    '        End If
    '    Next

    '    PictureBox1.Refresh()
    'End Sub
    'Private Sub Redraw()
    '    If Not PictureBox1.Image Is Nothing Then
    '        PictureBox1.Image.Dispose()
    '    End If
    '    PictureBox1.Image = PictureBox1ImageCopy.Clone
    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        embedLayerObject(vec.thisVector)
    '    Next
    'End Sub

    'Private Function MakeNewSquareVector(ByVal location As Point) As EditDaqumentUtil.Vector
    '    Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector
    '    VectorIDCtr = VectorIDCtr + 1
    '    myVector.vectorID = VectorIDCtr
    '    myVector.StartPointX = location.X : myVector.StartPointY = location.Y
    '    'myVector.endPointX = EndPt.X : myVector.endPointY = EndPt.Y
    '    'myVector.OrgStartPointX = StartPt.X : myVector.OrgStartPointY = StartPt.Y
    '    'myVector.OrgEndPointX = EndPt.X : myVector.OrgEndPointY = EndPt.Y
    '    myVector.DrawingID = DocumentID
    '    myVector.OrgLineWidth = CurrentLineWidth
    '    myVector.ScaledLineWidth = CurrentLineWidth
    '    Dim myPen As New Pen(New SolidBrush(btnColorChoice.BackColor), CurrentLineWidth)
    '    myPen.EndCap = Drawing2D.LineCap.Flat
    '    myVector.penArgb = myPen.Color.ToArgb
    '    '            myVector.Opaque = IIf(btnMarking.Checked, True, False)
    '    myVector.VectorType = daqMode
    '    myVector.lineEnd = myPen.EndCap
    '    myVector.seqNumber = Vectors.Count + 1
    '    myVector.ObjectDeleted = False
    '    myVector.VectorObjectType = "Square"
    '    myVector.DateCreated = Now
    '    '            myVector.boundRectangle = New Rectangle(Control.MousePosition.X, Control.MousePosition.Y, 0, 0)
    '    myVector.OrgScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
    '    myVector.OrgScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
    '    Return myVector
    'End Function

    'Private Function MakeNewLineVector(ByVal StartPt As Point, ByVal EndPt As Point) As EditDaqumentUtil.Vector
    '    Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector
    '    VectorIDCtr = VectorIDCtr + 1
    '    myVector.vectorID = VectorIDCtr
    '    myVector.StartPointX = StartPt.X : myVector.StartPointY = StartPt.Y
    '    myVector.endPointX = EndPt.X : myVector.endPointY = EndPt.Y
    '    myVector.OrgStartPointX = StartPt.X : myVector.OrgStartPointY = StartPt.Y
    '    myVector.OrgEndPointX = EndPt.X : myVector.OrgEndPointY = EndPt.Y
    '    myVector.DrawingID = DocumentID
    '    myVector.OrgLineWidth = CurrentLineWidth
    '    myVector.ScaledLineWidth = CurrentLineWidth
    '    Dim myPen As New Pen(New SolidBrush(btnColorChoice.BackColor), CurrentLineWidth)
    '    myPen.EndCap = Drawing2D.LineCap.Flat
    '    myVector.penArgb = myPen.Color.ToArgb
    '    '            myVector.Opaque = IIf(btnMarking.Checked, True, False)
    '    myVector.VectorType = daqMode
    '    myVector.lineEnd = myPen.EndCap
    '    myVector.seqNumber = Vectors.Count + 1
    '    myVector.ObjectDeleted = False
    '    myVector.VectorObjectType = "Line"
    '    myVector.DateCreated = Now
    '    '            myVector.boundRectangle = New Rectangle(Control.MousePosition.X, Control.MousePosition.Y, 0, 0)
    '    myVector.OrgScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
    '    myVector.OrgScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
    '    Return myVector
    'End Function
    'Private Function MakeNewPictureImageVector(ByVal location As Point) As EditDaqumentUtil.Vector
    '    '        AddHandler mBox.DoubleClick, AddressOf TextBox1_DoubleClick
    '    Dim MyParent As DaqumentMain = Me.ParentForm
    '    Dim pBox As PictureBox = New PictureBox()
    '    VectorIDCtr = VectorIDCtr + 1
    '    Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector
    '    myVector.VectorImage = PicBox2.Image.Clone
    '    myVector.vectorID = VectorIDCtr
    '    'If btnMarking.Checked Then
    '    '    myVector.VectorImage = PicBox2.Image
    '    'Else
    '    '    Dim bm = New Bitmap(PicBox2.Image.Width, PicBox2.Image.Height)
    '    '    Using picCanvas As Graphics = Graphics.FromImage(bm)
    '    '        picCanvas.FillRectangle(Brushes.White, 0, 0, PicBox2.Image.Width, PicBox2.Image.Height)
    '    '        picCanvas.DrawImage(PicBox2.Image, 0, 0)
    '    '        Dim backColor As Color = bm.GetPixel(1, 1)
    '    '        bm.MakeTransparent(backColor)
    '    '        myVector.VectorImage = bm
    '    '    End Using
    '    'End If
    '    pBox.Name = VectorIDCtr.ToString
    '    pBox.Image = myVector.VectorImage.Clone
    '    pBox.Size = pBox.Image.Size
    '    pBox.BringToFront()
    '    pBox.Location = location
    '    PictureBox1.Controls.Add(pBox)

    '    myVector.VectorType = EditDaqumentUtil.mode.EmbedImage
    '    myVector.ObjectDeleted = False
    '    myVector.VectorObjectType = "Pic"
    '    myVector.StartPointX = pBox.Location.X : myVector.StartPointY = pBox.Location.Y
    '    myVector.endPointX = pBox.Location.X + pBox.Width : myVector.endPointY = pBox.Location.Y + pBox.Height
    '    myVector.OrgStartPointX = pBox.Location.X : myVector.OrgStartPointY = pBox.Location.Y
    '    myVector.OrgEndPointX = pBox.Location.X + pBox.Width : myVector.OrgEndPointY = pBox.Location.Y + pBox.Height
    '    myVector.seqNumber = Vectors.Count + 1
    '    myVector.DrawingID = DocumentID
    '    myVector.itmSelected = True
    '    myVector.DateCreated = Now
    '    myVector.pBox = pBox

    '    '        myVector.Opaque = IIf(btnMarking.Checked, True, False)
    '    '       myVector.boundRectangle = New Rectangle(Control.MousePosition, pBox.Size)
    '    myVector.OrgScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
    '    myVector.OrgScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
    '    Vectors.Add(New EditDaqumentUtil.VectorMap(myVector))
    '    AddBoundryBox(myVector)
    '    '        AddHandler pBox.MouseClick, AddressOf SelectedBox_MouseClick
    '    'AddHandler pBox.PreviewKeyDown, AddressOf SelectedPitcureBox_PreviewKeyDown
    '    '        AddHandler pBox.DoubleClick, AddressOf SelectedBox_DoubleClick
    '    Return myVector

    'End Function
    'Private Function MakeNewOverlayVector() As EditDaqumentUtil.Vector

    '    Dim MyParent As DaqumentMain = Me.ParentForm
    '    Dim pBox As PictureBox = New PictureBox()
    '    pBox.BackColor = Color.Transparent
    '    'AddHandler pBox.Click, AddressOf TextBox1_DoubleClick

    '    VectorIDCtr = VectorIDCtr + 1
    '    Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector

    '    Dim tmp_Image As Image = myDoc.CurrentImage
    '    Dim bmp_Image As New Bitmap(myDoc.CurrentImage)
    '    Dim backColor As Color = bmp_Image.GetPixel(1, 1)
    '    bmp_Image.MakeTransparent(backColor)

    '    'bmp_Image.Save("c:/test.png", System.Drawing.Imaging.ImageFormat.Png)

    '    myVector.VectorImage = bmp_Image
    '    myVector.vectorID = VectorIDCtr

    '    pBox.Name = "Overlay"
    '    pBox.Image = myVector.VectorImage.Clone
    '    pBox.Size = PictureBox1.Size
    '    pBox.BringToFront()
    '    pBox.Location = PictureBox1.Location
    '    'PictureBox1.Controls.Add(pBox)

    '    myVector.VectorType = EditDaqumentUtil.mode.EmbedImage
    '    myVector.ObjectDeleted = False
    '    myVector.VectorObjectType = "Overlay"
    '    myVector.StartPointX = pBox.Location.X : myVector.StartPointY = pBox.Location.Y
    '    myVector.endPointX = pBox.Location.X + pBox.Width : myVector.endPointY = pBox.Location.Y + pBox.Height
    '    myVector.OrgStartPointX = pBox.Location.X : myVector.OrgStartPointY = pBox.Location.Y
    '    myVector.OrgEndPointX = pBox.Location.X + pBox.Width : myVector.OrgEndPointY = pBox.Location.Y + pBox.Height
    '    myVector.seqNumber = Vectors.Count + 1
    '    myVector.DrawingID = DocumentID
    '    myVector.itmSelected = True
    '    myVector.DateCreated = Now
    '    myVector.pBox = pBox

    '    myVector.OrgScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
    '    myVector.OrgScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
    '    Vectors.Add(New EditDaqumentUtil.VectorMap(myVector))
    '    'AddBoundryBox(myVector)

    '    Return myVector

    'End Function
    'Private Function MakeNewTextBoxVector(ByVal location As Point) As EditDaqumentUtil.Vector
    '    '        AddHandler mBox.DoubleClick, AddressOf TextBox1_DoubleClick
    '    Dim MyParent As DaqumentMain = Me.ParentForm
    '    Dim mBox As TextBox = New TextBox()
    '    VectorIDCtr = VectorIDCtr + 1
    '    mBox.Name = VectorIDCtr.ToString
    '    mBox.Font = btnFontSelect.Font
    '    mBox.Text = ""
    '    mBox.BringToFront()
    '    mBox.Location = location
    '    mBox.Multiline = True
    '    PictureBox1.Controls.Add(mBox)
    '    mBox.BringToFront()
    '    Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector
    '    myVector.vectorID = VectorIDCtr
    '    myVector.VectorType = daqMode
    '    myVector.ObjectDeleted = False
    '    myVector.VectorObjectType = "Text"
    '    myVector.StartPointX = mBox.Location.X : myVector.StartPointY = mBox.Location.Y
    '    myVector.endPointX = mBox.Location.X + mBox.Width : myVector.endPointY = mBox.Location.Y + mBox.Height
    '    myVector.OrgStartPointX = mBox.Location.X : myVector.OrgStartPointY = mBox.Location.Y
    '    myVector.OrgEndPointX = mBox.Location.X + mBox.Width : myVector.OrgEndPointY = mBox.Location.Y + mBox.Height
    '    myVector.seqNumber = Vectors.Count + 1
    '    myVector.DrawingID = DocumentID
    '    myVector.itmSelected = True
    '    myVector.DateCreated = Now
    '    myVector.tBox = mBox
    '    Dim pBox As PictureBox = New PictureBox()
    '    myVector.pBox = pBox
    '    'myVector.Opaque = IIf(btnMarking.Checked, True, False)
    '    'myVector.boundRectangle = New Rectangle(Control.MousePosition, mBox.Size)
    '    myVector.OrgScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
    '    myVector.OrgScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
    '    Vectors.Add(New EditDaqumentUtil.VectorMap(myVector))
    '    AddBoundryBox(myVector)
    '    '        AddHandler mBox.MouseClick, AddressOf SelectedBox_MouseClick
    '    'AddHandler mBox.KeyDown, AddressOf SelectedBox_KeyDown
    '    '        AddHandler mBox.DoubleClick, AddressOf SelectedBox_DoubleClick
    '    Return myVector

    'End Function

    'Private Sub AddBoundryBox(ByVal vec As EditDaqumentUtil.Vector)

    '    Dim Width As Integer = Math.Abs(vec.StartPointX - vec.endPointX)
    '    Dim Height As Integer = Math.Abs(vec.StartPointY - vec.endPointY)
    '    Dim rect As Rectangle = New Rectangle(vec.StartPointX, vec.StartPointY, Width, Height)

    '    If vec.VectorObjectType = "Line" Then
    '        For i As Integer = 0 To 1
    '            Dim pic As PictureBox = New PictureBox
    '            pic.Size = New Size(8, 8)
    '            If i = 0 Then
    '                pic.Location = New Point(vec.StartPointX, vec.StartPointY)
    '            Else
    '                pic.Location = New Point(vec.endPointX, vec.endPointY)
    '            End If
    '            pic.BorderStyle = BorderStyle.FixedSingle
    '            PictureBox1.Controls.Add(pic)
    '            pic.BringToFront()
    '            pic.Visible = True
    '            Dim sCtrl As SeqControl
    '            sCtrl.Ctrl = pic : sCtrl.seqNumber = vec.seqNumber
    '            sCtrl.vecID = vec.vectorID
    '            tmpControls.Add(sCtrl)
    '        Next
    '        Return
    '    End If
    '    Dim picCtr = 0
    '    Dim lineTipCtr = 0

    '    Dim loc() As Point = { _
    '            New Point(rect.X - 8, rect.Y - 8), New Point(rect.X - 2 + rect.Width / 2, rect.Y - 4), _
    '            New Point(rect.X + rect.Width, rect.Y - 4), New Point(rect.X - 4, rect.Y - 2 + rect.Height / 2), _
    '            New Point(rect.X + rect.Width, rect.Y - 2 + rect.Height / 2), New Point(rect.X - 4, rect.Y + rect.Height), _
    '            New Point(rect.X - 2 + rect.Width / 2, rect.Y + rect.Height), New Point(rect.X + rect.Width, rect.Y + rect.Height)}
    '    Dim side() As Size = {New Size(8, 8), New Size(4, 4), New Size(4, 4), New Size(4, 4), _
    '            New Size(4, 4), New Size(4, 4), New Size(4, 4), New Size(4, 4)}
    '    For i As Integer = 0 To 7
    '        Dim pic As PictureBox = New PictureBox
    '        pic.Size = side(i)
    '        pic.Location = loc(i)
    '        pic.Name = "pic-" + vec.vectorID.ToString + "-" + i.ToString
    '        Dim bmp = New Bitmap(pic.Size.Width, pic.Size.Height)
    '        Dim g As Graphics = Graphics.FromImage(bmp)
    '        Dim customColor As Color = Color.FromArgb(200, Color.Black)
    '        'Dim myPen As New Pen(New SolidBrush(customColor), 4)
    '        g.FillRectangle(New SolidBrush(customColor), 0, 0, pic.Bounds.Width, pic.Bounds.Height)
    '        pic.Image = bmp
    '        'Dim backColor As Color = bmp.GetPixel(1, 1)
    '        ''TestPicBox.Image.Dispose()
    '        'bmp.MakeTransparent(backColor)
    '        'g.DrawImage(bmp, 0, 0)
    '        PictureBox1.Controls.Add(pic)
    '        Dim sCtrl As SeqControl
    '        sCtrl.Ctrl = pic : sCtrl.seqNumber = vec.seqNumber
    '        sCtrl.vecID = vec.vectorID
    '        tmpControls.Add(sCtrl)
    '        AddHandler pic.MouseHover, AddressOf TestPicBox_MouseHover
    '        AddHandler pic.MouseDown, AddressOf TestPicBox_MouseDown
    '        AddHandler pic.MouseMove, AddressOf TestPicBox_MouseMove
    '        AddHandler pic.MouseUp, AddressOf TestPicBox_MouseUp
    '        AddHandler pic.MouseLeave, AddressOf TestPicBox_MouseLeave
    '    Next
    '    '                vec.boundRectangle = New Rectangle(New Point(vec.StartPointX, vec.StartPointY), New Size(Width, Height))
    '    ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec), Me.BackColor, FrameStyle.Dashed)

    'End Sub

    'Private Function vectorScreenBoundRectangle(ByVal vec As EditDaqumentUtil.Vector) As Rectangle
    '    Dim Width As Integer = Math.Abs(vec.StartPointX - vec.endPointX)
    '    Dim Height As Integer = Math.Abs(vec.StartPointY - vec.endPointY)

    '    Dim vecRectangle As Rectangle = New Rectangle(PointToScreen(New Point(vec.StartPointX + ScreenOffsetX, vec.StartPointY + ScreenOffsetY)), _
    '            New Size(Width, Height))
    '    Return vecRectangle
    'End Function
    'Private Sub TestPicBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
    '    If daqMode = EditDaqumentUtil.mode.None Then
    '        daqMode = EditDaqumentUtil.mode.ObjectSelected
    '        '            AddBoundryBox()
    '    End If
    '    If daqMode = EditDaqumentUtil.mode.ObjectSelected Then
    '        dragStartPoint = Control.MousePosition
    '    End If
    'End Sub
    'Private Sub TestPicBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
    '    Dim vectorID As Integer = CType(Split(CType(sender, Control).Name, "-")(1), Integer)
    '    If daqMode = EditDaqumentUtil.mode.ObjectSelected Then
    '        daqMode = EditDaqumentUtil.mode.DragObject
    '        'For Each ctrl As SeqControl In tmpControls
    '        '    ctrl.Ctrl.Visible = False
    '        'Next
    '        'PictureBox1.Refresh()
    '        ''            dragStartPoint = Control.MousePosition
    '    End If
    '    If daqMode = EditDaqumentUtil.mode.DragObject Then
    '        'Dim dragX = Control.MousePosition.X - dragStartPoint.X
    '        'Dim dragY = Control.MousePosition.Y - dragStartPoint.Y
    '        For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '            If vec.itmSelected Then
    '                If vec.vectorID = vectorID Then
    '                    ComputDragLocation(sender, vec)
    '                    Exit Sub
    '                End If
    '                'ControlPaint.DrawReversibleFrame(vectorBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
    '                'Dim newLoc As Point = New Point(vectorBoundRectangle(vec.thisVector).X + dragX, vectorBoundRectangle(vec.thisVector).Y + dragY)
    '                'vectorBoundRectangle(vec.thisVector) = New Rectangle(newLoc, vectorBoundRectangle(vec.thisVector).Size)
    '                'ControlPaint.DrawReversibleFrame(vectorBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
    '            End If
    '        Next
    '    End If
    'End Sub
    'Private Sub TestPicBox_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PictureBox1.Cursor = Cursors.Default
    'End Sub

    'Private Sub TestPicBox_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim myControl As Control = sender
    '    Dim picPosition As String = Split(myControl.Name, "-")(2)
    '    If picPosition = "0" Then
    '        PictureBox1.Cursor = Cursors.Hand
    '    ElseIf picPosition = "1" Then
    '        PictureBox1.Cursor = Cursors.SizeNS
    '    ElseIf picPosition = "2" Then
    '        PictureBox1.Cursor = Cursors.SizeNESW
    '    ElseIf picPosition = "3" Then
    '        PictureBox1.Cursor = Cursors.SizeWE
    '    ElseIf picPosition = "4" Then
    '        PictureBox1.Cursor = Cursors.SizeWE
    '    ElseIf picPosition = "5" Then
    '        PictureBox1.Cursor = Cursors.SizeNESW
    '    ElseIf picPosition = "6" Then
    '        PictureBox1.Cursor = Cursors.SizeNS
    '    ElseIf picPosition = "7" Then
    '        PictureBox1.Cursor = Cursors.SizeNWSE
    '    End If
    '    PictureBox1.Refresh()
    'End Sub
    'Private Sub TestPicBox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If daqMode = EditDaqumentUtil.mode.DragObject Then
    '        Dim vectorID As Integer = CType(Split(CType(sender, Control).Name, "-")(1), Integer)
    '        For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '            If vec.vectorID = vectorID Then
    '                ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
    '                If vec.VectorObjectType = "Text" Then
    '                    vec.tBox.Size = vectorScreenBoundRectangle(vec.thisVector).Size
    '                    vec.tBox.Location = New Point(vec.StartPointX, vec.StartPointY)
    '                    If vec.tBox.Text > "" Then
    '                        MakeTextImage(vec)
    '                        vec.VectorType = EditDaqumentUtil.mode.EmbedText
    '                        vec.tBox.Visible = False
    '                        vec.itmSelected = False
    '                    Else
    '                        PictureBox1.Refresh()
    '                        Exit Sub
    '                    End If
    '                ElseIf vec.VectorObjectType = "Pic" Then
    '                    vec.pBox.Size = vectorScreenBoundRectangle(vec.thisVector).Size
    '                    vec.pBox.Location = New Point(vec.StartPointX, vec.StartPointY)
    '                    Dim newW = vec.pBox.Size.Width : Dim newH = vec.pBox.Size.Height
    '                    Dim img As Image = myDoc.ResizeImage(vec.vectorImage, New Size(newW, newH))
    '                    vec.pBox.Image.Dispose()
    '                    vec.pBox.Image = img
    '                    vec.VectorType = EditDaqumentUtil.mode.EmbedImage
    '                End If
    '                embedLayerObject(vec.thisVector)
    '                ClearSelectedBoundryBox(vec)
    '                vec.pBox.Visible = False
    '                daqMode = EditDaqumentUtil.mode.None
    '                Redraw()
    '                PictureBox1.Cursor = Cursors.Default
    '                PictureBox1.Refresh()
    '                Exit Sub
    '            End If
    '        Next
    '        '            AddBoundryBox()
    '    End If
    'End Sub
    'Private Function LayerSelected() As Boolean
    '    Dim i As Integer = 0
    '    For Each thisItem As ToolStripMenuItem In Me.btnViewLayers.DropDownItems
    '        If thisItem.Checked Then
    '            i = i + 1
    '        End If
    '    Next
    '    If i = 0 Then
    '        MessageBox.Show("Please Select a drawing layer")
    '        Return False
    '    Else
    '        If i <> 1 Then
    '            MessageBox.Show("Please Select a single drawing layer")
    '            Return False
    '        End If
    '    End If
    '    Return True
    'End Function
    'Private Function GetSeqCtrl(ByVal seq As Integer) As Integer
    '    For i As Integer = 0 To tmpControls.Count - 1
    '        If tmpControls(i).seqNumber = seq Then Return i
    '    Next
    '    Return -1
    'End Function
    'Private Sub ClearAllSelectedItems()

    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        vec.itmSelected = False
    '    Next
    '    Dim i As Integer = 0
    '    For Each sCtrl As SeqControl In tmpControls
    '        sCtrl.Ctrl.Dispose()
    '    Next
    '    tmpControls.Clear()
    'End Sub
    'Private Sub ClearSelectedBoundryBox(ByVal vec As EditDaqumentUtil.VectorMap)
    '    Dim i As Integer = 0
    '    While i >= 0
    '        i = GetSeqCtrl(vec.seqNumber)
    '        If i >= 0 Then
    '            tmpControls(i).Ctrl.Dispose()
    '            tmpControls.RemoveAt(i)
    '        End If
    '    End While
    '    vec.itmSelected = False

    '    localStartPoint = New Point(0, 0)
    '    theRectangle.Location = New Point(0, 0)
    '    theRectangle.Size = New Size(0, 0)

    'End Sub


    'Private Sub printDoc_BeginPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
    '    intPageCounter = 0
    'End Sub

    'Private Sub printDoc_EndPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
    'End Sub
    'Private Sub MakePrintImages()
    '    'daqumentRefresh()
    '    Dim img As Image = PictureBox1.Image.Clone
    '    Dim PprSize As PaperSize = printDoc.DefaultPageSettings.PaperSize()
    '    Dim pprWidth = PprSize.Width
    '    Dim pprHeight = PprSize.Height
    '    If printDoc.DefaultPageSettings.Landscape Then
    '        pprWidth = PprSize.Height
    '        pprHeight = PprSize.Width
    '    Else
    '        pprWidth = PprSize.Width
    '        pprHeight = PprSize.Height
    '    End If
    '    '        If img.Width > img.Height Then
    '    ' img.RotateFlip(RotateFlipType.Rotate90FlipNone)
    '    'End If

    '    For Each mg As Image In _PrintImages
    '        mg.Dispose()
    '    Next
    '    _PrintImages.Clear()
    '    Dim DoResize As Boolean = False

    '    If pprWidth <> img.Width Or pprHeight <> img.Height Then
    '        Dim rslt As DialogResult = MessageBox.Show("The default paper size does nat match; do you wish to resize image?", "Paper Size", MessageBoxButtons.YesNo)
    '        If rslt = Windows.Forms.DialogResult.Yes Then
    '            DoResize = True
    '        End If
    '    End If
    '    If DoResize Then
    '        _PrintImages.Add(myDoc.ResizeImage(New Size(pprWidth, pprHeight)))
    '    Else
    '        _PrintImages.Add(img)
    '    End If

    'End Sub
    'Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)

    '    Dim img As Image = _PrintImages(intPageCounter)
    '    e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height)
    '    e.HasMorePages = False
    '    intPageCounter = 0

    'End Sub

    'Private Sub cms1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms1.Opening
    '    If daqMode <> EditDaqumentUtil.mode.None Then Return
    '    cms1Loc = New Point(Control.MousePosition.X, Control.MousePosition.Y)

    '    ' Acquire references to the owning control and item.
    '    Dim c As Control = cms1.SourceControl
    '    Dim tsi As ToolStripDropDownItem = cms1.OwnerItem
    '    If (c IsNot Nothing) Then
    '        If c.Name <> "PictureBox1" Then Return
    '    End If
    '    If theRectangle.Size.Width = 0 Or theRectangle.Size.Height = 0 Then
    '        If Not cmsPictureBox.Image Is Nothing Then
    '            cms1.Items.Clear()
    '            cms1.Items.Add("-")
    '            cms1.Items.Add("Paste")
    '        End If
    '        Return
    '    Else
    '        ' Populate the ContextMenuStrip control with its default items.
    '        'If (theRectangle.Size.Width = 0 Or theRectangle.Size.Height = 0) Then Return
    '        cms1.Items.Clear()
    '        cms1.Items.Add("-")
    '        cms1.Items.Add("Cut")
    '        cms1.Items.Add("Copy")
    '        If Not cmsPictureBox.Image Is Nothing Then
    '            cms1.Items.Add("Paste")
    '        End If
    '    End If
    '    e.Cancel = False
    'End Sub

    'Private Sub cms1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cms1.ItemClicked
    '    Dim ScreenPoint As Point = cms1.Bounds.Location
    '    Dim ClientPoint As Point = PointToClient(cms1.Bounds.Location)
    '    Dim ClientPointF As PointF = CType(ClientPoint, PointF)
    '    Dim tsi As ToolStripDropDownItem = e.ClickedItem
    '    If Not LayerSelected() Then
    '        Return
    '    End If

    '    ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
    '    If tsi.Text = "Cut" Then
    '        Dim bm = New Bitmap(theRectangle.Size.Width, theRectangle.Size.Height)
    '        Dim picCanvas As Graphics = Graphics.FromImage(bm)
    '        picCanvas.CopyFromScreen(theRectangle.Location, New Point(0, 0), theRectangle.Size)
    '        If Not cmsPictureBox.Image Is Nothing Then
    '            cmsPictureBox.Image.Dispose()
    '        End If
    '        cmsPictureBox.Image = bm
    '        cmsPictureBox.Size = theRectangle.Size


    '        Dim bm1 = New Bitmap(theRectangle.Size.Width, theRectangle.Size.Height)
    '        Dim cutCanvas As Graphics = Graphics.FromImage(bm1)
    '        cutCanvas.FillRectangle(Brushes.White, 0, 0, theRectangle.Size.Width, theRectangle.Size.Height)
    '        If Not PicBox2.Image Is Nothing Then
    '            PicBox2.Image.Dispose()
    '        End If
    '        PicBox2.Image = bm1
    '        PicBox2.Size = theRectangle.Size
    '        daqMode = EditDaqumentUtil.mode.InsertImage
    '        Dim vect As EditDaqumentUtil.Vector = MakeNewPictureImageVector(PictureBox1.PointToClient(theRectangle.Location))
    '        embedLayerObject(vect)
    '        vect.pBox.Visible = False
    '        For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '            ClearSelectedBoundryBox(vec)
    '            vec.itmSelected = False
    '        Next
    '        daqMode = EditDaqumentUtil.mode.None
    '        ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
    '    ElseIf tsi.Text = "Copy" Then
    '        '            Dim myRect As Rectangle = theRectangle

    '        Dim bm = New Bitmap(theRectangle.Size.Width, theRectangle.Size.Height)
    '        Dim picCanvas As Graphics = Graphics.FromImage(bm)
    '        picCanvas.CopyFromScreen(theRectangle.Location, New Point(0, 0), theRectangle.Size)
    '        If Not cmsPictureBox.Image Is Nothing Then
    '            cmsPictureBox.Image.Dispose()
    '        End If
    '        cmsPictureBox.Image = bm
    '        cmsPictureBox.Size = theRectangle.Size

    '        If Not PicBox2.Image Is Nothing Then
    '            PicBox2.Image.Dispose()
    '        End If
    '        PicBox2.Image = bm
    '        PicBox2.Size = theRectangle.Size


    '    ElseIf tsi.Text = "Paste" Then
    '        If Not PicBox2.Image Is Nothing Then
    '            PicBox2.Image.Dispose()
    '        End If
    '        PicBox2.Size = theRectangle.Size
    '        PicBox2.Image = cmsPictureBox.Image.Clone
    '        daqMode = EditDaqumentUtil.mode.InsertImage
    '        MakeNewPictureImageVector(ClientPoint)
    '        daqMode = EditDaqumentUtil.mode.ObjectSelected
    '    End If

    '    PictureBox1.Refresh()

    'End Sub
    'Private Sub EditDaqument_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '    If daqMode = EditDaqumentUtil.mode.ObjectSelected Then
    '        For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '            If vec.itmSelected Then
    '                Dim objMoved As Boolean = False
    '                Dim X = vectorScreenBoundRectangle(vec.thisVector).X : Dim Y = vectorScreenBoundRectangle(vec.thisVector).Y
    '                If e.KeyCode = Keys.Escape Then
    '                    vec.ObjectDeleted = True
    '                End If
    '                If e.KeyCode = Keys.Delete Then
    '                    vec.ObjectDeleted = True
    '                End If
    '                If e.KeyCode = Keys.Left Then
    '                    X = X - 1 : objMoved = True
    '                End If
    '                If e.KeyCode = Keys.Right Then
    '                    X = X + 1 : objMoved = True
    '                End If
    '                If e.KeyCode = Keys.Up Then
    '                    Y = Y - 1 : objMoved = True
    '                End If
    '                If e.KeyCode = Keys.Down Then
    '                    Y = Y + 1 : objMoved = True
    '                End If
    '                If objMoved Then
    '                    'ResizeObject(vec)
    '                End If
    '            End If
    '        Next

    '    End If
    '    If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
    '        For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '            For Each sCtrl As SeqControl In tmpControls
    '                If sCtrl.vecID = vec.vectorID Then
    '                    vec.ObjectDeleted = True
    '                    If Not vec.tBox Is Nothing Then
    '                        vec.tBox.Visible = False
    '                    End If
    '                    If Not vec.pBox Is Nothing Then
    '                        vec.pBox.Visible = False
    '                    End If
    '                End If
    '            Next
    '        Next
    '        ClearAllSelectedItems()
    '        Redraw()
    '        PictureBox1.Refresh()
    '    End If

    'End Sub
    'Private Sub btnViewLayers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewLayers.Click
    '    Try
    '        Dim i As Integer = 0
    '        For Each thisItem As ToolStripMenuItem In Me.btnViewLayers.DropDownItems
    '            i = i + 1
    '        Next
    '        If i = 1 Then
    '            Dim msgResult As DialogResult = MessageBox.Show("No layer has been added to the Drawing; do you wish to add a new layer?", "Add Layer", MessageBoxButtons.YesNo)
    '            If msgResult = Windows.Forms.DialogResult.Yes Then
    '                Dim myForm As DaqumentAddNewLayer = New DaqumentAddNewLayer(myDoc)
    '                myForm.ShowDialog()
    '                AddLayerTitles()
    '                Dim thisItem As ToolStripMenuItem = Me.btnViewLayers.DropDownItems(0)
    '                thisItem.Checked = True
    '                thisItem.CheckOnClick = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try

    'End Sub

    'Private Sub btnCreateNewLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNewLayer.Click
    '    Dim myForm As DaqumentAddNewLayer = New DaqumentAddNewLayer(myDoc)
    '    myForm.ShowDialog()
    '    AddLayerTitles()
    'End Sub
    'Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    '    daqMode = EditDaqumentUtil.mode.None
    '    PictureBox1.Cursor = Cursors.Default
    '    ClearAllSelectedItems()
    '    Me.PictureBox1.Invalidate()
    '    Me.Refresh()

    'End Sub

    'Private Sub btnLineDraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLineDraw.Click
    '    If Not LayerSelected() Then
    '        Return
    '    End If
    '    'daqumentRefresh()
    '    daqMode = EditDaqumentUtil.mode.lineDraw
    '    PictureBox1.Cursor = Cursors.Cross
    'End Sub
    'Private Sub btnFreehand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFreehand.Click
    '    If Not LayerSelected() Then
    '        Return
    '    End If
    '    '    daqumentRefresh()
    '    daqMode = EditDaqumentUtil.mode.FreeHand
    '    PictureBox1.Cursor = Cursors.UpArrow
    'End Sub

    'Private Sub btnInsertImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertImage.Click
    '    If Not LayerSelected() Then
    '        Return
    '    End If

    '    '        daqumentRefresh()
    '    PictureBox1.Cursor = Cursors.Cross
    '    picBoxDragHandle.Image = Global.Daqument.My.Resources.Resources.Image
    '    picBoxDragHandle.Visible = False
    '    Dim openFileDialog1 As New OpenFileDialog()
    '    openFileDialog1.InitialDirectory = "c:\"
    '    openFileDialog1.Filter = "Image files (*.bmp)|*.bmp|(*.png)|*.png|(*.jpg)|*.jpg|(*.*)|*.*"
    '    openFileDialog1.FilterIndex = 1

    '    If openFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
    '    If Not PicBox2.Image Is Nothing Then
    '        PicBox2.Image.Dispose()
    '    End If
    '    PicBox2.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName).Clone
    '    If PicBox2.Image.Size.Height = 0 Or PicBox2.Image.Size.Width = 0 Then Return
    '    If PicBox2.Image.Size.Height >= PictureBox1.Image.Size.Height Then Return
    '    If PicBox2.Image.Size.Width >= PictureBox1.Image.Size.Width Then Return
    '    PicBox2.Size = PicBox2.Image.Size
    '    PicBox2.Visible = False
    '    daqMode = EditDaqumentUtil.mode.InsertImage
    'End Sub


    'Private Sub btnInsertText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertText.Click
    '    If Not LayerSelected() Then
    '        Return
    '    End If
    '    'daqumentRefresh()
    '    daqMode = EditDaqumentUtil.mode.InsertText
    '    PictureBox1.Cursor = Cursors.Cross
    '    picBoxDragHandle.Image = Global.Daqument.My.Resources.Resources.Text_Document
    '    picBoxDragHandle.Visible = False

    'End Sub

    'Private Sub btnWidth1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth1.Click
    '    btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width1
    '    CurrentLineWidth = 1
    'End Sub

    'Private Sub btnWidth2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth2.Click
    '    btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width2
    '    CurrentLineWidth = 2
    'End Sub

    'Private Sub btnWidth3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth3.Click
    '    btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width3
    '    CurrentLineWidth = 4
    'End Sub

    'Private Sub btnWidth4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth4.Click
    '    btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width4
    '    CurrentLineWidth = 8
    'End Sub

    'Private Sub btnWidth5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth5.Click
    '    btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width5
    '    CurrentLineWidth = 15
    'End Sub

    'Private Sub btnColorRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorRed.Click
    '    If btnHiliting.Checked Then
    '        btnColorChoice.BackColor = Color.FromArgb(80, 255, 0, 0)
    '    Else
    '        btnColorChoice.BackColor = Color.FromArgb(255, 255, 0, 0)
    '    End If
    '    Dim myBackColor As Color = btnColorChoice.BackColor
    '    btnColorChoice.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)
    'End Sub

    'Private Sub btnColorBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorBlue.Click
    '    If btnHiliting.Checked Then
    '        btnColorChoice.BackColor = Color.FromArgb(80, 0, 0, 255)
    '    Else
    '        btnColorChoice.BackColor = Color.FromArgb(255, 0, 0, 255)
    '    End If
    '    Dim myBackColor As Color = btnColorChoice.BackColor
    '    btnColorChoice.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)

    'End Sub

    'Private Sub btnColorGreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorGreen.Click
    '    If btnHiliting.Checked Then
    '        btnColorChoice.BackColor = Color.FromArgb(80, 0, 255, 0)
    '    Else
    '        btnColorChoice.BackColor = Color.FromArgb(255, 0, 255, 0)
    '    End If
    '    Dim myBackColor As Color = btnColorChoice.BackColor
    '    btnColorChoice.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)

    'End Sub
    'Private Sub btnColorYellow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorYellow.Click
    '    If btnHiliting.Checked Then
    '        btnColorChoice.BackColor = Color.FromArgb(80, 255, 255, 0)
    '    Else
    '        btnColorChoice.BackColor = Color.FromArgb(255, 255, 255, 0)
    '    End If
    '    Dim myBackColor As Color = btnColorChoice.BackColor
    '    btnColorChoice.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)
    'End Sub
    'Private Sub btnHiliting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHiliting.Click
    '    btnMarking.Checked = False
    '    btnColorChoice.Text = "Hilite"
    '    btnHiliting.Checked = True
    '    Dim myBackColor As Color = btnColorChoice.BackColor
    '    myBackColor = Color.FromArgb(80, myBackColor.R, myBackColor.G, myBackColor.B)
    '    btnColorChoice.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)
    '    btnColorChoice.BackColor = myBackColor
    'End Sub

    'Private Sub btnMarking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarking.Click
    '    btnMarking.Checked = True
    '    btnColorChoice.Text = "Marking"
    '    btnHiliting.Checked = False
    '    Dim myBackColor As Color = btnColorChoice.BackColor
    '    myBackColor = Color.FromArgb(255, myBackColor.R, myBackColor.G, myBackColor.B)
    '    btnColorChoice.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)
    '    btnColorChoice.BackColor = myBackColor

    'End Sub

    'Private Sub btnEnlarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnlarge.Click
    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
    '            If vec.itmSelected Then
    '                Dim myFontSize As Single = vec.tBox.Font.Size
    '                If vec.tBox.Font.Size < 72 Then
    '                    Dim myFont = New Font(vec.tBox.Font.FontFamily, vec.tBox.Font.Size + 1, _
    '                                System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
    '                    vec.tBox.Font = myFont
    '                End If
    '            End If
    '        End If
    '    Next
    'End Sub

    'Private Sub btnReduce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReduce.Click
    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
    '            If vec.itmSelected Then
    '                Dim myFontSize As Single = vec.tBox.Font.Size
    '                If vec.tBox.Font.Size > 4 Then
    '                    Dim myFont = New Font(vec.tBox.Font.FontFamily, vec.tBox.Font.Size - 1, _
    '                                System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
    '                    vec.tBox.Font = myFont
    '                End If
    '            End If
    '        End If
    '    Next
    'End Sub

    'Private Sub btnDrag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrag.Click
    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        ' ClearSelectedBoundryBox(vec)
    '    Next

    '    PreviousAnchorPoint = PictureBox1.Location
    '    daqMode = EditDaqumentUtil.mode.Drag
    '    '        embedAllObjects()
    '    PictureBox1.Cursor = Cursors.NoMove2D
    'End Sub

    'Private Sub btn500_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn500.Click
    '    If ResizeDrawingView(5, 5) Then
    '        Me.btnMaginfy.Text = String.Format("500%")
    '    End If
    'End Sub

    'Private Sub btn200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn200.Click
    '    If ResizeDrawingView(2, 2) Then
    '        Me.btnMaginfy.Text = String.Format("200%")
    '    End If
    'End Sub

    'Private Sub btn150_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn150.Click
    '    If ResizeDrawingView(1.5, 1.5) Then
    '        Me.btnMaginfy.Text = String.Format("150%")
    '    End If
    'End Sub

    'Private Sub btn100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn100.Click
    '    If ResizeDrawingView(1, 1) Then
    '        Me.btnMaginfy.Text = String.Format("100%")
    '    End If
    'End Sub

    'Private Sub btn75_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn75.Click
    '    If ResizeDrawingView(0.75, 0.75) Then
    '        Me.btnMaginfy.Text = String.Format("75%")
    '    End If
    'End Sub

    'Private Sub btn50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn50.Click
    '    If ResizeDrawingView(0.5, 0.5) Then
    '        Me.btnMaginfy.Text = String.Format("50%")
    '    End If
    'End Sub

    'Private Sub btn25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn25.Click
    '    If ResizeDrawingView(0.25, 0.25) Then
    '        Me.btnMaginfy.Text = String.Format("25%")
    '    End If
    'End Sub
    'Private Sub btnPageWidth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageWidth.Click
    '    ResizePageWidth()
    'End Sub

 
End Class




