<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportViewerMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportViewerMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitPackageViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportType = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileHorizontallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileVerticallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileInGridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OverviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.StatusOverviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ReportType, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem, Me.StatusToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(868, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitPackageViewerToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitPackageViewerToolStripMenuItem
        '
        Me.ExitPackageViewerToolStripMenuItem.Name = "ExitPackageViewerToolStripMenuItem"
        Me.ExitPackageViewerToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ExitPackageViewerToolStripMenuItem.Text = "Exit Package Viewer"
        '
        'ReportType
        '
        Me.ReportType.Name = "ReportType"
        Me.ReportType.Size = New System.Drawing.Size(76, 20)
        Me.ReportType.Text = "ReportType"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TileHorizontallyToolStripMenuItem, Me.TileVerticallyToolStripMenuItem, Me.TileInGridToolStripMenuItem})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'TileHorizontallyToolStripMenuItem
        '
        Me.TileHorizontallyToolStripMenuItem.Name = "TileHorizontallyToolStripMenuItem"
        Me.TileHorizontallyToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.TileHorizontallyToolStripMenuItem.Text = "Tile Horizontally"
        '
        'TileVerticallyToolStripMenuItem
        '
        Me.TileVerticallyToolStripMenuItem.Name = "TileVerticallyToolStripMenuItem"
        Me.TileVerticallyToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.TileVerticallyToolStripMenuItem.Text = "Tile Vertically"
        '
        'TileInGridToolStripMenuItem
        '
        Me.TileInGridToolStripMenuItem.Name = "TileInGridToolStripMenuItem"
        Me.TileInGridToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.TileInGridToolStripMenuItem.Text = "Tile in Grid"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'StatusToolStripMenuItem
        '
        Me.StatusToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OverviewToolStripMenuItem, Me.StatusOverviewToolStripMenuItem})
        Me.StatusToolStripMenuItem.Name = "StatusToolStripMenuItem"
        Me.StatusToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.StatusToolStripMenuItem.Text = "Status"
        '
        'OverviewToolStripMenuItem
        '
        Me.OverviewToolStripMenuItem.Name = "OverviewToolStripMenuItem"
        Me.OverviewToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.OverviewToolStripMenuItem.Text = "Overview"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(868, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Refresh"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 586)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(868, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusOverviewToolStripMenuItem
        '
        Me.StatusOverviewToolStripMenuItem.Name = "StatusOverviewToolStripMenuItem"
        Me.StatusOverviewToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.StatusOverviewToolStripMenuItem.Text = "Status Overview"
        '
        'GridControl2
        '
        Me.GridControl2.EmbeddedNavigator.Name = ""
        Me.GridControl2.Location = New System.Drawing.Point(347, 144)
        Me.GridControl2.MainView = Me.GridView1
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(400, 200)
        Me.GridControl2.TabIndex = 8
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl2
        Me.GridView1.Name = "GridView1"
        '
        'ReportViewerMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 608)
        Me.Controls.Add(Me.GridControl2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ReportViewerMain"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitPackageViewerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileInGridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusOverviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView

End Class
