<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataExport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataExport))
        Me.dgv_Export = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_Export = New System.Windows.Forms.ToolStripButton
        Me.cbx_ExportType = New System.Windows.Forms.ToolStripComboBox
        CType(Me.dgv_Export, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_Export
        '
        Me.dgv_Export.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Export.EmbeddedNavigator.Name = ""
        Me.dgv_Export.Location = New System.Drawing.Point(0, 25)
        Me.dgv_Export.MainView = Me.GridView1
        Me.dgv_Export.Name = "dgv_Export"
        Me.dgv_Export.Size = New System.Drawing.Size(640, 454)
        Me.dgv_Export.TabIndex = 0
        Me.dgv_Export.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.dgv_Export
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 479)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(640, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Export, Me.cbx_ExportType})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(640, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_Export
        '
        Me.btn_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_Export.Enabled = False
        Me.btn_Export.Image = CType(resources.GetObject("btn_Export.Image"), System.Drawing.Image)
        Me.btn_Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Export.Name = "btn_Export"
        Me.btn_Export.Size = New System.Drawing.Size(43, 22)
        Me.btn_Export.Text = "Export"
        '
        'cbx_ExportType
        '
        Me.cbx_ExportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ExportType.Items.AddRange(New Object() {"HTML", "PDF", "Text", "Xls"})
        Me.cbx_ExportType.Name = "cbx_ExportType"
        Me.cbx_ExportType.Size = New System.Drawing.Size(121, 25)
        '
        'DataExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 501)
        Me.Controls.Add(Me.dgv_Export)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "DataExport"
        Me.Text = "Data Export"
        CType(Me.dgv_Export, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_Export As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cbx_ExportType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btn_Export As System.Windows.Forms.ToolStripButton
End Class
