Imports daqartDLL
Imports System.IO
Public Class ProjectStatus

    Dim dt_DataSource As New DataTable
    Dim sys_DataSource As New DataTable

    Dim _SubHeading As String
    Dim _CurrentStatusIndicator As String
    Dim _logoPath As String
    Dim _TtlProjectEarnedHours As String
    Dim _TtlProjectManHours As String

    Public Sub New(ByVal prjTable As DataTable, ByVal logoPath As String, _
    ByVal CurrentStatusIndicator As String, ByVal TtlProjectEarnedHours As String, _
    ByVal TtlProjectManHours As String, ByVal subHeading As String)

        _SubHeading = subHeading
        _CurrentStatusIndicator = CurrentStatusIndicator
        _TtlProjectEarnedHours = TtlProjectEarnedHours
        _logoPath = logoPath
        _TtlProjectManHours = TtlProjectManHours
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        dt_DataSource = prjTable

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ProjectStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            Me.ReportViewer1.RefreshReport()
            Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportManager.ProjectStatusReport.rdlc"
            ReportDataSource1.Name = "dst_Results"
            ReportDataSource1.Value = Me.bsr_Items


            ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
            ReportViewer1.LocalReport.EnableExternalImages = True

            'Adding parameter values
            Dim UserName As String = runtime.UserName
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
            Dim prj As String = runtime.selectedProject
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_PercentCompleteText", _CurrentStatusIndicator, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_TtlManhoursText", _TtlProjectManHours, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_TtlEarnedHoursText", _TtlProjectEarnedHours, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_Logo", _logoPath, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_SubHeading", _SubHeading, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_UserID", UserName, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_Today", Now.Date(), False))

            Dim eitems As New ReportManager.ProjectStatusItems
            For Each dr As DataRow In dt_DataSource.Rows
                Dim eitem As New ReportManager.ProjectStatusItem
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
            If parmCtr < 8 Then
                For i As Integer = parmCtr To 7
                    paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("par_hdr" + parmCtr.ToString, parmCtr.ToString, False))
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
            Utilities.logErrorMessage("ReportManager.ProjectStatus._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    'Private Sub WeldTrackingReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '    Me.ReportViewer1.RefreshReport()
    'End Sub
End Class