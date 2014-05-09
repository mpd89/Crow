Public Class Calendar
    Public Shared datev As String
    Public Shared action As String

    Private Sub Calendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        MonthCalendar1.MaxSelectionCount = 1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        action = "OK"
        DialogResult = Windows.Forms.DialogResult.OK
        datev = MonthCalendar1.SelectionRange.Start
        txt_Date.Text = datev
        Close()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        action = "Clear"
        datev = ""
        txt_Date.Text = ""
        Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        action = "Cancel"
        Me.Dispose()
    End Sub
End Class