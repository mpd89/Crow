Imports System.Data.SqlClient
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports daqartDLL
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Drawing.Graphics
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports SystemManager

Public Class SystemAuditor
    Dim dt_AuditResults As New DataTable


    Public Sub New()
        InitializeComponent()
    End Sub


    Private Sub SystemAuditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadTests()
        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.SystemAuditor_Load-" + ex.Message)

            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim View As ColumnView = GridControl1.MainView
        Dim ParentView As GridView = View.ParentView
        Select Case View.GetFocusedRowCellValue("Name")
            Case "Tag"
            Case "Package"
        End Select
    End Sub


    Private Sub repositoryItemButtonEdit1_ButtonClick(ByVal sender As Object, _
     ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim Editor As DevExpress.XtraEditors.ButtonEdit = CType(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim Button As DevExpress.XtraEditors.Controls.EditorButton = e.Button
        Dim Info As String = Nothing
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

        Select Case View.GetFocusedRowCellValue("Catagory")
            Case "Package"
                Dim myForm As New package.PkgSelect
                myForm.Show()
            Case "Tag"
                Dim myForm As New package.TagSelect
                myForm.Show()
        End Select
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


    Private Sub ViewSystemAudit()

        GridControl1.DataSource = SystemToolsManager.GetUnassigned()
        GridControl1.BringToFront()
        AddViewButton()

#If 0 Then
        unbColumn.Name = "gridColumn1"
        unbColumn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
        unbColumn.VisibleIndex = 4

        '...

        Dim View As ColumnView = GridControl1.MainView

        Dim btnView As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = CType(GridControl1.RepositoryItems.Add("ButtonEdit"), _
           DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit)
        btnView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        btnView.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Dim btn As DevExpress.XtraEditors.ButtonEdit = New DevExpress.XtraEditors.ButtonEdit()



        View.Columns(2).ColumnEdit = btnView
        '        View.Columns(2).Properties.Value = New Button




        ' creating a new vertical grid control
        Dim VGrid As New VGridControl()
        VGrid.Parent = Me
        VGrid.Width = 300
        VGrid.RowHeaderWidth = 170

        ' creating two editor rows with the specified captions
        Dim Row1 As New EditorRow()
        Row1.Properties.Caption = "Treat Warnings as Errors"
        Dim Row2 As New EditorRow()
        Row2.Properties.Caption = "Warning Level"

        ' creating a new category row and adding it to the grid
        Dim Category As New CategoryRow("Errors and Warnings")
        VGrid.Rows.Add(Category)

        ' adding the editor rows as childs to the category
        Dim Rows() As EditorRow = {Row1, Row2}
        Category.ChildRows.AddRange(Rows)

        ' creating a check editor for the first editor row
        Dim RICheck As RepositoryItemImageEdit = CType(VGrid.RepositoryItems.Add("ImageEdit"), _
          RepositoryItemImageEdit)
        Row1.Properties.RowEdit = RICheck
        ' specifying the row value to be displayed by the associated check editor
        Row1.Properties.Value = myForm.FormEsign

        ' creating a combobox editor for the second editor row
        '        Dim RICombo As RepositoryItemComboBox = CType(VGrid.RepositoryItems.Add("ComboBox"), _
        '         RepositoryItemComboBox)
        ' populating the combo box with data
        Dim I As Integer
        For I = 0 To 4
            '          RICombo.Properties.Items.Add("Warning Level " + I.ToString())
        Next
        '     Row2.Properties.RowEdit = RICombo
        ' specifying the second row's value
        '    Row2.Properties.Value = RICombo.Properties.Items(3)

        VGrid.BringToFront()

        '        VGridControl1.ShowEditor()
        '      GridControl1.DataSource = myForm.GetFormProperies()
        '    GridControl1.RepositoryItems.Add(RIMemoEdit)
        '   Dim View As ColumnView = GridControl1.MainView

        '  View.Columns("Comment").ColumnEdit = RIMemoEdit
        ' Dim View As Views.Base. = VGridControl1.MainView
#End If

    End Sub
    Private Sub ButtonEdit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show("ButtonClick event")
    End Sub


    Private Sub LoadTests()
        dgv_AuditPanel.Rows.Add("1", "Package", "Undefined System Number", "", "View")
        dgv_AuditPanel.Rows.Add("2", "Package", "Undefined Owner", "", "View")
        dgv_AuditPanel.Rows.Add("3", "Package", "Undefined Discipline", "", "View")
        dgv_AuditPanel.Rows.Add("4", "Package", "Undefined Group", "", "View")
        dgv_AuditPanel.Rows.Add("5", "Tag", "Undefined Package Number", "", "View")
        dgv_AuditPanel.Rows.Add("6", "Tag", "Undefined Type", "", "View")
        dgv_AuditPanel.Rows.Add("7", "Equipment Type", "Equipment Type Used with no Requirement", "", "View")

        PerformTests()
    End Sub


    Private Sub PerformTests()
        Test_1a()
        Test_2a()
        Test_3a()
        Test_4a()
        Test_5a()
        Test_6a()
        Test_7a()
    End Sub


    Private Sub Test_1a()
        Dim query As String = "SELECT * FROM package"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        dt_AuditResults.Clear()
        dt_AuditResults.Columns.Clear()
        dt_AuditResults.Columns.Add("Num")
        dt_AuditResults.Columns.Add("Package Number")
        dt_AuditResults.Columns.Add("Description")

        Dim TestCount As Integer = 0

        If Not dt.Rows.Count = 0 Then
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                If Not SystemDataManager.SystemValidate(dt.Rows(i)(3)) Then
                    TestCount = TestCount + 1

                    dt_AuditResults.Rows.Add(i + 1, dt.Rows(i)(2), dt.Rows(i)(4))
                End If
            Next
        End If

        dgv_AuditPanel.Rows(0).Cells(3).Value = TestCount.ToString
    End Sub


    Private Sub Test_2a()
        Dim query As String = "SELECT * FROM package WHERE OwnerMUID = '1'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        dt_AuditResults.Clear()
        dt_AuditResults.Columns.Clear()
        dt_AuditResults.Columns.Add("Num")
        dt_AuditResults.Columns.Add("Package Number")
        dt_AuditResults.Columns.Add("Description")

        Dim TestCount As Integer = dt.Rows.Count

        If Not dt.Rows.Count = 0 Then
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                dt_AuditResults.Rows.Add(i + 1, dt.Rows(i)(2), dt.Rows(i)(4))
            Next
        End If

        dgv_AuditPanel.Rows(1).Cells(3).Value = TestCount.ToString
    End Sub


    Private Sub Test_3a()
        Dim query As String = "SELECT * FROM package WHERE DisciplineMUID = '1'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()


        dt_AuditResults.Clear()
        dt_AuditResults.Columns.Clear()
        dt_AuditResults.Columns.Add("Num")
        dt_AuditResults.Columns.Add("Package Number")
        dt_AuditResults.Columns.Add("Description")

        Dim TestCount As Integer = dt.Rows.Count
        If Not dt.Rows.Count = 0 Then
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                dt_AuditResults.Rows.Add(i + 1, dt.Rows(i)(2), dt.Rows(i)(4))
            Next
        End If

        dgv_AuditPanel.Rows(2).Cells(3).Value = TestCount.ToString
    End Sub


    Private Sub Test_4a()
        Dim query As String = "SELECT * FROM package WHERE GroupMUID = '1'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        dt_AuditResults.Clear()
        dt_AuditResults.Columns.Clear()
        dt_AuditResults.Columns.Add("Num")
        dt_AuditResults.Columns.Add("Package Number")
        dt_AuditResults.Columns.Add("Description")

        Dim TestCount As Integer = dt.Rows.Count
        If Not dt.Rows.Count = 0 Then
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                dt_AuditResults.Rows.Add(i + 1, dt.Rows(i)(2), dt.Rows(i)(4), "")
            Next
        End If

        dgv_AuditPanel.Rows(3).Cells(3).Value = TestCount.ToString
    End Sub


    Private Sub Test_5a()
        Dim query As String = "SELECT * FROM tags"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Dim TestCount As Integer = 0
        dt_AuditResults.Clear()
        dt_AuditResults.Columns.Clear()
        dt_AuditResults.Columns.Add("Num")
        dt_AuditResults.Columns.Add("Tag Number")
        dt_AuditResults.Columns.Add("Description")

        If Not dt.Rows.Count = 0 Then
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                If Not PackageValidate(dt.Rows(i)(3)) Then
                    TestCount = TestCount + 1
                    dt_AuditResults.Rows.Add(i + 1, dt.Rows(i)(2), "")
                End If
            Next
        End If

        dgv_AuditPanel.Rows(4).Cells(3).Value = TestCount.ToString
    End Sub


    Private Sub Test_6a()
        Dim query As String = "SELECT * FROM tags WHERE TypeMUID = '1'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Dim TestCount As Integer = dt.Rows.Count
        dt_AuditResults.Clear()
        dt_AuditResults.Columns.Clear()
        dt_AuditResults.Columns.Add("Num")
        dt_AuditResults.Columns.Add("Tag Number")
        dt_AuditResults.Columns.Add("Description")

        If Not dt.Rows.Count = 0 Then
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                dt_AuditResults.Rows.Add(i + 1, dt.Rows(i)(2), "")
            Next
        End If
        dgv_AuditPanel.Rows(5).Cells(3).Value = TestCount.ToString
    End Sub


    Private Sub Test_7a()
        Dim query As String = "SELECT DISTINCT TypeMUID FROM tags"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Dim TestCount As Integer = 0
        dt_AuditResults.Clear()
        dt_AuditResults.Columns.Clear()
        dt_AuditResults.Columns.Add("Num")
        dt_AuditResults.Columns.Add("Tag Number")
        dt_AuditResults.Columns.Add("Description")

        If Not dt.Rows.Count = 0 Then
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                If Not TypeValidate(dt.Rows(i)(0)) Then
                    TestCount = TestCount + 1

                    dt_AuditResults.Rows.Add(i + 1, dt.Rows(i)(0), "")
                End If
            Next
        End If
        dgv_AuditPanel.Rows(6).Cells(3).Value = TestCount.ToString
    End Sub


    Private Function PackageValidate(ByVal _MUID As String)
        Dim query As String = "SELECT * FROM package WHERE MUID='" & _MUID & "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Function TypeValidate(ByVal _TypeMUID As Integer)
        Dim query As String = "SELECT * FROM requirements WHERE TypeMUID = '" & _TypeMUID & "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
    End Sub


    Private Sub dgv_AuditPanel_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_AuditPanel.CellClick
        If Not e.ColumnIndex = 4 Then
            Return
        End If

        'launch audit list
        Dim ThisTestID As String = dgv_AuditPanel.Rows(e.RowIndex).Cells(0).Value

        If ThisTestID = 1 Then
            Test_1a()

            Dim frm_Results As New SystemAuditResults(dt_AuditResults)
            frm_Results.Show()
        End If

        If ThisTestID = 2 Then
            Test_2a()

            Dim frm_Results As New SystemAuditResults(dt_AuditResults)
            frm_Results.Show()
        End If

        If ThisTestID = 3 Then
            Test_3a()

            Dim frm_Results As New SystemAuditResults(dt_AuditResults)
            frm_Results.Show()
        End If

        If ThisTestID = 4 Then
            Test_4a()

            Dim frm_Results As New SystemAuditResults(dt_AuditResults)
            frm_Results.Show()
        End If

        If ThisTestID = 5 Then
            Test_5a()

            Dim frm_Results As New SystemAuditResults(dt_AuditResults)
            frm_Results.Show()
        End If

        If ThisTestID = 6 Then
            Test_6a()

            Dim frm_Results As New SystemAuditResults(dt_AuditResults)
            frm_Results.Show()
        End If

        If ThisTestID = 7 Then
            Test_7a()

            Dim frm_Results As New SystemAuditResults(dt_AuditResults)
            frm_Results.Show()
        End If

    End Sub


    Private Sub tsb_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Refresh.Click
        PerformTests()
    End Sub

End Class