Imports daqartDLL
Imports Microsoft.Reporting.WinForms


Public Class TurnoverReport
    Dim dt_TurnoverStatus As DataTable


    Public Sub New(ByVal _dt_TurnoverStatus As DataTable)
        InitializeComponent()

        dt_TurnoverStatus = _dt_TurnoverStatus
    End Sub


    Private Sub TurnoverReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Daqart.Turnover.rdlc"
            'Me.ReportViewer1.LocalReport.ReportPath = "..\..\Turnover\TurnoverReport.rdlc"
            ReportDataSource1.Name = "Turnover Results"
            ReportDataSource1.Value = Me.BindingSource1
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

            'Adding parameter values
            Dim UserName As String = runtime.UserName
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
            'paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Report_Par_ProjectName", runtime.selectedProject, False))
            'paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Report_Par_UserID", UserName, False))
            'ReportViewer1.LocalReport.SetParameters(paramList)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            Dim eitems As New TurnoverItems
            For Each dr As DataRow In dt_TurnoverStatus.Rows
                Dim eitem As New TurnoverItem
                With eitem
                    .ProjectMUID = dr("ProjectMUID")
                    .ProjectName = dr("ProjectName")
                    .SH_MUID = dr("SH_MUID")
                    .SHNumber = dr("SH#")
                    .SH_Description = dr("SH_Description")
                    .MC_MUID = dr("MC_MUID")
                    .MC_Description = dr("MC_Description")
                    If Not IsDBNull(dr("Disc")) Then
                        .Disc = dr("Disc")
                    End If

                    If Not IsDBNull(dr("Project Number")) Then
                        .ProjectNumber = dr("Project Number")
                    End If

                    If Not IsDBNull(dr("Contractor")) Then
                        .Contractor = dr("Contractor")
                    End If

                    If Not IsDBNull(dr("Location")) Then
                        .Location = dr("Location")
                    End If

                    .MCNumber = dr("MC#")

                    If Not IsDBNull(dr("MC_Sent")) Then
                        .MC_Sent = dr("MC_Sent")
                    End If

                    If Not IsDBNull(dr("IWL_Start")) Then
                        .IWL_Start = dr("IWL_Start")
                    End If

                    If Not IsDBNull(dr("MC_Signed")) Then
                        .MC_Signed = dr("MC_Signed")
                    End If

                    If Not IsDBNull(dr("SH_Sent")) Then
                        .SH_Sent = dr("SH_Sent")
                    End If

                    If Not IsDBNull(dr("SH_Signed")) Then
                        .SH_Signed = dr("SH_Signed")
                    End If

                End With
                eitems.Add(eitem)
            Next

            Me.BindingSource1.DataSource = eitems
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.TurnoverReport_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class