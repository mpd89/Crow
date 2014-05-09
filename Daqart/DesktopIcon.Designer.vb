<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesktopIcon
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pbx_Icon = New System.Windows.Forms.PictureBox
        Me.tbx_Description = New System.Windows.Forms.TextBox
        CType(Me.pbx_Icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbx_Icon
        '
        Me.pbx_Icon.BackColor = System.Drawing.Color.Transparent
        Me.pbx_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbx_Icon.Location = New System.Drawing.Point(0, 0)
        Me.pbx_Icon.Name = "pbx_Icon"
        Me.pbx_Icon.Size = New System.Drawing.Size(64, 64)
        Me.pbx_Icon.TabIndex = 0
        Me.pbx_Icon.TabStop = False
        '
        'tbx_Description
        '
        Me.tbx_Description.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.tbx_Description.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbx_Description.Location = New System.Drawing.Point(1, 63)
        Me.tbx_Description.Multiline = True
        Me.tbx_Description.Name = "tbx_Description"
        Me.tbx_Description.ReadOnly = True
        Me.tbx_Description.Size = New System.Drawing.Size(63, 36)
        Me.tbx_Description.TabIndex = 1
        '
        'DesktopIcon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.tbx_Description)
        Me.Controls.Add(Me.pbx_Icon)
        Me.Name = "DesktopIcon"
        Me.Size = New System.Drawing.Size(64, 100)
        CType(Me.pbx_Icon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbx_Icon As System.Windows.Forms.PictureBox
    Friend WithEvents tbx_Description As System.Windows.Forms.TextBox

End Class
