Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.IO
'Imports System.Data.SqlServerCe
Imports Microsoft.VisualBasic.FileIO
Imports daqartDLL
Imports System.Drawing.Printing
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports System.Security.Permissions

<Assembly: RegistryPermissionAttribute( _
    SecurityAction.RequestMinimum, ViewAndModify:="HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings")> 
'Imports System.Collections
Public Class EditDaqumentUtil
    Public Enum mode
        None
        ObjectSelected
        InsertImage
        EmbedImage
        DragObject
        InsertText
        EmbedText
        Drag
        FreeHand
        lineDraw
        InserWeld
        EmbedWeld
        WeldHeadSelected
        WeldTailSelected
    End Enum

    Public Enum enumWeldStatus
        WeldCreated = 0
        WeldAssignedForWork
        WeldAssignedForInspection
        WeldPassed
        WeldReject
        WeldReassigned
    End Enum
    Public Shared Function enumStatusInt(ByVal st As String) As Integer
        Select Case st
            Case "WeldAssignedForWork"
                Return 1
            Case "WeldAssignedForInspection"
                Return 2
            Case "WeldPassed"
                Return 3
            Case "WeldReject"
                Return 4
            Case "WeldReassigned"
                Return 5
        End Select
        'Case enumWeldStatus.WeldCreated
        Return 0
    End Function
    Public Class WeldStatusColorTranslation
        Public Shared Function GetColor1(ByVal st As enumWeldStatus) As Color
            Select Case st
                Case enumWeldStatus.WeldAssignedForWork
                    Return (Color.Silver)
                Case enumWeldStatus.WeldAssignedForInspection
                    Return (Color.Brown)
                Case enumWeldStatus.WeldPassed
                    Return (Color.Green)
                Case enumWeldStatus.WeldReject
                    Return (Color.Red)
                Case enumWeldStatus.WeldReassigned
                    Return (Color.Orange)
            End Select
            'Case enumWeldStatus.WeldCreated
            Return (Color.MediumBlue)
        End Function
        Public Shared Function GetColor2(ByVal st As enumWeldStatus) As Color
            Select Case st
                Case enumWeldStatus.WeldAssignedForWork
                    Return (Color.Blue)
                Case enumWeldStatus.WeldAssignedForInspection
                    Return (Color.White)
                Case enumWeldStatus.WeldPassed
                    Return (Color.Yellow)
                Case enumWeldStatus.WeldReject
                    Return (Color.Yellow)
                Case enumWeldStatus.WeldReassigned
                    Return (Color.SteelBlue)
            End Select
            'Case enumWeldStatus.WeldCreated
            Return (Color.Yellow)
        End Function
        'Public Shared Function GetStatus(ByVal st As String) As enumWeldStatus
        '    Select Case st
        '        Case "Weld Assigned"
        '            Return enumWeldStatus.WeldAssignedForWork
        '        Case "Weld Inspection"
        '            Return enumWeldStatus.WeldAssignedForInspection
        '        Case "Weld Passed"
        '            Return enumWeldStatus.WeldPassed
        '        Case "Weld Reject"
        '            Return enumWeldStatus.WeldReject
        '        Case "Weld Reassigned"
        '            Return enumWeldStatus.WeldReassigned
        '    End Select
        '    'Case enumWeldStatus.WeldCreated
        '    Return "Weld Created"
        'End Function
        'Public Shared Function GetStatusName(ByVal st As enumWeldStatus) As String
        '    Select Case st
        '        Case enumWeldStatus.WeldAssignedForWork
        '            Return "Weld Assigned"
        '        Case enumWeldStatus.WeldAssignedForInspection
        '            Return "Weld Inspection"
        '        Case enumWeldStatus.WeldPassed
        '            Return "Weld Passed"
        '        Case enumWeldStatus.WeldReject
        '            Return "Weld Reject"
        '        Case enumWeldStatus.WeldReassigned
        '            Return "Weld Reassigned"
        '    End Select
        '    'Case enumWeldStatus.WeldCreated
        '    Return "Weld Created"
        'End Function

    End Class

    'Public Function GetWeldStatusColor()
    '    For Each s As WeldStatusColors In SystemList
    '        If s.Name = SystemName Then
    '            nameExist = True
    '        End If
    '    Next
    'End Function
    'Public WeldStatusColorMap As New List(Of WeldStatusColors)

    'Private connDaqument As SqlCeConnection = daqartDLL.connections.DaqumentConnect(connDaqument)
    '   Private connServer As SqlCeConnection = daqartDLL.connections.serverDBConnect(connServer)
    Private _LayerInfoTbl As DataTable = New DataTable
    Private _SpoolInfoTbl As DataTable = New DataTable
    'Private _imgList As New List(Of Image)
    '    Private _LayerID As New List(Of Integer)
    Private _AllVectors As New List(Of Vector)
    Public LayerVectorArray As New List(Of Vector)
    Public WeldPointInfoTable As DataTable
    Public _DocumentID As String
    Public EngineeringCode As String
    Public Sheet As Integer


    'Private docStore As New DocumentStore
    Private _CurrentImage As Image
    Private OriginalDocImage As Image
    'Public Shared DrawingLayerID As Integer = 0
    Public Structure WeldPoint
        Dim ID As String
        Dim Disc As String
        Dim TagNo As String
        Dim System As String
        Dim Area As String
        Dim DWGNO As String
        Dim TestPkgNo As String
        Dim EnteredBy As String
        Dim DateEntered As String
        Dim SpoolTo As String
        Dim SpoolFrom As String
        Dim PipeSize As String
        Dim ConstCode As String
        Dim WeldInches As String
        Dim ForemanName As String
        Dim SVCSPEC As String
        Dim WPS As String
        Dim NDEPcntReq As String
        Dim Material As String
        Dim WallThk As String
        Dim WeldType As String
        Dim WeldStn As String
        Dim NDEType As String
        Dim DateTested As String
        Dim AdvancedTesting As String
        Dim TestResult As String
        Dim VisInspDate As String
        Dim VisInspName As String
        Dim PMIDate As String
        Dim PMIResult As String
        Dim RejInches As String
        Dim PWHT As String
        Dim BHN As String
        Dim Comments As String
        Dim Revision As String
        Dim WeldStatus As Integer
        Dim DrawingID As String
        Dim Aux05 As Integer ' use it as a temporary link to vector
    End Structure

    Public Structure Vector
        Dim vectorID As String
        Dim seqNumber As Integer
        Dim itmSelected As Boolean
        Dim newObjectFlag As Boolean
        Dim tBox As TextBox
        Dim pBox As PictureBox
        Dim ObjectDeleted As Boolean
        Dim VectorObjectType As String
        Dim OrgScaleX As Single
        Dim OrgScaleY As Single
        Dim DrawingID As String
        Dim VectorType As Integer
        Dim StartPointX As Integer
        Dim StartPointY As Integer
        Dim endPointX As Integer
        Dim endPointY As Integer
        Dim OrgStartPointX As Integer
        Dim OrgStartPointY As Integer
        Dim OrgEndPointX As Integer
        Dim OrgEndPointY As Integer
        Dim OrgLineWidth As Integer
        Dim ScaledLineWidth As Integer
        Dim lineEnd As Integer
        Dim penArgb As Integer
        '        Dim Opaque As Integer
        Dim VectorImage As Image
        Dim text As String
        Dim fontfamily As String
        Dim fontsize As Integer
        Dim fontforecolor As Integer
        Dim fontbackcolor As Integer
        Dim layerID As String
        Dim CabinetID As String
        Dim layerRevDate As Date
        Dim lastUser As String
        Dim layerStatus As Integer
        Dim DateCreated As Date
        Dim layerDescription As String
        Dim layerTitle As String
        Dim ObjectMode As String
        Dim VectorModified As Boolean
        Dim SQLID As String
    End Structure


    Public Sub New(ByVal DocumentID As String)
        _DocumentID = DocumentID
        '        connProject.Open()
        '       connServer.Open()
        'connDaqument.Open()
        Dim query As String = "select * from document_store  where DocumentMUID = '" + _DocumentID + "'"
        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument001")
        'sqlDocUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLDaqument001.ExecuteQuery(query)

        'sqlDocUtils.CloseConnection()


        'Dim sqlDocument As DataUtils = New DataUtils("Daqument")
        'sqlDocument.OpenConnection()

        query = "select * from documents where MUID = '" + _DocumentID + "'"
        Dim dt_Info As DataTable = runtime.SQLDaqument.ExecuteQuery(query)
        If dt_Info.Rows.Count > 0 Then
            Me.EngineeringCode = dt_Info.Rows(0)(2)
            Me.Sheet = dt_Info.Rows(0)(7)
        End If
        'sqlDocument.CloseConnection()




        If dt.Rows.Count = 0 Then Return
        Dim imagedata() As Byte
        Dim imageBytedata As MemoryStream
        imagedata = dt.Rows(0)("DocumentImage")
        imageBytedata = New MemoryStream(imagedata)
        OriginalDocImage = Image.FromStream(imageBytedata)

        'docStore.DocumentImage = MakeTransparent(docStore.DocumentImage)
        ReLoadBaseImage()
        InitializeWeldPointInfo()
    End Sub


    Private Sub InitializeWeldPointInfo()
        If Not WeldPointInfoTable Is Nothing Then
            WeldPointInfoTable.Dispose()
        End If
        Dim tmpVector As Vector = New Vector
        tmpVector.DrawingID = 0
        tmpVector.text = ""
        'this will give us an empty vector info table
        AddToWeldPointInfoTable(tmpVector)
        'WeldStatusColorMap.Add(New WeldStatusColors(enumWeldStatus.WeldCreated, "Weld Created", Color.Blue, Color.Aqua))
        'WeldStatusColorMap.Add(New WeldStatusColors(enumWeldStatus.WeldAssignedForWork, "Weld Assigned", Color.Yellow, Color.YellowGreen))
        'WeldStatusColorMap.Add(New WeldStatusColors(enumWeldStatus.WeldAssignedForInspection, "Weld Inspection", Color.Brown, Color.Beige))
        'WeldStatusColorMap.Add(New WeldStatusColors(enumWeldStatus.WeldReject, "Weld Reject", Color.Red, Color.RosyBrown))
        'WeldStatusColorMap.Add(New WeldStatusColors(enumWeldStatus.WeldReassigned, "Weld Reassigned", Color.Orange, Color.OrangeRed))
        'WeldStatusColorMap.Add(New WeldStatusColors(enumWeldStatus.WeldPassed, "Weld Passed", Color.Green, Color.GreenYellow))

    End Sub

    Public Function AddToWeldPointInfoTable(ByVal thisVector As Vector) As String
        Dim retStr = ""
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Try

            Dim qry As String = " SELECT " + _
                    "MUID" + "," + _
                    "TagNo" + "," + _
                    "WeldStatus" + "," + _
                    "SystemMUID" + "," + _
                    "Area" + "," + _
                    "DWGNO" + "," + _
                    "TestPkgNo" + "," + _
                    "EnteredBy" + "," + _
                    "DateEntered" + "," + _
                    "SpoolTo" + "," + _
                    "SpoolFrom" + "," + _
                    "PipeSize" + "," + _
                    "ConstCode" + "," + _
                    "WeldInches" + "," + _
                    "ForemanName" + "," + _
                    "SVCSPEC" + "," + _
                    "WPS" + "," + _
                    "NDEPcntReq" + "," + _
                    "Material" + "," + _
                    "WallThk" + "," + _
                    "WeldType" + "," + _
                    "WeldStn" + "," + _
                    "NDEType" + "," + _
                    "DateTested" + "," + _
                    "AdvancedTesting" + "," + _
                    "TestResult" + "," + _
                    "VisInspDate" + "," + _
                    "VisInspName" + "," + _
                    "PMIDate" + "," + _
                    "PMIResult" + "," + _
                    "RejInches" + "," + _
                    "PWHT" + "," + _
                    "BHN" + "," + _
                    "Comments" + "," + _
                    "Revision" + "," + _
                    "DrawingMUID" + "," + _
                    "Disc" + "," + _
                    "VectorLink" + _
                    " FROM tblWeldTracking WHERE DrawingMUID ='" + _
                       thisVector.DrawingID.ToString + "'"
            If thisVector.DrawingID = "0" Then
                If Not WeldPointInfoTable Is Nothing Then
                    WeldPointInfoTable.Dispose()
                End If
                qry = qry + " AND TagNo ='" + thisVector.text + "'"
                'Make a new initialized WeldPointInfoTable with no row
                'WeldPointInfoTable = Utilities.ExecuteQuery(qry, "project")
                WeldPointInfoTable = runtime.SQLProject.ExecuteQuery(qry)

            Else
                If thisVector.text > "" Then
                    'Get Data Row from the DataBase
                    qry = qry + " AND TagNo ='" + thisVector.text + "'"

                    Dim dr As DataRow = runtime.SQLProject.ExecuteQuery(qry).Rows(0)
                    Dim wdr As DataRow = WeldPointInfoTable.NewRow
                    For i As Integer = 0 To WeldPointInfoTable.Columns.Count - 1
                        wdr(i) = dr(i)
                    Next
                    WeldPointInfoTable.Rows.Add(wdr)
                    retStr = dr("TagNo")
                Else
                    'Get Data Row from registry for new weld
                    Dim dr As DataRow = GetDefaultWeldPointRowFromRegistry()
                    dr("DrawingMUID") = thisVector.DrawingID
                    dr("DWGNO") = DocumentName()
                    dr("VectorLink") = ""
                    WeldPointInfoTable.Rows.Add(dr)
                    retStr = dr("TagNo")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to add Weld Point info:")
        End Try
        'sqlPrjUtils.CloseConnection()
        Return retStr
    End Function


    Public ReadOnly Property AllVectors() As List(Of Vector)
        Get
            Return _AllVectors
        End Get
    End Property

    Public ReadOnly Property CurrentImage() As Image
        Get
            Return _CurrentImage
        End Get
    End Property
    Public ReadOnly Property OriginalDrawingSize() As Size
        Get
            Return OriginalDocImage.Size
        End Get
    End Property

    Public Class VectorMap
        Dim _Vector As Vector
        Public Sub New(ByVal myVector As Vector)
            _Vector = myVector
        End Sub
        Public Property seqNumber() As Integer
            Get
                Return _Vector.seqNumber
            End Get
            Set(ByVal Val As Integer)
                _Vector.seqNumber = Val
            End Set
        End Property
        Public Property vectorID() As Integer
            Get
                Return _Vector.vectorID
            End Get
            Set(ByVal Val As Integer)
                _Vector.vectorID = Val
            End Set
        End Property
        Public Property OrgScaleX() As Single
            Get
                Return _Vector.OrgScaleX
            End Get
            Set(ByVal Val As Single)
                _Vector.OrgScaleX = Val
            End Set
        End Property
        Public Property OrgScaleY() As Single
            Get
                Return _Vector.OrgScaleY
            End Get
            Set(ByVal Val As Single)
                _Vector.OrgScaleY = Val
            End Set
        End Property
        Public Property ObjectDeleted() As Boolean
            Get
                Return _Vector.ObjectDeleted
            End Get
            Set(ByVal Val As Boolean)
                _Vector.ObjectDeleted = Val
            End Set
        End Property
        Public Property NewObjectFlag() As Boolean
            Get
                Return _Vector.newObjectFlag
            End Get
            Set(ByVal Val As Boolean)
                _Vector.newObjectFlag = Val
            End Set
        End Property
        Public Property VectorModified() As Boolean
            Get
                Return _Vector.VectorModified
            End Get
            Set(ByVal Val As Boolean)
                _Vector.VectorModified = Val
            End Set
        End Property
        Public ReadOnly Property thisVector() As Vector
            Get
                Return _Vector
            End Get
        End Property
        Public ReadOnly Property VectorCopy(ByVal vec As Vector) As Vector
            Get
                Dim vect As Vector = New Vector
                vect = vec
                Return vect
            End Get
        End Property

        Public Property itmSelected() As Boolean
            Get
                Return _Vector.itmSelected
            End Get
            Set(ByVal Val As Boolean)
                _Vector.itmSelected = Val
            End Set
        End Property
        Public Property tBox() As TextBox
            Get
                Return _Vector.tBox
            End Get
            Set(ByVal Val As TextBox)
                _Vector.tBox = Val
            End Set
        End Property
        Public Property pBox() As PictureBox
            Get
                Return _Vector.pBox
            End Get
            Set(ByVal Val As PictureBox)
                _Vector.pBox = Val
            End Set
        End Property
        Public Property VectorObjectType() As String
            Get
                Return _Vector.VectorObjectType
            End Get
            Set(ByVal Val As String)
                _Vector.VectorObjectType = Val
            End Set
        End Property
        Public Property DrawingID() As String
            Get
                Return _Vector.DrawingID
            End Get
            Set(ByVal Val As String)
                _Vector.DrawingID = Val
            End Set
        End Property
        Public Property VectorType() As Integer
            Get
                Return _Vector.VectorType
            End Get
            Set(ByVal Val As Integer)
                _Vector.VectorType = Val
            End Set
        End Property
        Public Property StartPointX() As Integer
            Get
                Return _Vector.StartPointX
            End Get
            Set(ByVal Val As Integer)
                _Vector.StartPointX = Val
            End Set
        End Property
        Public Property StartPointY() As Integer
            Get
                Return _Vector.StartPointY
            End Get
            Set(ByVal Val As Integer)
                _Vector.StartPointY = Val
            End Set
        End Property
        Public Property endPointX() As Integer
            Get
                Return _Vector.endPointX
            End Get
            Set(ByVal Val As Integer)
                _Vector.endPointX = Val
            End Set
        End Property
        Public Property endPointY() As Integer
            Get
                Return _Vector.endPointY
            End Get
            Set(ByVal Val As Integer)
                _Vector.endPointY = Val
            End Set
        End Property
        Public Property OrgStartPointX() As Integer
            Get
                Return _Vector.OrgStartPointX
            End Get
            Set(ByVal Val As Integer)
                _Vector.OrgStartPointX = Val
            End Set
        End Property
        Public Property OrgStartPointY() As Integer
            Get
                Return _Vector.OrgStartPointY
            End Get
            Set(ByVal Val As Integer)
                _Vector.OrgStartPointY = Val
            End Set
        End Property
        Public Property OrgEndPointX() As Integer
            Get
                Return _Vector.OrgEndPointX
            End Get
            Set(ByVal Val As Integer)
                _Vector.OrgEndPointX = Val
            End Set
        End Property
        Public Property OrgEndPointY() As Integer
            Get
                Return _Vector.OrgEndPointY
            End Get
            Set(ByVal Val As Integer)
                _Vector.OrgEndPointY = Val
            End Set
        End Property
        Public Property OrgLineWidth() As Integer
            Get
                Return _Vector.OrgLineWidth
            End Get
            Set(ByVal Val As Integer)
                _Vector.OrgLineWidth = Val
            End Set
        End Property
        Public Property ScaledlineWidth() As Integer
            Get
                Return _Vector.ScaledLineWidth
            End Get
            Set(ByVal Val As Integer)
                _Vector.ScaledLineWidth = Val
            End Set
        End Property
        Public Property lineEnd() As Integer
            Get
                Return _Vector.lineEnd
            End Get
            Set(ByVal Val As Integer)
                _Vector.lineEnd = Val
            End Set
        End Property
        Public Property penArgb() As Integer
            Get
                Return _Vector.penArgb
            End Get
            Set(ByVal Val As Integer)
                _Vector.penArgb = Val
            End Set
        End Property
        Public Property vectorImage() As Image
            Get
                Return _Vector.VectorImage
            End Get
            Set(ByVal Val As Image)
                _Vector.VectorImage = Val
            End Set
        End Property

        Public Property text() As String
            Get
                Return _Vector.text
            End Get
            Set(ByVal value As String)
                _Vector.text = value
            End Set
        End Property
        Public Property fontFamily() As String
            Get
                Return _Vector.fontfamily
            End Get
            Set(ByVal value As String)
                _Vector.fontfamily = value
            End Set
        End Property
        Public Property CabinetID() As String
            Get
                Return _Vector.CabinetID
            End Get
            Set(ByVal value As String)
                _Vector.CabinetID = value
            End Set
        End Property
        Public Property fontSize() As Integer
            Get
                Return _Vector.fontsize
            End Get
            Set(ByVal value As Integer)
                _Vector.fontsize = value
            End Set
        End Property
        Public Property fontforecolor() As Integer
            Get
                Return _Vector.fontforecolor
            End Get
            Set(ByVal value As Integer)
                _Vector.fontforecolor = value
            End Set
        End Property
        Public Property fontbackcolor() As Integer
            Get
                Return _Vector.fontbackcolor
            End Get
            Set(ByVal value As Integer)
                _Vector.fontbackcolor = value
            End Set
        End Property
        Public Property layerID() As String
            Get
                Return _Vector.layerID
            End Get
            Set(ByVal value As String)
                _Vector.layerID = value
            End Set
        End Property
        Public Property layerRevDate() As Date
            Get
                Return _Vector.DateCreated
            End Get
            Set(ByVal value As Date)
                _Vector.DateCreated = value
            End Set
        End Property
        Public Property lastUser() As String
            Get
                Return _Vector.lastUser
            End Get
            Set(ByVal value As String)
                _Vector.lastUser = value
            End Set
        End Property
        Public Property layerStatus() As Integer
            Get
                Return _Vector.layerStatus
            End Get
            Set(ByVal value As Integer)
                _Vector.layerStatus = value
            End Set
        End Property
        Public Property layerDescription() As String
            Get
                Return _Vector.layerDescription
            End Get
            Set(ByVal value As String)
                _Vector.layerDescription = value
            End Set
        End Property
        Public Property DateCreated() As Date
            Get
                Return _Vector.DateCreated
            End Get
            Set(ByVal value As Date)
                _Vector.DateCreated = value
            End Set
        End Property
        Public Property ObjectMode() As String
            Get
                Return _Vector.ObjectMode
            End Get
            Set(ByVal value As String)
                _Vector.ObjectMode = value
            End Set
        End Property
        Public Property SQLID() As String
            Get
                Return _Vector.SQLID
            End Get
            Set(ByVal value As String)
                _Vector.SQLID = value
            End Set
        End Property
    End Class


    Public Function CheckTitle(ByVal title As String) As Boolean
        Dim qry = "SELECT LayerTitle FROM drawing_layers WHERE(DrawingMUID = '" + _DocumentID.ToString + "' AND LayerTitle = '" + title + "')"
        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        'sqlDocUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(qry)
        'sqlDocUtils.CloseConnection()

        'If (Utilities.ExecuteQuery(qry, "Daqument")).Rows.Count > 0 Then
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Sub ReLoadBaseImage()
        If Not _CurrentImage Is Nothing Then
            _CurrentImage.Dispose()
        End If
        _CurrentImage = OriginalDocImage.Clone
    End Sub


    Public Sub SaveDocumentImage()
        Dim dr As String = runtime.AbsolutePath + "sites\tmp.png"
        File.Delete(dr)
        OriginalDocImage.Save(dr, System.Drawing.Imaging.ImageFormat.Png)
    End Sub

    Public Function OriginalDocumentImage() As Image
        If OriginalDocImage Is Nothing Then Return Nothing
        Return (OriginalDocImage)
    End Function

    Public Function IsWeldInfoEntryModified(ByVal odr As DataRow, ByVal ndr As DataRow)
        For j As Integer = 0 To WeldPointInfoTable.Columns.Count - 1
            If odr(j) <> ndr(j) Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Function DocumentImageAvailable() As Boolean
        If OriginalDocImage Is Nothing Then Return False
        Return True
    End Function

    '    Public Function GetWeldProperty(ByVal TagNo As String) As DataTable
    '        Dim dt As DataTable = 
    '        For i As Integer = 0 To WeldPointInfoTable.Rows.Count - 1
    '            If WeldPointInfoTable.Rows(i)("TagNo") <> TagNo Then
    'WeldPointInfoTable.Rows(i).
    '                Dim dr As DataRow = WeldPointInfoTable.Rows(i)
    '                Return dr
    '                Exit For
    '            End If
    '        Next
    '        Return Nothing
    '    End Function
    Public Function GetWeldPointColor1(ByVal TagNo As String) As Color

        For i As Integer = 0 To WeldPointInfoTable.Rows.Count - 1
            If WeldPointInfoTable.Rows(i)("TagNo") = TagNo Then
                'Dim st As enumWeldStatus = WeldPointInfoTable.Rows(i)("WeldStatus")
                Dim w As Integer = WeldPointInfoTable.Rows(i)("WeldStatus")
                'If WeldPointInfoTable.Rows(i)("WeldStatus") > "" Then
                '    Try
                '        Dim st As Integer = enumStatusInt((WeldPointInfoTable.Rows(i)("WeldStatus")))

                '        Return WeldStatusColorTranslation.GetColor1(st)
                '    Catch ex As Exception

                '    End Try

                'End If
                Return WeldStatusColorTranslation.GetColor1(w)
            End If
        Next
        Return WeldStatusColorTranslation.GetColor1(enumWeldStatus.WeldCreated)
    End Function
    Public Function GetWeldPointColor2(ByVal TagNo As String) As Color
        For i As Integer = 0 To WeldPointInfoTable.Rows.Count - 1
            If WeldPointInfoTable.Rows(i)("TagNo") = TagNo Then
                'Dim st As Integer = enumStatusInt((WeldPointInfoTable.Rows(i)("WeldStatus")))
                Dim w As Integer = WeldPointInfoTable.Rows(i)("WeldStatus")
                Return WeldStatusColorTranslation.GetColor2(w)
            End If
        Next
        Return WeldStatusColorTranslation.GetColor1(enumWeldStatus.WeldCreated)
    End Function
    Public Function GetWeldPropertyTable(ByVal TagNo As String) As DataTable
        Dim dt As DataTable = WeldPointInfoTable.Clone
        For i As Integer = 0 To WeldPointInfoTable.Rows.Count - 1
            If WeldPointInfoTable.Rows(i)("TagNo") = TagNo Then
                Dim dr As DataRow = dt.NewRow
                For j As Integer = 0 To WeldPointInfoTable.Columns.Count - 1
                    dr(j) = WeldPointInfoTable.Rows(i)(j)
                Next
                dt.Rows.Add(dr)
                Return dt


                'For j As Integer = 0 To WeldPointInfoTable.Columns.Count - 1
                '    If WeldPointInfoTable.Columns(j).ColumnName = "WeldStatus" Then
                '        dt.Columns.Add(New DataColumn(WeldPointInfoTable.Columns(j).ColumnName, _
                '            System.Type.GetType("System.String")))
                '    Else
                '        dt.Columns.Add(New DataColumn(WeldPointInfoTable.Columns(j).ColumnName, _
                '            WeldPointInfoTable.Columns(j).DataType))
                '    End If

                'Next

                'Dim dr As DataRow = dt.NewRow
                'For j As Integer = 0 To WeldPointInfoTable.Columns.Count - 1
                '    If WeldPointInfoTable.Columns(j).ColumnName = "WeldStatus" Then
                '        dr(j) = WeldStatusColorMap(0).ToString 'WeldCreated
                '        For Each s As WeldStatusColors In WeldStatusColorMap
                '            If s.st = enumWeldStatus.WeldCreated Then
                '                dr(j) = s.ToString
                '                Exit For
                '            End If
                '        Next
                '    Else
                '        dr(j) = WeldPointInfoTable.Rows(i)(j)
                '    End If
                'Next
                'dt.Rows.Add(dr)
                'Return dt
            End If
        Next
        Return Nothing
    End Function
    Public Function DocumentName() As String
        Dim qry = "SELECT EngCode FROM documents WHERE MUID = '" + _DocumentID + "'"
        'Dim myTbl As DataTable = Utilities.ExecuteQuery(qry, "Daqument")
        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        'sqlDocUtils.OpenConnection()
        Dim myTbl As DataTable = runtime.SQLDaqument.ExecuteQuery(qry)
        'sqlDocUtils.CloseConnection()
        If Not myTbl Is Nothing Then
            If myTbl.Rows.Count > 0 Then
                Return myTbl.Rows(0)("EngCode").ToString
            End If
        End If
        Return ("")
    End Function
    Public Function GetBlankWeldPointParametersDataRow() As DataRow
        Dim defaultWeldRow As DataRow = WeldPointInfoTable.NewRow

        defaultWeldRow("Disc") = "Weld"
        defaultWeldRow("AdvancedTesting") = ""
        defaultWeldRow("Area") = ""
        defaultWeldRow("BHN") = ""
        defaultWeldRow("TagNo") = ""
        defaultWeldRow("SystemMUID") = ""
        'defaultWeldRow("DWGNO") = ""
        'defaultWeldRow("DrawingID") = ""
        'defaultWeldRow("TestPkgNo") = ""
        defaultWeldRow("EnteredBy") = ""
        'defaultWeldRow("DateEntered") = ""
        defaultWeldRow("SpoolTo") = ""
        defaultWeldRow("SpoolFrom") = ""
        defaultWeldRow("PipeSize") = ""
        defaultWeldRow("ConstCode") = ""
        defaultWeldRow("WeldInches") = ""
        defaultWeldRow("ForemanName") = ""
        defaultWeldRow("SVCSPEC") = ""
        defaultWeldRow("WPS") = ""
        defaultWeldRow("NDEPcntReq") = ""
        defaultWeldRow("Material") = ""
        defaultWeldRow("WallThk") = ""
        defaultWeldRow("WeldType") = ""
        defaultWeldRow("WeldStn") = ""
        defaultWeldRow("NDEType") = ""
        'defaultWeldRow("DateTested") = ""
        defaultWeldRow("TestResult") = ""
        'defaultWeldRow("VisInspDate") = ""
        defaultWeldRow("VisInspName") = ""
        'defaultWeldRow("PMIDate") = ""
        defaultWeldRow("PMIResult") = ""
        defaultWeldRow("RejInches") = ""
        defaultWeldRow("PWHT") = ""
        defaultWeldRow("BHN") = ""
        defaultWeldRow("Comments") = ""
        defaultWeldRow("Revision") = ""
        'defaultWeldRow("ID") = ""

        Return defaultWeldRow
    End Function
    Public Sub SetDefaultWeldPointRegistryValues(ByVal dr As DataRow)
        Dim regKey As String = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings\DefaultWeldParameters"
        Registry.SetValue(regKey, "Disc", "Weld", RegistryValueKind.String)
        Registry.SetValue(regKey, "AdvancedTesting", dr("AdvancedTesting").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "Area", dr("Area").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "BHN", dr("BHN").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "TagNo", dr("TagNo").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "SystemMUID", "", RegistryValueKind.String)
        'Registry.SetValue(regKey, "DWGNO", "", RegistryValueKind.String)
        'Registry.SetValue(regKey, "DrawingID", "", RegistryValueKind.String)
        Registry.SetValue(regKey, "TestPkgNo", "", RegistryValueKind.String)
        Registry.SetValue(regKey, "EnteredBy", dr("EnteredBy").ToString, RegistryValueKind.String)
        'Registry.SetValue(regKey, "DateEntered", "", RegistryValueKind.String)
        Registry.SetValue(regKey, "SpoolTo", dr("SpoolTo").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "SpoolFrom", dr("SpoolFrom").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "PipeSize", dr("PipeSize").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "ConstCode", dr("ConstCode").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "WeldInches", dr("WeldInches").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "ForemanName", dr("ForemanName").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "SVCSPEC", dr("SVCSPEC").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "WPS", dr("WPS").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "NDEPcntReq", dr("NDEPcntReq").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "Material", dr("Material").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "WallThk", dr("WallThk").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "WeldType", dr("WeldType").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "WeldStn", dr("WeldStn").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "NDEType", dr("NDEType").ToString, RegistryValueKind.String)
        'Registry.SetValue(regKey, "DateTested", "", RegistryValueKind.String)
        Registry.SetValue(regKey, "TestResult", "", RegistryValueKind.String)
        'Registry.SetValue(regKey, "VisInspDate", "", RegistryValueKind.String)
        Registry.SetValue(regKey, "VisInspName", dr("VisInspName").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "PMIDate", "", RegistryValueKind.String)
        Registry.SetValue(regKey, "PMIResult", "", RegistryValueKind.String)
        Registry.SetValue(regKey, "RejInches", "", RegistryValueKind.String)
        Registry.SetValue(regKey, "PWHT", dr("PWHT").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "BHN", dr("BHN").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "Comments", dr("Comments").ToString, RegistryValueKind.String)
        Registry.SetValue(regKey, "Revision", "", RegistryValueKind.String)
        'Registry.SetValue(regKey, "ID", "", RegistryValueKind.String)
    End Sub
    Private Function GetNextAvaialbleTagNo() As String

        'Dim Daqument001 As New DataUtils("Daqument001")
        Dim query As String = "SELECT MAX(CONVERT(numeric,Text)) AS Expr1  FROM drawing_objects WHERE VectorObjectType='Weld'"

        'Daqument001.OpenConnection()
        Dim dt As DataTable = runtime.SQLDaqument001.ExecuteQuery(query)
        'Daqument001.CloseConnection()

        Dim newTag As Integer = 1
        If dt.Rows.Count > 0 Then
            'If WeldPointInfoTable.Rows.Count = 0 Then
            newTag = dt.Rows(0)(0) + 1
            'Else
            'newTag = dt.Rows(0)(0)
            'End If
        End If


        Dim Match As Boolean
        Dim noMatchCtr As Integer = newTag
        If noMatchCtr = 1 Then Return noMatchCtr.ToString
        Do
            Match = False
            For i As Integer = 0 To WeldPointInfoTable.Rows.Count - 1
                If WeldPointInfoTable.Rows(i)("TagNo") = noMatchCtr.ToString Then
                    noMatchCtr = noMatchCtr + 1
                    Match = True
                    Exit For
                End If
            Next
        Loop While Match
        Return noMatchCtr.ToString


    End Function


    Public Function GetDefaultWeldPointInfoTable() As DataTable
        Dim dt As DataTable = WeldPointInfoTable.Clone
        Dim ndr As DataRow = dt.NewRow
        Dim odr As DataRow = GetDefaultWeldPointRowFromRegistry()
        For i As Integer = 0 To odr.Table.Columns.Count - 1
            ndr(i) = odr(i)
        Next
        dt.Rows.Add(ndr)
        Return dt
    End Function
    Public Function GetDefaultWeldPointRowFromRegistry() As DataRow
        Dim regKey As String
        regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings\DefaultWeldParameters"
        Dim regValue = Registry.GetValue(regKey, "Version", Nothing)

        If regValue Is Nothing Then

            'Registry.LocalMachine.CreateSubKey(regKey)
            Dim test9999 As RegistryKey = _
            Registry.CurrentUser.CreateSubKey("DefaultWeldParameters")

            Dim blankdr As DataRow = GetBlankWeldPointParametersDataRow()
            SetDefaultWeldPointRegistryValues(blankdr)
        End If

        Dim dr As DataRow = WeldPointInfoTable.NewRow
        dr("Disc") = Registry.GetValue(regKey, "Disc", Nothing)
        dr("AdvancedTesting") = Registry.GetValue(regKey, "AdvancedTesting", Nothing)
        dr("Area") = Registry.GetValue(regKey, "Area", Nothing)
        dr("BHN") = Registry.GetValue(regKey, "BHN", Nothing)
        dr("TagNo") = GetNextAvaialbleTagNo() 'Registry.GetValue(regKey, "TagNo", Nothing)
        dr("SystemMUID") = "" 'Registry.GetValue(regKey, "System", "", Nothing)
        'dr("DWGNO") = DocumentName() 'Registry.GetValue(regKey, "DWGNO", "", Nothing)
        'dr("DrawingID") = "" 'Registry.GetValue(regKey, "DrawingID", Nothing)
        dr("TestPkgNo") = "" 'Registry.GetValue(regKey, "TestPkgNo", Nothing)
        dr("EnteredBy") = Utilities.GetUserName(runtime.UserMUID) 'Registry.GetValue(regKey, "EnteredBy", Nothing)
        'dr("DateEntered") = DateTime.Now.ToShortDateString 'Registry.GetValue(regKey, "DateEntered", Nothing)
        dr("SpoolTo") = Registry.GetValue(regKey, "SpoolTo", Nothing)
        dr("SpoolFrom") = Registry.GetValue(regKey, "SpoolFrom", Nothing)
        dr("PipeSize") = Registry.GetValue(regKey, "PipeSize", Nothing)
        dr("ConstCode") = Registry.GetValue(regKey, "ConstCode", Nothing)
        dr("WeldInches") = Registry.GetValue(regKey, "WeldInches", Nothing)
        dr("ForemanName") = Registry.GetValue(regKey, "ForemanName", Nothing)
        dr("SVCSPEC") = Registry.GetValue(regKey, "SVCSPEC", Nothing)
        dr("WPS") = Registry.GetValue(regKey, "WPS", Nothing)
        dr("NDEPcntReq") = Registry.GetValue(regKey, "NDEPcntReq", Nothing)
        dr("Material") = Registry.GetValue(regKey, "Material", Nothing)
        dr("WallThk") = Registry.GetValue(regKey, "WallThk", Nothing)
        dr("WeldType") = Registry.GetValue(regKey, "WeldType", Nothing)
        dr("WeldStn") = Registry.GetValue(regKey, "WeldStn", Nothing)
        dr("NDEType") = Registry.GetValue(regKey, "NDEType", Nothing)
        'dr("DateTested") = "" 'Registry.GetValue(regKey, "DateTested", "", Nothing)
        dr("TestResult") = "" 'Registry.GetValue(regKey, "TestResult", "", Nothing)
        'dr("VisInspDate") = "" 'Registry.GetValue(regKey, "VisInspDate", "", Nothing)
        dr("VisInspName") = Registry.GetValue(regKey, "VisInspName", Nothing)
        'dr("PMIDate") = Registry.GetValue(regKey, "PMIDate", Nothing)
        dr("PMIResult") = "" 'Registry.GetValue(regKey, "PMIResult", "", Nothing)
        dr("RejInches") = "" 'Registry.GetValue(regKey, "RejInches", "", Nothing)
        dr("PWHT") = Registry.GetValue(regKey, "PWHT", Nothing)
        dr("BHN") = Registry.GetValue(regKey, "BHN", Nothing)
        dr("Comments") = Registry.GetValue(regKey, "Comments", Nothing)
        dr("Revision") = Registry.GetValue(regKey, "Revision", Nothing)
        dr("WeldStatus") = 0 ' enumWeldStatus.WeldCreated     'Registry.GetValue(regKey, "Revision", Nothing)

        dr("MUID") = 0 'Registry.GetValue(regKey, "ID", Nothing)
        Return dr
    End Function
    'Private Sub CreateWeldPointRegistryValues()
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\Disc")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\AdvancedTesting")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\Area")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\BHN")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\TagNo")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\System")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\DWGNO")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\DrawingID")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\TestPkgNo")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\EnteredBy")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\DateEntered")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\SpoolTo")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\SpoolFrom")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\PipeSize")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\ConstCode")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\WeldInches")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\ForemanName")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\SVCSPEC")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\WPS")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\NDEPcntReq")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\Material")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\WallThk")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\WeldType")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\WeldStn")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\NDEType")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\DateTested")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\TestResult")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\VisInspDate")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\VisInspName")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\PMIDate")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\PMIResult")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\RejInches")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\PWHT")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\BHN")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\Comments")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\Revision")
    '    'Registry.LocalMachine.CreateSubKey(regKey + "\ID")
    'End Sub


    Public Sub LoadLayerVectors(ByVal LayerID As String)
        For Each vec As Vector In LayerVectorArray
            If Not vec.VectorImage Is Nothing Then
                vec.VectorImage.Dispose()
            End If
            If Not vec.pBox Is Nothing Then
                vec.pBox.Image.Dispose()
            End If
        Next
        LayerVectorArray.Clear()
        Dim qry = "SELECT Cabinet FROM drawing_layers WHERE(DrawingMUID = '" + _DocumentID.ToString + "'" + _
                    " AND MUID ='" + LayerID.ToString + "')"
        'Dim myTbl As DataTable = Utilities.ExecuteQuery(qry, "Daqument")
        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        'sqlDocUtils.OpenConnection()
        Dim myTbl As DataTable = runtime.SQLDaqument.ExecuteQuery(qry)
        'Dim sqlCabinetUtils As DataUtils = New DataUtils("Daqument001")
        'sqlCabinetUtils.OpenConnection()

        If myTbl.Rows.Count > 0 Then
            Dim cabinetID As String = myTbl.Rows(0)(0)
            'Dim connCabinet As SqlCeConnection = daqartDLL.connections.DaqumentStorageConnect(connCabinet, cabinetID)
            qry = "SELECT * From drawing_objects WHERE layerMUID = '" + LayerID.ToString + "'" + _
                        " AND DocumentMUID = '" + _DocumentID.ToString + "'"

            'Dim myAdapter As SqlCeDataAdapter = New SqlCeDataAdapter(qry, connCabinet)

            'Dim table As New System.Data.DataTable
            'table.Locale = System.Globalization.CultureInfo.InvariantCulture
            'myAdapter.Fill(table)
            Dim table As DataTable = runtime.SQLDaqument001.ExecuteQuery(qry)


            'qry = "DELETE From drawing_objects WHERE DrawingID = " + _DocumentID.ToString + " And Aux01 = 'Weld'"
            For i As Integer = 0 To table.Rows.Count - 1
                Dim myVector As Vector = New Vector
                myVector.SQLID = table.Rows(i)("MUID")
                myVector.DrawingID = table.Rows(i)("DocumentMUID")
                myVector.layerID = table.Rows(i)("layerMUID")
                myVector.VectorType = table.Rows(i)("VectorType")
                myVector.OrgStartPointX = table.Rows(i)("StartPointX")
                myVector.OrgStartPointY = table.Rows(i)("StartPointY")
                myVector.OrgEndPointX = table.Rows(i)("endPointX")
                myVector.OrgEndPointY = table.Rows(i)("endPointY")
                myVector.OrgLineWidth = table.Rows(i)("lineWidth")
                myVector.lineEnd = table.Rows(i)("lineend")
                myVector.penArgb = table.Rows(i)("penArgb")
                'myVector.Visibility = table.Rows(i)(11)
                myVector.VectorObjectType = table.Rows(i)("VectorObjectType") 'Vector Object Type
                If myVector.VectorObjectType = "Pic" Then
                    If (Not table.Rows(i)("VectorImage") Is Nothing) Then
                        Dim buffer() As Byte = table.Rows(i)("VectorImage")
                        Dim m As New MemoryStream(buffer)
                        Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(m)
                        'Image.Save("C:\tmp\ashttt.png")
                        Image.Save(m, ImageFormat.Png)
                        myVector.VectorImage = Image
                    End If
                End If
                myVector.text = table.Rows(i)("Text").ToString
                If myVector.VectorObjectType = "Text" Then
                    If ((table.Rows(i)(13)).ToString > "") Then
                        myVector.fontfamily = table.Rows(i)("fontFamily")
                        myVector.fontsize = table.Rows(i)("fontSize")
                        myVector.fontforecolor = table.Rows(i)("fontforecolor")
                        myVector.fontbackcolor = table.Rows(i)("fontbackcolor")
                    End If
                End If
                If myVector.VectorObjectType = "Weld" Then
                    Dim jj = 0
                End If
                myVector.OrgScaleX = Convert.ToSingle(table.Rows(i)("OrgScaleX")) 'Vector Object Type
                myVector.OrgScaleY = Convert.ToSingle(table.Rows(i)("OrgScaleY")) 'Vector Object Type
                myVector.ObjectMode = table.Rows(i)("ObjectMode")
                myVector.CabinetID = cabinetID

                LayerVectorArray.Add(myVector)
            Next
        Else
        End If
        'sqlDocUtils.CloseConnection()
        'sqlCabinetUtils.CloseConnection()
    End Sub


    'Public ReadOnly Property WeldPointInfoTbl() As DataTable
    '    Get
    '        'Dim useStr = "USE [" + runtime.selectedProject + "] "
    '        'Dim qry As String = "SELECT TagNo,Area,DWGNO,TestPkgNo,AdvancedTesting,BHN,System,SpoolTo,SpoolFrom,PipeSize," + _
    '        '            "WeldInches,ForemanName,SVCSPEC,WPS,NDEPcntReq,Material,WallThk,WeldType," + _
    '        '            "WeldStn,NDEType,TestResult,VisInspName,PWHT,DateEntered, Comments,DrawingID, ID"
    '        'Return (daqartDLL.Utilities.ExecuteRemoteQuery(useStr + qry + " FROM tblWeldTracking WHERE DrawingID =" + _DocumentID.ToString, "No Welders List"))
    '        Dim qry As String = "SELECT TagNo,Area,DWGNO,TestPkgNo,AdvancedTesting,BHN,System,SpoolTo,SpoolFrom,PipeSize," + _
    '                    "WeldInches,ForemanName,SVCSPEC,WPS,NDEPcntReq,Material,WallThk,WeldType," + _
    '                    "WeldStn,NDEType,TestResult,VisInspName,PWHT,DateEntered, Comments,DrawingID, ID, WeldStatus "
    '        Return (daqartDLL.Utilities.ExecuteQuery(qry + " FROM tblWeldTracking WHERE DrawingID =" + _DocumentID.ToString, "project"))
    '    End Get
    'End Property


    'Public Sub WeldPointDeleteAll()
    '    'Dim useStr = "USE [" + runtime.selectedProject + "] "
    '    'Dim qry As String = "DELETE * "
    '    'daqartDLL.Utilities.ExecuteRemoteNonQuery(useStr + "DELETE FROM tblWeldTracking WHERE DrawingID =" + _DocumentID.ToString, "No Welders List")

    '    Dim qry As String = "DELETE * "
    '    daqartDLL.Utilities.ExecuteNonQuery("DELETE FROM tblWeldTracking WHERE DrawingID =" + _DocumentID.ToString, "project")

    '    Dim dt As DataTable = Me.WeldLayerInfoTbl()
    '    Dim cabID = GetCabinetID(dt.Rows(0)(0))
    '    Dim connCabinet As SqlCeConnection = daqartDLL.connections.DaqumentStorageConnect(connCabinet, cabID)
    '    connCabinet.Open()
    '    Dim cmd As SqlCeCommand = connCabinet.CreateCommand()
    '    Dim query = "DELETE drawing_objects WHERE DrawingID = " + _DocumentID.ToString + " AND LayerID =" + _
    '            Me.GetLayerID("Welds").ToString
    '    'cmd.Dispose()
    '    cmd.CommandText = query
    '    cmd.ExecuteNonQuery()
    '    cmd.Dispose()
    '    connCabinet.Close()
    'End Sub



    Public ReadOnly Property LayerInfoTbl() As DataTable
        Get
            Dim qry = "SELECT MUID, LayerTitle As Title, LayerDescription As Description, LayerRevDate Revision, lastUserMUID, " + _
                    " layerStatus, DateCreated, Cabinet, DrawingMUID " + _
                    " FROM drawing_layers " + _
                                    " WHERE(DrawingMUID = '" + _DocumentID.ToString + "') "
            '_LayerInfoTbl = (Utilities.ExecuteQuery(qry, "Daqument"))
            'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

            'sqlDocUtils.OpenConnection()
            _LayerInfoTbl = runtime.SQLDaqument.ExecuteQuery(qry)
            'sqlDocUtils.CloseConnection()
            Return _LayerInfoTbl
        End Get
    End Property
    Public ReadOnly Property DeleteDrawingLayer(ByVal LayerID As String) As Boolean
        Get
            Try
                Dim qry = "DELETE FROM drawing_layers " + _
                                        " WHERE(DrawingMUID = @DrawingMUID) AND " + _
                                        " (MUID = @MUID)"

                'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

                Dim dt_param As DataTable = runtime.SQLDaqument.paramDT
                dt_param.Rows.Add("@DrawingMUID", _DocumentID.ToString)
                dt_param.Rows.Add("@MUID", LayerID.ToString)

                'sqlDocUtils.OpenConnection()
                runtime.SQLDaqument.ExecuteNonQuery(qry, dt_param)
                'sqlDocUtils.CloseConnection()

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property
    Public ReadOnly Property SpoolInfoTbl() As DataTable
        Get
            Dim qry = "SELECT TagNo, System, Area " + _
                    " FROM tblSpoolList "
            '_SpoolInfoTbl = (Utilities.ExecuteQuery(qry, "project"))
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            'sqlPrjUtils.OpenConnection()
            _SpoolInfoTbl = runtime.SQLProject.ExecuteQuery(qry)
            'sqlPrjUtils.CloseConnection()
            Return _SpoolInfoTbl
        End Get
    End Property
    Public ReadOnly Property WeldLayerInfoTbl() As DataTable
        Get
            Dim qry = "SELECT MUID, LayerTitle As Title, LayerDescription As Description, LayerRevDate Revision, lastUser, " + _
                    " layerStatus, DateCreated, Cabinet, DrawingMUID " + _
                    " FROM drawing_layers " + _
                                    " WHERE(DrawingMUID = '" + _DocumentID.ToString + "') AND " + _
                                    " (LayerTitle = 'Welds')"
            '_LayerInfoTbl = (Utilities.ExecuteQuery(qry, "Daqument"))
            'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

            'sqlDocUtils.OpenConnection()
            _LayerInfoTbl = runtime.SQLDaqument.ExecuteQuery(qry)
            'sqlDocUtils.CloseConnection()
            Return _LayerInfoTbl
        End Get
    End Property
    Public Function GetLayerID(ByVal LayerTitle As String)
        Dim qry = "SELECT MUID FROM drawing_layers WHERE(LayerTitle = '" + LayerTitle + "') AND (DrawingMUID = '" + _DocumentID.ToString + "')"
        Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(qry)

        If dt.Rows.Count > 0 Then
            Return (dt.Rows(0)(0))
        Else
            Return -1
        End If
    End Function

    Public Function GetCabinetID(ByVal LayerID As Integer)
        Dim qry = "SELECT Cabinet FROM drawing_layers WHERE(MUID = '" + LayerID.ToString + "') AND (DrawingMUID = '" + _DocumentID.ToString + "')"
        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        'sqlDocUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(qry)
        'sqlDocUtils.CloseConnection()

        'Return ((Utilities.ExecuteQuery(qry, "Daqument")).Rows(0)(0))
        Return (dt.Rows(0)(0))
    End Function
    Private Function GetNewCabinetID() As String
        Return "001"
    End Function
    Public Sub AddNewLayer(ByVal Title As String, ByVal Desc As String)
        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")
        Dim muid As String = idUtils.GetNextMUID("Daqument", "drawing_layers")
        Dim qry As String = "INSERT INTO drawing_layers(" + _
                "MUID, DrawingMUID, LayerRevDate, lastUserMUID, layerStatus, " + _
                " DateCreated, LayerDescription, LayerTitle, Cabinet " + _
                ") VALUES (" + _
                "@MUID," + _
                "@DrawingMUID," + _
                "@LayerRevDate," + _
                "@lastUserMUID," + _
                "@layerStatus," + _
                "@DateCreated," + _
                "@LayerDescription," + _
                "@LayerTitle," + _
                "@Cabinet)"

        Dim dt_param As DataTable = runtime.SQLDaqument.paramDT
        dt_param.Rows.Add("@MUID", muid)
        dt_param.Rows.Add("@DrawingMUID", _DocumentID.ToString)
        dt_param.Rows.Add("@LayerRevDate", Now.ToString)
        dt_param.Rows.Add("@lastUserMUID", runtime.UserMUID)
        dt_param.Rows.Add("@layerStatus", "0")
        dt_param.Rows.Add("@DateCreated", Now.ToString)
        dt_param.Rows.Add("@LayerDescription", Desc)
        dt_param.Rows.Add("@LayerTitle", Title)
        dt_param.Rows.Add("@Cabinet", GetNewCabinetID.ToString)

        'sqlDocUtils.OpenConnection()
        runtime.SQLDaqument.ExecuteNonQuery(qry, dt_param)
        'sqlDocUtils.CloseConnection()

    End Sub

    Public Function ResizeImage(ByVal oldImage As Image, ByVal nSize As Size) As Image
        Dim newSize As Size
        Dim ScaleX As Single = CType(nSize.Width, Single) / CType(oldImage.Size.Width, Single)
        Dim ScaleY As Single = CType(nSize.Height, Single) / CType(oldImage.Size.Height, Single)
        newSize.Width = CType((ScaleX * CType(oldImage.Size.Width, Single)), Integer)
        newSize.Height = CType((ScaleY * CType(oldImage.Size.Height, Single)), Integer)
        Using newImage As Bitmap = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
            Using canvas As Graphics = Graphics.FromImage(newImage)
                canvas.DrawImage(oldImage, New Rectangle(New Point(0, 0), newSize))
                Dim m As New MemoryStream
                newImage.MakeTransparent()
                newImage.Save(m, ImageFormat.Png)
                Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(m)
                Return Image
            End Using
        End Using
    End Function

    Public Function ResizeImage(ByVal nSize As Size) As Image
        Dim oldImage As Image = OriginalDocImage.Clone
        If (nSize.Width = oldImage.Width And nSize.Height = oldImage.Height) Then
            Return oldImage
        Else
            Return (ResizeImage(oldImage, nSize))
        End If
        'Dim ScaleX As Single = CType(nSize.Width, Single) / CType(oldImage.Size.Width, Single)
        'Dim ScaleY As Single = CType(nSize.Height, Single) / CType(oldImage.Size.Height, Single)
        'newSize.Width = CType((ScaleX * CType(oldImage.Size.Width, Single)), Integer)
        'newSize.Height = CType((ScaleY * CType(oldImage.Size.Height, Single)), Integer)
        'Using newImage As Bitmap = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
        '    Using canvas As Graphics = Graphics.FromImage(newImage)
        '        canvas.DrawImage(oldImage, New Rectangle(New Point(0, 0), newSize))
        '        Dim m As New MemoryStream
        '        newImage.Save(m, ImageFormat.Png)
        '        Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(m)
        '        Return Image
        '    End Using
        'End Using
    End Function
    Public Sub RemoveLayerObjects(ByVal LayerID As Integer)
        'Dim CabID = (Utilities.ExecuteQuery("SELECT CabinetID FROM drawing_layers " + _
        '                        " WHERE(LayerID = " + LayerID.ToString + ") ", "Daqument")).Rows(0)(0)
        Dim query As String = "SELECT Cabinet FROM drawing_layers " + _
                                " WHERE(MUID = '" + LayerID.ToString + "') "

        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument")

        'sqlDocUtils.OpenConnection()
        Dim CabID As String = runtime.SQLDaqument.ExecuteQuery(query).Rows(0)(0)
        'sqlDocUtils.CloseConnection()

        'Dim connCabinet As SqlCeConnection = connections.DaqumentStorageConnect(connCabinet, CabID)
        'connCabinet.Open()
        'Dim cmd As SqlCeCommand = connCabinet.CreateCommand()
        'cmd.CommandText = "delete FROM Drawing_Objects WHERE LayerID = " + LayerID.ToString
        'cmd.ExecuteNonQuery()
        'cmd.Dispose()
        'connCabinet.Close()
        'Dim sqlCabinetUtils As DataUtils = New DataUtils("Daqument001")
        query = "delete FROM Drawing_Objects WHERE LayerMUID = @LayerMUID"
        'sqlCabinetUtils.OpenConnection()

        Dim dt_param As DataTable = runtime.SQLDaqument001.paramDT
        dt_param.Rows.Add("@LayerMUID", LayerID.ToString)

        runtime.SQLDaqument001.ExecuteNonQuery(query, dt_param)
        'sqlCabinetUtils.CloseConnection()
    End Sub




    Public Function InsertLayerVector(ByVal vec As VectorMap) As String
        '" Aux01 " + _ 'VectorObjectType
        '" Aux02 " + _ 'OrgScaleX
        '" Aux03 " + _ 'OrgScaleY
        '" Aux04 " + _ 'ObjectMode
        Dim retID As String = ""
        'Dim sqlDocUtils As DataUtils = New DataUtils("Daqument001") ', vec.CabinetID.ToString)
        'sqlDocUtils.OpenConnection()

        Try

            If vec.text Is Nothing Then
                vec.text = ""
            End If
            'Dim connCabinet = runtime.SiteName + "_Daqument" + vec.CabinetID.ToString
            'Dim qryEntries = " DocumentMUID, LayerMUID, VectorType, " + _
            '        " StartPointX, StartPointY, " + _
            '        " endPointX, endPointY, " + _
            '        " lineWidth, lineEnd, penArgb, " + _
            '        " Text, VectorObjectType, " + _
            '        " OrgScaleX, OrgScaleY, " + _
            '        " ObjectMode "
            If vec.VectorObjectType = "Line" Then
                vec.text = ""
            End If
            'Dim qryValues = "@DocumentMUID" + _
            '            ",@LayerMUID" + _
            '            ",@VectorType" + _
            '            ",@StartPointX,@StartPointY" + _
            '            ",@endPointX,@endPointY" + _
            '            ",@lineWidth,@lineEnd,@penArgb" + _
            '            ",@Text,@VectorObjectType" + _
            '            ",@OrgScaleX,@OrgScaleY" + _
            '            ",@ObjectMode"

            retID = idUtils.GetNextMUID("Daqument001", "drawing_objects")
            Dim qry = "INSERT INTO Drawing_Objects (MUID, DocumentMUID, LayerMUID, VectorType, " + _
                    " StartPointX, StartPointY, " + _
                    " endPointX, endPointY, " + _
                    " lineWidth, lineEnd, penArgb, " + _
                    " Text, VectorObjectType, " + _
                    " OrgScaleX, OrgScaleY, " + _
                    " ObjectMode ) VALUES (" + _
                        "@MUID" + _
                        ",@DocumentMUID" + _
                        ",@LayerMUID" + _
                        ",@VectorType" + _
                        ",@StartPointX,@StartPointY" + _
                        ",@endPointX,@endPointY" + _
                        ",@lineWidth,@lineEnd,@penArgb" + _
                        ",@Text,@VectorObjectType" + _
                        ",@OrgScaleX,@OrgScaleY" + _
                        ",@ObjectMode)"
            Dim daqCabinet = "Daqument" + vec.CabinetID

            Dim dt_param As DataTable = runtime.SQLDaqument001.paramDT
            dt_param.Rows.Add("@MUID", retID)
            dt_param.Rows.Add("@DocumentMUID", vec.DrawingID.ToString)
            dt_param.Rows.Add("@LayerMUID", vec.layerID.ToString)
            dt_param.Rows.Add("@VectorType", vec.VectorType.ToString)
            dt_param.Rows.Add("@StartPointX", vec.OrgStartPointX.ToString)
            dt_param.Rows.Add("@StartPointY", vec.OrgStartPointY.ToString)
            dt_param.Rows.Add("@endPointX", vec.OrgEndPointX.ToString)
            dt_param.Rows.Add("@endPointY", vec.OrgEndPointY.ToString)
            dt_param.Rows.Add("@lineWidth", vec.OrgLineWidth.ToString)
            dt_param.Rows.Add("@lineEnd", vec.lineEnd.ToString)
            dt_param.Rows.Add("@penArgb", vec.penArgb.ToString)
            dt_param.Rows.Add("@Text", vec.text)
            dt_param.Rows.Add("@VectorObjectType", vec.VectorObjectType.ToString)
            dt_param.Rows.Add("@OrgScaleX", vec.OrgScaleX.ToString)
            dt_param.Rows.Add("@OrgScaleY", vec.OrgScaleY.ToString)
            dt_param.Rows.Add("@ObjectMode", vec.ObjectMode.ToString)

            runtime.SQLDaqument001.ExecuteNonQuery(qry, dt_param)

            Dim buffer As Byte() = Nothing
            If vec.VectorObjectType = "Pic" Then
                Dim m As New MemoryStream
                vec.vectorImage.Save(m, ImageFormat.Png)
                buffer = m.GetBuffer
                qry = "UPDATE drawing_objects SET vectorImage =" + _
                        "@vectorImage WHERE MUID = '" + retID.ToString + "'"
                'retID = Utilities.ExecuteSingleParameterizedScalar _
                '    (qry, "@vectorImage", buffer, daqCabinet)
                runtime.SQLDaqument001.ExecuteSingleParameterizedQuery(qry, "@vectorImage", buffer)
                'If retID = 0 Then
                '    MessageBox.Show("Failed to add Vector Image")
                '    Return 0
                'End If
                'retID = 1
            End If
            If vec.VectorObjectType = "Text" Then
                qry = "UPDATE drawing_objects SET " + _
                    "fontFamily =@fontFamily," + _
                    "fontSize =@fontSize," + _
                    "fontforecolor =@fontforecolor," + _
                    "fontbackcolor =@fontbackcolor " & _
                    " WHERE MUID=@MUID"

                dt_param = runtime.SQLDaqument001.paramDT
                dt_param.Rows.Add("@fontFamily", vec.fontFamily)
                dt_param.Rows.Add("@fontSize", vec.fontSize.ToString)
                dt_param.Rows.Add("@fontforecolor", vec.fontforecolor.ToString)
                dt_param.Rows.Add("@fontbackcolor", vec.fontbackcolor.ToString)
                dt_param.Rows.Add("@MUID", retID.ToString)

                runtime.SQLDaqument001.ExecuteNonQuery(qry, dt_param)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'sqlDocUtils.CloseConnection()
        Return retID

    End Function
    Public Function InsertWeldPointInfoIntoDatabase(ByVal dr As DataRow) As String
        Dim update As Boolean = True
        Dim qry As String = " "
        Dim selectQry As String = " "
        Dim valQry As String = " "
        For Each clm As DataColumn In dr.Table.Columns
            If clm.ColumnName <> "MUID" Then
                If clm.ColumnName = "DateEntered" Then
                    valQry = valQry + "'" + Now.Date() + "',"
                Else
                    valQry = valQry + "'" + dr(clm.ColumnName).ToString + "',"
                End If
                selectQry = selectQry + clm.ColumnName.ToString + ","

            End If
        Next
        valQry = valQry.Remove(valQry.Length - 1, 1)
        selectQry = selectQry.Remove(selectQry.Length - 1, 1)

        qry = " SELECT MUID FROM tblWeldTracking " + _
                " WHERE MUID =" + dr("MUID").ToString
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)

        If dt.Rows.Count > 0 Then
            'sqlPrjUtils.CloseConnection()
            Return (0)
        End If
        Dim muid As String = idUtils.GetNextMUID("project", "tblWeldTracking")
        qry = "INSERT INTO tblWeldTracking (MUID," + selectQry + _
                ") VALUES (" + "'" + muid + "'," + valQry + ") "
        'Return (daqartDLL.Utilities.ExecuteScalar(qry + ";", "project"))

        Dim dt_param As DataTable = runtime.SQLProject.paramDT
        runtime.SQLProject.ExecuteNonQuery(qry, dt_param)

        'sqlPrjUtils.CloseConnection()
        Return muid
    End Function
    Public Sub RemoveWeldPoint(ByVal weldTagNo As String)
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        For i As Integer = 0 To WeldPointInfoTable.Rows.Count - 1
            If WeldPointInfoTable.Rows(i)("TagNo") = weldTagNo Then
                Dim dr As DataRow = WeldPointInfoTable.Rows(i)
                If Not dr("MUID") = "0" Then
                    Dim qry = " DELETE From tblWeldTracking WHERE MUID = @MUID"

                    Dim dt_param As DataTable = runtime.SQLProject.paramDT
                    dt_param.Rows.Add("@MUID", dr("MUID").ToString)

                    runtime.SQLProject.ExecuteNonQuery(qry, dt_param)
                    'sqlPrjUtils.CloseConnection()
                    Return
                End If
            End If
        Next
        'sqlPrjUtils.CloseConnection()
        MessageBox.Show("No Weld Record deleted")
    End Sub
    Public Function AddOrUpdateWeldPointToDataBase(ByVal weldTagNo As String) As String
        Dim retID = "0"
        For i As Integer = 0 To WeldPointInfoTable.Rows.Count - 1
            If WeldPointInfoTable.Rows(i)("TagNo") = weldTagNo Then
                Dim dr As DataRow = WeldPointInfoTable.Rows(i)
                If dr("MUID") = "0" Then
                    Dim newId As String = InsertWeldPointInfoIntoDatabase(dr)
                    WeldPointInfoTable.Rows(i)("MUID") = newId
                    Return newId
                End If
                Dim qry As String = " "
                Dim selectQry As String = " "
                Dim valQry As String = " "


                'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
                Dim dt_param As DataTable = runtime.SQLProject.paramDT

                For Each clm As DataColumn In dr.Table.Columns
                    If clm.ColumnName <> "MUID" Then
                        If clm.ColumnName = "DateEntered" Then
                            valQry = valQry + clm.ColumnName + " = @" + clm.ColumnName + ","
                            dt_param.Rows.Add("@" + clm.ColumnName, Now.Date())
                        Else
                            valQry = valQry + clm.ColumnName + " = @" + clm.ColumnName + ","
                            dt_param.Rows.Add("@" + clm.ColumnName, dr(clm.ColumnName).ToString)
                        End If
                    End If
                Next
                valQry = valQry.Remove(valQry.Length - 1, 1)
                qry = " Update tblWeldTracking SET " + valQry + " WHERE MUID=@MUID"

                dt_param.Rows.Add("@MUID", dr("MUID").ToString)

                'sqlPrjUtils.OpenConnection()
                runtime.SQLProject.ExecuteNonQuery(qry, dt_param)
                'sqlPrjUtils.CloseConnection()
                retID = dr("MUID")
            End If
        Next
        Return retID
    End Function

    Public Sub UpdateLayerVector(ByVal vec As VectorMap)
        '" Aux01 " + _ 'VectorObjectType
        '" Aux02 " + _ 'OrgScaleX
        '" Aux03 " + _ 'OrgScaleY
        '" Aux04 " + _ 'ObjectMode

        'Dim sqlCabinetUtils As DataUtils = New DataUtils("Daqument001") ', vec.CabinetID)
        'sqlCabinetUtils.OpenConnection()

        If vec.text Is Nothing Then
            vec.text = ""
        End If
        Dim query = "UPDATE drawing_objects Set " & _
        " StartPointX = @StartPointX," & _
        " StartPointY = @StartPointY," & _
        " endPointX = @endPointX," & _
        " endPointY = @endPointY," & _
        " lineWidth = @lineWidth," & _
        " lineEnd = @lineEnd," & _
        " penArgb = @penArgb," & _
        " Text = @Text," & _
        " vectorObjectType = @vectorObjectType," & _
        " OrgScaleX = @OrgScaleX," & _
        " OrgScaleY = @OrgScaleY," & _
        " ObjectMode = @ObjectMode"

        Dim dt_param As DataTable = runtime.SQLDaqument001.paramDT
        dt_param.Rows.Add("@StartPointX", vec.OrgStartPointX.ToString)
        dt_param.Rows.Add("@StartPointY", vec.OrgStartPointY.ToString)
        dt_param.Rows.Add("@endPointX", vec.OrgEndPointX.ToString)
        dt_param.Rows.Add("@endPointY", vec.OrgEndPointY.ToString)
        dt_param.Rows.Add("@lineWidth", vec.OrgLineWidth.ToString)
        dt_param.Rows.Add("@lineEnd", vec.lineEnd.ToString)
        dt_param.Rows.Add("@penArgb", vec.penArgb.ToString)
        dt_param.Rows.Add("@Text", vec.text.ToString)
        dt_param.Rows.Add("@vectorObjectType", vec.VectorObjectType.ToString)
        dt_param.Rows.Add("@OrgScaleX", vec.OrgScaleX.ToString)
        dt_param.Rows.Add("@OrgScaleY", vec.OrgScaleY.ToString)
        dt_param.Rows.Add("@ObjectMode", vec.ObjectMode.ToString)

        Dim buffer As Byte() = Nothing
        If vec.VectorObjectType = "Text" Then
            query += ", fontFamily = @fontFamily"
            query += ", fontSize = @fontSize"
            query += ", fontforecolor = @fontforecolor"
            query += ", fontbackcolor = @fontbackcolor"

            dt_param.Rows.Add("@fontFamily", vec.fontFamily)
            dt_param.Rows.Add("@fontSize", vec.fontSize.ToString)
            dt_param.Rows.Add("@fontforecolor", vec.fontforecolor.ToString)
            dt_param.Rows.Add("@fontbackcolor", vec.fontbackcolor.ToString)
        End If

        query += " WHERE MUID = @MUID"
        dt_param.Rows.Add("@MUID", vec.SQLID.ToString)

        Try

            runtime.SQLDaqument001.ExecuteNonQuery(query, dt_param)

            If vec.VectorObjectType = "Pic" Then
                'Dim m As New MemoryStream
                'vec.vectorImage.Save(m, ImageFormat.Png)

                'buffer = m.GetBuffer
                'query = "UPDATE drawing_objects SET vectorImage =" + _
                '        "@vectorImage WHERE MUID = '" + vec.SQLID.ToString + "'"
                ''retID = Utilities.ExecuteSingleParameterizedScalar _
                ''    (qry, "@vectorImage", buffer, daqCabinet)
                'sqlCabinetUtils.ExecuteSingleParameterizedQuery(query, "@vectorImage", buffer)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'sqlCabinetUtils.CloseConnection()
    End Sub
    Public Sub DeleteLayerVector(ByVal vec As VectorMap)
        Try
            Dim qry = "DELETE FROM Drawing_Objects WHERE MUID = @MUID"
            'Dim sqlCabinetUtils As DataUtils = New DataUtils("Daqument001") ', vec.CabinetID)
            'sqlCabinetUtils.OpenConnection()

            Dim dt_param As DataTable = runtime.SQLDaqument001.paramDT
            dt_param.Rows.Add("@MUID", vec.SQLID.ToString)

            runtime.SQLDaqument001.ExecuteNonQuery(qry, dt_param)
            'sqlCabinetUtils.CloseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Public Function GetLayerProperties() As DataTable
    '    Dim hdrs() As String = {"Name", "Type", "Tag", "Owner", "User", "LastModified", "Last UserAction", "Form Current Levl", "percentComplete", "RequireMhrs", "EarnedMhrs", "Comment"}
    '    Dim DisplayTable As DataTable = New DataTable("FormProperties")
    '    For Each s As String In hdrs
    '        Dim ThisColumn As DataColumn = New DataColumn(s, GetType(String))
    '        ThisColumn.ColumnName = s
    '        DisplayTable.Columns.Add(ThisColumn)
    '    Next
    '    Dim imageColumn As DataColumn = New DataColumn("Esign", GetType(Image))
    '    imageColumn.ColumnName = "Esign"
    '    DisplayTable.Columns.Add(imageColumn)

    '    Dim dRow As DataRow = DisplayTable.NewRow
    '    Dim i As Integer = 0
    '    For i = 0 To hdrs.Length - 1
    '        '            dRow(hdrs(i)) = myVal(i)
    '    Next
    '    '    dRow("Esign") = _FormESign
    '    DisplayTable.Rows.Add(dRow)
    '    Return DisplayTable
    'End Function

    Private Function MakeTransparent(ByVal Img As Image) As Image
        Try
            Dim tmp_Image As Image = Img
            Dim bmp_Image As New Bitmap(Img)
            Dim backColor As Color = bmp_Image.GetPixel(1, 1)
            bmp_Image.MakeTransparent(backColor)
            tmp_Image = bmp_Image
            Return tmp_Image
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


End Class
