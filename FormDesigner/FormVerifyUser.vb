Imports System.Windows.Forms
Imports daqartDLL
Public Class FormVerifyUser
    Private _myForm As FormUtils
    Private CurrentUserID As String
    Private reqLevelId As String


    Public Sub New(ByVal myForm As FormUtils)
        _myForm = myForm

        Dim reqLevel As Integer = _myForm.FormCurrentLevel
        If reqLevel >= _myForm.FormLevelOrder.Length Then
            reqLevel = _myForm.FormLevelOrder.Length - 1
        End If
        reqLevelId = _myForm.FormLevelOrder(reqLevel)
        If reqLevelId = _myForm.FormCurrentUserLevelID Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
        InitializeComponent()
        Me.OK_Button.Enabled = False
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim myID = Utilities.GetUserLevel(Me.tbxUserName.Text, Me.tbxPW.Text)
        If myID <> reqLevelId Then
            If myID = "0" Then
                Me.essMsg.Text = "Invalid User name or Password"
            Else
                Me.essMsg.Text = "Invalid authorization level"
            End If
            Me.essMsg.Visible = True
            Return
        End If
        _myForm.FormCurrentUserID = Utilities.GetUserID(Me.tbxUserName.Text, Me.tbxPW.Text)
        _myForm.FormCurrentUserLevelID = myID
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub FormVerifyUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.essMsg.Visible = False
        Catch ex As Exception
            Utilities.logErrorMessage("FormDesigner.FormVerifyUser_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub tbxUserName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxUserName.TextChanged
        If Me.tbxUserName.Text > "" And tbxPW.Text > "" Then
            Me.OK_Button.Enabled = True
        End If
    End Sub


    Private Sub tbxPW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxPW.TextChanged
        If Me.tbxUserName.Text > "" And tbxPW.Text > "" Then
            Me.OK_Button.Enabled = True
        End If
    End Sub
End Class
