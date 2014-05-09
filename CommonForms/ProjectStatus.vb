Imports system.collections.generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports DataStreams.Csv
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports daqartDLL
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Layout
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports System.Drawing.Printing


Public Class ProjectStatus
    Dim dtPrjStatus As New DataTable
    Dim item1 As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
    Dim itemReqdMhrs As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
    Dim itemEarnedMhrs As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
    Dim itemLevel As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
    Dim itemPcnt As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
    Dim itemNonFCOMhrs As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
    Dim itemNonFCOCompleteMhrs As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()


    Dim FinalizeCounter As Integer = 0
    Dim earnedMhrs As Single = 0
    Dim reqdMHrs As Single = 0
    Dim grandTotalearnedMhrs As Single = 0
    Dim grandTotalreqdMHrs As Single = 0
    Dim NonFCOMhrs As Single = 0
    Dim NonFCOMhrsComplete As Single = 0


    Private Sub ProjectStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblProject.Text = "Project: " + runtime.selectedProject
        Dim clmns() As String = {"Owner", "System", "ReqdMhrs", "EarnedMhrs", "PercentComplete", "Discrepancy MH", "Discrepancy MH Complete"}
        For i As Integer = 0 To clmns.Length - 1
            Dim dc As DataColumn = New DataColumn(clmns(i))
            dtPrjStatus.Columns.Add(dc)
        Next
        Dim query As String = "SELECT * From owner WHERE Name !='Undefined'"
        Dim ownerdt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        For j As Integer = 0 To ownerdt.Rows.Count - 1
            Dim ownerMUID As String = ownerdt.Rows(j)("MUID")
            Dim ownerName As String = ownerdt.Rows(j)("Name")

            query = "SELECT * From system_status WHERE OwnerMUID = '" + ownerMUID + "' AND RequiredManHours > 0"
            Dim dt_ValidOwner As DataTable = runtime.SQLProject.ExecuteQuery(query)

            If dt_ValidOwner.Rows.Count = 0 Then
                Exit For
            End If

            'For k As Integer = 0 To dtSysNum.Rows.Count - 1
            '    Dim dr As DataRow = dtPrjStatus.NewRow
            '    dr("Owner") = ownerName
            '    dr("System") = SystemManager.SystemDataManager.TranslateSystemID(dtSysNum.Rows(k)("SystemMUID"))
            '    dr("ReqdMhrs") = dtSysNum.Rows(k)("RequiredManHours")
            '    dr("EarnedMhrs") = dtSysNum.Rows(k)("EarnedManHours")
            '    Dim reqdMhrs As Single = Convert.ToSingle(dtSysNum.Rows(k)("RequiredManHours"))
            '    If reqdMhrs > 0 Then
            '        dr("PercentComplete") = Convert.ToSingle(dtSysNum.Rows(k)("EarnedManHours")) * 100 / Convert.ToSingle(dtSysNum.Rows(k)("RequiredManHours"))
            '    Else
            '        dr("PercentComplete") = 0
            '    End If
            '    dr("Level") = dtSysNum.Rows(k)("CurrentLevel")
            '    dtPrjStatus.Rows.Add(dr)
            'Next

            query = "SELECT * FROM system_number WHERE TierMUID='1' Order BY Identifier ASC"
            Dim dt_ParentSystems As DataTable = runtime.SQLProject.ExecuteQuery(query)

            For i As Integer = 0 To dt_ParentSystems.Rows.Count - 1
                query = "SELECT * From system_status WHERE OwnerMUID = '" + _
                    ownerMUID + "' AND SystemMUID LIKE '" + dt_ParentSystems.Rows(i)("MUID") + ";%'"
                Dim dtSysNum As DataTable = runtime.SQLProject.ExecuteQuery(query)

                If i = 12 Then
                    Dim stopme As String = ""
                End If

                query = "SELECT SUM(RequiredManHours),SUM(EarnedManHours) From system_status WHERE OwnerMUID = '" + _
                    ownerMUID + "' AND SystemMUID LIKE '" + dt_ParentSystems.Rows(i)("MUID") + ";%'"
                Dim dt_Sums As DataTable = runtime.SQLProject.ExecuteQuery(query)

                Dim dr As DataRow = dtPrjStatus.NewRow
                dr("Owner") = ownerName
                dr("System") = SystemManager.SystemDataManager.TranslateSystemID(dt_ParentSystems.Rows(i)("MUID"))
                dr("System") = Replace(dr("System"), ">", "")
                dr("System") = dr("System") & " - " & SystemManager.SystemDataManager.GetSystemDescription(dt_ParentSystems.Rows(i)("MUID"))

                query = "SELECT SUM(discrepancy.ManHours) AS Expr1" & _
                        " FROM discrepancy INNER JOIN package ON discrepancy.PackageMUID = package.MUID" & _
                        " WHERE package.SystemMUID LIKE '" + dt_ParentSystems.Rows(i)("MUID") + "%'" & _
                        " AND discrepancy.Status != 'No Action'"
                Dim dt_DiscrepancyMH As DataTable = runtime.SQLProject.ExecuteQuery(query)

                Dim SystemOpenDiscrepancyMH As Double = 0
                If dt_DiscrepancyMH.Rows.Count > 0 Then
                    If Not IsDBNull(dt_DiscrepancyMH.Rows(0)(0)) Then
                        SystemOpenDiscrepancyMH = dt_DiscrepancyMH.Rows(0)(0)
                    End If
                End If
                dr("Discrepancy MH") = SystemOpenDiscrepancyMH

                If IsDBNull(dt_Sums.Rows(0)(0)) Then
                    dr("ReqdMhrs") = "0"
                Else
                    dr("ReqdMhrs") = dt_Sums.Rows(0)(0)
                End If

                query = "SELECT SUM(discrepancy.ManHours) AS Expr1" & _
                        " FROM discrepancy INNER JOIN package ON discrepancy.PackageMUID = package.MUID" & _
                        " WHERE package.SystemMUID LIKE '" + dt_ParentSystems.Rows(i)("MUID") + "%'" & _
                        " AND discrepancy.Status = 'Resolved'"
                dt_DiscrepancyMH = runtime.SQLProject.ExecuteQuery(query)

                Dim SystemClosedDiscrepancyMH As Double = 0
                If dt_DiscrepancyMH.Rows.Count > 0 Then
                    If Not IsDBNull(dt_DiscrepancyMH.Rows(0)(0)) Then
                        SystemClosedDiscrepancyMH = dt_DiscrepancyMH.Rows(0)(0)
                    End If
                End If
                dr("Discrepancy MH Complete") = SystemClosedDiscrepancyMH


                If IsDBNull(dt_Sums.Rows(0)(1)) Then
                    dr("EarnedMhrs") = "0"
                Else
                    dr("EarnedMhrs") = dt_Sums.Rows(0)(1)
                End If

                Dim reqdMhrs As Single = dr("ReqdMhrs")
                If reqdMhrs > 0 Then
                    dr("PercentComplete") = Math.Round(Convert.ToSingle(dr("EarnedMhrs")) * 100 / Convert.ToSingle(dr("ReqdMhrs")), 2)
                Else
                    dr("PercentComplete") = 0.0
                End If


                dtPrjStatus.Rows.Add(dr)
            Next
        Next
        runtime.SQLProject.CloseConnection()
        runtime.SQLServer.CloseConnection()

        Me.GridControl1.DataSource = dtPrjStatus
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = GridControl1.MainView
        For i As Integer = 0 To View.Columns.Count - 1
            View.Columns(i).OptionsColumn.FixedWidth = True
            View.Columns(i).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            'View.Columns(i).BestFit()
        Next
        GridView1.SortInfo.ClearAndAddRange(New GridColumnSortInfo() { _
            New GridColumnSortInfo(View.Columns("Owner"), DevExpress.Data.ColumnSortOrder.Descending), _
            New GridColumnSortInfo(View.Columns("System"), DevExpress.Data.ColumnSortOrder.Ascending) _
            }, 1)

        SetupGroupSummaryItems()



    End Sub


    Private Sub SetupGroupSummaryItems()
        GridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways

        ' Create and setup the first summary item.
        item1.FieldName = "System"
        item1.Tag = "System"
        item1.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.GroupSummary.Add(item1)

        ' Create and setup the second summary item.
        itemReqdMhrs.FieldName = "ReqdMhrs"
        itemReqdMhrs.Tag = "ReqdMhrs"
        itemReqdMhrs.SummaryType = DevExpress.Data.SummaryItemType.Sum
        itemReqdMhrs.DisplayFormat = "Reqd Mhrs Total = {0:n2}"
        itemReqdMhrs.ShowInGroupColumnFooter = GridView1.Columns("ReqdMhrs")
        GridView1.GroupSummary.Add(itemReqdMhrs)

        itemEarnedMhrs.FieldName = "EarnedMhrs"
        itemEarnedMhrs.Tag = "EarnedMhrs"
        itemEarnedMhrs.SummaryType = DevExpress.Data.SummaryItemType.Sum
        itemEarnedMhrs.DisplayFormat = "Earned Mhrs Total = {0:n2}"
        itemEarnedMhrs.ShowInGroupColumnFooter = GridView1.Columns("EarnedMhrs")
        GridView1.GroupSummary.Add(itemEarnedMhrs)

        itemLevel.FieldName = "Level"
        itemLevel.Tag = "Level"
        itemLevel.SummaryType = DevExpress.Data.SummaryItemType.Min
        itemLevel.DisplayFormat = "Status {0:n}"
        itemLevel.ShowInGroupColumnFooter = GridView1.Columns("Level")
        GridView1.GroupSummary.Add(itemLevel)

        itemNonFCOMhrs.FieldName = "Discrepancy MH"
        itemNonFCOMhrs.Tag = "Discrepancy MH"
        itemNonFCOMhrs.SummaryType = DevExpress.Data.SummaryItemType.Sum
        itemNonFCOMhrs.DisplayFormat = "Discrepancy MH Total = {0:n2}"
        itemNonFCOMhrs.ShowInGroupColumnFooter = GridView1.Columns("Discrepancy MH")
        GridView1.GroupSummary.Add(itemNonFCOMhrs)

        itemNonFCOCompleteMhrs.FieldName = "Discrepancy MH Complete"
        itemNonFCOCompleteMhrs.Tag = "Discrepancy MH Complete"
        itemNonFCOCompleteMhrs.SummaryType = DevExpress.Data.SummaryItemType.Sum
        itemNonFCOCompleteMhrs.DisplayFormat = "Discprepancy MH Complete Total = {0:n2}"
        itemNonFCOCompleteMhrs.ShowInGroupColumnFooter = GridView1.Columns("Discrepancy MH Complete")
        GridView1.GroupSummary.Add(itemNonFCOCompleteMhrs)

        itemPcnt.FieldName = "PercentComplete"
        itemPcnt.Tag = "PercentComplete"
        itemPcnt.SummaryType = DevExpress.Data.SummaryItemType.Custom
        itemPcnt.DisplayFormat = "% Complete = {0:n2}%"
        itemPcnt.ShowInGroupColumnFooter = GridView1.Columns("PercentComplete")
        GridView1.GroupSummary.Add(itemPcnt)
    End Sub


    Public Sub GridView1_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        Dim View As GridView = CType(sender, GridView)
        If e.IsTotalSummary Then Return
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim rqd As Single = (View.GetRowCellValue(e.RowHandle, "ReqdMhrs"))
            reqdMHrs = reqdMHrs + rqd
            Dim erd As Single = (View.GetRowCellValue(e.RowHandle, "EarnedMhrs"))
            earnedMhrs = earnedMhrs + erd

            Dim _NonFCOmhrs As Single = (View.GetRowCellValue(e.RowHandle, "Discrepancy MH"))
            NonFCOMhrs = NonFCOMhrs + _NonFCOmhrs
            Dim _NonFCOmhrs_complete As Single = (View.GetRowCellValue(e.RowHandle, "Discrepancy MH Complete"))
            NonFCOMhrsComplete = NonFCOMhrsComplete + _NonFCOmhrs_complete

            Return
        End If

        Dim summaryID As String = (CType(e.Item, GridSummaryItem).Tag)
        Dim itm As DevExpress.XtraGrid.GridGroupSummaryItem = CType(e.Item, GridGroupSummaryItem)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            earnedMhrs = 0
            reqdMHrs = 0

            NonFCOMhrs = 0
            NonFCOMhrsComplete = 0
            Return
        End If

        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case "PercentComplete"
                    grandTotalearnedMhrs = grandTotalearnedMhrs + earnedMhrs
                    grandTotalreqdMHrs = grandTotalreqdMHrs + reqdMHrs
                    Try
                        If reqdMHrs > 0 Then
                            e.TotalValue = earnedMhrs * 100 / reqdMHrs
                        Else
                            e.TotalValue = 0
                        End If
                        txtReqdMhrs.Text = String.Format("{0:n2}", grandTotalreqdMHrs)
                        txtEarnedMhrs.Text = String.Format("{0:n2}", grandTotalearnedMhrs)
                        If grandTotalreqdMHrs > 0 Then
                            txtPcntComplete.Text = String.Format("{0:n2}", (grandTotalearnedMhrs * 100 / grandTotalreqdMHrs))
                        Else
                            txtPcntComplete.Text = "0.00%"
                        End If

                        If FinalizeCounter = Utilities.GetOwners.Rows.Count - 1 Then
                            grandTotalearnedMhrs = 0
                            grandTotalreqdMHrs = 0
                            FinalizeCounter = 0
                        Else
                            FinalizeCounter += 1
                        End If


                    Catch ex As Exception

                    End Try
            End Select
        End If
    End Sub


    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        Dim xgp As XtraGridPrinting = New XtraGridPrinting(lblProject.Text, GridControl1)
        xgp.Show()
    End Sub


    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim xgp As XtraGridPrinting = New XtraGridPrinting(lblProject.Text, GridControl1)
        xgp.Show()
    End Sub

End Class