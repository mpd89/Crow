Imports System
Imports System.Windows.Forms
Imports DataStreams.Csv
Imports daqartDLL


Public Class addEquipment
    'Dim SQLServer As DataUtils
    'Dim SQLProject As DataUtils

    Private Sub addEquipment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'SQLServer = New DataUtils("project")
            'SQLServer.OpenConnection()

        Catch ex As Exception
            Utilities.logErrorMessage("ProjectWizard.addEquipment._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub CheckBlanks()
        Dim isEmpty As Boolean = True

        If (addEquipmentCode.Text <> "" And addEquipmentDescription.Text <> "") Then
            isEmpty = False
        End If

        If (isEmpty = False) Then
            addEquipmentOKButton.Enabled = True
            addEquipmentApplyButton.Enabled = True
        Else
            addEquipmentOKButton.Enabled = False
            addEquipmentApplyButton.Enabled = False
        End If
    End Sub


    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addEquipmentCancelButton.Click
        Me.Close()
    End Sub


    Private Function CheckCode()
        Dim query As String = "SELECT TypeName FROM equipment_type WHERE TypeName='" & addEquipmentCode.Text & "'"
        Dim hasExisting As Boolean = False

        Try
            Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

            If dt.Rows.Count > 0 Then
                hasExisting = True
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to verify new project name: " + ex.Message)
        End Try
        Return hasExisting
    End Function


    Private Sub insertData()
        Dim query As String = "INSERT INTO equipment_type(MUID,TS,TypeName,TypeDesc) VALUES (" & _
        " @MUID," & _
        " @TS," & _
        " @TypeName," & _
        " @TypeDesc)"

        Dim dt_param As DataTable = runtime.SQLServer.paramDT
        dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "equipment_type"))
        dt_param.Rows.Add("@TS", Now())
        dt_param.Rows.Add("@TypeName", addEquipmentCode.Text)
        dt_param.Rows.Add("@TypeDesc", addEquipmentDescription.Text)

        Try
            runtime.SQLServer.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Failed to add code to equipment_code table: " + ex.Message)
        End Try
    End Sub


    Private Sub addEquipmentOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addEquipmentOKButton.Click
        If CheckCode() = False Then
            insertData()
        Else
            MessageBox.Show("The code you have entered """ + addEquipmentCode.Text + """ is already in use. ")
        End If

        CreateEquipment.ViewData("select * from equipment_type")

        Me.Close()
    End Sub


    Private Sub addEquipmentApplyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addEquipmentApplyButton.Click
        If CheckCode() = False Then
            insertData()
        Else
            MessageBox.Show("The code you have entered """ + addEquipmentCode.Text + """ is already in use. ")
        End If

        addEquipmentCode.Text = ""
        addEquipmentDescription.Text = ""
        CheckBlanks()
        CreateEquipment.ViewData("select * from equipment_type")
    End Sub


    Private Sub addEquipmentCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles addEquipmentCode.KeyUp
        CheckBlanks()
    End Sub


    Private Sub addEquipmentDescription_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles addEquipmentDescription.KeyUp
        CheckBlanks()
    End Sub

End Class