Imports daqartDLL
Imports Daqument


Public Class AddPackageDocument
    Dim dt_DocumentList As New DataTable
    Public ThisSystem As String
    Dim Loading As Boolean = True
    Dim dt_Selected As New DataTable

    Public Sub New(ByVal _SystemID As String)
        InitializeComponent()

        ThisSystem = _SystemID
    End Sub


    Private Sub AddPackageDocument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.rbn_Engineering.Checked = True
            PopulateTagList()
            PopulateDocumentList()

            Me.dt_Selected.Columns.Add("DocumentMUID")
            Me.dt_Selected.Columns.Add("DocumentNumber")
            Me.dt_Selected.Columns.Add("TagMUID")
            Me.dt_Selected.Columns.Add("Notes")


            Loading = False
        Catch ex As Exception
            Utilities.logErrorMessage("PackageViewer.AddPackageDocument._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub PopulateTagList()
        Dim query As String = "SELECT MUID,TagNumber FROM tags WHERE PackageMUID = '" & PackageViewerManager.SelectedPackageID & "' ORDER BY TagNumber ASC"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        Dim dt2 As New DataTable
        dt2.Columns.Add("MUID")
        dt2.Columns.Add("TagNumber")
        dt2.Rows.Add()
        dt2.Rows(0)(0) = "0"
        dt2.Rows(0)(1) = "*"

        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            dt2.Rows.Add()
            dt2.Rows(i + 1)(0) = dt.Rows(i)(0)
            dt2.Rows(i + 1)(1) = dt.Rows(i)(1)
        Next

        cbx_TagList.DataSource = dt2
        cbx_TagList.DisplayMember = dt2.Columns(1).ToString
        cbx_TagList.ValueMember = dt2.Columns(0).ToString
        cbx_TagList.SelectedIndex = 0
    End Sub


    Private Sub PopulateDocumentCategory()
        Dim query As String = "SELECT MUID,Code, Description,  Code + ' - ' + Description As ShowThis FROM document_type WHERE Code != 'UDF' AND ParentMUID = '0' ORDER BY Code ASC"
        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        'sqlDocUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(query)
        'sqlDocUtils.CloseConnection()

        Dim dt2 As New DataTable
        dt2.Columns.Add("MUID")
        dt2.Columns.Add("Code")
        dt2.Columns.Add("Description")
        dt2.Rows.Add()
        dt2.Rows(0)("MUID") = "0"
        dt2.Rows(0)("Code") = "*"
        dt2.Rows(0)("Description") = "*"

        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            dt2.Rows.Add()
            dt2.Rows(i + 1)("MUID") = dt.Rows(i)("MUID")
            dt2.Rows(i + 1)("Code") = dt.Rows(i)("Description")
            dt2.Rows(i + 1)("Description") = dt.Rows(i)("ShowThis")
        Next

        cbx_DocumentCategory.DataSource = dt2
        cbx_DocumentCategory.DisplayMember = "Code"
        cbx_DocumentCategory.ValueMember = "MUID"

        cbx_DocumentCategory.SelectedIndex = 0

    End Sub


    Private Sub PopulateDocumentList()
        Dim query As String
        Dim CategoryID As String = Me.tbx_documentType.Tag
        dt_DocumentList = New DataTable
        Dim OrderStr As String = " ORDER BY EngCode ASC "
        If Me.rbn_Client.Checked Then
            OrderStr = " Order By ClientCode "
        End If
        If Me.rbn_Engineering.Checked Then
            OrderStr = " Order By EngCode "
        End If

        dt_DocumentList.Columns.Add("DocumentID")
        dt_DocumentList.Columns.Add("EngCode")
        dt_DocumentList.Columns.Add("ClientCode")

        If CategoryID = "" Then
            query = "SELECT MUID, EngCode + ', Sht ' + Sheet As ShowEng, ClientCode + ', Sht ' + Sheet As ShowClient  FROM documents " & _
            " WHERE ProjectMUID = '" & Utilities.GetProjectID(runtime.selectedProject).ToString & "'" + OrderStr
        Else
            query = "SELECT MUID, EngCode + ', Sht ' + Sheet As ShowEng, ClientCode + ', Sht ' + Sheet As ShowClient FROM documents WHERE DocumentTypeMUID = '" & CategoryID + "' " & _
            " AND ProjectMUID = '" & Utilities.GetProjectID(runtime.selectedProject) & "'" + OrderStr
        End If

        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
        'sqlDocUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(query)
        'sqlDocUtils.CloseConnection()

        If Not Me.lbx_DocumentList Is Nothing Then
            Me.lbx_DocumentList.ClearSelected()
        End If

        Me.lbx_DocumentList.Visible = True
        lbx_DocumentList.DataSource = dt
        If Me.rbn_Client.Checked Then
            lbx_DocumentList.DisplayMember = dt.Columns(2).ToString
        End If
        If Me.rbn_Engineering.Checked Then
            lbx_DocumentList.DisplayMember = dt.Columns(1).ToString
        End If

        lbx_DocumentList.ValueMember = "MUID"
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Close()
    End Sub


    Private Sub cbx_DocumentCategory_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_DocumentCategory.SelectedValueChanged
        If Loading Then Return
        PopulateDocumentList()
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        For Each dr As DataRow In Me.dt_Selected.Rows
            If Not PackageUtils.TestPackageDocument(PackageViewerManager.SelectedPackageID, lbx_DocumentList.SelectedValue) Then
                Dim query As String = "INSERT INTO package_documents (MUID,TS,DocumentMUID,PackageMUID,Notes,TagMUID,SystemMUID) " & _
                    " Values (@MUID,@TS,@DocumentMUID,@PackageMUID,@Notes,@TagMUID,@SystemMUID)"
                'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
                Dim dt_param As DataTable = runtime.SQLProject.paramDT
                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "Package_documents"))
                dt_param.Rows.Add("@TS", DateTime.Now.ToString)
                dt_param.Rows.Add("@DocumentMUID", dr("DocumentMUID"))
                dt_param.Rows.Add("@PackageMUID", PackageViewerManager.SelectedPackageID)
                dt_param.Rows.Add("@Notes", dr("Notes"))
                dt_param.Rows.Add("@TagMUID", dr("TagMUID"))
                dt_param.Rows.Add("@SystemMUID", ThisSystem.ToString)

                'sqlPrjUtils.OpenConnection()
                runtime.SQLProject.ExecuteNonQuery(query, dt_param)
                'sqlPrjUtils.CloseConnection()
            Else
                MessageBox.Show("This document is already associated to this package.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Next

        Me.Dispose()
    End Sub


    Private Sub rbn_Client_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbn_Client.CheckedChanged
        If Loading Then Return
        PopulateDocumentList()
    End Sub

 
    Private Sub rbn_Engineering_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbn_Engineering.CheckedChanged
        If Loading Then Return
        PopulateDocumentList()
    End Sub


    Private Sub TextBox1_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_documentType.Click
        Dim frm_Defaults As New DaqumentImportDefaults
        If frm_Defaults.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        Me.tbx_documentType.Tag = frm_Defaults.DefaultTypeID
        Me.tbx_documentType.Text = frm_Defaults.DefaultTypeName

        PopulateDocumentList()
    End Sub


    Private Sub btn_AddToList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddToList.Click
        Try
            Dim Existing As Boolean = False

            For Each dr As DataRow In dt_Selected.Rows
                If dr("DocumentMUID") = Me.lbx_DocumentList.SelectedValue Then
                    Existing = True
                End If
            Next

            If Not Existing Then
                Me.dt_Selected.Rows.Add(Me.lbx_DocumentList.SelectedValue, Me.lbx_DocumentList.Text, Me.cbx_TagList.SelectedValue, Me.tbx_Notes.Text)

                Me.lbx_References.DataSource = Me.dt_Selected
                Me.lbx_References.DisplayMember = Me.dt_Selected.Columns("DocumentNumber").ToString
                Me.lbx_References.ValueMember = Me.dt_Selected.Columns("DocumentMUID").ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btn_RemoveFromList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RemoveFromList.Click
        Try

            Dim dtCount As Integer = dt_Selected.Rows.Count
            For i As Integer = 0 To dtCount - 1
                If dt_Selected.Rows(i)("DocumentMUID") = Me.lbx_References.SelectedValue Then

                    Me.dt_Selected.Rows.Remove(dt_Selected.Rows(i))
                    dtCount -= 1

                    Me.lbx_References.DataSource = Me.dt_Selected
                    Me.lbx_References.DisplayMember = Me.dt_Selected.Columns("DocumentNumber").ToString
                    Me.lbx_References.ValueMember = Me.dt_Selected.Columns("DocumentMUID").ToString
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub lbx_References_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbx_References.SelectedIndexChanged
        If Loading Then Return
        If dt_Selected.Rows.Count < 2 Then Return

        Try
            For Each dr As DataRow In dt_Selected.Rows
                If dr("DocumentMUID") = Me.lbx_References.SelectedValue Then
                    Me.cbx_TagList.SelectedValue = dr("TagMUID")
                    Me.tbx_Notes.Text = dr("Notes")
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub tbx_Notes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_Notes.TextChanged
        If Loading Then Return

        For Each dr As DataRow In dt_Selected.Rows
            If dr("DocumentMUID") = Me.lbx_References.SelectedValue Then
                dr("Notes") = Me.tbx_Notes.Text
            End If
        Next
    End Sub


    Private Sub cbx_TagList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_TagList.SelectedIndexChanged
        If Loading Then Return

        For Each dr As DataRow In dt_Selected.Rows
            If dr("DocumentMUID") = Me.lbx_References.SelectedValue Then
                dr("TagMUID") = Me.cbx_TagList.SelectedValue
            End If
        Next
    End Sub
End Class