<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _SystemOverview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(_SystemOverview))
        Me.tbp_Discrepancies = New System.Windows.Forms.TabPage
        Me.pnl_Discrepancies = New System.Windows.Forms.Panel
        Me.dgv_Discrepancies = New DevExpress.XtraGrid.GridControl
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip
        Me.btn_ListDiscrpancies = New System.Windows.Forms.ToolStripButton
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.dgv_PackageData = New DevExpress.XtraGrid.GridControl
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.tbp_Punchlist = New System.Windows.Forms.TabPage
        Me.pnl_Punchlist = New System.Windows.Forms.Panel
        Me.dgv_Punchlist = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_ListPunchlist = New System.Windows.Forms.ToolStripButton
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.dgv_Documents = New DevExpress.XtraGrid.GridControl
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.tbp_Documents = New System.Windows.Forms.TabPage
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.tsp_DocumentAdd = New System.Windows.Forms.ToolStripButton
        Me.tsp_DocumentEdit = New System.Windows.Forms.ToolStripButton
        Me.tsp_DocumentDelete = New System.Windows.Forms.ToolStripButton
        Me.tsp_DocumentView = New System.Windows.Forms.ToolStripButton
        Me.tbp_SystemMain = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btn_ITS = New System.Windows.Forms.Button
        Me.btn_PrintOverview = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbx_AllPackages = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbx_Owner = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbx_PackageRemaining = New System.Windows.Forms.TextBox
        Me.tbx_PackageComplete = New System.Windows.Forms.TextBox
        Me.tbx_PackageCount = New System.Windows.Forms.TextBox
        Me.txtPcntComplete = New System.Windows.Forms.TextBox
        Me.txtReqdMhrs = New System.Windows.Forms.TextBox
        Me.txtEarnedMhrs = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbx_Description2 = New System.Windows.Forms.TextBox
        Me.tbx_SystemID2 = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.btn_PunchlistExport = New System.Windows.Forms.ToolStripButton
        Me.tbp_Discrepancies.SuspendLayout()
        Me.pnl_Discrepancies.SuspendLayout()
        CType(Me.dgv_Discrepancies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_PackageData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp_Punchlist.SuspendLayout()
        Me.pnl_Punchlist.SuspendLayout()
        CType(Me.dgv_Punchlist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Documents, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp_Documents.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.tbp_SystemMain.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbp_Discrepancies
        '
        Me.tbp_Discrepancies.Controls.Add(Me.pnl_Discrepancies)
        Me.tbp_Discrepancies.Controls.Add(Me.ToolStrip3)
        Me.tbp_Discrepancies.Location = New System.Drawing.Point(4, 22)
        Me.tbp_Discrepancies.Name = "tbp_Discrepancies"
        Me.tbp_Discrepancies.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_Discrepancies.Size = New System.Drawing.Size(928, 604)
        Me.tbp_Discrepancies.TabIndex = 4
        Me.tbp_Discrepancies.Text = "Discrepancies"
        Me.tbp_Discrepancies.UseVisualStyleBackColor = True
        '
        'pnl_Discrepancies
        '
        Me.pnl_Discrepancies.AutoScroll = True
        Me.pnl_Discrepancies.Controls.Add(Me.dgv_Discrepancies)
        Me.pnl_Discrepancies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Discrepancies.Location = New System.Drawing.Point(3, 28)
        Me.pnl_Discrepancies.Name = "pnl_Discrepancies"
        Me.pnl_Discrepancies.Size = New System.Drawing.Size(922, 573)
        Me.pnl_Discrepancies.TabIndex = 2
        '
        'dgv_Discrepancies
        '
        Me.dgv_Discrepancies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Discrepancies.EmbeddedNavigator.Name = ""
        Me.dgv_Discrepancies.Location = New System.Drawing.Point(0, 0)
        Me.dgv_Discrepancies.MainView = Me.GridView4
        Me.dgv_Discrepancies.Name = "dgv_Discrepancies"
        Me.dgv_Discrepancies.Size = New System.Drawing.Size(922, 573)
        Me.dgv_Discrepancies.TabIndex = 2
        Me.dgv_Discrepancies.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.dgv_Discrepancies
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.Editable = False
        Me.GridView4.OptionsCustomization.AllowGroup = False
        Me.GridView4.OptionsView.ColumnAutoWidth = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'ToolStrip3
        '
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_ListDiscrpancies})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(922, 25)
        Me.ToolStrip3.TabIndex = 1
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'btn_ListDiscrpancies
        '
        Me.btn_ListDiscrpancies.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ListDiscrpancies.Image = Global.Daqart.My.Resources.Resources.Table
        Me.btn_ListDiscrpancies.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ListDiscrpancies.Name = "btn_ListDiscrpancies"
        Me.btn_ListDiscrpancies.Size = New System.Drawing.Size(23, 22)
        Me.btn_ListDiscrpancies.Text = "List Discrepancies"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.dgv_PackageData
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'dgv_PackageData
        '
        Me.dgv_PackageData.BackgroundImage = Global.Daqart.My.Resources.Resources.Printer_Laser
        Me.dgv_PackageData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.dgv_PackageData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_PackageData.EmbeddedNavigator.Name = ""
        Me.dgv_PackageData.Location = New System.Drawing.Point(0, 0)
        Me.dgv_PackageData.MainView = Me.GridView1
        Me.dgv_PackageData.Name = "dgv_PackageData"
        Me.dgv_PackageData.Size = New System.Drawing.Size(922, 369)
        Me.dgv_PackageData.TabIndex = 0
        Me.dgv_PackageData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView6})
        '
        'GridView6
        '
        Me.GridView6.GridControl = Me.dgv_PackageData
        Me.GridView6.Name = "GridView6"
        '
        'tbp_Punchlist
        '
        Me.tbp_Punchlist.Controls.Add(Me.pnl_Punchlist)
        Me.tbp_Punchlist.Controls.Add(Me.ToolStrip1)
        Me.tbp_Punchlist.Location = New System.Drawing.Point(4, 22)
        Me.tbp_Punchlist.Name = "tbp_Punchlist"
        Me.tbp_Punchlist.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_Punchlist.Size = New System.Drawing.Size(928, 604)
        Me.tbp_Punchlist.TabIndex = 3
        Me.tbp_Punchlist.Text = "Punchlist"
        Me.tbp_Punchlist.UseVisualStyleBackColor = True
        '
        'pnl_Punchlist
        '
        Me.pnl_Punchlist.AutoScroll = True
        Me.pnl_Punchlist.Controls.Add(Me.dgv_Punchlist)
        Me.pnl_Punchlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Punchlist.Location = New System.Drawing.Point(3, 28)
        Me.pnl_Punchlist.Name = "pnl_Punchlist"
        Me.pnl_Punchlist.Size = New System.Drawing.Size(922, 573)
        Me.pnl_Punchlist.TabIndex = 1
        '
        'dgv_Punchlist
        '
        Me.dgv_Punchlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Punchlist.EmbeddedNavigator.Name = ""
        Me.dgv_Punchlist.Location = New System.Drawing.Point(0, 0)
        Me.dgv_Punchlist.MainView = Me.GridView3
        Me.dgv_Punchlist.Name = "dgv_Punchlist"
        Me.dgv_Punchlist.Size = New System.Drawing.Size(922, 573)
        Me.dgv_Punchlist.TabIndex = 2
        Me.dgv_Punchlist.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView3.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView3.GridControl = Me.dgv_Punchlist
        Me.GridView3.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsCustomization.AllowGroup = False
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_ListPunchlist, Me.btn_PunchlistExport})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(922, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_ListPunchlist
        '
        Me.btn_ListPunchlist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ListPunchlist.Image = Global.Daqart.My.Resources.Resources.Table
        Me.btn_ListPunchlist.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ListPunchlist.Name = "btn_ListPunchlist"
        Me.btn_ListPunchlist.Size = New System.Drawing.Size(23, 22)
        Me.btn_ListPunchlist.Text = "Punchlist details"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.dgv_Documents
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsCustomization.AllowGroup = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'dgv_Documents
        '
        Me.dgv_Documents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Documents.EmbeddedNavigator.Name = ""
        Me.dgv_Documents.Location = New System.Drawing.Point(3, 28)
        Me.dgv_Documents.MainView = Me.GridView2
        Me.dgv_Documents.Name = "dgv_Documents"
        Me.dgv_Documents.Size = New System.Drawing.Size(922, 573)
        Me.dgv_Documents.TabIndex = 1
        Me.dgv_Documents.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2, Me.GridView5})
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.dgv_Documents
        Me.GridView5.Name = "GridView5"
        '
        'tbp_Documents
        '
        Me.tbp_Documents.Controls.Add(Me.dgv_Documents)
        Me.tbp_Documents.Controls.Add(Me.ToolStrip2)
        Me.tbp_Documents.Location = New System.Drawing.Point(4, 22)
        Me.tbp_Documents.Name = "tbp_Documents"
        Me.tbp_Documents.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_Documents.Size = New System.Drawing.Size(928, 604)
        Me.tbp_Documents.TabIndex = 2
        Me.tbp_Documents.Text = "Documents"
        Me.tbp_Documents.UseVisualStyleBackColor = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsp_DocumentAdd, Me.tsp_DocumentEdit, Me.tsp_DocumentDelete, Me.tsp_DocumentView})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(922, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsp_DocumentAdd
        '
        Me.tsp_DocumentAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsp_DocumentAdd.Image = Global.Daqart.My.Resources.Resources.Document_1_Add
        Me.tsp_DocumentAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsp_DocumentAdd.Name = "tsp_DocumentAdd"
        Me.tsp_DocumentAdd.Size = New System.Drawing.Size(23, 22)
        Me.tsp_DocumentAdd.Text = "ToolStripButton1"
        '
        'tsp_DocumentEdit
        '
        Me.tsp_DocumentEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsp_DocumentEdit.Enabled = False
        Me.tsp_DocumentEdit.Image = Global.Daqart.My.Resources.Resources.Document_1_Edit
        Me.tsp_DocumentEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsp_DocumentEdit.Name = "tsp_DocumentEdit"
        Me.tsp_DocumentEdit.Size = New System.Drawing.Size(23, 22)
        Me.tsp_DocumentEdit.Text = "ToolStripButton2"
        '
        'tsp_DocumentDelete
        '
        Me.tsp_DocumentDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsp_DocumentDelete.Enabled = False
        Me.tsp_DocumentDelete.Image = Global.Daqart.My.Resources.Resources.Document_1_Delete
        Me.tsp_DocumentDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsp_DocumentDelete.Name = "tsp_DocumentDelete"
        Me.tsp_DocumentDelete.Size = New System.Drawing.Size(23, 22)
        Me.tsp_DocumentDelete.Text = "ToolStripButton3"
        '
        'tsp_DocumentView
        '
        Me.tsp_DocumentView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsp_DocumentView.Enabled = False
        Me.tsp_DocumentView.Image = Global.Daqart.My.Resources.Resources.Document_1_Search
        Me.tsp_DocumentView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsp_DocumentView.Name = "tsp_DocumentView"
        Me.tsp_DocumentView.Size = New System.Drawing.Size(23, 22)
        Me.tsp_DocumentView.Text = "ToolStripButton4"
        '
        'tbp_SystemMain
        '
        Me.tbp_SystemMain.Controls.Add(Me.SplitContainer1)
        Me.tbp_SystemMain.Location = New System.Drawing.Point(4, 22)
        Me.tbp_SystemMain.Name = "tbp_SystemMain"
        Me.tbp_SystemMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_SystemMain.Size = New System.Drawing.Size(928, 604)
        Me.tbp_SystemMain.TabIndex = 0
        Me.tbp_SystemMain.Text = "System Main"
        Me.tbp_SystemMain.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.SplitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_ITS)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_PrintOverview)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbx_AllPackages)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbx_Owner)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_PackageRemaining)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_PackageComplete)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_PackageCount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPcntComplete)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtReqdMhrs)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtEarnedMhrs)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_Description2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_SystemID2)
        Me.SplitContainer1.Panel1MinSize = 225
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_PackageData)
        Me.SplitContainer1.Size = New System.Drawing.Size(922, 598)
        Me.SplitContainer1.SplitterDistance = 225
        Me.SplitContainer1.TabIndex = 0
        '
        'btn_ITS
        '
        Me.btn_ITS.Location = New System.Drawing.Point(505, 106)
        Me.btn_ITS.Name = "btn_ITS"
        Me.btn_ITS.Size = New System.Drawing.Size(91, 23)
        Me.btn_ITS.TabIndex = 39
        Me.btn_ITS.Text = "Generate ITS"
        Me.btn_ITS.UseVisualStyleBackColor = True
        '
        'btn_PrintOverview
        '
        Me.btn_PrintOverview.Location = New System.Drawing.Point(505, 78)
        Me.btn_PrintOverview.Name = "btn_PrintOverview"
        Me.btn_PrintOverview.Size = New System.Drawing.Size(91, 22)
        Me.btn_PrintOverview.TabIndex = 13
        Me.btn_PrintOverview.Text = "Print Overview"
        Me.btn_PrintOverview.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(413, 161)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Percent Complete"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(346, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Owner"
        '
        'cbx_AllPackages
        '
        Me.cbx_AllPackages.AutoSize = True
        Me.cbx_AllPackages.Location = New System.Drawing.Point(349, 55)
        Me.cbx_AllPackages.Name = "cbx_AllPackages"
        Me.cbx_AllPackages.Size = New System.Drawing.Size(181, 17)
        Me.cbx_AllPackages.TabIndex = 12
        Me.cbx_AllPackages.Text = "Show all packages for all owners"
        Me.cbx_AllPackages.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(424, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Remaining"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(220, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Completed"
        '
        'cbx_Owner
        '
        Me.cbx_Owner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Owner.FormattingEnabled = True
        Me.cbx_Owner.Location = New System.Drawing.Point(349, 26)
        Me.cbx_Owner.Name = "cbx_Owner"
        Me.cbx_Owner.Size = New System.Drawing.Size(247, 21)
        Me.cbx_Owner.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Package Total"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(202, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Required ManHours"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Earned ManHours"
        '
        'tbx_PackageRemaining
        '
        Me.tbx_PackageRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_PackageRemaining.Location = New System.Drawing.Point(509, 178)
        Me.tbx_PackageRemaining.Name = "tbx_PackageRemaining"
        Me.tbx_PackageRemaining.Size = New System.Drawing.Size(87, 20)
        Me.tbx_PackageRemaining.TabIndex = 32
        '
        'tbx_PackageComplete
        '
        Me.tbx_PackageComplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_PackageComplete.Location = New System.Drawing.Point(308, 178)
        Me.tbx_PackageComplete.Name = "tbx_PackageComplete"
        Me.tbx_PackageComplete.Size = New System.Drawing.Size(100, 20)
        Me.tbx_PackageComplete.TabIndex = 30
        '
        'tbx_PackageCount
        '
        Me.tbx_PackageCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_PackageCount.Location = New System.Drawing.Point(113, 178)
        Me.tbx_PackageCount.Name = "tbx_PackageCount"
        Me.tbx_PackageCount.Size = New System.Drawing.Size(86, 20)
        Me.tbx_PackageCount.TabIndex = 28
        '
        'txtPcntComplete
        '
        Me.txtPcntComplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPcntComplete.Location = New System.Drawing.Point(509, 159)
        Me.txtPcntComplete.Name = "txtPcntComplete"
        Me.txtPcntComplete.Size = New System.Drawing.Size(87, 20)
        Me.txtPcntComplete.TabIndex = 26
        '
        'txtReqdMhrs
        '
        Me.txtReqdMhrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReqdMhrs.Location = New System.Drawing.Point(308, 159)
        Me.txtReqdMhrs.Name = "txtReqdMhrs"
        Me.txtReqdMhrs.Size = New System.Drawing.Size(100, 20)
        Me.txtReqdMhrs.TabIndex = 25
        '
        'txtEarnedMhrs
        '
        Me.txtEarnedMhrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEarnedMhrs.Location = New System.Drawing.Point(113, 159)
        Me.txtEarnedMhrs.Name = "txtEarnedMhrs"
        Me.txtEarnedMhrs.Size = New System.Drawing.Size(86, 20)
        Me.txtEarnedMhrs.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "System ID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Description"
        '
        'tbx_Description2
        '
        Me.tbx_Description2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_Description2.Location = New System.Drawing.Point(14, 71)
        Me.tbx_Description2.Multiline = True
        Me.tbx_Description2.Name = "tbx_Description2"
        Me.tbx_Description2.Size = New System.Drawing.Size(256, 62)
        Me.tbx_Description2.TabIndex = 5
        '
        'tbx_SystemID2
        '
        Me.tbx_SystemID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_SystemID2.Location = New System.Drawing.Point(14, 27)
        Me.tbx_SystemID2.Name = "tbx_SystemID2"
        Me.tbx_SystemID2.Size = New System.Drawing.Size(256, 20)
        Me.tbx_SystemID2.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbp_SystemMain)
        Me.TabControl1.Controls.Add(Me.tbp_Documents)
        Me.TabControl1.Controls.Add(Me.tbp_Punchlist)
        Me.TabControl1.Controls.Add(Me.tbp_Discrepancies)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(936, 630)
        Me.TabControl1.TabIndex = 8
        '
        'btn_PunchlistExport
        '
        Me.btn_PunchlistExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_PunchlistExport.Image = CType(resources.GetObject("btn_PunchlistExport.Image"), System.Drawing.Image)
        Me.btn_PunchlistExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_PunchlistExport.Name = "btn_PunchlistExport"
        Me.btn_PunchlistExport.Size = New System.Drawing.Size(44, 22)
        Me.btn_PunchlistExport.Text = "Export"
        '
        '_SystemOverview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "_SystemOverview"
        Me.Size = New System.Drawing.Size(936, 630)
        Me.tbp_Discrepancies.ResumeLayout(False)
        Me.tbp_Discrepancies.PerformLayout()
        Me.pnl_Discrepancies.ResumeLayout(False)
        CType(Me.dgv_Discrepancies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_PackageData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp_Punchlist.ResumeLayout(False)
        Me.tbp_Punchlist.PerformLayout()
        Me.pnl_Punchlist.ResumeLayout(False)
        CType(Me.dgv_Punchlist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Documents, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp_Documents.ResumeLayout(False)
        Me.tbp_Documents.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.tbp_SystemMain.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbp_Discrepancies As System.Windows.Forms.TabPage
    Friend WithEvents pnl_Discrepancies As System.Windows.Forms.Panel
    Friend WithEvents dgv_Discrepancies As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_ListDiscrpancies As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents dgv_PackageData As DevExpress.XtraGrid.GridControl
    Friend WithEvents tbp_Punchlist As System.Windows.Forms.TabPage
    Friend WithEvents pnl_Punchlist As System.Windows.Forms.Panel
    Friend WithEvents dgv_Punchlist As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_ListPunchlist As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents dgv_Documents As DevExpress.XtraGrid.GridControl
    Friend WithEvents tbp_Documents As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsp_DocumentAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsp_DocumentEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsp_DocumentDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsp_DocumentView As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tbp_SystemMain As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tbx_PackageRemaining As System.Windows.Forms.TextBox
    Friend WithEvents tbx_PackageComplete As System.Windows.Forms.TextBox
    Friend WithEvents tbx_PackageCount As System.Windows.Forms.TextBox
    Friend WithEvents txtPcntComplete As System.Windows.Forms.TextBox
    Friend WithEvents txtReqdMhrs As System.Windows.Forms.TextBox
    Friend WithEvents txtEarnedMhrs As System.Windows.Forms.TextBox
    Friend WithEvents cbx_AllPackages As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbx_Owner As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbx_Description2 As System.Windows.Forms.TextBox
    Friend WithEvents tbx_SystemID2 As System.Windows.Forms.TextBox
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents btn_PrintOverview As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_ITS As System.Windows.Forms.Button
    Friend WithEvents btn_PunchlistExport As System.Windows.Forms.ToolStripButton

End Class
