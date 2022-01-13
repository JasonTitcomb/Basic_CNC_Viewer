Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Public Structure Address
    Private mLabel As String
    Public Value As Double
    Public DecimalString As String
    Public AddressArrayIndex As Integer
    Public Function Init(ncWord As Match) As Boolean
        Label = ncWord.Groups(1).Value.Trim
        If ncWord.Groups(2).Value.Length > 0 Then
            DecimalString = ncWord.Groups(2).Value.Replace(","c, "."c)
            Value = Double.Parse(DecimalString, Globalization.NumberFormatInfo.InvariantInfo)
            Return True
        Else
            Return False
        End If
    End Function
    Public Property Label() As String
        Get
            Return mLabel
        End Get
        Set(ByVal value As String)
            mLabel = value.ToUpper
            AddressArrayIndex = Text.Encoding.ASCII.GetBytes(mLabel)(0) - 65
            If mLabel.Length = 2 Then
                AddressArrayIndex += Text.Encoding.ASCII.GetBytes(mLabel)(1) - 65
            End If
        End Set
    End Property

    Function IsMatch(ByVal a As Address) As Boolean
        If (a.Label = Me.Label) AndAlso (a.Value = Me.Value) Then
            Return True
        Else
            Return False
        End If
    End Function

    Overrides Function ToString() As String
        Return Label & Value
    End Function
End Structure

Public Class WrkOffset
    Public PrimaryAddress As Address
    Public SecondaryAddress As Address
    Public X As Double
    Public Y As Double
    Public Z As Double
    Public A As Double
    Public B As Double
    Public C As Double
    Public Sub Reset()
        X = 0
        Y = 0
        Z = 0
        A = 0
        B = 0
        C = 0
        PrimaryAddress.Value = Double.NaN
        SecondaryAddress.Value = Double.NaN
    End Sub
    Public Sub ApplyToArray(ByRef arr As Double())
        arr(0) = X
        arr(1) = Y
        arr(2) = Z
        arr(3) = A
        arr(4) = B
        arr(5) = C
    End Sub
    Public Function Match(pri As String, sec As String) As Boolean
        If SecondaryAddress.Value > 0 Then
            Return PrimaryAddress.ToString = pri AndAlso SecondaryAddress.ToString = sec
        Else
            Return PrimaryAddress.ToString = pri
        End If

    End Function
    Public Overrides Function ToString() As String
        Dim ret As String = ""
        If PrimaryAddress.Value > 0 Then
            ret = PrimaryAddress.ToString.Trim
        End If
        If SecondaryAddress.Value > 0 Then
            ret += SecondaryAddress.ToString.Trim
        End If
        Return ret
    End Function
End Class

Public Class clsMotion
    Public WrkOffsets As New List(Of WrkOffset) 'G54 G55 ...
    Public G10L2PooXYZ As Address 'G10 L2 P XYZ
    Public Drills(9) As Address 'G81,G82
    Public ReturnLevel(1) As Address 'G98,G99
    Public DrillRapid As Address 'R
    Public Rapid As Address 'G00
    Public Linear As Address 'G01
    Public CCArc As Address 'G03
    Public CWArc As Address 'G02
    Public Inc As Address 'G91
    Public Abs As Address 'G90
    Public G92 As Address 'G92.1
    Public G52 As Address 'Offset to offset?
    Public G51 As Address 'Scaling on
    Public G50 As Address 'Scaling off
    Public G51_1 As Address 'Mirror
    Public G50_1 As Address 'Mirror off
    Public G68 As Address 'Rotate on
    Public G69 As Address 'Rotate off
    Public IgnoreOffsetNonModal As Address 'G53
    Public AbsIJK As Address
    Public IncIJK As Address
    Public CompLeft As Address 'G41
    Public CompRight As Address 'G42
    Public CompCancel As Address 'G40
    Public Plane(2) As Address 'G18,18,19
    Public Rotary As Address 'A B C
    Public SubCall As Address 'M98
    Public SubCallParam As Address 'H or P
    Public LocalSubCall As Address 'M97
    Public LocalSubCallParam As Address 'H or P
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

