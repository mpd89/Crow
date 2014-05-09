<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemPermissions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SystemPermissions))
        Me.dgv_PermissionTable = New System.Windows.Forms.DataGridView
        Me.Feature = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsb_Save = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.cbx_LevelList = New System.Windows.Forms.ComboBox
        Me.lbl_Levels = New System.Windows.Forms.Label
        CType(Me.dgv_PermissionTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_PermissionTable
        '
        Me.dgv_PermissionTable.AllowUserToAddRows = False
        Me.dgv_PermissionTable.AllowUserToDeleteRows = False
        Me.dgv_PermissionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_PermissionTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Feature, Me.Status})
        Me.dgv_PermissionTable.Location = New System.Drawing.Point(12, 63)
        Me.dgv_PermissionTable.Name = "dgv_PermissionTable"
        Me.dgv_PermissionTable.RowHeadersVisible = False
        Me.dgv_PermissionTable.Size = New System.Drawing.Size(488, 495)
        Me.dgv_PermissionTable.TabIndex = 0
        '
        'Feature
        '
        Me.Feature.HeaderText = "System Feature"
        Me.Feature.Name = "Feature"
        Me.Feature.ReadOnly = True
        Me.Feature.Width = 400
        '
        'Status
        '
        Me.Status.FalseValue = "False"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.TrueValue = "True"
        Me.Status.Width = 50
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Save})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(512, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsb_Save
        '
        Me.tsb_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_Save.Image = Global.Daqart.My.Resources.Resources.Floppy
        Me.tsb_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Save.Name = "tsb_Save"
        Me.tsb_Save.Size = New System.Drawing.Size(23, 22)
        Me.tsb_Save.Text = "ToolStripButton1"
        Me.tsb_Save.ToolTipText = "Save"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 578)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(512, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'cbx_LevelList
        '
        Me.cbx_LevelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_LevelList.FormattingEnabled = True
        Me.cbx_LevelList.Location = New System.Drawing.Point(84, 39)
        Me.cbx_LevelList.Name = "cbx_LevelList"
        Me.cbx_LevelList.Size = New System.Drawing.Size(173, 21)
        Me.cbx_LevelList.TabIndex = 3
        '
        'lbl_Levels
        '
        Me.lbl_Levels.AutoSize = True
        Me.lbl_Levels.Location = New System.Drawing.Point(12, 47)
        Me.lbl_Levels.Name = "lbl_Levels"
        Me.lbl_Levels.Size = New System.Drawing.Size(66, 13)
        Me.lbl_Levels.TabIndex = 4
        Me.lbl_Levels.Text = "Select Level"
        '
        'SystemPermissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 600)
        Me.Controls.Add(Me.lbl_Levels)
        Me.Controls.Add(Me.cbx_LevelList)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgv_PermissionTable)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SystemPermissions"
        Me.Text = "System Permissions"
        CType(Me.dgv_PermissionTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_PermissionTable As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsb_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbx_LevelList As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Levels As System.Windows.Forms.Label
    Friend WithEvents Feature As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
