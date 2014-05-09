Imports daqartDLL

Public Class AddUser

    Public Shared UserAdded As String
    Dim UserID As String


    Private Sub AddUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.GetLevels()
        Me.GetCompanies()
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Try
            GenerateUID()

            If TestUID(UserID) = 0 Then

                Dim query As String = "INSERT INTO userInfo (" & _
                    " MUID, UserName, TS, UserPW, Title, Number," & _
                    " FirstName, MI, LastName, CompanyMUID, LevelMUID, Active) VALUES (" & _
                    " @MUID," & _
                    " @UserName," & _
                    " @TS," & _
                    " @UserPW," & _
                    " @Title," & _
                    " @Number," & _
                    " @FirstName," & _
                    " @MI," & _
                    " @LastName," & _
                    " @CompanyMUID," & _
                    " @LevelMUID," & _
                    " @Active)"

                Dim dt_param As DataTable = runtime.SQLServer.paramDT
                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("server", "userInfo"))
                dt_param.Rows.Add("@UserName", Me.UserID)
                dt_param.Rows.Add("@TS", Now())
                dt_param.Rows.Add("@UserPW", Me.GeneratePW)
                dt_param.Rows.Add("@Title", Me.txt_Title.Text)
                dt_param.Rows.Add("@Number", Me.txt_Number.Text)
                dt_param.Rows.Add("@FirstName", Me.tbx_FirstName.Text)
                dt_param.Rows.Add("@MI", Me.tbx_Initial.Text)
                dt_param.Rows.Add("@LastName", Me.tbx_LastName.Text)
                dt_param.Rows.Add("@CompanyMUID", Me.cbx_CompanyId.SelectedValue.ToString)
                dt_param.Rows.Add("@LevelMUID", Me.cbx_LevelID.SelectedValue.ToString)
                dt_param.Rows.Add("@Active", False)

                runtime.SQLServer.ExecuteNonQuery(query, dt_param)

                query = "SELECT MUID FROM userInfo WHERE UserName = '" + Me.UserID + "'"
                Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

                If dt.Rows.Count > 0 Then
                    UserAdded = dt.Rows(0)(0)
                Else
                    UserAdded = "0"
                End If

                Me.Dispose()

            Else
                MessageBox.Show("User ID already exists")
            End If
        Catch ex As Exception
            MessageBox.Show("Error  occurred while performing this operation" + ex.Message)
            Me.Dispose()
        End Try
    End Sub

    Private Sub CheckBlanks()
        Dim IsEmpty As Boolean = False

        If Me.tbx_FirstName.Text = "" Then
            IsEmpty = True
        End If

        If Me.tbx_LastName.Text = "" Then
            IsEmpty = True
        End If

        If Me.cbx_LevelID.Text = "" Then
            IsEmpty = True
        End If

        If cbx_CompanyId.Text = "" Then
            IsEmpty = True
        End If

        If txt_Number.Text = "" Then
            IsEmpty = True
        End If

        If txt_Title.Text = "" Then
            IsEmpty = True
        End If


        If Not IsEmpty Then
            Me.btn_OK.Enabled = True
        End If
    End Sub

    Private Sub GenerateUID()
        Dim First As String = Nothing
        Dim Middle As String = Nothing
        Dim Last As String = Nothing

        If Not Me.tbx_FirstName.Text = "" Then
            First = Me.tbx_FirstName.Text.Substring(0, 1)
        End If
        If Not Me.tbx_Initial.Text = "" Then
            Middle = Me.tbx_Initial.Text.Substring(0, 1)
        End If
        If Not Me.tbx_LastName.Text = "" Then
            Last = Me.tbx_LastName.Text.Substring(0, 1)
        End If


        UserID = First + Middle + Last
        UserID = UserID.ToLower

        Dim UserSequence As Integer = TestUID(UserID) + 1
        If Not TestUID(UserID) = 0 Then
            UserID += UserSequence.ToString
        End If

    End Sub

    Private Function TestUID(ByVal UserID As String)
        Dim query As String = "SELECT * FROM userInfo WHERE UserName = '" & UserID & "'"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows.Count
        End If
    End Function

    Private Function GeneratePW() As String
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

        Return NewPassword
    End Function

    Private Sub GetLevels()
        Try
            Dim dt As DataTable
            dt = Utilities.GetLevels
            cbx_LevelID.Items.Clear()
            cbx_LevelID.Items.Add("")
            cbx_LevelID.DataSource = dt
            cbx_LevelID.DisplayMember = dt.Columns(2).ToString
            cbx_LevelID.ValueMember = dt.Columns(0).ToString
        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.AddUser.GetLevels-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetCompanies()
        Try
            Dim dt As DataTable
            dt = Utilities.GetCompanies
            cbx_CompanyId.Items.Clear()
            cbx_CompanyId.Items.Add("")
            cbx_CompanyId.DataSource = dt
            cbx_CompanyId.DisplayMember = dt.Columns(2).ToString
            cbx_CompanyId.ValueMember = dt.Columns(0).ToString
        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.AddUser.GetCompanies-" + ex.Message)
            MessageBox.Show("Failed to populate Company list: " + ex.Message)
        End Try
    End Sub

    Private Sub tbx_FirstName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_FirstName.TextChanged
        CheckBlanks()
    End Sub

    Private Sub tbx_Initial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_Initial.TextChanged
        CheckBlanks()
    End Sub

    Private Sub tbx_LastName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_LastName.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txt_Number_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Number.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txt_Title_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Title.TextChanged
        CheckBlanks()
    End Sub

    Private Sub cbx_CompanyId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_CompanyId.SelectedIndexChanged
        CheckBlanks()
    End Sub

    Private Sub cbx_LevelID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_LevelID.SelectedIndexChanged
        CheckBlanks()
    End Sub

End Class