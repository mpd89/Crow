Imports daqartDLL
'Imports System.Data.SqlClient


Public Class FormImport
    Dim FormID As String
    Dim OldFormID As String


    Private Sub FormImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim query As String = "USE [" + runtime.SiteName + "_ServerDB]  SELECT * FROM projects WHERE Name != '" + runtime.selectedProject + "'"
        Dim query As String = " SELECT * FROM projects WHERE Name != '" + runtime.selectedProject + "' ORDER BY Name"
        'Dim dt As New DataTable
        'dt = Utilities.ExecuteRemoteQuery(query, "server")
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
        sqlSrvUtils.CloseConnection()


        If dt.Rows.Count = 0 Then
            MessageBox.Show("There are no other projects on this server to import from.")
            Me.Dispose()
        Else
            Me.cbx_Projects.DataSource = dt
            Me.cbx_Projects.DisplayMember = dt.Columns(2).ToString
            Me.cbx_Projects.ValueMember = dt.Columns(0).ToString
        End If
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub cbx_Projects_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_Projects.SelectedIndexChanged
        'Dim query As String = "USE [" + Me.cbx_Projects.Text + "]  SELECT * FROM forms"
        'Dim dt As New DataTable
        'dt = Utilities.ExecuteRemoteQuery(query, "server")

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim query As String = " SELECT * FROM forms ORDER BY Name ASC"
        sqlPrjUtils.ProjectName = Me.cbx_Projects.Text
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()
        If Not dt.Rows.Count = 0 Then
            Me.cbx_Forms.DataSource = dt
            Me.cbx_Forms.DisplayMember = dt.Columns(2).ToString
            Me.cbx_Forms.ValueMember = dt.Columns(0).ToString
            Me.cbx_Forms.Enabled = True
        End If


    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        'get selected form info
        'Dim query As String = "USE [" + Me.cbx_Projects.Text + "]  SELECT * FROM forms WHERE ID = '" + Me.cbx_Forms.SelectedValue.ToString + "'"
        'Dim dt As New DataTable
        'dt = Utilities.ExecuteRemoteQuery(query, "server")

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.ProjectName = Me.cbx_Projects.Text
        Dim query As String = " SELECT * FROM forms WHERE MUID = '" + Me.cbx_Forms.SelectedValue.ToString + "'"
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()


        If Not dt.Rows.Count = 0 Then
            Dim sqlPrj1Utils As DataUtils = New DataUtils("project")
            sqlPrj1Utils.OpenConnection()

            query = " INSERT INTO forms " & _
                "(MUID,TS,Name,Description,NumberPages,Active,Comments,MultiElement," & _
                "NumberofElements,PackageTemplateMUID,TagTemplateMUID,SystemForm,Aux02,Aux01) VALUES (" & _
                "@MUID," & _
                "@TS," & _
                "@Name," & _
                "@Description," & _
                "@NumberPages," & _
                "@Active," & _
                "@Comments," & _
                "@MultiElement," & _
                "@NumberofElements," & _
                "@PackageTemplateMUID," & _
                "@TagTemplateMUID," & _
                "@SystemForm," & _
                "@Aux02," & _
                "@Aux01)"

            Dim dt_param As DataTable = sqlPrj1Utils.paramDT
            Dim muid As String = idUtils.GetNextMUID("project", "forms")
            dt_param.Rows.Add("@MUID", muid)
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@Name", dt.Rows(0)(2).ToString)
            dt_param.Rows.Add("@Description", dt.Rows(0)(3).ToString)
            dt_param.Rows.Add("@NumberPages", dt.Rows(0)(4).ToString)
            dt_param.Rows.Add("@Active", dt.Rows(0)(6).ToString)
            dt_param.Rows.Add("@Comments", dt.Rows(0)(7).ToString)
            dt_param.Rows.Add("@MultiElement", dt.Rows(0)(8).ToString)
            dt_param.Rows.Add("@NumberofElements", dt.Rows(0)(9).ToString)
            dt_param.Rows.Add("@PackageTemplateMUID", dt.Rows(0)(10).ToString)
            dt_param.Rows.Add("@TagTemplateMUID", dt.Rows(0)(11).ToString)
            dt_param.Rows.Add("@SystemForm", dt.Rows(0)(12).ToString)
            dt_param.Rows.Add("@Aux02", dt.Rows(0)(13).ToString)
            dt_param.Rows.Add("@Aux01", dt.Rows(0)(14).ToString)

            sqlPrj1Utils.ExecuteNonQuery(query, dt_param)

            OldFormID = dt.Rows(0)(0)

            'query = " SELECT TOP 1 MUID FROM forms Order By MUID DESC"
            'dt = sqlPrj1Utils.ExecuteQuery(query)


            FormID = muid ' dt.Rows(0)(0)

            sqlPrj1Utils.CloseConnection()


            GetFormImage()

            GetAuxFormInfo()

            GetAuxSubFormsFields()

            GetAuxSubFormsInfo()

            GetFormStorage()

            'Utilities.SyncProjectDB(runtime.selectedProject)
            Me.Cursor = Cursors.Default
            Me.Enabled = True
            MessageBox.Show("Form Import Complete.")
            Me.Dispose()
        End If
    End Sub


    Private Sub GetFormImage()
        'Dim query As String = "USE [" + Me.cbx_Projects.Text + "]  SELECT * FROM forms_image WHERE FormID = '" + OldFormID.ToString + "'"
        'Dim dt As New DataTable
        'dt = Utilities.ExecuteRemoteQuery(query, "server")
        Dim query As String = " SELECT * FROM forms_image WHERE FormMUID = '" + OldFormID.ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.ProjectName = Me.cbx_Projects.Text
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()



        Dim sqlPrj1Utils As DataUtils = New DataUtils("project")
        sqlPrj1Utils.OpenConnection()
        If Not dt.Rows.Count = 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                'query = "USE [" + runtime.selectedProject + "]  INSERT INTO forms_image " & _
                '    "(TS,FormID,PageNumber,FormImage) VALUES (" & _
                '    "'" + Now() + "'," & _
                '    "'" + FormID.ToString + "'," & _
                '    "'" + dt.Rows(0)(3).ToString + "'," & _
                '    "'" + dt.Rows(0)(4).ToString + "')"
                'Utilities.ExecuteRemoteNonQuery(query, "project")

                'Dim connSQLServer As SqlConnection = Nothing
                'connSQLServer = daqartDLL.connections.serverRemoteConnect(connSQLServer)
                'Dim cmd As SqlCommand = connSQLServer.CreateCommand()
                'cmd.CommandText = "USE [" + runtime.selectedProject + "] INSERT INTO forms_image (TS,FormID,PageNumber,FormImage) VALUES " _
                '        & "('" + Now() + "','" + FormID.ToString + "','" + dt.Rows(0)(3).ToString + "',@BaseImage)"
                'cmd.Parameters.Add("@BaseImage", SqlDbType.VarBinary)
                'cmd.Parameters("@BaseImage").Value = dt.Rows(i)(4)
                'connSQLServer.Open()
                'cmd.ExecuteScalar()
                'connSQLServer.Close()

                'query = " INSERT INTO forms_image (TS,FormID,PageNumber,FormImage) VALUES " _
                '        & "('" + Now() + "','" + FormID.ToString + "','" + dt.Rows(0)(3).ToString + "',@BaseImage)"
                Dim muid As String = idUtils.GetNextMUID("project", "forms_image")
                query = " INSERT INTO forms_image (MUID, TS,FormMUID,PageNumber,FormImage) VALUES " _
                                        & "('" + muid + "','" + Now() + "','" + FormID.ToString + "','" + dt.Rows(0)(3).ToString + "',@BaseImage)"

                sqlPrj1Utils.ExecuteSingleParameterizedQuery(query, "@BaseImage", dt.Rows(i)(4))
            Next
        End If
        sqlPrj1Utils.CloseConnection()
    End Sub


    Private Sub GetAuxFormInfo()
        'Dim query As String = "USE [" + Me.cbx_Projects.Text + "]  SELECT * FROM aux_forms_info WHERE FormID = '" + OldFormID.ToString + "'"
        'Dim dt As New DataTable
        'dt = Utilities.ExecuteRemoteQuery(query, "server")

        Dim query As String = " SELECT * FROM aux_forms_info WHERE FormMUID = '" + OldFormID.ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.ProjectName = Me.cbx_Projects.Text
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()



        Dim sqlPrj1Utils As DataUtils = New DataUtils("project")
        sqlPrj1Utils.OpenConnection()
        If Not dt.Rows.Count = 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                query = " INSERT INTO aux_forms_info " & _
                    "(MUID, TS,FormMUID,AuxData) VALUES (" & _
                    "@MUID," & _
                    "@TS," & _
                    "@FormMUID," & _
                    "@AuxData)"

                Dim dt_param As DataTable = sqlPrj1Utils.paramDT
                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "aux_forms_info"))
                dt_param.Rows.Add("@TS", Now())
                dt_param.Rows.Add("@FormMUID", FormID.ToString)
                dt_param.Rows.Add("@AuxData", dt.Rows(i)(3).ToString)

                sqlPrj1Utils.ExecuteNonQuery(query, dt_param)
            Next
        End If
        sqlPrj1Utils.CloseConnection()
    End Sub


    Private Sub GetAuxSubFormsFields()
        'Dim query As String = "USE [" + Me.cbx_Projects.Text + "]  SELECT * FROM aux_subforms_fields WHERE FormID = '" + OldFormID.ToString + "'"
        'Dim dt As New DataTable
        'dt = Utilities.ExecuteRemoteQuery(query, "server")

        Dim query As String = " SELECT * FROM aux_subforms_fields WHERE FormMUID = '" + OldFormID.ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.ProjectName = Me.cbx_Projects.Text
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()


        Dim sqlPrj1Utils As DataUtils = New DataUtils("project")
        sqlPrj1Utils.OpenConnection()
        If Not dt.Rows.Count = 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                query = " INSERT INTO aux_subforms_fields " & _
                    "(MUID,TS,FormMUID,Fieldname,Aux05,Aux04,Aux03,Aux02,Aux01) VALUES (" & _
                    "@MUID," & _
                    "@TS," & _
                    "@FormMUID," & _
                    "@Fieldname," & _
                    "@Aux05," & _
                    "@Aux04," & _
                    "@Aux03," & _
                    "@Aux02," & _
                    "@Aux01)"

                Dim dt_param As DataTable = sqlPrj1Utils.paramDT
                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "aux_subforms_fields"))
                dt_param.Rows.Add("@TS", Now())
                dt_param.Rows.Add("@FormMUID", FormID.ToString)
                dt_param.Rows.Add("@Fieldname", dt.Rows(i)(2).ToString)
                dt_param.Rows.Add("@Aux05", dt.Rows(i)(3).ToString)
                dt_param.Rows.Add("@Aux04", dt.Rows(i)(4).ToString)
                dt_param.Rows.Add("@Aux03", dt.Rows(i)(5).ToString)
                dt_param.Rows.Add("@Aux02", dt.Rows(i)(6).ToString)
                dt_param.Rows.Add("@Aux01", dt.Rows(i)(7).ToString)

                sqlPrj1Utils.ExecuteNonQuery(query, dt_param)
            Next
        End If
        sqlPrj1Utils.CloseConnection()
    End Sub


    Private Sub GetAuxSubFormsInfo()
        Dim query As String = " SELECT * FROM aux_subforms_info WHERE FormMUID = '" + OldFormID.ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.ProjectName = Me.cbx_Projects.Text
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Dim sqlPrj1Utils As DataUtils = New DataUtils("project")
        sqlPrj1Utils.OpenConnection()

        If Not dt.Rows.Count = 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                query = " INSERT INTO aux_subforms_info " & _
                    "(MUID,TS,FormMUID,AuxData,Aux01,Aux02,Aux03,Aux04,Aux05) VALUES (" & _
                    "@MUID," & _
                    "@TS," & _
                    "@FormMUID," & _
                    "@AuxData," & _
                    "@Aux01," & _
                    "@Aux02," & _
                    "@Aux03," & _
                    "@Aux04," & _
                    "@Aux05)"

                Dim dt_param As DataTable = sqlPrj1Utils.paramDT
                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "aux_subforms_info"))
                dt_param.Rows.Add("@TS", Now())
                dt_param.Rows.Add("@FormMUID", FormID.ToString)
                dt_param.Rows.Add("@AuxData", dt.Rows(i)(3).ToString)
                dt_param.Rows.Add("@Aux01", dt.Rows(i)(4).ToString)
                dt_param.Rows.Add("@Aux02", dt.Rows(i)(5).ToString)
                dt_param.Rows.Add("@Aux03", dt.Rows(i)(6).ToString)
                dt_param.Rows.Add("@Aux04", dt.Rows(i)(7).ToString)
                dt_param.Rows.Add("@Aux05", dt.Rows(i)(8).ToString)

                sqlPrj1Utils.ExecuteNonQuery(query, dt_param)
            Next
        End If
        sqlPrj1Utils.CloseConnection()
    End Sub


    Private Sub GetFormStorage()
        'Dim query As String = "USE [" + Me.cbx_Projects.Text + "]  SELECT * FROM forms_storage WHERE FormID = '" + OldFormID.ToString + "'"
        'Dim dt As New DataTable
        'dt = Utilities.ExecuteRemoteQuery(query, "server")
        Dim query As String = " SELECT * FROM forms_storage WHERE FormMUID = '" + OldFormID.ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.ProjectName = Me.cbx_Projects.Text
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Dim sqlPrj1Utils As DataUtils = New DataUtils("project")
        sqlPrj1Utils.OpenConnection()
        
        If Not dt.Rows.Count = 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                'query = "USE [" + runtime.selectedProject + "]  INSERT INTO forms_storage " & _
                '    "(FormID,baseImage) VALUES (" & _
                '    "'" + FormID.ToString + "'," & _
                '    "'" + dt.Rows(0)(2).ToString + "')"
                'Utilities.ExecuteRemoteNonQuery(query, "project")
                'query = " INSERT INTO forms_storage (MUID,FormMUID,BaseImage) VALUES " _
                '        & "('" + FormID.ToString + "',@BaseImage)"
                Dim muid As String = idUtils.GetNextMUID("project", "forms_storage")
                query = " INSERT INTO forms_storage (MUID,FormMUID,BaseImage) VALUES " _
                        & "('" + muid + "','" + FormID.ToString + "',@BaseImage)"
                sqlPrj1Utils.ExecuteSingleParameterizedQuery(query, "@BaseImage", dt.Rows(i)(2))

                'Dim connSQLServer As SqlConnection = Nothing
                'connSQLServer = daqartDLL.connections.serverRemoteConnect(connSQLServer)
                'Dim cmd As SqlCommand = connSQLServer.CreateCommand()
                'cmd.CommandText = "USE [" + runtime.selectedProject + "] INSERT INTO forms_storage (FormID,BaseImage) VALUES " _
                '        & "(@FormID,@BaseImage)"
                'cmd.Parameters.Add("@FormID", SqlDbType.Int)
                'cmd.Parameters("@FormID").Value = FormID.ToString
                'cmd.Parameters.Add("@BaseImage", SqlDbType.VarBinary)
                'cmd.Parameters("@BaseImage").Value = dt.Rows(i)(2)

                'connSQLServer.Open()
                'cmd.ExecuteScalar()
                'connSQLServer.Close()
            Next
        End If
        sqlPrj1Utils.CloseConnection()
    End Sub

End Class