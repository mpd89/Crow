<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomMenu
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tlp_Custom1 = New System.Windows.Forms.TableLayoutPanel
        Me.pbx_Custom1 = New System.Windows.Forms.PictureBox
        Me.tbx_Custom1 = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.tlp_Custom1.SuspendLayout()
        CType(Me.pbx_Custom1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 493)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(734, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(734, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.tlp_Custom1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(734, 468)
        Me.Panel1.TabIndex = 3
        '
        'tlp_Custom1
        '
        Me.tlp_Custom1.BackColor = System.Drawing.SystemColors.Window
        Me.tlp_Custom1.ColumnCount = 1
        Me.tlp_Custom1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Custom1.Controls.Add(Me.pbx_Custom1, 0, 0)
        Me.tlp_Custom1.Controls.Add(Me.tbx_Custom1, 0, 1)
        Me.tlp_Custom1.Location = New System.Drawing.Point(3, 3)
        Me.tlp_Custom1.Name = "tlp_Custom1"
        Me.tlp_Custom1.RowCount = 2
        Me.tlp_Custom1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.33333!))
        Me.tlp_Custom1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.66667!))
        Me.tlp_Custom1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_Custom1.Size = New System.Drawing.Size(69, 90)
        Me.tlp_Custom1.TabIndex = 14
        '
        'pbx_Custom1
        '
        Me.pbx_Custom1.BackColor = System.Drawing.SystemColors.Window
        Me.pbx_Custom1.Image = Global.CustomMods.My.Resources.Resources.Report_Document_1
        Me.pbx_Custom1.Location = New System.Drawing.Point(3, 3)
        Me.pbx_Custom1.Name = "pbx_Custom1"
        Me.pbx_Custom1.Size = New System.Drawing.Size(63, 50)
        Me.pbx_Custom1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbx_Custom1.TabIndex = 8
        Me.pbx_Custom1.TabStop = False
        '
        'tbx_Custom1
        '
        Me.tbx_Custom1.BackColor = System.Drawing.SystemColors.Window
        Me.tbx_Custom1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbx_Custom1.Enabled = False
        Me.tbx_Custom1.Location = New System.Drawing.Point(3, 59)
        Me.tbx_Custom1.Multiline = True
        Me.tbx_Custom1.Name = "tbx_Custom1"
        Me.tbx_Custom1.ReadOnly = True
        Me.tbx_Custom1.Size = New System.Drawing.Size(63, 27)
        Me.tbx_Custom1.TabIndex = 9
        Me.tbx_Custom1.TabStop = False
        Me.tbx_Custom1.Text = "Export 1"
        Me.tbx_Custom1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CustomMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 515)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MaximizeBox = False
        Me.Name = "CustomMenu"
        Me.ShowIcon = False
        Me.Text = "Custom Mods"
        Me.Panel1.ResumeLayout(False)
        Me.tlp_Custom1.ResumeLayout(False)
        Me.tlp_Custom1.PerformLayout()
        CType(Me.pbx_Custom1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tlp_Custom1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbx_Custom1 As System.Windows.Forms.PictureBox
    Friend WithEvents tbx_Custom1 As System.Windows.Forms.TextBox
End Class
