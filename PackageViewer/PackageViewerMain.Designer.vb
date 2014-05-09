<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PackageViewerMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PackageViewerMain))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lbl_Message = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsl_SiteLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProjectStatusInd = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenPackageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitPackageViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DiscrepanciesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddDiscrepancyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PunchlistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PackageList = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(927, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.PackageViewer.My.Resources.Resources.Refresh
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Refresh"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.PackageViewer.My.Resources.Resources.Post_Note
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Add Discrepancy"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.PackageViewer.My.Resources.Resources.Tools_Add
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        Me.ToolStripButton3.ToolTipText = "Add Punchlist Item"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_Message, Me.tsl_SiteLabel, Me.ProjectStatusInd})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 547)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(927, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbl_Message
        '
        Me.lbl_Message.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Message.Name = "lbl_Message"
        Me.lbl_Message.Size = New System.Drawing.Size(688, 17)
        Me.lbl_Message.Spring = True
        Me.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsl_SiteLabel
        '
        Me.tsl_SiteLabel.BackColor = System.Drawing.SystemColors.Control
        Me.tsl_SiteLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsl_SiteLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tsl_SiteLabel.Name = "tsl_SiteLabel"
        Me.tsl_SiteLabel.Size = New System.Drawing.Size(108, 17)
        Me.tsl_SiteLabel.Text = "Site: Not Connected"
        '
        'ProjectStatusInd
        '
        Me.ProjectStatusInd.BackColor = System.Drawing.SystemColors.Control
        Me.ProjectStatusInd.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ProjectStatusInd.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ProjectStatusInd.Name = "ProjectStatusInd"
        Me.ProjectStatusInd.Size = New System.Drawing.Size(116, 17)
        Me.ProjectStatusInd.Text = "Project:  Not Selected"
        Me.ProjectStatusInd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.DiscrepanciesToolStripMenuItem, Me.PunchlistToolStripMenuItem, Me.PackageList, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(927, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenPackageToolStripMenuItem, Me.ToolStripSeparator2, Me.PrintPreviewToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitPackageViewerToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenPackageToolStripMenuItem
        '
        Me.OpenPackageToolStripMenuItem.Image = Global.PackageViewer.My.Resources.Resources.Folder_1_Open
        Me.OpenPackageToolStripMenuItem.Name = "OpenPackageToolStripMenuItem"
        Me.OpenPackageToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.OpenPackageToolStripMenuItem.Text = "Open Package"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(178, 6)
        '
        'PrintPreviewToolStripMenuItem
        '
        Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
        Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.PrintPreviewToolStripMenuItem.Text = "Print Preview"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(178, 6)
        '
        'ExitPackageViewerToolStripMenuItem
        '
        Me.ExitPackageViewerToolStripMenuItem.Image = Global.PackageViewer.My.Resources.Resources.Logout
        Me.ExitPackageViewerToolStripMenuItem.Name = "ExitPackageViewerToolStripMenuItem"
        Me.ExitPackageViewerToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ExitPackageViewerToolStripMenuItem.Text = "Exit Package Viewer"
        '
        'DiscrepanciesToolStripMenuItem
        '
        Me.DiscrepanciesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddDiscrepancyToolStripMenuItem})
        Me.DiscrepanciesToolStripMenuItem.Name = "DiscrepanciesToolStripMenuItem"
        Me.DiscrepanciesToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.DiscrepanciesToolStripMenuItem.Text = "Discrepancies"
        '
        'AddDiscrepancyToolStripMenuItem
        '
        Me.AddDiscrepancyToolStripMenuItem.Name = "AddDiscrepancyToolStripMenuItem"
        Me.AddDiscrepancyToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.AddDiscrepancyToolStripMenuItem.Text = "Add Discrepancy"
        '
        'PunchlistToolStripMenuItem
        '
        Me.PunchlistToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddItemToolStripMenuItem})
        Me.PunchlistToolStripMenuItem.Name = "PunchlistToolStripMenuItem"
        Me.PunchlistToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.PunchlistToolStripMenuItem.Text = "Punchlist"
        '
        'AddItemToolStripMenuItem
        '
        Me.AddItemToolStripMenuItem.Name = "AddItemToolStripMenuItem"
        Me.AddItemToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.AddItemToolStripMenuItem.Text = "Add Item"
        '
        'PackageList
        '
        Me.PackageList.Name = "PackageList"
        Me.PackageList.Size = New System.Drawing.Size(78, 20)
        Me.PackageList.Text = "Package List"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'PackageViewerMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 569)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PackageViewerMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daqart Package Viewer"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitPackageViewerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PackageList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiscrepanciesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddDiscrepancyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PunchlistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenPackageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl_Message As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsl_SiteLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProjectStatusInd As System.Windows.Forms.ToolStripStatusLabel
End Class
