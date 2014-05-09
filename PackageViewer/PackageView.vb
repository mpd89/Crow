'Imports System.Data.SqlServerCe
Imports daqartDLL
Imports ReferenceLibrary
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid


Public Class PackageView
    Public PackageID As String = ""
    Public TagID As String = ""
    Private PackageOwner As String
    Private PackageGroup As String
    Private PackageDiscipline As String
    Private PackageName As String
    Private PackageOwnerName As String
    Private SystemNumber As String
    Dim Loading As Boolean = True
    Dim labelObject As TextBox
    Dim WithEvents FieldTextBox As TextBox
    Dim WithEvents DiscrepancyObject As DiscrepancyManager.ControlDiscrepancy
    '  Dim WithEvents PunchlistObject As PunchlistManager.ControlPunchlist
    Dim TaglabelObject As TextBox
    Dim WithEvents TagFieldTextBox As TextBox
    Dim newLabelTop As Integer = 35
    Dim UserTable As DataTable
    Dim SelectedDocument As String
    Dim sqlPrjUtils As New DataUtils("project")
    Dim sqlSrvUtils As New DataUtils("server")
    Dim sqlDocUtils As New DataUtils("Daqument")
            
    Private PkgAuxTable As DataTable
    Private PkgAuxIDTable As DataTable

    Private TagAuxTable As DataTable
    Private TagAuxIDTable As DataTable

    Private AllTagIDs As New List(Of String)
    Private AllFormIDs As New List(Of String)
    Private AllOwnerIDs As New List(Of String)
    Private AllTypeIDs As New List(Of String)
    Private CurrentProjectID As String
    Private CurrentTypeID As String
    Private CurrentOwnerID As String
    Private CurrentPackageID As String
    Private CurrentTagID As String
    Private CurrentFormID As String
    Private CurrentSystemID As String
    Private CurrentFormLevel As Integer
    Private CurrentFormPercentComplete As Single
    Private CurrentFormEarnedManHours As Single
    Private CurrentFormRequiredManHours As Single
    Private CurrentTagLevel As Integer
    Private CurrentTagPercentComplete As Single
    Private CurrentTagEarnedManHours As Single
    Private CurrentTagRequiredManHours As Single
    Private CurrentPackageLevel As Integer
    Private CurrentPackagePercentComplete As Single
    Private CurrentPackageEarnedManHours As Single
    Private CurrentPackageRequiredManHours As Single

    Private LowestPackageLevel As Integer
    Private TtlPackagePercentComplete As Single
    Private TtlPackageEarnedManHours As Single
    Private TtlPackageRequiredManHours As Single

    Private LowestTagLevel As Integer
    Private TtlTagPercentComplete As Single
    Private TtlTagEarnedManHours As Single
    Private TtlTagRequiredManHours As Single

    Private LowestFormLevel As Integer
    Private TtlFormPercentComplete As Single
    Private TtlFormEarnedManHours As Single
    Private TtlFormRequiredManHours As Single


    Private SelectedTagMUID As String
    Private SelectedFormMUID As String


    Private Sub PackageView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            sqlPrjUtils.OpenConnection()
            sqlSrvUtils.OpenConnection()
            sqlDocUtils.OpenConnection()

            Loading = True

            PopulatePackage()

            GridControl_PkgAuxData(PkgID.Text)

            PopulateCboOwner()

            CreateTagTree()

            CheckPermissions()
            CreateOwnerTabs()

            If Utilities.CountTags(PackageID) > 0 Then
                GetPackageForms()
                MatrixStatus()
                PkgMatrixTabControl.SelectedTab.Controls.Add(PkgMatrix)
                PkgMatrix.Dock = DockStyle.Fill
            Else
                PkgMatrix.Visible = False
            End If

            Loading = False
            PackageViewer.PackageViewerManager.SelectedPackageID = PackageID
            PackageViewer.PackageViewerManager.SelectedPackageOwnerID = PackageOwner
            PackageViewer.PackageViewerManager.SelectedPackagename = PkgNumber.Text
            PackageViewer.PackageViewerManager.SelectedPackageOwnerName = OwnerID.Text

        Catch ex As Exception
            Utilities.logErrorMessage("PackageViewer.PackageView._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub CreateOwnerTabs()
        Dim query As String = "SELECT DISTINCT OwnerMUID From requirements"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        Me.Controls.Add(PkgMatrix)
        If dt.Rows.Count = 0 Then
            MessageBox.Show("Form requirements have not been set")
            Return
        End If
        PkgMatrixTabControl.TabPages(0).Dispose()
        Dim selectedTabIndex As Integer = 0
        For i As Integer = 0 To dt.Rows.Count - 1

            Dim dtOwner As DataTable = Utilities.GetOwnerInfo(dt.Rows(i)(0))
            PkgMatrixTabControl.TabPages.Add(dtOwner.Rows(0)("Name"))
            PkgMatrixTabControl.TabPages(i).Tag = dtOwner.Rows(0)("MUID")
            If dtOwner.Rows(0)("MUID") = PackageOwner Then
                selectedTabIndex = i
            End If
        Next
        PkgMatrixTabControl.SelectedIndex = selectedTabIndex
    End Sub


    Private Sub CheckPermissions()
        If Not Utilities.CheckPermission("PKG002") Then
            Me.OwnerID.Enabled = False
            Me.GroupID.Enabled = False
            Me.DisciplineID.Enabled = False
            Me.PkgNumber.ReadOnly = True
            Me.Button1.Enabled = False
            Me.Description.ReadOnly = True
            Me.nud_Priority.Enabled = False
        End If

        If Not Utilities.CheckPermission("TAG006") Then
            Me.Button2.Enabled = False
            Me.tbx_TagPrefix.ReadOnly = True
            Me.tbx_TagService.ReadOnly = True
            Me.tbx_TagDescription.ReadOnly = True
            Me.tbx_TagManufacturer.ReadOnly = True
            Me.tbx_TagModel.ReadOnly = True
            Me.tbx_TagSerial.ReadOnly = True
            Me.tbx_TagPONumber.ReadOnly = True
            Me.tbx_TagLineNumber.ReadOnly = True
            Me.tbx_TagRemarks.ReadOnly = True
        End If

        If Not Utilities.CheckPermission("TAG007") Then
            Me.btnUpdateTagAuxValue.Enabled = False
            Me.TagVGridControl1.Enabled = False
        End If

        If Not Utilities.CheckPermission("PKG009") Then
            Me.tsb_DocumentAdd.Enabled = False
        End If
    End Sub

    Private Sub PackageView_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        PackageViewerManager.PackageFocus(Me.Text)
        PackageViewer.PackageViewerManager.SelectedPackageID = PackageID
        PackageViewer.PackageViewerManager.SelectedPackageOwnerID = PackageOwner
        PackageViewer.PackageViewerManager.SelectedPackagename = PkgNumber.Text
        PackageViewer.PackageViewerManager.SelectedPackageOwnerName = OwnerID.Text
    End Sub


    Private Sub PackageView_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        PackageViewerManager.PackageFocus(Me.Text)
        PackageViewer.PackageViewerManager.SelectedPackageID = PackageID
        PackageViewer.PackageViewerManager.SelectedPackageOwnerID = PackageOwner
        PackageViewer.PackageViewerManager.SelectedPackagename = PkgNumber.Text
        PackageViewer.PackageViewerManager.SelectedPackageOwnerName = OwnerID.Text
    End Sub


    Private Sub PopulatePackage()
        Dim query As String = "SELECT * FROM package WHERE MUID='" & PackageID & "';"
        Try
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            If dt.Rows.Count > 0 Then
                PkgID.Text = dt.Rows(0)("MUID").ToString
                PkgNumber.Text = dt.Rows(0)("PackageNumber").ToString
                SystemNumber = dt.Rows(0)("SystemMUID")
                TranslateSystemNumber(SystemNumber)
                Me.ShowSystem.Tag = SystemNumber
                Description.Text = dt.Rows(0)("Description").ToString
                PackageName = dt.Rows(0)("PackageNumber")
                If Not IsDBNull(dt.Rows(0)("OwnerMUID")) Then
                    PackageOwner = dt.Rows(0)("OwnerMUID").ToString
                End If
                If Not IsDBNull(dt.Rows(0)("GroupMUID")) Then
                    PackageGroup = dt.Rows(0)("GroupMUID").ToString
                End If
                If Not IsDBNull(dt.Rows(0)("DisciplineMUID")) Then
                    PackageDiscipline = dt.Rows(0)("DisciplineMUID").ToString
                End If
                If Not IsDBNull(dt.Rows(0)("Aux09")) Then
                    Me.nud_Priority.Value = dt.Rows(0)("Aux09")
                End If
                If Not IsDBNull(dt.Rows(0)("Aux08")) Then
                    Me.ckbx_Audit.Checked = dt.Rows(0)("Aux08")
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Cannot get Tier Description: " + ex.Message)
        End Try

        PopulateDropDowns()
    End Sub


    Private Sub PopulateDropDowns()
        OwnerID.DataSource = GetOwner()
        OwnerID.DisplayMember = GetOwner().Columns("Name").ToString
        OwnerID.ValueMember = GetOwner().Columns("MUID").ToString

        GroupID.DataSource = GetGroup()
        GroupID.DisplayMember = GetGroup().Columns("Name").ToString
        GroupID.ValueMember = GetGroup().Columns("MUID").ToString

        DisciplineID.DataSource = GetDiscipline()
        DisciplineID.DisplayMember = GetDiscipline().Columns("Name").ToString
        DisciplineID.ValueMember = GetDiscipline().Columns("MUID").ToString

        Dim i As Integer
        For i = 0 To GetOwner().Rows.Count - 1
            If GetOwner().Rows(i)("MUID") = PackageOwner Then
                OwnerID.SelectedIndex = i
            End If
        Next

        For i = 0 To GetGroup().Rows.Count - 1
            If GetGroup().Rows(i)(0) = PackageGroup Then
                GroupID.SelectedIndex = i
            End If
        Next

        For i = 0 To GetDiscipline().Rows.Count - 1
            If GetDiscipline().Rows(i)(0) = PackageDiscipline Then
                DisciplineID.SelectedIndex = i
            End If
        Next

    End Sub


    Private Function TestAuxRecord()
        Dim query As String
        query = "Select * From aux_package WHERE PackageMUID='" & PackageID & "'"

        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        Dim HasAuxInfo As Boolean = False
        If dt.Rows.Count > 0 Then
            HasAuxInfo = True
        End If

        Return HasAuxInfo
    End Function


    Private Function GetAuxRecord() As Array
        Dim query As String = "Select auxData From aux_package WHERE PackageMUID='" & PackageID & "'"
        Dim FieldString As String = Nothing
        Dim FieldArray As Array
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

        If dt.Rows.Count > 0 Then
            FieldString = dt.Rows(0)(0)
            FieldArray = Split(FieldString, "&001")
        End If

        Return FieldArray
    End Function


    Private Function GetOwner() As DataTable
        Dim query As String = "Select * From Owner ORDER BY Name ASC"
        Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
        Return dt
    End Function


    Private Function GetGroup() As DataTable
        Dim query As String = "Select * From groups ORDER BY Name ASC"
        Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
        Return dt
    End Function


    Private Function GetDiscipline() As DataTable
        Dim query As String
        query = "Select * From discipline ORDER BY Name ASC"
        Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
        Return dt
    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim systemValue As String
        Dim thisSystem As New SystemManager.SystemDataManager
        systemValue = SystemManager.SystemDataManager.GetSystem(ShowSystem.Tag)

        If Not systemValue = "" Then
            SystemNumber = systemValue
            TranslateSystemNumber(SystemNumber)
            ShowSystem.Tag = SystemNumber
        End If
    End Sub


    Private Sub TranslateSystemNumber(ByVal ThisSystemID As String)
        Dim translatedValue As String
        translatedValue = SystemManager.SystemDataManager.TranslateSystemID(ThisSystemID)
        ShowSystem.Text = translatedValue
    End Sub


    Private Sub PackageUpdate()
        If Not Loading Then
            Dim query As String = "UPDATE package SET " & _
                         "TS='" & Now() & "', " & _
                         "PackageNumber='" & PkgNumber.Text & "', " & _
                         "SystemMUID='" & SystemNumber & "', " & _
                         "Description='" & Description.Text & "', " & _
                         "OwnerMUID='" & OwnerID.SelectedValue & "', " & _
                         "GroupMUID='" & GroupID.SelectedValue & "', " & _
                         "DisciplineMUID='" & DisciplineID.SelectedValue & "', " & _
                         "Aux09='" & Me.nud_Priority.Value.ToString & "', " & _
                         "Aux08='" & Me.ckbx_Audit.Checked.ToString & "' " & _
                         "WHERE MUID='" & PackageID & "'"
            Dim dt_param As DataTable = sqlPrjUtils.paramDT

            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        End If
    End Sub


    Private Sub Description_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Description.TextChanged
        PackageUpdate()
    End Sub


    Private Sub PkgNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PkgNumber.TextChanged
        If Loading Then Return
        PackageUpdate()
    End Sub


    Private Sub ShowSystem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowSystem.TextChanged
        If Loading Then Return
        PackageUpdate()
    End Sub


    Private Sub OwnerID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OwnerID.SelectedIndexChanged
        If Loading Then Return
        PackageUpdate()
        MessageBox.Show("Package ownership has been changed")
    End Sub


    Private Sub GroupID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupID.SelectedIndexChanged
        If Loading Then Return
        PackageUpdate()
        MessageBox.Show("Package Group has been changed")
    End Sub


    Private Sub DisciplineID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DisciplineID.SelectedValueChanged
        If Loading Then Return
        PackageUpdate()
        MessageBox.Show("Package Discipline has been changed")
    End Sub


    Private Function GetTagRecord() As DataTable
        Dim query As String
        query = "Select * From tags WHERE PackageMUID='" & PackageID & "'"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        Return dt
    End Function


    Private Function GetTagRecord(ByVal TagID As String) As DataTable
        Dim query As String = "Select * From tags WHERE MUID='" & TagID & "'"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        Return dt
    End Function


    Private Function TestTagEngData(ByVal TagID As String)
        Dim query As String = "Select * From engineering_data WHERE TagMUID='" & TagID & "'"
        Dim HasData As Boolean = False

        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        If dt.Rows.Count > 0 Then
            HasData = True
        End If

        Return HasData
    End Function


    Private Function GetTagEngineeringData(ByVal TagID As String) As DataTable
        Dim query As String
        query = "Select * From engineering_data WHERE TagMUID='" & TagID & "' ORDER BY TS DESC"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

        Return dt
    End Function


    Private Sub CreateTagTree()
        Dim PackageNode As TreeNode
        PackageNode = New TreeNode
        PackageNode.Name = "Package"
        PackageNode.Text = PkgNumber.Text
        PackageNode.ContextMenuStrip = PackageRoot
        PackageNode.Expand()


        Dim i As Integer
        For i = 0 To Utilities.CountTags(PackageID) - 1
            Dim tn As TreeNode
            tn = New TreeNode
            tn.Name = "Tag" & i
            'tn.ContextMenuStrip = TagRoot
            tn.Text = GetTagRecord().Rows(i)("TagNumber")
            tn.Tag = GetTagRecord().Rows(i)("MUID")

            'tn.Nodes.Add("Auxillary Info")

            PackageNode.Nodes.Add(tn)
        Next
        AddHandler TagTree.AfterSelect, AddressOf TagSelect

        TagTree.Nodes.Add(PackageNode)
    End Sub

    Private Sub CheckTagAuxDataModified()
        If Me.btnUpdateTagAuxValue.Enabled Then
            Dim ret = MessageBox.Show("Tag Aux Data has been modified. Do you wish to updaye?", "Tag Aux Data", MessageBoxButtons.YesNo)
            If ret = System.Windows.Forms.DialogResult.Yes Then
                UpdateTagAuxData()
            End If
        End If
    End Sub

    Private Sub CheckPkgAuxDataModified()
        If Me.btnUpdatePkgAuxVals.Enabled Then
            Dim ret = MessageBox.Show("Pkg Aux Data has been modified. Do you wish to updaye?", "Package Aux Data", MessageBoxButtons.YesNo)
            If ret = System.Windows.Forms.DialogResult.Yes Then
                UpdatePkgAuxData()
            End If
        End If
    End Sub


    Private Sub TagSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)

        If e.Node.Level > 0 Then
            CheckTagAuxDataModified()

            lbl_SelectedTag.Text = "Tag: " & e.Node.Text

            PopulateEngData(e.Node.Tag)

            'Me.tab_TagAuxInfo.Controls.Clear()

            'PopulateTagAuxInfo(e.Node.Tag)
            TagID = e.Node.Tag
            GridControl_TagAuxData(e.Node.Tag)
        Else

            lbl_SelectedTag.Text = "Tag: not selected"

        End If
        Me.btnUpdateTagAuxValue.Enabled = False
    End Sub


    Private Sub PopulateEngData(ByVal TagID As String)
        tbx_TagID.Tag = TagID

        tbx_TagType.Tag = GetTagRecord(TagID).Rows(0)("TypeMUID")
        tbx_TagType.Text = Utilities.GetTypeCode(tbx_TagType.Tag)

        If TestTagEngData(TagID) Then
            If IsDBNull(GetTagEngineeringData(TagID).Rows(0)("Prefix")) Then
                tbx_TagPrefix.Text = "no data"
            Else
                tbx_TagPrefix.Text = GetTagEngineeringData(TagID).Rows(0)("Prefix")
            End If

            If IsDBNull(GetTagEngineeringData(TagID).Rows(0)("Service")) Then
                tbx_TagService.Text = "no data"
            Else
                tbx_TagService.Text = GetTagEngineeringData(TagID).Rows(0)("Service")
            End If

            If IsDBNull(GetTagEngineeringData(TagID).Rows(0)("Description")) Then
                tbx_TagDescription.Text = "no data"
            Else
                tbx_TagDescription.Text = GetTagEngineeringData(TagID).Rows(0)("Description")
            End If

            If IsDBNull(GetTagEngineeringData(TagID).Rows(0)("Manufacturer")) Then
                tbx_TagManufacturer.Text = "no data"
            Else
                tbx_TagManufacturer.Text = GetTagEngineeringData(TagID).Rows(0)("Manufacturer")
            End If

            If IsDBNull(GetTagEngineeringData(TagID).Rows(0)("ModelNumber")) Then
                tbx_TagModel.Text = "no data"
            Else
                tbx_TagModel.Text = GetTagEngineeringData(TagID).Rows(0)("ModelNumber")
            End If
            If IsDBNull(GetTagEngineeringData(TagID).Rows(0)("SerialNumber")) Then
                tbx_TagSerial.Text = "no data"
            Else
                tbx_TagSerial.Text = GetTagEngineeringData(TagID).Rows(0)("SerialNumber")
            End If
            If IsDBNull(GetTagEngineeringData(TagID).Rows(0)("PONumber")) Then
                tbx_TagPONumber.Text = "no data"
            Else
                tbx_TagPONumber.Text = GetTagEngineeringData(TagID).Rows(0)("PONumber")
            End If
            If IsDBNull(GetTagEngineeringData(TagID).Rows(0)("LineNumber")) Then
                tbx_TagLineNumber.Text = "no data"
            Else
                tbx_TagLineNumber.Text = GetTagEngineeringData(TagID).Rows(0)("LineNumber")
            End If
            If IsDBNull(GetTagEngineeringData(TagID).Rows(0)("Remarks")) Then
                tbx_TagRemarks.Text = "no data"
            Else
                tbx_TagRemarks.Text = GetTagEngineeringData(TagID).Rows(0)("Remarks")
            End If
        Else
            tbx_TagPrefix.Text = "no data"
            tbx_TagService.Text = "no data"
            tbx_TagDescription.Text = "no data"
            tbx_TagManufacturer.Text = "no data"
            tbx_TagModel.Text = "no data"
            tbx_TagSerial.Text = "no data"
            tbx_TagPONumber.Text = "no data"
            tbx_TagLineNumber.Text = "no data"
            tbx_TagRemarks.Text = "no data"
        End If

    End Sub


    Private Sub TagEngDataUpdate()
        
        If tbx_TagPrefix.Text = "no data" Then tbx_TagPrefix.Text = ""
        If tbx_TagService.Text = "no data" Then tbx_TagService.Text = ""
        If tbx_TagDescription.Text = "no data" Then tbx_TagDescription.Text = ""
        If tbx_TagManufacturer.Text = "no data" Then tbx_TagManufacturer.Text = ""
        If tbx_TagModel.Text = "no data" Then tbx_TagModel.Text = ""
        If tbx_TagSerial.Text = "no data" Then tbx_TagSerial.Text = ""
        If tbx_TagPONumber.Text = "no data" Then tbx_TagPONumber.Text = ""
        If tbx_TagLineNumber.Text = "no data" Then tbx_TagLineNumber.Text = ""
        If tbx_TagRemarks.Text = "no data" Then tbx_TagRemarks.Text = ""

        Dim DataModified As Boolean = False

        Dim query As String

        If GetTagEngineeringData(TagID).Rows.Count = 0 Then
            query = "INSERT INTO engineering_data (MUID,TS,TagMUID,Remarks,Prefix," & _
        "Description,Service,Manufacturer,ModelNumber,SerialNumber,PONumber,LineNumber,Aux09) Values ("
            query += "@MUID,"
            query += "@TS,"
            query += "@TagMUID,"
            query += "@Remarks,"
            query += "@Prefix,"
            query += "@Description,"
            query += "@Service,"
            query += "@Manufacturer,"
            query += "@ModelNumber,"
            query += "@SerialNumber,"
            query += "@PONumber,"
            query += "@LineNumber,"
            query += "@Aux09"
            query += ")"

            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "engineering_data"))
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@TagMUID", tbx_TagID.Tag)
            dt_param.Rows.Add("@Remarks", tbx_TagRemarks.Text)
            dt_param.Rows.Add("@Prefix", tbx_TagPrefix.Text)
            dt_param.Rows.Add("@Description", tbx_TagDescription.Text)
            dt_param.Rows.Add("@Service", tbx_TagService.Text)
            dt_param.Rows.Add("@Manufacturer", tbx_TagManufacturer.Text)
            dt_param.Rows.Add("@ModelNumber", tbx_TagModel.Text)
            dt_param.Rows.Add("@SerialNumber", tbx_TagSerial.Text)
            dt_param.Rows.Add("@PONumber", tbx_TagPONumber.Text)
            dt_param.Rows.Add("@LineNumber", tbx_TagLineNumber.Text)
            dt_param.Rows.Add("@Aux09", "1")

            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        End If


        Dim ModifiedString As String = "The following tag data has been modified:  "

        If tbx_TagPrefix.Text <> GetTagEngineeringData(TagID).Rows(0)("Prefix") And Not tbx_TagPrefix.Text = "" Then
            DataModified = True
            ModifiedString += " Prefix: from '" + GetTagEngineeringData(TagID).Rows(0)("Prefix") + "' to '" + tbx_TagPrefix.Text + "',"
        End If
        If tbx_TagService.Text <> GetTagEngineeringData(TagID).Rows(0)("Service") And Not tbx_TagService.Text = "" Then
            DataModified = True
            ModifiedString += " Service: from '" + GetTagEngineeringData(TagID).Rows(0)("Service") + "' to '" + tbx_TagService.Text + "',"
        End If
        If tbx_TagDescription.Text <> GetTagEngineeringData(TagID).Rows(0)("Description") And Not tbx_TagDescription.Text = "" Then
            DataModified = True
            ModifiedString += " Description: from '" + GetTagEngineeringData(TagID).Rows(0)("Description") + "' to '" + tbx_TagDescription.Text + "',"
        End If
        If tbx_TagManufacturer.Text <> GetTagEngineeringData(TagID).Rows(0)("Manufacturer") And Not tbx_TagManufacturer.Text = "" Then
            DataModified = True
            ModifiedString += " Manufacturer: from '" + GetTagEngineeringData(TagID).Rows(0)("Manufacturer") + "' to '" + tbx_TagManufacturer.Text + "',"
        End If
        If tbx_TagModel.Text <> GetTagEngineeringData(TagID).Rows(0)("ModelNumber") And Not tbx_TagModel.Text = "" Then
            DataModified = True
            ModifiedString += " Model: from '" + GetTagEngineeringData(TagID).Rows(0)("ModelNumber") + "' to '" + tbx_TagModel.Text + "',"
        End If
        If tbx_TagSerial.Text <> GetTagEngineeringData(TagID).Rows(0)("SerialNumber") And Not tbx_TagSerial.Text = "" Then
            DataModified = True
            ModifiedString += " Serial#: from '" + GetTagEngineeringData(TagID).Rows(0)("SerialNumber") + "' to '" + tbx_TagSerial.Text + "',"
        End If
        If tbx_TagPONumber.Text <> GetTagEngineeringData(TagID).Rows(0)("PONumber") And Not tbx_TagPONumber.Text = "" Then
            DataModified = True
            ModifiedString += " PO#: from '" + GetTagEngineeringData(TagID).Rows(0)("PONumber") + "' to '" + tbx_TagPONumber.Text + "',"
        End If
        If tbx_TagLineNumber.Text <> GetTagEngineeringData(TagID).Rows(0)("LineNumber") And Not tbx_TagLineNumber.Text = "" Then
            DataModified = True
            ModifiedString += " Line#: from '" + GetTagEngineeringData(TagID).Rows(0)("LineNumber") + "' to '" + tbx_TagLineNumber.Text + "',"
        End If
        If tbx_TagRemarks.Text <> GetTagEngineeringData(TagID).Rows(0)("Remarks") And Not tbx_TagRemarks.Text = "" Then
            DataModified = True
            ModifiedString += " Remarks#: from '" + GetTagEngineeringData(TagID).Rows(0)("Remarks") + "' to '" + tbx_TagRemarks.Text + "'"
        End If


        If DataModified Then
            query = "INSERT INTO engineering_data (MUID,TS,TagMUID,Remarks,Prefix," & _
        "Description,Service,Manufacturer,ModelNumber,SerialNumber,PONumber,LineNumber,Aux09) Values ("
            query += "@MUID,"
            query += "@TS,"
            query += "@TagMUID,"
            query += "@Remarks,"
            query += "@Prefix,"
            query += "@Description,"
            query += "@Service,"
            query += "@Manufacturer,"
            query += "@ModelNumber,"
            query += "@SerialNumber,"
            query += "@PONumber,"
            query += "@LineNumber,"
            query += "@Aux09"
            query += ")"

            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "engineering_data"))
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@TagMUID", tbx_TagID.Tag)
            dt_param.Rows.Add("@Remarks", tbx_TagRemarks.Text)
            dt_param.Rows.Add("@Prefix", tbx_TagPrefix.Text)
            dt_param.Rows.Add("@Description", tbx_TagDescription.Text)
            dt_param.Rows.Add("@Service", tbx_TagService.Text)
            dt_param.Rows.Add("@Manufacturer", tbx_TagManufacturer.Text)
            dt_param.Rows.Add("@ModelNumber", tbx_TagModel.Text)
            dt_param.Rows.Add("@SerialNumber", tbx_TagSerial.Text)
            dt_param.Rows.Add("@PONumber", tbx_TagPONumber.Text)
            dt_param.Rows.Add("@LineNumber", tbx_TagLineNumber.Text)
            dt_param.Rows.Add("@Aux09", "1")

            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
            query = "INSERT INTO discrepancy (MUID,TS,Title," & _
                " Description,Resolution,ListedBy,ListedOn,ClosedBy,ClosedOn,Status,ManHours," & _
                " PackageMUID) VALUES (" & _
                " @MUID," & _
                " @TS," & _
                " @Title," & _
                " @Description," & _
                " @Resolution," & _
                " @ListedBy," & _
                " @ListedOn," & _
                " @ClosedBy," & _
                " @ClosedOn," & _
                " @Status," & _
                " @ManHours," & _
                " @PackageMUID)"

            dt_param = sqlPrjUtils.paramDT
            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "discrepancy"))
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@Title", "'Tag " + Utilities.TranslateTagID(TagID) + " Eng. Data Modified',")
            dt_param.Rows.Add("@Description", ModifiedString)
            dt_param.Rows.Add("@Resolution", "Auto-Resolve")
            dt_param.Rows.Add("@ListedBy", runtime.UserMUID)
            dt_param.Rows.Add("@ListedOn", Now())
            dt_param.Rows.Add("@ListedBy", runtime.UserMUID)
            dt_param.Rows.Add("@ListedOn", Now())
            dt_param.Rows.Add("@Status", "Resolved")
            dt_param.Rows.Add("@ManHours", "0")
            dt_param.Rows.Add("@PackageMUID", Me.PackageID.ToString)

            sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TagID <= "" Then
            MessageBox.Show("Please select a Tag")
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False
        TagEngDataUpdate()
        Me.Enabled = True
        Me.Cursor = Cursors.Default
        MessageBox.Show("Update complete.")
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        PopulateEngData(CInt(tbx_TagID.Text))
    End Sub


    Private Function GetPackageForms() As DataTable
        PkgMatrix.Dispose()
        Me.PkgMatrix = New System.Windows.Forms.DataGridView
        PkgMatrix.Columns.Add("TagNum", "")

        Dim PkgArray As DataTable = PkgForms(PkgMatrixTabControl.SelectedTab.Tag)
        Dim i As Integer
        Dim clmCount As Integer = 1
        For i = 0 To PkgArray.Rows.Count - 1
            Dim formExist As Boolean = False
            For j As Integer = 1 To PkgMatrix.ColumnCount - 1
                If PkgMatrix.Columns(j).Tag = PkgArray.Rows(i)("FormsMUID") Then
                    formExist = True
                End If
            Next
            If Not formExist Then
                PkgMatrix.Columns.Add(PkgArray.Rows(i)("reqMUID"), PkgArray.Rows(i)("Name"))
                PkgMatrix.Columns(clmCount).Tag = PkgArray.Rows(i)("FormsMUID")
                clmCount = clmCount + 1
            End If
        Next

        'Make a row for each tag in the package
        For i = 0 To Utilities.CountTags(PackageID) - 1
            Dim RowValues As New DataGridViewRow()

            PkgMatrix.Rows.Add(RowValues)
            PkgMatrix.Rows(i).Cells("TagNum").Value = GetTagRecord().Rows(i)("TagNumber")
            PkgMatrix.Rows(i).Cells("TagNum").Tag = GetTagRecord().Rows(i)("MUID")
        Next

        PkgMatrix.Columns("TagNum").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        PkgMatrix.ContextMenuStrip = Me.cms_TagGrid
        PkgMatrix.AllowUserToAddRows = False
        PkgMatrix.AllowUserToDeleteRows = False
        PkgMatrix.AllowUserToOrderColumns = False

        PkgMatrix.Refresh()
    End Function


    Private Function PkgForms(ByVal reqMUID As String) As DataTable
        Dim EqIDList As String = "("
        Dim i As Integer
        For i = 0 To Utilities.CountTags(PackageID) - 1
            If i = Utilities.CountTags(PackageID) - 1 Then
                EqIDList += "'" & GetTagRecord().Rows(i)("TypeMUID") & "'"
            Else
                EqIDList += "'" & GetTagRecord().Rows(i)("TypeMUID") & "',"
            End If
        Next
        EqIDList += ")"

        Dim query As String = "SELECT Distinct forms.MUID As formsMUID,forms.Name, requirements.MUID As reqMUID " & _
                "FROM requirements, forms " & _
                "WHERE requirements.FormMUID = forms.MUID " & _
                "AND requirements.OwnerMUID = '" + reqMUID + "' " & _
                "AND requirements.TypeMUID IN " & EqIDList

        Try
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            Return dt
        Catch ex As Exception
            Dim message As String = ex.Message
            Throw ex
        End Try
    End Function


    Private Sub PkgMatrix_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PkgMatrix.CellClick
        If e.ColumnIndex > 0 And e.RowIndex > -1 Then
            Me.SelectedTagMUID = PkgMatrix.Rows(e.RowIndex).Cells(0).Tag
            Me.SelectedFormMUID = PkgMatrix.Columns(e.ColumnIndex).Tag
        End If
    End Sub


    Private Sub PkgMatrix_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PkgMatrix.CellDoubleClick

        If e.RowIndex = -1 Then Return
        If e.ColumnIndex < 1 Then Return

        Me.Cursor = Cursors.WaitCursor

        Dim ThisTag As String
        Dim ThisForm As String
        ThisForm = PkgMatrix.Columns(e.ColumnIndex).Tag
        ThisTag = PkgMatrix.Rows(e.RowIndex).Cells(0).Tag

        Dim TypeID As String = GetTagRecord(PkgMatrix.Rows(e.RowIndex).Cells(0).Tag).Rows(0)(4)
        Dim NeedStatus As Boolean = Utilities.FormCheck(TypeID, PkgMatrixTabControl.SelectedTab.Tag, ThisForm)

        If Not NeedStatus Then Return

        Try
            Dim OpenForm As New FormDesigner.FormView(ThisForm, ThisTag, PkgMatrixTabControl.SelectedTab.Tag)
            OpenForm.Show()
            MatrixStatus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub MatrixStatus()
        Dim query As String = "SELECT Distinct typeMUID FROM tags " & _
                "WHERE PackageMUID = '" + PackageID + "'"
        Dim dtType As DataTable = sqlPrjUtils.ExecuteQuery(query)

        'Make a row for each tag in the package
        Dim i As Integer
        Dim j As Integer
        For i = 0 To Utilities.CountTags(PackageID) - 1
            For j = 0 To PkgMatrix.ColumnCount - 1
                PkgMatrix.Rows(i).Cells(j).Style.BackColor = Color.DarkGray
            Next
        Next

        For i = 0 To Utilities.CountTags(PackageID) - 1
            Dim TagID As String = PkgMatrix.Rows(i).Cells("TagNum").Tag
            Dim TypeID As String = GetTagRecord(PkgMatrix.Rows(i).Cells("TagNum").Tag).Rows(0)(4)
            For j = 0 To dtType.Rows.Count - 1
                If TypeID = dtType.Rows(j)(0) Then
                    Dim reqMUID As String = PkgMatrixTabControl.SelectedTab.Tag
                    Dim PkgArray As DataTable = PkgForms(reqMUID)
                    Dim FormCol As Integer
                    For FormCol = 1 To PkgMatrix.Columns.Count - 1
                        Dim FormID As String = PkgMatrix.Columns(FormCol).Tag
                        Dim NeedStatus As Boolean = False
                        NeedStatus = Utilities.FormCheck(TypeID, PkgMatrixTabControl.SelectedTab.Tag, FormID)
                        If NeedStatus Then
                            Dim ThisStatus As Integer = Utilities.GetFormStatus(TagID, FormID, PkgMatrixTabControl.SelectedTab.Tag)
                            Dim StatusColor As String = Utilities.GetFormStatusColor(PkgMatrixTabControl.SelectedTab.Tag, ThisStatus)
                            Dim TagType = Utilities.GetTypeCode(TypeID)
                            PkgMatrix.Rows(i).Cells(FormCol).Value = TagType
                            If StatusColor = 0 Then
                                PkgMatrix.Rows(i).Cells(FormCol).Style.BackColor = Color.Red
                            ElseIf StatusColor = "" Then
                                PkgMatrix.Rows(i).Cells(FormCol).Style.BackColor = Color.Red
                            Else
                                PkgMatrix.Rows(i).Cells(FormCol).Style.BackColor = System.Drawing.Color.FromArgb(StatusColor)
                            End If
                        End If
                    Next
                End If
            Next
        Next
    End Sub


    Private Sub PopulateCboOwner()
        'Me.cboOwner.BeginUpdate()
        'Dim qry = "SELECT MUID, Name FROM Owner ORDER BY Name ASC"
        ''Dim myTbl As DataTable = Utilities.ExecuteQuery(qry, "server")
        'Dim myTbl As DataTable = sqlSrvUtils.ExecuteQuery(qry)

        'Dim nRow As DataRow = myTbl.NewRow
        'nRow(0) = 0
        'nRow(1) = "All"
        'myTbl.Rows.Add(nRow)
        'Me.cboOwner.DataSource = myTbl
        'Me.cboOwner.DisplayMember = "Name"
        'Me.cboOwner.ValueMember = "MUID"
        'Me.cboOwner.SelectedValue = 0
        'Me.cboOwner.EndUpdate()
        'AddHandler cboOwner.SelectedIndexChanged, AddressOf cboOwner_SelectedIndexChanged
    End Sub


    Private Sub TabPage12_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowStatus()
    End Sub


    Private Sub PackageView_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        sqlSrvUtils.CloseConnection()
        sqlPrjUtils.CloseConnection()
        sqlDocUtils.CloseConnection()
        CheckPkgAuxDataModified()
        CheckTagAuxDataModified()

        PackageViewerManager.FormClosed(Me.Text)
    End Sub


    Private Sub TabPage6_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tab_PkgDiscrepancy.Enter
        Dim query = "SELECT * FROM discrepancy WHERE PackageMUID = '" + PackageID.ToString + "'"
        Dim i As Integer = 1
        Dim RecordTop As Integer = 25
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

        For i = 0 To dt.Rows.Count - 1
            UserTable = Utilities.GetUserInfoByMUID(dt.Rows(i)("ListedBy"))
            DiscrepancyObject = New DiscrepancyManager.ControlDiscrepancy()
            With DiscrepancyObject
                .Name = "DiscrepancyObject" & dt.Rows(i)("MUID").ToString
                .Tag = dt.Rows(i)("MUID")
                .Visible = True
                .Left = 10
                .Top = RecordTop
                .tbx_Title.Text = dt.Rows(i)("Title").ToString
                .tbx_Description.Text = dt.Rows(i)("Description")
                .tbx_ListedBy.Text = UserTable.Rows(0)("FirstName") & " " & UserTable.Rows(0)("MI") & " " & UserTable.Rows(0)("LastName")
                .tbx_ListedOn.Text = dt.Rows(i)("ListedOn")
                .tbx_Resolution.Text = dt.Rows(i)("Resolution")
                .tbx_PackageID.Text = Utilities.GetPackageName(dt.Rows(i)("PackageMUID").ToString)
                .tbx_Status.Text = dt.Rows(i)("Status")
                .Cursor = Cursors.Hand
            End With
            RecordTop += 250
            tab_PkgDiscrepancy.Controls.Add(DiscrepancyObject)

            AddHandler DiscrepancyObject.Click, AddressOf DiscrepancyObject_Click
            'AddHandler DiscrepancyObject.DoubleClick, AddressOf DiscrepancyObject_DoubleClick
        Next
    End Sub


    Private Sub DiscrepancyObject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscrepancyObject.Click
        'Dim tempObject As New DiscrepancyManager.ControlDiscrepancy()
        'tempObject = sender

        'For Each thisDiscrepancy As Control In tab_PkgDiscrepancy.Controls
        '    If thisDiscrepancy.Name = tempObject.Name Then
        '        thisDiscrepancy.BackColor = Color.Red
        '    Else
        '        thisDiscrepancy.BackColor = Color.Gray
        '    End If
        'Next thisDiscrepancy


        Dim tempObject As New DiscrepancyManager.ControlDiscrepancy()
        tempObject = sender

        Dim frmDiscrepancyEdit As New DiscrepancyManager.frmEditDiscrepancy(tempObject.Tag)
        frmDiscrepancyEdit.txtDiscrepancy.Text = tempObject.Tag
        frmDiscrepancyEdit.ShowDialog()

    End Sub

    Private Sub DiscrepancyObject_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscrepancyObject.DoubleClick
        Dim tempObject As New DiscrepancyManager.ControlDiscrepancy()
        tempObject = sender

        Dim frmDiscrepancyEdit As New DiscrepancyManager.frmEditDiscrepancy(tempObject.Tag)
        frmDiscrepancyEdit.txtDiscrepancy.Text = tempObject.Tag
        frmDiscrepancyEdit.ShowDialog()
    End Sub


    Private Sub PkgDocuments_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab_PkgDocuments.Enter
        Me.Cursor = Cursors.AppStarting
        DocumentsLoad()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DocumentsLoad()
        Try

            Dim query As String = "Select package_documents.TagMUID As TagRef,package_documents.DocumentMUID As ID From package_documents WHERE package_documents.PackageMUID = '" & PackageID & "'"
            Dim dt_PkgDocs As DataTable = sqlPrjUtils.ExecuteQuery(query)

            If Not dt_PkgDocs.Rows.Count = 0 Then
                Dim DocsList As String = "("
                Dim i As Integer
                For i = 0 To dt_PkgDocs.Rows.Count - 1
                    DocsList += "'" + dt_PkgDocs.Rows(i)(1) + "',"
                Next

                DocsList = DocsList.TrimEnd(",")
                DocsList += ")"

                query = "Select documents.MUID As ID,documents.EngCode," + _
                    " documents.ClientCode + '\' + documents.EngCode As Document," + _
                    " document_type.Description As Type,documents.Revision As Rev," + _
                    " documents.Sheet + '\' + documents.Sheets As Sht From documents," + _
                    " document_type WHERE documents.projectMUID = '" + runtime.selectedProjectID + "' AND documents.DocumentTypeMUID=document_type.MUID " + _
                    " AND documents.MUID IN " & DocsList

                Dim dt_Docs As DataTable = sqlDocUtils.ExecuteQuery(query)
                dt_Docs.Columns("EngCode").ColumnMapping = MappingType.Hidden
                dt_Docs.DefaultView.Sort = "EngCode Asc, Rev Desc"
                dt_Docs = dt_Docs.DefaultView.ToTable()

                Dim badRows As New List(Of DataRow)
                For Each dr2 As DataRow In dt_PkgDocs.Rows
                    Dim rowNum As DataRow = Nothing
                    For Each dr As DataRow In dt_Docs.Rows

                        If dr("ID") = dr2("ID") Then
                            rowNum = Nothing
                            If Not dr("Rev") = "0" Then
                                dr("Rev") = Utilities.TranslateRev(Utilities.GetDocumentLatestRev(dr("ID")))
                            End If
                            Exit For
                        End If
                        rowNum = dr2
                    Next
                    If Not rowNum Is Nothing Then
                        'dt_PkgDocs.Rows.Remove(rowNum)
                        badRows.Add(rowNum)
                    End If
                Next

                For Each dr As DataRow In badRows
                    dt_PkgDocs.Rows.Remove(dr)
                Next

                Dim ds As DataSet = New DataSet
                ds.Tables.Add(dt_PkgDocs)
                ds.Tables.Add(dt_Docs)
                ds.Relations.Add(dt_Docs.Columns("ID"), dt_PkgDocs.Columns("ID"))
                dt_PkgDocs.Columns.Add("Document", GetType(System.String), "Parent.Document")
                dt_PkgDocs.Columns.Add("Type", GetType(System.String), "Parent.Type")
                dt_PkgDocs.Columns.Add("Rev", GetType(System.String), "Parent.Rev")
                dt_PkgDocs.Columns.Add("Sheet", GetType(System.String), "Parent.Sht")

                dgv_PkgDocuments.DataSource = dt_PkgDocs
                dgv_PkgDocuments.Columns(0).Width = 90
                dgv_PkgDocuments.Columns(1).Visible = False
                dgv_PkgDocuments.Columns(2).Width = 300
                'dgv_PkgDocuments.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True

                dgv_PkgDocuments.Columns(3).Width = 150
                dgv_PkgDocuments.Columns(4).Width = 50
                dgv_PkgDocuments.Columns(5).Width = 50


                Try
                    For i = 0 To dgv_PkgDocuments.RowCount - 1
                        If Utilities.TestPkgDocContainsRedLineItems(dgv_PkgDocuments.Rows(i).Cells("ID").Value, PackageID) Then
                            dgv_PkgDocuments.Rows(i).DefaultCellStyle.BackColor = Color.Red
                            dgv_PkgDocuments.Rows(i).Cells(0).Style.BackColor = Color.Red
                        End If
                        If Not dgv_PkgDocuments.Rows(i).Cells(0).Value = "0" Then
                            dgv_PkgDocuments.Rows(i).Cells(0).Value = CommonForms.Classes.GetTagNumber(dgv_PkgDocuments.Rows(i).Cells(0).Value)
                        Else
                            dgv_PkgDocuments.Rows(i).Cells(0).Value = "*"
                        End If
                    Next
                Catch ex As Exception
                    MessageBox.Show("Could not translate Tag Number. Error " & ex.Message)
                End Try


            Else
                'MessageBox.Show("There are no documents in this package.")
                dgv_PkgDocuments.DataSource = Nothing
                tsb_DocumentEdit.Enabled = False
                tsb_DocumentDelete.Enabled = False
                tsb_DocumentView.Enabled = False
            End If
            tbx_DocumentCount.Text = dgv_PkgDocuments.Rows.Count.ToString

            dgv_PkgDocuments.Refresh()

        Catch ex As Exception
            MessageBox.Show("Error", ex.Message)
        End Try

    End Sub


    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_DocumentView.Click
        Dim ThisDocument As String = Utilities.GetDocumentLatestRevID(SelectedDocument)
        Dim frm_DocumentViewer As New Daqument.EditDaqument(ThisDocument, PackageName, "")
        frm_DocumentViewer.Show()
    End Sub


    Private Sub dgv_PkgDocuments_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_PkgDocuments.CellClick
        If e.RowIndex < 0 Then
            Return
        End If

        SelectedDocument = dgv_PkgDocuments.Rows(e.RowIndex).Cells(1).Value
        tsb_DocumentView.Enabled = True
        If Utilities.CheckPermission("PKG010") Then
            tsb_DocumentEdit.Enabled = True
        End If
        If Utilities.CheckPermission("PKG011") Then
            tsb_DocumentDelete.Enabled = True
        End If
    End Sub


    Private Sub dgv_PkgDocuments_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_PkgDocuments.CellDoubleClick
        Me.Cursor = Cursors.WaitCursor

        Dim ThisDocument As String = Utilities.GetDocumentLatestRevID(SelectedDocument)
        Dim frm_DocumentViewer As New Daqument.EditDaqument(ThisDocument, PackageName, "")
        frm_DocumentViewer.Show()

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ShowStatus()

        'Dim WherOwnerIDStr As String = " WHERE tags.MUID = tag_status.tagMUID AND tags.PackageMUID = '" + PackageID.ToString + "'"
        'If cboOwner.Text = "All" Then
        'Else
        '    WherOwnerIDStr = WherOwnerIDStr + " AND OwnerMUID = " + cboOwner.SelectedValue.ToString
        'End If

        'Dim qry = "SELECT tags.TagNumber, RequiredManhours, EarnedManhours, CurrentLevel FROM tags,tag_status " + _
        '    WherOwnerIDStr ' " WHERE tags.tagID = tag_status.tagID AND tags.PackageID = " + PackageID.ToString
        ''Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
        'Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        'Me.GridControl1.DataSource = dt
        ''qry = "SELECT Sum (RequiredManhours) As SumReqMhr, Sum EarnedManhours, Min Of (CurrentLevel) As MinCurrentLevel FROM tags,tag_status " + _
        ''    " WHERE tags.PackageID = " + PackageID.ToString

        'qry = "SELECT SUM(tag_status.RequiredManhours) AS ReqMhr, SUM(tag_status.EarnedManHours) AS EMhr, " + _
        '        " MIN(tag_status.CurrentLevel) AS MinCurrentLevel From tags,tag_status " + _
        '    WherOwnerIDStr ' " WHERE tags.tagID = tag_status.tagID AND tags.PackageID = " + PackageID.ToString

        ''" FROM  tags INNER JOIN " + _
        ''" tag_status ON tags.TagID = tag_status.TagID " + _
        ''" AND (tags.PackageID = 1)"
        ''Dim dtt As DataTable = Utilities.ExecuteQuery(qry, "project")

        'Dim dtt As DataTable = sqlPrjUtils.ExecuteQuery(qry)


        'Dim ttlPackagePercentComplete As Single = 0
        'If dtt.Rows.Count > 0 Then
        '    Me.lblTtlProjectEarnedHours.Text = "Total Earned Hours: " + Format("{0:P}", dtt.Rows(0)(1))
        '    Me.lblTtlProjectManHours.Text = "Total Required Man Hours: " + Format("{0:P}", dtt.Rows(0)(0))
        '    IIf(dtt.Rows(0)(0) > 0, ttlPackagePercentComplete = dtt.Rows(0)(1) / dtt.Rows(0)(0) * 100, 0)
        '    Me.lblCurrentStatusIndicator.Text = "Percent Complete: " + Format("{0:P}", ttlPackagePercentComplete) + "%"
        '    Me.lblProjectOverallStatus.Text = "Overall status: " + Format("{0:P}", dtt.Rows(0)(2))
        'End If
        ''GridControl1.ForceInitialize()

        ''Dim myPkgStatus As StatusManager.Status = New StatusManager.Status
        ''Dim _OwnerID As Integer = Me.cboOwner.SelectedValue
        ''Dim pkgTable As DataTable = myPkgStatus.PackageStatusTable(PackageViewer.PackageViewerManager.SelectedPackageID, _OwnerID)
        ''If pkgTable.Rows.Count > 0 Then
        ''    Dim ttlPackagePercentComplete As Single = pkgTable.Rows(0)(4)
        ''    Me.lblCurrentStatusIndicator.Text = "Percent Complete: " + Format("{0:P}", pkgTable.Rows(0)(5)) + "%"
        ''    Me.lblProjectOverallStatus.Text = "Overall Status Level: " + Format("{0:P}", pkgTable.Rows(0)(3))
        ''    Me.lblTtlProjectEarnedHours.Text = "Total Earned Hours: " + Format("{0:P}", pkgTable.Rows(0)(4))
        ''    Me.lblTtlProjectManHours.Text = "Total Required Man Hours: " + Format("{0:P}", pkgTable.Rows(0)(2))
        ''Else
        ''    Me.lblCurrentStatusIndicator.Text = "No Tags in the current Owner type"
        ''    Me.lblProjectOverallStatus.Text = ""
        ''    Me.lblTtlProjectEarnedHours.Text = ""
        ''    Me.lblTtlProjectManHours.Text = ""
        ''End If
        ''Dim bmp As Bitmap = New Bitmap(PictureBox2.Size.Width, PictureBox2.Size.Height)
        ''PictureBox2.Image = bmp
        ''Dim g As Graphics = Graphics.FromImage(Me.PictureBox2.Image)
        ''Dim myPen As New Pen(Brushes.Blue, 10)
        ''Dim startPoint As Point = New Point(0, Me.PictureBox2.Height / 2)
        ''Dim ScalePoints As Integer = ttlPackagePercentComplete * Me.PictureBox2.Width
        ''Dim myPoint As Point = New Point(ScalePoints, Me.PictureBox2.Height / 2)
        ''g.DrawLine(myPen, startPoint, myPoint)
        ''PictureBox2.Update()
        ''Dim tagTable As DataTable = myPkgStatus.pkgTagStatusTable(PackageViewer.PackageViewerManager.SelectedPackageID, _OwnerID)
        ''Me.GridControl1.DataSource = tagTable
        ''GridControl1.ForceInitialize()
    End Sub


    Private Sub cboOwner_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowStatus()
    End Sub

    '/* •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    ' |                                                                                                                                                                                                                                                    |
    ' |     Private Sub tab_PkgPunchlist_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab_PkgPunchlist.Enter                                                                                                                         |
    ' |         'Dim cmd As SqlCeCommand = connSQLProject.CreateCommand()                                                                                                                                                                                  |
    ' |         'cmd.CommandText = "SELECT * FROM tags, punchlist WHERE tags.TagID = punchlist.TagID AND (tags.PackageID = '" + PackageID.ToString + "')"                                                                                                  |
    ' |         'Dim read As SqlCeDataReader = cmd.ExecuteReader()                                                                                                                                                                                         |
    ' |         Dim i As Integer = 1                                                                                                                                                                                                                       |
    ' |         Dim RecordTop As Integer = 25                                                                                                                                                                                                              |
    ' |         Dim query = "SELECT punchlist.MUID As punchlistMUID, punchlist.Description, TagNumber, Priority, Status, Location,ListedBy FROM tags, punchlist WHERE tags.MUID = punchlist.TagMUID AND (tags.PackageMUID = '" + PackageID.ToString + "')" |
    ' |         Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)                                                                                                                                                                                      |
    ' |                                                                                                                                                                                                                                                    |
    ' |         For i = 0 To dt.Rows.Count - 1                                                                                                                                                                                                             |
    ' |             PunchlistObject = New PunchlistManager.ControlPunchlist()                                                                                                                                                                              |
    ' |             With PunchlistObject                                                                                                                                                                                                                   |
    ' |                 .Name = "PunchlistObject" & dt.Rows(i)("PunchlistMUID").ToString                                                                                                                                                                   |
    ' |                 .Tag = dt.Rows(i)("PunchlistMUID")                                                                                                                                                                                                 |
    ' |                 .Visible = True                                                                                                                                                                                                                    |
    ' |                 .Left = 10                                                                                                                                                                                                                         |
    ' |                 .Top = RecordTop                                                                                                                                                                                                                   |
    ' |                 .tbx_ID.Text = Utilities.GetUserInfoByMUID(dt.Rows(i)("ListedBY")).Rows(0)("UserName") + "-" + Split(dt.Rows(i)("punchlistMUID"), "&001")(1)                                                                                       |
    ' |                 .tbx_Description.Text = dt.Rows(i)("Description")                                                                                                                                                                                  |
    ' |                 .tbx_Tag.Text = dt.Rows(i)("TagNumber")                                                                                                                                                                                            |
    ' |                 .tbx_Priority.Text = dt.Rows(i)("Priority").ToString                                                                                                                                                                               |
    ' |                 .tbx_Status.Text = dt.Rows(i)("Status")                                                                                                                                                                                            |
    ' |                 .tbx_Location.Text = dt.Rows(i)("Location")                                                                                                                                                                                        |
    ' |                 .Cursor = Cursors.Hand                                                                                                                                                                                                             |
    ' |             End With                                                                                                                                                                                                                               |
    ' |                                                                                                                                                                                                                                                    |
    ' |             RecordTop += 150                                                                                                                                                                                                                       |
    ' |             tab_PkgPunchlist.Controls.Add(PunchlistObject)                                                                                                                                                                                         |
    ' |                                                                                                                                                                                                                                                    |
    ' |             AddHandler PunchlistObject.Click, AddressOf PunchlistObject_Click                                                                                                                                                                      |
    ' |             AddHandler PunchlistObject.DoubleClick, AddressOf PunchlistObject_DoubleClick                                                                                                                                                          |
    ' |         Next                                                                                                                                                                                                                                       |
    ' |     End Sub                                                                                                                                                                                                                                        |
    ' •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————• */

    '/* •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    ' |                                                                                                                          |
    ' |     Private Sub PunchlistObject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PunchlistObject.Click |
    ' |         Dim tempObject As New PunchlistManager.ControlPunchlist()                                                        |
    ' |         tempObject = sender                                                                                              |
    ' |                                                                                                                          |
    ' |         For Each thisPunchlist As Control In tab_PkgPunchlist.Controls                                                   |
    ' |             If thisPunchlist.Name = tempObject.Name Then                                                                 |
    ' |                 thisPunchlist.BackColor = Color.Red                                                                      |
    ' |             Else                                                                                                         |
    ' |                 thisPunchlist.BackColor = Color.Gray                                                                     |
    ' |             End If                                                                                                       |
    ' |         Next thisPunchlist                                                                                               |
    ' |     End Sub                                                                                                              |
    ' |                                                                                                                          |
    '  •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————• */

    ' /* •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    ' | Private Sub PunchlistObject_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PunchlistObject.DoubleClick |
    ' |     Dim tempObject As New PunchlistManager.ControlPunchlist()                                                                    |
    ' |     tempObject = sender                                                                                                          |
    ' |                                                                                                                                  |
    ' |     Dim frmPunchlistEdit As New PunchlistManager.EditPunchlist(tempObject.Tag, runtime.selectedProjectID)                        |
    ' |     frmPunchlistEdit.txtPunchlist.Text = tempObject.Tag                                                                          |
    ' |     frmPunchlistEdit.ShowDialog()                                                                                                |
    ' | End Sub                                                                                                                          |
    ' |                                                                                                                                  |
    '   •——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————• */

    Private Sub tsb_DocumentAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_DocumentAdd.Click
        Dim frm_AddDocument As New AddPackageDocument(Me.ShowSystem.Tag)
        frm_AddDocument.ThisSystem = Me.ShowSystem.Tag
        frm_AddDocument.ShowDialog()

        DocumentsLoad()
        dgv_PkgDocuments.Refresh()
    End Sub


    Private Sub tsb_DocumentEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_DocumentEdit.Click
        Dim frm_EditDocument As New EditPackageDocument(SelectedDocument, PackageViewerManager.SelectedPackageID)
        frm_EditDocument.ShowDialog()

        DocumentsLoad()
        dgv_PkgDocuments.Refresh()
    End Sub


    Private Sub tsb_DocumentDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_DocumentDelete.Click
        If MessageBox.Show("Are you sure you want to delete the selected document association?", _
           "Delete Document Asscoiation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, _
           MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "DELETE FROM package_documents WHERE DocumentMUID=@DocumentMUID " + _
                " AND PackageMUID = @PackageMUID"

            Dim dt_param As DataTable = sqlPrjUtils.paramDT

            dt_param.Rows.Add("@DocumentMUID", SelectedDocument)
            dt_param.Rows.Add("@PackageMUID", PackageViewerManager.SelectedPackageID)

            'Utilities.ExecuteNonQuery(query, "project")
            sqlPrjUtils.ExecuteNonQuery(query, dt_param)


            tsb_DocumentEdit.Enabled = False
            tsb_DocumentDelete.Enabled = False
            tsb_DocumentView.Enabled = False

            DocumentsLoad()
            dgv_PkgDocuments.Refresh()
        End If
    End Sub


    Private Sub AddDiscrepancyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddDiscrepancyToolStripMenuItem.Click
        Dim frmDiscrepancy As New DiscrepancyManager.frmAddDiscrepancy(PackageViewerManager.SelectedPackageID, PackageViewerManager.SelectedPackagename)
        frmDiscrepancy.ShowDialog()
    End Sub


    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        MessageBox.Show("Please use the Package Manager to add tags.")
    End Sub


    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        MessageBox.Show("Please use the Package Manager to add tags.")
    End Sub


    Private Sub PkgVGridControl1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles PkgVGridControl1.CellValueChanged
        btnUpdatePkgAuxVals.Enabled = True
    End Sub


    Private Sub TagVGridControl1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles TagVGridControl1.CellValueChanged
        btnUpdateTagAuxValue.Enabled = True
    End Sub


    Private Sub GridControl_PkgAuxData(ByVal PackageID As String)
        If Not PkgAuxTable Is Nothing Then
            PkgAuxTable.Dispose()
            PkgVGridControl1.DataSource = Nothing
        End If
        PkgAuxTable = New DataTable("AuxData")
        If Not PkgAuxIDTable Is Nothing Then
            PkgAuxIDTable.Dispose()
        End If
        PkgAuxIDTable = New DataTable("AuxID")

        Dim qry As String = ""
        qry = "SELECT aux_fieldmap.MUID, aux_fieldmap.CustomName, aux_package.auxData " + _
                        " FROM aux_fieldmap, aux_package, aux_template_assoc " + _
                        " WHERE (aux_fieldmap.TemplateMUID = aux_template_assoc.TemplateMUID) AND " + _
                        " (aux_template_assoc.AssocMUID ='" + PackageID.ToString + "') AND " + _
                        " (aux_template_assoc.SourceMUID = 'Package') AND " + _
                        " (aux_package.FieldmapMUID = aux_fieldmap.MUID) AND " + _
                        " ( aux_package.PackageMUID = '" + PackageID.ToString + "')"
        'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        
        If dt.Rows.Count < 1 Then Return


        For i As Integer = 0 To dt.Rows.Count - 1
            Dim DataCol As DataColumn = New DataColumn()
            DataCol.DataType = System.Type.GetType("System.String")
            DataCol.ColumnName = dt.Rows(i)("CustomName")
            PkgAuxTable.Columns.Add(DataCol)
            Dim IDCol As DataColumn = New DataColumn()
            IDCol.DataType = System.Type.GetType("System.String")
            IDCol.ColumnName = dt.Rows(i)("MUID")
            PkgAuxIDTable.Columns.Add(IDCol)
        Next

        Dim rowData As DataRow = PkgAuxTable.NewRow()
        Dim rowID As DataRow = PkgAuxIDTable.NewRow()
        For i As Integer = 0 To dt.Rows.Count - 1
            rowData(i) = dt.Rows(i)("auxData")
            rowID(i) = dt.Rows(i)("MUID")
        Next
        PkgAuxTable.Rows.Add(rowData)
        PkgAuxIDTable.Rows.Add(rowID)
        PkgAuxTable.AcceptChanges()
        PkgAuxIDTable.AcceptChanges()
        PkgVGridControl1.DataSource = PkgAuxTable
        PkgVGridControl1.RowHeaderWidth = 200
        PkgVGridControl1.Refresh()
    End Sub


    Private Sub GridControl_TagAuxData(ByVal TagID As String)
        Dim qry As String = ""
        If Not TagAuxTable Is Nothing Then
            TagAuxTable.Dispose()
            TagVGridControl1.DataSource = Nothing
        End If
        TagAuxTable = New DataTable("AuxData")
        If Not TagAuxIDTable Is Nothing Then
            TagAuxIDTable.Dispose()
        End If
        TagAuxIDTable = New DataTable("AuxID")
        qry = "SELECT aux_fieldmap.MUID, aux_fieldmap.CustomName, aux_tags.auxData " + _
                        " FROM aux_fieldmap, aux_tags, aux_template_assoc " + _
                        " WHERE (aux_fieldmap.TemplateMUID = aux_template_assoc.TemplateMUID) AND " + _
                        " (aux_template_assoc.AssocMUID ='" + TagID.ToString + "') AND " + _
                        " (aux_template_assoc.SourceMUID = 'Tag') AND " + _
                        " (aux_tags.FieldmapMUID = aux_fieldmap.MUID) AND " + _
                        " ( aux_tags.TagMUID = '" + TagID.ToString + "')"
        'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        
        If dt.Rows.Count < 1 Then Return
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim DataCol As DataColumn = New DataColumn()
            DataCol.DataType = System.Type.GetType("System.String")
            DataCol.ColumnName = dt.Rows(i)("CustomName")
            TagAuxTable.Columns.Add(DataCol)
            Dim IDCol As DataColumn = New DataColumn()
            IDCol.DataType = System.Type.GetType("System.String")
            IDCol.ColumnName = dt.Rows(i)("MUID")
            TagAuxIDTable.Columns.Add(IDCol)
        Next

        Dim rowData As DataRow = TagAuxTable.NewRow()
        Dim rowID As DataRow = TagAuxIDTable.NewRow()
        For i As Integer = 0 To dt.Rows.Count - 1
            rowData(i) = dt.Rows(i)("auxData")
            rowID(i) = dt.Rows(i)("MUID")
        Next
        TagAuxTable.Rows.Add(rowData)
        TagAuxIDTable.Rows.Add(rowID)
        TagAuxTable.AcceptChanges()
        TagAuxIDTable.AcceptChanges()
        TagVGridControl1.DataSource = TagAuxTable
        TagVGridControl1.RowHeaderWidth = 200
        TagVGridControl1.BringToFront()
        TagVGridControl1.Refresh()

    End Sub


    Private Sub UpdatePkgAuxData()
        If PackageID > "" Then
            For j As Integer = 0 To PkgVGridControl1.Rows.Count - 1
                If Not IsDBNull(PkgVGridControl1.GetCellValue(Me.PkgVGridControl1.Rows(j), 0)) Then
                    Dim colVal As String = PkgVGridControl1.GetCellValue(Me.PkgVGridControl1.Rows(j), 0)
                    Dim colID As String = PkgAuxIDTable.Rows(0)(j)
                    Dim qry = " UPDATE aux_package SET auxData = @auxData" + _
                                    " WHERE  (FieldmapMUID =@FieldmapMUID) AND (" + _
                                    " PackageMUID = @PackageMUID)"
                    Dim dt_param As DataTable = sqlPrjUtils.paramDT

                    dt_param.Rows.Add("@FieldmapMUID", colID.ToString)
                    dt_param.Rows.Add("@PackageMUID", PackageID.ToString)
                    dt_param.Rows.Add("@auxData", colVal)

                    sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                End If
            Next
        End If
    End Sub


    Private Sub btnUpdatePkgAuxVals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdatePkgAuxVals.Click
        UpdatePkgAuxData()
        btnUpdatePkgAuxVals.Enabled = False
    End Sub


    Private Sub UpdateTagAuxData()
        If Not TagID = "" Then

            Dim query As String
            Dim dt As DataTable
            Dim dt2 As DataTable
            Dim DataModified As Boolean = False
            Dim ModifiedString As String = "The following tag auxiliary data has been modified:  "

            For j As Integer = 0 To TagVGridControl1.Rows.Count - 1
                If Not IsDBNull(TagVGridControl1.GetCellValue(Me.TagVGridControl1.Rows(j), 0)) Then
                    Dim colVal As String = TagVGridControl1.GetCellValue(Me.TagVGridControl1.Rows(j), 0)
                    Dim colID As String = TagAuxIDTable.Rows(0)(j)

                    query = "SELECT auxData FROM aux_tags WHERE " & _
                            "(FieldmapMUID = '" + colID + "') AND (" + _
                            " TagMUID = '" + TagID + "')"
                    dt = sqlPrjUtils.ExecuteQuery(query)

                    query = "SELECT CustomName FROM aux_fieldmap WHERE " & _
                            "idaux_fieldmap = '" + colID + "'"
                    dt2 = sqlPrjUtils.ExecuteQuery(query)
                    Dim fieldCustomName As String = Nothing
                    If dt2.Rows.Count > 0 Then
                        fieldCustomName = dt2.Rows(0)(0)
                    Else
                        fieldCustomName = Me.TagVGridControl1.Rows(j).Properties.Caption
                    End If

                    If dt.Rows.Count > 0 Then
                        If colVal <> dt.Rows(0)(0) And Not colVal = "" Then
                            DataModified = True
                            ModifiedString += " " + fieldCustomName + " : from '" + dt.Rows(0)(0) + "' to '" + colVal + "',"
                        End If
                    End If

                    Dim qry = " UPDATE aux_tags SET auxData = @auxData, Aux05='1' WHERE  (FieldmapMUID =@FieldmapMUID)" + _
                                " AND (TagMUID = @TagMUID)"
                    Dim dt_param As DataTable = sqlPrjUtils.paramDT

                    dt_param.Rows.Add("@auxData", colVal)
                    dt_param.Rows.Add("@FieldmapMUID", colID)
                    dt_param.Rows.Add("@TagMUID", TagID)

                    sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
                End If
            Next
            If DataModified Then
                Dim dt_param As DataTable = sqlPrjUtils.paramDT
                query = "INSERT INTO discrepancy (MUID,TS,Title," & _
                    " Description,Resolution,ListedBy,ListedOn,ClosedBy,ClosedOn,Status,ManHours," & _
                    " PackageMUID) VALUES (" & _
                    " @MUID," & _
                    " @TS," & _
                    " @Title," & _
                    " @Description," & _
                    " @Resolution," & _
                    " @ListedBy," & _
                    " @ListedOn," & _
                    " @ClosedBy," & _
                    " @ClosedOn," & _
                    " @Status," & _
                    " @ManHours," & _
                    " @PackageMUID)"

                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "discrepancy"))
                dt_param.Rows.Add("@TS", Now())
                dt_param.Rows.Add("@Title", tbx_TagID.Text + " Aux Data Modified',")
                dt_param.Rows.Add("@Description", ModifiedString)
                dt_param.Rows.Add("@Resolution", "Auto-Resolve")
                dt_param.Rows.Add("@ListedBy", runtime.UserMUID.ToString)
                dt_param.Rows.Add("@ListedOn", Now().ToString)
                dt_param.Rows.Add("@ClosedBy", runtime.UserMUID.ToString)
                dt_param.Rows.Add("@ClosedOn", Now().ToString)
                dt_param.Rows.Add("@Status", "Pending")
                dt_param.Rows.Add("@ManHours", 0)
                dt_param.Rows.Add("@PackageMUID", Me.PackageID.ToString)

                sqlPrjUtils.ExecuteNonQuery(query, dt_param)
            End If
        End If
    End Sub


    Private Sub btnUpdateTagAuxValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateTagAuxValue.Click
        UpdateTagAuxData()
        btnUpdateTagAuxValue.Enabled = False
    End Sub


    Private Sub dgv_PkgDocuments_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_PkgDocuments.CellFormatting
        If e.ColumnIndex = dgv_PkgDocuments.Columns("Document").Index Then
            Dim DocID As String = dgv_PkgDocuments.Rows(e.RowIndex()).Cells("ID").Value
            If Utilities.TestPkgDocContainsRedLineItems(DocID, PackageID) Then
                e.CellStyle.BackColor = Color.Red
            End If
        End If
    End Sub


    Private Sub PkgMatrixTabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PkgMatrixTabControl.SelectedIndexChanged
        If Loading Then Return
        If Utilities.CountTags(PackageID) > 0 Then

            GetPackageForms()
            MatrixStatus()

        Else
            PkgMatrix.Visible = False
        End If
        PkgMatrixTabControl.SelectedTab.Controls.Add(PkgMatrix)
        PkgMatrix.Dock = DockStyle.Fill
    End Sub


    Private Sub tab_RefDocs_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab_RefDocs.Enter
        GenerateRefDocs()
    End Sub


    Private Sub GenerateRefDocs()
        If Loading Then Return
        Dim query As String = "SELECT * FROM tags WHERE PackageMUID = '" + Me.PackageID + "'"
        Dim dt As DataTable = Me.sqlPrjUtils.ExecuteQuery(query)

        Dim dt_AllDocs As New DataTable()
        dt_AllDocs.Columns.Add("MUID")
        dt_AllDocs.Columns.Add("TAG")
        dt_AllDocs.Columns.Add("TITLE")
        dt_AllDocs.Columns.Add("DESCRIPTION")
        dt_AllDocs.Columns.Add("DATE")

        dt_AllDocs.Columns(0).ColumnMapping = MappingType.Hidden

        For Each dr As DataRow In dt.Rows
            query = "SELECT r.MUID,t.TagNumber,r.Title,r.Description,r.TS FROM ReferenceLibrary as r" & _
                " LEFT JOIN tags as t ON r.Aux07 = t.MUID WHERE " & _
                " t.MUID = '" + dr("MUID") + "'"
            Dim dt_Docs As DataTable = Me.sqlPrjUtils.ExecuteQuery(query)
            For i As Integer = 0 To dt_Docs.Rows.Count - 1
                dt_AllDocs.Rows.Add(dt_Docs.Rows(i)(0), dt_Docs.Rows(i)(1), dt_Docs.Rows(i)(2), dt_Docs.Rows(i)(3), dt_Docs.Rows(i)(4))
            Next
        Next

        Me.dgv_RefDocs.DataSource = dt_AllDocs
    End Sub


    Private Sub btn_RefDocAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RefDocAdd.Click
        Dim ThisTagID As String = CommonForms.Classes.GetTagMUID(PackageViewerManager.SelectedPackageID)

        If ThisTagID = "" Then
            Return
        End If

        Dim frm_RefDocAdd As New AddDocRef("add", ThisTagID)
        frm_RefDocAdd.ShowDialog()

        GenerateRefDocs()
    End Sub


    Private Sub dgv_RefDocs_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_RefDocs.DoubleClick
        Dim View As ColumnView = Me.dgv_RefDocs.MainView
        Dim ParentView As GridView = View.ParentView

        Me.Cursor = Cursors.AppStarting
        RefLibUtils.ViewReference(View.GetFocusedRowCellValue("MUID"))
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub btn_RefDocEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RefDocEdit.Click
        Dim View As ColumnView = Me.dgv_RefDocs.MainView
        Dim ParentView As GridView = View.ParentView
        Dim addForm As New AddDocRef("edit", View.GetFocusedRowCellValue("MUID"))
        addForm.ShowDialog()

        GenerateRefDocs()
    End Sub


    Private Sub btn_RefDocDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RefDocDelete.Click
        Dim View As ColumnView = Me.dgv_RefDocs.MainView
        Dim ParentView As GridView = View.ParentView

        If (MessageBox.Show("Are you sure you want to delete the selected reference?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            RefLibUtils.DeleteReference(View.GetFocusedRowCellValue("MUID"))
        End If

        GenerateRefDocs()
    End Sub


    Private Sub UpdateStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateStatusToolStripMenuItem.Click
        Dim frm_Status As New ManualStatus(Me.SelectedTagMUID, Me.SelectedFormMUID, Me.PackageOwner)
        frm_Status.ShowDialog()
    End Sub

    Private Sub nud_Priority_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nud_Priority.ValueChanged
        If Loading Then Return
        PackageUpdate()
    End Sub

    Private Sub ckbx_Audit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbx_Audit.CheckedChanged
        If Loading Then Return
        PackageUpdate()
    End Sub


    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub cms_TagGrid_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cms_TagGrid.Opening

    End Sub

    Private Sub tab_PkgGeneral_Click(sender As Object, e As EventArgs) Handles tab_PkgGeneral.Click

    End Sub
End Class