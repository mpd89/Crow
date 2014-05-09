<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAuxTemplate
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
        Me.lvwPkgTemplateList = New System.Windows.Forms.ListBox
        Me.lvwTagTemplateList = New System.Windows.Forms.ListBox
        Me.tbxPkgTemplateName = New System.Windows.Forms.TextBox
        Me.tbxTagTemplateName = New System.Windows.Forms.TextBox
        Me.lblImportFields = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblCustomName = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 355)
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
        'lvwPkgTemplateList
        '
        Me.lvwPkgTemplateList.FormattingEnabled = True
        Me.lvwPkgTemplateList.Location = New System.Drawing.Point(48, 126)
        Me.lvwPkgTemplateList.Name = "lvwPkgTemplateList"
        Me.lvwPkgTemplateList.Size = New System.Drawing.Size(120, 212)
        Me.lvwPkgTemplateList.TabIndex = 168
        '
        'lvwTagTemplateList
        '
        Me.lvwTagTemplateList.FormattingEnabled = True
        Me.lvwTagTemplateList.Location = New System.Drawing.Point(227, 126)
        Me.lvwTagTemplateList.Name = "lvwTagTemplateList"
        Me.lvwTagTemplateList.Size = New System.Drawing.Size(120, 212)
        Me.lvwTagTemplateList.TabIndex = 169
        '
        'tbxPkgTemplateName
        '
        Me.tbxPkgTemplateName.Enabled = False
        Me.tbxPkgTemplateName.Location = New System.Drawing.Point(48, 64)
        Me.tbxPkgTemplateName.Name = "tbxPkgTemplateName"
        Me.tbxPkgTemplateName.Size = New System.Drawing.Size(120, 20)
        Me.tbxPkgTemplateName.TabIndex = 170
        '
        'tbxTagTemplateName
        '
        Me.tbxTagTemplateName.Enabled = False
        Me.tbxTagTemplateName.Location = New System.Drawing.Point(227, 64)
        Me.tbxTagTemplateName.Name = "tbxTagTemplateName"
        Me.tbxTagTemplateName.Size = New System.Drawing.Size(120, 20)
        Me.tbxTagTemplateName.TabIndex = 171
        '
        'lblImportFields
        '
        Me.lblImportFields.AutoSize = True
        Me.lblImportFields.Location = New System.Drawing.Point(45, 48)
        Me.lblImportFields.Name = "lblImportFields"
        Me.lblImportFields.Size = New System.Drawing.Size(142, 13)
        Me.lblImportFields.TabIndex = 172
        Me.lblImportFields.Text = "Selected Package Template"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(224, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "Selected Tag Template"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "Package Template List"
        '
        'lblCustomName
        '
        Me.lblCustomName.AutoSize = True
        Me.lblCustomName.Location = New System.Drawing.Point(224, 110)
        Me.lblCustomName.Name = "lblCustomName"
        Me.lblCustomName.Size = New System.Drawing.Size(92, 13)
        Me.lblCustomName.TabIndex = 175
        Me.lblCustomName.Text = "Tag Template List"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(102, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(198, 20)
        Me.Label15.TabIndex = 176
        Me.Label15.Text = "Auxiliary Data Template"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(19, 358)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 13)
        Me.Label3.TabIndex = 177
        Me.Label3.Text = "* Double click list item to select template"
        '
        'FormAuxTemplate
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 396)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblCustomName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblImportFields)
        Me.Controls.Add(Me.tbxTagTemplateName)
        Me.Controls.Add(Me.tbxPkgTemplateName)
        Me.Controls.Add(Me.lvwTagTemplateList)
        Me.Controls.Add(Me.lvwPkgTemplateList)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAuxTemplate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormAuxTemplate"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lvwPkgTemplateList As System.Windows.Forms.ListBox
    Friend WithEvents lvwTagTemplateList As System.Windows.Forms.ListBox
    Friend WithEvents tbxPkgTemplateName As System.Windows.Forms.TextBox
    Friend WithEvents tbxTagTemplateName As System.Windows.Forms.TextBox
    Friend WithEvents lblImportFields As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCustomName As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
