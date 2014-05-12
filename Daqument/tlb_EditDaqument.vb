Imports System.Drawing.Imaging
Imports System.Drawing.Printing
'Imports System.Collections
Imports System.IO
Imports System.Data.SqlClient
Imports daqartDLL
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraVerticalGrid
'Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.Utils


Public Class tlb_EditDaqument

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    'Private printDoc As PrintDocument = New PrintDocument()
    Private printDialog As PrintPreviewDialog
    Private intPageCounter As Integer
    Private PreviousAnchorPoint = New Point(0, 0)
    Private cms1Loc As Point = New Point(0, 0)
    'Private image As Image
    'Private bmp As Bitmap
    Private ScreenOffsetX As Integer = 20
    Private ScreenOffsetY As Integer = 60
    Private localStartPoint As Point = New Point()
    Private dragHandleStartPoint As Point = New Point()
    Private dragStartPoint As Point = New Point()
    Private dragEndPoint As Point = New Point()
    Private theRectangle As New Rectangle(New Point(0, 0), New Size(0, 0))
    Private lineStartPoint As Point = New Point()
    Private VectorIDCtr As Integer = 0
    Private lineEndPoint As Point = New Point()
    Private myDoc As EditDaqumentUtil
    Private PictureBox1ImageCopy As Image
    '    Private CurrentOpaqueValue As Integer
    Private CurrentLineWidth As Integer
    Private Vectors As New List(Of EditDaqumentUtil.VectorMap)
    Private BoundryBox As New List(Of PictureBox)
    '    Private Magnification As Single = 1
    Private tmpVectors As New List(Of EditDaqumentUtil.Vector)

   

 
End Class




