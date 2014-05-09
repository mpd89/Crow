<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagSelect
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TagSelect))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.DataNavigator1 = New DevExpress.XtraEditors.DataNavigator
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnUpdateTags = New System.Windows.Forms.Button
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboPkgNum = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboTypeID = New System.Windows.Forms.ComboBox
        Me.btnUpdateAuxVals = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.tbx_ColorInvalid = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbx_ColorBlank = New System.Windows.Forms.TextBox
        Me.btn_Delete = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(7, 104)
        Me.GridControl1.LookAndFeel.SkinName = "Blue"
        Me.GridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(656, 280)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        '
        'DataNavigator1
        '
        Me.DataNavigator1.Buttons.Append.Visible = False
        Me.DataNavigator1.Buttons.EndEdit.Visible = False
        Me.DataNavigator1.Buttons.Remove.Visible = False
        Me.DataNavigator1.Location = New System.Drawing.Point(331, 113)
        Me.DataNavigator1.LookAndFeel.SkinName = "Lilian"
        Me.DataNavigator1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.DataNavigator1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DataNavigator1.LookAndFeel.UseWindowsXPTheme = True
        Me.DataNavigator1.Name = "DataNavigator1"
        Me.DataNavigator1.Size = New System.Drawing.Size(204, 24)
        Me.DataNavigator1.TabIndex = 4
        Me.DataNavigator1.Text = "DataNavigator1"
        Me.DataNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 402)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Auxiliary Data"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tag Edit"
        '
        'btnUpdateTags
        '
        Me.btnUpdateTags.Enabled = False
        Me.btnUpdateTags.Location = New System.Drawing.Point(143, 12)
        Me.btnUpdateTags.Name = "btnUpdateTags"
        Me.btnUpdateTags.Size = New System.Drawing.Size(124, 23)
        Me.btnUpdateTags.TabIndex = 8
        Me.btnUpdateTags.Text = "Update Selected Tags"
        Me.btnUpdateTags.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(529, 3)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(124, 23)
        Me.btnSelectAll.TabIndex = 7
        Me.btnSelectAll.Text = "Select All Records"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(321, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Package Number"
        '
        'cboPkgNum
        '
        Me.cboPkgNum.FormattingEnabled = True
        Me.cboPkgNum.Location = New System.Drawing.Point(414, 78)
        Me.cboPkgNum.Name = "cboPkgNum"
        Me.cboPkgNum.Size = New System.Drawing.Size(121, 21)
        Me.cboPkgNum.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(142, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Type"
        '
        'cboTypeID
        '
        Me.cboTypeID.FormattingEnabled = True
        Me.cboTypeID.Location = New System.Drawing.Point(179, 78)
        Me.cboTypeID.Name = "cboTypeID"
        Me.cboTypeID.Size = New System.Drawing.Size(121, 21)
        Me.cboTypeID.TabIndex = 11
        '
        'btnUpdateAuxVals
        '
        Me.btnUpdateAuxVals.Enabled = False
        Me.btnUpdateAuxVals.Location = New System.Drawing.Point(411, 402)
        Me.btnUpdateAuxVals.Name = "btnUpdateAuxVals"
        Me.btnUpdateAuxVals.Size = New System.Drawing.Size(124, 23)
        Me.btnUpdateAuxVals.TabIndex = 13
        Me.btnUpdateAuxVals.Text = "Update Aux Values"
        Me.btnUpdateAuxVals.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(65, 425)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Fields"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(262, 425)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Values"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "Invalid Value"
        '
        'tbx_ColorInvalid
        '
        Me.tbx_ColorInvalid.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tbx_ColorInvalid.Location = New System.Drawing.Point(12, 71)
        Me.tbx_ColorInvalid.Multiline = True
        Me.tbx_ColorInvalid.Name = "tbx_ColorInvalid"
        Me.tbx_ColorInvalid.Size = New System.Drawing.Size(19, 20)
        Me.tbx_ColorInvalid.TabIndex = 106
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(37, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "Blank Entries"
        '
        'tbx_ColorBlank
        '
        Me.tbx_ColorBlank.BackColor = System.Drawing.Color.Yellow
        Me.tbx_ColorBlank.Location = New System.Drawing.Point(12, 47)
        Me.tbx_ColorBlank.Multiline = True
        Me.tbx_ColorBlank.Name = "tbx_ColorBlank"
        Me.tbx_ColorBlank.Size = New System.Drawing.Size(19, 20)
        Me.tbx_ColorBlank.TabIndex = 104
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(143, 39)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(124, 23)
        Me.btn_Delete.TabIndex = 108
        Me.btn_Delete.Text = "Delete Selected Tags"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(7, 441)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(449, 261)
        Me.Panel1.TabIndex = 109
        '
        'TagSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 714)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbx_ColorInvalid)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbx_ColorBlank)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnUpdateAuxVals)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTypeID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboPkgNum)
        Me.Controls.Add(Me.btnUpdateTags)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataNavigator1)
        Me.Controls.Add(Me.GridControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TagSelect"
        Me.ShowInTaskbar = False
        Me.Text = "Tag Select"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DataNavigator1 As DevExpress.XtraEditors.DataNavigator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnUpdateTags As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPkgNum As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents btnUpdateAuxVals As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbx_ColorInvalid As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbx_ColorBlank As System.Windows.Forms.TextBox
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
