Friend Class clsColorBar
    Public Brush As Brush
    Public Color As Color
    Public Text As String
    Public Value As Integer

    Public Sub New(ByVal clr As Color, ByVal txt As String, ByVal val As Integer)
        Brush = New SolidBrush(clr)
        Color = clr
        Text = txt
        Value = val
    End Sub
End Class
