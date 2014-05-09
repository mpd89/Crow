<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubForm
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
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.btn_Save = New System.Windows.Forms.Button
        Me.dgv_FieldNames = New System.Windows.Forms.DataGridView
        Me.FieldName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.nud_Elements = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgv_FieldNames, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_Elements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(185, 400)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 0
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Location = New System.Drawing.Point(266, 400)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(75, 23)
        Me.btn_Save.TabIndex = 1
        Me.btn_Save.Text = "Save"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'dgv_FieldNames
        '
        Me.dgv_FieldNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_FieldNames.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FieldName})
        Me.dgv_FieldNames.Location = New System.Drawing.Point(28, 71)
        Me.dgv_FieldNames.Name = "dgv_FieldNames"
        Me.dgv_FieldNames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgv_FieldNames.Size = New System.Drawing.Size(313, 314)
        Me.dgv_FieldNames.TabIndex = 4
        '
        'FieldName
        '
        Me.FieldName.HeaderText = "FieldName"
        Me.FieldName.Name = "FieldName"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Enter element field names:"
        '
        'nud_Elements
        '
        Me.nud_Elements.Location = New System.Drawing.Point(286, 12)
        Me.nud_Elements.Name = "nud_Elements"
        Me.nud_Elements.Size = New System.Drawing.Size(55, 20)
        Me.nud_Elements.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(90, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Enter number of tag elements per page"
        '
        'SubForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 437)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nud_Elements)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgv_FieldNames)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Name = "SubForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Manage Sub Form"
        CType(Me.dgv_FieldNames, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_Elements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents dgv_FieldNames As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nud_Elements As System.Windows.Forms.NumericUpDown
    Friend WithEvents FieldName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
