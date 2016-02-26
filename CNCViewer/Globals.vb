Public Module Globals
    Public Enum Motion
        RAPID = 0
        XY_PLN = 0
        I_PLN = 0
        LINE = 1
        XZ_PLN = 1
        R_PLN = 1
        CWARC = 2
        YZ_PLN = 2
        CCARC = 3
        HOLE_I = 4
        HOLE_R = 5
    End Enum
    Public Enum MachineType
        LATHEDIA = 0
        LATHERAD = 1
        MILL = 2
    End Enum
    Public Enum MachineUnits
        ENGLISH = 0
        METRIC = 1
    End Enum
    Public Enum Axis
        Z = 0
        Y = 1
        X = 2
    End Enum
    Public Enum RotaryDirection
        CW = 1
        CCW = -1
    End Enum
    Public Enum FeedMode
        UNIT_PER_MIN = 0
        UNIT_PER_REV = 1
    End Enum
    Public Enum SpeedMode
        RPM = 0
        SURFACE_SPEED = 1
    End Enum
    Public Enum RotaryMotionType
        BMC = 0
        CAD = 1
    End Enum

End Module
