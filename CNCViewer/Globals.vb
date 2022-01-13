Public Module Globals
    <Flags> Public Enum BlockShiftType
        NoShift = 0
        WorkOffset = 2 ^ 0 'Work offsets might include positions
        DatsSetting = 2 ^ 1 'G10 
        LocalSet = 2 ^ 2 'G92
        LocalShift = 2 ^ 3 'G52
        SuspendWorkOffset = 2 ^ 4 'G53
        GoHome = 2 ^ 5 'G28 Might include positions on the way home
        Rotate = 2 ^ 6 'G68
        RotateCancel = 2 ^ 7 'G69
        Scale = 2 ^ 8 'G51
        ScaleCancel = 2 ^ 9 'G50
        Mirror = 2 ^ 10 'G51.1
        MirrorCancel = 2 ^ 11 'G50.1
    End Enum

    Public Enum CornerBreakType
        None
        RadiusCorner
        ChamferCorner
    End Enum

    Public Enum IncAbsMode
        ABS
        INC
    End Enum
    <Flags> Public Enum Motion
        RAPID = 0
        LINE = 1
        CWARC = 2
        CCARC = 3
        HOLE_I = 4
        HOLE_R = 5
        XY_PLN = 6
        XZ_PLN = 7
        YZ_PLN = 8
        NONE = 255
    End Enum

    Public Enum DrillReturn
        RETURN_TO_I_PLN = 0
        RETURN_TO_R_PLN = 1
    End Enum
    Public Enum CutterComp
        OFF
        LEFT
        RIGHT
    End Enum
    Public Enum AlphaChars
        A
        B
        C
        D
        E
        F
        G
        H
        I
        J
        K
        L
        M
        N
        O
        P
        Q
        R
        S
        T
        U
        V
        W
        X
        Y
        Z '25
        ANY
        AXIS_MOVEMENT
        UNKNOWN
    End Enum
    Public Enum ArcData
        X_CTR
        Y_CTR
        Z_CTR
        ARC_RAD
        ANGLE_1
        ANGLE_2
    End Enum
    Public Enum Axees
        X
        Y
        Z
        A
        B
        C
        XX
        YY
        ZZ
        AA
        BB
        CC
        UNKNOWN
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
