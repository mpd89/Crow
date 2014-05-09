Imports System
Imports daqartDLL


Public Class addSystemNumber
    Public listValue As Integer
    Public thisParent As String
    Public thisTier As Integer
    Dim hasSubSystem As Boolean = False
    Dim SQLProject As DataUtils


    Private Sub addSystemNumber_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLProject.CloseConnection()
    End Sub


    Private Sub addSystemNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SQLProject = New DataUtils("project")
            SQLProject.OpenConnection()

            Dim thisDir = daqartDLL.Utilities.GetDirectory()
        Catch ex As Exception
            Utilities.logErrorMessage("ProjectWizard.addSystemNumber._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        EnterData()

        If Not thisParent Is Nothing Then
            CreateSystemNumbers.PopulateSubSystem(thisTier, thisParent)
        Else
            CreateSystemNumbers.PopulateListBoxes(thisTier)
        End If

        CreateSystemNumbers.CheckBlanks()
        Me.Dispose()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub


    Private Sub EnterData()
        If ((addSystemIdentifier.Text <> "") And (addSystemDescription.Text <> "")) Then
            Dim query As String = "INSERT INTO system_number " & _
                " (MUID,TS,Identifier,ParentLinkMUID,Description,TierMUID) VALUES (" & _
                " @MUID," & _
                " @TS," & _
                " @Identifier," & _
                " @ParentLinkMUID," & _
                " @Description," & _
                " @TierMUID)"

            Dim dt_param As DataTable = SQLProject.paramDT
            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "system_number"))
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@Identifier", addSystemIdentifier.Text)
            dt_param.Rows.Add("@ParentLinkMUID", CStr(thisParent))
            dt_param.Rows.Add("@Description", addSystemDescription.Text)
            dt_param.Rows.Add("@TierMUID", CStr(listValue))

            Try
                SQLProject.ExecuteNonQuery(query, dt_param)
            Catch ex As Exception
                MessageBox.Show("Failed to add system number to table: " + ex.Message)
            End Try
        End If
    End Sub


    Public Sub CheckBlanks()
        Dim hasValue As Boolean = True

        If addSystemIdentifier.Text = "" Then
            hasValue = False
        End If
        If addSystemDescription.Text = "" Then
            hasValue = False
        End If

        If (hasValue = False) Then
            OK_Button.Enabled = False
        Else
            OK_Button.Enabled = True
        End If
    End Sub


    Private Sub addSystemDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles addSystemDescription.TextChanged
        CheckBlanks()
    End Sub


    Private Sub addSystemIdentifier_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles addSystemIdentifier.TextChanged
        CheckBlanks()
    End Sub

End Class
