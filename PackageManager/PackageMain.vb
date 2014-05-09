Imports System
Imports System.Data
Imports System.Windows.Forms.Cursor
Imports System.Data.SqlServerCe
Imports System.Windows.Forms
Imports daqartDLL

Public Class PackageMain
    Inherits System.Windows.Forms.Form

    '    Private MyWaitCursor As System.Windows.Forms.Cursor
    Public user As String = runtime.UserMUID
    Dim connClient As SqlCeConnection
    Public Shared selectedProject As String

    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.tsl_SiteLabel.Text = "Site: " + runtime.SiteName
            Me.ProjectStatusInd.Text = "Project: " + runtime.selectedProject


            'If runtime.ConnectionMode = "OFFLINE" Then
            '    Me.btnPackageImport.Enabled = False
            '    Me.btnTagImport.Enabled = False
            'End If

            Me.MarqueeProgressBarControl1.Visible = False
        Catch ex As Exception
            Utilities.logErrorMessage("PackageMain.Main_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub LogOutExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()
    End Sub

    Private Sub LogOut()
        Dim connServer As SqlCeConnection = Nothing
        connServer = daqartDLL.connections.serverDBConnect(connServer)
        If Not connServer Is Nothing Then
            Dim query As String = "INSERT INTO userlog (userMUID,userLogTS,userLogAction,userLogTime,userLogProject) VALUES ('" + user + "','" + Now() + "','Out','" + Now() + "','')"
            Dim cmd As New SqlCeCommand(query, connServer)
            Dim result As Integer
            Try
                result = cmd.ExecuteNonQuery()
            Catch ex As SqlCeException
                Utilities.logErrorMessage("PackageMain.LogOut_Load-query-" + query)
                MessageBox.Show("Failed to add session to Log records: " + ex.Message)
            End Try
        End If

    End Sub


    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If runtime.UserMUID = "" Then
            LogOut()
        End If
    End Sub


    Private Sub ConnTimer_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles ConnTimer.Elapsed
        'serverConnect()
        ' If conn.Ping() = True Then
        '    ConnIndicator.Image = Global.Daqart.My.Resources.Resources.animated_globe2
        ' Else
        'serverConnect()
        '    ConnIndicator.Image = Global.Daqart.My.Resources.Resources.icon_cancel
        'MessageBox.Show("Connection to the server was lost!!")
        '  End If


    End Sub

    Private Sub FormBuilder10ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frmBuilder As New FormBuilder.frmMain_old
        'frmBuilder.Show()
    End Sub

    Private Sub HelpManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpManualToolStripMenuItem.Click
        Help.ShowHelp(Me, runtime.AbsolutePath() + "\daqart.chm")
    End Sub


    Private Sub ManagePackagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim PackageManager As New package.mainEntry
        'PackageManager.ShowDialog()
    End Sub

    Private Sub DaqumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim DocumentManager As New Daqument.frmImage
        'DocumentManager.ShowDialog()
    End Sub



    Private Sub btnPackageView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.MarqueeProgressBarControl1.Visible = True
        Me.MarqueeProgressBarControl1.BringToFront()
        Me.MarqueeProgressBarControl1.Enabled = True
        Me.Refresh()

        Me.ToolStripStatusLabel1.Text = "loading Package database"
        Cursor.Current = Cursors.NoMove2D
        '      Dim myForm As New PackageViewer.PackageViewerMain_ash
        Cursor.Current = Cursors.IBeam
        Me.ToolStripStatusLabel1.Text = "Package database has been loaded"
        '        myForm.ShowDialog()
        '       Me.MarqueeProgressBarControl1.Visible = False
    End Sub

    Private Sub btnPackageEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPackageEdit.Click
        Me.Cursor = Cursors.WaitCursor

        Dim myForm As New PkgEdit()
        myForm.MdiParent = Me
        Me.Cursor = Cursors.Default

        myForm.Show()
        'myForm.BringToFront()
    End Sub

    Private Sub btnPackageNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPackageNew.Click
        Dim myForm As New PkgFormAdd()

        myForm.Show()
        'myForm.BringToFront()
    End Sub

    Private Sub btnPackageImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPackageImport.Click
        Me.ToolStripStatusLabel1.Text = "loading Package database"
        Me.Cursor = Cursors.NoMove2D
        Dim myForm As New pkgImport()
        Me.Cursor = Cursors.IBeam
        Me.ToolStripStatusLabel1.Text = "Package database has been loaded"
        myForm.MdiParent = Me
        myForm.Show()
        'myForm.BringToFront()
    End Sub

    Private Sub btnPackageExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPackageExport.Click
        'Dim myForm As New PkgExport()
        'myForm.Show()
        'myForm.BringToFront()
        Cursor = Cursors.AppStarting

        Dim cls_Export As New CommonForms.PackageDetails
        Dim dt As DataTable = cls_Export.MakeDT

        Dim frm_ShowExport As New CommonForms.DataExport(dt)
        Cursor = Cursors.Default
        frm_ShowExport.Show()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

 

    Private Sub btnTagImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTagImport.Click
        Me.ToolStripStatusLabel1.Text = "loading Tag database"
        'Cursor.Current = Cursors.NoMove2D
        'Dim Myform As New Form1
        'Myform.ShowDialog()
        Dim myForm As New TagImport
        Cursor.Current = Cursors.IBeam
        Me.ToolStripStatusLabel1.Text = "Tag database has been loaded"
        myForm.MdiParent = Me
        myForm.Show()
        'myForm.BringToFront()
    End Sub

    Private Sub btnTagNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTagNew.Click
        Dim myForm As Form = New TagFormAdd
        myForm.ShowDialog()
        'myForm.BringToFront()
    End Sub

    Private Sub btnTagEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTagEdit.Click
        Me.Cursor = Cursors.AppStarting

        Dim my1Form As New TagSelect()
        my1Form.MdiParent = Me
        Me.Cursor = Cursors.Default

        my1Form.Show()
        'my1Form.BringToFront()
    End Sub

    Private Sub ImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myForm As New equipmentImport()
        myForm.Show()
        myForm.BringToFront()
    End Sub

    Private Sub ImportToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        Dim frm_TaskImport As New TaskImport
        frm_TaskImport.Show()
    End Sub


    Private Sub btnTagExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTagExport.Click
        Cursor = Cursors.AppStarting

        Dim cls_Export As New CommonForms.Tag_List_Export
        Dim dt As DataTable = cls_Export.MakeDT

        Dim frm_ShowExport As New CommonForms.DataExport(dt)
        Cursor = Cursors.Default
        frm_ShowExport.Show()

    End Sub
End Class



















































