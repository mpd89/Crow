Imports DataStreams.Csv
Imports System.IO
Imports System.Windows.Forms
Imports DaqartDLL

Public Class pkgAuxTemplate
    Public Class ColumnMap
        Private _Num As Integer
        Private _Name As String
        Public Sub New(ByVal Num As Integer, ByVal Name As String)
            _Num = Num
            _Name = Name
        End Sub
        Public Property Num() As Integer
            Get
                Return _Num
            End Get
            Set(ByVal Num As Integer)
                _Num = Num
            End Set
        End Property
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal Name As String)
                _Name = Name
            End Set
        End Property

        '        Public Overrides Function ToString() As String
        '           Return String.Format("{0}---{1}", _Num, _Name)
        '      End Function
    End Class
    Dim csvFile As String = ""
    Dim templateType As String
    Dim fieldNames As New ArrayList
    Dim newLabelTop As Integer = 10
    Dim Panel1 As System.Windows.Forms.Panel

    'Private useProjectDB As String = "USE [" + runtime.selectedProject + "] "
    Public Sub New(ByVal tType As String, ByVal fn As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        templateType = tType
        csvFile = fn
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If btnNext.Text = "OK" Then
            UpdateTemplate()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If

        If Not Panel1 Is Nothing Then
            Panel1.Controls.Clear()
            Panel1.Dispose()
        End If
        Panel1 = New System.Windows.Forms.Panel()
        Dim Height = Me.Height - 200
        Dim Width = Me.Width - 20
        Panel1.Location = New Point(0, 100)
        Panel1.Size = New Size(Width, Height)
        newLabelTop = 10
        Panel1.Visible = True
        'Panel1.Dock = DockStyle.Fill
        Panel1.AutoScroll = True
        Me.Controls.Add(Panel1)
        Panel1.BringToFront()
        For i As Integer = 0 To lvwImportFields.Items.Count - 1
            DrawAuxFields(i, lvwImportFields.Items(i).ToString)
        Next
        Me.lblImportFields.Text = "Import Fields"
        Me.lblCustomName.Text = "Custom Names"
        btnBack.Visible = True
        btnNext.Text = "OK"
        If Me.tbxTemplateName.Text > "" Then
            Me.btnNext.Enabled = True
        Else
            Me.btnNext.Enabled = False
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub tbxTemplateName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxTemplateName.TextChanged
        If tbxTemplateName.Text > "" Then
            btnNext.Enabled = True
        End If
    End Sub
    Private Sub DrawAuxFields(ByVal ThisField As Integer, ByVal s As String)

        Dim labelObject As TextBox = New TextBox()
        With labelObject
            .Name = "Label" + CStr(ThisField)
            .Text = s
            .Visible = True
            .Width = 150
            .Height = 20
            .Left = 30
            .Top = newLabelTop
            .TabStop = False
            .ReadOnly = True
            .BringToFront()
        End With

        Dim tBox = New System.Windows.Forms.TextBox

        With tBox
            .Name = "AuxField" + CStr(ThisField)
            .Tag = "Label" + CStr(ThisField)
            .Visible = True
            .Width = 150
            .Height = 20
            .Left = 200
            .Top = newLabelTop
            '            .MaxLength = 100
            .Text = s
            '            .Visible = False
            '            .SelectedIndex = ThisField
            .BringToFront()

        End With
        Me.Panel1.Controls.Add(labelObject)
        Me.Panel1.Controls.Add(tBox)
        'Me.Controls.Add(labelObject)
        'Me.Controls.Add(FieldComboBox)



        '        AddHandler FieldComboBox.TextChanged, AddressOf FieldComboBox_TextChanged

        newLabelTop = newLabelTop + 20
        '       FieldComboBox.Refresh()
    End Sub


    Private Sub pkgAuxTemplate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BringToFront()
        tbxTemplateType.Text = templateType
        ' Add any initialization after the InitializeComponent() call.
        btnNext.Enabled = False
        tbxTemplateType.Enabled = False
        ImportHeaders()
        btnBack.Visible = False
        btnNext.Enabled = False
        btnNext.Text = "Next"

    End Sub


    Private Sub UpdateTemplate()
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        
        Dim qrySelect = "SELECT MUID FROM aux_template WHERE TemplateName = '" + tbxTemplateName.Text + "'"
        'Dim dt As DataTable = Utilities.ExecuteRemoteQuery(qrySelect, "")
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qrySelect)

        If dt.Rows.Count > 0 Then
            Dim rs As DialogResult = MessageBox.Show("Template already exist. Please rename the template", "Template", MessageBoxButtons.OK)
            sqlPrjUtils.CloseConnection()
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        'Dim idAuxTemplate As Integer = dt.Rows(0)(0)
        Dim qry As String = ""
        Dim templateMUID As String = idUtils.GetNextMUID("project", "aux_Template")
        Dim dt_param As DataTable = sqlPrjUtils.paramDT

        dt_param.Rows.Add("@MUID", templateMUID)
        dt_param.Rows.Add("@TemplateName", tbxTemplateName.Text)
        dt_param.Rows.Add("@Type", templateType)

        qry = "INSERT INTO aux_Template (MUID, TemplateName,Type) " + _
            " VALUES (@MUID, @TemplateName,@Type)"
        sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
        sqlPrjUtils.CloseConnection()

        sqlPrjUtils.OpenConnection()

        For i As Integer = 0 To lvwImportFields.Items.Count - 1
            Dim CustomName As String = ""
            Dim ColName = lvwImportFields.Items(i).ToString
            For Each ctrl As Control In Me.Panel1.Controls
                If ctrl.Name = "AuxField" + i.ToString Then
                    CustomName = ctrl.Text
                    Exit For
                End If
            Next
            qry = "INSERT INTO aux_FieldMap (MUID , TemplateMUID, ColName,CustomName) VALUES (" + _
            "@MUID , @TemplateMUID, @ColName,@CustomName)"

            dt_param = sqlPrjUtils.paramDT

            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "aux_Fieldmap"))
            dt_param.Rows.Add("@TemplateMUID", templateMUID.ToString)
            dt_param.Rows.Add("@ColName", ColName.ToString)
            dt_param.Rows.Add("@CustomName", CustomName.ToString)

            sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
        Next
        sqlPrjUtils.CloseConnection()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Function ImportHeaders() As Boolean
        'Me.Controls.Add(dgv1)

        Dim CSVreader As CsvReader
        CSVreader = New CsvReader(csvFile)
        CSVreader.ReadHeaders()
        lvwCSVFile.Items.Clear()
        lvwImportFields.Items.Clear()
        lvwCSVFile.MultiColumn = False
        lvwImportFields.MultiColumn = False
        lvwCSVFile.SelectionMode = SelectionMode.MultiExtended
        lvwImportFields.SelectionMode = SelectionMode.MultiExtended

        For i As Integer = 0 To CSVreader.HeaderCount - 1
            Dim fldName As String = CSVreader.GetHeader(i)
            If fldName > "" Then
                fieldNames.Add(fldName)
                lvwCSVFile.Items.Add(fldName)
            End If
        Next
        CSVreader.Close()
        Return False
    End Function
    Private Sub MoveRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveRight.Click

        If tbxTemplateName.Text > "" Then
            btnNext.Enabled = True
        End If
        Dim i As Integer
        Try
            For i = 0 To lvwCSVFile.Items.Count - 1
                If lvwCSVFile.GetSelected(i) Then
                    lvwImportFields.Items.Add(lvwCSVFile.Items(i))
                    lvwCSVFile.Items.RemoveAt(i)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub


    Private Sub MoveAllRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveAllRight.Click
        If tbxTemplateName.Text > "" Then
            btnNext.Enabled = True
        End If
        Dim i As Integer
        Try
            For i = 0 To lvwCSVFile.Items.Count - 1
                lvwImportFields.Items.Add(lvwCSVFile.Items(i))
            Next
            lvwCSVFile.Items.Clear()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub MoveLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveLeft.Click
        Dim i As Integer
        Try
            For i = 0 To lvwImportFields.Items.Count - 1
                If lvwImportFields.GetSelected(i) Then
                    lvwCSVFile.Items.Add(lvwImportFields.Items(i))
                    lvwImportFields.Items.RemoveAt(i)
                End If
            Next
        Catch ex As Exception
        End Try
        If tbxTemplateName.Text > "" And lvwImportFields.Items.Count = 0 Then
            btnNext.Enabled = False
        End If
    End Sub


    Private Sub MoveAllLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveAllLeft.Click

        btnNext.Enabled = False
        Dim i As Integer
        Try
            For i = 0 To lvwImportFields.Items.Count - 1
                lvwCSVFile.Items.Add(lvwImportFields.Items(i))
            Next
            lvwImportFields.Items.Clear()
        Catch ex As Exception
        End Try
        If tbxTemplateName.Text > "" And lvwImportFields.Items.Count = 0 Then
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        'Me.SplitContainer1.Panel2.BringToFront()
        Me.lblImportFields.Text = "Import Fields"
        Me.lblCustomName.Text = "Custom Names"
        Panel1.Visible = False
        btnBack.Visible = False
        btnNext.Text = "Next"
    End Sub
End Class
