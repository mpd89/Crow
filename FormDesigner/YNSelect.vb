Public Class YNSelect
    Public FinalValue As String
    Dim InitialValue As String


    Public Sub New(ByVal _Value As String)
        InitializeComponent()

        InitialValue = _Value
    End Sub

    Private Sub YNSelect_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If InitialValue = "Yes" Then
            Me.btn_Yes.Select()
        End If
        If InitialValue = "No" Then
            Me.btn_No.Select()
        End If
        If InitialValue = "NA" Then
            Me.btn_NA.Select()
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btn_Yes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Yes.Click
        FinalValue = "Yes"
        Me.Close()
    End Sub

    Private Sub btn_No_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_No.Click
        FinalValue = "No"
        Me.Close()
    End Sub

    Private Sub btn_NA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NA.Click
        FinalValue = "NA"
        Me.Close()
    End Sub

    Private Sub btn_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Clear.Click
        FinalValue = ""
        Me.Close()
    End Sub
End Class