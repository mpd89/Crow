Imports System.Windows.Forms
Imports System.Data.SqlServerCe
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid


Public Class TagSearch


    Private Sub TagSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ComboBox1.SelectedIndex = 0
            Me.TextBox1.Text = ""
            Me.GridControl2.Visible = False
            Me.Size = New Size(450, 80)
        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.TagSearch_Load-" + ex.Message)

            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl2.DoubleClick
        Dim View As ColumnView = GridControl2.MainView
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = View.CalcHitInfo((TryCast(sender, Control)).PointToClient(Control.MousePosition))
        Dim dr As DataRow = View.GetDataRow(View.FocusedRowHandle)

        Try
            If hi.RowHandle >= 0 Then
                dr = View.GetDataRow(hi.RowHandle)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Dim packageID As String = dr(0)
        Dim packageNumber As String = dr(2)
        PackageViewer.PackageViewerManager.OpenPackage(packageID, packageNumber)
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim likeStr = ""
        Select Case Me.ComboBox1.SelectedIndex
            Case 0
                likeStr = Me.TextBox1.Text + "%"
            Case 1
                likeStr = "%" + Me.TextBox1.Text + "%"
            Case Else
                likeStr = Me.TextBox1.Text + "%"
        End Select
        Dim qry = "SELECT tags.PackageMUID, tags.tagNumber,  package.packageNumber, SystemMUID " + _
                    " FROM tags,package WHERE " + _
                    " package.MUID = tags.PackageMUID AND tags.tagNumber LIKE '" + likeStr + "'"

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        dt.Columns.Add("SystemNum", GetType(String))
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim sys As String = SystemManager.SystemDataManager.TranslateSystemID(dt.Rows(i)("SystemMUID"))
            dt.Rows(i)("SystemNum") = sys
        Next
        sqlPrjUtils.CloseConnection()
        Me.Size = New Size(800, 600)
        If Not Me.GridControl2.DataSource Is Nothing Then
            Me.GridControl2.DataSource.Dispose()
        End If
        Me.GridControl2.Visible = True
        Me.GridControl2.Dock = DockStyle.Fill

        Me.GridControl2.DataSource = dt
        Dim View = Me.GridControl2.MainView
        View.Columns(0).Visible = False
        View.Columns(1).Visible = True
        View.Columns(2).Visible = True
        View.Columns(3).Visible = False
        View.Columns(4).Visible = True


    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub TagSearch_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub
End Class
