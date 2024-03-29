Public Class clsMachine 'Store all settings in this class
    Public Name As String 'file name
    Public Description As String 'file name
    Public GlobalReplacements As String
    Public ProgramId As String
    Public ExternalCall As String 'call sub
    Public ExternalCallParam As String
    Public InternalCall As String 'local call sub
    Public InternalCallParam As String
    Public SubRepeats As String
    Public SubReturn As String 'return from sub
    Public Endmain As String 'End of main program
    Public BlockSkip As String 'do not process lines that start with this
    Public Comments As String 'Comments
    Public MachineType As MachineType 'lathe ,mill etc..
    Public MachineUnits As MachineUnits 'English or metric
    Public UnitsEnglishAddress As String 'G20
    Public UnitsMetricAddress As String 'G21
    Public LatheMinus As Boolean 'this is for minus lathes
    Public HelixPitch As Boolean 'helix check box setting
    Public AbsArcCenter As Boolean 'Arc center chkbox
    Public Precision As Integer 'output precision 0.0001
    Public FeedPrecision As Integer
    Public FeedModeMin As String
    Public FeedModeRev As String
    Public SpeedModeSFM As String
    Public SpeedModeRPM As String

    Public RapidRate As Single
    Public MaxRpmAddress As String
    Public MaxRpmValue As Single
    Public DogLegMotion As Boolean
    Public AllowG10 As Boolean
    Public Searchstring As String 'a string that determines the setup record
    Public Drills(9) As String '10 drilling cycles 0 index is the cancel code
    Public ReturnLevel(1) As String
    Public DrillRapid As String
    Public Rapid As String
    Public Linear As String
    Public CCArc As String
    Public CWArc As String
    Public Incremental As String
    Public Absolute As String
    Public CompLeft As String
    Public CompRight As String
    Public CompCancel As String
    Public AbsIJK As String
    Public IncIJK As String
    Public XYplane As String
    Public XZplane As String
    Public YZplane As String
    Public ViewAngles(2) As Single 'Store pitch,roll,yaw
    Public Rotary As String 'Rotary axis code ABC
    Public RotaryDir As RotaryDirection '+1 or -1
    Public RotaryAxis As ArcAxis 'XYZ
    Public RotaryType As RotaryMotionType
    Public RotPrecision As Integer 'output precision 0.0001
    Public Rotary1Radius As Single
    Public ViewShift(2) As Single 'Shift the view for viewing
    Public Invert(3) As Single 'invert values
    Public UseUVW As Boolean
    Public InvertArcCenterValues As Boolean
    Public HomeCommand As String 'G28
    Public ToolChange As String 'M06
    Public HomeAddresses(2) As String
    Public HomeValues(2) As Single
    Public Limits(5) As Single
    Public ParserName As String
    Public EmitterName As String
    Public CornerTreatments As Boolean
    Public AllowTaper As Boolean
    Public WorkOffsets As String
    Public WorkOffsetCancel As String
    Public WorkOffsetPreAddress As String
    Public WorkOffsetTemp As String
    Public WorkOffsetG52 As String
    Public G68RotOn As String
    Public G68RotOff As String
    Public G68RotX As String
    Public G68RotY As String
    Public G68RotR As String
    Public G51ScaleOn As String
    Public G51ScaleOff As String
    Public G51ScaleX As String
    Public G51ScaleY As String
    Public G51ScaleZ As String
    Public G51ScaleFactor As String
    Public MirrorOn As String
    Public MirrorOff As String
    Public MirrorX As String
    Public MirrorY As String
    Public MirrorZ As String

    Public Sub New(ByVal name As String)
        Me.Name = name
    End Sub
    Public Sub New()
    End Sub
End Class
