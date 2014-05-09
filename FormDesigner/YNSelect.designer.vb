<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YNSelect
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
        Me.btn_Yes = New System.Windows.Forms.Button
        Me.btn_No = New System.Windows.Forms.Button
        Me.btn_NA = New System.Windows.Forms.Button
        Me.btn_Clear = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_Yes
        '
        Me.btn_Yes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Yes.Location = New System.Drawing.Point(29, 13)
        Me.btn_Yes.Name = "btn_Yes"
        Me.btn_Yes.Size = New System.Drawing.Size(140, 33)
        Me.btn_Yes.TabIndex = 0
        Me.btn_Yes.Text = "Yes"
        Me.btn_Yes.UseVisualStyleBackColor = True
        '
        'btn_No
        '
        Me.btn_No.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_No.Location = New System.Drawing.Point(29, 52)
        Me.btn_No.Name = "btn_No"
        Me.btn_No.Size = New System.Drawing.Size(140, 33)
        Me.btn_No.TabIndex = 1
        Me.btn_No.Text = "No"
        Me.btn_No.UseVisualStyleBackColor = True
        '
        'btn_NA
        '
        Me.btn_NA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_NA.Location = New System.Drawing.Point(29, 91)
        Me.btn_NA.Name = "btn_NA"
        Me.btn_NA.Size = New System.Drawing.Size(140, 33)
        Me.btn_NA.TabIndex = 2
        Me.btn_NA.Text = "N/A"
        Me.btn_NA.UseVisualStyleBackColor = True
        '
        'btn_Clear
        '
        Me.btn_Clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Clear.Location = New System.Drawing.Point(29, 171)
        Me.btn_Clear.Name = "btn_Clear"
        Me.btn_Clear.Size = New System.Drawing.Size(140, 33)
        Me.btn_Clear.TabIndex = 3
        Me.btn_Clear.Text = "Clear"
        Me.btn_Clear.UseVisualStyleBackColor = True
        '
        'YNSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(192, 238)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_Clear)
        Me.Controls.Add(Me.btn_NA)
        Me.Controls.Add(Me.btn_No)
        Me.Controls.Add(Me.btn_Yes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "YNSelect"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Value"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Yes As System.Windows.Forms.Button
    Friend WithEvents btn_No As System.Windows.Forms.Button
    Friend WithEvents btn_NA As System.Windows.Forms.Button
    Friend WithEvents btn_Clear As System.Windows.Forms.Button
End Class
