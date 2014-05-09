<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DaqumentMain
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DaqumentMain))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CategoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsvCategory = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.TSBRefresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.tbx_Search = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.cbx_SearchField = New System.Windows.Forms.ToolStripComboBox
        Me.btn_Search = New System.Windows.Forms.ToolStripButton
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.trvCategory = New System.Windows.Forms.TreeView
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewAssociationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TSMEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsl_SiteLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProjectStatusInd = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BackgroundRepairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SymbolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MarkupDrawingsListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.PropertiesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(128, 70)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CategoryToolStripMenuItem, Me.DocumentToolStripMenuItem})
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'CategoryToolStripMenuItem
        '
        Me.CategoryToolStripMenuItem.Name = "CategoryToolStripMenuItem"
        Me.CategoryToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.CategoryToolStripMenuItem.Text = "Category"
        '
        'DocumentToolStripMenuItem
        '
        Me.DocumentToolStripMenuItem.Name = "DocumentToolStripMenuItem"
        Me.DocumentToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.DocumentToolStripMenuItem.Text = "Document"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.PropertiesToolStripMenuItem.Text = "Properties"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsvCategory, Me.ToolStripButton1, Me.TSBRefresh, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.tbx_Search, Me.ToolStripLabel2, Me.cbx_SearchField, Me.btn_Search})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(750, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsvCategory
        '
        Me.tsvCategory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsvCategory.Image = Global.Daqument.My.Resources.Resources.Black_List_Add
        Me.tsvCategory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsvCategory.Name = "tsvCategory"
        Me.tsvCategory.Size = New System.Drawing.Size(23, 22)
        Me.tsvCategory.Text = "Add Main Category"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Daqument.My.Resources.Resources.Documents_Add
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Add Document"
        '
        'TSBRefresh
        '
        Me.TSBRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSBRefresh.Image = Global.Daqument.My.Resources.Resources.Document_Reload1
        Me.TSBRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBRefresh.Name = "TSBRefresh"
        Me.TSBRefresh.Size = New System.Drawing.Size(23, 22)
        Me.TSBRefresh.Text = "Refresh"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel1.Text = "Search for:"
        '
        'tbx_Search
        '
        Me.tbx_Search.Name = "tbx_Search"
        Me.tbx_Search.Size = New System.Drawing.Size(150, 25)
        Me.tbx_Search.ToolTipText = "Drawing Number Search"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(17, 22)
        Me.ToolStripLabel2.Text = "in"
        '
        'cbx_SearchField
        '
        Me.cbx_SearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_SearchField.Items.AddRange(New Object() {"Engineering Code", "Client Code", "Document Title"})
        Me.cbx_SearchField.Name = "cbx_SearchField"
        Me.cbx_SearchField.Size = New System.Drawing.Size(121, 25)
        '
        'btn_Search
        '
        Me.btn_Search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Search.Image = Global.Daqument.My.Resources.Resources.Find
        Me.btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(23, 22)
        Me.btn_Search.Text = "ToolStripButton2"
        Me.btn_Search.ToolTipText = "Search"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.trvCategory)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(750, 465)
        Me.SplitContainer1.SplitterDistance = 193
        Me.SplitContainer1.TabIndex = 3
        '
        'trvCategory
        '
        Me.trvCategory.ContextMenuStrip = Me.ContextMenuStrip1
        Me.trvCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvCategory.Location = New System.Drawing.Point(0, 0)
        Me.trvCategory.Name = "trvCategory"
        Me.trvCategory.Size = New System.Drawing.Size(193, 465)
        Me.trvCategory.TabIndex = 4
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.LookAndFeel.SkinName = "Blue"
        Me.GridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(553, 465)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewAssociationsToolStripMenuItem, Me.ToolStripSeparator2, Me.TSMEdit, Me.TSMDelete})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(169, 76)
        '
        'ViewAssociationsToolStripMenuItem
        '
        Me.ViewAssociationsToolStripMenuItem.Name = "ViewAssociationsToolStripMenuItem"
        Me.ViewAssociationsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ViewAssociationsToolStripMenuItem.Text = "View Associations"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(165, 6)
        '
        'TSMEdit
        '
        Me.TSMEdit.Name = "TSMEdit"
        Me.TSMEdit.Size = New System.Drawing.Size(168, 22)
        Me.TSMEdit.Text = "Edit"
        '
        'TSMDelete
        '
        Me.TSMDelete.Name = "TSMDelete"
        Me.TSMDelete.Size = New System.Drawing.Size(168, 22)
        Me.TSMDelete.Text = "Delete"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.tsl_SiteLabel, Me.ProjectStatusInd})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 514)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(750, 24)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(289, 19)
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
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(94, 19)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(111, 19)
        Me.ToolStripStatusLabel2.Text = "Document 1 of 109"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(750, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem, Me.ImportToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(107, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackgroundRepairToolStripMenuItem, Me.SymbolsToolStripMenuItem, Me.MarkupDrawingsListToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'BackgroundRepairToolStripMenuItem
        '
        Me.BackgroundRepairToolStripMenuItem.Name = "BackgroundRepairToolStripMenuItem"
        Me.BackgroundRepairToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.BackgroundRepairToolStripMenuItem.Text = "Background Repair"
        Me.BackgroundRepairToolStripMenuItem.Visible = False
        '
        'SymbolsToolStripMenuItem
        '
        Me.SymbolsToolStripMenuItem.Name = "SymbolsToolStripMenuItem"
        Me.SymbolsToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.SymbolsToolStripMenuItem.Text = "Symbols"
        '
        'MarkupDrawingsListToolStripMenuItem
        '
        Me.MarkupDrawingsListToolStripMenuItem.Name = "MarkupDrawingsListToolStripMenuItem"
        Me.MarkupDrawingsListToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.MarkupDrawingsListToolStripMenuItem.Text = "Manage Markups"
        '
        'DaqumentMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 538)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "DaqumentMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Daqument"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsvCategory As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CategoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSBRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents trvCategory As System.Windows.Forms.TreeView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsl_SiteLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProjectStatusInd As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundRepairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewAssociationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbx_Search As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btn_Search As System.Windows.Forms.ToolStripButton
    Friend WithEvents SymbolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cbx_SearchField As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents MarkupDrawingsListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
