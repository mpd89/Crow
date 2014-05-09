Imports System.Data.SqlServerCe
Imports daqartDLL
Imports SystemManager

Public Class mainFunctions
    Dim connProject As SqlCeConnection = daqartDLL.connections.projectDBConnect(connProject)
    Public Shared PackageTable As New DataTable


    Public Shared Function CreateTierNodes()
        Dim result As Boolean
        Dim connProject As SqlCeConnection = Nothing
        Try
            connProject = connections.projectDBConnect(connProject)
            Dim cmd As New SqlCeCommand("SELECT * FROM system_number WHERE TierID='1' Order By 'Identifier' ASC", connProject)
            Dim da As New SqlCeDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            For Each dr As DataRow In dt.Rows
                Dim tn As New TreeNode()
                tn.Tag = dr("SystemNumberID")
                tn.Text = dr("Identifier").ToString() + " - " + dr("Description").ToString()
                tn.Name = dr("SystemNumberID").ToString()

                If SystemDataManager.IsParent(1) Then
                    SystemTreeNode(tn, 2, tn.Tag)
                Else
                    SystemTreeNode(tn, 2, 0)
                End If
            Next
        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.mainFunctions.CreateTierNodes-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

        Return result
    End Function


    Public Shared Sub SystemTreeNode(ByVal thisNode As TreeNode, ByVal _thisTier As Integer, ByVal _ParentLinkMUID As String)
        Try
            If _thisTier < Utilities.CountTiers() + 1 Then

                Dim connProject As SqlCeConnection = Nothing
                connProject = connections.projectDBConnect(connProject)
                Dim cmd As New SqlCeCommand("SELECT * FROM system_number WHERE TierMUID='" & _thisTier & "' Order By 'Identifier' ASC", connProject)
                Dim da As New SqlCeDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                Dim tn As TreeNode
                For Each dr As DataRow In dt.Rows
                    tn = New TreeNode()
                    tn.Tag = dr("MUID")
                    tn.Text = dr("Identifier").ToString() + " - " + dr("Description").ToString()
                    tn.Name = dr("SystemNumberMUID").ToString()
                    SystemTreeNode(tn, _thisTier + 1, 0)

                    thisNode.Nodes.Add(tn)
                Next

            End If
        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.mainFunctions.SystemTreeNodes-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Shared Sub CreateRootNodes()
        Try
            Dim dt As New DataTable()
            dt = SystemDataManager.GetSystemList()

            If Not dt.Rows.Count = 0 Then
                Dim SystemID() As String = New String(Utilities.CountTiers() - 1) {}
                Dim TreeNodeArray() As TreeNode = New TreeNode(Utilities.CountTiers() - 1) {}
                Dim tn As TreeNode

                For Each dr As DataRow In dt.Rows
                    Dim u As Integer
                    Dim SystemMUID As String = Nothing
                    For i As Integer = 0 To Utilities.CountTiers() - 1
                        'If Not SystemID.GetValue(i) = dr(i) Then

                        If i = 0 Then
                            SystemMUID = dr(i)
                        Else
                            SystemMUID = SystemMUID + ";" + dr(i)
                        End If

                        Dim StripSystem As String = dr(i)
                        'StripSystem = StripSystem.Split("&001")(1)
                        If Not SystemID.GetValue(i) = StripSystem Then

                            tn = New TreeNode()
                            tn.Tag = dr(i).ToString
                            tn.Text = SystemDataManager.GetSystemIdentifier(dr(i).ToString) + " - " + SystemDataManager.GetSystemDescription(dr(i).ToString)
                            tn.Name = dr(i).ToString()

                            If i = Utilities.CountTiers() - 1 Then
                                Dim SystemPriority As Integer = SystemDataManager.GetSystemPriority(SystemMUID)

                                If SystemPriority = 1 Then
                                    tn.BackColor = Color.Red
                                ElseIf SystemPriority = 2 Then
                                    tn.BackColor = Color.Aqua
                                ElseIf SystemPriority = 3 Then
                                    tn.BackColor = Color.Yellow
                                Else
                                    tn.BackColor = Nothing
                                End If
                            End If

                            TreeNodeArray(i) = tn

                            If i > 0 Then
                                TreeNodeArray(i - 1).Nodes.Add(tn)

                                'assign priority color
                                If Not tn.BackColor = Nothing Then
                                    If TreeNodeArray(i - 1).BackColor = Nothing Then
                                        TreeNodeArray(i - 1).BackColor = tn.BackColor
                                    ElseIf TreeNodeArray(i - 1).BackColor = Color.Yellow Then
                                        TreeNodeArray(i - 1).BackColor = tn.BackColor
                                    ElseIf TreeNodeArray(i - 1).BackColor = Color.Aqua And tn.BackColor = Color.Red Then
                                        TreeNodeArray(i - 1).BackColor = tn.BackColor
                                    End If
                                End If


                            ElseIf i = 0 Then
                                SystemView.SystemTree.Nodes.Add(TreeNodeArray(i))
                            Else

                            End If

                            For u = i + 1 To Utilities.CountTiers() - 1
                                SystemID(u) = 0
                            Next
                        End If
                        SystemID(i) = StripSystem
                    Next
                Next
            End If
        Catch ex As Exception
            Utilities.logErrorMessage("Daqart.mainFunctions.CreateRootNodes-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Shared Sub SetSelectedProject()
        Main.ProjectStatusInd.Text = "Project: " + runtime.selectedProject
    End Sub

    'Public Shared Sub PopulateOverview(ByVal ThisTab As TabPage, ByVal SystemID As String, ByVal SystemName As String)
    '    Dim sqlPrjUtils As DataUtils = New DataUtils("project")
    '    Try
    '        Dim i As Integer
    '        sqlPrjUtils.OpenConnection()

    '        Dim thisSystem As New SystemOverview()
    '        thisSystem.Tag = SystemID
    '        thisSystem.Name = "SysID" & SystemID
    '        thisSystem.MyOwnerID = SystemView.cbx_Owners.SelectedValue
    '        thisSystem.MyOwnerName = SystemView.cbx_Owners.Text

    '        Dim query As String
    '        'Dim SystemStatusTable As New DataTable
    '        query = "SELECT * " & _
    '        "FROM system_status " & _
    '        "WHERE SystemID LIKE '" & SystemID & "%' AND OwnerID='" & thisSystem.MyOwnerID & "'"
    '        'SystemStatusTable = Utilities.ExecuteQuery(query, "project")
    '        Dim SystemStatusTable As DataTable = sqlPrjUtils.ExecuteQuery(query)

    '        'Dim dt_EarnedMH As New DataTable
    '        query = "SELECT SUM(EarnedManHours) As EMH " & _
    '        "FROM system_status " & _
    '        "WHERE SystemID LIKE '" & SystemID & "%' AND OwnerID='" & thisSystem.MyOwnerID & "'"
    '        'dt_EarnedMH = Utilities.ExecuteQuery(query, "project")
    '        Dim dt_EarnedMH As DataTable = sqlPrjUtils.ExecuteQuery(query)

    '        'Dim dt_ReqdMH As New DataTable
    '        query = "SELECT SUM(RequiredManHours) As RMH " & _
    '        "FROM system_status " & _
    '        "WHERE SystemID LIKE '" & SystemID & "%' AND OwnerID='" & thisSystem.MyOwnerID & "'"
    '        'dt_ReqdMH = Utilities.ExecuteQuery(query, "project")
    '        Dim dt_ReqdMH As DataTable = sqlPrjUtils.ExecuteQuery(query)


    '        'Public Shared PackageTable As New DataTable
    '        query = "SELECT " & _
    '        "package.packageID, package.PackageNumber AS Package, package.Description AS Description " & _
    '        "FROM package  " & _
    '        "WHERE package.SystemNumber LIKE '" & SystemID & "%' "
    '        'PackageTable = Utilities.ExecuteQuery(query, "project")
    '        PackageTable = sqlPrjUtils.ExecuteQuery(query)

    '        PackageTable.Columns.Add("Level")
    '        PackageTable.Columns.Add("Earned_MH")
    '        PackageTable.Columns.Add("Reqd_MH")
    '        PackageTable.Columns.Add("PerComp")


    '        Dim PackageStatusTable As New DataTable
    '        For i = 0 To PackageTable.Rows.Count - 1
    '            query = "SELECT " & _
    '            "package_status.CurrentLevel As Level, package_status.EarnedManHours As Earned_MH, " & _
    '            "package_status.RequiredManHours AS Reqd_MH, " & _
    '            "CASE WHEN package_status.RequiredManHours = '0' THEN 0 ELSE " & _
    '            "Round(package_status.EarnedManHours / package_status.RequiredManHours * 100, 2) END AS PerComp " & _
    '            "FROM package_status  " & _
    '            "WHERE packageID = '" & PackageTable.Rows(i)(0) & "' " & _
    '            "AND OwnerID ='" & thisSystem.MyOwnerID & "' "
    '            'PackageStatusTable = Utilities.ExecuteQuery(query, "project")
    '            PackageStatusTable = sqlPrjUtils.ExecuteQuery(query)

    '            If Not PackageStatusTable.Rows.Count = 0 Then
    '                PackageTable.Rows(i)(3) = PackageStatusTable.Rows(0)(0)
    '                PackageTable.Rows(i)(4) = PackageStatusTable.Rows(0)(1)
    '                PackageTable.Rows(i)(5) = PackageStatusTable.Rows(0)(2)
    '                PackageTable.Rows(i)(6) = PackageStatusTable.Rows(0)(3)
    '            Else
    '                PackageTable.Rows(i)(3) = 0
    '                PackageTable.Rows(i)(4) = 0
    '                PackageTable.Rows(i)(5) = 0
    '                PackageTable.Rows(i)(6) = 0
    '            End If
    '        Next



    '        Dim CompletePackageCount As Integer = 0
    '        For Each dr As DataRow In PackageTable.Rows
    '            Dim CompletePackageTable As New DataTable
    '            query = "SELECT * " & _
    '            "FROM package_status " & _
    '            "WHERE OwnerID = '" & thisSystem.MyOwnerID & "' " & _
    '            "AND PackageID = '" & dr(0) & "' " & _
    '            "AND CurrentLevel = '" & Utilities.GetFormConfigCount(thisSystem.MyOwnerID) & "' "
    '            'CompletePackageTable = Utilities.ExecuteQuery(query, "project")
    '            CompletePackageTable = sqlPrjUtils.ExecuteQuery(query)

    '            CompletePackageCount += CompletePackageTable.Rows.Count

    '        Next



    '        thisSystem.tbx_SystemID.Text = SystemName
    '        thisSystem.tbx_Description.Text = SystemManager.SystemDataManager.GetFullSystemDescription(SystemID)
    '        thisSystem.tbx_Owner.Text = thisSystem.MyOwnerName
    '        thisSystem.tbx_Owner.Tag = thisSystem.MyOwnerName

    '        If Not IsDBNull(dt_EarnedMH.Rows(0)("EMH")) Then
    '            thisSystem.tbx_EarnedMH.Text = dt_EarnedMH.Rows(0)("EMH")
    '            thisSystem.tbx_RequiredMH.Text = dt_ReqdMH.Rows(0)("RMH")
    '        Else
    '            thisSystem.tbx_EarnedMH.Text = 0
    '            thisSystem.tbx_RequiredMH.Text = 0
    '        End If

    '        Dim PComplete As Double
    '        If Not thisSystem.tbx_RequiredMH.Text = 0 Then
    '            PComplete = Math.Round(Convert.ToDouble(thisSystem.tbx_EarnedMH.Text) / Convert.ToDouble(thisSystem.tbx_RequiredMH.Text) * 100, 2)
    '        Else
    '            PComplete = 0.0
    '        End If
    '        thisSystem.tbx_PercentComplete.Text = PComplete.ToString

    '        thisSystem.tbx_PackageCount.Text = PackageTable.Rows.Count.ToString
    '        thisSystem.tbx_PackageComplete.Text = CompletePackageCount.ToString
    '        thisSystem.tbx_PackageRemaining.Text = PackageTable.Rows.Count - CompletePackageCount

    '        With thisSystem.dgv_Packages
    '            '.DataSource = PackageTable
    '            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '            .AutoResizeRows()
    '            .Columns(0).Width = 75
    '            .Columns(1).Width = 305
    '            .Columns(2).Width = 100
    '            .Columns(3).Width = 65
    '            .Columns(4).Width = 65
    '            .Columns(5).Width = 60
    '        End With

    '        Dim gridHeight As Integer = 25
    '        For i = 0 To PackageTable.Rows.Count - 1

    '            Dim RowValues As New DataGridViewRow()
    '            thisSystem.dgv_Packages.Rows.Add(RowValues)
    '            thisSystem.dgv_Packages.Rows(i).Cells(0).Value = PackageTable.Rows(i)(1)
    '            thisSystem.dgv_Packages.Rows(i).Cells(0).Tag = PackageTable.Rows(i)(0)

    '            thisSystem.dgv_Packages.Rows(i).Cells(1).Value = PackageTable.Rows(i)(2)

    '            thisSystem.dgv_Packages.Rows(i).Cells(3).Value = PackageTable.Rows(i)(4)
    '            thisSystem.dgv_Packages.Rows(i).Cells(4).Value = PackageTable.Rows(i)(5)
    '            thisSystem.dgv_Packages.Rows(i).Cells(5).Value = PackageTable.Rows(i)(6)


    '            gridHeight += thisSystem.dgv_Packages.Rows(i).Height
    '        Next

    '        SystemView.dt_CurrentSystem = PackageTable

    '        'thisSystem.dgv_Packages.Height = gridHeight



    '        For Each Page As TabPage In SystemView.tbc_Main.TabPages
    '            If Page.Name = SystemName Then
    '                Page.Controls.Add(thisSystem)
    '            End If
    '        Next


    '    Catch ex As Exception
    '        Utilities.logErrorMessage("Daqart.mainFunctions.PopulateOverview-" + ex.Message)
    '        MessageBox.Show(ex.Message)
    '    End Try
    '    sqlPrjUtils.CloseConnection()
    'End Sub




End Class


