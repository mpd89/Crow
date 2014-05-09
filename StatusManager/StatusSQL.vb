Imports System
Imports daqartDLL
Imports SystemManager


Public Class StatusSQL

    Dim SystemTable As DataTable = New DataTable("sysTable")
    Dim ProjectTable As DataTable = New DataTable("prjTable")
    Dim PackageTable As DataTable = New DataTable("pkjTable")
    Dim TagTable As DataTable = New DataTable("tagTable")
    Dim formTable As DataTable = New DataTable("frmTable")
    Dim SystemPnlTableList As New List(Of TableLayoutPanel)
    Dim ProjectPnlTableList As New List(Of TableLayoutPanel)
    Dim PackagePnlTableList As New List(Of TableLayoutPanel)
    Dim TagPnlTableList As New List(Of TableLayoutPanel)
    Dim FormPnlTableList As New List(Of TableLayoutPanel)

    Dim AllSiteNames As New List(Of String)
    Dim AllProjectIDs As New List(Of String)
    Dim AllProjectNames As New List(Of String)
    Dim AllSystemIDs As New List(Of String)
    Dim AllOwnerIDs As New List(Of Integer)
    Dim AllTypeIDs As New List(Of Integer)
    Dim AllPackageIDs As New List(Of Integer)
    Dim AllTagIDs As New List(Of Integer)
    Dim AllFormReqdMhrs As New List(Of Single)
    Dim runtimeUser As Integer
    Dim CurrentSite As String
    Dim CurrentProjectName As String
    Dim SQLIP As String = "."   '"192.168.5.13"
    Dim ProjectID As Integer


    Private Function UtilExecuteQry(ByVal query As String, ByVal thisDB As String)
        Dim dt As DataTable = Nothing
        Select Case thisDB
            Case "project"
                Dim sqlPrjUtils As DataUtils = New DataUtils("project")

                sqlPrjUtils.OpenConnection()
                dt = sqlPrjUtils.ExecuteQuery(query)
                sqlPrjUtils.CloseConnection()
                Return dt
            Case "server"
                Dim sqlSrvUtils As DataUtils = New DataUtils("server")

                sqlSrvUtils.OpenConnection()
                dt = sqlSrvUtils.ExecuteQuery(query)
                sqlSrvUtils.CloseConnection()


            Case Else
                MessageBox.Show("Invalid Database: " + thisDB)
        End Select
        Return dt
        'Return Utilities.ExecuteQuery(query, thisDB)
    End Function


    Private Sub UtilExecuteNonQry(ByVal query As String, ByVal thisDB As String)
        Select Case thisDB
            Case "project"
                Dim sqlPrjUtils As DataUtils = New DataUtils("project")

                sqlPrjUtils.OpenConnection()
                Dim dt_param As DataTable = sqlPrjUtils.paramDT
                sqlPrjUtils.ExecuteNonQuery(query, dt_param)
                sqlPrjUtils.CloseConnection()
            Case "server"
                Dim sqlSrvUtils As DataUtils = New DataUtils("server")

                sqlSrvUtils.OpenConnection()
                Dim dt_param As DataTable = sqlSrvUtils.paramDT
                sqlSrvUtils.ExecuteNonQuery(query, dt_param)
                sqlSrvUtils.CloseConnection()


            Case Else
                MessageBox.Show("Invalid Database: " + thisDB)
        End Select
        'Utilities.ExecuteNonQuery(query, thisDB)
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

        SQLIP = runtime.SQLIP
        CurrentSite = runtime.SiteName

        AllSiteNames.Add(CurrentSite)

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
                " VALUES ('" + DateTime.Now.ToString + _
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
                " VALUES ('" + DateTime.Now.ToString + _
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
        Dim dt As New DataTable
        dt = UtilExecuteQry(qry, "project")

        If dt.Rows.Count > 0 Then
            qry = "UPDATE package_status SET RequiredManHours = " + pkgReqdMhr.ToString + _
                ", EarnedManHours = " + pkgEarnedMhr.ToString + _
                ", CurrentLevel = " + pkgMinCurrentLevel.ToString + _
                " WHERE ID = " + dt.Rows(0)(0).ToString
        Else
            qry = "INSERT INTO package_status (TS,OwnerID,PackageID,RequiredManHours,EarnedManHours,CurrentLevel) " + _
                " VALUES ('" + DateTime.Now.ToString + _
                "'," + OwnerID.ToString + "," + PkgID.ToString + _
                "," + pkgReqdMhr.ToString + "," + pkgEarnedMhr.ToString + _
                "," + pkgMinCurrentLevel.ToString + ")"
        End If
        UtilExecuteNonQry(qry, "project")
    End Sub


    Private Function GetTagRequiredManHours(ByVal OwnerID As Integer, ByVal TagID As Integer, ByVal TypeID As Integer)
        Dim qry = " SELECT DISTINCT requirements.FormID, forms.MultiElement , " + _
                    " requirements.ManHours ,requirements.Aux01 FROM requirements,forms " + _
                     " WHERE Forms.ID = requirements.FormID AND requirements.TypeID = " + TypeID.ToString + _
                     " AND requirements.OwnerID = " + OwnerID.ToString
        Dim rg As DataTable = UtilExecuteQry(qry, "project")
        Dim TagTTL As Single = 0
        For k As Integer = 0 To rg.Rows.Count - 1
            Dim frmMhr As Single = 0
            Dim frmMETagMhr As Single = 0
            Dim frmMEPkgMhr As Single = 0

            If rg.Rows(k)(1) = 1 Then
                If rg.Rows(k)(3).ToString > "" Then
                    frmMETagMhr = Convert.ToSingle(rg.Rows(k)(3).ToString)
                    frmMEPkgMhr = Convert.ToSingle(rg.Rows(k)(2).ToString)
                End If
            Else
                If rg.Rows(k)(2).ToString > "" Then
                    frmMhr = Convert.ToSingle(rg.Rows(k)(2).ToString)
                End If
            End If
            TagTTL = TagTTL + frmMhr + frmMETagMhr
        Next
        Return TagTTL
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


    Private Function GetPkgRequiredManHours(ByVal OwnerID As Integer, ByVal PkgID As Integer)
        Dim formPkgReqdMhr As Single = 0
        Dim formTagReqdMhr As Single = 0
        Dim qry = "SELECT DISTINCT TypeID From tags WHERE PackageID = " + PkgID.ToString + _
                " AND OwnerID = " + OwnerID.ToString
        Dim dt1 As DataTable = UtilExecuteQry(qry, "project")
        For i As Integer = 0 To dt1.Rows.Count - 1
            qry = "SELECT FormID, ManHours, Aux01 FROM requirements WHERE TypeID = " + _
                dt1.Rows(i)(0) + " AND OwnerID = " + OwnerID.ToString
            Dim dt2 As DataTable = UtilExecuteQry(qry, "project")
            For j As Integer = 0 To dt2.Rows.Count - 1
                qry = "SELECT MultiElement FROM forms WHERE ID=" & dt2.Rows(j)(0).ToString
                Dim dt3 As DataTable = UtilExecuteQry(qry, "project")
                If dt3.Rows(0)(0) = 1 Then
                    If Not IsDBNull(dt2.Rows(j)(1)) Then formPkgReqdMhr = dt2.Rows(j)(1) + formPkgReqdMhr
                End If
            Next
        Next
        qry = "SELECT TagID From tags WHERE PackageID = " + PkgID.ToString + _
                " AND OwnerID = " + OwnerID.ToString
        Dim dt4 As DataTable = UtilExecuteQry(qry, "project")
        For k As Integer = 0 To dt4.Rows.Count - 1
            formTagReqdMhr = formTagReqdMhr + GetTagRequiredManHours(OwnerID, PkgID, dt4.Rows(k)(0))
        Next
        Return formTagReqdMhr + formPkgReqdMhr
    End Function


    Private Sub UpdateAllTagsManHours(ByVal OwnerID As Integer, ByVal OwnerName As String)
        Dim str As String = ""
        Dim qry = " SELECT tagID,TypeID FROM tags "
        Dim tg As New DataTable
        tg = UtilExecuteQry(qry, "project")

        Dim tagTTL As Single = 0
        For j As Integer = 0 To tg.Rows.Count - 1
            'Dim tagReqdMhr As Single = GetTagRequiredManHours(OwnerID, tg.Rows(j)(0), tg.Rows(j)(1))
            'Dim tagEarnedMhr As Single = GetTagEarnedManHours(OwnerID, tg.Rows(j)(0))

            Dim tagReqdMhr As Single = Utilities.GetTagRequiredManHours(tg.Rows(j)(0), OwnerID)
            Dim tagEarnedMhr As Single = Utilities.GetTagEarnedManHours(tg.Rows(j)(0), OwnerID)
            Dim tagCurrentLevel As Integer = GetTagCurrentLevel(OwnerID, tg.Rows(j)(0))
            UpdateTagStatus(OwnerID, tg.Rows(j)(0), tagReqdMhr, tagEarnedMhr, tagCurrentLevel)
        Next
    End Sub


    Private Sub UpdateAllPkgManHours(ByVal OwnerID As Integer, ByVal OwnerName As String)
        Dim str As String = ""
        Dim qry = " SELECT PackageID FROM Package"
        Dim pkgTbl As New DataTable
        pkgTbl = UtilExecuteQry(qry, "project")

        Dim pkgTTL As Single = 0
        For i As Integer = 0 To pkgTbl.Rows.Count - 1
            Dim pkgReqdMhr As Single = 0
            Dim pkgEarnedMhr As Single = 0
            Dim pkgMinCurrentLevel As Integer = 0
            qry = " SELECT SUM (RequiredManHours), SUM (EarnedManHours) , MIN (CurrentLevel) FROM tag_status, tags " + _
                " WHERE tags.PackageID = " + pkgTbl.Rows(i)(0).ToString + _
                " AND tag_status.OwnerID = " + OwnerID.ToString + _
                " AND tag_status.TagID = tags.TagID "

            Dim ts As New DataTable
            ts = UtilExecuteQry(qry, "project")

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

            Dim tn As New DataTable
            tn = UtilExecuteQry(qry, "project")

            If tn.Rows(0)(0).ToString > "" Then pkgReqdMEMhr = tn.Rows(0)(0)
            If tn.Rows(0)(1).ToString > "" Then pkgEarnedMEMhr = tn.Rows(0)(1)
            If tn.Rows(0)(2).ToString > "" Then pkgMEMinCurrentLevel = tn.Rows(0)(2)

            'UpdatePkgStatus(OwnerID, pkgTbl.Rows(i)(0), (pkgReqdMhr + pkgReqdMEMhr), (pkgEarnedMhr + pkgEarnedMEMhr), Math.Min(pkgMEMinCurrentLevel, pkgMinCurrentLevel))
            UpdatePkgStatus(OwnerID, pkgTbl.Rows(i)(0), _
                Utilities.GetPackageRequiredManHours(pkgTbl.Rows(i)(0).ToString, OwnerID.ToString), _
                Utilities.GetPackageEarnedManHours(pkgTbl.Rows(i)(0).ToString, OwnerID.ToString), _
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
                    " VALUES ('" + DateTime.Now.ToString + _
                    "'," + OwnerID.ToString + "," + ProjectID.ToString + _
                    "," + ReqdMhr.ToString + "," + EarnedMhr.ToString + _
                    "," + minCurrentLevel.ToString + ")"
            End If
            UtilExecuteNonQry(qry, "server")
        Next
    End Sub


    Public Sub LoopThroughAllStatus()
        Try

            runtimeUser = 1 ' Admin
            MakeSiteList()

            Dim qry = " SELECT OwnerID, Name FROM  owner"
            Dim dt As DataTable = UtilExecuteQry(qry, "server")
            qry = " Select ProjectID FROM projects WHERE Name = '" + runtime.selectedProject + "'"

            If UtilExecuteQry(qry, "server").Rows.count = 0 Then
                Return
            End If

            ProjectID = UtilExecuteQry(qry, "server").Rows(0)(0)
            For i As Integer = 0 To dt.Rows.Count - 1
                'UpdateAllFormsRequiredManHours(dt.Rows(i)(0), dt.Rows(i)(1))
                UpdateAllTagsManHours(dt.Rows(i)(0), dt.Rows(i)(1))
                UpdateAllPkgManHours(dt.Rows(i)(0), dt.Rows(i)(1))
                UpdateAllSysManHours(dt.Rows(i)(0), dt.Rows(i)(1))
                UpdateProjectManHours(dt.Rows(i)(0), ProjectID)
            Next

        Catch ex As Exception
            Utilities.logErrorMessage("StatusManager.StatusSQL.LoopThroughAllStatus-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class


































