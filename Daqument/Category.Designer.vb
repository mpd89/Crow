<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Category
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
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.lblTag = New System.Windows.Forms.Label
        Me.ckb_Disable11x17 = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Category Code"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(124, 69)
        Me.txtCode.MaxLength = 10
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCode.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Category Description"
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(124, 109)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(213, 20)
        Me.txtDesc.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(205, 188)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(290, 188)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lblTag
        '
        Me.lblTag.AutoSize = True
        Me.lblTag.Location = New System.Drawing.Point(16, 33)
        Me.lblTag.Name = "lblTag"
        Me.lblTag.Size = New System.Drawing.Size(0, 13)
        Me.lblTag.TabIndex = 7
        Me.lblTag.Visible = False
        '
        'ckb_Disable11x17
        '
        Me.ckb_Disable11x17.AutoSize = True
        Me.ckb_Disable11x17.Location = New System.Drawing.Point(124, 149)
        Me.ckb_Disable11x17.Name = "ckb_Disable11x17"
        Me.ckb_Disable11x17.Size = New System.Drawing.Size(117, 17)
        Me.ckb_Disable11x17.TabIndex = 8
        Me.ckb_Disable11x17.Text = "Disable 11x17 Print"
        Me.ckb_Disable11x17.UseVisualStyleBackColor = True
        '
        'Category
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 222)
        Me.Controls.Add(Me.ckb_Disable11x17)
        Me.Controls.Add(Me.lblTag)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Category"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Document Category"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblTag As System.Windows.Forms.Label
    Friend WithEvents ckb_Disable11x17 As System.Windows.Forms.CheckBox
End Class
