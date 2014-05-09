Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports System.Drawing.Graphics
Imports daqartDLL
Imports SystemManager


Public Class SystemPrintUtils
    Private pgInfo() As PrintUtils.InfoSetting
    Private PrintDoc As PrintDocument
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
    Private _DonePrinting As Boolean = False
    Private SysID As String = ""
    Private SysName As String = ""
    Private _PrintPkgHiliteLayer As Boolean = False
    Private _PrintPkgMarkupLayer As Boolean = False


    Public Sub New(ByVal _SysID As String)
        SysID = _SysID
        SysName = SystemDataManager.GetFullSystemDescription(_SysID)
        Dim logoPath = runtime.AbsolutePath + "sites\images\logo128.jpg"
        logoImg = Image.FromFile(logoPath)
    End Sub


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


    Public ReadOnly Property DonePrinting()
        Get
            Return _DonePrinting
        End Get
    End Property


    Public ReadOnly Property GetSystemName(ByVal SysID As String) As String
        Get
            Return SysName
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

            Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
            sqlPrjUtils.CloseConnection()

            Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
            sqlDocUtils.OpenConnection()

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim id As String = Utilities.GetDocumentLatestRevID(dt.Rows(i)("DocumentMUID"))
                    Dim query As String = "Select * From documents WHERE MUID='" + id + "'"
                    Dim dt2 As DataTable = sqlDocUtils.ExecuteQuery(query)
                    If dt2.Rows.Count > 0 Then
                        AllDocIDs.Add(dt.Rows(i)(0))
                    End If
                Next
            End If
            sqlDocUtils.CloseConnection()
            Return AllDocIDs
        End Get
    End Property


    'Public ReadOnly Property GetPackageName(ByVal _MUID As String) As String
    '    Get
    '        Dim qry = " Select PackageNumber FROM Package WHERE MUID = '" + _MUID + "'"
    '        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
    '        sqlPrjUtils.OpenConnection()
    '        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '        sqlPrjUtils.CloseConnection()

    '        Return dt.Rows(0)("PackageNumber").ToString
    '    End Get
    'End Property


    Private Function GetSysDocumentImage(ByVal _DocumentMUID As String) As Image
        Dim tmpVectors As New List(Of Daqument.EditDaqumentUtil.Vector)
        Dim myDoc As Daqument.EditDaqumentUtil = New Daqument.EditDaqumentUtil(_DocumentMUID)

        If myDoc.DocumentImageAvailable() Then
            Dim Img As Image = myDoc.OriginalDocumentImage
            Dim ImgBm As Bitmap = New Bitmap(Img)
            Dim backColor As Color = ImgBm.GetPixel(1, 1)
            ImgBm.MakeTransparent(backColor)

            Dim Rect As Rectangle
            Rect = New Rectangle(0, 0, Img.Width, Img.Height)

            Dim ImageBM As Bitmap = New Bitmap(Img)
            Dim g As Graphics = Graphics.FromImage(ImageBM)
            Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            Try
                Dim qry = " SELECT PackageMUID " + _
                               " FROM  package_documents WHERE SystemMUID LIKE '%" + _
                               SysID + "%' AND DocumentMUID = " + _DocumentMUID
                sqlPrjUtils.OpenConnection()
                Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
                sqlPrjUtils.CloseConnection()
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim PkgID As Integer = dt.Rows(i)(0)
                    If PkgID > 0 Then
                        Dim pkgNum As String = Utilities.GetPackageName(PkgID)
                        Dim myLayerID = myDoc.GetLayerID("HL-" + pkgNum)
                        myDoc.LoadLayerVectors(myLayerID)
                        For Each vec As Daqument.EditDaqumentUtil.Vector In myDoc.LayerVectorArray
                            tmpVectors.Add(vec)
                        Next
                        myLayerID = myDoc.GetLayerID("RL-" + pkgNum)
                        myDoc.LoadLayerVectors(myLayerID)
                        For Each vec As Daqument.EditDaqumentUtil.Vector In myDoc.LayerVectorArray
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


    Private Sub AddSystemDocumentImagePage(ByVal _DocumentMUID As String)
        Dim Image As Image = GetSysDocumentImage(_DocumentMUID)
        If Image Is Nothing Then Return

        pgCtr = pgCtr + 1
        ReDim Preserve pgInfo(pgCtr)

        Dim pp11x17 As Boolean = False
        If _ckb_11x17 Then
            pp11x17 = True
        End If
        Dim sz As Size = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
            PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
        pgInfo(pgCtr).Landscape = True
        If pp11x17 Then
            For i As Integer = 0 To PrintDoc.PrinterSettings.PaperSizes.Count - 1
                Dim ppSize As System.Drawing.Printing.PaperSize = PrintDoc.PrinterSettings.PaperSizes.Item(i)
                Dim pKind As System.Drawing.Printing.PaperKind = PrintDoc.PrinterSettings.PaperSizes.Item(i).Kind
                If pKind = PaperKind.Tabloid Then
                    sz = New Size(ppSize.Height, ppSize.Width)
                    pgInfo(pgCtr).pSize = sz
                    pgInfo(pgCtr).pkSize = ppSize
                    pgInfo(pgCtr).Landscape = True
                    Exit For
                End If
            Next
        Else
            For i As Integer = 0 To PrintDoc.PrinterSettings.PaperSizes.Count - 1
                Dim pSize As PaperSize = PrintDoc.PrinterSettings.PaperSizes.Item(i)
                Dim pKind As System.Drawing.Printing.PaperKind = PrintDoc.PrinterSettings.PaperSizes.Item(i).RawKind
                If pKind = PaperKind.Letter Then
                    sz = New Size(pSize.Height, pSize.Width)
                    Exit For
                End If
            Next
        End If

        pgInfo(pgCtr).PrintHdr = False
        pgInfo(pgCtr).PrintFooter = False
        pgInfo(pgCtr).Heading = " "
        pgInfo(pgCtr).SubHeading = " "
        pgInfo(pgCtr).PgNum = pgCtr

        pgInfo(pgCtr).pSize = sz
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


    Private Sub AddCoverPage()
        Dim linelist() As PrintUtils.pgTextLine
        Dim linectr As Integer = 0 : ReDim Preserve linelist(linectr)
        linelist(linectr) = PrintUtils.MakeTextLineObject("System: " + SysName, PrintUtils.Allign.Center, f_title)
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
        pgInfo(pgCtr).Heading = "System: " + SysName
        pgInfo(pgCtr).SubHeading = " "
        pgInfo(pgCtr).pSize = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
                       PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
    End Sub


    Private Function GetSystemPkgTagTable(ByVal _OwnerMUID As String) As DataTable
        Dim i As Integer
        Dim query As String
        Dim SystemStatusTable As New DataTable
        Dim PackageTable As New DataTable

        query = "SELECT " & _
        "package.packageMUID, package.PackageNumber AS Package, package.Description AS Description, package.DisciplineMUID  " & _
        "FROM package  " & _
        "WHERE package.SystemMUID " + Utilities.SystemQuery(SysID) + " AND OwnerMUID= " & _OwnerMUID

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
            pgInfo(pgCtr).Heading = "System: " + SysName
            pgInfo(pgCtr).SubHeading = " "
            pgInfo(pgCtr).PgNum = pgCtr
            pgInfo(pgCtr).pSize = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
               PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
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
                pgInfo(pgCtr).Heading = "Package: " + Utilities.GetPackageName(_PkgID)
                pgInfo(pgCtr).SubHeading = "Discrepancies "
                pgInfo(pgCtr).PgNum = pgCtr
            End If
        Next

    End Sub


    'Private Sub AddDiscrepancyPages(ByVal _PackageMUID As String)
    '    Dim qry = "select discrepancy.MUID from discrepancy,package WHERE " + _
    '        " package.MUID = '" + _PackageMUID.ToString + "'" + _
    '        " AND discrepancy.PackageMUID=package.MUID"

    '    Dim sqlPrjUtils As DataUtils = New DataUtils("project")
    '    sqlPrjUtils.OpenConnection()
    '    Dim IDList As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '    sqlPrjUtils.CloseConnection()

    '    Dim mypgInfo() As PrintUtils.InfoSetting ' = DiscrepancyManager.DiscrepancyPrintUtils(IDList)
    '    Dim mypgCtr As Integer = 0
    '    If mypgInfo Is Nothing Then Return

    '    For Each myPage As PrintUtils.InfoSetting In mypgInfo
    '        If mypgInfo.Length > 0 Then
    '            pgCtr = pgCtr + 1
    '            ReDim Preserve pgInfo(pgCtr)
    '            pgInfo(pgCtr) = myPage
    '            mypgCtr = mypgCtr + 1
    '            pgInfo(pgCtr).Landscape = False
    '            pgInfo(pgCtr).PrintHdr = True
    '            pgInfo(pgCtr).PrintFooter = True
    '            pgInfo(pgCtr).Heading = "System: " + SysName
    '            pgInfo(pgCtr).SubHeading = "Package: " + GetPackageName(_PackageMUID)
    '            pgInfo(pgCtr).PgNum = pgCtr
    '        End If
    '    Next
    'End Sub


    'Private Sub AddPunchlistPages(ByVal _PackageMUID As String)
    '    Dim qry = "SELECT MUID, TagNumber FROM tags WHERE PackageMUID = '" + _PackageMUID + "'"
    '    Dim sqlPrjUtils As DataUtils = New DataUtils("project")
    '    sqlPrjUtils.OpenConnection()
    '    Dim tagdt As DataTable = sqlPrjUtils.ExecuteQuery(qry)

    '    For ii As Integer = 0 To tagdt.Rows.Count - 1
    '        qry = "SELECT MUID FROM punchlist WHERE TagMUID = '" + tagdt.Rows(ii)("MUID").ToString + "'"
    '        Dim punchlistdt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
    '        Dim mypgInfo() As PrintUtils.InfoSetting = PunchlistManager.PunchlistDataManager.MakeShortPunchlistPrintPages(punchlistdt)
    '        Dim mypgCtr As Integer = 0

    '        If Not mypgInfo Is Nothing Then
    '            For Each myPage As PrintUtils.InfoSetting In mypgInfo
    '                If mypgInfo.Length > 0 Then
    '                    pgCtr = pgCtr + 1
    '                    ReDim Preserve pgInfo(pgCtr)
    '                    pgInfo(pgCtr) = myPage
    '                    mypgCtr = mypgCtr + 1
    '                    pgInfo(pgCtr).Landscape = False
    '                    pgInfo(pgCtr).PrintHdr = True
    '                    pgInfo(pgCtr).PrintFooter = True
    '                    pgInfo(pgCtr).Heading = "Package: " + GetPackageName(_PackageMUID)
    '                    pgInfo(pgCtr).SubHeading = "Punchlist" + "-- Tag: " + tagdt.Rows(ii)(1).ToString
    '                    pgInfo(pgCtr).PgNum = pgCtr
    '                End If
    '            Next
    '        End If
    '    Next
    '    sqlPrjUtils.CloseConnection()
    'End Sub
    '  /* •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    ' | Private Sub AddPunchlistPages(ByVal _PkgID As String)                                                                              |
    ' |     Dim qry = "SELECT MUID, TagNumber FROM tags WHERE PackageMUID = '" + _PkgID.ToString + "'"                                     |
    ' |     'Dim tagdt As DataTable = Utilities.ExecuteQuery(qry, "project")                                                               |
    ' |     Dim sqlPrjUtils As DataUtils = New DataUtils("project")                                                                        |
    ' |                                                                                                                                    |
    ' |     sqlPrjUtils.OpenConnection()                                                                                                   |
    ' |     Dim tagdt As DataTable = sqlPrjUtils.ExecuteQuery(qry)                                                                         |
    ' |                                                                                                                                    |
    ' |     For ii As Integer = 0 To tagdt.Rows.Count - 1                                                                                  |
    ' |         qry = "SELECT MUID FROM punchlist WHERE TagMUID = '" + tagdt.Rows(ii)("MUID").ToString + "'"                               |
    ' |         'Dim punchlistdt As DataTable = Utilities.ExecuteQuery(qry, "project")                                                     |
    ' |         Dim punchlistdt As DataTable = sqlPrjUtils.ExecuteQuery(qry)                                                               |
    ' |                                                                                                                                    |
    ' |         Dim mypgInfo() As PrintUtils.InfoSetting = PunchlistManager.PunchlistDataManager.MakeShortPunchlistPrintPages(punchlistdt) |
    ' |         Dim mypgCtr As Integer = 0                                                                                                 |
    ' |         If Not mypgInfo Is Nothing Then                                                                                            |
    ' |             For Each myPage As PrintUtils.InfoSetting In mypgInfo                                                                  |
    ' |                 If mypgInfo.Length > 0 Then                                                                                        |
    ' |                     pgCtr = pgCtr + 1                                                                                              |
    ' |                     ReDim Preserve pgInfo(pgCtr)                                                                                   |
    ' |                     pgInfo(pgCtr) = myPage                                                                                         |
    ' |                     mypgCtr = mypgCtr + 1                                                                                          |
    ' |                     pgInfo(pgCtr).Landscape = False                                                                                |
    ' |                     pgInfo(pgCtr).PrintHdr = True                                                                                  |
    ' |                     pgInfo(pgCtr).PrintFooter = True                                                                               |
    ' |                     pgInfo(pgCtr).Heading = "Package: " + Utilities.GetPackageName(_PkgID)                                         |
    ' |                     pgInfo(pgCtr).SubHeading = "Punchlist" + "-- Tag: " + tagdt.Rows(ii)(1).ToString                               |
    ' |                     pgInfo(pgCtr).PgNum = pgCtr                                                                                    |
    ' |                 End If                                                                                                             |
    ' |             Next                                                                                                                   |
    ' |         End If                                                                                                                     |
    ' |     Next                                                                                                                           |
    ' |     sqlPrjUtils.CloseConnection()                                                                                                  |
    ' |                                                                                                                                    |
    ' | End Sub                                                                                                                            |
    ' |                                                                                                                                    |
    '    •————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————• */

    Public ReadOnly Property GetSysDocumentStatusTable() As DataTable
        Get
            Dim AllDocIDs As List(Of String) = GetSysDocumentIDList(SysID)
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
                    Dim docRev As String = AllDocRev(i)
                    Dim docImgPresent As String = AllDocImg(i)
                    Dim docSheet As String = AllDocSheet(i)
                    Dim docDate As String = AllDocDate(i)
                    Dim DocID As Integer = AllDocIDs(i)
                    Dim qry = " SELECT PackageMUID " + _
                                " FROM  package_documents WHERE SystemMUID LIKE '%" + _
                                        SysID + "%' AND DocumentMUID = '" + DocID.ToString + "'"
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
            pgInfo(pgCtr).Heading = "System: " + SysName
            pgInfo(pgCtr).SubHeading = " "
            pgInfo(pgCtr).PgNum = pgCtr
            pgInfo(pgCtr).pSize = New Size(PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Width, _
               PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize.Height)
        Next
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
        Dim qry = " SELECT MUID, PackageNumber, Description, GroupMUID, OwnerMUID, DisciplineMUID " + _
        " FROM  Package WHERE OwnerMUID = '" + _OwnerMUID + "' AND SystemMUID " + Utilities.SystemQuery(SysID)
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

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
        '     If _ckbPunchListChecked Then
        'For Each PkgID As String In AllPkgIDList
        'AddPunchlistPages(PkgID)
        'Next
        '  End If
        If _ckbDocumentsChecked Then
            AddSystemDocumentSummaryPage(_OwnerMUID)
            For Each DocID As String In GetSysDocumentIDList(SysID)
                Try
                    AddSystemDocumentImagePage(DocID)
                Catch ex As Exception

                End Try
            Next
        End If

    End Sub


    Private Sub printDoc_BeginPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        pgCtr = 0
        'PrintDoc.PrinterSettings.DefaultPageSettings.PaperSize = pgInfo(0).ppSize
        If pgInfo(pgCtr).Landscape Then
            PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = True
        Else
            PrintDoc.PrinterSettings.DefaultPageSettings.Landscape = False
        End If
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


    Private Sub printDoc_EndPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        _DonePrinting = True
    End Sub


    Public Sub Print2PDF(ByVal dest As String, ByVal _OwnerMUID As String)
        _DonePrinting = False
        Cursor.Current = Cursors.WaitCursor
        MakeSysPrintImages(_OwnerMUID)
        image_pdf.PrintPDFPages(pgInfo, dest)

        Cursor.Current = Cursors.Default
        _DonePrinting = True
    End Sub


    Public Sub PrintSystem(ByVal _OwnerMUID As String)
        _DonePrinting = False
        Cursor.Current = Cursors.WaitCursor
        MakeSysPrintImages(_OwnerMUID)
        PrintDoc.DocumentName = "Print Packages"
        AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
        AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage
        PrintDoc.Print()
        Cursor.Current = Cursors.Default
    End Sub


    Public Sub PrintPreviewSystem(ByVal _OwnerMUID As String)
        _DonePrinting = False
        Cursor.Current = Cursors.WaitCursor
        MakeSysPrintImages(_OwnerMUID)
        PrintDoc.DocumentName = "Print Packages"
        Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()

        AddHandler PrintDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler PrintDoc.EndPrint, AddressOf printDoc_EndPrint
        AddHandler PrintDoc.PrintPage, AddressOf printDoc_PrintPage

        Cursor.Current = Cursors.Default
        printDialog.Document = Me.PrintDoc
        printDialog.ShowDialog()
    End Sub


End Class
