<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VersionUpdates
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
        Me.dgv_ClientUpdates = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbx_CurrentVersion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbx_RequiredVersion = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbx_Comments = New System.Windows.Forms.TextBox
        Me.btn_Update = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv_ClientUpdates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_Cancel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_Update)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_Comments)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_RequiredVersion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tbx_CurrentVersion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_ClientUpdates)
        Me.SplitContainer1.Size = New System.Drawing.Size(458, 353)
        Me.SplitContainer1.SplitterDistance = 198
        Me.SplitContainer1.TabIndex = 0
        '
        'dgv_ClientUpdates
        '
        Me.dgv_ClientUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ClientUpdates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ClientUpdates.Location = New System.Drawing.Point(0, 0)
        Me.dgv_ClientUpdates.Name = "dgv_ClientUpdates"
        Me.dgv_ClientUpdates.Size = New System.Drawing.Size(458, 151)
        Me.dgv_ClientUpdates.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(139, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Version Update"
        '
        'tbx_CurrentVersion
        '
        Me.tbx_CurrentVersion.Location = New System.Drawing.Point(61, 60)
        Me.tbx_CurrentVersion.Name = "tbx_CurrentVersion"
        Me.tbx_CurrentVersion.Size = New System.Drawing.Size(91, 20)
        Me.tbx_CurrentVersion.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Current Version"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Required Version"
        '
        'tbx_RequiredVersion
        '
        Me.tbx_RequiredVersion.Location = New System.Drawing.Point(61, 99)
        Me.tbx_RequiredVersion.Name = "tbx_RequiredVersion"
        Me.tbx_RequiredVersion.Size = New System.Drawing.Size(100, 20)
        Me.tbx_RequiredVersion.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Comments"
        '
        'tbx_Comments
        '
        Me.tbx_Comments.Location = New System.Drawing.Point(61, 138)
        Me.tbx_Comments.Multiline = True
        Me.tbx_Comments.Name = "tbx_Comments"
        Me.tbx_Comments.Size = New System.Drawing.Size(354, 57)
        Me.tbx_Comments.TabIndex = 7
        '
        'btn_Update
        '
        Me.btn_Update.Location = New System.Drawing.Point(290, 60)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(75, 23)
        Me.btn_Update.TabIndex = 8
        Me.btn_Update.Text = "Update"
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(371, 60)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 9
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'VersionUpdates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 353)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "VersionUpdates"
        Me.Text = "VersionUpdates"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv_ClientUpdates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tbx_CurrentVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_ClientUpdates As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbx_Comments As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbx_RequiredVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents btn_Update As System.Windows.Forms.Button
End Class
