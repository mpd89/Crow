<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PkgFormAdd
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboDiscipline = New System.Windows.Forms.ComboBox
        Me.cboOwner = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboGroup = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbxPkgName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbxDescription = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbx_SystemNumber = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(581, 125)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(38, 21)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = ". . ."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(157, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Owner"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(-57, 157)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Discipline"
        '
        'cboDiscipline
        '
        Me.cboDiscipline.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDiscipline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiscipline.FormattingEnabled = True
        Me.cboDiscipline.Location = New System.Drawing.Point(13, 124)
        Me.cboDiscipline.Name = "cboDiscipline"
        Me.cboDiscipline.Size = New System.Drawing.Size(121, 21)
        Me.cboDiscipline.TabIndex = 34
        '
        'cboOwner
        '
        Me.cboOwner.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOwner.FormattingEnabled = True
        Me.cboOwner.Location = New System.Drawing.Point(160, 124)
        Me.cboOwner.Name = "cboOwner"
        Me.cboOwner.Size = New System.Drawing.Size(121, 21)
        Me.cboOwner.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(302, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Group"
        '
        'cboGroup
        '
        Me.cboGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGroup.FormattingEnabled = True
        Me.cboGroup.Location = New System.Drawing.Point(305, 125)
        Me.cboGroup.Name = "cboGroup"
        Me.cboGroup.Size = New System.Drawing.Size(121, 21)
        Me.cboGroup.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(437, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "System Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 23)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Add New Package"
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(457, 18)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 39
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(351, 18)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 38
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(150, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Package Name"
        '
        'tbxPkgName
        '
        Me.tbxPkgName.Location = New System.Drawing.Point(150, 65)
        Me.tbxPkgName.Name = "tbxPkgName"
        Me.tbxPkgName.Size = New System.Drawing.Size(121, 20)
        Me.tbxPkgName.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Discipline"
        '
        'tbxDescription
        '
        Me.tbxDescription.Location = New System.Drawing.Point(305, 65)
        Me.tbxDescription.Name = "tbxDescription"
        Me.tbxDescription.Size = New System.Drawing.Size(314, 20)
        Me.tbxDescription.TabIndex = 43
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(337, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Description"
        '
        'tbx_SystemNumber
        '
        Me.tbx_SystemNumber.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbx_SystemNumber.Location = New System.Drawing.Point(440, 125)
        Me.tbx_SystemNumber.Name = "tbx_SystemNumber"
        Me.tbx_SystemNumber.ReadOnly = True
        Me.tbx_SystemNumber.Size = New System.Drawing.Size(135, 20)
        Me.tbx_SystemNumber.TabIndex = 45
        '
        'PkgFormAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 182)
        Me.Controls.Add(Me.tbx_SystemNumber)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbxDescription)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbxPkgName)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboDiscipline)
        Me.Controls.Add(Me.cboOwner)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboGroup)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "PkgFormAdd"
        Me.Text = "PkgFormAdd"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboDiscipline As System.Windows.Forms.ComboBox
    Friend WithEvents cboOwner As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxPkgName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbxDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbx_SystemNumber As System.Windows.Forms.TextBox
End Class
