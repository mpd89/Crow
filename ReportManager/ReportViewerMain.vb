Imports System.Data.SqlClient
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class ReportViewerMain
    Private connSQLServer As System.Data.SqlClient.SqlConnection = serverRemoteConnect(connSQLServer)
    Private useServerDB As String = "USE [ServerDB] "
    Private useProjectDB As String = "USE [Project01] "
    Private AllProjects As New List(Of String)
    Private AllSystemIDs As New List(Of String)
    Private AllPackageIDs As New List(Of Integer)
    Private AllTagIDs As New List(Of Integer)
    Private AllFormIDs As New List(Of Integer)
    Private AllOwnerIDs As New List(Of Integer)
    Private AllTypeIDs As New List(Of Integer)
    Private FormStatusTable As DataTable
    Private TagStatusTable As DataTable
    Private PackageStatusTable As DataTable
    Private SystemStatusTable As DataTable
    Private ProjectStatusTable As DataTable
    Private CurrentProjectID As String
    Private CurrentTypeID As Integer
    Private CurrentOwnerID As Integer
    Private CurrentPackageID As Integer
    Private CurrentTagID As Integer
    Private CurrentFormID As Integer
    Private CurrentSystemID As String
    Private CurrentFormLevel As Integer
    Private CurrentFormPercentComplete As Single
    Private CurrentFormEarnedManHours As Single
    Private CurrentFormRequiredManHours As Single
    Private CurrentTagLevel As Integer
    Private CurrentTagPercentComplete As Single
    Private CurrentTagEarnedManHours As Single
    Private CurrentTagRequiredManHours As Single
    Private CurrentPackageLevel As Integer
    Private CurrentPackagePercentComplete As Single
    Private CurrentPackageEarnedManHours As Single
    Private CurrentPackageRequiredManHours As Single
    Private CurrentSystemLevel As Integer
    Private CurrentSystemPercentComplete As Single
    Private CurrentSystemEarnedManHours As Single
    Private CurrentSystemRequiredManHours As Single
    Private CurrentProjectLevel As Integer
    Private CurrentProjectPercentComplete As Single
    Private CurrentProjectEarnedManHours As Single
    Private CurrentProjectRequiredManHours As Single


    Private LowestSystemLevel As Integer
    Private TtlSystemPercentComplete As Single
    Private TtlSystemEarnedManHours As Single
    Private TtlSystemRequiredManHours As Single

    Private LowestPackageLevel As Integer
    Private TtlPackagePercentComplete As Single
    Private TtlPackageEarnedManHours As Single
    Private TtlPackageRequiredManHours As Single

    Private LowestTagLevel As Integer
    Private TtlTagPercentComplete As Single
    Private TtlTagEarnedManHours As Single
    Private TtlTagRequiredManHours As Single

    Private LowestFormLevel As Integer
    Private TtlFormPercentComplete As Single
    Private TtlFormEarnedManHours As Single
    Private TtlFormRequiredManHours As Single

    Private NewLevel As Integer
    Private NewPercentComplete As Single
    Private NewEarnedManHours As Single
    Private Sub UpdateTagStatus()
        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        cmd.CommandText = " SELECT CurrentLevel, PercentComplete From tag_status " + _
                        " WHERE TagID = " + CurrentTagID.ToString
        Dim myID = Convert.ToInt32(cmd.ExecuteScalar())
        Dim qry As String
        If myID > 0 Then
            qry = "UPDATE tag_status SET (CurrentLevel = " + LowestTagLevel.ToString + _
                    " , PercentComplete = " + TtlTagPercentComplete.ToString + _
                    " , EarnedManHours = " + TtlTagEarnedManHours.ToString + _
                    " WHERE TagID = " + CurrentTagID.ToString
        Else
            qry = "INSERT INTO tag_status (CurrentLevel, PercentComplete, EarnedManHours ) VALUES (" + _
            LowestTagLevel.ToString + "," + TtlTagPercentComplete.ToString + "," + TtlTagEarnedManHours.ToString + ")"
        End If
        cmd.CommandText = qry
        cmd.ExecuteNonQuery()
    End Sub
    Private Sub UpdatePackageStatus()
        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        cmd.CommandText = " SELECT CurrentLevel, PercentComplete From Package_status " + _
                        " WHERE PackageID = " + CurrentPackageID.ToString
        Dim myID = Convert.ToInt32(cmd.ExecuteScalar())
        Dim qry As String
        If myID > 0 Then
            qry = "UPDATE Package_status SET (CurrentLevel = " + LowestPackageLevel.ToString + _
                    " , PercentComplete = " + TtlPackagePercentComplete.ToString + _
                    " , EarnedManHours = " + TtlPackageEarnedManHours.ToString + _
                    " WHERE PackageID = " + CurrentPackageID.ToString
        Else
            qry = "INSERT INTO Package_status (CurrentLevel, PercentComplete, EarnedManHours ) VALUES (" + _
            LowestPackageLevel.ToString + "," + TtlPackagePercentComplete.ToString + "," + TtlPackageEarnedManHours.ToString + ")"
        End If
        cmd.CommandText = qry
        cmd.ExecuteNonQuery()
    End Sub
    Private Sub UpdateSystemStatus()
        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        cmd.CommandText = " SELECT CurrentLevel, PercentComplete From System_status " + _
                        " WHERE SystemID = " + CurrentSystemID.ToString
        Dim myID = Convert.ToInt32(cmd.ExecuteScalar())
        Dim qry As String
        If myID > 0 Then
            qry = "UPDATE System_status SET (CurrentLevel = " + LowestSystemLevel.ToString + _
                    " , PercentComplete = " + TtlSystemPercentComplete.ToString + _
                    " , EarnedManHours = " + TtlSystemEarnedManHours.ToString + _
                    " WHERE SystemID = " + CurrentSystemID.ToString
        Else
            qry = "INSERT INTO System_status (CurrentLevel, PercentComplete, EarnedManHours ) VALUES (" + _
            LowestSystemLevel.ToString + "," + TtlSystemPercentComplete.ToString + "," + TtlSystemEarnedManHours.ToString + ")"
        End If
        cmd.CommandText = qry
        cmd.ExecuteNonQuery()
    End Sub
    Private Sub GetAllForms()
        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        cmd.CommandText = "USE [" + CurrentProjectID + "] Select DISTINCT FormID FROM forms_status WHERE TagID = " + CurrentTagID.ToString
        cmd.CommandType = CommandType.Text
        Dim read As SqlDataReader = cmd.ExecuteReader()
        AllFormIDs.Clear()
        While read.Read()
            AllFormIDs.Add(read(0))
        End While
        read.Close()
        LowestFormLevel = 9
        TtlFormPercentComplete = 0
        TtlFormEarnedManHours = 0
        TtlFormRequiredManHours = 0
    End Sub
    Private Sub GetAllTags()
        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        cmd.CommandText = "USE [" + CurrentProjectID + "] Select tagID, TypeID FROM tags WHERE PackageID = " + CurrentPackageID.ToString
        cmd.CommandType = CommandType.Text
        Dim read As SqlDataReader = cmd.ExecuteReader()
        AllTagIDs.Clear()
        AllTypeIDs.Clear()
        While read.Read()
            AllTagIDs.Add(read(0))
            AllTypeIDs.Add(read(1))
        End While
        read.Close()
        LowestTagLevel = 9
        TtlTagPercentComplete = 0
        TtlTagEarnedManHours = 0
        TtlTagRequiredManHours = 0
    End Sub
    Private Sub GetAllPackages()
        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        cmd.CommandText = "USE [" + CurrentProjectID + "] Select PackageID, OwnerID FROM Package WHERE SystemNumber = '" + CurrentSystemID.ToString + "'"
        cmd.CommandType = CommandType.Text
        Dim read As SqlDataReader = cmd.ExecuteReader()
        AllPackageIDs.Clear()
        AllOwnerIDs.Clear()
        Try

            While read.Read()
                AllPackageIDs.Add(read(0))
                AllOwnerIDs.Add(read(1))
            End While
        Catch ex As Exception
            System.IO.File.AppendAllText("C:\tmp\ISSILog.txt", _
                   ex.Message & Now.ToString() & vbCrLf)
        End Try

        read.Close()
        LowestPackageLevel = 9
        TtlPackagePercentComplete = 0
        TtlPackageEarnedManHours = 0
        TtlPackageRequiredManHours = 0
    End Sub
    Private Sub GetAllSystems()
        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        cmd.CommandText = "USE [" + CurrentProjectID + "] Select DISTINCT SystemNumber FROM package "
        cmd.CommandType = CommandType.Text
        Dim read As SqlDataReader = cmd.ExecuteReader()
        AllSystemIDs.Clear()
        While read.Read()
            AllSystemIDs.Add(read(0))
        End While
        read.Close()
        LowestSystemLevel = 9
        TtlSystemPercentComplete = 0
        TtlSystemEarnedManHours = 0
        TtlSystemRequiredManHours = 0

    End Sub
    Private Sub ProcessFormStatus()
        If LowestFormLevel > CurrentFormLevel Then
            LowestFormLevel = CurrentFormLevel
        End If
        TtlFormPercentComplete = TtlFormPercentComplete + CurrentFormPercentComplete
        TtlFormEarnedManHours = TtlFormEarnedManHours + CurrentFormEarnedManHours
        TtlFormRequiredManHours = TtlFormRequiredManHours + CurrentFormRequiredManHours
    End Sub
    Private Sub ProcessTagStatus()
        If LowestTagLevel > CurrentFormLevel Then
            LowestTagLevel = CurrentFormLevel
        End If
        TtlTagPercentComplete = TtlTagPercentComplete + CurrentFormPercentComplete
        TtlTagEarnedManHours = TtlTagEarnedManHours + CurrentFormEarnedManHours
        TtlTagRequiredManHours = TtlTagRequiredManHours + CurrentFormRequiredManHours
    End Sub
    Private Sub ProcessPackageStatus()
        If LowestPackageLevel > CurrentTagLevel Then
            LowestPackageLevel = CurrentTagLevel
        End If
        TtlPackagePercentComplete = TtlPackagePercentComplete + TtlTagPercentComplete
        TtlPackageEarnedManHours = TtlPackageEarnedManHours + TtlTagEarnedManHours
        TtlPackageRequiredManHours = TtlPackageRequiredManHours + TtlTagRequiredManHours
    End Sub
    Private Sub ProcessSystemStatus()
        If LowestSystemLevel > CurrentTagLevel Then
            LowestTagLevel = CurrentTagLevel
        End If
        TtlSystemPercentComplete = TtlSystemPercentComplete + TtlPackagePercentComplete
        TtlSystemEarnedManHours = TtlSystemEarnedManHours + TtlPackageEarnedManHours
        TtlSystemRequiredManHours = TtlSystemRequiredManHours + TtlPackageRequiredManHours
    End Sub
    Private Sub GetFormCurrentStatus()
        CurrentFormLevel = 0
        CurrentFormPercentComplete = 0
        CurrentFormEarnedManHours = "0"
        CurrentFormRequiredManHours = 0
        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        cmd.CommandText = CurrentProjectID + " SELECT CurrentLevel, PercentComplete, Aux03 As EarnedManHours, TS " + _
                " WHERE (TagID = " + CurrentTagID.ToString + ") And (FormID = " + CurrentFormID.ToString + " ORDER BY TS DESC"
        cmd.CommandType = CommandType.Text
        Dim read As SqlDataReader = cmd.ExecuteReader()
        If read.Read Then
            CurrentFormLevel = read(0)
            CurrentFormPercentComplete = read(1)
            CurrentFormEarnedManHours = read(2).ToString
        End If
        cmd.CommandText = CurrentProjectID + " SELECT ManHours FROM requirements " + _
                " WHERE(TypeID) = " + CurrentTypeID.ToString + ") And (" + _
                "FormID = " + CurrentFormID.ToString + ") And " + _
                "OwnerID = " + CurrentOwnerID.ToString + ")"
        CurrentFormRequiredManHours = Convert.ToSingle(cmd.ExecuteScalar)
        read.Close()
    End Sub

    Private Sub LoopThroughAllStatus()
        System.IO.File.AppendAllText("C:\tmp\ISSILog.txt", _
            "Status Update Start " & Now.ToString() & vbCrLf)

        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        cmd.CommandText = "USE [ServerDB] Select Name FROM projects"
        cmd.CommandType = CommandType.Text
        Dim read As SqlDataReader = cmd.ExecuteReader()
        Dim SystemCtr As Integer = 0
        Try
            AllProjects.Clear()
            While read.Read()
                AllProjects.Add(read(0))
            End While
            read.Close()
            For Each CurrentProjectID In AllProjects
                AllSystemIDs.Clear()
                GetAllSystems()
                For Each CurrentSystemID In AllSystemIDs
                    AllOwnerIDs.Clear()
                    AllPackageIDs.Clear()
                    GetAllPackages()
                    Dim OwnerIDCtr As Integer = 0
                    Dim PackageCtr As Integer = 0
                    For Each CurrentPackageID In AllPackageIDs
                        CurrentOwnerID = AllOwnerIDs(OwnerIDCtr)
                        AllTagIDs.Clear()
                        AllTypeIDs.Clear()
                        GetAllTags()
                        Dim TypeIDCtr As Integer = 0
                        For Each CurrentTagID In AllTagIDs
                            CurrentTypeID = AllTypeIDs(TypeIDCtr)
                            GetAllForms()
                            For Each CurrentFormID In AllFormIDs
                                GetFormCurrentStatus()
                                ProcessFormStatus()
                            Next
                            ProcessTagStatus()
                            TypeIDCtr = TypeIDCtr + 1
                            SystemCtr = SystemCtr + 1
                            If SystemCtr = 4585 Then
                                SystemCtr = SystemCtr
                            End If
                        Next
                        UpdateTagStatus()
                        ProcessPackageStatus()
                        OwnerIDCtr = OwnerIDCtr + 1
                    Next
                    PackageCtr = PackageCtr + 1
                    UpdatePackageStatus()
                    ProcessSystemStatus()
                Next
            Next
        Catch ex As Exception
            System.IO.File.AppendAllText("C:\tmp\ISSILog.txt", _
                   ex.Message & Now.ToString() & vbCrLf)
        End Try
        cmd.Dispose()
        System.IO.File.AppendAllText("C:\tmp\ISSILog.txt", _
            "Status Updated End " & Now.ToString() & vbCrLf)

    End Sub

    Public Shared Function serverRemoteConnect(ByVal conn As SqlClient.SqlConnection)
        Dim connStr As String

        Dim SQLIP = "192.168.5.13"
        Dim SQLInstance = "DAQART"

        If Not conn Is Nothing Then conn.Close()
        Dim thisConn As New ConnectionState
        If Not conn Is Nothing Then conn.Close()
        connStr = "Data Source=""" + SQLIP + "\" + SQLInstance + """;Integrated Security=True"
        'connStr = "Data Source=""" + "LT002" + "\" + runtime.SQLInstance + """;Integrated Security=True"

        Try
            conn = New SqlClient.SqlConnection(connStr)
        Catch ex As SqlClient.SqlException
            System.IO.File.AppendAllText("C:\tmp\ISSILog.txt", _
                   ex.Message & Now.ToString() & vbCrLf)
        End Try

        Return conn

    End Function
    Private Sub ExitPackageViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitPackageViewerToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub ReportType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportType.Click

    End Sub

    Private Sub OverviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverviewToolStripMenuItem.Click
        LoopThroughAllStatus()
        '    UpdateStatusTables()
    End Sub

    Private Sub ReportViewerMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connSQLServer.Open()
    End Sub

    Private Sub ReportViewerMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        connSQLServer.Dispose()
    End Sub

    Private Sub StatusOverviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusOverviewToolStripMenuItem.Click
        '        InitializeGridControl1()
    End Sub
End Class
