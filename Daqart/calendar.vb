Public Class calendar

    '/* 風覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧藍
    ' |                                                                                                            |
    ' |     Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click |
    ' |                                                                                                            |
    ' |                                                                                                            |
    ' |         Dim thisDate As String                                                                             |
    ' |                                                                                                            |
    ' |         Dim thisPunchlist As New PunchlistManager.PunchlistDataManager                                     |
    ' |                                                                                                            |
    ' |         thisDate = PunchlistManager.PunchlistDataManager.GetDate()                                         |
    ' |                                                                                                            |
    ' |                                                                                                            |
    ' |         TextBox1.Text = thisDate                                                                           |
    ' |                                                                                                            |
    ' |                                                                                                            |
    ' |     End Sub                                                                                                |
    ' |                                                                                                            |
    '風覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧藍 */


    Private Sub calendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class