Imports System.Data.SqlServerCe
Imports System.IO
Imports System.Windows.Forms
Imports daqartDLL

Public Class formSubmit
    Private Action As FormDesigner.FormView.ActionType
    Private image As Image
    Private bmp As Bitmap
    Private startPoint As Point = New Point()
    Private _myForm As FormUtils
    Private FormLevel As Integer
    Private FormUserID As String

    Public Sub New(ByVal myForm As FormUtils, ByVal myAction As Integer)

        ' This call is required by the Windows Form Designer.
        _myForm = myForm
        InitializeComponent()
        Action = myAction
        Select Case myAction
            Case 1
                Me.lblAction.Text = "Action: Submit"
            Case 2
                Me.lblAction.Text = "Action: Reject"
            Case 3
                Me.lblAction.Text = "Action: Accept"
        End Select
        ' Add any initialization after the InitializeComponent() call.
        FormLevel = _myForm.FormCurrentLevel
        FormUserID = runtime.UserMUID
    End Sub


    Private Sub formSubmit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try

            startPoint = New Point(0, 0)
            bmp = New Bitmap(PictureBox1.Size.Width, PictureBox1.Size.Height)
            PictureBox1.Image = bmp
            Me.OK_Button.Enabled = False

            If runtime.SiteName = "ENI001" Then
                If runtime.UserMUID = "yP3y006ajyj0LZHA-2sPzAErb&0016" Then 'Tom McCall
                    Dim query As String = "SELECT ESign FROM forms_status WHERE MUID = 'M2KeytSdHmyaZSZN-wnBfWyGJ&00138'"
                    Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
                    If dt.Rows.Count = 0 Then
                        Return
                    End If
                    If Not (IsDBNull(dt.Rows(0)("ESign"))) Then
                        Dim buffer() As Byte = dt.Rows(0)("ESign")
                        Dim sigImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))

                        PictureBox1.Image = sigImage
                        Me.OK_Button.Enabled = True
                    End If
                ElseIf runtime.UserMUID = "yP3y006ajyj0LZHA-2sPzAErb&0017" Then ' Mark White
                    Dim query As String = "SELECT DocumentImage FROM SystemImages WHERE Name = 'yP3y006ajyj0LZHA-2sPzAErb&0017'"
                    Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
                    If dt.Rows.Count = 0 Then
                        Return
                    End If
                    If Not (IsDBNull(dt.Rows(0)("DocumentImage"))) Then
                        Dim buffer() As Byte = dt.Rows(0)("DocumentImage")
                        Dim sigImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))

                        PictureBox1.Image = sigImage
                        Me.OK_Button.Enabled = True
                    End If
                ElseIf runtime.UserMUID = "yP3y006ajyj0LZHA-2sPzAErb&0011" Then ' Tommy Boutwell
                    Dim query As String = "SELECT ESign FROM forms_status WHERE MUID = 'yP3y006ajyj0LZHA-2sPzAErb&00118'"
                    Dim dt As DataTable = runtime.SQLProject.ExecuteQuery(query)
                    If dt.Rows.Count = 0 Then
                        Return
                    End If
                    If Not (IsDBNull(dt.Rows(0)("ESign"))) Then
                        Dim buffer() As Byte = dt.Rows(0)("ESign")
                        Dim sigImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))

                        PictureBox1.Image = sigImage
                        Me.OK_Button.Enabled = True
                    End If
                ElseIf runtime.UserMUID = "ZTsSCQYTTrgS0Loj-Ag5jzjPk&00121" Then ' Bill Childress
                    Dim query As String = "SELECT DocumentImage FROM SystemImages WHERE Name = 'ZTsSCQYTTrgS0Loj-Ag5jzjPk&00121'"
                    Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
                    If dt.Rows.Count = 0 Then
                        Return
                    End If
                    If Not (IsDBNull(dt.Rows(0)("DocumentImage"))) Then
                        Dim buffer() As Byte = dt.Rows(0)("DocumentImage")
                        Dim sigImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))

                        PictureBox1.Image = sigImage
                        Me.OK_Button.Enabled = True
                    End If
                ElseIf runtime.UserMUID = "ZTsSCQYTTrgS0Loj-Ag5jzjPk&00161" Then ' Brian Miller
                    Dim query As String = "SELECT DocumentImage FROM SystemImages WHERE Name = 'ZTsSCQYTTrgS0Loj-Ag5jzjPk&00161'"
                    Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
                    If dt.Rows.Count = 0 Then
                        Return
                    End If
                    If Not (IsDBNull(dt.Rows(0)("DocumentImage"))) Then
                        Dim buffer() As Byte = dt.Rows(0)("DocumentImage")
                        Dim sigImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))

                        PictureBox1.Image = sigImage
                        Me.OK_Button.Enabled = True
                    End If
                ElseIf runtime.UserMUID = "yP3y006ajyj0LZHA-2sPzAErb&00110" Then ' Rod Damewood
                    Dim query As String = "SELECT DocumentImage FROM SystemImages WHERE Name = 'yP3y006ajyj0LZHA-2sPzAErb&00110'"
                    Dim dt As DataTable = runtime.SQLServer.ExecuteQuery(query)
                    If dt.Rows.Count = 0 Then
                        Return
                    End If
                    If Not (IsDBNull(dt.Rows(0)("DocumentImage"))) Then
                        Dim buffer() As Byte = dt.Rows(0)("DocumentImage")
                        Dim sigImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(buffer))

                        PictureBox1.Image = sigImage
                        Me.OK_Button.Enabled = True
                    End If
                End If
            End If


            If Action = FormView.ActionType.Accept Or Action = FormView.ActionType.Reject Then
                If _myForm.FormCurrentLevel <> _myForm.FormUserLevel Then
                    Dim myForm As New FormDesigner.FormVerifyUser(_myForm)
                    Dim msgResult As DialogResult = myForm.ShowDialog()
                    If msgResult = Windows.Forms.DialogResult.Cancel Then
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                        Me.Close()
                    End If
                    If msgResult = Windows.Forms.DialogResult.OK Then
                        FormUserID = _myForm.FormCurrentUserID
                    End If
                End If
            End If
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

        'TimeStamp(DateTime.Now, Me.Font, 100)
        If Action = FormView.ActionType.Reject Or Action = FormView.ActionType.CancelSubmit Then
            FormLevel = FormLevel - 1
        Else
            FormLevel = FormLevel + 1
        End If
        Dim myAction As Integer = 0
        Select Case Action
            Case FormView.ActionType.CancelSubmit
                myAction = 4
                FormLevel = 0
            Case FormView.ActionType.Accept
                myAction = 3
            Case FormView.ActionType.Reject
                FormLevel = 0
                myAction = 2
            Case FormView.ActionType.Submit
                myAction = 1
        End Select
        _myForm.FormComment = tbxComments.Text
        _myForm.FormAction = myAction
        _myForm.FormEsign = PictureBox1.Image
        _myForm.FormCurrentLevel = FormLevel
        _myForm.SaveFieldValues()
        _myForm.UpdateAllFormStatus()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
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


End Class
