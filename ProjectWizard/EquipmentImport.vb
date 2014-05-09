Imports DataStreams.Csv
Imports daqartDLL
Imports SystemManager


Public Class EquipmentImport
    Private CboControls(4) As System.Windows.Forms.ComboBox
    Dim SQLProject As DataUtils


    Private Sub EquipmentImport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLProject.CloseConnection()
    End Sub


    Private Sub SystemImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SQLProject = New DataUtils("project")
        SQLProject.OpenConnection()

        CboControls(0) = cbx_Type
        CboControls(1) = cbx_Description
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

            ImportHeaders()

            ImportCSVData()

            PopulateColumnHeaderSelection()

            dgv_TypeGrid.Refresh()
        Catch ex As Exception
            Utilities.logErrorMessage("ProjectWizard.EquipmentImport.Button1-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Function ImportHeaders() As Boolean
        dgv_TypeGrid.Columns.Clear()
        dgv_TypeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv_TypeGrid.AllowUserToResizeColumns = True

        Dim CSVreader As CsvReader
        CSVreader = New CsvReader(Me.tbx_Filename.Text)
        CSVreader.ReadHeaders()

        If cbx_Headers.Checked = True Then
            For i As Integer = 0 To CSVreader.HeaderCount - 1
                dgv_TypeGrid.Columns.Add(CSVreader.GetHeader(i), CSVreader.GetHeader(i))
            Next
        Else
            For i As Integer = 0 To CSVreader.HeaderCount - 1
                dgv_TypeGrid.Columns.Add("Column" & i, "Column" & i)
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
            dgv_TypeGrid.Rows.Add(CSVreader.Values)

            Me.tsb_ProgressBar.Increment(1)
            Ctr = Ctr + 1
            If (Ctr Mod 100) = 0 Then

                If (Ctr Mod 1000) = 0 Then
                    Me.tsb_ProgressBar.Value = 0
                End If

                Me.Refresh()
            End If
        End While
        Me.tsb_ProgressBar.Value = Me.tsb_ProgressBar.Maximum
        Me.cbx_Type.Focus()

        CSVreader.Close()
    End Sub


    Private Sub PopulateColumnHeaderSelection()
        Dim dt_TypeHeaders As New DataTable
        Dim dt_DescriptionHeaders As New DataTable

        dt_TypeHeaders.Columns.Add("ColumnNumber")
        dt_TypeHeaders.Columns.Add("ColumnName")
        dt_DescriptionHeaders.Columns.Add("ColumnNumber")
        dt_DescriptionHeaders.Columns.Add("ColumnName")

        For i As Integer = 0 To dgv_TypeGrid.Columns.Count - 1
            dt_TypeHeaders.Rows.Add(i, dgv_TypeGrid.Columns(i).Name)
            dt_DescriptionHeaders.Rows.Add(i, dgv_TypeGrid.Columns(i).Name)
        Next

        cbx_Type.DataSource = dt_TypeHeaders
        cbx_Type.ValueMember = dt_TypeHeaders.Columns("ColumnNumber").ToString
        cbx_Type.DisplayMember = dt_TypeHeaders.Columns("ColumnName").ToString

        cbx_Description.DataSource = dt_DescriptionHeaders
        cbx_Description.ValueMember = dt_DescriptionHeaders.Columns("ColumnNumber").ToString
        cbx_Description.DisplayMember = dt_DescriptionHeaders.Columns("ColumnName").ToString
    End Sub


    Private Sub btn_CheckData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CheckData.Click
        ValidateData()
    End Sub


    Private Function ValidateData() As Boolean
        Dim HasError As Boolean = False

        If Not CheckBlanks() Then
            Return False
        End If

        If Not CheckDuplicates() Then
            Return False
        End If

        If Not CheckExistingSystem() Then
            Return False
        End If


        For i As Integer = 0 To dgv_TypeGrid.Rows.Count - 1
            If dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.Yellow Then
                HasError = True
            End If
            If dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.Aqua Then
                HasError = True
            End If
            If dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.Fuchsia Then
                HasError = True
            End If
        Next

        If HasError Then
            MessageBox.Show("Please correct all errors and check data again.", "Data Error", _
            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            MessageBox.Show("Data check successful.")
            btn_ImportData.Enabled = True
        End If

        Return True
    End Function


    Private Function CheckBlanks() As Boolean
        Dim HasError As Boolean = False
        For i As Integer = 0 To dgv_TypeGrid.Rows.Count - 1
            For u As Integer = 0 To 1
                Dim Name As String = dgv_TypeGrid.Rows(i).Cells(CboControls(u).SelectedIndex).Value
                If Name = "" Then
                    HasError = True
                    dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    Exit For
                Else
                    If dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.Yellow Then
                        dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.White
                    End If
                End If
            Next
        Next

        If HasError Then
            If MessageBox.Show("There are blanks in mapped columns in the CSV File." & vbCr & "Would you like to continue?", "Data Error", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, _
            MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.No Then
                Return False
            End If
        End If

        Return True
    End Function


    Private Function CheckDuplicates() As Boolean
        Dim HasError As Boolean = False
        Dim ShowError As Boolean = False

        For i As Integer = 0 To dgv_TypeGrid.Rows.Count - 1

            Dim Name As String = dgv_TypeGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value

            For u As Integer = 0 To dgv_TypeGrid.Rows.Count - 1

                If u <> i Then
                    If (dgv_TypeGrid.Rows(u).Cells(CboControls(0).SelectedIndex).Value = dgv_TypeGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value) Or _
                        (dgv_TypeGrid.Rows(u).Cells(CboControls(1).SelectedIndex).Value = dgv_TypeGrid.Rows(i).Cells(CboControls(1).SelectedIndex).Value) Then

                        HasError = True
                    End If
                End If
            Next


            If HasError Then
                dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.Aqua
                ShowError = True
            Else
                If dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.Aqua Then
                    dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If
            End If
            HasError = False

        Next

        If ShowError Then
            If MessageBox.Show("Duplicate type numbers(s) or description(s) in the CSV File." & vbCr & "Would you like to continue?", "Data Error", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, _
            MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.No Then
                Return False
            End If

        End If

        Return True
    End Function


    Private Function CheckExistingSystem() As Boolean
        Dim HasError As Boolean = False
        Dim query As String = Nothing

        For i As Integer = 0 To dgv_TypeGrid.Rows.Count - 1
            query = " SELECT * FROM equipment_type WHERE TypeName = '" + dgv_TypeGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value + "'"
            Dim dt As DataTable = SQLProject.ExecuteQuery(query)

            If dt.Rows.Count > 0 Then
                HasError = True
                dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.Fuchsia
            Else
                If dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.Fuchsia Then
                    dgv_TypeGrid.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If
            End If
        Next

        If HasError Then
            If MessageBox.Show("There are systems in the .CSV file that exist on the server." & vbCr & "Would you like to continue?", "Data Error", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, _
            MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.No Then
                Return False
            End If
        End If

        Return True
    End Function


    Private Sub btn_ImportData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ImportData.Click
        If InsertTypes() Then
            Utilities.SyncProjectDB(runtime.selectedProject)
            MessageBox.Show("Import Complete.")
        End If
        Me.Dispose()
    End Sub


    Private Function InsertTypes() As Boolean
        Dim query As String = Nothing

        For i As Integer = 0 To dgv_TypeGrid.Rows.Count - 1
            query = " Insert Into equipment_type (MUID,TS,TypeName,TypeDesc,Active) VALUES (" & _
             "@MUID," & _
             "@TS," & _
             "@TypeName," & _
             "@TypeDesc," & _
             "@Active" & _
             ")"

            Dim dt_param As DataTable = SQLProject.paramDT
            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "equipment_type"))
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@TypeName", dgv_TypeGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value)
            dt_param.Rows.Add("@TypeDesc", dgv_TypeGrid.Rows(i).Cells(CboControls(1).SelectedIndex).Value)
            dt_param.Rows.Add("@Active", "True")

            Try
                SQLProject.ExecuteNonQuery(query, dt_param)
            Catch ex As Exception
                MessageBox.Show("Failed to insert types: " + ex.Message)
                Return False
            End Try
        Next

        Return True
    End Function


End Class