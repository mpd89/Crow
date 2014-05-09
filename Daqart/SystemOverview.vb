Public Class SystemOverview
    Public MyOwnerName As String
    Public MyOwnerID As Integer


    Private Sub dgv_Packages_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Packages.CellDoubleClick

        PackageViewer.PackageViewerManager.OpenPackage(dgv_Packages.Rows(e.RowIndex).Cells(0).Tag, dgv_Packages.Rows(e.RowIndex).Cells(0).Value)

        'MessageBox.Show(dgv_Packages.Rows(e.RowIndex).Cells(0).Tag & " - " & dgv_Packages.Rows(e.RowIndex).Cells(0).Value)


    End Sub

End Class
