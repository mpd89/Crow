Imports System
Imports System.Windows.Forms
Imports DataStreams.Csv
Imports daqartDLL


Public Class CreateSystemNumbers
    Public selectedList As Integer
    Dim thisList As ListBox
    Dim newLabelLeft As Integer = 225
    Dim loading As Boolean
    'Dim SQLProject As DataUtils


    Private Sub CreateSystemNumbers_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'SQLProject.CloseConnection()
    End Sub


    Private Sub CreateSystemNumbers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            loading = True

            'runtime.selectedProjectID = Utilities.GetProjectID(runtime.selectedProject)

            'SQLProject = New DataUtils("project")
            'SQLProject.OpenConnection()

            BuildListBoxes()

            Dim i As Integer
            For i = 1 To Utilities.CountTiers()
                PopulateListBoxes(i)
            Next i

            CreateLabels()

            CheckBlanks()

            loading = False
        Catch ex As Exception
            Utilities.logErrorMessage("ProjectWizard.CreateSystemNumbers._Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    'Public Function CountTiers() As Integer
    '    Dim query As String = "SELECT COUNT(*) FROM system_mnemonic"
    '    Dim dt As DataTable

    '    Try
    '        dt = SQLProject.ExecuteQuery(query)
    '        If dt.Rows.Count > 0 Then
    '            Return dt.Rows(0)(0)
    '        Else
    '            Return 0
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Cannot get Tier Count: " + ex.Message)
    '    End Try

    '    Return 0
    'End Function


    Private Sub BuildListBoxes()
        Dim i As Integer
        For i = 1 To Utilities.CountTiers()
            Dim Trs As Integer = Utilities.CountTiers()
            Dim query As String = "SELECT TierColor,SubSystem FROM system_mnemonic WHERE TierNumber='" + CStr(i) + "'"
            Dim ListBoxColor As String = Nothing
            Dim hasSubSystem As String = Nothing
            Dim dt As DataTable

            Try
                dt = runtime.SQLProject.ExecuteQuery(query)
                If dt.Rows.Count > 0 Then
                    ListBoxColor = dt.Rows(0)(0)
                    hasSubSystem = dt.Rows(0)(1)
                End If
            Catch ex As Exception
                MessageBox.Show("Cannot get Tier Color: " + ex.Message)
            End Try


            Dim selectionColor As Array
            selectionColor = Split(ListBoxColor, ",")

            If selectionColor(0) = "" Then
                selectionColor(0) = "255"
            End If
            If selectionColor(1) = "" Then
                selectionColor(1) = "255"
            End If
            If selectionColor(2) = "" Then
                selectionColor(2) = "255"
            End If
            If selectionColor(3) = "" Then
                selectionColor(3) = "255"
            End If

            Dim tierListBox As ListBox
            tierListBox = New ListBox()
            With tierListBox
                .Name = "Tier" + CStr(i)
                .Tag = CStr(i)
                .Visible = True
                .Width = 250
                .Height = 70
                .Left = (CInt(i) - 1) * 40 + 10
                .Top = (CInt(i) - 1) * 75 + 10
                .BackColor = Color.FromArgb(CInt(selectionColor(0)), CInt(selectionColor(1)), CInt(selectionColor(2)), CInt(selectionColor(3)))
            End With

            SystemNumberPanel1.Controls.Add(tierListBox)
            tierListBox.Items.Clear()

            If hasSubSystem = True Then
                AddHandler tierListBox.SelectedIndexChanged, AddressOf valueSelectedSS
            Else
                AddHandler tierListBox.SelectedIndexChanged, AddressOf valueSelected
            End If
            AddHandler tierListBox.Click, AddressOf showMyControls

            Dim tierAdd As Button
            tierAdd = New Button()
            With tierAdd
                .Name = "TierAdd" + CStr(i)
                .Tag = CStr(i)
                .Visible = False
                .Width = 23
                .Height = 23
                .Left = (CInt(i) - 1) * 40 + 260
                .Top = (CInt(i) - 1) * 75 + 10
                .Image = My.Resources.Resources.icon_add
            End With
            SystemNumberPanel1.Controls.Add(tierAdd)
            AddHandler tierAdd.Click, AddressOf addNumber

            Dim tierRemove As Button
            tierRemove = New Button()
            With tierRemove
                .Name = "TierRemove" + CStr(i)
                .Tag = CStr(i)
                .Enabled = False
                .Visible = False
                .Width = 23
                .Height = 23
                .Left = (CInt(i) - 1) * 40 + 260
                .Top = (CInt(i) - 1) * 75 + 33
                .Image = My.Resources.Resources.icon_delete
            End With
            SystemNumberPanel1.Controls.Add(tierRemove)
            AddHandler tierRemove.Click, AddressOf deleteNumber

            Dim tierEdit As Button
            tierEdit = New Button()
            With tierEdit
                .Name = "TierEdit" + CStr(i)
                .Tag = CStr(i)
                .Enabled = False
                .Visible = False
                .Width = 23
                .Height = 23
                .Left = (CInt(i) - 1) * 40 + 260
                .Top = (CInt(i) - 1) * 75 + 56
                .Image = My.Resources.Document_1_Edit
            End With
            SystemNumberPanel1.Controls.Add(tierEdit)
            AddHandler tierEdit.Click, AddressOf editSystem
        Next i
    End Sub


    Private Sub valueSelected(ByVal sender As Object, ByVal e As System.EventArgs)
        If loading = False Then
            thisList = sender
            Dim thisTier As Integer = CInt(thisList.Tag)
            Dim showThisValue As String = Nothing

            Dim query As String = "SELECT sn.Identifier FROM system_number sn WHERE MUID='" + CStr(thisList.SelectedValue) + "'"
            Dim oldWidth As Integer
            Dim newWidth As Integer = 0
            Dim maxTierLength As Integer = 2
            Dim dt As DataTable

            Try
                dt = runtime.SQLProject.ExecuteQuery(query)
                If dt.Rows.Count > 0 Then
                    Dim thisTierLength As Integer
                    thisTierLength = CStr(dt.Rows(0)(0)).Length
                    If thisTierLength > maxTierLength Then maxTierLength = thisTierLength
                    showThisValue = dt.Rows(0)(0)
                End If
            Catch ex As Exception
                MessageBox.Show("Failed to populate Systems Tier" + CStr(thisTier) + ": " + ex.Message)
            End Try

            'write selected value to label text field
            For Each thisControl As Control In SystemNumberPanel2.Controls
                If thisControl.Name = "Label" + CStr(thisList.Tag) Then
                    thisControl.Text = showThisValue
                End If
            Next thisControl

            'get new width if there is one
            For Each thisControl As Control In SystemNumberPanel2.Controls
                If thisControl.Name = "Label" + CStr(thisTier) Then
                    oldWidth = thisControl.Width

                    If oldWidth <> 18 * maxTierLength Then
                        thisControl.Width = 18 * maxTierLength
                        newWidth = thisControl.Width
                    End If

                End If
            Next thisControl

            'resize and move all labels
            If newWidth <> 0 Then
                Dim i As Integer
                For i = 1 To Utilities.CountTiers()
                    For Each thisControl As Control In SystemNumberPanel2.Controls
                        If CInt(thisControl.Tag) > thisTier Then
                            If thisControl.Name = "Label" + CStr(i) Then
                                thisControl.Left = thisControl.Left + (newWidth - oldWidth)
                            End If
                        End If
                    Next thisControl
                Next i
            End If
        End If
    End Sub


    Private Sub valueSelectedSS(ByVal sender As Object, ByVal e As System.EventArgs)
        If loading = False Then
            thisList = sender
            Dim thisTier As Integer = CInt(thisList.Tag)
            Dim showThisValue As String = Nothing
            Dim query As String = "SELECT sn.Identifier FROM system_number sn WHERE MUID='" + CStr(thisList.SelectedValue) + "'"
            Dim oldWidth As Integer
            Dim newWidth As Integer = 0
            Dim maxTierLength As Integer = 2
            Dim dt As DataTable

            Try
                dt = runtime.SQLProject.ExecuteQuery(query)
                If dt.Rows.Count > 0 Then
                    Dim thisTierLength As Integer
                    thisTierLength = CStr(dt.Rows(0)(0)).Length
                    If thisTierLength > maxTierLength Then maxTierLength = thisTierLength
                    showThisValue = dt.Rows(0)(0)
                End If
            Catch ex As Exception
                MessageBox.Show("Failed to populate Systems Tier" + CStr(thisTier) + ": " + ex.Message)
            End Try

            'write selected value to label text field
            For Each thisControl As Control In SystemNumberPanel2.Controls
                If thisControl.Name = "Label" + CStr(thisList.Tag) Then
                    thisControl.Text = showThisValue
                End If
            Next thisControl

            'get new width if there is one
            For Each thisControl As Control In SystemNumberPanel2.Controls
                If thisControl.Name = "Label" + CStr(thisTier) Then
                    oldWidth = thisControl.Width

                    If oldWidth <> 18 * maxTierLength Then
                        thisControl.Width = 18 * maxTierLength
                        newWidth = thisControl.Width
                    End If

                End If
            Next thisControl

            'resize and move all labels
            If newWidth <> 0 Then
                Dim i As Integer
                For i = 1 To Utilities.CountTiers()
                    For Each thisControl As Control In SystemNumberPanel2.Controls
                        If CInt(thisControl.Tag) > thisTier Then
                            If thisControl.Name = "Label" + CStr(i) Then
                                thisControl.Left = thisControl.Left + (newWidth - oldWidth)
                            End If
                        End If
                    Next thisControl
                Next i
            End If

            PopulateSubSystem(thisTier + 1, thisList.SelectedValue)

            For Each thisControl As Control In SystemNumberPanel1.Controls
                If thisControl.Name = "Tier" + CStr(thisList.Tag) Then
                    thisControl.Select()
                    thisList = thisControl
                End If
            Next thisControl

        End If

    End Sub


    Private Sub showMyControls(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim MyList As ListBox = sender
        selectedList = CInt(MyList.Tag)

        Dim i As Integer
        For i = 1 To Utilities.CountTiers()
            For Each thisControl As Control In SystemNumberPanel1.Controls
                If thisControl.Name = "TierAdd" + CStr(i) Then
                    thisControl.Visible = False
                End If
                If thisControl.Name = "TierRemove" + CStr(i) Then
                    thisControl.Visible = False
                    thisControl.Enabled = False
                End If
                If thisControl.Name = "TierEdit" + CStr(i) Then
                    thisControl.Visible = False
                    thisControl.Enabled = False
                End If
            Next thisControl
        Next i

        For Each thisControl As Control In SystemNumberPanel1.Controls

            If thisControl.Name = "TierAdd" + MyList.Tag Then
                thisControl.Visible = True
            End If

            If thisControl.Name = "TierRemove" + MyList.Tag Then
                thisControl.Visible = True
                If Not MyList.SelectedValue = Nothing Then
                    thisControl.Enabled = True
                End If
            End If

            If thisControl.Name = "TierEdit" + MyList.Tag Then
                thisControl.Visible = True
                If Not MyList.SelectedValue = Nothing Then
                    thisControl.Enabled = True
                End If
            End If

        Next thisControl
    End Sub


    Private Sub addNumber(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim thisDir = daqartDLL.Utilities.GetDirectory()
        addSystemNumber.listValue = selectedList

        For Each thisControl As Control In SystemNumberPanel1.Controls
            If thisControl.Name = "Tier" + CStr(selectedList - 1) Then
                Dim thisList As ListBox = thisControl
                addSystemNumber.thisParent = thisList.SelectedValue
            End If
        Next thisControl

        addSystemNumber.thisTier = selectedList

        addSystemNumber.ShowDialog()
        PopulateListBoxes(selectedList)
    End Sub


    Private Sub deleteNumber(ByVal sender As Object, ByVal e As System.EventArgs)
        For Each thisControl As Control In SystemNumberPanel1.Controls
            If thisControl.Name = "Tier" + CStr(thisList.Tag) Then
                Dim result As Integer
                Dim query As String = "DELETE FROM system_number WHERE ParentLinkMUID=@ParentLink"

                Try
                    Dim dt_param As DataTable = runtime.SQLProject.paramDT
                    dt_param.Rows.Add("@ParentLink", thisList.SelectedValue)

                    runtime.SQLProject.ExecuteNonQuery(query, dt_param)
                Catch ex As Exception
                    MessageBox.Show("Failed to add project to Projects table: " + ex.Message)
                End Try

                query = "DELETE FROM system_number WHERE MUID=@MUID"
                Try
                    Dim dt_param As DataTable = runtime.SQLProject.paramDT
                    dt_param.Rows.Add("@MUID", thisList.SelectedValue)

                    runtime.SQLProject.ExecuteNonQuery(query, dt_param)
                Catch ex As Exception
                    MessageBox.Show("Failed to add project to Projects table: " + ex.Message)
                End Try
            End If
        Next thisControl

        If thisList.Tag = "1" Then
            PopulateListBoxes(selectedList)
        Else
            For Each thisControl As Control In SystemNumberPanel1.Controls
                If thisControl.Name = "Tier" + CStr(CInt(thisList.Tag) - 1) Then
                    Dim thisList As ListBox = thisControl
                    Dim hasSubSystem As Boolean
                    Dim dt As DataTable

                    Dim query As String = "SELECT * FROM system_mnemonic " & _
                        " WHERE MUID='" + CStr(CInt(thisList.Tag) - 1) + "'" & _
                        " AND SubSystem='True'"

                    Try
                        dt = runtime.SQLProject.ExecuteQuery(query)

                        If dt.Rows.Count > 0 Then
                            hasSubSystem = True
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Failed to add project to Projects table: " + ex.Message)
                    End Try

                    If hasSubSystem = True Then
                        PopulateListBoxes(selectedList)
                        PopulateSubSystem(selectedList + 1, thisList.SelectedValue)
                    Else
                        PopulateListBoxes(selectedList)
                    End If

                End If

            Next thisControl
        End If
        CheckBlanks()
    End Sub


    Private Sub editSystem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SystemID As String = ""

        For Each thisControl As Control In SystemNumberPanel1.Controls
            If thisControl.Name = "Tier" + CStr(selectedList) Then
                Dim thisListBox As New ListBox
                thisListBox = thisControl

                SystemID = thisListBox.SelectedValue
            End If
        Next


        Dim frm_EditSystem As New editSystemNumber
        frm_EditSystem.SystemID = SystemID
        frm_EditSystem.ShowDialog()

        For i As Integer = 1 To Utilities.CountTiers()
            PopulateListBoxes(i)
        Next i
    End Sub


    Public Sub PopulateListBoxes(ByVal thisTier As Integer)
        Dim ParentID As String = Nothing
        Dim query As String = "SELECT sm.MUID,sm.SubSystem,sn.MUID,sn.Identifier,sn.Description, sn.Identifier +' - '+ sn.Description As showThis " & _
                            " FROM system_mnemonic sm RIGHT JOIN " & _
                            " system_number sn ON sm.TierNumber=sn.TierMUID WHERE sm.TierNumber='" _
                            + CStr(thisTier) + "' Order by sn.Identifier Asc"

        For Each thisControl As Control In SystemNumberPanel1.Controls
            If thisControl.Name = "Tier" + CStr(thisTier - 1) Then
                Dim thisListBox As New ListBox
                thisListBox = thisControl
                ParentID = thisListBox.SelectedValue
            End If

            If thisControl.Name = "Tier" + CStr(thisTier) Then
                Dim thisListBox As ListBox = thisControl
                If Not SystemManager.SystemDataManager.HasParent(thisTier) = "True" Then
                    Try
                        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

                        thisListBox.DataSource = dt
                        thisListBox.DisplayMember = dt.Columns(5).ToString
                        thisListBox.ValueMember = dt.Columns(2).ToString
                    Catch ex As Exception
                        MessageBox.Show("Failed to populate Level list: " + ex.Message)
                    End Try
                Else
                    PopulateSubSystem(thisTier, ParentID)
                End If

            End If
        Next thisControl
    End Sub


    Public Sub PopulateSubSystem(ByVal thisTier As Integer, ByVal thisParent As String)
        Dim query As String = "SELECT sm.MUID,sm.SubSystem,sn.MUID,sn.Identifier,sn.Description, sn.Identifier +' - '+ sn.Description As showThis " & _
                            " FROM system_mnemonic sm RIGHT JOIN " & _
                            " system_number sn ON sm.TierNumber=sn.TierMUID WHERE sm.TierNumber='" _
                            + CStr(thisTier) + "' AND ParentLinkMUID='" + CStr(thisParent) + "'" & _
                            " ORDER BY sn.Identifier ASC"

        For Each thisControl As Control In SystemNumberPanel1.Controls
            If thisControl.Name = "Tier" + CStr(thisTier) Then
                Dim thisListBox As ListBox = thisControl
                Try
                    Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

                    thisListBox.DataSource = dt
                    thisListBox.DisplayMember = dt.Columns(5).ToString
                    thisListBox.ValueMember = dt.Columns(2).ToString
                Catch ex As Exception
                    MessageBox.Show("Failed to populate Level list: " + ex.Message)
                End Try

            End If
        Next thisControl

        CheckBlanks()
    End Sub


    Private Sub CreateLabels()
        Dim labelObject As Label
        Dim i As Integer
        For i = 1 To Utilities.CountTiers()

            Dim query As String = "SELECT TierColor FROM system_mnemonic WHERE TierNumber='" + CStr(i) + "';"
            Dim ListBoxColor As String = Nothing

            Try
                Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
                If dt.Rows.Count > 0 Then
                    ListBoxColor = dt.Rows(0)(0)
                End If
            Catch ex As Exception
                MessageBox.Show("Cannot get Tier Color: " + ex.Message)
            End Try

            Dim selectionColor As Array
            selectionColor = Split(ListBoxColor, ",")

            labelObject = New Label()
            With labelObject
                .Name = "Label" + CStr(i)
                .Tag = CStr(i)
                .Visible = True
                .Width = 36
                .Height = 36
                .Left = newLabelLeft
                .Top = 2
                .BackColor = Color.FromArgb(CInt(selectionColor(0)), CInt(selectionColor(1)), CInt(selectionColor(2)), CInt(selectionColor(3)))
                .BorderStyle = BorderStyle.FixedSingle
                .Font = New Font("Verdana", 10, FontStyle.Bold)
                .TextAlign = ContentAlignment.MiddleCenter
            End With

            newLabelLeft = newLabelLeft + labelObject.Width - 1
            SystemNumberPanel2.Controls.Add(labelObject)
        Next i
    End Sub


    Public Sub CheckBlanks()
        Dim hasValue As Boolean = True
        Dim i As Integer

        For i = 1 To Utilities.CountTiers()
            Dim thisString = "Tier" + CStr(i)
            For Each thisControl As Control In SystemNumberPanel1.Controls
                If thisControl.Name = thisString Then
                    If thisControl.Text = "" Then hasValue = False
                End If
            Next thisControl
        Next i

        If (hasValue = False) Then
            CreateSystemNumbersFinish.Enabled = False
        Else
            CreateSystemNumbersFinish.Enabled = True
        End If
    End Sub


    Private Sub CreateSystemNumbersCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateSystemNumbersCancel.Click
        Me.Dispose()
    End Sub


    Private Sub CreateSystemNumbersFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateSystemNumbersFinish.Click
        If wizard1.WizardStatus = 0 Then
            Me.Dispose()
            Return
        End If

        EndStep()
    End Sub


    Private Sub EndStep()
        wizard1.LabelStep3.ForeColor = Color.Black
        wizard1.LabelStep3.Cursor = Cursors.Arrow

        wizard1.LabelStep4.ForeColor = Color.Blue
        wizard1.LabelStep4.Cursor = Cursors.Hand
        wizard1.LabelStep4.Enabled = True

        wizard1.StatusStep3.Image = My.Resources.Resources.icon_ok
        wizard1.NextStep.Top = wizard1.NextStep.Top + 27
        wizard1.WizardStatus = 3

        MessageBox.Show("Project System Numbers Created Successfully!!")
        Me.Dispose()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm_ImportSystems As New SystemImport
        frm_ImportSystems.ShowDialog()

        For i As Integer = 1 To Utilities.CountTiers()
            PopulateListBoxes(i)
        Next i
    End Sub



End Class