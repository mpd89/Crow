Public Class WeldManager
    Public Shared ThisViewer As WeldMain
    Public Shared SelectedFormID As Integer
    Public Shared SelectedFormname As String
    Public Shared SelectedFormOwnerID As Integer
    Public Shared SelectedFormOwnerName As String


    Public Shared Function OpenWeldEdit()
        '  If the instance still exists... (ie. it's Not Nothing)
        If Not IsNothing(ThisViewer) Then
            '  and if it hasn't been disposed yet
            If Not ThisViewer.IsDisposed Then
                '  then it must already be instantiated - maybe it's
                '  minimized or hidden behind other forms ?
                ThisViewer.WindowState = FormWindowState.Normal
                ThisViewer.BringToFront()
            Else
                '  else it has already been disposed, so you can
                '  instantiate a new form and show it
                ThisViewer = New WeldMain()
                ThisViewer.Show()
            End If
        Else
            '  else the form = nothing, so you can safely
            '  instantiate a new form and show it
            ThisViewer = New WeldMain()
            ThisViewer.Show()
        End If

    End Function

    Public Shared Sub OpenForm(ByVal FormID As Integer, ByVal Name As String)
        OpenWeldEdit()
        'ThisViewer.WeldDocumentList.DropDownItems.Add(Name)

        'For Each thisItem As ToolStripMenuItem In ThisViewer.WeldDocumentList.DropDownItems
        '    Dim test As String = thisItem.Text
        '    If thisItem.Text = Name Then
        '        thisItem.Name = FormID
        '        thisItem.Checked = True
        '        'thisItem.CheckState = CheckState.Checked
        '    Else
        '        thisItem.Checked = False
        '        'thisItem.CheckState = CheckState.Unchecked
        '    End If
        'Next thisItem


        '        Dim myForm As New FormDesignerMain(FormID)
        'Dim myForm As New FormEdit(FormID)
        Dim myForm As New WeldTracking(FormID, Name)
        myForm.MdiParent = ThisViewer
        myForm.Text = Name
        myForm.Name = FormID
        myForm.BringToFront()
        myForm.Show()

    End Sub

    Public Shared Sub FormClosed(ByVal ThisForm As String)

        'For Each thisItem As ToolStripMenuItem In ThisViewer.WeldDocumentList.DropDownItems
        '    If thisItem.Text = ThisForm Then
        '        ThisViewer.WeldDocumentList.DropDownItems.Remove(thisItem)
        '        Return
        '    End If
        'Next thisItem
    End Sub


    Public Shared Sub FormFocus(ByVal ThisForm As String)
        'For Each thisItem As ToolStripMenuItem In ThisViewer.WeldDocumentList.DropDownItems
        '    If thisItem.Text = ThisForm Then
        '        thisItem.Checked = True
        '    Else
        '        thisItem.Checked = False
        '    End If
        'Next thisItem
    End Sub


End Class
