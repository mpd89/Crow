Imports System.Data.SqlServerCe
Imports daqartDLL


Public Class Diagnostics

    Private Sub Diagnostics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        MessageBox.Show("Start")
        Dim repl As New SqlCeReplication()
        MessageBox.Show("Step 2")

        repl.InternetUrl = "http://xt3ancap025:80/Daqart/sqlcesa35.dll/sqlcesa30.dll"
        MessageBox.Show("Step 3")

        'repl.InternetUrl = "http://" + runtime.SQLMachine.ToLower + ":" + runtime.IISPort + "/" + runtime.IISvDir + "/sqlcesa35.dll/sqlcesa30.dll"

        MessageBox.Show("http://xt3ancap025:80/Daqart/sqlcesa35.dll/sqlcesa30.dll" + vbCr + repl.InternetUrl)

        repl.Publisher = "XT3ANCAP025"
        repl.PublisherDatabase = "BP001_ServerDB"
        repl.PublisherSecurityMode = SecurityType.DBAuthentication
        repl.PublisherLogin = "daqart_sa"
        repl.PublisherPassword = "p@ssW0rd"
        repl.Publication = "BP001_ServerDB"
        repl.Subscriber = "BP001_ServerDB"
        repl.SubscriberConnectionString = "Data Source=""C:\Program Files\Daqart\sites\BP001\BP001_ServerDB.sdf"";Max Database Size=128;Default Lock Escalation =100;"
        Try

            If Not System.IO.File.Exists("C:\Program Files\Daqart\sites\BP001\BP001_ServerDB.sdf") Then
                repl.AddSubscription(AddOption.CreateDatabase)
            End If

            'Dim UPGD As New SqlCeEngine
            'UPGD.LocalConnectionString = repl.SubscriberConnectionString
            'UPGD.Upgrade()

            'repl.AddSubscription(AddOption.ExistingDatabase)
            repl.Synchronize()
        Catch err As SqlCeException
            MessageBox.Show(err.ToString)
        End Try

    End Sub
End Class