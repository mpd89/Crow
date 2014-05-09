Imports daqartDLL

Public Class Category
    Private typeID As String = ""
    Public Sub New(ByVal _typeID As String)
        typeID = _typeID
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim Code As String = ""
        Dim Description As String
        Dim Parent As String
        Dim Disable11x17Print As String = "0"
        'declare DocTypeData object rec 
        'Dim rec As New DocTypeData
        Code = txtCode.Text
        Description = txtDesc.Text
        ' lbltag is empty store as parent or else as child
        If (lblTag.Text <> "0") Then
            Parent = lblTag.Text
        Else
            Parent = "0"
        End If
        If Me.ckb_Disable11x17.Checked Then
            Disable11x17Print = "1"
        End If
        Dim sqlDaqUtils As DataUtils = New DataUtils("Daqument")

        sqlDaqUtils.OpenConnection()
        Dim query As String = ""
        'call adddatarecord to add record 

        Dim dt_param As DataTable = sqlDaqUtils.paramDT
        If typeID = "0" Then
            Dim muid As String = idUtils.GetNextMUID("Daqument", "document_type")
            query = "insert into document_type(" + _
                " MUID,TS, Code,Description,ParentMUID,Disable11x17) values (" + _
                " @MUID," + _
                " @TS," + _
                " @Code," + _
                " @Description," + _
                " @ParentMUID," + _
                " @Disable11x17" + _
                " )"
            dt_param.Rows.Add("@MUID", muid)
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@Code", Code.ToString)
            dt_param.Rows.Add("@Description", Description.ToString)
            dt_param.Rows.Add("@ParentMUID", Parent)
            dt_param.Rows.Add("@Disable11x17", Disable11x17Print)
        Else
            query = "Update document_type SET " + _
            "TS =@TS," + _
            "Code = @Code," + _
            "Description =@Description," + _
            "Disable11x17 =@Disable11x17 " + _
            "WHERE MUID = @MUID"

            dt_param.Rows.Add("@MUID", typeID.ToString)
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@Code", Code.ToString)
            dt_param.Rows.Add("@Description", Description.ToString)
            dt_param.Rows.Add("@Disable11x17", Disable11x17Print)
        End If

        sqlDaqUtils.ExecuteNonQuery(query, dt_param)
        sqlDaqUtils.CloseConnection()
        Me.Dispose()


    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
End Class