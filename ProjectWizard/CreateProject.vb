Imports System
Imports System.Windows.Forms
Imports daqartDLL


Public Class CreateProject
    Dim SQLServer As DataUtils
    Dim SQLProject As DataUtils


    Private Sub CreateProject_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLServer.CloseConnection()
    End Sub


    Private Sub CreateProject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SQLServer = New DataUtils("server")
        SQLServer.OpenConnection()
    End Sub


    Private Sub ProjectCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectCancel.Click
        Me.Close()
    End Sub


    Private Sub ProjectName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ProjectName.KeyUp
        If e.KeyCode = Keys.Space Then
            Me.ProjectName.Text.Replace(" ", "_")
        End If
    End Sub


    Private Sub ProjectName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProjectName.TextChanged
        CheckBlanks()

        Dim newString As String = Nothing
        If Me.ProjectName.Text.Length = 0 Then Return

        Dim test As String = Me.ProjectName.Text.Clone

        test = test.Replace(" ", "_")

        If Not Char.IsLetter(Me.ProjectName.Text(0)) Then
            MessageBox.Show("Project Name must begin with a letter.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.ProjectName.Clear()
            'myString = ""
        End If

        For i As Integer = 0 To test.Length - 1
            If Char.IsLetterOrDigit(Me.ProjectName.Text(i)) Then
                newString = newString + test(i)
            ElseIf test(i) = "_" Then
                newString = newString + test(i)
            End If
        Next

        Me.ProjectName.Text = newString
        Me.ProjectName.SelectionStart = Me.ProjectName.TextLength
    End Sub


    Private Sub ProjectDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProjectDescription.TextChanged
        CheckBlanks()
    End Sub


    Private Sub ProjectLocation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProjectLocation.TextChanged
        CheckBlanks()
    End Sub


    Private Sub CheckBlanks()
        Dim isEmpty As Boolean = True

        If (ProjectName.Text <> "" And ProjectDescription.Text <> "" And ProjectLocation.Text <> "") Then
            isEmpty = False
        End If

        If (isEmpty = False) Then
            ProjectNext1.Enabled = True
        Else
            ProjectNext1.Enabled = False
        End If

    End Sub


    Private Sub ProjectNext1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectNext1.Click
        If CheckProjectName() = False Then

            Dim query As String = "INSERT INTO projects (MUID,TS,Name,Description,Location,Active) VALUES (" & _
            " @MUID," & _
            " @TS," & _
            " @Name," & _
            " @Description," & _
            " @Location," & _
            " @Active)"

            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("server", "projects"))
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@Name", ProjectName.Text)
            dt_param.Rows.Add("@Description", ProjectDescription.Text)
            dt_param.Rows.Add("@Location", ProjectLocation.Text)
            dt_param.Rows.Add("@Active", "0")

            Try
                SQLServer.ExecuteNonQuery(query, dt_param)
            Catch ex As Exception
                MessageBox.Show("Failed to add project to Projects table: " + ex.Message)
            End Try

            ProjectPanel1.Visible = False
            ProjectPanel2.Top = 0
            ProjectPanel2.Left = 0
            ProjectPanel2.Visible = True

            'BuildProjectDB()
            ExecutedSQL.Items.Add("Creating Project Database.")
            ExecutedSQL.Refresh()
            CreateProjectDB()
            ExecutedSQL.SetItemChecked(0, True)
            ExecutedSQL.Refresh()


            'Create Project Tables
            ExecutedSQL.Items.Add("Creating Project Tables.")
            ExecutedSQL.Refresh()
            CreateProjectDBTables()
            ExecutedSQL.SetItemChecked(1, True)
            ExecutedSQL.Refresh()


            'Publish the Project DB
            ExecutedSQL.Items.Add("Publishing Project Database.")
            ExecutedSQL.Refresh()
            PublishProjectDB()
            ExecutedSQL.SetItemChecked(2, True)
            ExecutedSQL.Refresh()


            'Add Daqart SQL Agent Permissions
            ExecutedSQL.Items.Add("Adding Snapshot Agent to Project Database.")
            ExecutedSQL.Refresh()
            Utilities.addProjectAgent(runtime.SQLInstance, ProjectName.Text)
            Utilities.addSQLAgent(runtime.SQLInstance, ProjectName.Text)
            ExecutedSQL.SetItemChecked(3, True)
            ExecutedSQL.Refresh()


            'Start ProjectDB Snapshot
            ExecutedSQL.Items.Add("Creating Project Snapshot.")
            ExecutedSQL.Refresh()
            Utilities.StartProjectSnapshot(runtime.SQLInstance, ProjectName.Text)
            ExecutedSQL.SetItemChecked(4, True)
            ExecutedSQL.Refresh()


            'Create Subscription and Synchronize
            ExecutedSQL.Items.Add("Creating Local Subscription.")
            ExecutedSQL.Refresh()
            Utilities.SubscribeProjectDB(ProjectName.Text)
            ExecutedSQL.SetItemChecked(5, True)
            ExecutedSQL.Refresh()


            'Build DocumentDB()
            ExecutedSQL.Items.Add("Creating Document Database.")
            ExecutedSQL.Refresh()
            CreateDaqument001()
            ExecutedSQL.SetItemChecked(6, True)
            ExecutedSQL.Refresh()


            'Create Document Tables
            ExecutedSQL.Items.Add("Creating Document Tables.")
            ExecutedSQL.Refresh()
            CreateDaqument001Tables()
            ExecutedSQL.SetItemChecked(7, True)
            ExecutedSQL.Refresh()


            'Publish the Document DB
            ExecutedSQL.Items.Add("Publishing Document Database.")
            ExecutedSQL.Refresh()
            PublishDaqument001()
            ExecutedSQL.SetItemChecked(8, True)
            ExecutedSQL.Refresh()


            'Add Document SQL Agent Permissions
            ExecutedSQL.Items.Add("Adding Snapshot Agent to Document Database.")
            ExecutedSQL.Refresh()
            Utilities.addProjectAgent(runtime.SQLInstance, ProjectName.Text + "_Daqument001")
            Utilities.addSQLAgent(runtime.SQLInstance, ProjectName.Text + "_Daqument001")
            ExecutedSQL.SetItemChecked(9, True)
            ExecutedSQL.Refresh()


            'Start Document Snapshot
            ExecutedSQL.Items.Add("Creating Document Snapshot.")
            ExecutedSQL.Refresh()
            Utilities.StartProjectSnapshot(runtime.SQLInstance, ProjectName.Text + "_Daqument001")
            ExecutedSQL.SetItemChecked(10, True)
            ExecutedSQL.Refresh()


            'Create Document Subscription and Synchronize
            ExecutedSQL.Items.Add("Creating Document Subscription.")
            ExecutedSQL.Refresh()
            Utilities.SubscribeProjectDB(ProjectName.Text + "_Daqument001")
            ExecutedSQL.SetItemChecked(11, True)
            ExecutedSQL.Refresh()


            runtime.selectedProject = ProjectName.Text
            runtime.selectedProjectID = Utilities.GetProjectID(ProjectName.Text)

            runtime.SQLProject = New DataUtilsGlobal("project")
            runtime.SQLProject.OpenConnection()

            'Goto next step in wizard
            NextStep()
        Else
            MessageBox.Show("The project you have entered """ + ProjectName.Text + """ is already in use. ")
        End If
    End Sub


    Private Function CheckProjectName()
        Dim query As String = "SELECT * FROM projects WHERE Name='" + ProjectName.Text + "'"
        Dim dt As DataTable
        Dim hasExisting As Boolean = False

        Try
            dt = SQLServer.ExecuteQuery(query)

            If dt.Rows.Count > 0 Then
                hasExisting = True
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to verify new project name: " + ex.Message)
        End Try

        Return hasExisting
    End Function


    Private Function RunQuery(ByVal query As String, ByVal ErrString As String)
        Dim value As Boolean = False

        Try
            SQLServer.ExecuteQuery(query)
        Catch ex As Exception
            MessageBox.Show(ErrString + ": " + ex.Message)
        End Try

        Return value
    End Function


    Private Sub CreateProjectDB()
        Dim query As String
        Dim CustomErr As String
        ProjectName.Text.ToLower()
        ProjectName.Text.Replace(" ", "_")

        query = "USE [master]"
        CustomErr = ""
        RunQuery(query, CustomErr)

        query = "CREATE DATABASE " + ProjectName.Text
        CustomErr = ""
        RunQuery(query, CustomErr)
    End Sub


    Private Sub CreateProjectDBTables()
        Dim query As String = Nothing
        Dim SQLMaster As DataUtils = New DataUtils("master")
        SQLMaster.OpenConnection()

        query = "USE [" + ProjectName.Text + "] " + My.Resources.CreateProjectTables1.ToString
        query = query.Replace("!!MID!!", idUtils.GetMID)
        query = query.Replace("!!NOW!!", Now())

        Dim dt_param As DataTable = SQLServer.paramDT

        Try
            SQLMaster.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        End Try

        SQLMaster.CloseConnection()
    End Sub


    Private Function PublishProjectDB()
        Dim value As Boolean = False
        Dim query As String = Nothing
        Dim SQLMaster As DataUtils = New DataUtils("master")
        SQLMaster.OpenConnection()


        Try
            query = My.Resources.ProjectPublication.ToString
            query = query.Replace("!!ProjectName!!", ProjectName.Text)
            query = query.Replace("!!MachineName!!", runtime.SQLMachine)
            query = query.Replace("!!ServerInstance!!", runtime.SQLInstance)

            Dim dt_param As DataTable = SQLServer.paramDT
            SQLMaster.ExecuteNonQuery(query, dt_param)

            value = True
        Catch ex As Exception
            Utilities.logErrorMessage("ProjectWizard.CreateProject.PublishProjectDB-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

        SQLMaster.CloseConnection()

        Return value
    End Function


    Private Sub CreateDaqument001()
        Dim query As String
        Dim CustomErr As String
        ProjectName.Text.ToLower()
        ProjectName.Text.Replace(" ", "_")

        query = "USE [master]"
        CustomErr = ""
        RunQuery(query, CustomErr)

        query = "CREATE DATABASE " + ProjectName.Text + "_Daqument001"
        CustomErr = ""
        RunQuery(query, CustomErr)
    End Sub


    Private Sub CreateDaqument001Tables()
        Dim query As String = Nothing
        Dim SQLMaster As DataUtils = New DataUtils("master")
        SQLMaster.OpenConnection()

        query = "USE [" + ProjectName.Text + "_Daqument001] " + My.Resources.createDaqument001Tables.ToString
        query = query.Replace("!!ProjectName!!", ProjectName.Text)
        query = query.Replace("!!MID!!", idUtils.GetMID)
        query = query.Replace("!!NOW!!", Now())
        Dim dt_param As DataTable = SQLServer.paramDT

        Try
            SQLMaster.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        End Try

        SQLMaster.CloseConnection()
    End Sub


    Private Function PublishDaqument001()
        Dim value As Boolean = False
        Dim query As String = Nothing
        Dim SQLMaster As DataUtils = New DataUtils("master")
        SQLMaster.OpenConnection()

        Try
            query = My.Resources.PublishDaqument001.ToString
            query = query.Replace("!!PUB!!", runtime.SQLMachine + "\" + runtime.SQLInstance)
            query = query.Replace("!!ProjectName!!", ProjectName.Text)

            Dim dt_param As DataTable = SQLServer.paramDT

            SQLMaster.ExecuteNonQuery(query, dt_param)

            value = True
        Catch ex As Exception
            Utilities.logErrorMessage("ProjectWizard.CreateProject.PublishProjectDB-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

        SQLMaster.CloseConnection()

        Return value
    End Function


    Private Sub NextStep()
        daqartDLL.runtime.selectedProject = ProjectName.Text
        wizard1.LabelStep1.ForeColor = Color.Black
        wizard1.LabelStep1.Cursor = Cursors.Arrow
        wizard1.LabelStep2.ForeColor = Color.Blue
        wizard1.LabelStep2.Cursor = Cursors.Hand
        wizard1.LabelStep2.Enabled = True
        wizard1.StatusStep1.Image = My.Resources.Resources.icon_ok
        wizard1.NextStep.Top = wizard1.NextStep.Top + 27
        wizard1.WizardStatus = 1

        MessageBox.Show("New Project Database Built Successfully!!")
        Me.Dispose()
    End Sub

End Class