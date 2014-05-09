Imports daqartDLL
Imports SystemManager


Public Class CustomSummary
    Public PkgID As String
    Public OwnerID As String
    Public Landscape As Boolean = False
    Public PrintHdr As Boolean = False
    Public PrintFooter As Boolean = False
    Public NumberofPages As Integer
    Public CustomPages As New List(Of Pages)

    Private PackageData As New DataTable
    Private TagsData As New DataTable
    Private DocsData As New DataTable
    Private myMargin As Integer = 30
    Private InfoCoverNeeded As Boolean = True


    Public Sub New(ByVal _PkgID As String, ByVal _OwnerID As String)
        PkgID = _PkgID
        OwnerID = _OwnerID

        TagsData = GetTags()
        DocsData = GetDocs()
        AddCoverPage()

        For i As Integer = 0 To TagsData.Rows.Count - 1
            AddInfoPages(i)
            If i = 0 Then
                i += 1
            Else
                i += 2
            End If
        Next

    End Sub


    Structure Pages
        Dim Landscape As Boolean
        Dim PrintHdr As Boolean
        Dim PrintFooter As Boolean
        Dim pgInfo As PrintUtils.InfoSetting
    End Structure


    Public Sub AddCoverPage()
        Dim ThisPage As New Pages
        ThisPage.Landscape = False
        ThisPage.PrintHdr = False
        ThisPage.PrintFooter = False

        Dim pgInfo As PrintUtils.InfoSetting = New PrintUtils.InfoSetting
        Dim pgContents As PrintUtils.pgBodyContents = New PrintUtils.pgBodyContents
        Dim PageCenter As Integer
        If ThisPage.Landscape Then PageCenter = 550 Else PageCenter = 425
        Dim myFont As Font
        Dim myString As String
        Dim i As Integer = 0
        Dim TagCount As Integer = Utilities.CountTags(PkgID)

        ReDim Preserve pgInfo.pgBody(i)
        myFont = New Font("Verdana", 20, FontStyle.Bold)
        myString = "Package Table of Contents"
        pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(PageCenter - (FindStringWidth(myString, myFont) / 2), 10), myFont, Color.Black)
        i = i + 1

        ReDim Preserve pgInfo.pgBody(i)
        myFont = New Font("Verdana", 20, FontStyle.Bold)
        myString = "Z506C"
        pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(PageCenter - (FindStringWidth(myString, myFont) / 2), 40), myFont, Color.Black)
        i = i + 1

        ReDim Preserve pgInfo.pgBody(i)
        myFont = New Font("Verdana", 12, FontStyle.Regular)
        myString = "Z-PAD WELL MODULE 506C"
        pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(PageCenter - (FindStringWidth(myString, myFont) / 2), 70), myFont, Color.Black)
        i = i + 1

        ReDim Preserve pgInfo.pgBody(i)
        pgInfo.pgBody(i) = PrintUtils.MakeLineObject(New Point(myMargin, 110), New Point(850 - myMargin, 110))
        i = i + 1

        ReDim Preserve pgInfo.pgBody(i)
        myFont = New Font("Verdana", 16, FontStyle.Regular)
        myString = "Sys: " + GetSystemNumber()
        pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(30, 115), myFont, Color.Black)
        i = i + 1

        ReDim Preserve pgInfo.pgBody(i)
        myFont = New Font("Verdana", 16, FontStyle.Regular)
        myString = "MC: 61A"
        pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(350, 115), myFont, Color.Black)
        i = i + 1

        ReDim Preserve pgInfo.pgBody(i)
        myFont = New Font("Verdana", 16, FontStyle.Regular)
        myString = "Pkg: " + PackageData.Rows(0)(0)
        pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(550, 115), myFont, Color.Black)
        i = i + 1

        ReDim Preserve pgInfo.pgBody(i)
        pgInfo.pgBody(i) = PrintUtils.MakeLineObject(New Point(myMargin, 145), New Point(850 - myMargin, 145))
        i = i + 1

        ReDim Preserve pgInfo.pgBody(i)
        myFont = New Font("Verdana", 10, FontStyle.Regular)
        myString = "Tag Numbers"
        pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(70, 170), myFont, Color.Black)
        i = i + 1

        Dim yPosition As Integer = 195
        Dim xPosition As Integer = 70
        Dim TagCounter As Integer = 0
        For u As Integer = 0 To TagsData.Rows.Count - 1
            If TagCounter > 5 Then
                yPosition += 25
                xPosition = 70
                TagCounter = 0
            End If

            ReDim Preserve pgInfo.pgBody(i)
            myFont = New Font("Verdana", 9, FontStyle.Regular)
            myString = TagsData.Rows(u)(2)
            pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(xPosition, yPosition), myFont, Color.Blue)
            i = i + 1

            TagCounter += 1
            xPosition = (TagCounter * 130) + 70
        Next

        yPosition += 40

        ReDim Preserve pgInfo.pgBody(i)
        myFont = New Font("Verdana", 10, FontStyle.Regular)
        myString = "1. Pre-Comm Record Report"
        pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(70, yPosition), myFont, Color.Black)
        i = i + 1
        yPosition += 40

        ReDim Preserve pgInfo.pgBody(i)
        myFont = New Font("Verdana", 10, FontStyle.Regular)
        myString = "2. Inspection & Testing Reports"
        pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(70, yPosition), myFont, Color.Black)
        i = i + 1
        'yPosition += 40

        Dim ListNumber As Integer = 3

        xPosition = 70
        TagCounter = 0
        Dim ThisType As String = Nothing

        'For u As Integer = 0 To DocsData.Rows.Count - 1
        For Each dr As DataRow In DocsData.Rows
            If Not ThisType = dr(1) Then
                yPosition += 40
                xPosition = 70
                TagCounter = 0
                ReDim Preserve pgInfo.pgBody(i)
                myFont = New Font("Verdana", 10, FontStyle.Regular)
                myString = ListNumber.ToString + ". " + dr(1)
                pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(xPosition, yPosition), myFont, Color.Black)
                i = i + 1
                yPosition += 30
                ListNumber += 1
            End If

            If TagCounter > 2 Then
                yPosition += 25
                xPosition = 70
                TagCounter = 0
            End If

            ReDim Preserve pgInfo.pgBody(i)
            myFont = New Font("Verdana", 9, FontStyle.Regular)
            myString = dr(2)
            pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(xPosition, yPosition), myFont, Color.Blue)
            i = i + 1

            TagCounter += 1
            xPosition = (TagCounter * 260) + 70

            ThisType = dr(1)
        Next

        yPosition += 40

        ReDim Preserve pgInfo.pgBody(i)
        myFont = New Font("Verdana", 12, FontStyle.Regular)
        myString = "Package Contents Reviewed By:_________________________"
        pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(250, yPosition), myFont, Color.Black)
        i = i + 1
        yPosition += 40

        ReDim Preserve pgInfo.pgBody(i)
        myFont = New Font("Verdana", 12, FontStyle.Regular)
        myString = "Date:_________________________"
        pgInfo.pgBody(i) = PrintUtils.MakeTextObject(myString, New Point(476, yPosition), myFont, Color.Black)
        i = i + 1
        yPosition += 40

        ThisPage.pgInfo = pgInfo
        CustomPages.Add(ThisPage)
    End Sub


    Public Sub AddInfoPages(ByVal StartingPosition As Integer)
        Dim ThisPage As New Pages
        ThisPage.Landscape = False
        ThisPage.PrintHdr = False
        ThisPage.PrintFooter = False

        Dim pgInfo As PrintUtils.InfoSetting = New PrintUtils.InfoSetting
        Dim pgContents As PrintUtils.pgBodyContents = New PrintUtils.pgBodyContents
        Dim PageCenter As Integer
        If ThisPage.Landscape Then PageCenter = 550 Else PageCenter = 425
        Dim myFont As Font
        Dim myString As String
        Dim NumberofRecords As Integer = 3

        Dim ElementCtr As Integer = 0
        Dim yOffset As Integer = 150
        If InfoCoverNeeded Then
            NumberofRecords = 2
            'info header here
            ReDim Preserve pgInfo.pgBody(ElementCtr)
            myFont = New Font("Verdana", 20, FontStyle.Bold)
            myString = "PRE-COMM RECORD"
            pgInfo.pgBody(ElementCtr) = PrintUtils.MakeTextObject(myString, New Point(PageCenter - (FindStringWidth(myString, myFont) / 2), 10), myFont, Color.Black)
            ElementCtr += 1

            ReDim Preserve pgInfo.pgBody(ElementCtr)
            myFont = New Font("Verdana", 16, FontStyle.Bold)
            myString = "PACKAGE COMPLETION REPORT - MODULE"
            pgInfo.pgBody(ElementCtr) = PrintUtils.MakeTextObject(myString, New Point(PageCenter - (FindStringWidth(myString, myFont) / 2), 40), myFont, Color.Black)
            ElementCtr += 1

            'info key here
            Dim thisTag As New precomm_record(0)

            For Each cntl As TextBox In thisTag.Controls
                Dim xPosition As Integer = cntl.Location.X + 30
                Dim yPosition As Integer = cntl.Location.Y + yOffset

                ReDim Preserve pgInfo.pgBody(ElementCtr)
                myFont = New Font("Verdana", 8, FontStyle.Regular)

                myString = cntl.Text
                If FindStringWidth(myString, myFont) > cntl.Width Then
                    myString = myString.Substring(0, Convert.ToInt32(cntl.Width / myFont.Size))
                End If
                pgInfo.pgBody(ElementCtr) = PrintUtils.MakeTextObject(myString, New Point(xPosition, yPosition), myFont, Color.Black)
                ElementCtr += 1

                ReDim Preserve pgInfo.pgBody(ElementCtr)
                Dim rect As New Rectangle(xPosition, yPosition, cntl.Width - 1, cntl.Height - 1)
                pgInfo.pgBody(ElementCtr) = PrintUtils.MakeRectObject(rect)
                ElementCtr += 1
            Next

            InfoCoverNeeded = False
            yOffset += 300
        End If

        For i As Integer = StartingPosition To (StartingPosition + NumberofRecords - 1)
            If i = TagsData.Rows.Count Then
                Exit For
            End If

            Dim thisTag As New precomm_record(TagsData.Rows(i)(0))

            For Each cntl As TextBox In thisTag.Controls
                Dim xPosition As Integer = cntl.Location.X + 30
                Dim yPosition As Integer = cntl.Location.Y + yOffset

                ReDim Preserve pgInfo.pgBody(ElementCtr)
                myFont = New Font("Verdana", 8, FontStyle.Regular)
                myString = cntl.Text
                If FindStringWidth(myString, myFont) > cntl.Width Then
                    myString = myString.Substring(0, Convert.ToInt32(cntl.Width / myFont.Size))
                End If
                pgInfo.pgBody(ElementCtr) = PrintUtils.MakeTextObject(myString, New Point(xPosition, yPosition), myFont, Color.Black)
                ElementCtr += 1

                ReDim Preserve pgInfo.pgBody(ElementCtr)
                Dim rect As New Rectangle(xPosition, yPosition, cntl.Width - 1, cntl.Height - 1)
                pgInfo.pgBody(ElementCtr) = PrintUtils.MakeRectObject(rect)
                ElementCtr += 1
            Next
            yOffset += 300
        Next

        ThisPage.pgInfo = pgInfo
        CustomPages.Add(ThisPage)
    End Sub


    Private Function FindStringWidth(ByVal _String As String, ByVal _Font As Font) As Integer
        Dim txtSize As Size = TextRenderer.MeasureText(_String, _Font)
        Return txtSize.Width
    End Function


    Private Function GetSystemNumber() As String
        Dim qry As String = "SELECT PackageNumber,SystemNumber,Description, " + _
            "GroupMUID,OwnerMUID,DisciplineMUID FROM package WHERE MUID = " + PkgID.ToString

        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(qry)
        sqlPrjUtils.CloseConnection()

        PackageData = dt
        Dim SysID = dt.Rows(0)("SystemNumber")
        Return SystemDataManager.TranslateSystemID(SysID)
    End Function


    Private Function GetTags() As DataTable
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim query As String = "SELECT * FROM tags WHERE PackageMUID='" & PkgID & "'"
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()
        Return dt
    End Function


    Private Function GetDocs() As DataTable
        Dim query As String = "SELECT DocumentMUID FROM package_documents WHERE PackageMUID='" & PkgID & "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        dt.Columns.Add("DocumentType")
        dt.Columns.Add("DocumentNumber")

        Dim badRows As New List(Of DataRow)
        For i As Integer = 0 To dt.Rows.Count - 1
            If GetDocInfo(dt.Rows(i)(0)).Rows.Count > 0 Then
                dt.Rows(i)(1) = GetDocInfo(dt.Rows(i)(0)).Rows(0)(0)
                dt.Rows(i)(2) = GetDocInfo(dt.Rows(i)(0)).Rows(0)(1)
            Else
                badRows.Add(dt.Rows(i))
            End If
        Next

        For Each dr As DataRow In badRows
            dt.Rows.Remove(dr)
        Next

        dt.DefaultView.Sort = "DocumentType Asc"
        Return dt.DefaultView.ToTable()
    End Function


    Private Function GetDocInfo(ByVal _DocID As Integer) As DataTable
        Dim query As String = "SELECT document_type.Description," & _
            " Documents.EngCode FROM  document_type INNER JOIN " & _
            " documents ON document_type.MUID = documents.DocumentTypeMUID" & _
            " WHERE (documents.MUID = '" & _DocID & "')"
        Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
        sqlDocUtils.OpenConnection()
        Dim dt As DataTable = sqlDocUtils.ExecuteQuery(query)
        sqlDocUtils.CloseConnection()

        Return dt
    End Function


End Class
