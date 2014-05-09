Imports daqartDLL
Public Class DaqumentReport
    Dim dtDaqument As New DataTable

    Private Sub DaqumentReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportManager.Daqumentreport.rdlc"
            ReportDataSource1.Name = "Daqument Results"
            ReportDataSource1.Value = Me.bsrDaqument
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

            'Adding parameter values
            Dim UserName As String = runtime.UserName
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Report_Par_ProjectName", runtime.selectedProject, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Report_Par_UserID", UserName, False))
            ReportViewer1.LocalReport.SetParameters(paramList)
            Dim eitems As New DaqumentItems
            For Each dr As DataRow In dtDaqument.Rows
                Dim eitem As New DaqumentItem
                eitem.VariableEngCode = dr(1)
                eitem.VariableClientCode = dr(2)
                eitem.VariableDescription = dr(3)
                eitem.VariableRevision = dr(4)
                eitem.VariableSheet = dr(5)
                eitem.VariableDateLoaded = dr(6)
                eitem.VariableCode = dr(7)
                eitems.Add(eitem)
            Next
            Me.bsrDaqument.DataSource = eitems
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Utilities.logErrorMessage("ReportManager.DaqumentReport._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal dt As DataTable)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        dtDaqument = dt

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class