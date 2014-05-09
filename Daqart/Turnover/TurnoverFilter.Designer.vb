<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TurnoverFilter
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
        Me.rad_ProjectNumber = New System.Windows.Forms.RadioButton
        Me.rad_Contractor = New System.Windows.Forms.RadioButton
        Me.rad_Location = New System.Windows.Forms.RadioButton
        Me.cbx_Contractor = New System.Windows.Forms.ComboBox
        Me.cbx_Location = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.cbx_ProjectNumber = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.clb_Projects = New System.Windows.Forms.CheckedListBox
        Me.rad_SelectProject = New System.Windows.Forms.RadioButton
        Me.rad_CurrentProject = New System.Windows.Forms.RadioButton
        Me.rad_MyProjects = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rad_ProjectNumber
        '
        Me.rad_ProjectNumber.AutoSize = True
        Me.rad_ProjectNumber.Location = New System.Drawing.Point(9, 56)
        Me.rad_ProjectNumber.Name = "rad_ProjectNumber"
        Me.rad_ProjectNumber.Size = New System.Drawing.Size(68, 17)
        Me.rad_ProjectNumber.TabIndex = 0
        Me.rad_ProjectNumber.Text = "Project #"
        Me.rad_ProjectNumber.UseVisualStyleBackColor = True
        '
        'rad_Contractor
        '
        Me.rad_Contractor.AutoSize = True
        Me.rad_Contractor.Location = New System.Drawing.Point(9, 95)
        Me.rad_Contractor.Name = "rad_Contractor"
        Me.rad_Contractor.Size = New System.Drawing.Size(74, 17)
        Me.rad_Contractor.TabIndex = 1
        Me.rad_Contractor.Text = "Contractor"
        Me.rad_Contractor.UseVisualStyleBackColor = True
        '
        'rad_Location
        '
        Me.rad_Location.AutoSize = True
        Me.rad_Location.Location = New System.Drawing.Point(9, 134)
        Me.rad_Location.Name = "rad_Location"
        Me.rad_Location.Size = New System.Drawing.Size(66, 17)
        Me.rad_Location.TabIndex = 2
        Me.rad_Location.Text = "Location"
        Me.rad_Location.UseVisualStyleBackColor = True
        '
        'cbx_Contractor
        '
        Me.cbx_Contractor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Contractor.FormattingEnabled = True
        Me.cbx_Contractor.Location = New System.Drawing.Point(113, 95)
        Me.cbx_Contractor.Name = "cbx_Contractor"
        Me.cbx_Contractor.Size = New System.Drawing.Size(235, 21)
        Me.cbx_Contractor.TabIndex = 4
        '
        'cbx_Location
        '
        Me.cbx_Location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Location.FormattingEnabled = True
        Me.cbx_Location.Location = New System.Drawing.Point(113, 134)
        Me.cbx_Location.Name = "cbx_Location"
        Me.cbx_Location.Size = New System.Drawing.Size(235, 21)
        Me.cbx_Location.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(311, 432)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(230, 432)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cbx_ProjectNumber
        '
        Me.cbx_ProjectNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ProjectNumber.FormattingEnabled = True
        Me.cbx_ProjectNumber.Location = New System.Drawing.Point(113, 52)
        Me.cbx_ProjectNumber.Name = "cbx_ProjectNumber"
        Me.cbx_ProjectNumber.Size = New System.Drawing.Size(235, 21)
        Me.cbx_ProjectNumber.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.cbx_ProjectNumber)
        Me.GroupBox1.Controls.Add(Me.rad_ProjectNumber)
        Me.GroupBox1.Controls.Add(Me.rad_Contractor)
        Me.GroupBox1.Controls.Add(Me.rad_Location)
        Me.GroupBox1.Controls.Add(Me.cbx_Location)
        Me.GroupBox1.Controls.Add(Me.cbx_Contractor)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 239)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(371, 187)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Criteria"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.clb_Projects)
        Me.GroupBox2.Controls.Add(Me.rad_SelectProject)
        Me.GroupBox2.Controls.Add(Me.rad_CurrentProject)
        Me.GroupBox2.Controls.Add(Me.rad_MyProjects)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(371, 221)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Project Select"
        '
        'clb_Projects
        '
        Me.clb_Projects.Enabled = False
        Me.clb_Projects.FormattingEnabled = True
        Me.clb_Projects.Location = New System.Drawing.Point(29, 112)
        Me.clb_Projects.Name = "clb_Projects"
        Me.clb_Projects.Size = New System.Drawing.Size(319, 94)
        Me.clb_Projects.TabIndex = 5
        '
        'rad_SelectProject
        '
        Me.rad_SelectProject.AutoSize = True
        Me.rad_SelectProject.Enabled = False
        Me.rad_SelectProject.Location = New System.Drawing.Point(9, 89)
        Me.rad_SelectProject.Name = "rad_SelectProject"
        Me.rad_SelectProject.Size = New System.Drawing.Size(96, 17)
        Me.rad_SelectProject.TabIndex = 4
        Me.rad_SelectProject.Text = "Select Projects"
        Me.rad_SelectProject.UseVisualStyleBackColor = True
        '
        'rad_CurrentProject
        '
        Me.rad_CurrentProject.AutoSize = True
        Me.rad_CurrentProject.Location = New System.Drawing.Point(9, 54)
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
        Me.rad_MyProjects.Location = New System.Drawing.Point(9, 19)
        Me.rad_MyProjects.Name = "rad_MyProjects"
        Me.rad_MyProjects.Size = New System.Drawing.Size(80, 17)
        Me.rad_MyProjects.TabIndex = 1
        Me.rad_MyProjects.TabStop = True
        Me.rad_MyProjects.Text = "My Projects"
        Me.rad_MyProjects.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(9, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(51, 17)
        Me.RadioButton1.TabIndex = 9
        Me.RadioButton1.Text = "None"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'TurnoverFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 467)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "TurnoverFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Turnover Status Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rad_ProjectNumber As System.Windows.Forms.RadioButton
    Friend WithEvents rad_Contractor As System.Windows.Forms.RadioButton
    Friend WithEvents rad_Location As System.Windows.Forms.RadioButton
    Friend WithEvents cbx_Contractor As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Location As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbx_ProjectNumber As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents clb_Projects As System.Windows.Forms.CheckedListBox
    Friend WithEvents rad_SelectProject As System.Windows.Forms.RadioButton
    Friend WithEvents rad_CurrentProject As System.Windows.Forms.RadioButton
    Friend WithEvents rad_MyProjects As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
