Imports daqartDLL


Public Class editSignOff
    Dim ThisOwner As String
    Dim ThisOrder As Integer
    Dim ThisLevelID As String
    Dim ThisColor As String
    Dim ThisDescription As String
    Dim customColor As Color


    Public Sub New(ByVal _OwnerMUID As String, ByVal Order As Integer, ByVal _LevelMUID As String, ByVal Color As String, ByVal Description As String)
        InitializeComponent()

        ThisOwner = _OwnerMUID
        ThisOrder = Order
        ThisLevelID = _LevelMUID
        ThisColor = Color
        ThisDescription = Description
    End Sub


    Private Sub btn_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Color.Click
        Dim thisColor As Button
        thisColor = sender

        ColorDialog1.ShowDialog(Me)
        btn_Color.BackColor = ColorDialog1.Color

    End Sub


    Private Sub editSignOff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lbl_Order.Text = CStr(ThisOrder)
            cbx_Level.DataSource = Utilities.GetLevels()
            cbx_Level.DisplayMember = Utilities.GetLevels().Columns(2).ToString
            cbx_Level.ValueMember = Utilities.GetLevels().Columns(0).ToString

            Dim i As Integer
            For i = 0 To Utilities.GetLevels().Rows.Count - 1
                If Utilities.GetLevels().Rows(i)(0) = ThisLevelID Then
                    cbx_Level.SelectedIndex = i
                End If
            Next

            If ThisColor = "" Then
                btn_Color.BackColor = Color.White
            Else
                customColor = System.Drawing.Color.FromArgb(ThisColor)
                btn_Color.BackColor = customColor
            End If

            tbx_Description.Text = ThisDescription
        Catch ex As Exception
            Utilities.logErrorMessage("DataManager.editSignoff_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Dim query As String
        Dim ThisRecord As DataTable = Utilities.GetFormLevel(ThisOwner)
        Dim sqlPrjUtils As DataUtils = New DataUtils("project")
        Dim dt_param As DataTable = sqlPrjUtils.paramDT

        If Not ThisRecord.Rows.Count = 0 Then
            Dim LevelArray As Array = Split(ThisRecord.Rows(0)(2), ",")

            If Not ThisOrder > LevelArray.Length Then
                Dim i As Integer
                'make color array
                Dim ColorArray As New List(Of String)
                If Not IsDBNull(ThisRecord.Rows(0)(3)) Then
                    Dim Array
                    Array = Split(ThisRecord.Rows(0)(3), "&001")
                    For i = 0 To Array.length - 1
                        ColorArray.Add(Array(i))
                    Next
                Else
                    For i = 0 To LevelArray.Length - 1
                        ColorArray.Add("")
                    Next
                End If

                'make descrption array
                Dim DescriptionArray As New List(Of String)
                If Not IsDBNull(ThisRecord.Rows(0)(4)) Then
                    Dim Array
                    Array = Split(ThisRecord.Rows(0)(4), "&001")
                    For i = 0 To Array.length - 1
                        DescriptionArray.Add(Array(i))
                    Next
                Else
                    For i = 0 To LevelArray.Length - 1
                        DescriptionArray.Add("")
                    Next
                End If

                'Change the specified index values for each array
                LevelArray(ThisOrder - 1) = cbx_Level.SelectedValue
                ColorArray(ThisOrder - 1) = btn_Color.BackColor.ToArgb
                DescriptionArray(ThisOrder - 1) = tbx_Description.Text


                'change array to delimited strings again
                Dim NewLevel As String = Nothing
                Dim NewColor As String = Nothing
                Dim NewDescription As String = Nothing

                For i = 0 To LevelArray.Length - 1

                    If i = LevelArray.Length - 1 Then
                        NewLevel += LevelArray(i)
                        NewColor += ColorArray(i)
                        NewDescription += DescriptionArray(i)
                    Else
                        NewLevel += LevelArray(i) + ","
                        NewColor += ColorArray(i) + "&001"
                        NewDescription += DescriptionArray(i) + "&001"
                    End If

                Next

                query = "UPDATE forms_config SET " & _
                        " LevelOrder=@LevelOrder" & _
                        " , LevelColor=@LevelColor" & _
                        " , LevelDescription=@LevelDescription" & _
                        " WHERE OwnerMUID=@OwnerMUID"

                dt_param.Rows.Add("@LevelOrder", NewLevel)
                dt_param.Rows.Add("@LevelColor", NewColor)
                dt_param.Rows.Add("@LevelDescription", NewDescription)
                dt_param.Rows.Add("@OwnerMUID", ThisOwner)
            Else
                query = "UPDATE forms_config SET " & _
                        " LevelOrder=@LevelOrder" & _
                        " , LevelColor=@LevelColor" & _
                        " , LevelDescription=@LevelDescription" & _
                        " WHERE OwnerMUID=@OwnerMUID"

                dt_param.Rows.Add("@LevelOrder", ThisRecord.Rows(0)(2) & "," & cbx_Level.SelectedValue)
                dt_param.Rows.Add("@LevelColor", ThisRecord.Rows(0)(3) & "&001" & btn_Color.BackColor.ToArgb)
                dt_param.Rows.Add("@LevelDescription", ThisRecord.Rows(0)(4) & "&001" & tbx_Description.Text)
                dt_param.Rows.Add("@OwnerMUID", ThisOwner)
            End If
        Else
            query = "INSERT INTO forms_config " & _
                " (MUID,OwnerMUID,LevelOrder,LevelColor,LevelDescription) Values(" & _
                " @MUID," & _
                " @OwnerMUID," & _
                " @LevelOrder," & _
                " @LevelColor," & _
                " @LevelDescription)"

            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "forms_config"))
            dt_param.Rows.Add("@OwnerMUID", ThisOwner)
            dt_param.Rows.Add("@LevelOrder", cbx_Level.SelectedValue)
            dt_param.Rows.Add("@LevelColor", btn_Color.BackColor.ToArgb)
            dt_param.Rows.Add("@LevelDescription", tbx_Description.Text)
        End If


        sqlPrjUtils.OpenConnection()
        sqlPrjUtils.ExecuteNonQuery(query, dt_param)
        sqlPrjUtils.CloseConnection()

        Me.Dispose()
    End Sub


End Class