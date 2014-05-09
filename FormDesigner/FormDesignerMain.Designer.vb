<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDesignerMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDesignerMain))
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.cboDataType = New System.Windows.Forms.ToolStripComboBox
        Me.cboColor = New System.Windows.Forms.ToolStripTextBox
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportBaseDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOptionApplySelection = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.TsAttributeSelection = New System.Windows.Forms.ToolStripComboBox
        Me.ApplyWeightPercentageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TsApplyWtPcnt = New System.Windows.Forms.ToolStripComboBox
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.mnuFonts = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.mnuFontFamily = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.mnuFontSize = New System.Windows.Forms.ToolStripTextBox
        Me.mnuBtnTxtColor = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.TsBtn_Color = New System.Windows.Forms.ToolStripButton
        Me.mnuTxtColor = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuBtnDefaultValue = New System.Windows.Forms.ToolStripLabel
        Me.mnuDefaultValue = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel
        Me.mnuWeight = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel
        Me.mnuDataType = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripPageSelected = New System.Windows.Forms.ToolStripTextBox
        Me.TsBtn_First = New System.Windows.Forms.ToolStripButton
        Me.TsBtn_Previous = New System.Windows.Forms.ToolStripButton
        Me.TsBtn_Next = New System.Windows.Forms.ToolStripButton
        Me.TsBtn_Last = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblSampleFont = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboUserVar = New DevExpress.XtraEditors.ComboBoxEdit
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.cboUserVar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ToolStripSeparator1, Me.ImportToolStripMenuItem, Me.ExportToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(114, 6)
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 597)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1030, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'cboDataType
        '
        Me.cboDataType.Items.AddRange(New Object() {"Text", "CheckBox", "Time&Date", "NumericValue", ""})
        Me.cboDataType.Name = "cboDataType"
        Me.cboDataType.Size = New System.Drawing.Size(80, 21)
        '
        'cboColor
        '
        Me.cboColor.Name = "cboColor"
        Me.cboColor.Size = New System.Drawing.Size(50, 25)
        Me.cboColor.Text = "Color"
        Me.cboColor.ToolTipText = "Color"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuOptionApplySelection, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1030, 24)
        Me.MenuStrip1.TabIndex = 38
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem1, Me.ExitToolStripMenuItem1, Me.SaveExitToolStripMenuItem, Me.ExportBaseDocumentToolStripMenuItem})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(35, 20)
        Me.mnuFile.Text = "File"
        '
        'SaveToolStripMenuItem1
        '
        Me.SaveToolStripMenuItem1.Name = "SaveToolStripMenuItem1"
        Me.SaveToolStripMenuItem1.Size = New System.Drawing.Size(194, 22)
        Me.SaveToolStripMenuItem1.Text = "Save"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Image = Global.FormDesigner.My.Resources.Resources.Logout
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(194, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'SaveExitToolStripMenuItem
        '
        Me.SaveExitToolStripMenuItem.Name = "SaveExitToolStripMenuItem"
        Me.SaveExitToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.SaveExitToolStripMenuItem.Text = "Save & Exit"
        '
        'ExportBaseDocumentToolStripMenuItem
        '
        Me.ExportBaseDocumentToolStripMenuItem.Name = "ExportBaseDocumentToolStripMenuItem"
        Me.ExportBaseDocumentToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ExportBaseDocumentToolStripMenuItem.Text = "Export Base Document"
        '
        'mnuOptionApplySelection
        '
        Me.mnuOptionApplySelection.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ApplyWeightPercentageToolStripMenuItem})
        Me.mnuOptionApplySelection.Name = "mnuOptionApplySelection"
        Me.mnuOptionApplySelection.Size = New System.Drawing.Size(56, 20)
        Me.mnuOptionApplySelection.Text = "Options"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsAttributeSelection})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(207, 22)
        Me.ToolStripMenuItem1.Text = "Attribute selection"
        '
        'TsAttributeSelection
        '
        Me.TsAttributeSelection.Items.AddRange(New Object() {"Apply selection to all", "Reset after each entry"})
        Me.TsAttributeSelection.Name = "TsAttributeSelection"
        Me.TsAttributeSelection.Size = New System.Drawing.Size(121, 21)
        Me.TsAttributeSelection.Text = "Reset after each entry"
        '
        'ApplyWeightPercentageToolStripMenuItem
        '
        Me.ApplyWeightPercentageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsApplyWtPcnt})
        Me.ApplyWeightPercentageToolStripMenuItem.Name = "ApplyWeightPercentageToolStripMenuItem"
        Me.ApplyWeightPercentageToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ApplyWeightPercentageToolStripMenuItem.Text = "Apply Weight Percentage"
        '
        'TsApplyWtPcnt
        '
        Me.TsApplyWtPcnt.Items.AddRange(New Object() {"Equally to all", "Select individually"})
        Me.TsApplyWtPcnt.Name = "TsApplyWtPcnt"
        Me.TsApplyWtPcnt.Size = New System.Drawing.Size(121, 21)
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFonts, Me.ToolStripLabel1, Me.mnuFontFamily, Me.ToolStripLabel2, Me.mnuFontSize, Me.mnuBtnTxtColor, Me.ToolStripSeparator6, Me.TsBtn_Color, Me.mnuTxtColor, Me.ToolStripSeparator7, Me.mnuBtnDefaultValue, Me.mnuDefaultValue, Me.ToolStripLabel5, Me.mnuWeight, Me.ToolStripLabel6, Me.mnuDataType, Me.ToolStripPageSelected, Me.TsBtn_First, Me.TsBtn_Previous, Me.TsBtn_Next, Me.TsBtn_Last})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1030, 25)
        Me.ToolStrip1.TabIndex = 39
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'mnuFonts
        '
        Me.mnuFonts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuFonts.Image = CType(resources.GetObject("mnuFonts.Image"), System.Drawing.Image)
        Me.mnuFonts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuFonts.Name = "mnuFonts"
        Me.mnuFonts.Size = New System.Drawing.Size(38, 22)
        Me.mnuFonts.Text = "Fonts"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLabel1.Image = Global.FormDesigner.My.Resources.Resources.Rename
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(16, 22)
        Me.ToolStripLabel1.Text = "FontFamily"
        Me.ToolStripLabel1.ToolTipText = "Font Family"
        '
        'mnuFontFamily
        '
        Me.mnuFontFamily.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.mnuFontFamily.Name = "mnuFontFamily"
        Me.mnuFontFamily.Size = New System.Drawing.Size(150, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLabel2.Image = Global.FormDesigner.My.Resources.Resources.pcSizeGrip
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(16, 22)
        Me.ToolStripLabel2.Text = "FontSize"
        Me.ToolStripLabel2.ToolTipText = "Font Size"
        '
        'mnuFontSize
        '
        Me.mnuFontSize.Name = "mnuFontSize"
        Me.mnuFontSize.Size = New System.Drawing.Size(100, 25)
        '
        'mnuBtnTxtColor
        '
        Me.mnuBtnTxtColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnuBtnTxtColor.Name = "mnuBtnTxtColor"
        Me.mnuBtnTxtColor.Size = New System.Drawing.Size(0, 22)
        Me.mnuBtnTxtColor.Text = "txtColor"
        Me.mnuBtnTxtColor.ToolTipText = "Back Ground Color"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'TsBtn_Color
        '
        Me.TsBtn_Color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsBtn_Color.Image = Global.FormDesigner.My.Resources.Resources.Objects
        Me.TsBtn_Color.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtn_Color.Name = "TsBtn_Color"
        Me.TsBtn_Color.Size = New System.Drawing.Size(23, 22)
        Me.TsBtn_Color.Text = "ToolStripButton8"
        Me.TsBtn_Color.ToolTipText = "Background Color"
        '
        'mnuTxtColor
        '
        Me.mnuTxtColor.Name = "mnuTxtColor"
        Me.mnuTxtColor.Size = New System.Drawing.Size(50, 25)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'mnuBtnDefaultValue
        '
        Me.mnuBtnDefaultValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnuBtnDefaultValue.Image = Global.FormDesigner.My.Resources.Resources.tutorials
        Me.mnuBtnDefaultValue.Name = "mnuBtnDefaultValue"
        Me.mnuBtnDefaultValue.Size = New System.Drawing.Size(16, 22)
        Me.mnuBtnDefaultValue.Text = "DefaultValue"
        Me.mnuBtnDefaultValue.ToolTipText = "Default Value"
        '
        'mnuDefaultValue
        '
        Me.mnuDefaultValue.Name = "mnuDefaultValue"
        Me.mnuDefaultValue.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLabel5.Image = Global.FormDesigner.My.Resources.Resources.icon_add_layer
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(16, 22)
        Me.ToolStripLabel5.Text = "Weight"
        Me.ToolStripLabel5.ToolTipText = "Weight"
        '
        'mnuWeight
        '
        Me.mnuWeight.Name = "mnuWeight"
        Me.mnuWeight.Size = New System.Drawing.Size(50, 25)
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLabel6.Image = Global.FormDesigner.My.Resources.Resources.DataType
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(16, 22)
        Me.ToolStripLabel6.Text = "DataType"
        Me.ToolStripLabel6.ToolTipText = "Data Type"
        '
        'mnuDataType
        '
        Me.mnuDataType.Items.AddRange(New Object() {"Text", "Number", "DateTime", "Yes/No"})
        Me.mnuDataType.Name = "mnuDataType"
        Me.mnuDataType.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripPageSelected
        '
        Me.ToolStripPageSelected.Name = "ToolStripPageSelected"
        Me.ToolStripPageSelected.Size = New System.Drawing.Size(100, 25)
        '
        'TsBtn_First
        '
        Me.TsBtn_First.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsBtn_First.Image = Global.FormDesigner.My.Resources.Resources.Navigation_Blue_First
        Me.TsBtn_First.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtn_First.Name = "TsBtn_First"
        Me.TsBtn_First.Size = New System.Drawing.Size(23, 22)
        Me.TsBtn_First.Text = "ToolStripButton8"
        '
        'TsBtn_Previous
        '
        Me.TsBtn_Previous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsBtn_Previous.Image = Global.FormDesigner.My.Resources.Resources.Navigation_Blue_Previous
        Me.TsBtn_Previous.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtn_Previous.Name = "TsBtn_Previous"
        Me.TsBtn_Previous.Size = New System.Drawing.Size(23, 22)
        Me.TsBtn_Previous.Text = "ToolStripButton9"
        '
        'TsBtn_Next
        '
        Me.TsBtn_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsBtn_Next.Image = Global.FormDesigner.My.Resources.Resources.Navigation_Blue_Next
        Me.TsBtn_Next.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtn_Next.Name = "TsBtn_Next"
        Me.TsBtn_Next.Size = New System.Drawing.Size(23, 22)
        Me.TsBtn_Next.Text = "ToolStripButton10"
        '
        'TsBtn_Last
        '
        Me.TsBtn_Last.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsBtn_Last.Image = Global.FormDesigner.My.Resources.Resources.Navigation_Blue_Last
        Me.TsBtn_Last.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtn_Last.Name = "TsBtn_Last"
        Me.TsBtn_Last.Size = New System.Drawing.Size(23, 22)
        Me.TsBtn_Last.Text = "ToolStripButton11"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblSampleFont)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboUserVar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1030, 548)
        Me.SplitContainer1.SplitterDistance = 206
        Me.SplitContainer1.TabIndex = 43
        '
        'lblSampleFont
        '
        Me.lblSampleFont.AutoSize = True
        Me.lblSampleFont.Location = New System.Drawing.Point(36, 230)
        Me.lblSampleFont.Name = "lblSampleFont"
        Me.lblSampleFont.Size = New System.Drawing.Size(134, 13)
        Me.lblSampleFont.TabIndex = 43
        Me.lblSampleFont.Text = "Sample font family and size"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.FormDesigner.My.Resources.Resources.Delete
        Me.Button1.Location = New System.Drawing.Point(87, 256)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 37)
        Me.Button1.TabIndex = 42
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TreeView1.Location = New System.Drawing.Point(0, 16)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(206, 28)
        Me.TreeView1.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 16)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Drag & Drop System Variables"
        '
        'cboUserVar
        '
        Me.cboUserVar.Location = New System.Drawing.Point(0, 16)
        Me.cboUserVar.Name = "cboUserVar"
        Me.cboUserVar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboUserVar.Properties.LookAndFeel.SkinName = "Blue"
        Me.cboUserVar.Properties.LookAndFeel.UseWindowsXPTheme = True
        Me.cboUserVar.Size = New System.Drawing.Size(206, 20)
        Me.cboUserVar.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Form Itmes"
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(821, 523)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(813, 497)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'FormDesignerMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1030, 619)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormDesignerMain"
        Me.Text = "FormDesign"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.cboUserVar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents cboDataType As System.Windows.Forms.ToolStripComboBox
    ' Friend WithEvents cboWtPcntg As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cboColor As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuFonts As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuFontFamily As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents mnuFontSize As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents mnuBtnTxtColor As System.Windows.Forms.ToolStripLabel
    Friend WithEvents mnuTxtColor As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents mnuBtnDefaultValue As System.Windows.Forms.ToolStripLabel
    Friend WithEvents mnuDefaultValue As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents mnuWeight As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents mnuDataType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents SaveToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportBaseDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents TsBtn_First As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsBtn_Previous As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsBtn_Next As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsBtn_Last As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripPageSelected As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsBtn_Color As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents mnuOptionApplySelection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TsAttributeSelection As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ApplyWeightPercentageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TsApplyWtPcnt As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cboUserVar As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblSampleFont As System.Windows.Forms.Label

End Class
