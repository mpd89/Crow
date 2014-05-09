Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
'Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL
Imports SystemManager
Imports SautinSoft


Public Class PackageUtils
    Private pgInfo() As PrintUtils.InfoSetting
    Private PrintDoc As PrintDocument
    Public CoversheetPresent As Boolean = True
    Private imgdir As String = runtime.AbsolutePath + "sites\Forms\images\imgList"
    Private turnoverDir As String = runtime.AbsolutePath + "sites\turnover\system"
    Private _ImgList As New List(Of Image)
    Private logoImg As Image
    Private pgCtr As Integer = -1
    Private statusGrid As TableLayoutPanel = New TableLayoutPanel
    Private f_body As Font = New Font("Times New Roman", 10)
    Private f_title As Font = New Font("Times New Roman", 20, FontStyle.Bold)
    Private f_main As Font = New Font("Times New Roman", 36, FontStyle.Bold)
    Private f_heading1 As Font = New Font("Times New Roman", 16, FontStyle.Bold)
    Private f_heading2 As Font = New Font("Times New Roman", 12, FontStyle.Bold)
    Private LeftMargin As Integer = 70
    Private _PageSize As Size
    Private _CoversheetPresent As Boolean
    Private _pixFormat As System.Drawing.Imaging.PixelFormat
    Private _BaseImage As System.Drawing.Image
    Private TopMargin As Integer = 300
    Private _StartingTop As Integer = TopMargin
    Private _StartingLeft As Integer = 50

    Private _ckbSummaryChecked As Boolean = True
    Private _ckbDiscripancyChecked As Boolean = False
    Private _ckbFormsChecked As Boolean = False
    Private _ckbDocumentsChecked As Boolean = False
    Private _ckbPunchListChecked As Boolean = False
    Private _ckb_11x17 As Boolean = False
    Private _PrintPkgHiliteLayer As Boolean = False
    Private _PrintPkgMarkupLayer As Boolean = False
    Private _DonePrinting As Boolean = False
    
    Friend WithEvents ppc As New PreviewPrintController
    Private ListofImages() As String

    Dim SystemMUID As String
    Dim PackageList As DataTable
    Dim HoldImage As Image
    Dim HoldImageRedline As Boolean = False
    Dim SystemPath As String


    Public Sub SetPrintOptions(ByVal pSummary As Boolean, ByVal pDiscripancy As Boolean, _
                                    ByVal pForms As Boolean, ByVal pDoc As Boolean, _
                                    ByVal pPunchlist As Boolean, ByVal ckb_11x17 As Boolean, _
                                    ByVal PrintPkgHiliteLayer As Boolean, ByVal PrintPkgMarkupLayer As Boolean)
        _ckbSummaryChecked = pSummary
        _ckbDiscripancyChecked = pDiscripancy
        _ckbFormsChecked = pForms
        _ckbDocumentsChecked = pDoc
        _ckbPunchListChecked = pPunchlist
        _ckb_11x17 = ckb_11x17
        _PrintPkgHiliteLayer = PrintPkgHiliteLayer
        _PrintPkgMarkupLayer = PrintPkgMarkupLayer

    End Sub


    Public Shared Function TestPackageDocument(ByVal PackageID As String, ByVal DocumentID As String)
        Dim query As String = "SELECT * FROM package_documents WHERE DocumentMUID = '" & DocumentID & "' AND PackageMUID= '" & PackageID & "'"
        'Dim dt As New DataTable
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        Try
            'dt = Utilities.ExecuteQuery(query, "project")
            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            sqlPrjUtils.CloseConnection()

            If dt.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
            Return False
        End Try

    End Function

    Public ReadOnly Property GetPackageName(ByVal PkgID As String) As String
        Get
            Dim qry As String = "SELECT PackageNumber,SystemMUID,Description, " + _
        "GroupMUID,OwnerMUID,DisciplineMUID FROM package WHERE MUID = '" + PkgID.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()

            Return dt.Rows(0)("PackageNumber")
        End Get
    End Property


    Public ReadOnly Property GetPkgSystemName(ByVal PkgID As String) As String
        Get
            Dim qry As String = "SELECT PackageNumber,SystemMUID,Description, " + _
        "GroupMUID,OwnerMUID,DisciplineMUID FROM package WHERE MUID = '" + PkgID.ToString + "'"
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            Dim SysID = dt.Rows(0)("SystemMUID")
            'Return SystemDataManager.GetFullSystemDescription(SysID)
            Return SystemDataManager.TranslateSystemID(SysID)
        End Get
    End Property


    Public ReadOnly Property DonePrinting()
        Get
            Return _DonePrinting
        End Get
    End Property

    'Public ReadOnly Property GetPkgDocumentIDList(ByVal PkgID As String) As List(Of Integer)
    '    Get
    '        Dim AllDocIDs As New List(Of Integer)
    '        Dim WHEREStr As String = ""
    '        If PkgID > 0 Then
    '            WHEREStr = "WHERE PackageID = " + PkgID.ToString
    '        End If
    '        Dim qry = " Select DocumentID FROM package_documents " + WHEREStr
    '        'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
    '        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

    '        sqlPrjUtils.OpenConnection()
    '        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '        sqlPrjUtils.CloseConnection()

    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            Dim myID As Integer = dt.Rows(i)(0)
    '            Dim latestID = Utilities.GetDocumentLatestRevID(myID)
    '            AllDocIDs.Add(latestID)
    '        Next
    '        Return AllDocIDs
    '    End Get
    'End Property
    'Public ReadOnly Property GetPkgDocumentStatusList(ByVal PkgID As Integer) As DataTable
    '    Get
    '        Dim AllDocIDs As List(Of Integer) = GetPkgDocumentIDList(PkgID)

    '        Dim dtt As DataTable = New DataTable
    '        Dim clmHeading() As String = {"Document_Name", "Rev", "Date", "Sheet", "Image"}
    '        Dim clmCaption() As String = {"Document Name", "Rev", "Date", "Sheet", "Image"}

    '        For i As Integer = 0 To clmHeading.Length - 1
    '            Dim dc As DataColumn = New DataColumn
    '            dc.ColumnName = clmHeading(i)
    '            dc.Caption = clmCaption(i)
    '            dc.DataType = System.Type.GetType("System.String")
    '            dtt.Columns.Add(dc)
    '        Next
    '        For Each id As Integer In AllDocIDs
    '            Dim qry = " Select EngCode, Revision,DateLoaded, Sheet, Sheets  FROM documents WHERE DocumentID = " + id.ToString
    '            Dim dt As DataTable = Utilities.ExecuteQuery(qry, "Daqument")
    '            Dim dr As DataRow = dtt.NewRow
    '            dr("Document_Name") = dt.Rows(0)(0).ToString
    '            dr("Rev") = dt.Rows(0)(1).ToString
    '            dr("Date") = dt.Rows(0)(2).ToString
    '            dr("Sheet") = dt.Rows(0)(3).ToString + " of " + dt.Rows(0)(4).ToString
    '            Dim docImgPresent As String = "No"
    '            Dim docImg As Daqument.EditDaqumentUtil = New Daqument.EditDaqumentUtil(id)
    '            If docImg.DocumentImageAvailable() Then
    '                docImgPresent = "Yes"
    '            End If
    '            dr("Image") = docImgPresent
    '        Next


    '        Return dtt
    '    End Get
    'End Property


    Public ReadOnly Property GetTagIDList(ByVal PkgID As String) As List(Of String)
        Get
            Dim AllTagIDs As New List(Of String)
            Dim WHEREStr As String = ""
            If PkgID > "" Then
                WHEREStr = "WHERE PackageMUID = '" + PkgID.ToString + "'"
            End If
            Dim qry = " Select MUID FROM tags " + WHEREStr
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()

            For i As Integer = 0 To dt.Rows.Count - 1
                AllTagIDs.Add(dt.Rows(i)(0))
            Next
            Return AllTagIDs
        End Get
    End Property


    Public ReadOnly Property GetNMEFormIDList(ByVal TagID As String, ByVal OwnerID As String) As List(Of String)
        Get
            Dim AllFormIDs As New List(Of String)
            Dim TypeID As String = GetTagTypeID(TagID)
            Dim WHEREStr As String = " WHERE (requirements.TypeMUID = '" + TypeID.ToString + "'" + _
                ") AND (forms.ID = requirements.FormID) AND (forms.MultiElement = 0)"
            If OwnerID > "" Then
                WHEREStr = " WHERE (requirements.TypeMUID = '" + _
                TypeID.ToString + "') AND (OwnerMUID = '" + OwnerID.ToString + "') AND (" + _
                " forms.MUID = requirements.FormMUID) AND (forms.MultiElement = 0)"
            End If

            'Dim AllFormIDs As New List(Of String)
            'Dim TypeID As String = GetTagTypeID(TagID)
            'Dim WHEREStr As String = " WHERE (MUID = '" + TypeID.ToString + "'" + _
            '    ") AND (forms.MUID = requirements.FormMUID) AND (forms.MultiElement = 0)"
            'If OwnerID > "" Then
            '    WHEREStr = " WHERE (MUID = '" + _
            '    TypeID.ToString + "') AND (OwnerMUID = '" + OwnerID.ToString + "') AND (" + _
            '    " forms.MUID = requirements.FormMUID) AND (forms.MultiElement = 0)"
            'End If

            Dim qry = " Select requirements.FormMUID FROM requirements,forms " + WHEREStr
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()

            For i As Integer = 0 To dt.Rows.Count - 1
                AllFormIDs.Add(dt.Rows(i)(0))
            Next
            Return AllFormIDs
        End Get
    End Property


    Private Function GetTagRecord(ByVal PkgID As String) As DataTable
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim query As String = "Select * From tags WHERE PackageMUID='" & PkgID & "'"
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()
        Return dt
    End Function


    Public Function GetPkgMEFormIDList(ByVal PkgID As String, ByVal OwnerID As String) As List(Of String)
        Dim AllFormIDs As New List(Of String)
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim query As String = ""
        Dim EqIDList As String = "("
        Dim i As Integer
        For i = 0 To Utilities.CountTags(PkgID) - 1
            If i = Utilities.CountTags(PkgID) - 1 Then
                EqIDList += "'" & GetTagRecord(PkgID).Rows(i)("TypeMUID") & "'"
            Else
                EqIDList += "'" & GetTagRecord(PkgID).Rows(i)("TypeMUID") & "',"
            End If
        Next
        EqIDList += ")"

        query = "SELECT Distinct forms.MUID As formsMUID,forms.Name, requirements.MUID As reqMUID " & _
                " FROM requirements, forms " & _
                " WHERE requirements.FormMUID = forms.MUID " & _
                " AND requirements.OwnerMUID = '" + OwnerID + "' " & _
                " AND requirements.TypeMUID IN " & EqIDList & _
                " AND MultiElement='1'"

        Try
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            For i = 0 To dt.Rows.Count - 1
                Dim FormAdded As Boolean = False
                For u As Integer = 0 To AllFormIDs.Count - 1
                    If AllFormIDs(u) = dt.Rows(i)(0) Then
                        FormAdded = True
                    End If
                Next
                If Not FormAdded Then
                    AllFormIDs.Add(dt.Rows(i)(0))
                End If
            Next
        Catch ex As Exception
            Dim message As String = ex.Message
            Throw ex
        End Try
        Return AllFormIDs
    End Function

    'Public ReadOnly Property GetPkgMEFormIDList(ByVal PkgID As String, ByVal OwnerID As String) As List(Of String)
    '    Get


    '        Dim AllFormIDs As New List(Of String)

    '        Dim TypeID As String = GetTagTypeID(TagID)
    '        Dim WHEREStr As String = " WHERE (requirements.TypeMUID = '" + TypeID.ToString + "'" + _
    '            ") AND (forms.MUID = requirements.FormMUID) AND (forms.MultiElement = 1)"
    '        If OwnerID > "" Then
    '            WHEREStr = " WHERE (requirements.TypeMUID = '" + _
    '            TypeID.ToString + "') AND (OwnerMUID = '" + OwnerID.ToString + "') AND (" + _
    '            " forms.MUID = requirements.FormMUID) AND (forms.MultiElement = 1)"
    '        End If
    '        Dim qry = " Select requirements.FormMUID FROM requirements,forms " + WHEREStr

    '        'Dim AllFormIDs As New List(Of String)
    '        'Dim TypeID As String = GetTagTypeID(TagID)
    '        'Dim WHEREStr As String = " WHERE (forms.MUID = '" + TypeID.ToString + "'" + _
    '        '    ") AND (forms.MUID = requirements.FormMUID) AND (forms.MultiElement = 1)"
    '        'If OwnerID > "" Then
    '        '    WHEREStr = " WHERE (MUID = '" + _
    '        '    TypeID.ToString + "') AND (OwnerMUID = '" + OwnerID.ToString + "') AND (" + _
    '        '    " forms.MUID = requirements.FormMUID) AND (forms.MultiElement = 1)"
    '        'End If
    '        'Dim qry = " Select requirements.FormMUID FROM requirements,forms " + WHEREStr

    '        'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
    '        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

    '        sqlPrjUtils.OpenConnection()
    '        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '        sqlPrjUtils.CloseConnection()

    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            AllFormIDs.Add(dt.Rows(i)(0))
    '        Next
    '        Return AllFormIDs
    '    End Get
    'End Property

    Public ReadOnly Property GetDocumentImage(ByVal DocumentID As String) As Image
        Get
            Dim myDoc As Daqument.EditDaqumentUtil = New Daqument.EditDaqumentUtil(DocumentID)
            If myDoc.DocumentImageAvailable() Then
                Return myDoc.OriginalDocumentImage()
            End If
            Return Nothing
        End Get
    End Property


    Public ReadOnly Property GetTagTypeID(ByVal TagID As String) As String
        Get
            Dim qry = " Select TypeMUID FROM tags WHERE MUID = '" + TagID.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()

            If dt.Rows.Count > 0 Then
                Return (dt.Rows(0)(0))
            End If
            Return ""
        End Get
    End Property


    Public ReadOnly Property GetCompanyName(ByVal PkgID As String) As String
        Get
            Dim query = " SELECT company.CompanyName From company INNER JOIN userInfo " + _
                        " WHERE UserMUID = '" + runtime.UserMUID + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(query, "server")
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            sqlSrvUtils.OpenConnection()
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(query)
            sqlSrvUtils.CloseConnection()

            Return (dt.Rows(0)(0))
        End Get
    End Property


    Public ReadOnly Property GetOwnerID(ByVal PkgID As String) As String
        Get
            Dim qry = " Select OwnerMUID FROM Package WHERE Package.MUID = '" + PkgID.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()

            If dt.Rows.Count > 0 Then
                Return (dt.Rows(0)(0))
            End If
            Return ""
        End Get
    End Property


    Public ReadOnly Property GetPkgDescription(ByVal PkgID As String) As String
        Get
            Dim qry = " Select Description FROM Package WHERE MUID = '" + PkgID.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()
            If dt.Rows.Count > 0 Then
                Return (dt.Rows(0)(0).ToString)
            End If
            Return ""

        End Get
    End Property


    Public ReadOnly Property GetUserName(ByVal UserID As String) As String
        Get
            Dim qry = " Select FirstName, MI, LastName FROM userInfo WHERE UserMUID = '" + UserID.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "server")

            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            sqlSrvUtils.OpenConnection()
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(qry)
            sqlSrvUtils.CloseConnection()

            Dim str = " "
            If dt.Rows.Count > 0 Then
                str = dt.Rows(0)(0) + " " + dt.Rows(0)(1) + " " + dt.Rows(0)(2)
            End If
            Return str
        End Get
    End Property


    Public ReadOnly Property GetGroupID(ByVal PkgID As String) As String
        Get
            Dim qry = " Select GroupMUID FROM Package WHERE MUID = '" + PkgID.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()
            If dt.Rows.Count > 0 Then
                Return (dt.Rows(0)(0))
            End If
            Return ""

        End Get
    End Property


    Public ReadOnly Property GetDisciplineID(ByVal PkgID As String) As String
        Get
            Dim qry = " Select DisciplineMUID FROM Package WHERE MUID = '" + PkgID.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()
            If dt.Rows.Count > 0 Then
                Return (dt.Rows(0)(0))
            End If
            Return 0
        End Get
    End Property


    Public ReadOnly Property GetOwnerName(ByVal OwnerID As String) As String
        Get
            Dim qry = " Select Name FROM Owner WHERE MUID = '" + OwnerID + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            sqlSrvUtils.OpenConnection()
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(qry)
            sqlSrvUtils.CloseConnection()
            If dt.Rows.Count > 0 Then
                Return (dt.Rows(0)("Name"))
            End If
            Return "All"
        End Get
    End Property


    Public ReadOnly Property GetGroupName(ByVal GroupID As String) As String
        Get
            Dim qry = " Select Name FROM Groups WHERE MUID = '" + GroupID.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "server")
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            sqlSrvUtils.OpenConnection()
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(qry)
            sqlSrvUtils.CloseConnection()

            If dt.Rows.Count > 0 Then
                Return (dt.Rows(0)("Name").ToString)
            End If
            Return ""
        End Get
    End Property


    Public ReadOnly Property GetDisciplineName(ByVal DisciplineID As String) As String
        Get
            Dim qry = " Select Name FROM Discipline WHERE MUID = '" + DisciplineID.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "server")
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            sqlSrvUtils.OpenConnection()
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(qry)
            sqlSrvUtils.CloseConnection()

            If dt.Rows.Count > 0 Then
                Return (dt.Rows(0)("Name").ToString)
            End If
            Return ""
        End Get
    End Property


    Public ReadOnly Property GetPkgDocumentIDList(ByVal PkgID As String) As List(Of String)
        Get
            Dim AllDocIDs As New List(Of String)
            Dim WHEREStr As String = ""
            If PkgID > "" Then
                WHEREStr = "WHERE PackageMUID ='" + PkgID.ToString + "'"
            End If
            Dim qry = "Select DocumentMUID FROM package_documents " + WHEREStr
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim id As String = Utilities.GetDocumentLatestRevID(dt.Rows(i)("DocumentMUID"))
                    AllDocIDs.Add(id) ' dt.Rows(i)("DocumentMUID"))
                Next
            End If
            Return AllDocIDs
        End Get
    End Property


    Private Sub AddCoverPage(ByVal PkgID As String, ByVal OwnerID As String)
        Dim linelist() As PrintUtils.pgTextLine
        Dim linectr As Integer = 0 : ReDim Preserve linelist(linectr)
        'linelist(linectr) = PrintUtils.MakeTextLineObject("Package: " + GetPackageName(PkgID), PrintUtils.Allign.Left, f_title)
        'linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        'linelist(linectr) = PrintUtils.MakeTextLineObject("Owner: " + GetOwnerName(OwnerID), PrintUtils.Allign.Center, f_title)
        'linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        'linelist(linectr) = PrintUtils.MakeTextLineObject(" ", PrintUtils.Allign.Left, f_title)
        'linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        'linelist(linectr) = PrintUtils.MakeTextLineObject(" ", PrintUtils.Allign.Left, f_title)
        'linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        'linelist(linectr) = PrintUtils.MakeTextLineObject(" ", PrintUtils.Allign.Left, f_title)
        'linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject("System: " + GetPkgSystemName(PkgID), PrintUtils.Allign.Center, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject("Package: " + GetPackageName(PkgID), PrintUtils.Allign.Center, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(" ", PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(" ", PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(IIf(_ckbSummaryChecked, "[X] Summary", "[   ] Summary"), PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(IIf(_ckbDiscripancyChecked, "[X] Discrepancy", "[   ] Discrepancy"), PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(IIf(_ckbPunchListChecked, "[X] Punchlist", "[   ] Punchlist"), PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(IIf(_ckbFormsChecked, "[X] Forms", "[   ] Forms"), PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(IIf(_ckbDocumentsChecked, "[X] Document", "[   ] Document"), PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(" ", PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(" ", PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject("Requested By:  " + runtime.UserName, PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject("Date:  " + Now.ToString, PrintUtils.Allign.Left, f_title)

        pgCtr = pgCtr + 1
        ReDim Preserve pgInfo(pgCtr)
        pgInfo(pgCtr) = PrintUtils.MakeTextPage(New Point(70, 300), linelist)
        pgInfo(pgCtr).Landscape = False
        pgInfo(pgCtr).PrintHdr = True
        pgInfo(pgCtr).PrintFooter = False
        pgInfo(pgCtr).Heading = "Package: " + GetPackageName(PkgID)
        pgInfo(pgCtr).SubHeading = "Owner: " + GetOwnerName(OwnerID)
        pgInfo(pgCtr).pSize = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
                       PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
    End Sub


    Private Sub AddPackageStatusSummaryPage(ByVal PkgID As String, ByVal _OwnerID As String)
        Dim AllOwnerIDList As New List(Of String)
        If _OwnerID = "" Then
            Dim qry = " Select MUID FROM owner "
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "server")
            Dim sqlSrvUtils As DataUtils = New DataUtils("server")

            sqlSrvUtils.OpenConnection()
            Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(qry)
            sqlSrvUtils.CloseConnection()

            For i As Integer = 0 To dt.Rows.Count - 1
                AllOwnerIDList.Add(dt.Rows(i)("MUID"))
            Next
        Else
            AllOwnerIDList.Add(_OwnerID)
        End If
        For Each OwnerID As String In AllOwnerIDList
            'Dim RecordTop As Integer = 210


            'Dim tagPnlTableList As List(Of TableLayoutPanel) = GetPkgTagStatusPnlList(PkgID, OwnerID)
            'Dim docPnlTableList As List(Of TableLayoutPanel) = GetPkgDocumentStatusList(OwnerID)
            'Dim tagTbl As DataTable = myTagStatus.TagStatusTable(TagID, PkgID)
            Dim dt As DataTable = GetPkgTagStatusTable(PkgID, OwnerID)
            Dim clmWd() As Integer = {40, 200, 100, 100, 100, 100}
            Dim myPgInfo() As PrintUtils.InfoSetting = PrintUtils.MakeTableListPages(dt, clmWd)
            If myPgInfo Is Nothing Then Return
            For i As Integer = 0 To myPgInfo.Length - 1
                pgCtr = pgCtr + 1
                ReDim Preserve pgInfo(pgCtr)
                pgInfo(pgCtr) = myPgInfo(i)
                pgInfo(pgCtr).Landscape = False
                pgInfo(pgCtr).PrintHdr = True
                pgInfo(pgCtr).PrintFooter = True
                pgInfo(pgCtr).Heading = "Package: " + GetPackageName(PkgID)
                pgInfo(pgCtr).SubHeading = "Owner: " + GetOwnerName(OwnerID)
                pgInfo(pgCtr).PgNum = pgCtr
                pgInfo(pgCtr).pSize = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
                   PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
            Next
        Next
    End Sub


    Private Sub AddDiscrepancyPages(ByVal _PkgID As String)

        Dim qry = "select Discrepancy.MUID from discrepancy,package WHERE " + _
    " package.MUID = '" + _PkgID.ToString + "'" + _
    " AND discrepancy.PackageMUID=package.MUID"
        'Dim IDList As DataTable = Utilities.ExecuteQuery(qry, "project")
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim IDList As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        Dim mypgInfo() As PrintUtils.InfoSetting = DiscrepancyManager.DiscrepancyPrintUtils.MakeShortDiscrepancyPrintPages(IDList)
        If mypgInfo Is Nothing Then Return
        Dim mypgCtr As Integer = 0
        For Each myPage As PrintUtils.InfoSetting In mypgInfo
            If mypgInfo.Length > 0 Then
                pgCtr = pgCtr + 1
                ReDim Preserve pgInfo(pgCtr)
                pgInfo(pgCtr) = myPage
                mypgCtr = mypgCtr + 1
                pgInfo(pgCtr).Landscape = False
                pgInfo(pgCtr).PrintHdr = True
                pgInfo(pgCtr).PrintFooter = True
                pgInfo(pgCtr).Heading = "Package: " + GetPackageName(_PkgID)
                pgInfo(pgCtr).SubHeading = "Discrepancies "
                pgInfo(pgCtr).PgNum = pgCtr
            End If
        Next

    End Sub


    Private Sub AddPkgDocumentSummaryPage(ByVal _PkgID As String)
        Dim AllDocIDs As List(Of String) = GetPkgDocumentIDList(_PkgID)
        Dim dtt As DataTable = New DataTable
        'Dim clmHeading() As String = {"Document_Name", "Rev", "Date", "Sheet", "Image"}
        'Dim clmCaption() As String = {"Document Name", "Rev", "Date", "Sheet", "Image"}
        Dim clmHeading() As String = {"Document_Name", "Rev", "Sheet", "Image", "RedLine"}
        Dim clmCaption() As String = {"   Document Name", "   Rev", "  Sheet", "  Image", " RedLine"}
        Dim clmWd() As Integer = {40, 300, 100, 100, 100, 100, 100}

        For i As Integer = 0 To clmHeading.Length - 1
            Dim dc As DataColumn = New DataColumn
            dc.ColumnName = clmHeading(i)
            dc.Caption = clmCaption(i)
            dc.DataType = System.Type.GetType("System.String")
            dtt.Columns.Add(dc)
        Next
        'Dim colorCode() As Color
        Dim Ctr As Integer = 0
        For Each id As String In AllDocIDs
            'Dim qry = " Select EngCode, Revision,DateLoaded, Sheet, Sheets  FROM documents WHERE DocumentID = " + id.ToString
            Dim qry = " Select EngCode, Revision, Sheet, Sheets  FROM documents WHERE MUID = '" + id.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "Daqument")
            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

            sqlDocUtils.OpenConnection()
            Dim dt As DataTable = sqlDocUtils.ExecuteQuery(qry)
            sqlDocUtils.CloseConnection()


            Dim dr As DataRow = dtt.NewRow
            'dr("Document_Name") = dt.Rows(0)(0).ToString
            If dt.Rows.Count > 0 Then
                dr("Document_Name") = dt.Rows(0)(0).ToString
                dr("Rev") = " " + dt.Rows(0)(1).ToString
                'dr("Date") = dt.Rows(0)(2).ToString
                dr("Sheet") = " " + dt.Rows(0)(2).ToString + " of " + dt.Rows(0)(3).ToString
                Dim docImgPresent As String = " No"
                Dim docImg As Daqument.EditDaqumentUtil = New Daqument.EditDaqumentUtil(id)
                If docImg.DocumentImageAvailable() Then
                    docImgPresent = " Yes"
                End If
                dr("Image") = docImgPresent

                dtt.Rows.Add(dr)
                If Utilities.TestPkgDocContainsRedLineItems(id, _PkgID) Then
                    dr("RedLine") = "Yes"
                Else
                    dr("RedLine") = "No"
                End If
            End If
            'ReDim Preserve colorCode(Ctr)
            'If Utilities.TestPkgDocContainsRedLineItems(id, _PkgID) Then
            '    colorCode(Ctr) = Color.Red
            'Else
            '    colorCode(Ctr) = Color.White
            'End If
            Ctr = Ctr + 1
        Next

        'docPnlTableList As List(Of TableLayoutPanel) = GetPkgDocumentStatusList(_PkgID)
        'Dim tagTbl As DataTable = myTagStatus.TagStatusTable(TagID, PkgID)
        'Dim myPgInfo() As PrintUtils.InfoSetting = PrintUtils.MakeTableListPages(dtt, clmWd, colorCode)
        Dim myPgInfo() As PrintUtils.InfoSetting = PrintUtils.MakeTableListPages(dtt)
        If myPgInfo Is Nothing Then Return
        For i As Integer = 0 To myPgInfo.Length - 1
            pgCtr = pgCtr + 1
            ReDim Preserve pgInfo(pgCtr)
            pgInfo(pgCtr) = myPgInfo(i)
            pgInfo(pgCtr).Landscape = False
            pgInfo(pgCtr).PrintHdr = True
            pgInfo(pgCtr).PrintFooter = True
            pgInfo(pgCtr).Heading = "Package: " + GetPackageName(_PkgID)
            pgInfo(pgCtr).SubHeading = " " 'Owner: " + Utilities.GetOwner(OwnerID).Rows(0)(2)
            pgInfo(pgCtr).PgNum = pgCtr
            pgInfo(pgCtr).pSize = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
               PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
        Next
    End Sub

    ''
    ''Private Sub AddPunchlistPages(ByVal _PkgID As String)
    ''Dim qry = "SELECT MUID, TagNumber FROM tags WHERE PackageMUID = '" + _PkgID.ToString + "'"
    ' 'Dim tagdt As DataTable = Utilities.ExecuteQuery(qry, "project")
    ''  Dim sqlPrjUtils As DataUtils = New DataUtils("project")

    ''      sqlPrjUtils.OpenConnection()
    ''  Dim tagdt As DataTable = sqlPrjUtils.ExecuteQuery(qry)

    ''     For ii As Integer = 0 To tagdt.Rows.Count - 1
    ''         qry = "SELECT MUID FROM punchlist WHERE TagMUID = '" + tagdt.Rows(ii)("MUID").ToString + "'"
    ''  'Dim punchlistdt As DataTable = Utilities.ExecuteQuery(qry, "project")
    ''  Dim punchlistdt As DataTable = sqlPrjUtils.ExecuteQuery(qry)

    '' Dim mypgInfo() As PrintUtils.InfoSetting = PunchlistManager.PunchlistDataManager.MakeShortPunchlistPrintPages(punchlistdt)
    '' Dim mypgCtr As Integer = 0
    ''        If Not mypgInfo Is Nothing Then
    ''         For Each myPage As PrintUtils.InfoSetting In mypgInfo
    ''              If mypgInfo.Length > 0 Then
    ''                  pgCtr = pgCtr + 1
    ''                  ReDim Preserve pgInfo(pgCtr)
    ''                  pgInfo(pgCtr) = myPage
    ''                  mypgCtr = mypgCtr + 1
    ''                  pgInfo(pgCtr).Landscape = False
    ''                  pgInfo(pgCtr).PrintHdr = True
    ''                   pgInfo(pgCtr).PrintFooter = True
    ''                   pgInfo(pgCtr).Heading = "Package: " + GetPackageName(_PkgID)
    ''''                   pgInfo(pgCtr).SubHeading = "Punchlist" + "-- Tag: " + tagdt.Rows(ii)(1).ToString
    ''                   pgInfo(pgCtr).PgNum = pgCtr
    ''               End If
    ''           Next
    '''       End If
    ''    Next
    ''   sqlPrjUtils.CloseConnection()

    ''End Sub


    Private Sub SetPaperSize(ByVal wd As Integer, ByVal ht As Integer)
        If wd > ht Then
            pgInfo(pgCtr).Landscape = True
        Else
            pgInfo(pgCtr).Landscape = False
        End If
        Dim foundPprSize As Boolean = False

        For i As Integer = 0 To PrintDoc.PrinterSettings.PaperSizes.Count - 1
            Dim ppSize As System.Drawing.Printing.PaperSize = PrintDoc.PrinterSettings.PaperSizes.Item(i)
            If ppSize.Height = ht And ppSize.Width = wd Then
                Dim pKind As System.Drawing.Printing.PaperKind = PrintDoc.PrinterSettings.PaperSizes.Item(i).Kind
                pgInfo(pgCtr).pSize = New Size(ppSize.Height, ppSize.Width)
                pgInfo(pgCtr).pkSize = ppSize
                foundPprSize = True
                Exit For
            End If
        Next
        If Not foundPprSize Then

        End If
    End Sub


    Private Sub AddPkgDocumentImagePage(ByVal DocID, ByVal _PkgID)
        Dim Image As Image = GetPkgDocumentImage(DocID, _PkgID)
        If Image Is Nothing Then Return

        pgCtr = pgCtr + 1
        ReDim Preserve pgInfo(pgCtr)

        Dim qry As String = "SELECT document_type.Disable11x17 From Document_type, documents WHERE " + _
                " document_type.MUID = documents.DocumentTypeMUID AND documents.MUID = '" + DocID.ToString + "'"
        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
        'Dim Disable11x17 As String = Utilities.ExecuteQuery(qry, "Daqument").Rows(0)(0).ToString

        sqlDocUtils.OpenConnection()
        Dim Disable11x17 As String = sqlDocUtils.ExecuteQuery(qry).Rows(0)(0).ToString
        sqlDocUtils.CloseConnection()


        Dim pp11x17 As Boolean = False
        If _ckb_11x17 And Disable11x17 <> "1" Then
            pp11x17 = True
        End If

        Dim sz As Size = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
            PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
        pgInfo(pgCtr).Landscape = False

        If Image.Size.Width > Image.Size.Height Then
            pgInfo(pgCtr).Landscape = True
        End If

        If pp11x17 Then
            'For i As Integer = 0 To PrintDoc.PrinterSettings.PaperSizes.Count - 1
            '    Dim ppSize As System.Drawing.Printing.PaperSize = PrintDoc.PrinterSettings.PaperSizes.Item(i)
            '    Dim pKind As System.Drawing.Printing.PaperKind = PrintDoc.PrinterSettings.PaperSizes.Item(i).Kind
            '    If pKind = PaperKind.Tabloid Then
            '        sz = New Size(ppSize.Height, ppSize.Width)
            '        pgInfo(pgCtr).pSize = sz
            '        pgInfo(pgCtr).pkSize = ppSize
            '        Exit For
            '    End If
            'Next
            If pgInfo(pgCtr).Landscape = True Then
                pgInfo(pgCtr).pprKind = PrintUtils.GetPaperKind(Image.Size.Width, Image.Size.Height)
            Else
                pgInfo(pgCtr).pprKind = PrintUtils.GetPaperKind(Image.Size.Width, Image.Size.Height)
            End If
        Else
            'For i As Integer = 0 To PrintDoc.PrinterSettings.PaperSizes.Count - 1
            'Dim pSize As PaperSize = PrintDoc.PrinterSettings.PaperSizes.Item(i)
            'Dim pKind As System.Drawing.Printing.PaperKind = PrintDoc.PrinterSettings.PaperSizes.Item(i).RawKind
            'If pKind = PaperKind.Letter Then
            '    'sz = New Size(pSize.Width, pSize.Height)
            '    If Image.Size.Width > Image.Size.Height Then
            '        sz = New Size(pSize.Height, pSize.Width)
            '    Else
            '        sz = New Size(pSize.Width, pSize.Height)
            '    End If
            '    pgInfo(pgCtr).pSize = sz
            '    pgInfo(pgCtr).pkSize = pSize
            '    Exit For
            'End If
            'Next
            'pgInfo(pgCtr).pprKind = PrintUtils.myDefaultPaperKind
            If pgInfo(pgCtr).Landscape = True Then
                pgInfo(pgCtr).pprKind = PrintUtils.GetPaperKind(Image.Size.Width, Image.Size.Height)
            Else
                pgInfo(pgCtr).pprKind = PrintUtils.GetPaperKind(Image.Size.Width, Image.Size.Height)
            End If
        End If

        pgInfo(pgCtr).PrintHdr = False
        pgInfo(pgCtr).PrintFooter = False
        pgInfo(pgCtr).Heading = " "
        pgInfo(pgCtr).SubHeading = " "
        pgInfo(pgCtr).PgNum = pgCtr

        pgInfo(pgCtr).pSize = New Size(Image.Size.Width, Image.Size.Height)
        Dim j As Integer = 0
        ReDim Preserve pgInfo(pgCtr).pgBody(j)
        Dim fn As String = PrintUtils.GetNextImageFileName()
        Image.Save(fn)
        pgInfo(pgCtr).pgBody(j).contentType = PrintUtils.pgContentType.docImage
        pgInfo(pgCtr).pgBody(j).obj = fn
        pgInfo(pgCtr).pgBody(j).loc = New Point(0, 0)
        pgInfo(pgCtr).pgBody(j).sz = sz 'Image.Size 'pkSize
        Image.Dispose()
    End Sub


    Public Function GetMEFormTagIDList(ByVal FormID As String, ByVal OwnerID As String, ByVal PkgID As String) As List(Of String)
        Dim AllTagIDs As New List(Of String)
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim query As String = ""

        query = "SELECT Distinct TypeMUID " & _
                "FROM requirements " & _
                "WHERE requirements.FormMUID = '" + FormID + "' " + _
                " AND OwnerMUID = '" + OwnerID + "'"

        'build a "HAVING" clause with all types



        Try
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
            For i As Integer = 0 To dt.Rows.Count - 1
                query = "SELECT MUID From tags WHERE TypeMUID = '" + dt.Rows(i)(0) + "'" + " AND PackageMUID = '" + PkgID + "'"
                Dim dtTag As DataTable = sqlPrjUtils.ExecuteQuery(query)
                If dtTag.Rows.Count > 0 Then
                    For u As Integer = 0 To dtTag.Rows.Count - 1
                        AllTagIDs.Add(dtTag.Rows(u)(0))
                    Next
                End If
            Next
        Catch ex As Exception
            Dim message As String = ex.Message
            Throw ex
        End Try
        Return AllTagIDs
    End Function


    Private Sub AddFormImagePages(ByVal _PkgID As String, ByVal _OwnerID As String)
        Try
            For Each FormID As String In GetPkgMEFormIDList(_PkgID, _OwnerID)
                'get a tag from a package, it doesn't matter which one
                'For Each TagID As String In GetMEFormTagIDList(FormID, _OwnerID, _PkgID)
                Dim LeadTag As String = GetMEFormTagIDList(FormID, _OwnerID, _PkgID)(0)
                'For Each TagID As String In GetMEFormTagIDList(FormID, _OwnerID, _PkgID)
                Try
                    Dim formImages As FormDesigner.FormUtils = New FormDesigner.FormUtils(FormID, LeadTag, _OwnerID, "View")
                    If Not formImages Is Nothing Then
                        For Each formPgInfo As PrintUtils.InfoSetting In formImages.MakeFormPgInfo(New Size(formImages.FormWidth, formImages.FormHeight))
                            pgCtr = pgCtr + 1
                            'pgInfo(pgCtr) = formPgInfo
                            ReDim Preserve pgInfo(pgCtr)
                            pgInfo(pgCtr) = formPgInfo
                            pgInfo(pgCtr).pprKind = PrintUtils.myDefaultPaperKind
                        Next
                    Else
                        MessageBox.Show("Form images not available; Form Name:" + Utilities.GetFormName(FormID))
                    End If
                Catch ex As Exception
                    MessageBox.Show("Form images not available; Form Name:" + Utilities.GetFormName(FormID))
                End Try
                'Next
            Next

            For Each TagID As String In GetTagIDList(_PkgID)
                For Each FormID As String In GetNMEFormIDList(TagID, _OwnerID)
                    Try
                        Dim formImages As FormDesigner.FormUtils = New FormDesigner.FormUtils(FormID, TagID, _OwnerID, "View")
                        If Not formImages Is Nothing Then
                            'For Each formPgInfo As PrintUtils.InfoSetting In formImages.MakeFormPgInfo(_PageSize)
                            For Each formPgInfo As PrintUtils.InfoSetting In formImages.MakeFormPgInfo(New Size(formImages.FormWidth, formImages.FormHeight))
                                pgCtr = pgCtr + 1
                                ReDim Preserve pgInfo(pgCtr)
                                formPgInfo.pSize = New Size(formImages.FormWidth, formImages.FormHeight)
                                pgInfo(pgCtr) = formPgInfo
                                pgInfo(pgCtr).pprKind = formPgInfo.pprKind

                            Next
                        Else
                            MessageBox.Show("Form images not available; Form Name:" + Utilities.GetFormName(FormID))
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Form images not available; Form Name:" + Utilities.GetFormName(FormID))
                    End Try
                Next
            Next
        Catch ex As Exception
            MessageBox.Show("Form Print Error")
        End Try

    End Sub

    Structure Pages
        Dim Landscape As Boolean
        Dim PrintHdr As Boolean
        Dim PrintFooter As Boolean
        Dim pgInfo As PrintUtils.InfoSetting
    End Structure

    Private Sub MakePkgPrintImages(ByVal _PkgID As String, ByVal _OwnerID As String)
        'pgCtr = -1
        _StartingTop = TopMargin
        _PageSize = New Size(PrintDoc.DefaultPageSettings.PaperSize.Width, PrintDoc.DefaultPageSettings.PaperSize.Height)

        If CustomMods.ModIndex.PackageSummary Then
            Dim CustomSummary As New CustomMods.CustomSummary(_PkgID, _OwnerID)

            For u As Integer = 0 To CustomSummary.CustomPages.Count - 1
                pgCtr = pgCtr + 1
                ReDim Preserve pgInfo(pgCtr)
                pgInfo(pgCtr) = CustomSummary.CustomPages(u).pgInfo
                pgInfo(pgCtr).Landscape = CustomSummary.CustomPages(u).Landscape
                pgInfo(pgCtr).PrintHdr = CustomSummary.CustomPages(u).PrintHdr
                pgInfo(pgCtr).PrintFooter = CustomSummary.CustomPages(u).PrintFooter
                pgInfo(pgCtr).PgNum = pgCtr
                pgInfo(pgCtr).pSize = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
                               PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
                pgInfo(pgCtr).pprKind = PrintUtils.myDefaultPaperKind

            Next
        Else
            AddCoverPage(_PkgID, _OwnerID)
        End If

        If _ckbSummaryChecked Then
            AddPackageStatusSummaryPage(_PkgID, _OwnerID)
        End If

        If _ckbDiscripancyChecked Then
            AddDiscrepancyPages(_PkgID)
        End If

        '  If _ckbPunchListChecked Then
        'AddPunchlistPages(_PkgID)
        '   End If

        If _ckbFormsChecked Then
            Dim AllOwnerIDList As New List(Of String)
            If _OwnerID = "" Then
                Dim qry = " Select MUID FROM owner "
                Dim sqlSrvUtils As DataUtils = New DataUtils("server")
                sqlSrvUtils.OpenConnection()
                Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(qry)
                sqlSrvUtils.CloseConnection()
                For i As Integer = 0 To dt.Rows.Count - 1
                    AllOwnerIDList.Add(dt.Rows(i)("MUID"))
                Next
            Else
                AllOwnerIDList.Add(_OwnerID)
            End If
            For Each OwnerID As String In AllOwnerIDList
                AddFormImagePages(_PkgID, OwnerID)
            Next
        End If

        If _ckbDocumentsChecked Then
            AddPkgDocumentSummaryPage(_PkgID)
            For Each DocID As String In GetPkgDocumentIDList(_PkgID)
                AddPkgDocumentImagePage(DocID, _PkgID)
            Next
        End If

    End Sub


    Private Sub MakeSysPrintImages(ByVal _OwnerMUID As String)
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

        Dim AllPkgIDList As New List(Of String)
        Dim dt As DataTable = PackageList

        For i As Integer = 0 To dt.Rows.Count - 1
            AllPkgIDList.Add(dt.Rows(i)(0))
        Next

        AddCoverPage()

        If _ckbSummaryChecked Then
            AddSystemStatusSummaryPage(_OwnerMUID)
        End If
        If _ckbDiscripancyChecked Then
            For Each PkgID As String In AllPkgIDList
                AddDiscrepancyPages(PkgID)
            Next
        End If
        '    If _ckbPunchListChecked Then
        'For Each PkgID As String In AllPkgIDList
        'AddPunchlistPages(PkgID)
        ' Next
        ' End If

        'Forms
        If _ckbFormsChecked Then
            Dim AllOwnerIDList As New List(Of String)
            If _OwnerMUID = "" Then
                Dim qry = " Select MUID FROM owner "
                Dim dt_Owners As DataTable = runtime.SQLServer.ExecuteQuery(qry)
                For i As Integer = 0 To dt.Rows.Count - 1
                    AllOwnerIDList.Add(dt.Rows(i)("MUID"))
                Next
            Else
                AllOwnerIDList.Add(_OwnerMUID)
            End If
            For Each OwnerID As String In AllOwnerIDList
                For i As Integer = 0 To PackageList.Rows.Count - 1
                    AddFormImagePages(PackageList.Rows(i)("MUID"), OwnerID)
                Next
            Next
        End If

        If _ckbDocumentsChecked Then
            AddSystemDocumentSummaryPage(_OwnerMUID)
            For Each DocID As String In GetSysDocumentIDList(SystemMUID)
                Try
                    AddSystemDocumentImagePage(DocID)
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub


    Private Sub MakeENISysPrintImages(ByVal _OwnerMUID As String)
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

        Dim AllPkgIDList As New List(Of String)
        Dim dt As DataTable = PackageList

        For i As Integer = 0 To dt.Rows.Count - 1
            AllPkgIDList.Add(dt.Rows(i)(0))
        Next


        AddCoverPage()

        If _ckbSummaryChecked Then
            AddSystemStatusSummaryPage(_OwnerMUID)
        End If
        If _ckbDiscripancyChecked Then
            For Each PkgID As String In AllPkgIDList
                AddDiscrepancyPages(PkgID)
            Next
        End If
        '  If _ckbPunchListChecked Then
        'For Each PkgID As String In AllPkgIDList
        'AddPunchlistPages(PkgID)
        '   Next
        '   End If

        'Forms
        If _ckbFormsChecked Then
            Dim AllOwnerIDList As New List(Of String)
            If _OwnerMUID = "" Then
                Dim qry = " Select MUID FROM owner "
                Dim dt_Owners As DataTable = runtime.SQLServer.ExecuteQuery(qry)
                For i As Integer = 0 To dt.Rows.Count - 1
                    AllOwnerIDList.Add(dt.Rows(i)("MUID"))
                Next
            Else
                AllOwnerIDList.Add(_OwnerMUID)
            End If
            For Each OwnerID As String In AllOwnerIDList
                For i As Integer = 0 To PackageList.Rows.Count - 1
                    AddFormImagePages(PackageList.Rows(i)("MUID"), OwnerID)
                Next
            Next
        End If

        'documents
        If _ckbDocumentsChecked Then
            Dim DocumentList As List(Of String) = GetSysDocumentIDList(SystemMUID)
            For Each DocID As String In DocumentList
                Try
                    Dim DocType As String = Utilities.GetDocumentTypeFromDocument(DocID)
                    Dim MatchType As Boolean = False
                    Dim TypePath As String
                    Select Case DocType

                        'Case "yP3y006ajyj0LZHA-2sPzAErb&0011" 'pid
                        '    MatchType = True
                        '    TypePath = " P&ID"

                        Case "yP3y006ajyj0LZHA-2sPzAErb&0017" ' das
                            MatchType = True
                            TypePath = " DATASHEETS"

                        Case "yP3y006ajyj0LZHA-2sPzAErb&0015" 'loops
                            MatchType = True
                            TypePath = " LOOP DRAWINGS"

                    End Select

                    'flag if redline
                    If MatchType Or Me.HoldImageRedline Then
                        'HoldImage = Me.GetDocumentImage(DocID)

                        Dim tmpimg As Image = Me.GetSysDocumentImage(DocID)
                        tmpimg.Dispose()

                        'get doc name and rev
                        Dim DocQuery As String = "SELECT * FROM documents WHERE MUID = '" + DocID + "'"
                        Dim DocInfo As DataTable = runtime.SQLDaqument.ExecuteQuery(DocQuery)

                        If Not HoldImage Is Nothing And DocInfo.Rows.Count > 0 Then

                            If File.Exists(runtime.AbsolutePath + "\sites\tmp.png") Then
                                File.Delete(runtime.AbsolutePath + "\sites\tmp.png")
                            End If

                            'clear images folder and save
                            Dim DocFilename As String = DocInfo.Rows(0)("EngCode") + " Rev" + Utilities.TranslateRev(DocInfo.Rows(0)("Revision"))

                            Dim path As String = runtime.AbsolutePath + "sites\tmp.png"

                            HoldImage.Save(path)
                            HoldImage.Dispose()

                            'convert to pdf
                            Dim PV As New SautinSoft.PdfVision
                            With PV
                                .Serial = "10007511254"
                                .PageStyle.PageSize.Auto()
                            End With

                            If MatchType Then
                                Dim x As Integer = PV.ConvertFile(runtime.AbsolutePath + "\sites\tmp.png", SystemPath + TypePath + "\" + DocFilename + ".pdf")
                            End If

                            If Me.HoldImageRedline Then
                                Dim y As Integer = PV.ConvertFile(runtime.AbsolutePath + "\sites\tmp.png", SystemPath + "REDLINES\" + DocFilename + ".pdf")
                            End If


                        End If
                    End If

                Catch ex As Exception

                End Try
            Next

            'redlined documents
            Dim RL_DocumentList As New List(Of String)

            For i As Integer = 0 To Me.PackageList.Rows.Count - 1
                Dim RL_query As String = "SELECT * FROM drawing_layers WHERE layerTitle = 'RL-" + Me.PackageList.Rows(i)("PackageNumber") + "'"
                Dim dt_RL As DataTable = runtime.SQLDaqument.ExecuteQuery(RL_query)

                For a As Integer = 0 To dt_RL.Rows.Count - 1
                    Dim AlreadyAdded As Boolean = False

                    For u As Integer = 0 To RL_DocumentList.Count - 1
                        If dt_RL.Rows(a)("DrawingMUID") = RL_DocumentList(u)(0) Then
                            AlreadyAdded = True
                        End If
                    Next

                    If Not AlreadyAdded Then
                        RL_DocumentList.Add(dt_RL.Rows(a)("DrawingMUID"))
                    End If
                Next
            Next

            For Each DocID As String In RL_DocumentList
                Try
                    Dim TypePath As String
                    TypePath = " REDLINES"

                    Dim tmpimg As Image = Me.GetSysDocumentImage(DocID)
                    tmpimg.Dispose()

                    'get doc name and rev
                    Dim DocQuery As String = "SELECT * FROM documents WHERE MUID = '" + DocID + "'"
                    Dim DocInfo As DataTable = runtime.SQLDaqument.ExecuteQuery(DocQuery)

                    If Not HoldImage Is Nothing And DocInfo.Rows.Count > 0 Then
                        If File.Exists(runtime.AbsolutePath + "\sites\tmp.png") Then
                            File.Delete(runtime.AbsolutePath + "\sites\tmp.png")
                        End If

                        'clear images folder and save
                        Dim DocFilename As String = DocInfo.Rows(0)("EngCode") + " Rev" + Utilities.TranslateRev(DocInfo.Rows(0)("Revision"))

                        Dim path As String = runtime.AbsolutePath + "sites\tmp.png"

                        HoldImage.Save(path)
                        HoldImage.Dispose()

                        'convert to pdf
                        Dim PV As New SautinSoft.PdfVision
                        With PV
                            .Serial = "10007511254"
                            .PageStyle.PageSize.Auto()
                        End With

                        Dim x As Integer = PV.ConvertFile(runtime.AbsolutePath + "\sites\tmp.png", SystemPath + TypePath + "\" + DocFilename + ".pdf")
                    End If

                Catch ex As Exception

                End Try
            Next
        End If


    End Sub



    Public Sub Print2PDF(ByVal dest As String, ByVal PkgID As String, ByVal OwnerID As String)
        If Directory.Exists(imgdir) Then
            Directory.Delete(imgdir, True)
        End If
        Directory.CreateDirectory(imgdir)
        If Not PrintDoc Is Nothing Then
            PrintDoc.Dispose()
        End If
        PrintDoc = New PrintDocument()
        _DonePrinting = False
        pgCtr = -1
        Cursor.Current = Cursors.WaitCursor
        MakePkgPrintImages(PkgID, OwnerID)
        image_pdf.PrintPDFPages(pgInfo, dest)

        Cursor.Current = Cursors.Default
        _DonePrinting = True
    End Sub


    Public Sub Print2PDFAllPackages(ByVal dest As String, ByVal AllPkgID As List(Of String), ByVal OwnerID As String)
        If Directory.Exists(imgdir) Then
            Directory.Delete(imgdir, True)
        End If
        Directory.CreateDirectory(imgdir)
        If Not PrintDoc Is Nothing Then
            PrintDoc.Dispose()
        End If
        PrintDoc = New PrintDocument()
        _DonePrinting = False
        Cursor.Current = Cursors.WaitCursor
        pgCtr = -1
        For Each PkgID As String In AllPkgID
            MakePkgPrintImages(PkgID, OwnerID)
        Next
        image_pdf.PrintPDFPages(pgInfo, dest)
        Cursor.Current = Cursors.Default
        _DonePrinting = True
    End Sub


    Public Sub PrintPackage(ByVal PkgID As String, ByVal OwnerID As String)
        If Directory.Exists(imgdir) Then
            Directory.Delete(imgdir, True)
        End If
        Directory.CreateDirectory(imgdir)
        If Not PrintDoc Is Nothing Then
            PrintDoc.Dispose()
        End If
        PrintDoc = New PrintDocument()
        _DonePrinting = False
        pgCtr = -1
        Cursor.Current = Cursors.WaitCursor

        MakePkgPrintImages(PkgID, OwnerID)
        PrintDoc.DocumentName = "Print Packages"
        AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
        AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage
        PrintDoc.Print()
        Cursor.Current = Cursors.Default
    End Sub


    Public Sub PrintAllPackages(ByVal AllPkgID As List(Of String), ByVal OwnerID As String)
        If Directory.Exists(imgdir) Then
            Directory.Delete(imgdir, True)
        End If
        Directory.CreateDirectory(imgdir)
        If Not PrintDoc Is Nothing Then
            PrintDoc.Dispose()
        End If
        PrintDoc = New PrintDocument()
        _DonePrinting = False
        pgCtr = -1
        Cursor.Current = Cursors.WaitCursor
        For Each PkgID As String In AllPkgID
            MakePkgPrintImages(PkgID, OwnerID)
        Next
        PrintDoc.DocumentName = "Print Packages"
        AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
        AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage
        PrintDoc.Print()
        Cursor.Current = Cursors.Default
    End Sub

    Private PDFPrint As Boolean = False


    Public Sub PrintPreviewPackage(ByVal PkgID As String, ByVal OwnerID As String, ByVal PrintMode As String, ByVal _PathToPDF As String)
        PDFPrint = False

        If Directory.Exists(imgdir) Then
            Directory.Delete(imgdir, True)
        End If
        Directory.CreateDirectory(imgdir)
        If Not PrintDoc Is Nothing Then
            PrintDoc.Dispose()
        End If
        PrintDoc = New PrintDocument()
        PrintDoc.PrintController = ppc

        _DonePrinting = False
        pgCtr = -1
        Cursor.Current = Cursors.WaitCursor


        MakePkgPrintImages(PkgID, OwnerID)


        PrintDoc.DocumentName = "Print Packages"
        Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()

        If PrintMode = "pdf" Then
            PDFPrint = True
        End If

        AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
        AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage

        If PrintMode = "print" Then
            PrintDoc.PrintController = New Printing.StandardPrintController
        End If

        PrintDoc.Print()

        If PrintMode = "pdf" Then
            Dim ImageList() As String
            ImageList = New String(pgCtr - 1) {}
            For i As Integer = 0 To pgCtr - 1
                ImageList(i) = runtime.AbsolutePath + "\sites\forms\images\img_" & i.ToString
            Next

            'image_pdf.Multiple2One(_PathToPDF, ImageList)
            Dim PV As New SautinSoft.PdfVision
            With PV
                .Serial = "10007511254"
                .PageStyle.PageSize.Auto()
            End With

            Dim x As Integer = PV.ConvertFolder(runtime.AbsolutePath + "\sites\forms\images\", _PathToPDF + ".pdf")

        End If

        Cursor.Current = Cursors.Default

        If PrintMode = "preview" Then
            PrintDoc.PrintController = New Printing.StandardPrintController
            printDialog.Document = Me.PrintDoc
            printDialog.ShowDialog()
        End If

    End Sub


    Public Sub PrintPreviewSystemPackage(ByVal _SystemMUID As String, ByVal _PackageList As DataTable, ByVal OwnerID As String, ByVal PrintMode As String, ByVal _PathToPDF As String)
        PDFPrint = False

        SystemMUID = _SystemMUID
        Me.PackageList = _PackageList

        If Directory.Exists(imgdir) Then
            Directory.Delete(imgdir, True)
        End If

        Directory.CreateDirectory(imgdir)
        If Not PrintDoc Is Nothing Then
            PrintDoc.Dispose()
        End If

        PrintDoc = New PrintDocument()
        PrintDoc.PrintController = ppc

        _DonePrinting = False
        pgCtr = -1
        Cursor.Current = Cursors.WaitCursor

        If Not runtime.SiteName = "ENI001" Then
            Me.MakeSysPrintImages(OwnerID)
        Else
            SystemPath = _PathToPDF
            SystemPath = Replace(SystemPath, " DOCUMENTS ALL", "")
            Me.MakeENISysPrintImages(OwnerID)
        End If

        PrintDoc.DocumentName = "Print Packages"
        Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()

        If PrintMode = "pdf" Then
            PDFPrint = True
            PrintDoc.PrintController = New Printing.PreviewPrintController
        End If

        AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
        AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage

        If PrintMode = "print" Then
            PrintDoc.PrintController = New Printing.StandardPrintController
        End If

        PrintDoc.Print()

        If PrintMode = "pdf" Then
            Dim ImageList() As String
            ImageList = New String(pgCtr - 1) {}
            For i As Integer = 0 To pgCtr - 1
                ImageList(i) = runtime.AbsolutePath + "\sites\forms\images\img_" & i.ToString
            Next

            'image_pdf.Multiple2One(_PathToPDF, ImageList)
            Dim PV As New SautinSoft.PdfVision
            With PV
                .Serial = "10007511254"
                .PageStyle.PageSize.Auto()
            End With

            Dim x As Integer = PV.ConvertFolder(runtime.AbsolutePath + "\sites\forms\images\", _PathToPDF + ".pdf")

            'Dim y As Integer = PV.ConvertFolder(runtime.AbsolutePath + "\sites\forms\images\", _PathToPDF + "SYSTEM 60A PFP01 DOCUMENTS ALL.pdf")


        End If

        Cursor.Current = Cursors.Default

        If PrintMode = "preview" Then
            PrintDoc.PrintController = New Printing.StandardPrintController
            printDialog.Document = Me.PrintDoc
            printDialog.ShowDialog()
        End If

    End Sub


    Public Sub PrintPreviewAllPackages(ByVal AllPkgID As List(Of String), ByVal OwnerID As String)
        If Directory.Exists(imgdir) Then
            Dim fentries As String() = Directory.GetFiles(imgdir)
            Dim fs As String
            For Each fs In fentries
                File.Delete(fs)
            Next
            Directory.Delete(imgdir, True)
        End If

        Directory.CreateDirectory(imgdir)
        If Not PrintDoc Is Nothing Then
            PrintDoc.Dispose()
        End If
        PrintDoc = New PrintDocument()
        PrintDoc.PrintController = ppc

        _DonePrinting = False
        pgCtr = -1
        Cursor.Current = Cursors.WaitCursor
        Try
            For Each PkgID As String In AllPkgID
                MakePkgPrintImages(PkgID, OwnerID)
            Next
        Catch ex As Exception
            MessageBox.Show("Package Print Error")
        End Try
        PrintDoc.DocumentName = "Print Packages"
        Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()

        AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage
        AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint

        PrintDoc.Print()

        Cursor.Current = Cursors.Default

        PrintDoc.PrintController = New Printing.StandardPrintController
        printDialog.Document = Me.PrintDoc
        printDialog.ShowDialog()

    End Sub


    Public ReadOnly Property GetPkgTagStatusTable(ByVal _PkgID As String, ByVal _OwnerID As String) As DataTable
        Get
            Dim ORDERstr As String = " ORDER BY tags.TagNumber ASC"

            Dim WHEREStr As String = ""
            If _PkgID > "" And _OwnerID > "" Then
                WHEREStr = "WHERE tags.PackageMUID = '" + _PkgID.ToString + "' AND tag_status.OwnerMUID = '" + _OwnerID.ToString + "'"
            ElseIf _PkgID > "" And _OwnerID = "" Then
                WHEREStr = "WHERE tags.PackageMUID = '" + _PkgID.ToString + "'"
            ElseIf _PkgID = "" And _OwnerID > "" Then
                WHEREStr = "WHERE tag_status.OwnerMUID = '" + _OwnerID.ToString + "'"
            End If
            Dim qry = " SELECT  DISTINCT tags.TagNumber As Tag, tag_status.RequiredManHours As ReqManHours, " + _
                            " tag_status.CurrentLevel As Level, tag_status.EarnedManHours As EarnedMhrs, " + _
                            " CASE WHEN tag_status.RequiredManHours = '0' THEN 0 ELSE " + _
                            " Round(tag_status.EarnedManHours / tag_status.RequiredManHours * 100, 2) END AS PctComplete " + _
                            " FROM tags INNER JOIN tag_status ON tags.MUID = tag_status.tagMUID " + WHEREStr + ORDERstr

            '                Dim hdrclmTxt() As String = {"#", "Tag", "Req MHrs", "Level", "Earned Mhrs", "%Complete"}
            'Return qry
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()

            'Return (Utilities.ExecuteQuery(qry, "project"))
            Return dt
        End Get

    End Property


    Private Sub printDoc_BeginPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        pgCtr = 0
        'PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize = pgInfo(0).ppSize
        If pgInfo(pgCtr).Landscape Then
            PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = True
        Else
            PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = False
        End If

        Dim S() As String = Directory.GetFiles(runtime.AbsolutePath + "\sites\forms\images\")
        For Each DeleteFile As String In S
            File.Delete(DeleteFile)
        Next

    End Sub


    Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        e.Graphics.FillRectangle(Brushes.White, New Rectangle(0, 0, pgInfo(pgCtr).pSize.Width, pgInfo(pgCtr).pSize.Height))

        pgInfo(pgCtr).PgNum = pgCtr

        PrintUtils.PrintFullPage(e, pgInfo(pgCtr).Heading, pgInfo(pgCtr).SubHeading, pgInfo(pgCtr), pgInfo(pgCtr).PgNum, pgInfo.Length)


        'If pgInfo(pgCtr).PrintHdr Then
        '    PrintUtils.PrintPageHeader(e, pgInfo(pgCtr).Heading, pgInfo(pgCtr).SubHeading)
        'End If

        'If Not pgInfo(pgCtr).pgBody Is Nothing Then
        '    PrintUtils.PrintPageBody(e, pgInfo(pgCtr))
        'End If

        'If pgInfo(pgCtr).PrintFooter Then
        '    PrintUtils.PrintPageFooter(e, pgInfo(pgCtr).PgNum, pgInfo.Length)
        'End If

        pgCtr = pgCtr + 1
        If pgCtr < pgInfo.Length Then

            If Not pgInfo(pgCtr).pkSize Is Nothing Then
                e.PageSettings.PaperSize = pgInfo(pgCtr).pkSize
            End If

            If pgInfo(pgCtr).Landscape Then
                e.PageSettings.PaperSize = New PaperSize("Custom", pgInfo(pgCtr).pSize.Height, pgInfo(pgCtr).pSize.Width)
                e.PageSettings.Landscape = True
            Else
                e.PageSettings.PaperSize = New PaperSize("Custom", pgInfo(pgCtr).pSize.Width, pgInfo(pgCtr).pSize.Height)
                e.PageSettings.Landscape = False
            End If
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

        'Dim g As Graphics = imag
        ''Dim tmp_Image As Image
        'Dim bmp As New Bitmap(pgInfo(pgCtr).pSize.Width, pgInfo(pgCtr).pSize.Height)
        ''g.DrawImage(.DrawImage(bmp, 0, 0)
        'bmp.Save("c:\test.png", System.Drawing.Imaging.ImageFormat.Png)


    End Sub


    Private Sub printDoc_EndPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        'If PDFPrint Then
        '    Dim ppi() As Printing.PreviewPageInfo = ppc.GetPreviewPageInfo()
        '    ListofImages = New String(pgCtr - 1) {}
        '    Dim S() As String = Directory.GetFiles(runtime.AbsolutePath + "\sites\forms\images\")
        '    For Each DeleteFile As String In S
        '        File.Delete(DeleteFile)
        '    Next

        '    For x As Integer = 0 To ppi.Length - 1
        '        'resize image from preview window
        '        Dim bm As New Bitmap(ppi(x).Image.Size.Width, ppi(x).Image.Height)
        '        Dim width As Integer = ppi(x).Image.Size.Width / 4
        '        Dim height As Integer = ppi(x).Image.Height / 4
        '        Dim thumb As New Bitmap(width, height)
        '        Dim g As Graphics = Graphics.FromImage(thumb)

        '        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        '        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        '        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
        '        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

        '        g.DrawImage(ppi(x).Image, 0, 0, width, height)
        '        g.Dispose()

        '        thumb.Save(runtime.AbsolutePath + "\sites\forms\images\img_" & x.ToString, System.Drawing.Imaging.ImageFormat.Png)
        '        bm.Dispose()
        '        thumb.Dispose()

        '        'ppi(x).Image.Save(runtime.AbsolutePath + "\sites\forms\images\img_" & x.ToString, System.Drawing.Imaging.ImageFormat.Png)

        '        ListofImages(x) = runtime.AbsolutePath + "\sites\forms\images\img_" & x.ToString
        '    Next
        'End If

        _DonePrinting = True
    End Sub

    'Private tmpVectors As New List(Of Daqument.EditDaqumentUtil.Vector)

    Private Function GetPkgDocumentImage(ByVal DocID As String, ByVal PkgID As String) As Image
        Dim myDoc As Daqument.EditDaqumentUtil = New Daqument.EditDaqumentUtil(DocID)
        If myDoc.DocumentImageAvailable() Then

            Dim Img As Image = myDoc.OriginalDocumentImage
            Dim ImgBm As Bitmap = New Bitmap(Img)
            Dim backColor As Color = ImgBm.GetPixel(1, 1)
            ImgBm.MakeTransparent(backColor)

            Dim Rect As Rectangle
            Rect = New Rectangle(0, 0, Img.Width, Img.Height)

            'Dim ImageBM As Bitmap = New Bitmap(Img.Width, Img.Height)
            Dim ImageBM As Bitmap = New Bitmap(Img)
            Dim g As Graphics = Graphics.FromImage(ImageBM)
            'g.DrawRectangle(Pens.White, 0, 0, Img.Width, Img.Height)
            'g.FillRectangle(Brushes.White, 0, 0, Img.Width, Img.Height)
            Dim pkgNum As String = GetPackageName(PkgID)
            'Dim myLayerID = myDoc.GetLayerID("HL-" + pkgNum)
            'myDoc.LoadLayerVectors(myLayerID)
            'For Each vec As Daqument.EditDaqumentUtil.Vector In myDoc.LayerVectorArray
            '    tmpVectors.Add(vec)
            'Next
            'myLayerID = myDoc.GetLayerID("RL-" + pkgNum)
            'myDoc.LoadLayerVectors(myLayerID)
            'For Each vec As Daqument.EditDaqumentUtil.Vector In myDoc.LayerVectorArray
            '    tmpVectors.Add(vec)
            'Next


            g.DrawImage(ImgBm, Rect, 0, 0, Img.Width, Img.Height, GraphicsUnit.Pixel)
            If _PrintPkgHiliteLayer Then
                Dim myLayerID = myDoc.GetLayerID("HL-" + pkgNum)
                myDoc.LoadLayerVectors(myLayerID)
                For Each vec As Daqument.EditDaqumentUtil.Vector In myDoc.LayerVectorArray
                    embedLayerObject(myDoc, g, vec)
                Next
            End If
            g.DrawImage(ImgBm, Rect, 0, 0, Img.Width, Img.Height, GraphicsUnit.Pixel)
            If _PrintPkgMarkupLayer Then
                Dim myLayerID = myDoc.GetLayerID("RL-" + pkgNum)
                myDoc.LoadLayerVectors(myLayerID)
                For Each vec As Daqument.EditDaqumentUtil.Vector In myDoc.LayerVectorArray
                    embedLayerObject(myDoc, g, vec)
                Next
            End If
            Return ImageBM
        End If
        Return Nothing
    End Function


    Public Sub embedLayerObject(ByRef myDoc As Daqument.EditDaqumentUtil, ByRef g As Graphics, ByVal vec As Daqument.EditDaqumentUtil.Vector)
        If vec.VectorObjectType = "Text" Then
            Dim myFont = New Font(vec.fontfamily, vec.fontsize * (1 / vec.OrgScaleX), _
                     System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
            Dim myBrush As Brush = New SolidBrush(Color.FromArgb(vec.fontforecolor))
            Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX)
            Dim Height As Single = Math.Abs(vec.OrgStartPointY - vec.OrgEndPointY)

            g.DrawString(vec.text, myFont, myBrush, New Rectangle(New Point(vec.OrgStartPointX / vec.OrgScaleX, vec.OrgStartPointY / vec.OrgScaleY), New Size(Width, Height)))
        ElseIf vec.VectorObjectType = "Pic" Then
            If Not vec.VectorImage Is Nothing Then
                Dim newScaleX = 1 / vec.OrgScaleX
                Dim newScaleY = 1 / vec.OrgScaleY
                Dim myStartPointX As Single = vec.OrgStartPointX * newScaleX
                Dim myStartPointY As Single = vec.OrgStartPointY * newScaleY

                Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX)
                Dim Height As Single = Math.Abs(vec.OrgStartPointY - vec.OrgEndPointY)
                Dim img As Image = myDoc.ResizeImage(vec.VectorImage, New Size(Width * newScaleX, Height * newScaleY))
                g.DrawImage(vec.VectorImage, New Point(myStartPointX, myStartPointY))
                img.Dispose()
            End If
        ElseIf vec.VectorObjectType = "Line" Then
            Dim newScaleX = 1 / vec.OrgScaleX
            Dim newScaleY = 1 / vec.OrgScaleY
            Dim ScaledLineWidth = vec.OrgLineWidth * newScaleY
            Dim clr As Color = Color.FromArgb(vec.penArgb)
            Dim myPen As Pen = New Pen(New SolidBrush(clr), ScaledLineWidth)
            myPen.EndCap = vec.lineEnd
            Dim StartPointX = vec.OrgStartPointX * newScaleX
            Dim StartPointY = vec.OrgStartPointY * newScaleY
            Dim endPointX = vec.OrgEndPointX * newScaleX
            Dim endPointY = vec.OrgEndPointY * newScaleY
            Dim startPoint As Point = New Point(StartPointX, StartPointY)
            Dim endPoint As Point = New Point(endPointX, endPointY)
            g.DrawLine(myPen, startPoint, endPoint)
        End If
    End Sub


    'System subs from SystemPrintUtils
    Private Sub AddCoverPage()
        Dim linelist() As PrintUtils.pgTextLine
        Dim linectr As Integer = 0 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject("System: " + SystemManager.SystemDataManager.TranslateSystemID(SystemMUID), PrintUtils.Allign.Center, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject("Cover Page", PrintUtils.Allign.Center, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(" ", PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(" ", PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(IIf(_ckbSummaryChecked, "[X] Summary", "[   ] Summary"), PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(IIf(_ckbDiscripancyChecked, "[X] Discrepancy", "[   ] Discrepancy"), PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(IIf(_ckbPunchListChecked, "[X] Punchlist", "[   ] Punchlist"), PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(IIf(_ckbFormsChecked, "[X] Forms", "[   ] Forms"), PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(IIf(_ckbDocumentsChecked, "[X] Document", "[   ] Document"), PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(" ", PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject(" ", PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject("Requested By:  " + Utilities.GetUserName(runtime.UserName), PrintUtils.Allign.Left, f_title)
        linectr = linectr + 1 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject("Date:  " + Now.ToString, PrintUtils.Allign.Left, f_title)

        pgCtr = pgCtr + 1
        ReDim Preserve pgInfo(pgCtr)
        pgInfo(pgCtr) = PrintUtils.MakeTextPage(New Point(70, 300), linelist)
        pgInfo(pgCtr).Landscape = False
        pgInfo(pgCtr).PrintHdr = True
        pgInfo(pgCtr).PrintFooter = False
        pgInfo(pgCtr).Heading = "System: " + SystemManager.SystemDataManager.TranslateSystemID(SystemMUID)
        pgInfo(pgCtr).SubHeading = " "
        pgInfo(pgCtr).pSize = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
                       PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
    End Sub


    Private Sub AddSystemStatusSummaryPage(ByVal _OwnerMUID As String)
        Dim dt As DataTable = GetSystemPkgTagTable(_OwnerMUID)
        Dim myPgInfo() As PrintUtils.InfoSetting = PrintUtils.MakeTableListPages(dt)

        If myPgInfo Is Nothing Then Return
        For i As Integer = 0 To myPgInfo.Length - 1
            pgCtr = pgCtr + 1
            ReDim Preserve pgInfo(pgCtr)
            pgInfo(pgCtr) = myPgInfo(i)
            pgInfo(pgCtr).Landscape = False
            pgInfo(pgCtr).PrintHdr = True
            pgInfo(pgCtr).PrintFooter = True
            pgInfo(pgCtr).Heading = "System: " + SystemManager.SystemDataManager.TranslateSystemID(SystemMUID)
            pgInfo(pgCtr).SubHeading = " "
            pgInfo(pgCtr).PgNum = pgCtr
            pgInfo(pgCtr).pSize = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
               PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
        Next
    End Sub

    Private Sub AddSystemDocumentSummaryPage(ByVal _OwnerMUID As String)
        Dim dt As DataTable = GetSysDocumentStatusTable()
        Dim myPgInfo() As PrintUtils.InfoSetting = PrintUtils.MakeTableListPages(dt)
        If myPgInfo Is Nothing Then Return
        For i As Integer = 0 To myPgInfo.Length - 1
            pgCtr = pgCtr + 1
            ReDim Preserve pgInfo(pgCtr)
            pgInfo(pgCtr) = myPgInfo(i)
            pgInfo(pgCtr).Landscape = False
            pgInfo(pgCtr).PrintHdr = True
            pgInfo(pgCtr).PrintFooter = True
            pgInfo(pgCtr).Heading = "System: " + SystemManager.SystemDataManager.TranslateSystemID(SystemMUID)
            pgInfo(pgCtr).SubHeading = " "
            pgInfo(pgCtr).PgNum = pgCtr
            pgInfo(pgCtr).pSize = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
               PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
        Next
    End Sub


    Public ReadOnly Property GetSysDocumentStatusTable() As DataTable
        Get
            Dim AllDocIDs As List(Of String) = GetSysDocumentIDList(SystemMUID)
            Dim AllDocName As New List(Of String)
            Dim AllDocRev As New List(Of String)
            Dim AllDocImg As New List(Of String)
            Dim AllDocSheet As New List(Of String)
            Dim AllDocDate As New List(Of String)
            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

            sqlDocUtils.OpenConnection()

            For Each id As String In AllDocIDs
                Dim qry = " Select EngCode, Revision,DateLoaded, Sheet, Sheets  FROM documents WHERE MUID = '" + id.ToString + "'"
                Dim dtDoc As DataTable = sqlDocUtils.ExecuteQuery(qry)
                If dtDoc.Rows.Count > 0 Then
                    AllDocName.Add(dtDoc.Rows(0)(0).ToString)
                    AllDocRev.Add(dtDoc.Rows(0)(1).ToString)
                    Dim myDate As Date = dtDoc.Rows(0)(2).ToString
                    'AllDocDate.Add(dt.Rows(0)(2).ToString)
                    AllDocDate.Add(myDate.ToShortDateString)
                    Dim sheetStr = dtDoc.Rows(0)(3).ToString + " of " + dtDoc.Rows(0)(4).ToString
                    AllDocSheet.Add(sheetStr)
                    Dim docImgPresent As String = "No"
                    Dim docImg As Daqument.EditDaqumentUtil = New Daqument.EditDaqumentUtil(id)
                    If docImg.DocumentImageAvailable() Then
                        docImgPresent = "Yes"
                    End If
                    AllDocImg.Add(docImgPresent)
                End If
            Next

            sqlDocUtils.CloseConnection()
            Dim dt As DataTable = New DataTable
            'dt.Columns.Add(New DataColumn("#", GetType(Integer)))
            dt.Columns.Add(New DataColumn("DocumentName", GetType(String)))
            dt.Columns.Add(New DataColumn("Rev", GetType(String)))
            dt.Columns.Add(New DataColumn("Date", GetType(String)))
            dt.Columns.Add(New DataColumn("Sheet", GetType(String)))
            dt.Columns.Add(New DataColumn("Image", GetType(String)))
            dt.Columns.Add(New DataColumn("RedLine", GetType(String)))


            dt.Columns("DocumentName").Caption = "  Document Name     "
            dt.Columns("Rev").Caption = " Rev  "
            dt.Columns("Date").Caption = " Date   "
            dt.Columns("Sheet").Caption = " Sheet  "
            dt.Columns("Image").Caption = " Image "
            dt.Columns("RedLine").Caption = " RedLine "
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            sqlPrjUtils.OpenConnection()

            Try
                For i As Integer = 0 To AllDocIDs.Count - 1
                    Dim docName As String = AllDocName(i)
                    Dim docRev As String = Utilities.TranslateRev(AllDocRev(i))
                    Dim docImgPresent As String = AllDocImg(i)
                    Dim docSheet As String = AllDocSheet(i)
                    Dim docDate As String = AllDocDate(i)
                    Dim DocID As String = AllDocIDs(i)
                    Dim qry = " SELECT PackageMUID " + _
                                " FROM  package_documents WHERE SystemMUID LIKE " + Utilities.SystemQuery(SystemMUID) & _
                                        " AND DocumentMUID = '" + DocID.ToString + "'"
                    Try
                        Dim dtt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                        Dim RedLine As String = "No"
                        For j As Integer = 0 To dtt.Rows.Count - 1
                            Dim pkgID As Integer = dtt.Rows(j)(0)
                            If pkgID > 0 Then
                                If Utilities.TestPkgDocContainsRedLineItems(DocID, pkgID) Then
                                    RedLine = "Yes"
                                End If
                            End If
                        Next
                        Dim dr As DataRow = dt.NewRow
                        dr(0) = docName : dr(1) = docRev : dr(2) = docDate : dr(3) = docSheet : dr(4) = docImgPresent
                        dr(5) = RedLine
                        dt.Rows.Add(dr)
                    Catch ex As Exception

                    End Try
                Next
            Catch ex As Exception

            End Try
            sqlPrjUtils.CloseConnection()
            Return dt
        End Get
    End Property


    Public ReadOnly Property GetSysDocumentIDList(ByVal SysID As String) As List(Of String)
        Get
            Dim AllDocIDs As New List(Of String)
            Dim WHEREStr As String = ""
            If SysID > "" Then
                WHEREStr = "WHERE SystemMUID " + Utilities.SystemQuery(SysID)
            End If

            Dim qry = "Select DISTINCT DocumentMUID FROM package_documents " + WHEREStr
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)

            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
            sqlDocUtils.OpenConnection()

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    'get all documents matching the engineering code and sheet number
                    'Dim id As String = Utilities.GetDocumentLatestRevID(dt.Rows(i)("DocumentMUID"))
                    'Dim query As String = "Select * From documents WHERE MUID='" + id + "'"

                    Dim DocumentInfo As DataTable = Utilities.GetDocumentInfo(dt.Rows(i)("DocumentMUID"))
                    If DocumentInfo.Rows.Count > 0 Then
                        Dim query As String = "SELECT * FROM documents WHERE EngCode = '" + DocumentInfo.Rows(0)("EngCode") + "'"
                        Dim dt2 As DataTable = sqlDocUtils.ExecuteQuery(query)
                        If dt2.Rows.Count > 0 Then
                            AllDocIDs.Add(dt.Rows(i)(0))
                        End If
                    End If


                Next
            End If
            sqlDocUtils.CloseConnection()
            Return AllDocIDs
        End Get
    End Property


    Private Sub AddSystemDocumentImagePage(ByVal _DocumentMUID As String)
        Dim Image As Image = GetSysDocumentImage(_DocumentMUID)
        If Image Is Nothing Then
            Return
        Else
            'Image = HoldImage
            HoldImage = Image.Clone
        End If

        pgCtr = pgCtr + 1
        ReDim Preserve pgInfo(pgCtr)

        Dim qry As String = "SELECT document_type.Disable11x17 From Document_type, documents WHERE " + _
        " document_type.MUID = documents.DocumentTypeMUID AND documents.MUID = '" + _DocumentMUID.ToString + "'"
        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
        'Dim Disable11x17 As String = Utilities.ExecuteQuery(qry, "Daqument").Rows(0)(0).ToString

        sqlDocUtils.OpenConnection()
        Dim Disable11x17 As String = sqlDocUtils.ExecuteQuery(qry).Rows(0)(0).ToString
        sqlDocUtils.CloseConnection()

        Dim pp11x17 As Boolean = False
        If _ckb_11x17 And Disable11x17 <> "1" Then
            pp11x17 = True
        End If

        Dim sz As Size = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
            PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)

        If Image.Size.Width > Image.Size.Height Then
            pgInfo(pgCtr).Landscape = True
        End If

        If pp11x17 Then
            'For i As Integer = 0 To PrintDoc.PrinterSettings.PaperSizes.Count - 1
            '    Dim ppSize As System.Drawing.Printing.PaperSize = PrintDoc.PrinterSettings.PaperSizes.Item(i)
            '    Dim pKind As System.Drawing.Printing.PaperKind = PrintDoc.PrinterSettings.PaperSizes.Item(i).Kind
            '    If pKind = PaperKind.Tabloid Then
            '        sz = New Size(ppSize.Height, ppSize.Width)
            '        pgInfo(pgCtr).pSize = sz
            '        pgInfo(pgCtr).pkSize = ppSize
            '        pgInfo(pgCtr).Landscape = True
            '        Exit For
            '    End If
            'Next
            If pgInfo(pgCtr).Landscape = True Then
                pgInfo(pgCtr).pprKind = PrintUtils.GetPaperKind(Image.Size.Width, Image.Size.Height)
            Else
                pgInfo(pgCtr).pprKind = PrintUtils.GetPaperKind(Image.Size.Width, Image.Size.Height)
            End If
        Else
            'For i As Integer = 0 To PrintDoc.PrinterSettings.PaperSizes.Count - 1
            '    Dim pSize As PaperSize = PrintDoc.PrinterSettings.PaperSizes.Item(i)
            '    Dim pKind As System.Drawing.Printing.PaperKind = PrintDoc.PrinterSettings.PaperSizes.Item(i).RawKind
            '    If pKind = PaperKind.Letter Then
            '        sz = New Size(pSize.Height, pSize.Width)
            '        Exit For
            '    End If
            'Next
            If pgInfo(pgCtr).Landscape = True Then
                pgInfo(pgCtr).pprKind = PrintUtils.GetPaperKind(Image.Size.Width, Image.Size.Height)
            Else
                pgInfo(pgCtr).pprKind = PrintUtils.GetPaperKind(Image.Size.Width, Image.Size.Height)
            End If
        End If

        pgInfo(pgCtr).PrintHdr = False
        pgInfo(pgCtr).PrintFooter = False
        pgInfo(pgCtr).Heading = " "
        pgInfo(pgCtr).SubHeading = " "
        pgInfo(pgCtr).PgNum = pgCtr

        pgInfo(pgCtr).pSize = New Size(Image.Size.Width, Image.Size.Height)
        Dim j As Integer = 0
        ReDim Preserve pgInfo(pgCtr).pgBody(j)
        Dim fn As String = PrintUtils.GetNextImageFileName()
        Image.Save(fn)
        pgInfo(pgCtr).pgBody(j).contentType = PrintUtils.pgContentType.docImage
        pgInfo(pgCtr).pgBody(j).obj = fn
        pgInfo(pgCtr).pgBody(j).loc = New Point(0, 0)
        pgInfo(pgCtr).pgBody(j).sz = sz 'Image.Size 'pkSize
        Image.Dispose()
    End Sub


    Private Function GetSysDocumentImage(ByVal _DocumentMUID As String) As Image
        Dim tmpVectors As New List(Of Daqument.EditDaqumentUtil.Vector)
        Dim LatestRevMUID As String = Utilities.GetDocumentLatestRevID(_DocumentMUID)
        Dim myDoc As Daqument.EditDaqumentUtil = New Daqument.EditDaqumentUtil(LatestRevMUID)


        If myDoc.DocumentImageAvailable() Then
            Dim Img As Image = myDoc.OriginalDocumentImage
            Dim ImgBm As Bitmap = New Bitmap(Img)
            Dim backColor As Color = ImgBm.GetPixel(1, 1)
            ImgBm.MakeTransparent(backColor)

            Dim Rect As Rectangle
            Rect = New Rectangle(0, 0, Img.Width, Img.Height)

            Dim ImageBM As Bitmap = New Bitmap(Img)
            Dim CloneImg As Image = Img.Clone

            Dim g As Graphics = Graphics.FromImage(ImageBM)
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            Try
                Dim qry = "SELECT PackageMUID FROM  package_documents WHERE SystemMUID " + Utilities.SystemQuery(SystemMUID) & _
                               " AND DocumentMUID = '" + _DocumentMUID + "'"
                sqlPrjUtils.OpenConnection()
                Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                sqlPrjUtils.CloseConnection()
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim PkgID As String = dt.Rows(i)(0)
                    If Not PkgID = "" Then
                        Dim pkgNum As String = Utilities.GetPackageName(PkgID)
                        Dim myLayerID = myDoc.GetLayerID("HL-" + pkgNum)

                        myDoc.LoadLayerVectors(myLayerID)
                        For Each vec As Daqument.EditDaqumentUtil.Vector In myDoc.LayerVectorArray
                            tmpVectors.Add(vec)
                        Next

                        myLayerID = myDoc.GetLayerID("RL-" + pkgNum)
                        myDoc.LoadLayerVectors(myLayerID)
                        For Each vec As Daqument.EditDaqumentUtil.Vector In myDoc.LayerVectorArray
                            Me.HoldImageRedline = True
                            tmpVectors.Add(vec)
                        Next

                        g.DrawImage(ImgBm, Rect, 0, 0, Img.Width, Img.Height, GraphicsUnit.Pixel)
                        If _PrintPkgHiliteLayer Then
                            For Each vec As Daqument.EditDaqumentUtil.Vector In tmpVectors
                                If vec.ObjectMode = "Hilite" Then
                                    embedLayerObject(g, vec)
                                End If
                            Next
                        End If

                        If _PrintPkgMarkupLayer Then
                            For Each vec As Daqument.EditDaqumentUtil.Vector In tmpVectors
                                If vec.ObjectMode = "Marking" Then
                                    embedLayerObject(g, vec)
                                End If
                            Next
                        End If
                    End If
                Next

                'Overlay
                g.DrawImage(ImgBm, Rect, 0, 0, Img.Width, Img.Height, GraphicsUnit.Pixel)

                HoldImage = ImageBM.Clone

                Img.Dispose()
                ImgBm.Dispose()
                ImageBM.Dispose()
                CloneImg.Dispose()


            Catch ex As Exception

            End Try

            Return ImageBM
        End If
        Return Nothing
    End Function


    Public Sub embedLayerObject(ByRef g As Graphics, ByVal vec As Daqument.EditDaqumentUtil.Vector)
        If vec.VectorObjectType = "Text" Then
            Dim myFont = New Font(vec.fontfamily, vec.fontsize * (1 / vec.OrgScaleX), _
                     System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
            Dim myBrush As Brush = New SolidBrush(Color.FromArgb(vec.fontforecolor))
            Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX)
            Dim Height As Single = Math.Abs(vec.OrgStartPointY - vec.OrgEndPointY)

            g.DrawString(vec.text, myFont, myBrush, New Rectangle(New Point(vec.OrgStartPointX / vec.OrgScaleX, vec.OrgStartPointY / vec.OrgScaleY), New Size(Width, Height)))
        ElseIf vec.VectorObjectType = "Pic" Then
            g.DrawImage(vec.pBox.Image, New Point(vec.StartPointX, vec.StartPointY))
        ElseIf vec.VectorObjectType = "Line" Then
            Dim newScaleX = 1 / vec.OrgScaleX
            Dim newScaleY = 1 / vec.OrgScaleY
            Dim ScaledLineWidth = vec.OrgLineWidth * newScaleY
            Dim clr As Color = Color.FromArgb(vec.penArgb)
            Dim myPen As Pen = New Pen(New SolidBrush(clr), ScaledLineWidth)
            myPen.EndCap = vec.lineEnd
            Dim StartPointX = vec.OrgStartPointX * newScaleX
            Dim StartPointY = vec.OrgStartPointY * newScaleY
            Dim endPointX = vec.OrgEndPointX * newScaleX
            Dim endPointY = vec.OrgEndPointY * newScaleY
            Dim startPoint As Point = New Point(StartPointX, StartPointY)
            Dim endPoint As Point = New Point(endPointX, endPointY)
            g.DrawLine(myPen, startPoint, endPoint)
        End If
    End Sub


    Private Function GetSystemPkgTagTable(ByVal _OwnerMUID As String) As DataTable
        Dim i As Integer
        Dim query As String
        Dim SystemStatusTable As New DataTable
        Dim PackageTable As New DataTable

        query = "SELECT " & _
        "package.packageMUID, package.PackageNumber AS Package, package.Description AS Description, package.DisciplineMUID  " & _
        "FROM package  " & _
        "WHERE package.SystemMUID " + Utilities.SystemQuery(SystemMUID) + " AND OwnerMUID= " & _OwnerMUID

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        PackageTable = sqlPrjUtils.ExecuteQuery(query)
        PackageTable.Columns.Add("Disc")
        PackageTable.Columns("Disc").DataType = System.Type.GetType("System.String")
        PackageTable.Columns.Add("Level")
        PackageTable.Columns.Add("Earned_MH")
        PackageTable.Columns.Add("Reqd_MH")
        PackageTable.Columns.Add("PerComp")


        Dim PackageStatusTable As New DataTable
        For i = 0 To PackageTable.Rows.Count - 1
            query = "SELECT " & _
            "package_status.CurrentLevel As Level, package_status.EarnedManHours As Earned_MH, " & _
            "package_status.RequiredManHours AS Reqd_MH, " & _
            "CASE WHEN package_status.RequiredManHours = '0' THEN 0 ELSE " & _
            "Round(package_status.EarnedManHours / package_status.RequiredManHours * 100, 2) END AS PerComp " & _
            "FROM package_status  " & _
            "WHERE MUID = '" & PackageTable.Rows(i)(0) & "' " & _
            " AND OwnerMUID= " & _OwnerMUID

            PackageStatusTable = sqlPrjUtils.ExecuteQuery(query)
            PackageTable.Rows(i)(4) = Utilities.GetDisciplineName(PackageTable.Rows(i)(3))

            If Not PackageStatusTable.Rows.Count = 0 Then
                PackageTable.Rows(i)(5) = PackageStatusTable.Rows(0)(0)
                PackageTable.Rows(i)(6) = PackageStatusTable.Rows(0)(1)
                PackageTable.Rows(i)(7) = PackageStatusTable.Rows(0)(2)
                PackageTable.Rows(i)(8) = PackageStatusTable.Rows(0)(3)
            Else
                PackageTable.Rows(i)(5) = 0
                PackageTable.Rows(i)(6) = 0
                PackageTable.Rows(i)(7) = 0
                PackageTable.Rows(i)(8) = 0
            End If
        Next

        Dim EMH As Single = 0
        Dim RMH As Single = 0

        Dim CompletePackageCount As Integer = 0
        For Each dr As DataRow In PackageTable.Rows
            Dim CompletePackageTable As New DataTable
            query = "SELECT * " & _
            "FROM package_status " & _
            "WHERE OwnerMUID = '" & _OwnerMUID + "'" + _
            "AND PackageMUID = '" & dr(0) & "' " & _
            "AND CurrentLevel = '" & Utilities.GetFormConfigCount(_OwnerMUID) & "' "

            CompletePackageTable = sqlPrjUtils.ExecuteQuery(query)
            CompletePackageCount += CompletePackageTable.Rows.Count

            EMH += dr(6)
            RMH += dr(7)
        Next

        sqlPrjUtils.CloseConnection()

        Dim PComplete As Double
        If Not RMH = 0 Then
            PComplete = Math.Round(Convert.ToDouble(EMH) / Convert.ToDouble(RMH) * 100, 2)
        Else
            PComplete = 0.0
        End If

        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Package")
        dt.Columns.Add("Disc")
        dt.Columns.Add("Earned_MH")
        dt.Columns.Add("Reqd_MH")
        dt.Columns.Add("PerComp")

        dt.Columns("Package").Caption = "   Package                  "
        dt.Columns("Disc").Caption = " Discipline "
        dt.Columns("Earned_MH").Caption = " Earned Manhr "
        dt.Columns("Reqd_MH").Caption = " Reqd Manhr "
        dt.Columns("PerComp").Caption = " % Complete "

        For i = 0 To PackageTable.Rows.Count - 1
            Dim r As DataRow = dt.NewRow
            r("Package") = PackageTable.Rows(i)("Package")
            r("Disc") = Utilities.GetDisciplineName(PackageTable.Rows(i)("DisciplineMUID"))
            r("Earned_MH") = PackageTable.Rows(i)("Earned_MH")
            r("Reqd_MH") = PackageTable.Rows(i)("Reqd_MH")
            r("PerComp") = PackageTable.Rows(i)("PerComp")
            dt.Rows.Add(r)
        Next

        Return dt 'PackageTable
    End Function


End Class
