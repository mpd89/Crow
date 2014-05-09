Imports System.Windows.Forms
'Imports System.ComponentModel
'Imports System.Globalization
'Imports System.Collections
'Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
'Imports System.Data.SqlServerCe
'Imports Microsoft.VisualBasic.FileIO
'Imports System.Drawing.Graphics
Imports daqartDLL
'Imports SystemManager
Public Class image_pdf
    Private Declare Function ApCreate Lib "imagetopdf.dll" (ByVal lpFileName As String) As Integer
    Private Declare Function ApOpen Lib "imagetopdf.dll" (ByVal lpFileName As String) As Integer
    Private Declare Sub ApClose Lib "imagetopdf.dll" (ByVal id As Integer)
    Private Declare Function ApAddImage Lib "imagetopdf.dll" (ByVal id As Integer, ByVal lpFileName As String) As Integer
    Private Declare Function ApAddImageData Lib "imagetopdf.dll" (ByVal id As Integer, ByVal MemData() As Byte, ByVal width As Integer, ByVal height As Integer, ByVal color As Integer) As Integer
    Private Declare Function ApAddTextEx Lib "imagetopdf.dll" (ByVal id As Integer, ByVal x As Integer, ByVal y As Integer, ByVal str As String, ByVal color As Integer) As Integer
    Private Declare Function ApAddText Lib "imagetopdf.dll" (ByVal id As Integer, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal str As String, ByVal color As Integer, ByVal bkcolor As Integer, ByVal lformat As Integer) As Integer
    Private Declare Function ApAddTxt Lib "imagetopdf.dll" (ByVal id As Integer, ByVal lpFileName As String, ByVal color As Integer, ByVal PageWidth As Integer, ByVal PageHeight As Integer, ByVal AutoNewLine As Integer, ByVal AutoWidthAdjust As Integer, ByVal LeftMargin As Integer, ByVal RightMargin As Integer, ByVal TopMargin As Integer, ByVal BottomMargin As Integer, ByVal TabSize As Integer) As Integer
    Private Declare Function ApAddLine Lib "imagetopdf.dll" (ByVal id As Integer, ByVal sx As Integer, ByVal sy As Integer, ByVal ex As Integer, ByVal ey As Integer, ByVal side_width As Integer, ByVal side_color As Integer) As Integer
    Private Declare Function ApAddRect Lib "imagetopdf.dll" (ByVal id As Integer, ByVal sx As Integer, ByVal sy As Integer, ByVal ex As Integer, ByVal ey As Integer, ByVal side_width As Integer, ByVal side_color As Integer, ByVal flagFill As Integer, ByVal fill_color As Integer) As Integer
    Private Declare Function ApAddInfo Lib "imagetopdf.dll" (ByVal id As Integer, ByVal Title As String, ByVal Subject As String, ByVal Author As String, ByVal Keywords As String, ByVal Creator As String) As Integer
    Private Declare Function ApSetFunction Lib "imagetopdf.dll" (ByVal id As Integer, ByVal func_code As Integer, ByVal Para1 As Integer, ByVal Para2 As Integer, ByVal szPara3 As String, ByVal szPara4 As String) As Integer
    Private Declare Function ApGetFunction Lib "imagetopdf.dll" (ByVal id As Integer, ByVal func_code As Integer, ByVal Para1 As Integer, ByVal Para2 As Integer, ByVal szPara3 As String, ByVal szPara4 As String) As Integer


    'defined for ApSetFunction
    Const Ap_Set_MultiPage = 101
    Const Ap_Set_ImagePosAndSize = 104
    Const Ap_Set_Encrypt = 105
    Const Ap_Set_Font = 106
    Const Ap_Set_NewOrClosePage = 109
    Const Ap_Set_BookMark = 110
    Const Ap_Set_ViewerPreferences = 121
    Const Ap_Set_Orientation = 122
    Const Ap_Set_Recompress = 123
    Const Ap_Set_Skewcorrect = 126
    Const Ap_Set_JpegQuality = 128

    'defined for ApGetFunction
    Const Ap_Get_ImagePageCount = 201
    Const Ap_Get_ImageSizeW = 202
    Const Ap_Get_ImageSizeH = 203
    Const Ap_Get_ImageDpiX = 204
    Const Ap_Get_ImageDpiY = 205
    Const Ap_Get_PdfPageCount = 206
    Const Ap_Get_PdfCurrentPageSize = 209
    Const Ap_Get_StringWidth = 250
    Const Ap_Get_StringHeight = 251
    Const Ap_Get_Recomporess = 210
    Const Ap_Get_ImageBits = 211

    'defined for ApAddText
    Const Ap_DT_LEFT = &H0
    Const Ap_DT_CENTER = &H1
    Const Ap_DT_RIGHT = &H2
    Const Ap_DT_WORDBREAK = &H10
    Const Ap_DT_CALCRECT = &H400

    'defined permission
    Const permission_Print = 1
    Const permission_Copy = 2
    Const permission_Modify = 4
    'para1=para2=1 : A3
    '       para1=para2=2 : A4
    '        para1=para2=3 : A5
    '       para1=para2=4 : B5
    '        para1=para2=5 : letter
    '       para1=para2=6 : legal 

    'Para1
    ' Font name

    '100
    ' Times-Roman

    '101
    ' Times-Bold

    '102
    ' Times-Italic

    '103
    ' Times-Bold-Italic

    '200
    ' Courier

    '201
    ' Courier-Bold

    '202
    ' Courier-Oblique

    '203
    ' Courier-Bold-Oblique

    '300
    ' Helvetica

    '301
    ' Helvetica-Bold

    '302
    ' Helvetica-Oblique

    '303
    ' Helvetica-Bold-Oblique

    '400
    ' Symbol


    Public Shared Sub One2One(ByVal pPdf As String, ByVal pImage As String)
        Dim ret, id As Integer
        id = ApCreate(pPdf)
        If id > 0 Then
            ret = ApAddImage(id, pImage)
            ApClose(id)
        End If
    End Sub


    Public Shared Sub Multiple2One(ByVal pPdf As String, ByVal pImage() As String)
        Dim id = ApCreate(pPdf + ".pdf")
        For i As Integer = 0 To pImage.Length - 1
            Dim ret As Object
            Dim ImageHeight2, ImageHeight, ImageWidth, ImageWidth2, PageWidth As Object
            Dim PageHeight As Integer
            Dim xdpi As Object
            Dim ydpi As Integer
            Dim fZoom, zw As Object
            Dim zh As Double
            If (id > 0) Then
                ImageWidth = ApGetFunction(id, Ap_Get_ImageSizeW, 0, 0, pImage(i), vbNullString)
                'UPGRADE_WARNING: Couldn't resolve default property of object ImageHeight. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ImageHeight = ApGetFunction(id, Ap_Get_ImageSizeH, 0, 0, pImage(i), vbNullString)

                'Get image dpi (Resolution)
                'UPGRADE_WARNING: Couldn't resolve default property of object xdpi. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                xdpi = ApGetFunction(id, Ap_Get_ImageDpiX, 0, 0, pImage(i), vbNullString)
                ydpi = ApGetFunction(id, Ap_Get_ImageDpiY, 0, 0, pImage(i), vbNullString)

                'keep image dpi (resolution)
                'UPGRADE_WARNING: Couldn't resolve default property of object xdpi. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ''If (xdpi > 0 And ydpi > 0) Then
                ''    'UPGRADE_WARNING: Couldn't resolve default property of object xdpi. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ''    'UPGRADE_WARNING: Couldn't resolve default property of object ImageWidth. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ''    'UPGRADE_WARNING: Couldn't resolve default property of object ImageWidth2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ''    ImageWidth2 = (ImageWidth * (72.0# / xdpi))
                ''    'UPGRADE_WARNING: Couldn't resolve default property of object ImageHeight. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ''    'UPGRADE_WARNING: Couldn't resolve default property of object ImageHeight2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ''    ImageHeight2 = (ImageHeight * (72.0# / ydpi))
                ''End If
                'UPGRADE_WARNING: Couldn't resolve default property of object ImageHeight2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object ImageWidth2. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object ret. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'ret = ApSetFunction(id, Ap_Set_NewOrClosePage, ImageWidth2, ImageHeight2, vbNullString, vbNullString)
                'UPGRADE_WARNING: Couldn't resolve default property of object ret. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'ret = ApAddImage(id, pImage(i))

                'page size with image size
                'UPGRADE_WARNING: Couldn't resolve default property of object ImageHeight. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object ImageWidth. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object ret. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ret = ApSetFunction(id, Ap_Set_NewOrClosePage, ImageWidth, ImageHeight, vbNullString, vbNullString)
                ret = ApSetFunction(id, Ap_Set_Recompress, 2, vbNullString, "lzw", vbNullString)
                'UPGRADE_WARNING: Couldn't resolve default property of object ret. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ret = ApAddImage(id, pImage(i))

            End If

        Next i
        ApClose(id)

    End Sub
    Private Sub PageHeader(ByVal id As Integer, ByVal Heading As String, ByVal SubHeading As String)
        'If PgInfos(pgNum).Heading Then
        '    Dim logoPath = runtime.AbsolutePath + "sites\images\logo128.jpg"
        '    ApAddImage(id, logoPath)
        '    Dim logoImg As Image = Image.FromFile(logoPath)
        '    Dim f_title As Font = New Font("Times New Roman", 20, FontStyle.Bold)

        '    Dim PprSize As PaperSize = e.PageSettings.PaperSize
        '    e.Graphics.DrawRectangle(Pens.Blue, 50, 50, PprSize.Width - 100, PprSize.Height - 100)
        '    e.Graphics.DrawImage(logoImg, 600, 60, logoImg.Width, logoImg.Height)
        '    Dim HdrX As Integer = 60 : Dim HdrY As Integer = 100
        '    e.Graphics.DrawString(Heading, f_title, Brushes.Black, HdrX, HdrY)
        '    HdrY = HdrY + TextRenderer.MeasureText(SubHeading, f_title).Height + 5
        '    e.Graphics.DrawString(SubHeading, f_title, Brushes.Black, HdrX, HdrY)
        '    e.Graphics.DrawLine(Pens.Blue, 70, 200, PprSize.Width - 60, 200)
        '    logoImg.Dispose()
        'End If
    End Sub


    Public Shared Sub PrintPDFPages(ByRef PgInfos() As PrintUtils.InfoSetting, ByVal pPdf As String)
        Dim id = ApCreate(pPdf)
        If id <= 0 Then
            MessageBox.Show("File (" + pPdf + ") creation error")
            Return
        End If
        Dim ret = ApSetFunction(id, Ap_Set_MultiPage, 0, 0, 0, 0)
        If ret <= 0 Then Return
        Dim owd As Single = ApGetFunction(id, Ap_Get_PdfCurrentPageSize, 0, 0, "width", "")
        Dim oht As Single = ApGetFunction(id, Ap_Get_PdfCurrentPageSize, 0, 0, "height", "")


        For pgNum As Integer = 0 To PgInfos.Length - 1
            Dim pwd As Integer = PgInfos(pgNum).pSize.Width
            Dim pht As Integer = PgInfos(pgNum).pSize.Height
            If PgInfos(pgNum).Landscape Then
                Dim nOrientation = 0
                ret = ApSetFunction(id, Ap_Set_NewOrClosePage, pht, pwd, "", "")
                ret = ApSetFunction(id, Ap_Set_Orientation, nOrientation, 0, vbNullString, vbNullString)

            Else
                Dim nOrientation = 0
                ret = ApSetFunction(id, Ap_Set_Orientation, nOrientation, 0, vbNullString, vbNullString)
                ret = ApSetFunction(id, Ap_Set_NewOrClosePage, pwd, pht, "", "")
            End If
            Dim nwd As Single = ApGetFunction(id, Ap_Get_PdfCurrentPageSize, 0, 0, "width", "")
            Dim nht As Single = ApGetFunction(id, Ap_Get_PdfCurrentPageSize, 0, 0, "height", "")
            Dim XscaleFactor As Single = nwd / owd
            Dim YscaleFactor As Single = nht / oht
            If PgInfos(pgNum).PrintHdr Then
                Dim logoPath = runtime.AbsolutePath + "sites\images\logo128.jpg"
                Dim logoImg As Image = System.Drawing.Image.FromFile(logoPath)
                ret = ApSetFunction(id, Ap_Set_ImagePosAndSize, 600, 60, logoImg.Width, logoImg.Height)
                ApAddImage(id, logoPath)
                logoImg.Dispose()
                ApAddRect(id, 50, 50, 50 + nwd - 100, 50 + nht - 100, 2, RGB(0, 0, 255), 0, 0)
                ret = ApAddLine(id, 70, 200, nwd - 100, 200, 2, RGB(0, 0, 255))
                ret = ApSetFunction(id, Ap_Set_Font, 1, 32, "Times New Roman", vbNullString)
                Dim HdrX As Integer = 60 : Dim HdrY As Integer = 100
                ret = ApAddTextEx(id, HdrX, HdrY, PgInfos(pgNum).Heading, RGB(0, 0, 0))
                Dim f_title As Font = New Font("Times New Roman", 32, FontStyle.Bold)
                HdrY = HdrY + TextRenderer.MeasureText(PgInfos(pgNum).SubHeading, f_title).Height + 5
                ret = ApAddTextEx(id, HdrX, HdrY, PgInfos(pgNum).SubHeading, RGB(0, 0, 0))

            End If
            If PgInfos(pgNum).PrintFooter Then
                Dim str As String = "Page " + pgNum.ToString + " of " + PgInfos.Length.ToString + "                      " + _
                                    Now.Date.ToShortDateString
                ret = ApSetFunction(id, Ap_Set_Font, 1, 10, "Times New Roman", vbNullString)
                ret = ApAddTextEx(id, 50, pht - 30, str, RGB(0, 0, 0))
            End If
            If Not PgInfos(pgNum).pgBody Is Nothing Then
                If PgInfos(pgNum).pgBody.Length > 0 Then
                    For Each obj As PrintUtils.pgBodyContents In PgInfos(pgNum).pgBody
                        If obj.contentType = PrintUtils.pgContentType.image Then
                            Dim ob As String = CType(obj.obj, String)
                            Dim Img As Image = System.Drawing.Image.FromFile(ob)
                            'If Img.Size.Width > Img.Size.Height Then
                            '    Img.RotateFlip(RotateFlipType.Rotate90FlipNone)
                            'End If
                            ret = ApSetFunction(id, Ap_Set_ImagePosAndSize, obj.loc.X, obj.loc.Y, Img.Width, Img.Height)
                            ApAddImage(id, ob)
                            Img.Dispose()
                        End If
                    Next
                    For Each obj As PrintUtils.pgBodyContents In PgInfos(pgNum).pgBody
                        If obj.contentType = PrintUtils.pgContentType.docImage Then
                            Dim ob As String = CType(obj.obj, String)
                            Dim img As Image = Image.FromFile(ob)
                            If img.Size.Width > img.Size.Height Then
                                img.RotateFlip(RotateFlipType.Rotate90FlipNone)
                                ret = ApSetFunction(id, Ap_Set_ImagePosAndSize, 0, 0, pht, pwd)

                            Else
                                ret = ApSetFunction(id, Ap_Set_ImagePosAndSize, 0, 0, pwd, pht)
                            End If
                            'img.RotateFlip(RotateFlipType.Rotate90FlipX)
                            'File.Delete(ob)
                            'img.Save(ob)
                            ApAddImage(id, ob)
                            img.Dispose()
                        End If
                    Next
                    For Each obj As PrintUtils.pgBodyContents In PgInfos(pgNum).pgBody
                        If obj.contentType = PrintUtils.pgContentType.text Then
                            Dim str As String = CType(obj.obj, String)
                            Dim fsz As Integer = obj.mfont.Size * YscaleFactor
                            Dim yofst As Integer = obj.loc.Y / 1100.0 * 40.0
                            Dim xofst As Integer = obj.loc.X / 850.0 * 30.0
                            ret = ApSetFunction(id, Ap_Set_Font, 1, fsz, "Times New Roman", vbNullString)
                            Dim Red As Integer = obj.foreColor.R
                            Dim Blue As Integer = obj.foreColor.B
                            Dim Green As Integer = obj.foreColor.G
                            'ret = ApAddTextEx(id, obj.loc.X, obj.loc.Y, str, RGB(Red, Green, Blue)) ' obj.foreColor)
                            ret = ApAddText(id, obj.loc.X, obj.loc.Y, obj.sz.Width, obj.sz.Height, str, RGB(Red, Green, Blue), RGB(255, 255, 255), 0)
                        ElseIf obj.contentType = PrintUtils.pgContentType.line Then
                            Dim st As Point = obj.loc : Dim en As Point = obj.eloc
                            Dim stY As Integer = st.Y / 1100.0 * 40.0
                            Dim stX As Integer = st.X / 850.0 * 30.0
                            Dim enY As Integer = en.Y / 1100.0 * 40.0
                            Dim enX As Integer = en.X / 850.0 * 30.0
                            ret = ApAddLine(id, st.X, st.Y, en.X, en.Y, 2, RGB(0, 0, 0))
                        ElseIf obj.contentType = PrintUtils.pgContentType.docImage Then
                            Dim ob As String = CType(obj.obj, String)
                            'ret = ApSetFunction(id, Ap_Set_ImagePosAndSize, 0, 0, PgInfos(pgNum).pSize.Width, PgInfos(pgNum).pSize.Height)
                            'ApAddImage(id, ob)
                        ElseIf obj.contentType = PrintUtils.pgContentType.rect Then
                            Dim rct As Rectangle = CType(obj.obj, Rectangle)
                            ApAddRect(id, rct.X, rct.Y, rct.X + rct.Width, rct.Y + rct.Height, 2, RGB(0, 0, 0), 0, RGB(255, 255, 255))
                        End If
                    Next

                End If
            End If
            If PgInfos(pgNum).PrintFooter Then
                'PageFooter(id, pgInfo(pgNum).PgNum)
            End If

        Next
        ApClose(id)

    End Sub

    Public Shared Sub OLDMultiple2One(ByVal pPdf As String, ByVal pImage() As String)
        Dim ret, id, i As Integer

        id = ApCreate(pPdf)
        If id > 0 Then
            For i = 0 To pImage.Length - 1

                ret = ApAddImage(id, pImage(i))

            Next i
            ApClose(id)
        End If

    End Sub



End Class
