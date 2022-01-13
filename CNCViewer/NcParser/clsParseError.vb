
Public Class clsParseError
    Public CharPosition As Integer
    Public LinePosition As Integer
    Public Msg As String
    Public WordMatch As String
    Public File As String
    Public Sub New(srcfile As String, ByVal pos As Integer, ByVal line As Integer, ByVal msg As String, Optional wordMatch As String = Nothing)
        Me.CharPosition = pos
        Me.Msg = msg
        Me.LinePosition = line
        Me.WordMatch = wordMatch
        Me.File = srcfile
    End Sub
End Class
