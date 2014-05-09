<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemImport
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
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbx_Description = New System.Windows.Forms.ComboBox
        Me.cbx_Identifier = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbx_Parent = New System.Windows.Forms.ComboBox
        Me.lbl_Parent = New System.Windows.Forms.Label
        Me.cbx_Tier = New System.Windows.Forms.ComboBox
        Me.lbl_TierNumber = New System.Windows.Forms.Label
        Me.dgv_SystemGrid = New System.Windows.Forms.DataGridView
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv_SystemGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsb_ProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 536)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(855, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(707, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox4)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbx_Description)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbx_Identifier)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbx_Parent)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbl_Parent)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbx_Tier)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbl_TierNumber)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_SystemGrid)
        Me.SplitContainer1.Size = New System.Drawing.Size(855, 536)
        Me.SplitContainer1.SplitterDistance = 217
        Me.SplitContainer1.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(40, 462)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "Invalid Parent System"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.PaleVioletRed
        Me.TextBox4.Location = New System.Drawing.Point(15, 455)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(19, 20)
        Me.TextBox4.TabIndex = 106
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(40, 429)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "Existing System"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Fuchsia
        Me.TextBox3.Location = New System.Drawing.Point(15, 422)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(19, 20)
        Me.TextBox3.TabIndex = 104
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(40, 395)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(158, 13)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "Duplicate System / Descriptions"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Aqua
        Me.TextBox2.Location = New System.Drawing.Point(15, 388)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(19, 20)
        Me.TextBox2.TabIndex = 102
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(40, 363)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Blank Entries"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Yellow
        Me.TextBox1.Location = New System.Drawing.Point(15, 356)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(19, 20)
        Me.TextBox1.TabIndex = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 329)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Error Codes::"
        '
        'btn_ImportData
        '
        Me.btn_ImportData.Enabled = False
        Me.btn_ImportData.Location = New System.Drawing.Point(129, 283)
        Me.btn_ImportData.Name = "btn_ImportData"
        Me.btn_ImportData.Size = New System.Drawing.Size(75, 23)
        Me.btn_ImportData.TabIndex = 98
        Me.btn_ImportData.Text = "Import Data"
        Me.btn_ImportData.UseVisualStyleBackColor = True
        '
        'btn_CheckData
        '
        Me.btn_CheckData.Location = New System.Drawing.Point(24, 283)
        Me.btn_CheckData.Name = "btn_CheckData"
        Me.btn_CheckData.Size = New System.Drawing.Size(75, 23)
        Me.btn_CheckData.TabIndex = 97
        Me.btn_CheckData.Text = "Check Data"
        Me.btn_CheckData.UseVisualStyleBackColor = True
        '
        'cbx_Headers
        '
        Me.cbx_Headers.AutoSize = True
        Me.cbx_Headers.Checked = True
        Me.cbx_Headers.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbx_Headers.Location = New System.Drawing.Point(15, 72)
        Me.cbx_Headers.Name = "cbx_Headers"
        Me.cbx_Headers.Size = New System.Drawing.Size(149, 17)
        Me.cbx_Headers.TabIndex = 96
        Me.cbx_Headers.Text = "First row contains headers"
        Me.cbx_Headers.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Select .csv Import File:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(186, 45)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 21)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbx_Filename
        '
        Me.tbx_Filename.Location = New System.Drawing.Point(15, 46)
        Me.tbx_Filename.Name = "tbx_Filename"
        Me.tbx_Filename.Size = New System.Drawing.Size(165, 20)
        Me.tbx_Filename.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Identifier"
        '
        'cbx_Description
        '
        Me.cbx_Description.FormattingEnabled = True
        Me.cbx_Description.Location = New System.Drawing.Point(74, 238)
        Me.cbx_Description.Name = "cbx_Description"
        Me.cbx_Description.Size = New System.Drawing.Size(130, 21)
        Me.cbx_Description.TabIndex = 6
        '
        'cbx_Identifier
        '
        Me.cbx_Identifier.FormattingEnabled = True
        Me.cbx_Identifier.Location = New System.Drawing.Point(74, 211)
        Me.cbx_Identifier.Name = "cbx_Identifier"
        Me.cbx_Identifier.Size = New System.Drawing.Size(130, 21)
        Me.cbx_Identifier.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Map Colums Below:"
        '
        'cbx_Parent
        '
        Me.cbx_Parent.FormattingEnabled = True
        Me.cbx_Parent.Location = New System.Drawing.Point(74, 184)
        Me.cbx_Parent.Name = "cbx_Parent"
        Me.cbx_Parent.Size = New System.Drawing.Size(130, 21)
        Me.cbx_Parent.TabIndex = 3
        '
        'lbl_Parent
        '
        Me.lbl_Parent.AutoSize = True
        Me.lbl_Parent.Location = New System.Drawing.Point(30, 192)
        Me.lbl_Parent.Name = "lbl_Parent"
        Me.lbl_Parent.Size = New System.Drawing.Size(38, 13)
        Me.lbl_Parent.TabIndex = 2
        Me.lbl_Parent.Text = "Parent"
        '
        'cbx_Tier
        '
        Me.cbx_Tier.FormattingEnabled = True
        Me.cbx_Tier.Location = New System.Drawing.Point(74, 157)
        Me.cbx_Tier.Name = "cbx_Tier"
        Me.cbx_Tier.Size = New System.Drawing.Size(130, 21)
        Me.cbx_Tier.TabIndex = 1
        '
        'lbl_TierNumber
        '
        Me.lbl_TierNumber.AutoSize = True
        Me.lbl_TierNumber.Location = New System.Drawing.Point(43, 165)
        Me.lbl_TierNumber.Name = "lbl_TierNumber"
        Me.lbl_TierNumber.Size = New System.Drawing.Size(25, 13)
        Me.lbl_TierNumber.TabIndex = 0
        Me.lbl_TierNumber.Text = "Tier"
        '
        'dgv_SystemGrid
        '
        Me.dgv_SystemGrid.AllowUserToAddRows = False
        Me.dgv_SystemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_SystemGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_SystemGrid.Location = New System.Drawing.Point(0, 0)
        Me.dgv_SystemGrid.Name = "dgv_SystemGrid"
        Me.dgv_SystemGrid.Size = New System.Drawing.Size(634, 536)
        Me.dgv_SystemGrid.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SystemImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 558)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SystemImport"
        Me.Text = "Import Systems"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv_SystemGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgv_SystemGrid As System.Windows.Forms.DataGridView
    Friend WithEvents cbx_Parent As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Parent As System.Windows.Forms.Label
    Friend WithEvents cbx_Tier As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_TierNumber As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbx_Description As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Identifier As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbx_Filename As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cbx_Headers As System.Windows.Forms.CheckBox
    Friend WithEvents tsb_ProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btn_ImportData As System.Windows.Forms.Button
    Friend WithEvents btn_CheckData As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
