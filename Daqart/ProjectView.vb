Imports daqartDLL
Imports System.Drawing.Printing
Imports System.Data.SqlServerCe

Public Class ProjectView
    Dim dtProjectStatus As New DataTable


    Private Sub ProjectView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Return
        'qlPrjUtils.OpenConnection()
        Dim clmns() As String = {"Owner", "System", "ReqdMhrs", "EarnedMhrs", "PcntComplete", "Status"}
        For i As Integer = 0 To clmns.Length - 1
            Dim dc As DataColumn = New DataColumn(clmns(i))
        Next
        Dim sqlSrvUtils As New DataUtils("server")
        sqlSrvUtils.OpenConnection()
        Dim query As String = "SELECT * From Projects"
        Dim prjdt As DataTable = sqlSrvUtils.ExecuteQuery(query)
        query = "SELECT * From owner"
        Dim ownerdt As DataTable = sqlSrvUtils.ExecuteQuery(query)
        For i As Integer = 0 To prjdt.Rows.Count - 1
            For j As Integer = 0 To ownerdt.Rows.Count - 1
                Dim sqlPrjUtils As New DataUtils("project")

            Next
        Next

        'sqlPrjUtils.CloseConnection()

    End Sub


End Class