<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MERequirement
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbx_BaseMH = New System.Windows.Forms.TextBox
        Me.tbx_ElementMH = New System.Windows.Forms.TextBox
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Form Base Manhours"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Element Manhours"
        '
        'tbx_BaseMH
        '
        Me.tbx_BaseMH.Location = New System.Drawing.Point(153, 30)
        Me.tbx_BaseMH.Name = "tbx_BaseMH"
        Me.tbx_BaseMH.Size = New System.Drawing.Size(100, 20)
        Me.tbx_BaseMH.TabIndex = 2
        '
        'tbx_ElementMH
        '
        Me.tbx_ElementMH.Location = New System.Drawing.Point(153, 60)
        Me.tbx_ElementMH.Name = "tbx_ElementMH"
        Me.tbx_ElementMH.Size = New System.Drawing.Size(100, 20)
        Me.tbx_ElementMH.TabIndex = 3
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(214, 101)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 4
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(133, 101)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 5
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'MERequirement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 141)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.tbx_ElementMH)
        Me.Controls.Add(Me.tbx_BaseMH)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "MERequirement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Multi-Element Requirement"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbx_BaseMH As System.Windows.Forms.TextBox
    Friend WithEvents tbx_ElementMH As System.Windows.Forms.TextBox
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
End Class
