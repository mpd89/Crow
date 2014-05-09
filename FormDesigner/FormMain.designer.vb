<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FormatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FontSelect = New System.Windows.Forms.ToolStripMenuItem
        Me.BkColor = New System.Windows.Forms.ToolStripMenuItem
        Me.DataTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.dataTypeText = New System.Windows.Forms.ToolStripMenuItem
        Me.dataTypeNumber = New System.Windows.Forms.ToolStripMenuItem
        Me.dataTypeDateTime = New System.Windows.Forms.ToolStripMenuItem
        Me.dataTypeBoolean = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectAuxiliaryDataTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReloadFormImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FormList = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutDaqartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbl_Message = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsl_SiteLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProjectStatusInd = New System.Windows.Forms.ToolStripStatusLabel
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ConnTimer = New System.Timers.Timer
        Me.MainWindow = New System.Windows.Forms.SplitContainer
        Me.spl_Variables = New System.Windows.Forms.SplitContainer
        Me.tbx_CommonVariables = New System.Windows.Forms.TextBox
        Me.lbx_ElementFields = New System.Windows.Forms.ListBox
        Me.cbx_Elements = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_SubForm = New System.Windows.Forms.Button
        Me.tbx_FormVariables = New System.Windows.Forms.TextBox
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ConnTimer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainWindow.Panel1.SuspendLayout()
        Me.MainWindow.SuspendLayout()
        Me.spl_Variables.Panel1.SuspendLayout()
        Me.spl_Variables.Panel2.SuspendLayout()
        Me.spl_Variables.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.FormatToolStripMenuItem, Me.FormList, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(990, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.FileToolStripMenuItem.Text = "Forms"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'FormatToolStripMenuItem
        '
        Me.FormatToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FontSelect, Me.BkColor, Me.DataTypeToolStripMenuItem, Me.SelectAuxiliaryDataTemplateToolStripMenuItem, Me.ReloadFormImageToolStripMenuItem})
        Me.FormatToolStripMenuItem.Name = "FormatToolStripMenuItem"
        Me.FormatToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.FormatToolStripMenuItem.Text = "Format"
        '
        'FontSelect
        '
        Me.FontSelect.Image = Global.FormDesigner.My.Resources.Resources.Rename
        Me.FontSelect.Name = "FontSelect"
        Me.FontSelect.Size = New System.Drawing.Size(233, 22)
        Me.FontSelect.Text = "Font"
        '
        'BkColor
        '
        Me.BkColor.Image = Global.FormDesigner.My.Resources.Resources.Objects
        Me.BkColor.Name = "BkColor"
        Me.BkColor.Size = New System.Drawing.Size(233, 22)
        Me.BkColor.Text = "Background Color"
        '
        'DataTypeToolStripMenuItem
        '
        Me.DataTypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.dataTypeText, Me.dataTypeNumber, Me.dataTypeDateTime, Me.dataTypeBoolean})
        Me.DataTypeToolStripMenuItem.Name = "DataTypeToolStripMenuItem"
        Me.DataTypeToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.DataTypeToolStripMenuItem.Text = "Data Type"
        '
        'dataTypeText
        '
        Me.dataTypeText.Name = "dataTypeText"
        Me.dataTypeText.Size = New System.Drawing.Size(128, 22)
        Me.dataTypeText.Text = "Text"
        '
        'dataTypeNumber
        '
        Me.dataTypeNumber.Name = "dataTypeNumber"
        Me.dataTypeNumber.Size = New System.Drawing.Size(128, 22)
        Me.dataTypeNumber.Text = "Number"
        '
        'dataTypeDateTime
        '
        Me.dataTypeDateTime.Name = "dataTypeDateTime"
        Me.dataTypeDateTime.Size = New System.Drawing.Size(128, 22)
        Me.dataTypeDateTime.Text = "Date Time"
        '
        'dataTypeBoolean
        '
        Me.dataTypeBoolean.Name = "dataTypeBoolean"
        Me.dataTypeBoolean.Size = New System.Drawing.Size(128, 22)
        Me.dataTypeBoolean.Text = "Boolean"
        '
        'SelectAuxiliaryDataTemplateToolStripMenuItem
        '
        Me.SelectAuxiliaryDataTemplateToolStripMenuItem.Name = "SelectAuxiliaryDataTemplateToolStripMenuItem"
        Me.SelectAuxiliaryDataTemplateToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.SelectAuxiliaryDataTemplateToolStripMenuItem.Text = "Select Auxiliary Data Template"
        '
        'ReloadFormImageToolStripMenuItem
        '
        Me.ReloadFormImageToolStripMenuItem.Name = "ReloadFormImageToolStripMenuItem"
        Me.ReloadFormImageToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ReloadFormImageToolStripMenuItem.Text = "Reload Form Image"
        '
        'FormList
        '
        Me.FormList.Name = "FormList"
        Me.FormList.Size = New System.Drawing.Size(68, 20)
        Me.FormList.Text = "Form List"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpManualToolStripMenuItem, Me.AboutDaqartToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpManualToolStripMenuItem
        '
        Me.HelpManualToolStripMenuItem.Name = "HelpManualToolStripMenuItem"
        Me.HelpManualToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.HelpManualToolStripMenuItem.Text = "Help Manual"
        '
        'AboutDaqartToolStripMenuItem
        '
        Me.AboutDaqartToolStripMenuItem.Name = "AboutDaqartToolStripMenuItem"
        Me.AboutDaqartToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.AboutDaqartToolStripMenuItem.Text = "About Daqart"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lbl_Message, Me.tsl_SiteLabel, Me.ProjectStatusInd})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 515)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(990, 24)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 19)
        '
        'lbl_Message
        '
        Me.lbl_Message.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Message.Name = "lbl_Message"
        Me.lbl_Message.Size = New System.Drawing.Size(734, 19)
        Me.lbl_Message.Spring = True
        Me.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsl_SiteLabel
        '
        Me.tsl_SiteLabel.BackColor = System.Drawing.SystemColors.Control
        Me.tsl_SiteLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsl_SiteLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tsl_SiteLabel.Name = "tsl_SiteLabel"
        Me.tsl_SiteLabel.Size = New System.Drawing.Size(117, 19)
        Me.tsl_SiteLabel.Text = "Site: Not Connected"
        '
        'ProjectStatusInd
        '
        Me.ProjectStatusInd.BackColor = System.Drawing.SystemColors.Control
        Me.ProjectStatusInd.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ProjectStatusInd.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ProjectStatusInd.Name = "ProjectStatusInd"
        Me.ProjectStatusInd.Size = New System.Drawing.Size(124, 19)
        Me.ProjectStatusInd.Text = "Project:  Not Selected"
        Me.ProjectStatusInd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "Daqart is Running"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Daqart"
        Me.NotifyIcon1.Visible = True
        '
        'ConnTimer
        '
        Me.ConnTimer.Enabled = True
        Me.ConnTimer.Interval = 500
        Me.ConnTimer.SynchronizingObject = Me
        '
        'MainWindow
        '
        Me.MainWindow.Dock = System.Windows.Forms.DockStyle.Left
        Me.MainWindow.Location = New System.Drawing.Point(0, 24)
        Me.MainWindow.Name = "MainWindow"
        '
        'MainWindow.Panel1
        '
        Me.MainWindow.Panel1.Controls.Add(Me.spl_Variables)
        Me.MainWindow.Panel2Collapsed = True
        Me.MainWindow.Size = New System.Drawing.Size(200, 491)
        Me.MainWindow.SplitterDistance = 175
        Me.MainWindow.TabIndex = 4
        Me.MainWindow.Visible = False
        '
        'spl_Variables
        '
        Me.spl_Variables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spl_Variables.Location = New System.Drawing.Point(0, 0)
        Me.spl_Variables.Name = "spl_Variables"
        Me.spl_Variables.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spl_Variables.Panel1
        '
        Me.spl_Variables.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.spl_Variables.Panel1.Controls.Add(Me.tbx_CommonVariables)
        '
        'spl_Variables.Panel2
        '
        Me.spl_Variables.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.spl_Variables.Panel2.Controls.Add(Me.lbx_ElementFields)
        Me.spl_Variables.Panel2.Controls.Add(Me.cbx_Elements)
        Me.spl_Variables.Panel2.Controls.Add(Me.Panel1)
        Me.spl_Variables.Size = New System.Drawing.Size(200, 491)
        Me.spl_Variables.SplitterDistance = 228
        Me.spl_Variables.TabIndex = 0
        '
        'tbx_CommonVariables
        '
        Me.tbx_CommonVariables.BackColor = System.Drawing.SystemColors.Window
        Me.tbx_CommonVariables.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbx_CommonVariables.Dock = System.Windows.Forms.DockStyle.Top
        Me.tbx_CommonVariables.Enabled = False
        Me.tbx_CommonVariables.Location = New System.Drawing.Point(0, 0)
        Me.tbx_CommonVariables.Name = "tbx_CommonVariables"
        Me.tbx_CommonVariables.ReadOnly = True
        Me.tbx_CommonVariables.Size = New System.Drawing.Size(200, 13)
        Me.tbx_CommonVariables.TabIndex = 0
        Me.tbx_CommonVariables.Text = "System Variables"
        '
        'lbx_ElementFields
        '
        Me.lbx_ElementFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbx_ElementFields.FormattingEnabled = True
        Me.lbx_ElementFields.Location = New System.Drawing.Point(0, 52)
        Me.lbx_ElementFields.Name = "lbx_ElementFields"
        Me.lbx_ElementFields.Size = New System.Drawing.Size(200, 199)
        Me.lbx_ElementFields.TabIndex = 4
        '
        'cbx_Elements
        '
        Me.cbx_Elements.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbx_Elements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Elements.FormattingEnabled = True
        Me.cbx_Elements.Location = New System.Drawing.Point(0, 31)
        Me.cbx_Elements.Name = "cbx_Elements"
        Me.cbx_Elements.Size = New System.Drawing.Size(200, 21)
        Me.cbx_Elements.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.Controls.Add(Me.btn_SubForm)
        Me.Panel1.Controls.Add(Me.tbx_FormVariables)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 31)
        Me.Panel1.TabIndex = 2
        '
        'btn_SubForm
        '
        Me.btn_SubForm.Location = New System.Drawing.Point(115, 5)
        Me.btn_SubForm.Name = "btn_SubForm"
        Me.btn_SubForm.Size = New System.Drawing.Size(67, 23)
        Me.btn_SubForm.TabIndex = 2
        Me.btn_SubForm.Text = "SubForm"
        Me.btn_SubForm.UseVisualStyleBackColor = True
        '
        'tbx_FormVariables
        '
        Me.tbx_FormVariables.BackColor = System.Drawing.SystemColors.Window
        Me.tbx_FormVariables.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbx_FormVariables.Location = New System.Drawing.Point(3, 15)
        Me.tbx_FormVariables.Name = "tbx_FormVariables"
        Me.tbx_FormVariables.ReadOnly = True
        Me.tbx_FormVariables.Size = New System.Drawing.Size(106, 13)
        Me.tbx_FormVariables.TabIndex = 1
        Me.tbx_FormVariables.Text = "Element Variables"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(990, 539)
        Me.Controls.Add(Me.MainWindow)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.Text = "DAQART Forms"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ConnTimer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainWindow.Panel1.ResumeLayout(False)
        Me.MainWindow.ResumeLayout(False)
        Me.spl_Variables.Panel1.ResumeLayout(False)
        Me.spl_Variables.Panel1.PerformLayout()
        Me.spl_Variables.Panel2.ResumeLayout(False)
        Me.spl_Variables.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents HelpManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutDaqartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ConnTimer As System.Timers.Timer
    Friend WithEvents MainWindow As System.Windows.Forms.SplitContainer
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BkColor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dataTypeText As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dataTypeNumber As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dataTypeDateTime As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dataTypeBoolean As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spl_Variables As System.Windows.Forms.SplitContainer
    Friend WithEvents tbx_CommonVariables As System.Windows.Forms.TextBox
    Friend WithEvents tbx_FormVariables As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_SubForm As System.Windows.Forms.Button
    Friend WithEvents lbx_ElementFields As System.Windows.Forms.ListBox
    Public WithEvents cbx_Elements As System.Windows.Forms.ComboBox
    Public WithEvents FormList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAuxiliaryDataTemplateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_Message As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsl_SiteLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProjectStatusInd As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ReloadFormImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
