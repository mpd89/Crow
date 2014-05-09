Imports daqartDLL
Public Class ValueEntry
    Public _Value As String
    Public FieldModified As Boolean = False
    Public FieldName As String


    Public Sub New(ByVal ThisValue As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _Value = ThisValue
    End Sub


    Private Sub ValueEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            tbx_Value.Text = _Value
            lbl_FieldName.Text = FieldName
        Catch ex As Exception
            Utilities.logErrorMessage("FormDesigner.ValueEntry.ValueEntry_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click

        If Not tbx_Value.Text = _Value Then
            _Value = tbx_Value.Text
            FieldModified = True
        End If
        Me.Close()

    End Sub


End Class