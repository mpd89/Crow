<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PackageView
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PackageView))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tab_PkgGeneral = New System.Windows.Forms.TabPage()
        Me.ckbx_Audit = New System.Windows.Forms.CheckBox()
        Me.nud_Priority = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PkgMatrixTabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PkgMatrix = New System.Windows.Forms.DataGridView()
        Me.cms_TagGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpdateStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DisciplineID = New System.Windows.Forms.ComboBox()
        Me.GroupID = New System.Windows.Forms.ComboBox()
        Me.OwnerID = New System.Windows.Forms.ComboBox()
        Me.Description = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ShowSystem = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PkgNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PkgID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tab_PkgAux = New System.Windows.Forms.TabPage()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnUpdatePkgAuxVals = New System.Windows.Forms.Button()
        Me.PkgVGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tab_PkgDiscrepancy = New System.Windows.Forms.TabPage()
        Me.tab_PkgDocuments = New System.Windows.Forms.TabPage()
        Me.tbx_DocumentCount = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgv_PkgDocuments = New System.Windows.Forms.DataGridView()
        Me.tls_PkgDocuments = New System.Windows.Forms.ToolStrip()
        Me.tsb_DocumentAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsb_DocumentEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsb_DocumentDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsb_DocumentView = New System.Windows.Forms.ToolStripButton()
        Me.tab_RefDocs = New System.Windows.Forms.TabPage()
        Me.dgv_RefDocs = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_RefDocAdd = New System.Windows.Forms.ToolStripButton()
        Me.btn_RefDocEdit = New System.Windows.Forms.ToolStripButton()
        Me.btn_RefDocDelete = New System.Windows.Forms.ToolStripButton()
        Me.btn_RefDocView = New System.Windows.Forms.ToolStripButton()
        Me.tab_PkgPunchlist = New System.Windows.Forms.TabPage()
        Me.tab_PkgTags = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TagTree = New System.Windows.Forms.TreeView()
        Me.tab_TagAll = New System.Windows.Forms.TabControl()
        Me.tab_TagGeneralInfo = New System.Windows.Forms.TabPage()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tbx_TagType = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tbx_TagID = New System.Windows.Forms.TextBox()
        Me.tbx_TagDescription = New System.Windows.Forms.TextBox()
        Me.tbx_TagService = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbx_TagLineNumber = New System.Windows.Forms.TextBox()
        Me.tbx_TagPONumber = New System.Windows.Forms.TextBox()
        Me.tbx_TagSerial = New System.Windows.Forms.TextBox()
        Me.tbx_TagModel = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbx_TagManufacturer = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbx_TagPrefix = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbx_TagRemarks = New System.Windows.Forms.TextBox()
        Me.tab_TagAuxInfo = New System.Windows.Forms.TabPage()
        Me.btnUpdateTagAuxValue = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TagVGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbl_SelectedTag = New System.Windows.Forms.Label()
        Me.PackageRoot = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddDiscrepancyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TagRoot = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiscrepancyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PunchlistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.tab_PkgGeneral.SuspendLayout()
        CType(Me.nud_Priority, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PkgMatrixTabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PkgMatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_TagGrid.SuspendLayout()
        Me.tab_PkgAux.SuspendLayout()
        CType(Me.PkgVGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_PkgDocuments.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_PkgDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tls_PkgDocuments.SuspendLayout()
        Me.tab_RefDocs.SuspendLayout()
        CType(Me.dgv_RefDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.tab_PkgTags.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tab_TagAll.SuspendLayout()
        Me.tab_TagGeneralInfo.SuspendLayout()
        Me.tab_TagAuxInfo.SuspendLayout()
        CType(Me.TagVGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PackageRoot.SuspendLayout()
        Me.TagRoot.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab_PkgGeneral)
        Me.TabControl1.Controls.Add(Me.tab_PkgAux)
        Me.TabControl1.Controls.Add(Me.tab_PkgDiscrepancy)
        Me.TabControl1.Controls.Add(Me.tab_PkgDocuments)
        Me.TabControl1.Controls.Add(Me.tab_RefDocs)
        Me.TabControl1.Controls.Add(Me.tab_PkgPunchlist)
        Me.TabControl1.Controls.Add(Me.tab_PkgTags)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(691, 597)
        Me.TabControl1.TabIndex = 0
        '
        'tab_PkgGeneral
        '
        Me.tab_PkgGeneral.Controls.Add(Me.ckbx_Audit)
        Me.tab_PkgGeneral.Controls.Add(Me.nud_Priority)
        Me.tab_PkgGeneral.Controls.Add(Me.Label19)
        Me.tab_PkgGeneral.Controls.Add(Me.Panel1)
        Me.tab_PkgGeneral.Controls.Add(Me.Label8)
        Me.tab_PkgGeneral.Controls.Add(Me.Label7)
        Me.tab_PkgGeneral.Controls.Add(Me.Label6)
        Me.tab_PkgGeneral.Controls.Add(Me.DisciplineID)
        Me.tab_PkgGeneral.Controls.Add(Me.GroupID)
        Me.tab_PkgGeneral.Controls.Add(Me.OwnerID)
        Me.tab_PkgGeneral.Controls.Add(Me.Description)
        Me.tab_PkgGeneral.Controls.Add(Me.Label5)
        Me.tab_PkgGeneral.Controls.Add(Me.Button1)
        Me.tab_PkgGeneral.Controls.Add(Me.ShowSystem)
        Me.tab_PkgGeneral.Controls.Add(Me.Label4)
        Me.tab_PkgGeneral.Controls.Add(Me.PkgNumber)
        Me.tab_PkgGeneral.Controls.Add(Me.Label3)
        Me.tab_PkgGeneral.Controls.Add(Me.PkgID)
        Me.tab_PkgGeneral.Controls.Add(Me.Label1)
        Me.tab_PkgGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tab_PkgGeneral.Name = "tab_PkgGeneral"
        Me.tab_PkgGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_PkgGeneral.Size = New System.Drawing.Size(683, 571)
        Me.tab_PkgGeneral.TabIndex = 0
        Me.tab_PkgGeneral.Text = "General"
        Me.tab_PkgGeneral.UseVisualStyleBackColor = True
        '
        'ckbx_Audit
        '
        Me.ckbx_Audit.AutoSize = True
        Me.ckbx_Audit.Location = New System.Drawing.Point(431, 99)
        Me.ckbx_Audit.Name = "ckbx_Audit"
        Me.ckbx_Audit.Size = New System.Drawing.Size(188, 17)
        Me.ckbx_Audit.TabIndex = 18
        Me.ckbx_Audit.Text = "Package has required documents."
        Me.ckbx_Audit.UseVisualStyleBackColor = True
        '
        'nud_Priority
        '
        Me.nud_Priority.Location = New System.Drawing.Point(145, 99)
        Me.nud_Priority.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nud_Priority.Name = "nud_Priority"
        Me.nud_Priority.Size = New System.Drawing.Size(128, 20)
        Me.nud_Priority.TabIndex = 17
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(21, 106)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "Priority"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Panel1.Controls.Add(Me.PkgMatrixTabControl)
        Me.Panel1.Location = New System.Drawing.Point(24, 166)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(637, 383)
        Me.Panel1.TabIndex = 15
        '
        'PkgMatrixTabControl
        '
        Me.PkgMatrixTabControl.Controls.Add(Me.TabPage1)
        Me.PkgMatrixTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PkgMatrixTabControl.Location = New System.Drawing.Point(0, 0)
        Me.PkgMatrixTabControl.Name = "PkgMatrixTabControl"
        Me.PkgMatrixTabControl.SelectedIndex = 0
        Me.PkgMatrixTabControl.Size = New System.Drawing.Size(637, 383)
        Me.PkgMatrixTabControl.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PkgMatrix)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(629, 357)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Forms"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PkgMatrix
        '
        Me.PkgMatrix.AllowUserToAddRows = False
        Me.PkgMatrix.AllowUserToDeleteRows = False
        Me.PkgMatrix.AllowUserToOrderColumns = True
        Me.PkgMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PkgMatrix.ContextMenuStrip = Me.cms_TagGrid
        Me.PkgMatrix.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PkgMatrix.Location = New System.Drawing.Point(3, 3)
        Me.PkgMatrix.Name = "PkgMatrix"
        Me.PkgMatrix.ReadOnly = True
        Me.PkgMatrix.RowHeadersVisible = False
        Me.PkgMatrix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.PkgMatrix.Size = New System.Drawing.Size(623, 351)
        Me.PkgMatrix.TabIndex = 0
        '
        'cms_TagGrid
        '
        Me.cms_TagGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateStatusToolStripMenuItem})
        Me.cms_TagGrid.Name = "cms_TagGrid"
        Me.cms_TagGrid.Size = New System.Drawing.Size(148, 26)
        '
        'UpdateStatusToolStripMenuItem
        '
        Me.UpdateStatusToolStripMenuItem.Name = "UpdateStatusToolStripMenuItem"
        Me.UpdateStatusToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.UpdateStatusToolStripMenuItem.Text = "Update Status"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(373, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Discipline"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(373, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Group"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(373, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Owner"
        '
        'DisciplineID
        '
        Me.DisciplineID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DisciplineID.FormattingEnabled = True
        Me.DisciplineID.Location = New System.Drawing.Point(431, 65)
        Me.DisciplineID.Name = "DisciplineID"
        Me.DisciplineID.Size = New System.Drawing.Size(230, 21)
        Me.DisciplineID.TabIndex = 11
        '
        'GroupID
        '
        Me.GroupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GroupID.FormattingEnabled = True
        Me.GroupID.Location = New System.Drawing.Point(431, 38)
        Me.GroupID.Name = "GroupID"
        Me.GroupID.Size = New System.Drawing.Size(230, 21)
        Me.GroupID.TabIndex = 10
        '
        'OwnerID
        '
        Me.OwnerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OwnerID.FormattingEnabled = True
        Me.OwnerID.Location = New System.Drawing.Point(431, 11)
        Me.OwnerID.Name = "OwnerID"
        Me.OwnerID.Size = New System.Drawing.Size(230, 21)
        Me.OwnerID.TabIndex = 9
        '
        'Description
        '
        Me.Description.Location = New System.Drawing.Point(145, 126)
        Me.Description.MaxLength = 100
        Me.Description.Multiline = True
        Me.Description.Name = "Description"
        Me.Description.Size = New System.Drawing.Size(516, 34)
        Me.Description.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Description"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(273, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(38, 20)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = ". . ."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ShowSystem
        '
        Me.ShowSystem.Location = New System.Drawing.Point(145, 68)
        Me.ShowSystem.MaxLength = 50
        Me.ShowSystem.Name = "ShowSystem"
        Me.ShowSystem.ReadOnly = True
        Me.ShowSystem.Size = New System.Drawing.Size(128, 20)
        Me.ShowSystem.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "System"
        '
        'PkgNumber
        '
        Me.PkgNumber.Location = New System.Drawing.Point(145, 39)
        Me.PkgNumber.MaxLength = 50
        Me.PkgNumber.Name = "PkgNumber"
        Me.PkgNumber.Size = New System.Drawing.Size(128, 20)
        Me.PkgNumber.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Package#"
        '
        'PkgID
        '
        Me.PkgID.AutoSize = True
        Me.PkgID.Location = New System.Drawing.Point(142, 16)
        Me.PkgID.Name = "PkgID"
        Me.PkgID.Size = New System.Drawing.Size(35, 13)
        Me.PkgID.TabIndex = 1
        Me.PkgID.Text = "####"
        Me.PkgID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PackageID#"
        Me.Label1.Visible = False
        '
        'tab_PkgAux
        '
        Me.tab_PkgAux.AutoScroll = True
        Me.tab_PkgAux.Controls.Add(Me.Label20)
        Me.tab_PkgAux.Controls.Add(Me.Label21)
        Me.tab_PkgAux.Controls.Add(Me.btnUpdatePkgAuxVals)
        Me.tab_PkgAux.Controls.Add(Me.PkgVGridControl1)
        Me.tab_PkgAux.Controls.Add(Me.Label2)
        Me.tab_PkgAux.Location = New System.Drawing.Point(4, 22)
        Me.tab_PkgAux.Name = "tab_PkgAux"
        Me.tab_PkgAux.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_PkgAux.Size = New System.Drawing.Size(683, 571)
        Me.tab_PkgAux.TabIndex = 1
        Me.tab_PkgAux.Text = "Auxillary"
        Me.tab_PkgAux.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(394, 58)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "Values"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(180, 58)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(34, 13)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "Fields"
        '
        'btnUpdatePkgAuxVals
        '
        Me.btnUpdatePkgAuxVals.Enabled = False
        Me.btnUpdatePkgAuxVals.Location = New System.Drawing.Point(292, 10)
        Me.btnUpdatePkgAuxVals.Name = "btnUpdatePkgAuxVals"
        Me.btnUpdatePkgAuxVals.Size = New System.Drawing.Size(124, 23)
        Me.btnUpdatePkgAuxVals.TabIndex = 16
        Me.btnUpdatePkgAuxVals.Text = "Update Aux Values"
        Me.btnUpdatePkgAuxVals.UseVisualStyleBackColor = True
        '
        'PkgVGridControl1
        '
        Me.PkgVGridControl1.Location = New System.Drawing.Point(44, 74)
        Me.PkgVGridControl1.Name = "PkgVGridControl1"
        Me.PkgVGridControl1.Size = New System.Drawing.Size(607, 491)
        Me.PkgVGridControl1.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(221, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Package Auxillary Information:"
        '
        'tab_PkgDiscrepancy
        '
        Me.tab_PkgDiscrepancy.AutoScroll = True
        Me.tab_PkgDiscrepancy.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tab_PkgDiscrepancy.Location = New System.Drawing.Point(4, 22)
        Me.tab_PkgDiscrepancy.Name = "tab_PkgDiscrepancy"
        Me.tab_PkgDiscrepancy.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_PkgDiscrepancy.Size = New System.Drawing.Size(683, 571)
        Me.tab_PkgDiscrepancy.TabIndex = 5
        Me.tab_PkgDiscrepancy.Text = "Discrepancy List"
        Me.tab_PkgDiscrepancy.UseVisualStyleBackColor = True
        '
        'tab_PkgDocuments
        '
        Me.tab_PkgDocuments.Controls.Add(Me.tbx_DocumentCount)
        Me.tab_PkgDocuments.Controls.Add(Me.TextBox1)
        Me.tab_PkgDocuments.Controls.Add(Me.Panel2)
        Me.tab_PkgDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tab_PkgDocuments.Name = "tab_PkgDocuments"
        Me.tab_PkgDocuments.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_PkgDocuments.Size = New System.Drawing.Size(683, 571)
        Me.tab_PkgDocuments.TabIndex = 3
        Me.tab_PkgDocuments.Text = "Eng. Documents"
        Me.tab_PkgDocuments.UseVisualStyleBackColor = True
        '
        'tbx_DocumentCount
        '
        Me.tbx_DocumentCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_DocumentCount.Location = New System.Drawing.Point(107, 14)
        Me.tbx_DocumentCount.Name = "tbx_DocumentCount"
        Me.tbx_DocumentCount.Size = New System.Drawing.Size(92, 20)
        Me.tbx_DocumentCount.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(8, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Document Count"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgv_PkgDocuments)
        Me.Panel2.Controls.Add(Me.tls_PkgDocuments)
        Me.Panel2.Location = New System.Drawing.Point(8, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(667, 533)
        Me.Panel2.TabIndex = 2
        '
        'dgv_PkgDocuments
        '
        Me.dgv_PkgDocuments.AllowUserToAddRows = False
        Me.dgv_PkgDocuments.AllowUserToDeleteRows = False
        Me.dgv_PkgDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_PkgDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_PkgDocuments.Location = New System.Drawing.Point(0, 25)
        Me.dgv_PkgDocuments.Name = "dgv_PkgDocuments"
        Me.dgv_PkgDocuments.ReadOnly = True
        Me.dgv_PkgDocuments.RowHeadersWidth = 25
        Me.dgv_PkgDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_PkgDocuments.Size = New System.Drawing.Size(665, 506)
        Me.dgv_PkgDocuments.TabIndex = 1
        '
        'tls_PkgDocuments
        '
        Me.tls_PkgDocuments.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tls_PkgDocuments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_DocumentAdd, Me.tsb_DocumentEdit, Me.tsb_DocumentDelete, Me.tsb_DocumentView})
        Me.tls_PkgDocuments.Location = New System.Drawing.Point(0, 0)
        Me.tls_PkgDocuments.Name = "tls_PkgDocuments"
        Me.tls_PkgDocuments.Size = New System.Drawing.Size(665, 25)
        Me.tls_PkgDocuments.TabIndex = 3
        Me.tls_PkgDocuments.Text = "ToolStrip1"
        '
        'tsb_DocumentAdd
        '
        Me.tsb_DocumentAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_DocumentAdd.Image = CType(resources.GetObject("tsb_DocumentAdd.Image"), System.Drawing.Image)
        Me.tsb_DocumentAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_DocumentAdd.Name = "tsb_DocumentAdd"
        Me.tsb_DocumentAdd.Size = New System.Drawing.Size(23, 22)
        Me.tsb_DocumentAdd.Text = "ToolStripButton1"
        Me.tsb_DocumentAdd.ToolTipText = "Add Document"
        '
        'tsb_DocumentEdit
        '
        Me.tsb_DocumentEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_DocumentEdit.Enabled = False
        Me.tsb_DocumentEdit.Image = CType(resources.GetObject("tsb_DocumentEdit.Image"), System.Drawing.Image)
        Me.tsb_DocumentEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_DocumentEdit.Name = "tsb_DocumentEdit"
        Me.tsb_DocumentEdit.Size = New System.Drawing.Size(23, 22)
        Me.tsb_DocumentEdit.Text = "ToolStripButton2"
        Me.tsb_DocumentEdit.ToolTipText = "Edit Document"
        '
        'tsb_DocumentDelete
        '
        Me.tsb_DocumentDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_DocumentDelete.Enabled = False
        Me.tsb_DocumentDelete.Image = CType(resources.GetObject("tsb_DocumentDelete.Image"), System.Drawing.Image)
        Me.tsb_DocumentDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_DocumentDelete.Name = "tsb_DocumentDelete"
        Me.tsb_DocumentDelete.Size = New System.Drawing.Size(23, 22)
        Me.tsb_DocumentDelete.Text = "ToolStripButton3"
        Me.tsb_DocumentDelete.ToolTipText = "Delete Document"
        '
        'tsb_DocumentView
        '
        Me.tsb_DocumentView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_DocumentView.Enabled = False
        Me.tsb_DocumentView.Image = CType(resources.GetObject("tsb_DocumentView.Image"), System.Drawing.Image)
        Me.tsb_DocumentView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_DocumentView.Name = "tsb_DocumentView"
        Me.tsb_DocumentView.Size = New System.Drawing.Size(23, 22)
        Me.tsb_DocumentView.Text = "ToolStripButton4"
        Me.tsb_DocumentView.ToolTipText = "View Document"
        '
        'tab_RefDocs
        '
        Me.tab_RefDocs.Controls.Add(Me.dgv_RefDocs)
        Me.tab_RefDocs.Controls.Add(Me.ToolStrip1)
        Me.tab_RefDocs.Location = New System.Drawing.Point(4, 22)
        Me.tab_RefDocs.Name = "tab_RefDocs"
        Me.tab_RefDocs.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_RefDocs.Size = New System.Drawing.Size(683, 571)
        Me.tab_RefDocs.TabIndex = 6
        Me.tab_RefDocs.Text = "Ref Documents"
        Me.tab_RefDocs.UseVisualStyleBackColor = True
        '
        'dgv_RefDocs
        '
        Me.dgv_RefDocs.Location = New System.Drawing.Point(3, 28)
        Me.dgv_RefDocs.MainView = Me.GridView1
        Me.dgv_RefDocs.Name = "dgv_RefDocs"
        Me.dgv_RefDocs.Size = New System.Drawing.Size(677, 540)
        Me.dgv_RefDocs.TabIndex = 1
        Me.dgv_RefDocs.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView2})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.dgv_RefDocs
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.dgv_RefDocs
        Me.GridView2.Name = "GridView2"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_RefDocAdd, Me.btn_RefDocEdit, Me.btn_RefDocDelete, Me.btn_RefDocView})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(677, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "Add Reference Document"
        '
        'btn_RefDocAdd
        '
        Me.btn_RefDocAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_RefDocAdd.Image = CType(resources.GetObject("btn_RefDocAdd.Image"), System.Drawing.Image)
        Me.btn_RefDocAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_RefDocAdd.Name = "btn_RefDocAdd"
        Me.btn_RefDocAdd.Size = New System.Drawing.Size(23, 22)
        Me.btn_RefDocAdd.Text = "ToolStripButton1"
        '
        'btn_RefDocEdit
        '
        Me.btn_RefDocEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_RefDocEdit.Image = CType(resources.GetObject("btn_RefDocEdit.Image"), System.Drawing.Image)
        Me.btn_RefDocEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_RefDocEdit.Name = "btn_RefDocEdit"
        Me.btn_RefDocEdit.Size = New System.Drawing.Size(23, 22)
        Me.btn_RefDocEdit.Text = "Edit Reference Document"
        '
        'btn_RefDocDelete
        '
        Me.btn_RefDocDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_RefDocDelete.Image = CType(resources.GetObject("btn_RefDocDelete.Image"), System.Drawing.Image)
        Me.btn_RefDocDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_RefDocDelete.Name = "btn_RefDocDelete"
        Me.btn_RefDocDelete.Size = New System.Drawing.Size(23, 22)
        Me.btn_RefDocDelete.Text = "Delete Reference Document"
        '
        'btn_RefDocView
        '
        Me.btn_RefDocView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_RefDocView.Image = CType(resources.GetObject("btn_RefDocView.Image"), System.Drawing.Image)
        Me.btn_RefDocView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_RefDocView.Name = "btn_RefDocView"
        Me.btn_RefDocView.Size = New System.Drawing.Size(23, 22)
        Me.btn_RefDocView.Text = "View Reference Document"
        '
        'tab_PkgPunchlist
        '
        Me.tab_PkgPunchlist.Location = New System.Drawing.Point(4, 22)
        Me.tab_PkgPunchlist.Name = "tab_PkgPunchlist"
        Me.tab_PkgPunchlist.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_PkgPunchlist.Size = New System.Drawing.Size(683, 571)
        Me.tab_PkgPunchlist.TabIndex = 4
        Me.tab_PkgPunchlist.Text = "Punchlist"
        Me.tab_PkgPunchlist.UseVisualStyleBackColor = True
        '
        'tab_PkgTags
        '
        Me.tab_PkgTags.Controls.Add(Me.SplitContainer1)
        Me.tab_PkgTags.Location = New System.Drawing.Point(4, 22)
        Me.tab_PkgTags.Name = "tab_PkgTags"
        Me.tab_PkgTags.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_PkgTags.Size = New System.Drawing.Size(683, 571)
        Me.tab_PkgTags.TabIndex = 2
        Me.tab_PkgTags.Text = "Tags"
        Me.tab_PkgTags.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TagTree)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tab_TagAll)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lbl_SelectedTag)
        Me.SplitContainer1.Size = New System.Drawing.Size(677, 565)
        Me.SplitContainer1.SplitterDistance = 173
        Me.SplitContainer1.TabIndex = 0
        '
        'TagTree
        '
        Me.TagTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagTree.Location = New System.Drawing.Point(0, 0)
        Me.TagTree.Name = "TagTree"
        Me.TagTree.Size = New System.Drawing.Size(173, 565)
        Me.TagTree.TabIndex = 0
        '
        'tab_TagAll
        '
        Me.tab_TagAll.Controls.Add(Me.tab_TagGeneralInfo)
        Me.tab_TagAll.Controls.Add(Me.tab_TagAuxInfo)
        Me.tab_TagAll.Location = New System.Drawing.Point(23, 53)
        Me.tab_TagAll.Name = "tab_TagAll"
        Me.tab_TagAll.SelectedIndex = 0
        Me.tab_TagAll.Size = New System.Drawing.Size(452, 489)
        Me.tab_TagAll.TabIndex = 1
        '
        'tab_TagGeneralInfo
        '
        Me.tab_TagGeneralInfo.Controls.Add(Me.Label23)
        Me.tab_TagGeneralInfo.Controls.Add(Me.tbx_TagType)
        Me.tab_TagGeneralInfo.Controls.Add(Me.Button3)
        Me.tab_TagGeneralInfo.Controls.Add(Me.Button2)
        Me.tab_TagGeneralInfo.Controls.Add(Me.tbx_TagID)
        Me.tab_TagGeneralInfo.Controls.Add(Me.tbx_TagDescription)
        Me.tab_TagGeneralInfo.Controls.Add(Me.tbx_TagService)
        Me.tab_TagGeneralInfo.Controls.Add(Me.Label17)
        Me.tab_TagGeneralInfo.Controls.Add(Me.Label16)
        Me.tab_TagGeneralInfo.Controls.Add(Me.tbx_TagLineNumber)
        Me.tab_TagGeneralInfo.Controls.Add(Me.tbx_TagPONumber)
        Me.tab_TagGeneralInfo.Controls.Add(Me.tbx_TagSerial)
        Me.tab_TagGeneralInfo.Controls.Add(Me.tbx_TagModel)
        Me.tab_TagGeneralInfo.Controls.Add(Me.Label15)
        Me.tab_TagGeneralInfo.Controls.Add(Me.Label14)
        Me.tab_TagGeneralInfo.Controls.Add(Me.Label13)
        Me.tab_TagGeneralInfo.Controls.Add(Me.Label12)
        Me.tab_TagGeneralInfo.Controls.Add(Me.Label11)
        Me.tab_TagGeneralInfo.Controls.Add(Me.tbx_TagManufacturer)
        Me.tab_TagGeneralInfo.Controls.Add(Me.Label10)
        Me.tab_TagGeneralInfo.Controls.Add(Me.tbx_TagPrefix)
        Me.tab_TagGeneralInfo.Controls.Add(Me.Label9)
        Me.tab_TagGeneralInfo.Controls.Add(Me.tbx_TagRemarks)
        Me.tab_TagGeneralInfo.Location = New System.Drawing.Point(4, 22)
        Me.tab_TagGeneralInfo.Name = "tab_TagGeneralInfo"
        Me.tab_TagGeneralInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_TagGeneralInfo.Size = New System.Drawing.Size(444, 463)
        Me.tab_TagGeneralInfo.TabIndex = 0
        Me.tab_TagGeneralInfo.Text = "Engineering Data"
        Me.tab_TagGeneralInfo.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(277, 23)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(31, 13)
        Me.Label23.TabIndex = 20
        Me.Label23.Text = "Type"
        '
        'tbx_TagType
        '
        Me.tbx_TagType.Location = New System.Drawing.Point(314, 16)
        Me.tbx_TagType.Name = "tbx_TagType"
        Me.tbx_TagType.ReadOnly = True
        Me.tbx_TagType.Size = New System.Drawing.Size(100, 20)
        Me.tbx_TagType.TabIndex = 19
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(246, 434)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(339, 434)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Update"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tbx_TagID
        '
        Me.tbx_TagID.Location = New System.Drawing.Point(0, 0)
        Me.tbx_TagID.Name = "tbx_TagID"
        Me.tbx_TagID.Size = New System.Drawing.Size(29, 20)
        Me.tbx_TagID.TabIndex = 18
        Me.tbx_TagID.Visible = False
        '
        'tbx_TagDescription
        '
        Me.tbx_TagDescription.Location = New System.Drawing.Point(121, 86)
        Me.tbx_TagDescription.Name = "tbx_TagDescription"
        Me.tbx_TagDescription.Size = New System.Drawing.Size(293, 20)
        Me.tbx_TagDescription.TabIndex = 3
        '
        'tbx_TagService
        '
        Me.tbx_TagService.Location = New System.Drawing.Point(121, 51)
        Me.tbx_TagService.Name = "tbx_TagService"
        Me.tbx_TagService.Size = New System.Drawing.Size(293, 20)
        Me.tbx_TagService.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(37, 93)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Description"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(37, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Service"
        '
        'tbx_TagLineNumber
        '
        Me.tbx_TagLineNumber.Location = New System.Drawing.Point(121, 258)
        Me.tbx_TagLineNumber.MaxLength = 100
        Me.tbx_TagLineNumber.Name = "tbx_TagLineNumber"
        Me.tbx_TagLineNumber.Size = New System.Drawing.Size(293, 20)
        Me.tbx_TagLineNumber.TabIndex = 8
        '
        'tbx_TagPONumber
        '
        Me.tbx_TagPONumber.Location = New System.Drawing.Point(121, 224)
        Me.tbx_TagPONumber.MaxLength = 100
        Me.tbx_TagPONumber.Name = "tbx_TagPONumber"
        Me.tbx_TagPONumber.Size = New System.Drawing.Size(293, 20)
        Me.tbx_TagPONumber.TabIndex = 7
        '
        'tbx_TagSerial
        '
        Me.tbx_TagSerial.Location = New System.Drawing.Point(121, 190)
        Me.tbx_TagSerial.MaxLength = 100
        Me.tbx_TagSerial.Name = "tbx_TagSerial"
        Me.tbx_TagSerial.Size = New System.Drawing.Size(293, 20)
        Me.tbx_TagSerial.TabIndex = 6
        '
        'tbx_TagModel
        '
        Me.tbx_TagModel.Location = New System.Drawing.Point(121, 156)
        Me.tbx_TagModel.MaxLength = 100
        Me.tbx_TagModel.Name = "tbx_TagModel"
        Me.tbx_TagModel.Size = New System.Drawing.Size(293, 20)
        Me.tbx_TagModel.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(37, 265)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Line Number"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(37, 231)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "P.O. Number"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(37, 197)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Serial Number"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(37, 163)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Model Number"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(37, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Manufacturer"
        '
        'tbx_TagManufacturer
        '
        Me.tbx_TagManufacturer.Location = New System.Drawing.Point(121, 122)
        Me.tbx_TagManufacturer.MaxLength = 100
        Me.tbx_TagManufacturer.Name = "tbx_TagManufacturer"
        Me.tbx_TagManufacturer.Size = New System.Drawing.Size(293, 20)
        Me.tbx_TagManufacturer.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Prefix"
        '
        'tbx_TagPrefix
        '
        Me.tbx_TagPrefix.Location = New System.Drawing.Point(121, 16)
        Me.tbx_TagPrefix.MaxLength = 10
        Me.tbx_TagPrefix.Name = "tbx_TagPrefix"
        Me.tbx_TagPrefix.Size = New System.Drawing.Size(72, 20)
        Me.tbx_TagPrefix.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 299)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Remarks"
        '
        'tbx_TagRemarks
        '
        Me.tbx_TagRemarks.Location = New System.Drawing.Point(121, 292)
        Me.tbx_TagRemarks.MaxLength = 255
        Me.tbx_TagRemarks.Multiline = True
        Me.tbx_TagRemarks.Name = "tbx_TagRemarks"
        Me.tbx_TagRemarks.Size = New System.Drawing.Size(293, 111)
        Me.tbx_TagRemarks.TabIndex = 9
        '
        'tab_TagAuxInfo
        '
        Me.tab_TagAuxInfo.AutoScroll = True
        Me.tab_TagAuxInfo.Controls.Add(Me.btnUpdateTagAuxValue)
        Me.tab_TagAuxInfo.Controls.Add(Me.Label26)
        Me.tab_TagAuxInfo.Controls.Add(Me.Label27)
        Me.tab_TagAuxInfo.Controls.Add(Me.TagVGridControl1)
        Me.tab_TagAuxInfo.Controls.Add(Me.Label18)
        Me.tab_TagAuxInfo.Location = New System.Drawing.Point(4, 22)
        Me.tab_TagAuxInfo.Name = "tab_TagAuxInfo"
        Me.tab_TagAuxInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_TagAuxInfo.Size = New System.Drawing.Size(444, 463)
        Me.tab_TagAuxInfo.TabIndex = 1
        Me.tab_TagAuxInfo.Text = "Auxillary Info"
        Me.tab_TagAuxInfo.UseVisualStyleBackColor = True
        '
        'btnUpdateTagAuxValue
        '
        Me.btnUpdateTagAuxValue.Enabled = False
        Me.btnUpdateTagAuxValue.Location = New System.Drawing.Point(305, 6)
        Me.btnUpdateTagAuxValue.Name = "btnUpdateTagAuxValue"
        Me.btnUpdateTagAuxValue.Size = New System.Drawing.Size(124, 23)
        Me.btnUpdateTagAuxValue.TabIndex = 21
        Me.btnUpdateTagAuxValue.Text = "Update Aux Values"
        Me.btnUpdateTagAuxValue.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(263, 39)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(39, 13)
        Me.Label26.TabIndex = 20
        Me.Label26.Text = "Values"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(71, 39)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 19
        Me.Label27.Text = "Fields"
        '
        'TagVGridControl1
        '
        Me.TagVGridControl1.Location = New System.Drawing.Point(15, 55)
        Me.TagVGridControl1.Name = "TagVGridControl1"
        Me.TagVGridControl1.Size = New System.Drawing.Size(414, 408)
        Me.TagVGridControl1.TabIndex = 16
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(125, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Tag Auxillary Information:"
        '
        'lbl_SelectedTag
        '
        Me.lbl_SelectedTag.AutoSize = True
        Me.lbl_SelectedTag.Location = New System.Drawing.Point(20, 24)
        Me.lbl_SelectedTag.Name = "lbl_SelectedTag"
        Me.lbl_SelectedTag.Size = New System.Drawing.Size(90, 13)
        Me.lbl_SelectedTag.TabIndex = 0
        Me.lbl_SelectedTag.Text = "Tag: not selected"
        '
        'PackageRoot
        '
        Me.PackageRoot.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripSeparator1, Me.AddDiscrepancyToolStripMenuItem})
        Me.PackageRoot.Name = "PackageRoot"
        Me.PackageRoot.Size = New System.Drawing.Size(164, 76)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(163, 22)
        Me.ToolStripMenuItem1.Text = "Add New Tag"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(163, 22)
        Me.ToolStripMenuItem2.Text = "Add Existing Tag"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(160, 6)
        '
        'AddDiscrepancyToolStripMenuItem
        '
        Me.AddDiscrepancyToolStripMenuItem.Name = "AddDiscrepancyToolStripMenuItem"
        Me.AddDiscrepancyToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.AddDiscrepancyToolStripMenuItem.Text = "Add Discrepancy"
        '
        'TagRoot
        '
        Me.TagRoot.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator2, Me.AddDocumentToolStripMenuItem})
        Me.TagRoot.Name = "TagRoot"
        Me.TagRoot.Size = New System.Drawing.Size(108, 76)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(104, 6)
        '
        'AddDocumentToolStripMenuItem
        '
        Me.AddDocumentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiscrepancyToolStripMenuItem, Me.DocumentToolStripMenuItem, Me.PunchlistToolStripMenuItem})
        Me.AddDocumentToolStripMenuItem.Name = "AddDocumentToolStripMenuItem"
        Me.AddDocumentToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AddDocumentToolStripMenuItem.Text = "Add"
        '
        'DiscrepancyToolStripMenuItem
        '
        Me.DiscrepancyToolStripMenuItem.Name = "DiscrepancyToolStripMenuItem"
        Me.DiscrepancyToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.DiscrepancyToolStripMenuItem.Text = "Discrepancy"
        '
        'DocumentToolStripMenuItem
        '
        Me.DocumentToolStripMenuItem.Name = "DocumentToolStripMenuItem"
        Me.DocumentToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.DocumentToolStripMenuItem.Text = "Document"
        '
        'PunchlistToolStripMenuItem
        '
        Me.PunchlistToolStripMenuItem.Name = "PunchlistToolStripMenuItem"
        Me.PunchlistToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.PunchlistToolStripMenuItem.Text = "Punchlist"
        '
        'PackageView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 597)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PackageView"
        Me.Text = "Package Not Defined!!"
        Me.TabControl1.ResumeLayout(False)
        Me.tab_PkgGeneral.ResumeLayout(False)
        Me.tab_PkgGeneral.PerformLayout()
        CType(Me.nud_Priority, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PkgMatrixTabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.PkgMatrix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_TagGrid.ResumeLayout(False)
        Me.tab_PkgAux.ResumeLayout(False)
        Me.tab_PkgAux.PerformLayout()
        CType(Me.PkgVGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_PkgDocuments.ResumeLayout(False)
        Me.tab_PkgDocuments.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgv_PkgDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tls_PkgDocuments.ResumeLayout(False)
        Me.tls_PkgDocuments.PerformLayout()
        Me.tab_RefDocs.ResumeLayout(False)
        Me.tab_RefDocs.PerformLayout()
        CType(Me.dgv_RefDocs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tab_PkgTags.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tab_TagAll.ResumeLayout(False)
        Me.tab_TagGeneralInfo.ResumeLayout(False)
        Me.tab_TagGeneralInfo.PerformLayout()
        Me.tab_TagAuxInfo.ResumeLayout(False)
        Me.tab_TagAuxInfo.PerformLayout()
        CType(Me.TagVGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PackageRoot.ResumeLayout(False)
        Me.TagRoot.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tab_PkgGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tab_PkgAux As System.Windows.Forms.TabPage
    Friend WithEvents tab_PkgTags As System.Windows.Forms.TabPage
    Friend WithEvents PkgNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PkgID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Description As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DisciplineID As System.Windows.Forms.ComboBox
    Friend WithEvents GroupID As System.Windows.Forms.ComboBox
    Friend WithEvents OwnerID As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TagTree As System.Windows.Forms.TreeView
    Friend WithEvents PackageRoot As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AddDiscrepancyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TagRoot As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AddDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiscrepancyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PunchlistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    'Friend WithEvents GridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    'Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents tab_TagAll As System.Windows.Forms.TabControl
    Friend WithEvents tab_TagGeneralInfo As System.Windows.Forms.TabPage
    Friend WithEvents tab_TagAuxInfo As System.Windows.Forms.TabPage
    Friend WithEvents lbl_SelectedTag As System.Windows.Forms.Label
    Friend WithEvents tbx_TagPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbx_TagRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbx_TagManufacturer As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbx_TagPONumber As System.Windows.Forms.TextBox
    Friend WithEvents tbx_TagSerial As System.Windows.Forms.TextBox
    Friend WithEvents tbx_TagModel As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbx_TagLineNumber As System.Windows.Forms.TextBox
    Friend WithEvents tbx_TagDescription As System.Windows.Forms.TextBox
    Friend WithEvents tbx_TagService As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbx_TagID As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tab_PkgDocuments As System.Windows.Forms.TabPage
    Friend WithEvents tab_PkgPunchlist As System.Windows.Forms.TabPage
    Friend WithEvents tab_PkgDiscrepancy As System.Windows.Forms.TabPage
    Friend WithEvents dgv_PkgDocuments As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tbx_DocumentCount As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents tls_PkgDocuments As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_DocumentAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_DocumentEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_DocumentDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_DocumentView As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbx_TagType As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents PkgVGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents btnUpdatePkgAuxVals As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TagVGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents btnUpdateTagAuxValue As System.Windows.Forms.Button
    Public WithEvents ShowSystem As System.Windows.Forms.TextBox
    Friend WithEvents PkgMatrixTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PkgMatrix As System.Windows.Forms.DataGridView
    Friend WithEvents tab_RefDocs As System.Windows.Forms.TabPage
    Friend WithEvents dgv_RefDocs As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_RefDocAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_RefDocEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_RefDocDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_RefDocView As System.Windows.Forms.ToolStripButton
    Friend WithEvents cms_TagGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UpdateStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents nud_Priority As System.Windows.Forms.NumericUpDown
    Friend WithEvents ckbx_Audit As System.Windows.Forms.CheckBox
End Class
