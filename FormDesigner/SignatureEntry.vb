Imports System.Data.SqlServerCe
Imports System.IO
Imports System.Windows.Forms
Imports daqartDLL
Imports System.Drawing.Imaging


Public Class SignatureEntry
    Private image As Image
    Private bmp As Bitmap
    Private startPoint As Point = New Point()
    Private myForm As FormUtils
    Private FormLevel As Integer
    Private FormUserID As String
    Public FieldID As String
    Public FieldName As String
    Private FormID As String
    Private serverSQL As DataUtils
    Public SignatureImage As Image

    Public Sub New(ByVal _myForm As FormUtils, ByVal _FormID As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        myForm = _myForm
        FormID = _FormID
    End Sub


    Private Sub SignatureEntry_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        serverSQL.CloseConnection()
    End Sub


    Private Sub formSubmit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            serverSQL = New DataUtils("project")
            serverSQL.OpenConnection()

            startPoint = New Point(0, 0)
            bmp = New Bitmap(PictureBox1.Size.Width, PictureBox1.Size.Height)
            PictureBox1.Image = bmp
            Me.OK_Button.Enabled = False


            For i As Integer = 0 To myForm.FormVars.Count - 1
                If myForm.FormVars(i).FieldName = FieldName Then

                    If Not myForm.FormVars(i).image Is Nothing Then
                        Me.PictureBox1.Image = myForm.FormVars(i).image
                    End If
                End If
            Next


        Catch ex As Exception
            Utilities.logErrorMessage("FormDesigner.FormSubmit_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        SignatureImage = Me.PictureBox1.Image
        Dim ThisItem As New FormUtils.formItem
        For i As Integer = 0 To myForm.FormVars.Count - 1
            If myForm.FormVars(i).FieldName = FieldName Then
                FieldID = myForm.FormVars(i).FieldID
                ThisItem = myForm.FormVars(i)

                If SignatureImage Is Nothing Then
                    ThisItem.image = Nothing
                Else
                    Dim m As New MemoryStream
                    SignatureImage.Save(m, ImageFormat.Png)
                    ThisItem.image = image.FromStream(m)
                End If
                myForm.FormVars(i) = ThisItem

                'myForm.FormVars(i).image = Me.PictureBox1.Image
            End If
        Next

        Me.Close()
    End Sub


    Private Function TimeStamp(ByVal text As String, ByVal fnt As Font, ByVal wid As Integer) As Bitmap
        Dim mBox As TextBox = New TextBox()
        If Not (mBox Is Nothing) Then
            mBox = New TextBox()
            mBox.TabStop = False
            mBox.Location = New Point(-9999, 0)
            Me.Controls.Add(mBox)
        End If
        ' mBox.Font = fnt
        mBox.Width = wid
        mBox.Text = text
        'bmp = New Bitmap(mBox.Width, mBox.Height)
        '     mBox.DrawToBitmap(bmp, New Rectangle(0, 0, mBox.Width, mBox.Height))
        mBox.DrawToBitmap(bmp, New Rectangle(0, 0, 100, wid))

        Return bmp
    End Function


    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        startPoint = New Point(e.X, e.Y)
    End Sub


    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Dim myPoint As Point = New Point(e.X, e.Y)

        Dim g As Graphics = Graphics.FromImage(Me.PictureBox1.Image)
        Dim myPen As New Pen(New SolidBrush(Color.Blue), 2)
        myPen.EndCap = Drawing2D.LineCap.Round
        g.DrawLine(myPen, startPoint, myPoint)
        startPoint = myPoint
        PictureBox1.Refresh()
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Dim myPoint As Point = New Point(e.X, e.Y)
        ControlPaint.DrawReversibleLine(startPoint, myPoint, Color.Black)
        Me.OK_Button.Enabled = True
    End Sub

    Private Sub btn_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Clear.Click
        Me.PictureBox1.Image = Nothing
        Me.OK_Button.Enabled = True

        Me.SignatureImage = Nothing
    End Sub


End Class