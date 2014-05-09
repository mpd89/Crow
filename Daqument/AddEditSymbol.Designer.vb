<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEditSymbol
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbx_Name = New System.Windows.Forms.TextBox
        Me.btn_Upload = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_Save = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(260, 173)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 199)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'tbx_Name
        '
        Me.tbx_Name.Location = New System.Drawing.Point(50, 192)
        Me.tbx_Name.Name = "tbx_Name"
        Me.tbx_Name.Size = New System.Drawing.Size(222, 20)
        Me.tbx_Name.TabIndex = 2
        '
        'btn_Upload
        '
        Me.btn_Upload.Location = New System.Drawing.Point(12, 227)
        Me.btn_Upload.Name = "btn_Upload"
        Me.btn_Upload.Size = New System.Drawing.Size(75, 23)
        Me.btn_Upload.TabIndex = 3
        Me.btn_Upload.Text = "Upload"
        Me.btn_Upload.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(106, 227)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 4
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Enabled = False
        Me.btn_Save.Location = New System.Drawing.Point(197, 227)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(75, 23)
        Me.btn_Save.TabIndex = 5
        Me.btn_Save.Text = "Save"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'AddEditSymbol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Upload)
        Me.Controls.Add(Me.tbx_Name)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.Name = "AddEditSymbol"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add/Edit Symbol"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbx_Name As System.Windows.Forms.TextBox
    Friend WithEvents btn_Upload As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
