<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddDocRef
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbx_Title = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbx_Description = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbx_Type = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbx_Revision = New System.Windows.Forms.TextBox
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Browse = New System.Windows.Forms.Button
        Me.tbx_FileName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Type"
        '
        'tbx_Title
        '
        Me.tbx_Title.Location = New System.Drawing.Point(90, 48)
        Me.tbx_Title.MaxLength = 50
        Me.tbx_Title.Name = "tbx_Title"
        Me.tbx_Title.Size = New System.Drawing.Size(391, 20)
        Me.tbx_Title.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Title"
        '
        'tbx_Description
        '
        Me.tbx_Description.Location = New System.Drawing.Point(90, 74)
        Me.tbx_Description.MaxLength = 250
        Me.tbx_Description.Multiline = True
        Me.tbx_Description.Name = "tbx_Description"
        Me.tbx_Description.Size = New System.Drawing.Size(391, 55)
        Me.tbx_Description.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Description"
        '
        'cbx_Type
        '
        Me.cbx_Type.FormattingEnabled = True
        Me.cbx_Type.Location = New System.Drawing.Point(90, 20)
        Me.cbx_Type.Name = "cbx_Type"
        Me.cbx_Type.Size = New System.Drawing.Size(210, 21)
        Me.cbx_Type.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Revision"
        '
        'tbx_Revision
        '
        Me.tbx_Revision.Location = New System.Drawing.Point(90, 133)
        Me.tbx_Revision.MaxLength = 50
        Me.tbx_Revision.Name = "tbx_Revision"
        Me.tbx_Revision.Size = New System.Drawing.Size(106, 20)
        Me.tbx_Revision.TabIndex = 8
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(325, 206)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 11
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(406, 206)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 12
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Browse
        '
        Me.btn_Browse.Location = New System.Drawing.Point(406, 159)
        Me.btn_Browse.Name = "btn_Browse"
        Me.btn_Browse.Size = New System.Drawing.Size(75, 23)
        Me.btn_Browse.TabIndex = 13
        Me.btn_Browse.Text = "Browse"
        Me.btn_Browse.UseVisualStyleBackColor = True
        '
        'tbx_FileName
        '
        Me.tbx_FileName.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbx_FileName.Location = New System.Drawing.Point(90, 161)
        Me.tbx_FileName.MaxLength = 50
        Me.tbx_FileName.Name = "tbx_FileName"
        Me.tbx_FileName.ReadOnly = True
        Me.tbx_FileName.Size = New System.Drawing.Size(310, 20)
        Me.tbx_FileName.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Filename"
        '
        'AddDocRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 249)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbx_FileName)
        Me.Controls.Add(Me.btn_Browse)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.tbx_Revision)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbx_Type)
        Me.Controls.Add(Me.tbx_Description)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbx_Title)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddDocRef"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Document Reference"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbx_Title As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbx_Description As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbx_Type As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbx_Revision As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Browse As System.Windows.Forms.Button
    Friend WithEvents tbx_FileName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
