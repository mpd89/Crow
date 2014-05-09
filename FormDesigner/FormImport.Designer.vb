<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImport
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
        Me.cbx_Projects = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbx_Forms = New System.Windows.Forms.ComboBox
        Me.btn_OK = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Project to import from:"
        '
        'cbx_Projects
        '
        Me.cbx_Projects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Projects.FormattingEnabled = True
        Me.cbx_Projects.Location = New System.Drawing.Point(204, 29)
        Me.cbx_Projects.Name = "cbx_Projects"
        Me.cbx_Projects.Size = New System.Drawing.Size(207, 21)
        Me.cbx_Projects.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Select Form to import:"
        '
        'cbx_Forms
        '
        Me.cbx_Forms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_Forms.Enabled = False
        Me.cbx_Forms.FormattingEnabled = True
        Me.cbx_Forms.Location = New System.Drawing.Point(204, 72)
        Me.cbx_Forms.Name = "cbx_Forms"
        Me.cbx_Forms.Size = New System.Drawing.Size(207, 21)
        Me.cbx_Forms.TabIndex = 3
        '
        'btn_OK
        '
        Me.btn_OK.Location = New System.Drawing.Point(339, 152)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_OK.TabIndex = 4
        Me.btn_OK.Text = "Import"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(240, 152)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 5
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'FormImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 194)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.cbx_Forms)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbx_Projects)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormImport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form Import"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbx_Projects As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbx_Forms As System.Windows.Forms.ComboBox
    Friend WithEvents btn_OK As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
End Class
