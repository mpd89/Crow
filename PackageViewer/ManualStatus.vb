Imports daqartDLL


Public Class ManualStatus
    Dim TagMUID As String
    Dim FormMUID As String
    Dim OwnerMUID As String


    Public Sub New(ByVal _TagMUID As String, ByVal _FormMUID As String, ByVal _OwnerMUID As String)
        InitializeComponent()

        TagMUID = _TagMUID
        FormMUID = _FormMUID
        OwnerMUID = _OwnerMUID
    End Sub


    Private Sub ManualStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbx_StatusDate.TextChanged
        Dim thisDate As String
        thisDate = Utilities.GetDate()
        Me.tbx_StatusDate.Text = thisDate
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Close()
    End Sub


    Private Sub cbx_UploadScan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_UploadScan.CheckedChanged
        If Me.cbx_UploadScan.Checked = True Then
            Me.tbx_Filename.Enabled = True
            Me.btn_Upload.Enabled = True
        Else
            Me.tbx_Filename.Text = ""
            Me.tbx_Filename.Enabled = True
            Me.btn_Upload.Enabled = True
        End If
    End Sub



End Class