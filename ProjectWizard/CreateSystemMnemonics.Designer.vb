<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateSystemMnemonics
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SystemMnemonicCount = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.SystemMnemonicCancel = New System.Windows.Forms.Button
        Me.SystemMnemonicsPanel1 = New System.Windows.Forms.Panel
        Me.SystemMnemonicNext1 = New System.Windows.Forms.Button
        Me.SystemMnemonicsPanel2 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.SystemMnemonicsPanel3 = New System.Windows.Forms.Panel
        Me.SystemMnemonicsPanel2Next = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SystemMnemonicsPanel4 = New System.Windows.Forms.Panel
        Me.SampleMnemonic = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.SystemMnemonicsPanel4Back = New System.Windows.Forms.Button
        Me.SystemMnemonicsPanel4Finish = New System.Windows.Forms.Button
        Me.SystemMnemonicsPanel4Cancel = New System.Windows.Forms.Button
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.GroupBox1.SuspendLayout()
        CType(Me.SystemMnemonicCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SystemMnemonicsPanel1.SuspendLayout()
        Me.SystemMnemonicsPanel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SystemMnemonicsPanel4.SuspendLayout()
        Me.SampleMnemonic.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SystemMnemonicCount)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(540, 219)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System Mnemonics"
        '
        'SystemMnemonicCount
        '
        Me.SystemMnemonicCount.Location = New System.Drawing.Point(252, 94)
        Me.SystemMnemonicCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SystemMnemonicCount.Name = "SystemMnemonicCount"
        Me.SystemMnemonicCount.Size = New System.Drawing.Size(50, 20)
        Me.SystemMnemonicCount.TabIndex = 9
        Me.SystemMnemonicCount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(166, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Select the number of System levels or tiers:"
        '
        'SystemMnemonicCancel
        '
        Me.SystemMnemonicCancel.Location = New System.Drawing.Point(12, 257)
        Me.SystemMnemonicCancel.Name = "SystemMnemonicCancel"
        Me.SystemMnemonicCancel.Size = New System.Drawing.Size(75, 23)
        Me.SystemMnemonicCancel.TabIndex = 9
        Me.SystemMnemonicCancel.Text = "Cancel"
        Me.SystemMnemonicCancel.UseVisualStyleBackColor = True
        '
        'SystemMnemonicsPanel1
        '
        Me.SystemMnemonicsPanel1.Controls.Add(Me.SystemMnemonicNext1)
        Me.SystemMnemonicsPanel1.Controls.Add(Me.SystemMnemonicCancel)
        Me.SystemMnemonicsPanel1.Controls.Add(Me.GroupBox1)
        Me.SystemMnemonicsPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SystemMnemonicsPanel1.Name = "SystemMnemonicsPanel1"
        Me.SystemMnemonicsPanel1.Size = New System.Drawing.Size(572, 290)
        Me.SystemMnemonicsPanel1.TabIndex = 12
        '
        'SystemMnemonicNext1
        '
        Me.SystemMnemonicNext1.Location = New System.Drawing.Point(481, 256)
        Me.SystemMnemonicNext1.Name = "SystemMnemonicNext1"
        Me.SystemMnemonicNext1.Size = New System.Drawing.Size(75, 23)
        Me.SystemMnemonicNext1.TabIndex = 8
        Me.SystemMnemonicNext1.Text = "Next"
        Me.SystemMnemonicNext1.UseVisualStyleBackColor = True
        '
        'SystemMnemonicsPanel2
        '
        Me.SystemMnemonicsPanel2.Controls.Add(Me.Label4)
        Me.SystemMnemonicsPanel2.Controls.Add(Me.Button1)
        Me.SystemMnemonicsPanel2.Controls.Add(Me.Label7)
        Me.SystemMnemonicsPanel2.Controls.Add(Me.Label3)
        Me.SystemMnemonicsPanel2.Controls.Add(Me.Label5)
        Me.SystemMnemonicsPanel2.Controls.Add(Me.Label2)
        Me.SystemMnemonicsPanel2.Controls.Add(Me.Label6)
        Me.SystemMnemonicsPanel2.Controls.Add(Me.PictureBox2)
        Me.SystemMnemonicsPanel2.Controls.Add(Me.Button3)
        Me.SystemMnemonicsPanel2.Controls.Add(Me.SystemMnemonicsPanel3)
        Me.SystemMnemonicsPanel2.Controls.Add(Me.SystemMnemonicsPanel2Next)
        Me.SystemMnemonicsPanel2.Controls.Add(Me.Button2)
        Me.SystemMnemonicsPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SystemMnemonicsPanel2.Name = "SystemMnemonicsPanel2"
        Me.SystemMnemonicsPanel2.Size = New System.Drawing.Size(572, 290)
        Me.SystemMnemonicsPanel2.TabIndex = 13
        Me.SystemMnemonicsPanel2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(213, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Color"
        '
        'Button1
        '
        Me.Button1.Image = Global.ProjectWizard.My.Resources.Resources.Help
        Me.Button1.Location = New System.Drawing.Point(12, 256)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(322, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Subsystem"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(250, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Separator"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Tier"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(51, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(175, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Enter the description of the tier."
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ProjectWizard.My.Resources.Resources.icon_alert
        Me.PictureBox2.Location = New System.Drawing.Point(3, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(44, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(406, 256)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Back"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'SystemMnemonicsPanel3
        '
        Me.SystemMnemonicsPanel3.AutoScroll = True
        Me.SystemMnemonicsPanel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SystemMnemonicsPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SystemMnemonicsPanel3.Location = New System.Drawing.Point(12, 58)
        Me.SystemMnemonicsPanel3.Name = "SystemMnemonicsPanel3"
        Me.SystemMnemonicsPanel3.Size = New System.Drawing.Size(552, 193)
        Me.SystemMnemonicsPanel3.TabIndex = 10
        '
        'SystemMnemonicsPanel2Next
        '
        Me.SystemMnemonicsPanel2Next.Enabled = False
        Me.SystemMnemonicsPanel2Next.Location = New System.Drawing.Point(487, 256)
        Me.SystemMnemonicsPanel2Next.Name = "SystemMnemonicsPanel2Next"
        Me.SystemMnemonicsPanel2Next.Size = New System.Drawing.Size(75, 23)
        Me.SystemMnemonicsPanel2Next.TabIndex = 8
        Me.SystemMnemonicsPanel2Next.Text = "Next"
        Me.SystemMnemonicsPanel2Next.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(325, 256)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'SystemMnemonicsPanel4
        '
        Me.SystemMnemonicsPanel4.Controls.Add(Me.SampleMnemonic)
        Me.SystemMnemonicsPanel4.Controls.Add(Me.Label12)
        Me.SystemMnemonicsPanel4.Controls.Add(Me.PictureBox3)
        Me.SystemMnemonicsPanel4.Controls.Add(Me.SystemMnemonicsPanel4Back)
        Me.SystemMnemonicsPanel4.Controls.Add(Me.SystemMnemonicsPanel4Finish)
        Me.SystemMnemonicsPanel4.Controls.Add(Me.SystemMnemonicsPanel4Cancel)
        Me.SystemMnemonicsPanel4.Location = New System.Drawing.Point(0, 0)
        Me.SystemMnemonicsPanel4.Name = "SystemMnemonicsPanel4"
        Me.SystemMnemonicsPanel4.Size = New System.Drawing.Size(572, 290)
        Me.SystemMnemonicsPanel4.TabIndex = 14
        Me.SystemMnemonicsPanel4.Visible = False
        '
        'SampleMnemonic
        '
        Me.SampleMnemonic.Controls.Add(Me.TextBox1)
        Me.SampleMnemonic.Location = New System.Drawing.Point(17, 40)
        Me.SampleMnemonic.Name = "SampleMnemonic"
        Me.SampleMnemonic.Size = New System.Drawing.Size(545, 210)
        Me.SampleMnemonic.TabIndex = 25
        Me.SampleMnemonic.TabStop = False
        Me.SampleMnemonic.Text = "Sample Mnemonic"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(24, 139)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(488, 48)
        Me.TextBox1.TabIndex = 26
        Me.TextBox1.Text = "If the above template looks correct, click Finish to go to the next step of the w" & _
            "izard.  If not, press Back to change your selections."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(55, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(204, 15)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Include some basic info on the form."
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.ProjectWizard.My.Resources.Resources.icon_alert
        Me.PictureBox3.Location = New System.Drawing.Point(7, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(44, 29)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 23
        Me.PictureBox3.TabStop = False
        '
        'SystemMnemonicsPanel4Back
        '
        Me.SystemMnemonicsPanel4Back.Location = New System.Drawing.Point(406, 262)
        Me.SystemMnemonicsPanel4Back.Name = "SystemMnemonicsPanel4Back"
        Me.SystemMnemonicsPanel4Back.Size = New System.Drawing.Size(75, 23)
        Me.SystemMnemonicsPanel4Back.TabIndex = 22
        Me.SystemMnemonicsPanel4Back.Text = "Back"
        Me.SystemMnemonicsPanel4Back.UseVisualStyleBackColor = True
        '
        'SystemMnemonicsPanel4Finish
        '
        Me.SystemMnemonicsPanel4Finish.Location = New System.Drawing.Point(487, 262)
        Me.SystemMnemonicsPanel4Finish.Name = "SystemMnemonicsPanel4Finish"
        Me.SystemMnemonicsPanel4Finish.Size = New System.Drawing.Size(75, 23)
        Me.SystemMnemonicsPanel4Finish.TabIndex = 19
        Me.SystemMnemonicsPanel4Finish.Text = "Finish"
        Me.SystemMnemonicsPanel4Finish.UseVisualStyleBackColor = True
        '
        'SystemMnemonicsPanel4Cancel
        '
        Me.SystemMnemonicsPanel4Cancel.Location = New System.Drawing.Point(16, 262)
        Me.SystemMnemonicsPanel4Cancel.Name = "SystemMnemonicsPanel4Cancel"
        Me.SystemMnemonicsPanel4Cancel.Size = New System.Drawing.Size(75, 23)
        Me.SystemMnemonicsPanel4Cancel.TabIndex = 20
        Me.SystemMnemonicsPanel4Cancel.Text = "Cancel"
        Me.SystemMnemonicsPanel4Cancel.UseVisualStyleBackColor = True
        '
        'CreateSystemMnemonics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 291)
        Me.Controls.Add(Me.SystemMnemonicsPanel1)
        Me.Controls.Add(Me.SystemMnemonicsPanel2)
        Me.Controls.Add(Me.SystemMnemonicsPanel4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateSystemMnemonics"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create System Mnemonics"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SystemMnemonicCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SystemMnemonicsPanel1.ResumeLayout(False)
        Me.SystemMnemonicsPanel2.ResumeLayout(False)
        Me.SystemMnemonicsPanel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SystemMnemonicsPanel4.ResumeLayout(False)
        Me.SystemMnemonicsPanel4.PerformLayout()
        Me.SampleMnemonic.ResumeLayout(False)
        Me.SampleMnemonic.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SystemMnemonicCancel As System.Windows.Forms.Button
    Friend WithEvents SystemMnemonicsPanel1 As System.Windows.Forms.Panel
    Friend WithEvents SystemMnemonicNext1 As System.Windows.Forms.Button
    Friend WithEvents SystemMnemonicCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SystemMnemonicsPanel2 As System.Windows.Forms.Panel
    Friend WithEvents SystemMnemonicsPanel2Next As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SystemMnemonicsPanel3 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SystemMnemonicsPanel4 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents SystemMnemonicsPanel4Back As System.Windows.Forms.Button
    Friend WithEvents SystemMnemonicsPanel4Finish As System.Windows.Forms.Button
    Friend WithEvents SystemMnemonicsPanel4Cancel As System.Windows.Forms.Button
    Friend WithEvents SampleMnemonic As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
