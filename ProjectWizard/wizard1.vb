Imports System
Imports System.Windows.Forms
Imports daqartDLL


Public Class wizard1
    Public WizardStatus As Integer

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("You have not finished creating your project.  Are you sure you want to cancel?  All changes will be lost.", "Project cancellation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) Then

            'undo completed steps
            If WizardStatus > 0 Then
                'remove project subscription from server


                'delete project database from server


            End If

            Me.Close()
        End If
    End Sub


    Private Sub LabelStep1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelStep1.Click
        If WizardStatus = 0 Then
            CreateProject.ShowDialog()
        End If
    End Sub


    Private Sub LabelStep2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelStep2.Click
        If WizardStatus = 1 Then
            CreateSystemMnemonics.ShowDialog()
        End If
    End Sub


    Private Sub LabelStep3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelStep3.Click
        If WizardStatus = 2 Then
            CreateSystemNumbers.ShowDialog()
        End If
    End Sub


    Private Sub LabelStep4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelStep4.Click
        If WizardStatus = 3 Then
            CreateEquipment.ShowDialog()
        End If
    End Sub


    Private Sub WizardFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WizardFinish.Click
        MessageBox.Show("New Project Created Successfully!!")
        Me.Dispose()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Help.ShowHelp(Me, runtime.AbsolutePath() + "\daqart.chm", HelpNavigator.Topic, "ProjectChecklist.htm")
    End Sub

End Class