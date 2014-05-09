Imports daqartDLL

Public Class FormEditManager
    Public Shared ThisViewer As FormMain
    Public Shared SelectedFormID As String
    Public Shared SelectedFormname As String
    Public Shared SelectedFormOwnerID As String
    Public Shared SelectedFormOwnerName As String


    Public Shared Function OpenFormEdit()
        '  If the instance still exists... (ie. it's Not Nothing)
        If Not IsNothing(ThisViewer) Then
            '  and if it hasn't been disposed yet
            If Not ThisViewer.IsDisposed Then
                '  then it must already be instantiated - maybe it's
                '  minimized or hidden behind other forms ?
                ThisViewer.WindowState = FormWindowState.Maximized
                ThisViewer.BringToFront()
            Else
                '  else it has already been disposed, so you can
                '  instantiate a new form and show it
                ThisViewer = New FormMain()
                ThisViewer.Show()
            End If
        Else
            '  else the form = nothing, so you can safely
            '  instantiate a new form and show it
            ThisViewer = New FormMain()
            ThisViewer.Show()
        End If

    End Function

    Public Shared Sub OpenForm(ByVal FormID As String, ByVal myName As String)
        OpenFormEdit()
        ThisViewer.FormList.DropDownItems.Add(myName)

        'FormMain.FormList.DropDownItems.Add(Name)

        For Each thisItem As ToolStripMenuItem In ThisViewer.FormList.DropDownItems
            Dim test As String = thisItem.Text
            If thisItem.Text = myName Then
                thisItem.Name = FormID
                thisItem.Checked = True
                'thisItem.CheckState = CheckState.Checked
            Else
                thisItem.Checked = False
                'thisItem.CheckState = CheckState.Unchecked
            End If
        Next thisItem

        Dim myForm As New FormEditing(FormID, ThisViewer, myName)
        myForm.MdiParent = ThisViewer
        myForm.Text = myName + " - " + Utilities.GetFormDescription(FormID)
        'myForm.DocumentID = FormID
        'myForm.DocumentName = Name
        myForm.Name = FormID
        myForm.Show()

        'ThisViewer.MainWindow.Panel2.Controls.Add(myForm)

        ThisViewer.MainWindow.Visible = True
        ThisViewer.MainWindow.BringToFront()
        '        Dim myForm As New FormDesignerMain(FormID)
        'Dim myForm As New FormEdit(FormID)
        'Dim myForm As New FormEditing(FormID)
        'myForm.MdiParent = FormMain
        'myForm.Text = Name
        'myForm.Name = FormID
        'myForm.BringToFront()
        'myForm.Show()

    End Sub

    Public Shared Sub FormClosed(ByVal ThisForm As String)

        For Each thisItem As ToolStripMenuItem In ThisViewer.FormList.DropDownItems
            If thisItem.Text = ThisForm Then
                ThisViewer.FormList.DropDownItems.Remove(thisItem)
                Return
            End If
        Next thisItem
    End Sub


    Public Shared Sub FormFocus(ByVal FormID As String, ByVal FormName As String)
        ThisViewer.SelectedFormID = FormID
        For Each thisItem As ToolStripMenuItem In ThisViewer.FormList.DropDownItems
            If thisItem.Text = FormName Then
                thisItem.Checked = True
            Else
                thisItem.Checked = False
            End If
        Next thisItem
        ThisViewer.InitializeMultiElementView()
        ThisViewer.InitializeMenuTreeView()

    End Sub
End Class
