<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentImport
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_ImportData = New System.Windows.Forms.Button
        Me.btn_CheckData = New System.Windows.Forms.Button
        Me.cbx_Headers = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.tbx_Filename = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbx_Description = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbx_Type = New System.Windows.Forms.ComboBox
        Me.lbl_Type = New System.Windows.Forms.Label
        Me.dgv_TypeGrid = New System.Windows.Forms.DataGridView
        Me.tsb_ProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv_TypeGrid, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_ImportData)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_CheckData)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbx_Headers)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_Filename)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbx_Description)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbx_Type)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbl_Type)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_TypeGrid)
        Me.SplitContainer1.Size = New System.Drawing.Size(816, 505)
        Me.SplitContainer1.SplitterDistance = 220
        Me.SplitContainer1.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(38, 434)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Existing Type"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Fuchsia
        Me.TextBox3.Location = New System.Drawing.Point(13, 427)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(19, 20)
        Me.TextBox3.TabIndex = 128
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(38, 400)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 13)
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "Duplicate Types / Descriptions"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Aqua
        Me.TextBox2.Location = New System.Drawing.Point(13, 393)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(19, 20)
        Me.TextBox2.TabIndex = 126
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 368)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "Blank Entries"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Yellow
        Me.TextBox1.Location = New System.Drawing.Point(13, 361)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(19, 20)
        Me.TextBox1.TabIndex = 124
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 334)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 123
        Me.Label5.Text = "Error Codes::"
        '
        'btn_ImportData
        '
        Me.btn_ImportData.Enabled = False
        Me.btn_ImportData.Location = New System.Drawing.Point(121, 285)
        Me.btn_ImportData.Name = "btn_ImportData"
        Me.btn_ImportData.Size = New System.Drawing.Size(75, 23)
        Me.btn_ImportData.TabIndex = 122
        Me.btn_ImportData.Text = "Import Data"
        Me.btn_ImportData.UseVisualStyleBackColor = True
        '
        'btn_CheckData
        '
        Me.btn_CheckData.Location = New System.Drawing.Point(16, 285)
        Me.btn_CheckData.Name = "btn_CheckData"
        Me.btn_CheckData.Size = New System.Drawing.Size(75, 23)
        Me.btn_CheckData.TabIndex = 121
        Me.btn_CheckData.Text = "Check Data"
        Me.btn_CheckData.UseVisualStyleBackColor = True
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "Description"
        '
        'cbx_Description
        '
        Me.cbx_Description.FormattingEnabled = True
        Me.cbx_Description.Location = New System.Drawing.Point(72, 189)
        Me.cbx_Description.Name = "cbx_Description"
        Me.cbx_Description.Size = New System.Drawing.Size(130, 21)
        Me.cbx_Description.TabIndex = 114
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Map Colums Below:"
        '
        'cbx_Type
        '
        Me.cbx_Type.FormattingEnabled = True
        Me.cbx_Type.Location = New System.Drawing.Point(72, 162)
        Me.cbx_Type.Name = "cbx_Type"
        Me.cbx_Type.Size = New System.Drawing.Size(130, 21)
        Me.cbx_Type.TabIndex = 109
        '
        'lbl_Type
        '
        Me.lbl_Type.AutoSize = True
        Me.lbl_Type.Location = New System.Drawing.Point(41, 170)
        Me.lbl_Type.Name = "lbl_Type"
        Me.lbl_Type.Size = New System.Drawing.Size(31, 13)
        Me.lbl_Type.TabIndex = 108
        Me.lbl_Type.Text = "Type"
        '
        'dgv_TypeGrid
        '
        Me.dgv_TypeGrid.AllowUserToAddRows = False
        Me.dgv_TypeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_TypeGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_TypeGrid.Location = New System.Drawing.Point(0, 0)
        Me.dgv_TypeGrid.Name = "dgv_TypeGrid"
        Me.dgv_TypeGrid.Size = New System.Drawing.Size(592, 505)
        Me.dgv_TypeGrid.TabIndex = 0
        '
        'tsb_ProgressBar
        '
        Me.tsb_ProgressBar.Name = "tsb_ProgressBar"
        Me.tsb_ProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(668, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'EquipmentImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 527)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EquipmentImport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Equipment Import"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv_TypeGrid, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbx_Description As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbx_Type As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Type As System.Windows.Forms.Label
    Friend WithEvents dgv_TypeGrid As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsb_ProgressBar As System.Windows.Forms.ToolStripProgressBar
End Class
