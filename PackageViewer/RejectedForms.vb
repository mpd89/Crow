Imports daqartDLL


Public Class RejectedForms

    Private Sub RejectedForms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            'get all rejected forms
            'Dim query As String = "SELECT * FROM forms_status Order BY TagMUID ASC, Action DESC"
            Dim query As String = "SELECT * FROM forms_status WHERE Action='2'"
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

            Dim dt_Final As New DataTable
            dt_Final.Columns.Add("MUID")
            dt_Final.Columns("MUID").ColumnMapping = MappingType.Hidden
            dt_Final.Columns.Add("Date-Time")
            dt_Final.Columns.Add("OwnerMUID")
            dt_Final.Columns("OwnerMUID").ColumnMapping = MappingType.Hidden
            dt_Final.Columns.Add("TagMUID")
            dt_Final.Columns("TagMUID").ColumnMapping = MappingType.Hidden
            dt_Final.Columns.Add("Tag Number")
            dt_Final.Columns.Add("FormMUID")
            dt_Final.Columns("FormMUID").ColumnMapping = MappingType.Hidden
            dt_Final.Columns.Add("Form")
            dt_Final.Columns.Add("Submitted By")
            dt_Final.Columns.Add("Rejected By")
            dt_Final.Columns.Add("Comment")

            For i As Integer = 0 To dt.Rows.Count - 1

                '        query = "SELECT * FROM forms_status WHERE " & _
                '" OwnerMUID = '" + dt.Rows(i)("OwnerMUID") + "' AND" & _
                '" TagMUID = '" + dt.Rows(i)("TagMUID") + "' AND" & _
                '" FormMUID = '" + dt.Rows(i)("FormMUID") + "' AND" & _
                '" CurrentLevel > '" + dt.Rows(i)("CurrentLevel") + "' AND" & _
                '" TS > '" + dt.Rows(i)("TS") + "'"


                'check for later submits
                query = "SELECT * FROM forms_status WHERE " & _
                    " OwnerMUID = '" + dt.Rows(i)("OwnerMUID") + "' AND" & _
                    " TagMUID = '" + dt.Rows(i)("TagMUID") + "' AND" & _
                    " FormMUID = '" + dt.Rows(i)("FormMUID") + "' AND" & _
                    " CurrentLevel = '1' AND" & _
                    " TS > '" + dt.Rows(i)("TS") + "'"
                Dim dt_ReSubmitted As DataTable = runtime.SQLProject.ExecuteQuery(query)

                If dt_ReSubmitted.Rows.Count = 0 Then
                    'get previous submitted info
                    query = "SELECT * FROM forms_status WHERE" & _
                            " TS<'" + dt.Rows(i)("TS") + "' AND" & _
                            " OwnerMUID = '" + dt.Rows(i)("OwnerMUID") + "' AND" & _
                            " TagMUID = '" + dt.Rows(i)("TagMUID") + "' AND" & _
                            " FormMUID = '" + dt.Rows(i)("FormMUID") + "' AND" & _
                            " Action = '1'" & _
                            " ORDER BY TS DESC"

                    Dim dt_SubmitInfo As DataTable = runtime.SQLProject.ExecuteQuery(query)

                    'add to dt_Final

                    dt_Final.Rows.Add(dt.Rows(i)("MUID"), dt.Rows(i)("TS"), dt.Rows(i)("OwnerMUID"), _
                                        dt.Rows(i)("TagMUID"), Utilities.TranslateTagID(dt.Rows(i)("TagMUID")), _
                                        dt.Rows(i)("FormMUID"), Utilities.GetFormName(dt.Rows(i)("FormMUID")), _
                                        Utilities.GetUserName(dt_SubmitInfo.Rows(0)("UserMUID")), _
                                        Utilities.GetUserName(dt.Rows(i)("UserMUID")), dt.Rows(i)("Comment"))
                End If
            Next

            'get ME form data
            query = "SELECT * FROM forms_me_status WHERE Action='2' AND SourceType= 'Tag'"
            dt = runtime.SQLProject.ExecuteQuery(query)

            For i As Integer = 0 To dt.Rows.Count - 1
                'check for later submits
                query = "SELECT * FROM forms_me_status WHERE " & _
                    " OwnerMUID = '" + dt.Rows(i)("OwnerMUID") + "' AND" & _
                    " SourceMUID = '" + dt.Rows(i)("SourceMUID") + "' AND" & _
                    " FormMUID = '" + dt.Rows(i)("FormMUID") + "' AND" & _
                    " SourceType= 'Tag' AND CurrentLevel = '1' AND" & _
                    " TS > '" + dt.Rows(i)("TS") + "'"
                Dim dt_ReSubmitted As DataTable = runtime.SQLProject.ExecuteQuery(query)

                If dt_ReSubmitted.Rows.Count = 0 Then
                    'get previous submitted info
                    query = "SELECT * FROM forms_me_status WHERE" & _
                            " TS<'" + dt.Rows(i)("TS") + "' AND" & _
                            " OwnerMUID = '" + dt.Rows(i)("OwnerMUID") + "' AND" & _
                            " SourceMUID = '" + dt.Rows(i)("SourceMUID") + "' AND" & _
                            " FormMUID = '" + dt.Rows(i)("FormMUID") + "' AND" & _
                            " SourceType = 'Tag' AND Action = '1'" & _
                            " ORDER BY TS DESC"

                    Dim dt_SubmitInfo As DataTable = runtime.SQLProject.ExecuteQuery(query)

                    If dt_SubmitInfo.Rows.Count > 0 Then
                        'add to dt_Final
                        dt_Final.Rows.Add(dt.Rows(i)("MUID"), dt.Rows(i)("TS"), dt.Rows(i)("OwnerMUID"), _
                                            dt.Rows(i)("SourceMUID"), Utilities.TranslateTagID(dt.Rows(i)("SourceMUID")), _
                                            dt.Rows(i)("FormMUID"), Utilities.GetFormName(dt.Rows(i)("FormMUID")), _
                                            Utilities.GetUserName(dt_SubmitInfo.Rows(0)("UserMUID")), _
                                            Utilities.GetUserName(dt.Rows(i)("UserMUID")), dt.Rows(i)("Comment"))
                    End If
                End If
            Next

            Me.dgv_Final.DataSource = dt_Final
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub dgv_Final_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Final.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = Me.dgv_Final.MainView
        Dim ParentView As DevExpress.XtraGrid.Views.Grid.GridView = View.ParentView

        If View.GetFocusedDataRow.Item("TagMUID") = "TagMUID" Then
            Me.Cursor = Cursors.Default
            Return
        End If

        If IsDBNull(View.GetFocusedValue) Then
            Me.Cursor = Cursors.Default
            Return
        End If

        Try
            Dim OpenForm As New FormDesigner.FormView(View.GetFocusedDataRow.Item("FormMUID"), View.GetFocusedDataRow.Item("TagMUID"), View.GetFocusedDataRow.Item("OwnerMUID"))
            OpenForm.Show()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub btn_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Export.Click
        Dim xgp As CommonForms.XtraGridPrinting = New CommonForms.XtraGridPrinting("Rejected Forms", Me.dgv_Final)
        xgp.Show()
    End Sub


End Class