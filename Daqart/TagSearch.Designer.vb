<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagSearch
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode
        Me.OK_Button = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(389, 16)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Search"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Begins with", "Contains", "Ends with"})
        Me.ComboBox1.Location = New System.Drawing.Point(2, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(82, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(90, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(283, 20)
        Me.TextBox1.TabIndex = 2
        '
        'GridControl2
        '
        Me.GridControl2.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl2.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl2.EmbeddedNavigator.Name = ""
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl2.Location = New System.Drawing.Point(53, 30)
        Me.GridControl2.MainView = Me.GridView4
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(243, 21)
        Me.GridControl2.TabIndex = 20
        Me.GridControl2.UseEmbeddedNavigator = True
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.GridControl2
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.Editable = False
        '
        'TagSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 58)
        Me.Controls.Add(Me.GridControl2)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TagSearch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TagSearch"
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView

End Class
