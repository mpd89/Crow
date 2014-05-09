Imports daqartDLL
Imports System.IO


Public Class SystemAuditReport
    Dim dt_DataSource As New DataTable


    Public Sub New(ByVal dt As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dt_DataSource = dt
    End Sub

    Private Sub SystemAuditReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportManager.SystemAuditReport.rdlc"
            ReportDataSource1.Name = "dst_AuditResults"
            ReportDataSource1.Value = Me.bsr_AuditResults
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

            'Adding parameter values
            Dim UserName As String = runtime.UserName
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_ProjectName", runtime.selectedProject, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_UserID", UserName, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_SiteName", runtime.SiteName, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_VariableName", dt_DataSource.Columns(1).ColumnName, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_VariableDescription", dt_DataSource.Columns(2).ColumnName, False))

            ReportViewer1.LocalReport.SetParameters(paramList)


            Dim eitems As New ReportManager.AuditItems
            For Each dr As DataRow In dt_DataSource.Rows
                Dim eitem As New ReportManager.AuditItem
                eitem.ItemNumber = dr(0)
                eitem.VariableName = dr(1)
                eitem.VariableDescription = dr(2)
                eitems.Add(eitem)
            Next
            Me.bsr_AuditResults.DataSource = eitems


            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Utilities.logErrorMessage("ReportManager.SystemAudit._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub



End Class