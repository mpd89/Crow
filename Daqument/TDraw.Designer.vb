<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TDraw
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TDraw))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.tsb_Colors = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsb_Color1 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Color2 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Color3 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Width = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsb_Thin = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Normal = New System.Windows.Forms.ToolStripMenuItem
        Me.tsb_Thick = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
        Me.cbx_Zoom = New System.Windows.Forms.ToolStripComboBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tsl_Coordinates = New System.Windows.Forms.ToolStripStatusLabel
        Me.pbx_Background = New System.Windows.Forms.PictureBox
        Me.pbx_Overlay = New System.Windows.Forms.PictureBox
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.pbx_Background, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_Overlay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.tsb_Colors, Me.tsb_Width, Me.ToolStripButton6, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton7, Me.cbx_Zoom, Me.ToolStripButton8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(997, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(34, 22)
        Me.ToolStripButton1.Text = "Hilite"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripButton2.Text = "Markup"
        '
        'tsb_Colors
        '
        Me.tsb_Colors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Colors.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Color1, Me.tsb_Color2, Me.tsb_Color3})
        Me.tsb_Colors.Image = CType(resources.GetObject("tsb_Colors.Image"), System.Drawing.Image)
        Me.tsb_Colors.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Colors.Name = "tsb_Colors"
        Me.tsb_Colors.Size = New System.Drawing.Size(45, 22)
        Me.tsb_Colors.Text = "Color"
        '
        'tsb_Color1
        '
        Me.tsb_Color1.Name = "tsb_Color1"
        Me.tsb_Color1.Size = New System.Drawing.Size(116, 22)
        Me.tsb_Color1.Text = "Color1"
        '
        'tsb_Color2
        '
        Me.tsb_Color2.Name = "tsb_Color2"
        Me.tsb_Color2.Size = New System.Drawing.Size(116, 22)
        Me.tsb_Color2.Text = "Color2"
        '
        'tsb_Color3
        '
        Me.tsb_Color3.Name = "tsb_Color3"
        Me.tsb_Color3.Size = New System.Drawing.Size(116, 22)
        Me.tsb_Color3.Text = "Color3"
        '
        'tsb_Width
        '
        Me.tsb_Width.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_Width.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Thin, Me.tsb_Normal, Me.tsb_Thick})
        Me.tsb_Width.Image = CType(resources.GetObject("tsb_Width.Image"), System.Drawing.Image)
        Me.tsb_Width.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Width.Name = "tsb_Width"
        Me.tsb_Width.Size = New System.Drawing.Size(48, 22)
        Me.tsb_Width.Text = "Width"
        '
        'tsb_Thin
        '
        Me.tsb_Thin.Name = "tsb_Thin"
        Me.tsb_Thin.Size = New System.Drawing.Size(118, 22)
        Me.tsb_Thin.Text = "Thin"
        '
        'tsb_Normal
        '
        Me.tsb_Normal.Name = "tsb_Normal"
        Me.tsb_Normal.Size = New System.Drawing.Size(118, 22)
        Me.tsb_Normal.Text = "Normal"
        '
        'tsb_Thick
        '
        Me.tsb_Thick.Name = "tsb_Thick"
        Me.tsb_Thick.Size = New System.Drawing.Size(118, 22)
        Me.tsb_Thick.Text = "Thick"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(40, 22)
        Me.ToolStripButton6.Text = "Select"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(57, 22)
        Me.ToolStripButton3.Text = "Freehand"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(30, 22)
        Me.ToolStripButton4.Text = "Line"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(41, 22)
        Me.ToolStripButton5.Text = "Image"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripButton7.Text = "Pan"
        '
        'cbx_Zoom
        '
        Me.cbx_Zoom.Items.AddRange(New Object() {"400%", "200%", "150%", "100%", "75%", "50%", "25%", "Page"})
        Me.cbx_Zoom.Name = "cbx_Zoom"
        Me.cbx_Zoom.Size = New System.Drawing.Size(121, 25)
        Me.cbx_Zoom.Text = "Page"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsl_Coordinates})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 549)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(997, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsl_Coordinates
        '
        Me.tsl_Coordinates.Name = "tsl_Coordinates"
        Me.tsl_Coordinates.Size = New System.Drawing.Size(23, 17)
        Me.tsl_Coordinates.Text = "0,0"
        '
        'pbx_Background
        '
        Me.pbx_Background.BackColor = System.Drawing.SystemColors.Window
        Me.pbx_Background.Location = New System.Drawing.Point(12, 28)
        Me.pbx_Background.Margin = New System.Windows.Forms.Padding(0)
        Me.pbx_Background.Name = "pbx_Background"
        Me.pbx_Background.Size = New System.Drawing.Size(918, 503)
        Me.pbx_Background.TabIndex = 2
        Me.pbx_Background.TabStop = False
        '
        'pbx_Overlay
        '
        Me.pbx_Overlay.BackColor = System.Drawing.Color.Transparent
        Me.pbx_Overlay.Location = New System.Drawing.Point(12, 28)
        Me.pbx_Overlay.Name = "pbx_Overlay"
        Me.pbx_Overlay.Size = New System.Drawing.Size(918, 503)
        Me.pbx_Overlay.TabIndex = 3
        Me.pbx_Overlay.TabStop = False
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "ToolStripButton8"
        '
        'TDraw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 571)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.pbx_Overlay)
        Me.Controls.Add(Me.pbx_Background)
        Me.Name = "TDraw"
        Me.Text = "TDraw"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.pbx_Background, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_Overlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents pbx_Background As System.Windows.Forms.PictureBox
    Friend WithEvents pbx_Overlay As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Colors As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsb_Color1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Color2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Color3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Width As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsb_Thin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Normal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsb_Thick As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbx_Zoom As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsl_Coordinates As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
End Class
