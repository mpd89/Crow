<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DaqumentImportDefaults
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
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.trvCategory = New System.Windows.Forms.TreeView
        Me.SuspendLayout()
        '
        'btn_OK
        '
        Me.btn_OK.Enabled = False
        Me.btn_OK.Location = New System.Drawing.Point(320, 556)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 3
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(239, 556)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 2
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Default Document Type"
        '
        'trvCategory
        '
        Me.trvCategory.Location = New System.Drawing.Point(15, 26)
        Me.trvCategory.Name = "trvCategory"
        Me.trvCategory.Size = New System.Drawing.Size(380, 524)
        Me.trvCategory.TabIndex = 14
        '
        'DaqumentImportDefaults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 591)
        Me.ControlBox = False
        Me.Controls.Add(Me.trvCategory)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Name = "DaqumentImportDefaults"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Document Category Select"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents trvCategory As System.Windows.Forms.TreeView
End Class
