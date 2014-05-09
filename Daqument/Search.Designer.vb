<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search
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
        Me.lblTag = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtDocumentID = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtRevision = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSheet = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEngCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvSearch = New System.Windows.Forms.DataGridView
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTag
        '
        Me.lblTag.AutoSize = True
        Me.lblTag.Location = New System.Drawing.Point(181, 530)
        Me.lblTag.Name = "lblTag"
        Me.lblTag.Size = New System.Drawing.Size(0, 13)
        Me.lblTag.TabIndex = 85
        Me.lblTag.Visible = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDocumentID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtLocation)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDescription)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtRevision)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSheet)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbProject)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtClientCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtEngCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvSearch)
        Me.SplitContainer1.Size = New System.Drawing.Size(736, 493)
        Me.SplitContainer1.SplitterDistance = 290
        Me.SplitContainer1.TabIndex = 86
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(80, 455)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 106
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtDocumentID
        '
        Me.txtDocumentID.Location = New System.Drawing.Point(105, 52)
        Me.txtDocumentID.Name = "txtDocumentID"
        Me.txtDocumentID.Size = New System.Drawing.Size(168, 20)
        Me.txtDocumentID.TabIndex = 105
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "Document ID"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(105, 310)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(168, 20)
        Me.txtLocation.TabIndex = 103
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 300)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 102
        Me.Label8.Text = "Location"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(105, 352)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(168, 69)
        Me.txtDescription.TabIndex = 101
        '
        'txtRevision
        '
        Me.txtRevision.Location = New System.Drawing.Point(105, 223)
        Me.txtRevision.Name = "txtRevision"
        Me.txtRevision.Size = New System.Drawing.Size(168, 20)
        Me.txtRevision.TabIndex = 100
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 355)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Description"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 223)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "Revision"
        '
        'txtSheet
        '
        Me.txtSheet.Location = New System.Drawing.Point(105, 179)
        Me.txtSheet.Name = "txtSheet"
        Me.txtSheet.Size = New System.Drawing.Size(168, 20)
        Me.txtSheet.TabIndex = 95
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Sheet"
        '
        'cmbProject
        '
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(105, 263)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(168, 21)
        Me.cmbProject.TabIndex = 93
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 263)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "Project"
        '
        'txtClientCode
        '
        Me.txtClientCode.Location = New System.Drawing.Point(105, 135)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(168, 20)
        Me.txtClientCode.TabIndex = 91
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Client Code"
        '
        'txtEngCode
        '
        Me.txtEngCode.Location = New System.Drawing.Point(105, 91)
        Me.txtEngCode.Name = "txtEngCode"
        Me.txtEngCode.Size = New System.Drawing.Size(168, 20)
        Me.txtEngCode.TabIndex = 89
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "Engineering Code"
        '
        'dgvSearch
        '
        Me.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSearch.Location = New System.Drawing.Point(0, 0)
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.Size = New System.Drawing.Size(442, 493)
        Me.dgvSearch.TabIndex = 1
        '
        'Search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 493)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblTag)
        Me.Name = "Search"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTag As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtDocumentID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtRevision As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSheet As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEngCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvSearch As System.Windows.Forms.DataGridView
End Class
