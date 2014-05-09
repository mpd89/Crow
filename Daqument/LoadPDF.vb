Imports daqartDLL
Public Class LoadPDF

    Private Sub FolderBrowserDialog1_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FolderBrowserDialog1.HelpRequest

    End Sub

    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.Click
        Try

            OpenFD.InitialDirectory = "C:\"
            OpenFD.Title = "Open a File"
            OpenFD.FileName = ""
            OpenFD.ShowDialog()
            txtBrowse.Text = OpenFD.FileName
            If (OpenFD.FileName <> "") Then
                btnNext.Enabled = True
            Else
                btnNext.Enabled = False
            End If
        Catch ex As Exception
            Utilities.logErrorMessage("Daqument.LoadPDF.btnBrowse_Click-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub LoadPDF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MessageBox.Show(lblTag.Text.ToString)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try

            If (txtBrowse.Text = "") Then
                MessageBox.Show("Please select the file")
            Else

                DocumentPDF.WBPDf.Navigate(txtBrowse.Text)
                DocumentPDF.txtSource.Text = txtBrowse.Text
                'Me.Close()
                DocumentPDF.lblTag.Text = lblTag.Text
                DocumentPDF.Show()

                Me.Dispose()
            End If
        Catch ex As Exception
            Utilities.logErrorMessage("Daqument.LoadPDF.btnNext_Click-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class