Imports system.collections.generic

Public Class TurnoverItems : Inherits List(Of TurnoverItem)

End Class


Public Class TurnoverItem
    Dim _ProjectName As String
    Dim _ProjectMUID As String
    Dim _SH_MUID As String
    Dim _SHNumber As String
    Dim _SH_Description As String
    Dim _MC_Description As String
    Dim _Disc As String
    Dim _ProjectNumber As String
    Dim _Contractor As String
    Dim _Location As String
    Dim _MC_MUID As String
    Dim _MCNumber As String
    Dim _MC_Sent As String
    Dim _IWL_Start As String
    Dim _MC_Signed As String
    Dim _SH_Sent As String
    Dim _SH_Signed As String


    Public Property ProjectName() As String
        Get
            Return _ProjectName
        End Get
        Set(ByVal value As String)
            _ProjectName = value
        End Set
    End Property

    Public Property ProjectMUID() As String
        Get
            Return _ProjectMUID
        End Get
        Set(ByVal value As String)
            _ProjectMUID = value
        End Set
    End Property

    Public Property SH_MUID() As String
        Get
            Return _SH_MUID
        End Get
        Set(ByVal value As String)
            _SH_MUID = value
        End Set
    End Property

    Public Property SH_Description() As String
        Get
            Return _SH_Description
        End Get
        Set(ByVal value As String)
            _SH_Description = value
        End Set
    End Property

    Public Property SHNumber() As String
        Get
            Return _SHNumber
        End Get
        Set(ByVal value As String)
            _SHNumber = value
        End Set
    End Property

    Public Property MC_MUID() As String
        Get
            Return _MC_MUID
        End Get
        Set(ByVal value As String)
            _MC_MUID = value
        End Set
    End Property

    Public Property MC_Description() As String
        Get
            Return _MC_Description
        End Get
        Set(ByVal value As String)
            _MC_Description = value
        End Set
    End Property

    Public Property Disc() As String
        Get
            Return _Disc
        End Get
        Set(ByVal value As String)
            _Disc = value
        End Set
    End Property

    Public Property ProjectNumber() As String
        Get
            Return _ProjectNumber
        End Get
        Set(ByVal value As String)
            _ProjectNumber = value
        End Set
    End Property

    Public Property Contractor() As String
        Get
            Return _Contractor
        End Get
        Set(ByVal value As String)
            _Contractor = value
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

    Public Property MCNumber() As String
        Get
            Return _MCNumber
        End Get
        Set(ByVal value As String)
            _MCNumber = value
        End Set
    End Property

    Public Property MC_Sent() As String
        Get
            Return _MC_Sent
        End Get
        Set(ByVal value As String)
            _MC_Sent = value
        End Set
    End Property

    Public Property IWL_Start() As String
        Get
            Return _IWL_Start
        End Get
        Set(ByVal value As String)
            _IWL_Start = value
        End Set
    End Property

    Public Property MC_Signed() As String
        Get
            Return _MC_Signed
        End Get
        Set(ByVal value As String)
            _MC_Signed = value
        End Set
    End Property

    Public Property SH_Sent() As String
        Get
            Return _SH_Sent
        End Get
        Set(ByVal value As String)
            _SH_Sent = value
        End Set
    End Property

    Public Property SH_Signed() As String
        Get
            Return _SH_Signed
        End Get
        Set(ByVal value As String)
            _SH_Signed = value
        End Set
    End Property

   
End Class

