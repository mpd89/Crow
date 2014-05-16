Imports System.Data.SqlServerCe
Imports System.Data.SqlClient

Public Class CloudUtils
    Dim ThisDB As String
    Dim connSQLCE As SqlCeConnection
    Dim connSQL As SqlClient.SqlConnection
    Dim UseStatement As String
    Dim ThisCabinet As String
    Dim sqlCmd As SqlCommand = Nothing
    Dim sqlCeCmd As SqlCeCommand = Nothing


    Private thisProject As String

    Public Sub New(ByVal _Database As String)
        ThisDB = _Database
        ThisCabinet = ""
        thisProject = runtime.selectedProject
    End Sub


    Public WriteOnly Property ProjectName() As String
        Set(ByVal value As String)
            thisProject = value
        End Set
    End Property


    Public Function OpenConnection() As Boolean
        Try

            If runtime.ConnectionMode = "ONLINE" Then
                Dim connStr As String = Nothing
                ' connStr = "Data Source=""" + runtime.SQLIP + "," + runtime.SQLPort + """;uid=sa;pwd=Al@ska2014"
                connStr = "Data Source=""" + runtime.SQLIP + "," + runtime.SQLPort + """;uid=daqart_sa;pwd=p@ssW0rd"
                Debug.Print("string in datautils is " + connStr)
                connSQL = New SqlClient.SqlConnection(connStr)

                'UseStatement = "Use [" + ThisDB + "] "

                If ThisDB = "server" Then
                    UseStatement = "Use [" + runtime.SiteName + "_ServerDB] "
                End If
                If ThisDB = "project" Then
                    UseStatement = "USE [" + thisProject + "] "
                End If
                If ThisDB = "Daqument" Then
                    UseStatement = "Use [" + runtime.SiteName + "_Daqument" + ThisCabinet + "] "
                End If
                If ThisDB = "Daqument001" Then
                    UseStatement = "Use [" + thisProject + "_Daqument001" + ThisCabinet + "] "
                End If
                If ThisDB = "System" Then
                    UseStatement = ""


                End If

                

                If connSQL.State = ConnectionState.Closed Then
                    connSQL.Open()
                End If

            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                Dim connStr As String = Nothing
                If ThisDB = "server" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.SiteName + "_ServerDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If
                If ThisDB = "project" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + thisProject + ".sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If
                If ThisDB = "Daqument" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.SiteName + "_Daqument.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If
                If ThisDB = "Daqument001" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + thisProject + "_Daqument001.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If

                connSQLCE = New SqlCeConnection(connStr)

                If connSQLCE.State = ConnectionState.Closed Then
                    connSQLCE.Open()
                End If
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("DataUtils.OpenConnection():" + ex.Message)
        End Try

    End Function
End Class
