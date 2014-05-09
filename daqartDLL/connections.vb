Imports System.Data.SqlServerCe
Imports daqartDLL


Public Class connections

    Public Shared Function localDBConnect(ByVal conn As SqlCeConnection)
        Dim connStr As String

        If Not conn Is Nothing Then conn.Close()
        Debug.Print("connections localDB absolutePath: " + runtime.AbsolutePath)
        connStr = "Data Source=""" + runtime.AbsolutePath() + "ClientDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"

        Try
            conn = New SqlCeConnection(connStr)
        Catch ex As SqlCeException
            'MessageBox.Show("Error connecting to the server: " + ex.Message)
        End Try

        Return conn

    End Function


    Public Shared Function serverDBConnect(ByVal conn As SqlCeConnection)
        Dim connStr As String

        If Not conn Is Nothing Then conn.Close()

        Dim test As String = runtime.SiteName
        connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.SiteName + "_ServerDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
        'connStr = "Data Source=""..\..\..\Sites\Home\ServerDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"

        Try
            conn = New SqlCeConnection(connStr)
        Catch ex As SqlCeException
            'MessageBox.Show("Error connecting to the server: " + ex.Message)
        End Try

        Return conn

    End Function


    Public Shared Function projectDBConnect(ByVal conn As SqlCeConnection)
        Dim connStr As String

        If Not conn Is Nothing Then conn.Close()
        connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.selectedProject + ".sdf"";Max Database Size=4090;Default Lock Escalation =100;"

        Try
            conn = New SqlCeConnection(connStr)
        Catch ex As SqlCeException
            'MessageBox.Show("Error connecting to the server: " + ex.Message)
        End Try

        Return conn

    End Function


    Public Shared Function DaqumentConnect(ByVal conn As SqlCeConnection)
        Dim connStr As String

        If Not conn Is Nothing Then conn.Close()
        connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.SiteName + "_Daqument.sdf"";Max Database Size=4090;Default Lock Escalation =100;"

        Try
            conn = New SqlCeConnection(connStr)
        Catch ex As SqlCeException
            'MessageBox.Show("Error connecting to the server: " + ex.Message)
        End Try

        Return conn

    End Function


    Public Shared Function DaqumentStorageConnect(ByVal conn As SqlCeConnection, ByVal Vault As String)
        Dim connStr As String

        If Not conn Is Nothing Then conn.Close()
        connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.SiteName + "_Daqument" + Vault + ".sdf"";Max Database Size=4090;Default Lock Escalation =100;"

        Try
            conn = New SqlCeConnection(connStr)
        Catch ex As SqlCeException
            'MessageBox.Show("Error connecting to the server: " + ex.Message)
        End Try

        Return conn

    End Function


    Public Shared Function serverRemoteConnect(ByVal conn As SqlClient.SqlConnection)
        Debug.Print("serverRemoteConnect HIT")
        Dim temp As Boolean
        temp = False
        temp = conn Is Nothing
        Debug.Print(temp.ToString)


        Dim connStr As String

        If Not conn Is Nothing Then conn.Close()
        Dim thisConn As New ConnectionState
        If Not conn Is Nothing Then conn.Close()
        'connStr = "Data Source=""" + runtime.SQLIP + "\" + runtime.SQLInstance + """;Integrated Security=True"
        'connStr = "Data Source=""" + "LT002" + "\" + runtime.SQLInstance + """;Integrated Security=True"
        connStr = "Data Source=""" + runtime.SQLIP + "," + runtime.SQLPort + """;uid=daqart_sa;pwd=p@ssW0rd"
        '  connStr = "Data Source=""" + runtime.SQLIP + "," + runtime.SQLPort + """;uid=sa;pwd=Al@ska2014"

        Try
            conn = New SqlClient.SqlConnection(connStr)
            Debug.Print("The SQL Connection in serverRemoteConnect worked")
        Catch ex As SqlClient.SqlException
            'MessageBox.Show("Error connecting to the server: " + ex.Message)
            Debug.Print("The Sql Connection in serverRemoteConnect failed")
        End Try

        Return conn

    End Function


    Public Shared Function serverDBConnStr()
        Dim connStr As String
        connStr = "Data Source=""..\..\..\Sites\" + runtime.SiteName + "\" + runtime.SiteName + "_ServerDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
        Return connStr
    End Function


    Public Shared Function projectDBConnStr()
        Dim connStr As String
        connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.selectedProject + ".sdf"";Max Database Size=4090;Default Lock Escalation =100;"
        Return connStr
    End Function

End Class
