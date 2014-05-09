<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pkgAuxTemplate
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
        Me.btnNext = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.MoveAllRight = New System.Windows.Forms.Button
        Me.MoveLeft = New System.Windows.Forms.Button
        Me.MoveAllLeft = New System.Windows.Forms.Button
        Me.MoveRight = New System.Windows.Forms.Button
        Me.lblCustomName = New System.Windows.Forms.Label
        Me.lvwImportFields = New System.Windows.Forms.ListBox
        Me.lvwCSVFile = New System.Windows.Forms.ListBox
        Me.lblImportFields = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.tbxTemplateName = New System.Windows.Forms.TextBox
        Me.tbxTemplateType = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnBack = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnNext.Location = New System.Drawing.Point(253, 260)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(67, 23)
        Me.btnNext.TabIndex = 0
        Me.btnNext.Text = "Next"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(326, 260)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'MoveAllRight
        '
        Me.MoveAllRight.Location = New System.Drawing.Point(181, 68)
        Me.MoveAllRight.Name = "MoveAllRight"
        Me.MoveAllRight.Size = New System.Drawing.Size(28, 19)
        Me.MoveAllRight.TabIndex = 167
        Me.MoveAllRight.Text = ">>"
        Me.MoveAllRight.UseVisualStyleBackColor = True
        '
        'MoveLeft
        '
        Me.MoveLeft.Location = New System.Drawing.Point(181, 104)
        Me.MoveLeft.Name = "MoveLeft"
        Me.MoveLeft.Size = New System.Drawing.Size(28, 19)
        Me.MoveLeft.TabIndex = 166
        Me.MoveLeft.Text = "<"
        Me.MoveLeft.UseVisualStyleBackColor = True
        '
        'MoveAllLeft
        '
        Me.MoveAllLeft.Location = New System.Drawing.Point(181, 142)
        Me.MoveAllLeft.Name = "MoveAllLeft"
        Me.MoveAllLeft.Size = New System.Drawing.Size(28, 19)
        Me.MoveAllLeft.TabIndex = 165
        Me.MoveAllLeft.Text = "<<"
        Me.MoveAllLeft.UseVisualStyleBackColor = True
        '
        'MoveRight
        '
        Me.MoveRight.Location = New System.Drawing.Point(181, 34)
        Me.MoveRight.Name = "MoveRight"
        Me.MoveRight.Size = New System.Drawing.Size(28, 19)
        Me.MoveRight.TabIndex = 164
        Me.MoveRight.Text = ">"
        Me.MoveRight.UseVisualStyleBackColor = True
        '
        'lblCustomName
        '
        Me.lblCustomName.AutoSize = True
        Me.lblCustomName.Location = New System.Drawing.Point(228, 111)
        Me.lblCustomName.Name = "lblCustomName"
        Me.lblCustomName.Size = New System.Drawing.Size(79, 13)
        Me.lblCustomName.TabIndex = 163
        Me.lblCustomName.Text = "Selected Fields"
        '
        'lvwImportFields
        '
        Me.lvwImportFields.FormattingEnabled = True
        Me.lvwImportFields.Location = New System.Drawing.Point(224, 5)
        Me.lvwImportFields.Name = "lvwImportFields"
        Me.lvwImportFields.Size = New System.Drawing.Size(120, 212)
        Me.lvwImportFields.TabIndex = 162
        '
        'lvwCSVFile
        '
        Me.lvwCSVFile.FormattingEnabled = True
        Me.lvwCSVFile.Location = New System.Drawing.Point(45, 5)
        Me.lvwCSVFile.Name = "lvwCSVFile"
        Me.lvwCSVFile.Size = New System.Drawing.Size(120, 212)
        Me.lvwCSVFile.TabIndex = 161
        '
        'lblImportFields
        '
        Me.lblImportFields.AutoSize = True
        Me.lblImportFields.Location = New System.Drawing.Point(59, 111)
        Me.lblImportFields.Name = "lblImportFields"
        Me.lblImportFields.Size = New System.Drawing.Size(106, 13)
        Me.lblImportFields.TabIndex = 160
        Me.lblImportFields.Text = "Fields in the CSV File"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(41, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(266, 20)
        Me.Label15.TabIndex = 168
        Me.Label15.Text = "Create Auxiliary Fields Template"
        '
        'tbxTemplateName
        '
        Me.tbxTemplateName.Location = New System.Drawing.Point(126, 38)
        Me.tbxTemplateName.Name = "tbxTemplateName"
        Me.tbxTemplateName.Size = New System.Drawing.Size(151, 20)
        Me.tbxTemplateName.TabIndex = 169
        '
        'tbxTemplateType
        '
        Me.tbxTemplateType.Location = New System.Drawing.Point(126, 72)
        Me.tbxTemplateType.Name = "tbxTemplateType"
        Me.tbxTemplateType.Size = New System.Drawing.Size(151, 20)
        Me.tbxTemplateType.TabIndex = 170
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "Template Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 172
        Me.Label2.Text = "Template Type"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblImportFields)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCustomName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbxTemplateName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbxTemplateType)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Cancel_Button)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnNext)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnBack)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MoveLeft)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvwCSVFile)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvwImportFields)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MoveAllRight)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MoveRight)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MoveAllLeft)
        Me.SplitContainer1.Size = New System.Drawing.Size(405, 445)
        Me.SplitContainer1.SplitterDistance = 130
        Me.SplitContainer1.TabIndex = 173
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(170, 259)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 178
        Me.btnBack.Text = "<< Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'pkgAuxTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 445)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "pkgAuxTemplate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "pkgAuxTemplate"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents MoveAllRight As System.Windows.Forms.Button
    Friend WithEvents MoveLeft As System.Windows.Forms.Button
    Friend WithEvents MoveAllLeft As System.Windows.Forms.Button
    Friend WithEvents MoveRight As System.Windows.Forms.Button
    Friend WithEvents lblCustomName As System.Windows.Forms.Label
    Friend WithEvents lvwImportFields As System.Windows.Forms.ListBox
    Friend WithEvents lvwCSVFile As System.Windows.Forms.ListBox
    Friend WithEvents lblImportFields As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbxTemplateName As System.Windows.Forms.TextBox
    Friend WithEvents tbxTemplateType As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnBack As System.Windows.Forms.Button

End Class
