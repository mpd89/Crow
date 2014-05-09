Imports DaqartDLL


Public Class PackageList
    Public Shared SelectedPackage As String = ""
    Public Shared SelectedPackageMUID As String = ""

    Private SQLProject As DataUtils = New daqartDLL.DataUtils("project")


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub


    Private Sub PackageList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = " Select * FROM package ORDER BY PackageNumber ASC"
        SQLProject.OpenConnection()
        Dim dt As DataTable = SQLProject.ExecuteQuery(query)
        SQLProject.CloseConnection()

        lbx_PackageSelect.DataSource = dt
        lbx_PackageSelect.DisplayMember = dt.Columns("PackageNumber").ToString
        lbx_PackageSelect.ValueMember = dt.Columns(0).ToString

        lbx_PackageSelect.SelectedIndex = -1
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SelectedPackageMUID = lbx_PackageSelect.SelectedValue
        SelectedPackage = lbx_PackageSelect.Text
        Me.Close()
    End Sub

End Class