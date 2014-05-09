Imports daqartDLL


Public Class SymbolsMain
    Dim dt_Symbols As DataTable
    Dim Loading As Boolean = True


    Private Sub SymbolsMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dt_Symbols = Utilities.Cache_Symbols
        Me.lbx_Symbols.DataSource = dt_Symbols
        Me.lbx_Symbols.DisplayMember = dt_Symbols.Columns("Name").ToString
        Me.lbx_Symbols.ValueMember = dt_Symbols.Columns("MUID").ToString

        Loading = False
    End Sub


    Private Sub lbx_Symbols_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbx_Symbols.SelectedIndexChanged
        If Loading Then Return

        Me.Cursor = Cursors.AppStarting
        Try

            Dim fn As String = runtime.AbsolutePath + "symbols\" + Me.lbx_Symbols.Text + ".png"
            Dim img As Image = Image.FromFile(fn)

            Me.pbx_Preview.Image = img

            Me.btn_Delete.Enabled = True
            Me.btn_Edit.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error opening image.")
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        Dim frm_Add As New AddEditSymbol("add")
        frm_Add.ShowDialog()

        'refresh list box
        dt_Symbols = Utilities.Cache_Symbols
        Me.lbx_Symbols.DataSource = dt_Symbols
        Me.lbx_Symbols.DisplayMember = dt_Symbols.Columns("Name").ToString
        Me.lbx_Symbols.ValueMember = dt_Symbols.Columns("MUID").ToString
    End Sub


    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click

    End Sub


    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click

        If MessageBox.Show("Are you sure you want to delete the selected symbol?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            Dim qry = "DELETE FROM SystemImages WHERE MUID = '" + Me.lbx_Symbols.SelectedValue + "'"
            Dim sqlUtils As DataUtils = New DataUtils("server")
            Dim dt_param As DataTable = sqlUtils.paramDT

            sqlUtils.OpenConnection()
            sqlUtils.ExecuteNonQuery(qry, dt_param)
            sqlUtils.CloseConnection()

            'refresh list box
            dt_Symbols = Utilities.Cache_Symbols
            Me.lbx_Symbols.DataSource = dt_Symbols
            Me.lbx_Symbols.DisplayMember = dt_Symbols.Columns("Name").ToString
            Me.lbx_Symbols.ValueMember = dt_Symbols.Columns("MUID").ToString
        End If

    End Sub
End Class