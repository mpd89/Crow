Imports System.Data.SqlServerCe
Imports daqartDLL

Public Class loginClass

    Public Sub GetServerDB(ByVal repl As String)



    End Sub

    Public Shared Function SubscribeToDB(ByVal dbName As String)
        Dim RetVal As String = Nothing

        Dim repl As New SqlCeReplication()
        Dim DaqartPath As String = "..\..\..\Sites\" + runtime.SiteName
        Dim PathCreated As String = Nothing
        Dim strDataSource As String

        repl.InternetUrl = "http://" + runtime.IISIP.ToLower + ":" + runtime.IISPort + "/" + runtime.IISvDir + "/sqlcesa35.dll"
        If Not runtime.SQLInstance = "MSSQLSERVER" Then
            repl.Publisher = runtime.SQLMachine + "\" + runtime.SQLInstance
        Else
            repl.Publisher = runtime.SQLMachine 'test
        End If
        repl.PublisherDatabase = dbName
        'repl.PublisherSecurityMode = SecurityType.NTAuthentication
        repl.PublisherSecurityMode = SecurityType.DBAuthentication
        repl.PublisherLogin = "daqart_sa"
        repl.PublisherPassword = "p@ssW0rd"
        repl.Publication = dbName
        repl.Subscriber = dbName

        strDataSource = runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + dbName + ".sdf"
        repl.SubscriberConnectionString = "Data Source=" + strDataSource + ";Max Database Size=4090;Default Lock Escalation =100;"


        'Check to see if file exists
        'If the file does not exist, create it, and add it as a subscription.
        'if no then create it
        While System.IO.File.Exists(strDataSource) = False
            repl.AddSubscription(AddOption.CreateDatabase)
        End While

        SubscriberSync(repl)


        Return RetVal
    End Function

    Public Shared Function SubscriberSync(ByVal repl As SqlCeReplication)
        Dim retVal As String = Nothing
        'synchronize
        Try
            Try
                repl.AddSubscription(AddOption.ExistingDatabase)
            Catch err As SqlCeException

                If err.NativeError = 28521 Then
                    retVal = "Error: " + err.NativeError.ToString
                End If
            End Try

            repl.Synchronize()

        Catch err As SqlCeException
            retVal = "Error: " + err.ToString
        End Try

        Return retVal

    End Function


End Class
