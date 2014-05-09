<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddDiscrepancy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddDiscrepancy))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtManHours = New System.Windows.Forms.TextBox
        Me.txtResolution = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.lblPackageID = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(255, 408)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 57
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(336, 408)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 56
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtManHours
        '
        Me.txtManHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtManHours.Location = New System.Drawing.Point(12, 368)
        Me.txtManHours.Name = "txtManHours"
        Me.txtManHours.Size = New System.Drawing.Size(130, 20)
        Me.txtManHours.TabIndex = 49
        '
        'txtResolution
        '
        Me.txtResolution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResolution.Location = New System.Drawing.Point(12, 204)
        Me.txtResolution.Multiline = True
        Me.txtResolution.Name = "txtResolution"
        Me.txtResolution.Size = New System.Drawing.Size(399, 146)
        Me.txtResolution.TabIndex = 35
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Location = New System.Drawing.Point(12, 69)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(399, 117)
        Me.txtDescription.TabIndex = 33
        '
        'txtTitle
        '
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTitle.Location = New System.Drawing.Point(141, 31)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(270, 20)
        Me.txtTitle.TabIndex = 32
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(130, 20)
        Me.TextBox1.TabIndex = 58
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "PackageID"
        '
        'lblPackageID
        '
        Me.lblPackageID.BackColor = System.Drawing.SystemColors.Window
        Me.lblPackageID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPackageID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPackageID.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblPackageID.Location = New System.Drawing.Point(12, 31)
        Me.lblPackageID.Name = "lblPackageID"
        Me.lblPackageID.ReadOnly = True
        Me.lblPackageID.Size = New System.Drawing.Size(130, 20)
        Me.lblPackageID.TabIndex = 59
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(141, 12)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(270, 20)
        Me.TextBox2.TabIndex = 60
        Me.TextBox2.Text = "Title"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Location = New System.Drawing.Point(12, 50)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(399, 20)
        Me.TextBox3.TabIndex = 61
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = "Description"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Location = New System.Drawing.Point(12, 185)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(399, 20)
        Me.TextBox4.TabIndex = 62
        Me.TextBox4.TabStop = False
        Me.TextBox4.Text = "Resolution"
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.Location = New System.Drawing.Point(12, 349)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(130, 20)
        Me.TextBox5.TabIndex = 63
        Me.TextBox5.Text = "Scope Impact"
        '
        'frmAddDiscrepancy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(424, 445)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.lblPackageID)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtManHours)
        Me.Controls.Add(Me.txtResolution)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddDiscrepancy"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Discrepancy"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtManHours As System.Windows.Forms.TextBox
    Friend WithEvents txtResolution As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblPackageID As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
End Class
