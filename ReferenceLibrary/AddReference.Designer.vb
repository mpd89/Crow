<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddReference
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
        Me.ckbx_Transmittal = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Browse = New System.Windows.Forms.Button
        Me.tbx_FileName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbx_TransmittalReturnedMethod = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.date_TransmittalReturnedDate = New System.Windows.Forms.DateTimePicker
        Me.cbx_TransmittalToDestination = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cbx_TransmittalToCompany = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cbx_TransmittalToName = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbx_TransmittalMethod = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.tbx_TransmittalContents = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbx_TransmittalFromCompany = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbx_TransmittalFromName = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.date_TransmittalDate = New System.Windows.Forms.DateTimePicker
        Me.cbx_TransmittalDirection = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbx_TransmittalNumber = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
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
        'ckbx_Transmittal
        '
        Me.ckbx_Transmittal.AutoSize = True
        Me.ckbx_Transmittal.Enabled = False
        Me.ckbx_Transmittal.Location = New System.Drawing.Point(90, 160)
        Me.ckbx_Transmittal.Name = "ckbx_Transmittal"
        Me.ckbx_Transmittal.Size = New System.Drawing.Size(15, 14)
        Me.ckbx_Transmittal.TabIndex = 9
        Me.ckbx_Transmittal.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Transmittal"
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(325, 225)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 11
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(406, 225)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 12
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Browse
        '
        Me.btn_Browse.Location = New System.Drawing.Point(406, 181)
        Me.btn_Browse.Name = "btn_Browse"
        Me.btn_Browse.Size = New System.Drawing.Size(75, 23)
        Me.btn_Browse.TabIndex = 13
        Me.btn_Browse.Text = "Browse"
        Me.btn_Browse.UseVisualStyleBackColor = True
        '
        'tbx_FileName
        '
        Me.tbx_FileName.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbx_FileName.Location = New System.Drawing.Point(90, 183)
        Me.tbx_FileName.MaxLength = 50
        Me.tbx_FileName.Name = "tbx_FileName"
        Me.tbx_FileName.ReadOnly = True
        Me.tbx_FileName.Size = New System.Drawing.Size(310, 20)
        Me.tbx_FileName.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Filename"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbx_TransmittalReturnedMethod)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.date_TransmittalReturnedDate)
        Me.GroupBox1.Controls.Add(Me.cbx_TransmittalToDestination)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cbx_TransmittalToCompany)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cbx_TransmittalToName)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cbx_TransmittalMethod)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.tbx_TransmittalContents)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cbx_TransmittalFromCompany)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbx_TransmittalFromName)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.date_TransmittalDate)
        Me.GroupBox1.Controls.Add(Me.cbx_TransmittalDirection)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbx_TransmittalNumber)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 182)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(465, 296)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transmittal Info"
        Me.GroupBox1.Visible = False
        '
        'cbx_TransmittalReturnedMethod
        '
        Me.cbx_TransmittalReturnedMethod.FormattingEnabled = True
        Me.cbx_TransmittalReturnedMethod.Location = New System.Drawing.Point(167, 269)
        Me.cbx_TransmittalReturnedMethod.Name = "cbx_TransmittalReturnedMethod"
        Me.cbx_TransmittalReturnedMethod.Size = New System.Drawing.Size(276, 21)
        Me.cbx_TransmittalReturnedMethod.TabIndex = 39
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(164, 253)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Method"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 253)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 13)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "Returned"
        '
        'date_TransmittalReturnedDate
        '
        Me.date_TransmittalReturnedDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_TransmittalReturnedDate.Location = New System.Drawing.Point(12, 270)
        Me.date_TransmittalReturnedDate.Name = "date_TransmittalReturnedDate"
        Me.date_TransmittalReturnedDate.Size = New System.Drawing.Size(146, 20)
        Me.date_TransmittalReturnedDate.TabIndex = 36
        '
        'cbx_TransmittalToDestination
        '
        Me.cbx_TransmittalToDestination.FormattingEnabled = True
        Me.cbx_TransmittalToDestination.Location = New System.Drawing.Point(12, 218)
        Me.cbx_TransmittalToDestination.Name = "cbx_TransmittalToDestination"
        Me.cbx_TransmittalToDestination.Size = New System.Drawing.Size(175, 21)
        Me.cbx_TransmittalToDestination.TabIndex = 35
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 202)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Destination"
        '
        'cbx_TransmittalToCompany
        '
        Me.cbx_TransmittalToCompany.FormattingEnabled = True
        Me.cbx_TransmittalToCompany.Location = New System.Drawing.Point(199, 170)
        Me.cbx_TransmittalToCompany.Name = "cbx_TransmittalToCompany"
        Me.cbx_TransmittalToCompany.Size = New System.Drawing.Size(244, 21)
        Me.cbx_TransmittalToCompany.TabIndex = 33
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(196, 154)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Company"
        '
        'cbx_TransmittalToName
        '
        Me.cbx_TransmittalToName.FormattingEnabled = True
        Me.cbx_TransmittalToName.Location = New System.Drawing.Point(12, 170)
        Me.cbx_TransmittalToName.Name = "cbx_TransmittalToName"
        Me.cbx_TransmittalToName.Size = New System.Drawing.Size(175, 21)
        Me.cbx_TransmittalToName.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 154)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(20, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "To"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(287, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Date"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(196, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Direction"
        '
        'cbx_TransmittalMethod
        '
        Me.cbx_TransmittalMethod.FormattingEnabled = True
        Me.cbx_TransmittalMethod.Location = New System.Drawing.Point(268, 125)
        Me.cbx_TransmittalMethod.Name = "cbx_TransmittalMethod"
        Me.cbx_TransmittalMethod.Size = New System.Drawing.Size(175, 21)
        Me.cbx_TransmittalMethod.TabIndex = 27
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(265, 109)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Method"
        '
        'tbx_TransmittalContents
        '
        Me.tbx_TransmittalContents.Location = New System.Drawing.Point(12, 126)
        Me.tbx_TransmittalContents.MaxLength = 50
        Me.tbx_TransmittalContents.Name = "tbx_TransmittalContents"
        Me.tbx_TransmittalContents.Size = New System.Drawing.Size(253, 20)
        Me.tbx_TransmittalContents.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Contents"
        '
        'cbx_TransmittalFromCompany
        '
        Me.cbx_TransmittalFromCompany.FormattingEnabled = True
        Me.cbx_TransmittalFromCompany.Location = New System.Drawing.Point(199, 80)
        Me.cbx_TransmittalFromCompany.Name = "cbx_TransmittalFromCompany"
        Me.cbx_TransmittalFromCompany.Size = New System.Drawing.Size(244, 21)
        Me.cbx_TransmittalFromCompany.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(196, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Company"
        '
        'cbx_TransmittalFromName
        '
        Me.cbx_TransmittalFromName.FormattingEnabled = True
        Me.cbx_TransmittalFromName.Location = New System.Drawing.Point(12, 80)
        Me.cbx_TransmittalFromName.Name = "cbx_TransmittalFromName"
        Me.cbx_TransmittalFromName.Size = New System.Drawing.Size(175, 21)
        Me.cbx_TransmittalFromName.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "From"
        '
        'date_TransmittalDate
        '
        Me.date_TransmittalDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_TransmittalDate.Location = New System.Drawing.Point(290, 36)
        Me.date_TransmittalDate.Name = "date_TransmittalDate"
        Me.date_TransmittalDate.Size = New System.Drawing.Size(153, 20)
        Me.date_TransmittalDate.TabIndex = 19
        '
        'cbx_TransmittalDirection
        '
        Me.cbx_TransmittalDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_TransmittalDirection.FormattingEnabled = True
        Me.cbx_TransmittalDirection.Items.AddRange(New Object() {"In", "Out"})
        Me.cbx_TransmittalDirection.Location = New System.Drawing.Point(199, 35)
        Me.cbx_TransmittalDirection.Name = "cbx_TransmittalDirection"
        Me.cbx_TransmittalDirection.Size = New System.Drawing.Size(85, 21)
        Me.cbx_TransmittalDirection.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Number"
        '
        'cbx_TransmittalNumber
        '
        Me.cbx_TransmittalNumber.FormattingEnabled = True
        Me.cbx_TransmittalNumber.Location = New System.Drawing.Point(12, 35)
        Me.cbx_TransmittalNumber.Name = "cbx_TransmittalNumber"
        Me.cbx_TransmittalNumber.Size = New System.Drawing.Size(175, 21)
        Me.cbx_TransmittalNumber.TabIndex = 0
        '
        'AddReference
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 258)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbx_FileName)
        Me.Controls.Add(Me.btn_Browse)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ckbx_Transmittal)
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
        Me.Name = "AddReference"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Reference"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents ckbx_Transmittal As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Browse As System.Windows.Forms.Button
    Friend WithEvents tbx_FileName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents date_TransmittalDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbx_TransmittalDirection As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbx_TransmittalNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_TransmittalMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbx_TransmittalContents As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbx_TransmittalFromCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbx_TransmittalFromName As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbx_TransmittalToCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbx_TransmittalToName As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbx_TransmittalToDestination As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbx_TransmittalReturnedMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents date_TransmittalReturnedDate As System.Windows.Forms.DateTimePicker
End Class
