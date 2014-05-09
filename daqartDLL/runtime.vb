Public Class runtime
    Dim selectedPort As String
    Dim selectedIP As String

    Public Shared SiteName As String
    Public Shared IISIP As String
    Public Shared IISPort As String
    Public Shared IISvDir As String
    Public Shared SQLIP As String
    Public Shared SQLPort As String
    Public Shared SQLInstance As String
    Public Shared SQLMachine As String
    Public Shared selectedProject As String
    Public Shared selectedProjectID As String
    Public Shared UserName As String
    Public Shared UserMUID As String
    Public Shared DaqartPath As String
    Public Shared ConnectionMode As String = "OFFLINE"
    Public Shared MID As String
    Public Shared PackageTable As DataTable

    Public Shared DefaultPrintSize As System.Drawing.Printing.PaperSize
    Public Shared DefaultPrintSource As System.Drawing.Printing.PaperSource
    Public Shared DefaultPrintLandscape As Boolean
    Public Shared DefaultPrintMargins As System.Drawing.Printing.Margins

    Public Shared Symbols As DataTable

    Public Shared SQLProject As DataUtilsGlobal
    Public Shared SQLServer As DataUtilsGlobal
    Public Shared SQLDaqument As DataUtilsGlobal
    Public Shared SQLDaqument001 As DataUtilsGlobal
    Public Shared SQLMaster As DataUtilsGlobal

    Public Shared AppShutdown As Boolean = False

    'this will be a registry entry when installed
    Public Shared AbsolutePathValue As String
    Public Shared AbsolutePathValue2 As String


    Public Shared Punchlist_SystemMUID As String
    Public Shared Punchlist_ListedBy As String
    Public Shared Punchlist_ListedOn As String


    Public Shared Property AbsolutePath() As String
        Get
            Return AbsolutePathValue
        End Get
        Set(ByVal value As String)
            AbsolutePathValue = value
        End Set
    End Property


    Public Shared Property AbsolutePath2() As String
        Get
            Return AbsolutePathValue2
        End Get
        Set(ByVal value As String)
            AbsolutePathValue2 = value
        End Set
    End Property


End Class
