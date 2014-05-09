Public Class settings

    Public Shared Property localPort() As String
        Get
            Return My.Settings.localPort
        End Get
        Set(ByVal value As String)
            'My.Settings.localPort = value
        End Set
    End Property

    Public Shared Property localIP() As String
        Get
            Return My.Settings.localIP
        End Get
        Set(ByVal value As String)
            'My.Settings.localPort = value
        End Set
    End Property

End Class
