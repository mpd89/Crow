<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemView
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SystemView))
        Me.SystemWindow = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SystemTree = New System.Windows.Forms.TreeView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_ProjectITS = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SystemMenu = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.cbx_Owners = New System.Windows.Forms.ComboBox
        Me.btn_GetOverview = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.tbx_SystemNumber = New System.Windows.Forms.TextBox
        Me.tbc_Main = New System.Windows.Forms.TabControl
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_RefreshOverview = New System.Windows.Forms.ToolStripButton
        Me.tsb_PrintOverview = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_OverviewClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsb_GetSystemDiscrepancies = New System.Windows.Forms.ToolStripButton
        Me.tsb_GetSystemPunchlist = New System.Windows.Forms.ToolStripButton
        Me.tsb_PkgShortForm = New System.Windows.Forms.ToolStripDropDownButton
        Me.PrintPkgShortFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintSystemPackagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btn_EniExport = New System.Windows.Forms.ToolStripButton
        Me.cmsMessages = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.RefreshToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lbl_Message = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsl_SiteLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProjectStatusInd = New System.Windows.Forms.ToolStripStatusLabel
        Me.SystemWindow.Panel1.SuspendLayout()
        Me.SystemWindow.Panel2.SuspendLayout()
        Me.SystemWindow.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SystemMenu.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.cmsMessages.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SystemWindow
        '
        Me.SystemWindow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SystemWindow.Location = New System.Drawing.Point(0, 0)
        Me.SystemWindow.Name = "SystemWindow"
        '
        'SystemWindow.Panel1
        '
        Me.SystemWindow.Panel1.Controls.Add(Me.Panel1)
        '
        'SystemWindow.Panel2
        '
        Me.SystemWindow.Panel2.Controls.Add(Me.tbc_Main)
        Me.SystemWindow.Panel2.Controls.Add(Me.ToolStrip2)
        Me.SystemWindow.Size = New System.Drawing.Size(994, 482)
        Me.SystemWindow.SplitterDistance = 197
        Me.SystemWindow.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.SystemTree)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(197, 482)
        Me.Panel1.TabIndex = 0
        '
        'SystemTree
        '
        Me.SystemTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SystemTree.Location = New System.Drawing.Point(0, 25)
        Me.SystemTree.Name = "SystemTree"
        Me.SystemTree.Size = New System.Drawing.Size(197, 457)
        Me.SystemTree.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_ProjectITS})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(197, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_ProjectITS
        '
        Me.btn_ProjectITS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_ProjectITS.Image = CType(resources.GetObject("btn_ProjectITS.Image"), System.Drawing.Image)
        Me.btn_ProjectITS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ProjectITS.Name = "btn_ProjectITS"
        Me.btn_ProjectITS.Size = New System.Drawing.Size(67, 22)
        Me.btn_ProjectITS.Text = "Project ITS"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 184)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SystemMenu)
        Me.SplitContainer1.Size = New System.Drawing.Size(161, 194)
        Me.SplitContainer1.SplitterDistance = 125
        Me.SplitContainer1.TabIndex = 0
        '
        'SystemMenu
        '
        Me.SystemMenu.Controls.Add(Me.Button2)
        Me.SystemMenu.Controls.Add(Me.cbx_Owners)
        Me.SystemMenu.Controls.Add(Me.btn_GetOverview)
        Me.SystemMenu.Controls.Add(Me.Button1)
        Me.SystemMenu.Controls.Add(Me.tbx_SystemNumber)
        Me.SystemMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SystemMenu.Location = New System.Drawing.Point(0, 0)
        Me.SystemMenu.Name = "SystemMenu"
        Me.SystemMenu.Size = New System.Drawing.Size(161, 65)
        Me.SystemMenu.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(45, 147)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Test"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cbx_Owners
        '
        Me.cbx_Owners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Owners.FormattingEnabled = True
        Me.cbx_Owners.Items.AddRange(New Object() {"*"})
        Me.cbx_Owners.Location = New System.Drawing.Point(3, 35)
        Me.cbx_Owners.Name = "cbx_Owners"
        Me.cbx_Owners.Size = New System.Drawing.Size(168, 21)
        Me.cbx_Owners.TabIndex = 3
        '
        'btn_GetOverview
        '
        Me.btn_GetOverview.Location = New System.Drawing.Point(3, 71)
        Me.btn_GetOverview.Name = "btn_GetOverview"
        Me.btn_GetOverview.Size = New System.Drawing.Size(168, 23)
        Me.btn_GetOverview.TabIndex = 2
        Me.btn_GetOverview.Text = "Get Overview"
        Me.btn_GetOverview.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(144, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 20)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbx_SystemNumber
        '
        Me.tbx_SystemNumber.Location = New System.Drawing.Point(3, 0)
        Me.tbx_SystemNumber.Name = "tbx_SystemNumber"
        Me.tbx_SystemNumber.Size = New System.Drawing.Size(140, 20)
        Me.tbx_SystemNumber.TabIndex = 0
        '
        'tbc_Main
        '
        Me.tbc_Main.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tbc_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbc_Main.Location = New System.Drawing.Point(0, 25)
        Me.tbc_Main.Multiline = True
        Me.tbc_Main.Name = "tbc_Main"
        Me.tbc_Main.SelectedIndex = 0
        Me.tbc_Main.Size = New System.Drawing.Size(793, 457)
        Me.tbc_Main.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator3, Me.tsb_RefreshOverview, Me.tsb_PrintOverview, Me.ToolStripSeparator1, Me.tsb_OverviewClose, Me.ToolStripSeparator2, Me.tsb_GetSystemDiscrepancies, Me.tsb_GetSystemPunchlist, Me.tsb_PkgShortForm, Me.btn_EniExport})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip2.Size = New System.Drawing.Size(793, 25)
        Me.ToolStrip2.TabIndex = 1
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Synchronize Database"
        Me.ToolStripButton1.ToolTipText = "Synchronize Project"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_RefreshOverview
        '
        Me.tsb_RefreshOverview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_RefreshOverview.Image = CType(resources.GetObject("tsb_RefreshOverview.Image"), System.Drawing.Image)
        Me.tsb_RefreshOverview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_RefreshOverview.Name = "tsb_RefreshOverview"
        Me.tsb_RefreshOverview.Size = New System.Drawing.Size(23, 22)
        Me.tsb_RefreshOverview.Text = "Refresh"
        Me.tsb_RefreshOverview.ToolTipText = "Refresh Overview"
        '
        'tsb_PrintOverview
        '
        Me.tsb_PrintOverview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_PrintOverview.Image = CType(resources.GetObject("tsb_PrintOverview.Image"), System.Drawing.Image)
        Me.tsb_PrintOverview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_PrintOverview.Name = "tsb_PrintOverview"
        Me.tsb_PrintOverview.Size = New System.Drawing.Size(23, 22)
        Me.tsb_PrintOverview.Text = "Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_OverviewClose
        '
        Me.tsb_OverviewClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_OverviewClose.Image = CType(resources.GetObject("tsb_OverviewClose.Image"), System.Drawing.Image)
        Me.tsb_OverviewClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_OverviewClose.Name = "tsb_OverviewClose"
        Me.tsb_OverviewClose.Size = New System.Drawing.Size(23, 22)
        Me.tsb_OverviewClose.Text = "Overview"
        Me.tsb_OverviewClose.ToolTipText = "Close Overview Tab"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsb_GetSystemDiscrepancies
        '
        Me.tsb_GetSystemDiscrepancies.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_GetSystemDiscrepancies.Image = CType(resources.GetObject("tsb_GetSystemDiscrepancies.Image"), System.Drawing.Image)
        Me.tsb_GetSystemDiscrepancies.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_GetSystemDiscrepancies.Name = "tsb_GetSystemDiscrepancies"
        Me.tsb_GetSystemDiscrepancies.Size = New System.Drawing.Size(23, 22)
        Me.tsb_GetSystemDiscrepancies.Text = "System Descrepencies"
        Me.tsb_GetSystemDiscrepancies.ToolTipText = "View Discpreancies"
        Me.tsb_GetSystemDiscrepancies.Visible = False
        '
        'tsb_GetSystemPunchlist
        '
        Me.tsb_GetSystemPunchlist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_GetSystemPunchlist.Image = CType(resources.GetObject("tsb_GetSystemPunchlist.Image"), System.Drawing.Image)
        Me.tsb_GetSystemPunchlist.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_GetSystemPunchlist.Name = "tsb_GetSystemPunchlist"
        Me.tsb_GetSystemPunchlist.Size = New System.Drawing.Size(23, 22)
        Me.tsb_GetSystemPunchlist.Text = "Punch List"
        Me.tsb_GetSystemPunchlist.ToolTipText = "View Punchlist"
        Me.tsb_GetSystemPunchlist.Visible = False
        '
        'tsb_PkgShortForm
        '
        Me.tsb_PkgShortForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_PkgShortForm.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintPkgShortFormToolStripMenuItem, Me.PrintSystemPackagesToolStripMenuItem})
        Me.tsb_PkgShortForm.Image = Global.Daqart.My.Resources.Resources.Clipboard_Configuration
        Me.tsb_PkgShortForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_PkgShortForm.Name = "tsb_PkgShortForm"
        Me.tsb_PkgShortForm.Size = New System.Drawing.Size(29, 22)
        Me.tsb_PkgShortForm.Text = "Print System"
        Me.tsb_PkgShortForm.Visible = False
        '
        'PrintPkgShortFormToolStripMenuItem
        '
        Me.PrintPkgShortFormToolStripMenuItem.Name = "PrintPkgShortFormToolStripMenuItem"
        Me.PrintPkgShortFormToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.PrintPkgShortFormToolStripMenuItem.Text = "Print Package Short Form"
        '
        'PrintSystemPackagesToolStripMenuItem
        '
        Me.PrintSystemPackagesToolStripMenuItem.Name = "PrintSystemPackagesToolStripMenuItem"
        Me.PrintSystemPackagesToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.PrintSystemPackagesToolStripMenuItem.Text = "Print System Packages"
        '
        'btn_EniExport
        '
        Me.btn_EniExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_EniExport.Image = CType(resources.GetObject("btn_EniExport.Image"), System.Drawing.Image)
        Me.btn_EniExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_EniExport.Name = "btn_EniExport"
        Me.btn_EniExport.Size = New System.Drawing.Size(63, 22)
        Me.btn_EniExport.Text = "eni Export"
        Me.btn_EniExport.Visible = False
        '
        'cmsMessages
        '
        Me.cmsMessages.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem1, Me.EditToolStripMenuItem1, Me.DeleteToolStripMenuItem1, Me.RefreshToolStripMenuItem1})
        Me.cmsMessages.Name = "ContextMenuStrip2"
        Me.cmsMessages.Size = New System.Drawing.Size(114, 92)
        '
        'NewToolStripMenuItem1
        '
        Me.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1"
        Me.NewToolStripMenuItem1.Size = New System.Drawing.Size(113, 22)
        Me.NewToolStripMenuItem1.Text = "New"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(113, 22)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'DeleteToolStripMenuItem1
        '
        Me.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1"
        Me.DeleteToolStripMenuItem1.Size = New System.Drawing.Size(113, 22)
        Me.DeleteToolStripMenuItem1.Text = "Delete"
        '
        'RefreshToolStripMenuItem1
        '
        Me.RefreshToolStripMenuItem1.Name = "RefreshToolStripMenuItem1"
        Me.RefreshToolStripMenuItem1.Size = New System.Drawing.Size(113, 22)
        Me.RefreshToolStripMenuItem1.Text = "Refresh"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.EditToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(114, 92)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_Message, Me.tsl_SiteLabel, Me.ProjectStatusInd})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 482)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(994, 24)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbl_Message
        '
        Me.lbl_Message.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Message.Name = "lbl_Message"
        Me.lbl_Message.Size = New System.Drawing.Size(738, 19)
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
        Me.tsl_SiteLabel.Size = New System.Drawing.Size(117, 19)
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
        Me.ProjectStatusInd.Size = New System.Drawing.Size(124, 19)
        Me.ProjectStatusInd.Text = "Project:  Not Selected"
        Me.ProjectStatusInd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SystemView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 506)
        Me.Controls.Add(Me.SystemWindow)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "SystemView"
        Me.Text = "SystemView"
        Me.SystemWindow.Panel1.ResumeLayout(False)
        Me.SystemWindow.Panel2.ResumeLayout(False)
        Me.SystemWindow.Panel2.PerformLayout()
        Me.SystemWindow.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SystemMenu.ResumeLayout(False)
        Me.SystemMenu.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.cmsMessages.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SystemWindow As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SystemTree As System.Windows.Forms.TreeView
    Friend WithEvents SystemMenu As System.Windows.Forms.Panel
    Friend WithEvents cbx_Owners As System.Windows.Forms.ComboBox
    Friend WithEvents btn_GetOverview As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbx_SystemNumber As System.Windows.Forms.TextBox
    Friend WithEvents tbc_Main As System.Windows.Forms.TabControl
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsb_RefreshOverview As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_PrintOverview As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsb_OverviewClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsb_GetSystemDiscrepancies As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_GetSystemPunchlist As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmsMessages As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tsb_PkgShortForm As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents PrintPkgShortFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintSystemPackagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbl_Message As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsl_SiteLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProjectStatusInd As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_ProjectITS As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_EniExport As System.Windows.Forms.ToolStripButton
End Class
