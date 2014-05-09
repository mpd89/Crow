<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUser
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
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_Add = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.txt_Number = New System.Windows.Forms.TextBox
        Me.txt_Title = New System.Windows.Forms.TextBox
        Me.cmb_LevelID = New System.Windows.Forms.ComboBox
        Me.txt_Password2 = New System.Windows.Forms.TextBox
        Me.lblRPassword = New System.Windows.Forms.Label
        Me.txt_Password = New System.Windows.Forms.TextBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.cmb_CompanyId = New System.Windows.Forms.ComboBox
        Me.txt_UserID = New System.Windows.Forms.TextBox
        Me.lblUserID = New System.Windows.Forms.Label
        Me.txt_LastName = New System.Windows.Forms.TextBox
        Me.txt_Initial = New System.Windows.Forms.TextBox
        Me.txt_FirstName = New System.Windows.Forms.TextBox
        Me.chk_Active = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(286, 402)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 17
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Add
        '
        Me.btn_Add.Enabled = False
        Me.btn_Add.Location = New System.Drawing.Point(367, 402)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(75, 23)
        Me.btn_Add.TabIndex = 16
        Me.btn_Add.Text = "Add"
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chk_Active)
        Me.Panel1.Controls.Add(Me.TextBox6)
        Me.Panel1.Controls.Add(Me.TextBox7)
        Me.Panel1.Controls.Add(Me.TextBox5)
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.txt_Number)
        Me.Panel1.Controls.Add(Me.txt_Title)
        Me.Panel1.Controls.Add(Me.cmb_LevelID)
        Me.Panel1.Controls.Add(Me.txt_Password2)
        Me.Panel1.Controls.Add(Me.lblRPassword)
        Me.Panel1.Controls.Add(Me.txt_Password)
        Me.Panel1.Controls.Add(Me.lblPassword)
        Me.Panel1.Controls.Add(Me.cmb_CompanyId)
        Me.Panel1.Controls.Add(Me.txt_UserID)
        Me.Panel1.Controls.Add(Me.lblUserID)
        Me.Panel1.Controls.Add(Me.txt_LastName)
        Me.Panel1.Controls.Add(Me.txt_Initial)
        Me.Panel1.Controls.Add(Me.txt_FirstName)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(428, 384)
        Me.Panel1.TabIndex = 15
        '
        'TextBox6
        '
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox6.Location = New System.Drawing.Point(173, 87)
        Me.TextBox6.MaxLength = 30
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(241, 20)
        Me.TextBox6.TabIndex = 27
        Me.TextBox6.TabStop = False
        Me.TextBox6.Text = "Job Title"
        '
        'TextBox7
        '
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox7.Location = New System.Drawing.Point(14, 87)
        Me.TextBox7.MaxLength = 30
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(160, 20)
        Me.TextBox7.TabIndex = 26
        Me.TextBox7.TabStop = False
        Me.TextBox7.Text = "Employee Number"
        '
        'TextBox5
        '
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.Location = New System.Drawing.Point(173, 48)
        Me.TextBox5.MaxLength = 30
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(241, 20)
        Me.TextBox5.TabIndex = 25
        Me.TextBox5.TabStop = False
        Me.TextBox5.Text = "Company"
        '
        'TextBox4
        '
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Location = New System.Drawing.Point(14, 48)
        Me.TextBox4.MaxLength = 30
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(160, 20)
        Me.TextBox4.TabIndex = 24
        Me.TextBox4.TabStop = False
        Me.TextBox4.Text = "User Primary Level"
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Location = New System.Drawing.Point(173, 10)
        Me.TextBox3.MaxLength = 30
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(241, 20)
        Me.TextBox3.TabIndex = 23
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = "Last Name"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(145, 10)
        Me.TextBox2.MaxLength = 30
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(29, 20)
        Me.TextBox2.TabIndex = 22
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = "MI"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(14, 10)
        Me.TextBox1.MaxLength = 30
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(132, 20)
        Me.TextBox1.TabIndex = 21
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "First Name"
        '
        'txt_Number
        '
        Me.txt_Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Number.Location = New System.Drawing.Point(14, 106)
        Me.txt_Number.MaxLength = 20
        Me.txt_Number.Name = "txt_Number"
        Me.txt_Number.Size = New System.Drawing.Size(160, 20)
        Me.txt_Number.TabIndex = 5
        '
        'txt_Title
        '
        Me.txt_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Title.Location = New System.Drawing.Point(173, 106)
        Me.txt_Title.MaxLength = 50
        Me.txt_Title.Name = "txt_Title"
        Me.txt_Title.Size = New System.Drawing.Size(241, 20)
        Me.txt_Title.TabIndex = 9
        '
        'cmb_LevelID
        '
        Me.cmb_LevelID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_LevelID.FormattingEnabled = True
        Me.cmb_LevelID.Items.AddRange(New Object() {"a"})
        Me.cmb_LevelID.Location = New System.Drawing.Point(14, 67)
        Me.cmb_LevelID.MaxDropDownItems = 15
        Me.cmb_LevelID.Name = "cmb_LevelID"
        Me.cmb_LevelID.Size = New System.Drawing.Size(160, 21)
        Me.cmb_LevelID.TabIndex = 8
        '
        'txt_Password2
        '
        Me.txt_Password2.Location = New System.Drawing.Point(173, 262)
        Me.txt_Password2.MaxLength = 10
        Me.txt_Password2.Name = "txt_Password2"
        Me.txt_Password2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Password2.Size = New System.Drawing.Size(182, 20)
        Me.txt_Password2.TabIndex = 7
        '
        'lblRPassword
        '
        Me.lblRPassword.AutoSize = True
        Me.lblRPassword.Location = New System.Drawing.Point(66, 265)
        Me.lblRPassword.Name = "lblRPassword"
        Me.lblRPassword.Size = New System.Drawing.Size(91, 13)
        Me.lblRPassword.TabIndex = 14
        Me.lblRPassword.Text = "Confirm Password"
        '
        'txt_Password
        '
        Me.txt_Password.Location = New System.Drawing.Point(173, 217)
        Me.txt_Password.MaxLength = 10
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Password.Size = New System.Drawing.Size(182, 20)
        Me.txt_Password.TabIndex = 6
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(104, 224)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 12
        Me.lblPassword.Text = "Password"
        '
        'cmb_CompanyId
        '
        Me.cmb_CompanyId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_CompanyId.FormattingEnabled = True
        Me.cmb_CompanyId.Location = New System.Drawing.Point(173, 67)
        Me.cmb_CompanyId.Name = "cmb_CompanyId"
        Me.cmb_CompanyId.Size = New System.Drawing.Size(241, 21)
        Me.cmb_CompanyId.TabIndex = 10
        '
        'txt_UserID
        '
        Me.txt_UserID.Location = New System.Drawing.Point(173, 172)
        Me.txt_UserID.MaxLength = 10
        Me.txt_UserID.Name = "txt_UserID"
        Me.txt_UserID.ReadOnly = True
        Me.txt_UserID.Size = New System.Drawing.Size(182, 20)
        Me.txt_UserID.TabIndex = 4
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Location = New System.Drawing.Point(114, 179)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(43, 13)
        Me.lblUserID.TabIndex = 8
        Me.lblUserID.Text = "User ID"
        '
        'txt_LastName
        '
        Me.txt_LastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_LastName.Location = New System.Drawing.Point(173, 29)
        Me.txt_LastName.MaxLength = 30
        Me.txt_LastName.Name = "txt_LastName"
        Me.txt_LastName.Size = New System.Drawing.Size(241, 20)
        Me.txt_LastName.TabIndex = 3
        '
        'txt_Initial
        '
        Me.txt_Initial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Initial.Location = New System.Drawing.Point(145, 29)
        Me.txt_Initial.MaxLength = 1
        Me.txt_Initial.Name = "txt_Initial"
        Me.txt_Initial.Size = New System.Drawing.Size(29, 20)
        Me.txt_Initial.TabIndex = 2
        '
        'txt_FirstName
        '
        Me.txt_FirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_FirstName.Location = New System.Drawing.Point(14, 29)
        Me.txt_FirstName.MaxLength = 30
        Me.txt_FirstName.Name = "txt_FirstName"
        Me.txt_FirstName.Size = New System.Drawing.Size(132, 20)
        Me.txt_FirstName.TabIndex = 1
        '
        'chk_Active
        '
        Me.chk_Active.AutoSize = True
        Me.chk_Active.Location = New System.Drawing.Point(173, 322)
        Me.chk_Active.Name = "chk_Active"
        Me.chk_Active.Size = New System.Drawing.Size(56, 17)
        Me.chk_Active.TabIndex = 87
        Me.chk_Active.Text = "Active"
        Me.chk_Active.UseVisualStyleBackColor = True
        '
        'AddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MintCream
        Me.ClientSize = New System.Drawing.Size(452, 437)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Add)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "AddUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddUser"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Add As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txt_Number As System.Windows.Forms.TextBox
    Friend WithEvents txt_Title As System.Windows.Forms.TextBox
    Friend WithEvents cmb_LevelID As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Password2 As System.Windows.Forms.TextBox
    Friend WithEvents lblRPassword As System.Windows.Forms.Label
    Friend WithEvents txt_Password As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents cmb_CompanyId As System.Windows.Forms.ComboBox
    Friend WithEvents txt_UserID As System.Windows.Forms.TextBox
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents txt_LastName As System.Windows.Forms.TextBox
    Friend WithEvents txt_Initial As System.Windows.Forms.TextBox
    Friend WithEvents txt_FirstName As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents chk_Active As System.Windows.Forms.CheckBox
End Class
