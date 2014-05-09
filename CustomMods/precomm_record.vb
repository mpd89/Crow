Imports daqartDLL


Public Class precomm_record


    Public Sub New(ByVal _TagID As String)
        InitializeComponent()

        If Not _TagID = "" Then
            PopulateInfo(_TagID)
            PopulateAuxInfo(_TagID)
            GetDocuments(_TagID)
        End If
    End Sub


    Private Sub PopulateInfo(ByVal ThisTag As String)
        Dim query As String = "SELECT engineering_data.MUID, engineering_data.TS, " & _
                    "engineering_data.TagMUID, engineering_data.Remarks, engineering_data.Prefix,  " & _
                    "engineering_data.Description, engineering_data.Service, engineering_data.Manufacturer, " & _
                    "engineering_data.ModelNumber,  engineering_data.SerialNumber, engineering_data.PONumber, " & _
                    "engineering_data.LineNumber, engineering_data.rowguid, tags.MUID AS Expr1,  " & _
                    "tags.TS, tags.TagNumber, tags.PackageMUID, tags.TypeMUID, tags.rowguid AS Expr2 " & _
                    "FROM tags LEFT JOIN engineering_data ON engineering_data.TagMUID = tags.MUID " & _
                    "WHERE (tags.MUID = '" + ThisTag.ToString + "') ORDER BY engineering_data.TS DESC"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Me.tbx_Description.Text = dt.Rows(0)(5) + "/" + dt.Rows(0)(6)
        Me.tbx_DeviceType.Text = Utilities.GetTypeCode(dt.Rows(0)(17))
        Me.tbx_LoopID.Text = Utilities.GetPackageName(dt.Rows(0)(16))
        Me.tbx_TagNumber.Text = dt.Rows(0)(15)
    End Sub

    Private Sub PopulateAuxInfo(ByVal ThisTag As String)
        Dim dt_EngInfo As New DataTable
        dt_EngInfo = Utilities.GetTagEngInfo(ThisTag)

        If Not dt_EngInfo Is Nothing And dt_EngInfo.Rows.Count > 0 Then
            Me.tbx_Manufacturer.Text = dt_EngInfo.Rows(0)(7)
            Me.tbx_Model.Text = dt_EngInfo.Rows(0)(8)
            Me.tbx_Remarks.Text = dt_EngInfo.Rows(0)(3)
            Me.tbx_SerialNumber.Text = dt_EngInfo.Rows(0)(9)
        Else
            Me.tbx_Manufacturer.Text = ""
            Me.tbx_Model.Text = ""
            Me.tbx_Remarks.Text = ""
            Me.tbx_SerialNumber.Text = ""
        End If

        Me.tbx_AlarmState.Text = GetAuxData("xxx", ThisTag)
        Me.tbx_Block.Text = GetAuxData("xxx", ThisTag)
        Me.tbx_BusNode.Text = GetAuxData("I/O Address", ThisTag)
        Me.tbx_Certificates.Text = GetAuxData("xxx", ThisTag)
        Me.tbx_ControlSystem.Text = GetAuxData("xxx", ThisTag)
        Me.tbx_Datasheet.Text = GetAuxData("Data Sheet", ThisTag)
        Me.tbx_HiAlarm.Text = GetAuxData("Hi Alarm", ThisTag)
        Me.tbx_HiHiAlarm.Text = GetAuxData("Hi-Hi Alarm", ThisTag)
        Me.tbx_InputRange.Text = GetAuxData("Input Range", ThisTag)
        Me.TextBox10.Text = GetAuxData("xxx", ThisTag)
        Me.tbx_LoAlarm.Text = GetAuxData("Low Alarm", ThisTag)
        Me.tbx_Location.Text = GetAuxData("FieldLocation", ThisTag)
        Me.tbx_LoLoAlarm.Text = GetAuxData("Low-Low Alarm", ThisTag)
        Me.tbx_MCC.Text = GetAuxData("MCCNR", ThisTag)
        Me.tbx_OutputRange.Text = GetAuxData("Output Range", ThisTag)
        Me.tbx_Point.Text = GetAuxData("xxx", ThisTag)
        Me.tbx_PONumber1.Text = GetAuxData("PONBR", ThisTag)
        Me.tbx_PONumber2.Text = GetAuxData("PONBR", ThisTag)
        Me.tbx_ScaleHi.Text = GetAuxData("xxx", ThisTag)
        Me.tbx_ScaleLo.Text = GetAuxData("xxx", ThisTag)
        Me.tbx_Setpoints.Text = GetAuxData("PROC_SETPT", ThisTag)
        Me.tbx_SignalType.Text = GetAuxData("xxx", ThisTag)
        Me.tbx_UnitModuleSystem.Text = GetAuxData("Module", ThisTag)
    End Sub


    Private Function GetAuxData(ByVal AuxField As String, ByVal ThisTag As String) As String
        Dim query As String = "SELECT TOP (1) aux_tags.auxData " & _
            "FROM aux_fieldmap INNER JOIN " & _
            "aux_template_assoc ON aux_fieldmap.TemplateMUID = aux_template_assoc.TemplateMUID INNER JOIN " & _
            "aux_tags ON aux_fieldmap.idaux_fieldmap = aux_tags.FieldmapMUID " & _
            "WHERE (aux_fieldmap.CustomName = '" + AuxField.ToString + "') AND (aux_template_assoc.Aux01 = 'tag') " & _
            " AND (aux_template_assoc.AssocMUID = '" + ThisTag.ToString + "') " & _
            "ORDER BY aux_tags.MUID DESC"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        If dt Is Nothing Then Return ""
        If dt.Rows.Count = 0 Then Return ""

        If IsDBNull(dt.Rows(0)(0)) Then
            Return ("")
        End If
        Return dt.Rows(0)(0)
    End Function


    Private Sub GetDocuments(ByVal ThisTag As Integer)
        Dim PackageID As Integer = Utilities.GetPackageID(ThisTag)
        Dim query As String = "SELECT * FROM package_documents WHERE PackageMUID='" + PackageID.ToString + "' OR TagMUID='" + ThisTag.ToString + "'"
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        sqlPrjUtils.OpenConnection()
        Dim dt As DataTable = sqlPrjUtils.ExecuteQuery(query)
        sqlPrjUtils.CloseConnection()

        Try
            Me.tbx_Dwg1.Text = ""
            Me.tbx_Dwg2.Text = ""
            Me.tbx_Dwg3.Text = ""
            Me.tbx_Dwg4.Text = ""
            Me.tbx_Dwg5.Text = ""
            Me.tbx_Dwg6.Text = ""
            Me.tbx_Dwg7.Text = ""
            Me.tbx_Dwg8.Text = ""
            Me.tbx_Dwg9.Text = ""
            Me.tbx_Dwg10.Text = ""
            Me.tbx_Dwg11.Text = ""
            Me.tbx_Dwg12.Text = ""

            If dt.Rows.Count = 0 Then

            ElseIf (dt.Rows.Count = 1) Then
                Me.tbx_Dwg1.Text = Utilities.GetDocumentEngCode(dt.Rows(0)(2))
            ElseIf (dt.Rows.Count = 2) Then
                Me.tbx_Dwg2.Text = Utilities.GetDocumentEngCode(dt.Rows(1)(2))
            ElseIf (dt.Rows.Count = 3) Then
                Me.tbx_Dwg3.Text = Utilities.GetDocumentEngCode(dt.Rows(2)(2))
            ElseIf (dt.Rows.Count = 4) Then
                Me.tbx_Dwg4.Text = Utilities.GetDocumentEngCode(dt.Rows(3)(2))
            ElseIf (dt.Rows.Count = 5) Then
                Me.tbx_Dwg5.Text = Utilities.GetDocumentEngCode(dt.Rows(4)(2))
            ElseIf (dt.Rows.Count = 6) Then
                Me.tbx_Dwg6.Text = Utilities.GetDocumentEngCode(dt.Rows(5)(2))
            ElseIf (dt.Rows.Count = 7) Then
                Me.tbx_Dwg7.Text = Utilities.GetDocumentEngCode(dt.Rows(6)(2))
            ElseIf (dt.Rows.Count = 8) Then
                Me.tbx_Dwg8.Text = Utilities.GetDocumentEngCode(dt.Rows(7)(2))
            ElseIf (dt.Rows.Count = 9) Then
                Me.tbx_Dwg9.Text = Utilities.GetDocumentEngCode(dt.Rows(8)(2))
            ElseIf (dt.Rows.Count = 10) Then
                Me.tbx_Dwg10.Text = Utilities.GetDocumentEngCode(dt.Rows(9)(2))
            ElseIf (dt.Rows.Count = 11) Then
                Me.tbx_Dwg11.Text = Utilities.GetDocumentEngCode(dt.Rows(10)(2))
            ElseIf (dt.Rows.Count = 12) Then
                Me.tbx_Dwg12.Text = Utilities.GetDocumentEngCode(dt.Rows(11)(2))
            End If

        Catch ex As Exception

        End Try
    End Sub
 
End Class
