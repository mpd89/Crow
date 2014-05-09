<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImagePreview
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsb_Pan = New System.Windows.Forms.ToolStripButton
        Me.tsb_ZoomIn = New System.Windows.Forms.ToolStripButton
        Me.tsb_ZoomOut = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pbx_Image = New System.Windows.Forms.PictureBox
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbx_Image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Pan, Me.tsb_ZoomIn, Me.tsb_ZoomOut})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(581, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsb_Pan
        '
        Me.tsb_Pan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_Pan.Enabled = False
        Me.tsb_Pan.Image = Global.Daqument.My.Resources.Resources.move
        Me.tsb_Pan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Pan.Name = "tsb_Pan"
        Me.tsb_Pan.Size = New System.Drawing.Size(23, 22)
        Me.tsb_Pan.Text = "ToolStripButton1"
        Me.tsb_Pan.Visible = False
        '
        'tsb_ZoomIn
        '
        Me.tsb_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_ZoomIn.Image = Global.Daqument.My.Resources.Resources.Search_Zoom_In
        Me.tsb_ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_ZoomIn.Name = "tsb_ZoomIn"
        Me.tsb_ZoomIn.Size = New System.Drawing.Size(23, 22)
        Me.tsb_ZoomIn.Text = "Zoom out"
        '
        'tsb_ZoomOut
        '
        Me.tsb_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_ZoomOut.Image = Global.Daqument.My.Resources.Resources.Search_Zoom_Out
        Me.tsb_ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_ZoomOut.Name = "tsb_ZoomOut"
        Me.tsb_ZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.tsb_ZoomOut.Text = "Zoom in"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.pbx_Image)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(581, 429)
        Me.Panel1.TabIndex = 2
        '
        'pbx_Image
        '
        Me.pbx_Image.Location = New System.Drawing.Point(0, 0)
        Me.pbx_Image.Name = "pbx_Image"
        Me.pbx_Image.Size = New System.Drawing.Size(581, 429)
        Me.pbx_Image.TabIndex = 1
        Me.pbx_Image.TabStop = False
        '
        'ImagePreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "ImagePreview"
        Me.Size = New System.Drawing.Size(581, 454)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbx_Image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents pbx_Image As System.Windows.Forms.PictureBox
    Friend WithEvents tsb_Pan As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_ZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_ZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
