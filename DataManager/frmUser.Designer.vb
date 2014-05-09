<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TbpGeneral = New System.Windows.Forms.TabPage
        Me.btn_ResetPassword = New System.Windows.Forms.Button
        Me.chk_Active = New System.Windows.Forms.CheckBox
        Me.btn_Apply = New System.Windows.Forms.Button
        Me.txt_UserName = New System.Windows.Forms.TextBox
        Me.lbltag = New System.Windows.Forms.Label
        Me.txt_Number = New System.Windows.Forms.TextBox
        Me.lblNumber = New System.Windows.Forms.Label
        Me.txt_Title = New System.Windows.Forms.TextBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.cmb_LevelID = New System.Windows.Forms.ComboBox
        Me.lblLevelID = New System.Windows.Forms.Label
        Me.cmb_CompanyId = New System.Windows.Forms.ComboBox
        Me.lblCompanyID = New System.Windows.Forms.Label
        Me.txt_UserID = New System.Windows.Forms.TextBox
        Me.lblUserID = New System.Windows.Forms.Label
        Me.txt_LastName = New System.Windows.Forms.TextBox
        Me.lblLastName = New System.Windows.Forms.Label
        Me.txt_Initial = New System.Windows.Forms.TextBox
        Me.lblInitial = New System.Windows.Forms.Label
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.txt_FirstName = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.lblEditName = New System.Windows.Forms.Label
        Me.TbpDiscipline = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnDispAdd = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.lstSelected = New System.Windows.Forms.ListBox
        Me.lstAll = New System.Windows.Forms.ListBox
        Me.TbpGroup = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnGrpAdd = New System.Windows.Forms.Button
        Me.btnGrpRemove = New System.Windows.Forms.Button
        Me.lstGrpSelect = New System.Windows.Forms.ListBox
        Me.lstGrpAll = New System.Windows.Forms.ListBox
        Me.TbpLevel = New System.Windows.Forms.TabPage
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnlvlAdd = New System.Windows.Forms.Button
        Me.btnlvlRemove = New System.Windows.Forms.Button
        Me.lstLvlSelect = New System.Windows.Forms.ListBox
        Me.lstLvlAll = New System.Windows.Forms.ListBox
        Me.TbpOwner = New System.Windows.Forms.TabPage
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnOwnAdd = New System.Windows.Forms.Button
        Me.btnOwnRemove = New System.Windows.Forms.Button
        Me.lstOwnerSelect = New System.Windows.Forms.ListBox
        Me.lstOwnerAll = New System.Windows.Forms.ListBox
        Me.tab_Projects = New System.Windows.Forms.TabPage
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btn_SelectProject = New System.Windows.Forms.Button
        Me.btn_RemoveProject = New System.Windows.Forms.Button
        Me.lbx_SelectedProjects = New System.Windows.Forms.ListBox
        Me.lbx_ProjectList = New System.Windows.Forms.ListBox
        Me.TabControl1.SuspendLayout()
        Me.TbpGeneral.SuspendLayout()
        Me.TbpDiscipline.SuspendLayout()
        Me.TbpGroup.SuspendLayout()
        Me.TbpLevel.SuspendLayout()
        Me.TbpOwner.SuspendLayout()
        Me.tab_Projects.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TbpGeneral)
        Me.TabControl1.Controls.Add(Me.TbpDiscipline)
        Me.TabControl1.Controls.Add(Me.TbpGroup)
        Me.TabControl1.Controls.Add(Me.TbpLevel)
        Me.TabControl1.Controls.Add(Me.TbpOwner)
        Me.TabControl1.Controls.Add(Me.tab_Projects)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(443, 377)
        Me.TabControl1.TabIndex = 1
        '
        'TbpGeneral
        '
        Me.TbpGeneral.BackColor = System.Drawing.Color.Transparent
        Me.TbpGeneral.Controls.Add(Me.btn_ResetPassword)
        Me.TbpGeneral.Controls.Add(Me.chk_Active)
        Me.TbpGeneral.Controls.Add(Me.btn_Apply)
        Me.TbpGeneral.Controls.Add(Me.txt_UserName)
        Me.TbpGeneral.Controls.Add(Me.lbltag)
        Me.TbpGeneral.Controls.Add(Me.txt_Number)
        Me.TbpGeneral.Controls.Add(Me.lblNumber)
        Me.TbpGeneral.Controls.Add(Me.txt_Title)
        Me.TbpGeneral.Controls.Add(Me.lblTitle)
        Me.TbpGeneral.Controls.Add(Me.cmb_LevelID)
        Me.TbpGeneral.Controls.Add(Me.lblLevelID)
        Me.TbpGeneral.Controls.Add(Me.cmb_CompanyId)
        Me.TbpGeneral.Controls.Add(Me.lblCompanyID)
        Me.TbpGeneral.Controls.Add(Me.txt_UserID)
        Me.TbpGeneral.Controls.Add(Me.lblUserID)
        Me.TbpGeneral.Controls.Add(Me.txt_LastName)
        Me.TbpGeneral.Controls.Add(Me.lblLastName)
        Me.TbpGeneral.Controls.Add(Me.txt_Initial)
        Me.TbpGeneral.Controls.Add(Me.lblInitial)
        Me.TbpGeneral.Controls.Add(Me.lblFirstName)
        Me.TbpGeneral.Controls.Add(Me.txt_FirstName)
        Me.TbpGeneral.Controls.Add(Me.btnCancel)
        Me.TbpGeneral.Controls.Add(Me.btn_OK)
        Me.TbpGeneral.Controls.Add(Me.lblEditName)
        Me.TbpGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TbpGeneral.Name = "TbpGeneral"
        Me.TbpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.TbpGeneral.Size = New System.Drawing.Size(435, 351)
        Me.TbpGeneral.TabIndex = 0
        Me.TbpGeneral.Text = "General"
        Me.TbpGeneral.UseVisualStyleBackColor = True
        '
        'btn_ResetPassword
        '
        Me.btn_ResetPassword.Location = New System.Drawing.Point(13, 322)
        Me.btn_ResetPassword.Name = "btn_ResetPassword"
        Me.btn_ResetPassword.Size = New System.Drawing.Size(105, 23)
        Me.btn_ResetPassword.TabIndex = 87
        Me.btn_ResetPassword.Text = "Reset Password"
        Me.btn_ResetPassword.UseVisualStyleBackColor = True
        '
        'chk_Active
        '
        Me.chk_Active.AutoSize = True
        Me.chk_Active.Location = New System.Drawing.Point(161, 268)
        Me.chk_Active.Name = "chk_Active"
        Me.chk_Active.Size = New System.Drawing.Size(56, 17)
        Me.chk_Active.TabIndex = 86
        Me.chk_Active.Text = "Active"
        Me.chk_Active.UseVisualStyleBackColor = True
        '
        'btn_Apply
        '
        Me.btn_Apply.Location = New System.Drawing.Point(354, 322)
        Me.btn_Apply.Name = "btn_Apply"
        Me.btn_Apply.Size = New System.Drawing.Size(75, 23)
        Me.btn_Apply.TabIndex = 85
        Me.btn_Apply.Text = "Apply"
        Me.btn_Apply.UseVisualStyleBackColor = True
        '
        'txt_UserName
        '
        Me.txt_UserName.Location = New System.Drawing.Point(10, 45)
        Me.txt_UserName.Name = "txt_UserName"
        Me.txt_UserName.ReadOnly = True
        Me.txt_UserName.Size = New System.Drawing.Size(84, 20)
        Me.txt_UserName.TabIndex = 84
        '
        'lbltag
        '
        Me.lbltag.AutoSize = True
        Me.lbltag.Location = New System.Drawing.Point(242, 86)
        Me.lbltag.Name = "lbltag"
        Me.lbltag.Size = New System.Drawing.Size(0, 13)
        Me.lbltag.TabIndex = 83
        '
        'txt_Number
        '
        Me.txt_Number.Location = New System.Drawing.Point(338, 45)
        Me.txt_Number.MaxLength = 20
        Me.txt_Number.Name = "txt_Number"
        Me.txt_Number.Size = New System.Drawing.Size(90, 20)
        Me.txt_Number.TabIndex = 74
        '
        'lblNumber
        '
        Me.lblNumber.AutoSize = True
        Me.lblNumber.Location = New System.Drawing.Point(335, 29)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(93, 13)
        Me.lblNumber.TabIndex = 82
        Me.lblNumber.Text = "Employee Number"
        '
        'txt_Title
        '
        Me.txt_Title.Location = New System.Drawing.Point(11, 219)
        Me.txt_Title.MaxLength = 50
        Me.txt_Title.Name = "txt_Title"
        Me.txt_Title.Size = New System.Drawing.Size(416, 20)
        Me.txt_Title.TabIndex = 77
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(8, 201)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(47, 13)
        Me.lblTitle.TabIndex = 81
        Me.lblTitle.Text = "Job Title"
        '
        'cmb_LevelID
        '
        Me.cmb_LevelID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_LevelID.FormattingEnabled = True
        Me.cmb_LevelID.Items.AddRange(New Object() {"a"})
        Me.cmb_LevelID.Location = New System.Drawing.Point(12, 157)
        Me.cmb_LevelID.MaxDropDownItems = 15
        Me.cmb_LevelID.Name = "cmb_LevelID"
        Me.cmb_LevelID.Size = New System.Drawing.Size(182, 21)
        Me.cmb_LevelID.TabIndex = 76
        '
        'lblLevelID
        '
        Me.lblLevelID.AutoSize = True
        Me.lblLevelID.Location = New System.Drawing.Point(10, 141)
        Me.lblLevelID.Name = "lblLevelID"
        Me.lblLevelID.Size = New System.Drawing.Size(47, 13)
        Me.lblLevelID.TabIndex = 80
        Me.lblLevelID.Text = "Level ID"
        '
        'cmb_CompanyId
        '
        Me.cmb_CompanyId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_CompanyId.FormattingEnabled = True
        Me.cmb_CompanyId.Location = New System.Drawing.Point(201, 157)
        Me.cmb_CompanyId.Name = "cmb_CompanyId"
        Me.cmb_CompanyId.Size = New System.Drawing.Size(228, 21)
        Me.cmb_CompanyId.TabIndex = 79
        '
        'lblCompanyID
        '
        Me.lblCompanyID.AutoSize = True
        Me.lblCompanyID.Location = New System.Drawing.Point(198, 141)
        Me.lblCompanyID.Name = "lblCompanyID"
        Me.lblCompanyID.Size = New System.Drawing.Size(65, 13)
        Me.lblCompanyID.TabIndex = 78
        Me.lblCompanyID.Text = "Company ID"
        '
        'txt_UserID
        '
        Me.txt_UserID.Location = New System.Drawing.Point(11, 45)
        Me.txt_UserID.MaxLength = 10
        Me.txt_UserID.Name = "txt_UserID"
        Me.txt_UserID.Size = New System.Drawing.Size(83, 20)
        Me.txt_UserID.TabIndex = 73
        Me.txt_UserID.Visible = False
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Location = New System.Drawing.Point(8, 29)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(43, 13)
        Me.lblUserID.TabIndex = 75
        Me.lblUserID.Text = "User ID"
        '
        'txt_LastName
        '
        Me.txt_LastName.Location = New System.Drawing.Point(225, 103)
        Me.txt_LastName.MaxLength = 30
        Me.txt_LastName.Name = "txt_LastName"
        Me.txt_LastName.Size = New System.Drawing.Size(204, 20)
        Me.txt_LastName.TabIndex = 70
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(222, 87)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(58, 13)
        Me.lblLastName.TabIndex = 72
        Me.lblLastName.Text = "Last Name"
        '
        'txt_Initial
        '
        Me.txt_Initial.Location = New System.Drawing.Point(192, 103)
        Me.txt_Initial.MaxLength = 1
        Me.txt_Initial.Name = "txt_Initial"
        Me.txt_Initial.Size = New System.Drawing.Size(27, 20)
        Me.txt_Initial.TabIndex = 69
        '
        'lblInitial
        '
        Me.lblInitial.AutoSize = True
        Me.lblInitial.Location = New System.Drawing.Point(189, 87)
        Me.lblInitial.Name = "lblInitial"
        Me.lblInitial.Size = New System.Drawing.Size(19, 13)
        Me.lblInitial.TabIndex = 71
        Me.lblInitial.Text = "MI"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.Location = New System.Drawing.Point(8, 87)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(57, 13)
        Me.lblFirstName.TabIndex = 68
        Me.lblFirstName.Text = "First Name"
        '
        'txt_FirstName
        '
        Me.txt_FirstName.Location = New System.Drawing.Point(11, 103)
        Me.txt_FirstName.MaxLength = 30
        Me.txt_FirstName.Name = "txt_FirstName"
        Me.txt_FirstName.Size = New System.Drawing.Size(175, 20)
        Me.txt_FirstName.TabIndex = 67
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(188, 322)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 64
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(273, 322)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 63
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'lblEditName
        '
        Me.lblEditName.AutoSize = True
        Me.lblEditName.Location = New System.Drawing.Point(133, 81)
        Me.lblEditName.Name = "lblEditName"
        Me.lblEditName.Size = New System.Drawing.Size(0, 13)
        Me.lblEditName.TabIndex = 66
        Me.lblEditName.Visible = False
        '
        'TbpDiscipline
        '
        Me.TbpDiscipline.BackColor = System.Drawing.Color.Transparent
        Me.TbpDiscipline.Controls.Add(Me.Label2)
        Me.TbpDiscipline.Controls.Add(Me.Label1)
        Me.TbpDiscipline.Controls.Add(Me.btnDispAdd)
        Me.TbpDiscipline.Controls.Add(Me.btnRemove)
        Me.TbpDiscipline.Controls.Add(Me.lstSelected)
        Me.TbpDiscipline.Controls.Add(Me.lstAll)
        Me.TbpDiscipline.Location = New System.Drawing.Point(4, 22)
        Me.TbpDiscipline.Name = "TbpDiscipline"
        Me.TbpDiscipline.Size = New System.Drawing.Size(435, 351)
        Me.TbpDiscipline.TabIndex = 2
        Me.TbpDiscipline.Text = "Discipline"
        Me.TbpDiscipline.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(297, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Selected Disciplines"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Discipline List"
        '
        'btnDispAdd
        '
        Me.btnDispAdd.Location = New System.Drawing.Point(178, 102)
        Me.btnDispAdd.Name = "btnDispAdd"
        Me.btnDispAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnDispAdd.TabIndex = 8
        Me.btnDispAdd.Text = "Select"
        Me.btnDispAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(178, 146)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 7
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'lstSelected
        '
        Me.lstSelected.FormattingEnabled = True
        Me.lstSelected.Location = New System.Drawing.Point(300, 29)
        Me.lstSelected.Name = "lstSelected"
        Me.lstSelected.Size = New System.Drawing.Size(120, 264)
        Me.lstSelected.TabIndex = 5
        '
        'lstAll
        '
        Me.lstAll.FormattingEnabled = True
        Me.lstAll.Location = New System.Drawing.Point(15, 29)
        Me.lstAll.Name = "lstAll"
        Me.lstAll.Size = New System.Drawing.Size(120, 264)
        Me.lstAll.TabIndex = 4
        '
        'TbpGroup
        '
        Me.TbpGroup.BackColor = System.Drawing.Color.Transparent
        Me.TbpGroup.Controls.Add(Me.Label3)
        Me.TbpGroup.Controls.Add(Me.Label4)
        Me.TbpGroup.Controls.Add(Me.btnGrpAdd)
        Me.TbpGroup.Controls.Add(Me.btnGrpRemove)
        Me.TbpGroup.Controls.Add(Me.lstGrpSelect)
        Me.TbpGroup.Controls.Add(Me.lstGrpAll)
        Me.TbpGroup.Location = New System.Drawing.Point(4, 22)
        Me.TbpGroup.Name = "TbpGroup"
        Me.TbpGroup.Size = New System.Drawing.Size(435, 351)
        Me.TbpGroup.TabIndex = 3
        Me.TbpGroup.Text = "Group"
        Me.TbpGroup.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(289, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Selected Groups"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Groups List"
        '
        'btnGrpAdd
        '
        Me.btnGrpAdd.Location = New System.Drawing.Point(188, 129)
        Me.btnGrpAdd.Name = "btnGrpAdd"
        Me.btnGrpAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnGrpAdd.TabIndex = 12
        Me.btnGrpAdd.Text = "Select"
        Me.btnGrpAdd.UseVisualStyleBackColor = True
        '
        'btnGrpRemove
        '
        Me.btnGrpRemove.Location = New System.Drawing.Point(188, 175)
        Me.btnGrpRemove.Name = "btnGrpRemove"
        Me.btnGrpRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnGrpRemove.TabIndex = 11
        Me.btnGrpRemove.Text = "Remove"
        Me.btnGrpRemove.UseVisualStyleBackColor = True
        '
        'lstGrpSelect
        '
        Me.lstGrpSelect.FormattingEnabled = True
        Me.lstGrpSelect.Location = New System.Drawing.Point(292, 29)
        Me.lstGrpSelect.Name = "lstGrpSelect"
        Me.lstGrpSelect.Size = New System.Drawing.Size(127, 277)
        Me.lstGrpSelect.TabIndex = 10
        '
        'lstGrpAll
        '
        Me.lstGrpAll.FormattingEnabled = True
        Me.lstGrpAll.Location = New System.Drawing.Point(15, 29)
        Me.lstGrpAll.Name = "lstGrpAll"
        Me.lstGrpAll.Size = New System.Drawing.Size(141, 277)
        Me.lstGrpAll.TabIndex = 9
        '
        'TbpLevel
        '
        Me.TbpLevel.BackColor = System.Drawing.Color.Transparent
        Me.TbpLevel.Controls.Add(Me.Label5)
        Me.TbpLevel.Controls.Add(Me.Label6)
        Me.TbpLevel.Controls.Add(Me.btnlvlAdd)
        Me.TbpLevel.Controls.Add(Me.btnlvlRemove)
        Me.TbpLevel.Controls.Add(Me.lstLvlSelect)
        Me.TbpLevel.Controls.Add(Me.lstLvlAll)
        Me.TbpLevel.Location = New System.Drawing.Point(4, 22)
        Me.TbpLevel.Name = "TbpLevel"
        Me.TbpLevel.Size = New System.Drawing.Size(435, 351)
        Me.TbpLevel.TabIndex = 4
        Me.TbpLevel.Text = "Level"
        Me.TbpLevel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(296, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Selected Levels"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Levels List"
        '
        'btnlvlAdd
        '
        Me.btnlvlAdd.Location = New System.Drawing.Point(187, 103)
        Me.btnlvlAdd.Name = "btnlvlAdd"
        Me.btnlvlAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnlvlAdd.TabIndex = 12
        Me.btnlvlAdd.Text = "Select"
        Me.btnlvlAdd.UseVisualStyleBackColor = True
        '
        'btnlvlRemove
        '
        Me.btnlvlRemove.Location = New System.Drawing.Point(187, 149)
        Me.btnlvlRemove.Name = "btnlvlRemove"
        Me.btnlvlRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnlvlRemove.TabIndex = 11
        Me.btnlvlRemove.Text = "Remove"
        Me.btnlvlRemove.UseVisualStyleBackColor = True
        '
        'lstLvlSelect
        '
        Me.lstLvlSelect.FormattingEnabled = True
        Me.lstLvlSelect.Location = New System.Drawing.Point(299, 29)
        Me.lstLvlSelect.Name = "lstLvlSelect"
        Me.lstLvlSelect.Size = New System.Drawing.Size(120, 277)
        Me.lstLvlSelect.TabIndex = 10
        '
        'lstLvlAll
        '
        Me.lstLvlAll.FormattingEnabled = True
        Me.lstLvlAll.Location = New System.Drawing.Point(15, 29)
        Me.lstLvlAll.Name = "lstLvlAll"
        Me.lstLvlAll.Size = New System.Drawing.Size(120, 277)
        Me.lstLvlAll.TabIndex = 9
        '
        'TbpOwner
        '
        Me.TbpOwner.BackColor = System.Drawing.Color.Transparent
        Me.TbpOwner.Controls.Add(Me.Label7)
        Me.TbpOwner.Controls.Add(Me.Label8)
        Me.TbpOwner.Controls.Add(Me.btnOwnAdd)
        Me.TbpOwner.Controls.Add(Me.btnOwnRemove)
        Me.TbpOwner.Controls.Add(Me.lstOwnerSelect)
        Me.TbpOwner.Controls.Add(Me.lstOwnerAll)
        Me.TbpOwner.Location = New System.Drawing.Point(4, 22)
        Me.TbpOwner.Name = "TbpOwner"
        Me.TbpOwner.Size = New System.Drawing.Size(435, 351)
        Me.TbpOwner.TabIndex = 5
        Me.TbpOwner.Text = "Owner"
        Me.TbpOwner.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(285, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Selected Owners"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Owners List"
        '
        'btnOwnAdd
        '
        Me.btnOwnAdd.Location = New System.Drawing.Point(187, 119)
        Me.btnOwnAdd.Name = "btnOwnAdd"
        Me.btnOwnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnOwnAdd.TabIndex = 12
        Me.btnOwnAdd.Text = "Add"
        Me.btnOwnAdd.UseVisualStyleBackColor = True
        '
        'btnOwnRemove
        '
        Me.btnOwnRemove.Location = New System.Drawing.Point(187, 165)
        Me.btnOwnRemove.Name = "btnOwnRemove"
        Me.btnOwnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnOwnRemove.TabIndex = 11
        Me.btnOwnRemove.Text = "Remove"
        Me.btnOwnRemove.UseVisualStyleBackColor = True
        '
        'lstOwnerSelect
        '
        Me.lstOwnerSelect.FormattingEnabled = True
        Me.lstOwnerSelect.Location = New System.Drawing.Point(288, 29)
        Me.lstOwnerSelect.Name = "lstOwnerSelect"
        Me.lstOwnerSelect.Size = New System.Drawing.Size(132, 277)
        Me.lstOwnerSelect.TabIndex = 10
        '
        'lstOwnerAll
        '
        Me.lstOwnerAll.FormattingEnabled = True
        Me.lstOwnerAll.Location = New System.Drawing.Point(15, 29)
        Me.lstOwnerAll.Name = "lstOwnerAll"
        Me.lstOwnerAll.Size = New System.Drawing.Size(142, 277)
        Me.lstOwnerAll.TabIndex = 9
        '
        'tab_Projects
        '
        Me.tab_Projects.Controls.Add(Me.Label9)
        Me.tab_Projects.Controls.Add(Me.Label10)
        Me.tab_Projects.Controls.Add(Me.btn_SelectProject)
        Me.tab_Projects.Controls.Add(Me.btn_RemoveProject)
        Me.tab_Projects.Controls.Add(Me.lbx_SelectedProjects)
        Me.tab_Projects.Controls.Add(Me.lbx_ProjectList)
        Me.tab_Projects.Location = New System.Drawing.Point(4, 22)
        Me.tab_Projects.Name = "tab_Projects"
        Me.tab_Projects.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_Projects.Size = New System.Drawing.Size(435, 351)
        Me.tab_Projects.TabIndex = 6
        Me.tab_Projects.Text = "Projects"
        Me.tab_Projects.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(295, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Selected Projects"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Project List"
        '
        'btn_SelectProject
        '
        Me.btn_SelectProject.Location = New System.Drawing.Point(176, 116)
        Me.btn_SelectProject.Name = "btn_SelectProject"
        Me.btn_SelectProject.Size = New System.Drawing.Size(75, 23)
        Me.btn_SelectProject.TabIndex = 14
        Me.btn_SelectProject.Text = "Select"
        Me.btn_SelectProject.UseVisualStyleBackColor = True
        '
        'btn_RemoveProject
        '
        Me.btn_RemoveProject.Location = New System.Drawing.Point(176, 160)
        Me.btn_RemoveProject.Name = "btn_RemoveProject"
        Me.btn_RemoveProject.Size = New System.Drawing.Size(75, 23)
        Me.btn_RemoveProject.TabIndex = 13
        Me.btn_RemoveProject.Text = "Remove"
        Me.btn_RemoveProject.UseVisualStyleBackColor = True
        '
        'lbx_SelectedProjects
        '
        Me.lbx_SelectedProjects.FormattingEnabled = True
        Me.lbx_SelectedProjects.Location = New System.Drawing.Point(298, 43)
        Me.lbx_SelectedProjects.Name = "lbx_SelectedProjects"
        Me.lbx_SelectedProjects.Size = New System.Drawing.Size(120, 264)
        Me.lbx_SelectedProjects.TabIndex = 12
        '
        'lbx_ProjectList
        '
        Me.lbx_ProjectList.FormattingEnabled = True
        Me.lbx_ProjectList.Location = New System.Drawing.Point(13, 43)
        Me.lbx_ProjectList.Name = "lbx_ProjectList"
        Me.lbx_ProjectList.Size = New System.Drawing.Size(120, 264)
        Me.lbx_ProjectList.TabIndex = 11
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 401)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User"
        Me.TabControl1.ResumeLayout(False)
        Me.TbpGeneral.ResumeLayout(False)
        Me.TbpGeneral.PerformLayout()
        Me.TbpDiscipline.ResumeLayout(False)
        Me.TbpDiscipline.PerformLayout()
        Me.TbpGroup.ResumeLayout(False)
        Me.TbpGroup.PerformLayout()
        Me.TbpLevel.ResumeLayout(False)
        Me.TbpLevel.PerformLayout()
        Me.TbpOwner.ResumeLayout(False)
        Me.TbpOwner.PerformLayout()
        Me.tab_Projects.ResumeLayout(False)
        Me.tab_Projects.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TbpGeneral As System.Windows.Forms.TabPage
    Friend WithEvents txt_Number As System.Windows.Forms.TextBox
    Friend WithEvents lblNumber As System.Windows.Forms.Label
    Friend WithEvents txt_Title As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cmb_LevelID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLevelID As System.Windows.Forms.Label
    Friend WithEvents cmb_CompanyId As System.Windows.Forms.ComboBox
    Friend WithEvents lblCompanyID As System.Windows.Forms.Label
    Friend WithEvents txt_UserID As System.Windows.Forms.TextBox
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents txt_LastName As System.Windows.Forms.TextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents txt_Initial As System.Windows.Forms.TextBox
    Friend WithEvents lblInitial As System.Windows.Forms.Label
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents txt_FirstName As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents lblEditName As System.Windows.Forms.Label
    Friend WithEvents TbpDiscipline As System.Windows.Forms.TabPage
    Friend WithEvents btnDispAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents lstSelected As System.Windows.Forms.ListBox
    Friend WithEvents lstAll As System.Windows.Forms.ListBox
    Friend WithEvents TbpGroup As System.Windows.Forms.TabPage
    Friend WithEvents btnGrpAdd As System.Windows.Forms.Button
    Friend WithEvents btnGrpRemove As System.Windows.Forms.Button
    Friend WithEvents lstGrpSelect As System.Windows.Forms.ListBox
    Friend WithEvents lstGrpAll As System.Windows.Forms.ListBox
    Friend WithEvents TbpLevel As System.Windows.Forms.TabPage
    Friend WithEvents btnlvlAdd As System.Windows.Forms.Button
    Friend WithEvents btnlvlRemove As System.Windows.Forms.Button
    Friend WithEvents lstLvlSelect As System.Windows.Forms.ListBox
    Friend WithEvents lstLvlAll As System.Windows.Forms.ListBox
    Friend WithEvents TbpOwner As System.Windows.Forms.TabPage
    Friend WithEvents btnOwnAdd As System.Windows.Forms.Button
    Friend WithEvents btnOwnRemove As System.Windows.Forms.Button
    Friend WithEvents lstOwnerSelect As System.Windows.Forms.ListBox
    Friend WithEvents lstOwnerAll As System.Windows.Forms.ListBox
    Friend WithEvents lbltag As System.Windows.Forms.Label
    Friend WithEvents txt_UserName As System.Windows.Forms.TextBox
    Friend WithEvents btn_Apply As System.Windows.Forms.Button
    Friend WithEvents chk_Active As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_ResetPassword As System.Windows.Forms.Button
    Friend WithEvents tab_Projects As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_SelectProject As System.Windows.Forms.Button
    Friend WithEvents btn_RemoveProject As System.Windows.Forms.Button
    Friend WithEvents lbx_SelectedProjects As System.Windows.Forms.ListBox
    Friend WithEvents lbx_ProjectList As System.Windows.Forms.ListBox
End Class
