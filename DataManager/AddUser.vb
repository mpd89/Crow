Imports daqartDLL


Public Class AddUser
    Dim dt As New DataTable
    Dim SQLServer As DataUtils


    Private Sub AddUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLServer.CloseConnection()
    End Sub


    Private Sub AddUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SQLServer = New DataUtils("server")
            SQLServer.OpenConnection()

            GetLevels()
            GetCompanies()
        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.AddUser_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub GetLevels()
        Try
            dt = Utilities.GetLevels
            cmb_LevelID.Items.Clear()
            cmb_LevelID.Items.Add("")
            cmb_LevelID.DataSource = dt
            cmb_LevelID.DisplayMember = dt.Columns(2).ToString
            cmb_LevelID.ValueMember = dt.Columns(0).ToString
        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.AddUser.GetLevels-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub GetCompanies()
        Try
            dt = Utilities.GetCompanies
            cmb_CompanyId.Items.Clear()
            cmb_CompanyId.Items.Add("")
            cmb_CompanyId.DataSource = dt
            cmb_CompanyId.DisplayMember = dt.Columns(2).ToString
            cmb_CompanyId.ValueMember = dt.Columns(0).ToString
        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.AddUser.GetCompanies-" + ex.Message)
            MessageBox.Show("Failed to populate Company list: " + ex.Message)
        End Try
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        Dim newnode As New TreeNode
        Try
            If (validatecontrols()) Then
                If TestUID(txt_UserID.Text) = 0 Then


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

                    Dim dt_param As DataTable = SQLServer.paramDT
                    dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("server", "userInfo"))
                    dt_param.Rows.Add("@UserName", Me.txt_UserID.Text)
                    dt_param.Rows.Add("@TS", Now())
                    dt_param.Rows.Add("@UserPW", Me.txt_Password.Text)
                    dt_param.Rows.Add("@Title", Me.txt_Title.Text)
                    dt_param.Rows.Add("@Number", Me.txt_Number.Text)
                    dt_param.Rows.Add("@FirstName", Me.txt_FirstName.Text)
                    dt_param.Rows.Add("@MI", Me.txt_Initial.Text)
                    dt_param.Rows.Add("@LastName", Me.txt_LastName.Text)
                    dt_param.Rows.Add("@CompanyMUID", cmb_CompanyId.SelectedValue.ToString)
                    dt_param.Rows.Add("@LevelMUID", Me.cmb_LevelID.SelectedValue.ToString)
                    dt_param.Rows.Add("@Active", Me.chk_Active.Checked.ToString)

                    SQLServer.ExecuteNonQuery(query, dt_param)

                    'MessageBox.Show("Data has been saved")
                    newnode.Text = txt_UserID.Text
                    newnode.Tag = txt_UserID.Text
                    'DataManagerMain.trvComplete.Nodes("ServerDB").Nodes(DataManagerMain.eStatus.User).Nodes.Add(newnode)
                    'DataManagerMain.RefreshTree()
                Else
                    MessageBox.Show("User ID already exists")
                    txt_UserID.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error  occurred while performing this operation" + ex.Message)
            Me.Dispose()
        End Try

        Me.Dispose()
    End Sub


    Private Sub clearcontrols()
        txt_FirstName.Text = ""
        txt_LastName.Text = ""
        txt_Initial.Text = ""
        txt_Number.Text = ""
        txt_Password.Text = ""
        txt_Password2.Text = ""
        txt_Title.Text = ""
        txt_UserID.Text = ""
        cmb_CompanyId.SelectedIndex = 0
        cmb_LevelID.SelectedIndex = 0
        chk_Active.Checked = False
    End Sub


    Private Function validatecontrols() As Boolean
        If (txt_Password2.Text = "") Then
            MessageBox.Show("Please Re-Enter Password")
            txt_Password2.Focus()
            Return False
        ElseIf (txt_Password.Text <> txt_Password2.Text.ToString) Then
            MessageBox.Show("Password Mismatch")
            txt_Password2.Text = ""
            txt_Password2.Focus()
            Return False
        End If
        Return True
    End Function


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub CheckBlanks()
        Dim IsEmpty As Boolean = False

        If txt_FirstName.Text = "" Then
            IsEmpty = True
        End If

        If txt_LastName.Text = "" Then
            IsEmpty = True
        End If

        If cmb_LevelID.Text = "" Then
            IsEmpty = True
        End If

        If cmb_CompanyId.Text = "" Then
            IsEmpty = True
        End If

        If txt_Number.Text = "" Then
            IsEmpty = True
        End If

        If txt_Title.Text = "" Then
            IsEmpty = True
        End If

        If txt_UserID.Text = "" Then
            IsEmpty = True
        End If

        If txt_Password.Text = "" Then
            IsEmpty = True
        End If

        If txt_Password2.Text = "" Then
            IsEmpty = True
        End If

        If Not IsEmpty Then
            btn_Add.Enabled = True
        End If
    End Sub

    Private Sub txt_FirstName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_FirstName.TextChanged
        GenerateUID()
        CheckBlanks()
    End Sub

    Private Sub txt_Initial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Initial.TextChanged
        GenerateUID()
        CheckBlanks()
    End Sub

    Private Sub txt_LastName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_LastName.TextChanged
        GenerateUID()
        CheckBlanks()
    End Sub

    Private Sub txt_Number_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Number.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txt_Password_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Password.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txt_Password2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Password2.TextChanged
        CheckBlanks()
    End Sub

    Private Sub cmb_CompanyId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_CompanyId.SelectedIndexChanged
        CheckBlanks()
    End Sub

    Private Sub cmb_LevelID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_LevelID.SelectedIndexChanged
        CheckBlanks()
    End Sub

    Private Sub GenerateUID()
        Dim First As String = Nothing
        Dim Middle As String = Nothing
        Dim Last As String = Nothing

        If Not txt_FirstName.Text = "" Then
            First = txt_FirstName.Text.Substring(0, 1)
        End If
        If Not txt_Initial.Text = "" Then
            Middle = txt_Initial.Text.Substring(0, 1)
        End If
        If Not txt_LastName.Text = "" Then
            Last = txt_LastName.Text.Substring(0, 1)
        End If


        Dim UserID As String = First + Middle + Last
        UserID = UserID.ToLower

        Dim UserSequence As Integer = TestUID(UserID) + 1
        If Not TestUID(UserID) = 0 Then
            UserID += UserSequence.ToString
        End If

        txt_UserID.Text = UserID
    End Sub


    Private Function TestUID(ByVal UserID As String)
        Dim query As String = "SELECT * FROM userInfo WHERE UserName = '" & UserID & "'"
        'Dim dt As New DataTable
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
        sqlSrvUtils.CloseConnection()

        If dt.Rows.Count = 0 Then
            Return 0
        Else
            Return dt.Rows.Count
        End If
    End Function

End Class