<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemOverview
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.tbx_PackageRemaining = New System.Windows.Forms.TextBox
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.tbx_PackageComplete = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tbx_PackageCount = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.tbx_PercentComplete = New System.Windows.Forms.TextBox
        Me.tbx_RequiredMH = New System.Windows.Forms.TextBox
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.tbx_EarnedMH = New System.Windows.Forms.TextBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.dgv_Packages = New System.Windows.Forms.DataGridView
        Me.Package = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Discipline = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EarnedManHours = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RequiredManHours = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PerComp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.tbx_Owner = New System.Windows.Forms.TextBox
        Me.tbx_SystemID = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.tbx_Description = New System.Windows.Forms.TextBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_Packages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.Panel2.Controls.Add(Me.tbx_PackageRemaining)
        Me.Panel2.Controls.Add(Me.TextBox11)
        Me.Panel2.Controls.Add(Me.tbx_PackageComplete)
        Me.Panel2.Controls.Add(Me.TextBox6)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.tbx_PackageCount)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.tbx_PercentComplete)
        Me.Panel2.Controls.Add(Me.tbx_RequiredMH)
        Me.Panel2.Controls.Add(Me.TextBox10)
        Me.Panel2.Controls.Add(Me.TextBox9)
        Me.Panel2.Controls.Add(Me.tbx_EarnedMH)
        Me.Panel2.Controls.Add(Me.TextBox7)
        Me.Panel2.Controls.Add(Me.dgv_Packages)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.tbx_Owner)
        Me.Panel2.Controls.Add(Me.tbx_SystemID)
        Me.Panel2.Controls.Add(Me.TextBox5)
        Me.Panel2.Controls.Add(Me.TextBox3)
        Me.Panel2.Controls.Add(Me.tbx_Description)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(700, 630)
        Me.Panel2.TabIndex = 7
        '
        'tbx_PackageRemaining
        '
        Me.tbx_PackageRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_PackageRemaining.Location = New System.Drawing.Point(544, 108)
        Me.tbx_PackageRemaining.Name = "tbx_PackageRemaining"
        Me.tbx_PackageRemaining.Size = New System.Drawing.Size(152, 20)
        Me.tbx_PackageRemaining.TabIndex = 20
        '
        'TextBox11
        '
        Me.TextBox11.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox11.Location = New System.Drawing.Point(453, 108)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(93, 20)
        Me.TextBox11.TabIndex = 19
        Me.TextBox11.TabStop = False
        Me.TextBox11.Text = "Remaining"
        '
        'tbx_PackageComplete
        '
        Me.tbx_PackageComplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_PackageComplete.Location = New System.Drawing.Point(343, 108)
        Me.tbx_PackageComplete.Name = "tbx_PackageComplete"
        Me.tbx_PackageComplete.Size = New System.Drawing.Size(111, 20)
        Me.tbx_PackageComplete.TabIndex = 18
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox6.Location = New System.Drawing.Point(244, 108)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(100, 20)
        Me.TextBox6.TabIndex = 17
        Me.TextBox6.TabStop = False
        Me.TextBox6.Text = "Completed"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(3, 98)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(693, 11)
        Me.Panel1.TabIndex = 14
        '
        'tbx_PackageCount
        '
        Me.tbx_PackageCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_PackageCount.Location = New System.Drawing.Point(102, 108)
        Me.tbx_PackageCount.Name = "tbx_PackageCount"
        Me.tbx_PackageCount.Size = New System.Drawing.Size(143, 20)
        Me.tbx_PackageCount.TabIndex = 16
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(3, 108)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 15
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = "Package Total"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(244, 41)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(301, 58)
        Me.Panel3.TabIndex = 13
        '
        'tbx_PercentComplete
        '
        Me.tbx_PercentComplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_PercentComplete.Location = New System.Drawing.Point(102, 79)
        Me.tbx_PercentComplete.Name = "tbx_PercentComplete"
        Me.tbx_PercentComplete.Size = New System.Drawing.Size(143, 20)
        Me.tbx_PercentComplete.TabIndex = 12
        '
        'tbx_RequiredMH
        '
        Me.tbx_RequiredMH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_RequiredMH.Location = New System.Drawing.Point(102, 60)
        Me.tbx_RequiredMH.Name = "tbx_RequiredMH"
        Me.tbx_RequiredMH.Size = New System.Drawing.Size(143, 20)
        Me.tbx_RequiredMH.TabIndex = 11
        '
        'TextBox10
        '
        Me.TextBox10.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox10.Location = New System.Drawing.Point(3, 79)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(100, 20)
        Me.TextBox10.TabIndex = 10
        Me.TextBox10.TabStop = False
        Me.TextBox10.Text = "Percent Complete"
        '
        'TextBox9
        '
        Me.TextBox9.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox9.Location = New System.Drawing.Point(3, 60)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(100, 20)
        Me.TextBox9.TabIndex = 9
        Me.TextBox9.TabStop = False
        Me.TextBox9.Text = "Required ManHours"
        '
        'tbx_EarnedMH
        '
        Me.tbx_EarnedMH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_EarnedMH.Location = New System.Drawing.Point(102, 41)
        Me.tbx_EarnedMH.Name = "tbx_EarnedMH"
        Me.tbx_EarnedMH.Size = New System.Drawing.Size(143, 20)
        Me.tbx_EarnedMH.TabIndex = 8
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox7.Location = New System.Drawing.Point(3, 41)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(100, 20)
        Me.TextBox7.TabIndex = 7
        Me.TextBox7.TabStop = False
        Me.TextBox7.Text = "Earned ManHours"
        '
        'dgv_Packages
        '
        Me.dgv_Packages.AllowUserToAddRows = False
        Me.dgv_Packages.AllowUserToDeleteRows = False
        Me.dgv_Packages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_Packages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Packages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Package, Me.Description, Me.Discipline, Me.EarnedManHours, Me.RequiredManHours, Me.PerComp})
        Me.dgv_Packages.Location = New System.Drawing.Point(3, 127)
        Me.dgv_Packages.Name = "dgv_Packages"
        Me.dgv_Packages.ReadOnly = True
        Me.dgv_Packages.RowHeadersVisible = False
        Me.dgv_Packages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgv_Packages.Size = New System.Drawing.Size(693, 500)
        Me.dgv_Packages.TabIndex = 6
        '
        'Package
        '
        Me.Package.HeaderText = "Package"
        Me.Package.Name = "Package"
        Me.Package.ReadOnly = True
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'Discipline
        '
        Me.Discipline.HeaderText = "Disc"
        Me.Discipline.Name = "Discipline"
        Me.Discipline.ReadOnly = True
        '
        'EarnedManHours
        '
        Me.EarnedManHours.HeaderText = "Earned MH"
        Me.EarnedManHours.Name = "EarnedManHours"
        Me.EarnedManHours.ReadOnly = True
        '
        'RequiredManHours
        '
        Me.RequiredManHours.HeaderText = "Req'd MH"
        Me.RequiredManHours.Name = "RequiredManHours"
        Me.RequiredManHours.ReadOnly = True
        '
        'PerComp
        '
        Me.PerComp.HeaderText = "% Comp"
        Me.PerComp.Name = "PerComp"
        Me.PerComp.ReadOnly = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(3, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "System ID"
        '
        'tbx_Owner
        '
        Me.tbx_Owner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_Owner.Location = New System.Drawing.Point(343, 3)
        Me.tbx_Owner.Name = "tbx_Owner"
        Me.tbx_Owner.Size = New System.Drawing.Size(202, 20)
        Me.tbx_Owner.TabIndex = 5
        '
        'tbx_SystemID
        '
        Me.tbx_SystemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_SystemID.Location = New System.Drawing.Point(102, 3)
        Me.tbx_SystemID.Name = "tbx_SystemID"
        Me.tbx_SystemID.Size = New System.Drawing.Size(143, 20)
        Me.tbx_SystemID.TabIndex = 1
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.Location = New System.Drawing.Point(244, 3)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(100, 20)
        Me.TextBox5.TabIndex = 4
        Me.TextBox5.TabStop = False
        Me.TextBox5.Text = "Current Owner"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Location = New System.Drawing.Point(3, 22)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = "Description"
        '
        'tbx_Description
        '
        Me.tbx_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbx_Description.Location = New System.Drawing.Point(102, 22)
        Me.tbx_Description.Name = "tbx_Description"
        Me.tbx_Description.Size = New System.Drawing.Size(443, 20)
        Me.tbx_Description.TabIndex = 3
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(544, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(152, 96)
        Me.PictureBox3.TabIndex = 14
        Me.PictureBox3.TabStop = False
        '
        'SystemOverview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Name = "SystemOverview"
        Me.Size = New System.Drawing.Size(700, 630)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgv_Packages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tbx_PercentComplete As System.Windows.Forms.TextBox
    Friend WithEvents tbx_RequiredMH As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents tbx_EarnedMH As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents dgv_Packages As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Owner As System.Windows.Forms.TextBox
    Friend WithEvents tbx_SystemID As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Description As System.Windows.Forms.TextBox
    Friend WithEvents Package As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Discipline As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EarnedManHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequiredManHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PerComp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbx_PackageCount As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbx_PackageRemaining As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents tbx_PackageComplete As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox

End Class
