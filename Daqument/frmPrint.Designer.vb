<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint
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
        Me.button1 = New System.Windows.Forms.Button
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.txtspacerows = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.txtspacecols = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.txtrows = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.txtcols = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.txtendpage = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.txtstartpage = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.chkprintall = New System.Windows.Forms.CheckBox
        Me.chkoutline = New System.Windows.Forms.CheckBox
        Me.chkstretch = New System.Windows.Forms.CheckBox
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.opthorzalignright = New System.Windows.Forms.RadioButton
        Me.opthorzaligncenter = New System.Windows.Forms.RadioButton
        Me.opthorzalignleft = New System.Windows.Forms.RadioButton
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.optvertalignbottom = New System.Windows.Forms.RadioButton
        Me.optvertaligncenter = New System.Windows.Forms.RadioButton
        Me.optvertaligntop = New System.Windows.Forms.RadioButton
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(458, 493)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(88, 32)
        Me.button1.TabIndex = 11
        Me.button1.Text = "OK"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.txtspacerows)
        Me.groupBox3.Controls.Add(Me.label6)
        Me.groupBox3.Controls.Add(Me.txtspacecols)
        Me.groupBox3.Controls.Add(Me.label5)
        Me.groupBox3.Controls.Add(Me.txtrows)
        Me.groupBox3.Controls.Add(Me.label4)
        Me.groupBox3.Controls.Add(Me.txtcols)
        Me.groupBox3.Controls.Add(Me.label3)
        Me.groupBox3.Controls.Add(Me.txtendpage)
        Me.groupBox3.Controls.Add(Me.label2)
        Me.groupBox3.Controls.Add(Me.txtstartpage)
        Me.groupBox3.Controls.Add(Me.label1)
        Me.groupBox3.Controls.Add(Me.chkprintall)
        Me.groupBox3.Location = New System.Drawing.Point(130, 229)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(432, 248)
        Me.groupBox3.TabIndex = 10
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Page Control"
        '
        'txtspacerows
        '
        Me.txtspacerows.Location = New System.Drawing.Point(288, 208)
        Me.txtspacerows.Name = "txtspacerows"
        Me.txtspacerows.Size = New System.Drawing.Size(64, 20)
        Me.txtspacerows.TabIndex = 12
        Me.txtspacerows.Text = "10"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(8, 208)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(136, 32)
        Me.label6.TabIndex = 11
        Me.label6.Text = "Space of vertically  (mm)"
        '
        'txtspacecols
        '
        Me.txtspacecols.Location = New System.Drawing.Point(288, 176)
        Me.txtspacecols.Name = "txtspacecols"
        Me.txtspacecols.Size = New System.Drawing.Size(64, 20)
        Me.txtspacecols.TabIndex = 10
        Me.txtspacecols.Text = "10"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(8, 176)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(184, 24)
        Me.label5.TabIndex = 9
        Me.label5.Text = "Space of horizontally  (mm)"
        '
        'txtrows
        '
        Me.txtrows.Location = New System.Drawing.Point(288, 144)
        Me.txtrows.Name = "txtrows"
        Me.txtrows.Size = New System.Drawing.Size(64, 20)
        Me.txtrows.TabIndex = 8
        Me.txtrows.Text = "1"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(8, 144)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(240, 32)
        Me.label4.TabIndex = 7
        Me.label4.Text = "Sets the number of pages displayed vertically"
        '
        'txtcols
        '
        Me.txtcols.Location = New System.Drawing.Point(288, 112)
        Me.txtcols.Name = "txtcols"
        Me.txtcols.Size = New System.Drawing.Size(64, 20)
        Me.txtcols.TabIndex = 6
        Me.txtcols.Text = "1"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(8, 112)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(264, 24)
        Me.label3.TabIndex = 5
        Me.label3.Text = "Sets the number of pages displayed horizontally"
        '
        'txtendpage
        '
        Me.txtendpage.Location = New System.Drawing.Point(288, 64)
        Me.txtendpage.Name = "txtendpage"
        Me.txtendpage.Size = New System.Drawing.Size(64, 20)
        Me.txtendpage.TabIndex = 4
        Me.txtendpage.Text = "1"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(192, 64)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(80, 16)
        Me.label2.TabIndex = 3
        Me.label2.Text = "End Page No"
        '
        'txtstartpage
        '
        Me.txtstartpage.Location = New System.Drawing.Point(112, 64)
        Me.txtstartpage.Name = "txtstartpage"
        Me.txtstartpage.Size = New System.Drawing.Size(64, 20)
        Me.txtstartpage.TabIndex = 2
        Me.txtstartpage.Text = "1"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(16, 64)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(80, 24)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Start Page No"
        '
        'chkprintall
        '
        Me.chkprintall.Checked = True
        Me.chkprintall.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkprintall.Location = New System.Drawing.Point(16, 24)
        Me.chkprintall.Name = "chkprintall"
        Me.chkprintall.Size = New System.Drawing.Size(120, 16)
        Me.chkprintall.TabIndex = 0
        Me.chkprintall.Text = "Print All Pages"
        '
        'chkoutline
        '
        Me.chkoutline.Location = New System.Drawing.Point(266, 181)
        Me.chkoutline.Name = "chkoutline"
        Me.chkoutline.Size = New System.Drawing.Size(136, 24)
        Me.chkoutline.TabIndex = 9
        Me.chkoutline.Text = "Show Outline Box"
        '
        'chkstretch
        '
        Me.chkstretch.Location = New System.Drawing.Point(130, 181)
        Me.chkstretch.Name = "chkstretch"
        Me.chkstretch.Size = New System.Drawing.Size(112, 24)
        Me.chkstretch.TabIndex = 8
        Me.chkstretch.Text = "Stretch Image "
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.opthorzalignright)
        Me.groupBox2.Controls.Add(Me.opthorzaligncenter)
        Me.groupBox2.Controls.Add(Me.opthorzalignleft)
        Me.groupBox2.Location = New System.Drawing.Point(130, 101)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(408, 56)
        Me.groupBox2.TabIndex = 7
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Horizontal Alignment"
        '
        'opthorzalignright
        '
        Me.opthorzalignright.Location = New System.Drawing.Point(272, 24)
        Me.opthorzalignright.Name = "opthorzalignright"
        Me.opthorzalignright.Size = New System.Drawing.Size(72, 24)
        Me.opthorzalignright.TabIndex = 2
        Me.opthorzalignright.Text = "Right"
        '
        'opthorzaligncenter
        '
        Me.opthorzaligncenter.Checked = True
        Me.opthorzaligncenter.Location = New System.Drawing.Point(152, 24)
        Me.opthorzaligncenter.Name = "opthorzaligncenter"
        Me.opthorzaligncenter.Size = New System.Drawing.Size(56, 24)
        Me.opthorzaligncenter.TabIndex = 1
        Me.opthorzaligncenter.TabStop = True
        Me.opthorzaligncenter.Text = "Center"
        '
        'opthorzalignleft
        '
        Me.opthorzalignleft.Location = New System.Drawing.Point(24, 24)
        Me.opthorzalignleft.Name = "opthorzalignleft"
        Me.opthorzalignleft.Size = New System.Drawing.Size(56, 24)
        Me.opthorzalignleft.TabIndex = 0
        Me.opthorzalignleft.Text = "Left"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.optvertalignbottom)
        Me.groupBox1.Controls.Add(Me.optvertaligncenter)
        Me.groupBox1.Controls.Add(Me.optvertaligntop)
        Me.groupBox1.Location = New System.Drawing.Point(130, 21)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(408, 64)
        Me.groupBox1.TabIndex = 6
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Vertical Alignment"
        '
        'optvertalignbottom
        '
        Me.optvertalignbottom.Location = New System.Drawing.Point(272, 24)
        Me.optvertalignbottom.Name = "optvertalignbottom"
        Me.optvertalignbottom.Size = New System.Drawing.Size(96, 24)
        Me.optvertalignbottom.TabIndex = 2
        Me.optvertalignbottom.Text = "Bottom"
        '
        'optvertaligncenter
        '
        Me.optvertaligncenter.Checked = True
        Me.optvertaligncenter.Location = New System.Drawing.Point(152, 24)
        Me.optvertaligncenter.Name = "optvertaligncenter"
        Me.optvertaligncenter.Size = New System.Drawing.Size(56, 24)
        Me.optvertaligncenter.TabIndex = 1
        Me.optvertaligncenter.TabStop = True
        Me.optvertaligncenter.Text = "Center"
        '
        'optvertaligntop
        '
        Me.optvertaligntop.Location = New System.Drawing.Point(24, 24)
        Me.optvertaligntop.Name = "optvertaligntop"
        Me.optvertaligntop.Size = New System.Drawing.Size(48, 24)
        Me.optvertaligntop.TabIndex = 0
        Me.optvertaligntop.Text = "Top"
        '
        'frmPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 546)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.chkoutline)
        Me.Controls.Add(Me.chkstretch)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "frmPrint"
        Me.Text = "frmPrint"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents txtspacerows As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Public WithEvents txtspacecols As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Public WithEvents txtrows As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Public WithEvents txtcols As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Public WithEvents txtendpage As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Public WithEvents txtstartpage As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Public WithEvents chkprintall As System.Windows.Forms.CheckBox
    Public WithEvents chkoutline As System.Windows.Forms.CheckBox
    Public WithEvents chkstretch As System.Windows.Forms.CheckBox
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents opthorzalignright As System.Windows.Forms.RadioButton
    Public WithEvents opthorzaligncenter As System.Windows.Forms.RadioButton
    Public WithEvents opthorzalignleft As System.Windows.Forms.RadioButton
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents optvertalignbottom As System.Windows.Forms.RadioButton
    Public WithEvents optvertaligncenter As System.Windows.Forms.RadioButton
    Public WithEvents optvertaligntop As System.Windows.Forms.RadioButton
End Class
