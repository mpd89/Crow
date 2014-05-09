'Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid


Public Class TaskUpdate
    Dim TaskID As Integer
    Dim TotalPercentComplete As Double

    Public Sub New(ByVal ThisTask As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TaskID = ThisTask
    End Sub

    Private Sub TaskUpdate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Me.Text = "Update Task# " + TaskID.ToString
            InitializeGridControl1()

            SetMinimum()

            If TaskUtilities.GetBaseQTY(TaskID) = 0 Then
                tbx_ActQTY.Enabled = False
            End If
        Catch ex As Exception
            Utilities.logErrorMessage("TaskManager.TaskUpdate._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub InitializeGridControl1()
        Dim query = "SELECT TS As [Date],UserID,EarnedManHours As EarnedMH," & _
            " EarnedQuantity As EarnedQTY,PercentComplete As [Percent], ActualManHours As ActMH, ActualQuantity As ActQTY" & _
            " FROM TaskStatus WHERE P3ID='" + TaskID.ToString + "'"

        'Dim dt As New DataTable
        'dt = Utilities.ExecuteQuery(query, "project")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()


        dgv_History.DataSource = dt

        'Dim View As ColumnView = dgv_History.MainView
        'Dim Column As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("taskid")
        'Column.Visible = False

        dgv_History.ForceInitialize()
    End Sub


    Private Sub SetMinimum()
        Dim query = "SELECT SUM(PercentComplete)" & _
            " FROM TaskStatus WHERE P3ID='" + TaskID.ToString + "' ORDER BY TS DESC"

        'Dim dt As New DataTable
        'dt = Utilities.ExecuteQuery(query, "project")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If IsDBNull(dt.Rows(0)(0)) Then
            TotalPercentComplete = 0
        Else
            TotalPercentComplete = dt.Rows(0)(0)
        End If

        NumericUpDown1.Maximum = 100 - TotalPercentComplete


    End Sub


    Private Sub btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Update.Click
        If Not NumericUpDown1.Value = NumericUpDown1.Minimum Then
            UpdateTask()
        End If
        Me.Dispose()
    End Sub


    Private Sub UpdateTask()

        Dim EarnedManHours As Double
        Dim EarnedQuantity As Double

        EarnedManHours = Math.Round(TaskUtilities.GetBaseMH(TaskID) * (NumericUpDown1.Value / 100), 1)
        If tbx_ActQTY.Enabled = False Then
            EarnedQuantity = 0
        Else
            EarnedQuantity = TaskUtilities.GetBaseQTY(TaskID) * (NumericUpDown1.Value / 100)
        End If


        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim query = "INSERT INTO TaskStatus " & _
            " (TS,P3ID,UserID,EarnedManHours,EarnedQuantity,ActualManHours, ActualQuantity, PercentComplete) " & _
            " Values (" & _
            "@TS," & _
            "@P3ID," & _
            "@UserID," & _
            "@EarnedManHours," & _
            "@EarnedQuantity," & _
            "@ActualManHours," & _
            "@ActualQuantity," & _
            "@PercentComplete" & _
            ")"

        Dim dt_param As DataTable = sqlPrjUtils.paramDT
        dt_param.Rows.Add("@TS", Now)
        dt_param.Rows.Add("@P3ID", TaskID.ToString)
        dt_param.Rows.Add("@UserID", runtime.UserMUID.ToString)
        dt_param.Rows.Add("@EarnedManHours", EarnedManHours.ToString)
        dt_param.Rows.Add("@EarnedQuantity", EarnedQuantity.ToString)
        dt_param.Rows.Add("@ActualManHours", tbx_ActMH.Text)
        dt_param.Rows.Add("@ActualQuantity", tbx_ActQTY.Text)
        dt_param.Rows.Add("@PercentComplete", NumericUpDown1.Value.ToString)


        sqlPrjUtils.OpenConnection()
        sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        sqlPrjUtils.CloseConnection()

    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Dim EarnedManHours As Double
        Dim EarnedQuantity As Double

        EarnedManHours = Math.Round(TaskUtilities.GetBaseMH(TaskID) * (NumericUpDown1.Value / 100), 1)
        If tbx_ActQTY.Enabled = False Then
            EarnedQuantity = 0
        Else
            EarnedQuantity = TaskUtilities.GetBaseQTY(TaskID) * (NumericUpDown1.Value / 100)
        End If

        tbx_ActMH.Text = EarnedManHours.ToString
        tbx_ActQTY.Text = EarnedQuantity.ToString


    End Sub



End Class