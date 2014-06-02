Imports System.Data.SqlServerCe
Imports System.Data.SqlClient


Public Class DataUtils

    Dim ThisDB As String
    Dim connSQLCE As SqlCeConnection
    Dim connSQL As SqlClient.SqlConnection
    Dim UseStatement As String
    Dim ThisCabinet As String
    Dim sqlCmd As SqlCommand = Nothing
    Dim sqlCeCmd As SqlCeCommand = Nothing
    Dim connCount As Integer = 0
    Private thisProject As String


    Public Sub New(ByVal _Database As String)
        ThisDB = _Database
        ThisCabinet = ""
        thisProject = runtime.selectedProject
    End Sub


    Public WriteOnly Property ProjectName() As String
        Set(ByVal value As String)
            thisProject = value
        End Set
    End Property


    Public Function OpenConnection() As Boolean
        Try

            If runtime.ConnectionMode = "ONLINE" Then
                Dim connStr As String = Nothing
                ' connStr = "Data Source=""" + runtime.SQLIP + "," + runtime.SQLPort + """;uid=sa;pwd=Al@ska2014"
                connStr = "Data Source=""" + runtime.SQLIP + "," + runtime.SQLPort + """;uid=daqart_sa;pwd=p@ssW0rd"
                connCount = connCount + 1
                Debug.Print("The OpenConnection Count is currently: " + connCount.ToString)
                connSQL = New SqlClient.SqlConnection(connStr)

                'UseStatement = "Use [" + ThisDB + "] "

                If ThisDB = "server" Then
                    UseStatement = "Use [" + runtime.SiteName + "_ServerDB] "
                End If
                If ThisDB = "project" Then
                    UseStatement = "USE [" + thisProject + "] "
                End If
                If ThisDB = "Daqument" Then
                    UseStatement = "Use [" + runtime.SiteName + "_Daqument" + ThisCabinet + "] "
                End If
                If ThisDB = "Daqument001" Then
                    UseStatement = "Use [" + thisProject + "_Daqument001" + ThisCabinet + "] "
                End If
                If ThisDB = "System" Then
                    UseStatement = ""

                   
                End If

                If connSQL.State = ConnectionState.Closed Then
                    connSQL.Open()
                End If

            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                Dim connStr As String = Nothing
                If ThisDB = "server" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.SiteName + "_ServerDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If
                If ThisDB = "project" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + thisProject + ".sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If
                If ThisDB = "Daqument" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.SiteName + "_Daqument.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If
                If ThisDB = "Daqument001" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + thisProject + "_Daqument001.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If

                connSQLCE = New SqlCeConnection(connStr)

                If connSQLCE.State = ConnectionState.Closed Then
                    connSQLCE.Open()
                End If
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("DataUtils.OpenConnection():" + ex.Message)
        End Try

    End Function
    Public Sub AddParameter(ByVal Params As String, ByVal ParamType As System.Data.SqlDbType)
        Try
            If runtime.ConnectionMode = "ONLINE" Then
                sqlCmd.Parameters.Add(Params, ParamType)
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                sqlCeCmd.Parameters.Add(Params, ParamType)
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("DataUtils.AddParameter():" + ex.Message)
        End Try
    End Sub
    Public Sub CreateCommand()
        Try
            If runtime.ConnectionMode = "ONLINE" Then

                sqlCmd = connSQL.CreateCommand()
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                sqlCeCmd = connSQLCE.CreateCommand()
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("DataUtils.CreateCommand():" + ex.Message)
        End Try
    End Sub
    Public Sub CommandText(ByVal text As String)
        Try
            If runtime.ConnectionMode = "ONLINE" Then
                sqlCmd.CommandText = UseStatement + text
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                sqlCeCmd.CommandText = text
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("DataUtils.CreateCommand():" + ex.Message)
        End Try
    End Sub
    Public WriteOnly Property sqlParamValue(ByVal param As String)
        Set(ByVal value)
            Try
                If runtime.ConnectionMode = "ONLINE" Then
                    sqlCmd.Parameters(param).Value = value
                ElseIf runtime.ConnectionMode = "OFFLINE" Then
                    sqlCeCmd.Parameters(param).Value = value
                End If
            Catch ex As Exception
                Dim message As String = ex.Message
                Utilities.logErrorMessage("DataUtils.sqlParamValue():" + ex.Message)
            End Try
        End Set
    End Property

    Public Function CloseConnection() As Boolean
        Try
            If runtime.ConnectionMode = "ONLINE" Then
                If Not sqlCmd Is Nothing Then
                    sqlCmd.Dispose()
                End If
                If Not connSQL.State = ConnectionState.Closed Then
                    connSQL.Close()
                End If
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                If Not sqlCeCmd Is Nothing Then
                    sqlCeCmd.Dispose()
                End If
                If Not connSQLCE.State = ConnectionState.Closed Then
                    connSQLCE.Close()
                End If
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("DataUtils.CloseConnection():" + ex.Message)
        End Try
    End Function

    Public Sub SaveLclSingleParamQuery(ByVal query As String, ByVal param As String, ByVal chunk As Byte())
        Dim lclconnSQLCE As SqlCeConnection
        Dim lclconnStr = "Data Source=""" + runtime.AbsolutePath() + "\ClientDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
        lclconnSQLCE = New SqlCeConnection(lclconnStr)
        lclconnSQLCE.Close()

        If lclconnSQLCE.State = ConnectionState.Closed Then
            lclconnSQLCE.Open()
        End If

        Dim MUIDquery As String = "SELECT MAX(CONVERT(numeric," & _
            " SUBSTRING(MUID," + (runtime.MID.Length + 5).ToString + ",100))) " & _
            " FROM lclquery WHERE MUID LIKE '" + runtime.MID + "%'"

        Dim myAdapter As SqlCeDataAdapter = New SqlCeDataAdapter(MUIDquery, lclconnSQLCE)
        Dim dt As New System.Data.DataTable
        dt.Locale = System.Globalization.CultureInfo.InvariantCulture
        myAdapter.Fill(dt)
        Dim lclMUID As String = runtime.MID + "&0011"
        If Not dt Is Nothing Then
            If Not IsDBNull(dt.Rows(0)(0)) Then
                Dim NewID As Integer = Convert.ToInt64(dt.Rows(0)(0)) + 1
                lclMUID = runtime.MID + "&001" + NewID.ToString
            End If
        End If


        Dim lclquery As String = " INSERT INTO lclquery " + _
                             "(MUID, TS,db,querystring,param,queryimage) " + _
                             " VALUES ('" + lclMUID + _
                             "','" + Now().ToString + _
                             "','" + ThisDB + _
                             "',@querystring,@param,@img)"

        Dim cmd As SqlCeCommand = New SqlCeCommand(lclquery, lclconnSQLCE)
        Try
            cmd.CommandText = lclquery
            cmd.Parameters.Add("@querystring", SqlDbType.NText)
            cmd.Parameters.Add("@param", SqlDbType.NText)
            cmd.Parameters.Add("@img", SqlDbType.Image)
            cmd.Parameters("@querystring").Value = query
            cmd.Parameters("@param").Value = param
            cmd.Parameters("@img").Value = chunk
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("Utilities.ExecuteNonQuery()--lclquery-" + lclquery + "-" + ex.Message)
        End Try
        cmd.Dispose()
        lclconnSQLCE.Close()
    End Sub

    Public Sub SaveLclQuery(ByVal query As String, ByVal _params As DataTable)
        Dim lclconnSQLCE As SqlCeConnection
        Dim lclconnStr = "Data Source=""" + runtime.AbsolutePath() + "\ClientDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
        lclconnSQLCE = New SqlCeConnection(lclconnStr)

        If lclconnSQLCE.State = ConnectionState.Closed Then
            lclconnSQLCE.Open()
        End If

        Dim MUIDquery As String = "SELECT MAX(CONVERT(numeric," & _
            " SUBSTRING(MUID," + (runtime.MID.Length + 5).ToString + ",100))) " & _
            " FROM lclquery WHERE MUID LIKE '" + runtime.MID + "%'"

        Dim myAdapter As SqlCeDataAdapter = New SqlCeDataAdapter(MUIDquery, lclconnSQLCE)
        Dim dt As New System.Data.DataTable
        dt.Locale = System.Globalization.CultureInfo.InvariantCulture
        myAdapter.Fill(dt)
        Dim lclMUID As String = runtime.MID + "&0011"
        If Not dt Is Nothing Then
            If Not IsDBNull(dt.Rows(0)(0)) Then
                Dim NewID As Integer = Convert.ToInt64(dt.Rows(0)(0)) + 1
                lclMUID = runtime.MID + "&001" + NewID.ToString
            End If
        End If

        Try


            Dim lclparams As String = ""
            Dim lclvals As String = ""
            For i As Integer = 0 To _params.Rows.Count - 1
                lclparams = lclparams + _params.Rows(i)(0).ToString + "&002"
            Next
            For i As Integer = 0 To _params.Rows.Count - 1
                lclvals = lclvals + _params.Rows(i)(1).ToString + "&002"
            Next



            lclparams = lclparams.Remove(lclparams.Length - 4, 4)
            lclvals = lclvals.Remove(lclvals.Length - 4, 4)

            Dim lclquery As String = " INSERT INTO lclquery " + _
                                 "(MUID, TS,db,querystring,param,lclvalues) " + _
                                 " VALUES ('" + lclMUID + _
                                 "','" + Now().ToString + _
                                 "','" + ThisDB + _
                                 "',@querystring,@param,@lclvalues)"
            'Dim myCommand As SqlCeCommand = New SqlCeCommand(query, lclconnSQLCE)
            Dim cmd As SqlCeCommand = New SqlCeCommand(lclquery, lclconnSQLCE)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@querystring", SqlDbType.NText)
            cmd.Parameters.Add("@param", SqlDbType.NText)
            cmd.Parameters.Add("@lclvalues", SqlDbType.NText)
            cmd.Parameters("@querystring").Value = query
            cmd.Parameters("@param").Value = lclparams
            cmd.Parameters("@lclvalues").Value = lclvals
            cmd.ExecuteNonQuery()
            lclconnSQLCE.Close()
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("Utilities.ExecuteNonQuery()--lclquery--" + ex.Message)
        End Try
    End Sub


    Public Sub ExecuteNonQuery(ByVal query As String, ByVal _params As DataTable)
        If runtime.ConnectionMode = "ONLINE" Then
            query = UseStatement + query
            'query = "USE [master] " + query
            Dim value As Integer = 0
            If Not connSQL.State = ConnectionState.Open Then
                connSQL.Open()
            End If
            Dim cmd As New SqlClient.SqlCommand(query, connSQL)
            For Each dr As DataRow In _params.Rows
                cmd.Parameters.Add(dr(0), dr(1))
            Next
            cmd.CommandType = CommandType.Text

            Try
                cmd.ExecuteNonQuery()
            Catch ex As SqlClient.SqlException
                Utilities.logErrorMessage("Utilities.ExecuteNonQuery()--" + ex.Message)
                If ex.Number <> 2601 And ex.Number <> 2627 Then
                    value = ex.Number
                Else
                    value = -1
                End If
            Finally
                cmd.Dispose()
            End Try
        ElseIf runtime.ConnectionMode = "OFFLINE" Then
            Try
                'SaveLclQuery(query, _params)
                If Not connSQLCE.State = ConnectionState.Open Then
                    connSQLCE.Open()
                End If
                Dim myCommand As SqlCeCommand = New SqlCeCommand(query, connSQLCE)
                For Each dr As DataRow In _params.Rows
                    myCommand.Parameters.Add(dr(0), dr(1))
                Next
                myCommand.CommandType = CommandType.Text

                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                Dim message As String = ex.Message
                Utilities.logErrorMessage("Utilities.ExecuteNonQuery()--query-" + query + "-" + ex.Message)
                'Throw ex
            Finally

            End Try
        End If
    End Sub


    Public Function ExecuteQuery(ByVal query As String) As System.Data.DataTable
        Dim table As New System.Data.DataTable
        Try
            If runtime.ConnectionMode = "ONLINE" Then
                query = UseStatement + query
                Dim value As Boolean = False
                Dim cmd As New SqlClient.SqlCommand(query, connSQL)
                cmd.CommandType = CommandType.Text
                Dim myAdapter As SqlDataAdapter = New SqlDataAdapter(query, connSQL)
                table.Locale = System.Globalization.CultureInfo.InvariantCulture
                myAdapter.Fill(table)
                cmd.Dispose()
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                If Not connSQLCE.State = ConnectionState.Open Then
                    connSQLCE.Open()
                End If
                Dim myAdapter As SqlCeDataAdapter = New SqlCeDataAdapter(query, connSQLCE)
                table.Locale = System.Globalization.CultureInfo.InvariantCulture
                myAdapter.Fill(table)
            End If

        Catch ex As Exception
            Utilities.logErrorMessage("Utilities.ExecuteQuery()--query-" + query + "-" + ex.Message)
            'MessageBox.Show(ErrString + ": " + ex.Message)
        End Try
        Return table
    End Function

    'Public Function ExecuteScalar(ByVal query As String) As Integer
    '    Dim newID As Integer = 0
    '    Try
    '        If runtime.ConnectionMode = "ONLINE" Then
    '            query = UseStatement + query
    '            Dim cmd As New SqlClient.SqlCommand(query + "; select SCOPE_IDENTITY() ", connSQL)
    '            cmd.CommandType = CommandType.Text
    '            Dim ret = cmd.ExecuteScalar()
    '            If Not IsDBNull(ret) Then
    '                newID = Convert.ToInt32(ret)
    '            End If
    '            cmd.Dispose()
    '        ElseIf runtime.ConnectionMode = "OFFLINE" Then
    '            If Not connSQLCE.State = ConnectionState.Open Then
    '                connSQLCE.Open()
    '            End If
    '            Dim cmd As SqlCeCommand = New SqlCeCommand(query, connSQLCE)

    '            newID = cmd.ExecuteScalar()

    '            Dim cmd1 As SqlCeCommand = New SqlCeCommand(" select @@IDENTITY ", connSQLCE)
    '            Dim ret = cmd1.ExecuteScalar()
    '            If Not IsDBNull(ret) Then
    '                newID = Convert.ToInt32(ret)
    '            End If

    '            cmd.Dispose()
    '            cmd1.Dispose()
    '        End If
    '    Catch ex As Exception
    '        Utilities.logErrorMessage("Utilities.ExecuteScalar()--query-" + query)
    '        'MessageBox.Show(ErrString + ": " + ex.Message)
    '    End Try
    '    Return newID
    'End Function
    Public Sub ExecuteSingleParameterizedQuery(ByVal query As String, ByVal param As String, ByVal chunk As Byte())
        Try
            If runtime.ConnectionMode = "ONLINE" Then
                query = UseStatement + query
                Dim cmd As New SqlClient.SqlCommand(query, connSQL)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add(param, SqlDbType.VarBinary)
                cmd.Parameters(param).Value = chunk
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                'SaveLclSingleParamQuery(query, param, chunk)
                Dim cmd As SqlCeCommand = New SqlCeCommand(query, connSQLCE)
                cmd.CommandText = query
                cmd.Parameters.Add(param, SqlDbType.Image)
                cmd.Parameters(param).Value = chunk
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("Utilities.ExecuteNonQuery()--query-" + query + "-" + ex.Message)
            'Throw ex
        End Try
    End Sub

    'Public Function ExecuteParameterScalar() As Integer
    '    Dim newID As Integer = 0
    '    Dim query As String
    '    Try
    '        If runtime.ConnectionMode = "ONLINE" Then
    '            query = sqlCmd.CommandText()
    '            newID = sqlCmd.ExecuteScalar()
    '        ElseIf runtime.ConnectionMode = "OFFLINE" Then
    '            query = sqlCeCmd.CommandText()
    '            newID = sqlCeCmd.ExecuteScalar()
    '        End If
    '    Catch ex As Exception
    '        Utilities.logErrorMessage("Utilities.ExecuteScalar()--query-" + query)
    '        'MessageBox.Show(ErrString + ": " + ex.Message)
    '    End Try
    '    Return newID
    'End Function

    Function paramDT() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("field_name")
        dt.Columns.Add("field_value")

        Return dt
    End Function


End Class


Public Class DataUtilsGlobal
    Dim ThisDB As String
    Dim connSQLCE As SqlCeConnection
    Dim connSQL As SqlClient.SqlConnection
    Dim UseStatement As String
    Dim ThisCabinet As String
    Dim sqlCmd As SqlCommand = Nothing
    Dim sqlCeCmd As SqlCeCommand = Nothing

    Private thisProject As String


    Public Sub New(ByVal _Database As String)
        ThisDB = _Database
        ThisCabinet = ""
        thisProject = runtime.selectedProject
    End Sub


    'Public Sub New(ByVal _Database As String, ByVal _ThisCabinet As String)
    '    ThisDB = _Database
    '    ThisCabinet = _ThisCabinet
    '    thisProject = runtime.selectedProject
    'End Sub

    Public WriteOnly Property ProjectName() As String
        Set(ByVal value As String)
            thisProject = value
        End Set
    End Property

    Public Function OpenConnection() As Boolean
        Try

            If runtime.ConnectionMode = "ONLINE" Then
                Dim connStr As String = Nothing
                '  connStr = "Data Source=""" + runtime.SQLIP + "," + runtime.SQLPort + """;uid=sa;pwd=Al@ska2014"
                connStr = "Data Source=""" + runtime.SQLIP + "," + runtime.SQLPort + """;uid=daqart_sa;pwd=p@ssW0rd"
                Debug.Print("string in datautilsglobal is " + connStr)

                connSQL = New SqlClient.SqlConnection(connStr)

                'UseStatement = "Use [" + ThisDB + "] "

                If ThisDB = "server" Then
                    UseStatement = "Use [" + runtime.SiteName + "_ServerDB] "
                End If
                If ThisDB = "project" Then
                    UseStatement = "USE [" + thisProject + "] "
                End If
                If ThisDB = "Daqument" Then
                    UseStatement = "Use [" + runtime.SiteName + "_Daqument" + ThisCabinet + "] "
                End If
                If ThisDB = "Daqument001" Then
                    UseStatement = "Use [" + thisProject + "_Daqument001" + ThisCabinet + "] "
                End If
                If ThisDB = "System" Then
                    UseStatement = ""
                End If

                If connSQL.State = ConnectionState.Closed Then
                    connSQL.Open()
                End If

            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                Dim connStr As String = Nothing
                If ThisDB = "server" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.SiteName + "_ServerDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If
                If ThisDB = "project" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + thisProject + ".sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If
                If ThisDB = "Daqument" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + runtime.SiteName + "_Daqument.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If
                If ThisDB = "Daqument001" Then
                    connStr = "Data Source=""" + runtime.AbsolutePath() + "Sites\" + runtime.SiteName + "\" + thisProject + "_Daqument001.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
                End If

                connSQLCE = New SqlCeConnection(connStr)

                If connSQLCE.State = ConnectionState.Closed Then
                    connSQLCE.Open()
                End If
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("DataUtils.OpenConnection():" + ex.Message)
        End Try

    End Function
    Public Sub AddParameter(ByVal Params As String, ByVal ParamType As System.Data.SqlDbType)
        Try
            If runtime.ConnectionMode = "ONLINE" Then
                sqlCmd.Parameters.Add(Params, ParamType)
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                sqlCeCmd.Parameters.Add(Params, ParamType)
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("DataUtils.AddParameter():" + ex.Message)
        End Try
    End Sub
    Public Sub CreateCommand()
        Try
            If runtime.ConnectionMode = "ONLINE" Then

                sqlCmd = connSQL.CreateCommand()
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                sqlCeCmd = connSQLCE.CreateCommand()
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("DataUtils.CreateCommand():" + ex.Message)
        End Try
    End Sub
    Public Sub CommandText(ByVal text As String)
        Try
            If runtime.ConnectionMode = "ONLINE" Then
                sqlCmd.CommandText = UseStatement + text
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                sqlCeCmd.CommandText = text
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("DataUtils.CreateCommand():" + ex.Message)
        End Try
    End Sub
    Public WriteOnly Property sqlParamValue(ByVal param As String)
        Set(ByVal value)
            Try
                If runtime.ConnectionMode = "ONLINE" Then
                    sqlCmd.Parameters(param).Value = value
                ElseIf runtime.ConnectionMode = "OFFLINE" Then
                    sqlCeCmd.Parameters(param).Value = value
                End If
            Catch ex As Exception
                Dim message As String = ex.Message
                Utilities.logErrorMessage("DataUtils.sqlParamValue():" + ex.Message)
            End Try
        End Set
    End Property

    Public Function CloseConnection() As Boolean
        Try
            If runtime.ConnectionMode = "ONLINE" Then
                If Not sqlCmd Is Nothing Then
                    sqlCmd.Dispose()
                End If
                If Not connSQL.State = ConnectionState.Closed Then
                    connSQL.Close()
                End If
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                If Not sqlCeCmd Is Nothing Then
                    sqlCeCmd.Dispose()
                End If
                If Not connSQLCE.State = ConnectionState.Closed Then
                    connSQLCE.Close()
                End If
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("DataUtils.CloseConnection():" + ex.Message)
        End Try
    End Function

    Public Sub SaveLclSingleParamQuery(ByVal query As String, ByVal param As String, ByVal chunk As Byte())
        Dim lclconnSQLCE As SqlCeConnection
        Dim lclconnStr = "Data Source=""" + runtime.AbsolutePath() + "\ClientDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
        lclconnSQLCE = New SqlCeConnection(lclconnStr)
        lclconnSQLCE.Close()

        If lclconnSQLCE.State = ConnectionState.Closed Then
            lclconnSQLCE.Open()
        End If

        Dim MUIDquery As String = "SELECT MAX(CONVERT(numeric," & _
            " SUBSTRING(MUID," + (runtime.MID.Length + 5).ToString + ",100))) " & _
            " FROM lclquery WHERE MUID LIKE '" + runtime.MID + "%'"

        Dim myAdapter As SqlCeDataAdapter = New SqlCeDataAdapter(MUIDquery, lclconnSQLCE)
        Dim dt As New System.Data.DataTable
        dt.Locale = System.Globalization.CultureInfo.InvariantCulture
        myAdapter.Fill(dt)
        Dim lclMUID As String = runtime.MID + "&0011"
        If Not dt Is Nothing Then
            If Not IsDBNull(dt.Rows(0)(0)) Then
                Dim NewID As Integer = Convert.ToInt64(dt.Rows(0)(0)) + 1
                lclMUID = runtime.MID + "&001" + NewID.ToString
            End If
        End If


        Dim lclquery As String = " INSERT INTO lclquery " + _
                             "(MUID, TS,db,querystring,param,queryimage) " + _
                             " VALUES ('" + lclMUID + _
                             "','" + Now().ToString + _
                             "','" + ThisDB + _
                             "',@querystring,@param,@img)"

        Dim cmd As SqlCeCommand = New SqlCeCommand(lclquery, lclconnSQLCE)
        Try
            cmd.CommandText = lclquery
            cmd.Parameters.Add("@querystring", SqlDbType.NText)
            cmd.Parameters.Add("@param", SqlDbType.NText)
            cmd.Parameters.Add("@img", SqlDbType.Image)
            cmd.Parameters("@querystring").Value = query
            cmd.Parameters("@param").Value = param
            cmd.Parameters("@img").Value = chunk
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("Utilities.ExecuteNonQuery()--lclquery-" + lclquery + "-" + ex.Message)
        End Try
        cmd.Dispose()
        lclconnSQLCE.Close()
    End Sub

    Public Sub SaveLclQuery(ByVal query As String, ByVal _params As DataTable)
        Dim lclconnSQLCE As SqlCeConnection
        Dim lclconnStr = "Data Source=""" + runtime.AbsolutePath() + "\ClientDB.sdf"";Max Database Size=4090;Default Lock Escalation =100;"
        lclconnSQLCE = New SqlCeConnection(lclconnStr)

        If lclconnSQLCE.State = ConnectionState.Closed Then
            lclconnSQLCE.Open()
        End If

        Dim MUIDquery As String = "SELECT MAX(CONVERT(numeric," & _
            " SUBSTRING(MUID," + (runtime.MID.Length + 5).ToString + ",100))) " & _
            " FROM lclquery WHERE MUID LIKE '" + runtime.MID + "%'"

        Dim myAdapter As SqlCeDataAdapter = New SqlCeDataAdapter(MUIDquery, lclconnSQLCE)
        Dim dt As New System.Data.DataTable
        dt.Locale = System.Globalization.CultureInfo.InvariantCulture
        myAdapter.Fill(dt)
        Dim lclMUID As String = runtime.MID + "&0011"
        If Not dt Is Nothing Then
            If Not IsDBNull(dt.Rows(0)(0)) Then
                Dim NewID As Integer = Convert.ToInt64(dt.Rows(0)(0)) + 1
                lclMUID = runtime.MID + "&001" + NewID.ToString
            End If
        End If

        Try


            Dim lclparams As String = ""
            Dim lclvals As String = ""
            For i As Integer = 0 To _params.Rows.Count - 1
                lclparams = lclparams + _params.Rows(i)(0).ToString + "&002"
            Next
            For i As Integer = 0 To _params.Rows.Count - 1
                lclvals = lclvals + _params.Rows(i)(1).ToString + "&002"
            Next



            lclparams = lclparams.Remove(lclparams.Length - 4, 4)
            lclvals = lclvals.Remove(lclvals.Length - 4, 4)

            Dim lclquery As String = " INSERT INTO lclquery " + _
                                 "(MUID, TS,db,querystring,param,lclvalues) " + _
                                 " VALUES ('" + lclMUID + _
                                 "','" + Now().ToString + _
                                 "','" + ThisDB + _
                                 "',@querystring,@param,@lclvalues)"
            'Dim myCommand As SqlCeCommand = New SqlCeCommand(query, lclconnSQLCE)
            Dim cmd As SqlCeCommand = New SqlCeCommand(lclquery, lclconnSQLCE)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@querystring", SqlDbType.NText)
            cmd.Parameters.Add("@param", SqlDbType.NText)
            cmd.Parameters.Add("@lclvalues", SqlDbType.NText)
            cmd.Parameters("@querystring").Value = query
            cmd.Parameters("@param").Value = lclparams
            cmd.Parameters("@lclvalues").Value = lclvals
            cmd.ExecuteNonQuery()
            lclconnSQLCE.Close()
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("Utilities.ExecuteNonQuery()--lclquery--" + ex.Message)
        End Try
    End Sub


    Public Sub ExecuteNonQuery(ByVal query As String, ByVal _params As DataTable)
        If runtime.ConnectionMode = "ONLINE" Then
            query = UseStatement + query
            'query = "USE [master] " + query
            Dim value As Integer = 0
            If Not connSQL.State = ConnectionState.Open Then
                connSQL.Open()
            End If
            Dim cmd As New SqlClient.SqlCommand(query, connSQL)
            For Each dr As DataRow In _params.Rows
                cmd.Parameters.Add(dr(0), dr(1))
            Next
            cmd.CommandType = CommandType.Text

            Try
                cmd.ExecuteNonQuery()
            Catch ex As SqlClient.SqlException
                Utilities.logErrorMessage("Utilities.ExecuteNonQuery()--" + ex.Message)
                If ex.Number <> 2601 And ex.Number <> 2627 Then
                    value = ex.Number
                Else
                    value = -1
                End If
            Finally
                cmd.Dispose()
            End Try
        ElseIf runtime.ConnectionMode = "OFFLINE" Then
            Try
                'SaveLclQuery(query, _params)
                If Not connSQLCE.State = ConnectionState.Open Then
                    connSQLCE.Open()
                End If
                Dim myCommand As SqlCeCommand = New SqlCeCommand(query, connSQLCE)
                For Each dr As DataRow In _params.Rows
                    myCommand.Parameters.Add(dr(0), dr(1))
                Next
                myCommand.CommandType = CommandType.Text

                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                Dim message As String = ex.Message
                Utilities.logErrorMessage("Utilities.ExecuteNonQuery()--query-" + query + "-" + ex.Message)
                'Throw ex
            Finally

            End Try
        End If
    End Sub


    Public Function ExecuteQuery(ByVal query As String) As System.Data.DataTable
        Dim table As New System.Data.DataTable
        Try
            If runtime.ConnectionMode = "ONLINE" Then
                query = UseStatement + query
                Dim value As Boolean = False
                Dim cmd As New SqlClient.SqlCommand(query, connSQL)
                cmd.CommandType = CommandType.Text
                Dim myAdapter As SqlDataAdapter = New SqlDataAdapter(query, connSQL)
                table.Locale = System.Globalization.CultureInfo.InvariantCulture
                myAdapter.Fill(table)
                cmd.Dispose()
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                If Not connSQLCE.State = ConnectionState.Open Then
                    connSQLCE.Open()
                End If
                Dim myAdapter As SqlCeDataAdapter = New SqlCeDataAdapter(query, connSQLCE)
                table.Locale = System.Globalization.CultureInfo.InvariantCulture
                myAdapter.Fill(table)
            End If

        Catch ex As Exception
            Utilities.logErrorMessage("Utilities.ExecuteQuery()--query-" + query + "-" + ex.Message)
            'MessageBox.Show(ErrString + ": " + ex.Message)
        End Try
        Return table
    End Function

    'Public Function ExecuteScalar(ByVal query As String) As Integer
    '    Dim newID As Integer = 0
    '    Try
    '        If runtime.ConnectionMode = "ONLINE" Then
    '            query = UseStatement + query
    '            Dim cmd As New SqlClient.SqlCommand(query + "; select SCOPE_IDENTITY() ", connSQL)
    '            cmd.CommandType = CommandType.Text
    '            Dim ret = cmd.ExecuteScalar()
    '            If Not IsDBNull(ret) Then
    '                newID = Convert.ToInt32(ret)
    '            End If
    '            cmd.Dispose()
    '        ElseIf runtime.ConnectionMode = "OFFLINE" Then
    '            If Not connSQLCE.State = ConnectionState.Open Then
    '                connSQLCE.Open()
    '            End If
    '            Dim cmd As SqlCeCommand = New SqlCeCommand(query, connSQLCE)

    '            newID = cmd.ExecuteScalar()

    '            Dim cmd1 As SqlCeCommand = New SqlCeCommand(" select @@IDENTITY ", connSQLCE)
    '            Dim ret = cmd1.ExecuteScalar()
    '            If Not IsDBNull(ret) Then
    '                newID = Convert.ToInt32(ret)
    '            End If

    '            cmd.Dispose()
    '            cmd1.Dispose()
    '        End If
    '    Catch ex As Exception
    '        Utilities.logErrorMessage("Utilities.ExecuteScalar()--query-" + query)
    '        'MessageBox.Show(ErrString + ": " + ex.Message)
    '    End Try
    '    Return newID
    'End Function
    Public Sub ExecuteSingleParameterizedQuery(ByVal query As String, ByVal param As String, ByVal chunk As Byte())
        Try
            If runtime.ConnectionMode = "ONLINE" Then
                query = UseStatement + query
                Dim cmd As New SqlClient.SqlCommand(query, connSQL)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.Add(param, SqlDbType.VarBinary)
                cmd.Parameters(param).Value = chunk
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            ElseIf runtime.ConnectionMode = "OFFLINE" Then
                'SaveLclSingleParamQuery(query, param, chunk)
                Dim cmd As SqlCeCommand = New SqlCeCommand(query, connSQLCE)
                cmd.CommandText = query
                cmd.Parameters.Add(param, SqlDbType.Image)
                cmd.Parameters(param).Value = chunk
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
            Utilities.logErrorMessage("Utilities.ExecuteNonQuery()--query-" + query + "-" + ex.Message)
            'Throw ex
        End Try
    End Sub

    'Public Function ExecuteParameterScalar() As Integer
    '    Dim newID As Integer = 0
    '    Dim query As String
    '    Try
    '        If runtime.ConnectionMode = "ONLINE" Then
    '            query = sqlCmd.CommandText()
    '            newID = sqlCmd.ExecuteScalar()
    '        ElseIf runtime.ConnectionMode = "OFFLINE" Then
    '            query = sqlCeCmd.CommandText()
    '            newID = sqlCeCmd.ExecuteScalar()
    '        End If
    '    Catch ex As Exception
    '        Utilities.logErrorMessage("Utilities.ExecuteScalar()--query-" + query)
    '        'MessageBox.Show(ErrString + ": " + ex.Message)
    '    End Try
    '    Return newID
    'End Function

    Function paramDT() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("field_name")
        dt.Columns.Add("field_value")

        Return dt
    End Function


End Class
