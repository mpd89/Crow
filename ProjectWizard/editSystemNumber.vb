Imports System
Imports System.Windows.Forms
Imports daqartDLL
Imports SystemManager


Public Class editSystemNumber
    Public SystemID As String
    Dim SQLProject As DataUtils
    Dim HasParent As Boolean
    Dim ParentMUID As String
    Dim IsParent As Boolean
    Dim ParentModified As Boolean


    Private Sub editSystemNumber_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLProject.CloseConnection()
    End Sub


    Private Sub editSystemNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SQLProject = New DataUtils("project")
            SQLProject.OpenConnection()

            'load all project numbers
            Dim query As String = "SELECT * FROM SystemImages WHERE Code='PNR' ORDER BY Name ASC"
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

            'load all disciplines
            query = "SELECT MUID, Name + ' - ' + Description AS Show FROM discipline ORDER BY Name ASC"
            Dim dt_Discipline As DataTable = runtime.SQLServer.ExecuteQuery(query)
            Me.cbx_Discipline.DataSource = dt_Discipline
            Me.cbx_Discipline.DisplayMember = dt_Discipline.Columns("Show").ToString
            Me.cbx_Discipline.ValueMember = dt_Discipline.Columns("MUID").ToString

            Dim dt As DataTable = Nothing
            query = "SELECT * FROM system_number WHERE MUID = '" + SystemID + "'"
            dt = SQLProject.ExecuteQuery(query)

            SystemIdentifier.Text = dt.Rows(0)("Identifier")
            SystemDescription.Text = dt.Rows(0)("Description")

            HasParent = SystemDataManager.HasParent(dt.Rows(0)("TierMUID"))
            IsParent = SystemDataManager.IsParent(dt.Rows(0)("TierMUID"))
            If HasParent Then
                ParentMUID = dt.Rows(0)("ParentLinkMUID")

                Dim dt_ParentMUIDs As DataTable
                query = "SELECT * FROM system_number WHERE TierMUID = '" + (dt.Rows(0)("TierMUID") - 1).ToString + "' ORDER BY Identifier ASC"
                dt_ParentMUIDs = runtime.SQLProject.ExecuteQuery(query)

                Me.cbx_Parent.Enabled = True
                Me.cbx_Parent.DataSource = dt_ParentMUIDs
                Me.cbx_Parent.DisplayMember = dt_ParentMUIDs.Columns("Identifier").ToString
                Me.cbx_Parent.ValueMember = dt_ParentMUIDs.Columns("MUID").ToString

                Me.cbx_Parent.SelectedValue = ParentMUID
            Else
                Me.cbx_Parent.Enabled = False
            End If


            If Not IsDBNull(dt.Rows(0)("Aux09")) Then
                Me.cbx_ProjectNumber.Text = dt.Rows(0)("Aux09")
            End If

            If Not IsDBNull(dt.Rows(0)("Aux08")) Then
                Me.cbx_Contractor.SelectedValue = dt.Rows(0)("Aux08")
            End If

            If Not IsDBNull(dt.Rows(0)("Aux07")) Then
                Me.cbx_Location.Text = dt.Rows(0)("Aux07")
            End If

            If Not IsDBNull(dt.Rows(0)("Aux06")) Then
                Me.cbx_Discipline.SelectedValue = dt.Rows(0)("Aux06")
            End If


            CheckBlanks()
        Catch ex As Exception
            Utilities.logErrorMessage("ProjectWizard.editSystemNumber-Load" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'If Not CheckData() Then
        '    MessageBox.Show("The system number you have entered already exists." + vbCr + "Please make changes and try again")
        '    Return
        'End If

        UpdateData()

        If Not Me.ParentMUID = Me.cbx_Parent.SelectedValue Then
            UpdateParent()
        End If

        Me.Dispose()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub


    Private Function CheckData() As Boolean
        Dim dt As DataTable = Nothing
        Dim query As String = "SELECT * FROM system_number " & _
        " WHERE Identifier = '" + SystemIdentifier.Text + "' AND Description = '" + SystemDescription.Text + "'"

        Try
            dt = SQLProject.ExecuteQuery(query)
        Catch ex As Exception
            MessageBox.Show("Failed to edit system number: " + ex.Message)
        End Try

        If Not dt.Rows.Count = 0 Then
            Return False
        End If

        Return True
    End Function


    Private Sub UpdateData()
        Dim query As String = "UPDATE system_number SET" & _
        " Identifier = @Identifier," & _
        " Description = @Description," & _
        " Aux09 = @ProjectNumber," & _
        " Aux08 = @ContractorMUID," & _
        " Aux07 = @Location," & _
        " Aux06 = @DisciplineMUID" & _
        " WHERE MUID = @MUID"

        Try
            Dim dt_param As DataTable = SQLProject.paramDT
            dt_param.Rows.Add("@Identifier", SystemIdentifier.Text)
            dt_param.Rows.Add("@Description", SystemDescription.Text)
            dt_param.Rows.Add("@ProjectNumber", Me.cbx_ProjectNumber.Text)
            dt_param.Rows.Add("@ContractorMUID", Me.cbx_Contractor.SelectedValue)
            dt_param.Rows.Add("@Location", Me.cbx_Location.Text)
            dt_param.Rows.Add("@DisciplineMUID", Me.cbx_Discipline.SelectedValue)
            dt_param.Rows.Add("@MUID", SystemID.ToString)


            'check to see if the Project Number exists, insert if not CODE::PNR
            Dim serverQuery As String = "SELECT * FROM SystemImages WHERE Code='PNR' AND Name='" + Me.cbx_ProjectNumber.Text + "'"
            Dim dt_Server As DataTable = runtime.SQLServer.ExecuteQuery(serverQuery)

            If dt_Server.Rows.Count = 0 Then
                serverQuery = "INSERT INTO SystemImages (MUID,TS,Name,Code) VALUES" & _
                            " (@MUID, @TS , @Name, @Code)"
                Dim dt_ServerParam As DataTable = runtime.SQLServer.paramDT
                dt_ServerParam.Rows.Add("@MUID", idUtils.GetNextMUID("server", "SystemImages"))
                dt_ServerParam.Rows.Add("@TS", Now())
                dt_ServerParam.Rows.Add("@Name", Me.cbx_ProjectNumber.Text)
                dt_ServerParam.Rows.Add("@Code", "PNR")

                runtime.SQLServer.ExecuteNonQuery(serverQuery, dt_ServerParam)
            End If

            'check to see if the Location exists, insert if not CODE::PLO
            serverQuery = "SELECT * FROM SystemImages WHERE Code='PLO' AND Name='" + Me.cbx_Location.Text + "'"
            dt_Server = runtime.SQLServer.ExecuteQuery(serverQuery)

            If dt_Server.Rows.Count = 0 Then
                serverQuery = "INSERT INTO SystemImages (MUID,TS,Name,Code) VALUES" & _
                            " (@MUID, @TS , @Name, @Code)"
                Dim dt_ServerParam As DataTable = runtime.SQLServer.paramDT
                dt_ServerParam.Rows.Add("@MUID", idUtils.GetNextMUID("server", "SystemImages"))
                dt_ServerParam.Rows.Add("@TS", Now())
                dt_ServerParam.Rows.Add("@Name", Me.cbx_Location.Text)
                dt_ServerParam.Rows.Add("@Code", "PLO")

                runtime.SQLServer.ExecuteNonQuery(serverQuery, dt_ServerParam)
            End If



            SQLProject.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Failed to add system number to table: " + ex.Message)
        End Try
    End Sub


    Private Sub UpdateParent()
        Try
            'Update Parent Link field
            Dim query As String = "UPDATE system_number SET" & _
            " ParentLinkMUID = @ParentLinkMUID" & _
            " WHERE MUID = @MUID"

            Dim dt_param As DataTable = SQLProject.paramDT
            dt_param.Rows.Add("@ParentLinkMUID", Me.cbx_Parent.SelectedValue)
            dt_param.Rows.Add("@MUID", SystemID.ToString)

            SQLProject.ExecuteNonQuery(query, dt_param)

            dt_param.Rows.Clear()
            'Update All Punchlist Item references to this system
            query = "UPDATE punchlist SET SystemMUID = (REPLACE(SystemMUID, '" + Me.ParentMUID + ";', '" + Me.cbx_Parent.SelectedValue + ";')) WHERE SystemMUID LIKE '%;" + SystemID + "'"
            runtime.SQLProject.ExecuteNonQuery(query, dt_param)

            'Update All Package references to this system
            query = "UPDATE package SET SystemMUID = (REPLACE(SystemMUID, '" + Me.ParentMUID + ";', '" + Me.cbx_Parent.SelectedValue + ";')) WHERE SystemMUID LIKE '%;" + SystemID + "'"
            runtime.SQLProject.ExecuteNonQuery(query, dt_param)



        Catch ex As Exception
            MessageBox.Show("Failed to modify Parent System: " + ex.Message)
        End Try
    End Sub

    Public Sub CheckBlanks()
        Dim hasValue As Boolean = True
        If SystemIdentifier.Text = "" Then
            hasValue = False
        End If
        If SystemDescription.Text = "" Then
            hasValue = False
        End If

        If (hasValue = False) Then
            OK_Button.Enabled = False
        Else
            OK_Button.Enabled = True
        End If
    End Sub


    Private Sub addSystemDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SystemDescription.TextChanged
        CheckBlanks()
    End Sub


    Private Sub addSystemIdentifier_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SystemIdentifier.TextChanged
        CheckBlanks()
    End Sub



End Class
