Imports System.Drawing.Imaging
Imports System.Drawing.Printing
'Imports System.Collections
Imports System.IO
Imports System.Data.SqlClient
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraVerticalGrid
'Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.Utils
Public Class WeldParametersCtrl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Private defaultWeld As EditDaqumentUtil.WeldPoint '= New EditDaqumentUtil.WeldPoint
    Private selectedInfo As String = ""

    Private Sub SetDefaultValue(ByVal dr As DataRow)
        Dim s As String = ""

        If Not dr Is Nothing Then
            Dim items As Object() = dr.ItemArray

            Select Case selectedInfo
                Case "AdvancedTesting"
                    Me.defaultWeld.AdvancedTesting = dr("AdvancedTesting").ToString
                Case "Area"
                    Me.defaultWeld.Area = dr("Area").ToString
                Case "TagNo"
                    Me.defaultWeld.TagNo = dr("TagNo").ToString
                Case "System"
                    Me.defaultWeld.System = dr("System").ToString
                Case "TestPkgNo"
                    Me.defaultWeld.TestPkgNo = dr("TestPkgNo").ToString
                Case "SpoolTo"
                    Me.defaultWeld.SpoolTo = dr("SpoolTo").ToString
                    Me.defaultWeld.Area = dr("Area").ToString
                Case "SpoolFrom"
                    Me.defaultWeld.SpoolFrom = dr("SpoolFrom").ToString
                    Me.defaultWeld.Area = dr("Area").ToString
                Case "PipeSize"
                    Me.defaultWeld.PipeSize = dr("PipeSize").ToString
                    Me.defaultWeld.WeldInches = dr("WeldInches").ToString
                Case "ConstCode"
                    Me.defaultWeld.ConstCode = dr("ConstCode").ToString
                Case "WeldInches"
                    Me.defaultWeld.WeldInches = dr("WeldInches").ToString
                    Me.defaultWeld.PipeSize = dr("PipeSize").ToString
                Case "ForemanName"
                    Me.defaultWeld.ForemanName = dr("ForemanName").ToString
                Case "SVCSPEC"
                    Me.defaultWeld.SVCSPEC = dr("SVCSPEC").ToString
                    Me.defaultWeld.WPS = dr("WPS").ToString
                    Me.defaultWeld.NDEPcntReq = dr("NDEPcntReq").ToString
                Case "WPS"
                    Me.defaultWeld.WPS = dr("WPS").ToString
                    Me.defaultWeld.SVCSPEC = dr("SVCSPEC").ToString
                    Me.defaultWeld.NDEPcntReq = dr("NDEPcntReq").ToString
                Case "NDEPcntReq"
                    Me.defaultWeld.NDEPcntReq = dr("NDEPcntReq").ToString
                    Me.defaultWeld.WPS = dr("WPS").ToString
                    '    Me.defaultWeld.SVCSPEC = dr("SVCSPEC").ToString
                Case "Material"
                    Me.defaultWeld.Material = dr("Material").ToString
                Case "WallThk"
                    Me.defaultWeld.WallThk = dr("WallThk").ToString
                Case "WeldType"
                    Me.defaultWeld.WeldType = dr("WeldType").ToString
                Case "WeldStn"
                    Me.defaultWeld.WeldStn = dr("WeldStn").ToString
                Case "NDEType"
                    Me.defaultWeld.NDEType = dr("NDEType").ToString
                Case "TestResult"
                    Me.defaultWeld.TestResult = dr("TestResult").ToString
                Case "VisInspName"
                    Me.defaultWeld.VisInspName = dr("VisInspName").ToString
                Case "PWHT"
                    Me.defaultWeld.PWHT = dr("PWHT").ToString
                Case "BHN"
                    Me.defaultWeld.BHN = dr("BHN").ToString
                Case "Comments"
                    Me.defaultWeld.Comments = dr("Comments").ToString
                Case "DWGNO"
                    Me.defaultWeld.Comments = dr("DWGNO").ToString
                Case "DrawingID"
                    Me.defaultWeld.DrawingID = dr("DrawingID").ToString
                Case "ID"
                    Me.defaultWeld.ID = dr("ID").ToString
                Case Else
            End Select


        End If
    End Sub
    Private Sub ShowParameterTable(ByVal info As String)
        Dim qry As String = ""
        Select Case info
            Case "Disc"
            Case "AdvancedTesting"
            Case "Area"
                qry = " SELECT DISTINCT Area FROM tblSpoolList "
            Case "TagNo"
                qry = " SELECT TagNo, System, Area FROM tblSpoolList "
            Case "System"
                qry = " SELECT DISTINCT System FROM tblSpoolList "
            Case "TestPkgNo"
                qry = " SELECT PackageNumber As TestPkgNo, SystemNumber, Description FROM package "
            Case "EnteredBy"
            Case "DateEntered"
            Case "SpoolTo"
                qry = " SELECT TagNo As SpoolTo, System, Area FROM tblSpoolList "
            Case "SpoolFrom"
                qry = " SELECT TagNo As SpoolFrom, System, Area FROM tblSpoolList "
            Case "PipeSize"
                qry = " SELECT PipeSize, InchesOfWeld, Diameter FROM tblWeldInchesEQLookup "
            Case "ConstCode"
                qry = " SELECT DISTINCT ConstCode FROM tblWeldTracking "
            Case "WeldInches"
                qry = " SELECT InchesOfWeld As WeldInches, PipeSize, Diameter FROM tblWeldInchesEQLookup "
            Case "ForemanName"
                qry = " SELECT TSGroup, ForemanName FROM tblForemanName "
            Case "SVCSPEC"
                qry = " SELECT ClassID AS SVCSPEC, WPS, NDEPcntReq FROM tblWeldWPSLookup "
            Case "WPS"
                qry = " SELECT WPS, ClassID, NDEPcntReq FROM tblWeldWPSLookup "
            Case "NDEPcntReq"
                qry = " SELECT WPS, ClassID, NDEPcntReq FROM tblWeldWPSLookup "
            Case "Material"
                qry = " SELECT DISTINCT Material FROM tblWeldTracking "
            Case "WallThk"
                qry = " SELECT DISTINCT WallThk FROM tblWeldTracking "
            Case "WeldType"
                qry = " SELECT DISTINCT WeldType FROM tblWeldTracking "
            Case "WeldStn"
                qry = " SELECT TagNo As WeldStn,Name FROM tblWeldersList "
            Case "NDEType"
                qry = " SELECT NDEType FROM tblWeldTracking "
            Case "DateTested"
            Case "AdvancedTesting"
            Case "TestResult"
            Case "VisInspDate"
            Case "VisInspName"
                qry = " SELECT DISTINCT VisInspName FROM tblWeldTracking "
            Case "PMIDate"
            Case "PMIResult"
            Case "RejInches"
            Case "PWHT"
                qry = " SELECT DISTINCT PWHT FROM tblWeldTracking "
            Case "BHN"
            Case "Comments"
                qry = " SELECT DISTINCT BHN FROM tblWeldTracking "
            Case "Revision"
            Case Else

        End Select
        If qry > "" Then
            'ShowSelectedInfoTable(daqartDLL.Utilities.ExecuteQuery(qry, "project"))
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()
            ShowSelectedInfoTable(dt)
        End If
    End Sub
    Private Sub ShowSelectedInfoTable(ByVal infoTbl As DataTable)
        '        selectedInfo = ""
        If Not GridControl1 Is Nothing Then

            GridControl1.Dispose()
            GridControl1 = Nothing
        End If
        'If Not infoTbl.DataSet Is Nothing Then
        '    infoTbl.DataSet.Dispose()
        'End If
        Try
            If Not infoTbl.DataSet Is Nothing Then
                infoTbl.DataSet.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show("No entry in the Data Table")
            Return
        End Try

        GridControl1 = New DevExpress.XtraGrid.GridControl
        GridControl1.Location = New System.Drawing.Point(0, 30)
        'GridControl1.Dock = DockStyle.Fill
        GridControl1.Name = "GridControl1"
        'GridControl1.Visible = False
        GridControl1.Dock = DockStyle.Top
        '        GridControl1.Bounds = New Rectangle(40, 100, 800, 200)
        'GridControl1.Size = New System.Drawing.Size(300, 200)

        '            Dim gView As GridView = GridControl1.MainView

        '        VGridControl1.Rows(0).Height = 50
        'AddHandler GridControl1.Click, AddressOf GridControl1_Click
        Dim ds As DataSet = New DataSet
        ds.Tables.Add(infoTbl.Copy)
        GridControl1.DataSource = ds.Tables(0)
        'Dim View As ColumnView = GridControl1.MainView
        'gView.AddNewRow()
        'View.ClearSelection()
        '            gView.GetVisibleColumn(0).Visible = False
        '           gView.Columns.View.ClearSelection()
        '        gView.Columns(0).Visible = False
        'Dim RIMemoEdit As RepositoryItemMemoEdit = CType(GridControl1.RepositoryItems.Add("MemoEdit"), _
        '   RepositoryItemMemoEdit)
        'RIMemoEdit.WordWrap = True
        'GridControl1.RepositoryItems.Add(RIMemoEdit)
        'InfoTblForm.Bounds = New Rectangle(40, 120, 800, 240) 'GridControl1.Bounds
        'InfoTblForm.Bounds = GridControl1.ClientRectangle
        'InfoTblForm.Size = GridControl1.PreferredSize
        Dim gView As GridView = GridControl1.MainView
        'gView.BestFitColumns()
        GridControl1.BringToFront()
        gView.OptionsView.ColumnAutoWidth = False
        AddHandler GridControl1.Click, AddressOf GridControl1_Click
        'Dim RowEsign As RepositoryItemImageEdit = CType(GridControl1.RepositoryItems.Add("ImageEdit"), _
        '   RepositoryItemImageEdit)
    End Sub
    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim View As ColumnView = GridControl1.MainView
        Dim ParentView As GridView = View.ParentView

        '        PackageViewer.PackageViewerManager.OpenPackage(View.GetFocusedRowCellValue("PackageID"), View.GetFocusedRowCellValue("PackageNumber"))

        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = View.CalcHitInfo((TryCast(sender, Control)).PointToClient(Control.MousePosition))
        Try
            If hi.RowHandle >= 0 Then
                SetDefaultValue(View.GetDataRow(hi.RowHandle))
            ElseIf View.FocusedRowHandle >= 0 Then
                SetDefaultValue(View.GetDataRow(View.FocusedRowHandle))
            Else
                '                SetDefaultValue(Nothing)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        'For Each vec As EditDaqumentUtil.VectorMap In Vectors
        '    If Not vec.ObjectDeleted And vec.itmSelected = True Then
        '        For Each dr As DataRow In tblWeldTracking.Rows
        '            If dr("TagNo") = vec.text Then
        '                For Each clmn As DataColumn In tblWeldTracking.Columns
        '                    Try
        '                        If clmn.ColumnName <> "TagNo" Then
        '                            dr(clmn) = GetDefaultParameter(clmn.ColumnName.ToString)
        '                        End If
        '                    Catch ex As Exception

        '                    End Try
        '                    'dr(clmn) = GetDefaultParameter(clmn.ColumnName.ToString)
        '                Next
        '            End If
        '        Next
        '    End If
        'Next
        'WeldPointParameters()
    End Sub
    Public Sub New(ByVal _defaultWeld As EditDaqumentUtil.WeldPoint)
        '= New EditDaqumentUtil.WeldPoint

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        defaultWeld = _defaultWeld
    End Sub
End Class
