Imports daqartDLL


Public Class frmAddDiscrepancy
    Public Shared PackageID As String
    Public Shared PackageName As String
    Dim SQLProject As DataUtils


    Private Sub frmAddDiscrepancy_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SQLProject.CloseConnection()
    End Sub


    Private Sub frmAddDiscrepancy_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SQLProject = New DataUtils("project")
        SQLProject.OpenConnection()

        lblPackageID.Tag = PackageID
        lblPackageID.Text = PackageName
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim query As String = "INSERT INTO discrepancy (MUID,TS,Title," & _
                " Description,Resolution,ListedBy,ListedOn,Status,ManHours," & _
                " PackageMUID) VALUES (" & _
                " @MUID," & _
                " @TS," & _
                " @Title," & _
                " @Description," & _
                " @Resolution," & _
                " @ListedBy," & _
                " @ListedOn," & _
                " @Status," & _
                " @ManHours," & _
                " @PackageMUID)"

            Dim dt_param As DataTable = SQLProject.paramDT
            dt_param.Rows.Add("@MUID", idUtils.GetNextMUID("project", "discrepancy"))
            dt_param.Rows.Add("@TS", Now())
            dt_param.Rows.Add("@Title", txtTitle.Text)
            dt_param.Rows.Add("@Description", txtDescription.Text)
            dt_param.Rows.Add("@Resolution", txtResolution.Text)
            dt_param.Rows.Add("@ListedBy", runtime.UserMUID)
            dt_param.Rows.Add("@ListedOn", Now())
            dt_param.Rows.Add("@Status", "Pending")
            Dim manHours As String = Me.txtManHours.Text
            If manHours = "" Then
                manHours = "0"
            End If
            dt_param.Rows.Add("@ManHours", manHours)
            dt_param.Rows.Add("@PackageMUID", lblPackageID.Tag)

            SQLProject.ExecuteNonQuery(query, dt_param)
        Catch ex As Exception
            Utilities.logErrorMessage("DiscrepancyManager.frmAddDiscrepancy.btnSave-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

        Me.Dispose()
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub


    Public Sub New(ByVal ThisPackageID As String, ByVal ThisPackageName As String)
        InitializeComponent()
        PackageID = ThisPackageID
        PackageName = ThisPackageName
    End Sub


    Private Sub txtManHours_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtManHours.KeyPress
        Dim c As Char = e.KeyChar
        e.Handled = Not (Char.IsDigit(c))
    End Sub

End Class