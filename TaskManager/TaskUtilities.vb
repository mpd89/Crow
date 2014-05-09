'Imports System.Data.SqlServerCe
Imports daqartDLL

Public Class TaskUtilities

    Public Shared Function GetBaseMH(ByVal TaskID As Integer) As Double
        Dim query As String
        'Dim dt As New DataTable

        query = "Select BaseManHours FROM TaskList WHERE taskid = '" & TaskID & "'"
        'dt = Utilities.ExecuteQuery(query, "project")

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If IsDBNull(dt.Rows(0)(0)) Then
            Return 0
        End If

        If Not dt.Rows.Count = 0 Then
            Return dt.Rows(0)(0)
        Else
            Return 0
        End If
    End Function


    Public Shared Function GetBaseQTY(ByVal TaskID As Integer) As Double
        Dim query As String
        'Dim dt As New DataTable

        query = "Select BaseQuantity FROM TaskList WHERE taskid = '" & TaskID & "'"
        'dt = Utilities.ExecuteQuery(query, "project")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If IsDBNull(dt.Rows(0)(0)) Then
            Return 0
        End If
        If Not dt.Rows.Count = 0 Then
            Return dt.Rows(0)(0)
        Else
            Return 0
        End If
    End Function


End Class
