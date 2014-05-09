<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagStatusReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TagStatusReport))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btn_Export = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.tbx_Resolved = New System.Windows.Forms.TextBox
        Me.tbx_Written = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtp_To = New System.Windows.Forms.DateTimePicker
        Me.dtp_From = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbx_TotalEMH = New System.Windows.Forms.TextBox
        Me.tbx_FromDate = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbx_ToDate = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbx_EngInfo = New System.Windows.Forms.ListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_Search = New System.Windows.Forms.Button
        Me.dgv_CertCount = New System.Windows.Forms.DataGridView
        Me.dgv_Results = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgv_CertCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Results, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Export})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1093, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_Export
        '
        Me.btn_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_Export.Image = CType(resources.GetObject("btn_Export.Image"), System.Drawing.Image)
        Me.btn_Export.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Export.Name = "btn_Export"
        Me.btn_Export.Size = New System.Drawing.Size(44, 22)
        Me.btn_Export.Text = "Export"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 760)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1093, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_Results)
        Me.SplitContainer1.Size = New System.Drawing.Size(1093, 735)
        Me.SplitContainer1.SplitterDistance = 236
        Me.SplitContainer1.TabIndex = 3
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbx_Resolved)
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbx_Written)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtp_To)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtp_From)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbx_TotalEMH)
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbx_FromDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.tbx_ToDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lbx_EngInfo)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btn_Search)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgv_CertCount)
        Me.SplitContainer2.Size = New System.Drawing.Size(236, 735)
        Me.SplitContainer2.SplitterDistance = 408
        Me.SplitContainer2.TabIndex = 11
        '
        'tbx_Resolved
        '
        Me.tbx_Resolved.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbx_Resolved.Location = New System.Drawing.Point(157, 381)
        Me.tbx_Resolved.Name = "tbx_Resolved"
        Me.tbx_Resolved.ReadOnly = True
        Me.tbx_Resolved.Size = New System.Drawing.Size(63, 20)
        Me.tbx_Resolved.TabIndex = 16
        Me.tbx_Resolved.Text = "0"
        Me.tbx_Resolved.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbx_Written
        '
        Me.tbx_Written.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbx_Written.Location = New System.Drawing.Point(157, 353)
        Me.tbx_Written.Name = "tbx_Written"
        Me.tbx_Written.ReadOnly = True
        Me.tbx_Written.Size = New System.Drawing.Size(63, 20)
        Me.tbx_Written.TabIndex = 15
        Me.tbx_Written.Text = "0"
        Me.tbx_Written.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 388)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Discrepancies Resolved:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 360)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Discrepancies Written:"
        '
        'dtp_To
        '
        Me.dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_To.Location = New System.Drawing.Point(137, 51)
        Me.dtp_To.MinDate = New Date(2005, 1, 1, 0, 0, 0, 0)
        Me.dtp_To.Name = "dtp_To"
        Me.dtp_To.ShowUpDown = True
        Me.dtp_To.Size = New System.Drawing.Size(93, 20)
        Me.dtp_To.TabIndex = 11
        Me.dtp_To.Value = New Date(2010, 11, 20, 18, 0, 0, 0)
        '
        'dtp_From
        '
        Me.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_From.Location = New System.Drawing.Point(137, 25)
        Me.dtp_From.MinDate = New Date(2005, 1, 1, 0, 0, 0, 0)
        Me.dtp_From.Name = "dtp_From"
        Me.dtp_From.ShowUpDown = True
        Me.dtp_From.Size = New System.Drawing.Size(93, 20)
        Me.dtp_From.TabIndex = 10
        Me.dtp_From.Value = New Date(2010, 11, 20, 6, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Report Date Range"
        '
        'tbx_TotalEMH
        '
        Me.tbx_TotalEMH.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbx_TotalEMH.Location = New System.Drawing.Point(123, 327)
        Me.tbx_TotalEMH.Name = "tbx_TotalEMH"
        Me.tbx_TotalEMH.ReadOnly = True
        Me.tbx_TotalEMH.Size = New System.Drawing.Size(97, 20)
        Me.tbx_TotalEMH.TabIndex = 9
        Me.tbx_TotalEMH.Text = "0"
        Me.tbx_TotalEMH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbx_FromDate
        '
        Me.tbx_FromDate.Location = New System.Drawing.Point(42, 25)
        Me.tbx_FromDate.Name = "tbx_FromDate"
        Me.tbx_FromDate.Size = New System.Drawing.Size(89, 20)
        Me.tbx_FromDate.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 334)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Total Earned MH"
        '
        'tbx_ToDate
        '
        Me.tbx_ToDate.Location = New System.Drawing.Point(42, 51)
        Me.tbx_ToDate.Name = "tbx_ToDate"
        Me.tbx_ToDate.Size = New System.Drawing.Size(89, 20)
        Me.tbx_ToDate.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Select Addition Columns"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "From"
        '
        'lbx_EngInfo
        '
        Me.lbx_EngInfo.FormattingEnabled = True
        Me.lbx_EngInfo.Items.AddRange(New Object() {"Remarks", "Prefix", "Description", "Service", "Manufacturer", "ModelNumber", "SerialNumber", "PONumber", "LineNumber", "Aux01", "Aux02", "Aux03"})
        Me.lbx_EngInfo.Location = New System.Drawing.Point(13, 105)
        Me.lbx_EngInfo.Name = "lbx_EngInfo"
        Me.lbx_EngInfo.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbx_EngInfo.Size = New System.Drawing.Size(207, 173)
        Me.lbx_EngInfo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "To"
        '
        'btn_Search
        '
        Me.btn_Search.Location = New System.Drawing.Point(123, 284)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(97, 28)
        Me.btn_Search.TabIndex = 5
        Me.btn_Search.Text = "Get Report"
        Me.btn_Search.UseVisualStyleBackColor = True
        '
        'dgv_CertCount
        '
        Me.dgv_CertCount.AllowUserToAddRows = False
        Me.dgv_CertCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_CertCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_CertCount.Location = New System.Drawing.Point(0, 0)
        Me.dgv_CertCount.Name = "dgv_CertCount"
        Me.dgv_CertCount.RowHeadersVisible = False
        Me.dgv_CertCount.Size = New System.Drawing.Size(236, 323)
        Me.dgv_CertCount.TabIndex = 10
        '
        'dgv_Results
        '
        Me.dgv_Results.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Results.EmbeddedNavigator.Name = ""
        Me.dgv_Results.Location = New System.Drawing.Point(0, 0)
        Me.dgv_Results.MainView = Me.GridView1
        Me.dgv_Results.Name = "dgv_Results"
        Me.dgv_Results.Size = New System.Drawing.Size(853, 735)
        Me.dgv_Results.TabIndex = 0
        Me.dgv_Results.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.dgv_Results
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'TagStatusReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 782)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "TagStatusReport"
        Me.Text = "Status Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgv_CertCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Results, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbx_ToDate As System.Windows.Forms.TextBox
    Friend WithEvents tbx_FromDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Search As System.Windows.Forms.Button
    Friend WithEvents dgv_Results As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btn_Export As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbx_EngInfo As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgv_CertCount As System.Windows.Forms.DataGridView
    Friend WithEvents tbx_TotalEMH As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dtp_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbx_Resolved As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Written As System.Windows.Forms.TextBox
End Class
