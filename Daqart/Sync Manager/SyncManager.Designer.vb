<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SyncManager
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rad_SelectProject = New System.Windows.Forms.RadioButton
        Me.rad_CurrentProject = New System.Windows.Forms.RadioButton
        Me.rad_MyProjects = New System.Windows.Forms.RadioButton
        Me.lbx_Projects = New System.Windows.Forms.ListBox
        Me.lbx_MyProjects = New System.Windows.Forms.ListBox
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_Sync = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbx_MyProjects)
        Me.GroupBox2.Controls.Add(Me.lbx_Projects)
        Me.GroupBox2.Controls.Add(Me.rad_SelectProject)
        Me.GroupBox2.Controls.Add(Me.rad_CurrentProject)
        Me.GroupBox2.Controls.Add(Me.rad_MyProjects)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(371, 310)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Project Select"
        '
        'rad_SelectProject
        '
        Me.rad_SelectProject.AutoSize = True
        Me.rad_SelectProject.Enabled = False
        Me.rad_SelectProject.Location = New System.Drawing.Point(9, 158)
        Me.rad_SelectProject.Name = "rad_SelectProject"
        Me.rad_SelectProject.Size = New System.Drawing.Size(110, 17)
        Me.rad_SelectProject.TabIndex = 4
        Me.rad_SelectProject.Text = "All Active Projects"
        Me.rad_SelectProject.UseVisualStyleBackColor = True
        '
        'rad_CurrentProject
        '
        Me.rad_CurrentProject.AutoSize = True
        Me.rad_CurrentProject.Location = New System.Drawing.Point(9, 19)
        Me.rad_CurrentProject.Name = "rad_CurrentProject"
        Me.rad_CurrentProject.Size = New System.Drawing.Size(95, 17)
        Me.rad_CurrentProject.TabIndex = 2
        Me.rad_CurrentProject.Text = "Current Project"
        Me.rad_CurrentProject.UseVisualStyleBackColor = True
        '
        'rad_MyProjects
        '
        Me.rad_MyProjects.AutoSize = True
        Me.rad_MyProjects.Checked = True
        Me.rad_MyProjects.Location = New System.Drawing.Point(9, 47)
        Me.rad_MyProjects.Name = "rad_MyProjects"
        Me.rad_MyProjects.Size = New System.Drawing.Size(80, 17)
        Me.rad_MyProjects.TabIndex = 1
        Me.rad_MyProjects.TabStop = True
        Me.rad_MyProjects.Text = "My Projects"
        Me.rad_MyProjects.UseVisualStyleBackColor = True
        '
        'lbx_Projects
        '
        Me.lbx_Projects.FormattingEnabled = True
        Me.lbx_Projects.Location = New System.Drawing.Point(25, 181)
        Me.lbx_Projects.Name = "lbx_Projects"
        Me.lbx_Projects.Size = New System.Drawing.Size(328, 95)
        Me.lbx_Projects.TabIndex = 5
        '
        'lbx_MyProjects
        '
        Me.lbx_MyProjects.FormattingEnabled = True
        Me.lbx_MyProjects.Location = New System.Drawing.Point(25, 70)
        Me.lbx_MyProjects.Name = "lbx_MyProjects"
        Me.lbx_MyProjects.Size = New System.Drawing.Size(328, 69)
        Me.lbx_MyProjects.TabIndex = 6
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(226, 339)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 12
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Sync
        '
        Me.btn_Sync.Location = New System.Drawing.Point(307, 339)
        Me.btn_Sync.Name = "btn_Sync"
        Me.btn_Sync.Size = New System.Drawing.Size(75, 23)
        Me.btn_Sync.TabIndex = 13
        Me.btn_Sync.Text = "Sync"
        Me.btn_Sync.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'SyncManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 374)
        Me.Controls.Add(Me.btn_Sync)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SyncManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sync Manager"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rad_SelectProject As System.Windows.Forms.RadioButton
    Friend WithEvents rad_CurrentProject As System.Windows.Forms.RadioButton
    Friend WithEvents rad_MyProjects As System.Windows.Forms.RadioButton
    Friend WithEvents lbx_Projects As System.Windows.Forms.ListBox
    Friend WithEvents lbx_MyProjects As System.Windows.Forms.ListBox
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Sync As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
