Public Class DisplayException
    Inherits Exception
    Private mNC_Source As String
    Private mOriginalMsg As String

    Public Sub New(ByVal originalMsg As String, ByVal nc_src As String)
        mNC_Source = nc_src
        mOriginalMsg = originalMsg
    End Sub
    Public Overrides ReadOnly Property Message() As String
        Get
            Return mOriginalMsg & " :Line=" & mNC_Source
        End Get
    End Property
End Class
