<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tlb_EditDaqument
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tlb_EditDaqument))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnPageSetup = New System.Windows.Forms.ToolStripMenuItem
        Me.btnPrintPreview = New System.Windows.Forms.ToolStripMenuItem
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.btnInsertText = New System.Windows.Forms.ToolStripButton
        Me.btnInsertImage = New System.Windows.Forms.ToolStripButton
        Me.btnFreehand = New System.Windows.Forms.ToolStripButton
        Me.btnLineDraw = New System.Windows.Forms.ToolStripButton
        Me.btnDrag = New System.Windows.Forms.ToolStripButton
        Me.btnEnlarge = New System.Windows.Forms.ToolStripButton
        Me.btnReduce = New System.Windows.Forms.ToolStripButton
        Me.btnColorChoice = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnColorRed = New System.Windows.Forms.ToolStripMenuItem
        Me.btnColorBlue = New System.Windows.Forms.ToolStripMenuItem
        Me.btnColorGreen = New System.Windows.Forms.ToolStripMenuItem
        Me.btnColorYellow = New System.Windows.Forms.ToolStripMenuItem
        Me.btnMarking = New System.Windows.Forms.ToolStripMenuItem
        Me.btnHiliting = New System.Windows.Forms.ToolStripMenuItem
        Me.btnLineWidth = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnWidth1 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnWidth2 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnWidth3 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnWidth4 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnWidth5 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnUndo = New System.Windows.Forms.ToolStripButton
        Me.btnRedo = New System.Windows.Forms.ToolStripButton
        Me.btnMaginfy = New System.Windows.Forms.ToolStripDropDownButton
        Me.btn500 = New System.Windows.Forms.ToolStripMenuItem
        Me.btn200 = New System.Windows.Forms.ToolStripMenuItem
        Me.btn150 = New System.Windows.Forms.ToolStripMenuItem
        Me.btn100 = New System.Windows.Forms.ToolStripMenuItem
        Me.btn75 = New System.Windows.Forms.ToolStripMenuItem
        Me.btn50 = New System.Windows.Forms.ToolStripMenuItem
        Me.btn25 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnPageWidth = New System.Windows.Forms.ToolStripMenuItem
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnCreateNewLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.btnSaveAsNewLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PageSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnFormat = New System.Windows.Forms.ToolStripMenuItem
        Me.btnFontSelect = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItemVisibleObjects = New System.Windows.Forms.ToolStripMenuItem
        Me.btnHilitingVisibleLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.btnMarkingVisibleLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.btnViewLayers = New System.Windows.Forms.ToolStripMenuItem
        Me.TestingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.picBoxDragHandle = New System.Windows.Forms.PictureBox
        Me.PicBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cms1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsPictureBox = New System.Windows.Forms.PictureBox
        Me.pbx_Overlay = New System.Windows.Forms.PictureBox
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picBoxDragHandle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmsPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Overlay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripDropDownButton2, Me.btnCancel, Me.btnInsertText, Me.btnInsertImage, Me.btnFreehand, Me.btnLineDraw, Me.btnDrag, Me.btnEnlarge, Me.btnReduce, Me.btnColorChoice, Me.btnLineWidth, Me.btnUndo, Me.btnRedo, Me.btnMaginfy})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(768, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = Global.Daqument.My.Resources.Resources.Floppy
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(23, 22)
        Me.btnSave.Text = "Save Documents"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPageSetup, Me.btnPrintPreview})
        Me.ToolStripDropDownButton2.Image = Global.Daqument.My.Resources.Resources.Printer
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton2.Text = "ToolStripDropDownButton2"
        '
        'btnPageSetup
        '
        Me.btnPageSetup.Name = "btnPageSetup"
        Me.btnPageSetup.Size = New System.Drawing.Size(148, 22)
        Me.btnPageSetup.Text = "Page Setup"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(148, 22)
        Me.btnPrintPreview.Text = "Print Preview"
        '
        'btnCancel
        '
        Me.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancel.Image = Global.Daqument.My.Resources.Resources.Cancel
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(23, 22)
        Me.btnCancel.Text = "ToolStripButton3"
        '
        'btnInsertText
        '
        Me.btnInsertText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnInsertText.Image = Global.Daqument.My.Resources.Resources.Text_Document
        Me.btnInsertText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInsertText.Name = "btnInsertText"
        Me.btnInsertText.Size = New System.Drawing.Size(23, 22)
        Me.btnInsertText.Text = "Insert Text"
        '
        'btnInsertImage
        '
        Me.btnInsertImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnInsertImage.Image = Global.Daqument.My.Resources.Resources.Image
        Me.btnInsertImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInsertImage.Name = "btnInsertImage"
        Me.btnInsertImage.Size = New System.Drawing.Size(23, 22)
        Me.btnInsertImage.Text = "Insert Image"
        '
        'btnFreehand
        '
        Me.btnFreehand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFreehand.Image = Global.Daqument.My.Resources.Resources.Symbol_Edit
        Me.btnFreehand.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFreehand.Name = "btnFreehand"
        Me.btnFreehand.Size = New System.Drawing.Size(23, 22)
        Me.btnFreehand.Text = "Freehand Draw"
        '
        'btnLineDraw
        '
        Me.btnLineDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLineDraw.Image = Global.Daqument.My.Resources.Resources.highlite
        Me.btnLineDraw.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLineDraw.Name = "btnLineDraw"
        Me.btnLineDraw.Size = New System.Drawing.Size(23, 22)
        Me.btnLineDraw.Text = "Line Draw"
        '
        'btnDrag
        '
        Me.btnDrag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDrag.Image = Global.Daqument.My.Resources.Resources.move
        Me.btnDrag.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDrag.Name = "btnDrag"
        Me.btnDrag.Size = New System.Drawing.Size(23, 22)
        Me.btnDrag.Text = "Drag"
        '
        'btnEnlarge
        '
        Me.btnEnlarge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEnlarge.Image = Global.Daqument.My.Resources.Resources.plus
        Me.btnEnlarge.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEnlarge.Name = "btnEnlarge"
        Me.btnEnlarge.Size = New System.Drawing.Size(23, 22)
        Me.btnEnlarge.Text = "ToolStripButton3"
        '
        'btnReduce
        '
        Me.btnReduce.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnReduce.Image = Global.Daqument.My.Resources.Resources.minus
        Me.btnReduce.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReduce.Name = "btnReduce"
        Me.btnReduce.Size = New System.Drawing.Size(23, 22)
        Me.btnReduce.Text = "ToolStripButton4"
        '
        'btnColorChoice
        '
        Me.btnColorChoice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnColorChoice.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnColorRed, Me.btnColorBlue, Me.btnColorGreen, Me.btnColorYellow, Me.btnMarking, Me.btnHiliting})
        Me.btnColorChoice.Image = CType(resources.GetObject("btnColorChoice.Image"), System.Drawing.Image)
        Me.btnColorChoice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnColorChoice.Name = "btnColorChoice"
        Me.btnColorChoice.Size = New System.Drawing.Size(80, 22)
        Me.btnColorChoice.Text = "Color Choice"
        '
        'btnColorRed
        '
        Me.btnColorRed.BackColor = System.Drawing.Color.Red
        Me.btnColorRed.Name = "btnColorRed"
        Me.btnColorRed.Size = New System.Drawing.Size(122, 22)
        Me.btnColorRed.Text = "Red"
        '
        'btnColorBlue
        '
        Me.btnColorBlue.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnColorBlue.Name = "btnColorBlue"
        Me.btnColorBlue.Size = New System.Drawing.Size(122, 22)
        Me.btnColorBlue.Text = "Blue"
        '
        'btnColorGreen
        '
        Me.btnColorGreen.BackColor = System.Drawing.Color.Lime
        Me.btnColorGreen.Name = "btnColorGreen"
        Me.btnColorGreen.Size = New System.Drawing.Size(122, 22)
        Me.btnColorGreen.Text = "Green"
        '
        'btnColorYellow
        '
        Me.btnColorYellow.BackColor = System.Drawing.Color.Yellow
        Me.btnColorYellow.Name = "btnColorYellow"
        Me.btnColorYellow.Size = New System.Drawing.Size(122, 22)
        Me.btnColorYellow.Text = "Yellow"
        '
        'btnMarking
        '
        Me.btnMarking.Name = "btnMarking"
        Me.btnMarking.Size = New System.Drawing.Size(122, 22)
        Me.btnMarking.Text = "Marking"
        '
        'btnHiliting
        '
        Me.btnHiliting.Name = "btnHiliting"
        Me.btnHiliting.Size = New System.Drawing.Size(122, 22)
        Me.btnHiliting.Text = "Hilite"
        '
        'btnLineWidth
        '
        Me.btnLineWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLineWidth.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnWidth1, Me.btnWidth2, Me.btnWidth3, Me.btnWidth4, Me.btnWidth5})
        Me.btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width1
        Me.btnLineWidth.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLineWidth.Name = "btnLineWidth"
        Me.btnLineWidth.Size = New System.Drawing.Size(29, 22)
        Me.btnLineWidth.Text = "Line Width"
        '
        'btnWidth1
        '
        Me.btnWidth1.Name = "btnWidth1"
        Me.btnWidth1.Size = New System.Drawing.Size(119, 22)
        Me.btnWidth1.Text = "Width1"
        '
        'btnWidth2
        '
        Me.btnWidth2.Name = "btnWidth2"
        Me.btnWidth2.Size = New System.Drawing.Size(119, 22)
        Me.btnWidth2.Text = "Width2"
        '
        'btnWidth3
        '
        Me.btnWidth3.Name = "btnWidth3"
        Me.btnWidth3.Size = New System.Drawing.Size(119, 22)
        Me.btnWidth3.Text = "Width3"
        '
        'btnWidth4
        '
        Me.btnWidth4.Name = "btnWidth4"
        Me.btnWidth4.Size = New System.Drawing.Size(119, 22)
        Me.btnWidth4.Text = "Width4"
        '
        'btnWidth5
        '
        Me.btnWidth5.Name = "btnWidth5"
        Me.btnWidth5.Size = New System.Drawing.Size(119, 22)
        Me.btnWidth5.Text = "Width5"
        '
        'btnUndo
        '
        Me.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUndo.Image = Global.Daqument.My.Resources.Resources.Undo
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(23, 22)
        Me.btnUndo.Text = "Undo"
        '
        'btnRedo
        '
        Me.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRedo.Image = Global.Daqument.My.Resources.Resources.Redo
        Me.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRedo.Name = "btnRedo"
        Me.btnRedo.Size = New System.Drawing.Size(23, 22)
        Me.btnRedo.Text = "Redo"
        '
        'btnMaginfy
        '
        Me.btnMaginfy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnMaginfy.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn500, Me.btn200, Me.btn150, Me.btn100, Me.btn75, Me.btn50, Me.btn25, Me.btnPageWidth})
        Me.btnMaginfy.Image = CType(resources.GetObject("btnMaginfy.Image"), System.Drawing.Image)
        Me.btnMaginfy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMaginfy.Name = "btnMaginfy"
        Me.btnMaginfy.Size = New System.Drawing.Size(49, 22)
        Me.btnMaginfy.Text = "100%"
        '
        'btn500
        '
        Me.btn500.Name = "btn500"
        Me.btn500.Size = New System.Drawing.Size(140, 22)
        Me.btn500.Text = "500%"
        '
        'btn200
        '
        Me.btn200.Name = "btn200"
        Me.btn200.Size = New System.Drawing.Size(140, 22)
        Me.btn200.Text = "200%"
        '
        'btn150
        '
        Me.btn150.Name = "btn150"
        Me.btn150.Size = New System.Drawing.Size(140, 22)
        Me.btn150.Text = "150%"
        '
        'btn100
        '
        Me.btn100.Name = "btn100"
        Me.btn100.Size = New System.Drawing.Size(140, 22)
        Me.btn100.Text = "100%"
        '
        'btn75
        '
        Me.btn75.Name = "btn75"
        Me.btn75.Size = New System.Drawing.Size(140, 22)
        Me.btn75.Text = "75%"
        '
        'btn50
        '
        Me.btn50.Name = "btn50"
        Me.btn50.Size = New System.Drawing.Size(140, 22)
        Me.btn50.Text = "50%"
        '
        'btn25
        '
        Me.btn25.Name = "btn25"
        Me.btn25.Size = New System.Drawing.Size(140, 22)
        Me.btn25.Text = "25%"
        '
        'btnPageWidth
        '
        Me.btnPageWidth.Name = "btnPageWidth"
        Me.btnPageWidth.Size = New System.Drawing.Size(140, 22)
        Me.btnPageWidth.Text = "Page Width"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 509)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(768, 22)
        Me.StatusStrip1.TabIndex = 21
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.btnFormat, Me.MenuItemVisibleObjects, Me.btnViewLayers})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(768, 24)
        Me.MenuStrip1.TabIndex = 22
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCreateNewLayer, Me.btnSaveAsNewLayer, Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem, Me.PageSetupToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'btnCreateNewLayer
        '
        Me.btnCreateNewLayer.Name = "btnCreateNewLayer"
        Me.btnCreateNewLayer.Size = New System.Drawing.Size(173, 22)
        Me.btnCreateNewLayer.Text = "Add new layer"
        '
        'btnSaveAsNewLayer
        '
        Me.btnSaveAsNewLayer.Name = "btnSaveAsNewLayer"
        Me.btnSaveAsNewLayer.Size = New System.Drawing.Size(173, 22)
        Me.btnSaveAsNewLayer.Text = "Save as new layer"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'PageSetupToolStripMenuItem
        '
        Me.PageSetupToolStripMenuItem.Name = "PageSetupToolStripMenuItem"
        Me.PageSetupToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.PageSetupToolStripMenuItem.Text = "Page setup"
        '
        'btnFormat
        '
        Me.btnFormat.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFontSelect})
        Me.btnFormat.Name = "btnFormat"
        Me.btnFormat.Size = New System.Drawing.Size(53, 20)
        Me.btnFormat.Text = "Format"
        '
        'btnFontSelect
        '
        Me.btnFontSelect.Image = Global.Daqument.My.Resources.Resources.Fonts
        Me.btnFontSelect.Name = "btnFontSelect"
        Me.btnFontSelect.Size = New System.Drawing.Size(112, 22)
        Me.btnFontSelect.Text = "Fonts"
        '
        'MenuItemVisibleObjects
        '
        Me.MenuItemVisibleObjects.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnHilitingVisibleLayer, Me.btnMarkingVisibleLayer})
        Me.MenuItemVisibleObjects.Name = "MenuItemVisibleObjects"
        Me.MenuItemVisibleObjects.Size = New System.Drawing.Size(88, 20)
        Me.MenuItemVisibleObjects.Text = "Visible Objects"
        '
        'btnHilitingVisibleLayer
        '
        Me.btnHilitingVisibleLayer.Name = "btnHilitingVisibleLayer"
        Me.btnHilitingVisibleLayer.Size = New System.Drawing.Size(122, 22)
        Me.btnHilitingVisibleLayer.Text = "Hilite"
        '
        'btnMarkingVisibleLayer
        '
        Me.btnMarkingVisibleLayer.Name = "btnMarkingVisibleLayer"
        Me.btnMarkingVisibleLayer.Size = New System.Drawing.Size(122, 22)
        Me.btnMarkingVisibleLayer.Text = "Marking"
        '
        'btnViewLayers
        '
        Me.btnViewLayers.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestingToolStripMenuItem})
        Me.btnViewLayers.Name = "btnViewLayers"
        Me.btnViewLayers.Size = New System.Drawing.Size(73, 20)
        Me.btnViewLayers.Text = "View layers"
        '
        'TestingToolStripMenuItem
        '
        Me.TestingToolStripMenuItem.Name = "TestingToolStripMenuItem"
        Me.TestingToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.TestingToolStripMenuItem.Text = "Testing"
        '
        'picBoxDragHandle
        '
        Me.picBoxDragHandle.Location = New System.Drawing.Point(194, 155)
        Me.picBoxDragHandle.Name = "picBoxDragHandle"
        Me.picBoxDragHandle.Size = New System.Drawing.Size(23, 20)
        Me.picBoxDragHandle.TabIndex = 23
        Me.picBoxDragHandle.TabStop = False
        '
        'PicBox2
        '
        Me.PicBox2.Location = New System.Drawing.Point(83, 155)
        Me.PicBox2.Name = "PicBox2"
        Me.PicBox2.Size = New System.Drawing.Size(41, 35)
        Me.PicBox2.TabIndex = 15
        Me.PicBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ContextMenuStrip = Me.cms1
        Me.PictureBox1.Location = New System.Drawing.Point(83, 155)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(483, 186)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'cms1
        '
        Me.cms1.Name = "ContextMenuStrip1"
        Me.cms1.Size = New System.Drawing.Size(61, 4)
        '
        'cmsPictureBox
        '
        Me.cmsPictureBox.Location = New System.Drawing.Point(258, 368)
        Me.cmsPictureBox.Name = "cmsPictureBox"
        Me.cmsPictureBox.Size = New System.Drawing.Size(100, 50)
        Me.cmsPictureBox.TabIndex = 25
        Me.cmsPictureBox.TabStop = False
        Me.cmsPictureBox.Visible = False
        '
        'pbx_Overlay
        '
        Me.pbx_Overlay.BackColor = System.Drawing.Color.Transparent
        Me.pbx_Overlay.Location = New System.Drawing.Point(414, 368)
        Me.pbx_Overlay.Name = "pbx_Overlay"
        Me.pbx_Overlay.Size = New System.Drawing.Size(246, 106)
        Me.pbx_Overlay.TabIndex = 26
        Me.pbx_Overlay.TabStop = False
        Me.pbx_Overlay.Visible = False
        '
        'tlb_EditDaqument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 531)
        Me.Controls.Add(Me.cmsPictureBox)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.picBoxDragHandle)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PicBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pbx_Overlay)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "tlb_EditDaqument"
        Me.Text = "Edit Test Form"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picBoxDragHandle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmsPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Overlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnInsertText As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnInsertImage As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFreehand As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDrag As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEnlarge As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnReduce As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnColorChoice As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnColorRed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnColorBlue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnColorGreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMarking As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLineWidth As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnWidth1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRedo As System.Windows.Forms.ToolStripButton
    Friend WithEvents PicBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrintPreview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnFormat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemVisibleObjects As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnViewLayers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSaveAsNewLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PageSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnHilitingVisibleLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMarkingVisibleLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLineDraw As System.Windows.Forms.ToolStripButton
    Friend WithEvents picBoxDragHandle As System.Windows.Forms.PictureBox
    Friend WithEvents btnColorYellow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnHiliting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCreateNewLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFontSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMaginfy As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btn500 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn200 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn150 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn100 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn75 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn50 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn25 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPageWidth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cms1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents pbx_Overlay As System.Windows.Forms.PictureBox

End Class
