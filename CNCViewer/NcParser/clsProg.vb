Public Class clsProg
    Public Main As Boolean
    Public Label As String
    Public Value As Single
    Public Index As Integer
    Public Contents As String
    Public TimesCalled As Integer = 0
    Public StartLine As Integer
    Public StartChar As Integer
    Public BlockSkip As Single = 0
    Public FileName As String
    'Public OpenFile As Boolean
    Public Shared Function GetCurrentProgFile(ByVal prgs As Generic.List(Of clsProg), ByVal idx As Integer) As String
        Return prgs(idx).FileName
    End Function
End Class
