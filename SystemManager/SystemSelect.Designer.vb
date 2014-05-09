<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemSelect
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
        Me.SystemID = New System.Windows.Forms.TextBox
        Me.btn_Select = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'SystemID
        '
        Me.SystemID.Location = New System.Drawing.Point(81, 12)
        Me.SystemID.Name = "SystemID"
        Me.SystemID.Size = New System.Drawing.Size(183, 20)
        Me.SystemID.TabIndex = 0
        Me.SystemID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SystemID.Visible = False
        '
        'btn_Select
        '
        Me.btn_Select.Enabled = False
        Me.btn_Select.Location = New System.Drawing.Point(507, 341)
        Me.btn_Select.Name = "btn_Select"
        Me.btn_Select.Size = New System.Drawing.Size(75, 23)
        Me.btn_Select.TabIndex = 1
        Me.btn_Select.Text = "Select"
        Me.btn_Select.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(426, 341)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'SystemSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 376)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_Select)
        Me.Controls.Add(Me.SystemID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SystemSelect"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Selection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SystemID As System.Windows.Forms.TextBox
    Friend WithEvents btn_Select As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
