<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiscrepancyMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiscrepancyMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsb_PrintList = New System.Windows.Forms.ToolStripButton
        Me.tsb_PrintShortDescription = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lbl_Message = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsl_SiteLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProjectStatusInd = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPackageID = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtClosedOnTo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtClosedOnFrom = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtListedOnTo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtListedOnFrom = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbc_DiscrepancyMain = New System.Windows.Forms.TabControl
        Me.tbp_Lookup = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbx_NoAction = New System.Windows.Forms.CheckBox
        Me.cbx_Resolved = New System.Windows.Forms.CheckBox
        Me.cbx_Open = New System.Windows.Forms.CheckBox
        Me.cbx_Pending = New System.Windows.Forms.CheckBox
        Me.cboDiscrepancyID = New System.Windows.Forms.ComboBox
        Me.cbxClosedBy = New System.Windows.Forms.ComboBox
        Me.cbxListedBy = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtResolution = New System.Windows.Forms.TextBox
        Me.tbp_Results = New System.Windows.Forms.TabPage
        Me.dgv_Results = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.tbc_DiscrepancyMain.SuspendLayout()
        Me.tbp_Lookup.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbp_Results.SuspendLayout()
        CType(Me.dgv_Results, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(956, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_PrintList, Me.tsb_PrintShortDescription})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(956, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsb_PrintList
        '
        Me.tsb_PrintList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_PrintList.Image = Global.DiscrepancyManager.My.Resources.Resources.Printer_1
        Me.tsb_PrintList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_PrintList.Name = "tsb_PrintList"
        Me.tsb_PrintList.Size = New System.Drawing.Size(23, 22)
        Me.tsb_PrintList.Text = "Print List"
        '
        'tsb_PrintShortDescription
        '
        Me.tsb_PrintShortDescription.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_PrintShortDescription.Image = CType(resources.GetObject("tsb_PrintShortDescription.Image"), System.Drawing.Image)
        Me.tsb_PrintShortDescription.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_PrintShortDescription.Name = "tsb_PrintShortDescription"
        Me.tsb_PrintShortDescription.Size = New System.Drawing.Size(23, 22)
        Me.tsb_PrintShortDescription.Text = "Print Short Description"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_Message, Me.tsl_SiteLabel, Me.ProjectStatusInd})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 516)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(956, 24)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbl_Message
        '
        Me.lbl_Message.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Message.Name = "lbl_Message"
        Me.lbl_Message.Size = New System.Drawing.Size(700, 19)
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
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(38, 87)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(27, 13)
        Me.Label20.TabIndex = 146
        Me.Label20.Text = "Title"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(161, 87)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(189, 20)
        Me.txtTitle.TabIndex = 145
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(335, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 144
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 136
        Me.Label3.Text = "Package Name"
        '
        'txtPackageID
        '
        Me.txtPackageID.Location = New System.Drawing.Point(160, 200)
        Me.txtPackageID.Name = "txtPackageID"
        Me.txtPackageID.Size = New System.Drawing.Size(191, 20)
        Me.txtPackageID.TabIndex = 135
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(559, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "To"
        '
        'txtClosedOnTo
        '
        Me.txtClosedOnTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtClosedOnTo.Location = New System.Drawing.Point(584, 172)
        Me.txtClosedOnTo.Name = "txtClosedOnTo"
        Me.txtClosedOnTo.ReadOnly = True
        Me.txtClosedOnTo.Size = New System.Drawing.Size(89, 20)
        Me.txtClosedOnTo.TabIndex = 108
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(373, 172)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 107
        Me.Label10.Text = "ClosedOn"
        '
        'txtClosedOnFrom
        '
        Me.txtClosedOnFrom.BackColor = System.Drawing.SystemColors.Window
        Me.txtClosedOnFrom.Location = New System.Drawing.Point(468, 172)
        Me.txtClosedOnFrom.Name = "txtClosedOnFrom"
        Me.txtClosedOnFrom.ReadOnly = True
        Me.txtClosedOnFrom.Size = New System.Drawing.Size(85, 20)
        Me.txtClosedOnFrom.TabIndex = 106
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(373, 136)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 104
        Me.Label11.Text = "ClosedBy"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(558, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "To"
        '
        'txtListedOnTo
        '
        Me.txtListedOnTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtListedOnTo.Location = New System.Drawing.Point(584, 89)
        Me.txtListedOnTo.Name = "txtListedOnTo"
        Me.txtListedOnTo.ReadOnly = True
        Me.txtListedOnTo.Size = New System.Drawing.Size(89, 20)
        Me.txtListedOnTo.TabIndex = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(372, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "ListedOn"
        '
        'txtListedOnFrom
        '
        Me.txtListedOnFrom.BackColor = System.Drawing.SystemColors.Window
        Me.txtListedOnFrom.Location = New System.Drawing.Point(467, 89)
        Me.txtListedOnFrom.Name = "txtListedOnFrom"
        Me.txtListedOnFrom.ReadOnly = True
        Me.txtListedOnFrom.Size = New System.Drawing.Size(86, 20)
        Me.txtListedOnFrom.TabIndex = 98
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(372, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "ListedBy"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(162, 125)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(190, 20)
        Me.txtDescription.TabIndex = 92
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "Discrepancy ID"
        '
        'tbc_DiscrepancyMain
        '
        Me.tbc_DiscrepancyMain.Controls.Add(Me.tbp_Lookup)
        Me.tbc_DiscrepancyMain.Controls.Add(Me.tbp_Results)
        Me.tbc_DiscrepancyMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbc_DiscrepancyMain.Location = New System.Drawing.Point(0, 49)
        Me.tbc_DiscrepancyMain.Name = "tbc_DiscrepancyMain"
        Me.tbc_DiscrepancyMain.SelectedIndex = 0
        Me.tbc_DiscrepancyMain.Size = New System.Drawing.Size(956, 467)
        Me.tbc_DiscrepancyMain.TabIndex = 5
        '
        'tbp_Lookup
        '
        Me.tbp_Lookup.Controls.Add(Me.GroupBox1)
        Me.tbp_Lookup.Controls.Add(Me.cboDiscrepancyID)
        Me.tbp_Lookup.Controls.Add(Me.cbxClosedBy)
        Me.tbp_Lookup.Controls.Add(Me.cbxListedBy)
        Me.tbp_Lookup.Controls.Add(Me.txtPackageID)
        Me.tbp_Lookup.Controls.Add(Me.Label14)
        Me.tbp_Lookup.Controls.Add(Me.Label1)
        Me.tbp_Lookup.Controls.Add(Me.txtResolution)
        Me.tbp_Lookup.Controls.Add(Me.Label20)
        Me.tbp_Lookup.Controls.Add(Me.txtDescription)
        Me.tbp_Lookup.Controls.Add(Me.txtTitle)
        Me.tbp_Lookup.Controls.Add(Me.btnSearch)
        Me.tbp_Lookup.Controls.Add(Me.Label2)
        Me.tbp_Lookup.Controls.Add(Me.Label3)
        Me.tbp_Lookup.Controls.Add(Me.Label4)
        Me.tbp_Lookup.Controls.Add(Me.txtListedOnFrom)
        Me.tbp_Lookup.Controls.Add(Me.Label5)
        Me.tbp_Lookup.Controls.Add(Me.txtListedOnTo)
        Me.tbp_Lookup.Controls.Add(Me.Label7)
        Me.tbp_Lookup.Controls.Add(Me.Label8)
        Me.tbp_Lookup.Controls.Add(Me.Label11)
        Me.tbp_Lookup.Controls.Add(Me.txtClosedOnTo)
        Me.tbp_Lookup.Controls.Add(Me.txtClosedOnFrom)
        Me.tbp_Lookup.Controls.Add(Me.Label10)
        Me.tbp_Lookup.Location = New System.Drawing.Point(4, 22)
        Me.tbp_Lookup.Name = "tbp_Lookup"
        Me.tbp_Lookup.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_Lookup.Size = New System.Drawing.Size(948, 441)
        Me.tbp_Lookup.TabIndex = 0
        Me.tbp_Lookup.Text = "Lookup"
        Me.tbp_Lookup.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbx_NoAction)
        Me.GroupBox1.Controls.Add(Me.cbx_Resolved)
        Me.GroupBox1.Controls.Add(Me.cbx_Open)
        Me.GroupBox1.Controls.Add(Me.cbx_Pending)
        Me.GroupBox1.Location = New System.Drawing.Point(160, 242)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(192, 124)
        Me.GroupBox1.TabIndex = 154
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'cbx_NoAction
        '
        Me.cbx_NoAction.AutoSize = True
        Me.cbx_NoAction.Location = New System.Drawing.Point(38, 88)
        Me.cbx_NoAction.Name = "cbx_NoAction"
        Me.cbx_NoAction.Size = New System.Drawing.Size(73, 17)
        Me.cbx_NoAction.TabIndex = 3
        Me.cbx_NoAction.Text = "No Action"
        Me.cbx_NoAction.UseVisualStyleBackColor = True
        '
        'cbx_Resolved
        '
        Me.cbx_Resolved.AutoSize = True
        Me.cbx_Resolved.Location = New System.Drawing.Point(38, 65)
        Me.cbx_Resolved.Name = "cbx_Resolved"
        Me.cbx_Resolved.Size = New System.Drawing.Size(71, 17)
        Me.cbx_Resolved.TabIndex = 2
        Me.cbx_Resolved.Text = "Resolved"
        Me.cbx_Resolved.UseVisualStyleBackColor = True
        '
        'cbx_Open
        '
        Me.cbx_Open.AutoSize = True
        Me.cbx_Open.Checked = True
        Me.cbx_Open.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbx_Open.Location = New System.Drawing.Point(38, 42)
        Me.cbx_Open.Name = "cbx_Open"
        Me.cbx_Open.Size = New System.Drawing.Size(52, 17)
        Me.cbx_Open.TabIndex = 1
        Me.cbx_Open.Text = "Open"
        Me.cbx_Open.UseVisualStyleBackColor = True
        '
        'cbx_Pending
        '
        Me.cbx_Pending.AutoSize = True
        Me.cbx_Pending.Checked = True
        Me.cbx_Pending.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbx_Pending.Location = New System.Drawing.Point(38, 19)
        Me.cbx_Pending.Name = "cbx_Pending"
        Me.cbx_Pending.Size = New System.Drawing.Size(65, 17)
        Me.cbx_Pending.TabIndex = 0
        Me.cbx_Pending.Text = "Pending"
        Me.cbx_Pending.UseVisualStyleBackColor = True
        '
        'cboDiscrepancyID
        '
        Me.cboDiscrepancyID.FormattingEnabled = True
        Me.cboDiscrepancyID.Location = New System.Drawing.Point(160, 50)
        Me.cboDiscrepancyID.Name = "cboDiscrepancyID"
        Me.cboDiscrepancyID.Size = New System.Drawing.Size(192, 21)
        Me.cboDiscrepancyID.TabIndex = 153
        '
        'cbxClosedBy
        '
        Me.cbxClosedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxClosedBy.FormattingEnabled = True
        Me.cbxClosedBy.Location = New System.Drawing.Point(467, 136)
        Me.cbxClosedBy.Name = "cbxClosedBy"
        Me.cbxClosedBy.Size = New System.Drawing.Size(206, 21)
        Me.cbxClosedBy.TabIndex = 152
        '
        'cbxListedBy
        '
        Me.cbxListedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxListedBy.FormattingEnabled = True
        Me.cbxListedBy.Location = New System.Drawing.Point(467, 53)
        Me.cbxListedBy.Name = "cbxListedBy"
        Me.cbxListedBy.Size = New System.Drawing.Size(206, 21)
        Me.cbxListedBy.TabIndex = 151
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(41, 161)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 148
        Me.Label14.Text = "Resolution"
        '
        'txtResolution
        '
        Me.txtResolution.Location = New System.Drawing.Point(162, 161)
        Me.txtResolution.Name = "txtResolution"
        Me.txtResolution.Size = New System.Drawing.Size(190, 20)
        Me.txtResolution.TabIndex = 147
        '
        'tbp_Results
        '
        Me.tbp_Results.Controls.Add(Me.dgv_Results)
        Me.tbp_Results.Location = New System.Drawing.Point(4, 22)
        Me.tbp_Results.Name = "tbp_Results"
        Me.tbp_Results.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_Results.Size = New System.Drawing.Size(948, 441)
        Me.tbp_Results.TabIndex = 1
        Me.tbp_Results.Text = "Results"
        Me.tbp_Results.UseVisualStyleBackColor = True
        '
        'dgv_Results
        '
        Me.dgv_Results.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Results.EmbeddedNavigator.Name = ""
        Me.dgv_Results.Location = New System.Drawing.Point(3, 3)
        Me.dgv_Results.MainView = Me.GridView1
        Me.dgv_Results.Name = "dgv_Results"
        Me.dgv_Results.Size = New System.Drawing.Size(942, 435)
        Me.dgv_Results.TabIndex = 0
        Me.dgv_Results.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.dgv_Results
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'DiscrepancyMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 540)
        Me.Controls.Add(Me.tbc_DiscrepancyMain)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "DiscrepancyMain"
        Me.Text = "Discrepancy Manager"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tbc_DiscrepancyMain.ResumeLayout(False)
        Me.tbp_Lookup.ResumeLayout(False)
        Me.tbp_Lookup.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbp_Results.ResumeLayout(False)
        CType(Me.dgv_Results, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPackageID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtClosedOnTo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtClosedOnFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtListedOnTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtListedOnFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbc_DiscrepancyMain As System.Windows.Forms.TabControl
    Friend WithEvents tbp_Lookup As System.Windows.Forms.TabPage
    Friend WithEvents tbp_Results As System.Windows.Forms.TabPage
    Friend WithEvents dgv_Results As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtResolution As System.Windows.Forms.TextBox
    Friend WithEvents cbxClosedBy As System.Windows.Forms.ComboBox
    Friend WithEvents cbxListedBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbl_Message As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsl_SiteLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProjectStatusInd As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsb_PrintList As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_PrintShortDescription As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboDiscrepancyID As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbx_Pending As System.Windows.Forms.CheckBox
    Friend WithEvents cbx_NoAction As System.Windows.Forms.CheckBox
    Friend WithEvents cbx_Resolved As System.Windows.Forms.CheckBox
    Friend WithEvents cbx_Open As System.Windows.Forms.CheckBox
End Class
