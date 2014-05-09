Imports daqartDLL

Public Class SystemSelect
    Dim SystemDropDown As ComboBox
    Dim tierLabel As TextBox
    Dim HoldSystemID As TextBox
    Dim tierCount As Integer
    Dim boxY As Integer = 40
    Dim loading As Boolean = True
    Dim SystemMUID As String
    Dim SystemMUID_List As String()
    Dim ComboList As List(Of Control)



    Public Sub New(ByVal _SystemMUID As String)
        InitializeComponent()

        SystemMUID = _SystemMUID
    End Sub


    Private Sub SystemSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tierCount = Utilities.CountTiers()

        Dim BlankString As String = ""

        For i As Integer = 1 To tierCount
            CreateSystem(i)
            BlankString += ";"
        Next i

        If Not SystemMUID = "" Then
            SystemMUID_List = Split(SystemMUID, ";")
        Else
            SystemMUID_List = Split(BlankString, ";")
        End If


        For i As Integer = 1 To tierCount
            PopulateSystems(i)
        Next i

        If Not SystemMUID = "" Then
            For i As Integer = 1 To tierCount
                For Each thisControl As Control In Me.Controls

                    If thisControl.Name = "SystemIDHolder" + CStr(i) Then
                        thisControl.Text = SystemMUID_List(i - 1)
                    End If

                    If thisControl.Name = "SystemIDHolder" + CStr(i) Then
                        SystemID.Text = SystemID.Text + thisControl.Text

                        If i < tierCount Then
                            SystemID.Text = SystemID.Text + ";"
                        End If
                    End If
                Next thisControl
            Next i
        End If

        Me.CheckBlanks()

        loading = False
    End Sub


    Private Sub CreateSystem(ByVal tierNumber As Integer)
        tierLabel = New TextBox()
        With tierLabel
            .Name = "Label" + CStr(tierNumber)
            .Text = SystemDataManager.GetTierDescription(tierNumber)
            .BackColor = Color.White
            .Visible = True
            .ReadOnly = True
            .Width = 200
            .Left = 25
            .Top = boxY
            .Font = New Font(.Font.Name, 8, _
                .Font.Style)

        End With
        Me.Controls.Add(tierLabel)

        HoldSystemID = New TextBox()
        With HoldSystemID
            .Name = "SystemIDHolder" + CStr(tierNumber)
            .BackColor = Color.White
            .Visible = False
            .ReadOnly = True
            .Width = 50
            .Left = 275
            .Top = boxY
        End With
        Me.Controls.Add(HoldSystemID)

        SystemDropDown = New ComboBox()
        With SystemDropDown
            .Name = "Tier" + CStr(tierNumber)
            .Tag = CStr(tierNumber)
            .Visible = True
            .Width = 350
            .Left = 225
            .Top = boxY
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
        Me.Controls.Add(SystemDropDown)

        boxY = boxY + 22
        AddHandler SystemDropDown.SelectedValueChanged, AddressOf ValueSelected
    End Sub


    Private Sub PopulateSystems(ByVal tierNumber As Integer)
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()

        Dim ParentID As String = Nothing
        Dim ParentCriteria As String = Nothing
        If SystemDataManager.HasParent(tierNumber) Then

            For Each thisControl As Control In Me.Controls
                If thisControl.Name = "Tier" + CStr(tierNumber - 1) Then
                    Dim thisDropDown As ComboBox
                    thisDropDown = thisControl
                    ParentID = thisDropDown.SelectedValue
                End If
            Next thisControl

            ParentCriteria = " AND ParentLinkMUID='" + ParentID + "'"
        Else
            ParentCriteria = Nothing
        End If

        Dim query As String = "SELECT sn.MUID, sn.Identifier+' - '+ sn.Description As showThis " & _
                            " FROM system_number sn WHERE TierMUID='" _
                            + CStr(tierNumber) + "' " + ParentCriteria + " Order by sn.Identifier Asc"

        Dim CBX_RESET As Boolean = False


        Try

            For Each thisControl As Control In Me.Controls
                If thisControl.Name = "Tier" + CStr(tierNumber) Then
                    Dim LevelDataset As New DataSet
                    Dim thisDropDown As New ComboBox
                    thisDropDown = thisControl
                    thisDropDown.Text = ""

                    Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
                    thisDropDown.DataSource = dt
                    thisDropDown.DisplayMember = dt.Columns(1).ToString
                    thisDropDown.ValueMember = dt.Columns(0).ToString

                    If Not Me.SystemMUID_List(tierNumber - 1) = "" Then
                        thisDropDown.SelectedValue = Me.SystemMUID_List(tierNumber - 1)
                    Else
                        thisDropDown.SelectedIndex = -1
                        CBX_RESET = True
                    End If

                End If
            Next thisControl

            For Each thisControl As Control In Me.Controls
                If thisControl.Name = "SystemIDHolder" + CStr(tierNumber) And CBX_RESET Then
                    Dim thisTextBox As New TextBox
                    thisTextBox = thisControl
                    thisTextBox.Text = ""
                End If
            Next thisControl

        Catch ex As Exception
            Utilities.logErrorMessage("SystemManager.SystemSelect.PopulateSystem-" + ex.Message)
            'MessageBox.Show(ex.Message)
        End Try





        'For Each thisControl As Control In Me.Controls
        '    If thisControl.Name = "Tier" + CStr(tierNumber + 1) Then
        '        Dim tmpCombo As ComboBox
        '        tmpCombo = thisControl
        '        tmpCombo.SelectedIndex = -1
        '    End If
        'Next

        sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub ValueSelected(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Not loading Then
                SystemID.Text = Nothing
                Dim i As Integer
                Dim thisCombo As New ComboBox
                thisCombo = sender
                Dim thisID As String = thisCombo.SelectedValue.ToString
                Dim EmptySystems As Boolean = False

                For i = 1 To tierCount
                    For Each thisControl As Control In Me.Controls

                        If thisControl.Name = "SystemIDHolder" + thisCombo.Tag Then
                            thisControl.Text = thisID
                        End If

                        If thisControl.Name = "SystemIDHolder" + CStr(i) Then
                            SystemID.Text = SystemID.Text + thisControl.Text

                            If i < tierCount Then
                                SystemID.Text = SystemID.Text + ";"
                            End If
                        End If
                    Next thisControl
                Next i

                If SystemDataManager.IsParent(CInt(thisCombo.Tag)) Then
                    PopulateSystems(CInt(thisCombo.Tag) + 1)
                Else
                    'clear tier below
                    For Each thisControl As Control In Me.Controls
                        If thisControl.Name = "Tier" + CStr(CInt(thisCombo.Tag) + 1) Then
                            Dim tmpCombo As New ComboBox
                            tmpCombo = thisControl
                            tmpCombo.SelectedIndex = -1
                        End If

                    Next

                End If

                Dim w As Integer = CInt(thisCombo.Tag) + 1
                For Each thisControl As Control In Me.Controls
                    If thisControl.Name = "Tier" + CStr(w) Then
                        Dim tmpCombo As New ComboBox
                        tmpCombo = thisControl

                        If tmpCombo.SelectedValue = "" Then
                            EmptySystems = True
                        End If
                        w += 1
                    End If
                Next thisControl


                If EmptySystems Then
                    Me.btn_Select.Enabled = False
                Else
                    Me.btn_Select.Enabled = True
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Select.Click

        If Not SystemDataManager.SystemValidate(SystemID.Text) Then
            MessageBox.Show("You have not selected a complete system number.")
            Return
        End If

        Me.Close()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SystemID.Text = ""
        Me.Dispose()
    End Sub



    Private Function CheckBlanks() As Boolean
        Dim ReturnValue As Boolean = True

        For i As Integer = 1 To tierCount
            For Each thisControl As Control In Me.Controls

                If thisControl.Name = "SystemIDHolder" + CStr(i) Then
                    If thisControl.Text = "" Then
                        ReturnValue = False
                    End If
                End If
            Next thisControl
        Next i

        'If ReturnValue Then
        '    Me.btn_Select.Enabled = True
        'Else
        '    Me.btn_Select.Enabled = False
        'End If

    End Function



End Class