Imports daqartDLL
Imports SystemManager


Public Class TagStatusReport
    Dim dt_Final As New DataTable


    Private Sub TagStatusReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub tbx_FromDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_FromDate.DoubleClick
        Dim frmDate As New Calendar
        frmDate.ShowDialog()
        Me.tbx_FromDate.Text = frmDate.txt_Date.Text
    End Sub


    Private Sub tbx_ToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_ToDate.DoubleClick
        Dim frmDate As New Calendar
        frmDate.ShowDialog()
        Me.tbx_ToDate.Text = frmDate.txt_Date.Text
    End Sub


    Private Sub btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search.Click
        Me.Cursor = Cursors.WaitCursor

        BuildFinalTable()

        GetResults()

        GetDiscrepancyCount()

        Me.dgv_Results.DataSource = Nothing

        Me.dgv_Results.DataSource = Me.dt_Final
        Me.dgv_Results.RefreshDataSource()

        Me.dgv_Results.Refresh()

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub btn_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Export.Click
        Dim xgp As XtraGridPrinting = New XtraGridPrinting("", Me.dgv_Results)
        xgp.Show()
    End Sub


    Private Sub BuildFinalTable()
        'add system columns
        Dim TiersCount As Integer = Utilities.CountTiers

        'Me.dgv_Results.Dispose()

        'Me.dgv_Results = New DevExpress.XtraGrid.GridControl
        'Me.dgv_Results.Dock = DockStyle.Fill


        dt_Final = New DataTable

        dt_Final.Columns.Clear()
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = Me.dgv_Results.MainView
        Dim ParentView As DevExpress.XtraGrid.Views.Grid.GridView = View.ParentView
        View.Columns.Clear()


        For i As Integer = 0 To TiersCount - 1
            dt_Final.Columns.Add(SystemUtils.GetTierDescription(i + 1))
        Next

        dt_Final.Columns.Add("MUID")
        dt_Final.Columns("MUID").ColumnMapping = MappingType.Hidden

        dt_Final.Columns.Add("TagMUID")
        dt_Final.Columns("TagMUID").ColumnMapping = MappingType.Hidden

        dt_Final.Columns.Add("OwnerMUID")
        dt_Final.Columns("OwnerMUID").ColumnMapping = MappingType.Hidden

        dt_Final.Columns.Add("Tag#")
        dt_Final.Columns.Add("Package#")

        For Each EngItem As String In Me.lbx_EngInfo.SelectedItems
            dt_Final.Columns.Add(EngItem)
        Next

        dt_Final.Columns.Add("User")
        dt_Final.Columns.Add("Date")
        dt_Final.Columns.Add("Time")
        dt_Final.Columns.Add("Certificate")
        dt_Final.Columns.Add("Status")

        dt_Final.Columns.Add("FormMUID")
        dt_Final.Columns("FormMUID").ColumnMapping = MappingType.Hidden

        dt_Final.Columns.Add("Earned MH", System.Type.GetType("System.String"))

    End Sub


    Private Sub GetResults()
        dt_Final.Rows.Clear()

        Try


            Dim query As String = "SELECT MUID,Name As Certificate FROM forms ORDER BY Name ASC"
            Dim dt_forms As DataTable = runtime.SQLProject.ExecuteQuery(query)
            dt_forms.Columns("MUID").ColumnMapping = MappingType.Hidden
            dt_forms.Columns.Add("Count")


            'get tags from form status tables matching date criteria
            query = "SELECT * FROM forms_status WHERE (TS >= '" + Me.tbx_FromDate.Text + " " + Me.dtp_From.Text + "') AND (TS <= '" + Me.tbx_ToDate.Text + " " + Me.dtp_To.Text + "') ORDER BY TS "
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

            Dim TotalEMH As Double = 0.0

            For Each dr As DataRow In dt.Rows
                'Has form been rejected
                Dim reject_query As String = "SELECT * FROM forms_status WHERE TagMUID = '" + dr("TagMUID") + "' AND Action='2'"
                Dim result As DataTable = runtime.SQLProject.ExecuteQuery(reject_query)

                If Not result.Rows.Count = 0 Then
                    Dim test = "test"
                End If

                Dim PackageNumber As String = Utilities.GetPackageName(Utilities.GetPackageID(dr("TagMUID")))
                If Not PackageNumber = "0" And result.Rows.Count = 0 Then

                    Dim TagNumber As String = Utilities.TranslateTagID(dr("TagMUID"))
                    Dim SystemList() As String = Split(Utilities.GetTagSystem(dr("TagMUID")), ";")
                    Dim UserName As String = Utilities.GetUserName(dr("UserMUID"))
                    Dim FormNumber As String = Utilities.GetFormName(dr("FormMUID"))
                    Dim DateTime() As String = Split(dr("TS"), " ")
                    Dim PreviousMH As Double = GetPreviousEMH(dr("OwnerMUID"), dr("TagMUID"), dr("FormMUID"), dr("TS"))
                    Dim GainMH As Double = Math.Round(CDbl(dr("EarnedManHours")) - PreviousMH, 2)

                    If GainMH > 0 Or CInt(dr("CurrentLevel")) > 0 Then
                        TotalEMH += GainMH

                        If CInt(dr("CurrentLevel")) = 1 Then
                            For i As Integer = 0 To dt_forms.Rows.Count - 1
                                If dt_forms.Rows(i)("MUID") = dr("FormMUID") Then
                                    If IsDBNull(dt_forms.Rows(i)("Count")) Then
                                        dt_forms.Rows(i)("Count") = 0
                                    End If
                                    dt_forms.Rows(i)("Count") = dt_forms.Rows(i)("Count") + 1
                                End If
                            Next
                        End If

                        'add row to Final table
                        Me.dt_Final.Rows.Add()

                        'Populate Row
                        Dim CurrentRow As Integer = dt_Final.Rows.Count - 1
                        For i As Integer = 0 To Utilities.CountTiers - 1
                            dt_Final.Rows(CurrentRow)(SystemUtils.GetTierDescription(i + 1)) = SystemDataManager.GetSystemIdentifier(SystemList(i))
                        Next

                        dt_Final.Rows(CurrentRow)("MUID") = dr("MUID")
                        dt_Final.Rows(CurrentRow)("TagMUID") = dr("TagMUID")
                        dt_Final.Rows(CurrentRow)("OwnerMUID") = dr("OwnerMUID")
                        dt_Final.Rows(CurrentRow)("Tag#") = TagNumber
                        dt_Final.Rows(CurrentRow)("Package#") = PackageNumber

                        Dim dt_EngInfo As DataTable = Utilities.GetTagEngInfo(dr("TagMUID"))
                        If dt_EngInfo.Rows.Count > 0 Then
                            For Each EngItem As String In Me.lbx_EngInfo.SelectedItems
                                dt_Final.Rows(CurrentRow)(EngItem) = dt_EngInfo.Rows(0)(EngItem)
                            Next
                        End If

                        dt_Final.Rows(CurrentRow)("User") = UserName
                        dt_Final.Rows(CurrentRow)("Date") = DateTime(0)
                        dt_Final.Rows(CurrentRow)("Time") = DateTime(1) + " " + DateTime(2)

                        dt_Final.Rows(CurrentRow)("Certificate") = Utilities.GetFormName(dr("FormMUID"))
                        dt_Final.Rows(CurrentRow)("FormMUID") = dr("FormMUID")

                        'dt_Final.Rows(CurrentRow)("Status") = utilities.GetStatusDescription(dr("OwnerMUID"),dr("CurrentLevel"))

                        If CInt(dr("CurrentLevel")) > 0 Then
                            dt_Final.Rows(CurrentRow)("Status") = Utilities.GetStatusDescription(dr("OwnerMUID"), CInt(dr("CurrentLevel")))
                        Else
                            dt_Final.Rows(CurrentRow)("Status") = "Saved"
                        End If

                        dt_Final.Rows(CurrentRow)("Earned MH") = GainMH

                    End If
                End If

            Next

            'get tags from form me status tables matching date criteria
            query = "SELECT * FROM forms_me_status WHERE SourceType='Tag' AND (TS >= '" + Me.tbx_FromDate.Text + " " + Me.dtp_From.Text + "') AND (TS <= '" + Me.tbx_ToDate.Text + " " + Me.dtp_To.Text + "') ORDER BY TS "
            dt = runtime.SQLProject.ExecuteQuery(query)

            For Each dr As DataRow In dt.Rows
                'Has form been rejected
                Dim reject_query As String = "SELECT * FROM forms_me_status WHERE SourceMUID = '" + dr("SourceMUID") + "' AND SourceType='Tag' AND Action='2'"
                Dim result As DataTable = runtime.SQLProject.ExecuteQuery(reject_query)

                If Not result.Rows.Count = 0 Then
                    Dim test = "test"
                End If

                Dim PackageNumber As String = Utilities.GetPackageName(Utilities.GetPackageID(dr("SourceMUID")))
                If Not PackageNumber = "0" And result.Rows.Count = 0 Then

                    Dim TagNumber As String = Utilities.TranslateTagID(dr("SourceMUID"))
                    Dim SystemList() As String = Split(Utilities.GetTagSystem(dr("SourceMUID")), ";")
                    Dim UserName As String = Utilities.GetUserName(dr("UserMUID"))
                    Dim FormNumber As String = Utilities.GetFormName(dr("FormMUID"))
                    Dim DateTime() As String = Split(dr("TS"), " ")
                    Dim PreviousMH As Double = GetPreviousEMH_ME(dr("OwnerMUID"), dr("SourceMUID"), dr("FormMUID"), dr("TS"))
                    Dim GainMH As Double = Math.Round(CDbl(dr("EarnedManHours")) - PreviousMH, 2)

                    'get package earned man hours
                    query = ""

                    'divide by the number of tags on me form

                    'add to GainMH


                    If GainMH > 0 Or CInt(dr("CurrentLevel")) > 0 Then
                        TotalEMH += GainMH

                        If CInt(dr("CurrentLevel")) = 1 Then
                            For i As Integer = 0 To dt_forms.Rows.Count - 1
                                If dt_forms.Rows(i)("MUID") = dr("FormMUID") Then
                                    If IsDBNull(dt_forms.Rows(i)("Count")) Then
                                        dt_forms.Rows(i)("Count") = 0
                                    End If
                                    dt_forms.Rows(i)("Count") = dt_forms.Rows(i)("Count") + 1
                                End If
                            Next
                        End If

                        'add row to Final table
                        Me.dt_Final.Rows.Add()

                        'Populate Row
                        Dim CurrentRow As Integer = dt_Final.Rows.Count - 1
                        For i As Integer = 0 To Utilities.CountTiers - 1
                            dt_Final.Rows(CurrentRow)(SystemUtils.GetTierDescription(i + 1)) = SystemDataManager.GetSystemIdentifier(SystemList(i))
                        Next

                        dt_Final.Rows(CurrentRow)("MUID") = dr("MUID")
                        dt_Final.Rows(CurrentRow)("TagMUID") = dr("SourceMUID")
                        dt_Final.Rows(CurrentRow)("OwnerMUID") = dr("OwnerMUID")
                        dt_Final.Rows(CurrentRow)("Tag#") = TagNumber
                        dt_Final.Rows(CurrentRow)("Package#") = PackageNumber

                        Dim dt_EngInfo As DataTable = Utilities.GetTagEngInfo(dr("SourceMUID"))
                        If dt_EngInfo.Rows.Count > 0 Then
                            For Each EngItem As String In Me.lbx_EngInfo.SelectedItems
                                dt_Final.Rows(CurrentRow)(EngItem) = dt_EngInfo.Rows(0)(EngItem)
                            Next
                        End If

                        dt_Final.Rows(CurrentRow)("User") = UserName
                        dt_Final.Rows(CurrentRow)("Date") = DateTime(0)
                        dt_Final.Rows(CurrentRow)("Time") = DateTime(1) + " " + DateTime(2)

                        dt_Final.Rows(CurrentRow)("Certificate") = Utilities.GetFormName(dr("FormMUID"))
                        dt_Final.Rows(CurrentRow)("FormMUID") = dr("FormMUID")

                        If CInt(dr("CurrentLevel")) > 0 Then
                            dt_Final.Rows(CurrentRow)("Status") = Utilities.GetStatusDescription(dr("OwnerMUID"), CInt(dr("CurrentLevel")))
                        Else
                            dt_Final.Rows(CurrentRow)("Status") = "Saved"
                        End If


                        dt_Final.Rows(CurrentRow)("Earned MH") = GainMH
                    End If
                End If
            Next

            Me.tbx_TotalEMH.Text = Math.Round(TotalEMH, 2).ToString
            Me.dgv_CertCount.DataSource = dt_forms


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try




    End Sub


    Private Function GetPreviousEMH(ByVal _OwnerMUID As String, ByVal _TagMUID As String, ByVal _FormMUID As String, ByVal _DateTime As String) As Double
        Dim query As String = "SELECT * FROM forms_status WHERE " & _
                                " OwnerMUID = '" + _OwnerMUID + "'" & _
                                " AND TagMUID = '" + _TagMUID + "'" & _
                                " AND FormMUID = '" + _FormMUID + "'" & _
                                " AND TS < '" + _DateTime + "'" & _
                                " ORDER BY TS DESC"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        If dt.Rows.Count = 0 Then
            Return 0.0
        Else
            Return CDbl(dt.Rows(0)("EarnedManHours"))
        End If
    End Function

    Private Function GetPreviousEMH_ME(ByVal _OwnerMUID As String, ByVal _TagMUID As String, ByVal _FormMUID As String, ByVal _DateTime As String) As Double
        Dim query As String = "SELECT * FROM forms_me_status WHERE SourceType='Tag' AND" & _
                                " OwnerMUID = '" + _OwnerMUID + "'" & _
                                " AND SourceMUID = '" + _TagMUID + "'" & _
                                " AND FormMUID = '" + _FormMUID + "'" & _
                                " AND TS < '" + _DateTime + "'" & _
                                " ORDER BY TS DESC"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        If dt.Rows.Count = 0 Then
            Return 0.0
        Else
            Return CDbl(dt.Rows(0)("EarnedManHours"))
        End If

    End Function


    Private Sub GetDiscrepancyCount()
        Dim query As String = "SELECT * FROM discrepancy WHERE (ListedOn >= '" + Me.tbx_FromDate.Text + " " + Me.dtp_From.Text + "') AND (ListedOn <= '" + Me.tbx_ToDate.Text + " " + Me.dtp_To.Text + "')"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        If dt.Rows.Count > 0 Then
            Me.tbx_Written.Text = dt.Rows.Count.ToString
        End If

        query = "SELECT * FROM discrepancy WHERE (ClosedOn >= '" + Me.tbx_FromDate.Text + " " + Me.dtp_From.Text + "') AND (ClosedOn <= '" + Me.tbx_ToDate.Text + " " + Me.dtp_To.Text + "')"
        dt = runtime.SQLProject.ExecuteQuery(query)
        If dt.Rows.Count > 0 Then
            Me.tbx_Resolved.Text = dt.Rows.Count.ToString
        End If

    End Sub



    Private Sub dgv_Results_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Results.DoubleClick
        'Me.Cursor = Cursors.WaitCursor
        'Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = dgv_ITS.MainView
        'Dim ParentView As DevExpress.XtraGrid.Views.Grid.GridView = View.ParentView

        'If View.FocusedColumn.AbsoluteIndex < 2 Then
        '    Me.Cursor = Cursors.Default
        '    Return
        'End If

        'If IsDBNull(View.GetFocusedValue) Then
        '    Me.Cursor = Cursors.Default
        '    Return
        'End If

        'Dim ThisTag As String = View.GetFocusedDataRow.Item("MUID")
        'Dim ThisForm As String = View.FocusedColumn.Name
        'ThisForm = ThisForm.Replace("col", "")
        'Dim ThisType As String = Utilities.GetTagType(ThisTag)
        'Dim ThisOwner As String

        'Dim query As String = "SELECT OwnerMUID FROM requirements WHERE TypeMUID='" & ThisType & "'" & _
        '    " AND FormMUID='" + ThisForm + "'"
        'Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

        'If Not IsDBNull(dt.Rows(0)(0)) Then
        '    ThisOwner = dt.Rows(0)(0)
        'End If



        ''Dim TypeID As String = GetTagRecord(PkgMatrix.Rows(e.RowIndex).Cells(0).Tag).Rows(0)(4)
        ''Dim NeedStatus As Boolean = Utilities.FormCheck(TypeID, PkgMatrixTabControl.SelectedTab.Tag, ThisForm)
        ''If Not NeedStatus Then Return

        'Try
        '    Dim OpenForm As New FormDesigner.FormView(ThisForm, ThisTag, ThisOwner)
        '    OpenForm.Show()
        'Catch ex As Exception
        '    Me.Cursor = Cursors.Default
        '    MessageBox.Show(ex.Message)
        'End Try

        'Me.Cursor = Cursors.Default
    End Sub


End Class