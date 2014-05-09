Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.SqlServerCe
Imports System.Threading
Imports IMAGECONVERTERLib
Imports System.IO
Imports System.Text
Imports daqartDLL
Imports CommonForms
Imports System.Collections.Generic
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices


Public Class ViewAssociations
    Private DocumentMUID As String
    Private DocumentName As String
    Private SelectedTag
    Dim ImageExists As Boolean
    Dim OriginalImage As Image
    Dim NewImage As Boolean = False
    Private ProjectSQL As New DataUtils("project")
    Private DaqumentSQL As New DataUtils("Daqument")
    Private Daqument001SQL As New DataUtils("Daqument001")


    Public Sub New(ByVal _DocumentMUID As String)
        InitializeComponent()

        DocumentMUID = _DocumentMUID
    End Sub


    Private Sub ViewAssociations_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ProjectSQL.CloseConnection()
        DaqumentSQL.CloseConnection()
        Daqument001SQL.CloseConnection()
    End Sub


    Private Sub ViewAssociations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProjectSQL.OpenConnection()
        DaqumentSQL.OpenConnection()
        Daqument001SQL.OpenConnection()

        Dim query As String = "SELECT * FROM documents WHERE MUID='" + DocumentMUID + "'"
        Dim dt As DataTable = ProjectSQL.ExecuteQuery(query)


        LoadImage()
        LoadAssociations()
    End Sub


    Private Sub LoadImage()
        Try
            Dim query As String = "select * from document_store  where DocumentMUID = '" + DocumentMUID + "'"
            Dim dt As DataTable = Daqument001SQL.ExecuteQuery(query)

            ImageExists = False

            If dt Is Nothing Then Return

            If dt.Rows.Count > 0 Then
                Dim imagedata() As Byte
                Dim imageBytedata As MemoryStream
                imagedata = dt.Rows(0)("DocumentImage")
                imageBytedata = New MemoryStream(imagedata)
                OriginalImage = Image.FromStream(imageBytedata)

                ImageExists = True
                ipw_Image.pbx_Image.Image = OriginalImage
                ipw_Image.ImageLoaded()
            End If
        Catch ex As Exception
            Utilities.logErrorMessage("ViewAssociations.ViewAssociations_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub LoadTags(ByVal _PackageMUID As String)
        Try
            Dim query As String = "SELECT * FROM tags WHERE PackageMUID='" + _PackageMUID + "' ORDER BY TagNumber ASC"
            Dim dt As DataTable = ProjectSQL.ExecuteQuery(query)

            Dim dt_Master As New DataTable
            dt_Master.Columns.Add("MUID")
            dt_Master.Columns.Add("TagNumber")
            dt_Master.Rows.Add("0", "*")

            For Each dr As DataRow In dt.Rows
                dt_Master.Rows.Add(dr("MUID"), dr("TagNumber"))
            Next

            Me.cbx_Tags.DataSource = dt_Master
            Me.cbx_Tags.DisplayMember = dt_Master.Columns("TagNumber").ToString
            Me.cbx_Tags.ValueMember = dt_Master.Columns("MUID").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub LoadAssociations()
        Try
            Dim query As String = "SELECT package_documents.MUID, package.PackageNumber, tags.TagNumber" & _
                " FROM package_documents LEFT OUTER JOIN" & _
                " package ON package_documents.PackageMUID = package.MUID LEFT OUTER JOIN" & _
                " tags ON package_documents.TagMUID = tags.MUID" & _
                " WHERE package_documents.DocumentMUID = '" + DocumentMUID + "'"
            Dim dt As DataTable = ProjectSQL.ExecuteQuery(query)

            Dim dt_Master As New DataTable
            dt_Master.Columns.Add("MUID")
            dt_Master.Columns.Add("Reference")

            For Each dr As DataRow In dt.Rows
                Dim _Tag As String

                If IsDBNull(dr("TagNumber")) Then
                    _Tag = "*"
                Else
                    _Tag = dr("TagNumber")
                End If

                Dim reference As String = dr("PackageNumber") + "  (" + _Tag + ")"
                dt_Master.Rows.Add(dr("MUID"), reference)
            Next

            Me.lbx_References.DataSource = dt_Master
            Me.lbx_References.DisplayMember = dt_Master.Columns("Reference").ToString
            Me.lbx_References.ValueMember = dt_Master.Columns("MUID").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub tbx_Package_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_Package.Click
        Dim frm_PackageSelect As New PackageList
        frm_PackageSelect.ShowDialog()

        Me.tbx_Package.Text = PackageList.SelectedPackage
        Me.tbx_Package.Tag = PackageList.SelectedPackageMUID

        If Me.tbx_Package.Text = "" Then Return

        LoadTags(Me.tbx_Package.Tag)

        If Me.cbx_Tags.Text = "" And Me.tbx_Package.Text = "" Then
            Me.btn_Add.Enabled = False
        Else
            Me.btn_Add.Enabled = True
        End If
    End Sub


    Private Sub tbx_Package_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_Package.TextChanged
        If Me.cbx_Tags.Text = "" And Me.tbx_Package.Text = "" Then
            Me.btn_Add.Enabled = False
        Else
            Me.btn_Add.Enabled = True
        End If
    End Sub


    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        Try
            Dim query As String = "SELECT * FROM package_documents WHERE " & _
                " PackageMUID = '" + Me.tbx_Package.Tag + "'" & _
                " AND DocumentMUID = '" + Me.DocumentMUID + "'"
            Dim dt As DataTable = ProjectSQL.ExecuteQuery(query)

            If dt.Rows.Count > 0 Then
                If Not dt.Rows(0)("TagMUID") = Me.cbx_Tags.SelectedValue Then
                    query = "UPDATE package_documents SET " & _
                        "TagMUID='0' WHERE MUID='" + dt.Rows(0)("MUID") + "'"
                    Dim dt_param As DataTable = ProjectSQL.paramDT
                    ProjectSQL.ExecuteNonQuery(query, dt_param)
                End If
            Else
                query = "INSERT INTO package_documents (MUID,TS,DocumentMUID,PackageMUID,Notes,TagMUID,SystemMUID) " & _
        "Values (@MUID,@TS,@DocumentMUID,@PackageMUID,@Notes,@TagMUID,@SystemMUID)"
                Dim dt_param As DataTable = ProjectSQL.paramDT

                dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "Package_documents"))
                dt_param.Rows.Add("@TS", DateTime.Now.ToString)
                dt_param.Rows.Add("@DocumentMUID", Me.DocumentMUID)
                dt_param.Rows.Add("@PackageMUID", Me.tbx_Package.Tag)
                dt_param.Rows.Add("@Notes", tbx_Notes.Text)
                dt_param.Rows.Add("@TagMUID", cbx_Tags.SelectedValue)
                dt_param.Rows.Add("@SystemMUID", Utilities.GetPackageSystem(Me.tbx_Package.Tag))

                ProjectSQL.ExecuteNonQuery(query, dt_param)
            End If

            LoadAssociations()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub cbx_Tags_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbx_Tags.SelectedIndexChanged
        If Me.cbx_Tags.Text = "" And Me.tbx_Package.Text = "" Then
            Me.btn_Add.Enabled = False
        Else
            Me.btn_Add.Enabled = True
        End If
    End Sub


    Private Sub DeleteReferenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteReferenceToolStripMenuItem.Click
        Try
            If MessageBox.Show("Are you sure you want to delete this reference?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM package_documents WHERE MUID=@MUID"
                Dim dt_param As DataTable = ProjectSQL.paramDT
                dt_param.Rows.Add("@MUID", Me.lbx_References.SelectedValue)

                ProjectSQL.ExecuteNonQuery(query, dt_param)
            End If

            LoadAssociations()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


End Class