Public Class DocumentPDF

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        'MessageBox.Show(WBPDf.Url.ToString)
        'FrmSave.WebBrowser1.Navigate(txtSource.Text)
      FrmSave.txtSource.Text = txtSource.Text
      FrmSave.lblTag.Text = lblTag.Text
        FrmSave.Show()

        Me.Dispose()

    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Me.Close()
    End Sub

    Private Sub DocumentPDF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class