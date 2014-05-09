Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports DataStreams.Csv
Imports System.IO
Imports DevExpress.XtraEditors.Controls
Imports daqartDLL
Public Class equipmentImport
    Private cboFields As New List(Of Control)
    Private dgv1 As System.Windows.Forms.DataGridView
    Public Class ColumnMap
        Private _Num As Integer
        Private _Name As String
        Public Sub New(ByVal Num As Integer, ByVal Name As String)
            _Num = Num
            _Name = Name
        End Sub
        Public Property Num() As Integer
            Get
                Return _Num
            End Get
            Set(ByVal Num As Integer)
                _Num = Num
            End Set
        End Property
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal Name As String)
                _Name = Name
            End Set
        End Property

        '        Public Overrides Function ToString() As String
        '           Return String.Format("{0}---{1}", _Num, _Name)
        '      End Function
    End Class


    Private Function PopulateColumnHeaderSelection() As Boolean
        For i As Integer = 0 To dGV1.Columns.Count - 1
            If dGV1.Columns(i).HeaderText = "" Then
                dGV1.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
                dGV1.Columns(i).HeaderCell.Style.BackColor = Color.Yellow
                MessageBox.Show("Blank Header Columns Found in the Import File")
                Return False
            End If
        Next
        For i As Integer = 0 To dGV1.Columns.Count - 1
            For j As Integer = i + 1 To dGV1.Columns.Count - 1
                If dGV1.Columns(i).HeaderText = dGV1.Columns(j).HeaderText Then
                    dGV1.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
                    dGV1.Columns(j).DefaultCellStyle.BackColor = Color.Yellow
                    MessageBox.Show("Duplicate Columns Found in the Import File")
                    Return False
                End If
            Next
        Next
        For j As Integer = 0 To cboFields.Count - 1
            Dim hdrs As New List(Of ColumnMap)
            For i As Integer = 0 To dgv1.Columns.Count - 1
                hdrs.Add(New ColumnMap(i, dgv1.Columns(i).HeaderText))
            Next
            Dim cbo As ComboBox = cboFields(j)
            cbo.DataSource = hdrs
            cbo.DisplayMember = "name"
            cbo.ValueMember = "num"
            cbo.SelectedIndex = -1
            cbo.Text = ""
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
        dgv1.Location = New System.Drawing.Point(12, 458)
        dgv1.Size = New System.Drawing.Size(956, 212)
        dgv1.BringToFront()
        Me.Controls.Add(dgv1)

        Dim CSVreader As CsvReader
        CSVreader = New CsvReader(Me.fileName.Text)
        CSVreader.ReadHeaders()
        For i As Integer = 0 To CSVreader.HeaderCount - 1
            dgv1.Columns.Add(CSVreader.GetHeader(i), CSVreader.GetHeader(i))
        Next
        If Not PopulateColumnHeaderSelection() Then
            CSVreader.Close()
            Return False
        End If
        CSVreader.Close()
        Return False

    End Function
    Private Sub btnImportCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    End Sub




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
                Me.ToolStripProgressBar1.Text = Ctr.ToString
                If (Ctr Mod 1000) = 0 Then
                    Me.ToolStripProgressBar1.Value = 0
                End If
                Me.Refresh()
            End If
        End While
        Me.ToolStripProgressBar1.Text = Ctr.ToString
        Me.ToolStripProgressBar1.Value = Me.ToolStripProgressBar1.Maximum
        MessageBox.Show("File Import Completed")
        '    Me.btnImportCSV.Enabled = False
        Me.cboFields(0).Focus()
        CSVreader.Close()

    End Sub

    Private Sub AssignFieldColumns()
        Dim fields() As String = {"TagName", "Remarks", "Prefix", "Description", _
              "Service", "Manufacturer", "ModelNumber", "SerialNumber", "PONumber", "LineNumber"}
        Dim mytop As Point = Me.lblEquipmentImport.Location
        Dim X = mytop.X + 40 : Dim Y = mytop.Y + 40
        Dim k = 0
        For i As Integer = 0 To fields.Length - 1
            Dim ctrl As Control = New ComboBox
            Dim lbl As Label = New Label
            lbl.TextAlign = ContentAlignment.TopRight
            lbl.Text = fields(i)
            lbl.Location = New Point(X, Y + (k * 25) + 20)
            ctrl.Location = New Point(lbl.Location.X + lbl.Width + 10, lbl.Location.Y)
            cboFields.Add(ctrl)
            Me.TabControl1.TabPages(0).Controls.Add(ctrl)
            Me.TabControl1.TabPages(0).Controls.Add(lbl)
            k = k + 1
            If ((i + 1) Mod 5) = 0 Then
                X = X + 300
                k = 0
            End If
        Next
    End Sub

    Private Sub equipmentImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            AssignFieldColumns()
        Catch ex As Exception
            Utilities.logErrorMessage("PackageManager.equipmentImport_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class