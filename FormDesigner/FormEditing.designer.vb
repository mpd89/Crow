<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEditing))
        Me.dwgPanel = New System.Windows.Forms.Panel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.stat_Main = New System.Windows.Forms.ToolStripStatusLabel
        Me.lab_XY = New System.Windows.Forms.ToolStripStatusLabel
        Me.tbr_Main = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnFirst = New System.Windows.Forms.ToolStripButton
        Me.btnPrevious = New System.Windows.Forms.ToolStripButton
        Me.tbxPgNum = New System.Windows.Forms.ToolStripTextBox
        Me.btnNext = New System.Windows.Forms.ToolStripButton
        Me.btnLast = New System.Windows.Forms.ToolStripButton
        Me.cboVarSearch = New System.Windows.Forms.ToolStripTextBox
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAddVar = New System.Windows.Forms.ToolStripButton
        Me.btn_Signbox = New System.Windows.Forms.ToolStripButton
        Me.btnAutoSize = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.cboDataType = New System.Windows.Forms.ToolStripComboBox
        Me.IncreaseFont = New System.Windows.Forms.ToolStripButton
        Me.decreaseFont = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_Group = New System.Windows.Forms.ToolStripButton
        Me.btn_Ungroup = New System.Windows.Forms.ToolStripButton
        Me.btnProperties = New System.Windows.Forms.ToolStripButton
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btn_YNNA_Select = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1.SuspendLayout()
        Me.tbr_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'dwgPanel
        '
        Me.dwgPanel.AllowDrop = True
        Me.dwgPanel.AutoScroll = True
        Me.dwgPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.dwgPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwgPanel.Location = New System.Drawing.Point(0, 25)
        Me.dwgPanel.Name = "dwgPanel"
        Me.dwgPanel.Size = New System.Drawing.Size(944, 484)
        Me.dwgPanel.TabIndex = 6
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stat_Main, Me.lab_XY})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 509)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(944, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'stat_Main
        '
        Me.stat_Main.Name = "stat_Main"
        Me.stat_Main.Size = New System.Drawing.Size(835, 17)
        Me.stat_Main.Spring = True
        '
        'lab_XY
        '
        Me.lab_XY.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lab_XY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.lab_XY.Name = "lab_XY"
        Me.lab_XY.Size = New System.Drawing.Size(94, 17)
        Me.lab_XY.Text = "X:          Y:           "
        '
        'tbr_Main
        '
        Me.tbr_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnFirst, Me.btnPrevious, Me.tbxPgNum, Me.btnNext, Me.btnLast, Me.cboVarSearch, Me.btnDelete, Me.ToolStripSeparator2, Me.btnAddVar, Me.btn_Signbox, Me.btnAutoSize, Me.ToolStripSeparator3, Me.cboDataType, Me.IncreaseFont, Me.decreaseFont, Me.ToolStripSeparator1, Me.btn_Group, Me.btn_Ungroup, Me.btnProperties, Me.btn_YNNA_Select})
        Me.tbr_Main.Location = New System.Drawing.Point(0, 0)
        Me.tbr_Main.Name = "tbr_Main"
        Me.tbr_Main.Size = New System.Drawing.Size(944, 25)
        Me.tbr_Main.TabIndex = 5
        Me.tbr_Main.Text = "ToolStrip1"
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = Global.FormDesigner.My.Resources.Resources.Floppy
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(23, 22)
        Me.btnSave.Text = "Save"
        '
        'btnFirst
        '
        Me.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFirst.Image = Global.FormDesigner.My.Resources.Resources.Navigation_Blue_First
        Me.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(23, 22)
        Me.btnFirst.Text = "First"
        '
        'btnPrevious
        '
        Me.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPrevious.Image = Global.FormDesigner.My.Resources.Resources.Navigation_Blue_Previous
        Me.btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.btnPrevious.Text = "Previous"
        '
        'tbxPgNum
        '
        Me.tbxPgNum.Name = "tbxPgNum"
        Me.tbxPgNum.Size = New System.Drawing.Size(100, 25)
        '
        'btnNext
        '
        Me.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNext.Image = Global.FormDesigner.My.Resources.Resources.Navigation_Blue_Next
        Me.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(23, 22)
        Me.btnNext.Text = "Next"
        '
        'btnLast
        '
        Me.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLast.Image = Global.FormDesigner.My.Resources.Resources.Navigation_Blue_Last
        Me.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(23, 22)
        Me.btnLast.Text = "Last"
        '
        'cboVarSearch
        '
        Me.cboVarSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cboVarSearch.Name = "cboVarSearch"
        Me.cboVarSearch.Size = New System.Drawing.Size(120, 25)
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = Global.FormDesigner.My.Resources.Resources.Delete
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(23, 22)
        Me.btnDelete.Text = "Cancel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnAddVar
        '
        Me.btnAddVar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAddVar.Image = Global.FormDesigner.My.Resources.Resources.Text_Document
        Me.btnAddVar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddVar.Name = "btnAddVar"
        Me.btnAddVar.Size = New System.Drawing.Size(23, 22)
        Me.btnAddVar.Text = "Text box"
        Me.btnAddVar.ToolTipText = "Text Input box"
        '
        'btn_Signbox
        '
        Me.btn_Signbox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Signbox.Image = Global.FormDesigner.My.Resources.Resources.Symbol_Edit1
        Me.btn_Signbox.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Signbox.Name = "btn_Signbox"
        Me.btn_Signbox.Size = New System.Drawing.Size(23, 22)
        Me.btn_Signbox.Text = "Signature box"
        '
        'btnAutoSize
        '
        Me.btnAutoSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAutoSize.Image = Global.FormDesigner.My.Resources.Resources.Antenna
        Me.btnAutoSize.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAutoSize.Name = "btnAutoSize"
        Me.btnAutoSize.Size = New System.Drawing.Size(23, 22)
        Me.btnAutoSize.Text = "Auto Size TextBox"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'cboDataType
        '
        Me.cboDataType.Name = "cboDataType"
        Me.cboDataType.Size = New System.Drawing.Size(75, 25)
        Me.cboDataType.Visible = False
        '
        'IncreaseFont
        '
        Me.IncreaseFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.IncreaseFont.Image = Global.FormDesigner.My.Resources.Resources.Text_Ascending
        Me.IncreaseFont.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.IncreaseFont.Name = "IncreaseFont"
        Me.IncreaseFont.Size = New System.Drawing.Size(23, 22)
        Me.IncreaseFont.Text = "Increase Font size"
        '
        'decreaseFont
        '
        Me.decreaseFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.decreaseFont.Image = Global.FormDesigner.My.Resources.Resources.Text_Descending
        Me.decreaseFont.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.decreaseFont.Name = "decreaseFont"
        Me.decreaseFont.Size = New System.Drawing.Size(23, 22)
        Me.decreaseFont.Text = "Descrease Font size"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btn_Group
        '
        Me.btn_Group.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Group.Image = Global.FormDesigner.My.Resources.Resources.group1
        Me.btn_Group.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Group.Name = "btn_Group"
        Me.btn_Group.Size = New System.Drawing.Size(23, 22)
        Me.btn_Group.Text = "Group Fields"
        '
        'btn_Ungroup
        '
        Me.btn_Ungroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Ungroup.Image = Global.FormDesigner.My.Resources.Resources.ungroup
        Me.btn_Ungroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Ungroup.Name = "btn_Ungroup"
        Me.btn_Ungroup.Size = New System.Drawing.Size(23, 22)
        Me.btn_Ungroup.Text = "Ungroup Fields"
        '
        'btnProperties
        '
        Me.btnProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnProperties.Image = Global.FormDesigner.My.Resources.Resources.Calendar
        Me.btnProperties.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProperties.Name = "btnProperties"
        Me.btnProperties.Size = New System.Drawing.Size(23, 22)
        Me.btnProperties.Text = "Properties"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(230, 100)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Visible = False
        '
        'btn_YNNA_Select
        '
        Me.btn_YNNA_Select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_YNNA_Select.Image = CType(resources.GetObject("btn_YNNA_Select.Image"), System.Drawing.Image)
        Me.btn_YNNA_Select.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_YNNA_Select.Name = "btn_YNNA_Select"
        Me.btn_YNNA_Select.Size = New System.Drawing.Size(63, 22)
        Me.btn_YNNA_Select.Text = "Yes/No/NA"
        Me.btn_YNNA_Select.ToolTipText = "Yes/No/NA Select Box"
        '
        'FormEditing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 531)
        Me.Controls.Add(Me.dwgPanel)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tbr_Main)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "FormEditing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Edit"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tbr_Main.ResumeLayout(False)
        Me.tbr_Main.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dwgPanel As System.Windows.Forms.Panel
    Friend WithEvents tbr_Main As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents stat_Main As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lab_XY As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnAddVar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbxPgNum As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents IncreaseFont As System.Windows.Forms.ToolStripButton
    Friend WithEvents decreaseFont As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_Group As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_Ungroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAutoSize As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnProperties As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cboVarSearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents cboDataType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btn_Signbox As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_YNNA_Select As System.Windows.Forms.ToolStripButton
End Class
