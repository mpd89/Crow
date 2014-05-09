<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignOffProxy
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbx_User = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User"
        '
        'cbx_User
        '
        Me.cbx_User.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_User.FormattingEnabled = True
        Me.cbx_User.Location = New System.Drawing.Point(55, 10)
        Me.cbx_User.Name = "cbx_User"
        Me.cbx_User.Size = New System.Drawing.Size(393, 21)
        Me.cbx_User.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(454, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 21)
        Me.Button1.TabIndex = 97
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(316, 56)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 99
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(397, 56)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 100
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'SignOffProxy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 98)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbx_User)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SignOffProxy"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sign Off Proxy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbx_User As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
End Class
