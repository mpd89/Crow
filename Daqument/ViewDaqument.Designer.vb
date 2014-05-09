<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewDaqument
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
        Me.dwgPanel = New System.Windows.Forms.Panel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.stat_Main = New System.Windows.Forms.ToolStripStatusLabel
        Me.lab_XY = New System.Windows.Forms.ToolStripStatusLabel
        Me.tbr_Main = New System.Windows.Forms.ToolStrip
        Me.cbx_Zoom = New System.Windows.Forms.ToolStripComboBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HideTransparencyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowTransparencyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnViewNormal = New System.Windows.Forms.ToolStripButton
        Me.btnDrag = New System.Windows.Forms.ToolStripButton
        Me.btnHighlite = New System.Windows.Forms.ToolStripButton
        Me.dwgPanel.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.tbr_Main.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dwgPanel
        '
        Me.dwgPanel.AutoScroll = True
        Me.dwgPanel.Controls.Add(Me.StatusStrip1)
        Me.dwgPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.dwgPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwgPanel.Location = New System.Drawing.Point(0, 49)
        Me.dwgPanel.Name = "dwgPanel"
        Me.dwgPanel.Size = New System.Drawing.Size(944, 482)
        Me.dwgPanel.TabIndex = 6
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stat_Main, Me.lab_XY})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 460)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(944, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'stat_Main
        '
        Me.stat_Main.Name = "stat_Main"
        Me.stat_Main.Size = New System.Drawing.Size(835, 17)
        Me.stat_Main.Spring = True
        '
        'lab_XY
        '
        Me.lab_XY.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lab_XY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.lab_XY.Name = "lab_XY"
        Me.lab_XY.Size = New System.Drawing.Size(94, 17)
        Me.lab_XY.Text = "X:          Y:           "
        '
        'tbr_Main
        '
        Me.tbr_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnViewNormal, Me.btnDrag, Me.cbx_Zoom, Me.btnHighlite})
        Me.tbr_Main.Location = New System.Drawing.Point(0, 24)
        Me.tbr_Main.Name = "tbr_Main"
        Me.tbr_Main.Size = New System.Drawing.Size(944, 25)
        Me.tbr_Main.TabIndex = 5
        Me.tbr_Main.Text = "ToolStrip1"
        '
        'cbx_Zoom
        '
        Me.cbx_Zoom.Items.AddRange(New Object() {"25%", "50%", "75%", "100%", "125%", "150%", "200%", "400%", "800%"})
        Me.cbx_Zoom.Name = "cbx_Zoom"
        Me.cbx_Zoom.Size = New System.Drawing.Size(75, 25)
        Me.cbx_Zoom.Text = "100%"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.LayToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(944, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'LayToolStripMenuItem
        '
        Me.LayToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideTransparencyToolStripMenuItem, Me.ShowTransparencyToolStripMenuItem})
        Me.LayToolStripMenuItem.Enabled = False
        Me.LayToolStripMenuItem.Name = "LayToolStripMenuItem"
        Me.LayToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.LayToolStripMenuItem.Text = "Layers"
        '
        'HideTransparencyToolStripMenuItem
        '
        Me.HideTransparencyToolStripMenuItem.Name = "HideTransparencyToolStripMenuItem"
        Me.HideTransparencyToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.HideTransparencyToolStripMenuItem.Text = "Hide Transparency"
        '
        'ShowTransparencyToolStripMenuItem
        '
        Me.ShowTransparencyToolStripMenuItem.Name = "ShowTransparencyToolStripMenuItem"
        Me.ShowTransparencyToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ShowTransparencyToolStripMenuItem.Text = "Show Transparency"
        '
        'btnViewNormal
        '
        Me.btnViewNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnViewNormal.Image = Global.Daqument.My.Resources.Resources.Cancel
        Me.btnViewNormal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnViewNormal.Name = "btnViewNormal"
        Me.btnViewNormal.Size = New System.Drawing.Size(23, 22)
        Me.btnViewNormal.Text = "ToolStripButton2"
        '
        'btnDrag
        '
        Me.btnDrag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDrag.Image = Global.Daqument.My.Resources.Resources.move
        Me.btnDrag.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDrag.Name = "btnDrag"
        Me.btnDrag.Size = New System.Drawing.Size(23, 22)
        Me.btnDrag.Text = "ToolStripButton1"
        Me.btnDrag.ToolTipText = "Reset Background Image"
        '
        'btnHighlite
        '
        Me.btnHighlite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnHighlite.Image = Global.Daqument.My.Resources.Resources.highlite
        Me.btnHighlite.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHighlite.Name = "btnHighlite"
        Me.btnHighlite.Size = New System.Drawing.Size(23, 22)
        Me.btnHighlite.Text = "ToolStripButton1"
        '
        'ViewDaqument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 531)
        Me.Controls.Add(Me.dwgPanel)
        Me.Controls.Add(Me.tbr_Main)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "ViewDaqument"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ViewDaqument"
        Me.dwgPanel.ResumeLayout(False)
        Me.dwgPanel.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tbr_Main.ResumeLayout(False)
        Me.tbr_Main.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dwgPanel As System.Windows.Forms.Panel
    Friend WithEvents tbr_Main As System.Windows.Forms.ToolStrip
    Friend WithEvents btnViewNormal As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDrag As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbx_Zoom As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideTransparencyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowTransparencyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents stat_Main As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lab_XY As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnHighlite As System.Windows.Forms.ToolStripButton
End Class
