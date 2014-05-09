Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.IO


Public Class RefLibMain
    Private SelectedID As String
    Dim SQLProject As DataUtils


    Private Sub RefLibMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLProject.CloseConnection()
    End Sub


    Private Sub RefLibMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SQLProject = New DataUtils("project")
        SQLProject.OpenConnection()

        If runtime.ConnectionMode = "OFFLINE" Then
            Me.btn_Add.Enabled = False
            Me.btn_Delete.Enabled = False
        End If

        LoadTypes()
        LoadReferences()
    End Sub


    Private Sub LoadTypes()
        Dim query As String = "SELECT Distinct(Type) FROM ReferenceLibrary ORDER BY Type ASC"

        Try
            Dim dt As DataTable = SQLProject.ExecuteQuery(query)
            Me.lbx_Types.Items.Clear()


            Me.lbx_Types.Items.Add("All Types")
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.lbx_Types.Items.Add(dt.Rows(i)(0))
            Next


        Catch ex As Exception
            Utilities.logErrorMessage("ReferenceLibrary.RefLibMain-" + ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub LoadReferences()
        Dim query As String = "SELECT MUID,Type,Title,Description,Rev FROM ReferenceLibrary ORDER BY Type asc, Title asc"

        Try
            Dim dt As DataTable = SQLProject.ExecuteQuery(query)
            dt.Columns("MUID").ColumnMapping = MappingType.Hidden
            Me.dgv_References.DataSource = dt
        Catch ex As Exception
            Utilities.logErrorMessage("ReferenceLibrary.RefLibMain-" + ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub LoadReferences(ByVal _Type As String)
        Dim query As String
        If _Type = "All Types" Then
            query = "SELECT MUID,Type,Title,Description,Rev FROM ReferenceLibrary ORDER BY Type asc, Title asc"
        Else
            query = "SELECT MUID,Type,Title,Description,Rev FROM ReferenceLibrary WHERE Type = '" + _Type + "'ORDER BY Type asc, Title asc"
        End If

        Try
            Dim dt As DataTable = SQLProject.ExecuteQuery(query)
            dt.Columns("MUID").ColumnMapping = MappingType.Hidden
            Me.dgv_References.DataSource = dt
        Catch ex As Exception
            Utilities.logErrorMessage("ReferenceLibrary.RefLibMain-" + ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub AddReference()
        Dim addForm As New AddReference("add")
        addForm.ShowDialog()

        LoadTypes()
        LoadReferences()
    End Sub


    Private Sub DeleteReference()
        Dim View As ColumnView = Me.dgv_References.MainView
        Dim ParentView As GridView = View.ParentView


        If (MessageBox.Show("Are you sure you want to delete the selected reference?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            SelectedID = View.GetFocusedRowCellValue("MUID")
            Dim query As String = "DELETE FROM ReferenceLibrary WHERE MUID = @MUID"
            Try
                Dim sqlPrjUtils As DataUtils = New DataUtils("project")

                Dim dt_param As DataTable = sqlPrjUtils.paramDT
                dt_param.Rows.Add("@MUID", SelectedID)

                sqlPrjUtils.OpenConnection()
                sqlPrjUtils.ExecuteNonQuery(query, dt_param)
                sqlPrjUtils.CloseConnection()

                LoadTypes()
                LoadReferences()
            Catch ex As Exception
                Utilities.logErrorMessage("ReferenceLibrary.RefLibMain-" + ex.Message)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    Private Sub ViewReference(ByVal _ID As String)
        Me.Cursor = Cursors.AppStarting
        Dim RefDir As String = runtime.AbsolutePath2 + "reference\"
        Dim FileName As String
        Dim query As String = "SELECT FileContents,FileName FROM ReferenceLibrary WHERE MUID = '" + _ID + "'"

        Try
            Directory.CreateDirectory(RefDir)
            Dim dt As DataTable = SQLProject.ExecuteQuery(query)

            FileName = dt.Rows(0)(1)
            Dim fname = RefDir + FileName
            Dim fi As FileInfo = New FileInfo(fname)

            If Not fi.Exists Then
                If Not dt.Rows.Count = 0 Then
                    Dim chunk As Byte() = dt.Rows(0)(0)
                    Dim fs As New FileStream(fname, FileMode.Create, FileAccess.Write)
                    Dim fw As New BinaryWriter(fs)
                    fw.Write(chunk)
                    fw.Close()
                    fs.Close()
                Else
                    MessageBox.Show("No update file available ")
                End If
            End If

            Dim cmdLine As String = """" + fname + """"
            System.Diagnostics.Process.Start(cmdLine)

            LoadTypes()
            LoadReferences()

        Catch ex As Exception
            Utilities.logErrorMessage("ReferenceLibrary.RefLibMain-" + ex.Message)
            MessageBox.Show("There was an error opening the file.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Dispose()
    End Sub


    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        AddReference()
    End Sub


    Private Sub AddReferenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddReferenceToolStripMenuItem.Click
        AddReference()
    End Sub


    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Dim View As ColumnView = Me.dgv_References.MainView
        Dim ParentView As GridView = View.ParentView
        SelectedID = View.GetFocusedRowCellValue("MUID")

        Dim addForm As New AddReference("edit", SelectedID)
        addForm.ShowDialog()

        LoadTypes()
        LoadReferences()
    End Sub


    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        DeleteReference()
    End Sub

    Private Sub dgv_References_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_References.Click
        Dim View As ColumnView = Me.dgv_References.MainView
        Dim ParentView As GridView = View.ParentView

        SelectedID = View.GetFocusedRowCellValue("MUID")
    End Sub


    Private Sub dgv_References_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_References.DoubleClick
        Dim View As ColumnView = Me.dgv_References.MainView
        Dim ParentView As GridView = View.ParentView

        ViewReference(View.GetFocusedRowCellValue("MUID"))
    End Sub

    Private Sub DeleteReferenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteReferenceToolStripMenuItem.Click
        DeleteReference()
    End Sub


    Private Sub lbx_Types_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbx_Types.Click
        LoadReferences(Me.lbx_Types.SelectedItem)
    End Sub



End Class
