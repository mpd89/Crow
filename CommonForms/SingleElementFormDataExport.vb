Imports daqartDLL

Public Class SingleElementFormDataExport
    Dim FormID As Integer
    Dim OwnerID As Integer
    Dim ReqID As Integer

    Dim dt_FieldList As New DataTable
    Dim dt_TagIDList As New DataTable


    Public Sub New(ByVal _FormID As Integer, ByVal _OwnerID As Integer)
        FormID = _FormID
        OwnerID = _OwnerID
    End Sub


    Public Function MakeDT() As DataTable
        Dim dt_Final As New DataTable
        dt_TagIDList = Me.GetTagIDList
        Me.GetAuxFormsInfo()

        dt_Final.Columns.Add("Tag#")
        dt_Final.Columns.Add("Package#")
        dt_Final.Columns.Add("System#")

        For Each dr As DataRow In Me.dt_FieldList.Rows
            dt_Final.Columns.Add(dr("FieldID"))
            dt_Final.Columns(dt_Final.Columns.Count - 1).Caption = dr("FieldName")
        Next

        Dim key(1) As DataColumn
        key(0) = Me.dt_FieldList.Columns("FieldName")
        Me.dt_FieldList.PrimaryKey = key

        'Dim key2(1) As DataColumn
        'key2(0) = Me.dt_TagIDList.Columns("TagNumber")
        'Me.dt_TagIDList.PrimaryKey = key2

        If Not Me.dt_TagIDList Is Nothing Then
            Dim key2(1) As DataColumn
            key2(0) = Me.dt_TagIDList.Columns("TagNumber")
            Me.dt_TagIDList.PrimaryKey = key2

            For Each dr As DataRow In Me.dt_TagIDList.Rows
                dt_Final.Rows.Add(dr("TagNumber"), dr("PackageNumber"), dr("SystemNumber"))
            Next
        End If

        Dim i As Integer = 0
        For Each dr As DataRow In dt_Final.Rows
            dt_Final.Rows(i)(2) = SystemManager.SystemDataManager.TranslateSystemID(dt_Final.Rows(i)(2))

            Dim drMatchTag As DataRow = Me.dt_TagIDList.Rows.Find(dr(0))
            Dim thisTagID As Integer

            thisTagID = Utilities.TranslateTagNumber(dr(0))

            Dim FormComplete As Integer = Utilities.GetFormConfigCount(OwnerID)
            Dim CurrentStatus As Integer = Utilities.GetFormStatus(thisTagID, FormID, OwnerID)

            If (FormComplete = CurrentStatus) Then
                For Each dc As DataColumn In dt_Final.Columns

                    'Dim drMatchRow As DataRow = Me.dt_FieldList.Rows.Find(dc.ColumnName)
                    Dim FieldID As Integer = 0
                    'If Not drMatchRow Is Nothing Then
                    '    FieldID = drMatchRow("FieldID")
                    'End If

                    'FieldID = dc.ColumnName
                    If Char.IsDigit(dc.ColumnName) Then
                        FieldID = dc.ColumnName
                    End If

                    Dim thisColumn() As String = dc.Caption.Split("@")
                    Dim SignOffLevel As Integer
                    If Mid(dc.Caption, 1, 13) = "SignOff_Level" Then
                        SignOffLevel = Convert.ToInt16(thisColumn(0).Replace("SignOff_Level", ""))
                    End If

                    If (Not thisTagID = 0) And (Not FieldID = 0) And (Not Mid(dc.Caption, 1, 13) = "SignOff_Level") Then
                        dt_Final.Rows(i)(dc.Ordinal) = GetFormData(thisTagID, FieldID)
                    ElseIf Mid(dc.Caption, 1, 13) = "SignOff_Level" Then
                        Dim query As String = Nothing
                        Dim NewValue As String = Nothing

                        'If thisColumn.Length = 2 Then

                        query = "SELECT * FROM forms_status WHERE OwnerID='" + OwnerID.ToString + "' " & _
                            " AND TagID='" + thisTagID.ToString + "'" & _
                            " AND FormID='" + FormID.ToString + "'" & _
                            " AND CurrentLevel='" + SignOffLevel.ToString + "'" & _
                            " ORDER BY TS DESC"
                        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
                        sqlPrjUtils.OpenConnection()

                        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

                        If dt.Rows.Count > 0 Then
                            Dim qryUI = "SELECT FirstName, MI, LastName, Number, CompanyID FROM userInfo WHERE UserID = '" + _
                                dt.Rows(0)(5).ToString + "'"
                            Dim ui As DataTable = sqlPrjUtils.ExecuteQuery(qryUI)

                            Select Case thisColumn(1)
                                Case "Name"
                                    NewValue = ui.Rows(0)(0) + " " + ui.Rows(0)(1) + ". " + ui.Rows(0)(2)
                                Case "Number"
                                    NewValue = ui.Rows(0)(3)
                                Case "Company"
                                    Dim qryCO = "SELECT Name FROM Company WHERE CompanyID = '" + ui.Rows(0)(4).ToString + "'"
                                    NewValue = sqlPrjUtils.ExecuteQuery(qryCO).Rows(0)(0)
                                Case "Title"
                                    NewValue = ui.Rows(0)(5)
                                Case "Date"
                                    NewValue = dt.Rows(0)(1)
                                Case "Signature"
                                    'do nothing
                            End Select
                            dt_Final.Rows(i)(dc.Ordinal) = NewValue
                        End If
                        sqlPrjUtils.CloseConnection()

                    End If

                Next
            End If
            i = i + 1

        Next

        Return dt_Final
    End Function


    Private Function GetTypeList() As String
        Dim TypeList As String = "("
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim query As String = "SELECT TypeMUID,ReqMUID FROM requirements WHERE FormMUID='" + FormID.ToString + "' AND OwnerMUID='" + OwnerID.ToString + "'"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()
        If dt.Rows.Count > 0 Then
            ReqID = dt.Rows(0)("ReqID").ToString
            For i As Integer = 0 To dt.Rows.Count - 1
                If i < dt.Rows.Count - 1 Then
                    TypeList += dt.Rows(i)("TypeID").ToString + ","
                Else
                    TypeList += dt.Rows(i)("TypeID").ToString + ")"
                End If
            Next
        End If

        Return TypeList

    End Function


    Private Function GetTagIDList() As DataTable
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim query As String = "SELECT tags.TagMUID AS TagMUID,tags.TagNumber As TagNumber," & _
            " tags.PackageMUID,package.PackageNumber, package.SystemNumber " & _
            " FROM tags INNER JOIN package ON tags.PackageMUID = package.MUID" & _
            " WHERE TypeMUID  IN " + GetTypeList()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Return dt
    End Function


    Private Function GetAuxFormsInfo() As DataTable
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim query As String = "SELECT ID, AuxData FROM aux_forms_info WHERE FormMUID = '" + FormID.ToString + "'"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        dt_FieldList.Columns.Add("FieldID")
        dt_FieldList.Columns.Add("FieldName")

        Try

            For Each dr As DataRow In dt.Rows


                If (Mid(dr("AuxData"), 1, 6) = "Field_") Or _
                    (Mid(dr("AuxData"), 1, 9) = "YNSelect_") Or _
                    (Mid(dr("AuxData"), 1, 13) = "SignOff_Level") Then

                    Dim SplitValues() As String = Split(dr("AuxData"), "&001")
                    dt_FieldList.Rows.Add(dr("ID"), SplitValues(21))
                End If
            Next
        Catch ex As Exception

        End Try

        Return dt_FieldList

    End Function


    Private Function GetFormData(ByVal TagID As Integer, ByVal FieldID As Integer) As String

        Try

            Dim query As String = "SELECT FieldValue FROM forms_update WHERE RequirementMUID = '" + ReqID.ToString + "'" & _
                " AND SourceType='Tag' AND SourceMUID='" + TagID.ToString + "' AND FieldMUID='" + FieldID.ToString + "'"

            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            sqlPrjUtils.CloseConnection()
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)(0)
                End If
            End If

        Catch ex As Exception

        End Try
        Return Nothing

    End Function

End Class
