Imports daqartDLL

Public Class DiscrepancyReport
    Dim dtDiscrepancy As New DataTable
    Private Sub DiscrepancyReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportManager.DiscrepancyReport.rdlc"
            ReportDataSource1.Name = "Discrepancy Results"
            ReportDataSource1.Value = Me.bsrDiscrepancy
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

            'Adding parameter values
            Dim UserName As String = runtime.UserName
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Report_Par_ProjectName", runtime.selectedProject, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Report_Par_UserID", UserName, False))
            ReportViewer1.LocalReport.SetParameters(paramList)
            Dim eitems As New DiscrepancyItems
            For Each dr As DataRow In dtDiscrepancy.Rows
                Dim eitem As New DiscrepancyItem
                eitem.DiscrepancyID = dr(0)
                eitem.VariableTitle = dr(1)
                eitem.VariableStatus = dr(2)
                eitem.VariablePackageNumber = dr(3)
                eitems.Add(eitem)
            Next
            Me.bsrDiscrepancy.DataSource = eitems
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Utilities.logErrorMessage("ReportManager.DiscrepancyReport._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub New(ByVal dt As DataTable)
        ' Add any initialization after the InitializeComponent() call.
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        dtDiscrepancy = dt

    End Sub
End Class