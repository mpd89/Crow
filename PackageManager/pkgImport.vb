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



Public Class pkgImport
    Inherits System.Windows.Forms.Form

    Private GroupIDTbl As DataTable = New DataTable
    Private OwnerIDTbl As DataTable = New DataTable
    Private DisciplineIDTbl As DataTable = New DataTable
    Private sysCtrls As New List(Of Control)
    Private sysLblCtrls As New List(Of Control)
    Private ImportDataTable As DataTable
    Private FileLoadingComplete As Boolean = False

    Private labelObject As TextBox
    Private WithEvents FieldComboBox As System.Windows.Forms.ComboBox
    Private newLabelTop As Integer = 10

    Private auxHdrCboControls(60) As System.Windows.Forms.ComboBox
    Private PanelComboBox() As System.Windows.Forms.ComboBox
    Private PanellabelBox() As System.Windows.Forms.TextBox
    Private hdrFlds() As Integer

    Private UpdateCtr As Integer
    Private InsertCtr As Integer
    Private Panel1 As Panel
    Private Caption As String = "Import Tags"
    Private msgResult As DialogResult
    Private AuxFieldmapIDList As New List(Of ColumnMap)

    Private dgv1 As System.Windows.Forms.DataGridView
    Private CSVDataError As Boolean = False
    Private firstErrColumn As String = ""
    Private firstErrRow As Integer = -1
    Private firstErrMsg As String = ""


    Public Class ColumnMap
        Private _Num As String
        Private _Name As String
        Public Sub New(ByVal Num As String, ByVal Name As String)
            _Num = Num
            _Name = Name
        End Sub
        Public Property Num() As String
            Get
                Return _Num
            End Get
            Set(ByVal Num As String)
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

    End Class

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyClass.Load
        Try
            Me.btnCreateTemplate.Enabled = False
            Me.btnAuxUpload.Enabled = False

            'If runtime.ConnectionMode = "OFFLINE" Then
            '    MessageBox.Show("Can not import while System is offline")
            '    Me.Dispose()
            'End If
            'connSQLServer.Open()
            ReDim PanelComboBox(0)
            ReDim PanellabelBox(0)
            Panel1 = New System.Windows.Forms.Panel
            Panel1.AutoScroll = True
            Panel1.Location = New System.Drawing.Point(10, 50)
            Panel1.Size = New System.Drawing.Size(450, 270)

            Me.Size = New Size(1000, 700)

            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            sqlSrvUtils.OpenConnection()
            Dim query = " SELECT MUID,Name FROM groups ORDER BY Name"
            GroupIDTbl = sqlSrvUtils.ExecuteQuery(query)
            Me.cboDefaultGroupID.DataSource = GroupIDTbl
            Me.cboDefaultGroupID.DisplayMember = GroupIDTbl.Columns("Name").ToString
            Me.cboDefaultGroupID.ValueMember = GroupIDTbl.Columns("MUID").ToString
            Me.cboDefaultGroupID.SelectedItem = "Undefined"
            Dim Groupkeys(0) As DataColumn
            Groupkeys(0) = GroupIDTbl.Columns("Name")
            GroupIDTbl.PrimaryKey = Groupkeys


            query = " SELECT MUID,Name FROM owner ORDER BY Name"
            OwnerIDTbl = sqlSrvUtils.ExecuteQuery(query)
            Me.cboDefaultOwnerID.DataSource = OwnerIDTbl
            Me.cboDefaultOwnerID.DisplayMember = OwnerIDTbl.Columns("Name").ToString
            Me.cboDefaultOwnerID.ValueMember = OwnerIDTbl.Columns("MUID").ToString
            Me.cboDefaultOwnerID.SelectedItem = "Undefined"
            Dim Ownerkeys(0) As DataColumn
            Ownerkeys(0) = OwnerIDTbl.Columns("Name")
            OwnerIDTbl.PrimaryKey = Ownerkeys


            query = " SELECT MUID,Name FROM discipline  ORDER BY Name"
            DisciplineIDTbl = sqlSrvUtils.ExecuteQuery(query)
            Me.cboDefaultDisciplineID.DataSource = DisciplineIDTbl
            Me.cboDefaultDisciplineID.DisplayMember = DisciplineIDTbl.Columns("Name").ToString
            Me.cboDefaultDisciplineID.ValueMember = DisciplineIDTbl.Columns("MUID").ToString
            Me.cboDefaultDisciplineID.SelectedItem = "Undefined"
            Dim Disciplinekeys(0) As DataColumn
            Disciplinekeys(0) = DisciplineIDTbl.Columns("Name")
            DisciplineIDTbl.PrimaryKey = Disciplinekeys


            Me.cboAuxDiscID.DataSource = DisciplineIDTbl
            Me.cboAuxDiscID.DisplayMember = DisciplineIDTbl.Columns("Name").ToString
            Me.cboAuxDiscID.ValueMember = DisciplineIDTbl.Columns("MUID").ToString

            sqlSrvUtils.CloseConnection()

            dgv1 = New System.Windows.Forms.DataGridView
            dgv1.AllowUserToResizeColumns = True
            ckbAssignSystemColumns.Checked = False
            Me.Controls.Add(Panel1)
            Panel1.Visible = False
            AssignSystemColumns()

        Catch ex As Exception
            Utilities.logErrorMessage("PkgImport.Form1_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
        btnUploadPkgNums.Enabled = False
        Me.SplitContainer1.SplitterDistance = Me.TabControl1.Size.Height

    End Sub


    Private Sub PopulatecboTemplateName()
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim qry = "SELECT MUID,TemplateName FROM aux_template WHERE Type = 'Package'"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        If Not cboTemplateName.DataSource Is Nothing Then
            cboTemplateName.DataSource.Dispose()
        End If
        cboTemplateName.Enabled = False
        If dt.Rows.Count > 0 Then
            cboTemplateName.BeginUpdate()
            cboTemplateName.DataSource = dt
            cboTemplateName.DisplayMember = "TemplateName"
            cboTemplateName.ValueMember = "MUID"
            cboTemplateName.EndUpdate()
            cboTemplateName.Enabled = True
            cboTemplateName.SelectedIndex = 0
        End If
    End Sub


    Private Sub PopulateAuxFieldNames()
        If cboTemplateName.Enabled Then
            Dim id = cboTemplateName.SelectedValue
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim qry = "SELECT ColName,CustomName,MUID FROM aux_fieldmap WHERE TemplateMUID = '" + id.ToString + "'"
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()

            Dim match As Boolean = False
            If dt.Rows.Count > 0 Then
                NewlvwCSVFile.Items.Clear()
                NewlvwImportFields.Items.Clear()
                NewlvwCSVFile.MultiColumn = False
                NewlvwImportFields.MultiColumn = False
                NewlvwCSVFile.SelectionMode = SelectionMode.MultiExtended
                NewlvwImportFields.SelectionMode = SelectionMode.MultiExtended
                AuxFieldmapIDList.Clear()
                For j As Integer = 0 To dgv1.ColumnCount - 1
                    dgv1.Columns(j).HeaderCell.Style.BackColor = Color.White
                Next
                For i As Integer = 0 To dt.Rows.Count - 1
                    For j As Integer = 0 To dgv1.ColumnCount - 1
                        If dgv1.Columns(j).HeaderText = dt.Rows(i)("ColName") Then
                            match = True
                            dgv1.Columns(j).HeaderCell.Style.BackColor = Color.CadetBlue
                        End If
                    Next
                Next
                For i As Integer = 0 To dt.Rows.Count - 1
                    AuxFieldmapIDList.Add(New ColumnMap(dt.Rows(i)("MUID"), dt.Rows(i)(0)))
                    NewlvwCSVFile.Items.Add(dt.Rows(i)("ColName"))
                    NewlvwImportFields.Items.Add(dt.Rows(i)("ColName"))
                Next
                If Not match Then
                    MessageBox.Show("No matching column found, please load another template.")
                End If
            End If
        End If
    End Sub


    Private Function GetListOfColumnHeaders() As List(Of String)
        Dim myList As New List(Of String)
        myList.Add("")
        For i As Integer = 0 To dgv1.Columns.Count - 1
            myList.Add(dgv1.Columns(i).HeaderText)
        Next
        Return myList
    End Function


    Private Function PopulateColumnHeaderSelection() As Boolean
        For i As Integer = 0 To dgv1.Columns.Count - 1
            If dgv1.Columns(i).HeaderText = "" Then
                dgv1.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
                dgv1.Columns(i).HeaderCell.Style.BackColor = Color.Yellow
                MessageBox.Show("Blank Header Columns Found in the Import File")
                Return False
            End If
        Next
        For i As Integer = 0 To dgv1.Columns.Count - 1
            For j As Integer = i + 1 To dgv1.Columns.Count - 1
                If dgv1.Columns(i).HeaderText = dgv1.Columns(j).HeaderText Then
                    dgv1.Columns(i).DefaultCellStyle.BackColor = Color.Yellow
                    dgv1.Columns(j).DefaultCellStyle.BackColor = Color.Yellow
                    MessageBox.Show("Duplicate Columns Found in the Import File")
                    Return False
                End If
            Next
        Next

        Me.cboPkgNumber.DataSource = GetListOfColumnHeaders()
        Me.cboGroup.DataSource = GetListOfColumnHeaders()
        Me.cboDiscipline.DataSource = GetListOfColumnHeaders()
        Me.cboOwner.DataSource = GetListOfColumnHeaders()
        Me.cboDescription.DataSource = GetListOfColumnHeaders()
        Me.cbx_Priority.DataSource = GetListOfColumnHeaders()

        For Each ctrl As ComboBox In sysCtrls
            ctrl.DataSource = GetListOfColumnHeaders()
        Next

        Return True
    End Function


    Private Sub ImportCSVData()

        Dim CSVreader As CsvReader
        CSVreader = New CsvReader(Me.fileName.Text)

        Dim Ctr = 0
        Me.ToolStripProgressBar1.Maximum = 1000
        If Me.CheckBox1.Checked Then
            CSVreader.ReadRecord()
        End If

        While (CSVreader.ReadRecord())
            If CSVreader.ColumnCount <> ImportDataTable.Columns.Count Then
                Dim drr As Array = CSVreader.Values
                Dim dr As DataRow = ImportDataTable.NewRow
                If CSVreader.ColumnCount > ImportDataTable.Columns.Count Then
                    For i As Integer = 0 To ImportDataTable.Columns.Count - 1
                        dr(i) = drr(i)
                    Next
                Else
                    For i As Integer = 0 To drr.Length - 1
                        dr(i) = drr(i)
                    Next
                End If
                ImportDataTable.Rows.Add(dr)
            Else
                ImportDataTable.Rows.Add(CSVreader.Values)
            End If
            Me.ToolStripProgressBar1.Increment(1)
            Ctr = Ctr + 1
            If (Ctr Mod 100) = 0 Then
                Me.ToolStripTextBox1.Text = Ctr.ToString
                If (Ctr Mod 1000) = 0 Then
                    Me.ToolStripProgressBar1.Value = 0
                End If
                Me.Refresh()
            End If
        End While

        Me.ToolStripTextBox1.Text = Ctr.ToString
        Me.ToolStripProgressBar1.Value = Me.ToolStripProgressBar1.Maximum
        MessageBox.Show("File Import Completed")
        '    Me.btnImportCSV.Enabled = False
        Me.cboPkgNumber.Focus()
        CSVreader.Close()
        FileLoadingComplete = True
    End Sub


    Private Function ImportHeaders() As Boolean
        If Not dgv1 Is Nothing Then
            dgv1.Dispose()
        End If
        If Not ImportDataTable Is Nothing Then
            ImportDataTable.Dispose()
        End If
        ImportDataTable = New DataTable
        dgv1 = New DataGridView

        'dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        'dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        'dgv1.Location = New System.Drawing.Point(12, 458)
        'dgv1.Size = New System.Drawing.Size(956, 212)
        dgv1.AllowUserToAddRows = False
        dgv1.BringToFront()
        Me.SplitContainer1.Panel2.Controls.Add(dgv1)
        dgv1.Dock = DockStyle.Fill

        Dim CSVreader As CsvReader
        CSVreader = New CsvReader(Me.fileName.Text)
        If Me.CheckBox1.Checked Then
            CSVreader.ReadHeaders()
            For i As Integer = 0 To CSVreader.HeaderCount - 1
                Dim dc As DataColumn = New DataColumn
                dc.ColumnName = CSVreader.GetHeader(i)
                dc.DataType = System.Type.GetType("System.String")
                ImportDataTable.Columns.Add(dc)
            Next
        Else
            CSVreader.ReadRecord()
            For i As Integer = 0 To CSVreader.ColumnCount - 1
                Dim dc As DataColumn = New DataColumn
                dc.ColumnName = "Column" + (i + 1).ToString
                dc.DataType = System.Type.GetType("System.String")
                ImportDataTable.Columns.Add(dc)
            Next
        End If

        Me.BindingSource1.DataSource = ImportDataTable
        dgv1.DataSource = Me.BindingSource1
        dgv1.Dock = DockStyle.Fill
        Me.BindingNavigator1.Dock = DockStyle.Bottom
        If Not PopulateColumnHeaderSelection() Then
            Return False
        End If
        CSVreader.Close()
        Me.btnCreateTemplate.Enabled = True
        Me.btnAuxUpload.Enabled = True
        Return False

    End Function
    Private Sub AssignSystemColumns()
        Dim mytop As Point = Me.ckbAssignSystemColumns.Location
        For i As Integer = 0 To Utilities.CountTiers() - 1
            Dim ctrl As Control = New ComboBox
            ctrl.Location = New Point(mytop.X, mytop.Y + (i * 25) + 20)
            Dim lbl As Control = New Label
            lbl.Text = "Tier" + (i + 1).ToString + ": " + SystemManager.SystemDataManager.GetTierDescription(i + 1)
            lbl.Location = New Point(ctrl.Location.X + ctrl.Width + 10, ctrl.Location.Y)
            sysCtrls.Add(ctrl)
            sysLblCtrls.Add(lbl)
            Me.TabControl1.TabPages(0).Controls.Add(ctrl)
            Me.TabControl1.TabPages(0).Controls.Add(lbl)
        Next
        For i As Integer = 0 To sysCtrls.Count - 1
            CType(sysCtrls(i), ComboBox).Visible = False
            CType(sysLblCtrls(i), Label).Visible = False
        Next
    End Sub




    Private Function GetTierID(ByVal rowNo As Integer) As String
        If Me.ckbAssignSystemColumns.Checked = False Then
            Return "Undefined"
        End If

        Dim SysID As String = ""
        Dim MyParent As String = "0"

        Dim u As Integer = 1
        For Each sys As ComboBox In sysCtrls
            If sys.SelectedIndex >= 0 Then
                'SysID = SysID + SystemManager.SystemDataManager.GetSystemID(dgv1.Rows(rowNo).Cells(sys.SelectedItem).Value, ) + ";"
                'ParentID = SystemManager.SystemDataManager.GetSystemID(dgv1.Rows(rowNo).Cells(sys.SelectedItem).Value)
                If SystemManager.SystemDataManager.HasParent(u) Then
                    SysID = SysID + SystemManager.SystemDataManager.GetSystemID(dgv1.Rows(rowNo).Cells(sys.SelectedItem).Value, MyParent) + ";"
                    MyParent = SystemManager.SystemDataManager.GetSystemID(dgv1.Rows(rowNo).Cells(sys.SelectedItem).Value, MyParent)
                Else
                    SysID = SysID + SystemManager.SystemDataManager.GetSystemID(dgv1.Rows(rowNo).Cells(sys.SelectedItem).Value, False, u.ToString) + ";"
                    MyParent = SystemManager.SystemDataManager.GetSystemID(dgv1.Rows(rowNo).Cells(sys.SelectedItem).Value, False, u.ToString)
                End If
            End If
            u = u + 1
        Next
        If SysID > "" Then
            SysID = SysID.Remove(SysID.Length - 1, 1) ' remove the last ';'
            If (SystemManager.SystemDataManager.SystemValidate(SysID)) Then
                Return SysID
            End If
        End If
        Return "Undefined"
    End Function


    Private Sub InsertNewPackageNumbersUsingParameter()

        Dim qry As String = ""
        Dim Ctr As Integer = 0
        UpdateCtr = 0
        InsertCtr = 0
        Dim processCtr As Integer = 0
        Me.ToolStripProgressBar1.Maximum = dgv1.Rows.Count - 2
        Me.ToolStripProgressBar1.Value = 0
        msgResult = System.Windows.Forms.DialogResult.OK

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()
        Try
            Dim Ignore As Boolean = False
            For i As Integer = 0 To dgv1.Rows.Count - 1
                Ctr = Ctr + 1
                Dim pkgNum As String = dgv1.Rows(i).Cells(Me.cboPkgNumber.SelectedItem).Value
                Dim errMsg = ""

                Dim GroupID As String = Me.cboDefaultGroupID.SelectedValue
                If Me.cboGroup.SelectedIndex > 0 Then
                    Dim foundRow As DataRow = GroupIDTbl.Rows.Find(dgv1.Rows(i).Cells(Me.cboGroup.SelectedItem).Value.ToString)
                    GroupID = foundRow("MUID")
                End If

                Dim OwnerID As String = Me.cboDefaultOwnerID.SelectedValue
                If Me.cboOwner.SelectedIndex > 0 Then
                    Dim foundRow As DataRow = OwnerIDTbl.Rows.Find(dgv1.Rows(i).Cells(Me.cboOwner.SelectedItem).Value.ToString)
                    OwnerID = foundRow("MUID")
                End If

                Dim DisciplineID As String = Me.cboDefaultDisciplineID.SelectedValue
                If Me.cboDiscipline.SelectedIndex > 0 Then
                    Dim foundRow As DataRow = DisciplineIDTbl.Rows.Find(dgv1.Rows(i).Cells(Me.cboDiscipline.SelectedItem).Value.ToString)
                    DisciplineID = foundRow("MUID")
                End If

                Dim Description As String = ""
                If Me.cboDescription.Text > "" Then
                    Description = dgv1.Rows(i).Cells(Me.cboDescription.SelectedItem).Value
                End If
                Dim dt_param As DataTable = sqlPrjUtils.paramDT

                Dim Priority As String = "0"
                If Me.cbx_Priority.Text > "" Then
                    Priority = dgv1.Rows(i).Cells(Me.cbx_Priority.SelectedItem).Value
                End If

                dt_param.Rows.Add("@PackageNumber", pkgNum)
                dt_param.Rows.Add("@TS", DateAndTime.Now.ToString)
                dt_param.Rows.Add("@SystemMUID", GetTierID(i))
                dt_param.Rows.Add("@Description", Description)
                dt_param.Rows.Add("@GroupMUID", GroupID.ToString)
                dt_param.Rows.Add("@OwnerMUID", OwnerID.ToString)
                dt_param.Rows.Add("@DisciplineMUID", DisciplineID.ToString)
                dt_param.Rows.Add("@Priority", Priority.ToString)

                qry = " SELECT MUID FROM package WHERE (packageNumber = '" + pkgNum + "')"
                Dim dtt As DataTable = sqlPrjUtils.ExecuteQuery(qry) 'cmdCheck.sqlParamValue("@PackageNumber") = pkgNum
                Dim muid As String = ""
                If dtt.Rows.Count > 0 Then
                    muid = dtt.Rows(0)("MUID") 'cmdCheck.ExecuteParameterScalar()
                    qry = " UPDATE package SET " + _
                             " TS = @TS," + _
                             " PackageNumber = @PackageNumber," + _
                             " SystemMUID = @SystemMUID," + _
                             " Description = @Description," + _
                             " GroupMUID = @GroupMUID," + _
                             " OwnerMUID = @OwnerMUID," + _
                             " DisciplineMUID = @DisciplineMUID, " + _
                             " Aux09 = @Priority " + _
                             " WHERE MUID = @MUID"

                    dt_param.Rows.Add("@MUID", muid)

                    UpdateCtr = UpdateCtr + 1
                Else
                    qry = " INSERT INTO package " + _
                     "(MUID, PackageNumber, TS,SystemMUID, Description, GroupMUID,OwnerMUID,DisciplineMUID,Aux09) " + _
                     " VALUES (@MUID, @PackageNumber, @TS,@SystemMUID, @Description, @GroupMUID,@OwnerMUID,@DisciplineMUID,@Priority) "

                    dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "package"))

                    InsertCtr = InsertCtr + 1
                End If
                sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                processCtr = processCtr + 1
                If (Ctr Mod 100) = 0 Then
                    Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", Ctr.ToString, dgv1.Rows.Count - 2)
                    Me.ToolStripProgressBar1.Increment(100)
                    Me.Refresh()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        sqlPrjUtils.CloseConnection()
        Me.ToolStripProgressBar1.Value = Me.ToolStripProgressBar1.Maximum
        MessageBox.Show("Total Rows: " + Ctr.ToString + ", Packages processed: " + processCtr.ToString + _
                ", New Packages Added: " + InsertCtr.ToString + ", Packages Updated: " + UpdateCtr.ToString)

    End Sub


    Private Function VerifyHdrFields() As Boolean
        If NewlvwImportFields.Items.Count <= 0 Then
            MessageBox.Show("Please select valid Aux Template")
            Return 0
        End If
        For i As Integer = 0 To NewlvwImportFields.Items.Count - 1
            Dim name As String = ""
            For j As Integer = 0 To dgv1.Columns.Count - 1
                If NewlvwImportFields.Items(i) = dgv1.Columns(j).Name Then
                    name = NewlvwImportFields.Items(i)
                    Exit For
                End If
            Next
            If name = "" Then
                MessageBox.Show("Template header name: '" + NewlvwImportFields.Items(i) + "' not found in CSV file")
                Return False
            End If
        Next
        Return True
    End Function



    'Private Function SelectHdrFields() As Integer
    '    Dim cmdCheck As SqlCommand = connSQLServer.CreateCommand()
    '    Dim auxDispID As Integer = Me.cboAuxDiscID.SelectedValue
    '    Dim ValidColumns As Integer = 0
    '    cmdCheck.CommandText = useProjectDB + " SELECT auxHeader FROM aux_fieldmap " + _
    '                "WHERE (mainTable = 'package') AND (auxField = " + auxDispID.ToString + ")"
    '    Dim auxHeader = Convert.ToString(cmdCheck.ExecuteScalar())
    '    ReDim hdrFlds(0)
    '    If auxHeader > "" Then
    '        For i As Integer = 0 To PanelComboBox.Length - 2
    '            If PanelComboBox(i).SelectedIndex >= 0 Then
    '                hdrFlds(i) = PanelComboBox(i).SelectedValue
    '                ReDim Preserve hdrFlds(UBound(hdrFlds) + 1)
    '            Else
    '                hdrFlds(i) = -1
    '                ReDim Preserve hdrFlds(UBound(hdrFlds) + 1)
    '            End If
    '        Next
    '        For i As Integer = 0 To PanelComboBox.Length - 2
    '            Dim ColumnNum As Integer = hdrFlds(i)
    '            If ColumnNum >= 0 Then
    '                For j As Integer = i + 1 To PanelComboBox.Length - 2
    '                    If ColumnNum = hdrFlds(j) Then
    '                        MessageBox.Show("Duplicate Column mapping found")
    '                        PanelComboBox(i).BackColor = Color.Yellow
    '                        PanelComboBox(j).BackColor = Color.Yellow
    '                        Return 0
    '                    End If
    '                Next
    '                ValidColumns = ValidColumns + 1
    '            End If
    '        Next
    '    Else
    '        If NewlvwImportFields.Items.Count <= 0 Then
    '            MessageBox.Show("Please select Column Headers")
    '            Return 0
    '        End If
    '        For i As Integer = 0 To NewlvwImportFields.Items.Count - 1
    '            Dim name As String = NewlvwImportFields.Items(i)
    '            For j As Integer = 0 To dgv1.Columns.Count - 1
    '                If name = dgv1.Columns(j).Name Then
    '                    hdrFlds(i) = j
    '                    ReDim Preserve hdrFlds(UBound(hdrFlds) + 1)
    '                End If
    '            Next
    '            Dim search As Integer = 1
    '            While InStr(search, name, "'")
    '                search = InStr(search, name, "'")
    '                name = name.Insert(search, "'")
    '                search = search + 2
    '            End While
    '            auxHeader = auxHeader + name + "&001"
    '        Next
    '        Dim cmdHdrInsert As SqlCommand = connSQLServer.CreateCommand()
    '        cmdHdrInsert.CommandText = useProjectDB + " INSERT INTO aux_fieldmap " + _
    '                            "(mainTable,auxField,auxHeader) VALUES " + _
    '                            "('package'," + auxDispID.ToString + ",'" + auxHeader + "')"
    '        Convert.ToString(cmdHdrInsert.ExecuteScalar())
    '        ValidColumns = hdrFlds.Length - 1
    '    End If
    '    If ValidColumns <= 0 Then
    '        MessageBox.Show("Please select Column Headers")
    '    End If
    '    Return (ValidColumns)
    'End Function


    'Private Sub InsertAuxPkgInfo()

    '    Dim DisciplineID = Me.cboAuxDiscID.SelectedValue
    '    Dim cmdInsert As SqlCommand = connSQLServer.CreateCommand()
    '    cmdInsert.CommandText = useProjectDB + " INSERT INTO aux_package " + _
    '                "(PackageID,auxData) VALUES (@PackageID,@auxData)"
    '    cmdInsert.Parameters.Add("@PackageID", SqlDbType.Int)
    '    cmdInsert.Parameters.Add("@auxData", SqlDbType.VarChar)


    '    Dim cmdUpdate As SqlCommand = connSQLServer.CreateCommand()
    '    cmdUpdate.CommandText = useProjectDB + " UPDATE aux_package SET " + _
    '                "auxData = @auxData WHERE auxID = @auxID"
    '    cmdUpdate.Parameters.Add("@auxData", SqlDbType.VarChar)
    '    cmdUpdate.Parameters.Add("@auxid", SqlDbType.Int)

    '    Dim cmdPkgID As SqlCommand = connSQLServer.CreateCommand()
    '    cmdPkgID.CommandText = useProjectDB + " SELECT PackageID FROM package WHERE PackageNumber = @PackageNumber " + _
    '                                        " AND DisciplineID = " + DisciplineID.ToString
    '    cmdPkgID.Parameters.Add("@PackageNumber", SqlDbType.VarChar)

    '    Dim cmdAuxID As SqlCommand = connSQLServer.CreateCommand()
    '    cmdAuxID.CommandText = useProjectDB + " SELECT auxID FROM aux_package " + _
    '                        " WHERE PackageID = @PackageID"
    '    cmdAuxID.Parameters.Add("@PackageID", SqlDbType.Int)



    '    Me.ToolStripProgressBar1.Maximum = dgv1.Rows.Count - 2
    '    Me.ToolStripProgressBar1.Value = 0
    '    UpdateCtr = 0
    '    InsertCtr = 0
    '    Dim Row As Integer
    '    For Row = 0 To dgv1.Rows.Count - 1
    '        Dim pkgNum As String = dgv1.Rows(Row).Cells(Me.cboAuxPkgNum.SelectedIndex).Value
    '        If pkgNum > "" Then
    '            cmdPkgID.Parameters("@PackageNumber").Value = pkgNum

    '            Dim pkgID = Convert.ToInt32(cmdPkgID.ExecuteScalar())
    '            If pkgID > 0 Then
    '                Dim auxData As String = ""
    '                For j As Integer = 0 To hdrFlds.Length - 2
    '                    If hdrFlds(j) > 0 Then
    '                        auxData = auxData + dgv1.Rows(Row).Cells(hdrFlds(j)).Value + "&001"
    '                    Else
    '                        auxData = auxData + "&001"
    '                    End If
    '                Next
    '                cmdAuxID.Parameters("@PackageID").Value = pkgID
    '                Dim auxID = Convert.ToInt32(cmdAuxID.ExecuteScalar())
    '                If auxID > 0 Then
    '                    cmdUpdate.Parameters("@auxID").Value = auxID
    '                    cmdUpdate.Parameters("@auxData").Value = auxData
    '                    Convert.ToInt32(cmdUpdate.ExecuteScalar())
    '                    UpdateCtr = UpdateCtr + 1
    '                Else
    '                    cmdInsert.Parameters("@auxData").Value = auxData
    '                    cmdInsert.Parameters("@PackageID").Value = pkgID
    '                    Convert.ToInt32(cmdInsert.ExecuteScalar())
    '                    InsertCtr = InsertCtr + 1
    '                End If
    '            End If
    '        End If
    '        If (Row Mod 100) = 0 Then
    '            Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", Row.ToString, dgv1.Rows.Count - 1)
    '            Me.ToolStripProgressBar1.Increment(100)
    '            Me.ToolStripProgressBar1.Invalidate()
    '            Me.Refresh()
    '        End If
    '    Next
    '    Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", (Row - 1), dgv1.Rows.Count - 1)
    '    Me.ToolStripProgressBar1.Value = Me.ToolStripProgressBar1.Maximum
    '    MessageBox.Show("Total Rows: " + Row.ToString + ", New Tags Added: " + InsertCtr.ToString + _
    '                    ", Tags Updated: " + UpdateCtr.ToString)
    'End Sub
    Private Sub InsertAuxData()

    End Sub
    Private Sub InsertAuxPkgInfo()
        Dim Ctr As Integer = 0
        Dim UpdateCtr As Integer = 0
        Dim InsertCtr As Integer = 0
        Dim processCtr As Integer = 0
        Dim TemplateID As String = Me.cboTemplateName.SelectedValue
        If TemplateID <= "" Then
            MessageBox.Show("Please select a Template")
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.ToolStripProgressBar1.Maximum = 10
        Me.ToolStripProgressBar1.Value = 0

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim Row As Integer
        For Row = 0 To dgv1.Rows.Count - 1
            Dim pkgNum As String = dgv1.Rows(Row).Cells(Me.cboPkgNumber.SelectedItem).Value
            If pkgNum > "" Then
                'pkgNum = dgv1.Rows(Row).Cells(Me.cboPkgNumber.SelectedItem).Value
                Dim qry = " SELECT MUID FROM package WHERE PackageNumber = '" + pkgNum + "'"
                'Dim dt As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
                Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)


                Dim pkgID As String = ""
                If dt.Rows.Count > 0 Then
                    pkgID = dt.Rows(0)("MUID")
                End If
                If pkgID > "" Then
                    For j As Integer = 0 To AuxFieldmapIDList.Count - 1
                        Dim fldName = AuxFieldmapIDList(j).Name
                        Dim fldMapID = AuxFieldmapIDList(j).Num
                        Dim matchingColumn As Integer = -1
                        For k As Integer = 0 To dgv1.Columns.Count - 1
                            If fldName = dgv1.Columns(k).Name Then
                                matchingColumn = k
                                Exit For
                            End If
                        Next
                        If matchingColumn >= 0 Then
                            Dim fldValue As String

                            If Not IsDBNull(dgv1.Rows(Row).Cells(fldName).Value()) Then
                                fldValue = dgv1.Rows(Row).Cells(fldName).Value()
                            Else
                                fldValue = ""
                            End If
                            qry = "SELECT MUID FROM aux_package WHERE FieldmapMUID = '" + fldMapID.ToString + "'" + _
                                    " AND PackageMUID = '" + pkgID.ToString + "'"
                            Dim dt3 As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                            'Dim dt3 As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
                            Dim auxID As String = ""
                            If dt3.Rows.Count > 0 Then
                                auxID = dt3.Rows(0)("MUID")
                            End If
                            Dim dt_param As DataTable = sqlPrjUtils.paramDT
                            If auxID > "" Then
                                'qry = " UPDATE aux_package SET auxData = '" + fldValue + "'" + _
                                '            " WHERE MUID = " + auxID.ToString
                                qry = " UPDATE aux_package SET auxData = @auxData WHERE MUID = @MUID"

                                dt_param.Rows.Add("@auxData", fldValue)
                                dt_param.Rows.Add("@MUID", auxID.ToString)
                                sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                            Else
                                auxID = idUtils.GetNextMUID("project", "aux_package")
                                'qry = " INSERT INTO aux_package " + _
                                '            "(MUID,FieldmapID,PackageID,auxData) VALUES (" + _
                                '            "'" + auxID + "'," + _
                                '            "'" + fldMapID.ToString + "'," + _
                                '            "'" + pkgID.ToString + ",'" + _
                                '            "'" + fldValue.ToString + "')"
                                qry = " INSERT INTO aux_package " + _
                                            "(MUID,FieldmapMUID,PackageMUID,auxData) VALUES (" + _
                                            "@MUID,@FieldmapMUID,@PackageMUID,@auxData)"
                                Dim muid = idUtils.GetNextMUID("project", "aux_package")
                                dt_param.Rows.Add("@MUID", muid)
                                dt_param.Rows.Add("@FieldMapMUID", fldMapID.ToString)
                                dt_param.Rows.Add("@PackageMUID", pkgID.ToString)
                                dt_param.Rows.Add("@auxData", fldValue)
                                sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                            End If
                            'Utilities.ExecuteRemoteNonQuery(qry, "")
                        End If
                    Next
                    InsertCtr = InsertCtr + 1
                End If
            End If
            Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", Row.ToString, dgv1.Rows.Count - 1)
            Me.ToolStripProgressBar1.Increment(1)
            If Me.ToolStripProgressBar1.Value >= 10 Then
                Me.ToolStripProgressBar1.Value = 0
            End If

            'Me.ToolStripProgressBar1.Invalidate()
            'Me.Refresh()
        Next
        Me.Cursor = Cursors.Default
        Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", (Row - 1), dgv1.Rows.Count - 1)
        Me.ToolStripProgressBar1.Value = Me.ToolStripProgressBar1.Maximum
        MessageBox.Show("Total rows: " + Row.ToString + ", total Pkgs processed: " + InsertCtr.ToString)
        sqlPrjUtils.CloseConnection()

    End Sub

    Private Function CheckDupliacteAuxTemplate() As Boolean
        Dim rt As Boolean = False
        Dim TemplateID As String = Me.cboTemplateName.SelectedValue
        Dim auxPkgID As New ArrayList
        Dim qry As String = ""
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()

        For Row As Integer = 0 To dgv1.Rows.Count - 1
            dgv1.Rows(Row).DefaultCellStyle.BackColor = Color.White
            Dim pkgNum As String = dgv1.Rows(Row).Cells(Me.cboPkgNumber.SelectedItem).Value
            If pkgNum > "" Then
                qry = " SELECT MUID FROM package WHERE PackageNumber = '" + pkgNum + "'"
                'Dim dt As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
                Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)

                Dim pkgID As String = ""
                If dt.Rows.Count > 0 Then
                    pkgID = dt.Rows(0)("MUID")
                End If
                If pkgID > "" Then
                    qry = " SELECT TemplateMUID FROM aux_template_assoc " + _
                                "WHERE AssocMUID = '" + pkgID.ToString + "' AND SourceMUID = 'Package' "
                    'Dim dt2 As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
                    Dim dt2 As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                    If dt2.Rows.Count > 0 Then
                        If dt2.Rows(0)("TemplateMUID") <> TemplateID Then
                            dgv1.Rows(Row).DefaultCellStyle.BackColor = Me.tbx_Duplicate.BackColor
                            rt = True
                        End If
                    End If
                    auxPkgID.Add(pkgID)
                End If
            End If
        Next

        If rt Then
            MessageBox.Show("The package has already been assigned to another Template ")
            sqlPrjUtils.CloseConnection()
            Return rt
        End If
        For Each pkgID As String In auxPkgID
            qry = " SELECT MUID FROM aux_template_assoc " + _
                                    "WHERE AssocMUID = '" + pkgID.ToString + "' AND SourceMUID = 'Package' "
            Dim dt2 As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            If dt2.Rows.Count = 0 Then
                Dim muid As String = idUtils.GetNextMUID("project", "aux_template_assoc")
                qry = " INSERT INTO aux_template_assoc " + _
                            "(MUID,TemplateMUID,AssocMUID,SourceMUID) VALUES (" + _
                            "@MUID,@TemplateMUID,@AssocMUID,@SourceMUID)"
                Dim dt_param As DataTable = sqlPrjUtils.paramDT
                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "aux_template_assoc"))
                dt_param.Rows.Add("@TemplateMUID", TemplateID.ToString)
                dt_param.Rows.Add("@AssocMUID", pkgID.ToString)
                dt_param.Rows.Add("@SourceMUID", "Package")

                sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
            End If
        Next
        sqlPrjUtils.CloseConnection()
        Return rt

    End Function


    Private Sub btnUploadPkgNums_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadPkgNums.Click
        If ErrorCheck() Then
            MessageBox.Show("Please perform error check")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False
        InsertNewPackageNumbersUsingParameter()


        Me.Enabled = True
        Me.Cursor = Cursors.Default

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnImportCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportCSV.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory
        openFileDialog1.Filter = "CSV files (*.csv)|*.csv"
        openFileDialog1.FilterIndex = 1

        If openFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return

        Me.fileName.Visible = True
        Me.fileName.Text = openFileDialog1.FileName

        ImportHeaders()
        '        Me.TabPage2.Controls.Add(Panel1)

        ImportCSVData()
        PopulatecboTemplateName()
        If cboTemplateName.Items.Count > 0 Then
            PopulateAuxFieldNames()
            cboTemplateName.SelectedIndex = 0
        End If


    End Sub


    Private Sub cboAuxDiscID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAuxDiscID.SelectedIndexChanged
        If cboAuxDiscID.SelectedIndex >= 0 Then
            'UpdateAuxColumnHeaderMapping()
        End If
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Name = "TabPage2" Then
            'UpdateAuxColumnHeaderMapping()
        End If
    End Sub


    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        Me.Dispose()
    End Sub


    Private Sub btnAuxUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuxUpload.Click
        CSVDataError = False
        If Me.fileName.Text = "" Then
            MessageBox.Show("Missing File name")
            Return
        End If
        If Me.cboPkgNumber.Text <= "" Then
            MessageBox.Show("Missing 'Package Number' field map")
            Return
        End If
        If CheckValidPackageValues() Then
        End If

        If CSVDataError Then
            Me.lbl_error0.ForeColor = Color.Red
            Me.lbl_error0.Text = firstErrMsg
            msgResult = MessageBox.Show(firstErrMsg + firstErrRow.ToString, Caption, MessageBoxButtons.OK)
            Return
        End If


        If Not VerifyHdrFields() Then
            Return
        End If
        If CheckDupliacteAuxTemplate() Then
            Return
        End If
        InsertAuxPkgInfo()
    End Sub




    Private Sub btnCreateTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateTemplate.Click
        If fileName.Text = "" Then
            MessageBox.Show("Please select CSV file name")
            Return
        End If
        Dim fm As Form = New pkgAuxTemplate("Package", Me.fileName.Text)
        fm.ShowDialog()
        PopulatecboTemplateName()
        If cboTemplateName.Items.Count > 0 Then
            PopulateAuxFieldNames()
            cboTemplateName.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboTemplateName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTemplateName.SelectedIndexChanged
        PopulateAuxFieldNames()
    End Sub
    Private Sub ckbAssignSystemColumns_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbAssignSystemColumns.CheckStateChanged
        If ckbAssignSystemColumns.Checked Then
            For i As Integer = 0 To sysCtrls.Count - 1
                CType(sysCtrls(i), ComboBox).Visible = True
                CType(sysCtrls(i), ComboBox).DropDownStyle = ComboBoxStyle.DropDownList
                CType(sysLblCtrls(i), Label).Visible = True
            Next
        Else
            For i As Integer = 0 To sysCtrls.Count - 1
                CType(sysCtrls(i), ComboBox).Visible = False
                CType(sysCtrls(i), ComboBox).DropDownStyle = ComboBoxStyle.DropDownList
                CType(sysLblCtrls(i), Label).Visible = False
            Next
        End If
    End Sub

    Private Function CheckValidSystemNumber() As Integer
        If Me.ckbAssignSystemColumns.Checked = False Then Return False
        Dim selectedComboBox As Integer = 0
        For Each sys As ComboBox In sysCtrls
            If sys.SelectedIndex >= 0 Then
                selectedComboBox = selectedComboBox + 1
            End If
        Next
        If selectedComboBox = 0 Then Return False
        Dim ColumnNum As Integer = Me.cboPkgNumber.SelectedIndex
        For i As Integer = 0 To dgv1.Rows.Count - 1
            Dim SysID As String = ""
            Dim u As Integer = 1
            Dim MyParent As String = 0
            For Each sys As ComboBox In sysCtrls

                If i = 280 Then
                    Dim hold As String = Nothing
                End If
                If sys.SelectedItem > "" Then
                    If SystemManager.SystemDataManager.HasParent(u) Then
                        SysID = SysID + SystemManager.SystemDataManager.GetSystemID(dgv1.Rows(i).Cells(sys.SelectedItem).Value, MyParent) + ";"
                        MyParent = SystemManager.SystemDataManager.GetSystemID(dgv1.Rows(i).Cells(sys.SelectedItem).Value, MyParent)
                    Else
                        SysID = SysID + SystemManager.SystemDataManager.GetSystemID(dgv1.Rows(i).Cells(sys.SelectedItem).Value, False, u.ToString) + ";"
                        MyParent = SystemManager.SystemDataManager.GetSystemID(dgv1.Rows(i).Cells(sys.SelectedItem).Value, False, u.ToString)
                    End If
                End If
                u += 1
            Next
            If SysID > "" Then
                SysID = SysID.Remove(SysID.Length - 1, 1) ' remove the last ';'
                If Not (SystemManager.SystemDataManager.SystemValidate(SysID)) Then
                    'dgv1.Columns(i).DefaultCellStyle.BackColor = Me.tbx_ColorInvalid.BackColor
                    'If msgResult = Windows.Forms.DialogResult.Ignore Then Return False
                    Dim msg = "Invalid System Number in Row:" + (i + 1).ToString
                    msgResult = MessageBox.Show(msg, Caption, MessageBoxButtons.OK)
                    Me.lbl_error0.Text = msg
                    Me.lbl_error0.ForeColor = Color.Red
                    Return i
                End If
            End If
        Next

        Return -1
    End Function
    Private Function CheckValidPackageValues() As Boolean
        dgv1.ClearSelection()
        For i As Integer = 0 To dgv1.Rows.Count - 1
            dgv1.Rows(i).DefaultCellStyle.BackColor = Color.White
            'Check for duplicate/balnk Pkg Numbers
            Dim ColumnNum As String = Me.cboPkgNumber.Text
            Dim Name As String = dgv1.Rows(i).Cells(ColumnNum).Value.ToString
            dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Color.White
            Dim rt As Boolean = False
            Dim msg As String = ""
            If Strings.LTrim(Name) = "" Then
                dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorBlank.BackColor
                'dgv1.Columns(i).DefaultCellStyle.BackColor = Me.tbx_ColorBlank.BackColor
                If FirsterrRow < 0 Then
                    FirsterrRow = i
                    CSVDataError = True
                    firstErrMsg = "Blank Pkg numbers in the CSV File: Row#:" + i.ToString
                End If
            Else
                For j As Integer = i + 1 To dgv1.Rows.Count - 1
                    If Name = (dgv1.Rows(j).Cells(ColumnNum).Value).ToString Then
                        dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_Duplicate.BackColor
                        dgv1.Rows(j).Cells(ColumnNum).Style.BackColor = Me.tbx_Duplicate.BackColor
                        rt = True
                    End If
                Next
                If rt Then
                    If FirsterrRow < 0 Then
                        FirsterrRow = i
                        CSVDataError = True
                        firstErrMsg = "Duplicate Pkg numbers in the CSV File"
                    End If
                End If
            End If
        Next
        Return CSVDataError
    End Function
    Private Function ErrorCheck() As Boolean
        dgv1.ClearSelection()
        firstErrColumn = ""
        FirsterrRow = -1
        firstErrMsg = ""
        Me.lbl_error0.Text = ""
        Me.lbl_error0.Visible = True
        Me.btnUploadPkgNums.Enabled = False
        dgv1.ClearSelection()
        CSVDataError = False

        If Me.fileName.Text = "" Then
            MessageBox.Show("Missing File name")
            Return True
        End If
        If Me.cboPkgNumber.Text = "" Then
            MessageBox.Show("Missing the mapping of the 'Packge Number' field")
            Return True
        End If


        Me.Cursor = Cursors.Default
        Me.Enabled = True
        If ckbAssignSystemColumns.Checked Then
            Dim errRow As Integer = CheckValidSystemNumber()
            If errRow >= 0 Then
                Return True
            End If
        End If


        CheckValidPackageValues()



        For i As Integer = 0 To dgv1.Rows.Count - 1

            'Check for duplicate/balnk Pkg Numbers
            Dim ColumnNum As String = ""
            ColumnNum = Me.cboDiscipline.Text
            If Me.cboDiscipline.Text > "" Then
                dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Color.White
                Name = dgv1.Rows(i).Cells(ColumnNum).Value.ToString
                If Name = "" Then
                    dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorBlank.BackColor
                    If firstErrRow < 0 Then
                        firstErrRow = i
                        CSVDataError = True
                        firstErrMsg = "Blank Discipline value in Row#:" + i.ToString
                    End If
                Else
                    Dim foundRow As DataRow = DisciplineIDTbl.Rows.Find(dgv1.Rows(i).Cells(Me.cboDiscipline.SelectedItem).Value.ToString)
                    If foundRow Is Nothing Then
                        dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorInvalid.BackColor
                        If firstErrRow < 0 Then
                            firstErrRow = i
                            CSVDataError = True
                            firstErrMsg = "Invalid Discipline value in Row#:" + i.ToString
                        End If
                    End If

                End If
            End If

            ColumnNum = Me.cboGroup.Text
            If Me.cboGroup.Text > "" Then
                dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Color.White
                Name = dgv1.Rows(i).Cells(ColumnNum).Value.ToString
                If Name = "" Then
                    dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorBlank.BackColor
                    If firstErrRow < 0 Then
                        firstErrRow = i
                        CSVDataError = True
                        firstErrMsg = "Blank Group value in Row#:" + i.ToString
                    End If
                Else
                    Dim foundRow As DataRow = GroupIDTbl.Rows.Find(dgv1.Rows(i).Cells(Me.cboGroup.SelectedItem).Value.ToString)
                    If foundRow Is Nothing Then
                        dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorInvalid.BackColor
                        If firstErrRow < 0 Then
                            firstErrRow = i
                            CSVDataError = True
                            firstErrMsg = "Invalid Group value in Row#:" + i.ToString
                        End If
                    End If
                End If
            End If

            ColumnNum = Me.cboOwner.Text
            If Me.cboOwner.Text > "" Then
                dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Color.White
                Name = dgv1.Rows(i).Cells(ColumnNum).Value.ToString
                If Strings.LTrim(Name) = "" Then
                    dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorBlank.BackColor
                    If firstErrRow < 0 Then
                        firstErrRow = i
                        CSVDataError = True
                        firstErrMsg = "Blank Owner value in Row#:" + i.ToString
                    End If
                Else
                    Dim foundRow As DataRow = OwnerIDTbl.Rows.Find(dgv1.Rows(i).Cells(Me.cboOwner.SelectedItem).Value.ToString)
                    If foundRow Is Nothing Then
                        dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorInvalid.BackColor
                        If firstErrRow < 0 Then
                            firstErrRow = i
                            CSVDataError = True
                            firstErrMsg = "Invalid Owner value in Row#:" + i.ToString
                        End If
                    End If
                End If
            End If
        Next
       
        'If CSVDataError Then
        '    Me.lbl_error0.ForeColor = Color.Red
        '    Me.lbl_error0.Text = firstErrMsg
        '    msgResult = MessageBox.Show(firstErrMsg + firstErrRow, Caption, MessageBoxButtons.OK)
        'Else
        '    Me.lbl_error0.Text = "No error found"
        '    Me.lbl_error0.ForeColor = Color.Green
        '    Me.btnUploadPkgNums.Enabled = True
        '    msgResult = MessageBox.Show("No error found", Caption, MessageBoxButtons.OK)
        'End If


        Me.Cursor = Cursors.Default
        Me.Enabled = True

        Return CSVDataError

    End Function

    Private Sub btnCheckData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckData.Click

        Me.Cursor = Cursors.WaitCursor
        If Not ErrorCheck() Then
            Me.btnUploadPkgNums.Enabled = True
        Else
            Return
        End If

        If CSVDataError Then
            Me.lbl_error0.ForeColor = Color.Red
            Me.lbl_error0.Text = firstErrMsg
            Me.Cursor = Cursors.Default
            msgResult = MessageBox.Show(firstErrMsg + firstErrRow.ToString, Caption, MessageBoxButtons.OK)
        Else
            Me.lbl_error0.Text = "No error found"
            Me.lbl_error0.ForeColor = Color.Green
            Me.btnUploadPkgNums.Enabled = True
            Me.Cursor = Cursors.Default
            msgResult = MessageBox.Show("No error found", Caption, MessageBoxButtons.OK)
        End If

        Me.Cursor = Cursors.Default
    End Sub

 
End Class