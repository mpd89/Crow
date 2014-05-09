Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports daqartDLL
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Drawing.Graphics
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.Utils

Public Class FormView
    Private _FormName As String
    Private _FormID As String
    Private _FormTagID As String
    Private _FormRequirementID As String
    Private _FormOwnerID As String
    Private _FormTagName As String
    Private _FormTypeID As String
    Private _FormReadOnly As Integer = True
    Private _FormImages As List(Of Image)
    Private _FormPanelSize As Size
    Private _FormResizeImages As List(Of Image)
    Private _FormVarTextBox As New List(Of TextBox)
    Private Magnification As Single = 1
    Private CurrentPage As Integer = 0
    Private myForm As FormUtils
    Friend WithEvents VGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
    'Private connProject As SqlCeConnection = daqartDLL.connections.projectDBConnect(connProject)
    Private printDoc As PrintDocument
    Private printDialog As PrintPreviewDialog
    Private intPageCounter As Integer
    '    Private pkgUtil As PackageUtils = New PackageUtils()
    Dim imgdir As String = runtime.AbsolutePath + "sites\Forms\images\imgList"

    Private MultiElement As Boolean
    Private NumberofElements As Integer
    Private PackageID As String
    Private SelectedField As String



    Public Enum ActionType
        Undefined
        Submit
        Reject
        Accept
        CancelSubmit
    End Enum



    Public Sub New(ByVal ThisFormID As String, ByVal ThisTagID As String, ByVal ThisOwnerID As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        _FormID = ThisFormID
        _FormTagID = ThisTagID
        _FormOwnerID = ThisOwnerID

        MultiElement = False
        NumberofElements = 0

    End Sub

    Private Sub FormEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'connProject.Open()
            If InitializeForm() Then
                SetupFormUserPermission()
                PopulateCboVarSearch()
                PopulateFormVariables()
                'PopulateSubFormVariables() 
                PageRefresh()
                printDoc = New PrintDocument()
            Else
                Me.Close()
            End If

        Catch ex As Exception
            Utilities.logErrorMessage("FormDesigner.FormView.FormEdit_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Shared Function ResizeImage(ByVal oldImage As Image, ByVal Magnification As Single) As Image
        Dim newSize As Size
        newSize.Width = CType((Magnification * CType(oldImage.Size.Width, Single)), Integer)
        newSize.Height = CType((Magnification * CType(oldImage.Size.Height, Single)), Integer)
        Using newImage As Bitmap = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
            Using canvas As Graphics = Graphics.FromImage(newImage)
                canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
                canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                canvas.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
                canvas.DrawImage(oldImage, New Rectangle(New Point(0, 0), newSize))
                Dim m As New MemoryStream
                newImage.Save(m, ImageFormat.Png)
                Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(m)
                Return Image
            End Using
        End Using
    End Function

    Private Function InitializeForm() As Boolean


        Dim qry As String = " SELECT TagNumber, TypeMUID, PackageMUID  FROM tags WHERE tags.MUID = '" + _FormTagID.ToString + "'"
        'Dim myTbl As DataTable = Utilities.ExecuteQuery(qry, "project")
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim myTbl As DataTable = runtime.SQLProject.ExecuteQuery(qry)
        _FormTagName = myTbl.Rows(0)("TagNumber")
        _FormTypeID = myTbl.Rows(0)("TypeMUID")
        PackageID = myTbl.Rows(0)("PackageMUID")

        qry = " SELECT MUID FROM requirements WHERE FormMUID = '" + _FormID.ToString + "'" + _
                " AND OwnerMUID = '" + _FormOwnerID.ToString + "' AND TypeMUID = '" + _FormTypeID.ToString + "'"
        '_FormRequirementID = Utilities.ExecuteQuery(qry, "project").Rows(0)(0)
        _FormRequirementID = runtime.SQLProject.ExecuteQuery(qry).Rows(0)("MUID")


        qry = " SELECT MultiElement,NumberofElements FROM forms WHERE MUID = '" + _FormID.ToString + "'"
        'If Utilities.ExecuteQuery(qry, "project").Rows(0)(0) = 1 Then
        If runtime.SQLProject.ExecuteQuery(qry).Rows(0)("MultiElement") = 1 Then
            MultiElement = True
            'NumberofElements = Utilities.ExecuteQuery(qry, "project").Rows(0)(1)
            NumberofElements = 0 'sqlPrjUtils.ExecuteQuery(qry).Rows(0)("NumberofElements")
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
            If dt.Rows.Count > 0 Then
                NumberofElements = dt.Rows(0)("NumberofElements")
            End If
            If NumberofElements = 0 Then
                MessageBox.Show("You have selected a multiElement form but elements have not been assigned to the form yet")
                Return False
            End If
        End If

        myForm = New FormUtils(_FormID, _FormTagID, _FormOwnerID, "View")
        _FormImages = myForm.FormImages()
        If _FormImages.Count <= 0 Then
            MessageBox.Show("Error: Form Image is not available.")
            runtime.SQLProject.CloseConnection()
            Return False
        End If

        Dim rect As Rectangle = System.Windows.Forms.Screen.PrimaryScreen.Bounds
        Me.Width = myForm.FormWidth
        Me.Height = rect.Height - 50
        If rect.Width > Me.Width Then
            Me.Location = New Point((rect.Width - Me.Width) / 2, 0)
        Else
            Me.Location = New Point(0, 0)
        End If

        _FormPanelSize = Me.ClientRectangle.Size
        Me.Panel1.Size = _FormImages(0).Size
        Me.Panel1.BackgroundImage = _FormImages(CurrentPage)
        'sqlPrjUtils.CloseConnection()
        Return True
    End Function


    Private Sub PopulateCboVarSearch()
        For i As Integer = 0 To myForm.FormVars.Count - 1
            Me.cboVarSearch.Items.Add(myForm.FormVars(i).FieldName)
        Next

    End Sub


    Private Sub PopulateFormVariables()
        _FormVarTextBox.Clear()
        Panel1.Controls.Clear()

        For i As Integer = 0 To myForm.FormVars.Count - 1

            Dim ctrl As TextBox = New TextBox

            ctrl.Location = New Point(myForm.FormVars(i).PosX, myForm.FormVars(i).PosY)
            ctrl.Name = myForm.FormVars(i).FieldName
            ctrl.Width = myForm.FormVars(i).Width
            ctrl.Height = myForm.FormVars(i).Height
            ctrl.Multiline = True
            ctrl.Font = New Font(myForm.FormVars(i).FontName, _
                       myForm.FormVars(i).FontSize, _
                       IIf(myForm.FormVars(i).FontBold, FontStyle.Bold, _
                       IIf(myForm.FormVars(i).FontItalic, FontStyle.Italic, _
                       IIf(myForm.FormVars(i).FontUnderline, FontStyle.Underline, _
                       FontStyle.Regular))), GraphicsUnit.Point)
            ctrl.BackColor = System.Drawing.Color.FromArgb(myForm.FormVars(i).Color)
            ctrl.Visible = False
            If _FormReadOnly Then ' The user has no permission
                ctrl.ReadOnly = True
            End If

            ctrl.Tag = myForm.FormVars(i).PgNum
            _FormVarTextBox.Add(ctrl)
            Me.Panel1.Controls.Add(ctrl)
            ctrl.BringToFront()
            ctrl.Text = myForm.FormVars(i).Value

            If Mid(myForm.FormVars(i).FieldName, 1, 9) = "Signature" Then

            End If

            'If myForm.FormVars(i).FieldName = "package@SystemNumber" Then
            '    ctrl.Text = SystemManager.SystemDataManager.TranslateSystemID(myForm.FormVars(i).Value)
            'End If

            If Not myForm.FormVars(i).linkTbl = "" Then
                ctrl.ReadOnly = True
            End If

            Dim VariableTest() As String = Split(myForm.FormVars(i).FieldName, "@")

            If VariableTest(0) = "Documents" Then
                ctrl.ReadOnly = True
            End If
            If Mid(VariableTest(0), 1, 7) = "Element" Then
                If VariableTest(1) = "TagNumber" Then
                    ctrl.ReadOnly = True
                End If
                If VariableTest(1) = "Description" Then
                    ctrl.ReadOnly = True
                End If
                If VariableTest(1) = "Remarks" Then
                    ctrl.ReadOnly = True
                End If
                If VariableTest(1) = "Service" Then
                    ctrl.ReadOnly = True
                End If
                If VariableTest(1) = "Manufacturer" Then
                    ctrl.ReadOnly = True
                End If
                If VariableTest(1) = "ModelNumber" Then
                    ctrl.ReadOnly = True
                End If
                If VariableTest(1) = "SerialNumber" Then
                    ctrl.ReadOnly = True
                End If
                If VariableTest(1) = "PONumber" Then
                    ctrl.ReadOnly = True
                End If
                If VariableTest(1) = "LineNumber" Then
                    ctrl.ReadOnly = True
                End If
            End If


            'If Not myForm.FormVars(i).image Is Nothing Then
            '    Dim pbox As PictureBox = New PictureBox
            '    pbox.Location = ctrl.Location
            '    pbox.Size = ctrl.Size
            '    pbox.BorderStyle = BorderStyle.FixedSingle
            '    pbox.Image = myForm.ResizeImage(myForm.FormVars(i).image, pbox.Size.Width, pbox.Size.Height)
            '    Me.Panel1.Controls.Add(pbox)
            '    pbox.BringToFront()
            'End If
        Next
        Me.Panel1.Invalidate()

    End Sub


    'Private Sub PopulateSubFormVariables()
    '    _FormVarTextBox.Clear()
    '    For i As Integer = 0 To myForm.FormVars.Count - 1
    '        If Mid(myForm.FormVars(i).FieldName, 1, 7) = "Element" Then

    '            Dim ctrl As TextBox = New TextBox
    '            ctrl.Location = New Point(myForm.FormVars(i).PosX, myForm.FormVars(i).PosY)
    '            ctrl.Name = myForm.FormVars(i).FieldName
    '            ctrl.Width = myForm.FormVars(i).Width
    '            ctrl.Font = New Font(myForm.FormVars(i).FontName, _
    '                       myForm.FormVars(i).FontSize, _
    '                       IIf(myForm.FormVars(i).FontBold, FontStyle.Bold, _
    '                       IIf(myForm.FormVars(i).FontItalic, FontStyle.Italic, _
    '                       IIf(myForm.FormVars(i).FontUnderline, FontStyle.Underline, _
    '                       FontStyle.Regular))), GraphicsUnit.Point)
    '            ctrl.BackColor = System.Drawing.Color.FromArgb(myForm.FormVars(i).Color)
    '            If _FormReadOnly Then ' The user has no permission
    '                ctrl.ReadOnly = True
    '            End If

    '            _FormVarTextBox.Add(ctrl)
    '            Me.Panel1.Controls.Add(ctrl)
    '            ctrl.BringToFront()




    '            ctrl.Text = myForm.FormVars(i).Value


    '            If Not myForm.FormVars(i).image Is Nothing Then
    '                Dim pbox As PictureBox = New PictureBox
    '                pbox.Location = ctrl.Location
    '                pbox.Size = ctrl.Size
    '                pbox.BorderStyle = BorderStyle.FixedSingle
    '                pbox.Image = myForm.ResizeImage(myForm.FormVars(i).image, pbox.Size.Width, pbox.Size.Height)
    '                Me.Panel1.Controls.Add(pbox)
    '                pbox.BringToFront()
    '            End If




    '        End If
    '    Next

    'End Sub

    Private Sub SelectTextBoxes()
        For i As Integer = 0 To _FormVarTextBox.Count - 1
            _FormVarTextBox(i).Visible = False
            If Magnification = 1 Then
                For Each var As FormUtils.formItem In myForm.FormVars
                    If _FormVarTextBox(i).Name = var.FieldName Then
                        If _FormReadOnly Then
                            _FormVarTextBox(i).Enabled = False
                        Else
                            _FormVarTextBox(i).Enabled = True
                        End If
                        If myForm.FormVars(i).linkTbl > "" And Not Mid(myForm.FormVars(i).FieldName, 1, 7) = "Element" Then
                            _FormVarTextBox(i).Enabled = False
                        End If

                        If var.PgNum = CurrentPage Then
                            '_FormVarTextBox(i).Visible = True
                            _FormVarTextBox(i).Visible = False
                        End If

                    End If
                Next
            End If
        Next

        If myForm.FormCurrentLevel >= myForm.FormTtlRequiredLevels Then
            TsBtn_Unlock.Image = My.Resources.Security_Gold
            Me.TsBtn_Unlock.Enabled = True
            Me.TsBtn_Accept.Enabled = False
        Else
            TsBtn_Unlock.Image = My.Resources.Symbol_Unsecured
            Me.TsBtn_Unlock.Enabled = False
            Me.TsBtn_Accept.Enabled = True
        End If

        TsBtn_Unlock.Image = My.Resources.Security_Gold
        Me.TsBtn_Unlock.Enabled = True

    End Sub

    Private Sub PageRefresh()
        Magnification = 1
        Me.Panel1.Size = _FormImages(0).Size
        Me.Panel1.BackgroundImage = _FormImages(CurrentPage)
        Me.tbxPgNum.Text = "Page " + (CurrentPage + 1).ToString + " of " + myForm.FormPageCount.ToString
        SelectTextBoxes()
        DrawText()
        Me.Refresh()
    End Sub
    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
        PageRefresh()
    End Sub
    Private Sub VGridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub SetupFormUserPermission()
        Me.TsBtn_Save.Enabled = False
        'Me.TsBtn_Accept.Enabled = True
        Me.TsBtn_Reject.Enabled = True
        Me.TsBtn_Submit.Enabled = False
        'Me.TsBtn_Unlock.Enabled = False
        '        FormStatus = Utilities.GetFormStatus(FormTagID, FormID, FormOwnerID)

        Dim FormAction As Integer = 0
        If myForm.FormUserLevel = -1 Then ' The user has no permission
            'MessageBox.Show("You do not have permission to edit this form, all fields read only!")
            Return
        End If

        If myForm.FormCurrentLevel = myForm.FormTtlRequiredLevels Then
            'Me.TsBtn_Unlock.Enabled = True
            'MessageBox.Show("The form has been completed and signed off, all fields read only!")
            'Return
        End If

        Dim Permit As Boolean = False
        'If myForm.FormCurrentLevel + 1 = myForm.FormUserLevel Then Permit = True
        If myForm.FormCurrentLevel = myForm.FormUserLevel Then Permit = True

        If Not Permit Then ' The form was submitted
            'MessageBox.Show("You do not have permission to edit this form, all fields read only!")
            If myForm.FormCurrentLevel > 0 Then
                'Me.TsBtn_Accept.Enabled = True
                Me.TsBtn_Reject.Enabled = True
                'Me.TsBtn_Unlock.Enabled = True
                If myForm.FormCurrentLevel < myForm.FormTtlRequiredLevels Then
                    'MessageBox.Show("The form has been submitted and waiting for approval, all field are read only!")
                    Return
                End If
            End If
            Return
        End If

        If myForm.FormCurrentLevel > 0 Then
            'Me.TsBtn_Accept.Enabled = True
            Me.TsBtn_Reject.Enabled = True
            'Me.TsBtn_Unlock.Enabled = True
            If myForm.FormCurrentLevel < myForm.FormTtlRequiredLevels Then
                'MessageBox.Show("The form has been submitted and waiting for approval, all field are read only!")
            End If
            Return
        End If
        Me.TsBtn_Submit.Enabled = True
        Me.TsBtn_Save.Enabled = True
        _FormReadOnly = False
    End Sub

    Private Sub ViewFormLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewFormLog.Click
        If Not VGridControl1 Is Nothing Then
            VGridControl1.Dispose()
            VGridControl1 = Nothing
            Return
        End If
        VGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl
        VGridControl1.Location = New System.Drawing.Point(0, 30)
        VGridControl1.Name = "VGridControl1"
        VGridControl1.Size = New System.Drawing.Size(200, 200)
        '        VGridControl1.Rows(0).Height = 50
        AddHandler VGridControl1.Click, AddressOf VGridControl1_Click
        VGridControl1.DataSource = myForm.GetFormProperies()
        Me.Controls.Add(VGridControl1)
        VGridControl1.BringToFront()
        VGridControl1.Dock = DockStyle.None

        VGridControl1.Rows(11).Height = 50
        Dim RIMemoEdit As RepositoryItemMemoEdit = CType(VGridControl1.RepositoryItems.Add("MemoEdit"), _
           RepositoryItemMemoEdit)
        RIMemoEdit.WordWrap = True
        VGridControl1.RepositoryItems.Add(RIMemoEdit)
        VGridControl1.Rows(11).Properties.RowEdit = RIMemoEdit



        Dim RowEsign As RepositoryItemImageEdit = CType(VGridControl1.RepositoryItems.Add("ImageEdit"), _
           RepositoryItemImageEdit)
        VGridControl1.Rows(12).Properties.RowEdit = RowEsign
        VGridControl1.Rows(12).Properties.Value = myForm.FormEsign


        ''...

        '' creating a new vertical grid control
        'Dim VGrid As New VGridControl()
        'VGrid.Parent = Me
        'VGrid.Width = 300
        'VGrid.RowHeaderWidth = 170

        '' creating two editor rows with the specified captions
        'Dim Row1 As New EditorRow()
        'Row1.Properties.Caption = "Treat Warnings as Errors"
        'Dim Row2 As New EditorRow()
        'Row2.Properties.Caption = "Warning Level"

        '' creating a new category row and adding it to the grid
        'Dim Category As New CategoryRow("Errors and Warnings")
        'VGrid.Rows.Add(Category)

        '' adding the editor rows as childs to the category
        'Dim Rows() As EditorRow = {Row1, Row2}
        'Category.ChildRows.AddRange(Rows)

        '' creating a check editor for the first editor row
        'Dim RICheck As RepositoryItemImageEdit = CType(VGrid.RepositoryItems.Add("ImageEdit"), _
        '  RepositoryItemImageEdit)
        'Row1.Properties.RowEdit = RICheck
        '' specifying the row value to be displayed by the associated check editor
        'Row1.Properties.Value = myForm.FormEsign

        '' creating a combobox editor for the second editor row
        ''        Dim RICombo As RepositoryItemComboBox = CType(VGrid.RepositoryItems.Add("ComboBox"), _
        ''         RepositoryItemComboBox)
        '' populating the combo box with data
        'Dim I As Integer
        'For I = 0 To 4
        '    '          RICombo.Properties.Items.Add("Warning Level " + I.ToString())
        'Next
        ''     Row2.Properties.RowEdit = RICombo
        '' specifying the second row's value
        ''    Row2.Properties.Value = RICombo.Properties.Items(3)

        'VGrid.BringToFront()

        ''        VGridControl1.ShowEditor()
        ''      GridControl1.DataSource = myForm.GetFormProperies()
        ''    GridControl1.RepositoryItems.Add(RIMemoEdit)
        ''   Dim View As ColumnView = GridControl1.MainView

        ''  View.Columns("Comment").ColumnEdit = RIMemoEdit
        '' Dim View As Views.Base. = VGridControl1.MainView

    End Sub


    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIn.Click
        Magnification = Magnification + 0.5
        SelectTextBoxes()
        Dim img As Image = _FormImages(CurrentPage)
        Dim g As Graphics = Graphics.FromImage(img)
        For i As Integer = 0 To myForm.FormVars.Count - 1
            Dim itm As FormUtils.formItem = myForm.FormVars(i)
            If itm.PgNum = CurrentPage Then
                Dim drawFont As System.Drawing.Font = New Font(itm.FontName, itm.FontSize, _
                    IIf(itm.FontBold, FontStyle.Bold, IIf(itm.FontItalic, FontStyle.Italic, _
                    IIf(itm.FontUnderline, FontStyle.Underline, FontStyle.Regular))), GraphicsUnit.Point)
                Dim myPen As New Pen(Brushes.Blue, 1)
                g.DrawString(_FormVarTextBox(i).Text, drawFont, Brushes.Black, itm.PosX, itm.PosY)
                g.DrawRectangle(myPen, itm.PosX, itm.PosY, itm.Width, itm.Height)
            End If
        Next

        Me.Panel1.BackgroundImage = ResizeImage(img, Magnification)
        Me.Panel1.Size = Me.Panel1.BackgroundImage.Size
        Me.Panel1.BringToFront()
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        CurrentPage = 0
        PageRefresh()
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        If CurrentPage > 0 Then
            CurrentPage = CurrentPage - 1
        End If
        PageRefresh()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If CurrentPage < myForm.FormPageCount - 1 Then
            CurrentPage = CurrentPage + 1
        End If
        PageRefresh()
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        CurrentPage = myForm.FormPageCount - 1
        PageRefresh()
    End Sub
    Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageSetup.Click
        PageSetupDialog1.Document = printDoc
        ' Sets the print document's color setting to false,
        ' so that the page will not be printed in color.
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        Dim msgResult As DialogResult = Me.PageSetupDialog1.ShowDialog()
    End Sub
    Private Sub Btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Print.Click
        'myForm.SaveFieldValues()
        'myForm.UpdateAllFormStatus()
        'myForm.InitializeFormImage()
        myForm.InitializeFormPrintImage()

        If Directory.Exists(imgdir) Then
            Directory.Delete(imgdir, True)
        End If
        Directory.CreateDirectory(imgdir)
        intPageCounter = 0
        Dim AllOwnerIDList As New List(Of String)
        Dim i As Integer = 0
        For Each image As Image In myForm.FormPrintImages
            Dim imgFile As String = (imgdir + "\img" + i.ToString)
            image.Save(imgFile + ".png", System.Drawing.Imaging.ImageFormat.Png)
            i = i + 1
        Next


        Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()
        printDoc.DocumentName = "Printing from Windows forms"

        AddHandler printDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler printDoc.EndPrint, AddressOf printDoc_EndPrint
        AddHandler printDoc.PrintPage, AddressOf printDoc_PrintPage

        printDialog.Document = Me.printDoc
        printDialog.ShowDialog()


    End Sub

    Private Sub cboVarSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVarSearch.SelectedIndexChanged

        For i As Integer = 0 To _FormVarTextBox.Count - 1
            If Magnification = 1 Then
                For Each var As FormUtils.formItem In myForm.FormVars
                    If _FormVarTextBox(i).Name = cboVarSearch.SelectedItem Then
                        If var.PgNum <> CurrentPage Then
                            CurrentPage = var.PgNum
                            PageRefresh()
                        End If
                        _FormVarTextBox(i).Focus()
                        Exit Sub
                    End If
                Next
            End If
        Next
    End Sub




    Private Sub printDoc_BeginPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        intPageCounter = 0
    End Sub

    Private Sub printDoc_EndPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        '        f_title = Nothing
        '       f_body = Nothing
    End Sub
    Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Dim imgFile As String = (imgdir + "\img" + intPageCounter.ToString + ".png")
        Dim f_body As Font = New Font("Times New Roman", 10)
        Dim LeftMargin As Integer = 50
        If File.Exists(imgFile) Then
            Dim Image As System.Drawing.Image = System.Drawing.Image.FromFile(imgFile)

            e.Graphics.DrawImage(Image, 0, 0, Image.Width, Image.Height)
            '  If intPageCounter > 0 Then
            e.Graphics.DrawString("Page " + intPageCounter.ToString(), f_body, Brushes.Black, LeftMargin, Image.Height - 30)
            'End If
        End If

        If (intPageCounter < Directory.GetFiles(imgdir).Length - 1) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
        intPageCounter = intPageCounter + 1

    End Sub
    Private Function chkUpdateRequired() As Boolean
        If _FormReadOnly Then ' The user has no permission
            Return False
        End If
        Dim updateRequired As Boolean = False
        For i As Integer = 0 To _FormVarTextBox.Count - 1
            For Each var As FormUtils.formItem In myForm.FormVars
                If _FormVarTextBox(i).Name = var.FieldName Then
                    If _FormVarTextBox(i).Text <> var.Value Then
                        updateRequired = True
                    End If
                End If
            Next
        Next
        Return updateRequired
    End Function
    Private Sub SaveForm()
        Try

            If _FormReadOnly Then ' The user has no permission
                Return
            End If
            Dim updateRequired As Boolean = False
            For i As Integer = 0 To _FormVarTextBox.Count - 1
                For j As Integer = 0 To myForm.FormVars.Count - 1
                    If _FormVarTextBox(i).Name = myForm.FormVars(j).FieldName Then
                        If _FormVarTextBox(i).Text <> myForm.FormVars(j).Value Then
                            updateRequired = True
                            myForm.FormUpdateVarValue(myForm.FormVars(j).FieldName, _FormVarTextBox(i).Text)
                        End If
                    End If
                Next
            Next

            myForm.FormCurrentLevel = 0
            myForm.FormAction = FormUtils.ActionType.Undefined
            myForm.SaveFieldValues()
            myForm.UpdateAllFormStatus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TsBtn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtn_Save.Click
        If _FormReadOnly Then ' The user has no permission
            Return
        End If
        SaveForm()
    End Sub
    Private Function chkBlankFields() As Boolean
        For i As Integer = 0 To _FormVarTextBox.Count - 1
            For j As Integer = 0 To myForm.FormVars.Count - 1
                If _FormVarTextBox(i).Name = myForm.FormVars(j).FieldName Then
                    If _FormVarTextBox(i).ReadOnly = False Then
                        If _FormVarTextBox(i).Text = "" Then
                            Return True
                        End If
                    End If
                End If
            Next
        Next
        Return False
    End Function
    Private Sub TsBtn_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtn_Submit.Click
        'myForm.SaveFieldValues()
        'myForm.UpdateFormStatus()
        If _FormReadOnly Then ' The user has no permission
            Return
        End If

        SaveForm()

        If chkBlankFields() Then

            '    MessageBox.Show("Form can not be submitted while entries are blank")
            '   Return
            If MessageBox.Show("There are blanks on the form.  Do you wish to fill blanks with N/A?", "Form Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Return
            End If
            For i As Integer = 0 To _FormVarTextBox.Count - 1
                For j As Integer = 0 To myForm.FormVars.Count - 1
                    If _FormVarTextBox(i).Name = myForm.FormVars(j).FieldName Then
                        If _FormVarTextBox(i).ReadOnly = False Then
                            If _FormVarTextBox(i).Text = "" Then
                                _FormVarTextBox(i).Text = "N/A"
                                myForm.FormUpdateVarValue(myForm.FormVars(j).FieldName, _FormVarTextBox(i).Text)
                            End If
                        End If
                    End If
                Next
            Next
            SaveForm()
        End If

        Dim mySignature As New formSubmit(myForm, ActionType.Submit)
        Dim msgResult As DialogResult = mySignature.ShowDialog()
        If msgResult = Windows.Forms.DialogResult.Cancel Then Return
        MessageBox.Show("Form has been submitted and is open for read only")
        Me.TsBtn_Accept.Enabled = True
        Me.TsBtn_Reject.Enabled = True
        _FormReadOnly = True
        TsBtn_Submit.Enabled = False
        myForm.FormAction = FormUtils.ActionType.Submit
        SelectTextBoxes()
        myForm.InitializeFormParameters()
        PopulateFormVariables()

    End Sub

    Private Sub TsBtn_Unlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtn_Unlock.Click
        'If myForm.FormCurrentLevel <= 0 Then Return


        ''Dim verifyUserForm As New FormDesigner.FormVerifyUser(myForm)
        ''Dim msgResult As DialogResult = verifyUserForm.ShowDialog()
        ''If msgResult = Windows.Forms.DialogResult.Cancel Then
        ''    Return
        ''End If

        If Utilities.CheckPermission("PRO001") Then
            If MessageBox.Show("Do you wish to change the form status, ", "FormView", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                'Dim mySignature As New formSubmit(myForm, ActionType.Submit)
                'Dim msgResult As DialogResult = mySignature.ShowDialog()
                'If msgResult = Windows.Forms.DialogResult.Cancel Then Return
                'MessageBox.Show("Form submit has been cancelled")
                myForm.FormCurrentLevel = 0
                _FormReadOnly = False
                TsBtn_Submit.Enabled = True
                TsBtn_Save.Enabled = True
                myForm.FormAction = FormUtils.ActionType.CancelSubmit
                SaveForm()
                SelectTextBoxes()
            End If
        End If

    End Sub

    Private Sub FormView_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If chkUpdateRequired() Then
            If MessageBox.Show("Form has been changed, do you wish to save?", "Form Save", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                SaveForm()
            End If
        End If
    End Sub
    Private Sub TsBtn_Accept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtn_Accept.Click
        If myForm.FormCurrentLevel <= 0 Then
            MessageBox.Show("Form has not been submitted")
            Return
        End If
        'Dim Permit As Boolean = False
        'If myForm.FormCurrentLevel + 1 = myForm.FormUserLevel Then Permit = True
        'If myForm.FormCurrentLevel = myForm.FormUserLevel Then Permit = True
        'If Not Permit Then
        '    MessageBox.Show("You do not have permission to approve this form")
        '    Return
        'End If

        Dim mySignature As New formSubmit(myForm, ActionType.Accept)
        Dim msgResult As DialogResult = mySignature.ShowDialog()
        If msgResult = Windows.Forms.DialogResult.Cancel Then Return
        'MessageBox.Show("Form has been accepted")
        Me.Close()
    End Sub

    Private Sub TsBtn_Reject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsBtn_Reject.Click
        If myForm.FormCurrentLevel <= 0 Then
            MessageBox.Show("Form has not been submitted")
            Return
        End If

        Dim mySignature As New formSubmit(myForm, ActionType.Reject)
        Dim msgResult As DialogResult = mySignature.ShowDialog()
        If msgResult = Windows.Forms.DialogResult.Cancel Then Return
        MessageBox.Show("Form has been rejected")

        SaveForm()
        Me.Close()
    End Sub


    Private Sub DrawText()
        'Dim bm_tmp As New Bitmap(_FormImages(CurrentPage).Width, _FormImages(CurrentPage).Height)
        'Dim g As Graphics = Graphics.FromImage(bm_tmp)

        'g.DrawImage(_FormImages(CurrentPage), 0, 0, _FormImages(CurrentPage).Width, _FormImages(CurrentPage).Height)


        'For Each cntl As Control In Panel1.Controls
        '    Dim mBox As TextBox = TryCast(cntl, TextBox)
        '    If Not mBox Is Nothing Then
        '        If mBox.Tag = CurrentPage Then
        '            Dim bm As New Bitmap(mBox.Bounds.Width, mBox.Bounds.Height)
        '            Dim g2 As Graphics = Graphics.FromImage(bm)

        '            Dim myFont = New Font(mBox.Font.FontFamily, mBox.Font.Size, _
        '                     System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
        '            Dim myBrush As Brush = New SolidBrush(Color.Blue)
        '            g2.DrawString(mBox.Text, myFont, myBrush, New Rectangle(New Point(2, 2), mBox.Bounds.Size))

        '            Dim rect As Rectangle = New Rectangle(mBox.Bounds.X, mBox.Bounds.Y, mBox.Bounds.Width, mBox.Bounds.Height)

        '            If mBox.Text = "" And Not mBox.ReadOnly And Not mBox.Name = SelectedField Then
        '                myBrush = New SolidBrush(Color.FromArgb(150, 255, 210, 210))
        '                g.FillRectangle(myBrush, rect)
        '            ElseIf Not mBox.Text = "" And Not mBox.ReadOnly And Not mBox.Name = SelectedField Then
        '                myBrush = New SolidBrush(Color.FromArgb(150, 210, 255, 210))
        '                g.FillRectangle(myBrush, rect)
        '            ElseIf mBox.Name = SelectedField Then
        '                myBrush = New SolidBrush(Color.FromArgb(230, 255, 255, 130))
        '                g.FillRectangle(myBrush, rect)
        '            End If


        '            g.DrawImage(bm, New Point(mBox.Bounds.X, mBox.Bounds.Y))

        '        End If
        '    End If
        'Next


        'Panel1.BackgroundImage = bm_tmp


    End Sub
    Private Function VarGroupID(ByVal varName As String)
        Dim GroupID As Integer = -1
        For j As Integer = 0 To myForm.FormVars.Count - 1
            If varName = myForm.FormVars(j).FieldName Then
                GroupID = myForm.FormVars(j).GroupID
                Exit For
            End If
        Next
        Return GroupID
    End Function
    Private Sub SetGroupValues(ByVal varName As String, ByVal val As String)
        Dim GroupID As Integer = -1
        For j As Integer = 0 To myForm.FormVars.Count - 1
            If varName = myForm.FormVars(j).FieldName Then
                GroupID = myForm.FormVars(j).GroupID
            End If
        Next
        If GroupID <= 0 Then Return

        For Each cntl As Control In Panel1.Controls
            Dim mBox As TextBox = TryCast(cntl, TextBox)
            If Not mBox Is Nothing Then
                Dim grpID = VarGroupID(mBox.Name)
                If grpID = GroupID Then
                    mBox.Text = val
                End If
            End If
        Next
    End Sub

    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseClick
        For Each cntl As Control In Panel1.Controls
            Dim mBox As TextBox = TryCast(cntl, TextBox)
            If Not mBox Is Nothing Then
                Dim mBoxRect As New Rectangle(mBox.Bounds.X, mBox.Bounds.Y, mBox.Bounds.Width, mBox.Bounds.Height)
                If mBoxRect.Contains(e.X, e.Y) Then
                    If mBox.Tag = CurrentPage Then
                        If mBox.ReadOnly = False Then
                            SelectedField = mBox.Name
                            DrawText()

                            If Mid(mBox.Name, 1, 9) = "Signature" Then
                                Dim frm_Entry As New SignatureEntry(myForm, _FormID)
                                frm_Entry.FieldName = mBox.Name
                                frm_Entry.ShowDialog()

                                If Not frm_Entry.SignatureImage Is Nothing Then
                                    mBox.Text = " "
                                Else
                                    mBox.Text = ""
                                End If
                                frm_Entry.Dispose()
                                SelectedField = ""
                                Me.Panel1.Invalidate()
                            ElseIf Mid(mBox.Name, 1, 8) = "YNSelect" Then
                                Dim frm_Entry As New YNSelect(mBox.Text)
                                'frm_Entry.FieldName = mBox.Name
                                frm_Entry.ShowDialog()

                                mBox.Text = frm_Entry.FinalValue

                                frm_Entry.Dispose()
                                SelectedField = ""
                                Me.Panel1.Invalidate()
                                DrawText()
                            Else
                                Dim frm_Entry As New ValueEntry(mBox.Text)
                                frm_Entry.FieldName = mBox.Name
                                frm_Entry.ShowDialog()

                                SelectedField = ""

                                If frm_Entry.FieldModified Then
                                    Dim val As String = frm_Entry._Value
                                    If val > "" Then
                                        SetGroupValues(mBox.Name, " ") 'set all group members
                                    Else
                                        SetGroupValues(mBox.Name, "") 'clear all group members
                                    End If
                                    mBox.Text = val
                                    Me.Panel1.Invalidate()
                                End If
                                DrawText()
                                frm_Entry.Dispose()
                            End If

                        End If
                    End If
                Else
                    mBox.Visible = False
                End If
            End If
        Next




    End Sub


    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Dim g As Graphics = e.Graphics

        For Each cntl As Control In Panel1.Controls
            Dim mBox As TextBox = TryCast(cntl, TextBox)
            If Not mBox Is Nothing Then
                Dim mBoxVisible As Boolean = False
                If mBox.Tag = CurrentPage Then mBoxVisible = True
                If MultiElement Then
                    Dim VariableTest() As String = Split(mBox.Name, "@")
                    If Not Mid(VariableTest(0), 1, 7) = "Element" Then
                        mBoxVisible = True
                    End If
                End If


                'If mBox.Tag = CurrentPage Then
                If mBoxVisible Then
                    Dim bm As New Bitmap(mBox.Bounds.Width, mBox.Bounds.Height)
                    Dim g2 As Graphics = Graphics.FromImage(bm)

                    Dim myFont = New Font(mBox.Font.FontFamily, mBox.Font.Size, _
                             System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
                    Dim myBrush As Brush = New SolidBrush(Color.Blue)
                    g.DrawString(mBox.Text, myFont, myBrush, New Rectangle(New Point(mBox.Bounds.X + 2, mBox.Bounds.Y + 2), mBox.Bounds.Size))

                    Dim rect As Rectangle = New Rectangle(mBox.Bounds.X, mBox.Bounds.Y, mBox.Bounds.Width, mBox.Bounds.Height)

                    If mBox.Text = "" And Not mBox.ReadOnly And Not mBox.Name = SelectedField Then
                        myBrush = New SolidBrush(Color.FromArgb(150, 255, 210, 210))
                        g.FillRectangle(myBrush, rect)
                    ElseIf Not mBox.Text = "" And Not mBox.ReadOnly And Not mBox.Name = SelectedField Then

                        If Mid(mBox.Name, 1, 9) = "Signature" Then

                        Else
                            myBrush = New SolidBrush(Color.FromArgb(150, 210, 255, 210))
                            g.FillRectangle(myBrush, rect)
                        End If
                    ElseIf mBox.Name = SelectedField Then
                        myBrush = New SolidBrush(Color.FromArgb(230, 255, 255, 130))
                        g.FillRectangle(myBrush, rect)
                    End If


                    'g.DrawImage(bm, New Point(mBox.Bounds.X, mBox.Bounds.Y))

                End If
            End If
        Next


        Dim SignatureBoxWidth As Integer = 305
        Dim SignatureBoxHeight As Integer = 69

        For Each itm As FormUtils.formItem In Me.myForm.FormVars
            If Not itm.image Is Nothing Then

                If Mid(itm.FieldName, 1, 9) = "Signature" Then
                    If itm.PgNum = CurrentPage Then
                        Dim NewWidth As Single = itm.Height / SignatureBoxHeight * itm.Width * 3
                        g.DrawImage(itm.image, itm.PosX, itm.PosY, NewWidth, itm.Height)
                    End If
                Else
                    Dim NewWidth As Single = itm.Height / SignatureBoxHeight * itm.Width * 3
                    g.DrawImage(itm.image, itm.PosX, itm.PosY, NewWidth, itm.Height)
                End If
            End If
        Next

    End Sub


    Private Sub btn_Recall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Recall.Click
        Dim query As String = Nothing

        'check to see if form is multielement
        If Utilities.IsFormMultiElement(Me._FormID) Then
            query = "SELECT * FROM forms_me_status WHERE FormMUID = '" + Me._FormID + "'" & _
                    " AND OwnerMUID='" + Me._FormOwnerID + "'" & _
                    " AND SourceMUID='" + Me.PackageID + "'" & _
                    " AND SourceType='Package'" & _
                    " ORDER BY TS DESC"
            Dim dt_FormStatus As DataTable = runtime.SQLProject.ExecuteQuery(query)

            'return if no submitted status
            If dt_FormStatus.Rows.Count = 0 Then Return
            If myForm.FormCurrentLevel = 0 Then Return

            'check to see if the user was the submitter
            If Not dt_FormStatus.Rows(0)("UserMUID") = runtime.UserMUID Then
                MessageBox.Show("This form was submitted by " + Utilities.GetUserName(dt_FormStatus.Rows(0)("UserMUID")) + " and can only be recalled by that user.")
                Return
            End If

            'check to see if form was sync'd
            query = "SELECT * FROM ClientAccess WHERE MUID='" + runtime.MID + "'"
            Dim dt_Sync As DataTable = runtime.SQLServer.ExecuteQuery(query)

            If dt_Sync.Rows.Count = 0 Then
                MessageBox.Show("Cannot get sync data at this time, Un-Submit not allowed.")
                Return
            Else
                If dt_Sync.Rows(0)("LastAccess") > dt_FormStatus.Rows(0)("TS") Then
                    'if it was display message that it cannot be unsubmitted, it must be rejected
                    MessageBox.Show("Client has been synchronized, Un-Submit not allowed.  The form must be rejected to allow changes.")
                    Return
                Else
                    'if not, then delete the submit record
                    query = "DELETE FROM forms_status WHERE MUID = '" + dt_FormStatus.Rows(0)("MUID") + "'"
                    Dim dt_param As DataTable = runtime.SQLServer.paramDT
                    runtime.SQLProject.ExecuteNonQuery(query, dt_param)

                    'get all tag records and delete
                    query = "SELECT * FROM tags WHERE PackageMUID='" + Me.PackageID + "'"
                    Dim dt_Tags As DataTable = runtime.SQLProject.ExecuteQuery(query)

                    For i As Integer = 0 To dt_Tags.Rows.Count - 1
                        query = "DELETE FROM forms_me_status WHERE FormMUID = '" + Me._FormID + "'" & _
                                " AND OwnerMUID='" + Me._FormOwnerID + "'" & _
                                " AND SourceMUID='" + dt_Tags.Rows(i)("MUID") + "'" & _
                                " AND SourceType='Tag'"
                        Dim dt_param2 As DataTable = runtime.SQLServer.paramDT
                        runtime.SQLProject.ExecuteNonQuery(query, dt_param2)
                    Next
                End If
            End If

        Else
            query = "SELECT * FROM forms_status WHERE FormMUID = '" + Me._FormID + "'" & _
                    " AND OwnerMUID='" + Me._FormOwnerID + "'" & _
                    " AND TagMUID='" + Me._FormTagID + "'" & _
                    " ORDER BY TS DESC"
            Dim dt_FormStatus As DataTable = runtime.SQLProject.ExecuteQuery(query)

            'return if no submitted status
            If dt_FormStatus.Rows.Count = 0 Then Return
            If myForm.FormCurrentLevel = 0 Then Return

            'check to see if the user was the submitter
            If Not dt_FormStatus.Rows(0)("UserMUID") = runtime.UserMUID Then
                MessageBox.Show("This form was submitted by " + Utilities.GetUserName(dt_FormStatus.Rows(0)("UserMUID")) + " and can only be recalled by that user.")
                Return
            End If

            'check to see if form was sync'd
            query = "SELECT * FROM ClientAccess WHERE MUID='" + runtime.MID + "'"
            Dim dt_Sync As DataTable = runtime.SQLServer.ExecuteQuery(query)

            If dt_Sync.Rows.Count = 0 Then
                MessageBox.Show("Cannot get sync data at this time, Un-Submit not allowed.")
                Return
            Else
                If dt_Sync.Rows(0)("LastAccess") > dt_FormStatus.Rows(0)("TS") Then
                    'if it was display message that it cannot be unsubmitted, it must be rejected
                    MessageBox.Show("Client has been synchronized, Un-Submit not allowed.  The form must be rejected to allow changes.")
                    Return
                Else
                    'if not, then delete the submit record
                    query = "DELETE FROM forms_status WHERE MUID = '" + dt_FormStatus.Rows(0)("MUID") + "'"
                    Dim dt_param As DataTable = runtime.SQLServer.paramDT
                    runtime.SQLProject.ExecuteNonQuery(query, dt_param)
                End If
            End If
        End If


        'message form must be closed and reopened, me.close
        MessageBox.Show("The form must be re-opened before modifying.")
        Me.Close()

    End Sub


End Class