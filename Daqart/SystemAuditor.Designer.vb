<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemAuditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SystemAuditor))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsb_Refresh = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.dgv_AuditPanel = New System.Windows.Forms.DataGridView
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Test = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Results = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.View = New System.Windows.Forms.DataGridViewButtonColumn
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_AuditPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(733, 24)
        Me.MenuStrip1.TabIndex = 18
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Refresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(733, 25)
        Me.ToolStrip1.TabIndex = 17
        '
        'tsb_Refresh
        '
        Me.tsb_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_Refresh.Image = Global.Daqart.My.Resources.Resources.Refresh1
        Me.tsb_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Refresh.Name = "tsb_Refresh"
        Me.tsb_Refresh.Size = New System.Drawing.Size(23, 22)
        Me.tsb_Refresh.Text = "ToolStripButton1"
        Me.tsb_Refresh.ToolTipText = "Refresh"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 549)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(733, 22)
        Me.StatusStrip1.TabIndex = 16
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(496, 376)
        Me.GridControl1.LookAndFeel.SkinName = "Blue"
        Me.GridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(294, 170)
        Me.GridControl1.TabIndex = 19
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.GridControl1.Visible = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'dgv_AuditPanel
        '
        Me.dgv_AuditPanel.AllowUserToAddRows = False
        Me.dgv_AuditPanel.AllowUserToDeleteRows = False
        Me.dgv_AuditPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_AuditPanel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.Type, Me.Test, Me.Results, Me.View})
        Me.dgv_AuditPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_AuditPanel.Location = New System.Drawing.Point(0, 49)
        Me.dgv_AuditPanel.Name = "dgv_AuditPanel"
        Me.dgv_AuditPanel.ReadOnly = True
        Me.dgv_AuditPanel.RowHeadersVisible = False
        Me.dgv_AuditPanel.Size = New System.Drawing.Size(733, 500)
        Me.dgv_AuditPanel.TabIndex = 20
        '
        'Item
        '
        Me.Item.HeaderText = "Item#"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        Me.Item.Width = 50
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Width = 150
        '
        'Test
        '
        Me.Test.HeaderText = "Test"
        Me.Test.Name = "Test"
        Me.Test.ReadOnly = True
        Me.Test.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Test.Width = 350
        '
        'Results
        '
        Me.Results.HeaderText = "Results"
        Me.Results.Name = "Results"
        Me.Results.ReadOnly = True
        Me.Results.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Results.Width = 50
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.ReadOnly = True
        Me.View.Width = 50
        '
        'SystemAuditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(733, 571)
        Me.Controls.Add(Me.dgv_AuditPanel)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "SystemAuditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "System Auditor Panel"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_AuditPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgv_AuditPanel As System.Windows.Forms.DataGridView
    Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Test As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Results As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents View As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents tsb_Refresh As System.Windows.Forms.ToolStripButton
End Class
#If 0 Then
Namespace ButtonClickOnGridButtonDoesNotFire 
    Partial Class Form1 
        ''' <summary> 
        ''' Required designer variable. 
        ''' </summary> 
        Private components As System.ComponentModel.IContainer = Nothing 

        ''' <summary> 
        ''' Clean up any resources being used. 
        ''' </summary> 
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param> 
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean) 
            If disposing AndAlso (components IsNot Nothing) Then 
                components.Dispose() 
            End If 
            MyBase.Dispose(disposing) 
        End Sub 

        #Region "Windows Form Designer generated code" 

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor. 
        ''' </summary> 
        Private Sub InitializeComponent() 
            Me.components = New System.ComponentModel.Container() 
            Me.gridControl1 = New DevExpress.XtraGrid.GridControl() 
            Me.carsBindingSource = New System.Windows.Forms.BindingSource(Me.components) 
            Me.carsDBDataSet = New ButtonClickOnGridButtonDoesNotFire.CarsDBDataSet() 
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView() 
            Me.colID = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colTrademark = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colModel = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colHP = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colLiter = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colCyl = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colTransmissSpeedCount = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colTransmissAutomatic = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colMPG_City = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colMPG_Highway = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colCategory = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colHyperlink = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colPicture = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colPrice = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.colRtfContent = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.carsTableAdapter = New ButtonClickOnGridButtonDoesNotFire.CarsDBDataSetTableAdapters.CarsTableAdapter() 
            Me.repositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() 
            Me.gridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn() 
            Me.repositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit() 
            DirectCast((Me.gridControl1), System.ComponentModel.ISupportInitialize).BeginInit() 
            DirectCast((Me.carsBindingSource), System.ComponentModel.ISupportInitialize).BeginInit() 
            DirectCast((Me.carsDBDataSet), System.ComponentModel.ISupportInitialize).BeginInit() 
            DirectCast((Me.gridView1), System.ComponentModel.ISupportInitialize).BeginInit() 
            DirectCast((Me.repositoryItemPictureEdit1), System.ComponentModel.ISupportInitialize).BeginInit() 
            DirectCast((Me.repositoryItemButtonEdit1), System.ComponentModel.ISupportInitialize).BeginInit() 
            Me.SuspendLayout() 
            ' 
            ' gridControl1 
            ' 
            Me.gridControl1.DataSource = Me.carsBindingSource 
            Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill 
            Me.gridControl1.EmbeddedNavigator.Name = "" 
            Me.gridControl1.FormsUseDefaultLookAndFeel = False 
            Me.gridControl1.Location = New System.Drawing.Point(0, 0) 
            Me.gridControl1.MainView = Me.gridView1 
            Me.gridControl1.Name = "gridControl1" 
            Me.gridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repositoryItemPictureEdit1, Me.repositoryItemButtonEdit1}) 
            Me.gridControl1.Size = New System.Drawing.Size(967, 409) 
            Me.gridControl1.TabIndex = 0 
            Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView1}) 
            ' 
            ' carsBindingSource 
            ' 
            Me.carsBindingSource.DataMember = "Cars" 
            Me.carsBindingSource.DataSource = Me.carsDBDataSet 
            ' 
            ' carsDBDataSet 
            ' 
            Me.carsDBDataSet.DataSetName = "CarsDBDataSet" 
            Me.carsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema 
            ' 
            ' gridView1 
            ' 
            Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colTrademark, Me.colModel, Me.colHP, Me.colLiter, Me.colCyl, _ 
            Me.colTransmissSpeedCount, Me.colTransmissAutomatic, Me.colMPG_City, Me.colMPG_Highway, Me.colCategory, Me.colDescription, _ 
            Me.colHyperlink, Me.colPicture, Me.colPrice, Me.colRtfContent, Me.gridColumn1}) 
            Me.gridView1.GridControl = Me.gridControl1 
            Me.gridView1.Name = "gridView1" 
            ' 
            ' colID 
            ' 
            Me.colID.Caption = "ID" 
            Me.colID.FieldName = "ID" 
            Me.colID.Name = "colID" 
            ' 
            ' colTrademark 
            ' 
            Me.colTrademark.Caption = "Trademark" 
            Me.colTrademark.FieldName = "Trademark" 
            Me.colTrademark.Name = "colTrademark" 
            Me.colTrademark.Visible = True 
            Me.colTrademark.VisibleIndex = 0 
            ' 
            ' colModel 
            ' 
            Me.colModel.Caption = "Model" 
            Me.colModel.FieldName = "Model" 
            Me.colModel.Name = "colModel" 
            Me.colModel.Visible = True 
            Me.colModel.VisibleIndex = 1 
            ' 
            ' colHP 
            ' 
            Me.colHP.Caption = "HP" 
            Me.colHP.FieldName = "HP" 
            Me.colHP.Name = "colHP" 
            ' 
            ' colLiter 
            ' 
            Me.colLiter.Caption = "Liter" 
            Me.colLiter.FieldName = "Liter" 
            Me.colLiter.Name = "colLiter" 
            ' 
            ' colCyl 
            ' 
            Me.colCyl.Caption = "Cyl" 
            Me.colCyl.FieldName = "Cyl" 
            Me.colCyl.Name = "colCyl" 
            ' 
            ' colTransmissSpeedCount 
            ' 
            Me.colTransmissSpeedCount.Caption = "TransmissSpeedCount" 
            Me.colTransmissSpeedCount.FieldName = "TransmissSpeedCount" 
            Me.colTransmissSpeedCount.Name = "colTransmissSpeedCount" 
            ' 
            ' colTransmissAutomatic 
            ' 
            Me.colTransmissAutomatic.Caption = "TransmissAutomatic" 
            Me.colTransmissAutomatic.FieldName = "TransmissAutomatic" 
            Me.colTransmissAutomatic.Name = "colTransmissAutomatic" 
            ' 
            ' colMPG_City 
            ' 
            Me.colMPG_City.Caption = "MPG_City" 
            Me.colMPG_City.FieldName = "MPG_City" 
            Me.colMPG_City.Name = "colMPG_City" 
            ' 
            ' colMPG_Highway 
            ' 
            Me.colMPG_Highway.Caption = "MPG_Highway" 
            Me.colMPG_Highway.FieldName = "MPG_Highway" 
            Me.colMPG_Highway.Name = "colMPG_Highway" 
            ' 
            ' colCategory 
            ' 
            Me.colCategory.Caption = "Category" 
            Me.colCategory.FieldName = "Category" 
            Me.colCategory.Name = "colCategory" 
            ' 
            ' colDescription 
            ' 
            Me.colDescription.Caption = "Description" 
            Me.colDescription.FieldName = "Description" 
            Me.colDescription.Name = "colDescription" 
            ' 
            ' colHyperlink 
            ' 
            Me.colHyperlink.Caption = "Hyperlink" 
            Me.colHyperlink.FieldName = "Hyperlink" 
            Me.colHyperlink.Name = "colHyperlink" 
            ' 
            ' colPicture 
            ' 
            Me.colPicture.Caption = "Picture" 
            Me.colPicture.ColumnEdit = Me.repositoryItemPictureEdit1 
            Me.colPicture.FieldName = "Picture" 
            Me.colPicture.Name = "colPicture" 
            Me.colPicture.Visible = True 
            Me.colPicture.VisibleIndex = 2 
            ' 
            ' colPrice 
            ' 
            Me.colPrice.Caption = "Price" 
            Me.colPrice.FieldName = "Price" 
            Me.colPrice.Name = "colPrice" 
            Me.colPrice.Visible = True 
            Me.colPrice.VisibleIndex = 3 
            ' 
            ' colRtfContent 
            ' 
            Me.colRtfContent.Caption = "RtfContent" 
            Me.colRtfContent.FieldName = "RtfContent" 
            Me.colRtfContent.Name = "colRtfContent" 
            ' 
            ' carsTableAdapter 
            ' 
            Me.carsTableAdapter.ClearBeforeFill = True 
            ' 
            ' repositoryItemPictureEdit1 
            ' 
            Me.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1" 
            ' 
            ' gridColumn1 
            ' 
            Me.gridColumn1.Caption = "gridColumn1" 
            Me.gridColumn1.ColumnEdit = Me.repositoryItemButtonEdit1 
            Me.gridColumn1.Name = "gridColumn1" 
            Me.gridColumn1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways 
            Me.gridColumn1.Visible = True 
            Me.gridColumn1.VisibleIndex = 4 
            ' 
            ' repositoryItemButtonEdit1 
            ' 
            Me.repositoryItemButtonEdit1.AutoHeight = False 
            Me.repositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()}) 
            Me.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1" 
            AddHandler Me.repositoryItemButtonEdit1.ButtonClick, AddressOf Me.repositoryItemButtonEdit1_ButtonClick 
            ' 
            ' Form1 
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F) 
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font 
            Me.ClientSize = New System.Drawing.Size(967, 409) 
            Me.Controls.Add(Me.gridControl1) 
            Me.Name = "Form1" 
            Me.Text = "Form1" 
            AddHandler Me.Load, AddressOf Me.Form1_Load 
            DirectCast((Me.gridControl1), System.ComponentModel.ISupportInitialize).EndInit() 
            DirectCast((Me.carsBindingSource), System.ComponentModel.ISupportInitialize).EndInit() 
            DirectCast((Me.carsDBDataSet), System.ComponentModel.ISupportInitialize).EndInit() 
            DirectCast((Me.gridView1), System.ComponentModel.ISupportInitialize).EndInit() 
            DirectCast((Me.repositoryItemPictureEdit1), System.ComponentModel.ISupportInitialize).EndInit() 
            DirectCast((Me.repositoryItemButtonEdit1), System.ComponentModel.ISupportInitialize).EndInit() 
            Me.ResumeLayout(False) 

        End Sub 

        #End Region 

        Private gridControl1 As DevExpress.XtraGrid.GridControl 
        Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView 
        Private carsDBDataSet As CarsDBDataSet 
        Private carsBindingSource As System.Windows.Forms.BindingSource 
        Private carsTableAdapter As ButtonClickOnGridButtonDoesNotFire.CarsDBDataSetTableAdapters.CarsTableAdapter 
        Private colID As DevExpress.XtraGrid.Columns.GridColumn 
        Private colTrademark As DevExpress.XtraGrid.Columns.GridColumn 
        Private colModel As DevExpress.XtraGrid.Columns.GridColumn 
        Private colHP As DevExpress.XtraGrid.Columns.GridColumn 
        Private colLiter As DevExpress.XtraGrid.Columns.GridColumn 
        Private colCyl As DevExpress.XtraGrid.Columns.GridColumn 
        Private colTransmissSpeedCount As DevExpress.XtraGrid.Columns.GridColumn 
        Private colTransmissAutomatic As DevExpress.XtraGrid.Columns.GridColumn 
        Private colMPG_City As DevExpress.XtraGrid.Columns.GridColumn 
        Private colMPG_Highway As DevExpress.XtraGrid.Columns.GridColumn 
        Private colCategory As DevExpress.XtraGrid.Columns.GridColumn 
        Private colDescription As DevExpress.XtraGrid.Columns.GridColumn 
        Private colHyperlink As DevExpress.XtraGrid.Columns.GridColumn 
        Private colPicture As DevExpress.XtraGrid.Columns.GridColumn 
        Private colPrice As DevExpress.XtraGrid.Columns.GridColumn 
        Private colRtfContent As DevExpress.XtraGrid.Columns.GridColumn 
        Private repositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit 
        Private gridColumn1 As DevExpress.XtraGrid.Columns.GridColumn 
        Private repositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit 
    End Class 
End Namespace 
#End If