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
Imports System.Drawing


Public Class Utilities
    Dim testCount As Integer = 0
    Public Shared Function GetDirectory()
        Dim thisDir As String = System.IO.Directory.GetCurrentDirectory
        Return thisDir
    End Function

    Public Shared Function GetFileContents(ByVal FullPath As String, _
  Optional ByRef ErrInfo As String = "") As String

        Dim strContents As String
        Dim objReader As StreamReader
        Try

            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Return strContents
        Catch Ex As Exception
            ErrInfo = Ex.Message
            logErrorMessage("Utilities.GetFileContents()--FullPath-" + FullPath + "-" + Ex.Message)
            Return ErrInfo
        End Try
    End Function

    Public Shared Function SubscribeProjectDB(ByVal ProjectName As String)
        Dim repl As New SqlCeReplication()
        Dim DaqartPath As String = "..\..\..\Sites\" + runtime.SiteName
        Dim PathCreated As String = Nothing
        Dim strDataSource As String
        Dim retVal As String = Nothing
        Try

            If runtime.ConnectionMode = "ONLINE" Then
                repl.InternetUrl = "http://" + runtime.IISIP.ToLower + ":" + runtime.IISPort + "/" + runtime.IISvDir + "/sqlcesa35.dll"
                repl.Publisher = runtime.SQLMachine + "\" + runtime.SQLInstance
                repl.PublisherDatabase = ProjectName
                repl.PublisherSecurityMode = SecurityType.DBAuthentication
                repl.PublisherLogin = "daqart_sa"
                repl.PublisherPassword = "p@ssW0rd"
                repl.Publication = ProjectName
                repl.Subscriber = ProjectName

                strDataSource = runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + ProjectName + ".sdf"
                repl.SubscriberConnectionString = "Data Source=" + strDataSource + ";Max Database Size=4090;Default Lock Escalation =100;"


                'Check to see if file exists
                'If the file does not exist, create it, and add it as a subscription.
                'If no Then create(it)
                While System.IO.File.Exists(strDataSource) = False
                    repl.AddSubscription(AddOption.CreateDatabase)
                End While

                'ProjectSync(repl)
                SyncProjectDB(ProjectName)

            End If
        Catch ex As Exception
            logErrorMessage("Utilities.SubscribeProjectDB()--ProjectName-" + ProjectName + "-" + ex.Message)
        End Try

        Return retVal
    End Function

    Public Shared Function SyncProjectDB(ByVal ProjectName As String)
        Dim repl As New SqlCeReplication()
        Dim DaqartPath As String = "..\..\..\Sites\" + runtime.SiteName
        Dim PathCreated As String = Nothing
        Dim strDataSource As String
        Dim retVal As String = Nothing
        Try

            If runtime.ConnectionMode = "ONLINE" Then
                repl.InternetUrl = "http://" + runtime.IISIP.ToLower + ":" + runtime.IISPort + "/" + runtime.IISvDir + "/sqlcesa35.dll"
                If Not runtime.SQLInstance = "MSSQLSERVER" Then
                    repl.Publisher = runtime.SQLMachine + "\" + runtime.SQLInstance
                Else
                    repl.Publisher = runtime.SQLMachine
                End If
                repl.PublisherDatabase = ProjectName
                repl.PublisherSecurityMode = SecurityType.DBAuthentication
                repl.PublisherLogin = "daqart_sa"
                repl.PublisherPassword = "p@ssW0rd"
                repl.Publication = ProjectName
                repl.Subscriber = ProjectName

                strDataSource = runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + ProjectName + ".sdf"
                repl.SubscriberConnectionString = "Data Source=" + strDataSource + ";Max Database Size=4090;Default Lock Escalation =100;"
                ProjectSync(repl)
            End If
        Catch ex As Exception
            logErrorMessage("Utilities.SyncProjectDB()--ProjectName-" + ProjectName + "-" + ex.Message)
        End Try

        Return retVal
    End Function

    Public Shared Function ProjectSync(ByVal repl As SqlCeReplication)
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
            logErrorMessage("Utilities.ProjectSync()--" + retVal)
        End Try

        Return retVal

    End Function

    Public Shared Function SubscribeToDB(ByVal dbName As String)

        Dim RetVal As String = Nothing

        Dim repl As New SqlCeReplication()
        Dim DaqartPath As String = "..\..\..\Sites\" + runtime.SiteName
        Dim PathCreated As String = Nothing
        Dim strDataSource As String

        Try
            repl.InternetUrl = "http://" + runtime.IISIP.ToLower + ":" + runtime.IISPort + "/" + runtime.IISvDir + "/sqlcesa35.dll"
            If Not runtime.SQLInstance = "MSSQLSERVER" Then
                repl.Publisher = runtime.SQLMachine + "\" + runtime.SQLInstance
            Else
                repl.Publisher = runtime.SQLMachine
            End If
            repl.PublisherDatabase = dbName
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
        Catch ex As Exception
            logErrorMessage("Utilities.SubscribeToDB()--" + dbName)
        End Try

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
                    logErrorMessage("Utilities.SubscribeSync()--" + retVal)

                End If
            End Try

            repl.Synchronize()

        Catch err As SqlCeException
            retVal = "Error: " + err.ToString
            logErrorMessage("Utilities.SubscribeSync()--" + retVal)
        End Try

        Return retVal

    End Function

    Public Shared Function addProjectAgent(ByVal ServerInstance As String, ByVal ProjectName As String)
        Dim connRemote As SqlClient.SqlConnection = Nothing
        connRemote = daqartDLL.connections.serverRemoteConnect(connRemote)

        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, connRemote)
        Dim sContents As String
        Dim sErr As String = Nothing

        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\addRoles.sql", sErr)
        sContents = My.Resources.addRoles.ToString
        sContents = sContents.Replace("!!MachineName!!", runtime.SQLMachine)
        sContents = sContents.Replace("!!dbName!!", ProjectName)
        cmd.CommandText = sContents
        cmd.CommandType = CommandType.Text

        connRemote.Open()
        Try
            cmd.ExecuteNonQuery()
            value = "success"
        Catch ex As SqlClient.SqlException
            Dim myLog As New EventLog()
            myLog.Source = "DaqartLog"
            myLog.WriteEntry(String.Format("addProjectAgent Error; Time: {0}, args: {1}", DateTime.Now.ToLongDateString, ex.Message))
            value = "Error: " + ex.Message
        Finally
            cmd.Dispose()
        End Try
        connRemote.Close()

        sContents = My.Resources.addPAL.ToString
        sContents = sContents.Replace("!!MachineName!!", runtime.SQLMachine)
        sContents = sContents.Replace("!!dbName!!", ProjectName)
        cmd.CommandText = sContents
        cmd.CommandType = CommandType.Text

        connRemote.Open()
        Try
            cmd.ExecuteNonQuery()
            value = "success"
        Catch ex As SqlClient.SqlException
            logErrorMessage("Utilities.addProjectAgent()--" + ServerInstance + "-" + ProjectName)
            value = "Error: " + ex.Message
        Finally
            cmd.Dispose()
        End Try
        connRemote.Close()

        Return value
    End Function

    Public Shared Function StartProjectSnapshot(ByVal ServerInstance As String, ByVal ProjectName As String)
        Dim retVal As String = Nothing

        Dim connRemote As SqlClient.SqlConnection = Nothing
        connRemote = daqartDLL.connections.serverRemoteConnect(connRemote)

        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, connRemote)
        Dim sErr As String = Nothing

        connRemote.Open()

        'set up the command object
        Dim myCommand As New SqlClient.SqlCommand
        Dim SnapshotStart As String = "1"
        myCommand = New SqlClient.SqlCommand("USE [" + ProjectName + "]", connRemote)
        myCommand.ExecuteNonQuery()

        myCommand = New SqlClient.SqlCommand("sp_startpublication_snapshot", connRemote)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.AddWithValue("Publication", ProjectName)
        myCommand.Parameters.AddWithValue("ReturnValue", "1")
        myCommand.Parameters("ReturnValue").Direction = ParameterDirection.ReturnValue

        SnapshotStart = myCommand.Parameters("ReturnValue").Value.ToString

        Do Until SnapshotStart = "0"
            Try
                'myCommand.ExecuteNonQuery()
                'connRemote.Open()
                myCommand.ExecuteNonQuery()

            Catch ex As SqlClient.SqlException
                logErrorMessage("Utilities.StartProjectSnapShot()--" + ServerInstance + "-" + ProjectName)
                'MessageBox.Show("Error connecting to the server: " + ex.Message)
            End Try
            SnapshotStart = myCommand.Parameters("ReturnValue").Value.ToString
        Loop

        'wait until snapshot is finished
        myCommand = New SqlClient.SqlCommand("USE [" + ProjectName + "]", connRemote)
        myCommand.ExecuteNonQuery()

        Dim SnapshotStatus As String = "0"
        Dim sp_DataReader As SqlClient.SqlDataReader = Nothing

        myCommand = New SqlClient.SqlCommand("sp_MSchecksnapshotstatus", connRemote)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.AddWithValue("Publication", ProjectName)

        SnapshotStatus = "0"

        Do Until SnapshotStatus = "1"
            Try

                sp_DataReader = myCommand.ExecuteReader()
                While (sp_DataReader.Read)
                    SnapshotStatus = sp_DataReader.GetSqlInt32(0).ToString
                End While

            Catch ex As SqlClient.SqlException
                logErrorMessage("Utilities.StartProjectSnapShot()--" + ServerInstance + "-" + ProjectName)
                'MessageBox.Show("Error connecting to the server: " + ex.Message)
            Finally
                If Not sp_DataReader Is Nothing Then sp_DataReader.Close()
            End Try

        Loop

        connRemote.Close()

        Return retVal
    End Function

    Public Shared Function DropPublication(ByVal ServerInstance As String, ByVal ProjectName As String)
        Dim retVal As String = Nothing

        Dim connRemote As SqlClient.SqlConnection = Nothing
        connRemote = daqartDLL.connections.serverRemoteConnect(connRemote)

        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, connRemote)
        Dim sErr As String = Nothing

        connRemote.Open()
        'see if publicatin exists
        query = "USE [distribution] SELECT * FROM MSpublications WHERE publisher_db = '" + ProjectName + "'"
        Dim dt As New DataTable
        'dt = ExecuteRemoteQuery(query, "project")

        Dim sqlMaster As DataUtils = New DataUtils("master")

        sqlMaster.OpenConnection()
        dt = sqlMaster.ExecuteQuery(query)


        If dt.Rows.Count > 0 Then

            'set up the command object
            Dim myCommand As New SqlClient.SqlCommand
            Dim sp_status As String = "1"
            myCommand = New SqlClient.SqlCommand("USE [" + ProjectName + "]", connRemote)
            myCommand.ExecuteNonQuery()

            myCommand = New SqlClient.SqlCommand("sp_dropmergepublication", connRemote)
            myCommand.CommandType = CommandType.StoredProcedure
            myCommand.Parameters.AddWithValue("Publication", ProjectName)
            myCommand.Parameters.AddWithValue("ReturnValue", "1")
            myCommand.Parameters("ReturnValue").Direction = ParameterDirection.ReturnValue

            sp_status = myCommand.Parameters("ReturnValue").Value.ToString

            Do Until sp_status = "0"
                Try
                    myCommand.ExecuteNonQuery()
                Catch ex As SqlClient.SqlException
                    logErrorMessage("Utilities.DropPublication()--:" + ServerInstance + "-" + ProjectName + "-" + ex.Message)

                    'MessageBox.Show("Error connecting to the server: " + ex.Message)
                End Try
                sp_status = myCommand.Parameters("ReturnValue").Value.ToString
            Loop

            query = "USE [distribution] DELETE FROM MSpublications WHERE publisher_db = @projectname"
            Dim dt_param As DataTable = sqlMaster.paramDT
            dt_param.Rows.Add("@projectname", ProjectName)

            sqlMaster.ExecuteNonQuery(query, dt_param)

        End If




        sqlMaster.CloseConnection()
        connRemote.Close()

        Return retVal
    End Function

    Public Shared Function RemoveDBReplication(ByVal ServerInstance As String, ByVal ProjectName As String)
        Dim retVal As String = Nothing

        Dim connRemote As SqlClient.SqlConnection = Nothing
        connRemote = daqartDLL.connections.serverRemoteConnect(connRemote)

        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, connRemote)
        Dim sErr As String = Nothing

        connRemote.Open()

        'see if publicatin exists
        'query = "USE [master] SELECT name,is_merged_published FROM databases WHERE name = '" + ProjectName + "'"
        'Dim dt As New DataTable
        'dt = ExecuteRemoteQuery(query, "project")

        'If dt.Rows(0)(1) > 0 Then
        query = "USE [master] SELECT name,is_merge_published FROM sys.databases WHERE name = '" + ProjectName + "'"
        Dim dt As New DataTable
        'dt = ExecuteRemoteQuery(query, "project")
        Dim sqlMaster As DataUtils = New DataUtils("master")

        sqlMaster.OpenConnection()
        dt = sqlMaster.ExecuteQuery(query)
        sqlMaster.CloseConnection()



        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(1) Then

                'set up the command object
                Dim myCommand As New SqlClient.SqlCommand
                Dim sp_status As String = "1"
                myCommand = New SqlClient.SqlCommand("USE [" + ProjectName + "]", connRemote)
                myCommand.ExecuteNonQuery()

                myCommand = New SqlClient.SqlCommand("sp_removedbreplication", connRemote)
                myCommand.CommandType = CommandType.StoredProcedure
                myCommand.Parameters.AddWithValue("dbname", ProjectName)
                myCommand.Parameters.AddWithValue("type", "merge")
                myCommand.Parameters.AddWithValue("ReturnValue", "1")
                myCommand.Parameters("ReturnValue").Direction = ParameterDirection.ReturnValue

                sp_status = myCommand.Parameters("ReturnValue").Value.ToString

                Do Until sp_status = "0"
                    Try
                        myCommand.ExecuteNonQuery()
                    Catch ex As SqlClient.SqlException
                        logErrorMessage("Utilities.RemoveDBReplication()--:" + ServerInstance + "-" + ProjectName + "-" + ex.Message)
                        'MessageBox.Show("Error connecting to the server: " + ex.Message)
                    End Try
                    sp_status = myCommand.Parameters("ReturnValue").Value.ToString
                Loop

            End If
        End If

        connRemote.Close()

        Return retVal
    End Function

    Public Shared Sub ReadIniFile()
        '
        'Build setting
        Dim regKey As String
        Dim regValue As String

        Dim getversion As String

        Try

            regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
            regValue = Registry.GetValue(regKey, "InstallPath", Nothing)
            Debug.Print("regValue is :" + regValue)


            If Not regValue = Nothing Then
                runtime.AbsolutePath = regValue + "\"

                Dim osInfo As OperatingSystem
                osInfo = System.Environment.OSVersion
                Debug.Print(osInfo.ToString)
                With osInfo
                    Dim winDrive As String = System.Environment.SystemDirectory.ToString
                    Debug.Print(winDrive)
                    winDrive = winDrive.Remove(3, winDrive.Length - 3)
                    Debug.Print(winDrive)
                    If Directory.Exists(winDrive + "Users\" + System.Environment.UserName + "\AppData\Local\VirtualStore\Program Files\Daqart") Then
                        runtime.AbsolutePath2 = winDrive + "Users\" + System.Environment.UserName + "\AppData\Local\VirtualStore\Program Files\Daqart\"
                    ElseIf Directory.Exists(winDrive + "Users\" + System.Environment.UserName + "\AppData\Local\VirtualStore\Program Files (x86)\Daqart") Then
                        runtime.AbsolutePath2 = winDrive + "Users\" + System.Environment.UserName + "\AppData\Local\VirtualStore\Program Files (x86)\Daqart\"
                    Else
                        runtime.AbsolutePath2 = regValue + "\"
                    End If
                End With
                Debug.Print("before return")
                Return
                Debug.Print("after return")
            End If


            'Design(Setting)
            Dim file As New System.IO.StreamReader("..\..\..\Daqart.ini")
            Dim oneLine As String
            oneLine = file.ReadLine()
            Debug.Print("oneLine is " + oneLine)
            While Not (file.EndOfStream)

                If oneLine <> "" Then

                    'Console.WriteLine(oneLine)
                    Dim thisChar = oneLine.Chars(0)
                    If Not ((oneLine.Chars(0) = "#") Or (oneLine.Chars(0) = "[") Or (oneLine.Chars(0) = " ")) Then
                        Dim parameter As Array
                        parameter = oneLine.Split("=")

                        If parameter(0).ToString.Trim(" ") = "absolutePath" Then
                            runtime.AbsolutePath = parameter(1).ToString.Trim(" ")

                            Dim osInfo As OperatingSystem
                            osInfo = System.Environment.OSVersion

                            With osInfo
                                Dim winDrive As String = System.Environment.SystemDirectory.ToString
                                Debug.Print("windDrive is : " + winDrive)
                                winDrive = winDrive.Remove(3, winDrive.Length - 3)
                                Debug.Print("win drive now is : " + winDrive)
                                If Directory.Exists(winDrive + "Users\" + System.Environment.UserName + "\AppData\Local\VirtualStore\Program Files\Daqart") Then
                                    runtime.AbsolutePath2 = winDrive + "Users\" + System.Environment.UserName + "\AppData\Local\VirtualStore\Program Files\Daqart\"
                                Else
                                    runtime.AbsolutePath2 = parameter(1).ToString.Trim(" ")
                                End If
                            End With

                        End If

                    End If
                End If
                oneLine = file.ReadLine()

            End While

            file.Close()
        Catch ex As Exception
            logErrorMessage("Utilities.ReadIniFile()--query:" + ex.Message)
        End Try

    End Sub

    Public Shared Function Ping(ByVal Host As String) As Boolean
        Dim connRemote As SqlClient.SqlConnection = Nothing
        connRemote = daqartDLL.connections.serverRemoteConnect(connRemote)

        Try
            connRemote.Open()
            If connRemote.State = ConnectionState.Open Then
                connRemote.Close()
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Debug.Print("catch exception in ping" + ex.Message)
            Return False
        End Try

    End Function

    Public Shared Function CountTiers()
        Dim query As String = "SELECT COUNT(*) FROM system_mnemonic"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()
        Return dt.Rows(0)(0)
    End Function

    Public Shared Function CountTags(ByVal _PackageMUID As String)
        Dim query As String = "SELECT COUNT(*) FROM tags WHERE PackageMUID='" & _PackageMUID & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()
        Return dt.Rows(0)(0)
    End Function

    Public Shared Function ExportToWord(ByVal fname As String)

        'Dim wdDoc As Microsoft.Office.Interop.Word.Document = New Microsoft.Office.Interop.Word.Document
        'Dim wdApp As Microsoft.Office.Interop.Word.Application = New Microsoft.Office.Interop.Word.Application
        'wdApp.Visible = True
        'Dim oMissing As Object = System.Reflection.Missing.Value
        'Try

        '    'wdDoc = wdApp.Documents.Add(oMissing, oMissing, oMissing, oMissing)
        '    wdApp.Documents.Open(fname)
        'Catch ex As Exception
        '    logErrorMessage("Utilities.ExportToWord()--file:" + fname)
        '    Return False
        'End Try
        'wdApp.Documents.Open(fname)
        Return True
    End Function

    Public Shared Function GetFormConfig(ByVal _OwnerMUID As String) As System.Data.DataTable
        Dim query As String = "Select LevelOrder From forms_config WHERE OwnerMUID = '" & _OwnerMUID & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()
        Return dt
    End Function

    Public Shared Function GetFormConfigCount(ByVal _OwnerMUID As String) As Integer
        Dim query As String = "Select LevelOrder From forms_config WHERE OwnerMUID = '" & _OwnerMUID & "'"
        Dim tmpArray As Array

        Try
            'dt = ExecuteQuery(query, "project")
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
            'sqlPrjUtils.CloseConnection()
            tmpArray = Split(dt.Rows(0)(0), ",")

            Return tmpArray.Length
        Catch ex As Exception
            Dim message As String = ex.Message
            logErrorMessage("Utilities.GetFormConfigCount()--query:" + query)
            Return 0
            Throw ex
        End Try
    End Function

    Public Shared Function GetFormLevel(ByVal _OwnerMUID As String) As System.Data.DataTable
        'Dim conn As SqlCeConnection = Nothing
        'conn = daqartDLL.connections.projectDBConnect(conn)

        'Dim query As String
        'query = "Select * From forms_config WHERE OwnerID = '" & OwnerID & "'"

        'Try
        '    Dim myAdapter As SqlCeDataAdapter = New SqlCeDataAdapter(query, conn)
        '    Dim ds As DataSet = New DataSet()
        '    myAdapter.Fill(ds, "LevelOrder")
        '    ds.Tables(0).TableName = "LevelOrder"
        '    Return ds.Tables(0)
        'Catch ex As Exception
        '    Dim message As String = ex.Message
        '    logErrorMessage("Utilities.GetFormLevel()--query:" + query)
        '    Throw ex
        'End Try

        Dim query As String = "Select * From forms_config WHERE OwnerMUID = '" & _OwnerMUID & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        'sqlPrjUtils.CloseConnection()
        Return dt
    End Function

    Public Shared Function GetFormDescription(ByVal _MUID As String) As String
        Dim query As String = "Select Description From forms WHERE MUID = '" & _MUID.ToString & "'"

        Try
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
            'sqlPrjUtils.CloseConnection()
            Return dt.Rows(0)(0).ToString
        Catch ex As Exception
            logErrorMessage("Utilities.GetFormDescription()--query:" + query)
            Dim message As String = ex.Message
            'Throw ex
        End Try
        Return "False"
    End Function

    Public Shared Function GetFormID(ByVal _FormName As String) As String
        Dim query As String = "Select MUID From forms WHERE Name = '" & _FormName.ToString & "'"

        Try
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
            'sqlPrjUtils.CloseConnection()
            Return dt.Rows(0)(0)
        Catch ex As Exception
            logErrorMessage("Utilities.GetFormID()--query:" + query)
            Dim message As String = ex.Message
            'Throw ex
        End Try
        Return 0
    End Function

    Public Shared Function GetFormName(ByVal _FormID As String) As String
        Dim query As String = "Select Name From forms WHERE MUID = '" & _FormID.ToString & "'"

        Try
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
            'sqlPrjUtils.CloseConnection()
            Return dt.Rows(0)(0)
        Catch ex As Exception
            logErrorMessage("Utilities.GetFormID()--query:" + query)
            Dim message As String = ex.Message
            'Throw ex
        End Try
        Return 0
    End Function


    'Returns datatable with userInfo record based on username
    Public Shared Function GetUserInfo(ByVal Name As String) As System.Data.DataTable
        Dim query As String = "Select * From userInfo WHERE UserName = '" & Name & "'"

        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        'sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
        'sqlSrvUtils.CloseConnection()
        Return dt
    End Function


    Public Shared Function GetUserInfoByMUID(ByVal _MUID As String) As System.Data.DataTable
        Dim query As String = "Select * From userInfo WHERE MUID = '" & _MUID & "'"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
        Return dt
    End Function


    Public Shared Function GetUserName(ByVal _MUID As String) As String
        If _MUID = "" Then Return ""
        Dim query As String = "Select FirstName, MI, LastName From userInfo WHERE MUID = '" & _MUID.ToString & "'"
        Dim FullName As String

        Try
            'Dim sqlSrvUtils As DataUtils = New DataUtils("server")
            'sqlSrvUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
            'sqlSrvUtils.CloseConnection()

            FullName = dt.Rows(0)(0).ToString + " " + dt.Rows(0)(1).ToString + ". " + dt.Rows(0)(2).ToString
            Return FullName
        Catch ex As Exception
            logErrorMessage("Utilities.GetUserName()--query:" + query)
            Dim message As String = ex.Message
        End Try
    End Function


    Public Shared Function GetUserNameShort(ByVal _MUID As String) As String
        If _MUID = "" Then Return ""
        Dim query As String = "Select LastName + ', ' +  SUBSTRING(FirstName,1,1) From userInfo WHERE MUID = '" & _MUID.ToString & "'"
        Dim FullName As String

        Try
            'Dim sqlSrvUtils As DataUtils = New DataUtils("server")
            'sqlSrvUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
            'sqlSrvUtils.CloseConnection()

            FullName = dt.Rows(0)(0).ToString
            Return FullName
        Catch ex As Exception
            logErrorMessage("Utilities.GetUserName()--query:" + query)
            Dim message As String = ex.Message
        End Try
    End Function


    Public Shared Function IsFormMultiElement(ByVal _MUID As String) As Boolean
        Dim query As String = "SELECT * FROM forms WHERE MUID='" & _MUID.ToString & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        If dt.Rows(0)(8) = 1 Then
            Return True
        Else
            Return False
        End If

    End Function


    Public Shared Function GetFormStatus(ByVal _TagMUID As String, ByVal _FormMUID As String, ByVal _OwnerMUID As String)
        Dim query As String


        If IsFormMultiElement(_FormMUID) Then
            query = "SELECT * FROM forms_me_status WHERE SourceType='Package' AND SourceMUID='" & Utilities.GetPackageID(_TagMUID) & "' AND FormMUID='" & _FormMUID & _
                        "' AND OwnerMUID ='" & _OwnerMUID & "' ORDER BY TS DESC"
        Else
            query = "SELECT * FROM forms_status WHERE TagMUID='" & _TagMUID & "' AND FormMUID='" & _FormMUID & _
                        "' AND OwnerMUID ='" & _OwnerMUID & "' ORDER BY TS DESC"
        End If


        Dim ThisStatus As Integer = 0
        Dim HasStatus As Boolean
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim StatusTable As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        If StatusTable.Rows.Count > 0 Then
            HasStatus = True
        End If

        If HasStatus Then
            If IsDBNull(StatusTable.Rows(0)(9)) Then
                ThisStatus = 0
            Else
                ThisStatus = CInt(StatusTable.Rows(0)(9))
            End If
        End If

        Return ThisStatus
    End Function


    Public Shared Function GetFormStatusColor(ByVal _OwnerMUID As String, ByVal CurrentLevel As Integer) As String
        Dim query As String = "Select LevelColor From forms_config WHERE OwnerMUID = '" & _OwnerMUID & "'"
        Dim tmpArray As Array

        Try
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
            'sqlPrjUtils.CloseConnection()
            tmpArray = Split(dt.Rows(0)(0), "&001")

            Return tmpArray(CurrentLevel - 1)
        Catch ex As Exception
            Dim message As String = ex.Message
            logErrorMessage("Utilities.GetFormStatusColor()--query:" + query)
            Return 0
            Throw ex
        End Try
    End Function


    Public Shared Function GetFormStatusColor(ByVal _OwnerMUID As String, ByVal _Description As String) As String
        Dim query As String = "Select LevelDescription,LevelColor From forms_config WHERE OwnerMUID = '" & _OwnerMUID & "'"
        Dim tmpArray As Array
        Dim ColorArray As Array

        Try
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
            'sqlPrjUtils.CloseConnection()
            tmpArray = Split(dt.Rows(0)(0), "&001")
            ColorArray = Split(dt.Rows(0)(1), "&001")

            Dim ThisRow As Integer = 0
            For i As Integer = 0 To tmpArray.Length - 1
                If tmpArray(i) = _Description Then
                    ThisRow = i
                End If
            Next

            Return ColorArray(ThisRow)

        Catch ex As Exception
            Dim message As String = ex.Message
            logErrorMessage("Utilities.GetFormStatusColor()--query:" + query)
            Return 0
            Throw ex
        End Try
    End Function


    Public Shared Function GetStatusDescription(ByVal _OwnerMUID As String, ByVal CurrentLevel As Integer) As String
        Dim query As String = "Select LevelDescription From forms_config WHERE OwnerMUID = '" & _OwnerMUID & "'"
        Dim tmpArray As Array

        Try
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
            'sqlPrjUtils.CloseConnection()

            If dt.Rows.Count > 0 Then
                tmpArray = Split(dt.Rows(0)(0), "&001")
                Return tmpArray(CurrentLevel - 1)
            Else
                Return "0"
            End If

        Catch ex As Exception
            Dim message As String = ex.Message
            logErrorMessage("Utilities.GetFormStatusColor()--query:" + query)
            Return 0
            Throw ex
        End Try
    End Function


    Public Shared Function FormCheck(ByVal _TypeMUID As String, ByVal _OwnerMUID As String, ByVal _FormMUID As String)
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim query As String = "Select * From requirements WHERE TypeMUID = '" & _TypeMUID & "' AND OwnerMUID = '" & _OwnerMUID & "' AND FormMUID = '" & _FormMUID & "'"

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function GetDiscipline(ByVal DisciplineName As String) As String
        Dim query As String = "Select DisciplineMUID From discipline WHERE Name = '" & DisciplineName & "'"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Return dt.Rows(0)(0)
    End Function


    Public Shared Function GetDisciplineName(ByVal _MUID As String) As String
        Dim query As String = "Select Name From discipline WHERE MUID = '" & _MUID & "'"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Return dt.Rows(0)(0)
    End Function


    Public Shared Function GetDisciplineNameDesc(ByVal _MUID As String) As String
        Dim query As String = "Select Name + ' - ' + Description From discipline WHERE MUID = '" & _MUID & "'"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Return dt.Rows(0)(0)
    End Function


    Public Shared Function GetOwners() As System.Data.DataTable
        Debug.Print("utilities.getowners hit")
        Dim query As String = "Select * From owner Order By Aux05"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Return dt
    End Function


    Public Shared Function GetOwnerInfo(ByVal _MUID As String) As System.Data.DataTable
        Dim query As String = "Select * From owner WHERE MUID = '" & _MUID & "'"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Return dt
    End Function


    Public Shared Function GetOwner(ByVal OwnerName As String) As String
        Dim query As String = "Select MUID From owner WHERE Name = '" & OwnerName & "'"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)(0)
        End If
    End Function

    Public Shared Function GetGroupID(ByVal _Group As String) As String
        Dim query As String = "Select MUID From groups WHERE Name = '" & _Group & "'"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)(0)
        End If
    End Function

    Public Shared Function GetOwner() As System.Data.DataTable
        Dim query As String = "Select * From Owner ORDER BY Aux05 ASC"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Return dt
    End Function


    Public Shared Function GetLevels() As System.Data.DataTable
        Dim query As String = "Select * From levels ORDER BY Name ASC"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Return dt
    End Function

    Public Shared Function GetLevels(ByVal _MUID As String) As System.Data.DataTable
        Dim query As String = "Select * From levels WHERE MUID = '" & _MUID & "'"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Return dt
    End Function

    Public Shared Function addSQLAgent(ByVal ServerInstance As String, ByVal ThisDatabase As String)
        Dim conn As SqlConnection = Nothing
        conn = daqartDLL.connections.serverRemoteConnect(conn)

        'create Daqart_Agent SQL login
        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, conn)
        Dim sContents As String
        Dim sErr As String = Nothing


        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\addRolesSQL.sql", sErr)
        sContents = My.Resources.addRolesSQL.ToString
        sContents = sContents.Replace("!!dbName!!", ThisDatabase)
        cmd.CommandText = sContents
        cmd.CommandType = CommandType.Text

        conn.Open()
        Try
            cmd.ExecuteNonQuery()
            value = "success"
        Catch ex As SqlClient.SqlException
            value = "Error: " + ex.Message
        Finally
            cmd.Dispose()
        End Try
        conn.Close()

        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\addPALSQL.sql", sErr)
        sContents = My.Resources.addPALSQL.ToString
        sContents = sContents.Replace("!!dbName!!", ThisDatabase)
        cmd.CommandText = sContents
        cmd.CommandType = CommandType.Text

        conn.Open()
        Try
            cmd.ExecuteNonQuery()
            value = "success"
        Catch ex As SqlClient.SqlException
            value = "Error: " + ex.Message
            Dim myLog As New EventLog()
            myLog.Source = "DaqartLog"
            myLog.WriteEntry(String.Format("addSQLAgent Error; Time: {0}, args: {1}", DateTime.Now.ToLongDateString, ex.Message))
        Finally
            cmd.Dispose()
        End Try
        conn.Close()

        Return value
    End Function


    Public Shared Function GetTypeCode(ByVal _MUID As String)
        Dim query As String = "Select TypeName FROM equipment_type WHERE MUID='" & _MUID & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)(0)
        End If

    End Function

    Public Shared Function GetTypeID(ByVal _TypeCode As String) As String
        Dim query As String = "Select MUID FROM equipment_type WHERE TypeName='" & _TypeCode & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)(0)
        End If
    End Function


    Public Shared Function GetFeatureID(ByVal FeatureCode As String)
        Dim query As String = "SELECT * FROM SystemFeatures WHERE Code='" & FeatureCode & "'"
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        'sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
        'sqlSrvUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            Return dt.Rows(0)("MUID")
        Else
            Return 0
        End If
    End Function

    'CheckPermission Connects to the ServerDatabase and looks up the Permissions table WHERE
    'The LevelMUID of the user and the requested permission code are in the table
    'If the user has permission return TRUE
    'Else return false
    Public Shared Function CheckPermission(ByVal FeatureCode As String)
        Dim query As String = "SELECT * FROM Permissions WHERE LevelMUID='" & GetUserInfo(runtime.UserName).Rows(0)("LevelMUID") & "' AND FeatureMUID='" & GetFeatureID(FeatureCode) & "'"
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        'sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
        'sqlSrvUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Shared Function GetUserLevel(ByVal UserName As String, ByVal Password As String) As String
        Dim query As String = "SELECT LevelMUID FROM userInfo WHERE UserName='" + _
            UserName + "' AND UserPW ='" + Password + "'"
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        'sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
        'sqlSrvUtils.CloseConnection()

        If dt.Rows.Count = 0 Then
            Return "0"
        Else
            Return dt.Rows(0)(0)
        End If
    End Function


    Public Shared Function GetUserID(ByVal UserName As String, ByVal Password As String) As String
        Dim query As String = "SELECT MUID FROM userInfo WHERE UserName='" + _
            UserName + "' AND UserPW ='" + Password + "'"
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        'sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
        'sqlSrvUtils.CloseConnection()

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)(0)
        End If
    End Function


    Public Shared Function GetUserID(ByVal UserName As String) As String
        Dim query As String = "SELECT MUID FROM userInfo WHERE UserName='" + UserName + "'"
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        'sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
        'sqlSrvUtils.CloseConnection()

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)(0)
        End If

    End Function


    Public Shared Function GetProjectName(ByVal _MUID As String)
        Dim query As String = "Select Name FROM projects WHERE MUID='" & _MUID & "'"
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        'sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
        'sqlSrvUtils.CloseConnection()

        'Return dt.Rows(0)("Name")

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)("Name")
        End If
    End Function


    Public Shared Function GetProjectID(ByVal ProjectName As String)
        Dim query As String = "Select MUID FROM projects WHERE Name='" & ProjectName & "'"
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        'sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
        'sqlSrvUtils.CloseConnection()

        Return dt.Rows(0)(0)
    End Function


    Public Shared Function GetPackageID(ByVal _MUID As String)
        Dim query As String = "Select PackageMUID FROM tags WHERE MUID='" & _MUID.ToString & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()
        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)(0)
        End If
    End Function


    Public Shared Function GetRequirementOwner(ByVal _MUID As String) As String
        Dim query As String = "SELECT OwnerMUID FROM requirements WHERE MUID='" & _MUID.ToString & "'"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)(0)
        End If
    End Function


    Public Shared Function TranslateTagNumber(ByVal TagNumber As String) As String
        Dim query As String = "SELECT MUID FROM tags WHERE TagNumber='" & TagNumber & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)(0)
        End If
    End Function


    Public Shared Function TranslateTagID(ByVal _MUID As String) As String
        Dim query As String = "SELECT TagNumber FROM tags WHERE MUID='" & _MUID.ToString & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        If dt.Rows.Count = 0 Then
            Return ""
        Else
            Return dt.Rows(0)(0)
        End If
    End Function


    Public Shared Function GetFormMaxTagCount(ByVal _FormMUID As String) As Integer
        Dim TagCount As Integer = 0
        'Dim query As String = " SELECT TOP (1) COUNT(tags.TagNumber) AS Expr1, tags.PackageMUID " & _
        '    "FROM tags INNER JOIN " & _
        '    "requirements ON tags.TypeMUID = requirements.TypeMUID INNER JOIN " & _
        '    "forms ON requirements.FormMUID = forms.MUID " & _
        '    "WHERE(forms.MUID = '" + _FormMUID.ToString + "') " & _
        '    "GROUP BY tags.PackageMUID " & _
        '    "ORDER BY Expr1 DESC "

        Try
            '    Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            '    sqlPrjUtils.OpenConnection()
            '    Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            '    sqlPrjUtils.CloseConnection()

            '    If dt.Rows.Count = 0 Then
            '        TagCount = 0
            '    Else
            '        'TagCount = dt.Rows(0)(0)
            TagCount = 20
            'End If
        Catch ex As Exception

        End Try

        Return TagCount
    End Function


    Public Shared Function GetTypeMaxTagCount(ByVal _TypeMUID As String, ByVal _PackageMUID As String) As Integer
        Dim TagCount As Integer = 0
        Dim query As String = "SELECT TypeMUID FROM requirements WHERE FormMUID = '" + _TypeMUID + "'"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        Dim queryString As String = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            If i = 0 Then
                queryString += "TypeMUID='" + dt.Rows(i)(0) + "' "
            Else
                queryString += " OR TypeMUID='" + dt.Rows(i)(0) + "' "
            End If
        Next

        Dim dt_Tag As New DataTable

        query = "SELECT * FROM tags WHERE PackageMUID = '" + _PackageMUID + "' AND (" + queryString + ")"
        dt_Tag = runtime.SQLProject.ExecuteQuery(query)


        Return dt_Tag.Rows.Count
        'Return 1

    End Function


    Public Shared Function GetDocumentTypeID(ByVal DocumentType As String)
        Dim query As String = "Select MUID FROM document_type WHERE Code='" & DocumentType & "'"
        Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(query)

        Return dt.Rows(0)(0)
    End Function


    Public Shared Function GetDocumentType(ByVal _MUID As String)
        Dim query As String = "Select Code + ' - ' + Description As DocType FROM document_type WHERE MUID='" & _MUID.ToString & "'"
        Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(query)

        Return dt.Rows(0)(0)
    End Function


    Public Shared Function GetDocumentTypeFromDocument(ByVal _MUID As String)
        Dim query As String = "Select DocumentTypeMUID FROM documents WHERE MUID='" & _MUID.ToString & "'"

        Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(query)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return 0
        End If
    End Function


    Public Shared Function GetTagRequiredManHours(ByVal _TagMUID As String, ByVal _OwnerMUID As String) As Single
        Dim ManHours As Single = 0
        Dim TagType As String

        Dim query As String = "Select TypeMUID FROM tags WHERE MUID='" & _TagMUID.ToString & "'"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        Try
            TagType = dt.Rows(0)(0)
        Catch ex As SqlException
        End Try

        query = "SELECT * FROM requirements WHERE OwnerMUID = '" + _OwnerMUID.ToString + "' AND TypeMUID = '" + TagType.ToString + "'"
        dt = runtime.SQLProject.ExecuteQuery(query)
        For i As Integer = 0 To dt.Rows.Count - 1
            If IsFormMultiElement(dt.Rows(i)(4)) Then
                ManHours += Convert.ToSingle(dt.Rows(i)(6))
            Else
                ManHours += Convert.ToSingle(dt.Rows(i)(5))
            End If
        Next

        Return ManHours
    End Function


    Public Shared Function GetTagRequiredManHours(ByVal _TagMUID As String) As Single
        Dim ManHours As Single = 0
        Dim TagType As String
        Dim query As String = "Select TypeMUID FROM tags WHERE MUID='" & _TagMUID.ToString & "'"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        Try
            TagType = dt.Rows(0)(0)
        Catch ex As SqlException
        End Try

        query = "SELECT * FROM requirements WHERE TypeMUID = '" + TagType.ToString + "'"
        dt = runtime.SQLProject.ExecuteQuery(query)
        For i As Integer = 0 To dt.Rows.Count - 1
            If IsFormMultiElement(dt.Rows(i)(4)) Then
                ManHours += Convert.ToSingle(dt.Rows(i)(6))
            Else
                ManHours += Convert.ToSingle(dt.Rows(i)(5))
            End If
        Next

        Return ManHours
    End Function


    Public Shared Function GetTagEarnedManHours(ByVal _TagMUID As String, ByVal _OwnerMUID As String) As Single
        Dim ManHours As Single = 0
        Dim TagType As String = Nothing

        Dim query As String = "Select TypeMUID FROM tags WHERE MUID='" & _TagMUID.ToString & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        Try
            TagType = dt.Rows(0)(0)
        Catch ex As SqlException
        End Try

        query = "SELECT * FROM requirements WHERE OwnerMUID = '" + _OwnerMUID.ToString + "' AND TypeMUID = '" + TagType.ToString + "'"
        dt = runtime.SQLProject.ExecuteQuery(query)

        For i As Integer = 0 To dt.Rows.Count - 1

            Dim dt_FormStatus As New DataTable
            If IsFormMultiElement(dt.Rows(i)(4)) Then
                query = "SELECT * FROM forms_me_status WHERE " & _
                " OwnerMUID = '" + _OwnerMUID.ToString + "' " & _
                " AND SourceMUID = '" + _TagMUID.ToString + "' " & _
                " AND FormMUID = '" + dt.Rows(i)(4).ToString + "' " & _
                " AND SourceType = 'Tag' " & _
                " Order By TS DESC"
                dt_FormStatus = runtime.SQLProject.ExecuteQuery(query)
                If Not dt_FormStatus.Rows.Count = 0 Then
                    ManHours += Convert.ToSingle(dt_FormStatus.Rows(0)(11))
                End If
            Else
                query = "SELECT * FROM forms_status WHERE " & _
                " OwnerMUID = '" + _OwnerMUID.ToString + "' " & _
                " AND TagMUID = '" + _TagMUID.ToString + "' " & _
                " AND FormMUID = '" + dt.Rows(i)(4).ToString + "' " & _
                " Order By TS DESC"
                dt_FormStatus = runtime.SQLProject.ExecuteQuery(query)

                If Not dt_FormStatus.Rows.Count = 0 Then
                    ManHours += Convert.ToSingle(dt_FormStatus.Rows(0)(11))
                End If
            End If
        Next
        'sqlPrjUtils.CloseConnection()

        Return ManHours
    End Function


    Public Shared Function GetTagEarnedManHours(ByVal _TagMUID As String) As Single
        Dim ManHours As Single = 0
        Dim TagType As String = Nothing
        Dim query As String = "Select TypeMUID FROM tags WHERE MUID='" & _TagMUID.ToString & "'"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        Try
            TagType = dt.Rows(0)(0)
        Catch ex As SqlException
        End Try

        query = "SELECT * FROM requirements WHERE TypeMUID = '" + TagType.ToString + "'"
        dt = runtime.SQLProject.ExecuteQuery(query)

        For i As Integer = 0 To dt.Rows.Count - 1

            Dim dt_FormStatus As New DataTable
            If IsFormMultiElement(dt.Rows(i)(4)) Then
                query = "SELECT * FROM forms_me_status WHERE " & _
                " SourceMUID = '" + _TagMUID.ToString + "' " & _
                " AND FormMUID = '" + dt.Rows(i)(4).ToString + "' " & _
                " AND SourceType = 'Tag' " & _
                " Order By TS DESC"
                dt_FormStatus = runtime.SQLProject.ExecuteQuery(query)
                If Not dt_FormStatus.Rows.Count = 0 Then
                    ManHours += Convert.ToSingle(dt_FormStatus.Rows(0)(11))
                End If
            Else
                query = "SELECT * FROM forms_status WHERE " & _
                " TagMUID = '" + _TagMUID.ToString + "' " & _
                " AND FormMUID = '" + dt.Rows(i)(4).ToString + "' " & _
                " Order By TS DESC"
                dt_FormStatus = runtime.SQLProject.ExecuteQuery(query)

                If Not dt_FormStatus.Rows.Count = 0 Then
                    ManHours += Convert.ToSingle(dt_FormStatus.Rows(0)(11))
                End If
            End If
        Next

        Return ManHours
    End Function


    Public Shared Function GetPackageRequiredManHours(ByVal _PackageMUID As String, ByVal _OwnerMUID As String) As Single
        Dim ManHours As Single = 0

        Dim query As String = "Select * FROM tags WHERE PackageMUID='" & _PackageMUID.ToString & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt_Tags As DataTable = runtime.SQLProject.ExecuteQuery(query)

        Dim TypeList As String = Nothing
        Dim dt As New System.Data.DataTable

        For TagNum As Integer = 0 To dt_Tags.Rows.Count - 1
            query = "Select * FROM tag_status WHERE TagMUID='" & dt_Tags.Rows(TagNum)(0).ToString & "' AND OwnerMUID = '" + _OwnerMUID.ToString + "'"
            dt = runtime.SQLProject.ExecuteQuery(query)

            ManHours += Convert.ToSingle(dt.Rows(0)(4))
            TypeList += dt_Tags.Rows(TagNum)(4).ToString + ","
        Next

        If Not TypeList = Nothing Then
            TypeList = Left(TypeList, TypeList.Length - 1)

            query = "SELECT DISTINCT FormMUID, ManHours, MEManHours FROM requirements WHERE " & _
            " OwnerMUID = '" + _OwnerMUID.ToString + "'" & _
            " AND TypeMUID IN (" + TypeList + ")"
            dt = runtime.SQLProject.ExecuteQuery(query)

            If Not dt.Rows.Count = 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If IsFormMultiElement(dt.Rows(i)(0)) Then
                        ManHours += Convert.ToSingle(dt.Rows(i)(1))
                    End If
                Next
            End If
        End If
        'sqlPrjUtils.CloseConnection()

        Return ManHours
    End Function


    Public Shared Function GetPackageEarnedManHours(ByVal _PackageMUID As String, ByVal _OwnerMUID As String) As Single
        Dim ManHours As Single = 0

        Dim query As String = "Select * FROM tags WHERE PackageMUID='" & _PackageMUID.ToString & "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt_Tags As DataTable = runtime.SQLProject.ExecuteQuery(query)
        Dim TypeList As String = Nothing
        Dim dt As System.Data.DataTable

        For TagNum As Integer = 0 To dt_Tags.Rows.Count - 1
            query = "Select * FROM tag_status WHERE TagMUID='" & dt_Tags.Rows(TagNum)(0).ToString & "' AND OwnerMUID = '" + _OwnerMUID.ToString + "'"
            dt = runtime.SQLProject.ExecuteQuery(query)
            ManHours += Convert.ToSingle(dt.Rows(0)(6))

            TypeList += dt_Tags.Rows(TagNum)(4).ToString + ","
        Next

        If Not TypeList = Nothing Then
            TypeList = Left(TypeList, TypeList.Length - 1)

            query = "SELECT DISTINCT FormMUID FROM requirements WHERE " & _
            " OwnerMUID = '" + _OwnerMUID.ToString + "'" & _
            " AND TypeMUID IN (" + TypeList + ")"
            dt = runtime.SQLProject.ExecuteQuery(query)

            For i As Integer = 0 To dt.Rows.Count - 1
                If IsFormMultiElement(dt.Rows(i)(0)) Then
                    Dim dt_FormStatus As New DataTable
                    query = "SELECT * FROM forms_me_status WHERE " & _
                    " OwnerMUID = '" + _OwnerMUID.ToString + "' " & _
                    " AND SourceMUID = '" + _PackageMUID.ToString + "' " & _
                    " AND FormMUID = '" + dt.Rows(i)(0).ToString + "' " & _
                    " AND SourceType = 'Package' " & _
                    " Order By TS DESC"
                    dt_FormStatus = runtime.SQLProject.ExecuteQuery(query)

                    If Not dt_FormStatus.Rows.Count = 0 Then
                        ManHours += Convert.ToSingle(dt_FormStatus.Rows(0)(11))
                    End If
                End If
            Next
        End If
        'sqlPrjUtils.CloseConnection()

        Return ManHours
    End Function


    Public Shared Function GetSystemRequiredManHours(ByVal SystemNumber As String, ByVal _OwnerMUID As String) As Single
        Dim ManHours As Single = 0

        Dim query As String = "SELECT SUM(package_status.RequiredManHours) AS EXPR1" & _
            " FROM package INNER JOIN" & _
            " package_status ON package.MUID = package_status.PackageMUID" & _
            " WHERE (package.SystemNumber LIKE '" + SystemNumber + "%')" & _
            " AND (package_status.OwnerMUID = '" + _OwnerMUID.ToString + "')"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt_PRMH As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        If Not IsDBNull(dt_PRMH.Rows(0)(0)) Then
            ManHours = Convert.ToSingle(dt_PRMH.Rows(0)(0))
        End If

        Return ManHours
    End Function

    Public Shared Function GetSystemEarnedManHours(ByVal SystemNumber As String, ByVal _OwnerMUID As String) As Single
        Dim ManHours As Single = 0

        Dim query As String = "SELECT SUM(package_status.EarnedManHours) AS EXPR1" & _
            " FROM package INNER JOIN" & _
            " package_status ON package.MUID = package_status.PackageMUID" & _
            " WHERE (package.SystemNumber LIKE '" + SystemNumber + "%')" & _
            " AND (package_status.OwnerMUID = '" + _OwnerMUID + "')"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt_PRMH As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()
        If Not IsDBNull(dt_PRMH.Rows(0)(0)) Then
            ManHours = Convert.ToSingle(dt_PRMH.Rows(0)(0))
        End If

        Return ManHours
    End Function

    Public Shared Sub logErrorMessage(ByVal msg As String)
        Dim logDir As String = runtime.AbsolutePath + "sites\log\"
        Dim logFileName As String = "daqartErrorLog.txt"
        'Dim w As StreamWriter = File.AppendText(logDir + logFileName)
        Directory.CreateDirectory(logDir)
        Dim w As StreamWriter = File.AppendText(logDir + logFileName)
        Dim myDateTime As String = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString()
        w.WriteLine("{0} {1}", myDateTime, msg)
        w.Flush()
        w.Close()
        'Dim di As New DirectoryInfo(logDir)
        'Dim fiArr As FileInfo() = di.GetFiles()
        Dim fi As FileInfo = New FileInfo(logDir + logFileName)
        If fi.Length > 500000 Then
            Dim fn As DateTime = DateTime.Now
            Dim newName As String = logDir + fn.ToFileTime.ToString + logFileName
            Rename(logDir + logFileName, newName)
        End If
    End Sub

    Public Shared Sub logClientMessage(ByVal msg As String, ByVal msgType As String)
        'If Not EventLog.SourceExists("DaqartClientLog") Then
        '    EventLog.CreateEventSource("DaqartClientLog", "Daqart Client Message Log")
        '    Console.WriteLine("CreatingEventSource")
        'End If

        'Dim evlog As New EventLog("DaqartClientLog")
        'evlog.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 7)
        'evlog.MaximumKilobytes = 1024

        'Dim myLog As New EventLog()
        'myLog.Source = "DaqartClientLog"
        'myLog.WriteEntry(String.Format("{0};:: {1}::, Time {2}", msgType, msg, DateTime.Now.ToString))
    End Sub

    Public Shared Function GetMachineID() As String
        Dim strProcessorId As String = Nothing
        Dim query As New SelectQuery("Win32_processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject

        For Each info In search.Get()
            strProcessorId = info("processorId").ToString()
        Next

        Return Dns.GetHostName + "::" + strProcessorId
    End Function

    Public Shared Function GetCompanies() As DataTable
        Dim query As String = "Select * From company ORDER BY Name ASC"
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        'sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
        'sqlSrvUtils.CloseConnection()

        Return dt
    End Function


    Public Shared Function GetCompanyName(ByVal _MUID As String) As String
        If _MUID = "" Then Return ""
        Dim query As String = "Select Name FROM company WHERE MUID='" & _MUID & "'"

        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Return dt.Rows(0)("Name")
    End Function


    Public Shared Function GetTagSystem(ByVal _MUID As String) As String
        Dim query As String
        query = "SELECT package.SystemMUID FROM  package INNER JOIN  tags ON package.MUID = tags.PackageMUID WHERE (tags.MUID = '" + _MUID.ToString + "')"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)(0)
        End If

    End Function


    Public Shared Function GetTagCount(ByVal _MUID As String) As Integer
        Dim query As String
        query = "SELECT * FROM  tags WHERE tags.PackageMUID = '" + _MUID.ToString + "'"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        Return dt.Rows.Count
    End Function

    Public Shared Function GetTagType(ByVal _MUID As String) As String
        Dim query As String = "SELECT TypeMUID FROM tags WHERE MUID = '" + _MUID.ToString + "'"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        Return dt.Rows(0)(0)
    End Function


    Public Shared Function Encrypt(ByVal plainText As String) As String
        Dim passPhrase As String = "Pas5pr@s"
        Dim saltValue As String = "s@1tValue"
        Dim hashAlgorithm As String = "SHA1"
        Dim passwordIterations As Integer = 2
        Dim initVector As String = "@1B2c3D4e5F6g7H8"
        Dim keySize As Integer = 256

        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

        Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)

        Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

        Dim keyBytes As Byte() = password.GetBytes(keySize / 8)

        Dim symmetricKey As New RijndaelManaged()

        symmetricKey.Mode = CipherMode.CBC

        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

        Dim memoryStream As New IO.MemoryStream()

        Dim cryptoStream As New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
        cryptoStream.FlushFinalBlock()

        Dim cipherTextBytes As Byte() = memoryStream.ToArray()

        memoryStream.Close()
        cryptoStream.Close()

        Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)

        Return cipherText
    End Function

    Public Shared Function Decrypt(ByVal cipherText As String) As String
        Dim passPhrase As String = "Pas5pr@s"
        Dim saltValue As String = "s@1tValue"
        Dim hashAlgorithm As String = "SHA1"
        Dim passwordIterations As Integer = 2
        Dim initVector As String = "@1B2c3D4e5F6g7H8"
        Dim keySize As Integer = 256


        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
        Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)
        Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

        'Dim pw2 As Rfc2898DeriveBytes
        'pw2 = New Rfc2898DeriveBytes(passPhrase, saltValue)

        Dim keyBytes As Byte() = password.GetBytes(keySize / 8)
        'Dim keyBytes As Byte() = pw2.GetBytes(keySize / 8)

        Dim symmetricKey As New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
        Dim memoryStream As New IO.MemoryStream(cipherTextBytes)
        Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
        Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}
        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)

        memoryStream.Close()
        cryptoStream.Close()

        Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)

        Return plainText
    End Function

    Public Shared Function SystemQuery(ByVal SystemID As String) As String

        If SystemID(SystemID.Length - 1) = ";" Then
            SystemID = SystemID.Remove(SystemID.Length - 1, 1)
        End If

        Dim SysArray As String() = Split(SystemID, ";")
        If SysArray.Length < CountTiers() Then
            Return " LIKE '" + SystemID.ToString + "%'"
        Else
            Return " = '" + SystemID.ToString + "'"
        End If
    End Function

    Public Shared Function GetDocumentLatestRev(ByVal _MUID As String) As String
        Dim EngNumber As String
        Dim SheetNumber As String
        Dim query As String = "SELECT EngCode, Sheet FROM documents WHERE MUID = '" + _MUID.ToString + "' AND projectMUID='" + runtime.selectedProjectID + "'"

        Try
            Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(query)

            EngNumber = dt.Rows(0)("EngCode").ToString
            SheetNumber = dt.Rows(0)("Sheet").ToString

            query = "SELECT * FROM documents WHERE EngCode = '" + EngNumber + "'" & _
                    " AND Sheet = '" + SheetNumber + "' AND projectMUID ='" + runtime.selectedProjectID + "' ORDER BY Revision desc"
            dt = runtime.SQLDaqument.ExecuteQuery(query)

            If dt.Rows.Count = 0 Then
                Return "0"
            Else
                Return dt.Rows(0)("Revision").ToString
            End If


        Catch ex As Exception


        End Try
        Return 0
    End Function


    Public Shared Function GetDocumentLatestRevID(ByVal _MUID As String) As String
        Dim EngNumber As String
        Dim SheetNumber As String
        Dim query As String = "SELECT EngCode, Sheet FROM documents WHERE MUID = '" + _MUID.ToString + "'"

        Try
            'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
            'sqlDocUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(query)

            EngNumber = dt.Rows(0)("EngCode")
            SheetNumber = dt.Rows(0)("Sheet")

            query = "SELECT * FROM documents WHERE EngCode = '" + EngNumber + "'" & _
                    " AND Sheet = '" + SheetNumber + "' AND ProjectMUID = '" + runtime.selectedProjectID + "' ORDER BY Revision desc"
            dt = runtime.SQLDaqument.ExecuteQuery(query)
            'sqlDocUtils.CloseConnection()

            Return dt.Rows(0)("MUID").ToString
        Catch ex As Exception

        End Try
        Return 0
    End Function


    Public Shared Function GetDocumentEngCode(ByVal _MUID As String) As String
        Dim EngNumber As String
        Dim query As String = "SELECT EngCode FROM documents WHERE MUID = '" + _MUID.ToString + "'"

        Try
            'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

            'sqlDocUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(query)
            'sqlDocUtils.CloseConnection()

            EngNumber = dt.Rows(0)("EngCode")

            Return EngNumber.ToString
        Catch ex As Exception

        End Try
        Return 0
    End Function


    Public Shared Function GetDocumentInfo(ByVal _MUID As String) As DataTable
        Dim query As String = "SELECT * FROM documents WHERE MUID = '" + _MUID.ToString + "'"
        Dim dt_empty As New DataTable

        Try
            Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(query)
            Return dt
        Catch ex As Exception
            Return dt_empty
        End Try
        Return dt_empty
    End Function


    Public Shared Function TranslateGroupID(ByVal _MUID As String) As String
        Dim query As String = "SELECT Name + ' - ' + Description As expr1 FROM groups WHERE MUID='" & _MUID.ToString & "'"
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        'sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
        'sqlSrvUtils.CloseConnection()

        If dt.Rows.Count = 0 Then
            Return "undefined"
        Else
            Return dt.Rows(0)("expr1")
        End If
    End Function


    Public Shared Function GetTagEngInfo(ByVal _TagMUID As String) As DataTable
        Dim query As String = "Select * From engineering_data WHERE TagMUID='" + _TagMUID.ToString + "' ORDER BY TS desc"

        Try
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

            Return dt
        Catch ex As Exception
            Dim message As String = ex.Message
            Throw ex
        End Try
    End Function


    Public Shared Function GetPackageName(ByVal _MUID As String) As String
        Dim qry As String = "SELECT * from package WHERE MUID = '" + _MUID + "'"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)

        If dt.Rows.Count = 0 Then

            Return 0
        Else
            Return dt.Rows(0)("PackageNumber")
        End If

    End Function


    Public Shared Function GetPackageSystem(ByVal _MUID As String) As String
        Dim qry As String = "SELECT * from package WHERE MUID = '" + _MUID + "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
        'sqlPrjUtils.CloseConnection()
        Return dt.Rows(0)("SystemMUID")
    End Function


    Public Shared Function PopulateMultiElementFormFields(ByVal _FormMUID As String) As Boolean
        Dim query As String = " SELECT * FROM aux_subforms_info WHERE FormMUID='" + _FormMUID.ToString + "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim dt As New DataTable
        Dim NumberofElements As Integer = GetNumberofFormElements(_FormMUID)

        Try
            dt = runtime.SQLProject.ExecuteQuery(query)

            For Each dr As DataRow In dt.Rows
                Dim myVars() As String = Split(dr(3), "&001")
                Dim PagesNeeded As Integer = Math.Ceiling(Utilities.GetFormMaxTagCount(_FormMUID) / NumberofElements)
                For i As Integer = 0 To PagesNeeded - 1
                    Dim ElementName() As String = Split(myVars(0), "@")
                    Dim ElementNumber As Integer = CInt(Replace(ElementName(0), "Element", ""))
                    Dim NewNumber As Integer = ElementNumber + (i * NumberofElements)
                    Dim NewName As String = "Element" + NewNumber.ToString + "@" + ElementName(1)


                    'check to see if element exists in aux_forms_info
                    query = " SELECT * FROM aux_forms_info WHERE AuxData LIKE '" + NewName + "%' and FormMUID='" + _FormMUID.ToString + "'"
                    Dim dt1 As DataTable = runtime.SQLProject.ExecuteQuery(query)

                    Dim fieldStr As String = _
                            NewName + "&001" + _
                            myVars(1) + "&001" + _
                            myVars(2) + "&001" + _
                            myVars(3) + "&001" + _
                            myVars(4) + "&001" + _
                            myVars(5) + "&001" + _
                            myVars(6) + "&001" + _
                            i.ToString + "&001" + _
                            myVars(8) + "&001" + _
                            myVars(9) + "&001" + _
                            myVars(10) + "&001" + _
                            myVars(11) + "&001" + _
                            myVars(12) + "&001" + _
                            myVars(13) + "&001" + _
                            myVars(14) + "&001" + _
                            myVars(15) + "&001" + _
                            myVars(16) + "&001" + _
                            myVars(17) + "&001" + _
                            myVars(18) + "&001" + _
                            myVars(19) + "&001" + _
                            myVars(20) + "&001" + _
                            myVars(21) + "&001"
                    If dt1.Rows.Count = 0 Then
                        Dim qryInsert As String = " INSERT INTO aux_forms_info " + _
                                     " (MUID,TS,FormMUID,AuxData ) VALUES (" + _
                                     " @MUID," + _
                                     " @TS," + _
                                     " @FormMUID," + _
                                     " @AuxData)"
                        Dim dt_param As DataTable = runtime.SQLProject.paramDT
                        dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "aux_forms_info"))
                        dt_param.Rows.Add("@TS", Now())
                        dt_param.Rows.Add("@FormMUID", _FormMUID.ToString)
                        dt_param.Rows.Add("@AuxData", fieldStr)

                        runtime.SQLProject.ExecuteNonQuery(qryInsert, dt_param)
                    End If
                Next
            Next

            Return True

        Catch ex As Exception
            Return False
        End Try
        'sqlPrjUtils.CloseConnection()


    End Function


    Public Shared Function PopulateMultiElementFormFieldsType(ByVal _TypeMUID As String) As Boolean
        Dim query As String = " SELECT DISTINCT forms.MUID " & _
            "FROM tags INNER JOIN " & _
            "requirements ON tags.TypeMUID = requirements.TypeMUID INNER JOIN " & _
            "forms ON requirements.FormMUID = forms.MUID " & _
            "WHERE (tags.TypeMUID = " + _TypeMUID + ") OR " & _
            "(requirements.TypeID = " + _TypeMUID + ") "
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()

        Try
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
            'sqlPrjUtils.CloseConnection()
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    PopulateMultiElementFormFields(dr(0))
                Next
            End If
        Catch ex As Exception

        End Try
    End Function


    Public Shared Function GetNumberofFormElements(ByVal _MUID As String) As Integer
        Dim qry As String = " SELECT NumberofElements FROM forms WHERE MUID = '" + _MUID.ToString + "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim dt As New DataTable

        Try
            dt = runtime.SQLProject.ExecuteQuery(qry)
            'sqlPrjUtils.CloseConnection()
            If IsDBNull(dt.Rows(0)("NumberofElements")) Then
                Return 0
            Else
                Return dt.Rows(0)("NumberofElements")
            End If
        Catch ex As Exception
            Return 0
        End Try

        Return 0
    End Function


    Public Shared Function TestPkgDocContainsRedLineItems(ByVal _DocumentMUID As String, ByVal _PackageMUID As String) As Boolean
        Dim pkgNum As String = GetPackageName(_PackageMUID)
        Dim LayerTitle As String = "RL-" + pkgNum
        Dim qry = "SELECT MUID FROM drawing_layers WHERE(LayerTitle = '" + LayerTitle + "') AND (DrawingMUID = '" + _DocumentMUID.ToString + "')"
        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        'sqlDocUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
        'sqlDocUtils.CloseConnection()

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Shared Function FormatRev(ByVal _rev As String) As String
        Dim HasLetter As Boolean = False
        For i As Integer = 0 To _rev.Length - 1
            If Char.IsLetter(_rev(i)) Then
                HasLetter = True
            End If
        Next

        If HasLetter Then
            For i As Integer = 0 To 3 - _rev.Length
                _rev = "0" + _rev
            Next
        Else
            _rev = _rev + "-"
            For i As Integer = 0 To 3 - _rev.Length
                _rev = "0" + _rev
            Next
        End If

        Return _rev
    End Function


    Public Shared Function TranslateRev(ByVal _rev As String) As String
        For i As Integer = 0 To 1
            If _rev(0) = "0" Then
                'Return 0
                _rev = _rev.Substring(1)
            End If
        Next

        _rev = _rev.Replace("-", "")

        Return _rev
    End Function


    Public Shared Function GetProjectRecordField(ByVal tblName As String, ByVal muid As String, ByVal fieldName As String) As String
        Dim queryString As String = "select * FROM " + tblName + " WHERE MUID = '" + muid + "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(queryString)
        'sqlPrjUtils.CloseConnection()

        If (dt.Rows.Count = 0) Then
            Return ""
        End If
        Return dt.Rows(0)(fieldName)
    End Function

    Public Shared Function GetDate() As String
        Dim returnDate As String
        Dim frmDate As New Calendar
        frmDate.ShowDialog()
        returnDate = frmDate.txt_Date.Text
        Return returnDate
    End Function

    Public Shared Function Cache_PackageList() As DataTable
        Dim qry = " SELECT MUID, PackageNumber As Package, GroupMUID, Description AS GroupID, Aux09 as Priority, Description, Aux08 as Audited FROM Package "
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
        'sqlPrjUtils.CloseConnection()

        dt.Columns("MUID").ColumnMapping = MappingType.Hidden
        dt.Columns("GroupMUID").ColumnMapping = MappingType.Hidden

        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)(3) = Utilities.TranslateGroupID(dt.Rows(i)(2))

            If IsDBNull(dt.Rows(i)("Audited")) Then
                dt.Rows(i)("Audited") = "No"
            End If
        Next

        Return dt
    End Function

    Public Shared Function Cache_Symbols() As DataTable
        Dim qry = " SELECT * FROM SystemImages WHERE Code='SYM' Order By Name ASC"
        'Dim sqlUtils As DataUtils = New DataUtils("server")

        'sqlUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(qry)
        'sqlUtils.CloseConnection()

        Return dt
    End Function


    Public Shared Function LoadSymbols() As Boolean
        Dim qry = " SELECT * FROM SystemImages WHERE Code='SYM' Order By Name ASC"
        'Dim sqlUtils As DataUtils = New DataUtils("server")

        'sqlUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(qry)
        'sqlUtils.CloseConnection()

        If Not Directory.Exists(runtime.AbsolutePath2 + "symbols") Then
            Directory.CreateDirectory(runtime.AbsolutePath2 + "symbols")
        End If

        For Each dr As DataRow In dt.Rows
            'if file exists check for edit flag
            Dim fn As String = runtime.AbsolutePath2 + "symbols\" + dr("Name") + ".png"
            If Not File.Exists(fn) Then
                Dim img As Image
                Dim imagedata() As Byte
                Dim imageBytedata As MemoryStream
                imagedata = dt.Rows(0)("DocumentImage")
                imageBytedata = New MemoryStream(imagedata)
                img = Image.FromStream(imageBytedata)
                img.Save(fn)
            Else
                If Not IsDBNull(dr("Aux05")) Then
                    If dr("Aux05") = True Then
                        Dim img As Image
                        Dim imagedata() As Byte
                        Dim imageBytedata As MemoryStream
                        imagedata = dt.Rows(0)("DocumentImage")
                        imageBytedata = New MemoryStream(imagedata)
                        img = Image.FromStream(imageBytedata)
                        img.Save(fn)
                    End If
                End If
            End If
        Next

        'recheck filenames against dt for deletions
        Dim dir As String = runtime.AbsolutePath2 + "symbols\"
        Dim fentries As String() = Directory.GetFiles(dir)
        Dim fs As String
        For Each fs In fentries
            Dim DoesExists As Boolean = False
            For Each dr As DataRow In dt.Rows
                Dim filename As String = System.IO.Path.GetFileNameWithoutExtension(fs)
                If filename = dr("Name") Then
                    DoesExists = True
                    Exit For
                End If
            Next

            If Not DoesExists Then
                File.Delete(fs)
            End If
        Next



    End Function


    Public Shared Function TranslatePackageNumber(ByVal _PackageNumber As String)
        Dim query As String = "Select MUID FROM package WHERE PackageNumber='" & _PackageNumber.ToString & "'"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows(0)(0)
        End If
    End Function


    Public Shared Function PackageDiscrepancy(ByVal _PackageNumber As String) As Boolean
        Dim query As String = "Select * FROM discrepancy WHERE PackageMUID='" & Utilities.TranslatePackageNumber(_PackageNumber) & "'" & _
                " AND (Status='Pending' OR Status='Open')"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        If dt.Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function


End Class
