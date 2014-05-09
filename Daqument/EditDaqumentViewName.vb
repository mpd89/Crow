Imports System.Windows.Forms
Imports System.Drawing
'Imports System.Drawing.Imaging
'Imports System.Drawing.Printing
Imports System.IO
Imports System.Data.SqlClient
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Layout

Public Class EditDaqumentViewName
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Daqument.EditDaqumentInfo.ViewName = Me.tbx_ViewName.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EditDaqumentViewName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.OK_Button.Enabled = False
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_ViewName.TextChanged
        Me.OK_Button.Enabled = True
    End Sub
End Class
