<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectMain
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.ProjectList = New System.Windows.Forms.ListBox
        Me.btn_ProjectArchive = New System.Windows.Forms.Button
        Me.btn_ProjectRestore = New System.Windows.Forms.Button
        Me.btn_ProjectDelete = New System.Windows.Forms.Button
        Me.projectCancel = New System.Windows.Forms.Button
        Me.btn_Duplicate = New System.Windows.Forms.Button
        Me.cbx_Status = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(63, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 15)
        Me.Label4.TabIndex = 12
        '
        'ProjectList
        '
        Me.ProjectList.FormattingEnabled = True
        Me.ProjectList.Location = New System.Drawing.Point(12, 51)
        Me.ProjectList.Name = "ProjectList"
        Me.ProjectList.Size = New System.Drawing.Size(335, 316)
        Me.ProjectList.TabIndex = 10
        '
        'btn_ProjectArchive
        '
        Me.btn_ProjectArchive.Enabled = False
        Me.btn_ProjectArchive.Location = New System.Drawing.Point(12, 389)
        Me.btn_ProjectArchive.Name = "btn_ProjectArchive"
        Me.btn_ProjectArchive.Size = New System.Drawing.Size(58, 23)
        Me.btn_ProjectArchive.TabIndex = 13
        Me.btn_ProjectArchive.Text = "Archive"
        Me.btn_ProjectArchive.UseVisualStyleBackColor = True
        '
        'btn_ProjectRestore
        '
        Me.btn_ProjectRestore.Enabled = False
        Me.btn_ProjectRestore.Location = New System.Drawing.Point(76, 389)
        Me.btn_ProjectRestore.Name = "btn_ProjectRestore"
        Me.btn_ProjectRestore.Size = New System.Drawing.Size(54, 23)
        Me.btn_ProjectRestore.TabIndex = 14
        Me.btn_ProjectRestore.Text = "Restore"
        Me.btn_ProjectRestore.UseVisualStyleBackColor = True
        '
        'btn_ProjectDelete
        '
        Me.btn_ProjectDelete.Enabled = False
        Me.btn_ProjectDelete.Location = New System.Drawing.Point(215, 389)
        Me.btn_ProjectDelete.Name = "btn_ProjectDelete"
        Me.btn_ProjectDelete.Size = New System.Drawing.Size(62, 23)
        Me.btn_ProjectDelete.TabIndex = 15
        Me.btn_ProjectDelete.Text = "Delete"
        Me.btn_ProjectDelete.UseVisualStyleBackColor = True
        '
        'projectCancel
        '
        Me.projectCancel.Location = New System.Drawing.Point(283, 389)
        Me.projectCancel.Name = "projectCancel"
        Me.projectCancel.Size = New System.Drawing.Size(62, 23)
        Me.projectCancel.TabIndex = 16
        Me.projectCancel.Text = "Cancel"
        Me.projectCancel.UseVisualStyleBackColor = True
        '
        'btn_Duplicate
        '
        Me.btn_Duplicate.Enabled = False
        Me.btn_Duplicate.Location = New System.Drawing.Point(137, 389)
        Me.btn_Duplicate.Name = "btn_Duplicate"
        Me.btn_Duplicate.Size = New System.Drawing.Size(72, 23)
        Me.btn_Duplicate.TabIndex = 17
        Me.btn_Duplicate.Text = "Duplicate"
        Me.btn_Duplicate.UseVisualStyleBackColor = True
        '
        'cbx_Status
        '
        Me.cbx_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Status.FormattingEnabled = True
        Me.cbx_Status.Items.AddRange(New Object() {"Inactive", "Active", "Draft", "Cancelled", "Archive"})
        Me.cbx_Status.Location = New System.Drawing.Point(162, 22)
        Me.cbx_Status.Name = "cbx_Status"
        Me.cbx_Status.Size = New System.Drawing.Size(183, 21)
        Me.cbx_Status.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(76, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Project Status"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(365, 422)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbx_Status)
        Me.Controls.Add(Me.btn_Duplicate)
        Me.Controls.Add(Me.projectCancel)
        Me.Controls.Add(Me.btn_ProjectDelete)
        Me.Controls.Add(Me.btn_ProjectRestore)
        Me.Controls.Add(Me.btn_ProjectArchive)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ProjectList)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage Projects"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProjectList As System.Windows.Forms.ListBox
    Friend WithEvents btn_ProjectArchive As System.Windows.Forms.Button
    Friend WithEvents btn_ProjectRestore As System.Windows.Forms.Button
    Friend WithEvents btn_ProjectDelete As System.Windows.Forms.Button
    Friend WithEvents projectCancel As System.Windows.Forms.Button
    Friend WithEvents btn_Duplicate As System.Windows.Forms.Button
    Friend WithEvents cbx_Status As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
