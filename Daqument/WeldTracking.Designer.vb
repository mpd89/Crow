<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WeldTracking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WeldTracking))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnCreateNewLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PageSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnFormat = New System.Windows.Forms.ToolStripMenuItem
        Me.btnFontSelect = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnPageSetup = New System.Windows.Forms.ToolStripMenuItem
        Me.btnPrintPreview = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.btnInsertImage = New System.Windows.Forms.ToolStripButton
        Me.btnDrag = New System.Windows.Forms.ToolStripButton
        Me.btnWeldSelect = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnColorRed = New System.Windows.Forms.ToolStripMenuItem
        Me.btnColorBlue = New System.Windows.Forms.ToolStripMenuItem
        Me.btnColorGreen = New System.Windows.Forms.ToolStripMenuItem
        Me.btnColorYellow = New System.Windows.Forms.ToolStripMenuItem
        Me.btnColorOrange = New System.Windows.Forms.ToolStripMenuItem
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.cms1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsPictureBox = New System.Windows.Forms.PictureBox
        Me.picBoxDragHandle = New System.Windows.Forms.PictureBox
        Me.PicBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cmsPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxDragHandle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.btnFormat})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1069, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCreateNewLayer, Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem, Me.PageSetupToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'btnCreateNewLayer
        '
        Me.btnCreateNewLayer.Name = "btnCreateNewLayer"
        Me.btnCreateNewLayer.Size = New System.Drawing.Size(154, 22)
        Me.btnCreateNewLayer.Text = "Add new layer"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'PageSetupToolStripMenuItem
        '
        Me.PageSetupToolStripMenuItem.Name = "PageSetupToolStripMenuItem"
        Me.PageSetupToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
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
        Me.btnFontSelect.Size = New System.Drawing.Size(152, 22)
        Me.btnFontSelect.Text = "Fonts"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripDropDownButton2, Me.ToolStripButton2, Me.ToolStripButton1, Me.btnCancel, Me.btnInsertImage, Me.btnDrag, Me.btnWeldSelect, Me.btnLineWidth, Me.btnUndo, Me.btnRedo, Me.btnMaginfy})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1069, 25)
        Me.ToolStrip1.TabIndex = 24
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
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Daqument.My.Resources.Resources.Calendar
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Weld List"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Daqument.My.Resources.Resources.Document
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Weld Parameters"
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
        'btnInsertImage
        '
        Me.btnInsertImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnInsertImage.Image = Global.Daqument.My.Resources.Resources.yellowSocketWeld
        Me.btnInsertImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInsertImage.Name = "btnInsertImage"
        Me.btnInsertImage.Size = New System.Drawing.Size(23, 22)
        Me.btnInsertImage.Text = "Insert Image"
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
        'btnWeldSelect
        '
        Me.btnWeldSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnWeldSelect.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnColorRed, Me.btnColorBlue, Me.btnColorGreen, Me.btnColorYellow, Me.btnColorOrange})
        Me.btnWeldSelect.Image = CType(resources.GetObject("btnWeldSelect.Image"), System.Drawing.Image)
        Me.btnWeldSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnWeldSelect.Name = "btnWeldSelect"
        Me.btnWeldSelect.Size = New System.Drawing.Size(127, 22)
        Me.btnWeldSelect.Text = "Select Weld Operation"
        '
        'btnColorRed
        '
        Me.btnColorRed.BackColor = System.Drawing.Color.Red
        Me.btnColorRed.Name = "btnColorRed"
        Me.btnColorRed.Size = New System.Drawing.Size(168, 22)
        Me.btnColorRed.Text = "Reject Welds"
        '
        'btnColorBlue
        '
        Me.btnColorBlue.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnColorBlue.Name = "btnColorBlue"
        Me.btnColorBlue.Size = New System.Drawing.Size(168, 22)
        Me.btnColorBlue.Text = "New Welds"
        '
        'btnColorGreen
        '
        Me.btnColorGreen.BackColor = System.Drawing.Color.Lime
        Me.btnColorGreen.Name = "btnColorGreen"
        Me.btnColorGreen.Size = New System.Drawing.Size(168, 22)
        Me.btnColorGreen.Text = "Completed Welds"
        '
        'btnColorYellow
        '
        Me.btnColorYellow.BackColor = System.Drawing.Color.Yellow
        Me.btnColorYellow.Name = "btnColorYellow"
        Me.btnColorYellow.Size = New System.Drawing.Size(168, 22)
        Me.btnColorYellow.Text = "Field Welds"
        '
        'btnColorOrange
        '
        Me.btnColorOrange.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnColorOrange.Name = "btnColorOrange"
        Me.btnColorOrange.Size = New System.Drawing.Size(168, 22)
        Me.btnColorOrange.Text = "Inspect Welds"
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
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 621)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1069, 22)
        Me.StatusStrip1.TabIndex = 30
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'cms1
        '
        Me.cms1.Name = "ContextMenuStrip1"
        Me.cms1.Size = New System.Drawing.Size(61, 4)
        '
        'cmsPictureBox
        '
        Me.cmsPictureBox.Location = New System.Drawing.Point(298, 250)
        Me.cmsPictureBox.Name = "cmsPictureBox"
        Me.cmsPictureBox.Size = New System.Drawing.Size(100, 50)
        Me.cmsPictureBox.TabIndex = 29
        Me.cmsPictureBox.TabStop = False
        Me.cmsPictureBox.Visible = False
        '
        'picBoxDragHandle
        '
        Me.picBoxDragHandle.Location = New System.Drawing.Point(334, 126)
        Me.picBoxDragHandle.Name = "picBoxDragHandle"
        Me.picBoxDragHandle.Size = New System.Drawing.Size(23, 20)
        Me.picBoxDragHandle.TabIndex = 28
        Me.picBoxDragHandle.TabStop = False
        '
        'PicBox2
        '
        Me.PicBox2.Location = New System.Drawing.Point(252, 117)
        Me.PicBox2.Name = "PicBox2"
        Me.PicBox2.Size = New System.Drawing.Size(41, 35)
        Me.PicBox2.TabIndex = 27
        Me.PicBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(252, 114)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(342, 132)
        Me.PictureBox1.TabIndex = 26
        Me.PictureBox1.TabStop = False
        '
        'WeldTracking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 643)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cmsPictureBox)
        Me.Controls.Add(Me.picBoxDragHandle)
        Me.Controls.Add(Me.PicBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "WeldTracking"
        Me.Text = "Weld Mapping"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cmsPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxDragHandle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCreateNewLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PageSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFormat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFontSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnPageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrintPreview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnInsertImage As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDrag As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnWeldSelect As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnColorRed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnColorBlue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnColorGreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnColorYellow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLineWidth As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnWidth1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRedo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMaginfy As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btn500 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn200 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn150 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn100 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn75 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn50 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn25 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPageWidth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents picBoxDragHandle As System.Windows.Forms.PictureBox
    Friend WithEvents PicBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents cms1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnColorOrange As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
End Class
