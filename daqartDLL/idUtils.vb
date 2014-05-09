Imports System
Imports System.Management
Imports System.IO


Public Class idUtils

    Public Shared Function GetMID() As String
        'Dim strProcessorId As String = Nothing
        'Dim query As New SelectQuery("Win32_processor")
        'Dim search As New ManagementObjectSearcher(query)
        'Dim info As ManagementObject

        'Try
        '    For Each info In search.Get()
        '        strProcessorId = info("processorId").ToString()
        '    Next

        '    Dim arDrives() As String
        '    arDrives = Directory.GetLogicalDrives()
        '    Dim drive As String = arDrives(0)
        '    drive = drive.Replace(":\", "")
        '    'If drive = "" OrElse drive Is Nothing Then
        '    drive = "C"
        '    'End If
        '    Dim disk As New ManagementObject("Win32_LogicalDisk.DeviceID=""" + drive + ":""")
        '    disk.[Get]()

        '    Dim MID As String = strProcessorId + "-" + disk("VolumeSerialNumber").ToString()
        '    Return MID
        'Catch ex As Exception

        'End Try

        Return runtime.MID

    End Function


    Public Shared Function GenerateMID() As String
        Dim PASSWORD_CHARS As String = "0abcdefgijkmnopqrstwxyz"
        PASSWORD_CHARS += "ABCDEFGHJKLMNPQRSTWXYZ"
        PASSWORD_CHARS += "23456789"

        Dim seed As Integer
        Dim RandomClass As New Random()

        Dim Part1 As String = Nothing
        For i As Integer = 0 To 15
            seed = RandomClass.Next(1, PASSWORD_CHARS.Length - 1)
            Part1 += Mid(PASSWORD_CHARS, seed, 1)
        Next

        Dim Part2 As String = Nothing
        For i As Integer = 0 To 7
            seed = RandomClass.Next(1, PASSWORD_CHARS.Length - 1)
            Part2 += Mid(PASSWORD_CHARS, seed, 1)
        Next

        Return Part1 + "-" + Part2
    End Function


    Public Shared Function GetNextMUID(ByVal _Database As String, ByVal _Table As String) As String
        Dim query As String = "SELECT MAX(CONVERT(numeric," & _
            " SUBSTRING(MUID," + (runtime.MID.Length + 5).ToString + ",100))) " & _
            " FROM " + _Table + " WHERE MUID LIKE '" + runtime.MID + "%'"
        Dim SQLUtil As New DataUtils(_Database)
        Try
            SQLUtil.OpenConnection()
            Dim dt As DataTable = SQLUtil.ExecuteQuery(query)
            SQLUtil.CloseConnection()

            If Not dt Is Nothing Then
                If Not IsDBNull(dt.Rows(0)(0)) Then
                    Dim NewID As Integer = Convert.ToInt64(dt.Rows(0)(0)) + 1
                    Return runtime.MID + "&001" + NewID.ToString
                Else
                    Return runtime.MID + "&0011"
                End If
            End If

        Catch ex As Exception

        End Try
    End Function


    Public Shared Function GetMUIDSeed(ByVal _Database As String, ByVal _Table As String) As Integer
        Dim query As String = "SELECT MAX(CONVERT(int,SUBSTRING(MUID," + runtime.MID.Length.ToString + ",100))) FROM " + _Table
        Dim SQLUtil As New DataUtils(_Database)

        Try
            SQLUtil.OpenConnection()
            Dim dt As DataTable = SQLUtil.ExecuteQuery(query)
            SQLUtil.CloseConnection()

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Return Convert.ToInt16(dt.Rows(0)(0)) + 1
                Else
                    Return 1
                End If
            End If

        Catch ex As Exception

        End Try
    End Function
End Class
