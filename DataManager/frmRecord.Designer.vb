<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecord
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
        Me.lblEditName = New System.Windows.Forms.Label
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
        Me.lblStatus.Location = New System.Drawing.Point(44, 161)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 42
        Me.lblStatus.Text = "Status"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(133, 159)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 37
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(146, 199)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 39
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(227, 199)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 38
        Me.btnAdd.Text = "Update"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblEditName
        '
        Me.lblEditName.AutoSize = True
        Me.lblEditName.Location = New System.Drawing.Point(130, 40)
        Me.lblEditName.Name = "lblEditName"
        Me.lblEditName.Size = New System.Drawing.Size(0, 13)
        Me.lblEditName.TabIndex = 41
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(44, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 29)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(133, 118)
        Me.txtDescription.MaxLength = 100
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(144, 20)
        Me.txtDescription.TabIndex = 35
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(44, 118)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 36
        Me.lblDescription.Text = "Description"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(133, 75)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(144, 20)
        Me.txtName.TabIndex = 33
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(44, 75)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 34
        Me.lblName.Text = "Name"
        '
        'frmRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 236)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblEditName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmRecord"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Properties"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblEditName As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
End Class
