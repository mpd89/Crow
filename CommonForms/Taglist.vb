Public Class Taglist
    Dim PackageID As String
    Public Shared SelectedTag As String
    Public Shared SelectedTagName As String
    Private sqlPrjUtils As daqartDLL.DataUtils = New daqartDLL.DataUtils("project")


    Public Sub New(ByVal thisPackageID As String)
        InitializeComponent()

        PackageID = thisPackageID
    End Sub


    Private Sub Taglist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = " Select * FROM tags WHERE PackageMUID='" & PackageID & "'"
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        lbx_TagSelect.DataSource = dt
        lbx_TagSelect.DisplayMember = dt.Columns("TagNumber").ToString
        lbx_TagSelect.ValueMember = dt.Columns("MUID").ToString
        lbx_TagSelect.SelectedItem = 0
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SelectedTag = ""
        Me.Dispose()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SelectedTag = lbx_TagSelect.SelectedValue
        SelectedTagName = lbx_TagSelect.Text

        Me.Close()
    End Sub

End Class