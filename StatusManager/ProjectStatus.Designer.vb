<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectStatus
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
        Me.btn_RunStatus = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_RunStatus
        '
        Me.btn_RunStatus.Location = New System.Drawing.Point(268, 145)
        Me.btn_RunStatus.Name = "btn_RunStatus"
        Me.btn_RunStatus.Size = New System.Drawing.Size(75, 23)
        Me.btn_RunStatus.TabIndex = 0
        Me.btn_RunStatus.Text = "Run Status"
        Me.btn_RunStatus.UseVisualStyleBackColor = True
        '
        'ProjectStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 202)
        Me.Controls.Add(Me.btn_RunStatus)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProjectStatus"
        Me.Text = "ProjectStatus"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_RunStatus As System.Windows.Forms.Button
End Class
