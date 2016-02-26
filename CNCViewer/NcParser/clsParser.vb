''' <remarks>
''' Jason Titcomb
''' www.CncEdit.com
''' https://github.com/JasonTitcomb/Basic_CNC_Viewer/blob/master/LICENSE.md
''' </remarks>

Option Strict On
Option Explicit On
Option Compare Text
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

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
    Z
    ANY
    AXIS
End Enum
Public Enum ArcData
    X_CTR
    Y_CTR
    Z_CTR
    ARC_RAD
    ANGLE_1
    ANGLE_2
End Enum

Public Class clsParser
    Private mWorker As System.ComponentModel.BackgroundWorker = Nothing
    Private Const REG_JUNK As String = "\x0A\x0A|\x0D\x0D|[\x00-\x09]|[\x0E-\x1F]|[\x7F-\xFF]"
    Private Const REG_NCWORDS As String = "[A-Z]([-+]?[0-9]*[\.,]?[0-9]*)" '[-+]?[0-9]*[\.,]?[0-9]*
    Private Const STR_EOL As String = "\u000d?\u000a"
    Private Const LETTERS As String = "-ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Friend Const MAX_COLORS As Integer = 31
    Private mColors32(MAX_COLORS) As Integer
    Private mToolNumbers As New List(Of Single)

    Public BlockSkips As New List(Of clsBlockSkip)
    Private mRegSkips As Regex
    Private mWordMatchIndex As Integer
    Private mParseErrorsIndex As Integer
    Private mRegSubs As Regex
    Private mRegWords As Regex
    Private mRegNewLines As Regex
    Private mCommentMatch As String
    Private mArcPlane As Integer
    Private mDrillClear As Single

    Private mInitialZBeforeDrill As Single
    Private mEndmain As String 'M30
    Private mSubcall As String 'M98
    Private mIsSubCall As Boolean

    'Private mCurSub As clsProg
    Private mCurSubIndex As Integer
    Private mRepeatsLabel As Char 'L
    Private mReps As Integer = 1
    Private mCurrentUnits As MachineUnits
    Private mArcRadSigned As Single
    Private mPrevABC, mABC As Single

    Private mGoHomeAddressIndexX As Integer
    Private mGoHomeAddressIndexY As Integer
    Private mGoHomeAddressIndexZ As Integer

    Private mRotDir As Integer
    Private mRotating As Boolean
    Private mComp As CutterComp
    Private mDrillReturnMode As Motion 'G98,G99
    Private mTool As Single
    Private mMode As Motion
    Private mFeedMode As MacGen.FeedMode
    Private mSpeedMode As MacGen.SpeedMode
    Private mSpeed As Single
    Private mMaxRpm As Single
    Private mAbsolute As Boolean
    Private mGoHome As Boolean
    Private mRpmLimit As Boolean
    Private mToolChangeBlock As Boolean
    Private mCodeText As String
    Private mLineNumber As Integer
    Private mTotalBites As Integer
    Private mMotion As New clsMotion
    Private mLatheDiaRadFactor As Single

    Private mCurAddress As Address
    Private mMotionRec As MacGen.clsMotionRecord
    Private mMotionRecs As System.Collections.Generic.List(Of MacGen.clsMotionRecord)
    Public mCurMachine As clsMachine
    Private mRapidRate As Single = 100.0F
    Private Const ONE_RADIAN As Single = Math.PI * 2
    Private Const HALF_RADIAN As Single = Math.PI
    Private Const QUARTER_RADIAN As Single = Math.PI / 2

    Private mBlockHasAddress(27) As Boolean
    Private mRegisters(25) As Single
    Private mLastBlockHadAddress(27) As Boolean
    Private mLastRegisters(25) As Single
    Private mArcData(7) As Single
    Private mArcCenterInversion As Integer = 1
    Private mAxisValuesRaw(6) As Single

    Private mCannedCycles As New List(Of Address)
    Private mCannedCycleFileNames As New Specialized.StringCollection
    Private mCannedCycleFile As String
    Private mCurrentCannedCycleProg As New clsProg
    Private mCannedCycle As Address
    Private mIsCannedCycle As Boolean
    Private mCannedCycleLineNumber As Integer

    Private mCustomAddresses As New List(Of Address)
    Private mMaxX As Single = Single.MinValue
    Private mMaxY As Single = Single.MinValue
    Private mMaxZ As Single = Single.MinValue
    Private mMinX As Single = Single.MaxValue
    Private mMinY As Single = Single.MaxValue
    Private mMinZ As Single = Single.MaxValue

    'add events for motion blocks
    Public Event OnProgStart(ByVal name As String, ByVal line As Integer)
    Public Event OnProgEnd(ByVal name As String, ByVal line As Integer)
    Public Event BeforeMotionRecAdded(ByRef registers() As Single, ByRef arcData() As Single)
    Public Event AfterMotionRecAdded(ByRef registers() As Single, ByRef arcData() As Single)
    Public Event OnCustomAddress(ByVal address As Char, ByVal value As Single, ByRef registers() As Single, ByRef arcData() As Single)
    Public Event OnToolChanged(ByVal tool As Single)
    Public Event OnParseError(ByVal position As Integer, ByVal msg As String)
    Public Event OnProgress(ByVal percent As Integer)


    Private mGegexNcWords As String
    Public Property RegexNcWordsMatch() As String
        Get
            Return mGegexNcWords
        End Get
        Set(ByVal value As String)
            mGegexNcWords = value
        End Set
    End Property


    Private mIgnoreToolColor As Boolean
    Public WriteOnly Property IgnoreToolColor() As Boolean
        Set(ByVal value As Boolean)
            mIgnoreToolColor = value
        End Set
    End Property

    Private mDrawColor As Drawing.Color = Drawing.Color.Blue
    Public Property DrawColor() As Drawing.Color
        Get
            Return mDrawColor
        End Get
        Set(ByVal value As Drawing.Color)
            mDrawColor = value
        End Set
    End Property

    Public ReadOnly Property MaxZ() As Single
        Get
            Return mMaxZ
        End Get
    End Property

    Public ReadOnly Property MinZ() As Single
        Get
            Return mMinZ
        End Get
    End Property

    Private mCurrentColorIndex As Integer = MAX_COLORS
    Public Property CurrentColorIndex() As Integer
        Get
            Return mCurrentColorIndex
        End Get
        Set(ByVal value As Integer)
            mCurrentColorIndex = value
            If Not mIgnoreToolColor Then
                DrawColor = Color32(mCurrentColorIndex)
            End If
        End Set
    End Property

    Public Function GetNextParseError() As clsParseError
        mParseErrorsIndex += 1
        If mParseErrorsIndex > -1 AndAlso mParseErrorsIndex < mParseErrors.Count Then
            Return mParseErrors(mParseErrorsIndex)
        Else
            mParseErrorsIndex = 0
            Return mParseErrors(mParseErrorsIndex)
        End If
    End Function


    Private mParseErrors As New List(Of clsParseError)
    Public ReadOnly Property ParseErrors() As List(Of clsParseError)
        Get
            Return mParseErrors
        End Get
    End Property

    Public ReadOnly Property CodeLine() As String
        Get
            Return mCodeText
        End Get
    End Property

#Region "Singleton"
    Private Shared mInstance As clsParser
    Private Shared SyncLock_LOCK As New Object
    'PRIVATE constructor can only be called from this class
    Private Sub New()
        mColors32(0) = -16777216
        mColors32(1) = -8388608
        mColors32(2) = -16744448
        mColors32(3) = -8355840
        mColors32(4) = -16777088
        mColors32(5) = -8388480
        mColors32(6) = -16744320
        mColors32(7) = -4144960
        mColors32(8) = -8355712
        mColors32(9) = -65536
        mColors32(10) = -16711936
        mColors32(11) = -256
        mColors32(12) = -16776961
        mColors32(13) = -12525360
        mColors32(14) = -65281
        mColors32(15) = -8388608
        mColors32(16) = -16777216
        mColors32(17) = -8388608
        mColors32(18) = -16744448
        mColors32(19) = -8355840
        mColors32(20) = -16777088
        mColors32(21) = -8388480
        mColors32(22) = -16744320
        mColors32(23) = -4144960
        mColors32(24) = -8355712
        mColors32(25) = -65536
        mColors32(26) = -16711936
        mColors32(27) = -256
        mColors32(28) = -16776961
        mColors32(29) = -12525360
        mColors32(30) = -65281
        mColors32(31) = -8388608
    End Sub
    ''' <summary>
    ''' Static method for creating the single instance of the Constructor
    ''' </summary>
    Public Shared Function Instance() As clsParser
        SyncLock SyncLock_LOCK
            ' initialize if not already done
            If mInstance Is Nothing Then
                mInstance = New clsParser
            End If
        End SyncLock
        ' return the initialized instance of the Singleton Class
        Return mInstance
    End Function 'Instance
#End Region

    Private mNcProgs As System.Collections.Generic.List(Of clsProg)
    Public Function IsSubFileUsedByProgram(ByVal fl As String) As Boolean
        If mNcProgs.Count < 2 Then Return False
        For r As Integer = 1 To mNcProgs.Count - 1
            Dim p As clsProg = mNcProgs(r)
            If String.Compare(p.FileName, fl, True) = 0 Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function GetProgIndex(ByVal fl As String, ByVal selStart As Integer) As Integer
        For r As Integer = 0 To mNcProgs.Count - 1
            If String.Compare(mNcProgs(r).FileName, fl, True) = 0 Then
                If selStart >= mNcProgs(r).StartChar AndAlso selStart <= (mNcProgs(r).Contents.Length + mNcProgs(r).StartChar) Then
                    Return r
                End If
            End If
        Next
        Return 0
    End Function

    Private Sub Arc_Center()
        Dim side_opposite As Single
        Dim meanX As Single
        Dim meanY As Single
        Dim centerVector As Single
        Dim quarterArc As Single

        Select Case mArcPlane
            Case Motion.XY_PLN
                'This is for an arc or helix that uses an R insdead of I,J,K,

                If mBlockHasAddress(AlphaChars.R) AndAlso (mMode > Motion.LINE) Then 'Radius move with R
                    quarterArc = Math.PI / 2
                    '|------- Calculate arc center position -------|

                    If mArcRadSigned < 0 Then 'A "-R" is used to specify big arc
                        quarterArc = -quarterArc 'Total angle > 180 deg
                    End If 'Total angle is always <180 if "+R"

                    If mLastRegisters(AlphaChars.X) = mRegisters(AlphaChars.X) AndAlso mLastRegisters(AlphaChars.Y) = mRegisters(AlphaChars.Y) Then 'this is a full arc
                        quarterArc = 0
                    End If

                    mArcData(ArcData.ARC_RAD) = System.Math.Abs(mArcRadSigned)
                    'calculate side opposite 'hypotenuse
                    side_opposite = CSng(System.Math.Abs((mArcData(ArcData.ARC_RAD) ^ 2) - ((VectorLength(mLastRegisters(AlphaChars.X), mLastRegisters(AlphaChars.Y), 0, mRegisters(AlphaChars.X), mRegisters(AlphaChars.Y), 0) / 2) ^ 2)))
                    side_opposite = CSng(System.Math.Sqrt(side_opposite))
                    'find mid point of start and end of arc start and end points
                    meanX = (mLastRegisters(AlphaChars.X) + mRegisters(AlphaChars.X)) / 2
                    meanY = (mLastRegisters(AlphaChars.Y) + mRegisters(AlphaChars.Y)) / 2

                    If mMode = Motion.CCARC Then
                        centerVector = AngleFromPoint(mRegisters(AlphaChars.X) - mLastRegisters(AlphaChars.X), mRegisters(AlphaChars.Y) - mLastRegisters(AlphaChars.Y), False) - quarterArc
                        If centerVector < 0 Then
                            centerVector = ONE_RADIAN + centerVector
                        End If

                    End If

                    If mMode = Motion.CWARC Then
                        centerVector = AngleFromPoint(mRegisters(AlphaChars.X) - mLastRegisters(AlphaChars.X), mRegisters(AlphaChars.Y) - mLastRegisters(AlphaChars.Y), False) + quarterArc
                        If centerVector > ONE_RADIAN Then
                            centerVector = centerVector - ONE_RADIAN
                        End If
                    End If


                    mArcData(ArcData.X_CTR) = CSng(meanX - (side_opposite * System.Math.Cos(centerVector)))
                    mArcData(ArcData.Y_CTR) = CSng(meanY - (side_opposite * System.Math.Sin(centerVector)))

                    'Calculate start and end angle
                    mArcData(ArcData.ANGLE_1) = AngleFromPoint(mLastRegisters(AlphaChars.X) - mArcData(ArcData.X_CTR), mLastRegisters(AlphaChars.Y) - mArcData(ArcData.Y_CTR), False)
                    mArcData(ArcData.ANGLE_2) = AngleFromPoint(mRegisters(AlphaChars.X) - mArcData(ArcData.X_CTR), mRegisters(AlphaChars.Y) - mArcData(ArcData.Y_CTR), False)
                Else

                    If mCurMachine.AbsArcCenter Then
                        mRegisters(AlphaChars.I) = mRegisters(AlphaChars.I) - mLastRegisters(AlphaChars.X)
                        mRegisters(AlphaChars.J) = mRegisters(AlphaChars.J) - mLastRegisters(AlphaChars.Y)
                    End If

                    mRegisters(AlphaChars.I) *= mArcCenterInversion
                    mRegisters(AlphaChars.J) *= mArcCenterInversion

                    mArcData(ArcData.ARC_RAD) = CSng(System.Math.Sqrt(mRegisters(AlphaChars.I) ^ 2 + mRegisters(AlphaChars.J) ^ 2)) 'calculate rad
                    mArcData(ArcData.X_CTR) = mLastRegisters(AlphaChars.X) + mRegisters(AlphaChars.I) 'Arc origins
                    mArcData(ArcData.Y_CTR) = mLastRegisters(AlphaChars.Y) + mRegisters(AlphaChars.J)
                    mArcData(ArcData.Z_CTR) = mLastRegisters(AlphaChars.Z) + mRegisters(AlphaChars.K)
                    mArcData(ArcData.ANGLE_1) = AngleFromPoint(mLastRegisters(AlphaChars.X) - mArcData(ArcData.X_CTR), mLastRegisters(AlphaChars.Y) - mArcData(ArcData.Y_CTR), False)
                    mArcData(ArcData.ANGLE_2) = AngleFromPoint(mRegisters(AlphaChars.X) - mArcData(ArcData.X_CTR), mRegisters(AlphaChars.Y) - mArcData(ArcData.Y_CTR), False)

                End If 'InStr(codeline, "R")

            Case Motion.XZ_PLN
                'This is for an arc or helix that uses an R insdead of I,J,K,

                If mBlockHasAddress(AlphaChars.R) AndAlso mMode > Motion.LINE Then 'Radius move with R
                    quarterArc = Math.PI / 2
                    '|------- Calculate arc center position -------|

                    If mArcRadSigned < 0 Then 'A "-R" is used to specify big arc
                        quarterArc = -quarterArc 'Total angle > 180 deg
                    End If 'Total angle is always <180 if "+R"

                    If mLastRegisters(AlphaChars.X) = mRegisters(AlphaChars.X) AndAlso mLastRegisters(AlphaChars.Z) = mRegisters(AlphaChars.Z) Then 'this is a full arc
                        quarterArc = 0
                    End If

                    mArcData(ArcData.ARC_RAD) = System.Math.Abs(mArcRadSigned)
                    'calculate side opposite 'hypotenuse
                    side_opposite = CSng(System.Math.Abs((mArcData(ArcData.ARC_RAD) ^ 2) - ((VectorLength(mLastRegisters(AlphaChars.X), mLastRegisters(AlphaChars.Z), 0, mRegisters(AlphaChars.X), mRegisters(AlphaChars.Z), 0) / 2) ^ 2)))
                    side_opposite = CSng(System.Math.Sqrt(side_opposite))
                    'find mid point of start and end of arc start and end points
                    meanX = (mLastRegisters(AlphaChars.X) + mRegisters(AlphaChars.X)) / 2
                    meanY = (mLastRegisters(AlphaChars.Z) + mRegisters(AlphaChars.Z)) / 2

                    If mMode = Motion.CCARC Then
                        centerVector = AngleFromPoint(mRegisters(AlphaChars.X) - mLastRegisters(AlphaChars.X), mRegisters(AlphaChars.Z) - mLastRegisters(AlphaChars.Z), False) - quarterArc
                        If centerVector < 0 Then
                            centerVector = ONE_RADIAN + centerVector
                        End If

                    End If

                    If mMode = Motion.CWARC Then
                        centerVector = AngleFromPoint(mRegisters(AlphaChars.X) - mLastRegisters(AlphaChars.X), mRegisters(AlphaChars.Z) - mLastRegisters(AlphaChars.Z), False) + quarterArc
                        If centerVector > ONE_RADIAN Then
                            centerVector = centerVector - ONE_RADIAN
                        End If
                    End If


                    mArcData(ArcData.X_CTR) = CSng(meanX - (side_opposite * System.Math.Cos(centerVector)))
                    mArcData(ArcData.Z_CTR) = CSng(meanY - (side_opposite * System.Math.Sin(centerVector)))

                    'Calculate start and end angle
                    mArcData(ArcData.ANGLE_1) = AngleFromPoint(mLastRegisters(AlphaChars.X) - mArcData(ArcData.X_CTR), mLastRegisters(AlphaChars.Z) - mArcData(ArcData.Z_CTR), False)
                    mArcData(ArcData.ANGLE_2) = AngleFromPoint(mRegisters(AlphaChars.X) - mArcData(ArcData.X_CTR), mRegisters(AlphaChars.Z) - mArcData(ArcData.Z_CTR), False)
                Else

                    If mCurMachine.AbsArcCenter Then
                        mRegisters(AlphaChars.I) = mRegisters(AlphaChars.I) - mLastRegisters(AlphaChars.X)
                        mRegisters(AlphaChars.K) = mRegisters(AlphaChars.K) - mLastRegisters(AlphaChars.Z)
                    End If
                    mRegisters(AlphaChars.I) *= mArcCenterInversion
                    mRegisters(AlphaChars.K) *= mArcCenterInversion


                    mArcData(ArcData.ARC_RAD) = CSng(System.Math.Sqrt(mRegisters(AlphaChars.I) ^ 2 + mRegisters(AlphaChars.K) ^ 2)) 'calculate rad
                    mArcData(ArcData.X_CTR) = mLastRegisters(AlphaChars.X) + mRegisters(AlphaChars.I)
                    mArcData(ArcData.Y_CTR) = mLastRegisters(AlphaChars.Y) + mRegisters(AlphaChars.J) 'Arc origins
                    mArcData(ArcData.Z_CTR) = mLastRegisters(AlphaChars.Z) + mRegisters(AlphaChars.K)

                    mArcData(ArcData.ANGLE_1) = AngleFromPoint(mLastRegisters(AlphaChars.X) - mArcData(ArcData.X_CTR), mLastRegisters(AlphaChars.Z) - mArcData(ArcData.Z_CTR), False)
                    mArcData(ArcData.ANGLE_2) = AngleFromPoint(mRegisters(AlphaChars.X) - mArcData(ArcData.X_CTR), mRegisters(AlphaChars.Z) - mArcData(ArcData.Z_CTR), False)

                End If 'InStr(codeline, "R")

            Case Motion.YZ_PLN
                'This is for an arc or helix that uses an R insdead of I,J,K,

                If mBlockHasAddress(AlphaChars.R) AndAlso mMode > Motion.LINE Then 'Radius move with R
                    quarterArc = Math.PI / 2
                    '|------- Calculate arc center position -------|

                    If mArcRadSigned < 0 Then 'A "-R" is used to specify big arc
                        quarterArc = -quarterArc 'Total angle > 180 deg
                    End If 'Total angle is always <180 if "+R"

                    If mLastRegisters(AlphaChars.Y) = mRegisters(AlphaChars.Y) AndAlso mLastRegisters(AlphaChars.Z) = mRegisters(AlphaChars.Z) Then 'this is a full arc
                        quarterArc = 0
                    End If

                    mArcData(ArcData.ARC_RAD) = System.Math.Abs(mArcRadSigned)
                    'calculate side opposite 'hypotenuse
                    side_opposite = CSng(System.Math.Abs((mArcData(ArcData.ARC_RAD) ^ 2) - ((VectorLength(mLastRegisters(AlphaChars.Y), mLastRegisters(AlphaChars.Z), 0, mRegisters(AlphaChars.Y), mRegisters(AlphaChars.Z), 0) / 2) ^ 2)))
                    side_opposite = CSng(System.Math.Sqrt(side_opposite))
                    'find mid point of start and end of arc start and end points
                    meanX = (mLastRegisters(AlphaChars.Y) + mRegisters(AlphaChars.Y)) / 2
                    meanY = (mLastRegisters(AlphaChars.Z) + mRegisters(AlphaChars.Z)) / 2

                    If mMode = Motion.CCARC Then
                        centerVector = AngleFromPoint(mRegisters(AlphaChars.Y) - mLastRegisters(AlphaChars.Y), mRegisters(AlphaChars.Z) - mLastRegisters(AlphaChars.Z), False) - quarterArc
                        If centerVector < 0 Then
                            centerVector = ONE_RADIAN + centerVector
                        End If

                    End If

                    If mMode = Motion.CWARC Then
                        centerVector = AngleFromPoint(mRegisters(AlphaChars.Y) - mLastRegisters(AlphaChars.Y), mRegisters(AlphaChars.Z) - mLastRegisters(AlphaChars.Z), False) + quarterArc
                        If centerVector > ONE_RADIAN Then
                            centerVector = centerVector - ONE_RADIAN
                        End If
                    End If


                    mArcData(ArcData.Y_CTR) = CSng(meanX - (side_opposite * System.Math.Cos(centerVector)))
                    mArcData(ArcData.Z_CTR) = CSng(meanY - (side_opposite * System.Math.Sin(centerVector)))

                    'Calculate start and end angle
                    mArcData(ArcData.ANGLE_1) = AngleFromPoint(mLastRegisters(AlphaChars.Y) - mArcData(ArcData.Y_CTR), mLastRegisters(AlphaChars.Z) - mArcData(ArcData.Z_CTR), False)
                    mArcData(ArcData.ANGLE_2) = AngleFromPoint(mRegisters(AlphaChars.Y) - mArcData(ArcData.Y_CTR), mRegisters(AlphaChars.Z) - mArcData(ArcData.Z_CTR), False)
                Else

                    If mCurMachine.AbsArcCenter Then
                        mRegisters(AlphaChars.J) = mRegisters(AlphaChars.J) - mLastRegisters(AlphaChars.Y)
                        mRegisters(AlphaChars.K) = mRegisters(AlphaChars.K) - mLastRegisters(AlphaChars.Z)
                    End If
                    mRegisters(AlphaChars.K) *= mArcCenterInversion
                    mRegisters(AlphaChars.J) *= mArcCenterInversion

                    mArcData(ArcData.ARC_RAD) = CSng(System.Math.Sqrt(mRegisters(AlphaChars.J) ^ 2 + mRegisters(AlphaChars.K) ^ 2)) 'calculate rad
                    mArcData(ArcData.X_CTR) = mLastRegisters(AlphaChars.X) + mRegisters(AlphaChars.I)
                    mArcData(ArcData.Y_CTR) = mLastRegisters(AlphaChars.Y) + mRegisters(AlphaChars.J) 'Arc origins
                    mArcData(ArcData.Z_CTR) = mLastRegisters(AlphaChars.Z) + mRegisters(AlphaChars.K)

                    mArcData(ArcData.ANGLE_1) = AngleFromPoint(mLastRegisters(AlphaChars.Y) - mArcData(ArcData.Y_CTR), mLastRegisters(AlphaChars.Z) - mArcData(ArcData.Z_CTR), False)
                    mArcData(ArcData.ANGLE_2) = AngleFromPoint(mRegisters(AlphaChars.Y) - mArcData(ArcData.Y_CTR), mRegisters(AlphaChars.Z) - mArcData(ArcData.Z_CTR), False)

                End If 'InStr(codeline, "R")

        End Select

    End Sub

    Private Function Normalize(x As Single, y As Single) As Drawing.PointF
        Dim length As Single
        ' Calculate the length of the vector		
        length = CSng(1.0F / Math.Sqrt((x * x) + (y * y)))
        'Dividing each element by the length will result in a
        'unit normal vector.
        Return New Drawing.PointF(x * length, y * length)
    End Function

    Private Function Distance3(ByVal X1 As Single, ByVal Y1 As Single, ByVal Z1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal Z2 As Single) As Single
        Return CSng(System.Math.Sqrt(((X1 - x2) ^ 2) + ((Y1 - y2) ^ 2) + ((Z1 - Z2) ^ 2)))
    End Function

    Private Function CrossProd(p1 As Drawing.PointF, p2 As Drawing.PointF) As Single
        Return (p1.X * p2.Y) - (p1.Y * p2.X)
    End Function

    'Create the graphics record here
    'Block with X and C,R and no Z is a candidate for break corner
    Private Sub AddCornerRecord(ByVal lnPos As Integer)
        Dim arcmode As Boolean = False
        Dim arcInfo(7) As Single
        Dim I As Single = 0
        Dim J As Single = 0
        Dim K As Single = 0
        Dim arcOrChamferEnd_XYZ(2) As Single
        Dim offsetRadOrChamfer As Single = 0
        Dim mode As Motion = Motion.LINE
        Dim cornerRecord As clsMotionRecord
        Dim nv1 As Drawing.PointF
        Dim nv2 As Drawing.PointF
        Dim arcDirDotProd As Single
        Dim cornerErr As String
        Dim len1, len2 As Single
        'Use either C or IJK
        'IJK must match XYZ
        'Must not be too large
        'R only does radius


        'If the last line had an R or C 
        If mLastBlockHadAddress(AlphaChars.C) Then
            offsetRadOrChamfer = Math.Abs(AdjustForUnits(mLastRegisters(AlphaChars.C)))
        ElseIf mLastBlockHadAddress(AlphaChars.R) Then
            offsetRadOrChamfer = Math.Abs(AdjustForUnits(mLastRegisters(AlphaChars.R)))
            arcmode = offsetRadOrChamfer > 0
        Else
            'IJK chamfer KX IZ
            If mLastBlockHadAddress(AlphaChars.I) Then
                I = Math.Abs(AdjustForUnits(mLastRegisters(AlphaChars.I)))
            ElseIf mLastBlockHadAddress(AlphaChars.J) Then
                J = Math.Abs(AdjustForUnits(mLastRegisters(AlphaChars.J)))
            ElseIf mLastBlockHadAddress(AlphaChars.K) Then
                K = Math.Abs(AdjustForUnits(mLastRegisters(AlphaChars.K)))
            Else
                Return
            End If
        End If

        len1 = Distance3(mMotionRec.Xold, mMotionRec.Yold, mMotionRec.Zold, mMotionRec.Xpos, mMotionRec.Ypos, mMotionRec.Zpos)
        len2 = Distance3(mLastRegisters(AlphaChars.X),
                         mLastRegisters(AlphaChars.Y),
                         mLastRegisters(AlphaChars.Z),
                         mRegisters(AlphaChars.X),
                         mRegisters(AlphaChars.Y),
                         mRegisters(AlphaChars.Z))

        If len1 <= Math.Abs(offsetRadOrChamfer) Or len2 <= Math.Abs(offsetRadOrChamfer) Then
            cornerErr = "Corner break too large"
            mParseErrors.Add(New clsParseError(mWordMatchIndex, mLineNumber, cornerErr))
            RaiseEvent OnParseError(mLineNumber, cornerErr)
            Return
        End If


        Select Case mArcPlane
            Case Motion.XY_PLN
                'Using X and Y because we are on the XY plane
                nv1 = Normalize(mMotionRec.Xpos - mMotionRec.Xold, mMotionRec.Ypos - mMotionRec.Yold)
                nv2 = Normalize(mRegisters(AlphaChars.X) - mLastRegisters(AlphaChars.X), mRegisters(AlphaChars.Y) - mLastRegisters(AlphaChars.Y))

                arcDirDotProd = CrossProd(nv1, nv2) 'This must be either -1 or +1

                If arcmode Then
                    mode = If(arcDirDotProd = -1, Motion.CWARC, Motion.CCARC)
                End If

                If Math.Abs(arcDirDotProd) <> 1 Then
                    cornerErr = "Axis moves not aligned"
                    mParseErrors.Add(New clsParseError(mWordMatchIndex, mLineNumber, cornerErr))
                    RaiseEvent OnParseError(mLineNumber, cornerErr)
                    Return
                End If

                Select Case nv2.X
                    Case -1
                        arcInfo(ArcData.ANGLE_1) = 0
                    Case +1
                        arcInfo(ArcData.ANGLE_1) = HALF_RADIAN '180
                    Case 0
                        Select Case nv2.Y
                            Case -1
                                arcInfo(ArcData.ANGLE_1) = QUARTER_RADIAN '90
                            Case +1
                                arcInfo(ArcData.ANGLE_1) = HALF_RADIAN + QUARTER_RADIAN '270
                        End Select
                End Select
                arcInfo(ArcData.ANGLE_2) = arcInfo(ArcData.ANGLE_1) + (QUARTER_RADIAN * arcDirDotProd)

                'At this point we have read the next line.
                'In this case it is a Z move.
                'We need to determine new end points
                'Determine arc center.
                'And alter the last record by the amount of the rad

                Select Case nv1.X
                    Case +1, -1 'Moving in X and then Y
                        offsetRadOrChamfer = If(offsetRadOrChamfer <> 0, offsetRadOrChamfer, J)
                        arcOrChamferEnd_XYZ(0) = mMotionRec.Xpos 'original X
                        mMotionRec.Xpos -= (offsetRadOrChamfer * nv1.X)
                        arcOrChamferEnd_XYZ(1) = mLastRegisters(AlphaChars.Y) + (offsetRadOrChamfer * nv2.Y)
                        'Adjust the last y for the next line
                        mLastRegisters(AlphaChars.Y) = arcOrChamferEnd_XYZ(1)

                        arcInfo(ArcData.X_CTR) = mMotionRec.Xpos 'modified X
                        arcInfo(ArcData.Y_CTR) = arcOrChamferEnd_XYZ(1)
                    Case 0 'Moving in Y then X
                        offsetRadOrChamfer = If(offsetRadOrChamfer <> 0, offsetRadOrChamfer, I)
                        'arc will end at original Y
                        arcOrChamferEnd_XYZ(1) = mMotionRec.Ypos
                        'the old Y is modified by the radius value
                        mMotionRec.Ypos -= (offsetRadOrChamfer * nv1.Y)
                        'this is the new arc end in the other axis[x] adjusted by the radius
                        arcOrChamferEnd_XYZ(0) = mLastRegisters(AlphaChars.X) + (offsetRadOrChamfer * nv2.X)
                        'Adjust the last X for the next line
                        mLastRegisters(AlphaChars.X) = arcOrChamferEnd_XYZ(0)

                        arcInfo(ArcData.Y_CTR) = mMotionRec.Ypos 'modified y
                        arcInfo(ArcData.X_CTR) = arcOrChamferEnd_XYZ(0)
                End Select
            Case Motion.XZ_PLN 'lathe
                'Using X and Z because we are on the XZ plane
                nv1 = Normalize(mMotionRec.Zpos - mMotionRec.Zold, mMotionRec.Xpos - mMotionRec.Xold)
                nv2 = Normalize(mRegisters(AlphaChars.Z) - mLastRegisters(AlphaChars.Z), mRegisters(AlphaChars.X) - mLastRegisters(AlphaChars.X))

                arcDirDotProd = CrossProd(nv1, nv2) 'This must be either -1 or +1
                If arcmode Then
                    mode = If(arcDirDotProd = 1, Motion.CWARC, Motion.CCARC)
                End If
                If Math.Abs(arcDirDotProd) <> 1 Then
                    cornerErr = "Axis moves not aligned"
                    mParseErrors.Add(New clsParseError(mWordMatchIndex, mLineNumber, cornerErr))
                    RaiseEvent OnParseError(mLineNumber, cornerErr)
                    Return
                End If

                Select Case nv2.X
                    Case -1
                        arcInfo(ArcData.ANGLE_1) = QUARTER_RADIAN '90
                    Case +1
                        arcInfo(ArcData.ANGLE_1) = HALF_RADIAN + QUARTER_RADIAN '270
                    Case 0
                        Select Case nv2.Y
                            Case -1
                                arcInfo(ArcData.ANGLE_1) = 0
                            Case +1
                                arcInfo(ArcData.ANGLE_1) = HALF_RADIAN '180
                        End Select
                End Select
                arcInfo(ArcData.ANGLE_2) = arcInfo(ArcData.ANGLE_1) + (QUARTER_RADIAN * arcDirDotProd)

                'At this point we have read the next line.
                'In this case it is a Z move.
                'We need to determine new end points
                'Determine arc center.
                'And alter the last record by the amount of the rad

                Select Case nv1.Y'X->Z move
                    Case +1, -1
                        offsetRadOrChamfer = If(offsetRadOrChamfer <> 0, offsetRadOrChamfer, K)

                        arcOrChamferEnd_XYZ(0) = mMotionRec.Xpos 'original X
                        mMotionRec.Xpos -= (offsetRadOrChamfer * nv1.Y)
                        arcOrChamferEnd_XYZ(2) = mLastRegisters(AlphaChars.Z) + (offsetRadOrChamfer * nv2.X)
                        'Adjust the last Z for the next line
                        mLastRegisters(AlphaChars.Z) = arcOrChamferEnd_XYZ(2)

                        arcInfo(ArcData.X_CTR) = mMotionRec.Xpos 'modified X
                        arcInfo(ArcData.Z_CTR) = arcOrChamferEnd_XYZ(2)
                    Case 0 'Z->X move
                        offsetRadOrChamfer = If(offsetRadOrChamfer <> 0, offsetRadOrChamfer, I)
                        'arc will end at original z
                        arcOrChamferEnd_XYZ(2) = mMotionRec.Zpos
                        'the old z is modified by the radius value
                        mMotionRec.Zpos -= (offsetRadOrChamfer * nv1.X)
                        'this is the new arc end in the other axis[x] adjusted by the radius
                        arcOrChamferEnd_XYZ(0) = mLastRegisters(AlphaChars.X) + (offsetRadOrChamfer * nv2.Y)
                        'Adjust the last X for the next line
                        mLastRegisters(AlphaChars.X) = arcOrChamferEnd_XYZ(0)

                        arcInfo(ArcData.Z_CTR) = mMotionRec.Zpos 'modified Z
                        arcInfo(ArcData.X_CTR) = arcOrChamferEnd_XYZ(0)
                End Select

            Case Motion.YZ_PLN
                Return
        End Select

        If offsetRadOrChamfer = 0 Then
            cornerErr = "Zero size corner. Check I J K R C values"
            mParseErrors.Add(New clsParseError(mWordMatchIndex, mLineNumber, cornerErr))
            RaiseEvent OnParseError(mLineNumber, cornerErr)
            Return
        End If


        cornerRecord = New clsMotionRecord
        With cornerRecord
            .Units = mCurrentUnits
            .ProgIndex = mCurSubIndex
            .Linenumber = lnPos - 1
            .ArcPlane = mArcPlane
            .Tool = mTool 'mRegisters(AlphaChars.T)
            .DrawColor = DrawColor

            .Codestring = mMotionRec.Codestring
            .MotionType = mode

            .Rpoint = 0
            .DrillClear = mDrillClear

            .Rad = offsetRadOrChamfer

            .Xold = mMotionRec.Xpos 'last x
            .Xpos = arcOrChamferEnd_XYZ(0)
            .Xcentr = arcInfo(ArcData.X_CTR) + mCurMachine.ViewShift(0)

            .Yold = mMotionRec.Ypos
            .Ypos = arcOrChamferEnd_XYZ(1)
            .Ycentr = arcInfo(ArcData.Y_CTR) + mCurMachine.ViewShift(1)

            .Zold = mMotionRec.Zpos
            .Zpos = arcOrChamferEnd_XYZ(2)
            .Zcentr = arcInfo(ArcData.Z_CTR) + mCurMachine.ViewShift(2)

            .Sang = arcInfo(ArcData.ANGLE_1)
            .Eang = arcInfo(ArcData.ANGLE_2)

            .Comp = mComp
            .Speed = mMotionRec.Speed
            .SpeedMode = mSpeedMode
            .MaxRpm = mMotionRec.MaxRpm

            .RapidRate = mCurMachine.RapidRate
            If mode = Motion.RAPID Then
                .FeedMode = FeedMode.UNIT_PER_MIN
            Else
                .FeedRate = mRegisters(AlphaChars.F)
                .FeedMode = mFeedMode
            End If

        End With
        mMotionRecs.Add(cornerRecord)

    End Sub


    Private Sub AddMotionRecord(ByVal lnPos As Integer)
        RaiseEvent BeforeMotionRecAdded(mRegisters, mArcData)
        mMotionRec = New clsMotionRecord
        If mMode = Motion.HOLE_I Then
            mDrillClear = mInitialZBeforeDrill
        End If
        If mMode = Motion.HOLE_R Then
            mDrillClear = mRegisters(AlphaChars.R)
        End If
        With mMotionRec
            .Units = mCurrentUnits
            .ProgIndex = mCurSubIndex
            .Linenumber = lnPos
            .ArcPlane = mArcPlane
            .Tool = mTool 'mRegisters(AlphaChars.T)
            .DrawColor = DrawColor

            .Codestring = mCodeText

            If mBlockHasAddress(AlphaChars.AXIS) Then
                .MotionType = mMode
            Else
                .MotionType = Motion.RAPID
            End If

            .Rpoint = mRegisters(AlphaChars.R) + mCurMachine.ViewShift(2)
            .DrillClear = mDrillClear
            .Rad = mArcData(ArcData.ARC_RAD)

            .Xold = mLastRegisters(AlphaChars.X) + mCurMachine.ViewShift(0)
            .Xpos = mRegisters(AlphaChars.X) + mCurMachine.ViewShift(0)
            .Xcentr = mArcData(ArcData.X_CTR) + mCurMachine.ViewShift(0)

            .Yold = mLastRegisters(AlphaChars.Y) + mCurMachine.ViewShift(1)
            .Ypos = mRegisters(AlphaChars.Y) + mCurMachine.ViewShift(1)
            .Ycentr = mArcData(ArcData.Y_CTR) + mCurMachine.ViewShift(1)

            .Zold = mLastRegisters(AlphaChars.Z) + mCurMachine.ViewShift(2)
            .Zpos = mRegisters(AlphaChars.Z) + mCurMachine.ViewShift(2)
            .Zcentr = mArcData(ArcData.Z_CTR) + mCurMachine.ViewShift(2)

            .Rotate = mRotating
            .NewRotaryPos = mABC
            .OldRotaryPos = mPrevABC
            .RotaryDir = mRotDir ' * mcurmachine.nRotaryDir
            .Comp = mComp

            .Speed = Math.Min(mSpeed, mMaxRpm)
            .SpeedMode = mSpeedMode
            If mMaxRpm > 0 Then
                .MaxRpm = mMaxRpm
            Else
                .MaxRpm = 5000
            End If

            .RapidRate = mCurMachine.RapidRate
            If mMode = Motion.RAPID Then
                '.FeedRate = mRapidRate
                .FeedMode = FeedMode.UNIT_PER_MIN
            Else
                .FeedRate = mRegisters(AlphaChars.F)
                .FeedMode = mFeedMode
            End If

            .Sang = mArcData(ArcData.ANGLE_1)
            .Eang = mArcData(ArcData.ANGLE_2)

            mMaxX = Math.Max(.Xpos, mMaxX)
            mMaxY = Math.Max(.Ypos, mMaxY)
            mMaxZ = Math.Max(.Zpos, mMaxZ)
            mMinX = Math.Min(.Xpos, mMinX)
            mMinY = Math.Min(.Ypos, mMinY)
            mMinZ = Math.Min(.Zpos, mMinZ)
        End With
        mMotionRecs.Add(mMotionRec)
        RaiseEvent AfterMotionRecAdded(mRegisters, mArcData)

    End Sub

    Private Function TrySingleParse(ByVal s As String) As Single
        Dim ret As Single = 0
        Single.TryParse(s, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, ret)
        Return ret
    End Function

    Private Function SingleParse(ByVal s As String, Optional ByVal precision As Integer = 0) As Single
        If s.Contains(".") Then 'decimal place
            Return Single.Parse(s, System.Globalization.NumberFormatInfo.InvariantInfo)
        Else
            Return CSng(Integer.Parse(s, System.Globalization.NumberFormatInfo.InvariantInfo) * (10 ^ -precision)) 'convert a number from a 4 place
        End If
    End Function

    Public Sub ProcessFile(ByVal ncFile As String, ByVal gfxRecs As List(Of clsMotionRecord), ByVal prgs As System.Collections.Generic.List(Of clsProg))
        Dim sFileContents As String
        mNcProgs = prgs
        Using MyReader As New IO.StreamReader(ncFile)
            sFileContents = Me.FilterJunk(MyReader.ReadToEnd())
        End Using
        ProcessText(ncFile, sFileContents, gfxRecs, mNcProgs)
    End Sub

    Public Sub ProcessText(ByVal sFileName As String, ByVal sFileContents As String, ByVal gfxRecs As List(Of clsMotionRecord), ByVal prgs As System.Collections.Generic.List(Of clsProg), Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing)
        mNcProgs = prgs
        mWorker = worker
        mMotionRecs = gfxRecs
        mParseErrors.Clear()
        mParseErrorsIndex = -1
        mToolNumbers.Clear()
        With mMotion
            .UnitsEnglish.Label = mCurMachine.UnitsEnglishAddress.Chars(0)
            .UnitsEnglish.Value = TrySingleParse(mCurMachine.UnitsEnglishAddress.Substring(1))

            .UnitsMetric.Label = mCurMachine.UnitsMetricAddress.Chars(0)
            .UnitsMetric.Value = TrySingleParse(mCurMachine.UnitsMetricAddress.Substring(1))

            .FeedModeMin.Label = mCurMachine.FeedModeMin.Chars(0)
            .FeedModeMin.Value = TrySingleParse(mCurMachine.FeedModeMin.Substring(1))
            .FeedModeRev.Label = mCurMachine.FeedModeRev.Chars(0)
            .FeedModeRev.Value = TrySingleParse(mCurMachine.FeedModeRev.Substring(1))

            .SpeedModeRPM.Label = mCurMachine.SpeedModeRPM.Chars(0)
            .SpeedModeRPM.Value = TrySingleParse(mCurMachine.SpeedModeRPM.Substring(1))
            .SpeedModeSFPM.Label = mCurMachine.SpeedModeSFM.Chars(0)
            .SpeedModeSFPM.Value = TrySingleParse(mCurMachine.SpeedModeSFM.Substring(1))

            .SpeedLimit.Label = mCurMachine.MaxRpmAddress.Chars(0)
            .SpeedLimit.Value = TrySingleParse(mCurMachine.MaxRpmAddress.Substring(1))

            .SubCall.Label = mCurMachine.Subcall.Chars(0)
            .SubCall.Value = TrySingleParse(mCurMachine.Subcall.Substring(1))

            .SubReturn.Label = mCurMachine.SubReturn.Chars(0)
            .SubReturn.Value = TrySingleParse(mCurMachine.SubReturn.Substring(1))

            .Abs.Label = mCurMachine.Absolute.Chars(0)
            .Abs.Value = TrySingleParse(mCurMachine.Absolute.Substring(1))
            .CCArc.Label = mCurMachine.CCArc.Chars(0)
            .CCArc.Value = TrySingleParse(mCurMachine.CCArc.Substring(1))
            .CWArc.Label = mCurMachine.CWArc.Chars(0)
            .CWArc.Value = TrySingleParse(mCurMachine.CWArc.Substring(1))

            .Inc.Label = mCurMachine.Incremental.Chars(0)
            .Inc.Value = TrySingleParse(mCurMachine.Incremental.Substring(1))

            .CompLeft.Label = mCurMachine.CompLeft.Chars(0)
            .CompLeft.Value = TrySingleParse(mCurMachine.CompLeft.Substring(1))

            .CompRight.Label = mCurMachine.CompRight.Chars(0)
            .CompRight.Value = TrySingleParse(mCurMachine.CompRight.Substring(1))

            .CompCancel.Label = mCurMachine.CompCancel.Chars(0)
            .CompCancel.Value = TrySingleParse(mCurMachine.CompCancel.Substring(1))

            .Linear.Label = mCurMachine.Linear.Chars(0)
            .Linear.Value = TrySingleParse(mCurMachine.Linear.Substring(1))

            .Rapid.Label = mCurMachine.Rapid.Chars(0)
            .Rapid.Value = TrySingleParse(mCurMachine.Rapid.Substring(1))

            .Rotary.Label = mCurMachine.Rotary.Chars(0)
            .Rotary.Value = 0

            .DrillRapid.Label = mCurMachine.DrillRapid.Chars(0)
            .DrillRapid.Value = 0

            .Plane(0).Label = mCurMachine.XYplane.Chars(0)
            .Plane(0).Value = TrySingleParse(mCurMachine.XYplane.Substring(1))
            .Plane(1).Label = mCurMachine.XZplane.Chars(0)
            .Plane(1).Value = TrySingleParse(mCurMachine.XZplane.Substring(1))
            .Plane(2).Label = mCurMachine.YZplane.Chars(0)
            .Plane(2).Value = TrySingleParse(mCurMachine.YZplane.Substring(1))

            .ReturnLevel(0).Label = mCurMachine.ReturnLevel(0).Chars(0)
            .ReturnLevel(0).Value = TrySingleParse(mCurMachine.ReturnLevel(0).Substring(1))
            .ReturnLevel(1).Label = mCurMachine.ReturnLevel(1).Chars(0)
            .ReturnLevel(1).Value = TrySingleParse(mCurMachine.ReturnLevel(1).Substring(1))

            .ToolChange.Label = mCurMachine.ToolChange.Chars(0)
            .ToolChange.Value = TrySingleParse(mCurMachine.ToolChange.Substring(1))

            .GoHome.Label = mCurMachine.HomeCommand.Chars(0)
            .GoHome.Value = TrySingleParse(mCurMachine.HomeCommand.Substring(1))


            For r As Integer = 0 To .Drills.Length - 1
                If mCurMachine.Drills(r).Length > 2 Then
                    .Drills(r).Label = mCurMachine.Drills(r).Chars(0)
                    .Drills(r).Value = TrySingleParse(mCurMachine.Drills(r).Substring(1))
                End If
            Next
        End With

        mCurrentUnits = mCurMachine.MachineUnits

        'Reset all positions.
        mMotionRecs.Clear()
        CurrentColorIndex = MAX_COLORS
        mTool = 0

        mRegisters(AlphaChars.T) = 0
        mArcData(ArcData.ARC_RAD) = 0
        mArcData(ArcData.X_CTR) = 0 'Arc origins
        mArcData(ArcData.Y_CTR) = 0
        mArcData(ArcData.Z_CTR) = 0
        mArcData(ArcData.ANGLE_1) = 0
        mArcData(ArcData.ANGLE_2) = 0


        mRegisters(AlphaChars.U) = 0
        mRegisters(AlphaChars.V) = 0
        mRegisters(AlphaChars.W) = 0

        mLastRegisters(AlphaChars.X) = mCurMachine.HomeValues(0)
        mLastRegisters(AlphaChars.Y) = mCurMachine.HomeValues(1)
        mLastRegisters(AlphaChars.Z) = mCurMachine.HomeValues(2)

        mRegisters(AlphaChars.X) = mLastRegisters(AlphaChars.X)
        mRegisters(AlphaChars.Y) = mLastRegisters(AlphaChars.Y)
        mRegisters(AlphaChars.Z) = mLastRegisters(AlphaChars.Z)

        mPrevABC = 0
        mABC = 0
        mRegisters(AlphaChars.R) = 0
        mRegisters(AlphaChars.S) = 0
        mDrillClear = 0
        mInitialZBeforeDrill = 0
        mRotDir = 1
        mAbsolute = True
        mGoHome = False
        mRpmLimit = False
        mMaxRpm = mCurMachine.MaxRpmValue
        mToolChangeBlock = False
        mMode = Motion.RAPID
        mRapidRate = mCurMachine.RapidRate

        'Get the addresses specified in the settings
        mGoHomeAddressIndexX = Text.Encoding.ASCII.GetBytes(mCurMachine.HomeAddresses(0).Chars(0))(0) - 65
        mGoHomeAddressIndexY = Text.Encoding.ASCII.GetBytes(mCurMachine.HomeAddresses(1).Chars(0))(0) - 65
        mGoHomeAddressIndexZ = Text.Encoding.ASCII.GetBytes(mCurMachine.HomeAddresses(2).Chars(0))(0) - 65

        mSpeedMode = SpeedMode.RPM
        Select Case mCurMachine.MachineType
            Case MachineType.LATHEDIA, MachineType.LATHERAD
                mFeedMode = FeedMode.UNIT_PER_REV
            Case MachineType.MILL
                mFeedMode = FeedMode.UNIT_PER_MIN
        End Select

        mComp = CutterComp.OFF
        mRegisters(AlphaChars.F) = 0

        mDrillReturnMode = Motion.I_PLN

        If mCurMachine.MachineType = MachineType.MILL Then
            mArcPlane = Motion.XY_PLN 'Mill
        Else
            mArcPlane = Motion.XZ_PLN 'Lathe
        End If

        If mCurMachine.MachineType = MachineType.LATHEDIA Then
            mLatheDiaRadFactor = 2.0F
        Else
            mLatheDiaRadFactor = 1.0F
        End If

        mEndmain = mCurMachine.Endmain.Trim
        mSubcall = mCurMachine.Subcall.Trim
        mRepeatsLabel = mCurMachine.SubRepeats.Trim.ToCharArray()(0)

        If mCurMachine.InvertArcCenterValues Then
            mArcCenterInversion = -1
        Else
            mArcCenterInversion = 1
        End If
        mMaxX = Single.MinValue
        mMaxY = Single.MinValue
        mMaxZ = Single.MinValue
        mMinX = Single.MaxValue
        mMinY = Single.MaxValue
        mMinZ = Single.MaxValue


        'Do global replacements
        DoGlobalReplacements(sFileContents)

        mNcProgs.Clear()
        Dim retprog As clsProg = CreateNcProgs(sFileContents, sFileName)
        mLineNumber = 1
        mTotalBites = 0

        'We ignore tool color when we are comparing
        If Not mIgnoreToolColor Then
            DrawColor = Drawing.Color.Blue
        End If
        mCannedCycle.Value = -1
        mCurSubIndex = mNcProgs.IndexOf(retprog)
        ProcessSub(retprog)
        'Now process any remaining un-called subs
        For Each p As clsProg In mNcProgs
            If p.TimesCalled = 0 Then
                mCurSubIndex = mNcProgs.IndexOf(p)
                ProcessSub(p)
            End If
        Next
        'AdjustMaxScale()
    End Sub

    'Private mMaxAxis As Single
    'Public ReadOnly Property MaxAxis() As Single
    '    Get
    '        Return mMaxAxis
    '    End Get
    'End Property

    'Private Sub AdjustMaxScale()
    '    Const maxVal As Single = 5000

    '    If mMaxX > maxVal Or mMaxY > maxVal Or mMaxZ > maxVal Or mMinX < -maxVal Or mMinY < -maxVal Or mMinZ < -maxVal Then

    '        mMaxAxis = Math.Max(Math.Abs(mMaxX), mMaxAxis)
    '        mMaxAxis = Math.Max(Math.Abs(mMaxY), mMaxAxis)
    '        mMaxAxis = Math.Max(Math.Abs(mMaxZ), mMaxAxis)

    '        mMaxAxis = Math.Max(Math.Abs(mMinX), mMaxAxis)
    '        mMaxAxis = Math.Max(Math.Abs(mMinY), mMaxAxis)
    '        mMaxAxis = Math.Max(Math.Abs(mMinZ), mMaxAxis)

    '        'mScalePerfFactor = CSng(1.0F / Math.Floor(mMaxAxis / (maxVal / 2)))
    '        'For Each m As clsMotionRecord In mMotionRecs
    '        '    With m
    '        '        .Rad *= mScalePerfFactor
    '        '        .Rpoint *= mScalePerfFactor
    '        '        .Xcentr *= mScalePerfFactor
    '        '        .Xold *= mScalePerfFactor
    '        '        .Xpos *= mScalePerfFactor
    '        '        .Ycentr *= mScalePerfFactor
    '        '        .Yold *= mScalePerfFactor
    '        '        .Ypos *= mScalePerfFactor
    '        '        .Zcentr *= mScalePerfFactor
    '        '        .Zold *= mScalePerfFactor
    '        '        .Zpos *= mScalePerfFactor
    '        '    End With
    '        'Next

    '    End If
    'End Sub


    Private Function CreateNcProgs(ByVal sFileContents As String, ByVal sFileName As String) As clsProg
        Dim lastIndex As Integer = -1
        Dim thisIndex As Integer = -1
        Dim p As clsProg
        Dim retProg As clsProg = Nothing

        For Each m As Match In Me.mRegSubs.Matches(sFileContents)
            If m.Length = 0 Then Continue For
            If mCurMachine.ProgramId.Contains(m.Value(0)) Then
                thisIndex = m.Index
                'Each program
                If lastIndex > -1 Then
                    mNcProgs(mNcProgs.Count - 1).Contents = sFileContents.Substring(lastIndex, thisIndex - lastIndex).TrimEnd

                    If mNcProgs(mNcProgs.Count - 1).Contents.Contains(mCurMachine.Endmain) Then
                        mNcProgs(mNcProgs.Count - 1).Main = True
                        retProg = mNcProgs(mNcProgs.Count - 1)
                    End If

                End If
                p = New clsProg
                p.Main = False
                p.Index = thisIndex
                p.Label = [Char].ToUpper(m.Value(0))
                p.Value = SingleParse(m.Groups(1).Value)
                p.StartChar = m.Index
                p.StartLine = mRegNewLines.Matches(sFileContents.Substring(0, thisIndex)).Count
                p.FileName = sFileName
                mNcProgs.Add(p)
                lastIndex = m.Index
            End If
        Next

        If mNcProgs.Count = 0 Then
            'Just add all the text we found in the file
            p = New clsProg
            p.Main = True
            p.Index = 0
            p.Label = "MAIN"
            p.Value = 0.0F
            p.Contents = sFileContents
            p.FileName = sFileName
            p.StartLine = 0
            p.StartChar = 0
            mNcProgs.Add(p)
            retProg = p
        Else
            mNcProgs(mNcProgs.Count - 1).Contents = sFileContents.Substring(lastIndex).TrimEnd
            If mNcProgs(mNcProgs.Count - 1).Contents.Contains(mCurMachine.Endmain) Then
                mNcProgs(mNcProgs.Count - 1).Main = True
                retProg = mNcProgs(mNcProgs.Count - 1)
            Else
                retProg = mNcProgs(0)
            End If
        End If
        Return retProg

    End Function

    Private Sub DoGlobalReplacements(ByRef sFileContents As String)
        Dim parts() As String = {"", ""}
        If mCurMachine.GlobalReplacements IsNot Nothing Then
            If mCurMachine.GlobalReplacements.Contains(vbTab) Then
                Dim replacements() As String = mCurMachine.GlobalReplacements.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
                For Each replacement As String In replacements
                    If replacement.Contains(vbTab) Then
                        replacement.Split(vbTab.ToCharArray, StringSplitOptions.RemoveEmptyEntries).CopyTo(parts, 0)
                        sFileContents = Regex.Replace(sFileContents, parts(0), parts(1), RegexOptions.Multiline)
                    End If
                Next
            End If
        End If
    End Sub

    Private Function FindSubByValue(ByVal curProg As clsProg, ByVal val As Single) As clsProg
        For Each p As clsProg In mNcProgs
            If p.Value = val Then Return p
        Next

        If curProg Is Nothing Then Return Nothing
        'If we get here then we should look for an external sub
        Dim fldr As String = IO.Path.GetDirectoryName(curProg.FileName)
        Dim ext As String = IO.Path.GetExtension(curProg.FileName)
        Dim fl As String

        Dim fls() As String = IO.Directory.GetFiles(fldr, val.ToString() & ".*", IO.SearchOption.TopDirectoryOnly)
        If fls.Length > 0 Then
            fl = fls(0)
            If IO.File.Exists(fl) Then
                CreateNcProgs(IO.File.ReadAllText(fl), fl)
            End If

            For Each p As clsProg In mNcProgs
                If p.Value = val Then Return p
            Next
        End If
        Return Nothing
    End Function

    Private Sub ProcessSub(ByVal p As clsProg)
        Static percent As Integer = 0
        Dim blockSkipped As Boolean = False
        Dim ncWord As Match
        Dim progress As Integer = 0
        Try

            'mCurSubIndex = mNcProgs.IndexOf(p)

            Dim contents As String = p.Contents
            Dim lnPos As Integer = p.StartLine
            mLineNumber = p.StartLine + 1
            mTotalBites += p.Contents.Length

            p.TimesCalled += 1
            Dim lastIndex As Integer = 0

            RaiseEvent OnProgStart(p.Label & p.Value.ToString, lnPos)
            ncWord = mRegWords.Match(contents)

            While ncWord.Success

                If Not mWorker Is Nothing Then
                    If mWorker.CancellationPending Then
                        Return
                    End If
                End If

                mWordMatchIndex = ncWord.Index
                If ncWord.Value.EndsWith(vbLf) Then 'Is this a newline
                    mLineNumber += 1
                    mCodeText = contents.Substring(lastIndex, ncWord.Index - lastIndex).Trim
                    '--------------------
                    EvaluateBlock(blockSkipped, lnPos, p)

                    lastIndex = ncWord.Index + 1

                    If mTotalBites > 0 Then
                        If progress <> percent AndAlso percent Mod 10 = 0 Then
                            progress = percent
                            If mWorker IsNot Nothing Then
                                If mWorker.WorkerReportsProgress Then
                                    mWorker.ReportProgress(percent)
                                End If
                            Else
                                RaiseEvent OnProgress(percent)
                            End If
                        End If
                        percent = CInt((ncWord.Index / mTotalBites) * 100)
                    End If

                ElseIf MatchIsComment(ncWord) Then
                    'Comment
                    lnPos += mRegNewLines.Matches(ncWord.Value).Count
                ElseIf mCurMachine.BlockSkip.Contains(ncWord.Value.Chars(0)) Then
                    'Blockskip no longer matches the entire line.
                    'lnPos += 1
                    For Each s As clsBlockSkip In BlockSkips
                        If s.Enabled Then
                            If String.Compare(s.Match, ncWord.Value) = 0 Then
                                blockSkipped = True
                                Exit For
                            End If
                        End If
                    Next
                Else
                    'Word
                    If Not blockSkipped Then
                        Try
                            'Debug.Assert(ncWord.Groups(1).Value.Length > 0, "ncWord.Groups(1).Value")
                            mCurAddress.Label = [Char].ToUpper(ncWord.Value(0))
                            mCurAddress.DecimalString = ncWord.Groups(1).Value.Replace(","c, "."c)
                            mCurAddress.Value = SingleParse(mCurAddress.DecimalString)
                            EvaluateWord()
                        Catch
                            mCodeText = contents.Substring(lastIndex, ncWord.Index - lastIndex).Trim
                            mParseErrors.Add(New clsParseError(mWordMatchIndex + p.StartChar, mLineNumber + p.StartLine, mCodeText))
                            RaiseEvent OnParseError(mLineNumber, mCodeText)
                        End Try
                    End If
                End If
                ncWord = ncWord.NextMatch
            End While

            'We have a remaining line
            If mBlockHasAddress(AlphaChars.ANY) Then
                EvaluateBlock(blockSkipped, lnPos, p)
            End If

            RaiseEvent OnProgEnd(p.Label & p.Value.ToString, lnPos)

        Catch ex As Exception
            mParseErrors.Add(New clsParseError(mWordMatchIndex, mLineNumber, mCodeText))
            RaiseEvent OnParseError(mLineNumber, mCodeText)
        End Try
    End Sub

    Private Sub EvaluateBlock(ByRef blockSkipped As Boolean, ByRef lnPos As Integer, ByVal p As clsProg)
        Dim localSubIndex As Integer = mCurSubIndex

        lnPos += 1

        If mIsSubCall Then
            mIsSubCall = False
            If Not blockSkipped Then
                'M98 P. Use the next word value as the sub name
                Dim targetSubVal As Single = mRegisters(AlphaChars.P)
                If targetSubVal > 9999 AndAlso mReps = 1 Then
                    mReps = CInt(Math.Truncate(targetSubVal / 10000)) 'we will use the first two digits to determine the reps.
                    targetSubVal = CSng(targetSubVal - (mReps * 10000)) 'and the remaining digits to determine the value.
                End If

                Dim retProg As clsProg = FindSubByValue(p, targetSubVal)
                Dim subReps As Integer = mReps
                mReps = 1
                If Not retProg Is Nothing Then
                    If retProg.TimesCalled > 100 Then Return 'Prevent infinate loop
                    For r As Integer = 1 To subReps
                        mCurSubIndex = mNcProgs.IndexOf(retProg)
                        ProcessSub(retProg) 'Call again
                    Next
                    'Restore the prog index
                    mCurSubIndex = localSubIndex
                End If
            End If
        Else
            For r As Integer = 1 To mReps
                EvaluateBlockRegisters(lnPos)
            Next
            ResetGcodeBlock()
        End If
        mCannedCycle.Value = -1
        blockSkipped = False
        mReps = 1

        Array.Copy(mBlockHasAddress, mLastBlockHadAddress, mBlockHasAddress.Length)
        Array.Clear(mBlockHasAddress, 0, mBlockHasAddress.Length)

    End Sub

    Private Sub EvaluateBlockRegisters(ByVal lnPos As Integer)
        Static mPrevMode As Motion = Motion.RAPID
        'No valid motion code was parsed on this line so return
        If Not mBlockHasAddress(AlphaChars.ANY) Then Return

        If mBlockHasAddress(AlphaChars.X) Then
            If mAbsolute = False Then
                mRegisters(AlphaChars.X) = mAxisValuesRaw(0) + mLastRegisters(AlphaChars.X)
            End If
            mRegisters(AlphaChars.X) /= mLatheDiaRadFactor
        End If

        If mBlockHasAddress(AlphaChars.Y) Then
            If mAbsolute = False Then
                mRegisters(AlphaChars.Y) = mAxisValuesRaw(1) + mLastRegisters(AlphaChars.Y)
            End If
        End If

        If mBlockHasAddress(AlphaChars.Z) Then
            If mAbsolute = False Then
                mRegisters(AlphaChars.Z) = mAxisValuesRaw(2) + mLastRegisters(AlphaChars.Z)
            End If
        End If


        'U V W
        If mCurMachine.UseUVW Then
            If mBlockHasAddress(AlphaChars.U) Then
                mRegisters(AlphaChars.X) += (mRegisters(AlphaChars.U) / mLatheDiaRadFactor)
            End If

            If mBlockHasAddress(AlphaChars.V) Then
                mRegisters(AlphaChars.Y) += mRegisters(AlphaChars.V)
            End If

            If mBlockHasAddress(AlphaChars.W) Then
                mRegisters(AlphaChars.Z) += mRegisters(AlphaChars.W)
            End If
        End If

        If mBlockHasAddress(mMotion.Rotary.AddressArrayIndex) Then
            mRotating = True
            If mCurMachine.RotaryType = RotaryMotionType.BMC Then '0>360 sign determines dir
                If mAbsolute = False Then
                    mABC = mAxisValuesRaw(3) + mPrevABC
                End If
            Else 'like CAD
                If mAbsolute = False Then
                    mRotDir = System.Math.Sign(mABC)
                    mABC = mAxisValuesRaw(3) + mPrevABC
                Else
                    'In a scale that runs from zero to 360
                    'we determine the direction based on the shortest distance.
                    If Math.Abs(mABC Mod ONE_RADIAN) > Math.PI AndAlso Math.Abs(mPrevABC Mod ONE_RADIAN) < Math.PI Then
                        mPrevABC += ONE_RADIAN
                    ElseIf Math.Abs(mABC Mod ONE_RADIAN) < Math.PI AndAlso Math.Abs(mPrevABC Mod ONE_RADIAN) > Math.PI Then
                        mPrevABC -= ONE_RADIAN
                    End If

                    If mABC < mPrevABC Then
                        mRotDir = -1
                    Else
                        mRotDir = 1
                    End If
                End If
            End If
            mRegisters(mMotion.Rotary.AddressArrayIndex) = mABC
        End If

        'Arc clockwise-------------------
        If mMode = Motion.CWARC Then
            Arc_Center() 'Calculate arc center
            If mArcData(ArcData.ANGLE_1) <= mArcData(ArcData.ANGLE_2) Then
                mArcData(ArcData.ANGLE_1) = mArcData(ArcData.ANGLE_1) + ONE_RADIAN
            End If

            're-calculate zpos if helix using k for pitch
            If mRegisters(AlphaChars.K) > 0 AndAlso mArcPlane = Motion.XY_PLN Then
                If mArcData(ArcData.ANGLE_1) = mArcData(ArcData.ANGLE_2) Then
                    mRegisters(AlphaChars.Z) = mRegisters(AlphaChars.Z) + mRegisters(AlphaChars.K)
                Else
                    mRegisters(AlphaChars.Z) = mRegisters(AlphaChars.Z) + (mRegisters(AlphaChars.K) * (System.Math.Abs(mArcData(ArcData.ANGLE_1) - mArcData(ArcData.ANGLE_2))) / ONE_RADIAN)
                End If
            End If

        End If

        'Arc anti-clockwise--------------
        If mMode = Motion.CCARC Then
            Arc_Center() 'Calculate arc center
            If mArcData(ArcData.ANGLE_2) <= mArcData(ArcData.ANGLE_1) Then
                mArcData(ArcData.ANGLE_2) = mArcData(ArcData.ANGLE_2) + ONE_RADIAN
            End If
            're-calculate zpos if helix using k for pitch
            If mRegisters(AlphaChars.K) > 0 AndAlso mArcPlane = Motion.XY_PLN Then
                If mArcData(ArcData.ANGLE_1) = mArcData(ArcData.ANGLE_2) Then
                    mRegisters(AlphaChars.Z) = mRegisters(AlphaChars.Z) + mRegisters(AlphaChars.K)
                Else
                    mRegisters(AlphaChars.Z) = mRegisters(AlphaChars.Z) + (mRegisters(AlphaChars.K) * (System.Math.Abs(mArcData(ArcData.ANGLE_1) - mArcData(ArcData.ANGLE_2))) / ONE_RADIAN)
                End If
            End If
        End If

        mSpeed = mRegisters(AlphaChars.S)

        If mRpmLimit Then 'An RPM limit has been specified
            mMaxRpm = mRegisters(AlphaChars.S)
        End If

        'Increment the tool
        If mToolChangeBlock Then
            mTool = mRegisters(AlphaChars.T)
            'The color range is between 1 and 31 but the tool could be anything
            'We need a list of tools to colors so the same color will show for the same tool
            Dim toolIdx As Integer = mToolNumbers.IndexOf(mTool)
            If toolIdx = -1 Then
                mToolNumbers.Add(mTool)
                toolIdx = mToolNumbers.Count - 1
            End If
            CurrentColorIndex = CInt(Math.Min(MAX_COLORS, toolIdx))
            RaiseEvent OnToolChanged(mRegisters(AlphaChars.T))
        End If

        If mMode <> Motion.HOLE_I AndAlso mMode <> Motion.HOLE_R Then
            mInitialZBeforeDrill = mRegisters(AlphaChars.Z)
        End If

        If mIsCannedCycle Then
            lnPos = mCannedCycleLineNumber
        End If

        Dim hasMove As Boolean = False
        'Go home. Most likely a G28
        If mGoHome Then 'We have a G28
            If mBlockHasAddress(mGoHomeAddressIndexX) AndAlso mRegisters(mGoHomeAddressIndexX) <> 0 Then 'X
                mRegisters(AlphaChars.X) = mRegisters(mGoHomeAddressIndexX)
                hasMove = True
            End If
            If mBlockHasAddress(mGoHomeAddressIndexY) AndAlso mRegisters(mGoHomeAddressIndexY) <> 0 Then
                mRegisters(AlphaChars.Y) = mRegisters(mGoHomeAddressIndexY)
                hasMove = True
            End If

            If mBlockHasAddress(mGoHomeAddressIndexZ) AndAlso mRegisters(mGoHomeAddressIndexZ) <> 0 Then
                mRegisters(AlphaChars.Z) = mRegisters(mGoHomeAddressIndexZ)
                hasMove = True
            End If

            'Create the graphics record for the home shift
            If hasMove Then AddMotionRecord(lnPos)
            hasMove = False

            'Only if we have a block address on this line
            If mBlockHasAddress(mGoHomeAddressIndexX) Then 'X
                mRegisters(AlphaChars.X) = (mCurMachine.HomeValues(0) / mLatheDiaRadFactor)
                hasMove = True
            End If

            If mBlockHasAddress(mGoHomeAddressIndexY) Then
                mRegisters(AlphaChars.Y) = mCurMachine.HomeValues(1)
                hasMove = True
            End If

            If mBlockHasAddress(mGoHomeAddressIndexZ) Then
                mRegisters(AlphaChars.Z) = mCurMachine.HomeValues(2)
                hasMove = True
            End If

            If Not hasMove Then 'Set all because one was not specified
                mRegisters(AlphaChars.X) = (mCurMachine.HomeValues(0) / mLatheDiaRadFactor)
                mRegisters(AlphaChars.Y) = mCurMachine.HomeValues(1)
                mRegisters(AlphaChars.Z) = mCurMachine.HomeValues(2)
            End If

        End If

        If mCurMachine.CornerTreatments AndAlso mMode = Motion.LINE AndAlso mMotionRec.MotionType = Motion.LINE Then
            AddCornerRecord(lnPos)
        End If
        AddMotionRecord(lnPos)

        'Stores last position
        Array.Copy(mRegisters, mLastRegisters, mRegisters.Length)

        'Debug.Print(mCodeText)
        mGoHome = False 'one time only
        mPrevMode = Motion.RAPID

    End Sub

    Private Sub ResetGcodeBlock()
        'Reset some values
        mToolChangeBlock = False
        mIsSubCall = False
        mRegisters(AlphaChars.P) = 0
        mArcData(ArcData.ANGLE_2) = 0
        mArcData(ArcData.ANGLE_1) = 0
        mArcData(ArcData.ARC_RAD) = 0
        'mRegisters(AlphaChars.R) = 0
        mArcData(ArcData.X_CTR) = 0
        mArcData(ArcData.Y_CTR) = 0
        mArcData(ArcData.Z_CTR) = 0
        'mPrevTool = mRegisters(AlphaChars.T)
        mRotating = False
        mPrevABC = mABC
        mRegisters(AlphaChars.I) = 0
        mRegisters(AlphaChars.J) = 0
        mRegisters(AlphaChars.K) = 0
        mRegisters(AlphaChars.U) = 0
        mRegisters(AlphaChars.V) = 0
        mRegisters(AlphaChars.W) = 0
    End Sub

    Private Sub EvaluateWord()
        mBlockHasAddress(mCurAddress.AddressArrayIndex) = True
        'Default value for all registers.
        'May be overwritten later
        If mCurAddress.AddressArrayIndex = AlphaChars.G OrElse mCurAddress.AddressArrayIndex = AlphaChars.M Then
            mRegisters(mCurAddress.AddressArrayIndex) = SingleParse(mCurAddress.DecimalString)
        Else
            mRegisters(mCurAddress.AddressArrayIndex) = SingleParse(mCurAddress.DecimalString, mCurMachine.Precision)
        End If

        For Each custom As Address In mCustomAddresses
            If custom.IsMatch(mCurAddress) Then
                RaiseEvent OnCustomAddress(custom.Label, custom.Value, mRegisters, mArcData)
                mBlockHasAddress(AlphaChars.ANY) = True
                Return
            End If
        Next

        Select Case mCurAddress.Label
            Case "X"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockHasAddress(AlphaChars.AXIS) = True
                mAxisValuesRaw(0) = AdjustForUnits(mRegisters(AlphaChars.X))
            Case "Y"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockHasAddress(AlphaChars.AXIS) = True
                mAxisValuesRaw(1) = AdjustForUnits(mRegisters(AlphaChars.Y))
            Case "Z"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockHasAddress(AlphaChars.AXIS) = True
                mAxisValuesRaw(2) = AdjustForUnits(mRegisters(AlphaChars.Z))
            Case "A"c
                mAxisValuesRaw(3) = AdjustForUnits(mRegisters(AlphaChars.A))
            Case "B"c
                mAxisValuesRaw(4) = AdjustForUnits(mRegisters(AlphaChars.B))
            Case "C"c
                mAxisValuesRaw(5) = AdjustForUnits(mRegisters(AlphaChars.C))
            Case "U"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockHasAddress(AlphaChars.AXIS) = True
                AdjustForUnits(mRegisters(AlphaChars.U))
            Case "V"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockHasAddress(AlphaChars.AXIS) = True
                AdjustForUnits(mRegisters(AlphaChars.V))
            Case "W"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockHasAddress(AlphaChars.AXIS) = True
                AdjustForUnits(mRegisters(AlphaChars.W))
            Case "I"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockHasAddress(AlphaChars.AXIS) = True
                AdjustForUnits(mRegisters(AlphaChars.I))
                If mCurMachine.AbsArcCenter Then
                    mRegisters(AlphaChars.I) /= mLatheDiaRadFactor
                End If
            Case "J"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockHasAddress(AlphaChars.AXIS) = True
                AdjustForUnits(mRegisters(AlphaChars.J))
            Case "K"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockHasAddress(AlphaChars.AXIS) = True
                AdjustForUnits(mRegisters(AlphaChars.K))
            Case "P"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mRegisters(AlphaChars.P) = SingleParse(mCurAddress.DecimalString)
            Case "R"c
                mBlockHasAddress(AlphaChars.ANY) = True
                'mRegisters(AlphaChars.R) = SingleParse(mCurAddress.DecimalString, mCurMachine.Precision)
                mArcRadSigned = AdjustForUnits(mRegisters(AlphaChars.R))
            Case "S"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mRegisters(AlphaChars.S) = SingleParse(mCurAddress.DecimalString)
            Case "F"c
                mBlockHasAddress(AlphaChars.ANY) = True
                'mRegisters(AlphaChars.F) = SingleParse(mCurAddress.DecimalString, mCurMachine.FeedPrecision)
                AdjustForUnits(mRegisters(AlphaChars.F))
            Case "T"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mRegisters(AlphaChars.T) = CInt(SingleParse(mCurAddress.DecimalString))
                If mMotion.ToolChange.Label = "T"c AndAlso mMotion.ToolChange.Value = 0 Then
                    mToolChangeBlock = True
                End If
            Case mRepeatsLabel
                mBlockHasAddress(AlphaChars.ANY) = True
                'we must ignore the reps with a canned cycle
                If mCannedCycle.Value = -1 Then
                    mReps = CInt(SingleParse(mCurAddress.DecimalString))
                End If
            Case mMotion.Rotary.Label
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockHasAddress(AlphaChars.AXIS) = True
                mABC = SingleParse(mCurAddress.DecimalString, mCurMachine.RotPrecision) * 0.0174532924F 'Convert to radians
                mAxisValuesRaw(3) = mABC
                If mCurAddress.DecimalString.StartsWith("-") Then 'check for -0
                    mRotDir = -1 'CCW
                End If

            Case Else

                If mCurAddress.IsMatch(mMotion.Abs) Then 'Absolute positioning
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mAbsolute = True
                ElseIf mCurAddress.IsMatch(mMotion.Inc) Then 'Incremental positioning
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mAbsolute = False

                ElseIf mCurAddress.IsMatch(mMotion.FeedModeMin) Then 'FeedMode
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mFeedMode = FeedMode.UNIT_PER_MIN
                ElseIf mCurAddress.IsMatch(mMotion.FeedModeRev) Then
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mFeedMode = FeedMode.UNIT_PER_REV

                ElseIf mCurAddress.IsMatch(mMotion.CompLeft) Then 'Cutter comp 'Left
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mComp = CutterComp.LEFT

                ElseIf mCurAddress.IsMatch(mMotion.CompRight) Then 'Right
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mComp = CutterComp.RIGHT

                ElseIf mCurAddress.IsMatch(mMotion.CompCancel) Then 'Off
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mComp = CutterComp.OFF

                ElseIf mCurAddress.IsMatch(mMotion.Rapid) Then
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mMode = Motion.RAPID
                ElseIf mCurAddress.IsMatch(mMotion.ToolChange) Then 'Toolchange
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mToolChangeBlock = True
                ElseIf mCurAddress.IsMatch(mMotion.Linear) Then
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mMode = Motion.LINE
                ElseIf mCurAddress.IsMatch(mMotion.CWArc) Then  'Arc clockwise
                    mBlockHasAddress(AlphaChars.ANY) = True
                    If mArcPlane = Motion.XZ_PLN Then
                        mMode = Motion.CCARC
                    Else
                        mMode = Motion.CWARC
                    End If
                ElseIf mCurAddress.IsMatch(mMotion.CCArc) Then  'Arc anti-clockwise
                    mBlockHasAddress(AlphaChars.ANY) = True
                    If mArcPlane = Motion.XZ_PLN Then
                        mMode = Motion.CWARC
                    Else
                        mMode = Motion.CCARC
                    End If
                ElseIf mCurAddress.IsMatch(mMotion.GoHome) Then 'GO HOME
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mGoHome = True
                ElseIf mCurAddress.IsMatch(mMotion.SpeedLimit) Then 'RPM limit
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mRpmLimit = True
                ElseIf mCurAddress.IsMatch(mMotion.SpeedModeRPM) Then 'RPM Mode RPM
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mSpeedMode = SpeedMode.RPM
                ElseIf mCurAddress.IsMatch(mMotion.SpeedModeSFPM) Then 'RPM Mode SFPM
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mSpeedMode = SpeedMode.SURFACE_SPEED
                ElseIf mCurAddress.IsMatch(mMotion.UnitsEnglish) Then 'English units
                    mCurrentUnits = MachineUnits.ENGLISH
                ElseIf mCurAddress.IsMatch(mMotion.UnitsMetric) Then 'Metric units
                    mCurrentUnits = MachineUnits.METRIC
                ElseIf mCurAddress.IsMatch(mMotion.Drills(0)) Then  'Drill cancel found
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mMode = Motion.RAPID
                    If mDrillReturnMode = Motion.I_PLN Then
                        mRegisters(AlphaChars.Z) = mInitialZBeforeDrill
                    Else
                        mRegisters(AlphaChars.Z) = mRegisters(AlphaChars.R)
                    End If
                    mRegisters(AlphaChars.R) = 0

                ElseIf mCurAddress.IsMatch(mMotion.ReturnLevel(0)) Then
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mDrillReturnMode = Motion.I_PLN
                    If mMode > 3 Then
                        mMode = DirectCast(Motion.HOLE_I + mDrillReturnMode, Motion)
                    End If
                ElseIf mCurAddress.IsMatch(mMotion.ReturnLevel(1)) Then
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mDrillReturnMode = Motion.R_PLN
                    If mMode > 3 Then
                        mMode = DirectCast(Motion.HOLE_I + mDrillReturnMode, Motion)
                    End If
                ElseIf mCurAddress.IsMatch(mMotion.Plane(0)) Then 'Plane Change G17
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mArcPlane = Motion.XY_PLN
                ElseIf mCurAddress.IsMatch(mMotion.Plane(1)) Then  'Plane Change G18
                    mBlockHasAddress(AlphaChars.ANY) = True
                    mArcPlane = Motion.XZ_PLN
                ElseIf mCurAddress.IsMatch(mMotion.Plane(2)) Then  'Plane Change G19
                    mArcPlane = Motion.YZ_PLN
                    mBlockHasAddress(AlphaChars.ANY) = True
                ElseIf mCurAddress.IsMatch(mMotion.SubCall) Then
                    mIsSubCall = True
                Else
                    For r As Integer = 1 To mMotion.Drills.Length - 1 'Cycle through all 10 drilling cycles
                        If mMotion.Drills(r).Label <> Nothing Then 'NOT an empty field
                            If mCurAddress.IsMatch(mMotion.Drills(r)) Then
                                mMode = DirectCast(Motion.HOLE_I + mDrillReturnMode, Motion) 'Drill cycle found
                                mBlockHasAddress(AlphaChars.ANY) = True
                                Exit Select
                            End If
                        End If
                    Next r

                    For r As Integer = 0 To mCannedCycles.Count - 1
                        If mCannedCycles(r).IsMatch(mCurAddress) Then
                            mCannedCycle = mCannedCycles(r)
                            mBlockHasAddress(AlphaChars.ANY) = True
                            mCannedCycleFile = mCannedCycleFileNames(r)
                            Exit For
                        End If
                    Next

                    'If some G code is found and it has not been handled we need to reset.
                    'If mCurAddress.Label = "G"c Then
                    '    If Not mBlockAddresses(letters.AXIS) Then
                    '        mMode = Motion.LINE
                    '    End If
                    'End If
                End If

        End Select
    End Sub

    Private Function AdjustForUnits(ByRef val As Single) As Single
        If mCurrentUnits <> MachineUnits.ENGLISH Then
            val /= 25.4F
        End If
        Return val
    End Function

    Friend Function MatchIsComment(ByVal m As Match) As Boolean
        Return m.Groups("Comment").Success
    End Function

    Private Function InsertCommment() As String
        If mCommentMatch.Length > 0 Then
            Return mCommentMatch & "|"
        Else
            Return ""
        End If
    End Function

    Private Sub BuildCommentMatch()
        mCommentMatch = ""
        Dim commentSetting As String = mCurMachine.Comments
        If commentSetting.Contains("(*)") OrElse commentSetting.Contains("()") Then 'Legacy support
            mCommentMatch = "\([^()]*\)"
        End If

        If commentSetting.Contains("{}") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= "{[^{}]*}"
        End If
        If commentSetting.Contains("[]") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= "\[[[]]*\]"
        End If
        If commentSetting.Contains("<>") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= "\<[<>]*\>"
        End If

        If commentSetting.Contains("""""") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= """.*"""
        End If

        'Single characters
        If commentSetting.Contains("*") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= "\*.*\n"
        End If

        If commentSetting.Contains(";") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= ";.*\n"
        End If
        If commentSetting.Contains(":") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= ":.*\n"
        End If
        If commentSetting.Contains("'") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= "'.*\n"
        End If

        If mCommentMatch.Length > 0 Then
            mCommentMatch = "(?<Comment>" & mCommentMatch & ")"
        End If
    End Sub

    Public Sub Init(ByVal machineSetup As clsMachine, ByVal cannedCyclesFldr As String, ByVal settingsFolder As String)
        If machineSetup Is Nothing Then Return
        Init(machineSetup)
    End Sub

    Public Sub Init(ByVal machineSetup As clsMachine)
        If machineSetup Is Nothing Then Return
        mCurMachine = machineSetup

        Dim skipChars As String = ""
        If mCurMachine.BlockSkip IsNot Nothing Then
            For Each c As Char In mCurMachine.BlockSkip.ToCharArray
                skipChars += Regex.Escape(c)
            Next
        End If

        Dim progId As String = Regex.Escape(mCurMachine.ProgramId)
        '\([^()]*\)|[/\*].*\n|\n|[A-Z][-+]?[0-9]*\.?[0-9]*
        '(?=\([^()].*?\))

        'Dim comment As String = ""
        'If mCurMachine.Comments.Length = 3 Then
        '    comment = Regex.Escape(mCurMachine.Comments(0)) & "[^" & mCurMachine.Comments(0) & mCurMachine.Comments(2) & "]*" & Regex.Escape(mCurMachine.Comments(2)) & "|"
        'Else
        '    comment = Regex.Escape(mCurMachine.Comments(0)) & ".*" & STR_EOL & "|"
        'End If

        If String.IsNullOrEmpty(RegexNcWordsMatch) Then
            RegexNcWordsMatch = REG_NCWORDS
        End If

        BuildCommentMatch()

        mRegSkips = New Regex(InsertCommment() & "[" & skipChars & "][0-9]?", RegexOptions.Compiled)

        mRegWords = New Regex(InsertCommment() & "[" & skipChars & "][0-9]?|" & STR_EOL & "|" & RegexNcWordsMatch, RegexOptions.Compiled Or RegexOptions.IgnoreCase)
        '[:\$O]+([0-9]+)  This will return the label and value of each program.
        mRegSubs = New Regex(InsertCommment() & "[" & progId & "]([0-9]+)", RegexOptions.Compiled)
        'Used to count lines
        mRegNewLines = New Regex(STR_EOL, RegexOptions.Compiled)
    End Sub

    Public Function GatherBlockSkips(ByVal txt As String) As Integer
        'BlockSkips.Clear()
        Dim bsk As clsBlockSkip
        Dim contains As Boolean = False
        For Each sk As Match In Me.mRegSkips.Matches(txt)
            If Not mCurMachine.BlockSkip.Contains(sk.Value(0)) Then
                Continue For
            End If

            bsk = New clsBlockSkip(sk.Value)
            contains = False
            For Each s As clsBlockSkip In BlockSkips
                If s.Match = bsk.Match Then
                    contains = True
                    Exit For
                End If
            Next
            If Not contains Then
                BlockSkips.Add(bsk)
            End If
        Next
        Return BlockSkips.Count
    End Function

    Public Function FilterJunk(ByRef sText As String) As String
        Dim match As String = REG_JUNK
        Return Regex.Replace(sText, match, "", RegexOptions.Compiled)
    End Function

    Public Sub LoadColorsFromSettings(ByVal clrs As Specialized.StringCollection)
        For c As Integer = 0 To MAX_COLORS
            mColors32(c) = CInt(clrs(c))
        Next
    End Sub

    Private Function Color32(ByVal i As Integer) As System.Drawing.Color
        If i > MAX_COLORS Then
            Return System.Drawing.Color.FromArgb(mColors32(0))
        End If
        Return System.Drawing.Color.FromArgb(mColors32(i))
    End Function

    Public Sub InsertMotionRecord(ByVal linePos As Integer, ByVal mode As Motion, ByVal arcPlane As Integer, ByVal newProfile As Boolean, ByVal gcode As String)
        mMotionRec = New clsMotionRecord
        mMode = mode

        If mMode = Motion.HOLE_I Then
            mDrillClear = mInitialZBeforeDrill
        End If
        If mMode = Motion.HOLE_R Then
            mDrillClear = mRegisters(AlphaChars.R)
        End If
        With mMotionRec
            .Linenumber = linePos
            .ArcPlane = arcPlane
            .Tool = mTool 'mRegisters(AlphaChars.T)
            .DrawColor = DrawColor
            .Yold = mLastRegisters(AlphaChars.Y) + mCurMachine.ViewShift(1)
            .Ycentr = mArcData(ArcData.Y_CTR) + mCurMachine.ViewShift(1)
            .Ypos = mRegisters(AlphaChars.Y) + mCurMachine.ViewShift(1)

            .Codestring = gcode
            If mBlockHasAddress(AlphaChars.AXIS) Then
                .MotionType = mMode
            Else
                .MotionType = Motion.RAPID
            End If
            .Rpoint = mRegisters(AlphaChars.R) + mCurMachine.ViewShift(2)
            .DrillClear = mDrillClear
            .Xold = mLastRegisters(AlphaChars.X) + mCurMachine.ViewShift(0)
            .Xpos = mRegisters(AlphaChars.X) + mCurMachine.ViewShift(0)
            .Rad = mArcData(ArcData.ARC_RAD)
            .Xcentr = mArcData(ArcData.X_CTR) + mCurMachine.ViewShift(0)

            .Zold = mLastRegisters(AlphaChars.Z) + mCurMachine.ViewShift(2)
            .Zpos = mRegisters(AlphaChars.Z) + mCurMachine.ViewShift(2)
            .Zcentr = mArcData(ArcData.Z_CTR) + mCurMachine.ViewShift(2)

            .Rotate = mRotating
            .NewRotaryPos = mABC
            .OldRotaryPos = mPrevABC
            .RotaryDir = mRotDir ' * mcurmachine.nRotaryDir
            .Comp = mComp
            .Speed = mRegisters(AlphaChars.S)
            If mMode = Motion.RAPID Then
                .FeedRate = mRapidRate
                .FeedMode = FeedMode.UNIT_PER_MIN
            Else
                .FeedRate = mRegisters(AlphaChars.F)
                .FeedMode = mFeedMode
            End If
            .Sang = mArcData(ArcData.ANGLE_1)
            .Eang = mArcData(ArcData.ANGLE_2)
        End With
        mMotionRecs.Add(mMotionRec)
    End Sub

    Public Sub RegisterCustomAddress(ByVal label As Char, ByVal value As Single)
        Dim a As New Address
        a.Label = label
        a.Value = value
        mCustomAddresses.Add(a)
    End Sub

    Public Shared Function VectorLength(ByVal X1 As Single, ByVal Y1 As Single, ByVal Z1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal Z2 As Single) As Single
        Return CSng(System.Math.Sqrt(((X1 - x2) ^ 2) + ((Y1 - y2) ^ 2) + ((Z1 - Z2) ^ 2)))
    End Function

    Public Shared Function AngleFromPoint(ByVal x As Single, ByVal y As Single, ByVal deg As Boolean) As Single
        Dim theta As Single
        If x > 0 AndAlso y > 0 Then ' Quadrant 1
            theta = CSng(System.Math.Atan(y / x))
        ElseIf x < 0 AndAlso y > 0 Then  ' Quadrant 2
            theta = CSng(System.Math.Atan(y / x) + Math.PI)
        ElseIf x < 0 AndAlso y < 0 Then  ' Quadrant 3
            theta = CSng(System.Math.Atan(y / x) + Math.PI)
        ElseIf x > 0 AndAlso y < 0 Then  ' Quadrant 4
            theta = CSng(System.Math.Atan(y / x) + 2 * Math.PI)
        End If

        ' Exceptions for points landing on an axis
        If x > 0 AndAlso y = 0 Then '0
            theta = 0
        ElseIf x = 0 AndAlso y > 0 Then  '90
            theta = Math.PI / 2
        ElseIf x < 0 AndAlso y = 0 Then  '180
            theta = Math.PI
        ElseIf x = 0 AndAlso y < 0 Then  '270
            theta = 3 * (Math.PI / 2)
        End If

        ' if you want the angle in degrees use this conversion
        If deg Then
            theta = CSng(theta * (180.0 / Math.PI))
        End If
        Return theta

    End Function

End Class