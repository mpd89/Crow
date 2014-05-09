Imports System.Drawing.Imaging
Imports System.Drawing.Printing
'Imports System.Collections
Imports System.IO
'Imports System.Data.SqlClient
Imports daqartDLL
Imports DevExpress.XtraGrid
'Imports DevExpress.XtraEditors.Repository
'Imports DevExpress.XtraGrid.Views.BandedGrid
'Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
'Imports DevExpress.XtraVerticalGrid
'Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.Utils
Public Class EditDaqumentLayerInfo
    Public Shared ViewName As String = ""
    Private myViews As daqartDLL.DataGridViews
    Private showInfo As String = ""
    Private myDoc As EditDaqumentUtil
    Private selectedWeldTableIndex As Integer = -1
    Private FormInitialized As Boolean = False
    Private dataReadOnly As Boolean = True
    Private myGridLayoutTable As DataTable
    Private LayerInfoTable As DataTable

    Public Sub New(ByVal _myDoc As EditDaqumentUtil, ByVal _LayerInfoTable As DataTable)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        myDoc = _myDoc
        LayerInfoTable = _layerInfoTable
        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub EditDaqumentInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            VGridControl1.DataSource = Nothing
            GridControl1.DataSource = Nothing
            Me.GridControl1.Visible = True
            Me.VGridControl1.Visible = False

            VGridControl1.DataSource = myDoc.GetDefaultWeldPointInfoTable()
            GridControl1.DataSource = myDoc.GetDefaultWeldPointInfoTable()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        FormInitialized = True
    End Sub




    Private Sub GridView1_ValidatingEditor(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        If dataReadOnly Then
            e.Valid = False
        Else
            e.Valid = True
        End If
    End Sub
    Private Sub GridView1_InvalidValueException(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles GridView1.InvalidValueException
        If dataReadOnly Then
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
            e.WindowCaption = "Input Error"
            e.ErrorText = "The values are readonly"
        Else
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore
        End If

        ' Destroying the editor and discarding the wrong changes made within the edited cell
        GridView1.HideEditor()
    End Sub

    Private Sub VGridControl1_InvalidValueException(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles VGridControl1.InvalidValueException
        If dataReadOnly Then
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError
            e.WindowCaption = "Input Error"
            e.ErrorText = "The values are readonly"
        Else
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore
        End If

        ' Destroying the editor and discarding the wrong changes made within the edited cell
        VGridControl1.HideEditor()
    End Sub

    Private Sub VGridControl1_ValidatingEditor(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles VGridControl1.ValidatingEditor
        'If VGridControl1.FocusedRow.Name = "rowAnatomy" Or _
        '   VGridControl1.FocusedRow.Name = "rowBusiness" Or _
        '   VGridControl1.FocusedRow.Name = "rowDesign" Or _
        '   VGridControl1.FocusedRow.Name = "History" Then
        '    If Convert.ToInt32(e.Value) > 100000 Then
        '        e.Valid = False
        '    End If
        'End If
        If dataReadOnly Then
            e.Valid = False
        Else
            e.Valid = True
        End If
    End Sub
    Private Sub VGridControl1_RecordCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraVerticalGrid.Events.GetCustomRowCellStyleEventArgs)
        Try
            'Dim dg As DevExpress.XtraVerticalGrid.VGridControl = sender
            'If e.Row.Name <> "rowWeldStatus" Then Exit Sub
            'Dim st = Convert.ToInt32(VGridControl1.GetCellValue(e.Row, e.RecordIndex))
            'riCboEdit.Appearance.BackColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor1(st)
            ''riCboEdit.()
            'riCboEdit.Appearance.ForeColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor2(st)
            'riCboEdit.Appearance.BackColor2 = Color.AliceBlue

            'riCboEdit.Appearance.BorderColor = Color.BlanchedAlmond
            ''If e.Column.FieldName = "Count" Or e.Column.FieldName = "Unit Price" Then
            ''Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Category"))
            ''End If
            ''e.Appearance.Font = New Font(e.Appearance.Font.Name, _
            ''   e.Appearance.Font.Size, FontStyle.Bold)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GridView2_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs)
        Dim View As GridView = sender
        Dim match As Boolean = False
        If e.Column.FieldName = "WeldStatus" Then
            Dim st = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, e.Column.FieldName))
            e.Appearance.BackColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor1(st)
            e.Appearance.ForeColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor2(st)
            'e.Appearance.Font = New Font(e.Appearance.Font.Name, _
            '   e.Appearance.Font.Size, FontStyle.Bold)
        End If
        'If e.Column.FieldName = "Count" Or e.Column.FieldName = "Unit Price" Then
        'Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Category"))
        'End If
    End Sub

    Private Sub rdbColView_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbColView.CheckedChanged
        If Not FormInitialized Then Return
        If rdbColView.Checked Then
            Me.VGridControl1.Visible = True
            Me.GridControl1.Visible = False
        End If
    End Sub

    Private Sub rdbTblView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbTblView.CheckedChanged
        If Not FormInitialized Then Return
        If rdbTblView.Checked Then
            Me.VGridControl1.Visible = False
            Me.GridControl1.Visible = True
        End If
    End Sub


    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        myViews.ShowGridPreview(showInfo)
    End Sub

    Private Sub ExportToPDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToPDFToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Me.VGridControl1.Visible Then
                Me.VGridControl1.ExportToPdf(SaveFileDialog1.FileName)
            Else
                Me.GridControl1.ExportToPdf(SaveFileDialog1.FileName)
            End If
        End If
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Me.VGridControl1.Visible Then
                Me.VGridControl1.ExportToXls(SaveFileDialog1.FileName)
            Else
                Me.GridControl1.ExportToXls(SaveFileDialog1.FileName)
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

End Class