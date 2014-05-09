Imports daqartDLL
Imports System.Data.SqlServerCe
Imports SystemManager
Imports System.IO


Public Class projectSelect
    Dim connClient As SqlCeConnection = daqartDLL.connections.localDBConnect(connClient)
    Dim connServer As SqlCeConnection = daqartDLL.connections.serverDBConnect(connServer)

    Private Sub projectSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connClient.Open()
            connServer.Open()

            GetProjects()

            If Not Utilities.CheckPermission("PRO001") Then
                btn_AddProject.Enabled = False
            End If

        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.projectSelect_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GetProjects()
        Dim qry_AllProjects As String = Nothing

        If Not Utilities.CheckPermission("PRO004") Then
            qry_AllProjects = " AND Active='1'"
        End If

        Dim query As String = "SELECT projects.MUID, projects.Name + ' - ' + Description as Show FROM projects,user_projects WHERE projects.MUID = user_projects.ProjectMUID AND user_projects.UserMUID='" + runtime.UserMUID + "'" + qry_AllProjects + " ORDER BY Name ASC"
        Try
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            sqlSrvUtils.OpenConnection()
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
            sqlSrvUtils.CloseConnection()

            ProjectList.DataSource = dt
            ProjectList.DisplayMember = dt.Columns(1).ToString
            ProjectList.ValueMember = dt.Columns(0).ToString
        Catch ex As SqlCeException
            MessageBox.Show("Failed to select projects from project database: " + ex.Message)
        End Try

    End Sub


    Private Sub ProjectSelectOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectSelectOK.Click
        Me.Enabled = False
        Me.Cursor = Cursors.AppStarting
        'check to see if local datastore has been loaded

        If runtime.ConnectionMode = "OFFLINE" Then
            Dim fn As String = runtime.AbsolutePath + "sites\" + runtime.SiteName + "\" + Utilities.GetProjectName(Me.ProjectList.SelectedValue) + ".sdf"
            If Not File.Exists(fn) Then
                Me.Enabled = True
                Me.Cursor = Cursors.Default
                MessageBox.Show("The local data store for the project you have" + vbCr + "selected does not exist, please connect to" + vbCr + "the project first in Online mode.")
                Return
            End If
        End If
        ExecProject()

        runtime.SQLProject = New DataUtilsGlobal("project")
        runtime.SQLDaqument001 = New DataUtilsGlobal("Daqument001")

        runtime.SQLDaqument001.OpenConnection()
        runtime.SQLProject.OpenConnection()

        ' runtime.PackageTable = Utilities.Cache_PackageList
        If runtime.ConnectionMode = "ONLINE" Then
            runtime.ConnectionMode = "OFFLINE"
            runtime.SQLProject.OpenConnection()

            runtime.PackageTable = Utilities.Cache_PackageList
            runtime.ConnectionMode = "ONLINE"
            runtime.SQLProject.OpenConnection()
        Else
            runtime.PackageTable = Utilities.Cache_PackageList
        End If

        Me.Cursor = Cursors.Default
        Me.Enabled = True

        Me.Dispose()
    End Sub


    Private Sub ExecProject()
        runtime.selectedProjectID = ProjectList.SelectedValue
        runtime.selectedProject = Utilities.GetProjectName(runtime.selectedProjectID)

        Try
            If runtime.ConnectionMode = "ONLINE" Then
                Utilities.SubscribeProjectDB(runtime.selectedProject)
                Utilities.SubscribeToDB(runtime.selectedProject + "_Daqument001")

            End If

            Main.ProjectStatusInd.Text = "Project: " + runtime.selectedProject
            Main.PackagesToolStripMenuItem.Enabled = True
            Main.pbx_FormBuilder.Enabled = True
            Main.pbx_SystemView.Enabled = True
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddProject.Click
        Main.LaunchProjectWizard()

        ProjectList.Items.Clear()
        GetProjects()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub


    Private Sub ProjectList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectList.SelectedIndexChanged
        If Not ProjectList.Text = "" Then
            ProjectSelectOK.Enabled = True
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Help.ShowHelp(Me, runtime.AbsolutePath() + "\daqart.chm")
    End Sub
End Class