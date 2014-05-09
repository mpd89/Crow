Imports System.Data
Imports CommonForms.Classes
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Threading
Imports daqartDLL


Public Class DiscrepancyMain
    Dim dt As DataTable
    Dim sqlPrjUtils As DataUtils
    Dim sqlSrvUtils As DataUtils



    Private Sub DiscrepancyMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            sqlPrjUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            sqlSrvUtils = New DataUtils("server")
            sqlSrvUtils.OpenConnection()


            Me.tsl_SiteLabel.Text = "Site: " + runtime.SiteName
            Me.ProjectStatusInd.Text = "Project: " + runtime.selectedProject

            Dim flag As New System.Drawing.Bitmap(100, 100)
            Dim x As Integer
            Dim y As Integer
            For x = 0 To flag.Height - 1
                For y = 0 To flag.Width - 1
                    flag.SetPixel(x, y, Color.White)
                Next
            Next

            For x = 0 To flag.Height - 1
                flag.SetPixel(x, x, Color.Red)
            Next

            PopulateListedBy()
            PopulateClosedBy()
            PopulateDiscrepancyID()
        Catch ex As Exception
            Utilities.logErrorMessage("DiscrepancyManager.DiscrepancyMain._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub PopulateListedBy()
        Dim query As String = "SELECT DISTINCT(ListedBy) from discrepancy WHERE ListedBy !='' OR ListedBy != null"

        'Dim dt As New DataTable
        'dt = Utilities.ExecuteQuery(query, "project")
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)


        dt.DefaultView.Sort = String.Format("{0} {1}", "ListedBy", "ASC")
        dt = dt.DefaultView.Table

        Dim dt_show As New DataTable
        dt_show.Columns.Add("userName")
        dt_show.Columns.Add("userID")
        dt_show.Rows.Add("")
        For Each dr As DataRow In dt.Rows
            Dim drShow As DataRow = dt_show.NewRow
            drShow("userID") = dr("ListedBy")
            drShow("userName") = Utilities.GetUserName(dr("ListedBy"))

            dt_show.Rows.Add(drShow)
        Next

        Me.cbxListedBy.DataSource = dt_show
        Me.cbxListedBy.DisplayMember = dt_show.Columns("userName").ToString
        Me.cbxListedBy.ValueMember = dt_show.Columns("userID").ToString
        Me.cbxListedBy.SelectedIndex = -1

    End Sub
    Private Sub PopulateDiscrepancyID()

        'dt_discrepancy.Rows(i)("discrepancyID") = Utilities.GetUserInfoByMUID(dt.Rows(i)("ListedBY")).Rows(0)("UserName") + "-" + Split(dt.Rows(i)("MUID"), "&001")(1)

        Dim query As String = "SELECT DISTINCT ListedBy, MUID from discrepancy"

        'Dim dt As New DataTable
        'dt = Utilities.ExecuteQuery(query, "project")
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)


        dt.DefaultView.Sort = String.Format("{0} {1}", "ListedBy", "ASC")
        dt = dt.DefaultView.Table

        Dim dt_show As New DataTable
        dt_show.Columns.Add("DiscrepancyID")
        dt_show.Columns.Add("MUID")
        dt_show.Rows.Add("")
        For Each dr As DataRow In dt.Rows
            Dim drShow As DataRow = dt_show.NewRow
            drShow("DiscrepancyID") = Utilities.GetUserInfoByMUID(dr("ListedBy")).Rows(0)("UserName") + "-" + Split(dr("MUID"), "&001")(1)
            drShow("MUID") = dr("MUID")
            dt_show.Rows.Add(drShow)
        Next

        Me.cboDiscrepancyID.DataSource = dt_show
        Me.cboDiscrepancyID.DisplayMember = dt_show.Columns("DiscrepancyID").ToString
        Me.cboDiscrepancyID.ValueMember = dt_show.Columns("MUID").ToString
        Me.cboDiscrepancyID.SelectedIndex = -1

    End Sub


    Private Sub PopulateClosedBy()
        Dim query As String = "SELECT DISTINCT(ClosedBy) from discrepancy WHERE (ClosedBy IS NOT NULL)"
        'Dim dtme As New DataTable
        'dtme = Utilities.ExecuteQuery(query, "project")
        Dim dtme As DataTable = sqlPrjUtils.ExecuteQuery(query)

        dtme.DefaultView.Sort = String.Format("{0} {1}", "ClosedBy", "ASC")
        dtme = dtme.DefaultView.Table

        Dim dt_show As New DataTable
        dt_show.Columns.Add("userName")
        dt_show.Columns.Add("userID")
        dt_show.Rows.Add("")
        For Each dr As DataRow In dtme.Rows
            Dim drShow As DataRow = dt_show.NewRow
            drShow("userID") = dr("ClosedBy")
            drShow("userName") = Utilities.GetUserName(dr("ClosedBy"))
            dt_show.Rows.Add(drShow)
        Next

        Me.cbxClosedBy.DataSource = dt_show
        Me.cbxClosedBy.DisplayMember = dt_show.Columns("userName").ToString
        Me.cbxClosedBy.ValueMember = dt_show.Columns("userID").ToString
        Me.cbxClosedBy.SelectedIndex = -1

    End Sub


    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim PackageMUID As String = CommonForms.Classes.GetPackageID()
        If PackageMUID = "" Then
            Return
        End If

        PackageMUID = Utilities.TranslatePackageNumber(PackageMUID)
        Dim frmnew As New frmAddDiscrepancy(PackageMUID, CommonForms.Classes.GetPackageName(PackageMUID))
        frmnew.ShowDialog()
    End Sub

    Private Sub SetupGrid()
        Dim strquery As String = ""

        ' Search PunchlistID
        If (cboDiscrepancyID.Text <> "") Then
            strquery += " AND discrepancy.MUID = '" + cboDiscrepancyID.SelectedValue + "'"
        End If

        ' Search Description
        If (txtDescription.Text <> "") Then
            strquery += " AND discrepancy.Description LIKE '%" + txtDescription.Text + "%'"
        End If

        'search resolution
        If (txtResolution.Text <> "") Then
            strquery += " AND Resolution LIKE '%" + txtResolution.Text + "%'"
        End If

        ' Search title
        If (txtTitle.Text <> "") Then
            strquery += " AND Title LIKE '%" + txtTitle.Text + "%'"
        End If

        'Search ListedBy
        If (cbxListedBy.Text <> "") Then
            strquery += " AND ListedBy = '" + cbxListedBy.SelectedValue.ToString + "'"
        End If

        'Search ListedOn
        If (txtListedOnFrom.Text <> "") Then
            If (txtListedOnTo.Text <> "") Then
                strquery += " AND ListedOn  BETWEEN '" + txtListedOnFrom.Text + "'" + " AND '" + txtListedOnTo.Text + " 11:59:59 PM'"
            Else
                strquery += "AND ListedOn = '" + txtListedOnFrom.Text + "'"
            End If
        End If

        'Search ClosedBy
        If (cbxClosedBy.Text <> "") Then
            strquery += " AND ClosedBy = '" + cbxClosedBy.Text + "'"
        End If

        'Search ClosedOn
        If (txtClosedOnFrom.Text <> "") Then
            If (txtClosedOnTo.Text <> "") Then
                strquery += " AND ClosedOn  BETWEEN '" + txtClosedOnFrom.Text + "'" + " AND '" + txtClosedOnTo.Text + " 11:59:59 PM'"
            Else
                strquery += " AND ClosedOn LIKE '%" + txtClosedOnFrom.Text + "%'"
            End If
        End If

        Dim StatusString As String = ""
        If Me.cbx_Pending.Checked Then
            StatusString = "AND (discrepancy.Status='Pending'"
        End If
        If Me.cbx_Open.Checked Then
            If StatusString = "" Then
                StatusString = "AND (discrepancy.Status='Open'"
            Else
                StatusString += " OR discrepancy.Status='Open'"
            End If
        End If
        If Me.cbx_Resolved.Checked Then
            If StatusString = "" Then
                StatusString = "AND (discrepancy.Status='Resolved'"
            Else
                StatusString += " OR discrepancy.Status='Resolved'"
            End If
        End If
        If Me.cbx_NoAction.Checked Then
            If StatusString = "" Then
                StatusString = "AND (discrepancy.Status='No Action'"
            Else
                StatusString += " OR discrepancy.Status='No Action'"
            End If
        End If
        If Not StatusString = "" Then
            StatusString += ")"
            strquery += StatusString
        End If


        ' Search PackageID
        If (txtPackageID.Text <> "") Then
            Dim qry As String = "SELECT MUID FROM package WHERE packageNumber LIKE '%" + txtPackageID.Text + "%'"
            Dim dtt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            Dim ret As String = ""
            For ii As Integer = 0 To dtt.Rows.Count - 1
                ret = ret + "'" + dtt.Rows(ii)("MUID") + "',"
            Next
            If ret > "" Then
                ret = Strings.Left(ret, ret.Length - 1)
                strquery += " AND PackageMUID IN (" & ret & ")"
            End If
        End If

        Dim query As String = "SELECT discrepancy.*, package.* From discrepancy, package WHERE discrepancy.PackageMUID = package.MUID " + strquery + ""
        dt = sqlPrjUtils.ExecuteQuery(query)


        Dim dt_discrepancy As New DataTable
        dt_discrepancy.Columns.Add("MUID")
        dt_discrepancy.Columns.Add("discrepancyID")
        dt_discrepancy.Columns.Add("PackageNumber")
        dt_discrepancy.Columns.Add("ListedOn")
        dt_discrepancy.Columns.Add("System")
        dt_discrepancy.Columns.Add("Title")
        dt_discrepancy.Columns.Add("Description")
        dt_discrepancy.Columns.Add("Resolution")
        dt_discrepancy.Columns.Add("Status")
        dt_discrepancy.Columns.Add("Type")
        'dt_discrepancy.Columns.Add("TagMUID")
        'dt_discrepancy.Columns.Add("ListedByMUID")
        dt_discrepancy.Columns.Add("ListedBy")
        'dt_discrepancy.Columns.Add("ApprovedByMUID")
        dt_discrepancy.Columns.Add("ClosedBy")
        dt_discrepancy.Columns.Add("ManHours")
        dt_discrepancy.Columns.Add("CrossReferenceType")
        dt_discrepancy.Columns.Add("CrossReferenceNumber")



        If Not dt Is Nothing Then
            For i As Integer = 0 To dt.Rows.Count - 1
                dt_discrepancy.Rows.Add()
                dt_discrepancy.Rows(i)("MUID") = dt.Rows(i)("MUID")
                dt_discrepancy.Rows(i)("System") = SystemManager.SystemDataManager.TranslateSystemID(dt.Rows(i)("SystemMUID"))
                dt_discrepancy.Rows(i)("discrepancyID") = Utilities.GetUserInfoByMUID(dt.Rows(i)("ListedBY")).Rows(0)("UserName") + "-" + Split(dt.Rows(i)("MUID"), "&001")(1)
                'dt_discrepancy.Rows(i)("SystemMUID") = dt.Rows(i)("SystemMUID").ToString
                dt_discrepancy.Rows(i)("Description") = dt.Rows(i)("Description").ToString
                dt_discrepancy.Rows(i)("Status") = dt.Rows(i)("Status").ToString
                dt_discrepancy.Rows(i)("Type") = dt.Rows(i)("Type").ToString
                dt_discrepancy.Rows(i)("Title") = dt.Rows(i)("Title").ToString
                dt_discrepancy.Rows(i)("ManHours") = dt.Rows(i)("ManHours").ToString
                dt_discrepancy.Rows(i)("Resolution") = dt.Rows(i)("Resolution").ToString
                dt_discrepancy.Rows(i)("ListedOn") = dt.Rows(i)("ListedOn").ToString

                'dt_discrepancy.Rows(i)("TagMUID") = dt.Rows(i)("TagMUID").ToString
                If dt.Rows(i)("PackageMUID").ToString = "" Then
                    dt_discrepancy.Rows(i)("PackageNumber") = "No Pkg Association"
                Else
                    dt_discrepancy.Rows(i)("PackageNumber") = Utilities.GetPackageName(dt.Rows(i)("PackageMUID"))
                End If
                'dt_discrepancy.Rows(i)("ListedByMUID") = dt.Rows(i)("ListedBy")
                If dt.Rows(i)("ListedBy").ToString > "" Then
                    dt_discrepancy.Rows(i)("ListedBy") = Utilities.GetUserName(dt.Rows(i)("ListedBY"))
                End If
                If dt.Rows(i)("ClosedBY").ToString > "" Then
                    dt_discrepancy.Rows(i)("ClosedBy") = Utilities.GetUserName(dt.Rows(i)("ClosedBY"))
                End If
                'dt_discrepancy.Rows(i)("ResponsiblePartyMUID") = dt.Rows(i)("ResponsiblePartymuid")
                dt_discrepancy.Rows(i)("CrossReferenceType") = dt.Rows(i)("CrossReferenceType").ToString
                dt_discrepancy.Rows(i)("CrossReferenceNumber") = dt.Rows(i)("CrossReferenceType").ToString

            Next

        End If

        dt_discrepancy.Columns("MUID").ColumnMapping = MappingType.Hidden
        dgv_Results.DataSource = dt_discrepancy


        Me.tbc_DiscrepancyMain.SelectedTab = Me.tbp_Results

    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor
        SetupGrid()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub txtDiscrepancyID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim c As Char = e.KeyChar
        e.Handled = Not (Char.IsDigit(c))
    End Sub


    Private Sub txtClosedOnFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClosedOnFrom.Click
        Dim thisDate As String
        thisDate = Utilities.GetDate()
        txtClosedOnFrom.Text = thisDate
    End Sub


    Private Sub txtClosedOnTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClosedOnTo.Click
        Dim thisDate As String
        thisDate = Utilities.GetDate()
        txtClosedOnTo.Text = thisDate
    End Sub


    Private Sub txtListedOnFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtListedOnFrom.Click
        Dim thisDate As String
        thisDate = Utilities.GetDate()
        txtListedOnFrom.Text = thisDate
    End Sub


    Private Sub txtListedOnTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtListedOnTo.Click
        Dim thisDate As String
        thisDate = Utilities.GetDate()
        txtListedOnTo.Text = thisDate
    End Sub


    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        printList()
    End Sub


    Private Sub dgv_Results_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Results.DoubleClick
        Me.Cursor = Cursors.AppStarting

        Dim View As ColumnView = dgv_Results.MainView
        Dim ParentView As GridView = View.ParentView

        Dim frmeditsearch As New frmEditDiscrepancy(View.GetFocusedRowCellValue("MUID"))
        frmeditsearch.ShowDialog()

        Me.Cursor = Cursors.Default

        'SetupGrid()
    End Sub
    Private Sub printList()
        If Me.dgv_Results.DataSource Is Nothing Then
            MessageBox.Show("No data to print")
            Return
        End If
        Dim dt As DataTable = Me.dgv_Results.DataSource
        If dt.Rows.Count = 0 Then
            MessageBox.Show("No data to print")
            Return
        End If
        Dim ps As CommonForms.XtraGridPrinting = New CommonForms.XtraGridPrinting("Disacrepancies ", Me.dgv_Results)
        ps.ShowDialog()
    End Sub
    Private Sub PrintShortReport()
        If Me.dgv_Results.DataSource Is Nothing Then
            MessageBox.Show("No data to print")
            Return
        End If
        Dim dt As DataTable = Me.dgv_Results.DataSource
        If dt.Rows.Count = 0 Then
            MessageBox.Show("No data to print")
        End If
        Dim pgInfo() As PrintUtils.InfoSetting = DiscrepancyPrintUtils.MakeShortDiscrepancyPrintPages(Me.dgv_Results.DataSource)
        Dim ps As CommonForms.XtraGridPrinting = New CommonForms.XtraGridPrinting(pgInfo)
        ps.ShowDialog()
    End Sub

    Private Sub tsb_PrintList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_PrintList.Click
        printList()
    End Sub

    Private Sub tsb_PrintShortDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_PrintShortDescription.Click
        PrintUtils.ClearImageList()
        PrintShortReport()
    End Sub
    Private Sub DiscrepancyMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        sqlPrjUtils.CloseConnection()
        sqlSrvUtils.CloseConnection()
    End Sub

    Private Sub txtClosedOnFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClosedOnFrom.TextChanged

    End Sub
End Class