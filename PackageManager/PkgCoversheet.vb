Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.FileIO
Imports daqartDLL
Imports Print2eDocSDK


Public Class PkgCoversheet
    Public Shared rtfCode As String = Nothing
    Public Shared rawData() As Byte
    Public Shared rawImage() As Byte
    Dim connSQLServer As SqlConnection = daqartDLL.connections.serverRemoteConnect(connSQLServer)
    '    Private conn As SqlCeConnection
    Private PrintingStarted As Integer
    Private selectedProject As String
    Private newFormID As Integer
    Private Sub buttonGetFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonGetFile.Click
        With OpenFileDialog1
            'The Caption
            .Title = "Pick a file to upload..."

            'Ensure we only get back valid filenames
            .CheckFileExists() = True
            .CheckPathExists = True
            .ValidateNames = True
            .DereferenceLinks = True

            'Set the starting dir
            .InitialDirectory = "c:\"

            'Show the Window
            .ShowDialog(Me)

            If .FileName <> "" Then
                formFile.Text = .FileName
            End If
        End With
    End Sub

    Public Function AddBaseFile() As Integer
        Dim newID As Int32 = 0
        Dim strBLOBFilePath As String = OpenFileDialog1.FileName
        Dim fsBLOBFile As New FileStream(strBLOBFilePath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fsBLOBFile)
        Dim chunk As Byte() = br.ReadBytes(fsBLOBFile.Length - 1)

        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        Dim muid As String = idUtils.GetNextMUID("project", "forms_storage")
        cmd.CommandText = selectedProject + "INSERT INTO forms_storage (FormMUID,BaseImage) VALUES " _
                & "(@MUID, @FormID,@BaseImage)"
        cmd.Parameters.Add("@MUID", SqlDbType.VarChar)
        cmd.Parameters("@MUID").Value = muid.ToString
        cmd.Parameters.Add("@FormID", SqlDbType.VarChar)
        cmd.Parameters("@FormID").Value = newFormID.ToString
        cmd.Parameters.Add("@BaseImage", SqlDbType.VarBinary)
        cmd.Parameters("@BaseImage").Value = chunk
        Return muid
    End Function
    Public Function AddFormsImage(ByVal buffer As Array, ByVal PgNum As Integer) As Integer
        Dim newID As Int32 = 0
        Dim cmd As SqlCommand = connSQLServer.CreateCommand()
        Dim muid As String = idUtils.GetNextMUID("project", "forms_image")
        cmd.CommandText = "INSERT INTO forms_image (MUID,TS,FormMUID,FormImage,PageNumber) VALUES " _
                    & "(@TS,@FormMUID,@FormImage,@PageNumber));"
        cmd.Parameters.Add("@MUID", SqlDbType.VarChar)
        cmd.Parameters("@MUID").Value = muid.ToString
        cmd.Parameters.Add("@TS", SqlDbType.DateTime)
        cmd.Parameters("@TS").Value = DateTime.Now
        cmd.Parameters.Add("@FormMUID", SqlDbType.VarChar)
        cmd.Parameters("@FormMUID").Value = newFormID.ToString
        cmd.Parameters.Add("@FormImage", SqlDbType.VarBinary)
        cmd.Parameters("@FormImage").Value = buffer
        cmd.Parameters.Add("@PageNumber", SqlDbType.Int)
        cmd.Parameters("@PageNumber").Value = PgNum.ToString
        If newID = 0 Then
            MessageBox.Show("Error#2010: Can not add Base File to Database")
            Return 1
        End If
        Return muid
    End Function

    Private Function AddFile() As Integer

        Dim dr As String = runtime.AbsolutePath + "sites\Forms\"
        Dim d As IO.DirectoryInfo = New IO.DirectoryInfo(dr)
        Dim enumerator As System.Collections.IEnumerator = CType(d.GetFiles("*.jpg"), System.Collections.IEnumerable).GetEnumerator
        Dim PageNum As Integer = 1

        Try
            Do While enumerator.MoveNext
                PageNum = PageNum + 1
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        newFormID = 0
        Try
            Dim cmd As SqlCommand = connSQLServer.CreateCommand()
            cmd.CommandText = selectedProject + "SELECT MUID FROM forms WHERE Name = 'Coversheet'"
            newFormID = Convert.ToString(cmd.ExecuteScalar())
            If newFormID Then
                MessageBox.Show("Name already in use")
                cmd.Dispose()
                Return False
            End If
            newFormID = idUtils.GetNextMUID("project", "forms")
            cmd.CommandText = selectedProject + _
             "INSERT INTO forms(MUID,TS,Name,Description,NumberPages) VALUES (@MUID, @TS,@Name,@Description,@NumberPages)"
            cmd.Parameters.Add("@MUID", SqlDbType.VarChar)
            cmd.Parameters("@MUID").Value = newFormID.ToString
            cmd.Parameters.Add("@TS", SqlDbType.DateTime)
            cmd.Parameters("@TS").Value = DateTime.Now
            cmd.Parameters.Add("@Name", SqlDbType.VarChar)
            cmd.Parameters("@Name").Value = "CoverSheet"
            cmd.Parameters.Add("@Description", SqlDbType.VarChar)
            cmd.Parameters("@Description").Value = "Coversheet"
            cmd.Parameters.Add("@NumberPages", SqlDbType.Int)
            cmd.Parameters("@NumberPages").Value = PageNum
            newFormID = Convert.ToInt32(cmd.ExecuteScalar())
            If AddBaseFile() = 0 Then
                Return 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return 0
        End Try
        Return newFormID
    End Function


    Sub OnAbort(ByVal InputFileName As String, ByVal OutputFileName As String)
        '       PrinterObj.RestoreDefaultPrinter()
        Me.Dispose()
    End Sub


    Function MakeImages() As Boolean
        Dim PrinterObj As New gtPrint2eDoc
        PrinterObj.ActivateLicense("7754735264486B507755624C3664306261337A4573746E51")

        ' Performs SDK license registration
        'PrinterObj.ActivateLicense("7754735264486B507755624C3664306261337A4573746E51")

        ' Performs PPrint2eDoc application license registration
        PrinterObj.RegisterPrint2eDocApplication("61526E53624668587857674F44654E542F4A3034324B3337")


        AddHandler PrinterObj.OnEndDoc, AddressOf OnEndDoc
        AddHandler PrinterObj.OnAbort, AddressOf OnAbort

        Try
            PrintingStarted = 0
            'Specify general settings
            Dim dr As String = runtime.AbsolutePath + "sites\Forms\images\"
            Dim fentries As String() = Directory.GetFiles(dr)
            Dim fs As String
            For Each fs In fentries
                File.Delete(fs)
            Next


            With PrinterObj
                .ShowPreview = False
                .ShowSaveDialog = False
                .ShowSettingsDialog = False
                .ViewGeneratedDocuments = False
                .UseCustomDocumentName = True
                .DefaultOutputDirectory = dr
                .OutputDocumentName = "Output"
                .OutputDocumentFormat = TxgtDocumentFormat.JPEG
            End With


            'Convert the document
            'PrinterObj.SetAsDefaultPrinter()
            '           PrinterObj.SourceApplication = TxgtSourceApplication.MSWord
            Me.Refresh()
            PrinterObj.PrintWordDocument(OpenFileDialog1.FileName)
            '            PrinterObj.PrintDocument(OpenFileDialog1.FileName)
            Me.Refresh()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return False

    End Function
    Sub OnEndDoc(ByVal InputFileName As String, ByVal OutputFileName As String)

        Dim dr As String = runtime.AbsolutePath + "sites\Forms\images\"
        Dim d As IO.DirectoryInfo = New IO.DirectoryInfo(dr)
        Dim enumerator As System.Collections.IEnumerator = CType(d.GetFiles("*.jpg"), System.Collections.IEnumerable).GetEnumerator
        Dim PageNum As Integer = 1
        Try

            Do While enumerator.MoveNext
                Dim f As IO.FileInfo = CType(enumerator.Current, IO.FileInfo)
                Dim buffer() As Byte = New Byte((f.OpenRead.Length) - 1) {}
                f.OpenRead.Read(buffer, 0, CType(f.OpenRead.Length, Integer))
                AddFormsImage(buffer, PageNum)
                PageNum = PageNum + 1
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Coversheet has been uploaded")
        Me.Close()
    End Sub

    Private Sub buttonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonOK.Click
        If AddFile() = 0 Then Return
        If Not MakeImages() Then Return
        Utilities.SyncProjectDB(runtime.selectedProject)

        'OnEndDoc(formFile.Text, formFile.Text)

        'Dim CreateForm1 As New FormDesignerMain(formName.Text)
        'CreateForm1.BringToFront()
        '        CreateForm1.ShowDialog()
        'Me.Dispose()
    End Sub




    Private Sub FormAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If runtime.ConnectionMode = "OFFLINE" Then
                MessageBox.Show("You must be online connected to the Server before a Cover sheet could be added")
                Me.Close()
            End If
            selectedProject = "USE [" + runtime.selectedProject + "] "
            connSQLServer.Open()
        Catch ex As Exception
            Utilities.logErrorMessage("PkgCoversheet.ForamAdd_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub buttonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonCancel.Click
        Me.Close()
    End Sub

    Private Sub formFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles formFile.TextChanged
        buttonOK.Enabled = True
    End Sub
End Class