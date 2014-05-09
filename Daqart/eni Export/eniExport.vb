Imports daqartDLL
Imports System.Data
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports System.Threading
Imports System
Imports PackageViewer

Public Class eniExport
    Dim OwnerMUID As String
    Dim SystemMUID As String
    Dim SystemList As Array
    Dim ModuleNumber As String
    Dim Root As String
    Dim DirPath As String


    Public Sub New(ByVal _SystemMUID As String)
        InitializeComponent()

        SystemMUID = _SystemMUID
    End Sub


    Private Sub eniExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM owner ORDER BY Name ASC"
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

        Me.cbx_Owner.DataSource = dt
        Me.cbx_Owner.ValueMember = dt.Columns("MUID").ToString
        Me.cbx_Owner.DisplayMember = dt.Columns("Name").ToString

        SystemList = Split(SystemMUID, ";")



    End Sub


    Private Sub btn_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Browse.Click
        Me.FolderBrowserDialog1.SelectedPath = System.Environment.CurrentDirectory
        If FolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.tbx_Folder.Text = FolderBrowserDialog1.SelectedPath
        End If


    End Sub


    Private Sub CreateFolders()
        ModuleNumber = SystemManager.SystemDataManager.GetSystemIdentifier(SystemList(1))
        Directory.CreateDirectory(FolderBrowserDialog1.SelectedPath + "\SYSTEM " + Me.tbx_System.Text + " " + ModuleNumber)
        Root = FolderBrowserDialog1.SelectedPath + "\SYSTEM " + Me.tbx_System.Text + " " + ModuleNumber
        DirPath = "SYSTEM " + Me.tbx_System.Text + " " + ModuleNumber


        Directory.CreateDirectory(Root + "\SYSTEM " + Me.tbx_System.Text + " " + ModuleNumber + " DATASHEETS")
        'Directory.CreateDirectory(Root + "\SYSTEM " + Me.tbx_System.Text + " " + ModuleNumber + " DOCUMENTS ALL")
        Directory.CreateDirectory(Root + "\SYSTEM " + Me.tbx_System.Text + " " + ModuleNumber + " FORMS")
        Directory.CreateDirectory(Root + "\SYSTEM " + Me.tbx_System.Text + " " + ModuleNumber + " ITS")
        Directory.CreateDirectory(Root + "\SYSTEM " + Me.tbx_System.Text + " " + ModuleNumber + " LOOP DRAWINGS")
        'Directory.CreateDirectory(Root + "\SYSTEM " + Me.tbx_System.Text + " " + ModuleNumber + " P&ID")
        Directory.CreateDirectory(Root + "\SYSTEM " + Me.tbx_System.Text + " " + ModuleNumber + " REDLINES")
    End Sub


    Private Sub PrintPreviewPackages()
        Dim pkgUtil As PackageUtils = New PackageUtils()
        Dim query As String = "SELECT * FROM package WHERE SystemMUID " + Utilities.SystemQuery(SystemMUID)
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        Dim PrintMode As String = "preview"
        Dim PathToPDF As String = Nothing

        PrintMode = "pdf"

        'pkgUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
        '        ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked, _
        '        ckb_PkgHilite.Checked, ckb_PkgMarkeup.Checked)


        'documents
        pkgUtil.SetPrintOptions(False, False, False, True, True, False, True, True)
        pkgUtil.PrintPreviewSystemPackage(SystemMUID, dt, Me.cbx_Owner.SelectedValue, PrintMode, Root + "\" + DirPath + " DOCUMENTS ALL")

        'FORMS
        pkgUtil.SetPrintOptions(False, False, True, False, False, False, False, False)
        pkgUtil.PrintPreviewSystemPackage(SystemMUID, dt, Me.cbx_Owner.SelectedValue, PrintMode, Root + "\" + DirPath + " FORMS" + "\" + DirPath + " FORMS")

        Do
            Thread.Sleep(1)
        Loop Until pkgUtil.DonePrinting

    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        CreateFolders()

        PrintPreviewPackages()

        MessageBox.Show("Export Complete")

        Me.Close()

    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub
End Class