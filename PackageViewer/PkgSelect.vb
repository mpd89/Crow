Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid


Public Class PkgSelect

    Private Sub PackageSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'GridControl_GroupByAllPackages()
            Me.Cursor = Cursors.AppStarting
            Me.GridControl1.DataSource = runtime.PackageTable
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Utilities.logErrorMessage("PkgSelect.PackageSelect_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'no longer used - function Cache_PackageList used instead
    'Private Sub GridControl_GroupByAllPackages()
    '    Me.Cursor = Cursors.AppStarting

    '    GridControl1.DataSource = Nothing

    '    Dim qry = " SELECT MUID, PackageNumber As Package, GroupMUID, Description AS GroupID, Description FROM Package "
    '    'Dim dt As New DataTable

    '    'dt = Utilities.ExecuteQuery(qry, "project")
    '    Dim sqlPrjUtils As DataUtils = New DataUtils("project")

    '    sqlPrjUtils.OpenConnection()
    '    Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '    sqlPrjUtils.CloseConnection()

    '    dt.Columns("MUID").ColumnMapping = MappingType.Hidden
    '    dt.Columns("GroupMUID").ColumnMapping = MappingType.Hidden

    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        dt.Rows(i)(3) = Utilities.TranslateGroupID(dt.Rows(i)(2))
    '    Next

    '    Me.GridControl1.DataSource = dt
    '    Me.Cursor = Cursors.Default
    'End Sub


    Private Sub GridControl1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        Dim View As ColumnView = GridControl1.MainView
        Dim ParentView As GridView = View.ParentView

        Me.Cursor = Cursors.AppStarting

        PackageViewerManager.OpenPackage(View.GetFocusedRowCellValue("MUID"), View.GetFocusedRowCellValue("Package"))

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub btn_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Refresh.Click
        Me.Cursor = Cursors.AppStarting
        Me.GridControl1.DataSource = Nothing
        runtime.PackageTable = Utilities.Cache_PackageList()
        Me.GridControl1.DataSource = runtime.PackageTable
        Me.GridControl1.Refresh()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim frm_Stats As New PackageAuditStats
        frm_Stats.ShowDialog()
    End Sub


    Private Sub btn_Rejected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Rejected.Click
        Me.Cursor = Cursors.AppStarting
        Dim frm As New RejectedForms
        frm.MdiParent = Me.ParentForm
        frm.Show()
        Me.Cursor = Cursors.Default
    End Sub

End Class