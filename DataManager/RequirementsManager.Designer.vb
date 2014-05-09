<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RequirementsManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RequirementsManager))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgv_Certification = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cbx_OwnerList = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.btn_Export = New System.Windows.Forms.ToolStripButton
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_Certification, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgv_Certification)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(849, 504)
        Me.Panel2.TabIndex = 1
        '
        'dgv_Certification
        '
        Me.dgv_Certification.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Certification.EmbeddedNavigator.Name = ""
        Me.dgv_Certification.Location = New System.Drawing.Point(0, 0)
        Me.dgv_Certification.MainView = Me.GridView1
        Me.dgv_Certification.Name = "dgv_Certification"
        Me.dgv_Certification.Size = New System.Drawing.Size(849, 504)
        Me.dgv_Certification.TabIndex = 0
        Me.dgv_Certification.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.dgv_Certification
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cbx_OwnerList, Me.ToolStripButton1, Me.btn_Export})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(849, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cbx_OwnerList
        '
        Me.cbx_OwnerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_OwnerList.Name = "cbx_OwnerList"
        Me.cbx_OwnerList.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripButton1.Text = "Update"
        Me.ToolStripButton1.ToolTipText = "Update Certification Requirements"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 529)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(849, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
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
        'RequirementsManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 551)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "RequirementsManager"
        Me.ShowIcon = False
        Me.Text = "Certification Requirements"
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgv_Certification, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents dgv_Certification As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cbx_OwnerList As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_Export As System.Windows.Forms.ToolStripButton
End Class
