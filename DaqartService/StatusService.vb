#Const SERVICE = 1

#Const TRIAL = 1
Imports System.Data.SqlClient
Imports System.Net.Dns
Imports System.Threading
Imports System
Imports System.Diagnostics

Public Class StatusService

    Dim AllSiteNames As New List(Of String)
    Dim AllProjectIDs As New List(Of String)
    Dim AllProjectNames As New List(Of String)
    Dim runtimeUser As Integer
    Dim CurrentSite As String
    Dim CurrentProjectName As String
    Dim SQLIP As String
    Dim ProjectID As Integer
    Private TheThread As New Thread(AddressOf Action1)
    Private myLog As New EventLog()
    Private Function IsFormMultiElement(ByVal FormID As Integer) As Boolean
        Dim dt As New DataTable
        Dim query As String = "SELECT * FROM forms WHERE ID='" & FormID.ToString & "'"
        dt = UtilExecuteQry(query, "project")

        If dt.Rows(0)(8) = 1 Then
            Return True
        Else
            Return False
        End If

    End Function


    Private Function UtilExecuteQry(ByVal query As String, ByVal thisDB As String) As DataTable
#If SERVICE Then

        Dim useStr As String = ""
        If thisDB = "server" Then
            useStr = "USE [" + CurrentSite + "_ServerDB] " + query
        End If
        If thisDB = "project" Then
            useStr = "USE [" + CurrentProjectName + "] " + query
        End If
        Dim SQLInstance As String = "DAQART"

        '        Dim connStr = "Data Source=""" + SQLIP + """;uid=daqart_sa;pwd=p@ssW0rd"
        Dim connStr As String = "Data Source=""" + SQLIP + "\" + SQLInstance + """;Integrated Security=True"


        Dim conn As SqlConnection = New SqlClient.SqlConnection(connStr)
        conn.Open()

        Dim table As New System.Data.DataTable
        Dim myAdapter As SqlDataAdapter = New SqlDataAdapter(useStr + query, conn)
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        myAdapter.Fill(table)
        conn.Close()
        Return table
#Else
        Return Utilities.ExecuteQuery(query,thisDB)
#End If
    End Function
    Private Sub UtilExecuteNonQry(ByVal query As String, ByVal thisDB As String)
#If SERVICE Then
        Dim useStr As String = ""
        If thisDB = "server" Then
            useStr = "USE [" + CurrentSite + "_ServerDB] " + query
        End If
        If thisDB = "project" Then
            useStr = "USE [" + CurrentProjectName + "] " + query
        End If
        Dim connStr = "Data Source=""" + SQLIP + "," + "2786" + """;uid=daqart_sa;pwd=p@ssW0rd"
        Dim SQLInstance As String = "DAQART"

        Dim conn As SqlConnection = New SqlClient.SqlConnection(connStr)
        conn.Open()
        Dim cmd As SqlCommand = conn.CreateCommand()
        cmd.CommandText = useStr + query
        cmd.ExecuteNonQuery()
        cmd.Dispose()
#Else
        Utilities.ExecuteNonQuery(query, thisDB)
#End If
    End Sub
    Private Sub MakeProjectList()
        Dim SystemCtr As Integer = 0
        AllProjectIDs.Clear()
        AllProjectNames.Clear()
        Dim qry = " Select Name, ProjectID FROM projects"
        Dim dt As DataTable = UtilExecuteQry(qry, "server")
        For i As Integer = 0 To dt.Rows.Count - 1
            AllProjectIDs.Add(dt.Rows(i)(1))
            AllProjectNames.Add(dt.Rows(i)(0))
        Next
    End Sub
    Private Sub MakeSiteList()
        AllSiteNames.Clear()
#If SERVICE Then
        '        SQLIP = "www.issiglobal.com" 'runtime.SQLIP
        SQLIP = "."
        CurrentSite = "Test02" ' runtime.SiteName
#Else
        SQLIP = runtime.SQLIP
        CurrentSite = runtime.SiteName
#End If


#If TRIAL Then

        Dim qry = "USE [TrialDB] Select SiteName FROM Sites "
        Dim dt As DataTable = UtilExecuteQry(qry, "TrailDB")
        For i As Integer = 0 To dt.Rows.Count - 1
            AllSiteNames.Add(dt.Rows(i)(0))
        Next
#Else
        AllSiteNames.Add(CurrentSite)
#End If




    End Sub

    Private Sub UpdateTagStatus(ByVal OwnerID As Integer, ByVal TagID As Integer, _
                    ByVal tagReqdMhr As Single, ByVal tagEarnedMhr As Single, ByVal tagMinCurrentLevel As Integer)
        Dim qry = " SELECT ID FROM  tag_status WHERE OwnerID = " + OwnerID.ToString + _
                    " AND TagID = " + TagID.ToString
        Dim dt As DataTable = UtilExecuteQry(qry, "project")
        If dt.Rows.Count > 0 Then
            qry = "UPDATE tag_status SET RequiredManHours = " + tagReqdMhr.ToString + _
                   ", EarnedManHours = " + tagEarnedMhr.ToString + _
                   ", CurrentLevel = " + tagMinCurrentLevel.ToString + _
                    " WHERE ID = " + dt.Rows(0)(0).ToString
        Else
            qry = "INSERT INTO tag_status (TS,OwnerID,TagID,RequiredManHours,EarnedManHours, CurrentLevel) " + _
                " VALUES ('" + DateTime.Now.ToShortDateString + _
                "'," + OwnerID.ToString + "," + TagID.ToString + _
                "," + tagReqdMhr.ToString + "," + tagEarnedMhr.ToString + _
                "," + tagMinCurrentLevel.ToString + ")"
        End If
        UtilExecuteNonQry(qry, "project")
    End Sub
    Private Sub UpdateSysStatus(ByVal OwnerID As Integer, ByVal SysID As String, _
                    ByVal sysReqdMhr As Single, ByVal sysEarnedMhr As Single, ByVal pkgCurrentLevel As Integer)
        Dim qry = " SELECT ID FROM  system_status WHERE OwnerID = " + OwnerID.ToString + _
                    " AND SystemID = '" + SysID + "'"
        Dim dt As DataTable = UtilExecuteQry(qry, "project")
        If dt.Rows.Count > 0 Then
            qry = "UPDATE system_status SET RequiredManHours = " + sysReqdMhr.ToString + _
                   ", EarnedManHours = " + sysEarnedMhr.ToString + _
                    " WHERE ID = " + dt.Rows(0)(0).ToString
        Else
            qry = "INSERT INTO system_status (TS,OwnerID,SystemID,RequiredManHours,EarnedManHours,CurrentLevel) " + _
                " VALUES ('" + DateTime.Now.ToShortDateString + _
                "'," + OwnerID.ToString + ",'" + SysID.ToString + _
                "'," + sysReqdMhr.ToString + "," + sysEarnedMhr.ToString + _
                "," + pkgCurrentLevel.ToString + ")"
        End If
        UtilExecuteNonQry(qry, "project")
    End Sub
    Private Sub UpdatePkgStatus(ByVal OwnerID As Integer, ByVal PkgID As Integer, _
                    ByVal pkgReqdMhr As Single, ByVal pkgEarnedMhr As Single, ByVal pkgMinCurrentLevel As Integer)
        Dim qry = " SELECT ID FROM  package_status WHERE OwnerID = " + OwnerID.ToString + _
                    " AND packageID = " + PkgID.ToString
        Dim dt As DataTable = UtilExecuteQry(qry, "project")
        If dt.Rows.Count > 0 Then
            qry = "UPDATE package_status SET RequiredManHours = " + pkgReqdMhr.ToString + _
                ", EarnedManHours = " + pkgEarnedMhr.ToString + _
                ", CurrentLevel = " + pkgMinCurrentLevel.ToString + _
                " WHERE ID = " + dt.Rows(0)(0).ToString
        Else
            qry = "INSERT INTO package_status (TS,OwnerID,PackageID,RequiredManHours,EarnedManHours,CurrentLevel) " + _
                " VALUES ('" + DateTime.Now.ToShortDateString + _
                "'," + OwnerID.ToString + "," + PkgID.ToString + _
                "," + pkgReqdMhr.ToString + "," + pkgEarnedMhr.ToString + _
                "," + pkgMinCurrentLevel.ToString + ")"
        End If
        UtilExecuteNonQry(qry, "project")
    End Sub

    Private Function GetTagCurrentLevel(ByVal OwnerID As Integer, ByVal TagID As Integer)
        Dim lvl As Integer
        Dim qry = " SELECT MIN (CurrentLevel) FROM forms_status " + _
                "WHERE OwnerID = " + OwnerID.ToString + _
                " AND TagID = " + TagID.ToString
        Dim dt1 As DataTable = UtilExecuteQry(qry, "project")
        If dt1.Rows.Count > 0 Then
            If Not IsDBNull(dt1.Rows(0)(0)) Then
                If lvl > dt1.Rows(0)(0) Then lvl = dt1.Rows(0)(0)
            End If
        End If
        qry = " SELECT MIN (CurrentLevel) FROM forms_me_status " + _
                "WHERE OwnerID = " + OwnerID.ToString + _
                " AND SourceID = " + TagID.ToString + _
                " AND SourceType = 'Tag'"
        Dim dt2 As DataTable = UtilExecuteQry(qry, "project")
        If dt2.Rows.Count > 0 Then
            If Not IsDBNull(dt2.Rows(0)(0)) Then
                If lvl > dt2.Rows(0)(0) Then lvl = dt2.Rows(0)(0)
            End If
        End If
        Return lvl
    End Function
    Private Function GetTagRequiredManHours(ByVal TagID As Integer, ByVal OwnerID As Integer) As Single
        Dim ManHours As Single = 0
        Dim TagType As Integer

        Dim query As String = "Select TypeID FROM tags WHERE TagID='" & TagID.ToString & "'"
        Dim dt As System.Data.DataTable = UtilExecuteQry(query, "project")
        Try
            dt = UtilExecuteQry(query, "project")
            TagType = dt.Rows(0)(0)
        Catch ex As SqlException
        End Try

        query = "SELECT * FROM requirements WHERE OwnerID = '" + OwnerID.ToString + "' AND TypeID = '" + TagType.ToString + "'"
        dt = UtilExecuteQry(query, "project")

        For i As Integer = 0 To dt.Rows.Count - 1

            If IsFormMultiElement(dt.Rows(i)(4)) Then
                ManHours += Convert.ToSingle(dt.Rows(i)(6))
            Else
                ManHours += Convert.ToSingle(dt.Rows(i)(5))
            End If
        Next

        Return ManHours
    End Function

    Private Function GetTagEarnedManHours(ByVal OwnerID As Integer, ByVal TagID As Integer)
        Dim hrs As Single = 0
        Dim qry = " SELECT SUM (EarnedManHours) FROM forms_status " + _
                "WHERE OwnerID = " + OwnerID.ToString + _
                " AND TagID = " + TagID.ToString
        Dim dt1 As DataTable = UtilExecuteQry(qry, "project")
        If dt1.Rows.Count > 0 Then
            If Not IsDBNull(dt1.Rows(0)(0)) Then hrs = hrs + dt1.Rows(0)(0)
        End If
        qry = " SELECT SUM (EarnedManHours) FROM forms_me_status " + _
                "WHERE OwnerID = " + OwnerID.ToString + _
                " AND SourceID = " + TagID.ToString + _
                " AND SourceType = 'Tag'"
        Dim dt2 As DataTable = UtilExecuteQry(qry, "project")
        If dt2.Rows.Count > 0 Then
            If Not IsDBNull(dt1.Rows(0)(0)) Then hrs = hrs + dt2.Rows(0)(0)
        End If
        Return hrs
    End Function


    Private Sub UpdateAllTagsManHours(ByVal OwnerID As Integer, ByVal OwnerName As String)
        Dim str As String = ""
        Dim qry = " SELECT tagID,TypeID FROM tags "
        Dim tg As DataTable = UtilExecuteQry(qry, "project")
        Dim tagTTL As Single = 0
        For j As Integer = 0 To tg.Rows.Count - 1
            'Dim tagReqdMhr As Single = GetTagRequiredManHours(OwnerID, tg.Rows(j)(0), tg.Rows(j)(1))
            'Dim tagEarnedMhr As Single = GetTagEarnedManHours(OwnerID, tg.Rows(j)(0))

            Dim tagReqdMhr As Single = GetTagRequiredManHours(tg.Rows(j)(0), OwnerID)
            Dim tagEarnedMhr As Single = GetTagEarnedManHours(tg.Rows(j)(0), OwnerID)
            Dim tagCurrentLevel As Integer = GetTagCurrentLevel(OwnerID, tg.Rows(j)(0))
            UpdateTagStatus(OwnerID, tg.Rows(j)(0), tagReqdMhr, tagEarnedMhr, tagCurrentLevel)
        Next
    End Sub
    Private Function GetPackageRequiredManHours(ByVal PackageID As Integer, ByVal OwnerID As Integer) As Single
        Dim ManHours As Single = 0

        'get taglist
        Dim query As String = "Select * FROM tags WHERE PackageID='" & PackageID.ToString & "'"
        Dim dt_Tags As System.Data.DataTable = UtilExecuteQry(query, "project")
        Dim TypeList As String = Nothing
        Dim dt As System.Data.DataTable

        For TagNum As Integer = 0 To dt_Tags.Rows.Count - 1
            'get tag manhours from tags table
            query = "Select * FROM tag_status WHERE TagID='" & dt_Tags.Rows(TagNum)(0).ToString & "' AND OwnerID = '" + OwnerID.ToString + "'"
            dt = UtilExecuteQry(query, "project")

            ManHours += Convert.ToSingle(dt.Rows(0)(4))

            'build a tag type list for SQL HAVING statement
            TypeList += dt_Tags.Rows(TagNum)(4).ToString + ","
        Next
        TypeList = Left(TypeList, TypeList.Length - 1)

        'get package manhours from ME forms
        query = "SELECT DISTINCT FormID, ManHours, Aux01 FROM requirements WHERE " & _
        " OwnerID = '" + OwnerID.ToString + "'" & _
        " AND TypeID IN (" + TypeList + ")"
        dt = UtilExecuteQry(query, "project")

        For i As Integer = 0 To dt.Rows.Count - 1
            If IsFormMultiElement(dt.Rows(i)(0)) Then
                ManHours += Convert.ToSingle(dt.Rows(i)(1))
            End If
        Next


        Return ManHours
    End Function
    Private Function GetPackageEarnedManHours(ByVal PackageID As Integer, ByVal OwnerID As Integer) As Single
        Dim ManHours As Single = 0

        'get taglist
        Dim query As String = "Select * FROM tags WHERE PackageID='" & PackageID.ToString & "'"
        Dim dt_Tags As System.Data.DataTable = UtilExecuteQry(query, "project")
        Dim TypeList As String = Nothing
        Dim dt As System.Data.DataTable

        For TagNum As Integer = 0 To dt_Tags.Rows.Count - 1

            'get tag manhours from tags table
            query = "Select * FROM tag_status WHERE TagID='" & dt_Tags.Rows(TagNum)(0).ToString & "' AND OwnerID = '" + OwnerID.ToString + "'"
            dt = UtilExecuteQry(query, "project")

            ManHours += Convert.ToSingle(dt.Rows(0)(6))

            'build a tag type list for SQL HAVING statement
            TypeList += dt_Tags.Rows(TagNum)(4).ToString + ","
        Next
        TypeList = Left(TypeList, TypeList.Length - 1)

        'get package manhours from ME forms
        query = "SELECT DISTINCT FormID FROM requirements WHERE " & _
        " OwnerID = '" + OwnerID.ToString + "'" & _
        " AND TypeID IN (" + TypeList + ")"
        dt = UtilExecuteQry(query, "project")

        For i As Integer = 0 To dt.Rows.Count - 1
            If IsFormMultiElement(dt.Rows(i)(0)) Then

                Dim dt_FormStatus As New DataTable
                query = "SELECT * FROM forms_me_status WHERE " & _
                " OwnerID = '" + OwnerID.ToString + "' " & _
                " AND SourceID = '" + PackageID.ToString + "' " & _
                " AND FormID = '" + dt.Rows(i)(0).ToString + "' " & _
                " AND SourceType = 'Package' " & _
                " Order By TS DESC "
                dt_FormStatus = UtilExecuteQry(query, "project")

                If Not dt_FormStatus.Rows.Count = 0 Then
                    ManHours += Convert.ToSingle(dt_FormStatus.Rows(0)(11))
                End If
            End If
        Next

        Return ManHours
    End Function


    Private Sub UpdateAllPkgManHours(ByVal OwnerID As Integer, ByVal OwnerName As String)
        Dim str As String = ""
        Dim qry = " SELECT PackageID FROM  Package "
        Dim pkgTbl As DataTable = UtilExecuteQry(qry, "project")
        Dim pkgTTL As Single = 0
        For i As Integer = 0 To pkgTbl.Rows.Count - 1
            Dim pkgReqdMhr As Single = 0
            Dim pkgEarnedMhr As Single = 0
            Dim pkgMinCurrentLevel As Integer = 0
            qry = " SELECT SUM (RequiredManHours), SUM (EarnedManHours) , MIN (CurrentLevel) FROM tag_status, tags " + _
                " WHERE tags.PackageID = " + pkgTbl.Rows(i)(0).ToString + _
                " AND tag_status.OwnerID = " + OwnerID.ToString + _
                " AND tag_status.TagID = tags.TagID "

            Dim ts As DataTable = UtilExecuteQry(qry, "project")
            If ts.Rows(0)(0).ToString > "" Then pkgReqdMhr = ts.Rows(0)(0)
            If ts.Rows(0)(1).ToString > "" Then pkgEarnedMhr = ts.Rows(0)(1)
            If ts.Rows(0)(2).ToString > "" Then pkgMinCurrentLevel = ts.Rows(0)(2)
            Dim pkgReqdMEMhr As Single = 0
            Dim pkgEarnedMEMhr As Single = 0
            Dim pkgMEMinCurrentLevel As Integer = 0
            qry = " SELECT SUM (RequiredManHours), SUM (EarnedManHours), MIN (CurrentLevel) FROM forms_me_status " + _
                " WHERE SourceID = " + pkgTbl.Rows(i)(0).ToString + _
                " AND OwnerID = " + OwnerID.ToString + _
                " AND SourceType = 'Package'"

            Dim tn As DataTable = UtilExecuteQry(qry, "project")
            If tn.Rows(0)(0).ToString > "" Then pkgReqdMEMhr = tn.Rows(0)(0)
            If tn.Rows(0)(1).ToString > "" Then pkgEarnedMEMhr = tn.Rows(0)(1)
            If tn.Rows(0)(2).ToString > "" Then pkgMEMinCurrentLevel = tn.Rows(0)(2)

            'UpdatePkgStatus(OwnerID, pkgTbl.Rows(i)(0), (pkgReqdMhr + pkgReqdMEMhr), (pkgEarnedMhr + pkgEarnedMEMhr), Math.Min(pkgMEMinCurrentLevel, pkgMinCurrentLevel))
            UpdatePkgStatus(OwnerID, pkgTbl.Rows(i)(0), _
                GetPackageRequiredManHours(pkgTbl.Rows(i)(0).ToString, OwnerID.ToString), _
                GetPackageEarnedManHours(pkgTbl.Rows(i)(0).ToString, OwnerID.ToString), _
                Math.Min(pkgMEMinCurrentLevel, pkgMinCurrentLevel))

        Next
    End Sub
    Private Sub UpdateAllSysManHours(ByVal OwnerID As Integer, ByVal OwnerName As String)
        Dim qry = " SELECT SUM (package_status.RequiredManHours), SUM (package_status.EarnedManHours), " + _
            " package.SystemNumber, Min(package_status.CurrentLevel) FROM package_status,package " + _
            " WHERE package_status.PackageID = package.PackageID " + _
            " AND package_status.OwnerID = " + OwnerID.ToString + _
            " GROUP BY package.SystemNumber "
        Dim ts As DataTable = UtilExecuteQry(qry, "project")
        For i As Integer = 0 To ts.Rows.Count - 1
            Dim pkgReqdMhr As Single = 0
            Dim pkgEarnedMhr As Single = 0
            Dim pkgMinCurrentLevel As Integer = 0
            If ts.Rows(i)(0).ToString > "" Then pkgReqdMhr = ts.Rows(i)(0)
            If ts.Rows(i)(1).ToString > "" Then pkgEarnedMhr = ts.Rows(i)(1)
            If ts.Rows(i)(3).ToString > "" Then pkgMinCurrentLevel = ts.Rows(i)(3)
            UpdateSysStatus(OwnerID, ts.Rows(i)(2), pkgReqdMhr, pkgEarnedMhr, pkgMinCurrentLevel)
        Next
    End Sub
    Private Sub UpdateProjectManHours(ByVal OwnerID As Integer, ByVal ProjectID As Integer)
        Dim qry = " SELECT SUM (RequiredManHours), SUM (EarnedManHours), Min(CurrentLevel)  " + _
            " FROM package_status " + _
            " WHERE OwnerID = " + OwnerID.ToString
        Dim ts As DataTable = UtilExecuteQry(qry, "project")
        For i As Integer = 0 To ts.Rows.Count - 1
            Dim ReqdMhr As Single = 0
            Dim EarnedMhr As Single = 0
            Dim minCurrentLevel As Integer = 0
            If ts.Rows(0)(0).ToString > "" Then ReqdMhr = ts.Rows(0)(0)
            If ts.Rows(0)(1).ToString > "" Then EarnedMhr = ts.Rows(0)(1)
            If ts.Rows(0)(2).ToString > "" Then minCurrentLevel = ts.Rows(0)(2)
            qry = " SELECT ID FROM  project_status WHERE OwnerID = " + OwnerID.ToString
            Dim dt As DataTable = UtilExecuteQry(qry, "server")
            If dt.Rows.Count > 0 Then
                qry = "UPDATE project_status SET RequiredManHours = " + ReqdMhr.ToString + _
                       ", EarnedManHours = " + EarnedMhr.ToString + _
                       ", CurrentLevel = " + minCurrentLevel.ToString + _
                        " WHERE ID = " + dt.Rows(0)(0).ToString
            Else
                qry = "INSERT INTO project_status (TS,OwnerID,ProjectID,RequiredManHours,EarnedManHours) " + _
                    " VALUES ('" + DateTime.Now.ToShortDateString + _
                    "'," + OwnerID.ToString + "," + ProjectID.ToString + _
                    "," + ReqdMhr.ToString + "," + EarnedMhr.ToString + _
                    "," + minCurrentLevel.ToString + ")"
            End If
            UtilExecuteNonQry(qry, "server")
        Next
    End Sub


#If SERVICE Then
    Public Sub LoopThroughAllStatus()
        runtimeUser = 1 ' Admin
        MakeSiteList()
        For Each CurrentSite In AllSiteNames
            MakeProjectList()
            Dim ctr As Integer = 0
            For Each ProjectID In AllProjectIDs
                myLog.WriteEntry(String.Format("Looping Service Time: {0}, ProjectID: {1}", DateTime.Now, ProjectID.ToString))
                CurrentProjectName = AllProjectNames(ctr)
                Dim qry = " SELECT OwnerID, Name FROM  owner"
                Dim dt As DataTable = UtilExecuteQry(qry, "server")
                For i As Integer = 0 To dt.Rows.Count - 1
                    UpdateAllTagsManHours(dt.Rows(i)(0), dt.Rows(i)(1))
                    UpdateAllPkgManHours(dt.Rows(i)(0), dt.Rows(i)(1))
                    UpdateAllSysManHours(dt.Rows(i)(0), dt.Rows(i)(1))
                    UpdateProjectManHours(dt.Rows(i)(0), ProjectID)
                Next
                ctr = ctr + 1
            Next
        Next
    End Sub
#Else
    Public Sub LoopThroughAllStatus()
        runtimeUser = 1 ' Admin
        MakeSiteList()

        Dim qry = " SELECT OwnerID, Name FROM  owner"
        Dim dt As DataTable = UtilExecuteQry(qry, "server")
        qry = " Select ProjectID FROM projects WHERE Name = '" + runtime.selectedProject + "'"
        ProjectID = UtilExecuteQry(qry, "server").Rows(0)(0)
        For i As Integer = 0 To dt.Rows.Count - 1
            'UpdateAllFormsRequiredManHours(dt.Rows(i)(0), dt.Rows(i)(1))
            UpdateAllTagsManHours(dt.Rows(i)(0), dt.Rows(i)(1))
            UpdateAllPkgManHours(dt.Rows(i)(0), dt.Rows(i)(1))
            UpdateAllSysManHours(dt.Rows(i)(0), dt.Rows(i)(1))
            UpdateProjectManHours(dt.Rows(i)(0), ProjectID)
        Next


    End Sub
#End If

    Private Sub Action1(ByVal sender As Object)
        Dim autoEvent As New AutoResetEvent(False)
        Do While 1
            LoopThroughAllStatus()
            autoEvent.WaitOne(600000, False)
        Loop
    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)


        Dim param As String = "No Arg"
        If args.Length > 0 Then
            param = args(0).ToString
        End If
        myLog.Source = "DaqartLog"

        myLog.WriteEntry(String.Format("Starting the Daqart Status Service; Time: {0}, args: {1}", DateTime.Now.ToLongDateString, param))


'SiteServerDB = "Test01_ServerDB"
'        CurrentSite = args(0)
        CurrentSite = "Test02"

' Add code here to start your service. This method should set things
' in motion so your service can do its work.
'        SQLHost = GetHostName()
        If TheThread Is Nothing Then
            TheThread = New Thread(AddressOf Action1)
        End If
        TheThread.Start()

    End Sub
Protected Overrides Sub OnStop()
    ' Add code here to perform any tear-down necessary to stop your service.
    TheThread.Abort()
End Sub
End Class
'Class MySample
'    Public Shared Sub Main()

'        If Not EventLog.SourceExists("MySource") Then
'            ' Create the source, if it does not already exist.
'            ' An event log source should not be created and immediately used.
'            ' There is a latency time to enable the source, it should be created
'            ' prior to executing the application that uses the source.
'            ' Execute this sample a second time to use the new source.
'            EventLog.CreateEventSource("MySource", "MyNewLog")
'            Console.WriteLine("CreatingEventSource")
'            'The source is created.  Exit the application to allow it to be registered.
'            Return
'        End If

'        ' Create an EventLog instance and assign its source.
'        Dim myLog As New EventLog()
'        myLog.Source = "MySource"

'        ' Write an informational entry to the event log.    
'        myLog.WriteEntry("Writing to event log.")
'    End Sub 'Main 
'End Class 'MySample

