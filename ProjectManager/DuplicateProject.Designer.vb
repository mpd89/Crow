<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DuplicateProject
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tbx_ProjectLocation = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbx_ProjectName = New System.Windows.Forms.TextBox
        Me.tbx_ProjectDescription = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btn_Duplicate = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.lbl_Project = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbx_ProjectLocation)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbx_ProjectName)
        Me.GroupBox1.Controls.Add(Me.tbx_ProjectDescription)
        Me.GroupBox1.Location = New System.Drawing.Point(34, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 213)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New Project Info"
        '
        'tbx_ProjectLocation
        '
        Me.tbx_ProjectLocation.Location = New System.Drawing.Point(103, 136)
        Me.tbx_ProjectLocation.MaxLength = 100
        Me.tbx_ProjectLocation.Multiline = True
        Me.tbx_ProjectLocation.Name = "tbx_ProjectLocation"
        Me.tbx_ProjectLocation.Size = New System.Drawing.Size(185, 61)
        Me.tbx_ProjectLocation.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Project Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Location"
        '
        'tbx_ProjectName
        '
        Me.tbx_ProjectName.Location = New System.Drawing.Point(103, 22)
        Me.tbx_ProjectName.MaxLength = 50
        Me.tbx_ProjectName.Name = "tbx_ProjectName"
        Me.tbx_ProjectName.Size = New System.Drawing.Size(185, 20)
        Me.tbx_ProjectName.TabIndex = 3
        '
        'tbx_ProjectDescription
        '
        Me.tbx_ProjectDescription.Location = New System.Drawing.Point(103, 59)
        Me.tbx_ProjectDescription.MaxLength = 100
        Me.tbx_ProjectDescription.Multiline = True
        Me.tbx_ProjectDescription.Name = "tbx_ProjectDescription"
        Me.tbx_ProjectDescription.Size = New System.Drawing.Size(185, 61)
        Me.tbx_ProjectDescription.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(60, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(281, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "You have chosen to duplicate the following project:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ProjectManager.My.Resources.Resources.icon_alert
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(44, 29)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'btn_Duplicate
        '
        Me.btn_Duplicate.Location = New System.Drawing.Point(271, 315)
        Me.btn_Duplicate.Name = "btn_Duplicate"
        Me.btn_Duplicate.Size = New System.Drawing.Size(75, 23)
        Me.btn_Duplicate.TabIndex = 14
        Me.btn_Duplicate.Text = "Duplicate"
        Me.btn_Duplicate.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(190, 315)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 15
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'lbl_Project
        '
        Me.lbl_Project.AutoSize = True
        Me.lbl_Project.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Project.Location = New System.Drawing.Point(146, 57)
        Me.lbl_Project.Name = "lbl_Project"
        Me.lbl_Project.Size = New System.Drawing.Size(45, 13)
        Me.lbl_Project.TabIndex = 16
        Me.lbl_Project.Text = "Label5"
        '
        'DuplicateProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 359)
        Me.Controls.Add(Me.lbl_Project)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Duplicate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DuplicateProject"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Duplicate Project"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbx_ProjectLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbx_ProjectName As System.Windows.Forms.TextBox
    Friend WithEvents tbx_ProjectDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Duplicate As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents lbl_Project As System.Windows.Forms.Label
End Class
