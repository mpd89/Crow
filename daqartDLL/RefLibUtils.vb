Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Environment
Imports System.Data
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports Microsoft.Win32
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System
Imports System.IO
Imports System.Data.SqlServerCe
Imports System.Data.SqlClient
Imports daqartDLL
Imports System.Management
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text


Public Class RefLibUtils
    Private Shared SQLProject As New DataUtils("project")

    Public Shared Sub ViewReference(ByVal _ID As String)
        Dim RefDir As String = runtime.AbsolutePath2 + "reference\"
        Dim FileName As String
        Dim query As String = "SELECT FileContents,FileName FROM ReferenceLibrary WHERE MUID = '" + _ID + "'"

        Try
            Directory.CreateDirectory(RefDir)

            SQLProject.OpenConnection()
            Dim dt As DataTable = SQLProject.ExecuteQuery(query)

            FileName = dt.Rows(0)(1)
            Dim fname = RefDir + FileName
            Dim fi As FileInfo = New FileInfo(fname)

            If Not fi.Exists Then
                If Not dt.Rows.Count = 0 Then
                    Dim chunk As Byte() = dt.Rows(0)(0)
                    Dim fs As New FileStream(fname, FileMode.Create, FileAccess.Write)
                    Dim fw As New BinaryWriter(fs)
                    fw.Write(chunk)
                    fw.Close()
                    fs.Close()
                Else
                    'MessageBox.Show("No update file available ")
                End If
            End If

            Dim cmdLine As String = """" + fname + """"
            System.Diagnostics.Process.Start(cmdLine)


        Catch ex As Exception
            Utilities.logErrorMessage("ReferenceLibrary.RefLibMain-" + ex.Message)
            'MessageBox.Show("There was an error opening the file.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Sub DeleteReference(ByVal _MUID As String)
        Dim query As String = "DELETE FROM ReferenceLibrary WHERE MUID = @MUID"
        Try
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            dt_param.Rows.Add("@MUID", _MUID)

            sqlPrjUtils.OpenConnection()
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
            sqlPrjUtils.CloseConnection()

        Catch ex As Exception
            Utilities.logErrorMessage("ReferenceLibrary.RefLibMain-" + ex.Message)
        End Try
    End Sub

End Class
