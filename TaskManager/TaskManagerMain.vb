'Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid


Public Class TaskManagerMain
    '  Private sqlConnProjectDB As SqlCeConnection = daqartDLL.connections.projectDBConnect(sqlConnProjectDB)

    Private dt_Status As New DataTable
    Private dt_TaskInfo As New DataTable
    Private ds_TaskSet As New DataSet

    Private Sub TaskManagerMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateTaskInfoTable()

        CreateStatusTable()

        MergeTables()

        InitializeGridControl1()

    End Sub

    Private Sub ExitTaskManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitTaskManagerToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub InitializeGridControl1()

        'Dim keyColumn As DataColumn = dt.Columns("taskid")
        dgv_TaskMain.DataSource = ds_TaskSet.Tables(0)

        Dim View As ColumnView = dgv_TaskMain.MainView
        Dim Column As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("taskid")

        dgv_TaskMain.ForceInitialize()
    End Sub


    Private Sub dgv_TaskMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_TaskMain.DoubleClick
        Dim View As ColumnView = dgv_TaskMain.MainView
        Dim ParentView As GridView = View.ParentView
        'MessageBox.Show(View.GetFocusedRowCellValue("taskid"))
        'dgv_TaskMain.PackageViewerManager.OpenPackage(View.GetFocusedRowCellValue("PackageID"), View.GetFocusedRowCellValue("Package"))

        Dim frm_TaskUpdate As New TaskUpdate(View.GetFocusedRowCellValue("taskid"))
        frm_TaskUpdate.ShowDialog()

    End Sub


    Private Sub CreateTaskInfoTable()
        Dim query = "SELECT tl.TaskGroup As PackageGroup,tl.taskid,tl.p3id," & _
            " tl.Description,tl.TS AS LastUpdate, tl.ScheduledStart, tl.ScheduledFinish" & _
            " from TaskList As tl"

        'dt_TaskInfo = Utilities.ExecuteQuery(query, "project")


        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        dt_TaskInfo = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub CreateStatusTable()

        dt_Status.Locale = dt_TaskInfo.Locale

        'create status columns
        dt_Status.Columns.Add("p3id", GetType(System.Int32))
        dt_Status.Columns.Add("percentcomplete")
        dt_Status.Columns.Add("earnedMH")
        dt_Status.Columns.Add("earnedQTY")
        dt_Status.Columns.Add("actualMH")
        dt_Status.Columns.Add("actualQTY")


        For Each dr As DataRow In dt_TaskInfo.Rows
            Dim query As String
            Dim dt As New DataTable

            query = "SELECT SUM(PercentComplete) AS EXPR1, Round(SUM(EarnedManHours),1) AS EXPR2," & _
            " SUM(EarnedQuantity) AS EXPR3, SUM(ActualManHours) AS EXPR4, " & _
            " SUM(ActualQuantity) AS EXPR5" & _
            " FROM TaskStatus" & _
            " WHERE (P3ID = '" + dr("taskid").ToString + "')"
            'dt = Utilities.ExecuteQuery(query, "project")

            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            dt = sqlPrjUtils.ExecuteQuery(query)
            sqlPrjUtils.CloseConnection()

            dt_Status.Rows.Add(dr("taskid"), dt.Rows(0)(0), dt.Rows(0)(1), dt.Rows(0)(2), dt.Rows(0)(3), dt.Rows(0)(4))
        Next
    End Sub


    Private Sub MergeTables()

        ds_TaskSet.Tables.Add(dt_TaskInfo)
        ds_TaskSet.Tables.Add(dt_Status)

        'Dim relation As New DataRelation("TaskJoin", _
        'ds_TaskSet.Tables(0).Columns(1), _
        'ds_TaskSet.Tables(1).Columns(0) _
        ')

        ds_TaskSet.Relations.Add(ds_TaskSet.Tables(1).Columns("p3id"), ds_TaskSet.Tables(0).Columns("taskid"))
        dt_TaskInfo.Columns.Add("PerComp", GetType(System.Double), "Parent.percentcomplete")
        dt_TaskInfo.Columns.Add("EarnedMH", GetType(System.Double), "Parent.earnedMH")
        dt_TaskInfo.Columns.Add("EarnedQTY", GetType(System.Double), "Parent.earnedQTY")
        dt_TaskInfo.Columns.Add("ActualMH", GetType(System.Double), "Parent.actualMH")
        dt_TaskInfo.Columns.Add("ActualQTY", GetType(System.Double), "Parent.actualQTY")

    End Sub


End Class
