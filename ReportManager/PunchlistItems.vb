Imports system.collections.generic

Public Class PunchlistItems : Inherits List(Of PunchlistItem)

End Class

Public Class PunchlistItem
    Dim _Project As String
    Dim _PunchlistID As String
    Dim _Description As String
    Dim _Status As String
    Dim _Priority As String
    Dim _TagNumber As String
    Dim _ListedBy As String
    Dim _ListedOn As String
    Dim _ApprovedBy As String
    Dim _ApprovedOn As String
    Dim _ClosedBy As String
    Dim _ClosedOn As String
    Dim _CompletedBy As String
    Dim _CompletedOn As String
    Dim _Comment As String
    Dim _Location As String
    Dim _ActionBy As String
    Dim _SHPriority As String
    Dim _RFI As String
    Dim _System As String
    Dim _SystemDescription As String
    Dim _TargetDate As String
    Dim _MCNumber As String
    Dim _MCDescription As String



    Public Property Project() As String
        Get
            Return _Project
        End Get
        Set(ByVal value As String)
            _Project = value
        End Set
    End Property

    Public Property PunchlistID() As String
        Get
            Return _PunchlistID
        End Get
        Set(ByVal value As String)
            _PunchlistID = value
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

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

    Public Property Priority() As String
        Get
            Return _Priority
        End Get
        Set(ByVal value As String)
            _Priority = value
        End Set
    End Property

    Public Property TagNumber() As String
        Get
            Return _TagNumber
        End Get
        Set(ByVal value As String)
            _TagNumber = value
        End Set
    End Property

    Public Property ListedBy() As String
        Get
            Return _ListedBy
        End Get
        Set(ByVal value As String)
            _ListedBy = value
        End Set
    End Property

    Public Property ListedOn() As String
        Get
            Return _ListedOn
        End Get
        Set(ByVal value As String)
            _ListedOn = value
        End Set
    End Property

    Public Property ApprovedBy() As String
        Get
            Return _ApprovedBy
        End Get
        Set(ByVal value As String)
            _ApprovedBy = value
        End Set
    End Property

    Public Property ApprovedOn() As String
        Get
            Return _ApprovedOn
        End Get
        Set(ByVal value As String)
            _ApprovedOn = value
        End Set
    End Property

    Public Property ClosedBy() As String
        Get
            Return _ClosedBy
        End Get
        Set(ByVal value As String)
            _ClosedBy = value
        End Set
    End Property

    Public Property ClosedOn() As String
        Get
            Return _ClosedOn
        End Get
        Set(ByVal value As String)
            _ClosedOn = value
        End Set
    End Property

    Public Property CompletedBy() As String
        Get
            Return _CompletedBy
        End Get
        Set(ByVal value As String)
            _CompletedBy = value
        End Set
    End Property

    Public Property CompletedOn() As String
        Get
            Return _CompletedOn
        End Get
        Set(ByVal value As String)
            _CompletedOn = value
        End Set
    End Property

    Public Property Comment() As String
        Get
            Return _Comment
        End Get
        Set(ByVal value As String)
            _Comment = value
        End Set
    End Property

    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = value
        End Set
    End Property

    Public Property ActionBy() As String
        Get
            Return _ActionBy
        End Get
        Set(ByVal value As String)
            _ActionBy = value
        End Set
    End Property

    Public Property SHPriority() As String
        Get
            Return _SHPriority
        End Get
        Set(ByVal value As String)
            _SHPriority = value
        End Set
    End Property

    Public Property RFI() As String
        Get
            Return _RFI
        End Get
        Set(ByVal value As String)
            _RFI = value
        End Set
    End Property

    Public Property System() As String
        Get
            Return _System
        End Get
        Set(ByVal value As String)
            _System = value
        End Set
    End Property

    Public Property SystemDescription() As String
        Get
            Return _SystemDescription
        End Get
        Set(ByVal value As String)
            _SystemDescription = value
        End Set
    End Property

    Public Property TargetDate() As String
        Get
            Return _TargetDate
        End Get
        Set(ByVal value As String)
            _TargetDate = value
        End Set
    End Property

    Public Property MCNumber() As String
        Get
            Return _MCNumber
        End Get
        Set(ByVal value As String)
            _MCNumber = value
        End Set
    End Property

    Public Property MCDescription() As String
        Get
            Return _MCDescription
        End Get
        Set(ByVal value As String)
            _MCDescription = value
        End Set
    End Property

End Class

