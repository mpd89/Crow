Imports system.collections.generic

Public Class AuditItems : Inherits List(Of AuditItem)

End Class

Public Class AuditItem

    ' Parent properties
    Dim _ItemNumber As Integer
    Dim _VariableName As String
    Dim _VariableDescription As String

    Public Property ItemNumber() As Integer
        Get
            Return _ItemNumber
        End Get
        Set(ByVal value As Integer)
            _ItemNumber = value
        End Set
    End Property

    Public Property VariableName() As String
        Get
            Return _VariableName
        End Get
        Set(ByVal value As String)
            _VariableName = value
        End Set
    End Property

    Public Property VariableDescription() As String
        Get
            Return _VariableDescription
        End Get
        Set(ByVal value As String)
            _VariableDescription = value
        End Set
    End Property

End Class
