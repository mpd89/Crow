Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports daqartDLL
Imports Print2eDocSDK
Imports Daqument


Public Class FormAdd

    Dim ImgCon As New Daqument.P2I


    Private Sub FormAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception

        End Try
    End Sub


    Private Sub buttonGetFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonGetFile.Click
        With OpenFileDialog1
            'The Caption
            .Title = "Pick a file to upload..."
            .FileName = ""
            'Ensure we only get back valid filenames
            .CheckFileExists() = True
            .CheckPathExists = True
            .ValidateNames = True
            .DereferenceLinks = True

            'Set the starting dir
            .InitialDirectory = Directory.GetCurrentDirectory
            .Filter = "PDF files (*.pdf)|*.pdf"
            .FilterIndex = 1

            'Show the Window
            .ShowDialog(Me)

            If .FileName <> "" Then
                formFile.Text = .FileName
                Dim fi As New IO.FileInfo(.FileName)
                If fi.Extension = ".pdf" Then
                    Dim dr As String = runtime.AbsolutePath + "sites\Forms\images\"
                    Dim fentries As String() = Directory.GetFiles(dr)
                    Dim fs As String
                    For Each fs In fentries
                        File.Delete(fs)
                    Next
                    ImgCon.ImgConvert(dr, formFile.Text, "100", "100", False)
                    fentries = Directory.GetFiles(dr)
                    If fentries.Length > 1 Then
                        If Me.cbx_MultiElement.Text = "Yes" Then
                            MessageBox.Show("Multiple pages are not supported for multi element forms")
                            fentries = Directory.GetFiles(dr)
                            For Each fs In fentries
                                File.Delete(fs)
                            Next
                            buttonOK.Enabled = False
                            .FileName = ""
                            formFile.Text = ""
                        End If
                    End If
                End If
            End If
        End With
    End Sub

 
    Public Function AddBaseFile(ByVal newFormID As String) As String
        Dim strBLOBFilePath As String = OpenFileDialog1.FileName
        Dim fsBLOBFile As New FileStream(strBLOBFilePath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fsBLOBFile)
        Dim chunk As Byte() = br.ReadBytes(fsBLOBFile.Length - 1)

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim muid = idUtils.GetNextMUID("project", "forms_storage")
        Dim qry As String = "INSERT INTO forms_storage (MUID,FormMUID,BaseImage) VALUES (" _
                + "'" + muid + "','" + newFormID.ToString + "',@BaseImage )"
        sqlPrjUtils.ExecuteSingleParameterizedQuery(qry, "@BaseImage", chunk)

        sqlPrjUtils.CloseConnection()
        Return muid
    End Function

    Public Function AddFormsImage(ByVal buffer As Array, ByVal PgNum As Integer, ByVal NewFormID As String) As String
        Dim muid = idUtils.GetNextMUID("project", "forms_image")
        Dim qry As String = "INSERT INTO forms_image (MUID,TS,FormMUID,FormImage,PageNumber) VALUES (" _
                    + "'" + muid + "','" + DateTime.Now.ToString + "','" + NewFormID.ToString + _
                    "',@FormImage" + "," + PgNum.ToString + ")"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        sqlPrjUtils.ExecuteSingleParameterizedQuery(qry, "@FormImage", buffer)
        Return muid
    End Function


    Private Function AddFile() As String
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Try
            Dim multiElement As Integer = 0
            If cbx_MultiElement.SelectedIndex = 1 Then
                multiElement = 1
            End If
            Dim systemForm As Integer = 0
            If Me.cbx_System.SelectedIndex = 1 Then
                systemForm = 1
            End If
            Dim newFormID As String = idUtils.GetNextMUID("project", "forms")
            Dim qry As String = "INSERT INTO forms(MUID, TS,Name,Description,NumberPages, " + _
                " MultiElement,NumberofElements,SystemForm) VALUES (" + _
            "@MUID,@TS,@Name," + _
            "@Description,@NumberPages," + _
            "@MultiElement,@NumberofElements,@SystemForm)"

            Dim dr As String = runtime.AbsolutePath + "sites\Forms\images\"
            Directory.GetFiles(dr)


            Dim dt_param As DataTable = sqlPrjUtils.paramDT
            dt_param.Rows.Add("@MUID", newFormID)
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@Name", formName.Text)
            dt_param.Rows.Add("@Description", formDescription.Text)
            dt_param.Rows.Add("@NumberPages", Directory.GetFiles(dr).Length.ToString)
            dt_param.Rows.Add("@MultiElement", multiElement.ToString)
            dt_param.Rows.Add("@NumberofElements", "0")
            dt_param.Rows.Add("@SystemForm", systemForm.ToString)

            sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
            If AddBaseFile(newFormID) = "" Then
                MessageBox.Show("Base file image could not be added")
                sqlPrjUtils.CloseConnection()
                Return 0
            End If
            OpenFormEdit(newFormID)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            sqlPrjUtils.CloseConnection()
            Return 0
        End Try
        sqlPrjUtils.CloseConnection()
        Return 1
    End Function


    Sub OnAbort(ByVal InputFileName As String, ByVal OutputFileName As String)
        '       PrinterObj.RestoreDefaultPrinter()
        Me.Dispose()
    End Sub


    Sub OpenFormEdit(ByVal newFormID As String)

        Dim dr As String = runtime.AbsolutePath + "sites\Forms\images\"
        Dim d As IO.DirectoryInfo = New IO.DirectoryInfo(dr)
        Dim enumerator As System.Collections.IEnumerator = CType(d.GetFiles("*.png"), System.Collections.IEnumerable).GetEnumerator
        Dim PageNum As Integer = 1
        Try

            Do While enumerator.MoveNext
                Dim f As IO.FileInfo = CType(enumerator.Current, IO.FileInfo)
                Dim buffer() As Byte = New Byte((f.OpenRead.Length) - 1) {}
                f.OpenRead.Read(buffer, 0, CType(f.OpenRead.Length, Integer))
                AddFormsImage(buffer, PageNum, newFormID)
                PageNum = PageNum + 1
            Loop
            FormEditManager.OpenForm(newFormID, formName.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Close()
    End Sub

    Private Sub buttonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonOK.Click
        AddFile()
    End Sub


    Private Sub formName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles formName.TextChanged
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim qry As String = "SELECT MUID FROM forms WHERE Name = '" + formName.Text + "'"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()
        If dt.Rows.Count > 0 Then
            MessageBox.Show("Name already in use")
            formName.Text = ""
        End If
        checkBlanks()
    End Sub
    Private Sub formDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles formDescription.TextChanged
        checkBlanks()
    End Sub
    Private Sub formFile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles formFile.TextChanged
        checkBlanks()
    End Sub
    Private Sub checkBlanks()
        Dim isEmpty As Boolean = True

        If (formName.Text <> "" And formDescription.Text <> "" And formFile.Text <> "") Then
            isEmpty = False
        End If

        If (isEmpty = False) Then
            buttonOK.Enabled = True
        Else
            buttonOK.Enabled = False
        End If


    End Sub


    Private Sub buttonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonCancel.Click
        Me.Dispose()
    End Sub



    Private Sub cbx_System_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_System.SelectedIndexChanged
        If Me.cbx_System.Text = "Yes" Then
            Me.cbx_MultiElement.SelectedIndex = 0
            Me.cbx_MultiElement.Enabled = False
        Else
            Me.cbx_MultiElement.Enabled = True
        End If
    End Sub


End Class
