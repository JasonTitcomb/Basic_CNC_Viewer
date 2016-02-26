Public Class ParseException
    Inherits Exception

    Public Sub New(ByVal msg As String, ByVal originalException As Exception, ByVal codeFragment As String, ByVal allSettings As String)
        MyBase.New(msg, originalException)
        mCodeFragment = CodeFragment
        mAllSettings = allSettings
    End Sub

    Private mCodeFragment As String
    Public ReadOnly Property CodeFragment() As String
        Get
            Return mCodeFragment
        End Get
    End Property

    Private mAllSettings As String
    Public ReadOnly Property AllSettings() As String
        Get
            Return mAllSettings
        End Get
    End Property

End Class
