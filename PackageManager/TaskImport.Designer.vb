<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaskImport))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsb_ProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_OpenCSV = New System.Windows.Forms.ToolStripButton
        Me.btn_Import = New System.Windows.Forms.ToolStripButton
        Me.btn_Update = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chk_Update = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tbx_FieldInfo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbx_BaseQuantity = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbx_BaseMH = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbx_ActualFinish = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbx_ActualStart = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbx_ScheduledFinish = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbx_ScheduledStart = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbx_description = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbx_TaskGroup = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbx_taskid = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbx_p3id = New System.Windows.Forms.ComboBox
        Me.dgv_CSV = New System.Windows.Forms.DataGridView
        Me.lbl_Defaults = New System.Windows.Forms.Label
        Me.tbx_DefaultTaskGroup = New System.Windows.Forms.TextBox
        Me.tbx_DefaultSchStart = New System.Windows.Forms.MaskedTextBox
        Me.tbx_DefaultSchFinish = New System.Windows.Forms.MaskedTextBox
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_CSV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsb_ProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 618)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(831, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(714, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'tsb_ProgressBar
        '
        Me.tsb_ProgressBar.Name = "tsb_ProgressBar"
        Me.tsb_ProgressBar.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_OpenCSV, Me.btn_Import, Me.btn_Update})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(831, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_OpenCSV
        '
        Me.btn_OpenCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_OpenCSV.Image = CType(resources.GetObject("btn_OpenCSV.Image"), System.Drawing.Image)
        Me.btn_OpenCSV.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_OpenCSV.Name = "btn_OpenCSV"
        Me.btn_OpenCSV.Size = New System.Drawing.Size(23, 22)
        Me.btn_OpenCSV.Text = "Open CSV"
        '
        'btn_Import
        '
        Me.btn_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Import.Enabled = False
        Me.btn_Import.Image = CType(resources.GetObject("btn_Import.Image"), System.Drawing.Image)
        Me.btn_Import.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Import.Name = "btn_Import"
        Me.btn_Import.Size = New System.Drawing.Size(23, 22)
        Me.btn_Import.Text = "Task Import"
        Me.btn_Import.ToolTipText = "Task Import"
        '
        'btn_Update
        '
        Me.btn_Update.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Update.Enabled = False
        Me.btn_Update.Image = Global.package.My.Resources.Resources.Data_Blue_Edit
        Me.btn_Update.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(23, 22)
        Me.btn_Update.Text = "Task Update"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel1MinSize = 350
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_CSV)
        Me.SplitContainer1.Size = New System.Drawing.Size(831, 593)
        Me.SplitContainer1.SplitterDistance = 350
        Me.SplitContainer1.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(831, 350)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tbx_DefaultSchFinish)
        Me.TabPage1.Controls.Add(Me.tbx_DefaultSchStart)
        Me.TabPage1.Controls.Add(Me.tbx_DefaultTaskGroup)
        Me.TabPage1.Controls.Add(Me.lbl_Defaults)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.cbx_BaseQuantity)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.cbx_BaseMH)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.cbx_ActualFinish)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.cbx_ActualStart)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cbx_ScheduledFinish)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cbx_ScheduledStart)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.cbx_description)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cbx_TaskGroup)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cbx_taskid)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cbx_p3id)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(823, 324)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Task Import Mapping"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(27, 299)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "*Required Fields"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk_Update)
        Me.GroupBox2.Location = New System.Drawing.Point(492, 113)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(307, 183)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Import Settings"
        '
        'chk_Update
        '
        Me.chk_Update.AutoSize = True
        Me.chk_Update.Checked = True
        Me.chk_Update.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Update.Location = New System.Drawing.Point(17, 21)
        Me.chk_Update.Name = "chk_Update"
        Me.chk_Update.Size = New System.Drawing.Size(155, 17)
        Me.chk_Update.TabIndex = 0
        Me.chk_Update.Text = "Update Existing Information"
        Me.chk_Update.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbx_FieldInfo)
        Me.GroupBox1.Location = New System.Drawing.Point(492, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(310, 67)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Field Information"
        '
        'tbx_FieldInfo
        '
        Me.tbx_FieldInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbx_FieldInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbx_FieldInfo.Location = New System.Drawing.Point(3, 16)
        Me.tbx_FieldInfo.Multiline = True
        Me.tbx_FieldInfo.Name = "tbx_FieldInfo"
        Me.tbx_FieldInfo.Size = New System.Drawing.Size(304, 48)
        Me.tbx_FieldInfo.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(27, 275)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Base Quantity"
        '
        'cbx_BaseQuantity
        '
        Me.cbx_BaseQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_BaseQuantity.FormattingEnabled = True
        Me.cbx_BaseQuantity.Location = New System.Drawing.Point(121, 275)
        Me.cbx_BaseQuantity.Name = "cbx_BaseQuantity"
        Me.cbx_BaseQuantity.Size = New System.Drawing.Size(180, 21)
        Me.cbx_BaseQuantity.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 248)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Base Man Hours*"
        '
        'cbx_BaseMH
        '
        Me.cbx_BaseMH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_BaseMH.FormattingEnabled = True
        Me.cbx_BaseMH.Location = New System.Drawing.Point(121, 248)
        Me.cbx_BaseMH.Name = "cbx_BaseMH"
        Me.cbx_BaseMH.Size = New System.Drawing.Size(180, 21)
        Me.cbx_BaseMH.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 221)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Actual Finish"
        '
        'cbx_ActualFinish
        '
        Me.cbx_ActualFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ActualFinish.FormattingEnabled = True
        Me.cbx_ActualFinish.Location = New System.Drawing.Point(121, 221)
        Me.cbx_ActualFinish.Name = "cbx_ActualFinish"
        Me.cbx_ActualFinish.Size = New System.Drawing.Size(180, 21)
        Me.cbx_ActualFinish.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Actual Start"
        '
        'cbx_ActualStart
        '
        Me.cbx_ActualStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ActualStart.FormattingEnabled = True
        Me.cbx_ActualStart.Location = New System.Drawing.Point(121, 194)
        Me.cbx_ActualStart.Name = "cbx_ActualStart"
        Me.cbx_ActualStart.Size = New System.Drawing.Size(180, 21)
        Me.cbx_ActualStart.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Scheduled Finish"
        '
        'cbx_ScheduledFinish
        '
        Me.cbx_ScheduledFinish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ScheduledFinish.FormattingEnabled = True
        Me.cbx_ScheduledFinish.Location = New System.Drawing.Point(121, 167)
        Me.cbx_ScheduledFinish.Name = "cbx_ScheduledFinish"
        Me.cbx_ScheduledFinish.Size = New System.Drawing.Size(180, 21)
        Me.cbx_ScheduledFinish.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Scheduled Start"
        '
        'cbx_ScheduledStart
        '
        Me.cbx_ScheduledStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ScheduledStart.FormattingEnabled = True
        Me.cbx_ScheduledStart.Location = New System.Drawing.Point(121, 140)
        Me.cbx_ScheduledStart.Name = "cbx_ScheduledStart"
        Me.cbx_ScheduledStart.Size = New System.Drawing.Size(180, 21)
        Me.cbx_ScheduledStart.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Description*"
        '
        'cbx_description
        '
        Me.cbx_description.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_description.FormattingEnabled = True
        Me.cbx_description.Location = New System.Drawing.Point(121, 113)
        Me.cbx_description.Name = "cbx_description"
        Me.cbx_description.Size = New System.Drawing.Size(180, 21)
        Me.cbx_description.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Task Group*"
        '
        'cbx_TaskGroup
        '
        Me.cbx_TaskGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_TaskGroup.FormattingEnabled = True
        Me.cbx_TaskGroup.Location = New System.Drawing.Point(121, 86)
        Me.cbx_TaskGroup.Name = "cbx_TaskGroup"
        Me.cbx_TaskGroup.Size = New System.Drawing.Size(180, 21)
        Me.cbx_TaskGroup.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Task ID*"
        '
        'cbx_taskid
        '
        Me.cbx_taskid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_taskid.FormattingEnabled = True
        Me.cbx_taskid.Location = New System.Drawing.Point(121, 59)
        Me.cbx_taskid.Name = "cbx_taskid"
        Me.cbx_taskid.Size = New System.Drawing.Size(180, 21)
        Me.cbx_taskid.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "P3 ID*"
        '
        'cbx_p3id
        '
        Me.cbx_p3id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_p3id.FormattingEnabled = True
        Me.cbx_p3id.Location = New System.Drawing.Point(121, 32)
        Me.cbx_p3id.Name = "cbx_p3id"
        Me.cbx_p3id.Size = New System.Drawing.Size(180, 21)
        Me.cbx_p3id.TabIndex = 0
        '
        'dgv_CSV
        '
        Me.dgv_CSV.AllowUserToAddRows = False
        Me.dgv_CSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_CSV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_CSV.Location = New System.Drawing.Point(0, 0)
        Me.dgv_CSV.Name = "dgv_CSV"
        Me.dgv_CSV.Size = New System.Drawing.Size(831, 239)
        Me.dgv_CSV.TabIndex = 0
        '
        'lbl_Defaults
        '
        Me.lbl_Defaults.AutoSize = True
        Me.lbl_Defaults.Location = New System.Drawing.Point(329, 16)
        Me.lbl_Defaults.Name = "lbl_Defaults"
        Me.lbl_Defaults.Size = New System.Drawing.Size(76, 13)
        Me.lbl_Defaults.TabIndex = 23
        Me.lbl_Defaults.Text = "Default Values"
        '
        'tbx_DefaultTaskGroup
        '
        Me.tbx_DefaultTaskGroup.Location = New System.Drawing.Point(303, 87)
        Me.tbx_DefaultTaskGroup.Name = "tbx_DefaultTaskGroup"
        Me.tbx_DefaultTaskGroup.Size = New System.Drawing.Size(144, 20)
        Me.tbx_DefaultTaskGroup.TabIndex = 24
        Me.tbx_DefaultTaskGroup.Text = "undefined"
        '
        'tbx_DefaultSchStart
        '
        Me.tbx_DefaultSchStart.Location = New System.Drawing.Point(303, 140)
        Me.tbx_DefaultSchStart.Mask = "00/00/0000"
        Me.tbx_DefaultSchStart.Name = "tbx_DefaultSchStart"
        Me.tbx_DefaultSchStart.Size = New System.Drawing.Size(144, 20)
        Me.tbx_DefaultSchStart.TabIndex = 27
        Me.tbx_DefaultSchStart.ValidatingType = GetType(Date)
        '
        'tbx_DefaultSchFinish
        '
        Me.tbx_DefaultSchFinish.Location = New System.Drawing.Point(303, 168)
        Me.tbx_DefaultSchFinish.Mask = "00/00/0000"
        Me.tbx_DefaultSchFinish.Name = "tbx_DefaultSchFinish"
        Me.tbx_DefaultSchFinish.Size = New System.Drawing.Size(144, 20)
        Me.tbx_DefaultSchFinish.TabIndex = 28
        Me.tbx_DefaultSchFinish.ValidatingType = GetType(Date)
        '
        'TaskImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 640)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TaskImport"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Task Import"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_CSV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_CSV As System.Windows.Forms.DataGridView
    Friend WithEvents btn_OpenCSV As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_ProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbx_p3id As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbx_BaseQuantity As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbx_BaseMH As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbx_ActualFinish As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbx_ActualStart As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbx_ScheduledFinish As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbx_ScheduledStart As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbx_description As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbx_TaskGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbx_taskid As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbx_FieldInfo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_Update As System.Windows.Forms.CheckBox
    Friend WithEvents btn_Import As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_Update As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbx_DefaultTaskGroup As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Defaults As System.Windows.Forms.Label
    Friend WithEvents tbx_DefaultSchFinish As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tbx_DefaultSchStart As System.Windows.Forms.MaskedTextBox
End Class
