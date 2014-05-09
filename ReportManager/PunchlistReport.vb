Imports daqartDLL
Imports Microsoft.Reporting.WinForms

Public Class PunchlistReport
    Dim dtPunchlist As DataTable
    Dim DetailLevel As Integer
    Dim SortA As String
    Dim SortB As String
    Dim SortC As String


    Public Sub New(ByVal dt As DataTable, ByVal _DetailLevel As Integer, _
        ByVal _SortA As String, ByVal _SortB As String, ByVal _SortC As String)
        InitializeComponent()
        dtPunchlist = dt
        DetailLevel = _DetailLevel

        SortA = _SortA
        SortB = _SortB
        SortC = _SortC

    End Sub


    Private Sub PunchlistReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ReportManager.PunchlistReport.rdlc"
            ReportDataSource1.Name = "Punchlist Results"
            ReportDataSource1.Value = Me.PunchlistItemsBindingSource
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

            'Adding parameter values
            Dim UserName As String = runtime.UserName
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Report_Par_ProjectName", runtime.selectedProject, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Report_Par_UserID", UserName, False))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("DetailLevel", DetailLevel))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("SortA", SortA))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("SortB", SortB))
            paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("SortC", SortC))
            ReportViewer1.LocalReport.SetParameters(paramList)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            Dim eitems As New PunchlistItems
            For Each dr As DataRow In dtPunchlist.Rows
                Dim eitem As New PunchlistItem
                With eitem
                    .Project = dr("Project")
                    .PunchlistID = dr("PunchlistID")
                    .Description = dr("Description")
                    .Status = dr("Status")
                    If Not IsDBNull(dr("MC_Priority")) Then
                        .Priority = dr("MC_Priority")
                    End If

                    .TagNumber = dr("TagNumber")
                    .System = dr("System")
                    .SystemDescription = dr("System Description")
                    If Not IsDBNull(dr("SH_Priority")) Then
                        .SHPriority = dr("SH_Priority")
                    End If

                    If Not IsDBNull(dr("RFI #")) Then
                        .RFI = dr("RFI #")
                    End If

                    If Not IsDBNull(dr("Location")) Then
                        .Location = dr("Location")
                    End If

                    If Not IsDBNull(dr("ListedBy")) Then
                        .ListedBy = dr("ListedBy")
                    End If

                    If Not IsDBNull(dr("ListedOn")) Then
                        .ListedOn = dr("ListedOn")
                    End If

                    If Not IsDBNull(dr("Action By")) Then
                        .ActionBy = dr("Action By")
                    End If

                    If Not IsDBNull(dr("ApprovedBy")) Then
                        .ApprovedBy = dr("ApprovedBy")
                    End If

                    If Not IsDBNull(dr("ApprovedOn")) Then
                        .ApprovedOn = dr("ApprovedOn")
                    End If

                    If Not IsDBNull(dr("CompletedBy")) Then
                        .CompletedBy = dr("CompletedBy")
                    End If

                    If Not IsDBNull(dr("CompletedOn")) Then
                        .CompletedOn = dr("CompletedOn")
                    End If

                    If Not IsDBNull(dr("ClosedBy")) Then
                        .ClosedBy = dr("ClosedBy")
                    End If

                    If Not IsDBNull(dr("ClosedOn")) Then
                        .ClosedOn = dr("ClosedOn")
                    End If

                    If Not IsDBNull(dr("Comments")) Then
                        .Comment = dr("Comments")
                    End If

                    If Not IsDBNull(dr("Target Date")) Then
                        .TargetDate = dr("Target Date")
                    End If

                    If Not IsDBNull(dr("MC#")) Then
                        '.Location = dr("Location") + ";  " + dr("MC#")
                        .MCNumber = dr("MC#")
                    End If

                    If Not IsDBNull(dr("MC Description")) Then
                        .MCDescription = dr("MC Description")
                    End If

                End With
                eitems.Add(eitem)
            Next

            Me.PunchlistItemsBindingSource.DataSource = eitems
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Utilities.logErrorMessage("ReportManager.Punchlist._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub





End Class