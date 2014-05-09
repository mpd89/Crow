Public Class PackageViewerManager
    Public Shared ThisViewer As PackageViewerMain
    Public Shared SelectedPackageID As String
    Public Shared SelectedPackagename As String
    Public Shared SelectedPackageOwnerID As String
    Public Shared SelectedPackageOwnerName As String


    Public Shared Sub OpenPackageViewer()
        If Not IsNothing(ThisViewer) Then
            If Not ThisViewer.IsDisposed Then
                'ThisViewer.WindowState = FormWindowState.Normal
                ThisViewer.BringToFront()
            Else
                ThisViewer = New PackageViewerMain()
                ThisViewer.Show()
            End If
        Else
            ThisViewer = New PackageViewerMain()
            ThisViewer.Show()
        End If

    End Sub

    Public Shared Sub OpenPackage(ByVal PackageID As String, ByVal Description As String)
        OpenPackageViewer()
        ThisViewer.PackageList.DropDownItems.Add(Description)

        For Each thisItem As ToolStripMenuItem In ThisViewer.PackageList.DropDownItems
            Dim test As String = thisItem.Text
            If thisItem.Text = Description Then
                thisItem.Name = PackageID
                thisItem.Checked = True
                'thisItem.CheckState = CheckState.Checked
            Else
                thisItem.Checked = False
                'thisItem.CheckState = CheckState.Unchecked
            End If
        Next thisItem


        Dim Package As New PackageView
        Package.MdiParent = ThisViewer
        Package.Text = Description
        Package.PackageID = PackageID
        Package.Name = PackageID

        Package.Show()

    End Sub


    Public Shared Sub FormClosed(ByVal ThisForm As String)

        For Each thisItem As ToolStripMenuItem In ThisViewer.PackageList.DropDownItems
            If thisItem.Text = ThisForm Then
                ThisViewer.PackageList.DropDownItems.Remove(thisItem)
                Return
            End If
        Next thisItem
    End Sub


    Public Shared Sub PackageFocus(ByVal ThisForm As String)
        For Each thisItem As ToolStripMenuItem In ThisViewer.PackageList.DropDownItems
            If thisItem.Text = ThisForm Then
                thisItem.Checked = True
            Else
                thisItem.Checked = False
            End If
        Next thisItem


    End Sub


    Public Shared Sub RefreshPackageMatrix(ByVal ThisForm As String)

        For Each thisItem As ToolStripMenuItem In ThisViewer.PackageList.DropDownItems
            If thisItem.Text = ThisForm Then
                thisItem.Checked = True
            Else
                thisItem.Checked = False
            End If
        Next thisItem


    End Sub



End Class
