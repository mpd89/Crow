<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class projectSelect
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
        Me.ProjectList = New System.Windows.Forms.ListBox
        Me.ProjectSelectOK = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.btn_AddProject = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ProjectList
        '
        Me.ProjectList.FormattingEnabled = True
        Me.ProjectList.Location = New System.Drawing.Point(12, 12)
        Me.ProjectList.Name = "ProjectList"
        Me.ProjectList.Size = New System.Drawing.Size(335, 303)
        Me.ProjectList.TabIndex = 0
        '
        'ProjectSelectOK
        '
        Me.ProjectSelectOK.Enabled = False
        Me.ProjectSelectOK.Location = New System.Drawing.Point(272, 337)
        Me.ProjectSelectOK.Name = "ProjectSelectOK"
        Me.ProjectSelectOK.Size = New System.Drawing.Size(75, 23)
        Me.ProjectSelectOK.TabIndex = 10
        Me.ProjectSelectOK.Text = "Select"
        Me.ProjectSelectOK.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(191, 337)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Daqart.My.Resources.Resources.Help
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(12, 337)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 23)
        Me.Button2.TabIndex = 12
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_AddProject
        '
        Me.btn_AddProject.Location = New System.Drawing.Point(140, 337)
        Me.btn_AddProject.Name = "btn_AddProject"
        Me.btn_AddProject.Size = New System.Drawing.Size(45, 23)
        Me.btn_AddProject.TabIndex = 13
        Me.btn_AddProject.Text = "Add"
        Me.btn_AddProject.UseVisualStyleBackColor = True
        '
        'projectSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 372)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_AddProject)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProjectSelectOK)
        Me.Controls.Add(Me.ProjectList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "projectSelect"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Project"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProjectList As System.Windows.Forms.ListBox
    Friend WithEvents ProjectSelectOK As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_AddProject As System.Windows.Forms.Button
End Class
