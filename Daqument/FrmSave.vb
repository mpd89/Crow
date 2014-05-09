Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.SqlServerCe
Imports System.Threading
Imports IMAGECONVERTERLib
Imports System.IO
Imports System.Text
Imports daqartDLL

Imports System.Collections.Generic
'Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices


Public Class FrmSave
    Dim load1 As Boolean = False
    Dim pathstring As String
    Dim ImgCon As New P2I


    Private Sub FrmSave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If runtime.SiteName = "BP001" Then
                Me.lbl_Location.Text = "EPT#"
            End If

        Catch ex As Exception
            Utilities.logErrorMessage("Daqument.frmSave.frmSave_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

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



    Private Function CheckExisting() As Boolean
        Dim HasError As Boolean = False
        Dim conn As New SqlCeConnection
        Dim cmd As New SqlCeCommand
        Dim query As String

        conn = daqartDLL.connections.DaqumentConnect(conn)


        If conn Is Nothing Then
            conn.Open()
        End If
        Dim rev As String = Me.txtRevision.Text
        Dim revCode As String = Utilities.FormatRev(rev)

        query = "SELECT * FROM documents WHERE (ClientCode='" + Me.txtEngCode.Text + _
            "') AND Revision='" + revCode + _
            "' AND Sheet='" + Me.txtSheet.Text + "' AND ProjectMUID = '" + runtime.selectedProjectID + "'"

        If runtime.SiteName = "BP001" Then
            query = "SELECT * FROM documents WHERE (ClientCode='" + Me.txtEngCode.Text + _
                "') AND Revision='" + revCode + _
                "' AND Sheet='" + Me.txtSheet.Text + _
                "' AND ProjectMUID = '" + runtime.selectedProjectID + "'" + _
                "' AND Location = '" + Me.txtLocation.Text + "'"
        End If


        'Dim dt As New DataTable
        'dt = Utilities.ExecuteQuery(query, "Daqument")

        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        sqlDocUtils.OpenConnection()
        Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
        sqlDocUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            HasError = True
        End If

        Return HasError
    End Function



    Public Sub adddocrecord()
        Try
            If CheckBlanks() Then
                MessageBox.Show("Please fill-in blank entries")
                Return
            End If
            If CheckExisting() Then
                MessageBox.Show("Drawing already exist")
                Return
            End If

            Dim muid As String = idUtils.GetNextMUID("Daqument", "Documents")
            Dim query As String = "INSERT INTO documents( " + _
                "MUID, TS,EngCode,ClientCode,Revision,DateLoaded,Description," + _
                "Sheet,Sheets,Location,DocumentTypeMUID,ProjectMUID,DocumentPath) VALUES (" + _
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
            dt_param.Rows.Add("@EngCode", txtEngCode.Text)
            dt_param.Rows.Add("@ClientCode", txtClientCode.Text)
            dt_param.Rows.Add("@Revision", FormatRev(txtRevision.Text))
            dt_param.Rows.Add("@DateLoaded", Now())
            dt_param.Rows.Add("@Description", txtDescription.Text)
            dt_param.Rows.Add("@Sheet", txtSheet.Text)
            dt_param.Rows.Add("@Sheets", txtSheetOf.Text)
            dt_param.Rows.Add("@Location", txtLocation.Text)
            dt_param.Rows.Add("@DocumentTypeMUID", Me.tbx_DocType.Tag)
            dt_param.Rows.Add("@ProjectMUID", Utilities.GetProjectID(runtime.selectedProject))
            dt_param.Rows.Add("@DocumentPath", "001")

            sqlDocUtils.OpenConnection()
            sqlDocUtils.ExecuteNonQuery(query, dt_param)
            sqlDocUtils.CloseConnection()


            'Dim docid As Integer
            'docid = DocumentDataManager.GetDataRecord(rec.DocumentTS, rec.Revision, rec.Sheet)
            saveDocMUID(muid)
        Catch ex As Exception
            Utilities.logErrorMessage("DaqumentImport.addocrecord-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Public Sub adddocrecord()
    '    Dim rec As New DocumentData
    '    rec.DocumentTS = Now()
    '    rec.EngCode = txtEngCode.Text
    '    rec.ClientCode = txtClientCode.Text
    '    rec.Revision = FormatRev(txtRevision.Text)
    '    rec.DateLoaded = Now.Date
    '    rec.Description = txtDescription.Text
    '    rec.Sheet = txtSheet.Text
    '    rec.Sheets = txtSheetOf.Text
    '    rec.Location = txtLocation.Text
    '    rec.DocumenttypeID = Me.tbx_DocType.Tag
    '    rec.ProjectID = Utilities.GetProjectID(runtime.selectedProject)
    '    rec.DocumentPath = "001"
    '    DocumentDataManager.AddDataRecord(rec)

    '    If (load1) Then
    '        Dim docid As Integer
    '        docid = DocumentDataManager.GetDataRecord(rec.DocumentTS, rec.Revision, rec.Sheet)
    '        'MessageBox.Show(docid.ToString)
    '        'DoConvert()
    '        savein2(docid)
    '    Else
    '        MessageBox.Show("Document record has been saved without a document.")
    '    End If
    'End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If CheckExisting() Then
            MessageBox.Show("Drawing already exist")
            Return
        End If
        adddocrecord()
        Me.Dispose()
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
                Utilities.logErrorMessage("frmSave.btnBrowse_Click-" + ex.Message)
                MessageBox.Show(ex.Message)
                'lblStatus.Text += ex.Message
            End Try


            ImgCon.ImgConvert(runtime.AbsolutePath, pathstring, tbx_Hdpi.Text, tbx_Vdpi.Text, Me.ckbx_Color.Checked)
            Dim fs As FileStream
            fs = New FileStream(runtime.AbsolutePath + "OutputFile00001.png", FileMode.Open, FileAccess.Read)
            thisImg = Image.FromStream(fs)
            fs.Dispose()


            'resizeIMG(thisImg)
            'thisImg = New Bitmap(thisImg)
            'thisImg.Save(runtime.AbsolutePath + "OutputFile00001.png", System.Drawing.Imaging.ImageFormat.Png)

            ipw_Image.pbx_Image.Image = thisImg
            ipw_Image.ImageLoaded()

            load1 = True

            'Select Case thisImg.PixelFormat
            '    Case System.Drawing.Imaging.PixelFormat.Undefined, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, System.Drawing.Imaging.PixelFormat.Format4bppIndexed, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale, System.Drawing.Imaging.PixelFormat.Format16bppArgb1555

            '        ' Create a new BitMap object using original Image instance
            '        thisImg = New Bitmap(thisImg)
            '        Exit Select
            'End Select

            'pbx_Image.Image = thisImg


        End If


    End Sub


    Private Sub resizeIMG(byval thisIMG as Image)
        'following code resizes picture to fit

        Dim bm As New Bitmap(thisIMG)
        Dim x As Int32 'variable for new width size
        Dim y As Int32 'variable for new height size

        Dim width As Integer = thisIMG.Width / 3 'image width. 
        Dim height As Integer = thisIMG.Height / 3 'image height

        Dim thumb As New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(thumb)

        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

        g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, _
            bm.Height), GraphicsUnit.Pixel)

        Dim indexedBM As New Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format4bppIndexed)
        indexedBM = thumb


        g.Dispose()


        ' Convert image to bitonal for saving to file
        'Dim bitonalBitmap As Bitmap = ConvertToBitonal(thumb)

        ' Display converted image
        'convertedImage.Image = bitonalBitmap

        ' Get an ImageCodecInfo object that represents the TIFF codec.
        Dim imageCodecInfo As ImageCodecInfo = GetEncoderInfo("image/png")
        Dim encoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Compression
        Dim encoderParameters As New EncoderParameters(1)

        ' Save the bitmap as a TIFF file with group IV compression.
        Dim encoderParameter As New EncoderParameter(encoder, Fix(EncoderValue.CompressionLZW))
        encoderParameters.Param(0) = encoderParameter
        indexedBM.Save("c:\Daqart\Bitonal-Out.png")
        'thumb.Save("c:\Daqart\Bitonal-Out.png", imageCodecInfo, encoderParameters)


        'image path. better to make this dynamic. I am hardcoding a path just for example sake
        'thumb.Save("C:\Daqart\test1.png", _
        '    System.Drawing.Imaging.ImageFormat.Png) 'can use any image format 


        bm.Dispose()

        thumb.Dispose()

        'Me.Close()  'exit app
    End Sub


    Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length - 1
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
        Next
        Return Nothing
    End Function


    Public Shared Function ConvertToRGB(ByVal original As Bitmap) As Bitmap
        Dim newImage As New Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb)
        newImage.SetResolution(original.HorizontalResolution, original.VerticalResolution)
        Dim g As Graphics = Graphics.FromImage(newImage)
        g.DrawImageUnscaled(original, 0, 0)
        g.Dispose()
        Return newImage
    End Function


    Public Shared Function ConvertToBitonal(ByVal original As Bitmap) As Bitmap
        Dim source As Bitmap = Nothing

        ' If original bitmap is not already in 32 BPP, ARGB format, then convert
        If original.PixelFormat <> PixelFormat.Format32bppArgb Then
            source = New Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb)
            source.SetResolution(original.HorizontalResolution, original.VerticalResolution)
            Using g As Graphics = Graphics.FromImage(source)
                g.DrawImageUnscaled(original, 0, 0)
            End Using
        Else
            source = original
        End If

        ' Lock source bitmap in memory
        Dim sourceData As BitmapData = source.LockBits(New Rectangle(0, 0, source.Width, source.Height), ImageLockMode.[ReadOnly], PixelFormat.Format32bppArgb)

        ' Copy image data to binary array
        Dim imageSize As Integer = sourceData.Stride * sourceData.Height
        Dim sourceBuffer As Byte() = New Byte(imageSize - 1) {}
        Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, imageSize)

        ' Unlock source bitmap
        source.UnlockBits(sourceData)

        ' Create destination bitmap
        Dim destination As New Bitmap(source.Width, source.Height, PixelFormat.Format1bppIndexed)

        ' Lock destination bitmap in memory
        Dim destinationData As BitmapData = destination.LockBits(New Rectangle(0, 0, destination.Width, destination.Height), ImageLockMode.[WriteOnly], PixelFormat.Format1bppIndexed)

        ' Create destination buffer
        imageSize = destinationData.Stride * destinationData.Height
        Dim destinationBuffer As Byte() = New Byte(imageSize - 1) {}

        Dim sourceIndex As Int64 = 0
        Dim destinationIndex As Int64 = 0
        Dim pixelTotal As Int64 = 0
        Dim destinationValue As Byte = 0
        Dim pixelValue As Integer = 128
        Dim height As Integer = source.Height
        Dim width As Integer = source.Width
        Dim threshold As Integer = 500
        For y As Integer = 0 To height - 1

            ' Iterate lines
            sourceIndex = y * sourceData.Stride
            destinationIndex = y * destinationData.Stride
            destinationValue = 0
            pixelValue = 128
            For x As Integer = 0 To width - 1

                ' Iterate pixels
                ' Compute pixel brightness (i.e. total of Red, Green, and Blue values)
                pixelTotal = sourceBuffer(sourceIndex + 1) + sourceBuffer(sourceIndex + 2) + sourceBuffer(sourceIndex + 3)
                If pixelTotal > threshold Then
                    destinationValue += CByte(pixelValue)
                End If
                If pixelValue = 1 Then
                    destinationBuffer(destinationIndex) = destinationValue
                    destinationIndex += 1
                    destinationValue = 0
                    pixelValue = 128
                Else
                    pixelValue >>= 1
                End If
                sourceIndex += 4
            Next
            If pixelValue <> 128 Then
                destinationBuffer(destinationIndex) = destinationValue
            End If
        Next

        ' Copy binary image data to destination bitmap
        Marshal.Copy(destinationBuffer, 0, destinationData.Scan0, imageSize)

        ' Unlock destination bitmap
        destination.UnlockBits(destinationData)

        ' Dispose of source if not originally supplied bitmap
        'If Not source > original Then
        '    source.Dispose()
        'End If

        ' Return
        Return destination
    End Function


    Public Sub DoConvert()
        Dim image As IMAGECONVERTERLib.ImageConverter
        Dim strOutput As String
        Dim strOutputFile As String = daqartDLL.runtime.AbsolutePath + "OutputFile"
        Dim result As Boolean
        image = New ImageConverterClass()
        image.SetLicenseNum("555-2213")
        image.SetDPI(200, 200)
        image.ReadImage(pathstring)
        strOutput = "png"
        strOutputFile = strOutputFile + "." + strOutput
        result = image.ConvertTo(strOutputFile, strOutput)
        If (result) Then
            pathstring = strOutputFile
        Else
            MessageBox.Show("Failed to save")
        End If
        image = Nothing
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
            Dim query As String = "INSERT INTO document_store(" + _
            "MUID, TS,DocumentMUID,DocumentImage) VALUES (" + _
            " '" + muid + "'," + _
            " '" + Now() + "'," + _
            " '" + DocID + "'," + _
            " @File)"

            sqlDocUtils.OpenConnection()
            sqlDocUtils.ExecuteSingleParameterizedQuery(query, "@File", rawData)
            sqlDocUtils.CloseConnection()
        Catch ex As Exception
            Utilities.logErrorMessage("DaqumentImport.savein2-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    'Public Sub savein2(ByVal DocID As Integer)
    '    Dim conn As New SqlCeConnection
    '    Dim cmd As New SqlCeCommand
    '    Dim FileSize As UInt32
    '    Dim rawData() As Byte
    '    Dim fs As FileStream
    '    conn = daqartDLL.connections.DaqumentStorageConnect(conn, "001")
    '    Try
    '        fs = New FileStream(runtime.AbsolutePath + "OutputFile00001.png", FileMode.Open, FileAccess.Read)
    '        FileSize = fs.Length
    '        rawData = New Byte(FileSize) {}
    '        fs.Read(rawData, 0, FileSize)
    '        fs.Close()
    '        conn.Open()
    '        Dim querystring As String = "insert into document_store(TS,DocumentID,DocumentImage) values ('" + Now() + "','" & CInt(DocID) & "',@File)"
    '        cmd.Connection = conn
    '        cmd.CommandText = querystring
    '        cmd.Parameters.AddWithValue("@File", rawData)
    '        cmd.ExecuteNonQuery()
    '        MessageBox.Show("File Inserted into database successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '        conn.Close()
    '    Catch ex As Exception
    '        MessageBox.Show("There was an error: " & ex.Message, "Error", _
    '        MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
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
        End If


    End Sub


    Private Sub btn_DocType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DocType.Click
        Dim frm_Select As New DocumentTypeSelect
        frm_Select.ShowDialog()

        Me.tbx_DocType.Tag = frm_Select.SelectedType
        Me.tbx_DocType.Text = Utilities.GetDocumentType(frm_Select.SelectedType)

        frm_Select.Dispose()
    End Sub


    Private Function CheckBlanks()

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
            Me.btnSave.Enabled = False
            Return True
        Else
            Me.btnSave.Enabled = True
            Return False
        End If

    End Function

    Private Sub txtClientCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClientCode.TextChanged
        CheckBlanks()
    End Sub

    Private Sub tbx_DocType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_DocType.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txtEngCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngCode.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txtSheet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSheet.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txtSheetOf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSheetOf.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txtRevision_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRevision.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txtLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocation.TextChanged
        CheckBlanks()
    End Sub

    Private Sub txtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged
        CheckBlanks()
    End Sub
End Class