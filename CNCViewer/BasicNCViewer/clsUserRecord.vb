Imports Abacus.DoublePrecision
Public Class clsUserRecord
    Public ID As String
    Public GraphicsType As UserGraphicsType
    Public DrawColor As Color
    Public stVec As Vector3
    Public endVec As Vector3
    Public ctrVec As Vector3
    Public Rad As Double
    Public ArcSang As Double
    Public ArcEang As Double
    Public ArcPlane As Integer = Motion.XY_PLN
End Class

<Flags>
Public Enum UserGraphicsType
    LINE
    CWARC
    CCARC
    POINT
End Enum