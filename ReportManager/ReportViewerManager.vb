Public Class ReportViewerManager
    Public Shared ThisViewer As ReportViewerMain

    Public Shared Function OpenReportViewer()
        '  If the instance still exists... (ie. it's Not Nothing)
        If Not IsNothing(ThisViewer) Then
            '  and if it hasn't been disposed yet
            If Not ThisViewer.IsDisposed Then
                '  then it must already be instantiated - maybe it's
                '  minimized or hidden behind other forms ?
                ThisViewer.WindowState = FormWindowState.Normal
                ThisViewer.BringToFront()
            Else
                '  else it has already been disposed, so you can
                '  instantiate a new form and show it
                ThisViewer = New ReportViewerMain()
                ThisViewer.Show()
            End If
        Else
            '  else the form = nothing, so you can safely
            '  instantiate a new form and show it
            ThisViewer = New ReportViewerMain()
            ThisViewer.Show()
        End If

    End Function

    Public Shared Sub OpenReport()
        OpenReportViewer()
        ThisViewer.ReportType.DropDownItems.Add("Report")

        Dim Report As New ReportView
        Report.MdiParent = ThisViewer
        Report.Text = "Report"


        Report.Show()
        Report.BringToFront()


    End Sub


End Class
