<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.userid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.password = New System.Windows.Forms.TextBox()
        Me.loginButton = New System.Windows.Forms.Button()
        Me.exitButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.siteList = New System.Windows.Forms.ComboBox()
        Me.eula = New System.Windows.Forms.TextBox()
        Me.advancedButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_SqlPort = New System.Windows.Forms.Label()
        Me.tbx_SqlPort = New System.Windows.Forms.TextBox()
        Me.tbx_SQLMachine = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.IISvDir = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbx_SQLInstance = New System.Windows.Forms.TextBox()
        Me.tbx_SQLIP = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.siteAdd = New System.Windows.Forms.Button()
        Me.tbx_SiteName = New System.Windows.Forms.TextBox()
        Me.tbx_IISPort = New System.Windows.Forms.TextBox()
        Me.tbx_IISIP = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.siteDeleteList = New System.Windows.Forms.ListBox()
        Me.siteDelete = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbx_ConnectMode = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ImportSite = New System.Windows.Forms.Button()
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'userid
        '
        Me.userid.Location = New System.Drawing.Point(86, 16)
        Me.userid.Name = "userid"
        Me.userid.Size = New System.Drawing.Size(121, 20)
        Me.userid.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "User Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password"
        '
        'password
        '
        Me.password.Location = New System.Drawing.Point(86, 42)
        Me.password.Name = "password"
        Me.password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.password.Size = New System.Drawing.Size(121, 20)
        Me.password.TabIndex = 2
        '
        'loginButton
        '
        Me.loginButton.Enabled = False
        Me.loginButton.Location = New System.Drawing.Point(317, 581)
        Me.loginButton.Name = "loginButton"
        Me.loginButton.Size = New System.Drawing.Size(75, 25)
        Me.loginButton.TabIndex = 4
        Me.loginButton.Text = "Login"
        Me.loginButton.UseVisualStyleBackColor = True
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(398, 581)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(75, 25)
        Me.exitButton.TabIndex = 5
        Me.exitButton.Text = "Cancel"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(223, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Select Site"
        '
        'siteList
        '
        Me.siteList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.siteList.FormattingEnabled = True
        Me.siteList.Location = New System.Drawing.Point(297, 15)
        Me.siteList.Name = "siteList"
        Me.siteList.Size = New System.Drawing.Size(155, 21)
        Me.siteList.TabIndex = 7
        '
        'eula
        '
        Me.eula.Location = New System.Drawing.Point(16, 66)
        Me.eula.Multiline = True
        Me.eula.Name = "eula"
        Me.eula.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.eula.Size = New System.Drawing.Size(457, 117)
        Me.eula.TabIndex = 8
        '
        'advancedButton
        '
        Me.advancedButton.Location = New System.Drawing.Point(12, 581)
        Me.advancedButton.Name = "advancedButton"
        Me.advancedButton.Size = New System.Drawing.Size(75, 25)
        Me.advancedButton.TabIndex = 9
        Me.advancedButton.Text = "Advanced +"
        Me.advancedButton.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(65, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(342, 79)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_SqlPort)
        Me.GroupBox1.Controls.Add(Me.tbx_SqlPort)
        Me.GroupBox1.Controls.Add(Me.tbx_SQLMachine)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.IISvDir)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tbx_SQLInstance)
        Me.GroupBox1.Controls.Add(Me.tbx_SQLIP)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.siteAdd)
        Me.GroupBox1.Controls.Add(Me.tbx_SiteName)
        Me.GroupBox1.Controls.Add(Me.tbx_IISPort)
        Me.GroupBox1.Controls.Add(Me.tbx_IISIP)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 323)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 155)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Site Connection"
        Me.GroupBox1.Visible = False
        '
        'lbl_SqlPort
        '
        Me.lbl_SqlPort.AutoSize = True
        Me.lbl_SqlPort.Location = New System.Drawing.Point(291, 79)
        Me.lbl_SqlPort.Name = "lbl_SqlPort"
        Me.lbl_SqlPort.Size = New System.Drawing.Size(50, 13)
        Me.lbl_SqlPort.TabIndex = 16
        Me.lbl_SqlPort.Text = "SQL Port"
        '
        'tbx_SqlPort
        '
        Me.tbx_SqlPort.Location = New System.Drawing.Point(342, 71)
        Me.tbx_SqlPort.Name = "tbx_SqlPort"
        Me.tbx_SqlPort.Size = New System.Drawing.Size(100, 20)
        Me.tbx_SqlPort.TabIndex = 15
        Me.tbx_SqlPort.Text = "2786"
        '
        'tbx_SQLMachine
        '
        Me.tbx_SQLMachine.Location = New System.Drawing.Point(86, 97)
        Me.tbx_SQLMachine.Name = "tbx_SQLMachine"
        Me.tbx_SQLMachine.Size = New System.Drawing.Size(178, 20)
        Me.tbx_SQLMachine.TabIndex = 14
        Me.tbx_SQLMachine.Text = "L001-DS002"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "SQL PC Name"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Location = New System.Drawing.Point(294, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "vDir"
        Me.Label9.Visible = False
        '
        'IISvDir
        '
        Me.IISvDir.BackColor = System.Drawing.Color.Red
        Me.IISvDir.Location = New System.Drawing.Point(342, 19)
        Me.IISvDir.Name = "IISvDir"
        Me.IISvDir.Size = New System.Drawing.Size(100, 20)
        Me.IISvDir.TabIndex = 11
        Me.IISvDir.Text = "Daqart"
        Me.IISvDir.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "SQL Instance"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "SQL IP"
        '
        'tbx_SQLInstance
        '
        Me.tbx_SQLInstance.Location = New System.Drawing.Point(86, 123)
        Me.tbx_SQLInstance.Name = "tbx_SQLInstance"
        Me.tbx_SQLInstance.Size = New System.Drawing.Size(178, 20)
        Me.tbx_SQLInstance.TabIndex = 8
        Me.tbx_SQLInstance.Text = "DAQART"
        '
        'tbx_SQLIP
        '
        Me.tbx_SQLIP.Location = New System.Drawing.Point(86, 71)
        Me.tbx_SQLIP.Name = "tbx_SQLIP"
        Me.tbx_SQLIP.Size = New System.Drawing.Size(178, 20)
        Me.tbx_SQLIP.TabIndex = 7
        Me.tbx_SQLIP.Text = "70.155.147.26"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(291, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "IIS Port"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Site Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "IIS IP"
        '
        'siteAdd
        '
        Me.siteAdd.Enabled = False
        Me.siteAdd.Location = New System.Drawing.Point(346, 120)
        Me.siteAdd.Name = "siteAdd"
        Me.siteAdd.Size = New System.Drawing.Size(96, 25)
        Me.siteAdd.TabIndex = 3
        Me.siteAdd.Text = "Add Site"
        Me.siteAdd.UseVisualStyleBackColor = True
        '
        'tbx_SiteName
        '
        Me.tbx_SiteName.Location = New System.Drawing.Point(86, 19)
        Me.tbx_SiteName.Name = "tbx_SiteName"
        Me.tbx_SiteName.Size = New System.Drawing.Size(178, 20)
        Me.tbx_SiteName.TabIndex = 2
        '
        'tbx_IISPort
        '
        Me.tbx_IISPort.Location = New System.Drawing.Point(342, 45)
        Me.tbx_IISPort.Name = "tbx_IISPort"
        Me.tbx_IISPort.Size = New System.Drawing.Size(100, 20)
        Me.tbx_IISPort.TabIndex = 1
        Me.tbx_IISPort.Text = "8088"
        '
        'tbx_IISIP
        '
        Me.tbx_IISIP.Location = New System.Drawing.Point(86, 45)
        Me.tbx_IISIP.Name = "tbx_IISIP"
        Me.tbx_IISIP.Size = New System.Drawing.Size(178, 20)
        Me.tbx_IISIP.TabIndex = 0
        Me.tbx_IISIP.Text = "70.155.147.26"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.siteDeleteList)
        Me.GroupBox2.Controls.Add(Me.siteDelete)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 484)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(458, 91)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Delete Site Connection"
        Me.GroupBox2.Visible = False
        '
        'siteDeleteList
        '
        Me.siteDeleteList.FormattingEnabled = True
        Me.siteDeleteList.Location = New System.Drawing.Point(23, 19)
        Me.siteDeleteList.Name = "siteDeleteList"
        Me.siteDeleteList.ScrollAlwaysVisible = True
        Me.siteDeleteList.Size = New System.Drawing.Size(241, 56)
        Me.siteDeleteList.TabIndex = 5
        '
        'siteDelete
        '
        Me.siteDelete.Enabled = False
        Me.siteDelete.Location = New System.Drawing.Point(338, 58)
        Me.siteDelete.Name = "siteDelete"
        Me.siteDelete.Size = New System.Drawing.Size(96, 25)
        Me.siteDelete.TabIndex = 4
        Me.siteDelete.Text = "Delete Site(s)"
        Me.siteDelete.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.cbx_ConnectMode)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.ImportSite)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.userid)
        Me.GroupBox3.Controls.Add(Me.password)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.siteList)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 189)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(458, 128)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Logon Info"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(321, 75)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'cbx_ConnectMode
        '
        Me.cbx_ConnectMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ConnectMode.FormattingEnabled = True
        Me.cbx_ConnectMode.Items.AddRange(New Object() {"Online", "Offline"})
        Me.cbx_ConnectMode.Location = New System.Drawing.Point(86, 67)
        Me.cbx_ConnectMode.Name = "cbx_ConnectMode"
        Me.cbx_ConnectMode.Size = New System.Drawing.Size(121, 21)
        Me.cbx_ConnectMode.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Default Mode"
        '
        'ImportSite
        '
        Me.ImportSite.Location = New System.Drawing.Point(321, 42)
        Me.ImportSite.Name = "ImportSite"
        Me.ImportSite.Size = New System.Drawing.Size(104, 23)
        Me.ImportSite.TabIndex = 8
        Me.ImportSite.Text = "Import Site Profile"
        Me.ImportSite.UseVisualStyleBackColor = True
        '
        'ofd1
        '
        Me.ofd1.FileName = "OpenFileDialog1"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 618)
        Me.ControlBox = False
        Me.Controls.Add(Me.eula)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.advancedButton)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.loginButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dempsey Is in Control"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents userid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents password As System.Windows.Forms.TextBox
    Friend WithEvents loginButton As System.Windows.Forms.Button
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents siteList As System.Windows.Forms.ComboBox
    Friend WithEvents eula As System.Windows.Forms.TextBox
    Friend WithEvents advancedButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents siteAdd As System.Windows.Forms.Button
    Friend WithEvents tbx_SiteName As System.Windows.Forms.TextBox
    Friend WithEvents tbx_IISPort As System.Windows.Forms.TextBox
    Friend WithEvents tbx_IISIP As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents siteDelete As System.Windows.Forms.Button
    Friend WithEvents siteDeleteList As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbx_SQLInstance As System.Windows.Forms.TextBox
    Friend WithEvents tbx_SQLIP As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents IISvDir As System.Windows.Forms.TextBox
    Friend WithEvents tbx_SQLMachine As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ImportSite As System.Windows.Forms.Button
    Friend WithEvents lbl_SqlPort As System.Windows.Forms.Label
    Friend WithEvents tbx_SqlPort As System.Windows.Forms.TextBox
    Friend WithEvents cbx_ConnectMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ofd1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
