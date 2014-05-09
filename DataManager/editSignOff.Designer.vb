<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class editSignOff
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbx_Description = New System.Windows.Forms.TextBox
        Me.cbx_Level = New System.Windows.Forms.ComboBox
        Me.btn_Color = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.lbl_Order = New System.Windows.Forms.Label
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Order"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Level"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(181, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Color"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Description"
        '
        'tbx_Description
        '
        Me.tbx_Description.Location = New System.Drawing.Point(221, 24)
        Me.tbx_Description.Name = "tbx_Description"
        Me.tbx_Description.Size = New System.Drawing.Size(222, 20)
        Me.tbx_Description.TabIndex = 4
        '
        'cbx_Level
        '
        Me.cbx_Level.FormattingEnabled = True
        Me.cbx_Level.Location = New System.Drawing.Point(54, 23)
        Me.cbx_Level.Name = "cbx_Level"
        Me.cbx_Level.Size = New System.Drawing.Size(121, 21)
        Me.cbx_Level.TabIndex = 5
        '
        'btn_Color
        '
        Me.btn_Color.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_Color.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_Color.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Color.Location = New System.Drawing.Point(184, 25)
        Me.btn_Color.Name = "btn_Color"
        Me.btn_Color.Size = New System.Drawing.Size(28, 19)
        Me.btn_Color.TabIndex = 6
        Me.btn_Color.UseVisualStyleBackColor = False
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(359, 64)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 7
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(278, 64)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 8
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'lbl_Order
        '
        Me.lbl_Order.AutoSize = True
        Me.lbl_Order.Location = New System.Drawing.Point(15, 30)
        Me.lbl_Order.Name = "lbl_Order"
        Me.lbl_Order.Size = New System.Drawing.Size(29, 13)
        Me.lbl_Order.TabIndex = 9
        Me.lbl_Order.Text = "NaN"
        '
        'editSignOff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 95)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_Order)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Color)
        Me.Controls.Add(Me.cbx_Level)
        Me.Controls.Add(Me.tbx_Description)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "editSignOff"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Owner Sign-Off Configuration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbx_Description As System.Windows.Forms.TextBox
    Friend WithEvents cbx_Level As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Color As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents lbl_Order As System.Windows.Forms.Label
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
End Class
