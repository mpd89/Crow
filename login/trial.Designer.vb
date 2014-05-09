<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class trial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(trial))
        Me.StatusList = New System.Windows.Forms.CheckedListBox()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'StatusList
        '
        Me.StatusList.Enabled = False
        Me.StatusList.FormattingEnabled = True
        Me.StatusList.Items.AddRange(New Object() {"Create Daqart Server Agent", "Create Daqart Synchronization Share Folder", "Configure SQL Daqart Instance As Distributor", "Create Daqart ServerDB database", "Publish ServerDB", "Prepare ServerDB for Merge replication", "Create ServerDB PAL login account w/ access", "Create Daqument database", "Publish Daqument", "Prepare Daqument for Merge replication", "Create Daqument PAL login account w/ access"})
        Me.StatusList.Location = New System.Drawing.Point(413, 54)
        Me.StatusList.Name = "StatusList"
        Me.StatusList.ScrollAlwaysVisible = True
        Me.StatusList.Size = New System.Drawing.Size(332, 244)
        Me.StatusList.TabIndex = 28
        Me.StatusList.TabStop = False
        '
        'btnConfig
        '
        Me.btnConfig.Location = New System.Drawing.Point(669, 325)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(75, 23)
        Me.btnConfig.TabIndex = 24
        Me.btnConfig.Text = "Configure"
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(588, 325)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(413, 19)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(332, 35)
        Me.TextBox1.TabIndex = 27
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "This installer will configure SQL Server 2005 for use with the Daqart replication" & _
    " architecture."
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox2.Location = New System.Drawing.Point(12, 19)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(332, 92)
        Me.TextBox2.TabIndex = 29
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = resources.GetString("TextBox2.Text")
        '
        'trial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 380)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.StatusList)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "trial"
        Me.Text = "Daqart 2.0 Trial Version"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusList As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
End Class
