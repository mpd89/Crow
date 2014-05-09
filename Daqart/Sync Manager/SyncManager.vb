Imports daqartDLL

Public Class SyncManager
    Dim dt_UserProjects As New DataTable
    Dim dt_ActiveProjects As New DataTable


    Private Sub SyncManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'populate My projects
        Dim query As String = "SELECT projects.MUID,projects.Name" & _
            " FROM projects,user_projects WHERE projects.MUID = user_projects.ProjectMUID " & _
            " AND user_projects.UserMUID='" + runtime.UserMUID + "'" & _
            " ORDER BY projects.Name ASC"
        dt_UserProjects = runtime.SQLServer.ExecuteQuery(query)

        Me.lbx_MyProjects.DataSource = dt_UserProjects
        Me.lbx_MyProjects.DisplayMember = dt_UserProjects.Columns("Name").ToString
        Me.lbx_MyProjects.ValueMember = dt_UserProjects.Columns("MUID").ToString


        query = "SELECT projects.MUID,projects.Name" & _
            " FROM projects WHERE Active = '1' " & _
            " ORDER BY projects.Name ASC"
        dt_ActiveProjects = runtime.SQLServer.ExecuteQuery(query)

        Me.lbx_Projects.DataSource = dt_UserProjects
        Me.lbx_Projects.DisplayMember = dt_UserProjects.Columns("Name").ToString
        Me.lbx_Projects.ValueMember = dt_UserProjects.Columns("MUID").ToString

    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub


    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

    End Sub


    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub


End Class