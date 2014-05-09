Imports daqartDLL


Public Class frmRecord
    Private TableName As String
    Private RecordID As String


    Public Sub New(ByVal _TableName As String, ByVal _RecordID As String)
        InitializeComponent()
        RecordID = _RecordID
        TableName = _TableName
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim id As String = ""
        Select Case TableName
            Case "company"
                id = "MUID"
            Case "discipline"
                id = "MUID"
            Case "levels"
                id = "MUID"
            Case "groups"
                id = "MUID"
            Case "owner"
                id = "MUID"
            Case "user"
                id = "MUID"
        End Select

        Dim _Active As Integer
        If (chkActive.Checked = True) Then
            _Active = 1
        Else
            _Active = 0
        End If

        Dim ServerSQL As New DataUtils("server")
        ServerSQL.OpenConnection()
        Dim query As String = "SELECT Name From " + TableName.ToString + " WHERE Name = '" + Me.txtName.Text + "' AND " + id + " <> " + RecordID.ToString
        Dim dt As DataTable = ServerSQL.ExecuteQuery(query)

        If dt.Rows.Count > 0 Then
            MessageBox.Show("Name already exist")
            ServerSQL.CloseConnection()
            Return
        End If

        query = "UPDATE " + TableName.ToString + " SET " & _
            " Name=@Name," & _
            " Description=@Description," & _
            " Active=@Active " & _
            " WHERE MUID=@MUID"

        Dim dt_param As DataTable = ServerSQL.paramDT
        dt_param.Rows.Add("@Name", Me.txtName.Text)
        dt_param.Rows.Add("@Description", Me.txtDescription.Text)
        dt_param.Rows.Add("@Active", _Active.ToString)
        dt_param.Rows.Add("@MUID", RecordID.ToString)

        ServerSQL.ExecuteNonQuery(query, dt_param)
        ServerSQL.CloseConnection()

        Me.Dispose()

    End Sub



End Class