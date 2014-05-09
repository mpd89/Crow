<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateProject
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ProjectName = New System.Windows.Forms.TextBox
        Me.ProjectDescription = New System.Windows.Forms.TextBox
        Me.ProjectLocation = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ProjectNext1 = New System.Windows.Forms.Button
        Me.ProjectCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ProjectPanel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ProjectPanel2 = New System.Windows.Forms.Panel
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.ExecutedSQL = New System.Windows.Forms.CheckedListBox
        Me.GroupBox1.SuspendLayout()
        Me.ProjectPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProjectPanel2.SuspendLayout()
        Me.SuspendLayout()
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
        'ProjectName
        '
        Me.ProjectName.Location = New System.Drawing.Point(103, 22)
        Me.ProjectName.MaxLength = 50
        Me.ProjectName.Name = "ProjectName"
        Me.ProjectName.Size = New System.Drawing.Size(185, 20)
        Me.ProjectName.TabIndex = 3
        '
        'ProjectDescription
        '
        Me.ProjectDescription.Location = New System.Drawing.Point(103, 59)
        Me.ProjectDescription.MaxLength = 100
        Me.ProjectDescription.Multiline = True
        Me.ProjectDescription.Name = "ProjectDescription"
        Me.ProjectDescription.Size = New System.Drawing.Size(185, 61)
        Me.ProjectDescription.TabIndex = 4
        '
        'ProjectLocation
        '
        Me.ProjectLocation.Location = New System.Drawing.Point(103, 136)
        Me.ProjectLocation.MaxLength = 100
        Me.ProjectLocation.Multiline = True
        Me.ProjectLocation.Name = "ProjectLocation"
        Me.ProjectLocation.Size = New System.Drawing.Size(185, 61)
        Me.ProjectLocation.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(204, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Include some basic info on the form."
        '
        'ProjectNext1
        '
        Me.ProjectNext1.Enabled = False
        Me.ProjectNext1.Location = New System.Drawing.Point(305, 257)
        Me.ProjectNext1.Name = "ProjectNext1"
        Me.ProjectNext1.Size = New System.Drawing.Size(75, 23)
        Me.ProjectNext1.TabIndex = 8
        Me.ProjectNext1.Text = "Next"
        Me.ProjectNext1.UseVisualStyleBackColor = True
        '
        'ProjectCancel
        '
        Me.ProjectCancel.Location = New System.Drawing.Point(224, 257)
        Me.ProjectCancel.Name = "ProjectCancel"
        Me.ProjectCancel.Size = New System.Drawing.Size(75, 23)
        Me.ProjectCancel.TabIndex = 9
        Me.ProjectCancel.Text = "Cancel"
        Me.ProjectCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProjectLocation)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ProjectName)
        Me.GroupBox1.Controls.Add(Me.ProjectDescription)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 213)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New Project Info"
        '
        'ProjectPanel1
        '
        Me.ProjectPanel1.Controls.Add(Me.ProjectNext1)
        Me.ProjectPanel1.Controls.Add(Me.GroupBox1)
        Me.ProjectPanel1.Controls.Add(Me.ProjectCancel)
        Me.ProjectPanel1.Controls.Add(Me.Label4)
        Me.ProjectPanel1.Controls.Add(Me.PictureBox1)
        Me.ProjectPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ProjectPanel1.Name = "ProjectPanel1"
        Me.ProjectPanel1.Size = New System.Drawing.Size(390, 290)
        Me.ProjectPanel1.TabIndex = 11
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ProjectWizard.My.Resources.Resources.icon_alert
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(44, 29)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'ProjectPanel2
        '
        Me.ProjectPanel2.Controls.Add(Me.ProgressBar1)
        Me.ProjectPanel2.Controls.Add(Me.Label5)
        Me.ProjectPanel2.Controls.Add(Me.ExecutedSQL)
        Me.ProjectPanel2.Location = New System.Drawing.Point(0, 296)
        Me.ProjectPanel2.Name = "ProjectPanel2"
        Me.ProjectPanel2.Size = New System.Drawing.Size(390, 290)
        Me.ProjectPanel2.TabIndex = 11
        Me.ProjectPanel2.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(26, 245)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(342, 23)
        Me.ProgressBar1.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Building Database:"
        '
        'ExecutedSQL
        '
        Me.ExecutedSQL.FormattingEnabled = True
        Me.ExecutedSQL.Location = New System.Drawing.Point(26, 44)
        Me.ExecutedSQL.Name = "ExecutedSQL"
        Me.ExecutedSQL.Size = New System.Drawing.Size(342, 184)
        Me.ExecutedSQL.TabIndex = 0
        '
        'CreateProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 291)
        Me.Controls.Add(Me.ProjectPanel1)
        Me.Controls.Add(Me.ProjectPanel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "CreateProject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create Project"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ProjectPanel1.ResumeLayout(False)
        Me.ProjectPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProjectPanel2.ResumeLayout(False)
        Me.ProjectPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProjectName As System.Windows.Forms.TextBox
    Friend WithEvents ProjectDescription As System.Windows.Forms.TextBox
    Friend WithEvents ProjectLocation As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProjectNext1 As System.Windows.Forms.Button
    Friend WithEvents ProjectCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ProjectPanel1 As System.Windows.Forms.Panel
    Friend WithEvents ProjectPanel2 As System.Windows.Forms.Panel
    Friend WithEvents ExecutedSQL As System.Windows.Forms.CheckedListBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
