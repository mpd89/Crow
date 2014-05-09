Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid
Imports DataStreams.Csv
Imports daqartDLL
Imports Microsoft.VisualBasic


Public Class ImportCSV
    Private sqlPrjUtils As DataUtils

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
    Private dbName As String

    Public Sub New(ByVal _title As String, ByVal _database As String)
        InitializeComponent()
        title = _title
        dbName = _database
    End Sub


    Private Sub SystemImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.Visible = False
        GridControl1.Visible = False
        Me.btn_ImportData.Enabled = False
        Me.Text = title

        sqlPrjUtils = New DataUtils(dbName)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.InitialDirectory = "c:\"
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv"
            openFileDialog1.FilterIndex = 1
            If openFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
            Me.tbx_Filename.Visible = True
            Me.tbx_Filename.Text = openFileDialog1.FileName
            setupRequiredFields()
            ImportHeaders()
            ImportCSVData()
            ShowSystemHeaderMappingGrid()
            GridControl1.Visible = True
            Panel1.Visible = True
            GridControl1.Refresh()
        Catch ex As Exception
            Utilities.logErrorMessage("Daqument WeldImport.Button1-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


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
    End Sub


    Private Sub ShowSystemHeaderMappingGrid()
        Dim clmQry As String = ""
        Dim dt As DataTable = New DataTable
        For Each s As String In sysTableFields
            Dim myCol As DataColumn = New DataColumn(s, GetType(String))
            dt.Columns.Add(myCol)
            clmQry = clmQry + " [" + s + "],"
        Next
        clmQry = clmQry.Remove(clmQry.Length - 1, 1)
        Dim qry = " SELECT " + clmQry + " FROM " + sysTableName
        sqlPrjUtils.OpenConnection()
        sysdt = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        Dim dr As DataRow = dt.NewRow
        dt.Rows.Add(dr)
        VGridControl1.DataSource = dt
        For i As Integer = 0 To VGridControl1.Rows.Count - 1
            Dim riCboEdit As RepositoryItemComboBox = New RepositoryItemComboBox
            riCboEdit.Tag = VGridControl1.Rows(i).Name
            riCboEdit.Items.AddRange(csvHeaders)
            riCboEdit.ReadOnly = False
            riCboEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
            AddHandler riCboEdit.EditValueChanged, AddressOf riCboEdit_EditValueChanged
            VGridControl1.RepositoryItems.Add(riCboEdit)
            VGridControl1.Rows(i).Properties.RowEdit = riCboEdit
        Next
    End Sub


    Private Function ImportHeaders() As Boolean
        Dim CSVreader As CsvReader
        CSVreader = New CsvReader(Me.tbx_Filename.Text)
        CSVreader.ReadHeaders()

        If cbx_Headers.Checked = True Then
            For i As Integer = 0 To CSVreader.HeaderCount - 1
                Dim myCol As DataColumn = New DataColumn
                myCol.Caption = CSVreader.GetHeader(i)
                myCol.DataType = GetType(String)
                csvdt.Columns.Add(myCol)
                ReDim Preserve csvHeaders(i)
                csvHeaders(i) = myCol.Caption
            Next
        Else
            For i As Integer = 0 To CSVreader.HeaderCount - 1
                Dim myCol As DataColumn = New DataColumn
                myCol.Caption = "Column" + i.ToString
                myCol.DataType = GetType(String)
                csvdt.Columns.Add(myCol)
            Next
        End If

        CSVreader.Close()
        Return False
    End Function


    Private Sub ImportCSVData()

        Dim CSVreader As CsvReader
        CSVreader = New CsvReader(Me.tbx_Filename.Text)

        Dim Ctr = 0
        Me.tsb_ProgressBar.Maximum = 1000

        If cbx_Headers.Checked = True Then
            CSVreader.ReadRecord()
        End If
        While (CSVreader.ReadRecord())
            Dim dr As DataRow = csvdt.NewRow
            dr.ItemArray = CSVreader.Values
            Me.tsb_ProgressBar.Increment(1)
            Ctr = Ctr + 1
            If (Ctr Mod 100) = 0 Then
                If (Ctr Mod 1000) = 0 Then
                    Me.tsb_ProgressBar.Value = 0
                End If

                Me.Refresh()
            End If
            csvdt.Rows.Add(dr)
        End While
        Me.tsb_ProgressBar.Value = Me.tsb_ProgressBar.Maximum
        CSVreader.Close()
        GridControl1.DataSource = Me.csvdt

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


    Private Function IsExisting(ByVal iRow As Integer, ByVal iCol As Integer, ByVal ColName As String) As Integer
        Dim ctr = 0
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        Dim TagNoVal As Object = pv.GetRowCellValue(iRow, pv.Columns(iCol))
        If IsDBNull(TagNoVal) Then
            Return 0
        End If
        If TagNoVal Is Nothing Then
            Return 0
        End If
        For i As Integer = 0 To sysdt.Rows.Count - 1
            Dim cmpare As String = sysdt.Rows(i)(ColName)
            cmpare = cmpare.Trim(" ")
            If TagNoVal = cmpare Then
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


    Private Sub btn_CheckData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CheckData.Click
        Dim reqComplete As Boolean = True
        For Each cMap As ColumnMap In Me.requiredColMap
            If cMap.IsRequired Then
                If cMap.ValidateGridColNum < 0 Then
                    reqComplete = False
                End If
            End If
        Next
        If reqComplete Then
            If ValidateData() Then
                MessageBox.Show("Ready to Import Data")
                Me.btn_ImportData.Enabled = True
            Else
                MessageBox.Show("Invalid Data in the CSV file")
            End If
        Else
            MessageBox.Show("Please complete *required fields")
        End If

        GridView1.LayoutChanged()
        GridView1.InvalidateRows()
        GridControl1.Update()
    End Sub


    Private Function ValidateData() As Boolean
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        For iRow As Integer = 0 To pv.RowCount - 1
            For iCol As Integer = 0 To pv.Columns.Count - 1
                For Each cMap As ColumnMap In Me.requiredColMap
                    If cMap.IsRequired Then
                        'check for blank TagNo
                        If Not Me.ckb_IgnoreBlanks.Checked Then
                            If IsBlank(iRow, cMap.ValidateGridColNum) > 0 Then
                                MessageBox.Show("Error: Blank Field")
                                Return False
                            End If
                        End If
                        'check for duplicates
                        If Not Me.ckb_OverrideDuplicates.Checked Then
                            If IsDuplicate(iRow, cMap.ValidateGridColNum) > 0 Then
                                MessageBox.Show("Error: Duplicate Field")
                                Return False
                            End If
                        End If
                        'check for existing TagNo
                        If cMap.RequiredFieldName = uniqueField Then
                            If IsExisting(iRow, cMap.ValidateGridColNum, cMap.RequiredFieldName) > 0 Then
                                If Not Me.ckb_OverrideExisting.Checked Then
                                    MessageBox.Show("Error: Existing Field")
                                    Return False
                                End If
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
                        dt_param.Rows.Add("@" + uniqueField, uniqueFieldVal)
                    Else
                        If cMap.ValidateGridColNum >= 0 Then
                            Dim clm As DevExpress.XtraGrid.Columns.GridColumn = pv.Columns(cMap.ValidateGridColNum)
                            valqry = valqry + "[" + sysCol + "]=@" + sysCol + "',"
                            dt_param.Rows.Add("@" + sysCol, pv.GetRowCellValue(iRow, clm))
                        End If
                    End If
                End If
            Next
        Next
        If valqry > "" And uniqueFieldVal > "" Then
            valqry = valqry.Remove(valqry.Length - 1, 1)
            Dim query = "UPDATE " + sysTableName + " SET " + valqry + " " + _
                " WHERE " + uniqueField + "=@" + uniqueField


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

            Dim query = "INSERT INTO " + sysTableName + _
                    "(MUID," + sysqry + ") VALUES ('" + idUtils.GetNextMUID(dbName, sysTableName) + "'," + valqry + ")"


            sqlPrjUtils.OpenConnection()
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
            sqlPrjUtils.CloseConnection()

        End If
    End Sub


    Private Sub btn_ImportData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ImportData.Click
        Me.Cursor = Cursors.WaitCursor
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView

        For iRow As Integer = 0 To pv.RowCount - 1
            Dim save As Boolean = True
            Dim update As Boolean = False
            For iCol As Integer = 0 To pv.Columns.Count - 1
                For Each cMap As ColumnMap In Me.requiredColMap
                    If cMap.IsRequired Then
                        Dim myCol As Integer = cMap.ValidateGridColNum
                        'check for blank TagNo
                        If Not Me.ckb_IgnoreBlanks.Checked Then
                            If IsBlank(iRow, myCol) > 0 Then
                                save = False
                            End If
                        End If
                        'check for duplicates
                        If Not Me.ckb_OverrideDuplicates.Checked Then
                            If IsDuplicate(iRow, myCol) > 0 Then
                                save = False
                            End If
                        End If
                        'check for existing TagNo
                        If IsExisting(iRow, iCol, cMap.RequiredFieldName) > 0 Then
                            If Me.ckb_OverrideExisting.Checked Then
                                update = True
                            Else
                                save = False
                            End If
                        End If
                    End If
                    If Not save Then Exit For
                Next
                If Not save Then Exit For
            Next
            If save Then
                If update Then
                    UpdateValues(iRow)
                Else
                    InsertValues(iRow)
                End If
            End If
        Next
        MessageBox.Show("Import Done!")
        Me.Cursor = Cursors.Default

        Me.Close()
    End Sub


    Private Function InsertOrUpdateValues() As Boolean
        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim sErr As String = Nothing
        Dim clmQry As String = ""
        For Each s As String In sysTableFields
            clmQry = clmQry + s + ","
            Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow = VGridControl1.Rows(s)
            Dim clmMap As String = VGridControl1.GetCellValue(r, 0)
        Next
        clmQry = clmQry.Remove(clmQry.Length - 1, 1)
        Dim valQry As String = ""
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        For i As Integer = 0 To pv.RowCount - 1
            Dim dr As DevExpress.XtraGrid.Views.Grid.GridRow = pv.GetRow(i)
            For Each s As String In sysTableFields
                Dim r As DevExpress.XtraVerticalGrid.Rows.BaseRow = VGridControl1.Rows(s)
                Dim clmMap As String = VGridControl1.GetCellValue(r, 0)
                Dim myVal As Object = pv.GetRowCellValue(i, pv.Columns(clmMap))
                valQry = valQry + "'" + myVal.ToString + "',"
            Next
        Next
        Return True
    End Function


    Private Sub GridView1_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        Dim match As Boolean = False
        e.Appearance.BackColor = Color.Transparent
        For Each cMap As ColumnMap In Me.requiredColMap
            If cMap.ValidateGridColNum = e.Column.ColumnHandle Then
                If cMap.IsRequired Then
                    If IsBlank(e.RowHandle, e.Column.ColumnHandle) Then
                        e.Appearance.BackColor = Color.Yellow
                    ElseIf IsDuplicate(e.RowHandle, e.Column.ColumnHandle) Then
                        e.Appearance.BackColor = Color.Aqua
                    ElseIf IsExisting(e.RowHandle, e.Column.ColumnHandle, cMap.RequiredFieldName) Then
                        e.Appearance.BackColor = Color.Fuchsia
                    End If
                End If
            End If
        Next
    End Sub


    Private Sub VGridControl1_RecordCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraVerticalGrid.Events.GetCustomRowCellStyleEventArgs) Handles VGridControl1.RecordCellStyle
        For Each cMap As ColumnMap In Me.requiredColMap
            If cMap.VGridRowName = e.Row.Name And cMap.IsRequired Then
                If IsDBNull(VGridControl1.GetCellValue(e.Row, e.RecordIndex)) Then
                    e.Appearance.BackColor = Color.Red
                    Me.lbl_RequiredField.Text = "* Required Field"
                ElseIf VGridControl1.GetCellValue(e.Row, e.RecordIndex) = "" Then
                    e.Appearance.BackColor = Color.Red
                    Me.lbl_RequiredField.Text = "* Required Field"
                Else
                    e.Appearance.BackColor = Color.White
                    Me.lbl_RequiredField.Text = ""
                End If
            End If
        Next
    End Sub


    Private Sub riCboEdit_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim riCboEdit As DevExpress.XtraEditors.ComboBoxEdit = sender
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.DefaultView
        Dim colName = riCboEdit.SelectedText()
        Dim colNum As Integer = -1
        For i As Integer = 0 To pv.Columns.Count - 1
            If pv.Columns(i).Caption = colName Then
                colNum = i
                Exit For
            End If
        Next
        For Each cMap As ColumnMap In Me.requiredColMap
            If cMap.VGridRowName = riCboEdit.Tag.Tag Then
                cMap.ValidateGridColNum = colNum
            End If
        Next
        pv.LayoutChanged()
        pv.InvalidateRows()
        GridControl1.Update()
    End Sub

End Class


