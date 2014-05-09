<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PackageAuditStats
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbl_Total = New System.Windows.Forms.Label
        Me.lbl_Passed = New System.Windows.Forms.Label
        Me.lbl_Failed = New System.Windows.Forms.Label
        Me.lbl_NotAudited = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Packages:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(87, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Passed:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(94, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Failed:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(66, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Not Audited:"
        '
        'lbl_Total
        '
        Me.lbl_Total.AutoSize = True
        Me.lbl_Total.Location = New System.Drawing.Point(158, 19)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(22, 13)
        Me.lbl_Total.TabIndex = 4
        Me.lbl_Total.Text = "-----"
        '
        'lbl_Passed
        '
        Me.lbl_Passed.AutoSize = True
        Me.lbl_Passed.Location = New System.Drawing.Point(158, 50)
        Me.lbl_Passed.Name = "lbl_Passed"
        Me.lbl_Passed.Size = New System.Drawing.Size(22, 13)
        Me.lbl_Passed.TabIndex = 5
        Me.lbl_Passed.Text = "-----"
        '
        'lbl_Failed
        '
        Me.lbl_Failed.AutoSize = True
        Me.lbl_Failed.Location = New System.Drawing.Point(158, 80)
        Me.lbl_Failed.Name = "lbl_Failed"
        Me.lbl_Failed.Size = New System.Drawing.Size(22, 13)
        Me.lbl_Failed.TabIndex = 6
        Me.lbl_Failed.Text = "-----"
        '
        'lbl_NotAudited
        '
        Me.lbl_NotAudited.AutoSize = True
        Me.lbl_NotAudited.Location = New System.Drawing.Point(158, 108)
        Me.lbl_NotAudited.Name = "lbl_NotAudited"
        Me.lbl_NotAudited.Size = New System.Drawing.Size(22, 13)
        Me.lbl_NotAudited.TabIndex = 7
        Me.lbl_NotAudited.Text = "-----"
        '
        'PackageAuditStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 161)
        Me.Controls.Add(Me.lbl_NotAudited)
        Me.Controls.Add(Me.lbl_Failed)
        Me.Controls.Add(Me.lbl_Passed)
        Me.Controls.Add(Me.lbl_Total)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PackageAuditStats"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Package Audit Statistics"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents lbl_Passed As System.Windows.Forms.Label
    Friend WithEvents lbl_Failed As System.Windows.Forms.Label
    Friend WithEvents lbl_NotAudited As System.Windows.Forms.Label
End Class
