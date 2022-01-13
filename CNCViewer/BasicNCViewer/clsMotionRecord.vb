Imports Abacus.DoublePrecision
Public Class clsMotionRecord
    Public Index As Integer
    Public WorldShift As BlockShiftType
    Public OffsetString As String
    Public Codestring As String 'cnc codeline
    Public MotionType As Motion 'point,arc,line etc....
    Public MotionMode As IncAbsMode
    Public Units As MachineUnits
    Public FeedMode As FeedMode
    Public SpeedMode As SpeedMode
    Public Comp As CutterComp
    Public Linenumber As Integer 'line number of CNC file
    Public CharPos As Integer
    Public ProgIndex As Integer

    Public XYZold As Vector3
    Public XYZpos As Vector3
    Public XYZcenter As Vector3
    Public ABCold As Vector3
    Public ABCpos As Vector3

    Public Rpoint As Double
    Public Rad As Double
    Public DrillClear As Double

    Public Sang As Double
    Public Eang As Double
    Public OldRotaryPos As Double
    Public NewRotaryPos As Double

    Public DrawColor As Color
    Public ToolDia As Double
    Public Tool As Double
    Public Speed As Double
    Public RPM As Double
    Public MaxRpm As Double
    Public FeedRate As Double
    Public RapidRate As Double
    Public Rotate As Boolean
    Public RotaryDir As Integer
    Public ArcPlane As Integer
    Public Visible As Boolean = True
    Public FilterZ As Boolean = False
    Public RapidLength As Double = 0
    Public CuttingLength As Double = 0
    Public MotionTime As Double
    Public PriorMotion As clsMotionRecord
    Public CornerBreak As Double
    Public CornerBreakType As CornerBreakType
    'Public MCS_G54(5) As Double
    'Public MCS_G52(5) As Double
    Public Overrides Function ToString() As String
        Return Codestring
    End Function
    Public Function ShallowCopy() As clsMotionRecord
        Dim clone As clsMotionRecord = DirectCast(Me.MemberwiseClone(), clsMotionRecord)

        With clone
            .XYZold = XYZpos
            .ABCold = ABCpos
            .Codestring = ""
            .OldRotaryPos = NewRotaryPos
            .PriorMotion = Me
            .CornerBreak = 0
            .CornerBreakType = CornerBreakType.None
        End With

        Return clone
    End Function
End Class
