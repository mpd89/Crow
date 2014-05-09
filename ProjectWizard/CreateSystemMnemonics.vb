Option Explicit On

Imports System
Imports System.Windows.Forms
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports daqartDLL


Public Class CreateSystemMnemonics
    Dim newLabelTop As Integer = 2
    Dim labelObject As Label
    Dim WithEvents tierTextBox As TextBox
    Dim tierSeparatorTextBox As TextBox
    Dim tierSubsystem As CheckBox
    Dim tierColor As Button
    Dim SQLProject As DataUtils

    Dim WithEvents cbx_IsHandover As ComboBox
    Dim WithEvents cbx_HandoverType As ComboBox
    Dim WithEvents tbx_HandoverForm As TextBox


    Private Sub CreateSystemMnemonics_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLProject.CloseConnection()
    End Sub


    Private Sub CreateSystemMnemonics_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SQLProject = New DataUtils("project")
        SQLProject.OpenConnection()
    End Sub


    Private Sub SystemMnemonicCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemMnemonicCancel.Click
        Me.Dispose()
    End Sub


    Private Sub SystemMnemonicNext1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemMnemonicNext1.Click
        Try
            Dim i As Integer
            For i = 1 To SystemMnemonicCount.Value
                CreateTier(i)
            Next i

            SystemMnemonicsPanel1.Visible = False
            SystemMnemonicsPanel2.Visible = True
        Catch ex As Exception
            Utilities.logErrorMessage("ProjectWizard.CreateSystemnemonics.Next1-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub CreateTier(ByVal tierInfo As Integer)
        labelObject = New Label()
        With labelObject
            .Name = "Label" + CStr(tierInfo)
            .Text = CStr(tierInfo)
            .Visible = True
            .Width = 23
            .Height = 20
            .Left = 0
            .Top = newLabelTop
            .TextAlign = ContentAlignment.MiddleCenter
        End With

        tierTextBox = New TextBox()
        With tierTextBox
            .Name = "Tier" + CStr(tierInfo)
            .Tag = "Label" + CStr(tierInfo)
            .Visible = True
            .Width = 175
            .Height = 20
            .Left = 35
            .Top = newLabelTop
            .MaxLength = 100
        End With

        tierColor = New Button()
        With tierColor
            .Name = "TierColor" + CStr(tierInfo)
            .Tag = CStr(tierInfo)
            .Visible = True
            .Width = 25
            .Height = 20
            .Left = 210
            .Top = newLabelTop
            .Text = "..."
        End With

        tierSeparatorTextBox = New TextBox()
        With tierSeparatorTextBox
            .Name = "TierSeparator" + CStr(tierInfo)
            If tierInfo <> SystemMnemonicCount.Value Then
                .Visible = True
            Else
                .Visible = False
            End If
            .Width = 30
            .Height = 20
            .Left = 250
            .Top = newLabelTop
            .MaxLength = 1
        End With

        tierSubsystem = New CheckBox()
        With tierSubsystem
            .Name = "TierSubsystem" + CStr(tierInfo)
            .Visible = True
            .Left = 330
            .Height = 20
            .Width = 20
            .Text = Nothing
            .Top = newLabelTop + 1
        End With

        Me.cbx_IsHandover = New ComboBox()
        With cbx_IsHandover
            .Name = "TierIsHandover" + CStr(tierInfo)
            .Visible = True
            .Left = 350
            .Height = 20
            .Width = 75
            .Text = Nothing
            .Top = newLabelTop
            .Items.Add("true")
            .Items.Add("false")
        End With

        Me.cbx_HandoverType = New ComboBox()
        With cbx_HandoverType
            .Name = "TierHandoverType" + CStr(tierInfo)
            .Visible = True
            .Left = 425
            .Height = 20
            .Width = 50
            .Text = Nothing
            .Top = newLabelTop
            .Items.Add("MC")
            .Items.Add("SH")
        End With

        'Me.tbx_HandoverForm = New TextBox()
        'With tbx_HandoverForm
        '    .Name = "TierHandoverForm" + CStr(tierInfo)
        '    .Visible = True
        '    .Left = 350
        '    .Height = 20
        '    .Width = 20
        '    .Text = Nothing
        '    .Top = newLabelTop
        'End With


        Me.SystemMnemonicsPanel3.Controls.Add(labelObject)
        Me.SystemMnemonicsPanel3.Controls.Add(tierTextBox)
        Me.SystemMnemonicsPanel3.Controls.Add(tierColor)
        Me.SystemMnemonicsPanel3.Controls.Add(tierSeparatorTextBox)
        Me.SystemMnemonicsPanel3.Controls.Add(tierSubsystem)
        Me.SystemMnemonicsPanel3.Controls.Add(cbx_IsHandover)
        Me.SystemMnemonicsPanel3.Controls.Add(cbx_HandoverType)
        'Me.SystemMnemonicsPanel3.Controls.Add(tbx_HandoverForm)

        AddHandler tierTextBox.TextChanged, AddressOf CheckBlanks
        AddHandler tierColor.Click, AddressOf GetColor


        newLabelTop = newLabelTop + 25
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SystemMnemonicsPanel3.Controls.Clear()
        newLabelTop = 15
        SystemMnemonicsPanel2.Visible = False
        SystemMnemonicsPanel1.Visible = True
    End Sub


    Private Sub CheckBlanks(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim hasValue As Boolean = True

        Dim i As Integer
        For i = 1 To SystemMnemonicCount.Value
            Dim thisString = "Tier" + CStr(i)
            For Each thisControl As Control In SystemMnemonicsPanel3.Controls
                If thisControl.Name = thisString Then
                    If thisControl.Text = "" Then hasValue = False
                End If
            Next thisControl
        Next i

        If (hasValue = False) Then
            SystemMnemonicsPanel2Next.Enabled = False
        Else
            SystemMnemonicsPanel2Next.Enabled = True
        End If
    End Sub


    Private Sub GetColor(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim thisColor As Button
        thisColor = sender

        With ColorDialog1
            .ShowDialog(Me)

            For Each thisControl As Control In SystemMnemonicsPanel3.Controls
                If thisControl.Name = "Tier" + CStr(thisColor.Tag) Then
                    Dim thisListBox As TextBox
                    thisListBox = thisControl
                    thisListBox.BackColor = .Color
                End If
            Next thisControl
        End With
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub


    Private Sub SystemMnemonicsPanel2Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemMnemonicsPanel2Next.Click

        Dim showMnemonicLeft As Integer = 150 - (SystemMnemonicCount.Value * 28 / 2)
        Dim i As Integer
        Dim thisColor As Color

        For i = 1 To SystemMnemonicCount.Value

            For Each thisControl As Control In SystemMnemonicsPanel3.Controls

                If thisControl.Name = ("Tier" + CStr(i)) Then
                    thisColor = thisControl.BackColor
                End If

            Next thisControl

            labelObject = New Label()
            With labelObject
                .Name = "showLabel" + CStr(i)
                .Text = CStr(i) + CStr(i)
                .BackColor = thisColor
                .Visible = True
                .Width = 28
                .Height = 20
                .Left = showMnemonicLeft
                .Top = 80
                .Font = New System.Drawing.Font("Arial", 10, FontStyle.Bold)
                .TextAlign = ContentAlignment.MiddleCenter
                .BorderStyle = BorderStyle.FixedSingle
            End With


            showMnemonicLeft = showMnemonicLeft + 27
            Me.SampleMnemonic.Controls.Add(labelObject)

            Dim thisString = "TierSeparator" + CStr(i)
            For Each thisControl As Control In SystemMnemonicsPanel3.Controls
                If thisControl.Name = thisString Then
                    If thisControl.Text <> "" Then
                        labelObject = New Label()
                        With labelObject
                            .Name = "showSep" + CStr(i)
                            .Text = thisControl.Text
                            .Visible = True
                            .Width = 20
                            .Height = 20
                            .Left = showMnemonicLeft
                            .Top = 80
                            .Font = New System.Drawing.Font("Arial", 10, FontStyle.Bold)
                            .TextAlign = ContentAlignment.MiddleCenter
                            .BorderStyle = BorderStyle.FixedSingle
                        End With

                        showMnemonicLeft = showMnemonicLeft + 19
                        Me.SampleMnemonic.Controls.Add(labelObject)

                    End If
                End If
            Next thisControl
        Next i

        SystemMnemonicsPanel4.Visible = True
        SystemMnemonicsPanel2.Visible = False
    End Sub


    Private Sub SystemMnemonicsPanel4Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemMnemonicsPanel4Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub SystemMnemonicsPanel4Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemMnemonicsPanel4Back.Click
        SampleMnemonic.Controls.Clear()
        SystemMnemonicsPanel2.Visible = True
        SystemMnemonicsPanel4.Visible = False
    End Sub


    Private Sub SystemMnemonicsPanel4Finish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemMnemonicsPanel4Finish.Click
        Dim i As Integer
        For i = 1 To SystemMnemonicCount.Value

            Dim query As String = Nothing
            Dim querySeparator As String = Nothing
            Dim queryDescription As String = Nothing
            Dim querySubSystem As String = Nothing
            Dim queryColor As String = Nothing
            Dim queryIsHandover As String = Nothing
            Dim queryHandoverType As String = Nothing

            query = "INSERT INTO system_mnemonic (MUID,TierNumber,TS,Sep,Description,SubSystem,TierColor,Aux09,Aux08) VALUES (" & _
                    " @MUID," & _
                    " @TierNumber," & _
                    " @TS, " & _
                    " @Sep, " & _
                    " @Description, " & _
                    " @SubSystem, " & _
                    " @TierColor," & _
                    " @IsHandover," & _
                    " @HandoverType" & _
                    " )"

            For Each thisControl As Control In SystemMnemonicsPanel3.Controls
                If thisControl.Name = ("TierSeparator" + CStr(i)) Then
                    querySeparator = "" & thisControl.Text & ""
                End If

                If thisControl.Name = ("Tier" + CStr(i)) Then
                    queryDescription = "" & thisControl.Text & ""
                    queryColor = "" & thisControl.BackColor.A & "," & thisControl.BackColor.R & "," & thisControl.BackColor.G & "," & thisControl.BackColor.B & ""
                End If

                If thisControl.Name = ("TierSubsystem" + CStr(i)) Then
                    Dim showMe As CheckBox = thisControl
                    If showMe.CheckState = CheckState.Checked Then
                        querySubSystem = "True"
                    Else
                        querySubSystem = "False"
                    End If
                End If

                If thisControl.Name = ("TierIsHandover" + CStr(i)) Then
                    queryIsHandover = "" & thisControl.Text & ""
                End If

                If thisControl.Name = ("TierHandoverType" + CStr(i)) Then
                    queryHandoverType = "" & thisControl.Text & ""
                End If

            Next thisControl

            'query = query & querySeparator & queryDescription & querySubSystem & queryColor & ");"

            Dim dt_param As DataTable = SQLProject.paramDT
            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "system_mnemonic"))
            dt_param.Rows.Add("@TierNumber", i)
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@Sep", querySeparator)
            dt_param.Rows.Add("@Description", queryDescription)
            dt_param.Rows.Add("@SubSystem", querySubSystem)
            dt_param.Rows.Add("@TierColor", queryColor)
            dt_param.Rows.Add("@IsHandover", queryIsHandover)
            dt_param.Rows.Add("@HandoverType", queryHandoverType)

            Try
                SQLProject.ExecuteNonQuery(query, dt_param)
            Catch ex As Exception
                MessageBox.Show("Failed to insert System Tiers to Projects table: " + ex.Message)
            End Try
        Next i

        EndStep()
    End Sub


    Private Sub EndStep()
        wizard1.LabelStep2.ForeColor = Color.Black
        wizard1.LabelStep2.Cursor = Cursors.Arrow

        wizard1.LabelStep3.ForeColor = Color.Blue
        wizard1.LabelStep3.Cursor = Cursors.Hand
        wizard1.LabelStep3.Enabled = True

        wizard1.StatusStep2.Image = My.Resources.Resources.icon_ok
        wizard1.NextStep.Top = wizard1.NextStep.Top + 27
        wizard1.WizardStatus = 2

        MessageBox.Show("Project System Mnemonics Created Successfully!!")
        Me.Dispose()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Help.ShowHelp(Me, runtime.AbsolutePath() + "\daqart.chm", HelpNavigator.Topic, "CreateSystemMnemonics.htm")
    End Sub

End Class