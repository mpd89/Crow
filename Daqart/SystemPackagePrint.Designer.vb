<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemPackagePrint
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
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.ckbSummary = New System.Windows.Forms.CheckBox
        Me.ckbForms = New System.Windows.Forms.CheckBox
        Me.ckbDiscripancy = New System.Windows.Forms.CheckBox
        Me.ckbPunchlist = New System.Windows.Forms.CheckBox
        Me.ckbDocuments = New System.Windows.Forms.CheckBox
        Me.ckbAll = New System.Windows.Forms.CheckBox
        Me.ckb_11x17 = New System.Windows.Forms.CheckBox
        Me.lblPackage = New System.Windows.Forms.Label
        Me.radio_ToPDF = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radio_PrintPreview = New System.Windows.Forms.RadioButton
        Me.radio_Print = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ckb_PkgHilite = New System.Windows.Forms.CheckBox
        Me.ckb_PkgMarkeup = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(267, 274)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
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
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'ckbSummary
        '
        Me.ckbSummary.AutoSize = True
        Me.ckbSummary.Location = New System.Drawing.Point(50, 86)
        Me.ckbSummary.Name = "ckbSummary"
        Me.ckbSummary.Size = New System.Drawing.Size(69, 17)
        Me.ckbSummary.TabIndex = 9
        Me.ckbSummary.Text = "Summary"
        Me.ckbSummary.UseVisualStyleBackColor = True
        '
        'ckbForms
        '
        Me.ckbForms.AutoSize = True
        Me.ckbForms.Location = New System.Drawing.Point(50, 109)
        Me.ckbForms.Name = "ckbForms"
        Me.ckbForms.Size = New System.Drawing.Size(54, 17)
        Me.ckbForms.TabIndex = 10
        Me.ckbForms.Text = "Forms"
        Me.ckbForms.UseVisualStyleBackColor = True
        '
        'ckbDiscripancy
        '
        Me.ckbDiscripancy.AutoSize = True
        Me.ckbDiscripancy.Location = New System.Drawing.Point(50, 132)
        Me.ckbDiscripancy.Name = "ckbDiscripancy"
        Me.ckbDiscripancy.Size = New System.Drawing.Size(81, 17)
        Me.ckbDiscripancy.TabIndex = 11
        Me.ckbDiscripancy.Text = "Discripancy"
        Me.ckbDiscripancy.UseVisualStyleBackColor = True
        '
        'ckbPunchlist
        '
        Me.ckbPunchlist.AutoSize = True
        Me.ckbPunchlist.Location = New System.Drawing.Point(50, 155)
        Me.ckbPunchlist.Name = "ckbPunchlist"
        Me.ckbPunchlist.Size = New System.Drawing.Size(69, 17)
        Me.ckbPunchlist.TabIndex = 12
        Me.ckbPunchlist.Text = "Punchlist"
        Me.ckbPunchlist.UseVisualStyleBackColor = True
        '
        'ckbDocuments
        '
        Me.ckbDocuments.AutoSize = True
        Me.ckbDocuments.Location = New System.Drawing.Point(50, 178)
        Me.ckbDocuments.Name = "ckbDocuments"
        Me.ckbDocuments.Size = New System.Drawing.Size(80, 17)
        Me.ckbDocuments.TabIndex = 13
        Me.ckbDocuments.Text = "Documents"
        Me.ckbDocuments.UseVisualStyleBackColor = True
        '
        'ckbAll
        '
        Me.ckbAll.AutoSize = True
        Me.ckbAll.Location = New System.Drawing.Point(50, 203)
        Me.ckbAll.Name = "ckbAll"
        Me.ckbAll.Size = New System.Drawing.Size(37, 17)
        Me.ckbAll.TabIndex = 14
        Me.ckbAll.Text = "All"
        Me.ckbAll.UseVisualStyleBackColor = True
        '
        'ckb_11x17
        '
        Me.ckb_11x17.AutoSize = True
        Me.ckb_11x17.Location = New System.Drawing.Point(136, 178)
        Me.ckb_11x17.Name = "ckb_11x17"
        Me.ckb_11x17.Size = New System.Drawing.Size(107, 17)
        Me.ckb_11x17.TabIndex = 18
        Me.ckb_11x17.Text = "Use 11x17 paper"
        Me.ckb_11x17.UseVisualStyleBackColor = True
        '
        'lblPackage
        '
        Me.lblPackage.AutoSize = True
        Me.lblPackage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackage.Location = New System.Drawing.Point(45, 26)
        Me.lblPackage.Name = "lblPackage"
        Me.lblPackage.Size = New System.Drawing.Size(77, 25)
        Me.lblPackage.TabIndex = 22
        Me.lblPackage.Text = "Label1"
        '
        'radio_ToPDF
        '
        Me.radio_ToPDF.AutoSize = True
        Me.radio_ToPDF.Location = New System.Drawing.Point(11, 68)
        Me.radio_ToPDF.Name = "radio_ToPDF"
        Me.radio_ToPDF.Size = New System.Drawing.Size(82, 17)
        Me.radio_ToPDF.TabIndex = 2
        Me.radio_ToPDF.TabStop = True
        Me.radio_ToPDF.Text = "Print to PDF"
        Me.radio_ToPDF.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radio_PrintPreview)
        Me.GroupBox1.Controls.Add(Me.radio_ToPDF)
        Me.GroupBox1.Controls.Add(Me.radio_Print)
        Me.GroupBox1.Location = New System.Drawing.Point(283, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(127, 106)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        '
        'radio_PrintPreview
        '
        Me.radio_PrintPreview.AutoSize = True
        Me.radio_PrintPreview.Checked = True
        Me.radio_PrintPreview.Location = New System.Drawing.Point(11, 45)
        Me.radio_PrintPreview.Name = "radio_PrintPreview"
        Me.radio_PrintPreview.Size = New System.Drawing.Size(87, 17)
        Me.radio_PrintPreview.TabIndex = 3
        Me.radio_PrintPreview.TabStop = True
        Me.radio_PrintPreview.Text = "Print Preview"
        Me.radio_PrintPreview.UseVisualStyleBackColor = True
        '
        'radio_Print
        '
        Me.radio_Print.AutoSize = True
        Me.radio_Print.Checked = True
        Me.radio_Print.Location = New System.Drawing.Point(11, 22)
        Me.radio_Print.Name = "radio_Print"
        Me.radio_Print.Size = New System.Drawing.Size(46, 17)
        Me.radio_Print.TabIndex = 0
        Me.radio_Print.TabStop = True
        Me.radio_Print.Text = "Print"
        Me.radio_Print.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ckb_PkgHilite)
        Me.GroupBox2.Controls.Add(Me.ckb_PkgMarkeup)
        Me.GroupBox2.Location = New System.Drawing.Point(283, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(125, 65)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Include"
        '
        'ckb_PkgHilite
        '
        Me.ckb_PkgHilite.AutoSize = True
        Me.ckb_PkgHilite.Location = New System.Drawing.Point(7, 44)
        Me.ckb_PkgHilite.Name = "ckb_PkgHilite"
        Me.ckb_PkgHilite.Size = New System.Drawing.Size(100, 17)
        Me.ckb_PkgHilite.TabIndex = 1
        Me.ckb_PkgHilite.Text = "Pkg Hilite Layer"
        Me.ckb_PkgHilite.UseVisualStyleBackColor = True
        '
        'ckb_PkgMarkeup
        '
        Me.ckb_PkgMarkeup.AutoSize = True
        Me.ckb_PkgMarkeup.Checked = True
        Me.ckb_PkgMarkeup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckb_PkgMarkeup.Location = New System.Drawing.Point(7, 21)
        Me.ckb_PkgMarkeup.Name = "ckb_PkgMarkeup"
        Me.ckb_PkgMarkeup.Size = New System.Drawing.Size(113, 17)
        Me.ckb_PkgMarkeup.TabIndex = 0
        Me.ckb_PkgMarkeup.Text = "Pkg Markup Layer"
        Me.ckb_PkgMarkeup.UseVisualStyleBackColor = True
        '
        'SystemPackagePrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(468, 315)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblPackage)
        Me.Controls.Add(Me.ckb_11x17)
        Me.Controls.Add(Me.ckbAll)
        Me.Controls.Add(Me.ckbDocuments)
        Me.Controls.Add(Me.ckbPunchlist)
        Me.Controls.Add(Me.ckbDiscripancy)
        Me.Controls.Add(Me.ckbForms)
        Me.Controls.Add(Me.ckbSummary)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SystemPackagePrint"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SystemPackagePrint"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ckbSummary As System.Windows.Forms.CheckBox
    Friend WithEvents ckbForms As System.Windows.Forms.CheckBox
    Friend WithEvents ckbDiscripancy As System.Windows.Forms.CheckBox
    Friend WithEvents ckbPunchlist As System.Windows.Forms.CheckBox
    Friend WithEvents ckbDocuments As System.Windows.Forms.CheckBox
    Friend WithEvents ckbAll As System.Windows.Forms.CheckBox
    Friend WithEvents ckb_11x17 As System.Windows.Forms.CheckBox
    Friend WithEvents lblPackage As System.Windows.Forms.Label
    Friend WithEvents radio_ToPDF As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radio_Print As System.Windows.Forms.RadioButton
    Friend WithEvents radio_PrintPreview As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ckb_PkgHilite As System.Windows.Forms.CheckBox
    Friend WithEvents ckb_PkgMarkeup As System.Windows.Forms.CheckBox

End Class
