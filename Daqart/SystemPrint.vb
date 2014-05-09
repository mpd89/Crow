Imports System.Windows.Forms
Imports daqartDLL
Imports System.Threading


Public Class SystemPrint
    Private SystemMUID As String
    Private OwnerMUID As String


    Public Sub New(ByVal _SystemNumberMUID As String, ByVal _OwnerMUID As String)
        InitializeComponent()

        SystemMUID = _SystemNumberMUID
        OwnerMUID = _OwnerMUID
    End Sub


    Private Sub SystemPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblSystem.Text = SystemManager.SystemDataManager.TranslateSystemID(SystemMUID)
        Me.tbxOwner.Text = Utilities.GetOwnerInfo(OwnerMUID).Rows(0)(2)
        Me.ckbSummary.Checked = True
    End Sub


    Private Sub PrintToPDF()
        Dim pDialog As SaveFileDialog = New SaveFileDialog()
        If pDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim sysUtil As SystemPrintUtils = New SystemPrintUtils(SystemMUID)
            Me.lblPrintProgress.Text = "Printing: " + SystemMUID

            sysUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
               ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked, _
                                   ckb_PkgHilite.Checked, ckb_PkgMarkeup.Checked)
            Dim dest As String = pDialog.FileName
            If InStr(dest, ".") Then
                dest = dest.Insert(InStr(pDialog.FileName, ".") - 1, "_" + Utilities.GetOwnerInfo(OwnerMUID).Rows(0)(0).ToString)
            Else
                dest = dest.Insert(dest.Length, "_" + Utilities.GetOwnerInfo(OwnerMUID).Rows(0)(0).ToString + ".pdf")
            End If

            sysUtil.Print2PDF(dest, OwnerMUID)
            Me.lblPrintProgress.Text = "Done"
        End If
    End Sub


    Private Sub PrintSystem()
        Dim sysUtil As SystemPrintUtils = New SystemPrintUtils(SystemMUID)
        Me.lblPrintProgress.Text = "Printing: " + sysUtil.GetSystemName(SystemMUID)
        sysUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
           ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked, _
                               ckb_PkgHilite.Checked, ckb_PkgMarkeup.Checked)
        sysUtil.PrintSystem(OwnerMUID)
        Do
            Thread.Sleep(1)
        Loop Until sysUtil.DonePrinting
        Me.lblPrintProgress.Text = "Done"
    End Sub


    Private Sub PrintPreviewPackages()
        Dim sysUtil As SystemPrintUtils = New SystemPrintUtils(SystemMUID)
        sysUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
                   ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked, _
                                       ckb_PkgHilite.Checked, ckb_PkgMarkeup.Checked)
        sysUtil.PrintPreviewSystem(OwnerMUID)
        Do
            Thread.Sleep(1)
        Loop Until sysUtil.DonePrinting
        Me.lblPrintProgress.Text = "Done"
    End Sub


    Private Sub PrintToPrinter()
        Dim printDialog As PrintDialog = New PrintDialog()
        If printDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrintSystem()
        End If
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If radio_ToPDF.Checked Then
            PrintToPDF()
        ElseIf Me.radio_Print.Checked Then
            PrintToPrinter()
        ElseIf Me.radio_Preview.Checked Then
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
End Class
