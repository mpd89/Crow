Imports daqartDLL


Public Class SystemTools

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Exit.Click
        Me.Dispose()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_SystemAudit.Click
        If runtime.selectedProject = Nothing Then
            MessageBox.Show("System Audit cannot be performed until there is a project created in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        SystemToolsManager.OpenSystemAuditor()
    End Sub


    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SystemToolsManager.OpenPermissions()
    End Sub

 
End Class