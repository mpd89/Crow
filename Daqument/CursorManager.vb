Imports System


Public Class CursorManager

    Public Const NUM_OF_CURSORS = 2
    Public Shared customCursors(NUM_OF_CURSORS) As Cursor
    Private cursorFileName() As String = _
               {"Search_Zoom_In.ico", _
                "Search_Zoom_Out.ico"}


    Public Sub LoadCustomCursors()
        Dim CurrentAssembly As String = _
    Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString()
        Dim cursorFile As IO.Stream
        Dim i As Integer

        For i = 0 To NUM_OF_CURSORS - 1
            cursorFile = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream( _
                                CurrentAssembly + "." + cursorFileName(i))
            customCursors(i) = New Cursor(cursorFile)
        Next i

    End Sub
End Class
