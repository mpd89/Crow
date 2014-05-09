
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
'Imports System.Data.SqlServerCe
'Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL
'Imports DevExpress.XtraBars
'Imports DevExpress.XtraVerticalGrid.Rows
'Imports DevExpress.XtraEditors
'Imports DevExpress.XtraEditors.Controls
'Imports System.Data.OleDb
Public Class FormDesignerMain
    'Private sqlPrjUtils As DataUtils = New DataUtils("project")
    Public Class VarAttributes
        Enum dtype
            Text
            Number
            DateTime
            yesNo
        End Enum 'Days
        Private _XYCoordinates As Point = New Point(100, 100)
        Private _windowFont As Font = New Font("Arial", 8, FontStyle.Regular)
        Private _BackgroundColor As Color = SystemColors.Control
        Private _MapName As String = ""
        Private _linkTbl As String = ""
        Private _DefaultValue As String = ""
        Private _WtPcnt As Single = 0
        Private _DataType As dtype = dtype.Text
        Private _pageNumber As Integer = 0
        Private _TabPosition As Integer = 0
        Private _Width As Integer = 0
        Private _settingsChanged As Boolean = False

        <CategoryAttribute("Attributes"), ReadOnlyAttribute(True)> _
        Public Property XYCoordinates() As Point
            Get
                Return _XYCoordinates
            End Get
            Set(ByVal Value As Point)
                _XYCoordinates = Value
            End Set
        End Property

        <CategoryAttribute("Attributes")> _
        Public Property WindowFont() As Font
            Get
                Return _windowFont
            End Get
            Set(ByVal Value As Font)
                _windowFont = Value
            End Set
        End Property

        <CategoryAttribute("Attributes")> _
        Public Property BackgroundColor() As Color
            Get
                Return _BackgroundColor
            End Get
            Set(ByVal Value As Color)
                _BackgroundColor = Value
            End Set
        End Property

        <CategoryAttribute("Attributes"), _
        DefaultValueAttribute("")> _
        Public Property MapName() As String
            Get
                Return _MapName
            End Get
            Set(ByVal Value As String)
                _MapName = Value
            End Set
        End Property
        <CategoryAttribute("Attributes"), DescriptionAttribute("Link to System Variable."), _
        ReadOnlyAttribute(True), DefaultValueAttribute("")> _
                Public Property linkTbl() As String
            Get
                Return _linkTbl
            End Get
            Set(ByVal Value As String)
                _linkTbl = Value
            End Set
        End Property
        <CategoryAttribute("Attributes"), _
        DefaultValueAttribute("")> _
        Public Property DefaultValue() As String
            Get
                Return _DefaultValue
            End Get
            Set(ByVal Value As String)
                _DefaultValue = Value
            End Set
        End Property


        <CategoryAttribute("Attributes"), _
        DefaultValueAttribute(0)> _
        Public Property WtPcnt() As Single
            Get
                Return _WtPcnt
            End Get
            Set(ByVal Value As Single)
                _WtPcnt = Value
            End Set
        End Property

        <CategoryAttribute("Attributes"), _
        DefaultValueAttribute("")> _
        Public Property DataType() As dtype
            Get
                Return _DataType
            End Get
            Set(ByVal Value As dtype)
                _DataType = Value
            End Set
        End Property


        <DescriptionAttribute("The form page number this variable appears in."), _
        ReadOnlyAttribute(True), CategoryAttribute("Attributes"), _
        DefaultValueAttribute(0)> _
        Public Property PageNumber() As Integer
            Get
                Return _pageNumber
            End Get
            Set(ByVal Value As Integer)
                _pageNumber = Value
            End Set
        End Property
        <CategoryAttribute("Attributes"), _
        DefaultValueAttribute(0)> _
        Public Property TabPosition() As Integer
            Get
                Return _TabPosition
            End Get
            Set(ByVal Value As Integer)
                _TabPosition = Value
            End Set
        End Property
        <DescriptionAttribute("The text box width."), _
        CategoryAttribute("Attributes"), _
        DefaultValueAttribute(0)> _
        Public Property Width() As Integer
            Get
                Return _Width
            End Get
            Set(ByVal Value As Integer)
                _Width = Value
            End Set
        End Property

        <BrowsableAttribute(False), DefaultValueAttribute(False)> _
    Public Property SettingsChanged() As Boolean
            Get
                Return _settingsChanged
            End Get
            Set(ByVal Value As Boolean)
                _settingsChanged = Value
            End Set
        End Property

    End Class



    'Const CtrlMask As Byte = 8
    'Private Structure formItem
    '    ' Public members, accessible from throughout declaration region.
    '    Public FieldName As String
    '    Public MapName As String
    '    Public linkTbl As String
    '    Public Value As String
    '    Public WtPcnt As Single
    '    Public Color As String
    '    Public DataType As VarAttributes.dtype
    '    Public PgNum As Integer
    '    Public View As String
    '    Public Position As Integer
    '    Public PosX As Integer
    '    Public PosY As Integer
    '    Public Width As Integer
    '    Public Height As Integer
    '    Public TabPosition As Integer
    '    Public FontName As String
    '    Public FontSize As Single
    '    Public FontBold As Boolean
    '    Public FontItalic As Boolean
    '    Public FontUnderline As Boolean
    '    ' Public Selected As Boolean

    '    ' Procedure member, which can access structure's private members.
    'End Structure


    ''Private connSQLServer As SqlConnection = daqartDLL.connections.serverRemoteConnect(connSQLServer)
    ''Private useProjectDB As String = "USE [" + runtime.selectedProject + "] "
    ''Private useServerDB As String = "USE [ServerDB] "
    'Private FormName As String
    'Private FormID As Integer
    'Private isDrag As Boolean = False
    'Private theRectangle As New Rectangle(New Point(0, 0), New Size(0, 0))
    'Private allRectangle() As Rectangle
    'Private txtBox As TextBox
    'Private frmItem As formItem = New formItem
    'Private DefaultItemValues As formItem = New formItem
    'Private FormModified As Boolean = False
    'Private formVar As New List(Of formItem)
    'Private itmIndex As Integer
    'Private startPoint As Point
    'Private endPoint As Point
    'Private Xoffset As Integer
    'Private Yoffset As Integer
    'Private PageCount As Integer
    'Private CurrentPage As Integer
    'Private Itemselected As Integer
    'Private VarAttributeDS As DataSet
    'Private popupDGview As DataGridView
    'Private VarNameTable As DataTable
    'Private AttributeTable As DataTable
    'Private AttributeList As String() = {"FieldName", "MapName", "linkTbl", "Value", "WtPcnt", "Color", "DataType", _
    '                                    "PgNum", "View", "Position", "PosX", "PosY", "Width", "Height", "TabPosition", _
    '                                    "FontName", "FontSize", "FontBold", "FontItalic", "FontUnderline"}



    'Private OptionsPropertyGrid As System.Windows.Forms.PropertyGrid
    'Private AttributeSet As VarAttributes = New VarAttributes()
    'Private Function MakeFieldString(ByVal itm As formItem) As String
    '    Dim fieldStr As String = _
    '            itm.FieldName + "&001" + _
    '            itm.MapName + "&001" + _
    '            itm.linkTbl + "&001" + _
    '            itm.Value + "&001" + _
    '            itm.WtPcnt.ToString + "&001" + _
    '            itm.Color + "&001" + _
    '            itm.DataType.Number.ToString + "&001" + _
    '            itm.PgNum.ToString + "&001" + _
    '            itm.View + "&001" + _
    '            itm.Position.ToString + "&001" + _
    '            itm.PosX.ToString + "&001" + _
    '            itm.PosY.ToString + "&001" + _
    '            itm.Width.ToString + "&001" + _
    '            itm.Height.ToString + "&001" + _
    '            itm.TabPosition.ToString + "&001" + _
    '            itm.FontName + "&001" + _
    '            itm.FontSize.ToString + "&001" + _
    '            itm.FontBold.ToString + "&001" + _
    '            itm.FontItalic.ToString + "&001" + _
    '            itm.FontUnderline.ToString + "&001"
    '    Dim I As Integer = itm.DataType

    '    Return fieldStr
    'End Function
    'Private Sub ShowPropertyTable(ByVal thisItem As Integer)
    '    AttributeTable.Rows.Clear()
    '    VarNameTable.Rows.Clear()
    '    Dim i As Integer = 0
    '    For Each itm As formItem In formVar
    '        Dim row As DataRow = VarNameTable.NewRow()
    '        row(0) = i
    '        row(1) = itm.MapName
    '        VarNameTable.Rows.Add(row)
    '        i = i + 1
    '    Next
    '    VarNameTable.AcceptChanges()
    '    If thisItem >= 0 Then
    '        i = 0
    '        Dim val() As String = Split(MakeFieldString(formVar(thisItem)), "&001")
    '        For Each attribute As String In AttributeList
    '            AttributeTable.Rows.Add(New Object() {i, thisItem, attribute, val(i)})
    '            i = i + 1
    '        Next
    '    End If
    '    AttributeTable.AcceptChanges()
    '    Dim myItm As formItem = formVar.Item(thisItem)

    '    Dim drawFont As System.Drawing.Font = New Font(myItm.FontName, myItm.FontSize, _
    '        IIf(myItm.FontBold, FontStyle.Bold, IIf(myItm.FontItalic, FontStyle.Italic, _
    '        IIf(myItm.FontUnderline, FontStyle.Underline, FontStyle.Regular))), GraphicsUnit.Point)
    '    Dim customColor As Color = System.Drawing.Color.FromArgb(myItm.Color)

    '    AttributeSet.XYCoordinates = New Point(formVar(thisItem).PosX, formVar(thisItem).PosY)
    '    AttributeSet.WindowFont = drawFont
    '    AttributeSet.BackgroundColor = customColor
    '    AttributeSet.MapName = myItm.MapName
    '    AttributeSet.linkTbl = myItm.linkTbl
    '    AttributeSet.DefaultValue = myItm.linkTbl
    '    AttributeSet.WtPcnt = myItm.WtPcnt
    '    AttributeSet.DataType = myItm.DataType
    '    AttributeSet.PageNumber = myItm.PgNum
    '    AttributeSet.TabPosition = myItm.TabPosition
    '    AttributeSet.Width = myItm.Width
    '    AttributeSet.SettingsChanged = False
    '    OptionsPropertyGrid.Visible = True
    '    OptionsPropertyGrid.BringToFront()
    '    OptionsPropertyGrid.Width = Me.SplitContainer1.Panel1.Width
    '    OptionsPropertyGrid.Refresh()


    'End Sub
    'Private Sub MakeNewFormItem()

    '    frmItem.FieldName = "Field_" + (formVar.Count).ToString
    '    frmItem.MapName = frmItem.FieldName
    '    While DuplicateFieldName(frmItem.MapName) >= 0
    '        frmItem.MapName = frmItem.MapName + "_" + (formVar.Count).ToString
    '    End While
    '    frmItem.linkTbl = ""
    '    frmItem.Value = mnuDefaultValue.Text
    '    '        frmItem.WtPcnt = Me.ComputeWtPcnt()
    '    frmItem.WtPcnt = 0
    '    frmItem.Color = mnuTxtColor.BackColor.ToArgb.ToString
    '    frmItem.DataType = mnuDataType.SelectedIndex
    '    frmItem.Position = formVar.Count - 1
    '    frmItem.PosX = startPoint.X
    '    frmItem.PosY = startPoint.Y
    '    frmItem.Width = theRectangle.Width
    '    frmItem.Height = Label1.Height
    '    frmItem.TabPosition = formVar.Count.ToString
    '    frmItem.FontName = lblSampleFont.Font.FontFamily.Name
    '    frmItem.FontSize = lblSampleFont.Font.Size.ToString
    '    frmItem.FontUnderline = False
    '    frmItem.FontBold = False
    '    frmItem.FontItalic = False
    '    'frmItem.Selected = False
    'End Sub



    'Private Sub DrawTextBox()
    '    If Not txtBox Is Nothing Then
    '        '            txtBox.Dispose()
    '    End If


    '    txtBox = New System.Windows.Forms.TextBox()
    '    '        txtBox.Size = theRectangle.Size
    '    txtBox.Name = "Box"
    '    txtBox.Text = "Field_" + (formVar.Count).ToString
    '    txtBox.Font = lblSampleFont.Font
    '    txtBox.BackColor = mnuTxtColor.BackColor

    '    txtBox.BringToFront()
    '    '       Dim properties As DevExpress.XtraEditors.Repository.RepositoryItemComboBox = cboUserVar.Properties
    '    '      properties.Items.Add(frmItem.FieldName)
    '    txtBox.AllowDrop = True
    '    txtBox.Focus()
    '    Me.TabControl1.TabPages(TabControl1.SelectedIndex).Controls.Add(txtBox)
    '    txtBox.Location = New Point(startPoint.X, startPoint.Y)
    '    txtBox.Width = frmItem.Width

    '    AddHandler txtBox.KeyDown, AddressOf txtBox_KeyDown
    '    AddHandler txtBox.DragEnter, AddressOf txtBox_DragEnter
    '    AddHandler txtBox.DragDrop, AddressOf txtBox_DragDrop


    '    txtBox.Focus()
    '    '        Dim NewRectangle = New Rectangle(startPoint.X + Xoffset, startPoint.Y + Yoffset, theRectangle.Width, theRectangle.Height)
    '    '        Dim NewRectangle = New Rectangle(frmItem.PosX + Xoffset, frmItem.PosY + Yoffset, frmItem.Width, frmItem.Height)
    '    ' Draw the new rectangle by calling DrawReversibleFrame again.  
    '    '       ControlPaint.DrawReversibleFrame(NewRectangle, Me.BackColor, _
    '    '           FrameStyle.Thick)
    '    ' Dim g As Graphics = System.Drawing.Graphics.FromHwnd(txtBox.Handle)
    '    'Dim NewRectangle = New Rectangle(txtBox.Location.X, txtBox.Location.Y, txtBox.Width, txtBox.Height)
    '    ' ControlPaint.DrawSizeGrip(g, Color.Chartreuse, txtBox.Location.X, txtBox.Location.Y, txtBox.Width, txtBox.Height)
    '    'ControlPaint.DrawGrabHandle(g, NewRectangle, True, True)
    '    'txtBox.BorderStyle() = Windows.Forms.BorderStyle.Fixed3D

    'End Sub
    'Private Sub txtBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    '        ThreadBusy = True
    '    Dim cursorMoved As Boolean = False
    '    Dim loc As System.Drawing.Point = txtBox.Location
    '    If e.KeyCode = Keys.Escape Then
    '        OptionsPropertyGrid.Visible = False
    '        txtBox.Dispose()
    '        Itemselected = -1
    '        '            popupDGview.Visible = False
    '        Me.Refresh()
    '        Return
    '    End If
    '    If e.KeyCode = Keys.Delete Then
    '        OptionsPropertyGrid.Visible = False
    '        txtBox.Dispose()
    '        If Itemselected >= 0 Then
    '            For i As Integer = Itemselected To formVar.Count - 2
    '                Dim name As String = formVar(i).FieldName
    '                Dim itm As formItem = formVar(i + 1)
    '                itm.FieldName = name
    '                formVar(i) = itm
    '            Next
    '            formVar.RemoveAt(formVar.Count - 1)
    '            Dim properties As DevExpress.XtraEditors.Repository.RepositoryItemComboBox = cboUserVar.Properties
    '            properties.Items.Remove(frmItem.MapName)
    '        End If
    '        Itemselected = -1
    '        Me.Refresh()
    '        Return
    '    End If

    '    If e.KeyCode = Keys.Return Then
    '        OptionsPropertyGrid.Visible = False
    '        If txtBox.Text > "" Then
    '            If DuplicateFieldName(txtBox.Text) >= 0 And DuplicateFieldName(txtBox.Text) <> Itemselected Then
    '                MessageBox.Show("Duplicate Field name")
    '                Return
    '            End If
    '            frmItem.MapName = txtBox.Text
    '            UpdateFieldAttributeS()
    '            txtBox.Enabled = False
    '            Me.TabControl1.TabPages(Me.TabControl1.SelectedIndex).Controls.Add(txtBox)
    '            Me.TabControl1.Refresh()

    '            Itemselected = -1
    '            Return
    '        End If
    '    End If
    'End Sub
    'Private Sub txtBox_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
    '    If (e.Data.GetDataPresent("System.Windows.Forms.TreeNode")) Then
    '        If (e.KeyState And CtrlMask) = CtrlMask Then
    '            e.Effect = DragDropEffects.Copy
    '        Else
    '            e.Effect = DragDropEffects.Move
    '        End If
    '    Else
    '        e.Effect = DragDropEffects.None
    '    End If
    'End Sub
    'Private Sub txtBox_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
    '    Dim tn As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
    '    If Not (txtBox Is Nothing) Then
    '        If txtBox.Enabled Then
    '            txtBox.Text = tn.Text
    '            frmItem.MapName = tn.Text
    '            frmItem.linkTbl = tn.Parent.Text
    '            frmItem.MapName = txtBox.Text
    '            UpdateFieldAttributeS()
    '            txtBox.Enabled = False
    '            Me.TabControl1.TabPages(Me.TabControl1.SelectedIndex).Controls.Add(txtBox)
    '            Itemselected = -1
    '            PageRefresh()
    '        End If
    '    End If
    '    tn.Remove()
    'End Sub
    'Private Sub TreeView_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles TreeView1.ItemDrag
    '    If e.Button = Windows.Forms.MouseButtons.Left Then
    '        Dim tn As TreeNode = e.Item
    '        'invoke the drag and drop operation
    '        If tn.Level = 1 Then
    '            DoDragDrop(e.Item, DragDropEffects.Move Or DragDropEffects.Copy)
    '            '            DoDragDrop("TTTT", DragDropEffects.Move Or DragDropEffects.Copy)
    '        End If
    '    End If
    'End Sub

    'Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As _
    'System.Windows.Forms.MouseEventArgs)
    '    If cboUserVar.SelectedIndex >= 0 Then Return

    '    If (e.Button <> System.Windows.Forms.MouseButtons.Left) Or Itemselected >= 0 Then Return
    '    If Not (txtBox Is Nothing) Then
    '        If txtBox.Enabled Then
    '            txtBox.Dispose()
    '        End If
    '    End If

    '    Dim Overlap As Integer = -1
    '    For i As Integer = 0 To formVar.Count - 1
    '        Dim itm As formItem = formVar(i)
    '        If ((e.X > itm.PosX) And (e.X < itm.PosX + itm.Width) And (e.Y > itm.PosY) And (e.Y < itm.PosY + itm.Height)) Then
    '            Overlap = i
    '            Exit For
    '        End If
    '    Next
    '    startPoint = New Point(e.X, e.Y)
    '    If Overlap < 0 Then
    '        theRectangle = New Rectangle(Control.MousePosition.X, Control.MousePosition.Y, 0, 0)
    '    Else
    '        frmItem = formVar(Overlap)
    '        theRectangle = New Rectangle(Control.MousePosition.X, Control.MousePosition.Y, frmItem.Width, frmItem.Height)
    '    End If
    '    Itemselected = Overlap
    'End Sub


    'Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As _
    'System.Windows.Forms.MouseEventArgs)
    '    If cboUserVar.SelectedIndex >= 0 Then Return
    '    If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
    '    'Dim width As Integer = Control.MousePosition.X - startPoint.X
    '    'Dim height As Integer = Control.MousePosition.Y - startPoint.Y
    '    Dim width As Integer = Math.Abs(Control.MousePosition.X - theRectangle.Left)
    '    Dim height As Integer = Math.Abs(Control.MousePosition.Y - theRectangle.Top)
    '    'Xoffset = 0 : Yoffset = 0
    '    If isDrag Then
    '        If Itemselected >= 0 Then
    '            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Thick)
    '            theRectangle = New Rectangle(Control.MousePosition.X, Control.MousePosition.Y, frmItem.Width, frmItem.Height)
    '            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Thick)
    '        Else
    '            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
    '            theRectangle = New Rectangle(Control.MousePosition.X - width, Control.MousePosition.Y - height, width, height)
    '            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
    '        End If
    '    Else
    '        isDrag = True
    '    End If

    'End Sub

    'Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As _
    'System.Windows.Forms.MouseEventArgs)
    '    If cboUserVar.SelectedIndex >= 0 Then Return
    '    If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
    '    If isDrag Then
    '        ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Thick)
    '        If Itemselected >= 0 Then
    '            frmItem.PosX = e.X
    '            frmItem.PosY = e.Y
    '            UpdateFieldAttributeS()
    '            PageRefresh()
    '        Else
    '            If theRectangle.Width > 4 And theRectangle.Height > 4 Then
    '                MakeNewFormItem()
    '                DrawTextBox()
    '            End If
    '        End If
    '        theRectangle = New Rectangle(0, 0, 0, 0)
    '        ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Thick)
    '    End If
    '    isDrag = False
    '    Itemselected = -1

    '    Me.Refresh()


    'End Sub

    'Private Sub PageRefresh()
    '    'pPen.DashStyle = Drawing2D.DashStyle.DashDot
    '    Dim currentPage As Integer = Me.TabControl1.SelectedIndex
    '    Dim bmp As Bitmap = TabControl1.TabPages(currentPage).BackgroundImage
    '    Me.TabControl1.SuspendLayout()

    '    Me.TabControl1.TabPages(currentPage).Controls.Clear()
    '    For i As Integer = 0 To formVar.Count - 1
    '        Dim itm As formItem = formVar.Item(i)

    '        If itm.PgNum = currentPage Then


    '            Dim drawFont As System.Drawing.Font = New Font(itm.FontName, itm.FontSize, _
    '                IIf(itm.FontBold, FontStyle.Bold, IIf(itm.FontItalic, FontStyle.Italic, _
    '                IIf(itm.FontUnderline, FontStyle.Underline, FontStyle.Regular))), GraphicsUnit.Point)
    '            Dim mBox As TextBox = New TextBox()
    '            mBox.Font = drawFont
    '            mBox.Width = itm.Width
    '            mBox.Enabled = False
    '            mBox.Location = New Point(itm.PosX, itm.PosY)
    '            If itm.Color > "" Then 'Color
    '                mBox.BackColor = System.Drawing.Color.FromArgb(itm.Color)
    '            End If
    '            If i = Itemselected Then
    '                mBox.BorderStyle = BorderStyle.Fixed3D
    '                mBox.ForeColor = Color.Green

    '            Else
    '                mBox.BorderStyle = BorderStyle.FixedSingle
    '                mBox.ForeColor = Color.Blue
    '            End If
    '            'Dim myPen As New Pen(Brushes.Blue, 1)

    '            mBox.Text = itm.MapName
    '            Me.TabControl1.TabPages(currentPage).Controls.Add(mBox)
    '            'mBox.DrawToBitmap(bmp, New Rectangle(itm.PosX, itm.PosY, mBox.Width, mBox.Height))
    '        End If
    '    Next
    '    Me.TabControl1.ResumeLayout()
    '    TabControl1.Refresh()

    'End Sub
    'Private Sub cboUserVar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboUserVar.KeyDown
    '    cboUserVar.Focus()
    '    OptionsPropertyGrid.Visible = False
    '    cboUserVar.CancelPopup()
    '    Itemselected = -1
    '    cboUserVar.SelectedIndex = -1

    'End Sub

    'Private Sub cboUserVar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUserVar.SelectedIndexChanged
    '    If cboUserVar.SelectedIndex >= 0 Then
    '        Button1.Visible = True
    '        Itemselected = cboUserVar.SelectedIndex
    '        frmItem = formVar(Itemselected)
    '        startPoint = New Point(frmItem.PosX, frmItem.PosY)
    '        Dim RWidth = frmItem.Width : Dim RHeight = frmItem.Height
    '        'theRectangle = New Rectangle(startPoint.X + Xoffset, startPoint.Y + Yoffset, RWidth, RHeight)
    '        'DrawTextBox()
    '        ShowPropertyTable(cboUserVar.SelectedIndex)
    '    Else
    '        cboUserVar.Text = ""
    '        Button1.Visible = False

    '    End If
    '    '        Me.Refresh()
    '    '        Me.Invalidate()

    'End Sub
    'Public Sub New(ByVal ID As Integer)

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()
    '    FormID = ID

    'End Sub

    'Public Sub InitializeMenuTreeView()
    '    Dim tblNames As New Dictionary(Of String, String)

    '    ' Create the root node.
    '    tblNames.Add("engineering_data", "Remarks,Prefix,Description," + _
    '            "Service,Manufacturer,ModelNumber,SerialNumber,PONumber,LineNumber")
    '    tblNames.Add("equipment_type", "TypeName,TypeDesc,Active")
    '    tblNames.Add("package", "PackageNumber,Description")
    '    tblNames.Add("punchlist", "Description,Priority,ListedBy,ListedOn,ClosedBy," + _
    '            " ClosedOn,Status,Type,ManHours,CompletedBy,CompletedOn,CompletedCommentS," + _
    '            "ApprovedBy,ApprovedOn,Location,MaterialRequired,Material,ResponsibleParty," + _
    '            "ResponsibleDiscipline,EstimatedDate,RequiredDate")
    '    tblNames.Add("tags", "TagNumber")
    '    Dim keys As Dictionary(Of String, String).KeyCollection = tblNames.Keys

    '    TreeView1.BeginUpdate()

    '    ' Clear the TreeView each time the method is called.
    '    TreeView1.Nodes.Clear()
    '    For Each s As String In keys
    '        Dim myItem = TreeView1.Nodes.Add(New TreeNode(s))
    '        Dim myStr() = Split(tblNames(s), ",")
    '        Dim i As Integer
    '        For i = 0 To (UBound(myStr) - 1)
    '            Dim ms As String = myStr(i)
    '            TreeView1.Nodes(myItem).Nodes.Add(New TreeNode(ms))
    '        Next
    '    Next s
    '    TreeView1.EndUpdate()
    '    TreeView1.BringToFront()

    'End Sub

    'Private Sub InitializeImageList()
    '    Dim i As Integer = 0
    '    sqlPrjUtils.OpenConnection()

    '    TabControl1.Location = New Point(0, 0)
    '    Dim qry = "SELECT FormImage FROM forms_image WHERE FormID =" + FormID.ToString + " ORDER By PageNumber;"

    '    Try
    '        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '        For j As Integer = 0 To dt.Rows.Count - 1

    '            Dim buffer() As Byte = dt.Rows(j)("FormaImage")
    '            Dim Page As String = "Page_" + i.ToString
    '            Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))
    '            TabControl1.Size = New Size(Image.Width, Image.Height)
    '            TabControl1.TabPages(i).Name = (Page)
    '            TabControl1.TabPages(i).Text = (Page)
    '            TabControl1.TabPages(i).BackgroundImage = Image
    '            AddHandler TabControl1.TabPages(i).MouseUp, AddressOf Form1_MouseUp
    '            AddHandler TabControl1.TabPages(i).MouseDown, AddressOf Form1_MouseDown
    '            AddHandler TabControl1.TabPages(i).MouseMove, AddressOf Form1_MouseMove
    '            'AddHandler TabControl1.TabPages(i).Paint, AddressOf RePaint
    '            'AddHandler TabControl1.TabPages(i).Click, AddressOf Form1_Click
    '            TabControl1.TabPages.Add(Page)
    '            i = i + 1
    '        Next
    '        TabControl1.TabPages.RemoveAt(i)

    '    Catch ex As Exception
    '        '    MessageBox.Show(ex.Message)
    '    End Try
    '    TabControl1.SelectedIndex = 0
    '    PageCount = i
    '    CurrentPage = TabControl1.SelectedIndex + 1
    '    ToolStripPageSelected.Text = "Page " + CurrentPage.ToString + " of " + PageCount.ToString
    '    If PageCount = 1 Then
    '        Me.TsBtn_Next.Enabled = False
    '        Me.TsBtn_Previous.Enabled = False
    '        Me.TsBtn_Last.Enabled = False
    '    End If
    '    '' Add any initialization after the InitializeComponent() call.
    '    sqlPrjUtils.CloseConnection()
    'End Sub
    'Private Sub InitializeCboDropdownList()
    '    Dim properties As DevExpress.XtraEditors.Repository.RepositoryItemComboBox = cboUserVar.Properties
    '    properties.Items.Clear()
    '    For Each itm As formItem In formVar
    '        properties.Items.Add(itm.MapName)
    '    Next
    'End Sub
    'Private Sub InitializeFormVar()
    '    'Dim connStr = "Data Source=d:\daq\Project.sdf;Max Database Size=128;Default Lock Escalation =100;"
    '    Dim sqlPrjUtils As DataUtils = New DataUtils("project")
    '    sqlPrjUtils.OpenConnection()

    '    Dim qry = "SELECT AuxData FROM aux_forms_info WHERE FormID = " + FormID.ToString
    '    Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '    Try
    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            Dim myVars() As String = Split(dt.Rows(i)("AuxData"), "&001")
    '            Dim itm As formItem = New formItem
    '            itm.FieldName = myVars(0)
    '            itm.MapName = myVars(1)
    '            itm.linkTbl = myVars(2)
    '            itm.Value = myVars(3)
    '            Try
    '                itm.WtPcnt = CSng(myVars(4))
    '            Catch ex As Exception
    '                itm.WtPcnt = 0
    '            End Try
    '            itm.Color = myVars(5)
    '            Try
    '                itm.DataType = CInt(myVars(6))
    '            Catch ex As Exception
    '                itm.DataType = VarAttributes.dtype.Text
    '            End Try
    '            itm.PgNum = CInt(myVars(7))
    '            itm.View = myVars(8)
    '            itm.Position = CInt(myVars(9))
    '            itm.PosX = CInt(myVars(10))
    '            itm.PosY = CInt(myVars(11))
    '            itm.Width = CInt(myVars(12))
    '            itm.Height = CInt(myVars(13))
    '            itm.TabPosition = CInt(myVars(14))
    '            itm.FontName = myVars(15)
    '            itm.FontSize = CSng(myVars(16))
    '            itm.FontBold = CBool(myVars(17))
    '            itm.FontItalic = CBool(myVars(18))
    '            itm.FontUnderline = CBool(myVars(19))
    '            formVar.Add(itm)
    '        Next

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    'Private Sub InitializePropertyView()
    '    Me.TsAttributeSelection.SelectedIndex = 1
    '    Me.TsApplyWtPcnt.SelectedIndex = 1
    '    VarNameTable = New DataTable("Variables")
    '    Dim idColumn As DataColumn = VarNameTable.Columns.Add("ID", GetType(Integer))
    '    VarNameTable.Columns.Add("Attributes", GetType(String))
    '    ' Set the ID column as the primary key column.
    '    VarNameTable.PrimaryKey = New DataColumn() {idColumn}

    '    AttributeTable = New DataTable("AttributeData")
    '    ' Create three columns, ID, attribute, value.
    '    idColumn = AttributeTable.Columns.Add("ID", GetType(Integer))
    '    AttributeTable.Columns.Add("VarID", GetType(Integer))
    '    AttributeTable.Columns.Add("Attributes", GetType(String))
    '    AttributeTable.Columns.Add("Values", GetType(String))
    '    ' Set the ID column as the primary key column.
    '    AttributeTable.PrimaryKey = New DataColumn() {idColumn}

    '    VarAttributeDS = New DataSet
    '    VarAttributeDS.Tables.Add(VarNameTable)
    '    VarAttributeDS.Tables.Add(AttributeTable)
    '    OptionsPropertyGrid = New PropertyGrid()
    '    OptionsPropertyGrid.Dock = DockStyle.None

    '    Me.SplitContainer1.Panel1.Controls.Add(OptionsPropertyGrid)

    '    ' Add any initialization after the InitializeComponent() call.
    '    ' Create the VarAttributes class and display it in the PropertyGrid.
    '    OptionsPropertyGrid.SelectedObject = AttributeSet
    '    OptionsPropertyGrid.Visible = False

    '    Label2.Location = New Point(0, 40)
    '    TreeView1.Location = New Point(Label2.Location.X, Label2.Location.Y + Label2.Height)
    '    TreeView1.Width = SplitContainer1.Panel1.Width
    '    Button1.Visible = False
    '    Button1.Location = New Point(Me.SplitContainer1.Panel1.Width + Me.SplitContainer1.Panel1.Left - 40, Me.TreeView1.Location.Y + Me.TreeView1.Height)
    '    Label1.Location = New Point(Me.TreeView1.Location.X, Me.Button1.Location.Y + 20)
    '    cboUserVar.Width = Me.SplitContainer1.Panel1.Width
    '    cboUserVar.Location = New Point(Me.Label1.Location.X, Me.Label1.Location.Y + Me.Label1.Height)
    '    lblSampleFont.Location = New Point(Me.cboUserVar.Location.X, Me.cboUserVar.Location.Y + 40)
    '    OptionsPropertyGrid.Location = New Point(Me.cboUserVar.Location.X, Me.cboUserVar.Location.Y + 20)
    '    OptionsPropertyGrid.ToolbarVisible = False
    '    OptionsPropertyGrid.Size = New Size(Me.SplitContainer1.Panel1.Width, 250)
    '    AddHandler OptionsPropertyGrid.PropertyValueChanged, AddressOf OptionsPropertyGrid_PropertyValueChanged
    '    '        OptionsPropertyGrid.BringToFront()


    'End Sub


    'Private Sub SetSystemDefault()
    '    DefaultItemValues.Value = mnuDefaultValue.Text
    '    Try
    '        DefaultItemValues.WtPcnt = CSng(Me.mnuWeight.Text)
    '    Catch ex As Exception
    '        DefaultItemValues.WtPcnt = 0
    '    End Try
    '    '        Dim SystemFont As Font = New Font("Arial", 8, FontStyle.Regular)
    '    Dim myBox As TextBox = New System.Windows.Forms.TextBox()

    '    DefaultItemValues.Color = myBox.BackColor.ToArgb
    '    DefaultItemValues.DataType = 0
    '    DefaultItemValues.FontName = myBox.Font.FontFamily.Name
    '    DefaultItemValues.FontSize = myBox.Font.Size
    '    DefaultItemValues.FontUnderline = FontStyle.Regular
    '    myBox.Dispose()
    '    Me.mnuWeight.Text = DefaultItemValues.WtPcnt.ToString
    '    Me.mnuTxtColor.BackColor = System.Drawing.Color.FromArgb(DefaultItemValues.Color)
    '    Me.mnuDataType.SelectedIndex = DefaultItemValues.DataType
    '    Me.mnuFontFamily.Text = DefaultItemValues.FontName
    '    Me.mnuFontSize.Text = DefaultItemValues.FontSize

    '    'frmItem.Selected = False
    'End Sub
    'Private Sub UpdateFieldAttributeS()
    '    'frmItem.Selected = False
    '    Dim ttlWeight As Single = 0

    '    For Each itm As formItem In formVar
    '        Try
    '            ttlWeight = ttlWeight + CSng(itm.WtPcnt)
    '        Catch ex As Exception
    '        End Try
    '    Next
    '    If ttlWeight + frmItem.WtPcnt > 100 Then
    '        MessageBox.Show("Weight percentage " + frmItem.WtPcnt.ToString + " exceeds limit, current allocation: " + ttlWeight.ToString)
    '        frmItem.WtPcnt = 0
    '    End If

    '    If Itemselected < 0 Then
    '        formVar.Add(frmItem)
    '        Dim properties As DevExpress.XtraEditors.Repository.RepositoryItemComboBox = cboUserVar.Properties
    '        properties.Items.Add(frmItem.MapName)
    '    Else
    '        formVar(Itemselected) = frmItem
    '    End If
    '    FormModified = True
    '    SetSystemDefault()

    'End Sub
    'Private Function DuplicateFieldName(ByVal name As String) As Integer
    '    For i As Integer = 0 To formVar.Count - 1
    '        If formVar.Item(i).MapName = name Then Return i
    '    Next
    '    Return -1
    'End Function
    'Private Sub FormDesignerMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Try
    '        sqlPrjUtils.OpenConnection()

    '        Dim qry = "SELECT Name FROM forms WHERE ID =" + FormID.ToString
    '        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '        Me.FormName = dt.Rows(0)("Name")
    '        Me.Text = Me.FormName
    '        Me.TreeView1.Height = 300
    '        '        Xoffset = Me.SplitContainer1.Panel2.Location.X + Me.TabControl1.Location.X 
    '        '       Yoffset = Me.SplitContainer1.Panel2.Location.Y + Me.TabControl1.Location.Y
    '        Xoffset = 0
    '        Yoffset = 0
    '        '      Xoffset = Me.SplitContainer1.Panel2.Location.X
    '        '     Yoffset = Me.SplitContainer1.Panel2.Location.Y
    '        'Xoffset = Me.SplitContainer1.Panel2.Location.X + Me.TabControl1.Location.X
    '        'Yoffset = Me.SplitContainer1.Panel2.Location.Y + Me.TabControl1.Location.Y

    '        InitializeImageList()
    '        InitializeFormVar()
    '        InitializeMenuTreeView()
    '        InitializePropertyView()
    '        InitializeCboDropdownList()

    '        '
    '        '       Xoffset = Me.PointToClient(New Point(0, 0)).X
    '        Xoffset = Xoffset + Me.SplitContainer1.Panel2.PointToScreen(New Point(0, 0)).X
    '        '        Xoffset = Xoffset - 4

    '        '     Yoffset = Me.PointToClient(New Point(0, 0)).Y
    '        Yoffset = Yoffset + Me.SplitContainer1.Panel2.PointToScreen(New Point(0, 0)).Y + Me.ToolStrip1.Height
    '        '       Yoffset = Yoffset + 3
    '        Itemselected = -1
    '        mnuFontFamily.Text = Label1.Font.FontFamily.ToString
    '        mnuFontSize.Text = Label1.Font.Size.ToString
    '        mnuDataType.SelectedIndex = 0

    '        SetSystemDefault()
    '        '        mnuTest.MenuItems.Add(mnuTestItem1)
    '        '       mnuTest.MenuItems.Add(mnuTestItem2)

    '        PageRefresh()
    '    Catch ex As Exception
    '        Utilities.logErrorMessage("FormDesigner.FormDesignerMain_Load-" + ex.Message)
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If cboUserVar.SelectedIndex >= 0 Then
    '        If MessageBox.Show("Do you wish to delete this variable", "Delete Varibale", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
    '            For i As Integer = 0 To formVar.Count - 1
    '                Dim itm As formItem = formVar(i)
    '                If (i = cboUserVar.SelectedIndex) Then
    '                    formVar.Remove(itm)
    '                    Exit For
    '                End If
    '            Next

    '            OptionsPropertyGrid.Visible = False
    '            cboUserVar.CancelPopup()
    '            cboUserVar.SelectedIndex = -1
    '            InitializeCboDropdownList()
    '            PageRefresh()
    '            cboUserVar.Focus()
    '            Button1.Visible = False
    '        End If
    '    End If

    'End Sub

    'Private Sub mnuFonts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFonts.Click
    '    FontDialog1.ShowColor = True

    '    '        FontDialog1.Font = New Font(frmItem.FontName, frmItem.FontSize, FontStyle.Bold, GraphicsUnit.Pixel, True)
    '    '       FontDialog1.Color = Label1.ForeColor

    '    If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
    '        lblSampleFont.Font = FontDialog1.Font
    '        lblSampleFont.ForeColor = FontDialog1.Color
    '        'Label1.Font = FontDialog1.Font)
    '        'Label1.ForeColor = FontDialog1.Color
    '        mnuFontFamily.Text = lblSampleFont.Font.FontFamily.ToString
    '        mnuFontSize.Text = lblSampleFont.Font.Size.ToString
    '        '            mnuTxtColor.BackColor = lblSampleFont.ForeColor
    '    End If

    'End Sub

    'Private Sub TsBtn_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtn_Color.Click
    '    If ColorDialog1.ShowDialog() <> System.Windows.Forms.DialogResult.Cancel Then
    '        mnuTxtColor.BackColor = ColorDialog1.Color
    '    End If
    'End Sub
    'Private Sub SaveFormAttributes()
    '    Dim qry = "DELETE FROM aux_forms_info WHERE FormMUID = @MUID"
    '    Dim dt_param As DataTable = sqlPrjUtils.paramDT
    '    dt_param.Rows.Add("@MUID", FormID.ToString)
    '    sqlPrjUtils.ExecuteNonQuery(qry, dt_param)


    '    Try
    '        For Each itm As formItem In formVar
    '            Dim muid = idUtils.GetNextMUID("project", "aux_forms_info")
    '            qry = "INSERT INTO aux_forms_info " + _
    '                         "(MUID, TS,FormID,AuxData ) VALUES (" + _
    '                         "@MUID," + _
    '                         "@TS," + _
    '                         "@FormID," + _
    '                         "@AuxData"

    '            dt_param = sqlPrjUtils.paramDT
    '            dt_param.Rows.Add("@MUID", muid)
    '            dt_param.Rows.Add("@TS", Now().ToString)
    '            dt_param.Rows.Add("@FormID", FormID)
    '            dt_param.Rows.Add("@AuxData", MakeFieldString(itm))

    '            sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
    '        Next
    '        FormModified = False
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub


    'Private Sub SaveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem1.Click
    '    SaveFormAttributes()
    '    '        Utilities.SubscribeProjectDB(runtime.selectedProject)
    '    Utilities.SyncProjectDB(runtime.selectedProject)
    'End Sub


    'Private Sub FormExit()
    '    FormEditManager.FormClosed(Me.Text)
    '    Me.Dispose()
    'End Sub


    'Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
    '    If FormModified Then
    '        If MessageBox.Show("The form has been modified; do you wish to exit?", "Exit Form Design", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
    '            FormExit()
    '        End If
    '    Else
    '        FormExit()
    '    End If
    'End Sub


    'Private Sub SaveExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveExitToolStripMenuItem.Click
    '    SaveFormAttributes()
    '    FormExit()
    'End Sub


    'Private Sub ExportBaseDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportBaseDocumentToolStripMenuItem.Click
    '    Dim qry = "SELECT baseImage FROM forms_storage WHERE FormID = " + FormID.ToString
    '    Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '    If dt.Rows.Count = 0 Then
    '        MessageBox.Show("No base Image available ")
    '        Return
    '    End If
    '    Dim chunk As Byte() = dt.Rows(0)("BaseImage")
    '    Dim fname As String = runtime.AbsolutePath + "sites\Forms\" + FormName.ToString
    '    File.WriteAllBytes(fname, chunk)

    '    Dim fs As New FileStream(fname, FileMode.Create, FileAccess.Write)
    '    Dim fw As New BinaryWriter(fs)
    '    fw.Write(chunk)
    '    fw.Close()
    '    fs.Close()
    '    Utilities.ExportToWord(fname)
    'End Sub

    'Private Sub mnuWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWeight.TextChanged
    '    If mnuWeight.Text > "" Then
    '        If Me.TsApplyWtPcnt.SelectedIndex = 0 Then
    '            Return
    '        End If
    '        Dim val As Single = 0
    '        Try
    '            val = CSng(mnuWeight.Text)
    '            If val < 0 And val > 100 Then
    '                Throw New Exception()
    '            End If
    '        Catch ex As Exception
    '            MessageBox.Show("Weight percentage must be betweeen 1 and 100")
    '        Finally
    '            Dim ttlWeight As Single = 0
    '            For Each itm As formItem In formVar
    '                Try
    '                    ttlWeight = ttlWeight + CSng(itm.WtPcnt)
    '                Catch ex As Exception

    '                End Try
    '            Next
    '        End Try
    '        frmItem.WtPcnt = val
    '    End If
    'End Sub

    'Private Sub OptionsPropertyGrid_PropertyValueChanged(ByVal s As System.Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs)
    '    '   If DuplicateFieldName(AttributeSet.MapName) >= 0 And DuplicateFieldName(txtBox.Text) <> Itemselected Then
    '    If AttributeSet.linkTbl > "" Then
    '        If (AttributeSet.MapName <> formVar(Itemselected).MapName) Then
    '            MessageBox.Show("System Variable names can not be changed")
    '            Return
    '        End If

    '    End If

    '    AttributeSet.SettingsChanged = True

    '    '        Dim customColor As Color = System.Drawing.Color.FromArgb(myItm.Color)

    '    For i As Integer = 0 To formVar.Count - 1
    '        If i <> Itemselected Then
    '            If formVar.Item(i).MapName = AttributeSet.MapName Then
    '                MessageBox.Show("Duplicate Field name")
    '                Return
    '            End If
    '        End If
    '    Next

    '    frmItem = formVar(Itemselected)

    '    frmItem.Color = AttributeSet.BackgroundColor.ToArgb.ToString
    '    frmItem.PosX = AttributeSet.XYCoordinates.X
    '    frmItem.PosY = AttributeSet.XYCoordinates.Y
    '    frmItem.FontName = AttributeSet.WindowFont.Name
    '    frmItem.FontSize = AttributeSet.WindowFont.Size
    '    frmItem.MapName = AttributeSet.MapName
    '    frmItem.Value = AttributeSet.DefaultValue
    '    frmItem.WtPcnt = AttributeSet.WtPcnt
    '    frmItem.DataType = AttributeSet.DataType
    '    frmItem.TabPosition = AttributeSet.TabPosition
    '    frmItem.Width = AttributeSet.Width

    '    UpdateFieldAttributeS()
    '    InitializeCboDropdownList()


    'End Sub

    'Private Sub TsBtn_First_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtn_First.Click
    '    TabControl1.SelectedIndex = 0
    '    CurrentPage = TabControl1.SelectedIndex + 1
    '    ToolStripPageSelected.Text = "Page " + CurrentPage.ToString + " of " + PageCount.ToString
    'End Sub
    'Private Sub TsBtn_Previous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtn_Previous.Click
    '    If TabControl1.SelectedIndex > 0 Then
    '        TabControl1.SelectedIndex = TabControl1.SelectedIndex - 1
    '        CurrentPage = TabControl1.SelectedIndex + 1
    '        ToolStripPageSelected.Text = "Page " + CurrentPage.ToString + " of " + PageCount.ToString
    '    End If
    'End Sub
    'Private Sub TsBtn_Last_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtn_Last.Click
    '    TabControl1.SelectedIndex = TabControl1.TabCount - 1
    '    CurrentPage = TabControl1.SelectedIndex + 1
    '    ToolStripPageSelected.Text = "Page " + CurrentPage.ToString + " of " + PageCount.ToString
    'End Sub
    'Private Sub TsBtn_Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtn_Next.Click
    '    If TabControl1.SelectedIndex < TabControl1.TabCount - 1 Then
    '        TabControl1.SelectedIndex = TabControl1.SelectedIndex + 1
    '        CurrentPage = TabControl1.SelectedIndex + 1
    '        ToolStripPageSelected.Text = "Page " + CurrentPage.ToString + " of " + PageCount.ToString
    '    End If
    'End Sub
    'Private Sub FormDesignerMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    sqlPrjUtils.CloseConnection()
    '    If FormModified Then
    '        If MessageBox.Show("The form has been modified; do you wish to save?", "Exit Form Design", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
    '            SaveFormAttributes()
    '        End If
    '    End If
    '    FormEditManager.FormClosed(Me.Text)
    'End Sub
End Class
