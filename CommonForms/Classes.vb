Imports daqartDLL


Public Class Classes


    Public Shared Function GetPackageID()
        Dim frm_PackageList As New PackageList
        frm_PackageList.ShowDialog()
        Return frm_PackageList.SelectedPackage
    End Function


    Public Shared Function GetPackageName(ByVal _MUID As String)
        Dim query As String = "Select PackageNumber FROM package WHERE MUID='" & _MUID & "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()
        If Not dt.Rows.Count = 0 Then
            Return dt.Rows(0)(0)
        Else
            Return "0"
        End If
    End Function


    Public Shared Function GetPackageID(ByVal PackageNumber As String)
        Dim query As String = "Select MUID FROM package WHERE PackageNumber LIKE '" & PackageNumber & "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()
        If Not dt.Rows.Count = 0 Then
            Return dt.Rows(0)(0)
        Else
            Return "0"
        End If
    End Function


    Public Shared Function SelectTag(ByVal _MUID As String)
        Dim frm_TagList As New Taglist(_MUID)
        frm_TagList.ShowDialog()

        Return frm_TagList.SelectedTag
    End Function


    Public Shared Function GetTagNumber(ByVal _MUID As String)
        Dim query As String = "Select TagNumber FROM tags WHERE MUID='" & _MUID & "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            Return dt.Rows(0)(0)
        Else
            Return "No Data"
        End If
    End Function
    Public Shared Function GetTagMUID(ByVal PackageID As String)

        Dim frm_TagList As New Taglist(PackageID)
        frm_TagList.ShowDialog()

        Return frm_TagList.SelectedTag

    End Function

    Public Shared Function GetLikeTagMUID(ByVal TagNumber As String)
        Dim query As String = "Select MUID FROM tags WHERE TagNumber  LIKE '%" & TagNumber & "%'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            Return dt.Rows(0)(0)
        Else
            Return Nothing
        End If
    End Function


    Public Shared Function GetTagIDList(ByVal TagNumber As String) As DataTable
        Dim query As String = "Select MUID FROM tags WHERE TagNumber  LIKE '%" & TagNumber & "%'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If Not dt.Rows.Count = 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function

End Class
