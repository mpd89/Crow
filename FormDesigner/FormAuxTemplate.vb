Imports System.Windows.Forms
Imports daqartDLL
Public Class FormAuxTemplate
    'Private useProjectDB As String = "USE [" + Runtime.selectedProject + "] "
    Private TagTemplateDT As DataTable
    Private PkgTemplateDT As DataTable
    Private SelectedFormID As String


    Public Sub New(ByVal formID As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        SelectedFormID = formID
    End Sub

    Private Sub PopulateTemplateName()
        Dim qry = "SELECT MUID,TemplateName FROM aux_template WHERE Type = 'Tag' ORDER BY TemplateName DESC"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        TagTemplateDT = sqlPrjUtils.ExecuteQuery(qry)

        'TagTemplateDT = Utilities.ExecuteRemoteQuery(qry, "")
        If TagTemplateDT.Rows.Count > 0 Then
            For i As Integer = 0 To TagTemplateDT.Rows.Count - 1
                Me.lvwTagTemplateList.Items.Add(TagTemplateDT.Rows(i)("TemplateName"))
            Next
        End If
        qry = "SELECT MUID,TemplateName FROM aux_template WHERE Type = 'Package' ORDER BY TemplateName DESC"
        'PkgTemplateDT = Utilities.ExecuteRemoteQuery(qry, "")
        PkgTemplateDT = sqlPrjUtils.ExecuteQuery(qry)
        If PkgTemplateDT.Rows.Count > 0 Then
            For i As Integer = 0 To PkgTemplateDT.Rows.Count - 1
                Me.lvwPkgTemplateList.Items.Add(PkgTemplateDT.Rows(i)("TemplateName"))
            Next
        End If
        sqlPrjUtils.CloseConnection()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim qry As String = ""
        Try
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()

            If Me.tbxTagTemplateName.Text > "" Then
                Dim id = Me.tbxTagTemplateName.Tag
                If id > "" Then
                    qry = " Update Forms Set TagTemplateMUID = @TagTemplateMUID" + _
                        " WHERE MUID = @MUID"

                    Dim dt_param As DataTable = sqlPrjUtils.paramDT
                    dt_param.Rows.Add("@TagTemplateMUID", id.ToString)
                    dt_param.Rows.Add("@MUID", SelectedFormID.ToString)

                    sqlPrjUtils.ExecuteNonQuery(qry, dt_param)

                End If
            End If
            If Me.tbxPkgTemplateName.Text > "" Then
                Dim id = Me.tbxPkgTemplateName.Tag
                If id > "" Then
                    qry = " Update Forms Set PackageTemplateMUID = @PackageTemplateMUID" + _
                        " WHERE MUID = @MUID"

                    Dim dt_param As DataTable = sqlPrjUtils.paramDT
                    dt_param.Rows.Add("@PackageTemplateMUID", id.ToString)
                    dt_param.Rows.Add("@MUID", SelectedFormID.ToString)

                    sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                End If
            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            sqlPrjUtils.CloseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End Try
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FormAuxTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateTemplateName()
    End Sub

    Private Sub lvwPkgTemplateList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwPkgTemplateList.SelectedIndexChanged
        Dim id As String = ""
        For i As Integer = 0 To lvwPkgTemplateList.Items.Count - 1
            If lvwPkgTemplateList.GetSelected(i) Then
                Dim template = lvwPkgTemplateList.Items(i)
                For j As Integer = 0 To PkgTemplateDT.Rows.Count - 1
                    If PkgTemplateDT.Rows(i)("TemplateName") = template Then
                        id = PkgTemplateDT.Rows(i)("MUID")
                        Exit For
                    End If
                Next
                If id > "" Then
                    Me.tbxPkgTemplateName.Text = template
                    Me.tbxPkgTemplateName.Tag = id
                End If
                Return
            End If
        Next
    End Sub

    Private Sub lvwTagTemplateList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwTagTemplateList.SelectedIndexChanged
        Dim id As String = ""
        For i As Integer = 0 To lvwTagTemplateList.Items.Count - 1
            If lvwTagTemplateList.GetSelected(i) Then
                Dim template = lvwTagTemplateList.Items(i)
                For j As Integer = 0 To TagTemplateDT.Rows.Count - 1
                    If TagTemplateDT.Rows(i)("TemplateName") = template Then
                        id = TagTemplateDT.Rows(i)("MUID")
                        Exit For
                    End If
                Next
                If id > "" Then
                    Me.tbxTagTemplateName.Text = template
                    Me.tbxTagTemplateName.Tag = id
                End If
                Return
            End If
        Next
    End Sub
End Class
