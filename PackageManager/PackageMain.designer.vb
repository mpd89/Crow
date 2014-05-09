<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PackageMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PackageMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnClose = New System.Windows.Forms.ToolStripMenuItem
        Me.PackgesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnPackageEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.btnPackageNew = New System.Windows.Forms.ToolStripMenuItem
        Me.btnPackageImport = New System.Windows.Forms.ToolStripMenuItem
        Me.btnPackageExport = New System.Windows.Forms.ToolStripMenuItem
        Me.TagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnTagEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.btnTagNew = New System.Windows.Forms.ToolStripMenuItem
        Me.btnTagImport = New System.Windows.Forms.ToolStripMenuItem
        Me.btnTagExport = New System.Windows.Forms.ToolStripMenuItem
        Me.TasksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbl_Message = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsl_SiteLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProjectStatusInd = New System.Windows.Forms.ToolStripStatusLabel
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ConnTimer = New System.Timers.Timer
        Me.SystemWindow = New System.Windows.Forms.SplitContainer
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.MarqueeProgressBarControl1 = New DevExpress.XtraEditors.MarqueeProgressBarControl
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ConnTimer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SystemWindow.Panel2.SuspendLayout()
        Me.SystemWindow.SuspendLayout()
        CType(Me.MarqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.PackgesToolStripMenuItem, Me.TagsToolStripMenuItem, Me.TasksToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(711, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnClose})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'btnClose
        '
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(111, 22)
        Me.btnClose.Text = "Close"
        '
        'PackgesToolStripMenuItem
        '
        Me.PackgesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPackageEdit, Me.btnPackageNew, Me.btnPackageImport, Me.btnPackageExport})
        Me.PackgesToolStripMenuItem.Name = "PackgesToolStripMenuItem"
        Me.PackgesToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.PackgesToolStripMenuItem.Text = "Packages"
        '
        'btnPackageEdit
        '
        Me.btnPackageEdit.Name = "btnPackageEdit"
        Me.btnPackageEdit.Size = New System.Drawing.Size(117, 22)
        Me.btnPackageEdit.Text = "Edit"
        '
        'btnPackageNew
        '
        Me.btnPackageNew.Name = "btnPackageNew"
        Me.btnPackageNew.Size = New System.Drawing.Size(117, 22)
        Me.btnPackageNew.Text = "New"
        '
        'btnPackageImport
        '
        Me.btnPackageImport.Name = "btnPackageImport"
        Me.btnPackageImport.Size = New System.Drawing.Size(117, 22)
        Me.btnPackageImport.Text = "Import"
        '
        'btnPackageExport
        '
        Me.btnPackageExport.Name = "btnPackageExport"
        Me.btnPackageExport.Size = New System.Drawing.Size(117, 22)
        Me.btnPackageExport.Text = "Export"
        '
        'TagsToolStripMenuItem
        '
        Me.TagsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnTagEdit, Me.btnTagNew, Me.btnTagImport, Me.btnTagExport})
        Me.TagsToolStripMenuItem.Name = "TagsToolStripMenuItem"
        Me.TagsToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.TagsToolStripMenuItem.Text = "Tags"
        '
        'btnTagEdit
        '
        Me.btnTagEdit.Name = "btnTagEdit"
        Me.btnTagEdit.Size = New System.Drawing.Size(152, 22)
        Me.btnTagEdit.Text = "Edit"
        '
        'btnTagNew
        '
        Me.btnTagNew.Name = "btnTagNew"
        Me.btnTagNew.Size = New System.Drawing.Size(152, 22)
        Me.btnTagNew.Text = "New"
        '
        'btnTagImport
        '
        Me.btnTagImport.Name = "btnTagImport"
        Me.btnTagImport.Size = New System.Drawing.Size(152, 22)
        Me.btnTagImport.Text = "Import"
        '
        'btnTagExport
        '
        Me.btnTagExport.Name = "btnTagExport"
        Me.btnTagExport.Size = New System.Drawing.Size(152, 22)
        Me.btnTagExport.Text = "Export"
        '
        'TasksToolStripMenuItem
        '
        Me.TasksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.NewToolStripMenuItem, Me.ImportToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.TasksToolStripMenuItem.Name = "TasksToolStripMenuItem"
        Me.TasksToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.TasksToolStripMenuItem.Text = "Tasks"
        Me.TasksToolStripMenuItem.Visible = False
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpManualToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpManualToolStripMenuItem
        '
        Me.HelpManualToolStripMenuItem.Name = "HelpManualToolStripMenuItem"
        Me.HelpManualToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.HelpManualToolStripMenuItem.Text = "Help Manual"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lbl_Message, Me.tsl_SiteLabel, Me.ProjectStatusInd})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 523)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(711, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'lbl_Message
        '
        Me.lbl_Message.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Message.Name = "lbl_Message"
        Me.lbl_Message.Size = New System.Drawing.Size(472, 17)
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
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "Daqart is Running"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Daqart"
        Me.NotifyIcon1.Visible = True
        '
        'ConnTimer
        '
        Me.ConnTimer.Enabled = True
        Me.ConnTimer.Interval = 1000
        Me.ConnTimer.SynchronizingObject = Me
        '
        'SystemWindow
        '
        Me.SystemWindow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SystemWindow.Location = New System.Drawing.Point(0, 24)
        Me.SystemWindow.Name = "SystemWindow"
        '
        'SystemWindow.Panel2
        '
        Me.SystemWindow.Panel2.Controls.Add(Me.TabControl1)
        Me.SystemWindow.Size = New System.Drawing.Size(711, 499)
        Me.SystemWindow.SplitterDistance = 143
        Me.SystemWindow.TabIndex = 4
        Me.SystemWindow.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(564, 499)
        Me.TabControl1.TabIndex = 0
        '
        'MarqueeProgressBarControl1
        '
        Me.MarqueeProgressBarControl1.EditValue = 0
        Me.MarqueeProgressBarControl1.Location = New System.Drawing.Point(418, 3)
        Me.MarqueeProgressBarControl1.Name = "MarqueeProgressBarControl1"
        Me.MarqueeProgressBarControl1.Size = New System.Drawing.Size(100, 18)
        Me.MarqueeProgressBarControl1.TabIndex = 6
        '
        'PackageMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(711, 545)
        Me.Controls.Add(Me.MarqueeProgressBarControl1)
        Me.Controls.Add(Me.SystemWindow)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PackageMain"
        Me.Text = "Package Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ConnTimer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SystemWindow.Panel2.ResumeLayout(False)
        Me.SystemWindow.ResumeLayout(False)
        CType(Me.MarqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents HelpManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ConnTimer As System.Timers.Timer
    Friend WithEvents SystemWindow As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PackgesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPackageEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPackageNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPackageImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTagEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTagNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTagImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTagExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPackageExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarqueeProgressBarControl1 As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents TasksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_Message As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsl_SiteLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProjectStatusInd As System.Windows.Forms.ToolStripStatusLabel
End Class
