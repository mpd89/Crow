Imports daqartDLL

Public Class SignOffProxy
    Public Shared HasValue As Boolean = False
    Public Shared MUID As String
    Dim NewUser As String


    Private Sub SignOffProxy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub


    Private Sub LoadUsers()
        Dim query As String = "SELECT MUID, LastName + ',' + FirstName + ' ' + MI As UserName FROM userInfo ORDER BY LastName ASC, FirstName ASC"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Dim dt_Final As New DataTable
        dt_Final.Columns.Add("MUID")
        dt_Final.Columns.Add("UserName")

        dt_Final.Rows.Add("", "")

        For i As Integer = 0 To dt.Rows.Count - 1
            dt_Final.Rows.Add(dt.Rows(i)("MUID"), dt.Rows(i)("UserName"))
        Next

        Me.cbx_User.DataSource = dt_Final
        Me.cbx_User.DisplayMember = dt_Final.Columns("UserName").ToString
        Me.cbx_User.ValueMember = dt_Final.Columns("MUID").ToString

        If Not NewUser = Nothing Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If NewUser = dt.Rows(i)("MUID") Then
                    Me.cbx_User.SelectedIndex = i + 1
                End If
            Next
        End If
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        'return MUID, Name and Date
        HasValue = True
        MUID = Me.cbx_User.SelectedValue
        Me.Dispose()
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        HasValue = False
        Me.Dispose()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New AddUser
        frm.ShowDialog()

        NewUser = frm.UserAdded
        LoadUsers()

    End Sub


    Private Sub cbx_User_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_User.SelectedIndexChanged
        'If Me.cbx_User.Text = "" Then
        '    Me.btn_OK.Enabled = False
        'Else
        '    Me.btn_OK.Enabled = True
        'End If
    End Sub

End Class