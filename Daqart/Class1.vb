Imports System.Data.SqlClient
Imports System.Net.Dns
Imports System.Threading
Public Class Class1
    '#If 0 Then

    '    Private connSQLServer As System.Data.SqlClient.SqlConnection = Nothing
    '    'Dim SQLIP As String = "192.168.5.13"
    '    Private SQLHost As String = Nothing
    '    Private Sub UpdateTagStatus(ByVal CurrentProjectName As String, ByVal TagID As Integer, ByVal LowestTagLevel As Integer, _
    '                    ByVal TagRequiredMhrs As Single, ByVal TagEarnedManHours As Single)

    '        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
    '        cmd.CommandText = " USE [" + CurrentProjectName + " ] SELECT TagID From tag_status " + _
    '                        " WHERE TagID = " + TagID.ToString
    '        Dim myID = Convert.ToInt32(cmd.ExecuteScalar())
    '        Dim qry As String
    '        If myID > 0 Then
    '            qry = "USE [" + CurrentProjectName + " ] UPDATE tag_status SET CurrentLevel = " + LowestTagLevel.ToString + _
    '                    " , RequiredManHours = " + TagRequiredMhrs.ToString + _
    '                    " , EarnedManHours = " + TagEarnedManHours.ToString + _
    '                    " WHERE TagID = " + TagID.ToString
    '        Else
    '            qry = "USE [" + CurrentProjectName + " ] INSERT INTO tag_status (TagID, CurrentLevel, RequiredManHours, EarnedManHours ) VALUES (" + _
    '            TagID.ToString + "," + LowestTagLevel.ToString + "," + TagRequiredMhrs.ToString + "," + TagEarnedManHours.ToString + ")"
    '        End If
    '        cmd.CommandText = qry
    '        cmd.ExecuteNonQuery()
    '        cmd.Dispose()

    '    End Sub
    '    Private Sub UpdatePackageStatus(ByVal CurrentProjectName As String, ByVal PkgID As Integer, ByVal LowestPkgLevel As Integer, _
    '                    ByVal PkgRequiredMhrs As Single, ByVal PkgEarnedManHours As Single)

    '        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
    '        cmd.CommandText = " USE [" + CurrentProjectName + " ] SELECT PackageID From Package_status " + _
    '                        " WHERE PackageID = " + PkgID.ToString
    '        Dim myID = Convert.ToInt32(cmd.ExecuteScalar())
    '        Dim qry As String
    '        If myID > 0 Then
    '            qry = "USE [" + CurrentProjectName + " ] UPDATE Package_status SET CurrentLevel = " + LowestPkgLevel.ToString + _
    '                    " , RequiredManHours = " + PkgRequiredMhrs.ToString + _
    '                    " , EarnedManHours = " + PkgEarnedManHours.ToString + _
    '                    " WHERE PackageID = " + PkgID.ToString
    '        Else
    '            qry = "USE [" + CurrentProjectName + " ] INSERT INTO Package_status (PackageID, CurrentLevel, RequiredManHours, EarnedManHours ) VALUES (" + _
    '            PkgID.ToString + "," + LowestPkgLevel.ToString + "," + PkgRequiredMhrs.ToString + "," + PkgEarnedManHours.ToString + ")"
    '        End If
    '        cmd.CommandText = qry
    '        cmd.ExecuteNonQuery()
    '        cmd.Dispose()
    '    End Sub
    '    Private Sub UpdateSystemStatus(ByVal CurrentProjectName As String, ByVal SystemID As String, ByVal OwnerID As Integer, ByVal LowestSystemLevel As Integer, _
    '                    ByVal SysRequiredMhrs As Single, ByVal SystemEarnedManHours As Single)

    '        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
    '        cmd.CommandText = " USE [" + CurrentProjectName + " ] SELECT ID From System_status " + _
    '                        " WHERE SystemID = '" + SystemID + "' AND OwnerID = " + OwnerID.ToString
    '        Dim myID = Convert.ToString(cmd.ExecuteScalar())
    '        Dim qry As String
    '        If myID > "" Then
    '            qry = "USE [" + CurrentProjectName + " ] UPDATE System_status SET CurrentLevel = " + LowestSystemLevel.ToString + _
    '                    " , RequiredManHours = " + SysRequiredMhrs.ToString + _
    '                    " , EarnedManHours = " + SystemEarnedManHours.ToString + _
    '                    " WHERE ID = " + myID.ToString
    '        Else
    '            qry = "USE [" + CurrentProjectName + " ] INSERT INTO System_status (SystemID, OwnerID, CurrentLevel, RequiredManHours, EarnedManHours ) VALUES ('" + _
    '            SystemID + "'," + OwnerID.ToString + "," + LowestSystemLevel.ToString + "," + SysRequiredMhrs.ToString + "," + SystemEarnedManHours.ToString + ")"
    '        End If
    '        cmd.CommandText = qry
    '        cmd.ExecuteNonQuery()
    '        cmd.Dispose()
    '    End Sub
    '    Private Sub UpdateProjectStatus(ByVal ProjectID As Integer, ByVal LowestProjectLevel As Integer, _
    '                    ByVal PrjRequiredMhrs As Single, ByVal ProjectEarnedManHours As Single)


    '        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
    '        cmd.CommandText = " USE [ServerDB] SELECT ProjectID From Project_status " + _
    '                        " WHERE ProjectID = " + ProjectID.ToString
    '        Dim myID = Convert.ToInt32(cmd.ExecuteScalar())
    '        Dim qry As String
    '        If myID > 0 Then
    '            qry = "USE [ServerDB] UPDATE project_status SET CurrentLevel = " + LowestProjectLevel.ToString + _
    '                    " , RequiredManHours = " + PrjRequiredMhrs.ToString + _
    '                    " , EarnedManHours = " + ProjectEarnedManHours.ToString + _
    '                    " WHERE ProjectID = '" + ProjectID.ToString + "'"
    '        Else
    '            qry = "USE [ServerDB] INSERT INTO project_status (ProjectID, CurrentLevel, RequiredManHours, EarnedManHours ) VALUES (" + _
    '            ProjectID.ToString + "," + LowestProjectLevel.ToString + "," + PrjRequiredMhrs.ToString + "," + ProjectEarnedManHours.ToString + ")"
    '        End If
    '        cmd.CommandText = qry
    '        cmd.ExecuteNonQuery()
    '        cmd.Dispose()
    '    End Sub

    '    Private Sub UpdatePackageRequiredMhrs(ByVal CurrentProjectName As String, ByVal PackageID As Integer, ByVal OwnerID As Integer)
    '        Dim AllTagIDs As New List(Of Integer)
    '        Dim AllTypeIDs As New List(Of Integer)
    '        Dim AllFormIDs As New List(Of Integer)

    '        Dim CurrentTagID As Integer
    '        Dim CurrentTypeID As Integer
    '        Dim LowestTagLevel As Integer = 9
    '        Dim TtlTagEarnedManHours As Single = 0
    '        Dim TtlTagRequiredManHours As Single = 0
    '        Dim qry As String = "USE [" + CurrentProjectName + "] Select TagID, TypeID FROM tags WHERE PackageID = " + PackageID.ToString
    '        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
    '        cmd.CommandText = qry
    '        cmd.CommandType = CommandType.Text
    '        Dim read As SqlDataReader = cmd.ExecuteReader()
    '        While read.Read()
    '            AllTagIDs.Add(read(0))
    '            AllTypeIDs.Add(read(1))
    '        End While
    '        read.Close()
    '        Dim TypeIDCtr As Integer = 0

    '        For Each CurrentTagID In AllTagIDs
    '            Dim FormEarnedMhrs As Single = 0
    '            Dim LowestFormLevel As Integer = 9
    '            Dim TtlFormEarnedManHours As Single = 0
    '            Dim TtlFormRequiredManHours As Single = 0
    '            Dim RequiredManHours As Single = 0

    '            CurrentTypeID = AllTypeIDs(TypeIDCtr)
    '            cmd.CommandText = "USE [" + CurrentProjectName + "] SELECT FormID, ManHours FROM requirements " + _
    '                    " WHERE(TypeID = " + CurrentTypeID.ToString + ") And (" + _
    '                    "OwnerID = " + OwnerID.ToString + ")"
    '            read = cmd.ExecuteReader()
    '            AllFormIDs.Clear()
    '            While read.Read()
    '                AllFormIDs.Add(read(0))
    '                TtlFormRequiredManHours = TtlFormRequiredManHours + read(1)
    '            End While
    '            read.Close()
    '            Dim FormID As Integer
    '            For Each FormID In AllFormIDs
    '                cmd.CommandText = "USE [" + CurrentProjectName + "] SELECT CurrentLevel, RequiredManHours, TS FROM forms_status " + _
    '                                        " WHERE(TagID = " + CurrentTagID.ToString + ") AND (" + _
    '                                        " FormID = " + FormID.ToString + ") ORDER BY TS Desc"
    '                read = cmd.ExecuteReader()
    '                While read.Read()
    '                    If LowestFormLevel > read(0) Then
    '                        LowestFormLevel = read(0)
    '                    End If
    '                    TtlFormEarnedManHours = TtlFormEarnedManHours + Convert.ToSingle(read(1))
    '                End While
    '                read.Close()
    '            Next
    '            If LowestFormLevel = 9 Then
    '                LowestFormLevel = 0
    '            End If
    '            If LowestTagLevel > LowestFormLevel Then
    '                LowestTagLevel = LowestFormLevel
    '            End If
    '            UpdateTagStatus(CurrentProjectName, CurrentTagID, LowestFormLevel, _
    '                    TtlFormRequiredManHours, TtlFormEarnedManHours)
    '            TtlTagEarnedManHours = TtlTagEarnedManHours + TtlFormEarnedManHours
    '            TtlTagRequiredManHours = TtlTagRequiredManHours + TtlFormRequiredManHours
    '        Next
    '        If LowestTagLevel = 9 Then
    '            LowestTagLevel = 0
    '        End If
    '        UpdatePackageStatus(CurrentProjectName, PackageID, LowestTagLevel, _
    '                TtlTagRequiredManHours, TtlTagEarnedManHours)

    '        cmd.Dispose()

    '    End Sub



    '    Public Sub LoopThroughAllStatus()
    '        Dim SQLIP As String = "192.168.5.13"
    '        '        SQLIP = "."

    '        Dim SQLInstance As String = "DAQART"
    '        '        Dim connStr As String = "Data Source=""" + SQLIP + "\" + SQLInstance + """;UID=aakhan@issi.local;PWD=L@lukhet4"
    '        SQLHost = "1001-ds002"
    '        '        Dim connStr As String = "Data Source=""" + SQLIP + "\" + SQLInstance + """;uid=daqart_sa;pwd=p@ssW0rd"
    '        Dim connStr As String = "Data Source=""" + SQLIP + "\" + SQLInstance + """;uid=daqart_sa;pwd=p@ssW0rd"

    '        connSQLServer = New SqlClient.SqlConnection(connStr)
    '        connSQLServer.Open()



    '        Dim AllProjectIDs As New List(Of String)
    '        Dim AllProjectNames As New List(Of String)
    '        Dim CurrentProjectName As String
    '        Dim CurrentProjectID As String
    '        Dim CurrentSystemID As String
    '        Dim CurrentOwnerID As String
    '        Dim CurrentPackageID As Integer
    '        Dim AllSystemIDs As New List(Of String)


    '        Dim AllOwnerIDs As New List(Of Integer)
    '        Dim AllTypeIDs As New List(Of Integer)
    '        Dim AllPackageIDs As New List(Of Integer)

    '        connSQLServer = New SqlClient.SqlConnection(connStr)
    '        connSQLServer.Open()


    '        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
    '        cmd.CommandText = "USE [ServerDB] Select Name, ProjectID FROM projects"
    '        Dim read As SqlDataReader = cmd.ExecuteReader()
    '        Dim SystemCtr As Integer = 0
    '        AllProjectIDs.Clear()
    '        AllProjectNames.Clear()
    '        While read.Read()
    '            AllProjectIDs.Add(read(1))
    '            AllProjectNames.Add(read(0))
    '        End While
    '        read.Close()
    '        Dim PrjCtr As Integer = 0
    '        For Each CurrentProjectName In AllProjectNames
    '            CurrentProjectID = AllProjectIDs(PrjCtr)
    '            AllSystemIDs.Clear()
    '            Try

    '            cmd.CommandText = "USE [" + CurrentProjectName + "] Select DISTINCT SystemNumber FROM package "
    '                read = cmd.ExecuteReader()
    '                While read.Read()
    '                    AllSystemIDs.Add(read(0))
    '                End While
    '                read.Close()
    '            Catch ex As Exception
    '                read.Close()
    '            End Try
    '            Dim LowestSystemLevel As Integer = 9
    '            Dim TtlSystemEarnedManHours As Single = 0
    '            Dim TtlSystemRequiredManHours As Single = 0

    '            For Each CurrentSystemID In AllSystemIDs
    '                cmd.CommandText = "USE [ServerDB] Select OwnerID FROM owner "
    '                read = cmd.ExecuteReader()
    '                AllOwnerIDs.Clear()
    '                While read.Read()
    '                    AllOwnerIDs.Add(read(0))
    '                End While
    '                read.Close()

    '                For Each CurrentOwnerID In AllOwnerIDs
    '                    cmd.CommandText = "USE [" + CurrentProjectName + "] Select PackageID FROM Package WHERE SystemNumber = '" + CurrentSystemID.ToString + _
    '                                "' AND OwnerID = " + CurrentOwnerID.ToString
    '                    read = cmd.ExecuteReader()
    '                    AllPackageIDs.Clear()
    '                    While read.Read()
    '                        AllPackageIDs.Add(read(0))
    '                    End While
    '                    read.Close()
    '                    Dim LowestPackageLevel As Integer = 9
    '                    Dim TtlPackageEarnedManHours As Single = 0
    '                    Dim TtlPackageRequiredManHours As Single = 0
    '                    For Each CurrentPackageID In AllPackageIDs
    '                        UpdatePackageRequiredMhrs(CurrentProjectName, CurrentPackageID, CurrentOwnerID)
    '                        cmd.CommandText = "USE [" + CurrentProjectName + "] SELECT CurrentLevel, " + _
    '                                " RequiredManHours, EarnedManHours FROM package_status " + _
    '                                " WHERE(PackageID = " + CurrentPackageID.ToString + ")"
    '                        read = cmd.ExecuteReader()
    '                        If read.Read Then
    '                            If LowestPackageLevel > read(0) Then
    '                                LowestPackageLevel = read(0)
    '                            End If
    '                            TtlPackageRequiredManHours = TtlPackageRequiredManHours + (read(1))
    '                            TtlPackageEarnedManHours = TtlPackageEarnedManHours + (read(2))
    '                        End If
    '                        read.Close()
    '                    Next

    '                    If LowestSystemLevel > LowestPackageLevel Then
    '                        LowestSystemLevel = LowestPackageLevel
    '                    End If
    '                    If LowestSystemLevel = 9 Then
    '                        LowestSystemLevel = 0
    '                    End If

    '                    If CurrentSystemID > "0" Then
    '                        UpdateSystemStatus(CurrentProjectName, CurrentSystemID, CurrentOwnerID, LowestSystemLevel, _
    '                               TtlPackageRequiredManHours, TtlPackageEarnedManHours)
    '                    Else
    '                        UpdateSystemStatus(CurrentProjectName, "UDF", CurrentOwnerID, LowestSystemLevel, TtlPackageRequiredManHours, TtlPackageEarnedManHours)
    '                    End If
    '                    TtlSystemRequiredManHours = TtlSystemRequiredManHours + TtlPackageRequiredManHours
    '                    TtlSystemEarnedManHours = TtlSystemEarnedManHours + TtlPackageEarnedManHours
    '                Next
    '            Next

    '            UpdateProjectStatus(CurrentProjectID, LowestSystemLevel, TtlSystemRequiredManHours, TtlSystemEarnedManHours)
    '            PrjCtr = PrjCtr + 1
    '        Next

    '        cmd.CommandText = "USE [ServerDB] INSERT INTO ServiceLog (Message,MessageType) VALUES (" + _
    '                            "@Message,@MessageType )"
    '        cmd.Parameters.AddWithValue("@Message", "'Status updated'")
    '        Dim myType As Integer = 1
    '        cmd.Parameters.AddWithValue("@MessageType", myType.ToString)

    '        cmd.ExecuteNonQuery()
    '        cmd.Dispose()
    '        connSQLServer.Close()
    '        connSQLServer.Dispose()


    '    End Sub
    '#End If
End Class

