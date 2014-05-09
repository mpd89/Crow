Imports daqartDLL
Imports System.Data.SqlServerCe


Public Class DaqumentImportDefaults
    Public DefaultTypeID As String
    Public DefaultTypeName As String
    Public DefaultProjectID As String
    Public DefaultProjectName As String

    Private Loading As Boolean


    Private Sub DaqumentImportDefaults_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Loading = True

            DefaultProjectID = runtime.selectedProjectID
            DefaultProjectName = runtime.selectedProject

            generatenodes()
            trvCategory.Sort()

            Loading = False
        Catch ex As Exception
            Utilities.logErrorMessage("DaqumentImport.DaqumentImportDefaults_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
        '    Me.Dispose()
    End Sub


    Public Sub generatenodes()
        Dim Company As New TreeNode
        Dim dt As New DataTable("parent")
        Dim cdt As New DataTable("child")
        Dim query As String = "select * from document_type "
        Dim sqlDaqUtils As DataUtils = New DataUtils("Daqument")
        sqlDaqUtils.OpenConnection()
        dt = sqlDaqUtils.ExecuteQuery(query)    '(DocTypeDataManager.GetParentData()

        query = "select * from document_type where ParentMUID != '0'"
        cdt = sqlDaqUtils.ExecuteQuery(query) 'DocTypeDataManager.GetChildData()
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
        sqlDaqUtils.CloseConnection()
    End Sub

    Private Sub LoadTreeView(ByVal ds As DataSet)
        'Dim oTreeView As TreeView = New TreeView()
        Dim oDataRow As DataRow
        For Each oDataRow In ds.Tables(0).Rows
            'Find Root Node,A root node has ParentID NULL
            If oDataRow("ParentMUID") = "0" Then
                'Create Parent Node and add to tree
                Dim oNode As New TreeNode()
                oNode.Text = oDataRow("Code").ToString() + "-" + oDataRow("Description").ToString
                oNode.Tag = oDataRow("MUID").ToString()
                trvCategory.Nodes.Add(oNode)
                'Recursively Populate From root
                RecursivelyLoadTree(oDataRow, oNode)
            End If
        Next oDataRow
        ' Controls.Add(oTreeView)
        ds.Dispose()
        ds = Nothing
    End Sub


    Private Sub RecursivelyLoadTree(ByVal oDataRow As DataRow, _
    ByRef oNode As TreeNode)
        Dim oChildRow As DataRow
        'returns an array of DataRow objects representing the child view 
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

    Private Sub trvCategory_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvCategory.AfterSelect
        DefaultTypeID = trvCategory.SelectedNode.Tag
        DefaultTypeName = trvCategory.SelectedNode.Text
        btn_OK.Enabled = True
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


End Class