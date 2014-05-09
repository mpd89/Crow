<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskUpdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaskUpdate))
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgv_History = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.btn_Update = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbx_ActMH = New System.Windows.Forms.TextBox
        Me.tbx_ActQTY = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.dgv_History, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Percent Complete"
        '
        'dgv_History
        '
        Me.dgv_History.EmbeddedNavigator.Name = ""
        Me.dgv_History.Location = New System.Drawing.Point(15, 133)
        Me.dgv_History.MainView = Me.GridView1
        Me.dgv_History.Name = "dgv_History"
        Me.dgv_History.Size = New System.Drawing.Size(656, 130)
        Me.dgv_History.TabIndex = 1
        Me.dgv_History.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.dgv_History
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown1.Location = New System.Drawing.Point(33, 39)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 50)
        Me.NumericUpDown1.TabIndex = 2
        '
        'btn_Update
        '
        Me.btn_Update.BackgroundImage = Global.TaskManager.My.Resources.Resources.Task_Add
        Me.btn_Update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Update.Location = New System.Drawing.Point(598, 39)
        Me.btn_Update.Name = "btn_Update"
        Me.btn_Update.Size = New System.Drawing.Size(48, 50)
        Me.btn_Update.TabIndex = 3
        Me.btn_Update.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Task History"
        '
        'tbx_ActMH
        '
        Me.tbx_ActMH.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_ActMH.Location = New System.Drawing.Point(212, 39)
        Me.tbx_ActMH.Name = "tbx_ActMH"
        Me.tbx_ActMH.Size = New System.Drawing.Size(135, 50)
        Me.tbx_ActMH.TabIndex = 5
        '
        'tbx_ActQTY
        '
        Me.tbx_ActQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_ActQTY.Location = New System.Drawing.Point(402, 39)
        Me.tbx_ActQTY.Name = "tbx_ActQTY"
        Me.tbx_ActQTY.Size = New System.Drawing.Size(139, 50)
        Me.tbx_ActQTY.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(209, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Actual Man Hours"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(399, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Actual Quantity"
        '
        'TaskUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 278)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbx_ActQTY)
        Me.Controls.Add(Me.tbx_ActMH)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_Update)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.dgv_History)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TaskUpdate"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Update Task#"
        CType(Me.dgv_History, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_History As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents btn_Update As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbx_ActMH As System.Windows.Forms.TextBox
    Friend WithEvents tbx_ActQTY As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
