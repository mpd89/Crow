Imports daqartDLL
Imports System.IO


Public Class AddEditSymbol
    Dim Mode As String = "Add"
    Dim fn As String


    Public Sub New(ByVal _Mode As String)
        InitializeComponent()

        Mode = _Mode
    End Sub


    Private Sub AddEditSymbol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Mode = "Edit" Then

        End If

    End Sub


    Private Sub btn_Upload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Upload.Click
        With OpenFileDialog1
            .Title = "Pick a file to upload..."
            .FileName = ""
            .InitialDirectory = Directory.GetCurrentDirectory
            .Filter = "(*.png)|*.png|(*.jpg)|*.jpg|(*.bmp)|*.bmp"
            .FilterIndex = 1
            .ShowDialog(Me)

            If .FileName <> "" Then
                fn = .FileName
                Dim img As Image = Image.FromFile(fn)
                Me.PictureBox1.Image = img
            End If
        End With
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        Try
            'check symbol name
            If TestName() Then
                MessageBox.Show("Symbol name already exists.")
                Return
            Else
                'save symbol to database
                saveSymbol()
            End If

            'make local file in symbols directory
            If Not Directory.Exists(runtime.AbsolutePath + "symbols\") Then
                Directory.CreateDirectory(runtime.AbsolutePath + "symbols\")
            End If

            Me.PictureBox1.Image.Save(runtime.AbsolutePath + "symbols\" + Me.tbx_Name.Text + ".png", System.Drawing.Imaging.ImageFormat.Png)
        Catch ex As Exception
            MessageBox.Show("Error creating local symbol file.")
        End Try

        Me.Dispose()
    End Sub


    Private Function TestName() As Boolean
        Try
            'Dim sqlUtils As DataUtils = New DataUtils("server")
            Dim muid As String = idUtils.GetNextMUID("server", "SystemImages")
            Dim query As String = "SELECT * FROM SystemImages WHERE Name='" + Me.tbx_Name.Text + "'"

            'sqlUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
            'sqlUtils.CloseConnection()

            If dt.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Utilities.logErrorMessage("AddEditSymbols.saveDocMUID-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Function


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_Name.TextChanged
        checkblanks()
    End Sub


    Private Sub checkblanks()
        If Me.tbx_Name.Text = "" Then
            Me.btn_Save.Enabled = False
        Else
            Me.btn_Save.Enabled = True
        End If
    End Sub


    Public Sub saveSymbol()
        Dim FileSize As UInt32
        Dim rawData() As Byte
        Dim fs As FileStream
        Try
            fs = New FileStream(fn, FileMode.Open, FileAccess.Read)
            FileSize = fs.Length
            rawData = New Byte(FileSize) {}
            fs.Read(rawData, 0, FileSize)
            fs.Close()
            'Dim sqlDocUtils As DataUtils = New DataUtils("server")
            Dim muid As String = idUtils.GetNextMUID("server", "SystemImages")
            Dim query As String = "INSERT INTO SystemImages(" + _
            "MUID, TS,Name,Code,DocumentImage) VALUES (" + _
            " '" + muid + "'," + _
            " '" + Now() + "'," + _
            " '" + Me.tbx_Name.Text + "'," + _
            " 'SYM'," + _
            " @File)"

            'sqlDocUtils.OpenConnection()
            runtime.SQLServer.ExecuteSingleParameterizedQuery(query, "@File", rawData)
            'sqlDocUtils.CloseConnection()
        Catch ex As Exception
            Utilities.logErrorMessage("AddEditSymbols.saveDocMUID-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub





End Class