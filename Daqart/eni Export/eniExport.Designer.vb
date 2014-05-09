<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class eniExport
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
        Me.btn_Browse = New System.Windows.Forms.Button
        Me.tbx_Folder = New System.Windows.Forms.TextBox
        Me.cbx_Owner = New System.Windows.Forms.ComboBox
        Me.tbx_System = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(373, 129)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 0
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(292, 129)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 1
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Browse
        '
        Me.btn_Browse.Location = New System.Drawing.Point(373, 77)
        Me.btn_Browse.Name = "btn_Browse"
        Me.btn_Browse.Size = New System.Drawing.Size(75, 23)
        Me.btn_Browse.TabIndex = 2
        Me.btn_Browse.Text = "Browse"
        Me.btn_Browse.UseVisualStyleBackColor = True
        '
        'tbx_Folder
        '
        Me.tbx_Folder.Location = New System.Drawing.Point(88, 79)
        Me.tbx_Folder.Name = "tbx_Folder"
        Me.tbx_Folder.Size = New System.Drawing.Size(279, 20)
        Me.tbx_Folder.TabIndex = 3
        '
        'cbx_Owner
        '
        Me.cbx_Owner.FormattingEnabled = True
        Me.cbx_Owner.Location = New System.Drawing.Point(88, 42)
        Me.cbx_Owner.Name = "cbx_Owner"
        Me.cbx_Owner.Size = New System.Drawing.Size(279, 21)
        Me.cbx_Owner.TabIndex = 4
        '
        'tbx_System
        '
        Me.tbx_System.Location = New System.Drawing.Point(88, 12)
        Me.tbx_System.Name = "tbx_System"
        Me.tbx_System.Size = New System.Drawing.Size(66, 20)
        Me.tbx_System.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "eni System#"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Owner"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Folder"
        '
        'eniExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 169)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbx_System)
        Me.Controls.Add(Me.cbx_Owner)
        Me.Controls.Add(Me.tbx_Folder)
        Me.Controls.Add(Me.btn_Browse)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Name = "eniExport"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "eni Turnover Package Export"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Browse As System.Windows.Forms.Button
    Friend WithEvents tbx_Folder As System.Windows.Forms.TextBox
    Friend WithEvents cbx_Owner As System.Windows.Forms.ComboBox
    Friend WithEvents tbx_System As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
