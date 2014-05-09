Imports daqartDLL
Imports ProjectWizard
Imports System.Threading


Public Class DataManagerMain
    Dim myselectednode As TreeNode
    Dim stroldnode As String
    Dim strnode As String
    Dim strparent As String
    Dim stroldtag As String
    Private SelectedSignOffOwner As String
    Dim SQLServer As DataUtils
    Dim SQLProject As DataUtils
    Public Loading As Boolean = False


    Public Enum eStatus
        Company = 0
        Discipline = 1
        Group = 2
        Level = 3
        Owner = 4
        User = 5
    End Enum


    Private Sub DataManagerMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLServer.CloseConnection()
        SQLProject.CloseConnection()
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SQLServer = New DataUtils("server")
            SQLServer.OpenConnection()
            SQLProject = New DataUtils("project")
            SQLProject.OpenConnection()

            Loading = True
            Me.tsl_SiteLabel.Text = "Site: " + runtime.SiteName
            Me.ProjectStatusInd.Text = "Project: " + runtime.selectedProject

            generatenodes(0, "company")
            generatenodes(1, "discipline")
            generatenodes(2, "groups")
            generatenodes(3, "levels")
            generatenodes(4, "owner")
            generateusernode(5, "userInfo")

            If runtime.selectedProject = Nothing Then
                trvComplete.Nodes("ProjectDB").Remove()
            Else
                'sign=-off
                generateSignoff()
            End If

            Loading = False
        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.DataManagerMain.Form1_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Sub createform(ByVal name As String)
        Dim frmA As New AddCompany
        frmA.Text = name.ToString
        frmA.ShowDialog()
        RefreshTree()
    End Sub


    Private Sub tsbAddCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAddCompany.Click
        createform("Add Company")
    End Sub


    Public Sub generatenodes(ByVal nodetag As Integer, ByVal tablename As String)
        Dim Company As New TreeNode
        Dim query As String = "SELECT * FROM " + tablename + " WHERE Name != 'Undefined' ORDER BY Name ASC"
        Dim dt As New DataTable
        dt = SQLServer.ExecuteQuery(query)

        Dim i As Integer
        trvComplete.Nodes(0).Nodes(nodetag).Nodes.Clear()

        Try
            For i = 0 To dt.Rows.Count - 1
                Dim temp As New TreeNode
                temp.Tag = dt.Rows(i).Item(0)
                temp.Text = dt.Rows(i).Item(2) + " - " + dt.Rows(i).Item(3)
                If dt.Rows(i)("Active") = "1" Then
                Else
                    temp.ForeColor = Color.Red
                    temp.Checked = True
                End If
                trvComplete.Nodes(0).Nodes(nodetag).Nodes.Add(temp)
                temp.ContextMenuStrip = CMSNode
            Next
        Catch ex As Exception

        End Try

        trvComplete.Refresh()
        trvComplete.Update()
    End Sub


    Public Sub generateusernode(ByVal nodetag As Integer, ByVal tablename As String)
        Dim Company As New TreeNode
        Dim query As String = "select * from userInfo WHERE MUID <> 1"
        Dim dt As DataTable = SQLServer.ExecuteQuery(query)

        Dim i As Integer
        trvComplete.Nodes(0).Nodes(nodetag).Nodes.Clear()

        Try
            For i = 0 To dt.Rows.Count - 1
                Dim temp As New TreeNode
                temp.Tag = dt.Rows(i).Item(0)
                temp.Text = dt.Rows(i).Item(1) + " - " + Utilities.GetUserName(dt.Rows(i).Item(0))
                trvComplete.Nodes(0).Nodes(nodetag).Nodes.Add(temp)
                temp.ContextMenuStrip = CMSNode
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click
        If (Not trvComplete.SelectedNode.Parent Is Nothing) Then
            Dim ActiveState As String = IIf(GetActiveInfo(), "1", "0")
            Dim flg As String = ""
            Dim dr As DialogResult
            If ActiveState = "1" Then
                dr = MessageBox.Show("Are you sure you want to de-activate  " + trvComplete.SelectedNode.Text, "Caption", MessageBoxButtons.YesNo)
                flg = "0"
            Else
                dr = MessageBox.Show("Are you sure you want to activate  " + trvComplete.SelectedNode.Text, "Caption", MessageBoxButtons.YesNo)
                flg = "1"
            End If
            If (dr = DialogResult.Yes) Then

                Dim qry As String = Nothing
                Select Case trvComplete.SelectedNode.Parent.Text
                    Case "Company"
                        qry = "UPDATE company SET Active = @Active WHERE Name = @Name"
                    Case "Discipline"
                        qry = "UPDATE discipline SET Active = @Active WHERE Name = @Name"
                    Case "Levels"
                        qry = "UPDATE levels SET Active = @Active WHERE Name = @Name"
                    Case "Groups"
                        qry = "UPDATE groups SET Active = @Active WHERE Name = @Name"
                    Case "Owner"
                        qry = "UPDATE owner SET Active = @Active WHERE Name = @Name"
                    Case "User"
                        qry = "UPDATE userInfo SET Active = @Active WHERE UserName = @Name"
                End Select

                Dim sqlSrvUtils As DataUtils = New DataUtils("server")
                Dim dt_param As DataTable = SQLServer.paramDT

                dt_param.Rows.Add("@Active", flg.ToString)
                dt_param.Rows.Add("@Name", trvComplete.SelectedNode.Text)

                sqlSrvUtils.OpenConnection()
                sqlSrvUtils.ExecuteNonQuery(qry, dt_param)
                sqlSrvUtils.CloseConnection()

                RefreshTree()
            End If
        Else
            MessageBox.Show("Root node")
        End If
    End Sub


    Private Sub CompanyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyToolStripMenuItem1.Click
        Dim frmA As New AddCompany
        frmA.TopLevel = False
        frmA.MdiParent = Me
        frmA.WindowState = FormWindowState.Maximized
        Me.SplitContainer1.Panel2.Controls.Add(frmA)
        frmA.Text = "Add Company"
        frmA.Show()
        RefreshTree()
    End Sub


    Private Sub tspAddDiscipline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tspAddDiscipline.Click
        createform("Add Discipline")
    End Sub


    Private Sub tspAddGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tspAddGroup.Click
        createform("Add Group")
    End Sub


    Private Sub tspAddLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tspAddLevel.Click
        createform("Add Level")
    End Sub


    Private Sub tspAddOwner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tspAddOwner.Click
        createform("Add Owner")
    End Sub


    Private Sub DisciplineToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisciplineToolStripMenuItem1.Click
        createform("Add Discipline")
    End Sub


    Private Sub LevelToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LevelToolStripMenuItem1.Click
        createform("Add Level")
    End Sub


    Private Sub OwnerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OwnerToolStripMenuItem1.Click
        createform("Add Owner")
    End Sub


    Private Sub GroupToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupToolStripMenuItem1.Click
        createform("Add Group")
    End Sub


    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshTree()
    End Sub


    Public Sub RefreshTree()
        generatenodes(0, "company")
        generatenodes(1, "discipline")
        generatenodes(2, "groups")
        generatenodes(3, "levels")
        generatenodes(4, "owner")
        generateusernode(5, "userInfo")

        If trvComplete.SelectedNode.Name = "nodeUser" Then
            ListUsers()
        End If

        If Not runtime.selectedProject = Nothing Then
            generateSignoff()
        End If

    End Sub


    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        Try
            If (Not trvComplete.SelectedNode.Parent Is Nothing) Then
                Select Case trvComplete.SelectedNode.Parent.Text
                    Case "Company"
                        ViewForm()
                    Case "Discipline"
                        ViewForm()
                    Case "Levels"
                        ViewForm()
                    Case "Groups"
                        ViewForm()
                    Case "Owner"
                        ViewForm()
                    Case "User"
                        Dim ShortID As String() = Split(trvComplete.SelectedNode.Text, " - ")
                        Dim nu As New frmUser(Utilities.GetUserID(ShortID(0)))
                End Select
            End If
        Catch ex As System.NullReferenceException
        End Try
    End Sub


    Private Sub ViewForm()
        Dim ShortID As String() = Split(trvComplete.SelectedNode.Text, " - ")
        Dim query As String = "select * from " + trvComplete.SelectedNode.Parent.Text.ToLower + " where MUID = '" + trvComplete.SelectedNode.Tag + "'"
        Dim dt As New DataTable
        dt = SQLServer.ExecuteQuery(query)

        Dim nd As New frmRecord(trvComplete.SelectedNode.Parent.Text.ToLower, dt.Rows(0)(0))
        nd.lblEditName.Text = trvComplete.SelectedNode.Text
        nd.txtName.Text = dt.Rows(0)(2)
        nd.txtDescription.Text = dt.Rows(0)(3)

        If (dt.Rows(0)(4) = "1") Then
            nd.chkActive.Checked = True
        Else
            nd.chkActive.Checked = False
        End If
        nd.ShowDialog()
        RefreshTree()
    End Sub


    Private Function GetTableRows(ByVal _TableName As String) As DataTable
        Dim query As String = "Select * From " + _TableName + " WHERE Name != 'Undefined' ORDER BY Name ASC"
        Dim dt As DataTable = SQLServer.ExecuteQuery(query)

        Return dt
    End Function

    Private Sub ViewData(ByVal tablename As String)
        Dim CompanyDataset As New DataSet
        Dim x, y As Integer

        Me.SplitContainer1.Panel2.Controls.Clear()
        Dim dt As New DataTable
        dt = GetTableRows(tablename)

        y = dt.Rows.Count
        y = y * 24
        x = dt.Columns.Count
        x = x * 90
        Dim dgtable As DataGrid = New DataGrid()
        dgtable.DataMember = ""
        dgtable.DataSource = Nothing
        dgtable.HeaderForeColor = System.Drawing.SystemColors.ControlText
        dgtable.Location = New System.Drawing.Point(8, 8)
        dgtable.Name = "dgtable"
        dgtable.Size = New System.Drawing.Size(x, y)
        dgtable.TabIndex = 0
        dgtable.Visible = True
        dgtable.DataSource = dt
        Me.SplitContainer1.Panel2.Controls.Add(dgtable)
    End Sub


    Private Sub RenameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        If Not (myselectednode Is Nothing) And Not (myselectednode.Parent Is Nothing) Then
            trvComplete.SelectedNode = myselectednode
            trvComplete.LabelEdit = True
            If Not myselectednode.IsEditing Then
                myselectednode.BeginEdit()
            End If
        Else
            MessageBox.Show("No tree node selected or selected node is a root node." & _
              Microsoft.VisualBasic.ControlChars.Cr & _
              "Editing of root nodes is not allowed.", "Invalid selection")
        End If
    End Sub


    Private Sub trvComplete_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvComplete.MouseDown
        myselectednode = trvComplete.GetNodeAt(e.X, e.Y)
    End Sub


    Private Sub trvComplete_BeforeLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles trvComplete.BeforeLabelEdit
        stroldnode = trvComplete.SelectedNode.Text
        stroldtag = trvComplete.SelectedNode.Tag
        strparent = trvComplete.SelectedNode.Parent.Text
    End Sub


    Private Sub trvComplete_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles trvComplete.AfterLabelEdit
        'If Not (e.Label Is Nothing) Then
        '    If e.Label.Length > 0 Then
        '        If e.Label.IndexOfAny(New Char() {"@"c, "."c, ","c, "!"c}) = -1 Then
        '            ' Stop editing without canceling the label change.
        '            If (strparent <> "User") Then
        '                If (GeneralDataManager.CheckDataRecord(e.Label, trvComplete.SelectedNode.Parent.Text.ToLower)) Then
        '                    e.Node.EndEdit(False)
        '                    e.Node.Text = e.Label
        '                    strnode = trvComplete.SelectedNode.Text
        '                    'MessageBox.Show(TrVAccounts.SelectedNode.Parent.Text)
        '                    GeneralDataManager.RenameDataRecord(stroldnode, strnode, trvComplete.SelectedNode.Parent.Text.ToLower)
        '                Else
        '                    ' Cancel the label edit action, inform the user, and
        '                    ' place the node in edit mode again. 
        '                    e.CancelEdit = True
        '                    MessageBox.Show("Invalid, Name already exists.")
        '                    e.Node.BeginEdit()
        '                End If
        '            Else
        '                If (UserDataManager.CheckDataRecord(e.Label)) Then
        '                    e.Node.EndEdit(False)
        '                    e.Node.Text = e.Label
        '                    strnode = trvComplete.SelectedNode.Text
        '                    'MessageBox.Show(TrVAccounts.SelectedNode.Parent.Text)
        '                    UserDataManager.RenameDataRecord(stroldtag, strnode, trvComplete.SelectedNode.Parent.Text.ToLower)
        '                Else
        '                    ' Cancel the label edit action, inform the user, and
        '                    ' place the node in edit mode again. 
        '                    e.CancelEdit = True
        '                    MessageBox.Show("Invalid, Name already exists.")
        '                    e.Node.BeginEdit()
        '                End If
        '            End If

        '        Else
        '            ' Cancel the label edit action, inform the user, and
        '            ' place the node in edit mode again. 
        '            e.CancelEdit = True
        '            MessageBox.Show("Invalid tree node label." & _
        '              Microsoft.VisualBasic.ControlChars.Cr & _
        '              "The invalid characters are: '@','.', ',', '!'", _
        '              "Node Label Edit")
        '            e.Node.BeginEdit()
        '        End If
        '    Else
        '        ' Cancel the label edit action, inform the user, and
        '        ' place the node in edit mode again. 
        '        e.CancelEdit = True
        '        MessageBox.Show("Invalid tree node label." & _
        '          Microsoft.VisualBasic.ControlChars.Cr & _
        '          "The label cannot be blank", "Node Label Edit")
        '        e.Node.BeginEdit()
        '    End If
        '    Me.trvComplete.LabelEdit = False
        'End If
    End Sub


    Private Sub UserToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserToolStripMenuItem1.Click
        Dim user As New AddUser
        user.ShowDialog()

        RefreshTree()
        ListUsers()
    End Sub


    Private Sub tspAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tspAddUser.Click
        Dim user As New AddUser
        user.ShowDialog()

        RefreshTree()
        ListUsers()
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        RefreshTree()
    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub


    Private Sub trvComplete_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvComplete.AfterSelect
        If Not Loading Then
            If trvComplete.SelectedNode.Name = "nodeUser" Then
                ListUsers()
            End If

            If trvComplete.SelectedNode.Name = "nodeEquipment" Then
                ListEquipment()
            End If

            If trvComplete.SelectedNode.Name = "nodeFormRequirements" Then
                'ListRequirements()

                Dim frm_Cert As New RequirementsManager
                frm_Cert.Show()

            End If
            If trvComplete.SelectedNode.Name = "nodeSignOff" Then
                dgv_Data.Columns.Clear()
            End If
            If trvComplete.SelectedNode.Name = "nodeCompany" Then
                dgv_Data.Columns.Clear()
            End If
            If trvComplete.SelectedNode.Name = "nodeGroup" Then
                dgv_Data.Columns.Clear()
            End If
            If trvComplete.SelectedNode.Name = "nodeLevel" Then
                dgv_Data.Columns.Clear()
            End If
            If trvComplete.SelectedNode.Name = "nodeOwner" Then
                dgv_Data.Columns.Clear()
            End If
            If trvComplete.SelectedNode.Name = "nodeDiscipline" Then
                dgv_Data.Columns.Clear()
            End If

            If Not e.Node.Parent Is Nothing Then
                If e.Node.Parent.Name = "nodeSignOff" Then
                    SelectedSignOffOwner = e.Node.Tag
                    ListSignOff(e.Node.Tag)
                End If
            End If

            dgv_Data.Refresh()
        End If
    End Sub


    Private Sub PopulateGrid(ByVal query As String)
        If Not query Is Nothing Then
            Dim bindingSource1 As New BindingSource
            With dgv_Data

                Dim dt As DataTable = SQLProject.ExecuteQuery(query)
                dt.Columns("ID").ColumnMapping = MappingType.Hidden
                bindingSource1.DataSource = dt
                .DataSource = bindingSource1

                .AutoGenerateColumns = True
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
                .EnableHeadersVisualStyles = False
                .BorderStyle = BorderStyle.None

                .CellBorderStyle = DataGridViewCellBorderStyle.None
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
        End If
    End Sub


    Public Sub ListUsers()
        Dim query As String = "SELECT userInfo.MUID AS MUID, userInfo.UserName, userInfo.LastName + ',' + userInfo.FirstName + ' ' + userInfo.MI AS FullName, userInfo.Title, company.Name, " & _
                    " userInfo.Active, levels.Name AS [Level]" & _
                    " FROM  userInfo INNER JOIN" & _
                    " company ON userInfo.CompanyMUID = company.MUID INNER JOIN" & _
                    " levels ON userInfo.LevelMUID = levels.MUID" & _
                    " WHERE (userInfo.UserName != 'Admin') ORDER BY FullName ASC"

        Dim dt As DataTable = SQLServer.ExecuteQuery(query)
        dt.Columns("MUID").ColumnMapping = MappingType.Hidden

        dgv_Data.Columns.Clear()
        dgv_Data.Tag = "User"
        dgv_Data.DataSource = dt
        dgv_Data.Refresh()
    End Sub


    Public Sub ListEquipment()
        Dim query As String = "Select MUID as ID,TypeName As Code,TypeDesc As Description,Active  From equipment_type" + _
            " WHERE TypeName <> 'UDF'"

        dgv_Data.Columns.Clear()
        dgv_Data.ContextMenuStrip = EquipmentCMS
        dgv_Data.Tag = "Equipment"

        PopulateGrid(query)
        dgv_Data.Refresh()
    End Sub


    Public Sub ListRequirements()
        Dim query As String = "SELECT requirements.MUID, requirements.OwnerMUID, equipment_type.TypeName As Equipment_Type, forms.Name As Form_Name, requirements.ManHours" & _
            " FROM equipment_type, requirements, forms" & _
            " WHERE equipment_type.MUID = requirements.TypeMUID AND " & _
            " requirements.FormMUID = forms.MUID"

        dgv_Data.Columns.Clear()

        Dim dt As DataTable = SQLProject.ExecuteQuery(query)
        If Not dt.Rows.Count = 0 Then
            PopulateGrid(query)

            dgv_Data.Columns(0).ValueType = GetType(String())
            dgv_Data.Columns.Add("Owner", "Owner")
            dgv_Data.Columns(0).Visible = False
            dgv_Data.Columns(1).Visible = False

            Dim i As Integer
            For i = 0 To dgv_Data.RowCount - 1
                Dim NewValue As String = Utilities.GetOwner(dgv_Data.Rows(i).Cells(1).Value)
                dgv_Data.Rows(i).Cells(5).Value = NewValue
            Next

            dgv_Data.Tag = "Requirements"
            dgv_Data.Rows(0).Selected = True
            dgv_Data.Refresh()
        End If
    End Sub


    Public Sub ListSignOff(ByVal _OwnerMUID As String)
        Dim query As String = "Select * From forms_config WHERE OwnerMUID = '" & _OwnerMUID.ToString & "'"
        Dim dt As DataTable = SQLProject.ExecuteQuery(query)

        If dt.Rows.Count = 0 Then
            If MessageBox.Show("No Sign-Off Configuration for Owner: " & Utilities.GetOwnerInfo(_OwnerMUID).Rows(0)(2) & "\" & Utilities.GetOwnerInfo(_OwnerMUID).Rows(0)(3) & " do you want to add one?", _
                "Create Sign-Off", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, _
                MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim ThisOwnerID As String = SelectedSignOffOwner
                Dim Order As Integer = dgv_Data.RowCount + 1
                Dim Level As Integer = 0
                Dim Color As String = ""
                Dim Description As String = ""

                Dim frmGetColor As New editSignOff(ThisOwnerID, Order, Level, Color, Description)
                Dim ret As Windows.Forms.DialogResult = frmGetColor.ShowDialog()
                If ret <> Windows.Forms.DialogResult.OK Then Return
            Else
                Return
            End If
        End If

        dgv_Data.DataSource = Nothing
        dgv_Data.Columns.Clear()
        dgv_Data.ContextMenuStrip = CMSSignOff
        dgv_Data.Columns.Add("Order", "Order")
        dgv_Data.Columns.Add("Level", "Level")
        dgv_Data.Columns.Add("Color", "Color")
        dgv_Data.Columns.Add("Description", "Description")
        dt = Nothing
        dt = SQLProject.ExecuteQuery(query)

        Dim LevelArray As Array = Split(dt.Rows(0)(2), ",")
        Dim ColorArray As Array = Nothing
        Dim DescriptionArray As Array = Nothing

        If Not IsDBNull(dt.Rows(0)(3)) Then
            ColorArray = Split(dt.Rows(0)(3), "&001")
        End If
        If Not IsDBNull(dt.Rows(0)(4)) Then
            DescriptionArray = Split(dt.Rows(0)(4), "&001")
        End If

        Dim i As Integer
        For i = 0 To LevelArray.Length - 1
            Dim RowValues As New DataGridViewRow()
            dgv_Data.Rows.Add(RowValues)

            dgv_Data.Rows(i).Cells(0).Value = i + 1
            dgv_Data.Rows(i).Cells(0).Tag = i + 1

            dgv_Data.Rows(i).Cells(1).Value = Utilities.GetLevels(LevelArray(i)).Rows(0)(2)
            dgv_Data.Rows(i).Cells(1).Tag = LevelArray(i)


            Dim CustomColor As Color
            If Not ColorArray Is Nothing Then
                dgv_Data.Rows(i).Cells(2).Tag = ColorArray(i)
                If ColorArray(i) = "" Then
                    dgv_Data.Rows(i).Cells(2).Style.BackColor = Color.White
                Else
                    CustomColor = System.Drawing.Color.FromArgb(ColorArray(i))
                    dgv_Data.Rows(i).Cells(2).Style.BackColor = CustomColor
                End If
            End If

            If Not DescriptionArray Is Nothing Then
                dgv_Data.Rows(i).Cells(3).Value = DescriptionArray(i)
                dgv_Data.Rows(i).Cells(3).Tag = DescriptionArray(i)
            End If
        Next

        dgv_Data.Tag = "SignOff"
        dgv_Data.ResumeLayout()
        dgv_Data.Refresh()
    End Sub


    Public Sub EditSignOff()
        Dim OwnerID As String = SelectedSignOffOwner
        Dim Order As Integer = dgv_Data.SelectedRows(0).Cells(0).Value
        Dim Level As String = dgv_Data.SelectedRows(0).Cells(1).Tag
        Dim Color As String = dgv_Data.SelectedRows(0).Cells(2).Tag
        Dim Description As String = dgv_Data.SelectedRows(0).Cells(3).Value

        Dim frmGetColor As New editSignOff(OwnerID, Order, Level, Color, Description)
        frmGetColor.ShowDialog()

        ListSignOff(OwnerID)
    End Sub


    Private Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit.Click
        If trvComplete.SelectedNode.Name = "nodeUser" Then

            Dim userName = dgv_Data.SelectedRows(0).Cells("UserName").Value
            Dim muid As String = Utilities.GetUserID(userName)
            Dim EditForm As New frmUser(muid)
            EditForm.ShowDialog()
            ListUsers()
        End If

        If trvComplete.SelectedNode.Name = "nodeEquipment" Then
            Dim EditForm As New ManageEquipment
            EditForm.EquipmentMode = "Edit"
            EditForm.EquipmentTypeID = Utilities.GetTypeID(dgv_Data.CurrentRow.Cells(0).Value)
            EditForm.ShowDialog()
            ListEquipment()
        End If
    End Sub


    Private Sub Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete.Click
        If trvComplete.SelectedNode.Name = "nodeUser" Then
            Dim query As String = "DELETE FROM userInfo WHERE MUID=@MUID"

            If MessageBox.Show("Are you sure you want to delete the selected record?", _
               "Delete Type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, _
               MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                
                Dim dt_param As DataTable = SQLServer.paramDT
                'dt_param.Rows.Add("@MUID", dgv_Data.CurrentRow.Cells(0).Value.ToString)

                Dim userName = dgv_Data.SelectedRows(0).Cells("UserName").Value
                Dim muid As String = Utilities.GetUserID(userName)
                dt_param.Rows.Add("@MUID", muid)

                SQLServer.ExecuteNonQuery(query, dt_param)
                ListUsers()
                Me.Refresh()
            End If

        End If

        If trvComplete.SelectedNode.Name = "nodeEquipment" Then
            Dim query As String = "DELETE FROM equipment_type WHERE MUID=@MUID"

            If MessageBox.Show("Are you sure you want to delete the selected record?", _
               "Delete Type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, _
               MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim dt_param As DataTable = SQLProject.paramDT
                Dim muid As String = Utilities.GetTypeID(dgv_Data.CurrentRow.Cells(0).Value)
                dt_param.Rows.Add("@MUID", muid)
                SQLProject.ExecuteNonQuery(query, dt_param)
                ListEquipment()
                Me.Refresh()
            End If
        End If

    End Sub


    Private Sub NewEquipmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewEquipmentToolStripMenuItem.Click
        Dim EditForm As New ManageEquipment
        EditForm.EquipmentMode = "Add"
        EditForm.ShowDialog()

        ListEquipment()
    End Sub


    Private Sub NewRequirementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewRequirementToolStripMenuItem.Click
        Dim EditForm As New ManageRequirements
        EditForm.RequirementMode = "Add"
        EditForm.ShowDialog()

        ListRequirements()
    End Sub


    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Dim EditForm As New ManageRequirements
        EditForm.RequirementMode = "Edit"
        If dgv_Data.CurrentRow Is Nothing Then
            EditForm.RequirementID = dgv_Data.Rows(0).Cells(0).Value.ToString
        Else
            EditForm.RequirementID = dgv_Data.CurrentRow.Cells(0).Value.ToString
        End If
        EditForm.ShowDialog()

        ListRequirements()
    End Sub


    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim query As String = "DELETE FROM requirements WHERE MUID=@MUID"

        If MessageBox.Show("Are you sure you want to delete the selected record?", _
           "Delete Type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, _
           MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

            Dim dt_param As DataTable = SQLProject.paramDT
            dt_param.Rows.Add("@MUID", dgv_Data.CurrentRow.Cells(0).Value.ToString)

            SQLProject.ExecuteNonQuery(query, dt_param)

            ListRequirements()
            Me.Refresh()
        End If
    End Sub


    Public Sub generateSignoff()
        Try
            Dim Company As New TreeNode
            Dim dt As New DataTable
            dt = Me.GetTableRows("Owner")

            If Not dt.Rows.Count = 0 Then
                Dim i As Integer
                trvComplete.Nodes(1).Nodes(2).Nodes.Clear()
                For i = 0 To dt.Rows.Count - 1
                    Dim temp As New TreeNode
                    temp.Tag = dt.Rows(i).Item(0)
                    temp.Text = dt.Rows(i).Item(2)
                    temp.Name = dt.Rows(i).Item(2)
                    trvComplete.Nodes(1).Nodes(2).Nodes.Add(temp)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub EditToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem1.Click
        EditSignOff()
    End Sub


    Private Sub AddLevelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddLevelToolStripMenuItem.Click
        Dim OwnerID As String = SelectedSignOffOwner
        Dim Order As Integer = dgv_Data.RowCount + 1
        Dim Level As String = 0
        Dim Color As String = ""
        Dim Description As String = ""
        Dim frmGetColor As New editSignOff(OwnerID, Order, Level, Color, Description)
        frmGetColor.ShowDialog()

        ListSignOff(OwnerID)
    End Sub


    Private Sub DeleteLevelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteLevelToolStripMenuItem.Click
        Dim OwnerID As String = SelectedSignOffOwner
        Dim Order As Integer = dgv_Data.SelectedRows(0).Cells(0).Value

        If MessageBox.Show("Are you sure you want to delete the selected Sign Off level?", _
           "Delete Sign-Off", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, _
           MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

            Dim ThisRecord As DataTable = Utilities.GetFormLevel(OwnerID)
            Dim LevelArray As Array = Split(ThisRecord.Rows(0)(2), ",")
            Dim ColorArray As Array = Split(ThisRecord.Rows(0)(3), "&001")
            Dim DescriptionArray As Array = Split(ThisRecord.Rows(0)(4), "&001")

            'change array to delimited strings again
            Dim NewLevel As String = Nothing
            Dim NewColor As String = Nothing
            Dim NewDescription As String = Nothing

            Dim i As Integer
            For i = 0 To LevelArray.Length - 1
                If Not i = Order - 1 Then
                    If i = LevelArray.Length - 1 Then
                        NewLevel += LevelArray(i)
                        NewColor += ColorArray(i)
                        NewDescription += DescriptionArray(i)
                    Else
                        NewLevel += LevelArray(i) + ","
                        NewColor += ColorArray(i) + "&001"
                        NewDescription += DescriptionArray(i) + "&001"
                    End If
                End If
            Next

            Dim query As String = "UPDATE forms_config SET " & _
                    " LevelOrder=@LevelOrder," & _
                    " LevelColor=@LevelColor," & _
                    " LevelDescription=@LevelDescription" & _
                    " WHERE OwnerMUID=@OwnerMUID"

            Dim dt_param As DataTable = SQLProject.paramDT
            dt_param.Rows.Add("@LevelOrder", NewLevel)
            dt_param.Rows.Add("@LevelColor", NewColor)
            dt_param.Rows.Add("@LevelDescription", NewDescription)
            dt_param.Rows.Add("@OwnerMUID", OwnerID)

            SQLProject.ExecuteNonQuery(query, dt_param)
            ListSignOff(SelectedSignOffOwner)
            Me.Refresh()
        End If
    End Sub


    Private Sub DataGridView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgv_Data.ColumnWidthChanged
        Me.Refresh()
    End Sub


    Private Sub dgv_Data_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_Data.DoubleClick
        If dgv_Data.Tag = "User" Then
            Dim frm_User As New frmUser(Utilities.GetUserID(dgv_Data.CurrentRow.Cells(0).Value))
            frm_User.ShowDialog()
        End If
    End Sub


    Private Sub DataGridView1_RowHeightChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_Data.RowHeightChanged
        Me.Refresh()
    End Sub


    Private Sub ImportEquipmentTypesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportEquipmentTypesToolStripMenuItem.Click
        Dim frm_Types As New ProjectWizard.CreateEquipment
        frm_Types.ShowDialog()

        ListEquipment()
    End Sub


    Private Function GetActiveInfo() As Boolean
        Dim tblName As String = trvComplete.SelectedNode.Parent.Text
        Dim txt As String = trvComplete.SelectedNode.Text.ToString
        Dim qry As String = "select * from " + tblName + " where Name = '" + txt + "'"
        Dim ActiveState As Boolean = True
        Select Case trvComplete.SelectedNode.Parent.Text
            Case "Company"
            Case "Discipline"
            Case "Levels"
            Case "Groups"
            Case "Owner"
            Case "User"
                qry = "select * from userInfo where UserName = '" + trvComplete.SelectedNode.Text.ToString + "'"
            Case Else
                Return ActiveState
        End Select

        Dim dt As DataTable = SQLServer.ExecuteQuery(qry)

        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Active") = "0" Or "False" Then
                ActiveState = False
            End If
        End If
        Return ActiveState
    End Function


    Private Sub CMSNode_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMSNode.Opening
        DeleteToolStripMenuItem1.Text = "Set Active"
        If trvComplete.SelectedNode.Level <= 1 Then
            DeleteToolStripMenuItem1.Enabled = False
            RenameToolStripMenuItem.Enabled = False
        Else
            If GetActiveInfo() Then DeleteToolStripMenuItem1.Text = "Set Inactive"
            DeleteToolStripMenuItem1.Enabled = True
            RenameToolStripMenuItem.Enabled = True
        End If
    End Sub


    Private Sub ImportGroupsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportGroupsToolStripMenuItem.Click
        Dim sysFields() As String = {"Name", "Description", "Active"}
        Dim sysReqFields() As String = {"Name", "Description", "Active"}
        Dim myForm As CommonForms.ImportCSV = New CommonForms.ImportCSV("Import Groups", "server")
        myForm.sysTableFields = sysFields
        myForm.sysTableName = "groups"
        myForm.requiredFields = sysReqFields
        myForm.uniqueField = "Name"
        myForm.Show()
    End Sub



End Class

