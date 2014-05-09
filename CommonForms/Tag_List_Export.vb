Imports daqartDLL
Imports SystemManager



Public Class Tag_List_Export
    Dim dt_FieldList As New DataTable
    Dim dt_TagIDList As New DataTable



    Public Sub New()

    End Sub


    Public Function MakeDT() As DataTable
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim dt_Final As New DataTable
        Dim dt_Tags As New DataTable

        dt_Final.Columns.Add("MUID")
        dt_Final.Columns("MUID").ColumnMapping = MappingType.Hidden

        dt_Final.Columns.Add("TypeMUID")
        dt_Final.Columns("TypeMUID").ColumnMapping = MappingType.Hidden

        dt_Final.Columns.Add("System-Module")
        dt_Final.Columns.Add("Package#")
        dt_Final.Columns.Add("Tag#")
        dt_Final.Columns.Add("Type")
        dt_Final.Columns.Add("Description")
        dt_Final.Columns.Add("Earned MH", System.Type.GetType("System.String"))
        dt_Final.Columns.Add("Required MH", System.Type.GetType("System.String"))
        dt_Final.Columns.Add("Weighted Package MH", System.Type.GetType("System.String"))


        Try
            sqlPrjUtils.OpenConnection()

            Dim query As String = "SELECT MUID,Name FROM forms ORDER BY NAME"
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

            For Each dr As DataRow In dt.Rows
                dt_Final.Columns.Add(dr("MUID"))
                dt_Final.Columns(dt_Final.Columns.Count - 1).Caption = dr("Name")
            Next

            query = "SELECT tags.MUID, package.SystemMUID, package.PackageNumber, tags.TagNumber, " & _
                    " equipment_type.MUID As TypeMUID, equipment_type.TypeName" & _
                    " FROM tags INNER JOIN" & _
                    " package ON tags.PackageMUID = package.MUID INNER JOIN" & _
                    " equipment_type ON tags.TypeMUID = equipment_type.MUID " & _
                    " ORDER BY tags.TagNumber"
            dt_Tags = sqlPrjUtils.ExecuteQuery(query)

            For i As Integer = 0 To dt_Tags.Rows.Count - 1
                dt_Final.Rows.Add(dt_Tags.Rows(i)("MUID"), dt_Tags.Rows(i)("TypeMUID"), _
                    SystemDataManager.TranslateSystemID(dt_Tags.Rows(i)("SystemMUID")), _
                    dt_Tags.Rows(i)("PackageNumber"), dt_Tags.Rows(i)("TagNumber"), _
                    dt_Tags.Rows(i)("TypeName"), "", _
                    Utilities.GetTagEarnedManHours(dt_Tags.Rows(i)("MUID")), _
                    Utilities.GetTagRequiredManHours(dt_Tags.Rows(i)("MUID")), "0")
            Next


            For i As Integer = 0 To dt_Final.Rows.Count - 1


                query = "SELECT requirements.ManHours,  requirements.FormMUID, requirements.MEManHours" & _
                        " FROM requirements INNER JOIN forms ON requirements.FormMUID = forms.MUID" & _
                        " WHERE requirements.TypeMUID='" + dt_Final.Rows(i)("TypeMUID") + "'"

                Dim dt_Req As DataTable = sqlPrjUtils.ExecuteQuery(query)

                For u As Integer = 0 To dt_Final.Columns.Count - 1
                    For Each dr As DataRow In dt_Req.Rows
                        If dt_Final.Columns(u).ColumnName = dr(1) Then
                            'if form is multi element
                            Dim IsFormME As Boolean = Utilities.IsFormMultiElement(dr(1))

                            If IsFormME Then
                                dt_Final.Rows(i)(u) = dr(2)
                                Dim PackageTagCount As Integer = Utilities.GetTypeMaxTagCount(dr(1), Utilities.GetPackageID(dt_Final.Rows(i)("MUID")))

                                If PackageTagCount > 0 Then
                                    Dim adjustment As Double = Math.Round(dr(0) / PackageTagCount, 2)
                                    dt_Final.Rows(i)("Weighted Package MH") = CDbl(dt_Final.Rows(i)("Weighted Package MH")) + adjustment
                                Else
                                    dt_Final.Rows(i)(u) = dr(0)
                                End If

                            Else
                                dt_Final.Rows(i)(u) = dr(0)
                            End If

                        End If
                    Next
                Next
            Next


            For i As Integer = 0 To dt_Final.Rows.Count - 1
                dt_Final.Rows(i)("Required MH") = CDbl(dt_Final.Rows(i)("Required MH")) + CDbl(dt_Final.Rows(i)("Weighted Package MH"))
            Next




        Catch ex As Exception

        End Try

        Return dt_Final
    End Function


End Class
