Imports System
Imports System.Data.SqlServerCe

Imports daqartDLL
Imports SystemManager

Public Class Status

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



    'Private connProject As SqlCeConnection = daqartDLL.connections.projectDBConnect(connProject)
    'Private connServer As SqlCeConnection = daqartDLL.connections.serverDBConnect(connServer)
    Public ReadOnly Property ProjectStatusTable(ByVal ProjectName As String) As System.Data.DataTable
        Get
            Dim qry = MakeProjectStatusQry(ProjectName)
            InitializeTable(ProjectTable)
            MakeProjectStatusTable(qry, ProjectTable)
            Return ProjectTable
        End Get
    End Property

    Public ReadOnly Property pkgTagStatusTable(ByVal PkgID As Integer, ByVal OwnerID As Integer) As DataTable
        Get
            Dim qry As String = MakepkgTagStatusQry(PkgID, OwnerID)
            InitializeTable(TagTable)
            MakeStatusTable(qry, TagTable)
            Return TagTable
        End Get
    End Property
    Public ReadOnly Property allPkgTagStatusPanelTable(ByVal PkgID As Integer, ByVal OwnerID As Integer) As List(Of TableLayoutPanel)
        Get
            Dim qry As String = MakepkgTagStatusQry(PkgID, OwnerID)
            MakeTblPnlList(qry, TagPnlTableList)
            Return TagPnlTableList
        End Get
    End Property

    Public ReadOnly Property PackageStatusTable(ByVal pkgID As Integer, ByVal OwnerID As Integer) As System.Data.DataTable
        Get
            Dim qry As String = MakePkgStatusQry(pkgID, OwnerID)
            InitializeTable(PackageTable)
            MakeStatusTable(qry, PackageTable)
            Return PackageTable
        End Get
    End Property
    Public ReadOnly Property PackageStatusPanelTable(ByVal pkgID As Integer, ByVal OwnerID As Integer) As List(Of TableLayoutPanel)
        Get
            Dim qry As String = MakePkgStatusQry(pkgID, OwnerID)
            MakeTblPnlList(qry, PackagePnlTableList)
            Return PackagePnlTableList
        End Get
    End Property

    Public ReadOnly Property SystemStatusTable(ByVal SystemIDStr As String) As System.Data.DataTable
        Get
            Dim qry = MakeSystemStatusQry(SystemIDStr)
            InitializeTable(SystemTable)
            MakeStatusTable(qry, SystemTable)
            For i As Integer = 0 To SystemTable.Rows.Count - 1
                Dim row As DataRow = SystemTable.Rows(i)
                Dim sysID = row(1)
                Dim sysName As String = "Undefined"
                If sysID <> "UDF" Then
                    sysName = SystemDataManager.TranslateSystemID(sysID)
                End If
                SystemTable.Rows(i)(1) = sysName
            Next

            Return SystemTable
        End Get
    End Property
    Private Sub MakeTblPnlList(ByVal qry As String, ByRef PnlList As List(Of TableLayoutPanel))
        Dim i As Integer
        For i = 0 To PnlList.Count - 1
            PnlList(i).Dispose()
        Next
        PnlList.Clear()
        Dim pnlTbl As TableLayoutPanel = New TableLayoutPanel
        pnlTbl.ColumnCount = 6
        pnlTbl.BackColor = Color.White
        pnlTbl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Dim clmWd() As Integer = {40, 200, 70, 70, 70, 70}
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
        Dim rowNo As Integer = 0
        Dim recNo As Integer = 1
        For i = 0 To dt.Rows.Count - 1
            Dim TagNumber As String = dt.Rows(i)(0)
            Dim RequiredManHours As Single = dt.Rows(i)(1)
            Dim TagLevel As Integer = dt.Rows(i)(2)
            Dim EarnedManHours As Single = dt.Rows(i)(3)
            Dim PercentComplete As Single = dt.Rows(i)(4)
            Dim ctrl(6) As Control
            Dim clmTxt() As String = {recNo.ToString, TagNumber, RequiredManHours.ToString, _
                    TagLevel.ToString, EarnedManHours.ToString, PercentComplete.ToString}
            For k As Integer = 0 To 5
                ctrl(k) = New Label
                ctrl(k).Width = clmWd(k)
                ctrl(k).Text = clmTxt(k)
                pnlTbl.Controls.Add(ctrl(k), k, rowNo)
                Dim cStyle As ColumnStyle = New ColumnStyle
                cStyle.Width = ctrl(k).Width
                pnlTbl.ColumnStyles.Add(cStyle)
            Next
            rowNo = rowNo + 1
            recNo = recNo + 1
            If rowNo > 20 Then
                pnlTbl.Size = New System.Drawing.Size(600, (rowNo + 1) * 30)
                PnlList.Add(pnlTbl)
                pnlTbl = New TableLayoutPanel
                pnlTbl.Size = New System.Drawing.Size(600, (rowNo + 1) * 30)
                pnlTbl.ColumnCount = 6
                pnlTbl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
                rowNo = 0
            End If
            End
            If rowNo > 0 Then
                pnlTbl.Size = New System.Drawing.Size(600, (rowNo + 1) * 20)
                PnlList.Add(pnlTbl)
            End If
        Next
    End Sub
    Private Function MakeSystemStatusQry(ByVal SystemIDStr As String) As String
        Dim ORDERstr As String = " ORDER BY SystemID ASC"
        Dim WHEREStr = ""
        If SystemIDStr > "" Then
            WHEREStr = "WHERE SystemID = '" + SystemIDStr + "'"
        End If


        Dim qry = " SELECT  DISTINCT SystemID, OwnerID, RequiredManHours, " + _
                    " CurrentLevel, EarnedManHours, " + _
                    " CASE WHEN system_status.RequiredManHours = '0' THEN 0 ELSE " + _
                    " Round(system_status.EarnedManHours / system_status.RequiredManHours * 100, 2) " + _
                    " END AS PercentComplete " + _
                    " FROM system_status " + WHEREStr + ORDERstr

        Return qry
    End Function
    Private Function MakepkgTagStatusQry(ByVal _PkgID As Integer, ByVal _OwnerID As Integer) As String

        Dim ORDERstr As String = " ORDER BY tags.TagNumber ASC"

        Dim WHEREStr As String = ""
        If _PkgID > 0 And _OwnerID > 0 Then
            WHEREStr = "WHERE tags.PackageID = " + _PkgID.ToString + " AND tag_status.OwnerID = " + _OwnerID.ToString
        ElseIf _PkgID > 0 And _OwnerID = 0 Then
            WHEREStr = "WHERE tags.PackageID = " + _PkgID.ToString
        ElseIf _PkgID = 0 And _OwnerID > 0 Then
            WHEREStr = "WHERE tag_status.OwnerID = " + _OwnerID.ToString
        End If
        Dim qry = " SELECT  DISTINCT tags.TagNumber, tag_status.OwnerID, tag_status.RequiredManHours, " + _
                        " tag_status.CurrentLevel, tag_status.EarnedManHours, " + _
                        " CASE WHEN tag_status.RequiredManHours = '0' THEN 0 ELSE " + _
                        " Round(tag_status.EarnedManHours / tag_status.RequiredManHours * 100, 2) END AS PercentComplete " + _
                        " FROM tags INNER JOIN tag_status ON tags.TagID = tag_status.tagID " + WHEREStr + ORDERstr
        Return qry
    End Function

    Private Function MakePkgStatusQry(ByVal _PkgID As Integer, ByVal _OwnerID As String) As String
        Dim ORDERstr As String = " ORDER BY package.PackageNumber ASC"
        Dim WHEREStr As String = ""
        If _PkgID > 0 And _OwnerID > 0 Then
            WHEREStr = "WHERE Package.PackageID = " + _PkgID.ToString + " AND Package.OwnerID = " + _OwnerID.ToString
        ElseIf _PkgID > 0 And _OwnerID = 0 Then
            WHEREStr = "WHERE Package.PackageID = " + _PkgID.ToString
        ElseIf _PkgID = 0 And _OwnerID > 0 Then
            WHEREStr = "WHERE tags.OwnerID = " + _OwnerID.ToString
        End If

        Dim qry = " SELECT DISTINCT package.PackageNumber, package_status.OwnerID, package_status.RequiredManHours, " + _
           " package_status.CurrentLevel, package_status.EarnedManHours, " + _
           " CASE WHEN package_status.RequiredManHours = '0' THEN 0 ELSE " + _
           " Round(package_status.EarnedManHours / package_status.RequiredManHours * 100, 2) " + _
           " END AS PercentComplete " + _
           " FROM package INNER JOIN package_status ON package.PackageID = package_status.PackageID " + WHEREStr + ORDERstr
        Return qry
    End Function
    Private Function MakeProjectStatusQry(ByVal ProjectName As String) As String
        Dim ORDERstr As String = " ORDER BY projects.Name ASC"
        Dim qry = " SELECT DISTINCT projects.Name, project_status.OwnerID, project_status.RequiredManHours, " + _
           " project_status.CurrentLevel, project_status.EarnedManHours, " + _
           " CASE WHEN project_status.RequiredManHours = '0' THEN 0 ELSE " + _
           " Round(project_status.EarnedManHours / project_status.RequiredManHours * 100, 2) " + _
           " END AS PercentComplete " + _
           " FROM project_status INNER JOIN projects ON project_status.ProjectID = projects.ProjectID " + _
           " WHERE projects.Name = '" + ProjectName + "' " + ORDERstr
        Return qry
    End Function
    Private Sub InitializeTable(ByRef tbl As System.Data.DataTable)
        tbl.Reset()
        Dim idColumn As DataColumn = tbl.Columns.Add("Num", GetType(Integer))
        ' Set the ID column as the primary key column.
        tbl.PrimaryKey = New DataColumn() {idColumn}
        tbl.Columns.Add("Name", GetType(String))
        tbl.Columns.Add("OwnerName", GetType(String))
        tbl.Columns.Add("RequiredManHours", GetType(String))
        tbl.Columns.Add("CurrentLevel", GetType(String))
        tbl.Columns.Add("EarnedManHours", GetType(String))
        tbl.Columns.Add("PercentComplete", GetType(String))

    End Sub
    Private Sub MakeStatusTable(ByVal qry As String, ByRef tbl As DataTable)
        Try

            Dim i As Integer = 1
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")
            sqlSrvUtils.OpenConnection()

            For j As Integer = 0 To dt.Rows.Count - 1
                Dim row As DataRow = tbl.NewRow()
                row("Num") = i
                row("Name") = dt.Rows(j)(0)
                Dim ownerID = dt.Rows(j)(1)
                If Not IsDBNull(ownerID) Then
                    Dim qry1 As String = "SELECT Name From owner WHERE OwnerID = " + ownerID.ToString
                    Dim dt1 As DataTable = sqlSrvUtils.ExecuteQuery(qry1)
                    row("OwnerName") = Convert.ToString(dt1.Rows(0)(0))
                Else
                    row("OwnerName") = "UDF"
                End If
                row("RequiredManHours") = dt.Rows(j)(2)
                row("CurrentLevel") = dt.Rows(j)(3)
                row("EarnedManHours") = dt.Rows(j)(4)
                row("PercentComplete") = dt.Rows(j)(5)
                tbl.Rows.Add(row)
                i = i + 1
            Next
            sqlSrvUtils.CloseConnection()


            'Dim cmd As SqlCeCommand = connProject.CreateCommand()
            'Dim cmd1 As SqlCeCommand = connServer.CreateCommand()
            'cmd.CommandText = qry
            'cmd.CommandType = CommandType.Text
            'Dim read As SqlCeDataReader = cmd.ExecuteReader()
            'Dim i As Integer = 1
            'While read.Read()
            '    Dim row As DataRow = tbl.NewRow()
            '    row("Num") = i
            '    row("Name") = read(0)
            '    Dim ownerID = read(1)
            '    If Not IsDBNull(ownerID) Then
            '        cmd1.CommandText = "SELECT Name From owner WHERE OwnerID = " + ownerID.ToString
            '        row("OwnerName") = Convert.ToString(cmd1.ExecuteScalar())
            '    Else
            '        row("OwnerName") = "UDF"
            '    End If
            '    row("RequiredManHours") = read(2)
            '    row("CurrentLevel") = read(3)
            '    row("EarnedManHours") = read(4)
            '    row("PercentComplete") = read(5)
            '    tbl.Rows.Add(row)
            '    i = i + 1
            'End While
            'read.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'connProject.Close()
        'connServer.Close()

    End Sub
    Private Sub MakeProjectStatusTable(ByVal qry As String, ByRef tbl As DataTable)
        Try

            'Dim cmd As SqlCeCommand = connServer.CreateCommand()
            'Dim cmd1 As SqlCeCommand = connServer.CreateCommand()
            'cmd.CommandText = qry
            'cmd.CommandType = CommandType.Text
            'Dim read As SqlCeDataReader = cmd.ExecuteReader()
            'Dim i As Integer = 1
            'While read.Read()
            '    Dim row As DataRow = tbl.NewRow()
            '    row("Num") = i
            '    row("Name") = read(0)
            '    Dim ownerID = read(1)
            '    If Not IsDBNull(ownerID) Then
            '        cmd1.CommandText = "SELECT Name From owner WHERE OwnerID = " + ownerID.ToString
            '        row("OwnerName") = Convert.ToString(cmd1.ExecuteScalar())
            '    Else
            '        row("OwnerName") = "UDF"
            '    End If
            '    row("RequiredManHours") = read(2)
            '    row("CurrentLevel") = read(3)
            '    row("EarnedManHours") = read(4)
            '    row("PercentComplete") = read(5)
            '    tbl.Rows.Add(row)
            '    i = i + 1
            'End While
            'read.Close()

            Dim i As Integer = 1
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")
            sqlSrvUtils.OpenConnection()
            For j As Integer = 0 To dt.Rows.Count - 1
                Dim row As DataRow = tbl.NewRow()
                row("Num") = i
                row("Name") = dt.Rows(j)(0)
                Dim ownerID = dt.Rows(j)(1)
                If Not IsDBNull(ownerID) Then
                    Dim qry1 As String = "SELECT Name From owner WHERE OwnerID = " + ownerID.ToString
                    Dim dt1 As DataTable = sqlSrvUtils.ExecuteQuery(qry1)
                    row("OwnerName") = Convert.ToString(dt1.Rows(0)(0))
                Else
                    row("OwnerName") = "UDF"
                End If
                row("RequiredManHours") = dt.Rows(j)(2)
                row("CurrentLevel") = dt.Rows(j)(3)
                row("EarnedManHours") = dt.Rows(j)(4)
                row("PercentComplete") = dt.Rows(j)(5)
                tbl.Rows.Add(row)
                i = i + 1
            Next
            sqlSrvUtils.CloseConnection()

            'Dim i As Integer = 1
            'While read.Read()
            '    Dim row As DataRow = tbl.NewRow()
            '    row("Num") = i
            '    row("Name") = read(0)
            '    Dim ownerID = read(1)
            '    If Not IsDBNull(ownerID) Then
            '        cmd1.CommandText = "SELECT Name From owner WHERE OwnerID = " + ownerID.ToString
            '        row("OwnerName") = Convert.ToString(cmd1.ExecuteScalar())
            '    Else
            '        row("OwnerName") = "UDF"
            '    End If
            '    row("RequiredManHours") = read(2)
            '    row("CurrentLevel") = read(3)
            '    row("EarnedManHours") = read(4)
            '    row("PercentComplete") = read(5)
            '    tbl.Rows.Add(row)
            '    i = i + 1
            'End While
            'read.Close()


        Catch ex As Exception
            Utilities.logErrorMessage("StatusManager.Status.MakeProjectStatusTbl-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
        'connServer.Close()
        'connProject.Close()

    End Sub


    'Private connSQLServer As System.Data.SqlClient.SqlConnection = Nothing
    'Dim SQLIP As String = "192.168.5.13"
    Private SQLHost As String = Nothing

    Public Sub New()
        'connProject.Open()
        'connServer.Open()
    End Sub
End Class
