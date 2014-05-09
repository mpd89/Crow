Imports DataStreams.Csv

Public Class ImportReadIndex
    Public FileName As String
    Public dt As New DataTable
    Dim Loading As Boolean = True


    Public Sub New(ByVal _Filename As String)
        InitializeComponent()

        FileName = _Filename

    End Sub


    Private Sub ImportReadIndex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loading = False

        PopulateDatatable()

        PopulateColumnHeaderSelection()

    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        dt = Nothing

        Me.Dispose()
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        'read file / create datatable



        Me.Close()
    End Sub


    Private Sub PopulateDatatable()
        If Loading Then Return

        Try

            Dim CSVreader As CsvReader
            CSVreader = New CsvReader(FileName)
            CSVreader.ReadHeaders()

            Dim StartLoop As Boolean = True

            dt.Rows.Clear()
            dt.Columns.Clear()
            While (CSVreader.ReadRecord())
                If StartLoop Then

                    If Me.cbx_RowHeaders.Checked Then
                        For i As Integer = 0 To CSVreader.ColumnCount - 1
                            Dim dc As DataColumn = New DataColumn
                            dc.ColumnName = CSVreader.GetHeader(i)
                            dc.DataType = System.Type.GetType("System.String")
                            dt.Columns.Add(dc)
                        Next
                    Else
                        For i As Integer = 1 To CSVreader.ColumnCount
                            dt.Columns.Add("Column" & i)
                        Next
                    End If
                End If
                StartLoop = False

                dt.Rows.Add(CSVreader.Values)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub PopulateColumnHeaderSelection()
        If Loading Then Return

        Try

            Dim dt_FileName As New DataTable
            Dim dt_EngCode As New DataTable
            Dim dt_ClientCode As New DataTable
            Dim dt_Revision As New DataTable
            Dim dt_Description As New DataTable
            Dim dt_Sheet As New DataTable
            Dim dt_Sheets As New DataTable
            Dim dt_Location As New DataTable

            dt_FileName.Columns.Add("ColumnNumber")
            dt_FileName.Columns.Add("ColumnName")
            dt_EngCode.Columns.Add("ColumnNumber")
            dt_EngCode.Columns.Add("ColumnName")
            dt_ClientCode.Columns.Add("ColumnNumber")
            dt_ClientCode.Columns.Add("ColumnName")
            dt_Revision.Columns.Add("ColumnNumber")
            dt_Revision.Columns.Add("ColumnName")
            dt_Description.Columns.Add("ColumnNumber")
            dt_Description.Columns.Add("ColumnName")
            dt_Sheet.Columns.Add("ColumnNumber")
            dt_Sheet.Columns.Add("ColumnName")
            dt_Sheets.Columns.Add("ColumnNumber")
            dt_Sheets.Columns.Add("ColumnName")
            dt_Location.Columns.Add("ColumnNumber")
            dt_Location.Columns.Add("ColumnName")

            For i As Integer = 0 To dt.Columns.Count - 1
                dt_FileName.Rows.Add(i, dt.Columns(i).ColumnName)
                dt_EngCode.Rows.Add(i, dt.Columns(i).ColumnName)
                dt_ClientCode.Rows.Add(i, dt.Columns(i).ColumnName)
                dt_Revision.Rows.Add(i, dt.Columns(i).ColumnName)
                dt_Description.Rows.Add(i, dt.Columns(i).ColumnName)
                dt_Sheet.Rows.Add(i, dt.Columns(i).ColumnName)
                dt_Sheets.Rows.Add(i, dt.Columns(i).ColumnName)
                dt_Location.Rows.Add(i, dt.Columns(i).ColumnName)
            Next

            Me.cbx_FileName.DataSource = Nothing
            Me.cbx_FileName.DataSource = dt_FileName
            cbx_FileName.ValueMember = dt_FileName.Columns("ColumnNumber").ToString
            cbx_FileName.DisplayMember = dt_FileName.Columns("ColumnName").ToString

            Me.cbx_EngCode.DataSource = Nothing
            Me.cbx_EngCode.DataSource = dt_EngCode
            cbx_EngCode.ValueMember = dt_EngCode.Columns("ColumnNumber").ToString
            cbx_EngCode.DisplayMember = dt_EngCode.Columns("ColumnName").ToString

            Me.cbx_ClientCode.DataSource = Nothing
            Me.cbx_ClientCode.DataSource = dt_ClientCode
            cbx_ClientCode.ValueMember = dt_ClientCode.Columns("ColumnNumber").ToString
            cbx_ClientCode.DisplayMember = dt_ClientCode.Columns("ColumnName").ToString

            Me.cbx_Description.DataSource = Nothing
            Me.cbx_Description.DataSource = dt_Description
            cbx_Description.ValueMember = dt_Description.Columns("ColumnNumber").ToString
            cbx_Description.DisplayMember = dt_Description.Columns("ColumnName").ToString

            Me.cbx_Revision.DataSource = Nothing
            Me.cbx_Revision.DataSource = dt_Revision
            cbx_Revision.ValueMember = dt_Revision.Columns("ColumnNumber").ToString
            cbx_Revision.DisplayMember = dt_Revision.Columns("ColumnName").ToString

            Me.cbx_Sheet.DataSource = Nothing
            Me.cbx_Sheet.DataSource = dt_Sheet
            cbx_Sheet.ValueMember = dt_Sheet.Columns("ColumnNumber").ToString
            cbx_Sheet.DisplayMember = dt_Sheet.Columns("ColumnName").ToString

            Me.cbx_Sheets.DataSource = Nothing
            Me.cbx_Sheets.DataSource = dt_Sheets
            cbx_Sheets.ValueMember = dt_Sheets.Columns("ColumnNumber").ToString
            cbx_Sheets.DisplayMember = dt_Sheets.Columns("ColumnName").ToString

            Me.cbx_Location.DataSource = Nothing
            Me.cbx_Location.DataSource = dt_Location
            cbx_Location.ValueMember = dt_Location.Columns("ColumnNumber").ToString
            cbx_Location.DisplayMember = dt_Location.Columns("ColumnName").ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub cbx_RowHeaders_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_RowHeaders.CheckedChanged
        If Loading Then Return
        PopulateDatatable()

        PopulateColumnHeaderSelection()
    End Sub


End Class