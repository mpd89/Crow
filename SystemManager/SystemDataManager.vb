Imports daqartDLL


Public Class SystemDataManager


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
            MessageBox.Show("Cannot get Tier Description: " + ex.Message)
        Finally
        End Try
        sqlPrjUtils.CloseConnection()

        Return Description
    End Function


    Public Shared Function IsParent(ByVal thisTier As Integer)
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim result As String = Nothing
        Dim query As String = "SELECT * FROM system_mnemonic WHERE TierNumber='" + thisTier.ToString + "';"
        Try
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            For i As Integer = 0 To dt.Rows.Count - 1
                result = dt.Rows(i)("SubSystem").ToString
            Next
        Catch ex As Exception
            MessageBox.Show("Cannot get Tier IsParent: " + ex.Message)
        Finally
        End Try
        sqlPrjUtils.CloseConnection()

        Return result
    End Function


    Public Shared Function HasParent(ByVal thisTier As Integer)
        thisTier = thisTier - 1
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim result As String = Nothing
        Dim query As String = "SELECT * FROM system_mnemonic WHERE TierNumber='" + thisTier.ToString + "'"
        Try
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            For i As Integer = 0 To dt.Rows.Count - 1
                result = dt.Rows(i)("SubSystem").ToString
            Next
        Catch ex As Exception
            MessageBox.Show("Cannot get Tier HasParent: " + ex.Message)
        Finally
        End Try
        sqlPrjUtils.CloseConnection()

        Return result
    End Function


    Public Shared Function GetSystem(ByVal _SystemMUID As String) As String
        Dim value As String = Nothing
        Dim thisSystem As New SystemSelect(_SystemMUID)
        thisSystem.ShowDialog()

        value = thisSystem.SystemID.Text
        Return value
    End Function


    Public Shared Function TranslateSystemID(ByVal thisSystem As String)
        If IsDBNull(thisSystem) Then
            Return "Undefined"
        End If
        If thisSystem = "" Then
            Return "Undefined"
        End If
        If thisSystem = "Undefined" Then
            Return "Undefined"
        End If

        Dim value As String = Nothing
        Dim systemArray As Array = thisSystem.Split(";")
        Dim tierCount As Integer = systemArray.GetLength(0)

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim Description As String = Nothing
        Dim i As Integer
        For i = 0 To (tierCount - 1)
            Dim query As String = "SELECT sm.MUID,sm.SubSystem,sn.MUID,sn.Identifier,sn.Description, sn.Identifier +''+ sm.sep As showThis " & _
                                " FROM system_mnemonic sm RIGHT JOIN " & _
                                " system_number sn ON sm.TierNumber=sn.TierMUID WHERE sm.TierNumber='" _
                                    + CStr(i + 1) + "' AND sn.MUID='" + systemArray.GetValue(i).ToString + "'"
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            Try
                For j As Integer = 0 To dt.Rows.Count - 1
                    value = value + dt.Rows(j)(5).ToString
                Next

            Catch ex As Exception
                MessageBox.Show("Cannot Translate SystemID: " + ex.Message)
            Finally
            End Try
        Next i
        sqlPrjUtils.CloseConnection()
        If value Is Nothing Then Return "Undefined"


        Return value
    End Function


    Public Shared Function GetSystemList() As DataTable
        Dim query As String
        query = "Select DISTINCT SystemMUID FROM package WHERE SystemMUID != '' AND SystemMUID != 'Undefined'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Dim SystemTable As New DataTable("SystemList")
        If Not dt.Rows.Count = 0 Then
            Dim i As Integer
            For i = 0 To Utilities.CountTiers - 1
                SystemTable.Columns.Add("tier" & i)
            Next

            For Each dr As DataRow In dt.Rows
                If Not IsDBNull(dr("SystemMUID")) Then
                    SystemTable.Rows.Add(Split(dr("SystemMUID"), ";"))
                End If
            Next
        End If


        SystemTable.DefaultView.Sort = "tier1 ASC"

        Return SystemTable.DefaultView.Table
    End Function


    Public Shared Function GetSystemIdentifier(ByVal _MUID As String)
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim result As String = Nothing
        Dim query As String = "SELECT * FROM system_number WHERE MUID='" + _MUID + "';"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)

        Try
            For j As Integer = 0 To dt.Rows.Count - 1
                result = dt.Rows(j)("Identifier").ToString
            Next
        Catch ex As Exception
            MessageBox.Show("Cannot get Tier IsParent: " + ex.Message)
        Finally
        End Try
        sqlPrjUtils.CloseConnection()

        Return result
    End Function


    Public Shared Function GetSystemID(ByVal thisNumber As String, ByVal HasParent As Boolean, ByVal thisTier As String)
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim result As String = Nothing
        Dim query As String = "SELECT MUID FROM system_number WHERE Identifier='" + thisNumber + "' AND TierMUID='" + thisTier + "';"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        Try
            For j As Integer = 0 To dt.Rows.Count - 1
                result = dt.Rows(j)("MUID").ToString
            Next
        Catch ex As Exception
            MessageBox.Show("Cannot get System ID: " + ex.Message)
        Finally
        End Try

        sqlPrjUtils.CloseConnection()
        Return result
    End Function


    Public Shared Function GetSystemID(ByVal _Identifier As String, ByVal _ParentMUID As String)
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim result As String = Nothing
        Dim query As String = "SELECT MUID FROM system_number WHERE Identifier='" + _Identifier + "' AND ParentLinkMUID='" + _ParentMUID + "'"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()
        Try
            For j As Integer = 0 To dt.Rows.Count - 1
                result = dt.Rows(j)("MUID").ToString
            Next
        Catch ex As Exception
            MessageBox.Show("Cannot get SystemID(thisParentID): " + ex.Message)
        Finally
        End Try

        Return result
    End Function


    Public Shared Function GetSystemDescription(ByVal _MUID As String)
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim result As String = Nothing
        Dim query As String = "SELECT * FROM system_number WHERE MUID='" + _MUID + "';"

        Try
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            For j As Integer = 0 To dt.Rows.Count - 1
                result = dt.Rows(j)("Description").ToString
            Next
        Catch ex As Exception
            MessageBox.Show("Cannot get Tier IsParent: " + ex.Message)
        Finally
        End Try
        sqlPrjUtils.CloseConnection()

        Return result
    End Function


    Public Shared Function GetFullSystemDescription(ByVal thisID As String)
        If thisID = "Undefined" Then Return "Undefined"

        Dim result As String = Nothing

        Dim tempArray As Array
        tempArray = Split(thisID, ";")
        If Not tempArray Is Nothing Then
            Dim i As Integer
            For i = 0 To tempArray.Length - 1

                result += GetSystemDescription(tempArray(i))
                If Not i = tempArray.Length - 1 Then
                    result += ">"
                End If
            Next

        End If
        Return result
    End Function


    Public Shared Function SystemValidate(ByVal SystemNumber As String)
        Dim RetVal As Boolean = True
        Dim tmpArray As Array = Split(SystemNumber, ";")
        If Not tmpArray.Length = Utilities.CountTiers Then
            Return False
        End If

        Dim i As Integer
        For i = 0 To Utilities.CountTiers - 1
            'If system number is blank
            If tmpArray(i) = "" Then
                Return False
            End If

            ' If system number does not exist
            If Not TestSystemID(tmpArray(i)) Then
                Return False
            End If

            'If parent link does not exist
            If HasParent(i + 1) Then
                Dim tID As String = GetSystemRecord(tmpArray(i)).Rows(0)(3).ToString
                If Not tmpArray(i - 1) = tID Then
                    Return False
                End If
            End If
        Next

        Return RetVal
    End Function


    Public Shared Function TestSystemID(ByVal _MUID As String)
        Dim query As String = "SELECT * FROM system_number WHERE MUID = '" & _MUID & "'"

        Try
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            sqlPrjUtils.CloseConnection()

            If dt.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
            Return False
        End Try
    End Function


    Public Shared Function GetSystemRecord(ByVal _MUID As String) As DataTable
        Dim query As String = "SELECT * FROM system_number WHERE MUID = '" & _MUID & "'"
        Dim dt As New DataTable

        Try
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            dt = sqlPrjUtils.ExecuteQuery(query)
            sqlPrjUtils.CloseConnection()
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        End Try
        Return dt
    End Function


    Public Shared Function GetSystemPriority(ByVal _MUID As String) As Integer
        Dim query As String = "SELECT MIN(Aux09) FROM package WHERE SystemMUID = '" & _MUID & "'"

        Try
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            sqlPrjUtils.CloseConnection()

            If dt.Rows.Count = 0 Then
                Return 0
            Else
                If IsDBNull(dt.Rows(0)(0)) Then
                    Return 0
                Else
                    Return dt.Rows(0)(0)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
            Return 0
        End Try
    End Function

End Class
