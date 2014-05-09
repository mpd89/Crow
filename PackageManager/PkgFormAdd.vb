Imports System.Data.SqlClient
Imports daqartDLL
Public Class PkgFormAdd

    'Private connSQLServer As SqlConnection = daqartDLL.connections.serverRemoteConnect(connSQLServer)
    'Private useProjectDB As String = "USE [" + Runtime.selectedProject + "] "
    'Private useServerDB As String = "USE [" + runtime.SiteName + "_ServerDB] "

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.tbxPkgName.Text <= "" Then
            MessageBox.Show("Please Enter Package Name")
            Return
        End If
        If Me.cboDiscipline.Text <= "" Then
            MessageBox.Show("Please Enter Discipline Name")
            Return
        End If

        If Not (Me.tbx_SystemNumber.Text > "" And Me.cboGroup.Text > "" And Me.cboDiscipline.Text > "" And Me.cboOwner.Text > "") Then
            MessageBox.Show("Please provide default values for Update query")
            Return
        End If


        Dim query As String = "SELECT MUID FROM " + _
                                " package WHERE package.PackageNumber ='" + tbxPkgName.Text + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        If dt.Rows.Count > 0 Then
            MessageBox.Show("Package already exists")
            sqlPrjUtils.CloseConnection()
            Return
        End If
        'Dim pkgID As String = idUtils.GetNextMUID("project", "package")
        Dim Description As String = Me.tbxDescription.Text.ToString
        Dim SysID As String = Me.tbx_SystemNumber.Tag
        Dim GroupID = Me.cboGroup.SelectedValue
        Dim ownerID = Me.cboOwner.SelectedValue
        Dim DspID = Me.cboDiscipline.SelectedValue

        Dim muid As String = idUtils.GetNextMUID("project", "package")
        query = " INSERT INTO package (MUID, TS, Description, PackageNumber, OwnerMUID, GroupMUID, DisciplineMUID, SystemMUID)  VALUES (" + _
        "@MUID,@TS,@Description,@PackageNumber,@OwnerMUID,@GroupMUID,@DisciplineMUID,@SystemMUID)"




        Dim dt_param As DataTable = sqlPrjUtils.paramDT

        dt_param.Rows.Add("@MUID", muid.ToString)
        dt_param.Rows.Add("@TS", DateTime.Now.ToString)
        dt_param.Rows.Add("@PackageNumber", Me.tbxPkgName.Text)
        dt_param.Rows.Add("@OwnerMUID", ownerID.ToString)
        dt_param.Rows.Add("@GroupMUID", GroupID.ToString)
        dt_param.Rows.Add("@DisciplineMUID", DspID.ToString)
        dt_param.Rows.Add("@SystemMUID", SysID.ToString)
        dt_param.Rows.Add("@Description", Description.ToString)

        sqlPrjUtils.ExecuteNonQuery(query, dt_param)



        MessageBox.Show("Package has been updated")
        sqlPrjUtils.CloseConnection()
        ' Me.Dispose()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim systemValue As String
        Dim thisSystem As New SystemManager.SystemDataManager
        systemValue = SystemManager.SystemDataManager.GetSystem(Me.tbx_SystemNumber.Tag)

        Me.tbx_SystemNumber.Tag = systemValue
        Me.tbx_SystemNumber.Text = SystemManager.SystemDataManager.TranslateSystemID(systemValue)

        'If systemValue > "" Then
        '    Dim sysTable As DataTable = cboSysNum.DataSource
        '    Dim dRow As DataRow = sysTable.NewRow
        '    dRow("SystemNumberID") = systemValue
        '    dRow("SystemNumber") = SystemManager.SystemDataManager.TranslateSystemID(systemValue)
        '    sysTable.Rows.Add(dRow)
        '    cboSysNum.Text = dRow("SystemNumber")
        'End If

    End Sub


    Private Sub PkgFormAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        sqlSrvUtils.OpenConnection()
        Try
            'Dim sysTable As DataTable = New DataTable("sysTbl")
            'sysTable.Columns.Add(New DataColumn("SystemNumber", GetType(String)))
            'sysTable.Columns.Add(New DataColumn("SystemNumberID", GetType(String)))
            'Dim cmd As New SqlCommand(useProjectDB + "SELECT DISTINCT SystemNumber FROM package", connSQLServer)
            'Dim reader As SqlDataReader = cmd.ExecuteReader()
            'While reader.Read
            '    Dim dRow As DataRow = sysTable.NewRow
            '    dRow("SystemNumberID") = reader(0)
            '    dRow("SystemNumber") = SystemManager.SystemDataManager.TranslateSystemID(reader(0))
            '    sysTable.Rows.Add(dRow)
            'End While
            'reader.Close()
            'cboSysNum.DataSource = sysTable
            'cboSysNum.DisplayMember = sysTable.Columns(0).ToString
            'cboSysNum.ValueMember = sysTable.Columns(1).ToString
            'cboSysNum.SelectedIndex = -1

            Dim query As String = "SELECT Name, MUID From groups"

            Dim grpTable As DataTable = sqlSrvUtils.ExecuteQuery(query)
            cboGroup.DataSource = grpTable
            cboGroup.DisplayMember = grpTable.Columns("Name").ToString
            cboGroup.ValueMember = grpTable.Columns("MUID").ToString
            cboGroup.SelectedItem = "Undefined"

            query = "SELECT Name, MUID From owner"
            Dim ownerTable As DataTable = sqlSrvUtils.ExecuteQuery(query)
            cboOwner.DataSource = ownerTable
            cboOwner.DisplayMember = ownerTable.Columns("Name").ToString
            cboOwner.ValueMember = ownerTable.Columns("MUID").ToString
            cboOwner.SelectedItem = "Undefined"

            query = "SELECT Name, MUID From Discipline"
            Dim dspTable As DataTable = sqlSrvUtils.ExecuteQuery(query)
            cboDiscipline.DataSource = dspTable
            cboDiscipline.DisplayMember = dspTable.Columns("Name").ToString
            cboDiscipline.ValueMember = dspTable.Columns("MUID").ToString
            cboDiscipline.SelectedItem = "Undefined"

            Me.tbx_SystemNumber.Text = "Undefined"
            Me.tbx_SystemNumber.Tag = "Undefined"
        Catch ex As Exception
            Utilities.logErrorMessage("pkgFormAdd.pkgFormAdd_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
        sqlSrvUtils.CloseConnection()

    End Sub

    Private Sub tbxPkgName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxPkgName.TextChanged
        If Me.tbxPkgName.Text > "" Then
            btnAdd.Enabled = True
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class