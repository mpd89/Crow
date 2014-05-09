Imports daqartDLL
Public Class TagFormAdd

    Private Sub TagFormAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Try

            Dim qry As String = "SELECT PackageNumber, MUID FROM package ORDER By PackageNumber"
            'Dim myPkgNumTbl As DataTable = daqartDLL.Utilities.ExecuteQuery(qry, "project")

            sqlPrjUtils.OpenConnection()
            Dim myPkgNumTbl As DataTable = sqlPrjUtils.ExecuteQuery(qry)


            cboPkgNum.DataSource = myPkgNumTbl
            cboPkgNum.DisplayMember = myPkgNumTbl.Columns("PackageNumber").ToString
            cboPkgNum.ValueMember = myPkgNumTbl.Columns("MUID").ToString
            qry = "SELECT TypeName, MUID FROM equipment_type ORDER BY TypeName ASC"
            'Dim myTypeIDTbl As DataTable = daqartDLL.Utilities.ExecuteQuery(qry, "project")
            Dim myTypeIDTbl As DataTable = sqlPrjUtils.ExecuteQuery(qry)

            cboTypeID.DataSource = myTypeIDTbl
            cboTypeID.DisplayMember = myTypeIDTbl.Columns("TypeName").ToString
            cboTypeID.ValueMember = myTypeIDTbl.Columns("MUID").ToString

        Catch ex As Exception
            Utilities.logErrorMessage("TagFormAdd.TagFormAdd_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

        sqlPrjUtils.CloseConnection()

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text > " " Then
            btnAdd.Enabled = True
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim qry = " SELECT TagNumber, PackageMUID, TypeMUID FROM Tags WHERE TagNumber = '" + TextBox1.Text + "'"
        'Dim myTbl As DataTable = daqartDLL.Utilities.ExecuteQuery(qry, "project")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim myTbl As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        
        If myTbl.Rows.Count > 0 Then
            Dim tagName As String = myTbl.Rows(0)("TagNumber")
            If tagName.ToLower = TextBox1.Text.ToLower Then
                MessageBox.Show("The Tag number already exist; please edit the Tag Number")
                sqlPrjUtils.CloseConnection()
                Return
            End If
        End If
        'If cboTypeID.SelectedValue = 1 Then
        '    MessageBox.Show("TypeID 'undefined' is not a valid Type ID")
        '    sqlPrjUtils.CloseConnection()
        '    Return
        'End If
        Dim muid As String = idUtils.GetNextMUID("project", "tags")
        qry = " INSERT INTO tags (MUID, TagNumber, PackageMUID, TypeMUID) VALUES (" + _
        "@MUID, @TagNumber, @PackageMUID,@TypeMUID)"
        Dim dt_param As DataTable = sqlPrjUtils.paramDT

        dt_param.Rows.Add("@MUID", muid)
        dt_param.Rows.Add("@TagNumber", TextBox1.Text)
        dt_param.Rows.Add("@PackageMUID", cboPkgNum.SelectedValue.ToString)
        dt_param.Rows.Add("@TypeMUID", cboTypeID.SelectedValue.ToString)

        sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
        MessageBox.Show("Tag has been added to database")
        sqlPrjUtils.CloseConnection()
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
End Class