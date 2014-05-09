Imports System.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Object
Imports System.MarshalByRefObject
Imports System.ComponentModel.Component
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports Microsoft.Win32
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports System.Net
Imports System.IO
Imports System.Data.SqlClient
Imports daqartDLL
Imports System.Threading

Public Class AddReference
    Private Mode As String
    Private ReferenceID As String
    Private FileName As String
    Private FileExtension As String
    'Dim SQLProject As DataUtils


    Public Sub New(ByVal _Mode As String)
        InitializeComponent()
        Mode = _Mode
    End Sub


    Public Sub New(ByVal _Mode As String, ByVal _ReferenceID As String)
        InitializeComponent()
        Mode = _Mode
        ReferenceID = _ReferenceID
    End Sub

    Private Sub AddReference_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim query As String = "SELECT Distinct(Type) FROM ReferenceLibrary ORDER BY Type ASC"
        'SQLProject = New DataUtils("project")
        'SQLProject.OpenConnection()

        Try
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

            Me.cbx_Type.DataSource = dt
            Me.cbx_Type.DisplayMember = dt.Columns(0).ToString
            Me.cbx_Type.ValueMember = dt.Columns(0).ToString
        Catch ex As Exception
            Utilities.logErrorMessage("ReferenceLibrary.AddReference-" + ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If Mode = "edit" Then
            Dim dr As DataRow = Me.GetReference()
            'Me.cbx_Type.Text = dr(2).ToString
            'Me.tbx_Description.Text = dr(4).ToString
            'Me.tbx_Title.Text = dr(3).ToString
            'Me.tbx_Revision.Text = dr(5).ToString

            If Not DBNull.Value.Equals(dr(2)) Then
                Me.cbx_Type.Text = dr(2).ToString
            End If
            If Not DBNull.Value.Equals(dr(4)) Then
                Me.tbx_Description.Text = dr(4).ToString
            End If
            If Not DBNull.Value.Equals(dr(3)) Then
                Me.tbx_Title.Text = dr(3).ToString
            End If
            If Not DBNull.Value.Equals(dr(5)) Then
                Me.tbx_Revision.Text = dr(5).ToString
            End If



            Me.Text = "Edit Reference"
            Me.tbx_FileName.Visible = False
            Me.btn_Browse.Visible = False
        End If
    End Sub


    Private Sub ckbx_Transmittal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbx_Transmittal.CheckedChanged
        If Me.ckbx_Transmittal.Checked Then
            Me.Height = Me.Height + 300
            Me.Label6.Location = New System.Drawing.Point(Me.Label6.Location.X, Me.Label6.Location.Y + 300)
            Me.tbx_FileName.Location = New System.Drawing.Point(Me.tbx_FileName.Location.X, Me.tbx_FileName.Location.Y + 300)
            Me.btn_Browse.Location = New System.Drawing.Point(Me.btn_Browse.Location.X, Me.btn_Browse.Location.Y + 300)
            Me.btn_Cancel.Location = New System.Drawing.Point(Me.btn_Cancel.Location.X, Me.btn_Cancel.Location.Y + 300)
            Me.btn_OK.Location = New System.Drawing.Point(Me.btn_OK.Location.X, Me.btn_OK.Location.Y + 300)
            Me.GroupBox1.Visible = True
        Else
            Me.Height = Me.Height - 300
            Me.Label6.Location = New System.Drawing.Point(Me.Label6.Location.X, Me.Label6.Location.Y - 300)
            Me.tbx_FileName.Location = New System.Drawing.Point(Me.tbx_FileName.Location.X, Me.tbx_FileName.Location.Y - 300)
            Me.btn_Browse.Location = New System.Drawing.Point(Me.btn_Browse.Location.X, Me.btn_Browse.Location.Y - 300)
            Me.btn_Cancel.Location = New System.Drawing.Point(Me.btn_Cancel.Location.X, Me.btn_Cancel.Location.Y - 300)
            Me.btn_OK.Location = New System.Drawing.Point(Me.btn_OK.Location.X, Me.btn_OK.Location.Y - 300)
            Me.GroupBox1.Visible = False
        End If
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub btn_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Browse.Click
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()

        If ofd.FileName = "" Then Return
        Me.tbx_FileName.Text = ofd.FileName

        Dim FI As New FileInfo(ofd.FileName)
        FileName = FI.Name
        FileExtension = FI.Extension
    End Sub


    Private Function InsertRecord()
        Dim newID As Int32 = 0
        Dim strBLOBFilePath As String = Me.tbx_FileName.Text
        If strBLOBFilePath = "" Then Return 0
        Dim fsBLOBFile As New FileStream(strBLOBFilePath, FileMode.Open, FileAccess.Read)
        'Dim fi As New IO.FileInfo(strBLOBFilePath)
        Dim br As New BinaryReader(fsBLOBFile)
        Dim chunk As Byte() = br.ReadBytes(fsBLOBFile.Length)
        Dim connSQL As SqlClient.SqlConnection = Nothing

        Try
            connSQL = connections.serverRemoteConnect(connSQL)
            connSQL.Open()

            Dim cmd As SqlCommand = connSQL.CreateCommand()

            Dim TransmittalQuery As String = Nothing
            Dim TransmittalValues As String = Nothing
            If Me.ckbx_Transmittal.Checked Then
                TransmittalQuery = ",Transmittal,TransmittalNumber,TransmittalDirection,TransmittalDate,TransmittalFromName" + _
                ",TransmittalFromCompany,TransmittalContents,TransmittalMethod,TransmittalToName,TransmittalToCompany" + _
                ",TransmittalToDestination,TransmittalReturnedDate,TransmittalReturnedMethod"

                TransmittalValues += ",'" + Me.ckbx_Transmittal.CheckState + "','" + Me.cbx_TransmittalNumber.Text + "','" + Me.cbx_TransmittalDirection.Text + "',"
                TransmittalValues += "'" + Me.date_TransmittalDate.Text + "','" + Me.cbx_TransmittalFromName.Text + "',"
                TransmittalValues += "'" + Me.cbx_TransmittalFromCompany.Text + "','" + Me.tbx_TransmittalContents.Text + "',"
                TransmittalValues += "'" + Me.cbx_TransmittalMethod.Text + "','" + Me.cbx_TransmittalToName.Text + "',"
                TransmittalValues += "'" + Me.cbx_TransmittalToCompany.Text + "','" + Me.cbx_TransmittalToDestination.Text + "',"
                TransmittalValues += "'" + Me.date_TransmittalReturnedDate.Text + "','" + Me.cbx_TransmittalReturnedMethod.Text + "'"
            Else
                TransmittalQuery = ""
                TransmittalValues = ""
            End If

            cmd.CommandText = "USE [" + runtime.selectedProject + "] " + "INSERT INTO ReferenceLibrary (" + _
                " MUID,TS,Type,Title,Description,Rev,FileName,FileExtension,FileContents" + TransmittalQuery + ") VALUES (" + _
                " '" + idUtils.GetNextMUID("project", "ReferenceLibrary") + "'," + _
                " '" + Now() + "'," + _
                " '" + Me.cbx_Type.Text + "'," + _
                " '" + Me.tbx_Title.Text + "'," + _
                " '" + Me.tbx_Description.Text + "'," + _
                " '" + Me.tbx_Revision.Text + "'," + _
                " '" + FileName + "'," + _
                " '" + FileExtension + "'," + _
                "@FileContents" + TransmittalValues & _
                ")"


            cmd.Parameters.Add("@FileContents", SqlDbType.VarBinary)
            cmd.Parameters("@FileContents").Value = chunk
            newID = Convert.ToInt32(cmd.ExecuteScalar())

            connSQL.Close()
            Return newID
        Catch ex As Exception
            Utilities.logErrorMessage("ReferenceLibrary.AddReference-" + ex.Message)
            Return 0
        End Try
    End Function


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Me.Cursor = Cursors.AppStarting

        If Mode = "edit" Then
            Try
                'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
                Dim query As String = "UPDATE ReferenceLibrary SET " & _
                     " TS=@TS, " & _
                     " Type=@Type, " & _
                     " Title=@Title, " & _
                     " Description=@Description, " & _
                     " Rev=@Rev " & _
                     " WHERE MUID = @MUID"

                Dim dt_param As DataTable = runtime.SQLProject.paramDT
                dt_param.Rows.Add("@TS", Now())
                dt_param.Rows.Add("@Type", Me.cbx_Type.Text)
                dt_param.Rows.Add("@Title", Me.tbx_Title.Text)
                dt_param.Rows.Add("@Description", Me.tbx_Description.Text)
                dt_param.Rows.Add("@Rev", Me.tbx_Revision.Text)
                dt_param.Rows.Add("@MUID", Me.ReferenceID)

                'sqlPrjUtils.OpenConnection()
                runtime.SQLProject.ExecuteNonQuery(query, dt_param)
                'sqlPrjUtils.CloseConnection()

            Catch ex As Exception
                Utilities.logErrorMessage("ReferenceLibrary.AddReference-" + ex.Message)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            InsertRecord()
            'If InsertRecord() > 0 Then
            '    'If (MessageBox.Show("Reference added successfully to server.  Would you like to synchronize now to get a local copy?", "Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes) Then
            '    '    synchronize()
            '    'End If
            'Else
            '    MessageBox.Show("Failed to add reference", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
        End If

        Me.Cursor = Cursors.Default

        Me.Dispose()
    End Sub


    Private Function GetReference() As DataRow
        Dim query As String = "SELECT * FROM ReferenceLibrary WHERE MUID= '" + Me.ReferenceID.ToString + "'"
        'Dim dt As New DataTable

        Try
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

            Return dt.Rows(0)
        Catch ex As Exception
            Utilities.logErrorMessage("ReferenceLibrary.AddReference-" + ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function



End Class