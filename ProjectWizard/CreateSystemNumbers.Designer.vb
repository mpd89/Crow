<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateSystemNumbers
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
        Me.SystemNumberPanel1 = New System.Windows.Forms.Panel
        Me.SystemNumberPanel2 = New System.Windows.Forms.Panel
        Me.CreateSystemNumbersFinish = New System.Windows.Forms.Button
        Me.CreateSystemNumbersCancel = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'SystemNumberPanel1
        '
        Me.SystemNumberPanel1.AutoScroll = True
        Me.SystemNumberPanel1.Location = New System.Drawing.Point(0, 40)
        Me.SystemNumberPanel1.Name = "SystemNumberPanel1"
        Me.SystemNumberPanel1.Size = New System.Drawing.Size(690, 475)
        Me.SystemNumberPanel1.TabIndex = 0
        '
        'SystemNumberPanel2
        '
        Me.SystemNumberPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SystemNumberPanel2.Name = "SystemNumberPanel2"
        Me.SystemNumberPanel2.Size = New System.Drawing.Size(690, 40)
        Me.SystemNumberPanel2.TabIndex = 1
        '
        'CreateSystemNumbersFinish
        '
        Me.CreateSystemNumbersFinish.Enabled = False
        Me.CreateSystemNumbersFinish.Location = New System.Drawing.Point(605, 531)
        Me.CreateSystemNumbersFinish.Name = "CreateSystemNumbersFinish"
        Me.CreateSystemNumbersFinish.Size = New System.Drawing.Size(75, 23)
        Me.CreateSystemNumbersFinish.TabIndex = 2
        Me.CreateSystemNumbersFinish.Text = "Finish"
        Me.CreateSystemNumbersFinish.UseVisualStyleBackColor = True
        '
        'CreateSystemNumbersCancel
        '
        Me.CreateSystemNumbersCancel.Location = New System.Drawing.Point(524, 531)
        Me.CreateSystemNumbersCancel.Name = "CreateSystemNumbersCancel"
        Me.CreateSystemNumbersCancel.Size = New System.Drawing.Size(75, 23)
        Me.CreateSystemNumbersCancel.TabIndex = 3
        Me.CreateSystemNumbersCancel.Text = "Cancel"
        Me.CreateSystemNumbersCancel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(443, 531)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Import"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.ProjectWizard.My.Resources.Resources.Help
        Me.Button2.Location = New System.Drawing.Point(12, 531)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CreateSystemNumbers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 562)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CreateSystemNumbersCancel)
        Me.Controls.Add(Me.CreateSystemNumbersFinish)
        Me.Controls.Add(Me.SystemNumberPanel1)
        Me.Controls.Add(Me.SystemNumberPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "CreateSystemNumbers"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create System Numbers"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SystemNumberPanel1 As System.Windows.Forms.Panel
    Friend WithEvents SystemNumberPanel2 As System.Windows.Forms.Panel
    Friend WithEvents CreateSystemNumbersFinish As System.Windows.Forms.Button
    Friend WithEvents CreateSystemNumbersCancel As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
