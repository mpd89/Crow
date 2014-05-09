

Public Class ViewChangeLog

    Private Sub ViewChangeLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.RichTextBox1.Text = My.Resources.ChangeLog.ToString
    End Sub
End Class