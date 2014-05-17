Imports System.Drawing.Imaging
Imports System.Drawing.Printing
'Imports System.Collections
Imports System.IO
'Imports System.Data.SqlClient
Imports daqartDLL
Imports DevExpress.XtraGrid
'Imports DevExpress.XtraEditors.Repository
'Imports DevExpress.XtraGrid.Views.BandedGrid
'Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
'Imports DevExpress.XtraVerticalGrid
'Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils
Imports Microsoft.Win32
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey



Public Class EditDaqument

    'Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    'Private InfoTblForm As Form
    Private printDoc As PrintDocument = New PrintDocument()
    Private printDialog As PrintPreviewDialog
    Private intPageCounter As Integer
    Private PreviousAnchorPoint = New Point(0, 0)
    Private cms1Loc As Point = New Point(0, 0)
    'Private image As Image
    Private bmp As Bitmap
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
    Private CloneOriginalWeldInfoTable As DataTable
    '    Private CurrentOpaqueValue As Integer
    Private CurrentLineWidth As Integer
    Private Vectors As New List(Of EditDaqumentUtil.VectorMap)
    Private BoundryBox As New List(Of PictureBox)
    '    Private Magnification As Single = 1
    Private tmpVectors As New List(Of EditDaqumentUtil.Vector)
    Private ListOfModifiedVectors As New List(Of EditDaqumentUtil.Vector)
    Private UserActionList As New List(Of UserAction)
    Private LayerInfoTbl As DataTable
    Private OverlayBM As Bitmap
    Private LayerMode As String
    Private Loaded As Boolean = False
    Private CurrentColor As Color = Color.PaleTurquoise
    Private CurrentLayer As String = ""
    Private CurrentScaleFactor As Single = 0
    Private PkgNum As String = ""
    Private Loading As Boolean
    Private DocumentMode As String
    'Friend WithEvents VGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
    Private vdt As DataTable ' used in vgridcontrol
    Private GlobalScreenPoint As Point
    Private selectedWeldTableIndex As Integer = 0
    Private selectedWeldTagNo As String = ""
    Private riCboEdit As RepositoryItemComboBox = New RepositoryItemComboBox()

    Public Class UserAction
        Public Structure Action
            Dim ActType As ActionType
            Dim vecID As Integer
            Dim vec As EditDaqumentUtil.Vector
        End Structure
        Public Enum ActionType
            Add
            Delete
            Modify
        End Enum
        Dim _Action As Action
        Public Sub New(ByVal ActionType As ActionType, ByVal ID As Integer)
            _Action.ActType = ActionType
            _Action.vecID = ID
        End Sub
        Public Sub New(ByVal ActionType As ActionType, ByVal ID As Integer, ByVal vec As EditDaqumentUtil.Vector)
            _Action.ActType = ActionType
            _Action.vecID = ID
            _Action.vec = vec
        End Sub
    End Class

    Public Structure SeqControl
        Dim seqNumber As Integer
        Dim Ctrl As System.Windows.Forms.Control
        Dim vecID As Integer
    End Structure

    Private tmpControls As New List(Of SeqControl)
    Private dragHandleRectangle As Rectangle

    '    Private VarCtr As Integer
    Private _PrintImages As New List(Of Image)
    Dim daqMode As EditDaqumentUtil.mode = EditDaqumentUtil.mode.None
    Public Shared DocumentID As String


    Public Sub New(ByVal ThisDocument As String)
        Me.InitializeComponent()
        DocumentID = ThisDocument
        PkgNum = ""
        DocumentMode = ""
    End Sub


    Public Sub New(ByVal ThisDocument As String, ByVal PkgNumber As String, ByVal _DocumentMode As String)
        Me.InitializeComponent()
        DocumentID = ThisDocument
        PkgNum = PkgNumber
        DocumentMode = _DocumentMode
    End Sub


    Private Sub EditDaqument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loading = True

        Try

            ''EditDaqumentUtil selects all from the documents table that match the DocumentID
            ''And selects all from the documents_store that match the DocumentID
            ''The image in the documents_store is loaded into the CurrentImage variable for 
            ''later use
            myDoc = New EditDaqumentUtil(DocumentID)


            ''If OriginalDocImage is Nothing it DocumentImageAvailable returns false
            If Not myDoc.DocumentImageAvailable() Then
                MessageBox.Show("No image available for this document")
                Me.Close()
            End If


            localStartPoint = New Point(0, 0)

            ''AddLayerTitles selects all of the layers from drawing_layers where the DrawingMUID = DocumentID
            ''It then populates the tsmi_selectlayers dropdown menu with the name and description of each
            AddLayerTitles()


            ''ShowPkgLayers goes through all of the tsmi_selectedlayers items and if the text(description) is 
            ''"RL-" + pkgNum or "HL-" + pkgNum then the item then gets checked
            ''Then it runs through that list again and for each checked item it adds that same item to the 
            ''btn_ActiveLayer ToolStripMenuItem drop down menu
            ShowPkgLayers()

            ''ResizePageWidth resizes the pictureBox1 container to the size of the users viewing window and sets the magnification
            ''Then it calls secondary subroutine 
            ''  ResizeDrawingView()
            ''  resets the originalDocImage size based on the magX and magY variables then creates a new bitmap to that size
            ''  myDoc.ResizeImage(newSize) scales the image as a ratio newsize/oldsize, creates a new image with the new size and returns it.
            ''It then sets the image to transperent, places it in the pictureBox and sets the currentScalFactor as a ratio of pictureBox.width/originalSize.width
            ''  CreatePageOverlay() Creates an overlay bitmap to the width/height of the pictureBox, and creates a drawingArea rectangle the size of the PictureBox
            ''  CreateOverlay() Creates a drawingArea rectangle with pictureBoxImage1Copy called OverlayBM. For every layer in the dropdownitems get the layerID from 
            ''  the layerInfoTbl and for each vector in list of vectors if the vec.layerID=LayerID call embedLayerObjectOverlay
            ResizePageWidth()



            LoadAllLayerVectors()

            ''sets the editing variables Hilite, backcolor, linewidth, currentlinewidth, Title text, 
            ''and printing buttons and handlers
            LayerMode = "Hilite"
            btnColorChoice.BackColor = Color.PaleTurquoise
            btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width3
            CurrentLineWidth = 9
            btn_Width3.Checked = True
            Me.Text = "Daqument Viewer / Editor: File '" + myDoc.DocumentName + "'"
            PicBox2.Visible = False
            picBoxDragHandle.Visible = False
            PictureBox1.Controls.Add(picBoxDragHandle)
            printDoc.DocumentName = "Printing Documents"
            AddHandler printDoc.BeginPrint, AddressOf printDoc_BeginPrint
            AddHandler printDoc.EndPrint, AddressOf printDoc_EndPrint
            AddHandler printDoc.PrintPage, AddressOf printDoc_PrintPage
            PictureBox1.Refresh()
            '            Dim myLayerInfo As New Daqument.DcomentLayer(myDoc)
            '           myLayerInfo.Show()


            btnCancel.Select()


            CreatePageOverlay(PictureBox1ImageCopy)

            btnEnlarge.Enabled = True
            btnReduce.Enabled = True

            Me.cbx_FontSize.SelectedIndex = 1
            'SetupGridControls()
            Redraw()


            ''Set the registry setting for zoom preferences for the user 
            Dim regKey As String
            Dim regValue As String
            regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
            regValue = Registry.GetValue(regKey, "DaqumentZoom", Nothing)
            If regValue = Nothing Then
                regValue = "75"
                Me.WriteDefaultZoom("75")
            End If

            ResizeDrawingView(CInt(regValue) / 100, CInt(regValue) / 100)
            Me.btnMaginfy.Text = String.Format(regValue + "%")

        Catch ex As Exception
            Utilities.logErrorMessage("EditDaqument.EditDaqument_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try


        Loaded = True


        ''updates the list of layers in again after layers and vectors have been added
        ShowPkgLayers()


     

    End Sub


    Private Sub LoadDocument(ByVal DocumentMUID As String)
        Loading = True

        Try
            DocumentID = DocumentMUID

            myDoc = New EditDaqumentUtil(DocumentID)


            If Not myDoc.DocumentImageAvailable() Then
                MessageBox.Show("No image available for this document")
                Me.Close()
            End If

            localStartPoint = New Point(0, 0)
            AddLayerTitles()
            ShowPkgLayers()

            'ResizePageWidth()

            LoadAllLayerVectors()

            LayerMode = "Hilite"
            btnColorChoice.BackColor = Color.PaleTurquoise

            btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width3
            CurrentLineWidth = 9
            btn_Width3.Checked = True
            Me.Text = "Daqument Viewer / Editor: File '" + myDoc.DocumentName + "'"
            PicBox2.Visible = False
            picBoxDragHandle.Visible = False
            PictureBox1.Controls.Add(picBoxDragHandle)
            printDoc.DocumentName = "Printing Documents"


            btnCancel.Select()

            CreatePageOverlay(PictureBox1ImageCopy)

            btnEnlarge.Enabled = True
            btnReduce.Enabled = True

            Me.cbx_FontSize.SelectedIndex = 1
            'SetupGridControls()
            Redraw()

            Dim regKey As String
            Dim regValue As String
            regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings"
            regValue = Registry.GetValue(regKey, "DaqumentZoom", Nothing)
            If regValue = Nothing Then
                regValue = "75"
                Me.WriteDefaultZoom("75")
            End If

            ResizeDrawingView(CInt(regValue) / 100, CInt(regValue) / 100)
            Me.btnMaginfy.Text = String.Format(regValue + "%")


        Catch ex As Exception
            Utilities.logErrorMessage("EditDaqument.EditDaqument_Load-" + ex.Message)
            MessageBox.Show(ex.Message)
        End Try


        Loaded = True
        ShowPkgLayers()
     

    End Sub

    Private Function GetCurrentCabinetID() As String
        'Dim i As Integer = 0
        'For Each thisItem As ToolStripMenuItem In Me.btnViewLayers.DropDownItems
        'If thisItem.Checked Then
        'Return (LayerInfoTbl.Rows(i)(7))
        'End If
        'i = i + 1
        'Next

        For i As Integer = 0 To LayerInfoTbl.Rows.Count - 1
            If LayerInfoTbl.Rows(i)(0) = CurrentLayer Then
                Return (LayerInfoTbl.Rows(i)(7))
            End If
        Next
        Return ""
    End Function
    Private Function GetCurrentLayerID() As Integer
        'Dim i As Integer = 0
        'For Each thisItem As ToolStripMenuItem In Me.btnViewLayers.DropDownItems
        '    If thisItem.Checked Then
        '        Return (LayerInfoTbl.Rows(i)(0))
        '    End If
        '    i = i + 1
        'Next
        Return CurrentLayer
        Return 0
    End Function


    ''  CreateOverlay() Creates a drawingArea rectangle with pictureBoxImage1Copy called OverlayBM. For every layer in the dropdownitems get the layerID from 
    ''  the layerInfoTbl and for each vector in list of vectors if the vec.layerID=LayerID call embedLayerObjectOverlay
    Private Sub CreateOverlay()
        OverlayBM = New Bitmap(Me.Width, Me.Height)
        Dim DrawingArea As Graphics = Graphics.FromImage(OverlayBM)
        Dim Rect As Rectangle
        Rect = New Rectangle(0, 0, Me.Width, Me.Height)
        'DrawingArea.DrawImage(PictureBox1.Image, Rect, ScreenOffsetX * -1, ScreenOffsetY * -1, Me.Width, Me.Height, GraphicsUnit.Pixel)
        DrawingArea.DrawImage(PictureBox1ImageCopy, Rect, ScreenOffsetX * -1, ScreenOffsetY * -1, Me.Width, Me.Height, GraphicsUnit.Pixel)

        Dim layerCtr As Integer = 0
        Dim LayerID As String
        layerCtr = 0
        '        For Each ts As ToolStripMenuItem In Me.btnViewLayers.DropDownItems
        For Each ts As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            If ts.Checked Then
                LayerID = LayerInfoTbl.Rows(layerCtr)(0)
                For Each vec As EditDaqumentUtil.VectorMap In Vectors
                    If Not vec.ObjectDeleted And vec.ObjectMode = "Marking" And vec.layerID = LayerID Then
                       
                        embedLayerObjectOverlay(vec.thisVector)
                        'OverlayBM.Save("c:\vec" + vec.vectorID.ToString + ".png", ImageFormat.Png)
                    End If
                Next
            End If
            layerCtr = layerCtr + 1
        Next


    End Sub

    Private PageOverlayBM As Bitmap

    '' CreatePageOverlay() Creates an overlay bitmap to the width/height of the pictureBox, and creates a drawingArea rectangle the size of the PictureBox
    Private Sub CreatePageOverlay(ByVal Img As Image)
        PageOverlayBM = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim DrawingArea As Graphics = Graphics.FromImage(PageOverlayBM)
        Dim Rect As Rectangle
        Rect = New Rectangle(0, 0, PictureBox1.Width, PictureBox1.Height)
        DrawingArea.DrawImage(Img, Rect, 0, 0, PictureBox1.Width, PictureBox1.Height, GraphicsUnit.Pixel)
    End Sub


    Private Sub ShowInfoTable(ByVal infoTbl As DataTable, ByVal myCaption As String)
     
    End Sub


    ''' AddLayerTitles populates the ToolStripMenuItem tsmi_SelectLayers with
    ''' all of the layers that match the documentID
    ''' </summary>

    Private Sub AddLayerTitles()
        Try

            ''If the layerInfoTbl has data in it dispose of it
            If Not LayerInfoTbl Is Nothing Then
                LayerInfoTbl.Dispose()
                LayerInfoTbl = Nothing
            End If

            ''Selects MUID layerTitle, LayerDescription, LayerRevDate Revision, lastUserMUID
            ''layerStatus, DateCreated, Cabinet, and DrawingMUID from drawing_layers
            ''where DrawingMUID = DocumentID
            LayerInfoTbl = myDoc.LayerInfoTbl()

            ''tsmi_selectedLayers is the ToolStripMenuItem that holds all of the Layers for
            ''each document 
            tsmi_SelectLayers.DropDownItems.Clear()


            ''For every layer in the LayerInfoTbl add a tool stripMenuItem
            ''with a name and description in the tsmi_selectLayers ToolStripMenuItem
            For i As Integer = 0 To LayerInfoTbl.Rows.Count - 1
                Dim ts As ToolStripMenuItem = New ToolStripMenuItem
                ts.Name = LayerInfoTbl.Rows(i)(0)
                ts.Text = LayerInfoTbl.Rows(i)(1)

                
                tsmi_SelectLayers.DropDownItems.Add(ts)
                AddHandler ts.Click, AddressOf btnLayer_Click


            Next

        Catch ex As Exception

        End Try

    End Sub


    ''LoadAllLayerVectors()
    ''for every layerId in the layerInfoTbl call LoadLayerVectors
    Private Sub LoadAllLayerVectors()
        Dim LayerID As String
        VectorIDCtr = 0
        Dim layerCtr As Integer = 0
      
        For Each ts As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            LayerID = LayerInfoTbl.Rows(layerCtr)(0)
            loadLayerVectors(LayerID)
            layerCtr = layerCtr + 1
        Next


        Dim picSize As Size = New Size(Me.ClientRectangle.Size.Width - ScreenOffsetX, Me.ClientRectangle.Size.Height - ScreenOffsetY)
        Dim orgSize As Size = myDoc.OriginalDrawingSize
        Dim magX As Single = (picSize.Width / orgSize.Width) : Dim magY As Single = (picSize.Height / orgSize.Height)
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorObjectType = "Text" Then
                RescaleVector(vec, magX, magY)
                MakeTextImage(vec)
                'vec.pBox.Image.Save("c:\tbx1.png", ImageFormat.Png)
            End If
        Next
        'for comparing to see weld property is beinged
        ''' CloneOriginalWeldInfoTable = myDoc.WeldPointInfoTable.Copy

    End Sub


    Private Function LayerIsVisible(ByVal LayerID As String) As Boolean
        Dim LayerIndex As Integer = 0
        For LayerIndex = 0 To LayerInfoTbl.Rows.Count - 1
            If LayerInfoTbl.Rows(LayerIndex)(0) = LayerID Then Exit For
        Next
        Dim j As Integer = 0
        'For Each thisItem As ToolStripMenuItem In Me.btnViewLayers.DropDownItems
        '    If thisItem.Checked Then
        '        If LayerIndex = j Then Return True
        '    End If
        '    j = j + 1
        'Next
        For Each thisItem As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            If thisItem.Checked Then
                If LayerIndex = j Then Return True
            End If
            j = j + 1
        Next
        Return False
    End Function


    Public Sub embedLayerObject(ByVal vec As EditDaqumentUtil.Vector)
        Dim g As Graphics = Graphics.FromImage(Me.PictureBox1.Image)

        If Not vec.ObjectDeleted And LayerIsVisible(vec.layerID) Then
            If vec.VectorObjectType = "Text" Then
                Dim myFont = New Font(vec.fontfamily, vec.tBox.Font.Size * (CurrentScaleFactor / vec.OrgScaleX), _
                         vec.tBox.Font.Style, GraphicsUnit.Point)
                Dim myBrush As Brush = New SolidBrush(vec.tBox.ForeColor)
                Dim boxWidth As Integer = vec.tBox.Size.Width * (CurrentScaleFactor / vec.OrgScaleX)
                Dim boxHeight As Integer = vec.tBox.Size.Height * (CurrentScaleFactor / vec.OrgScaleY)
                Dim boxSize As Size = New Size(boxWidth, boxHeight)
                g.DrawString(vec.text, myFont, myBrush, New Rectangle(New Point(vec.StartPointX, vec.StartPointY), boxSize))
                'ElseIf vec.VectorObjectType = "Pic" Then
                '    Dim img As Image = myDoc.ResizeImage(vec.pBox.Image, vec.pBox.Size)
                '    'g.DrawImage(img, New Point(vec.StartPointX, vec.StartPointY))
                '    'g.DrawImage(bmp_Image, New Point(vec.StartPointX, vec.StartPointY))
                '    img.Dispose()
            ElseIf vec.VectorObjectType = "Line" Then
                Dim clr As Color = Color.FromArgb(vec.penArgb)
                Dim clr2 As Color = Color.LightGray

                Dim myPen As Pen = New Pen(New SolidBrush(clr), vec.ScaledLineWidth)
                If Me.GrayscaleInactiveLayer.Checked Then
                    If Not vec.layerID = CurrentLayer Then
                        myPen = New Pen(New SolidBrush(clr2), vec.ScaledLineWidth)
                    End If
                End If

                myPen.EndCap = vec.lineEnd
                Dim startPoint As Point = New Point(vec.StartPointX, vec.StartPointY)
                Dim endPoint As Point = New Point(vec.endPointX, vec.endPointY)
                g.DrawLine(myPen, startPoint, endPoint)
            ElseIf vec.VectorObjectType = "Weld" Then
                '        DrawWeld(vec)
            End If
        End If
    End Sub



    ''If the vector object isn't deleted and it isnt visible and its objectMode is a marking then
    ''draw the appropriate graphic for Text, Pic, and Line.
    Public Sub embedLayerObjectOverlay(ByVal vec As EditDaqumentUtil.Vector)
        Dim g As Graphics = Graphics.FromImage(OverlayBM)

        If Not vec.ObjectDeleted And LayerIsVisible(vec.layerID) And vec.ObjectMode = "Marking" Then

            If vec.VectorObjectType = "Text" Then
                Dim myFont = New Font(vec.fontfamily, vec.tBox.Font.Size * (CurrentScaleFactor / vec.OrgScaleX), _
                         vec.tBox.Font.Style, GraphicsUnit.Point)
                Dim myBrush As Brush = New SolidBrush(vec.tBox.ForeColor)
                g.DrawString(vec.text, myFont, myBrush, New Rectangle(New Point(vec.StartPointX + ScreenOffsetX, vec.StartPointY + ScreenOffsetY), vec.tBox.Size))
            ElseIf vec.VectorObjectType = "Pic" Then
                Dim img As Image = myDoc.ResizeImage(vec.pBox.Image, vec.pBox.Size)
                g.DrawImage(img, New Point(vec.StartPointX + ScreenOffsetX, vec.StartPointY + ScreenOffsetY))
            ElseIf vec.VectorObjectType = "Line" Then
                Dim clr As Color = Color.FromArgb(vec.penArgb)
                Dim clr2 As Color = Color.LightGray

                Dim myPen As Pen = New Pen(New SolidBrush(clr), vec.ScaledLineWidth)
                If Me.GrayscaleInactiveLayer.Checked Then
                    If Not vec.layerID = CurrentLayer Then
                        myPen = New Pen(New SolidBrush(clr2), vec.ScaledLineWidth)
                    End If
                End If

                myPen.EndCap = vec.lineEnd
                Dim startPoint As Point = New Point(vec.StartPointX + ScreenOffsetX, vec.StartPointY + ScreenOffsetY)
                Dim endPoint As Point = New Point(vec.endPointX + ScreenOffsetX, vec.endPointY + ScreenOffsetY)
                g.DrawLine(myPen, startPoint, endPoint)
            End If
        End If
    End Sub



    Private Sub RescaleVector(ByVal vec As EditDaqumentUtil.VectorMap, ByVal MagX As Single, ByVal MagY As Single)
        Dim newScaleX = MagX / vec.OrgScaleX
        Dim newScaleY = MagY / vec.OrgScaleY
        vec.StartPointX = vec.OrgStartPointX * newScaleX
        vec.StartPointY = vec.OrgStartPointY * newScaleY
        Dim newLoc As Point = New Point(vec.StartPointX, vec.StartPointY)
        If vec.VectorObjectType = "Line" Or vec.VectorObjectType = "Weld" Then
            vec.endPointX = vec.OrgEndPointX * newScaleX
            vec.endPointY = vec.OrgEndPointY * newScaleY
            vec.ScaledlineWidth = vec.OrgLineWidth * newScaleY
        ElseIf vec.VectorObjectType = "Text" Then
            If Not vec.tBox Is Nothing Then
                If vec.tBox.Text > "" Then
                    Dim bm = New Bitmap(vec.tBox.Bounds.Size.Width, vec.tBox.Bounds.Size.Height)
                    Dim picCanvas As Graphics = Graphics.FromImage(bm)
                    picCanvas.FillRectangle(Brushes.White, 0, 0, vec.tBox.Bounds.Size.Width, vec.tBox.Bounds.Size.Height)
                    Dim myBrush As Brush = New SolidBrush(vec.tBox.ForeColor)
                    picCanvas.DrawString(vec.tBox.Text, vec.tBox.Font, myBrush, New Rectangle(New Point(0, 0), vec.tBox.Size))
                    Dim m As New MemoryStream
                    bm.Save(m, ImageFormat.Png)
                    If Not vec.vectorImage Is Nothing Then
                        vec.vectorImage.Dispose()
                    End If
                    'keep original image
                    vec.vectorImage = System.Drawing.Image.FromStream(m)

                    Dim tBoxRatio As Single = CType(vec.tBox.Size.Height, Single) / CType(vec.tBox.Size.Width, Single)
                    Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX) * newScaleX
                    Dim Height As Single = Width * tBoxRatio
                    vec.endPointX = vec.StartPointX + Width
                    vec.endPointY = vec.StartPointY + Height
                    vec.tBox.Location = newLoc
                    'vec.tBox.Height = Height
                    'vec.tBox.Width = Width
                    If Not vec.pBox.Image Is Nothing Then
                        vec.pBox.Image.Dispose()
                    End If
                    vec.pBox.Image = myDoc.ResizeImage(vec.vectorImage, vectorScreenBoundRectangle(vec.thisVector).Size)
                    vec.tBox.Visible = False
                    vec.VectorType = EditDaqumentUtil.mode.EmbedText
                    vec.itmSelected = False
                End If
            End If
        ElseIf vec.VectorObjectType = "Pic" Then
            If Not vec.pBox Is Nothing Then
                Dim pBoxRatio As Single = CType(vec.pBox.Size.Height, Single) / CType(vec.pBox.Size.Width, Single)
                Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX) * newScaleX
                Dim Height As Single = Width * pBoxRatio
                vec.endPointX = vec.StartPointX + Width
                vec.endPointY = vec.StartPointY + Height
                vec.pBox.Size = vectorScreenBoundRectangle(vec.thisVector).Size
                vec.pBox.Location = newLoc
                'Dim img As Image = myDoc.ResizeImage(vec.pBox.Image, New Size(Width, Height))
                'vec.pBox.Image.Dispose()
                'vec.pBox.Image = img
                vec.VectorType = EditDaqumentUtil.mode.EmbedImage
                vec.itmSelected = False
            End If
        End If
    End Sub



    ''  resets the originalDocImage size based on the magX and magY variables then creates a new bitmap to that size
    ''  myDoc.ResizeImage(newSize) scales the image as a ratio newsize/oldsize, creates a new image with the new size and returns it.
    ''It then sets the image to transperent, places it in the pictureBox and sets the currentScalFactor as a ratio of pictureBox.width/originalSize.width
    '' 
    
    Private Function ResizeDrawingView(ByVal MagX As Single, ByVal MagY As Single) As Boolean
        Dim sX As Integer = MagX * myDoc.OriginalDrawingSize.Width
        Dim sY As Integer = MagY * myDoc.OriginalDrawingSize.Height
        If (sX * sY) > 20000000 Then
            MessageBox.Show("Not enough memory")
            Return False
        End If
        Dim newSize As Size = New Size(sX, sY)
        If Not PictureBox1.Image Is Nothing Then
            PictureBox1.Image.Dispose()
        End If

        Dim bmp_Image As Bitmap
        bmp_Image = myDoc.ResizeImage(newSize)

        For i As Integer = 0 To 3
            bmp_Image.MakeTransparent(Color.FromArgb(255, 255 - i, 255 - i, 255 - i))
        Next

        PictureBox1.Image = bmp_Image
        If Not PictureBox1ImageCopy Is Nothing Then
            PictureBox1ImageCopy.Dispose()
        End If
        PictureBox1ImageCopy = PictureBox1.Image.Clone
        PictureBox1.Size = PictureBox1.Image.Size

        CurrentScaleFactor = PictureBox1.Size.Width / myDoc.OriginalDrawingSize.Width


        '' CreatePageOverlay() Creates an overlay bitmap to the width/height of the pictureBox, and creates a drawingArea rectangle the size of the PictureBox
        CreatePageOverlay(bmp_Image)

        ''  CreateOverlay() Creates a drawingArea rectangle with pictureBoxImage1Copy called OverlayBM. For every layer in the dropdownitems get the layerID from 
        ''  the layerInfoTbl and for each vector in list of vectors if the vec.layerID=LayerID call embedLayerObjectOverlay

        CreateOverlay()
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            ClearSelectedBoundryBox(vec)
            RescaleVector(vec, MagX, MagY)
            embedLayerObject(vec.thisVector)
        Next

        Dim g As Graphics = Graphics.FromImage(Me.PictureBox1.Image)
        g.DrawImage(PageOverlayBM, 0, 0)

        Redraw()

        PictureBox1.Location = New Point(ScreenOffsetX, ScreenOffsetY)
        PictureBox1.Refresh()
        Return True
    End Function


    Private Sub ComputDragLocation(ByVal sender As System.Object, ByVal vec As EditDaqumentUtil.VectorMap)
        Dim dragX = Control.MousePosition.X - dragStartPoint.X
        Dim dragY = Control.MousePosition.Y - dragStartPoint.Y

        Me.drag.Text = dragX.ToString + "," + dragY.ToString
        Me.vec.Text = System.Windows.Forms.Control.MousePosition.X.ToString + "," + System.Windows.Forms.Control.MousePosition.Y.ToString

        Dim W = Math.Abs(vec.StartPointX - vec.endPointX)
        Dim H = Math.Abs(vec.StartPointY - vec.endPointY)

        Dim X = vec.StartPointX
        Dim Y = vec.StartPointY

        ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
        'ControlPaint.DrawReversibleFrame(New Rectangle(Control.MousePosition.X, Control.MousePosition.Y, vec.pBox.Width, vec.pBox.Height), Me.BackColor, FrameStyle.Dashed)

        Dim myControl As System.Windows.Forms.Control = sender
        Dim picPosition As String = Split(myControl.Name, "-")(2)
        If picPosition = "0" Then
            vec.StartPointX = vec.StartPointX + dragX
            vec.StartPointY = vec.StartPointY + dragY
            vec.endPointX = vec.endPointX + dragX
            vec.endPointY = vec.endPointY + dragY
            vec.OrgStartPointX = vec.StartPointX
            vec.OrgStartPointY = vec.StartPointY
            vec.OrgEndPointX = vec.endPointX
            vec.OrgEndPointY = vec.endPointY


            dragStartPoint = System.Windows.Forms.Control.MousePosition
            ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
            'ControlPaint.DrawReversibleFrame(New Rectangle(Control.MousePosition.X, Control.MousePosition.Y, vec.pBox.Width, vec.pBox.Height), Me.BackColor, FrameStyle.Dashed)
            Return
        ElseIf picPosition = "1" Then
            Y = Y + dragY : H = H - dragY
            PictureBox1.Cursor = Cursors.SizeNS
        ElseIf picPosition = "2" Then
            Y = Y + dragY : H = H - dragY : W = W - dragY
            PictureBox1.Cursor = Cursors.SizeNESW
        ElseIf picPosition = "3" Then
            X = X + dragX : W = W - dragX
            PictureBox1.Cursor = Cursors.SizeWE
        ElseIf picPosition = "4" Then
            W = W + dragX
            PictureBox1.Cursor = Cursors.SizeWE
        ElseIf picPosition = "5" Then
            X = X + dragX : H = H + dragY : W = W - dragX
            PictureBox1.Cursor = Cursors.SizeNESW
        ElseIf picPosition = "6" Then
            H = H + dragY
            PictureBox1.Cursor = Cursors.SizeNS
        ElseIf picPosition = "7" Then
            H = H + dragY : W = W + dragY
            PictureBox1.Cursor = Cursors.SizeNWSE
        End If
        If H > 4 And W > 4 Then
            vec.StartPointX = X : vec.StartPointY = Y
            vec.endPointX = vec.endPointX + dragX : vec.endPointY = vec.endPointY + dragY
            vec.OrgStartPointX = vec.StartPointX : vec.OrgStartPointY = vec.StartPointY
            vec.OrgEndPointX = vec.endPointX : vec.OrgEndPointY = vec.endPointY
        End If

        dragStartPoint = System.Windows.Forms.Control.MousePosition
        'ControlPaint.DrawReversibleFrame(New Rectangle(Control.MousePosition.X, Control.MousePosition.Y, vec.pBox.Width, vec.pBox.Height), Me.BackColor, FrameStyle.Dashed)
        ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)

    End Sub


    Private Sub MakeTextImage(ByVal vec As EditDaqumentUtil.VectorMap)
        Dim bm = New Bitmap(vec.tBox.Bounds.Size.Width, vec.tBox.Bounds.Size.Height)
        Dim picCanvas As Graphics = Graphics.FromImage(bm)
        picCanvas.FillRectangle(Brushes.White, 0, 0, vec.tBox.Bounds.Size.Width, vec.tBox.Bounds.Size.Height)
        Dim myBrush As Brush = New SolidBrush(vec.tBox.ForeColor)

        Dim tSize = TextRenderer.MeasureText(vec.tBox.Text, vec.tBox.Font)

        picCanvas.DrawString(vec.tBox.Text, vec.tBox.Font, myBrush, New Rectangle(New Point(0, 0), vec.tBox.Size))

        Dim currentScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
        Dim currentScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
        Dim newScaleX = currentScaleX / vec.OrgScaleX
        Dim newScaleY = currentScaleY / vec.OrgScaleY
        Dim m As New MemoryStream

        bm.Save(m, ImageFormat.Png)
        If Not vec.vectorImage Is Nothing Then
            vec.vectorImage.Dispose()
        End If
        'keep original image
        vec.vectorImage = System.Drawing.Image.FromStream(m)

        'keep the resize image
        If Not vec.pBox.Image Is Nothing Then
            vec.pBox.Image.Dispose()
        End If
        Dim bm_Vec As Bitmap = myDoc.ResizeImage(vec.vectorImage, New Size(vec.tBox.Bounds.Size.Width * newScaleX, vec.tBox.Bounds.Size.Height * newScaleY))

        bm_Vec.MakeTransparent(Color.White)
        vec.pBox.Image = bm_Vec

    End Sub

    ''Sets the pictureBox1 size to the picSize, sets the magnification variables
    ''calls resizeDrawingView()
    Private Sub ResizePageWidth()
        Dim picSize As Size = New Size(Me.ClientRectangle.Size.Width - ScreenOffsetX, Me.ClientRectangle.Size.Height - ScreenOffsetY)
        Dim orgSize As Size = myDoc.OriginalDrawingSize
        PictureBox1.Size = picSize
        Dim magX As Single = (picSize.Width / orgSize.Width) : Dim magY As Single = (picSize.Height / orgSize.Height)
        If ResizeDrawingView(magX, magY) Then
            Me.btnMaginfy.Text = String.Format("{0}%", CType((magX * 100), Integer))
        End If
    End Sub


    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Dim ScreenPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)

        GlobalScreenPoint = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)

        localStartPoint = New Point(e.X, e.Y)
        lineStartPoint = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
        If daqMode = EditDaqumentUtil.mode.FreeHand Then

            tmpVectors.Clear()

        ElseIf daqMode = EditDaqumentUtil.mode.lineDraw Then

            lineStartPoint = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
            lineEndPoint = lineStartPoint
            tmpVectors.Clear()

        ElseIf daqMode = EditDaqumentUtil.mode.InserWeld Then

            lineStartPoint = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
            lineEndPoint = lineStartPoint
            tmpVectors.Clear()

        ElseIf daqMode = EditDaqumentUtil.mode.InsertText Then

            picBoxDragHandle.Visible = False
            MakeNewTextBoxVector(ClientPoint)
            daqMode = EditDaqumentUtil.mode.ObjectSelected
            PictureBox1.Cursor = Cursors.Default

        ElseIf daqMode = EditDaqumentUtil.mode.InsertImage Then

            picBoxDragHandle.Visible = False
            MakeNewPictureImageVector(ClientPoint)
            daqMode = EditDaqumentUtil.mode.ObjectSelected
            PictureBox1.Cursor = Cursors.Default

        ElseIf daqMode = EditDaqumentUtil.mode.None Then
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                'If vec.VectorObjectType = "Pic" And vec.layerID = CurrentLayer And vec.ObjectDeleted = False Then
                '    vec.pBox.Image = myDoc.ResizeImage(vec.pBox.Image.Clone, New Size(vec.vectorImage.Width, vec.vectorImage.Height))
                'End If

                '                If vec.VectorObjectType = "Weld" And vec.layerID = CurrentLayer And vec.ObjectDeleted = False Then
                'If IsWeldPointHeadSelected(ClientPoint, vec.thisVector) Then
                'daqMode = EditDaqumentUtil.mode.WeldHeadSelected
                'vec.itmSelected = True
                '              lineEndPoint = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
                '             Dim pt As Point = New Point(vec.endPointX + ScreenOffsetX, vec.endPointY + ScreenOffsetY)
                '            lineStartPoint = New Point(PointToScreen(pt))
                '           tmpVectors.Clear()
                '          Exit For
                '         ElseIf IsWeldPointTailSelected(ClientPoint, vec.thisVector) Then
                '        vec.itmSelected = True
                '       daqMode = EditDaqumentUtil.mode.WeldTailSelected
                ''      lineEndPoint = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
                '    Dim pt As Point = New Point(vec.StartPointX + ScreenOffsetX, vec.StartPointY + ScreenOffsetY)
                '   lineStartPoint = New Point(PointToScreen(pt))
                '  tmpVectors.Clear()
                ' Exit For
                '        Else
                '        Dim test As String = "xxx"
                '        End If
                '        End If
                '       */
            Next
        End If

        Dim newPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
        theRectangle.Location = New Point(newPoint.X, newPoint.Y)
        theRectangle.Size = New Size(0, 0)
        'ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)


    End Sub


    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove

        Dim myPoint As Point = New Point(e.X, e.Y)
        Dim ScreenPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
        '        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)

        If daqMode = EditDaqumentUtil.mode.FreeHand Then
            If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
            Dim vec As EditDaqumentUtil.Vector = MakeNewLineVector(localStartPoint, myPoint)
            tmpVectors.Add(vec)
            localStartPoint = myPoint
            embedLayerObject(vec)

            If LayerMode = "Hilite" Then
                Dim g As Graphics = Graphics.FromImage(Me.PictureBox1.Image)
                g.DrawImage(OverlayBM, ScreenOffsetX * -1, ScreenOffsetY * -1)
            End If

            PictureBox1.Refresh()
        ElseIf daqMode = EditDaqumentUtil.mode.Drag Then
            If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
            Dim picPoint As Point = PictureBox1.Location
            Dim diffX = myPoint.X - localStartPoint.X : Dim diffY = myPoint.Y - localStartPoint.Y

            PictureBox1.Location = New Point(picPoint.X + diffX, picPoint.Y + diffY)
            ScreenOffsetX = ScreenOffsetX + diffX : ScreenOffsetY = ScreenOffsetY + diffY
            Me.PictureBox1.Refresh()
        ElseIf daqMode = EditDaqumentUtil.mode.lineDraw Then
            If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
            Dim newPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
            If myPoint.X > 0 And myPoint.Y > 0 Then
                ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
                lineEndPoint = newPoint
                ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
            End If
        ElseIf daqMode = EditDaqumentUtil.mode.InserWeld Then
            If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
            Dim newPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
            If myPoint.X > 0 And myPoint.Y > 0 Then
                ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
                lineEndPoint = newPoint
                ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
            End If
        ElseIf daqMode = EditDaqumentUtil.mode.None Then

            If (e.Button = System.Windows.Forms.MouseButtons.Left) Then
                Dim newPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)

                If theRectangle.X = 0 Then
                    theRectangle.Location = New Point(newPoint.X, newPoint.Y)
                Else

                    Dim myWidth = newPoint.X - theRectangle.X : Dim myHeight = newPoint.Y - theRectangle.Y
                    'theRectangle.Size = New Size(Math.Abs(myWidth), Math.Abs(myHeight))
                    theRectangle.Size = New Size(myWidth, myHeight)
                End If

                'theRectangle.Location = New Point(newPoint.X, newPoint.Y)
                'If theRectangle.X = 0 Then
                '    theRectangle.Location = New Point(newPoint.X, newPoint.Y)
                'Else

                '    Dim myWidth = theRectangle.X - GlobalScreenPoint.X : Dim myHeight = theRectangle.Y - GlobalScreenPoint.Y
                '    'theRectangle.Size = New Size(Math.Abs(myWidth), Math.Abs(myHeight))
                '    theRectangle.Size = New Size(myWidth, myHeight)

                'End If

                PictureBox1.Refresh()
                ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
            End If

        ElseIf daqMode = EditDaqumentUtil.mode.InsertText Then
            picBoxDragHandle.Visible = True
            picBoxDragHandle.Location = New Point(e.X + 5, e.Y + 5)
        ElseIf daqMode = EditDaqumentUtil.mode.InsertImage Then
            picBoxDragHandle.Visible = True
            picBoxDragHandle.Location = New Point(e.X + 5, e.Y + 5)
        ElseIf daqMode = EditDaqumentUtil.mode.WeldHeadSelected Then
            Dim newPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.VectorObjectType = "Weld" And vec.layerID = CurrentLayer _
                        And vec.ObjectDeleted = False And vec.itmSelected Then
                    If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
                    If myPoint.X > 30 And myPoint.Y > 30 Then
                        ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
                        lineEndPoint = newPoint
                        'Dim pt As Point = New Point(vec.endPointX + ScreenOffsetX, vec.endPointY + ScreenOffsetY)
                        'lineEndPoint = New Point(PointToScreen(pt))
                        ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
                        Exit For
                    End If
                End If
            Next
        ElseIf daqMode = EditDaqumentUtil.mode.WeldHeadSelected Or daqMode = EditDaqumentUtil.mode.WeldTailSelected Then
            Dim newPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.VectorObjectType = "Weld" And vec.layerID = CurrentLayer _
                        And vec.ObjectDeleted = False And vec.itmSelected Then
                    If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
                    If myPoint.X > 0 And myPoint.Y > 0 Then
                        ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
                        lineEndPoint = newPoint
                        ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub
   
    Private Function IsWeldPointTailSelected(ByVal sp As Point, ByVal vec As EditDaqumentUtil.Vector) As Boolean

        Dim scX = vec.endPointX / vec.OrgEndPointX : Dim scY = vec.endPointY / vec.OrgEndPointY
        Dim myX = (vec.endPointX - (10 * scX)) : Dim myY = (vec.endPointY - (10 * scY))
        Dim myWd = (20 * scX) : Dim myHt = (20 * scY)

        Dim WeldTailRectangle As Rectangle = New Rectangle(New Point(myX, myY), New Size(myWd, myHt))

        If WeldTailRectangle.Contains(sp) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Dim ScreenPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)

        If daqMode = EditDaqumentUtil.mode.FreeHand Then

            For Each vec As EditDaqumentUtil.Vector In tmpVectors
                Vectors.Add(New EditDaqumentUtil.VectorMap(vec))
            Next

        ElseIf daqMode = EditDaqumentUtil.mode.lineDraw And Not (localStartPoint.X = e.X And localStartPoint.Y = e.Y) Then

            ControlPaint.DrawReversibleLine(lineStartPoint, lineEndPoint, Color.Gray)
            Dim vec As EditDaqumentUtil.Vector = MakeNewLineVector(localStartPoint, e.Location)
            Vectors.Add(New EditDaqumentUtil.VectorMap(vec))
            embedLayerObject(vec)
            PictureBox1.Refresh()
      
        ElseIf daqMode = EditDaqumentUtil.mode.None Then

            If theRectangle.Size.Width < 0 Then
                theRectangle.Location = New Point(theRectangle.Location.X - Math.Abs(theRectangle.Size.Width), theRectangle.Location.Y)
                theRectangle.Width = Math.Abs(theRectangle.Size.Width)
            End If
            If theRectangle.Size.Height < 0 Then
                theRectangle.Location = New Point(theRectangle.Location.X, theRectangle.Location.Y - Math.Abs(theRectangle.Size.Height))
                theRectangle.Height = Math.Abs(theRectangle.Size.Height)
            End If

            ClearAllSelectedItems()
            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If theRectangle.Contains(vectorScreenBoundRectangle(vec.thisVector)) And vec.layerID = CurrentLayer And vec.ObjectDeleted = False Then
                    AddBoundryBox(vec.thisVector)
                    vec.itmSelected = True
                End If
            Next

            '    ElseIf daqMode = EditDaqumentUtil.mode.WeldHeadSelected Then
        
       


        End If

        If LayerMode = "Hilite" Then
            Dim g As Graphics = Graphics.FromImage(Me.PictureBox1.Image)
            g.DrawImage(PageOverlayBM, 0, 0)
            PictureBox1.Refresh()
        End If
        CreateOverlay()

        Redraw()


    End Sub


    Private Sub PictureBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        If (e.Button = System.Windows.Forms.MouseButtons.Right) Then
            cms1.Visible = True
            cms1.BringToFront()
            Return
        End If

        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Dim ScreenPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)
        If daqMode = EditDaqumentUtil.mode.lineDraw _
            Or daqMode = EditDaqumentUtil.mode.FreeHand _
            Or daqMode = EditDaqumentUtil.mode.Drag Then
            Return
        End If

        'ClearAllSelectedItems()
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            'If vec.itmSelected Then
            '    ClearSelectedBoundryBox(vec)
            'End If

            If Not vec.ObjectDeleted And vec.layerID = CurrentLayer Then
                If vectorScreenBoundRectangle(vec.thisVector).Contains(ScreenPoint) Then
                    'If vec.VectorType = EditDaqumentUtil.mode.EmbedText Then
                    If vec.VectorObjectType = "Text" Then
                        daqMode = EditDaqumentUtil.mode.ObjectSelected
                        vec.VectorType = EditDaqumentUtil.mode.InsertText
                        vec.itmSelected = True
                        Me.cbx_FontSize.Text = vec.tBox.Font.Size.ToString
                        AddBoundryBox(vec.thisVector)
                        Exit Sub
                    ElseIf vec.VectorType = EditDaqumentUtil.mode.EmbedImage Then
                        daqMode = EditDaqumentUtil.mode.ObjectSelected
                        vec.itmSelected = True
                        AddBoundryBox(vec.thisVector)
                        Exit Sub
                    End If
                End If
            End If
        Next


        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.itmSelected Then
                If vec.VectorObjectType = "Pic" Then
                    If Vectors.Count = 1 Then
                        Me.btn_RotateLeft.Enabled = True
                        Me.btn_RotateRight.Enabled = True
                    Else
                        Me.btn_RotateLeft.Enabled = False
                        Me.btn_RotateRight.Enabled = False
                    End If

                    ClearSelectedBoundryBox(vec)
                    vec.pBox.Visible = False
                    vec.itmSelected = False
                    embedLayerObject(vec.thisVector)
                    Me.CreateOverlay()

                    Redraw()

                ElseIf vec.VectorObjectType = "Text" Then
                    Me.btn_RotateLeft.Enabled = False
                    Me.btn_RotateRight.Enabled = False

                    If vec.tBox.Text > "" Then
                        'MakeTextImage(vec)
                        vec.text = vec.tBox.Text
                        vec.VectorType = EditDaqumentUtil.mode.EmbedText
                        vec.tBox.Visible = False
                        vec.itmSelected = False
                        'embedLayerObject(vec.thisVector)
                        ClearSelectedBoundryBox(vec)
                        Redraw()
                    Else
                        vec.itmSelected = False
                        vec.text = " "
                        vec.VectorType = EditDaqumentUtil.mode.EmbedText
                        vec.tBox.Visible = False
                        vec.ObjectDeleted = True
                        vec.VectorModified = True
                        Redraw()
                    End If
                End If
            End If
        Next

        Dim itmSel As Boolean = False
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.itmSelected Then itmSel = True
        Next
        If Not itmSel And daqMode = EditDaqumentUtil.mode.ObjectSelected Then
            daqMode = EditDaqumentUtil.mode.None
        End If


        PictureBox1.Refresh()
    End Sub


    Private Sub PictureBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDoubleClick
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Dim ScreenPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)
        If daqMode = EditDaqumentUtil.mode.lineDraw _
            Or daqMode = EditDaqumentUtil.mode.FreeHand _
            Or daqMode = EditDaqumentUtil.mode.Drag Then
            Return
        End If

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If Not vec.ObjectDeleted And vec.layerID = CurrentLayer Then
                If vec.VectorObjectType = "Text" Then
                    If vectorScreenBoundRectangle(vec.thisVector).Contains(ScreenPoint) Then
                        'If vec.VectorType = EditDaqumentUtil.mode.EmbedText Then
                        daqMode = EditDaqumentUtil.mode.ObjectSelected
                        'vec.VectorType = EditDaqumentUtil.mode.InsertText
                        vec.itmSelected = True
                        vec.tBox.Height = vec.endPointY - vec.StartPointY
                        vec.tBox.Width = vec.endPointX - vec.StartPointX
                        vec.tBox.Visible = True
                        'AddBoundryBox(vec.thisVector)
                        Exit Sub
                        'End If
                    End If
                End If
            End If
        Next

    End Sub


    Private Sub Redraw()
        If Not PictureBox1.Image Is Nothing Then
            PictureBox1.Image.Dispose()
        End If
        PictureBox1.Image = PictureBox1ImageCopy.Clone
        'PictureBox1.Image.Save("c:\pbx1.png", ImageFormat.Png)

        Dim layerCtr As Integer = 0
        Dim LayerID As String
        '        For Each ts As ToolStripMenuItem In Me.btnViewLayers.DropDownItems
        For Each ts As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            If ts.Checked Then
                LayerID = LayerInfoTbl.Rows(layerCtr)(0)
                For Each vec As EditDaqumentUtil.VectorMap In Vectors
                    If Not vec.ObjectDeleted And vec.ObjectMode = "Hilite" And vec.layerID = LayerID Then
                        embedLayerObject(vec.thisVector)
                    End If
                Next
            End If
            layerCtr = layerCtr + 1
        Next

        CreateOverlay()

        Dim g As Graphics = Graphics.FromImage(Me.PictureBox1.Image)
        g.DrawImage(PageOverlayBM, 0, 0)
        g.DrawImage(OverlayBM, ScreenOffsetX * -1, ScreenOffsetY * -1)
        'PictureBox1.Image.Save("c:\pbx2.png", ImageFormat.Png)

        layerCtr = 0
        '        For Each ts As ToolStripMenuItem In Me.btnViewLayers.DropDownItems
        For Each ts As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            If ts.Checked Then
                LayerID = LayerInfoTbl.Rows(layerCtr)(0)
                For Each vec As EditDaqumentUtil.VectorMap In Vectors
                    If Not vec.ObjectDeleted And vec.ObjectMode = "Marking" And vec.layerID = LayerID Then
                        'embedLayerObject(vec.thisVector)
                        embedLayerObjectOverlay(vec.thisVector)
                    End If
                Next
            End If
            layerCtr = layerCtr + 1
        Next
        'PictureBox1.Image.Save("c:\pbx3.png", ImageFormat.Png)

    End Sub
 



    Private Function MakeNewLineVector(ByVal StartPt As Point, ByVal EndPt As Point) As EditDaqumentUtil.Vector
        Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector
        VectorIDCtr = VectorIDCtr + 1
        myVector.vectorID = VectorIDCtr
        myVector.SQLID = ""
        myVector.layerID = CurrentLayer
        myVector.CabinetID = GetCurrentCabinetID()
        myVector.VectorModified = True
        myVector.StartPointX = StartPt.X : myVector.StartPointY = StartPt.Y
        myVector.endPointX = EndPt.X : myVector.endPointY = EndPt.Y
        myVector.OrgStartPointX = StartPt.X : myVector.OrgStartPointY = StartPt.Y
        myVector.OrgEndPointX = EndPt.X : myVector.OrgEndPointY = EndPt.Y
        myVector.DrawingID = DocumentID
        myVector.OrgLineWidth = CurrentLineWidth
        myVector.ScaledLineWidth = CurrentLineWidth
        Dim myPen As New Pen(New SolidBrush(CurrentColor), CurrentLineWidth)
        myPen.EndCap = Drawing2D.LineCap.Round
        myVector.penArgb = myPen.Color.ToArgb
        '            myVector.Opaque = IIf(btnMarking.Checked, True, False)
        myVector.VectorType = daqMode
        myVector.lineEnd = myPen.EndCap
        myVector.seqNumber = Vectors.Count + 1
        myVector.ObjectDeleted = False
        myVector.VectorObjectType = "Line"
        myVector.DateCreated = Now
        '            myVector.boundRectangle = New Rectangle(Control.MousePosition.X, Control.MousePosition.Y, 0, 0)
        myVector.OrgScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
        myVector.OrgScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
        If LayerMode = "Hilite" Then
            myVector.ObjectMode = "Hilite"
        Else
            myVector.ObjectMode = "Marking"
        End If
        Dim act As UserAction = New UserAction(UserAction.ActionType.Add, myVector.vectorID)
        UserActionList.Add(act)
        Return myVector
    End Function

  

    Private Function MakeNewPictureImageVector(ByVal location As Point) As EditDaqumentUtil.Vector
        '        AddHandler mBox.DoubleClick, AddressOf TextBox1_DoubleClick
        Dim MyParent As DaqumentMain = Me.ParentForm
        Dim pBox As PictureBox = New PictureBox()

        Dim bmp_Temp As Bitmap = PicBox2.Image.Clone
        'bmp_Temp.MakeTransparent()
        'bmp_Temp.MakeTransparent(bmp_Temp.GetPixel(2, 2))

        VectorIDCtr = VectorIDCtr + 1
        Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector
        myVector.VectorImage = bmp_Temp
        myVector.vectorID = VectorIDCtr
        myVector.SQLID = ""
        myVector.layerID = CurrentLayer
        myVector.CabinetID = GetCurrentCabinetID()
        myVector.VectorModified = True
        'If btnMarking.Checked Then
        '    myVector.VectorImage = PicBox2.Image
        'Else
        '    Dim bm = New Bitmap(PicBox2.Image.Width, PicBox2.Image.Height)
        '    Using picCanvas As Graphics = Graphics.FromImage(bm)
        '        picCanvas.FillRectangle(Brushes.White, 0, 0, PicBox2.Image.Width, PicBox2.Image.Height)
        '        picCanvas.DrawImage(PicBox2.Image, 0, 0)
        '        Dim backColor As Color = bm.GetPixel(1, 1)
        '        bm.MakeTransparent(backColor)
        '        myVector.VectorImage = bm
        '    End Using
        'End If
        pBox.Name = VectorIDCtr.ToString
        'myDoc.ResizeImage(myVector.VectorImage.Clone, New Size(vec.width, vec.height))
        pBox.Image = myVector.VectorImage.Clone
        'pBox.Image = myDoc.ResizeImage(pBox.Image.Clone, New Size(myVector.VectorImage.Width, myVector.VectorImage.Height))
        'pBox.Image.Save("c:\test.png", System.Drawing.Imaging.ImageFormat.Png)

        pBox.Size = pBox.Image.Size
        pBox.BringToFront()
        pBox.Location = location
        PictureBox1.Controls.Add(pBox)

        myVector.VectorType = EditDaqumentUtil.mode.EmbedImage
        myVector.ObjectDeleted = False
        myVector.VectorObjectType = "Pic"
        myVector.ObjectMode = "Marking"
        myVector.StartPointX = pBox.Location.X : myVector.StartPointY = pBox.Location.Y
        myVector.endPointX = pBox.Location.X + pBox.Width : myVector.endPointY = pBox.Location.Y + pBox.Height
        myVector.OrgStartPointX = pBox.Location.X : myVector.OrgStartPointY = pBox.Location.Y
        myVector.OrgEndPointX = pBox.Location.X + pBox.Width : myVector.OrgEndPointY = pBox.Location.Y + pBox.Height
        myVector.seqNumber = Vectors.Count + 1
        myVector.DrawingID = DocumentID
        myVector.itmSelected = True
        myVector.DateCreated = Now
        myVector.pBox = pBox

        '        myVector.Opaque = IIf(btnMarking.Checked, True, False)
        '       myVector.boundRectangle = New Rectangle(Control.MousePosition, pBox.Size)
        myVector.OrgScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
        myVector.OrgScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
        Vectors.Add(New EditDaqumentUtil.VectorMap(myVector))
        AddBoundryBox(myVector)
        '        AddHandler pBox.MouseClick, AddressOf SelectedBox_MouseClick
        'AddHandler pBox.PreviewKeyDown, AddressOf SelectedPitcureBox_PreviewKeyDown
        '        AddHandler pBox.DoubleClick, AddressOf SelectedBox_DoubleClick
        Dim act As UserAction = New UserAction(UserAction.ActionType.Add, myVector.vectorID)
        UserActionList.Add(act)
        Return myVector

    End Function


    Private Function MakeNewTextBoxVector(ByVal location As Point) As EditDaqumentUtil.Vector
        '        AddHandler mBox.DoubleClick, AddressOf TextBox1_DoubleClick
        Dim MyParent As DaqumentMain = Me.ParentForm
        Dim mBox As TextBox = New TextBox()
        VectorIDCtr = VectorIDCtr + 1
        mBox.Name = VectorIDCtr.ToString
        'mBox.Font = btnFontSelect.Font

        Dim MyStyle As FontStyle = FontStyle.Regular
        If Me.btn_Bold.Checked And Me.btn_Italic.Checked Then
            MyStyle = FontStyle.Bold + FontStyle.Italic
        ElseIf Me.btn_Bold.Checked Then
            MyStyle = FontStyle.Bold
        ElseIf Me.btn_Italic.Checked Then
            MyStyle = FontStyle.Italic
        End If

        Dim MyFont As Font = New Font("Verdana", Me.cbx_FontSize.Text, MyStyle, GraphicsUnit.Point)
        mBox.Font = MyFont
        mBox.ForeColor = Me.btn_TextColor.ForeColor

        mBox.Text = ""
        mBox.BringToFront()
        mBox.Location = location
        mBox.Multiline = True
        PictureBox1.Controls.Add(mBox)
        mBox.BringToFront()
        Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector
        myVector.vectorID = VectorIDCtr
        myVector.SQLID = ""
        myVector.layerID = CurrentLayer
        myVector.CabinetID = GetCurrentCabinetID()
        myVector.VectorModified = True
        myVector.VectorType = daqMode
        myVector.ObjectDeleted = False
        myVector.VectorObjectType = "Text"
        myVector.ObjectMode = "Marking"
        myVector.StartPointX = mBox.Location.X : myVector.StartPointY = mBox.Location.Y
        myVector.endPointX = mBox.Location.X + mBox.Width : myVector.endPointY = mBox.Location.Y + mBox.Height
        myVector.OrgStartPointX = mBox.Location.X : myVector.OrgStartPointY = mBox.Location.Y
        myVector.OrgEndPointX = mBox.Location.X + mBox.Width : myVector.OrgEndPointY = mBox.Location.Y + mBox.Height
        myVector.seqNumber = Vectors.Count + 1
        myVector.DrawingID = DocumentID
        myVector.itmSelected = True
        myVector.DateCreated = Now
        myVector.tBox = mBox
        Dim pBox As PictureBox = New PictureBox()
        myVector.pBox = pBox
        'myVector.Opaque = IIf(btnMarking.Checked, True, False)
        'myVector.boundRectangle = New Rectangle(Control.MousePosition, mBox.Size)
        myVector.OrgScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
        myVector.OrgScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
        Vectors.Add(New EditDaqumentUtil.VectorMap(myVector))
        'AddBoundryBox(myVector)
        '        AddHandler mBox.MouseClick, AddressOf SelectedBox_MouseClick
        'AddHandler mBox.KeyDown, AddressOf SelectedBox_KeyDown
        '        AddHandler mBox.DoubleClick, AddressOf SelectedBox_DoubleClick
        Dim act As UserAction = New UserAction(UserAction.ActionType.Add, myVector.vectorID)
        UserActionList.Add(act)
        Return myVector

    End Function


    Private Sub AddBoundryBox(ByVal vec As EditDaqumentUtil.Vector)

        Dim Width As Integer = Math.Abs(vec.StartPointX - vec.endPointX)
        Dim Height As Integer = Math.Abs(vec.StartPointY - vec.endPointY)
        Dim rect As Rectangle = New Rectangle(vec.StartPointX, vec.StartPointY, Width, Height)

        If vec.VectorObjectType = "Line" Then
            For i As Integer = 0 To 1
                Dim pic As PictureBox = New PictureBox
                pic.Size = New Size(8, 8)
                If i = 0 Then
                    pic.Location = New Point(vec.StartPointX, vec.StartPointY)
                Else
                    pic.Location = New Point(vec.endPointX, vec.endPointY)
                End If
                pic.BorderStyle = BorderStyle.FixedSingle
                PictureBox1.Controls.Add(pic)
                pic.BringToFront()
                pic.Visible = True
                Dim sCtrl As SeqControl
                sCtrl.Ctrl = pic : sCtrl.seqNumber = vec.seqNumber
                sCtrl.vecID = vec.vectorID
                tmpControls.Add(sCtrl)
            Next
            Return
        End If
        Dim picCtr = 0
        Dim lineTipCtr = 0

        Dim loc() As Point = { _
                New Point(rect.X - 8, rect.Y - 8), New Point(rect.X - 2 + rect.Width / 2, rect.Y - 4), _
                New Point(rect.X + rect.Width, rect.Y - 4), New Point(rect.X - 4, rect.Y - 2 + rect.Height / 2), _
                New Point(rect.X + rect.Width, rect.Y - 2 + rect.Height / 2), New Point(rect.X - 4, rect.Y + rect.Height), _
                New Point(rect.X - 2 + rect.Width / 2, rect.Y + rect.Height), New Point(rect.X + rect.Width, rect.Y + rect.Height)}
        Dim side() As Size = {New Size(8, 8), New Size(4, 4), New Size(4, 4), New Size(4, 4), _
                New Size(4, 4), New Size(4, 4), New Size(4, 4), New Size(4, 4)}
        For i As Integer = 0 To 7
            Dim pic As PictureBox = New PictureBox
            pic.Size = side(i)
            pic.Location = loc(i)
            pic.Name = "pic-" + vec.vectorID.ToString + "-" + i.ToString

            Dim bmp = New Bitmap(pic.Size.Width, pic.Size.Height)
            Dim g As Graphics = Graphics.FromImage(bmp)
            Dim customColor As Color = Color.FromArgb(200, Color.Blue)
            g.FillRectangle(New SolidBrush(customColor), 0, 0, pic.Bounds.Width, pic.Bounds.Height)
            pic.Image = bmp
            PictureBox1.Controls.Add(pic)

            Dim sCtrl As SeqControl
            sCtrl.Ctrl = pic : sCtrl.seqNumber = vec.seqNumber
            sCtrl.vecID = vec.vectorID
            tmpControls.Add(sCtrl)

            AddHandler pic.MouseHover, AddressOf TestPicBox_MouseHover
            AddHandler pic.MouseDown, AddressOf TestPicBox_MouseDown
            AddHandler pic.MouseMove, AddressOf TestPicBox_MouseMove
            AddHandler pic.MouseUp, AddressOf TestPicBox_MouseUp
            AddHandler pic.MouseLeave, AddressOf TestPicBox_MouseLeave
        Next
        '                vec.boundRectangle = New Rectangle(New Point(vec.StartPointX, vec.StartPointY), New Size(Width, Height))
        ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec), Me.BackColor, FrameStyle.Dashed)

    End Sub


    Private Function vectorScreenBoundRectangle(ByVal vec As EditDaqumentUtil.Vector) As Rectangle
        Dim Width As Integer = Math.Abs(vec.StartPointX - vec.endPointX)
        Dim Height As Integer = Math.Abs(vec.StartPointY - vec.endPointY)

        Dim vecRectangle As Rectangle = New Rectangle(PointToScreen(New Point(vec.StartPointX + ScreenOffsetX, vec.StartPointY + ScreenOffsetY)), _
                New Size(Width, Height))
        Return vecRectangle
    End Function


    Private Sub TestPicBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        If daqMode = EditDaqumentUtil.mode.None Then
            daqMode = EditDaqumentUtil.mode.ObjectSelected
            '            AddBoundryBox()
        End If
        If daqMode = EditDaqumentUtil.mode.ObjectSelected Then
            dragStartPoint = System.Windows.Forms.Control.MousePosition
        End If
        Dim vectorID As Integer = CType(Split(CType(sender, System.Windows.Forms.Control).Name, "-")(1), Integer)
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.vectorID = vectorID Then
                Dim act As UserAction = New UserAction(UserAction.ActionType.Modify, vec.vectorID, vec.thisVector)
                UserActionList.Add(act)
                ' Me.cbx_FontSize.Text = vec.tBox.Font.Size.ToString
                If vec.VectorObjectType = "Text" Then
                    Me.cbx_FontSize.Text = vec.tBox.Font.Size.ToString
                End If
                Me.Refresh()


                Exit Sub
            End If
        Next


    End Sub


    Private Sub TestPicBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (e.Button <> System.Windows.Forms.MouseButtons.Left) Then Return
        Me.vec.Text = Windows.Forms.Cursor.Position.X.ToString + "," + Windows.Forms.Cursor.Position.Y.ToString

        Dim vectorID As Integer = CType(Split(CType(sender, System.Windows.Forms.Control).Name, "-")(1), Integer)
        If daqMode = EditDaqumentUtil.mode.ObjectSelected Then
            daqMode = EditDaqumentUtil.mode.DragObject
            'For Each ctrl As SeqControl In tmpControls
            '    ctrl.Ctrl.Visible = False
            'Next
            'PictureBox1.Refresh()
            ''            dragStartPoint = Control.MousePosition
        End If
        If daqMode = EditDaqumentUtil.mode.DragObject Then
            'Dim dragX = Control.MousePosition.X - dragStartPoint.X
            'Dim dragY = Control.MousePosition.Y - dragStartPoint.Y
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.itmSelected Then
                    If vec.vectorID = vectorID Then
                        ComputDragLocation(sender, vec)

                        'ControlPaint.DrawReversibleFrame(New Rectangle(Control.MousePosition.X, Control.MousePosition.Y, vec.pBox.Width, vec.pBox.Height), Me.BackColor, FrameStyle.Dashed)
                        'dragStartPoint = System.Windows.Forms.Control.MousePosition
                        Exit Sub
                    End If
                    'ControlPaint.DrawReversibleFrame(vectorBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
                    'Dim newLoc As Point = New Point(vectorBoundRectangle(vec.thisVector).X + dragX, vectorBoundRectangle(vec.thisVector).Y + dragY)
                    'vectorBoundRectangle(vec.thisVector) = New Rectangle(newLoc, vectorBoundRectangle(vec.thisVector).Size)
                    'ControlPaint.DrawReversibleFrame(vectorBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
                End If
            Next
        End If
    End Sub


    Private Sub TestPicBox_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PictureBox1.Cursor = Cursors.Default
    End Sub


    Private Sub TestPicBox_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim myControl As System.Windows.Forms.Control = sender
        Dim picPosition As String = Split(myControl.Name, "-")(2)
        If picPosition = "0" Then
            PictureBox1.Cursor = Cursors.Hand
        ElseIf picPosition = "1" Then
            PictureBox1.Cursor = Cursors.SizeNS
        ElseIf picPosition = "2" Then
            PictureBox1.Cursor = Cursors.SizeNESW
        ElseIf picPosition = "3" Then
            PictureBox1.Cursor = Cursors.SizeWE
        ElseIf picPosition = "4" Then
            PictureBox1.Cursor = Cursors.SizeWE
        ElseIf picPosition = "5" Then
            PictureBox1.Cursor = Cursors.SizeNESW
        ElseIf picPosition = "6" Then
            PictureBox1.Cursor = Cursors.SizeNS
        ElseIf picPosition = "7" Then
            PictureBox1.Cursor = Cursors.SizeNWSE
        End If
        PictureBox1.Refresh()
    End Sub


    Private Sub TestPicBox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If daqMode = EditDaqumentUtil.mode.DragObject Then
            Dim vectorID As Integer = CType(Split(CType(sender, System.Windows.Forms.Control).Name, "-")(1), Integer)
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.vectorID = vectorID Then
                    vec.VectorModified = True
                    ControlPaint.DrawReversibleFrame(vectorScreenBoundRectangle(vec.thisVector), Me.BackColor, FrameStyle.Dashed)
                    If vec.VectorObjectType = "Text" Then
                        vec.tBox.Size = vectorScreenBoundRectangle(vec.thisVector).Size
                        vec.tBox.Location = New Point(vec.StartPointX, vec.StartPointY)
                        Me.cbx_FontSize.Text = vec.tBox.Font.Size.ToString
                        If vec.tBox.Text > "" Then
                            MakeTextImage(vec)
                            vec.VectorType = EditDaqumentUtil.mode.EmbedText
                            vec.tBox.Visible = False
                            vec.itmSelected = False
                        Else
                            PictureBox1.Refresh()
                            Exit Sub
                        End If
                    ElseIf vec.VectorObjectType = "Pic" Then
                        vec.pBox.Size = vectorScreenBoundRectangle(vec.thisVector).Size
                        vec.pBox.Location = New Point(vec.StartPointX, vec.StartPointY)
                        Dim newW = vec.pBox.Size.Width : Dim newH = vec.pBox.Size.Height
                        Dim img As Image = myDoc.ResizeImage(vec.pBox.Image, New Size(newW, newH))
                        vec.pBox.Image.Dispose()
                        vec.pBox.Image = img
                        vec.VectorType = EditDaqumentUtil.mode.EmbedImage
                    End If
                    embedLayerObject(vec.thisVector)
                    ClearSelectedBoundryBox(vec)
                    vec.pBox.Visible = False
                    daqMode = EditDaqumentUtil.mode.None
                    Me.CreateOverlay()

                    Redraw()
                    PictureBox1.Cursor = Cursors.Default
                    PictureBox1.Refresh()
                    Exit Sub
                End If
            Next
            '            AddBoundryBox()
        End If
    End Sub


    Private Function LayerSelected() As Boolean
        If CurrentLayer = "" Then
            MessageBox.Show("Please Select a drawing layer")
            Return False
        Else
            Return True
        End If
  
    End Function


    Private Function GetSeqCtrl(ByVal seq As Integer) As Integer
        For i As Integer = 0 To tmpControls.Count - 1
            If tmpControls(i).seqNumber = seq Then Return i
        Next
        Return -1
    End Function


    Private Sub ClearAllSelectedItems()

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            vec.itmSelected = False
        Next
        Dim i As Integer = 0
        For Each sCtrl As SeqControl In tmpControls
            sCtrl.Ctrl.Dispose()
        Next
        tmpControls.Clear()
    End Sub


    Private Sub ClearSelectedBoundryBox(ByVal vec As EditDaqumentUtil.VectorMap)
        Dim i As Integer = 0
        While i >= 0
            i = GetSeqCtrl(vec.seqNumber)
            If i >= 0 Then
                tmpControls(i).Ctrl.Dispose()
                tmpControls.RemoveAt(i)
            End If
        End While
        vec.itmSelected = False

        localStartPoint = New Point(0, 0)
        theRectangle.Location = New Point(0, 0)
        theRectangle.Size = New Size(0, 0)

    End Sub



    Private Sub DeleteSelectedObjects()
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            For Each sCtrl As SeqControl In tmpControls
                If sCtrl.vecID = vec.vectorID Then
                    vec.ObjectDeleted = True
                    If Not vec.tBox Is Nothing Then
                        vec.tBox.Visible = False
                    End If
                    If Not vec.pBox Is Nothing Then
                        vec.pBox.Visible = False
                    End If
                End If
            Next
        Next
        ClearAllSelectedItems()
        Redraw()
        PictureBox1.Refresh()
    End Sub


    Private Sub cbx_ActivateLayer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbx_ActivateLayer.KeyDown
        If daqMode = EditDaqumentUtil.mode.ObjectSelected Then
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.itmSelected Then
                    Dim objMoved As Boolean = False
                    Dim X = vectorScreenBoundRectangle(vec.thisVector).X : Dim Y = vectorScreenBoundRectangle(vec.thisVector).Y
                    If e.KeyCode = Keys.Escape Then
                        vec.ObjectDeleted = True
                    End If
                    If e.KeyCode = Keys.Delete Then
                        vec.ObjectDeleted = True
                    End If
                    If e.KeyCode = Keys.Left Then
                        X = X - 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Right Then
                        X = X + 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Up Then
                        Y = Y - 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Down Then
                        Y = Y + 1 : objMoved = True
                    End If
                    If objMoved Then
                        'ResizeObject(vec)
                    End If
                End If
            Next

        End If
        If e.KeyCode = Keys.Delete Then
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                For Each sCtrl As SeqControl In tmpControls
                    If sCtrl.vecID = vec.vectorID Then
                        vec.ObjectDeleted = True
                        If Not vec.tBox Is Nothing Then
                            vec.tBox.Visible = False
                        End If
                        If Not vec.pBox Is Nothing Then
                            vec.pBox.Visible = False
                        End If
                    End If
                Next
            Next
            ClearAllSelectedItems()
            Redraw()
            PictureBox1.Refresh()
        End If

        If e.KeyCode = Keys.Escape Then
            ClearAllSelectedItems()
            Redraw()
            PictureBox1.Refresh()
        End If

        PictureBox1.Refresh()
    End Sub
    
    Private Sub SaveObjects(ByVal LayerID As String)
        Dim layerCtr As Integer = 0

        For Each vec As EditDaqumentUtil.VectorMap In Vectors

            If vec.layerID = LayerID Then

                '  If vec.VectorObjectType = "Weld" Then SaveWeldPointObjects(vec)

                vec.lastUser = runtime.UserMUID
                If vec.VectorType = EditDaqumentUtil.mode.InsertText Or vec.VectorType = EditDaqumentUtil.mode.EmbedText Then
                    vec.fontbackcolor = vec.tBox.BackColor.ToArgb
                    vec.fontforecolor = vec.tBox.ForeColor.ToArgb
                    vec.text = vec.tBox.Text
                    vec.fontSize = vec.tBox.Font.Size
                    vec.fontFamily = vec.tBox.Font.FontFamily.ToString
                End If

                If Not vec.ObjectDeleted And vec.SQLID = "" Then
                    Dim retID = myDoc.InsertLayerVector(vec)
                    If retID = "" Then
                        MessageBox.Show("Falied to create Database record")
                    Else
                        vec.SQLID = retID
                    End If
                ElseIf Not vec.ObjectDeleted And Not vec.SQLID = "" And Not vec.VectorObjectType = "Line" Then
                    myDoc.UpdateLayerVector(vec)
                ElseIf vec.ObjectDeleted And Not vec.SQLID = "" Then
                    myDoc.DeleteLayerVector(vec)
                End If


                vec.VectorModified = False
            End If
        Next
    End Sub
    Private Sub loadLayerVectors(ByVal layerID As String)
        myDoc.LoadLayerVectors(layerID)

        Dim picSize As Size = PictureBox1.Size
        Dim orgSize As Size = myDoc.OriginalDrawingSize
        Dim magX As Single = (picSize.Width / orgSize.Width) : Dim magY As Single = (picSize.Height / orgSize.Height)
        For Each vec As EditDaqumentUtil.Vector In myDoc.LayerVectorArray
            Dim myVector As EditDaqumentUtil.Vector = New EditDaqumentUtil.Vector
            VectorIDCtr = VectorIDCtr + 1
            myVector.vectorID = VectorIDCtr
            myVector.SQLID = vec.SQLID
            myVector.layerID = vec.layerID
            myVector.VectorModified = False
            myVector.VectorType = vec.VectorType
            myVector.CabinetID = vec.CabinetID
            myVector.ObjectDeleted = False
            myVector.OrgScaleX = vec.OrgScaleX
            myVector.OrgScaleY = vec.OrgScaleY
            myVector.OrgStartPointX = vec.OrgStartPointX
            myVector.OrgStartPointY = vec.OrgStartPointY
            myVector.OrgEndPointX = vec.OrgEndPointX
            myVector.OrgEndPointY = vec.OrgEndPointY
            myVector.OrgLineWidth = vec.OrgLineWidth
            myVector.StartPointX = vec.OrgStartPointX
            myVector.StartPointY = vec.OrgStartPointY
            myVector.endPointX = vec.OrgEndPointX
            myVector.endPointY = vec.OrgEndPointY


            'Dim newScaleX = magX / vec.OrgScaleX
            'Dim newScaleY = magY / vec.OrgScaleY
            Dim currentScaleX = Convert.ToSingle(PictureBox1.Image.Size.Width) / Convert.ToSingle(myDoc.OriginalDrawingSize.Width)
            Dim currentScaleY = Convert.ToSingle(PictureBox1.Image.Size.Height) / Convert.ToSingle(myDoc.OriginalDrawingSize.Height)
            Dim newScaleX = currentScaleX / vec.OrgScaleX
            Dim newScaleY = currentScaleY / vec.OrgScaleY

            myVector.ObjectMode = vec.ObjectMode


            myVector.StartPointX = vec.OrgStartPointX * newScaleX
            myVector.StartPointY = vec.OrgStartPointY * newScaleY

            myVector.endPointX = vec.OrgEndPointX * newScaleX
            myVector.endPointY = vec.OrgEndPointY * newScaleY
            myVector.ScaledLineWidth = vec.OrgLineWidth * newScaleY

            myVector.seqNumber = vec.seqNumber
            myVector.DrawingID = vec.DrawingID
            myVector.penArgb = vec.penArgb
            myVector.lineEnd = vec.lineEnd
            myVector.itmSelected = False
            myVector.DateCreated = vec.DateCreated
            myVector.VectorObjectType = vec.VectorObjectType
            If vec.VectorObjectType = "Pic" Then
                myVector.VectorImage = vec.VectorImage
                Dim pBox As PictureBox = New PictureBox()
                pBox.Name = VectorIDCtr.ToString
                Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX)
                Dim Height As Single = Math.Abs(vec.OrgStartPointY - vec.OrgEndPointY)
                pBox.Size = New Size(Width, Height)
                'pBox.Size = myVector.VectorImage.Size
                pBox.Image = myVector.VectorImage.Clone
                Dim img As Image = myDoc.ResizeImage(pBox.Image, New Size(Width, Height))
                pBox.Image.Dispose()
                pBox.Image = img
                pBox.SendToBack()
                pBox.Visible = False
                pBox.Location = New Point(myVector.StartPointX, myVector.StartPointY)
                PictureBox1.Controls.Add(pBox)
                myVector.pBox = pBox
            End If
            If myVector.VectorObjectType = "Text" Then
                myVector.text = vec.text
                myVector.fontfamily = vec.fontfamily
                myVector.fontsize = vec.fontsize
                myVector.fontforecolor = vec.fontforecolor
                myVector.fontbackcolor = vec.fontbackcolor

                Dim mBox As TextBox = New TextBox()
                Dim myFont = New Font(vec.fontfamily, vec.fontsize, _
                            System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
                mBox.Name = VectorIDCtr.ToString
                mBox.Font = myFont
                mBox.Text = vec.text
                mBox.ForeColor = Color.FromArgb(myVector.fontforecolor)
                Dim Width As Single = Math.Abs(vec.OrgStartPointX - vec.OrgEndPointX)
                Dim Height As Single = Math.Abs(vec.OrgStartPointY - vec.OrgEndPointY)
                mBox.Size = New Size(Width, Height)
                mBox.Location = New Point(myVector.StartPointX, myVector.StartPointY)
                mBox.Multiline = True

                PictureBox1.Controls.Add(mBox) 'add the textbox
                'mBox.BringToFront()
                myVector.tBox = mBox

                Dim bm = New Bitmap(mBox.Bounds.Size.Width + mBox.Margin.Horizontal, mBox.Bounds.Size.Height + mBox.Margin.Vertical)
                Dim picCanvas As Graphics = Graphics.FromImage(bm)
                'picCanvas.FillRectangle(Brushes.White, 0, 0, mBox.Bounds.Size.Width, mBox.Bounds.Size.Height)
                'picCanvas.FillRectangle(Brushes.White, 0, 0, bm.Width, bm.Height)
                Dim myBrush As Brush = New SolidBrush(mBox.ForeColor)
                picCanvas.DrawString(mBox.Text, mBox.Font, myBrush, New Rectangle(New Point(0, 0), mBox.Size))


                Dim m As New MemoryStream
                bm.Save(m, ImageFormat.Png)
                If Not myVector.VectorImage Is Nothing Then
                    myVector.VectorImage.Dispose()
                End If


                'keep original image
                myVector.VectorImage = System.Drawing.Image.FromStream(m)
                Dim pBox As PictureBox = New PictureBox()
                myVector.pBox = pBox
                myVector.pBox.Image = myVector.VectorImage.Clone
                myVector.pBox.Visible = False
                myVector.tBox.Visible = False
                myVector.VectorType = EditDaqumentUtil.mode.EmbedText
                myVector.itmSelected = False

            End If

         

            Vectors.Add(New EditDaqumentUtil.VectorMap(myVector))
        Next
    End Sub
    Private Sub RemoveLayerVectorImages(ByVal vec As EditDaqumentUtil.VectorMap)
        If Not vec.pBox Is Nothing Then
            vec.pBox.Image.Dispose()
            vec.pBox.Dispose()
        End If
        If Not vec.pBox Is Nothing Then
            vec.pBox.Image.Dispose()
            vec.pBox.Dispose()
        End If
        If Not vec.vectorImage Is Nothing Then
            vec.vectorImage.Dispose()
        End If
    End Sub

    Private Sub SelectLayerVectors()
        Dim Ask As Boolean = True
        Dim doSave As Boolean = False
        Dim LayerID As Integer = 0

        'Me.cbx_ActivateLayer.Items.Clear()
        'For Each tls As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
        '    If tls.Checked Then
        '        cbx_ActivateLayer.Items.Add(tls.Text)
        '        cbx_ActivateLayer.SelectedItem = tls.Text
        '    End If
        'Next

        Me.btn_ActiveLayer.DropDownItems.Clear()
        For Each tls As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            If tls.Checked Then
                Dim newts As ToolStripMenuItem = New ToolStripMenuItem
                newts.Name = tls.Name
                newts.Text = tls.Text
                newts.CheckOnClick = True
                Me.btn_ActiveLayer.DropDownItems.Add(newts)
            End If
        Next

        For Each tls As ToolStripMenuItem In Me.btn_ActiveLayer.DropDownItems
            If tls.Name = CurrentLayer Then
                tls.Checked = True
            Else
                'tls.Checked = False
            End If
        Next

        SelectCurrentLayer()

        Redraw()
    End Sub


    Private Sub SaveDrawing()
        Me.Cursor = Cursors.WaitCursor
        Me.Enabled = False

        Dim modified As Boolean = False
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorModified Or vec.ObjectDeleted Then
                modified = True
            End If
        Next
        'If Not modified Then
        '    MessageBox.Show("Nothing has changed; Documents are not being saved")

        '    Me.Cursor = Cursors.Default
        '    Me.Enabled = True

        '    Return
        'End If
        For i As Integer = 0 To LayerInfoTbl.Rows.Count - 1
            SaveObjects(LayerInfoTbl.Rows(i)(0))
        Next

        'Utilities.SyncProjectDB(runtime.selectedProject)
        'SaveObjects(CurrentLayer)

        Me.Cursor = Cursors.Default
        Me.Enabled = True

    End Sub
    Private Function requestToSaveLayer() As Windows.Forms.DialogResult
        Dim Ask As Boolean = True
        Dim doSave As Boolean = False
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorModified Then
                If Ask Then
                    Ask = False
                    Return (MessageBox.Show("Drawing has been modifed, would you like to save your changes?", "Save Drawing", MessageBoxButtons.YesNoCancel))
                End If
            End If
        Next
        Return (Windows.Forms.DialogResult.No)
    End Function


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveDrawing()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveDrawing()
    End Sub




    Private Sub btnCreateNewLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNewLayer.Click
        Dim myForm As DaqumentAddNewLayer = New DaqumentAddNewLayer(myDoc, PkgNum)
        myForm.ShowDialog()
        AddLayerTitles()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        daqMode = EditDaqumentUtil.mode.None
        PictureBox1.Cursor = Cursors.Default
        ClearAllSelectedItems()
        Me.PictureBox1.Invalidate()
        Me.Refresh()
        Me.Focus()

    End Sub

    Private Sub btnLineDraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLineDraw.Click
        btnLineDraw.Select()

        If Not LayerSelected() Then
            Return
        End If
        'daqumentRefresh()
        daqMode = EditDaqumentUtil.mode.lineDraw
        PictureBox1.Cursor = Cursors.Cross

        If LayerMode = "Hilite" Then
            CreateOverlay()
        End If
    End Sub
    Private Sub btnFreehand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFreehand.Click
        btnFreehand.Select()

        If Not LayerSelected() Then
            Return
        End If
        '    daqumentRefresh()
        daqMode = EditDaqumentUtil.mode.FreeHand
        PictureBox1.Cursor = Cursors.Cross

        If LayerMode = "Hilite" Then
            CreateOverlay()
        End If
    End Sub

    Private Sub btnInsertImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertImage.Click
        If Not LayerSelected() Then
            Return
        End If

        '        daqumentRefresh()
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = runtime.AbsolutePath + "symbols\"
        openFileDialog1.Filter = "(*.png)|*.png|(*.jpg)|*.jpg|(*.bmp)|*.bmp"
        'openFileDialog1.Filter = "Image files (*.bmp)|*.bmp|(*.png)|*.png|(*.jpg)|*.jpg|(*.*)|*.*"
        openFileDialog1.FilterIndex = 1

        If openFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.OK Then Return
        If Not PicBox2.Image Is Nothing Then
            PicBox2.Image.Dispose()
        End If
        'Dim myImg As Image = System.Drawing.Image.FromFile(openFileDialog1.FileName).Clone

        'Dim bmp_Image As Bitmap
        'bmp_Image = myImg
        'bmp_Image.MakeTransparent(bmp_Image.GetPixel(2, 2))

        'PicBox2.Image = bmp_Image 'System.Drawing.Image.FromFile(openFileDialog1.FileName).Clone
        Try
            PicBox2.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName).Clone
            If PicBox2.Image.Size.Height = 0 Or PicBox2.Image.Size.Width = 0 Then
                MessageBox.Show("Invalid image size")
                Return
            End If
            If PicBox2.Image.Size.Height >= PictureBox1.Image.Size.Height Or _
                PicBox2.Image.Size.Width >= PictureBox1.Image.Size.Width Then
                MessageBox.Show("Image size is larger then the current frame setting")
                Return
            End If
            PictureBox1.Cursor = Cursors.Cross
            picBoxDragHandle.Image = Global.Daqument.My.Resources.Resources.Image
            picBoxDragHandle.Visible = False
            PicBox2.Size = PicBox2.Image.Size
            PicBox2.Visible = False
            daqMode = EditDaqumentUtil.mode.InsertImage
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return
        End Try
    End Sub


    Private Sub btnInsertText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertText.Click
        If Not LayerSelected() Then
            Return
        End If
        'daqumentRefresh()
        daqMode = EditDaqumentUtil.mode.InsertText
        PictureBox1.Cursor = Cursors.Cross
        picBoxDragHandle.Image = Global.Daqument.My.Resources.Resources.Text_Document
        picBoxDragHandle.Visible = False

    End Sub
    Private Sub ClearLineChecks()
        btn_Width1.Checked = False
        btn_Width2.Checked = False
        btn_Width3.Checked = False
        btnWidth4.Checked = False
        btnWidth5.Checked = False
    End Sub
    Private Sub btnWidth1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Width1.Click
        ClearLineChecks()
        btn_Width1.Checked = True
        btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width1
        If LayerMode = "Marking" Then CurrentLineWidth = 1
        If LayerMode = "Hilite" Then CurrentLineWidth = 3
    End Sub

    Private Sub btnWidth2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Width2.Click
        ClearLineChecks()
        btn_Width2.Checked = True
        btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width2
        If LayerMode = "Marking" Then CurrentLineWidth = 2
        If LayerMode = "Hilite" Then CurrentLineWidth = 6
    End Sub

    Private Sub btnWidth3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Width3.Click
        ClearLineChecks()
        btn_Width3.Checked = True
        btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width3
        If LayerMode = "Marking" Then CurrentLineWidth = 3
        If LayerMode = "Hilite" Then CurrentLineWidth = 9
    End Sub

    Private Sub btnWidth4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth4.Click
        ClearLineChecks()
        btnWidth4.Checked = True
        btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width4
        If LayerMode = "Marking" Then CurrentLineWidth = 4
        If LayerMode = "Hilite" Then CurrentLineWidth = 12
    End Sub

    Private Sub btnWidth5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWidth5.Click
        ClearLineChecks()
        btnWidth5.Checked = True
        btnLineWidth.Image = Global.Daqument.My.Resources.Resources.Width5
        If LayerMode = "Marking" Then CurrentLineWidth = 5
        If LayerMode = "Hilite" Then CurrentLineWidth = 15
    End Sub

    Private Sub btn_Color1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HLColor1.Click
        btnColorChoice.BackColor = btn_HLColor1.BackColor
        CurrentColor = btn_HLColor1.BackColor
    End Sub

    Private Sub btn_Color2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HLColor2.Click
        btnColorChoice.BackColor = btn_HLColor2.BackColor
        CurrentColor = btn_HLColor2.BackColor
    End Sub

    Private Sub btn_Color3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HLColor3.Click
        btnColorChoice.BackColor = btn_HLColor3.BackColor
        CurrentColor = btn_HLColor3.BackColor
    End Sub

    Private Sub btn_HLColor4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HLColor4.Click
        Dim tmp As ToolStripMenuItem = sender
        btnColorChoice.BackColor = tmp.BackColor
        CurrentColor = tmp.BackColor
    End Sub

    Private Sub btn_HLColor5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HLColor5.Click
        Dim tmp As ToolStripMenuItem = sender
        btnColorChoice.BackColor = tmp.BackColor
        CurrentColor = tmp.BackColor
    End Sub

    Private Sub btn_HLColor6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HLColor6.Click
        Dim tmp As ToolStripMenuItem = sender
        btnColorChoice.BackColor = tmp.BackColor
        CurrentColor = tmp.BackColor
    End Sub

    Private Sub btn_HLColor7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HLColor7.Click
        Dim tmp As ToolStripMenuItem = sender
        btnColorChoice.BackColor = tmp.BackColor
        CurrentColor = tmp.BackColor
    End Sub

    Private Sub btn_HLColor8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HLColor8.Click
        Dim tmp As ToolStripMenuItem = sender
        btnColorChoice.BackColor = tmp.BackColor
        CurrentColor = tmp.BackColor
    End Sub

    Private Sub btn_HLColor9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HLColor9.Click
        Dim tmp As ToolStripMenuItem = sender
        btnColorChoice.BackColor = tmp.BackColor
        CurrentColor = tmp.BackColor
    End Sub

    Private Sub btn_HLColor10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_HLColor10.Click
        Dim tmp As ToolStripMenuItem = sender
        btnColorChoice.BackColor = tmp.BackColor
        CurrentColor = tmp.BackColor
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_MUColor1.Click
        btn_MarkupColors.BackColor = btn_MUColor1.BackColor
        CurrentColor = btn_MUColor1.BackColor
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_MUColor2.Click
        btn_MarkupColors.BackColor = btn_MUColor2.BackColor
        CurrentColor = btn_MUColor2.BackColor
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_MUColor3.Click
        btn_MarkupColors.BackColor = btn_MUColor3.BackColor
        CurrentColor = btn_MUColor3.BackColor
    End Sub


    Private Sub btnEnlarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnlarge.Click
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
                If vec.itmSelected Then
                    Dim myFontSize As Single = vec.tBox.Font.Size
                    If vec.tBox.Font.Size < 72 Then
                        Dim myFont = New Font(vec.tBox.Font.FontFamily, vec.tBox.Font.Size + 1, _
                                    System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
                        vec.tBox.Font = myFont
                    End If
                End If
            End If
        Next
        Redraw()
    End Sub


    Private Sub btnReduce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReduce.Click
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
                If vec.itmSelected Then
                    Dim myFontSize As Single = vec.tBox.Font.Size
                    If vec.tBox.Font.Size > 4 Then
                        Dim myFont = New Font(vec.tBox.Font.FontFamily, vec.tBox.Font.Size - 1, _
                                    System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
                        vec.tBox.Font = myFont
                    End If
                End If
            End If
        Next
        Redraw()
    End Sub

    Private Sub btnDrag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrag.Click
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            ' ClearSelectedBoundryBox(vec)
        Next

        PreviousAnchorPoint = PictureBox1.Location
        daqMode = EditDaqumentUtil.mode.Drag
        '        embedAllObjects()
        PictureBox1.Cursor = Cursors.NoMove2D
    End Sub

    Private Sub btn500_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn500.Click
        If ResizeDrawingView(5, 5) Then
            Me.btnMaginfy.Text = String.Format("500%")
            Me.WriteDefaultZoom("500")
        End If
    End Sub

    Private Sub btn200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn200.Click
        If ResizeDrawingView(2, 2) Then
            Me.btnMaginfy.Text = String.Format("200%")
            Me.WriteDefaultZoom("200")
        End If
    End Sub

    Private Sub btn150_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn150.Click
        If ResizeDrawingView(1.5, 1.5) Then
            Me.btnMaginfy.Text = String.Format("150%")
            Me.WriteDefaultZoom("150")
        End If
    End Sub

    Private Sub btn100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn100.Click
        If ResizeDrawingView(1, 1) Then
            Me.btnMaginfy.Text = String.Format("100%")
            Me.WriteDefaultZoom("100")
        End If
    End Sub

    Private Sub btn75_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn75.Click
        If ResizeDrawingView(0.75, 0.75) Then
            Me.btnMaginfy.Text = String.Format("75%")
            Me.WriteDefaultZoom("75")
        End If
    End Sub

    Private Sub btn50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn50.Click
        If ResizeDrawingView(0.5, 0.5) Then
            Me.btnMaginfy.Text = String.Format("50%")
            Me.WriteDefaultZoom("50")
        End If
    End Sub

    Private Sub btn25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn25.Click
        If ResizeDrawingView(0.25, 0.25) Then
            Me.btnMaginfy.Text = String.Format("25%")
            Me.WriteDefaultZoom("25")
        End If
    End Sub
    Private Sub btnPageWidth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageWidth.Click
        ResizePageWidth()
    End Sub

    Private Sub btnShowLayerInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowLayerInfo.Click
        'Dim myForm As Form = New EditDaqumentLayerInfo(myDoc, LayerInfoTbl)
        'myForm.Show()

        'Dim infoTbl As DataTable = myDoc.LayerInfoTbl
        'ShowInfoTable(infoTbl, "Document Layer Info")
        'If GridControl1.Visible Then
        '    GridControl1.Visible = False
        'Else
        '    GridControl1.Visible = True
        'End If

    End Sub

    Private Sub ToggleDrawButtons()
        If CurrentLayer = "" Then
            btnInsertText.Enabled = False
            btnInsertImage.Enabled = False
            btnFreehand.Enabled = False
            btnLineDraw.Enabled = False
        Else
            btnInsertText.Enabled = True
            btnInsertImage.Enabled = True
            btnFreehand.Enabled = True
            btnLineDraw.Enabled = True
        End If

    End Sub


    Private Sub SelectCurrentLayer()
        lbl_CurrentLayer.Text = "Current Layer: None"

        'If cbx_ActivateLayer.SelectedIndex < 0 Then
        '    CurrentLayer = 0
        '    Return
        'End If

        'For i As Integer = 0 To LayerInfoTbl.Rows.Count - 1
        '    If LayerInfoTbl.Rows(i)(0) = cbx_ActivateLayer.Name Then
        '        CurrentLayer = (LayerInfoTbl.Rows(i)(0))
        '    End If
        'Next
        'lbl_CurrentLayer.Text = "Current Layer: " + cbx_ActivateLayer.Text


        Dim ActiveLayer As String = ""
        Dim ActiveLayerText As String = "none"

        For Each dditem As ToolStripMenuItem In Me.btn_ActiveLayer.DropDownItems
            If dditem.Checked Then
                ActiveLayer = dditem.Name
                ActiveLayerText = dditem.Text
            End If
        Next

        For i As Integer = 0 To LayerInfoTbl.Rows.Count - 1
            If LayerInfoTbl.Rows(i)(0) = ActiveLayer Then
                CurrentLayer = (LayerInfoTbl.Rows(i)(0))
            End If
        Next

        lbl_CurrentLayer.Text = "Current Layer: " + ActiveLayerText

        btnCancel.Select()
        btnSave.Enabled = True
        ToggleDrawButtons()
    End Sub


    Private Sub cbx_ActivateLayer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_ActivateLayer.SelectedIndexChanged
        'SelectLayerVectors()
        SelectCurrentLayer()
        Redraw()

    End Sub


    Private Sub btn_ActiveLayer_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles btn_ActiveLayer.DropDownItemClicked

        Dim ts As ToolStripDropDownButton = sender


        For Each dditem As ToolStripMenuItem In Me.btn_ActiveLayer.DropDownItems
            If dditem.Name = e.ClickedItem.Name Then
                dditem.Checked = True
            Else
                'dditem.Checked = False
            End If

        Next

        SelectCurrentLayer()
        Redraw()

        For Each dditem As ToolStripMenuItem In Me.btn_ActiveLayer.DropDownItems
            If dditem.Name = CurrentLayer Then
                dditem.Checked = True
            End If
        Next

    End Sub


    Private Sub btnLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ts As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        For i As Integer = 0 To LayerInfoTbl.Rows.Count - 1
            If LayerInfoTbl.Rows(i)(0) = ts.Name Then
                If ts.Checked Then
                    ts.Checked = False
                    'cbx_ActivateLayer.Items.Remove(ts.Text)


                    For Each dditem As ToolStripMenuItem In Me.btn_ActiveLayer.DropDownItems
                        If dditem.Name = ts.Name Then
                            Me.btn_ActiveLayer.DropDownItems.Remove(dditem)
                            Exit For
                        End If
                    Next


                    'If cbx_ActivateLayer.Items.Count > 0 Then
                    '    cbx_ActivateLayer.SelectedIndex = 0
                    'Else
                    '    cbx_ActivateLayer.SelectedIndex = -1
                    '    CurrentLayer = 0
                    'End If

                    Dim LayerSelected As Boolean = False
                    For Each dditem As ToolStripMenuItem In Me.btn_ActiveLayer.DropDownItems
                        If dditem.Checked Then
                            LayerSelected = True
                        End If
                    Next
                    If Not LayerSelected Then
                        CurrentLayer = 0
                    End If
                Else
                    ts.Checked = True
                    Dim newts As ToolStripMenuItem = New ToolStripMenuItem
                    newts.Name = ts.Name
                    newts.Text = ts.Text
                    newts.CheckOnClick = True
                    newts.Checked = True

                    Me.btn_ActiveLayer.DropDownItems.Add(newts)

                    For Each dditem As ToolStripMenuItem In Me.btn_ActiveLayer.DropDownItems

                        If dditem.Name = LayerInfoTbl.Rows(i)(0) Then
                            dditem.Checked = True
                        End If

                    Next

                    'cbx_ActivateLayer.Items.Add(newts)
                    'cbx_ActivateLayer.SelectedIndex = cbx_ActivateLayer.Items.Count - 1
                    'cbx_ActivateLayer.SelectedText = ts.Text
                    'cbx_ActivateLayer.SelectedItem = ts.Name
                    'cbx_ActivateLayer.Text = ts.Text
                    Me.Refresh()

                End If
            End If
        Next

        ToggleDrawButtons()

        SelectLayerVectors()

        Redraw()
        Dim g As Graphics = Graphics.FromImage(PictureBox1ImageCopy)
        g.DrawImage(PageOverlayBM, 0, 0)

    End Sub


    Private Sub EditDaqument_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim rslt = Me.requestToSaveLayer()
        If rslt = Windows.Forms.DialogResult.Cancel Then
            e.Cancel = True
            Return
        End If
        If rslt = Windows.Forms.DialogResult.Yes Then
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            For i As Integer = 0 To LayerInfoTbl.Rows.Count - 1
                SaveObjects(LayerInfoTbl.Rows(i)(0))
                Utilities.SyncProjectDB(runtime.selectedProject)
            Next
            Windows.Forms.Cursor.Current = Cursors.Default
        End If

    End Sub
    Private Sub btnRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedo.Click
        Dim CurrentSeqNumber = 0
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.ObjectDeleted Then
                CurrentSeqNumber = vec.seqNumber
            End If
        Next
        If CurrentSeqNumber = 0 Then Return

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.seqNumber = CurrentSeqNumber Then
                vec.ObjectDeleted = False
            End If
        Next
        Redraw()

    End Sub

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        Dim CurrentSeqNumber = 0
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If Not vec.ObjectDeleted Then
                CurrentSeqNumber = vec.seqNumber
            End If
        Next
        If CurrentSeqNumber = 0 Then Return

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.seqNumber = CurrentSeqNumber Then
                vec.ObjectDeleted = True
            End If
        Next
        Redraw()
    End Sub

    Private Sub EditDaqument_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Loaded Then
            CreateOverlay()
        End If
    End Sub

    Private Sub btn_DrawingMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DrawingMode.Click

        If btn_DrawingMode.Text = "Hilite" Then
            btnColorChoice.Visible = False
            btn_MarkupColors.Visible = True
            CurrentColor = Color.Red
            btn_MarkupColors.BackColor = Color.Red
            CurrentLineWidth = 9
            LayerMode = "Marking"
            btn_DrawingMode.Text = "Markup"
            CreateOverlay()
        ElseIf btn_DrawingMode.Text = "Markup" Then
            btnColorChoice.Visible = True
            btn_MarkupColors.Visible = False
            CurrentColor = Color.Yellow
            btnColorChoice.BackColor = Color.Yellow
            CurrentLineWidth = 3
            LayerMode = "Hilite"
            btn_DrawingMode.Text = "Hilite"
            CreateOverlay()
        End If
    End Sub

    'Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem.Click
    '    For Each tls As ToolStripMenuItem In btnViewLayers.DropDownItems
    '        tls.Checked = True
    '    Next
    '    SelectLayerVectors()
    '    Redraw()
    '    Dim g As Graphics = Graphics.FromImage(PictureBox1ImageCopy)
    '    g.DrawImage(PageOverlayBM, 0, 0)
    'End Sub




    Private Sub MakePrintImages()
        'If ResizeDrawingView(1, 1) Then
        '    Me.btnMaginfy.Text = String.Format("100%")
        'End If
        'Dim img As Image = PictureBox1.Image.Clone

        'Dim bm As New Bitmap(img.Width, img.Height)
        'Dim g As Graphics = Graphics.FromImage(bm)

        'g.FillRectangle(Brushes.White, 0, 0, img.Width, img.Height)
        'g.DrawImage(img, 0, 0)

        'img.Save("c:\test.png", System.Drawing.Imaging.ImageFormat.Png)

        Dim img As Image = myDoc.OriginalDocumentImage
        Dim bm As New Bitmap(img.Width, img.Height)
        Dim g As Graphics = Graphics.FromImage(bm)

        g.FillRectangle(Brushes.White, 0, 0, img.Width, img.Height)
        g.DrawImage(img, 0, 0, img.Width, img.Height)

        Dim layerCtr As Integer = 0
        Dim LayerID As String

        'draw hilites
        For Each ts As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            If ts.Checked Then
                LayerID = LayerInfoTbl.Rows(layerCtr)(0)
                For Each vec As EditDaqumentUtil.VectorMap In Vectors
                    Me.RescaleVector(vec, 1, 1)
                    If Not vec.ObjectDeleted And vec.ObjectMode = "Hilite" And vec.layerID = LayerID Then
                        If Not vec.ObjectDeleted And LayerIsVisible(vec.layerID) Then
                            If vec.VectorObjectType = "Text" Then
                                Dim myFont = New Font(vec.fontFamily, vec.tBox.Font.Size * (1 / vec.OrgScaleX), _
                                         vec.tBox.Font.Style, GraphicsUnit.Point)
                                Dim myBrush As Brush = New SolidBrush(vec.tBox.ForeColor)
                                Dim boxWidth As Integer = vec.tBox.Size.Width * (1 / vec.OrgScaleX)
                                Dim boxHeight As Integer = vec.tBox.Size.Height * (1 / vec.OrgScaleY)
                                Dim boxSize As Size = New Size(boxWidth, boxHeight)
                                g.DrawString(vec.text, myFont, myBrush, New Rectangle(New Point(vec.StartPointX, vec.StartPointY), boxSize))
                            ElseIf vec.VectorObjectType = "Line" Then
                                Dim clr As Color = Color.FromArgb(vec.penArgb)
                                Dim clr2 As Color = Color.LightGray

                                Dim myPen As Pen = New Pen(New SolidBrush(clr), vec.ScaledlineWidth)
                                If Me.GrayscaleInactiveLayer.Checked Then
                                    If Not vec.layerID = CurrentLayer Then
                                        myPen = New Pen(New SolidBrush(clr2), vec.ScaledlineWidth)
                                    End If
                                End If

                                myPen.EndCap = vec.lineEnd
                                Dim startPoint As Point = New Point(vec.StartPointX, vec.StartPointY)
                                Dim endPoint As Point = New Point(vec.endPointX, vec.endPointY)
                                g.DrawLine(myPen, startPoint, endPoint)
                            ElseIf vec.VectorObjectType = "Weld" Then
                                'DrawWeld(vec)
                            End If
                        End If
                    End If
                Next
            End If
            layerCtr = layerCtr + 1
        Next


        'draw overlay
        g.DrawImage(PageOverlayBM, 0, 0, img.Width, img.Height)

        'draw markups
        layerCtr = 0
        For Each ts As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            If ts.Checked Then
                LayerID = LayerInfoTbl.Rows(layerCtr)(0)
                For Each vec As EditDaqumentUtil.VectorMap In Vectors
                    Me.RescaleVector(vec, 1, 1)
                    If Not vec.ObjectDeleted And LayerIsVisible(vec.layerID) And vec.ObjectMode = "Marking" Then

                        If vec.VectorObjectType = "Text" Then
                            Dim myFont = New Font(vec.fontFamily, vec.tBox.Font.Size * (1 / vec.OrgScaleX), _
                                     vec.tBox.Font.Style, GraphicsUnit.Point)
                            Dim myBrush As Brush = New SolidBrush(vec.tBox.ForeColor)
                            g.DrawString(vec.text, myFont, myBrush, New Rectangle(New Point(vec.StartPointX, vec.StartPointY), vec.tBox.Size))
                        ElseIf vec.VectorObjectType = "Pic" Then
                            Dim imgPic As Image = myDoc.ResizeImage(vec.pBox.Image, vec.pBox.Size)
                            g.DrawImage(imgPic, New Point(vec.StartPointX, vec.StartPointY))
                        ElseIf vec.VectorObjectType = "Line" Then
                            Dim clr As Color = Color.FromArgb(vec.penArgb)
                            Dim clr2 As Color = Color.LightGray

                            Dim myPen As Pen = New Pen(New SolidBrush(clr), vec.ScaledlineWidth)
                            If Me.GrayscaleInactiveLayer.Checked Then
                                If Not vec.layerID = CurrentLayer Then
                                    myPen = New Pen(New SolidBrush(clr2), vec.ScaledlineWidth)
                                End If
                            End If

                            myPen.EndCap = vec.lineEnd
                            Dim startPoint As Point = New Point(vec.StartPointX, vec.StartPointY)
                            Dim endPoint As Point = New Point(vec.endPointX, vec.endPointY)
                            g.DrawLine(myPen, startPoint, endPoint)
                        End If
                    End If
                Next
            End If
            layerCtr = layerCtr + 1
        Next


        For Each mg As Image In _PrintImages
            mg.Dispose()
        Next
        _PrintImages.Clear()
        _PrintImages.Add(bm)
    End Sub



    Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        'Dim img As Image = _PrintImages(intPageCounter)
        'e.Graphics.FillRectangle(Brushes.White, 0, 0, img.Height, img.Width)
        'e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height)
        'e.HasMorePages = False
        'intPageCounter = 0

        Dim PprSize As PaperSize = printDoc.DefaultPageSettings.PaperSize()
        Dim pprWidth As Integer = PprSize.Width
        Dim pprHeight As Integer = PprSize.Height
        If printDoc.DefaultPageSettings.Landscape Then
            pprWidth = PprSize.Height - 20
            pprHeight = PprSize.Width - 20
        Else
            pprWidth = PprSize.Width - 20
            pprHeight = PprSize.Height - 20
        End If

        Dim img As Image = _PrintImages(intPageCounter)
        e.Graphics.FillRectangle(Brushes.White, 0, 0, pprWidth, pprHeight)
        e.Graphics.DrawImage(img, 0, 0, pprWidth, pprHeight)
        e.HasMorePages = False
        intPageCounter = 0


    End Sub



    Private Function GetFileName()
        With sfd1
            'The Caption
            .Title = "Save Document Image as PNG..."

            'Ensure we only get back valid filenames
            .CheckFileExists() = False
            .CheckPathExists = True
            .ValidateNames = True
            .DereferenceLinks = True
            .DefaultExt = "png"
            'Set the starting dir
            .InitialDirectory = "c:\"
            .AddExtension = True
            .FileName = myDoc.DocumentName() + ".png"
            .Filter = "PNG Files|*.png"


            'Show the Window
            If .ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
                Return ""
            End If
            If .FileName > "" Then
                Return .FileName
            End If
        End With
        Return ""
    End Function



    Private Sub ShowPkgLayers()
        For Each ts As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            If ts.Text = "RL-" + PkgNum Then
                ts.Checked = True
            End If
            If ts.Text = "HL-" + PkgNum Then
                ts.Checked = True
            End If
        Next

        Me.btn_ActiveLayer.DropDownItems.Clear()
        For Each ts As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            If ts.Checked Then
                Dim newts As ToolStripMenuItem = New ToolStripMenuItem
                newts.Name = ts.Name
                newts.Text = ts.Text
                newts.CheckOnClick = True
                Me.btn_ActiveLayer.DropDownItems.Add(newts)
            End If
        Next

    End Sub



    Private Sub WriteDefaultZoom(ByVal _Zoom As String)
        'write to registry
        Dim MyKey As RegistryKey
        Dim regKey As String

        'MyKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\ISSI\Daqart\Settings", True)
        'MyKey.CreateSubKey("DaqumentZoom")
        'MyKey.Close()

        regKey = "HKEY_LOCAL_MACHINE\Software\ISSI\Daqart\Settings\"
        Registry.SetValue(regKey, "DaqumentZoom", _Zoom, RegistryValueKind.String)

    End Sub



    Private Sub cms1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms1.Opening
        If daqMode <> EditDaqumentUtil.mode.None Then Return
        cms1Loc = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
        Dim ScreenPoint As Point = New Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
        Dim ClientPoint As Point = Me.PictureBox1.PointToClient(ScreenPoint)

        ' Acquire references to the owning control and item.
        Dim c As System.Windows.Forms.Control = cms1.SourceControl
        Dim tsi As ToolStripDropDownItem = cms1.OwnerItem
        If (c IsNot Nothing) Then
            If c.Name <> "PictureBox1" Then Return
        End If

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorObjectType = "Weld" And vec.layerID = CurrentLayer And vec.ObjectDeleted = False Then
                If IsWeldPointTailSelected(ClientPoint, vec.thisVector) Then
                    vec.itmSelected = True
                    selectedWeldTableIndex = 0
                    selectedWeldTagNo = ""
                    For i As Integer = 0 To myDoc.WeldPointInfoTable.Rows.Count - 1
                        If myDoc.WeldPointInfoTable.Rows(i)("TagNo") = vec.text Then
                            selectedWeldTableIndex = i
                            selectedWeldTagNo = vec.text
                            Exit For
                        End If
                    Next
                    cms1.Items.Clear()
                    cms1.Items.Add("-")
                    cms1.Items.Add("Property")
                    cms1.Items.Add("Change Weld Status")
                    cms1.Items.Add("Delete")
                    Return
                End If
            End If
        Next

        If theRectangle.Size.Width = 0 Or theRectangle.Size.Height = 0 Then
            'If Not cmsPictureBox.Image Is Nothing Then
            '    cms1.Items.Clear()
            '    cms1.Items.Add("-")
            '    cms1.Items.Add("Paste")
            'End If
            Return
        Else
            ' Populate the ContextMenuStrip control with its default items.
            'If (theRectangle.Size.Width = 0 Or theRectangle.Size.Height = 0) Then Return
            cms1.Items.Clear()
            cms1.Items.Add("-")
            cms1.Items.Add("Delete")
            'cms1.Items.Add("Cut")
            'cms1.Items.Add("Copy")
            'If Not cmsPictureBox.Image Is Nothing Then
            '    cms1.Items.Add("Paste")
            'End If
        End If
        e.Cancel = False
    End Sub

    Private Sub cms1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cms1.ItemClicked
        Dim ScreenPoint As Point = cms1.Bounds.Location
        Dim ClientPoint As Point = PointToClient(cms1.Bounds.Location)
        Dim ClientPointF As PointF = CType(ClientPoint, PointF)
        Dim tsi As ToolStripDropDownItem = e.ClickedItem
        If Not LayerSelected() Then
            Return
        End If

        ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
        If tsi.Text = "Cut" Then
            Dim bm = New Bitmap(theRectangle.Size.Width, theRectangle.Size.Height)
            Dim picCanvas As Graphics = Graphics.FromImage(bm)
            picCanvas.CopyFromScreen(theRectangle.Location, New Point(0, 0), theRectangle.Size)
            If Not cmsPictureBox.Image Is Nothing Then
                cmsPictureBox.Image.Dispose()
            End If
            cmsPictureBox.Image = bm
            cmsPictureBox.Size = theRectangle.Size


            Dim bm1 = New Bitmap(theRectangle.Size.Width, theRectangle.Size.Height)
            Dim cutCanvas As Graphics = Graphics.FromImage(bm1)
            cutCanvas.FillRectangle(Brushes.White, 0, 0, theRectangle.Size.Width, theRectangle.Size.Height)
            If Not PicBox2.Image Is Nothing Then
                PicBox2.Image.Dispose()
            End If
            PicBox2.Image = bm1
            PicBox2.Size = theRectangle.Size
            daqMode = EditDaqumentUtil.mode.InsertImage
            Dim vect As EditDaqumentUtil.Vector = MakeNewPictureImageVector(PictureBox1.PointToClient(theRectangle.Location))
            embedLayerObject(vect)
            vect.pBox.Visible = False
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                ClearSelectedBoundryBox(vec)
                vec.itmSelected = False
            Next
            daqMode = EditDaqumentUtil.mode.None
            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, FrameStyle.Dashed)
        ElseIf tsi.Text = "Copy" Then
            '            Dim myRect As Rectangle = theRectangle

            Dim bm = New Bitmap(theRectangle.Size.Width, theRectangle.Size.Height)
            Dim picCanvas As Graphics = Graphics.FromImage(bm)
            picCanvas.CopyFromScreen(theRectangle.Location, New Point(0, 0), theRectangle.Size)
            If Not cmsPictureBox.Image Is Nothing Then
                cmsPictureBox.Image.Dispose()
            End If
            cmsPictureBox.Image = bm
            cmsPictureBox.Size = theRectangle.Size

            If Not PicBox2.Image Is Nothing Then
                PicBox2.Image.Dispose()
            End If
            PicBox2.Image = bm
            PicBox2.Size = theRectangle.Size


        ElseIf tsi.Text = "Paste" Then
            If Not PicBox2.Image Is Nothing Then
                PicBox2.Image.Dispose()
            End If
            PicBox2.Size = theRectangle.Size
            PicBox2.Image = cmsPictureBox.Image.Clone
            daqMode = EditDaqumentUtil.mode.InsertImage
            MakeNewPictureImageVector(ClientPoint)
            daqMode = EditDaqumentUtil.mode.ObjectSelected
        ElseIf tsi.Text = "Delete" Then
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.itmSelected And vec.VectorObjectType = "Weld" Then
                    vec.ObjectDeleted = True
                    vec.VectorModified = True
                    Exit For
                End If
            Next
            Redraw()
        ElseIf tsi.Text = "Property" Then
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.itmSelected And vec.VectorObjectType = "Weld" Then
                    For i As Integer = 0 To myDoc.WeldPointInfoTable.Rows.Count - 1
                        If myDoc.WeldPointInfoTable.Rows(i)("TagNo") = vec.text Then
                            Dim myForm As New EditDaqumentInfo(myDoc, "Weld Properties", i)
                            myForm.Show()
                            Exit For
                        End If
                    Next
                End If
            Next
            'DisplayWeldPointPropertyGrid()
        ElseIf tsi.Text = "Change Weld Status" Then

        End If
        PictureBox1.Refresh()

    End Sub


    Private Sub EditDaqument_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If daqMode = EditDaqumentUtil.mode.ObjectSelected Then
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.itmSelected Then
                    Dim objMoved As Boolean = False
                    Dim X = vectorScreenBoundRectangle(vec.thisVector).X : Dim Y = vectorScreenBoundRectangle(vec.thisVector).Y
                    If e.KeyCode = Keys.Escape Then
                        vec.ObjectDeleted = True
                    End If
                    If e.KeyCode = Keys.Delete Then
                        vec.ObjectDeleted = True
                    End If
                    If e.KeyCode = Keys.Left Then
                        X = X - 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Right Then
                        X = X + 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Up Then
                        Y = Y - 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Down Then
                        Y = Y + 1 : objMoved = True
                    End If
                    If objMoved Then
                        'ResizeObject(vec)
                    End If
                End If
            Next

        End If
        If e.KeyCode = Keys.Delete Then
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                For Each sCtrl As SeqControl In tmpControls
                    If sCtrl.vecID = vec.vectorID Then
                        vec.ObjectDeleted = True
                        vec.VectorModified = True
                        If Not vec.tBox Is Nothing Then
                            vec.tBox.Visible = False
                        End If
                        If Not vec.pBox Is Nothing Then
                            vec.pBox.Visible = False
                        End If
                    End If
                Next
            Next
            ClearAllSelectedItems()
            Redraw()
            PictureBox1.Refresh()
            'CreatePageOverlay(PictureBox1ImageCopy)
        End If

        If e.KeyCode = Keys.Escape Then
            ClearAllSelectedItems()
            Redraw()
            PictureBox1.Refresh()
        End If

        PictureBox1.Refresh()
    End Sub

    Private Sub HandleKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If daqMode = EditDaqumentUtil.mode.ObjectSelected Then
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                If vec.itmSelected Then
                    Dim objMoved As Boolean = False
                    Dim X = vectorScreenBoundRectangle(vec.thisVector).X : Dim Y = vectorScreenBoundRectangle(vec.thisVector).Y
                    If e.KeyCode = Keys.Escape Then
                        vec.ObjectDeleted = True
                    End If
                    If e.KeyCode = Keys.Delete Then
                        vec.ObjectDeleted = True
                    End If
                    If e.KeyCode = Keys.Left Then
                        X = X - 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Right Then
                        X = X + 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Up Then
                        Y = Y - 1 : objMoved = True
                    End If
                    If e.KeyCode = Keys.Down Then
                        Y = Y + 1 : objMoved = True
                    End If
                    If objMoved Then
                        'ResizeObject(vec)
                    End If
                End If
            Next

        End If
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            For Each vec As EditDaqumentUtil.VectorMap In Vectors
                For Each sCtrl As SeqControl In tmpControls
                    If sCtrl.vecID = vec.vectorID Then
                        vec.ObjectDeleted = True
                        If Not vec.tBox Is Nothing Then
                            vec.tBox.Visible = False
                        End If
                        If Not vec.pBox Is Nothing Then
                            vec.pBox.Visible = False
                        End If
                    End If
                Next
            Next
            ClearAllSelectedItems()
            Redraw()
            PictureBox1.Refresh()
            'CreatePageOverlay(PictureBox1ImageCopy)
        End If

        'Dim g As Graphics = Graphics.FromImage(Me.PictureBox1.Image)
        'g.DrawImage(PageOverlayBM, 0, 0)
        PictureBox1.Refresh()

    End Sub

   

    Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageSetup.Click
        PageSetupDialog1.Document = printDoc
        ' Sets the print document's color setting to false,
        ' so that the page will not be printed in color.
        'PageSetupDialog1.Document.DefaultPageSettings.Color = False
        Dim msgResult As DialogResult = Me.PageSetupDialog1.ShowDialog()
    End Sub
    Private Sub printDoc_BeginPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
        intPageCounter = 0
    End Sub

    Private Sub printDoc_EndPrint(ByVal sender As Object, ByVal ev As PrintEventArgs)
    End Sub


    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        myDoc.SaveDocumentImage()
        MakePrintImages()
        Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()

        printDialog.Document = Me.printDoc
        printDialog.ShowDialog()

        'Dim lesson As New Lesson1(printingSystem1)
        'lesson.ShowPreview()

    End Sub


    Private Sub ts_ExportToPNG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_ExportToPNG.Click
        myDoc.SaveDocumentImage()
        MakePrintImages()
        Dim fp As String = GetFileName()
        If fp > "" Then
            _PrintImages(0).Save(fp, System.Drawing.Imaging.ImageFormat.Png)
        End If
    End Sub


    Private Sub PageSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageSetupToolStripMenuItem.Click
        PageSetupDialog1.Document = printDoc
        Dim msgResult As DialogResult = Me.PageSetupDialog1.ShowDialog()
    End Sub


    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        myDoc.SaveDocumentImage()
        MakePrintImages()
        Dim printDialog As PrintPreviewDialog = New PrintPreviewDialog()

        printDialog.Document = Me.printDoc
        printDialog.ShowDialog()
    End Sub
    Private Sub ToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_TextRed.Click
        Me.btn_TextColor.ForeColor = Me.btn_TextRed.BackColor

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
                If vec.itmSelected Then
                    vec.tBox.ForeColor = Me.btn_TextRed.BackColor
                End If
            End If
        Next
    End Sub


    Private Sub btn_TextBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_TextBlue.Click
        Me.btn_TextColor.ForeColor = Me.btn_TextBlue.BackColor
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
                If vec.itmSelected Then
                    vec.tBox.ForeColor = Me.btn_TextBlue.BackColor
                End If
            End If
        Next
    End Sub


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        myDoc.SaveDocumentImage()
        MakePrintImages()
        Me.PrintDialog1.Document = Me.printDoc
        Dim msgResult As DialogResult = Me.PrintDialog1.ShowDialog()
        If msgResult = Windows.Forms.DialogResult.Cancel Then Return
    End Sub

    Private Sub cbx_FontSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
                If vec.itmSelected Then
                    Dim myFont = New Font(vec.tBox.Font.FontFamily, Convert.ToSingle(Me.cbx_FontSize.Text), _
                                    vec.tBox.Font.Style, GraphicsUnit.Point)
                    vec.tBox.Font = myFont
                End If
            End If
        Next
    End Sub


    Private Sub btn_Bold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Bold.Click
        Dim MyStyle As FontStyle = FontStyle.Regular
        If Me.btn_Bold.Checked And Me.btn_Italic.Checked Then
            MyStyle = FontStyle.Bold + FontStyle.Italic
        ElseIf Me.btn_Bold.Checked Then
            MyStyle = FontStyle.Bold
        ElseIf Me.btn_Italic.Checked Then
            MyStyle = FontStyle.Italic
        End If

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
                If vec.itmSelected Then
                    Dim myFont = New Font(vec.tBox.Font.FontFamily, vec.tBox.Font.Size, _
                                    MyStyle, GraphicsUnit.Point)
                    vec.tBox.Font = myFont
                End If
            End If
        Next
    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub tsmi_SelectLayers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_SelectLayers.Click
        Try
            Dim i As Integer = 0
            For Each thisItem As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
                i = i + 1
            Next
            If i = 0 Then
                Dim msgResult As DialogResult = MessageBox.Show("No layer has been added to the Drawing; do you wish to add a new layer?", "Add Layer", MessageBoxButtons.YesNo)
                If msgResult = Windows.Forms.DialogResult.Yes Then
                    Dim myForm As DaqumentAddNewLayer = New DaqumentAddNewLayer(myDoc, PkgNum)
                    myForm.ShowDialog()
                    AddLayerTitles()
                    Dim thisItem As ToolStripMenuItem = Me.tsmi_SelectLayers.DropDownItems(0)
                    'Private Sub TestingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestingToolStripMenuItem.Click
                    thisItem.Checked = True
                    thisItem.CheckOnClick = True
                End If
            End If
            If i > 1 Then

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_Italic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Italic.Click
        Dim MyStyle As FontStyle = FontStyle.Regular
        If Me.btn_Bold.Checked And Me.btn_Italic.Checked Then
            MyStyle = FontStyle.Bold + FontStyle.Italic
        ElseIf Me.btn_Bold.Checked Then
            MyStyle = FontStyle.Bold
        ElseIf Me.btn_Italic.Checked Then
            MyStyle = FontStyle.Italic
        End If

        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
                If vec.itmSelected Then
                    Dim myFont = New Font(vec.tBox.Font.FontFamily, vec.tBox.Font.Size, _
                                    MyStyle, GraphicsUnit.Point)
                    vec.tBox.Font = myFont
                End If
            End If
        Next
    End Sub


    Private Sub btn_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        DeleteSelectedObjects()
    End Sub

    Private Sub GrayscaleInactiveLayer_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrayscaleInactiveLayer.CheckStateChanged
        If Not Loaded Then Return

        Redraw()
    End Sub


    Private Sub tsmi_HideAllLayers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_HideAllLayers.Click
        For Each tls As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            tls.Checked = False
        Next
        SelectLayerVectors()
        Redraw()
        Dim g As Graphics = Graphics.FromImage(PictureBox1ImageCopy)
        g.DrawImage(PageOverlayBM, 0, 0)
    End Sub


    Private Sub tsmi_ViewAllLayers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_ViewAllLayers.Click
        For Each tls As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            tls.Checked = True
        Next
        SelectLayerVectors()
        Redraw()
        Dim g As Graphics = Graphics.FromImage(PictureBox1ImageCopy)
        g.DrawImage(PageOverlayBM, 0, 0)
    End Sub
    Private Sub tsmi_ViewWeldLayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each tls As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems

            tls.Checked = False
            If tls.Text = "Welds" Then
                tls.Checked = True
            End If
        Next
        SelectLayerVectors()
        Redraw()
        Dim g As Graphics = Graphics.FromImage(PictureBox1ImageCopy)
        g.DrawImage(PageOverlayBM, 0, 0)
    End Sub


    Private Sub DeleteActiveLayerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteActiveLayerToolStripMenuItem.Click
        If CurrentLayer <= "" Then
            MessageBox.Show("Please select layer")
            Return
        End If

        If (MessageBox.Show("Are you sure you want to delete the cureent selected layer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Return
        End If

        Dim ret = myDoc.DeleteDrawingLayer(CurrentLayer)
        Dim i As Integer = 0
        Me.tsmi_SelectLayers.DropDownItems.Clear()
        AddLayerTitles()
        LoadAllLayerVectors()
        For Each tls As ToolStripMenuItem In Me.tsmi_SelectLayers.DropDownItems
            tls.Checked = False
        Next
        SelectLayerVectors()
        Redraw()
        Dim g As Graphics = Graphics.FromImage(PictureBox1ImageCopy)
        g.DrawImage(PageOverlayBM, 0, 0)
    End Sub


    Private Sub ts_ExportToPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_ExportToPDF.Click
        myDoc.SaveDocumentImage()
        MakePrintImages()

        With sfd1
            'The Caption
            .Title = "Save Document Image as PDF"

            'Ensure we only get back valid filenames
            .CheckFileExists() = False
            .CheckPathExists = True
            .ValidateNames = True
            .DereferenceLinks = True
            .DefaultExt = "png"
            'Set the starting dir
            .InitialDirectory = "c:\"
            .AddExtension = True
            .FileName = myDoc.DocumentName() + ".pdf"
            .Filter = "PDF Files|*.pdf"
        End With

        sfd1.ShowDialog()

        If sfd1.FileName = Nothing Then
            Return
        End If

        File.Delete(runtime.AbsolutePath + "sites\tmp.png")
        _PrintImages(0).Save(runtime.AbsolutePath + "sites\tmp.png", System.Drawing.Imaging.ImageFormat.Png)

        image_pdf.One2One(sfd1.FileName, runtime.AbsolutePath + "sites\tmp.png")
        File.Delete(runtime.AbsolutePath + "sites\tmp.png")
    End Sub

    Private Sub btn_InsertWeld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_InsertWeld.Click
        btn_InsertWeld.Select()

        If Not LayerSelected() Then
            Return
        End If
        'daqumentRefresh()
        daqMode = EditDaqumentUtil.mode.InserWeld
        PictureBox1.Cursor = Cursors.Cross

    End Sub
   

    Private Sub btn_WeldList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_WeldList.Click
        Dim myForm As New EditDaqumentInfo(myDoc, "Daqument Weld List")
        myForm.Show()
    End Sub

    Private Sub btn_DefauletWeld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DefaultWeld.Click
        Dim myForm As New EditDaqumentInfo(myDoc, "Default Weld Properties")
        myForm.Show()
    End Sub



    Private Sub cms1_Closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles cms1.Closing
        ClearAllSelectedItems()
    End Sub
    Private Sub GridView2_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs)
        Dim View As GridView = sender
        Dim match As Boolean = False
        If e.Column.FieldName = "WeldStatus" Then
            Dim st = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, e.Column.FieldName))
            e.Appearance.BackColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor1(st)
            e.Appearance.ForeColor = EditDaqumentUtil.WeldStatusColorTranslation.GetColor2(st)
            'e.Appearance.Font = New Font(e.Appearance.Font.Name, _
            '   e.Appearance.Font.Size, FontStyle.Bold)
        End If
        'If e.Column.FieldName = "Count" Or e.Column.FieldName = "Unit Price" Then
        'Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Category"))
        'End If
    End Sub


  
 
    Private Sub cbx_FontSize_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbx_FontSize.SelectedIndexChanged
        For Each vec As EditDaqumentUtil.VectorMap In Vectors
            If vec.VectorType = EditDaqumentUtil.mode.InsertText Then
                If vec.itmSelected Then
                    If vec.tBox.Font.Size < 72 Then
                        Dim myFont = New Font(vec.tBox.Font.FontFamily, Me.cbx_FontSize.Text, _
                                    System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
                        vec.tBox.Font = myFont
                    End If
                End If
            End If
        Next
        Redraw()
    End Sub


    Private Sub btn_NextSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NextSheet.Click
        Dim query As String = "SELECT * FROM documents WHERE EngCode='" + myDoc.EngineeringCode + "' AND Sheet > '" + myDoc.Sheet.ToString + "' ORDER BY Sheet ASC, Revision DESC"

        'Dim SQLDaqument As New DataUtils("Daqument")
        'SQLDaqument.OpenConnection()
        Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(query)
        'SQLDaqument.CloseConnection()

        If dt.Rows.Count > 0 Then
            Me.LoadDocument(dt.Rows(0)(0))
        Else
            MessageBox.Show("There are no other sheets to display")
        End If


    End Sub

    Private Sub btn_PreviousSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PreviousSheet.Click
        Dim query As String = "SELECT * FROM documents WHERE EngCode='" + myDoc.EngineeringCode + "' AND Sheet < '" + myDoc.Sheet.ToString + "' ORDER BY Sheet DESC, Revision DESC"

        'Dim SQLDaqument As New DataUtils("Daqument")
        'SQLDaqument.OpenConnection()
        Dim dt As DataTable = runtime.SQLDaqument.ExecuteQuery(query)
        'SQLDaqument.CloseConnection()

        If dt.Rows.Count > 0 Then
            Me.LoadDocument(dt.Rows(0)(0))
        Else
            MessageBox.Show("There are no other sheets to display")
        End If

    End Sub





    Private Sub DesignTest_Click(sender As Object, e As EventArgs) Handles DesignTest.Click
        Debug.Print("Design button works")
        Dim docTest As Form1 = New Form1
        docTest.Show()


    End Sub
End Class

