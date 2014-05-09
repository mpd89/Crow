Imports daqartDLL


Public Class ManageEquipment
    Public EquipmentTypeID As String
    Public EquipmentMode As String
    Dim SQLProject As DataUtils


    Private Sub ManageEquipment_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLProject.CloseConnection()
    End Sub


    Private Sub ManageEquipment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SQLProject = New DataUtils("project")
            SQLProject.OpenConnection()

            If EquipmentMode = "Edit" Then
                Populate()
            End If

            checkBlanks()
        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.ManageEquipment._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim query As String = Nothing
        Dim dt_param As DataTable = SQLProject.paramDT
        If EquipmentMode = "Edit" Then
            query = "UPDATE equipment_type SET TypeName=@TypeName, " & _
                  "TypeDesc=@TypeDesc, " & _
                  "Active=@Active " & _
                  "WHERE MUID=@MUID"
            dt_param.Rows.Add("@TypeName", EqCode.Text)
            dt_param.Rows.Add("@TypeDesc", EqDesc.Text)
            dt_param.Rows.Add("@Active", EqActive.Checked)
            dt_param.Rows.Add("@MUID", EquipmentTypeID)
        End If

        If EquipmentMode = "Add" Then
            query = "INSERT INTO equipment_type (MUID,TS,TypeName,TypeDesc,Active) VALUES (" & _
                " @MUID," & _
                " @TS," & _
                " @TypeName," & _
                " @TypeDesc," & _
                " @Active)"

            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "equipment_type"))
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@TypeName", EqCode.Text)
            dt_param.Rows.Add("@TypeDesc", EqDesc.Text)
            dt_param.Rows.Add("@Active", EqActive.Checked.ToString)
        End If


        SQLProject.ExecuteNonQuery(query, dt_param)
        Me.Dispose()
    End Sub


    Private Sub Populate()
        Dim query As String = "SELECT * FROM equipment_type WHERE MUID='" + EquipmentTypeID + "'"
        Dim dt As DataTable = SQLProject.ExecuteQuery(query)

        Try
            For Each dr As DataRow In dt.Rows
                If Not IsDBNull(dr(2)) Then
                    EqCode.Text = dr(2)
                End If
                If Not IsDBNull(dr(3)) Then
                    EqDesc.Text = dr(3)
                End If


                If Not IsDBNull(dr(4)) Then
                    If dr(4) = "True" Then
                        EqActive.Checked = True
                    Else
                        EqActive.Checked = False
                    End If
                End If
            Next
        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.ManageEquipment.Populate-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub checkBlanks()
        Dim isEmpty As Boolean = True

        If (EqCode.Text <> "" And EqDesc.Text <> "") Then
            isEmpty = False
        End If

        If (isEmpty = False) Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub


    Private Sub EqCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EqCode.TextChanged
        checkBlanks()
    End Sub


    Private Sub EqDesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EqDesc.TextChanged
        checkBlanks()
    End Sub
End Class