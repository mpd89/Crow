<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportCSV
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsb_ProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.VGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.lbl_RequiredField = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ckb_OverrideExisting = New System.Windows.Forms.CheckBox
        Me.lbl_CSVColumn = New System.Windows.Forms.Label
        Me.ckb_OverrideDuplicates = New System.Windows.Forms.CheckBox
        Me.lbl_TableColumn = New System.Windows.Forms.Label
        Me.ckb_IgnoreBlanks = New System.Windows.Forms.CheckBox
        Me.btn_CheckData = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.btn_ImportData = New System.Windows.Forms.Button
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbx_Headers = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.tbx_Filename = New System.Windows.Forms.TextBox
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsb_ProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 505)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(816, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(699, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'tsb_ProgressBar
        '
        Me.tsb_ProgressBar.Name = "tsb_ProgressBar"
        Me.tsb_ProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbx_Headers)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_Filename)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(816, 505)
        Me.SplitContainer1.SplitterDistance = 304
        Me.SplitContainer1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.VGridControl1)
        Me.Panel1.Controls.Add(Me.lbl_RequiredField)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ckb_OverrideExisting)
        Me.Panel1.Controls.Add(Me.lbl_CSVColumn)
        Me.Panel1.Controls.Add(Me.ckb_OverrideDuplicates)
        Me.Panel1.Controls.Add(Me.lbl_TableColumn)
        Me.Panel1.Controls.Add(Me.ckb_IgnoreBlanks)
        Me.Panel1.Controls.Add(Me.btn_CheckData)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.btn_ImportData)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(13, 100)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(289, 384)
        Me.Panel1.TabIndex = 139
        '
        'VGridControl1
        '
        Me.VGridControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.VGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.VGridControl1.Location = New System.Drawing.Point(6, 42)
        Me.VGridControl1.Name = "VGridControl1"
        Me.VGridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.VGridControl1.Size = New System.Drawing.Size(278, 201)
        Me.VGridControl1.TabIndex = 130
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'lbl_RequiredField
        '
        Me.lbl_RequiredField.AutoSize = True
        Me.lbl_RequiredField.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RequiredField.ForeColor = System.Drawing.Color.Red
        Me.lbl_RequiredField.Location = New System.Drawing.Point(149, 9)
        Me.lbl_RequiredField.Name = "lbl_RequiredField"
        Me.lbl_RequiredField.Size = New System.Drawing.Size(0, 13)
        Me.lbl_RequiredField.TabIndex = 138
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Map Colums Below:"
        '
        'ckb_OverrideExisting
        '
        Me.ckb_OverrideExisting.AutoSize = True
        Me.ckb_OverrideExisting.Location = New System.Drawing.Point(130, 358)
        Me.ckb_OverrideExisting.Name = "ckb_OverrideExisting"
        Me.ckb_OverrideExisting.Size = New System.Drawing.Size(140, 17)
        Me.ckb_OverrideExisting.TabIndex = 133
        Me.ckb_OverrideExisting.Text = "Override Existing Values"
        Me.ckb_OverrideExisting.UseVisualStyleBackColor = True
        '
        'lbl_CSVColumn
        '
        Me.lbl_CSVColumn.AutoSize = True
        Me.lbl_CSVColumn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CSVColumn.Location = New System.Drawing.Point(177, 26)
        Me.lbl_CSVColumn.Name = "lbl_CSVColumn"
        Me.lbl_CSVColumn.Size = New System.Drawing.Size(66, 13)
        Me.lbl_CSVColumn.TabIndex = 137
        Me.lbl_CSVColumn.Text = "CSV Column"
        '
        'ckb_OverrideDuplicates
        '
        Me.ckb_OverrideDuplicates.AutoSize = True
        Me.ckb_OverrideDuplicates.Location = New System.Drawing.Point(130, 326)
        Me.ckb_OverrideDuplicates.Name = "ckb_OverrideDuplicates"
        Me.ckb_OverrideDuplicates.Size = New System.Drawing.Size(149, 17)
        Me.ckb_OverrideDuplicates.TabIndex = 132
        Me.ckb_OverrideDuplicates.Text = "Override Duplicate Values"
        Me.ckb_OverrideDuplicates.UseVisualStyleBackColor = True
        '
        'lbl_TableColumn
        '
        Me.lbl_TableColumn.AutoSize = True
        Me.lbl_TableColumn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TableColumn.Location = New System.Drawing.Point(26, 26)
        Me.lbl_TableColumn.Name = "lbl_TableColumn"
        Me.lbl_TableColumn.Size = New System.Drawing.Size(72, 13)
        Me.lbl_TableColumn.TabIndex = 136
        Me.lbl_TableColumn.Text = "Table Column"
        '
        'ckb_IgnoreBlanks
        '
        Me.ckb_IgnoreBlanks.AutoSize = True
        Me.ckb_IgnoreBlanks.Location = New System.Drawing.Point(130, 291)
        Me.ckb_IgnoreBlanks.Name = "ckb_IgnoreBlanks"
        Me.ckb_IgnoreBlanks.Size = New System.Drawing.Size(91, 17)
        Me.ckb_IgnoreBlanks.TabIndex = 131
        Me.ckb_IgnoreBlanks.Text = "Ignore Blanks"
        Me.ckb_IgnoreBlanks.UseVisualStyleBackColor = True
        '
        'btn_CheckData
        '
        Me.btn_CheckData.Location = New System.Drawing.Point(47, 247)
        Me.btn_CheckData.Name = "btn_CheckData"
        Me.btn_CheckData.Size = New System.Drawing.Size(75, 23)
        Me.btn_CheckData.TabIndex = 121
        Me.btn_CheckData.Text = "Check Data"
        Me.btn_CheckData.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(35, 362)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Existing Type"
        '
        'btn_ImportData
        '
        Me.btn_ImportData.Enabled = False
        Me.btn_ImportData.Location = New System.Drawing.Point(168, 247)
        Me.btn_ImportData.Name = "btn_ImportData"
        Me.btn_ImportData.Size = New System.Drawing.Size(75, 23)
        Me.btn_ImportData.TabIndex = 122
        Me.btn_ImportData.Text = "Import Data"
        Me.btn_ImportData.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Fuchsia
        Me.TextBox3.Location = New System.Drawing.Point(10, 355)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(19, 20)
        Me.TextBox3.TabIndex = 128
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 273)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 123
        Me.Label5.Text = "Error Codes::"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "Duplicate Values"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Aqua
        Me.TextBox2.Location = New System.Drawing.Point(10, 321)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(19, 20)
        Me.TextBox2.TabIndex = 126
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Yellow
        Me.TextBox1.Location = New System.Drawing.Point(10, 289)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(19, 20)
        Me.TextBox1.TabIndex = 124
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 296)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "Blank Entries"
        '
        'cbx_Headers
        '
        Me.cbx_Headers.AutoSize = True
        Me.cbx_Headers.Checked = True
        Me.cbx_Headers.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbx_Headers.Location = New System.Drawing.Point(13, 77)
        Me.cbx_Headers.Name = "cbx_Headers"
        Me.cbx_Headers.Size = New System.Drawing.Size(149, 17)
        Me.cbx_Headers.TabIndex = 120
        Me.cbx_Headers.Text = "First row contains headers"
        Me.cbx_Headers.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 13)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "Select .csv Import File:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(184, 50)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 21)
        Me.Button1.TabIndex = 118
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbx_Filename
        '
        Me.tbx_Filename.Location = New System.Drawing.Point(13, 51)
        Me.tbx_Filename.Name = "tbx_Filename"
        Me.tbx_Filename.Size = New System.Drawing.Size(165, 20)
        Me.tbx_Filename.TabIndex = 117
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(508, 505)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        '
        'ImportCSV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 527)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImportCSV"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import InchesEQLookup"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_ImportData As System.Windows.Forms.Button
    Friend WithEvents btn_CheckData As System.Windows.Forms.Button
    Friend WithEvents cbx_Headers As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbx_Filename As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsb_ProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents VGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ckb_OverrideExisting As System.Windows.Forms.CheckBox
    Friend WithEvents ckb_OverrideDuplicates As System.Windows.Forms.CheckBox
    Friend WithEvents ckb_IgnoreBlanks As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_RequiredField As System.Windows.Forms.Label
    Friend WithEvents lbl_CSVColumn As System.Windows.Forms.Label
    Friend WithEvents lbl_TableColumn As System.Windows.Forms.Label
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
