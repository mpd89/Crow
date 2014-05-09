Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors


Public Class AddSystemDocument
    Private SystemMUID As String


    Public Sub New(ByVal _SystemMUID As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SystemMUID = _SystemMUID
    End Sub


    Private Sub AddSystemDocument_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim query As String
        query = "Select documents.MUID As MUID," & _
            " documents.ClientCode + ' (' + documents.EngCode + ')' As Document," & _
            " document_type.Description As Type,documents.Revision As Rev," & _
            " documents.Sheet + '\' + documents.Sheets As Sht From documents," & _
            " document_type WHERE documents.DocumentTypeMUID=document_type.MUID" & _
            " AND documents.ProjectMUID = '" & Utilities.GetProjectID(runtime.selectedProject).ToString & "'"
        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        sqlDocUtils.OpenConnection()
        Dim dt_Docs As DataTable = sqlDocUtils.ExecuteQuery(query)
        sqlDocUtils.CloseConnection()

        dt_Docs.Columns("MUID").ColumnMapping = MappingType.Hidden
        dt_Docs.Columns("Document").Caption = "Client Code (Eng Code)"

        Me.dgv_DocList.DataSource = dt_Docs
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Dim View As ColumnView = Me.dgv_DocList.FocusedView
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        For i As Integer = 0 To View.RowCount - 1
            If View.IsRowSelected(i) Then
                If Not AssocExist(View.GetRowCellValue(i, "MUID"), SystemMUID.ToString) Then
                    'Dim query As String = "INSERT INTO package_documents " & _
                    '    " (MUID,TS,DocumentMUID,PackageMUID,Notes,TagMUID,SystemMUID) " & _
                    '    " Values (" & _
                    '     " '" & idUtils.GetNextMUID("server", "package_documents") & "'," & _
                    '   " '" & Now() & "'," & _
                    '    " '" & View.GetRowCellValue(i, "MUID").ToString & "'," & _
                    '    " '0'," & _
                    '    " 'System Document'," & _
                    '    " ''," & _
                    '    " '" & SystemMUID.ToString & "')"
                    Dim query As String = "INSERT INTO package_documents " & _
                                          " (MUID,TS,DocumentMUID,PackageMUID,Notes,TagMUID,SystemMUID) " & _
                                          " Values (MUID,TS,DocumentMUID,PackageMUID,Notes,TagMUID,SystemMUID)"
                    Dim dt_param As DataTable = sqlPrjUtils.paramDT

                    dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "package_documents"))
                    dt_param.Rows.Add("@TS", DateAndTime.Now.ToString)
                    dt_param.Rows.Add("@DocumentMUID", View.GetRowCellValue(i, "MUID").ToString)
                    dt_param.Rows.Add("@PackageMUID", "0")
                    dt_param.Rows.Add("@Notes", "System Document")
                    dt_param.Rows.Add("@TagMUID", "")
                    dt_param.Rows.Add("@SystemMUID", SystemMUID.ToString)

                    sqlPrjUtils.ExecuteNonQuery(query, dt_param)

                End If
            End If
        Next
        sqlPrjUtils.CloseConnection()

        Me.Dispose()
    End Sub


    Private Function AssocExist(ByVal _DocumentMUID As String, ByVal _SystemMUID As String) As Boolean
        Dim query As String = "SELECT * FROM package_documents WHERE" & _
            " DocumentMUID = '" + _DocumentMUID.ToString + "'" & _
            " AND SystemMUID = '" + _SystemMUID.ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If dt.Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function


End Class