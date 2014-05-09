Public Class DesktopIcon

    Private Sub pbx_Icon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Icon.Click
        Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    End Sub

    Private Sub pbx_Icon_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Icon.DoubleClick
        MessageBox.Show("open System View.")
    End Sub


    Private Sub pbx_Icon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbx_Icon.LostFocus
        Me.BorderStyle = Windows.Forms.BorderStyle.None
    End Sub



End Class
