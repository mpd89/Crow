<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManualSynchronize
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
        Me.Button2 = New System.Windows.Forms.Button
        Me.btn_ServerDB = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.btn_ProjectDB = New System.Windows.Forms.Button
        Me.Btn_PrjDaqument = New System.Windows.Forms.Button
        Me.btn_Daqument = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_Daqument)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Btn_PrjDaqument)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_ProjectDB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btn_ServerDB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(677, 380)
        Me.SplitContainer1.SplitterDistance = 94
        Me.SplitContainer1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(348, 54)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_ServerDB
        '
        Me.btn_ServerDB.Location = New System.Drawing.Point(348, 12)
        Me.btn_ServerDB.Name = "btn_ServerDB"
        Me.btn_ServerDB.Size = New System.Drawing.Size(75, 23)
        Me.btn_ServerDB.TabIndex = 1
        Me.btn_ServerDB.Text = "ServerDB"
        Me.btn_ServerDB.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(229, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Synchronize Database"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(677, 282)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'btn_ProjectDB
        '
        Me.btn_ProjectDB.Location = New System.Drawing.Point(251, 12)
        Me.btn_ProjectDB.Name = "btn_ProjectDB"
        Me.btn_ProjectDB.Size = New System.Drawing.Size(75, 23)
        Me.btn_ProjectDB.TabIndex = 3
        Me.btn_ProjectDB.Text = "ProjectDB"
        Me.btn_ProjectDB.UseVisualStyleBackColor = True
        '
        'Btn_PrjDaqument
        '
        Me.Btn_PrjDaqument.Location = New System.Drawing.Point(552, 12)
        Me.Btn_PrjDaqument.Name = "Btn_PrjDaqument"
        Me.Btn_PrjDaqument.Size = New System.Drawing.Size(75, 23)
        Me.Btn_PrjDaqument.TabIndex = 4
        Me.Btn_PrjDaqument.Text = "ProjDaqument"
        Me.Btn_PrjDaqument.UseVisualStyleBackColor = True
        '
        'btn_Daqument
        '
        Me.btn_Daqument.Location = New System.Drawing.Point(455, 12)
        Me.btn_Daqument.Name = "btn_Daqument"
        Me.btn_Daqument.Size = New System.Drawing.Size(75, 23)
        Me.btn_Daqument.TabIndex = 5
        Me.btn_Daqument.Text = "Daqument"
        Me.btn_Daqument.UseVisualStyleBackColor = True
        '
        'ManualSynchronize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 380)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ManualSynchronize"
        Me.Text = "ManualSynchronize"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btn_ServerDB As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_Daqument As System.Windows.Forms.Button
    Friend WithEvents Btn_PrjDaqument As System.Windows.Forms.Button
    Friend WithEvents btn_ProjectDB As System.Windows.Forms.Button
End Class
