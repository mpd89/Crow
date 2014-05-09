Imports daqartDLL


Public Class SystemPermissions
    Dim Loading As Boolean

    Private Sub SystemPermissions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Loading = True

            LoadLevels()

            GetFeatures()

            Loading = False
        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.SystemPermission_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub LoadLevels()
        Dim dt As New DataTable
        dt = Utilities.GetLevels()

        cbx_LevelList.DataSource = dt
        cbx_LevelList.DisplayMember = dt.Columns(2).ToString
        cbx_LevelList.ValueMember = dt.Columns(0).ToString
    End Sub


    Private Sub GetFeatures()
        Dim query As String = "SELECT * FROM SystemFeatures WHERE Status='1' AND Active='1' ORDER BY Code ASC "
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
        sqlSrvUtils.CloseConnection()

        dgv_PermissionTable.Rows.Clear()
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            dgv_PermissionTable.Rows.Add(dt.Rows(i)("Description"), GetPermissions(dt.Rows(i)("MUID")))
            dgv_PermissionTable.Rows(i).Tag = dt.Rows(i)("MUID")

        Next
    End Sub


    Private Function GetPermissions(ByVal _MUID As String)
        Dim query As String = "SELECT * FROM Permissions WHERE LevelMUID='" & cbx_LevelList.SelectedValue & "' AND FeatureMUID='" & _MUID & "'"
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
        sqlSrvUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub cbx_LevelList_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_LevelList.SelectedValueChanged
        If Not Loading Then
            GetFeatures()
        End If
    End Sub


    Private Sub tsb_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Save.Click
        Me.Enabled = False
        Me.Cursor = Cursors.AppStarting

        Dim query As String = Nothing
        Dim i As Integer
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        Try
            For i = 0 To dgv_PermissionTable.Rows.Count - 1
                If dgv_PermissionTable.Rows(i).Cells(1).Value = True And Not GetPermissions(dgv_PermissionTable.Rows(i).Tag) Then
                    'query = "INSERT INTO Permissions (MUID,TS,LevelMUID,FeatureMUID) Values (" & _
                    '"'" & idUtils.GetNextMUID("server", "Permissions") & "'," & _
                    '"'" & Now() & "'," & _
                    '" '" & cbx_LevelList.SelectedValue & "'," & _
                    '" '" & dgv_PermissionTable.Rows(i).Tag & "')"

                    query = "INSERT INTO Permissions (MUID,TS,LevelMUID,FeatureMUID) Values " & _
                    "(@MUID,@TS,@LevelMUID,@FeatureMUID)"
                    sqlSrvUtils.OpenConnection()

                    Dim dt_param As DataTable = sqlSrvUtils.paramDT

                    dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("server", "Permissions"))
                    dt_param.Rows.Add("@TS", DateAndTime.Now.ToString)
                    dt_param.Rows.Add("@LevelMUID", cbx_LevelList.SelectedValue)
                    dt_param.Rows.Add("@FeatureMUID", dgv_PermissionTable.Rows(i).Tag)

                    sqlSrvUtils.ExecuteNonQuery(query, dt_param)
                    sqlSrvUtils.CloseConnection()
                ElseIf dgv_PermissionTable.Rows(i).Cells(1).Value = False And GetPermissions(dgv_PermissionTable.Rows(i).Tag) Then
                    'query = "DELETE FROM Permissions WHERE LevelMUID='" & cbx_LevelList.SelectedValue & "' AND FeatureMUID='" & dgv_PermissionTable.Rows(i).Tag & "'"
                    query = "DELETE FROM Permissions WHERE LevelMUID=@LevelMUID"
                    sqlSrvUtils.OpenConnection()
                    Dim dt_param As DataTable = sqlSrvUtils.paramDT

                    dt_param.Rows.Add("@LevelMUID", cbx_LevelList.SelectedValue)

                    sqlSrvUtils.ExecuteNonQuery(query, dt_param)
                    sqlSrvUtils.CloseConnection()
                End If
            Next

            MessageBox.Show("Record Updated!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub dgv_PermissionTable_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_PermissionTable.CellClick
        If Not Loading Then
            Try
                If dgv_PermissionTable.Rows(e.RowIndex).Cells(1).Value Then
                    dgv_PermissionTable.Rows(e.RowIndex).Cells(1).Value = False
                Else
                    dgv_PermissionTable.Rows(e.RowIndex).Cells(1).Value = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

End Class