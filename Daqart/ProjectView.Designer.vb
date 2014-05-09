<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectView
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.lblProject = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbx_PrjStatus = New System.Windows.Forms.TextBox
        Me.tbx_ReqdMhrs = New System.Windows.Forms.TextBox
        Me.tbx_EarnedMhrs = New System.Windows.Forms.TextBox
        Me.tbx_PercntComplete = New System.Windows.Forms.TextBox
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cbx_ExportType = New System.Windows.Forms.ToolStripComboBox
        Me.MenuStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ProjectToolStripMenuItem, Me.ToolStripMenuItem1, Me.cbx_ExportType})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(758, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_PercntComplete)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_EarnedMhrs)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_ReqdMhrs)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_PrjStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblProject)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(755, 453)
        Me.SplitContainer1.SplitterDistance = 116
        Me.SplitContainer1.TabIndex = 1
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(755, 333)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'lblProject
        '
        Me.lblProject.AutoSize = True
        Me.lblProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProject.Location = New System.Drawing.Point(12, 17)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(77, 25)
        Me.lblProject.TabIndex = 0
        Me.lblProject.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(390, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Project Status"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(377, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Reqd. Manhours"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(372, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Earned Manhours"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(401, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "% Complete"
        '
        'tbx_PrjStatus
        '
        Me.tbx_PrjStatus.Location = New System.Drawing.Point(469, 14)
        Me.tbx_PrjStatus.Name = "tbx_PrjStatus"
        Me.tbx_PrjStatus.Size = New System.Drawing.Size(100, 20)
        Me.tbx_PrjStatus.TabIndex = 5
        '
        'tbx_ReqdMhrs
        '
        Me.tbx_ReqdMhrs.Location = New System.Drawing.Point(469, 34)
        Me.tbx_ReqdMhrs.Name = "tbx_ReqdMhrs"
        Me.tbx_ReqdMhrs.Size = New System.Drawing.Size(100, 20)
        Me.tbx_ReqdMhrs.TabIndex = 6
        '
        'tbx_EarnedMhrs
        '
        Me.tbx_EarnedMhrs.Location = New System.Drawing.Point(469, 54)
        Me.tbx_EarnedMhrs.Name = "tbx_EarnedMhrs"
        Me.tbx_EarnedMhrs.Size = New System.Drawing.Size(100, 20)
        Me.tbx_EarnedMhrs.TabIndex = 7
        '
        'tbx_PercntComplete
        '
        Me.tbx_PercntComplete.Location = New System.Drawing.Point(469, 74)
        Me.tbx_PercntComplete.Name = "tbx_PercntComplete"
        Me.tbx_PercntComplete.Size = New System.Drawing.Size(100, 20)
        Me.tbx_PercntComplete.TabIndex = 8
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 21)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ProjectToolStripMenuItem
        '
        Me.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem"
        Me.ProjectToolStripMenuItem.Size = New System.Drawing.Size(41, 21)
        Me.ProjectToolStripMenuItem.Text = "Print"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(51, 21)
        Me.ToolStripMenuItem1.Text = "Export"
        '
        'cbx_ExportType
        '
        Me.cbx_ExportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ExportType.Items.AddRange(New Object() {"HTML", "PDF", "Text", "Xls"})
        Me.cbx_ExportType.Name = "cbx_ExportType"
        Me.cbx_ExportType.Size = New System.Drawing.Size(121, 21)
        '
        'ProjectView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 478)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ProjectView"
        Me.Text = "ProjectView"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents tbx_PercntComplete As System.Windows.Forms.TextBox
    Friend WithEvents tbx_EarnedMhrs As System.Windows.Forms.TextBox
    Friend WithEvents tbx_ReqdMhrs As System.Windows.Forms.TextBox
    Friend WithEvents tbx_PrjStatus As System.Windows.Forms.TextBox
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbx_ExportType As System.Windows.Forms.ToolStripComboBox
End Class
