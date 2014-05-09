Imports System
Imports System.IO
Imports daqartDLL
Imports System.Data.SqlServerCe

Class DocumentTypeSelect
    Public SelectedType As String


    Private Sub DocumentTypeSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            generatenodes()
                Catch ex As Exception
            Utilities.logErrorMessage("DaqumentTypeSelect.DaqumentTypeSelect_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub

    Public Sub generatenodes()
        Dim Company As New TreeNode
        Dim dt As New DataTable("parent")
        Dim cdt As New DataTable("child")
        Dim query As String = "select * from document_type ORDER BY Code ASC"
        Dim sqlDaqUtils As DataUtils = New DataUtils("Daqument")
        sqlDaqUtils.OpenConnection()
        dt = sqlDaqUtils.ExecuteQuery(query)    '(DocTypeDataManager.GetParentData()
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
        SelectedType = trvCategory.SelectedNode.Tag
        btn_OK.Enabled = True
        Me.Close()
    End Sub

    Private Sub btn_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Me.Close()
    End Sub
End Class