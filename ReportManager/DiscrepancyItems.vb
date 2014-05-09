
Imports system.collections.generic
Public Class DiscrepancyItems : Inherits List(Of DiscrepancyItem)

End Class

Public Class DiscrepancyItem

    ' Parent properties

    Dim _DiscrepancyID As Integer
    Dim _VariableTitle As String
    Dim _VariableStatus As String
    Dim _VariablePackageNumber As String

    Public Property DiscrepancyID() As Integer
        Get
            Return _DiscrepancyID
        End Get
        Set(ByVal value As Integer)
            _DiscrepancyID = value
        End Set
    End Property

    Public Property VariableTitle() As String
        Get
            Return _VariableTitle
        End Get
        Set(ByVal value As String)
            _VariableTitle = value
        End Set
    End Property

    Public Property VariableStatus() As String
        Get
            Return _VariableStatus
        End Get
        Set(ByVal value As String)
            _VariableStatus = value
        End Set
    End Property
    Public Property VariablePackageNumber() As String
        Get
            Return _VariablePackageNumber
        End Get
        Set(ByVal value As String)
            _VariablePackageNumber = value
        End Set
    End Property

End Class
