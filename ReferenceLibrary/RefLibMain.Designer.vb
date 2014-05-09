<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RefLibMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RefLibMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_Add = New System.Windows.Forms.ToolStripButton
        Me.btn_Delete = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lbx_Types = New System.Windows.Forms.ListBox
        Me.dgv_References = New DevExpress.XtraGrid.GridControl
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddReferenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteReferenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv_References, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(969, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Add, Me.btn_Delete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(969, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_Add
        '
        Me.btn_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Add.Image = Global.ReferenceLibrary.My.Resources.Resources.Symbol_Add
        Me.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(23, 22)
        Me.btn_Add.Text = "ToolStripButton1"
        Me.btn_Add.ToolTipText = "Add Reference"
        '
        'btn_Delete
        '
        Me.btn_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Delete.Image = Global.ReferenceLibrary.My.Resources.Resources.Symbol_Delete
        Me.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(23, 22)
        Me.btn_Delete.Text = "ToolStripButton1"
        Me.btn_Delete.ToolTipText = "Delete Reference"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 612)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(969, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbx_Types)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_References)
        Me.SplitContainer1.Size = New System.Drawing.Size(969, 563)
        Me.SplitContainer1.SplitterDistance = 208
        Me.SplitContainer1.TabIndex = 3
        '
        'lbx_Types
        '
        Me.lbx_Types.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbx_Types.FormattingEnabled = True
        Me.lbx_Types.Location = New System.Drawing.Point(0, 0)
        Me.lbx_Types.Name = "lbx_Types"
        Me.lbx_Types.Size = New System.Drawing.Size(208, 563)
        Me.lbx_Types.TabIndex = 0
        '
        'dgv_References
        '
        Me.dgv_References.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgv_References.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_References.EmbeddedNavigator.Name = ""
        Me.dgv_References.Location = New System.Drawing.Point(0, 0)
        Me.dgv_References.LookAndFeel.SkinName = "iMaginary"
        Me.dgv_References.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.dgv_References.MainView = Me.GridView1
        Me.dgv_References.Name = "dgv_References"
        Me.dgv_References.Size = New System.Drawing.Size(757, 563)
        Me.dgv_References.TabIndex = 0
        Me.dgv_References.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddReferenceToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteReferenceToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 70)
        '
        'AddReferenceToolStripMenuItem
        '
        Me.AddReferenceToolStripMenuItem.Name = "AddReferenceToolStripMenuItem"
        Me.AddReferenceToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AddReferenceToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteReferenceToolStripMenuItem
        '
        Me.DeleteReferenceToolStripMenuItem.Name = "DeleteReferenceToolStripMenuItem"
        Me.DeleteReferenceToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteReferenceToolStripMenuItem.Text = "Delete"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.dgv_References
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'RefLibMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 634)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "RefLibMain"
        Me.Text = "Daqart Reference Library"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv_References, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lbx_Types As System.Windows.Forms.ListBox
    Friend WithEvents dgv_References As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddReferenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteReferenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_Delete As System.Windows.Forms.ToolStripButton

End Class
