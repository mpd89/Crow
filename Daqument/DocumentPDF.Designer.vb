<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentPDF
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnYes = New System.Windows.Forms.Button
        Me.btnNo = New System.Windows.Forms.Button
        Me.txtSource = New System.Windows.Forms.TextBox
        Me.WBPDf = New System.Windows.Forms.WebBrowser
        Me.lblTag = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 414)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 26)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Is this document correct?"
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(246, 455)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(75, 23)
        Me.btnYes.TabIndex = 2
        Me.btnYes.Text = "Yes"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.Location = New System.Drawing.Point(344, 455)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(75, 23)
        Me.btnNo.TabIndex = 3
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(543, 455)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(100, 20)
        Me.txtSource.TabIndex = 4
        Me.txtSource.Visible = False
        '
        'WBPDf
        '
        Me.WBPDf.Location = New System.Drawing.Point(71, 12)
        Me.WBPDf.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WBPDf.Name = "WBPDf"
        Me.WBPDf.Size = New System.Drawing.Size(590, 375)
        Me.WBPDf.TabIndex = 5
        '
        'lblTag
        '
        Me.lblTag.AutoSize = True
        Me.lblTag.Location = New System.Drawing.Point(656, 426)
        Me.lblTag.Name = "lblTag"
        Me.lblTag.Size = New System.Drawing.Size(0, 13)
        Me.lblTag.TabIndex = 6
        Me.lblTag.Visible = False
        '
        'DocumentPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 516)
        Me.Controls.Add(Me.lblTag)
        Me.Controls.Add(Me.WBPDf)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DocumentPDF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "DocumentPDF"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
   Friend WithEvents WBPDf As System.Windows.Forms.WebBrowser
   Friend WithEvents lblTag As System.Windows.Forms.Label
End Class
