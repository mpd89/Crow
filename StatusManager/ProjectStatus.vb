Imports System.Data.SqlClient
Imports System.Net.Dns
Imports System.Threading
Imports System
Imports System.Diagnostics
Imports Microsoft.Win32
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Imports System.Management
Imports System.IO
Imports daqartDLL



Public Class ProjectStatus
    Dim AllSiteNames As New List(Of String)
    Dim AllProjectIDs As New List(Of String)
    Dim AllProjectNames As New List(Of String)
    Dim runtimeUser As String
    Dim CurrentSite As String
    Dim CurrentProjectName As String
    Dim SQLIP As String
    Dim ProjectID As String
    Private myLog As New EventLog()
    Private SiteName As String
    Dim ProjectSQL As New DataUtils("project")
    Dim ServerSQL As New DataUtils("server")


    Private Sub ProjectStatus_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ProjectSQL.CloseConnection()
        ServerSQL.CloseConnection()
    End Sub


    Private Sub ProjectStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProjectSQL.OpenConnection()
        ServerSQL.OpenConnection()
    End Sub


    Private Sub btn_RunStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RunStatus.Click
        Me.Cursor = Cursors.WaitCursor
        LoopThroughAllStatus()
        Me.Cursor = Cursors.Default

        MessageBox.Show("Project Status complete.")
    End Sub


    Private Function GetIPAddress()
        Return runtime.IISIP
    End Function


    Public Sub LoopThroughAllStatus()
        runtimeUser = 1 ' Admin

        Dim query As String = Nothing
        Dim qry = " SELECT MUID, Name FROM owner WHERE Name != 'Undefined'"
        Dim dt As New DataTable
        dt = ServerSQL.ExecuteQuery(qry)

        For i As Integer = 0 To dt.Rows.Count - 1
            UpdateAllTagsManHours(dt.Rows(i)(0), dt.Rows(i)(1))
            UpdateAllPkgManHours(dt.Rows(i)(0), dt.Rows(i)(1))
            UpdateAllSysManHours(dt.Rows(i)(0), dt.Rows(i)(1))
            UpdateProjectManHours(dt.Rows(i)(0), runtime.selectedProjectID)
        Next

        'report table
        'myLog.WriteEntry(String.Format("Start Report Table:: {0}", Now()))
        'ReportTable.Run(CurrentProjectName)
        'myLog.WriteEntry(String.Format("End Project:: {0}", Now()))
    End Sub


    Private Function IsFormMultiElement(ByVal FormID As String) As Boolean
        Dim dt As New DataTable
        Dim query As String = "SELECT * FROM forms WHERE MUID='" & FormID.ToString & "'"
        dt = ProjectSQL.ExecuteQuery(query)

        If dt.Rows(0)(8) = 1 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub UpdateTagStatus(ByVal OwnerID As String, ByVal TagID As String, _
                    ByVal tagReqdMhr As Single, ByVal tagEarnedMhr As Single, ByVal tagMinCurrentLevel As Integer)

        Dim qry = " SELECT MUID FROM  tag_status WHERE OwnerMUID = '" + OwnerID.ToString + "'" + _
                    " AND TagMUID = '" + TagID.ToString + "'"
        Dim dt As DataTable = ProjectSQL.ExecuteQuery(qry)

        If dt.Rows.Count > 0 Then
            qry = "UPDATE tag_status SET RequiredManHours = " + tagReqdMhr.ToString + _
                   ", EarnedManHours = " + tagEarnedMhr.ToString + _
                   ", CurrentLevel = " + tagMinCurrentLevel.ToString + _
                   " WHERE MUID = '" + dt.Rows(0)(0).ToString + "'"
        Else
            qry = "INSERT INTO tag_status (MUID,TS,OwnerMUID,TagMUID,RequiredManHours,EarnedManHours, CurrentLevel) " + _
                " VALUES (" + _
                "'" + idUtils.GetNextMUID("project", "tag_status") + "'," + _
                "'" + DateTime.Now.ToString + "'," + _
                "'" + OwnerID.ToString + "'," + _
                "'" + TagID.ToString + "'," + _
                "'" + tagReqdMhr.ToString + "'," + _
                "'" + tagEarnedMhr.ToString + "'," + _
                "'" + tagMinCurrentLevel.ToString + "')"
        End If
        ProjectSQL.ExecuteQuery(qry)
    End Sub


    Private Sub UpdateSysStatus(ByVal OwnerID As String, ByVal SysID As String, _
                    ByVal sysReqdMhr As Single, ByVal sysEarnedMhr As Single, ByVal pkgCurrentLevel As Integer)
        Dim qry = " SELECT MUID FROM  system_status WHERE OwnerMUID = '" + OwnerID.ToString + "'" + _
                    " AND SystemMUID = '" + SysID + "'"
        Dim dt As DataTable = ProjectSQL.ExecuteQuery(qry)
        If dt.Rows.Count > 0 Then
            qry = "UPDATE system_status SET RequiredManHours = " + sysReqdMhr.ToString + _
                   ", EarnedManHours = " + sysEarnedMhr.ToString + _
                    " WHERE MUID = '" + dt.Rows(0)(0).ToString + "'"
        Else
            qry = "INSERT INTO system_status (MUID,TS,OwnerMUID,SystemMUID,RequiredManHours,EarnedManHours,CurrentLevel) " + _
                " VALUES (" + _
                "'" + idUtils.GetNextMUID("project", "system_status") + "'," + _
                "'" + DateTime.Now.ToString + "'," + _
                "'" + OwnerID.ToString + "'," + _
                "'" + SysID.ToString + "'," + _
                "'" + sysReqdMhr.ToString + "'," + _
                "'" + sysEarnedMhr.ToString + "'," + _
                "'" + pkgCurrentLevel.ToString + "')"
        End If
        ProjectSQL.ExecuteQuery(qry)
    End Sub


    Private Sub UpdatePkgStatus(ByVal OwnerID As String, ByVal PkgID As String, _
                    ByVal pkgReqdMhr As Single, ByVal pkgEarnedMhr As Single, ByVal pkgMinCurrentLevel As Integer)
        Dim qry = " SELECT MUID FROM  package_status WHERE OwnerMUID = '" + OwnerID.ToString + "'" + _
                    " AND PackageMUID = '" + PkgID.ToString + "'"
        Dim dt As DataTable = ProjectSQL.ExecuteQuery(qry)
        If dt.Rows.Count > 0 Then
            qry = "UPDATE package_status SET RequiredManHours = " + pkgReqdMhr.ToString + _
                ", EarnedManHours = " + pkgEarnedMhr.ToString + _
                ", CurrentLevel = " + pkgMinCurrentLevel.ToString + _
                " WHERE MUID = '" + dt.Rows(0)(0).ToString + "'"
        Else
            qry = "INSERT INTO package_status (MUID,TS,OwnerMUID,PackageMUID,RequiredManHours,EarnedManHours,CurrentLevel) " + _
                " VALUES (" + _
                "'" + idUtils.GetNextMUID("project", "package_status") + "'," + _
                "'" + DateTime.Now.ToString + "'," + _
                "'" + OwnerID.ToString + "'," + _
                "'" + PkgID.ToString + "'," + _
                "'" + pkgReqdMhr.ToString + "'," + _
                "'" + pkgEarnedMhr.ToString + "'," + _
                "'" + pkgMinCurrentLevel.ToString + "')"
        End If
        ProjectSQL.ExecuteQuery(qry)
    End Sub


    Private Function GetTagCurrentLevel(ByVal TagID As String, ByVal OwnerID As String)
        Dim lvl As Integer = -1

        Dim query As String = "SELECT DISTINCT FormMUID FROM forms_status" + _
                " WHERE OwnerMUID = '" + OwnerID.ToString + "'" + _
                " AND TagMUID = '" + TagID.ToString + "'"
        Dim dt_forms As DataTable = ProjectSQL.ExecuteQuery(query)

        For Each dr As DataRow In dt_forms.Rows

            query = "SELECT TOP(1) * FROM forms_status " + _
                " WHERE OwnerMUID = '" + OwnerID.ToString + "'" + _
                " AND TagMUID = '" + TagID.ToString + "'" + _
                " AND FormMUID = '" + dr("FormMUID") + "'" + _
                " ORDER BY TS DESC"
            Dim dt As DataTable = ProjectSQL.ExecuteQuery(query)

            For Each dr2 As DataRow In dt.Rows
                If lvl = -1 Then
                    lvl = dr2("CurrentLevel")
                ElseIf dr2("CurrentLevel") < lvl Then
                    lvl = dr2("CurrentLevel")
                End If
            Next
        Next

        query = "SELECT DISTINCT FormMUID FROM forms_me_status" + _
                " WHERE OwnerMUID = '" + OwnerID.ToString + "'" + _
                " AND SourceMUID = '" + TagID.ToString + "'" + _
                " AND SourceType = 'Tag'"
        dt_forms = ProjectSQL.ExecuteQuery(query)

        For Each dr As DataRow In dt_forms.Rows
            query = "SELECT TOP(1) * FROM forms_me_status " + _
                " WHERE OwnerMUID = '" + OwnerID.ToString + "'" + _
                " AND SourceMUID = '" + TagID.ToString + "'" + _
                " AND FormMUID = '" + dr("FormMUID") + "'" + _
                " AND SourceType = 'Tag'" + _
                " ORDER BY TS DESC"
            Dim dt As DataTable = ProjectSQL.ExecuteQuery(query)

            For Each dr2 As DataRow In dt.Rows
                If lvl = -1 Then
                    lvl = dr2("CurrentLevel")
                ElseIf dr2("CurrentLevel") < lvl Then
                    lvl = dr2("CurrentLevel")
                End If
            Next
        Next


        If lvl = -1 Then lvl = 0

        Return lvl
    End Function


    Private Function GetTagRequiredManHours(ByVal TagID As String, ByVal OwnerID As String) As Single
        Dim ManHours As Single = 0
        Dim TagMUID As String

        Dim query As String = "Select TypeMUID FROM tags WHERE MUID='" & TagID.ToString & "'"
        Dim dt As System.Data.DataTable = ProjectSQL.ExecuteQuery(query)
        Try
            dt = ProjectSQL.ExecuteQuery(query)
            TagMUID = dt.Rows(0)(0)
        Catch ex As SqlException
        End Try

        query = "SELECT * FROM requirements WHERE OwnerMUID = '" + OwnerID.ToString + "' AND TypeMUID = '" + TagMUID.ToString + "'"
        dt = ProjectSQL.ExecuteQuery(query)

        For i As Integer = 0 To dt.Rows.Count - 1
            If IsFormMultiElement(dt.Rows(i)(4)) Then
                ManHours += Convert.ToSingle(dt.Rows(i)(6))
            Else
                ManHours += Convert.ToSingle(dt.Rows(i)(5))
            End If
        Next

        Return ManHours
    End Function


    Private Function GetTagEarnedManHours(ByVal TagID As String, ByVal OwnerID As String)
        Dim hrs As Single = 0
        Dim query As String = "SELECT DISTINCT FormMUID FROM forms_status" + _
                " WHERE OwnerMUID = '" + OwnerID.ToString + "'" + _
                " AND TagMUID = '" + TagID.ToString + "'"
        Dim dt_forms As DataTable = ProjectSQL.ExecuteQuery(query)

        For Each dr As DataRow In dt_forms.Rows


            query = "SELECT TOP(1) * FROM forms_status " + _
                " WHERE OwnerMUID = '" + OwnerID.ToString + "'" + _
                " AND TagMUID = '" + TagID.ToString + "'" + _
                " AND FormMUID = '" + dr("FormMUID") + "'" + _
                " ORDER BY TS DESC"
            Dim dt As DataTable = ProjectSQL.ExecuteQuery(query)


            For Each dr2 As DataRow In dt.Rows
                hrs = hrs + dr2("EarnedManHours")
            Next
        Next

        query = "SELECT DISTINCT FormMUID FROM forms_me_status" + _
                " WHERE OwnerMUID = '" + OwnerID.ToString + "'" + _
                " AND SourceMUID = '" + TagID.ToString + "'" + _
                " AND SourceType = 'Tag'"
        dt_forms = ProjectSQL.ExecuteQuery(query)

        For Each dr As DataRow In dt_forms.Rows

            query = "SELECT TOP(1) * FROM forms_me_status " + _
                " WHERE OwnerMUID = '" + OwnerID.ToString + "'" + _
                " AND SourceMUID = '" + TagID.ToString + "'" + _
                " AND FormMUID = '" + dr("FormMUID") + "'" + _
                " AND SourceType = 'Tag'" + _
                " ORDER BY TS DESC"
            Dim dt As DataTable = ProjectSQL.ExecuteQuery(query)

            For Each dr2 As DataRow In dt.Rows
                hrs = hrs + dr2("EarnedManHours")
            Next

        Next


        hrs = Math.Round(hrs, 1)
        Return hrs
    End Function


    Private Sub UpdateAllTagsManHours(ByVal OwnerID As String, ByVal OwnerName As String)
        Dim str As String = ""
        Dim qry = " SELECT MUID,TypeMUID FROM tags "
        Dim tg As DataTable = ProjectSQL.ExecuteQuery(qry)
        Dim tagTTL As Single = 0
        For j As Integer = 0 To tg.Rows.Count - 1

            'If tg.Rows(j)(0) = "178BFBFF00060FB1-843EE648&001455" Then
            '    Dim hold As String = Nothing
            'End If

            Dim tagReqdMhr As Single = GetTagRequiredManHours(tg.Rows(j)(0), OwnerID)
            Dim tagEarnedMhr As Single = GetTagEarnedManHours(tg.Rows(j)(0), OwnerID)
            Dim tagCurrentLevel As Integer = GetTagCurrentLevel(tg.Rows(j)(0), OwnerID)
            UpdateTagStatus(OwnerID, tg.Rows(j)(0), tagReqdMhr, tagEarnedMhr, tagCurrentLevel)
        Next
    End Sub


    Private Function GetPackageRequiredManHours(ByVal PackageID As String, ByVal OwnerID As String) As Single
        Dim ManHours As Single = 0

        'get taglist
        Dim query As String = "Select * FROM tags WHERE PackageMUID='" & PackageID.ToString & "'"
        Dim dt_Tags As New System.Data.DataTable
        dt_Tags = ProjectSQL.ExecuteQuery(query)

        Dim TypeList As String = Nothing
        Dim dt As New System.Data.DataTable

        For TagNum As Integer = 0 To dt_Tags.Rows.Count - 1
            'get tag manhours from tags table
            query = "Select * FROM tag_status WHERE TagMUID='" & dt_Tags.Rows(TagNum)(0).ToString & "' AND OwnerMUID = '" + OwnerID.ToString + "'"
            dt = ProjectSQL.ExecuteQuery(query)

            ManHours += Convert.ToSingle(dt.Rows(0)(4))

            'build a tag type list for SQL HAVING statement
            TypeList += "'" + dt_Tags.Rows(TagNum)(4).ToString + "',"
        Next

        If Not TypeList = Nothing Then
            'TypeList = Left(TypeList, TypeList.Length - 1)
            TypeList = Mid(TypeList, 1, TypeList.Length - 1)

            'get package manhours from ME forms
            query = "SELECT DISTINCT FormMUID, ManHours, MEManHours FROM requirements WHERE " & _
            " OwnerMUID = '" + OwnerID.ToString + "'" & _
            " AND TypeMUID IN (" + TypeList + ")"
            dt = ProjectSQL.ExecuteQuery(query)

            If Not dt.Rows.Count = 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If IsFormMultiElement(dt.Rows(i)(0)) Then
                        ManHours += Convert.ToSingle(dt.Rows(i)(1))
                    End If
                Next
            End If
        End If

        Return ManHours
    End Function


    Private Function GetPackageEarnedManHours(ByVal PackageID As String, ByVal OwnerID As String) As Single
        Dim ManHours As Single = 0

        'get taglist
        Dim query As String = "Select * FROM tags WHERE PackageMUID='" & PackageID.ToString & "'"
        Dim dt_Tags As System.Data.DataTable = ProjectSQL.ExecuteQuery(query)
        Dim TypeList As String = Nothing
        Dim dt As System.Data.DataTable

        For TagNum As Integer = 0 To dt_Tags.Rows.Count - 1

            'get tag manhours from tags table
            query = "Select * FROM tag_status WHERE TagMUID='" & dt_Tags.Rows(TagNum)(0).ToString & "' AND OwnerMUID = '" + OwnerID.ToString + "'"
            dt = ProjectSQL.ExecuteQuery(query)

            ManHours += Convert.ToSingle(dt.Rows(0)(6))

            'build a tag type list for SQL HAVING statement
            TypeList += "'" + dt_Tags.Rows(TagNum)(4).ToString + "',"

        Next

        If Not TypeList = Nothing Then
            'TypeList = Left(TypeList, TypeList.Length - 1)
            TypeList = Mid(TypeList, 1, TypeList.Length - 1)

            'get package manhours from ME forms
            query = "SELECT DISTINCT FormMUID FROM requirements WHERE " & _
            " OwnerMUID = '" + OwnerID.ToString + "'" & _
            " AND TypeMUID IN (" + TypeList + ") "
            dt = ProjectSQL.ExecuteQuery(query)

            For i As Integer = 0 To dt.Rows.Count - 1
                If IsFormMultiElement(dt.Rows(i)(0)) Then

                    Dim dt_FormStatus As New DataTable
                    query = "SELECT * FROM forms_me_status WHERE " & _
                    " OwnerMUID = '" + OwnerID.ToString + "' " & _
                    " AND SourceMUID = '" + PackageID.ToString + "' " & _
                    " AND FormMUID = '" + dt.Rows(i)(0).ToString + "' " & _
                    " AND SourceType = 'Package' " & _
                    " Order By TS DESC "
                    dt_FormStatus = ProjectSQL.ExecuteQuery(query)
                    query = Nothing

                    If Not dt_FormStatus.Rows.Count = 0 Then
                        ManHours += Convert.ToSingle(dt_FormStatus.Rows(0)(11))
                    End If
                End If
            Next
        End If

        Return ManHours
    End Function


    Private Sub fixTagMEStatus(ByVal PackageID As String, ByVal StatusMUID As String)
        Dim query As String = "SELECT * FROM tags WHERE PackageMUID='" + PackageID + "'"
        Dim dt As DataTable = ProjectSQL.ExecuteQuery(query)

        Dim qry As String = " SELECT * FROM forms_me_status " + _
            " WHERE MUID = '" + StatusMUID + "'" + _
            " ORDER BY TS DESC"
        Dim tn As DataTable = ProjectSQL.ExecuteQuery(query)

        For Each dr As DataRow In dt.Rows
            query = "SELECT MEManHours from requirements WHERE OwnerMUID='" + tn.Rows(0)("OwnerMUID") + "' AND TypeMUID='" + dr("TypeMUID") + "' AND FormMUID='" + tn.Rows(0)("FormMUID") + "'"
            Dim dt2 As DataTable = ProjectSQL.ExecuteQuery(query)

            If dt2.Rows.Count > 0 Then
                query = "INSERT INTO forms_me_status (" + _
                        " MUID,TS,OwnerMUID,SourceMUID,FormMUID,UserMUID,Action,Comment," + _
                        " CurrentLevel,RequiredManHours,EarnedManHours,SourceType" + _
                        " ) VALUES (" + _
                        "'" + idUtils.GetNextMUID("project", "forms_me_status") + "'," + _
                        "'" + Now() + "'," + _
                        "'" + tn.Rows(0)(2) + "'," + _
                        "'" + dr("MUID") + "'," + _
                        "'" + tn.Rows(0)(4) + "'," + _
                        "'" + tn.Rows(0)(5) + "'," + _
                        "'" + tn.Rows(0)(6).ToString + "'," + _
                        "'" + tn.Rows(0)(7) + "'," + _
                        "'" + tn.Rows(0)(9).ToString + "'," + _
                        "'" + dt2.Rows(0)("MEManHours").ToString + "'," + _
                        "'" + dt2.Rows(0)("MEManHours").ToString + "'," + _
                        "'Tag'" + _
                        ")"

                ProjectSQL.ExecuteQuery(query)
            End If
        Next

    End Sub


    Private Sub UpdateAllPkgManHours(ByVal OwnerID As String, ByVal OwnerName As String)
        Dim str As String = ""
        Dim qry = " SELECT MUID FROM  Package "
        Dim pkgTbl As DataTable = ProjectSQL.ExecuteQuery(qry)
        Dim pkgTTL As Single = 0
        For i As Integer = 0 To pkgTbl.Rows.Count - 1

            If pkgTbl.Rows(i)(0) = "178BFBFF00060FB1-843EE648&001282" Then
                Dim hold As String = Nothing
            End If

            Dim pkgReqdMhr As Single = 0
            Dim pkgEarnedMhr As Single = 0
            Dim pkgMinCurrentLevel As Integer = 0
            qry = " SELECT SUM (RequiredManHours), SUM (EarnedManHours) , MIN (CurrentLevel) FROM tag_status, tags " + _
                " WHERE tags.PackageMUID = '" + pkgTbl.Rows(i)(0).ToString + "'" + _
                " AND tag_status.OwnerMUID = '" + OwnerID.ToString + "'" + _
                " AND tag_status.TagMUID = tags.MUID "

            Dim ts As DataTable = ProjectSQL.ExecuteQuery(qry)
            If ts.Rows(0)(0).ToString > "" Then pkgReqdMhr = ts.Rows(0)(0)
            If ts.Rows(0)(1).ToString > "" Then pkgEarnedMhr = ts.Rows(0)(1)
            If ts.Rows(0)(2).ToString > "" Then pkgMinCurrentLevel = ts.Rows(0)(2)


            Dim pkgReqdMEMhr As Single = 0
            Dim pkgEarnedMEMhr As Single = 0
            Dim pkgMEMinCurrentLevel As Integer = -1

            qry = "SELECT DISTINCT FormMUID FROM forms_me_status " + _
                " WHERE SourceMUID = '" + pkgTbl.Rows(i)(0).ToString + "'" + _
                " AND OwnerMUID = '" + OwnerID.ToString + "'" + _
                " AND SourceType = 'Package'"
            Dim dt_forms As DataTable = ProjectSQL.ExecuteQuery(qry)

            If dt_forms.Rows.Count = 0 Then
                pkgMEMinCurrentLevel = pkgMinCurrentLevel
            End If

            For Each dr As DataRow In dt_forms.Rows
                qry = " SELECT TOP(1) RequiredManHours,EarnedManHours,CurrentLevel,MUID FROM forms_me_status " + _
                    " WHERE SourceMUID = '" + pkgTbl.Rows(i)(0).ToString + "'" + _
                    " AND OwnerMUID = '" + OwnerID.ToString + "'" + _
                    " AND FormMUID = '" + dr("FormMUID") + "'" + _
                    " AND SourceType = 'Package'" + _
                    " ORDER BY TS DESC"

                Dim tn As DataTable = ProjectSQL.ExecuteQuery(qry)

                'If tn.Rows(0)(0).ToString > "" Then pkgReqdMEMhr = pkgReqdMEMhr + tn.Rows(0)(0)
                'If tn.Rows(0)(1).ToString > "" Then pkgEarnedMEMhr = pkgEarnedMEMhr + tn.Rows(0)(1)
                'If tn.Rows(0)(2).ToString > "" Then
                '    If pkgMEMinCurrentLevel = -1 Then
                '        pkgMEMinCurrentLevel = tn.Rows(0)(2)
                '    ElseIf tn.Rows(0)("CurrentLevel") < pkgMEMinCurrentLevel Then
                '        pkgMEMinCurrentLevel = tn.Rows(0)(2)
                '    End If
                '    'If pkgMEMinCurrentLevel > -1 Then Me.fixTagMEStatus(pkgTbl.Rows(i)(0).ToString, tn.Rows(0)("MUID"))
                'End If

                If tn.Rows.Count > 0 Then
                    If tn.Rows(0)(0).ToString > "" Then pkgReqdMEMhr = pkgReqdMEMhr + tn.Rows(0)(0)
                    If tn.Rows(0)(1).ToString > "" Then pkgEarnedMEMhr = pkgEarnedMEMhr + tn.Rows(0)(1)
                    If tn.Rows(0)(2).ToString > "" Then
                        If pkgMEMinCurrentLevel = -1 Then
                            pkgMEMinCurrentLevel = tn.Rows(0)(2)
                        ElseIf tn.Rows(0)("CurrentLevel") < pkgMEMinCurrentLevel Then
                            pkgMEMinCurrentLevel = tn.Rows(0)(2)
                        End If
                        'If pkgMEMinCurrentLevel > -1 Then Me.fixTagMEStatus(pkgTbl.Rows(i)(0).ToString, tn.Rows(0)("MUID"))
                    End If

                End If
            Next


            If pkgMEMinCurrentLevel = -1 Then pkgMEMinCurrentLevel = 0

            'UpdatePkgStatus(OwnerID, pkgTbl.Rows(i)(0), (pkgReqdMhr + pkgReqdMEMhr), (pkgEarnedMhr + pkgEarnedMEMhr), Math.Min(pkgMEMinCurrentLevel, pkgMinCurrentLevel))
            UpdatePkgStatus(OwnerID, pkgTbl.Rows(i)(0), _
                GetPackageRequiredManHours(pkgTbl.Rows(i)(0).ToString, OwnerID.ToString), _
                GetPackageEarnedManHours(pkgTbl.Rows(i)(0).ToString, OwnerID.ToString), _
                Math.Min(pkgMEMinCurrentLevel, pkgMinCurrentLevel))

        Next
    End Sub


    Private Sub UpdateAllSysManHours(ByVal OwnerID As String, ByVal OwnerName As String)
        Dim qry = " SELECT SUM (package_status.RequiredManHours), SUM (package_status.EarnedManHours), " + _
            " package.SystemMUID, Min(package_status.CurrentLevel) FROM package_status,package " + _
            " WHERE package_status.PackageMUID = package.MUID " + _
            " AND package_status.OwnerMUID = '" + OwnerID.ToString + "'" + _
            " GROUP BY package.SystemMUID "
        Dim ts As DataTable = ProjectSQL.ExecuteQuery(qry)
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


    Private Sub UpdateProjectManHours(ByVal OwnerID As String, ByVal ProjectID As String)
        Dim qry = " SELECT SUM (RequiredManHours), SUM (EarnedManHours), Min(CurrentLevel)  " + _
            " FROM package_status " + _
            " WHERE OwnerMUID = '" + OwnerID.ToString + "'"
        Dim ts As DataTable = ServerSQL.ExecuteQuery(qry)
        For i As Integer = 0 To ts.Rows.Count - 1
            Dim ReqdMhr As Single = 0
            Dim EarnedMhr As Single = 0
            Dim minCurrentLevel As Integer = 0
            If ts.Rows(0)(0).ToString > "" Then ReqdMhr = ts.Rows(0)(0)
            If ts.Rows(0)(1).ToString > "" Then EarnedMhr = ts.Rows(0)(1)
            If ts.Rows(0)(2).ToString > "" Then minCurrentLevel = ts.Rows(0)(2)
            qry = " SELECT MUID FROM  project_status WHERE OwnerMUID = '" + OwnerID.ToString + "'"
            Dim dt As DataTable = ServerSQL.ExecuteQuery(qry)
            If dt.Rows.Count > 0 Then
                qry = "UPDATE project_status SET RequiredManHours = " + ReqdMhr.ToString + _
                       ", EarnedManHours = " + EarnedMhr.ToString + _
                       ", CurrentLevel = " + minCurrentLevel.ToString + _
                        " WHERE MUID = '" + dt.Rows(0)(0).ToString + "'"
            Else
                qry = "INSERT INTO project_status (MUID,TS,OwnerMUID,ProjectMUID,RequiredManHours,EarnedManHours,CurrentLevel) " + _
                    " VALUES (" + _
                    "'" + idUtils.GetNextMUID("server", "project_status") + "'," + _
                    "'" + DateTime.Now.ToString + "'," + _
                    "'" + OwnerID.ToString + "'," + _
                    "'" + ProjectID.ToString + "'," + _
                    "'" + ReqdMhr.ToString + "'," + _
                    "'" + EarnedMhr.ToString + "'," + _
                    "'" + minCurrentLevel.ToString + "')"
            End If
            ServerSQL.ExecuteQuery(qry)
        Next
    End Sub


    Public Shared Function GetInstalledInstance() As String
        Return runtime.SQLInstance
    End Function


    Private Function GetSQLPortAddress()
        Return runtime.SQLPort
    End Function


 
End Class