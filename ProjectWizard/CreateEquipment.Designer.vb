<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateEquipment
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
        Me.EquipmentPanel1 = New System.Windows.Forms.Panel
        Me.EquipmentPanel2 = New System.Windows.Forms.Panel
        Me.EquipmentImportButton = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.EquipmentAdd = New System.Windows.Forms.Button
        Me.EquipmentFinish = New System.Windows.Forms.Button
        Me.EquipmentRemove = New System.Windows.Forms.Button
        Me.EquipmentPanel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EquipmentPanel1
        '
        Me.EquipmentPanel1.Controls.Add(Me.EquipmentPanel2)
        Me.EquipmentPanel1.Controls.Add(Me.EquipmentImportButton)
        Me.EquipmentPanel1.Controls.Add(Me.Label6)
        Me.EquipmentPanel1.Controls.Add(Me.PictureBox2)
        Me.EquipmentPanel1.Controls.Add(Me.EquipmentAdd)
        Me.EquipmentPanel1.Controls.Add(Me.EquipmentFinish)
        Me.EquipmentPanel1.Controls.Add(Me.EquipmentRemove)
        Me.EquipmentPanel1.Location = New System.Drawing.Point(1, 2)
        Me.EquipmentPanel1.Name = "EquipmentPanel1"
        Me.EquipmentPanel1.Size = New System.Drawing.Size(390, 290)
        Me.EquipmentPanel1.TabIndex = 14
        '
        'EquipmentPanel2
        '
        Me.EquipmentPanel2.Location = New System.Drawing.Point(12, 35)
        Me.EquipmentPanel2.Name = "EquipmentPanel2"
        Me.EquipmentPanel2.Size = New System.Drawing.Size(367, 216)
        Me.EquipmentPanel2.TabIndex = 16
        '
        'EquipmentImportButton
        '
        Me.EquipmentImportButton.Location = New System.Drawing.Point(174, 257)
        Me.EquipmentImportButton.Name = "EquipmentImportButton"
        Me.EquipmentImportButton.Size = New System.Drawing.Size(64, 23)
        Me.EquipmentImportButton.TabIndex = 15
        Me.EquipmentImportButton.Text = "Import"
        Me.EquipmentImportButton.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(51, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(243, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "List equipment code with a brief description"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ProjectWizard.My.Resources.Resources.icon_alert
        Me.PictureBox2.Location = New System.Drawing.Point(3, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(44, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'EquipmentAdd
        '
        Me.EquipmentAdd.Location = New System.Drawing.Point(93, 257)
        Me.EquipmentAdd.Name = "EquipmentAdd"
        Me.EquipmentAdd.Size = New System.Drawing.Size(75, 23)
        Me.EquipmentAdd.TabIndex = 11
        Me.EquipmentAdd.Text = "Add"
        Me.EquipmentAdd.UseVisualStyleBackColor = True
        '
        'EquipmentFinish
        '
        Me.EquipmentFinish.Enabled = False
        Me.EquipmentFinish.Location = New System.Drawing.Point(305, 257)
        Me.EquipmentFinish.Name = "EquipmentFinish"
        Me.EquipmentFinish.Size = New System.Drawing.Size(75, 23)
        Me.EquipmentFinish.TabIndex = 8
        Me.EquipmentFinish.Text = "Finish"
        Me.EquipmentFinish.UseVisualStyleBackColor = True
        '
        'EquipmentRemove
        '
        Me.EquipmentRemove.Enabled = False
        Me.EquipmentRemove.Location = New System.Drawing.Point(12, 257)
        Me.EquipmentRemove.Name = "EquipmentRemove"
        Me.EquipmentRemove.Size = New System.Drawing.Size(75, 23)
        Me.EquipmentRemove.TabIndex = 9
        Me.EquipmentRemove.Text = "Remove"
        Me.EquipmentRemove.UseVisualStyleBackColor = True
        '
        'CreateEquipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 291)
        Me.Controls.Add(Me.EquipmentPanel1)
        Me.Name = "CreateEquipment"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CreateEquipment"
        Me.EquipmentPanel1.ResumeLayout(False)
        Me.EquipmentPanel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EquipmentPanel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents EquipmentAdd As System.Windows.Forms.Button
    Friend WithEvents EquipmentFinish As System.Windows.Forms.Button
    Friend WithEvents EquipmentRemove As System.Windows.Forms.Button
    Friend WithEvents EquipmentImportButton As System.Windows.Forms.Button
    Friend WithEvents EquipmentPanel2 As System.Windows.Forms.Panel
End Class
