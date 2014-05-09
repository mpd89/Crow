<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageRequirements
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.tbx_ManHours = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.FormBox = New System.Windows.Forms.ComboBox
        Me.EquipmentBox = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.OwnerBox = New System.Windows.Forms.ComboBox
        Me.lbl_ElementMH1 = New System.Windows.Forms.Label
        Me.lbl_ElementMH2 = New System.Windows.Forms.Label
        Me.tbx_ElementMH = New System.Windows.Forms.TextBox
        Me.lbl_ElementMH3 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(333, 286)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tbx_ElementMH)
        Me.TabPage1.Controls.Add(Me.lbl_ElementMH3)
        Me.TabPage1.Controls.Add(Me.lbl_ElementMH2)
        Me.TabPage1.Controls.Add(Me.lbl_ElementMH1)
        Me.TabPage1.Controls.Add(Me.tbx_ManHours)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.FormBox)
        Me.TabPage1.Controls.Add(Me.EquipmentBox)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.OwnerBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(325, 260)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tbx_ManHours
        '
        Me.tbx_ManHours.Location = New System.Drawing.Point(109, 112)
        Me.tbx_ManHours.Name = "tbx_ManHours"
        Me.tbx_ManHours.Size = New System.Drawing.Size(94, 20)
        Me.tbx_ManHours.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Form Man Hours"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Form Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Equipment Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Owner"
        '
        'FormBox
        '
        Me.FormBox.FormattingEnabled = True
        Me.FormBox.Location = New System.Drawing.Point(109, 85)
        Me.FormBox.Name = "FormBox"
        Me.FormBox.Size = New System.Drawing.Size(202, 21)
        Me.FormBox.TabIndex = 5
        '
        'EquipmentBox
        '
        Me.EquipmentBox.FormattingEnabled = True
        Me.EquipmentBox.Location = New System.Drawing.Point(109, 58)
        Me.EquipmentBox.Name = "EquipmentBox"
        Me.EquipmentBox.Size = New System.Drawing.Size(202, 21)
        Me.EquipmentBox.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(155, 220)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(236, 220)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OwnerBox
        '
        Me.OwnerBox.FormattingEnabled = True
        Me.OwnerBox.Location = New System.Drawing.Point(109, 31)
        Me.OwnerBox.Name = "OwnerBox"
        Me.OwnerBox.Size = New System.Drawing.Size(202, 21)
        Me.OwnerBox.TabIndex = 0
        '
        'lbl_ElementMH1
        '
        Me.lbl_ElementMH1.AutoSize = True
        Me.lbl_ElementMH1.Location = New System.Drawing.Point(21, 147)
        Me.lbl_ElementMH1.Name = "lbl_ElementMH1"
        Me.lbl_ElementMH1.Size = New System.Drawing.Size(202, 13)
        Me.lbl_ElementMH1.TabIndex = 11
        Me.lbl_ElementMH1.Text = "* You have selected a multi-element form."
        Me.lbl_ElementMH1.Visible = False
        '
        'lbl_ElementMH2
        '
        Me.lbl_ElementMH2.AutoSize = True
        Me.lbl_ElementMH2.Location = New System.Drawing.Point(27, 160)
        Me.lbl_ElementMH2.Name = "lbl_ElementMH2"
        Me.lbl_ElementMH2.Size = New System.Drawing.Size(207, 13)
        Me.lbl_ElementMH2.TabIndex = 12
        Me.lbl_ElementMH2.Text = "Please enter a value for each tag element."
        Me.lbl_ElementMH2.Visible = False
        '
        'tbx_ElementMH
        '
        Me.tbx_ElementMH.Location = New System.Drawing.Point(109, 182)
        Me.tbx_ElementMH.Name = "tbx_ElementMH"
        Me.tbx_ElementMH.Size = New System.Drawing.Size(94, 20)
        Me.tbx_ElementMH.TabIndex = 14
        Me.tbx_ElementMH.Visible = False
        '
        'lbl_ElementMH3
        '
        Me.lbl_ElementMH3.AutoSize = True
        Me.lbl_ElementMH3.Location = New System.Drawing.Point(18, 189)
        Me.lbl_ElementMH3.Name = "lbl_ElementMH3"
        Me.lbl_ElementMH3.Size = New System.Drawing.Size(76, 13)
        Me.lbl_ElementMH3.TabIndex = 13
        Me.lbl_ElementMH3.Text = "Element Hours"
        Me.lbl_ElementMH3.Visible = False
        '
        'ManageRequirements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 286)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ManageRequirements"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Requirements"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents FormBox As System.Windows.Forms.ComboBox
    Friend WithEvents EquipmentBox As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OwnerBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbx_ManHours As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_ElementMH2 As System.Windows.Forms.Label
    Friend WithEvents lbl_ElementMH1 As System.Windows.Forms.Label
    Friend WithEvents tbx_ElementMH As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ElementMH3 As System.Windows.Forms.Label
End Class
