Public Class clsParseError
    Public CharPosition As Integer
    Public LinePosition As Integer
    Public Msg As String
    Public Sub New(ByVal pos As Integer, ByVal line As Integer, ByVal msg As String)
        Me.CharPosition = pos
        Me.Msg = msg
        Me.LinePosition = line
    End Sub
End Class
