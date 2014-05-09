Imports System.IO 'used for streamreader
Imports System.Net 'for GetHostName
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports Microsoft.Win32
Imports daqartDLL


Public Class trial
    Public Shared conn As SqlClient.SqlConnection = connections.serverRemoteConnect(conn)
    Public Shared ServerInstance As String = "Daqart"


    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        Dim Status As String

        'Create ServerDB
        Status = CreateServerDB()
        If Not Status = "success" Then
            MessageBox.Show("Daqart setup failed to create ServerDB table." + vbCr + "Error: " + Status)
            Application.Exit()
        End If
        StatusList.SetItemChecked(3, True)
        StatusList.Refresh()

        'Publish ServerDB
        Status = PublishServerDB()
        If Not Status = "success" Then
            MessageBox.Show("Daqart setup failed to publish ServerDB." + vbCr + "Error: " + Status)
            Application.Exit()
        End If
        StatusList.SetItemChecked(4, True)
        StatusList.Refresh()


        'Create Snapshot
        Status = CreateSnapshot(runtime.SiteName + "_ServerDB")
        If Not Status = "success" Then
            MessageBox.Show("Daqart setup failed to create ServerDB snapshot." + vbCr + "Error: " + Status)
            Application.Exit()
        End If
        StatusList.SetItemChecked(5, True)
        StatusList.Refresh()


        'Add Daqart_Agent to the Logins, Add Daqument DB to Daqart_Agent, Add Daqart_Agent to Daqument PAL
        Status = addAgent(runtime.SiteName + "_ServerDB")
        If Not Status = "success" Then
            MessageBox.Show("Daqart setup failed to create and assign roles to the Daqart Server agent." + vbCr + "Error: " + Status)
            Application.Exit()
        End If
        Status = addSQLAgent(runtime.SiteName + "_ServerDB")
        If Not Status = "success" Then
            MessageBox.Show("Daqart setup failed to create and assign roles to the Daqart SQL Server agent." + vbCr + "Error: " + Status)
            Application.Exit()
        End If
        StatusList.SetItemChecked(6, True)
        StatusList.Refresh()


        'Create Daqument database
        Status = CreateDaqumentDB()
        If Not Status = "success" Then
            MessageBox.Show("Daqart setup failed to create Daqument database." + vbCr + "Error: " + Status)
            Application.Exit()
        End If
        StatusList.SetItemChecked(7, True)
        StatusList.Refresh()


        'Publish Daqument
        Status = PublishDaqument()
        If Not Status = "success" Then
            MessageBox.Show("Daqart setup failed to publish Daqument." + vbCr + "Error: " + Status)
            Application.Exit()
        End If
        StatusList.SetItemChecked(8, True)
        StatusList.Refresh()


        'Create Snapshot
        Status = CreateSnapshot(runtime.SiteName + "_Daqument")
        If Not Status = "success" Then
            MessageBox.Show("Daqart setup failed to create Daqument snapshot." + vbCr + "Error: " + Status)
            Application.Exit()
        End If
        StatusList.SetItemChecked(9, True)
        StatusList.Refresh()


        'Add Daqart_Agent to the Logins, Add Daqument DB to Daqart_Agent, Add Daqart_Agent to Daqument PAL
        Status = addAgent(runtime.SiteName + "_Daqument")
        If Not Status = "success" Then
            MessageBox.Show("Daqart setup failed to create and assign roles to the Daqart Server agent." + vbCr + "Error: " + Status)
            Application.Exit()
        End If
        Status = addSQLAgent(runtime.SiteName + "_Daqument")
        If Not Status = "success" Then
            MessageBox.Show("Daqart setup failed to create and assign roles to the Daqart SQL Server agent." + vbCr + "Error: " + Status)
            Application.Exit()
        End If
        StatusList.SetItemChecked(10, True)
        StatusList.Refresh()


        ''Create Daqument001 storage database
        'Status = CreateDaqument001DB()
        'If Not Status = "success" Then
        '    MessageBox.Show("Daqart setup failed to create Daqument database." + vbCr + "Error: " + Status)
        '    Application.Exit()
        'End If
        'StatusList.SetItemChecked(11, True)
        'StatusList.Refresh()


        ''Publish Daqument001 storage database
        'Status = PublishDaqument001()
        'If Not Status = "success" Then
        '    MessageBox.Show("Daqart setup failed to publish Daqument001." + vbCr + "Error: " + Status)
        '    Application.Exit()
        'End If
        'StatusList.SetItemChecked(12, True)
        'StatusList.Refresh()


        ''Create Snapshot
        'Status = CreateSnapshot(runtime.SiteName + "_Daqument001")
        'If Not Status = "success" Then
        '    MessageBox.Show("Daqart setup failed to create Daqument001 snapshot." + vbCr + "Error: " + Status)
        '    Application.Exit()
        'End If
        'StatusList.SetItemChecked(13, True)
        'StatusList.Refresh()


        ''Add Daqart_Agent to the Logins, Add Daqument DB to Daqart_Agent, Add Daqart_Agent to Daqument PAL
        'Status = addAgent(runtime.SiteName + "_Daqument001")
        'If Not Status = "success" Then
        '    MessageBox.Show("Daqart setup failed to create and assign roles to the Daqart Server agent." + vbCr + "Error: " + Status)
        '    Application.Exit()
        'End If
        'Status = addSQLAgent(runtime.SiteName + "_Daqument001")
        'If Not Status = "success" Then
        '    MessageBox.Show("Daqart setup failed to create and assign roles to the Daqart SQL Server agent." + vbCr + "Error: " + Status)
        '    Application.Exit()
        'End If
        'StatusList.SetItemChecked(14, True)
        'StatusList.Refresh()


        MessageBox.Show("SQL Server Configuration Complete.")

        'Add record in TrialDB
        AddSiteToDB(runtime.SiteName)

        Me.Dispose()

    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub


    Public Shared Function TestSite(ByVal Site As String)
        'Try
        '    conn = New SqlClient.SqlConnection(connStr)
        'Catch ex As SqlClient.SqlException
        '    MessageBox.Show("Error connecting to the server: " + ex.Message)
        'End Try

        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, conn)
        Dim sContents As String
        Dim sErr As String = Nothing
        Dim reader As SqlClient.SqlDataReader = Nothing
        Dim logPass As Boolean

        sContents = "SELECT * FROM master.sys.databases WHERE name = '" + Site + "_ServerDB'"
        cmd.CommandText = sContents
        cmd.CommandType = CommandType.Text

        conn.Open()
        Try
            reader = cmd.ExecuteReader()
            logPass = reader.HasRows()

        Catch ex As SqlClient.SqlException
            'MessageBox.Show("Failed to connect to site: " + ex.Message)
            value = "Error: " + ex.Message
        Finally
            If Not reader Is Nothing Then
                reader.Close()
            End If
            cmd.Dispose()
        End Try
        conn.Close()

        Return logPass
    End Function

    Public Shared Sub AddSiteToDB(ByVal Site As String)
        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, conn)
        Dim sContents As String
        Dim sErr As String = Nothing

        sContents = "USE [TrialDB] "
        sContents += "Insert Into Sites (SiteName) VALUES ('" + Site + "')"
        cmd.CommandText = sContents
        cmd.CommandType = CommandType.Text

        conn.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As SqlClient.SqlException
            'MessageBox.Show("Failed to connect to site: " + ex.Message)
            value = "Error: " + ex.Message
        Finally
            cmd.Dispose()
        End Try
        conn.Close()

    End Sub


    Public Shared Function CreateServerDB()

        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, conn)
        Dim sContents As String
        Dim sErr As String = Nothing

        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\createServerDB.sql", sErr)
        sContents = My.Resources.createServerDB.ToString

        sContents = sContents.Replace("!!SiteName!!", runtime.SiteName)
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

        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\ServerDBTables.sql", sErr)
        sContents = My.Resources.ServerDBTables.ToString
        sContents = sContents.Replace("!!SiteName!!", runtime.SiteName)
        sContents = sContents.Replace("!!MID!!", idUtils.GetMID)
        sContents = sContents.Replace("!!NOW!!", Now())
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

        Return value
    End Function

    Public Shared Function addAgent(ByVal ThisDatabase As String)

        'create Daqart_Agent SQL login
        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, conn)
        Dim sContents As String
        Dim sErr As String = Nothing


        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\addRoles.sql", sErr)
        sContents = My.Resources.addRoles.ToString
        sContents = sContents.Replace("!!MachineName!!", runtime.SQLMachine)
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

        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\addPAL.sql", sErr)
        sContents = My.Resources.addPAL.ToString
        sContents = sContents.Replace("!!MachineName!!", runtime.SQLMachine)
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

        Return value
    End Function

    Public Shared Function addSQLAgent(ByVal ThisDatabase As String)


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
        Finally
            cmd.Dispose()
        End Try
        conn.Close()

        Return value
    End Function


    Public Shared Function PublishServerDB()

        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, conn)

        Dim sContents As String
        Dim sErr As String = Nothing
        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\PublishServerDB.sql", sErr)
        sContents = My.Resources.PublishServerDB.ToString
        sContents = sContents.Replace("!!SiteName!!", runtime.SiteName)
        sContents = sContents.Replace("!!PUB!!", runtime.SQLMachine + "\" + ServerInstance)
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

        Return value
    End Function


    Public Shared Function CreateDaqumentDB()

        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, conn)
        Dim sContents As String
        Dim sErr As String = Nothing

        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\createDaqumentDB.sql", sErr)
        sContents = My.Resources.createDaqumentDB.ToString
        sContents = sContents.Replace("!!SiteName!!", runtime.SiteName)
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

        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\createDaqumentTables.sql", sErr)
        sContents = My.Resources.createDaqumentTables.ToString
        sContents = sContents.Replace("!!SiteName!!", runtime.SiteName)
        sContents = sContents.Replace("!!MID!!", idUtils.GetMID)
        sContents = sContents.Replace("!!NOW!!", Now())
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

        Return value
    End Function


    Public Shared Function CreateSnapshot(ByVal ThisDatabase As String)
        Dim retVal As String = Nothing
        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, conn)
        Dim sErr As String = Nothing

        conn.Open()

        'set up the command object
        Dim myCommand As New SqlClient.SqlCommand
        Dim SnapshotStart As String = "1"
        myCommand = New SqlClient.SqlCommand("USE [" + ThisDatabase + "]", conn)
        myCommand.ExecuteNonQuery()

        myCommand = New SqlClient.SqlCommand("sp_startpublication_snapshot", conn)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.AddWithValue("Publication", ThisDatabase)
        myCommand.Parameters.AddWithValue("ReturnValue", "1")
        myCommand.Parameters("ReturnValue").Direction = ParameterDirection.ReturnValue

        SnapshotStart = myCommand.Parameters("ReturnValue").Value.ToString

        Do Until SnapshotStart = "0"
            Try
                myCommand.ExecuteNonQuery()
            Catch ex As SqlClient.SqlException
                'MessageBox.Show("Error connecting to the server: " + ex.Message)
            End Try
            SnapshotStart = myCommand.Parameters("ReturnValue").Value.ToString
        Loop

        'wait until snapshot is finished
        myCommand = New SqlClient.SqlCommand("USE [" + ThisDatabase + "]", conn)
        myCommand.ExecuteNonQuery()

        Dim SnapshotStatus As String = "0"
        Dim sp_DataReader As SqlClient.SqlDataReader = Nothing

        myCommand = New SqlClient.SqlCommand("sp_MSchecksnapshotstatus", conn)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.AddWithValue("Publication", ThisDatabase)

        SnapshotStatus = "0"

        Do Until SnapshotStatus = "1"
            Try

                sp_DataReader = myCommand.ExecuteReader()
                While (sp_DataReader.Read)
                    SnapshotStatus = sp_DataReader.GetSqlInt32(0).ToString
                End While
                retVal = "success"

            Catch ex As SqlClient.SqlException
                'MessageBox.Show("Error connecting to the server: " + ex.Message)
            Finally
                If Not sp_DataReader Is Nothing Then sp_DataReader.Close()
            End Try

        Loop

        conn.Close()

        Return retVal
    End Function

    Public Shared Function PublishDaqument()

        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, conn)

        Dim sContents As String
        Dim sErr As String = Nothing
        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\PublishDaqument.sql", sErr)
        sContents = My.Resources.PublishDaqument.ToString
        sContents = sContents.Replace("!!SiteName!!", runtime.SiteName)
        sContents = sContents.Replace("!!PUB!!", runtime.SQLMachine + "\" + ServerInstance)
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

        Return value
    End Function

    Public Shared Function CreateDaqument001DB()

        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, conn)
        Dim sContents As String
        Dim sErr As String = Nothing

        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\createDaqument001DB.sql", sErr)
        sContents = My.Resources.createDaqument001DB.ToString
        sContents = sContents.Replace("!!SiteName!!", runtime.SiteName)
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

        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\createDaqument001Tables.sql", sErr)
        sContents = My.Resources.createDaqument001Tables.ToString
        sContents = sContents.Replace("!!SiteName!!", runtime.SiteName)
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

        Return value
    End Function

    Public Shared Function PublishDaqument001()

        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim cmd As New SqlClient.SqlCommand(query, conn)

        Dim sContents As String
        Dim sErr As String = Nothing
        'sContents = Utilities.GetFileContents(runtime.AbsolutePath() + "Data Files\PublishDaqument001.sql", sErr)
        sContents = My.Resources.PublishDaqument001.ToString
        sContents = sContents.Replace("!!SiteName!!", runtime.SiteName)
        sContents = sContents.Replace("!!PUB!!", runtime.SQLMachine + "\" + ServerInstance)
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

        Return value
    End Function



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class