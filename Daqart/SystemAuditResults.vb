Imports daqartDLL


Public Class SystemAuditResults
    Dim dt As DataTable

    Public Sub New(ByVal dt_This As DataTable)
        InitializeComponent()

        dt = dt_This
    End Sub

    Private Sub SystemAuditResults_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dgv_Results.DataSource = dt
        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.SystemAuditResults_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim frm_Results As New ReportManager.SystemAuditReport(dt)
        frm_Results.Show()
    End Sub
End Class