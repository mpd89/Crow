Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
'Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL
Imports System.Threading
Imports System

Public Class PackagePrint
    Private _PkgID As String
    Dim PackageList As DataTable
    Dim SystemMUID As String


    Public Sub New(ByVal PkgID As String)
        InitializeComponent()

        _PkgID = PkgID
    End Sub


    Public Sub New(ByVal _PackageList As DataTable, ByVal _SystemMUID As String)
        InitializeComponent()

        PackageList = _PackageList
        SystemMUID = _SystemMUID
    End Sub


    Private Function getOwnerID() As String
        If Me.cboOwner.Text = "All" Then
            Return ""
        Else
            Return (Me.cboOwner.SelectedValue)
        End If
    End Function


    Private Sub PrintToPDF()
        Dim pDialog As SaveFileDialog = New SaveFileDialog()
        pDialog.FileName = Utilities.GetPackageName(_PkgID)
        'pDialog.DefaultExt = ".pdf"
        pDialog.Filter = "*.pdf|PDF Document"
        If pDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim pkgUtil As PackageUtils = New PackageUtils()
            Me.lblPrintProgress.Text = "Printing: " + pkgUtil.GetPackageName(_PkgID)
            pkgUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
                    ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked, _
                    ckb_PkgHilite.Checked, ckb_PkgMarkeup.Checked)
            Dim dest As String = pDialog.FileName
            If InStr(dest, ".") Then
                'dest = dest.Insert(InStr(pDialog.FileName, ".") - 1, "_" + Utilities.GetOwner(OwnerID).Rows(0)(0).ToString)
            Else
                'dest = dest.Insert(dest.Length, "_" + Utilities.GetOwner(OwnerID).Rows(0)(0).ToString + ".pdf")
                dest = dest.Insert(dest.Length, ".pdf")
            End If
            pkgUtil.Print2PDF(dest, _PkgID, getOwnerID)
            Do
                Thread.Sleep(1)
            Loop Until pkgUtil.DonePrinting

            Me.lblPrintProgress.Text = "Done"

        End If
    End Sub


    Private Sub PrintPackages()
        Dim pkgUtil As PackageUtils = New PackageUtils()
        Me.lblPrintProgress.Text = "Printing: " + pkgUtil.GetPackageName(_PkgID)
        pkgUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
                ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked, _
                ckb_PkgHilite.Checked, ckb_PkgMarkeup.Checked)
        pkgUtil.PrintPackage(_PkgID, getOwnerID)
        Do
            Thread.Sleep(1)
        Loop Until pkgUtil.DonePrinting


        Me.lblPrintProgress.Text = "Done"

    End Sub


    Private Sub PrintPreviewPackages()
        Dim pkgUtil As PackageUtils = New PackageUtils()

        Dim PrintMode As String = "preview"
        Dim PathToPDF As String = Nothing

        If radio_ToPDF.Checked Then
            Dim pDialog As SaveFileDialog = New SaveFileDialog()

            If Not Me._PkgID Is Nothing Then
                pDialog.FileName = Utilities.GetPackageName(_PkgID)
            Else
                pDialog.FileName = SystemManager.SystemDataManager.TranslateSystemID(Me.SystemMUID)
            End If


            'pDialog.DefaultExt = ".pdf"
            pDialog.Filter = "*.pdf|PDF Document"
            If pDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                PathToPDF = pDialog.FileName
            Else
                Exit Sub
            End If

            PrintMode = "pdf"
        ElseIf Me.radio_Print.Checked Then
            PrintMode = "print"
        ElseIf Me.radio_Preview.Checked Then
            PrintMode = "preview"
        End If

        pkgUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
                ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked, _
                ckb_PkgHilite.Checked, ckb_PkgMarkeup.Checked)


        If Not Me._PkgID Is Nothing Then
            Me.lblPrintProgress.Text = "Printing: " + pkgUtil.GetPackageName(_PkgID)
            pkgUtil.PrintPreviewPackage(_PkgID, getOwnerID, PrintMode, PathToPDF)
        Else
            Me.lblPrintProgress.Text = "Printing: " + SystemManager.SystemDataManager.TranslateSystemID(SystemMUID)
            pkgUtil.PrintPreviewSystemPackage(SystemMUID, PackageList, getOwnerID, PrintMode, PathToPDF)
        End If

        Do
            Thread.Sleep(1)
        Loop Until pkgUtil.DonePrinting
        Me.lblPrintProgress.Text = "Done"
    End Sub


    Private Sub PrintToPrinter()
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Enabled = False
        Me.Cursor = Cursors.AppStarting

        PrintPreviewPackages()

        Me.Cursor = Cursors.Default
        Me.Enabled = True
        Me.Dispose()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub PackagePrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'set up Owner drop down list
        Dim qry = "SELECT MUID, Name FROM Owner"
        Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        sqlSrvUtils.OpenConnection()
        Dim myTbl As DataTable = sqlSrvUtils.ExecuteQuery(qry)
        sqlSrvUtils.CloseConnection()

        Dim myRow As DataRow = myTbl.NewRow
        myRow(0) = 0
        myRow(1) = "All"
        myTbl.Rows.Add(myRow)

        ckbSummary.Checked = True
        Me.cboOwner.DataSource = myTbl
        Me.cboOwner.DisplayMember = "Name"
        Me.cboOwner.ValueMember = "MUID"

        Try
            If Not Me._PkgID Is Nothing Then
                Me.cboOwner.SelectedValue = PackageViewer.PackageViewerManager.SelectedPackageOwnerID
                Me.lblPackage.Text = "Print Package: " + PackageViewer.PackageViewerManager.SelectedPackagename
                Me.Text = "Print Package: " + PackageViewer.PackageViewerManager.SelectedPackagename
            ElseIf Not Me.PackageList Is Nothing Then
                Me.lblPackage.Text = "Print System Package: " + SystemManager.SystemDataManager.TranslateSystemID(SystemMUID)
                Me.Text = "Print System Package: " + SystemManager.SystemDataManager.TranslateSystemID(SystemMUID)
            End If

            '        Directory.Delete(runtime.AbsolutePath + "sites\Forms\images\imgList", True)
        Catch ex As Exception
            Utilities.logErrorMessage("PackageViewer.PackagePrint._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub ckbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbAll.CheckedChanged
        If Me.ckbAll.Checked Then
            ckbDocuments.Checked = True
            ckbPunchlist.Checked = True
            ckbDiscripancy.Checked = True
            ckbForms.Checked = True
            ckbSummary.Checked = True
        End If
    End Sub

    Private Sub ckbDocuments_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbDocuments.CheckedChanged
        If Not ckbDocuments.Checked Then
            ckbAll.Checked = False
        End If

    End Sub

    Private Sub ckbPunchlist_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbPunchlist.CheckedChanged
        If Not ckbPunchlist.Checked Then
            ckbAll.Checked = False
        End If
    End Sub

    Private Sub ckbDiscripancy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbDiscripancy.CheckedChanged
        If Not ckbDiscripancy.Checked Then
            ckbAll.Checked = False
        End If
    End Sub

    Private Sub ckbForms_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbForms.CheckedChanged
        If Not ckbForms.Checked Then
            ckbAll.Checked = False
        End If
    End Sub

    Private Sub ckbSummary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbSummary.CheckedChanged
        If Not ckbSummary.Checked Then
            ckbAll.Checked = False
        End If
    End Sub


End Class

