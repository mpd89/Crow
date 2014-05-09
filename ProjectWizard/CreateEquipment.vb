Imports System
Imports System.Windows.Forms
Imports DataStreams.Csv
Imports daqartDLL


Public Class CreateEquipment
    Dim dgtable As DataGridView
    Dim SQLProject As DataUtils


    Private Sub CreateEquipment_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLProject.CloseConnection()
    End Sub


    Private Sub CreateEquipment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SQLProject = New DataUtils("project")
        SQLProject.OpenConnection()

        ViewData("select * from equipment_type")
    End Sub


    Public Sub ViewData(ByVal strquery As String)
        Dim x, y As Integer
        Me.EquipmentPanel2.Controls.Clear()
        y = 200
        x = 360

        Dim dt As DataTable = SQLProject.ExecuteQuery(strquery)

        dgtable = New DataGridView()
        With dgtable
            .DataMember = ""
            .DataSource = Nothing
            .Location = New System.Drawing.Point(0, 0)
            .Name = "dgtable"
            .Size = New System.Drawing.Size(x, y)
            .TabIndex = 0
            .Visible = True
            .AllowUserToAddRows = False
            .DataSource = dt
        End With

        Me.EquipmentPanel2.Controls.Add(dgtable)
        AddHandler dgtable.CellClick, AddressOf activateRow

        Dim hasRows As Integer
        hasRows = dgtable.RowCount

        If hasRows <> 0 Then
            EquipmentFinish.Enabled = True
        End If

        dgtable.Columns(0).Visible = False
        dgtable.Columns(1).Visible = False

        dgtable.Columns(2).Width = 100
        dgtable.Columns(3).Width = 250

        EquipmentRemove.Enabled = False
    End Sub


    Private Sub activateRow(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        Dim myRow As DataGridViewRow
        myRow = dgtable.CurrentRow

        EquipmentRemove.Enabled = True
    End Sub


    Private Sub EquipmentAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquipmentAdd.Click
        addEquipment.ShowDialog()
    End Sub


    Private Sub EquipmentRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquipmentRemove.Click
        removeEquipment.ShowDialog()
    End Sub


    Public Sub deleteRow()
        Dim myRow As DataGridViewRow = dgtable.CurrentRow
        Dim query As String = "DELETE FROM equipment_type WHERE MUID=@MUID"
        Dim dt_param As DataTable = SQLProject.paramDT
        dt_param.Rows.Add("@MUID", myRow.Cells(0).Value.ToString)

        Try
            SQLProject.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            MessageBox.Show("Failed to delete equipment type from Equipment Type table: " + ex.Message)
        End Try

        ViewData("select * from " & daqartDLL.runtime.selectedProject & ".equipment_type")
    End Sub


    Private Sub importCSV()
        Try
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.InitialDirectory = "c:\"
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv"
            openFileDialog1.FilterIndex = 1

            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim reader As CsvReader = New CsvReader(openFileDialog1.FileName)
                reader.ReadHeaders()

                While (reader.ReadRecord())
                    Dim Column1 As String = reader.Values(0)
                    Dim Column2 As String = reader.Values(1)

                    Dim query As String = "INSERT INTO equipment_type (MUID,TS,TypeName,TypeDesc) VALUES (" & _
                    " @MUID," & _
                    " @TS," & _
                    " @TypeName," & _
                    " @TypeDesc)"

                    Dim dt_param As DataTable = SQLProject.paramDT
                    dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "equipment_type"))
                    dt_param.Rows.Add("@TS", Now())
                    dt_param.Rows.Add("@TypeName", Column1)
                    dt_param.Rows.Add("@TypeDesc", Column2)

                    Try
                        SQLProject.ExecuteNonQuery(query, dt_param)
                    Catch ex As Exception
                        MessageBox.Show("Failed to add project to Projects table: " + ex.Message)
                    End Try
                End While

                reader.Close()
                ViewData("select * from equipment_type")

            End If
        Catch ex As Exception
            Utilities.logErrorMessage("ProjectWizard.CreateEquipment.ImportCSV-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub EquipmentImportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquipmentImportButton.Click
        Dim frm_ImportTypes As New EquipmentImport
        frm_ImportTypes.ShowDialog()

        ViewData("select * from equipment_type")
    End Sub


    Private Sub EquipmentFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquipmentFinish.Click
        EndStep()
    End Sub


    Private Sub EndStep()
        If wizard1.WizardStatus = 0 Then
            Me.Dispose()
            Return
        End If

        wizard1.LabelStep4.ForeColor = Color.Black
        wizard1.LabelStep4.Cursor = Cursors.Arrow
        wizard1.StatusStep4.Image = My.Resources.Resources.icon_ok

        wizard1.NextStep.Visible = False
        wizard1.WizardFinish.Enabled = True
        wizard1.WizardStatus = 4

        MessageBox.Show("Project Equipment Types Created Successfully!!")
        Me.Dispose()
    End Sub

End Class