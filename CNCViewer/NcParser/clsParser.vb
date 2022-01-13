Option Strict On
Option Explicit On
Option Compare Text
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.RegularExpressions
Imports Abacus.DoublePrecision

''' <remarks>
''' Jason Titcomb
''' www.CncEdit.com
''' https://github.com/JasonTitcomb/Basic_CNC_Viewer/blob/master/LICENSE.md
''' </remarks>
Public Class clsParser
    Private mWorker As System.ComponentModel.BackgroundWorker = Nothing
    Private Const REG_JUNK As String = "\x0A\x0A|\x0D\x0D|[\x00-\x09]|[\x0E-\x1F]|[\x7F-\xFF]"
    Private Const STR_EOL As String = "\u000d?\u000a"
    Friend Const MAX_COLORS As Integer = 31
    Private mColors32(MAX_COLORS) As Integer
    Private mToolNumbers As New List(Of Double)

    Public BlockSkips As New List(Of clsBlockSkip)
    Private mRegSkips As Regex
    Private mWordMatchIndex As Integer
    Private mParseErrorsIndex As Integer
    Private mRegMacroTest As Regex
    Private mRegSubs As Regex
    Private mCurProg As clsProg
    Private mGlobalProg As clsProg
    Private mMainProg As clsProg

    Private mRegNewLines As Regex
    Private mCommentMatch As String
    Private mCommentNoMatch As String
    Private mArcPlane As Integer
    Private mDrillClear As Double

    Private mInitialZBeforeDrill As Double
    Private mEndmain As String 'M30
    Private mEndsub As String 'M99
    Private mSubcall As String 'M98
    Private mInternalSubcall As String 'M97
    Private mInternalSubParam As String 'H or P
    Private mInternalCallParam As Integer
    Private mExternalCallParam As Integer
    Private mBlockComment As String
    Private mCancelParse As Boolean
    Private Enum subCallType
        none
        external_M98
        internal_M97
    End Enum

    Private mSubCallType As subCallType
    Private mCurSubIndex As Integer
    Private mRepeatsLabel As Char 'L
    Private mReps As Integer = 1
    Private mCurrentUnits As MachineUnits
    Private mUnitsConversion As Double
    Private mArcRadSigned As Double

    Private mPrevABC, mRotaryMoveABC As Double
    Private mRotDir As Integer
    Private mBlockRotating As Boolean
    Private mRotaryAxisLabel As AlphaChars

    Private mGoHomeAddressIndexX As Integer
    Private mGoHomeAddressIndexY As Integer
    Private mGoHomeAddressIndexZ As Integer

    Private mComp As CutterComp
    Private mDrillReturnMode As DrillReturn 'G98,G99
    Private mTool As Double
    Private mMode As Motion
    Private mLastMode As Motion
    Private mFeedMode As MacGen.FeedMode
    Private mSpeedMode As MacGen.SpeedMode
    Private mSpeed As Double
    Private mMaxRpm As Double
    Private mAbsOrInc As IncAbsMode
    Private mRpmLimit As Boolean
    Private mToolChangeBlock As Boolean
    Private mLineNumber As Integer
    Private mTotalBites As Integer
    Private mWords As New clsMotion
    Private mLatheDiaRadFactor As Double

    Private mCurAddress As Address
    'Private mEndMain As Address
    Private mMotionRec As MacGen.clsMotionRecord
    Private mMotionRecs As List(Of clsMotionRecord)
    Public mCurMachine As clsMachine
    Private mRapidRate As Double = 100.0F
    Private Const ONE_RADIAN As Double = Math.PI * 2
    Private Const HALF_RADIAN_PI As Double = Math.PI
    Private Const QUARTER_RADIAN As Double = Math.PI / 2

    Private mPrevTransXYZ As Vector3
    Private mTransXYZ As Vector3
    Private mToolPosXYZ As Vector3
    Private mTransArcCenter As Vector3

    Private mRegisters(AlphaChars.UNKNOWN) As Double
    Private mRawWordValues(AlphaChars.UNKNOWN) As Double
    Private mBlockHasAddress(AlphaChars.UNKNOWN) As Boolean
    Private mLastRegisters(AlphaChars.UNKNOWN) As Double
    Private mArcData(7) As Double
    Private mMirrorOneAxisActive As Boolean
    Private mIJK_Invert As Integer = 1
    Private mParamVals(12) As Double 'unmolested values from word
    Private mBlockCausesAxisMove As Boolean
    Private mCannedCycles As New List(Of Address)
    Private mCannedCycleFileNames As New Specialized.StringCollection
    Private mCannedCycleFile As String
    Private mCannedCycle As Address
    Private mIsCannedCycle As Boolean
    Private mCannedCycleLineNumber As Integer

    Private mMaxX As Double = Double.MinValue
    Private mMaxY As Double = Double.MinValue
    Private mMaxZ As Double = Double.MinValue
    Private mMinX As Double = Double.MaxValue
    Private mMinY As Double = Double.MaxValue
    Private mMinZ As Double = Double.MaxValue

    'Private mWorld As WorldOffset
    Private mPriWrkAddress As Integer 'G54
    Private mSecWrkAddress As Integer 'G57 H92
    Private mG54Offset As New WrkOffset
    Private mG92Offset As New WrkOffset
    Private mG52Offset As New WrkOffset
    Private mCanEvalMacroB As Boolean
    'add events for motion blocks
    Private mProgStack As New Stack(Of clsProg)
    Public Event OnProgStart(name As String, line As Integer)
    Public Event OnProgEnd(name As String, line As Integer)

    Public Event OnToolChanged(tool As Double)
    Public Event OnParseError(position As Integer, msg As String)
    Public Event OnProgress(percent As Integer)
    Public Event OnMsgInfo(msg As String)
    Public Event OnParseStart(sender As Object, isMacro As Boolean)

    Private mCodeBlock As Block
    Private Structure Block
        Sub Create(str As String, startidx As Integer, endidx As Integer, line As Integer)
            Text = str
            StartIndex = startidx
            EndIndex = endidx
            LineNUmber = line
        End Sub
        Dim Text As String
        Dim StartIndex As Integer
        Dim EndIndex As Integer
        Dim LineNUmber As Integer
    End Structure


    Private mGegexNcWords As String
    Public Property RegexNcWordsMatch() As String
        Get
            Return mGegexNcWords
        End Get
        Set(value As String)
            mGegexNcWords = value
        End Set
    End Property

    Private mMacroMatch As String = "\#\d+|GOTO"
    Public Property MacroMatch() As String
        Get
            Return mMacroMatch
        End Get
        Set(value As String)
            mMacroMatch = value
        End Set
    End Property

    Private mIgnoreWhiteSpace As Boolean
    Public Property IgnoreWhitespace() As Boolean
        Get
            Return mIgnoreWhiteSpace
        End Get
        Set(value As Boolean)
            mIgnoreWhiteSpace = value
        End Set
    End Property

    Private mTryEvalMacroB As Boolean = True
    Public Property TryEvalMacroB() As Boolean
        Get
            Return mTryEvalMacroB
        End Get
        Set(value As Boolean)
            mTryEvalMacroB = value
        End Set
    End Property

    Private mIgnoreToolColor As Boolean
    Public WriteOnly Property IgnoreToolColor() As Boolean
        Set(value As Boolean)
            mIgnoreToolColor = value
        End Set
    End Property

    Private mDrawColor As Drawing.Color = Drawing.Color.Blue
    Public Property DrawColor() As Drawing.Color
        Get
            Return mDrawColor
        End Get
        Set(value As Drawing.Color)
            mDrawColor = value
        End Set
    End Property

    Public ReadOnly Property MaxZ() As Double
        Get
            Return mMaxZ
        End Get
    End Property

    Public ReadOnly Property MinZ() As Double
        Get
            Return mMinZ
        End Get
    End Property

    Private mCurrentColorIndex As Integer = MAX_COLORS
    Public Property CurrentColorIndex() As Integer
        Get
            Return mCurrentColorIndex
        End Get
        Set(value As Integer)
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
    Public ReadOnly Property LastParseError() As clsParseError
        Get
            Return mParseErrors.LastOrDefault
        End Get
    End Property
    Public ReadOnly Property CodeLine() As String
        Get
            Return mCodeBlock.Text
        End Get
    End Property

#Region "Doubleton"
    Private Shared mInstance As clsParser
    Private Shared SyncLock_LOCK As New Object
    'PRIVATE constructor can only be called from this class
    Public Sub New()
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
    ''' Static method for creating the Double instance of the Constructor
    ''' </summary>
    Public Shared Function Instance() As clsParser
        SyncLock SyncLock_LOCK
            ' initialize if not already done
            If mInstance Is Nothing Then
                mInstance = New clsParser
            End If
        End SyncLock
        ' return the initialized instance of the Doubleton Class
        Return mInstance
    End Function 'Instance
#End Region

    Private mNcProgs As System.Collections.Generic.List(Of clsProg)
    Public Function IsSubFileUsedByProgram(fl As String) As Boolean
        If mNcProgs Is Nothing OrElse mNcProgs.Count < 2 Then Return False
        For r As Integer = 1 To mNcProgs.Count - 1
            Dim p As clsProg = mNcProgs(r)
            If String.Compare(p.FileName, fl, True) = 0 Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function GetProgIndex(fl As String, selStart As Integer) As Integer
        If mNcProgs Is Nothing Then Return -1
        For r As Integer = 0 To mNcProgs.Count - 1
            If String.Compare(mNcProgs(r).FileName, fl, True) = 0 Then
                If selStart >= mNcProgs(r).StartChar AndAlso selStart <= (mNcProgs(r).Contents.Length + mNcProgs(r).StartChar) Then
                    Return r
                End If
            End If
        Next
        Return 0
    End Function

    Private Function WordChanged(axis As AlphaChars) As Boolean
        Return mLastRegisters(axis) = mRegisters(axis)
    End Function

    Private Function RegisterDelta(axis As Integer) As Double
        Return mRegisters(axis) - mLastRegisters(axis)
    End Function
    Private Function HaveAxisValue() As Boolean
        If mMode <> Motion.NONE Then
            If mBlockHasAddress(AlphaChars.X) OrElse
                mBlockHasAddress(AlphaChars.Y) OrElse
                mBlockHasAddress(AlphaChars.Z) OrElse
                mBlockHasAddress(AlphaChars.A) OrElse
                mBlockHasAddress(AlphaChars.B) OrElse
                mBlockHasAddress(AlphaChars.C) OrElse
                mBlockHasAddress(AlphaChars.I) OrElse
                mBlockHasAddress(AlphaChars.J) OrElse
                mBlockHasAddress(AlphaChars.K) OrElse
                mBlockHasAddress(AlphaChars.U) OrElse
                mBlockHasAddress(AlphaChars.V) OrElse
                mBlockHasAddress(AlphaChars.W) Then
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Private Sub TestArcCenterTol(tol As Double)
        Dim endRad As Double = Distance3(mArcData(ArcData.X_CTR), mArcData(ArcData.Y_CTR), 0, mRegisters(AlphaChars.X), mRegisters(AlphaChars.Y), 0)
        If Math.Abs(endRad - mArcData(ArcData.ARC_RAD)) > tol Then
            mParseErrors.Add(New clsParseError(mCurProg.FileName, mCodeBlock.StartIndex, mCodeBlock.LineNUmber, "Radius error >" & tol, mCodeBlock.Text))
        End If
    End Sub

    Private Function Normalize(x As Double, y As Double) As Vector2
        Dim length As Double
        ' Calculate the length of the vector		
        length = 1.0F / Math.Sqrt((x * x) + (y * y))
        'Dividing each element by the length will result in a
        'unit normal vector.
        Return New Vector2(x * length, y * length)
    End Function

    Private Function Distance3(X1 As Double, Y1 As Double, Z1 As Double, x2 As Double, y2 As Double, Z2 As Double) As Double
        Return Math.Sqrt(((X1 - x2) ^ 2) + ((Y1 - y2) ^ 2) + ((Z1 - Z2) ^ 2))
    End Function

    Private Function CrossProd(p1 As Vector2, p2 As Vector2) As Double
        p1.Normalise()
        p2.Normalise()
        Return (p1.X * p2.Y) - (p1.Y * p2.X)
    End Function

    Private Sub PointFromAngleAndRad(ByRef retpoint As Vector3, angleInRadians As Double, rad As Double)
        retpoint.X = rad * Math.Cos(angleInRadians)
        retpoint.Y = (rad * Math.Sin(angleInRadians))
    End Sub

    ''' <summary>
    ''' Calculaes angle
    ''' </summary>
    ''' <param name="v1">normal vector start</param>
    ''' <param name="v2">normal vector end</param>
    ''' <returns></returns>
    Private Function AngleBetween2D(v1 As Vector2, v2 As Vector2) As Double
        If v1.Length = 0 Or v2.Length = 0 Then
            Return 0
        End If
        Dim angle As Double
        angle = Math.Atan2(v2.Y, v2.X) - Math.Atan2(v1.Y, v1.X)
        If (angle < 0) Then
            angle += (ONE_RADIAN)
        End If

        If (angle > Math.PI) Then
            angle -= ONE_RADIAN
        ElseIf (angle <= -Math.PI) Then
            angle += ONE_RADIAN
        End If
        Return angle
        'Return angle * (180.0 / Math.PI)
    End Function
    Private Function AngleBetween_XY(vector1 As Vector2, vector2 As Vector2) As Double
        If vector1.Length = 0 Or vector2.Length = 0 Then
            Return 0
        End If
        Dim v3 = vector2 - vector1
        Return AngleFromPoint(v3.X, v3.Y, False)
        'Return (theta * (180.0 / Math.PI))
    End Function

    Private Sub TestBlockForCornerBreak()
        mMotionRec.CornerBreakType = CornerBreakType.None
        If mCurMachine.CornerTreatments AndAlso mMode = Motion.LINE Then

            Dim r_c As Double
            'If the line has an R or C 
            If mBlockHasAddress(AlphaChars.C) Then
                r_c = Math.Abs(mRegisters(AlphaChars.C))
                mMotionRec.CornerBreakType = CornerBreakType.ChamferCorner
            ElseIf mBlockHasAddress(AlphaChars.R) Then
                r_c = Math.Abs(mRegisters(AlphaChars.R))
                mMotionRec.CornerBreakType = CornerBreakType.RadiusCorner
            Else
                'IJK chamfer KX IZ
                If mBlockHasAddress(AlphaChars.I) Then
                    r_c = Math.Abs(mRegisters(AlphaChars.I))
                    mMotionRec.CornerBreakType = CornerBreakType.ChamferCorner
                ElseIf mBlockHasAddress(AlphaChars.J) Then
                    r_c = Math.Abs(mRegisters(AlphaChars.J))
                    mMotionRec.CornerBreakType = CornerBreakType.ChamferCorner
                ElseIf mBlockHasAddress(AlphaChars.K) Then
                    r_c = Math.Abs(mRegisters(AlphaChars.K))
                    mMotionRec.CornerBreakType = CornerBreakType.ChamferCorner
                End If
            End If
            mMotionRec.CornerBreak = r_c
        End If

    End Sub

    'Create the graphics record here
    'Block with X and C,R and no Z is a candidate for break corner
    Private Sub AddCornerRecord(priorCornerBlock As clsMotionRecord)
        Dim calculateArcOrLineMode As Motion = Motion.LINE
        Dim blendOrChamfer As clsMotionRecord
        Dim vec1 As Vector2
        Dim vec2 As Vector2
        Dim len1, len2 As Double
        Dim motionType As Motion = Motion.LINE
        Const cornerTooLargeMsg As String = "Corner break too large"

        Dim priorTrimmedVec3 As Vector3
        Dim nextTrimmedVec3 As Vector3
        Dim curCtr As Vector3
        Dim r_c As Double = priorCornerBlock.CornerBreak
        Dim arcOrChamfer = priorCornerBlock.CornerBreakType

        'Adds a chamfer or rad to the end of cornerMotionRecord
        'So I need to read the line after the chamfer line before I can insert a record.
        'Use either C or IJK
        'IJK must match XYZ
        'Must not be too large
        'R only does radius


        len1 = Distance3(priorCornerBlock.XYZold.X, priorCornerBlock.XYZold.Y, priorCornerBlock.XYZold.Z, priorCornerBlock.XYZpos.X, priorCornerBlock.XYZpos.Y, priorCornerBlock.XYZpos.Z)
        len2 = Distance3(mMotionRec.XYZold.X, mMotionRec.XYZold.Y, mMotionRec.XYZold.Z, mMotionRec.XYZpos.X, mMotionRec.XYZpos.Y, mMotionRec.XYZpos.Z)

        'Make sure both of the adjacent elements can support the break
        If len1 <= Math.Abs(r_c) Or len2 <= Math.Abs(r_c) Then
            mParseErrors.Add(New clsParseError(mCurProg.FileName, mCodeBlock.StartIndex, mLineNumber, cornerTooLargeMsg, mCodeBlock.Text))
            Return
        End If
        If r_c = 0 Then
            mParseErrors.Add(New clsParseError(mCurProg.FileName, mCodeBlock.StartIndex, mLineNumber, "Zero size corner. Check I J K R C values", mCodeBlock.Text))
            Return
        End If


        Select Case mArcPlane
            Case Motion.XY_PLN
                'Using X and Y because we are on the XY plane
                vec1 = New Vector2(priorCornerBlock.XYZpos.X - priorCornerBlock.XYZold.X,
                                   priorCornerBlock.XYZpos.Y - priorCornerBlock.XYZold.Y)
                vec2 = New Vector2(mMotionRec.XYZpos.X - mMotionRec.XYZold.X,
                                   mMotionRec.XYZpos.Y - mMotionRec.XYZold.Y)

                Dim blendVec1 = New Vector2(priorCornerBlock.XYZold.X, priorCornerBlock.XYZold.Y)
                Dim blendVec2 = New Vector2(priorCornerBlock.XYZpos.X, priorCornerBlock.XYZpos.Y)
                Dim blendVec3 = New Vector2(priorCornerBlock.XYZpos.X, priorCornerBlock.XYZpos.Y)
                Dim blendVec4 = New Vector2(mMotionRec.XYZpos.X, mMotionRec.XYZpos.Y)

                Dim prevModLine As New BlendCalculatorXY(blendVec1, blendVec2)
                Dim nextModLine As New BlendCalculatorXY(blendVec3, blendVec4)

                Dim dotprod As Double
                If arcOrChamfer = CornerBreakType.RadiusCorner Then
                    dotprod = CalcWindingDirection(vec1, vec2)
                    motionType = If(dotprod = -1, Motion.CWARC, Motion.CCARC)
                Else
                    motionType = Motion.LINE
                End If
                Dim trimDist = GetTrimBackDist(vec1, vec2, r_c)

                prevModLine.TrimEnd(trimDist)
                prevModLine.FindCenter(trimDist, r_c, dotprod)
                nextModLine.TrimStart(trimDist)
                priorTrimmedVec3 = New Vector3(prevModLine.P2.X, prevModLine.P2.Y, priorCornerBlock.XYZpos.Z)
                nextTrimmedVec3 = New Vector3(nextModLine.P1.X, nextModLine.P1.Y, priorCornerBlock.XYZpos.Z)
                curCtr = New Vector3(prevModLine.Ctr.X, prevModLine.Ctr.Y, priorCornerBlock.XYZpos.Z)

            Case Motion.XZ_PLN 'lathe
                'I have read the second line and am about to create the arc and the second line
                'We need to determine new end points
                'And determine arc center.
                'And alter the last record by the amount of the rad

                'Using X and Z because we are on the XZ plane
                vec1 = New Vector2(priorCornerBlock.XYZpos.Z - priorCornerBlock.XYZold.Z,
                                   priorCornerBlock.XYZpos.X - priorCornerBlock.XYZold.X)
                vec2 = New Vector2(mMotionRec.XYZpos.Z - priorCornerBlock.XYZpos.Z,
                                   mMotionRec.XYZpos.X - priorCornerBlock.XYZpos.X)

                Dim blendVec1 = New Vector2(priorCornerBlock.XYZold.Z, priorCornerBlock.XYZold.X)
                Dim blendVec2 = New Vector2(priorCornerBlock.XYZpos.Z, priorCornerBlock.XYZpos.X)
                Dim blendVec3 = New Vector2(priorCornerBlock.XYZpos.Z, priorCornerBlock.XYZpos.X)
                Dim blendVec4 = New Vector2(mMotionRec.XYZpos.Z, mMotionRec.XYZpos.X)

                Dim prevModLine As New BlendCalculatorXY(blendVec1, blendVec2)
                Dim nextModLine As New BlendCalculatorXY(blendVec3, blendVec4)

                Dim dotprod As Double
                If arcOrChamfer = CornerBreakType.RadiusCorner Then
                    dotprod = CalcWindingDirection(vec1, vec2)
                    motionType = If(dotprod = 1, Motion.CWARC, Motion.CCARC)
                Else
                    motionType = Motion.LINE
                End If
                Dim trimDist = GetTrimBackDist(vec1, vec2, r_c)
                prevModLine.TrimEnd(trimDist)
                prevModLine.FindCenter(trimDist, r_c, dotprod)
                nextModLine.TrimStart(trimDist)
                priorTrimmedVec3 = New Vector3(prevModLine.P2.Y, priorCornerBlock.XYZpos.Y, prevModLine.P2.X)
                nextTrimmedVec3 = New Vector3(nextModLine.P1.Y, mMotionRec.XYZpos.Y, nextModLine.P1.X)
                curCtr = New Vector3(prevModLine.Ctr.Y, mMotionRec.XYZpos.Y, prevModLine.Ctr.X)


            Case Motion.YZ_PLN
                Return
        End Select

        blendOrChamfer = mMotionRec.ShallowCopy

        'Update the last motion record to the trimed endpoints
        priorCornerBlock.XYZpos = priorTrimmedVec3
        mPrevTransXYZ = mMotionRec.XYZpos
        mMotionRec.PriorMotion = blendOrChamfer
        mMotionRec.XYZold = nextTrimmedVec3
        mTransXYZ = nextTrimmedVec3

        With blendOrChamfer
            .PriorMotion = priorCornerBlock
            .OffsetString = WorldOffset.WoldldString
            .Codestring = arcOrChamfer.ToString
            .MotionType = motionType 'arc or line
            .ArcPlane = mArcPlane
            .Linenumber = priorCornerBlock.Linenumber
            .Index = priorCornerBlock.Index
            'define start of arc
            .XYZold = priorTrimmedVec3

            'define the end of the inserted arc
            .XYZpos = nextTrimmedVec3

            'Define the center
            .XYZcenter = curCtr
            Calc_Arc_Angles(.XYZpos, .XYZold, .XYZcenter, .Sang, .Eang, motionType)

            'Arc info
            .Rad = r_c
        End With

        'Insert the blend or chamfer into the collection
        mMotionRecs.Insert(priorCornerBlock.Index + 1, blendOrChamfer)
        mMotionRec.Index += 1
        mMode = mMotionRec.MotionType
    End Sub

    Private Function CalcWindingDirection(vec1 As Vector2, vec2 As Vector2) As Double
        If vec1.Length = 0 OrElse vec2.Length = 0 Then Return 0
        Dim arcDirDotProd As Double = CrossProd(vec1, vec2) 'This must be either -1 or +1
        Return If(arcDirDotProd < 0, -1, 1)
    End Function

    Private Function GetTrimBackDist(vec1 As Vector2, vec2 As Vector2, r_c As Double) As Double
        Dim hypot, ang As Double
        ang = AngleBetween2D(vec1, vec2) / 2
        hypot = r_c / Math.Cos(ang)
        Return Math.Sqrt((hypot ^ 2) - (r_c ^ 2))
    End Function

    Private Sub AddMotionRecord(lnPos As Integer)
        If mMotionRec Is Nothing Then
            mMotionRec = New clsMotionRecord
            mMotionRec.PriorMotion = mMotionRec
        Else
            mMotionRec = mMotionRec.ShallowCopy 'New clsMotionRecord
        End If
        ConfigureMotionRecord(lnPos)
        mMotionRecs.Add(mMotionRec)
        Array.Copy(mRegisters, mLastRegisters, mRegisters.Length)
    End Sub

    Private Sub ConfigureMotionRecord(lnPos As Integer)
        If mMode = Motion.HOLE_I Then
            mDrillClear = mInitialZBeforeDrill
        End If
        If mMode = Motion.HOLE_R Then
            mDrillClear = mRegisters(AlphaChars.R)
        End If

        With mMotionRec
            .Index = mMotionRecs.Count
            .Units = mCurrentUnits
            .ProgIndex = mCurSubIndex
            .Linenumber = lnPos
            .CharPos = mWordMatchIndex
            .ArcPlane = mArcPlane
            .Tool = mTool
            .DrawColor = DrawColor
            .Codestring = mCodeBlock.Text
            .OffsetString = WorldOffset.WoldldString
            .WorldShift = WorldOffset.TransformType

            'New position should only reflect an axis that moves
            If mBlockCausesAxisMove Then
                ShiftMotion() 'updates mTransXYZ
                .MotionType = mMode

                'Apply the transladed moves only in the axis that has movement
                If WorldOffset.IsRotated Then
                    mToolPosXYZ = mTransXYZ
                Else
                    If mBlockHasAddress(AlphaChars.X) Or mBlockHasAddress(AlphaChars.U) Then
                        mToolPosXYZ.X = mTransXYZ.X
                    End If
                    If mBlockHasAddress(AlphaChars.Y) Or mBlockHasAddress(AlphaChars.V) Then
                        mToolPosXYZ.Y = mTransXYZ.Y
                    End If
                    If mBlockHasAddress(AlphaChars.Z) Or mBlockHasAddress(AlphaChars.W) Then
                        mToolPosXYZ.Z = mTransXYZ.Z
                    End If
                End If

                .XYZpos = mToolPosXYZ
                mPrevTransXYZ = mTransXYZ

                .OldRotaryPos = mPrevABC
                .XYZcenter.X = mTransArcCenter.X
                .XYZcenter.Y = mTransArcCenter.Y
                .XYZcenter.Z = mTransArcCenter.Z

                .Rotate = mBlockRotating
                .NewRotaryPos = mRotaryMoveABC
                .RotaryDir = mRotDir ' * mcurmachine.nRotaryDir

                'Arc info
                .Rad = mArcData(ArcData.ARC_RAD)
                .Sang = mArcData(ArcData.ANGLE_1)
                .Eang = mArcData(ArcData.ANGLE_2)

                ''TODO encorporate rotation in work offset
                .Rpoint = WorldOffset.ApplyZ(mRegisters(AlphaChars.R))
                .DrillClear = WorldOffset.ApplyZ(mDrillClear)


                .Comp = mComp
                'Feeds and speeds
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


                mMaxX = Math.Max(.XYZpos.X, mMaxX)
                mMaxY = Math.Max(.XYZpos.Y, mMaxY)
                mMaxZ = Math.Max(.XYZpos.Z, mMaxZ)
                mMinX = Math.Min(.XYZpos.X, mMinX)
                mMinY = Math.Min(.XYZpos.Y, mMinY)
                mMinZ = Math.Min(.XYZpos.Z, mMinZ)
            Else
                .MotionType = Motion.NONE
            End If

        End With


        'RaiseEvent AfterMotionRecAdded(mRegisters, mArcData)

    End Sub

    Private Sub ShiftMotion()
        'if the world has been shifted then update the values
        mTransXYZ = New Vector3(mRegisters(AlphaChars.X), mRegisters(AlphaChars.Y), mRegisters(AlphaChars.Z))
        WorldOffset.Apply(mTransXYZ)
        If mMode = Motion.CCARC Or mMode = Motion.CWARC Then
            're-calculate zpos if helix using k for pitch
            If mRegisters(AlphaChars.K) <> 0 AndAlso mArcPlane = Motion.XY_PLN Then
                If mArcData(ArcData.ANGLE_1) = mArcData(ArcData.ANGLE_2) Then
                    mTransXYZ.Z += mRegisters(AlphaChars.K)
                Else
                    mTransXYZ.Z += (mRegisters(AlphaChars.K) * (Math.Abs(mArcData(ArcData.ANGLE_1) - mArcData(ArcData.ANGLE_2))) / ONE_RADIAN)
                End If
                mToolPosXYZ.Z = mTransXYZ.Z

            End If
            Calc_Arc_Center(mPrevTransXYZ, mTransXYZ) 'Calculate arc center using translated values
            Calc_Arc_Angles(mTransXYZ, mPrevTransXYZ, mTransArcCenter, mArcData(ArcData.ANGLE_1), mArcData(ArcData.ANGLE_2), mMode)
        End If
    End Sub
    Private Function TryDoubleParse(s As String) As Double
        Dim ret As Double = 0
        Double.TryParse(s, Globalization.NumberStyles.Number, Globalization.CultureInfo.InvariantCulture, ret)
        Return ret
    End Function

    Private Function DoubleParse(s As String, Optional precision As Integer = 0) As Double
        If s.Contains(".") Then 'decimal place
            Return Double.Parse(s, Globalization.NumberFormatInfo.InvariantInfo)
        Else

            Return Integer.Parse(s, Globalization.NumberFormatInfo.InvariantInfo) * (10 ^ -precision) 'convert a number from a 4 place
        End If
    End Function

    Public Sub ProcessFile(ncFile As String, gfxRecs As List(Of clsMotionRecord), prgs As System.Collections.Generic.List(Of clsProg))
        Dim sFileContents As String
        mNcProgs = prgs
        Using MyReader As New IO.StreamReader(ncFile)
            sFileContents = Me.FilterJunk(MyReader.ReadToEnd())
        End Using
        ProcessText(ncFile, sFileContents, gfxRecs, mNcProgs)
    End Sub

    Public Sub ProcessText(sFileName As String, sFileContents As String, gfxRecs As List(Of clsMotionRecord), ByRef prgs As List(Of clsProg), Optional worker As System.ComponentModel.BackgroundWorker = Nothing)
        mCancelParse = False
        mNcProgs = prgs
        mWorker = worker
        mMotionRecs = gfxRecs
        mParseErrors.Clear()
        mParseErrorsIndex = -1
        mToolNumbers.Clear()
        mG54Offset.PrimaryAddress = mWords.IgnoreOffsetNonModal
        mG54Offset.Reset()
        mG92Offset.Reset()
        mG52Offset.Reset()
        WorldOffset.TransformType = BlockShiftType.NoShift
        mMirrorOneAxisActive = False

        mCurrentUnits = mCurMachine.MachineUnits
        SetUnitsConversionFactor()

        'Init the world with the view shift 
        WorldOffset.Init(mCurMachine.ViewShift(0) * mUnitsConversion,
                         mCurMachine.ViewShift(1) * mUnitsConversion,
                         (mCurMachine.ViewShift(2) + mCurMachine.Rotary1Radius) * mUnitsConversion, mG54Offset)

        mPrevTransXYZ = New Vector3(0, 0, 0)
        mTransXYZ = New Vector3(0, 0, 0)
        mToolPosXYZ = New Vector3(0, 0, 0)
        mTransArcCenter = New Vector3(0, 0, 0)
        'mPrevRot = New Vector3(0, 0, 0)
        If String.IsNullOrEmpty(sFileName) Then
            Throw New ArgumentNullException("sFileName")
        End If

        If String.IsNullOrEmpty(sFileContents) Then
            Throw New ArgumentNullException("sFileContents")
        End If

        mCurProg = New clsProg(mCurMachine.BlockSkip, mCurMachine.Comments, IgnoreWhitespace)

        mCurProg.FileName = sFileName

        InitMotionWithMachineSettings(sFileName)

        'Reset all positions.
        mMotionRecs.Clear()
        mMotionRec = Nothing
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

        mPrevABC = 0
        mRotaryMoveABC = 0
        mRotaryAxisLabel = WordLabelFromString(mWords.Rotary.Label)

        mRegisters(AlphaChars.R) = 0
        mRegisters(AlphaChars.S) = 0
        mDrillClear = 0
        mRotDir = 1
        mAbsOrInc = IncAbsMode.ABS
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

        mDrillReturnMode = DrillReturn.RETURN_TO_I_PLN

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
        mEndsub = mCurMachine.SubReturn.Trim
        mSubcall = mCurMachine.ExternalCall.Trim
        mInternalSubcall = mCurMachine.InternalCall
        mInternalSubParam = mCurMachine.InternalCallParam
        mRepeatsLabel = mCurMachine.SubRepeats.Trim.ToCharArray()(0)

        If mCurMachine.InvertArcCenterValues Then
            mIJK_Invert = -1
        Else
            mIJK_Invert = 1
        End If
        mMaxX = Double.MinValue
        mMaxY = Double.MinValue
        mMaxZ = Double.MinValue
        mMinX = Double.MaxValue
        mMinY = Double.MaxValue
        mMinZ = Double.MaxValue


        mInternalCallParam = Asc(mCurMachine.InternalCallParam) - 65
        mExternalCallParam = Asc(mCurMachine.ExternalCallParam) - 65


        'Do global replacements
        DoGlobalReplacements(sFileContents)
        RaiseEvent OnParseStart(Me, False)

        mNcProgs.Clear()
        mMainProg = Nothing
        mGlobalProg = Nothing
        mCurProg = CreateNcProgs(sFileContents, sFileName)
        mLineNumber = 1
        mTotalBites = 0

        'We ignore tool color when we are comparing
        If Not mIgnoreToolColor Then
            DrawColor = Drawing.Color.Blue
        End If
        mCannedCycle.Value = -1
        mCurSubIndex = mNcProgs.IndexOf(mCurProg)
        mLastRegisters(AlphaChars.X) = mCurMachine.HomeValues(0) / mLatheDiaRadFactor
        mLastRegisters(AlphaChars.Y) = mCurMachine.HomeValues(1)
        mLastRegisters(AlphaChars.Z) = mCurMachine.HomeValues(2)

        mRegisters(AlphaChars.X) = mLastRegisters(AlphaChars.X)
        mRegisters(AlphaChars.Y) = mLastRegisters(AlphaChars.Y)
        mRegisters(AlphaChars.Z) = mLastRegisters(AlphaChars.Z)
        mInitialZBeforeDrill = mRegisters(AlphaChars.Z)
        mCodeBlock.Create("START", 0, 5, 0)
        AddMotionRecord(0)

        ProcessSub(mCurProg)
        'Now process any remaining un-called subs
        For Each p As clsProg In mNcProgs
            If p.TimesCalled = 0 Then
                mCurSubIndex = mNcProgs.IndexOf(p)
                ProcessSub(p)
            End If
        Next
        CalcMaxAxis()
    End Sub

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
    Private Sub SetUnitsConversionFactor()
        If mCurrentUnits = MachineUnits.METRIC Then
            mUnitsConversion = 0.0393701F
        Else
            mUnitsConversion = 1.0F
        End If
    End Sub

    Private Sub InitMotionWithMachineSettings(sFileName As String)

        With mWords
            .UnitsEnglish.Label = mCurMachine.UnitsEnglishAddress.Chars(0)
            .UnitsEnglish.Value = TryDoubleParse(mCurMachine.UnitsEnglishAddress.Substring(1))

            .UnitsMetric.Label = mCurMachine.UnitsMetricAddress.Chars(0)
            .UnitsMetric.Value = TryDoubleParse(mCurMachine.UnitsMetricAddress.Substring(1))

            .FeedModeMin.Label = mCurMachine.FeedModeMin.Chars(0)
            .FeedModeMin.Value = TryDoubleParse(mCurMachine.FeedModeMin.Substring(1))
            .FeedModeRev.Label = mCurMachine.FeedModeRev.Chars(0)
            .FeedModeRev.Value = TryDoubleParse(mCurMachine.FeedModeRev.Substring(1))

            .SpeedModeRPM.Label = mCurMachine.SpeedModeRPM.Chars(0)
            .SpeedModeRPM.Value = TryDoubleParse(mCurMachine.SpeedModeRPM.Substring(1))
            .SpeedModeSFPM.Label = mCurMachine.SpeedModeSFM.Chars(0)
            .SpeedModeSFPM.Value = TryDoubleParse(mCurMachine.SpeedModeSFM.Substring(1))

            .SpeedLimit.Label = mCurMachine.MaxRpmAddress.Chars(0)
            .SpeedLimit.Value = TryDoubleParse(mCurMachine.MaxRpmAddress.Substring(1))

            .SubCall.Label = mCurMachine.ExternalCall.Chars(0)
            .SubCall.Value = TryDoubleParse(mCurMachine.ExternalCall.Substring(1))
            .SubCallParam.Label = mCurMachine.ExternalCallParam.Chars(0)
            .SubCallParam.Value = TryDoubleParse(mCurMachine.ExternalCallParam.Substring(1))

            .LocalSubCall.Label = mCurMachine.InternalCall.Chars(0)
            .LocalSubCall.Value = TryDoubleParse(mCurMachine.InternalCall.Substring(1))
            .LocalSubCallParam.Label = mCurMachine.InternalCallParam.Chars(0)
            .LocalSubCallParam.Value = TryDoubleParse(mCurMachine.InternalCallParam.Substring(1))

            .SubReturn.Label = mCurMachine.SubReturn.Chars(0)
            .SubReturn.Value = TryDoubleParse(mCurMachine.SubReturn.Substring(1))

            .Abs.Label = mCurMachine.Absolute.Chars(0)
            .Abs.Value = TryDoubleParse(mCurMachine.Absolute.Substring(1))
            .CCArc.Label = mCurMachine.CCArc.Chars(0)
            .CCArc.Value = TryDoubleParse(mCurMachine.CCArc.Substring(1))
            .CWArc.Label = mCurMachine.CWArc.Chars(0)
            .CWArc.Value = TryDoubleParse(mCurMachine.CWArc.Substring(1))

            .Inc.Label = mCurMachine.Incremental.Chars(0)
            .Inc.Value = TryDoubleParse(mCurMachine.Incremental.Substring(1))

            .IncIJK.Label = mCurMachine.IncIJK.Chars(0)
            .IncIJK.Value = TryDoubleParse(mCurMachine.IncIJK.Substring(1))
            .AbsIJK.Label = mCurMachine.AbsIJK.Chars(0)
            .AbsIJK.Value = TryDoubleParse(mCurMachine.AbsIJK.Substring(1))

            .CompLeft.Label = mCurMachine.CompLeft.Chars(0)
            .CompLeft.Value = TryDoubleParse(mCurMachine.CompLeft.Substring(1))

            .CompRight.Label = mCurMachine.CompRight.Chars(0)
            .CompRight.Value = TryDoubleParse(mCurMachine.CompRight.Substring(1))

            .CompCancel.Label = mCurMachine.CompCancel.Chars(0)
            .CompCancel.Value = TryDoubleParse(mCurMachine.CompCancel.Substring(1))

            .Linear.Label = mCurMachine.Linear.Chars(0)
            .Linear.Value = TryDoubleParse(mCurMachine.Linear.Substring(1))

            .Rapid.Label = mCurMachine.Rapid.Chars(0)
            .Rapid.Value = TryDoubleParse(mCurMachine.Rapid.Substring(1))

            .Rotary.Label = mCurMachine.Rotary.Chars(0)
            .Rotary.Value = 0

            .DrillRapid.Label = mCurMachine.DrillRapid.Chars(0)
            .DrillRapid.Value = 0

            .Plane(0).Label = mCurMachine.XYplane.Chars(0)
            .Plane(0).Value = TryDoubleParse(mCurMachine.XYplane.Substring(1))
            .Plane(1).Label = mCurMachine.XZplane.Chars(0)
            .Plane(1).Value = TryDoubleParse(mCurMachine.XZplane.Substring(1))
            .Plane(2).Label = mCurMachine.YZplane.Chars(0)
            .Plane(2).Value = TryDoubleParse(mCurMachine.YZplane.Substring(1))

            .ReturnLevel(0).Label = mCurMachine.ReturnLevel(0).Chars(0)
            .ReturnLevel(0).Value = TryDoubleParse(mCurMachine.ReturnLevel(0).Substring(1))
            .ReturnLevel(1).Label = mCurMachine.ReturnLevel(1).Chars(0)
            .ReturnLevel(1).Value = TryDoubleParse(mCurMachine.ReturnLevel(1).Substring(1))

            .ToolChange.Label = mCurMachine.ToolChange.Chars(0)
            .ToolChange.Value = TryDoubleParse(mCurMachine.ToolChange.Substring(1))

            .GoHome.Label = mCurMachine.HomeCommand.Chars(0)
            .GoHome.Value = TryDoubleParse(mCurMachine.HomeCommand.Substring(1))

            For r As Integer = 0 To .Drills.Length - 1
                If mCurMachine.Drills(r).Length > 2 Then
                    .Drills(r).Label = mCurMachine.Drills(r).Chars(0)
                    .Drills(r).Value = TryDoubleParse(mCurMachine.Drills(r).Substring(1))
                End If
            Next

            'Work offsets and G92
            If mCurMachine.WorkOffsetTemp.Length > 1 Then
                .G92.Label = mCurMachine.WorkOffsetTemp.Chars(0)
                .G92.Value = TryDoubleParse(mCurMachine.WorkOffsetTemp.Substring(1))
            End If

            '52
            If mCurMachine.WorkOffsetG52.Length > 1 Then
                .G52.Label = mCurMachine.WorkOffsetG52.Chars(0)
                .G52.Value = TryDoubleParse(mCurMachine.WorkOffsetG52.Substring(1))
            End If
            '51
            If mCurMachine.G51ScaleOn.Length > 1 Then
                .G51.Label = mCurMachine.G51ScaleOn.Chars(0)
                .G51.Value = TryDoubleParse(mCurMachine.G51ScaleOn.Substring(1))
            End If

            '50
            If mCurMachine.G51ScaleOff.Length > 1 Then
                .G50.Label = mCurMachine.G51ScaleOff.Chars(0)
                .G50.Value = TryDoubleParse(mCurMachine.G51ScaleOff.Substring(1))
            End If
            '51.1
            If mCurMachine.MirrorOn.Length > 1 Then
                .G51_1.Label = mCurMachine.MirrorOn.Chars(0)
                .G51_1.Value = TryDoubleParse(mCurMachine.MirrorOn.Substring(1))
            End If
            '50.1
            If mCurMachine.MirrorOff.Length > 1 Then
                .G50_1.Label = mCurMachine.MirrorOff.Chars(0)
                .G50_1.Value = TryDoubleParse(mCurMachine.MirrorOff.Substring(1))
            End If

            '68
            If mCurMachine.G68RotOn.Length > 1 Then
                .G68.Label = mCurMachine.G68RotOn.Chars(0)
                .G68.Value = TryDoubleParse(mCurMachine.G68RotOn.Substring(1))
            End If

            '70
            If mCurMachine.G68RotOff.Length > 1 Then
                .G69.Label = mCurMachine.G68RotOff.Chars(0)
                .G69.Value = TryDoubleParse(mCurMachine.G68RotOff.Substring(1))
            End If

            'G53
            If mCurMachine.WorkOffsetCancel.Length > 1 Then
                .IgnoreOffsetNonModal.Label = mCurMachine.WorkOffsetCancel.Chars(0)
                .IgnoreOffsetNonModal.Value = TryDoubleParse(mCurMachine.WorkOffsetCancel.Substring(1))
            End If

            'G10
            If mCurMachine.AllowG10 Then
                .G10L2PooXYZ.Label = "G"
                .G10L2PooXYZ.Value = 10
            End If
            .WrkOffsets.Clear()

            Try
                'look in the same folder as the source file for an offsets file.
                Dim lines As String() = {}
                If Not String.IsNullOrEmpty(sFileName) Then
                    Dim srcFldr As String = IO.Path.GetDirectoryName(sFileName)
                    Dim offsetsFile As String = IO.Path.Combine(srcFldr, "WorkOffsets.txt")
                    If IO.File.Exists(offsetsFile) Then
                        'Parse the file and read the offsets
                        lines = IO.File.ReadAllLines(offsetsFile)
                        RaiseEvent OnMsgInfo("WorkOffsets from:" & offsetsFile)
                        AddOrUpdateWorkOffsetsFromLines(lines)
                    End If
                End If
                If lines.Length = 0 Then
                    lines = mCurMachine.WorkOffsets.Split(CType(vbCrLf, Char()), StringSplitOptions.RemoveEmptyEntries)
                    RaiseEvent OnMsgInfo("WorkOffsets from:" & mCurMachine.Name)
                    AddOrUpdateWorkOffsetsFromLines(lines)
                End If
            Catch ex As Exception
                RaiseEvent OnParseError(0, "Format error in work offsets data.")
            End Try
        End With


    End Sub

    Private Sub AddOrUpdateWorkOffsetsFromLines(lines() As String)
        Dim vals As String()
        If lines Is Nothing Or lines.Length = 0 Then
            lines = {"G54,0,0,0,0"}
        End If

        mPriWrkAddress = Integer.MinValue
        mSecWrkAddress = Integer.MinValue
        For Each ln As String In lines
            vals = ln.Split(","c)
            Dim wadd As New WrkOffset
            Dim words = Regex.Matches(vals(0), "([A-Z]{1,2})([-+]?[0-9]*[\.,]*[0-9]*)")
            Dim pri = String.Empty
            Dim sec = String.Empty
            If words.Count > 0 Then
                pri = words(0).Value
                wadd.PrimaryAddress.Label = pri.Chars(0)
                wadd.PrimaryAddress.Value = TryDoubleParse(pri.Substring(1))
                'G54 G55 ...
                mPriWrkAddress = wadd.PrimaryAddress.AddressArrayIndex
                If words.Count > 1 Then 'G57 H92 ...
                    sec = words(1).Value
                    wadd.SecondaryAddress.Label = sec.Chars(0)
                    wadd.SecondaryAddress.Value = TryDoubleParse(sec.Substring(1))
                    mSecWrkAddress = wadd.SecondaryAddress.AddressArrayIndex
                End If

                wadd.X = Double.Parse(vals(1), Globalization.CultureInfo.InvariantCulture.NumberFormat)
                wadd.Y = Double.Parse(vals(2), Globalization.CultureInfo.InvariantCulture.NumberFormat)
                wadd.Z = Double.Parse(vals(3), Globalization.CultureInfo.InvariantCulture.NumberFormat)
                wadd.A = Double.Parse(vals(4), Globalization.CultureInfo.InvariantCulture.NumberFormat)
                If vals.Length = 7 Then
                    wadd.B = Double.Parse(vals(5), Globalization.CultureInfo.InvariantCulture.NumberFormat)
                    wadd.C = Double.Parse(vals(6), Globalization.CultureInfo.InvariantCulture.NumberFormat)
                End If

                Dim existingWadd = mWords.WrkOffsets.Find(Function(x) x.Match(pri, sec))
                If existingWadd IsNot Nothing Then
                    existingWadd.X = wadd.X
                    existingWadd.Y = wadd.Y
                    existingWadd.Z = wadd.Z
                    existingWadd.A = wadd.A
                    existingWadd.B = wadd.B
                    existingWadd.C = wadd.C
                Else
                    mWords.WrkOffsets.Add(wadd)
                End If
            End If
            RaiseEvent OnMsgInfo(ln)
        Next
    End Sub

    Private mMaxAxis As Double
    Public ReadOnly Property MaxAxis() As Double
        Get
            Return mMaxAxis
        End Get
    End Property

    Private Sub CalcMaxAxis()
        mMaxAxis = Math.Max(Math.Abs(mMaxX), mMaxAxis)
        mMaxAxis = Math.Max(Math.Abs(mMaxY), mMaxAxis)
        mMaxAxis = Math.Max(Math.Abs(mMaxZ), mMaxAxis)

        mMaxAxis = Math.Max(Math.Abs(mMinX), mMaxAxis)
        mMaxAxis = Math.Max(Math.Abs(mMinY), mMaxAxis)
        mMaxAxis = Math.Max(Math.Abs(mMinZ), mMaxAxis)

        'mScalePerfFactor = CSng(1.0F / Math.Floor(mMaxAxis / (maxVal / 2)))
        'For Each m As clsMotionRecord In mMotionRecs
        '    With m
        '        .Rad *= mScalePerfFactor
        '        .Rpoint *= mScalePerfFactor
        '        .XYZcenter.x *= mScalePerfFactor
        '        .XYZold.x *= mScalePerfFactor
        '        .XYZpos.X *= mScalePerfFactor
        '        .XYZcenter.y *= mScalePerfFactor
        '        .XYZold.y *= mScalePerfFactor
        '        .XYZpos.Y *= mScalePerfFactor
        '        .XYZcenter.z *= mScalePerfFactor
        '        .XYZold.z *= mScalePerfFactor
        '        .XYZpos.Z *= mScalePerfFactor
        '    End With
        'Next

    End Sub

    Private Function GatherCannedCycles(machineName As String) As Integer
        mCannedCycles.Clear()
        mCannedCycleFileNames.Clear()
        If String.IsNullOrEmpty(CannedCyclesFolder) Then Return 0
        Dim fldr As String = CannedCyclesFolder
        fldr = IO.Path.Combine(fldr, machineName)
        Dim fileNameWithoutExtension As String
        If IO.Directory.Exists(fldr) Then
            Dim fls() As String = IO.Directory.GetFiles(fldr, "*.txt", IO.SearchOption.TopDirectoryOnly)
            For Each f As String In fls
                fileNameWithoutExtension = IO.Path.GetFileNameWithoutExtension(f)
                Dim a As New Address
                a.Label = fileNameWithoutExtension.Chars(0)
                a.Value = TryDoubleParse(fileNameWithoutExtension.Substring(1))
                mCannedCycles.Add(a)
                mCannedCycleFileNames.Add(f)
            Next
        End If
        Return mCannedCycles.Count
    End Function


    Private mCannedCyclesFolder As String
    Public Property CannedCyclesFolder() As String
        Get
            Return mCannedCyclesFolder
        End Get
        Set(value As String)
            mCannedCyclesFolder = value
            If Not mCannedCyclesFolder.EndsWith("\") Then
                mCannedCyclesFolder += "\"
            End If
        End Set
    End Property

    Private Function CreateNcProgs(sFileContents As String, sFileName As String) As clsProg
        Dim lastIndex As Integer = -1
        Dim thisIndex As Integer = -1
        Dim p As clsProg
        Dim retProg As clsProg = Nothing
        Dim startOfProgLineNum As Integer = 0
        Dim startProg As Integer = -1
        Dim lineIndex As Integer = 0
        Dim m As Match = mRegSubs.Match(sFileContents)
        'Dim mLines = mRegNewLines.Matches(sFileContents)
        Dim progMatch As Match = Nothing
        Dim endOfLastSubIdx As Integer = 0
        'First find progs with a M30 or M99
        Do While m.Success
            If m.Groups("CMT").Success Then
                Dim commentLines = mRegNewLines.Matches(m.Value).Count
                lineIndex += commentLines
                m = m.NextMatch()
                Continue Do
            End If
            If m.Groups("EOL").Success Then
                lineIndex += 1
                m = m.NextMatch()
                Continue Do
            End If

            If m.Groups("PROG").Success Then
                If progMatch IsNot Nothing Then 'we already are in a program so we shouldn't be here
                    mParseErrors.Add(New clsParseError(sFileName, m.Index, lineIndex, "Unexpected program label"))
                Else
                    startOfProgLineNum = lineIndex
                    progMatch = m
                End If
            Else
                If m.Groups("M30").Success Then
                    CreateProg(progMatch, endOfLastSubIdx, m, True, startOfProgLineNum, sFileName, sFileContents)
                    startOfProgLineNum = lineIndex + 1
                    endOfLastSubIdx = m.Index + m.Length
                    progMatch = Nothing
                    retProg = mNcProgs.Last
                    mMainProg = retProg
                Else
                    If m.Groups("M99").Success Then
                        CreateProg(progMatch, endOfLastSubIdx, m, False, startOfProgLineNum, sFileName, sFileContents)
                        startOfProgLineNum = lineIndex + 1
                        endOfLastSubIdx = m.Index + m.Length
                        If progMatch Is Nothing Then
                            mGlobalProg = mNcProgs.Last
                        End If
                        progMatch = Nothing
                    End If
                End If
            End If
            m = m.NextMatch()
        Loop

        'Just add all the text we found in the file if we hav no progs
        If mNcProgs.Count = 0 Then
            p = New clsProg(mCurMachine.BlockSkip, mCurMachine.Comments, IgnoreWhitespace)
            p.Main = True
            p.Label = "MAIN"
            p.Value = 0.0F
            p.Contents = sFileContents
            p.FileName = sFileName
            p.StartLine = 0
            p.StartChar = 0
            mNcProgs.Add(p)
            retProg = p
        End If
        Return retProg

    End Function

    Private Sub CreateProg(pm As Match, endOfLastSubIdx As Integer, m30m99 As Match, isMain As Boolean, startLine As Integer, sFilePath As String, sFileContents As String)
        Dim lbl As String = "MAIN"
        Dim progVal As Double = 0.0F
        Dim startIdx = endOfLastSubIdx
        If pm IsNot Nothing Then
            lbl = [Char].ToUpper(pm.Value(0))
            progVal = DoubleParse(pm.Groups(1).Value)
            startIdx = pm.Index + pm.Length
        Else
            lbl = IO.Path.GetFileName(sFilePath)
        End If

        Dim endIdx = m30m99.Index
        Dim len = endIdx - startIdx

        Dim p = New clsProg(mCurMachine.BlockSkip, mCurMachine.Comments, IgnoreWhitespace)
        p.Main = isMain
        p.Label = lbl
        p.Value = progVal
        p.StartChar = startIdx
        p.StartLine = startLine
        p.FileName = sFilePath
        p.Contents = sFileContents.Substring(startIdx, len)
        mNcProgs.Add(p)
    End Sub

    Private Function FindSubByName(curProg As clsProg, val As String) As clsProg
        For Each p As clsProg In mNcProgs
            If p.Label = val Then Return p
        Next

        If curProg Is Nothing Then Return Nothing
        'If we get here then we should look for an external sub
        Dim fldr As String = IO.Path.GetDirectoryName(curProg.FileName)
        Dim fl As String

        Dim fls() As String = IO.Directory.GetFiles(fldr, val.ToString() & ".*", IO.SearchOption.TopDirectoryOnly)
        If fls.Length > 0 Then
            fl = fls(0)
            If IO.File.Exists(fl) Then
                CreateNcProgs(IO.File.ReadAllText(fl), fl)
            End If

            For Each p As clsProg In mNcProgs
                If p.Label = val Then Return p
            Next
        End If
        Return Nothing
    End Function

    Private Function FindSubByValue(curProg As clsProg, val As Double) As clsProg
        For Each p As clsProg In mNcProgs
            If p.Value = val Then Return p
        Next

        If curProg Is Nothing Then Return Nothing
        'If we get here then we should look for an external sub
        Dim fldr As String = IO.Path.GetDirectoryName(curProg.FileName)
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

    Private Sub FindAllSequenceNumbers(p As clsProg)
        Dim ncWord As Match
        Dim blockSkipped As Boolean = False
        Dim lnPos As Integer = p.StartLine
        If p.SequenceNumbers.Count > 0 Then Return

        ncWord = p.GetNextMatch(0)

        While ncWord.Success
            If ncWord.Value.EndsWith(vbLf) Then 'Is this a newline
                lnPos += 1
            ElseIf MatchIsComment(ncWord) Then
                'Comment could be multi line
                lnPos += mRegNewLines.Matches(ncWord.Value).Count
            ElseIf mCurMachine.BlockSkip.Contains(ncWord.Value.Chars(0)) Then
                For Each s As clsBlockSkip In BlockSkips
                    If s.Enabled Then
                        If String.Compare(s.Match, ncWord.Value) = 0 Then
                            blockSkipped = True
                            Exit For
                        End If
                    End If
                Next
            ElseIf p.IsAddress Then
                'Word
                If Not blockSkipped Then
                    Try
                        mCurAddress.Init(ncWord)
                        If mCurAddress.Label = "N" Then
                            p.SequenceNumbers.Add(New clsProg.SeqNumber(ncWord.Index, lnPos, mCurAddress.Value))
                        End If
                    Catch ex As Exception
                        mParseErrors.Add(New clsParseError(mCurProg.FileName, ncWord.Index + p.StartChar, lnPos + p.StartLine, "Failed to parse address", mCurProg.CurMatchVal))
                    End Try
                End If
            End If
            ncWord = p.GetNextMatch
        End While
    End Sub

    Private Function ShouldCancel() As Boolean
        If Not mWorker Is Nothing Then
            If mWorker.CancellationPending Then
                mCancelParse = True
            End If
        End If
        Return mCancelParse
    End Function


    Private Sub ProcessSub(p As clsProg, Optional seqNumPos As Integer = 0)
        Static percent As Integer = 0
        Dim blockSkipped As Boolean = False
        Dim ncWord As Match
        Dim progress As Integer = 0
        mSubCallType = subCallType.none
        Try
            mProgStack.Push(p)
            mCurProg = mProgStack.First
            'mCurSubIndex = mNcProgs.IndexOf(p)
            'If i pass a sequence number then we should look for a local seq destination
            'Then look in the main program like HAAS.
            'M97 P1000 = external
            'M98 H1000 = internal
            'M98 P1000 H2000 = external + internal
            'M98 = self call

            Dim contents As String = p.Contents
            Dim lnPos As Integer = p.StartLine
            mLineNumber = p.StartLine + 1
            mTotalBites += p.Contents.Length

            p.TimesCalled += 1
            Dim lastIndex As Integer = 0

            RaiseEvent OnProgStart(p.Label & p.Value.ToString, lnPos)

            ncWord = p.GetNextMatch(seqNumPos)
            If seqNumPos > 0 Then
                lnPos = p.SequenceTarget.lineNo
            End If

            While ncWord.Success

                mWordMatchIndex = ncWord.Index
                If p.IsEOL Then 'Is this a newline
                    mLineNumber += 1

                    Dim blk = contents.Substring(lastIndex, ncWord.Index - lastIndex).Trim
                    mCodeBlock.Create(blk, lastIndex + p.StartChar, ncWord.Index - lastIndex + 1, mLineNumber)
                    EvaluateAllBlockWords(blockSkipped, lnPos, p)
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
                    If ShouldCancel() Then Exit While

                ElseIf p.IsComment Then
                    'Comment
                    Dim commentLines = mRegNewLines.Matches(ncWord.Value).Count
                    lnPos += commentLines
                    mLineNumber += commentLines
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
                ElseIf p.IsAddress Then
                    'Word
                    If Not blockSkipped Then
                        Try
                            If mCurAddress.Init(ncWord) Then
                                EvaluateWordForMotion()
                            Else
                                mParseErrors.Add(New clsParseError(p.FileName, p.GetLastMatchIndex, lnPos, "Failed to parse", ncWord.Value))
                            End If
                        Catch ex As Exception
                            mParseErrors.Add(New clsParseError(p.FileName, p.GetLastMatchIndex, lnPos, ex.Message, ncWord.Value))
                        End Try
                    End If
                End If
                If String.Compare(mEndmain, ncWord.Value, True) = 0 Then
                    Exit While
                End If
                If String.Compare(mEndsub, ncWord.Value, True) = 0 Then
                    Exit While
                End If
                If p.IsError Then
                    mParseErrors.Add(New clsParseError(p.FileName, p.MatchPositionInFile, lnPos + 1, "Failed to parse", ncWord.Value))
                End If

                ncWord = p.GetNextMatch
            End While

            'We have a remaining line
            If mBlockHasAddress(AlphaChars.ANY) And mParseErrors.Count = 0 Then
                EvaluateAllBlockWords(blockSkipped, lnPos, p)
            End If
            mProgStack.Pop()
            If mProgStack.Count > 0 Then
                mCurProg = mProgStack.First
            End If
            RaiseEvent OnProgEnd(p.Label & p.Value.ToString, lnPos)

        Catch ex As Exception
            mParseErrors.Add(New clsParseError(p.FileName, mCodeBlock.StartIndex + p.StartChar, mLineNumber, ex.Message, p.CurMatchVal))
            RaiseEvent OnParseError(mLineNumber, ex.Message)
        End Try
    End Sub

    Private Sub EvaluateAllBlockWords(ByRef blockSkipped As Boolean, ByRef lnPos As Integer, p As clsProg)
        Dim localSubIndex As Integer = mCurSubIndex
        Dim seqNumTargetPos As Integer = 0
        Dim subReps As Integer
        If mCancelParse Then Return

        lnPos += 1
        Select Case mSubCallType
            Case subCallType.none
                If WorldOffset.TransformType = BlockShiftType.NoShift Then
                    For r As Integer = 1 To mReps
                        EvaluateBlockRegisters(lnPos)
                    Next
                Else
                    EvaluateBlockRegisters(lnPos)
                End If
                ResetGcodeBlock()
            Case subCallType.external_M98
                If Not blockSkipped Then
                    'M98 H could be a local call if it has an H only
                    'M98 P H. Use the next word value as the sub name
                    AddMotionRecord(lnPos)
                    If mBlockHasAddress(mExternalCallParam) Then
                        Dim targetSubVal = EvalubTargetParam(mExternalCallParam, mReps)
                        Dim retProg As clsProg = FindSubByValue(p, targetSubVal)
                        subReps = mReps
                        mReps = 1
                        If retProg IsNot Nothing Then
                            If retProg.TimesCalled > 100 Then
                                mParseErrors.Add(New clsParseError(mCurProg.FileName, mCodeBlock.StartIndex, lnPos, "Posible infinate loop. ", mCurProg.CurMatchVal))
                                mCancelParse = True
                                Return 'Prevent infinate loop
                            End If

                            'M98 P H
                            'If mBlockHasAddress(mInternalCallParam) Then
                            '    FindAllSequenceNumbers(retProg)
                            '    seqNumTargetPos = retProg.FindSeqPos(mRegisters(mInternalCallParam))
                            'End If
                            For r As Integer = 1 To subReps
                                mCurSubIndex = mNcProgs.IndexOf(retProg)
                                ProcessSub(retProg, seqNumTargetPos) 'Call again
                            Next
                            'Restore the prog index
                            mCurSubIndex = localSubIndex
                        End If
                    Else
                        If p.TimesCalled > 100 Then
                            mParseErrors.Add(New clsParseError(mCurProg.FileName, mCodeBlock.StartIndex, lnPos, "Posible infinate loop. ", mCurProg.CurMatchVal))
                            mCancelParse = True
                            Return 'Prevent infinate loop
                        End If

                        'If mBlockHasAddress(mInternalCallParam) Then
                        '    'M98 H
                        '    FindAllSequenceNumbers(p)
                        '    seqNumTargetPos = p.FindSeqPos(mRegisters(mInternalCallParam))
                        '    subReps = mReps
                        '    mReps = 1
                        '    For r As Integer = 1 To subReps
                        '        mCurSubIndex = mNcProgs.IndexOf(p)
                        '        ProcessSub(p, seqNumTargetPos)
                        '    Next r
                        'Else
                        'M98
                        'M98 (sub.nc)
                        'M98Pmysub.ncL2
                        Dim subNameFromComment = Regex.Replace(mBlockComment, "[\();]", "")
                        Dim retProg As clsProg = FindSubByName(p, subNameFromComment)
                        If retProg IsNot Nothing Then
                            ProcessSub(retProg)
                        Else
                            mParseErrors.Add(New clsParseError(mCurProg.FileName, mCodeBlock.StartIndex, lnPos, "Cannot find sub", mCurProg.CurMatchVal))
                            mSubCallType = subCallType.none
                        End If
                        'End If
                    End If
                End If

            Case subCallType.internal_M97
                'mSubCallType = subCallType.none
                If Not blockSkipped Then
                    AddMotionRecord(lnPos)
                    'M98 H
                    'M97 H
                    If mGlobalProg IsNot Nothing Then
                        If p.TimesCalled > 100 Then
                            mParseErrors.Add(New clsParseError(mCurProg.FileName, mCodeBlock.StartIndex, lnPos, "Posible infinate loop. ", mCodeBlock.Text))
                            mCancelParse = True
                            Return 'Prevent infinate loop
                        End If
                        FindAllSequenceNumbers(mGlobalProg)
                        seqNumTargetPos = mGlobalProg.FindSeqPos(mRegisters(mInternalCallParam))
                        subReps = mReps
                        mReps = 1
                        For r As Integer = 1 To subReps
                            mCurSubIndex = mNcProgs.IndexOf(mGlobalProg)
                            ProcessSub(mGlobalProg, seqNumTargetPos)
                        Next
                        'Restore the prog index
                        mCurSubIndex = localSubIndex
                    Else
                        mParseErrors.Add(New clsParseError(mCurProg.FileName, mCodeBlock.StartIndex, lnPos, "Internal sub call > Expected " & mCurMachine.InternalCallParam, mCodeBlock.Text))
                        mSubCallType = subCallType.none
                    End If
                End If

        End Select

        mCannedCycle.Value = -1
        blockSkipped = False
        mReps = 1

        Array.Clear(mBlockHasAddress, 0, mBlockHasAddress.Length)
        mBlockComment = String.Empty
    End Sub

    Private Function EvalubTargetParam(targetParam As Integer, ByRef mReps As Integer) As Double
        Dim targetSubVal = mRegisters(targetParam)
        If targetSubVal > 9999 AndAlso mReps = 1 Then
            mReps = CInt(Math.Truncate(targetSubVal / 10000)) 'we will use the first two digits to determine the reps.
            targetSubVal = targetSubVal - (mReps * 10000) 'and the remaining digits to determine the value.
        End If
        Return targetSubVal
    End Function

    Private Sub EvaluateBlockRegisters(lnPos As Integer)
        'No valid motion code was parsed on this line so return
        If Not mBlockHasAddress(AlphaChars.ANY) Then Return

        If mCannedCycle.Value <> -1 Then
            EvalCannedCycle(lnPos)
            Return
        End If

        If mBlockHasAddress(AlphaChars.X) Then
            mParamVals(Axees.X) = mRegisters(AlphaChars.X) * mUnitsConversion
            If mAbsOrInc = IncAbsMode.INC Then 'Calculate absolute value for record
                mRegisters(AlphaChars.X) = (mParamVals(Axees.X)) + mToolPosXYZ.X ' mLastRegisters(AlphaChars.X)
            Else
                mRegisters(AlphaChars.X) = mParamVals(Axees.X)
            End If
            mRegisters(AlphaChars.X) /= mLatheDiaRadFactor
        End If

        If mBlockHasAddress(AlphaChars.Y) Then
            mParamVals(Axees.Y) = mRegisters(AlphaChars.Y) * mUnitsConversion
            If mAbsOrInc = IncAbsMode.INC Then 'Calculate absolute value for record
                mRegisters(AlphaChars.Y) = (mParamVals(Axees.Y)) + mToolPosXYZ.Y '  mLastRegisters(AlphaChars.Y)
            Else
                mRegisters(AlphaChars.Y) = mParamVals(Axees.Y)
            End If
        End If

        If mBlockHasAddress(AlphaChars.Z) Then
            mParamVals(Axees.Z) = mRegisters(AlphaChars.Z) * mUnitsConversion
            If mAbsOrInc = IncAbsMode.INC Then 'Calculate absolute value for record
                mRegisters(AlphaChars.Z) = (mParamVals(Axees.Z)) + mToolPosXYZ.Z ' mLastRegisters(AlphaChars.Z)
            Else
                mRegisters(AlphaChars.Z) = mParamVals(Axees.Z)
            End If
        End If

        If mMode = Motion.CCARC OrElse mMode = Motion.CWARC Then
            'IJK is used for axis calculations so we adjust units
            mRegisters(AlphaChars.I) *= mUnitsConversion * mCurMachine.Invert(Axees.X)
            mRegisters(AlphaChars.J) *= mUnitsConversion * mCurMachine.Invert(Axees.Y)
            mRegisters(AlphaChars.K) *= mUnitsConversion * mCurMachine.Invert(Axees.Z)
        ElseIf mMode = Motion.HOLE_I OrElse mMode = Motion.HOLE_R Then
            'R is used in drilling
            mRegisters(AlphaChars.R) *= mUnitsConversion * mCurMachine.Invert(Axees.Z)
        End If

        'U V W
        If mCurMachine.UseUVW Then
            If mBlockHasAddress(AlphaChars.U) Then
                mRegisters(AlphaChars.U) *= mUnitsConversion * mCurMachine.Invert(Axees.X)
                mRegisters(AlphaChars.X) += (mRegisters(AlphaChars.U) / mLatheDiaRadFactor)
            End If

            If mBlockHasAddress(AlphaChars.V) Then
                mRegisters(AlphaChars.V) *= mUnitsConversion * mCurMachine.Invert(Axees.Y)
                mRegisters(AlphaChars.Y) += mRegisters(AlphaChars.V)
            End If

            If mBlockHasAddress(AlphaChars.W) Then
                mRegisters(AlphaChars.W) *= mUnitsConversion * mCurMachine.Invert(Axees.Z)
                mRegisters(AlphaChars.Z) += mRegisters(AlphaChars.W)
            End If
        End If

        If mBlockHasAddress(mWords.Rotary.AddressArrayIndex) Then
            mBlockRotating = True
            If mCurMachine.RotaryType = RotaryMotionType.BMC Then '0>360 sign determines dir
                If mAbsOrInc = IncAbsMode.INC Then
                    mRotaryMoveABC = mParamVals(3) + mPrevABC - mG92Offset.A
                End If
            Else 'like CAD
                If mAbsOrInc = IncAbsMode.INC Then
                    mRotDir = Math.Sign(mRotaryMoveABC)
                    mRotaryMoveABC = mParamVals(3) + mPrevABC - mG92Offset.A
                Else
                    'In a scale that runs from zero to 360
                    'we determine the direction based on the shortest distance.
                    If Math.Abs(mRotaryMoveABC Mod ONE_RADIAN) > Math.PI AndAlso Math.Abs(mPrevABC Mod ONE_RADIAN) < Math.PI Then
                        mPrevABC += ONE_RADIAN
                    ElseIf Math.Abs(mRotaryMoveABC Mod ONE_RADIAN) < Math.PI AndAlso Math.Abs(mPrevABC Mod ONE_RADIAN) > Math.PI Then
                        mPrevABC -= ONE_RADIAN
                    End If

                    If mRotaryMoveABC < mPrevABC Then
                        mRotDir = -1
                    Else
                        mRotDir = 1
                    End If
                End If
            End If
            mRegisters(mWords.Rotary.AddressArrayIndex) = mRotaryMoveABC * mCurMachine.Invert(Axees.A)
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

        If WorldOffset.IsShiftType(BlockShiftType.DatsSetting) Then
            'Could be a G10L2PooXYZABC
            'We have G10
            'L2 ?
            If TryGetWordValue(AlphaChars.L) = 2.0F Then
                Dim pVal = TryGetWordValue(AlphaChars.P)
                If pVal >= 0 Then
                    'Set this work offset value
                    mBlockCausesAxisMove = False
                    SetWorkOffsetFromG10(pVal)
                End If
            End If
        End If

        If WorldOffset.IsShiftType(BlockShiftType.Scale) Then
            mBlockCausesAxisMove = False
            Dim scalex = BlockRegisterValueFromString(mCurMachine.G51ScaleX)
            Dim scaley = BlockRegisterValueFromString(mCurMachine.G51ScaleY)
            Dim scalez = BlockRegisterValueFromString(mCurMachine.G51ScaleZ)
            Dim arcRadScale = BlockRegisterValueFromString(mCurMachine.G51ScaleFactor) * mUnitsConversion
            WorldOffset.ScaleWorld(scalex, scaley, scalez, arcRadScale)
        End If
        If WorldOffset.IsShiftType(BlockShiftType.ScaleCancel) Then
            mBlockCausesAxisMove = False
            WorldOffset.CancelScale()
        End If
        If WorldOffset.IsShiftType(BlockShiftType.Mirror) Then
            mBlockCausesAxisMove = False
            'If mirror image is specified only for one axis on the specified plane,
            'the operation of the commands Is as follows:  
            'Arc command: The rotation direction Is reversed. 
            'Cutter compensation: The offset direction Is reversed. 
            'Coordinate system rotation: The rotation angle Is reversed
            Dim mirrorx = BlockHasAddressFromString(mCurMachine.MirrorX)
            Dim mirrory = BlockHasAddressFromString(mCurMachine.MirrorY)
            Dim mirrorz = BlockHasAddressFromString(mCurMachine.MirrorZ)
            WorldOffset.MirrorAboutAxis(mirrorx, mirrory, mirrorz)
            mMirrorOneAxisActive = WorldOffset.MirrorIsOnlyOneAxis
        End If

        If WorldOffset.IsShiftType(BlockShiftType.MirrorCancel) Then
            mBlockCausesAxisMove = False
            Dim mirrorx = BlockHasAddressFromString(mCurMachine.MirrorX)
            Dim mirrory = BlockHasAddressFromString(mCurMachine.MirrorY)
            Dim mirrorz = BlockHasAddressFromString(mCurMachine.MirrorZ)
            WorldOffset.CancelMirrorAxis(mirrorx, mirrory, mirrorz)
            mMirrorOneAxisActive = WorldOffset.MirrorIsOnlyOneAxis
        End If

        If WorldOffset.IsShiftType(BlockShiftType.WorkOffset) Then
            WorldOffset.SetOffset(mG54Offset)
        End If

        If WorldOffset.IsShiftType(BlockShiftType.LocalShift) Then
            mBlockCausesAxisMove = False
            'G52 work offset adjust
            mG52Offset.X = mParamVals(Axees.X)
            mG52Offset.Y = mParamVals(Axees.Y)
            mG52Offset.Z = mParamVals(Axees.Z)
            mG52Offset.A = mParamVals(Axees.A)
            mG52Offset.B = mParamVals(Axees.B)
            mG52Offset.C = mParamVals(Axees.C)
            WorldOffset.AddOffset(mG52Offset)

        End If
        If WorldOffset.IsShiftType(BlockShiftType.LocalSet) Then 'G92 and work offset adjust
            mBlockCausesAxisMove = False

            'Need to account for the current position and the G92 values.
            mG92Offset.X = RegisterDelta(AlphaChars.X) * mCurMachine.Invert(Axees.X)
            mG92Offset.Y = RegisterDelta(AlphaChars.Y) * mCurMachine.Invert(Axees.Y)
            mG92Offset.Z = RegisterDelta(AlphaChars.Z) * mCurMachine.Invert(Axees.Z)
            mG92Offset.A = RegisterDelta(mWords.Rotary.AddressArrayIndex) * mCurMachine.Invert(Axees.A)
            WorldOffset.ShiftOffset(mG92Offset)

        End If
        If WorldOffset.IsShiftType(BlockShiftType.Rotate) Then
            mBlockCausesAxisMove = False
            'map to the correct address
            Dim xctr = BlockRegisterValueFromString(mCurMachine.G68RotX)
            Dim yctr = BlockRegisterValueFromString(mCurMachine.G68RotY)
            Dim angle = BlockRegisterValueFromString(mCurMachine.G68RotR, False)
            WorldOffset.SetRotationXY(xctr, yctr, 0, angle, mAbsOrInc)
        End If

        If WorldOffset.IsShiftType(BlockShiftType.RotateCancel) Then
            WorldOffset.CancelRotation()
            mMode = Motion.NONE
        End If
        If WorldOffset.IsShiftType(BlockShiftType.SuspendWorkOffset) Then
            WorldOffset.Suspend()
            ProcessG53Block()
        End If

        If WorldOffset.IsShiftType(BlockShiftType.GoHome) Then
            'Go home. Most likely a G28
            ProcessG28Block(lnPos)
        End If

        WorldOffset.IsIncremental = (mAbsOrInc = IncAbsMode.INC)

        If mBlockCausesAxisMove Then
            'Taper move so modify the last motion record
            TestBlockForTaper()
            AddMotionRecord(lnPos)
            TestBlockForCornerBreak()
            If mMotionRec.PriorMotion.CornerBreakType <> CornerBreakType.None Then
                AddCornerRecord(mMotionRec.PriorMotion)
            End If
        End If
    End Sub

    Private Sub TestBlockForTaper()
        If mCurMachine.AllowTaper Then
            If mMotionRec.MotionType = Motion.LINE AndAlso mBlockHasAddress(AlphaChars.A) Then
                ModifyRegistersForTaper(mRegisters(AlphaChars.A))
                mMotionRec.Codestring += "(ADDED ANGLE)"
            End If
        End If
    End Sub

    Private Sub EvalCannedCycle(lnPos As Integer)
        Dim callingProg As clsProg = mCurProg
        Dim cannedCycleProg As New clsProg(mCurMachine.BlockSkip, mCurMachine.Comments, IgnoreWhitespace)

        With cannedCycleProg
            .Main = False
            '.Index = 0
            .Label = mCannedCycle.ToString
            .Value = 0.0F
            .Contents = String.Empty
            .FileName = mCannedCycleFile 'mNcProgs(mCurSubIndex).FileName
            .StartLine = 0
            .StartChar = 0
        End With
        If Not mNcProgs.Contains(cannedCycleProg) Then
            mNcProgs.Add(cannedCycleProg)
        End If
    End Sub

    Private Sub ModifyRegistersForTaper(ang As Double)
        If ang = 0 Then Return

        Dim thisPos = New Vector3(mRegisters(AlphaChars.X), mRegisters(AlphaChars.Y), mRegisters(AlphaChars.Z))
        Dim lastPos = New Vector3(mLastRegisters(AlphaChars.X), mLastRegisters(AlphaChars.Y), mLastRegisters(AlphaChars.Z))

        Dim sinAng As Double = Math.Sin(Maths.ToRadians(ang))
        Dim newend = thisPos - lastPos
        Dim direction = newend
        direction.Normalise()
        Dim len = newend.Length
        Select Case mArcPlane
            Case Motion.XY_PLN
                If Math.Abs(direction.X) = 1.0F Then
                    mRegisters(AlphaChars.Y) -= len * sinAng
                    mBlockHasAddress(AlphaChars.Y) = True

                ElseIf Math.Abs(direction.Y) = 1.0F Then
                    mRegisters(AlphaChars.X) += len * sinAng
                    mBlockHasAddress(AlphaChars.X) = True

                End If
            Case Motion.XZ_PLN
                If Math.Abs(direction.Z) = 1.0F Then
                    mRegisters(AlphaChars.X) += len * sinAng
                    mBlockHasAddress(AlphaChars.X) = True

                ElseIf Math.Abs(direction.X) = 1.0F Then
                    mRegisters(AlphaChars.Z) += len * sinAng
                    mBlockHasAddress(AlphaChars.Z) = True

                End If
        End Select
    End Sub

    Private Sub Calc_Arc_Center(prevTransXYZ As Vector3, xyz As Vector3)
        Dim side_opposite As Double
        Dim meanX As Double
        Dim meanY As Double
        Dim meanZ As Double
        Dim angleToCenter As Double
        Dim quarterArc As Double
        Dim lastXyzInPln As Vector3
        Dim xyzInPln As Vector3
        Dim deltaxyz As Vector3
        Dim IJK As Vector3
        Dim plane1 As AlphaChars
        Dim plane2 As AlphaChars
        Dim plane3 As AlphaChars
        Dim arcAxis1 As ArcData
        Dim arcAxis2 As ArcData
        Dim arcAxis3 As ArcData
        Dim arcCenter(2) As Double
        Dim rScaleFactor As Double = WorldOffset.ScaleFactor
        Dim useRforRad As Boolean = mBlockHasAddress(AlphaChars.R) AndAlso (mMode = Motion.CCARC Or mMode = Motion.CWARC)  'Radius move with R

        If mCurMachine.AbsArcCenter Then 'Convert to dalta values
            Dim lam = Function(x As Double, y As Double)
                          If x <> 0 Or y <> 0 Then
                              Return (x - y) * mIJK_Invert
                          Else
                              Return 0
                          End If
                      End Function
            IJK = New Vector3(lam(mRegisters(AlphaChars.I), prevTransXYZ.X),
                                lam(mRegisters(AlphaChars.J), prevTransXYZ.Y),
                                lam(mRegisters(AlphaChars.K), prevTransXYZ.Z))
        Else
            IJK = New Vector3(mRegisters(AlphaChars.I) * mIJK_Invert,
                              mRegisters(AlphaChars.J) * mIJK_Invert,
                              mRegisters(AlphaChars.K) * mIJK_Invert)
        End If

        Select Case mArcPlane
            Case Motion.XY_PLN
                arcAxis1 = ArcData.X_CTR
                arcAxis2 = ArcData.Y_CTR
                arcAxis3 = ArcData.Z_CTR
                plane1 = AlphaChars.X
                plane2 = AlphaChars.Y
                plane3 = AlphaChars.Z
                mArcData(ArcData.ARC_RAD) = Math.Sqrt(IJK.X ^ 2 + IJK.Y ^ 2) * rScaleFactor 'calculate rad
                lastXyzInPln.X = prevTransXYZ.X
                lastXyzInPln.Y = prevTransXYZ.Y
                lastXyzInPln.Z = prevTransXYZ.Z
                xyzInPln.X = xyz.X
                xyzInPln.Y = xyz.Y
                xyzInPln.Z = xyz.Z

            Case Motion.XZ_PLN
                arcAxis1 = ArcData.X_CTR
                arcAxis2 = ArcData.Z_CTR
                arcAxis3 = ArcData.Y_CTR

                plane1 = AlphaChars.X
                plane2 = AlphaChars.Z
                plane3 = AlphaChars.Y
                mArcData(ArcData.ARC_RAD) = Math.Sqrt(IJK.X ^ 2 + IJK.Z ^ 2) * rScaleFactor 'calculate rad
                lastXyzInPln.X = prevTransXYZ.X
                lastXyzInPln.Y = prevTransXYZ.Z
                lastXyzInPln.Z = prevTransXYZ.Y
                xyzInPln.X = xyz.X
                xyzInPln.Y = xyz.Z
                xyzInPln.Z = xyz.Y

            Case Motion.YZ_PLN
                arcAxis1 = ArcData.Y_CTR
                arcAxis2 = ArcData.Z_CTR
                arcAxis3 = ArcData.X_CTR

                plane1 = AlphaChars.Y
                plane2 = AlphaChars.Z
                plane3 = AlphaChars.X
                mArcData(ArcData.ARC_RAD) = Math.Sqrt(IJK.Y ^ 2 + IJK.Z ^ 2) * rScaleFactor 'calculate rad
                lastXyzInPln.X = prevTransXYZ.Y
                lastXyzInPln.Y = prevTransXYZ.Z
                lastXyzInPln.Z = prevTransXYZ.X
                xyzInPln.X = xyz.Y
                xyzInPln.Y = xyz.Z
                xyzInPln.Z = xyz.X

        End Select

        'find mid point of start and end of arc start and end points

        If mMirrorOneAxisActive Then
            quarterArc = -quarterArc
            If mMode = Motion.CWARC Then
                mMode = Motion.CCARC
            End If
            If mMode = Motion.CCARC Then
                mMode = Motion.CWARC
            End If
        End If

        'This is for an arc or helix that uses an R
        If mBlockHasAddress(AlphaChars.R) AndAlso (mMode = Motion.CCARC Or mMode = Motion.CWARC) Then 'Radius move with R
            deltaxyz = xyzInPln - lastXyzInPln
            meanX = (lastXyzInPln.X + xyzInPln.X) / 2
            meanY = (lastXyzInPln.Y + xyzInPln.Y) / 2
            meanZ = (lastXyzInPln.Z + xyzInPln.Z) / 2
            quarterArc = QUARTER_RADIAN
            '|------- Calculate arc center position -------|
            If mArcRadSigned < 0 Then 'A "-R" is used to specify big arc
                quarterArc = -quarterArc 'Total angle > 180 deg
            End If 'Total angle is always <180 if "+R"

            If WordChanged(plane1) AndAlso WordChanged(plane2) Then 'this is a full arc
                quarterArc = 0
            End If

            mArcData(ArcData.ARC_RAD) = Math.Abs(mArcRadSigned * rScaleFactor)

            'calculate side opposite 'hypotenuse
            Dim Asquared = mArcData(ArcData.ARC_RAD) ^ 2
            Dim Bsquared = (VectorLength(lastXyzInPln.X, lastXyzInPln.Y, 0, xyzInPln.X, xyzInPln.Y, 0) / 2) ^ 2
            side_opposite = (Math.Abs(Asquared - Bsquared))
            side_opposite = (Math.Sqrt(side_opposite))

            If mMode = Motion.CCARC Then
                angleToCenter = AngleFromPoint(deltaxyz.X, deltaxyz.Y, False) - quarterArc
                If angleToCenter < 0 Then
                    angleToCenter = ONE_RADIAN + angleToCenter
                End If
            End If

            If mMode = Motion.CWARC Then
                angleToCenter = AngleFromPoint(deltaxyz.X, deltaxyz.Y, False) + quarterArc
                If angleToCenter > ONE_RADIAN Then
                    angleToCenter = angleToCenter - ONE_RADIAN
                End If
            End If

            arcCenter(arcAxis1) = meanX - (side_opposite * Math.Cos(angleToCenter))
            arcCenter(arcAxis2) = meanY - (side_opposite * Math.Sin(angleToCenter))
            arcCenter(arcAxis3) = meanZ
            mTransArcCenter.X = arcCenter(0)
            mTransArcCenter.Y = arcCenter(1)
            mTransArcCenter.Z = arcCenter(2)

        Else
            'the IJK need to be rotated here
            '
            WorldOffset.ApplyRotationScaleMirror(IJK)
            arcCenter(0) = mToolPosXYZ.X + IJK.X 'Arc origins
            arcCenter(1) = mToolPosXYZ.Y + IJK.Y
            arcCenter(2) = mToolPosXYZ.Z + IJK.Z
            mTransArcCenter.X = arcCenter(0)
            mTransArcCenter.Y = arcCenter(1)
            mTransArcCenter.Z = arcCenter(2)
        End If 'InStr(codeline, "R")

        'Const tol As Double = 0.001
        'Dim endRad As Double = Distance3(mTransArcCenter.X, mTransArcCenter.Y, mTransArcCenter.Z,
        '                                 prevTransXYZ.X, prevTransXYZ.Y, prevTransXYZ.Z)
        'If Math.Abs(endRad - mArcData(ArcData.ARC_RAD)) > tol Then
        '    mParseErrors.Add(New clsParseError(mCurProg.FileName, mCodeBlock.StartIndex, mCodeBlock.LineNUmber, "Radius error >" & tol, mCodeBlock.Text))
        'End If


        If mArcData(ArcData.ARC_RAD) = 0 Then
            LogParseError(New clsParseError(mCurProg.FileName, mCodeBlock.StartIndex, mCodeBlock.LineNUmber, "Zero radius", mCodeBlock.Text))
        End If
    End Sub

    Private Sub Calc_Arc_Angles(endPos As Vector3, startPos As Vector3, centerPos As Vector3, ByRef ang1 As Double, ByRef ang2 As Double, arcDir As Motion)

        If arcDir = Motion.LINE Then Return

        Select Case mArcPlane
            Case Motion.XY_PLN
                ang1 = AngleFromPoint(startPos.X - centerPos.X, startPos.Y - centerPos.Y, False)
                ang2 = AngleFromPoint(endPos.X - centerPos.X, endPos.Y - centerPos.Y, False)
            Case Motion.XZ_PLN
                ang1 = AngleFromPoint(startPos.X - centerPos.X, startPos.Z - centerPos.Z, False)
                ang2 = AngleFromPoint(endPos.X - centerPos.X, endPos.Z - centerPos.Z, False)
            Case Motion.YZ_PLN
                ang1 = AngleFromPoint(startPos.Y - centerPos.Y, startPos.Z - centerPos.Z, False)
                ang2 = AngleFromPoint(endPos.Y - centerPos.Y, endPos.Z - centerPos.Z, False)
        End Select

        Select Case arcDir
            Case Motion.CCARC
                If ang2 <= ang1 Then
                    ang2 = ang2 + ONE_RADIAN
                End If

            Case Motion.CWARC
                If ang1 <= ang2 Then
                    ang1 = ang1 + ONE_RADIAN
                End If
        End Select

    End Sub

    Private Function BlockRegisterValueFromString(label As String, Optional convertForUnits As Boolean = True) As Double
        Dim inversion = 1.0F
        If label.Contains("-") Then
            inversion = -1.0F
            label = label.Replace("-", "")
        End If
        Dim result = AlphaChars.UNKNOWN
        AlphaChars.TryParse(label, result)
        If result <> AlphaChars.UNKNOWN Then
            If convertForUnits Then
                Return (mRawWordValues(result) * mUnitsConversion) * inversion
            Else
                Return mRawWordValues(result) * inversion
            End If
        Else
            Return 0
        End If
    End Function

    Private Function BlockHasAddressFromString(label As String) As Double
        Dim result = AlphaChars.UNKNOWN
        Dim inversion = 1.0F
        If label.Contains("-") Then
            inversion = -1.0F
            label = label.Replace("-", "")
        End If

        AlphaChars.TryParse(label, result)
        If result <> AlphaChars.UNKNOWN Then
            If mBlockHasAddress(result) Then
                Return mRegisters(result) * inversion
            Else
                Return Double.NaN
            End If
        End If
        Return Double.NaN
    End Function
    Private Function WordLabelFromString(label As String) As AlphaChars
        Dim result = AlphaChars.UNKNOWN
        AlphaChars.TryParse(label, result)
        Return result
    End Function

    Private Function TryGetWordValue(address As AlphaChars) As Double
        If mBlockHasAddress(address) Then
            Return mRawWordValues(address)
        End If
        Return Double.NaN
    End Function

    Private Sub ProcessG53Block()
        'Only if we have a block address on this line
        If mBlockHasAddress(AlphaChars.X) Then 'X
            mRegisters(AlphaChars.X) += mCurMachine.HomeValues(0)
        Else
            mRegisters(AlphaChars.X) = mPrevTransXYZ.X
        End If

        If mBlockHasAddress(AlphaChars.Y) Then
            mRegisters(AlphaChars.Y) += mCurMachine.HomeValues(1)
        Else
            mRegisters(AlphaChars.Y) = mPrevTransXYZ.Y
        End If

        If mBlockHasAddress(AlphaChars.Z) Then
            mRegisters(AlphaChars.Z) += mCurMachine.HomeValues(2)
        Else
            mRegisters(AlphaChars.Z) = mPrevTransXYZ.Z
        End If
    End Sub
    Private Sub ProcessG28Block(lnPos As Integer)
        Dim hasMove As Boolean = False
        'If the G28 has an XYZ then this is an intermediate move
        If mBlockHasAddress(mGoHomeAddressIndexX) AndAlso mRegisters(mGoHomeAddressIndexX) <> 0 Then 'X
            mRegisters(AlphaChars.X) = mRegisters(mGoHomeAddressIndexX) * mUnitsConversion
            hasMove = True
        End If
        If mBlockHasAddress(mGoHomeAddressIndexY) AndAlso mRegisters(mGoHomeAddressIndexY) <> 0 Then
            mRegisters(AlphaChars.Y) = mRegisters(mGoHomeAddressIndexY) * mUnitsConversion
            hasMove = True
        End If

        If mBlockHasAddress(mGoHomeAddressIndexZ) AndAlso mRegisters(mGoHomeAddressIndexZ) <> 0 Then
            mRegisters(AlphaChars.Z) = mRegisters(mGoHomeAddressIndexZ) * mUnitsConversion
            hasMove = True
        End If

        'Create the graphics record for the intermediate home shift
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
    End Sub

    Private Sub EvalWordForWorkOffsets()
        If mBlockHasAddress(mPriWrkAddress) Then 'Some work offset is defined
            For Each w As WrkOffset In mWords.WrkOffsets 'find the value in the register
                If mSecWrkAddress > -1 AndAlso mBlockHasAddress(mSecWrkAddress) Then
                    'G57 H92 style
                    If w.PrimaryAddress.Value = mRegisters(mPriWrkAddress) AndAlso w.SecondaryAddress.Value = mRegisters(mSecWrkAddress) Then
                        mG54Offset = w
                        WorldOffset.SetShiftEnum(BlockShiftType.WorkOffset)
                        mBlockHasAddress(AlphaChars.ANY) = True
                        Exit For
                    End If
                Else
                    'G54 style
                    If w.PrimaryAddress.Value = mRegisters(mPriWrkAddress) Then
                        mG54Offset = w
                        WorldOffset.SetShiftEnum(BlockShiftType.WorkOffset)
                        mBlockHasAddress(AlphaChars.ANY) = True
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub
    Private Sub SetWorkOffsetFromG10(pval As Double)
        Dim wadd As New WrkOffset
        Dim gval = pval + 53
        If pval = 0 Then
            wadd = mG54Offset 'current work offset
        Else
            For Each w As WrkOffset In mWords.WrkOffsets 'find the value in the register
                'G54 style
                If w.PrimaryAddress.Value = gval Then
                    wadd = w
                    Exit For
                End If
            Next
        End If

        If wadd.PrimaryAddress.Value <> gval Then
            mWords.WrkOffsets.Add(wadd)
            wadd.PrimaryAddress.Label = "G"
            wadd.PrimaryAddress.Value = gval
        End If

        With wadd
            If mBlockHasAddress(AlphaChars.X) Then
                .X = DistAdjustedForIncAbs(Axees.X, .X) '* mUnitsConversion
            End If
            If mBlockHasAddress(AlphaChars.Y) Then
                .Y = DistAdjustedForIncAbs(Axees.Y, .Y) '* mUnitsConversion
            End If
            If mBlockHasAddress(AlphaChars.Z) Then
                .Z = DistAdjustedForIncAbs(Axees.Z, .Z) '* mUnitsConversion
            End If
            If mBlockHasAddress(AlphaChars.A) Then
                .A = DistAdjustedForIncAbs(Axees.A, .A)
            End If
            If mBlockHasAddress(AlphaChars.B) Then
                .B = DistAdjustedForIncAbs(Axees.B, .B)
            End If
            If mBlockHasAddress(AlphaChars.C) Then
                .C = DistAdjustedForIncAbs(Axees.C, .C)
            End If
        End With
    End Sub

    Private Function DistAdjustedForIncAbs(a As Axees, curval As Double) As Double
        Dim ax As Axees
        If [Enum].TryParse(a.ToString, ax) Then
            If mAbsOrInc = IncAbsMode.INC Then
                Return mParamVals(ax) + curval 'convert ot absolute value
            Else
                Return mParamVals(ax) 'absolute value
            End If
        End If
    End Function


    Private Sub ResetGcodeBlock()
        'Reset some values
        mToolChangeBlock = False
        mSubCallType = subCallType.none
        mRegisters(AlphaChars.P) = 0
        mArcData(ArcData.ANGLE_2) = 0
        mArcData(ArcData.ANGLE_1) = 0
        mArcData(ArcData.ARC_RAD) = 0
        mArcData(ArcData.X_CTR) = 0
        mArcData(ArcData.Y_CTR) = 0
        mArcData(ArcData.Z_CTR) = 0
        'mPrevTool = mRegisters(AlphaChars.T)
        mBlockRotating = False
        mPrevABC = mRotaryMoveABC
        mRegisters(AlphaChars.I) = 0
        mRegisters(AlphaChars.J) = 0
        mRegisters(AlphaChars.K) = 0
        mRegisters(AlphaChars.U) = 0
        mRegisters(AlphaChars.V) = 0
        mRegisters(AlphaChars.W) = 0
        If mMode <> Motion.HOLE_R And mMode <> Motion.HOLE_I Then
            mRegisters(AlphaChars.R) = 0
        End If
        Array.Clear(mParamVals, 0, mParamVals.Length)

        WorldOffset.TransformType = BlockShiftType.NoShift
        mBlockCausesAxisMove = False
        WorldOffset.Restore()

    End Sub

    Private Sub EvaluateWordForMotion()
        mBlockHasAddress(mCurAddress.AddressArrayIndex) = True
        'Default value for all registers. 'May be overwritten later
        mRawWordValues(mCurAddress.AddressArrayIndex) = DoubleParse(mCurAddress.DecimalString)
        If mCurAddress.AddressArrayIndex = AlphaChars.G OrElse
            mCurAddress.AddressArrayIndex = AlphaChars.M OrElse
            mCurAddress.AddressArrayIndex = AlphaChars.N Then
            mRegisters(mCurAddress.AddressArrayIndex) = mRawWordValues(mCurAddress.AddressArrayIndex)
        Else
            mRegisters(mCurAddress.AddressArrayIndex) = DoubleParse(mCurAddress.DecimalString, mCurMachine.Precision)
        End If

        Select Case mCurAddress.Label
            Case "X"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
                mRegisters(AlphaChars.X) *= mCurMachine.Invert(Axees.X)
            Case "Y"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
                mRegisters(AlphaChars.Y) *= mCurMachine.Invert(Axees.Y)
            Case "Z"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
                mRegisters(AlphaChars.Z) *= mCurMachine.Invert(Axees.Z)
            Case "A"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
                mRegisters(AlphaChars.A) *= mCurMachine.Invert(Axees.A)
            Case "B"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
                mRegisters(AlphaChars.B) *= mCurMachine.Invert(Axees.A)
            Case "C"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
                mRegisters(AlphaChars.C) *= mCurMachine.Invert(Axees.A)
            Case "U"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
            Case "V"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
            Case "W"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
            Case "I"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
                If mCurMachine.AbsArcCenter Then
                    mRegisters(AlphaChars.I) /= mLatheDiaRadFactor
                End If
            Case "J"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
            Case "K"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mBlockCausesAxisMove = True
            Case "H"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mRegisters(AlphaChars.H) = DoubleParse(mCurAddress.DecimalString)
            Case "P"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mRegisters(AlphaChars.P) = DoubleParse(mCurAddress.DecimalString)
            Case "R"c
                'R could be a rapid Z, a radius value on an angle
                mBlockHasAddress(AlphaChars.ANY) = True
                mArcRadSigned = mRegisters(AlphaChars.R) * mUnitsConversion
                mBlockCausesAxisMove = True
            Case "S"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mRegisters(AlphaChars.S) = DoubleParse(mCurAddress.DecimalString)
            Case "F"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mRegisters(AlphaChars.F) = mRegisters(AlphaChars.F)
            Case "T"c
                mBlockHasAddress(AlphaChars.ANY) = True
                mRegisters(AlphaChars.T) = CInt(DoubleParse(mCurAddress.DecimalString))
                If mWords.ToolChange.Label = "T"c AndAlso mWords.ToolChange.Value = 0 Then
                    mToolChangeBlock = True
                End If
            Case mRepeatsLabel
                mBlockHasAddress(AlphaChars.ANY) = True
                'we must ignore the reps with a canned cycle
                If mCannedCycle.Value = -1 Then
                    mReps = CInt(DoubleParse(mCurAddress.DecimalString))
                End If
                mBlockCausesAxisMove = True
            Case Else

                If IsWordMatch(mWords.Abs) Then 'Absolute positioning
                    mAbsOrInc = IncAbsMode.ABS
                ElseIf IsWordMatch(mWords.Inc) Then 'Incremental positioning
                    mAbsOrInc = IncAbsMode.INC
                ElseIf IsWordMatch(mWords.IncIJK) Then 'Incremental positioning
                    mCurMachine.AbsArcCenter = False
                ElseIf IsWordMatch(mWords.AbsIJK) Then 'Incremental positioning
                    mCurMachine.AbsArcCenter = True

                ElseIf IsWordMatch(mWords.CompLeft) Then 'Cutter comp 'Left
                    mComp = CutterComp.LEFT

                ElseIf IsWordMatch(mWords.CompRight) Then 'Right
                    mComp = CutterComp.RIGHT

                ElseIf IsWordMatch(mWords.CompCancel) Then 'Off
                    mComp = CutterComp.OFF

                ElseIf IsWordMatch(mWords.Rapid) Then
                    mMode = Motion.RAPID
                ElseIf IsWordMatch(mWords.ToolChange) Then 'Toolchange
                    mToolChangeBlock = True
                ElseIf IsWordMatch(mWords.Linear) Then
                    mMode = Motion.LINE
                ElseIf IsWordMatch(mWords.CWArc) Then  'Arc clockwise
                    If mArcPlane = Motion.XZ_PLN Then
                        mMode = Motion.CCARC
                    Else
                        mMode = Motion.CWARC
                    End If
                ElseIf IsWordMatch(mWords.CCArc) Then  'Arc anti-clockwise
                    If mArcPlane = Motion.XZ_PLN Then
                        mMode = Motion.CWARC
                    Else
                        mMode = Motion.CCARC
                    End If
                ElseIf mCurMachine.MachineType <> MachineType.MILL AndAlso IsWordMatch(mWords.SpeedLimit) Then 'RPM limit
                    mRpmLimit = True
                ElseIf mCurMachine.MachineType <> MachineType.MILL AndAlso IsWordMatch(mWords.SpeedModeRPM) Then 'RPM Mode RPM
                    mSpeedMode = SpeedMode.RPM
                ElseIf mCurMachine.MachineType <> MachineType.MILL AndAlso IsWordMatch(mWords.SpeedModeSFPM) Then 'RPM Mode SFPM
                    mSpeedMode = SpeedMode.SURFACE_SPEED
                ElseIf IsWordMatch(mWords.UnitsEnglish) Then 'English units
                    mCurrentUnits = MachineUnits.ENGLISH
                    SetUnitsConversionFactor()
                ElseIf IsWordMatch(mWords.UnitsMetric) Then 'Metric units
                    mCurrentUnits = MachineUnits.METRIC
                    SetUnitsConversionFactor()
                ElseIf IsWordMatch(mWords.Drills(0)) Then  'Drill cancel found
                    mMode = Motion.RAPID
                    If mDrillReturnMode = DrillReturn.RETURN_TO_I_PLN Then
                        mRegisters(AlphaChars.Z) = mInitialZBeforeDrill
                    Else
                        mRegisters(AlphaChars.Z) = mRegisters(AlphaChars.R)
                    End If
                    mRegisters(AlphaChars.R) = 0

                ElseIf IsWordMatch(mWords.ReturnLevel(0)) Then
                    mDrillReturnMode = DrillReturn.RETURN_TO_I_PLN
                    If mMode = Motion.HOLE_I OrElse mMode = Motion.HOLE_R Then
                        mMode = DirectCast(Motion.HOLE_I + mDrillReturnMode, Motion)
                    End If
                ElseIf IsWordMatch(mWords.ReturnLevel(1)) Then
                    mDrillReturnMode = DrillReturn.RETURN_TO_R_PLN
                    If mMode = Motion.HOLE_I OrElse mMode = Motion.HOLE_R Then
                        mMode = DirectCast(Motion.HOLE_I + mDrillReturnMode, Motion)
                    End If
                ElseIf IsWordMatch(mWords.FeedModeMin) AndAlso mCurMachine.MachineType <> MachineType.MILL Then 'FeedMode
                    mFeedMode = FeedMode.UNIT_PER_MIN
                ElseIf IsWordMatch(mWords.FeedModeRev) AndAlso mCurMachine.MachineType <> MachineType.MILL Then
                    mFeedMode = FeedMode.UNIT_PER_REV
                ElseIf IsWordMatch(mWords.Plane(0)) Then 'Plane Change G17
                    mArcPlane = Motion.XY_PLN
                ElseIf IsWordMatch(mWords.Plane(1)) Then  'Plane Change G18
                    mArcPlane = Motion.XZ_PLN
                ElseIf IsWordMatch(mWords.Plane(2)) Then  'Plane Change G19
                    mArcPlane = Motion.YZ_PLN
                ElseIf mCurAddress.IsMatch(mWords.SubCall) OrElse mCurAddress.IsMatch(mWords.LocalSubCall) Then
                    Dim hasLocalParam = mCurProg.HasFollowingParam(mWords.LocalSubCallParam.Label)
                    Dim hasExtrnParam = mCurProg.HasFollowingParam(mWords.SubCallParam.Label)
                    If mCurAddress.IsMatch(mWords.SubCall) AndAlso hasExtrnParam Then
                        mSubCallType = subCallType.external_M98
                    ElseIf hasLocalParam Then 'local call
                        mSubCallType = subCallType.internal_M97
                    Else
                        Dim msg = "Expected " & mWords.LocalSubCallParam.Label & " or " & mWords.SubCallParam.Label & " following " & mCurAddress.ToString
                        mParseErrors.Add(New clsParseError(mCurProg.FileName, mCurProg.MatchPositionInFile, mLineNumber, msg, mCurProg.CurMatchVal))
                    End If
                Else
                    For r As Integer = 1 To mWords.Drills.Length - 1 'Cycle through all 10 drilling cycles
                        If mWords.Drills(r).Label <> Nothing Then 'NOT an empty field
                            If IsWordMatch(mWords.Drills(r)) Then
                                mMode = DirectCast(Motion.HOLE_I + mDrillReturnMode, Motion) 'Drill cycle found*//
                                mBlockHasAddress(AlphaChars.ANY) = True
                                Exit Select
                            End If
                        End If
                    Next r

                    For r As Integer = 0 To mCannedCycles.Count - 1
                        If mCannedCycles(r).IsMatch(mCurAddress) Then
                            mCannedCycle = mCannedCycles(r)
                            mCannedCycleFile = mCannedCycleFileNames(r)
                            Exit For
                        End If
                    Next

                    If mCurAddress.IsMatch(mWords.G92) Then 'G92
                        mG92Offset.PrimaryAddress = mWords.G92
                        WorldOffset.SetShiftEnum(BlockShiftType.LocalSet)
                    End If

                    '1
                    EvalWordForWorkOffsets()

                    If IsWordMatch(mWords.G10L2PooXYZ) Then 'Data setting
                        If mCurMachine.AllowG10 Then
                            WorldOffset.SetShiftEnum(BlockShiftType.DatsSetting)
                        Else
                            Throw New ArgumentException("G10 L2 Poo XYZ Not enabled")
                        End If
                    End If

                    If mCurAddress.IsMatch(mWords.GoHome) Then 'GO HOME
                        WorldOffset.SetShiftEnum(BlockShiftType.GoHome)
                    End If

                    'At this point we may not know the values from the remaining words in the block yet
                    If IsWordMatch(mWords.G52) Then 'G52 offset the offset
                        mG52Offset.PrimaryAddress = mWords.G52
                        WorldOffset.SetShiftEnum(BlockShiftType.LocalSet)
                        WorldOffset.G52String = mWords.G52.ToString
                    End If
                    If IsWordMatch(mWords.IgnoreOffsetNonModal) Then 'G53 Ignore offsets[non=modal]
                        WorldOffset.SetShiftEnum(BlockShiftType.SuspendWorkOffset)
                        WorldOffset.G53String = mWords.IgnoreOffsetNonModal.ToString
                    End If

                    If mCurMachine.MachineType = MachineType.MILL Then
                        'MILLING ONLY someday I will add the option
                        If IsWordMatch(mWords.G68) Then 'G68 rotate
                            WorldOffset.SetShiftEnum(BlockShiftType.Rotate)
                            WorldOffset.RotateString = mWords.G68.ToString
                        End If
                        If IsWordMatch(mWords.G69) Then 'G69 cancels G68
                            WorldOffset.SetShiftEnum(BlockShiftType.RotateCancel)
                            WorldOffset.RotateString = String.Empty
                        End If
                        If IsWordMatch(mWords.G51) Then 'G51 scale
                            WorldOffset.SetShiftEnum(BlockShiftType.Scale)
                            WorldOffset.ScaleString = mWords.G51.ToString
                        End If
                        If IsWordMatch(mWords.G50) Then 'G50 cancel
                            WorldOffset.SetShiftEnum(BlockShiftType.ScaleCancel)
                            WorldOffset.ScaleString = String.Empty
                        End If
                        If IsWordMatch(mWords.G51_1) Then 'G51.1 Mirror
                            WorldOffset.SetShiftEnum(BlockShiftType.Mirror)
                            WorldOffset.MirrorString = mWords.G51_1.ToString
                        End If
                        If IsWordMatch(mWords.G50_1) Then 'G50.1 Mirror Off
                            WorldOffset.SetShiftEnum(BlockShiftType.MirrorCancel)
                            WorldOffset.MirrorString = String.Empty
                        End If
                    End If
                End If
        End Select

        If mCurAddress.Label = mWords.Rotary.Label Then
            mBlockHasAddress(AlphaChars.ANY) = True
            mBlockCausesAxisMove = True
            'TODO support more than one rotary
            Dim rotVal As Double = DoubleParse(mCurAddress.DecimalString, mCurMachine.RotPrecision) + mG54Offset.A
            mRotaryMoveABC = Maths.ToRadians(rotVal) - mG92Offset.A
            mParamVals(3) = mRotaryMoveABC
            If mCurAddress.DecimalString.StartsWith("-") Then 'check for -0
                mRotDir = -1 'CCW
            End If
        End If
    End Sub

    Private Function IsWordMatch(thisAddress As Address) As Boolean
        If mCurAddress.IsMatch(thisAddress) Then
            mBlockHasAddress(AlphaChars.ANY) = True
            Return True
        End If
        Return False
    End Function

    Friend Function MatchIsComment(m As Match) As Boolean
        If m.Groups(clsProg.COMMENT).Success Then
            mBlockComment = m.Groups(clsProg.COMMENT).Value
            Return True
        End If
        Return False
    End Function

    Private Function InsertCommment() As String
        If mCommentMatch.Length > 0 Then
            Return "(?m)" & mCommentMatch & "|"
        Else
            Return "(?m)"
        End If
    End Function

    Private Function InsertNoCommment() As String
        If mCommentMatch.Length > 0 Then
            Return mCommentNoMatch & "|"
        Else
            Return ""
        End If
    End Function

    'Private Sub BuildCommentMatch()
    '    mCommentMatch = ""
    '    Dim commentSetting As String = mCurMachine.Comments
    '    If commentSetting.Contains("(*)") OrElse commentSetting.Contains("()") Then 'Legacy support
    '        mCommentMatch = "\([^()]*\)"
    '    End If

    '    If commentSetting.Contains("{}") Then
    '        If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
    '        mCommentMatch &= "{[^{}]*}"
    '    End If
    '    If commentSetting.Contains("[]") Then
    '        If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
    '        mCommentMatch &= "\[[[]]*\]"
    '    End If
    '    If commentSetting.Contains("<>") Then
    '        If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
    '        mCommentMatch &= "\<[<>]*\>"
    '    End If

    '    If commentSetting.Contains("""""") Then
    '        If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
    '        mCommentMatch &= """.*"""
    '    End If

    '    'Double characters
    '    If commentSetting.Contains("*") Then
    '        If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
    '        mCommentMatch &= "\*.*$"
    '    End If

    '    If commentSetting.Contains(";") Then
    '        If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
    '        mCommentMatch &= ";.*$"
    '    End If
    '    If commentSetting.Contains(":") Then
    '        If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
    '        mCommentMatch &= ":.*$"
    '    End If
    '    If commentSetting.Contains("'") Then
    '        If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
    '        mCommentMatch &= "'.*$"
    '    End If

    '    If mCommentMatch.Length > 0 Then
    '        mCommentNoMatch = "(?:<Comment>" & mCommentMatch & ")"
    '        mCommentMatch = "(?<Comment>" & mCommentMatch & ")"
    '    End If
    'End Sub

    Public Property MacroBParserNameOverride As String

    Private mMacroBParserName As String = String.Empty
    Public ReadOnly Property MacroBParserName As String
        Get
            Return mMacroBParserName
        End Get
    End Property

    Public Sub Init(machineSetup As clsMachine, cannedCyclesFldr As String, settingsFolder As String)
        If machineSetup Is Nothing Then Return
        Dim macroBparserName As String = String.Empty
        'Look in the proper folder for any canned cycles.
        CannedCyclesFolder = cannedCyclesFldr

        GatherCannedCycles(machineSetup.Name)

        If String.IsNullOrEmpty(MacroBParserNameOverride) Then
            mMacroBParserName = machineSetup.ParserName
        Else
            mMacroBParserName = MacroBParserNameOverride
        End If

        Init(machineSetup)
        mCanEvalMacroB = False
    End Sub

    Public Sub Init(machineSetup As clsMachine)
        If machineSetup Is Nothing Then Return
        mCurMachine = machineSetup

        Dim skipChars As String = ""
        If mCurMachine.BlockSkip IsNot Nothing Then
            For Each c As Char In mCurMachine.BlockSkip.ToCharArray
                skipChars += Regex.Escape(c)
            Next
        End If

        '\([^()]*\)|[/\*].*\n|\n|[A-Z][-+]?[0-9]*\.?[0-9]*
        '(?=\([^()].*?\))

        'Dim comment As String = ""
        'If mCurMachine.Comments.Length = 3 Then
        '    comment = Regex.Escape(mCurMachine.Comments(0)) & "[^" & mCurMachine.Comments(0) & mCurMachine.Comments(2) & "]*" & Regex.Escape(mCurMachine.Comments(2)) & "|"
        'Else
        '    comment = Regex.Escape(mCurMachine.Comments(0)) & ".*" & STR_EOL & "|"
        'End If

        'If IgnoreWhitespace Then
        '    RegexNcWordsMatch = REG_NCWORDS_WS
        'Else
        '    RegexNcWordsMatch = REG_NCWORDS
        'End If

        'BuildCommentMatch()
        mCommentMatch = clsProg.BuildCommentMatch(mCurMachine.Comments)
        mRegSkips = New Regex(mCommentMatch & "[" & skipChars & "][0-9]?", RegexOptions.Compiled)

        Dim progId As String = "(?<PROG>[" & Regex.Escape(mCurMachine.ProgramId) & "]([0-9]+))"
        Dim progM30 As String = "(?<M30>" & mCurMachine.Endmain.Trim & ")"
        Dim progM99 As String = "(?<M99>" & mCurMachine.SubReturn.Trim & ")"
        Dim eol As String = "(?<EOL>" & STR_EOL & ")"
        Dim completeMatch = mCommentMatch & progId & "|" & progM30 & "|" & progM99 & "|" & eol
        '[:\$O]+([0-9]+)  This will return the label and value of each program.
        mRegSubs = New Regex(completeMatch, RegexOptions.Compiled)
        mRegMacroTest = New Regex(mCommentMatch & MacroMatch, RegexOptions.Compiled)

        'Used to count lines
        mRegNewLines = New Regex(STR_EOL, RegexOptions.Compiled)
    End Sub

    Public Function GatherBlockSkips(txt As String) As Integer
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

    Public Sub LoadColorsFromSettings(clrs As Specialized.StringCollection)
        For c As Integer = 0 To MAX_COLORS
            mColors32(c) = CInt(clrs(c))
        Next
    End Sub

    Private Function Color32(i As Integer) As System.Drawing.Color
        If i > MAX_COLORS Then
            Return Drawing.Color.FromArgb(mColors32(0))
        End If
        Return Drawing.Color.FromArgb(mColors32(i))
    End Function

    Public Shared Function VectorLength(X1 As Double, Y1 As Double, Z1 As Double, x2 As Double, y2 As Double, Z2 As Double) As Double
        Return Math.Sqrt(((X1 - x2) ^ 2) + ((Y1 - y2) ^ 2) + ((Z1 - Z2) ^ 2))
    End Function

    Public Shared Function AngleFromPoint(x As Double, y As Double, deg As Boolean) As Double
        Dim theta As Double
        If x > 0 AndAlso y > 0 Then ' Quadrant 1
            theta = (Math.Atan(y / x))
        ElseIf x < 0 AndAlso y > 0 Then  ' Quadrant 2
            theta = (Math.Atan(y / x) + Math.PI)
        ElseIf x < 0 AndAlso y < 0 Then  ' Quadrant 3
            theta = (Math.Atan(y / x) + Math.PI)
        ElseIf x > 0 AndAlso y < 0 Then  ' Quadrant 4
            theta = (Math.Atan(y / x) + ONE_RADIAN)
        End If

        ' Exceptions for points landing on an axis
        If x > 0 AndAlso y = 0 Then '0
            theta = 0
        ElseIf x = 0 AndAlso y > 0 Then  '90
            theta = QUARTER_RADIAN
        ElseIf x < 0 AndAlso y = 0 Then  '180
            theta = Math.PI
        ElseIf x = 0 AndAlso y < 0 Then  '270
            theta = 3 * QUARTER_RADIAN
        End If

        ' if you want the angle in degrees use this conversion
        If deg Then
            theta = (theta * (180.0 / Math.PI))
        End If
        Return theta

    End Function

    Private Sub LogParseError(ex As clsParseError)
        mParseErrors.Add(ex)
    End Sub
End Class