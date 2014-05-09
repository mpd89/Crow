Option Explicit On
Imports System
Imports System.ComponentModel
Imports System.Object
Imports System.MarshalByRefObject
Imports System.ComponentModel.Component
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports Microsoft.Win32
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.Net
Imports System.IO
Imports DaqartDLL
Public Class ErrorLogView
    Private LogName As String = "DaqartClientLog"
    Private ComputerName As String = Dns.GetHostName
    Public Class myNodeComparerClass
        Implements IComparer
        Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
           Implements IComparer.Compare
            Dim ndx As Date = CType(x, FileInfo).CreationTime
            Dim ndy As Date = CType(y, FileInfo).CreationTime
            Return Date.Compare(ndy, ndx)
        End Function 'IComparer.Compare

    End Class

    Private Sub ServiceLogView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim logDir As String = runtime.AbsolutePath + "sites\log\"
        Dim logFileName As String = "daqartErrorLog.txt"
        Dim myNodeComparer = New myNodeComparerClass()

        Dim di As New DirectoryInfo(logDir)
        Try
            Dim fiArr As FileInfo() = di.GetFiles()
            fiArr.Sort(fiArr, myNodeComparer)
            For Each f As FileInfo In fiArr
                Dim nd As TreeNode = New TreeNode
                Dim SplitName() = f.Name.Split(logFileName)
                Dim tm As String = "Current"
                If SplitName(0) > "" Then
                    tm = DateTime.FromFileTime(SplitName(0).ToString)
                End If
                nd.Tag = f.Name
                nd.Text = tm
                TreeView1.Nodes.Add(nd)
            Next
            If TreeView1.Nodes.Count > 0 Then
                Dim r As StreamReader = File.OpenText(logDir + logFileName)
                DisplayLogContents(r)
                TreeView1.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show("No log file is available")
            Me.Close()
        End Try
    End Sub

    'Private Sub ServiceLogView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Dim logDir As String = runtime.AbsolutePath + "sites\log\"
    '    Dim logFileName As String = "daqartErrorLog.txt"
    '    Dim myNodeComparer = New myNodeComparerClass()

    '    Dim di As New DirectoryInfo(logDir)
    '    Try
    '        di.GetFiles.Sort(di.GetFiles(), myNodeComparer)
    '        'Dim fNames() As String
    '        'If di.GetFiles().Length > 0 Then
    '        '    Dim nd As TreeNode = New TreeNode
    '        '    nd.Tag = logFileName
    '        '    nd.Text = "Current"
    '        '    TreeView1.Nodes.Add(nd)
    '        '    ReDim Preserve fNames(IIf(Not fNames Is Nothing, fNames.Length, 0))
    '        'Else
    '        '    MessageBox.Show("No log file is available")
    '        '    Me.Close()
    '        'End If
    '        Dim fiArr As FileInfo() = di.GetFiles()
    '        For Each f As FileInfo In fiArr
    '            Dim myTag As String = logFileName
    '            Dim SplitName() = f.Name.Split(logFileName)
    '            Dim tm As String = ""
    '            If SplitName(0) > "" Then
    '                'ReDim Preserve fNames(IIf(Not fNames Is Nothing, fNames.Length, 0))

    '                ReDim Preserve fNames(IIf(Not fNames Is Nothing, fNames.Length, 0))
    '                fNames(fNames.Length) = f.Name
    '            End If

    '        Next
    '        If Not fNames Is Nothing Then
    '            Array.Sort(fNames)
    '            For Each f As String In fNames
    '                Dim SplitName() = f.Split(logFileName)
    '                Dim tm As String = ""
    '                If SplitName(0) > "" Then
    '                    tm = DateTime.FromFileTime(SplitName(0).ToString)
    '                    Dim nd As TreeNode = New TreeNode
    '                    nd.Tag = f
    '                    nd.Text = tm
    '                    TreeView1.Nodes.Add(nd)
    '                End If
    '            Next
    '        End If
    '        If TreeView1.Nodes.Count > 0 Then
    '            Dim r As StreamReader = File.OpenText(logDir + logFileName)
    '            DisplayLogContents(r)
    '            TreeView1.Enabled = True
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("No log file is available")
    '        Me.Close()
    '    End Try
    'End Sub



    Private Sub DisplayLogContents(ByVal r As StreamReader)
        Me.RichTextBox1.Clear()
        Dim line As String
        line = r.ReadLine()
        While Not line Is Nothing
            RichTextBox1.AppendText(line + ControlChars.CrLf)
            line = r.ReadLine()
        End While
        r.Close()
    End Sub


    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
        Select Case e.Node.Text
        End Select
    End Sub




    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub TreeView1_AfterSelect_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim logDir As String = runtime.AbsolutePath + "sites\log\"
        Dim logFileName As String = "daqartErrorLog.txt"
        If e.Node.Text > "" Then
            Try
                Dim r As StreamReader = File.OpenText(logDir + e.Node.Tag)
                DisplayLogContents(r)
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class