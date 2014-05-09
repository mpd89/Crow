Imports DataStreams.Csv
Imports daqartDLL
Imports SystemManager


Public Class SystemImport
    Private CboControls(4) As System.Windows.Forms.ComboBox
    Dim SQLProject As DataUtils


    Private Sub SystemImport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLProject.CloseConnection()
    End Sub


    Private Sub SystemImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SQLProject = New DataUtils("project")
        SQLProject.OpenConnection()

        CboControls(0) = cbx_Tier
        CboControls(1) = cbx_Parent
        CboControls(2) = cbx_Identifier
        CboControls(3) = cbx_Description
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

            If ImportHeaders() Then
                Me.tbx_Filename.Text = ""
                Return
            End If

            ImportCSVData()

            PopulateColumnHeaderSelection()

            dgv_SystemGrid.Refresh()
        Catch ex As Exception
            Utilities.logErrorMessage("ProjectWizard.SystemImport.Button1-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Function ImportHeaders() As Boolean
        dgv_SystemGrid.Columns.Clear()
        dgv_SystemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv_SystemGrid.AllowUserToResizeColumns = True

        Dim CSVreader As CsvReader
        CSVreader = New CsvReader(Me.tbx_Filename.Text)
        CSVreader.ReadHeaders()

        If cbx_Headers.Checked = True Then
            For i As Integer = 0 To CSVreader.HeaderCount - 1
                If (CSVreader.GetHeader(i)) = "" Then
                    MessageBox.Show("Invalid Column header; Column#:" + i.ToString)
                    Return True
                End If
                dgv_SystemGrid.Columns.Add(CSVreader.GetHeader(i), CSVreader.GetHeader(i))
            Next
        Else
            For i As Integer = 0 To CSVreader.HeaderCount - 1
                dgv_SystemGrid.Columns.Add("Column" & i, "Column" & i)
            Next
        End If
        If dgv_SystemGrid.Columns.Count < 4 Then
            MessageBox.Show("Not enough columns in the .csv file")
            Return True
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
            dgv_SystemGrid.Rows.Add(CSVreader.Values)

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

        Me.cbx_Tier.Focus()
        CSVreader.Close()
    End Sub


    Private Sub PopulateColumnHeaderSelection()
        Dim dt_TierHeaders As New DataTable
        Dim dt_ParentHeaders As New DataTable
        Dim dt_IdentifierHeaders As New DataTable
        Dim dt_DescriptionHeaders As New DataTable

        dt_TierHeaders.Columns.Add("ColumnNumber")
        dt_TierHeaders.Columns.Add("ColumnName")
        dt_ParentHeaders.Columns.Add("ColumnNumber")
        dt_ParentHeaders.Columns.Add("ColumnName")
        dt_IdentifierHeaders.Columns.Add("ColumnNumber")
        dt_IdentifierHeaders.Columns.Add("ColumnName")
        dt_DescriptionHeaders.Columns.Add("ColumnNumber")
        dt_DescriptionHeaders.Columns.Add("ColumnName")

        For i As Integer = 0 To dgv_SystemGrid.Columns.Count - 1
            dt_TierHeaders.Rows.Add(i, dgv_SystemGrid.Columns(i).Name)
            dt_ParentHeaders.Rows.Add(i, dgv_SystemGrid.Columns(i).Name)
            dt_IdentifierHeaders.Rows.Add(i, dgv_SystemGrid.Columns(i).Name)
            dt_DescriptionHeaders.Rows.Add(i, dgv_SystemGrid.Columns(i).Name)
        Next

        cbx_Tier.DataSource = dt_TierHeaders
        cbx_Tier.ValueMember = dt_TierHeaders.Columns("ColumnNumber").ToString
        cbx_Tier.DisplayMember = dt_TierHeaders.Columns("ColumnName").ToString

        cbx_Parent.DataSource = dt_ParentHeaders
        cbx_Parent.ValueMember = dt_ParentHeaders.Columns("ColumnNumber").ToString
        cbx_Parent.DisplayMember = dt_ParentHeaders.Columns("ColumnName").ToString

        cbx_Identifier.DataSource = dt_IdentifierHeaders
        cbx_Identifier.ValueMember = dt_IdentifierHeaders.Columns("ColumnNumber").ToString
        cbx_Identifier.DisplayMember = dt_IdentifierHeaders.Columns("ColumnName").ToString

        cbx_Description.DataSource = dt_DescriptionHeaders
        cbx_Description.ValueMember = dt_DescriptionHeaders.Columns("ColumnNumber").ToString
        cbx_Description.DisplayMember = dt_DescriptionHeaders.Columns("ColumnName").ToString
    End Sub


    Private Sub btn_CheckData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CheckData.Click
        Me.Cursor = Cursors.WaitCursor
        btn_ImportData.Enabled = False
        ValidateData()
        Me.Cursor = Cursors.Default
    End Sub


    Private Function ValidateData() As Boolean
        Dim HasError As Boolean = False

        If Not CheckDuplicates() Then
            Return False
        End If

        If Not CheckBlanks() Then
            Return False
        End If


        If Not CheckExistingSystem() Then
            Return False
        End If

        If Not CheckExistingParent() Then
            Return False
        End If


        For i As Integer = 0 To dgv_SystemGrid.Rows.Count - 1
            If dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.Yellow Then
                HasError = True
            End If
            If dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.Aqua Then
                HasError = True
            End If
            If dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.Fuchsia Then
                HasError = True
            End If
            If dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.PaleVioletRed Then
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
        Dim query = "SELECT COUNT(*) FROM system_mnemonic"
        Dim CountTiers = SQLProject.ExecuteQuery(query).Rows(0)(0)

        If dgv_SystemGrid.Rows.Count = 0 Then
            MessageBox.Show("Please import valid .csv file")
            Return False
        End If
        Try
            For i As Integer = 0 To dgv_SystemGrid.Rows.Count - 1
                Dim Tier As Integer = Convert.ToInt32(dgv_SystemGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value)
                If Tier > CountTiers Then
                    MessageBox.Show("Invalid Tier level in row# " + i.ToString)
                    HasError = True
                    Return False
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Tear level must be an integer(Column:" + CboControls(0).SelectedText)
            Return False
        End Try


        For i As Integer = 0 To dgv_SystemGrid.Rows.Count - 1

            For u As Integer = 0 To 3


                'Dim Tier As Integer = Convert.ToInt32(dgv_SystemGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value)
                Try
                    Dim Tier As Integer = Convert.ToInt32(dgv_SystemGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value)
                    If Tier > CountTiers Then
                        MessageBox.Show("Invalid Tier level in row# " + i.ToString)
                        HasError = True
                        Return False
                    End If
                    Try
                        Dim Skip As Boolean = False
                        If ((SystemDataManager.HasParent(Tier) = "False") Or (SystemDataManager.HasParent(Tier) = "")) And u = 1 Then
                            Skip = True
                        End If

                        If Not Skip Then

                            Dim Name As String = dgv_SystemGrid.Rows(i).Cells(CboControls(u).SelectedIndex).Value
                            If Name = "" Then
                                HasError = True
                                dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                                Exit For
                            Else
                                If dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.Yellow Then
                                    dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.White
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Inavlid Tier Column Value (Column#" + u.ToString)
                        Return False
                    End Try

                Catch ex As Exception
                    MessageBox.Show("Tear level must be an integer(Column:" + CboControls(0).SelectedText)
                    Return False
                End Try
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
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                If i <> j Then
                    If (CboControls(i).Text = CboControls(j).Text) Then
                        MessageBox.Show("Duplicate column mapping")
                        HasError = True
                        Return False
                    End If
                End If
            Next
        Next




        For i As Integer = 0 To dgv_SystemGrid.Rows.Count - 1

            Dim Name As String = dgv_SystemGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value + _
                "-" + dgv_SystemGrid.Rows(i).Cells(CboControls(2).SelectedIndex).Value + _
                "-" + dgv_SystemGrid.Rows(i).Cells(CboControls(1).SelectedIndex).Value

            For u As Integer = 0 To dgv_SystemGrid.Rows.Count - 1
                If u <> i Then
                    If ((dgv_SystemGrid.Rows(u).Cells(CboControls(0).SelectedIndex).Value = dgv_SystemGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value) And _
                        (dgv_SystemGrid.Rows(u).Cells(CboControls(2).SelectedIndex).Value = dgv_SystemGrid.Rows(i).Cells(CboControls(2).SelectedIndex).Value) And _
                        (dgv_SystemGrid.Rows(u).Cells(CboControls(1).SelectedIndex).Value = dgv_SystemGrid.Rows(i).Cells(CboControls(1).SelectedIndex).Value)) Then 'Or _
                        '(dgv_SystemGrid.Rows(u).Cells(CboControls(3).SelectedIndex).Value = dgv_SystemGrid.Rows(i).Cells(CboControls(3).SelectedIndex).Value) Then

                        Dim Match As String = dgv_SystemGrid.Rows(u).Cells(CboControls(0).SelectedIndex).Value + _
                            "-" + dgv_SystemGrid.Rows(u).Cells(CboControls(2).SelectedIndex).Value + _
                            "-" + dgv_SystemGrid.Rows(u).Cells(CboControls(1).SelectedIndex).Value

                        HasError = True
                    End If
                End If
            Next

            If HasError Then
                dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.Aqua
                ShowError = True
            Else
                If dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.Aqua Then
                    dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If
            End If
            HasError = False
        Next

        If ShowError Then
            If MessageBox.Show("Duplicate system numbers(s) or description(s) in the CSV File." & vbCr & "Would you like to continue?", "Data Error", _
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




        For i As Integer = 0 To dgv_SystemGrid.Rows.Count - 1


            query = " SELECT * FROM system_number WHERE Identifier = '" + dgv_SystemGrid.Rows(i).Cells(CboControls(2).SelectedIndex).Value + "' AND TierID = '" + dgv_SystemGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value + "'"
            Dim dt As DataTable = SQLProject.ExecuteQuery(query)

            If dt.Rows.Count > 0 Then
                HasError = True
                dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.Fuchsia
            Else
                If dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.Fuchsia Then
                    dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.White
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


    Private Function CheckExistingParent() As Boolean
        Dim HasError As Boolean = False
        Dim ShowError As Boolean = False
        Dim query As String = Nothing
        Dim Tier As Integer = 0
        Dim ParentTier As Integer = 0
        Dim HasParent As Boolean = False

        For i As Integer = 0 To dgv_SystemGrid.Rows.Count - 1

            Tier = Convert.ToInt32(dgv_SystemGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value)
            ParentTier = Tier - 1
            If SystemDataManager.HasParent(Tier) = "True" Then
                For u As Integer = 0 To dgv_SystemGrid.Rows.Count - 1
                    If ((dgv_SystemGrid.Rows(u).Cells(CboControls(2).SelectedIndex).Value = dgv_SystemGrid.Rows(i).Cells(CboControls(1).SelectedIndex).Value) And _
                            (dgv_SystemGrid.Rows(u).Cells(CboControls(0).SelectedIndex).Value = ParentTier)) Then

                        HasParent = True
                        HasError = False
                        If dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.PaleVioletRed Then
                            dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.White
                        End If
                        Exit For
                    Else
                        HasError = True
                    End If
                Next


                If HasError Then
                    'check database if not in datagrid
                    query = " SELECT * FROM system_number WHERE Identifier = '" + dgv_SystemGrid.Rows(i).Cells(CboControls(1).SelectedIndex).Value + "' AND TierID = '" + ParentTier.ToString + "'"
                    Dim dt As DataTable = SQLProject.ExecuteQuery(query)

                    If dt.Rows.Count = 0 Then
                        HasError = True
                        dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.PaleVioletRed
                    Else
                        HasError = False
                        If dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.PaleVioletRed Then
                            dgv_SystemGrid.Rows(i).DefaultCellStyle.BackColor = Color.White
                        End If
                    End If
                End If

            End If

            If HasError Then
                ShowError = True
            End If
            HasError = False
        Next

        If ShowError Then
            If MessageBox.Show("There are systems in the .CSV file that do not have a valid parent system." & vbCr & "Would you like to continue?", "Data Error", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, _
            MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.No Then
                Return False
            End If
        End If

        Return True
    End Function


    Private Sub btn_ImportData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ImportData.Click
        If InsertSystems() Then

            'Utilities.SyncProjectDB(runtime.selectedProject)
            MessageBox.Show("Import Complete.")
        End If
        Me.Dispose()
    End Sub


    Private Function InsertSystems() As Boolean
        Dim query As String = Nothing

        For i As Integer = 0 To dgv_SystemGrid.Rows.Count - 1
            Dim ParentTier As Integer = Convert.ToInt32(dgv_SystemGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value) - 1

            query = " Insert Into system_number (MUID,TS,Identifier,ParentLinkMUID,Description,TierMUID) VALUES (" & _
             " @MUID," & _
             " @TS," & _
             " @Identifier," & _
             " @ParentLinkMUID," & _
             " @Description," & _
             " @TierMUID)"

            Dim dt_param As DataTable = SQLProject.paramDT
            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "system_number"))
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@Identifier", dgv_SystemGrid.Rows(i).Cells(CboControls(2).SelectedIndex).Value)
            dt_param.Rows.Add("@ParentLinkMUID", GetSystemID(dgv_SystemGrid.Rows(i).Cells(CboControls(1).SelectedIndex).Value, ParentTier))
            dt_param.Rows.Add("@Description", dgv_SystemGrid.Rows(i).Cells(CboControls(3).SelectedIndex).Value)
            dt_param.Rows.Add("@TierMUID", dgv_SystemGrid.Rows(i).Cells(CboControls(0).SelectedIndex).Value)

            Try
                SQLProject.ExecuteNonQuery(query, dt_param)
            Catch ex As Exception
                MessageBox.Show("Import Complete: " + ex.Message)
                Return False
            End Try
        Next

        Return True
    End Function


    Private Function GetSystemID(ByVal thisNumber As String, ByVal thisTier As String)
        Dim result As String = Nothing
        Dim query As String = " SELECT MUID FROM system_number WHERE Identifier='" + thisNumber + "' AND TierMUID='" + thisTier + "'"

        Try
            Dim dt As DataTable = SQLProject.ExecuteQuery(query)

            If dt.Rows.Count > 0 Then
                result = dt.Rows(0)(0)
            End If

        Catch ex As Exception
            MessageBox.Show("Cannot get Tier IsParent: " + ex.Message)
        End Try

        Return result
    End Function

End Class