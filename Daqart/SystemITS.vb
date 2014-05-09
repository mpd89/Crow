Imports daqartDLL
Imports SystemManager
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid


Public Class SystemITS
    Dim dt_ITS As New DataTable
    Dim OwnerMUID As String
    Dim SystemMUID As String
    Dim SystemName As String
    Dim FormRow As Integer
    Dim FormColumn As String


    Public Sub New(ByVal _SystemMUID As String, ByVal _dt_ITS As DataTable, ByVal _OwnerMUID As String)
        InitializeComponent()

        SystemMUID = _SystemMUID
        dt_ITS = _dt_ITS
        OwnerMUID = _OwnerMUID
    End Sub


    Private Sub SystemITS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SystemName = SystemDataManager.TranslateSystemID(SystemMUID)
        Me.Text = "System ITS -" + SystemName
        Me.dgv_ITS.DataSource = dt_ITS

        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = Me.dgv_ITS.MainView
        View.Columns(1).Fixed = Columns.FixedStyle.Left
        View.Columns(0).BestFit()
        View.Columns(1).BestFit()

        View.Columns(0).OptionsColumn.ReadOnly = True

        Me.dgv_ITS.Refresh()

        AddHandler GridView1.RowCellStyle, AddressOf GridView1_RowCellStyle
    End Sub


    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim view As GridView = DirectCast(sender, GridView)
        Dim row As DataRow = view.GetDataRow(e.RowHandle)

        Dim tierquery As String = "SELECT * FROM system_mnemonic"
        Dim dt_tiers As DataTable = runtime.SQLProject.ExecuteQuery(tierquery)
        Dim StartingColumn As Integer = dt_tiers.Rows.Count

        If Me.SystemMUID = "Project" Then
            If e.Column.AbsoluteIndex = (2 + StartingColumn) Then
                Try

                    Dim cellval As String = view.GetRowCellDisplayText(e.RowHandle, e.Column)
                    If cellval = "Yes" Then
                        e.Appearance.BackColor = Color.Red
                    End If

                Catch ex As Exception

                End Try
            End If
        Else
            If e.Column.AbsoluteIndex = 3 Then
                Try

                    Dim cellval As String = view.GetRowCellDisplayText(e.RowHandle, e.Column)
                    If cellval = "Yes" Then
                        e.Appearance.BackColor = Color.Red
                    End If

                Catch ex As Exception

                End Try
            End If
        End If


        If Me.SystemMUID = "Project" Then
            If e.Column.AbsoluteIndex < (4 + StartingColumn) Then Return
            Try
                Dim cellval As String = view.GetRowCellDisplayText(e.RowHandle, e.Column)
                If cellval = "Incomplete" Then
                    e.Appearance.BackColor = Color.Red
                ElseIf cellval = "" Then
                    e.Appearance.BackColor = Color.DarkGray
                Else
                    Dim StatusColor As String = Utilities.GetFormStatusColor(Me.OwnerMUID, cellval)
                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(StatusColor)
                End If

            Catch ex As Exception

            End Try
        Else
            If e.Column.AbsoluteIndex < 4 Then Return
            Try
                Dim cellval As String = view.GetRowCellDisplayText(e.RowHandle, e.Column)
                If cellval = "Incomplete" Then
                    e.Appearance.BackColor = Color.Red
                ElseIf cellval = "" Then
                    e.Appearance.BackColor = Color.DarkGray
                Else
                    Dim StatusColor As String = Utilities.GetFormStatusColor(Me.OwnerMUID, cellval)
                    e.Appearance.BackColor = System.Drawing.Color.FromArgb(StatusColor)
                End If

            Catch ex As Exception

            End Try
        End If


    End Sub


    Private Sub btn_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Export.Click
        Dim xgp As CommonForms.XtraGridPrinting = New CommonForms.XtraGridPrinting("System ITS -" + SystemName, Me.dgv_ITS)
        xgp.Show()
    End Sub


    Private Sub dgv_ITS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_ITS.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = dgv_ITS.MainView
        Dim ParentView As DevExpress.XtraGrid.Views.Grid.GridView = View.ParentView

        Dim StartingColumn As Integer = 0
        If Me.SystemMUID = "Project" Then
            Dim tierquery As String = "SELECT * FROM system_mnemonic"
            Dim dt_tiers As DataTable = runtime.SQLProject.ExecuteQuery(tierquery)
            StartingColumn = dt_tiers.Rows.Count
        End If

        If View.FocusedColumn.AbsoluteIndex = 0 + StartingColumn Then
            Dim PackageMUID As String = Utilities.TranslatePackageNumber(View.GetFocusedDataRow.Item("Package#"))
            Dim PackageName As String = View.GetFocusedDataRow.Item("Package#")
            PackageViewer.PackageViewerManager.OpenPackage(PackageMUID, PackageName)

            Me.Cursor = Cursors.Default
        ElseIf View.FocusedColumn.AbsoluteIndex = 1 + StartingColumn Then
            Dim PackageMUID As String = Utilities.GetPackageID(View.GetFocusedDataRow.Item("MUID"))
            Dim PackageName As String = View.GetFocusedDataRow.Item("Package#")
            PackageViewer.PackageViewerManager.OpenPackage(PackageMUID, PackageName)

            Me.Cursor = Cursors.Default
        ElseIf View.FocusedColumn.AbsoluteIndex = 2 + StartingColumn Then
            Dim PackageMUID As String = Utilities.GetPackageID(View.GetFocusedDataRow.Item("MUID"))
            Dim PackageName As String = View.GetFocusedDataRow.Item("Package#")
            PackageViewer.PackageViewerManager.OpenPackage(PackageMUID, PackageName)

            Me.Cursor = Cursors.Default
        Else
            If IsDBNull(View.GetFocusedValue) Then
                Me.Cursor = Cursors.Default
                Return
            End If

            Dim ThisTag As String = View.GetFocusedDataRow.Item("MUID")
            Dim ThisForm As String = View.FocusedColumn.Name
            ThisForm = ThisForm.Replace("col", "")
            Dim ThisType As String = Utilities.GetTagType(ThisTag)
            Dim ThisOwner As String

            Dim query As String = "SELECT OwnerMUID FROM requirements WHERE TypeMUID='" & ThisType & "'" & _
                " AND FormMUID='" + ThisForm + "'"
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

            If Not IsDBNull(dt.Rows(0)(0)) Then
                ThisOwner = dt.Rows(0)(0)
            End If

            Try
                Dim OpenForm As New FormDesigner.FormView(ThisForm, ThisTag, ThisOwner)
                OpenForm.Show()

                'View.SetFocusedRowCellValue(View.FocusedColumn, Utilities.GetStatusDescription(ThisOwner, Utilities.GetFormStatus(ThisTag, ThisForm, ThisOwner)))

                Me.FormRow = View.FocusedRowHandle
                Me.FormColumn = View.FocusedColumn.Name


            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MessageBox.Show(ex.Message)
            End Try

            Me.Cursor = Cursors.Default
        End If

    End Sub


    Private Sub GetFormStatus()
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = dgv_ITS.MainView
        Dim ParentView As DevExpress.XtraGrid.Views.Grid.GridView = View.ParentView

        Dim StartingColumn As Integer = 0
        If View.FocusedColumn.AbsoluteIndex = 3 + StartingColumn Then
            If IsDBNull(View.GetFocusedValue) Then
                Me.Cursor = Cursors.Default
                Return
            End If

            Dim ThisTag As String = View.GetFocusedDataRow.Item("MUID")
            Dim ThisForm As String = View.FocusedColumn.Name
            ThisForm = ThisForm.Replace("col", "")
            Dim ThisType As String = Utilities.GetTagType(ThisTag)
            Dim ThisOwner As String

            Dim query As String = "SELECT OwnerMUID FROM requirements WHERE TypeMUID='" & ThisType & "'" & _
                " AND FormMUID='" + ThisForm + "'"
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

            If Not IsDBNull(dt.Rows(0)(0)) Then
                ThisOwner = dt.Rows(0)(0)
            End If

            View.SetFocusedRowCellValue(View.FocusedColumn, Utilities.GetStatusDescription(ThisOwner, Utilities.GetFormStatus(ThisTag, ThisForm, ThisOwner)))

        End If
    End Sub


    Private Sub GridView1_FocusedColumnChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        'GetFormStatus()
    End Sub


    Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        'GetFormStatus()
    End Sub

End Class