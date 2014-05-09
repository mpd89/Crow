Imports daqartDLL
Imports SystemManager


Public Class PackageDetails
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

        dt_Final.Columns.Add("System#")
        dt_Final.Columns.Add("Package#")
        dt_Final.Columns.Add("Tag#")
        dt_Final.Columns("Tag#").ColumnMapping = MappingType.Hidden
        dt_Final.Columns.Add("Type")
        dt_Final.Columns("Type").ColumnMapping = MappingType.Hidden
        dt_Final.Columns.Add("Description")
        dt_Final.Columns.Add("Priority")
        dt_Final.Columns.Add("Discipline")
        dt_Final.Columns.Add("Audited")
        dt_Final.Columns.Add("GroupID")

        Try
            sqlPrjUtils.OpenConnection()

            Dim query As String
            Dim dt As DataTable

            query = "SELECT tags.MUID, package.PackageNumber, package.SystemMUID, tags.TagNumber, " & _
                    " equipment_type.MUID As TypeMUID, equipment_type.TypeName," & _
                    " engineering_data.Description, package.Aux09 as Priority, package.DisciplineMUID,package.Aux08 As Audited,package.GroupMUID as GroupID FROM tags INNER JOIN" & _
                    " package ON tags.PackageMUID = package.MUID INNER JOIN" & _
                    " equipment_type ON tags.TypeMUID = equipment_type.MUID LEFT OUTER JOIN" & _
                    " engineering_data ON tags.MUID = engineering_data.TagMUID" & _
                    " ORDER BY tags.TagNumber"
            dt_Tags = sqlPrjUtils.ExecuteQuery(query)

            For i As Integer = 0 To dt_Tags.Rows.Count - 1
                dt_Final.Rows.Add(dt_Tags.Rows(i)("MUID"), dt_Tags.Rows(i)("TypeMUID"), SystemManager.SystemDataManager.TranslateSystemID(dt_Tags.Rows(i)("SystemMUID")), dt_Tags.Rows(i)("PackageNumber"), _
                    dt_Tags.Rows(i)("TagNumber"), dt_Tags.Rows(i)("TypeName"), dt_Tags.Rows(i)("Description"), dt_Tags.Rows(i)("Priority"), Utilities.GetDisciplineName(dt_Tags.Rows(i)("DisciplineMUID")), dt_Tags.Rows(i)("Audited"), Utilities.TranslateGroupID(dt_Tags.Rows(i)("GroupID")))
            Next


        Catch ex As Exception

        End Try

        Return dt_Final
    End Function


End Class
