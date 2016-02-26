Imports System.Collections.Generic

Friend Class clsColorSettings
    Public Name As String = ""
    Public BackColor As Color = Color.White
    Public GutterBackColor As Color = Color.Blue
    Public GutterForeColor As Color = Color.White
    Public BookmarkColor As Color = Color.Red
    Public GutterFont As Font
    Public Indent As Integer = 0
    Public TextRangeBoxColor As Color = Color.FromName("Highlight")
    Public StdSettings As New List(Of clsOneSetting)
    Public CstSettings As New List(Of clsOneSetting)
End Class
