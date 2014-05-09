<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ValueEntry
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
        Me.tbx_Value = New System.Windows.Forms.TextBox
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_FieldName = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'tbx_Value
        '
        Me.tbx_Value.Location = New System.Drawing.Point(12, 57)
        Me.tbx_Value.MaxLength = 500
        Me.tbx_Value.Multiline = True
        Me.tbx_Value.Name = "tbx_Value"
        Me.tbx_Value.Size = New System.Drawing.Size(295, 129)
        Me.tbx_Value.TabIndex = 0
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(62, 192)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 1
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(161, 192)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 2
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Selected Field:"
        '
        'lbl_FieldName
        '
        Me.lbl_FieldName.AutoSize = True
        Me.lbl_FieldName.Location = New System.Drawing.Point(13, 32)
        Me.lbl_FieldName.Name = "lbl_FieldName"
        Me.lbl_FieldName.Size = New System.Drawing.Size(39, 13)
        Me.lbl_FieldName.TabIndex = 4
        Me.lbl_FieldName.Text = "Label2"
        '
        'ValueEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 227)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_FieldName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.tbx_Value)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ValueEntry"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Value Entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbx_Value As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_FieldName As System.Windows.Forms.Label
End Class
