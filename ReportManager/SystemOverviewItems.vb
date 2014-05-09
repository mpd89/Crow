Imports system.collections.generic

Public Class SystemOverviewItems : Inherits List(Of SystemOverviewItem)

End Class

Public Class SystemOverviewItem

    ' Parent properties
    Dim _PackageNumber As String
    Dim _Description As String
    Dim _Discipline As String
    Dim _EarnedMH As Double
    Dim _RequiredMH As Double
    Dim _PercentComplete As Double

    Public Property PackageNumber() As String
        Get
            Return _PackageNumber
        End Get
        Set(ByVal value As String)
            _PackageNumber = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Public Property Discipline() As String
        Get
            Return _Discipline
        End Get
        Set(ByVal value As String)
            _Discipline = value
        End Set
    End Property

    Public Property EarnedMH() As Double
        Get
            Return _EarnedMH
        End Get
        Set(ByVal value As Double)
            _EarnedMH = value
        End Set
    End Property

    Public Property RequiredMH() As Double
        Get
            Return _RequiredMH
        End Get
        Set(ByVal value As Double)
            _RequiredMH = value
        End Set
    End Property

    Public Property PercentComplete() As Double
        Get
            Return _PercentComplete
        End Get
        Set(ByVal value As Double)
            _PercentComplete = value
        End Set
    End Property
End Class
