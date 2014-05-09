Imports daqartDLL


Public Class MERequirement
    Public ReturnValue As String
    Public CmdResult As DialogResult
    Dim InitialValue As String
    Dim ReqValue() As String
    Dim FormID As String


    Public Sub New(ByVal _Req As String, ByVal _FormID As String)
        InitializeComponent()
        InitialValue = _Req
        FormID = _FormID
    End Sub


    Private Sub MERequirement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Utilities.IsFormMultiElement(FormID) Then
            If Not InitialValue = "" Then
                ReqValue = InitialValue.Split("/")
                Me.tbx_BaseMH.Text = ReqValue(0).Trim(" ")
                Me.tbx_ElementMH.Text = ReqValue(1).Trim(" ")

            End If
        Else
            Me.tbx_BaseMH.Text = InitialValue
            Me.tbx_ElementMH.Visible = False
            Me.Label2.Visible = False
        End If
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        ReturnValue = InitialValue
        CmdResult = Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        CmdResult = Windows.Forms.DialogResult.OK
        If Me.tbx_BaseMH.Text = "" Then
            If Utilities.IsFormMultiElement(FormID) Then
                ReturnValue = ""
            Else
                ReturnValue = ""
            End If
        Else
            If Utilities.IsFormMultiElement(FormID) Then
                ReturnValue = Me.tbx_BaseMH.Text + " / " + Me.tbx_ElementMH.Text
            Else
                ReturnValue = Me.tbx_BaseMH.Text
            End If
        End If

        Me.Close()
    End Sub


End Class