<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DaqumentAddNewLayer
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rb_Redline = New System.Windows.Forms.RadioButton
        Me.rb_Hilite = New System.Windows.Forms.RadioButton
        Me.ckb_ApplyToPkg = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 274)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(208, 151)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(100, 20)
        Me.txtTitle.TabIndex = 1
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(208, 178)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(160, 20)
        Me.txtDesc.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Title"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Description"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(38, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(247, 26)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Add New Drawing Layer"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rb_Redline)
        Me.GroupBox1.Controls.Add(Me.rb_Hilite)
        Me.GroupBox1.Location = New System.Drawing.Point(170, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(157, 63)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'rb_Redline
        '
        Me.rb_Redline.AutoSize = True
        Me.rb_Redline.Location = New System.Drawing.Point(38, 35)
        Me.rb_Redline.Name = "rb_Redline"
        Me.rb_Redline.Size = New System.Drawing.Size(90, 17)
        Me.rb_Redline.TabIndex = 1
        Me.rb_Redline.TabStop = True
        Me.rb_Redline.Text = "Redline Layer"
        Me.rb_Redline.UseVisualStyleBackColor = True
        '
        'rb_Hilite
        '
        Me.rb_Hilite.AutoSize = True
        Me.rb_Hilite.Location = New System.Drawing.Point(38, 11)
        Me.rb_Hilite.Name = "rb_Hilite"
        Me.rb_Hilite.Size = New System.Drawing.Size(77, 17)
        Me.rb_Hilite.TabIndex = 0
        Me.rb_Hilite.TabStop = True
        Me.rb_Hilite.Text = "Hilite Layer"
        Me.rb_Hilite.UseVisualStyleBackColor = True
        '
        'ckb_ApplyToPkg
        '
        Me.ckb_ApplyToPkg.AutoSize = True
        Me.ckb_ApplyToPkg.Location = New System.Drawing.Point(208, 59)
        Me.ckb_ApplyToPkg.Name = "ckb_ApplyToPkg"
        Me.ckb_ApplyToPkg.Size = New System.Drawing.Size(110, 17)
        Me.ckb_ApplyToPkg.TabIndex = 15
        Me.ckb_ApplyToPkg.Text = "Apply to Package"
        Me.ckb_ApplyToPkg.UseVisualStyleBackColor = True
        '
        'DaqumentAddNewLayer
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 315)
        Me.Controls.Add(Me.ckb_ApplyToPkg)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DaqumentAddNewLayer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DaqumentAddNewLayer"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_Redline As System.Windows.Forms.RadioButton
    Friend WithEvents rb_Hilite As System.Windows.Forms.RadioButton
    Friend WithEvents ckb_ApplyToPkg As System.Windows.Forms.CheckBox

End Class
