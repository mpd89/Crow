<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPackageDocument
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
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_OK = New System.Windows.Forms.Button
        Me.lbx_DocumentList = New System.Windows.Forms.ListBox
        Me.cbx_DocumentCategory = New System.Windows.Forms.ComboBox
        Me.cbx_TagList = New System.Windows.Forms.ComboBox
        Me.lbl_TagReference = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbn_Both = New System.Windows.Forms.RadioButton
        Me.rbn_Client = New System.Windows.Forms.RadioButton
        Me.rbn_Engineering = New System.Windows.Forms.RadioButton
        Me.tbx_Notes = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbx_References = New System.Windows.Forms.ListBox
        Me.btn_RemoveFromList = New System.Windows.Forms.Button
        Me.btn_AddToList = New System.Windows.Forms.Button
        Me.tbx_documentType = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(403, 421)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 0
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(484, 421)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 1
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'lbx_DocumentList
        '
        Me.lbx_DocumentList.FormattingEnabled = True
        Me.lbx_DocumentList.Location = New System.Drawing.Point(16, 55)
        Me.lbx_DocumentList.Name = "lbx_DocumentList"
        Me.lbx_DocumentList.Size = New System.Drawing.Size(255, 251)
        Me.lbx_DocumentList.TabIndex = 2
        '
        'cbx_DocumentCategory
        '
        Me.cbx_DocumentCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_DocumentCategory.FormattingEnabled = True
        Me.cbx_DocumentCategory.Location = New System.Drawing.Point(19, 412)
        Me.cbx_DocumentCategory.Name = "cbx_DocumentCategory"
        Me.cbx_DocumentCategory.Size = New System.Drawing.Size(252, 21)
        Me.cbx_DocumentCategory.TabIndex = 3
        Me.cbx_DocumentCategory.Visible = False
        '
        'cbx_TagList
        '
        Me.cbx_TagList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_TagList.FormattingEnabled = True
        Me.cbx_TagList.Location = New System.Drawing.Point(337, 28)
        Me.cbx_TagList.Name = "cbx_TagList"
        Me.cbx_TagList.Size = New System.Drawing.Size(222, 21)
        Me.cbx_TagList.TabIndex = 4
        '
        'lbl_TagReference
        '
        Me.lbl_TagReference.AutoSize = True
        Me.lbl_TagReference.Location = New System.Drawing.Point(334, 12)
        Me.lbl_TagReference.Name = "lbl_TagReference"
        Me.lbl_TagReference.Size = New System.Drawing.Size(79, 13)
        Me.lbl_TagReference.TabIndex = 5
        Me.lbl_TagReference.Text = "Tag Reference"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Document Category"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbn_Both)
        Me.GroupBox1.Controls.Add(Me.rbn_Client)
        Me.GroupBox1.Controls.Add(Me.rbn_Engineering)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 321)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(98, 85)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Document No."
        Me.GroupBox1.Visible = False
        '
        'rbn_Both
        '
        Me.rbn_Both.AutoSize = True
        Me.rbn_Both.Enabled = False
        Me.rbn_Both.Location = New System.Drawing.Point(6, 65)
        Me.rbn_Both.Name = "rbn_Both"
        Me.rbn_Both.Size = New System.Drawing.Size(47, 17)
        Me.rbn_Both.TabIndex = 2
        Me.rbn_Both.Text = "Both"
        Me.rbn_Both.UseVisualStyleBackColor = True
        Me.rbn_Both.Visible = False
        '
        'rbn_Client
        '
        Me.rbn_Client.AutoSize = True
        Me.rbn_Client.Location = New System.Drawing.Point(6, 42)
        Me.rbn_Client.Name = "rbn_Client"
        Me.rbn_Client.Size = New System.Drawing.Size(51, 17)
        Me.rbn_Client.TabIndex = 1
        Me.rbn_Client.Text = "Client"
        Me.rbn_Client.UseVisualStyleBackColor = True
        '
        'rbn_Engineering
        '
        Me.rbn_Engineering.AutoSize = True
        Me.rbn_Engineering.Checked = True
        Me.rbn_Engineering.Location = New System.Drawing.Point(6, 19)
        Me.rbn_Engineering.Name = "rbn_Engineering"
        Me.rbn_Engineering.Size = New System.Drawing.Size(81, 17)
        Me.rbn_Engineering.TabIndex = 0
        Me.rbn_Engineering.TabStop = True
        Me.rbn_Engineering.Text = "Engineering"
        Me.rbn_Engineering.UseVisualStyleBackColor = True
        '
        'tbx_Notes
        '
        Me.tbx_Notes.Location = New System.Drawing.Point(337, 313)
        Me.tbx_Notes.MaxLength = 255
        Me.tbx_Notes.Multiline = True
        Me.tbx_Notes.Name = "tbx_Notes"
        Me.tbx_Notes.Size = New System.Drawing.Size(222, 93)
        Me.tbx_Notes.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(296, 316)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Notes"
        '
        'lbx_References
        '
        Me.lbx_References.FormattingEnabled = True
        Me.lbx_References.Location = New System.Drawing.Point(337, 55)
        Me.lbx_References.Name = "lbx_References"
        Me.lbx_References.Size = New System.Drawing.Size(222, 251)
        Me.lbx_References.TabIndex = 11
        '
        'btn_RemoveFromList
        '
        Me.btn_RemoveFromList.Image = Global.PackageViewer.My.Resources.Resources.Navigation_Blue_Left
        Me.btn_RemoveFromList.Location = New System.Drawing.Point(277, 178)
        Me.btn_RemoveFromList.Name = "btn_RemoveFromList"
        Me.btn_RemoveFromList.Size = New System.Drawing.Size(54, 41)
        Me.btn_RemoveFromList.TabIndex = 13
        Me.btn_RemoveFromList.UseVisualStyleBackColor = True
        '
        'btn_AddToList
        '
        Me.btn_AddToList.Image = Global.PackageViewer.My.Resources.Resources.Navigation_Blue_Right
        Me.btn_AddToList.Location = New System.Drawing.Point(277, 108)
        Me.btn_AddToList.Name = "btn_AddToList"
        Me.btn_AddToList.Size = New System.Drawing.Size(54, 41)
        Me.btn_AddToList.TabIndex = 12
        Me.btn_AddToList.UseVisualStyleBackColor = True
        '
        'tbx_documentType
        '
        Me.tbx_documentType.Location = New System.Drawing.Point(16, 29)
        Me.tbx_documentType.Name = "tbx_documentType"
        Me.tbx_documentType.Size = New System.Drawing.Size(255, 20)
        Me.tbx_documentType.TabIndex = 14
        '
        'AddPackageDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 456)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbx_documentType)
        Me.Controls.Add(Me.btn_RemoveFromList)
        Me.Controls.Add(Me.btn_AddToList)
        Me.Controls.Add(Me.lbx_References)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbx_Notes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_TagReference)
        Me.Controls.Add(Me.cbx_TagList)
        Me.Controls.Add(Me.cbx_DocumentCategory)
        Me.Controls.Add(Me.lbx_DocumentList)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Name = "AddPackageDocument"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add a Document"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents lbx_DocumentList As System.Windows.Forms.ListBox
    Friend WithEvents cbx_DocumentCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_TagList As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_TagReference As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbn_Client As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_Engineering As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_Both As System.Windows.Forms.RadioButton
    Friend WithEvents tbx_Notes As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbx_References As System.Windows.Forms.ListBox
    Friend WithEvents btn_AddToList As System.Windows.Forms.Button
    Friend WithEvents btn_RemoveFromList As System.Windows.Forms.Button
    Friend WithEvents tbx_documentType As System.Windows.Forms.TextBox
End Class
