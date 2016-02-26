Public Class clsBlockSkip
    Public Match As String
    Public Enabled As Boolean

    Public Sub New(ByVal match As String)
        Me.Match = match
        Me.Enabled = False
    End Sub

End Class
