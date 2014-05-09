Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup( _
    ByVal sender As Object, _
    ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs _
) Handles Me.Startup
            Debug.Print("start up hit")

            ' Get the splash screen. 
            Dim splash As splash2 = CType(My.Application.SplashScreen, splash2)
            My.Application.MinimumSplashScreenDisplayTime = 9000
            ' Display current status information.
            '  splash1.Status = "Current user: " & My.User.Name
        End Sub

        Protected Overrides Function OnInitialize( _
ByVal commandLineArgs As  _
System.Collections.ObjectModel.ReadOnlyCollection(Of String) _
) As Boolean
            ' Set the display time to 5000 milliseconds (5 seconds).
            Me.MinimumSplashScreenDisplayTime = 5000
            Return MyBase.OnInitialize(commandLineArgs)
        End Function
        '/* •—————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
        ' | Protected Overrides Function OnInitialize(ByVal commandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean |
        ' |     Debug.Print("oninitialize hit")                                                                                                         |
        ' |                                                                                                                                             |
        ' |     My.Application.MinimumSplashScreenDisplayTime = 9000                                                                                    |
        ' |     Return MyBase.OnInitialize(commandLineArgs)                                                                                             |
        ' |                                                                                                                                             |
        ' | End Function                                                                                                                                |
        '   •—————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————• */
    End Class


End Namespace

