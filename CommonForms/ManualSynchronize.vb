Imports system.collections.generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports DataStreams.Csv
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports daqartDLL
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Layout
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Public Class ManualSynchronize
    Dim connSQLCE As SqlCeConnection
    Dim UseStatement As String
    Dim connStr As String = Nothing
    Dim connSQL As SqlClient.SqlConnection = Nothing
    Private Function GetUseString(ByVal ThisDB As String)
        UseStatement = ""
        If ThisDB > "" Then
            If ThisDB = "server" Then
                UseStatement = "Use [" + runtime.SiteName + "_ServerDB] "
            End If
            If ThisDB = "project" Then
                UseStatement = "USE [" + runtime.selectedProject + "] "
            End If
            If ThisDB = "Daqument" Then
                UseStatement = "Use [" + runtime.SiteName + "_Daqument] "
            End If
            If ThisDB = "Daqument001" Then
                UseStatement = "Use [" + runtime.selectedProject + "_Daqument001] "
            End If
        End If
        Return UseStatement
    End Function
    Private Function GetTableName(ByVal query As String) As String
        Dim myQry As String = query.ToUpper()
        Dim ar As String = Split(query, "(")(0)
        Dim tmpStr() As String = Split(ar, " ")
        For i As Integer = 0 To tmpStr.Length - 1
            If tmpStr(i) <> "INSERT" And tmpStr(i) <> "INTO" Then
                Return tmpStr(i)
            End If
        Next
        Return ""
    End Function


    Private Function GetLclQueryTable(ByVal ThisDB As String)
        Dim query As String = "SELECT * FROM lclquery ORDER By TS ASC" + GetUseString(ThisDB)
        Dim lclconnSQLCE As New SqlCeConnection
        Dim lclconnStr = "Data Source=""" + runtime.AbsolutePath() + "\ClientDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
        lclconnSQLCE = New SqlCeConnection(lclconnStr)
        lclconnSQLCE.Open()
        Dim table As New System.Data.DataTable
        Dim myAdapter As SqlCeDataAdapter = New SqlCeDataAdapter(query, lclconnSQLCE)
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        myAdapter.Fill(table)
        For i As Integer = 0 To table.Rows.Count - 1
            table.Rows(i)("Aux5") = ""
            table.Rows(i)("Aux4") = ""
            table.Rows(i)("Aux3") = ""
            table.Rows(i)("Aux2") = ""
            table.Rows(i)("Aux1") = "Yes"
            Dim queryStr As String = table.Rows(i)("querystring")
            Dim paramStr() As String = Split(table.Rows(i)("param"), "&002")
            Dim valStr() As String = Split(table.Rows(i)("lclvalues"), "&002")
            If queryStr.ToUpper().Contains("INSERT INTO") Then
                table.Rows(i)("Aux5") = "INSERT"
                For j As Integer = 0 To paramStr.Length - 1
                    If paramStr(j).ToUpper = "@MUID" Then
                        table.Rows(i)("Aux4") = valStr(j)
                        table.Rows(i)("Aux3") = GetTableName(queryStr)
                        Dim tbl As New System.Data.DataTable
                        Dim myQry As String = GetUseString(table.Rows(i)("db")) + " SELECT * FROM " + table.Rows(i)("Aux3") + _
                            " WHERE MUID ='" + table.Rows(i)("Aux4") + "'"
                        Dim myAdapter1 As SqlDataAdapter = New SqlDataAdapter(myQry, connSQL)
                        tbl.Locale = System.Globalization.CultureInfo.InvariantCulture
                        'myAdapter1.Fill(tbl)
                        'table.Rows(i)("Aux2") = tbl.Rows.Count
                        table.Rows(i)("Aux1") = "No"
                        Exit For
                    End If
                Next
            End If
        Next
        lclconnSQLCE.Close()
        Return table
    End Function

    Private Sub ManualSynchronize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connStr = "Data Source=""" + runtime.SQLIP + "," + runtime.SQLPort + """;uid=daqart_sa;pwd=p@ssW0rd"
        connSQL = New SqlClient.SqlConnection(connStr)
        GridControl1.DataSource = GetLclQueryTable("")
    End Sub
    Private Sub UpdateDataBase(ByVal ThisDb As String)
        Dim sqlCmd As SqlCommand = Nothing

        Dim tbl As DataTable = GetLclQueryTable(ThisDb)
        For i As Integer = 0 To tbl.Rows.Count - 1
            If tbl.Rows(i)("Aux01") = "Yes" Then
                Dim queryStr As String = tbl.Rows(i)("querystring")
                Dim paramStr() As String = Split(tbl.Rows(i)("param"), "&002")
                Dim valStr() As String = Split(tbl.Rows(i)("lclvalues"), "&002")
                Dim query As String = GetUseString(ThisDb) + queryStr
                'query = "USE [master] " + query
                Dim value As Integer = 0
                Dim MUIDVal As String = ""
                Dim cmd As New SqlClient.SqlCommand(query, connSQL)

                For j As Integer = 0 To paramStr.Length - 1
                    cmd.Parameters.AddWithValue(paramStr(j), valStr(j))
                Next
                cmd.CommandType = CommandType.Text

                Try
                    'cmd.ExecuteNonQuery()
                Catch ex As SqlClient.SqlException
                    Utilities.logErrorMessage("Utilities.ManuualSynchronize()--" + ex.Message)
                    If ex.Number <> 2601 And ex.Number <> 2627 Then
                        value = ex.Number
                    Else
                        value = -1
                    End If
                Finally
                    cmd.Dispose()
                End Try
            End If
        Next
    End Sub

    Private Sub btn_ProjectDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ProjectDB.Click
        UpdateDataBase("project")
    End Sub

    Private Sub btn_ServerDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ServerDB.Click
        UpdateDataBase("server")
    End Sub

    Private Sub btn_Daqument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Daqument.Click
        UpdateDataBase("Daqument")
    End Sub

    Private Sub Btn_PrjDaqument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_PrjDaqument.Click
        UpdateDataBase("Daqumrnt001")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class