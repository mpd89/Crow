<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraGridPrinting
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraGridPrinting))
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.lblHeader = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdb_Email = New System.Windows.Forms.RadioButton
        Me.rdb_HTML = New System.Windows.Forms.RadioButton
        Me.rdb_Xls = New System.Windows.Forms.RadioButton
        Me.rdb_PDF = New System.Windows.Forms.RadioButton
        Me.rdb_Print = New System.Windows.Forms.RadioButton
        Me.rdb_PrintPreview = New System.Windows.Forms.RadioButton
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.CustomPaperSize = New System.Drawing.Size(0, 0)
        Me.PrintableComponentLink1.ImageStream = CType(resources.GetObject("PrintableComponentLink1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.PrintableComponentLink1.PrintingSystem = Me.PrintingSystem1
        Me.PrintableComponentLink1.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(30, 27)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(77, 25)
        Me.lblHeader.TabIndex = 32
        Me.lblHeader.Text = "Label1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(105, 234)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 25
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
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdb_Email)
        Me.GroupBox1.Controls.Add(Me.rdb_HTML)
        Me.GroupBox1.Controls.Add(Me.rdb_Xls)
        Me.GroupBox1.Controls.Add(Me.rdb_PDF)
        Me.GroupBox1.Controls.Add(Me.rdb_Print)
        Me.GroupBox1.Controls.Add(Me.rdb_PrintPreview)
        Me.GroupBox1.Location = New System.Drawing.Point(88, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(136, 156)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        '
        'rdb_Email
        '
        Me.rdb_Email.AutoSize = True
        Me.rdb_Email.Location = New System.Drawing.Point(6, 126)
        Me.rdb_Email.Name = "rdb_Email"
        Me.rdb_Email.Size = New System.Drawing.Size(49, 17)
        Me.rdb_Email.TabIndex = 5
        Me.rdb_Email.TabStop = True
        Me.rdb_Email.Text = "Email"
        Me.rdb_Email.UseVisualStyleBackColor = True
        '
        'rdb_HTML
        '
        Me.rdb_HTML.AutoSize = True
        Me.rdb_HTML.Location = New System.Drawing.Point(6, 105)
        Me.rdb_HTML.Name = "rdb_HTML"
        Me.rdb_HTML.Size = New System.Drawing.Size(51, 17)
        Me.rdb_HTML.TabIndex = 4
        Me.rdb_HTML.TabStop = True
        Me.rdb_HTML.Text = "HTML"
        Me.rdb_HTML.UseVisualStyleBackColor = True
        '
        'rdb_Xls
        '
        Me.rdb_Xls.AutoSize = True
        Me.rdb_Xls.Location = New System.Drawing.Point(6, 84)
        Me.rdb_Xls.Name = "rdb_Xls"
        Me.rdb_Xls.Size = New System.Drawing.Size(38, 17)
        Me.rdb_Xls.TabIndex = 3
        Me.rdb_Xls.TabStop = True
        Me.rdb_Xls.Text = "Xls"
        Me.rdb_Xls.UseVisualStyleBackColor = True
        '
        'rdb_PDF
        '
        Me.rdb_PDF.AutoSize = True
        Me.rdb_PDF.Location = New System.Drawing.Point(6, 63)
        Me.rdb_PDF.Name = "rdb_PDF"
        Me.rdb_PDF.Size = New System.Drawing.Size(44, 17)
        Me.rdb_PDF.TabIndex = 2
        Me.rdb_PDF.TabStop = True
        Me.rdb_PDF.Text = "PDF"
        Me.rdb_PDF.UseVisualStyleBackColor = True
        '
        'rdb_Print
        '
        Me.rdb_Print.AutoSize = True
        Me.rdb_Print.Location = New System.Drawing.Point(6, 42)
        Me.rdb_Print.Name = "rdb_Print"
        Me.rdb_Print.Size = New System.Drawing.Size(47, 17)
        Me.rdb_Print.TabIndex = 1
        Me.rdb_Print.TabStop = True
        Me.rdb_Print.Text = "Print"
        Me.rdb_Print.UseVisualStyleBackColor = True
        '
        'rdb_PrintPreview
        '
        Me.rdb_PrintPreview.AutoSize = True
        Me.rdb_PrintPreview.Checked = True
        Me.rdb_PrintPreview.Location = New System.Drawing.Point(6, 21)
        Me.rdb_PrintPreview.Name = "rdb_PrintPreview"
        Me.rdb_PrintPreview.Size = New System.Drawing.Size(88, 17)
        Me.rdb_PrintPreview.TabIndex = 0
        Me.rdb_PrintPreview.TabStop = True
        Me.rdb_PrintPreview.Text = "Print Preview"
        Me.rdb_PrintPreview.UseVisualStyleBackColor = True
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(127, 12)
        Me.GridControl1.MainView = Me.GridView2
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(179, 123)
        Me.GridControl1.TabIndex = 34
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        Me.GridControl1.Visible = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        '
        'XtraGridPrinting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 263)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblHeader)
        Me.Name = "XtraGridPrinting"
        Me.Text = "XtraPrinting"
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_Email As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_HTML As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_Xls As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_PDF As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_Print As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_PrintPreview As System.Windows.Forms.RadioButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
