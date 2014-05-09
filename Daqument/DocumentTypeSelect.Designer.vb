<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentTypeSelect
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
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.trvCategory = New System.Windows.Forms.TreeView
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(246, 317)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 0
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Enabled = False
        Me.btn_OK.Location = New System.Drawing.Point(327, 317)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 1
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.trvCategory)
        Me.Panel1.Location = New System.Drawing.Point(9, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(393, 301)
        Me.Panel1.TabIndex = 2
        '
        'trvCategory
        '
        Me.trvCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvCategory.Location = New System.Drawing.Point(0, 0)
        Me.trvCategory.Name = "trvCategory"
        Me.trvCategory.Size = New System.Drawing.Size(393, 301)
        Me.trvCategory.TabIndex = 0
        '
        'DocumentTypeSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 352)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Name = "DocumentTypeSelect"
        Me.Text = "Document Type Selection"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents trvCategory As System.Windows.Forms.TreeView
End Class
