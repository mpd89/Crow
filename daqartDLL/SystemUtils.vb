Public Class SystemUtils


    Public Shared Function GetTierDescription(ByVal thisTier As Integer)
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim Description As String = Nothing
        Dim query As String = "SELECT * FROM system_mnemonic WHERE TierNumber='" + thisTier.ToString + "';"
        Try
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            For i As Integer = 0 To dt.Rows.Count - 1
                Description = dt.Rows(i)("Description").ToString
            Next
        Catch ex As Exception
            'MessageBox.Show("Cannot get Tier Description: " + ex.Message)
        Finally
        End Try
        sqlPrjUtils.CloseConnection()

        Return Description
    End Function



End Class
