<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadPDF
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
      Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
      Me.txtBrowse = New System.Windows.Forms.TextBox
      Me.btnbrowse = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnNext = New System.Windows.Forms.Button
      Me.OpenFD = New System.Windows.Forms.OpenFileDialog
      Me.lblTag = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'FolderBrowserDialog1
      '
      '
      'txtBrowse
      '
      Me.txtBrowse.Location = New System.Drawing.Point(99, 132)
      Me.txtBrowse.Name = "txtBrowse"
      Me.txtBrowse.Size = New System.Drawing.Size(176, 20)
      Me.txtBrowse.TabIndex = 0
      '
      'btnbrowse
      '
      Me.btnbrowse.Location = New System.Drawing.Point(298, 128)
      Me.btnbrowse.Name = "btnbrowse"
      Me.btnbrowse.Size = New System.Drawing.Size(75, 23)
      Me.btnbrowse.TabIndex = 1
      Me.btnbrowse.Text = "Browse"
      Me.btnbrowse.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.Location = New System.Drawing.Point(145, 177)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 2
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnNext
      '
      Me.btnNext.Enabled = False
      Me.btnNext.Location = New System.Drawing.Point(242, 177)
      Me.btnNext.Name = "btnNext"
      Me.btnNext.Size = New System.Drawing.Size(75, 23)
      Me.btnNext.TabIndex = 3
      Me.btnNext.Text = "Next"
      Me.btnNext.UseVisualStyleBackColor = True
      '
      'OpenFD
      '
      Me.OpenFD.FileName = "OpenFileDialog1"
      '
      'lblTag
      '
      Me.lblTag.AutoSize = True
      Me.lblTag.Location = New System.Drawing.Point(82, 232)
      Me.lblTag.Name = "lblTag"
      Me.lblTag.Size = New System.Drawing.Size(0, 13)
      Me.lblTag.TabIndex = 4
      Me.lblTag.Visible = False
      '
      'LoadPDF
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(443, 352)
      Me.Controls.Add(Me.lblTag)
      Me.Controls.Add(Me.btnNext)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnbrowse)
      Me.Controls.Add(Me.txtBrowse)
      Me.Name = "LoadPDF"
      Me.Text = "LoadPDF"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtBrowse As System.Windows.Forms.TextBox
    Friend WithEvents btnbrowse As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
   Friend WithEvents OpenFD As System.Windows.Forms.OpenFileDialog
   Friend WithEvents lblTag As System.Windows.Forms.Label
End Class
