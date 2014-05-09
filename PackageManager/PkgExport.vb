Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.XtraPrinting.PrintableComponentLink
Imports System.Windows.Forms

Public Class PkgExport
    'Private connSQLServer As SqlConnection = daqartDLL.connections.serverRemoteConnect(connSQLServer)
    'Private useProjectDB As String = "USE [" + runtime.selectedProject + "] "
    'Private useServerDB As String = "USE [" + runtime.SiteName + "_ServerDB] "

    'Private Sub GridControl_GroupByAllPackages()
    '    GridControl1.DataSource = Nothing

    '    Dim DisplayTable As DataTable = New DataTable("AuxData")
    '    DisplayTable.Columns.Add(New DataColumn("Num", GetType(Integer)))
    '    DisplayTable.PrimaryKey = New DataColumn() {DisplayTable.Columns("PkgID")}
    '    Dim myHdr() As String = Split("PackageNumber SystemNumber Group Owner Discipline", " ")
    '    For Each s As String In myHdr
    '        Dim ThisColumn As DataColumn = New DataColumn(s, GetType(String))
    '        ThisColumn.ColumnName = s
    '        DisplayTable.Columns.Add(ThisColumn)
    '    Next

    '    Dim qry = useProjectDB + " SELECT PackageNumber, SystemNumber, GroupID, OwnerID, DisciplineID " + _
    '                    " FROM Package "

    '    Dim myAdapter As SqlDataAdapter = New SqlDataAdapter(qry, connSQLServer)
    '    Dim table As New System.Data.DataTable
    '    table.Locale = System.Globalization.CultureInfo.InvariantCulture
    '    myAdapter.Fill(table)
    '    Dim i As Integer = 0
    '    For Each row As DataRow In table.Rows
    '        Dim dRow As DataRow = DisplayTable.NewRow
    '        dRow("PackageNumber") = row(0)
    '        dRow("SystemNumber") = SystemManager.SystemDataManager.TranslateSystemID(row(1))
    '        qry = useServerDB + "SELECT Name From groups WHERE GroupID = " + row(2).ToString
    '        Dim cmd1 As New SqlCommand(qry, connSQLServer)
    '        dRow("Group") = Convert.ToString(cmd1.ExecuteScalar())

    '        qry = useServerDB + "SELECT Name From owner WHERE OwnerID = " + row(3).ToString
    '        Dim cmd2 As New SqlCommand(qry, connSQLServer)
    '        dRow("Owner") = Convert.ToString(cmd2.ExecuteScalar())

    '        qry = useServerDB + "SELECT Name From Discipline WHERE DisciplineID = " + row(4).ToString
    '        Dim cmd3 As New SqlCommand(qry, connSQLServer)
    '        dRow("Discipline") = Convert.ToString(cmd3.ExecuteScalar())
    '        dRow("Num") = i
    '        i = i + 1
    '        DisplayTable.Rows.Add(dRow)
    '    Next
    '    Me.GridControl1.DataSource = DisplayTable

    '    Dim View As ColumnView = GridControl1.MainView
    '    GridControl1.ForceInitialize()
    '    Me.DataNavigator1.DataSource = DisplayTable


    '    ' Creating a new DataNavigator control
    'End Sub

    Private Sub GridControl_GroupByAllPackages()
        GridControl1.DataSource = Nothing

        Dim DisplayTable As DataTable = New DataTable("AuxData")
        DisplayTable.Columns.Add(New DataColumn("Num", GetType(Integer)))
        DisplayTable.PrimaryKey = New DataColumn() {DisplayTable.Columns("PkgID")}
        Dim myHdr() As String = Split("PackageNumber SystemNumber Group Owner Discipline", " ")
        For Each s As String In myHdr
            Dim ThisColumn As DataColumn = New DataColumn(s, GetType(String))
            ThisColumn.ColumnName = s
            DisplayTable.Columns.Add(ThisColumn)
        Next

        Dim qry = " SELECT PackageNumber, SystemNumber, GroupMUID, OwnerMUID, DisciplineMUID " + _
                        " FROM Package "
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)


        Dim i As Integer = 0
        For Each row As DataRow In dt.Rows
            Dim dRow As DataRow = DisplayTable.NewRow
            dRow("PackageNumber") = row("PackageNumber")
            dRow("SystemNumber") = SystemManager.SystemDataManager.TranslateSystemID(row("SystemNumber"))
            qry = "SELECT Name From groups WHERE MUID = " + row("GroupMUID").ToString

            Dim dt1 As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            dRow("Group") = dt1.Rows(0)("Name")

            qry = "SELECT Name From owner WHERE MUID = " + row("OwnerMUID").ToString
            Dim dt2 As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            dRow("Owner") = dt2.Rows(0)("Name")

            qry = "SELECT Name From Discipline WHERE MUID = " + row("DisciplineMUID").ToString
            Dim dt3 As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            dRow("Discipline") = dt2.Rows(0)("Name")
            dRow("Num") = i
            i = i + 1
            DisplayTable.Rows.Add(dRow)
        Next
        sqlPrjUtils.CloseConnection()
        Me.GridControl1.DataSource = DisplayTable

        Dim View As ColumnView = GridControl1.MainView
        GridControl1.ForceInitialize()
        Me.DataNavigator1.DataSource = DisplayTable


        ' Creating a new DataNavigator control
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim View As ColumnView = GridControl1.MainView
        If cboExportType.SelectedIndex >= 0 Then
            Dim SaveFileDialog1 As New SaveFileDialog()

            SaveFileDialog1.InitialDirectory = "c:\"
            'SaveFileDialog1.Filter = "CSV files (*.csv)|*.csv"
            SaveFileDialog1.FilterIndex = 1

            If SaveFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
            Try

                Me.fileName.Visible = True
                Me.fileName.Text = SaveFileDialog1.FileName
                Select Case cboExportType.SelectedIndex
                    Case 0
                        View.ExportToHtml(fileName.Text + ".htm")
                    Case 1
                        View.ExportToMht(fileName.Text + ".mht")
                    Case 2
                        View.ExportToPdf(fileName.Text + ".pdf")
                    Case 3
                        View.ExportToRtf(fileName.Text + ".rtf")
                    Case 4
                        View.ExportToText(fileName.Text + ".txt")
                    Case 5
                        View.ExportToXls(fileName.Text + ".xls")
                End Select
            Catch ex As Exception
                MessageBox.Show("Error exporting packages: " + ex.Message)
                Utilities.logErrorMessage("Daqart.Main_Load-" + ex.Message)
                Me.Close()

            End Try
        End If
        MessageBox.Show("File has been exported")

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PkgExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GridControl_GroupByAllPackages()
            Dim exp() = {"HTML", "Mht", "PDF", "Rtf", "Text", "Xls"}
            cboExportType.DataSource = exp
            Me.BringToFront()
        Catch ex As Exception
            Utilities.logErrorMessage("PkgExport.PkgExport_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cboExportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExportType.SelectedIndexChanged

    End Sub
End Class
