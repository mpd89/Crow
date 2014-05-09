<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PkgCoversheet
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
        Me.buttonOK = New System.Windows.Forms.Button
        Me.buttonCancel = New System.Windows.Forms.Button
        Me.buttonGetFile = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.formFile = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'buttonOK
        '
        Me.buttonOK.Enabled = False
        Me.buttonOK.Location = New System.Drawing.Point(165, 189)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(75, 23)
        Me.buttonOK.TabIndex = 24
        Me.buttonOK.Text = "OK"
        Me.buttonOK.UseVisualStyleBackColor = True
        '
        'buttonCancel
        '
        Me.buttonCancel.Location = New System.Drawing.Point(257, 189)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
        Me.buttonCancel.TabIndex = 23
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonGetFile
        '
        Me.buttonGetFile.Location = New System.Drawing.Point(296, 133)
        Me.buttonGetFile.Name = "buttonGetFile"
        Me.buttonGetFile.Size = New System.Drawing.Size(36, 20)
        Me.buttonGetFile.TabIndex = 22
        Me.buttonGetFile.Text = "..."
        Me.buttonGetFile.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Base File"
        '
        'formFile
        '
        Me.formFile.Location = New System.Drawing.Point(50, 133)
        Me.formFile.Name = "formFile"
        Me.formFile.Size = New System.Drawing.Size(240, 20)
        Me.formFile.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 25)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Add Coversheet"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PkgCoversheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.buttonOK)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonGetFile)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.formFile)
        Me.Name = "PkgCoversheet"
        Me.Text = "PkgCoversheet"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buttonOK As System.Windows.Forms.Button
    Friend WithEvents buttonCancel As System.Windows.Forms.Button
    Friend WithEvents buttonGetFile As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents formFile As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
