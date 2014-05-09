Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid


Public Class RequirementsManager
    Dim dt_Matrix As New DataTable
    Dim dt_Matrix_original As New DataTable
    Dim GridModified As Boolean = False
    Dim CellChanging As Boolean = False
    Dim CurrentCellRow As Integer
    Dim CurrentCellColumn As Integer
    Dim SQLProject As DataUtils



    Private Sub RequirementsManager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If GridModified Then
            If MessageBox.Show("The grid has been modified, would you like to save your changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SaveGrid()
            End If
        End If
        SQLProject.CloseConnection()
    End Sub


    Private Sub RequirementsManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Enabled = False
        Me.Cursor = Cursors.AppStarting

        SQLProject = New DataUtils("project")
        SQLProject.OpenConnection()

        PopulateOwners()

        CreateFormColumns()
        GetEqTypes()

        Me.dgv_Certification.DataSource = Me.dt_Matrix

        Me.Cursor = Cursors.Default
        Me.Enabled = True

        AddHandler GridView1.RowCellStyle, AddressOf GridView1_RowCellStyle

    End Sub


    Private Sub CreateFormColumns()
        Dim query As String = "Select * from forms Order by Name ASC"
        Dim dt As New DataTable

        Try
            dt = SQLProject.ExecuteQuery(query)

            Me.dt_Matrix.Columns.Add("TypeName")
            Me.dt_Matrix_original.Columns.Add("TypeName")
            For Each dr As DataRow In dt.Rows
                Try

                    Me.dt_Matrix.Columns.Add(dr(2))
                    Me.dt_Matrix_original.Columns.Add(dr(2))
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub GetEqTypes()
        Dim query As String = "Select TypeName from equipment_type Order by TypeName ASC"
        Dim dt As New DataTable

        Try
            dt = SQLProject.ExecuteQuery(query)

            For Each dr As DataRow In dt.Rows
                Me.dt_Matrix.Rows.Add(dr(0))
                Me.dt_Matrix_original.Rows.Add(dr(0))
            Next
        Catch ex As Exception

        End Try

    End Sub


    Private Sub PopulateOwners()
        Dim query As String = "Select * From owner Order By Name"
        Dim dt As New DataTable

        Dim ServerSQL As New DataUtils("server")
        ServerSQL.OpenConnection()
        dt = ServerSQL.ExecuteQuery(query)
        ServerSQL.CloseConnection()

        For Each dr As DataRow In dt.Rows
            Me.cbx_OwnerList.Items.Add(dr(2))
        Next

        Me.cbx_OwnerList.SelectedIndex = -1
    End Sub


    Private Sub PopulateGrid()
        Me.dt_Matrix = New DataTable
        Me.dt_Matrix_original = New DataTable
        CreateFormColumns()
        GetEqTypes()

        'Me.dgv_Certification.DataSource = Me.dt_Matrix

        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = Me.dgv_Certification.MainView

        For i As Integer = 0 To View.RowCount - 1
            Dim query As String = "SELECT  requirements.FormMUID, forms.Name FROM " & _
                " requirements INNER JOIN forms ON requirements.FormMUID = forms.MUID" & _
                " WHERE OwnerMUID='" + Utilities.GetOwner(Me.cbx_OwnerList.Text) + "'" & _
                " AND TypeMUID='" + Utilities.GetTypeID(View.GetRowCellValue(i, View.Columns(0).Caption)) + "'"
            Dim dt As DataTable = Me.SQLProject.ExecuteQuery(query)

            For Each dr As DataRow In dt.Rows
                Dim newValue As Object
                Dim TypeName As String = View.GetRowCellValue(i, View.Columns(0).Caption)

                newValue = GetCert(Utilities.GetTypeID(TypeName), dr(0), Utilities.GetOwner(Me.cbx_OwnerList.Text))

                Me.dt_Matrix.Rows(i)(dt_Matrix.Columns(dr(1)).Ordinal) = newValue
                Me.dt_Matrix_original.Rows(i)(dt_Matrix.Columns(dr(1)).Ordinal) = newValue
            Next
        Next

        For u As Integer = 1 To View.Columns.Count - 1
            View.Columns(u).BestFit()

            If Utilities.IsFormMultiElement(Utilities.GetFormID(View.Columns(u).Caption)) Then
                View.Columns(u).OptionsColumn.ReadOnly = True
            End If
        Next

        Me.dt_Matrix.AcceptChanges()
        Me.dt_Matrix_original.AcceptChanges()

        Me.dgv_Certification.DataSource = Nothing
        Me.dgv_Certification.DataSource = Me.dt_Matrix


        View.Columns(0).OptionsColumn.FixedWidth = True
        View.Columns(0).Fixed = Columns.FixedStyle.Left
        View.Columns(0).BestFit()
        View.Columns(0).OptionsColumn.ReadOnly = True


        Me.dgv_Certification.Refresh()

    End Sub

    Private Function GetCert(ByVal _TypeMUID As String, ByVal _FormMUID As String, ByVal _OwnerMUID As String) As String

        Dim query As String = "SELECT * FROM requirements WHERE OwnerMUID='" + _OwnerMUID + "'" & _
            "AND FormMUID='" + _FormMUID + "' AND TypeMUID='" + _TypeMUID + "'"

        Dim dt As New DataTable
        Try
            dt = SQLProject.ExecuteQuery(query)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    If Utilities.IsFormMultiElement(_FormMUID) Then
                        Return dt.Rows(0)(5).ToString + " / " + dt.Rows(0)(6).ToString
                    Else
                        Return dt.Rows(0)(5).ToString
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

        If Utilities.IsFormMultiElement(_FormMUID) Then
            Return "-- / --"
        Else
            Return "--"
        End If
    End Function


    Private Sub cbx_OwnerList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_OwnerList.SelectedIndexChanged

        If GridModified Then
            If MessageBox.Show("The grid has been modified, would you like to save your changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SaveGrid()
            End If
        End If

        Me.Cursor = Cursors.AppStarting

        GridModified = False

        PopulateGrid()

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        GridModified = True
        Me.dgv_Certification.Refresh()

    End Sub


    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = Me.dgv_Certification.MainView

        Dim view As GridView = DirectCast(sender, GridView)
        Dim row As DataRow = view.GetDataRow(e.RowHandle)
        Try
            If row.RowState = DataRowState.Modified Then
                If row.HasVersion(DataRowVersion.Original) Then
                    If Not Equals(row(e.Column.FieldName, DataRowVersion.Current), row(e.Column.FieldName, DataRowVersion.Original)) Then
                        e.Appearance.BackColor = Color.Aqua
                        Me.dgv_Certification.Refresh()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub SaveGrid()
        Me.Cursor = Cursors.AppStarting
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = Me.dgv_Certification.MainView
        Dim query As String = Nothing
        Dim dt As New DataTable

        Try
            Dim OwnerID As String = Utilities.GetOwner(Me.cbx_OwnerList.Text)
            For i As Integer = 0 To View.RowCount - 1
                Dim TypeName As String = View.GetRowCellValue(i, View.Columns(0).Caption)
                Dim TypeID As String = Utilities.GetTypeID(TypeName)
                Dim DR As DataRow = View.GetDataRow(i)


                If DR.RowState = DataRowState.Modified Then
                    For u As Integer = 1 To View.Columns.Count - 1
                        Dim FormID As String = Utilities.GetFormID(View.Columns(u).Caption)

                        Dim CellValue As String
                        If IsDBNull(View.GetRowCellValue(i, View.Columns(u).Caption)) Then
                            CellValue = ""
                        Else
                            CellValue = View.GetRowCellValue(i, View.Columns(u).Caption)
                        End If



                        Dim MH() As String = CellValue.Split("/")
                        Dim MEMH As String = Nothing

                        query = "SELECT MUID FROM requirements WHERE TypeMUID='" + TypeID + "' AND FormMUID='" + FormID + "' AND OwnerMUID='" + OwnerID + "'"
                        dt = SQLProject.ExecuteQuery(query)

                        If MH.Length > 1 Then
                            MEMH = MH(1)
                        Else
                            MEMH = 0
                        End If

                        If dt.Rows.Count > 0 Then
                            Dim dt_param As DataTable = SQLProject.paramDT
                            If Not CellValue = "" Then
                                If MH.Length > 1 Then
                                    query = "UPDATE requirements SET Manhours=@Manhours,MEManHours=@MEManHours WHERE MUID=@MUID"
                                    dt_param.Rows.Add("@Manhours", MH(0).Trim(" "))
                                    dt_param.Rows.Add("@MEManHours", MH(1).Trim(" "))
                                    dt_param.Rows.Add("@MUID", dt.Rows(0)(0).ToString)
                                Else
                                    query = "UPDATE requirements SET Manhours=@Manhours WHERE MUID=@MUID"
                                    dt_param.Rows.Add("@Manhours", CellValue.Trim(" "))
                                    dt_param.Rows.Add("@MUID", dt.Rows(0)(0).ToString)
                                End If
                            Else
                                query = "DELETE FROM requirements WHERE MUID=@MUID"
                                dt_param.Rows.Add("@MUID", dt.Rows(0)(0).ToString)
                            End If

                            SQLProject.ExecuteNonQuery(query, dt_param)
                        Else
                            If Not CellValue = "" Then
                                query = "INSERT INTO requirements (MUID,TS," & _
                                    " OwnerMUID,TypeMUID,FormMUID,ManHours,MEManhours) values (" & _
                                    " @MUID," & _
                                    " @TS," & _
                                    " @OwnerMUID," & _
                                    " @TypeMUID," & _
                                    " @FormMUID," & _
                                    " @ManHours," & _
                                    " @MEManhours)"

                                Dim dt_param As DataTable = SQLProject.paramDT
                                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "requirements"))
                                dt_param.Rows.Add("@TS", Now())
                                dt_param.Rows.Add("@OwnerMUID", OwnerID)
                                dt_param.Rows.Add("@TypeMUID", TypeID)
                                dt_param.Rows.Add("@FormMUID", FormID)
                                dt_param.Rows.Add("@ManHours", MH(0))
                                dt_param.Rows.Add("@MEManhours", MEMH)

                                SQLProject.ExecuteNonQuery(query, dt_param)
                            End If
                        End If
                    Next
                End If
            Next
            MessageBox.Show("Requirement updates successful.")
            GridModified = False

        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SaveGrid()
    End Sub

    Private Sub dgv_Certification_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Certification.Click
        Me.dgv_Certification.Refresh()
    End Sub


    Private Sub dgv_Certification_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Certification.DoubleClick
        If Me.cbx_OwnerList.Text = "" Then Return

        Dim View As ColumnView = Me.dgv_Certification.MainView
        If View.FocusedRowHandle < 0 Then Return
        If View.FocusedColumn.VisibleIndex = 0 Then Return

        Dim CellValue As String
        If IsDBNull(View.FocusedValue) Then
            CellValue = ""
        Else
            CellValue = View.FocusedValue
        End If
        Dim frm_MeReq As New MERequirement(CellValue, Utilities.GetFormID(View.FocusedColumn.Caption))
        frm_MeReq.ShowDialog()
        Dim ThisResult As DialogResult = frm_MeReq.CmdResult

        If ThisResult = DialogResult.OK Then
            dt_Matrix.Rows(View.FocusedRowHandle)(View.FocusedColumn.VisibleIndex) = frm_MeReq.ReturnValue
            Me.dgv_Certification.RefreshDataSource()
            Me.GridModified = True
        End If



    End Sub


    Private Sub dgv_Certification_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgv_Certification.KeyPress
        Me.dgv_Certification.Refresh()
    End Sub

    Private Sub btn_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Export.Click
        Dim xgp As CommonForms.XtraGridPrinting = New CommonForms.XtraGridPrinting("Certification Requirements", Me.dgv_Certification)
        xgp.Show()

    End Sub
End Class