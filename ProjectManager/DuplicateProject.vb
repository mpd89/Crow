Imports daqartDLL
Imports System.Threading


Public Class DuplicateProject
    Dim SourceProject As String
    Dim DestProject As String
    Dim dt_requirements As New DataTable
    Dim Working As Boolean

    Dim SQLPRojectSrc As DataUtils
    Dim SQLPRojectDest As DataUtils



    Public Sub New(ByVal _SourceProject As String)
        InitializeComponent()

        SourceProject = _SourceProject

        SQLPRojectSrc = New DataUtils("project")
        SQLPRojectSrc.OpenConnection()


    End Sub


    Private Sub DuplicateProject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl_Project.Text = SourceProject
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub txt_ProjectName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_ProjectName.TextChanged
        If Me.tbx_ProjectName.Text = "" Or Me.tbx_ProjectDescription.Text = "" Or Me.tbx_ProjectLocation.Text = "" Then
            Me.btn_Duplicate.Enabled = False
        Else
            Me.btn_Duplicate.Enabled = True
        End If
    End Sub


    Private Sub txt_ProjectLocation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_ProjectLocation.TextChanged
        If Me.tbx_ProjectName.Text = "" Or Me.tbx_ProjectDescription.Text = "" Or Me.tbx_ProjectLocation.Text = "" Then
            Me.btn_Duplicate.Enabled = False
        Else
            Me.btn_Duplicate.Enabled = True
        End If
    End Sub


    Private Sub txt_ProjectDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_ProjectDescription.TextChanged
        If Me.tbx_ProjectName.Text = "" Or Me.tbx_ProjectDescription.Text = "" Or Me.tbx_ProjectLocation.Text = "" Then
            Me.btn_Duplicate.Enabled = False
        Else
            Me.btn_Duplicate.Enabled = True
        End If
    End Sub


    Private Sub btn_Duplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Duplicate.Click

        Me.Cursor = Cursors.WaitCursor

        Dim frm_Syncing As New CommonForms.Sync
        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Creating new project data base..."
        frm_Syncing.Show()
        frm_Syncing.Refresh()
        CreateNewProject()

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Creating new project data structure..."
        frm_Syncing.Refresh()
        CreateProjectDB()

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Creating new project data tables..."
        frm_Syncing.Refresh()
        CreateProjectDBTables()

        DestProject = tbx_ProjectName.Text

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Publishing Project..."
        frm_Syncing.Refresh()
        PublishProjectDB()

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Adding Project SQL Agent..."
        frm_Syncing.Refresh()
        Utilities.addProjectAgent(runtime.SQLInstance, tbx_ProjectName.Text)
        Utilities.addSQLAgent(runtime.SQLInstance, tbx_ProjectName.Text)
        Utilities.addProjectAgent(runtime.SQLInstance, tbx_ProjectName.Text + "_Daqument001")
        Utilities.addSQLAgent(runtime.SQLInstance, tbx_ProjectName.Text + "_Daqument001")

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Generating Data Snapshot..."
        frm_Syncing.Refresh()
        Utilities.StartProjectSnapshot(runtime.SQLInstance, tbx_ProjectName.Text)
        Utilities.StartProjectSnapshot(runtime.SQLInstance, tbx_ProjectName.Text + "_Daqument001")

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim query As String = " SELECT * FROM requirements Order By MUID Asc"
        sqlPrjUtils.OpenConnection()
        dt_requirements = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Getting Equipment Types..."
        frm_Syncing.Refresh()
        GetEquipmentTypes()

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Getting Sign Off Configuration..."
        frm_Syncing.Refresh()
        GetFormsConfig()

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Getting System Mnemonics..."
        frm_Syncing.Refresh()
        GetSystemMnemonics()

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Getting System Numbers..."
        frm_Syncing.Refresh()
        GetSystemNumbers()

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Getting Project Forms..."
        frm_Syncing.Refresh()
        GetForms()

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Getting Project Form Requirements..."
        frm_Syncing.Refresh()
        GetRequirements()

        frm_Syncing.Text = "Creating New Project"
        frm_Syncing.Label1.Text = "Synchronizing local data store..."
        frm_Syncing.Refresh()
        Utilities.SubscribeProjectDB(tbx_ProjectName.Text)
        Utilities.SubscribeProjectDB(tbx_ProjectName.Text + "_Daqument001")

        frm_Syncing.Dispose()
        Me.Cursor = Cursors.Arrow

        MessageBox.Show("Project successfully duplicated.")
        Me.Dispose()
    End Sub


    Private Sub CreateNewProject()
        Working = True

        Dim query As String
        query = "INSERT INTO projects (MUID,TS,Name,Description,Location,Active) VALUES (" & _
            "@MUID," & _
            "@TS," & _
            "@Name," & _
            "@Description," & _
            "@Location," & _
            "@Active)"

        Try
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            Dim dt_param As DataTable = sqlSrvUtils.paramDT
            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("server", "projects"))
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@Name", tbx_ProjectName.Text)
            dt_param.Rows.Add("@Description", tbx_ProjectDescription.Text)
            dt_param.Rows.Add("@Location", tbx_ProjectLocation.Text)
            dt_param.Rows.Add("@Active", "0")

            sqlSrvUtils.OpenConnection()
            sqlSrvUtils.ExecuteNonQuery(query, dt_param)
            sqlSrvUtils.CloseConnection()

        Catch ex As Exception
            MessageBox.Show("Failed to add project to Projects table: " + ex.Message)
        End Try

        Working = False
    End Sub


    Private Sub CreateProjectDB()
        Dim query As String
        tbx_ProjectName.Text.ToLower()
        tbx_ProjectName.Text.Replace(" ", "_")

        Try
            Dim sqlMaster As DataUtils = New DataUtils("master")
            sqlMaster.OpenConnection()
            query = "USE [master] CREATE DATABASE " + tbx_ProjectName.Text
            sqlMaster.ExecuteQuery(query)

            query = "USE [master] CREATE DATABASE " + tbx_ProjectName.Text + "_Daqument001"
            sqlMaster.ExecuteQuery(query)

            sqlMaster.CloseConnection()
        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

    End Sub


    Private Sub CreateProjectDBTables()

        Try
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            Dim sContents As String = ProjectWizard.WizardUtils.ProjectTables
            sContents = sContents.Replace("!!MID!!", runtime.MID)
            sContents = sContents.Replace("!!NOW!!", Now())

            sqlPrjUtils.ProjectName = tbx_ProjectName.Text
            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(sContents)
            sqlPrjUtils.CloseConnection()


            Dim DaqumentUtils As DataUtils = New DataUtils("Daqument001")
            sContents = ProjectWizard.WizardUtils.Daqument001Tables
            DaqumentUtils.ProjectName = tbx_ProjectName.Text
            DaqumentUtils.OpenConnection()
            dt = DaqumentUtils.ExecuteQuery(sContents)
            DaqumentUtils.CloseConnection()

        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try
    End Sub


    Private Function PublishProjectDB()
        Dim value As Boolean = False
        Dim sContents As String = ProjectWizard.WizardUtils.ProjectPublish
        Dim sErr As String = Nothing
        Try
            sContents = sContents.Replace("!!ProjectName!!", tbx_ProjectName.Text)
            sContents = sContents.Replace("!!MachineName!!", runtime.SQLMachine)
            sContents = sContents.Replace("!!ServerInstance!!", runtime.SQLInstance)

            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            sqlPrjUtils.ProjectName = tbx_ProjectName.Text
            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(sContents)
            sqlPrjUtils.CloseConnection()


            sContents = ProjectWizard.WizardUtils.Daqument001Publish
            sContents = sContents.Replace("!!ProjectName!!", tbx_ProjectName.Text)
            sContents = sContents.Replace("!!MachineName!!", runtime.SQLMachine)
            sContents = sContents.Replace("!!ServerInstance!!", runtime.SQLInstance)
            sContents = sContents.Replace("!!PUB!!", runtime.SQLMachine + "\" + runtime.SQLInstance)

            Dim DaqumentUtils As DataUtils = New DataUtils("Daqument001")
            DaqumentUtils.ProjectName = tbx_ProjectName.Text
            DaqumentUtils.OpenConnection()
            dt = sqlPrjUtils.ExecuteQuery(sContents)
            DaqumentUtils.CloseConnection()

        Catch ex As Exception
            Utilities.logErrorMessage("ProjectWizard.CreateProject.PublishProjectDB-" + ex.Message)
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

        Return value
    End Function


    Private Sub GetRequirements()
        Dim query As String
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        sqlPrjUtils.ProjectName = Me.tbx_ProjectName.Text
        Try
            'For i As Integer = 0 To dt_requirements.Rows.Count - 1
            'query = " INSERT INTO requirements " & _
            '        "(MUID,TS,OwnerMUID,TypeMUID,FormMUID,ManHours,MEManHours,Aux05,Aux04,Aux03,Aux02,Aux01) VALUES (" & _
            '        "@MUID," & _
            '        "@TS," & _
            '        "@OwnerMUID," & _
            '        "@TypeMUID," & _
            '        "@FormMUID," & _
            '        "@ManHours," & _
            '        "@MEManHours," & _
            '        "@Aux05," & _
            '        "@Aux04," & _
            '        "@Aux03," & _
            '        "@Aux02," & _
            '        "@Aux01)"

            'Dim dt_param As DataTable = sqlPrjUtils.paramDT
            'dt_param.Rows.Add("@MUID", dt_requirements.Rows(i)(0).ToString)
            'dt_param.Rows.Add("@TS", Now())
            'dt_param.Rows.Add("@OwnerMUID", dt_requirements.Rows(i)(2).ToString)
            'dt_param.Rows.Add("@TypeMUID", dt_requirements.Rows(i)(3).ToString)
            'dt_param.Rows.Add("@FormMUID", dt_requirements.Rows(i)(4).ToString)
            'dt_param.Rows.Add("@ManHours", dt_requirements.Rows(i)(5).ToString)
            'dt_param.Rows.Add("@MEManHours", dt_requirements.Rows(i)(6).ToString)
            'dt_param.Rows.Add("@Aux05", dt_requirements.Rows(i)(7).ToString)
            'dt_param.Rows.Add("@Aux04", dt_requirements.Rows(i)(8).ToString)
            'dt_param.Rows.Add("@Aux03", dt_requirements.Rows(i)(9).ToString)
            'dt_param.Rows.Add("@Aux02", dt_requirements.Rows(i)(10).ToString)
            'dt_param.Rows.Add("@Aux01", dt_requirements.Rows(i)(11).ToString)
            'Next
            query = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.requirements  SELECT * FROM " + Me.SourceProject + ".dbo.requirements"
            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)

        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub GetEquipmentTypes()
        Dim sqlPrjUtils As DataUtils = New DataUtils("master")
        sqlPrjUtils.ProjectName = Me.lbl_Project.Text
        sqlPrjUtils.OpenConnection()

        Try
            Dim query As String = ""
            Dim dt_param As DataTable = sqlPrjUtils.paramDT

            query = "USE [master] DELETE FROM " + Me.DestProject + ".dbo.equipment_type "
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)

            query = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.equipment_type  SELECT * FROM " + Me.SourceProject + ".dbo.equipment_type WHERE TypeName != 'UDF'"
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)

            query = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.aux_fieldmap  SELECT * FROM " + Me.SourceProject + ".dbo.aux_fieldmap"
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)

        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub GetFormsConfig()
        Dim sqlPrjUtils As DataUtils = New DataUtils("master")
        sqlPrjUtils.OpenConnection()
        Try
            Dim query As String = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.forms_config  SELECT * FROM " + Me.SourceProject + ".dbo.forms_config"
            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub GetSystemMnemonics()
        Dim sqlPrjUtils As DataUtils = New DataUtils("master")
        sqlPrjUtils.OpenConnection()
        Try
            Dim query As String = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.system_mnemonic  SELECT * FROM " + Me.SourceProject + ".dbo.system_mnemonic"
            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub GetSystemNumbers()
        Dim sqlPrjUtils As DataUtils = New DataUtils("master")
        sqlPrjUtils.OpenConnection()

        Try
            Dim query As String = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.system_number  SELECT * FROM " + Me.SourceProject + ".dbo.system_number"
            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)

        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub GetForms()
        Dim sqlPrjUtils As DataUtils = New DataUtils("master")
        sqlPrjUtils.OpenConnection()

        Dim query As String = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.forms  SELECT * FROM " + Me.SourceProject + ".dbo.forms"
        Dim dt_param As DataTable = sqlPrjUtils.paramDT
        sqlPrjUtils.ExecuteNonQuery(query, dt_param)


        GetFormImage()

        GetAuxFormInfo()

        GetAuxSubFormsFields()

        GetAuxSubFormsInfo()

        GetFormStorage()

        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub GetFormImage()
        Dim sqlPrjUtils As DataUtils = New DataUtils("master")
        sqlPrjUtils.OpenConnection()

        Try
            Dim query As String = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.forms_image  SELECT * FROM " + Me.SourceProject + ".dbo.forms_image"
            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub GetAuxFormInfo()
        Dim sqlPrjUtils As DataUtils = New DataUtils("master")
        sqlPrjUtils.OpenConnection()

        Try
            Dim query As String = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.aux_forms_info  SELECT * FROM " + Me.SourceProject + ".dbo.aux_forms_info"
            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub GetAuxSubFormsFields()
        Dim sqlPrjUtils As DataUtils = New DataUtils("master")
        sqlPrjUtils.OpenConnection()

        Try
            Dim query As String = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.aux_subforms_fields  SELECT * FROM " + Me.SourceProject + ".dbo.aux_subforms_fields"
            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub GetAuxSubFormsInfo()
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Try
            Dim query As String = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.aux_subforms_info  SELECT * FROM " + Me.SourceProject + ".dbo.aux_subforms_info"
            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub GetFormStorage()
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Try
            Dim query As String = "USE [master] INSERT INTO " + Me.DestProject + ".dbo.forms_storage  SELECT * FROM " + Me.SourceProject + ".dbo.forms_storage"
            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Error creating duplicate project: " + ex.Message)
        End Try

        sqlPrjUtils.CloseConnection()
    End Sub


End Class