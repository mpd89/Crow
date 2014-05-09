Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
'Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid



Public Class PkgSelect

    'Private connProject As SqlCeConnection = daqartDLL.connections.projectDBConnect(connProject)
    'Private connServer As SqlCeConnection = daqartDLL.connections.serverDBConnect(connServer)
    Private Sub repositoryItemButtonEdit1_ButtonClick(ByVal sender As Object, _
 ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim Editor As DevExpress.XtraEditors.ButtonEdit = CType(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim Button As DevExpress.XtraEditors.Controls.EditorButton = e.Button
        Dim Info As String = ""
        Dim EOL As String = vbCrLf
        Info += " Kind: " + Button.Kind.ToString() + EOL
        Info += " Caption: " + Button.Caption + EOL
        Info += " Image assigned: " + (Not Button.Image Is Nothing).ToString() + EOL
        Info += " Shortcut: " + Button.Shortcut.ToString() + EOL
        Info += " IsLeft: " + Button.IsLeft.ToString() + EOL
        Info += " Width: " + Button.Width.ToString() + EOL
        Info += " Index: " + Editor.Properties.Buttons.IndexOf(e.Button).ToString()
        Dim View As ColumnView = GridControl1.MainView
        Dim ParentView As GridView = View.ParentView


        PackageViewer.PackageViewerManager.OpenPackage(View.GetFocusedRowCellValue("PackageID"), View.GetFocusedRowCellValue("PackageNumber"))

    End Sub

    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Private Sub AddViewButton()
        'Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        ''Me.RepositoryItemButtonEdit1.AutoHeight = False
        'Me.RepositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1"
        'Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() _
        '  {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
        ' "View", -1, True, True, True, DevExpress.Utils.ViewStyle.DefaultStyleOptions.UseHorzAlignment, Nothing)})
        'Me.RepositoryItemButtonEdit1.Buttons(1).Width = 30
        'Dim unbColumn As DevExpress.XtraGrid.Columns.GridColumn = GridView1.Columns.AddField("Button")
        'unbColumn.VisibleIndex = GridView1.Columns.Count
        'unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object
        'unbColumn.ShowButtonMode = ShowButtonModeEnum.ShowAlways
        'unbColumn.ColumnEdit = RepositoryItemButtonEdit1
        'AddHandler Me.RepositoryItemButtonEdit1.ButtonPressed, AddressOf Me.repositoryItemButtonEdit1_ButtonClick
        'unbColumn.Caption = "View details"

    End Sub

    Private Sub GridControl_GroupByAllPackages()
        GridControl1.DataSource = Nothing

        Dim DisplayTable As DataTable = New DataTable("AuxData")
        DisplayTable.Columns.Add(New DataColumn("Num", GetType(Integer)))
        DisplayTable.PrimaryKey = New DataColumn() {DisplayTable.Columns("PkgID")}
        Dim myHdr() As String = Split("PackageNumber SystemNumber Group Owner Discipline PackageMUID", " ")
        For Each s As String In myHdr
            Dim ThisColumn As DataColumn = New DataColumn(s, GetType(String))
            ThisColumn.ColumnName = s
            DisplayTable.Columns.Add(ThisColumn)
        Next

        Dim qry = " SELECT PackageNumber As Package, SystemNumber, GroupID, OwnerID, DisciplineID, PackageID " + _
                        " FROM Package "
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        sqlPrjUtils.OpenConnection()
        sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)

        Dim i As Integer = 0
        For Each row As DataRow In dt.Rows
            Dim dRow As DataRow = DisplayTable.NewRow
            dRow("PackageNumber") = row(0)
            dRow("SystemNumber") = SystemManager.SystemDataManager.TranslateSystemID(row(1))
            qry = "SELECT Name From groups WHERE MUID = " + row(2).ToString
            Dim dt1 As DataTable = sqlSrvUtils.ExecuteQuery(qry)
            If dt1.Rows.Count > 0 Then
                dRow("Group") = dt1.Rows(0)("Name")
            Else
                dRow("Group") = ""
            End If

            qry = "SELECT Name From owner WHERE MUID = " + row(3).ToString
            Dim dt2 As DataTable = sqlSrvUtils.ExecuteQuery(qry)
            If dt2.Rows.Count > 0 Then
                dRow("Owner") = dt2.Rows(0)("Name")
            Else
                dRow("Owner") = ""
            End If

            qry = "SELECT Name From Discipline WHERE DisciplineID = " + row(4).ToString
            Dim dt3 As DataTable = sqlSrvUtils.ExecuteQuery(qry)
            If dt3.Rows.Count > 0 Then
                dRow("Discipline") = dt3.Rows(0)("Name")
            Else
                dRow("Discipline") = ""
            End If
            dRow("PackageID") = row("PackageMUID")
            dRow("Num") = i
            i = i + 1
            DisplayTable.Rows.Add(dRow)
        Next
        Me.GridControl1.DataSource = DisplayTable
        AddViewButton()
        Dim View As ColumnView = GridControl1.MainView
        GridControl1.ForceInitialize()
        Me.DataNavigator1.DataSource = DisplayTable
        View.Columns("MUID").Visible = False
        sqlPrjUtils.CloseConnection()
        sqlSrvUtils.CloseConnection()


        ' Creating a new DataNavigator control
    End Sub


    Private Sub PackageSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            GridControl_GroupByAllPackages()
        Catch ex As Exception
            Utilities.logErrorMessage("PkgSelect.PackageSelect_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub GridControl1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        Dim View As ColumnView = GridControl1.MainView
        Dim ParentView As GridView = View.ParentView

        PackageViewer.PackageViewerManager.OpenPackage(View.GetFocusedRowCellValue("PackageID"), View.GetFocusedRowCellValue("PackageNumber"))


    End Sub
End Class