Imports daqartDLL

Public Class CustomMenu

    Private Sub tlp_Custom1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim frm_FormSelect As New CommonForms.FormSelect
        frm_FormSelect.ShowDialog()

        Dim FormID As String = frm_FormSelect.FormID
        Dim OwnerID As String = frm_FormSelect.OwnerID

        If FormID > 0 Then
            Cursor = Cursors.AppStarting

            Dim cls_Export As New CommonForms.SingleElementFormDataExport(FormID, OwnerID)
            Dim dt As DataTable = cls_Export.MakeDT

            Dim frm_ShowExport As New CommonForms.DataExport(dt)
            Cursor = Cursors.Default
            frm_ShowExport.Show()

        End If


    End Sub

End Class