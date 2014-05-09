Imports daqartDLL


Public Class ManageRequirements
    Public RequirementID As String
    Public RequirementMode As String
    Public MultiElement As Boolean
    Private Loading As Boolean


    Private Sub ManageRequirements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Loading = True

            OwnerBox.DataSource = Utilities.GetOwners()
            OwnerBox.DisplayMember = Utilities.GetOwners().Columns(2).ToString
            OwnerBox.ValueMember = Utilities.GetOwners().Columns(0).ToString

            EquipmentBox.DataSource = GetTypes()
            EquipmentBox.DisplayMember = GetTypes().Columns(2).ToString
            EquipmentBox.ValueMember = GetTypes().Columns(0).ToString

            FormBox.DataSource = GetForms()
            FormBox.DisplayMember = GetForms().Columns(2).ToString
            FormBox.ValueMember = GetForms().Columns(0).ToString

            If Not GetRecord().Rows.Count = 0 Then
                If Not IsDBNull(GetRecord().Rows(0)(5)) Then
                    tbx_ManHours.Text = GetRecord().Rows(0)(5)
                End If
            End If

            Loading = False

            If RequirementMode = "Edit" Then
                Populate()
            End If

        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.ManageRequirements._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Populate()
        Dim i As Integer
        For i = 0 To Utilities.GetOwners().Rows.Count - 1
            If Utilities.GetOwners().Rows(i)(0) = GetRecord().Rows(0)(2) Then
                OwnerBox.SelectedIndex = i
            End If
        Next

        For i = 0 To GetTypes().Rows.Count - 1
            If GetTypes().Rows(i)(0) = GetRecord().Rows(0)(3) Then
                EquipmentBox.SelectedIndex = i
            End If
        Next

        For i = 0 To GetForms().Rows.Count - 1
            If GetForms().Rows(i)(0) = GetRecord().Rows(0)(4) Then
                FormBox.SelectedIndex = i
            End If
        Next

        Dim query As String = "Select * From requirements WHERE MUID='" + RequirementID + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            tbx_ElementMH.Text = dt.Rows(0)(6)
        End If
    End Sub


    Private Function GetRecord() As DataTable
        Dim query As String = "Select * From requirements WHERE MUID='" + RequirementID + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Return dt
    End Function


    Private Function GetTypes() As DataTable
        Dim query As String = "Select * From equipment_type ORDER BY TypeName ASC"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Return dt
    End Function


    Private Function GetForms() As DataTable
        Dim query As String = "Select * From forms WHERE SystemForm != '1' ORDER BY Name ASC"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Return dt
    End Function


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim query As String = Nothing
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim dt_param As DataTable = sqlPrjUtils.paramDT

        If RequirementMode = "Edit" Then
            query = "UPDATE requirements SET OwnerMUID=@OwnerMUID, " & _
                  " TypeMUID=@TypeMUID, " & _
                  " FormMUID=@FormMUID, " & _
                  " ManHours=@ManHours, " & _
                  " MEManHours=@MEManHours " & _
                  " WHERE MUID=@MUID"

            dt_param.Rows.Add("@OwnerMUID", CInt(OwnerBox.SelectedValue).ToString)
            dt_param.Rows.Add("@TypeMUID", CInt(EquipmentBox.SelectedValue).ToString)
            dt_param.Rows.Add("@FormMUID", CInt(FormBox.SelectedValue).ToString)
            dt_param.Rows.Add("@ManHours", tbx_ManHours.Text)
            dt_param.Rows.Add("@MEManHours", tbx_ElementMH.Text)
            dt_param.Rows.Add("@MUID", RequirementID)
        End If

        If RequirementMode = "Add" Then
            query = "INSERT INTO requirements (MUID,TS,OwnerMUID," & _
                " TypeMUID,FormMUID,ManHours,MEManHours) VALUES (" & _
                " @MUID," & _
                " @TS," & _
                " @OwnerMUID," & _
                " @TypeMUID," & _
                " @FormMUID," & _
                " @ManHours, " & _
                " @MEManHours)"

            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "requirements"))
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@OwnerMUID", CInt(OwnerBox.SelectedValue).ToString)
            dt_param.Rows.Add("@TypeMUID", CInt(EquipmentBox.SelectedValue).ToString)
            dt_param.Rows.Add("@FormMUID", CInt(FormBox.SelectedValue).ToString)
            dt_param.Rows.Add("@ManHours", CInt(tbx_ManHours.Text).ToString)
            dt_param.Rows.Add("@MEManHours", tbx_ElementMH.Text)
        End If

        sqlPrjUtils.OpenConnection()
        sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        sqlPrjUtils.CloseConnection()

        Me.Dispose()
    End Sub


    Private Sub FormBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormBox.SelectedIndexChanged
        If Loading Then Return

        Dim query As String = "Select * From forms WHERE MUID = '" + FormBox.SelectedValue.ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            If Not IsDBNull(dt.Rows(0)(8)) Then
                If dt.Rows(0)(8) = 1 Then
                    MultiElement = True
                    lbl_ElementMH1.Visible = True
                    lbl_ElementMH2.Visible = True
                    lbl_ElementMH3.Visible = True
                    tbx_ElementMH.Visible = True
                Else
                    MultiElement = False
                    lbl_ElementMH1.Visible = False
                    lbl_ElementMH2.Visible = False
                    lbl_ElementMH3.Visible = False
                    tbx_ElementMH.Visible = False
                    tbx_ElementMH.Text = ""
                End If
            End If
        End If
    End Sub




End Class