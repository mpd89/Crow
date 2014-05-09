Imports DaqartDLL
Public Class Taglist
    Dim PackageID As Integer
    Public Shared SelectedTag As Integer
    Public Shared SelectedTagName As String


    Public Sub New(ByVal thisPackageID As Integer)

        InitializeComponent()

        PackageID = thisPackageID

    End Sub

    Private Sub Taglist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = " Select * FROM tags WHERE PackageMUID='" & PackageID & "'"
        'Dim dt As DataTable = daqartDLL.Utilities.ExecuteQuery(query, "project")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        lbx_TagSelect.DataSource = dt
        lbx_TagSelect.DisplayMember = dt.Columns(2).ToString
        lbx_TagSelect.ValueMember = dt.Columns(0).ToString

        lbx_TagSelect.SelectedItem = 0

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SelectedTag = 0
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        SelectedTag = lbx_TagSelect.SelectedValue
        SelectedTagName = lbx_TagSelect.Text

        Me.Close()

    End Sub

End Class