Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports daqartDLL


Public Class SystemToolsManager
    Public Shared ThisTools As SystemTools


    Public Shared Function OpenSystemTools()
        If Not IsNothing(ThisTools) Then
            If Not ThisTools.IsDisposed Then
                ThisTools.WindowState = FormWindowState.Normal
                ThisTools.BringToFront()
            Else
                ThisTools = New SystemTools()
                ThisTools.Show()
            End If
        Else
            ThisTools = New SystemTools()
            ThisTools.Show()
        End If
    End Function


    Public Shared Sub OpenSystemAuditor()
        OpenSystemTools()

        Dim Auditor As New SystemAuditor
        Auditor.MdiParent = ThisTools
        Auditor.Show()
        Auditor.BringToFront()


    End Sub

    Public Shared Sub OpenPermissions()
        OpenSystemTools()

        Dim Permissions As New SystemPermissions
        Permissions.MdiParent = ThisTools
        Permissions.Show()
        Permissions.BringToFront()

    End Sub


    Private Structure undefStatus
        Dim catagory As String
        Dim Count As Integer
    End Structure


    Public Shared Function GetUnassigned() As DataTable
        Dim connProject As SqlCeConnection = Nothing
        connProject = daqartDLL.connections.projectDBConnect(connProject)
        Dim connServer As SqlCeConnection = Nothing
        connServer = daqartDLL.connections.serverDBConnect(connServer)
        connProject.Open()
        connServer.Open()
        Dim catagory() As String = {"Package", "Tag"}
        Dim hdrs() As String = {"Catagory", "Comments"}
        Dim DisplayTable As DataTable = New DataTable("FormProperties")
        Dim cmd As SqlCeCommand = connProject.CreateCommand()

        cmd.CommandText = " SELECT Count(MUID) As CountTags FROM tags WHERE TypeMUID = 1"
        Dim UndefTags As Integer = cmd.ExecuteScalar()
        cmd.CommandText = " SELECT Count(MUID) As CountPkgs FROM package WHERE OwnerMUID = 1"
        Dim UndefPkgs As Integer = cmd.ExecuteScalar()

        Dim myVal() As Integer = {UndefTags, UndefPkgs}

        For Each s As String In hdrs
            Dim ThisColumn As DataColumn = New DataColumn(s, GetType(String))
            ThisColumn.ColumnName = s
            DisplayTable.Columns.Add(ThisColumn)
        Next
        Dim viewColumn As DataColumn = New DataColumn("View", GetType(Button))
        viewColumn.ColumnName = "View"
        DisplayTable.Columns.Add(viewColumn)

        Dim i As Integer = 0
        For i = 0 To catagory.Length - 1
            Dim dRow As DataRow = DisplayTable.NewRow
            dRow(0) = catagory(i)
            dRow(1) = myVal(i)
            DisplayTable.Rows.Add(dRow)
        Next
        cmd.Dispose()
        connProject.Close()
        connServer.Close()
        Return DisplayTable
    End Function


End Class
