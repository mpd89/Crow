<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataManagerMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataManagerMain))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Company", 2, 2)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Discipline", 6, 6)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Groups")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Levels")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Owner")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("User")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Site", -2, -2, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Equipment Type")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Form Requirements")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sign-Off Configuration")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Project", -2, -2, New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9, TreeNode10})
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CMSNode = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CompanyToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DisciplineToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.LevelToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.OwnerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.UserToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EqRootCMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewEquipmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImportEquipmentTypesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReqRootCMs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewRequirementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbAddCompany = New System.Windows.Forms.ToolStripButton
        Me.tspAddDiscipline = New System.Windows.Forms.ToolStripButton
        Me.tspAddGroup = New System.Windows.Forms.ToolStripButton
        Me.tspAddLevel = New System.Windows.Forms.ToolStripButton
        Me.tspAddOwner = New System.Windows.Forms.ToolStripButton
        Me.tspAddUser = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.trvComplete = New System.Windows.Forms.TreeView
        Me.dgv_Data = New System.Windows.Forms.DataGridView
        Me.EquipmentCMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Edit = New System.Windows.Forms.ToolStripMenuItem
        Me.Delete = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReqCMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsl_SiteLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProjectStatusInd = New System.Windows.Forms.ToolStripStatusLabel
        Me.CMSSignOff = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddLevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteLevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.MoveUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MoveDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.ImportGroupsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CMSNode.SuspendLayout()
        Me.EqRootCMS.SuspendLayout()
        Me.ReqRootCMs.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EquipmentCMS.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ReqCMS.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.CMSSignOff.SuspendLayout()
        Me.SuspendLayout()
        '
        'CMSNode
        '
        Me.CMSNode.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem1, Me.RenameToolStripMenuItem, Me.ToolStripMenuItem1, Me.RefreshToolStripMenuItem, Me.PropertiesToolStripMenuItem})
        Me.CMSNode.Name = "CMSNode"
        Me.CMSNode.Size = New System.Drawing.Size(135, 114)
        '
        'DeleteToolStripMenuItem1
        '
        Me.DeleteToolStripMenuItem1.Enabled = False
        Me.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1"
        Me.DeleteToolStripMenuItem1.Size = New System.Drawing.Size(134, 22)
        Me.DeleteToolStripMenuItem1.Text = "Set inactive"
        Me.DeleteToolStripMenuItem1.Visible = False
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Enabled = False
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        Me.RenameToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompanyToolStripMenuItem1, Me.DisciplineToolStripMenuItem1, Me.GroupToolStripMenuItem1, Me.LevelToolStripMenuItem1, Me.OwnerToolStripMenuItem1, Me.UserToolStripMenuItem1})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(134, 22)
        Me.ToolStripMenuItem1.Text = "New"
        '
        'CompanyToolStripMenuItem1
        '
        Me.CompanyToolStripMenuItem1.Name = "CompanyToolStripMenuItem1"
        Me.CompanyToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.CompanyToolStripMenuItem1.Text = "Company"
        '
        'DisciplineToolStripMenuItem1
        '
        Me.DisciplineToolStripMenuItem1.Name = "DisciplineToolStripMenuItem1"
        Me.DisciplineToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.DisciplineToolStripMenuItem1.Text = "Discipline"
        '
        'GroupToolStripMenuItem1
        '
        Me.GroupToolStripMenuItem1.Name = "GroupToolStripMenuItem1"
        Me.GroupToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.GroupToolStripMenuItem1.Text = "Group"
        '
        'LevelToolStripMenuItem1
        '
        Me.LevelToolStripMenuItem1.Name = "LevelToolStripMenuItem1"
        Me.LevelToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.LevelToolStripMenuItem1.Text = "Level"
        '
        'OwnerToolStripMenuItem1
        '
        Me.OwnerToolStripMenuItem1.Name = "OwnerToolStripMenuItem1"
        Me.OwnerToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.OwnerToolStripMenuItem1.Text = "Owner"
        '
        'UserToolStripMenuItem1
        '
        Me.UserToolStripMenuItem1.Name = "UserToolStripMenuItem1"
        Me.UserToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.UserToolStripMenuItem1.Text = "User"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.PropertiesToolStripMenuItem.Text = "Properties"
        '
        'EqRootCMS
        '
        Me.EqRootCMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewEquipmentToolStripMenuItem, Me.ImportEquipmentTypesToolStripMenuItem})
        Me.EqRootCMS.Name = "ProjectCMS"
        Me.EqRootCMS.Size = New System.Drawing.Size(206, 48)
        '
        'NewEquipmentToolStripMenuItem
        '
        Me.NewEquipmentToolStripMenuItem.Name = "NewEquipmentToolStripMenuItem"
        Me.NewEquipmentToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.NewEquipmentToolStripMenuItem.Text = "New Equipment Type"
        '
        'ImportEquipmentTypesToolStripMenuItem
        '
        Me.ImportEquipmentTypesToolStripMenuItem.Name = "ImportEquipmentTypesToolStripMenuItem"
        Me.ImportEquipmentTypesToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ImportEquipmentTypesToolStripMenuItem.Text = "Import Equipment Types"
        '
        'ReqRootCMs
        '
        Me.ReqRootCMs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewRequirementToolStripMenuItem})
        Me.ReqRootCMs.Name = "ReqRootCMs"
        Me.ReqRootCMs.Size = New System.Drawing.Size(170, 26)
        '
        'NewRequirementToolStripMenuItem
        '
        Me.NewRequirementToolStripMenuItem.Name = "NewRequirementToolStripMenuItem"
        Me.NewRequirementToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.NewRequirementToolStripMenuItem.Text = "New Requirement"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAddCompany, Me.tspAddDiscipline, Me.tspAddGroup, Me.tspAddLevel, Me.tspAddOwner, Me.tspAddUser, Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(828, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbAddCompany
        '
        Me.tsbAddCompany.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAddCompany.Image = CType(resources.GetObject("tsbAddCompany.Image"), System.Drawing.Image)
        Me.tsbAddCompany.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddCompany.Name = "tsbAddCompany"
        Me.tsbAddCompany.Size = New System.Drawing.Size(23, 22)
        Me.tsbAddCompany.Text = "Company"
        '
        'tspAddDiscipline
        '
        Me.tspAddDiscipline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tspAddDiscipline.Image = CType(resources.GetObject("tspAddDiscipline.Image"), System.Drawing.Image)
        Me.tspAddDiscipline.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tspAddDiscipline.Name = "tspAddDiscipline"
        Me.tspAddDiscipline.Size = New System.Drawing.Size(23, 22)
        Me.tspAddDiscipline.Text = "Discipline"
        '
        'tspAddGroup
        '
        Me.tspAddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tspAddGroup.Image = CType(resources.GetObject("tspAddGroup.Image"), System.Drawing.Image)
        Me.tspAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tspAddGroup.Name = "tspAddGroup"
        Me.tspAddGroup.Size = New System.Drawing.Size(23, 22)
        Me.tspAddGroup.Text = "Group"
        '
        'tspAddLevel
        '
        Me.tspAddLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tspAddLevel.Image = Global.DataManager.My.Resources.Resources.Network_Security_Blue
        Me.tspAddLevel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tspAddLevel.Name = "tspAddLevel"
        Me.tspAddLevel.Size = New System.Drawing.Size(23, 22)
        Me.tspAddLevel.Text = "Level"
        '
        'tspAddOwner
        '
        Me.tspAddOwner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tspAddOwner.Image = CType(resources.GetObject("tspAddOwner.Image"), System.Drawing.Image)
        Me.tspAddOwner.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tspAddOwner.Name = "tspAddOwner"
        Me.tspAddOwner.Size = New System.Drawing.Size(23, 22)
        Me.tspAddOwner.Text = "Owner"
        '
        'tspAddUser
        '
        Me.tspAddUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tspAddUser.Image = CType(resources.GetObject("tspAddUser.Image"), System.Drawing.Image)
        Me.tspAddUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tspAddUser.Name = "tspAddUser"
        Me.tspAddUser.Size = New System.Drawing.Size(23, 22)
        Me.tspAddUser.Text = "User"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.DataManager.My.Resources.Resources.Refresh
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Refresh"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.trvComplete)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_Data)
        Me.SplitContainer1.Size = New System.Drawing.Size(828, 489)
        Me.SplitContainer1.SplitterDistance = 159
        Me.SplitContainer1.TabIndex = 1
        '
        'trvComplete
        '
        Me.trvComplete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvComplete.Location = New System.Drawing.Point(0, 0)
        Me.trvComplete.Name = "trvComplete"
        TreeNode1.ContextMenuStrip = Me.CMSNode
        TreeNode1.ImageIndex = 2
        TreeNode1.Name = "nodeCompany"
        TreeNode1.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode1.SelectedImageIndex = 2
        TreeNode1.Tag = "0"
        TreeNode1.Text = "Company"
        TreeNode2.ContextMenuStrip = Me.CMSNode
        TreeNode2.ImageIndex = 6
        TreeNode2.Name = "nodeDiscipline"
        TreeNode2.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode2.SelectedImageIndex = 6
        TreeNode2.Tag = "1"
        TreeNode2.Text = "Discipline"
        TreeNode3.ContextMenuStrip = Me.CMSNode
        TreeNode3.ImageIndex = 1
        TreeNode3.Name = "nodeGroup"
        TreeNode3.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode3.Tag = "2"
        TreeNode3.Text = "Groups"
        TreeNode4.ContextMenuStrip = Me.CMSNode
        TreeNode4.ImageIndex = 4
        TreeNode4.Name = "nodeLevel"
        TreeNode4.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode4.Tag = "3"
        TreeNode4.Text = "Levels"
        TreeNode5.ContextMenuStrip = Me.CMSNode
        TreeNode5.ImageIndex = 3
        TreeNode5.Name = "nodeOwner"
        TreeNode5.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode5.Tag = "4"
        TreeNode5.Text = "Owner"
        TreeNode6.ContextMenuStrip = Me.CMSNode
        TreeNode6.ImageIndex = 7
        TreeNode6.Name = "nodeUser"
        TreeNode6.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode6.Tag = "5"
        TreeNode6.Text = "User"
        TreeNode7.ContextMenuStrip = Me.CMSNode
        TreeNode7.ImageIndex = -2
        TreeNode7.Name = "ServerDB"
        TreeNode7.SelectedImageIndex = -2
        TreeNode7.Text = "Site"
        TreeNode8.ContextMenuStrip = Me.EqRootCMS
        TreeNode8.Name = "nodeEquipment"
        TreeNode8.Text = "Equipment Type"
        TreeNode9.Name = "nodeFormRequirements"
        TreeNode9.Text = "Form Requirements"
        TreeNode10.Name = "nodeSignOff"
        TreeNode10.Text = "Sign-Off Configuration"
        TreeNode11.ImageIndex = -2
        TreeNode11.Name = "ProjectDB"
        TreeNode11.SelectedImageIndex = -2
        TreeNode11.Text = "Project"
        Me.trvComplete.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode11})
        Me.trvComplete.Size = New System.Drawing.Size(159, 489)
        Me.trvComplete.TabIndex = 0
        '
        'dgv_Data
        '
        Me.dgv_Data.AllowUserToAddRows = False
        Me.dgv_Data.AllowUserToDeleteRows = False
        Me.dgv_Data.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Data.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Data.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Data.Location = New System.Drawing.Point(0, 0)
        Me.dgv_Data.Name = "dgv_Data"
        Me.dgv_Data.ReadOnly = True
        Me.dgv_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Data.Size = New System.Drawing.Size(665, 489)
        Me.dgv_Data.TabIndex = 0
        '
        'EquipmentCMS
        '
        Me.EquipmentCMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Edit, Me.Delete})
        Me.EquipmentCMS.Name = "EquipmentCMS"
        Me.EquipmentCMS.Size = New System.Drawing.Size(108, 48)
        '
        'Edit
        '
        Me.Edit.Name = "Edit"
        Me.Edit.Size = New System.Drawing.Size(107, 22)
        Me.Edit.Text = "Edit"
        '
        'Delete
        '
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(107, 22)
        Me.Delete.Text = "Delete"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Add.png")
        Me.ImageList1.Images.SetKeyName(1, "Group Workgroup 1.png")
        Me.ImageList1.Images.SetKeyName(2, "Home 3.png")
        Me.ImageList1.Images.SetKeyName(3, "Keys Blue.png")
        Me.ImageList1.Images.SetKeyName(4, "Network_Security_Blue.png")
        Me.ImageList1.Images.SetKeyName(5, "Refresh.png")
        Me.ImageList1.Images.SetKeyName(6, "Toolbox 1.png")
        Me.ImageList1.Images.SetKeyName(7, "User Business Male 2.png")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(828, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportGroupsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ReqCMS
        '
        Me.ReqCMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ReqCMS.Name = "ContextMenuStrip1"
        Me.ReqCMS.Size = New System.Drawing.Size(108, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsl_SiteLabel, Me.ProjectStatusInd})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 514)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(828, 24)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(572, 19)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
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
        'CMSSignOff
        '
        Me.CMSSignOff.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddLevelToolStripMenuItem, Me.EditToolStripMenuItem1, Me.DeleteLevelToolStripMenuItem, Me.ToolStripSeparator2, Me.MoveUpToolStripMenuItem, Me.MoveDownToolStripMenuItem})
        Me.CMSSignOff.Name = "CMSSignOff"
        Me.CMSSignOff.Size = New System.Drawing.Size(139, 120)
        '
        'AddLevelToolStripMenuItem
        '
        Me.AddLevelToolStripMenuItem.Name = "AddLevelToolStripMenuItem"
        Me.AddLevelToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.AddLevelToolStripMenuItem.Text = "Add Level"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(138, 22)
        Me.EditToolStripMenuItem1.Text = "Edit Level"
        '
        'DeleteLevelToolStripMenuItem
        '
        Me.DeleteLevelToolStripMenuItem.Name = "DeleteLevelToolStripMenuItem"
        Me.DeleteLevelToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.DeleteLevelToolStripMenuItem.Text = "Delete Level"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(135, 6)
        '
        'MoveUpToolStripMenuItem
        '
        Me.MoveUpToolStripMenuItem.Enabled = False
        Me.MoveUpToolStripMenuItem.Name = "MoveUpToolStripMenuItem"
        Me.MoveUpToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.MoveUpToolStripMenuItem.Text = "Move Up"
        '
        'MoveDownToolStripMenuItem
        '
        Me.MoveDownToolStripMenuItem.Enabled = False
        Me.MoveDownToolStripMenuItem.Name = "MoveDownToolStripMenuItem"
        Me.MoveDownToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.MoveDownToolStripMenuItem.Text = "Move Down"
        '
        'ImportGroupsToolStripMenuItem
        '
        Me.ImportGroupsToolStripMenuItem.Name = "ImportGroupsToolStripMenuItem"
        Me.ImportGroupsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ImportGroupsToolStripMenuItem.Text = "Import Groups"
        '
        'DataManagerMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 538)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "DataManagerMain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Management"
        Me.CMSNode.ResumeLayout(False)
        Me.EqRootCMS.ResumeLayout(False)
        Me.ReqRootCMs.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EquipmentCMS.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ReqCMS.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.CMSSignOff.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAddCompany As System.Windows.Forms.ToolStripButton
    Friend WithEvents tspAddDiscipline As System.Windows.Forms.ToolStripButton
    Friend WithEvents tspAddGroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents tspAddLevel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tspAddOwner As System.Windows.Forms.ToolStripButton
    Friend WithEvents tspAddUser As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents trvComplete As System.Windows.Forms.TreeView
    Friend WithEvents CMSNode As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompanyToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisciplineToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LevelToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OwnerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EqRootCMS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents dgv_Data As System.Windows.Forms.DataGridView
    Friend WithEvents EquipmentCMS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewEquipmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReqRootCMs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ReqCMS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewRequirementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMSSignOff As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents AddLevelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteLevelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MoveUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveDownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportEquipmentTypesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsl_SiteLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProjectStatusInd As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImportGroupsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
