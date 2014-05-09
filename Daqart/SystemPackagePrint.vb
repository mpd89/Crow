Imports System.Windows.Forms
Imports System.Threading
Imports System.ComponentModel
Imports System.Globalization
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL


Public Class SystemPackagePrint
    Private pkgPrint As Boolean = True
    Private printDoc As PrintDocument
    Private printDialog As PrintPreviewDialog
    Private pgCtr As Integer
    Private OwnerMUID As String
    Private SystemMUID As String
    Private AllPkgIDList As New List(Of String)

    Dim sqlPrjUtils As DataUtils = New DataUtils("project")

    Public Sub New(ByVal _SystemMUID As String, ByVal _OwnerMUID As String)
        InitializeComponent()

        pkgPrint = False
        OwnerMUID = _OwnerMUID
        SystemMUID = _SystemMUID

        Dim qry = " SELECT MUID, PackageNumber, Description, GroupMUID, OwnerMUID, DisciplineMUID " + _
               " FROM  Package WHERE SystemMUID LIKE '%" + SystemMUID + "%'"

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        
        For i As Integer = 0 To dt.Rows.Count - 1
            AllPkgIDList.Add(dt.Rows(i)("MUID"))
        Next
    End Sub

    Private Sub SystemPkgPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ckbSummary.Checked = True

            Dim sysName = "Print System: " + SystemManager.SystemDataManager.TranslateSystemID(SystemMUID)
            Me.lblPackage.Text = sysName
            Me.Text = sysName
        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.SystemPkgPrint_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub PrintPackages()
        pgCtr = 0
        Dim pkgUtil As PackageViewer.PackageUtils = New PackageViewer.PackageUtils()

        pkgUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
            ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked, _
                                ckb_PkgHilite.Checked, ckb_PkgMarkeup.Checked)

        pkgUtil.PrintAllPackages(AllPkgIDList, OwnerMUID)
        Do
            Thread.Sleep(1)
        Loop Until pkgUtil.DonePrinting
    End Sub


    Private Sub PrintPreviewPackages()
        pgCtr = 0
        Dim pkgUtil As PackageViewer.PackageUtils = New PackageViewer.PackageUtils()
        pkgUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
            ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked, _
                                ckb_PkgHilite.Checked, ckb_PkgMarkeup.Checked)

        pkgUtil.PrintPreviewAllPackages(AllPkgIDList, OwnerMUID)
        Do
            Thread.Sleep(1)
        Loop Until pkgUtil.DonePrinting


    End Sub


    Private Sub PrintPackagesPDF()
        Dim pDialog As SaveFileDialog = New SaveFileDialog()
        If pDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim dest As String = pDialog.FileName
            If InStr(dest, ".") Then
                'dest = dest.Insert(InStr(pDialog.FileName, ".") - 1, "_" + Utilities.GetOwner(OwnerID).Rows(0)(0).ToString)
            Else
                'dest = dest.Insert(dest.Length, "_" + Utilities.GetOwner(OwnerID).Rows(0)(0).ToString + ".pdf")
                dest = dest.Insert(dest.Length, ".pdf")
            End If
            pgCtr = 0
            Dim pkgUtil As PackageViewer.PackageUtils = New PackageViewer.PackageUtils()
            pkgUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
                ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked, _
                                    ckb_PkgHilite.Checked, ckb_PkgMarkeup.Checked)

            pkgUtil.Print2PDFAllPackages(dest, AllPkgIDList, OwnerMUID)

            Do
                Thread.Sleep(1)
            Loop Until pkgUtil.DonePrinting
        End If
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If radio_ToPDF.Checked Then
            PrintPackagesPDF()
        ElseIf Me.radio_Print.Checked Then
            PrintPackages()
        ElseIf Me.radio_PrintPreview.Checked Then
            PrintPreviewPackages()
        End If
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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

    Private Sub btn_PrintToPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrintPackagesPDF()
    End Sub

    Private Sub SystemPackagePrint_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        sqlPrjUtils.CloseConnection()
    End Sub
End Class
