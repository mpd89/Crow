Imports daqartDLL
Public Class NotesReport
    Dim dtNotes As New DataTable


    Public Sub New(ByVal dt As DataTable)
        InitializeComponent()
        dtNotes = dt
    End Sub

    Private Sub NotesReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportManager.NotesReport.rdlc"
            ReportDataSource1.Name = "Notes Results"
            ReportDataSource1.Value = Me.BindingSource1
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

            'Adding parameter values
            Dim UserName As String = runtime.UserName
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Report_Par_ProjectName", runtime.selectedProject, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Report_Par_UserID", UserName, False))
            ReportViewer1.LocalReport.SetParameters(paramList)
            Dim eitems As New NotesItems
            For Each dr As DataRow In dtNotes.Rows
                Dim eitem As New NotesItem
                eitem.ID = dr(0)
                eitem.Tstamp = dr(1)
                eitem.Subject = dr(2)
                eitem.Description = dr(3)
                eitems.Add(eitem)
            Next
            Me.BindingSource1.DataSource = eitems
            Me.ReportViewer1.RefreshReport()
            'Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Utilities.logErrorMessage("ReportManager.NotesReport._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class