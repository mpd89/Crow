Imports System.Windows.Forms

Public Class DaqumentAddNewLayer
    Private _myDoc As EditDaqumentUtil
    Private PkgNum As String = ""
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If txtTitle.Text = "" Then
            MessageBox.Show("Please enter Title")
            Return
        End If

        If txtDesc.Text = "" Then
            MessageBox.Show("Please enter Desciption")
            Return
        End If
        If _myDoc.CheckTitle(txtTitle.Text) Then
            MessageBox.Show("The title " + txtTitle.Text + " already exist")
            Return
        End If
        _myDoc.AddNewLayer(txtTitle.Text, txtDesc.Text)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Sub New(ByVal myDoc As EditDaqumentUtil)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _myDoc = myDoc

    End Sub
    Public Sub New(ByVal myDoc As EditDaqumentUtil, ByVal PkgNumber As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _myDoc = myDoc
        PkgNum = PkgNumber
    End Sub

    Private Sub DaqumentAddNewLayer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.rb_Redline.Checked = False
        Me.rb_Hilite.Checked = False
        Me.txtTitle.Text = ""
        Me.txtDesc.Text = ""
        If PkgNum > "" Then
            Me.GroupBox1.Visible = True
            Me.ckb_ApplyToPkg.Visible = True
            Me.rb_Redline.Visible = True
            Me.rb_Hilite.Visible = True
        Else
            Me.GroupBox1.Visible = False
            Me.ckb_ApplyToPkg.Visible = False
            Me.rb_Redline.Visible = False
            Me.rb_Hilite.Visible = False
        End If
    End Sub
    Private Sub ApplyToPkg()
        If ckb_ApplyToPkg.Checked Then
            Me.txtTitle.Enabled = False
            Me.txtDesc.Enabled = False
            If Me.rb_Redline.Checked Then
                Me.txtTitle.Text = "RL-" + PkgNum
                Me.txtDesc.Text = "Package Redline layer"
            Else
                Me.txtTitle.Text = "HL-" + PkgNum
                Me.txtDesc.Text = "Package Hilite layer"
                Me.rb_Hilite.Checked = True
            End If
        Else
            Me.txtTitle.Enabled = True
            Me.txtDesc.Enabled = True
            Me.txtTitle.Text = ""
            Me.txtDesc.Text = ""
        End If
    End Sub
    Private Sub ckb_ApplyToPkg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckb_ApplyToPkg.CheckedChanged
        ApplyToPkg()
    End Sub

    Private Sub rb_Hilite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_Hilite.CheckedChanged
        ApplyToPkg()
    End Sub

    Private Sub rb_Redline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_Redline.CheckedChanged
        ApplyToPkg()
    End Sub
End Class
