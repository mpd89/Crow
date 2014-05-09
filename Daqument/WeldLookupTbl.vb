Imports System.Windows.Forms
Imports daqartDLL

Public Class WeldLookupTbl
    Private tbxCtrls As New List(Of Control)
    Private lbxCtrls As New List(Of Control)
    Private fieldStr As New List(Of String)
    Private tblName As String
    Private dr As DataRow
    Private UpdateFlg As String
    Private myTitle As String
    Private Sub ParameterTextBoxSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim info As System.Windows.Forms.Button = CType(sender, System.Windows.Forms.Button)
        For Each ctrl As Control In tbxCtrls
            Dim selectedInfo = Split(ctrl.Name, "-")(1)
            If (ctrl.Text > "") And (selectedInfo <> "ID") Then
                dr(selectedInfo) = ctrl.Text
                ' Me.SetDefaultValue(dr)
            End If
        Next
    End Sub
    Private Sub UpdateRow()
        Dim qryFields As String = ""
        For j As Integer = 0 To fieldStr.Count - 1
            qryFields = qryFields + fieldStr(j) + " = '" + dr(j).ToString + "',"
        Next
        qryFields = qryFields.Remove(qryFields.Length - 1, 1)
        Dim qry = "UPDATE " + tblName + " SET " + qryFields + " WHERE ID = '" + dr(0).ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()

        Dim dt_param As DataTable = sqlPrjUtils.paramDT

        sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
        sqlPrjUtils.CloseConnection()

        'Utilities.ExecuteNonQuery(qry, "project")
    End Sub
    Private Sub InsertRow()
        Dim qryInsert As String = ""
        Dim qryValues As String = ""
        For j As Integer = 0 To fieldStr.Count - 1
            qryInsert = qryInsert + fieldStr(j) + "',"
            qryValues = qryValues + "'" + dr(j).ToString + "',"
        Next
        qryInsert = qryInsert.Remove(qryInsert.Length - 1, 1)
        Dim qry = "INSERT INTO " + tblName + " ( " + qryInsert + " ) VALUES (" + qryValues + ")"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        Dim dt_param As DataTable = sqlPrjUtils.paramDT

        sqlPrjUtils.OpenConnection()
        sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
        sqlPrjUtils.CloseConnection()
    End Sub


    Public Sub New(ByVal odr As DataRow, ByVal otblName As String, ByVal oFlg As String, ByVal oTitle As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        tblName = otblName
        UpdateFlg = oFlg
        dr = odr
        myTitle = oTitle
        For i As Integer = 0 To dr.Table.Columns.Count - 1
            fieldStr.Add(dr.Table.Columns(i).ColumnName)
        Next
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If UpdateFlg = "Delete" Then
        ElseIf UpdateFlg = "Add" Then
        ElseIf UpdateFlg = "Update" Then
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub WeldLookupTbl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim X = 20
            Dim Y = 50
            Dim i As Integer
            tbxCtrls.Clear()
            lbxCtrls.Clear()
            For i = 1 To dr.Table.Columns.Count - 1
                Dim tbx As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox
                tbx.Name = "tbx-" + dr.Table.Columns(i).ColumnName
                tbx.Text = dr(i).ToString
                tbx.Location = New Point(X, Y + 15)
                tbxCtrls.Add(tbx)
                Me.Controls.Add(tbx)
                Dim lbl As System.Windows.Forms.Label = New System.Windows.Forms.Label
                lbl.Text = dr.Table.Columns(i).ColumnName
                lbl.Location = New Point(X, Y)
                lbl.TextAlign = ContentAlignment.TopLeft
                lbxCtrls.Add(lbl)
                Me.Controls.Add(lbl)
                Y = Y + 52
                If (i + 1) Mod 5 = 0 Then
                    X = X + 150
                    Y = 50
                End If
            Next
            Dim ht As Integer = 450
            Dim wd As Integer = (Int(dr.Table.Columns.Count / 6) * 150) + 400
            If dr.Table.Columns.Count < 6 Then
                ht = dr.Table.Columns.Count * 50 + 150
            End If
            Me.Size = New Size(wd, ht)
            Me.Text = myTitle
            Me.lblTitle.Text = UpdateFlg + " " + myTitle
        Catch ex As Exception
            Utilities.logErrorMessage("Daqument.WeldLookupTbl_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
