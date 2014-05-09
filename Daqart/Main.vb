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
Imports CommonForms
Imports Microsoft.Win32


Public Class Main
    Inherits System.Windows.Forms.Form

    Public user As String = runtime.UserName
    Dim connClient As SqlCeConnection
    Dim connServer As SqlCeConnection
    Dim connSQLProject As SqlCeConnection
    Dim SystemTable As DataTable
    Public Shared selectedProject As String
    Dim dt_Temp As DataTable
    Dim dt_notes As DataTable
    Dim struser As String = ""
    Dim strchild As String = ""
    Dim tempid As Integer
    Dim strtemp As String
    Dim stredit As String
    Public Shared dt_CurrentSystem As DataTable
    Private LoggedIn As Boolean = False
    Private Synchronizing As Boolean
    Private Loading As Boolean = True


    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Loading = True

            If runtime.UserName = "" Then
                Dim thisLogin As New login.frmLogin
                thisLogin.ShowDialog()
                Debug.Print("If runtime.Username HIT")
            End If

            If runtime.AppShutdown Then
                Application.Exit()
            End If

            connServer = daqartDLL.connections.serverDBConnect(connServer)
            If runtime.UserMUID = "" Then
                Me.Dispose()
                Application.Exit()
                Exit Sub
            End If
            Debug.Print("If coonServer  HIT")
            Utilities.ReadIniFile()
            Debug.Print("readinifile returned")
            connClient = daqartDLL.connections.localDBConnect(connClient)
            connClient.Open()
            connServer.Open()


            projectSelect.ShowDialog()

            runtime.SQLProject = New DataUtilsGlobal("project")
            runtime.SQLDaqument001 = New DataUtilsGlobal("Daqument001")

            runtime.SQLProject.OpenConnection()
            runtime.SQLDaqument001.OpenConnection()

            'If runtime.ConnectionMode = "ONLINE" Then
            '    runtime.ConnectionMode = "OFFLINE"
            '    runtime.SQLProject.OpenConnection()

            '    runtime.PackageTable = Utilities.Cache_PackageList
            '    runtime.ConnectionMode = "ONLINE"
            '    runtime.SQLProject.OpenConnection()

            'Else
            '    runtime.PackageTable = Utilities.Cache_PackageList
            'End If

            tsl_SiteLabel.Text = "Site: " + runtime.SiteName
            Me.lbl_User.Text = Utilities.GetUserName(runtime.UserMUID)

            pnl_Desktop.Visible = True
            LoggedIn = True

            GetCompanyLogo()
            CheckMessages()
            Dim m_Thread As Thread

            Me.lbl_Message.Text = "Getting synchronization info..."
            Dim query As String = "SELECT * FROM ClientAccess WHERE MUID='" + runtime.MID + "'"
            Dim dt_Sync As DataTable = runtime.SQLServer.ExecuteQuery(query)

            If dt_Sync.Rows.Count = 0 Then
                Me.lbl_Message.Text = "Synchronization info not found."
            Else
                Me.lbl_Message.Text = "Synchronize Complete at " + dt_Sync.Rows(0)("LastAccess")
            End If


            Me.Refresh()
            Thread.Sleep(200)

            m_Thread = New Thread(AddressOf GetSyncInfo)
            m_Thread.Start()

            If runtime.ConnectionMode = "OFFLINE" Then
                Me.btn_ChangeMode.Image = My.Resources.Resources.Bulb_Off
                Me.btn_ChangeMode.ToolTipText = "Go Online"
            ElseIf runtime.ConnectionMode = "ONLINE" Then
                Me.btn_ChangeMode.Image = My.Resources.Resources.Bulb_On
                Me.btn_ChangeMode.ToolTipText = "Go Offline"
            End If


            Dim regKey As String
            Dim regValue As String
            regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
            regValue = Registry.GetValue(regKey, "DefaultPrintSize", Nothing)
            If regValue = Nothing Then
                Dim MyKey As RegistryKey
                MyKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\ISSI\Daqart\Settings", True)
                MyKey.CreateSubKey("DefaultPrintSize")
                MyKey.Close()
            End If

            regValue = Registry.GetValue(regKey, "DefaultPrintLandscape", Nothing)
            If regValue = Nothing Then
                Dim MyKey As RegistryKey
                MyKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\ISSI\Daqart\Settings", True)
                MyKey.CreateSubKey("DefaultPrintLandscape")
                MyKey.Close()
            End If

            regValue = Registry.GetValue(regKey, "DefaultPrintSource", Nothing)
            If regValue = Nothing Then
                Dim MyKey As RegistryKey
                MyKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\ISSI\Daqart\Settings", True)
                MyKey.CreateSubKey("DefaultPrintSource")
                MyKey.Close()
            End If

            Utilities.LoadSymbols()

            Loading = False
        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.Main_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        NotifyIcon1.Dispose()
        Me.Dispose()
    End Sub


    Private Sub Main_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        NotifyIcon1.Dispose()
    End Sub


    Private Sub GetCompanyLogo()
        Dim qry = "SELECT DocumentImage FROM projectImages WHERE Name = 'Logo128'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim table As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        'Specify general settings
        Dim dr As String = runtime.AbsolutePath + "sites\images\"
        IO.Directory.CreateDirectory(dr)
        Dim logoPath = runtime.AbsolutePath + "sites\images\logo128.jpg"
        Dim logo As Boolean = False
        If Not table Is Nothing Then
            If (table.Rows.Count > 0) Then
                Dim buffer() As Byte = table.Rows(0)(0)
                Dim m As New MemoryStream(buffer)
                Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(m)
                Image.Save(logoPath, System.Drawing.Imaging.ImageFormat.Jpeg)
                Image.Dispose()
                logo = True
            End If
        End If
        If Not logo Then
            ' create a dummy logo
            Dim bm As New Bitmap(128, 128)
            Dim g As Graphics = Graphics.FromImage(bm)
            Dim myBrush As Brush = New SolidBrush(Color.White)
            Dim rect As Rectangle = New Rectangle(0, 0, 128, 128)

            g.FillRectangle(myBrush, rect)
            bm.Save(logoPath, System.Drawing.Imaging.ImageFormat.Jpeg)
            bm.Dispose()
        End If
    End Sub


    Private Sub GetSyncInfo()
        Dim query As String = "SELECT SyncTS FROM ClientAccess WHERE Description = '" + Utilities.GetMachineID() + "'"
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
        sqlSrvUtils.CloseConnection()
    End Sub


    Private Sub LogOutExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutExitToolStripMenuItem.Click
        Application.Exit()
    End Sub


    Private Sub LogOut()
        NotifyIcon1.Dispose()

        Try
            Dim ServerSQL As New DataUtils("server")
            Dim query As String = "INSERT INTO userlog (MUID,UserMUID,TS,Action,Time,Project) VALUES (" & _
                    " @MUID," & _
                    " @UserMUID," & _
                    " @TS," & _
                    " @DIR," & _
                    " @TS2,'')"

            Dim dt_param As DataTable = ServerSQL.paramDT
            dt_param.Rows.Add("@UserMUID", runtime.UserMUID)
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@DIR", "Out")
            dt_param.Rows.Add("@TS2", Now())

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

        Catch ex As SqlCeException
            MessageBox.Show("Failed to add session to Log records: " + ex.Message)
        End Try
    End Sub


    Private Function GetProjects()
        Dim connServer As SqlCeConnection = Nothing
        connServer = daqartDLL.connections.serverDBConnect(connServer)
        Dim query As String = "SELECT * FROM projects WHERE Active='1'"
        Dim cmd As New SqlCeCommand(query, connServer)
        Dim reader As SqlCeDataReader = Nothing
        Dim hasProjects As Boolean

        Try
            reader = cmd.ExecuteReader()
            reader = cmd.ExecuteResultSet(ResultSetOptions.Scrollable)
            hasProjects = reader.HasRows
        Catch ex As SqlCeException
            MessageBox.Show("Failed to connect to site: " + ex.Message)
        End Try
        reader.Close()

        Return hasProjects
    End Function


    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        NotifyIcon1.Dispose()
        If runtime.AppShutdown Then
            Exit Sub
        End If

        If Not runtime.UserMUID = "" Then
            LogOut()

            runtime.SQLProject.CloseConnection()
            runtime.SQLServer.CloseConnection()
            runtime.SQLDaqument.CloseConnection()
            runtime.SQLDaqument001.CloseConnection()
            runtime.SQLMaster.CloseConnection()
        End If


        'Try
        '    If connClient.State = ConnectionState.Open Then
        '        connClient.Close()
        '    End If

        '    If connServer.State = ConnectionState.Open Then
        '        connServer.Close()
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub NewProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsm_NewProject.Click
        If Not Utilities.CheckPermission("PRO001") Then
            MessageBox.Show("Your user account is not configured to access this feature, please contact your System Administrator.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        LaunchProjectWizard()
    End Sub


    Public Shared Sub LaunchProjectWizard()
        Dim formProjectWizard As New ProjectWizard.start
        formProjectWizard.ShowDialog()

        mainFunctions.SetSelectedProject()
    End Sub


    Private Sub AboutDaqartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutDaqartToolStripMenuItem.Click
        AboutDaqart.ShowDialog()
    End Sub


    Private Sub ConnTimer_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles ConnTimer.Elapsed
        If Not LoggedIn Then
            'Me.ConnTimer.Stop()
            Return
        End If

        If Not runtime.selectedProject = "" Then
            CheckMessages()
        End If


        If runtime.ConnectionMode = "OFFLINE" Then
            ConnectionStatusInd.Image = My.Resources.Resources.Folder_1_Network_Restricted
            Return
        End If

        If Utilities.Ping(runtime.IISIP) Then
            ConnectionStatusInd.Image = My.Resources.Resources.Folder_1_Network_Check
            runtime.ConnectionMode = "ONLINE"
            Me.btn_Sync.Enabled = True
            If runtime.ConnectionMode = "OFFLINE" Then
                Me.btn_ChangeMode.Image = My.Resources.Resources.Bulb_Off
                Me.btn_ChangeMode.ToolTipText = "Go Online"
            ElseIf runtime.ConnectionMode = "ONLINE" Then
                Me.btn_ChangeMode.Image = My.Resources.Resources.Bulb_On
                Me.btn_ChangeMode.ToolTipText = "Go Offline"
            End If

            If runtime.ConnectionMode = "LOST_CONNECTION" Then
                MessageBox.Show("Connection to server has been restored.", "Connection Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Else
            Me.btn_Sync.Enabled = False
            ConnectionStatusInd.Image = My.Resources.Resources.Folder_1_Network_Restricted
            If runtime.ConnectionMode = "ONLINE" Then
                runtime.ConnectionMode = "OFFLINE"
                Me.ConnTimer.Stop()
                Me.btn_ChangeMode.Image = My.Resources.Resources.Bulb_Off
                Me.btn_ChangeMode.ToolTipText = "Go Offline"
                MessageBox.Show("Connection to server has been lost. Switching to OFFLINE mode.  Changes made ONLINE cannot be seen until the connection is restored.", "Connection Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ConnTimer.Start()

                runtime.SQLServer.OpenConnection()
                runtime.SQLDaqument.OpenConnection()
                runtime.SQLMaster.OpenConnection()

                runtime.SQLDaqument001.OpenConnection()
                runtime.SQLProject.OpenConnection()
            End If
        End If


    End Sub


    Private Sub FormBuilder10ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormBuilder10ToolStripMenuItem.Click
        If Not CheckProject() Then Return
        tlp_FormBuilder.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        Dim myform As New FormDesigner.FormMain
        myform.Show()
    End Sub


    Private Sub HelpManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpManualToolStripMenuItem.Click
        Help.ShowHelp(Me, runtime.AbsolutePath() + "\daqart.chm")
    End Sub


    Private Sub DataManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataManagerToolStripMenuItem.Click
        If Not runtime.UserName.ToLower = "admin" Then
            If Not Utilities.CheckPermission("DMR001") Then
                MessageBox.Show("Your user account is not configured to access this feature, please contact your System Administrator.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        Dim userManager As New DataManager.DataManagerMain
        userManager.Show()
    End Sub


    Private Sub SelectProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectProjectToolStripMenuItem.Click
        projectSelect.ShowDialog()
    End Sub


    Private Sub SystemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsm_Systems.Click
        If Not Utilities.CheckPermission("SYS001") Then
            MessageBox.Show("Your user account is not configured to manage System Numbers, please contact your System Administrator.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        If Not CheckProject() Then Return

        Dim systemManager As New ProjectWizard.CreateSystemNumbers
        systemManager.Show()
    End Sub


    Private Sub ManageProjectsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageProjectsToolStripMenuItem.Click
        If Not Utilities.CheckPermission("PRO004") Then
            MessageBox.Show("Your user account is not configured to manage Projects, please contact your System Administrator.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim projectManager As New ProjectManager.ProjectMain
        projectManager.ShowDialog()
    End Sub


    Private Sub MessagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessagesToolStripMenuItem.Click
        '     If Not CheckProject() Then Return
        '     Dim myMessages As New Messages.Inbox
        '    myMessages.ShowDialog()
    End Sub


    Private Sub NotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotesToolStripMenuItem.Click
        '   If Not CheckProject() Then Return
        '   Dim myNotes As New Notes.NotesMain
        '   myNotes.ShowDialog()
    End Sub


    Private Sub SystemTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myTest As New testform
        myTest.ShowDialog()
    End Sub


    Private Sub ManagePackagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManagePackagesToolStripMenuItem.Click
        If Not Utilities.CheckPermission("PKG001") Then
            MessageBox.Show("Your user account is not configured to access this feature, please contact your System Administrator.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim PackageManager As New package.PackageMain
        Windows.Forms.Cursor.Current = Cursors.IBeam
        PackageManager.Show()
    End Sub


    Private Sub DaqumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaqumentToolStripMenuItem.Click
        If Not CheckProject() Then Return
        Dim DocumentManager As New Daqument.DaqumentMain
        DocumentManager.Show()
    End Sub


    Private Sub CreateNewFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CreateForm As New FormDesigner.FormAdd
        CreateForm.ShowDialog()
    End Sub


    Public Shared Sub CloseApplication()
        Application.Exit()
    End Sub


    Private Sub ManageFormsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CreateForm As New FormDesigner.FormMain()
        CreateForm.ShowDialog()
    End Sub


    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TagSearch()
    End Sub


    Private Sub TagSearch()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim myForm As New package.PkgSelect

        Windows.Forms.Cursor.Current = Cursors.IBeam
        myForm.Show()
    End Sub


    Private Sub PackageViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PackageViewerToolStripMenuItem.Click
        PackageViewer.PackageViewerManager.OpenPackageViewer()
    End Sub


    Private Sub ReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportsToolStripMenuItem.Click
        ReportManager.ReportViewerManager.OpenReport()
    End Sub


    Private Sub DiscrepancyManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiscrepancyManagerToolStripMenuItem.Click
        If Not CheckProject() Then Return
        Dim frmDiscrepancy As New DiscrepancyManager.DiscrepancyMain
        frmDiscrepancy.Show()
    End Sub


    Private Sub PunchlistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PunchlistToolStripMenuItem.Click
        '  If Not CheckProject() Then Return
        '  Dim frmPunchlist As New PunchlistManager.frmMain
        '   frmPunchlist.Show()
    End Sub


    Private Sub CalendarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalendarToolStripMenuItem.Click
        Dim frmDateTest As New calendar
        frmDateTest.Show()
    End Sub


    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Dim frmOptions As New Options
        frmOptions.ShowDialog()
    End Sub


    Private Sub StatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If runtime.selectedProject = "" Then Return


        Me.Cursor = Cursors.WaitCursor
        Dim myStatus As StatusManager.StatusSQL = New StatusManager.StatusSQL
        myStatus.LoopThroughAllStatus()


        Try
            Utilities.SubscribeToDB(runtime.selectedProject)
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Utilities.SubscribeToDB(runtime.SiteName + "_ServerDB")
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Utilities.SubscribeToDB(runtime.SiteName + "_Daqument")
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Utilities.SubscribeToDB(runtime.SiteName + "_Daqument001")
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub SystemAuditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemAuditToolStripMenuItem.Click
        If Not runtime.UserName.ToLower = "admin" Then
            If Not Utilities.CheckPermission("DMR001") Then
                MessageBox.Show("Your user account is not configured to access this feature, please contact your System Administrator.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        SystemToolsManager.OpenSystemTools()
    End Sub


    Private Sub SynchronizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SynchronizeToolStripMenuItem.Click
        If Not CheckProject() Then Return
        synchronize()
    End Sub


    Private Sub ToolStripButton2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Sync.Click
        Me.Cursor = Cursors.WaitCursor
        If Utilities.Ping(runtime.IISIP) Then
            synchronize()
        Else
            MessageBox.Show("Cannot connect to server.  Please check connection.", "Connection Error")
        End If

        'check user status
        Dim query As String = "SELECT * FROM userInfo WHERE MUID='" + runtime.UserMUID + "' And Active='True'"
        Dim ServerSQL As DataUtils = New DataUtils("server")
        ServerSQL.OpenConnection()
        Dim dt As DataTable = ServerSQL.ExecuteQuery(query)
        ServerSQL.CloseConnection()
        Me.Cursor = Cursors.Default

        If dt.Rows.Count = 0 Then
            MessageBox.Show("User account no longer active, please contact administrator.", "Login Error")
            Application.Exit()
        End If

    End Sub


    Private Sub synchronize()
        Dim m_Thread As Thread

        Me.lbl_Message.Text = "Synchronizing with Project server..."
        Me.Refresh()

        Me.Cursor = Cursors.WaitCursor
        Thread.Sleep(500)

        m_Thread = New Thread(AddressOf SyncAll)
        m_Thread.Start()

        Dim frm_Syncing As New CommonForms.Sync
        frm_Syncing.Show()
        frm_Syncing.Refresh()
        Thread.Sleep(500)

        Synchronizing = True
        While (Synchronizing)
            frm_Syncing.Refresh()
            Thread.Sleep(500)
        End While

        Utilities.Cache_Symbols()

        Dim endtime As String = Now()
        Me.lbl_Message.Text = "Synchronize Complete at " + endtime

        Dim query As String = "UPDATE ClientAccess Set LastAccess = @SyncTS WHERE MUID=@MUID"
        Dim dt_param As DataTable = runtime.SQLServer.paramDT

        dt_param.Rows.Add("@SyncTS", endtime)
        dt_param.Rows.Add("@MUID", runtime.MID)

        runtime.SQLServer.ExecuteNonQuery(query, dt_param)

        frm_Syncing.Dispose()
        m_Thread.Abort()
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        '     Dim frmnotes As New Notes.frmNew
        '    frmnotes.ShowDialog()
    End Sub

 
    Private Sub WeldTrackingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeldTrackingToolStripMenuItem.Click
        Dim DocumentManager As New Daqument.WeldMain
        DocumentManager.Show()
    End Sub


    Private Sub TaskManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskManagerToolStripMenuItem.Click
        Dim frm_TaskManager As New TaskManager.TaskManagerMain
        frm_TaskManager.Show()
    End Sub


    Private Sub TimeSheetManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeSheetManagerToolStripMenuItem.Click
        '    Dim frm_TimeSheetManager As New TimeSheetManager.TimeSheetMain
        '   frm_TimeSheetManager.Show()
    End Sub


    Private Sub ClearIconBoundry()
        tlp_SystemView.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        tlp_FormBuilder.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        tlp_Daqument.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        tlp_Discrepancy.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        tlp_Messages.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        tlp_Notes.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        tlp_Punchlist.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        tlp_TaskManager.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        tlp_Timesheet.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        tlp_WeldTracking.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        Me.tlp_PackageViewer.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        Me.tlp_ReferenceLibrary.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        Me.tlp_ProjectView.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        Me.tlp_ProgressReport.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        Me.tlp_TurnoverReport.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
    End Sub


    Private Sub pbx_SystemView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_SystemView.Click
        ClearIconBoundry()
        tlp_SystemView.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_SystemView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_SystemView.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        If Not CheckProject() Then
            Return
        End If
        tlp_SystemView.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        Dim frm_SystemView As New SystemView
        SystemView.Show()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub pbx_FormBuilder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_FormBuilder.Click
        ClearIconBoundry()
        tlp_FormBuilder.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_FormBuilder_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_FormBuilder.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        If Not CheckProject() Then Return
        tlp_FormBuilder.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        FormDesigner.FormEditManager.OpenFormEdit()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub pbx_Daqument_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Daqument.Click
        ClearIconBoundry()
        tlp_Daqument.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_Daqument_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Daqument.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        If Not CheckProject() Then Return
        tlp_Daqument.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        Dim myform As New Daqument.DaqumentMain
        myform.Show()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub pbx_Discrepancy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Discrepancy.Click
        ClearIconBoundry()
        tlp_Discrepancy.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_Discrepancy_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Discrepancy.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        If Not CheckProject() Then Return
        tlp_Discrepancy.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        Dim myform As New DiscrepancyManager.DiscrepancyMain
        myform.Show()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub pbx_Messages_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Messages.Click
        ClearIconBoundry()
        tlp_Messages.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_Messages_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Messages.DoubleClick
        ''   Me.Cursor = Cursors.WaitCursor
        ''   ClearIconBoundry()
        ''  If Not CheckProject() Then Return
        ''   tlp_Messages.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        ''    Dim myform As New Messages.Inbox
        ''   myform.Show()
        ''   Me.Cursor = Cursors.Default
    End Sub


    Private Sub pbx_Notes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Notes.Click
        ClearIconBoundry()
        tlp_Notes.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_Notes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Notes.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        ''   If Not CheckProject() Then Return
        ''    tlp_Notes.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        ''     Dim myform As New Notes.NotesMain
        ''     myform.Show()
        ''     Me.Cursor = Cursors.Default
    End Sub


    Private Sub pbx_Punchlist_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Punchlist.Click
        ClearIconBoundry()
        tlp_Punchlist.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_Punchlist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Punchlist.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        ''    If Not CheckProject() Then Return
        ''     tlp_Punchlist.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        ''    Dim myform As New PunchlistManager.frmMain
        ''    myform.Show()
        ''   Me.Cursor = Cursors.Default
    End Sub


    Private Sub pbx_TaskManager_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_TaskManager.Click
        ClearIconBoundry()
        tlp_TaskManager.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_TaskManager_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_TaskManager.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        tlp_TaskManager.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        Dim myform As New TaskManager.TaskManagerMain
        myform.Show()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub pbx_Timesheet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Timesheet.Click
        ClearIconBoundry()
        tlp_Timesheet.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_Timesheet_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Timesheet.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        ''    tlp_Timesheet.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        ''    Dim myform As New TimeSheetManager.TimeSheetMain
        ''    myform.Show()
        ''    Me.Cursor = Cursors.Default
    End Sub


    Private Sub pbx_WeldTracking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_WeldTracking.Click
        ClearIconBoundry()
        tlp_WeldTracking.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_WeldTracking_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_WeldTracking.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        tlp_WeldTracking.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        Dim myform As New Daqument.WeldMain
        myform.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TagSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TagSearchToolStripMenuItem.Click
        Dim myForm As Form = Daqart.TagSearch
        myForm.ShowDialog()
    End Sub


    Private Sub SyncAll()
        Dim starttime As String = Now()
        Synchronizing = True
        Try
            Utilities.SubscribeToDB(runtime.selectedProject)
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Utilities.SubscribeToDB(runtime.SiteName + "_ServerDB")
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Utilities.SubscribeToDB(runtime.SiteName + "_Daqument")
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Utilities.SubscribeToDB(runtime.selectedProject + "_Daqument001")
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Synchronizing = False


    End Sub

    Private Sub SystemTestToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemTestToolStripMenuItem.Click
        Dim frm_Test As New testform
        frm_Test.Show()
    End Sub


    Private Sub ErrorLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorLogToolStripMenuItem.Click
        Dim myForm As Form = New ErrorLogView
        myForm.Show()
    End Sub


    Private Sub CheckMessages()
        Dim query As String
        'Dim dt As New DataTable

        query = "select MUID,SenderMUID,Subject,TS from messages_received where Status = '1' AND ReceiverMUID ='" + runtime.UserMUID + "' "
        'dt = Utilities.ExecuteQuery(query, "project")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()


        If Not dt Is Nothing Then
            If dt.Rows.Count = 0 Then
                Me.pbx_Messages.Image = My.Resources.Email_Inbox_Empty
            Else
                Me.pbx_Messages.Image = My.Resources.Email_Inbox
            End If
        End If
    End Sub


    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Dim frm_ChangePassword As New login.PasswordChange(runtime.UserMUID)
        frm_ChangePassword.Label1.Text = "Please enter your new password below."
        frm_ChangePassword.ShowDialog()
    End Sub

 
    Private Sub VersionUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VersionUpdateToolStripMenuItem.Click
        Dim myForm As Form = New Daqart.VersionUpdates()
        myForm.Show()
    End Sub

    Private Sub pbx_PackageViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx_PackageViewer.Click
        ClearIconBoundry()
        Me.tlp_PackageViewer.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_PackageViewer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_PackageViewer.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        If Not CheckProject() Then Return
        Me.tlp_PackageViewer.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        PackageViewer.PackageViewerManager.OpenPackageViewer()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pbx_ReferenceLibrary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx_ReferenceLibrary.Click
        ClearIconBoundry()
        Me.tlp_ReferenceLibrary.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_ReferenceLibrary_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_ReferenceLibrary.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        If Not CheckProject() Then Return
        Me.tlp_ReferenceLibrary.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        Dim myform As New ReferenceLibrary.RefLibMain
        myform.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function CheckProject() As Boolean
        If runtime.selectedProject = "" Then
            MessageBox.Show("You must first select a project.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function


    'Private path As String = "C:\tmp\mapfile.txt"
    'Dim sw As StreamWriter
    'Private Function TableFileVerify(ByVal dbName As String) As Boolean
    '    Dim err As Boolean = False
    '    Dim query As String = " SELECT * FROM sys.Tables "
    '    Dim sqlSrvUtils As DataUtils = New DataUtils(dbName)
    '    sqlSrvUtils.OpenConnection()
    '    Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
    '    If dt.Rows.Count > 0 Then
    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            Dim tmpTblName = dt.Rows(i)(0)
    '            If InStr(tmpTblName, "tmp") Then
    '                Dim orgTblName = Split(tmpTblName, "tmp_")(1)
    '                query = " SELECT * FROM " + tmpTblName
    '                Dim dtTmp As DataTable = sqlSrvUtils.ExecuteQuery(query)
    '                For j As Integer = 0 To dtTmp.Columns.Count - 1
    '                    Dim ColumnName = dtTmp.Columns(j).Caption
    '                    If InStr(ColumnName, "MUID") > 0 Then

    '                    Else
    '                        query = " SELECT " + ColumnName + " FROM " + orgTblName + " ORDER BY " + ColumnName
    '                        Dim OrgTbl As DataTable = sqlSrvUtils.ExecuteQuery(query)
    '                        query = " SELECT " + ColumnName + " FROM " + tmpTblName + " ORDER BY " + ColumnName
    '                        Dim TmpTbl As DataTable = sqlSrvUtils.ExecuteQuery(query)
    '                        For k As Integer = 0 To TmpTbl.Rows.Count - 1
    '                            If Not IsDBNull(TmpTbl.Rows(k)(ColumnName)) And Not IsDBNull(OrgTbl.Rows(k)(ColumnName)) Then
    '                                If TmpTbl.Rows(k)(ColumnName).ToString = OrgTbl.Rows(k)(ColumnName).ToString Then
    '                                Else
    '                                    MessageBox.Show("Mismatch values: TableName: '" + _
    '                                    orgTblName + "' Row: '" + k.ToString + "' -- " + _
    '                                    " Expecting: '" + OrgTbl.Rows(k)(ColumnName).ToString + _
    '                                    " Found: '" + dtTmp.Rows(k)(ColumnName).ToString + "'")
    '                                    'sqlSrvUtils.CloseConnection()
    '                                    'Return True
    '                                End If
    '                            End If
    '                        Next
    '                    End If
    '                Next
    '            End If
    '        Next
    '    End If
    '    Return False
    '    MessageBox.Show("Table contents verified")
    '    sqlSrvUtils.CloseConnection()
    'End Function

    'Private Function TableVerify(ByVal dbName As String) As Boolean
    '    Dim err As Boolean = False
    '    Dim query As String = " SELECT * FROM sys.Tables "
    '    Dim sqlSrvUtils As DataUtils
    '    If InStr(dbName, "USE") Then
    '        sqlSrvUtils = New DataUtils("system")
    '        sqlSrvUtils.UseString = dbName
    '    Else
    '        sqlSrvUtils = New DataUtils(dbName)
    '    End If
    '    sqlSrvUtils.OpenConnection()
    '    Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
    '    If dt.Rows.Count > 0 Then
    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            Dim tmpTblName = dt.Rows(i)(0)
    '            If InStr(tmpTblName, "tmp") Then
    '                Dim orgTblName = Split(tmpTblName, "tmp_")(1)
    '                query = " SELECT * FROM " + tmpTblName
    '                Dim dtTmp As DataTable = sqlSrvUtils.ExecuteQuery(query)

    '                For j As Integer = 0 To dtTmp.Columns.Count - 1
    '                    Dim ColumnName = dtTmp.Columns(j).Caption
    '                    Dim orgquery = " SELECT " + ColumnName + " FROM " + orgTblName + " ORDER BY " + ColumnName
    '                    Dim OrgTbl As DataTable = sqlSrvUtils.ExecuteQuery(orgquery)
    '                    Dim tmpquery = " SELECT " + ColumnName + " FROM " + tmpTblName + " ORDER BY " + ColumnName
    '                    Dim TmpTbl As DataTable = sqlSrvUtils.ExecuteQuery(tmpquery)
    '                    If Not TmpTbl Is Nothing And Not OrgTbl Is Nothing Then
    '                        If TmpTbl.Rows.Count > 0 And OrgTbl.Rows.Count > 0 Then
    '                            For k As Integer = 0 To OrgTbl.Rows.Count - 1
    '                                If Not IsDBNull(TmpTbl.Rows(k)(ColumnName)) And Not IsDBNull(OrgTbl.Rows(k)(ColumnName)) Then
    '                                    If TmpTbl.Rows(k)(ColumnName).ToString = OrgTbl.Rows(k)(ColumnName).ToString Then
    '                                    Else
    '                                        Dim errMsg As String = _
    '                                        "Mismatch values: TableName: '" + _
    '                                        orgTblName + "' Row: '" + k.ToString + "' -- " + _
    '                                        " Expecting: '" + OrgTbl.Rows(k)(ColumnName).ToString + _
    '                                        "' Found: '" + TmpTbl.Rows(k)(ColumnName).ToString + "'"

    '                                        MessageBox.Show("Mismatch values: TableName: '" + _
    '                                        orgTblName + "' Row: '" + k.ToString + "' -- " + _
    '                                        " Expecting: '" + OrgTbl.Rows(k)(ColumnName).ToString + _
    '                                        "' Found: '" + TmpTbl.Rows(k)(ColumnName).ToString + "'")
    '                                        'sqlSrvUtils.CloseConnection()
    '                                        'Return True
    '                                        sw.WriteLine(orgquery)
    '                                        sw.WriteLine(tmpquery)
    '                                        sw.WriteLine(errMsg)

    '                                    End If
    '                                End If
    '                            Next
    '                        End If
    '                    End If
    '                Next
    '            End If
    '        Next
    '    End If
    '    Return False
    '    MessageBox.Show("Table contents verified")
    '    sqlSrvUtils.CloseConnection()
    'End Function
    'Private Function TableDaqumentCabinetVerify() As Boolean
    '    Dim err As Boolean = False
    '    Dim query As String = " SELECT * FROM sys.Tables "
    '    Dim orgDaq001 As DataUtils = New DataUtils("system")
    '    Dim tmpDaq001 As DataUtils = New DataUtils("system")
    '    orgDaq001.UseString = "USE [Test02_Daqument001] "
    '    tmpDaq001.UseString = "USE [Test02_Project01_Daqument001] "
    '    orgDaq001.OpenConnection()
    '    tmpDaq001.OpenConnection()
    '    Dim dt As DataTable = tmpDaq001.ExecuteQuery(query)
    '    If dt.Rows.Count > 0 Then
    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            Dim tmpTblName = dt.Rows(i)(0)
    '            Dim orgTblName = tmpTblName
    '            query = " SELECT * FROM " + tmpTblName
    '            Dim dtTmp As DataTable = tmpDaq001.ExecuteQuery(query)
    '            For j As Integer = 0 To dtTmp.Columns.Count - 1
    '                Dim ColumnName = dtTmp.Columns(j).Caption
    '                Dim orgquery = " SELECT " + ColumnName + " FROM " + orgTblName + " ORDER BY " + ColumnName
    '                Dim OrgTbl As DataTable = orgDaq001.ExecuteQuery(orgquery)
    '                Dim tmpquery = " SELECT " + ColumnName + " FROM " + tmpTblName + " ORDER BY " + ColumnName
    '                Dim TmpTbl As DataTable = tmpDaq001.ExecuteQuery(tmpquery)
    '                If Not TmpTbl Is Nothing And Not OrgTbl Is Nothing Then
    '                    Dim ctr = TmpTbl.Rows.Count
    '                    If ctr > OrgTbl.Rows.Count Then
    '                        ctr = OrgTbl.Rows.Count
    '                    End If
    '                    For k As Integer = 0 To ctr - 1
    '                        If Not IsDBNull(TmpTbl.Rows(k)(ColumnName)) And Not IsDBNull(OrgTbl.Rows(k)(ColumnName)) Then
    '                            If TmpTbl.Rows(k)(ColumnName).ToString = OrgTbl.Rows(k)(ColumnName).ToString Then
    '                            Else
    '                                Dim errMsg As String = _
    '                                "Mismatch values: TableName: '" + _
    '                                orgTblName + "' Row: '" + k.ToString + "' -- " + _
    '                                " Expecting: '" + OrgTbl.Rows(k)(ColumnName).ToString + _
    '                                "' Found: '" + TmpTbl.Rows(k)(ColumnName).ToString + "'"

    '                                'MessageBox.Show("Mismatch values: TableName: '" + _
    '                                'orgTblName + "' Row: '" + k.ToString + "' -- " + _
    '                                '" Expecting: '" + OrgTbl.Rows(k)(ColumnName).ToString + _
    '                                '"' Found: '" + TmpTbl.Rows(k)(ColumnName).ToString + "'")
    '                                'sqlSrvUtils.CloseConnection()
    '                                'Return True
    '                                sw.WriteLine(orgquery)
    '                                sw.WriteLine(tmpquery)
    '                                sw.WriteLine(errMsg)

    '                            End If
    '                        End If
    '                    Next
    '                End If
    '            Next

    '        Next
    '    End If
    '    MessageBox.Show("Table contents verified")
    'End Function


    'Private Function TableColumnList(ByVal dbName As String) As Boolean
    '    Dim mapTbl As New DataTable
    '    For ii As Integer = 0 To 200
    '        Dim tblCol As New DataColumn
    '        tblCol.Caption = "Column_" + ii.ToString
    '        tblCol.DataType = GetType(String)
    '        mapTbl.Columns.Add(tblCol)
    '    Next
    '    Dim query As String = " SELECT * FROM sys.Tables "
    '    Dim sqlSrvUtils As DataUtils = New DataUtils(dbName)
    '    sqlSrvUtils.OpenConnection()
    '    Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
    '    If dt.Rows.Count > 0 Then
    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            Dim tmpTblName = dt.Rows(i)(0)
    '            If InStr(tmpTblName, "tmp") And tmpTblName <> "tmp_WPS_fields" Then
    '                Dim dr As DataRow = mapTbl.NewRow
    '                Dim colNum As Integer = 0
    '                dr(colNum) = tmpTblName
    '                Dim tcNames As String = tmpTblName
    '                Dim tmpquery = " SELECT * FROM " + tmpTblName
    '                Dim dtTmp As DataTable = sqlSrvUtils.ExecuteQuery(tmpquery)
    '                For j As Integer = 0 To dtTmp.Columns.Count - 1
    '                    Dim ColumnName As String = dtTmp.Columns(j).Caption
    '                    If InStr(ColumnName, "ID") Then
    '                    Else
    '                        If ColumnName <> "rowguid" And ColumnName <> "SystemNumber" Then
    '                            colNum += 1
    '                            dr(colNum) = ColumnName
    '                            tcNames = tcNames + "," + ColumnName
    '                        End If
    '                    End If
    '                Next
    '                mapTbl.Rows.Add(dr)
    '                sw.WriteLine(tcNames)
    '                Dim odr As DataRow = mapTbl.NewRow
    '                colNum = 0

    '                Dim orgTblName = Split(tmpTblName, "tmp_")(1)
    '                tcNames = orgTblName
    '                Dim orgquery = " SELECT * FROM " + orgTblName
    '                odr(colNum) = orgTblName
    '                Dim dtOrg As DataTable = sqlSrvUtils.ExecuteQuery(orgquery)
    '                For j As Integer = 0 To dtOrg.Columns.Count - 1
    '                    Dim ColumnName As String = dtOrg.Columns(j).Caption
    '                    If InStr(ColumnName, "ID") Then
    '                    Else
    '                        If ColumnName <> "rowguid" And ColumnName <> "SystemNumber" Then
    '                            colNum += 1
    '                            dr(colNum) = ColumnName
    '                            tcNames = tcNames + "," + ColumnName
    '                        End If
    '                    End If
    '                Next
    '                mapTbl.Rows.Add(odr)
    '                sw.WriteLine(tcNames)
    '            sw.Flush()
    '            End If
    '        Next
    '    End If
    '    sqlSrvUtils.CloseConnection()
    '    Dim dgv As New DevExpress.XtraGrid.GridControl
    '    dgv.DataSource = mapTbl
    '    Dim myForm As New Form
    '    Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = dgv.FocusedView
    '    myForm.Controls.Add(dgv)
    '    myForm.Show()
    '    dgv.Dock = DockStyle.Fill
    '    'gv.OptionsView.ColumnAutoWidth = False
    '    dgv.ExportToXls("c:\tmp\" + dbName + "_mapList.xls")
    'End Function

    'Private Sub CompareTablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompareTablesToolStripMenuItem.Click
    '    'TableVerify("server")
    '    'sw = File.CreateText(path)
    '    'TableVerify("project")
    '    sw = File.CreateText(path)
    '    'TableVerify("USE [Test02_Project01_Daqument001] ")
    '    TableDaqumentCabinetVerify()
    '    'TableColumnList("server")
    '    'TableColumnList("project")
    '    'TableColumnList("Daqument")
    '    sw.Close()

    'End Sub

    Private Sub pbx_ProjectView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx_ProjectView.Click
        ClearIconBoundry()
        tlp_ProjectView.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub

    Private Sub pbx_ProjectView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx_ProjectView.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        tlp_ProjectView.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        Dim frm_projectStatus As New ProjectStatus
        frm_projectStatus.Show()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub pbx_ProgressReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx_ProgressReport.Click
        ClearIconBoundry()
        tlp_ProgressReport.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub

    Private Sub pbx_ProgressReport_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbx_ProgressReport.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        tlp_ProgressReport.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        Dim frm_ProgressReport As New CommonForms.TagStatusReport
        frm_ProgressReport.Show()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub pbx_TurnoverReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_TurnoverReport.Click
        ClearIconBoundry()
        tlp_TurnoverReport.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    End Sub
    Private Sub pbx_TurnoverReport_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_TurnoverReport.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        ClearIconBoundry()
        tlp_TurnoverReport.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        Dim frm_TurnoverReport As New TurnoverFilter
        frm_TurnoverReport.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ManualSynchronizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualSynchronizeToolStripMenuItem.Click
        Dim frm_ManuSynch As New ManualSynchronize
        frm_ManuSynch.Show()
    End Sub

    Private Sub btn_ChangeMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChangeMode.Click
        If Loading Then Return

        If runtime.ConnectionMode = "OFFLINE" Then
            synchronize()
            Me.btn_ChangeMode.Image = My.Resources.Resources.Bulb_On
            runtime.ConnectionMode = "ONLINE"
            Me.btn_ChangeMode.ToolTipText = "Go Online"
        ElseIf runtime.ConnectionMode = "ONLINE" Then
            synchronize()
            Me.btn_ChangeMode.Image = My.Resources.Resources.Bulb_Off
            runtime.ConnectionMode = "OFFLINE"
            Me.btn_ChangeMode.ToolTipText = "Go Offline"
        End If

        'runtime.SQLProject = New DataUtilsGlobal("project")
        'runtime.SQLDaqument001 = New DataUtilsGlobal("Daqument001")
        runtime.SQLServer.OpenConnection()
        runtime.SQLDaqument.OpenConnection()
        runtime.SQLMaster.OpenConnection()
        runtime.SQLDaqument001.OpenConnection()
        runtime.SQLProject.OpenConnection()

    End Sub


    Private Sub FixManHoursToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixManHoursToolStripMenuItem.Click

        Try
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()

            Dim query As String = "SELECT forms_status.MUID,forms_status.OwnerMUID AS OwnerMUID," & _
                " forms_status.FormMUID AS FormMUID, tags.TypeMUID, " & _
                " forms_status.RequiredManHours AS ReqMH, forms_status.EarnedManHours AS EMH" & _
                " FROM forms_status INNER JOIN tags ON forms_status.TagMUID = tags.MUID" & _
                " ORDER BY forms_status.MUID ASC"
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

            Dim FixedRows As Integer = 0
            Dim BadReq As Integer = 0
            Dim Rowcount As Integer = 0

            For i As Integer = 0 To dt.Rows.Count - 1

                query = "SELECT ManHours FROM requirements WHERE " & _
                    " OwnerMUID='" + dt.Rows(i)(1) + "'" & _
                    " AND TypeMUID='" + dt.Rows(i)(3) + "'" & _
                    " AND FormMUID='" + dt.Rows(i)(2) + "'"

                Dim dt_req As DataTable = sqlPrjUtils.ExecuteQuery(query)

                If dt_req.Rows.Count = 0 Then
                    BadReq += 1
                Else
                    If dt_req.Rows(0)(0) < Math.Round(dt.Rows(i)(5), 2) Then

                        'get new earnedMH
                        Dim Earned As Single = dt.Rows(i)(5) / dt.Rows(i)(4) * dt_req.Rows(0)(0)
                        'Earned = 6.0
                        query = "UPDATE forms_status SET RequiredManHours='" + dt_req.Rows(0)(0).ToString + "'," & _
                            " EarnedManHours='" + Earned.ToString + "' " & _
                            " WHERE MUID='" + dt.Rows(i)(0) + "'"

                        'execute query
                        Dim dt_param As DataTable = sqlPrjUtils.paramDT
                        sqlPrjUtils.ExecuteNonQuery(query, dt_param)

                        FixedRows += 1
                    End If
                End If

                Rowcount = i
            Next

            sqlPrjUtils.CloseConnection()

        Catch ex As Exception

        End Try

    End Sub


    Private Sub ChangeLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeLogToolStripMenuItem.Click
        Dim frm_CL As New ViewChangeLog
        frm_CL.ShowDialog()
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageSetupToolStripMenuItem.Click
        Dim DefaultPageSize As System.Drawing.Printing.PaperSize
        Dim DefaultLandscape As Boolean
        Dim DefaultSource As System.Drawing.Printing.PaperSource
        Dim DefaultMargins As System.Drawing.Printing.Margins



        Me.PageSetupDialog1.PageSettings = New System.Drawing.Printing.PageSettings
        Me.PageSetupDialog1.ShowDialog()

        DefaultPageSize = Me.PageSetupDialog1.PageSettings.PaperSize
        DefaultLandscape = Me.PageSetupDialog1.PageSettings.Landscape
        DefaultSource = Me.PageSetupDialog1.PageSettings.PaperSource
        DefaultMargins = Me.PageSetupDialog1.PageSettings.Margins


    End Sub

 
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim frm_Status As New StatusManager.ProjectStatus
        frm_Status.Show()
    End Sub


    Private Sub FixPackageDocumentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixPackageDocumentsToolStripMenuItem.Click

        Dim query As String = "SELECT * FROM package_documents"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        For Each dr As DataRow In dt.Rows
            query = "SELECT SystemMUID FROM package WHERE MUID='" + dr("PackageMUID") + "'"
            Dim dt_Sys As DataTable = runtime.SQLProject.ExecuteQuery(query)

            If dt_Sys.Rows.Count > 0 Then
                query = "UPDATE package_documents SET SystemMUID='" + dt_Sys.Rows(0)("SystemMUID") + "' WHERE MUID='" + dr("MUID") + "'"
                Dim dt_param As DataTable = runtime.SQLProject.paramDT
                runtime.SQLProject.ExecuteNonQuery(query, dt_param)
            End If

        Next

    End Sub

 
    Private Sub tbx_PackageViewer_TextChanged(sender As Object, e As EventArgs) Handles tbx_PackageViewer.TextChanged

    End Sub
End Class