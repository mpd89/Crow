<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUser
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
        Me.cbx_LevelID = New System.Windows.Forms.ComboBox
        Me.lblLevelID = New System.Windows.Forms.Label
        Me.cbx_CompanyId = New System.Windows.Forms.ComboBox
        Me.lblCompanyID = New System.Windows.Forms.Label
        Me.lbltag = New System.Windows.Forms.Label
        Me.tbx_LastName = New System.Windows.Forms.TextBox
        Me.lblLastName = New System.Windows.Forms.Label
        Me.tbx_Initial = New System.Windows.Forms.TextBox
        Me.lblInitial = New System.Windows.Forms.Label
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.tbx_FirstName = New System.Windows.Forms.TextBox
        Me.txt_Number = New System.Windows.Forms.TextBox
        Me.lblNumber = New System.Windows.Forms.Label
        Me.txt_Title = New System.Windows.Forms.TextBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cbx_LevelID
        '
        Me.cbx_LevelID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_LevelID.FormattingEnabled = True
        Me.cbx_LevelID.Items.AddRange(New Object() {"a"})
        Me.cbx_LevelID.Location = New System.Drawing.Point(25, 72)
        Me.cbx_LevelID.MaxDropDownItems = 15
        Me.cbx_LevelID.Name = "cbx_LevelID"
        Me.cbx_LevelID.Size = New System.Drawing.Size(182, 21)
        Me.cbx_LevelID.TabIndex = 103
        '
        'lblLevelID
        '
        Me.lblLevelID.AutoSize = True
        Me.lblLevelID.Location = New System.Drawing.Point(23, 56)
        Me.lblLevelID.Name = "lblLevelID"
        Me.lblLevelID.Size = New System.Drawing.Size(47, 13)
        Me.lblLevelID.TabIndex = 106
        Me.lblLevelID.Text = "Level ID"
        '
        'cbx_CompanyId
        '
        Me.cbx_CompanyId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_CompanyId.FormattingEnabled = True
        Me.cbx_CompanyId.Location = New System.Drawing.Point(214, 72)
        Me.cbx_CompanyId.Name = "cbx_CompanyId"
        Me.cbx_CompanyId.Size = New System.Drawing.Size(228, 21)
        Me.cbx_CompanyId.TabIndex = 105
        '
        'lblCompanyID
        '
        Me.lblCompanyID.AutoSize = True
        Me.lblCompanyID.Location = New System.Drawing.Point(211, 56)
        Me.lblCompanyID.Name = "lblCompanyID"
        Me.lblCompanyID.Size = New System.Drawing.Size(65, 13)
        Me.lblCompanyID.TabIndex = 104
        Me.lblCompanyID.Text = "Company ID"
        '
        'lbltag
        '
        Me.lbltag.AutoSize = True
        Me.lbltag.Location = New System.Drawing.Point(256, 16)
        Me.lbltag.Name = "lbltag"
        Me.lbltag.Size = New System.Drawing.Size(0, 13)
        Me.lbltag.TabIndex = 102
        '
        'tbx_LastName
        '
        Me.tbx_LastName.Location = New System.Drawing.Point(239, 33)
        Me.tbx_LastName.MaxLength = 30
        Me.tbx_LastName.Name = "tbx_LastName"
        Me.tbx_LastName.Size = New System.Drawing.Size(204, 20)
        Me.tbx_LastName.TabIndex = 99
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(236, 17)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(58, 13)
        Me.lblLastName.TabIndex = 101
        Me.lblLastName.Text = "Last Name"
        '
        'tbx_Initial
        '
        Me.tbx_Initial.Location = New System.Drawing.Point(206, 33)
        Me.tbx_Initial.MaxLength = 1
        Me.tbx_Initial.Name = "tbx_Initial"
        Me.tbx_Initial.Size = New System.Drawing.Size(27, 20)
        Me.tbx_Initial.TabIndex = 98
        '
        'lblInitial
        '
        Me.lblInitial.AutoSize = True
        Me.lblInitial.Location = New System.Drawing.Point(203, 17)
        Me.lblInitial.Name = "lblInitial"
        Me.lblInitial.Size = New System.Drawing.Size(19, 13)
        Me.lblInitial.TabIndex = 100
        Me.lblInitial.Text = "MI"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.Location = New System.Drawing.Point(22, 17)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(57, 13)
        Me.lblFirstName.TabIndex = 97
        Me.lblFirstName.Text = "First Name"
        '
        'tbx_FirstName
        '
        Me.tbx_FirstName.Location = New System.Drawing.Point(25, 33)
        Me.tbx_FirstName.MaxLength = 30
        Me.tbx_FirstName.Name = "tbx_FirstName"
        Me.tbx_FirstName.Size = New System.Drawing.Size(175, 20)
        Me.tbx_FirstName.TabIndex = 96
        '
        'txt_Number
        '
        Me.txt_Number.Location = New System.Drawing.Point(25, 121)
        Me.txt_Number.MaxLength = 20
        Me.txt_Number.Name = "txt_Number"
        Me.txt_Number.Size = New System.Drawing.Size(90, 20)
        Me.txt_Number.TabIndex = 107
        '
        'lblNumber
        '
        Me.lblNumber.AutoSize = True
        Me.lblNumber.Location = New System.Drawing.Point(22, 105)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(93, 13)
        Me.lblNumber.TabIndex = 108
        Me.lblNumber.Text = "Employee Number"
        '
        'txt_Title
        '
        Me.txt_Title.Location = New System.Drawing.Point(121, 121)
        Me.txt_Title.MaxLength = 50
        Me.txt_Title.Name = "txt_Title"
        Me.txt_Title.Size = New System.Drawing.Size(321, 20)
        Me.txt_Title.TabIndex = 109
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(121, 105)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(47, 13)
        Me.lblTitle.TabIndex = 110
        Me.lblTitle.Text = "Job Title"
        '
        'btn_OK
        '
        Me.btn_OK.Enabled = False
        Me.btn_OK.Location = New System.Drawing.Point(367, 164)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 112
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(286, 164)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 111
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'AddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 199)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.txt_Title)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txt_Number)
        Me.Controls.Add(Me.lblNumber)
        Me.Controls.Add(Me.cbx_LevelID)
        Me.Controls.Add(Me.lblLevelID)
        Me.Controls.Add(Me.cbx_CompanyId)
        Me.Controls.Add(Me.lblCompanyID)
        Me.Controls.Add(Me.lbltag)
        Me.Controls.Add(Me.tbx_LastName)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.tbx_Initial)
        Me.Controls.Add(Me.lblInitial)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.tbx_FirstName)
        Me.Name = "AddUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbx_LevelID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLevelID As System.Windows.Forms.Label
    Friend WithEvents cbx_CompanyId As System.Windows.Forms.ComboBox
    Friend WithEvents lblCompanyID As System.Windows.Forms.Label
    Friend WithEvents lbltag As System.Windows.Forms.Label
    Friend WithEvents tbx_LastName As System.Windows.Forms.TextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents tbx_Initial As System.Windows.Forms.TextBox
    Friend WithEvents lblInitial As System.Windows.Forms.Label
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents tbx_FirstName As System.Windows.Forms.TextBox
    Friend WithEvents txt_Number As System.Windows.Forms.TextBox
    Friend WithEvents lblNumber As System.Windows.Forms.Label
    Friend WithEvents txt_Title As System.Windows.Forms.TextBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
End Class
