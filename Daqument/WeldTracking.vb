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


Public Class WeldTracking

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Private InfoTblForm As Form
    Private WeldParameterForm As Form
    Private printDoc As PrintDocument = New PrintDocument()
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
    '    Private Welds As New List(Of EditDaqumentUtil.WeldPoint)
    Private BoundryBox As New List(Of PictureBox)
    '    Private Magnification As Single = 1
    Private tmpVectors As New List(Of EditDaqumentUtil.Vector)
    Private ListOfModifiedVectors As New List(Of EditDaqumentUtil.Vector)
    Private UserActionList As New List(Of UserAction)
    'Private SpoolInfoTbl As DataTable
    'Private TestPkgInfoTbl As DataTable
    'Private PipeSizeInfoTbl As DataTable
    'Private WPSInfoTbl As DataTable
    'Private WeldStnInfoTbl As DataTable
    Private tblWeldTracking As DataTable


    Private ColorBlueHilite As Color = Color.FromArgb(80, 0, 0, 255)
    Private ColorBlueMarking As Color = Color.FromArgb(80, 0, 0, 255)
    Private ColorGreenHilite As Color = Color.FromArgb(80, 0, 255, 0)
    Private ColorGreenMarking As Color = Color.FromArgb(80, 0, 255, 0)
    Private ColorRedHilite As Color = Color.FromArgb(80, 255, 0, 0)
    Private ColorRedMarking As Color = Color.FromArgb(80, 255, 0, 0)
    Private ColorYellowHilite As Color = Color.FromArgb(80, 255, 255, 0)
    Private ColorYellowMarking As Color = Color.FromArgb(80, 255, 255, 0)
    Private ColorOrangeHilite As Color = Color.FromArgb(80, 255, 192, 128)
    Private ColorOrangeMarking As Color = Color.FromArgb(80, 255, 192, 128)
    Private defaultWeld As EditDaqumentUtil.WeldPoint = New EditDaqumentUtil.WeldPoint
    Public Enum WeldStatus
        NewWeld
        FieldWeld
        InspectWeld
        OKWeld
        RejectWeld
    End Enum

    Public Class UserAction
        Public Structure Action
            Dim ActType As ActionType
            Dim vecID As Integer
            Dim vec As EditDaqumentUtil.Vector
        End Structure
        Public Enum ActionType
            Add
            Delete
            Modify
        End Enum
        Dim _Action As Action
        Public Sub New(ByVal ActionType As ActionType, ByVal ID As Integer)
            _Action.ActType = ActionType
            _Action.vecID = ID
        End Sub
        Public Sub New(ByVal ActionType As ActionType, ByVal ID As Integer, ByVal vec As EditDaqumentUtil.Vector)
            _Action.ActType = ActionType
            _Action.vecID = ID
            _Action.vec = vec
        End Sub
    End Class

    Public Structure SeqControl
        Dim seqNumber As Integer
        Dim Ctrl As Control
        Dim vecID As Integer
    End Structure

    Private tmpControls As New List(Of SeqControl)
    Private dragHandleRectangle As Rectangle

    '    Private VarCtr As Integer
    Private _PrintImages As New List(Of Image)
    Dim daqMode As EditDaqumentUtil.mode = EditDaqumentUtil.mode.None
    Private _DocumentID As Integer
    Private _DocumentName As String

    Dim selectedInfo As String


    Private Sub AddLayerTitles()
        Try
            Dim dt As DataTable = myDoc.WeldLayerInfoTbl()
            If dt.Rows.Count = 0 Then
                myDoc.AddNewLayer("Welds", "Weld Tracking")
                'LayerInfoTbl = myDoc.WeldLayerInfoTbl()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EditDaqument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            myDoc = New EditDaqumentUtil(_DocumentID)
            '            tblWeldTracking = myDoc.WeldPointInfoTbl

            localStartPoint = New Point(0, 0)
            'Dim picSize = New Size(Me.ClientRectangle.Size.Width - 40, Me.ClientRectangle.Size.Height - 100)
            'PictureBox1.Size = picSize
            'PictureBox1.Image = myDoc.ResizeImage(PictureBox1.Size)
            ResizePageWidth()
            '            WeldTypeToolStripMenuItem.Text = "Butt Weld"
            btnWeldSelect.Text = "New Welds"
            Dim myBackColor As Color = ColorBlueHilite
            btnInsertImage.Image = Global.Daqument.My.Resources.Resources.blueButtWeld
            btnWeldSelect.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)
            btnWeldSelect.BackColor = myBackColor

            btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width1
            CurrentLineWidth = 1
            PicBox2.Visible = False
            picBoxDragHandle.Visible = False
            PictureBox1.Controls.Add(picBoxDragHandle)
            printDoc.DocumentName = "Printing Documents"
            AddHandler printDoc.BeginPrint, AddressOf printDoc_BeginPrint
            AddHandler printDoc.EndPrint, AddressOf printDoc_EndPrint
            AddHandler printDoc.PrintPage, AddressOf printDoc_PrintPage
            PictureBox1.Refresh()
            AddLayerTitles()
            '            populateInfoTbls()
            LoadDefaultWeldPointParameters()
            Me.loadWeldPointsLayerVectors(myDoc.GetLayerID("Welds"))

            'If Me.tblWeldTracking.Rows.Count <> Me.Vectors.Count Then
            '    MessageBox.Show("Corrupted Database; record count expected: " + Me.tblWeldTracking.Rows.Count.ToString + _
            '    " Found " + Me.Vectors.Count.ToString)
            '    myDoc.WeldPointDeleteAll()
            '    Me.Close()
            'End If
            Redraw()

            '            Dim myLayerInfo As New Daqument.DcomentLayer(myDoc)
            '           myLayerInfo.Show()
        Catch ex As Exception
            Utilities.logErrorMessage("Daqument.WeldTracking.EditDocument_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Public Sub embedLayerObject(ByVal vec As EditDaqumentUtil.Vector)
        Dim g As Graphics = Graphics.FromImage(Me.PictureBox1.Image)
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
                myPen.EndCap = vec.lineEnd
                Dim startPoint As Point = New Point(vec.StartPointX, vec.StartPointY)
                Dim endPoint As Point = New Point(vec.endPointX, vec.endPointY)
                g.DrawLine(myPen, startPoint, endPoint)
            End If
        End If
    End Sub
    Private Sub RescaleVector(ByVal vec As EditDaqumentUtil.VectorMap, ByVal MagX As Single, ByVal MagY As Single)
        Dim newScaleX = MagX / vec.OrgScaleX
        Dim newScaleY = MagY / vec.OrgScaleY
        vec.StartPointX = vec.OrgStartPointX * newScaleX
        vec.StartPointY = vec.OrgStartPointY * newScaleY
        Dim newLoc As Point = New Point(vec.StartPointX, vec.StartPointY)
        If vec.VectorObjectType = "Line" Then
            vec.endPointX = vec.OrgEndPointX * newScaleX
            vec.endPointY = vec.OrgEndPointY * newScaleY
            vec.ScaledlineWidth = vec.OrgLineWidth * newScaleY
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
        End If
    End Sub
    Private Function ResizeDrawingView(ByVal MagX As Single, ByVal MagY As Single) As Boolean
        Dim sX As Integer = MagX * myDoc.OriginalDrawingSize.Width
        Dim sY As Integer = MagY * myDoc.OriginalDrawingSize.Height
        If (sX * sY) > 20000000 Then
            MessageBox.Show("Not enough memory")
            Return False
        End If
        Dim newSize As Size = New Size(sX, sY)
        If Not PictureBox1.Image Is Nothing Then
            PictureBox1.Image.Dispose()
        End If
        PictureBox1.Image = myDoc.ResizeImage(newSize)
        If Not PictureBox1ImageCopy Is Nothing Then
            PictureBox1ImageCopy.Dispose()
        End If
        PictureBox1ImageCopy = PictureBox1.Image.Clone
        PictureBox1.Size = PictureBox1.Image.Size
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            ClearSelectedBoundryBox(vec)
            RescaleVector(vec, MagX, MagY)
            embedLayerObject(vec.thisVector)
        Next
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            'embedLayerObject(vec.thisVector)
        Next
        PictureBox1.Location = New Point(ScreenOffsetX, ScreenOffsetY)
        PictureBox1.Refresh()
        Return True
    End Function
    Private Sub ComputDragLocation(ByVal sender As System.Object, ByVal vec As EditDaqumentUtil.VectorMap)
        Dim dragX = Control.MousePosition.X - dragStartPoint.X
        Dim dragY = Control.MousePosition.Y - dragStartPoint.Y
        Dim W = Math.Abs(vec.StartPointX - vec.endPointX) : Dim H = Math.Abs(vec.StartPointY - vec.endPointY)
        Dim X = vec.StartPointX : Dim Y = vec.StartPointY
        ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
        Dim myControl As Control = sender
        Dim picPosition As String = Split(myControl.Name, "-")(2)
        If picPosition = "0" Then
            vec.StartPointX = vec.StartPointX + dragX : vec.StartPointY = vec.StartPointY + dragY
            vec.endPointX = vec.endPointX + dragX : vec.endPointY = vec.endPointY + dragY
            vec.OrgStartPointX = vec.StartPointX : vec.OrgStartPointY = vec.StartPointY
            vec.OrgEndPointX = vec.endPointX : vec.OrgEndPointY = vec.endPointY
            dragStartPoint = Control.MousePosition
            ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
            Return
        ElseIf picPosition = "1" Then
            Y = Y + dragY : H = H - dragY
            PictureBox1.Cursor = Cursors.SizeNS
        ElseIf picPosition = "2" Then
            Y = Y + dragY : H = H - dragY : W = W - dragY
            PictureBox1.Cursor = Cursors.SizeNESW
        ElseIf picPosition = "3" Then
            X = X + dragX : W = W - dragX
            PictureBox1.Cursor = Cursors.SizeWE
        ElseIf picPosition = "4" Then
            W = W + dragX
            PictureBox1.Cursor = Cursors.SizeWE
        ElseIf picPosition = "5" Then
            X = X + dragX : H = H + dragY : W = W - dragX
            PictureBox1.Cursor = Cursors.SizeNESW
        ElseIf picPosition = "6" Then
            H = H + dragY
            PictureBox1.Cursor = Cursors.SizeNS
        ElseIf picPosition = "7" Then
            H = H + dragY : W = W + dragY
            PictureBox1.Cursor = Cursors.SizeNWSE
        End If
        If H > 4 And W > 4 Then
            vec.StartPointX = X : vec.StartPointY = Y
            vec.endPointX = vec.endPointX + dragX : vec.endPointY = vec.endPointY + dragY
            vec.OrgStartPointX = vec.StartPointX : vec.OrgStartPointY = vec.StartPointY
            vec.OrgEndPointX = vec.endPointX : vec.OrgEndPointY = vec.endPointY
        End If
        dragStartPoint = Control.MousePosition
        ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)

    End Sub
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
    Private Sub ResizePageWidth()
        Dim picSize As Size = New Size(Me.ClientRectangle.Size.Width - 40, Me.ClientRectangle.Size.Height - 100)
        Dim orgSize As Size = myDoc.OriginalDrawingSize
        PictureBox1.Size = picSize
        Dim magX As Single = (picSize.Width / orgSize.Width) : Dim magY As Single = (picSize.Height / orgSize.Height)
        If ResizeDrawingView(magX, magY) Then
            Me.btnMaginfy.Text = String.Format("{0}%", CType((magX * 100), Integer))
        End If
    End Sub
    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Dim ScreenPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)

        localStartPoint = New Point(e.X, e.Y)
        If daqMode = EditDaqumentUtil.mode.FreeHand Then
            tmpVectors.Clear()
        ElseIf daqMode = EditDaqumentUtil.mode.lineDraw Then
            lineStartPoint = New Point(Control.MousePosition.X, Control.MousePosition.Y)
            lineEndPoint = lineStartPoint
            tmpVectors.Clear()
        ElseIf daqMode = EditDaqumentUtil.mode.InsertText Then
            picBoxDragHandle.Visible = False
            'MakeNewTextBoxVector(ClientPoint)
            daqMode = EditDaqumentUtil.mode.ObjectSelected
            PictureBox1.Cursor = Cursors.Default
        ElseIf daqMode = EditDaqumentUtil.mode.InsertImage Then
            picBoxDragHandle.Visible = False
            MakeNewPictureImageVector(ClientPoint)
            daqMode = EditDaqumentUtil.mode.ObjectSelected
            PictureBox1.Cursor = Cursors.Default
        End If
        Dim newPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
        theRectangle.Location = New Point(newPoint.X, newPoint.Y)
        theRectangle.Size = New Size(0, 0)
        'ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)


    End Sub
    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        Dim myPoint As Point = New Point(e.X, e.Y)
        Dim ScreenPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
        '        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)

        If daqMode = EditDaqumentUtil.mode.Drag Then
            If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
            Dim picPoint As Point = PictureBox1.Location
            Dim diffX = myPoint.X - localStartPoint.X : Dim diffY = myPoint.Y - localStartPoint.Y

            PictureBox1.Location = New Point(picPoint.X + diffX, picPoint.Y + diffY)
            ScreenOffsetX = ScreenOffsetX + diffX : ScreenOffsetY = ScreenOffsetY + diffY
            Me.PictureBox1.Refresh()
        ElseIf daqMode = EditDaqumentUtil.mode.None Then
            If (e.Button = System.Windows.Forms.MouseButtons.Left) Then
                Dim newPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
                If theRectangle.X = 0 Then
                    theRectangle.Location = New Point(newPoint.X, newPoint.Y)
                Else
                    Dim myWidth = newPoint.X - theRectangle.X : Dim myHeight = newPoint.Y - theRectangle.Y
                    theRectangle.Size = New Size(Math.Abs(myWidth), Math.Abs(myHeight))
                End If
                PictureBox1.Refresh()
                ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)


            End If
        ElseIf daqMode = EditDaqumentUtil.mode.InsertImage Then
            picBoxDragHandle.Visible = True
            picBoxDragHandle.Location = New Point(e.X + 5, e.Y + 5)
        End If

    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Dim ScreenPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)
        If daqMode = EditDaqumentUtil.mode.FreeHand Then
            For Each vec As EditDaqumentUtil.Vector In tmpVectors
                Vectors.Add(New EditDaqumentUtil.VectorMap(vec))
            Next
        ElseIf daqMode = EditDaqumentUtil.mode.None Then
            ClearAllSelectedItems()
            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If theRectangle.Contains(vectorScreenBoundRectangle(vec.thisVector)) Then
                    AddBoundryBox(vec.thisVector)
                    vec.itmSelected = True
                End If
            Next
        End If
    End Sub
    Private Sub PictureBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        Dim ScreenPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)
        If daqMode = EditDaqumentUtil.mode.lineDraw _
            Or daqMode = EditDaqumentUtil.mode.FreeHand _
            Or daqMode = EditDaqumentUtil.mode.Drag Then
            Return
        End If
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vectorScreenBoundRectangle(vec.thisVector).Contains(ScreenPoint) Then
                If ((Not vec.ObjectDeleted) And vec.itmSelected) Then
                    If vec.VectorObjectType = "Pic" Then
                        ClearSelectedBoundryBox(vec)
                        vec.pBox.Visible = False
                        vec.itmSelected = False
                        SelectVectorImage(vec)
                        embedLayerObject(vec.thisVector)
                    End If
                End If
            End If
        Next

        Dim itmSel As Boolean = False
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.itmSelected Then itmSel = True
        Next
        If Not itmSel And daqMode = EditDaqumentUtil.mode.ObjectSelected Then
            daqMode = EditDaqumentUtil.mode.None
        End If

        PictureBox1.Refresh()

    End Sub

    Private Sub PictureBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Dim ScreenPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)
        If daqMode = EditDaqumentUtil.mode.lineDraw _
            Or daqMode = EditDaqumentUtil.mode.FreeHand _
            Or daqMode = EditDaqumentUtil.mode.Drag Then
            Return
        End If


        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If Not vec.ObjectDeleted Then
                'Dim vecHeight As Integer = Math.Abs(vec.StartPointY - vec.endPointY)
                'Dim vecWidth As Integer = Math.Abs(vec.StartPointX - vec.endPointX)
                'Dim vecRect As Rectangle = New Rectangle(PointToScreen(New Point(vec.StartPointX, vec.StartPointY)), _
                '        New Size(vecWidth, vecHeight))
                If vectorScreenBoundRectangle(vec.thisVector).Contains(ScreenPoint) Then
                    If vec.VectorType = EditDaqumentUtil.mode.EmbedImage Then
                        daqMode = EditDaqumentUtil.mode.ObjectSelected
                        '        vec.VectorType = EditDaqumentUtil.mode.InsertImage
                        vec.itmSelected = True
                        'vec.pBox.Visible = True
                        'Redraw()
                        AddBoundryBox(vec.thisVector)
                        For Each dr As DataRow In tblWeldTracking.Rows
                            If dr("TagNo") = vec.text Then
                                For Each clm As DataColumn In tblWeldTracking.Columns
                                    selectedInfo = clm.ColumnName
                                    SetDefaultValue(dr)
                                Next
                            End If
                        Next
                        Exit Sub
                    End If
                End If

            End If
        Next
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.itmSelected Then
                If vec.VectorObjectType = "Pic" Then
                    ClearSelectedBoundryBox(vec)
                    vec.pBox.Visible = False
                    vec.itmSelected = False
                    embedLayerObject(vec.thisVector)
                End If
            End If
        Next

        Dim itmSel As Boolean = False
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.itmSelected Then itmSel = True
        Next
        If Not itmSel And daqMode = EditDaqumentUtil.mode.ObjectSelected Then
            daqMode = EditDaqumentUtil.mode.None
        End If

        PictureBox1.Refresh()
    End Sub
    Private Sub Redraw()
        If Not PictureBox1.Image Is Nothing Then
            PictureBox1.Image.Dispose()
        End If
        PictureBox1.Image = PictureBox1ImageCopy.Clone
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            embedLayerObject(vec.thisVector)
        Next
    End Sub


    Private Function MakeNewPictureImageVector(ByVal location As Point) As EditDaqumentUtil.Vector
        '        AddHandler mBox.DoubleClick, AddressOf TextBox1_DoubleClick
        Dim MyParent As DaqumentMain = Me.ParentForm
        Dim pBox As PictureBox = New PictureBox()
        VectorIDCtr = VectorIDCtr + 1
        Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector
        Dim myWeldPoint As EditDaqumentUtil.WeldPoint = New EditDaqumentUtil.WeldPoint
        myWeldPoint.ID = VectorIDCtr
        myWeldPoint.WeldStatus = WeldStatus.NewWeld
        CopyParamsFromDefaultWeldPoint(myWeldPoint)
        Dim dr As DataRow = tblWeldTracking.NewRow
        For Each clm As DataColumn In tblWeldTracking.Columns
            If clm.ColumnName <> "ID" Then dr(clm.ColumnName) = GetDefaultParameter(clm.ColumnName)
        Next
        dr("TagNo") = VectorIDCtr.ToString
        dr("ID") = 0
        dr("WeldStatus") = WeldStatus.NewWeld
        tblWeldTracking.Rows.Add(dr)
        myVector.VectorImage = PicBox2.Image.Clone
        myVector.vectorID = VectorIDCtr
        myVector.text = VectorIDCtr.ToString
        myVector.layerID = myDoc.GetLayerID("Welds")
        myVector.CabinetID = myDoc.GetCabinetID(myVector.layerID)
        myVector.VectorModified = True
        myVector.ObjectMode = "Marking"
        pBox.Name = VectorIDCtr.ToString
        pBox.Image = myVector.VectorImage.Clone
        pBox.Size = pBox.Image.Size
        pBox.BringToFront()
        pBox.Location = location
        PictureBox1.Controls.Add(pBox)

        myVector.VectorType = EditDaqumentUtil.mode.EmbedImage
        myVector.ObjectDeleted = False
        myVector.VectorObjectType = "Pic"
        myVector.StartPointX = pBox.Location.X : myVector.StartPointY = pBox.Location.Y
        myVector.endPointX = pBox.Location.X + pBox.Width : myVector.endPointY = pBox.Location.Y + pBox.Height
        myVector.OrgStartPointX = pBox.Location.X : myVector.OrgStartPointY = pBox.Location.Y
        myVector.OrgEndPointX = pBox.Location.X + pBox.Width : myVector.OrgEndPointY = pBox.Location.Y + pBox.Height
        myVector.seqNumber = Vectors.Count + 1
        myVector.DrawingID = _DocumentID
        myVector.itmSelected = True
        myVector.DateCreated = Now
        myVector.pBox = pBox

        '        myVector.Opaque = IIf(btnMarking.Checked, True, False)
        '       myVector.boundRectangle = New Rectangle(Control.MousePosition, pBox.Size)
        myVector.OrgScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
        myVector.OrgScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
        Vectors.Add(New EditDaqumentUtil.VectorMap(myVector))
        AddBoundryBox(myVector)
        '        AddHandler pBox.MouseClick, AddressOf SelectedBox_MouseClick
        'AddHandler pBox.PreviewKeyDown, AddressOf SelectedPitcureBox_PreviewKeyDown
        '        AddHandler pBox.DoubleClick, AddressOf SelectedBox_DoubleClick
        Dim act As UserAction = New UserAction(UserAction.ActionType.Add, myVector.vectorID)
        UserActionList.Add(act)
        Return myVector

    End Function
    Private Sub AddBoundryBox(ByVal vec As EditDaqumentUtil.Vector)

        Dim Width As Integer = Math.Abs(vec.StartPointX - vec.endPointX)
        Dim Height As Integer = Math.Abs(vec.StartPointY - vec.endPointY)
        Dim rect As Rectangle = New Rectangle(vec.StartPointX, vec.StartPointY, Width, Height)

        If vec.VectorObjectType = "Line" Then
            For i As Integer = 0 To 1
                Dim pic As PictureBox = New PictureBox
                pic.Size = New Size(8, 8)
                If i = 0 Then
                    pic.Location = New Point(vec.StartPointX, vec.StartPointY)
                Else
                    pic.Location = New Point(vec.endPointX, vec.endPointY)
                End If
                pic.BorderStyle = BorderStyle.FixedSingle
                PictureBox1.Controls.Add(pic)
                pic.BringToFront()
                pic.Visible = True
                Dim sCtrl As SeqControl
                sCtrl.Ctrl = pic : sCtrl.seqNumber = vec.seqNumber
                sCtrl.vecID = vec.vectorID
                tmpControls.Add(sCtrl)
            Next
            Return
        End If
        Dim picCtr = 0
        Dim lineTipCtr = 0

        Dim loc() As Point = { _
                New Point(rect.X - 8, rect.Y - 8), New Point(rect.X - 2 + rect.Width / 2, rect.Y - 4), _
                New Point(rect.X + rect.Width, rect.Y - 4), New Point(rect.X - 4, rect.Y - 2 + rect.Height / 2), _
                New Point(rect.X + rect.Width, rect.Y - 2 + rect.Height / 2), New Point(rect.X - 4, rect.Y + rect.Height), _
                New Point(rect.X - 2 + rect.Width / 2, rect.Y + rect.Height), New Point(rect.X + rect.Width, rect.Y + rect.Height)}
        Dim side() As Size = {New Size(8, 8), New Size(4, 4), New Size(4, 4), New Size(4, 4), _
                New Size(4, 4), New Size(4, 4), New Size(4, 4), New Size(4, 4)}
        For i As Integer = 0 To 7
            Dim pic As PictureBox = New PictureBox
            pic.Size = side(i)
            pic.Location = loc(i)
            pic.Name = "pic-" + vec.vectorID.ToString + "-" + i.ToString
            Dim bmp = New Bitmap(pic.Size.Width, pic.Size.Height)
            Dim g As Graphics = Graphics.FromImage(bmp)
            Dim customColor As Color = Color.FromArgb(200, Color.Black)
            'Dim myPen As New Pen(New SolidBrush(customColor), 4)
            g.FillRectangle(New SolidBrush(customColor), 0, 0, pic.Bounds.Width, pic.Bounds.Height)
            pic.Image = bmp
            'Dim backColor As Color = bmp.GetPixel(1, 1)
            ''TestPicBox.Image.Dispose()
            'bmp.MakeTransparent(backColor)
            'g.DrawImage(bmp, 0, 0)
            PictureBox1.Controls.Add(pic)
            Dim sCtrl As SeqControl
            sCtrl.Ctrl = pic : sCtrl.seqNumber = vec.seqNumber
            sCtrl.vecID = vec.vectorID
            tmpControls.Add(sCtrl)
            AddHandler pic.MouseHover, AddressOf TestPicBox_MouseHover
            AddHandler pic.MouseDown, AddressOf TestPicBox_MouseDown
            AddHandler pic.MouseMove, AddressOf TestPicBox_MouseMove
            AddHandler pic.MouseUp, AddressOf TestPicBox_MouseUp
            AddHandler pic.MouseLeave, AddressOf TestPicBox_MouseLeave
        Next
        '                vec.boundRectangle = New Rectangle(New Point(vec.StartPointX, vec.StartPointY), New Size(Width, Height))
        ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec), Me.BackColor, FrameStyle.Dashed)

    End Sub

    Private Function vectorScreenBoundRectangle(ByVal vec As EditDaqumentUtil.Vector) As Rectangle
        Dim Width As Integer = Math.Abs(vec.StartPointX - vec.endPointX)
        Dim Height As Integer = Math.Abs(vec.StartPointY - vec.endPointY)

        Dim vecRectangle As Rectangle = New Rectangle(PointToScreen(New Point(vec.StartPointX + ScreenOffsetX, vec.StartPointY + ScreenOffsetY)), _
                New Size(Width, Height))
        Return vecRectangle
    End Function
    Private Sub TestPicBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return

        ClearAllSelectedItems()

        If daqMode = EditDaqumentUtil.mode.None Then
            daqMode = EditDaqumentUtil.mode.ObjectSelected
            '            AddBoundryBox()
        End If
        If daqMode = EditDaqumentUtil.mode.ObjectSelected Then
            dragStartPoint = Control.MousePosition
        End If
        Dim vectorID As Integer = CType(Split(CType(sender, Control).Name, "-")(1), Integer)
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.vectorID = vectorID Then
                Dim act As UserAction = New UserAction(UserAction.ActionType.Modify, vec.vectorID, vec.thisVector)
                UserActionList.Add(act)
                Exit Sub
            End If
        Next
    End Sub
    Private Sub TestPicBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Dim vectorID As Integer = CType(Split(CType(sender, Control).Name, "-")(1), Integer)
        If daqMode = EditDaqumentUtil.mode.ObjectSelected Then
            daqMode = EditDaqumentUtil.mode.DragObject
            'For Each ctrl As SeqControl In tmpControls
            '    ctrl.Ctrl.Visible = False
            'Next
            'PictureBox1.Refresh()
            ''            dragStartPoint = Control.MousePosition
        End If
        If daqMode = EditDaqumentUtil.mode.DragObject Then
            'Dim dragX = Control.MousePosition.X - dragStartPoint.X
            'Dim dragY = Control.MousePosition.Y - dragStartPoint.Y
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.itmSelected Then
                    If vec.vectorID = vectorID Then
                        ComputDragLocation(sender, vec)
                        Exit Sub
                    End If
                    'ControlPaint.DrawReversibleFrame(vectorBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
                    'Dim newLoc As Point = New Point(vectorBoundRectangle(vec.thisVector).X + dragX, vectorBoundRectangle(vec.thisVector).Y + dragY)
                    'vectorBoundRectangle(vec.thisVector) = New Rectangle(newLoc, vectorBoundRectangle(vec.thisVector).Size)
                    'ControlPaint.DrawReversibleFrame(vectorBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
                End If
            Next
        End If
    End Sub
    Private Sub TestPicBox_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PictureBox1.Cursor = Cursors.Default
    End Sub

    Private Sub TestPicBox_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim myControl As Control = sender
        Dim picPosition As String = Split(myControl.Name, "-")(2)
        If picPosition = "0" Then
            PictureBox1.Cursor = Cursors.Hand
        ElseIf picPosition = "1" Then
            PictureBox1.Cursor = Cursors.SizeNS
        ElseIf picPosition = "2" Then
            PictureBox1.Cursor = Cursors.SizeNESW
        ElseIf picPosition = "3" Then
            PictureBox1.Cursor = Cursors.SizeWE
        ElseIf picPosition = "4" Then
            PictureBox1.Cursor = Cursors.SizeWE
        ElseIf picPosition = "5" Then
            PictureBox1.Cursor = Cursors.SizeNESW
        ElseIf picPosition = "6" Then
            PictureBox1.Cursor = Cursors.SizeNS
        ElseIf picPosition = "7" Then
            PictureBox1.Cursor = Cursors.SizeNWSE
        End If
        PictureBox1.Refresh()
    End Sub
    Private Sub TestPicBox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If daqMode = EditDaqumentUtil.mode.DragObject Then
            Dim vectorID As Integer = CType(Split(CType(sender, Control).Name, "-")(1), Integer)
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.vectorID = vectorID Then
                    vec.VectorModified = True
                    ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
                    If vec.VectorObjectType = "Pic" Then
                        vec.pBox.Size = vectorScreenBoundRectangle(vec.thisVector).Size
                        vec.pBox.Location = New Point(vec.StartPointX, vec.StartPointY)
                        Dim newW = vec.pBox.Size.Width : Dim newH = vec.pBox.Size.Height
                        Dim img As Image = myDoc.ResizeImage(vec.vectorImage, New Size(newW, newH))
                        vec.pBox.Image.Dispose()
                        vec.pBox.Image = img
                        vec.VectorType = EditDaqumentUtil.mode.EmbedImage
                    End If
                    embedLayerObject(vec.thisVector)
                    ClearSelectedBoundryBox(vec)
                    vec.pBox.Visible = False
                    daqMode = EditDaqumentUtil.mode.None
                    Redraw()
                    PictureBox1.Cursor = Cursors.Default
                    PictureBox1.Refresh()
                    Exit Sub
                End If
            Next
            '            AddBoundryBox()
        End If
    End Sub
    Private Function GetSeqCtrl(ByVal seq As Integer) As Integer
        For i As Integer = 0 To tmpControls.Count - 1
            If tmpControls(i).seqNumber = seq Then Return i
        Next
        Return -1
    End Function
    Private Sub ClearAllSelectedItems()

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            vec.itmSelected = False
        Next
        Dim i As Integer = 0
        For Each sCtrl As SeqControl In tmpControls
            sCtrl.Ctrl.Dispose()
        Next
        tmpControls.Clear()
    End Sub
    Private Sub ClearSelectedBoundryBox(ByVal vec As EditDaqumentUtil.VectorMap)
        Dim i As Integer = 0
        While i >= 0
            i = GetSeqCtrl(vec.seqNumber)
            If i >= 0 Then
                tmpControls(i).Ctrl.Dispose()
                tmpControls.RemoveAt(i)
            End If
        End While
        vec.itmSelected = False

        localStartPoint = New Point(0, 0)
        theRectangle.Location = New Point(0, 0)
        theRectangle.Size = New Size(0, 0)

    End Sub


    Private Sub printDoc_BeginPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        intPageCounter = 0
    End Sub

    Private Sub printDoc_EndPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
    End Sub
    Private Sub MakePrintImages()
        'daqumentRefresh()
        Dim img As Image = PictureBox1.Image.Clone
        Dim PprSize As PaperSize = printDoc.DefaultPageSettings.PaperSize()
        Dim pprWidth = PprSize.Width
        Dim pprHeight = PprSize.Height
        If printDoc.DefaultPageSettings.Landscape Then
            pprWidth = PprSize.Height
            pprHeight = PprSize.Width
        Else
            pprWidth = PprSize.Width
            pprHeight = PprSize.Height
        End If
        '        If img.Width > img.Height Then
        ' img.RotateFlip(RotateFlipType.Rotate90FlipNone)
        'End If

        For Each mg As Image In _PrintImages
            mg.Dispose()
        Next
        _PrintImages.Clear()
        Dim DoResize As Boolean = False

        If pprWidth <> img.Width Or pprHeight <> img.Height Then
            Dim rslt As DialogResult = MessageBox.Show("The default paper size does nat match; do you wish to resize image?", "Paper Size", MessageBoxButtons.YesNo)
            If rslt = Windows.Forms.DialogResult.Yes Then
                DoResize = True
            End If
        End If
        If DoResize Then
            _PrintImages.Add(myDoc.ResizeImage(New Size(pprWidth, pprHeight)))
        Else
            _PrintImages.Add(img)
        End If

    End Sub
    Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        Dim img As Image = _PrintImages(intPageCounter)
        e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height)
        e.HasMorePages = False
        intPageCounter = 0

    End Sub

    Private Sub cms1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms1.Opening
        If daqMode <> EditDaqumentUtil.mode.None Then Return
        cms1Loc = New Point(Control.MousePosition.X, Control.MousePosition.Y)

        ' Acquire references to the owning control and item.
        Dim c As Control = cms1.SourceControl
        Dim tsi As ToolStripDropDownItem = cms1.OwnerItem
        If (c IsNot Nothing) Then
            If c.Name <> "PictureBox1" Then Return
        End If
        If theRectangle.Size.Width = 0 Or theRectangle.Size.Height = 0 Then
            If Not cmsPictureBox.Image Is Nothing Then
                cms1.Items.Clear()
                cms1.Items.Add("-")
                cms1.Items.Add("Paste")
            End If
            Return
        Else
            ' Populate the ContextMenuStrip control with its default items.
            'If (theRectangle.Size.Width = 0 Or theRectangle.Size.Height = 0) Then Return
            cms1.Items.Clear()
            cms1.Items.Add("-")
            cms1.Items.Add("Cut")
            cms1.Items.Add("Copy")
            If Not cmsPictureBox.Image Is Nothing Then
                cms1.Items.Add("Paste")
            End If
        End If
        e.Cancel = False
    End Sub

    Private Sub cms1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cms1.ItemClicked
        Dim ScreenPoint As Point = cms1.Bounds.Location
        Dim ClientPoint As Point = PointToClient(cms1.Bounds.Location)
        Dim ClientPointF As PointF = CType(ClientPoint, PointF)
        Dim tsi As ToolStripDropDownItem = e.ClickedItem
        'If Not LayerSelected() Then
        '    Return
        'End If

        ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
        If tsi.Text = "Cut" Then
            Dim bm = New Bitmap(theRectangle.Size.Width, theRectangle.Size.Height)
            Dim picCanvas As Graphics = Graphics.FromImage(bm)
            picCanvas.CopyFromScreen(theRectangle.Location, New Point(0, 0), theRectangle.Size)
            If Not cmsPictureBox.Image Is Nothing Then
                cmsPictureBox.Image.Dispose()
            End If
            cmsPictureBox.Image = bm
            cmsPictureBox.Size = theRectangle.Size


            Dim bm1 = New Bitmap(theRectangle.Size.Width, theRectangle.Size.Height)
            Dim cutCanvas As Graphics = Graphics.FromImage(bm1)
            cutCanvas.FillRectangle(Brushes.White, 0, 0, theRectangle.Size.Width, theRectangle.Size.Height)
            If Not PicBox2.Image Is Nothing Then
                PicBox2.Image.Dispose()
            End If
            PicBox2.Image = bm1
            PicBox2.Size = theRectangle.Size
            daqMode = EditDaqumentUtil.mode.InsertImage
            Dim vect As EditDaqumentUtil.Vector = MakeNewPictureImageVector(PictureBox1.PointToClient(theRectangle.Location))
            embedLayerObject(vect)
            vect.pBox.Visible = False
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                ClearSelectedBoundryBox(vec)
                vec.itmSelected = False
            Next
            daqMode = EditDaqumentUtil.mode.None
            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
        ElseIf tsi.Text = "Copy" Then
            '            Dim myRect As Rectangle = theRectangle

            Dim bm = New Bitmap(theRectangle.Size.Width, theRectangle.Size.Height)
            Dim picCanvas As Graphics = Graphics.FromImage(bm)
            picCanvas.CopyFromScreen(theRectangle.Location, New Point(0, 0), theRectangle.Size)
            If Not cmsPictureBox.Image Is Nothing Then
                cmsPictureBox.Image.Dispose()
            End If
            cmsPictureBox.Image = bm
            cmsPictureBox.Size = theRectangle.Size

            If Not PicBox2.Image Is Nothing Then
                PicBox2.Image.Dispose()
            End If
            PicBox2.Image = bm
            PicBox2.Size = theRectangle.Size


        ElseIf tsi.Text = "Paste" Then
            If Not PicBox2.Image Is Nothing Then
                PicBox2.Image.Dispose()
            End If
            PicBox2.Size = theRectangle.Size
            PicBox2.Image = cmsPictureBox.Image.Clone
            daqMode = EditDaqumentUtil.mode.InsertImage
            MakeNewPictureImageVector(ClientPoint)
            daqMode = EditDaqumentUtil.mode.ObjectSelected
        End If

        PictureBox1.Refresh()

    End Sub
    Private Sub EditDaqument_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If daqMode = EditDaqumentUtil.mode.ObjectSelected Then
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.itmSelected Then
                    Dim objMoved As Boolean = False
                    Dim X = vectorScreenBoundRectangle(vec.thisVector).X : Dim Y = vectorScreenBoundRectangle(vec.thisVector).Y
                    If e.KeyCode = Keys.Escape Then
                        vec.ObjectDeleted = True
                    End If
                    If e.KeyCode = Keys.Delete Then
                        vec.ObjectDeleted = True
                    End If
                    If e.KeyCode = Keys.Left Then
                        X = X - 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Right Then
                        X = X + 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Up Then
                        Y = Y - 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Down Then
                        Y = Y + 1 : objMoved = True
                    End If
                    If objMoved Or vec.ObjectDeleted Then
                        vec.VectorModified = True
                        'ResizeObject(vec)
                    End If
                End If
            Next

        End If
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                For Each sCtrl As SeqControl In tmpControls
                    If sCtrl.vecID = vec.vectorID Then
                        vec.ObjectDeleted = True
                        If Not vec.tBox Is Nothing Then
                            vec.tBox.Visible = False
                        End If
                        If Not vec.pBox Is Nothing Then
                            vec.pBox.Visible = False
                        End If
                    End If
                Next
            Next
            ClearAllSelectedItems()
            Redraw()
            PictureBox1.Refresh()
        End If

    End Sub
    'Public Sub RemoveWeldPoint(ByVal WeldTagNo As String, ByVal DrawingID As Integer)
    '    Dim qry = "USE [" + runtime.selectedProject + "] DELETE From tblWeldTracking WHERE TagNo = " + WeldTagNo + " AND DrawingID = " + _DocumentID.ToString
    '    Utilities.ExecuteRemoteNonQuery(qry, "No Weld Lisat")
    'End Sub

    Private Sub SaveLayerObjects()
        Dim layerCtr As Integer = 0
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            For Each dr As DataRow In tblWeldTracking.Rows
                If dr("TagNo") = vec.text And vec.VectorModified Then
                    vec.lastUser = runtime.UserMUID
                    vec.VectorModified = False
                    dr("DateEntered") = Now().Date
                    If Not vec.ObjectDeleted And vec.SQLID = "" Then
                        'myDoc.SaveLayerVector(vec)
                        'myDoc.InsertWeldPoint(dr)
                    ElseIf Not vec.ObjectDeleted And Not vec.SQLID = "" Then
                        'myDoc.UpdateLayerVector(vec)
                        'myDoc.UpdateWeldPoint(dr)
                    ElseIf vec.ObjectDeleted And Not vec.SQLID = "" Then
                        'myDoc.DeleteLayerVector(vec)
                        'myDoc.RemoveWeldPoint(dr)
                    End If
                End If
            Next
        Next
    End Sub
    Private Sub loadWeldPointsLayerVectors(ByVal layerID As Integer)
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If Not vec.pBox Is Nothing Then
                vec.pBox.Image.Dispose()
            End If
            If Not vec.vectorImage Is Nothing Then
                vec.vectorImage.Dispose()
            End If
        Next
        If Not tblWeldTracking Is Nothing Then
            tblWeldTracking.Dispose()
        End If
        tblWeldTracking = myDoc.WeldPointInfoTable.Copy
        Vectors.Clear()
        myDoc.LoadLayerVectors(layerID)
        Dim picSize As Size = PictureBox1.Size
        Dim orgSize As Size = myDoc.OriginalDrawingSize
        Dim magX As Single = (picSize.Width / orgSize.Width) : Dim magY As Single = (picSize.Height / orgSize.Height)
        For Each vec As EditDaqumentUtil.Vector In myDoc.LayerVectorArray
            Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector
            VectorIDCtr = VectorIDCtr + 1
            myVector.vectorID = CType(vec.text, Int32)
            myVector.layerID = vec.layerID
            myVector.SQLID = vec.SQLID
            myVector.VectorModified = False
            myVector.VectorType = vec.VectorType
            myVector.CabinetID = vec.CabinetID
            myVector.ObjectDeleted = False
            myVector.ObjectMode = vec.ObjectMode
            myVector.OrgScaleX = vec.OrgScaleX
            myVector.OrgScaleY = vec.OrgScaleY
            myVector.OrgStartPointX = vec.OrgStartPointX
            myVector.OrgStartPointY = vec.OrgStartPointY
            myVector.OrgEndPointX = vec.OrgEndPointX
            myVector.OrgEndPointY = vec.OrgEndPointY
            myVector.OrgLineWidth = vec.OrgLineWidth
            myVector.StartPointX = vec.OrgStartPointX
            myVector.StartPointY = vec.OrgStartPointY
            myVector.endPointX = vec.OrgEndPointX
            myVector.endPointY = vec.OrgEndPointY


            Dim newScaleX = magX / vec.OrgScaleX
            Dim newScaleY = magY / vec.OrgScaleY



            myVector.StartPointX = vec.OrgStartPointX * newScaleX
            myVector.StartPointY = vec.OrgStartPointY * newScaleY

            myVector.endPointX = vec.OrgEndPointX * newScaleX
            myVector.endPointY = vec.OrgEndPointY * newScaleY
            myVector.ScaledLineWidth = vec.OrgLineWidth * newScaleY

            myVector.seqNumber = vec.seqNumber
            myVector.DrawingID = vec.DrawingID
            myVector.text = vec.text
            myVector.penArgb = vec.penArgb
            myVector.lineEnd = vec.lineEnd
            myVector.itmSelected = False
            myVector.DateCreated = vec.DateCreated
            myVector.VectorObjectType = vec.VectorObjectType
            If vec.VectorObjectType = "Pic" Then
                myVector.VectorImage = vec.VectorImage
                Dim pBox As PictureBox = New PictureBox()
                pBox.Name = VectorIDCtr.ToString
                pBox.Image = myVector.VectorImage.Clone
                pBox.Size = pBox.Image.Size
                pBox.BringToFront()
                pBox.Location = New Point(myVector.StartPointX, myVector.StartPointY)
                '            PictureBox1.Controls.Add(pBox)
                myVector.pBox = pBox
            End If
            Vectors.Add(New EditDaqumentUtil.VectorMap(myVector))
        Next
    End Sub
    Private Sub RemoveLayerVectorImages(ByVal vec As EditDaqumentUtil.VectorMap)
        If Not vec.pBox Is Nothing Then
            vec.pBox.Image.Dispose()
            vec.pBox.Dispose()
        End If
        If Not vec.pBox Is Nothing Then
            vec.pBox.Image.Dispose()
            vec.pBox.Dispose()
        End If
        If Not vec.vectorImage Is Nothing Then
            vec.vectorImage.Dispose()
        End If
    End Sub
    'Private Sub SelectLayerVectors()
    '    Dim Ask As Boolean = True
    '    Dim doSave As Boolean = False
    '    Dim LayerID As Integer = 0
    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        If vec.VectorModified Then
    '            LayerID = vec.layerID
    '            If Ask Then
    '                Ask = False
    '                Dim rslt = MessageBox.Show("Do wish to save the new objects added to the layer?", "Save Objects", MessageBoxButtons.YesNoCancel)
    '                If rslt = Windows.Forms.DialogResult.Cancel Then Return
    '                If rslt = Windows.Forms.DialogResult.Yes Then
    '                    doSave = True
    '                    Exit For
    '                End If
    '            End If
    '        End If
    '    Next
    '    If doSave Then SaveObjects(LayerID)
    '    For Each vec As EditDaqumentUtil.VectorMap In Vectors
    '        RemoveLayerVectorImages(vec)
    '    Next
    '    Vectors.Clear()
    '    '        RedoList.Clear()
    '    VectorIDCtr = 0
    '    Dim layerCtr As Integer = 0
    '    Redraw()
    'End Sub
    Private Function requestToSaveLayer() As Windows.Forms.DialogResult
        Dim Ask As Boolean = True
        Dim doSave As Boolean = False
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorModified Then
                If Ask Then
                    Ask = False
                    Return (MessageBox.Show("Weld objects have been added to the layer; would you like to save them?", "Save Objects", MessageBoxButtons.YesNoCancel))
                End If
            End If
        Next
    End Function
    'Private Sub CreateWeldLayers()

    '    myDoc.AddNewLayer("New Welds", "Weld Tracking")
    '    myDoc.AddNewLayer("Reject Welds", "Weld Tracking")
    '    myDoc.AddNewLayer("Completed Welds", "Weld Tracking")
    '    myDoc.AddNewLayer("Field Welds", "Weld Tracking")
    '    '        myDoc.AddNewLayer("Rework Welds", "Weld Tracking")
    'End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveLayerObjects()
        '        Me.loadWeldPointsLayerVectors(myDoc.GetLayerID("Welds"))
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        daqMode = EditDaqumentUtil.mode.None
        PictureBox1.Cursor = Cursors.Default
        ClearAllSelectedItems()
        Me.PictureBox1.Invalidate()
        Me.Refresh()
        Me.Focus()


    End Sub

    'Private Sub btnLineDraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not LayerSelected() Then
    '        Return
    '    End If
    '    'daqumentRefresh()
    '    daqMode = EditDaqumentUtil.mode.lineDraw
    '    PictureBox1.Cursor = Cursors.Cross
    'End Sub
    'Private Sub btnFreehand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not LayerSelected() Then
    '        Return
    '    End If
    '    '    daqumentRefresh()
    '    daqMode = EditDaqumentUtil.mode.FreeHand
    '    PictureBox1.Cursor = Cursors.UpArrow
    'End Sub

    Private Sub btnInsertImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertImage.Click
        'If Not LayerSelected() Then
        '    Return
        'End If
        PicBox2.Image = Me.btnInsertImage.Image.Clone
        If PicBox2.Image.Size.Height = 0 Or PicBox2.Image.Size.Width = 0 Then
            MessageBox.Show("Invalid image size")
            Return
        End If
        If PicBox2.Image.Size.Height >= PictureBox1.Image.Size.Height Or _
            PicBox2.Image.Size.Width >= PictureBox1.Image.Size.Width Then
            MessageBox.Show("Image size is larger then the current frame setting")
            Return
        End If
        PictureBox1.Cursor = Cursors.Cross
        If Not picBoxDragHandle.Image Is Nothing Then
            picBoxDragHandle.Image.Dispose()
        End If
        picBoxDragHandle.Image = Me.btnInsertImage.Image.Clone
        picBoxDragHandle.Visible = False
        PicBox2.Size = PicBox2.Image.Size
        PicBox2.Visible = False
        daqMode = EditDaqumentUtil.mode.InsertImage
    End Sub


    'Private Sub btnInsertText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not LayerSelected() Then
    '        Return
    '    End If
    '    'daqumentRefresh()
    '    daqMode = EditDaqumentUtil.mode.InsertText
    '    PictureBox1.Cursor = Cursors.Cross
    '    picBoxDragHandle.Image = Global.Daqument.My.Resources.Resources.Text_Document
    '    picBoxDragHandle.Visible = False

    'End Sub

    Private Sub btnWidth1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth1.Click
        btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width1
        CurrentLineWidth = 1
    End Sub

    Private Sub btnWidth2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth2.Click
        btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width2
        CurrentLineWidth = 2
    End Sub

    Private Sub btnWidth3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth3.Click
        btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width3
        CurrentLineWidth = 4
    End Sub

    Private Sub btnWidth4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth4.Click
        btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width4
        CurrentLineWidth = 8
    End Sub

    Private Sub btnWidth5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth5.Click
        btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width5
        CurrentLineWidth = 15
    End Sub

    Private Sub btnColorRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorRed.Click
        btnWeldSelect.BackColor = ColorRedHilite
        Dim myBackColor As Color = btnWeldSelect.BackColor
        btnWeldSelect.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)
        btnWeldSelect.Text = btnColorRed.Text
        If VerifyWeldParameters() Then
            SelectBtnInsertImage()
        End If
        btnInsertImage.Enabled = False
    End Sub

    Private Sub btnColorBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorBlue.Click
        btnWeldSelect.BackColor = ColorBlueHilite
        Dim myBackColor As Color = btnWeldSelect.BackColor
        btnWeldSelect.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)
        btnWeldSelect.Text = btnColorBlue.Text
        SelectBtnInsertImage()
        btnInsertImage.Enabled = True
    End Sub

    Private Sub btnColorGreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorGreen.Click
        btnWeldSelect.BackColor = ColorGreenHilite
        Dim myBackColor As Color = btnWeldSelect.BackColor
        btnWeldSelect.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)
        btnWeldSelect.Text = btnColorGreen.Text
        If VerifyWeldParameters() Then
            SelectBtnInsertImage()
        End If
        btnInsertImage.Enabled = False

    End Sub
    Private Sub btnColorYellow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorYellow.Click
        btnWeldSelect.BackColor = ColorYellowHilite
        Dim myBackColor As Color = btnWeldSelect.BackColor
        btnWeldSelect.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)
        btnWeldSelect.Text = btnColorYellow.Text
        If VerifyWeldParameters() Then
            SelectBtnInsertImage()
        End If
        btnInsertImage.Enabled = False
    End Sub
    Private Sub InspectWeldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColorOrange.Click
        btnWeldSelect.BackColor = ColorOrangeHilite
        Dim myBackColor As Color = btnWeldSelect.BackColor
        btnWeldSelect.ForeColor = Color.FromArgb(255, Not myBackColor.R, Not myBackColor.G, Not myBackColor.B)
        btnWeldSelect.Text = btnColorOrange.Text
        SelectBtnInsertImage()
        btnInsertImage.Enabled = False
    End Sub

    Private Sub btnEnlarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
                If vec.itmSelected Then
                    Dim myFontSize As Single = vec.tBox.Font.Size
                    If vec.tBox.Font.Size < 72 Then
                        Dim myFont = New Font(vec.tBox.Font.FontFamily, vec.tBox.Font.Size + 1, _
                                    System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
                        vec.tBox.Font = myFont
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub btnReduce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
                If vec.itmSelected Then
                    Dim myFontSize As Single = vec.tBox.Font.Size
                    If vec.tBox.Font.Size > 4 Then
                        Dim myFont = New Font(vec.tBox.Font.FontFamily, vec.tBox.Font.Size - 1, _
                                    System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
                        vec.tBox.Font = myFont
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub btnDrag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrag.Click
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            ' ClearSelectedBoundryBox(vec)
        Next

        PreviousAnchorPoint = PictureBox1.Location
        daqMode = EditDaqumentUtil.mode.Drag
        '        embedAllObjects()
        PictureBox1.Cursor = Cursors.NoMove2D
    End Sub

    Private Sub btn500_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn500.Click
        If ResizeDrawingView(5, 5) Then
            Me.btnMaginfy.Text = String.Format("500%")
        End If
    End Sub

    Private Sub btn200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn200.Click
        If ResizeDrawingView(2, 2) Then
            Me.btnMaginfy.Text = String.Format("200%")
        End If
    End Sub

    Private Sub btn150_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn150.Click
        If ResizeDrawingView(1.5, 1.5) Then
            Me.btnMaginfy.Text = String.Format("150%")
        End If
    End Sub

    Private Sub btn100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn100.Click
        If ResizeDrawingView(1, 1) Then
            Me.btnMaginfy.Text = String.Format("100%")
        End If
    End Sub

    Private Sub btn75_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn75.Click
        If ResizeDrawingView(0.75, 0.75) Then
            Me.btnMaginfy.Text = String.Format("75%")
        End If
    End Sub

    Private Sub btn50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn50.Click
        If ResizeDrawingView(0.5, 0.5) Then
            Me.btnMaginfy.Text = String.Format("50%")
        End If
    End Sub

    Private Sub btn25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn25.Click
        If ResizeDrawingView(0.25, 0.25) Then
            Me.btnMaginfy.Text = String.Format("25%")
        End If
    End Sub
    Private Sub btnPageWidth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageWidth.Click
        ResizePageWidth()
    End Sub


    Private Sub TestingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EditDaqument_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim rslt = Me.requestToSaveLayer()
        If rslt = Windows.Forms.DialogResult.Cancel Then
            e.Cancel = True
            Return
        End If
        If rslt = Windows.Forms.DialogResult.Yes Then
            SaveLayerObjects()
        End If
    End Sub
    Private Sub btnRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedo.Click
        Dim CurrentSeqNumber = 0
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.ObjectDeleted Then
                CurrentSeqNumber = vec.seqNumber
            End If
        Next
        If CurrentSeqNumber = 0 Then Return

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.seqNumber = CurrentSeqNumber Then
                vec.ObjectDeleted = False
            End If
        Next
        Redraw()

    End Sub

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        Dim CurrentSeqNumber = 0
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If Not vec.ObjectDeleted Then
                CurrentSeqNumber = vec.seqNumber
            End If
        Next
        If CurrentSeqNumber = 0 Then Return

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.seqNumber = CurrentSeqNumber Then
                vec.ObjectDeleted = True
            End If
        Next
        Redraw()
    End Sub

    'Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
    '    If UserActionList.Count > 0 Then
    '        Dim act As UserAction = UserActionList(UserActionList.Count - 1)
    '        Dim oldVec As EditDaqumentUtil.Vector
    '        For Each myVector As EditDaqumentUtil.VectorMap In Vectors
    '            If myVector.vectorID = oldVec.vectorID Then
    '                myVector.VectorModified = oldVec.VectorModified
    '                myVector.ObjectDeleted = False
    '                myVector.OrgScaleX = oldVec.OrgScaleX
    '                myVector.OrgScaleY = oldVec.OrgScaleY
    '                myVector.OrgStartPointX = oldVec.OrgStartPointX
    '                myVector.OrgStartPointY = oldVec.OrgStartPointY
    '                myVector.OrgEndPointX = oldVec.OrgEndPointX
    '                myVector.OrgEndPointY = oldVec.OrgEndPointY
    '                myVector.OrgLineWidth = oldVec.OrgLineWidth
    '                myVector.StartPointX = oldVec.StartPointX
    '                myVector.StartPointY = oldVec.StartPointY
    '                myVector.endPointX = oldVec.endPointX
    '                myVector.endPointY = oldVec.endPointY
    '                myVector.ScaledlineWidth = oldVec.ScaledLineWidth
    '                myVector.penArgb = oldVec.penArgb
    '                myVector.lineEnd = oldVec.lineEnd
    '            End If
    '        Next
    '    Else
    '        For i As Integer = Vectors.Count - 1 To 0 Step -1
    '            If Not Vectors(i).ObjectDeleted Then
    '                Dim vecID = Vectors(i).vectorID
    '                For Each myVector As EditDaqumentUtil.VectorMap In Vectors
    '                    If myVector.vectorID = vecID Then
    '                        myVector.ObjectDeleted = True
    '                    End If
    '                Next
    '            End If
    '        Next
    '    End If
    '    Redraw()
    'End Sub

    'Private Sub btnRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedo.Click
    '    For i As Integer = Vectors.Count - 1 To 0 Step -1
    '        If Not Vectors(i).ObjectDeleted Then
    '            Dim vecID = Vectors(i).vectorID
    '            For Each myVector As EditDaqumentUtil.VectorMap In Vectors
    '                If myVector.vectorID = vecID Then
    '                    myVector.ObjectDeleted = True
    '                End If
    '            Next
    '        End If
    '    Next
    'End Sub



    Public Sub New(ByVal ThisDocument As Integer, ByVal DocumentName As String)
        Me.InitializeComponent()
        _DocumentID = ThisDocument
        _DocumentName = DocumentName
        'Dim useStr = "USE [" + runtime.selectedProject + "] "
        'Dim qry As String = "SELECT AdvancedTesting,Area,BHN,TagNo,System,TestPkgNo,SpoolTo,SpoolFrom,PipeSize," + _
        '            "WeldInches,ForemanName,SVCSPEC,WPS,NDEPcntReq,Material,WallThk,WeldType," + _
        '            "WeldStn,NDEType,TestResult,VisInspName,PWHT,Comments,DrawingID, DWGNO,ID"
        'tblWeldTracking = daqartDLL.Utilities.ExecuteRemoteQuery(useStr + qry + " FROM tblWeldTracking WHERE DrawingID =" + _DocumentID.ToString, "No Welders List")

    End Sub
    Private Sub LoadDefaultWeldPointParameters()
        Me.defaultWeld.Disc = "Weld"
        Me.defaultWeld.AdvancedTesting = ""
        Me.defaultWeld.Area = ""
        Me.defaultWeld.BHN = ""
        Me.defaultWeld.TagNo = ""
        Me.defaultWeld.System = ""
        Me.defaultWeld.DWGNO = _DocumentName
        Me.defaultWeld.DrawingID = _DocumentID
        Me.defaultWeld.TestPkgNo = ""
        Me.defaultWeld.EnteredBy = ""
        Me.defaultWeld.DateEntered = Now.Date
        Me.defaultWeld.SpoolTo = ""
        Me.defaultWeld.SpoolFrom = ""
        Me.defaultWeld.PipeSize = ""
        Me.defaultWeld.ConstCode = ""
        Me.defaultWeld.WeldInches = ""
        Me.defaultWeld.ForemanName = ""
        Me.defaultWeld.SVCSPEC = ""
        Me.defaultWeld.WPS = ""
        Me.defaultWeld.NDEPcntReq = ""
        Me.defaultWeld.Material = ""
        Me.defaultWeld.WallThk = ""
        Me.defaultWeld.WeldType = ""
        Me.defaultWeld.WeldStn = ""
        Me.defaultWeld.NDEType = ""
        Me.defaultWeld.DateTested = ""
        Me.defaultWeld.AdvancedTesting = ""
        Me.defaultWeld.TestResult = ""
        Me.defaultWeld.VisInspDate = ""
        Me.defaultWeld.VisInspName = ""
        Me.defaultWeld.PMIDate = ""
        Me.defaultWeld.PMIResult = ""
        Me.defaultWeld.RejInches = ""
        Me.defaultWeld.PWHT = ""
        Me.defaultWeld.BHN = ""
        Me.defaultWeld.Comments = ""
        Me.defaultWeld.Revision = ""
        Me.defaultWeld.ID = "0"

    End Sub
    Private Sub ShowParameterTable(ByVal info As String)
        Dim qry As String = ""
        Select Case info
            Case "Disc"
            Case "AdvancedTesting"
            Case "Area"
                qry = " SELECT DISTINCT Area FROM tblSpoolList "
            Case "TagNo"
                qry = " SELECT TagNo, System, Area FROM tblSpoolList "
            Case "System"
                qry = " SELECT DISTINCT System FROM tblSpoolList "
            Case "TestPkgNo"
                qry = " SELECT PackageNumber As TestPkgNo, SystemNumber, Description FROM package "
            Case "EnteredBy"
            Case "DateEntered"
            Case "SpoolTo"
                qry = " SELECT TagNo As SpoolTo, System, Area FROM tblSpoolList "
            Case "SpoolFrom"
                qry = " SELECT TagNo As SpoolFrom, System, Area FROM tblSpoolList "
            Case "PipeSize"
                qry = " SELECT PipeSize, InchesOfWeld, Diameter FROM tblWeldInchesEQLookup "
            Case "ConstCode"
                qry = " SELECT DISTINCT ConstCode FROM tblWeldTracking "
            Case "WeldInches"
                qry = " SELECT InchesOfWeld As WeldInches, PipeSize, Diameter FROM tblWeldInchesEQLookup "
            Case "ForemanName"
                qry = " SELECT TSGroup, ForemanName FROM tblForemanName "
            Case "SVCSPEC"
                qry = " SELECT ClassID AS SVCSPEC, WPS, NDEPcntReq FROM tblWeldWPSLookup "
            Case "WPS"
                qry = " SELECT WPS, ClassID, NDEPcntReq FROM tblWeldWPSLookup "
            Case "NDEPcntReq"
                qry = " SELECT WPS, ClassID, NDEPcntReq FROM tblWeldWPSLookup "
            Case "Material"
                qry = " SELECT DISTINCT Material FROM tblWeldTracking "
            Case "WallThk"
                qry = " SELECT DISTINCT WallThk FROM tblWeldTracking "
            Case "WeldType"
                qry = " SELECT DISTINCT WeldType FROM tblWeldTracking "
            Case "WeldStn"
                qry = " SELECT TagNo As WeldStn,Name FROM tblWeldersList "
            Case "NDEType"
                qry = " SELECT NDEType FROM tblWeldTracking "
            Case "DateTested"
            Case "AdvancedTesting"
            Case "TestResult"
            Case "VisInspDate"
            Case "VisInspName"
                qry = " SELECT DISTINCT VisInspName FROM tblWeldTracking "
            Case "PMIDate"
            Case "PMIResult"
            Case "RejInches"
            Case "PWHT"
                qry = " SELECT DISTINCT PWHT FROM tblWeldTracking "
            Case "BHN"
            Case "Comments"
                qry = " SELECT DISTINCT BHN FROM tblWeldTracking "
            Case "Revision"
            Case Else

        End Select
        If qry > "" Then
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()
            'ShowSelectedInfoTable(daqartDLL.Utilities.ExecuteQuery(qry, "project"))
            ShowSelectedInfoTable(dt)
        End If
    End Sub
    Private Sub ParameterLabelSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim info As System.Windows.Forms.Label = CType(sender, System.Windows.Forms.Label)
        selectedInfo = info.Text
        ShowParameterTable(selectedInfo)
    End Sub
    Private Sub ParameterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim info As System.Windows.Forms.Button = CType(sender, System.Windows.Forms.Button)
        selectedInfo = Split(info.Name, "-")(1)
        ShowParameterTable(selectedInfo)
    End Sub
    Private Sub ParameterTextBoxSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim info As System.Windows.Forms.Button = CType(sender, System.Windows.Forms.Button)
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If Not vec.ObjectDeleted And vec.itmSelected = True Then
                For Each dr As DataRow In tblWeldTracking.Rows
                    If dr("TagNo") = vec.text Then
                        For Each ctrl As Control In tbxCtrls
                            selectedInfo = Split(ctrl.Name, "-")(1)
                            If (ctrl.Text > "") And (selectedInfo <> "ID") And (selectedInfo <> "TagNo") Then
                                vec.VectorModified = True
                                dr(selectedInfo) = ctrl.Text
                                ' Me.SetDefaultValue(dr)
                            End If
                        Next
                    End If
                Next
            End If
        Next


    End Sub

    Private Sub SelectVectorImage(ByVal vec As EditDaqumentUtil.VectorMap)
        If Not vec.vectorImage Is Nothing Then
            vec.vectorImage.Dispose()
        End If
        If Not vec.pBox.Image Is Nothing Then
            vec.pBox.Image.Dispose()
        End If

        If defaultWeld.WeldType = "SW" Then
            Select Case Me.btnWeldSelect.Text
                Case "New Welds"
                    vec.vectorImage = Global.Daqument.My.Resources.Resources.blueSocketWeld.Clone
                    vec.pBox.Image = Global.Daqument.My.Resources.Resources.blueSocketWeld.Clone
                Case "Reject Welds"
                    vec.vectorImage = Global.Daqument.My.Resources.Resources.redSocketWeld.Clone
                    vec.pBox.Image = Global.Daqument.My.Resources.Resources.redSocketWeld.Clone
                Case "Completed Welds"
                    vec.vectorImage = Global.Daqument.My.Resources.Resources.greenSocketWeld.Clone
                    vec.pBox.Image = Global.Daqument.My.Resources.Resources.greenSocketWeld.Clone
                Case "Field Welds"
                    vec.vectorImage = Global.Daqument.My.Resources.Resources.yellowSocketWeld.Clone
                    vec.pBox.Image = Global.Daqument.My.Resources.Resources.yellowSocketWeld.Clone
                Case Else
                    vec.vectorImage = Global.Daqument.My.Resources.Resources.blueSocketWeld.Clone
                    vec.pBox.Image = Global.Daqument.My.Resources.Resources.blueSocketWeld.Clone
            End Select
        Else
            Select Case Me.btnWeldSelect.Text
                Case "New Welds"
                    vec.vectorImage = Global.Daqument.My.Resources.Resources.blueButtWeld.Clone
                    vec.pBox.Image = Global.Daqument.My.Resources.Resources.blueButtWeld.Clone
                Case "Reject Welds"
                    vec.vectorImage = Global.Daqument.My.Resources.Resources.redButtWeld.Clone
                    vec.pBox.Image = Global.Daqument.My.Resources.Resources.redButtWeld.Clone
                Case "Completed Welds"
                    vec.vectorImage = Global.Daqument.My.Resources.Resources.greenButtWeld.Clone
                    vec.pBox.Image = Global.Daqument.My.Resources.Resources.greenButtWeld.Clone
                Case "Field Welds"
                    vec.vectorImage = Global.Daqument.My.Resources.Resources.yellowButtWeld.Clone
                    vec.pBox.Image = Global.Daqument.My.Resources.Resources.yellowButtWeld.Clone
                Case Else
                    vec.vectorImage = Global.Daqument.My.Resources.Resources.blueButtWeld.Clone
                    vec.pBox.Image = Global.Daqument.My.Resources.Resources.blueButtWeld.Clone
            End Select
        End If

    End Sub
    Private Function VerifyWeldParameters()
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If Not vec.ObjectDeleted And vec.itmSelected = True Then
                For Each dr As DataRow In tblWeldTracking.Rows
                    If dr("TagNo") = vec.text Then
                        For Each clmn As DataColumn In tblWeldTracking.Columns
                            Select Case clmn.ColumnName
                                Case "Disc"
                                Case "AdvancedTesting"
                                Case "Area"
                                Case "TagNo"
                                Case "System"
                                Case "TestPkgNo"
                                Case "EnteredBy"
                                Case "DateEntered"
                                Case "SpoolTo"
                                Case "SpoolFrom"
                                Case "PipeSize"
                                Case "ConstCode"
                                Case "WeldInches"
                                    If (dr("WeldInches") = "") Then
                                        MessageBox.Show("Weld Inches entry is blank")
                                        Return False
                                    End If
                                Case "ForemanName"
                                Case "SVCSPEC"
                                Case "WPS"
                                Case "NDEPcntReq"
                                    If (dr("NDEPcntReq") = "") Then
                                        MessageBox.Show("Weld NDE % entry is blank")
                                        Return False
                                    End If
                                Case "Material"
                                Case "WallThk"
                                Case "WeldType"
                                Case "WeldStn"
                                    If (dr("WeldStn") = "") Then
                                        MessageBox.Show("Weld Stencil entry `is blank")
                                        Return False
                                    End If
                                Case "NDEType"
                                Case "DateTested"
                                Case "AdvancedTesting"
                                Case "TestResult"
                                Case "VisInspDate"
                                Case "VisInspName"
                                Case "PMIDate"
                                Case "PMIResult"
                                Case "RejInches"
                                Case "PWHT"
                                Case "BHN"
                                Case "Comments"
                                Case "Revision"
                                Case Else
                            End Select
                        Next
                    End If
                Next
            End If
        Next
        Return True
    End Function
    Private Sub SelectBtnInsertImage()
        If Not btnInsertImage Is Nothing Then
            '            btnInsertImage.Dispose()
        End If
        If defaultWeld.WeldType = "BW" Then
            Select Case Me.btnWeldSelect.Text
                Case "New Welds"
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.blueSocketWeld.Clone
                Case "Reject Welds"
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.redSocketWeld.Clone
                Case "Completed Welds"
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.greenSocketWeld.Clone
                Case "Field Welds"
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.yellowSocketWeld.Clone
                Case "Inspect Welds"
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.orrangeSocketWeld.Clone
                Case Else
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.blueSocketWeld.Clone
            End Select
        Else
            Select Case Me.btnWeldSelect.Text
                Case "New Welds"
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.blueButtWeld.Clone
                Case "Reject Welds"
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.redButtWeld.Clone
                Case "Completed Welds"
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.greenButtWeld.Clone
                Case "Field Welds"
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.yellowButtWeld.Clone
                Case "Inspect Welds"
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.orrangeButtWeld.Clone
                Case Else
                    btnInsertImage.Image = Global.Daqument.My.Resources.Resources.blueButtWeld.Clone
            End Select
        End If
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If Not vec.ObjectDeleted And vec.itmSelected = True Then
                For Each dr As DataRow In tblWeldTracking.Rows
                    If dr("TagNo") = vec.text Then
                        'For Each clmn As DataColumn In tblWeldTracking.Columns
                        Try
                            vec.vectorImage.Dispose()
                            vec.pBox.Image.Dispose()
                            vec.vectorImage = btnInsertImage.Image.Clone
                            vec.pBox.Image = btnInsertImage.Image.Clone
                            vec.VectorModified = True
                            Select Case Me.btnWeldSelect.Text
                                Case "New Welds"
                                    dr("WeldStatus") = WeldStatus.NewWeld
                                Case "Reject Welds"
                                    dr("WeldStatus") = WeldStatus.RejectWeld
                                Case "Completed Welds"
                                    dr("WeldStatus") = WeldStatus.OKWeld
                                Case "Field Welds"
                                    dr("WeldStatus") = WeldStatus.FieldWeld
                                Case "Inspect Welds"
                                    dr("WeldStatus") = WeldStatus.InspectWeld
                                Case Else
                                    dr("WeldStatus") = WeldStatus.NewWeld
                            End Select
                        Catch ex As Exception

                        End Try
                        'dr(clmn) = GetDefaultParameter(clmn.ColumnName.ToString)
                        ' Next
                    End If
                Next
            End If
        Next
        Redraw()
    End Sub


    Private Sub SetDefaultValue(ByVal dr As DataRow)
        Dim s As String = ""

        If Not dr Is Nothing Then
            Dim items As Object() = dr.ItemArray

            Select Case selectedInfo
                Case "AdvancedTesting"
                    Me.defaultWeld.AdvancedTesting = dr("AdvancedTesting").ToString
                Case "Area"
                    Me.defaultWeld.Area = dr("Area").ToString
                Case "TagNo"
                    Me.defaultWeld.TagNo = dr("TagNo").ToString
                Case "System"
                    Me.defaultWeld.System = dr("System").ToString
                Case "TestPkgNo"
                    Me.defaultWeld.TestPkgNo = dr("TestPkgNo").ToString
                Case "SpoolTo"
                    Me.defaultWeld.SpoolTo = dr("SpoolTo").ToString
                    Me.defaultWeld.Area = dr("Area").ToString
                Case "SpoolFrom"
                    Me.defaultWeld.SpoolFrom = dr("SpoolFrom").ToString
                    Me.defaultWeld.Area = dr("Area").ToString
                Case "PipeSize"
                    Me.defaultWeld.PipeSize = dr("PipeSize").ToString
                    Me.defaultWeld.WeldInches = dr("WeldInches").ToString
                Case "ConstCode"
                    Me.defaultWeld.ConstCode = dr("ConstCode").ToString
                Case "WeldInches"
                    Me.defaultWeld.WeldInches = dr("WeldInches").ToString
                    Me.defaultWeld.PipeSize = dr("PipeSize").ToString
                Case "ForemanName"
                    Me.defaultWeld.ForemanName = dr("ForemanName").ToString
                Case "SVCSPEC"
                    Me.defaultWeld.SVCSPEC = dr("SVCSPEC").ToString
                    Me.defaultWeld.WPS = dr("WPS").ToString
                    Me.defaultWeld.NDEPcntReq = dr("NDEPcntReq").ToString
                Case "WPS"
                    Me.defaultWeld.WPS = dr("WPS").ToString
                    Me.defaultWeld.SVCSPEC = dr("SVCSPEC").ToString
                    Me.defaultWeld.NDEPcntReq = dr("NDEPcntReq").ToString
                Case "NDEPcntReq"
                    Me.defaultWeld.NDEPcntReq = dr("NDEPcntReq").ToString
                    Me.defaultWeld.WPS = dr("WPS").ToString
                    '    Me.defaultWeld.SVCSPEC = dr("SVCSPEC").ToString
                Case "Material"
                    Me.defaultWeld.Material = dr("Material").ToString
                Case "WallThk"
                    Me.defaultWeld.WallThk = dr("WallThk").ToString
                Case "WeldType"
                    Me.defaultWeld.WeldType = dr("WeldType").ToString
                Case "WeldStn"
                    Me.defaultWeld.WeldStn = dr("WeldStn").ToString
                Case "NDEType"
                    Me.defaultWeld.NDEType = dr("NDEType").ToString
                Case "TestResult"
                    Me.defaultWeld.TestResult = dr("TestResult").ToString
                Case "VisInspName"
                    Me.defaultWeld.VisInspName = dr("VisInspName").ToString
                Case "PWHT"
                    Me.defaultWeld.PWHT = dr("PWHT").ToString
                Case "BHN"
                    Me.defaultWeld.BHN = dr("BHN").ToString
                Case "Comments"
                    Me.defaultWeld.Comments = dr("Comments").ToString
                Case "DWGNO"
                    Me.defaultWeld.Comments = dr("DWGNO").ToString
                Case "DrawingID"
                    Me.defaultWeld.DrawingID = dr("DrawingID").ToString
                Case "ID"
                    Me.defaultWeld.ID = dr("ID").ToString
                Case Else
            End Select


        End If
    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim View As ColumnView = GridControl1.MainView
        Dim ParentView As GridView = View.ParentView

        '        PackageViewer.PackageViewerManager.OpenPackage(View.GetFocusedRowCellValue("PackageID"), View.GetFocusedRowCellValue("PackageNumber"))

        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = View.CalcHitInfo((TryCast(sender, Control)).PointToClient(Control.MousePosition))
        Try
            If hi.RowHandle >= 0 Then
                SetDefaultValue(View.GetDataRow(hi.RowHandle))
            ElseIf View.FocusedRowHandle >= 0 Then
                SetDefaultValue(View.GetDataRow(View.FocusedRowHandle))
            Else
                '                SetDefaultValue(Nothing)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        If Not InfoTblForm Is Nothing Then
            InfoTblForm.Dispose()
            InfoTblForm = Nothing
        End If

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If Not vec.ObjectDeleted And vec.itmSelected = True Then
                For Each dr As DataRow In tblWeldTracking.Rows
                    If dr("TagNo") = vec.text Then
                        For Each clmn As DataColumn In tblWeldTracking.Columns
                            Try
                                If clmn.ColumnName <> "TagNo" Then
                                    dr(clmn) = GetDefaultParameter(clmn.ColumnName.ToString)
                                End If
                            Catch ex As Exception

                            End Try
                            'dr(clmn) = GetDefaultParameter(clmn.ColumnName.ToString)
                        Next
                    End If
                Next
            End If
        Next
        WeldPointParameters()
    End Sub

    Private Sub ShowSelectedInfoTable(ByVal infoTbl As DataTable)
        '        selectedInfo = ""
        If Not InfoTblForm Is Nothing Then
            InfoTblForm.Dispose()
            InfoTblForm = Nothing
        End If
        If Not GridControl1 Is Nothing Then

            GridControl1.Dispose()
            GridControl1 = Nothing
        End If
        'If Not infoTbl.DataSet Is Nothing Then
        '    infoTbl.DataSet.Dispose()
        'End If
        Try
            If Not infoTbl.DataSet Is Nothing Then
                infoTbl.DataSet.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show("No entry in the Data Table")
            Return
        End Try

        InfoTblForm = New Form
        InfoTblForm.Text = "Weld Parameters"
        GridControl1 = New DevExpress.XtraGrid.GridControl
        GridControl1.Location = New System.Drawing.Point(0, 30)
        'GridControl1.Dock = DockStyle.Fill
        GridControl1.Name = "GridControl1"
        'GridControl1.Visible = False
        GridControl1.Dock = DockStyle.Top
        '        GridControl1.Bounds = New Rectangle(40, 100, 800, 200)
        'GridControl1.Size = New System.Drawing.Size(300, 200)

        '            Dim gView As GridView = GridControl1.MainView

        '        VGridControl1.Rows(0).Height = 50
        'AddHandler GridControl1.Click, AddressOf GridControl1_Click
        Dim ds As DataSet = New DataSet
        ds.Tables.Add(infoTbl.Copy)
        GridControl1.DataSource = ds.Tables(0)
        InfoTblForm.Controls.Add(GridControl1)
        'Dim View As ColumnView = GridControl1.MainView
        'gView.AddNewRow()
        'View.ClearSelection()
        '            gView.GetVisibleColumn(0).Visible = False
        '           gView.Columns.View.ClearSelection()
        '        gView.Columns(0).Visible = False
        'Dim RIMemoEdit As RepositoryItemMemoEdit = CType(GridControl1.RepositoryItems.Add("MemoEdit"), _
        '   RepositoryItemMemoEdit)
        'RIMemoEdit.WordWrap = True
        'GridControl1.RepositoryItems.Add(RIMemoEdit)
        'InfoTblForm.Bounds = New Rectangle(40, 120, 800, 240) 'GridControl1.Bounds
        'InfoTblForm.Bounds = GridControl1.ClientRectangle
        'InfoTblForm.Size = GridControl1.PreferredSize
        InfoTblForm.Size = New Size(infoTbl.Columns.Count * 100, 250)
        InfoTblForm.Show()
        Dim gView As GridView = GridControl1.MainView
        'gView.BestFitColumns()
        GridControl1.BringToFront()
        gView.OptionsView.ColumnAutoWidth = False
        InfoTblForm.BringToFront()
        AddHandler GridControl1.Click, AddressOf GridControl1_Click
        'Dim RowEsign As RepositoryItemImageEdit = CType(GridControl1.RepositoryItems.Add("ImageEdit"), _
        '   RepositoryItemImageEdit)
    End Sub
    Private Sub CopyParamsFromDefaultWeldPoint(ByRef weld As EditDaqumentUtil.WeldPoint)
        weld.Disc = Me.defaultWeld.Disc
        weld.AdvancedTesting = Me.defaultWeld.AdvancedTesting
        weld.Area = Me.defaultWeld.Area
        weld.BHN = Me.defaultWeld.BHN
        '        weld.TagNo = Me.defaultWeld.TagNo
        weld.System = Me.defaultWeld.System
        weld.DWGNO = Me.defaultWeld.DWGNO
        weld.TestPkgNo = Me.defaultWeld.TestPkgNo
        '       weld.EnteredBy = Me.defaultWeld.EnteredBy
        weld.DateEntered = Me.defaultWeld.DateEntered
        weld.SpoolTo = Me.defaultWeld.SpoolTo
        weld.SpoolFrom = Me.defaultWeld.SpoolFrom
        weld.PipeSize = Me.defaultWeld.PipeSize
        weld.ConstCode = Me.defaultWeld.ConstCode
        weld.WeldInches = Me.defaultWeld.WeldInches
        weld.ForemanName = Me.defaultWeld.ForemanName
        weld.SVCSPEC = Me.defaultWeld.SVCSPEC
        weld.WPS = Me.defaultWeld.WPS
        weld.NDEPcntReq = Me.defaultWeld.NDEPcntReq
        weld.Material = Me.defaultWeld.Material
        weld.WallThk = Me.defaultWeld.WallThk
        weld.WeldType = Me.defaultWeld.WeldType
        weld.WeldStn = Me.defaultWeld.WeldStn
        weld.NDEType = Me.defaultWeld.NDEType
        weld.DateTested = Me.defaultWeld.DateTested
        weld.AdvancedTesting = Me.defaultWeld.AdvancedTesting
        weld.TestResult = Me.defaultWeld.TestResult
        weld.VisInspDate = Me.defaultWeld.VisInspDate
        weld.VisInspName = Me.defaultWeld.VisInspName
        weld.PMIDate = Me.defaultWeld.PMIDate
        weld.PMIResult = Me.defaultWeld.PMIResult
        weld.RejInches = Me.defaultWeld.RejInches
        weld.PWHT = Me.defaultWeld.PWHT
        weld.BHN = Me.defaultWeld.BHN
        weld.Comments = Me.defaultWeld.Comments
        weld.Revision = Me.defaultWeld.Revision
    End Sub

    Private Function GetDefaultParameter(ByVal Param As String) As String
        Select Case Param
            Case "Disc"
                Return (Me.defaultWeld.Disc)
            Case "AdvancedTesting"
                Return Me.defaultWeld.AdvancedTesting
            Case "Area"
                Return Me.defaultWeld.Area
            Case "TagNo"
                Return Me.defaultWeld.TagNo
            Case "System"
                Return Me.defaultWeld.System
            Case "DWGNO"
                Return Me.defaultWeld.DWGNO
            Case "DrawingID"
                Return Me.defaultWeld.DrawingID.ToString
            Case "TestPkgNo"
                Return Me.defaultWeld.TestPkgNo
            Case "EnteredBy"
                Return Me.defaultWeld.EnteredBy
            Case "DateEntered"
                Return Me.defaultWeld.DateEntered.ToString
            Case "SpoolTo"
                Return Me.defaultWeld.SpoolTo
            Case "SpoolFrom"
                Return Me.defaultWeld.SpoolFrom
            Case "PipeSize"
                Return Me.defaultWeld.PipeSize
            Case "ConstCode"
                Return Me.defaultWeld.ConstCode
            Case "WeldInches"
                Return Me.defaultWeld.WeldInches
            Case "ForemanName"
                Return Me.defaultWeld.ForemanName
            Case "SVCSPEC"
                Return Me.defaultWeld.SVCSPEC
            Case "WPS"
                Return Me.defaultWeld.WPS
            Case "NDEPcntReq"
                Return Me.defaultWeld.NDEPcntReq
            Case "Material"
                Return Me.defaultWeld.Material
            Case "WallThk"
                Return Me.defaultWeld.WallThk
            Case "WeldType"
                Return Me.defaultWeld.WeldType
            Case "WeldStn"
                Return Me.defaultWeld.WeldStn
            Case "NDEType"
                Return Me.defaultWeld.NDEType
            Case "DateTested"
                Return Me.defaultWeld.DateTested.ToString
            Case "AdvancedTesting"
                Return Me.defaultWeld.AdvancedTesting
            Case "TestResult"
                Return Me.defaultWeld.TestResult
            Case "VisInspDate"
                Return Me.defaultWeld.VisInspDate.ToString
            Case "VisInspName"
                Return Me.defaultWeld.VisInspName
            Case "PMIDate"
                Return Me.defaultWeld.PMIDate.ToString
            Case "PMIResult"
                Return Me.defaultWeld.PMIResult
            Case "RejInches"
                Return Me.defaultWeld.RejInches
            Case "PWHT"
                Return Me.defaultWeld.PWHT
            Case "BHN"
                Return Me.defaultWeld.BHN
            Case "Comments"
                Return Me.defaultWeld.Comments
            Case "Revision"
                Return Me.defaultWeld.Revision.ToString
            Case "ID"
                Return Me.defaultWeld.ID.ToString
            Case Else
                Return ""
        End Select
    End Function
    Private tbxCtrls As New List(Of Control)
    Private lbxCtrls As New List(Of Control)
    Private btnCtrls As New List(Of Control)
    Private Sub WeldPointParameters()
        If Not WeldParameterForm Is Nothing Then
            WeldParameterForm.Dispose()
            WeldParameterForm = Nothing
        End If
        WeldParameterForm = New Form
        Dim X = 20
        Dim Y = 40
        Dim i As Integer
        If tbxCtrls.Count > 0 Then
            For i = 0 To tbxCtrls.Count - 1
                tbxCtrls(i).Dispose()
                lbxCtrls(i).Dispose()
                btnCtrls(i).Dispose()
            Next
            tbxCtrls.Clear()
            lbxCtrls.Clear()
            btnCtrls.Clear()
        End If
        '        tbxCtrls.Clear()
        For i = 0 To tblWeldTracking.Columns.Count - 1
            Dim tbx As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox
            tbx.Name = "tbx-" + tblWeldTracking.Columns(i).ColumnName
            tbx.Text = GetDefaultParameter(tblWeldTracking.Columns(i).ColumnName)
            tbx.Location = New Point(X + 100, Y)
            tbxCtrls.Add(tbx)
            WeldParameterForm.Controls.Add(tbx)
            Dim butn As System.Windows.Forms.Button = New System.Windows.Forms.Button
            butn.Name = "btn-" + tblWeldTracking.Columns(i).ColumnName
            butn.Width = 30
            butn.Text = "..."
            butn.Location = New Point(X + 205, Y)
            btnCtrls.Add(butn)
            WeldParameterForm.Controls.Add(butn)
            AddHandler butn.Click, AddressOf ParameterButton_Click
            Dim lbl As System.Windows.Forms.Label = New System.Windows.Forms.Label
            lbl.Text = tblWeldTracking.Columns(i).ColumnName
            lbl.Location = New Point(X, Y)
            lbl.TextAlign = ContentAlignment.TopRight
            WeldParameterForm.Controls.Add(lbl)
            lbxCtrls.Add(lbl)
            '            AddHandler lbl.DoubleClick, AddressOf ParameterSelect_Click
            AddHandler lbl.Click, AddressOf ParameterLabelSelect_Click
            Y = Y + 22
            If (i + 1) Mod 9 = 0 Then
                X = X + 250
                Y = 40
            End If

        Next
        Dim btn As System.Windows.Forms.Button = New System.Windows.Forms.Button
        btn.Name = "btnUpdate"
        btn.Text = "Update"
        btn.Location = New Point(300, 10)
        WeldParameterForm.Controls.Add(btn)

        AddHandler btn.Click, AddressOf ParameterTextBoxSelect_Click

        WeldParameterForm.Text = "Weld Parameters"
        WeldParameterForm.Size = New Size(X + 300, Y + 100)
        Dim title As System.Windows.Forms.Label = New System.Windows.Forms.Label
        title.Text = "Weld Parameters"
        title.Width = 200
        title.Name = "WeldParam"
        title.Font = New Font("Ariel", 14, FontStyle.Bold)
        title.Location = New Point(5, 5)

        WeldParameterForm.Controls.Add(title)
        WeldParameterForm.Show()
        WeldParameterForm.Height = 300
        WeldParameterForm.BringToFront()
        WeldParameterForm.Location = New Point(100, 100)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'WeldPointParameters()
        Dim dobj As Daqument.WeldParametersCtrl = New Daqument.WeldParametersCtrl(defaultWeld)
        dobj.Show()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        selectedInfo = ""
        ShowSelectedInfoTable(tblWeldTracking)
    End Sub

End Class