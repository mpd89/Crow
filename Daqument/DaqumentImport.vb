Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports daqartDLL
Imports IMAGECONVERTERLib
Imports System.Data.SqlServerCe

Public Class DaqumentImport

    Private FolderPath As String
    Private MasterCode As String
    Dim ImgCon As New P2I
    Private Importing As Boolean
    Private SelectedRow As Integer

    Private DefaultTypeID As String
    Private DefaultTypeName As String
    Private DefaultProjectID As String
    Private DefaultProjectName As String


    Private Sub DaqumentImport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If runtime.SiteName = "BP001" Then
            Me.dgv_Import.Columns(10).HeaderText = "EPT#"
        End If

    End Sub


    Private Sub btn_OpenFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OpenFolder.Click
        Dim frm_Defaults As New DaqumentImportDefaults
        If frm_Defaults.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        DefaultTypeID = frm_Defaults.DefaultTypeID
        DefaultTypeName = frm_Defaults.DefaultTypeName
        DefaultProjectID = frm_Defaults.DefaultProjectID
        DefaultProjectName = frm_Defaults.DefaultProjectName


        fbd_Folder.ShowDialog()

        If (fbd_Folder.SelectedPath <> "") Then
            FolderPath = fbd_Folder.SelectedPath
            lbl_CurrentPath.Text = "Current Path= " + FolderPath

            ReadFileNames()

        End If

    End Sub


    Private Sub ReadFileNames()
        Dim di As New IO.DirectoryInfo(FolderPath)
        Dim array_Files As IO.FileInfo() = di.GetFiles("*.*")
        Dim fi As IO.FileInfo

        Dim i As Integer = 0
        For Each fi In array_Files
            Dim DocName As String

            If fi.Extension = ".pdf" Then

                DocName = fi.Name
                DocName = DocName.Replace(fi.Extension, "")

                dgv_Import.Rows.Add("View", fi.Name, "150", "150", DocName, DocName, "", "", "", "", "", DefaultTypeName, DefaultProjectName)

                dgv_Import.Rows(i).Cells(11).Tag = DefaultTypeID
                dgv_Import.Rows(i).Cells(12).Tag = DefaultProjectID
                i = i + 1
            End If

        Next


        'set default project


        'set default type


        CheckBlanks()

        CheckExisting()
    End Sub


    Private Sub tbx_Hdpi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_Hdpi.TextChanged
        If Not dgv_Import.Rows.Count = 0 Then
            dgv_Import.Rows(SelectedRow).Cells(2).Value = tbx_Hdpi.Text
        End If
    End Sub


    Private Sub tbx_Vdpi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_Vdpi.TextChanged
        If Not dgv_Import.Rows.Count = 0 Then
            dgv_Import.Rows(SelectedRow).Cells(3).Value = tbx_Vdpi.Text
        End If
    End Sub


    Private Sub dgv_Import_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Import.CellClick

        SelectedRow = e.RowIndex
        If e.RowIndex < 0 Then Return
        tbx_Hdpi.Text = dgv_Import.Rows(e.RowIndex).Cells(2).Value
        tbx_Vdpi.Text = dgv_Import.Rows(e.RowIndex).Cells(3).Value

        If e.ColumnIndex = 0 Then
            Me.Cursor = Cursors.AppStarting
            Try
                Dim FullPath As String = FolderPath + "\" + dgv_Import.Rows(e.RowIndex).Cells(1).Value
                Dim thisImg As Image = Nothing
                ipw_Image.pbx_Image.Image = Nothing

                Dim TheFile As FileInfo = New FileInfo(runtime.AbsolutePath + "OutputFile00001.png")
                If TheFile.Exists Then
                    File.Delete(runtime.AbsolutePath + "OutputFile00001.png")
                    'Else
                    '    Throw New FileNotFoundException()
                End If

                ImgCon.ImgConvert(runtime.AbsolutePath, FullPath, tbx_Hdpi.Text, tbx_Vdpi.Text, False)
                Dim fs As FileStream
                fs = New FileStream(runtime.AbsolutePath + "OutputFile00001.png", FileMode.Open, FileAccess.Read)
                thisImg = Image.FromStream(fs)
                fs.Dispose()

                ipw_Image.Enabled = True
                ipw_Image.pbx_Image.Image = thisImg
                ipw_Image.ImageLoaded()

            Catch ex As FileNotFoundException
                'lblStatus.Text += ex.Message
            Catch ex As Exception
                Utilities.logErrorMessage("DaqumentImport.dgv_Import_Click-" + ex.Message)
                MessageBox.Show(ex.Message)
                'lblStatus.Text += ex.Message
            End Try
            Me.Cursor = Cursors.Default
            Return
        End If


        If e.ColumnIndex = 11 Then
            Dim frm_TypeSelect As New DocumentTypeSelect
            frm_TypeSelect.ShowDialog()

            Dim SelectedType As String = frm_TypeSelect.SelectedType

            If Not SelectedType = "" Then
                dgv_Import.Rows(e.RowIndex).Cells(11).Value = GetTypeDescription(SelectedType)
                dgv_Import.Rows(e.RowIndex).Cells(11).Tag = SelectedType
            End If

        End If

        If e.ColumnIndex = 12 Then
            Dim frm_ProjectSelect As New ProjectSelect
            frm_ProjectSelect.ShowDialog()

            Dim SelectedProjectID As Integer = frm_ProjectSelect.SelectedProjectID
            Dim SelectedProjectName As String = frm_ProjectSelect.SelectedProjectName

            dgv_Import.Rows(e.RowIndex).Cells(12).Value = SelectedProjectName
            dgv_Import.Rows(e.RowIndex).Cells(12).Tag = SelectedProjectID
        End If

    End Sub


    Private Function GetTypeDescription(ByVal TypeID As String) As String
        Dim query As String = "select * from document_type  where MUID = '" + TypeID.ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("Daqument")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()


        If Not dt.Rows.Count = 0 Then
            Return dt.Rows(0)("Code") + "-" + dt.Rows(0)("Description")
        Else
            Return "Error"
        End If

    End Function


    Private Sub btn_Import_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Import.Click
        Try

            Me.Cursor = Cursors.AppStarting
            Importing = True

            If CheckBlanks() Or CheckExisting() Then
                MessageBox.Show("Please correct or delete records with errors then import again." + vbCr + vbCr + _
                    "**Red indicates and existing record." + vbCr + vbCr + _
                    "**Yellow indicates the field is required.", "Alert")
                Me.Cursor = Cursors.Default
                Return
            End If

            For RowNum As Integer = 0 To dgv_Import.Rows.Count - 1

                Dim FullPath As String = FolderPath + "\" + dgv_Import.Rows(RowNum).Cells(1).Value
                Dim thisImg As Image = Nothing
                ipw_Image.pbx_Image.Image = Nothing

                Dim TheFile As FileInfo = New FileInfo(runtime.AbsolutePath + "OutputFile00001.png")
                If TheFile.Exists Then
                    File.Delete(runtime.AbsolutePath + "OutputFile00001.png")
                End If

                ImgCon.ImgConvert(runtime.AbsolutePath, FullPath, tbx_Hdpi.Text, tbx_Vdpi.Text, False)
                Dim fs As FileStream
                fs = New FileStream(runtime.AbsolutePath + "OutputFile00001.png", FileMode.Open, FileAccess.Read)
                thisImg = Image.FromStream(fs)
                fs.Dispose()


                adddocrecord(RowNum)
            Next

            Importing = False
            Me.Cursor = Cursors.Default

            MessageBox.Show("Documents imported successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Catch ex As Exception
            Utilities.logErrorMessage("DaqumentImport.btn_Import_Click-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Function CheckBlanks() As Boolean
        Dim HasError As Boolean = False

        For RowNum As Integer = 0 To dgv_Import.Rows.Count - 1
            For ColNum As Integer = 4 To 10
                If dgv_Import.Rows(RowNum).Cells(ColNum).Value = "" Then
                    dgv_Import.Rows(RowNum).Cells(ColNum).Style.BackColor = Color.Yellow
                    HasError = True
                Else
                    dgv_Import.Rows(RowNum).Cells(ColNum).Style.BackColor = Color.White
                End If
            Next
        Next

        Return HasError
    End Function

    Private Sub dgv_Import_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Import.CellEnter
        SelectedRow = e.RowIndex
    End Sub


    Private Sub dgv_Import_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Import.CellValueChanged
        CheckBlanks()
    End Sub


    Private Function CheckExisting() As Boolean
        Dim HasError As Boolean = False
        Dim conn As New SqlCeConnection
        Dim cmd As New SqlCeCommand
        Dim query As String

        conn = daqartDLL.connections.DaqumentConnect(conn)

        For RowNum As Integer = 0 To dgv_Import.Rows.Count - 1

            If conn Is Nothing Then
                conn.Open()
            End If
            Dim rev As String = dgv_Import.Rows(RowNum).Cells(6).Value
            Dim revCode As String = Utilities.FormatRev(rev)

            query = "SELECT * FROM documents WHERE EngCode='" + dgv_Import.Rows(RowNum).Cells(4).Value + _
                "' AND Revision='" + revCode + _
                "' AND Sheet='" + dgv_Import.Rows(RowNum).Cells(8).Value + "' AND ProjectMUID='" + runtime.selectedProjectID + "'"

            If runtime.SiteName = "BP001" Then
                query = "SELECT * FROM documents WHERE EngCode='" + dgv_Import.Rows(RowNum).Cells(4).Value + _
                    "' AND Revision='" + revCode + _
                    "' AND Sheet='" + dgv_Import.Rows(RowNum).Cells(8).Value + _
                    "' AND ProjectMUID='" + runtime.selectedProjectID + "'" + _
                    "' AND Location='" + dgv_Import.Rows(RowNum).Cells(10).Value + "'"
            End If

            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
            sqlDocUtils.OpenConnection()
            Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
            sqlDocUtils.CloseConnection()

            If Not dt.Rows.Count = 0 Then
                HasError = True
                dgv_Import.Rows(RowNum).Cells(4).Style.BackColor = Color.Red
                dgv_Import.Rows(RowNum).Cells(5).Style.BackColor = Color.Red
            Else
                dgv_Import.Rows(RowNum).Cells(4).Style.BackColor = Color.White
                dgv_Import.Rows(RowNum).Cells(5).Style.BackColor = Color.White
            End If
        Next

        Return HasError
    End Function


    Public Sub adddocrecord(ByVal RowNum As Integer)
        Try

            'Dim rec As New DocumentData
            'rec.DocumentTS = Now()
            Dim EngCode As String = dgv_Import.Rows(RowNum).Cells("EngineeringCode").Value
            Dim ClientCode As String = dgv_Import.Rows(RowNum).Cells("ClientCode").Value
            Dim Revision As String = FrmSave.FormatRev(dgv_Import.Rows(RowNum).Cells("Revision").Value)
            'Dim DateLoaded = Now.Date
            Dim Description = dgv_Import.Rows(RowNum).Cells("Description").Value
            Dim Sheet = dgv_Import.Rows(RowNum).Cells("Sheet").Value
            Dim Sheets = dgv_Import.Rows(RowNum).Cells("Sheets").Value
            Dim Location = dgv_Import.Rows(RowNum).Cells("Location").Value
            Dim DocumenttypeMUID = dgv_Import.Rows(RowNum).Cells("Type").Tag.ToString
            Dim ProjectMUID = dgv_Import.Rows(RowNum).Cells("Project").Tag
            Dim DocumentPath = "001"
            'DocumentDataManager.AddDataRecord(rec)
            Dim muid As String = idUtils.GetNextMUID("Daqument", "documents")
            Dim query As String = "insert into documents( " + _
                "MUID, TS,EngCode,ClientCode,Revision,DateLoaded,Description," + _
                " Sheet,Sheets,Location,DocumentTypeMUID,ProjectMUID,DocumentPath) values (" + _
                "@MUID," + _
                "@TS," + _
                "@EngCode," + _
                "@ClientCode," + _
                "@Revision," + _
                "@DateLoaded," + _
                "@Description," + _
                "@Sheet," + _
                "@Sheets," + _
                "@Location," + _
                "@DocumentTypeMUID," + _
                "@ProjectMUID," + _
                "@DocumentPath)"
            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

            Dim dt_param As DataTable = sqlDocUtils.paramDT
            dt_param.Rows.Add("@MUID", muid)
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@EngCode", EngCode.ToString)
            dt_param.Rows.Add("@ClientCode", ClientCode.ToString)
            dt_param.Rows.Add("@Revision", Revision)
            dt_param.Rows.Add("@DateLoaded", Now())
            dt_param.Rows.Add("@Description", Description)
            dt_param.Rows.Add("@Sheet", Sheet)
            dt_param.Rows.Add("@Sheets", Sheets)
            dt_param.Rows.Add("@Location", Location)
            dt_param.Rows.Add("@DocumentTypeMUID", DocumenttypeMUID)
            dt_param.Rows.Add("@ProjectMUID", ProjectMUID)
            dt_param.Rows.Add("@DocumentPath", DocumentPath)

            sqlDocUtils.OpenConnection()
            sqlDocUtils.ExecuteNonQuery(query, dt_param)
            sqlDocUtils.CloseConnection()

            saveDocMUID(muid)
        Catch ex As Exception
            Utilities.logErrorMessage("DaqumentImport.addocrecord-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Sub saveDocMUID(ByVal DocID As String)
        Dim conn As New SqlCeConnection
        Dim cmd As New SqlCeCommand
        Dim FileSize As UInt32
        Dim rawData() As Byte
        Dim fs As FileStream
        Try
            fs = New FileStream(runtime.AbsolutePath + "OutputFile00001.png", FileMode.Open, FileAccess.Read)
            FileSize = fs.Length
            rawData = New Byte(FileSize) {}
            fs.Read(rawData, 0, FileSize)
            fs.Close()
            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument001")
            Dim muid As String = idUtils.GetNextMUID("Daqument001", "document_store")
            Dim query As String = "insert into document_store(" + _
            "MUID, TS,DocumentMUID,DocumentImage) values (" + _
            "'" + muid + "','" + Now() + "','" + DocID + "',@File)"

            sqlDocUtils.OpenConnection()
            sqlDocUtils.ExecuteSingleParameterizedQuery(query, "@File", rawData)
            sqlDocUtils.CloseConnection()
        Catch ex As Exception
            Utilities.logErrorMessage("DaqumentImport.savein2-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


  
    Private Sub btn_ImportCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ImportCSV.Click
        ofd1.Filter = "csv Data Files|*.csv"
        ofd1.ShowDialog()
        ofd1.FilterIndex = 1

        'If ofd1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return

        Dim frm_ImportIndex As New ImportReadIndex(ofd1.FileName)
        'frm_ImportIndex.FileName = ofd1.FileName
        frm_ImportIndex.ShowDialog()

        If frm_ImportIndex.dt Is Nothing Then
            Return
        End If

        Dim dt_Import As New DataTable
        dt_Import = frm_ImportIndex.dt

        For i As Integer = 0 To dt_Import.Rows.Count - 1
            For docRow As Integer = 0 To Me.dgv_Import.RowCount - 1
                If dgv_Import.Rows(docRow).Cells(1).Value = dt_Import.Rows(i)(frm_ImportIndex.cbx_FileName.SelectedIndex) Then
                    dgv_Import.Rows(docRow).Cells(4).Value = dt_Import.Rows(i)(frm_ImportIndex.cbx_EngCode.SelectedIndex)
                    dgv_Import.Rows(docRow).Cells(5).Value = dt_Import.Rows(i)(frm_ImportIndex.cbx_ClientCode.SelectedIndex)
                    dgv_Import.Rows(docRow).Cells(6).Value = dt_Import.Rows(i)(frm_ImportIndex.cbx_Revision.SelectedIndex)
                    dgv_Import.Rows(docRow).Cells(7).Value = dt_Import.Rows(i)(frm_ImportIndex.cbx_Description.SelectedIndex)
                    dgv_Import.Rows(docRow).Cells(8).Value = dt_Import.Rows(i)(frm_ImportIndex.cbx_Sheet.SelectedIndex)
                    dgv_Import.Rows(docRow).Cells(9).Value = dt_Import.Rows(i)(frm_ImportIndex.cbx_Sheets.SelectedIndex)
                    dgv_Import.Rows(docRow).Cells(10).Value = dt_Import.Rows(i)(frm_ImportIndex.cbx_Location.SelectedIndex)
                End If
            Next
        Next

        frm_ImportIndex.Dispose()
    End Sub





End Class