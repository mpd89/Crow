Imports System.Windows.Media.Imaging
Imports System.Windows.Ink
Imports System.IO
Imports System

Imports System.Windows

Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Input
Imports System.Windows.Media

Public Class UserControl3
    Dim inkCanvas1 As InkCanvas
    ' Dim imageView As System.Windows.Controls.Image = Me.imageViewer1
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Debug.Print("new called")
        inkCanvas1 = Me.inkCanvas
        inkCanvas1.EditingMode = InkCanvasEditingMode.Ink

    End Sub




    Public Function getImageView()



        Return Me.imageViewer1
    End Function

    Public Sub setBitmap(ByVal bm As BitmapImage)
        Me.imageViewer1.Source = bm

    End Sub

    Private Sub Button_Click(sender As Object, e As Windows.RoutedEventArgs)
        inkCanvas1 = Me.inkCanvas

        inkCanvas1.EditingMode = InkCanvasEditingMode.Ink

        ' Set the DefaultDrawingAttributes for a highlighter pen.
        inkCanvas1.DefaultDrawingAttributes.Color = Colors.Yellow
        inkCanvas1.DefaultDrawingAttributes.IsHighlighter = True
        inkCanvas1.DefaultDrawingAttributes.Height = 25
    End Sub

    Private Sub Pen_Click(sender As Object, e As RoutedEventArgs)
        inkCanvas1 = Me.inkCanvas

        inkCanvas1.EditingMode = InkCanvasEditingMode.Ink
        inkCanvas1.DefaultDrawingAttributes.Color = Colors.Black
        inkCanvas1.DefaultDrawingAttributes.IsHighlighter = False
        inkCanvas1.DefaultDrawingAttributes.Width = 2.0
        inkCanvas1.DefaultDrawingAttributes.Height = 2.0
    End Sub

    Private Sub Eraser_Click(sender As Object, e As RoutedEventArgs)
        inkCanvas1.EditingMode = InkCanvasEditingMode.EraseByStroke
    End Sub

    Private Sub Select_Click(sender As Object, e As RoutedEventArgs)

        inkCanvas1.EditingMode = InkCanvasEditingMode.Select
    End Sub

    Private Sub Save_Click(sender As Object, e As RoutedEventArgs)
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "isf files (*.isf)|*.isf"

        If saveFileDialog1.ShowDialog() Then
            Dim fs As New FileStream(saveFileDialog1.FileName, FileMode.Create)
            inkCanvas1.Strokes.Save(fs)
            fs.Close()
        End If
    End Sub

    Private Sub Load_Click(sender As Object, e As RoutedEventArgs)
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "isf files (*.isf)|*.isf"

        If openFileDialog1.ShowDialog() Then
            Dim fs As New FileStream(openFileDialog1.FileName, FileMode.Open)
            inkCanvas1.Strokes = New StrokeCollection(fs)
            fs.Close()
        End If

    End Sub
End Class
