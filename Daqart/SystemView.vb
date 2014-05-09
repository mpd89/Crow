Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlServerCe
Imports System.Windows.Forms
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports daqartDLL
Imports SystemManager
Imports FormDesigner
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Views.Layout
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB


Public Class SystemView
    Dim dt_Temp As DataTable
    Dim dt_notes As DataTable
    Dim struser As String = ""
    Dim strchild As String = ""
    Dim tempid As Integer
    Dim strtemp As String
    Dim stredit As String
    Dim logoPath As String
    Dim logoImg As Image
    Dim PercentCompleteImagePath As String
    Private printPgHdr As String = ""
    Private printPgSubHdr As String = ""
    Public Shared dt_CurrentSystem As DataTable
    Private GridControl2 As DevExpress.XtraGrid.GridControl = Nothing
    Private Loading As Boolean = True


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        logoPath = runtime.AbsolutePath + "sites\images\logo128.jpg"

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub SystemView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If runtime.SiteName = "ENI001" Then
                Me.btn_EniExport.Visible = True
            End If

            Me.tsl_SiteLabel.Text = "Site: " + runtime.SiteName
            Me.ProjectStatusInd.Text = "Project: " + runtime.selectedProject

            Loading = True

            SystemTree.Nodes.Clear()

            mainFunctions.CreateRootNodes()

            SystemTree.Sort()

            SystemTree.Refresh()

            dt_Temp = New DataTable
            dt_Temp = Utilities.GetOwners()
            cbx_Owners.DataSource = dt_Temp
            cbx_Owners.DisplayMember = dt_Temp.Columns(2).ToString
            cbx_Owners.ValueMember = dt_Temp.Columns(0).ToString

            'Loading = False

        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.SystemView_Load-" + ex.Message)

            MessageBox.Show(ex.Message)
        End Try

        ' GetCompanyLogo()

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim systemValue As String
        Dim thisSystem As New SystemManager.SystemDataManager
        systemValue = SystemManager.SystemDataManager.GetSystem(tbx_SystemNumber.Tag)

        If Not systemValue = "" Then
            tbx_SystemNumber.Tag = systemValue
            tbx_SystemNumber.Text = SystemManager.SystemDataManager.TranslateSystemID(tbx_SystemNumber.Tag)
        End If

    End Sub


    Private Sub SystemTree_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles SystemTree.AfterSelect
        If Loading Then
            SystemTree.SelectedNode = Nothing
            Loading = False
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim CompleteSystem As String
        CompleteSystem = e.Node.Tag
        If Not e.Node.Level = 0 Then
            Dim i As Integer
            Dim tn As New TreeNode()
            tn = e.Node.Parent
            CompleteSystem = tn.Tag + ";" + e.Node.Tag
            Dim newnode As New TreeNode()
            For i = 0 To e.Node.Level - 1
                If Not tn.Level = 0 Then
                    newnode = New TreeNode
                    newnode = tn.Parent
                    CompleteSystem = newnode.Tag + ";" + CompleteSystem
                    tn = newnode
                End If
            Next
        Else
            CompleteSystem += ";"
        End If


        tbx_SystemNumber.Tag = CompleteSystem
        tbx_SystemNumber.Text = SystemManager.SystemDataManager.TranslateSystemID(tbx_SystemNumber.Tag)

        Dim PageExists As Boolean = False
        Dim selectedTab As Integer = 0
        For Each ThisSystem As TabPage In tbc_Main.TabPages
            'If ThisSystem.Text = tbx_SystemNumber.Text & " - " & cbx_Owners.Text Then
            '    PageExists = True
            'End If
            If ThisSystem.Text = tbx_SystemNumber.Text Then
                PageExists = True
                Exit For
            End If
            selectedTab = selectedTab + 1
        Next


        If Not PageExists Then
            Dim newTabPage As New TabPage
            newTabPage.Tag = CompleteSystem
            newTabPage.Name = SystemManager.SystemDataManager.TranslateSystemID(tbx_SystemNumber.Tag)
            'newTabPage.Text = tbx_SystemNumber.Text & " - " & cbx_Owners.Text
            newTabPage.Text = SystemManager.SystemDataManager.TranslateSystemID(tbx_SystemNumber.Tag)
            tbc_Main.TabPages.Add(newTabPage)

            Dim MySystem As New _SystemOverview(SystemManager.SystemDataManager.TranslateSystemID(tbx_SystemNumber.Tag), CompleteSystem)
            MySystem.Dock = DockStyle.Fill

            newTabPage.Controls.Add(MySystem)


            tbc_Main.SelectedTab = newTabPage
            newTabPage.Focus()
        Else
            tbc_Main.SelectedIndex = selectedTab
        End If

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub btn_GetOverview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GetOverview.Click

        If tbx_SystemNumber.Text = Nothing Then
            MessageBox.Show("You must select a system before generating system overview.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim PageExists As Boolean = False
        For Each ThisSystem As TabPage In tbc_Main.TabPages
            'If ThisSystem.Text = tbx_SystemNumber.Text & " - " & cbx_Owners.Text Then
            '    PageExists = True
            'End If
            If ThisSystem.Text = tbx_SystemNumber.Text Then
                PageExists = True
            End If
        Next


        If Not PageExists Then
            Dim newTabPage As New TabPage
            newTabPage.Tag = tbx_SystemNumber.Tag
            newTabPage.Name = tbx_SystemNumber.Text
            'newTabPage.Text = tbx_SystemNumber.Text & " - " & cbx_Owners.Text
            newTabPage.Text = tbx_SystemNumber.Text
            tbc_Main.TabPages.Add(newTabPage)

            Dim MySystem As New _SystemOverview(tbx_SystemNumber.Text, tbx_SystemNumber.Tag)
            MySystem.Dock = DockStyle.Fill

            newTabPage.Controls.Add(MySystem)



            'mainFunctions.PopulateOverview(newTabPage, tbx_SystemNumber.Tag, tbx_SystemNumber.Text)
            tbc_Main.SelectedTab = newTabPage
            newTabPage.Focus()
        End If


    End Sub


    Private Sub CloseSystemOverview()
        Dim PreviousTabIndex As Integer = tbc_Main.SelectedIndex
        If PreviousTabIndex <= 0 Then Return
        Dim ThisTab As TabPage = tbc_Main.SelectedTab
        tbc_Main.SelectedIndex = PreviousTabIndex - 1
        tbc_Main.TabPages.Remove(ThisTab)
    End Sub


    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_OverviewClose.Click
        '        If tbc_Main.SelectedIndex > 1 Then
        CloseSystemOverview()
        'End If

    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_GetSystemDiscrepancies.Click
        MessageBox.Show("System Discprepancy Module not currently loaded, please use the Discrepancy Manager", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_GetSystemPunchlist.Click
        MessageBox.Show("System Punchlist Module not currently loaded, please use the Punchlist Manager", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SyncAll()
    End Sub



    Private Sub ShowDataRow(ByVal dr As DataRow, ByVal fs As String, ByVal c As Color)
        Dim s As String = ""
        If Not dr Is Nothing Then
            Dim items As Object() = dr.ItemArray
            For Each o As Object In items
                If s = "" Then
                    s = ("") + o.ToString()
                    tempid = CInt(o.ToString)

                Else
                    s = (s & "; ") + o.ToString()
                End If
            Next o
        End If
        stredit = ""
        '        stredit = dr(0).ToString
        strtemp = ""
        strtemp = ""
    End Sub


    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        '   Dim frmnotes As New Notes.frmNew
        '   frmnotes.ShowDialog()
    End Sub


    Private Sub ToolStripButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim reportdaq As New ReportManager.NotesReport(dt_notes)
        reportdaq.Show()
    End Sub



    Private Sub ProjectStatusReport()
        Dim myPkgStatus As StatusManager.Status = New StatusManager.Status
        Dim prjTable As DataTable = myPkgStatus.ProjectStatusTable(runtime.selectedProject)
        'Dim SubHeading As String = "Project Status"
        'Dim frm_Results As New ReportManager.ProjectStatus(prjTable, logoPath, _
        '       Me.lblCurrentStatusIndicator.Text, Me.lblTtlProjectEarnedHours.Text, Me.lblTtlProjectManHours.Text, SubHeading)
        'frm_Results.Show()

        'Dim mySysStatus As StatusManager.Status = New StatusManager.Status
        'Dim sysTable As DataTable = mySysStatus.SystemStatusTable(runtime.selectedProject)
        'SubHeading = "System Status"
        'Dim sys_Results As New ReportManager.ProjectStatus(sysTable, logoPath, _
        '       Me.lblCurrentStatusIndicator.Text, Me.lblTtlProjectEarnedHours.Text, Me.lblTtlProjectManHours.Text, SubHeading)
        'sys_Results.Show()
        If Not GridControl2 Is Nothing Then
            GridControl2.Dispose()
            GridControl2 = Nothing
        End If
        printPgHdr = "Project Status"
        GridControl2 = New DevExpress.XtraGrid.GridControl
        GridControl2.Dock = DockStyle.Fill
        GridControl2.DataSource = prjTable
        Me.tbc_Main.TabPages(0).Controls.Add(GridControl2)
        GridControl2.BringToFront()
        Me.ShowGridPreview(GridControl2)

    End Sub
    Private Sub GridShortFormReport()

        Dim thisOwnerMUID As String = "" ' SystemView.CurrentOwner
        Dim ThisOverview As TabPage = tbc_Main.SelectedTab
        Try
            For Each contl As Control In ThisOverview.Controls
                If contl.Name = "_SystemOverview" Then
                    Dim SystemView = TryCast(contl, _SystemOverview)
                    thisOwnerMUID = SystemView.CurrentOwner
                End If
            Next

            If thisOwnerMUID = "" Then
                MessageBox.Show("Please select Owner")
                Return
            End If
            Dim thisOwnerName As String = Utilities.GetOwnerInfo(thisOwnerMUID).Rows(0)("Name")

            Dim qry = " SELECT MUID, PackageNumber, Description, GroupMUID, OwnerMUID, DisciplineMUID " + _
                    " FROM  Package WHERE SystemMUID LIKE '%" + tbx_SystemNumber.Tag + "%' AND OwnerMUID = '" + _
                    thisOwnerMUID + "'"
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            Dim pkgTbl As DataTable = sqlPrjUtils.ExecuteQuery(qry)

            Dim dt As DataTable = New DataTable
            Dim dc As DataColumn = New DataColumn
            printPgHdr = "Package List"
            printPgSubHdr = String.Format("System: {0}", tbx_SystemNumber.Text & " - " & thisOwnerName)
            dc.Caption = "Package"
            dt.Columns.Add(dc)

            For i As Integer = 0 To pkgTbl.Rows.Count - 1
                Dim str As String = String.Format("{0}: {1}", pkgTbl.Rows(i)(1), pkgTbl.Rows(i)(2))
                Dim dr As DataRow = dt.NewRow
                dr(0) = str
                dt.Rows.Add(dr)

                qry = " SELECT tags.TagNumber, engineering_data.Description FROM tags, engineering_data " + _
                         "WHERE tags.PackageMUID = '" + pkgTbl.Rows(i)(0).ToString + "'" + _
                         " AND engineering_data.TagMUID = tags.MUID "
                Dim tg As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                For j As Integer = 0 To tg.Rows.Count - 1
                    Dim dr1 As DataRow = dt.NewRow
                    str = String.Format("         {0}: {1}", tg.Rows(j)(0), tg.Rows(j)(1))
                    dr1(0) = str
                    dt.Rows.Add(dr1)
                Next
            Next
            sqlPrjUtils.CloseConnection()
            If Not GridControl2 Is Nothing Then
                GridControl2.Dispose()
                GridControl2 = Nothing
            End If
            Try
                If Not pkgTbl.DataSet Is Nothing Then
                    pkgTbl.DataSet.Dispose()
                End If
            Catch ex As Exception
                MessageBox.Show("No entry in the Data Table")
                Return
            End Try
            GridControl2 = New DevExpress.XtraGrid.GridControl
            GridControl2.Dock = DockStyle.Fill
            GridControl2.DataSource = dt
            Me.tbc_Main.TabPages(0).Controls.Add(GridControl2)
            GridControl2.BringToFront()
        Catch ex As Exception
            MessageBox.Show("Please select System Overview")
            Return
        End Try
    End Sub



    'Private Sub tmpGridShortFormReport(ByVal OwnerID As Integer, ByVal OwnerName As String)
    '    Dim str As String = ""
    '    Dim qry = " SELECT PackageID, PackageNumber, Description, GroupID, OwnerID, DisciplineID " + _
    '            " FROM  Package WHERE OwnerID = " + OwnerID.ToString
    '    Dim pkgTbl As DataTable = Utilities.ExecuteQuery(qry, "project")
    '    Dim dt As DataTable = New DataTable
    '    Dim dc As DataColumn = New DataColumn
    '    dc.Caption = "Package"
    '    dt.Columns.Add(dc)
    '    str = String.Format("***** Owner ***** ID:{0}: Name{1}", OwnerID, OwnerName)
    '    dt.Rows.Add(str)
    '    Dim pkgTTL As Single = 0
    '    For i As Integer = 0 To pkgTbl.Rows.Count - 1
    '        str = String.Format("{0}: {1}", pkgTbl.Rows(i)(1), pkgTbl.Rows(i)(2))
    '        Dim dr As DataRow = dt.NewRow
    '        dr(0) = str
    '        dt.Rows.Add(dr)

    '        qry = " SELECT tags.TagNumber, engineering_data.Description, typeID, tags.tagID FROM tags, engineering_data " + _
    '                 "WHERE tags.PackageID = " + pkgTbl.Rows(i)(0).ToString + _
    '                 " AND engineering_data.TagID = tags.tagID "
    '        Dim tg As DataTable = Utilities.ExecuteQuery(qry, "project")
    '        Dim tagTTL As Single = 0
    '        For j As Integer = 0 To tg.Rows.Count - 1
    '            Dim dr1 As DataRow = dt.NewRow
    '            str = String.Format("         {0},--TypeID:{1}--TagID:{2}", _
    '            tg.Rows(j)(0), tg.Rows(j)(2), tg.Rows(j)(3))
    '            dr1(0) = str
    '            dt.Rows.Add(dr1)
    '            qry = " SELECT DISTINCT requirements.FormID, forms.MultiElement As MEFlag, " + _
    '                    " requirements.ManHours As NonMEMhr,requirements.Aux01 As MEMhr FROM requirements,forms " + _
    '                     "WHERE Forms.ID = requirements.FormID AND requirements.TypeID = " + tg.Rows(j)(2).ToString + _
    '                     " AND requirements.OwnerID = " + OwnerID.ToString
    '            Dim rg As DataTable = Utilities.ExecuteQuery(qry, "project")
    '            Dim frmTTL As Single = 0
    '            For k As Integer = 0 To rg.Rows.Count - 1
    '                Dim frmMhr As Single = 0
    '                Dim dr2 As DataRow = dt.NewRow
    '                If rg.Rows(k)(1) = 1 Then
    '                    If rg.Rows(k)(3).ToString > "" Then
    '                        frmMhr = Convert.ToSingle(rg.Rows(k)(3).ToString)
    '                    End If
    '                Else
    '                    If rg.Rows(k)(2).ToString > "" Then
    '                        frmMhr = Convert.ToSingle(rg.Rows(k)(2).ToString)
    '                    End If
    '                End If
    '                str = String.Format("      ---------FormID:{0},MultiElement:{1},Mhr:{2}", _
    '                        rg.Rows(k)(0), rg.Rows(k)(1), frmMhr)
    '                dr2(0) = str
    '                dt.Rows.Add(dr2)
    '                frmTTL = frmTTL + frmMhr

    '            Next
    '            Dim dr3 As DataRow = dt.NewRow
    '            str = String.Format("      ------------Tag TTL:{0}", frmTTL)
    '            dr3(0) = str
    '            dt.Rows.Add(dr3)
    '            qry = "SELECT RequiredManhours, EarnedManhours,tagID FROM tag_status " + _
    '                    " WHERE tagID = " + tg.Rows(j)(3).ToString
    '            Dim sg As DataTable = Utilities.ExecuteQuery(qry, "project")
    '            Dim dr6 As DataRow = dt.NewRow
    '            str = String.Format("      ----------From Status Table ID:{2}--ReqMhr:{0}, --EarnMhr:{1}", _
    '                    sg.Rows(0)(0), sg.Rows(0)(1), sg.Rows(0)(2))
    '            dr6(0) = str
    '            dt.Rows.Add(dr6)




    '            tagTTL = tagTTL + frmTTL
    '        Next


    '        Dim dr4 As DataRow = dt.NewRow
    '        str = String.Format("      -------------------------- Pkg Tag TTL:{0}", tagTTL)
    '        dr4(0) = str
    '        dt.Rows.Add(dr4)

    '        qry = " SELECT DISTINCT typeID FROM tags WHERE PackageID = " + pkgTbl.Rows(i)(0).ToString
    '        Dim pg As DataTable = Utilities.ExecuteQuery(qry, "project")
    '        Dim pkgMEMhr As Single = 0
    '        For j As Integer = 0 To pg.Rows.Count - 1

    '            qry = " SELECT DISTINCT requirements.FormID, forms.MultiElement As MEFlag, requirements.ManHours As NonMEMhr,requirements.Aux01 As MEMhr FROM requirements,forms " + _
    '                     "WHERE requirements.TypeID = " + pg.Rows(j)(0).ToString
    '            Dim rg As DataTable = Utilities.ExecuteQuery(qry, "project")
    '            Dim pkgMhr As Single = 0
    '            For k As Integer = 0 To rg.Rows.Count - 1
    '                Dim dr2 As DataRow = dt.NewRow
    '                If rg.Rows(k)(1) = 1 Then
    '                    If rg.Rows(k)(2).ToString > "" Then
    '                        pkgMhr = Convert.ToSingle(rg.Rows(k)(2).ToString)
    '                        pkgMEMhr = pkgMhr + pkgMEMhr
    '                    End If
    '                End If
    '            Next
    '            Dim dr44 As DataRow = dt.NewRow
    '            str = String.Format("      -------------------------- Pkg Form TTL:{0}", pkgMhr)
    '            dr44(0) = str
    '            dt.Rows.Add(dr44)
    '        Next

    '        pkgTTL = pkgTTL + tagTTL + pkgMEMhr

    '    Next
    '    Dim dr5 As DataRow = dt.NewRow
    '    Dim mStr = String.Format("      -------------------------- Sys TTL:{0}", pkgTTL)
    '    dr5(0) = mStr
    '    dt.Rows.Add(dr5)
    '    If Not GridControl2 Is Nothing Then
    '        GridControl2.Dispose()
    '        GridControl2 = Nothing
    '    End If
    '    Try
    '        If Not pkgTbl.DataSet Is Nothing Then
    '            pkgTbl.DataSet.Dispose()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("No entry in the Data Table")
    '        Return
    '    End Try

    '    GridControl2 = New DevExpress.XtraGrid.GridControl
    '    GridControl2.Dock = DockStyle.Fill
    '    GridControl2.DataSource = dt
    '    Me.tbc_Main.TabPages(0).Controls.Add(GridControl2)
    '    GridControl2.BringToFront()
    'End Sub
    Private Sub CreateReportHeaderArea(ByVal sender As System.Object, ByVal e As CreateAreaEventArgs)
        Dim pgSize As SizeF = e.Graph.ClientPageSize
        Dim rec As RectangleF = New RectangleF(0, 0, pgSize.Width, 40)
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("TimesRoman", 24, FontStyle.Bold)
        e.Graph.DrawString(printPgHdr, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None)

        e.Graph.Font = New Font("TimesRoman", 12, FontStyle.Bold)
        Dim mydate As String = "Date: " + Now.Date()
        Dim strSize As SizeF = e.Graph.MeasureString(mydate)
        rec = New RectangleF(New Point(pgSize.Width - strSize.Width - 50, 40), strSize)
        e.Graph.DrawString(mydate, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None)


        rec = New RectangleF(New Point(200, 100), e.Graph.MeasureString(printPgSubHdr))
        e.Graph.DrawString(printPgSubHdr, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None)


        Dim mystr As String = "Requested By: " + Utilities.GetUserInfoByMUID(runtime.UserMUID).Rows(0)(1)
        strSize = e.Graph.MeasureString(mystr)
        rec = New RectangleF(New Point(pgSize.Width - strSize.Width - 50, 60), strSize)
        e.Graph.DrawString(mystr, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None)
        If Not logoPath Is Nothing Then
            If Not logoImg Is Nothing Then
                logoImg.Dispose()
            End If
            logoImg = Image.FromFile(logoPath)
            rec = New RectangleF(New Point(0, 0), logoImg.Size)
            e.Graph.DrawImage(logoImg, rec, DevExpress.XtraPrinting.BorderSide.None, Color.Violet)
        End If


    End Sub
    Sub ShowGridPreview(ByVal grid As GridControl)
        ' Check whether the GridControl can be previewed.
        If Not grid.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting.v7.2.dll' is not found", "Error")
            Return
        End If
        Dim ps As New PrintingSystem()
        ' Create a link that will print a control.
        Dim link As New PrintableComponentLink(ps)
        ' Specify the control to be printed.
        link.Component = grid
        ' Subscribe to the CreateReportHeaderArea event used to generate the report header.
        AddHandler link.CreateReportHeaderArea, AddressOf CreateReportHeaderArea
        AddHandler link.AfterCreateAreas, AddressOf DisposeGrid
        ' Generate the report.
        link.CreateDocument()
        ' Show the report.
        link.ShowPreview()
    End Sub
    Private Sub DisposeGrid(ByVal sender As System.Object, ByVal e As EventArgs)
        If Not GridControl2 Is Nothing Then
            GridControl2.Dispose()
            GridControl2 = Nothing
        End If
    End Sub


    Private Sub tsb_PrintOverview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_PrintOverview.Click
        Dim ThisOverview As TabPage = tbc_Main.SelectedTab
        Try

            For Each contl As Control In ThisOverview.Controls
                If contl.Name = "_SystemOverview" Then
                    Dim SystemView = TryCast(contl, _SystemOverview)
                    'Dim pPreview As New SystemPrint(ThisOverview.Tag, SystemView.CurrentOwner)
                    'pPreview.ShowDialog()

                    'get package list as datatable
                    Dim query As String = "SELECT * FROM package WHERE SystemMUID " + Utilities.SystemQuery(ThisOverview.Tag)
                    Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

                    Dim pPreview As New PackageViewer.PackagePrint(dt, ThisOverview.Tag)
                    pPreview.ShowDialog()
                End If
            Next

            'If tbc_Main.SelectedIndex > 1 Then
            '    Dim ThisOverview As TabPage = tbc_Main.SelectedTab

            '    For Each contl As Control In ThisOverview.Controls

            '        If contl.Name = "SysID" & ThisOverview.Tag Then

            '            Dim SystemView As New SystemOverview
            '            SystemView = contl

            '            Dim frm_Results As New ReportManager.SystemOverview(dt_CurrentSystem, SystemView.tbx_Owner.Text, _
            '                SystemView.tbx_SystemID.Text, SystemView.tbx_Description.Text, SystemView.tbx_EarnedMH.Text, _
            '                SystemView.tbx_RequiredMH.Text, SystemView.tbx_PercentComplete.Text)
            '            frm_Results.Show()


            '        End If

            '    Next


            'Else
            '    If tbc_Main.SelectedIndex = 1 Then
            '        ProjectStatusReport()
            '    End If

            'End If
        Catch ex As Exception

        End Try


    End Sub




    Private Sub SyncAll()
        Try
            Utilities.SubscribeToDB(runtime.selectedProject)
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Utilities.SubscribeToDB(runtime.SiteName + "_ServerDB")
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Utilities.SubscribeToDB(runtime.SiteName + "_Daqument")
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Utilities.SubscribeToDB(runtime.SiteName + "_Daqument001")
        Catch ex As SqlCeException
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'tbx_SystemNumber.Tag
        Dim SRMH As Single = Utilities.GetSystemRequiredManHours(tbx_SystemNumber.Tag, cbx_Owners.SelectedValue)

        Dim SEMH As Single = Utilities.GetSystemEarnedManHours(tbx_SystemNumber.Tag, cbx_Owners.SelectedValue)


        MessageBox.Show("EarnedMH : " + SEMH.ToString + " mh" + vbCr + "RequiredMH: " + SRMH.ToString + " mh")

    End Sub

    Private Sub PrintPkgShortFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPkgShortFormToolStripMenuItem.Click
        GridShortFormReport()
        If Not GridControl2 Is Nothing Then
            ShowGridPreview(GridControl2)
        End If
        'Dim qry = " SELECT OwnerID, Name FROM  owner"
        'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "server")
        'For i As Integer = 0 To dt.Rows.Count - 1
        '    tmpGridShortFormReport(dt.Rows(i)(0), dt.Rows(i)(1))
        '    ShowGridPreview(GridControl2)
        'Next
    End Sub

    Private Sub PrintSystemPackagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSystemPackagesToolStripMenuItem.Click
        Try
            Dim ThisOverview As TabPage = tbc_Main.SelectedTab
            For Each contl As Control In ThisOverview.Controls
                If contl.Name = "_SystemOverview" Then
                    Dim SystemView = TryCast(contl, _SystemOverview)
                    'Dim myForm As Form = New SystemPackagePrint(tbx_SystemNumber.Tag, cbx_Owners.SelectedValue)
                    'myForm.ShowDialog()
                    Dim pPreview As New SystemPackagePrint(ThisOverview.Tag, SystemView.CurrentOwner)
                    pPreview.ShowDialog()
                End If
            Next

            'Dim myForm As Form = New SystemPackagePrint(tbx_SystemNumber.Tag, cbx_Owners.SelectedValue)
            'myForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btn_ProjectITS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ProjectITS.Click
        Dim frm As New CommonForms.OwnerSelect
        frm.ShowDialog()

        Dim OwnerMUID As String
        OwnerMUID = CommonForms.OwnerSelect.OwnerMUID

        Me.Cursor = Cursors.WaitCursor
        Dim frm_ShowExport As New SystemITS("Project", MakeSystemITS(), OwnerMUID)
        Me.Cursor = Cursors.Default
        frm_ShowExport.Show()
    End Sub


    Public Function MakeSystemITS() As DataTable
        Dim dt_FieldList As New DataTable
        Dim dt_TagIDList As New DataTable
        Dim dt_Final As New DataTable
        Dim dt_Tags As New DataTable

        Dim tierquery As String = "SELECT * FROM system_mnemonic"
        Dim dt_tiers As DataTable = runtime.SQLProject.ExecuteQuery(tierquery)
        For i As Integer = 0 To dt_tiers.Rows.Count - 1
            dt_Final.Columns.Add(dt_tiers.Rows(i)("Description"))
        Next

        dt_Final.Columns.Add("MUID")
        dt_Final.Columns("MUID").ColumnMapping = MappingType.Hidden

        dt_Final.Columns.Add("TypeMUID")
        dt_Final.Columns("TypeMUID").ColumnMapping = MappingType.Hidden

        dt_Final.Columns.Add("Package#")
        dt_Final.Columns.Add("Tag#")
        dt_Final.Columns.Add("Discrepancy")
        dt_Final.Columns.Add("Discipline")

        dt_Final.Columns.Add("Type")
        dt_Final.Columns("Type").ColumnMapping = MappingType.Hidden
        dt_Final.Columns.Add("Description")
        dt_Final.Columns("Description").ColumnMapping = MappingType.Hidden

        Try
            Dim query As String = "SELECT MUID,Name FROM forms ORDER BY NAME"
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

            For Each dr As DataRow In dt.Rows
                dt_Final.Columns.Add(dr("MUID"))
                dt_Final.Columns(dt_Final.Columns.Count - 1).Caption = dr("Name")
            Next

            Dim OwnerCriteria As String = ""

            query = "SELECT package.SystemMUID,tags.MUID, package.PackageNumber, tags.TagNumber, " & _
                    " equipment_type.MUID As TypeMUID, equipment_type.TypeName, package.DisciplineMUID, " & _
                    " engineering_data.Description FROM tags INNER JOIN" & _
                    " package ON tags.PackageMUID = package.MUID INNER JOIN" & _
                    " equipment_type ON tags.TypeMUID = equipment_type.MUID LEFT OUTER JOIN" & _
                    " engineering_data ON tags.MUID = engineering_data.TagMUID" & _
                    " ORDER BY tags.TagNumber ASC, engineering_data.TS DESC"
            dt_Tags = runtime.SQLProject.ExecuteQuery(query)

            For i As Integer = 0 To dt_Tags.Rows.Count - 1
                Dim HasDiscrepancy As String = "No"
                If Utilities.PackageDiscrepancy(dt_Tags.Rows(i)("PackageNumber")) Then
                    HasDiscrepancy = "Yes"
                Else
                    HasDiscrepancy = "No"
                End If

                dt_Final.Rows.Add()
                Dim SystemList As Array = Split(dt_Tags.Rows(i)("SystemMUID"), ";")

                For u As Integer = 0 To SystemList.Length - 1
                    dt_Final.Rows(dt_Final.Rows.Count - 1)(u) = SystemDataManager.GetSystemIdentifier(SystemList(u))
                Next

                dt_Final.Rows(dt_Final.Rows.Count - 1)("MUID") = dt_Tags.Rows(i)("MUID")
                dt_Final.Rows(dt_Final.Rows.Count - 1)("TypeMUID") = dt_Tags.Rows(i)("TypeMUID")
                dt_Final.Rows(dt_Final.Rows.Count - 1)("Package#") = dt_Tags.Rows(i)("PackageNumber")
                dt_Final.Rows(dt_Final.Rows.Count - 1)("Tag#") = dt_Tags.Rows(i)("TagNumber")
                dt_Final.Rows(dt_Final.Rows.Count - 1)("Type") = dt_Tags.Rows(i)("TypeName")
                dt_Final.Rows(dt_Final.Rows.Count - 1)("Description") = dt_Tags.Rows(i)("Description")
                dt_Final.Rows(dt_Final.Rows.Count - 1)("Discipline") = Utilities.GetDisciplineName(dt_Tags.Rows(i)("DisciplineMUID"))
                dt_Final.Rows(dt_Final.Rows.Count - 1)("Discrepancy") = HasDiscrepancy
            Next

            For i As Integer = 0 To dt_Final.Rows.Count - 1
                query = "SELECT requirements.ManHours,  requirements.FormMUID, requirements.OwnerMUID" & _
                        " FROM requirements INNER JOIN forms ON requirements.FormMUID = forms.MUID" & _
                        " WHERE requirements.TypeMUID='" + dt_Final.Rows(i)("TypeMUID") + "'"


                Dim dt_Req As DataTable = runtime.SQLProject.ExecuteQuery(query)

                For u As Integer = 0 To dt_Final.Columns.Count - 1
                    For Each dr As DataRow In dt_Req.Rows
                        If dt_Final.Columns(u).ColumnName = dr(1) Then
                            Dim FormStatusLevel As Integer = Utilities.GetFormStatus(dt_Final.Rows(i)("MUID"), dr(1), dr("OwnerMUID"))
                            Dim FormStatusDescription As String = Utilities.GetStatusDescription(dr("OwnerMUID"), Utilities.GetFormStatus(dt_Final.Rows(i)("MUID"), dr(1), dr("OwnerMUID")))
                            If FormStatusLevel = 0 Then
                                FormStatusDescription = "Incomplete"
                            End If

                            dt_Final.Rows(i)(u) = FormStatusDescription
                        End If
                    Next
                Next
            Next

            'clear empty columns
            Dim EmptyColList As New List(Of Integer)
            Dim DupRowList As New List(Of Integer)
            For u As Integer = 0 To dt_Final.Columns.Count - 1
                Dim EmptyColumn As Boolean = True
                For i As Integer = 0 To dt_Final.Rows.Count - 1
                    If Not IsDBNull(dt_Final.Rows(i)(u)) Then
                        EmptyColumn = False
                        Exit For
                    End If
                Next
                If EmptyColumn Then
                    EmptyColList.Add(u)
                End If
            Next


            For i As Integer = 0 To dt_Final.Rows.Count - 1
                If i > 0 Then
                    If dt_Final.Rows(i)("Tag#") = dt_Final.Rows(i - 1)("Tag#") Then
                        DupRowList.Add(i)
                    End If
                End If
            Next

            EmptyColList.Reverse()
            For i As Integer = 0 To EmptyColList.Count - 1
                dt_Final.Columns.Remove(dt_Final.Columns(EmptyColList(i)))
            Next

            DupRowList.Reverse()
            For i As Integer = 0 To DupRowList.Count - 1
                dt_Final.Rows.Remove(dt_Final.Rows(DupRowList(i)))
            Next

        Catch ex As Exception

        End Try

        Return dt_Final
    End Function


    Private Sub btn_EniExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_EniExport.Click
        Dim frm As New eniExport(Me.tbx_SystemNumber.Tag)

        frm.Show()
    End Sub


End Class