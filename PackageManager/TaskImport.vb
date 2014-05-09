Imports DataStreams.Csv
Imports daqartDLL
Imports SystemManager


Public Class TaskImport

    Private FileName As String
    Private Headers As Boolean
    Private UploadMode As Integer = 0

    Dim dt_p3idHeaders As New DataTable
    Dim dt_taskidHeaders As New DataTable
    Dim dt_TaskGroupHeaders As New DataTable
    Dim dt_DescriptionHeaders As New DataTable
    Dim dt_ScheduledStartHeaders As New DataTable
    Dim dt_ScheduledFinishHeaders As New DataTable
    Dim dt_ActualStartHeaders As New DataTable
    Dim dt_ActualFinishHeaders As New DataTable
    Dim dt_BaseMHHeaders As New DataTable
    Dim dt_BaseQuantityHeaders As New DataTable

    Dim dtList As New List(Of DataTable)
    Dim cbxList As New List(Of ComboBox)

    Private Sub TaskImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            dtList.Add(dt_p3idHeaders)
            dtList.Add(dt_taskidHeaders)
            dtList.Add(dt_TaskGroupHeaders)
            dtList.Add(dt_DescriptionHeaders)
            dtList.Add(dt_ScheduledStartHeaders)
            dtList.Add(dt_ScheduledFinishHeaders)
            dtList.Add(dt_ActualStartHeaders)
            dtList.Add(dt_ActualFinishHeaders)
            dtList.Add(dt_BaseMHHeaders)
            dtList.Add(dt_BaseQuantityHeaders)

            cbxList.Add(cbx_p3id)
            cbxList.Add(cbx_taskid)
            cbxList.Add(cbx_TaskGroup)
            cbxList.Add(cbx_description)
            cbxList.Add(cbx_ScheduledStart)
            cbxList.Add(cbx_ScheduledFinish)
            cbxList.Add(cbx_ActualStart)
            cbxList.Add(cbx_ActualFinish)
            cbxList.Add(cbx_BaseMH)
            cbxList.Add(cbx_BaseQuantity)
        Catch ex As Exception
            Utilities.logErrorMessage("TaskImport.TaskImport_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OpenCSV.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "CSV files (*.csv)|*.csv"
        openFileDialog1.FilterIndex = 1

        If openFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return

        FileName = openFileDialog1.FileName
        If (MessageBox.Show("Does the .CSV file contain a header row?", "HeaderRows", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            Headers = True
        Else
            Headers = False
        End If

        ImportHeaders()

        ImportCSVData()

        PopulateColumnHeaderSelection()

        dgv_CSV.Refresh()
    End Sub

    Private Sub ImportCSVData()
        dgv_CSV.Rows.Clear()

        Dim CSVreader As CsvReader
        CSVreader = New CsvReader(FileName)

        Dim Ctr = 0
        Me.tsb_ProgressBar.Maximum = 1000

        If Headers = True Then
            CSVreader.ReadRecord()
        End If

        While (CSVreader.ReadRecord())
            dgv_CSV.Rows.Add(CSVreader.Values)

            Me.tsb_ProgressBar.Increment(1)
            Ctr = Ctr + 1
            If (Ctr Mod 100) = 0 Then

                If (Ctr Mod 1000) = 0 Then
                    Me.tsb_ProgressBar.Value = 0
                End If

                Me.Refresh()
            End If
        End While
        'Me.ToolStripTextBox1.Text = Ctr.ToString
        Me.tsb_ProgressBar.Value = Me.tsb_ProgressBar.Maximum

        Me.cbx_p3id.Focus()

        CSVreader.Close()

    End Sub

    Private Function ImportHeaders() As Boolean
        dgv_CSV.Columns.Clear()
        dgv_CSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv_CSV.AllowUserToResizeColumns = True

        Dim CSVreader As CsvReader
        CSVreader = New CsvReader(FileName)
        CSVreader.ReadHeaders()

        If Headers = True Then
            For i As Integer = 0 To CSVreader.HeaderCount - 1
                dgv_CSV.Columns.Add(CSVreader.GetHeader(i), CSVreader.GetHeader(i))
            Next
        Else
            For i As Integer = 0 To CSVreader.HeaderCount - 1
                dgv_CSV.Columns.Add("Column" & i, "Column" & i)
            Next
        End If

        CSVreader.Close()
        Return False

    End Function

    Private Sub PopulateColumnHeaderSelection()

        For i As Integer = 0 To cbxList.Count - 1
            dtList(i).Columns.Add("ColumnNumber")
            dtList(i).Columns.Add("ColumnName")
            dtList(i).Rows.Add(-1, "Leave Blank")

            For u As Integer = 0 To dgv_CSV.Columns.Count - 1
                dtList(i).Rows.Add(u, dgv_CSV.Columns(u).Name)
            Next

            cbxList(i).DataSource = dtList(i)
            cbxList(i).ValueMember = dtList(i).Columns("ColumnNumber").ToString
            cbxList(i).DisplayMember = dtList(i).Columns("ColumnName").ToString
            cbxList(i).SelectedIndex = -1
        Next

    End Sub

    'Private Sub cbx_p3id_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_p3id.SelectedIndexChanged
    '    Dim cbx_Temp As ComboBox
    '    cbx_Temp = sender
    '    RemoveSelection(cbx_Temp.SelectedIndex, cbx_Temp)
    'End Sub


    'Private Sub RemoveSelection(ByVal ThisItem As Integer, ByVal ThisCBX As ComboBox)
    '    For i As Integer = 0 To cbxList.Count - 1
    '        If Not cbxList(i).Name = ThisCBX.Name Then
    '            cbxList(i).Items.Remove(ThisItem)
    '        End If
    '    Next
    'End Sub

    Private Function CheckBlanks() As Boolean
        Dim HasError As Boolean = False


        For i As Integer = 0 To dgv_CSV.Rows.Count - 1
            For u As Integer = 0 To 1


                Dim Name As String = dgv_CSV.Rows(i).Cells(cbxList(u).SelectedIndex).Value
                If Name = "" Then
                    HasError = True
                    dgv_CSV.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    Exit For
                Else
                    If dgv_CSV.Rows(i).DefaultCellStyle.BackColor = Color.Yellow Then
                        dgv_CSV.Rows(i).DefaultCellStyle.BackColor = Color.White
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

    Private Sub btn_ImportData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Import.Click
        UploadMode = 1

        If InsertData() Then
            Utilities.SyncProjectDB(runtime.selectedProject)
            MessageBox.Show("Import Complete.")
        End If
        UploadMode = 0

        'Me.Dispose()
    End Sub


    Private Function InsertData() As Boolean
        Dim value As String = Nothing
        Dim query As String = Nothing
        Dim sContents As String = Nothing
        Dim sErr As String = Nothing

        For i As Integer = 0 To dgv_CSV.Rows.Count - 1

            Dim tmp_taskid As Integer
            If cbxList(1).SelectedIndex > 0 Then
                tmp_taskid = dgv_CSV.Rows(i).Cells(cbxList(1).SelectedIndex - 1).Value
            Else
                tmp_taskid = 0
            End If
            Dim tmp_ActualStart As String
            If cbxList(6).SelectedIndex > 0 Then
                tmp_ActualStart = dgv_CSV.Rows(i).Cells(cbxList(6).SelectedIndex - 1).Value
            Else
                tmp_ActualStart = ""
            End If
            Dim tmp_ActualFinish As String
            If cbxList(7).SelectedIndex > 0 Then
                tmp_ActualFinish = dgv_CSV.Rows(i).Cells(cbxList(7).SelectedIndex - 1).Value
            Else
                tmp_ActualFinish = ""
            End If
            Dim tmp_BaseQuantity As String
            If cbxList(9).SelectedIndex > 0 Then
                'tmp_BaseQuantity = dgv_CSV.Rows(i).Cells(cbxList(9).SelectedIndex - 1).Value
            Else
                tmp_BaseQuantity = ""
            End If


            'Aux10 = Task Group
            If Not CheckExistingTask(i) And UploadMode = 1 Then
                Dim muid = idUtils.GetNextMUID("project", "TaskList")
                sContents = " Insert Into TaskList (TS,p3id,taskid,description,ScheduledStart,ScheduledFinish," & _
                "ActualStart,ActualFinish,BaseManhours,BaseQuantity,TaskGroup) VALUES (" & _
                 "'" + Now() + "'," & _
                 "'" + dgv_CSV.Rows(i).Cells(cbxList(0).SelectedIndex - 1).Value + "'," & _
                 "'" + tmp_taskid.ToString + "'," & _
                 "'" + dgv_CSV.Rows(i).Cells(cbxList(3).SelectedIndex - 1).Value + "'," & _
                 "'" + dgv_CSV.Rows(i).Cells(cbxList(4).SelectedIndex - 1).Value + "'," & _
                 "'" + dgv_CSV.Rows(i).Cells(cbxList(5).SelectedIndex - 1).Value + "'," & _
                 "'" + tmp_ActualStart + "'," & _
                 "'" + tmp_ActualFinish + "'," & _
                 "'" + dgv_CSV.Rows(i).Cells(cbxList(8).SelectedIndex - 1).Value + "'," & _
                 "'" + tmp_BaseQuantity + "'," & _
                 "'" + dgv_CSV.Rows(i).Cells(cbxList(2).SelectedIndex - 1).Value + "'"
                sContents += ")"
            ElseIf chk_Update.Checked Or UploadMode = 2 Then
                sContents = " UPDATE TaskList SET "
                If cbxList(0).SelectedIndex > 0 Then
                    sContents += " p3id = '" + dgv_CSV.Rows(i).Cells(cbxList(0).SelectedIndex - 1).Value + "',"
                End If
                If cbxList(2).SelectedIndex > 0 Then
                    sContents += " TaskGroup = '" + dgv_CSV.Rows(i).Cells(cbxList(2).SelectedIndex - 1).Value + "',"
                End If
                If cbxList(3).SelectedIndex > 0 Then
                    sContents += " description = '" + dgv_CSV.Rows(i).Cells(cbxList(3).SelectedIndex - 1).Value + "',"
                End If
                If cbxList(4).SelectedIndex > 0 Then
                    sContents += " ScheduledStart = '" + dgv_CSV.Rows(i).Cells(cbxList(4).SelectedIndex - 1).Value + "',"
                End If
                If cbxList(5).SelectedIndex > 0 Then
                    sContents += " ScheduledFinish = '" + dgv_CSV.Rows(i).Cells(cbxList(5).SelectedIndex - 1).Value + "',"
                End If
                If cbxList(6).SelectedIndex > 0 Then
                    sContents += " ActualStart = '" + dgv_CSV.Rows(i).Cells(cbxList(6).SelectedIndex - 1).Value + "',"
                End If
                If cbxList(7).SelectedIndex > 0 Then
                    sContents += " ActualFinish = '" + dgv_CSV.Rows(i).Cells(cbxList(7).SelectedIndex - 1).Value + "',"
                End If
                If cbxList(8).SelectedIndex > 0 Then
                    sContents += " BaseManHours = '" + dgv_CSV.Rows(i).Cells(cbxList(8).SelectedIndex - 1).Value + "',"
                End If
                If cbxList(9).SelectedIndex > 0 Then
                    sContents += " BaseQuantity = '" + dgv_CSV.Rows(i).Cells(cbxList(9).SelectedIndex - 1).Value + "',"
                End If
                sContents = sContents.Remove(sContents.Length - 1, 1)
                sContents += " WHERE taskid = '" + dgv_CSV.Rows(i).Cells(cbxList(1).SelectedIndex - 1).Value + "'"
            End If



            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            Try

                sqlPrjUtils.OpenConnection()
                sqlPrjUtils.ExecuteNonQuery(sContents, dt_param)
                sqlPrjUtils.CloseConnection()
            Catch ex As SqlClient.SqlException
                'MessageBox.Show("Failed to connect to site: " + ex.Message)
                value = "Error: " + ex.Message
                Return False
            End Try

        Next
        Return True
    End Function

    Private Function CheckExistingTask(ByVal ThisRow As Integer) As Boolean
        Dim query As String = Nothing

        query = " SELECT * FROM TaskList WHERE " & _
            "MUID = '" + dgv_CSV.Rows(ThisRow).Cells(cbxList(1).SelectedIndex - 1).Value + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If dt.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function

    Private Sub cbx_p3id_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_p3id.SelectedIndexChanged
        CheckRequiredFields()
    End Sub

    Private Sub cbx_taskid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_taskid.SelectedIndexChanged
        CheckRequiredFields()
    End Sub

    Private Sub cbx_TaskGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_TaskGroup.SelectedIndexChanged
        CheckRequiredFields()
    End Sub

    Private Sub cbx_description_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_description.SelectedIndexChanged
        CheckRequiredFields()
    End Sub

    Private Sub cbx_ScheduledStart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_ScheduledStart.SelectedIndexChanged
        CheckRequiredFields()
    End Sub

    Private Sub cbx_ScheduledFinish_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_ScheduledFinish.SelectedIndexChanged
        CheckRequiredFields()
    End Sub

    Private Sub cbx_BaseMH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_BaseMH.SelectedIndexChanged
        CheckRequiredFields()
    End Sub

    Private Function CheckRequiredFields() As Boolean
        btn_Import.Enabled = False
        btn_Update.Enabled = False
        If cbx_taskid.SelectedIndex < 1 Then Return False
        btn_Update.Enabled = True
        If cbx_p3id.SelectedIndex < 1 Then Return False
        If cbx_description.SelectedIndex < 1 Then Return False
        If cbx_ScheduledStart.SelectedIndex < 1 Then Return False
        If cbx_ScheduledFinish.SelectedIndex < 1 Then Return False
        If cbx_BaseMH.SelectedIndex < 1 Then Return False
        btn_Import.Enabled = True
    End Function


    Private Sub btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Update.Click
        UploadMode = 2
        If InsertData() Then
            Utilities.SyncProjectDB(runtime.selectedProject)
            MessageBox.Show("Task Updates Complete.")
        End If
        UploadMode = 0

    End Sub


End Class