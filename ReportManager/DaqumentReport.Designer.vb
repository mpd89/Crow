<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DaqumentReport
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
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.bsrDaqument = New System.Windows.Forms.BindingSource(Me.components)
        Me.DaqumentItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.bsrDaqument, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DaqumentItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ReportManager_DaqumentItems"
        ReportDataSource1.Value = Me.bsrDaqument
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportManager.Daqumentreport.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(753, 606)
        Me.ReportViewer1.TabIndex = 0
        '
        'DaqumentItemsBindingSource
        '
        Me.DaqumentItemsBindingSource.DataSource = GetType(ReportManager.DaqumentItems)
        '
        'DaqumentReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 606)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "DaqumentReport"
        Me.Text = "DaqumentReport"
        CType(Me.bsrDaqument, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DaqumentItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents bsrDaqument As System.Windows.Forms.BindingSource
    Friend WithEvents DaqumentItemsBindingSource As System.Windows.Forms.BindingSource
End Class
