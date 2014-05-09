Imports System
Imports System.Data
Imports System.IO
Imports System.Data.SqlServerCe
Imports System.Windows.Forms
Imports System.Threading
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports daqartDLL
Imports SystemManager
Imports FormDesigner
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports System.Data.SqlClient
Imports Microsoft.Win32


Public Class VersionUpdates
    Private dtClientUpdates As DataTable


    Private Function GetInstallVersion()
        Dim regKey As String
        Dim regValue As String
        regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
        regValue = Registry.GetValue(regKey, "Version", Nothing)
        Me.tbx_CurrentVersion.Text = regValue
        Return regValue
    End Function


    Private Sub CompareFile(ByVal fname As String)
        Dim br1() As Byte = File.ReadAllBytes(fname)
        Dim br() As Byte = File.ReadAllBytes("D:\Daqart\setup.cmp")
        'Return 0
        For i As Integer = 0 To br1.Length - 1
            If br1(i) <> br(i) Then
                MessageBox.Show("Difference At " + i.ToString + " first:" + br(0).ToString + " second: " + br(1).ToString)
            End If
        Next
    End Sub


    Private Function CheckUpdatesRequried()
        Me.tbx_RequiredVersion.Tag = 0
        Dim CurrentVersion() As String = Split(GetInstallVersion(), ".")
        Dim qry = "SELECT MUID, FileName, FileDate, FileVersion, FileComments FROM ClientUpdates"

        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(qry)
        sqlSrvUtils.CloseConnection()

        If dt.Rows.Count <= 0 Then
            MessageBox.Show("No Updates required")
            Return 0
        End If
        Dim match As Boolean = False
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim ver() As String = Split(dt.Rows(i)("FileVersion"), ".")
            For j As Integer = 0 To ver.Length - 1
                If ver(j) > CurrentVersion(j) Then
                    Me.tbx_RequiredVersion.Text = dt.Rows(i)("FileVersion")
                    Me.tbx_Comments.Text = dt.Rows(i)("FileComments").ToString
                    Me.tbx_RequiredVersion.Tag = dt.Rows(i)("MUID")
                    match = True
                    Exit For
                End If
            Next
            If match Then Exit For
        Next
        If match Then
            MessageBox.Show("Update is required")
        Else
            MessageBox.Show("No Update is required")
        End If
        Return 0
    End Function


    Private Function GetVersionUpdateFile()
        Dim qry = "SELECT MUID, FileName, FileDate, FileVersion, FileComments " + _
            " FROM ClientUpdates WHERE MUID = " + Me.tbx_RequiredVersion.Tag.ToString

        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(qry)
        sqlSrvUtils.CloseConnection()

        If dt.Rows.Count <= 0 Then Return ""
        Dim fl As String = dt.Rows(0)("FileName")
        Dim dr As String = runtime.AbsolutePath + "updates"
        IO.Directory.CreateDirectory(dr)
        Dim fname = runtime.AbsolutePath + "updates\" + fl
        Try
            Dim sqlSrv1 As DataUtils = New DataUtils("server")
            Dim query = "SELECT FileContents FROM ClientUpdates WHERE MUID = " + dt.Rows(0)(0).ToString
            sqlSrv1.OpenConnection()
            dt = sqlSrv1.ExecuteQuery(query)
            sqlSrv1.CloseConnection()

            If dt.Rows.Count <= 0 Then
                MessageBox.Show("No update file available ")
                Return ""
            End If

            Dim chunk As Byte() = dt.Rows(0)(0)
            Dim fs As New FileStream(fname, FileMode.Create, FileAccess.Write)
            Dim fw As New BinaryWriter(fs)
            fw.Write(chunk)
            fw.Close()
            fs.Close()
        Catch ex As Exception

        End Try
        Return fname
    End Function


    Private Sub ClientUpdates()
        Dim qry = "SELECT MUID, FileName, FileDate, FileVersion, FileComments FROM ClientUpdates"
        If Not dtClientUpdates Is Nothing Then
            dtClientUpdates.Dispose()
        End If
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        sqlSrvUtils.OpenConnection()
        dtClientUpdates = sqlSrvUtils.ExecuteQuery(qry)
        sqlSrvUtils.CloseConnection()

        dgv_ClientUpdates.DataSource = dtClientUpdates
        dgv_ClientUpdates.BringToFront()
        dgv_ClientUpdates.Columns("MUID").Visible = False
    End Sub


    Private Sub btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Update.Click
        Dim fname As String = GetVersionUpdateFile()
        Dim proc As System.Diagnostics.Process = New System.Diagnostics.Process()
        Try
            proc.EnableRaisingEvents = False
            proc.StartInfo.FileName = fname
            proc.Start()
        Catch ex As Exception

        End Try
        Application.Exit()
    End Sub


    Private Sub VersionUpdates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClientUpdates()
        CheckUpdatesRequried()
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Close()
    End Sub
End Class