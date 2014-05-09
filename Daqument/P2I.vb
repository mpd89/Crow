Public Class P2I

    Private Declare Function apOpen Lib "pdf2image.dll" (ByVal lpFileName As String, ByVal lpOwnerPw As String, ByVal lpUserPw As String) As Integer
    Private Declare Function apClose Lib "pdf2image.dll" (ByVal nHandle As Integer) As Integer
    Private Declare Function apConvert Lib "pdf2image.dll" (ByVal nHandle As Integer) As Integer
    Private Declare Function apConvertPage Lib "pdf2image.dll" (ByVal nHandle As Integer, ByVal nPageNo As Integer) As Integer
    Private Declare Function apConvertPageToStream Lib "pdf2image.dll" (ByVal nHandle As Integer, ByVal nPageNo As Integer, ByRef pImageStream As Integer, ByRef nSize As Integer) As Integer
    Private Declare Function apSetProperty Lib "pdf2image.dll" (ByVal nHandle As Integer, ByVal nIndex As Integer, ByVal lpValue As String, ByVal nValue As Integer, ByVal nOther As Integer) As Integer
    Private Declare Function apGetProperty Lib "pdf2image.dll" (ByVal nHandle As Integer, ByVal nIndex As Integer, ByRef lpValue As String, ByRef nValue As Integer) As Integer

    '1.2 Definitions of converter's properties
    '==========================================================================================
    'read/write properties
    Const AP_PROP_OUTDIR = 1         'Destination directory.
    Const AP_PROP_PREFIX = 2         'The prefix of the name of result image file.
    Const AP_PROP_PAGEZOOM = 3       'Zoom scale of the source pdf page.
    Const AP_PROP_BGCOLOR = 4        'Image background color.
    Const AP_PROP_IMAGETYPE = 5      'Result image format.
    Const AP_PROP_BITCOUNT = 6       'Color bits per pixel.
    Const AP_PROP_XDPI = 7           'Horizontal resolution.
    Const AP_PROP_YDPI = 8           'Vertical resolution.
    Const AP_PROP_QUALITY = 9        'JPEG compression quality.
    Const AP_PROP_COMPRESSION = 10   'TIFF compression mode.
    Const AP_PROP_MULTIPAGES = 11    'Multipages TIFF file.
    Const AP_PROP_GRAYSCALE = 12     'Grayscale image.
    Const AP_PROP_XDIMENSIONS = 13   'The width of the result image in pixel
    Const AP_PROP_YDIMENSIONS = 14   'The height of the result image in pixel

    'read only properties
    Const AP_PROP_PAGECOUNT = 20     'The total pages of source pdf file.
    Const AP_PROP_PAGEHEIGHT = 21    'Height of the current page of source pdf file.
    Const AP_PROP_PAGEWIDTH = 22     'Width of the current page of source pdf file.
    '==========================================================================================

    '1.3 TIFF tag's definitions.
    '==========================================================================================
    Const AP_TIFF_COMPRESSION_NONE = 0      'No compression.
    Const AP_TIFF_COMPRESSION_LZW = 1       '1,4,8,24bits(default 4,8,24bits)
    Const AP_TIFF_COMPRESSION_JPEG = 2      'Grayscale 8bits,24bits
    Const AP_TIFF_COMPRESSION_PACKBITS = 3  '4,8,24bits
    Const AP_TIFF_COMPRESSION_CCITTG4 = 4   '1bit(default 1bit)
    Const AP_TIFF_COMPRESSION_CCITTG3 = 5   '1bit
    Const AP_TIFF_COMPRESSION_RLE = 6       '1bit
    '==========================================================================================


    '1.4 Image type's definitions
    '=======================================================================================
    Const AP_IMAGE_BMP = 1    'BMP
    Const AP_IMAGE_EMF = 2    'EMF
    Const AP_IMAGE_WMF = 3    'WMF
    Const AP_IMAGE_JPG = 4    'JPG
    Const AP_IMAGE_PNG = 5    'PNG
    Const AP_IMAGE_GIF = 6    'GIF
    Const AP_IMAGE_TIF = 7    'TIF
    Const AP_IMAGE_PCX = 8    'PCX

    Const AP_IMAGE_JPEG = 4   'JPEG
    Const AP_IMAGE_TIFF = 7   'TIFF
    '=======================================================================================

    '1.5 Return code's definitions.
    '==========================================================================================
    Const RTN_OK = 1           'Successful operation.
    Const ERR_UNKNOWN = -99    'Unknown system error.

    Const ERR_OVER_MAXTHREADS = -1     'Over the limit amount of threads
    Const ERR_FILE_UNEXIST = -2        'Source PDF file unexist.
    Const ERR_FILE_DAMAGED = -3        'Source PDF file is damaged.
    Const ERR_FILE_RESTRICTED = -4     'Source PDF file is restricted.

    Const ERR_INVALID_PAGE = -5      'The PDF page is invalid.
    Const ERR_CONVERT_FAILURE = -8   'Conversion failure.
    Const ERR_INVALID_STREAM = -9    'Invalid memory stream address.
    Const ERR_INVALID_HANDLE = -10   'The handle of conversion object is invalid.
    '==========================================================================================


    '1.6 Windows API definitions.
    '==========================================================================================
    Private Const OFS_MAXPATHNAME = 128

    Private Declare Function GetTickCount Lib "kernel32" () As Integer
    Private Declare Function GetCurrentProcess Lib "kernel32" () As Integer
    Private Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByVal lpBuffer() As Byte, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer


    Public Sub ImgConvert(ByVal FilePath As String, ByVal FileName As String, ByVal Xdpi As Integer, ByVal Ydpi As Integer, ByVal ColorFlag As Boolean)

        Dim nHandle As Integer
        Dim iPageNo, iPageAmount As Integer

        Dim iStartTick, iEndTick As Integer
        iStartTick = GetTickCount()

        'Open pdf file and creating a converter.
        nHandle = apOpen(FileName, "", "")
        Select Case nHandle
            Case ERR_OVER_MAXTHREADS
                MsgBox("Over the limit amount of threads,please waiting!")
                Exit Sub
            Case ERR_FILE_UNEXIST
                MsgBox("Source pdf file unexist!")
                Exit Sub
            Case ERR_FILE_DAMAGED
                MsgBox("Source pdf file damaged!")
                Exit Sub
            Case ERR_FILE_RESTRICTED
                MsgBox("Source pdf file restricted!")
                Exit Sub
        End Select

        'Setting the converter's propertys.
        'For more, please refer to above definitions.
        apSetProperty(nHandle, AP_PROP_OUTDIR, FilePath, 0, 0)  'output directory
        apSetProperty(nHandle, AP_PROP_PREFIX, "OutputFile", 0, 0)    'prefix of image file name
        apSetProperty(nHandle, AP_PROP_IMAGETYPE, "", AP_IMAGE_PNG, 0) 'image type
        apSetProperty(nHandle, AP_PROP_XDPI, "", Xdpi, 0)  'horizontal dpi
        apSetProperty(nHandle, AP_PROP_YDPI, "", Ydpi, 0)  'vertical dpi
        apSetProperty(nHandle, AP_PROP_BGCOLOR, "white", 0, 0)  'bg color

        If ColorFlag Then
            'apSetProperty(nHandle, , "True", 1, 0)
            apSetProperty(nHandle, AP_PROP_BITCOUNT, "", 24, 0)
        Else
            apSetProperty(nHandle, AP_PROP_GRAYSCALE, "True", 1, 0)
            apSetProperty(nHandle, AP_PROP_BITCOUNT, "", 4, 0)
        End If
        'apSetProperty(nHandle, AP_PROP_COMPRESSION, "", AP_TIFF_COMPRESSION_LZW, 0)

        'Get the amount of the source pdf pages
        apGetProperty(nHandle, AP_PROP_PAGECOUNT, "", iPageAmount)

        'To convert the pdf file.
        For iPageNo = 1 To iPageAmount
            apConvertPage(nHandle, iPageNo)

            'Setting conversion's progress.
            'm_ProgressBar.Value = Math.Round((iPageNo * 1.0#) / iPageAmount * 100)
        Next



        'Close pdf file and destory the converter.
        apClose(nHandle)

        'To count conversion's time(ms).
        iEndTick = GetTickCount()
        'MsgBox("Conversion successful,it passed " + CStr(iEndTick - iStartTick) + "ms!")


    End Sub

End Class
