<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class editSystemNumber
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
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.SystemIdentifier = New System.Windows.Forms.TextBox
        Me.SystemDescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbx_ProjectNumber = New System.Windows.Forms.ComboBox
        Me.cbx_Contractor = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbx_Location = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbx_Discipline = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbx_Parent = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Enabled = False
        Me.OK_Button.Location = New System.Drawing.Point(337, 301)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(264, 301)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'SystemIdentifier
        '
        Me.SystemIdentifier.Location = New System.Drawing.Point(100, 37)
        Me.SystemIdentifier.MaxLength = 50
        Me.SystemIdentifier.Name = "SystemIdentifier"
        Me.SystemIdentifier.Size = New System.Drawing.Size(304, 20)
        Me.SystemIdentifier.TabIndex = 1
        '
        'SystemDescription
        '
        Me.SystemDescription.Location = New System.Drawing.Point(100, 63)
        Me.SystemDescription.MaxLength = 100
        Me.SystemDescription.Multiline = True
        Me.SystemDescription.Name = "SystemDescription"
        Me.SystemDescription.Size = New System.Drawing.Size(304, 86)
        Me.SystemDescription.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Turnover Number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Project #"
        '
        'cbx_ProjectNumber
        '
        Me.cbx_ProjectNumber.FormattingEnabled = True
        Me.cbx_ProjectNumber.Location = New System.Drawing.Point(100, 189)
        Me.cbx_ProjectNumber.Name = "cbx_ProjectNumber"
        Me.cbx_ProjectNumber.Size = New System.Drawing.Size(304, 21)
        Me.cbx_ProjectNumber.TabIndex = 7
        '
        'cbx_Contractor
        '
        Me.cbx_Contractor.FormattingEnabled = True
        Me.cbx_Contractor.Location = New System.Drawing.Point(100, 216)
        Me.cbx_Contractor.Name = "cbx_Contractor"
        Me.cbx_Contractor.Size = New System.Drawing.Size(304, 21)
        Me.cbx_Contractor.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Contractor"
        '
        'cbx_Location
        '
        Me.cbx_Location.FormattingEnabled = True
        Me.cbx_Location.Location = New System.Drawing.Point(100, 243)
        Me.cbx_Location.Name = "cbx_Location"
        Me.cbx_Location.Size = New System.Drawing.Size(304, 21)
        Me.cbx_Location.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(46, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Location"
        '
        'cbx_Discipline
        '
        Me.cbx_Discipline.FormattingEnabled = True
        Me.cbx_Discipline.Location = New System.Drawing.Point(100, 270)
        Me.cbx_Discipline.Name = "cbx_Discipline"
        Me.cbx_Discipline.Size = New System.Drawing.Size(304, 21)
        Me.cbx_Discipline.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Discipline"
        '
        'cbx_Parent
        '
        Me.cbx_Parent.Enabled = False
        Me.cbx_Parent.FormattingEnabled = True
        Me.cbx_Parent.Location = New System.Drawing.Point(100, 162)
        Me.cbx_Parent.Name = "cbx_Parent"
        Me.cbx_Parent.Size = New System.Drawing.Size(304, 21)
        Me.cbx_Parent.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Parent #"
        '
        'editSystemNumber
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(427, 336)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbx_Parent)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.cbx_Discipline)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbx_Location)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbx_Contractor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbx_ProjectNumber)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SystemDescription)
        Me.Controls.Add(Me.SystemIdentifier)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "editSystemNumber"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Turnover Number"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents SystemIdentifier As System.Windows.Forms.TextBox
    Friend WithEvents SystemDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbx_ProjectNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Contractor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbx_Location As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbx_Discipline As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbx_Parent As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
