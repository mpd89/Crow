Imports daqartDLL
Imports System.Threading


Public Class ProjectMain
    Dim ProjectStatus As Integer
    Dim Loading As Boolean
    Dim Deleting As Boolean = False


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loading = True

        Me.cbx_Status.SelectedIndex = -1

        GetProjects()

        If Not Utilities.CheckPermission("PRO004") Then
            btn_ProjectDelete.Enabled = False
        End If

        Loading = False
    End Sub


    Private Sub projectArchive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ProjectArchive.Click
        MessageBox.Show("Archive feature not activated in trial.")
    End Sub


    Private Sub projectRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ProjectRestore.Click
        MessageBox.Show("Restore feature not activated in trial.")
    End Sub


    Private Sub projectDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ProjectDelete.Click
        If ProjectList.SelectedItem = runtime.selectedProject Then
            MessageBox.Show("Currently selected project may not be deleted")
            Return
        End If
        Dim deleteDialog As New deleteConfirm

        If deleteDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            Me.Cursor = Cursors.WaitCursor

            DeleteProject()
            Me.Cursor = Cursors.Default
        End If
    End Sub


    Private Sub DeleteProject()
        Deleting = True

        'delete publication
        Utilities.DropPublication(runtime.SQLInstance, Me.ProjectList.SelectedItem)

        'remove project database from replication so we can delete
        Utilities.RemoveDBReplication(runtime.SQLInstance, Me.ProjectList.SelectedItem)


        'delete publication
        Utilities.DropPublication(runtime.SQLInstance, Me.ProjectList.SelectedItem + "_Daqument001")

        'remove project database from replication so we can delete
        Utilities.RemoveDBReplication(runtime.SQLInstance, Me.ProjectList.SelectedItem + "_Daqument001")


        Dim sqlPrjUtils As DataUtils = New DataUtils("master")
        sqlPrjUtils.OpenConnection()

        Dim query As String = ""
        Dim dt_param As DataTable = sqlPrjUtils.paramDT
        Do While (ProjectDBExists(ProjectList.SelectedItem))
            query = "DROP DATABASE " + ProjectList.SelectedItem

            Try
                sqlPrjUtils.ExecuteNonQuery(query, dt_param)
            Catch
            End Try
        Loop
        Do While (ProjectDBExists(ProjectList.SelectedItem + "_Daqument001"))
            query = "DROP DATABASE " + ProjectList.SelectedItem + "_Daqument001"
            Try
                sqlPrjUtils.ExecuteNonQuery(query, dt_param)
            Catch
            End Try
        Loop
        sqlPrjUtils.CloseConnection()


        'Check to see if file exists
        'If the file does exist delete it.
        If System.IO.File.Exists(runtime.AbsolutePath + "sites\" + runtime.SiteName + "\" + Me.ProjectList.SelectedItem + ".sdf") Then
            Try
                System.IO.File.Delete(runtime.AbsolutePath + "sites\" + runtime.SiteName + "\" + Me.ProjectList.SelectedItem + ".sdf")
            Catch ex As Exception
            End Try
        End If
        If System.IO.File.Exists(runtime.AbsolutePath + "sites\" + runtime.SiteName + "\" + Me.ProjectList.SelectedItem + "_Daqument001.sdf") Then
            Try
                System.IO.File.Delete(runtime.AbsolutePath + "sites\" + runtime.SiteName + "\" + Me.ProjectList.SelectedItem + "_Daqument001.sdf")
            Catch ex As Exception
            End Try
        End If



        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()


        query = "DELETE FROM projects WHERE name =@name"
        dt_param = sqlSrvUtils.paramDT
        dt_param.Rows.Add("@name", ProjectList.SelectedItem)

        Try
            sqlSrvUtils.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            Utilities.logErrorMessage("DeleteProject" + ex.Message)
            MessageBox.Show("Failed to delete project from server_db: " + ex.Message)
        End Try

        Deleting = False
        sqlSrvUtils.CloseConnection()

        GetProjects()
        MessageBox.Show("Project was successfully deleted.")
    End Sub


    Private Function ProjectDBExists(ByVal thisProject As String)
        Dim RetValue As Boolean = False
        Dim query As String = "USE [master] SELECT * FROM sys.databases WHERE name ='" + thisProject + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.ProjectName = "master"
        sqlPrjUtils.OpenConnection()


        Try
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            sqlPrjUtils.CloseConnection()
            RetValue = dt.Rows.Count
        Catch ex As Exception
            'MessageBox.Show("Failed to delete project from server_db: " + ex.Message)
        End Try

        Return RetValue
    End Function


    Private Sub projectCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles projectCancel.Click
        Me.Dispose()
    End Sub


    Private Sub GetProjects()
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        Dim query As String = "SELECT * FROM projects ORDER BY Name ASC"
        sqlSrvUtils.OpenConnection()

        ProjectList.Items.Clear()
        Try
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
            For i As Integer = 0 To dt.Rows.Count - 1
                ProjectList.Items.Add(dt.Rows(i)(2).ToString)
            Next


        Catch ex As Exception
            MessageBox.Show("Failed to populate site list: " + ex.Message)
        Finally
        End Try
        sqlSrvUtils.CloseConnection()

        btn_ProjectDelete.Enabled = False
    End Sub


    Private Sub ProjectList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProjectList.SelectedIndexChanged
        If Not ProjectList.SelectedItem Is Nothing Then
            btn_ProjectDelete.Enabled = True
            Me.btn_Duplicate.Enabled = True
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            sqlSrvUtils.OpenConnection()

            Dim query As String = "SELECT Active FROM projects WHERE Name='" + Me.ProjectList.SelectedItem + "'"
            Dim dt As New DataTable
            dt = sqlSrvUtils.ExecuteQuery(query)
            sqlSrvUtils.CloseConnection()

            Dim StatusString As String = Nothing
            Select Case dt.Rows(0)(0)
                Case 0
                    StatusString = "Inactive"
                Case 1
                    StatusString = "Active"
                Case 2
                    StatusString = "Draft"
                Case 3
                    StatusString = "Cancelled"
                Case 4
                    StatusString = "Archive"
            End Select

            If Not dt.Rows(0)(0) < 0 Then
                Me.cbx_Status.Text = StatusString
            Else
                Me.cbx_Status.Text = "Inactive"
            End If
        End If
    End Sub


    Private Sub btn_Duplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Duplicate.Click
        Dim frm_Duplicate As New DuplicateProject(Me.ProjectList.SelectedItem)
        frm_Duplicate.ShowDialog()
        Me.Dispose()
    End Sub


    Private Sub cbx_Status_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_Status.SelectedIndexChanged
        If Loading Then Return
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()


        Dim query As String = "UPDATE projects SET Active='" + Me.cbx_Status.SelectedIndex.ToString + "' WHERE Name='" + Me.ProjectList.SelectedItem + "'"
        Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
        sqlSrvUtils.CloseConnection()
        MessageBox.Show("Project status has been changed")
    End Sub


End Class
