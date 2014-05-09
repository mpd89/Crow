Imports daqartDLL
Imports System.Data


Public Class OwnerSelect
    Public Shared OwnerMUID As String

    Private Sub OwnerSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM owner ORDER BY Name ASC"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Me.cbx_Owners.DataSource = dt
        Me.cbx_Owners.ValueMember = dt.Columns("MUID").ToString
        Me.cbx_Owners.DisplayMember = dt.Columns("Name").ToString
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        OwnerMUID = Me.cbx_Owners.SelectedValue
        Me.Close()
    End Sub

End Class