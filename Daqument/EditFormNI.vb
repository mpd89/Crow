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
Public Class EditFormNI
    Dim load1 As Boolean
    Dim pathstring As String

    Public Sub DoConvert()
        Dim image As IMAGECONVERTERLib.ImageConverter
        Dim strOutput As String
        Dim strOutputFile As String = daqartDLL.runtime.AbsolutePath + "OutputFile"
        Dim result As Boolean
        image = New ImageConverterClass()
        image.SetLicenseNum("555-2213")
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

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OpenFD.InitialDirectory = "C:\"
        OpenFD.Title = "Open a File"
        OpenFD.FileName = ""
        OpenFD.ShowDialog()
        If (OpenFD.FileName <> "") Then
            pathstring = OpenFD.FileName
            Me.WebBrowser1.Navigate(OpenFD.FileName)
            load1 = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        adddocrecord()
    End Sub
    Public Sub adddocrecord()
        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        Dim query As String = "update documents  set " + _
        "EngCode=@EngCode," + _
        "ClientCode = @ClientCode," + _
        "Revision= @Revision," + _
        "Description=@Description," + _
        "Sheet=@Sheet," + _
        "Sheets=@Sheets," + _
        "ProjectMUID =@ProjectMUID," + _
        "Location=@Location," + _
        " WHERE MUID = @MUID"

        Dim dt_param As DataTable = sqlDocUtils.paramDT
        dt_param.Rows.Add("@EngCode", txtEngCode.Text)
        dt_param.Rows.Add("@ClientCode", txtClientCode.Text)
        dt_param.Rows.Add("@Revision", txtRevision.Text)
        dt_param.Rows.Add("@Description", txtDescription.Text)
        dt_param.Rows.Add("@Sheet", txtSheet.Text)
        dt_param.Rows.Add("@Sheets", txtSheetOf.Text)
        dt_param.Rows.Add("@ProjectMUID", cmbProject.SelectedValue.ToString)
        dt_param.Rows.Add("@Location", txtLocation.Text)
        dt_param.Rows.Add("@MUID", lblDID.Text)

        sqlDocUtils.OpenConnection()
        sqlDocUtils.ExecuteNonQuery(query, dt_param)
        sqlDocUtils.CloseConnection()


        If (load1) Then
            Dim docid As Integer
            docid = lblDID.Text 
            DoConvert()
            savein2(docid)
        End If
    End Sub
    Public Sub savein2(ByVal DocID As Integer)
        Dim conn As New SqlCeConnection
        Dim cmd As New SqlCeCommand
        Dim FileSize As UInt32
        Dim rawData() As Byte
        Dim fs As FileStream
        conn = daqartDLL.connections.DaqumentStorageConnect(conn, "001")
        Try
            fs = New FileStream(pathstring, FileMode.Open, FileAccess.Read)
            FileSize = fs.Length
            rawData = New Byte(FileSize) {}
            fs.Read(rawData, 0, FileSize)
            fs.Close()
            conn.Open()
            Dim querystring As String = "insert into document_store(TS,DocumentID,DocumentImage) values ('" + Now() + "','" & CInt(DocID) & "',@File)"
             cmd.Connection = conn
            cmd.CommandText = querystring
            cmd.Parameters.AddWithValue("@File", rawData)
            cmd.ExecuteNonQuery()
            MessageBox.Show("File Inserted into database successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("There was an error: " & ex.Message, "Error", _
            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    
End Class