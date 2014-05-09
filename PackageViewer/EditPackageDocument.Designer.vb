<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditPackageDocument
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
        Me.lbl_TagReference = New System.Windows.Forms.Label
        Me.cbx_TagList = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbx_Notes = New System.Windows.Forms.TextBox
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lbl_TagReference
        '
        Me.lbl_TagReference.AutoSize = True
        Me.lbl_TagReference.Location = New System.Drawing.Point(19, 36)
        Me.lbl_TagReference.Name = "lbl_TagReference"
        Me.lbl_TagReference.Size = New System.Drawing.Size(79, 13)
        Me.lbl_TagReference.TabIndex = 7
        Me.lbl_TagReference.Text = "Tag Reference"
        '
        'cbx_TagList
        '
        Me.cbx_TagList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_TagList.FormattingEnabled = True
        Me.cbx_TagList.Location = New System.Drawing.Point(142, 36)
        Me.cbx_TagList.Name = "cbx_TagList"
        Me.cbx_TagList.Size = New System.Drawing.Size(190, 21)
        Me.cbx_TagList.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Notes"
        '
        'tbx_Notes
        '
        Me.tbx_Notes.Location = New System.Drawing.Point(22, 84)
        Me.tbx_Notes.MaxLength = 255
        Me.tbx_Notes.Multiline = True
        Me.tbx_Notes.Name = "tbx_Notes"
        Me.tbx_Notes.Size = New System.Drawing.Size(310, 167)
        Me.tbx_Notes.TabIndex = 11
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(257, 276)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 13
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(176, 276)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 14
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'EditPackageDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 311)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbx_Notes)
        Me.Controls.Add(Me.lbl_TagReference)
        Me.Controls.Add(Me.cbx_TagList)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditPackageDocument"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Package Document Edit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_TagReference As System.Windows.Forms.Label
    Friend WithEvents cbx_TagList As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbx_Notes As System.Windows.Forms.TextBox
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
End Class
