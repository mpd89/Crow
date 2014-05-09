<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemTools
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SystemTools))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsb_Exit = New System.Windows.Forms.ToolStripButton
        Me.tsb_SystemAudit = New System.Windows.Forms.ToolStripButton
        Me.tsb_ServerLog = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 569)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(878, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Mainframe.png")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Exit, Me.tsb_SystemAudit, Me.tsb_ServerLog, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(878, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsb_Exit
        '
        Me.tsb_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_Exit.Image = Global.Daqart.My.Resources.Resources.Logout
        Me.tsb_Exit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Exit.Name = "tsb_Exit"
        Me.tsb_Exit.Size = New System.Drawing.Size(23, 22)
        Me.tsb_Exit.Text = "ToolStripButton3"
        Me.tsb_Exit.ToolTipText = "Logout"
        '
        'tsb_SystemAudit
        '
        Me.tsb_SystemAudit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_SystemAudit.Image = Global.Daqart.My.Resources.Resources.Mainframe1
        Me.tsb_SystemAudit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_SystemAudit.Name = "tsb_SystemAudit"
        Me.tsb_SystemAudit.Size = New System.Drawing.Size(23, 22)
        Me.tsb_SystemAudit.Text = "ToolStripButton1"
        Me.tsb_SystemAudit.ToolTipText = "System Audit"
        Me.tsb_SystemAudit.Visible = False
        '
        'tsb_ServerLog
        '
        Me.tsb_ServerLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_ServerLog.Image = Global.Daqart.My.Resources.Resources.Document_2_Configuration
        Me.tsb_ServerLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_ServerLog.Name = "tsb_ServerLog"
        Me.tsb_ServerLog.Size = New System.Drawing.Size(23, 22)
        Me.tsb_ServerLog.Text = "ToolStripButton2"
        Me.tsb_ServerLog.ToolTipText = "Server Log"
        Me.tsb_ServerLog.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Daqart.My.Resources.Resources.Security_Gold
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Permissions"
        '
        'SystemTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 591)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "SystemTools"
        Me.Text = "SystemTools"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_SystemAudit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_ServerLog As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Exit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
