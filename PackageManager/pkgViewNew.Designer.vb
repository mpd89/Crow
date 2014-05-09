<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pkgViewNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pkgViewNew))
        Me.AuxMoveLeftAll = New System.Windows.Forms.Button
        Me.AuxMoveLeft = New System.Windows.Forms.Button
        Me.AuxMoveRightAll = New System.Windows.Forms.Button
        Me.AuxMoveRight = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label16 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.EditMapButton = New System.Windows.Forms.Button
        Me.BtnApplyChanges = New System.Windows.Forms.Button
        Me.lvwMapFile = New System.Windows.Forms.ListView
        Me.Label12 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'AuxMoveLeftAll
        '
        Me.AuxMoveLeftAll.Location = New System.Drawing.Point(254, 401)
        Me.AuxMoveLeftAll.Name = "AuxMoveLeftAll"
        Me.AuxMoveLeftAll.Size = New System.Drawing.Size(28, 19)
        Me.AuxMoveLeftAll.TabIndex = 80
        Me.AuxMoveLeftAll.Text = "<<"
        Me.AuxMoveLeftAll.UseVisualStyleBackColor = True
        '
        'AuxMoveLeft
        '
        Me.AuxMoveLeft.Location = New System.Drawing.Point(288, 401)
        Me.AuxMoveLeft.Name = "AuxMoveLeft"
        Me.AuxMoveLeft.Size = New System.Drawing.Size(28, 19)
        Me.AuxMoveLeft.TabIndex = 81
        Me.AuxMoveLeft.Text = "<"
        Me.AuxMoveLeft.UseVisualStyleBackColor = True
        '
        'AuxMoveRightAll
        '
        Me.AuxMoveRightAll.Location = New System.Drawing.Point(363, 401)
        Me.AuxMoveRightAll.Name = "AuxMoveRightAll"
        Me.AuxMoveRightAll.Size = New System.Drawing.Size(28, 19)
        Me.AuxMoveRightAll.TabIndex = 82
        Me.AuxMoveRightAll.Text = ">>"
        Me.AuxMoveRightAll.UseVisualStyleBackColor = True
        '
        'AuxMoveRight
        '
        Me.AuxMoveRight.Location = New System.Drawing.Point(329, 401)
        Me.AuxMoveRight.Name = "AuxMoveRight"
        Me.AuxMoveRight.Size = New System.Drawing.Size(28, 19)
        Me.AuxMoveRight.TabIndex = 79
        Me.AuxMoveRight.Text = ">"
        Me.AuxMoveRight.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(12, 33)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(901, 362)
        Me.TabControl1.TabIndex = 83
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(893, 336)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Form View"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(893, 336)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Serch/Filter"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(191, 307)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Clear filter"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select filter criteria"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(57, 307)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Go"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.btnCancel)
        Me.TabPage3.Controls.Add(Me.Button3)
        Me.TabPage3.Controls.Add(Me.EditMapButton)
        Me.TabPage3.Controls.Add(Me.BtnApplyChanges)
        Me.TabPage3.Controls.Add(Me.lvwMapFile)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(893, 336)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Field Attributes"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(97, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(134, 24)
        Me.Label16.TabIndex = 101
        Me.Label16.Text = "Field Attributes"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(495, 260)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 23)
        Me.btnCancel.TabIndex = 100
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(149, 260)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(98, 23)
        Me.Button3.TabIndex = 99
        Me.Button3.Text = "Add New Field"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'EditMapButton
        '
        Me.EditMapButton.Location = New System.Drawing.Point(254, 260)
        Me.EditMapButton.Name = "EditMapButton"
        Me.EditMapButton.Size = New System.Drawing.Size(117, 23)
        Me.EditMapButton.TabIndex = 98
        Me.EditMapButton.Text = "Edit Field Attributes"
        Me.EditMapButton.UseVisualStyleBackColor = True
        '
        'BtnApplyChanges
        '
        Me.BtnApplyChanges.Location = New System.Drawing.Point(378, 260)
        Me.BtnApplyChanges.Name = "BtnApplyChanges"
        Me.BtnApplyChanges.Size = New System.Drawing.Size(110, 23)
        Me.BtnApplyChanges.TabIndex = 97
        Me.BtnApplyChanges.Text = "Apply Changes"
        Me.BtnApplyChanges.UseVisualStyleBackColor = True
        '
        'lvwMapFile
        '
        Me.lvwMapFile.Location = New System.Drawing.Point(101, 81)
        Me.lvwMapFile.Name = "lvwMapFile"
        Me.lvwMapFile.Size = New System.Drawing.Size(535, 173)
        Me.lvwMapFile.TabIndex = 96
        Me.lvwMapFile.UseCompatibleStateImageBehavior = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(110, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 13)
        Me.Label12.TabIndex = 95
        Me.Label12.Text = "Visible Field Attributes"
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(893, 336)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Reports"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(70, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 24)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Pkg View"
        '
        'pkgViewNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 586)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.AuxMoveLeftAll)
        Me.Controls.Add(Me.AuxMoveLeft)
        Me.Controls.Add(Me.AuxMoveRightAll)
        Me.Controls.Add(Me.AuxMoveRight)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "pkgViewNew"
        Me.Text = "pkgViewNew"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AuxMoveLeftAll As System.Windows.Forms.Button
    Friend WithEvents AuxMoveLeft As System.Windows.Forms.Button
    Friend WithEvents AuxMoveRightAll As System.Windows.Forms.Button
    Friend WithEvents AuxMoveRight As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents EditMapButton As System.Windows.Forms.Button
    Friend WithEvents BtnApplyChanges As System.Windows.Forms.Button
    Friend WithEvents lvwMapFile As System.Windows.Forms.ListView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
