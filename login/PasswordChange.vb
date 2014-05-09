Imports daqartDLL


Public Class PasswordChange
    Private UserID As String
    Public NewPassword As String


    Public Sub New(ByVal _UserID As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        UserID = _UserID
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If Me.TextBox1.Text.Length > 7 And Me.TextBox2.Text.Length > 7 Then
            btn_OK.Enabled = True
        Else
            btn_OK.Enabled = False
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If Me.TextBox1.Text.Length > 7 And Me.TextBox2.Text.Length > 7 Then
            btn_OK.Enabled = True
        Else
            btn_OK.Enabled = False
        End If
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click

        If Not Me.TextBox1.Text = Me.TextBox2.Text Then
            MessageBox.Show("The passwords entered do not match.  Please re-enter and try again.")
        Else
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")
            Dim query As String = "UPDATE userInfo SET UserPW = @UserPW WHERE MUID = @MUID"

            Dim dt_param As DataTable = sqlSrvUtils.paramDT
            dt_param.Rows.Add("@UserPW", Me.TextBox1.Text)
            dt_param.Rows.Add("@MUID", UserID.ToString)

            sqlSrvUtils.OpenConnection()
            sqlSrvUtils.ExecuteNonQuery(query, dt_param)
            sqlSrvUtils.CloseConnection()

            NewPassword = Me.TextBox1.Text

            Me.Close()
        End If
    End Sub



 
End Class