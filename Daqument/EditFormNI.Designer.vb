<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditFormNI
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
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblTag = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtRevision = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSource = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtSheetOf = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSheet = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.OpenFD = New System.Windows.Forms.OpenFileDialog
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEngCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.lblDID = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(632, 276)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 71
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(498, 363)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(168, 20)
        Me.txtLocation.TabIndex = 70
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(432, 363)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Location"
        '
        'lblTag
        '
        Me.lblTag.AutoSize = True
        Me.lblTag.Location = New System.Drawing.Point(567, 530)
        Me.lblTag.Name = "lblTag"
        Me.lblTag.Size = New System.Drawing.Size(0, 13)
        Me.lblTag.TabIndex = 68
        Me.lblTag.Visible = False
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(498, 408)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(238, 121)
        Me.txtDescription.TabIndex = 67
        '
        'txtRevision
        '
        Me.txtRevision.Location = New System.Drawing.Point(190, 467)
        Me.txtRevision.Name = "txtRevision"
        Me.txtRevision.Size = New System.Drawing.Size(168, 20)
        Me.txtRevision.TabIndex = 66
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(431, 411)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Description"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(86, 467)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Revision"
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(102, 560)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(100, 20)
        Me.txtSource.TabIndex = 63
        Me.txtSource.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(396, 553)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 62
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(295, 553)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 61
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtSheetOf
        '
        Me.txtSheetOf.Location = New System.Drawing.Point(318, 411)
        Me.txtSheetOf.Name = "txtSheetOf"
        Me.txtSheetOf.Size = New System.Drawing.Size(40, 20)
        Me.txtSheetOf.TabIndex = 60
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(262, 417)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 13)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "of"
        '
        'txtSheet
        '
        Me.txtSheet.Location = New System.Drawing.Point(190, 414)
        Me.txtSheet.Name = "txtSheet"
        Me.txtSheet.Size = New System.Drawing.Size(37, 20)
        Me.txtSheet.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(90, 414)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Sheet"
        '
        'cmbProject
        '
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(498, 319)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(168, 21)
        Me.cmbProject.TabIndex = 56
        '
        'OpenFD
        '
        Me.OpenFD.FileName = "OpenFileDialog1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(431, 319)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Project"
        '
        'txtClientCode
        '
        Me.txtClientCode.Location = New System.Drawing.Point(190, 366)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(168, 20)
        Me.txtClientCode.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(86, 366)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Client Code"
        '
        'txtEngCode
        '
        Me.txtEngCode.Location = New System.Drawing.Point(190, 319)
        Me.txtEngCode.Name = "txtEngCode"
        Me.txtEngCode.Size = New System.Drawing.Size(168, 20)
        Me.txtEngCode.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 319)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Engineering Code"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(-1, -6)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(824, 264)
        Me.WebBrowser1.TabIndex = 50
        '
        'lblDID
        '
        Me.lblDID.AutoSize = True
        Me.lblDID.Location = New System.Drawing.Point(12, 299)
        Me.lblDID.Name = "lblDID"
        Me.lblDID.Size = New System.Drawing.Size(39, 13)
        Me.lblDID.TabIndex = 72
        Me.lblDID.Text = "Label9"
        Me.lblDID.Visible = False
        '
        'EditFormNI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 606)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDID)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblTag)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtRevision)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtSheetOf)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSheet)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbProject)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtClientCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEngCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Name = "EditFormNI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EditFormNI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTag As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtRevision As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtSheetOf As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSheet As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents OpenFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEngCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents lblDID As System.Windows.Forms.Label
End Class
