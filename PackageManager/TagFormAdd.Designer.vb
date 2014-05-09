<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagFormAdd
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.cboPkgNum = New System.Windows.Forms.ComboBox
        Me.cboTypeID = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Add New Tag"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(291, 189)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(291, 145)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cboPkgNum
        '
        Me.cboPkgNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPkgNum.FormattingEnabled = True
        Me.cboPkgNum.Location = New System.Drawing.Point(36, 135)
        Me.cboPkgNum.Name = "cboPkgNum"
        Me.cboPkgNum.Size = New System.Drawing.Size(121, 21)
        Me.cboPkgNum.TabIndex = 3
        '
        'cboTypeID
        '
        Me.cboTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeID.FormattingEnabled = True
        Me.cboTypeID.Location = New System.Drawing.Point(36, 189)
        Me.cboTypeID.Name = "cboTypeID"
        Me.cboTypeID.Size = New System.Drawing.Size(121, 21)
        Me.cboTypeID.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(36, 81)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(121, 20)
        Me.TextBox1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tag Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Package Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "TypeID"
        '
        'TagFormAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 266)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cboTypeID)
        Me.Controls.Add(Me.cboPkgNum)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TagFormAdd"
        Me.Text = "Add New Tag"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cboPkgNum As System.Windows.Forms.ComboBox
    Friend WithEvents cboTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
