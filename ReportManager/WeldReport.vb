Imports daqartDLL
Imports System.IO

Public Class WeldReport

    Dim dt_DataSource As New DataTable

    Dim _SubHeading As String
    Dim _StartDate As Date
    Dim _EndDate As Date

    Public Sub New(ByVal dt As DataTable, ByVal startDate As String, ByVal endDate As String, ByVal subHeading As String)

        _SubHeading = subHeading
        _StartDate = startDate
        _EndDate = endDate
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dt_DataSource = dt

    End Sub

    Private Sub SystemOverview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportManager.WeldReportTracking.rdlc"
            ReportDataSource1.Name = "dst_Results"
            ReportDataSource1.Value = Me.bsr_Items
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

            'Adding parameter values
            Dim UserName As String = runtime.UserName
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
            Dim prj As String = runtime.selectedProject
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_ProjectName", prj, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_UserID", UserName, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_SubHeading", _SubHeading, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_StartDate", _StartDate, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_EndDate", _EndDate, False))

            Dim eitems As New ReportManager.WeldReportItems
            For Each dr As DataRow In dt_DataSource.Rows
                Dim eitem As New ReportManager.WeldReportItem
                eitem.Item0 = dr(0).ToString
                If dt_DataSource.Columns.Count > 1 Then eitem.Item1 = dr(1).ToString
                If dt_DataSource.Columns.Count > 2 Then eitem.Item2 = dr(2).ToString
                If dt_DataSource.Columns.Count > 3 Then eitem.Item3 = dr(3).ToString
                If dt_DataSource.Columns.Count > 4 Then eitem.Item4 = dr(4).ToString
                If dt_DataSource.Columns.Count > 5 Then eitem.Item5 = dr(5).ToString
                If dt_DataSource.Columns.Count > 6 Then eitem.Item6 = dr(6).ToString
                If dt_DataSource.Columns.Count > 7 Then eitem.Item7 = dr(7).ToString
                eitems.Add(eitem)
            Next
            Dim parmCtr As Integer = 0
            For Each clm As DataColumn In dt_DataSource.Columns
                paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_hdr" + parmCtr.ToString, clm.ColumnName, False))
                parmCtr = parmCtr + 1
            Next
            If parmCtr < 7 Then
                For i As Integer = parmCtr To 7
                    paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_hdr" + parmCtr.ToString, "8", False))
                    parmCtr = parmCtr + 1
                Next
            End If
            Me.bsr_Items.DataSource = eitems
            ReportViewer1.LocalReport.SetParameters(paramList)

            'Dim hdrs As New ReportManager.WeldReportHeaders
            'For Each dr As DataRow In dt_DataSource.Rows
            '    Dim hdr As New ReportManager.WeldReportHeader
            '    hdr.Header0 = dr(0)
            '    hdr.Header1 = dr(1)
            '    hdr.Header2 = dr(2)
            '    hdr.Header3 = dr(3)
            '    hdr.Header4 = dr(4)
            '    hdr.Header5 = dr(4)
            '    '          hdr.WeldInches = dr(6)
            '    hdrs.Add(hdr)

            'Next

            'Me.bsr_Headers.DataSource = hdrs

            Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Utilities.logErrorMessage("ReportManager.SystemOverview._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


End Class