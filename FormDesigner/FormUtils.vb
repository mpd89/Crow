Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.IO
'Imports System.Data.SqlServerCe
'Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.FileIO
Imports daqartDLL


Public Class FormUtils
    'Private connProject As SqlCeConnection = daqartDLL.connections.projectDBConnect(connProject)
    'Private connServer As SqlCeConnection = daqartDLL.connections.serverDBConnect(connServer)
    Private ElementTags() As ElementTagKeyValue
    Public Structure ElementTagKeyValue
        Public _ElementName As String
        Public _TagID As String
        Public _ReqManHours As Single
        Public _EarnedManHoursPerVariable As Single
        Public _EarnedManHours As Single
    End Structure


    Public Structure formItem
        ' Public members, accessible from throughout declaration region.
        Public FieldName As String
        Public MapName As String
        Public linkTbl As String
        Public Value As String
        Public WtPcnt As Single
        Public Color As String
        Public DataType As FormDesigner.FormDesignerMain.VarAttributes.dtype
        Public PgNum As Integer
        Public View As String
        Public Position As Integer
        Public PosX As Integer
        Public PosY As Integer
        Public Width As Integer
        Public Height As Integer
        Public TabPosition As Integer
        Public FontName As String
        Public FontSize As Single
        Public FontBold As Boolean
        Public FontItalic As Boolean
        Public FontUnderline As Boolean
        Public GroupID As Integer
        Public image As System.Drawing.Image
        Public FieldID As String
        Public CustomName As String
        ' Public Selected As Boolean

        ' Procedure member, which can access structure's private members.
    End Structure

    '    Private _PkgID As Integer
    Private _FrmID As String
    Private _TagID As String = ""
    Private _TypeID As String = ""
    Private _TagName As String = ""
    Private _OwnerID As String = ""
    Private _OwnerName As String = ""
    Private _TypeName As String = ""
    Private _UserName As String = ""
    Private _RequirementID As String = ""
    Private _imgList As New List(Of Image)
    Private _PrintImgList As New List(Of Image)
    Private _ResizeImgList As New List(Of Image)
    Private _formVar As New List(Of formItem)
    Private _formItm As formItem
    Private _FormUpdateDate As Date
    Private _FormCurrentUserID As String
    Private _FormUser As String
    Private _FormUserLevel As Integer
    Private _FormLevelOrder As Array
    Private _FormName As String
    Private _FormAction As Integer
    Private _FormCurrentLevel As Integer
    Private _FormTtlRequiredLevels As Integer
    Private _FormRequiredManHours As Single
    Private _FormElementRequiredManHours As Single
    Private _FormPercentComplete As Single

    Private _FormEarnedManHours As Single
    Private _FormESign As System.Drawing.Image
    Private _FormESignBuffer As System.Drawing.Image
    Private _FormComment As String
    Private _ElementVarCount As Integer = 0
    Private _SubElementVarCount As Integer = 0
    Private _NumElementVariables As Integer = 0
    Private _FormCurrentUserLevelID As String = ""
    Private MultiElement As Boolean
    Private NumberofElements As Integer
    Private PackageID As String
    Private TagCount As Integer
    Private MEPageCount As Integer
    Private _FormMode As String
    Private dt_TagList As New DataTable


    Public Property FormVars() As List(Of formItem)
        Get
            Return _formVar
        End Get

        Set(ByVal value As List(Of formItem))

        End Set
    End Property

    Public ReadOnly Property FormImages() As List(Of Image)
        Get
            Return _imgList
        End Get
    End Property

    Public ReadOnly Property FormPrintImages() As List(Of Image)
        Get
            InitializeFormPrintImage()
            Return _PrintImgList
        End Get
    End Property

    Public ReadOnly Property FormWidth() As Integer
        Get
            Return _imgList(0).Size.Width
        End Get
    End Property

    Public ReadOnly Property FormUserLevel() As Integer
        Get
            Return _FormUserLevel
        End Get
    End Property
    Public Property FormCurrentUserLevelID() As String
        Get
            Return _FormCurrentUserLevelID
        End Get
        Set(ByVal value As String)
            _FormCurrentUserLevelID = value
        End Set
    End Property

    Public ReadOnly Property FormLevelOrder() As Array
        Get
            Return _FormLevelOrder
        End Get
    End Property

    Public ReadOnly Property FormVarID(ByVal Name As String) As String
        Get
            For Each var As formItem In _formVar
                If var.FieldName = Name Then
                    Return var.FieldID
                End If
            Next
            Return ""
        End Get
    End Property

    Public ReadOnly Property FormTtlRequiredLevels() As Integer
        Get
            Return _FormTtlRequiredLevels
        End Get
    End Property

    Public ReadOnly Property FormMaxLevel() As Integer
        Get
            Dim qry As String = " SELECT CurrentLevel,TS FROM forms_status WHERE FormID = " + _
                    _FrmID.ToString + " ORDER By TS DESC "

            '2.1.0.42
            'Dim dt As New DataTable
            'dt = Utilities.ExecuteQuery(qry, "project")
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
            'sqlPrjUtils.CloseConnection()
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0)
            Else
                Return 0
            End If

            'Return 0
            'Dim cmd As SqlCeCommand = connProject.CreateCommand()
            'cmd.CommandText = " SELECT CurrentLevel FROM forms_status WHERE FormID = " + _
            '_FrmID.ToString + " ORDER By CurrentLevel DESC "
            'Dim MaxLevel = Convert.ToInt32(cmd.ExecuteScalar)
            'cmd.Dispose()
            'Return MaxLevel
        End Get
    End Property

    Public Property FormCurrentLevel() As Integer
        Get
            Return _FormCurrentLevel
        End Get
        Set(ByVal value As Integer)
            _FormCurrentLevel = value
        End Set
    End Property

    Public Property FormCurrentUserID() As String
        Get
            Return _FormCurrentUserID
        End Get
        Set(ByVal value As String)
            _FormCurrentUserID = value
            SetCurrentUserLevel()
        End Set
    End Property

    Public Property FormNumberOfElements() As Integer
        Get
            Return NumberofElements
        End Get
        Set(ByVal value As Integer)
            NumberofElements = value
        End Set
    End Property

    Public Property FormComment() As String
        Get
            Return _FormComment
        End Get
        Set(ByVal value As String)
            _FormComment = value
        End Set
    End Property

    Public Property FormAction() As ActionType
        Get
            Return _FormAction
        End Get
        Set(ByVal value As ActionType)
            _FormAction = value
        End Set
    End Property

    Public Property FormEsign() As Image
        Get
            Return _FormESign
        End Get
        Set(ByVal value As Image)
            If Not _FormESign Is Nothing Then
                _FormESign.Dispose()
            End If
            Dim m As New MemoryStream
            value.Save(m, ImageFormat.Png)
            _FormESign = System.Drawing.Image.FromStream(m)
        End Set
    End Property

    Public ReadOnly Property FormPageCount() As Integer
        Get
            Return _imgList.Count
        End Get
    End Property

    Public ReadOnly Property FormHeight() As Integer
        Get
            Return _imgList(0).Size.Height
        End Get
    End Property

    Public ReadOnly Property FormName() As String
        Get
            Return _FormName
        End Get
    End Property

    Public ReadOnly Property FormRequiredManHours() As Single
        Get
            Return GetRequiredManHours()
        End Get
    End Property
    'Public ReadOnly Property FormElementRequiredManHours() As Single
    '    Get
    '        Return _FormElementRequiredManHours
    '    End Get
    'End Property
    Public ReadOnly Property FormEarnedManHours() As Single
        Get
            Return GetEarnedManHours()
        End Get
    End Property

    Public ReadOnly Property FormPercentComplete() As Single
        Get
            Return Me.GetPercentComplete()
        End Get
    End Property

    Public ReadOnly Property FormResizeImages(ByVal Magnification As Single) As List(Of Image)
        Get
            For Each img As Image In _ResizeImgList
                img.Dispose()
            Next
            For i As Integer = 0 To _imgList.Count - 1
                _ResizeImgList.Add(ResizeImage(_imgList(i), Magnification))
            Next
            Return _ResizeImgList
        End Get
    End Property

    Public ReadOnly Property FormLocalPkgAuxFieldValue(ByVal fieldName As String) As String
        Get
            Dim qry = "SELECT PackageTemplateMUID FROM Forms WHERE MUID = '" + _FrmID.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
            If dt.Rows.Count > 0 Then
                Dim templateID As String = dt.Rows(0)("PackageTemplateMUID")
                qry = " SELECT aux_package.auxData FROM aux_package,aux_fieldmap WHERE " + _
                            " aux_fieldmap.CustomName = '" + fieldName + "' AND " + _
                            " aux_package.FieldmapMUID = aux_fieldmap.MUID AND " + _
                            " aux_fieldmap.TemplateMUID = '" + templateID.ToString + "'" + _
                            " AND aux_package.PackageMUID = '" + PackageID.ToString + "'"
                'dt = Utilities.ExecuteQuery(qry, "project")
                dt = runtime.SQLProject.ExecuteQuery(qry)
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)(0).ToString
                End If
            End If
            'sqlPrjUtils.CloseConnection()
            Return ""
        End Get
    End Property

    Public ReadOnly Property FormLocalTagAuxFieldValue(ByVal fieldName As String) As String
        Get
            Dim qry = "SELECT TagTemplateMUID FROM Forms WHERE MUID = '" + _FrmID.ToString + "'"
            'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
            If dt.Rows.Count > 0 Then
                Dim templateID As String = dt.Rows(0)("TagTemplateMUID")
                qry = " SELECT aux_tags.auxData FROM aux_tags,aux_fieldmap WHERE " + _
                            " aux_fieldmap.CustomName = '" + fieldName + "' AND " + _
                            " aux_tags.FieldmapMUID = aux_fieldmap.MUID AND " + _
                            " aux_fieldmap.TemplateMUID = '" + templateID.ToString + "'" + _
                            " AND aux_tags.TagMUID = '" + _TagID.ToString + "'"
                'dt = Utilities.ExecuteQuery(qry, "project")
                dt = runtime.SQLProject.ExecuteQuery(qry)
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)(0).ToString
                End If
            End If
            'sqlPrjUtils.CloseConnection()
            Return ""
        End Get
    End Property


    Public ReadOnly Property FormProjectInfoFieldValue(ByVal fieldName As String) As String
        Get
            Dim query As String
            Dim thisField As String = Nothing

            If fieldName = "Title" Then
                thisField = "Name"
            ElseIf fieldName = "Description" Then
                thisField = "Description"
            ElseIf fieldName = "Location" Then
                thisField = "Location"
            End If

            query = " SELECT " + thisField + " FROM projects WHERE " + _
                        " Name = '" + runtime.selectedProject + "'"

            Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0).ToString
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property FormSystemInfoFieldValue(ByVal fieldName As String) As String
        Get
            Dim query As String
            Dim thisField As String = Nothing
            Dim dt As DataTable
            Dim TierNumber As Integer

            If fieldName = "Project #" Then
                'get tier for MC
                query = "SELECT * FROM system_mnemonic WHERE Aux08='MC'"
                dt = runtime.SQLProject.ExecuteQuery(query)

                If dt.Rows.Count = 0 Then
                    Return ""
                Else
                    TierNumber = dt.Rows(0)("TierNumber")

                    'get tier MUID from package
                    query = "SELECT * FROM package WHERE MUID ='" + Me.PackageID + "'"
                    dt = runtime.SQLProject.ExecuteQuery(query)

                    If dt.Rows.Count = 0 Then
                        Return ""
                    Else
                        'split System MUID
                        Dim SystemArray As Array = Split(dt.Rows(0)("SystemMUID"), ";")


                        'get Aux09 for Project #
                        query = "SELECT * FROM system_number WHERE MUID='" + SystemArray(TierNumber - 1) + "'"
                        dt = runtime.SQLProject.ExecuteQuery(query)

                        'check to see if package is a handover package
                        Dim PackageNumber As String = Utilities.GetPackageName(Me.PackageID)
                        If Mid(PackageNumber, 1, 3) = "HCP" Then
                            'get Aux09 for Project #

                            Dim MC_Number As String = SystemManager.SystemDataManager.GetSystemID(Utilities.TranslateTagID(Me._TagID), True, TierNumber)
                            query = "SELECT * FROM system_number WHERE MUID='" + MC_Number + "'"
                            dt = runtime.SQLProject.ExecuteQuery(query)

                        End If

                        If dt.Rows.Count = 0 Or IsDBNull(dt.Rows(0)("Aux09")) Then
                            Return ""
                        Else
                            Return dt.Rows(0)("Aux09")
                        End If
                    End If
                End If
            Else
                'get tier for MC
                query = "SELECT * FROM system_mnemonic WHERE Description='" + fieldName + "'"
                dt = runtime.SQLProject.ExecuteQuery(query)

                If dt.Rows.Count = 0 Then
                    Return ""
                Else
                    TierNumber = dt.Rows(0)("TierNumber")

                    'get tier MUID from package
                    query = "SELECT * FROM package WHERE MUID ='" + Me.PackageID + "'"
                    dt = runtime.SQLProject.ExecuteQuery(query)

                    If dt.Rows.Count = 0 Then
                        Return ""
                    Else
                        'split System MUID
                        Dim SystemArray As Array = Split(dt.Rows(0)("SystemMUID"), ";")

                        'get Tier for Project #
                        query = "SELECT * FROM system_number WHERE MUID='" + SystemArray(TierNumber - 1) + "'"
                        dt = runtime.SQLProject.ExecuteQuery(query)

                        If dt.Rows.Count = 0 Then
                            Return ""
                        Else
                            Return SystemManager.SystemDataManager.GetSystemIdentifier(dt.Rows(0)("MUID"))
                        End If
                    End If
                End If
                'get tier info

                'split system number

                'translate the system identifier

                'return value


            End If

            'query = " SELECT " + thisField + " FROM projects WHERE " + _
            '            " Name = '" + runtime.selectedProject + "'"


            'If dt.Rows.Count > 0 Then
            '    Return dt.Rows(0)(0).ToString
            'End If
            'Return ""
        End Get
    End Property


    Public Enum ActionType
        Undefined = 0
        Submit
        Reject
        Accept
        CancelSubmit
    End Enum
    Public Enum FormDataType
        Text
        Number
        DateTime
        yesNo
    End Enum 'Days


    Public Sub New(ByVal FormID As String, ByVal aTagID As String, ByVal OwnerID As String, ByVal FormMode As String)
        Dim qry As String = " SELECT MultiElement,NumberofElements FROM forms WHERE MUID = '" + FormID.ToString + "'"
        Debug.Print("New formUtils created")
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        _FormMode = FormMode
        _FrmID = FormID
        _TagID = aTagID
        _OwnerID = OwnerID
        _TypeID = GetTypeID()

        If runtime.SQLProject.ExecuteQuery(qry).Rows(0)("MultiElement") = 1 Then
            MultiElement = True
            If IsDBNull(runtime.SQLProject.ExecuteQuery(qry).Rows(0)(1)) Then
                NumberofElements = 0
            Else
                NumberofElements = runtime.SQLProject.ExecuteQuery(qry).Rows(0)(1)
            End If
        End If

        If MultiElement And FormMode = "View" Then
            qry = " SELECT TagNumber, TypeMUID, PackageMUID  FROM tags WHERE tags.MUID = '" + aTagID.ToString + "'"
            Dim myTbl As DataTable = runtime.SQLProject.ExecuteQuery(qry)
            PackageID = myTbl.Rows(0)(2)

            ''Unused Query
            qry = " SELECT * FROM tags WHERE PackageMUID = '" + PackageID.ToString + "' AND " + _
                " TypeMUID = '" + _TypeID + "'"
            'dt_TagList = sqlPrjUtils.ExecuteQuery(qry)

            qry = "SELECT Distinct TypeMUID " & _
                    "FROM requirements " & _
                    "WHERE requirements.FormMUID = '" + FormID + "' " + _
                    " AND OwnerMUID = '" + OwnerID + "'"

            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
            For i As Integer = 0 To dt.Rows.Count - 1
                qry = "SELECT * From tags WHERE TypeMUID = '" + dt.Rows(i)(0) + "'" + " AND PackageMUID = '" + PackageID.ToString + "'"
                Dim dtTag As DataTable = runtime.SQLProject.ExecuteQuery(qry)
                'First time through
                If dt_TagList.Columns.Count = 0 Then
                    For Each col As DataColumn In dtTag.Columns
                        dt_TagList.Columns.Add(col.ColumnName)
                    Next
                    dt_TagList.Columns.Add("ReqMUID")
                End If
                If dtTag.Rows.Count > 0 Then
                    Debug.Print("FormUtils hit test")
                    'For every row in the tag List
                    For u As Integer = 0 To dtTag.Rows.Count - 1
                        'Add a row
                        dt_TagList.Rows.Add()
                        '  For every column in dt_tagList (which is the same as the tag columns except for the ReqMUID column
                        For a As Integer = 0 To dt_TagList.Columns.Count - 2
                            '               'The last row of the dt_tagList and for each column set it equal to 
                            dt_TagList.Rows(dt_TagList.Rows.Count - 1)(a) = dtTag.Rows(u)(a)
                        Next
                        dt_TagList.Rows(dt_TagList.Rows.Count - 1)(dt_TagList.Columns.Count - 1) = dt.Rows(i)(0)
                    Next
                End If
            Next

            TagCount = dt_TagList.Rows.Count
        ElseIf FormMode = "View" Then
            qry = " SELECT TagNumber, TypeMUID, PackageMUID  FROM tags WHERE tags.MUID = '" + aTagID.ToString + "'"
            Dim myTbl As DataTable = runtime.SQLProject.ExecuteQuery(qry)
            PackageID = myTbl.Rows(0)("PackageMUID")
        End If

        'sqlPrjUtils.CloseConnection()

        _TypeName = GetTypeName()
        _TagName = GetTagName()
        _OwnerName = GetOwnerName()
        _RequirementID = GetRequirementID()
        GetFormImageList()
        _FormAction = 0
        _FormCurrentLevel = 0
        _FormComment = ""

        If _FormMode = "View" Then
            GetAllFormStatus()
        End If
        InitializeFormParameters()

        'InitializeFormImage()
        _UserName = runtime.UserName
        Dim LevelOrder As String = "Undefined"
        Dim configTable As DataTable = Utilities.GetFormConfig(OwnerID)
        If configTable.Rows.Count > 0 Then
            LevelOrder = configTable.Rows(0)(0)
        End If


        _FormLevelOrder = Split(LevelOrder, ",")
        _FormTtlRequiredLevels = _FormLevelOrder.Length
        _FormCurrentUserID = runtime.UserMUID
        SetCurrentUserLevel()

    End Sub

    Private Function GetMEFormTagIDList(ByVal FormID As String, ByVal OwnerID As String) As List(Of String)
        Dim AllTagIDs As New List(Of String)
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim query As String = ""

        query = "SELECT Distinct TypeMUID " & _
                "FROM requirements " & _
                "WHERE requirements.FormMUID = '" + FormID + "' " + _
                " AND OwnerMUID = '" + OwnerID + "'"
        Try
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
            For i As Integer = 0 To dt.Rows.Count - 1
                query = "SELECT MUID From tags WHERE TypeMUID = '" + dt.Rows(i)(0) + "'"
                Dim dtTag As DataTable = runtime.SQLProject.ExecuteQuery(query)
                If dtTag.Rows.Count > 0 Then
                    AllTagIDs.Add(dtTag.Rows(i)(0))
                End If
            Next
        Catch ex As Exception
            Dim message As String = ex.Message
            Throw ex
        End Try
        Return AllTagIDs
    End Function

    Private Function IsReservedElement(ByVal mapName As String)
        Dim resStr() As String = {"TagNumber", "Description", "Remarks", "Service", _
                        "Manufacturer", "ModelNumber", "SerialNumber", "PONumber", "LineNumber"}
        For i As Integer = 0 To resStr.Length - 1
            If mapName.Contains(resStr(i)) Then Return True
        Next
        Return False
    End Function

    Private Function GetNonElementWtPercentComplete() As Single
        Dim AssignedWtPercent As Single = 0
        Dim CountVariablesWithEqualWts As Integer = 0
        Dim WtDistribution As Single = 0
        Dim ElementVarCount As Integer = 0
        Dim NumElementVarCount As Integer = 0
        Dim SubElementVarCount As Integer = 0
        Dim firstElementName As String = ""

        Try
            'count number of element variables
            For i As Integer = 0 To _formVar.Count - 1
                Dim itm As formItem = _formVar(i)
                If itm.linkTbl = "" Then
                    If itm.MapName.Contains("Element") Then
                    Else
                        If itm.WtPcnt > 0.0 Then
                            AssignedWtPercent = AssignedWtPercent + itm.WtPcnt
                        Else
                            CountVariablesWithEqualWts = CountVariablesWithEqualWts + 1
                        End If
                    End If
                End If
            Next
            Dim RemainingWtPercent As Single = 1 - AssignedWtPercent
            If CountVariablesWithEqualWts > 0 Then
                WtDistribution = RemainingWtPercent / CountVariablesWithEqualWts
            End If
            'coumpute ttl %complete
            Dim ttlPercentComplete As Single = 0.0
            For i As Integer = 0 To _formVar.Count - 1
                Dim itm As formItem = _formVar(i)
                If itm.linkTbl = "" And itm.Value > "" Then
                    If itm.MapName.Contains("Element") Then
                    Else
                        If itm.WtPcnt > 0.0 Then
                            ttlPercentComplete = ttlPercentComplete + itm.WtPcnt
                        Else
                            ttlPercentComplete = ttlPercentComplete + WtDistribution
                        End If
                    End If
                End If
            Next
            'Dim pkgMHrs As Single = GetNonElementRequiredManHours()
            'Dim tagMHrs As Single = GetAllElementRequiredManHours()
            'Dim NonElementPortion = pkgMHrs / tagMHrs
            'Return ttlPercentComplete * NonElementPortion
            Return ttlPercentComplete

        Catch ex As Exception
            MessageBox.Show("Error processing form status.(GetNonElementWtPercentComplete)")
        End Try
    End Function


    Private Function GetElementWtPercentComplete() As Single
        Dim AssignedWtPercent As Single = 0
        Dim CountVariablesWithEqualWts As Integer = 0
        Dim WtDistribution As Single = 0
        Dim firstElementName As String = ""
        'Compute wt % and equal wt
        For i As Integer = 0 To _formVar.Count - 1
            Dim itm As formItem = _formVar(i)
            If itm.linkTbl = "" Then
                If itm.MapName.Contains("Element") Then
                    If Not IsReservedElement(itm.MapName) Then
                        If itm.WtPcnt > 0.0 And _ElementVarCount > 0 Then
                            AssignedWtPercent = AssignedWtPercent + itm.WtPcnt / _ElementVarCount
                        Else
                            CountVariablesWithEqualWts = CountVariablesWithEqualWts + 1
                        End If
                    End If
                Else
                End If
            End If
        Next
        Dim RemainingWtPercent As Single = 1 - AssignedWtPercent
        If CountVariablesWithEqualWts > 0 Then
            WtDistribution = RemainingWtPercent / CountVariablesWithEqualWts
        End If
        'coumpute ttl %complete
        Dim ttlPercentComplete As Single = 0.0
        For i As Integer = 0 To _formVar.Count - 1
            Dim itm As formItem = _formVar(i)
            If itm.linkTbl = "" And itm.Value > "" Then
                If itm.MapName.Contains("Element") Then
                    If Not IsReservedElement(itm.MapName) Then
                        If itm.WtPcnt > 0.0 And _ElementVarCount > 0 Then
                            ttlPercentComplete = ttlPercentComplete + itm.WtPcnt / _ElementVarCount
                        Else
                            ttlPercentComplete = ttlPercentComplete + WtDistribution
                        End If
                    End If
                Else
                End If
            End If
        Next
        '        Dim ElementPortion = (GetAllElementRequiredManHours()) / (GetNonElementRequiredManHours() + GetAllElementRequiredManHours())
        Return ttlPercentComplete
    End Function


    Private Sub GetMeFormStatus()
        Dim qry = " SELECT Name FROM forms WHERE MUID = '" + _FrmID.ToString + "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        _FormName = runtime.SQLProject.ExecuteQuery(qry).Rows(0)(0)

        qry = "SELECT TS, UserMUID, Action,Comment,ESign,CurrentLevel " + _
           " FROM forms_me_status WHERE SourceMUID = '" + _TagID + "' AND FormMUID = '" + _FrmID + "' AND " + _
           " OwnerMUID = '" + _OwnerID.ToString + "' AND SourceType='Tag' ORDER BY TS DESC"

        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)


        If dt.Rows.Count = 0 Then
            Return
        End If

        _FormUpdateDate = dt.Rows(0)("TS")
        _FormUser = dt.Rows(0)("UserMUID")
        _FormAction = dt.Rows(0)("Action")
        _FormComment = dt.Rows(0)("Comment").ToString
        _FormCurrentLevel = dt.Rows(0)("CurrentLevel").ToString

        If Not (IsDBNull(dt.Rows(0)("ESign"))) Then
            Dim buffer() As Byte = dt.Rows(0)("ESign")
            Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))
            _FormESign = Image
        End If

        qry = " SELECT SUM (RequiredManHours), SUM (EarnedManHours), MIN (CurrentLevel) FROM forms_me_status " + _
                " WHERE SourceMUID = '" + PackageID + "'" + _
                " AND OwnerMUID = '" + _OwnerID + "'" + _
                " AND SourceType = 'Package'"

        Dim dq As DataTable = runtime.SQLProject.ExecuteQuery(qry)

        _FormEarnedManHours = 0
        If Not IsDBNull(dq.Rows(0)(1)) Then
            _FormEarnedManHours = dq.Rows(0)(1)
        End If

        _FormRequiredManHours = 0
        If Not IsDBNull(dq.Rows(0)(0)) Then
            _FormRequiredManHours = dq.Rows(0)(0)
        End If


        qry = " SELECT SUM (RequiredManHours), SUM (EarnedManHours), MIN (CurrentLevel) FROM forms_me_status, tags " + _
                " WHERE SourceMUID = tags.MUID " + _
                " AND OwnerMUID = '" + _OwnerID.ToString + "'" + _
                " AND SourceType = 'Tag'" + _
                " AND tags.PackageMUID = '" + PackageID.ToString + "'"

        Dim db As DataTable = runtime.SQLProject.ExecuteQuery(qry)

        If Not IsDBNull(db.Rows(0)(1)) Then
            _FormEarnedManHours = _FormEarnedManHours + db.Rows(0)(1)
        End If
        If Not IsDBNull(db.Rows(0)(0)) Then
            _FormRequiredManHours = _FormRequiredManHours + db.Rows(0)(0)
        End If

        _FormPercentComplete = IIf(_FormRequiredManHours > 0, _FormEarnedManHours / _FormRequiredManHours, 0)
        'sqlPrjUtils.CloseConnection()

    End Sub


    Private Sub GetNonMeFormStatus()
        'Return
        'Dim cmd As SqlCeCommand = connProject.CreateCommand()
        Dim qry = " SELECT Name FROM forms WHERE MUID = '" + _FrmID + "'"
        '_FormName = Utilities.ExecuteQuery(qry, "project").Rows(0)(0)
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()

        _FormName = runtime.SQLProject.ExecuteQuery(qry).Rows(0)(0)

        qry = "SELECT TS, UserMUID, Action,Comment,ESign,RequiredManHours,EarnedManHours,CurrentLevel " + _
           " FROM forms_status WHERE TagMUID = '" + _TagID.ToString + "' AND FormMUID = '" + _FrmID.ToString + "' AND " + _
           " OwnerMUID = '" + _OwnerID.ToString + "' ORDER BY TS DESC"
        'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)


        _FormRequiredManHours = GetNonElementRequiredManHours()
        If dt.Rows.Count = 0 Then
            _FormCurrentLevel = 0
            _FormEarnedManHours = 0
            Return
        End If

        _FormUpdateDate = dt.Rows(0)(0)
        _FormUser = dt.Rows(0)(1)
        _FormAction = dt.Rows(0)(2)
        _FormComment = dt.Rows(0)(3).ToString

        If Not (IsDBNull(dt.Rows(0)(4))) Then
            Dim buffer() As Byte = dt.Rows(0)(4)
            Try
                Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))
                _FormESign = Image
            Catch ex As Exception

            End Try
        End If
        _FormRequiredManHours = dt.Rows(0)(5)
        _FormEarnedManHours = dt.Rows(0)(6)
        _FormCurrentLevel = dt.Rows(0)(7)
        _FormPercentComplete = IIf(_FormRequiredManHours > 0, _FormEarnedManHours / _FormRequiredManHours, 0)
        'sqlPrjUtils.CloseConnection()
    End Sub


    Public Sub FormUpdateVarValue(ByVal Var As String, ByVal Val As String)
        Dim oldVar As formItem = New formItem
        Dim newVar As formItem = New formItem
        Dim index As Integer = 0
        For Each lclvar As formItem In _formVar
            If lclvar.FieldName = Var Then
                oldVar = lclvar
                newVar = lclvar
                newVar.Value = Val
                Exit For
            End If
            index = index + 1
        Next
        _formVar.Remove(oldVar)
        _formVar.Insert(index, newVar)
    End Sub
    Public Sub FormUpdateVarCustomName(ByVal Var As String, ByVal Val As String)
        Dim oldVar As formItem = New formItem
        Dim newVar As formItem = New formItem
        Dim index As Integer = 0
        For Each lclvar As formItem In _formVar
            If lclvar.FieldName = Var Then
                oldVar = lclvar
                newVar = lclvar
                newVar.CustomName = Val
                Exit For
            End If
            index = index + 1
        Next
        _formVar.Remove(oldVar)
        _formVar.Insert(index, newVar)
    End Sub


    Public Sub UpdateAllFormStatus()
        _FormEarnedManHours = 0
        Try
            If MultiElement Then
                Try
                    UpdateFormMEPkgStatus()
                Catch ex As Exception
                    MessageBox.Show("Error processing form status.(UpdateFormMEPkgStatus)")
                End Try

                Try
                    UpdateMETagStatus()
                Catch ex As Exception
                    MessageBox.Show("Error processing form status.(UpdateMETagStatus)")
                End Try
            Else
                Try
                    UpdateFormStatus()
                Catch ex As Exception
                    MessageBox.Show("Error processing form status.(UpdateFormStatus)")
                End Try
            End If

        Catch ex As Exception
            MessageBox.Show("Error processing form status.")
        End Try
    End Sub


    Public Sub GetAllFormStatus()
        If MultiElement Then
            GetMeFormStatus()
        Else
            GetNonMeFormStatus()
        End If
    End Sub

    Public Sub UpdateFormStatus()
        Dim earnMhrs = GetNonElementWtPercentComplete() * GetNonElementRequiredManHours()
        Dim reqdMhrs = GetNonElementRequiredManHours()
        Dim qry = " SELECT MUID FROM  forms_status WHERE OwnerMUID = '" + _OwnerID.ToString + "'" + _
                    " AND FormMUID = '" + _FrmID.ToString + "' AND TagMUID = '" + _TagID.ToString + "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)

        Dim muid As String = idUtils.GetNextMUID("project", "forms_status")
        qry = "INSERT INTO forms_status (MUID, TS,OwnerMUID,TagMUID,FormMUID,UserMUID, RequiredManHours,Action,EarnedManHours,CurrentLevel,Comment) " + _
            " VALUES (" + _
            "@MUID," + _
            "@TS," + _
            "@OwnerMUID," + _
            "@TagMUID," + _
            "@FormMUID," + _
            "@UserMUID," + _
            "@RequiredManHours," + _
            "@Action," + _
            "@EarnedManHours," + _
            "@CurrentLevel," + _
            "@Comment)"

        Dim dt_param As DataTable = runtime.SQLProject.paramDT
        dt_param.Rows.Add("@MUID", muid)
        dt_param.Rows.Add("@TS", Now())
        dt_param.Rows.Add("@OwnerMUID", _OwnerID.ToString)
        dt_param.Rows.Add("@TagMUID", _TagID.ToString)
        dt_param.Rows.Add("@FormMUID", _FrmID.ToString)
        dt_param.Rows.Add("@UserMUID", _FormCurrentUserID)
        dt_param.Rows.Add("@RequiredManHours", reqdMhrs.ToString)
        dt_param.Rows.Add("@Action", _FormAction.ToString)
        dt_param.Rows.Add("@EarnedManHours", earnMhrs.ToString)
        dt_param.Rows.Add("@CurrentLevel", _FormCurrentLevel.ToString)
        dt_param.Rows.Add("@Comment", _FormComment)

        runtime.SQLProject.ExecuteNonQuery(qry, dt_param)
        'sqlPrjUtils.CloseConnection()

        SaveSignature("forms_status")

        'End If
    End Sub


    Public Sub UpdateFormMEPkgStatus()
        Dim earnMhrs = GetNonElementWtPercentComplete() * GetNonElementRequiredManHours()
        Dim reqdMhrs = GetNonElementRequiredManHours()
        Dim muid As String = idUtils.GetNextMUID("project", "forms_me_status")
        Dim qry = "INSERT INTO forms_me_status (MUID,TS,OwnerMUID,SourceMUID,SourceType,FormMUID,UserMUID, RequiredManHours,Action,EarnedManHours,CurrentLevel,Comment) " + _
            " VALUES (" + _
            "@MUID," + _
            "@TS," + _
            "@OwnerMUID," + _
            "@SourceMUID," + _
            "@SourceType," + _
            "@FormMUID," + _
            "@UserMUID," + _
            "@RequiredManHours," + _
            "@Action," + _
            "@EarnedManHours," + _
            "@CurrentLevel," + _
            "@Comment)"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        Dim dt_param As DataTable = runtime.SQLProject.paramDT
        dt_param.Rows.Add("@MUID", muid)
        dt_param.Rows.Add("@TS", Now())
        dt_param.Rows.Add("@OwnerMUID", _OwnerID.ToString)
        dt_param.Rows.Add("@SourceMUID", PackageID.ToString)
        dt_param.Rows.Add("@SourceType", "Package")
        dt_param.Rows.Add("@FormMUID", _FrmID.ToString)
        dt_param.Rows.Add("@UserMUID", _FormCurrentUserID)
        dt_param.Rows.Add("@RequiredManHours", reqdMhrs.ToString)
        dt_param.Rows.Add("@Action", _FormAction.ToString)
        dt_param.Rows.Add("@EarnedManHours", earnMhrs.ToString)
        dt_param.Rows.Add("@CurrentLevel", _FormCurrentLevel.ToString)
        dt_param.Rows.Add("@Comment", _FormComment)

        'sqlPrjUtils.OpenConnection()
        runtime.SQLProject.ExecuteNonQuery(qry, dt_param)
        'sqlPrjUtils.CloseConnection()
        SaveSignature("forms_me_status")
    End Sub


    Private Sub SaveSignature(ByVal tblName As String)
        Try
            Dim qryID = "SELECT MUID From " + tblName + " ORDER By TS DESC"
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qryID)

            Dim ID As String
            If dt.Rows.Count > 0 Then
                ID = dt.Rows(0)(0)
            Else : Return

            End If

            If Not _FormESign Is Nothing Then
                Dim m As New MemoryStream
                _FormESign.Save(m, ImageFormat.Png)
                Dim buffer As Byte() = m.GetBuffer

                Dim query As String = "UPDATE " + tblName + " SET Esign = @Esign WHERE MUID = '" + ID.ToString + "'"
                runtime.SQLProject.ExecuteSingleParameterizedQuery(query, "@Esign", buffer)

            End If
            'sqlPrjUtils.CloseConnection()
        Catch ex As Exception
            MessageBox.Show("Error saving signature to database.(SaveSignature)")
        End Try


    End Sub
    Public Sub UpdateElementTagStatus(ByVal myTagID As String, ByVal reqMhrs As Single, ByVal EarnedHrs As Single)
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim muid As String = idUtils.GetNextMUID("project", "forms_me_status")
        Dim qry = "INSERT INTO forms_me_status (MUID,TS,OwnerMUID,SourceMUID,FormMUID,UserMUID,Action,Comment,CurrentLevel,RequiredManHours,EarnedManHours,SourceType) " + _
            " VALUES (" + _
            "@MUID," + _
            "@TS," + _
            "@OwnerMUID," + _
            "@SourceMUID," + _
            "@FormMUID," + _
            "@UserMUID," + _
            "@Action," + _
            "@Comment," + _
            "@CurrentLevel," + _
            "@RequiredManHours," + _
            "@EarnedManHours," + _
            "@SourceType)"


        Dim dt_param As DataTable = runtime.SQLProject.paramDT
        dt_param.Rows.Add("@MUID", muid)
        dt_param.Rows.Add("@TS", Now())
        dt_param.Rows.Add("@OwnerMUID", _OwnerID.ToString)
        dt_param.Rows.Add("@SourceMUID", myTagID.ToString)
        dt_param.Rows.Add("@SourceType", "Tag")
        dt_param.Rows.Add("@FormMUID", _FrmID.ToString)
        dt_param.Rows.Add("@UserMUID", _FormCurrentUserID)
        dt_param.Rows.Add("@RequiredManHours", reqMhrs.ToString)
        dt_param.Rows.Add("@Action", _FormAction.ToString)
        dt_param.Rows.Add("@EarnedManHours", EarnedHrs.ToString)
        dt_param.Rows.Add("@CurrentLevel", _FormCurrentLevel.ToString)
        dt_param.Rows.Add("@Comment", _FormComment)

        runtime.SQLProject.ExecuteNonQuery(qry, dt_param)
        'sqlPrjUtils.CloseConnection()
        ' End If
    End Sub
    Public Sub UpdateMETagStatus()
        Dim eid As Integer = 0
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()

        For i As Integer = 0 To _formVar.Count - 1
            Dim itm As formItem = _formVar(i)
            If itm.linkTbl = "" And itm.Value > "" Then
                If itm.FieldName.Contains("Element") Then
                    Dim elmName As String = itm.FieldName.Split("@")(0)
                    If itm.FieldName.Contains("TagNumber") Then
                        ReDim Preserve ElementTags(eid)
                        ElementTags(eid)._ElementName = elmName
                        Dim qry = " SELECT MUID FROM tags WHERE TagNumber = '" + itm.Value + "'"
                        'ElementTags(eid)._TagID = Utilities.ExecuteQuery(qry, "project").Rows(0)(0)
                        ElementTags(eid)._TagID = runtime.SQLProject.ExecuteQuery(qry).Rows(0)(0)

                        ElementTags(eid)._ReqManHours = GetSingleElementRequiredManHours().ToString
                        ElementTags(eid)._EarnedManHoursPerVariable = ElementTags(eid)._ReqManHours / _SubElementVarCount
                        ElementTags(eid)._EarnedManHours = 0
                        eid = eid + 1
                    End If
                End If
            End If
        Next

        For i As Integer = 0 To _formVar.Count - 1
            Dim itm As formItem = _formVar(i)
            If itm.linkTbl = "" And itm.Value > "" Then
                If itm.FieldName.Contains("Element") Then
                    Dim elmName As String = itm.FieldName.Split("@")(0)
                    If Not IsReservedElement(itm.FieldName) Then
                        For j As Integer = 0 To ElementTags.Length - 1
                            If ElementTags(j)._ElementName = elmName Then
                                ElementTags(j)._EarnedManHours = ElementTags(j)._EarnedManHours + ElementTags(j)._EarnedManHoursPerVariable
                                _FormEarnedManHours = _FormEarnedManHours + ElementTags(j)._EarnedManHoursPerVariable
                            End If
                        Next
                    End If
                End If
            End If
        Next
        If ElementTags.Length > 0 Then
            For Each elm As ElementTagKeyValue In ElementTags
                UpdateElementTagStatus(elm._TagID, elm._ReqManHours, elm._EarnedManHours)
            Next
        End If
        'For Each elm As ElementTagKeyValue In ElementTags
        '    UpdateElementTagStatus(elm._TagID, elm._ReqManHours, elm._EarnedManHours)
        'Next
        'sqlPrjUtils.CloseConnection()
    End Sub




    Public Shared Function ResizeImage(ByVal oldImage As Image, ByVal Magnification As Single) As Image
        Dim newSize As Size
        newSize.Width = CType((Magnification * CType(oldImage.Size.Width, Single)), Integer)
        newSize.Height = CType((Magnification * CType(oldImage.Size.Height, Single)), Integer)
        Using newImage As Bitmap = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
            Using canvas As Graphics = Graphics.FromImage(newImage)
                canvas.SmoothingMode = SmoothingMode.AntiAlias
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic
                canvas.PixelOffsetMode = PixelOffsetMode.HighQuality
                canvas.DrawImage(oldImage, New Rectangle(New Point(0, 0), newSize))
                Dim m As New MemoryStream
                newImage.Save(m, ImageFormat.Png)
                Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(m)
                Return Image
            End Using
        End Using
    End Function
    Public Shared Function ResizeImage(ByVal oldImage As Image, ByVal Width As Single, ByVal Height As Single) As Image
        Dim newSize As Size
        newSize.Width = Width
        newSize.Height = Height
        Using newImage As Bitmap = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
            Using canvas As Graphics = Graphics.FromImage(newImage)
                canvas.SmoothingMode = SmoothingMode.AntiAlias
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic
                canvas.PixelOffsetMode = PixelOffsetMode.HighQuality
                canvas.FillRectangle(Brushes.White, 0, 0, Width, Height)
                canvas.DrawImage(oldImage, New Rectangle(New Point(0, 0), newSize))
                Dim m As New MemoryStream
                newImage.Save(m, ImageFormat.Png)
                Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(m)
                Return Image
            End Using
        End Using
    End Function
    Public Sub remoteDeleteFormVar(ByVal itm As formItem)
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim query As String = "DELETE forms_update WHERE SourceType=@SourceType AND MUID=@MUID"

        Dim dt_param As DataTable = runtime.SQLProject.paramDT
        dt_param.Rows.Add("@SourceType", "Tag")
        dt_param.Rows.Add("@MUID", itm.FieldID.ToString)

        runtime.SQLProject.ExecuteNonQuery(query, dt_param)



        If MultiElement And Left(itm.FieldName, 7) = "Element" Then
            query = "DELETE aux_subforms_info WHERE MUID=@MUID"

            dt_param = runtime.SQLProject.paramDT
            dt_param.Rows.Add("@MUID", itm.FieldID.ToString)

            runtime.SQLProject.ExecuteNonQuery(query, dt_param)


            Dim PagesNeeded As Integer = 1
            If NumberofElements > 0 Then
                PagesNeeded = Math.Ceiling(Utilities.GetFormMaxTagCount(_FrmID) / NumberofElements)
            End If
            For i As Integer = 0 To PagesNeeded - 1
                Dim ElementName() As String = Split(itm.FieldName, "@")
                Dim ElementNumber As Integer = CInt(Replace(ElementName(0), "Element", ""))
                Dim NewNumber As Integer = ElementNumber + (i * NumberofElements)
                Dim NewName As String = "Element" + NewNumber.ToString + "@" + ElementName(1)

                query = "DELETE aux_forms_info WHERE FormMUID=@FormMUID AND AuxData LIKE @AuxData"
                dt_param = runtime.SQLProject.paramDT
                dt_param.Rows.Add("@FormMUID", Me._FrmID.ToString)
                dt_param.Rows.Add("@AuxData", NewName + "%")

                runtime.SQLProject.ExecuteNonQuery(query, dt_param)
            Next
        Else
            query = "DELETE aux_forms_info WHERE MUID=@MUID"
            dt_param = runtime.SQLProject.paramDT
            dt_param.Rows.Add("@MUID", itm.FieldID.ToString)

            runtime.SQLProject.ExecuteNonQuery(query, dt_param)
        End If
        'sqlPrjUtils.CloseConnection()
    End Sub

    Public Sub remoteAddUpdateFormVar(ByVal itm As formItem)
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim ElementTest As String = Left(itm.FieldName, 7)
        Dim AuxTable As String

        If ElementTest = "Element" Then
            AuxTable = "aux_subforms_info"
        Else
            AuxTable = "aux_forms_info"
        End If

        Dim query As String = ""
        Dim fieldStr As String = _
                itm.FieldName + "&001" + _
                itm.MapName + "&001" + _
                itm.linkTbl + "&001" + _
                itm.Value + "&001" + _
                itm.WtPcnt.ToString + "&001" + _
                itm.Color + "&001" + _
                itm.DataType.Number.ToString + "&001" + _
                itm.PgNum.ToString + "&001" + _
                itm.View + "&001" + _
                itm.Position.ToString + "&001" + _
                itm.PosX.ToString + "&001" + _
                itm.PosY.ToString + "&001" + _
                itm.Width.ToString + "&001" + _
                itm.Height.ToString + "&001" + _
                itm.TabPosition.ToString + "&001" + _
                itm.FontName + "&001" + _
                itm.FontSize.ToString + "&001" + _
                itm.FontBold.ToString + "&001" + _
                itm.FontItalic.ToString + "&001" + _
                itm.FontUnderline.ToString + "&001" + _
                itm.GroupID.ToString + "&001" + _
                itm.CustomName.ToString + "&001"

        Try

            Dim IDD As String = itm.FieldID
            If Not itm.FieldID = "" Then
                Dim qryUpdate = "UPDATE " + AuxTable + _
                    " SET TS=@TS,FormMUID=@FormMUID,AuxData=@AuxData" + _
                            " WHERE MUID=@MUID"

                Dim dt_param As DataTable = runtime.SQLProject.paramDT
                dt_param.Rows.Add("@TS", DateTime.Now.ToString)
                dt_param.Rows.Add("@FormMUID", _FrmID.ToString)
                dt_param.Rows.Add("@AuxData", fieldStr)
                dt_param.Rows.Add("@MUID", itm.FieldID.ToString)

                runtime.SQLProject.ExecuteNonQuery(qryUpdate, dt_param)
            Else
                Dim muid As String = idUtils.GetNextMUID("project", AuxTable)
                Dim qryInsert = "INSERT INTO " + AuxTable + " " + _
                             "(MUID, TS,FormMUID,AuxData ) VALUES (@MUID,@TS,@FormMUID,@AuxData)"

                Dim dt_param As DataTable = runtime.SQLProject.paramDT
                dt_param.Rows.Add("@MUID", muid)
                dt_param.Rows.Add("@TS", DateTime.Now.ToString)
                dt_param.Rows.Add("@FormMUID", _FrmID.ToString)
                dt_param.Rows.Add("@AuxData", fieldStr)

                runtime.SQLProject.ExecuteNonQuery(qryInsert, dt_param)
            End If

            If ElementTest = "Element" Then
                Dim PagesNeeded As Integer = Math.Ceiling(Utilities.GetFormMaxTagCount(_FrmID) / NumberofElements)
                For i As Integer = 0 To PagesNeeded - 1

                    Dim ElementName() As String = Split(itm.FieldName, "@")
                    Dim ElementNumber As Integer = CInt(Replace(ElementName(0), "Element", ""))
                    Dim NewNumber As Integer = ElementNumber + (i * NumberofElements)
                    Dim NewName As String = "Element" + NewNumber.ToString + "@" + ElementName(1)

                    Dim NewGroup As String
                    If itm.GroupID > 0 Then
                        NewGroup = (CInt(itm.GroupID) + (100 * ((i + 1) * NumberofElements))).ToString
                    Else
                        NewGroup = ""
                    End If

                    query = " SELECT * FROM aux_forms_info WHERE AuxData LIKE '" + NewName + "%' and FormMUID='" + Me._FrmID.ToString + "'"
                    Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

                    If dt.Rows.Count = 0 Then

                    Else
                        fieldStr = _
                                NewName + "&001" + _
                                NewName + "&001" + _
                                itm.linkTbl + "&001" + _
                                itm.Value + "&001" + _
                                itm.WtPcnt.ToString + "&001" + _
                                itm.Color + "&001" + _
                                itm.DataType.Number.ToString + "&001" + _
                                i.ToString + "&001" + _
                                itm.View + "&001" + _
                                itm.Position.ToString + "&001" + _
                                itm.PosX.ToString + "&001" + _
                                itm.PosY.ToString + "&001" + _
                                itm.Width.ToString + "&001" + _
                                itm.Height.ToString + "&001" + _
                                itm.TabPosition.ToString + "&001" + _
                                itm.FontName + "&001" + _
                                itm.FontSize.ToString + "&001" + _
                                itm.FontBold.ToString + "&001" + _
                                itm.FontItalic.ToString + "&001" + _
                                itm.FontUnderline.ToString + "&001" + _
                                NewGroup.ToString + "&001" + _
                                NewName + "&001"

                        query = " UPDATE aux_forms_info SET TS=@TS,FormMUID=@FormMUID,AuxData=@AuxData WHERE MUID=@MUID"

                        Dim dt_param As DataTable = runtime.SQLProject.paramDT
                        dt_param.Rows.Add("@TS", DateTime.Now.ToString)
                        dt_param.Rows.Add("@FormMUID", _FrmID.ToString)
                        dt_param.Rows.Add("@AuxData", fieldStr)
                        dt_param.Rows.Add("@MUID", dt.Rows(0)("MUID").ToString)

                        runtime.SQLProject.ExecuteNonQuery(query, dt_param)

                    End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("444 " + ex.Message)
        End Try
        'sqlPrjUtils.CloseConnection()
    End Sub

    Public Sub SaveFieldValues()
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()

        Dim qryID As String = ""
        Dim query As String = ""
        For i As Integer = 0 To _formVar.Count - 1
            Dim itm As formItem = _formVar(i)
            If itm.linkTbl = "" Then
                'cmdID.Parameters("@FieldID").Value = itm.FieldID.ToString

                'add TagID here
                Dim SourceType As String = "Tag"
                Dim SourceID As String = _TagID
                If MultiElement Then
                    If Not Left(itm.FieldName, 7) = "Element" Then
                        SourceID = PackageID
                        SourceType = "Package"
                        qryID = " SELECT MUID FROM forms_update " + _
                            " WHERE(RequirementMUID = '" + Me._RequirementID + "'" + _
                            ") And (SourceMUID = '" + PackageID.ToString + "'" + _
                            ") AND (SourceType= 'Package' " + _
                            ") And (FieldMUID = '" + itm.FieldID.ToString + "'"
                    Else
                        Dim NameArray() As String = Split(itm.FieldName, "@")
                        Dim ElementNumber As Integer = CInt(Replace(NameArray(0), "Element", ""))
                        Dim ElementField As String = NameArray(1)
                        SourceID = dt_TagList.Rows(ElementNumber - 1)(0)
                        SourceType = "Tag"
                        qryID = " SELECT MUID FROM forms_update " + _
                            " WHERE(RequirementMUID = '" + GetMERequirementID(SourceID, SourceType) + "'" + _
                            ") And (SourceMUID = '" + dt_TagList.Rows(ElementNumber - 1)(0).ToString + "'" + _
                            ") AND (SourceType= 'Tag' " + _
                            ") And (FieldMUID = '" + itm.FieldID.ToString + "')"
                    End If
                End If
                Dim ID As String = ""
                If qryID > "" Then
                    Dim dt1 As DataTable = runtime.SQLProject.ExecuteQuery(qryID)
                    If dt1.Rows.Count > 0 Then
                        ID = dt1.Rows(0)(0)
                    End If
                End If
                If Not ID = "" Then
                    query = " UPDATE forms_update SET TS = @TS," & _
                        " DateStamp = @DateStamp, " & _
                        " RequirementMUID = @RequirementMUID, " & _
                        " SourceMUID = @SourceMUID, " & _
                        " FieldMUID = @FieldMUID, " & _
                        " FieldValue = @FieldValue " + _
                        " WHERE SourceType=@SourceType AND MUID=@MUID"

                    Dim dt_param As DataTable = runtime.SQLProject.paramDT
                    dt_param.Rows.Add("@TS", Now())
                    dt_param.Rows.Add("@DateStamp", DateTime.Now.ToString)
                    dt_param.Rows.Add("@RequirementMUID", GetMERequirementID(SourceID, SourceType))
                    dt_param.Rows.Add("@SourceMUID", SourceID)
                    dt_param.Rows.Add("@FieldMUID", itm.FieldID)
                    dt_param.Rows.Add("@FieldValue", itm.Value)
                    dt_param.Rows.Add("@SourceType", SourceType)
                    dt_param.Rows.Add("@MUID", ID.ToString)

                    runtime.SQLProject.ExecuteNonQuery(query, dt_param)
                Else
                    Dim muid As String = idUtils.GetNextMUID("project", "forms_update")
                    query = " INSERT INTO forms_update (MUID,TS, DateStamp, RequirementMUID, SourceMUID, FieldMUID, FieldValue, SourceType) VALUES ( " + _
                        " @MUID,@TS, " & _
                        " @DateStamp, " & _
                        " @RequirementMUID, " & _
                        " @SourceMUID, " & _
                        " @FieldMUID, " & _
                        " @FieldValue, " & _
                        " @SourceType)"

                    Dim dt_param As DataTable = runtime.SQLProject.paramDT
                    dt_param.Rows.Add("@MUID", muid)
                    dt_param.Rows.Add("@TS", Now())
                    dt_param.Rows.Add("@DateStamp", DateTime.Now.ToString)
                    dt_param.Rows.Add("@RequirementMUID", GetMERequirementID(SourceID, SourceType))
                    dt_param.Rows.Add("@SourceMUID", SourceID.ToString)
                    dt_param.Rows.Add("@FieldMUID", itm.FieldID.ToString)
                    dt_param.Rows.Add("@FieldValue", itm.Value)
                    dt_param.Rows.Add("@SourceType", SourceType)

                    runtime.SQLProject.ExecuteNonQuery(query, dt_param)
                End If

                If Left(itm.FieldName, 9) = "Signature" Then
                    If Not itm.image Is Nothing Then
                        query = "SELECT * FROM forms_image WHERE FormMUID='0' AND Aux05='" + ID.ToString + "'"
                        'Dim dt As DataTable = Utilities.ExecuteQuery(query, "project")
                        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
                        Dim muid As String = idUtils.GetNextMUID("project", "forms_image")
                        If dt.Rows.Count = 0 Then
                            query = "INSERT INTO forms_image (MUID, TS,FormMUID,Aux05,FormImage) VALUES ('" + muid + "','" + Now() + "','','" + ID.ToString + "',@image)"
                            Dim m As New MemoryStream
                            itm.image.Save(m, ImageFormat.Png)
                            Dim buffer As Byte() = m.GetBuffer
                            'Utilities.ExecuteSingleParameterizedScalar(query, "@image", buffer, "project")
                            runtime.SQLProject.ExecuteSingleParameterizedQuery(query, "@image", buffer)
                        Else
                            query = "UPDATE forms_image SET TS='" + Now() + "',FormImage=@image WHERE FormMUID='' AND Aux05='" + ID.ToString + "'"
                            Dim m As New MemoryStream
                            itm.image.Save(m, ImageFormat.Png)
                            Dim buffer As Byte() = m.GetBuffer

                            runtime.SQLProject.ExecuteSingleParameterizedQuery(query, "@image", buffer)
                        End If

                    Else
                        query = "DELETE FROM forms_image WHERE FormMUID=@FormMUID AND Aux05=@Aux05"

                        Dim dt_param As DataTable = runtime.SQLProject.paramDT
                        dt_param.Rows.Add("@FormMUID", "0")
                        dt_param.Rows.Add("@Aux05", ID.ToString)

                        runtime.SQLProject.ExecuteNonQuery(query, dt_param)

                    End If
                End If
            End If
        Next
        'sqlPrjUtils.CloseConnection()
    End Sub


    Private Sub GetFormImageList()
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim query As String = "SELECT FormImage FROM forms_image WHERE FormMUID ='" + _FrmID.ToString + "' ORDER By PageNumber;"
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        'sqlPrjUtils.CloseConnection()
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim buffer() As Byte = dt.Rows(i)(0)
            Dim Img As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))
            Dim image As Bitmap = New Bitmap(Img)

            If MultiElement And _FormMode = "View" Then
                'Dim PagesNeeded As Integer = Math.Ceiling(Utilities.GetFormMaxTagCount(_FrmID) / NumberofElements)
                Dim PagesNeeded As Integer = Math.Ceiling(Me.dt_TagList.Rows.Count / NumberofElements)
                MEPageCount = PagesNeeded
                For j As Integer = 1 To PagesNeeded
                    _imgList.Add(image)
                Next
            Else
                _imgList.Add(image)
            End If
        Next
    End Sub


    Public Function MakeFormPgInfo(ByVal pgSize As Size)
        If _imgList.Count = 0 Then Return Nothing
        Dim pgInfo() As PrintUtils.InfoSetting

        Dim pgCtr As Integer = 0
        For pgNum As Integer = 0 To _imgList.Count - 1

            ReDim Preserve pgInfo(pgCtr)
            pgInfo(pgCtr).Landscape = False
            pgInfo(pgCtr).PrintHdr = False
            pgInfo(pgCtr).PrintFooter = False
            pgInfo(pgCtr).Heading = " "
            pgInfo(pgCtr).SubHeading = " "
            pgInfo(pgCtr).PgNum = pgCtr
            pgInfo(pgCtr).pSize = pgSize
            pgInfo(pgCtr).pprKind = PrintUtils.GetPaperKind(_imgList(pgNum).Width, _imgList(pgNum).Height)
            Dim j As Integer = 0
            ReDim Preserve pgInfo(pgCtr).pgBody(j)
            Dim imgFile As String = PrintUtils.GetNextImageFileName()
            _imgList(pgNum).Save(imgFile, System.Drawing.Imaging.ImageFormat.Png)
            If _imgList(pgNum).Height < _imgList(pgNum).Width Then
                pgInfo(pgCtr).Landscape = True
            End If
            Dim mSize As Size = New Size(_imgList(pgNum).Width, _imgList(pgNum).Height)
            pgInfo(pgCtr).pSize = mSize
            pgInfo(pgCtr).pgBody(j).contentType = PrintUtils.pgContentType.docImage
            pgInfo(pgCtr).pgBody(j).obj = imgFile
            pgInfo(pgCtr).pgBody(j).loc = New Point(0, 0)
            For Each itm As formItem In _formVar
                If itm.PgNum = pgNum Then
                    'Dim canvas As Graphics = Graphics.FromImage(_bmpImgList(itm.PgNum))
                    Dim drawFont As System.Drawing.Font = New Font(itm.FontName, itm.FontSize, _
                                IIf(itm.FontBold, FontStyle.Bold, IIf(itm.FontItalic, FontStyle.Italic, _
                                IIf(itm.FontUnderline, FontStyle.Underline, FontStyle.Regular))), GraphicsUnit.Point)

                    Dim myPen As New Pen(Brushes.Blue, 1)
                    If itm.image Is Nothing Then
                        If InStr(itm.FieldName, "@") > 0 Then
                            j = j + 1
                            ReDim Preserve pgInfo(pgCtr).pgBody(j)
                            pgInfo(pgCtr).pgBody(j).contentType = PrintUtils.pgContentType.text
                            pgInfo(pgCtr).pgBody(j).obj = itm.Value
                            pgInfo(pgCtr).pgBody(j).mfont = drawFont
                            pgInfo(pgCtr).pgBody(j).loc = New Point(itm.PosX, itm.PosY)
                            pgInfo(pgCtr).pgBody(j).foreColor = Color.Red 'RGB(255, 0, 0)
                            'pgInfo(pgCtr).pgBody(j).sz = TextRenderer.MeasureText(itm.Value, drawFont)
                            pgInfo(pgCtr).pgBody(j).sz = New Size(itm.Width, itm.Height)

                            'canvas.DrawString(itm.Value, drawFont, Brushes.Red, itm.PosX, itm.PosY)
                        Else
                            j = j + 1
                            ReDim Preserve pgInfo(pgCtr).pgBody(j)
                            pgInfo(pgCtr).pgBody(j).contentType = PrintUtils.pgContentType.text
                            pgInfo(pgCtr).pgBody(j).obj = itm.Value
                            pgInfo(pgCtr).pgBody(j).loc = New Point(itm.PosX, itm.PosY)
                            pgInfo(pgCtr).pgBody(j).mfont = drawFont
                            pgInfo(pgCtr).pgBody(j).foreColor = Color.Blue 'RGB(0, 0, 255)
                            'pgInfo(pgCtr).pgBody(j).sz = TextRenderer.MeasureText(itm.Value, drawFont)
                            pgInfo(pgCtr).pgBody(j).sz = New Size(itm.Width, itm.Height)
                            '5:
                            'canvas.DrawString(itm.Value, drawFont, Brushes.Blue, itm.PosX, itm.PosY)
                        End If
                    Else
                        j = j + 1
                        ReDim Preserve pgInfo(pgCtr).pgBody(j)
                        imgFile = PrintUtils.GetNextImageFileName()
                        pgInfo(pgCtr).pgBody(j).contentType = PrintUtils.pgContentType.image
                        pgInfo(pgCtr).pgBody(j).obj = imgFile
                        pgInfo(pgCtr).pgBody(j).loc = New Point(itm.PosX, itm.PosY)

                        If Mid(itm.FieldName, 1, 9) = "Signature" Then
                            Dim bmp_New As New Bitmap(itm.Width, itm.Height)
                            Dim canvas As Graphics = Nothing
                            canvas = Graphics.FromImage(bmp_New)
                            canvas.FillRectangle(Brushes.White, 0, 0, itm.Width, itm.Height)
                            canvas.DrawImage(itm.image, New Rectangle(0, 0, itm.Width, itm.Height))

                            bmp_New.Save(imgFile)
                        Else
                            itm.image.Save(imgFile)
                        End If

                    End If
                End If
            Next
            pgCtr = pgCtr + 1
        Next

        Return pgInfo
    End Function

    Public Sub InitializeFormPrintImage()
        Dim _bmpImgList As New List(Of Image)
        For i As Integer = 0 To _imgList.Count - 1
            _bmpImgList.Add(New Bitmap(_imgList(i)))
        Next

        For Each itm As formItem In _formVar
            Dim canvas As Graphics = Graphics.FromImage(_bmpImgList(itm.PgNum))
            Dim drawFont As System.Drawing.Font = New Font(itm.FontName, itm.FontSize, _
                        IIf(itm.FontBold, FontStyle.Bold, IIf(itm.FontItalic, FontStyle.Italic, _
                        IIf(itm.FontUnderline, FontStyle.Underline, FontStyle.Regular))), GraphicsUnit.Point)

            Dim myPen As New Pen(Brushes.Blue, 1)
            If itm.image Is Nothing Then
                If InStr(itm.FieldName, "@") > 0 Then
                    canvas.DrawString(itm.Value, drawFont, Brushes.Red, itm.PosX, itm.PosY)
                Else
                    canvas.DrawString(itm.Value, drawFont, Brushes.Blue, itm.PosX, itm.PosY)
                End If
            Else
                canvas.DrawImage(itm.image, New Rectangle(itm.PosX, itm.PosY, itm.Width, itm.Height))
            End If
        Next
        For i As Integer = 0 To _PrintImgList.Count - 1
            _PrintImgList(i).Dispose()
        Next
        _PrintImgList.Clear()
        For i As Integer = 0 To _bmpImgList.Count - 1
            Dim m As New MemoryStream
            _bmpImgList(i).Save(m, ImageFormat.Png)
            Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(m)
            _bmpImgList(i).Dispose()
            _PrintImgList.Add(Image)
        Next
    End Sub

    Public Sub InitializeFormImage()
        For Each itm As formItem In _formVar
            Dim canvas As Graphics = Graphics.FromImage(_imgList(itm.PgNum))
            Dim drawFont As System.Drawing.Font = New Font(itm.FontName, itm.FontSize, _
                        IIf(itm.FontBold, FontStyle.Bold, IIf(itm.FontItalic, FontStyle.Italic, _
                        IIf(itm.FontUnderline, FontStyle.Underline, FontStyle.Regular))), GraphicsUnit.Point)
            'TextRenderer.DrawText(canvas, itm.Value, drawFont, New Point(itm.PosX, itm.PosY), System.Drawing.Color.FromArgb(itm.Color))
            Dim myPen As New Pen(Brushes.Blue, 1)
            If itm.image Is Nothing Then
                canvas.DrawString(itm.Value, drawFont, Brushes.Black, itm.PosX, itm.PosY)
            Else
                canvas.DrawImage(itm.image, New Rectangle(itm.PosX, itm.PosY, itm.Width, itm.Height))
            End If
            'canvas.DrawRectangle(myPen, itm.PosX, itm.PosY, itm.Width, itm.Height)

        Next
    End Sub

    Private Sub GetSignOffInfo(ByRef itm As formItem)
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        'sqlSrvUtils.OpenConnection()
        'sqlPrjUtils.OpenConnection()
        Dim qrySt As String
        Dim SignOff() As String = Split(itm.linkTbl, "SignOff_Level")

        If MultiElement Then
            qrySt = "SELECT UserMUID,TS,OwnerMUID,Esign,MUID FROM Forms_me_status WHERE CurrentLevel = '" + _
                    SignOff(1) + "'" + _
                    " AND OwnerMUID ='" + _OwnerID.ToString + "'" + _
                    " AND SourceMUID ='" + PackageID.ToString + "'" + _
                    " AND FormMUID ='" + _FrmID.ToString + "'" + _
                    " AND SourceType = 'Package'" & _
                    " ORDER BY TS DESC"
        Else
            qrySt = "SELECT UserMUID,TS,OwnerMUID,Esign,MUID FROM Forms_status WHERE CurrentLevel = '" + _
                    (Convert.ToInt32(SignOff(1))).ToString + "'" + _
                    " AND OwnerMUID ='" + _OwnerID.ToString + "'" + _
                    " AND TagMUID ='" + _TagID.ToString + "'" + _
                    " AND FormMUID ='" + _FrmID.ToString + "'" + _
                    " ORDER BY TS DESC"
        End If

        'Dim st As DataTable = Utilities.ExecuteQuery(qrySt, "project")
        Dim st As DataTable = runtime.SQLProject.ExecuteQuery(qrySt)

        If st.Rows.Count < 1 Then Return
        Dim qryUI = "SELECT FirstName, MI, LastName, Number, CompanyMUID FROM userInfo WHERE MUID = '" + _
            st.Rows(0)(0).ToString + "'"

        Dim ui As DataTable = runtime.SQLServer.ExecuteQuery(qryUI)

        Select Case itm.MapName
            Case "Name"
                itm.Value = ui.Rows(0)(0) + " " + ui.Rows(0)(1) + ". " + ui.Rows(0)(2)
            Case "Number"
                itm.Value = ui.Rows(0)(3)
            Case "Company"
                Dim qryCO = "SELECT Name FROM Company WHERE MUID = '" + ui.Rows(0)(4).ToString + "'"
                itm.Value = runtime.SQLServer.ExecuteQuery(qryCO).Rows(0)(0)

            Case "Title"
                itm.Value = ui.Rows(0)(3)
            Case "Date"
                itm.Value = st.Rows(0)(1)
            Case "Signature"
                itm.Value = ""
                If Not IsDBNull(st.Rows(0)(3)) Then
                    Dim buffer() As Byte = st.Rows(0)(3)
                    Try
                        If buffer.Length > 0 Then
                            Dim tempImage As Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))
                            itm.image = ResizeImage(tempImage, itm.Width, itm.Height)
                            'itm.image = System.Drawing.Image.FromStream(New MemoryStream(buffer))
                        End If
                    Catch ex As Exception

                    End Try
                End If
        End Select
        'sqlPrjUtils.CloseConnection()
        'sqlSrvUtils.CloseConnection()
    End Sub
    Private Sub GetItemLinkVarValue(ByRef itm As formItem)
        If Left(itm.linkTbl, 7) = "Element" Then Return

        If Me._FormMode = "Edit" Then Return

        itm.Value = ""
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")

        'sqlSrvUtils.OpenConnection()
        'sqlPrjUtils.OpenConnection()

        If itm.linkTbl > "" Then
            Dim SignOff() As String = Split(itm.linkTbl, "SignOff_Level")
            If SignOff.Length > 1 Then
                If _FormCurrentLevel > 0 Then
                    Dim SignOffLevel As Integer = SignOff(1)
                    If SignOffLevel <= _FormCurrentLevel Then
                        GetSignOffInfo(itm)
                    End If
                End If
            Else

                If itm.linkTbl = "Documents" Then
                    itm.Value = GetDocumentType(itm)
                ElseIf itm.linkTbl = "Package Auxiliary Data" Then
                    itm.Value = FormLocalPkgAuxFieldValue(itm.MapName)
                ElseIf itm.linkTbl = "Tag Auxiliary Data" Then
                    itm.Value = FormLocalTagAuxFieldValue(itm.MapName)
                ElseIf itm.linkTbl = "Project Info" Then
                    itm.Value = FormProjectInfoFieldValue(itm.MapName)
                ElseIf itm.linkTbl = "System Info" Then
                    itm.Value = Me.FormSystemInfoFieldValue(itm.MapName)
                ElseIf itm.linkTbl = "Handover Info" Then
                    itm.Value = FormLocalTagAuxFieldValue(itm.MapName)
                Else
                    Dim WHEREStr As String = ""
                    If itm.linkTbl = "tags" Then
                        WHEREStr = " WHERE MUID = '" + _TagID.ToString + "'"
                    End If

                    Dim OrderBY As String = ""
                    If itm.linkTbl = "engineering_data" Then
                        WHEREStr = " WHERE TagMUID = '" + _TagID.ToString + "'"
                        OrderBY = " Order By TS Desc"
                    End If

                    Dim LocalMap As String = itm.MapName
                    If itm.linkTbl = "package" Then
                        If LocalMap = "SystemNumber" Then
                            LocalMap = "SystemMUID"
                        End If
                        WHEREStr = " WHERE MUID = '" + Me.PackageID + "'"
                    End If

                    Dim query As String = " SELECT " + LocalMap + " From " + itm.linkTbl + WHEREStr + OrderBY
                    Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)

                    If dt.Rows.Count > 0 Then
                        itm.Value = dt.Rows(0)(0)

                        'itm.Value = SystemManager.SystemDataManager.TranslateSystemID(itm.Value)
                        If LocalMap = "SystemMUID" Then
                            itm.Value = SystemManager.SystemDataManager.TranslateSystemID(itm.Value)
                        End If
                    End If

                End If
            End If
        End If

    End Sub

    Private Function GetDocumentType(ByRef itm As formItem)
        Dim dTypeCode As String = "undefined"
        Dim qry = "SELECT DocumentMUID FROM package_documents" + _
                " WHERE PackageMUID = '" + PackageID + "'"

        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)

        Dim DrawingNumber As String = "undefined"
        Dim dc As DataColumn = New DataColumn
        dc.ColumnName = "TypeID"
        dt.Columns.Add(dc)
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim qry1 = "SELECT DocumentTypeMUID, EngCode FROM documents " + _
                    " WHERE MUID = '" + dt.Rows(i)(0).ToString + "'"

            Dim dt1 As DataTable = runtime.SQLDaqument.ExecuteQuery(qry1)
            Dim dTypeID As String = dt1.Rows(0)(0)
            Dim qry2 = "SELECT Code FROM document_type " + _
                                " WHERE MUID = '" + dt1.Rows(0)(0).ToString + "'"

            Dim dt2 As DataTable = runtime.SQLDaqument.ExecuteQuery(qry2)
            dTypeCode = dt2.Rows(0)(0)

            If dTypeCode = itm.MapName Then
                DrawingNumber = dt1.Rows(0)(1)
                'sqlDocUtils.CloseConnection()
                Return DrawingNumber
            End If
        Next
        'sqlDocUtils.CloseConnection()
        Return DrawingNumber
    End Function


    Private Sub GetElementVarValue(ByRef itm As formItem)
        Dim query As String = Nothing
        'Dim dt As New DataTable
        'Example of aux_field_info
        'Element17@contractor_initials&001Element2@contractor_initials&001&001&0010&001-986896&001Number&0011&001&0019&001532&001310&001115&00125&001109&001Segoe UI&0019&001False&001False&001False&0010&001Element2@contractor_initials&001
        'This will be hit if the field says Element
        'itm.FieldName = Element17@contractorinitials


        Dim NameArray() As String = Split(itm.FieldName, "@")
        'NameArray will contain [Element17, contractorinitials ]

        Dim ElementNumber As Integer = CInt(Replace(NameArray(0), "Element", ""))
        'ElementNumber = 17

        Dim ElementField As String = NameArray(1)
        'ElementField = contractorinitials
        If ElementNumber < TagCount + 1 Then

            If ElementField = "TagNumber" Then
                itm.Value = dt_TagList.Rows(ElementNumber - 1)(2)
                Return
            End If

            query = "SELECT * FROM engineering_data WHERE TagMUID = '" + dt_TagList.Rows(ElementNumber - 1)(0).ToString + "' ORDER BY TS DESC"
            'dt = Utilities.ExecuteQuery(query, "project")
            'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
            'sqlPrjUtils.OpenConnection()
            Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
            'sqlPrjUtils.CloseConnection()

            If Not dt.Rows.Count = 0 Then
                If ElementField = "Description" Then
                    itm.Value = dt.Rows(0)(5)
                    Return
                ElseIf ElementField = "Remarks" Then
                    itm.Value = dt.Rows(0)(3)
                    Return
                ElseIf ElementField = "Service" Then
                    itm.Value = dt.Rows(0)(6)
                    Return
                ElseIf ElementField = "Manufacturer" Then
                    itm.Value = dt.Rows(0)(7)
                    Return
                ElseIf ElementField = "ModelNumber" Then
                    itm.Value = dt.Rows(0)(8)
                    Return
                ElseIf ElementField = "SerialNumber" Then
                    itm.Value = dt.Rows(0)(9)
                    Return
                ElseIf ElementField = "PONumber" Then
                    itm.Value = dt.Rows(0)(10)
                    Return
                ElseIf ElementField = "LineNumber" Then
                    itm.Value = dt.Rows(0)(11)
                    Return
                End If
            End If

            'Select FieldValue that corresponds to the elementNumber 
            query = "SELECT * FROM forms_update WHERE " & _
                    " RequirementMUID = '" + GetMERequirementID(dt_TagList.Rows(ElementNumber - 1)(0).ToString, "Tag") + "'" & _
                    " AND FieldMUID = '" + itm.FieldID.ToString + "'" & _
                    " AND SourceMUID = '" + dt_TagList.Rows(ElementNumber - 1)(0).ToString + "'" & _
                    " AND SourceType = 'Tag'"
       
            dt = runtime.SQLProject.ExecuteQuery(query)


            If Not dt.Rows.Count = 0 Then
                itm.Value = dt.Rows(0)("FieldValue")
            End If


            'Dim query As String = "SELECT * FROM tags WHERE PackageID='" + PackageID.ToString + "'"
            'Dim dt_Tags As New DataTable
            'dt_Tags = Utilities.ExecuteQuery(query, "project")

            'Dim NameArray() As String = Split(itm.FieldName, "@")
            'NameArray(0) = Replace(NameArray(0), "Element", "")

        End If


    End Sub

    '2.1.0.42
    Public Sub InitializeFormParameters()
        _formVar.Clear()

        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim query As String = "SELECT AuxData, MUID FROM aux_forms_info WHERE FormMUID = '" + _FrmID.ToString + "'"
        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        Debug.Print("row count for form is " + dt.Rows.Count.ToString)
        For i As Integer = 0 To dt.Rows.Count - 1
            Try
                'Dim myVars() As String = Split(read(0), "&001")
                Dim myVars() As String = Split(dt.Rows(i)(0), "&001")
                Dim itm As formItem = New formItem
                itm.FieldName = myVars(0)
                itm.MapName = myVars(1)
                itm.linkTbl = myVars(2)
                itm.Value = myVars(3)
                itm.WtPcnt = CSng(myVars(4))
                itm.Color = myVars(5)
                itm.DataType = FormDesigner.FormDesignerMain.VarAttributes.dtype.Text
                itm.PgNum = CInt(myVars(7))
                itm.View = myVars(8)
                itm.PosX = CInt(myVars(10))
                itm.PosY = CInt(myVars(11))
                itm.Width = CInt(myVars(12))
                itm.Height = CInt(myVars(13))
                itm.FontName = myVars(15)
                itm.FontSize = CSng(myVars(16))
                itm.FontBold = CBool(myVars(17))
                itm.FontItalic = CBool(myVars(18))
                itm.FontUnderline = CBool(myVars(19))
                If Not myVars(20) = "" Then
                    itm.GroupID = CInt(myVars(20))
                End If
                itm.CustomName = itm.FieldName
                If myVars.Length >= 22 Then
                    If Not myVars(21) = "" Then
                        itm.CustomName = CStr(myVars(21))
                    End If
                End If
                If i = 86 Then
                    i = i
                End If
                itm.FieldID = dt.Rows(i)(1)


                If itm.linkTbl > "" Then
                    GetItemLinkVarValue(itm)
                ElseIf Left(itm.FieldName, 7) = "Element" Then
                    GetElementVarValue(itm)
                ElseIf Left(itm.FieldName, 9) = "Signature" Then
                    If Me._FormMode = "View" Then
                        query = " SELECT FieldValue " + _
                                    " FROM  forms_update " + _
                                    " WHERE RequirementMUID = '" + GetMERequirementID(_TagID, "Tag") + "'" + _
                                    " AND SourceMUID = '" + _TagID.ToString + "'" + _
                                    " AND FieldMUID = '" + itm.FieldID.ToString + "'" + _
                                    " AND SourceType= 'Tag' ORDER BY DateStamp DESC "

                        Dim dtt As DataTable = runtime.SQLProject.ExecuteQuery(query)
                        If dtt.Rows.Count > 0 Then
                            itm.Value = dtt.Rows(0)(0)
                        End If

                        Dim SourceType As String = Nothing
                        Dim SourceID As String
                        If MultiElement Then
                            SourceID = PackageID
                            SourceType = "Package"
                        Else
                            SourceID = _TagID
                            SourceType = "Tag"
                        End If

                        query = " SELECT MUID " + _
                                    " FROM forms_update " + _
                                    " WHERE RequirementMUID = '" + GetMERequirementID(SourceID, SourceType) + "' AND " + _
                                    " SourceMUID = '" + SourceID + "' AND FieldMUID = '" + itm.FieldID + "'" + _
                                    " AND SourceType='" + SourceType + "' ORDER BY DateStamp DESC "

                        Dim dttt As DataTable = runtime.SQLProject.ExecuteQuery(query)
                        If dttt.Rows.Count > 0 Then
                            Dim ThisFieldID As String = dttt.Rows(0)(0)
                            query = "SELECT FormImage FROM forms_image WHERE FormMUID='0' AND Aux05='" + ThisFieldID.ToString + "'"
                            Dim dt1 As DataTable = runtime.SQLProject.ExecuteQuery(query)
                            If dt1.Rows.Count > 0 Then
                                If Not (IsDBNull(dt.Rows(0)(0))) Then
                                    Dim buffer() As Byte = dt1.Rows(0)(0)
                                    Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))
                                    itm.image = Image
                                End If
                            End If
                        End If
                    End If
                Else
                    itm.Value = ""
                    If _FormMode = "View" Then
                        If MultiElement Then
                            query = " SELECT FieldValue " + _
                                        " FROM  forms_update " + _
                                        " WHERE RequirementMUID = '" + _RequirementID + "'" + _
                                        " AND SourceMUID = '" + PackageID + "'" + _
                                        " AND FieldMUID = '" + itm.FieldID + "'" + _
                                        " AND SourceType= 'Package' ORDER BY DateStamp DESC "
                            Dim dt_value As DataTable = runtime.SQLProject.ExecuteQuery(query)
                            If dt_value.Rows.Count > 0 Then
                                itm.Value = dt_value.Rows(0)(0)
                            End If
                        Else
                            query = " SELECT FieldValue " + _
                                        " FROM  forms_update " + _
                                        " WHERE RequirementMUID = '" + Me._RequirementID + "'" + _
                                        " AND SourceMUID = '" + _TagID.ToString + "'" + _
                                        " AND FieldMUID = '" + itm.FieldID.ToString + "'" + _
                                        " AND SourceType= 'Tag' ORDER BY DateStamp DESC "

                            Dim dt_value As DataTable = runtime.SQLProject.ExecuteQuery(query)
                            If dt_value.Rows.Count > 0 Then
                                itm.Value = dt_value.Rows(0)(0)
                            End If
                        End If
                    End If
                End If


                If _FormMode = "View" And Left(itm.FieldName, 7) = "Element" Then
                    Dim NameArray() As String = Split(myVars(0), "@")
                    NameArray(0) = Replace(NameArray(0), "Element", "")
                    Dim ElementNumber As Integer = CInt(NameArray(0))

                    If ElementNumber < TagCount + 1 Then
                        _formVar.Add(itm)
                    End If
                ElseIf _FormMode = "View" Then
                    _formVar.Add(itm)
                ElseIf _FormMode = "Edit" And Not Left(itm.FieldName, 7) = "Element" Then
                    _formVar.Add(itm)
                End If

            Catch ex As Exception
                'MessageBox.Show("xxx" + ex.Message)
            End Try
        Next

        'End While


        If _FormMode = "Edit" Then

            query = "SELECT AuxData, MUID FROM aux_subforms_info WHERE FormMUID = '" + _FrmID.ToString + "'"
            Dim dt1 As DataTable = runtime.SQLProject.ExecuteQuery(query)
            For i As Integer = 0 To dt1.Rows.Count - 1
                Try
                    Dim myVars() As String = Split(dt1.Rows(i)(0), "&001")
                    Dim itm As formItem = New formItem
                    itm.FieldName = myVars(0)
                    itm.MapName = myVars(1)
                    itm.linkTbl = myVars(2)
                    itm.Value = myVars(3)
                    itm.WtPcnt = CSng(myVars(4))
                    itm.Color = myVars(5)
                    itm.DataType = FormDesigner.FormDesignerMain.VarAttributes.dtype.Text
                    itm.PgNum = CInt(myVars(7))
                    itm.View = myVars(8)
                    itm.PosX = CInt(myVars(10))
                    itm.PosY = CInt(myVars(11))
                    itm.Width = CInt(myVars(12))
                    itm.Height = CInt(myVars(13))
                    itm.FontName = myVars(15)
                    itm.FontSize = CSng(myVars(16))
                    itm.FontBold = CBool(myVars(17))
                    itm.FontItalic = CBool(myVars(18))
                    itm.FontUnderline = CBool(myVars(19))
                    If Not myVars(20) = "" Then
                        itm.GroupID = CInt(myVars(20))
                    End If
                    itm.CustomName = itm.FieldName
                    If myVars.Length >= 22 Then
                        If Not myVars(21) = "" Then
                            itm.CustomName = CStr(myVars(21))
                        End If
                    End If
                    'itm.FieldID = read(1)
                    itm.FieldID = dt1.Rows(i)(1)
                    If itm.linkTbl > "" Then
                        GetItemLinkVarValue(itm)
                    ElseIf Left(itm.FieldName, 7) = "Element" Then
                        itm.Value = itm.FieldName
                    Else
                        query = " SELECT FieldValue " + _
                                    " FROM  forms_update " + _
                                    " WHERE RequirementMUID = '" + GetMERequirementID(_TagID, "Tag") + "'" + _
                                    " AND SourceMUID = '" + _TagID + "'" + _
                                    " AND FieldMUID = '" + itm.FieldID + "'" + _
                                    " AND SourceType= 'Tag' ORDER BY DateStamp DESC "
                        Dim dtt As DataTable = runtime.SQLProject.ExecuteQuery(query)
                        If dtt.Rows.Count > 0 Then
                            itm.Value = dtt.Rows(0)(0)
                        End If
                    End If

                    _formVar.Add(itm)
                    'End While
                Catch ex As Exception
                    MessageBox.Show("222 " + ex.Message)
                End Try
            Next
 


        ElseIf _FormMode = "View" Then

            'count number of element variables
            Dim eid As Integer = 0
            Dim firstElementName As String = ""
            For i As Integer = 0 To _formVar.Count - 1
                Try

                    Dim itm As formItem = _formVar(i)
                    If itm.linkTbl = "" Then
                        If itm.FieldName.Contains("Element") Then
                            If Not IsReservedElement(itm.FieldName) Then
                                Dim elementName As String = itm.FieldName.Split("@")(0)
                                If firstElementName = "" Then
                                    firstElementName = elementName
                                End If
                                If firstElementName > "" Then
                                    If firstElementName = elementName Then
                                        _SubElementVarCount = _SubElementVarCount + 1
                                    End If
                                End If
                                _ElementVarCount = _ElementVarCount + 1
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("333 " + ex.Message)
                End Try

            Next
            If _SubElementVarCount > 0 Then
                _NumElementVariables = _ElementVarCount * _SubElementVarCount
            End If

        End If


        'read.Close()
    End Sub
    Public Function GetFormProperies() As DataTable
        Dim hdrs() As String = {"Name", "Type", "Tag", "Owner", "User", "LastModified", _
                    "Last UserAction", "Form Current Levl", "percentComplete", "RequireMhrs", "EarnedMhrs", "Comment"}
        Dim DisplayTable As DataTable = New DataTable("FormProperties")
        'DisplayTable.Columns.Add(New DataColumn("Num", GetType(Integer)))
        'DisplayTable.PrimaryKey = New DataColumn() {DisplayTable.Columns("PkgID")}
        Dim myVal() As String = {_FormName, _TypeName, _TagName, _OwnerName, _FormUser, _
        GetFormUpdateDate(), _FormAction, _FormCurrentLevel, _
            GetPercentComplete() * 100, GetRequiredManHours(), GetEarnedManHours(), " "}

        For Each s As String In hdrs
            Dim ThisColumn As DataColumn = New DataColumn(s, GetType(String))
            ThisColumn.ColumnName = s
            DisplayTable.Columns.Add(ThisColumn)
        Next
        Dim imageColumn As DataColumn = New DataColumn("Esign", GetType(Image))
        imageColumn.ColumnName = "Esign"
        DisplayTable.Columns.Add(imageColumn)

        Dim dRow As DataRow = DisplayTable.NewRow
        Dim i As Integer = 0
        For i = 0 To hdrs.Length - 1
            dRow(hdrs(i)) = myVal(i)
        Next
        dRow("Esign") = _FormESign
        DisplayTable.Rows.Add(dRow)
        Return DisplayTable
    End Function
    Private Function GetNonElementRequiredManHours() As Single
        Dim mhr As Single = 0
        'Dim cmd As SqlCeCommand = connProject.CreateCommand()
        'cmd.CommandText = " SELECT ManHours FROM requirements " + _
        '        " WHERE(TypeID = " + _TypeID.ToString + ") And (" + _
        '        "FormID = " + _FrmID.ToString + ") And (" + _
        '        "OwnerID = " + _OwnerID.ToString + ")"

        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim query As String = " SELECT ManHours FROM requirements " + _
                " WHERE(TypeMUID = '" + _TypeID.ToString + "') And (" + _
                "FormMUID = '" + _FrmID.ToString + "') And (" + _
                "OwnerMUID = '" + _OwnerID.ToString + "')"

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
        If dt.Rows.Count > 0 Then
            mhr = dt.Rows(0)(0)
        End If
        'sqlPrjUtils.CloseConnection()

        'mhr = Convert.ToSingle(cmd.ExecuteScalar)
        Return mhr
    End Function
    Private Function GetFormUpdateDate()
        Dim dte As String = ""
        Dim qry As String = ""
        If MultiElement Then
            qry = "SELECT TS From forms_me_status WHERE OwnerMUID = '" + _OwnerID.ToString + "' AND " + _
                                        " FormMUID = '" + _FrmID.ToString + "' AND SourceMUID = '" + PackageID.ToString + "'" + _
                                        " AND SourceType = 'Package' ORDER By TS DESC"
        Else
            qry = "SELECT TS From forms_status WHERE OwnerMUID = '" + _OwnerID.ToString + "' AND " + _
                                        " FormMUID = '" + _FrmID.ToString + "' AND TagMUID = '" + _TagID.ToString + "'"
        End If
        'Dim dt As DataTable = Utilities.ExecuteQuery(qry, "project")
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
        'sqlPrjUtils.CloseConnection()
        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows(0)(0)) Then
                Return dt.Rows(0)(0).ToString
            End If
        End If
        Return dte
    End Function


    Private Function GetSingleElementRequiredManHours() As Single
        Dim multimhr As Single = 0
        'Dim cmd As SqlCeCommand = connProject.CreateCommand()
        'If Me.MultiElement Then
        '    cmd.CommandText = " SELECT Aux01 FROM requirements " + _
        '            " WHERE(TypeID = " + _TypeID.ToString + ") And (" + _
        '            "FormID = " + _FrmID.ToString + ") And (" + _
        '            "OwnerID = " + _OwnerID.ToString + ")"
        '    multimhr = Convert.ToSingle(cmd.ExecuteScalar)
        'End If



        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()

        If Me.MultiElement Then
            Dim query As String = " SELECT MEManHours FROM requirements " + _
                    " WHERE(TypeMUID = '" + _TypeID.ToString + "') And (" + _
                    "FormMUID = '" + _FrmID.ToString + "') And (" + _
                    "OwnerMUID = '" + _OwnerID.ToString + "')"
            multimhr = Convert.ToSingle(runtime.SQLProject.ExecuteQuery(query).Rows(0)(0))
        End If
        'sqlPrjUtils.CloseConnection()

        Return multimhr
    End Function

    Private Function GetAllElementRequiredManHours() As Single
        Dim multimhr As Single = 0
        multimhr = GetSingleElementRequiredManHours() * _NumElementVariables
        Return multimhr
    End Function
    Private Function GetEarnedManHours() As Single
        Dim elmHrs As Single = 0
        Dim nelmHrs As Single = 0
        If MultiElement Then
            elmHrs = GetElementWtPercentComplete() * GetAllElementRequiredManHours()
            nelmHrs = GetNonElementWtPercentComplete() * GetNonElementRequiredManHours()
        Else
            nelmHrs = GetNonElementWtPercentComplete() * GetNonElementRequiredManHours()
        End If
        Return elmHrs + nelmHrs
    End Function


    Private Function GetRequiredManHours() As Single
        Dim elmHrs As Single = 0
        Dim nelmHrs As Single = 0
        If MultiElement Then
            elmHrs = GetAllElementRequiredManHours()
            nelmHrs = GetNonElementRequiredManHours()
        Else
            nelmHrs = GetNonElementRequiredManHours()
        End If
        Return elmHrs + nelmHrs
    End Function


    Private Function GetPercentComplete() As Single
        Dim pCnt As Single = 0
        If GetRequiredManHours() > 0 Then
            pCnt = GetEarnedManHours() / GetRequiredManHours()
        End If
        Return pCnt
    End Function



    Private Function GetRequirementID() As String
        'Dim cmd As SqlCeCommand = connProject.CreateCommand()
        'cmd.CommandText = " SELECT ReqID FROM requirements " + _
        '        " WHERE (TypeID = " + _TypeID.ToString + ") And (" + _
        '        "FormID = " + _FrmID.ToString + ") And (" + _
        '        "OwnerID = " + _OwnerID.ToString + ")"
        'Return (Convert.ToInt32(cmd.ExecuteScalar))
        Dim qry As String = " SELECT MUID FROM requirements " + _
                " WHERE (TypeMUID = '" + _TypeID.ToString + "') And (" + _
                "FormMUID = '" + _FrmID.ToString + "') And (" + _
                "OwnerMUID = '" + _OwnerID.ToString + "')"

        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
        Dim retVal As String = ""
        If dt.Rows.Count > 0 Then
            retVal = runtime.SQLProject.ExecuteQuery(qry).Rows(0)(0)
        End If
        'sqlPrjUtils.CloseConnection()
        Return retVal


    End Function


    Private Function GetMERequirementID(ByVal _TagMUID As String, ByVal _SourceType As String) As String

        If _SourceType = "Tag" Then
            For i As Integer = 0 To Me.dt_TagList.Rows.Count - 1
                If Me.dt_TagList.Rows(i)(0) = _TagMUID Then
                    Return Me.dt_TagList.Rows(i)("ReqMUID")
                End If
            Next
        End If
        Return Me._RequirementID
    End Function


    Private Function GetTypeID() As String
        'Dim cmd As SqlCeCommand = connProject.CreateCommand()
        'cmd.CommandText = " SELECT TypeID FROM tags WHERE TagID = " + _TagID.ToString
        'Return (Convert.ToInt32(cmd.ExecuteScalar))
        Dim qry As String = " SELECT TypeMUID FROM tags WHERE MUID = '" + _TagID.ToString + "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
        Dim retVal As String = ""
        If dt.Rows.Count > 0 Then
            retVal = runtime.SQLProject.ExecuteQuery(qry).Rows(0)(0)
        End If
        'sqlPrjUtils.CloseConnection()
        Return retVal
    End Function


    Private Function GetTypeName() As String
        'Dim cmd As SqlCeCommand = connProject.CreateCommand()
        'cmd.CommandText = " SELECT TypeName FROM equipment_type WHERE TypeID = " + _TypeID.ToString
        'Return (Convert.ToString(cmd.ExecuteScalar))
        Dim qry As String = " SELECT TypeName FROM equipment_type WHERE MUID = '" + _TypeID.ToString + "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
        Dim retVal As String = ""
        If dt.Rows.Count > 0 Then
            retVal = runtime.SQLProject.ExecuteQuery(qry).Rows(0)(0)
        End If
        'sqlPrjUtils.CloseConnection()
        Return retVal

    End Function


    Private Function GetTagName() As String
        'Dim cmd As SqlCeCommand = connProject.CreateCommand()
        'cmd.CommandText = " SELECT TagNumber FROM tags WHERE TagID = " + _TagID.ToString
        'Return (Convert.ToString(cmd.ExecuteScalar))
        Dim qry As String = " SELECT TagNumber FROM tags WHERE MUID = '" + _TagID.ToString + "'"
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
        Dim retVal As String = ""
        If dt.Rows.Count > 0 Then
            retVal = runtime.SQLProject.ExecuteQuery(qry).Rows(0)(0)
        End If
        'sqlPrjUtils.CloseConnection()
        Return retVal
    End Function


    Private Function GetOwnerName() As String
        'Dim cmd As SqlCeCommand = connServer.CreateCommand()
        'cmd.CommandText = " SELECT Name FROM owner WHERE OwnerID = " + _OwnerID.ToString
        'Return (Convert.ToString(cmd.ExecuteScalar))
        Dim qry As String = " SELECT Name FROM owner WHERE MUID = '" + _OwnerID.ToString + "'"
        'Dim sqlSrvUtils As DataUtils = New DataUtils("server")
        'sqlSrvUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(qry)
        Dim retVal As String = ""
        If dt.Rows.Count > 0 Then
            retVal = runtime.SQLServer.ExecuteQuery(qry).Rows(0)(0)
        End If
        'sqlSrvUtils.CloseConnection()
        Return retVal
    End Function


    'Private Function GetUserName() As String
    '    'Dim cmd As SqlCeCommand = connServer.CreateCommand()
    '    'cmd.CommandText = " SELECT UserName FROM userInfo WHERE UserID = " + _OwnerID.ToString
    '    'Return (Convert.ToString(cmd.ExecuteScalar))
    '    Dim qry As String = " SELECT UserName FROM userInfo WHERE MUID = '" + _OwnerID.ToString + "'"
    '    Dim sqlSrvUtils As DataUtils = New DataUtils("server")
    '    sqlSrvUtils.OpenConnection()
    '    Dim dt As DataTable = sqlSrvUtils.ExecuteQuery(qry)
    '    Dim retVal As String = ""
    '    If dt.Rows.Count > 0 Then
    '        retVal = sqlSrvUtils.ExecuteQuery(qry).Rows(0)(0)
    '    End If
    '    sqlSrvUtils.CloseConnection()
    '    Return retVal

    'End Function


    Private Sub SetCurrentUserLevel()
        Dim i As Integer
        _FormUserLevel = -1
        Dim dt As DataTable = Utilities.GetUserInfoByMUID(_FormCurrentUserID)
        If Not (IsDBNull(dt.Rows(0)(11))) Then
            _FormCurrentUserLevelID = dt.Rows(0)(11)
            For i = 0 To _FormLevelOrder.Length - 1
                If _FormLevelOrder(i) = (dt.Rows(0)(11)).ToString Then
                    _FormUserLevel = i
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Function IsSystemForm(ByVal FormID As String) As Boolean
        Dim qry = "SELECT SystemForm FROM Forms WHERE SystemForm = '1' AND MUID = '" + _FrmID.ToString + "'"
        'Dim dt = Utilities.ExecuteQuery(qry, "Project")
        'Dim sqlPrjUtils As DataUtils = New DataUtils("project")

        'sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(qry)
        'sqlPrjUtils.CloseConnection()
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function



End Class

