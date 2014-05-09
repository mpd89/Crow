Public Class Calendar
    Public Shared datev As Date

    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        MonthCalendar1.MaxSelectionCount = 1
        'To display single date use MonthCalendar1.SelectionRange.Start/ MonthCalendarSelectionRange.End
        'MessageBox.Show("Date Selected :" & MonthCalendar1.SelectionRange.Start)
        'AddPunchlist.
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.OK
        datev = MonthCalendar1.SelectionRange.Start
        txt_Date.Text = datev
        'PunchlistDataManager.datec = datev.ToString
        Close()
    End Sub

    Private Sub Calendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txt_Date.Text = ""
        Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Dispose()
    End Sub
End Class