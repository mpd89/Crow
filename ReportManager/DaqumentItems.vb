Imports system.collections.generic

Public Class DaqumentItems : Inherits List(Of DaqumentItem)

End Class

Public Class DaqumentItem
    'documents.DocumentID,documents.EngCode,documents.ClientCode,documents.Description,documents.Revision AS Rev, documents.Sheet+'/'+ documents.Sheets AS Sht, documents.DateLoaded, document_type.Code+'-'+document_type.Description AS DocumentType " & _
    '                 "FROM document_type, documents " & _
    '                "WHERE document_type.DocumentTypeID=documents.DocumentTypeID  AND  1=1" + querySearch

    ' Parent properties
    'PunchlistID,Description,Status,Priority,TagNumber
    Dim _VariableEngCode As String
    Dim _VariableClientCode As String
    Dim _VariableDescription As String
    Dim _VariableRevision As String
    Dim _VariableSheet As String
    Dim _VariableDateLoaded As String
    Dim _VariableCode As String


    Public Property VariableEngCode() As String
        Get
            Return _VariableEngCode
        End Get
        Set(ByVal value As String)
            _VariableEngCode = value
        End Set
    End Property
    Public Property VariableClientCode() As String
        Get
            Return _VariableClientCode
        End Get
        Set(ByVal value As String)
            _VariableClientCode = value
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

    Public Property VariableRevision() As String
        Get
            Return _VariableRevision
        End Get
        Set(ByVal value As String)
            _VariableRevision = value
        End Set
    End Property
    Public Property VariableSheet() As String
        Get
            Return _VariableSheet
        End Get
        Set(ByVal value As String)
            _VariableSheet = value
        End Set
    End Property
    Public Property VariableDateLoaded() As String
        Get
            Return _VariableDateLoaded
        End Get
        Set(ByVal value As String)
            _VariableDateLoaded = value
        End Set
    End Property
    Public Property VariableCode() As String
        Get
            Return _VariableCode
        End Get
        Set(ByVal value As String)
            _VariableCode = value
        End Set
    End Property

End Class
