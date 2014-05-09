<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PkgSelect
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PkgSelect))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.DataNavigator1 = New DevExpress.XtraEditors.DataNavigator
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(-2, 0)
        Me.GridControl1.LookAndFeel.SkinName = "Blue"
        Me.GridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(555, 317)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        '
        'DataNavigator1
        '
        Me.DataNavigator1.Buttons.Append.Visible = False
        Me.DataNavigator1.Buttons.CancelEdit.Visible = False
        Me.DataNavigator1.Buttons.EnabledAutoRepeat = False
        Me.DataNavigator1.Buttons.EndEdit.Visible = False
        Me.DataNavigator1.Buttons.Remove.Enabled = False
        Me.DataNavigator1.Buttons.Remove.Visible = False
        Me.DataNavigator1.Location = New System.Drawing.Point(305, 12)
        Me.DataNavigator1.LookAndFeel.SkinName = "Lilian"
        Me.DataNavigator1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.DataNavigator1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DataNavigator1.LookAndFeel.UseWindowsXPTheme = True
        Me.DataNavigator1.Name = "DataNavigator1"
        Me.DataNavigator1.Size = New System.Drawing.Size(192, 24)
        Me.DataNavigator1.TabIndex = 5
        Me.DataNavigator1.Text = "DataNavigator1"
        '
        'PkgSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(551, 314)
        Me.Controls.Add(Me.DataNavigator1)
        Me.Controls.Add(Me.GridControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PkgSelect"
        Me.ShowInTaskbar = False
        Me.Text = "Package Filter"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DataNavigator1 As DevExpress.XtraEditors.DataNavigator
End Class
