<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PkgExport
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboExportType = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataNavigator1 = New DevExpress.XtraEditors.DataNavigator
        Me.fileName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(502, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(12, 92)
        Me.GridControl1.LookAndFeel.SkinName = "Blue"
        Me.GridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(614, 280)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(205, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Select Export Type"
        '
        'cboExportType
        '
        Me.cboExportType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboExportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExportType.FormattingEnabled = True
        Me.cboExportType.Location = New System.Drawing.Point(208, 65)
        Me.cboExportType.Name = "cboExportType"
        Me.cboExportType.Size = New System.Drawing.Size(121, 21)
        Me.cboExportType.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 23)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Package Export"
        '
        'DataNavigator1
        '
        Me.DataNavigator1.Buttons.Append.Visible = False
        Me.DataNavigator1.Buttons.EndEdit.Visible = False
        Me.DataNavigator1.Buttons.Remove.Visible = False
        Me.DataNavigator1.Location = New System.Drawing.Point(370, 92)
        Me.DataNavigator1.LookAndFeel.SkinName = "Lilian"
        Me.DataNavigator1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.DataNavigator1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DataNavigator1.LookAndFeel.UseWindowsXPTheme = True
        Me.DataNavigator1.Name = "DataNavigator1"
        Me.DataNavigator1.Size = New System.Drawing.Size(192, 24)
        Me.DataNavigator1.TabIndex = 23
        Me.DataNavigator1.Text = "DataNavigator1"
        '
        'fileName
        '
        Me.fileName.Location = New System.Drawing.Point(370, 66)
        Me.fileName.Name = "fileName"
        Me.fileName.Size = New System.Drawing.Size(222, 20)
        Me.fileName.TabIndex = 95
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(367, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "File Name"
        '
        'PkgExport
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 399)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.fileName)
        Me.Controls.Add(Me.DataNavigator1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboExportType)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PkgExport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PkgExport"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboExportType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataNavigator1 As DevExpress.XtraEditors.DataNavigator
    Friend WithEvents fileName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
