<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addEquipment
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
        Me.addEquipmentCode = New System.Windows.Forms.TextBox
        Me.addEquipmentDescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.addEquipmentOKButton = New System.Windows.Forms.Button
        Me.addEquipmentApplyButton = New System.Windows.Forms.Button
        Me.addEquipmentCancelButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'addEquipmentCode
        '
        Me.addEquipmentCode.Location = New System.Drawing.Point(121, 22)
        Me.addEquipmentCode.Name = "addEquipmentCode"
        Me.addEquipmentCode.Size = New System.Drawing.Size(136, 20)
        Me.addEquipmentCode.TabIndex = 0
        '
        'addEquipmentDescription
        '
        Me.addEquipmentDescription.Location = New System.Drawing.Point(121, 64)
        Me.addEquipmentDescription.Multiline = True
        Me.addEquipmentDescription.Name = "addEquipmentDescription"
        Me.addEquipmentDescription.Size = New System.Drawing.Size(136, 90)
        Me.addEquipmentDescription.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Equipment Code:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Description:"
        '
        'addEquipmentOKButton
        '
        Me.addEquipmentOKButton.Enabled = False
        Me.addEquipmentOKButton.Location = New System.Drawing.Point(30, 181)
        Me.addEquipmentOKButton.Name = "addEquipmentOKButton"
        Me.addEquipmentOKButton.Size = New System.Drawing.Size(75, 23)
        Me.addEquipmentOKButton.TabIndex = 4
        Me.addEquipmentOKButton.Text = "OK"
        Me.addEquipmentOKButton.UseVisualStyleBackColor = True
        '
        'addEquipmentApplyButton
        '
        Me.addEquipmentApplyButton.Enabled = False
        Me.addEquipmentApplyButton.Location = New System.Drawing.Point(111, 181)
        Me.addEquipmentApplyButton.Name = "addEquipmentApplyButton"
        Me.addEquipmentApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.addEquipmentApplyButton.TabIndex = 5
        Me.addEquipmentApplyButton.Text = "Apply"
        Me.addEquipmentApplyButton.UseVisualStyleBackColor = True
        '
        'addEquipmentCancelButton
        '
        Me.addEquipmentCancelButton.Location = New System.Drawing.Point(192, 181)
        Me.addEquipmentCancelButton.Name = "addEquipmentCancelButton"
        Me.addEquipmentCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.addEquipmentCancelButton.TabIndex = 6
        Me.addEquipmentCancelButton.Text = "Cancel"
        Me.addEquipmentCancelButton.UseVisualStyleBackColor = True
        '
        'addEquipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 216)
        Me.Controls.Add(Me.addEquipmentCancelButton)
        Me.Controls.Add(Me.addEquipmentApplyButton)
        Me.Controls.Add(Me.addEquipmentOKButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.addEquipmentDescription)
        Me.Controls.Add(Me.addEquipmentCode)
        Me.Name = "addEquipment"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Equipment Type"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents addEquipmentCode As System.Windows.Forms.TextBox
    Friend WithEvents addEquipmentDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents addEquipmentOKButton As System.Windows.Forms.Button
    Friend WithEvents addEquipmentApplyButton As System.Windows.Forms.Button
    Friend WithEvents addEquipmentCancelButton As System.Windows.Forms.Button
End Class
