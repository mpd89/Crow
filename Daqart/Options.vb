Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.SqlServerCe
Imports System.Threading
Imports System.IO
Imports System.Text
Imports daqartDLL

Public Class Options

    Dim logoPath = runtime.AbsolutePath + "sites\images\logo128.jpg"
    
    Private Sub btn_Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Load.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "PNG files (*.png)|*.png"
        openFileDialog1.FilterIndex = 1

        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SaveImage(openFileDialog1.FileName)

        Else
            Return
        End If


    End Sub


    Public Sub SaveImage(ByVal ImagePath As String)

        Dim conn As New SqlCeConnection
        Dim cmd As New SqlCeCommand
        Dim FileSize As UInt32
        Dim rawData() As Byte
        Dim fs As FileStream
        Dim query As String
        Dim dt As New DataTable

        conn = daqartDLL.connections.projectDBConnect(conn)
        Try
            Dim newImg As System.Drawing.Image = Image.FromFile(ImagePath)
            Dim bm As New Bitmap(128, 128)
            Dim g As Graphics = Graphics.FromImage(bm)
            Dim myBrush As Brush = New SolidBrush(Color.White)
            Dim rect As Rectangle = New Rectangle(0, 0, 128, 128)
            g.FillRectangle(myBrush, rect)
            g.DrawImage(newImg, rect)
            bm.Save(logoPath, System.Drawing.Imaging.ImageFormat.Jpeg)
            bm.Dispose()

            fs = New FileStream(logoPath, FileMode.Open, FileAccess.Read)
            FileSize = fs.Length
            rawData = New Byte(FileSize) {}
            fs.Read(rawData, 0, FileSize)
            fs.Close()


            query = "SELECT * FROM  ProjectImages WHERE  Name = 'Logo128'"
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            dt = sqlPrjUtils.ExecuteQuery(query)
            sqlPrjUtils.CloseConnection()

            conn.Open()
            If dt.Rows.Count = 0 Then
                query = "insert into ProjectImages(MUID,TS,Name,DocumentImage) values ('" + idUtils.GetNextMUID("project", "ProjectImages") + "','" + Now() + "','Logo128',@file)"
                cmd.Connection = conn
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@File", rawData)
                cmd.ExecuteNonQuery()
                MessageBox.Show("File Inserted into database successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                query = "UPDATE ProjectImages SET TS='" + Now() + "',DocumentImage = @file WHERE Name = 'Logo128'"
                cmd.Connection = conn
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@File", rawData)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Image updated successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("There was an error: " & ex.Message, "Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        LoadLogo128()
    End Sub

    Private Sub LoadLogo128()
        Try
            Dim fs As FileStream = New FileStream(logoPath, FileMode.Open, FileAccess.Read)
            pbx_Logo128.Image = System.Drawing.Image.FromStream(fs).Clone
            fs.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try


    End Sub

    Private Sub TabPage3_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Enter
        LoadLogo128()
    End Sub


End Class