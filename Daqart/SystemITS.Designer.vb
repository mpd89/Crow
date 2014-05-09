<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemITS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SystemITS))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_Export = New System.Windows.Forms.ToolStripButton
        Me.dgv_ITS = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgv_ITS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Export})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(847, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_Export
        '
        Me.btn_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_Export.Image = CType(resources.GetObject("btn_Export.Image"), System.Drawing.Image)
        Me.btn_Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Export.Name = "btn_Export"
        Me.btn_Export.Size = New System.Drawing.Size(44, 22)
        Me.btn_Export.Text = "Export"
        '
        'dgv_ITS
        '
        Me.dgv_ITS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ITS.EmbeddedNavigator.Name = ""
        Me.dgv_ITS.Location = New System.Drawing.Point(0, 25)
        Me.dgv_ITS.MainView = Me.GridView1
        Me.dgv_ITS.Name = "dgv_ITS"
        Me.dgv_ITS.Size = New System.Drawing.Size(847, 449)
        Me.dgv_ITS.TabIndex = 1
        Me.dgv_ITS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.dgv_ITS
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'SystemITS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 474)
        Me.Controls.Add(Me.dgv_ITS)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "SystemITS"
        Me.Text = "SystemITS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgv_ITS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents dgv_ITS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btn_Export As System.Windows.Forms.ToolStripButton
End Class
