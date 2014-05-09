
Imports system.collections.generic
Public Class NotesItems : Inherits List(Of NotesItem)


End Class
Public Class NotesItem
    Dim _ID As String
    Dim _UserName As String
    Dim _Tstamp As String
    Dim _Subject As String
    Dim _Description As String
    
    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
            _ID = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property
    Public Property Tstamp() As String
        Get
            Return _Tstamp
        End Get
        Set(ByVal value As String)
            _Tstamp = value
        End Set
    End Property

    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
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
    
End Class
