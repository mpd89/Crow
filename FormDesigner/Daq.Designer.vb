<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Daq
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Daq))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.btnInsertText = New System.Windows.Forms.ToolStripButton
        Me.btnInsertImage = New System.Windows.Forms.ToolStripButton
        Me.btnLineDraw = New System.Windows.Forms.ToolStripButton
        Me.btnDrag = New System.Windows.Forms.ToolStripButton
        Me.zoomIn = New System.Windows.Forms.ToolStripButton
        Me.zoomOut = New System.Windows.Forms.ToolStripButton
        Me.btnColorChoice = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnColorRed = New System.Windows.Forms.ToolStripMenuItem
        Me.btnColorBlue = New System.Windows.Forms.ToolStripMenuItem
        Me.btnColorGreen = New System.Windows.Forms.ToolStripMenuItem
        Me.btnDrawOpaque = New System.Windows.Forms.ToolStripMenuItem
        Me.btnLineWidth = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnWidth1 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnWidth2 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnWidth3 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnWidth4 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnWidth5 = New System.Windows.Forms.ToolStripMenuItem
        Me.btnUndo = New System.Windows.Forms.ToolStripButton
        Me.btnRedo = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PicBox2 = New System.Windows.Forms.PictureBox
        Me.PicBoxDragHandle = New System.Windows.Forms.PictureBox
        Me.PicBoxDragXLeft = New System.Windows.Forms.PictureBox
        Me.PicBoxDragDrawBoundry = New System.Windows.Forms.PictureBox
        Me.PicBoxDragXY = New System.Windows.Forms.PictureBox
        Me.PicBoxDragXRight = New System.Windows.Forms.PictureBox
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBoxDragHandle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBoxDragXLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBoxDragDrawBoundry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBoxDragXY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBoxDragXRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCancel, Me.btnInsertText, Me.btnInsertImage, Me.btnLineDraw, Me.btnDrag, Me.zoomIn, Me.zoomOut, Me.btnColorChoice, Me.btnLineWidth, Me.btnUndo, Me.btnRedo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(518, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnCancel
        '
        Me.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancel.Image = Global.FormDesigner.My.Resources.Resources.Cancel
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(23, 22)
        Me.btnCancel.Text = "ToolStripButton3"
        '
        'btnInsertText
        '
        Me.btnInsertText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnInsertText.Image = Global.FormDesigner.My.Resources.Resources.Text_Document
        Me.btnInsertText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInsertText.Name = "btnInsertText"
        Me.btnInsertText.Size = New System.Drawing.Size(23, 22)
        Me.btnInsertText.Text = "Insert Text"
        '
        'btnInsertImage
        '
        Me.btnInsertImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnInsertImage.Image = Global.FormDesigner.My.Resources.Resources.Image
        Me.btnInsertImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInsertImage.Name = "btnInsertImage"
        Me.btnInsertImage.Size = New System.Drawing.Size(23, 22)
        Me.btnInsertImage.Text = "Insert Image"
        '
        'btnLineDraw
        '
        Me.btnLineDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLineDraw.Image = Global.FormDesigner.My.Resources.Resources.Symbol_Edit
        Me.btnLineDraw.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLineDraw.Name = "btnLineDraw"
        Me.btnLineDraw.Size = New System.Drawing.Size(23, 22)
        Me.btnLineDraw.Text = "Line Draw"
        '
        'btnDrag
        '
        Me.btnDrag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDrag.Image = Global.FormDesigner.My.Resources.Resources.move
        Me.btnDrag.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDrag.Name = "btnDrag"
        Me.btnDrag.Size = New System.Drawing.Size(23, 22)
        Me.btnDrag.Text = "Drag"
        '
        'zoomIn
        '
        Me.zoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.zoomIn.Image = Global.FormDesigner.My.Resources.Resources.Search_Zoom_In
        Me.zoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.zoomIn.Name = "zoomIn"
        Me.zoomIn.Size = New System.Drawing.Size(23, 22)
        Me.zoomIn.Text = "ToolStripButton3"
        '
        'zoomOut
        '
        Me.zoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.zoomOut.Image = Global.FormDesigner.My.Resources.Resources.Search_Zoom_Out
        Me.zoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.zoomOut.Name = "zoomOut"
        Me.zoomOut.Size = New System.Drawing.Size(23, 22)
        Me.zoomOut.Text = "ToolStripButton4"
        '
        'btnColorChoice
        '
        Me.btnColorChoice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnColorChoice.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnColorRed, Me.btnColorBlue, Me.btnColorGreen, Me.btnDrawOpaque})
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
        'btnDrawOpaque
        '
        Me.btnDrawOpaque.Name = "btnDrawOpaque"
        Me.btnDrawOpaque.Size = New System.Drawing.Size(122, 22)
        Me.btnDrawOpaque.Text = "Marking"
        '
        'btnLineWidth
        '
        Me.btnLineWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLineWidth.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnWidth1, Me.btnWidth2, Me.btnWidth3, Me.btnWidth4, Me.btnWidth5})
        Me.btnLineWidth.Image = CType(resources.GetObject("btnLineWidth.Image"), System.Drawing.Image)
        Me.btnLineWidth.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLineWidth.Name = "btnLineWidth"
        Me.btnLineWidth.Size = New System.Drawing.Size(29, 22)
        Me.btnLineWidth.Text = "Line Width"
        '
        'btnWidth1
        '
        Me.btnWidth1.Image = Global.FormDesigner.My.Resources.Resources.Width1
        Me.btnWidth1.Name = "btnWidth1"
        Me.btnWidth1.Size = New System.Drawing.Size(119, 22)
        Me.btnWidth1.Text = "Width1"
        '
        'btnWidth2
        '
        Me.btnWidth2.Image = Global.FormDesigner.My.Resources.Resources.Width2
        Me.btnWidth2.Name = "btnWidth2"
        Me.btnWidth2.Size = New System.Drawing.Size(119, 22)
        Me.btnWidth2.Text = "Width2"
        '
        'btnWidth3
        '
        Me.btnWidth3.Image = Global.FormDesigner.My.Resources.Resources.Width3
        Me.btnWidth3.Name = "btnWidth3"
        Me.btnWidth3.Size = New System.Drawing.Size(119, 22)
        Me.btnWidth3.Text = "Width3"
        '
        'btnWidth4
        '
        Me.btnWidth4.Image = Global.FormDesigner.My.Resources.Resources.Width4
        Me.btnWidth4.Name = "btnWidth4"
        Me.btnWidth4.Size = New System.Drawing.Size(119, 22)
        Me.btnWidth4.Text = "Width4"
        '
        'btnWidth5
        '
        Me.btnWidth5.Image = Global.FormDesigner.My.Resources.Resources.Width5
        Me.btnWidth5.Name = "btnWidth5"
        Me.btnWidth5.Size = New System.Drawing.Size(119, 22)
        Me.btnWidth5.Text = "Width5"
        '
        'btnUndo
        '
        Me.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUndo.Image = Global.FormDesigner.My.Resources.Resources.Undo
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(23, 22)
        Me.btnUndo.Text = "Undo"
        '
        'btnRedo
        '
        Me.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRedo.Image = Global.FormDesigner.My.Resources.Resources.Redo
        Me.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRedo.Name = "btnRedo"
        Me.btnRedo.Size = New System.Drawing.Size(23, 22)
        Me.btnRedo.Text = "Redo"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 334)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(518, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(75, 67)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(342, 132)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'PicBox2
        '
        Me.PicBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBox2.Location = New System.Drawing.Point(75, 67)
        Me.PicBox2.Name = "PicBox2"
        Me.PicBox2.Size = New System.Drawing.Size(41, 35)
        Me.PicBox2.TabIndex = 8
        Me.PicBox2.TabStop = False
        '
        'PicBoxDragHandle
        '
        Me.PicBoxDragHandle.Location = New System.Drawing.Point(135, 67)
        Me.PicBoxDragHandle.Name = "PicBoxDragHandle"
        Me.PicBoxDragHandle.Size = New System.Drawing.Size(22, 24)
        Me.PicBoxDragHandle.TabIndex = 9
        Me.PicBoxDragHandle.TabStop = False
        '
        'PicBoxDragXLeft
        '
        Me.PicBoxDragXLeft.Location = New System.Drawing.Point(269, 51)
        Me.PicBoxDragXLeft.Name = "PicBoxDragXLeft"
        Me.PicBoxDragXLeft.Size = New System.Drawing.Size(10, 10)
        Me.PicBoxDragXLeft.TabIndex = 10
        Me.PicBoxDragXLeft.TabStop = False
        '
        'PicBoxDragDrawBoundry
        '
        Me.PicBoxDragDrawBoundry.Location = New System.Drawing.Point(317, 51)
        Me.PicBoxDragDrawBoundry.Name = "PicBoxDragDrawBoundry"
        Me.PicBoxDragDrawBoundry.Size = New System.Drawing.Size(10, 10)
        Me.PicBoxDragDrawBoundry.TabIndex = 11
        Me.PicBoxDragDrawBoundry.TabStop = False
        '
        'PicBoxDragXY
        '
        Me.PicBoxDragXY.Location = New System.Drawing.Point(301, 51)
        Me.PicBoxDragXY.Name = "PicBoxDragXY"
        Me.PicBoxDragXY.Size = New System.Drawing.Size(10, 10)
        Me.PicBoxDragXY.TabIndex = 12
        Me.PicBoxDragXY.TabStop = False
        '
        'PicBoxDragXRight
        '
        Me.PicBoxDragXRight.Location = New System.Drawing.Point(285, 51)
        Me.PicBoxDragXRight.Name = "PicBoxDragXRight"
        Me.PicBoxDragXRight.Size = New System.Drawing.Size(10, 10)
        Me.PicBoxDragXRight.TabIndex = 13
        Me.PicBoxDragXRight.TabStop = False
        '
        'Daq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 356)
        Me.Controls.Add(Me.PicBoxDragXRight)
        Me.Controls.Add(Me.PicBoxDragXY)
        Me.Controls.Add(Me.PicBoxDragDrawBoundry)
        Me.Controls.Add(Me.PicBoxDragXLeft)
        Me.Controls.Add(Me.PicBoxDragHandle)
        Me.Controls.Add(Me.PicBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Daq"
        Me.Text = "Daq"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBoxDragHandle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBoxDragXLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBoxDragDrawBoundry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBoxDragXY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBoxDragXRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnLineDraw As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents btnDrag As System.Windows.Forms.ToolStripButton
    Friend WithEvents zoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents zoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnColorChoice As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnColorRed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnColorBlue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnColorGreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnInsertImage As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDrawOpaque As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLineWidth As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnWidth1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWidth5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRedo As System.Windows.Forms.ToolStripButton
    Friend WithEvents PicBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnInsertText As System.Windows.Forms.ToolStripButton
    Friend WithEvents PicBoxDragHandle As System.Windows.Forms.PictureBox
    Friend WithEvents PicBoxDragXLeft As System.Windows.Forms.PictureBox
    Friend WithEvents PicBoxDragDrawBoundry As System.Windows.Forms.PictureBox
    Friend WithEvents PicBoxDragXY As System.Windows.Forms.PictureBox
    Friend WithEvents PicBoxDragXRight As System.Windows.Forms.PictureBox
End Class
