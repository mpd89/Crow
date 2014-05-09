Imports daqartDLL
Imports System.IO

Public Class SystemOverview
    Dim dt_DataSource As New DataTable
    Dim SystemID As String
    Dim Description As String
    Dim EarnedMH As String
    Dim RequiredMH As String
    Dim PercentComplete As String



    Public Sub New(ByVal dt As DataTable, ByVal Owner As String, ByVal thisSystemID As String, ByVal thisDescription As String _
                        , ByVal thisEarnedMH As String, ByVal thisRequiredMH As String, ByVal thisPercentComplete As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dt_DataSource = dt
        SystemID = thisSystemID
        Description = thisDescription
        EarnedMH = thisEarnedMH
        RequiredMH = thisRequiredMH
        PercentComplete = thisPercentComplete

    End Sub

    Private Sub SystemOverview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportManager.SystemOverview.rdlc"
            ReportDataSource1.Name = "dst_Results"
            ReportDataSource1.Value = Me.bsr_Results
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

            'Adding parameter values
            Dim UserName As String = runtime.UserName
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_ProjectName", runtime.selectedProject, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_UserID", UserName, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_Owner", dt_DataSource.Columns(1).ColumnName, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_SystemID", SystemID, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_Description", Description, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_EarnedMH", EarnedMH, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_RequiredMH", RequiredMH, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_PercentComplete", PercentComplete, False))

            ReportViewer1.LocalReport.SetParameters(paramList)


            Dim eitems As New ReportManager.SystemOverviewItems
            For Each dr As DataRow In dt_DataSource.Rows
                Dim eitem As New ReportManager.SystemOverviewItem
                eitem.PackageNumber = dr(1)
                eitem.Description = dr(2)
                eitem.Discipline = dr(2)
                eitem.EarnedMH = dr(4)
                eitem.RequiredMH = dr(5)
                eitem.PercentComplete = dr(6)
                eitems.Add(eitem)
            Next
            Me.bsr_Results.DataSource = eitems


            Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Utilities.logErrorMessage("ReportManager.SystemOverview._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


End Class