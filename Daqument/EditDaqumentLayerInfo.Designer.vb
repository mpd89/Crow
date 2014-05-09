<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditDaqumentLayerInfo
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
        Me.dgvMenuStrip = New System.Windows.Forms.MenuStrip
        Me.ms_btnFile = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExportToPDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CustomViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveAsNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdbTblView = New System.Windows.Forms.RadioButton
        Me.rdbColView = New System.Windows.Forms.RadioButton
        Me.lbl_Info = New System.Windows.Forms.Label
        Me.VGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl
        Me.vgcCboPipeSize = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.vgcCboWeldInches = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.vgcCboForemanName = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.vgcCboSVCS = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.vgcCboNDEPcntReq = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.vgcCboWeldStn = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.vgcNDEType = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.vgcCboSpools = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gcCboPipeSize = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.gcCboWeldInches = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.gcCboForemanName = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.gcCboSVCSpec = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.gcCboNDEPcntReq = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.gcCboWeldStn = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.gcCboNDEType = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.gcCboSpools = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Me.dgvMenuStrip.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgcCboPipeSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgcCboWeldInches, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgcCboForemanName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgcCboSVCS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgcCboNDEPcntReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgcCboWeldStn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgcNDEType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vgcCboSpools, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcCboPipeSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcCboWeldInches, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcCboForemanName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcCboSVCSpec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcCboNDEPcntReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcCboWeldStn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcCboNDEType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcCboSpools, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMenuStrip
        '
        Me.dgvMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_btnFile, Me.CustomViewToolStripMenuItem})
        Me.dgvMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.dgvMenuStrip.Name = "dgvMenuStrip"
        Me.dgvMenuStrip.Size = New System.Drawing.Size(586, 24)
        Me.dgvMenuStrip.TabIndex = 31
        Me.dgvMenuStrip.Text = "MenuStrip2"
        '
        'ms_btnFile
        '
        Me.ms_btnFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem, Me.ToolStripSeparator1, Me.ExportToPDFToolStripMenuItem, Me.ExportToExcelToolStripMenuItem, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.ms_btnFile.Name = "ms_btnFile"
        Me.ms_btnFile.Size = New System.Drawing.Size(35, 20)
        Me.ms_btnFile.Text = "File"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(157, 6)
        '
        'ExportToPDFToolStripMenuItem
        '
        Me.ExportToPDFToolStripMenuItem.Name = "ExportToPDFToolStripMenuItem"
        Me.ExportToPDFToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExportToPDFToolStripMenuItem.Text = "Export To PDF"
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export To Excel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(157, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'CustomViewToolStripMenuItem
        '
        Me.CustomViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectToolStripMenuItem, Me.SaveToolStripMenuItem1, Me.SaveAsNewToolStripMenuItem})
        Me.CustomViewToolStripMenuItem.Enabled = False
        Me.CustomViewToolStripMenuItem.Name = "CustomViewToolStripMenuItem"
        Me.CustomViewToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.CustomViewToolStripMenuItem.Text = "Custom View"
        '
        'SelectToolStripMenuItem
        '
        Me.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem"
        Me.SelectToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SelectToolStripMenuItem.Text = "Select"
        '
        'SaveToolStripMenuItem1
        '
        Me.SaveToolStripMenuItem1.Name = "SaveToolStripMenuItem1"
        Me.SaveToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.SaveToolStripMenuItem1.Text = "Save"
        '
        'SaveAsNewToolStripMenuItem
        '
        Me.SaveAsNewToolStripMenuItem.Name = "SaveAsNewToolStripMenuItem"
        Me.SaveAsNewToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveAsNewToolStripMenuItem.Text = "Save As New"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbl_Info)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.VGridControl1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(586, 249)
        Me.SplitContainer1.SplitterDistance = 58
        Me.SplitContainer1.TabIndex = 32
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbTblView)
        Me.GroupBox1.Controls.Add(Me.rdbColView)
        Me.GroupBox1.Location = New System.Drawing.Point(329, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(117, 45)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'rdbTblView
        '
        Me.rdbTblView.AutoSize = True
        Me.rdbTblView.Checked = True
        Me.rdbTblView.Location = New System.Drawing.Point(6, 9)
        Me.rdbTblView.Name = "rdbTblView"
        Me.rdbTblView.Size = New System.Drawing.Size(78, 17)
        Me.rdbTblView.TabIndex = 0
        Me.rdbTblView.TabStop = True
        Me.rdbTblView.Text = "Table View"
        Me.rdbTblView.UseVisualStyleBackColor = True
        '
        'rdbColView
        '
        Me.rdbColView.AutoSize = True
        Me.rdbColView.Location = New System.Drawing.Point(6, 25)
        Me.rdbColView.Name = "rdbColView"
        Me.rdbColView.Size = New System.Drawing.Size(86, 17)
        Me.rdbColView.TabIndex = 1
        Me.rdbColView.Text = "Column View"
        Me.rdbColView.UseVisualStyleBackColor = True
        '
        'lbl_Info
        '
        Me.lbl_Info.AutoSize = True
        Me.lbl_Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Info.Location = New System.Drawing.Point(12, 13)
        Me.lbl_Info.Name = "lbl_Info"
        Me.lbl_Info.Size = New System.Drawing.Size(286, 31)
        Me.lbl_Info.TabIndex = 1
        Me.lbl_Info.Text = "Daqument Layer Info"
        '
        'VGridControl1
        '
        Me.VGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VGridControl1.Location = New System.Drawing.Point(0, 0)
        Me.VGridControl1.Name = "VGridControl1"
        Me.VGridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.vgcCboPipeSize, Me.vgcCboWeldInches, Me.vgcCboForemanName, Me.vgcCboSVCS, Me.vgcCboNDEPcntReq, Me.vgcCboWeldStn, Me.vgcNDEType, Me.vgcCboSpools})
        Me.VGridControl1.Size = New System.Drawing.Size(586, 187)
        Me.VGridControl1.TabIndex = 2
        '
        'vgcCboPipeSize
        '
        Me.vgcCboPipeSize.AutoHeight = False
        Me.vgcCboPipeSize.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.vgcCboPipeSize.Name = "vgcCboPipeSize"
        '
        'vgcCboWeldInches
        '
        Me.vgcCboWeldInches.AutoHeight = False
        Me.vgcCboWeldInches.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.vgcCboWeldInches.Name = "vgcCboWeldInches"
        '
        'vgcCboForemanName
        '
        Me.vgcCboForemanName.AutoHeight = False
        Me.vgcCboForemanName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.vgcCboForemanName.Name = "vgcCboForemanName"
        '
        'vgcCboSVCS
        '
        Me.vgcCboSVCS.AutoHeight = False
        Me.vgcCboSVCS.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.vgcCboSVCS.Name = "vgcCboSVCS"
        '
        'vgcCboNDEPcntReq
        '
        Me.vgcCboNDEPcntReq.AutoHeight = False
        Me.vgcCboNDEPcntReq.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.vgcCboNDEPcntReq.Name = "vgcCboNDEPcntReq"
        '
        'vgcCboWeldStn
        '
        Me.vgcCboWeldStn.AutoHeight = False
        Me.vgcCboWeldStn.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.vgcCboWeldStn.Name = "vgcCboWeldStn"
        '
        'vgcNDEType
        '
        Me.vgcNDEType.AutoHeight = False
        Me.vgcNDEType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.vgcNDEType.Name = "vgcNDEType"
        '
        'vgcCboSpools
        '
        Me.vgcCboSpools.AutoHeight = False
        Me.vgcCboSpools.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.vgcCboSpools.Name = "vgcCboSpools"
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
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.gcCboPipeSize, Me.gcCboWeldInches, Me.gcCboForemanName, Me.gcCboSVCSpec, Me.gcCboNDEPcntReq, Me.gcCboWeldStn, Me.gcCboNDEType, Me.gcCboSpools})
        Me.GridControl1.Size = New System.Drawing.Size(586, 187)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'gcCboPipeSize
        '
        Me.gcCboPipeSize.AutoHeight = False
        Me.gcCboPipeSize.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.gcCboPipeSize.Name = "gcCboPipeSize"
        '
        'gcCboWeldInches
        '
        Me.gcCboWeldInches.AutoHeight = False
        Me.gcCboWeldInches.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.gcCboWeldInches.Name = "gcCboWeldInches"
        '
        'gcCboForemanName
        '
        Me.gcCboForemanName.AutoHeight = False
        Me.gcCboForemanName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.gcCboForemanName.Name = "gcCboForemanName"
        '
        'gcCboSVCSpec
        '
        Me.gcCboSVCSpec.AutoHeight = False
        Me.gcCboSVCSpec.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.gcCboSVCSpec.Name = "gcCboSVCSpec"
        '
        'gcCboNDEPcntReq
        '
        Me.gcCboNDEPcntReq.AutoHeight = False
        Me.gcCboNDEPcntReq.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.gcCboNDEPcntReq.Name = "gcCboNDEPcntReq"
        '
        'gcCboWeldStn
        '
        Me.gcCboWeldStn.AutoHeight = False
        Me.gcCboWeldStn.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.gcCboWeldStn.Name = "gcCboWeldStn"
        '
        'gcCboNDEType
        '
        Me.gcCboNDEType.AutoHeight = False
        Me.gcCboNDEType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.gcCboNDEType.Name = "gcCboNDEType"
        '
        'gcCboSpools
        '
        Me.gcCboSpools.AutoHeight = False
        Me.gcCboSpools.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.gcCboSpools.Name = "gcCboSpools"
        '
        'EditDaqumentLayerInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 273)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.dgvMenuStrip)
        Me.Name = "EditDaqumentLayerInfo"
        Me.Text = "EditDaqumentLayerInfo"
        Me.dgvMenuStrip.ResumeLayout(False)
        Me.dgvMenuStrip.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgcCboPipeSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgcCboWeldInches, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgcCboForemanName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgcCboSVCS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgcCboNDEPcntReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgcCboWeldStn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgcNDEType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vgcCboSpools, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcCboPipeSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcCboWeldInches, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcCboForemanName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcCboSVCSpec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcCboNDEPcntReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcCboWeldStn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcCboNDEType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcCboSpools, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ms_btnFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToPDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcCboPipeSize As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents gcCboWeldInches As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents gcCboForemanName As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents gcCboSVCSpec As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents gcCboNDEPcntReq As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents gcCboWeldStn As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents gcCboNDEType As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents gcCboSpools As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents VGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents vgcCboPipeSize As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents vgcCboWeldInches As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents vgcCboForemanName As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents vgcCboSVCS As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents vgcCboNDEPcntReq As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents vgcCboWeldStn As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents vgcNDEType As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents vgcCboSpools As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents lbl_Info As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbTblView As System.Windows.Forms.RadioButton
    Friend WithEvents rdbColView As System.Windows.Forms.RadioButton
End Class
