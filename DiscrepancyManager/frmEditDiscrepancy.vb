Imports System.Threading
Imports daqartDLL

Public Class frmEditDiscrepancy
    Dim sqlPrjUtils As DataUtils
    Dim sqlSrvUtils As DataUtils
    Dim DiscrepancyID As String

    Public Sub New(ByVal _ID As String)
        InitializeComponent()

        DiscrepancyID = _ID
    End Sub



    Private Sub frmEditDiscrepancy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            sqlPrjUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            sqlSrvUtils = New DataUtils("server")
            sqlSrvUtils.OpenConnection()

            Dim query As String = "select * from discrepancy where MUID = '" + DiscrepancyID + "'"
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            Me.txtDiscrepancy.Text = Utilities.GetUserInfoByMUID(dt.Rows(0)("ListedBY")).Rows(0)("UserName") + "-" + Split(dt.Rows(0)("MUID"), "&001")(1)


            txtClosedBy.Tag = dt.Rows(0)("ClosedBy").ToString
            If txtClosedBy.Tag > "" Then
                txtClosedBy.Text = Utilities.GetUserName(dt.Rows(0)("ClosedBy"))
            End If
            If (IsDate(dt.Rows(0)("ClosedOn").ToString)) Then
                txtClosedOn.Text = Now()
            End If
            txtDescription.Text = dt.Rows(0)("Description").ToString
            txtListedBy.Text = Utilities.GetUserName(dt.Rows(0)("ListedBy").ToString)
            txtListedBy.Tag = dt.Rows(0)("ListedBy").ToString
            txtListedOn.Text = dt.Rows(0)("ListedOn").ToString
            txtManHours.Text = dt.Rows(0)("ManHours").ToString
            txtResolution.Text = dt.Rows(0)("Resolution").ToString
            txtStatus.Text = dt.Rows(0)("Status").ToString
            txtTitle.Text = dt.Rows(0)("Title").ToString
            txtPackageID.Tag = dt.Rows(0)("PackageMUID").ToString
            If txtPackageID.Tag > "" Then
                txtPackageID.Text = Utilities.GetPackageName(dt.Rows(0)("PackageMUID").ToString)
            End If
        Catch ex As Exception
            Utilities.logErrorMessage("DiscrepancyManager.frmEditDiscrepancy._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Me.Cursor = Cursors.AppStarting
        Me.Enabled = False

        Dim query As String = "UPDATE discrepancy SET TS='" + Now() + "'," & _
            " PackageMUID=@PackageMUID," & _
            " Title=@Title," & _
            " Description=@Description," & _
            " Resolution=@Resolution," & _
            " ClosedBy=@ClosedBy," & _
            " ClosedOn=@ClosedOn," & _
            " Status=@Status," & _
            " ManHours=@ManHours" & _
            " WHERE MUID = @MUID"

        Dim dt_param As DataTable = sqlPrjUtils.paramDT
        dt_param.Rows.Add("@PackageMUID", Me.txtPackageID.Tag)
        dt_param.Rows.Add("@Title", txtTitle.Text)
        dt_param.Rows.Add("@Description", txtDescription.Text)
        dt_param.Rows.Add("@Resolution", txtResolution.Text)
        If txtClosedBy.Text = "" Then
            dt_param.Rows.Add("@ClosedOn", DBNull.Value)
            dt_param.Rows.Add("@ClosedBy", DBNull.Value)
        Else
            dt_param.Rows.Add("@ClosedOn", txtClosedOn.Text)
            dt_param.Rows.Add("@ClosedBy", txtClosedBy.Tag)
        End If

        dt_param.Rows.Add("@Status", txtStatus.Text)
        Dim manHours As String = Me.txtManHours.Text
        If manHours = "" Then
            manHours = "0"
        End If
        dt_param.Rows.Add("@ManHours", manHours)
        dt_param.Rows.Add("@MUID", DiscrepancyID)

        sqlPrjUtils.ExecuteNonQuery(query, dt_param)

        Me.Cursor = Cursors.Default
        Me.Enabled = False
        Me.Dispose()
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub


    Private Sub PendingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendingToolStripMenuItem.Click
        txtClosedBy.Text = ""
        txtClosedOn.Text = ""
        txtStatus.Text = "Pending"
    End Sub


    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        txtClosedBy.Text = ""
        txtClosedOn.Text = ""
        txtStatus.Text = "Open"
    End Sub


    Private Sub ResolvedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResolvedToolStripMenuItem.Click
        Dim userTable As New DataTable
        userTable = daqartDLL.Utilities.GetUserInfo(runtime.UserName)
        txtClosedBy.Text = userTable.Rows(0)(6) & " " & userTable.Rows(0)(7) & " " & userTable.Rows(0)(8)
        txtClosedBy.Tag = userTable.Rows(0)(0)
        txtClosedOn.Text = Now()
        txtStatus.Text = "Resolved"
    End Sub


    Private Sub NoActionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoActionToolStripMenuItem.Click
        Dim userTable As New DataTable
        userTable = daqartDLL.Utilities.GetUserInfo(runtime.UserName)
        txtClosedBy.Text = userTable.Rows(0)(6) & " " & userTable.Rows(0)(7) & " " & userTable.Rows(0)(8)
        txtClosedOn.Text = Now()
        txtClosedBy.Tag = userTable.Rows(0)(0)
        txtStatus.Text = "No Action"
    End Sub


    Private Sub txtListedOn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtListedOn.Click
        'Dim thisDate As String
        'Dim thisPunchlist As New PunchlistManager.PunchlistDataManager
        'thisDate = PunchlistManager.PunchlistDataManager.GetDate()
        'txtListedOn.Text = thisDate
    End Sub


    Private Sub txtManHours_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtManHours.KeyPress
        Dim c As Char = e.KeyChar
        e.Handled = Not (Char.IsDigit(c))
    End Sub


    Private Sub txtClosedBy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClosedBy.Click
        If Me.txtClosedBy.Text = "" Then
            Me.txtClosedBy.Text = Utilities.GetUserName(runtime.UserMUID)
            Me.txtClosedBy.Tag = runtime.UserMUID
            txtClosedOn.Text = Now.ToString
        Else
            If Me.txtClosedBy.Tag <> runtime.UserMUID Then
                MessageBox.Show("You are not authorized to clear the entry")
                Return
            End If
            Me.txtClosedBy.Tag = DBNull.Value
            Me.txtClosedBy.Text = ""
            txtClosedOn.Text = ""
        End If

    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim prtUtil As DiscrepancyPrintUtils = New DiscrepancyPrintUtils
        'prtUtil.PrintDiscrepancyPagePreview(txtDiscrepancy.Text)
        Do
            Thread.Sleep(1)
        Loop Until prtUtil._DonePrinting
    End Sub


    Private Sub btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Print.Click
        Dim qry As String = " SELECT * From Discrepancy WHERE MUID = '" + DiscrepancyID + "'"
        Dim dtt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        Dim pgInfo() As PrintUtils.InfoSetting = DiscrepancyManager.DiscrepancyPrintUtils.MakeShortDiscrepancyPrintPages(dtt)
        Dim ps As CommonForms.XtraGridPrinting = New CommonForms.XtraGridPrinting(pgInfo)
        ps.ShowDialog()
    End Sub


    Private Sub frmEditDiscrepancy_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        sqlPrjUtils.CloseConnection()
        sqlSrvUtils.CloseConnection()

    End Sub


    Private Sub txtPackageID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPackageID.Click
        Dim frm As New CommonForms.PackageList

        frm.ShowDialog()

        Me.txtPackageID.Text = CommonForms.PackageList.SelectedPackage
        Me.txtPackageID.Tag = CommonForms.PackageList.SelectedPackageMUID


    End Sub

End Class