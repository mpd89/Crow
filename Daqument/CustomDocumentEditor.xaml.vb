Imports System.Windows.Media.Imaging
Imports System.Windows.Ink
Imports System.IO
Imports System

Imports System.Windows
Imports System.Data.SqlServerCe
Imports System.Data.SqlClient
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Input
Imports System.Windows.Media

Public Class UserControl3
    Dim SqlAzureServerConnectionString As String = "Server=tcp:bn8kt4cffz.database.windows.net,1433;Database=Document;User ID=udel_sa@bn8kt4cffz;Password=Al@ska2014;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"

    Dim SqlAzureServerConn As SqlConnection = New SqlConnection(SqlAzureServerConnectionString)



    Dim inkCanvas1 As InkCanvas
    ' Dim imageView As System.Windows.Controls.Image = Me.imageViewer1
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Debug.Print("new called")
        inkCanvas1 = Me.inkCanvas
        inkCanvas1.EditingMode = InkCanvasEditingMode.Ink

    End Sub




    Public Function getImageView()



        Return Me.imageViewer1
    End Function

    Public Sub setBitmap(ByVal bm As BitmapImage)
        Me.imageViewer1.Source = bm

    End Sub

    Private Sub Button_Click(sender As Object, e As Windows.RoutedEventArgs)
        inkCanvas1 = Me.inkCanvas

        inkCanvas1.EditingMode = InkCanvasEditingMode.Ink

        ' Set the DefaultDrawingAttributes for a highlighter pen.
        inkCanvas1.DefaultDrawingAttributes.Color = Colors.Yellow
        inkCanvas1.DefaultDrawingAttributes.IsHighlighter = True
        inkCanvas1.DefaultDrawingAttributes.Height = 25
    End Sub

    Private Sub Pen_Click(sender As Object, e As RoutedEventArgs)
        inkCanvas1 = Me.inkCanvas

        inkCanvas1.EditingMode = InkCanvasEditingMode.Ink
        inkCanvas1.DefaultDrawingAttributes.Color = Colors.Black
        inkCanvas1.DefaultDrawingAttributes.IsHighlighter = False
        inkCanvas1.DefaultDrawingAttributes.Width = 2.0
        inkCanvas1.DefaultDrawingAttributes.Height = 2.0
    End Sub

    Private Sub Eraser_Click(sender As Object, e As RoutedEventArgs)
        inkCanvas1.EditingMode = InkCanvasEditingMode.EraseByStroke
    End Sub

    Private Sub Select_Click(sender As Object, e As RoutedEventArgs)

        inkCanvas1.EditingMode = InkCanvasEditingMode.Select
    End Sub

    Private Sub Save_Click(sender As Object, e As RoutedEventArgs)

        '    Dim saveFileDialog1 As New SaveFileDialog()
        '    saveFileDialog1.Filter = "isf files (*.isf)|*.isf"

        '   If saveFileDialog1.ShowDialog() Then
        'Dim fs As New FileStream(saveFileDialog1.FileName, FileMode.Create)
        '  inkCanvas1.Strokes.Save(fs)
        ' fs.Close()
        ' End If

        ''Save to database 


        Dim strokes() As Byte

        Using ms As New MemoryStream

            inkCanvas1.Strokes.Save(ms)
            strokes = ms.ToArray()

        End Using

        ''Database connect

        Dim serverQuery As String = "INSERT INTO Document_Strokes (ID, DocumentId, userID, Strokes) VALUES ('4', '7', 'Daryl', @Strokes)"
        ' Dim serverQuery As String = My.Resources.Resource3.createCloudServerDBTables.ToString
        Dim serverCommand As New SqlClient.SqlCommand(serverQuery, SqlAzureServerConn)
        serverCommand.CommandType = CommandType.Text
        serverCommand.Parameters.AddWithValue("@Strokes", strokes)
        Try
            SqlAzureServerConn.Open()
            serverCommand.ExecuteNonQuery()

            Debug.Print("server tables created.")

        Catch ex As Exception
            MessageBox.Show("Sql exception in stroke upload:  please contact administrator")
            Debug.Print("error in createserverprojecttables" + ex.Message)
        End Try

        SqlAzureServerConn.Close()
    End Sub

    Private Sub Load_Click(sender As Object, e As RoutedEventArgs)
       


        Dim loadQuery As String = "SELECT Strokes FROM Document_Strokes WHERE DocumentId = '7' AND userID = 'James' "
        Dim loadCommand As New SqlClient.SqlCommand(loadQuery, SqlAzureServerConn)
        Dim strokesToLoad As Byte()
        Try

            SqlAzureServerConn.Open()
        strokesToLoad = loadCommand.ExecuteScalar


        Using ms As New MemoryStream(strokesToLoad)
            inkCanvas1.Strokes = New StrokeCollection(ms)
        End Using

        Catch ex As Exception

        End Try

        SqlAzureServerConn.Close()

    End Sub

    Private Sub Users_Click(sender As Object, e As RoutedEventArgs)
        Dim loadQuery As String = "SELECT * FROM Document_Strokes WHERE DocumentId = '7' "
        Dim loadCommand As New SqlClient.SqlCommand(loadQuery, SqlAzureServerConn)
        ' Dim cmd As New SqlClient.SqlCommand(query, connSQL)
        loadCommand.CommandType = CommandType.Text
        Dim dt As New DataTable
        Try

        

            SqlAzureServerConn.Open()
            Dim myAdapter As SqlDataAdapter = New SqlDataAdapter(loadQuery, SqlAzureServerConn)
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture
            myAdapter.Fill(dt)
            loadCommand.Dispose()

        Catch ex As Exception

        End Try

        If (dt.Rows.Count > 0) Then
            Dim listBox As ListBox
            listBox = Me.listBox1

            For i As Integer = 0 To dt.Rows.Count - 1
                listBox.Items.Add("User:" + dt.Rows(i)(2))

            Next

        End If
    End Sub
End Class
