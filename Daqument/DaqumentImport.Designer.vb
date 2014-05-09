<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DaqumentImport
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
        Me.spc_Main = New System.Windows.Forms.SplitContainer
        Me.ipw_Image = New Daqument.ImagePreview
        Me.dgv_Import = New System.Windows.Forms.DataGridView
        Me.View = New System.Windows.Forms.DataGridViewButtonColumn
        Me.filename = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Hdpi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vdpi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EngineeringCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ClientCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Revision = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sheet = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sheets = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Project = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lbl_CurrentPath = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsp_Import = New System.Windows.Forms.ToolStrip
        Me.btn_OpenFolder = New System.Windows.Forms.ToolStripButton
        Me.btn_ImportCSV = New System.Windows.Forms.ToolStripButton
        Me.btn_Import = New System.Windows.Forms.ToolStripButton
        Me.btn_GenerateIndex = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.lbl_Hdpi = New System.Windows.Forms.ToolStripLabel
        Me.tbx_Hdpi = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.lbl_Vdpi = New System.Windows.Forms.ToolStripLabel
        Me.tbx_Vdpi = New System.Windows.Forms.ToolStripTextBox
        Me.fbd_Folder = New System.Windows.Forms.FolderBrowserDialog
        Me.ofd1 = New System.Windows.Forms.OpenFileDialog
        Me.spc_Main.Panel1.SuspendLayout()
        Me.spc_Main.Panel2.SuspendLayout()
        Me.spc_Main.SuspendLayout()
        CType(Me.dgv_Import, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.tsp_Import.SuspendLayout()
        Me.SuspendLayout()
        '
        'spc_Main
        '
        Me.spc_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spc_Main.Location = New System.Drawing.Point(0, 0)
        Me.spc_Main.Name = "spc_Main"
        Me.spc_Main.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spc_Main.Panel1
        '
        Me.spc_Main.Panel1.Controls.Add(Me.ipw_Image)
        '
        'spc_Main.Panel2
        '
        Me.spc_Main.Panel2.Controls.Add(Me.dgv_Import)
        Me.spc_Main.Panel2.Controls.Add(Me.StatusStrip1)
        Me.spc_Main.Panel2.Controls.Add(Me.tsp_Import)
        Me.spc_Main.Size = New System.Drawing.Size(1003, 653)
        Me.spc_Main.SplitterDistance = 307
        Me.spc_Main.TabIndex = 0
        '
        'ipw_Image
        '
        Me.ipw_Image.AutoScroll = True
        Me.ipw_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ipw_Image.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ipw_Image.Enabled = False
        Me.ipw_Image.Location = New System.Drawing.Point(0, 0)
        Me.ipw_Image.Name = "ipw_Image"
        Me.ipw_Image.Size = New System.Drawing.Size(1003, 307)
        Me.ipw_Image.TabIndex = 0
        '
        'dgv_Import
        '
        Me.dgv_Import.AllowUserToAddRows = False
        Me.dgv_Import.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Import.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.View, Me.filename, Me.Hdpi, Me.Vdpi, Me.EngineeringCode, Me.ClientCode, Me.Revision, Me.Description, Me.Sheet, Me.Sheets, Me.Location, Me.Type, Me.Project})
        Me.dgv_Import.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Import.Location = New System.Drawing.Point(0, 25)
        Me.dgv_Import.Name = "dgv_Import"
        Me.dgv_Import.Size = New System.Drawing.Size(1003, 295)
        Me.dgv_Import.TabIndex = 2
        '
        'View
        '
        Me.View.HeaderText = "View"
        Me.View.Name = "View"
        Me.View.Width = 50
        '
        'filename
        '
        Me.filename.HeaderText = "filename"
        Me.filename.Name = "filename"
        Me.filename.Visible = False
        '
        'Hdpi
        '
        Me.Hdpi.HeaderText = "Hdpi"
        Me.Hdpi.Name = "Hdpi"
        Me.Hdpi.Visible = False
        '
        'Vdpi
        '
        Me.Vdpi.HeaderText = "Vdpi"
        Me.Vdpi.Name = "Vdpi"
        Me.Vdpi.Visible = False
        '
        'EngineeringCode
        '
        Me.EngineeringCode.HeaderText = "EngCode"
        Me.EngineeringCode.Name = "EngineeringCode"
        Me.EngineeringCode.Width = 150
        '
        'ClientCode
        '
        Me.ClientCode.HeaderText = "Client Code"
        Me.ClientCode.Name = "ClientCode"
        Me.ClientCode.Width = 150
        '
        'Revision
        '
        Me.Revision.HeaderText = "Rev"
        Me.Revision.Name = "Revision"
        Me.Revision.Width = 35
        '
        'Description
        '
        Me.Description.HeaderText = "Desc"
        Me.Description.Name = "Description"
        Me.Description.Width = 250
        '
        'Sheet
        '
        Me.Sheet.HeaderText = "SHT"
        Me.Sheet.Name = "Sheet"
        Me.Sheet.Width = 35
        '
        'Sheets
        '
        Me.Sheets.HeaderText = "SHTs"
        Me.Sheets.Name = "Sheets"
        Me.Sheets.Width = 40
        '
        'Location
        '
        Me.Location.HeaderText = "Loc"
        Me.Location.Name = "Location"
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Width = 150
        '
        'Project
        '
        Me.Project.HeaderText = "Project"
        Me.Project.Name = "Project"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_CurrentPath})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 320)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1003, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbl_CurrentPath
        '
        Me.lbl_CurrentPath.Name = "lbl_CurrentPath"
        Me.lbl_CurrentPath.Size = New System.Drawing.Size(77, 17)
        Me.lbl_CurrentPath.Text = "Current Path="
        '
        'tsp_Import
        '
        Me.tsp_Import.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsp_Import.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_OpenFolder, Me.btn_ImportCSV, Me.btn_Import, Me.btn_GenerateIndex, Me.ToolStripSeparator1, Me.lbl_Hdpi, Me.tbx_Hdpi, Me.ToolStripSeparator2, Me.lbl_Vdpi, Me.tbx_Vdpi})
        Me.tsp_Import.Location = New System.Drawing.Point(0, 0)
        Me.tsp_Import.Name = "tsp_Import"
        Me.tsp_Import.Size = New System.Drawing.Size(1003, 25)
        Me.tsp_Import.TabIndex = 0
        Me.tsp_Import.Text = "ToolStrip1"
        '
        'btn_OpenFolder
        '
        Me.btn_OpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_OpenFolder.Image = Global.Daqument.My.Resources.Resources.Folder_1_Open
        Me.btn_OpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_OpenFolder.Name = "btn_OpenFolder"
        Me.btn_OpenFolder.Size = New System.Drawing.Size(23, 22)
        Me.btn_OpenFolder.Text = "Open Document Folder"
        '
        'btn_ImportCSV
        '
        Me.btn_ImportCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ImportCSV.Image = Global.Daqument.My.Resources.Resources.Table_Column_Add_After
        Me.btn_ImportCSV.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ImportCSV.Name = "btn_ImportCSV"
        Me.btn_ImportCSV.Size = New System.Drawing.Size(23, 22)
        Me.btn_ImportCSV.Text = "Import CSV Data"
        '
        'btn_Import
        '
        Me.btn_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Import.Image = Global.Daqument.My.Resources.Resources.Data_Feed
        Me.btn_Import.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Import.Name = "btn_Import"
        Me.btn_Import.Size = New System.Drawing.Size(23, 22)
        Me.btn_Import.Text = "Import"
        Me.btn_Import.ToolTipText = "Import Documents"
        '
        'btn_GenerateIndex
        '
        Me.btn_GenerateIndex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_GenerateIndex.Enabled = False
        Me.btn_GenerateIndex.Image = Global.Daqument.My.Resources.Resources.Save_As
        Me.btn_GenerateIndex.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_GenerateIndex.Name = "btn_GenerateIndex"
        Me.btn_GenerateIndex.Size = New System.Drawing.Size(23, 22)
        Me.btn_GenerateIndex.Text = "Generate Index"
        Me.btn_GenerateIndex.ToolTipText = "Generate Index File"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lbl_Hdpi
        '
        Me.lbl_Hdpi.Name = "lbl_Hdpi"
        Me.lbl_Hdpi.Size = New System.Drawing.Size(28, 22)
        Me.lbl_Hdpi.Text = "Hdpi"
        '
        'tbx_Hdpi
        '
        Me.tbx_Hdpi.Name = "tbx_Hdpi"
        Me.tbx_Hdpi.Size = New System.Drawing.Size(100, 25)
        Me.tbx_Hdpi.Text = "150"
        Me.tbx_Hdpi.ToolTipText = "Horizontal DPI Resolution"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lbl_Vdpi
        '
        Me.lbl_Vdpi.Name = "lbl_Vdpi"
        Me.lbl_Vdpi.Size = New System.Drawing.Size(27, 22)
        Me.lbl_Vdpi.Text = "Vdpi"
        '
        'tbx_Vdpi
        '
        Me.tbx_Vdpi.Name = "tbx_Vdpi"
        Me.tbx_Vdpi.Size = New System.Drawing.Size(100, 25)
        Me.tbx_Vdpi.Text = "150"
        Me.tbx_Vdpi.ToolTipText = "Vertical dpi Resolution"
        '
        'ofd1
        '
        Me.ofd1.FileName = "ofd1"
        '
        'DaqumentImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 653)
        Me.Controls.Add(Me.spc_Main)
        Me.Name = "DaqumentImport"
        Me.Text = "Daqument Import"
        Me.spc_Main.Panel1.ResumeLayout(False)
        Me.spc_Main.Panel2.ResumeLayout(False)
        Me.spc_Main.Panel2.PerformLayout()
        Me.spc_Main.ResumeLayout(False)
        CType(Me.dgv_Import, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tsp_Import.ResumeLayout(False)
        Me.tsp_Import.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spc_Main As System.Windows.Forms.SplitContainer
    Friend WithEvents ipw_Image As Daqument.ImagePreview
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsp_Import As System.Windows.Forms.ToolStrip
    Friend WithEvents fbd_Folder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents dgv_Import As System.Windows.Forms.DataGridView
    Friend WithEvents btn_OpenFolder As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ImportCSV As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl_CurrentPath As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbx_Hdpi As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl_Hdpi As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl_Vdpi As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tbx_Vdpi As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btn_Import As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_GenerateIndex As System.Windows.Forms.ToolStripButton
    Friend WithEvents View As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents filename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hdpi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vdpi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EngineeringCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClientCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Revision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sheet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sheets As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Project As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ofd1 As System.Windows.Forms.OpenFileDialog
End Class
