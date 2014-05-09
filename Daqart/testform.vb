Imports SystemManager
Imports daqartDLL


Public Class testform

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim thisSystem As New SystemManager.SystemSelect
        'thisSystem.ShowDialog()

        Dim systemValue As String
        Dim thisSystem As New SystemManager.SystemDataManager
        systemValue = SystemManager.SystemDataManager.GetSystem(SystemNumber.Text)

        If Not systemValue = "" Then
            SystemNumber.Text = systemValue

            Dim translatedValue As String
            translatedValue = SystemManager.SystemDataManager.TranslateSystemID(systemValue)

            systemTranslate.Text = translatedValue
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Result.Text = SystemDataManager.SystemValidate(SystemString.Text).ToString

    End Sub


    Private Sub TabPage3_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Enter
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        Dim query As String = "SELECT * FROM tags"
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        'Dim dt As New DataTable
        'dt = Utilities.ExecuteQuery(query, "project")


        cbx_Tags.DataSource = dt
        cbx_Tags.DisplayMember = dt.Columns(2).ToString
        cbx_Tags.ValueMember = dt.Columns(0).ToString

        query = "SELECT * FROM owner"
        'Dim dt2 As New DataTable
        'dt2 = Utilities.ExecuteQuery(query, "server")

        sqlSrvUtils.OpenConnection()
        Dim dt2 As DataTable = sqlSrvUtils.ExecuteQuery(query)
        sqlSrvUtils.CloseConnection()



        cbx_Owners.DataSource = dt2
        cbx_Owners.DisplayMember = dt2.Columns(2).ToString
        cbx_Owners.ValueMember = dt2.Columns(0).ToString


        query = "SELECT * FROM package"
        'Dim dt3 As New DataTable
        'dt3 = Utilities.ExecuteQuery(query, "project")
        sqlPrjUtils.OpenConnection()
        Dim dt3 As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        cbx_PackageList.DataSource = dt3
        cbx_PackageList.DisplayMember = dt3.Columns(2).ToString
        cbx_PackageList.ValueMember = dt3.Columns(0).ToString


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim RMH As Single = Utilities.GetTagRequiredManHours(cbx_Tags.SelectedValue, cbx_Owners.SelectedValue)
        tbx_RMH.Text = RMH.ToString

        Dim EMH As Single = Utilities.GetTagEarnedManHours(cbx_Tags.SelectedValue, cbx_Owners.SelectedValue)
        tbx_EMH.Text = EMH.ToString

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click


        Dim PRMH As Single = Utilities.GetPackageRequiredManHours(cbx_PackageList.SelectedValue, cbx_Owners.SelectedValue)
        tbx_PRMH.Text = PRMH.ToString

        Dim PEMH As Single = Utilities.GetPackageEarnedManHours(cbx_PackageList.SelectedValue, cbx_Owners.SelectedValue)
        tbx_PEMH.Text = PEMH.ToString


    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        image_pdf.One2One(Me.TextBox2.Text, Me.TextBox1.Text)

    End Sub
End Class