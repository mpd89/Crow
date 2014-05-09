Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DataStreams.Csv
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports daqartDLL
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class TagImport
    Inherits System.Windows.Forms.Form
    Private Loading As Boolean = False
    Private cboFields As New List(Of Control)
    Dim engFields() As String = {"Remarks", "Prefix", "Description", "Service", _
                "Manufacturer", "ModelNumber", "SerialNumber", "PONumber", "LineNumber"}

    Private labelObject As TextBox
    Private WithEvents FieldComboBox As System.Windows.Forms.ComboBox
    Private newLabelTop As Integer = 10
    Private ImportDataTable As DataTable
    Private pkgNumTbl As DataTable = New DataTable
    Private TypeIDTbl As DataTable = New DataTable
    Private tabTagImpViewCboControls(6) As System.Windows.Forms.ComboBox
    Private auxHdrCboControls(60) As System.Windows.Forms.ComboBox
    Private PanelComboBox() As System.Windows.Forms.ComboBox
    Private PanellabelBox() As System.Windows.Forms.TextBox
    Private hdrFlds() As Integer
    Private CSVDataError As Boolean = False
    Private Caption As String = "Import Tags"
    Private Buttons As MessageBoxButtons = MessageBoxButtons.AbortRetryIgnore
    Private msgResult As DialogResult
    Private Tagheaders As New List(Of ColumnMap)
    Private AuxTagheaders As New List(Of ColumnMap)
    Private Typeheaders As New List(Of ColumnMap)
    Private Pkgheaders As New List(Of ColumnMap)
    Private AuxFieldheaders As New List(Of ColumnMap)
    Private dgv1 As System.Windows.Forms.DataGridView
    Private UpdateCtr As Integer = 0
    Private InsertCtr As Integer = 0
    Private firstErrColumn As String = ""
    Private firstErrRow As Integer = -1
    Private firstErrMsg As String = ""
    Private AuxFieldmapIDList As New List(Of ColumnMap)
    Private sqlPrjUtils As DataUtils = New DataUtils("project")
    Private sqlDaqument As DataUtils = New DataUtils("Daqument")
    Dim dt_DrawingErrors As New DataTable
    Dim dt_TagErrors As New DataTable


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

    Public Sub New()
        InitializeComponent()

    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyClass.Load
        Loading = True

        Try
            If runtime.SiteName = "BP001" Then
                Me.lbl_EPT.Visible = True
                Me.cbx_FieldSelectTag.Visible = True
            End If

            Me.btnCreateTemplate.Enabled = False
            Me.btnAuxUpload.Enabled = False
            ReDim PanelComboBox(0)
            ReDim PanellabelBox(0)
            Panel1 = New System.Windows.Forms.Panel
            Panel1.AutoScroll = True
            Panel1.Location = New System.Drawing.Point(10, 50)
            Panel1.Size = New System.Drawing.Size(450, 270)

            Me.Size = New Size(1000, 700)
            Dim qry = "Select MUID,TypeName FROM equipment_type ORDER BY TypeName ASC"

            sqlPrjUtils.OpenConnection()
            sqlDaqument.OpenConnection()

            TypeIDTbl = sqlPrjUtils.ExecuteQuery(qry)


            Me.cboDefaultTypeID.DataSource = TypeIDTbl
            Me.cboDefaultTypeID.DisplayMember = TypeIDTbl.Columns("TypeName").ToString
            Me.cboDefaultTypeID.ValueMember = TypeIDTbl.Columns("MUID").ToString
            Dim TypeIDKeys(0) As DataColumn
            TypeIDKeys(0) = TypeIDTbl.Columns("TypeName")
            TypeIDTbl.PrimaryKey = TypeIDKeys

            Me.cboEquipmentType.DataSource = TypeIDTbl
            Me.cboEquipmentType.DisplayMember = TypeIDTbl.Columns("TypeName").ToString
            Me.cboEquipmentType.ValueMember = TypeIDTbl.Columns("MUID").ToString

            qry = "Select MUID,PackageNumber FROM package ORDER BY PackageNumber ASC"
            pkgNumTbl = sqlPrjUtils.ExecuteQuery(qry)
            Dim PkgNumKeys(0) As DataColumn
            PkgNumKeys(0) = pkgNumTbl.Columns("PackageNumber")
            pkgNumTbl.PrimaryKey = PkgNumKeys

            tabTagImpViewCboControls(0) = Me.cboTagNumber
            tabTagImpViewCboControls(1) = Me.cboType
            tabTagImpViewCboControls(2) = Me.cboPkgNum
            tabTagImpViewCboControls(3) = Me.cboAuxTagNumber
            tabTagImpViewCboControls(4) = Me.cboEquipTagNumber
            tabTagImpViewCboControls(5) = Me.cbx_FieldSelectTag

            dgv1 = New System.Windows.Forms.DataGridView

            Me.Controls.Add(Panel1)
            Panel1.Visible = False
            AssignFieldColumns()


            dgv1.AllowUserToResizeColumns = True

            Dim cbxTemp As New System.Windows.Forms.DataGridViewComboBoxColumn
            Dim query As String = "SELECT MUID, Code + ' - ' + Description As Display FROM document_type ORDER BY Code ASC"
            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

            sqlDocUtils.OpenConnection()
            Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
            sqlDocUtils.CloseConnection()

            cbxTemp.HeaderText = "Document Type"
            cbxTemp.Name = "DocumentType"
            cbxTemp.Width = 200
            cbxTemp.DataSource = dt
            cbxTemp.DisplayMember = dt.Columns("Display").ToString
            cbxTemp.ValueMember = dt.Columns("MUID").ToString

            dgv_SelectedFields.Columns.Add(cbxTemp)
        Catch ex As Exception
            Utilities.logErrorMessage("PackageManager.TagImport.Form1_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
        Me.SplitContainer1.SplitterDistance = Me.TabControl1.Size.Height
        lbl_error0.Visible = False
        Loading = False

    End Sub


    Private Sub PopulatecboTemplateName()
        Dim qry = "SELECT MUID,TemplateName FROM aux_template WHERE Type = 'Tag' ORDER BY TemplateName DESC"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)

        If Not cboTemplateName.DataSource Is Nothing Then
            cboTemplateName.DataSource.Dispose()
        End If
        cboTemplateName.Enabled = False
        If dt.Rows.Count > 0 Then
            cboTemplateName.BeginUpdate()
            cboTemplateName.DataSource = dt
            cboTemplateName.DisplayMember = "TemplateName"
            cboTemplateName.ValueMember = "MUID"
            cboTemplateName.SelectedIndex = -1
            cboTemplateName.EndUpdate()
        End If
        cboTemplateName.Enabled = True
    End Sub


    Private Sub PopulateAuxFieldNames()
        Try
            If Not cboTemplateName.SelectedValue Is Nothing Then

                If Me.dgv_AuxFieldsMap.Columns.Count = 4 Then
                    Me.dgv_AuxFieldsMap.Columns.Remove("CSVColumn")
                End If

                Dim dt_ColName As New DataTable
                dt_ColName.Columns.Add("ColName")
                dt_ColName.Columns.Add("ColPos", GetType(Integer))

                For i As Integer = 0 To dgv1.Columns.Count - 1
                    dt_ColName.Rows.Add()
                    dt_ColName.Rows(i)("ColPos") = i
                    dt_ColName.Rows(i)("ColName") = dgv1.Columns(i).HeaderText
                Next

                Dim cbxTemp2 As New System.Windows.Forms.DataGridViewComboBoxColumn
                cbxTemp2.HeaderText = "CSV Column"
                cbxTemp2.Name = "CSVColumn"
                cbxTemp2.Width = 200
                cbxTemp2.DataSource = dt_ColName
                cbxTemp2.DisplayMember = dt_ColName.Columns("ColName").ToString
                cbxTemp2.ValueMember = dt_ColName.Columns("ColPos").ToString
                Me.dgv_AuxFieldsMap.Columns.Add(cbxTemp2)
                Me.dgv_AuxFieldsMap.Rows.Clear()

                Dim id = cboTemplateName.SelectedValue
                Dim qry = "SELECT ColName,CustomName,MUID FROM aux_fieldmap WHERE TemplateMUID = '" + id.ToString + "'"
                Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)

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
                            If dgv1.Columns(j).HeaderText = dt.Rows(i)(0) Then
                                match = True
                                dgv1.Columns(j).HeaderCell.Style.BackColor = Color.CadetBlue
                            End If
                        Next

                        'my code
                        Me.dgv_AuxFieldsMap.Rows.Add(dt.Rows(i)(0), dt.Rows(i)(2), dt.Rows(i)(1))

                        'for each Item 
                        Dim tempCol2 As DataGridViewComboBoxCell = CType(Me.dgv_AuxFieldsMap.Rows(i).Cells(3), DataGridViewComboBoxCell)
                        Dim ComboMatch As Boolean = False

                        For u As Integer = 0 To tempCol2.Items.Count - 1
                            Dim myRowView As System.Data.DataRowView = tempCol2.Items.Item(u)
                            If myRowView.Row.ItemArray(0) = dt.Rows(i)(0) Then
                                dgv_AuxFieldsMap.Rows(i).Cells(3).Value = dt.Rows(i)(0)
                                ComboMatch = True
                            End If
                        Next

                        If ComboMatch Then
                            dgv_AuxFieldsMap.Rows(i).Cells(2).Style.BackColor = Color.Green
                        Else
                            dgv_AuxFieldsMap.Rows(i).Cells(2).Style.BackColor = Color.Red
                        End If

                    Next
                    For i As Integer = 0 To dt.Rows.Count - 1
                        AuxFieldmapIDList.Add(New ColumnMap(dt.Rows(i)(2), dt.Rows(i)(0)))
                        NewlvwCSVFile.Items.Add(dt.Rows(i)(0))
                        NewlvwImportFields.Items.Add(dt.Rows(i)(0))
                    Next
                    If Not match Then
                        MessageBox.Show("No matching column found, please load another template.")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub


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

        For i As Integer = 0 To dgv1.Columns.Count - 1
            Tagheaders.Add(New ColumnMap(i, dgv1.Columns(i).HeaderText))
            Typeheaders.Add(New ColumnMap(i, dgv1.Columns(i).HeaderText))
            Pkgheaders.Add(New ColumnMap(i, dgv1.Columns(i).HeaderText))
            AuxTagheaders.Add(New ColumnMap(i, dgv1.Columns(i).HeaderText))
            lbx_CSVFields.Items.Add(dgv1.Columns(i).HeaderText)
            AuxFieldheaders.Add(New ColumnMap(i, dgv1.Columns(i).HeaderText))
        Next

        tabTagImpViewCboControls(0).DataSource = Tagheaders
        tabTagImpViewCboControls(1).DataSource = Typeheaders
        tabTagImpViewCboControls(2).DataSource = Pkgheaders
        tabTagImpViewCboControls(3).DataSource = Tagheaders
        tabTagImpViewCboControls(4).DataSource = Tagheaders
        tabTagImpViewCboControls(5).DataSource = Tagheaders

        tabTagImpViewCboControls(1).SelectedIndex = 0
        tabTagImpViewCboControls(2).SelectedIndex = 0

        For i As Integer = 0 To 5
            tabTagImpViewCboControls(i).Enabled = False
            tabTagImpViewCboControls(i).DisplayMember = "name"
            tabTagImpViewCboControls(i).ValueMember = "num"
            tabTagImpViewCboControls(i).SelectedIndex = -1
        Next
        For j As Integer = 0 To cboFields.Count - 1
            Dim hdrs As New List(Of ColumnMap)
            For i As Integer = 0 To dgv1.Columns.Count - 1
                hdrs.Add(New ColumnMap(i, dgv1.Columns(i).HeaderText))
            Next
            Dim cbo As System.Windows.Forms.ComboBox = cboFields(j)
            cbo.DataSource = hdrs
            cbo.DisplayMember = "name"
            cbo.ValueMember = "num"
            cbo.SelectedIndex = -1
            cbo.Text = ""
        Next
        For i As Integer = 0 To 5
            tabTagImpViewCboControls(i).Enabled = True
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
            'dgv1.Rows.Add(CSVreader.Values)
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
        MessageBox.Show("CSV Data Loaded.")
        '    Me.btnImportCSV.Enabled = False
        Me.cboTagNumber.Focus()
        CSVreader.Close()
        Me.cboPkgNum.SelectedIndex = -1
        Me.cboTagNumber.SelectedIndex = -1
        Me.cboType.SelectedIndex = -1
        'ErrorCheck()
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
        dgv1.AllowUserToResizeColumns = True
        'dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
        'dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        'dgv1.Location = New System.Drawing.Point(12, 458)
        'dgv1.Size = New System.Drawing.Size(956, 212)
        Me.SplitContainer1.Panel2.Controls.Add(dgv1)
        dgv1.AllowUserToAddRows = False
        dgv1.BringToFront()
        dgv1.Dock = DockStyle.Fill
        'Me.Controls.Add(dgv1)


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


    'Private Sub MoveRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim i As Integer
    '    Try
    '        For i = 0 To NewlvwCSVFile.Items.Count - 1
    '            If NewlvwCSVFile.GetSelected(i) Then
    '                NewlvwImportFields.Items.Add(NewlvwCSVFile.Items(i))
    '                NewlvwCSVFile.Items.RemoveAt(i)
    '            End If
    '        Next
    '    Catch ex As Exception
    '    End Try
    'End Sub


    'Private Sub MoveAllRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim i As Integer
    '    Try
    '        For i = 0 To NewlvwCSVFile.Items.Count - 1
    '            NewlvwImportFields.Items.Add(NewlvwCSVFile.Items(i))
    '        Next
    '        NewlvwCSVFile.Items.Clear()
    '    Catch ex As Exception
    '    End Try
    'End Sub


    'Private Sub MoveLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim i As Integer
    '    Try
    '        For i = 0 To NewlvwImportFields.Items.Count - 1
    '            If NewlvwImportFields.GetSelected(i) Then
    '                NewlvwCSVFile.Items.Add(NewlvwImportFields.Items(i))
    '                NewlvwImportFields.Items.RemoveAt(i)
    '            End If
    '        Next
    '    Catch ex As Exception
    '    End Try
    'End Sub


    'Private Sub MoveAllLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim i As Integer
    '    Try
    '        For i = 0 To NewlvwImportFields.Items.Count - 1
    '            NewlvwCSVFile.Items.Add(NewlvwImportFields.Items(i))
    '        Next
    '        NewlvwImportFields.Items.Clear()
    '    Catch ex As Exception
    '    End Try
    'End Sub




    Private Sub InsertEngineeringData()
        Dim TypeID = Me.cboEquipmentType.SelectedValue

        Me.ToolStripProgressBar1.Maximum = dgv1.Rows.Count - 1
        Me.ToolStripProgressBar1.Value = 0
        Dim UpdateCtr As Integer = 0
        Dim InsertCtr As Integer = 0
        UpdateCtr = 0
        InsertCtr = 0
        Dim Row As Integer
        For Row = 0 To dgv1.Rows.Count - 1
            Dim tagNum As String = dgv1.Rows(Row).Cells(Me.cboEquipTagNumber.SelectedIndex).Value
            If tagNum > "" Then
                Dim qry = " SELECT MUID FROM tags WHERE TagNumber = '" + tagNum + "'"
                Dim tagID As String = ""
                Dim dt_TagID As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                If dt_TagID.Rows.Count = 1 Then
                    tagID = dt_TagID.Rows(0)(0)
                End If

                If tagID > "" Then
                    qry = "SELECT MUID, Aux09  FROM engineering_data WHERE TagMUID = '" + tagID.ToString + "' ORDER BY TS DESC"
                    Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                    Dim EngTagID As String = ""
                    Dim dt_param As DataTable = sqlPrjUtils.paramDT


                    If dt.Rows.Count > 0 Then 'if record exists, update latest
                        If Not IsDBNull(dt.Rows(0)("Aux09")) Then
                            If dt.Rows(0)("Aux09") = 1 Then 'if orginal record has been modified, exit loop
                                Exit For
                            End If
                        End If

                        EngTagID = dt.Rows(0)("MUID")
                        qry = " UPDATE engineering_data SET "
                        For i As Integer = 0 To cboFields.Count - 1
                            Dim mycbo As System.Windows.Forms.ComboBox = CType(Me.cboFields(i), System.Windows.Forms.ComboBox)
                            If mycbo.SelectedIndex >= 0 Then
                                qry = qry + engFields(i) + "= @" + engFields(i) + ","
                                Dim val = dgv1.Rows(Row).Cells(mycbo.SelectedIndex).Value
                                dt_param.Rows.Add("@" + engFields(i), val)
                            End If
                        Next
                        qry = Strings.Left(qry, Strings.Len(qry) - 1) + " WHERE MUID = '" + EngTagID.ToString + "'"
                        sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                        UpdateCtr = UpdateCtr + 1
                    Else
                        Dim vals(engFields.Length) As String
                        qry = ""
                        For i As Integer = 0 To engFields.Length - 1
                            qry = qry + engFields(i) + ","
                        Next
                        qry = "INSERT INTO Engineering_data (" + qry + "MUID,TS,TagMUID ) VALUES ("
                        For i As Integer = 0 To engFields.Length - 1
                            qry = qry + "@" + engFields(i) + ","
                        Next
                        qry = qry + "@MUID,@TS,@TagMUID )"

                        Dim muid As String = idUtils.GetNextMUID("project", "Engineering_data")

                        For i As Integer = 0 To cboFields.Count - 1
                            Dim mycbo As System.Windows.Forms.ComboBox = CType(Me.cboFields(i), System.Windows.Forms.ComboBox)
                            If mycbo.SelectedIndex >= 0 Then
                                If Not IsDBNull(dgv1.Rows(Row).Cells(mycbo.SelectedIndex).Value) Then
                                    vals(i) = dgv1.Rows(Row).Cells(mycbo.SelectedIndex).Value
                                Else
                                    vals(i) = ""
                                End If
                            Else
                                vals(i) = ""
                            End If
                            dt_param.Rows.Add("@" + engFields(i), vals(i))
                        Next
                        dt_param.Rows.Add("@MUID", muid)
                        dt_param.Rows.Add("@TS", DateTime.Now.ToString)
                        dt_param.Rows.Add("@TagMUID", tagID)
                        sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                        InsertCtr = InsertCtr + 1
                    End If
                End If
            End If
            If (Row Mod 100) = 0 Then
                Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", Row.ToString, dgv1.Rows.Count)
                Me.ToolStripProgressBar1.Increment(100)
                Me.ToolStripProgressBar1.Invalidate()
                Me.Refresh()
            End If
        Next
        Utilities.SyncProjectDB(runtime.selectedProject)
        Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", (Row - 1), dgv1.Rows.Count - 1)
        Me.ToolStripProgressBar1.Value = Me.ToolStripProgressBar1.Maximum
        MessageBox.Show("Upload done. Total Tags uploaded: " + (UpdateCtr + InsertCtr).ToString + _
                        ", Tags Inserted: " + InsertCtr.ToString + _
                        ", Tags Updated: " + UpdateCtr.ToString)


    End Sub


    'Private Function GetPkgID(ByVal RowNum As Integer)
    '    Dim pkgID As String = ""
    '    If Me.cboPkgNum.SelectedIndex > 0 Then
    '        Dim pkgNum As String = dgv1.Rows(RowNum).Cells(Me.cboPkgNum.SelectedIndex).Value
    '        If pkgNum > "" Then
    '            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
    '            Dim qry = "SELECT MUID From Package WHERE PackageNumber = '" + pkgNum + "'"
    '            sqlPrjUtils.OpenConnection()
    '            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '            sqlPrjUtils.CloseConnection()

    '            'Dim qry = useProjectDB + "SELECT PackageID From Package WHERE PackageNumber = '" + pkgNum + "'"
    '            'Dim dt As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
    '            If dt.Rows.Count > 0 Then
    '                pkgID = dt.Rows(0)("MUID")
    '            End If
    '        End If
    '    End If
    '    Return pkgID
    'End Function
    'Private Function GetTypeID(ByVal RowNum As Integer)
    '    Dim TypeID As String = ""
    '    If Me.cboType.SelectedIndex > 0 Then
    '        Dim TypeName As String = dgv1.Rows(RowNum).Cells(Me.cboType.SelectedIndex).Value
    '        If TypeName > "" Then
    '            Dim qry = "SELECT MUID From Equipment_Type WHERE TypeName = '" + TypeName.ToString + "'"
    '            'Dim dt As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
    '            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

    '            sqlPrjUtils.OpenConnection()
    '            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '            sqlPrjUtils.CloseConnection()

    '            If dt.Rows.Count > 0 Then
    '                TypeID = dt.Rows(0)("MUID")
    '            End If
    '        End If
    '    Else
    '        If Me.cboDefaultTypeID.SelectedValue > 0 Then
    '            TypeID = Me.cboDefaultTypeID.SelectedValue
    '        End If
    '    End If
    '    Return TypeID
    'End Function
    'Private Function GetTagID(ByVal TagNum As String)
    '    Dim TagID As Integer = 0
    '    If TagNum > "" Then
    '        Dim qry = "SELECT MUID From tags WHERE TagNumber = '" + TagNum.ToString + "'"
    '        'Dim dt As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
    '        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

    '        sqlPrjUtils.OpenConnection()
    '        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '        sqlPrjUtils.CloseConnection()

    '        If dt.Rows.Count > 0 Then
    '            TagID = dt.Rows(0)("MUID")
    '        End If
    '    End If
    '    Return TagID
    'End Function
    Private Sub UploadTags()
        Dim Ctr As Integer = 0
        UpdateCtr = 0
        InsertCtr = 0
        Dim processCtr As Integer = 0
        Me.ToolStripProgressBar1.Maximum = dgv1.Rows.Count - 1
        Me.ToolStripProgressBar1.Value = 0
        msgResult = System.Windows.Forms.DialogResult.OK
        Dim qry As String = ""

        Try
            For i As Integer = 0 To dgv1.Rows.Count - 1
                'Dim pkgID As String = dgv1.Rows(i).Cells(Me.cboPkgNum.SelectedIndex).Tag

                Dim pkgNum As String = dgv1.Rows(i).Cells(Me.cboPkgNum.Text).Value.ToString
                qry = " SELECT MUID FROM package WHERE (packageNumber = '" + pkgNum + "')"
                Dim pkgID = sqlPrjUtils.ExecuteQuery(qry).Rows(0)("MUID")
                Dim TypeName = "UDF"
                If Me.cboType.Text > "" Then
                    TypeName = dgv1.Rows(i).Cells(Me.cboType.Text).Value.ToString
                End If


                qry = "SELECT MUID From equipment_type WHERE TypeName = '" + TypeName + "'"
                Dim TypeID As String = sqlPrjUtils.ExecuteQuery(qry).Rows(0)("MUID")

                If Me.cboType.Text = "" Then
                    TypeID = Me.cboDefaultTypeID.SelectedValue
                End If
                If Me.cboDefaultTypeID.SelectedValue > "" Then
                End If

                Dim TagNum As String = dgv1.Rows(i).Cells(Me.cboTagNumber.SelectedIndex).Value
                qry = "SELECT MUID From tags WHERE TagNumber = '" + TagNum.ToString + "'"
                Dim TagID As String = ""
                Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                If dt.Rows.Count > 0 Then
                    TagID = dt.Rows(0)("MUID")
                End If

                Ctr = Ctr + 1
                Dim dt_param As DataTable = sqlPrjUtils.paramDT
                If TagID > "" Then
                    qry = " UPDATE tags Set TS = @TS, TagNumber = @TagNumber, " + _
                        " PackageMUID = @PackageMUID, TypeMUID = @TypeMUID" + _
                        " WHERE MUID = @MUID"
                    dt_param.Rows.Add("@TS", DateTime.Now.ToString)
                    dt_param.Rows.Add("@TagNumber", TagNum.ToString)
                    dt_param.Rows.Add("@PackageMUID", pkgID.ToString)
                    dt_param.Rows.Add("@TypeMUID", TypeID.ToString)
                    dt_param.Rows.Add("@MUID", TagID.ToString)

                    UpdateCtr = UpdateCtr + 1
                Else
                    qry = " INSERT INTO tags (MUID, TS,TagNumber,PackageMUID,TypeMUID)  VALUES (" + _
                            "@MUID, @TS,@TagNumber,@PackageMUID,@TypeMUID)"

                    dt_param.Rows.Add("@TS", DateTime.Now.ToString)
                    dt_param.Rows.Add("@TagNumber", TagNum.ToString)
                    dt_param.Rows.Add("@PackageMUID", pkgID.ToString)
                    dt_param.Rows.Add("@TypeMUID", TypeID.ToString)
                    dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "tags"))

                    InsertCtr = InsertCtr + 1
                End If
                sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                processCtr = processCtr + 1
                If (Ctr Mod 100) = 0 Then
                    Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", Ctr.ToString, dgv1.Rows.Count - 2)
                    Me.ToolStripProgressBar1.Increment(100)
                    Me.ToolStripProgressBar1.Invalidate()
                    Me.Refresh()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", Ctr.ToString, dgv1.Rows.Count - 2)
        Me.ToolStripProgressBar1.Value = Me.ToolStripProgressBar1.Maximum
        MessageBox.Show("Total Rows: " + Ctr.ToString + ", processed: " + processCtr.ToString + _
                ", New Tags Added: " + InsertCtr.ToString + ", Tags Updated: " + UpdateCtr.ToString)
    End Sub
    'Private Sub InsertTagNumbers()

    '    Dim cmdInsert As SqlCommand = connSQLServer.CreateCommand()
    '    cmdInsert.CommandType = CommandType.Text
    '    cmdInsert.Parameters.Add("@TagTS", SqlDbType.DateTime)
    '    cmdInsert.Parameters("@TagTS").Value = DateTime.Now
    '    cmdInsert.Parameters.Add("@TagNumber", SqlDbType.VarChar)
    '    cmdInsert.Parameters.Add("@PackageID", SqlDbType.Int)
    '    cmdInsert.Parameters.Add("@TypeID", SqlDbType.Int)
    '    cmdInsert.CommandText = useProjectDB + " INSERT INTO tags (TagTS,TagNumber,PackageID,TypeID)  VALUES " + _
    '                        "(@TagTS,@TagNumber,@PackageID,@TypeID); SELECT CAST(scope_identity() AS int);"

    '    Dim cmdPkgNumID As SqlCommand = connSQLServer.CreateCommand()
    '    cmdPkgNumID.CommandType = CommandType.Text
    '    cmdPkgNumID.Parameters.Add("@PackageNumber", SqlDbType.VarChar)
    '    cmdPkgNumID.CommandText = useProjectDB + "Select PackageID FROM package WHERE (PackageNumber = @packageNumber)"


    '    Dim cmdTypeID As SqlCommand = connSQLServer.CreateCommand()
    '    cmdTypeID.CommandType = CommandType.Text
    '    cmdTypeID.Parameters.Add("@TypeName", SqlDbType.VarChar)
    '    cmdTypeID.CommandText = useProjectDB + "Select TypeID FROM equipment_type WHERE (TypeName = @TypeName)"


    '    Dim cmdCheck As SqlCommand = connSQLServer.CreateCommand()
    '    cmdCheck.CommandType = CommandType.Text
    '    cmdCheck.CommandText = useProjectDB + " SELECT TagID FROM tags WHERE TagNumber = @TagNumber " + _
    '                    " AND TypeID = @TypeID AND PackageID = @PackageID "
    '    cmdCheck.Parameters.Add("@TagNumber", SqlDbType.VarChar)
    '    cmdCheck.Parameters.Add("@TypeID", SqlDbType.Int)
    '    cmdCheck.Parameters.Add("@PackageID", SqlDbType.Int)

    '    Dim Ctr As Integer = 0
    '    InsertCtr = 0
    '    Dim processCtr As Integer = 0
    '    Me.ToolStripProgressBar1.Maximum = dgv1.Rows.Count - 2
    '    Me.ToolStripProgressBar1.Value = 0
    '    msgResult = System.Windows.Forms.DialogResult.OK
    '    Try
    '        For i As Integer = 0 To dgv1.Rows.Count - 1
    '            Dim msg As String = ""
    '            Dim errSet As Boolean = False
    '            Ctr = Ctr + 1
    '            Dim tagNum As String = dgv1.Rows(i).Cells(Me.cboTagNumber.SelectedIndex).Value
    '            Dim TypeID As Integer = 0
    '            Dim pkgNumID As Integer = 0
    '            If tagNum > "" Then
    '                If Me.cboType.SelectedIndex > 0 Then
    '                    cmdTypeID.Parameters("@TypeName").Value = dgv1.Rows(i).Cells(Me.cboType.SelectedIndex).Value
    '                    TypeID = Convert.ToInt32(cmdTypeID.ExecuteScalar())
    '                Else
    '                    TypeID = Me.cboDefaultTypeID.SelectedValue
    '                End If
    '                If TypeID = 0 Then TypeID = 1 'Undefined is always 1
    '                If Me.cboPkgNum.SelectedIndex > 0 Then
    '                    Dim pkgNum = dgv1.Rows(i).Cells(Me.cboPkgNum.SelectedIndex).Value
    '                    If pkgNum > "" Then
    '                        cmdPkgNumID.Parameters("@packageNumber").Value = dgv1.Rows(i).Cells(Me.cboPkgNum.SelectedIndex).Value
    '                        pkgNumID = Convert.ToInt32(cmdPkgNumID.ExecuteScalar())
    '                    End If
    '                Else
    '                    pkgNumID = Me.cboDefaultTypeID.SelectedValue
    '                End If
    '                If pkgNumID > 0 Then
    '                    cmdCheck.Parameters("@TagNumber").Value = tagNum
    '                    cmdCheck.Parameters("@TypeID").Value = TypeID
    '                    cmdCheck.Parameters("@PackageID").Value = pkgNumID
    '                    Dim NewID As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
    '                    If NewID = 0 Then
    '                        cmdInsert.Parameters("@PackageID").Value = pkgNumID
    '                        cmdInsert.Parameters("@TypeID").Value = TypeID
    '                        cmdInsert.Parameters("@TagNumber").Value = tagNum
    '                        Convert.ToInt32(cmdInsert.ExecuteScalar())
    '                        InsertCtr = InsertCtr + 1
    '                    End If
    '                    processCtr = processCtr + 1
    '                End If
    '            End If
    '            If (Ctr Mod 100) = 0 Then
    '                Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", Ctr.ToString, dgv1.Rows.Count - 2)
    '                Me.ToolStripProgressBar1.Increment(100)
    '                Me.ToolStripProgressBar1.Invalidate()
    '                Me.Refresh()
    '            End If
    '        Next
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    '    Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", Ctr.ToString, dgv1.Rows.Count - 2)
    '    Me.ToolStripProgressBar1.Value = Me.ToolStripProgressBar1.Maximum
    '    MessageBox.Show("Total Rows: " + Ctr.ToString + ", precessed: " + processCtr.ToString + _
    '            ", New Tags Added: " + InsertCtr.ToString + ", Tags Updated: " + UpdateCtr.ToString)
    'End Sub


    'Private Function UpdateAuxColumnHeaderMapping() As Boolean
    '    Dim ShowPanel As Boolean = False
    '    If (Me.cboEquipmentType.SelectedIndex) < 0 Then
    '        MessageBox.Show("Please select Equipment Type")
    '        Me.cboEquipmentType.SelectedIndex = 0
    '    End If
    '    Dim Row As DataRow = TypeIDTbl.Rows(Me.cboEquipmentType.SelectedIndex)

    '    Dim cmdCheck As SqlCommand = connSQLServer.CreateCommand()
    '    cmdCheck.CommandText = useProjectDB + " SELECT auxHeader FROM aux_fieldmap " + _
    '                "WHERE (mainTable = 'tags') AND (auxField = " + Row(0).ToString + ")"
    '    Dim auxHdr = "" ' Convert.ToString(cmdCheck.ExecuteScalar())
    '    If auxHdr > "" Then
    '        If PanelComboBox.Length > 1 Then
    '            For i As Integer = 1 To PanelComboBox.Length - 1
    '                PanelComboBox(i - 1).Dispose()
    '                PanellabelBox(i - 1).Dispose()
    '            Next
    '        End If
    '        ReDim PanelComboBox(0)
    '        ReDim PanellabelBox(0)
    '        newLabelTop = 10
    '        Dim myStr() As String = Split(auxHdr, "&001")
    '        If Not dgv1 Is Nothing Then
    '            If dgv1.Columns.Count > 0 Then
    '                For i As Integer = 0 To myStr.Length - 2
    '                    DrawAuxFields(i, myStr(i))
    '                Next
    '                For i As Integer = 0 To myStr.Length - 2
    '                    PanelComboBox(i).SelectedIndex = -1
    '                    PanelComboBox(i).Refresh()
    '                Next
    '            End If
    '            ShowPanel = True
    '        End If
    '    End If
    '    If ShowPanel Then
    '        Me.TabPage2.Controls.Add(Panel1)
    '        If dgv1.Columns.Count > 0 Then
    '            For i As Integer = 0 To PanelComboBox.Length - 2
    '                PanelComboBox(i).SelectedIndex = -1
    '                PanelComboBox(i).Refresh()
    '            Next
    '        End If
    '        Panel1.BringToFront()
    '        Panel1.Visible = True
    '    Else
    '        Panel1.Visible = False
    '    End If
    'End Function


    Private Sub AssignFieldColumns()
        Dim mytop As Point = Me.lblEquipmentImport.Location
        Dim X = mytop.X + 40 : Dim Y = mytop.Y + 40
        Dim k = 0
        For i As Integer = 0 To engFields.Length - 1
            Dim ctrl As Control = New System.Windows.Forms.ComboBox
            Dim lbl As Label = New Label
            lbl.TextAlign = ContentAlignment.TopRight
            lbl.Text = engFields(i)
            lbl.Location = New Point(X, Y + (k * 25) + 20)
            ctrl.Location = New Point(lbl.Location.X + lbl.Width + 10, lbl.Location.Y)
            cboFields.Add(ctrl)
            Me.TabControl1.TabPages(2).Controls.Add(ctrl)
            Me.TabControl1.TabPages(2).Controls.Add(lbl)
            k = k + 1
            If ((i + 1) Mod 5) = 0 Then
                X = X + 300
                k = 0
            End If
        Next
    End Sub


    Private Function VerifyHdrFields() As Boolean
        Dim match As Boolean = False
        If NewlvwImportFields.Items.Count <= 0 Then
            MessageBox.Show("Please select valid Aux Template")
            Return 0
        End If
        For i As Integer = 0 To NewlvwImportFields.Items.Count - 1
            Dim name As String = ""
            For j As Integer = 0 To dgv1.Columns.Count - 1
                If NewlvwImportFields.Items(i) = dgv1.Columns(j).Name Then
                    name = NewlvwImportFields.Items(i)
                    match = True
                    Exit For
                End If
            Next
        Next
        If Not match Then
            MessageBox.Show("No matching column header found in the CSV file")
            Return False
        End If
        Return True
    End Function


    Private Sub InsertAuxTagInfo()
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
        Dim Row As Integer

        For Row = 0 To dgv1.Rows.Count - 1
            Dim tagNum As String = dgv1.Rows(Row).Cells(Me.cboAuxTagNumber.SelectedIndex).Value
            If tagNum > "" Then
                Dim qry = " SELECT MUID FROM tags WHERE TagNumber = '" + tagNum + "'"
                Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                Dim myTagID As String = ""
                If dt.Rows.Count > 0 Then
                    myTagID = dt.Rows(0)("MUID")
                End If

                If myTagID > "" Then
                    For j As Integer = 0 To Me.dgv_AuxFieldsMap.Rows.Count - 1
                        Dim fldMapID As String = Me.dgv_AuxFieldsMap.Rows(j).Cells(1).Value
                        Dim fldName As String = Me.dgv_AuxFieldsMap.Rows(j).Cells(3).Value
                        If Not fldName = Nothing Then

                            Dim matchingColumn As Integer = -1
                            For k As Integer = 0 To dgv1.Columns.Count - 1
                                If fldName.ToString = dgv1.Columns(k).Name Then
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
                                qry = "SELECT MUID, Aux05 FROM aux_tags WHERE FieldmapMUID = '" + fldMapID.ToString + "'" + _
                                        " AND TagMUID = '" + myTagID.ToString + "'"
                                Dim dt3 As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                                Dim auxID As String = ""
                                If dt3.Rows.Count > 0 Then
                                    auxID = dt3.Rows(0)("MUID")
                                End If
                                Dim dt_param As DataTable = sqlPrjUtils.paramDT


                                If auxID > "" Then
                                    If Not IsDBNull(dt3.Rows(0)("Aux05")) Then 'if orginal record has been modified, exit loop
                                        If dt3.Rows(0)("Aux05") = 1 Then 'if orginal record has been modified, exit loop
                                            Exit For
                                        End If
                                    End If

                                    qry = " UPDATE aux_tags SET auxData = @auxData" + _
                                                " WHERE MUID = @MUID"
                                    dt_param.Rows.Add("@MUID", auxID.ToString)
                                    dt_param.Rows.Add("@auxData", fldValue)
                                    sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                                Else
                                    Dim muid As String = idUtils.GetNextMUID("project", "aux_tags")
                                    qry = " INSERT INTO aux_tags (MUID,TagMUID,FieldMapMUID,auxData) VALUES (@MUID,@TagMUID,@FieldMapMUID,@auxData)"
                                    dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "aux_tags"))
                                    dt_param.Rows.Add("@TagMUID", myTagID.ToString)
                                    dt_param.Rows.Add("@auxData", fldValue)
                                    dt_param.Rows.Add("@FieldMapMUID", fldMapID)
                                    sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                                End If
                            End If
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
        MessageBox.Show("Total rows: " + Row.ToString + ", total Tags processed: " + InsertCtr.ToString)

        'Dim Ctr As Integer = 0
        'Dim UpdateCtr As Integer = 0
        'Dim InsertCtr As Integer = 0
        'Dim processCtr As Integer = 0
        'Dim TemplateID As Integer = Me.cboTemplateName.SelectedValue
        'If TemplateID <= 0 Then
        '    MessageBox.Show("No Template Name has been selected")
        'End If
        'Me.Cursor = Cursors.WaitCursor
        'Me.ToolStripProgressBar1.Maximum = 10
        'Me.ToolStripProgressBar1.Value = 0
        'Dim Row As Integer
        'For Row = 0 To dgv1.Rows.Count - 1
        '    Dim tagNum As String = dgv1.Rows(Row).Cells(Me.cboAuxTagNumber.SelectedIndex).Value
        '    If tagNum > "" Then
        '        Dim qry = useProjectDB + " SELECT tagID FROM tags WHERE TagNumber = '" + tagNum + "'"
        '        Dim dt As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
        '        Dim tagID As Integer = 0
        '        If dt.Rows.Count > 0 Then
        '            tagID = dt.Rows(0)(0)
        '        End If
        '        If tagID > 0 Then
        '            qry = useProjectDB + " SELECT TemplateID,AssocID FROM aux_template_assoc " + _
        '                        "WHERE TemplateID = " + TemplateID.ToString + _
        '                        " AND AssocID = " + tagID.ToString + " AND Aux01 = 'Tag'"
        '            Dim dt2 As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
        '            If dt2.Rows.Count <= 0 Then
        '                qry = useProjectDB + " INSERT INTO aux_template_assoc " + _
        '                            "(TemplateID,AssocID,Aux01) VALUES (" + _
        '                            TemplateID.ToString + "," + tagID.ToString + ",'Tag')"
        '                Utilities.ExecuteRemoteNonQuery(qry, "")
        '            End If
        '            Dim auxData As String = ""
        '            For j As Integer = 0 To Me.NewlvwCSVFile.Items.Count - 1
        '                Dim fldName As String = NewlvwImportFields.Items(j)
        '                qry = useProjectDB + " SELECT idaux_fieldmap FROM aux_fieldmap WHERE ColName = '" + _
        '                        fldName + "' AND TemplateID = " + TemplateID.ToString
        '                Dim dt1 As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
        '                Dim fldMapID As Integer = 0
        '                If dt1.Rows.Count > 0 Then
        '                    fldMapID = dt1.Rows(0)(0)
        '                End If
        '                If fldMapID > 0 Then
        '                    Dim fldValue As String = dgv1.Rows(Row).Cells(fldName).Value()
        '                    qry = useProjectDB + "SELECT auxID FROM aux_tags WHERE FieldmapID = " + fldMapID.ToString + _
        '                            " AND TagID = " + tagID.ToString
        '                    Dim dt3 As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
        '                    Dim auxID As Integer = 0
        '                    If dt3.Rows.Count > 0 Then
        '                        auxID = dt3.Rows(0)(0)
        '                    End If
        '                    If auxID > 0 Then
        '                        qry = useProjectDB + " UPDATE aux_tags SET auxData = '" + fldValue + "'" + _
        '                                    " WHERE auxID = " + auxID.ToString
        '                    Else
        '                        qry = useProjectDB + " INSERT INTO aux_tags " + _
        '                                    "(FieldMapID,TagID,auxData) VALUES (" + fldMapID.ToString + _
        '                                    "," + tagID.ToString + ",'" + fldValue.ToString + "')"
        '                    End If
        '                    Utilities.ExecuteRemoteNonQuery(qry, "")
        '                End If
        '            Next
        '            InsertCtr = InsertCtr + 1
        '        End If
        '    End If
        '    Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", Row.ToString, dgv1.Rows.Count - 1)
        '    Me.ToolStripProgressBar1.Increment(1)
        '    If Me.ToolStripProgressBar1.Value >= dgv1.Rows.Count - 1 Then
        '        Me.ToolStripProgressBar1.Value = 0
        '    End If
        'Next
        'Me.Cursor = Cursors.Default
        'Me.ToolStripTextBox1.Text = String.Format("{0} of {1}", (Row - 1), dgv1.Rows.Count - 1)
        'Me.ToolStripProgressBar1.Value = Me.ToolStripProgressBar1.Maximum
        'MessageBox.Show("Total rows: " + Row.ToString + ", total Tags processed: " + InsertCtr.ToString)
    End Sub
    Private Function CheckDupliacteAuxTemplate() As Boolean
        Dim rt As Boolean = False
        Dim TemplateID As String = Me.cboTemplateName.SelectedValue
        Dim auxTagID As New ArrayList
        Dim qry As String = ""

        For Row As Integer = 0 To dgv1.Rows.Count - 1
            dgv1.Rows(Row).DefaultCellStyle.BackColor = Color.White
            Dim tagNum As String = dgv1.Rows(Row).Cells(Me.cboAuxTagNumber.SelectedIndex).Value
            If tagNum > "" Then
                qry = " SELECT MUID FROM tags WHERE TagNumber = '" + tagNum + "'"
                'Dim dt As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
                Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                Dim tagID As String = ""
                If dt.Rows.Count > 0 Then
                    tagID = dt.Rows(0)(0)
                End If
                If tagID > "" Then
                    qry = " SELECT TemplateMUID FROM aux_template_assoc " + _
                                "WHERE AssocMUID = '" + tagID.ToString + "' AND SourceMUID = 'Tag' "
                    'Dim dt2 As DataTable = Utilities.ExecuteRemoteQuery(qry, "")
                    Dim dt2 As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                    If dt2.Rows.Count > 0 Then
                        If dt2.Rows(0)("TemplateMUID") <> TemplateID Then
                            dgv1.Rows(Row).DefaultCellStyle.BackColor = Me.tbx_Duplicate.BackColor
                            rt = True
                        End If
                    Else
                        auxTagID.Add(tagID)
                    End If
                End If
            End If
        Next

        If rt Then
            MessageBox.Show("The package has already been assigned to another Template ")
            Return rt
        End If
        For Each tagID As String In auxTagID

            qry = " SELECT MUID FROM aux_template_assoc " + _
                                    "WHERE AssocMUID = '" + tagID.ToString + "' AND SourceMUID = 'Tag' "
            Dim dt2 As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            If dt2.Rows.Count = 0 Then
                qry = " INSERT INTO aux_template_assoc " + _
                            "(MUID,TemplateMUID,AssocMUID,SourceMUID) VALUES (@MUID,@TemplateMUID,@AssocMUID,@SourceMUID)"
                Dim dt_param As DataTable = sqlPrjUtils.paramDT

                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "aux_template_assoc"))
                dt_param.Rows.Add("@TemplateMUID", TemplateID.ToString)
                dt_param.Rows.Add("@AssocMUID", tagID.ToString)
                dt_param.Rows.Add("@SourceMUID", "Tag")
                sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
            End If
        Next
        Return rt

    End Function


    'Private Sub CheckDupliacteTagNumbers()
    '    Dim ColumnNum As Integer = Me.cboTagNumber.SelectedIndex
    '    If ColumnNum < 0 Then Return
    '    For i As Integer = 0 To dgv1.Rows.Count - 1
    '        dgv1.Rows(i).DefaultCellStyle.BackColor = Color.White
    '        'dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Color.White
    '        Dim Name As String = dgv1.Rows(i).Cells(ColumnNum).Value
    '        If Name > "" Then
    '            For j As Integer = i + 1 To dgv1.Rows.Count - 1
    '                If Name = dgv1.Rows(j).Cells(ColumnNum).Value Then
    '                    dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_Duplicate.BackColor
    '                    dgv1.Rows(j).Cells(ColumnNum).Style.BackColor = Me.tbx_Duplicate.BackColor
    '                    CSVDataError = True
    '                    dgv1.Rows(i).Tag = "err"
    '                    dgv1.Rows(j).Tag = "err"
    '                    If firstErrColumn < 0 Then
    '                        firstErrColumn = ColumnNum
    '                        firstErrRow = i
    '                    End If
    '                End If
    '            Next

    '        End If
    '    Next
    'End Sub


    'Private Sub CheckBlankTagNumbers()
    '    Dim ColumnNum As Integer = Me.cboTagNumber.SelectedIndex
    '    If ColumnNum < 0 Then Return
    '    For i As Integer = 0 To dgv1.Rows.Count - 1
    '        Dim Name As String = dgv1.Rows(i).Cells(ColumnNum).Value
    '        If Name = "" Then
    '            dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorBlank.BackColor
    '            CSVDataError = True
    '            If firstErrColumn < 0 Then
    '                firstErrColumn = ColumnNum
    '                firstErrRow = i
    '            End If
    '            dgv1.Rows(i).Tag = ""
    '        End If
    '    Next
    'End Sub
    'Private Sub CheckInvalidPackageNumbers()
    '    Dim ColumnNum As Integer = Me.cboPkgNum.SelectedIndex
    '    If ColumnNum < 0 Then Return
    '    Dim sqlPrjUtils As DataUtils = New DataUtils("project")
    '    sqlPrjUtils.OpenConnection()
    '    For i As Integer = 0 To dgv1.Rows.Count - 1
    '        Dim pkgNum As String = dgv1.Rows(i).Cells(ColumnNum).Value
    '        Dim qry As String = "SELECT MUID From Package WHERE PackageNumber = '" + pkgNum + "'"
    '        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '        If dt.Rows.Count = 0 Then
    '            dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = tbx_ColorInvalid.BackColor
    '            dgv1.Rows(i).Tag = ""
    '            CSVDataError = True
    '            If firstErrColumn < 0 Then
    '                firstErrColumn = ColumnNum
    '                firstErrRow = i
    '            End If
    '        Else
    '            dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Color.Transparent
    '            dgv1.Rows(i).Tag = dt.Rows(0)("MUID")
    '        End If
    '    Next
    '    sqlPrjUtils.CloseConnection()
    'End Sub
    'Private Sub CheckInvalidTypeNames()
    '    Dim ColumnNum As Integer = Me.cboType.SelectedIndex
    '    If ColumnNum < 0 Then Return
    '    Dim sqlPrjUtils As DataUtils = New DataUtils("project")
    '    sqlPrjUtils.OpenConnection()

    '    For i As Integer = 0 To dgv1.Rows.Count - 1
    '        Dim typeName As String = dgv1.Rows(i).Cells(Me.cboType.SelectedIndex).Value
    '        Dim qry As String = "SELECT MUID From equipment_type WHERE TypeName = '" + typeName + "'"
    '        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '        If dt.Rows.Count = 0 Then
    '            dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = tbx_ColorInvalid.BackColor
    '            dgv1.Rows(i).Tag = ""
    '            CSVDataError = True
    '            If firstErrColumn < 0 Then
    '                firstErrColumn = ColumnNum
    '                firstErrRow = i
    '            End If
    '        Else
    '            dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Color.Transparent
    '            dgv1.Rows(i).Tag = dt.Rows(0)("MUID")
    '        End If
    '    Next
    '    sqlPrjUtils.CloseConnection()


    'End Sub
    ''Private Function CheckInvalidTypeAndPkgFileds() As Boolean
    '    For i As Integer = 0 To dgv1.Rows.Count - 1
    '        Dim errSet As Boolean = False
    '        Dim pkgID As Integer = GetPkgID(i)
    '        Dim TypeID As Integer = GetTypeID(i)
    '        If pkgID = 0 Then
    '            Dim msg = "Invalid Package numbers in the CSV File: Row#:" + i.ToString
    '            msgResult = MessageBox.Show(msg, Caption, Buttons)
    '            If msgResult = Windows.Forms.DialogResult.Ignore Then Return False
    '            Return True
    '        End If
    '        If TypeID = 0 Then
    '            Dim msg = "Invalid Equipment Type in the CSV File: Row#:" + i.ToString
    '            msgResult = MessageBox.Show(msg, Caption, Buttons)
    '            If msgResult = Windows.Forms.DialogResult.Ignore Then Return False
    '            Return True
    '        End If
    '    Next
    '    Return False
    'End Function


    Private Sub btnUploadPkgNums_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadPkgNums.Click
        If ErrorCheck() Then
            MessageBox.Show("Please perform error check")
            Return
        End If

        Me.Cursor = Cursors.AppStarting
        Me.Enabled = False

        UploadTags()
        Me.Enabled = True
        Me.Cursor = Cursors.Default

    End Sub




    Private Sub btnImportCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportCSV.Click
        For i As Integer = 0 To 5
            tabTagImpViewCboControls(i).Enabled = False
            tabTagImpViewCboControls(i).Text = ""
        Next

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


        If cboTemplateName.Items.Count > 0 Then
            'PopulateAuxFieldNames()
            cboTemplateName.SelectedIndex = 0
        End If

    End Sub


    Private Sub AuxUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuxUpload.Click

        If Me.fileName.Text = "" Then
            MessageBox.Show("Missing File name")
            Return
        End If
        If Me.cboAuxTagNumber.Text = "" Then
            MessageBox.Show("Missing the 'TagNumber' Column mapping")
            Return
        End If
        If Me.cboEquipmentType.SelectedIndex < 0 Then
            MessageBox.Show("Missing the 'Engineering Type' field")
            Return
        End If
        If Not VerifyHdrFields() Then
            Return
        End If
        If CheckDupliacteAuxTemplate() Then
            Return
        End If
        InsertAuxTagInfo()
    End Sub


    Private Sub cboAuxTypeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Name = "TabPage2" Then
            'UpdateAuxColumnHeaderMapping()
        End If
    End Sub


    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        Me.Dispose()
    End Sub

    Private Sub ExitPackageViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitPackageViewerToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub GroupByPackagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupByPackagesToolStripMenuItem.Click
        Dim my1Form As New TagSelect()
        my1Form.ShowDialog()

    End Sub

    Private Sub btnEquipmentImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquipmentImport.Click
        Dim mapctr As Integer = 0
        If Me.cboTagNumber.Text = "" Then
            MessageBox.Show("Missing the mapping of the 'Tag Number' field")
        End If
        For i As Integer = 0 To cboFields.Count - 1
            Dim mycbo As System.Windows.Forms.ComboBox = CType(Me.cboFields(i), System.Windows.Forms.ComboBox)
            If mycbo.SelectedIndex >= 0 Then
                mapctr = mapctr + 1
            End If
        Next
        If mapctr = 0 Then
            MessageBox.Show("Missing Engineering Field map")
            Return
        End If
        InsertEngineeringData()
    End Sub


    Private Sub btn_AddDocumentField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddDocumentField.Click
        Dim i As Integer
        Try
            Dim cbxTemp As New System.Windows.Forms.DataGridViewComboBoxColumn


            For i = 0 To lbx_CSVFields.Items.Count - 1
                If lbx_CSVFields.GetSelected(i) Then


                    'check to see if it is already there
                    Dim Existing As Boolean = False
                    For u As Integer = 0 To dgv_SelectedFields.Rows.Count - 1
                        If dgv_SelectedFields.Rows(u).Cells(0).Value = lbx_CSVFields.SelectedItem Then
                            Existing = True
                        End If
                    Next

                    If Not Existing Then
                        dgv_SelectedFields.Rows.Add(lbx_CSVFields.SelectedItem)
                    End If

                End If
            Next
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_AddAllDocumentField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddAllDocumentField.Click
        Dim i As Integer
        Try
            dgv_SelectedFields.Rows.Clear()
            For i = 0 To lbx_CSVFields.Items.Count - 1
                'lbx_SelectedFields.Items.Add(lbx_CSVFields.Items(i))
                dgv_SelectedFields.Rows.Add(lbx_CSVFields.Items(i))
            Next
            'lbx_CSVFields.Items.Clear()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_RemoveDocumentField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RemoveDocumentField.Click
        Dim i As Integer
        Try
            'For i = 0 To dgv_SelectedFields.Rows.Count - 1
            'If dgv_SelectedFields.Rows.GetSelected(i) Then

            'lbx_CSVFields.Items.Add(lbx_SelectedFields.Items(i))
            dgv_SelectedFields.Rows.RemoveAt(dgv_SelectedFields.SelectedRows(0).Index)

            'End If
            'Next
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_RemoveAllDocumentField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RemoveAllDocumentField.Click
        Dim i As Integer
        Try
            For i = 0 To dgv_SelectedFields.Rows.Count - 1
                'lbx_CSVFields.Items.Add(lbx_SelectedFields.Items(i))
            Next
            dgv_SelectedFields.Rows.Clear()
        Catch ex As Exception
        End Try

    End Sub


    Private Sub btn_ImportDocumentAssociations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ImportDocumentAssociations.Click
        Dim query As String = Nothing
        Dim dt As New DataTable
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        If Me.cbx_FieldSelectTag.Text = "" Then
            MessageBox.Show("Please select Tag# field.")
            Me.Cursor = Cursors.Default
            Return
        End If

        If runtime.SiteName = "BP001" Then
            If Me.cbx_EPT.Text = "" Then
                MessageBox.Show("Please select EPT# field.")
                Me.Cursor = Cursors.Default
                Return
            End If
        End If

        For i As Integer = 0 To dgv1.Rows.Count - 1
            For u As Integer = 0 To dgv_SelectedFields.Rows.Count - 1
                Dim ColumnName As String = dgv_SelectedFields.Rows(u).Cells(0).Value
                Dim DocName As String
                If Not IsDBNull(dgv1.Rows(i).Cells(ColumnName).Value.ToString) Then
                    DocName = dgv1.Rows(i).Cells(ColumnName).Value.ToString
                Else
                    DocName = ""
                End If
                Dim DocType As String = dgv_SelectedFields.Rows(u).Cells(1).Value
                Dim TagID As String = Utilities.TranslateTagNumber(dgv1.Rows(i).Cells(cbx_FieldSelectTag.Text).Value)

                If Not DocName = "" And Not TagID = "" Then

                    'check to see if document number exists
                    Dim DocumentID As String = CheckDocumentExists(DocName)
                    If DocumentID = "" And Me.ckbx_ReferenceOverride.Checked Then
                        'if it doesn't, create a document record WITHOUT document using rev 0, sheet 1 of 1, and selected project
                        CreateDocumentReference(DocName, DocType)
                        DocumentID = CheckDocumentExists(DocName)
                    End If

                    'check to see if association already exists for package
                    If Not TagID = "0" And Not DocumentID = "" Then
                        Dim dt_PackageInfo As DataTable = Me.GetPackageInfo(TagID)
                        Dim PackageID As String = dt_PackageInfo.Rows(0)(0)
                        Dim SystemMUID As String = dt_PackageInfo.Rows(0)(1)
                        Dim dt_param As DataTable = sqlPrjUtils.paramDT

                        If CheckDocumentAssociationExists(DocumentID, PackageID, TagID) Then

                        ElseIf CheckDocumentAssociationExists(DocumentID, PackageID) Then
                            'update association with * for multi tag use
                            query = " UPDATE package_documents SET TagMUID = @TagMUID, SystemMUID = @SystemMUID " + _
                                    " WHERE DocumentMUID = @DocumentMUID AND PackageMUID = @PackageMUID"

                            dt_param.Rows.Add("@TagMUID", "0")
                            dt_param.Rows.Add("@SystemMUID", SystemMUID)
                            dt_param.Rows.Add("@DocumentMUID", DocumentID.ToString)
                            dt_param.Rows.Add("@PackageMUID", PackageID.ToString)

                            Try
                                sqlPrjUtils.ExecuteNonQuery(query, dt_param)
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        Else
                            'create the association using the DocumentID
                            Dim muid = idUtils.GetNextMUID("project", "package_documents")
                            query = " INSERT INTO package_documents " & _
                                " (MUID, TS,DocumentMUID,PackageMUID,TagMUID,SystemMUID) " & _
                                " Values (@MUID, @TS,@DocumentMUID,@PackageMUID,@TagMUID,@SystemMUID)"
                            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "package_documents"))
                            dt_param.Rows.Add("@DocumentMUID", DocumentID.ToString)
                            dt_param.Rows.Add("@PackageMUID", PackageID.ToString)
                            dt_param.Rows.Add("@TagMUID", TagID.ToString)
                            dt_param.Rows.Add("@SystemMUID", SystemMUID)
                            dt_param.Rows.Add("@TS", DateAndTime.Now.ToString)
                            Try
                                sqlPrjUtils.ExecuteNonQuery(query, dt_param)
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        End If
                    End If
                End If
            Next
        Next
        Me.Cursor = Cursors.Default
        Me.Enabled = True
        MessageBox.Show("Document Association Imported!")
    End Sub


    Private Function CheckDocumentExists(ByVal DocumentName As String) As String
        Dim query As String = Nothing
        Dim DocumentID As String = ""
        query = " Select MUID,EngCode FROM documents WHERE EngCode = '" + DocumentName + "' AND ProjectMUID = '" + runtime.selectedProjectID + "' Order By Sheet ASC, Revision DESC"

        Try
            Dim dt As DataTable = sqlDaqument.ExecuteQuery(query)

            If Not dt.Rows.Count = 0 Then
                DocumentID = dt.Rows(0)("MUID")
            Else
                query = " Select MUID,ClientCode FROM documents WHERE ClientCode = '" + DocumentName + "' AND ProjectMUID = '" + runtime.selectedProjectID + "' Order By Sheet ASC, Revision DESC"
                dt = sqlDaqument.ExecuteQuery(query)

                If Not dt.Rows.Count = 0 Then
                    DocumentID = dt.Rows(0)("MUID")
                Else
                    DocumentID = ""
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SQL Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return DocumentID
    End Function


    Private Function CheckDocumentAssociationExists(ByVal DocumentID As String, ByVal PackageID As String) As Boolean
        Dim query As String = Nothing

        query = " Select * FROM package_documents WHERE DocumentMUID = '" + DocumentID.ToString + "' AND PackageMUID = '" + PackageID.ToString + "'"
        Try
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

            If Not dt.Rows.Count = 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Function CheckDocumentAssociationExists(ByVal DocumentID As String, ByVal PackageID As String, ByVal _TagID As String) As Boolean
        Dim query As String = Nothing

        query = " Select * FROM package_documents WHERE DocumentMUID = '" + DocumentID.ToString + _
                "' AND PackageMUID = '" + PackageID.ToString + "'" & _
                " AND TagMUID = '" + _TagID + "'"
        Try
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

            If Not dt.Rows.Count = 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Sub CreateDocumentReference(ByVal DocumentName As String, ByVal DocumentType As String)
        Dim query As String = Nothing
        Dim DocumentID As String = ""
        Dim muid As String = idUtils.GetNextMUID("Daqument", "documents")
        query = " INSERT INTO documents " & _
            " (MUID, TS,EngCode,ClientCode,Revision,DateLoaded,Description,Sheet,Sheets,DocumentTypeMUID,ProjectMUID,DocumentPath) " & _
            " Values (" & _
            "'" + muid + "'," & _
            "'" + Now() + "'," & _
            "'" + DocumentName + "'," & _
            "'" + DocumentName + "'," & _
            "'000-'," & _
            "'" + Now() + "'," & _
            "'**Document loaded through association import - description needed**'," & _
            "'1'," & _
            "'1'," & _
            "'" + DocumentType.ToString + "'," & _
            "'" + Utilities.GetProjectID(runtime.selectedProject).ToString + "'," & _
            "'001')"

        Try
            'Utilities.ExecuteRemoteNonQuery(query, "")
            sqlDaqument.OpenConnection()

            Dim dt_param As DataTable = sqlDaqument.paramDT
            sqlDaqument.ExecuteNonQuery(query, dt_param)

            sqlDaqument.CloseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCreateTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateTemplate.Click
        If fileName.Text = "" Then
            MessageBox.Show("Please select CSV file name")
            Return
        End If
        Dim fm As Form = New pkgAuxTemplate("Tag", Me.fileName.Text)
        fm.ShowDialog()
        PopulatecboTemplateName()
        If cboTemplateName.Items.Count > 0 Then
            PopulateAuxFieldNames()
            cboTemplateName.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboTemplateName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTemplateName.SelectedIndexChanged
        If Not Me.cboTemplateName.Enabled Then Return
        If Loading Then Return
        PopulateAuxFieldNames()
    End Sub

    Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter

        'make list of template mapped columns
        PopulatecboTemplateName()


    End Sub

    Private Sub dgv_AuxFieldsMap_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_AuxFieldsMap.DataError

        Dim DataErr As Boolean = True
        Dim ErrMsg As String = e.Exception.Message

    End Sub

    Private Sub cboTagNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTagNumber.SelectedIndexChanged
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
    End Sub

    Private Sub cboPkgNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPkgNum.SelectedIndexChanged
    End Sub
    Private Function CheckValidPackageValues() As Boolean
        If Me.cboPkgNum.Text = "" Then Return False
        dgv1.ClearSelection()
        For i As Integer = 0 To dgv1.Rows.Count - 1
            dgv1.Rows(i).DefaultCellStyle.BackColor = Color.White
            'Check for duplicate/balnk Pkg Numbers
            Dim ColumnNum As String = Me.cboPkgNum.Text
            Dim Name As String = dgv1.Rows(i).Cells(ColumnNum).Value.ToString
            dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Color.White
            Dim rt As Boolean = False
            If Strings.LTrim(Name) = "" Then
                dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorBlank.BackColor
                'dgv1.Columns(i).DefaultCellStyle.BackColor = Me.tbx_ColorBlank.BackColor
                If firstErrRow < 0 Then
                    firstErrRow = i
                    CSVDataError = True
                    firstErrMsg = "Blank Pkg numbers in the CSV File: Row#:" + i.ToString
                End If
            Else
                Dim foundRow As DataRow = pkgNumTbl.Rows.Find(Name)
                If foundRow Is Nothing Then
                    dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorInvalid.BackColor
                    If firstErrRow < 0 Then
                        firstErrRow = i
                        CSVDataError = True
                        firstErrMsg = "Invalid Package Number in the CSV File: Row#:" + i.ToString
                    End If
                End If
            End If
        Next
    End Function
    Private Function CheckValidTypeNames() As Boolean
        If Me.cboType.Text = "" Then Return False
        dgv1.ClearSelection()
        For i As Integer = 0 To dgv1.Rows.Count - 1
            dgv1.Rows(i).DefaultCellStyle.BackColor = Color.White
            'Check for duplicate/balnk Pkg Numbers
            Dim ColumnNum As String = Me.cboType.Text
            Dim Name As String = dgv1.Rows(i).Cells(ColumnNum).Value.ToString
            dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Color.White
            Dim rt As Boolean = False
            If Strings.LTrim(Name) = "" Then
                dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorBlank.BackColor
                'dgv1.Columns(i).DefaultCellStyle.BackColor = Me.tbx_ColorBlank.BackColor
                If firstErrRow < 0 Then
                    firstErrRow = i
                    CSVDataError = True
                    firstErrMsg = "Blank Type Name in the CSV File: Row#:" + i.ToString
                End If
            Else
                Dim foundRow As DataRow = TypeIDTbl.Rows.Find(dgv1.Rows(i).Cells(ColumnNum).Value.ToString)
                If foundRow Is Nothing Then
                    dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorInvalid.BackColor
                    If firstErrRow < 0 Then
                        firstErrRow = i
                        CSVDataError = True
                        firstErrMsg = "Invalid Type Name in the CSV File: Row#:" + i.ToString
                    End If
                End If
            End If
        Next
        Return CSVDataError
    End Function

    Private Function CheckValidTagValues() As Boolean
        If Me.cboTagNumber.Text = "" Then Return False
        dgv1.ClearSelection()
        For i As Integer = 0 To dgv1.Rows.Count - 1
            dgv1.Rows(i).DefaultCellStyle.BackColor = Color.White
            'Check for duplicate/balnk Pkg Numbers
            Dim ColumnNum As String = Me.cboTagNumber.Text
            Dim Name As String = dgv1.Rows(i).Cells(ColumnNum).Value.ToString
            dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Color.White
            Dim rt As Boolean = False
            If Strings.LTrim(Name) = "" Then
                dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorBlank.BackColor
                If firstErrRow < 0 Then
                    firstErrRow = i
                    CSVDataError = True
                    firstErrMsg = "Blank Tag numbers in the CSV File: Row#:" + i.ToString
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
                    If firstErrRow < 0 Then
                        firstErrRow = i
                        CSVDataError = True
                        firstErrMsg = "Duplicate Tag numbers in the CSV File"
                    End If
                End If
            End If
        Next
    End Function


    Private Function ErrorCheck() As Boolean

        firstErrColumn = ""
        firstErrRow = -1
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
        If Me.cboTagNumber.Text = "" Then
            MessageBox.Show("Missing the mapping of the 'Tag Number' field")
            Return True
        End If
        If Me.cboPkgNum.Text = "" Then
            MessageBox.Show("Missing the mapping of the 'Package Number' field")
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        CheckValidTagValues()

        CheckValidPackageValues()

        CheckValidTypeNames()

        Me.Cursor = Cursors.Default
        Me.Enabled = True

        Return CSVDataError

    End Function

    'Private Sub ErrorCheck()
    '    CSVDataError = False
    '    firstErrColumn = -1
    '    firstErrRow = -1
    '    Dim errLine As Integer = 0
    '    CheckDupliacteTagNumbers()
    '    If CSVDataError Then
    '        ShowError("* Duplicate Tags in Import File", errLine, Color.Red)
    '        errLine = errLine + 1
    '    End If
    '    CheckBlankTagNumbers()
    '    If CSVDataError Then
    '        ShowError("* Blank Tags in Import File", errLine, Color.Red)
    '        errLine = errLine + 1
    '    End If
    '    CheckInvalidPackageNumbers()
    '    If CSVDataError Then
    '        ShowError("* Invalid Package number in Import File", errLine, Color.Red)
    '        errLine = errLine + 1
    '    End If
    '    CheckInvalidTypeNames()
    '    If CSVDataError Then
    '        ShowError("* Invalid Equipment Type in Import File", errLine, Color.Red)
    '        errLine = errLine + 1
    '    End If
    '    Return
    'End Sub

    Private Sub btnCheckData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckData.Click
        If Not ErrorCheck() Then
            Me.btnUploadPkgNums.Enabled = True
        End If
        If CSVDataError Then
            Me.lbl_error0.ForeColor = Color.Red
            Me.lbl_error0.Text = firstErrMsg
            msgResult = MessageBox.Show(firstErrMsg + firstErrRow.ToString, Caption, MessageBoxButtons.OK)
        Else
            Me.lbl_error0.Text = "No error found"
            Me.lbl_error0.ForeColor = Color.Green
            Me.btnUploadPkgNums.Enabled = True
            msgResult = MessageBox.Show("No error found", Caption, MessageBoxButtons.OK)
        End If
    End Sub


    Private Sub TagImport_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        sqlPrjUtils.CloseConnection()
        sqlDaqument.CloseConnection()
    End Sub


    Private Sub btn_CheckTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CheckTags.Click
        Me.Cursor = Cursors.WaitCursor
        CheckTags()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CheckTags()
        CSVDataError = False
        If Me.cbx_FieldSelectTag.Text = "" Then
            MessageBox.Show("Tag Number column not mapped.", "Error")
            Return
        End If
        dgv1.ClearSelection()

        Me.dt_TagErrors.Clear()
        Me.dt_TagErrors.Columns.Clear()
        Me.dt_TagErrors.Columns.Add("Tag")
        For u As Integer = 0 To dgv_SelectedFields.Rows.Count - 1
            Dim ColumnName As String = dgv_SelectedFields.Rows(u).Cells(0).Value
            Me.dt_TagErrors.Columns.Add(ColumnName)
        Next

        For i As Integer = 0 To dgv1.Rows.Count - 1
            dgv1.Rows(i).DefaultCellStyle.BackColor = Color.White

            Dim ColumnNum As String = Me.cbx_FieldSelectTag.Text
            Dim Name As String = dgv1.Rows(i).Cells(ColumnNum).Value.ToString
            dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Color.White
            Dim rt As Boolean = False
            If Strings.LTrim(Name) = "" Then
                dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorBlank.BackColor
                CSVDataError = True
            Else
                Dim query As String = "SELECT * FROM tags WHERE TagNumber = '" + dgv1.Rows(i).Cells(ColumnNum).Value + "'"
                Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

                If dt.Rows.Count = 0 Then
                    CSVDataError = True
                    dgv1.Rows(i).Cells(ColumnNum).Style.BackColor = Me.tbx_ColorInvalid.BackColor

                    Me.dt_TagErrors.Rows.Add()
                    Me.dt_TagErrors.Rows(Me.dt_TagErrors.Rows.Count - 1)("Tag") = dgv1.Rows(i).Cells(ColumnNum).Value

                    For u As Integer = 0 To dgv_SelectedFields.Rows.Count - 1
                        Dim ColumnName As String = dgv_SelectedFields.Rows(u).Cells(0).Value
                        Me.dt_TagErrors.Rows(Me.dt_TagErrors.Rows.Count - 1)(u + 1) = dgv1.Rows(i).Cells(ColumnName).Value
                    Next

                End If
            End If
        Next

        If CSVDataError Then
            MessageBox.Show("Errors in data grid, please correct then check again.", "Error")
        End If

    End Sub


    Private Sub btn_CheckDrawings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CheckDrawings.Click
        Dim query As String = Nothing
        Dim dt As New DataTable
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        Me.dt_DrawingErrors.Clear()
        Me.dt_DrawingErrors.Columns.Clear()
        Me.dt_DrawingErrors.Columns.Add("Tag")
        For u As Integer = 0 To dgv_SelectedFields.Rows.Count - 1
            Dim ColumnName As String = dgv_SelectedFields.Rows(u).Cells(0).Value
            Me.dt_DrawingErrors.Columns.Add(ColumnName)
        Next

        Dim existing As Boolean = True
        For i As Integer = 0 To dgv1.Rows.Count - 1
            Dim TagColumn As String = Me.cbx_FieldSelectTag.Text
            Dim ErrorAdded As Boolean = False
            For u As Integer = 0 To dgv_SelectedFields.Rows.Count - 1
                Dim ColumnName As String = dgv_SelectedFields.Rows(u).Cells(0).Value
                Dim DocName As String
                If Not IsDBNull(dgv1.Rows(i).Cells(ColumnName).Value.ToString) Then
                    DocName = dgv1.Rows(i).Cells(ColumnName).Value.ToString
                Else
                    DocName = ""
                End If
                Dim DocType As String = dgv_SelectedFields.Rows(u).Cells(1).Value

                If Not DocName = "" Then
                    Dim DocumentID As String = CheckDocumentExists(DocName)
                    If DocumentID = "" Then
                        existing = False
                        dgv1.Rows(i).Cells(ColumnName).Style.BackColor = Me.tbx_ColorInvalid.BackColor

                        If Not ErrorAdded Then
                            Me.dt_DrawingErrors.Rows.Add()
                            Me.dt_DrawingErrors.Rows(Me.dt_DrawingErrors.Rows.Count - 1)("Tag") = dgv1.Rows(i).Cells(TagColumn).Value

                            'query = "SELECT * FROM tags WHERE TagNumber = '" + dgv1.Rows(u).Cells(ColumnName).Value + "'"
                            'dt = sqlPrjUtils.ExecuteQuery(query)

                            'If dt.Rows.Count = 0 Then
                            '    Me.dt_DrawingErrors.Rows(Me.dt_DrawingErrors.Rows.Count - 1)("New Tag") = "Yes"
                            'Else
                            '    Me.dt_DrawingErrors.Rows(Me.dt_DrawingErrors.Rows.Count - 1)("New Tag") = "No"
                            'End If

                            ErrorAdded = True
                        End If

                        Me.dt_DrawingErrors.Rows(Me.dt_DrawingErrors.Rows.Count - 1)(ColumnName) = dgv1.Rows(i).Cells(ColumnName).Value
                    End If
                End If
            Next
        Next
        Me.Cursor = Cursors.Default
        Me.Enabled = True
        If existing Then
            MessageBox.Show("Documents Checked.")
        Else
            MessageBox.Show("Some Document References do not exist.  Check grid then validate again.")
        End If
    End Sub


    Private Sub btn_SaveDrawings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SaveDrawings.Click
        Dim frm_ShowExport As New CommonForms.DataExport(Me.dt_DrawingErrors)
        frm_ShowExport.Show()
    End Sub


    Private Sub btn_SaveTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SaveTags.Click
        Dim frm_ShowExport As New CommonForms.DataExport(Me.dt_TagErrors)
        frm_ShowExport.Show()
    End Sub


    Private Function GetPackageInfo(ByVal _MUID As String) As DataTable
        Dim query As String = "Select tags.PackageMUID,package.SystemMUID FROM tags,package WHERE tags.PackageMUID=package.MUID AND tags.MUID='" & _MUID.ToString & "'"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

        Return dt
    End Function
End Class
