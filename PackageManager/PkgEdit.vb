Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors



Public Class PkgEdit
    Dim GroupList As New ArrayList()
    Dim OwnerList As New ArrayList()
    Dim DisciplineList As New ArrayList()
    Dim groupCombo As RepositoryItemComboBox = New RepositoryItemComboBox
    Dim ownerCombo As RepositoryItemComboBox = New RepositoryItemComboBox
    Dim disciplineCombo As RepositoryItemComboBox = New RepositoryItemComboBox
    Dim tableModified As Boolean = False
    Private AuxTable As DataTable
    Private AuxIDTable As DataTable
    Public Class Record
        Dim _id As String
        Dim _name As String
        Sub New(ByVal id As String, ByVal name As String)
            Me._id = id
            Me._name = name
        End Sub
        Public ReadOnly Property ID() As String
            Get
                Return _id
            End Get
        End Property
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal Value As String)
                _name = Value
            End Set
        End Property
    End Class

    Public Enum PackageSelectEnum
        GroupByPackages
        GroupByEngineeringType
        AllPackages
    End Enum
    Private PackageSelectType As PackageSelectEnum
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub PackageSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            GridControl_GroupByAllPackages()

            Dim sqlSrvUtils As DataUtils = New DataUtils("server")
            sqlSrvUtils.OpenConnection()

            Dim qry As String = ""
            qry = "SELECT Name, MUID From groups"
            'Dim grpTable As DataTable = Utilities.ExecuteRemoteQuery(qry, "")

            Dim grpTable As DataTable = sqlSrvUtils.ExecuteQuery(qry)
            cboGroup.DataSource = grpTable
            cboGroup.DisplayMember = grpTable.Columns("Name").ToString
            cboGroup.ValueMember = grpTable.Columns("MUID").ToString
            cboGroup.SelectedIndex = -1


            qry = "SELECT Name, MUID From owner"
            'Dim ownerTable As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
            Dim ownerTable As DataTable = sqlSrvUtils.ExecuteQuery(qry)
            cboOwner.DataSource = ownerTable
            cboOwner.DisplayMember = ownerTable.Columns("Name").ToString
            cboOwner.ValueMember = ownerTable.Columns("MUID").ToString
            cboOwner.SelectedIndex = -1

            qry = "SELECT Name, MUID From Discipline"
            'Dim dspTable As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
            Dim dspTable As DataTable = sqlSrvUtils.ExecuteQuery(qry)

            cboDiscipline.DataSource = dspTable
            cboDiscipline.DisplayMember = dspTable.Columns("Name").ToString
            cboDiscipline.ValueMember = dspTable.Columns("MUID").ToString
            cboDiscipline.SelectedIndex = -1

            sqlSrvUtils.CloseConnection()

            Dim View As ColumnView = GridControl1.MainView
            groupCombo.AutoComplete = True
            If grpTable.Rows.Count > 0 Then
                For i As Integer = 0 To grpTable.Rows.Count - 1
                    GroupList.Add(grpTable.Rows(i)("Name"))
                Next
            End If
            groupCombo.Items.AddRange(GroupList)
            GridControl1.RepositoryItems.Add(groupCombo)
            View.Columns("GroupID").ColumnEdit = groupCombo

            ownerCombo.AutoComplete = True
            If ownerTable.Rows.Count > 0 Then
                For i As Integer = 0 To ownerTable.Rows.Count - 1
                    OwnerList.Add(ownerTable.Rows(i)("Name"))
                Next
            End If
            ownerCombo.Items.AddRange(OwnerList)

            GridControl1.RepositoryItems.Add(ownerCombo)
            View.Columns("OwnerID").ColumnEdit = ownerCombo

            disciplineCombo.AutoComplete = True
            If dspTable.Rows.Count > 0 Then
                For i As Integer = 0 To dspTable.Rows.Count - 1
                    DisciplineList.Add(dspTable.Rows(i)("Name"))
                Next
            End If
            disciplineCombo.Items.AddRange(DisciplineList)
            GridControl1.RepositoryItems.Add(disciplineCombo)
            View.Columns("DisciplineID").ColumnEdit = disciplineCombo


            Dim riButtonEdit As RepositoryItemButtonEdit = New RepositoryItemButtonEdit()
            GridControl1.RepositoryItems.Add(riButtonEdit)
            View.Columns("SystemNumber").ColumnEdit = riButtonEdit
            AddHandler riButtonEdit.Click, AddressOf repositoryItemButtonEdit1_Click


        Catch ex As Exception
            Utilities.logErrorMessage("PkgEdit.PackageSelect_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
        AddHandler GridView1.RowCellStyle, AddressOf GridView1_RowCellStyle

    End Sub


    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs)
        Dim View As GridView = sender
        'If Not ValidateCellValue Then Return
        e.Appearance.BackColor = Color.Empty
        'SELECT PackageNumber, SystemNumber, GroupID, OwnerID, DisciplineID 
        Dim Row As DataRow = View.GetDataRow(e.RowHandle)

        Dim cellval As String = View.GetRowCellDisplayText(e.RowHandle, e.Column)
        If cellval = "Undefined" Then
            e.Appearance.BackColor = Me.tbx_ColorInvalid.BackColor
        End If
        If cellval = "" Then
            e.Appearance.BackColor = Me.tbx_ColorBlank.BackColor
        End If
    End Sub
    Private Sub GridControl_AuxData(ByVal PackageID As String, ByVal DisciplineID As String)
        If Not AuxTable Is Nothing Then
            AuxTable.Dispose()
            Me.VGridControl1.DataSource = Nothing
        End If
        AuxTable = New DataTable("AuxData")
        If Not AuxIDTable Is Nothing Then
            AuxIDTable.Dispose()
        End If
        AuxIDTable = New DataTable("AuxID")

        Dim qry As String = ""
        qry = "SELECT aux_fieldmap.MUID AS AuxMUID, aux_fieldmap.CustomName, aux_package.auxData " + _
                        " FROM aux_fieldmap, aux_package, aux_template_assoc " + _
                        " WHERE (aux_fieldmap.TemplateMUID = aux_template_assoc.templateMUID) AND " + _
                        " (aux_template_assoc.AssocMUID ='" + PackageID.ToString + "') AND " + _
                        " (aux_template_assoc.SourceMUID = 'Package') AND " + _
                        " (aux_package.FieldmapMUID = aux_fieldmap.MUID) AND " + _
                        " ( aux_package.PackageMUID = '" + PackageID.ToString + "')"
        'Dim dt As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()
        If dt.Rows.Count < 1 Then Return


        For i As Integer = 0 To dt.Rows.Count - 1
            Dim DataCol As DataColumn = New DataColumn()
            DataCol.DataType = System.Type.GetType("System.String")
            DataCol.ColumnName = dt.Rows(i)("CustomName")
            AuxTable.Columns.Add(DataCol)
            Dim IDCol As DataColumn = New DataColumn()
            IDCol.DataType = System.Type.GetType("System.String")
            IDCol.ColumnName = dt.Rows(i)("AuxMUID")
            AuxIDTable.Columns.Add(IDCol)
        Next

        Dim rowData As DataRow = AuxTable.NewRow()
        Dim rowID As DataRow = AuxIDTable.NewRow()
        For i As Integer = 0 To dt.Rows.Count - 1
            rowData(i) = dt.Rows(i)("auxData")
            rowID(i) = dt.Rows(i)("AuxMUID")
        Next
        AuxTable.Rows.Add(rowData)
        AuxIDTable.Rows.Add(rowID)
        AuxTable.AcceptChanges()
        AuxIDTable.AcceptChanges()
        Me.VGridControl1.DataSource = AuxTable
        Me.VGridControl1.RowHeaderWidth = 200
        Me.VGridControl1.Refresh()
    End Sub


    Private Sub GridControl_GroupByAllPackages()
        GridControl1.DataSource = Nothing
        DataNavigator1.DataSource = Nothing
        Dim qry = " SELECT MUID, PackageNumber, SystemMUID, GroupMUID, OwnerMUID, DisciplineMUID " + _
                        " FROM Package "
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim DisplayTable As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        Dim myHdr() As String = Split("SystemNumber GroupID OwnerID DisciplineID", " ")
        For Each s As String In myHdr
            Dim ThisColumn As DataColumn = New DataColumn(s, GetType(String))
            ThisColumn.ColumnName = s
            DisplayTable.Columns.Add(ThisColumn)
        Next



        Dim i As Integer = 0
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()
        Try

            For Each drow As DataRow In DisplayTable.Rows
                'Dim dRow As DataRow = DisplayTable.NewRow
                drow("SystemNumber") = SystemManager.SystemDataManager.TranslateSystemID(drow("SystemMUID"))
                qry = "SELECT Name From groups WHERE MUID = '" + drow("GroupMUID").ToString + "'"
                drow("GroupID") = sqlSrvUtils.ExecuteQuery(qry).Rows(0)("Name")
                qry = "SELECT Name From owner WHERE MUID = '" + drow("OwnerMUID").ToString + "'"
                drow("OwnerID") = sqlSrvUtils.ExecuteQuery(qry).Rows(0)("Name")
                qry = "SELECT Name From Discipline WHERE MUID = '" + drow("DisciplineMUID").ToString + "'"
                drow("DisciplineID") = sqlSrvUtils.ExecuteQuery(qry).Rows(0)("Name")
            Next

            Me.GridControl1.DataSource = DisplayTable
            Me.DataNavigator1.DataSource = DisplayTable
        Catch ex As Exception
            Utilities.logErrorMessage("PkgEdit.PackageSelect_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
        sqlSrvUtils.CloseConnection()
        Dim View As ColumnView = GridControl1.MainView
        View.Columns("SystemMUID").Visible = False
        View.Columns("MUID").Visible = False
        View.Columns("GroupMUID").Visible = False
        View.Columns("OwnerMUID").Visible = False
        View.Columns("DisciplineMUID").Visible = False
        GridControl1.ForceInitialize()
    End Sub


    Private Sub repositoryItemButtonEdit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim View As ColumnView = GridControl1.MainView
        Dim rowHnadle = View.FocusedRowHandle
        'Dim thisSystem As New SystemManager.SystemDataManager
        Dim old_SystemMUID As String = View.GetFocusedRowCellValue(View.Columns("SystemMUID"))
        Dim systemMUID As String = SystemManager.SystemDataManager.GetSystem(old_SystemMUID)
        If systemMUID = "" Then Return
        Dim SystemName = SystemManager.SystemDataManager.TranslateSystemID(systemMUID)
        View.SetFocusedRowCellValue(View.Columns("SystemNumber"), SystemName)
        View.SetFocusedRowCellValue(View.Columns("SystemMUID"), systemMUID)
        View.SetFocusedRowModified()
    End Sub
    


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim systemMUID As String = SystemManager.SystemDataManager.GetSystem(tbxSysNum.Tag)
        If systemMUID = "" Then Return
        Dim SystemName As String = SystemManager.SystemDataManager.TranslateSystemID(SystemMUID)
        tbxSysNum.Text = SystemName
        tbxSysNum.Tag = SystemMUID
    End Sub




    Private Sub GridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Dim View As ColumnView = GridControl1.MainView
        Dim Row As DataRow = View.GetDataRow(View.FocusedRowHandle)
        btnUpdatePackages.Enabled = True

        Dim PkgID As String = View.GetDataRow(View.FocusedRowHandle)("MUID")
        Dim DspID As String = View.GetDataRow(View.FocusedRowHandle)("DisciplineMUID")
        GridControl_AuxData(PkgID, DspID)
    End Sub

    Private Sub btnUpdateAuxVals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateAuxVals.Click
        Dim View As ColumnView = GridControl1.MainView
        Dim PackageID As Integer = View.GetDataRow(View.FocusedRowHandle)(0)
        If PackageID > 0 Then
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()

            For j As Integer = 0 To Me.VGridControl1.Rows.Count - 1
                Dim colVal As String = Me.VGridControl1.GetCellValue(Me.VGridControl1.Rows(j), 0)
                Dim colID As Integer = AuxIDTable.Rows(0)(j)
                Dim query = " UPDATE aux_package SET auxData = @auxData" + _
                                " WHERE  (FieldmapMUID =@FieldmapMUID) AND (" + _
                                " PackageMUID = @PackageMUID)"

                Dim dt_param As DataTable = sqlPrjUtils.paramDT
                dt_param.Rows.Add("@auxData", colVal)
                dt_param.Rows.Add("@FieldmapMUID", colID.ToString)
                dt_param.Rows.Add("@PackageMUID", PackageID.ToString)

                sqlPrjUtils.ExecuteNonQuery(query, dt_param)
            Next
            sqlPrjUtils.CloseConnection()
        End If
    End Sub

    Private Sub VGridControl1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VGridControl1.CellValueChanged
        btnUpdateAuxVals.Enabled = True
    End Sub
    Private Sub UpdateSelectedRecords()
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()

        Dim View As ColumnView = GridControl1.FocusedView
        For i As Integer = 0 To View.RowCount - 1
            If View.IsRowSelected(i) Then
                Dim PkgNum = View.GetRowCellValue(i, "PackageNumber")
                Dim pkgID = View.GetRowCellValue(i, "MUID")
                Dim SysID As String = IIf(Me.tbxSysNum.Text > "", Me.tbxSysNum.Tag, View.GetRowCellValue(i, "SystemMUID"))
                Dim GroupID As String = IIf(Me.cboGroup.Text > "", Me.cboGroup.SelectedValue, View.GetRowCellValue(i, "GroupMUID"))
                Dim OwnerID As String = IIf(Me.cboOwner.Text > "", Me.cboOwner.SelectedValue, View.GetRowCellValue(i, "OwnerMUID"))
                Dim DisciplineID As String = IIf(Me.cboDiscipline.Text > "", Me.cboDiscipline.SelectedValue, View.GetRowCellValue(i, "DisciplineMUID"))

                Dim qry = "UPDATE Package Set PackageNumber = '" + PkgNum + "'" + _
                            ", SystemMUID = @SystemMUID" + _
                            ", GroupMUID = @GroupMUID" + _
                            ", OwnerMUID = @OwnerMUID" + _
                            ", DisciplineMUID = @DisciplineMUID" + _
                            " WHERE MUID = @MUID"
                'Utilities.ExecuteRemoteNonQuery(qry, "")
                Dim dt_param As DataTable = sqlPrjUtils.paramDT

                dt_param.Rows.Add("@PackageNumber", PkgNum)
                dt_param.Rows.Add("@SystemMUID", SysID.ToString)
                dt_param.Rows.Add("@GroupMUID", GroupID.ToString)
                dt_param.Rows.Add("@OwnerMUID", OwnerID.ToString)
                dt_param.Rows.Add("@DisciplineMUID", DisciplineID.ToString)
                dt_param.Rows.Add("@MUID", pkgID.ToString)
                sqlPrjUtils.ExecuteNonQuery(qry,dt_param)

            End If
        Next
        sqlPrjUtils.CloseConnection()
        GridControl_GroupByAllPackages()
        Me.Cursor = Cursors.Default
        Me.Enabled = True
    End Sub
    Private Sub UpdateModifiedRecords()
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim View As ColumnView = GridControl1.FocusedView

        For i As Integer = 0 To View.RowCount - 1
            Dim Row As DataRow = View.GetDataRow(i)
            If Row.RowState = DataRowState.Modified Then
                Dim PkgNum = Row("PackageNumber")
                Dim pkgID = Row("MUID")
                Dim SysID As String = Row("SystemMUID")
                Dim GroupID As String = Row("GroupMUID")
                Dim OwnerID As String = Row("OwnerMUID")
                Dim DisciplineID As String = Row("DisciplineMUID")

                'Dim qry = "UPDATE Package Set PackageNumber = '" + PkgNum + "'" + _
                '            ", SystemMUID = '" + SysID.ToString + "'" + _
                '            ", GroupMUID = '" + GroupID.ToString + "'" + _
                '            ", OwnerMUID = '" + OwnerID.ToString + "'" + _
                '            ", DisciplineMUID = '" + DisciplineID.ToString + "'" + _
                '            " WHERE MUID = '" + pkgID.ToString + "'"
                ''Utilities.ExecuteRemoteNonQuery(qry, "")
                'sqlPrjUtils.ExecuteNonQuery(qry)


                Dim qry = "UPDATE Package Set PackageNumber = '" + PkgNum + "'" + _
                            ", SystemMUID = @SystemMUID" + _
                            ", GroupMUID = @GroupMUID" + _
                            ", OwnerMUID = @OwnerMUID" + _
                            ", DisciplineMUID = @DisciplineMUID" + _
                            " WHERE MUID = @MUID"
                'Utilities.ExecuteRemoteNonQuery(qry, "")
                Dim dt_param As DataTable = sqlPrjUtils.paramDT

                dt_param.Rows.Add("@PackageNumber", PkgNum)
                dt_param.Rows.Add("@SystemMUID", SysID.ToString)
                dt_param.Rows.Add("@GroupMUID", GroupID.ToString)
                dt_param.Rows.Add("@OwnerMUID", OwnerID.ToString)
                dt_param.Rows.Add("@DisciplineMUID", DisciplineID.ToString)
                dt_param.Rows.Add("@MUID", pkgID.ToString)
                sqlPrjUtils.ExecuteNonQuery(qry, dt_param)


            End If
        Next
        sqlPrjUtils.CloseConnection()
        GridControl_GroupByAllPackages()
        Me.Cursor = Cursors.Default
        Me.Enabled = True

    End Sub
    Private Sub btnUpdatePackages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdatePackages.Click
        Dim View As ColumnView = GridControl1.FocusedView

        UpdateModifiedRecords()
        UpdateSelectedRecords()
        View.ClearSelection()
        tableModified = False
        MessageBox.Show("Selected Packages has been updated")
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show("Record may not be deleted")
    End Sub


    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        Dim View As ColumnView = GridControl1.FocusedView
        View.SelectAll()
    End Sub


    Private Sub DeletePackage(ByVal _PackageID As String, ByVal _Package As String)
        Dim query As String = "DELETE FROM package WHERE MUID = '" + _PackageID.ToString + "'"
        Try
            If VerifyPackageEmpty(_PackageID) Then
                'Utilities.ExecuteRemoteNonQuery(query, "")
                Dim sqlPrjUtils As DataUtils = New DataUtils("project")

                sqlPrjUtils.OpenConnection()
                Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
                sqlPrjUtils.CloseConnection()

                'need more cleanup


            Else
                MessageBox.Show("Package " + _Package + " contains tags and can not be deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Return
            End If

        Catch ex As Exception

            MessageBox.Show("There was a problem deleting the selected package.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function VerifyPackageEmpty(ByVal _PackageID As String) As Boolean
        Dim query As String = "SELECT * FROM tags WHERE PackageMUID = '" + _PackageID.ToString + "'"

        Try
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            sqlPrjUtils.CloseConnection()

            'dt = Utilities.ExecuteRemoteQuery(query, "")
            If dt Is Nothing Then
                Return True
            End If

            If dt.Rows.Count = 0 Then
                Return True
            End If

            Return False
        Catch ex As Exception

            MessageBox.Show("There was a problem deleting the selected package.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function


    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click

        If MessageBox.Show("Are you sure you want to delete the selected records?  This cannot be undone.", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
            Return
        End If

        Dim View As ColumnView = GridControl1.FocusedView
        For i As Integer = 0 To View.RowCount - 1
            If View.IsRowSelected(i) Then
                DeletePackage(View.GetRowCellValue(i, "MUID"), View.GetRowCellValue(i, "PackageNumber"))
            End If
        Next
        GridControl_GroupByAllPackages()

    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim View As ColumnView = GridControl1.MainView
        Dim Row As DataRow = View.GetDataRow(View.FocusedRowHandle)
        'Row.SetModified()
        tableModified = True
        If e.Column.FieldName = "PackageNumber" Then
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            Dim query As String = "SELECT * FROM package WHERE PackageNumber='" + Row("PackageNumber") + "'"
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            If dt.Rows.Count > 0 Then
                MessageBox.Show("Package Number already in use")
                'ValidateCellValue = False
                query = "SELECT PackageNumber FROM package WHERE MUID='" + Row("MUID") + "'"
                dt = sqlPrjUtils.ExecuteQuery(query)
                Row("PackageNumber") = dt.Rows(0)("PackageNumber")
                GridControl1.ForceInitialize()

            End If
            sqlPrjUtils.CloseConnection()
            Return
        End If
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()

        If e.Column.FieldName = "GroupID" Then
            Dim query As String = "SELECT MUID FROM groups WHERE Name ='" + Row("GroupID") + "'"
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
            Row("GroupMUID") = dt.Rows(0)("MUID")
        End If
        If e.Column.FieldName = "OwnerID" Then
            Dim query As String = "SELECT MUID FROM owner WHERE Name ='" + Row("OwnerID") + "'"
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
            Row("OwnerMUID") = dt.Rows(0)("MUID")
        End If
        If e.Column.FieldName = "DisciplineID" Then
            Dim query As String = "SELECT MUID FROM Discipline WHERE Name ='" + Row("DisciplineID") + "'"
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
            Row("DisciplineMUID") = dt.Rows(0)("MUID")
        End If
        sqlSrvUtils.CloseConnection()

    End Sub

    Private Sub PkgEdit_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If tableModified Then
            Dim ret As System.Windows.Forms.DialogResult = MessageBox.Show("Table entries have been modified; would you like to update records?", "Update Records", MessageBoxButtons.YesNo)
            If ret = Windows.Forms.DialogResult.No Then Return
            UpdateModifiedRecords()
        End If
    End Sub
End Class