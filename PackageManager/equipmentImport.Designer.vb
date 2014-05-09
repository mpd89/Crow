<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class equipmentImport
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnUploadPkgNums = New System.Windows.Forms.Button
        Me.lblEquipmentImport = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.fileName = New System.Windows.Forms.TextBox
        Me.btnImportCSV = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 658)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(974, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(974, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(974, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(6, 77)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(960, 378)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.btnUploadPkgNums)
        Me.TabPage1.Controls.Add(Me.lblEquipmentImport)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.fileName)
        Me.TabPage1.Controls.Add(Me.btnImportCSV)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(952, 352)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Import Packages"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(189, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(160, 13)
        Me.Label8.TabIndex = 137
        Me.Label8.Text = "Select columns from the CSV file"
        '
        'btnUploadPkgNums
        '
        Me.btnUploadPkgNums.Location = New System.Drawing.Point(446, 308)
        Me.btnUploadPkgNums.Name = "btnUploadPkgNums"
        Me.btnUploadPkgNums.Size = New System.Drawing.Size(123, 20)
        Me.btnUploadPkgNums.TabIndex = 136
        Me.btnUploadPkgNums.Text = "Upload Packages"
        Me.btnUploadPkgNums.UseVisualStyleBackColor = True
        '
        'lblEquipmentImport
        '
        Me.lblEquipmentImport.AutoSize = True
        Me.lblEquipmentImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquipmentImport.Location = New System.Drawing.Point(38, 27)
        Me.lblEquipmentImport.Name = "lblEquipmentImport"
        Me.lblEquipmentImport.Size = New System.Drawing.Size(159, 24)
        Me.lblEquipmentImport.TabIndex = 96
        Me.lblEquipmentImport.Text = "Equipment Import"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(234, 289)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(154, 17)
        Me.CheckBox1.TabIndex = 95
        Me.CheckBox1.Text = "First Row contains headers"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'fileName
        '
        Me.fileName.Location = New System.Drawing.Point(6, 308)
        Me.fileName.Name = "fileName"
        Me.fileName.Size = New System.Drawing.Size(222, 20)
        Me.fileName.TabIndex = 94
        '
        'btnImportCSV
        '
        Me.btnImportCSV.Location = New System.Drawing.Point(247, 308)
        Me.btnImportCSV.Name = "btnImportCSV"
        Me.btnImportCSV.Size = New System.Drawing.Size(123, 20)
        Me.btnImportCSV.TabIndex = 93
        Me.btnImportCSV.Text = "Import from CSV File"
        Me.btnImportCSV.UseVisualStyleBackColor = True
        '
        'equipmentImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 680)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "equipmentImport"
        Me.Text = "equipmentImport"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnUploadPkgNums As System.Windows.Forms.Button
    Friend WithEvents lblEquipmentImport As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents fileName As System.Windows.Forms.TextBox
    Friend WithEvents btnImportCSV As System.Windows.Forms.Button
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
End Class
