<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportReadIndex
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbx_FileName = New System.Windows.Forms.ComboBox
        Me.cbx_EngCode = New System.Windows.Forms.ComboBox
        Me.cbx_ClientCode = New System.Windows.Forms.ComboBox
        Me.cbx_Revision = New System.Windows.Forms.ComboBox
        Me.cbx_Description = New System.Windows.Forms.ComboBox
        Me.cbx_Sheet = New System.Windows.Forms.ComboBox
        Me.cbx_Sheets = New System.Windows.Forms.ComboBox
        Me.cbx_Location = New System.Windows.Forms.ComboBox
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.cbx_RowHeaders = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select the appropriate columns from the index file."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "File Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Engineering Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Client Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Revision"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Description"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Sheet Number"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Sheets Total"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 271)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Location"
        '
        'cbx_FileName
        '
        Me.cbx_FileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_FileName.FormattingEnabled = True
        Me.cbx_FileName.Location = New System.Drawing.Point(158, 82)
        Me.cbx_FileName.Name = "cbx_FileName"
        Me.cbx_FileName.Size = New System.Drawing.Size(241, 21)
        Me.cbx_FileName.TabIndex = 9
        '
        'cbx_EngCode
        '
        Me.cbx_EngCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_EngCode.FormattingEnabled = True
        Me.cbx_EngCode.Location = New System.Drawing.Point(158, 109)
        Me.cbx_EngCode.Name = "cbx_EngCode"
        Me.cbx_EngCode.Size = New System.Drawing.Size(241, 21)
        Me.cbx_EngCode.TabIndex = 10
        '
        'cbx_ClientCode
        '
        Me.cbx_ClientCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ClientCode.FormattingEnabled = True
        Me.cbx_ClientCode.Location = New System.Drawing.Point(158, 136)
        Me.cbx_ClientCode.Name = "cbx_ClientCode"
        Me.cbx_ClientCode.Size = New System.Drawing.Size(241, 21)
        Me.cbx_ClientCode.TabIndex = 11
        '
        'cbx_Revision
        '
        Me.cbx_Revision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Revision.FormattingEnabled = True
        Me.cbx_Revision.Location = New System.Drawing.Point(158, 163)
        Me.cbx_Revision.Name = "cbx_Revision"
        Me.cbx_Revision.Size = New System.Drawing.Size(241, 21)
        Me.cbx_Revision.TabIndex = 12
        '
        'cbx_Description
        '
        Me.cbx_Description.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Description.FormattingEnabled = True
        Me.cbx_Description.Location = New System.Drawing.Point(158, 190)
        Me.cbx_Description.Name = "cbx_Description"
        Me.cbx_Description.Size = New System.Drawing.Size(241, 21)
        Me.cbx_Description.TabIndex = 13
        '
        'cbx_Sheet
        '
        Me.cbx_Sheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Sheet.FormattingEnabled = True
        Me.cbx_Sheet.Location = New System.Drawing.Point(158, 217)
        Me.cbx_Sheet.Name = "cbx_Sheet"
        Me.cbx_Sheet.Size = New System.Drawing.Size(241, 21)
        Me.cbx_Sheet.TabIndex = 14
        '
        'cbx_Sheets
        '
        Me.cbx_Sheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Sheets.FormattingEnabled = True
        Me.cbx_Sheets.Location = New System.Drawing.Point(158, 244)
        Me.cbx_Sheets.Name = "cbx_Sheets"
        Me.cbx_Sheets.Size = New System.Drawing.Size(241, 21)
        Me.cbx_Sheets.TabIndex = 15
        '
        'cbx_Location
        '
        Me.cbx_Location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Location.FormattingEnabled = True
        Me.cbx_Location.Location = New System.Drawing.Point(158, 271)
        Me.cbx_Location.Name = "cbx_Location"
        Me.cbx_Location.Size = New System.Drawing.Size(241, 21)
        Me.cbx_Location.TabIndex = 16
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(324, 313)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 17
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(243, 313)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 18
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'cbx_RowHeaders
        '
        Me.cbx_RowHeaders.AutoSize = True
        Me.cbx_RowHeaders.Checked = True
        Me.cbx_RowHeaders.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbx_RowHeaders.Location = New System.Drawing.Point(158, 41)
        Me.cbx_RowHeaders.Name = "cbx_RowHeaders"
        Me.cbx_RowHeaders.Size = New System.Drawing.Size(152, 17)
        Me.cbx_RowHeaders.TabIndex = 19
        Me.cbx_RowHeaders.Text = "First row contains headers."
        Me.cbx_RowHeaders.UseVisualStyleBackColor = True
        '
        'ImportReadIndex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 368)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbx_RowHeaders)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.cbx_Location)
        Me.Controls.Add(Me.cbx_Sheets)
        Me.Controls.Add(Me.cbx_Sheet)
        Me.Controls.Add(Me.cbx_Description)
        Me.Controls.Add(Me.cbx_Revision)
        Me.Controls.Add(Me.cbx_ClientCode)
        Me.Controls.Add(Me.cbx_EngCode)
        Me.Controls.Add(Me.cbx_FileName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ImportReadIndex"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Document Import Index"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbx_FileName As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_EngCode As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_ClientCode As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Revision As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Description As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Sheet As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Sheets As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Location As System.Windows.Forms.ComboBox
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents cbx_RowHeaders As System.Windows.Forms.CheckBox
End Class
