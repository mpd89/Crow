<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManualStatus
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
        Me.cbx_StatusUser = New System.Windows.Forms.ComboBox
        Me.tbx_StatusDate = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbx_CurrentStatus = New System.Windows.Forms.TextBox
        Me.tbx_ProposedStatus = New System.Windows.Forms.TextBox
        Me.cbx_UploadScan = New System.Windows.Forms.CheckBox
        Me.tbx_Filename = New System.Windows.Forms.TextBox
        Me.btn_Upload = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cbx_StatusUser
        '
        Me.cbx_StatusUser.FormattingEnabled = True
        Me.cbx_StatusUser.Location = New System.Drawing.Point(150, 84)
        Me.cbx_StatusUser.Name = "cbx_StatusUser"
        Me.cbx_StatusUser.Size = New System.Drawing.Size(273, 21)
        Me.cbx_StatusUser.TabIndex = 0
        '
        'tbx_StatusDate
        '
        Me.tbx_StatusDate.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.tbx_StatusDate.Location = New System.Drawing.Point(150, 116)
        Me.tbx_StatusDate.Name = "tbx_StatusDate"
        Me.tbx_StatusDate.ReadOnly = True
        Me.tbx_StatusDate.Size = New System.Drawing.Size(273, 20)
        Me.tbx_StatusDate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Current Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "User Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Proposed Status"
        '
        'tbx_CurrentStatus
        '
        Me.tbx_CurrentStatus.Location = New System.Drawing.Point(150, 22)
        Me.tbx_CurrentStatus.Name = "tbx_CurrentStatus"
        Me.tbx_CurrentStatus.ReadOnly = True
        Me.tbx_CurrentStatus.Size = New System.Drawing.Size(273, 20)
        Me.tbx_CurrentStatus.TabIndex = 7
        '
        'tbx_ProposedStatus
        '
        Me.tbx_ProposedStatus.Location = New System.Drawing.Point(150, 53)
        Me.tbx_ProposedStatus.Name = "tbx_ProposedStatus"
        Me.tbx_ProposedStatus.ReadOnly = True
        Me.tbx_ProposedStatus.Size = New System.Drawing.Size(273, 20)
        Me.tbx_ProposedStatus.TabIndex = 8
        '
        'cbx_UploadScan
        '
        Me.cbx_UploadScan.AutoSize = True
        Me.cbx_UploadScan.Location = New System.Drawing.Point(28, 177)
        Me.cbx_UploadScan.Name = "cbx_UploadScan"
        Me.cbx_UploadScan.Size = New System.Drawing.Size(156, 17)
        Me.cbx_UploadScan.TabIndex = 9
        Me.cbx_UploadScan.Text = "Upload Scanned Certificate"
        Me.cbx_UploadScan.UseVisualStyleBackColor = True
        '
        'tbx_Filename
        '
        Me.tbx_Filename.Enabled = False
        Me.tbx_Filename.Location = New System.Drawing.Point(50, 216)
        Me.tbx_Filename.Name = "tbx_Filename"
        Me.tbx_Filename.Size = New System.Drawing.Size(317, 20)
        Me.tbx_Filename.TabIndex = 10
        '
        'btn_Upload
        '
        Me.btn_Upload.Enabled = False
        Me.btn_Upload.Location = New System.Drawing.Point(373, 215)
        Me.btn_Upload.Name = "btn_Upload"
        Me.btn_Upload.Size = New System.Drawing.Size(50, 23)
        Me.btn_Upload.TabIndex = 11
        Me.btn_Upload.Text = "Browse"
        Me.btn_Upload.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(388, 321)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 12
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(307, 321)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 13
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'ManualStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 356)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Upload)
        Me.Controls.Add(Me.tbx_Filename)
        Me.Controls.Add(Me.cbx_UploadScan)
        Me.Controls.Add(Me.tbx_ProposedStatus)
        Me.Controls.Add(Me.tbx_CurrentStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbx_StatusDate)
        Me.Controls.Add(Me.cbx_StatusUser)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ManualStatus"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manual Status Input"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbx_StatusUser As System.Windows.Forms.ComboBox
    Friend WithEvents tbx_StatusDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbx_CurrentStatus As System.Windows.Forms.TextBox
    Friend WithEvents tbx_ProposedStatus As System.Windows.Forms.TextBox
    Friend WithEvents cbx_UploadScan As System.Windows.Forms.CheckBox
    Friend WithEvents tbx_Filename As System.Windows.Forms.TextBox
    Friend WithEvents btn_Upload As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
End Class
