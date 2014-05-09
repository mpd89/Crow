Imports daqartDLL


Public Class AddCompany
    Private TableName As String
    'Dim ServerSQL As DataUtils


    Private Sub AddCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnAdd.Enabled = False

        'ServerSQL = New DataUtils("server")
        'ServerSQL.OpenConnection()
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Select Case Me.Text
                Case "Add Company"
                    TableName = "company"
                Case "Add Discipline"
                    TableName = "discipline"
                Case "Add Level"
                    TableName = "levels"
                Case "Add Group"
                    TableName = "groups"
                Case "Add Owner"
                    TableName = "owner"
            End Select

            Dim query As String = "SELECT * FROM " + TableName + " WHERE Name ='" + Me.txtName.Text + "'"
            Dim dt As New DataTable
            dt = runtime.SQLServer.ExecuteQuery(query)

            If dt.Rows.Count > 0 Then
                MessageBox.Show("The name you have entered already exists on the server.")
                Exit Sub
            End If

            Dim _Active As Integer
            If (chkActive.Checked = True) Then
                _Active = 1
            Else
                _Active = 0
            End If

            query = "insert into " + TableName + " (MUID,Name,Description,Active) values (" & _
                " @MUID," & _
                " @Name," & _
                " @Description," & _
                " @Active)"

            Dim dt_param As DataTable = runtime.SQLServer.paramDT
            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("server", TableName))
            dt_param.Rows.Add("@Name", Me.txtName.Text)
            dt_param.Rows.Add("@Description", Me.txtDescription.Text)
            dt_param.Rows.Add("@Active", _Active.ToString)

            runtime.SQLServer.ExecuteNonQuery(query, dt_param)
            'ServerSQL.CloseConnection()
            Me.Close()
        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.AddUser_Click-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Enter
        If txtDescription.Text > "" Then
            btnAdd.Enabled = True
        End If
    End Sub

    Private Sub txtDescription_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.Enter
        If txtName.Text > "" Then
            btnAdd.Enabled = True
        End If
    End Sub
End Class