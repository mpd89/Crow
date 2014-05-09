Imports System
Imports System.Drawing
Imports System.Windows.Forms

'Namespace fieldmap

'    Public Class Form1
'        Inherits System.Windows.Forms.Form
'        Private MapFields As ListView.SelectedListViewItemCollection
'        Private label3 As System.Windows.Forms.Label
'        Private label4 As System.Windows.Forms.Label
'        Private label5 As System.Windows.Forms.Label
'        Private label6 As System.Windows.Forms.Label
'        Friend WithEvents DataTypeComboBox As System.Windows.Forms.ComboBox
'        Friend WithEvents ColumnViewComboBox As System.Windows.Forms.ComboBox
'        Friend WithEvents ColorDialogButton As System.Windows.Forms.Button
'        Friend WithEvents ageUpDownPicker As System.Windows.Forms.NumericUpDown

'        Public Sub UpdateMapFields()
'            MapFields = pkgViewNew.lvwMapFile.SelectedItems
'        End Sub

'        Public Sub New()

'        End Sub

'        Public Sub Open()
'            Me.label3 = New System.Windows.Forms.Label()
'            Me.label4 = New System.Windows.Forms.Label()
'            Me.label5 = New System.Windows.Forms.Label()
'            Me.label6 = New System.Windows.Forms.Label()
'            Me.ageUpDownPicker = New System.Windows.Forms.NumericUpDown()
'            Me.DataTypeComboBox = New System.Windows.Forms.ComboBox()
'            Me.ColumnViewComboBox = New System.Windows.Forms.ComboBox()
'            Me.ColorDialogButton = New System.Windows.Forms.Button()


'            ' ErrorBlinkStyle.AlwaysBlink Label
'            Me.label4.Location = New System.Drawing.Point(50, 32)
'            Me.label4.Size = New System.Drawing.Size(160, 23)
'            Me.label4.Text = "Select Weighted Percentage value (0-100)"
'            Me.label4.TextAlign = ContentAlignment.MiddleRight

'            ' ErrorBlinkStyle.BlinkIfDifferentError Label
'            Me.label5.Location = New System.Drawing.Point(50, 64)
'            Me.label5.Size = New System.Drawing.Size(160, 23)
'            Me.label5.Text = "Select Field Data Type"
'            Me.label5.TextAlign = ContentAlignment.MiddleRight

'            ' Favorite Column View
'            Me.label3.Location = New System.Drawing.Point(50, 96)
'            Me.label3.Size = New System.Drawing.Size(160, 23)
'            Me.label3.Text = "Select Column View"
'            Me.label3.TextAlign = ContentAlignment.MiddleRight

'            ' ErrorBlinkStyle.NeverBlink Label
'            Me.label6.Location = New System.Drawing.Point(50, 128)
'            Me.label6.Size = New System.Drawing.Size(160, 23)
'            Me.label6.Text = "Select Color of the Column"
'            Me.label6.TextAlign = ContentAlignment.MiddleRight

'            ' Age NumericUpDown
'            Me.ageUpDownPicker.Location = New System.Drawing.Point(224, 32)
'            Me.ageUpDownPicker.Maximum = New System.Decimal(New Integer() {150, 0, 0, 0})
'            Me.ageUpDownPicker.TabIndex = 4

'            ' Favorite Color ComboBox
'            Me.DataTypeComboBox.Items.AddRange(New Object() {"TEXT", "NUMERIC", "DATE"})
'            Me.DataTypeComboBox.Location = New System.Drawing.Point(224, 64)
'            Me.DataTypeComboBox.Size = New System.Drawing.Size(120, 21)
'            Me.DataTypeComboBox.TabIndex = 5

'            Me.ColumnViewComboBox.Items.AddRange(New Object() {"Fixed", "Moveable", "Hidden"})
'            Me.ColumnViewComboBox.Location = New System.Drawing.Point(224, 96)
'            Me.ColumnViewComboBox.Size = New System.Drawing.Size(120, 21)
'            Me.ColumnViewComboBox.TabIndex = 6

'            Me.ColorDialogButton.Location = New System.Drawing.Point(224, 128)
'            Me.DataTypeComboBox.Size = New System.Drawing.Size(120, 10)
'            Me.DataTypeComboBox.TabIndex = 7
'            Me.ColorDialogButton.Text = "Color"

'            ' Set up how the form should be displayed and add the controls to the form.
'            Me.ClientSize = New System.Drawing.Size(464, 170)
'            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label6, Me.label5, Me.label4, _
'                                          Me.DataTypeComboBox, Me.ColumnViewComboBox, Me.ageUpDownPicker, _
'                                          Me.label3, Me.ColorDialogButton})

'            Me.Text = "Map Field Entries"


'        End Sub 'New
'        Private Sub ColorDialogButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColorDialogButton.Click
'            pkgViewNew.lvwMapFile.SelectedItems.GetEnumerator()
'            '            Dim MapFields As ListView.SelectedListViewItemCollection = _
'            'frmSearch.lvwMapFile.SelectedItems
'            Dim item As ListViewItem
'            'Dim price As Double = 0.0
'            Dim ColorDialog1 As New ColorDialog
'            Try

'                With ColorDialog1
'                    .ShowDialog(Me)
'                    '                frmSearch.lvwMapFile.SelectedItems.GetEnumerator()
'                    For Each item In pkgViewNew.SelectedMapFieldItems
'                        item.SubItems(0).BackColor = .Color
'                        item.SubItems(4).Text = .Color.ToArgb.ToString
'                    Next
'                End With
'            Catch ex As Exception
'                MessageBox.Show(ex.Message)
'            End Try

'        End Sub

'        Private Sub ageUpDownPicker_ValueChaged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ageUpDownPicker.ValueChanged

'            If IsValueTooLow() Then
'                ' Set the error if the age is too young.
'                MessageBox.Show("Invalid Percentage value")
'            ElseIf IsValueTooHigh() Then
'                ' Set the error if the age is too old.
'                MessageBox.Show("Total Percentage exceeds 100")
'            Else
'                Dim item As ListViewItem
'                'Dim price As Double = 0.0
'                'MapFields = frmSearch.lvwMapFile.SelectedItems.GetEnumerator()
'                For Each item In pkgViewNew.SelectedMapFieldItems
'                    Dim lbsender As NumericUpDown
'                    lbsender = CType(sender, NumericUpDown)
'                    item.SubItems(3).Text = lbsender.Value
'                Next

'            End If
'        End Sub

'        Private Sub DataTypeComboBox_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataTypeComboBox.TextChanged
'            If Not (DataTypeComboBox.SelectedItem Is Nothing) Then
'                ' Clear the error, if any, in the error provider.
'                Dim item As ListViewItem
'                For Each item In pkgViewNew.SelectedMapFieldItems
'                    Dim lbsender As ComboBox
'                    lbsender = CType(sender, ComboBox)
'                    If item.SubItems(0).Text = "PackageNumber" Then
'                        If lbsender.Text <> "TEXT" Then
'                            MessageBox.Show("PackageNumber must be a Text Field")
'                        End If
'                    Else
'                        item.SubItems(2).Text = lbsender.Text
'                    End If
'                Next
'            End If
'        End Sub
'        Private Sub ColumnViewComboBox_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColumnViewComboBox.TextChanged
'            If Not (ColumnViewComboBox.SelectedItem Is Nothing) Then
'                ' Clear the error, if any, in the error provider.
'                Dim item As ListViewItem
'                For Each item In pkgViewNew.SelectedMapFieldItems
'                    Dim lbsender As ComboBox
'                    lbsender = CType(sender, ComboBox)
'                    If item.SubItems(0).Text = "PackageNumber" Then
'                        If lbsender.Text <> "Fixed" Then
'                            MessageBox.Show("PackageNumber Column View can not be changed")
'                        End If
'                    Else
'                        item.SubItems(5).Text = lbsender.Text
'                    End If
'                Next
'            End If
'        End Sub

'        Private Function IsValueTooLow() As Boolean
'            ' Determine whether the age value is less than three.
'            Return ageUpDownPicker.Value < 0
'        End Function


'        Private Function IsValueTooHigh() As Boolean
'            ' Determine whether the age value is greater than five.
'            Dim i As Integer
'            Dim ttlPcntg As Double = 0
'            For i = 0 To i < pkgViewNew.lvwMapFile.Items.Count - 1
'                Try
'                    ttlPcntg = ttlPcntg + CDbl(pkgViewNew.lvwMapFile.Items(i).SubItems(1).Text)
'                Catch ex As Exception

'                End Try
'            Next
'            Return ttlPcntg + ageUpDownPicker.Value > 100
'        End Function
'    End Class 'Form1

'End Namespace 'ErrorProvider 
