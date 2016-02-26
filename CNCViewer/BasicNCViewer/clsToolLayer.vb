Public Class clsToolLayer
    Public Color As Color
    Public Number As Single
    Public Hidden As Boolean

    Public Sub New(ByVal number As Single, ByVal color As Color)
        Me.Number = number
        Me.Color = color
        Me.Hidden = False
    End Sub

    Public Overrides Function ToString() As String
        Return Number & " - " & Me.Color.ToString
    End Function
End Class
