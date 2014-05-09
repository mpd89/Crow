Imports System.Drawing
'Imports System.Drawing.Imaging
'Imports System.Drawing.Printing
Imports System.IO
Imports System.Data.SqlClient
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Layout
Imports DevExpress.XtraPrinting
Public Class DataGridViews
    Private ModuleName As String
    Private ModuleFileName As String
    Private DataGridName As String
    Private ViewDT As DataTable
    Private ViewContents As Byte()
    Private myHeading As String
    Public fixedColumns As New List(Of String)
    Private useProjectDB As String = "USE [" + runtime.selectedProject + "] "
    Public WithEvents DGC As DevExpress.XtraGrid.GridControl
    'Private ms As New System.IO.MemoryStream()

    Public Sub SetSelectedFixedColumns()
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = DGC.MainView
        For i As Integer = 0 To View.Columns.Count - 1
            Dim fix As Boolean = False
            For Each s As String In fixedColumns
                If s = View.Columns(i).Caption Then
                    fix = True
                    Exit For
                End If
            Next
            If fix Then
                View.Columns(i).OptionsColumn.FixedWidth = True
                View.Columns(i).Fixed = Columns.FixedStyle.Left
            Else
                View.Columns(i).OptionsColumn.FixedWidth = True
                View.Columns(i).Fixed = Columns.FixedStyle.None
            End If
        Next
        DGC.Refresh()
    End Sub

    Private Sub SaveNewView(ByVal myViewName As String)
        Dim connRemote As SqlClient.SqlConnection = Nothing
        connRemote = daqartDLL.connections.serverRemoteConnect(connRemote)
        connRemote.Open()
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = DGC.DefaultView
        Dim ms As New System.IO.MemoryStream()
        ms.Seek(0, SeekOrigin.Begin)
        pv.SaveLayoutToStream(ms)
        ms.Seek(0, SeekOrigin.Begin)
        Dim buffer() As Byte = ms.GetBuffer
        'ReDim buffer(ms.Length)
        'ms.Read(buffer, 0, ms.Length - 1)
        'Dim buf() As Byte = ms.GetBuffer


        Dim qry = useProjectDB + "INSERT INTO DatagridViews (ModuleName," + _
            " ModuleFileName, DataGridName, ViewName) VALUES (" + _
            "'" + ModuleName + "','" + ModuleFileName + _
            "','" + DataGridName + "','" + myViewName + "')"

        'Dim bb() As Byte
        'ms.Read(bb, 0, ms.Length - 1)

        Dim cmd1 As SqlCommand = New SqlClient.SqlCommand(qry, connRemote)

        cmd1.CommandType = CommandType.Text
        cmd1.ExecuteNonQuery()
        Dim cmd2 As SqlCommand = New SqlClient.SqlCommand(" select @@identity ", connRemote)
        cmd2.CommandType = CommandType.Text
        Dim newID = cmd2.ExecuteScalar()
        If Not IsDBNull(newID) Then
            newID = Convert.ToInt32(newID)
        Else
            newID = 0
        End If
        If newID = 0 Then
            'Utilities.logErrorMessage("DataGridViews.SaveNewView()...Can not save Custom View")
            Return
        End If
        qry = useProjectDB + " UPDATE DatagridViews SET ViewContents = @ViewContents " + _
                    " WHERE ID = " + newID.ToString
        Dim value As Integer = 0
        Dim cmd3 As SqlCommand = New SqlClient.SqlCommand(qry, connRemote)

        cmd3.CommandType = CommandType.Text
        Try
            cmd3.Parameters.AddWithValue("@ViewContents", buffer)
            cmd3.ExecuteNonQuery()
            connRemote.Close()
        Catch ex As Exception

        End Try
        GetDataBaseViews()
    End Sub
    Private Sub UpdateThisView(ByVal myViewName As String)
        Dim viewPresent As Boolean = False
        For i As Integer = 0 To ViewDT.Rows.Count - 1
            If ViewDT.Rows(i)("ViewName") = myViewName Then
                viewPresent = True
            End If
        Next
        If Not viewPresent Then
            'MessageBox.Show("Invalid View Name")
            Return
        End If
        Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = DGC.DefaultView
        Dim ms As New System.IO.MemoryStream()
        ms.Seek(0, SeekOrigin.Begin)
        pv.SaveLayoutToStream(ms)
        ms.Seek(0, SeekOrigin.Begin)
        Dim buffer() As Byte = ms.GetBuffer
        Dim qry = useProjectDB + " UPDATE DatagridViews SET ViewContents = @ViewContents " + _
            " WHERE ModuleName ='" + ModuleName + _
            "' AND ModuleFileName = '" + ModuleFileName + _
            "' AND DataGridName = '" + DataGridName + _
            "' AND ViewName = '" + myViewName + "'"
        Dim connRemote As SqlClient.SqlConnection = Nothing
        connRemote = daqartDLL.connections.serverRemoteConnect(connRemote)
        connRemote.Open()
        Dim value As Integer = 0
        Dim myCommand As New SqlClient.SqlCommand
        myCommand = New SqlClient.SqlCommand(qry, connRemote)
        myCommand.CommandType = CommandType.Text
        myCommand.Parameters.AddWithValue("@ViewContents", buffer)
        myCommand.ExecuteNonQuery()
        connRemote.Close()
        GetDataBaseViews()
    End Sub
    Private Sub GetDataBaseViews()
        If Not ViewDT Is Nothing Then
            ViewDT.Dispose()
        End If
        ViewDT = New DataTable
        Dim qry As String = useProjectDB + " SELECT ViewName, ViewContents FROM DataGridViews " + _
                                " WHERE ModuleName = '" + ModuleName + _
                                "' AND ModuleFileName = '" + ModuleFileName + _
                                "' AND DataGridName = '" + DataGridName + "'"
        Dim connRemote As SqlClient.SqlConnection = Nothing
        connRemote = daqartDLL.connections.serverRemoteConnect(connRemote)
        connRemote.Open()
        Try
            Dim myAdapter As SqlDataAdapter = New SqlDataAdapter(qry, connRemote)
            ViewDT.Locale = System.Globalization.CultureInfo.InvariantCulture
            myAdapter.Fill(ViewDT)
        Catch ex As SqlClient.SqlException
            'Utilities.logErrorMessage("DataGridViews.GetDataBaseViews()--query-")
            'MessageBox.Show(ErrString + ": " + ex.Message)
        End Try
        connRemote.Close()
    End Sub
    Public Sub New(ByVal _ModuleName As String, ByVal _ModuleFileName As String, ByVal _dgc As DevExpress.XtraGrid.GridControl)
        Try
            ModuleName = _ModuleName
            ModuleFileName = _ModuleFileName
            DGC = _dgc
            DataGridName = DGC.Name
            GetDataBaseViews()
            If ViewDT.Rows.Count = 0 Then
                Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = DGC.MainView
                For i As Integer = 0 To View.Columns.Count - 1
                    View.Columns(i).OptionsColumn.FixedWidth = True
                    If View.Columns(i).Caption = "ID" Then
                        View.Columns(i).OptionsColumn.ReadOnly = True
                        View.Columns(i).Visible = False
                    End If
                Next
                SaveNewView("default")
                GetDataBaseViews()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GetThisView(ByVal myViewName As String)
        If DGC.Name <> DataGridName Then Return
        For i As Integer = 0 To ViewDT.Rows.Count - 1
            If ViewDT.Rows(i)("ViewName") = myViewName Then
                Try
                    Dim pv As DevExpress.XtraGrid.Views.Grid.GridView = DGC.DefaultView
                    Dim buf() As Byte = ViewDT.Rows(i)("ViewContents")
                    Dim vdir As String = runtime.AbsolutePath + "sites\Views\"
                    Directory.CreateDirectory(vdir)
                    Dim fName = myViewName + ".txt"
                    File.WriteAllBytes(vdir + fName, buf)
                    Dim fd As Stream = File.Open(vdir + fName, FileMode.Open)
                    pv.RestoreLayoutFromStream(fd)
                    fd.Close()

                    'Dim ms As New System.IO.Stream()
                    'ms.Seek(0, SeekOrigin.Begin)
                    'ms.Write(buf, 0, buf.Length - 1)
                    'ms.Seek(0, SeekOrigin.Begin)
                    'pv.RestoreLayoutFromStream(ms)
                    DGC.Refresh()
                Catch ex As Exception

                End Try
            End If
        Next
    End Sub
    Public Sub SaveThisView(ByVal myViewName As String)
        If DGC.Name <> DataGridName Then Return
        For i As Integer = 0 To ViewDT.Rows.Count - 1
            If ViewDT.Rows(i)("ViewName") = myViewName Then
                UpdateThisView(myViewName)
            End If
        Next
    End Sub
    Public Function GetViewNames() As List(Of String)
        GetDataBaseViews()
        Dim myList As New List(Of String)
        For i As Integer = 0 To ViewDT.Rows.Count - 1
            myList.Add(ViewDT.Rows(i)("ViewName"))
        Next
        Return myList
    End Function
    Public Sub SaveAsNewView(ByVal myViewName As String)
        If DGC.Name <> DataGridName Then Return
        For i As Integer = 0 To ViewDT.Rows.Count - 1
            If ViewDT.Rows(i)("ViewName") = myViewName Then
                Return
            End If
        Next
        SaveNewView(myViewName)
    End Sub
    Public Function ViewExist(ByVal myViewName As String)
        If DGC.Name <> DataGridName Then Return False
        For i As Integer = 0 To ViewDT.Rows.Count - 1
            If ViewDT.Rows(i)("ViewName") = myViewName Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Sub ShowGridPreview(ByVal _myHeading As String)
        ' Check whether the GridControl can be previewed.
        If Not DGC.IsPrintingAvailable Then
            'MessageBox.Show("The 'DevExpress.XtraPrinting.v7.2.dll' is not found", "Error")
            Return
        End If
        Dim lView As LayoutView = New LayoutView(DGC)

        Dim ps As New PrintingSystem()
        ps.PageSettings.Landscape = True
        ' Create a link that will print a control.
        Dim link As New PrintableComponentLink(ps)
        ' Specify the control to be printed.
        link.Component = DGC
        ' Subscribe to the CreateReportHeaderArea event used to generate the report header.
        AddHandler link.CreateReportHeaderArea, AddressOf CreateReportHeaderArea
        ' Generate the report.
        link.CreateDocument()
        ' Show the report.
        link.ShowPreview()

        ' Opens the Preview window.
        '        grid.ShowPrintPreview()
    End Sub
    Private Sub ShowVGridPreview(ByVal Vgrid As DevExpress.XtraVerticalGrid.VGridControl, ByVal _myHeading As String)
        myHeading = _myHeading
        ' Check whether the GridControl can be previewed.
        If Not Vgrid.IsPrintingAvailable Then
            'MessageBox.Show("The 'DevExpress.XtraPrinting.v7.2.dll' is not found", "Error")
            Return
        End If

        Dim ps As New PrintingSystem()
        ps.PageSettings.Landscape = True
        ' Create a link that will print a control.
        Dim link As New PrintableComponentLink(ps)
        ' Specify the control to be printed.
        link.Component = Vgrid
        ' Subscribe to the CreateReportHeaderArea event used to generate the report header.
        AddHandler link.CreateReportHeaderArea, AddressOf CreateReportHeaderArea
        ' Generate the report.
        link.CreateDocument()
        ' Show the report.
        link.ShowPreview()

        ' Opens the Preview window.
        '        grid.ShowPrintPreview()
    End Sub

    Private Sub CreateReportHeaderArea(ByVal sender As System.Object, ByVal e As CreateAreaEventArgs)
        Dim pgSize As SizeF = e.Graph.ClientPageSize
        Dim rec As RectangleF = New RectangleF(0, 0, pgSize.Width, 40)
        e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
        e.Graph.Font = New Font("TimesRoman", 24, FontStyle.Bold)
        e.Graph.DrawString("Report View: " + myHeading, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None)
    End Sub

End Class
