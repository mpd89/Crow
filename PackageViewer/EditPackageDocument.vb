Imports daqartDLL

Public Class EditPackageDocument
    Dim DocumentID As String
    Dim PackageID As String
    Dim DataRecord As DataTable


    Public Sub New(ByVal thisDocument As String, ByVal thisPackage As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DocumentID = thisDocument
        PackageID = thisPackage

    End Sub


    Private Sub EditPackageDocument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            GetAssociationRecord()


            PopulateTagList()

            If Not IsDBNull(DataRecord.Rows(0)("Notes")) Then
                tbx_Notes.Text = DataRecord.Rows(0)("Notes")
            End If

        Catch ex As Exception
            Utilities.logErrorMessage("PackageViewer.EditPackageDocument._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub GetAssociationRecord()
        Dim query As String = "Select * From package_documents WHERE DocumentMUID='" & DocumentID & "' AND PackageMUID = '" & PackageID & "'"
        'DataRecord = Utilities.ExecuteQuery(query, "project")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        DataRecord = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()



    End Sub


    Private Sub PopulateTagList()
        Dim query As String = "SELECT MUID,TagNumber FROM tags WHERE PackageMUID = '" & PackageViewerManager.SelectedPackageID & "' ORDER BY TagNumber ASC"
        'Dim dt As DataTable = Utilities.ExecuteQuery(query, "project")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Dim dt2 As New DataTable

        dt2.Columns.Add("MUID")
        dt2.Columns.Add("TagNumber")
        dt2.Rows.Add()
        dt2.Rows(0)(0) = "0"
        dt2.Rows(0)(1) = "*"


        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            dt2.Rows.Add()
            dt2.Rows(i + 1)("MUID") = dt.Rows(i)("MUID")
            dt2.Rows(i + 1)("TagNumber") = dt.Rows(i)("TagNumber")
        Next

        cbx_TagList.DataSource = dt2
        cbx_TagList.DisplayMember = dt2.Columns(1).ToString
        cbx_TagList.ValueMember = dt2.Columns(0).ToString

        cbx_TagList.SelectedValue = DataRecord.Rows(0)("TagMUID")

    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        'Dim query As String = "UPDATE package_documents SET Notes = '" & tbx_Notes.Text & _
        '    "', Aux10 = '" & cbx_TagList.SelectedValue & "' WHERE ID='" & DataRecord.Rows(0)(0) & "'"
        ''Utilities.ExecuteQuery(query, "project")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim query As String = "UPDATE package_documents SET Notes = @Notes" + _
                    "TagMUID = @TagMUID WHERE MUID= @MUID"
        Dim dt_param As DataTable = sqlPrjUtils.paramDT

        dt_param.Rows.Add("@Notes", tbx_Notes.Text)
        dt_param.Rows.Add("@TagMUID", Me.cbx_TagList.SelectedValue)
        dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "package_documents"))

        sqlPrjUtils.OpenConnection()
        sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        sqlPrjUtils.CloseConnection()


        Me.Dispose()
    End Sub


End Class