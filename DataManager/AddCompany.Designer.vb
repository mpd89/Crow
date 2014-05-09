<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCompany
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
        Me.lblStatus = New System.Windows.Forms.Label
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(54, 176)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 22
        Me.lblStatus.Text = "Status"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(143, 174)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 17
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(221, 214)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(302, 214)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 18
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(54, 39)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 29)
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(143, 133)
        Me.txtDescription.MaxLength = 100
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(234, 20)
        Me.txtDescription.TabIndex = 15
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(54, 133)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 16
        Me.lblDescription.Text = "Description"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(143, 90)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 20)
        Me.txtName.TabIndex = 13
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(54, 90)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 14
        Me.lblName.Text = "Name"
        '
        'AddCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 256)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "AddCompany"
        Me.Text = "Add Company"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
End Class
