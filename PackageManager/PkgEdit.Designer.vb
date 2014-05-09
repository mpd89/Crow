<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PkgEdit
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PkgEdit))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.DataNavigator1 = New DevExpress.XtraEditors.DataNavigator
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnUpdatePackages = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboGroup = New System.Windows.Forms.ComboBox
        Me.btnUpdateAuxVals = New System.Windows.Forms.Button
        Me.VGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboOwner = New System.Windows.Forms.ComboBox
        Me.cboDiscipline = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.ckbAuxInfo = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.tbx_ColorInvalid = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.tbx_ColorBlank = New System.Windows.Forms.TextBox
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxSysNum = New System.Windows.Forms.TextBox
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.btn_Delete = New System.Windows.Forms.Button
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(16, 143)
        Me.GridControl1.LookAndFeel.SkinName = "Blue"
        Me.GridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(614, 280)
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
        Me.DataNavigator1.Buttons.CancelEdit.Enabled = False
        Me.DataNavigator1.Buttons.CancelEdit.Visible = False
        Me.DataNavigator1.Buttons.EndEdit.Visible = False
        Me.DataNavigator1.Location = New System.Drawing.Point(312, 148)
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
        Me.Label1.Location = New System.Drawing.Point(12, 426)
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
        Me.Label2.Size = New System.Drawing.Size(117, 23)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Package Edit"
        '
        'btnUpdatePackages
        '
        Me.btnUpdatePackages.Enabled = False
        Me.btnUpdatePackages.Location = New System.Drawing.Point(174, 12)
        Me.btnUpdatePackages.Name = "btnUpdatePackages"
        Me.btnUpdatePackages.Size = New System.Drawing.Size(152, 23)
        Me.btnUpdatePackages.TabIndex = 8
        Me.btnUpdatePackages.Text = "Update Selected Package"
        Me.btnUpdatePackages.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(449, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "System Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(305, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Group"
        '
        'cboGroup
        '
        Me.cboGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGroup.FormattingEnabled = True
        Me.cboGroup.Location = New System.Drawing.Point(308, 116)
        Me.cboGroup.Name = "cboGroup"
        Me.cboGroup.Size = New System.Drawing.Size(121, 21)
        Me.cboGroup.TabIndex = 11
        '
        'btnUpdateAuxVals
        '
        Me.btnUpdateAuxVals.Enabled = False
        Me.btnUpdateAuxVals.Location = New System.Drawing.Point(421, 450)
        Me.btnUpdateAuxVals.Name = "btnUpdateAuxVals"
        Me.btnUpdateAuxVals.Size = New System.Drawing.Size(124, 23)
        Me.btnUpdateAuxVals.TabIndex = 13
        Me.btnUpdateAuxVals.Text = "Update Aux Values"
        Me.btnUpdateAuxVals.UseVisualStyleBackColor = True
        '
        'VGridControl1
        '
        Me.VGridControl1.Location = New System.Drawing.Point(7, 471)
        Me.VGridControl1.Name = "VGridControl1"
        Me.VGridControl1.Size = New System.Drawing.Size(414, 266)
        Me.VGridControl1.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(49, 453)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Fields"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(246, 453)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Values"
        '
        'cboOwner
        '
        Me.cboOwner.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOwner.FormattingEnabled = True
        Me.cboOwner.Location = New System.Drawing.Point(163, 115)
        Me.cboOwner.Name = "cboOwner"
        Me.cboOwner.Size = New System.Drawing.Size(121, 21)
        Me.cboOwner.TabIndex = 17
        '
        'cboDiscipline
        '
        Me.cboDiscipline.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDiscipline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiscipline.FormattingEnabled = True
        Me.cboDiscipline.Location = New System.Drawing.Point(16, 115)
        Me.cboDiscipline.Name = "cboDiscipline"
        Me.cboDiscipline.Size = New System.Drawing.Size(121, 21)
        Me.cboDiscipline.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Discipline"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(160, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Owner"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(553, 114)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = ". . ."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ckbAuxInfo
        '
        Me.ckbAuxInfo.AutoSize = True
        Me.ckbAuxInfo.Location = New System.Drawing.Point(332, 16)
        Me.ckbAuxInfo.Name = "ckbAuxInfo"
        Me.ckbAuxInfo.Size = New System.Drawing.Size(135, 17)
        Me.ckbAuxInfo.TabIndex = 25
        Me.ckbAuxInfo.Text = "Remove Auxiliary Data"
        Me.ckbAuxInfo.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(41, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "Invalid Value"
        '
        'tbx_ColorInvalid
        '
        Me.tbx_ColorInvalid.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tbx_ColorInvalid.Location = New System.Drawing.Point(16, 65)
        Me.tbx_ColorInvalid.Multiline = True
        Me.tbx_ColorInvalid.Name = "tbx_ColorInvalid"
        Me.tbx_ColorInvalid.Size = New System.Drawing.Size(19, 20)
        Me.tbx_ColorInvalid.TabIndex = 110
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(41, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 109
        Me.Label11.Text = "Blank Entries"
        '
        'tbx_ColorBlank
        '
        Me.tbx_ColorBlank.BackColor = System.Drawing.Color.Yellow
        Me.tbx_ColorBlank.Location = New System.Drawing.Point(16, 41)
        Me.tbx_ColorBlank.Multiline = True
        Me.tbx_ColorBlank.Name = "tbx_ColorBlank"
        Me.tbx_ColorBlank.Size = New System.Drawing.Size(19, 20)
        Me.tbx_ColorBlank.TabIndex = 108
        '
        'tbxSysNum
        '
        Me.tbxSysNum.Location = New System.Drawing.Point(448, 117)
        Me.tbxSysNum.Name = "tbxSysNum"
        Me.tbxSysNum.Size = New System.Drawing.Size(100, 20)
        Me.tbxSysNum.TabIndex = 112
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectAll.Location = New System.Drawing.Point(496, 12)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(123, 23)
        Me.btnSelectAll.TabIndex = 113
        Me.btnSelectAll.Text = "Select All Records"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(174, 41)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(151, 23)
        Me.btn_Delete.TabIndex = 114
        Me.btn_Delete.Text = "Delete Selected Records"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'PkgEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 749)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.tbxSysNum)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tbx_ColorInvalid)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tbx_ColorBlank)
        Me.Controls.Add(Me.ckbAuxInfo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboDiscipline)
        Me.Controls.Add(Me.cboOwner)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.VGridControl1)
        Me.Controls.Add(Me.btnUpdateAuxVals)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboGroup)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnUpdatePackages)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataNavigator1)
        Me.Controls.Add(Me.GridControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PkgEdit"
        Me.ShowInTaskbar = False
        Me.Text = "Package Edit"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DataNavigator1 As DevExpress.XtraEditors.DataNavigator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnUpdatePackages As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboGroup As System.Windows.Forms.ComboBox
    Friend WithEvents btnUpdateAuxVals As System.Windows.Forms.Button
    Friend WithEvents VGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboOwner As System.Windows.Forms.ComboBox
    Friend WithEvents cboDiscipline As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ckbAuxInfo As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbx_ColorInvalid As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbx_ColorBlank As System.Windows.Forms.TextBox
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents tbxSysNum As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
End Class
