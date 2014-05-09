Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository
Imports daqartDLL

Public Class FormStatus
    Private FormID As Integer
    Private FormTagID As Integer
    Private FormOwnerID As Integer
    Private statusTable As String
    Private sqlProjectUtils As DataUtils = New DataUtils("project")
    Private sqlServerUtils As DataUtils = New DataUtils("server")

    Public Sub New(ByVal ThisFormID As Integer, ByVal ThisTagID As Integer, ByVal ThisOwnerID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormID = ThisFormID
        FormTagID = ThisTagID
        FormOwnerID = ThisOwnerID

    End Sub
    Private Sub ShowGrid(ByVal dt As DataTable)
        dt.Columns.Add("Form Level", GetType(String))
        dt.Columns.Add("User Action", GetType(String))
        GridView1.OptionsView.ColumnAutoWidth = True

        dt.Columns.Add("User Name", GetType(String))
        Dim query As String
        query = "Select LevelOrder, LevelDescription From forms_config WHERE OwnerID = '" & FormOwnerID & "'"

        Dim FormLevelOrder() As String
        Dim FormLevelDescription() As String = {"Incomplete"}
        Dim configTable As DataTable = sqlProjectUtils.ExecuteQuery(query)
        If configTable.Rows.Count > 0 Then
            FormLevelOrder = Split(configTable.Rows(0)(0), "&001")
            FormLevelDescription = Split(configTable.Rows(0)(1), "&001")
        End If

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim myAction As Integer = dt.Rows(i)("Action")
            Dim UserAction As String = _
                IIf(myAction = 0, "Save", _
                IIf(myAction = 1, "Submit", _
                IIf(myAction = 2, "Reject", _
                IIf(myAction = 3, "Accept", _
                IIf(myAction = 4, "Cancel", "Undefined")))))
            dt.Rows(i)("User Action") = UserAction
            Dim myFormLevel As Integer = dt.Rows(i)("CurrentLevel").ToString
            If myFormLevel = 0 Then
                dt.Rows(i)("Form Level") = "Incomplete"
            Else
                If myFormLevel >= FormLevelDescription.Length Then
                    myFormLevel = FormLevelDescription.Length
                End If
                dt.Rows(i)("Form Level") = FormLevelDescription(myFormLevel - 1)
            End If
            query = "SELECT userInfo.UserName, userInfo.LastName + ',' + userInfo.FirstName + ' ' + userInfo.MI AS FullName, " & _
                " userInfo.Active " & _
                " FROM userInfo WHERE userInfo.UserID = " + dt.Rows(i)("UserID").ToString
            Dim dtt As DataTable = sqlServerUtils.ExecuteQuery(query)
            If dtt.Rows.Count > 0 Then
                dt.Rows(i)("User Name") = dtt.Rows(0)("FullName")
            End If
        Next
        GridControl1.DataSource = dt
        For i As Integer = 0 To GridView1.Columns.Count - 1

            GridView1.Columns(i).OptionsColumn.FixedWidth = True
            GridView1.Columns("Comment").Width = 200
            GridView1.Columns(i).Fixed = Columns.FixedStyle.None
            GridView1.Columns(i).BestFit()
        Next
        GridView1.Columns("UserID").Visible = False
        GridView1.Columns("Action").Visible = False
        GridView1.Columns("CurrentLevel").Visible = False


        'Dim RIImageEdit As New RepositoryItemImageEdit()
        'GridControl1.RepositoryItems.Add(RIImageEdit)
        'GridView1.Columns("ESign").ColumnEdit = RIImageEdit
    End Sub
    Private Sub FormStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sqlProjectUtils.OpenConnection()
        sqlServerUtils.OpenConnection()
        Try
            Dim qry As String = " SELECT MultiElement,NumberofElements FROM forms WHERE MUID = '" + FormID.ToString + "'"
            If sqlProjectUtils.ExecuteQuery(qry).Rows(0)(0) = 1 Then
                qry = "SELECT TS, UserIMUD, Action,Comment,CurrentLevel " + _
                           " FROM forms_me_status WHERE SourceMUID = '" + FormTagID.ToString + "' AND FormMUID = '" + FormID.ToString + "' AND " + _
                           " OwnerMUID = '" + FormOwnerID.ToString + "' ORDER BY TS DESC"
            Else
                qry = "SELECT TS, UserMUID, Action,Comment,CurrentLevel " + _
                           " FROM forms_status WHERE TagMUID = '" + FormTagID.ToString + "' AND FormMUID = '" + FormID.ToString + "' AND " + _
                           " OwnerMUID = '" + FormOwnerID.ToString + "' ORDER BY TS DESC"
            End If
            Dim dt As DataTable = sqlProjectUtils.ExecuteQuery(qry)
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("No recorded activities on this form")
                sqlProjectUtils.CloseConnection()
                sqlServerUtils.CloseConnection()
                Me.Close()
            End If

            ShowGrid(dt)
        Catch ex As Exception
            MessageBox.Show("Form status can not be established")
        End Try
        sqlProjectUtils.CloseConnection()
        sqlServerUtils.CloseConnection()
    End Sub
End Class