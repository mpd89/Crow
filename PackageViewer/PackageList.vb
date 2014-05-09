Imports daqartDLL
Public Class PackageList
    Public Shared SelectedPackage As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub


    Private Sub PackageList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim query As String = " Select * FROM package ORDER BY PackageNumber ASC"
            'Dim dt As DataTable = daqartDLL.Utilities.ExecuteQuery(query, "project")
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            sqlPrjUtils.CloseConnection()


            lbx_PackageSelect.DataSource = dt
            lbx_PackageSelect.DisplayMember = dt.Columns("PackageNumber").ToString
            lbx_PackageSelect.ValueMember = dt.Columns("MUID").ToString

            lbx_PackageSelect.SelectedItem = 0
        Catch ex As Exception
            Utilities.logErrorMessage("PackageViewer.PackageList._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SelectedPackage = lbx_PackageSelect.SelectedValue
    End Sub


End Class