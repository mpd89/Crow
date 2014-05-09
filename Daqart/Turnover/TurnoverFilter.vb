Imports daqartDLL


Public Class TurnoverFilter
    Dim dt_UserProjects As New DataTable

    Private Sub TurnoverFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'populate My projects
        Dim query As String = "SELECT projects.MUID,projects.Name" & _
            " FROM projects,user_projects WHERE projects.MUID = user_projects.ProjectMUID " & _
            " AND user_projects.UserMUID='" + runtime.UserMUID + "'" & _
            " ORDER BY projects.Name ASC"
        dt_UserProjects = runtime.SQLServer.ExecuteQuery(query)

        Me.clb_Projects.DataSource = dt_UserProjects
        Me.clb_Projects.DisplayMember = dt_UserProjects.Columns("Name").ToString
        Me.clb_Projects.ValueMember = dt_UserProjects.Columns("MUID").ToString

        'load all project numbers
        query = "SELECT * FROM SystemImages WHERE Code='PNR' ORDER BY Name ASC"
        Dim dt_ProjectNumbers As DataTable = runtime.SQLServer.ExecuteQuery(query)
        Me.cbx_ProjectNumber.DataSource = dt_ProjectNumbers
        Me.cbx_ProjectNumber.DisplayMember = dt_ProjectNumbers.Columns("Name").ToString
        Me.cbx_ProjectNumber.ValueMember = dt_ProjectNumbers.Columns("Name").ToString

        'load allcontractors
        query = "SELECT * FROM company ORDER BY Name ASC"
        Dim dt_Contractors As DataTable = runtime.SQLServer.ExecuteQuery(query)
        Me.cbx_Contractor.DataSource = dt_Contractors
        Me.cbx_Contractor.DisplayMember = dt_Contractors.Columns("Name").ToString
        Me.cbx_Contractor.ValueMember = dt_Contractors.Columns("MUID").ToString

        'load all locations
        query = "SELECT * FROM SystemImages WHERE Code='PLO' ORDER BY Name ASC"
        Dim dt_Locations As DataTable = runtime.SQLServer.ExecuteQuery(query)
        Me.cbx_Location.DataSource = dt_Locations
        Me.cbx_Location.DisplayMember = dt_Locations.Columns("Name").ToString
        Me.cbx_Location.ValueMember = dt_Locations.Columns("Name").ToString

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor
        Dim ProjectList As New List(Of String)

        If Me.rad_MyProjects.Checked Then
            For i As Integer = 0 To Me.dt_UserProjects.Rows.Count - 1
                ProjectList.Add(Me.dt_UserProjects.Rows(i)(0))
            Next
        End If

        If Me.rad_CurrentProject.Checked Then
            ProjectList.Add(runtime.selectedProjectID)
        End If


        'If Me.rad_SelectProject.Checked Then
        '    For i As Integer = 0 To Me.clb_Projects.CheckedItems.Count - 1
        '        ProjectList.Add(Me.clb_Projects.CheckedItems(i))
        '    Next
        'End If

        'define datatable
        Dim dt_Final As New DataTable
        dt_Final.Columns.Add("ProjectMUID")
        dt_Final.Columns.Add("ProjectName")
        dt_Final.Columns.Add("SH_MUID")
        dt_Final.Columns.Add("SH#")
        dt_Final.Columns.Add("SH_Description")
        dt_Final.Columns.Add("MC_MUID")
        dt_Final.Columns.Add("MC_Description")
        dt_Final.Columns.Add("Disc")
        dt_Final.Columns.Add("Project Number")
        dt_Final.Columns.Add("Contractor")
        dt_Final.Columns.Add("Location")
        dt_Final.Columns.Add("MC#")
        dt_Final.Columns.Add("MC_Sent")
        dt_Final.Columns.Add("IWL_Start")
        dt_Final.Columns.Add("MC_Signed")
        dt_Final.Columns.Add("SH_Sent")
        dt_Final.Columns.Add("SH_Signed")


        Dim QueryCriteria As String = Nothing
        If Me.rad_ProjectNumber.Checked Then
            QueryCriteria = " AND Aux09='" + Me.cbx_ProjectNumber.Text + "'"
        End If
        If Me.rad_Contractor.Checked Then
            QueryCriteria = " AND Aux08='" + Me.cbx_Contractor.SelectedValue + "'"
        End If
        If Me.rad_Location.Checked Then
            QueryCriteria = " AND Aux07='" + Me.cbx_Location.Text + "'"
        End If


        For i As Integer = 0 To ProjectList.Count - 1
            Dim ThisProjectSQL As New DataUtils("project")
            ThisProjectSQL.ProjectName = Utilities.GetProjectName(ProjectList(i))
            ThisProjectSQL.OpenConnection()

            'define query
            Dim query As String = "SELECT * FROM system_mnemonic WHERE Aux08 = 'MC'"
            Dim dt As DataTable = ThisProjectSQL.ExecuteQuery(query)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Project: " + Utilities.GetProjectName(ProjectList(i)) + " has not been configured to use this feature.")

            Else
                query = "SELECT * FROM system_number WHERE Identifier NOT LIKE 'HCP%' AND TierMUID='" + dt.Rows(0)("TierNumber").ToString + "'" + QueryCriteria
                Dim dt_MCs As DataTable = ThisProjectSQL.ExecuteQuery(query)

                For u As Integer = 0 To dt_MCs.Rows.Count - 1
                    'look up SH information by ParentMUID
                    query = "SELECT * FROM system_number WHERE MUID='" + dt_MCs.Rows(u)("ParentLinkMUID") + "'"
                    Dim dt_SH As DataTable = ThisProjectSQL.ExecuteQuery(query)

                    dt_Final.Rows.Add()
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("ProjectMUID") = ProjectList(i)
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("ProjectName") = Utilities.GetProjectName(ProjectList(i))
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("SH_MUID") = dt_SH.Rows(0)("MUID")
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("SH#") = dt_SH.Rows(0)("Identifier")
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("SH_Description") = dt_SH.Rows(0)("Description")
                    If Not IsDBNull(dt_MCs.Rows(u)("Aux06")) Then
                        dt_Final.Rows(dt_Final.Rows.Count - 1)("Disc") = Utilities.GetDisciplineName(dt_MCs.Rows(u)("Aux06"))
                    End If
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("MC_MUID") = dt_MCs.Rows(u)("MUID")
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("MC#") = dt_MCs.Rows(u)("Identifier")
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("MC_Description") = dt_MCs.Rows(u)("Description")
                    If Not IsDBNull(dt_MCs.Rows(u)("Aux07")) Then
                        dt_Final.Rows(dt_Final.Rows.Count - 1)("Location") = dt_MCs.Rows(u)("Aux07")
                    End If
                    If Not IsDBNull(dt_MCs.Rows(u)("Aux08")) Then
                        dt_Final.Rows(dt_Final.Rows.Count - 1)("Contractor") = Utilities.GetCompanyName(dt_MCs.Rows(u)("Aux08"))
                    End If
                    If Not IsDBNull(dt_MCs.Rows(u)("Aux09")) Then
                        dt_Final.Rows(dt_Final.Rows.Count - 1)("Project Number") = dt_MCs.Rows(u)("Aux09")
                    End If
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("MC_Sent") = dt_MCs.Rows(u)("Aux04")
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("IWL_Start") = dt_MCs.Rows(u)("Aux05")
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("MC_Signed") = dt_MCs.Rows(u)("Aux03")
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("SH_Sent") = dt_SH.Rows(0)("Aux04")
                    dt_Final.Rows(dt_Final.Rows.Count - 1)("SH_Signed") = dt_SH.Rows(0)("Aux03")

                Next

            End If

            ThisProjectSQL.CloseConnection()
        Next

        Dim SelectBy As String = "None"
        Dim SearchBy As String = ""

        If Me.rad_ProjectNumber.Checked Then
            SelectBy = "ProjectNumber"
            SearchBy = Me.cbx_ProjectNumber.Text
        ElseIf Me.rad_Contractor.Checked Then
            SelectBy = "Contractor"
            SearchBy = Me.cbx_Contractor.Text
        ElseIf Me.rad_Location.Checked Then
            SelectBy = "Location"
            SearchBy = Me.cbx_Location.Text
        End If

        Dim frm_TurnoverInput As New TurnoverEntry(dt_Final, SelectBy, SearchBy)
        frm_TurnoverInput.Show()

        'Me.Dispose()
        Me.Cursor = Cursors.Default

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub rad_SelectProject_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_SelectProject.CheckedChanged

        If Me.rad_SelectProject.Checked Then
            Me.clb_Projects.Enabled = True
        Else
            For i As Integer = 0 To Me.clb_Projects.Items.Count - 1
                Me.clb_Projects.SetItemChecked(i, False)
            Next
            Me.clb_Projects.Enabled = False
        End If
    End Sub


End Class