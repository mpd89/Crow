Imports DaqartDll
Public Class Search
    Dim Project As Boolean
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim strquery As String = ""
        'search DocumentID
        If (txtDocumentID.Text <> "") Then
            strquery += " AND DocumentID= '" + txtDocumentID.Text + "'"
        End If
        'engineering code
        If (txtEngCode.Text <> "") Then
            strquery += " AND EngCode= '" + txtEngCode.Text + "'"
        End If
        ' client code
        If (txtClientCode.Text <> "") Then
            strquery += " AND ClientCode= '" + txtClientCode.Text + "'"
        End If
        'sheet
        If (txtSheet.Text <> "") Then
            strquery += " AND Sheet= '" + txtClientCode.Text + "'"
        End If
        'revision
        If (txtRevision.Text <> "") Then
            strquery += " AND Revision= '" + txtClientCode.Text + "'"
        End If
        'project
        If (Project = True) Then
            Dim temp As Integer = cmbProject.SelectedIndex + 1
            strquery += " AND ProjectID= '" + txtClientCode.Text + "'"
            MessageBox.Show(strquery)
        End If
        'location
        If (txtLocation.Text <> "") Then
            strquery += " AND Location= '" + txtClientCode.Text + "'"
        End If

        ' Search Description
        If (txtDescription.Text <> "") Then
            strquery += " AND Description= '" + txtDescription.Text + "'"
        End If
        Dim query As String = "SELECT documents.DocumentID,documents.EngCode,documents.ClientCode,documents.Description,documents.Revision AS Rev, documents.Sheet+'/'+ documents.Sheets AS Sht, documents.DateLoaded, document_type.Code+'-'+document_type.Description AS DocumentType " & _
                                          "FROM document_type, documents " & _
                                          "WHERE document_type.MUID=documents.DocumentTypeMUID  AND  1=1" + strquery
        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        sqlDocUtils.OpenConnection()


        'MessageBox.Show(queryString)
        Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query) 'DataManager.ExecuteQuery(queryString, "documents")
        sqlDocUtils.CloseConnection()
        If (dt Is Nothing) Then
            Return '
        End If
        If (Not dt Is Nothing) Then
            dgvSearch.DataSource = dt
            With dgvSearch
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End With
        End If
    End Sub


    Private Sub Search_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim query As String = "SELECT * FROM projects"
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            sqlSrvUtils.OpenConnection()


            'MessageBox.Show(queryString)
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query) 'DataManager.ExecuteQuery(queryString, "documents")
            sqlSrvUtils.CloseConnection()
            Me.cmbProject.DataSource = dt
            Me.cmbProject.DisplayMember = dt.Columns(2).ToString
            Me.cmbProject.ValueMember = dt.Columns(0).ToString
            Project = False
        Catch ex As Exception
            Utilities.logErrorMessage("Daqument.Search.Search_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbProject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProject.SelectedIndexChanged
        Project = True
    End Sub

    Private Sub cmbProject_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProject.SelectedValueChanged
        Project = True
    End Sub

    Private Sub txtDocumentID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDocumentID.KeyPress
        Dim c As Char = e.KeyChar
        e.Handled = Not (Char.IsDigit(c))
    End Sub
End Class