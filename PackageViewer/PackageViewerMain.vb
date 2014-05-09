Imports daqartDLL

Public Class PackageViewerMain

    Private Sub PackageViewerMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.tsl_SiteLabel.Text = "Site: " + Runtime.SiteName
        Me.ProjectStatusInd.Text = "Project: " + Runtime.selectedProject

        If PackageList.DropDownItems.Count = 0 Then
            Me.Cursor = Cursors.AppStarting
            Dim myForm As New PkgSelect
            myForm.MdiParent = Me
            myForm.Show()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CheckPermissions()
        If Not Utilities.CheckPermission("PUN001") Then
            Me.ToolStripButton3.Enabled = False
            Me.AddItemToolStripMenuItem.Enabled = False
        End If

        If Not Utilities.CheckPermission("DIS001") Then
            Me.ToolStripButton2.Enabled = False
            Me.AddDiscrepancyToolStripMenuItem.Enabled = False
        End If
    End Sub


    Private Sub ExitPackageViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitPackageViewerToolStripMenuItem.Click
        Me.Dispose()
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        DiscrepancyAdd()
    End Sub

    Private Sub DiscrepancyAdd()
        Dim frmDiscrepancy As New DiscrepancyManager.frmAddDiscrepancy(PackageViewerManager.SelectedPackageID, PackageViewerManager.SelectedPackagename)
        frmDiscrepancy.ShowDialog()
    End Sub


    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'MessageBox.Show("Print Module inactive.")
        'Return


        '        Dim pPreview As New PackagePreview
        '       pPreview.Show()
        If (PackageViewerManager.SelectedPackageID) Then

            Dim pPreview As New PackagePrint(PackageViewerManager.SelectedPackageID)
            pPreview.ShowDialog()
        Else
            MessageBox.Show("You must select a package before printing")
        End If
    End Sub


    Private Sub PackageList_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles PackageList.DropDownItemClicked

        For Each thisChild As Form In Me.MdiChildren
            If thisChild.Name = e.ClickedItem.Name Then
                'Me.ActivateMdiChild(thisChild)
                thisChild.Activate()
                thisChild.WindowState = FormWindowState.Normal

            End If
        Next thisChild

        For Each thisItem As ToolStripMenuItem In PackageList.DropDownItems
            If thisItem.Text = e.ClickedItem.Text Then
                thisItem.Checked = True
            Else
                thisItem.Checked = False
            End If
        Next thisItem


    End Sub



    Public Sub DocumentsEnable()
        'msi_Documents.Enabled = True
    End Sub


    Private Sub AddDiscrepancyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddDiscrepancyToolStripMenuItem.Click
        DiscrepancyAdd()
    End Sub


    Private Sub AddItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemToolStripMenuItem.Click
        '      PunchlistAdd()
    End Sub


    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        '      PunchlistAdd()
    End Sub
    '/* •———————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    ' |                                                                                                                       |
    ' |     Private Sub PunchlistAdd()                                                                                        |
    ' |         Dim ThisTagID As String = CommonForms.Classes.GetTagMUID(PackageViewerManager.SelectedPackageID)              |
    ' |                                                                                                                       |
    ' |         If ThisTagID = "" Then                                                                                        |
    ' |             Return                                                                                                    |
    ' |         End If                                                                                                        |
    ' |                                                                                                                       |
    ' |         Dim frmPunchlist As New PunchlistManager.AddPunchlist(ThisTagID, CommonForms.Classes.GetTagNumber(ThisTagID)) |
    ' |         frmPunchlist.ShowDialog()                                                                                     |
    ' |                                                                                                                       |
    ' |                                                                                                                       |
    ' |     End Sub                                                                                                           |
    ' •———————————————————————————————————————————————————————————————————————————————————————————————————————————————————• */

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        For Each thisChild As Form In Me.MdiChildren
            If Me.ActiveMdiChild.Name = "PkgSelect" Then
                Return
            End If
            If thisChild.Name = Convert.ToString(PackageViewerManager.SelectedPackageID) Then

                thisChild.Close()
                PackageViewerManager.OpenPackage(PackageViewerManager.SelectedPackageID, PackageViewerManager.SelectedPackagename)

            End If
        Next thisChild
    End Sub



    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        '        Dim pPreview As New PackagePreview
        '       pPreview.Show()
        If (PackageViewerManager.SelectedPackageID > "") Then

            Dim pPreview As New PackagePrint(PackageViewerManager.SelectedPackageID)
            pPreview.ShowDialog()
        Else
            MessageBox.Show("Please select a package")
        End If
    End Sub


    Private Sub OpenPackageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenPackageToolStripMenuItem.Click
        Dim myForm As New PkgSelect

        myForm.MdiParent = Me
        myForm.Show()

    End Sub



End Class