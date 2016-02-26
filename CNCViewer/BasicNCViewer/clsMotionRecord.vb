Public Class clsMotionRecord
    Public Codestring As String 'cnc codeline
    Public MotionType As Motion 'point,arc,line etc....
    Public Units As MachineUnits
    Public FeedMode As FeedMode
    Public SpeedMode As SpeedMode
    Public Comp As CutterComp
    Public Linenumber As Integer 'line number of CNC file
    Public ProgIndex As Integer

    Public Xold As Single
    Public Yold As Single
    Public Zold As Single
    Public Aold As Single
    Public Bold As Single
    Public Cold As Single

    Public Xpos As Single
    Public Ypos As Single
    Public Zpos As Single
    Public Apos As Single
    Public Bpos As Single
    Public Cpos As Single

    Public Rpoint As Single
    Public Rad As Single
    Public Xcentr As Single
    Public Ycentr As Single
    Public DrillClear As Single

    Public Sang As Single
    Public Eang As Single

    Public Zcentr As Single
    Public DrawColor As Color
    Public Tool As Single
    Public Speed As Single
    Public RPM As Single
    Public MaxRpm As Single
    Public FeedRate As Single
    Public RapidRate As Single
    Public Rotate As Boolean
    Public OldRotaryPos As Single
    Public NewRotaryPos As Single
    Public RotaryDir As Integer
    Public ArcPlane As Integer
    Public Visible As Boolean = True
    Public FilterZ As Boolean = False
    Public RapidLength As Single = 0
    Public CuttingLength As Single = 0
    Public MotionTime As Double
End Class
