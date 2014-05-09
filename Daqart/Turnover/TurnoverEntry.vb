Imports daqartDLL



Public Class TurnoverEntry
    Dim dt_Final As DataTable
    Dim SelectBy As String
    Dim SearchBy As String
    Dim Modified As Boolean

    Public Sub New(ByVal _dt_Final As DataTable, ByVal _SelectBy As String, ByVal _SearchBy As String)
        InitializeComponent()

        dt_Final = _dt_Final
        SelectBy = _SelectBy
        SearchBy = _SearchBy
    End Sub


    Private Sub TurnoverEntry_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Modified Then
            If MessageBox.Show("Data has been modified.  Would you like to save the data?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                Me.SaveData()
                Me.Cursor = Cursors.Default
            Else
                Me.Dispose()
            End If
        End If
    End Sub


    Private Sub TurnoverEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.SelectBy = "None" Then
            Me.lbl_Header.Text = "Turnover Status Report"
        ElseIf Me.SelectBy = "ProjectNumber" Then
            Me.lbl_Header.Text = "Turnover Status for Project#: " + SearchBy
        ElseIf Me.SelectBy = "Contractor" Then
            Me.lbl_Header.Text = "Turnover Status for Contractor: " + SearchBy
        ElseIf Me.SelectBy = "Location" Then
            Me.lbl_Header.Text = "Turnover Status for Location: " + SearchBy
        End If

        Me.dgv_Status.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_Status.AutoSize = True
        Me.dgv_Status.AutoResizeRows()

        Me.dgv_Status.DataSource = dt_Final

        Me.dgv_Status.Columns("ProjectName").ReadOnly = True
        Me.dgv_Status.Columns("SH#").ReadOnly = True
        Me.dgv_Status.Columns("MC_Description").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Me.dgv_Status.Columns("MC_Description").ReadOnly = True
        Me.dgv_Status.Columns("Disc").ReadOnly = True
        Me.dgv_Status.Columns("MC#").ReadOnly = True
        Me.dgv_Status.Columns("MC_Sent").ReadOnly = True
        Me.dgv_Status.Columns("IWL_Start").ReadOnly = True
        Me.dgv_Status.Columns("MC_Signed").ReadOnly = True
        Me.dgv_Status.Columns("SH_Sent").ReadOnly = True
        Me.dgv_Status.Columns("SH_Signed").ReadOnly = True

        Me.dgv_Status.Columns("ProjectMUID").Visible = False
        Me.dgv_Status.Columns("SH_MUID").Visible = False
        Me.dgv_Status.Columns("SH_Description").Visible = False
        Me.dgv_Status.Columns("MC_MUID").Visible = False

        Me.dgv_Status.Refresh()
    End Sub


    Private Sub dgv_Status_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgv_Status.CellBeginEdit
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex < 0 Then Return

        Me.dgv_Status.Rows(e.RowIndex).Tag = "Modified"
    End Sub


    Private Sub dgv_Status_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Status.CellClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex < 0 Then Return

        Dim RowModified As Boolean = False

        Select Case Me.dgv_Status.Columns(e.ColumnIndex).HeaderText
            Case "MC_Sent"
                Dim frm_Cal As New CommonForms.Calendar
                frm_Cal.ShowDialog()
                If CommonForms.Calendar.action = "Cancel" Then Exit Sub
                Me.dgv_Status.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CommonForms.Calendar.datev
                Modified = True
                RowModified = True

            Case "IWL_Start"
                Dim frm_Cal As New CommonForms.Calendar
                frm_Cal.ShowDialog()
                If CommonForms.Calendar.action = "Cancel" Then Exit Sub
                Me.dgv_Status.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CommonForms.Calendar.datev
                Modified = True
                RowModified = True

            Case "MC_Signed"
                Dim frm_Cal As New CommonForms.Calendar
                frm_Cal.ShowDialog()
                If CommonForms.Calendar.action = "Cancel" Then Exit Sub
                Me.dgv_Status.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CommonForms.Calendar.datev
                Modified = True
                RowModified = True

            Case "SH_Sent"
                Dim frm_Cal As New CommonForms.Calendar
                frm_Cal.ShowDialog()
                If CommonForms.Calendar.action = "Cancel" Then Exit Sub
                Me.dgv_Status.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CommonForms.Calendar.datev
                Modified = True
                RowModified = True

            Case "SH_Signed"
                Dim frm_Cal As New CommonForms.Calendar
                frm_Cal.ShowDialog()
                If CommonForms.Calendar.action = "Cancel" Then Exit Sub
                Me.dgv_Status.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CommonForms.Calendar.datev
                Modified = True
                RowModified = True

        End Select

        If RowModified = True Then
            Me.dgv_Status.Rows(e.RowIndex).Tag = "Modified"
        End If

    End Sub


    Private Sub dgv_Status_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Status.CellLeave

        If Me.dgv_Status.Columns(e.ColumnIndex).HeaderText = "SH_Sent" Then
            'find all rows matching SH MUID and update cell
            Dim ThisSH As String = Me.dgv_Status.Rows(e.RowIndex).Cells("SH_MUID").Value

            For i As Integer = 0 To Me.dgv_Status.Rows.Count - 1
                If Me.dgv_Status.Rows(i).Cells("SH_MUID").Value = ThisSH Then
                    Me.dgv_Status.Rows(i).Cells("SH_Sent").Value = Me.dgv_Status.Rows(e.RowIndex).Cells("SH_Sent").Value
                    Me.dgv_Status.Rows(i).Tag = "Modified"
                End If
            Next

        End If

        If Me.dgv_Status.Columns(e.ColumnIndex).HeaderText = "SH_Signed" Then
            'find all rows matching SH MUID and update cell
            Dim ThisSH As String = Me.dgv_Status.Rows(e.RowIndex).Cells("SH_MUID").Value

            For i As Integer = 0 To Me.dgv_Status.Rows.Count - 1
                If Me.dgv_Status.Rows(i).Cells("SH_MUID").Value = ThisSH Then
                    Me.dgv_Status.Rows(i).Cells("SH_Signed").Value = Me.dgv_Status.Rows(e.RowIndex).Cells("SH_Signed").Value
                    Me.dgv_Status.Rows(i).Tag = "Modified"
                End If
            Next

        End If

    End Sub


    Private Sub btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Update.Click
        Me.Cursor = Cursors.WaitCursor
        SaveData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SaveData()
        For i As Integer = 0 To Me.dgv_Status.Rows.Count - 1
            If Me.dgv_Status.Rows(i).Tag = "Modified" Then
                Dim ThisProjectSQL As New DataUtils("project")
                ThisProjectSQL.ProjectName = Utilities.GetProjectName(Me.dgv_Status.Rows(i).Cells("ProjectMUID").Value)

                ThisProjectSQL.OpenConnection()

                'Update System Handover Info
                Dim query As String = "UPDATE system_number SET" & _
                        " Aux04=@SH_Sent," & _
                        " Aux03=@SH_Signed" & _
                        " WHERE MUID='" + Me.dgv_Status.Rows(i).Cells("SH_MUID").Value + "'"

                Dim dt_param As DataTable = ThisProjectSQL.paramDT
                dt_param.Rows.Add("@SH_Sent", Me.dgv_Status.Rows(i).Cells("SH_Sent").Value)
                dt_param.Rows.Add("@SH_Signed", Me.dgv_Status.Rows(i).Cells("SH_Signed").Value)

                ThisProjectSQL.ExecuteNonQuery(query, dt_param)


                'Update Mechanical Completion Info
                query = "UPDATE system_number SET" & _
                        " Aux09=@ProjectNumber," & _
                        " Aux05=@IWL_Start," & _
                        " Aux04=@MC_Sent," & _
                        " Aux03=@MC_Signed" & _
                        " WHERE MUID='" + Me.dgv_Status.Rows(i).Cells("MC_MUID").Value + "'"

                dt_param = ThisProjectSQL.paramDT
                dt_param.Rows.Add("@ProjectNumber", Me.dgv_Status.Rows(i).Cells("Project Number").Value)
                dt_param.Rows.Add("@MC_Sent", Me.dgv_Status.Rows(i).Cells("MC_Sent").Value)
                dt_param.Rows.Add("@MC_Signed", Me.dgv_Status.Rows(i).Cells("MC_Signed").Value)
                dt_param.Rows.Add("@IWL_Start", Me.dgv_Status.Rows(i).Cells("IWL_Start").Value)

                ThisProjectSQL.ExecuteNonQuery(query, dt_param)

                ThisProjectSQL.CloseConnection()

                Me.dgv_Status.Rows(i).Tag = ""
            End If
        Next

        Modified = False
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim dt_Print As New DataTable

        For i As Integer = 0 To Me.dgv_Status.Columns.Count - 1
            dt_Print.Columns.Add(Me.dgv_Status.Columns(i).HeaderText)
        Next

        For i As Integer = 0 To Me.dgv_Status.Rows.Count - 1
            dt_Print.Rows.Add()
            For u As Integer = 0 To Me.dgv_Status.Columns.Count - 1
                dt_Print.Rows(dt_Print.Rows.Count - 1)(u) = Me.dgv_Status.Rows(i).Cells(u).Value
            Next
        Next

        Dim frm As New TurnoverReport(dt_Print)
        frm.Show()


    End Sub

End Class