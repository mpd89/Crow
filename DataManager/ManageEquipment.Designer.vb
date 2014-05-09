<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageEquipment
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
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.EqActive = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.EqDesc = New System.Windows.Forms.TextBox
        Me.EqCode = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.EqActive)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.EqDesc)
        Me.TabPage1.Controls.Add(Me.EqCode)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(339, 246)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(249, 202)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(168, 202)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'EqActive
        '
        Me.EqActive.AutoSize = True
        Me.EqActive.Location = New System.Drawing.Point(130, 157)
        Me.EqActive.Name = "EqActive"
        Me.EqActive.Size = New System.Drawing.Size(56, 17)
        Me.EqActive.TabIndex = 4
        Me.EqActive.Text = "Active"
        Me.EqActive.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Description"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Equipment Code"
        '
        'EqDesc
        '
        Me.EqDesc.Location = New System.Drawing.Point(130, 62)
        Me.EqDesc.Multiline = True
        Me.EqDesc.Name = "EqDesc"
        Me.EqDesc.Size = New System.Drawing.Size(183, 79)
        Me.EqDesc.TabIndex = 1
        '
        'EqCode
        '
        Me.EqCode.Location = New System.Drawing.Point(130, 20)
        Me.EqCode.Name = "EqCode"
        Me.EqCode.Size = New System.Drawing.Size(100, 20)
        Me.EqCode.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(347, 272)
        Me.TabControl1.TabIndex = 0
        '
        'ManageEquipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 296)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ManageEquipment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Manage Equipment Types"
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EqDesc As System.Windows.Forms.TextBox
    Friend WithEvents EqCode As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents EqActive As System.Windows.Forms.CheckBox
End Class
