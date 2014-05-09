Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid
Imports DataStreams.Csv
Imports daqartDLL
Imports Microsoft.VisualBasic
Imports system.collections.generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Layout
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports System.Drawing.Printing
Imports System.Data.SqlServerCe

Public Class EditLookupTable
 

    Public Shared Function myDataTable(ByVal tblFields() As String, ByVal tblName As String) As DataTable
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim clmQry As String = ""
        For Each s As String In tblFields
            Dim myCol As DataColumn = New DataColumn(s, GetType(String))
            clmQry = clmQry + s + ","
        Next
        clmQry = clmQry.Remove(clmQry.Length - 1, 1)
        Dim qry = " SELECT " + clmQry + " FROM " + tblName

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        Return dt
    End Function


    Public Shared Function myGridLookupEdit(ByVal tblFields() As String, _
                ByVal tblName As String, ByVal linkField As String, ByVal DisplayField As String) _
                As RepositoryItemGridLookUpEdit
        ' A lookup editor created at runtime.
        Dim gridLookup As RepositoryItemGridLookUpEdit = New RepositoryItemGridLookUpEdit()
        gridLookup.DataSource = myDataTable(tblFields, tblName)
        gridLookup.ValueMember = linkField
        gridLookup.DisplayMember = DisplayField
        gridLookup.ShowDropDown = ShowDropDown.SingleClick
        gridLookup.View.BestFitColumns()
        Return gridLookup
    End Function


    Public Class ColumnMap
        Private _requiredFieldName As String
        Private _GridCol As Integer
        Private _VGridRowName As String
        Private _required As Boolean

        Public Sub New(ByVal requiredFieldName As String, ByVal req As Boolean)
            _requiredFieldName = requiredFieldName
            _GridCol = -1
            Dim myRowName = requiredFieldName.Replace(" ", "_")
            _VGridRowName = "row" + myRowName
            _required = req
        End Sub

        Public ReadOnly Property VGridRowName()
            Get
                Return _VGridRowName
            End Get
        End Property

        Public ReadOnly Property IsRequired()
            Get
                Return _required
            End Get
        End Property

        Public ReadOnly Property RequiredFieldName()
            Get
                Return _requiredFieldName
            End Get
        End Property

        Public Property ValidateGridColNum()
            Get
                Return _GridCol
            End Get
            Set(ByVal value)
                _GridCol = value
            End Set
        End Property
    End Class

    Private csvdt As New DataTable
    Private sysdt As New DataTable
    Private csvHeaders() As String
    Public sysTableFields() As String
    Public sysTableName = ""
    Public requiredFields() As String
    Public uniqueField As String
    Private title As String = ""
    Private requiredColMap As New List(Of ColumnMap)
    Private sqlPrjUtils As DataUtils = New DataUtils("project")


    Public Sub New(ByVal _title As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        title = _title
    End Sub


    Private Sub EditLookupTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = title
        Me.lblMsg.Text = title
        Dim clmQry As String = ""
        For Each s As String In sysTableFields
            clmQry = clmQry + " [" + s + "],"
        Next
        clmQry = clmQry.Remove(clmQry.Length - 1, 1)
        Dim qry = " SELECT " + clmQry + " FROM " + sysTableName
        'sysdt = Utilities.ExecuteQuery(qry, "project")
        sqlPrjUtils.OpenConnection()
        sysdt = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        GridControl1.DataSource = sysdt
        setupRequiredFields()
        SetSelectedFixedColumns()
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Public Sub SetSelectedFixedColumns()
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = GridControl1.MainView
        For i As Integer = 0 To View.Columns.Count - 1
            Dim fix As Boolean = False
            'For Each s As String In fixedColumns
            '    If s = View.Columns(i).Caption Then
            '        fix = True
            '        Exit For
            '    End If
            'Next
            If fix Then
                View.Columns(i).OptionsColumn.FixedWidth = True
                View.Columns(i).Fixed = Columns.FixedStyle.Left

            Else
                View.Columns(i).OptionsColumn.FixedWidth = True
                View.Columns(i).Fixed = Columns.FixedStyle.None
                View.Columns(i).BestFit()
            End If
        Next
    End Sub


    Private Function IsDuplicate(ByVal iRow As Integer, ByVal iCol As Integer) As Integer
        Dim ctr = 0
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        Dim TagNoVal As Object = pv.GetRowCellValue(iRow, pv.Columns(iCol))
        For i As Integer = iRow + 1 To pv.RowCount - 1
            If TagNoVal = pv.GetRowCellValue(i, pv.Columns(iCol)) Then
                ctr = ctr + 1
                If ctr > 0 Then Return i
            End If
        Next
        Return 0
    End Function


    Private Function IsBlank(ByVal iRow As Integer, ByVal iCol As Integer) As Integer
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        Dim TagNoVal As Object = pv.GetRowCellValue(iRow, pv.Columns(iCol))
        If IsDBNull(TagNoVal) Then
            Return iRow
        End If
        If TagNoVal = "" Then
            Return iRow
        End If
        Return 0
    End Function


    Private Sub setupRequiredFields()
        For Each s As String In sysTableFields
            Dim match = False
            For Each sysField As String In requiredFields
                If s = sysField Then
                    match = True
                    Exit For
                End If
            Next
            If match Then
                requiredColMap.Add(New ColumnMap(s, True))
            Else
                requiredColMap.Add(New ColumnMap(s, False))
            End If
        Next
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        For iCol As Integer = 0 To pv.Columns.Count - 1
            For Each cMap As ColumnMap In Me.requiredColMap
                If pv.Columns(iCol).Caption = cMap.RequiredFieldName Then
                    cMap.ValidateGridColNum = iCol
                End If
            Next
        Next
    End Sub


    Private Function ValidateData() As Boolean
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        For iRow As Integer = 0 To pv.RowCount - 1
            For iCol As Integer = 0 To pv.Columns.Count - 1
                For Each cMap As ColumnMap In Me.requiredColMap
                    If cMap.IsRequired Then
                        'check for blank TagNo
                        'check for existing TagNo
                        If cMap.RequiredFieldName = uniqueField Then
                            If IsBlank(iRow, cMap.ValidateGridColNum) > 0 Then
                                MessageBox.Show("Error: Blank Field")
                                Return False

                            End If
                            'check for duplicates
                            If IsDuplicate(iRow, cMap.ValidateGridColNum) > 0 Then
                                MessageBox.Show("Error: Duplicate Field")
                                Return False

                            End If
                        End If
                    End If
                Next
            Next
        Next
        Return True
    End Function


    Private Sub UpdateValues(ByVal iRow As Integer)
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        Dim valqry As String = ""
        Dim uniqueFieldVal As String = ""
        Dim dt_param As DataTable = sqlPrjUtils.paramDT

        For Each sysCol As String In sysTableFields
            For Each cMap As ColumnMap In Me.requiredColMap
                If cMap.RequiredFieldName = sysCol Then
                    If cMap.RequiredFieldName = uniqueField Then
                        Dim clm As DevExpress.XtraGrid.Columns.GridColumn = pv.Columns(cMap.ValidateGridColNum)
                        uniqueFieldVal = pv.GetRowCellValue(iRow, clm)
                    Else
                        If cMap.ValidateGridColNum >= 0 Then
                            Dim clm As DevExpress.XtraGrid.Columns.GridColumn = pv.Columns(cMap.ValidateGridColNum)
                            valqry = valqry + "[" + sysCol + "]= @" + sysCol + ","
                            dt_param.Rows.Add("@" + sysCol, pv.GetRowCellValue(iRow, clm))
                        End If
                    End If
                End If
            Next
        Next
        If valqry > "" And uniqueFieldVal > "" Then
            valqry = valqry.Remove(valqry.Length - 1, 1)
            Dim query = " USE [" + runtime.selectedProject + "] UPDATE " + sysTableName + " SET " + valqry + " " + _
                " WHERE " + uniqueField + "='" + uniqueFieldVal + "'"


            sqlPrjUtils.OpenConnection()
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
            sqlPrjUtils.CloseConnection()


        End If
    End Sub


    Private Sub InsertValues(ByVal iRow As Integer)
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        Dim valqry As String = ""
        Dim sysqry As String = ""
        Dim dt_param As DataTable = sqlPrjUtils.paramDT

        For Each sysCol As String In sysTableFields
            For Each cMap As ColumnMap In Me.requiredColMap
                If cMap.RequiredFieldName = sysCol Then
                    If cMap.ValidateGridColNum >= 0 Then
                        Dim clm As DevExpress.XtraGrid.Columns.GridColumn = pv.Columns(cMap.ValidateGridColNum)
                        valqry = valqry + "@" + sysCol + ","
                        sysqry = sysqry + "[" + sysCol + "],"
                        dt_param.Rows.Add("@" + sysCol, pv.GetRowCellValue(iRow, clm))
                    End If
                End If
            Next
        Next
        If valqry > "" Then
            valqry = valqry.Remove(valqry.Length - 1, 1)
            sysqry = sysqry.Remove(sysqry.Length - 1, 1)

            Dim query = " USE [" + runtime.selectedProject + "] INSERT INTO " + sysTableName + _
                    "(" + sysqry + ") VALUES (" + valqry + ")"

            sqlPrjUtils.OpenConnection()
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
            sqlPrjUtils.CloseConnection()
        End If
    End Sub


    Private Sub btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIPdate.Click
        'Dim dr As DevExpress.XtraVerticalGrid.Rows.BaseRow = VGridControl1.GetRowByFieldName("rowTagNo")
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        For iRow As Integer = 0 To pv.RowCount - 1
            Dim dr As System.Data.DataRowView = pv.GetRow(iRow)
            Dim save As Boolean = True
            Dim update As Boolean = False
            For iCol As Integer = 0 To pv.Columns.Count - 1
                For Each cMap As ColumnMap In Me.requiredColMap
                    If cMap.IsRequired Then
                        If cMap.RequiredFieldName = uniqueField Then
                            Dim myCol As Integer = cMap.ValidateGridColNum
                            'check for blank TagNo
                            If IsBlank(iRow, myCol) > 0 Then
                                save = False
                            End If
                            'check for duplicates
                            If IsDuplicate(iRow, myCol) > 0 Then
                                save = False
                            End If
                        End If
                    End If
                    If Not save Then Exit For
                Next
                If Not save Then Exit For
            Next
            If save Then
                If dr.Row.RowState = DataRowState.Modified Then
                    UpdateValues(iRow)
                End If
                If dr.Row.RowState = DataRowState.Added Then
                    InsertValues(iRow)
                End If
            End If
        Next
        MessageBox.Show("Import Done!")
        Me.Close()
    End Sub


    Private Sub GridView1_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If e.RowHandle < 0 Then Return
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        Dim match As Boolean = False
        e.Appearance.BackColor = Color.Transparent
        For Each cMap As ColumnMap In Me.requiredColMap
            If cMap.ValidateGridColNum = e.Column.ColumnHandle Then
                If cMap.IsRequired Then
                    If cMap.RequiredFieldName = uniqueField Then
                        If IsBlank(e.RowHandle, e.Column.ColumnHandle) Then
                            e.Appearance.BackColor = Color.Yellow
                        ElseIf IsDuplicate(e.RowHandle, e.Column.ColumnHandle) Then
                            e.Appearance.BackColor = Color.Aqua
                        End If
                    End If
                End If
            End If
        Next
    End Sub

End Class