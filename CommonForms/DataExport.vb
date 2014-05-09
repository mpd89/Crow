Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting


Public Class DataExport
    Dim dt As DataTable


    Public Sub New(ByVal _dt As DataTable)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dt = _dt

    End Sub


    Private Sub DataExport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Cursor = Cursors.Default

        If Not dt Is Nothing Then
            Me.dgv_Export.DataSource = dt
            btn_Export.Enabled = True
        End If


    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Export.Click
        Dim Filename As String
        Dim View As ColumnView = Me.dgv_Export.MainView

        If cbx_ExportType.SelectedIndex >= 0 Then
            Dim SaveFileDialog1 As New SaveFileDialog()

            SaveFileDialog1.InitialDirectory = CurDir()
            SaveFileDialog1.FilterIndex = 1

            If SaveFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
            Try

                Filename = SaveFileDialog1.FileName
                Select Case cbx_ExportType.SelectedIndex
                    Case 0
                        View.ExportToHtml(Filename + ".htm")
                    Case 1
                        View.ExportToPdf(Filename + ".pdf")
                    Case 2
                        View.ExportToText(Filename + ".txt")
                    Case 3
                        View.ExportToXls(Filename + ".xls")
                End Select
            Catch ex As Exception
                MessageBox.Show("Error exporting packages: " + ex.Message)
                Me.Close()

            End Try
        End If
        MessageBox.Show("File has been exported")

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


End Class