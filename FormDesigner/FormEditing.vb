Imports System.Drawing.Imaging
Imports System.IO
Imports daqartDLL
Imports DevExpress.XtraEditors.Repository
Imports System.Runtime.InteropServices

Public Class FormEditing
    Public Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vKey As Int32) As UShort
    'Dim workingImage As Image '= Image.FromFile("c:\Daqlite\3039-48D5-5001_0C_1_1.png")
    'Dim bmp_Image As New Bitmap(workingImage)
    Dim ImageSize As Size
    Dim NewImageSize As Size
    Dim newCellValue As String = ""
    Dim newSelectedTextBoxIndex As Integer = -1
    Dim bm As Bitmap

    Dim MousePos As Point
    Dim StartingPoint As Point
    Dim ImagePosition As New Point(0, 0)
    Dim XOffset As Integer
    Dim YOffset As Integer


    Dim g As Graphics
    Dim foreground As Graphics
    Dim hilite As Graphics
    'Public Shared DocumentID As Integer
    'Public Shared DocumentName As String

    Dim HiLiteColor As Color = Color.Red
    Dim BoundingBoxVisible As Boolean = False
    Dim formHasBeenScrolled As Boolean = False

    Dim dwgMode As Integer
    Dim MouseDown As Boolean
    Dim ZoomFactor As Double = 1.0

    Dim objects As List(Of Point)
    Dim objectColor As List(Of Color)
    Dim objectSize As List(Of Integer)

    Private _backBuffer As Bitmap

    Dim TopLayerVisible As Boolean

    Private thisRectangle As Rectangle = New Rectangle(0, 0, 0, 0)
    Private _FormName As String
    Private _FormID As String
    Private _FormImages As List(Of Image)
    Private _FormPanelSize As Size
    Private _FormResizeImages As List(Of Image)
    '    Private _FormVarTextBox As New List(Of TextBox)
    Private _MyVarTextBox As New List(Of TextBox)
    Private Magnification As Single = 1
    Private CurrentPage As Integer = 0
    Private _FormVarDataType As FormUtils.FormDataType = FormUtils.FormDataType.Text
    Private DragHandleImg As Image
    Dim myForm As FormUtils
    '    Private connProject As SqlCeConnection = daqartDLL.connections.projectDBConnect(connProject)
    Private theRectangle As New Rectangle(New Point(0, 0), New Size(0, 0))
    Private startPoint As Point
    Private isDragging As Boolean = False
    Private rect As New Rectangle()
    Private rect1 As New Rectangle()
    Private rect2 As New Rectangle()
    Private rect3 As New Rectangle()
    Private rect4 As New Rectangle()
    Private rect5 As New Rectangle()

    Private VarCtr As Integer = 0
    Private isDrag As Boolean = False
    Private SelectedBox As New List(Of TextBox)
    '    Private _MyFormItems As New List(Of FormUtils.formItem)

    Public mFont As Font
    Private dt_FormInfo As DataTable
    Private LoadingVariables As Boolean
    Private _MyParent As FormMain
    Private ShiftKey As Boolean
    Private dt_FieldGroups As New DataTable
    Private dt_CustomNames As New DataTable
    Private ModifiedFlag As Boolean = False
    Friend WithEvents VGridControl1 As DevExpress.XtraVerticalGrid.VGridControl



    Private Enum mode
        None
        BoxSelected
        Insert
        DragLeft
        DragRight
        DragUp
        DragDown
        DragMove
    End Enum
    Private FormMode As mode = mode.None

    Public Sub New(ByVal ThisFormID As String, ByVal ThisParent As Form, ByVal myName As String)
        Me.InitializeComponent()

        _FormID = ThisFormID
        _MyParent = ThisParent
        _FormName = myName
        Me.MdiParent = _MyParent

        objects = New List(Of Point)
        objectColor = New List(Of Color)()
        objectSize = New List(Of Integer)()
        TopLayerVisible = True

        dt_FieldGroups.Columns.Add("GroupID")
        dt_FieldGroups.Columns.Add("TextboxName")
        dt_CustomNames.Columns.Add(New DataColumn("CustomName", GetType(String)))
        dt_CustomNames.Columns.Add(New DataColumn("TextboxName", GetType(String)))



    End Sub

    'Private Sub FormEditing_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

    '    For Each thisItem As ToolStripMenuItem In _MyParent.FormList.DropDownItems
    '        If thisItem.Text = Me.Text Then
    '            'thisItem.Name = FormID
    '            thisItem.Checked = True
    '            'thisItem.CheckState = CheckState.Checked
    '        Else
    '            thisItem.Checked = False
    '            'thisItem.CheckState = CheckState.Unchecked
    '        End If
    '    Next thisItem
    'End Sub


    Private Sub ViewDaqument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            myForm = New FormUtils(_FormID, 0, 0, "Edit")
            _FormImages = myForm.FormImages()

            If _FormImages.Count > 0 Then
                CurrentPage = 0

                StatusStrip1.Text = _FormName
                'Me.cboDataType.Items.Add("Text")
                'Me.cboDataType.Items.Add("Number")
                'Me.cboDataType.Items.Add("DateTime")
                'Me.cboDataType.Items.Add("Boolean")
                'Me.cboDataType.Text = "Text"
                '                PopulateCboVarSearch()
                '              PageRefresh()
                MakeDragHandleImage()
                Me.rect1.Height = 6 : rect1.Width = 6
                Me.rect2.Height = 6 : rect2.Width = 6
                Me.rect4.Height = 6 : rect4.Width = 6
                Me.rect5.Height = 6 : rect5.Width = 6

                FormMode = mode.None
                PopulateFormVariables()
                PageRefresh()
                Me.Height = dwgPanel.Height
                Me.Width = dwgPanel.Width
                Me.Refresh()

                GetFormInfo()
                AddHandler Me.Activated, AddressOf FormEditing_Activated
                AddHandler Me.GotFocus, AddressOf FormEditing_GotFocus
            Else
                MessageBox.Show("Image was not stored for the document")
                Me.Close()
            End If
        Catch ex As Exception
            Utilities.logErrorMessage("FormDesigner.FormEditing.ViewDaqument_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
        Me.cboVarSearch.Focus()
        Me.DoubleBuffered = True


    End Sub


    Private Sub GetFormInfo()
        Dim query As String = "SELECT * FROM forms WHERE ID='" + _FormID.ToString + "'"
        'dt_FormInfo = Utilities.ExecuteQuery(query, "project")

        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        dt_FormInfo = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

    End Sub


    Private Sub MakeTransparent(ByVal bmp_image As Bitmap, ByVal workingImage As Image)
        bmp_image = workingImage
        bm = New Bitmap(ImageSize.Width, ImageSize.Height)
        foreground = Graphics.FromImage(bm)
        bmp_image.MakeTransparent(Color.White)
        foreground.DrawImage(bmp_image, 0, 0)
    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub


    Private Sub picSrc_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dwgPanel.MouseDown
        MouseDown = True
        MousePos = e.Location
    End Sub


    Private Sub dwgPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dwgPanel.MouseMove
        lab_XY.Text = "X: " & e.Location.X & "         Y:  " & e.Location.Y

        MousePos = e.Location

        Dim myMode As mode = FormMode
        If myMode = mode.DragLeft Or myMode = mode.DragRight Or myMode = mode.DragMove Or myMode = mode.DragUp Or myMode = mode.DragDown Then
            If e.Button <> System.Windows.Forms.MouseButtons.Left Then
                'isDragging = False
                'FormMode = mode.None
                'SelectedBox.Clear()
                Return
            End If
            Me.Invalidate()
        End If

        Select Case FormMode
            Case mode.Insert
                'Me.dwgPanel.Cursor = Cursors.Cross
                'Return
            Case mode.DragLeft
                UpdateBoundingBox(sender, New Point(e.X, e.Y))
            Case mode.DragRight
                UpdateBoundingBox(sender, New Point(e.X, e.Y))
            Case mode.DragMove
                UpdateBoundingBox(sender, New Point(e.X, e.Y))
            Case mode.DragUp
                UpdateBoundingBox(sender, New Point(e.X, e.Y))
            Case mode.DragDown
                UpdateBoundingBox(sender, New Point(e.X, e.Y))
            Case mode.None
                'If e.Button = System.Windows.Forms.MouseButtons.Left Then
                '    ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
                '    Dim myPoint As Point = New Point(Control.MousePosition.X, Control.MousePosition.Y)
                '    If theRectangle.X = 0 Then
                '        theRectangle.Location = New Point(myPoint.X, myPoint.Y)
                '    Else
                '        Dim myWidth = myPoint.X - theRectangle.X : Dim myHeight = myPoint.Y - theRectangle.Y
                '        theRectangle.Size = New Size(Math.Abs(myWidth), Math.Abs(myHeight))
                '    End If
                '    ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
                'End If
            Case mode.BoxSelected
                If rect1.Contains(e.X, e.Y) Then
                    dwgPanel.Cursor = Cursors.SizeWE
                    myMode = mode.DragLeft
                End If
                If rect2.Contains(e.X, e.Y) Then
                    dwgPanel.Cursor = Cursors.SizeWE
                    myMode = mode.DragRight
                End If
                If rect3.Contains(e.X, e.Y) Then
                    dwgPanel.Cursor = Cursors.SizeAll
                    myMode = mode.DragMove
                End If
                If rect4.Contains(e.X, e.Y) Then
                    dwgPanel.Cursor = Cursors.SizeNS
                    myMode = mode.DragUp
                End If
                If rect5.Contains(e.X, e.Y) Then
                    dwgPanel.Cursor = Cursors.SizeNS
                    myMode = mode.DragDown
                End If
                If e.Button = System.Windows.Forms.MouseButtons.Left Then
                    FormMode = myMode
                    Return
                End If
        End Select
        If myMode = mode.DragLeft Or myMode = mode.DragRight Or myMode = mode.DragMove Or myMode = mode.DragUp Or myMode = mode.DragDown Then
            'dwgPanel.Refresh()

            'dwgPanel.Invalidate()
            If SelectedBox.Count > 0 Then
                'ControlPaint.DrawReversibleFrame(SelectedBox(0).Bounds, Me.BackColor, FrameStyle.Dashed)
                Dim myRect As Rectangle = SelectedBox(0).Bounds
                Dim myLoc As Point = PointToScreen(New Point(myRect.X, myRect.Y))

                theRectangle = New Rectangle(myLoc.X + dwgPanel.Location.X, myLoc.Y + +dwgPanel.Location.Y, myRect.Width, myRect.Height)

                ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
            End If
        Else
            If (btnAddVar.Checked Or Me.btn_Signbox.Checked Or Me.btn_YNNA_Select.Checked) And btnAutoSize.Checked Then
                FormMode = mode.Insert
                dwgPanel.Cursor = Cursors.Cross
            Else
                If FormMode <> mode.Insert Then dwgPanel.Cursor = Cursors.Default
            End If
        End If

    End Sub


    Private Sub dwgPanel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dwgPanel.MouseUp
        Dim newPosition As New Point(e.X, e.Y)

        If dwgMode = 1 Then
            dwgPanel.Update()
            'dwgPanel.Refresh()
        End If

        If dwgMode = 2 Then
            dwgPanel.Update()
            'dwgPanel.Refresh()
        End If


        MouseDown = False
        'If isDragging Then
        '    isDragging = False
        '    FormMode = mode.None
        '    dwgPanel.Cursor = Cursors.Default
        '    SelectedBox(0).Visible = False
        '    SelectedBox.Clear()
        '    BoundingBoxVisible = False
        '    Me.dwgPanel.Refresh()

        'End If

        If SelectedBox.Count = 0 Then
            'FormMode = mode.None
        End If

        'SelectedBox.Clear()
        'Me.dwgPanel.Invalidate()
        'Me.Invalidate()
        Me.Focus()

    End Sub


    Private Sub dwgPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles dwgPanel.Paint
        Try

            If LoadingVariables Then Return

            If _backBuffer Is Nothing Then
                _backBuffer = New Bitmap(NewImageSize.Width, NewImageSize.Height)
            End If

            g = e.Graphics


            If TopLayerVisible Then
                g.DrawImage(bm, ImagePosition.X, ImagePosition.Y, NewImageSize.Width, NewImageSize.Height)
            End If

            'Return
            For Each cntl As Control In dwgPanel.Controls
                Dim mBox As TextBox = TryCast(cntl, TextBox)
                If Not mBox Is Nothing Then
                    If mBox.Tag = CurrentPage Then
                        If mBox.Bounds.Width > 0 And mBox.Bounds.Height > 0 Then
                            Dim bm As New Bitmap(mBox.Bounds.Width, mBox.Bounds.Height)
                            Dim g2 As Graphics = Graphics.FromImage(bm)
                            Dim myFont = New Font(mBox.Font.FontFamily, mBox.Font.Size, _
                                     System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
                            Dim myBrush As Brush = New SolidBrush(Color.Blue)
                            g2.DrawString(mBox.Text, myFont, myBrush, New Rectangle(New Point(1, 1), mBox.Bounds.Size))

                            Dim rect As Rectangle = New Rectangle(mBox.Bounds.X, mBox.Bounds.Y, mBox.Bounds.Width, mBox.Bounds.Height)
                            Dim BoxSelected As Boolean = False
                            For Each tBox As TextBox In SelectedBox
                                If tBox.Name = mBox.Name Then
                                    BoxSelected = True
                                End If
                            Next
                            If BoxSelected Then
                                g.DrawRectangle(Pens.Green, rect)
                            Else
                                g.DrawRectangle(Pens.Red, rect)
                            End If


                            'For Each dr As DataRow In dt_FieldGroups.Rows
                            '    If dr(1) = mBox.Name Then
                            '        g.DrawRectangle(Pens.Yellow, rect)
                            '    End If
                            'Next

                            If SelectedBox.Count = 1 Then
                                If SelectedBox(0).Name = mBox.Name Then
                                    FormMode = mode.BoxSelected
                                    UpdateBoundingBox(sender, mBox.Location)
                                End If
                            End If


                            g.DrawImage(bm, New Point(mBox.Bounds.X, mBox.Bounds.Y))
                        End If
                    End If
                End If
            Next


            MyBase.OnPaint(e)
            If (Me.isDragging) Then
                Using pen As New Pen(Color.Black)
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
                    e.Graphics.FillRectangle(Brushes.Black, Me.rect1)
                    e.Graphics.FillRectangle(Brushes.Black, Me.rect2)
                    e.Graphics.FillRectangle(Brushes.Black, Me.rect4)
                    e.Graphics.FillRectangle(Brushes.Black, Me.rect5)
                    e.Graphics.DrawImage(DragHandleImg, Me.rect3.Location)
                End Using
            End If
        Catch ex As Exception

        End Try


    End Sub


    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    dwgPanel.Cursor = Cursors.NoMove2D
    '    dwgMode = 1
    'End Sub


    Private Sub dwgPanel_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dwgPanel.Scroll

        ImagePosition.X = dwgPanel.AutoScrollPosition.X
        ImagePosition.Y = dwgPanel.AutoScrollPosition.Y

        'dwgPanel.Refresh()
        dwgPanel.Update()
        dwgPanel.Invalidate()
        Me.Invalidate()

    End Sub


    'Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    dwgPanel.Cursor = Cursors.Arrow
    '    dwgMode = 0
    'End Sub


    'Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    dwgMode = 2
    '    dwgPanel.Cursor = Cursors.Cross

    'End Sub


    Private Sub Zoom(ByVal ZF As Double)

        NewImageSize.Width = ImageSize.Width * ZF / 100
        NewImageSize.Height = ImageSize.Height * ZF / 100

        dwgPanel.AutoScrollMinSize = NewImageSize
        dwgPanel.Refresh()

    End Sub


    Private Sub HideTransparencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TopLayerVisible = False
        dwgPanel.Update()

    End Sub


    Private Sub ShowTransparencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TopLayerVisible = True
        dwgPanel.Update()

    End Sub


    Private Function GetDataType(ByVal txt As String) As FormUtils.FormDataType
        Select Case cboDataType.Text
            Case "Text"
                Return FormUtils.FormDataType.Text
            Case "Number"
                Return FormUtils.FormDataType.Number
            Case "Boolean"
                Return FormUtils.FormDataType.yesNo
            Case "DateTime"
                Return FormUtils.FormDataType.DateTime
            Case Else
                Return FormUtils.FormDataType.Text
        End Select

    End Function


    Private Function ConvertDataType(ByVal myType As FormUtils.FormDataType) As String
        Select Case myType
            Case FormUtils.FormDataType.Text
                Return "Text"
            Case FormUtils.FormDataType.Number
                Return "Number"
            Case FormUtils.FormDataType.yesNo
                Return "Boolean"
            Case FormUtils.FormDataType.DateTime
                Return "DateTime"
            Case Else
                Return "Text"
        End Select

    End Function


    Private Function MakeFormItem(ByVal tbox As TextBox) As FormUtils.formItem

        Dim frmItem As FormUtils.formItem = New FormUtils.formItem
        frmItem.FieldName = tbox.Name
        Dim var() As String = Split(tbox.Text, "@")
        'frmItem.MapName = var(1)
        Dim ElementTest As String = Mid(tbox.Text, 1, 7)
        Try
            If (var.Length > 1) And Not ElementTest = "Element" Then
                frmItem.MapName = var(1)
                frmItem.linkTbl = var(0)
            Else
                frmItem.MapName = tbox.Name
                frmItem.linkTbl = ""
            End If
            frmItem.Value = ""
            frmItem.WtPcnt = 0
            frmItem.Color = tbox.BackColor.ToArgb.ToString
            frmItem.DataType = GetDataType(tbox.Text)
            frmItem.Position = tbox.TabIndex
            frmItem.PosX = tbox.Bounds.Location.X - Me.ImagePosition.X
            frmItem.PosY = tbox.Bounds.Location.Y - Me.ImagePosition.Y
            frmItem.Width = tbox.Width
            frmItem.Height = tbox.Height
            frmItem.PgNum = tbox.Tag
            frmItem.TabPosition = VarCtr.ToString
            frmItem.FontName = tbox.Font.FontFamily.Name
            frmItem.FontSize = tbox.Font.Size.ToString
            frmItem.FontUnderline = False
            frmItem.FontBold = False
            frmItem.FontItalic = False
            frmItem.FieldID = myForm.FormVarID(tbox.Name)

            'frmItem.Selected = False

            'check for GroupID
            For i As Integer = 0 To dt_FieldGroups.Rows.Count - 1
                If dt_FieldGroups.Rows(i)(1) = tbox.Name Then
                    If dt_FieldGroups.Rows(i)(0) > 0 Then
                        frmItem.GroupID = dt_FieldGroups.Rows(i)(0)
                    Else
                        frmItem.GroupID = 0
                    End If
                End If
            Next
            For i As Integer = 0 To dt_CustomNames.Rows.Count - 1
                If dt_CustomNames.Rows(i)(1) = tbox.Name Then
                    If dt_CustomNames.Rows(i)(0) > "" Then
                        frmItem.CustomName = dt_CustomNames.Rows(i)(0)
                    Else
                        frmItem.CustomName = frmItem.FieldName
                    End If
                End If
            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        Return frmItem
    End Function


    Private Sub DeleteVariable(ByVal thisbox As TextBox)
        If myForm.FormMaxLevel > 0 Then
            MessageBox.Show("The form status level does not allow variable delete")
            Return
        End If
        For Each tbox As Control In _MyVarTextBox
            If tbox.Name = thisbox.Name Then
                myForm.remoteDeleteFormVar(MakeFormItem(tbox))
                _MyVarTextBox.Remove(tbox)
                thisbox.Dispose()
                Exit For
            End If
        Next
        FormMode = mode.None
        isDragging = False
        Me.dwgPanel.Invalidate()
        Me.Invalidate()
    End Sub


    'Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.ShiftKey Then
    '        ShiftKey = True
    '        stat_Main.Text = ShiftKey
    '        Return
    '    End If

    '    If FormMode = mode.BoxSelected Then
    '        If e.KeyCode = Keys.Delete Then
    '            For Each mbox As TextBox In SelectedBox
    '                DeleteVariable(mbox)
    '            Next
    '            SelectedBox.Clear()
    '            Return
    '        End If




    '        For Each mbox As TextBox In SelectedBox
    '            If e.KeyCode = Keys.Left Then
    '                mbox.Location = New Point(mbox.Location.X - 1, mbox.Location.Y)
    '            End If
    '            If e.KeyCode = Keys.Right Then
    '                mbox.Location = New Point(mbox.Location.X + 1, mbox.Location.Y)
    '            End If
    '            If e.KeyCode = Keys.Up Then
    '                mbox.Location = New Point(mbox.Location.X, mbox.Location.Y - 1)
    '            End If
    '            If e.KeyCode = Keys.Down Then
    '                mbox.Location = New Point(mbox.Location.X, mbox.Location.Y + 1)
    '            End If
    '            Me.rect.Height = mbox.Bounds.Height + 4
    '            Me.rect.Width = mbox.Bounds.Width + 4
    '            Me.rect.Location = New Point(mbox.Bounds.X - 2, mbox.Bounds.Y - 2)
    '            Me.rect1.Location = New Point(mbox.Bounds.X - 6, mbox.Bounds.Y + mbox.Height / 2 - 3)
    '            Me.rect2.Location = New Point(mbox.Bounds.X + mbox.Bounds.Width, mbox.Bounds.Y + mbox.Height / 2 - 3)
    '            Me.rect3.Location = New Point(mbox.Bounds.X, mbox.Bounds.Y - Me.rect3.Height)
    '            Me.rect4.Location = New Point(mbox.Bounds.X + (mbox.Bounds.Width / 2), mbox.Bounds.Y - 6)
    '            Me.rect5.Location = New Point(mbox.Bounds.X + (mbox.Bounds.Width / 2), mbox.Bounds.Y + mbox.Height)
    '        Next
    '        Me.dwgPanel.Invalidate()
    '    End If

    'End Sub


    'Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.ShiftKey Then
    '        ShiftKey = False
    '        stat_Main.Text = ShiftKey
    '    End If
    'End Sub

    'Private Sub TextBox1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Cursor.Current = Cursors.SizeAll
    'End Sub

    'Private Sub ClearBoundingBox()
    '    'Me.rect.Height = 0 : Me.rect.Width = 0
    '    Me.rect1.Width = 0 : Me.rect1.Height = 0
    '    Me.rect2.Width = 0 : Me.rect2.Height = 0
    '    Me.rect3.Width = 0 : Me.rect3.Height = 0
    '    Me.rect4.Width = 0 : Me.rect3.Height = 0
    '    Me.rect5.Width = 0 : Me.rect3.Height = 0
    'End Sub
    Private Sub UpdateBoundingBox(ByVal sender As System.Object, ByVal e As Point)
        Dim newWidth As Integer
        Dim newHeight As Integer
        BoundingBoxVisible = True

        Dim newLocation As Point = e
        Me.rect1.Height = 6 : rect1.Width = 6
        Me.rect2.Height = 6 : rect2.Width = 6
        Me.rect4.Height = 6 : rect4.Width = 6
        Me.rect5.Height = 6 : rect5.Width = 6

        For Each mbox As TextBox In SelectedBox
            newHeight = mbox.Height
            newWidth = mbox.Width

            Select Case FormMode
                Case mode.DragLeft
                    newWidth = mbox.Bounds.X - e.X + mbox.Bounds.Width
                    newLocation = New Point(e.X, mbox.Bounds.Y)
                Case mode.DragRight
                    newWidth = e.X - mbox.Bounds.X
                    newLocation = New Point(mbox.Bounds.X, mbox.Bounds.Y)
                Case mode.DragMove
                    newWidth = mbox.Bounds.Width
                    newLocation = New Point(e.X, e.Y)
                Case mode.BoxSelected
                    Cursor.Current = Cursors.Default
                    newWidth = mbox.Bounds.Width
                    newLocation = New Point(mbox.Bounds.X, mbox.Bounds.Y)
                Case mode.DragUp
                    newHeight = mbox.Bounds.Y - e.Y + mbox.Bounds.Height
                    newLocation = New Point(mbox.Bounds.X, e.Y)
                Case mode.DragDown
                    newHeight = e.Y - mbox.Bounds.Y
                    newLocation = New Point(mbox.Bounds.X, mbox.Bounds.Y)
                Case Else
                    Return
            End Select

            mbox.Location = newLocation
            mbox.Width = newWidth
            mbox.Height = newHeight
            Me.rect.Height = mbox.Bounds.Height + 4
            Me.rect.Width = mbox.Bounds.Width + 4
            Me.rect.Location = New Point(mbox.Bounds.X - 2, mbox.Bounds.Y - 2)
            Me.rect1.Location = New Point(mbox.Bounds.X - 6, mbox.Bounds.Y + mbox.Height / 2 - 3)
            Me.rect2.Location = New Point(mbox.Bounds.X + mbox.Bounds.Width, mbox.Bounds.Y + mbox.Height / 2 - 3)
            Me.rect3.Location = New Point(mbox.Bounds.X + 4, mbox.Bounds.Y - Me.rect3.Height)
            Me.rect4.Location = New Point(mbox.Bounds.X + (mbox.Bounds.Width / 2), mbox.Bounds.Y - 6)
            Me.rect5.Location = New Point(mbox.Bounds.X + (mbox.Bounds.Width / 2), mbox.Bounds.Y + mbox.Height)
        Next
        isDragging = True
        ModifiedFlag = True
        dwgPanel.Update()


        'Me.dwgPanel.Invalidate()
        '        Me.Invalidate()
    End Sub


    'Private Sub TextBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If e.Button = MouseButtons.Left Then
    '        If FormMode = mode.None Or FormMode = mode.BoxSelected Then
    '            If _MyVarTextBox.Count > 1 Then
    '                Dim tt = _MyVarTextBox.Count
    '            End If
    '            Dim mBox As TextBox = TryCast(sender, TextBox)
    '            Cursor.Current = Cursors.SizeAll

    '            If Not ShiftKey Then
    '                SelectedBox.Clear()
    '            End If

    '            SelectedBox.Add(mBox)
    '            FormMode = mode.BoxSelected
    '            UpdateBoundingBox(sender, New Point(e.X, e.Y))
    '            If btnProperties.Checked Then
    '                Dim dt As DataTable = GetSelectedTextBoxFieldProperties()
    '                If Not dt Is Nothing Then DisplayTextBoxPropertyGrid(dt)
    '            End If
    '            Me.dwgPanel.Invalidate()
    '            Me.Invalidate()
    '        End If
    '    End If
    'End Sub


    'Private Sub TextBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    'End Sub


    'Private Sub DrawTextString(ByVal mBox As TextBox)
    '    g = Graphics.FromImage(dwgPanel.BackgroundImage)

    '    Dim myFont = New Font(mBox.Font.FontFamily, mBox.Font.Size, _
    '             System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
    '    Dim myBrush As Brush = New SolidBrush(mBox.ForeColor)
    '    g.DrawString(mBox.Text, myFont, myBrush, New Rectangle(New Point(mBox.Bounds.X, mBox.Bounds.Y), mBox.Bounds.Size))
    'End Sub


    Private Sub AddTextBox(ByVal mBox As TextBox)

        If FormMode = mode.Insert Then
            Me.ModifiedFlag = True

            dwgPanel.Controls.Add(mBox)

            _MyVarTextBox.Add(mBox)
            If CheckNewVariable(mBox.Name) Then
                dt_CustomNames.Rows.Add(mBox.Name, mBox.Name)
            End If
            mBox.BringToFront()
            mBox.ReadOnly = True
            mBox.Multiline = True
            mBox.Visible = False

            Me.isDragging = False
            FormMode = mode.None
            '    Me.Invalidate()
            'Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub PopulateFormVariables()
        LoadingVariables = True
        dt_FieldGroups.Rows.Clear()
        dt_CustomNames.Rows.Clear()


        For i As Integer = 0 To myForm.FormVars.Count - 1
            FormMode = mode.Insert
            Dim tbox As TextBox = New TextBox
            tbox.Location = New Point(myForm.FormVars(i).PosX, myForm.FormVars(i).PosY)
            tbox.Width = myForm.FormVars(i).Width
            tbox.Height = myForm.FormVars(i).Height
            '            ctrl.Font = myForm.FormVars(i).FontName
            tbox.Name = myForm.FormVars(i).FieldName
            If myForm.FormVars(i).linkTbl > "" Then
                tbox.Text = myForm.FormVars(i).linkTbl + "@" + myForm.FormVars(i).MapName
            ElseIf Mid(myForm.FormVars(i).FieldName, 1, 7) = "Element" Then
                tbox.Text = myForm.FormVars(i).FieldName
            ElseIf Mid(myForm.FormVars(i).FieldName, 1, 9) = "Signature" Then
                tbox.Text = "Signature"
            ElseIf Mid(myForm.FormVars(i).FieldName, 1, 8) = "YNSelect" Then
                tbox.Text = "YNSelect"
            Else
                tbox.Text = ConvertDataType(myForm.FormVars(i).DataType)
            End If
            tbox.Font = New Font(myForm.FormVars(i).FontName, _
                        myForm.FormVars(i).FontSize, _
                        IIf(myForm.FormVars(i).FontBold, FontStyle.Bold, _
                        IIf(myForm.FormVars(i).FontItalic, FontStyle.Italic, _
                        IIf(myForm.FormVars(i).FontUnderline, FontStyle.Underline, _
                        FontStyle.Regular))), GraphicsUnit.Point)
            tbox.BackColor = System.Drawing.Color.FromArgb(myForm.FormVars(i).Color)
            tbox.Tag = myForm.FormVars(i).PgNum

            If myForm.FormVars(i).GroupID > 0 Then
                dt_FieldGroups.Rows.Add(myForm.FormVars(i).GroupID, myForm.FormVars(i).FieldName)
            End If
            dt_CustomNames.Rows.Add(myForm.FormVars(i).CustomName, myForm.FormVars(i).FieldName)

            AddTextBox(tbox)
        Next
        dwgPanel.ResumeLayout()
        VarCtr = myForm.FormVars.Count
        FormMode = mode.None

        LoadingVariables = False
    End Sub


    Private Sub MakeDragHandleImage()
        System.Windows.Forms.Cursor.Current = Cursors.SizeAll
        rect3 = New Rectangle(0, 0, Cursor.Size.Width - 10, Cursor.Size.Height - 10)
        Using CursorImage As Bitmap = New Bitmap(rect3.Width, rect3.Height, PixelFormat.Format24bppRgb)
            Using canvas As Graphics = Graphics.FromImage(CursorImage)
                canvas.FillRectangle(Brushes.White, Me.rect3)
                Cursor.Current.Draw(canvas, rect3)
                Dim m As New MemoryStream
                CursorImage.Save(m, ImageFormat.Jpeg)
                DragHandleImg = System.Drawing.Image.FromStream(m)
            End Using
        End Using
    End Sub
    'Private Function AutoSizeTextBox(ByVal loc As Point) As Rectangle
    '    'Dim thisPixel As Color = bmp_Image()
    '    Dim thisPixColor As Integer = bm.GetPixel(loc.X, loc.Y).ToArgb
    '    Dim maxSize As Size = bm.Size
    '    Dim maxUpTravel As Integer = Math.Abs(loc.Y - startPoint.Y)
    '    Dim maxDnTravel As Integer = Math.Abs(loc.Y - (startPoint.Y + bm.Height))
    '    Dim maxLtTravel As Integer = Math.Abs(loc.X - startPoint.Y)
    '    Dim maxRtTravel As Integer = Math.Abs(loc.X - (startPoint.Y + bm.Width))
    '    Dim upDistance As Integer = 0
    '    Dim ltDistance As Integer = 0
    '    Dim dnDistance As Integer = 0
    '    Dim rtDistance As Integer = 0
    '    For i As Integer = 0 To maxLtTravel
    '        Dim nextPix As Integer = bm.GetPixel(loc.X - i, loc.Y).ToArgb
    '        If nextPix <> thisPixColor Then
    '            ltDistance = loc.X - i
    '            Exit For
    '        End If
    '    Next
    '    For i As Integer = 0 To maxUpTravel
    '        Dim nextPix As Integer = bm.GetPixel(loc.X, loc.Y - i).ToArgb
    '        If nextPix <> thisPixColor Then
    '            upDistance = loc.Y - i
    '            Exit For
    '        End If
    '    Next
    '    For i As Integer = 0 To maxRtTravel
    '        Dim nextPix As Integer = bm.GetPixel(loc.X + i, loc.Y).ToArgb
    '        If nextPix <> thisPixColor Then
    '            rtDistance = loc.X + i
    '            Exit For
    '        End If
    '    Next
    '    For i As Integer = 0 To maxDnTravel
    '        Dim nextPix As Integer = bm.GetPixel(loc.X, loc.Y + i).ToArgb
    '        If nextPix <> thisPixColor Then
    '            dnDistance = loc.Y + i
    '            Exit For
    '        End If
    '    Next
    '    If upDistance = 0 Or dnDistance = 0 Or ltDistance = 0 Or rtDistance = 0 Then
    '        Return New Rectangle(0, 0, 0, 0)
    '    End If
    '    Dim newRect As Rectangle = New Rectangle(ltDistance, upDistance, (rtDistance - ltDistance), (dnDistance - upDistance))
    '    Return newRect
    'End Function

    '2.1.0.42
    Private Function MakeNewTextBox(ByVal loc As Point) As TextBox
        Dim MyParent As FormMain = Me.ParentForm
        'Me.dwgPanel.Cursor.Current = Cursors.Cross
        Dim mBox As TextBox = New TextBox()

        If Me.btnAddVar.Checked = True Then
            mBox.Name = "Field_" + VarCtr.ToString
            mBox.Text = "Text"
        End If
        If Me.btn_Signbox.Checked = True Then
            mBox.Name = "Signature_" + VarCtr.ToString
            mBox.Text = "Signature"
        End If
        If Me.btn_YNNA_Select.Checked = True Then
            mBox.Name = "YNSelect_" + VarCtr.ToString
            mBox.Text = "YNSelect"
        End If

        'Panel1.Controls.Add(mBox)
        mBox.Font = MyParent.FontSelect.Font
        mBox.BringToFront()
        mBox.BackColor = MyParent.BkColor.BackColor
        mBox.Tag = CurrentPage
        mBox.Location = loc
        'SelectedBox.Clear()
        'SelectedBox.Add(mBox)
        VarCtr = VarCtr + 1
        Return mBox
        'dwgPanel.Cursor = Cursors.Cross
    End Function


    Private Sub btnAddVar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddVar.Click
        If btnAddVar.Checked Then
            Me.dwgPanel.Cursor = Cursors.Default
            btnAddVar.Checked = False
            FormMode = mode.None
            For Each cntl As Control In dwgPanel.Controls
                Dim mBox As TextBox = TryCast(cntl, TextBox)
                If Not mBox Is Nothing Then
                    mBox.Visible = False
                End If
            Next
            dwgPanel.Cursor = Cursors.Default
            SelectedBox.Clear()
            Return
        Else
            btn_Signbox.Checked = False
            btnAddVar.Checked = True
        End If
        If FormMode = mode.None Then
            Me.dwgPanel.Cursor = Cursors.Cross
            FormMode = mode.Insert
            'MakeNewTextBox()
            '            Me.Controls.Add(mBox)
            '                Me.Panel1.DoDragDrop(mBox, DragDropEffects.All)
            'Me.DoDragDrop(Me.Button1, DragDropEffects.All)
        End If
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If FormMode <> mode.BoxSelected Then Return
        For Each mbox As TextBox In SelectedBox
            DeleteVariable(mbox)
        Next
        SelectedBox.Clear()
        dwgPanel.Invalidate()

    End Sub


    Private Function TextBoxLocationOK(ByVal loc As Point) As Boolean
        'Dim thisPixel As Color = bmp_Image()
        'Dim loc As Point = New Point(rect.X, rect.Y)
        Dim tmpBox As TextBox = New TextBox
        Dim wd As Integer = tmpBox.Width
        Dim ht As Integer = tmpBox.Height
        tmpBox.Dispose()
        Dim thisPixColor As Integer = bm.GetPixel(loc.X, loc.Y).ToArgb
        Dim maxSize As Size = bm.Size
        Dim maxUpTravel As Integer = Math.Abs(loc.Y - startPoint.Y)
        Dim maxDnTravel As Integer = Math.Abs(loc.Y - (startPoint.Y + bm.Height))
        Dim maxLtTravel As Integer = Math.Abs(loc.X - startPoint.Y)
        Dim maxRtTravel As Integer = Math.Abs(loc.X - (startPoint.Y + bm.Width))
        If maxRtTravel < wd Then Return False
        If maxDnTravel < ht Then Return False

        For Each cntl As Control In dwgPanel.Controls
            Dim tBox As TextBox = TryCast(cntl, TextBox)
            If Not tBox Is Nothing Then
                If tBox.Tag = CurrentPage Then
                    If tBox.Bounds.Contains(loc.X, loc.Y) Then
                        Return False
                    End If
                End If
            End If
        Next

        Return True
    End Function
    Private Sub AutoSizeTextBox(ByRef mBox As TextBox)
        If Not btnAutoSize.Checked Then Return
        'Dim thisPixel As Color = bmp_Image()

        Dim loc As Point = New Point(mBox.Location.X - ImagePosition.X, mBox.Location.Y - ImagePosition.Y)

        Dim orgRect As Rectangle = New Rectangle(loc.X, loc.Y, mBox.Size.Width, mBox.Size.Height)

        Dim thisPixColor As Integer = bm.GetPixel(loc.X, loc.Y).ToArgb
        Dim maxSize As Size = bm.Size
        Dim maxUpTravel As Integer = Math.Abs(loc.Y - startPoint.Y)
        Dim maxDnTravel As Integer = Math.Abs(loc.Y - (startPoint.Y + bm.Height))
        Dim maxLtTravel As Integer = Math.Abs(loc.X - startPoint.Y)
        Dim maxRtTravel As Integer = Math.Abs(loc.X - (startPoint.Y + bm.Width))
        Dim upDistance As Integer = 0
        Dim ltDistance As Integer = 0
        Dim dnDistance As Integer = 0
        Dim rtDistance As Integer = 0
        For i As Integer = 0 To maxLtTravel - 1
            Dim nextPix As Integer = bm.GetPixel(loc.X - i, loc.Y).ToArgb
            If nextPix <> thisPixColor Then
                ltDistance = loc.X - i
                Exit For
            End If
        Next
        For i As Integer = 0 To maxUpTravel - 1
            Dim nextPix As Integer = bm.GetPixel(loc.X, loc.Y - i).ToArgb
            If nextPix <> thisPixColor Then
                upDistance = loc.Y - i
                Exit For
            End If
        Next
        For i As Integer = 0 To maxRtTravel - 1
            Dim nextPix As Integer = bm.GetPixel(loc.X + i, loc.Y).ToArgb
            If nextPix <> thisPixColor Then
                rtDistance = loc.X + i
                Exit For
            End If
        Next
        For i As Integer = 0 To maxDnTravel - 1
            Dim nextPix As Integer = bm.GetPixel(loc.X, loc.Y + i).ToArgb
            If nextPix <> thisPixColor Then
                dnDistance = loc.Y + i
                Exit For
            End If
        Next
        If upDistance = 0 Or dnDistance = 0 Or ltDistance = 0 Or rtDistance = 0 Then
            Return
        End If

        Dim newRect As Rectangle = New Rectangle(ltDistance, upDistance, (rtDistance - ltDistance), (dnDistance - upDistance))
        If newRect.Width < 10 Or newRect.Height < 10 Then
            Return
        End If
        mBox.Size = New Size(newRect.Width, newRect.Height)
        'mBox.Location = New Point(ltDistance, upDistance)
        mBox.Location = New Point(ltDistance + ImagePosition.X, upDistance + ImagePosition.Y)
        Return
    End Sub


    Private Function CheckNewVariable(ByVal VarName As String) As Boolean
        For i As Integer = 0 To _MyVarTextBox.Count - 1
            If _MyVarTextBox(i).Name = VarName Then
                For j As Integer = 0 To myForm.FormVars.Count - 1
                    If _MyVarTextBox(i).Name = myForm.FormVars(j).FieldName Then Return False
                Next
            End If
        Next
        Return True
    End Function


    Private Sub dwgPanel_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dwgPanel.MouseClick
        Dim GroupID As String = ""
        Dim key As Keys = Keys.ShiftKey
        Dim mk = GetAsyncKeyState(key) And &H8000US
        If mk Then
            ShiftKey = True
        Else
            ShiftKey = False
            If BoundingBoxVisible Then
                Me.dwgPanel.Invalidate()
                Me.Invalidate()
                BoundingBoxVisible = False
            End If
        End If
        'ClearBoundingBox()
        If FormMode = mode.Insert And (btnAddVar.Checked Or Me.btn_Signbox.Checked Or Me.btn_YNNA_Select.Checked) Then
            'Dim myLoc As Point = Me.dwgPanel.PointToClient(New Point(e.X, e.Y))
            Dim myLoc As Point = New Point(e.X, e.Y)
            If Not TextBoxLocationOK(myLoc) Then Return
            Dim mBox As TextBox = MakeNewTextBox(myLoc)
            AutoSizeTextBox(mBox)
            AddTextBox(mBox)
            'mBox.Visible = True
            'mBox.BringToFront()
            'mBox.Select()
            'mBox.Focus()
            SelectedBox.Clear()
            SelectedBox.Add(mBox)

            If Not Me.btnAutoSize.Checked Then
                Me.btnAddVar.Checked = False
                '2.1.0.42
                Me.btn_Signbox.Checked = False
                Me.btn_YNNA_Select.Checked = False
            Else
                FormMode = mode.Insert
            End If
            Me.isDragging = False
            Me.dwgPanel.Invalidate()
            Me.Invalidate()

            Return
        End If
        'If FormMode = mode.BoxSelected And btnAddVar.Checked And btnAutoSize.Checked Then
        '    'Dim myLoc As Point = Me.dwgPanel.PointToClient(New Point(e.X, e.Y))


        '    Dim myLoc As Point = New Point(e.X, e.Y)
        '    If Not TextBoxLocationOK(myLoc) Then Return
        '    Dim mBox As TextBox = MakeNewTextBox(myLoc)
        '    AutoSizeTextBox(mBox)
        '    AddTextBox(mBox)
        '    'mBox.Visible = True
        '    'mBox.BringToFront()
        '    'mBox.Select()
        '    'mBox.Focus()
        '    SelectedBox.Clear()
        '    SelectedBox.Add(mBox)

        '        FormMode = mode.Insert
        '    Me.isDragging = False
        '    Me.dwgPanel.Invalidate()
        '    Me.Invalidate()

        '    Return
        'End If
        'If FormMode = mode.Insert Then
        '    '    mBox.Location = Me.Panel1.PointToClient(New Point(e.X, e.Y))

        '    For Each mbox As TextBox In SelectedBox
        '        mbox.Location = New Point(e.X, e.Y)
        '        AddTextBox(mbox)
        '    Next

        '    FormMode = mode.None
        '    SelectedBox.Clear()
        '    dwgPanel.Cursor = Cursors.Default
        'ElseIf FormMode = mode.BoxSelected Then
        '    'FormMode = mode.None
        '    'SelectedBox.Clear()
        'End If

        Dim BoxClicked As Boolean = False
        For Each cntl As Control In dwgPanel.Controls
            Dim mBox As TextBox = TryCast(cntl, TextBox)
            If Not mBox Is Nothing Then
                Dim mBoxRect As New Rectangle(mBox.Bounds.X, mBox.Bounds.Y, mBox.Bounds.Width + 1, mBox.Bounds.Height + 1)
                If mBoxRect.Contains(e.X, e.Y) Then
                    If mBox.Tag = CurrentPage Then
                        'theRectangle = mBox.Bounds
                        'theRectangle = New Rectangle(0, 0, 0, 0)
                        'ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
                        'ClearBoundingBox()

                        'mBox.Visible = True
                        'mBox.BringToFront()
                        ''mBox.Select()
                        'mBox.Focus()


                        If Not ShiftKey Then
                            'For Each tBox As TextBox In SelectedBox
                            '    tBox.Visible = False
                            'Next
                            SelectedBox.Clear()
                        End If
                        SelectedBox.Add(mBox)
                        For i As Integer = 0 To dt_FieldGroups.Rows.Count - 1
                            If dt_FieldGroups.Rows(i)("TextBoxName") = SelectedBox(0).Name Then
                                GroupID = dt_FieldGroups.Rows(i)("GroupID")
                            End If
                        Next
                        BoxClicked = True
                        'FormMode = mode.BoxSelected
                        'UpdateBoundingBox(mBox, New Point(e.X, e.Y))
                        'Me.dwgPanel.Invalidate()
                        'Me.Invalidate()
                        dwgPanel.Invalidate()
                    End If
                    'Else
                    '    If Not ShiftKey Then
                    '        mBox.Visible = False
                    '        SelectedBox.Clear()
                    '    End If

                End If
            End If
        Next
        If Not BoxClicked Then
            'For Each mBox As TextBox In SelectedBox
            '    mBox.Visible = False
            'Next

            If Not ShiftKey Then SelectedBox.Clear()
            Me.dwgPanel.Invalidate()
        End If


        If SelectedBox.Count = 0 Then
            FormMode = mode.None
            dwgPanel.Cursor = Cursors.Default
            If Not VGridControl1 Is Nothing Then
                VGridControl1.Dispose()
            End If
        Else
            If btnProperties.Checked Then
                Dim dt As DataTable = GetSelectedTextBoxFieldProperties()
                If Not dt Is Nothing Then DisplayTextBoxPropertyGrid(dt)
            End If
            If GroupID > "" And SelectedBox.Count = 1 Then
                For i As Integer = 0 To dt_FieldGroups.Rows.Count - 1
                    For Each cntl As Control In dwgPanel.Controls
                        Dim mBox As TextBox = TryCast(cntl, TextBox)
                        If Not mBox Is Nothing Then
                            If dt_FieldGroups.Rows(i)("TextBoxName") <> SelectedBox(0).Name Then
                                If dt_FieldGroups.Rows(i)("GroupID") = GroupID And dt_FieldGroups.Rows(i)("TextBoxName") = mBox.Name Then
                                    SelectedBox.Add(mBox)
                                End If
                            End If
                        End If
                    Next
                Next
            End If

            'Me.dwgPanel.Invalidate()
            'Me.Invalidate()
        End If

        Me.isDragging = False
        'Me.dwgPanel.Invalidate()
        'Me.Invalidate()
        Me.Activate()
        Me.Select()
        Me.cboVarSearch.Focus()

    End Sub


    Private Sub PageRefresh()
        Dim workingImage As Image = _FormImages(CurrentPage)
        Dim bmp_Image As New Bitmap(workingImage)

        ImageSize = bmp_Image.Size
        NewImageSize = bmp_Image.Size

        bm = New Bitmap(ImageSize.Width, ImageSize.Height)

        dwgPanel.Width = ImageSize.Width
        dwgPanel.Height = ImageSize.Height
        dwgPanel.AutoScrollMinSize = NewImageSize

        MakeTransparent(bmp_Image, workingImage)

        'dwgPanel.BackgroundImage = (bmp_Image)
        'dwgPanel.BackgroundImageLayout = ImageLayout.None

        Me.tbxPgNum.Text = "Page " + (CurrentPage + 1).ToString + " of " + myForm.FormPageCount.ToString
        For Each tbx As TextBox In _MyVarTextBox
            If tbx.Tag = CurrentPage Then
                'tbx.Visible = True
                'tbx.BringToFront()
            Else
                tbx.Visible = False
            End If
        Next
        Me.Refresh()
    End Sub


    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        If CurrentPage <> 0 Then
            CurrentPage = 0
            PageRefresh()
        End If
    End Sub


    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        If CurrentPage > 0 Then
            CurrentPage = CurrentPage - 1
            PageRefresh()
        End If
    End Sub


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If CurrentPage < (_FormImages.Count - 1) Then
            CurrentPage = CurrentPage + 1
            PageRefresh()
        End If
    End Sub


    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        If CurrentPage < (_FormImages.Count - 1) Then
            CurrentPage = (_FormImages.Count - 1)
            PageRefresh()
        End If
    End Sub


    Private Sub decreaseFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles decreaseFont.Click
        If FormMode <> mode.BoxSelected Then Return
        For Each mbox As TextBox In SelectedBox
            If mbox.Font.Size <= 2 Then Return
            Dim newSize = mbox.Font.Size - 1
            Dim myFont As Font = New Font(mbox.Font.Name, newSize, mbox.Font.Style)
            mbox.Font = myFont
        Next

        Me.dwgPanel.Invalidate()
        '        Me.Invalidate()
    End Sub


    Private Function FormModified() As Boolean
        'Return True
        If Not ModifiedFlag Then Return False
        If _MyVarTextBox.Count <> myForm.FormVars.Count Then Return True
        For Each tbx As TextBox In _MyVarTextBox
            For i As Integer = 0 To myForm.FormVars.Count - 1
                If Not tbx.ReadOnly Then
                    If tbx.Name <> myForm.FormVars(i).FieldName Then Return True
                    If tbx.Text <> myForm.FormVars(i).Value Then Return True
                End If
            Next
        Next
        For i As Integer = 0 To dt_CustomNames.Rows.Count - 1
            If dt_CustomNames.Rows(i)(1) = myForm.FormVars(i).FieldName Then
                If dt_CustomNames.Rows(i)(0) <> myForm.FormVars(i).CustomName Then Return True
            End If
        Next
        For i As Integer = 0 To dt_FieldGroups.Rows.Count - 1
            If dt_FieldGroups.Rows(i)(1) = myForm.FormVars(i).FieldName Then
                If dt_FieldGroups.Rows(i)(0) <> myForm.FormVars(i).GroupID Then Return True
            End If
        Next
        Return False
    End Function


    Private Sub DoSaveFormVars()
        Try
            'Dim useProjectDB As String = "USE [" + runtime.selectedProject + "] "
            'Dim query As String = useProjectDB + "SELECT * FROM aux_subforms_fields WHERE FormID = '" + FormID.ToString + "'"
            'Dim query = useProjectDB + "SELECT NumberofElements FROM forms WHERE ID = '" + _FormID.ToString + "'"
            'Dim dt_form As New DataTable
            'dt_form = Utilities.ExecuteRemoteQuery(query, "project")

            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            Dim qry = "SELECT NumberofElements FROM forms WHERE MUID = '" + _FormID.ToString + "'"
            'sqlPrjUtils.OpenConnection()
            Dim dt_form As DataTable = runtime.SQLProject.ExecuteQuery(qry)
            'sqlPrjUtils.CloseConnection()

            If Not IsDBNull(dt_form.Rows(0)(0)) Then
                myForm.FormNumberOfElements = dt_form.Rows(0)(0)
            Else
                myForm.FormNumberOfElements = 0
            End If

            Dim i As Integer = 0
            For Each mbox As TextBox In _MyVarTextBox
                myForm.remoteAddUpdateFormVar(MakeFormItem(mbox))
                i = i + 1
            Next

            'Utilities.SyncProjectDB(runtime.selectedProject)
            'myForm.InitializeFormParameters()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Utilities.logErrorMessage("FormDesigner.FormEditing.DoSaveFormVars-" + ex.Message)
        End Try

    End Sub

    Private Sub SaveForm()
        Me.Enabled = False
        Me.Cursor = Cursors.AppStarting
        DoSaveFormVars()
        ModifiedFlag = False


        'If FormModified() Then
        '    DoSaveFormVars()
        '    ModifiedFlag = False
        'End If

        If myForm.FormNumberOfElements > 0 Then
            Utilities.PopulateMultiElementFormFields(_FormID)
        End If

        'Utilities.SyncProjectDB(runtime.selectedProject)
        myForm.InitializeFormParameters()

        Me.Cursor = Cursors.Default
        Me.Enabled = True
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveForm()
    End Sub


    Private Sub Panel1_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dwgPanel.DragEnter
        If FormMode = mode.None Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub


    Private Sub Panel1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dwgPanel.DragDrop
        If FormMode = mode.None Then

            'test for source control
            Dim lbx As ListBox = TryCast(e.Data.GetData(GetType(ListBox)), ListBox)

            Dim myName As String = Nothing

            If Not lbx Is Nothing Then
                myName = "Element" + lbx.Tag.ToString + "@" + lbx.Text
            Else
                Dim tn As TreeNode = TryCast(e.Data.GetData(GetType(TreeNode)), TreeNode)
                myName = tn.Parent.Text + "@" + tn.Text
            End If

            For Each tbx As TextBox In _MyVarTextBox
                If tbx.Name = myName Then
                    Return
                End If
            Next
            FormMode = mode.None
            SelectedBox.Clear()
            'Dim mBox = New TextBox
            'mBox.Location = Me.dwgPanel.PointToClient(New Point(e.X, e.Y))
            ''mBox.Font = Me.ParentForm.Name

            'mBox.Font = mFont
            'mBox.Text = myName
            'mBox.Name = myName
            'mBox.Tag = CurrentPage
            'FormMode = mode.Insert
            Dim myLoc As Point = Me.dwgPanel.PointToClient(New Point(e.X, e.Y))
            If TextBoxLocationOK(myLoc) Then
                FormMode = mode.Insert
                Dim MyParent As FormMain = Me.ParentForm
                Dim mBox As TextBox = New TextBox()
                mBox.Name = myName
                '            Panel1.Controls.Add(mBox)
                mBox.Font = MyParent.FontSelect.Font
                mBox.Text = myName
                mBox.BringToFront()
                mBox.BackColor = MyParent.BkColor.BackColor
                mBox.Tag = CurrentPage
                mBox.Location = myLoc
                VarCtr = VarCtr + 1
                AutoSizeTextBox(mBox)
                AddTextBox(mBox)
                'mBox.Visible = True
                'mBox.BringToFront()
                'mBox.Select()
                'mBox.Focus()

                'SelectedBox.Add(mBox)

                'FormMode = mode.BoxSelected
                'UpdateBoundingBox(mBox, New Point(e.X, e.Y))

                'SelectedBox.Add(mBox)
                'FormMode = mode.BoxSelected
                'UpdateBoundingBox(mBox, New Point(e.X, e.Y))
            End If
            '            _MyFormItems.Add(MakeFormItem(mBox))
            FormMode = mode.None
            SelectedBox.Clear()
            'PageRefresh()
            Me.dwgPanel.Invalidate()
            Me.Invalidate()


        End If
    End Sub


    Private Sub IncreaseFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncreaseFont.Click
        If FormMode <> mode.BoxSelected Then Return
        For Each mbox As TextBox In SelectedBox
            If mbox.Font.Size >= 72 Then Return
            Dim newSize = mbox.Font.Size + 1
            Dim myFont As Font = New Font(mbox.Font.Name, newSize, mbox.Font.Style)
            mbox.Font = myFont
        Next

        Me.dwgPanel.Invalidate()
        '    Me.Invalidate()
    End Sub


    Private Sub FormEditing_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If FormModified() Then
            If (MessageBox.Show("Form has been modified; do you wish to save?", "FormSave", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                SaveForm()
                'DoSaveFormVars()
            End If
        End If
        FormEditManager.FormClosed(Me.Text)
    End Sub


    Private Sub btn_Group_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Group.Click
        'If FormMode <> mode.BoxSelected Then Return
        Dim NewGroupID As Integer = 1


        dt_FieldGroups.DefaultView.Sort = "GroupID DESC"
        dt_FieldGroups = dt_FieldGroups.DefaultView.ToTable()
        'NewGroupID = CInt(dt_FieldGroups.Rows(0)(0)) + 1
        If dt_FieldGroups.Rows.Count = 0 Then
            NewGroupID = 1
        Else
            NewGroupID = CInt(dt_FieldGroups.Rows(0)(0)) + 1
        End If
        While TestGroupID(NewGroupID)
            NewGroupID = NewGroupID + 1
        End While

        For Each mbox As TextBox In SelectedBox
            Dim IsListed As Boolean = False
            'see if textbox is listed
            For i As Integer = 0 To dt_FieldGroups.Rows.Count - 1
                If dt_FieldGroups.Rows(i)(1) = mbox.Name Then
                    IsListed = True
                    dt_FieldGroups.Rows(i)(0) = NewGroupID
                End If
            Next

            If Not IsListed Then
                dt_FieldGroups.Rows.Add(NewGroupID, mbox.Name)
            End If
        Next

    End Sub

    Private Function TestGroupID(ByVal _GroupID As Integer) As Boolean
        Dim retvalue As Boolean = False
        For i As Integer = 0 To dt_FieldGroups.Rows.Count - 1
            If dt_FieldGroups.Rows(i)(0) = _GroupID Then
                retvalue = True
            End If
        Next

        Return retvalue
    End Function


    Private Sub btn_Ungroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ungroup.Click
        'If FormMode <> mode.BoxSelected Then Return
        For Each mbox As TextBox In SelectedBox
            For i As Integer = 0 To dt_FieldGroups.Rows.Count - 1
                If dt_FieldGroups.Rows(i)(1) = mbox.Name Then
                    dt_FieldGroups.Rows(i).Delete()
                    Exit For
                End If
            Next
        Next

        SelectedBox.Clear()
        Me.dwgPanel.Invalidate()
    End Sub





    Private Sub FormEditing_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' FormEditManager.FormFocus(_FormID, _FormName)
    End Sub



    Private Sub FormEditing_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Static Dim ctr = 0
        ctr = ctr + 1
        'FormEditManager.SelectedFormID = DocumentID
        'FormEditManager.SelectedFormname = DocumentName
        FormEditManager.FormFocus(_FormID, _FormName)

        'FormDesignerManager.SelectedPackageID = PackageID
        'FormDesignerManager.SelectedPackageOwnerID = PackageOwner
        'FormDesignerManager.SelectedPackagename = PkgNumber.Text
        'FormDesignerManager.SelectedPackageOwnerName = OwnerID.Text

    End Sub

    Private Sub btnAutoSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoSize.Click
        If btnAutoSize.Checked = False Then
            btnAutoSize.Checked = True
        Else
            btnAutoSize.Checked = False
        End If
    End Sub
    Private Sub VGridControl1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs)
        If newCellValue > "" Then
            Dim nu As String = newCellValue
            Dim id As Integer = newSelectedTextBoxIndex
            newCellValue = ""
            newSelectedTextBoxIndex = -1
            If id < 0 Then Return
            For i As Integer = 0 To dt_CustomNames.Rows.Count - 1
                Dim fName = dt_CustomNames.Rows(i)(0)
                If dt_CustomNames.Rows(i)(0) = nu Then
                    MessageBox.Show("Name '" + nu + "' already in use")
                    Return
                End If
            Next
            For i As Integer = 0 To dt_CustomNames.Rows.Count - 1
                Dim fName = dt_CustomNames.Rows(i)(0)
                Dim cName = _MyVarTextBox(id).Name
                If dt_CustomNames.Rows(i)(1) = _MyVarTextBox(id).Name Then
                    dt_CustomNames.Rows(i)(0) = nu
                    Return
                End If
            Next
        End If

        'Dim thisRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = e.Row
        'If thisRow.Name = "rowName" Then
        '    Dim nu As String = e.Value
        '    Dim id As Integer = GetSelectedTextBoxIndex()
        '    If id < 0 Then Return
        '    For i As Integer = 0 To dt_CustomNames.Rows.Count - 1
        '        Dim fName = dt_CustomNames.Rows(i)(0)
        '        If dt_CustomNames.Rows(i)(0) = nu Then
        '            MessageBox.Show("Name '" + nu + "' already in use")
        '            Return
        '        End If
        '    Next

        '    For i As Integer = 0 To dt_CustomNames.Rows.Count - 1
        '        Dim fName = dt_CustomNames.Rows(i)(0)
        '        Dim cName = myForm.FormVars(id).FieldName
        '        If dt_CustomNames.Rows(i)(1) = myForm.FormVars(id).FieldName Then
        '            dt_CustomNames.Rows(i)(0) = nu
        '            Return
        '        End If
        '    Next
        'End If
    End Sub
    Private Function GetSelectedTextBoxIndex()
        If SelectedBox.Count <> 1 Then
            If SelectedBox.Count > 1 Then
                MessageBox.Show("Please select one TextBox")
            Else
                MessageBox.Show("Please select a TextBox")
            End If
            Return -1
        End If
        Dim mBox As TextBox = SelectedBox(0)
        If Not mBox Is Nothing Then
            For i As Integer = 0 To _MyVarTextBox.Count - 1
                If mBox.Name = _MyVarTextBox(i).Name Then
                    Return i
                End If
            Next
        End If
        Return -1
    End Function
    Private Function GetSelectedTextBoxFieldProperties() As DataTable
        Dim hdrs() As String = {"Name"}
        Dim DisplayTable As DataTable = New DataTable("FieldProperties")
        'DisplayTable.Columns.Add(New DataColumn("Num", GetType(Integer)))
        'DisplayTable.PrimaryKey = New DataColumn() {DisplayTable.Columns("PkgID")}
        Dim id As Integer = GetSelectedTextBoxIndex()
        If id < 0 Then Return Nothing
        Dim i As Integer = 0
        Dim fldCustomName As String = _MyVarTextBox(id).Name
        For i = 0 To dt_CustomNames.Rows.Count - 1
            If dt_CustomNames.Rows(i)(1) = _MyVarTextBox(id).Name Then
                fldCustomName = dt_CustomNames.Rows(i)(0)
                Exit For
            End If
        Next

        Dim myVal() As String = {fldCustomName}

        For Each s As String In hdrs
            Dim ThisColumn As DataColumn = New DataColumn(s, GetType(String))
            ThisColumn.ColumnName = s
            DisplayTable.Columns.Add(ThisColumn)
        Next

        Dim dRow As DataRow = DisplayTable.NewRow

        For i = 0 To hdrs.Length - 1
            dRow(hdrs(i)) = myVal(i)
        Next
        DisplayTable.Rows.Add(dRow)
        Return DisplayTable
    End Function
    Private Sub DisplayTextBoxPropertyGrid(ByVal dt As DataTable)
        If Not VGridControl1 Is Nothing Then
            VGridControl1.Dispose()
        End If
        VGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl
        VGridControl1.Text = "TextBox Properties"
        VGridControl1.Location = New System.Drawing.Point(0, 30)
        VGridControl1.Name = "VGridControl1"
        VGridControl1.Size = New System.Drawing.Size(200, 200)
        '        VGridControl1.Rows(0).Height = 50
        AddHandler VGridControl1.CellValueChanged, AddressOf VGridControl1_CellValueChanged
        AddHandler VGridControl1.CellValueChanging, AddressOf VGridControl1_CellValueChanging
        AddHandler VGridControl1.Leave, AddressOf VGridControl1_Leave
        VGridControl1.DataSource = dt
        Me.Controls.Add(VGridControl1)
        VGridControl1.BringToFront()
        VGridControl1.Dock = DockStyle.None
    End Sub
    Private Sub btnProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProperties.Click
        If btnProperties.Checked Then
            If Not VGridControl1 Is Nothing Then
                VGridControl1.Dispose()
            End If
            btnProperties.Checked = False
            Return
        Else
            btnProperties.Checked = True
        End If
        Dim dt As DataTable = GetSelectedTextBoxFieldProperties()
        If dt Is Nothing Then Return
        DisplayTextBoxPropertyGrid(dt)
    End Sub

    Private Sub VGridControl1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If newCellValue > "" Then
            Dim nu As String = newCellValue
            Dim id As Integer = newSelectedTextBoxIndex
            newCellValue = ""
            newSelectedTextBoxIndex = -1
            If id < 0 Then Return
            For i As Integer = 0 To dt_CustomNames.Rows.Count - 1
                Dim fName = dt_CustomNames.Rows(i)(0)
                If dt_CustomNames.Rows(i)(0) = nu Then
                    MessageBox.Show("Name '" + nu + "' already in use")
                    Return
                End If
            Next
            For i As Integer = 0 To dt_CustomNames.Rows.Count - 1
                'Dim fName = dt_CustomNames.Rows(i)(0)
                'Dim cName = _MyVarTextBox(i).Name
                If dt_CustomNames.Rows(i)(1) = _MyVarTextBox(id).Name Then
                    dt_CustomNames.Rows(i)(0) = nu
                    Return
                End If
            Next
        End If
    End Sub

    Private Sub VGridControl1_CellValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs)
        newCellValue = e.Value
        newSelectedTextBoxIndex = GetSelectedTextBoxIndex()
    End Sub

    Private Sub dwgPanel_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dwgPanel.Resize

    End Sub

    Private Sub FormEditing_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.ShiftKey Then
        '    ShiftKey = True
        '    stat_Main.Text = ShiftKey
        '    Return
        'Else
        '    ShiftKey = False
        'End If

        'If FormMode = mode.BoxSelected Then
        '    If e.KeyCode = Keys.Delete Then
        '        For Each mbox As TextBox In SelectedBox
        '            DeleteVariable(mbox)
        '        Next
        '        SelectedBox.Clear()
        '        Return
        '    End If




        '    For Each mbox As TextBox In SelectedBox
        '        If e.KeyCode = Keys.Left Then
        '            mbox.Location = New Point(mbox.Location.X - 1, mbox.Location.Y)
        '        End If
        '        If e.KeyCode = Keys.Right Then
        '            mbox.Location = New Point(mbox.Location.X + 1, mbox.Location.Y)
        '        End If
        '        If e.KeyCode = Keys.Up Then
        '            mbox.Location = New Point(mbox.Location.X, mbox.Location.Y - 1)
        '        End If
        '        If e.KeyCode = Keys.Down Then
        '            mbox.Location = New Point(mbox.Location.X, mbox.Location.Y + 1)
        '        End If
        '        Me.rect.Height = mbox.Bounds.Height + 4
        '        Me.rect.Width = mbox.Bounds.Width + 4
        '        Me.rect.Location = New Point(mbox.Bounds.X - 2, mbox.Bounds.Y - 2)
        '        Me.rect1.Location = New Point(mbox.Bounds.X - 6, mbox.Bounds.Y + mbox.Height / 2 - 3)
        '        Me.rect2.Location = New Point(mbox.Bounds.X + mbox.Bounds.Width, mbox.Bounds.Y + mbox.Height / 2 - 3)
        '        Me.rect3.Location = New Point(mbox.Bounds.X, mbox.Bounds.Y - Me.rect3.Height)
        '        Me.rect4.Location = New Point(mbox.Bounds.X + (mbox.Bounds.Width / 2), mbox.Bounds.Y - 6)
        '        Me.rect5.Location = New Point(mbox.Bounds.X + (mbox.Bounds.Width / 2), mbox.Bounds.Y + mbox.Height)
        '    Next
        '    Me.dwgPanel.Invalidate()
        'End If


    End Sub

    Private Sub FormEditing_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.ShiftKey Then
            ShiftKey = False
            SelectedBox.Clear()
            ShiftKey = False
        End If
        If e.KeyCode = Keys.ShiftKey Then
            ShiftKey = True
            stat_Main.Text = ShiftKey
            Return
        Else
            ShiftKey = False
        End If

        If FormMode = mode.BoxSelected Then
            If e.KeyCode = Keys.Delete Then
                For Each mbox As TextBox In SelectedBox
                    DeleteVariable(mbox)
                Next
                SelectedBox.Clear()
                Return
            End If




            For Each mbox As TextBox In SelectedBox
                If e.KeyCode = Keys.Left Then
                    mbox.Location = New Point(mbox.Location.X - 1, mbox.Location.Y)
                End If
                If e.KeyCode = Keys.Right Then
                    mbox.Location = New Point(mbox.Location.X + 1, mbox.Location.Y)
                End If
                If e.KeyCode = Keys.Up Then
                    mbox.Location = New Point(mbox.Location.X, mbox.Location.Y - 1)
                End If
                If e.KeyCode = Keys.Down Then
                    mbox.Location = New Point(mbox.Location.X, mbox.Location.Y + 1)
                End If
                Me.rect.Height = mbox.Bounds.Height + 4
                Me.rect.Width = mbox.Bounds.Width + 4
                Me.rect.Location = New Point(mbox.Bounds.X - 2, mbox.Bounds.Y - 2)
                Me.rect1.Location = New Point(mbox.Bounds.X - 6, mbox.Bounds.Y + mbox.Height / 2 - 3)
                Me.rect2.Location = New Point(mbox.Bounds.X + mbox.Bounds.Width, mbox.Bounds.Y + mbox.Height / 2 - 3)
                Me.rect3.Location = New Point(mbox.Bounds.X, mbox.Bounds.Y - Me.rect3.Height)
                Me.rect4.Location = New Point(mbox.Bounds.X + (mbox.Bounds.Width / 2), mbox.Bounds.Y - 6)
                Me.rect5.Location = New Point(mbox.Bounds.X + (mbox.Bounds.Width / 2), mbox.Bounds.Y + mbox.Height)
            Next
            Me.dwgPanel.Invalidate()
        End If



    End Sub

    Private Sub cboVarSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVarSearch.KeyDown

        Dim ValidKey As Boolean = False
        If e.KeyCode = Keys.Delete Then
            ValidKey = True
        End If
        If e.KeyCode = Keys.Left Then
            ValidKey = True
        End If
        If e.KeyCode = Keys.Right Then
            ValidKey = True
        End If
        If e.KeyCode = Keys.Up Then
            ValidKey = True
        End If
        If e.KeyCode = Keys.Down Then
            ValidKey = True
        End If
        If Not ValidKey Then
            Return
        End If





        If FormMode = mode.BoxSelected Then
            If e.KeyCode = Keys.Delete Then
                For Each mbox As TextBox In SelectedBox
                    DeleteVariable(mbox)
                Next
                SelectedBox.Clear()
                Return
            End If




            For Each mbox As TextBox In SelectedBox
                If e.KeyCode = Keys.Left Then
                    mbox.Location = New Point(mbox.Location.X - 1, mbox.Location.Y)
                End If
                If e.KeyCode = Keys.Right Then
                    mbox.Location = New Point(mbox.Location.X + 1, mbox.Location.Y)
                End If
                If e.KeyCode = Keys.Up Then
                    mbox.Location = New Point(mbox.Location.X, mbox.Location.Y - 1)
                End If
                If e.KeyCode = Keys.Down Then
                    mbox.Location = New Point(mbox.Location.X, mbox.Location.Y + 1)
                End If
                Me.rect.Height = mbox.Bounds.Height + 4
                Me.rect.Width = mbox.Bounds.Width + 4
                Me.rect.Location = New Point(mbox.Bounds.X - 2, mbox.Bounds.Y - 2)
                Me.rect1.Location = New Point(mbox.Bounds.X - 6, mbox.Bounds.Y + mbox.Height / 2 - 3)
                Me.rect2.Location = New Point(mbox.Bounds.X + mbox.Bounds.Width, mbox.Bounds.Y + mbox.Height / 2 - 3)
                Me.rect3.Location = New Point(mbox.Bounds.X, mbox.Bounds.Y - Me.rect3.Height)
                Me.rect4.Location = New Point(mbox.Bounds.X + (mbox.Bounds.Width / 2), mbox.Bounds.Y - 6)
                Me.rect5.Location = New Point(mbox.Bounds.X + (mbox.Bounds.Width / 2), mbox.Bounds.Y + mbox.Height)
            Next
            Me.dwgPanel.Invalidate()
        End If

    End Sub

    '2.1.0.42
    Private Sub btn_Signbox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Signbox.Click
        If btn_Signbox.Checked Then
            Me.dwgPanel.Cursor = Cursors.Default
            btn_Signbox.Checked = False
            FormMode = mode.None
            For Each cntl As Control In dwgPanel.Controls
                Dim mBox As TextBox = TryCast(cntl, TextBox)
                If Not mBox Is Nothing Then
                    mBox.Visible = False
                End If
            Next
            dwgPanel.Cursor = Cursors.Default
            SelectedBox.Clear()
            Return
        Else
            Me.btnAddVar.Checked = False
            btn_Signbox.Checked = True
        End If
        If FormMode = mode.None Then
            Me.dwgPanel.Cursor = Cursors.Cross
            FormMode = mode.Insert
        End If

    End Sub
    Private Sub btn_YNNA_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_YNNA_Select.Click
        If Me.btn_YNNA_Select.Checked Then
            Me.dwgPanel.Cursor = Cursors.Default
            btn_YNNA_Select.Checked = False
            FormMode = mode.None
            For Each cntl As Control In dwgPanel.Controls
                Dim mBox As TextBox = TryCast(cntl, TextBox)
                If Not mBox Is Nothing Then
                    mBox.Visible = False
                End If
            Next
            dwgPanel.Cursor = Cursors.Default
            SelectedBox.Clear()
            Return
        Else
            Me.btnAddVar.Checked = False
            btn_Signbox.Checked = False
            btn_YNNA_Select.Checked = True
        End If
        If FormMode = mode.None Then
            Me.dwgPanel.Cursor = Cursors.Cross
            FormMode = mode.Insert
        End If

    End Sub
End Class