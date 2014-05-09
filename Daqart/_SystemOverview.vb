Imports daqartDLL
Imports CommonForms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid


Public Class _SystemOverview
    Private SystemID As String
    Private SystemNumber As String
    Private Loading As Boolean
    Private listPunchlist As Boolean = False
    Private listDiscrepancies As Boolean = False
    '  Dim WithEvents PunchlistObject As PunchlistManager.ControlPunchlist
    Public CurrentOwner As String = 0
    Dim item1 As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
    Dim itemReqdMhrs As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
    Dim itemEarnedMhrs As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
    Dim itemLevel As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
    Dim itemPcnt As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()

    Dim MCPriority As String
    Dim SHPriority As String


    Public Sub New(ByVal _SystemID As String, ByVal _SystemNumber As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SystemID = _SystemID
        SystemNumber = _SystemNumber

        Me.tbx_SystemID2.Text = SystemID
        Me.tbx_Description2.Text = SystemManager.SystemDataManager.GetFullSystemDescription(SystemNumber)

    End Sub


    Private Sub _SystemOverview_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Loading = True

        Try
            Dim dt_temp As DataTable
            dt_temp = Utilities.GetOwners()
            Me.cbx_Owner.DataSource = dt_temp
            Me.cbx_Owner.DisplayMember = dt_temp.Columns(2).ToString
            Me.cbx_Owner.ValueMember = dt_temp.Columns(0).ToString
            CurrentOwner = Me.cbx_Owner.SelectedValue

            Dim query As String = "SELECT * FROM punchlist WHERE SystemMUID " + Utilities.SystemQuery(SystemNumber) + "" & _
                " AND Status != 'Closed' ORDER BY Priority DESC"
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

            If dt.Rows.Count > 0 Then
                Me.MCPriority = dt.Rows(0)("Priority")
            End If


            query = "SELECT * FROM punchlist WHERE SystemMUID " + Utilities.SystemQuery(SystemNumber) + "" & _
                " AND Status != 'Closed' ORDER BY Aux09 DESC"
            dt = runtime.SQLProject.ExecuteQuery(query)

            If dt.Rows.Count > 0 Then
                Me.SHPriority = dt.Rows(0)("Aux09")
            End If


        Catch ex As Exception

        End Try

        TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed

        InitializeOverview()

        ShowPunchlistGrid()

        Loading = False

    End Sub


    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics = e.Graphics
        Dim tp As TabPage = TabControl1.TabPages(e.Index)
        Dim br As Brush
        Dim sf As New StringFormat
        Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height)

        sf.Alignment = StringAlignment.Center
        Dim strTitle As String = tp.Text

        If e.Index = 2 And (Me.MCPriority = "1" Or Me.SHPriority = "A") Then
            br = New SolidBrush(Color.Red)
            g.FillRectangle(br, e.Bounds)
            br = New SolidBrush(Color.Black)
            g.DrawString(strTitle, TabControl1.Font, br, r, sf)
        Else
            br = New SolidBrush(Color.WhiteSmoke)
            g.FillRectangle(br, e.Bounds)
            br = New SolidBrush(Color.Black)
            g.DrawString(strTitle, TabControl1.Font, br, r, sf)
        End If

    End Sub


    Public Sub InitializeOverview()
        Me.dgv_PackageData.DataSource = Nothing
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim i As Integer
        Dim query As String

        query = "SELECT * " & _
        "FROM system_status " & _
        "WHERE SystemMUID " + Utilities.SystemQuery(SystemNumber) + " AND OwnerMUID='" & Me.cbx_Owner.SelectedValue & "'"
        'sqlPrjUtils.OpenConnection()
        Dim SystemStatusTable As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        query = "SELECT SUM(EarnedManHours) As EMH " & _
        "FROM system_status " & _
        "WHERE SystemMUID LIKE " + Utilities.SystemQuery(SystemID) + " AND OwnerMUID='" & Me.cbx_Owner.SelectedValue & "'"
        'sqlPrjUtils.OpenConnection()
        Dim dt_EarnedMH As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        query = "SELECT SUM(RequiredManHours) As RMH " & _
        "FROM system_status " & _
        "WHERE SystemMUID LIKE " + Utilities.SystemQuery(SystemNumber) + " AND OwnerMUID='" & Me.cbx_Owner.SelectedValue & "'"
        'sqlPrjUtils.OpenConnection()
        Dim dt_ReqdMH As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        Dim AllPkgQuery As String
        If Me.cbx_AllPackages.Checked Then
            AllPkgQuery = ""
        Else
            AllPkgQuery = "AND OwnerMUID ='" & Me.cbx_Owner.SelectedValue & "' "
        End If

        'If SystemNumber(SystemNumber.Length - 1) = ";" Then
        '    SystemNumber = SystemNumber.Remove(SystemNumber.Length - 1, 1)
        'End If

        Dim SystemArray As Array
        SystemArray = Split(SystemNumber, ";")

        If Utilities.CountTiers = 1 Then
            'SystemNumber = SystemNumber.Remove(SystemNumber.Length - 1, 1)
            SystemNumber = SystemNumber.Replace(";", "")
        End If

        If SystemArray(SystemArray.Length - 1) = "" Then
            query = "SELECT " & _
                "package.MUID AS MUID, package.PackageNumber AS Package, package.Description AS Description, package.Aux09 As Priority, package.DisciplineMUID AS DisciplineMUID  " & _
                "FROM package  " & _
                "WHERE package.SystemMUID " + Utilities.SystemQuery(SystemNumber) + AllPkgQuery
        Else
            query = "SELECT " & _
                "package.MUID AS MUID, package.PackageNumber AS Package, package.Description AS Description, package.Aux09 As Priority, package.DisciplineMUID AS DisciplineMUID  " & _
                "FROM package  " & _
                "WHERE package.SystemMUID " + Utilities.SystemQuery(SystemNumber) + AllPkgQuery
        End If

        'query = "SELECT " & _
        '    "package.MUID AS MUID, package.PackageNumber AS Package, package.Description AS Description, package.Aux09 As Priority, package.DisciplineMUID AS DisciplineMUID  " & _
        '    "FROM package  " & _
        '    "WHERE package.SystemMUID LIKE '" & SystemNumber & "'" + AllPkgQuery

        'sqlPrjUtils.OpenConnection()
        Dim PackageTable As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        PackageTable.Columns.Add("Disc")
        PackageTable.Columns(5).DataType = System.Type.GetType("System.String")
        PackageTable.Columns.Add("Level")
        PackageTable.Columns.Add("EarnedMhrs")
        PackageTable.Columns.Add("reqdMhrs")
        PackageTable.Columns.Add("PercentComplete")
        PackageTable.Columns.Add("Status")

        Dim PackageStatusTable As New DataTable
        For i = 0 To PackageTable.Rows.Count - 1
            query = "SELECT " & _
            "package_status.CurrentLevel As Level, package_status.EarnedManHours As EarnedMhrs, " & _
            "package_status.RequiredManHours AS reqdMhrs, " & _
            "CASE WHEN package_status.RequiredManHours = '0' THEN 0 ELSE " & _
            "Round(package_status.EarnedManHours / package_status.RequiredManHours * 100, 2) END AS PercentComplete " & _
            "FROM package_status  " & _
            "WHERE packageMUID = '" & PackageTable.Rows(i)("MUID") & "' " & _
            "AND OwnerMUID ='" & Me.cbx_Owner.SelectedValue & "' "

            'sqlPrjUtils.OpenConnection()
            PackageStatusTable = runtime.SQLProject.ExecuteQuery(query)
            'sqlPrjUtils.CloseConnection()

            PackageTable.Rows(i)("Disc") = Utilities.GetDisciplineName(PackageTable.Rows(i)("DisciplineMUID"))

            If Not PackageStatusTable.Rows.Count = 0 Then
                PackageTable.Rows(i)("Level") = PackageStatusTable.Rows(0)("Level")
                PackageTable.Rows(i)("EarnedMhrs") = PackageStatusTable.Rows(0)("EarnedMhrs")
                PackageTable.Rows(i)("reqdMhrs") = PackageStatusTable.Rows(0)("reqdMhrs")
                PackageTable.Rows(i)("PercentComplete") = PackageStatusTable.Rows(0)("PercentComplete")
                If Utilities.GetStatusDescription(Me.cbx_Owner.SelectedValue, PackageStatusTable.Rows(0)("Level")) = "0" Then
                    PackageTable.Rows(i)("Status") = "Incomplete"
                Else
                    PackageTable.Rows(i)("Status") = Utilities.GetStatusDescription(Me.cbx_Owner.SelectedValue, PackageStatusTable.Rows(0)("Level"))
                End If
            Else
                PackageTable.Rows(i)("Level") = 0
                PackageTable.Rows(i)("EarnedMhrs") = 0
                PackageTable.Rows(i)("reqdMhrs") = 0
                PackageTable.Rows(i)("PercentComplete") = 0
                PackageTable.Rows(i)("Status") = "Incomplete"
            End If
        Next

        Dim EMH As Single = 0
        Dim RMH As Single = 0

        Dim CompletePackageCount As Integer = 0
        For Each dr As DataRow In PackageTable.Rows
            Dim CompletePackageTable As New DataTable
            query = "SELECT * " & _
            "FROM package_status " & _
            "WHERE OwnerMUID = '" & Me.cbx_Owner.SelectedValue & "' " & _
            "AND PackageMUID = '" & dr("MUID") & "' " & _
            "AND CurrentLevel = '" & Utilities.GetFormConfigCount(Me.cbx_Owner.SelectedValue) & "' "
            'sqlPrjUtils.OpenConnection()
            CompletePackageTable = runtime.SQLProject.ExecuteQuery(query)
            'sqlPrjUtils.CloseConnection()
            CompletePackageCount += CompletePackageTable.Rows.Count

            EMH += dr("EarnedMhrs")
            RMH += dr("reqdMhrs")
        Next

        Me.txtEarnedMhrs.Text = EMH.ToString
        Me.txtReqdMhrs.Text = RMH.ToString

        Dim PComplete As Double
        If Not Me.txtReqdMhrs.Text = 0 Then
            PComplete = Math.Round(Convert.ToDouble(Me.txtEarnedMhrs.Text) / Convert.ToDouble(Me.txtReqdMhrs.Text) * 100, 2)
        Else
            PComplete = 0.0
        End If
        Me.txtPcntComplete.Text = PComplete.ToString

        Me.tbx_PackageCount.Text = PackageTable.Rows.Count.ToString
        Me.tbx_PackageComplete.Text = CompletePackageCount.ToString
        Me.tbx_PackageRemaining.Text = PackageTable.Rows.Count - CompletePackageCount


        PackageTable.Columns("MUID").ColumnMapping = MappingType.Hidden
        PackageTable.Columns("DisciplineMUID").ColumnMapping = MappingType.Hidden
        'PackageTable.Columns("Level").ColumnMapping = MappingType.Hidden
        Me.dgv_PackageData.DataSource = PackageTable

        SystemView.dt_CurrentSystem = PackageTable
    End Sub

    Private Sub SetupGroupSummaryItems()

        GridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
        ' Create and setup the first summary item.
        item1.FieldName = "System"
        item1.Tag = "System"
        item1.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.GroupSummary.Add(item1)
        ' Create and setup the second summary item.
        itemReqdMhrs.FieldName = "ReqdMhrs"
        itemReqdMhrs.Tag = "ReqdMhrs"
        itemReqdMhrs.SummaryType = DevExpress.Data.SummaryItemType.Sum
        itemReqdMhrs.DisplayFormat = "Reqd Mhrs Total {0:n2}"
        itemReqdMhrs.ShowInGroupColumnFooter = GridView1.Columns("ReqdMhrs")
        GridView1.GroupSummary.Add(itemReqdMhrs)

        itemEarnedMhrs.FieldName = "EarnedMhrs"
        itemEarnedMhrs.Tag = "EarnedMhrs"
        itemEarnedMhrs.SummaryType = DevExpress.Data.SummaryItemType.Sum
        itemEarnedMhrs.DisplayFormat = "Earned Mhrs Total {0:n2}"
        itemEarnedMhrs.ShowInGroupColumnFooter = GridView1.Columns("EarnedMhrs")
        GridView1.GroupSummary.Add(itemEarnedMhrs)

        itemLevel.FieldName = "Level"
        itemLevel.Tag = "Level"
        itemLevel.SummaryType = DevExpress.Data.SummaryItemType.Min
        itemLevel.DisplayFormat = "Status {0:n}"
        itemLevel.ShowInGroupColumnFooter = GridView1.Columns("Level")
        GridView1.GroupSummary.Add(itemLevel)

        itemPcnt.FieldName = "PercentComplete"
        itemPcnt.Tag = "PercentComplete"
        itemPcnt.SummaryType = DevExpress.Data.SummaryItemType.Custom
        itemPcnt.DisplayFormat = "% Complete {0:n2}"
        itemPcnt.ShowInGroupColumnFooter = GridView1.Columns("PercentComplete")
        GridView1.GroupSummary.Add(itemPcnt)
    End Sub

    Private Sub dgv_PackageData_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_PackageData.DoubleClick
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = dgv_PackageData.MainView
        Dim ParentView As DevExpress.XtraGrid.Views.Grid.GridView = View.ParentView

        Dim PackageMUID As String = View.GetFocusedDataRow.Item("MUID")
        Dim PackageName As String = View.GetFocusedDataRow.Item("Package")
        PackageViewer.PackageViewerManager.OpenPackage(PackageMUID, PackageName)
    End Sub


    Private Sub cbx_Owner_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_Owner.SelectedIndexChanged
        If Loading Then Return
        InitializeOverview()
        CurrentOwner = cbx_Owner.SelectedValue
    End Sub


    Private Sub cbx_AllPackages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_AllPackages.CheckedChanged
        If Loading Then Return
        Me.Cursor = Cursors.WaitCursor
        InitializeOverview()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub tbp_Documents_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbp_Documents.Enter
        LoadDocs()
    End Sub


    Private Sub LoadDocs()
        Dim query As String = "SELECT DocumentMUID FROM package_documents WHERE SystemMUID LIKE '" + SystemNumber + "%'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
        'sqlDocUtils.OpenConnection()

        If Not dt.Rows.Count = 0 Then
            Dim DocsList As String = "("
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                DocsList += "'" + dt.Rows(i)("DocumentMUID") & "',"
            Next

            DocsList = DocsList.TrimEnd(",")
            DocsList += ")"

            Dim dt_Docs As DataTable
            query = "Select documents.MUID As MUID, documents.EngCode As Document," & _
                " documents.Description, document_type.Description As Type," & _
                " documents.Revision As Rev, documents.Sheet As Sht From documents," & _
                " document_type WHERE documents.DocumentTypeMUID=document_type.MUID" & _
                " AND documents.MUID IN " & DocsList
            dt_Docs = runtime.SQLDaqument.ExecuteQuery(query)
            dt_Docs.Columns("MUID").ColumnMapping = MappingType.Hidden
            dt_Docs.Columns("Document").Caption = "Eng Code"

            For Each dr As DataRow In dt_Docs.Rows
                dr("Rev") = Utilities.TranslateRev(dr("Rev"))
            Next

            dgv_Documents.DataSource = dt_Docs
        Else
            dgv_Documents.DataSource = Nothing
            Me.tsp_DocumentEdit.Enabled = False
            Me.tsp_DocumentDelete.Enabled = False
            Me.tsp_DocumentView.Enabled = False
        End If
        'sqlDocUtils.CloseConnection()
    End Sub


    Private Sub tsp_DocumentAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsp_DocumentAdd.Click
        Dim frm_AddDoc As New AddSystemDocument(Me.SystemNumber)
        frm_AddDoc.ShowDialog()
        LoadDocs()
    End Sub


    Private Sub tbp_Discrepancies_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbp_Discrepancies.Enter
        listDiscrepancies = False
        dgv_Discrepancies.Visible = False
        Dim qry = "select discrepancy.MUID as MUID,discrepancy.Description as description, " + _
            " ListedOn, ListedBy, Resolution, Title,Status, " + _
            " PackageNumber from discrepancy,package WHERE " + _
            " package.SystemMUID " + Utilities.SystemQuery(SystemNumber) + _
            " AND discrepancy.PackageMUID=package.MUID"

        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
        'sqlPrjUtils.CloseConnection()

        Dim RecordTop As Integer = 25
        For j As Integer = 0 To dt.Rows.Count - 1
            'Dim UserTable = Utilities.GetUserInfo(dt.Rows(j)("ListedBy"))
            Dim DiscrepancyObject = New DiscrepancyManager.ControlDiscrepancy()
            With DiscrepancyObject
                .Name = "DiscrepancyObject" & dt.Rows(j)("MUID").ToString
                .Tag = dt.Rows(j)("MUID")
                .Visible = True
                .Left = 10
                .Top = RecordTop
                .tbx_Title.Text = dt.Rows(j)("Title")
                .tbx_Description.Text = dt.Rows(j)("Description")
                .tbx_ListedBy.Text = Utilities.GetUserName(dt.Rows(j)("ListedBy"))
                .tbx_ListedOn.Text = dt.Rows(j)("ListedOn")
                .tbx_Resolution.Text = dt.Rows(j)("Resolution")
                .tbx_PackageID.Text = dt.Rows(j)("PackageNumber")
                .tbx_Status.Text = dt.Rows(j)("Status")
                .Cursor = Cursors.Hand
            End With

            RecordTop += 250
            pnl_Discrepancies.Controls.Add(DiscrepancyObject)
        Next
    End Sub

    '  /* •—————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    ' | Private Sub tbp_Punchlist_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbp_Punchlist.Enter                                                    |
    ' |     listPunchlist = True                                                                                                                                            |
    ' |     'dgv_Punchlist.Visible = False                                                                                                                                  |
    ' |     Dim query As String = "SELECT * FROM punchlist WHERE SystemMUID " + Utilities.SystemQuery(SystemNumber) + ""                                                    |
    ' |     Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)                                                                                                    |
    ' |                                                                                                                                                                     |
    ' |     Dim i As Integer = 1                                                                                                                                            |
    ' |     Dim RecordTop As Integer = 25                                                                                                                                   |
    ' |                                                                                                                                                                     |
    ' |     For j As Integer = 0 To dt.Rows.Count - 1                                                                                                                       |
    ' |         '     PunchlistObject = New PunchlistManager.ControlPunchlist()                                                                                             |
    ' |         With PunchlistObject                                                                                                                                        |
    ' |             .Name = "PunchlistObject" & dt.Rows(j)("MUID").ToString                                                                                                 |
    ' |             .Tag = dt.Rows(j)("MUID")                                                                                                                               |
    ' |             .Visible = True                                                                                                                                         |
    ' |             .Left = 10                                                                                                                                              |
    ' |             .Top = RecordTop                                                                                                                                        |
    ' |             .tbx_ID.Text = Utilities.GetUserInfoByMUID(dt.Rows(j)("ListedBY")).Rows(0)("UserName") + "-" + Split(dt.Rows(j)("MUID"), "&001")(1) 'dt.Rows(j)("MUID") |
    ' |             .tbx_Description.Text = dt.Rows(j)("Description")                                                                                                       |
    ' |             .tbx_Tag.Text = Utilities.TranslateTagID(dt.Rows(j)("TagMUID"))                                                                                         |
    ' |             .tbx_Priority.Text = dt.Rows(j)("Priority").ToString                                                                                                    |
    ' |             .tbx_Status.Text = dt.Rows(j)("Status")                                                                                                                 |
    ' |             .tbx_Location.Text = dt.Rows(j)("Location")                                                                                                             |
    ' |             .Cursor = Cursors.Hand                                                                                                                                  |
    ' |         End With                                                                                                                                                    |
    ' |                                                                                                                                                                     |
    ' |         RecordTop += 150                                                                                                                                            |
    ' |         pnl_Punchlist.Controls.Add(PunchlistObject)                                                                                                                 |
    ' |                                                                                                                                                                     |
    ' |         AddHandler PunchlistObject.Click, AddressOf PunchlistObject_Click                                                                                           |
    ' |         AddHandler PunchlistObject.DoubleClick, AddressOf PunchlistObject_DoubleClick                                                                               |
    ' |     Next                                                                                                                                                            |
    ' |                                                                                                                                                                     |
    ' | End Sub                                                                                                                                                             |
    '  •—————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————• */

    '/* •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    ' |                                                                                                                          |
    ' |     Private Sub PunchlistObject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PunchlistObject.Click |
    ' |         Dim tempObject As New PunchlistManager.ControlPunchlist()                                                        |
    ' |         tempObject = sender                                                                                              |
    ' |                                                                                                                          |
    ' |         For Each thisPunchlist As Control In pnl_Punchlist.Controls                                                      |
    ' |             If thisPunchlist.Name = tempObject.Name Then                                                                 |
    ' |                 thisPunchlist.BackColor = Color.Red                                                                      |
    ' |             Else                                                                                                         |
    ' |                 thisPunchlist.BackColor = Color.Gray                                                                     |
    ' |             End If                                                                                                       |
    ' |         Next thisPunchlist                                                                                               |
    ' |     End Sub                                                                                                              |
    '  •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————• */

    '/* •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    ' |                                                                                                                                      |
    ' |     Private Sub PunchlistObject_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PunchlistObject.DoubleClick |
    ' |         Dim tempObject As New PunchlistManager.ControlPunchlist()                                                                    |
    ' |         tempObject = sender                                                                                                          |
    ' |                                                                                                                                      |
    ' |         Dim frmPunchlistEdit As New PunchlistManager.EditPunchlist(tempObject.Tag, runtime.selectedProjectID)                        |
    ' |         frmPunchlistEdit.txtPunchlist.Text = tempObject.Tag                                                                          |
    ' |         frmPunchlistEdit.ShowDialog()                                                                                                |
    ' |         InitializeOverview()                                                                                                         |
    ' |                                                                                                                                      |
    ' |     End Sub                                                                                                                          |
    '  •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————• */


    Private Sub btn_ListPunchlist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ListPunchlist.Click
        ShowPunchlistGrid()
    End Sub


    Private Sub ShowPunchlistGrid()
        Dim descEdit As RepositoryItemMemoEdit

        If listPunchlist = False Then
            listPunchlist = True
        Else
            listPunchlist = False
        End If
        If listPunchlist Then
            'Dim qry = " SELECT " + _
            '"MUID, Description, ListedBy, ListedOn, ClosedBy, " + _
            '"ClosedOn, Status, Type, CompletedBy, CompletedOn, ApprovedBy, " + _
            '"ApprovedOn, Location, ResponsiblePartymuid, ResponsibleDisciplineMUID, " + _
            '"EstimatedDate, Priority, RequiredDate " + _
            '"FROM punchlist WHERE SystemMUID " + Utilities.SystemQuery(SystemNumber)
            'Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)

            Dim query As String = "SELECT * FROM punchlist WHERE SystemMUID " + Utilities.SystemQuery(SystemNumber)

            Dim dt_punchlist As New DataTable
            dt_punchlist.Columns.Add("MUID")
            dt_punchlist.Columns.Add("Project")
            dt_punchlist.Columns.Add("System")
            dt_punchlist.Columns.Add("Status")
            dt_punchlist.Columns.Add("ProjectMUID")
            dt_punchlist.Columns.Add("PunchlistID")
            'dt_punchlist.Columns.Add("SystemMUID")
            dt_punchlist.Columns.Add("RFI #")
            dt_punchlist.Columns.Add("Description")
            dt_punchlist.Columns.Add("Location")
            dt_punchlist.Columns.Add("MC Priority")
            dt_punchlist.Columns.Add("SH Priority")
            dt_punchlist.Columns.Add("Target Missed")
            dt_punchlist.Columns.Add("ListedBy")
            dt_punchlist.Columns.Add("ListedOn")
            dt_punchlist.Columns.Add("Action By")
            dt_punchlist.Columns.Add("CompletedOn")
            dt_punchlist.Columns.Add("CompletedBy")
            dt_punchlist.Columns.Add("ClosedBy")
            dt_punchlist.Columns.Add("ClosedOn")
            'dt_punchlist.Columns.Add("TagMUID")
            dt_punchlist.Columns.Add("TagNumber")
            dt_punchlist.Columns.Add("Comments")
            'dt_punchlist.Columns.Add("ListedByMUID")
            'dt_punchlist.Columns.Add("ApprovedByMUID")
            dt_punchlist.Columns.Add("ApprovedBy")
            dt_punchlist.Columns.Add("ApprovedOn")
            'dt_punchlist.Columns.Add("CompletedByMUID")
            'dt_punchlist.Columns.Add("ResponsiblePartyMUID")

            Dim ProjectList As New List(Of String)

            ProjectList.Add(runtime.selectedProjectID)

            Dim OriginalProject As String = runtime.selectedProjectID
            For u As Integer = 0 To ProjectList.Count - 1
                Dim ThisProject As String = Utilities.GetProjectName(ProjectList(u))

                If Not ThisProject = "0" Then
                    runtime.selectedProjectID = ProjectList(u)
                    runtime.selectedProject = ThisProject
                    runtime.SQLProject = New DataUtilsGlobal("project")
                    runtime.SQLProject.OpenConnection()
                    Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

                    If Not dt Is Nothing Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            dt_punchlist.Rows.Add()
                            Dim ThisRow As Integer = dt_punchlist.Rows.Count - 1
                            dt_punchlist.Rows(ThisRow)("Project") = ThisProject
                            dt_punchlist.Rows(ThisRow)("System") = SystemManager.SystemDataManager.TranslateSystemID(dt.Rows(i)("SystemMUID").ToString)
                            dt_punchlist.Rows(ThisRow)("ProjectMUID") = ProjectList(u)
                            dt_punchlist.Rows(ThisRow)("MUID") = dt.Rows(i)("MUID")
                            dt_punchlist.Rows(ThisRow)("PunchlistID") = Utilities.GetUserInfoByMUID(dt.Rows(i)("ListedBY")).Rows(0)("UserName") + "-" + Split(dt.Rows(i)("MUID"), "&001")(1)
                            dt_punchlist.Rows(ThisRow)("RFI #") = dt.Rows(i)("Aux08")
                            dt_punchlist.Rows(ThisRow)("Location") = dt.Rows(i)("Location")
                            dt_punchlist.Rows(ThisRow)("MC Priority") = dt.Rows(i)("Priority").ToString
                            dt_punchlist.Rows(ThisRow)("SH Priority") = dt.Rows(i)("Aux09").ToString
                            dt_punchlist.Rows(ThisRow)("Target Missed") = dt.Rows(i)("Aux07").ToString
                            dt_punchlist.Rows(ThisRow)("Description") = dt.Rows(i)("Description").ToString
                            dt_punchlist.Rows(ThisRow)("Status") = dt.Rows(i)("Status").ToString
                            dt_punchlist.Rows(ThisRow)("Comments") = dt.Rows(i)("CompletedComments").ToString
                            'dt_punchlist.Rows(ThisRow)("TagMUID") = dt.Rows(i)("TagMUID").ToString
                            If dt.Rows(i)("TagMUID").ToString = "" Then
                                dt_punchlist.Rows(ThisRow)("TagNumber") = "No Tag"
                            Else
                                dt_punchlist.Rows(ThisRow)("TagNumber") = Utilities.TranslateTagID(dt.Rows(i)("TagMUID"))
                            End If
                            'dt_punchlist.Rows(i)("ListedByMUID") = dt.Rows(i)("ListedBy")
                            If dt.Rows(i)("ListedBy").ToString > "" Then
                                dt_punchlist.Rows(i)("ListedBy") = Utilities.GetUserName(dt.Rows(i)("ListedBY"))
                            End If
                            'dt_punchlist.Rows(i)("ApprovedByMUID") = dt.Rows(i)("ApprovedBY")
                            If dt.Rows(i)("ApprovedBY").ToString > "" Then
                                dt_punchlist.Rows(ThisRow)("ApprovedBy") = Utilities.GetUserName(dt.Rows(i)("ApprovedBY"))
                            End If
                            'dt_punchlist.Rows(i)("CompletedByMUID") = dt.Rows(i)("CompletedBY")
                            If dt.Rows(i)("CompletedBY").ToString > "" Then
                                dt_punchlist.Rows(ThisRow)("CompletedBy") = Utilities.GetUserName(dt.Rows(i)("CompletedBY"))
                            End If
                            If dt.Rows(i)("ClosedBY").ToString > "" Then
                                dt_punchlist.Rows(ThisRow)("ClosedBy") = Utilities.GetUserName(dt.Rows(i)("ClosedBY"))
                            End If
                            'dt_punchlist.Rows(ThisRow)("ResponsiblePartyMUID") = dt.Rows(i)("ResponsiblePartymuid")


                            If dt.Rows(i)("ListedOn").ToString > "" Then
                                dt_punchlist.Rows(i)("ListedOn") = dt.Rows(i)("ListedOn")
                            End If
                            'dt_punchlist.Rows(i)("ApprovedByMUID") = dt.Rows(i)("ApprovedBY")
                            If dt.Rows(i)("ApprovedOn").ToString > "" Then
                                dt_punchlist.Rows(ThisRow)("ApprovedOn") = dt.Rows(i)("ApprovedOn")
                            End If
                            'dt_punchlist.Rows(i)("CompletedByMUID") = dt.Rows(i)("CompletedBY")
                            If dt.Rows(i)("CompletedOn").ToString > "" Then
                                dt_punchlist.Rows(ThisRow)("CompletedOn") = dt.Rows(i)("CompletedOn")
                            End If
                            If dt.Rows(i)("ClosedBY").ToString > "" Then
                                dt_punchlist.Rows(ThisRow)("ClosedOn") = dt.Rows(i)("ClosedOn")
                            End If

                            If dt.Rows(i)("ResponsiblePartymuid").ToString > "" Then
                                Dim qry As String = "SELECT Name From Company WHERE MUID = '" + dt.Rows(i)("ResponsiblePartymuid") + "'"
                                Dim dtt As DataTable = runtime.SQLServer.ExecuteQuery(qry)
                                dt_punchlist.Rows(ThisRow)("Action By") = dtt.Rows(0)(0).ToString
                            End If
                        Next
                    End If
                End If

            Next

            runtime.selectedProjectID = OriginalProject
            runtime.selectedProject = Utilities.GetProjectName(OriginalProject)
            runtime.SQLProject = New DataUtilsGlobal("project")
            runtime.SQLProject.OpenConnection()

            'dt_punchlist.Columns("SystemMUID").ColumnMapping = MappingType.Hidden
            dt_punchlist.Columns("MUID").ColumnMapping = MappingType.Hidden
            dt_punchlist.Columns("ProjectMUID").ColumnMapping = MappingType.Hidden
            'dt_punchlist.Columns("ListedByMUID").ColumnMapping = MappingType.Hidden
            'dt_punchlist.Columns("ApprovedByMUID").ColumnMapping = MappingType.Hidden
            'dt_punchlist.Columns("CompletedByMUID").ColumnMapping = MappingType.Hidden
            'dt_punchlist.Columns("ResponsiblePartyMUID").ColumnMapping = MappingType.Hidden

            'dt = PunchlistDataManager.SearchRecords(strquery)

            If Not dgv_Punchlist.DataSource Is Nothing Then
                dgv_Punchlist.DataSource = Nothing
            End If

            'If (Not dt Is Nothing) Then
            'dgvSearch.DataSource = dt_punchlist
            dgv_Punchlist.DataSource = dt_punchlist
            CType(Me.dgv_Punchlist.MainView, GridView).Columns("Description").ColumnEdit = descEdit
            CType(Me.dgv_Punchlist.MainView, GridView).OptionsView.RowAutoHeight = True


            Dim View As ColumnView = dgv_Punchlist.MainView
            Dim ParentView As GridView = View.ParentView

            View.Columns("PunchlistID").Visible = False
            'View.Columns("ListedOn").Visible = False
            View.Columns("ApprovedOn").Visible = False
            'View.Columns("CompletedOn").Visible = False
            View.Columns("ClosedOn").Visible = False
            View.Columns("ApprovedBy").Visible = False
            'View.Columns("CompletedBy").Visible = False
            'View.Columns("ClosedBy").Visible = False
            View.Columns("TagNumber").Visible = False

            View.Columns("Project").Group()
            View.Columns("System").Group()

            Dim thisME As New RepositoryItemMemoEdit
            thisME.AcceptsReturn = True
            thisME.WordWrap = True


            View.Columns("Description").ColumnEdit = thisME
            View.Columns("Location").ColumnEdit = thisME
            View.Columns("ListedBy").ColumnEdit = thisME
            View.Columns("ListedOn").ColumnEdit = thisME
            View.Columns("Action By").ColumnEdit = thisME
            View.Columns("CompletedOn").ColumnEdit = thisME
            View.Columns("CompletedBy").ColumnEdit = thisME
            View.Columns("ClosedOn").ColumnEdit = thisME
            View.Columns("ClosedBy").ColumnEdit = thisME
            View.Columns("Comments").ColumnEdit = thisME











            'old code starts here
            'If Not dgv_Punchlist.DataSource Is Nothing Then
            '    dgv_Punchlist.DataSource.Dispose()
            'End If
            'dgv_Punchlist.DataSource = dt
            dgv_Punchlist.Visible = True
            dgv_Punchlist.BringToFront()
        Else
            dgv_Punchlist.Visible = False
        End If

    End Sub



    Private Sub btn_ListDiscrpancies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ListDiscrpancies.Click
        If listDiscrepancies = False Then
            listDiscrepancies = True
        Else
            listDiscrepancies = False
        End If
        If listDiscrepancies Then
            Dim qry = "select discrepancy.MUID,discrepancy.Description, " + _
                " ListedOn, ListedBy, Resolution, Title,Status, " + _
                " PackageNumber from discrepancy,package WHERE " + _
                " package.SystemMUID " + Utilities.SystemQuery(SystemNumber) + _
                " AND discrepancy.PackageMUID=package.MUID"

            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
            'sqlPrjUtils.CloseConnection()
            If Not dgv_Discrepancies.DataSource Is Nothing Then
                dgv_Discrepancies.DataSource.Dispose()
            End If
            dgv_Discrepancies.DataSource = dt
            dgv_Discrepancies.Visible = True
            dgv_Discrepancies.BringToFront()
        Else
            dgv_Discrepancies.Visible = False
        End If

    End Sub


    Private Sub dgv_Documents_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Documents.DoubleClick
        Dim View As ColumnView = Me.dgv_Documents.MainView
        Dim ParentView As GridView = View.ParentView

        Dim frm_DocumentViewer As New Daqument.EditDaqument(View.GetFocusedRowCellValue("MUID"))
        frm_DocumentViewer.Show()
    End Sub


    Private Sub GridView2_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView2.RowStyle
        If e.RowHandle < 0 Then Return
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        Dim match As Boolean = False
        Dim DocID As String = View.GetDataRow(e.RowHandle)(0)

        Dim query As String = "SELECT PackageMUID FROM package_documents WHERE SystemMUID LIKE '" + SystemNumber + "%'" + " AND DocumentMUID = " + DocID.ToString
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim pkgID As Integer = dt.Rows(i)("PackageMUID")
            If pkgID > 0 Then
                If Utilities.TestPkgDocContainsRedLineItems(DocID, dt.Rows(i)("PackageMUID")) Then
                    e.Appearance.BackColor = Color.Red
                End If
            End If
        Next
    End Sub


    Private Sub btn_PrintOverview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PrintOverview.Click
        Dim xgp As XtraGridPrinting = New XtraGridPrinting("System Overview", Me.SplitContainer1.Panel1, Me.dgv_PackageData)
        xgp.Show()
    End Sub


    Dim earnedMhrs As Single = 0
    Dim reqdMHrs As Single = 0
    Dim grandTotalearnedMhrs As Single = 0
    Dim grandTotalreqdMHrs As Single = 0

    'Private Sub OLDGridView1_CustomSummaryCalculate(ByVal sender As DevExpress.XtraGrid.Views.Grid.GridView, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles Me.GridView1.CustomSummaryCalculate
    '    Dim View As GridView = CType(sender, GridView)
    '    If e.IsTotalSummary Then Return
    '    If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
    '        Dim rqd As Single = (View.GetRowCellValue(e.RowHandle, "ReqdMhrs"))
    '        reqdMHrs = reqdMHrs + rqd
    '        Dim erd As Single = (View.GetRowCellValue(e.RowHandle, "EarnedMhrs"))
    '        earnedMhrs = earnedMhrs + erd
    '        Return
    '    End If

    '    Dim summaryID As String = (CType(e.Item, GridSummaryItem).Tag)
    '    Dim itm As DevExpress.XtraGrid.GridGroupSummaryItem = CType(e.Item, GridGroupSummaryItem)
    '    If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
    '        earnedMhrs = 0
    '        reqdMHrs = 0
    '        Return
    '    End If
    '    If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
    '        Select Case summaryID
    '            Case "PercentComplete"
    '                'If GridView1.GroupSummary("ReqdMHrs").SummaryValue > 0 Then
    '                '    e.TotalValue = GridView1.GroupSummary("EarnedMhrs").SummaryValue * 100 / GridView1.GroupSummary("ReqdMHrs").SummaryValue
    '                'Else
    '                '    e.TotalValue = 0
    '                'End If
    '                grandTotalearnedMhrs = grandTotalearnedMhrs + earnedMhrs
    '                grandTotalreqdMHrs = grandTotalreqdMHrs + reqdMHrs
    '                Try
    '                    If reqdMHrs > 0 Then
    '                        e.TotalValue = earnedMhrs * 100 / reqdMHrs
    '                    Else
    '                        e.TotalValue = 0
    '                    End If
    '                    txtReqdMhrs.Text = String.Format("{0:n2}", grandTotalreqdMHrs)
    '                    txtEarnedMhrs.Text = String.Format("{0:n2}", grandTotalearnedMhrs)
    '                    If grandTotalreqdMHrs > 0 Then
    '                        txtPcntComplete.Text = String.Format("%{0:n2}", (grandTotalearnedMhrs * 100 / grandTotalreqdMHrs))
    '                    Else
    '                        txtPcntComplete.Text = "0"
    '                    End If

    '                Catch ex As Exception

    '                End Try
    '        End Select
    '    End If
    'End Sub

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub btn_ITS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ITS.Click
        Me.Cursor = Cursors.WaitCursor
        'Dim frm_ShowExport As New CommonForms.DataExport(MakeITS())
        'Me.Cursor = Cursors.Default
        'frm_ShowExport.Show()
        Dim frm_ShowExport As New SystemITS(Me.SystemNumber, MakeITS(), Me.cbx_Owner.SelectedValue)
        Me.Cursor = Cursors.Default
        frm_ShowExport.Show()
    End Sub


    Public Function MakeITS() As DataTable
        Dim dt_FieldList As New DataTable
        Dim dt_TagIDList As New DataTable
        Dim dt_Final As New DataTable
        Dim dt_Tags As New DataTable

        dt_Final.Columns.Add("MUID")
        dt_Final.Columns("MUID").ColumnMapping = MappingType.Hidden

        dt_Final.Columns.Add("TypeMUID")
        dt_Final.Columns("TypeMUID").ColumnMapping = MappingType.Hidden

        dt_Final.Columns.Add("Package#")
        dt_Final.Columns.Add("Tag#")
        dt_Final.Columns.Add("Discipline")
        dt_Final.Columns.Add("Discrepancy")

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

            Dim OwnerCriteria As String = Nothing
            If Not Me.cbx_AllPackages.Checked Then
                OwnerCriteria = " AND requirements.OwnerMUID = '" + Me.cbx_Owner.SelectedValue + "'"
            Else
                OwnerCriteria = ""
            End If

            query = "SELECT tags.MUID, package.PackageNumber, tags.TagNumber, " & _
                    " equipment_type.MUID As TypeMUID, equipment_type.TypeName, package.DisciplineMUID," & _
                    " engineering_data.Description FROM tags INNER JOIN" & _
                    " package ON tags.PackageMUID = package.MUID INNER JOIN" & _
                    " equipment_type ON tags.TypeMUID = equipment_type.MUID LEFT OUTER JOIN" & _
                    " engineering_data ON tags.MUID = engineering_data.TagMUID" & _
                    " WHERE package.SystemMUID " + Utilities.SystemQuery(Me.SystemNumber) & _
                    " ORDER BY tags.TagNumber ASC, engineering_data.TS DESC"
            dt_Tags = runtime.SQLProject.ExecuteQuery(query)

            For i As Integer = 0 To dt_Tags.Rows.Count - 1
                Dim HasDiscrepancy As String = "No"
                If Utilities.PackageDiscrepancy(dt_Tags.Rows(i)("PackageNumber")) Then
                    HasDiscrepancy = "Yes"
                Else
                    HasDiscrepancy = "No"
                End If

                dt_Final.Rows.Add(dt_Tags.Rows(i)("MUID"), dt_Tags.Rows(i)("TypeMUID"), dt_Tags.Rows(i)("PackageNumber"), _
                    dt_Tags.Rows(i)("TagNumber"), Utilities.GetDisciplineName(dt_Tags.Rows(i)("DisciplineMUID")), _
                    HasDiscrepancy, dt_Tags.Rows(i)("TypeName"), _
                    dt_Tags.Rows(i)("Description"))
            Next

            For i As Integer = 0 To dt_Final.Rows.Count - 1
                query = "SELECT requirements.ManHours,  requirements.FormMUID" & _
                        " FROM requirements INNER JOIN forms ON requirements.FormMUID = forms.MUID" & _
                        " WHERE requirements.TypeMUID='" + dt_Final.Rows(i)("TypeMUID") + "'" + OwnerCriteria


                Dim dt_Req As DataTable = runtime.SQLProject.ExecuteQuery(query)

                For u As Integer = 0 To dt_Final.Columns.Count - 1
                    For Each dr As DataRow In dt_Req.Rows
                        If dt_Final.Columns(u).ColumnName = dr(1) Then
                            'dt_Final.Rows(i)(u) = dr(0)
                            Dim FormStatusLevel As Integer = Utilities.GetFormStatus(dt_Final.Rows(i)(0), dr(1), Me.cbx_Owner.SelectedValue)
                            Dim FormStatusDescription As String = Utilities.GetStatusDescription(Me.cbx_Owner.SelectedValue, Utilities.GetFormStatus(dt_Final.Rows(i)(0), dr(1), Me.cbx_Owner.SelectedValue))
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

        dt_Final.DefaultView.Sort = "Package# ASC"

        Dim dt_temp As DataTable = dt_Final.DefaultView.Table

        Return dt_Final
    End Function

    '/* •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    ' |                                                                                                                                  |
    ' |     Private Sub dgv_Punchlist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Punchlist.DoubleClick |
    ' |         Me.Cursor = Cursors.WaitCursor                                                                                           |
    ' |         Dim View As ColumnView = dgv_Punchlist.MainView                                                                          |
    ' |         Dim ParentView As GridView = View.ParentView                                                                             |
    ' |                                                                                                                                  |
    ' |         Dim frmeditsearch As New PunchlistManager.EditPunchlist(View.GetFocusedRowCellValue("MUID"), runtime.selectedProjectID)  |
    ' |         frmeditsearch.ShowDialog()                                                                                               |
    ' |                                                                                                                                  |
    ' |         Me.Cursor = Cursors.Default                                                                                              |
    ' |     End Sub                                                                                                                      |
    '  •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————• */


    Private Sub btn_PunchlistExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PunchlistExport.Click
        Dim xgp As CommonForms.XtraGridPrinting = New CommonForms.XtraGridPrinting("IWL Report for System " + Me.SystemID, Me.dgv_Punchlist)
        xgp.Show()
    End Sub



End Class
