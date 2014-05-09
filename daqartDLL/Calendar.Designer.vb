<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calendar
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
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
        Me.Button1 = New System.Windows.Forms.Button
        Me.txt_Date = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(0, -1)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(65, 166)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt_Date
        '
        Me.txt_Date.Location = New System.Drawing.Point(137, 152)
        Me.txt_Date.Name = "txt_Date"
        Me.txt_Date.Size = New System.Drawing.Size(97, 20)
        Me.txt_Date.TabIndex = 2
        Me.txt_Date.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 166)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(47, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(118, 166)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Calendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(178, 198)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txt_Date)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Calendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_Date As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
