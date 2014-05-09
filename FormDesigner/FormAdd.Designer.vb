<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAdd
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
        Me.buttonOK = New System.Windows.Forms.Button
        Me.buttonCancel = New System.Windows.Forms.Button
        Me.buttonGetFile = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.formFile = New System.Windows.Forms.TextBox
        Me.formDescription = New System.Windows.Forms.TextBox
        Me.formName = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbx_MultiElement = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbx_System = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'buttonOK
        '
        Me.buttonOK.Enabled = False
        Me.buttonOK.Location = New System.Drawing.Point(305, 343)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(75, 23)
        Me.buttonOK.TabIndex = 19
        Me.buttonOK.Text = "OK"
        Me.buttonOK.UseVisualStyleBackColor = True
        '
        'buttonCancel
        '
        Me.buttonCancel.Location = New System.Drawing.Point(224, 343)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
        Me.buttonCancel.TabIndex = 18
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonGetFile
        '
        Me.buttonGetFile.Location = New System.Drawing.Point(344, 292)
        Me.buttonGetFile.Name = "buttonGetFile"
        Me.buttonGetFile.Size = New System.Drawing.Size(36, 20)
        Me.buttonGetFile.TabIndex = 17
        Me.buttonGetFile.Text = "..."
        Me.buttonGetFile.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 292)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Base File"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Form Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(350, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Please complete the form below to generate new form."
        '
        'formFile
        '
        Me.formFile.Location = New System.Drawing.Point(98, 292)
        Me.formFile.Name = "formFile"
        Me.formFile.Size = New System.Drawing.Size(240, 20)
        Me.formFile.TabIndex = 12
        '
        'formDescription
        '
        Me.formDescription.Location = New System.Drawing.Point(98, 96)
        Me.formDescription.Multiline = True
        Me.formDescription.Name = "formDescription"
        Me.formDescription.Size = New System.Drawing.Size(282, 82)
        Me.formDescription.TabIndex = 11
        '
        'formName
        '
        Me.formName.Location = New System.Drawing.Point(98, 60)
        Me.formName.Name = "formName"
        Me.formName.Size = New System.Drawing.Size(282, 20)
        Me.formName.TabIndex = 10
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(96, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Can the form have multiple tags?"
        '
        'cbx_MultiElement
        '
        Me.cbx_MultiElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_MultiElement.FormattingEnabled = True
        Me.cbx_MultiElement.Items.AddRange(New Object() {"No", "Yes"})
        Me.cbx_MultiElement.Location = New System.Drawing.Point(263, 243)
        Me.cbx_MultiElement.Name = "cbx_MultiElement"
        Me.cbx_MultiElement.Size = New System.Drawing.Size(75, 21)
        Me.cbx_MultiElement.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(96, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Is this a system form?"
        '
        'cbx_System
        '
        Me.cbx_System.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_System.Enabled = False
        Me.cbx_System.FormattingEnabled = True
        Me.cbx_System.Items.AddRange(New Object() {"No", "Yes"})
        Me.cbx_System.Location = New System.Drawing.Point(263, 200)
        Me.cbx_System.Name = "cbx_System"
        Me.cbx_System.Size = New System.Drawing.Size(75, 21)
        Me.cbx_System.TabIndex = 23
        '
        'FormAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 386)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbx_System)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbx_MultiElement)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.buttonOK)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonGetFile)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.formFile)
        Me.Controls.Add(Me.formDescription)
        Me.Controls.Add(Me.formName)
        Me.Name = "FormAdd"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buttonOK As System.Windows.Forms.Button
    Friend WithEvents buttonCancel As System.Windows.Forms.Button
    Friend WithEvents buttonGetFile As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents formFile As System.Windows.Forms.TextBox
    Friend WithEvents formDescription As System.Windows.Forms.TextBox
    Friend WithEvents formName As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbx_MultiElement As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbx_System As System.Windows.Forms.ComboBox
End Class
