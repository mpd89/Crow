<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAssociations
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
        Me.components = New System.ComponentModel.Container
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lbx_References = New System.Windows.Forms.ListBox
        Me.cms_Reference = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteReferenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_Add = New System.Windows.Forms.Button
        Me.tbx_Notes = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbx_Tags = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbx_Package = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_Export = New System.Windows.Forms.ToolStripButton
        Me.ipw_Image = New Daqument.ImagePreview
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.cms_Reference.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbx_References)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ipw_Image)
        Me.SplitContainer1.Size = New System.Drawing.Size(743, 582)
        Me.SplitContainer1.SplitterDistance = 247
        Me.SplitContainer1.TabIndex = 0
        '
        'lbx_References
        '
        Me.lbx_References.ContextMenuStrip = Me.cms_Reference
        Me.lbx_References.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbx_References.FormattingEnabled = True
        Me.lbx_References.Location = New System.Drawing.Point(0, 225)
        Me.lbx_References.Name = "lbx_References"
        Me.lbx_References.Size = New System.Drawing.Size(247, 355)
        Me.lbx_References.TabIndex = 1
        '
        'cms_Reference
        '
        Me.cms_Reference.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteReferenceToolStripMenuItem})
        Me.cms_Reference.Name = "cms_Reference"
        Me.cms_Reference.Size = New System.Drawing.Size(163, 48)
        '
        'DeleteReferenceToolStripMenuItem
        '
        Me.DeleteReferenceToolStripMenuItem.Name = "DeleteReferenceToolStripMenuItem"
        Me.DeleteReferenceToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.DeleteReferenceToolStripMenuItem.Text = "Delete Reference"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_Add)
        Me.Panel1.Controls.Add(Me.tbx_Notes)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbx_Tags)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.tbx_Package)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(247, 200)
        Me.Panel1.TabIndex = 2
        '
        'btn_Add
        '
        Me.btn_Add.Enabled = False
        Me.btn_Add.Location = New System.Drawing.Point(81, 163)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(75, 23)
        Me.btn_Add.TabIndex = 6
        Me.btn_Add.Text = "Add"
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'tbx_Notes
        '
        Me.tbx_Notes.Location = New System.Drawing.Point(63, 70)
        Me.tbx_Notes.Multiline = True
        Me.tbx_Notes.Name = "tbx_Notes"
        Me.tbx_Notes.Size = New System.Drawing.Size(172, 80)
        Me.tbx_Notes.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Notes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tag"
        '
        'cbx_Tags
        '
        Me.cbx_Tags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Tags.FormattingEnabled = True
        Me.cbx_Tags.Location = New System.Drawing.Point(63, 43)
        Me.cbx_Tags.Name = "cbx_Tags"
        Me.cbx_Tags.Size = New System.Drawing.Size(172, 21)
        Me.cbx_Tags.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Package"
        '
        'tbx_Package
        '
        Me.tbx_Package.Location = New System.Drawing.Point(63, 16)
        Me.tbx_Package.Name = "tbx_Package"
        Me.tbx_Package.Size = New System.Drawing.Size(172, 20)
        Me.tbx_Package.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Export})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(247, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_Export
        '
        Me.btn_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Export.Image = Global.Daqument.My.Resources.Resources.Save_As
        Me.btn_Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Export.Name = "btn_Export"
        Me.btn_Export.Size = New System.Drawing.Size(23, 22)
        Me.btn_Export.Text = "Export List"
        '
        'ipw_Image
        '
        Me.ipw_Image.AutoScroll = True
        Me.ipw_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ipw_Image.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ipw_Image.Location = New System.Drawing.Point(0, 0)
        Me.ipw_Image.Name = "ipw_Image"
        Me.ipw_Image.Size = New System.Drawing.Size(492, 582)
        Me.ipw_Image.TabIndex = 0
        '
        'ViewAssociations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 582)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ViewAssociations"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Package Associations"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.cms_Reference.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ipw_Image As Daqument.ImagePreview
    Friend WithEvents lbx_References As System.Windows.Forms.ListBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_Export As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbx_Tags As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbx_Package As System.Windows.Forms.TextBox
    Friend WithEvents btn_Add As System.Windows.Forms.Button
    Friend WithEvents tbx_Notes As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cms_Reference As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteReferenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
