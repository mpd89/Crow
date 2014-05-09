Public Class ProjectImage
    Public ID As String
    Public TS As String
    Public DocumentID As String
    Public DocumentImage As Image


    Public Sub New()

    End Sub


    Public Sub New(ByVal dr As DataRow)
        Me.ID = dr(0).ToString
        Me.TS = dr(1).ToString
        Me.DocumentID = dr(2).ToString
        Me.DocumentImage = dr(4)
    End Sub

End Class
