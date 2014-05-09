Imports daqartDLL


Public Class PackageAuditStats

    Private Sub PackageAuditStats_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim query As String = "SELECT Count(*) FROM package"
        Dim Count As Integer = runtime.SQLProject.ExecuteQuery(query).Rows(0)(0)
        Me.lbl_Total.Text = Count.ToString

        query = "SELECT Count(*) FROM package WHERE Aux08='True'"
        Count = runtime.SQLProject.ExecuteQuery(query).Rows(0)(0)
        Me.lbl_Passed.Text = Count.ToString

        query = "SELECT Count(*) FROM package WHERE Aux08='False'"
        Count = runtime.SQLProject.ExecuteQuery(query).Rows(0)(0)
        Me.lbl_Failed.Text = Count.ToString

        query = "SELECT Count(*) FROM package WHERE Aux08 IS NULL"
        Count = runtime.SQLProject.ExecuteQuery(query).Rows(0)(0)
        Me.lbl_NotAudited.Text = Count.ToString


    End Sub
End Class