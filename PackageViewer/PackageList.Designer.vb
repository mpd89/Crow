<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PackageList
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
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.lbx_PackageSelect = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(235, 268)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "OK"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(150, 268)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbx_PackageSelect
        '
        Me.lbx_PackageSelect.FormattingEnabled = True
        Me.lbx_PackageSelect.Location = New System.Drawing.Point(4, 3)
        Me.lbx_PackageSelect.Name = "lbx_PackageSelect"
        Me.lbx_PackageSelect.Size = New System.Drawing.Size(306, 251)
        Me.lbx_PackageSelect.TabIndex = 3
        '
        'PackageList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 301)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbx_PackageSelect)
        Me.Name = "PackageList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PackageList"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbx_PackageSelect As System.Windows.Forms.ListBox
End Class
