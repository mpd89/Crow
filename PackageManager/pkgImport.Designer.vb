<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pkgImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pkgImport))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.ckbAssignSystemColumns = New System.Windows.Forms.CheckBox
        Me.lbl_error0 = New System.Windows.Forms.Label
        Me.btnCheckData = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboDefaultGroupID = New System.Windows.Forms.ComboBox
        Me.cboDefaultDisciplineID = New System.Windows.Forms.ComboBox
        Me.cboDefaultOwnerID = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboDiscipline = New System.Windows.Forms.ComboBox
        Me.cboGroup = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboOwner = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnUploadPkgNums = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDescription = New System.Windows.Forms.ComboBox
        Me.cboPkgNumber = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.fileName = New System.Windows.Forms.TextBox
        Me.btnImportCSV = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label15 = New System.Windows.Forms.Label
        Me.btnCreateTemplate = New System.Windows.Forms.Button
        Me.cboTemplateName = New System.Windows.Forms.ComboBox
        Me.btnAuxUpload = New System.Windows.Forms.Button
        Me.cboAuxPkgNum = New System.Windows.Forms.ComboBox
        Me.cboAuxDiscID = New System.Windows.Forms.ComboBox
        Me.NewlvwImportFields = New System.Windows.Forms.ListBox
        Me.NewlvwCSVFile = New System.Windows.Forms.ListBox
        Me.tbx_Duplicate = New System.Windows.Forms.TextBox
        Me.tbx_ColorBlank = New System.Windows.Forms.TextBox
        Me.tbx_ColorInvalid = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbx_Priority = New System.Windows.Forms.ComboBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1008, 360)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cbx_Priority)
        Me.TabPage1.Controls.Add(Me.ckbAssignSystemColumns)
        Me.TabPage1.Controls.Add(Me.lbl_error0)
        Me.TabPage1.Controls.Add(Me.btnCheckData)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.btnUploadPkgNums)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cboDescription)
        Me.TabPage1.Controls.Add(Me.cboPkgNumber)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.fileName)
        Me.TabPage1.Controls.Add(Me.btnImportCSV)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1000, 334)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Import Packages"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ckbAssignSystemColumns
        '
        Me.ckbAssignSystemColumns.AutoSize = True
        Me.ckbAssignSystemColumns.Location = New System.Drawing.Point(572, 39)
        Me.ckbAssignSystemColumns.Name = "ckbAssignSystemColumns"
        Me.ckbAssignSystemColumns.Size = New System.Drawing.Size(131, 17)
        Me.ckbAssignSystemColumns.TabIndex = 153
        Me.ckbAssignSystemColumns.Text = "AssignSystemColumns"
        Me.ckbAssignSystemColumns.UseVisualStyleBackColor = True
        '
        'lbl_error0
        '
        Me.lbl_error0.AutoSize = True
        Me.lbl_error0.ForeColor = System.Drawing.Color.Red
        Me.lbl_error0.Location = New System.Drawing.Point(539, 289)
        Me.lbl_error0.Name = "lbl_error0"
        Me.lbl_error0.Size = New System.Drawing.Size(94, 13)
        Me.lbl_error0.TabIndex = 148
        Me.lbl_error0.Text = "* Error in import file"
        Me.lbl_error0.Visible = False
        '
        'btnCheckData
        '
        Me.btnCheckData.Location = New System.Drawing.Point(542, 308)
        Me.btnCheckData.Name = "btnCheckData"
        Me.btnCheckData.Size = New System.Drawing.Size(75, 20)
        Me.btnCheckData.TabIndex = 146
        Me.btnCheckData.Text = "Check Data"
        Me.btnCheckData.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(830, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 142
        Me.Label10.Text = "* Required"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(323, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 141
        Me.Label9.Text = "*"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboDefaultGroupID)
        Me.GroupBox1.Controls.Add(Me.cboDefaultDisciplineID)
        Me.GroupBox1.Controls.Add(Me.cboDefaultOwnerID)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cboDiscipline)
        Me.GroupBox1.Controls.Add(Me.cboGroup)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboOwner)
        Me.GroupBox1.Location = New System.Drawing.Point(34, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(444, 141)
        Me.GroupBox1.TabIndex = 139
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Associations"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Group"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboDefaultGroupID
        '
        Me.cboDefaultGroupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefaultGroupID.FormattingEnabled = True
        Me.cboDefaultGroupID.Location = New System.Drawing.Point(287, 36)
        Me.cboDefaultGroupID.Name = "cboDefaultGroupID"
        Me.cboDefaultGroupID.Size = New System.Drawing.Size(142, 21)
        Me.cboDefaultGroupID.TabIndex = 117
        '
        'cboDefaultDisciplineID
        '
        Me.cboDefaultDisciplineID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefaultDisciplineID.DropDownWidth = 200
        Me.cboDefaultDisciplineID.FormattingEnabled = True
        Me.cboDefaultDisciplineID.Location = New System.Drawing.Point(287, 91)
        Me.cboDefaultDisciplineID.Name = "cboDefaultDisciplineID"
        Me.cboDefaultDisciplineID.Size = New System.Drawing.Size(142, 21)
        Me.cboDefaultDisciplineID.TabIndex = 118
        '
        'cboDefaultOwnerID
        '
        Me.cboDefaultOwnerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefaultOwnerID.FormattingEnabled = True
        Me.cboDefaultOwnerID.Location = New System.Drawing.Point(287, 62)
        Me.cboDefaultOwnerID.Name = "cboDefaultOwnerID"
        Me.cboDefaultOwnerID.Size = New System.Drawing.Size(142, 21)
        Me.cboDefaultOwnerID.TabIndex = 119
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "Discipline"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(284, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(126, 13)
        Me.Label14.TabIndex = 120
        Me.Label14.Text = "Default Values for Blanks"
        '
        'cboDiscipline
        '
        Me.cboDiscipline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiscipline.FormattingEnabled = True
        Me.cboDiscipline.Location = New System.Drawing.Point(119, 92)
        Me.cboDiscipline.Name = "cboDiscipline"
        Me.cboDiscipline.Size = New System.Drawing.Size(157, 21)
        Me.cboDiscipline.TabIndex = 134
        '
        'cboGroup
        '
        Me.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGroup.FormattingEnabled = True
        Me.cboGroup.Location = New System.Drawing.Point(119, 37)
        Me.cboGroup.Name = "cboGroup"
        Me.cboGroup.Size = New System.Drawing.Size(157, 21)
        Me.cboGroup.TabIndex = 127
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(55, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Owner"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboOwner
        '
        Me.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOwner.FormattingEnabled = True
        Me.cboOwner.Location = New System.Drawing.Point(119, 64)
        Me.cboOwner.Name = "cboOwner"
        Me.cboOwner.Size = New System.Drawing.Size(157, 21)
        Me.cboOwner.TabIndex = 128
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(152, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(160, 13)
        Me.Label8.TabIndex = 137
        Me.Label8.Text = "Select columns from the CSV file"
        '
        'btnUploadPkgNums
        '
        Me.btnUploadPkgNums.Enabled = False
        Me.btnUploadPkgNums.Location = New System.Drawing.Point(670, 310)
        Me.btnUploadPkgNums.Name = "btnUploadPkgNums"
        Me.btnUploadPkgNums.Size = New System.Drawing.Size(123, 20)
        Me.btnUploadPkgNums.TabIndex = 136
        Me.btnUploadPkgNums.Text = "Upload Packages"
        Me.btnUploadPkgNums.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(66, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Description"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "Package Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboDescription
        '
        Me.cboDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDescription.FormattingEnabled = True
        Me.cboDescription.Location = New System.Drawing.Point(155, 93)
        Me.cboDescription.Name = "cboDescription"
        Me.cboDescription.Size = New System.Drawing.Size(157, 21)
        Me.cboDescription.TabIndex = 125
        '
        'cboPkgNumber
        '
        Me.cboPkgNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPkgNumber.FormattingEnabled = True
        Me.cboPkgNumber.Location = New System.Drawing.Point(155, 65)
        Me.cboPkgNumber.Name = "cboPkgNumber"
        Me.cboPkgNumber.Size = New System.Drawing.Size(157, 21)
        Me.cboPkgNumber.TabIndex = 124
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(149, 24)
        Me.Label17.TabIndex = 96
        Me.Label17.Text = "Import Packages"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(324, 289)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(154, 17)
        Me.CheckBox1.TabIndex = 95
        Me.CheckBox1.Text = "First Row contains headers"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'fileName
        '
        Me.fileName.Location = New System.Drawing.Point(34, 308)
        Me.fileName.Name = "fileName"
        Me.fileName.Size = New System.Drawing.Size(284, 20)
        Me.fileName.TabIndex = 94
        '
        'btnImportCSV
        '
        Me.btnImportCSV.Location = New System.Drawing.Point(324, 308)
        Me.btnImportCSV.Name = "btnImportCSV"
        Me.btnImportCSV.Size = New System.Drawing.Size(123, 20)
        Me.btnImportCSV.TabIndex = 93
        Me.btnImportCSV.Text = "Import from CSV File"
        Me.btnImportCSV.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.btnCreateTemplate)
        Me.TabPage2.Controls.Add(Me.cboTemplateName)
        Me.TabPage2.Controls.Add(Me.btnAuxUpload)
        Me.TabPage2.Controls.Add(Me.cboAuxPkgNum)
        Me.TabPage2.Controls.Add(Me.cboAuxDiscID)
        Me.TabPage2.Controls.Add(Me.NewlvwImportFields)
        Me.TabPage2.Controls.Add(Me.NewlvwCSVFile)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1000, 334)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Import auxiliary data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(138, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(197, 25)
        Me.Label15.TabIndex = 180
        Me.Label15.Text = "Aux Field Template"
        '
        'btnCreateTemplate
        '
        Me.btnCreateTemplate.Location = New System.Drawing.Point(154, 81)
        Me.btnCreateTemplate.Name = "btnCreateTemplate"
        Me.btnCreateTemplate.Size = New System.Drawing.Size(123, 23)
        Me.btnCreateTemplate.TabIndex = 177
        Me.btnCreateTemplate.Text = "Create Template"
        Me.btnCreateTemplate.UseVisualStyleBackColor = True
        '
        'cboTemplateName
        '
        Me.cboTemplateName.FormattingEnabled = True
        Me.cboTemplateName.Location = New System.Drawing.Point(156, 44)
        Me.cboTemplateName.Name = "cboTemplateName"
        Me.cboTemplateName.Size = New System.Drawing.Size(121, 21)
        Me.cboTemplateName.TabIndex = 176
        '
        'btnAuxUpload
        '
        Me.btnAuxUpload.Location = New System.Drawing.Point(154, 124)
        Me.btnAuxUpload.Name = "btnAuxUpload"
        Me.btnAuxUpload.Size = New System.Drawing.Size(123, 20)
        Me.btnAuxUpload.TabIndex = 170
        Me.btnAuxUpload.Text = "Upload auxiliary info"
        Me.btnAuxUpload.UseVisualStyleBackColor = True
        '
        'cboAuxPkgNum
        '
        Me.cboAuxPkgNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAuxPkgNum.FormattingEnabled = True
        Me.cboAuxPkgNum.Location = New System.Drawing.Point(677, 44)
        Me.cboAuxPkgNum.Name = "cboAuxPkgNum"
        Me.cboAuxPkgNum.Size = New System.Drawing.Size(121, 21)
        Me.cboAuxPkgNum.TabIndex = 165
        Me.cboAuxPkgNum.Visible = False
        '
        'cboAuxDiscID
        '
        Me.cboAuxDiscID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAuxDiscID.FormattingEnabled = True
        Me.cboAuxDiscID.Location = New System.Drawing.Point(677, 17)
        Me.cboAuxDiscID.Name = "cboAuxDiscID"
        Me.cboAuxDiscID.Size = New System.Drawing.Size(121, 21)
        Me.cboAuxDiscID.TabIndex = 164
        Me.cboAuxDiscID.Visible = False
        '
        'NewlvwImportFields
        '
        Me.NewlvwImportFields.FormattingEnabled = True
        Me.NewlvwImportFields.Location = New System.Drawing.Point(677, 71)
        Me.NewlvwImportFields.Name = "NewlvwImportFields"
        Me.NewlvwImportFields.Size = New System.Drawing.Size(120, 17)
        Me.NewlvwImportFields.TabIndex = 154
        Me.NewlvwImportFields.Visible = False
        '
        'NewlvwCSVFile
        '
        Me.NewlvwCSVFile.FormattingEnabled = True
        Me.NewlvwCSVFile.Location = New System.Drawing.Point(678, 94)
        Me.NewlvwCSVFile.Name = "NewlvwCSVFile"
        Me.NewlvwCSVFile.Size = New System.Drawing.Size(120, 17)
        Me.NewlvwCSVFile.TabIndex = 153
        Me.NewlvwCSVFile.Visible = False
        '
        'tbx_Duplicate
        '
        Me.tbx_Duplicate.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbx_Duplicate.Location = New System.Drawing.Point(412, 88)
        Me.tbx_Duplicate.Multiline = True
        Me.tbx_Duplicate.Name = "tbx_Duplicate"
        Me.tbx_Duplicate.Size = New System.Drawing.Size(19, 20)
        Me.tbx_Duplicate.TabIndex = 147
        '
        'tbx_ColorBlank
        '
        Me.tbx_ColorBlank.BackColor = System.Drawing.Color.Yellow
        Me.tbx_ColorBlank.Location = New System.Drawing.Point(412, 36)
        Me.tbx_ColorBlank.Multiline = True
        Me.tbx_ColorBlank.Name = "tbx_ColorBlank"
        Me.tbx_ColorBlank.Size = New System.Drawing.Size(19, 20)
        Me.tbx_ColorBlank.TabIndex = 143
        '
        'tbx_ColorInvalid
        '
        Me.tbx_ColorInvalid.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tbx_ColorInvalid.Location = New System.Drawing.Point(412, 62)
        Me.tbx_ColorInvalid.Multiline = True
        Me.tbx_ColorInvalid.Name = "tbx_ColorInvalid"
        Me.tbx_ColorInvalid.Size = New System.Drawing.Size(19, 20)
        Me.tbx_ColorInvalid.TabIndex = 145
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripProgressBar1, Me.ToolStripTextBox1, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1008, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(91, 22)
        Me.ToolStripLabel1.Text = "Import Progress"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 22)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(90, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_Duplicate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_ColorBlank)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_ColorInvalid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label18)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel1MinSize = 360
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 728)
        Me.SplitContainer1.SplitterDistance = 360
        Me.SplitContainer1.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(439, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 146
        Me.Label11.Text = "Invalid Value"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(438, 39)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 144
        Me.Label16.Text = "Blank Entries"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(437, 91)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 13)
        Me.Label18.TabIndex = 148
        Me.Label18.Text = "Duplicate Entries"
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BindingSource = Me.BindingSource1
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 753)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(1008, 25)
        Me.BindingNavigator1.TabIndex = 7
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(66, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 155
        Me.Label3.Text = "Priority"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cbx_Priority
        '
        Me.cbx_Priority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Priority.FormattingEnabled = True
        Me.cbx_Priority.Location = New System.Drawing.Point(155, 120)
        Me.cbx_Priority.Name = "cbx_Priority"
        Me.cbx_Priority.Size = New System.Drawing.Size(157, 21)
        Me.cbx_Priority.TabIndex = 154
        '
        'pkgImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 778)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "pkgImport"
        Me.Text = "Package Import"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents fileName As System.Windows.Forms.TextBox
    Friend WithEvents btnImportCSV As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboDefaultOwnerID As System.Windows.Forms.ComboBox
    Friend WithEvents cboDefaultDisciplineID As System.Windows.Forms.ComboBox
    Friend WithEvents cboDefaultGroupID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboOwner As System.Windows.Forms.ComboBox
    Friend WithEvents cboGroup As System.Windows.Forms.ComboBox
    Friend WithEvents cboDescription As System.Windows.Forms.ComboBox
    Friend WithEvents cboPkgNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboDiscipline As System.Windows.Forms.ComboBox
    Friend WithEvents btnUploadPkgNums As System.Windows.Forms.Button
    Friend WithEvents NewlvwImportFields As System.Windows.Forms.ListBox
    Friend WithEvents NewlvwCSVFile As System.Windows.Forms.ListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboAuxDiscID As System.Windows.Forms.ComboBox
    Friend WithEvents cboAuxPkgNum As System.Windows.Forms.ComboBox
    Friend WithEvents btnAuxUpload As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnCreateTemplate As System.Windows.Forms.Button
    Friend WithEvents cboTemplateName As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbx_ColorInvalid As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tbx_ColorBlank As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbx_Duplicate As System.Windows.Forms.TextBox
    Friend WithEvents btnCheckData As System.Windows.Forms.Button
    Friend WithEvents lbl_error0 As System.Windows.Forms.Label
    Friend WithEvents ckbAssignSystemColumns As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbx_Priority As System.Windows.Forms.ComboBox
End Class
