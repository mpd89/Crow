Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports DataStreams.Csv
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports daqartDLL
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class FrmTblImport
    Private cbxCtrls As New List(Of Control)
    Private lbxCtrls As New List(Of Control)
    Private _tblName As String
    Private _key As Integer
    Private _keyColumnName As String
    Private dgv1 As System.Windows.Forms.DataGridView
    Private Function PopulateColumnHeaderSelection() As Boolean
        Dim i As Integer
        For i = 0 To dgv1.Columns.Count - 1
            If dgv1.Columns(i).HeaderText = "" Then
                dgv1.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
                dgv1.Columns(i).HeaderCell.Style.BackColor = Color.Yellow
                MessageBox.Show("Blank Header Columns Found in the Import File")
                Return False
            End If
        Next
        For i = 0 To dgv1.Columns.Count - 1
            For j As Integer = i + 1 To dgv1.Columns.Count - 1
                If dgv1.Columns(i).HeaderText = dgv1.Columns(j).HeaderText Then
                    dgv1.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
                    dgv1.Columns(j).DefaultCellStyle.BackColor = Color.Yellow
                    MessageBox.Show("Duplicate Columns Found in the Import File")
                    Return False
                End If
            Next
        Next
        'Dim useStr = "USE [" + Runtime.selectedProject + "] "
        'Dim tbl As DataTable = daqartDLL.Utilities.ExecuteRemoteQuery(useStr + "SELECT * FROM " + _tblName, "No Welders List")
        Dim qry = "SELECT * FROM " + _tblName
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim tbl As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        Dim X = 20
        Dim Y = 40
        If cbxCtrls.Count > 0 Then
            For i = 0 To cbxCtrls.Count - 1
                cbxCtrls(i).Dispose()
                lbxCtrls(i).Dispose()
            Next
            cbxCtrls.Clear()
            lbxCtrls.Clear()
        End If
        '        tbxCtrls.Clear()
        For i = 0 To tbl.Columns.Count - 1
            '            cbo.DisplayMember = dgv1.Columns(i).HeaderText
            If i < dgv1.Columns.Count Then
                Dim hdrs As New List(Of String)
                For j As Integer = 0 To dgv1.Columns.Count - 1
                    hdrs.Add(dgv1.Columns(j).HeaderText)
                Next
                Dim cbo As System.Windows.Forms.ComboBox = New System.Windows.Forms.ComboBox
                cbo.DataSource = hdrs
                cbo.DisplayMember = dgv1.Columns(i).HeaderText
                cbo.ValueMember = dgv1.Columns(i).HeaderText
                '                cbo.SelectedIndex = i
                cbo.Text = dgv1.Columns(i).HeaderText
                cbo.Location = New Point(X + 100, Y)
                cbxCtrls.Add(cbo)
                Me.SplitContainer1.Panel1.Controls.Add(cbo)
                Dim lbl As System.Windows.Forms.Label = New System.Windows.Forms.Label
                lbl.Text = tbl.Columns(i).ColumnName
                If lbl.Text = _KeyColumnName Then
                    _key = i
                End If

                lbl.Location = New Point(X, Y)
                lbl.TextAlign = ContentAlignment.TopRight
                Me.SplitContainer1.Panel1.Controls.Add(lbl)
                lbxCtrls.Add(lbl)
                Y = Y + 22
                If (i + 1) Mod 10 = 0 Then
                    X = X + 250
                    Y = 40
                End If
            End If
        Next
        Dim k As Integer = 0
        For Each ctrl As System.Windows.Forms.ComboBox In cbxCtrls
            ctrl.SelectedIndex = k
            k = k + 1
        Next
        Return True
    End Function

    Private Function ImportHeaders() As Boolean
        If Not dgv1 Is Nothing Then
            dgv1.Dispose()
        End If

        dgv1 = New DataGridView
        dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv1.Dock = DockStyle.Fill
        'dgv1.Location = New System.Drawing.Point(0,012, 458)
        'dgv1.Size = New System.Drawing.Size(956, 212)
        dgv1.BringToFront()
        Me.SplitContainer1.Panel2.Controls.Add(dgv1)
        dgv1.Visible = True

        Dim CSVreader As CsvReader
        CSVreader = New CsvReader(Me.fileName.Text)
        CSVreader.ReadHeaders()
        For i As Integer = 0 To CSVreader.HeaderCount - 1
            dgv1.Columns.Add(CSVreader.GetHeader(i), CSVreader.GetHeader(i))
        Next

        If Not PopulateColumnHeaderSelection() Then
            Return False
        End If
        CSVreader.Close()
        Return False

    End Function
    Private Sub ImportCSVData()

        Dim CSVreader As CsvReader
        '        CSVreader = New CsvReader("c:\tmp\Test002.csv")
        CSVreader = New CsvReader(Me.fileName.Text)

        Dim Ctr = 0
        Me.ToolStripProgressBar1.Maximum = 1000
        CSVreader.ReadRecord()
        While (CSVreader.ReadRecord())
            dgv1.Rows.Add(CSVreader.Values)
            Me.ToolStripProgressBar1.Increment(1)
            Ctr = Ctr + 1
            If (Ctr Mod 100) = 0 Then
                '                Me.ToolStripTextBox1.Text = Ctr.ToString
                If (Ctr Mod 1000) = 0 Then
                    Me.ToolStripProgressBar1.Value = 0
                End If
                Me.Refresh()
            End If
        End While
        '       Me.ToolStripTextBox1.Text = Ctr.ToString
        Me.ToolStripProgressBar1.Value = Me.ToolStripProgressBar1.Maximum
        MessageBox.Show("File read ok")
        '    Me.btnImportCSV.Enabled = False
        '      Me.cboTagNumber.Focus()
        CSVreader.Close()

    End Sub

    Private Sub btnImportWeldersList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportWeldersList.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "CSV files (*.csv)|*.csv"
        openFileDialog1.FilterIndex = 1

        If openFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return

        Me.fileName.Visible = True
        Me.fileName.Text = openFileDialog1.FileName

        ImportHeaders()
        '        Me.TabPage2.Controls.Add(Panel1)
        ImportCSVData()
        btnUploadPkgNums.Visible = True
    End Sub
    Private Sub UploadWeldersList()
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt_param As DataTable = sqlPrjUtils.paramDT


        Dim i As Integer
        Dim qryInsertColumns As String = " INSERT INTO " + _tblName + "("
        For i = 0 To lbxCtrls.Count - 1
            If lbxCtrls(i).Text <> "ID" Then
                qryInsertColumns = qryInsertColumns + lbxCtrls(i).Text + ","
            End If
        Next
        qryInsertColumns = qryInsertColumns.Remove(qryInsertColumns.Length - 1, 1)
        qryInsertColumns = qryInsertColumns + ") VALUES ("
        Dim row As Integer
        Me.ToolStripProgressBar1.Maximum = dgv1.RowCount
        Me.ToolStripProgressBar1.Value = 0
        Dim InsertCtr = 0
        Dim UpdateCtr = 0

        Dim ignoreCtr As Integer = 0
        Dim ignore As Boolean = False
        For row = 0 To dgv1.RowCount - 1
            Dim updateQry As String = "Update " + _tblName + " SET "
            Dim qryVal As String = ""
            For i = 0 To cbxCtrls.Count - 1
                Dim cbx As System.Windows.Forms.ComboBox = cbxCtrls(i)
                If cbx.SelectedIndex >= 0 And lbxCtrls(i).Text <> "ID" Then
                    Dim val = dgv1.Rows(row).Cells(cbx.SelectedIndex).Value
                    qryVal = qryVal + "'" + val + "',"
                    If (i <> _key) Then updateQry = updateQry + lbxCtrls(i).Text + "=@" + lbxCtrls(i).Text + ","
                    dt_param.Rows.Add("@" + lbxCtrls(i).Text, val)
                End If
            Next
            qryVal = qryVal.Remove(qryVal.Length - 1, 1)
            qryVal = qryVal + ")"
            updateQry = updateQry.Remove(updateQry.Length - 1, 1)
            Dim whereClause As String = " WHERE " + _keyColumnName + "='" + dgv1.Rows(row).Cells(1).Value + "'"
            InsertCtr = InsertCtr + 1

            Dim qry As String = " SELECT * FROM " + _tblName + whereClause
            Dim ex As Integer = sqlPrjUtils.ExecuteQuery(qry).Rows.Count
            If ex > 0 Then
                UpdateCtr = UpdateCtr + 1
                InsertCtr = InsertCtr - 1

                sqlPrjUtils.ExecuteNonQuery(updateQry + whereClause, dt_param)
            Else
                sqlPrjUtils.ExecuteNonQuery(updateQry + whereClause, dt_param)
            End If


            Me.ToolStripProgressBar1.Increment(1)
            Me.ToolStripStatusLabel2.Text = "Record " + row.ToString + " of " + dgv1.RowCount.ToString
            Me.Refresh()
        Next
        Me.ToolStripStatusLabel2.Text = "Record " + row.ToString + " of " + dgv1.RowCount.ToString
        If ignoreCtr > 0 Then
            MessageBox.Show("Total records " + row.ToString + "; inserted = " + InsertCtr.ToString + "; updated = " + UpdateCtr.ToString + "; ignored =" + ignoreCtr.ToString)
        Else
            MessageBox.Show("Total records " + row.ToString + "; inserted = " + InsertCtr.ToString + "; updated = " + UpdateCtr.ToString)
        End If

        sqlPrjUtils.CloseConnection()

    End Sub

    Private Sub btnUploadPkgNums_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadPkgNums.Click
        UploadWeldersList()
    End Sub
    Public Sub New(ByVal Description As String, ByVal tblName As String, ByVal uniqueKeyColumnName As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblImport.Text = Description
        _keyColumnName = uniqueKeyColumnName
        _tblName = tblName
        Me.ToolStripStatusLabel2.Text = ""

    End Sub
End Class