﻿Namespace My
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

            Debug.Print("start up hit in frmlogin")
            ' Get the splash screen. 
            '  Dim splash As SplashScreen1 = CType(My.Application.SplashScreen, SplashScreen1)
            ' Display current status information.
            'splash.Status = "Current user: " & My.User.Name
        End Sub
    End Class


End Namespace

