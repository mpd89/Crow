Imports System
Imports System.Data
Imports System.Data.SqlServerCe
Imports System.Windows.Forms
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports daqartDLL
Imports System.IO


Public Class FormMain
    Public SelectedDataType As FormUtils.FormDataType = FormUtils.FormDataType.Text
    Public SelectedColor As String
    Public SelectedFormID As String

    Private AuxTagTable As DataTable
    Private AuxPkgTable As DataTable
    Public Shared mFont As Font

    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView = Nothing

    Dim ImgCon As New Daqument.P2I


    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.tsl_SiteLabel.Text = "Site: " + runtime.SiteName
        Me.ProjectStatusInd.Text = "Project: " + runtime.selectedProject
        FormatToolStripMenuItem.Enabled = False

    End Sub


    Private Function IsMultiElement(ByVal FormID As String) As Boolean
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim query As String = " SELECT MultiElement FROM forms WHERE MUID='" + FormID.ToString + "'"
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        'If Not IsDBNull(dt.Rows(0)(0)) Then
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(0) = 1 Then
                Return True
            Else
                Return False
            End If
        End If
        Return False
    End Function


    Private Sub FormList_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles FormList.DropDownItemClicked

        For Each thisChild As Form In Me.MdiChildren
            If thisChild.Name = e.ClickedItem.Name Then
                'Me.ActivateMdiChild(thisChild)
                thisChild.Activate()
                thisChild.WindowState = FormWindowState.Normal
                thisChild.BringToFront()

            End If
        Next thisChild

        For Each thisItem As ToolStripMenuItem In FormList.DropDownItems
            If thisItem.Text = e.ClickedItem.Text Then
                thisItem.Checked = True
            Else
                thisItem.Checked = False
            End If
        Next thisItem
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub


    Public Sub InitializeMultiElementView()
        If IsMultiElement(SelectedFormID) Then
            LoadSubForm(SelectedFormID)
            btn_SubForm.Enabled = True
            lbx_ElementFields.Visible = True
            cbx_Elements.Visible = True
        Else
            btn_SubForm.Enabled = False
            lbx_ElementFields.DataSource = Nothing
            lbx_ElementFields.Items.Clear()
            cbx_Elements.DataSource = Nothing
            cbx_Elements.Items.Clear()
            lbx_ElementFields.Visible = False
            cbx_Elements.Visible = False
        End If
    End Sub


    Private Sub SetupAuxTables()
        If Not AuxPkgTable Is Nothing Then
            AuxPkgTable.Reset()
        End If
        If Not AuxTagTable Is Nothing Then
            AuxTagTable.Reset()
        End If
        Dim qry = "SELECT PackageTemplateMUID,TagTemplateMUID FROM Forms WHERE MUID = '" + SelectedFormID.ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("PackageTemplateMUID").ToString > "" Then
                qry = "SELECT MUID,CustomName FROM aux_fieldmap " + _
                        " WHERE TemplateMUID = '" + dt.Rows(0)("PackageTemplateMUID").ToString + "'"

                AuxPkgTable = sqlPrjUtils.ExecuteQuery(qry)
            End If
            If dt.Rows(0)("TagTemplateMUID").ToString > "" Then
                qry = "SELECT MUID,CustomName FROM aux_fieldmap " + _
                        " WHERE TemplateMUID = '" + dt.Rows(0)("TagTemplateMUID").ToString + "'"

                AuxTagTable = sqlPrjUtils.ExecuteQuery(qry)
            End If
        End If
        sqlPrjUtils.CloseConnection()

    End Sub



    Public Sub InitializeMenuTreeView()

        Dim qry = "SELECT SystemForm FROM Forms WHERE SystemForm = '1' AND MUID = '" + SelectedFormID.ToString + "'"

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        If dt.Rows.Count > 0 Then
            InitializeSystemMenuTreeView()
        Else
            InitializePackageMenuTreeView()
        End If


    End Sub


    Public Sub InitializePackageMenuTreeView()
        Try
            FormatToolStripMenuItem.Enabled = True

            If Not TreeView1 Is Nothing Then
                TreeView1.Dispose()
                TreeView1 = Nothing
                'Return
            End If
            TreeView1 = New System.Windows.Forms.TreeView
            TreeView1.Location = New System.Drawing.Point(0, 30)
            TreeView1.Name = "TreeView1"
            TreeView1.Size = New System.Drawing.Size(200, 400)

            Dim tblNames As New Dictionary(Of String, String)

            ' Create the root node.
            tblNames.Add("Project Info", "Title,Description,Location")

            'tblNames.Add("System Info", "System Number,System Description") - NOT WORKING
            'get tiers
            Dim query As String = "SELECT * FROM system_mnemonic ORDER BY TierNumber ASC"
            Dim dt_Tiers As DataTable = runtime.SQLProject.ExecuteQuery(query)

            Dim TierString As String = ""
            For i As Integer = 0 To dt_Tiers.Rows.Count - 1
                TierString += dt_Tiers.Rows(i)("Description") + ","
            Next
            TierString += "Project #"
            tblNames.Add("System Info", TierString)

            tblNames.Add("engineering_data", "Remarks,Prefix,Description," + _
                    "Service,Manufacturer,ModelNumber,SerialNumber,PONumber,LineNumber")
            tblNames.Add("equipment_type", "TypeName,TypeDesc,Active")
            tblNames.Add("package", "PackageNumber,SystemNumber,Description")
            tblNames.Add("tags", "TagNumber")

            Dim sqlSrvUtils As DataUtils = New DataUtils("server")
            Dim qry = "SELECT * FROM levels WHERE Name!='Undefined'"
            sqlSrvUtils.OpenConnection()
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(qry)
            sqlSrvUtils.CloseConnection()


            For i As Integer = 0 To dt.Rows.Count - 1
                Dim signoffLevel As String = "SignOff_Level" + (i + 1).ToString
                Dim SignOffAttributes As String = "Name,Number,Company,Title,Date,Signature"
                tblNames.Add(signoffLevel, SignOffAttributes)
            Next

            qry = "SELECT * FROM document_type"
            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

            sqlDocUtils.OpenConnection()
            dt = sqlDocUtils.ExecuteQuery(qry)
            sqlDocUtils.CloseConnection()

            Dim DocumentTypes As String = Nothing
            For i As Integer = 0 To dt.Rows.Count - 1
                DocumentTypes += dt.Rows(i)(2)
                If i < dt.Rows.Count - 1 Then
                    DocumentTypes += ","
                End If
            Next
            tblNames.Add("Documents", DocumentTypes)
            SetupAuxTables()
            If Not AuxPkgTable Is Nothing Then
                If AuxPkgTable.Rows.Count > 0 Then
                    Dim PkgTemplateKey As String = "Package Auxiliary Data"
                    Dim PkgAuxiliaryValue As String = ""
                    For i As Integer = 0 To AuxPkgTable.Rows.Count - 1
                        If AuxPkgTable.Rows(i)("CustomName").ToString > "" Then
                            PkgAuxiliaryValue = PkgAuxiliaryValue + AuxPkgTable.Rows(i)("CustomName").ToString + ","
                        End If
                    Next
                    If PkgAuxiliaryValue > "" Then
                        PkgAuxiliaryValue = PkgAuxiliaryValue.Remove(PkgAuxiliaryValue.Length - 1, 1)
                        tblNames.Add(PkgTemplateKey, PkgAuxiliaryValue)
                    End If
                End If
            End If
            If Not AuxTagTable Is Nothing Then
                If AuxTagTable.Rows.Count > 0 Then
                    Dim TagTemplateKey As String = "Tag Auxiliary Data"
                    Dim TagAuxiliaryValue As String = ""
                    For i As Integer = 0 To AuxTagTable.Rows.Count - 1
                        If AuxTagTable.Rows(i)("CustomName").ToString > "" Then
                            TagAuxiliaryValue = TagAuxiliaryValue + AuxTagTable.Rows(i)("CustomName").ToString + ","
                        End If
                    Next
                    If TagAuxiliaryValue > "" Then
                        TagAuxiliaryValue = TagAuxiliaryValue.Remove(TagAuxiliaryValue.Length - 1, 1)
                        tblNames.Add(TagTemplateKey, TagAuxiliaryValue)
                    End If
                End If
            End If

            Dim keys As Dictionary(Of String, String).KeyCollection = tblNames.Keys

            TreeView1.BeginUpdate()

            ' Clear the TreeView each time the method is called.
            TreeView1.Nodes.Clear()
            For Each s As String In keys
                Dim myItem = TreeView1.Nodes.Add(New TreeNode(s))
                Dim myStr() = Split(tblNames(s), ",")
                Dim i As Integer
                For i = 0 To (UBound(myStr))
                    Dim ms As String = myStr(i)
                    TreeView1.Nodes(myItem).Nodes.Add(New TreeNode(ms))
                Next
            Next s

            TreeView1.EndUpdate()
            spl_Variables.Panel1.Controls.Add(TreeView1)
            TreeView1.Dock = DockStyle.Fill
            TreeView1.BringToFront()
            AddHandler TreeView1.ItemDrag, AddressOf TreeView_ItemDrag
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub InitializeSystemMenuTreeView()

        Try
            If Not TreeView1 Is Nothing Then
                TreeView1.Dispose()
                TreeView1 = Nothing
            End If

            TreeView1 = New System.Windows.Forms.TreeView
            TreeView1.Location = New System.Drawing.Point(0, 30)
            TreeView1.Name = "TreeView1"
            TreeView1.Size = New System.Drawing.Size(200, 400)

            Dim tblNames As New Dictionary(Of String, String)

            'define tree nodes here
            tblNames.Add("Project Info", "Title,Description,Location")
            tblNames.Add("System Info", "System Number,System Description")
            tblNames.Add("Handover Info", "Title,MC1#,SH1#,Maintenance#,Work Pack#")


            Dim keys As Dictionary(Of String, String).KeyCollection = tblNames.Keys

            TreeView1.BeginUpdate()

            ' Clear the TreeView each time the method is called.
            TreeView1.Nodes.Clear()
            For Each s As String In keys
                Dim myItem = TreeView1.Nodes.Add(New TreeNode(s))
                Dim myStr() = Split(tblNames(s), ",")
                Dim i As Integer
                For i = 0 To (UBound(myStr))
                    Dim ms As String = myStr(i)
                    TreeView1.Nodes(myItem).Nodes.Add(New TreeNode(ms))
                Next
            Next s

            TreeView1.EndUpdate()
            spl_Variables.Panel1.Controls.Add(TreeView1)
            TreeView1.Dock = DockStyle.Fill
            TreeView1.BringToFront()
            AddHandler TreeView1.ItemDrag, AddressOf TreeView_ItemDrag
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TreeView_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles TreeView1.ItemDrag
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim tn As TreeNode = e.Item
            'invoke the drag and drop operation
            If tn.Level = 1 Then
                DoDragDrop(e.Item, DragDropEffects.Move Or DragDropEffects.Copy)

            End If
        End If
    End Sub


    Private Sub dataTypeText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataTypeText.Click
        SelectedDataType = FormUtils.FormDataType.Text
    End Sub

    Private Sub dataTypeNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataTypeNumber.Click
        SelectedDataType = FormUtils.FormDataType.Number
    End Sub

    Private Sub dataTypeDateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataTypeDateTime.Click
        SelectedDataType = FormUtils.FormDataType.DateTime
    End Sub

    Private Sub dataTypeBoolean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataTypeBoolean.Click
        SelectedDataType = FormUtils.FormDataType.yesNo
    End Sub

    Private Sub BackgroundColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BkColor.Click
        If ColorDialog1.ShowDialog() <> System.Windows.Forms.DialogResult.Cancel Then
            BkColor.BackColor = ColorDialog1.Color
            SelectedColor = BkColor.BackColor.ToArgb.ToString
        End If
    End Sub

    Private Sub FontSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontSelect.Click
        FontDialog1.ShowColor = True

        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            FontSelect.Font = FontDialog1.Font
            FontSelect.ForeColor = FontDialog1.Color


            For Each thisChild As Form In Me.MdiChildren
                TryCast(thisChild, FormEditing).mFont = FontSelect.Font
            Next thisChild


        End If
    End Sub



    Private Sub FrmClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)

        Dim tmpForm As Form = sender
        For Each thisItem As ToolStripMenuItem In FormList.DropDownItems
            If thisItem.Name = tmpForm.Name Then
                FormList.DropDownItems.Remove(thisItem)
                Return
            End If
        Next thisItem
    End Sub



    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim myform As New FormSelect
        myform.ShowDialog()

    End Sub


    Private Sub btn_SubForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SubForm.Click
        Dim myform As New SubForm(SelectedFormID)
        myform.ShowDialog()
        If IsMultiElement(SelectedFormID) Then
            LoadSubForm(SelectedFormID)
        End If
    End Sub

    Private Sub LoadSubForm(ByVal FormID As String)
        cbx_Elements.Items.Clear()
        lbx_ElementFields.DataSource = Nothing

        Dim query As String
        query = "SELECT NumberofElements FROM forms WHERE MUID='" + FormID.ToString + "'"
        Dim dt_Elements As New DataTable
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        dt_Elements = sqlPrjUtils.ExecuteQuery(query)


        If Not dt_Elements.Rows.Count = 0 And Not IsDBNull(dt_Elements.Rows(0)(0)) Then
            For i As Integer = 1 To dt_Elements.Rows(0)(0)
                cbx_Elements.Items.Add("Element" + i.ToString)
            Next
        End If

        Dim dt_fields As New DataTable
        dt_fields.Columns.Add("Fieldname")
        dt_fields.Rows.Add("TagNumber")
        dt_fields.Rows.Add("Description")
        dt_fields.Rows.Add("Remarks")
        dt_fields.Rows.Add("Service")
        dt_fields.Rows.Add("Manufacturer")
        dt_fields.Rows.Add("ModelNumber")
        dt_fields.Rows.Add("SerialNumber")
        dt_fields.Rows.Add("PONumber")
        dt_fields.Rows.Add("LineNumber")


        query = "SELECT * FROM aux_subforms_fields WHERE FormMUID='" + FormID.ToString + "'"
        Dim dt As New DataTable
        'dt = Utilities.ExecuteRemoteQuery(query, "project")
        dt = sqlPrjUtils.ExecuteQuery(query)
        If Not dt.Rows.Count = 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                dt_fields.Rows.Add(dt.Rows(i)(3))
            Next
        End If

        lbx_ElementFields.DataSource = dt_fields
        lbx_ElementFields.DisplayMember = dt_fields.Columns("Fieldname").ToString

        btn_SubForm.Enabled = True
        sqlPrjUtils.CloseConnection()

    End Sub


    Private Sub lbx_ElementFields_DragDrop(ByVal sender As Object, ByVal e As Windows.Forms.MouseEventArgs) Handles lbx_ElementFields.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then

            Dim tmp_Listbox As ListBox = sender

            DoDragDrop(sender, DragDropEffects.Move Or DragDropEffects.Copy)
        End If

    End Sub


    Private Sub cbx_Elements_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_Elements.SelectedIndexChanged
        lbx_ElementFields.Tag = cbx_Elements.SelectedIndex + 1
    End Sub


    Private Sub ConnTimer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles ConnTimer.Elapsed

        For Each frm As Form In Me.MdiChildren
            If frm.Name = SelectedFormID Then
                frm.Focus()
            End If
        Next
    End Sub



    Private Sub SelectAuxiliaryDataTemplateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAuxiliaryDataTemplateToolStripMenuItem.Click
        Dim fm As Form = New FormAuxTemplate(SelectedFormID)
        fm.ShowDialog()
        InitializeMenuTreeView()
    End Sub


    Private Sub ReloadFormImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadFormImageToolStripMenuItem.Click

        If Not SelectedFormID = "" Then

            With OpenFileDialog1
                .Title = "Pick a file to upload..."
                .FileName = ""
                .CheckFileExists() = True
                .CheckPathExists = True
                .ValidateNames = True
                .DereferenceLinks = True

                .InitialDirectory = Directory.GetCurrentDirectory
                .Filter = "PDF files (*.pdf)|*.pdf"
                .FilterIndex = 1
                .ShowDialog(Me)

                If .FileName <> "" Then
                    Dim fi As New IO.FileInfo(.FileName)
                    If fi.Extension = ".pdf" Then
                        Dim dr As String = runtime.AbsolutePath + "sites\Forms\images\"
                        Dim fentries As String() = Directory.GetFiles(dr)
                        Dim fs As String
                        For Each fs In fentries
                            File.Delete(fs)
                        Next
                        ImgCon.ImgConvert(dr, .FileName, "100", "100", False)
                        fentries = Directory.GetFiles(dr)
                        If fentries.Length > 1 Then
                            If Utilities.IsFormMultiElement(SelectedFormID) Then
                                MessageBox.Show("Multiple pages are not supported for multi element forms")
                                fentries = Directory.GetFiles(dr)
                                For Each fs In fentries
                                    File.Delete(fs)
                                Next
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End With
        End If

        AddBaseFile(SelectedFormID)

        OpenFormEdit(SelectedFormID)

        MessageBox.Show("Form must be re-opened to load new image.")

    End Sub


    Public Function AddBaseFile(ByVal newFormID As String) As String
        Dim strBLOBFilePath As String = OpenFileDialog1.FileName
        Dim fsBLOBFile As New FileStream(strBLOBFilePath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fsBLOBFile)
        Dim chunk As Byte() = br.ReadBytes(fsBLOBFile.Length - 1)

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim muid = idUtils.GetNextMUID("project", "forms_storage")
        Dim qry As String = "UPDATE forms_storage SET BaseImage= @BaseImage WHERE FormMUID='" + SelectedFormID + "'"
        sqlPrjUtils.ExecuteSingleParameterizedQuery(qry, "@BaseImage", chunk)

        sqlPrjUtils.CloseConnection()
        Return muid
    End Function


    Sub OpenFormEdit(ByVal newFormID As String)
        Dim dr As String = runtime.AbsolutePath + "sites\Forms\images\"
        Dim d As IO.DirectoryInfo = New IO.DirectoryInfo(dr)
        Dim enumerator As System.Collections.IEnumerator = CType(d.GetFiles("*.png"), System.Collections.IEnumerable).GetEnumerator
        Dim PageNum As Integer = 1
        Try
            Do While enumerator.MoveNext
                Dim f As IO.FileInfo = CType(enumerator.Current, IO.FileInfo)
                Dim buffer() As Byte = New Byte((f.OpenRead.Length) - 1) {}
                f.OpenRead.Read(buffer, 0, CType(f.OpenRead.Length, Integer))
                AddFormsImage(buffer, PageNum, newFormID)
                PageNum = PageNum + 1
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Function AddFormsImage(ByVal buffer As Array, ByVal PgNum As Integer, ByVal NewFormID As String) As String
        Dim muid = idUtils.GetNextMUID("project", "forms_image")
        Dim qry As String = "UPDATE forms_image SET FormImage = @FormImage WHERE FormMUID='" + NewFormID + "' AND PageNumber='" + PgNum.ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        sqlPrjUtils.ExecuteSingleParameterizedQuery(qry, "@FormImage", buffer)
        Return muid
    End Function

End Class