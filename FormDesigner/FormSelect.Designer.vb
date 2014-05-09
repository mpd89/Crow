<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSelect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSelect))
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnAddNewForm = New System.Windows.Forms.ToolStripButton
        Me.btnDeleteForm = New System.Windows.Forms.ToolStripButton
        Me.btn_Import = New System.Windows.Forms.ToolStripButton
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.LookAndFeel.SkinName = "Blue"
        Me.GridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(698, 341)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddNewForm, Me.btnDeleteForm, Me.btn_Import})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(698, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAddNewForm
        '
        Me.btnAddNewForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAddNewForm.Image = CType(resources.GetObject("btnAddNewForm.Image"), System.Drawing.Image)
        Me.btnAddNewForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddNewForm.Name = "btnAddNewForm"
        Me.btnAddNewForm.Size = New System.Drawing.Size(81, 22)
        Me.btnAddNewForm.Text = "Add New Form"
        '
        'btnDeleteForm
        '
        Me.btnDeleteForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnDeleteForm.Image = CType(resources.GetObject("btnDeleteForm.Image"), System.Drawing.Image)
        Me.btnDeleteForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeleteForm.Name = "btnDeleteForm"
        Me.btnDeleteForm.Size = New System.Drawing.Size(69, 22)
        Me.btnDeleteForm.Text = "Delete Form"
        '
        'btn_Import
        '
        Me.btn_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_Import.Image = CType(resources.GetObject("btn_Import.Image"), System.Drawing.Image)
        Me.btn_Import.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Import.Name = "btn_Import"
        Me.btn_Import.Size = New System.Drawing.Size(43, 22)
        Me.btn_Import.Text = "Import"
        '
        'FormSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 341)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GridControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormSelect"
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAddNewForm As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_Import As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDeleteForm As System.Windows.Forms.ToolStripButton
End Class
