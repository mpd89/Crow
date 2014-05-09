Imports System.Data.SqlServerCe
Imports daqartDLL


Public Class frmUser
    Private UserID As String
    Dim SQLServer As DataUtils


    Public Sub New(ByVal _UserID As String)
        InitializeComponent()
        UserID = _UserID
    End Sub


    Private Sub frmUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLServer.CloseConnection()
    End Sub


    Private Sub frmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SQLServer = New DataUtils("server")
            SQLServer.OpenConnection()

            GetLevels()
            GetCompanies()

            Dim query As String = "select * from userInfo where MUID = '" + UserID.ToString + "'"
            Dim dt As New DataTable
            dt = SQLServer.ExecuteQuery(query)

            txt_FirstName.Text = dt.Rows(0)(6)
            txt_LastName.Text = dt.Rows(0)(8)
            txt_Initial.Text = dt.Rows(0)(7)
            txt_Number.Text = dt.Rows(0)(5)
            txt_Title.Text = dt.Rows(0)(4)
            txt_UserID.Text = dt.Rows(0)(0)
            txt_UserName.Text = dt.Rows(0)(1)
            cmb_LevelID.SelectedValue = dt.Rows(0)(11)
            cmb_CompanyId.SelectedValue = dt.Rows(0)(10)
            chk_Active.Checked = dt.Rows(0)(9)

            GetTabValues()
        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.fmUser_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub GetLevels()
        Dim dt As DataTable = Utilities.GetLevels
        Try
            cmb_LevelID.Items.Clear()
            cmb_LevelID.Items.Add("")
            cmb_LevelID.DataSource = dt
            cmb_LevelID.DisplayMember = dt.Columns(2).ToString
            cmb_LevelID.ValueMember = dt.Columns(0).ToString
        Catch ex As Exception
            MessageBox.Show("Failed to populate Level list: " + ex.Message)
        End Try
    End Sub


    Private Sub GetCompanies()
        Dim dt As DataTable = Utilities.GetCompanies
        Try
            cmb_CompanyId.Items.Clear()
            cmb_CompanyId.Items.Add("")
            cmb_CompanyId.DataSource = dt
            cmb_CompanyId.DisplayMember = dt.Columns(2).ToString
            cmb_CompanyId.ValueMember = dt.Columns(0).ToString
        Catch ex As SqlCeException
            MessageBox.Show("Failed to populate Company list: " + ex.Message)
        End Try
    End Sub


    Public Sub GetTabValues()
        Dim query As String

        Try
            ' discipline Tab
            query = "SELECT * FROM discipline WHERE Name != 'Undefined' "
            Dim dt_DisciplineAll As DataTable = SQLServer.ExecuteQuery(query)
            lstAll.DataSource = dt_DisciplineAll
            lstAll.DisplayMember = dt_DisciplineAll.Columns("Description").ToString
            lstAll.ValueMember = dt_DisciplineAll.Columns("MUID").ToString

            query = "SELECT * from discipline WHERE MUID in (SELECT DisciplineMUID FROM user_discipline where UserMUID='" + txt_UserID.Text + "')"
            Dim dt_DisciplineSelect As DataTable = SQLServer.ExecuteQuery(query)
            lstSelected.DataSource = dt_DisciplineSelect
            lstSelected.DisplayMember = dt_DisciplineSelect.Columns("Description").ToString
            lstSelected.ValueMember = dt_DisciplineSelect.Columns("MUID").ToString

            'group tab
            query = "SELECT * FROM groups WHERE Name != 'Undefined' "
            Dim dt_GroupAll As DataTable = SQLServer.ExecuteQuery(query)
            lstGrpAll.DataSource = dt_GroupAll
            lstGrpAll.DisplayMember = dt_GroupAll.Columns("Description").ToString
            lstGrpAll.ValueMember = dt_GroupAll.Columns("MUID").ToString

            query = "SELECT * from groups WHERE MUID in (SELECT GroupMUID FROM user_group where UserMUID='" + txt_UserID.Text + "')"
            Dim dt_GroupSelect As DataTable = SQLServer.ExecuteQuery(query)
            lstGrpSelect.DataSource = dt_GroupSelect
            lstGrpSelect.DisplayMember = dt_GroupSelect.Columns("Description").ToString
            lstGrpSelect.ValueMember = dt_GroupSelect.Columns("MUID").ToString

            'level
            query = "SELECT * FROM levels WHERE Name != 'Undefined' "
            Dim dt_LevelAll As DataTable = SQLServer.ExecuteQuery(query)
            lstLvlAll.DataSource = dt_LevelAll
            lstLvlAll.DisplayMember = dt_LevelAll.Columns("Description").ToString
            lstLvlAll.ValueMember = dt_LevelAll.Columns("MUID").ToString

            Dim dt_LevelSelect As New DataTable
            query = "SELECT * from levels WHERE MUID in (SELECT LevelMUID FROM user_levels where UserMUID='" + txt_UserID.Text + "')"
            dt_LevelSelect = SQLServer.ExecuteQuery(query)
            lstLvlSelect.DataSource = dt_LevelSelect
            lstLvlSelect.DisplayMember = dt_LevelSelect.Columns("Description").ToString
            lstLvlSelect.ValueMember = dt_LevelSelect.Columns("MUID").ToString

            'owner tab
            query = "SELECT * FROM owner WHERE Name != 'Undefined' "
            Dim dt_OwnerAll As DataTable = SQLServer.ExecuteQuery(query)
            lstOwnerAll.DataSource = dt_OwnerAll
            lstOwnerAll.DisplayMember = dt_OwnerAll.Columns("Description").ToString
            lstOwnerAll.ValueMember = dt_OwnerAll.Columns("MUID").ToString

            Dim dt_OwnerSelect As New DataTable
            query = "SELECT * from owner WHERE MUID in (SELECT OwnerMUID FROM user_owner where UserMUID='" + txt_UserID.Text + "')"
            dt_OwnerSelect = SQLServer.ExecuteQuery(query)
            lstOwnerSelect.DataSource = dt_OwnerSelect
            lstOwnerSelect.DisplayMember = dt_OwnerSelect.Columns("Description").ToString
            lstOwnerSelect.ValueMember = dt_OwnerSelect.Columns("MUID").ToString

        Catch ex As SqlCeException
            MessageBox.Show("Failed to populate Owner list: " + ex.Message)
        Catch ex As System.NullReferenceException
        Finally
        End Try
    End Sub


    Private Sub btnDispAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDispAdd.Click
        If lstAll.SelectedValue = Nothing Then
            MessageBox.Show("Please select a Discpline to be aded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        AddUserDiscipline()
    End Sub


    Public Sub AddUserDiscipline()
        Try
            Dim query As String = "Select * From user_discipline WHERE UserMUID ='" & txt_UserID.Text & "' AND DisciplineMUID = '" & lstAll.SelectedValue & "'"
            Dim dt As DataTable = SQLServer.ExecuteQuery(query)

            If Not dt.Rows.Count = 0 Then
                MessageBox.Show("This Discipline has already been added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            query = "INSERT INTO user_discipline (UserMUID,DisciplineMUID) VALUES (@UserMUID,@DisciplineMUID)"

            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@UserMUID", txt_UserID.Text)
            dt_param.Rows.Add("@DisciplineMUID", lstAll.SelectedValue)

            SQLServer.ExecuteNonQuery(query, dt_param)

            GetTabValues()
        Catch ex As SqlCeException
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try
    End Sub


    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If (lstSelected.SelectedValue = Nothing) Then
            MessageBox.Show("Please Select item in order to remove")
            Return
        End If

        Try
            Dim query As String
            query = "DELETE FROM user_discipline WHERE UserMUID =@UserMUID AND DisciplineMUID = @DisciplineMUID"

            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@UserMUID", txt_UserID.Text)
            dt_param.Rows.Add("@DisciplineMUID", lstSelected.SelectedValue)

            SQLServer.ExecuteNonQuery(query, dt_param)
            GetTabValues()
        Catch ex As SqlCeException
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try
    End Sub


    Private Sub btnGrpAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrpAdd.Click
        AddGroupRecord()
    End Sub


    Public Sub AddGroupRecord()
        Try
            Dim query As String
            query = "Select * From user_group WHERE UserMUID ='" & txt_UserID.Text & "' AND GroupMUID = '" & lstGrpAll.SelectedValue & "'"
            Dim dt As New DataTable
            dt = SQLServer.ExecuteQuery(query)

            If Not dt.Rows.Count = 0 Then
                MessageBox.Show("This Group has already been added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            query = "INSERT INTO user_group (UserMUID,GroupMUID) VALUES (@UserMUID,@GroupMUID)"

            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@UserMUID", txt_UserID.Text)
            dt_param.Rows.Add("@GroupMUID", lstGrpAll.SelectedValue)

            SQLServer.ExecuteNonQuery(query, dt_param)

            GetTabValues()
        Catch ex As SqlCeException
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try
    End Sub


    Private Sub btnGrpRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrpRemove.Click
        If (lstGrpSelect.SelectedValue = Nothing) Then
            MessageBox.Show("Please Select item in order to remove")
        End If

        Try
            Dim query As String
            query = "DELETE FROM user_group WHERE UserMUID =@UserMUID AND GroupMUID = @GroupMUID"

            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@UserMUID", txt_UserID.Text)
            dt_param.Rows.Add("@GroupMUID", lstGrpSelect.SelectedValue)

            SQLServer.ExecuteNonQuery(query, dt_param)

            GetTabValues()
        Catch ex As SqlCeException
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try
    End Sub


    Private Sub btnlvlAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlvlAdd.Click
        AddLevelRecord()
    End Sub


    Public Sub AddLevelRecord()
        Try
            Dim query As String
            query = "Select * From user_levels WHERE UserMUID ='" & txt_UserID.Text & "' AND LevelMUID = '" & lstLvlAll.SelectedValue & "'"
            Dim dt As New DataTable
            dt = SQLServer.ExecuteQuery(query)

            If Not dt.Rows.Count = 0 Then
                MessageBox.Show("This Level has already been added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            query = "INSERT INTO user_levels (UserMUID,LevelMUID) VALUES (@UserMUID,@LevelMUID)"

            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@UserMUID", txt_UserID.Text)
            dt_param.Rows.Add("@LevelMUID", lstLvlAll.SelectedValue)

            SQLServer.ExecuteNonQuery(query, dt_param)

            GetTabValues()
        Catch ex As SqlCeException
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try
    End Sub


    Private Sub btnlvlRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlvlRemove.Click
        If (lstLvlSelect.SelectedValue = Nothing) Then
            MessageBox.Show("Please Select item in order to remove")
            Return
        End If

        Try
            Dim query As String
            query = "DELETE FROM user_levels WHERE UserMUID=@UserMUID AND LevelMUID=@LevelMUID"

            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@UserMUID", txt_UserID.Text)
            dt_param.Rows.Add("@LevelMUID", lstLvlSelect.SelectedValue)

            SQLServer.ExecuteNonQuery(query, dt_param)

            GetTabValues()
        Catch ex As SqlCeException
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try
    End Sub


    Private Sub btnOwnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOwnAdd.Click
        AddOwnerRecord()
    End Sub


    Public Sub AddOwnerRecord()
        Try
            Dim query As String
            query = "Select * From user_owner WHERE UserMUID ='" & txt_UserID.Text & "' AND OwnerMUID = '" & lstOwnerAll.SelectedValue & "'"
            Dim dt As DataTable = SQLServer.ExecuteQuery(query)

            If Not dt.Rows.Count = 0 Then
                MessageBox.Show("This Owner has already been added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            query = "INSERT INTO user_owner (UserMUID,OwnerMUID) VALUES (@UserMUID,@OwnerMUID)"

            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@UserMUID", txt_UserID.Text)
            dt_param.Rows.Add("@OwnerMUID", lstOwnerAll.SelectedValue)

            SQLServer.ExecuteNonQuery(query, dt_param)

            GetTabValues()
        Catch ex As SqlCeException
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try
    End Sub


    Private Sub btnOwnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOwnRemove.Click
        If (lstOwnerSelect.SelectedValue = Nothing) Then
            MessageBox.Show("Please Select item in order to remove")
            Return
        End If

        Try
            Dim query As String
            query = "DELETE FROM user_owner WHERE UserMUID=@UserMUID AND OwnerMUID=@OwnerMUID"

            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@UserMUID", txt_UserID.Text)
            dt_param.Rows.Add("@OwnerMUID", lstOwnerSelect.SelectedValue)

            SQLServer.ExecuteNonQuery(query, dt_param)

            GetTabValues()
        Catch ex As Exception
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        SaveUserData()
        Me.Dispose()
    End Sub


    Private Sub btn_Apply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Apply.Click
        SaveUserData()
    End Sub


    Private Sub SaveUserData()
        Dim query As String = "UPDATE userInfo SET " & _
        " Title=@Title, " & _
        " Number=@Number," & _
        " FirstName=@FirstName, " & _
        " MI=@MI," & _
        " LastName=@LastName," & _
        " Active=@Active, " & _
        " CompanyMUID=@CompanyMUID," & _
        " LevelMUID=@LevelMUID " & _
        " WHERE MUID=@MUID"

        Dim dt_param As DataTable = SQLServer.paramDT
        dt_param.Rows.Add("@Title", txt_Title.Text)
        dt_param.Rows.Add("@Number", txt_Number.Text)
        dt_param.Rows.Add("@FirstName", txt_FirstName.Text)
        dt_param.Rows.Add("@MI", txt_Initial.Text)
        dt_param.Rows.Add("@LastName", txt_LastName.Text)
        dt_param.Rows.Add("@Active", chk_Active.Checked)
        dt_param.Rows.Add("@CompanyMUID", cmb_CompanyId.SelectedValue)
        dt_param.Rows.Add("@LevelMUID", cmb_LevelID.SelectedValue)
        dt_param.Rows.Add("@MUID", txt_UserID.Text)

        SQLServer.ExecuteNonQuery(query, dt_param)
    End Sub


    Private Sub btn_ResetPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ResetPassword.Click
        If (MessageBox.Show("Are you sure you want to reset the password for the selected user?", "Password Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then

            Dim PASSWORD_CHARS As String = "0abcdefgijkmnopqrstwxyz"
            PASSWORD_CHARS += "ABCDEFGHJKLMNPQRSTWXYZ"
            PASSWORD_CHARS += "23456789"

            Dim seed As Integer
            Dim RandomClass As New Random()

            Dim NewPassword As String = Nothing
            For i As Integer = 0 To 7
                seed = RandomClass.Next(1, PASSWORD_CHARS.Length - 1)
                NewPassword += Mid(PASSWORD_CHARS, seed, 1)
            Next

            Dim query As String = "Use [" + runtime.SiteName + "_ServerDB]  UPDATE userInfo SET UserPW = @userInfo WHERE MUID = @MUID"

            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@userInfo", "@@" + NewPassword)
            dt_param.Rows.Add("@MUID", UserID.ToString)

            SQLServer.ExecuteNonQuery(query, dt_param)

            MessageBox.Show("The temporary password for this user is '" + NewPassword + "'" + vbCr + vbCr + _
                "The user will be prompted to change on login.")

        End If
    End Sub


    Private Sub tab_Projects_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab_Projects.Enter
        Me.Cursor = Cursors.AppStarting

        Try

            RefreshProjects()

        Catch ex As Exception
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub RefreshProjects()
        Try
            Dim query As String = "SELECT projects.MUID,projects.Name" & _
                " FROM projects WHERE NOT EXISTS (SELECT * FROM user_projects " & _
                " WHERE projects.MUID = user_projects.ProjectMUID AND user_projects.UserMUID='" + Me.UserID + "') " & _
                " ORDER BY projects.Name ASC"
            Dim dt_Projects As New DataTable
            dt_Projects = SQLServer.ExecuteQuery(query)

            Me.lbx_ProjectList.DataSource = dt_Projects
            Me.lbx_ProjectList.DisplayMember = dt_Projects.Columns("Name").ToString
            Me.lbx_ProjectList.ValueMember = dt_Projects.Columns("MUID").ToString


            query = "SELECT projects.MUID,projects.Name" & _
                " FROM projects,user_projects WHERE projects.MUID = user_projects.ProjectMUID " & _
                " AND user_projects.UserMUID='" + Me.UserID + "'" & _
                " ORDER BY projects.Name ASC"
            Dim dt_UserProjects As New DataTable
            dt_UserProjects = SQLServer.ExecuteQuery(query)

            Me.lbx_SelectedProjects.DataSource = dt_UserProjects
            Me.lbx_SelectedProjects.DisplayMember = dt_UserProjects.Columns("Name").ToString
            Me.lbx_SelectedProjects.ValueMember = dt_UserProjects.Columns("MUID").ToString



        Catch ex As Exception
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try
    End Sub


    Private Sub btn_SelectProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SelectProject.Click
        Try
            Dim query As String = "INSERT INTO user_projects (UserMUID,ProjectMUID) VALUES (@UserMUID,@ProjectMUID)"
            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@UserMUID", txt_UserID.Text)
            dt_param.Rows.Add("@ProjectMUID", Me.lbx_ProjectList.SelectedValue)
            SQLServer.ExecuteNonQuery(query, dt_param)

            RefreshProjects()
        Catch ex As Exception
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try
    End Sub


    Private Sub btn_RemoveProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RemoveProject.Click
        Try
            Dim query As String
            query = "DELETE FROM user_projects WHERE UserMUID=@UserMUID AND ProjectMUID=@ProjectMUID"

            Dim dt_param As DataTable = SQLServer.paramDT
            dt_param.Rows.Add("@UserMUID", txt_UserID.Text)
            dt_param.Rows.Add("@ProjectMUID", Me.lbx_SelectedProjects.SelectedValue)

            SQLServer.ExecuteNonQuery(query, dt_param)

            RefreshProjects()
        Catch ex As Exception
            MessageBox.Show("Failed to connect to database " + ex.Message)
        End Try
    End Sub
End Class