
Friend Structure Address
    Public Property Label() As Char
        Get
            Return mLabel
        End Get
        Set(ByVal value As Char)
            mLabel = value
            AddressArrayIndex = Text.Encoding.ASCII.GetBytes(mLabel)(0) - 65
        End Set
    End Property
    Private mLabel As Char
    Public Value As Single
    Public DecimalString As String
    Public AddressArrayIndex As Integer

    Function IsMatch(ByVal a As Address) As Boolean
        Return (a.Label = Me.Label) AndAlso (a.Value = Me.Value)
    End Function
End Structure

Friend Class clsMotion
    Public Drills(9) As Address 'G81,G82
    Public ReturnLevel(1) As Address 'G98,G99
    Public DrillRapid As Address 'R
    Public Rapid As Address 'G00
    Public Linear As Address 'G01
    Public CCArc As Address 'G03
    Public CWArc As Address 'G02
    Public Inc As Address 'G91
    Public Abs As Address 'G90
    Public CompLeft As Address 'G41
    Public CompRight As Address 'G42
    Public CompCancel As Address 'G40
    Public Plane(2) As Address 'G18,18,19
    Public Rotary As Address 'A B C
    Public SubCall As Address 'M98
    Public SubReturn As Address 'M99
    Public FeedModeMin As Address 'G98
    Public FeedModeRev As Address 'G99
    Public SpeedModeRPM As Address 'G96
    Public SpeedModeSFPM As Address 'G97
    Public SpeedLimit As Address 'G50
    Public GoHome As Address 'G28
    Public ToolChange As Address 'M6
    Public UnitsEnglish As Address 'G20
    Public UnitsMetric As Address 'G21
End Class