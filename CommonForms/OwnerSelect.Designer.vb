<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OwnerSelect
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
        Me.cbx_Owners = New System.Windows.Forms.ComboBox
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cbx_Owners
        '
        Me.cbx_Owners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Owners.FormattingEnabled = True
        Me.cbx_Owners.Location = New System.Drawing.Point(12, 12)
        Me.cbx_Owners.Name = "cbx_Owners"
        Me.cbx_Owners.Size = New System.Drawing.Size(258, 21)
        Me.cbx_Owners.TabIndex = 0
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(195, 53)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 1
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(114, 53)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 2
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'OwnerSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 97)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.cbx_Owners)
        Me.Name = "OwnerSelect"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Owner Select"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbx_Owners As System.Windows.Forms.ComboBox
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
End Class
