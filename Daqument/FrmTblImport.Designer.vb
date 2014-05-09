<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTblImport
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnUploadPkgNums = New System.Windows.Forms.Button
        Me.fileName = New System.Windows.Forms.TextBox
        Me.btnImportWeldersList = New System.Windows.Forms.Button
        Me.lblImport = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnUploadPkgNums)
        Me.SplitContainer1.Panel1.Controls.Add(Me.fileName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnImportWeldersList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblImport)
        Me.SplitContainer1.Panel1MinSize = 300
        Me.SplitContainer1.Size = New System.Drawing.Size(869, 584)
        Me.SplitContainer1.SplitterDistance = 319
        Me.SplitContainer1.TabIndex = 3
        '
        'btnUploadPkgNums
        '
        Me.btnUploadPkgNums.Location = New System.Drawing.Point(429, 283)
        Me.btnUploadPkgNums.Name = "btnUploadPkgNums"
        Me.btnUploadPkgNums.Size = New System.Drawing.Size(123, 20)
        Me.btnUploadPkgNums.TabIndex = 140
        Me.btnUploadPkgNums.Text = "Upload"
        Me.btnUploadPkgNums.UseVisualStyleBackColor = True
        '
        'fileName
        '
        Me.fileName.Location = New System.Drawing.Point(34, 283)
        Me.fileName.Name = "fileName"
        Me.fileName.Size = New System.Drawing.Size(200, 20)
        Me.fileName.TabIndex = 138
        '
        'btnImportWeldersList
        '
        Me.btnImportWeldersList.Location = New System.Drawing.Point(258, 283)
        Me.btnImportWeldersList.Name = "btnImportWeldersList"
        Me.btnImportWeldersList.Size = New System.Drawing.Size(123, 20)
        Me.btnImportWeldersList.TabIndex = 137
        Me.btnImportWeldersList.Text = "Import from CSV File"
        Me.btnImportWeldersList.UseVisualStyleBackColor = True
        '
        'lblImport
        '
        Me.lblImport.AutoSize = True
        Me.lblImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImport.Location = New System.Drawing.Point(30, -1)
        Me.lblImport.Name = "lblImport"
        Me.lblImport.Size = New System.Drawing.Size(71, 24)
        Me.lblImport.TabIndex = 1
        Me.lblImport.Text = "Imports"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 562)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(869, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(562, 17)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "Selected Document Description goes here."
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(88, 17)
        Me.ToolStripStatusLabel1.Text = "Category: None"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(102, 17)
        Me.ToolStripStatusLabel2.Text = "Document 1 of 109"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'FrmTblImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 584)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmTblImport"
        Me.Text = "FrmTblImport"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnUploadPkgNums As System.Windows.Forms.Button
    Friend WithEvents fileName As System.Windows.Forms.TextBox
    Friend WithEvents btnImportWeldersList As System.Windows.Forms.Button
    Friend WithEvents lblImport As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
End Class
