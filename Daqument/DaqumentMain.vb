Imports System.io
Imports daqartDLL

Public Class DaqumentMain
    Dim myselectednode As TreeNode
    Dim stroldnode As String
    Dim strnode As String
    Dim strparent As String
    Dim stroldtag As String
    Dim dt As DataTable
    Dim strchild As String = ""
    Dim strtemp As String
    Dim stredit As String


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.tsl_SiteLabel.Text = "Site: " + runtime.SiteName
            Me.ProjectStatusInd.Text = "Project: " + runtime.selectedProject
            'call generatenodes inorder to generate nodes and child nodes
            generatenodes()
            'LoadData()
            Me.StatusStrip1.Items(0).Text = ""
            Me.StatusStrip1.Items(1).Text = ""

            Me.cbx_SearchField.SelectedIndex = 0

        Catch ex As Exception
            Utilities.logErrorMessage("DaqumentMain.Form1_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub DaqumentMain_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        generatenodes()
        'LoadData()
    End Sub


    Public Sub LoadData()
        Dim query As String = "SELECT documents.MUID,documents.EngCode,documents.ClientCode,documents.Description,documents.Revision AS Rev, documents.Sheet+'/'+ documents.Sheets AS Sht, documents.DateLoaded, document_type.Code AS DocumentType " & _
    "FROM document_type, documents " & _
    "WHERE document_type.MUID=documents.DocumentTypeMUID AND " + _
    "ProjectMUID = '" + Utilities.GetProjectID(runtime.selectedProject).ToString & "'"

        Dim sqlDaqUtils As DataUtils = New DataUtils("Daqument")
        sqlDaqUtils.OpenConnection()
        Dim sqlDaq001Utils As DataUtils = New DataUtils("Daqument001")
        sqlDaq001Utils.OpenConnection()

        Dim ProjectSQL As DataUtils = New DataUtils("project")
        ProjectSQL.OpenConnection()

        dt = sqlDaqUtils.ExecuteQuery(query)
        dt.Columns.Add("Image")
        dt.Columns.Add("Associated")

        ''check and repair doc name in package documents
        'query = "SELECT * From package_documents WHERE Aux8 IS NULL"
        'Dim dt_AssociationCheck As DataTable = ProjectSQL.ExecuteQuery(query)
        'If dt_AssociationCheck.Rows.Count > 0 Then
        '    For i As Integer = 0 To dt_AssociationCheck.Rows.Count - 1
        '        query = "SELECT EngCode FROM documents WHERE MUID='" + dt_AssociationCheck.Rows(i)(2) + "'"
        '        Dim dt_DocName As DataTable = sqlDaqUtils.ExecuteQuery(query)

        '        If dt_DocName.Rows.Count > 0 Then
        '            query = "UPDATE package_documents SET Aux8='" + dt_DocName.Rows(0)(0) + "'" & _
        '                " WHERE MUID='" + dt_AssociationCheck.Rows(i)(0) + "'"
        '            Dim dt_param = ProjectSQL.paramDT
        '            ProjectSQL.ExecuteNonQuery(query, dt_param)
        '        End If
        '    Next
        'End If


        'post process
        For Each dr As DataRow In dt.Rows
            dr("Rev") = Utilities.TranslateRev(dr("Rev"))
            query = "SELECT MUID From Document_Store WHERE DocumentMUID='" + dr("MUID") + "'"
            Dim dtt As DataTable = sqlDaq001Utils.ExecuteQuery(query)
            If dtt.Rows.Count > 0 Then
                dr("Image") = "Yes"
            Else
                dr("Image") = "No"
            End If

            query = "SELECT MUID From package_documents WHERE Aux8='" + dr("EngCode") + "'"
            Dim dt_Association As DataTable = ProjectSQL.ExecuteQuery(query)
            If dt_Association.Rows.Count > 0 Then
                dr("Associated") = "Yes"
            Else
                dr("Associated") = "No"
            End If
        Next


        sqlDaq001Utils.OpenConnection()
        sqlDaqUtils.CloseConnection()
        ProjectSQL.CloseConnection()

        GridControl1.DataSource = Nothing

        If Not dt Is Nothing Then
            StatusStrip1.Items(2).Text = dt.Rows.Count
            GridControl1.DataSource = dt
            Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = GridControl1.MainView
            View.Columns("MUID").Visible = False
        End If
    End Sub


    Public Sub generatenodes()
        Dim Company As New TreeNode
        Dim dt As New DataTable("parent")
        Dim cdt As New DataTable("child")
        Dim query As String = "select * from document_type ORDER BY Code ASC"
        Dim sqlDaqUtils As DataUtils = New DataUtils("Daqument")
        sqlDaqUtils.OpenConnection()
        dt = sqlDaqUtils.ExecuteQuery(query)
        query = "select * from document_type where ParentMUID > ''"
        cdt = sqlDaqUtils.ExecuteQuery(query)
        'clear all nodes
        trvCategory.Nodes.Clear()

        If (dt Is Nothing) Then
        Else
            Dim ds As New DataSet
            ds.Tables.Add(dt.Copy)
            If (ds.Relations.Contains("SelfRefenceRelation")) = False Then
                ds.Relations.Add("SelfRefenceRelation", ds.Tables(0).Columns("MUID"), ds.Tables(0).Columns("ParentMUID"), False)
            End If

            'Load tree 
            LoadTreeView(ds)

        End If

        trvCategory.Sort()

        sqlDaqUtils.CloseConnection()
    End Sub


    Private Sub LoadTreeView(ByVal ds As DataSet)
        Dim oDataRow As DataRow
        For Each oDataRow In ds.Tables(0).Rows
            Dim rootID As String = oDataRow("ParentMUID")
            If rootID = "0" Then
                Dim oNode As New TreeNode()
                oNode.Text = oDataRow("Code").ToString() + "-" + oDataRow("Description").ToString
                oNode.Tag = oDataRow("MUID").ToString()
                trvCategory.Nodes.Add(oNode)
                RecursivelyLoadTree(oDataRow, oNode)
            End If
        Next oDataRow
        ds.Dispose()
        ds = Nothing
    End Sub


    Private Sub RecursivelyLoadTree(ByVal oDataRow As DataRow, _
    ByRef oNode As TreeNode)
        Dim oChildRow As DataRow

        For Each oChildRow In oDataRow.GetChildRows("SelfRefenceRelation")
            'Create child node and add to Parent
            Dim oChildNode As New TreeNode()
            oChildNode.Text = oChildRow("Code").ToString() + "-" + oChildRow("Description").ToString
            oChildNode.Tag = oChildRow("MUID").ToString()
            ' oChildNode.NavigateUrl = oChildRow("NavigateURL").ToString()
            oNode.Nodes.Add(oChildNode)
            'Repeat for each child
            RecursivelyLoadTree(oChildRow, oChildNode)
        Next oChildRow
    End Sub


    Private Sub tsvCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsvCategory.Click
        Dim frmcategory As New Category("0")
        frmcategory.Label1.Text = "Category"
        frmcategory.lblTag.Text = "0"
        frmcategory.ShowDialog()
        generatenodes()
        'LoadData()
    End Sub


    Private Sub CategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryToolStripMenuItem.Click
        If (myselectednode Is Nothing) Then
            Dim frmcategory As New Category("0")
            frmcategory.Label1.Text = "Category"
            frmcategory.lblTag.Text = "0"
            frmcategory.ShowDialog()
            generatenodes()
            'LoadData()
        Else
            Dim frmcategory As New Category("0")
            frmcategory.Label1.Text = "Add to " + myselectednode.Text
            frmcategory.lblTag.Text = myselectednode.Tag
            frmcategory.ShowDialog()
            generatenodes()
            'LoadData()
        End If
    End Sub


    Private Sub trvCategory_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvCategory.MouseDown
        myselectednode = trvCategory.GetNodeAt(e.X, e.Y)
    End Sub


    Private Sub DocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentToolStripMenuItem.Click
        Dim newdoc As New FrmSave
        newdoc.lblTag.Text = trvCategory.SelectedNode.Tag.ToString
        newdoc.tbx_DocType.Tag = trvCategory.SelectedNode.Tag
        newdoc.tbx_DocType.Text = Utilities.GetDocumentType(trvCategory.SelectedNode.Tag)
        newdoc.Show()
        generatenodes()
        'LoadData()
    End Sub


    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        If Not (trvCategory.SelectedNode Is Nothing) Then
            Dim qry As String = "select * from document_type where MUID = '" + trvCategory.SelectedNode.Tag + "'"
            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

            sqlDocUtils.OpenConnection()
            Dim dt As DataTable = sqlDocUtils.ExecuteQuery(qry)
            sqlDocUtils.CloseConnection()

            Dim frmcategory As New Category(dt.Rows(0)("MUID"))
            frmcategory.Label1.Text = "Category"
            frmcategory.lblTag.Text = "0"
            frmcategory.txtCode.Text = dt.Rows(0)("Code")
            frmcategory.txtDesc.Text = dt.Rows(0)("Description")
            If dt.Rows(0)("Disable11x17").ToString = "1" Then
                frmcategory.ckb_Disable11x17.Checked = True
            Else
                frmcategory.ckb_Disable11x17.Checked = False
            End If
            frmcategory.ShowDialog()
            generatenodes()
            'LoadData()
        End If
    End Sub


    Private Sub ProcessNodes(ByVal nodes As TreeNodeCollection)
        For Each node As TreeNode In nodes
            ProcessNode(node)
            ProcessNodes(node.Nodes)
        Next
    End Sub


    Private Sub ProcessNode(ByVal node As TreeNode)
        If strchild = " " Then
            strchild = "'" + node.Tag + "'"
        Else
            strchild = strchild + "," + node.Tag
        End If
    End Sub


    Private Sub TSBRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBRefresh.Click
        RefreshList()
    End Sub


    Private Sub ShowDataRow(ByVal dr As DataRow, ByVal fs As String, ByVal c As Color)
        Dim s As String = ""

        If Not dr Is Nothing Then
            Dim items As Object() = dr.ItemArray

            For Each o As Object In items
                If s = "" Then
                    s = ("") + o.ToString()
                Else
                    s = (s & "; ") + o.ToString()
                End If
            Next o
        End If
        stredit = ""
        stredit = dr(0).ToString
        strtemp = ""
        strtemp = "" 
    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub


    Private Sub TSMEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMEdit.Click
        Try
            ShowDataRow(GridView1.GetDataRow(GridView1.FocusedRowHandle), "Focused Row: ", Color.Yellow)
            Dim query As String = "select * from documents  where MUID = '" + stredit + "'"
            Dim sqlDaqUtils As DataUtils = New DataUtils("Daqument")
            sqlDaqUtils.OpenConnection()

            Dim dt = sqlDaqUtils.ExecuteQuery(query)

            If (dt.Rows.Count = 0) Then
                sqlDaqUtils.CloseConnection()
                Return
            End If

            Dim dr As DataRow = dt.Rows(0)
            Dim frmedit As New frmEditDoc(dr.Item("MUID"))

            frmedit.txtClientCode.Text = dr.Item("ClientCode")
            frmedit.txtDescription.Text = dr.Item("Description")
            frmedit.txtEngCode.Text = dr.Item("EngCode")
            If Not IsDBNull(dr.Item("Location")) Then
                frmedit.txtLocation.Text = dr.Item("Location")
            End If
            frmedit.txtRevision.Text = dr.Item("Revision")
            frmedit.txtSheet.Text = dr.Item("Sheet")
            frmedit.txtSheetOf.Text = dr.Item("Sheets")
            frmedit.tbx_DocType.Tag = dr.Item("DocumentTypeMUID")
            frmedit.tbx_DocType.Text = Utilities.GetDocumentType(frmedit.tbx_DocType.Tag)

            frmedit.Show()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub TSMDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMDelete.Click
        ShowDataRow(GridView1.GetDataRow(GridView1.FocusedRowHandle), "Focused Row: ", Color.Yellow)
        Dim dr As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim docName As String = dr("EngCode")
        Dim strmessage As Windows.Forms.DialogResult = MessageBox.Show("Do you want to delete: " & docName, "Delete", MessageBoxButtons.YesNo)

        If (strmessage = Windows.Forms.DialogResult.Yes) Then
            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
            Dim query As String = "delete  from documents  where MUID =@MUID"
            Dim dt_param As DataTable = sqlDocUtils.paramDT
            dt_param.Rows.Add("@MUID", stredit)

            sqlDocUtils.OpenConnection()
            sqlDocUtils.ExecuteNonQuery(query, dt_param)
            sqlDocUtils.CloseConnection()


            Dim ProjectSQL As DataUtils = New DataUtils("Daqument")
            query = "delete from package_documents where DocumentMUID =@MUID"
            dt_param = ProjectSQL.paramDT
            dt_param.Rows.Add("@MUID", stredit)

            ProjectSQL.OpenConnection()
            ProjectSQL.ExecuteNonQuery(query, dt_param)
            ProjectSQL.CloseConnection()

            GridView1.DeleteRow((GridView1.FocusedRowHandle))
        End If
    End Sub


    Private Sub RefreshList()
        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
        sqlDocUtils.OpenConnection()

        Dim query As String = "SELECT documents.MUID,documents.EngCode,documents.ClientCode,documents.Description,documents.Revision AS Rev, documents.Sheet+'/'+ documents.Sheets AS Sht, documents.DateLoaded, document_type.Code+'-'+document_type.Description AS DocumentType " & _
                                          " FROM document_type, documents " & _
                                          " WHERE document_type.MUID=documents.DocumentTypeMUID  AND " & _
                                          " documents.DocumentTypeMUID in " + strchild + " " + _
                                          " AND ProjectMUID = '" & Utilities.GetProjectID(runtime.selectedProject).ToString & "'"


        dt = sqlDocUtils.ExecuteQuery(query)
        If dt Is Nothing Then
            sqlDocUtils.CloseConnection()
            Return 'Nothing
        End If
        dt.Columns.Add("Image")
        dt.Columns.Add("Associated")

        Dim ProjectSQL As DataUtils = New DataUtils("project")
        ProjectSQL.OpenConnection()

        'check and repair doc name in package documents
        query = "SELECT * From package_documents WHERE Aux8 IS NULL"
        Dim dt_AssociationCheck As DataTable = ProjectSQL.ExecuteQuery(query)
        If dt_AssociationCheck.Rows.Count > 0 Then
            For i As Integer = 0 To dt_AssociationCheck.Rows.Count - 1
                query = "SELECT EngCode FROM documents WHERE MUID='" + dt_AssociationCheck.Rows(i)(2) + "'"
                Dim dt_DocName As DataTable = sqlDocUtils.ExecuteQuery(query)

                If dt_DocName.Rows.Count > 0 Then
                    query = "UPDATE package_documents SET Aux8='" + dt_DocName.Rows(0)(0) + "'" & _
                        " WHERE MUID='" + dt_AssociationCheck.Rows(i)(0) + "'"
                    Dim dt_param = ProjectSQL.paramDT
                    ProjectSQL.ExecuteNonQuery(query, dt_param)
                End If
            Next
        End If


        Dim sqlDaq001Utils As DataUtils = New DataUtils("Daqument001")
        sqlDaq001Utils.OpenConnection()
        'Dim ProjectSQL As DataUtils = New DataUtils("project")
        'ProjectSQL.OpenConnection()

        For Each dr As DataRow In dt.Rows
            dr("Rev") = Utilities.TranslateRev(dr("Rev"))
            query = "SELECT MUID From Document_Store WHERE DocumentMUID='" + dr("MUID") + "'"
            Dim dtt = sqlDaq001Utils.ExecuteQuery(query)
            If dtt.Rows.Count > 0 Then
                dr("Image") = "Yes"
            Else
                dr("Image") = "No"
            End If

            query = "SELECT MUID From package_documents WHERE Aux8='" + dr("EngCode") + "'"
            Dim dt_Association As DataTable = ProjectSQL.ExecuteQuery(query)
            If dt_Association.Rows.Count > 0 Then
                dr("Associated") = "Yes"
            Else
                dr("Associated") = "No"
            End If
        Next

        ProjectSQL.CloseConnection()
        sqlDaq001Utils.OpenConnection()

        GridControl1.DataSource = Nothing
        GridControl1.DataSource = dt
        If dt.Rows.Count > 0 Then
            Me.StatusStrip1.Items(0).Text = dt.Rows(0)("Description")
            Me.StatusStrip1.Items(2).Text = dt.Rows.Count
        End If

        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = GridControl1.MainView
        View.Columns("MUID").Visible = False

        query = "SELECT Code+'-'+ Description AS DocumentType " & _
                                  " FROM document_type " & _
                                  " WHERE MUID in " + strchild + " "

        dt = sqlDocUtils.ExecuteQuery(query)
        If dt.Rows.Count > 0 Then
            Me.StatusStrip1.Items(1).Text = "Category:" + dt.Rows(0)("DocumentType")
        End If

        sqlDocUtils.CloseConnection()
    End Sub


    Private Sub trvCategory_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvCategory.DoubleClick

        Me.Cursor = Cursors.WaitCursor
        Me.StatusStrip1.Items(0).Text = ""
        Me.StatusStrip1.Items(1).Text = ""
        StatusStrip1.Items(2).Text = "0"

        If (Not (trvCategory.SelectedNode Is Nothing)) And (trvCategory.SelectedNode.GetNodeCount(True) > 0) Then
            strchild = " " '
            ProcessNodes(trvCategory.SelectedNode.Nodes)
            strchild = "('" + trvCategory.SelectedNode.Tag + "', " + strchild
            strchild = strchild + ")"
        Else
            strchild = " "
            ProcessNodes(trvCategory.SelectedNode.Nodes)
            strchild = "("
            If trvCategory.SelectedNode.Tag <> "" Then
                strchild = strchild + "'" + trvCategory.SelectedNode.Tag + "'"
            End If
            strchild = strchild + ")"
        End If
        RefreshList()

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmimage As New frmImageList
        frmimage.Show()
    End Sub


    Private Sub GridControl1_DoubleClick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        Me.Cursor = Cursors.WaitCursor

        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = GridView1.CalcHitInfo((TryCast(sender, Control)).PointToClient(Control.MousePosition))
        Try
            If hi.RowHandle >= 0 Then
                ShowDataRow(GridView1.GetDataRow(hi.RowHandle), "", Color.White)
                Me.StatusStrip1.Items(0).Text = GridView1.GetDataRow(hi.RowHandle)("Description")

                Dim query As String = "select DocumentImage from document_store  where DocumentMUID = '" + stredit + "'"
                Dim sqlDocUtils As DataUtils = New DataUtils("Daqument001")
                sqlDocUtils.OpenConnection()
                Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
                sqlDocUtils.CloseConnection()
                If dt.Rows.Count > 0 Then
                    If Not (dt.Rows(0)("DocumentImage") Is Nothing) Then
                        Dim frmImage As New EditDaqument(stredit)
                        frmImage.Show()
                    End If
                Else
                    MessageBox.Show("Image was not stored for the document")
                End If
            ElseIf GridView1.FocusedRowHandle >= 0 Then
                ShowDataRow(GridView1.GetDataRow(GridView1.FocusedRowHandle), "Focused Row: ", Color.Yellow)
            Else
                ShowDataRow(Nothing, "Empty...", Color.DeepSkyBlue)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmsearch As New Search
        frmsearch.ShowDialog()
    End Sub


    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        'Dim reportdaq As New ReportManager.DaqumentReport(dt)
        'reportdaq.Show()
        'Cursor = Cursors.AppStarting
        'Dim frm_ShowExport As New CommonForms.DataExport(Me.GridControl1.DataSource)
        'frm_ShowExport.Show()


        'system.Drawing.Printing.
        Dim xgp As CommonForms.XtraGridPrinting = New CommonForms.XtraGridPrinting("Document List", Me.GridControl1)
        xgp.Show()

        'Cursor = Cursors.Default

    End Sub


    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click

    End Sub


    Private Sub TDrawToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim query As String = "select DocumentImage from document_store  where DocumentMUID = '" + stredit + "'"
            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument001")
            sqlDocUtils.OpenConnection()
            Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
            sqlDocUtils.CloseConnection()


            If Not dt Is Nothing Then
                If Not (dt.Rows(0)("DocumentImage") Is Nothing) Then
                    Dim frmImage As New TDraw(stredit)
                    frmImage.Show()
                End If
            Else
                MessageBox.Show("Image was not stored for the document")
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub ImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        Dim frm_Imports As New DaqumentImport
        frm_Imports.Show()
    End Sub


    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim query As String = "SELECT * FROM documents WHERE DocumentTypeMUID = '" + trvCategory.SelectedNode.Tag.ToString + "'"
        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        sqlDocUtils.OpenConnection()
        Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
        sqlDocUtils.CloseConnection()

        If dt.Rows.Count > 0 Then
            MessageBox.Show("The document type cannot be deleted until all drawings have been reassigned.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        query = "DELETE FROM document_type WHERE MUID = @MUID"
        Dim dt_param As DataTable = sqlDocUtils.paramDT
        dt_param.Rows.Add("@MUID", trvCategory.SelectedNode.Tag.ToString)

        sqlDocUtils.OpenConnection()
        sqlDocUtils.ExecuteNonQuery(query, dt_param)
        sqlDocUtils.CloseConnection()

        generatenodes()
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim newdoc As New FrmSave
        newdoc.Show()
    End Sub


    Private Sub BackgroundRepairToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackgroundRepairToolStripMenuItem.Click
        Dim query As String = "SELECT * FROM documents WHERE ProjectMUID='" + Utilities.GetProjectID(runtime.selectedProject) + "'"
        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
        sqlDocUtils.OpenConnection()
        Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
        sqlDocUtils.CloseConnection()

        Dim SQL_Daq As DataUtils = New DataUtils("Daqument001")

        SQL_Daq.OpenConnection()
        For Each dr As DataRow In dt.Rows
            Dim OriginalDocImage As Image = Nothing
            query = "select * from document_store  where DocumentMUID = '" + dr(0) + "'"

            Dim dt2 As DataTable = SQL_Daq.ExecuteQuery(query)

            If dt2.Rows.Count > 0 Then
                Dim imagedata() As Byte
                Dim imageBytedata As MemoryStream
                imagedata = dt2.Rows(0)("DocumentImage")
                imageBytedata = New MemoryStream(imagedata)
                OriginalDocImage = Image.FromStream(imageBytedata)

                Dim bmp_Image As New Bitmap(OriginalDocImage)
                Dim ZeroPixelColor As Color = bmp_Image.GetPixel(0, 0)

                'bmp_Image.Save("c:\colortest1.png", System.Drawing.Imaging.ImageFormat.Png)

                Dim x As Integer
                Dim y As Integer
                Dim clr2 As Color = Color.White
                For x = 0 To bmp_Image.Width - 1 Step 1
                    For y = 0 To bmp_Image.Height - 1 Step 1
                        If bmp_Image.GetPixel(x, y) = ZeroPixelColor Then
                            bmp_Image.SetPixel(x, y, clr2)
                        End If
                    Next
                Next
                bmp_Image.Save(runtime.AbsolutePath + "OutputFile00001.png", System.Drawing.Imaging.ImageFormat.Png)
                UpdateDoc(dt2.Rows(0)("MUID"))
            End If
        Next
        SQL_Daq.CloseConnection()
    End Sub


    Public Sub UpdateDoc(ByVal MUID As String)
        Dim FileSize As UInt32
        Dim rawData() As Byte
        Dim fs As FileStream
        Try
            fs = New FileStream(runtime.AbsolutePath + "OutputFile00001.png", FileMode.Open, FileAccess.Read)
            FileSize = fs.Length
            rawData = New Byte(FileSize) {}
            fs.Read(rawData, 0, FileSize)
            fs.Close()
            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument001")
            Dim query As String = "UPDATE document_store set" + _
            " DocumentImage=@File " + _
            " WHERE MUID='" + MUID + "'"

            sqlDocUtils.OpenConnection()
            sqlDocUtils.ExecuteSingleParameterizedQuery(query, "@File", rawData)
            sqlDocUtils.CloseConnection()
        Catch ex As Exception
            Utilities.logErrorMessage("DaqumentMain.UpdateDoc-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub ViewAssociationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAssociationsToolStripMenuItem.Click
        ShowDataRow(GridView1.GetDataRow(GridView1.FocusedRowHandle), "Focused Row: ", Color.Yellow)
        Dim dr As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)

        Dim frm_DocAssoc As New ViewAssociations(dr("MUID"))
        frm_DocAssoc.Show()


    End Sub

    Private Sub btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search.Click
        Me.Cursor = Cursors.WaitCursor
        search()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub search()
        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
        sqlDocUtils.OpenConnection()

        Dim searchField As String = "EngCode"
        If Me.cbx_SearchField.Text = "Engineering Code" Then
            searchField = "EngCode"
        ElseIf Me.cbx_SearchField.Text = "Client Code" Then
            searchField = "ClientCode"
        ElseIf Me.cbx_SearchField.Text = "Document Title" Then
            searchField = "Description"
        End If


        Dim query As String = "SELECT documents.MUID,documents.EngCode,documents.ClientCode,documents.Description,documents.Revision AS Rev, documents.Sheet+'/'+ documents.Sheets AS Sht, documents.DateLoaded, document_type.Code+'-'+document_type.Description AS DocumentType " & _
                                          " FROM document_type, documents " & _
                                          " WHERE document_type.MUID=documents.DocumentTypeMUID AND documents." + searchField + " LIKE '%" + Me.tbx_Search.Text + "%'" + _
                                          " AND ProjectMUID = '" & Utilities.GetProjectID(runtime.selectedProject).ToString & "'"


        dt = sqlDocUtils.ExecuteQuery(query)
        If dt Is Nothing Or dt.Rows.Count = 0 Then
            sqlDocUtils.CloseConnection()

            MessageBox.Show("There are no documents matching your search.")
            Return
        End If
        dt.Columns.Add("Image")
        dt.Columns.Add("Associated")

        Dim ProjectSQL As DataUtils = New DataUtils("project")
        ProjectSQL.OpenConnection()

        Dim sqlDaq001Utils As DataUtils = New DataUtils("Daqument001")
        sqlDaq001Utils.OpenConnection()

        For Each dr As DataRow In dt.Rows
            dr("Rev") = Utilities.TranslateRev(dr("Rev"))
            query = "SELECT MUID From Document_Store WHERE DocumentMUID='" + dr("MUID") + "'"
            Dim dtt = sqlDaq001Utils.ExecuteQuery(query)
            If dtt.Rows.Count > 0 Then
                dr("Image") = "Yes"
            Else
                dr("Image") = "No"
            End If

            query = "SELECT MUID From package_documents WHERE Aux8='" + dr("EngCode") + "'"
            Dim dt_Association As DataTable = ProjectSQL.ExecuteQuery(query)
            If dt_Association.Rows.Count > 0 Then
                dr("Associated") = "Yes"
            Else
                dr("Associated") = "No"
            End If
        Next

        ProjectSQL.CloseConnection()
        sqlDaq001Utils.OpenConnection()

        GridControl1.DataSource = Nothing
        GridControl1.DataSource = dt
        If dt.Rows.Count > 0 Then
            Me.StatusStrip1.Items(0).Text = dt.Rows(0)("Description")
            Me.StatusStrip1.Items(2).Text = dt.Rows.Count
        End If

        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = GridControl1.MainView
        View.Columns("MUID").Visible = False

        query = "SELECT Code+'-'+ Description AS DocumentType " & _
                                  " FROM document_type " & _
                                  " WHERE MUID in " + strchild + " "

        dt = sqlDocUtils.ExecuteQuery(query)
        If dt.Rows.Count > 0 Then
            Me.StatusStrip1.Items(1).Text = "Category:" + dt.Rows(0)("DocumentType")
        End If

        sqlDocUtils.CloseConnection()
    End Sub

    Private Sub SymbolsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SymbolsToolStripMenuItem.Click
        Dim frm_Symbols As New SymbolsMain
        frm_Symbols.Show()

    End Sub
End Class
