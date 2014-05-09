<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SymbolsMain
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
        Me.lbx_Symbols = New System.Windows.Forms.ListBox
        Me.pbx_Preview = New System.Windows.Forms.PictureBox
        Me.btn_Add = New System.Windows.Forms.Button
        Me.btn_Edit = New System.Windows.Forms.Button
        Me.btn_Delete = New System.Windows.Forms.Button
        CType(Me.pbx_Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbx_Symbols
        '
        Me.lbx_Symbols.FormattingEnabled = True
        Me.lbx_Symbols.Location = New System.Drawing.Point(12, 12)
        Me.lbx_Symbols.Name = "lbx_Symbols"
        Me.lbx_Symbols.Size = New System.Drawing.Size(156, 251)
        Me.lbx_Symbols.TabIndex = 0
        '
        'pbx_Preview
        '
        Me.pbx_Preview.Location = New System.Drawing.Point(183, 12)
        Me.pbx_Preview.Name = "pbx_Preview"
        Me.pbx_Preview.Size = New System.Drawing.Size(161, 158)
        Me.pbx_Preview.TabIndex = 1
        Me.pbx_Preview.TabStop = False
        '
        'btn_Add
        '
        Me.btn_Add.Location = New System.Drawing.Point(183, 176)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(161, 23)
        Me.btn_Add.TabIndex = 2
        Me.btn_Add.Text = "Add"
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'btn_Edit
        '
        Me.btn_Edit.Enabled = False
        Me.btn_Edit.Location = New System.Drawing.Point(183, 205)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(161, 23)
        Me.btn_Edit.TabIndex = 3
        Me.btn_Edit.Text = "Edit"
        Me.btn_Edit.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Enabled = False
        Me.btn_Delete.Location = New System.Drawing.Point(183, 234)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(161, 23)
        Me.btn_Delete.TabIndex = 4
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'SymbolsMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 275)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_Edit)
        Me.Controls.Add(Me.btn_Add)
        Me.Controls.Add(Me.pbx_Preview)
        Me.Controls.Add(Me.lbx_Symbols)
        Me.MaximizeBox = False
        Me.Name = "SymbolsMain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daqart Symbols"
        CType(Me.pbx_Preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbx_Symbols As System.Windows.Forms.ListBox
    Friend WithEvents pbx_Preview As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Add As System.Windows.Forms.Button
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
End Class
