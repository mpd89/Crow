Imports System.Data.SqlClient
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors

Public Class FormSelect
    Public FormID As String
    Public FormName As String
    Public OwnerID As String

    'Private usequery As String
    'Private useProjectDB As String = "USE [" + runtime.selectedProject + "] "


    Private Sub InitializeGridControl1()
        If Not Me.GridControl1.DataSource Is Nothing Then
            Me.GridControl1.DataSource.Dispose()
        End If
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim query = "SELECT Name,MUID,Description FROM forms WHERE MultiElement='0' ORDER BY Name ASC"
        Me.GridControl1.DataSource = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()
        Dim View As ColumnView = GridControl1.MainView
        Dim Column As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("ID")
        Column.Visible = False
        GridControl1.ForceInitialize()
    End Sub


    Private Sub FormSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            InitializeGridControl1()

            'populate owners
            Dim sqlSrcUtils As DataUtils = New DataUtils("server")
            sqlSrcUtils.OpenConnection()

            Dim query As String = "SELECT OwnerMUID, Name FROM owner ORDER BY Name ASC"
            Dim dt As DataTable = sqlSrcUtils.ExecuteQuery(query)
            sqlSrcUtils.CloseConnection()
            For Each dr As DataRow In dt.Rows
                Me.cbx_Owners.Items.Add(dr("Name"))
            Next

            Me.cbx_Owners.SelectedIndex = 0

            Me.ToolStripButton1.Enabled = True

        Catch ex As Exception
            Utilities.logErrorMessage("FormDesigner.FormSelect_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub GridControl1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        'Dim View As ColumnView = GridControl1.MainView
        'Dim ParentView As GridView = View.ParentView

        'If View.GetFocusedRowCellValue("ID") Is Nothing Then
        '    Return
        'End If
        'FormID = View.GetFocusedRowCellValue("ID")
        'FormName = View.GetFocusedRowCellValue("Name")

        ''OwnerID = Utilities.GetOwner(Me.cbx_Owners.Text)

        'Me.Close()
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'OwnerID = Me.cbx_Owners.SelectedItem
        OwnerID = Utilities.GetOwner(Me.cbx_Owners.Text)

        Dim View As ColumnView = GridControl1.MainView
        Dim ParentView As GridView = View.ParentView
        FormID = View.GetFocusedRowCellValue("MUID")

        Me.Close()
    End Sub

End Class