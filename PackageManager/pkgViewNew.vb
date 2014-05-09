Imports System.Drawing
Imports System.Collections
'Imports System.Data.SqlServerCe
Imports daqartDLL
'Public Class pkgViewNew
'Const MAXSYNONYMS = 40
'Public Shared SelectedMapFieldItems As ListView.SelectedListViewItemCollection
'Private CurrentDiscID As Integer
'Private tbl_aux_fieldmap As DataTable
'Private tbl_tmppackage As DataTable
'Private pkgBS As BindingSource
'Private pkgDS As DataSet
'Private cboDS As DataSet
'Private pkgBN As BindingNavigator
'Private pkgDGV1 As DataGridView

'Dim posArray As Array
'Dim idArray As Array
'Dim maxFields As Integer
'Private fieldNames(MAXSYNONYMS) As String
'Private OriginalFieldNames(MAXSYNONYMS) As String
'Private lblControls(MAXSYNONYMS) As Label
'Private cbolblControls(MAXSYNONYMS) As Label
'Private cboControls(MAXSYNONYMS) As ComboBox
'Private txtControls(MAXSYNONYMS) As TextBox
'Private rptControls(MAXSYNONYMS) As CheckBox
'Private rptlblControls(MAXSYNONYMS) As Label
'Private Function filterForm(ByVal initial As Boolean) As String
'    Dim i, strLen As Integer
'    Static Dim strFilter As String
'    Dim strParse As String
'    Dim nextPos, currentPos As Integer
'    Dim strFieldName As String
'    If initial Then
'        strFilter = " WHERE package.MUID = aux_package.packageMUID AND (DisciplineMUID = " + CurrentDiscID.ToString + ") "
'    End If
'    For i = 0 To maxFields - 1
'        If cboControls(i).Text > "" Then
'            If strFilter > "" Then
'                strFilter = strFilter & " AND "
'            End If
'            currentPos = 1
'            nextPos = Len(cboControls(i).Text)
'            strParse = ""
'            If InStr(cboControls(i).Text, "*") > 0 Then
'                strParse = " [" & OriginalFieldNames(i) & "] LIKE '" & cboControls(i).Text & "' "
'            ElseIf InStr(UCase(cboControls(i).Text), "blank fields") Then
'                strParse = " [" & OriginalFieldNames(i) & "] Is Nothing "
'            ElseIf InStr(UCase(cboControls(i).Text), "non blank fields") Then
'                strParse = " [" & OriginalFieldNames(i) & "] Not Is Nothing " & UCase(cboControls(i).Text) & " "
'            Else
'                strFieldName = " [" & OriginalFieldNames(i) & "] = '"
'                If InStr(currentPos, cboControls(i).Text, ",") > 0 Then
'                    strLen = Len(cboControls(i))
'                    Do While InStr(currentPos, cboControls(i).Text, ",") > 0
'                        nextPos = InStr(currentPos, cboControls(i).Text, ",")
'                        strLen = nextPos - currentPos
'                        strParse = strParse & strFieldName & _
'                                    Mid(cboControls(i).Text, currentPos, strLen) & "' OR "
'                        currentPos = nextPos + 1
'                    Loop
'                    strLen = Len(cboControls(i)) - nextPos
'                    strParse = strParse & strFieldName & _
'                                  Mid(cboControls(i).Text, currentPos, strLen) & "' "
'                Else
'                    strParse = strParse & strFieldName & cboControls(i).Text & "' "
'                End If
'            End If
'            strFilter = strFilter & "(" & strParse & ")"
'        End If
'    Next i
'    filterForm = strFilter
'End Function

'Private Sub LoadComboBoxes()
'    Dim query As String
'    Dim i As Integer
'    Dim strFilter As String
'    strFilter = filterForm(False)
'    If Not (cboDS Is Nothing) Then
'        cboDS.Dispose()
'    End If
'    cboDS = New DataSet("ash_dsp")
'    For i = 0 To maxFields - 1
'        query = " SELECT DISTINCT [" & OriginalFieldNames(i) & "] FROM package, aux_package " + strFilter + _
'                 " ORDER By [" + OriginalFieldNames(i) + "]"
'        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

'        sqlPrjUtils.OpenConnection()
'        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

'        cmd.CommandText = query
'        Dim adapter As SqlCeDataAdapter = New SqlCeDataAdapter(query, connProject)
'        cboDS.Tables.Add(OriginalFieldNames(i))

'        adapter.FillSchema(cboDS.Tables(OriginalFieldNames(i)), SchemaType.Mapped)
'        adapter.Fill(cboDS.Tables(OriginalFieldNames(i)))
'        Dim drNewRow1 As DataRow = cboDS.Tables(OriginalFieldNames(i)).NewRow()
'        drNewRow1(0) = "<blank fields>"
'        cboDS.Tables(OriginalFieldNames(i)).Rows.InsertAt(drNewRow1, 0)
'        Dim drNewRow2 As DataRow = cboDS.Tables(OriginalFieldNames(i)).NewRow()
'        drNewRow2(0) = "<non blank fields>"
'        cboDS.Tables(OriginalFieldNames(i)).Rows.InsertAt(drNewRow2, 0)
'        cboControls(i).DataSource = cboDS.Tables(OriginalFieldNames(i))
'        cboControls(i).DisplayMember = OriginalFieldNames(i)
'        cboControls(i).ValueMember = OriginalFieldNames(i)
'        cboControls(i).Refresh()
'        cboControls(i).Enabled = True
'        cboControls(i).Text = Nothing
'        adapter.Dispose()
'    Next i
'End Sub

'Private Sub tabFieldAttributeViewSetup()
'    Dim i As Integer
'    TabControl1.SelectTab(2)
'    lvwMapFile.Clear()
'    lvwMapFile.View = View.Details
'    lvwMapFile.LabelEdit = True
'    lvwMapFile.AllowColumnReorder = True
'    ' Display check boxes.
'    '        lvwMapFile.CheckBoxes = True
'    lvwMapFile.FullRowSelect = True
'    lvwMapFile.GridLines = True
'    '        lvwMapFile.Sorting = SortOrder.Ascending

'    ' Create three items and three sets of subitems for each item.
'    ' Place a check mark next to the item.
'    ' Create columns for the items and subitems.
'    lvwMapFile.Columns.Add("tblField Name", -2, HorizontalAlignment.Left)
'    lvwMapFile.Columns.Add("Field Name", -2, HorizontalAlignment.Left)
'    lvwMapFile.Columns.Add("Data Type", -2, HorizontalAlignment.Left)
'    lvwMapFile.Columns.Add("Wt Pcntg", -2, HorizontalAlignment.Left)
'    lvwMapFile.Columns.Add("Color", -2, HorizontalAlignment.Center)
'    lvwMapFile.Columns.Add("ColumnView", -2, HorizontalAlignment.Center)
'    lvwMapFile.Columns(0).Width = 0
'    lvwMapFile.Columns(1).Width = 100
'    lvwMapFile.Columns(2).Width = 70
'    lvwMapFile.Columns(3).Width = 70
'    lvwMapFile.Columns(4).Width = 50
'    lvwMapFile.Columns(5).Width = 70

'    'Add the items to the ListView.
'    '       lvwMapFile.Items.AddRange(New ListViewItem() {item(i)})
'    ' Create two ImageList objects.
'    Dim imageListSmall As New ImageList()
'    Dim imageListLarge As New ImageList()

'    ' Initialize the ImageList objects with bitmaps.
'    '        imageListSmall.Images.Add(Bitmap.FromFile("C:\MySmallImage1.bmp"))
'    '      imageListSmall.Images.Add(Bitmap.FromFile("C:\MySmallImage2.bmp"))
'    '     imageListLarge.Images.Add(Bitmap.FromFile("C:\MyLargeImage1.bmp"))
'    '    imageListLarge.Images.Add(Bitmap.FromFile("C:\MyLargeImage2.bmp"))

'    'Assign the ImageList objects to the ListView.
'    lvwMapFile.LargeImageList = imageListLarge
'    lvwMapFile.SmallImageList = imageListSmall

'    Dim cmd As SqlCeCommand = connProject.CreateCommand()
'    Dim query = "SELECT * FROM aux_fieldmap WHERE (DisciplineID = " + CurrentDiscID.ToString + ")"
'    Dim adapter As SqlCeDataAdapter = New SqlCeDataAdapter(query, connProject)
'    Dim pkgTable As DataTable = New DataTable("aux_fieldmap")
'    adapter.FillSchema(pkgTable, SchemaType.Mapped)
'    adapter.Fill(pkgTable)
'    For i = 0 To pkgTable.Rows.Count - 1
'        Dim Row As DataRow = pkgTable.Rows(i)
'        If (Row("auxFieldMap").ToString > "") Then
'            Dim item As New ListViewItem(Row("auxField").ToString)
'            If Row("auxFieldColor").ToString > "" Then
'                item.BackColor = Color.FromArgb(Row("auxFieldColor").ToString)
'            End If
'            item.SubItems.Add(Row("auxFieldMap").ToString)
'            item.SubItems.Add(Row("auxFieldDataType").ToString)
'            item.SubItems.Add(Row("auxFieldWtPcnt").ToString)
'            item.SubItems.Add(Row("auxFieldColor").ToString)
'            item.SubItems.Add(Row("auxFieldView").ToString)
'            lvwMapFile.Items.AddRange(New ListViewItem() {item})
'        End If
'    Next
'End Sub

'Private Sub tabFormViewSetup()
'    Dim i As Integer
'    Dim X As Integer = TabControl1.Location.X
'    Dim Y As Integer = TabControl1.Location.Y
'    Dim Row As Integer = 0 : Dim Col As Integer = 0
'    For i = 0 To maxFields - 1

'        lblControls(i) = New System.Windows.Forms.Label()
'        lblControls(i).Text = fieldNames(i)
'        lblControls(i).Location = New System.Drawing.Point(X + Col * 23, Y + Row * 23)
'        lblControls(i).Size = New System.Drawing.Size(80, 23)
'        lblControls(i).TextAlign = ContentAlignment.TopRight
'        txtControls(i) = New System.Windows.Forms.TextBox()
'        txtControls(i).Location = New System.Drawing.Point(X + Col * 23 + 80, Y + Row * 23)
'        txtControls(i).Size = New System.Drawing.Size(120, 23)
'        txtControls(i).DataBindings.Add(New Binding("Text", pkgBS, pkgDS.Tables("tmppackage").Columns(i).ColumnName, True))
'        TabControl1.SelectTab(0)
'        TabControl1.SelectedTab.Controls.Add(lblControls(i))
'        TabControl1.SelectedTab.Controls.Add(txtControls(i))


'        cboControls(i) = New System.Windows.Forms.ComboBox()
'        cboControls(i).Location = New System.Drawing.Point(X + Col * 23 + 80, Y + Row * 23)
'        cboControls(i).Size = New System.Drawing.Size(120, 23)
'        cbolblControls(i) = New System.Windows.Forms.Label()
'        cbolblControls(i).Text = fieldNames(i)
'        cbolblControls(i).Location = New System.Drawing.Point(X + Col * 23, Y + Row * 23)
'        cbolblControls(i).Size = New System.Drawing.Size(80, 23)
'        TabControl1.SelectTab(1)
'        TabControl1.SelectedTab.Controls.Add(cboControls(i))
'        TabControl1.SelectedTab.Controls.Add(cbolblControls(i))


'        rptControls(i) = New System.Windows.Forms.CheckBox()
'        rptControls(i).Location = New System.Drawing.Point(X + Col * 23 + 80, Y + Row * 23)
'        rptControls(i).Size = New System.Drawing.Size(80, 23)
'        rptlblControls(i) = New System.Windows.Forms.Label()
'        rptlblControls(i).Text = fieldNames(i)
'        rptlblControls(i).Location = New System.Drawing.Point(X + Col * 23, Y + Row * 23)
'        rptlblControls(i).Size = New System.Drawing.Size(80, 23)
'        TabControl1.SelectTab(3)
'        TabControl1.SelectedTab.Controls.Add(rptControls(i))
'        TabControl1.SelectedTab.Controls.Add(rptlblControls(i))
'        Row = Row + 1
'        If Row > 10 Then
'            Col = Col + 1 : Row = 0
'            X = X + 200
'        End If
'    Next
'End Sub


'Private Sub tbl_aux_fieldmapReload_by_Order(ByVal OrderStr As String)
'    If Not tbl_aux_fieldmap Is Nothing Then
'        tbl_aux_fieldmap.Dispose()
'    End If
'    Try
'        Dim query As String = "SELECT auxField, auxFieldMap, auxFieldColor, auxFieldPosition, idaux_fieldmap FROM aux_fieldmap WHERE " + _
'                    " (MainTable = 'Package') AND " + _
'                    " (auxFieldMap > '') AND " + _
'                    " (DisciplineID = " + CurrentDiscID.ToString + ") " + OrderStr + ";"
'        Dim adapter As SqlCeDataAdapter = New SqlCeDataAdapter(query, connProject)
'        tbl_aux_fieldmap = New DataTable("aux_fieldmap")
'        adapter.FillSchema(tbl_aux_fieldmap, SchemaType.Mapped)
'        adapter.Fill(tbl_aux_fieldmap)
'        adapter.Dispose()
'    Catch ex As Exception
'    End Try

'End Sub

'Public Sub tblGDVReload()
'    Dim i As Integer
'    Dim fieldStr As String = ""
'    Try
'        If Not (pkgDS Is Nothing) Then
'            pkgDS.Dispose()
'        End If
'        If Not (pkgBS Is Nothing) Then
'            pkgBS.Dispose()
'        End If
'        If Not (pkgDGV1 Is Nothing) Then
'            pkgDGV1.Dispose()
'        End If
'        If Not (pkgBN Is Nothing) Then
'            pkgBN.Dispose()
'        End If
'        OriginalFieldNames(0) = "packageNumber"

'        For i = 1 To tbl_aux_fieldmap.Rows.Count - 1
'            Dim Row As DataRow = tbl_aux_fieldmap.Rows(i)
'            fieldStr = fieldStr + "[" + (Row("auxField") + "] As [" + Row("auxFieldMap") + "],")
'            OriginalFieldNames(i) = Row("auxField")
'        Next

'        fieldStr = fieldStr.Remove(fieldStr.Length - 1, 1)
'        Dim query = "SELECT package.packageNumber, " + fieldStr + _
'                    " FROM aux_package, package " + filterForm(False)

'        '" WHERE package.packageID = aux_package.pkgID AND (DisciplineID = " + CurrentDiscID.ToString + ");"

'        Dim adapter As SqlCeDataAdapter = New SqlCeDataAdapter(query, connProject)
'        pkgDS = New DataSet("ash_dsp")
'        pkgDS.Tables.Add("tmppackage")

'        adapter.FillSchema(pkgDS.Tables("tmppackage"), SchemaType.Mapped)
'        adapter.Fill(pkgDS.Tables("tmppackage"))
'        pkgBS = New BindingSource
'        pkgBS.DataSource = pkgDS.Tables("tmppackage")
'        pkgBN = New BindingNavigator(True)
'        pkgBN.BindingSource = pkgBS
'        '       Me.pkgBN.BindingSource = pkgBS.DataSource
'        pkgDGV1 = New DataGridView
'        pkgDGV1.AutoGenerateColumns = True
'        pkgDGV1.DataSource = pkgBS
'        pkgDGV1.Dock = System.Windows.Forms.DockStyle.Bottom
'        Me.Controls.Add(pkgDGV1)
'        Me.Controls.Add(pkgBN)

'        pkgDGV1.Height = 340
'        pkgDGV1.BringToFront()

'        pkgBN.Dock = System.Windows.Forms.DockStyle.None
'        pkgBN.Location = New Point(0, 400)

'        For i = 0 To tbl_aux_fieldmap.Rows.Count - 1
'            Dim Row As DataRow = tbl_aux_fieldmap.Rows(i)
'            Dim myColor As String = Row("auxFieldColor").ToString
'            Dim ColumnHeading As String = Row("auxFieldMap").ToString
'            If myColor > "" Then
'                pkgDGV1.Columns(ColumnHeading).DefaultCellStyle.BackColor = Color.FromArgb(CType(myColor, Integer))
'                pkgDGV1.Columns(ColumnHeading).HeaderCell.Style.BackColor = Color.FromArgb(CType(myColor, Integer))
'            End If
'        Next
'        adapter.Dispose()
'        maxFields = 0
'        For i = 0 To pkgDGV1.Columns.Count - 1
'            fieldNames(i) = pkgDGV1.Columns(i).Name
'            maxFields = maxFields + 1
'        Next

'    Catch ex As Exception

'    End Try
'End Sub

'Public Sub New()

'    ' This call is required by the Windows Form Designer.
'    InitializeComponent()

'    ' Add any initialization after the InitializeComponent() call.
'End Sub

'Private Sub pkgViewNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'    Try

'        Me.Size = New Size(1000, 800)
'        connProject.Open()
'        connServer.Open()

'        CurrentDiscID = 1

'        tbl_aux_fieldmapReload_by_Order("ORDER By auxFieldPosition")
'        filterForm(True)
'        tblGDVReload()
'        If (tbl_aux_fieldmap.Rows.Count <= 1) Then
'            MessageBox.Show("No items found in this discipline, please use option 'Import Packages' to populate data")
'            Me.Close()
'        End If

'        Dim cmd As SqlCeCommand = connProject.CreateCommand()


'        Me.AuxMoveRightAll.Location = New System.Drawing.Point(500, 400)
'        Me.AuxMoveRight.Location = New System.Drawing.Point(450, 400)
'        Me.AuxMoveLeftAll.Location = New System.Drawing.Point(350, 400)
'        Me.AuxMoveLeft.Location = New System.Drawing.Point(400, 400)
'        tabFormViewSetup()
'        tabFieldAttributeViewSetup()
'        LoadComboBoxes()
'    Catch ex As Exception
'        Utilities.logErrorMessage("PkgViewNew.pkgViewNew_Load-" + ex.Message)
'        MessageBox.Show(ex.Message)
'    End Try


'End Sub
'Private Sub GetCurrentFieldPositions()
'    posArray = Array.CreateInstance(GetType(Int32), tbl_aux_fieldmap.Rows.Count)
'    idArray = Array.CreateInstance(GetType(Int32), tbl_aux_fieldmap.Rows.Count)
'    Dim i As Integer
'    For i = 0 To tbl_aux_fieldmap.Rows.Count - 1
'        Dim row As DataRow = tbl_aux_fieldmap.Rows(i)
'        posArray.SetValue(row("auxFieldPosition"), i)
'        idArray.SetValue(row("idaux_fieldmap"), i)
'    Next i
'End Sub
'Private Sub SetNewFieldPositions()
'    Dim cmd As SqlCeCommand = connProject.CreateCommand()
'    Dim i As Integer
'    For i = posArray.GetLowerBound(0) To posArray.GetUpperBound(0)
'        Dim strUpdate = "UPDATE aux_fieldmap SET auxFieldPosition = " + posArray(i).ToString + _
'                                            " WHERE DisciplineID = " + CurrentDiscID.ToString + _
'                                            " AND idaux_fieldmap = " + idArray(i).ToString + " ;"
'        cmd.CommandText = strUpdate
'        cmd.ExecuteNonQuery()
'    Next i
'End Sub
'Private Sub AuxMoveRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuxMoveRight.Click
'    '       tbl_aux_fieldmapReload_by_Order("ORDER By auxFieldPosition")
'    GetCurrentFieldPositions()
'    Dim i As Integer
'    Dim lastVal = posArray(posArray.GetLowerBound(0))
'    For i = posArray.GetLowerBound(0) To posArray.GetUpperBound(0) - 1
'        Dim nextVal = posArray(i + 1)
'        posArray.SetValue(nextVal, i)
'    Next i
'    posArray.SetValue(lastVal, i)
'    SetNewFieldPositions()
'    tbl_aux_fieldmapReload_by_Order("ORDER By auxFieldPosition")
'    tblGDVReload()
'End Sub


'Private Sub AuxMoveLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuxMoveLeft.Click
'    '        tbl_aux_fieldmapReload_by_Order("ORDER By auxFieldPosition")
'    GetCurrentFieldPositions()
'    Dim i As Integer
'    Dim FirstVal = posArray(posArray.GetUpperBound(0))
'    For i = posArray.GetUpperBound(0) - 1 To posArray.GetLowerBound(0) Step -1
'        Dim nextVal = posArray(i)
'        posArray.SetValue(nextVal, i + 1)
'    Next i
'    posArray.SetValue(FirstVal, 0)
'    SetNewFieldPositions()
'    tbl_aux_fieldmapReload_by_Order("ORDER By auxFieldPosition")
'    tblGDVReload()
'End Sub

'Private Sub AuxMoveLeftAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuxMoveLeftAll.Click
'    tbl_aux_fieldmapReload_by_Order("ORDER By idaux_fieldmap")
'    tblGDVReload()
'End Sub
'Private Sub AuxMoveRightAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuxMoveRightAll.Click
'    tbl_aux_fieldmapReload_by_Order("ORDER By idaux_fieldmap DESC")
'    tblGDVReload()
'    Return
'End Sub

'Private Sub EditMapButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMapButton.Click
'    Try
'        If SelectedMapFieldItems.Count > 0 Then

'            Dim Form As New fieldmap.Form1()
'            '       Form.BringToFront()
'            Form.UpdateMapFields()
'            Form.Open()
'            Form.ShowDialog()
'        End If
'    Catch ex As Exception
'        MessageBox.Show("Empty Map List: " + ex.Message)
'    End Try
'End Sub

'Private Sub BtnApplyChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApplyChanges.Click
'    Dim query As String = " DELETE FROM aux_fieldmap WHERE mainTable = 'package' AND" + _
'                        " DisciplineID = 1;"
'    Dim cmd As SqlCeCommand = connProject.CreateCommand

'    cmd.CommandText = query
'    cmd.ExecuteNonQuery()
'    Dim i As Integer
'    '        DataManager.ExecuteNonQuery(connProjectDB, "START TRANSACTION;")
'    Dim insStr As String = "INSERT INTO aux_fieldmap " + _
'        "(mainTable, auxField, auxFieldMap, auxFieldDataType,auxFieldWtPcnt,auxFieldColor,auxFieldView, DisciplineID, auxFieldPosition ) VALUES "
'    'Ignore ID and Time stamp
'    Dim valStr As String = ""
'    For i = 0 To lvwMapFile.Items.Count - 1
'        Dim auxField As String = lvwMapFile.Items(i).SubItems(0).Text
'        Dim auxFieldMap As String = lvwMapFile.Items(i).SubItems(1).Text
'        Dim auxFieldDataType As String = lvwMapFile.Items(i).SubItems(2).Text
'        Dim auxFieldWtPcnt As String = lvwMapFile.Items(i).SubItems(3).Text
'        Dim auxFieldColor As String = lvwMapFile.Items(i).SubItems(4).Text
'        Dim auxFieldView As String = lvwMapFile.Items(i).SubItems(5).Text
'        Dim auxFieldPosition As String = i.ToString

'        valStr = "('package','" + auxField + "','" + auxFieldMap + "','" + auxFieldDataType + _
'                "','" + auxFieldWtPcnt + "','" + auxFieldColor + _
'                "','" + auxFieldView + "'," + CurrentDiscID.ToString + "," + auxFieldPosition + ");"

'        query = insStr + valStr
'        cmd.CommandText = query
'        cmd.ExecuteNonQuery()
'    Next i

'    insStr = "INSERT INTO aux_fieldmap " + _
'                "(mainTable, auxField, auxFieldMap, auxFieldDataType,auxFieldView, DisciplineID, auxFieldPosition ) VALUES "
'    'Ignore ID and Time stamp
'    For i = lvwMapFile.Items.Count - 1 To MAXSYNONYMS - 1
'        valStr = "('package','auxField" + i.ToString + "','','TEXT','Fixed'," + _
'                CurrentDiscID.ToString + "," + i.ToString + ");"
'        query = insStr + valStr
'        cmd.CommandText = query
'        cmd.ExecuteNonQuery()
'    Next i
'    MessageBox.Show("The form must be reloaded")
'    Me.Close()
'    '        SetColumnsDefaultView()
'End Sub
'Private Sub lvwMapFile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwMapFile.SelectedIndexChanged
'    'Dim MapFields As ListView.SelectedListViewItemCollection = _
'    SelectedMapFieldItems = Me.lvwMapFile.SelectedItems
'End Sub

'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
'    tblGDVReload()
'    LoadComboBoxes()
'End Sub

'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
'    filterForm(True)
'    tblGDVReload()
'    LoadComboBoxes()
'End Sub
'End Class