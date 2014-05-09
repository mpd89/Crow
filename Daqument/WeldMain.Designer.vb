<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WeldMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WeldMain))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode
        Me.cms_WeldersList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi_AddWeldersList = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmi_EditWeldersList = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmi_DeleteWeldersList = New System.Windows.Forms.ToolStripMenuItem
        Me.DocumentGridControl = New DevExpress.XtraGrid.GridControl
        Me.DocumentGridView = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.CardView1 = New DevExpress.XtraGrid.Views.Card.CardView
        Me.colCS_SMAW = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colSS_GTAW = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colSS_SMAW = New DevExpress.XtraGrid.Columns.GridColumn
        Me.col__sysCG = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colSS_PLT_SMAW = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colCR_SMAW = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colAux07 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colBlank1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colCR_GTAW = New DevExpress.XtraGrid.Columns.GridColumn
        Me.col__sysMCS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.col__sysIG = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colCraft = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colSSNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colShift = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colINCO_GTAW = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colCS_PLT_SMAW = New DevExpress.XtraGrid.Columns.GridColumn
        Me.col__sysSR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colAux06 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colTiGTAW = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colAux04 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colAux05 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colAux02 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colAux03 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colComments = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colCS_GTAW = New DevExpress.XtraGrid.Columns.GridColumn
        Me.col__sysMC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colCS_PLT_FCAW_BG = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colBlank2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colAux08 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colAux09 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.col__sysP1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colTagNo = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colDOH1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colW_WO_Backing = New DevExpress.XtraGrid.Columns.GridColumn
        Me.col__sysCD = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colAux01 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colDisc = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colDOR1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colrowguid = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colINCO_SMAW = New DevExpress.XtraGrid.Columns.GridColumn
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IImportWeldersListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImportNDEPercentTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImportSpoolListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LookupTablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WPSNDELookupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SpoolListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WeldersListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ForemanNamesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WeldInchesToDiameterConversionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutDaqartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tabWPSProcedures = New System.Windows.Forms.TabControl
        Me.DocumentPage = New System.Windows.Forms.TabPage
        Me.ReportPage = New System.Windows.Forms.TabPage
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmi_PrintPreview = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmi_Print = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveAsNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton
        Me.NDECompleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WeldStencilsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WeldStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DialyNDEReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DailyWeldCountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblReport = New System.Windows.Forms.Label
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnAddNewWPSProcedure = New System.Windows.Forms.Button
        Me.dgv_WPSProcedures = New DevExpress.XtraGrid.GridControl
        Me.cms_EQInches = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi_AddEQInchesLookup = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmi_EditEQInchesLookup = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmi_DeleteEQInchesLookup = New System.Windows.Forms.ToolStripMenuItem
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PrintingSystem2 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.cms_WeldersList.SuspendLayout()
        CType(Me.DocumentGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.tabWPSProcedures.SuspendLayout()
        Me.DocumentPage.SuspendLayout()
        Me.ReportPage.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv_WPSProcedures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_EQInches.SuspendLayout()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PrintingSystem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cms_WeldersList
        '
        Me.cms_WeldersList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_AddWeldersList, Me.tsmi_EditWeldersList, Me.tsmi_DeleteWeldersList})
        Me.cms_WeldersList.Name = "cms_WeldersList"
        Me.cms_WeldersList.Size = New System.Drawing.Size(117, 70)
        '
        'tsmi_AddWeldersList
        '
        Me.tsmi_AddWeldersList.Name = "tsmi_AddWeldersList"
        Me.tsmi_AddWeldersList.Size = New System.Drawing.Size(116, 22)
        Me.tsmi_AddWeldersList.Text = "Add"
        '
        'tsmi_EditWeldersList
        '
        Me.tsmi_EditWeldersList.Name = "tsmi_EditWeldersList"
        Me.tsmi_EditWeldersList.Size = New System.Drawing.Size(116, 22)
        Me.tsmi_EditWeldersList.Text = "Edit"
        '
        'tsmi_DeleteWeldersList
        '
        Me.tsmi_DeleteWeldersList.Name = "tsmi_DeleteWeldersList"
        Me.tsmi_DeleteWeldersList.Size = New System.Drawing.Size(116, 22)
        Me.tsmi_DeleteWeldersList.Text = "Delete"
        '
        'DocumentGridControl
        '
        Me.DocumentGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentGridControl.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.DocumentGridControl.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.DocumentGridControl.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.DocumentGridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.DocumentGridControl.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.DocumentGridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.DocumentGridControl.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.DocumentGridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.DocumentGridControl.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.DocumentGridControl.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.DocumentGridControl.EmbeddedNavigator.Name = ""
        Me.DocumentGridControl.Location = New System.Drawing.Point(3, 3)
        Me.DocumentGridControl.LookAndFeel.SkinName = "Blue"
        Me.DocumentGridControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.DocumentGridControl.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DocumentGridControl.MainView = Me.DocumentGridView
        Me.DocumentGridControl.Name = "DocumentGridControl"
        Me.DocumentGridControl.Size = New System.Drawing.Size(896, 583)
        Me.DocumentGridControl.TabIndex = 4
        Me.DocumentGridControl.UseEmbeddedNavigator = True
        Me.DocumentGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DocumentGridView, Me.CardView1})
        '
        'DocumentGridView
        '
        Me.DocumentGridView.GridControl = Me.DocumentGridControl
        Me.DocumentGridView.Name = "DocumentGridView"
        Me.DocumentGridView.OptionsBehavior.Editable = False
        Me.DocumentGridView.OptionsPrint.PrintDetails = True
        Me.DocumentGridView.OptionsPrint.PrintFilterInfo = True
        Me.DocumentGridView.OptionsPrint.PrintPreview = True
        Me.DocumentGridView.OptionsPrint.UsePrintStyles = True
        Me.DocumentGridView.OptionsSelection.MultiSelect = True
        Me.DocumentGridView.OptionsView.ColumnAutoWidth = False
        Me.DocumentGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        '
        'CardView1
        '
        Me.CardView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCS_SMAW, Me.colSS_GTAW, Me.colSS_SMAW, Me.col__sysCG, Me.colSS_PLT_SMAW, Me.colCR_SMAW, Me.colAux07, Me.colBlank1, Me.colCR_GTAW, Me.col__sysMCS, Me.col__sysIG, Me.colCraft, Me.colSSNo, Me.colShift, Me.colINCO_GTAW, Me.colCS_PLT_SMAW, Me.col__sysSR, Me.colAux06, Me.colTiGTAW, Me.colAux04, Me.colAux05, Me.colAux02, Me.colAux03, Me.colComments, Me.colCS_GTAW, Me.col__sysMC, Me.colCS_PLT_FCAW_BG, Me.colBlank2, Me.colAux08, Me.colAux09, Me.col__sysP1, Me.colTagNo, Me.colDOH1, Me.colW_WO_Backing, Me.col__sysCD, Me.colAux01, Me.colID, Me.colDisc, Me.colDOR1, Me.colrowguid, Me.colName, Me.colINCO_SMAW})
        Me.CardView1.FocusedCardTopFieldIndex = 0
        Me.CardView1.GridControl = Me.DocumentGridControl
        Me.CardView1.Name = "CardView1"
        Me.CardView1.OptionsBehavior.Editable = False
        Me.CardView1.OptionsSelection.MultiSelect = True
        Me.CardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        '
        'colCS_SMAW
        '
        Me.colCS_SMAW.Caption = "CS_SMAW"
        Me.colCS_SMAW.FieldName = "CS_SMAW"
        Me.colCS_SMAW.Name = "colCS_SMAW"
        Me.colCS_SMAW.Visible = True
        Me.colCS_SMAW.VisibleIndex = 0
        '
        'colSS_GTAW
        '
        Me.colSS_GTAW.Caption = "SS_GTAW"
        Me.colSS_GTAW.FieldName = "SS_GTAW"
        Me.colSS_GTAW.Name = "colSS_GTAW"
        Me.colSS_GTAW.Visible = True
        Me.colSS_GTAW.VisibleIndex = 1
        '
        'colSS_SMAW
        '
        Me.colSS_SMAW.Caption = "SS_SMAW"
        Me.colSS_SMAW.FieldName = "SS_SMAW"
        Me.colSS_SMAW.Name = "colSS_SMAW"
        Me.colSS_SMAW.Visible = True
        Me.colSS_SMAW.VisibleIndex = 2
        '
        'col__sysCG
        '
        Me.col__sysCG.Caption = "__sysCG"
        Me.col__sysCG.FieldName = "__sysCG"
        Me.col__sysCG.Name = "col__sysCG"
        Me.col__sysCG.Visible = True
        Me.col__sysCG.VisibleIndex = 3
        '
        'colSS_PLT_SMAW
        '
        Me.colSS_PLT_SMAW.Caption = "SS_PLT_SMAW"
        Me.colSS_PLT_SMAW.FieldName = "SS_PLT_SMAW"
        Me.colSS_PLT_SMAW.Name = "colSS_PLT_SMAW"
        Me.colSS_PLT_SMAW.Visible = True
        Me.colSS_PLT_SMAW.VisibleIndex = 4
        '
        'colCR_SMAW
        '
        Me.colCR_SMAW.Caption = "CR_SMAW"
        Me.colCR_SMAW.FieldName = "CR_SMAW"
        Me.colCR_SMAW.Name = "colCR_SMAW"
        Me.colCR_SMAW.Visible = True
        Me.colCR_SMAW.VisibleIndex = 5
        '
        'colAux07
        '
        Me.colAux07.Caption = "Aux07"
        Me.colAux07.FieldName = "Aux07"
        Me.colAux07.Name = "colAux07"
        Me.colAux07.Visible = True
        Me.colAux07.VisibleIndex = 6
        '
        'colBlank1
        '
        Me.colBlank1.Caption = "Blank1"
        Me.colBlank1.FieldName = "Blank1"
        Me.colBlank1.Name = "colBlank1"
        Me.colBlank1.Visible = True
        Me.colBlank1.VisibleIndex = 7
        '
        'colCR_GTAW
        '
        Me.colCR_GTAW.Caption = "CR_GTAW"
        Me.colCR_GTAW.FieldName = "CR_GTAW"
        Me.colCR_GTAW.Name = "colCR_GTAW"
        Me.colCR_GTAW.Visible = True
        Me.colCR_GTAW.VisibleIndex = 8
        '
        'col__sysMCS
        '
        Me.col__sysMCS.Caption = "__sysMCS"
        Me.col__sysMCS.FieldName = "__sysMCS"
        Me.col__sysMCS.Name = "col__sysMCS"
        Me.col__sysMCS.Visible = True
        Me.col__sysMCS.VisibleIndex = 9
        '
        'col__sysIG
        '
        Me.col__sysIG.Caption = "__sysIG"
        Me.col__sysIG.FieldName = "__sysIG"
        Me.col__sysIG.Name = "col__sysIG"
        Me.col__sysIG.Visible = True
        Me.col__sysIG.VisibleIndex = 10
        '
        'colCraft
        '
        Me.colCraft.Caption = "Craft"
        Me.colCraft.FieldName = "Craft"
        Me.colCraft.Name = "colCraft"
        Me.colCraft.Visible = True
        Me.colCraft.VisibleIndex = 11
        '
        'colSSNo
        '
        Me.colSSNo.Caption = "SSNo"
        Me.colSSNo.FieldName = "SSNo"
        Me.colSSNo.Name = "colSSNo"
        Me.colSSNo.Visible = True
        Me.colSSNo.VisibleIndex = 12
        '
        'colShift
        '
        Me.colShift.Caption = "Shift"
        Me.colShift.FieldName = "Shift"
        Me.colShift.Name = "colShift"
        Me.colShift.Visible = True
        Me.colShift.VisibleIndex = 13
        '
        'colINCO_GTAW
        '
        Me.colINCO_GTAW.Caption = "INCO_GTAW"
        Me.colINCO_GTAW.FieldName = "INCO_GTAW"
        Me.colINCO_GTAW.Name = "colINCO_GTAW"
        Me.colINCO_GTAW.Visible = True
        Me.colINCO_GTAW.VisibleIndex = 14
        '
        'colCS_PLT_SMAW
        '
        Me.colCS_PLT_SMAW.Caption = "CS_PLT_SMAW"
        Me.colCS_PLT_SMAW.FieldName = "CS_PLT_SMAW"
        Me.colCS_PLT_SMAW.Name = "colCS_PLT_SMAW"
        Me.colCS_PLT_SMAW.Visible = True
        Me.colCS_PLT_SMAW.VisibleIndex = 15
        '
        'col__sysSR
        '
        Me.col__sysSR.Caption = "__sysSR"
        Me.col__sysSR.FieldName = "__sysSR"
        Me.col__sysSR.Name = "col__sysSR"
        Me.col__sysSR.Visible = True
        Me.col__sysSR.VisibleIndex = 16
        '
        'colAux06
        '
        Me.colAux06.Caption = "Aux06"
        Me.colAux06.FieldName = "Aux06"
        Me.colAux06.Name = "colAux06"
        Me.colAux06.Visible = True
        Me.colAux06.VisibleIndex = 17
        '
        'colTiGTAW
        '
        Me.colTiGTAW.Caption = "TiGTAW"
        Me.colTiGTAW.FieldName = "TiGTAW"
        Me.colTiGTAW.Name = "colTiGTAW"
        Me.colTiGTAW.Visible = True
        Me.colTiGTAW.VisibleIndex = 18
        '
        'colAux04
        '
        Me.colAux04.Caption = "Aux04"
        Me.colAux04.FieldName = "Aux04"
        Me.colAux04.Name = "colAux04"
        Me.colAux04.Visible = True
        Me.colAux04.VisibleIndex = 19
        '
        'colAux05
        '
        Me.colAux05.Caption = "Aux05"
        Me.colAux05.FieldName = "Aux05"
        Me.colAux05.Name = "colAux05"
        Me.colAux05.Visible = True
        Me.colAux05.VisibleIndex = 20
        '
        'colAux02
        '
        Me.colAux02.Caption = "Aux02"
        Me.colAux02.FieldName = "Aux02"
        Me.colAux02.Name = "colAux02"
        Me.colAux02.Visible = True
        Me.colAux02.VisibleIndex = 21
        '
        'colAux03
        '
        Me.colAux03.Caption = "Aux03"
        Me.colAux03.FieldName = "Aux03"
        Me.colAux03.Name = "colAux03"
        Me.colAux03.Visible = True
        Me.colAux03.VisibleIndex = 22
        '
        'colComments
        '
        Me.colComments.Caption = "Comments"
        Me.colComments.FieldName = "Comments"
        Me.colComments.Name = "colComments"
        Me.colComments.Visible = True
        Me.colComments.VisibleIndex = 23
        '
        'colCS_GTAW
        '
        Me.colCS_GTAW.Caption = "CS_GTAW"
        Me.colCS_GTAW.FieldName = "CS_GTAW"
        Me.colCS_GTAW.Name = "colCS_GTAW"
        Me.colCS_GTAW.Visible = True
        Me.colCS_GTAW.VisibleIndex = 24
        '
        'col__sysMC
        '
        Me.col__sysMC.Caption = "__sysMC"
        Me.col__sysMC.FieldName = "__sysMC"
        Me.col__sysMC.Name = "col__sysMC"
        Me.col__sysMC.Visible = True
        Me.col__sysMC.VisibleIndex = 25
        '
        'colCS_PLT_FCAW_BG
        '
        Me.colCS_PLT_FCAW_BG.Caption = "CS_PLT_FCAW_BG"
        Me.colCS_PLT_FCAW_BG.FieldName = "CS_PLT_FCAW_BG"
        Me.colCS_PLT_FCAW_BG.Name = "colCS_PLT_FCAW_BG"
        Me.colCS_PLT_FCAW_BG.Visible = True
        Me.colCS_PLT_FCAW_BG.VisibleIndex = 26
        '
        'colBlank2
        '
        Me.colBlank2.Caption = "Blank2"
        Me.colBlank2.FieldName = "Blank2"
        Me.colBlank2.Name = "colBlank2"
        Me.colBlank2.Visible = True
        Me.colBlank2.VisibleIndex = 27
        '
        'colAux08
        '
        Me.colAux08.Caption = "Aux08"
        Me.colAux08.FieldName = "Aux08"
        Me.colAux08.Name = "colAux08"
        Me.colAux08.Visible = True
        Me.colAux08.VisibleIndex = 28
        '
        'colAux09
        '
        Me.colAux09.Caption = "Aux09"
        Me.colAux09.FieldName = "Aux09"
        Me.colAux09.Name = "colAux09"
        Me.colAux09.Visible = True
        Me.colAux09.VisibleIndex = 29
        '
        'col__sysP1
        '
        Me.col__sysP1.Caption = "__sysP1"
        Me.col__sysP1.FieldName = "__sysP1"
        Me.col__sysP1.Name = "col__sysP1"
        Me.col__sysP1.Visible = True
        Me.col__sysP1.VisibleIndex = 30
        '
        'colTagNo
        '
        Me.colTagNo.Caption = "TagNo"
        Me.colTagNo.FieldName = "TagNo"
        Me.colTagNo.Name = "colTagNo"
        Me.colTagNo.Visible = True
        Me.colTagNo.VisibleIndex = 31
        '
        'colDOH1
        '
        Me.colDOH1.Caption = "DOH1"
        Me.colDOH1.FieldName = "DOH1"
        Me.colDOH1.Name = "colDOH1"
        Me.colDOH1.Visible = True
        Me.colDOH1.VisibleIndex = 32
        '
        'colW_WO_Backing
        '
        Me.colW_WO_Backing.Caption = "W_WO_Backing"
        Me.colW_WO_Backing.FieldName = "W_WO_Backing"
        Me.colW_WO_Backing.Name = "colW_WO_Backing"
        Me.colW_WO_Backing.Visible = True
        Me.colW_WO_Backing.VisibleIndex = 33
        '
        'col__sysCD
        '
        Me.col__sysCD.Caption = "__sysCD"
        Me.col__sysCD.FieldName = "__sysCD"
        Me.col__sysCD.Name = "col__sysCD"
        Me.col__sysCD.Visible = True
        Me.col__sysCD.VisibleIndex = 34
        '
        'colAux01
        '
        Me.colAux01.Caption = "Aux01"
        Me.colAux01.FieldName = "Aux01"
        Me.colAux01.Name = "colAux01"
        Me.colAux01.Visible = True
        Me.colAux01.VisibleIndex = 35
        '
        'colID
        '
        Me.colID.Caption = "ID"
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 36
        '
        'colDisc
        '
        Me.colDisc.Caption = "Disc"
        Me.colDisc.FieldName = "Disc"
        Me.colDisc.Name = "colDisc"
        Me.colDisc.Visible = True
        Me.colDisc.VisibleIndex = 37
        '
        'colDOR1
        '
        Me.colDOR1.Caption = "DOR1"
        Me.colDOR1.FieldName = "DOR1"
        Me.colDOR1.Name = "colDOR1"
        Me.colDOR1.Visible = True
        Me.colDOR1.VisibleIndex = 38
        '
        'colrowguid
        '
        Me.colrowguid.Caption = "rowguid"
        Me.colrowguid.FieldName = "rowguid"
        Me.colrowguid.Name = "colrowguid"
        Me.colrowguid.Visible = True
        Me.colrowguid.VisibleIndex = 39
        '
        'colName
        '
        Me.colName.Caption = "Name"
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 40
        '
        'colINCO_SMAW
        '
        Me.colINCO_SMAW.Caption = "INCO_SMAW"
        Me.colINCO_SMAW.FieldName = "INCO_SMAW"
        Me.colINCO_SMAW.Name = "colINCO_SMAW"
        Me.colINCO_SMAW.Visible = True
        Me.colINCO_SMAW.VisibleIndex = 41
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(910, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(603, 17)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "Selected Document Description goes here."
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(88, 17)
        Me.ToolStripStatusLabel1.Text = "Category: None"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(102, 17)
        Me.ToolStripStatusLabel2.Text = "Document 1 of 109"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ImportsToolStripMenuItem, Me.LookupTablesToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(910, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.FileToolStripMenuItem.Text = "Forms"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ImportsToolStripMenuItem
        '
        Me.ImportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IImportWeldersListToolStripMenuItem, Me.ImportNDEPercentTableToolStripMenuItem, Me.ImportSpoolListToolStripMenuItem, Me.ImportToolStripMenuItem})
        Me.ImportsToolStripMenuItem.Name = "ImportsToolStripMenuItem"
        Me.ImportsToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.ImportsToolStripMenuItem.Text = "Imports"
        '
        'IImportWeldersListToolStripMenuItem
        '
        Me.IImportWeldersListToolStripMenuItem.Name = "IImportWeldersListToolStripMenuItem"
        Me.IImportWeldersListToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.IImportWeldersListToolStripMenuItem.Text = "Import Welders List"
        '
        'ImportNDEPercentTableToolStripMenuItem
        '
        Me.ImportNDEPercentTableToolStripMenuItem.Name = "ImportNDEPercentTableToolStripMenuItem"
        Me.ImportNDEPercentTableToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.ImportNDEPercentTableToolStripMenuItem.Text = "Import WPS/NDE % Table"
        '
        'ImportSpoolListToolStripMenuItem
        '
        Me.ImportSpoolListToolStripMenuItem.Name = "ImportSpoolListToolStripMenuItem"
        Me.ImportSpoolListToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.ImportSpoolListToolStripMenuItem.Text = "Import Spool List"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.ImportToolStripMenuItem.Text = "Import  Pipe Inches/Diameter Conversion Table"
        '
        'LookupTablesToolStripMenuItem
        '
        Me.LookupTablesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WPSNDELookupToolStripMenuItem, Me.SpoolListToolStripMenuItem, Me.WeldersListToolStripMenuItem, Me.ForemanNamesToolStripMenuItem, Me.WeldInchesToDiameterConversionToolStripMenuItem})
        Me.LookupTablesToolStripMenuItem.Name = "LookupTablesToolStripMenuItem"
        Me.LookupTablesToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.LookupTablesToolStripMenuItem.Text = "Lookup Tables"
        '
        'WPSNDELookupToolStripMenuItem
        '
        Me.WPSNDELookupToolStripMenuItem.Name = "WPSNDELookupToolStripMenuItem"
        Me.WPSNDELookupToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.WPSNDELookupToolStripMenuItem.Text = "WPS/NDE % lookup"
        '
        'SpoolListToolStripMenuItem
        '
        Me.SpoolListToolStripMenuItem.Name = "SpoolListToolStripMenuItem"
        Me.SpoolListToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.SpoolListToolStripMenuItem.Text = "Spool List"
        '
        'WeldersListToolStripMenuItem
        '
        Me.WeldersListToolStripMenuItem.Name = "WeldersListToolStripMenuItem"
        Me.WeldersListToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.WeldersListToolStripMenuItem.Text = "Welders List"
        '
        'ForemanNamesToolStripMenuItem
        '
        Me.ForemanNamesToolStripMenuItem.Name = "ForemanNamesToolStripMenuItem"
        Me.ForemanNamesToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.ForemanNamesToolStripMenuItem.Text = "Foreman Names"
        '
        'WeldInchesToDiameterConversionToolStripMenuItem
        '
        Me.WeldInchesToDiameterConversionToolStripMenuItem.Name = "WeldInchesToDiameterConversionToolStripMenuItem"
        Me.WeldInchesToDiameterConversionToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.WeldInchesToDiameterConversionToolStripMenuItem.Text = "Weld Inches to Diameter Conversion"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpManualToolStripMenuItem, Me.AboutDaqartToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpManualToolStripMenuItem
        '
        Me.HelpManualToolStripMenuItem.Name = "HelpManualToolStripMenuItem"
        Me.HelpManualToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.HelpManualToolStripMenuItem.Text = "Help Manual"
        '
        'AboutDaqartToolStripMenuItem
        '
        Me.AboutDaqartToolStripMenuItem.Name = "AboutDaqartToolStripMenuItem"
        Me.AboutDaqartToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.AboutDaqartToolStripMenuItem.Text = "About Daqart"
        '
        'tabWPSProcedures
        '
        Me.tabWPSProcedures.Controls.Add(Me.DocumentPage)
        Me.tabWPSProcedures.Controls.Add(Me.ReportPage)
        Me.tabWPSProcedures.Controls.Add(Me.TabPage1)
        Me.tabWPSProcedures.Controls.Add(Me.TabPage2)
        Me.tabWPSProcedures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabWPSProcedures.Location = New System.Drawing.Point(0, 0)
        Me.tabWPSProcedures.Name = "tabWPSProcedures"
        Me.tabWPSProcedures.SelectedIndex = 0
        Me.tabWPSProcedures.Size = New System.Drawing.Size(910, 615)
        Me.tabWPSProcedures.TabIndex = 8
        '
        'DocumentPage
        '
        Me.DocumentPage.Controls.Add(Me.DocumentGridControl)
        Me.DocumentPage.Location = New System.Drawing.Point(4, 22)
        Me.DocumentPage.Name = "DocumentPage"
        Me.DocumentPage.Padding = New System.Windows.Forms.Padding(3)
        Me.DocumentPage.Size = New System.Drawing.Size(902, 589)
        Me.DocumentPage.TabIndex = 0
        Me.DocumentPage.Text = "Weld Tracking"
        Me.DocumentPage.UseVisualStyleBackColor = True
        '
        'ReportPage
        '
        Me.ReportPage.Controls.Add(Me.SplitContainer1)
        Me.ReportPage.Location = New System.Drawing.Point(4, 22)
        Me.ReportPage.Name = "ReportPage"
        Me.ReportPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ReportPage.Size = New System.Drawing.Size(902, 589)
        Me.ReportPage.TabIndex = 4
        Me.ReportPage.Text = "Reports"
        Me.ReportPage.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton2, Me.ToolStripDropDownButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(896, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_PrintPreview, Me.tsmi_Print})
        Me.ToolStripDropDownButton1.Image = Global.Daqument.My.Resources.Resources.Printer
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.ToolTipText = "Print"
        '
        'tsmi_PrintPreview
        '
        Me.tsmi_PrintPreview.Name = "tsmi_PrintPreview"
        Me.tsmi_PrintPreview.Size = New System.Drawing.Size(148, 22)
        Me.tsmi_PrintPreview.Text = "Print Preview"
        '
        'tsmi_Print
        '
        Me.tsmi_Print.Name = "tsmi_Print"
        Me.tsmi_Print.Size = New System.Drawing.Size(148, 22)
        Me.tsmi_Print.Text = "Print"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsNewToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(94, 22)
        Me.ToolStripDropDownButton2.Text = "CustomReports"
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsNewToolStripMenuItem
        '
        Me.SaveAsNewToolStripMenuItem.Name = "SaveAsNewToolStripMenuItem"
        Me.SaveAsNewToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.SaveAsNewToolStripMenuItem.Text = "Save As New"
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NDECompleteToolStripMenuItem, Me.WeldStencilsToolStripMenuItem, Me.WeldStatusToolStripMenuItem, Me.DialyNDEReportToolStripMenuItem, Me.DailyWeldCountsToolStripMenuItem})
        Me.ToolStripDropDownButton3.Image = CType(resources.GetObject("ToolStripDropDownButton3.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripDropDownButton3.Text = "Reports"
        '
        'NDECompleteToolStripMenuItem
        '
        Me.NDECompleteToolStripMenuItem.Name = "NDECompleteToolStripMenuItem"
        Me.NDECompleteToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.NDECompleteToolStripMenuItem.Text = "NDE % Complete"
        '
        'WeldStencilsToolStripMenuItem
        '
        Me.WeldStencilsToolStripMenuItem.Name = "WeldStencilsToolStripMenuItem"
        Me.WeldStencilsToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.WeldStencilsToolStripMenuItem.Text = "Weld Stencils"
        '
        'WeldStatusToolStripMenuItem
        '
        Me.WeldStatusToolStripMenuItem.Name = "WeldStatusToolStripMenuItem"
        Me.WeldStatusToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.WeldStatusToolStripMenuItem.Text = "Weld Status"
        '
        'DialyNDEReportToolStripMenuItem
        '
        Me.DialyNDEReportToolStripMenuItem.Name = "DialyNDEReportToolStripMenuItem"
        Me.DialyNDEReportToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.DialyNDEReportToolStripMenuItem.Text = "Dialy NDE Report"
        '
        'DailyWeldCountsToolStripMenuItem
        '
        Me.DailyWeldCountsToolStripMenuItem.Name = "DailyWeldCountsToolStripMenuItem"
        Me.DailyWeldCountsToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.DailyWeldCountsToolStripMenuItem.Text = "Daily Weld Count"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblReport)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(896, 583)
        Me.SplitContainer1.SplitterDistance = 73
        Me.SplitContainer1.TabIndex = 4
        '
        'lblReport
        '
        Me.lblReport.AutoSize = True
        Me.lblReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReport.Location = New System.Drawing.Point(80, 36)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(77, 25)
        Me.lblReport.TabIndex = 10
        Me.lblReport.Text = "Label1"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.EmbeddedNavigator.Name = ""
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(896, 506)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnAddNewWPSProcedure)
        Me.TabPage1.Controls.Add(Me.dgv_WPSProcedures)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(902, 589)
        Me.TabPage1.TabIndex = 7
        Me.TabPage1.Text = "WPS Procedures"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnAddNewWPSProcedure
        '
        Me.btnAddNewWPSProcedure.Location = New System.Drawing.Point(477, 6)
        Me.btnAddNewWPSProcedure.Name = "btnAddNewWPSProcedure"
        Me.btnAddNewWPSProcedure.Size = New System.Drawing.Size(143, 23)
        Me.btnAddNewWPSProcedure.TabIndex = 6
        Me.btnAddNewWPSProcedure.Text = "Add New WPS Procedure"
        Me.btnAddNewWPSProcedure.UseVisualStyleBackColor = True
        '
        'dgv_WPSProcedures
        '
        Me.dgv_WPSProcedures.ContextMenuStrip = Me.cms_EQInches
        Me.dgv_WPSProcedures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_WPSProcedures.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.dgv_WPSProcedures.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.dgv_WPSProcedures.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.dgv_WPSProcedures.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.dgv_WPSProcedures.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.dgv_WPSProcedures.EmbeddedNavigator.Name = ""
        Me.dgv_WPSProcedures.Location = New System.Drawing.Point(3, 3)
        Me.dgv_WPSProcedures.LookAndFeel.SkinName = "Blue"
        Me.dgv_WPSProcedures.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.dgv_WPSProcedures.LookAndFeel.UseDefaultLookAndFeel = False
        Me.dgv_WPSProcedures.MainView = Me.GridView6
        Me.dgv_WPSProcedures.Name = "dgv_WPSProcedures"
        Me.dgv_WPSProcedures.Size = New System.Drawing.Size(896, 583)
        Me.dgv_WPSProcedures.TabIndex = 1
        Me.dgv_WPSProcedures.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView6})
        '
        'cms_EQInches
        '
        Me.cms_EQInches.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_AddEQInchesLookup, Me.tsmi_EditEQInchesLookup, Me.tsmi_DeleteEQInchesLookup})
        Me.cms_EQInches.Name = "cms_EQInches"
        Me.cms_EQInches.Size = New System.Drawing.Size(117, 70)
        '
        'tsmi_AddEQInchesLookup
        '
        Me.tsmi_AddEQInchesLookup.Name = "tsmi_AddEQInchesLookup"
        Me.tsmi_AddEQInchesLookup.Size = New System.Drawing.Size(116, 22)
        Me.tsmi_AddEQInchesLookup.Text = "Add"
        '
        'tsmi_EditEQInchesLookup
        '
        Me.tsmi_EditEQInchesLookup.Name = "tsmi_EditEQInchesLookup"
        Me.tsmi_EditEQInchesLookup.Size = New System.Drawing.Size(116, 22)
        Me.tsmi_EditEQInchesLookup.Text = "Edit"
        '
        'tsmi_DeleteEQInchesLookup
        '
        Me.tsmi_DeleteEQInchesLookup.Name = "tsmi_DeleteEQInchesLookup"
        Me.tsmi_DeleteEQInchesLookup.Size = New System.Drawing.Size(116, 22)
        Me.tsmi_DeleteEQInchesLookup.Text = "Delete"
        '
        'GridView6
        '
        Me.GridView6.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GridView6.Appearance.GroupRow.Options.UseFont = True
        Me.GridView6.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView6.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridView6.AppearancePrint.EvenRow.Options.UseBackColor = True
        Me.GridView6.GridControl = Me.dgv_WPSProcedures
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsBehavior.Editable = False
        Me.GridView6.OptionsPrint.EnableAppearanceEvenRow = True
        Me.GridView6.OptionsPrint.PrintPreview = True
        Me.GridView6.OptionsPrint.UsePrintStyles = True
        Me.GridView6.OptionsView.ColumnAutoWidth = False
        Me.GridView6.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView6.OptionsView.ShowGroupedColumns = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(902, 589)
        Me.TabPage2.TabIndex = 8
        Me.TabPage2.Text = "Weld Listings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnUpdate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnCancel)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GridControl2)
        Me.SplitContainer2.Size = New System.Drawing.Size(896, 583)
        Me.SplitContainer2.SplitterDistance = 92
        Me.SplitContainer2.TabIndex = 0
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(249, 22)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(360, 22)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.EmbeddedNavigator.Name = ""
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(896, 487)
        Me.GridControl2.TabIndex = 0
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        '
        'GridBand4
        '
        Me.GridBand4.Caption = "Name"
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.Width = 210
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tabWPSProcedures)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 24)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(910, 615)
        Me.Panel2.TabIndex = 10
        '
        'WeldMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 661)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WeldMain"
        Me.Text = "Weld Tracking"
        Me.cms_WeldersList.ResumeLayout(False)
        CType(Me.DocumentGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocumentGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tabWPSProcedures.ResumeLayout(False)
        Me.DocumentPage.ResumeLayout(False)
        Me.ReportPage.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgv_WPSProcedures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_EQInches.ResumeLayout(False)
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PrintingSystem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DocumentGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutDaqartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabWPSProcedures As System.Windows.Forms.TabControl
    Friend WithEvents DocumentPage As System.Windows.Forms.TabPage
    Friend WithEvents ReportPage As System.Windows.Forms.TabPage
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents CardView1 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents colCS_SMAW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSS_GTAW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSS_SMAW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents col__sysCG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSS_PLT_SMAW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCR_SMAW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAux07 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBlank1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCR_GTAW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents col__sysMCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents col__sysIG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCraft As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSSNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colShift As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINCO_GTAW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCS_PLT_SMAW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents col__sysSR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAux06 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTiGTAW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAux04 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAux05 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAux02 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAux03 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComments As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCS_GTAW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents col__sysMC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCS_PLT_FCAW_BG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBlank2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAux08 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAux09 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents col__sysP1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTagNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOH1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colW_WO_Backing As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents col__sysCD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAux01 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDisc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOR1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colrowguid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINCO_SMAW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmi_PrintPreview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_Print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cms_EQInches As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmi_AddEQInchesLookup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_EditEQInchesLookup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_DeleteEQInchesLookup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cms_WeldersList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmi_AddWeldersList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_EditWeldersList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_DeleteWeldersList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_WPSProcedures As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnAddNewWPSProcedure As System.Windows.Forms.Button
    Friend WithEvents PrintingSystem2 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents ImportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IImportWeldersListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportNDEPercentTableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportSpoolListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LookupTablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WPSNDELookupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpoolListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WeldersListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForemanNamesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WeldInchesToDiameterConversionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownButton3 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents lblReport As System.Windows.Forms.Label
    Friend WithEvents SelectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NDECompleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WeldStencilsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WeldStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DialyNDEReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailyWeldCountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
