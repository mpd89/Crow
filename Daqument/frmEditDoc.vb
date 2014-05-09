'Imports System.Data.SqlServerCe
Imports System.io
Imports System.data
Imports System.Drawing.Imaging
Imports IMAGECONVERTERLib
Imports daqartDLL



Public Class frmEditDoc
    Dim load1 As Boolean = True
    'Dim ds As New DocumentStore
    Dim pathstring As String
    Dim DocumentID As String
    'Dim drstore As New DocumentStore
    Dim ImgCon As New P2I
    Dim OriginalImage As Image
    Dim NewImage As Boolean = False
    Dim ImageExists As Boolean
    Dim DocInfoModified As Boolean = False
    Dim Loading As Boolean = True

    Public Sub New(ByVal ThisDocumentID As String)
        InitializeComponent()

        DocumentID = ThisDocumentID
    End Sub


    Private Sub frmEditDoc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Loading = True

            If runtime.SiteName = "BP001" Then
                Me.lbl_Location.Text = "EPT#"
            End If

            Me.txtRevision.Text = TranslateRev(Me.txtRevision.Text)

            Dim query As String = "select * from document_store  where DocumentMUID = '" + DocumentID + "'"
            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument001")
            sqlDocUtils.OpenConnection()
            Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
            sqlDocUtils.CloseConnection()

            ImageExists = False

            If dt Is Nothing Then Return


            If dt.Rows.Count > 0 Then
                Dim imagedata() As Byte
                Dim imageBytedata As MemoryStream
                imagedata = dt.Rows(0)("DocumentImage")
                imageBytedata = New MemoryStream(imagedata)
                OriginalImage = Image.FromStream(imageBytedata)

                ImageExists = True
                ipw_Image.pbx_Image.Image = OriginalImage
                ipw_Image.ImageLoaded()
            End If

            Loading = False
        Catch ex As Exception
            Utilities.logErrorMessage("frmEditDoc.frmEditDoc_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If DocInfoModified Then
            If CheckExisting() Then
                MessageBox.Show("Drawing already exist")
                Return
            End If
        End If

        Dim query As String = "UPDATE documents  SET " + _
                "EngCode=@EngCode," + _
                "ClientCode=@ClientCode," + _
                "Revision=@Revision," + _
                "Description=@Description," + _
                "Sheet=@Sheet," + _
                "Sheets=@Sheets," + _
                "ProjectMUID=@ProjectMUID," + _
                "Location=@Location," + _
                "DocumentTypeMUID=@DocumentTypeMUID" + _
                " WHERE MUID=@MUID"

        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        Dim dt_param As DataTable = sqlDocUtils.paramDT
        dt_param.Rows.Add("@EngCode", txtEngCode.Text)
        dt_param.Rows.Add("@ClientCode", txtClientCode.Text)
        dt_param.Rows.Add("@Revision", FormatRev(txtRevision.Text))
        dt_param.Rows.Add("@Description", txtDescription.Text)
        dt_param.Rows.Add("@Sheet", txtSheet.Text)
        dt_param.Rows.Add("@Sheets", txtSheetOf.Text)
        dt_param.Rows.Add("@ProjectMUID", Utilities.GetProjectID(runtime.selectedProject))
        dt_param.Rows.Add("@Location", txtLocation.Text)
        dt_param.Rows.Add("@DocumentTypeMUID", Me.tbx_DocType.Tag.ToString)
        dt_param.Rows.Add("@MUID", DocumentID)

        sqlDocUtils.OpenConnection()
        sqlDocUtils.ExecuteNonQuery(query, dt_param)
        sqlDocUtils.CloseConnection()
        If NewImage = True Then
            If Not ImageExists Then
                addImage(DocumentID)
            Else
                updateDocumentImage()
            End If
        End If

        MessageBox.Show("Document updated.")

        Me.Dispose()

    End Sub


    Private Function CheckExisting() As Boolean
        Dim HasError As Boolean = False
        Dim query As String

        Dim rev As String = Me.txtRevision.Text
        Dim revCode As String = Utilities.FormatRev(rev)

        query = "SELECT * FROM documents WHERE " & _
            " EngCode='" + Me.txtEngCode.Text + "'" & _
            " AND ClientCode='" + Me.txtClientCode.Text + "'" & _
            " AND Revision='" + revCode + "'" & _
            " AND Sheet='" + Me.txtSheet.Text + "'" & _
            " AND ProjectMUID = '" + runtime.selectedProjectID + "'"

        If runtime.SiteName = "BP001" Then
            query = "SELECT * FROM documents WHERE" & _
            " EngCode='" + Me.txtEngCode.Text + "'" & _
            " AND ClientCode='" + Me.txtClientCode.Text + "'" & _
            " AND Revision='" + revCode + "'" & _
            " AND Sheet='" + Me.txtSheet.Text + "'" & _
            " AND ProjectMUID = '" + runtime.selectedProjectID + "'" & _
            " AND Location = '" + Me.txtLocation.Text + "'"
        End If

        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
        sqlDocUtils.OpenConnection()
        Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
        sqlDocUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            HasError = True
        End If

        Return HasError
    End Function


    Public Sub addImage(ByVal DocID As String)
        'Dim conn As New SqlCeConnection
        'Dim cmd As New SqlCeCommand
        Dim FileSize As UInt32
        Dim rawData() As Byte
        Dim fs As FileStream
        'conn = daqartDLL.connections.DaqumentStorageConnect(conn, "001")
        Try
            fs = New FileStream(runtime.AbsolutePath + "OutputFile00001.png", FileMode.Open, FileAccess.Read)
            FileSize = fs.Length
            rawData = New Byte(FileSize) {}
            fs.Read(rawData, 0, FileSize)
            fs.Close()
            'conn.Open()
            'Dim querystring As String = "insert into document_store(TS,DocumentID,DocumentImage) values ('" + Now() + "','" & CInt(DocID) & "',@File)"
            'cmd.Connection = conn
            'cmd.CommandText = querystring
            'cmd.Parameters.AddWithValue("@File", rawData)
            'cmd.ExecuteNonQuery()
            Dim sqlCabinetUtils As DataUtils = New DataUtils("Daqument001")
            sqlCabinetUtils.OpenConnection()
            Dim muid As String = idUtils.GetNextMUID("Daqument001", "document_store")
            Dim querystring As String = "insert into document_store(MUID, TS,DocumentMUID,DocumentImage" + _
            ") values ('" + muid + "','" + Now() + "','" + DocID + "',@File)"
            sqlCabinetUtils.ExecuteSingleParameterizedQuery(querystring, "@File", rawData)
            sqlCabinetUtils.CloseConnection()

            MessageBox.Show("File Inserted into database successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'conn.Close()

        Catch ex As Exception
            MessageBox.Show("There was an error: " & ex.Message, "Error", _
            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub updateDocumentImage()
        Dim FileSize As UInt32
        Dim rawData() As Byte
        Dim fs As FileStream

        Try
            fs = New FileStream(runtime.AbsolutePath + "OutputFile00001.png", FileMode.Open, FileAccess.Read)
            FileSize = fs.Length
            rawData = New Byte(FileSize) {}
            fs.Read(rawData, 0, FileSize)
            fs.Close()

            Dim querystring As String = "update document_store set TS='" + Now() + "',DocumentImage = @File  where DocumentMUID= '" + DocumentID + "' "
            Dim sqlCabinetUtils As DataUtils = New DataUtils("Daqument001")
            sqlCabinetUtils.OpenConnection()
            sqlCabinetUtils.ExecuteSingleParameterizedQuery(querystring, "@File", rawData)
            sqlCabinetUtils.CloseConnection()

            MessageBox.Show("File Inserted into database successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Catch ex As Exception
            MessageBox.Show("There was an error: " & ex.Message, "Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Upload.Click
        OpenFD.InitialDirectory = Directory.GetCurrentDirectory
        OpenFD.Title = "Open a File"
        OpenFD.FileName = ""
        OpenFD.ShowDialog()
        If (OpenFD.FileName <> "") Then
            pathstring = OpenFD.FileName
            tbx_FileName.Text = pathstring
            '            Me.WebBrowser1.Navigate(OpenFD.FileName)

            Dim thisImg As Image = Nothing
            ipw_Image.pbx_Image.Image = Nothing

            Try
                Dim TheFile As FileInfo = New FileInfo(runtime.AbsolutePath + "OutputFile00001.png")
                If TheFile.Exists Then
                    File.Delete(runtime.AbsolutePath + "OutputFile00001.png")
                Else
                    Throw New FileNotFoundException()
                End If

            Catch ex As FileNotFoundException
                'lblStatus.Text += ex.Message
            Catch ex As Exception
                'lblStatus.Text += ex.Message
            End Try


            ImgCon.ImgConvert(runtime.AbsolutePath, pathstring, tbx_Hdpi.Text, tbx_Vdpi.Text, Me.ckbx_Color.Checked)
            Dim fs As FileStream
            fs = New FileStream(runtime.AbsolutePath + "OutputFile00001.png", FileMode.Open, FileAccess.Read)
            thisImg = Image.FromStream(fs)


            fs.Dispose()

            ipw_Image.pbx_Image.Image = thisImg
            ipw_Image.ImageLoaded()

            load1 = True
            NewImage = True

        End If


    End Sub


    Private Sub btn_Reload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reload.Click
        ipw_Image.pbx_Image.Image = Nothing

        If Not tbx_FileName.Text = "" Then
            pathstring = tbx_FileName.Text
            'tbx_FileName.Text = pathstring

            Dim thisImg As Image = Nothing
            ipw_Image.pbx_Image.Image = Nothing

            Try
                Dim TheFile As FileInfo = New FileInfo(runtime.AbsolutePath + "OutputFile00001.png")
                If TheFile.Exists Then
                    File.Delete(runtime.AbsolutePath + "OutputFile00001.png")
                Else
                    Throw New FileNotFoundException()
                End If

            Catch ex As FileNotFoundException
                'lblStatus.Text += ex.Message
            Catch ex As Exception
                'lblStatus.Text += ex.Message
            End Try


            ImgCon.ImgConvert(runtime.AbsolutePath, pathstring, tbx_Hdpi.Text, tbx_Vdpi.Text, Me.ckbx_Color.Checked)
            Dim fs As FileStream
            fs = New FileStream(runtime.AbsolutePath + "OutputFile00001.png", FileMode.Open, FileAccess.Read)
            thisImg = Image.FromStream(fs)


            fs.Dispose()

            ipw_Image.pbx_Image.Image = thisImg
            ipw_Image.ImageLoaded()

            load1 = True
            NewImage = True
        End If


    End Sub



    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub CheckBlanks()

        Dim Blanks As Boolean = False

        If Me.txtClientCode.Text = "" Then Blanks = True
        If Me.txtDescription.Text = "" Then Blanks = True
        If Me.tbx_DocType.Text = "" Then Blanks = True
        If Me.txtEngCode.Text = "" Then Blanks = True
        If Me.txtLocation.Text = "" Then Blanks = True
        If Me.txtRevision.Text = "" Then Blanks = True
        If Me.txtSheet.Text = "" Then Blanks = True
        If Me.txtSheet.Text = "" Then Blanks = True
        If Me.txtSheetOf.Text = "" Then Blanks = True

        If Blanks Then
            Me.btnUpdate.Enabled = False
        Else
            Me.btnUpdate.Enabled = True
        End If

    End Sub

    Private Sub txtClientCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClientCode.TextChanged
        If Loading Then Return
        DocInfoModified = True
        CheckBlanks()
    End Sub

    Private Sub tbx_DocType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_DocType.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txtEngCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngCode.TextChanged
        If Loading Then Return
        DocInfoModified = True
        CheckBlanks()
    End Sub

    Private Sub txtSheet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSheet.TextChanged
        If Loading Then Return
        DocInfoModified = True
        CheckBlanks()
    End Sub

    Private Sub txtSheetOf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSheetOf.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txtRevision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRevision.TextChanged
        If Loading Then Return
        DocInfoModified = True
        CheckBlanks()
    End Sub

    Private Sub txtLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocation.TextChanged
        If Loading Then Return
        If runtime.SiteName = "BP001" Then
            DocInfoModified = True
        End If
        CheckBlanks()
    End Sub

    Private Sub txtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged
        CheckBlanks()
    End Sub

    Private Sub btn_DocType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DocType.Click
        Dim frm_Select As New DocumentTypeSelect
        frm_Select.ShowDialog()

        Me.tbx_DocType.Tag = frm_Select.SelectedType
        Me.tbx_DocType.Text = Utilities.GetDocumentType(frm_Select.SelectedType)

        frm_Select.Dispose()
    End Sub


    Public Function FormatRev(ByVal _rev As String) As String

        Dim HasLetter As Boolean = False
        For i As Integer = 0 To _rev.Length - 1
            If Char.IsLetter(_rev(i)) Then
                HasLetter = True
            End If
        Next

        If HasLetter Then
            For i As Integer = 0 To 3 - _rev.Length
                _rev = "0" + _rev
            Next
        Else
            _rev = _rev + "-"
            For i As Integer = 0 To 3 - _rev.Length
                _rev = "0" + _rev
            Next
        End If

        Return _rev

    End Function


    Public Function TranslateRev(ByVal _rev As String) As String

        For i As Integer = 0 To 1
            If _rev(0) = "0" Then
                _rev = _rev.Substring(1)
            End If
        Next

        _rev = _rev.Replace("-", "")

        Return _rev

    End Function

End Class
