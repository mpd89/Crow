Imports System
Imports System.Data
Imports System.Data.SqlServerCe
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports daqartDLL
Imports System.Management
Imports System.Net
Imports System.Threading


Public Class frmLogin
    Dim connClient As SqlCeConnection
    Dim repl As New SqlCeReplication()
    Dim strDataSource As String
    Private DefaultSite As String
    Private TrialSetting As Boolean = False
    Dim LicenseAvailable As Boolean = False
    Dim ProjectSQL As New DataUtils("project")
    Dim ServerSQL As New DataUtils("server")


    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        End
    End Sub


    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If runtime.AppShutdown Then
            Exit Sub
        End If
        ProjectSQL.CloseConnection()
        ServerSQL.CloseConnection()
    End Sub


    Private Sub frmLogin_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Not all buttons that exist are displayed
        'the current buttons to be displayed are initialized here
        Me.Size = New System.Drawing.Size(500, 400)
        advancedButton.Location = New System.Drawing.Point(12, 330)
        exitButton.Location = New System.Drawing.Point(398, 330)
        loginButton.Location = New System.Drawing.Point(317, 330)


        'Utilities.ReadIniFile()  sets the value of runtime.AbsolutePath by looking it up
        'in the registry key first, if it is not there then it reads the path from the 
        'Daqart.ini file and builds the path from the current users info
        'a sample path would look like this
        'C:\Users\mike\AppData\Local\VirtualStore\ProgramFiles\Daqart
        Utilities.ReadIniFile()


        'Check the Daqart settings registry to determine whether the following values exist:
        'DefaultConnectionMode
        'DefaultSite
        'LastUser
        'If any of them exist, populate the form login with those settings, otherwise
        'leave them blank
        Dim regKey As String
        Dim regValue As String
        regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
        regValue = Registry.GetValue(regKey, "DefaultConnectMode", Nothing)
        Debug.Print("form login hkey finale: regvalue is " + regValue)
        If Not regValue = Nothing And Not regValue = "" Then
            If Not regValue = "" Then
                'set the default selection here
                cbx_ConnectMode.Text = regValue
                Debug.Print("cbx: " + cbx_ConnectMode.Text)
            End If
        End If

        regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
        regValue = Registry.GetValue(regKey, "DefaultSite", Nothing)
        If Not regValue = Nothing And Not regValue = "" Then
            If Not regValue = "" Then
                'set the default selection here
                DefaultSite = regValue
            End If
        End If

        regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
        regValue = Registry.GetValue(regKey, "LastUser", Nothing)
        If Not regValue = Nothing And Not regValue = "" Then
            If Not regValue = "" Then
                'set the default selection here
                userid.Text = regValue
            End If
        End If


        connClient = daqartDLL.connections.localDBConnect(connClient)
        eula.Text = My.Resources._060823eula.ToString

        Try
            connClient.Open()
        Catch ex As SqlCeException

            If ex.NativeError = 25138 Then
                Dim UPGD As New SqlCeEngine
                UPGD.LocalConnectionString = connClient.ConnectionString
                UPGD.Upgrade()
                connClient.Open()
            End If

        End Try

        GetSites()

        Me.password.Focus()
        Me.password.Select()

    End Sub


    Private Sub GetSites()
        Dim reader As SqlCeDataReader = Nothing
        Dim cmd As New SqlCeCommand("SELECT * FROM sites", connClient)

        Try
            reader = cmd.ExecuteReader()
            siteList.Items.Clear()
            siteDeleteList.Items.Clear()

            While (reader.Read())
                siteList.Items.Add(reader.GetString(1))
                siteDeleteList.Items.Add(reader.GetString(1))
            End While

            siteList.Text = DefaultSite

        Catch ex As SqlCeException
            MessageBox.Show("Failed to populate site list: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Sub


    Private Sub advancedButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles advancedButton.Click
        If (Me.Size.Height <= 401) Then
            Me.MaximumSize = New System.Drawing.Size(500, 650)
            Me.MinimumSize = New System.Drawing.Size(500, 650)
            Me.Size = New System.Drawing.Size(500, 650)
            advancedButton.Location = New System.Drawing.Point(12, 581)
            advancedButton.Text = "Advanced -"
            exitButton.Location = New System.Drawing.Point(398, 581)
            loginButton.Location = New System.Drawing.Point(317, 581)

            GroupBox1.Visible = True
            GroupBox2.Visible = True

        Else
            Me.MaximumSize = New System.Drawing.Size(500, 400)
            Me.MinimumSize = New System.Drawing.Size(500, 400)
            Me.Size = New System.Drawing.Size(500, 400)
            advancedButton.Location = New System.Drawing.Point(12, 330)
            advancedButton.Text = "Advanced +"
            exitButton.Location = New System.Drawing.Point(398, 330)
            loginButton.Location = New System.Drawing.Point(317, 330)

            GroupBox1.Visible = False
            GroupBox2.Visible = False
        End If
    End Sub


    Private Sub siteAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles siteAdd.Click
        AddSite()
    End Sub


    Private Sub AddSite()
        'first add site to local_db.sites
        Dim reader As SqlCeDataReader
        reader = Nothing

        Dim cmd As New SqlCeCommand("INSERT INTO sites (Name, IISIP, IISPort, IISvDir, SQLIP, SQLPort, SQLInstance, SQLAux1) VALUES ('" + tbx_SiteName.Text + "','" + tbx_IISIP.Text + "','" + tbx_IISPort.Text + "','" + IISvDir.Text + "','" + tbx_SQLIP.Text + "','" + tbx_SqlPort.Text + "','" + tbx_SQLInstance.Text + "', '" + tbx_SQLMachine.Text + "')", connClient)

        Try
            reader = cmd.ExecuteReader()
            Debug.Print("reader executed in addSite()")
        Catch ex As SqlCeException
            MessageBox.Show("Failed to add site to list: " + ex.Message)
            Debug.Print("Reader failed in addsite()")
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

        'then run GetSites() to refresh site list
        GetSites()

        MessageBox.Show("Site was added successfully.")
    End Sub


    Private Sub IISIP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_IISIP.TextChanged
        checkBlanks()
    End Sub
    Private Sub SiteName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_SiteName.TextChanged
        checkBlanks()
    End Sub
    Private Sub IISPort_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_IISPort.TextChanged
        checkBlanks()
    End Sub
    Private Sub SQLIP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_SQLIP.TextChanged
        checkBlanks()
    End Sub
    Private Sub SQLInstance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_SQLInstance.TextChanged
        checkBlanks()
    End Sub
    Private Sub checkBlanks()
        Dim isEmpty As Boolean = True

        If (tbx_SiteName.Text <> "" And tbx_IISIP.Text <> "" And tbx_IISPort.Text <> "" And tbx_SQLIP.Text <> "" And tbx_SQLInstance.Text <> "") Then
            isEmpty = False
        End If

        If (isEmpty = False) Then
            siteAdd.Enabled = True
        Else
            siteAdd.Enabled = False
        End If
    End Sub


    Private Sub siteDeleteList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles siteDeleteList.SelectedIndexChanged
        If (siteDeleteList.Text <> "") Then
            siteDelete.Enabled = True
        Else
            siteDelete.Enabled = False
        End If
    End Sub


    Private Sub siteDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles siteDelete.Click
        'confirm delete
        siteDeleteConfirm.ShowDialog()

        If (siteDeleteConfirm.DialogResult = Windows.Forms.DialogResult.OK) Then

            'delete site from local_db.sites
            Dim reader As SqlCeDataReader
            reader = Nothing

            Dim cmd As New SqlCeCommand("DELETE FROM sites WHERE Name ='" + siteDeleteList.Text + "'", connClient)

            'conn.Open()
            Try
                reader = cmd.ExecuteReader()

            Catch ex As SqlCeException
                MessageBox.Show("Failed to delete site from list: " + ex.Message)
            Finally
                If Not reader Is Nothing Then reader.Close()
            End Try

            siteDelete.Enabled = False

            'then run GetSites() to refresh site list
            GetSites()

            MessageBox.Show("Site was removed successfully.")
        End If
    End Sub


    Private Sub checkLoginBlanks()
        Dim isEmpty As Boolean = True

        If (userid.Text <> "" And password.Text <> "" And siteList.Text <> "") Then
            isEmpty = False
        End If

        If (isEmpty = False) Then
            loginButton.Enabled = True
            'loginButton.Select()
        Else
            loginButton.Enabled = False
        End If
    End Sub


    Private Sub userid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles userid.TextChanged
        checkLoginBlanks()
    End Sub


    Private Sub password_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles password.KeyUp
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            If Me.loginButton.Enabled = True Then
                Me.LoginButtonClicked()
            End If
        End If
    End Sub


    Private Sub password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles password.TextChanged
        checkLoginBlanks()

    End Sub


    Private Sub siteList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles siteList.SelectedIndexChanged
        checkLoginBlanks()
    End Sub


    Private Sub getSelectedSite()
        Dim query As String = "SELECT * FROM sites WHERE Name='" + siteList.Text + "'"
        Dim reader As SqlCeDataReader = Nothing
        Dim cmd As New SqlCeCommand(query, connClient)

        Try
            reader = cmd.ExecuteReader()
            While (reader.Read())
                runtime.SiteName = reader.GetSqlString(1)
                runtime.IISIP = reader.GetSqlString(2)
                runtime.IISPort = reader.GetSqlString(3)
                runtime.IISvDir = reader.GetSqlString(4)
                runtime.SQLIP = reader.GetSqlString(7)
                runtime.SQLPort = reader.GetSqlString(8)
                runtime.SQLInstance = reader.GetSqlString(9)
                runtime.SQLMachine = reader.GetSqlString(10)
            End While

        Catch ex As SqlCeException
            MessageBox.Show("Failed to connect to site: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

    End Sub


    Private Sub loginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginButton.Click
        LoginButtonClicked()
    End Sub


    Private Sub LoginButtonClicked()
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        getSelectedSite()

        runtime.MID = idUtils.GetMID
        Debug.Print(Utilities.Ping(runtime.IISIP).ToString)
        If Utilities.Ping(runtime.IISIP) And cbx_ConnectMode.Text = "Online" Then
            runtime.ConnectionMode = "ONLINE"

            If TrialSetting Then
                If Not trial.TestSite(siteList.Text) Then
                    If MessageBox.Show("The selected site has not been created. Would you like create it now?", _
                       "Create Virtual Site", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, _
                       MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim frm_Trial As New trial
                        frm_Trial.ShowDialog()

                        Me.Refresh()
                    Else
                        Application.Exit()
                    End If
                End If
            End If

            'test for sql server
            Debug.Print("runtime.Sitename is " + runtime.SiteName)
            Dim query As String = "USE [master]  Select * from sys.databases WHERE name = '" + runtime.SiteName + "_ServerDB';"
            Debug.Print(query)
            'query = "USE [master]  Select * from sys.databases"

            Dim dt As New DataTable

            Try
                Dim sqlMaster As DataUtils = New DataUtils("master")
                sqlMaster.OpenConnection()
                dt = sqlMaster.ExecuteQuery(query)
                sqlMaster.CloseConnection()

                If dt Is Nothing Then
                    MessageBox.Show("The site connection parameters are incorrect.  Please verify then try again.", "Connect Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Me.Enabled = True
                    Return
                End If

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("The Site Name does not exist.  Please verify then try again.", "Connect Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Me.Enabled = True
                    Return
                End If

            Catch ex As Exception
                MessageBox.Show("The site connection parameters are incorrect.  Please verify then try again.", "Connect Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Enabled = True
                Me.Cursor = Cursors.Default
                Return

            End Try


        ElseIf Not Utilities.Ping(runtime.IISIP) And cbx_ConnectMode.Text = "Online" Then
            Debug.Print(Utilities.Ping(runtime.IISIP).ToString)
            If MessageBox.Show("Connection to server cannot be established, do you want to continue in OFFLINE mode?",
               "Merge", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.Refresh()
            Else
                runtime.AppShutdown = True
                Application.Exit()
                Exit Sub
            End If

            runtime.ConnectionMode = "OFFLINE"
        End If

        If cbx_ConnectMode.Text = "Offline" Then
            runtime.ConnectionMode = "OFFLINE"
        End If

        ProjectSQL.OpenConnection()
        ServerSQL.OpenConnection()

        Login()
    End Sub


    Private Sub Login()
        Debug.Print("Login Has Been Reached")
        Debug.Print("SQLMACHINE VALUE IS " + runtime.SQLMachine)
        Dim DaqartPath As String = runtime.AbsolutePath() + "Sites\" + runtime.SiteName
        Dim PathCreated As String = Nothing
        Dim query As String
        Dim dt As New DataTable
        Dim MaxClients As Integer = 5
        Dim addrs() As IPAddress = Dns.GetHostAddresses(Dns.GetHostName)

        If runtime.ConnectionMode = "ONLINE" Then
            'check remaining timeleft
            query = " SELECT * FROM ServerInfo WHERE Parameter = 'P2'"

            dt = ServerSQL.ExecuteQuery(query)

            Dim _Date As New Date(Now.Year, Now.Month, Now.Day)
            Dim ExpireDate As Date
            Debug.Print("query result is" + dt.Rows(0)(2))
            Dim TestDate As Date
            TestDate = #4/28/2015#

            Debug.Print("My new Test Date is : " + Utilities.Encrypt(TestDate))
            Debug.Print("My new Test date decrypted is" + Utilities.Decrypt(Utilities.Encrypt(TestDate)))
            ExpireDate = Utilities.Decrypt(dt.Rows(0)(2))
            Debug.Print(ExpireDate)
            Dim NewDate As Date
            NewDate = #4/28/2015#
            Debug.Print(NewDate)
            Dim EncryptedDate As String
            EncryptedDate = Utilities.Encrypt(NewDate)
            Debug.Print(EncryptedDate)
            Debug.Print("runtime IISIP is: " + runtime.IISIP)
            Debug.Print("runtime SQLIP is: " + runtime.SQLIP)
            Debug.Print("runtime SQLPort is: " + runtime.SQLPort)
            Debug.Print("runtime SiteName is: " + runtime.SiteName)
            Debug.Print("runtime iisvDir is: " + runtime.IISvDir)
            Debug.Print("runtime iisPort is:" + runtime.IISPort)
            Dim DaysRemaining As Integer = ExpireDate.Subtract(_Date).TotalDays
            If DaysRemaining < 30 Then
                If DaysRemaining < 1 Then
                    Dim frm_License As New License
                    frm_License.ShowDialog()

                    Return
                Else
                    MessageBox.Show("The server license will expire in " + DaysRemaining.ToString + " days.", "License Expiration", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            Thread.Sleep(500)

            'Check to see if proper MID is logged
            Dim regKey As String
            Dim regValue As String
            regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
            regValue = Registry.GetValue(regKey, siteList.Text + "_MID", Nothing)
            If regValue = Nothing Then
                CreateMID()
            Else
                runtime.MID = regValue
            End If

            'check to see if is registered in client access table
            query = " SELECT * FROM ClientAccess WHERE MUID = '" + runtime.MID + "'"
            dt = ServerSQL.ExecuteQuery(query)

            If dt.Rows.Count = 0 Then
                'check to see if client access table has empty slot
                query = " SELECT * FROM ClientAccess WHERE Active = '1'"
                Dim dt_ClientList As DataTable = ServerSQL.ExecuteQuery(query)

                'here we need a server info table with the max cal limits
                query = " SELECT * FROM ServerInfo WHERE Parameter = 'P1'"
                dt = ServerSQL.ExecuteQuery(query)
                ' Debug.Print("row before decrypt: " + dt.Rows(0)(2))
                ' Debug.Print("row value encrypre: vN4UfYPmYyvkPxg7lWZPsw==")
                'Debug.Print("max clients decrypted " + Convert.ToString(Utilities.Decrypt(dt.Rows(0)(2))))
                ' Debug.Print("max clients decrypted " + Convert.ToString(Utilities.Decrypt("uMZ46KsUC584JGEDSYJTZw==")))
                MaxClients = Convert.ToInt32(Utilities.Decrypt(dt.Rows(0)(2)))
                ' Debug.Print(Utilities.Encrypt("35"))
                ' MaxClients = Convert.ToInt32(Utilities.Decrypt("uMZ46KsUC584JGEDSYJTZw=="))
                ' Dim x As Integer = 45

                ' Debug.Print("value of 45 encrypted as int: " + Utilities.Encrypt(x.ToString))
                ' Debug.Print("value of 45 encrypted as string" + Utilities.Encrypt("45"))
                ' Debug.Print("value of 45 decrypted: " + Utilities.Decrypt("vN4UfYPmYyvkPxg7lWZPsw=="))
                'Dim tempInt As Integer = Nothing
                'tempInt = Convert.ToInt32(Utilities.Decrypt("vN4UfYPmYyvkPxg7lWZPsw=="))
                ''Debug.Print("tempInt is " + tempInt.ToString)
                If dt_ClientList.Rows.Count < MaxClients Then
                    LicenseAvailable = True
                Else
                    MessageBox.Show("There are no available client access slots.  Please contact the administrator of the Daqart server for further action.")
                    Me.Enabled = True
                    Return
                End If
            Else
                'check to see if active
                If dt.Rows(0)("Active") = "0" Then
                    MessageBox.Show("The client license for this computer is inactive.  Please contact the administrator of the Daqart server for further action.")
                    Me.Enabled = True
                    Return
                End If

                'update client access table
                query = " UPDATE ClientAccess SET " & _
                " LastAccess = @LastAccess," & _
                " AccessIP = @AccessIP" & _
                " WHERE MUID=@MUID"

                Dim dt_param2 As DataTable = ServerSQL.paramDT
                dt_param2.Rows.Add("@LastAccess", Now())
                dt_param2.Rows.Add("@AccessIP", addrs(0).ToString)
                dt_param2.Rows.Add("@MUID", runtime.MID)

                ServerSQL.ExecuteNonQuery(query, dt_param2)
            End If

            Try
                If Not System.IO.Directory.Exists(DaqartPath) Then
                    System.IO.Directory.CreateDirectory(DaqartPath)
                    PathCreated = "success"
                End If
            Catch Ex As Exception
                MessageBox.Show("Daqart Error:" & Ex.ToString)
            End Try

            repl.InternetUrl = "http://" + runtime.IISIP.ToLower + ":" + runtime.IISPort + "/" + runtime.IISvDir + "/sqlcesa35.dll/sqlcesa30.dll"
            'MessageBox.Show("1 - " + repl.InternetUrl)
            Debug.Print("repl.interneturl is " + repl.InternetUrl)
            If Not runtime.SQLInstance = "MSSQLSERVER" Then
                repl.Publisher = runtime.SQLMachine + "\" + runtime.SQLInstance
            Else
                repl.Publisher = runtime.SQLMachine.ToUpper
            End If
            'MessageBox.Show("2 - " + repl.Publisher)

            repl.PublisherDatabase = runtime.SiteName + "_ServerDB"
            'MessageBox.Show("3 - " + repl.PublisherDatabase)

            repl.PublisherSecurityMode = SecurityType.DBAuthentication
            repl.PublisherLogin = "daqart_sa"
            repl.PublisherPassword = "p@ssW0rd"
            '  repl.PublisherLogin = "sa"
            ' repl.PublisherPassword = "Al@ska2014"
            repl.Publication = runtime.SiteName + "_ServerDB"
            'MessageBox.Show("4 - " + repl.Publication)

            repl.Subscriber = runtime.SiteName + "_ServerDB"
            'MessageBox.Show("5 - " + repl.Subscriber)

            strDataSource = runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.SiteName + "_ServerDB.sdf"
            repl.SubscriberConnectionString = "Data Source=" + strDataSource + ";Max Database Size=4090;Default Lock Escalation =100;"
            'MessageBox.Show("6 - " + repl.SubscriberConnectionString)

            'Check to see if file exists
            'If the file does not exist, create it, and add it as a subscription.
            'if no then create it
            If Not System.IO.File.Exists(strDataSource) Then
                If MessageBox.Show("The selected site profile does not exist.  This may take a few minutes, do you want to continue?", _
                   "Create Site Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, _
                   MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    repl.AddSubscription(AddOption.CreateDatabase)

                    'generate MID - MachineID
                    Dim newMID As String = idUtils.GenerateMID

                    'check uniqueness of MID
                    While CheckMID(newMID)
                        newMID = idUtils.GenerateMID
                    End While

                    'write to registry
                    Dim MyKey As RegistryKey
                    MyKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\ISSI\Daqart\Settings", True)
                    MyKey.CreateSubKey(siteList.Text + "_MID")
                    MyKey.Close()

                    regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
                    Registry.SetValue(regKey, siteList.Text + "_MID", newMID, RegistryValueKind.String)

                    runtime.MID = newMID
                    Me.Refresh()

                    'Test settings
                    'Me.Enabled = True
                    'Me.Cursor = Cursors.Default
                    'Exit Sub

                Else
                    Application.Exit()
                End If
            End If

            'synchronize
            Try
                Try
                    repl.AddSubscription(AddOption.ExistingDatabase)
                Catch err As SqlCeException
                    Debug.Print("addsubscription faileed")
                    If err.NativeError = 28521 Then
                        'MessageBox.Show("Error: " + err.NativeError.ToString)
                    End If
                End Try
                Debug.Print("About to sync")
                repl.Synchronize()

                'A subscriber row failed to apply at the publisher. Review the error parameters and the conflict logging tables at the publisher to determine the reason the row failed to apply. [ Table name = userlog, Row guid = {772B0771-A771-4366-943D-C94F09D2F9AC} ]
            Catch err As SqlCeException
                Dim ThisError As String = err.NativeError
                Debug.Print("whole sync failed")
                MessageBox.Show("Error1001: " + err.ToString)

                Dim instance As SqlCeException
                Dim value As Integer

                value = instance.HResult
                MessageBox.Show("HResult: " + value.ToString)

            End Try

            Try
                loginClass.SubscribeToDB(runtime.SiteName + "_Daqument")
            Catch ex As SqlCeException
                MessageBox.Show("Error: " + Err.ToString)
            End Try
        ElseIf runtime.ConnectionMode = "OFFLINE" Then
            'check to see if the project exists
            Try
                If Not System.IO.Directory.Exists(DaqartPath) Then
                    MessageBox.Show("The selected site profile must first be connected to the server in Online mode.")
                    Me.Enabled = True
                End If
            Catch Ex As Exception
                MessageBox.Show("Daqart Error:" & Ex.ToString)
            End Try

            'Check to see if proper MID is logged
            Dim regKey As String
            Dim regValue As String
            regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
            regValue = Registry.GetValue(regKey, siteList.Text + "_MID", Nothing)
            If regValue = Nothing Then
                MessageBox.Show("Updates require the client first be connected to the server in Online mode.")
                Me.Enabled = True
            Else
                runtime.MID = regValue
            End If
        End If

        'check to see if is registered in client access table
        query = " SELECT * FROM ClientAccess WHERE MUID = '" + runtime.MID + "'"
        dt = ServerSQL.ExecuteQuery(query)

        'update client access table
        query = " UPDATE ClientAccess SET " & _
        " LastAccess = @LastAccess," & _
        " AccessIP = @AccessIP" & _
        " WHERE MUID = @MUID"

        Dim dt_param As DataTable = ServerSQL.paramDT
        dt_param.Rows.Add("@LastAccess", Now())
        dt_param.Rows.Add("@AccessIP", addrs(0).ToString)
        dt_param.Rows.Add("@MUID", runtime.MID)

        ServerSQL.ExecuteNonQuery(query, dt_param)


        Dim connServer As SqlCeConnection = Nothing
        connServer = daqartDLL.connections.serverDBConnect(connServer)
        connServer.Open()

        runtime.SQLServer = New DataUtilsGlobal("server")
        runtime.SQLDaqument = New DataUtilsGlobal("Daqument")
        runtime.SQLMaster = New DataUtilsGlobal("System")

        runtime.SQLServer.OpenConnection()
        runtime.SQLDaqument.OpenConnection()
        runtime.SQLMaster.OpenConnection()


        query = "SELECT * FROM userInfo WHERE UserName='" + userid.Text + "' AND UserPW = '@@" + password.Text + "' AND active='True'"
        dt = ServerSQL.ExecuteQuery(query)

        If Not dt.Rows.Count = 0 Then
            'prompt change password
            Dim frm_ResetPassword As New PasswordChange(Utilities.GetUserID(Me.userid.Text))
            frm_ResetPassword.ShowDialog()

            Me.password.Text = frm_ResetPassword.NewPassword
            frm_ResetPassword.Dispose()
        End If


        query = "SELECT * FROM userInfo WHERE UserName='" + userid.Text + "' AND UserPW = '" + password.Text + "' And Active='True'"
        dt = ServerSQL.ExecuteQuery(query)
        Dim cmd As New SqlCeCommand(query, connServer)
        Dim reader As SqlCeDataReader = Nothing
        Dim logPass As Boolean

        Try
            reader = cmd.ExecuteReader()
            reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable)
            logPass = reader.HasRows()
        Catch ex As SqlCeException
            MessageBox.Show("Failed to connect to site: " + ex.Message)
        Finally
            If Not reader Is Nothing Then
                reader.Close()
            End If
        End Try

        If dt.Rows.Count > 0 Then
            loginOK()
        Else
            loginFailed()
        End If
    End Sub


    Private Sub loginOK()
        Dim connServer As SqlCeConnection = Nothing
        connServer = daqartDLL.connections.serverDBConnect(connServer)
        connServer.Open()

        Dim query As String = "SELECT MUID FROM userInfo WHERE UserName='" + userid.Text + "'"
        Dim reader As SqlCeDataReader = Nothing
        Dim cmd As New SqlCeCommand(query, connServer)
        Dim thisID As String = Nothing
        Dim addrs() As IPAddress = Dns.GetHostAddresses(Dns.GetHostName)

        Try
            reader = cmd.ExecuteReader()
            While (reader.Read())
                thisID = reader.GetSqlString(0)
            End While

        Catch ex As SqlCeException
            MessageBox.Show("Failed to connect to site: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

        'insert login record
        query = "INSERT INTO userlog (MUID,UserMUID,TS,Action,Time,Project) VALUES (" & _
                " @MUID," & _
                " @UserMUID," & _
                " @TS," & _
                " @DIR," & _
                " @TS2,'')"

        Dim dt_param As DataTable = ServerSQL.paramDT
        'dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("server", "userlog"))
        dt_param.Rows.Add("@UserMUID", thisID)
        dt_param.Rows.Add("@TS", Now())
        dt_param.Rows.Add("@DIR", "In")
        dt_param.Rows.Add("@TS2", Now())

        Try
            If runtime.ConnectionMode = "ONLINE" Then
                runtime.ConnectionMode = "OFFLINE"
                ServerSQL.OpenConnection()
                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("server", "userlog"))
                ServerSQL.ExecuteNonQuery(query, dt_param)
                ServerSQL.CloseConnection()
                runtime.ConnectionMode = "ONLINE"
            Else
                ServerSQL.OpenConnection()
                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("server", "userlog"))
                ServerSQL.ExecuteNonQuery(query, dt_param)
                ServerSQL.CloseConnection()
            End If

            'ServerSQL.ExecuteNonQuery(query, dt_param)
        Catch ex As SqlCeException
            MessageBox.Show("Failed to add session to Log records: " + ex.Message)
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try

        If LicenseAvailable Then
            'insert into client access table
            query = " INSERT INTO ClientAccess " & _
            "(MUID,TS,ClientMUID,LastAccess,AccessIP,Description,Active,Aux05) Values ( " & _
            " @MUID," & _
            " @TS," & _
            " @ClientMUID," & _
            " @LastAccess," & _
            " @AccessIP," & _
            " @Description," & _
            " @Active," & _
            " @MID)"

            dt_param = ServerSQL.paramDT
            dt_param.Rows.Add("@MUID", runtime.MID)
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@ClientMUID", thisID)
            dt_param.Rows.Add("@LastAccess", Now())
            dt_param.Rows.Add("@AccessIP", addrs(0).ToString)
            dt_param.Rows.Add("@Description", GetID())
            dt_param.Rows.Add("@Active", "1")
            dt_param.Rows.Add("@MID", runtime.MID)

            ServerSQL.ExecuteNonQuery(query, dt_param)
        End If

        daqartDLL.runtime.UserMUID = thisID
        daqartDLL.runtime.UserName = userid.Text

        'update registry values
        Dim regKey As String
        regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
        Registry.SetValue(regKey, "DefaultConnectMode", cbx_ConnectMode.Text, RegistryValueKind.String)
        Registry.SetValue(regKey, "DefaultSite", siteList.Text, RegistryValueKind.String)
        Registry.SetValue(regKey, "LastUser", userid.Text, RegistryValueKind.String)

        Me.Cursor = Cursors.Default
        Me.Dispose()
    End Sub


    Private Sub loginFailed()
        Me.Enabled = True
        Me.Cursor = Cursors.Default
        password.Text = ""
        MessageBox.Show("Login Failed, please check userID and Password and try again.")
    End Sub


    Private Sub ImportSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportSite.Click
        With ofd1
            .Filter = "Daqart Site Profile|*.dqt"
            .FileName = Nothing
        End With
        ofd1.ShowDialog()


        If ofd1.FileName = Nothing Then
            Return
        End If

        Dim SiteProfile As String = Nothing
        Try
            SiteProfile = Utilities.GetFileContents(ofd1.FileName)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim SiteParameters() As String = Split(SiteProfile, ";")
        Dim HostName() As String = Split(SiteParameters(0), ": ")
        Dim SiteName() As String = Split(SiteParameters(1), ": ")
        Dim IPAddress() As String = Split(SiteParameters(2), ": ")
        Dim SQLPort() As String = Split(SiteParameters(3), ": ")
        Dim IISPort() As String = Split(SiteParameters(4), ": ")
        Dim SQLInstance() As String = Split(SiteParameters(5), ": ")
        Debug.Print("Site Parameters" + SiteParameters(1))
        Debug.Print("HostName: " + HostName(1))
        Debug.Print("Sitename: " + SiteName(1))
        Debug.Print("IPAddress: " + IPAddress(1))
        Debug.Print("SQLPort: " + SQLPort(1))
        Debug.Print("IISPort" + IISPort(1))
        Debug.Print("SQL INSTANCE + " + SQLInstance(1))
        Me.tbx_SQLMachine.Text = HostName(1)
        Me.tbx_SiteName.Text = SiteName(1)
        Me.tbx_IISIP.Text = IPAddress(1)
        Me.tbx_SQLIP.Text = IPAddress(1)
        Me.tbx_SqlPort.Text = SQLPort(1)
        Me.tbx_IISPort.Text = IISPort(1)
        Me.tbx_SQLInstance.Text = SQLInstance(1)

        AddSite()
    End Sub


    Private Function GetID() As String
        Dim strProcessorId As String = Nothing
        Dim query As New SelectQuery("Win32_processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject

        For Each info In search.Get()
            strProcessorId = info("processorId").ToString()
        Next

        Return Dns.GetHostName + "::" + strProcessorId
    End Function


    Private Function CheckMID(ByVal _MID As String) As Boolean
        Try
            Dim query As String = "SELECT Count(MUID) FROM ClientAccess WHERE MUID='" + _MID + "'"
            Dim dt_MID As DataTable = ServerSQL.ExecuteQuery(query)

            If dt_MID.Rows(0)(0) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function


    Private Function CreateMID() As String
        'generate MID - MachineID
        Dim newMID As String = idUtils.GenerateMID

        'check uniqueness of MID
        While CheckMID(newMID)
            newMID = idUtils.GenerateMID
        End While

        'write to registry
        Dim MyKey As RegistryKey
        MyKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\ISSI\Daqart\Settings", True)
        MyKey.CreateSubKey(siteList.Text + "_MID")
        MyKey.Close()

        Dim regKey As String
        regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
        Registry.SetValue(regKey, siteList.Text + "_MID", newMID, RegistryValueKind.String)

        runtime.MID = newMID

        Return newMID
    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New Diagnostics
        frm.Show()
    End Sub
End Class

