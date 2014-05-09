Public Class working


    Private Sub Timer1_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed

        Dim ProgressValue As Integer = ProgressBar1.Value

        If ProgressValue < 100 Then
            ProgressValue += 1
        Else
            ProgressValue = 0
        End If


    End Sub


End Class