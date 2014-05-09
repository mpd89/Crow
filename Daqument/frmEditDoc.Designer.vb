<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditDoc
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
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.OpenFD = New System.Windows.Forms.OpenFileDialog
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_DocType = New System.Windows.Forms.Button
        Me.tbx_DocType = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtEngCode = New System.Windows.Forms.TextBox
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbl_Location = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.txtSheetOf = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRevision = New System.Windows.Forms.TextBox
        Me.txtSheet = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ckbx_Color = New System.Windows.Forms.CheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.btn_Reload = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.btn_Upload = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.tbx_FileName = New System.Windows.Forms.TextBox
        Me.tbx_Vdpi = New System.Windows.Forms.TextBox
        Me.tbx_Hdpi = New System.Windows.Forms.TextBox
        Me.ipw_Image = New Daqument.ImagePreview
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(665, 545)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 61
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'OpenFD
        '
        Me.OpenFD.FileName = "OpenFileDialog1"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(584, 545)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 74
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_DocType)
        Me.GroupBox1.Controls.Add(Me.tbx_DocType)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtEngCode)
        Me.GroupBox1.Controls.Add(Me.txtLocation)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lbl_Location)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtClientCode)
        Me.GroupBox1.Controls.Add(Me.txtSheetOf)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtRevision)
        Me.GroupBox1.Controls.Add(Me.txtSheet)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 273)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 295)
        Me.GroupBox1.TabIndex = 76
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Document Information"
        '
        'btn_DocType
        '
        Me.btn_DocType.Location = New System.Drawing.Point(285, 133)
        Me.btn_DocType.Name = "btn_DocType"
        Me.btn_DocType.Size = New System.Drawing.Size(34, 20)
        Me.btn_DocType.TabIndex = 53
        Me.btn_DocType.Text = "..."
        Me.btn_DocType.UseVisualStyleBackColor = True
        '
        'tbx_DocType
        '
        Me.tbx_DocType.Location = New System.Drawing.Point(110, 133)
        Me.tbx_DocType.Name = "tbx_DocType"
        Me.tbx_DocType.ReadOnly = True
        Me.tbx_DocType.Size = New System.Drawing.Size(168, 20)
        Me.tbx_DocType.TabIndex = 52
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Document Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Engineering Code"
        '
        'txtEngCode
        '
        Me.txtEngCode.Location = New System.Drawing.Point(110, 18)
        Me.txtEngCode.Name = "txtEngCode"
        Me.txtEngCode.Size = New System.Drawing.Size(168, 20)
        Me.txtEngCode.TabIndex = 30
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(110, 159)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(168, 20)
        Me.txtLocation.TabIndex = 48
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(110, 190)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(238, 87)
        Me.txtDescription.TabIndex = 45
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(70, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Title"
        '
        'lbl_Location
        '
        Me.lbl_Location.AutoSize = True
        Me.lbl_Location.Location = New System.Drawing.Point(49, 159)
        Me.lbl_Location.Name = "lbl_Location"
        Me.lbl_Location.Size = New System.Drawing.Size(48, 13)
        Me.lbl_Location.TabIndex = 47
        Me.lbl_Location.Text = "Location"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Client Code"
        '
        'txtClientCode
        '
        Me.txtClientCode.Location = New System.Drawing.Point(110, 50)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(168, 20)
        Me.txtClientCode.TabIndex = 32
        '
        'txtSheetOf
        '
        Me.txtSheetOf.Location = New System.Drawing.Point(238, 76)
        Me.txtSheetOf.Name = "txtSheetOf"
        Me.txtSheetOf.Size = New System.Drawing.Size(40, 20)
        Me.txtSheetOf.TabIndex = 38
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Sheet"
        '
        'txtRevision
        '
        Me.txtRevision.Location = New System.Drawing.Point(110, 106)
        Me.txtRevision.Name = "txtRevision"
        Me.txtRevision.Size = New System.Drawing.Size(168, 20)
        Me.txtRevision.TabIndex = 44
        '
        'txtSheet
        '
        Me.txtSheet.Location = New System.Drawing.Point(110, 79)
        Me.txtSheet.Name = "txtSheet"
        Me.txtSheet.Size = New System.Drawing.Size(37, 20)
        Me.txtSheet.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(49, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Revision"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(182, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "of"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ckbx_Color)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.btn_Reload)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.btn_Upload)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.tbx_FileName)
        Me.GroupBox2.Controls.Add(Me.tbx_Vdpi)
        Me.GroupBox2.Controls.Add(Me.tbx_Hdpi)
        Me.GroupBox2.Location = New System.Drawing.Point(425, 273)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(321, 251)
        Me.GroupBox2.TabIndex = 77
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Image Import Information"
        '
        'ckbx_Color
        '
        Me.ckbx_Color.AutoSize = True
        Me.ckbx_Color.Location = New System.Drawing.Point(79, 109)
        Me.ckbx_Color.Name = "ckbx_Color"
        Me.ckbx_Color.Size = New System.Drawing.Size(98, 17)
        Me.ckbx_Color.TabIndex = 56
        Me.ckbx_Color.Text = "Upload in Color"
        Me.ckbx_Color.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Vertical dpi"
        '
        'btn_Reload
        '
        Me.btn_Reload.Location = New System.Drawing.Point(257, 42)
        Me.btn_Reload.Name = "btn_Reload"
        Me.btn_Reload.Size = New System.Drawing.Size(58, 23)
        Me.btn_Reload.TabIndex = 52
        Me.btn_Reload.Text = "Reload"
        Me.btn_Reload.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(2, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Horizontal dpi"
        '
        'btn_Upload
        '
        Me.btn_Upload.Location = New System.Drawing.Point(257, 12)
        Me.btn_Upload.Name = "btn_Upload"
        Me.btn_Upload.Size = New System.Drawing.Size(58, 24)
        Me.btn_Upload.TabIndex = 49
        Me.btn_Upload.Text = "Upload"
        Me.btn_Upload.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "File Name"
        '
        'tbx_FileName
        '
        Me.tbx_FileName.BackColor = System.Drawing.SystemColors.Window
        Me.tbx_FileName.Location = New System.Drawing.Point(79, 17)
        Me.tbx_FileName.Name = "tbx_FileName"
        Me.tbx_FileName.ReadOnly = True
        Me.tbx_FileName.Size = New System.Drawing.Size(172, 20)
        Me.tbx_FileName.TabIndex = 2
        '
        'tbx_Vdpi
        '
        Me.tbx_Vdpi.Location = New System.Drawing.Point(79, 77)
        Me.tbx_Vdpi.Name = "tbx_Vdpi"
        Me.tbx_Vdpi.Size = New System.Drawing.Size(79, 20)
        Me.tbx_Vdpi.TabIndex = 1
        Me.tbx_Vdpi.Text = "150"
        '
        'tbx_Hdpi
        '
        Me.tbx_Hdpi.Location = New System.Drawing.Point(79, 46)
        Me.tbx_Hdpi.Name = "tbx_Hdpi"
        Me.tbx_Hdpi.Size = New System.Drawing.Size(79, 20)
        Me.tbx_Hdpi.TabIndex = 0
        Me.tbx_Hdpi.Text = "150"
        '
        'ipw_Image
        '
        Me.ipw_Image.AutoScroll = True
        Me.ipw_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ipw_Image.Location = New System.Drawing.Point(12, 12)
        Me.ipw_Image.Name = "ipw_Image"
        Me.ipw_Image.Size = New System.Drawing.Size(734, 249)
        Me.ipw_Image.TabIndex = 75
        '
        'frmEditDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 583)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ipw_Image)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUpdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditDoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Document"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents OpenFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ipw_Image As Daqument.ImagePreview
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEngCode As System.Windows.Forms.TextBox
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_Location As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSheetOf As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRevision As System.Windows.Forms.TextBox
    Friend WithEvents txtSheet As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_Reload As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_Upload As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbx_FileName As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Vdpi As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Hdpi As System.Windows.Forms.TextBox
    Friend WithEvents btn_DocType As System.Windows.Forms.Button
    Friend WithEvents tbx_DocType As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ckbx_Color As System.Windows.Forms.CheckBox
End Class
