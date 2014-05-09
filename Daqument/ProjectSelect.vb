Imports daqartDLL
Imports System.Data.SqlServerCe


Public Class ProjectSelect
    Public SelectedProjectID As Integer
    Public SelectedProjectName As String
    Dim Loading As Boolean


    Private Sub ProjectSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Loading = True

            GetProjects()

            Loading = False
        Catch ex As Exception
            Utilities.logErrorMessage("Daqument.ProjectSelect.ProjectSelect_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Me.Close()
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub GetProjects()
        Dim query As String = "SELECT * FROM projects"
        'Dim dt As New DataTable

        Try
            'dt = Utilities.ExecuteQuery(query, "server")
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            sqlSrvUtils.OpenConnection()
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
            sqlSrvUtils.CloseConnection()


            lbx_Projects.DataSource = dt
            lbx_Projects.DisplayMember = dt.Columns(2).ToString
            lbx_Projects.ValueMember = dt.Columns(0).ToString

            lbx_Projects.SelectedIndex = 0
            SelectedProjectID = lbx_Projects.SelectedValue
            SelectedProjectName = lbx_Projects.Text

        Catch ex As SqlCeException
            MessageBox.Show("Failed to select projects from project database: " + ex.Message)
        End Try

    End Sub


    Private Sub lbx_Projects_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbx_Projects.SelectedIndexChanged
        If Loading Then Return

        SelectedProjectID = lbx_Projects.SelectedValue
        SelectedProjectName = lbx_Projects.Text

        btn_OK.Enabled = True
    End Sub
End Class