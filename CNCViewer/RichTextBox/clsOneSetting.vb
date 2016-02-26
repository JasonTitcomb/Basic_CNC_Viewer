Friend Class clsOneSetting
    Public Name As String
    Public MatchText As String
    Public Color As Color
    Public Font As Font
    Public FontTableNumber As Integer = 0
    Public ColorTableNumber As Integer = 0
    'Public RtfCode As String
    Public Description As String
    Public Custom As Boolean
    Public Height As Single

    'Full featured constructor
    Public Sub New(ByVal sName As String, ByVal sDescription As String, ByVal text As String, ByVal fnt As Font, ByVal foreClr As Color, ByVal cust As Boolean)
        MatchText = text
        Color = foreClr
        Font = fnt
        Custom = cust
        Name = sName
        Description = sDescription
        Height = 0
    End Sub
    Public Sub New()
    End Sub
End Class
