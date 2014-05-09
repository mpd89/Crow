Imports DaqartDLL
Imports System.Drawing.Printing
Imports System.IO
Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class WeldWPSProcFormView
    Private orgDt As DataTable
    Private mdfdDT As DataTable
    Private CurrentPage As Integer = 1
    Private WPSProcID As Integer
    Private pgInfo() As PrintUtils.InfoSetting
    Private PrintDoc As PrintDocument
    Private _DonePrinting As Boolean = False
    Private pgCtr As Integer = -1
    Private imgdir As String = runtime.AbsolutePath + "sites\Forms\images\imgList"
    Private TopMargin As Integer = 300
    Private _StartingTop As Integer = TopMargin
    Private _StartingLeft As Integer = 50
    Private _PageSize As Size

    Public Sub New(ByVal _WPSProcID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        WPSProcID = _WPSProcID
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub WeldWPSProcFormView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.tbx_PageNo.Text = "Page 1 of 3"
            Me.Panel1.Visible = True
            Me.Panel2.Visible = False
            Me.Panel3.Visible = False

            Me.Panel1.Size = Me.Panel1.BackgroundImage.Size
            Me.Panel2.Size = Me.Panel2.BackgroundImage.Size
            'Dim bmp As New Bitmap(Me.Panel1.BackgroundImage.Size.Width, Me.Panel1.BackgroundImage.Size.Height)
            'Dim g As Graphics = Graphics.FromImage(bmp)
            'g.FillRectangle(New SolidBrush(Color.White), 0, 0, bmp.Width, bmp.Height)

            'bmp.Save("C:\tmp\AAA", ImageFormat.Png)


            Me.Panel3.Size = Me.Panel1.BackgroundImage.Size
            Me.Panel4.Size = Me.Panel1.Size 'New Size(Me.Panel1.Size.Width, Me.Panel1.Size.Height - 500)
            Me.Size = New Size(Me.Panel1.Size.Width, Me.Panel1.Size.Height - 100)
            Me.Panel1.Location = New Point(0, 0)
            Me.Panel2.Location = New Point(0, 0)
            Me.Panel3.Location = New Point(0, 0)

            RefreshFormControls()
            If WPSProcID > 0 Then
                Me.tbx_WPS_No.Enabled = False
                Me.Text = "New Form"
            Else
                Me.Text = orgDt.Rows(0)("WPS_No").ToString
            End If
        Catch ex As Exception
            MessageBox.Show("WeldWPSProcedure " + ex.Message)
        End Try

    End Sub



    Private Sub PopulateGroupCheckbox(ByVal Var As String, ByVal Val As String)
        Select Case Var
            Case "POS_WeldProgressionUpDown"
                Select Case Val
                    Case "Up"
                        Me.groupckb_POS_WeldProgressionUp.Checked = True
                    Case "Down"
                        Me.groupckb_POS_WeldProgressionDown.Checked = True
                End Select
            Case "SHLD_Shielding_Gas_Flux"
                Select Case Val
                    Case "Gas"
                        Me.groupckb_SHLD_ShieldingGas.Checked = True
                    Case "Flux"
                        Me.groupckb_SHLD_ShieldingFlux.Checked = True
                End Select
            Case "ELEC_Current_AC_DCEP_DCEN_PULSED"
                Select Case Val
                    Case "AC"
                        Me.groupckb_ELEC_Current_AC.Checked = True
                    Case "DCEN"
                        Me.groupckb_ELEC_Current_DCEN.Checked = True
                    Case "DCEP"
                        Me.groupckb_ELEC_Current_DCEP.Checked = True
                    Case "PULSED"
                        Me.groupckb_ELEC_Current_PULSED.Checked = True
                End Select
            Case "JDU_Single_Dbl_Weld"
                Select Case Val
                    Case "Single"
                        Me.groupckb_JDU_Single.Checked = True
                    Case "Double"
                        Me.groupckb_JDU_Double.Checked = True
                End Select
            Case "JDU_Backing_YesNo"
                Select Case Val
                    Case "Yes"
                        Me.groupckb_JDU_BackingYes.Checked = True
                    Case "No"
                        Me.groupckb_JDU_BackingNo.Checked = True
                End Select
            Case "JDU_BackGouging_YesNO"
                Select Case Val
                    Case "Yes"
                        Me.groupckb_JDU_BackGougingYesNO.Checked = True
                    Case "No"
                        Me.groupckb_JDU_BackGougingNo.Checked = True
                End Select
            Case "WPS_Prequalified"
                Select Case Val
                    Case "Prequalified"
                        Me.groupckb_WPS_Prequalified.Checked = True
                    Case "QlfdByTesting"
                        Me.groupckb_WPS_QlfdByTesting.Checked = True
                End Select
            Case "ELEC_Mode_ShortCircuiting_Globular_Spray"
                Select Case Val
                    Case "ShortCircuiting"
                        Me.groupckb_ELEC_ShortCircuiting.Checked = True
                    Case "Globular"
                        Me.groupckb_ELEC_Globular.Checked = True
                    Case "Spray"
                        Me.groupckb_ELEC_Spray.Checked = True
                End Select
        End Select
    End Sub
    Private Sub UpdateModifiedDataTable(ByVal Var As String, ByVal Val As String)
        For Each clmn As DataColumn In mdfdDT.Columns
            If clmn.Caption = Var Then
                mdfdDT.Rows(0)(clmn.Caption) = Val
            End If
        Next
    End Sub


    Private Sub PopulatePanelControls(ByVal pnl As System.Windows.Forms.Panel)

        For Each ctrl As Control In pnl.Controls
            Dim i As Integer = 0
            Dim prefix As String = ""
            Dim cName As String = ""
            Try

                prefix = Split(ctrl.Name, "_")(0)
                cName = Strings.Right(ctrl.Name, Strings.Len(ctrl.Name) - Strings.Len(prefix) - 1)
                Try

                    For Each clmn As DataColumn In orgDt.Columns
                        Select Case prefix
                            Case "tbx"
                                If clmn.Caption = cName Then
                                    ctrl.Text = orgDt.Rows(0)(clmn.Caption).ToString
                                End If
                            Case "groupckb"
                                PopulateGroupCheckbox(clmn.Caption, orgDt.Rows(0)(clmn.Caption).ToString)
                            Case "mtbx"
                                If clmn.Caption = cName Then
                                    ctrl.Text = orgDt.Rows(0)(clmn.Caption).ToString
                                End If
                            Case "lbl"
                            Case "dtp"
                                If clmn.Caption = cName Then
                                    ctrl.Text = orgDt.Rows(0)(clmn.Caption).ToString
                                End If
                        End Select
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Next

    End Sub
    Private Sub CopyPanelControlsToDataTable(ByVal pnl As System.Windows.Forms.Panel)

        For Each ctrl As Control In pnl.Controls
            Dim i As Integer = 0
            Try
                i = i + 1
                Dim prefix As String = Split(ctrl.Name, "_")(0)
                Dim cName As String = Strings.Right(ctrl.Name, Strings.Len(ctrl.Name) - Strings.Len(prefix) - 1)
                If cName = "WPS_AutorizedBy" Then
                    Dim dName = "WPS_AutorizedBy"
                End If
                For Each clmn As DataColumn In orgDt.Columns
                    If clmn.Caption = "WPS_AutorizedBy" Then
                        Dim tName As String = "WPS_AutorizedBy"
                    End If
                    Select Case prefix
                        Case "tbx"
                            If clmn.Caption = cName Then
                                mdfdDT.Rows(0)(clmn.Caption) = ctrl.Text
                            End If
                        Case "groupckb"
                            'PopulateGroupCheckbox(clmn.Caption, orgDt.Rows(0)(clmn.Caption).ToString)
                        Case "mtbx"
                            If clmn.Caption = cName Then
                                Dim tbx As TextBox = CType(ctrl, TextBox)
                                Dim str As String = ""
                                For Each ln As String In tbx.Lines
                                    str = str + ln + "\n"
                                Next
                                mdfdDT.Rows(0)(clmn.Caption) = str
                            End If
                        Case "lbl"
                        Case "dtp"
                            If clmn.Caption = cName Then
                                mdfdDT.Rows(0)(clmn.Caption) = ctrl.Text
                            End If

                    End Select
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Next
    End Sub
    Private Sub RefreshFormControls()
        Dim qry As String = "SELECT * FROM WPS_fields WHERE ID = " + WPSProcID.ToString.ToString
        'orgDt = Utilities.ExecuteRemoteQuery(qry, "")
        'mdfdDT = Utilities.ExecuteRemoteQuery(qry, "")

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        orgDt = sqlPrjUtils.ExecuteQuery(qry)
        mdfdDT = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()


        If orgDt.Rows.Count = 0 Then
            Dim r1 As DataRow = orgDt.NewRow
            orgDt.Rows.Add(r1)
            Dim r2 As DataRow = mdfdDT.NewRow
            mdfdDT.Rows.Add(r2)
        End If
        PopulatePanelControls(Panel1)
        PopulatePanelControls(Panel2)
        PopulatePanelControls(Panel3)

    End Sub

    Private Sub tsBtn_LeftArrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtn_LeftArrow.Click
        Select Case CurrentPage
            Case 2
                Me.Panel2.Visible = False
                Me.Panel3.Visible = False
                Me.Panel1.Visible = True
                Me.tbx_PageNo.Text = "Page 1 of 3"
                CurrentPage = 1
            Case 3
                Me.Panel3.Visible = False
                Me.Panel1.Visible = False
                Me.Panel2.Visible = True
                Me.tbx_PageNo.Text = "Page 2 of 3"
                CurrentPage = 2
        End Select
    End Sub

    Private Sub tsBtn_RightArrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBtn_RightArrow.Click
        Select Case CurrentPage
            Case 1
                Me.Panel1.Visible = False
                Me.Panel3.Visible = False
                Me.Panel2.Visible = True
                Me.tbx_PageNo.Text = "Page 2 of 3"
                CurrentPage = 2
            Case 2
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
                Me.Panel3.Visible = True
                Me.tbx_PageNo.Text = "Page 3 of 3"
                CurrentPage = 3
        End Select
    End Sub


    Private Sub groupckb_JDU_Single_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_JDU_Single.Click
        Me.groupckb_JDU_Double.Checked = False
        If groupckb_JDU_Single.Checked Then
            UpdateModifiedDataTable("JDU_Single_Dbl_Weld", "Single")
        Else
            UpdateModifiedDataTable("JDU_Single_Dbl_Weld", "")
        End If
    End Sub

    Private Sub groupckb_JDU_Double_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_JDU_Double.Click
        Me.groupckb_JDU_Single.Checked = False
        If groupckb_JDU_Double.Checked Then
            UpdateModifiedDataTable("JDU_Single_Dbl_Weld", "Double")
        Else
            UpdateModifiedDataTable("JDU_Single_Dbl_Weld", "")
        End If
    End Sub

    Private Sub groupckb_SHLD_ShieldingGas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_SHLD_ShieldingGas.Click
        Me.groupckb_SHLD_ShieldingFlux.Checked = False
        If Me.groupckb_SHLD_ShieldingGas.Checked Then
            UpdateModifiedDataTable("SHLD_Shielding_Gas_Flux", "Gas")
        Else
            UpdateModifiedDataTable("SHLD_Shielding_Gas_Flux", "")
        End If
    End Sub

    Private Sub groupckb_SHLD_ShieldingFlux_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_SHLD_ShieldingFlux.Click
        Me.groupckb_SHLD_ShieldingGas.Checked = False
        If Me.groupckb_SHLD_ShieldingFlux.Checked Then
            UpdateModifiedDataTable("SHLD_Shielding_Gas_Flux", "Flux")
        Else
            UpdateModifiedDataTable("SHLD_Shielding_Gas_Flux", "")
        End If
    End Sub

    Private Sub groupckb_ELEC_Current_PULSED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_ELEC_Current_PULSED.Click
        Me.groupckb_ELEC_Current_AC.Checked = False
        Me.groupckb_ELEC_Current_DCEN.Checked = False
        Me.groupckb_ELEC_Current_DCEP.Checked = False
        If Me.groupckb_ELEC_Current_PULSED.Checked Then
            UpdateModifiedDataTable("ELEC_Current_AC_DCEP_DCEN_PULSED", "PULSED")
        Else
            UpdateModifiedDataTable("ELEC_Current_AC_DCEP_DCEN_PULSED", "")
        End If
    End Sub

    Private Sub groupckb_ELEC_Current_AC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_ELEC_Current_AC.Click
        Me.groupckb_ELEC_Current_PULSED.Checked = False
        Me.groupckb_ELEC_Current_DCEN.Checked = False
        Me.groupckb_ELEC_Current_DCEP.Checked = False
        If Me.groupckb_ELEC_Current_AC.Checked Then
            UpdateModifiedDataTable("ELEC_Current_AC_DCEP_DCEN_PULSED", "AC")
        Else
            UpdateModifiedDataTable("ELEC_Current_AC_DCEP_DCEN_PULSED", "")
        End If
    End Sub
    Private Sub groupckb_ELEC_Current_DCEN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_ELEC_Current_DCEN.Click
        Me.groupckb_ELEC_Current_PULSED.Checked = False
        Me.groupckb_ELEC_Current_AC.Checked = False
        Me.groupckb_ELEC_Current_DCEP.Checked = False
        If Me.groupckb_ELEC_Current_DCEN.Checked Then
            UpdateModifiedDataTable("ELEC_Current_AC_DCEP_DCEN_PULSED", "DCEN")
        Else
            UpdateModifiedDataTable("ELEC_Current_AC_DCEP_DCEN_PULSED", "")
        End If
    End Sub

    Private Sub groupckb_ELEC_Current_DCEP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_ELEC_Current_DCEP.Click
        Me.groupckb_ELEC_Current_PULSED.Checked = False
        Me.groupckb_ELEC_Current_DCEN.Checked = False
        Me.groupckb_ELEC_Current_AC.Checked = False
        If Me.groupckb_ELEC_Current_DCEP.Checked Then
            UpdateModifiedDataTable("ELEC_Current_AC_DCEP_DCEN_PULSED", "DCEP")
        Else
            UpdateModifiedDataTable("ELEC_Current_AC_DCEP_DCEN_PULSED", "")
        End If
    End Sub

    Private Sub groupckb_ELEC_Spray_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_ELEC_Spray.Click
        Me.groupckb_ELEC_ShortCircuiting.Checked = False
        Me.groupckb_ELEC_Globular.Checked = False
        If Me.groupckb_ELEC_Spray.Checked Then
            UpdateModifiedDataTable("ELEC_Mode_ShortCircuiting_Globular_Spray", "Spray")
        Else
            UpdateModifiedDataTable("ELEC_Mode_ShortCircuiting_Globular_Spray", "")
        End If
    End Sub

    Private Sub groupckb_ELEC_Globular_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_ELEC_Globular.Click
        Me.groupckb_ELEC_ShortCircuiting.Checked = False
        Me.groupckb_ELEC_Spray.Checked = False
        If Me.groupckb_ELEC_Globular.Checked Then
            UpdateModifiedDataTable("ELEC_Mode_ShortCircuiting_Globular_Spray", "Globular")
        Else
            UpdateModifiedDataTable("ELEC_Mode_ShortCircuiting_Globular_Spray", "")
        End If
    End Sub

    Private Sub groupckb_ELEC_ShortCircuiting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_ELEC_ShortCircuiting.Click
        Me.groupckb_ELEC_Spray.Checked = False
        Me.groupckb_ELEC_Globular.Checked = False
        If Me.groupckb_ELEC_ShortCircuiting.Checked Then
            UpdateModifiedDataTable("ELEC_Mode_ShortCircuiting_Globular_Spray", "ShortCircuiting")
        Else
            UpdateModifiedDataTable("ELEC_Mode_ShortCircuiting_Globular_Spray", "")
        End If
    End Sub

    Private Sub groupckb_WPS_Prequalified_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_WPS_Prequalified.Click
        Me.groupckb_WPS_QlfdByTesting.Checked = False
        If Me.groupckb_WPS_Prequalified.Checked Then
            UpdateModifiedDataTable("WPS_Prequalified", "Prequalified")
        Else
            UpdateModifiedDataTable("WPS_Prequalified", "")
        End If
    End Sub

    Private Sub groupckb_WPS_QlfdByTesting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_WPS_QlfdByTesting.Click
        Me.groupckb_WPS_Prequalified.Checked = False
        If Me.groupckb_WPS_QlfdByTesting.Checked Then
            UpdateModifiedDataTable("WPS_Prequalified", "QlfdByTesting")
        Else
            UpdateModifiedDataTable("WPS_Prequalified", "")
        End If
    End Sub

    Private Sub groupckb_JDU_BackingYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_JDU_BackingYes.Click
        Me.groupckb_JDU_BackingNo.Checked = False
        If Me.groupckb_JDU_BackingYes.Checked Then
            UpdateModifiedDataTable("JDU_Backing_YesNo", "Yes")
        Else
            UpdateModifiedDataTable("JDU_Backing_YesNo", "")
        End If
    End Sub

    Private Sub groupckb_JDU_BackingNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_JDU_BackingNo.Click
        Me.groupckb_JDU_BackingYes.Checked = False
        If Me.groupckb_JDU_BackingNo.Checked Then
            UpdateModifiedDataTable("JDU_Backing_YesNo", "No")
        Else
            UpdateModifiedDataTable("JDU_Backing_YesNo", "")
        End If
    End Sub

    Private Sub groupckb_JDU_BackGougingYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_JDU_BackGougingYesNO.Click
        Me.groupckb_JDU_BackGougingNo.Checked = False
        If Me.groupckb_JDU_BackGougingYesNO.Checked Then
            UpdateModifiedDataTable("JDU_BackGouging_YesNO", "Yes")
        Else
            UpdateModifiedDataTable("JDU_BackGouging_YesNO", "")
        End If
    End Sub

    Private Sub groupckb_JDU_BackGougingNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_JDU_BackGougingNo.Click
        Me.groupckb_JDU_BackGougingYesNO.Checked = False
        If Me.groupckb_JDU_BackingNo.Checked Then
            UpdateModifiedDataTable("JDU_BackGouging_YesNO", "No")
        Else
            UpdateModifiedDataTable("JDU_BackGouging_YesNO", "")
        End If
    End Sub
    Private Sub groupckb_POS_WeldProgressionUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_POS_WeldProgressionUp.Click
        Me.groupckb_POS_WeldProgressionDown.Checked = False
        If Me.groupckb_POS_WeldProgressionUp.Checked Then
            UpdateModifiedDataTable("POS_WeldProgressionUpDown", "Up")
        Else
            UpdateModifiedDataTable("POS_WeldProgressionUpDown", "")
        End If
    End Sub

    Private Sub groupckb_POS_WeldProgressionDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupckb_POS_WeldProgressionDown.Click
        Me.groupckb_POS_WeldProgressionUp.Checked = False
        If Me.groupckb_POS_WeldProgressionDown.Checked Then
            UpdateModifiedDataTable("POS_WeldProgressionUpDown", "Down")
        Else
            UpdateModifiedDataTable("POS_WeldProgressionUpDown", "")
        End If
    End Sub

    Private Sub AddWPSRecord()
        If Me.tbx_WPS_No.Text <= "" Then
            MessageBox.Show("Record can not be added: No entry for WPS No.")
            Return
        End If
        Dim qry As String = " SELECT WPS_No From WPS_fields WHERE WPS_No = '" + Me.tbx_WPS_No.Text + "'"
        'Dim dt As DataTable = Utilities.ExecuteRemoteQuery(qry, "")

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        If dt.Rows.Count > 0 Then
            MessageBox.Show("WPS No. already exist: record can not be added.")
            Return
        End If
        Dim qryVars = "TS,"
        For Each clmn As DataColumn In orgDt.Columns
            If clmn.Caption <> "ID" And clmn.Caption <> "TS" Then
                qryVars = qryVars + clmn.Caption + ","
            End If
        Next
        qryVars = qryVars.Remove(qryVars.Length - 1, 1)
        Dim qryVals As String = "'" + DateTime.Now + "',"
        For Each clmn As DataColumn In mdfdDT.Columns
            If clmn.Caption <> "ID" And clmn.Caption <> "TS" Then
                qryVals = qryVals + "'" + mdfdDT.Rows(0)(clmn.Caption) + "',"
            End If
        Next
        qryVals = qryVals.Remove(qryVals.Length - 1, 1)
        'qry = "USE [" + runtime.selectedProject + _
        '        "] INSERT INTO WPS_fields ( " + qryVars + ") VALUES (" + qryVals + ")" + _
        '        "; SELECT CAST(scope_identity() AS int);"

        'WPSProcID = Utilities.ExecuteRemoteNonQueryScalar(qry, "")
        Dim muid As String = idUtils.GetNextMUID("project", "WPS_fields")
        qry = " INSERT INTO WPS_fields ( '" + muid + "'," + qryVars + ") VALUES ('" + muid + "'," + qryVals + ")"

        Dim sqlPrj1 As DataUtils = New DataUtils("project")

        Dim dt_param As DataTable = sqlPrj1.paramDT

        sqlPrj1.OpenConnection()
        sqlPrj1.ExecuteNonQuery(qry, dt_param)
        sqlPrj1.CloseConnection()

    End Sub

    Private Sub UpdateWPSRecord()
        Dim qryVars = "SET TS = '" + DateTime.Now + "',"
        For Each clmn As DataColumn In orgDt.Columns
            If clmn.Caption <> "ID" And clmn.Caption <> "TS" Then
                qryVars = qryVars + clmn.Caption + " = '" + mdfdDT.Rows(0)(clmn.Caption) + "',"
            End If
        Next

        qryVars = qryVars.Remove(qryVars.Length - 1, 1)

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()

        Dim qry As String = " UPDATE WPS_fields " + qryVars + " WHERE ID = " + WPSProcID.ToString

        Dim dt_param As DataTable = sqlPrjUtils.paramDT

        sqlPrjUtils.ExecuteNonQuery(qry, dt_param)
        sqlPrjUtils.CloseConnection()
        MessageBox.Show("Record has been updated")
    End Sub
    Private Function CheckFormModified()
        CopyPanelControlsToDataTable(Me.Panel1)
        CopyPanelControlsToDataTable(Me.Panel2)
        CopyPanelControlsToDataTable(Me.Panel3)
        Dim modified As Boolean = False
        For Each clmn As DataColumn In orgDt.Columns
            If Not mdfdDT.Rows(0)(clmn.Caption).ToString = orgDt.Rows(0)(clmn.Caption).ToString Then
                modified = True
            End If
        Next
        Return modified
    End Function
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If CheckFormModified() Then
            If WPSProcID = 0 Then
                AddWPSRecord()
            Else
                UpdateWPSRecord()
            End If
            RefreshFormControls()
        Else
            MessageBox.Show("No record is modified, database is not updated")
        End If
    End Sub

    Private Sub WeldWPSProcFormView_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not CheckFormModified() Then Return
        Dim rslt As System.Windows.Forms.DialogResult = MessageBox.Show("Form has been modified; would you like to save?", "FormUpdate", MessageBoxButtons.YesNo)
        If rslt = Windows.Forms.DialogResult.Yes Then
            If WPSProcID = 0 Then
                AddWPSRecord()
            Else
                UpdateWPSRecord()
            End If
        End If
    End Sub
    'Private Sub PrintToPDF()
    '    'Dim pDialog As SaveFileDialog = New SaveFileDialog()
    '    'If pDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

    '    '    Dim pkgUtil As PackageUtils = New PackageUtils()
    '    '    Me.lblPrintProgress.Text = "Printing: " + pkgUtil.GetPackageName(_PkgID)
    '    '    pkgUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
    '    '            ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked)
    '    '    Dim dest As String = pDialog.FileName
    '    '    If InStr(dest, ".") Then
    '    '        'dest = dest.Insert(InStr(pDialog.FileName, ".") - 1, "_" + Utilities.GetOwner(OwnerID).Rows(0)(0).ToString)
    '    '    Else
    '    '        'dest = dest.Insert(dest.Length, "_" + Utilities.GetOwner(OwnerID).Rows(0)(0).ToString + ".pdf")
    '    '        dest = dest.Insert(dest.Length, ".pdf")
    '    '    End If
    '    '    pkgUtil.Print2PDF(dest, _PkgID, getOwnerID)
    '    '    Do
    '    '        Thread.Sleep(1)
    '    '    Loop Until pkgUtil.DonePrinting
    '    '    Me.lblPrintProgress.Text = "Done"

    '    'End If

    '    Dim pDialog As SaveFileDialog = New SaveFileDialog()
    '    If pDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        Dim sysUtil As SystemPrintUtils = New SystemPrintUtils(SysID)
    '        Me.lblPrintProgress.Text = "Printing: " + SysID
    '        'If sysUtil.CoversheetPresent = False Then
    '        '    MessageBox.Show("No Cover sheet found. ")
    '        '    Me.Dispose()
    '        'End If
    '        sysUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
    '                ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked)
    '        Dim dest As String = pDialog.FileName
    '        If InStr(dest, ".") Then
    '            dest = dest.Insert(InStr(pDialog.FileName, ".") - 1, "_" + Utilities.GetOwner(OwnerID).Rows(0)(0).ToString)
    '        Else
    '            dest = dest.Insert(dest.Length, "_" + Utilities.GetOwner(OwnerID).Rows(0)(0).ToString + ".pdf")
    '        End If

    '        sysUtil.Print2PDF(dest, OwnerID)
    '        Me.lblPrintProgress.Text = "Done"
    '    End If
    'End Sub
    'Private Sub PrintSystem()
    '    'Dim pkgUtil As PackageUtils = New PackageUtils()
    '    'Me.lblPrintProgress.Text = "Printing: " + pkgUtil.GetPackageName(_PkgID)
    '    'pkgUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
    '    '        ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked)
    '    'pkgUtil.PrintPackage(_PkgID, getOwnerID)
    '    'Do
    '    '    Thread.Sleep(1)
    '    'Loop Until pkgUtil.DonePrinting
    '    'Me.lblPrintProgress.Text = "Done"

    '    Dim sysUtil As SystemPrintUtils = New SystemPrintUtils(SysID)
    '    Me.lblPrintProgress.Text = "Printing: " + sysUtil.GetSystemName(SysID)
    '    sysUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
    '            ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked)
    '    sysUtil.PrintSystem(OwnerID)
    '    Do
    '        Thread.Sleep(1)
    '    Loop Until sysUtil.DonePrinting
    '    Me.lblPrintProgress.Text = "Done"

    'End Sub

    'Private Sub PrintPreviewPackages()
    '    'Dim pkgUtil As PackageUtils = New PackageUtils()
    '    'Me.lblPrintProgress.Text = "Printing: " + pkgUtil.GetPackageName(_PkgID)
    '    'pkgUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
    '    '        ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked)
    '    'pkgUtil.PrintPreviewPackage(_PkgID, getOwnerID)
    '    'Do
    '    '    Thread.Sleep(1)
    '    'Loop Until pkgUtil.DonePrinting
    '    'Me.lblPrintProgress.Text = "Done"

    '    Dim sysUtil As SystemPrintUtils = New SystemPrintUtils(SysID)
    '    '        Me.lblPrintProgress.Text = "Printing: " + sysUtil.GetPackageName(_PkgID)
    '    sysUtil.SetPrintOptions(ckbSummary.Checked, ckbDiscripancy.Checked, _
    '            ckbForms.Checked, ckbDocuments.Checked, ckbPunchlist.Checked, ckb_11x17.Checked)
    '    sysUtil.PrintPreviewSystem(OwnerID)
    '    Do
    '        Thread.Sleep(1)
    '    Loop Until sysUtil.DonePrinting
    '    Me.lblPrintProgress.Text = "Done"

    'End Sub

    'Private Sub PrintToPrinter()
    '    Dim printDialog As PrintDialog = New PrintDialog()

    '    '        printDialog.Document = Me.printDoc
    '    If printDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        PrintSystem()
    '    End If
    'End Sub
    Private Sub printDoc_BeginPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        pgCtr = 0
        'PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize = pgInfo(0).ppSize
        If pgInfo(pgCtr).Landscape Then
            PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = True
        Else
            PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = False
        End If
    End Sub


    Private Sub printDoc_EndPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        _DonePrinting = True
    End Sub


    Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        If pgInfo(pgCtr).PrintHdr Then
            PrintUtils.PrintPageHeader(e, pgInfo(pgCtr).Heading, pgInfo(pgCtr).SubHeading)
        End If
        If Not pgInfo(pgCtr).pgBody Is Nothing Then
            PrintUtils.PrintPageBody(e, pgInfo(pgCtr))
        End If
        If pgInfo(pgCtr).PrintFooter Then
            PrintUtils.PrintPageFooter(e, pgInfo(pgCtr).PgNum, pgInfo.Length)
        End If
        pgCtr = pgCtr + 1
        If pgCtr < pgInfo.Length Then
            If Not pgInfo(pgCtr).pkSize Is Nothing Then
                e.PageSettings.PaperSize = pgInfo(pgCtr).pkSize
            End If
            If pgInfo(pgCtr).Landscape Then
                e.PageSettings.Landscape = True
            Else
                e.PageSettings.Landscape = False
            End If
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

    End Sub
    Private Sub AddPanelPage(ByVal pnl As System.Windows.Forms.Panel)
        pgCtr = pgCtr + 1
        ReDim Preserve pgInfo(pgCtr)
        Dim sz As Size = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
            PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
        pgInfo(pgCtr).PrintHdr = False
        pgInfo(pgCtr).PrintFooter = False
        pgInfo(pgCtr).Heading = " "
        pgInfo(pgCtr).SubHeading = " "
        pgInfo(pgCtr).PgNum = pgCtr
        pgInfo(pgCtr).pSize = sz    'New Size(pkSize.Width, pkSize.Height)
        pgInfo(pgCtr).PgNum = pgCtr
        pgInfo(pgCtr).pSize = PrintUtils.GetDefaultPageSize()


        Dim bdCtr As Integer = -1
        Dim Image As Image = pnl.BackgroundImage.Clone
        If Not Image Is Nothing Then
            For i As Integer = 0 To PrintDoc.PrinterSettings.PaperSizes.Count - 1
                Dim pSize As PaperSize = PrintDoc.PrinterSettings.PaperSizes.Item(i)
                Dim pKind As System.Drawing.Printing.PaperKind = PrintDoc.PrinterSettings.PaperSizes.Item(i).RawKind
                If pKind = PaperKind.Letter Then
                    sz = New Size(pSize.Height, pSize.Width)
                    Exit For
                End If
            Next
            bdCtr = bdCtr + 1
            ReDim Preserve pgInfo(pgCtr).pgBody(bdCtr)
            Dim fn As String = PrintUtils.GetNextImageFileName()
            Image.Save(fn)
            pgInfo(pgCtr).pgBody(bdCtr).contentType = PrintUtils.pgContentType.image
            pgInfo(pgCtr).pgBody(bdCtr).obj = fn
            pgInfo(pgCtr).pgBody(bdCtr).loc = New Point(0, 0)
            pgInfo(pgCtr).pgBody(bdCtr).sz = sz 'Image.Size 'pkSize
            'OldAddPgInfo(pgCtr, True, False, False, "", "", pp11x17)
            Image.Dispose()
        End If


        'Dim RecordTop = 200
        'Dim RecordLeft = 70
        Dim ControlTop = 0  'DiscrepancyObject.Top
        Dim ControlLeft = 0
        Dim mPts As Point = New Point(ControlLeft, ControlTop)
        For Each ctrl As Control In pnl.Controls
            Dim prefix As String = Split(ctrl.Name, "_")(0)
            Dim cName As String = Strings.Right(ctrl.Name, Strings.Len(ctrl.Name) - Strings.Len(prefix) - 1)
            Select Case prefix
                Case "tbx"
                    Dim X As Single = mPts.X + ctrl.Location.X
                    'pgInfo(pgCtr).pgBody(bdCtr) = PrintUtils.MakeTextObject(ctrl.Text, New Point(X, Y))
                    Dim tbx As TextBox = CType(ctrl, System.Windows.Forms.TextBox)
                    'Dim str As String = ""
                    Dim lCtr As Integer = 0
                    For Each ln As String In tbx.Lines
                        Dim measure As Size = TextRenderer.MeasureText(ln, tbx.Font)
                        Dim Y As Single = mPts.Y + ctrl.Location.Y + lCtr * measure.Height
                        bdCtr = bdCtr + 1
                        ReDim Preserve pgInfo(pgCtr).pgBody(bdCtr)
                        pgInfo(pgCtr).pgBody(bdCtr) = PrintUtils.MakeTextObject(ln, New Point(X, Y))
                        lCtr = lCtr + 1
                    Next

                Case "groupckb"
                    'PopulateGroupCheckbox(clmn.Caption, orgDt.Rows(0)(clmn.Caption).ToString)
                Case "mtbx"
                Case "lbl"
                Case "dtp"
            End Select
        Next

    End Sub


    Private Sub MakePrintImages()
        pgCtr = -1
        If Directory.Exists(imgdir) Then
            Directory.Delete(imgdir, True)
        End If
        Directory.CreateDirectory(imgdir)
        If Not PrintDoc Is Nothing Then
            PrintDoc.Dispose()
        End If
        PrintDoc = New PrintDocument()
        _StartingTop = TopMargin
        _PageSize = New Size(PrintDoc.DefaultPageSettings.PaperSize.Width, PrintDoc.DefaultPageSettings.PaperSize.Height)



        AddPanelPage(Me.Panel1)
        AddPanelPage(Me.Panel2)
        AddPanelPage(Me.Panel3)

    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        _DonePrinting = False
        Cursor.Current = Cursors.WaitCursor
        MakePrintImages()
        PrintDoc.DocumentName = "Print Packages"
        Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()

        AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
        AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage

        Cursor.Current = Cursors.Default
        printDialog.Document = Me.PrintDoc
        printDialog.ShowDialog()
        _DonePrinting = True
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        _DonePrinting = False
        Cursor.Current = Cursors.WaitCursor

        MakePrintImages()
        PrintDoc.DocumentName = "Print Packages"
        AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
        AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage
        PrintDoc.Print()
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub PrintToPDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToPDFToolStripMenuItem.Click
        Dim pDialog As SaveFileDialog = New SaveFileDialog()
        If pDialog.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        Dim dest As String = pDialog.FileName
        If InStr(dest, ".") Then
            'dest = dest.Insert(InStr(pDialog.FileName, ".") - 1, "_" + Utilities.GetOwner(OwnerID).Rows(0)(0).ToString)
        Else
            'dest = dest.Insert(dest.Length, "_" + Utilities.GetOwner(OwnerID).Rows(0)(0).ToString + ".pdf")
            dest = dest.Insert(dest.Length, ".pdf")
        End If
        Cursor.Current = Cursors.WaitCursor
        MakePrintImages()
        image_pdf.PrintPDFPages(pgInfo, dest)
        Cursor.Current = Cursors.Default
        _DonePrinting = True
    End Sub
End Class