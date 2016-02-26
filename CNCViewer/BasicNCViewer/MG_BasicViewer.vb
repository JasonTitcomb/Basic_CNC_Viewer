''' <remarks>
''' Jason Titcomb
''' MacGen Programming
''' www.CncEdit.com
''' https://github.com/JasonTitcomb/Basic_CNC_Viewer/blob/master/LICENSE.md
''' </remarks>
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

Public Class MG_BasicViewer
    Implements IDisposable, IComponent
#Region "ConstructorDestructor"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        mAll_Siblings.Add(Me)

        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, False)
        ' Retrieves the BufferedGraphicsContext for the current application domain.
        mContext = BufferedGraphicsManager.Current
    End Sub

    Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean).
        Dispose(False)
        MyBase.Finalize()
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then

                mAll_Siblings.Remove(Me)
                DrawAllSelectionOverlays = DirectCast([Delegate].Remove(DrawAllSelectionOverlays, DrawAllSelectionOverlays), DrawAllSelectionOverlayDelegate)

                If mMtxDraw IsNot Nothing Then
                    mMtxDraw.Dispose()
                    mMtxDraw = Nothing
                End If

                If mCurPen IsNot Nothing Then
                    mCurPen.Dispose()
                    mCurPen = Nothing
                End If

                If mWCSPen IsNot Nothing Then
                    mWCSPen.Dispose()
                    mWCSPen = Nothing
                End If

                If mGfxBuff IsNot Nothing Then
                    mGfxBuff.Dispose()
                    mGfxBuff = Nothing
                End If

                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
            System.GC.SuppressFinalize(Me)
        End Try
    End Sub

#End Region
    Public Enum ManipMode
        NONE
        FENCE
        PAN
        ZOOM
        ROTATE
        SELECTION
        FIT
    End Enum

    Public ToolLayers As New Dictionary(Of Single, clsToolLayer)
    Public Event AfterViewManip(ByVal mode As ManipMode, ByVal viewRect As RectangleF)
    Public Event OnStatus(ByVal msg As String, ByVal index As Integer, ByVal max As Integer)
    Public Event OnSelection(ByVal hits As List(Of clsMotionRecord), ByVal i As Integer)
    Public Event MouseLocation(ByVal x As Single, ByVal y As Single)
    Public Event OnSetViewMode(ByVal mode As ManipMode)
    Public Event OnSlowDrawingAlert(ByVal vewCtrl As MG_BasicViewer)
    ' Touch event handlers
    Public Event Touchdown As EventHandler(Of WMTouchEventArgs)
    Public Event Touchup As EventHandler(Of WMTouchEventArgs)
    Public Event TouchMove As EventHandler(Of WMTouchEventArgs)
    Public Event TouchHold As EventHandler(Of WMTouchEventArgs)
    Public Event TouchDoubleTap As EventHandler(Of WMTouchEventArgs)
    Public Event TouchDoubleDoubleTap As EventHandler(Of WMTouchEventArgs)
    Public Event TouchPinching As EventHandler(Of WMDoubleTouchEventArgs)

    Public Shared Event OnElementDetailsClose()
    Public Shared Event OnElementDetailsOpened()
    Public Event OnViewOrientationChanged(ByVal pitch As Single, ByVal roll As Single, ByVal yaw As Single)
    Public Shared Expired As Boolean = True
    'private members
    Private Const NUMBERFORMAT As String = "##0.0###"
    Private Shared mAll_Siblings As New List(Of MG_BasicViewer)
    Private Const ONE_RADIAN As Single = Math.PI * 2
    Private Const PI_S As Single = Math.PI
    Private Const FAST_QUALITY As Single = 0.25
    Private Const VARIABLE_QUALITY As Single = 1.0
    Private Const FIXED_QUALITY As Single = 100.0
    Private mPixelF As Single
    Private mBlipSize As Single
    Private mSinPitch As Single
    Private mSinYaw As Single
    Private mSinRoll As Single
    Private mCosPitch As Single
    Private mCosYaw As Single
    Private mCosRoll As Single
    Private mCosRot As Single
    Private mSinRot As Single
    Private mBackStep As Boolean
    Private mLongside As Single = 2.0
    Private mLastPos As PointF
    Private mCurMotionRec As clsMotionRecord
    Private mGfxIndex As Integer
    Private mCurMotionColor As Color = mRapidColor

    Private mExtentX(1) As Single
    Private mExtentY(1) As Single
    Private mExtentRectangle As RectangleF

    Private mPoints As New List(Of PointF)
    Private mSelectionHitIndices As New List(Of Integer)
    Private mLastSelectionHitIndices As New List(Of Integer)
    Private mSelectionHits As New List(Of clsMotionRecord)

    Private mDisplayLists As New List(Of clsDisplayList)
    Private mLimitsDisplayLists As New List(Of clsDisplayList)
    Private mWcsDisplayLists As New List(Of clsDisplayList)
    Private mMouseDownAndMoving As Boolean
    Private mMouseDownPt As Point
    Private mLastPt As Point

    Private mMtxDraw As New Drawing2D.Matrix
    Private mMtxWCS As New Drawing2D.Matrix
    Private mMtxFeedback As New Drawing2D.Matrix
    Private mMtxGeo As New Drawing2D.Matrix
    Private mViewRect As New RectangleF
    Private mClientRect As New Rectangle
    Private mSelectionRect As New RectangleF(0, 0, 0, 0)
    Private mSelectionPixRect As New Rectangle(0, 0, 6, 6)
    Private mViewportCenter As New PointF
    Private mScaleToReal As Single = 1.0
    Private mMousePtF(2) As PointF

    Private mCurPen As New Pen(Color.White, 0)
    Private mWCSPen As New Pen(Color.Blue, 0)
    Private mRapidDashStyle As Single() = New Single() {0.1F, 0.1F}
    Private mAxisDashStyle As Single() = New Single() {0.05F, 0.2F}

    Private mContext As BufferedGraphicsContext
    Private mGfxBuff As BufferedGraphics
    Private mGfx As Graphics
    Private WithEvents mFrmQuickPick As frmQuickPick
    Private mCurmanipMode As MG_BasicViewer.ManipMode
    Private mInverseColor As Color

    'Define the delegate types
    Delegate Sub DrawAllSelectionOverlayDelegate(ByVal Indices As List(Of Integer), ByVal selIndex As Integer)
    Protected Friend DrawAllSelectionOverlays As DrawAllSelectionOverlayDelegate = AddressOf DrawSelectionOverlay
    Private Shared mCancelSlowDisplayList As Boolean
    Private Shared mAllowSlowDisplayList As Boolean
    Private mStopWatch As Stopwatch
    Private mSelectCursor As Cursor
    Private mSelectEtcCursor As Cursor
    Private SavingDXF As Boolean = False
    Private mDxfOutFile As String
    Private xOld, yOld, zOld As Single
    Private mSectionsDXF As Dictionary(Of String, String)
    Private mTouchPointCount As Integer = 0

    Public Sub InitMyNeighbors()
        mMyNeighborhood.Clear()
        DrawAllSelectionOverlays = AddressOf DrawSelectionOverlay

        For Each s As MG_BasicViewer In mAll_Siblings
            If s.Parent Is Parent Then
                mMyNeighborhood.Add(s)
                If s IsNot Me Then 'We already added Me above so don't do it again.
                    DrawAllSelectionOverlays = DirectCast([Delegate].Combine(DrawAllSelectionOverlays, New DrawAllSelectionOverlayDelegate(AddressOf s.DrawSelectionOverlay)), DrawAllSelectionOverlayDelegate)
                End If
            End If
        Next

        For Each s As MG_BasicViewer In MG_BasicViewer.mAll_Siblings
            If s.Parent Is Parent Then
                s.DrawAllSelectionOverlays = DrawAllSelectionOverlays
                s.mMyNeighborhood = mMyNeighborhood
            End If
        Next

    End Sub

#Region "Properties"
    Protected Friend mMyNeighborhood As New List(Of MG_BasicViewer)
    Private ReadOnly Property MyNeighborhood() As List(Of MG_BasicViewer)
        Get
            Return mMyNeighborhood
        End Get
    End Property

    Private mRmbMenuOpen As Boolean = False
    Public ReadOnly Property RMBOpen() As Boolean
        Get
            Return mRmbMenuOpen
        End Get
    End Property

    Public ReadOnly Property ViewRect() As RectangleF
        Get
            Return mViewRect
        End Get
    End Property

    Private mIsShared As Boolean = False
    <Description("Set or get whether or not the control uses shared drawing"),
    Category("Custom"),
    DefaultValue(False)>
    Public Property IsShared() As Boolean
        Get
            Return mIsShared
        End Get
        Set(ByVal value As Boolean)
            mIsShared = value
        End Set
    End Property

    Private mMotionRecords As New List(Of clsMotionRecord)
    <Browsable(False)>
    Public ReadOnly Property MotionRecords() As List(Of clsMotionRecord)
        Get
            Return mMotionRecords
        End Get
    End Property
    Public Sub SetMotionBlocks(ByVal mb As List(Of clsMotionRecord))
        mMotionRecords = mb
    End Sub

    Private Shared mMaxSelectionHits As Integer = 16
    <Description("Set or get the max number of elements that will be selected"),
    Category("Custom"),
    DefaultValue(False)>
    Public Property MaxSelectionHits() As Integer
        Get
            Return mMaxSelectionHits
        End Get
        Set(ByVal value As Integer)
            mMaxSelectionHits = value
        End Set
    End Property

    Private Shared mDrawOnPaint As Boolean = True
    <Description("Determines if the graphics are redrawn within the paint event."),
    Category("Custom"),
    DefaultValue(False)>
    Public Property DrawOnPaint() As Boolean
        Get
            Return mDrawOnPaint
        End Get
        Set(ByVal value As Boolean)
            mDrawOnPaint = value
        End Set
    End Property

    Private Shared mColorByMotionType As Boolean = False
    <Description("Use motion type (G0 G1 G2 G3) colors instead of tool colors."),
    Category("Custom"),
    DefaultValue(False)>
    Public Property MotionColorByMotionType() As Boolean
        Get
            Return mColorByMotionType
        End Get
        Set(ByVal value As Boolean)
            mColorByMotionType = value
        End Set
    End Property

    Private Shared mRapidColor As Color = Color.OrangeRed
    <Description("Rapid (G00) motion color."), Category("Custom")>
    Public Property MotionColor_Rapid() As Color
        Get
            Return mRapidColor
        End Get
        Set(ByVal value As Color)
            mRapidColor = value
        End Set
    End Property

    Private Shared mLinearColor As Color = Color.DodgerBlue
    <Description("Linear (G01) motion color."), Category("Custom")>
    Public Property MotionColor_Line() As Color
        Get
            Return mLinearColor
        End Get
        Set(ByVal value As Color)
            mLinearColor = value
        End Set
    End Property

    Private Shared mArcCWColor As Color = Color.DarkSeaGreen
    <Description("CW Arc motion color."), Category("Custom")>
    Public Property MotionColor_ArcCW() As Color
        Get
            Return mArcCWColor
        End Get
        Set(ByVal value As Color)
            mArcCWColor = value
        End Set
    End Property

    Private Shared mArcCCWColor As Color = Color.DarkTurquoise
    <Description("CCW Arc motion color."), Category("Custom")>
    Public Property MotionColor_ArcCCW() As Color
        Get
            Return mArcCCWColor
        End Get
        Set(ByVal value As Color)
            mArcCCWColor = value
        End Set
    End Property

    Private Shared mDrawDogLeg As Boolean = True
    <Description("Draw rapid motion with a dog-leg or direct motion."),
    Category("Custom"),
    DefaultValue(True)>
    Public Property DrawDogLeg() As Boolean
        Get
            Return mDrawDogLeg
        End Get
        Set(ByVal value As Boolean)
            mDrawDogLeg = value
        End Set
    End Property


    Private Shared mDrawOverlayInfo As Boolean = True
    <Description("Show extra overlay information for element."),
    Category("Custom"),
    DefaultValue(False)>
    Public Property DrawExtraOverlayInfo() As Boolean
        Get
            Return mDrawOverlayInfo
        End Get
        Set(ByVal value As Boolean)
            mDrawOverlayInfo = value
        End Set
    End Property

    Private Shared mReverseMouseWheel As Boolean = True
    <Description("Reverses the mouse wheel zoom direction."),
    Category("Custom"),
    DefaultValue(False)>
    Public Property ReverseMouseWheel() As Boolean
        Get
            Return mReverseMouseWheel
        End Get
        Set(ByVal value As Boolean)
            mReverseMouseWheel = value
        End Set
    End Property

    Private Shared mOverlayFont As Font = New Font(FontFamily.GenericMonospace, 10)
    <Description("The font used for the text overlay."),
    Category("Custom")>
    Public Shared Property OverlayFont() As Font
        Get
            Return mOverlayFont
        End Get
        Set(ByVal value As Font)
            mOverlayFont = value
        End Set
    End Property

    Private Shared mDynamicViewManipulation As Boolean = False
    <Description("Determines if the graphics are redrawn during view manipulation."),
    Category("Custom"),
    DefaultValue(False)>
    Public Property DynamicViewManipulation() As Boolean
        Get
            Return mDynamicViewManipulation
        End Get
        Set(ByVal value As Boolean)
            mDynamicViewManipulation = value
        End Set
    End Property

    Private Shared mViewManipMode As ManipMode = ManipMode.NONE
    <Description("Sets or gets the view manipulation mode"),
    Category("Custom"),
    DefaultValue(ManipMode.NONE)>
    Public Property ViewManipMode() As ManipMode
        Get
            Return mViewManipMode
        End Get
        Set(ByVal value As ManipMode)
            timerQuickPick.Enabled = (mViewManipMode = ManipMode.SELECTION)
            mViewManipMode = value
            Select Case mViewManipMode
                Case ManipMode.PAN
                    Cursor = Cursors.SizeAll
                Case ManipMode.FENCE
                    Cursor = Cursors.Cross
                Case ManipMode.NONE
                    Cursor = Cursors.Default
                Case ManipMode.ROTATE
                    Cursor = Cursors.SizeNESW
                Case ManipMode.SELECTION
                    Cursor = mSelectCursor
                Case ManipMode.ZOOM
                    Cursor = Cursors.SizeNS
            End Select

            For Each Sibling As MG_BasicViewer In MyNeighborhood
                If Sibling.Name <> Name Then
                    Sibling.Cursor = Cursor
                End If
            Next
        End Set
    End Property

    Private Shared mAxisIndicatorScale As Single = 1.0F
    <Description("Sets or gets the scale if the axis indicator"),
    Category("Custom"),
    DefaultValue(1.0F)>
    Public Property AxisIndicatorScale() As Single
        Get
            Return mAxisIndicatorScale
        End Get
        Set(ByVal value As Single)
            mAxisIndicatorScale = value
        End Set
    End Property

    Private Shared mDrawAxisLines As Boolean = True
    <Description("Draw axis lines"),
    Category("Custom"),
    DefaultValue(True)>
    Public Property DrawAxisLines() As Boolean
        Get
            Return mDrawAxisLines
        End Get
        Set(ByVal value As Boolean)
            mDrawAxisLines = value
        End Set
    End Property

    Private Shared mDrawAxisIndicator As Boolean = True
    <Description("Draw wcs XYZ indicator"),
    Category("Custom"),
    DefaultValue(True)>
    Public Property DrawAxisIndicator() As Boolean
        Get
            Return mDrawAxisIndicator
        End Get
        Set(ByVal value As Boolean)
            mDrawAxisIndicator = value
        End Set
    End Property


    Private Shared mDrawAxisLimits As Boolean = False
    <Description("Draw axis limits"),
    Category("Custom"),
    DefaultValue(False)>
    Public Property DrawAxisLimits() As Boolean
        Get
            Return mDrawAxisLimits
        End Get
        Set(ByVal value As Boolean)
            mDrawAxisLimits = value
        End Set
    End Property


    Private Shared mDrawRapidLines As Boolean = True
    <Description("Draw raid tool motion lines"),
    Category("Custom"),
    DefaultValue(True)>
    Public Property DrawRapidLines() As Boolean
        Get
            Return mDrawRapidLines
        End Get
        Set(ByVal value As Boolean)
            mDrawRapidLines = value
        End Set
    End Property

    Private Shared mDrawRapidPoints As Boolean = True
    <Description("Draw raid tool motion points"),
    Category("Custom"),
    DefaultValue(True)>
    Public Property DrawRapidPoints() As Boolean
        Get
            Return mDrawRapidPoints AndAlso (Not mMouseDownAndMoving)
        End Get
        Set(ByVal value As Boolean)
            mDrawRapidPoints = value
        End Set
    End Property

    Private Shared mArcAxis As Axis = Axis.Z
    <Description("Sets or gets the plane that arcs will be drawn on"),
    Category("Custom"),
    DefaultValue(Axis.Z)>
    Public Property ArcAxis() As Axis
        Get
            Return mArcAxis
        End Get
        Set(ByVal value As Axis)
            mArcAxis = value
        End Set
    End Property
    Private Shared mRotaryType As RotaryMotionType = RotaryMotionType.CAD
    <Description("Sets or gets the way that fourth axis motion is interpreted"),
    Category("Custom"),
    DefaultValue(RotaryMotionType.CAD)>
    Public Property RotaryType() As RotaryMotionType
        Get
            Return mRotaryType
        End Get
        Set(ByVal value As RotaryMotionType)
            mRotaryType = value
        End Set
    End Property

    Private Shared mRotaryPlane As Axis = Axis.X
    <Description("Sets or gets the plane that the fourth axis rotates on"),
    Category("Custom"),
    DefaultValue(Axis.X)>
    Public Property RotaryPlane() As Axis
        Get
            Return mRotaryPlane
        End Get
        Set(ByVal value As Axis)
            mRotaryPlane = value
        End Set
    End Property

    Private Shared mRotaryDirection As RotaryDirection = MacGen.RotaryDirection.CW
    <Description("Sets or gets the direction of the fourth axis"),
    Category("Custom"),
    DefaultValue(MacGen.RotaryDirection.CW)>
    Public Property RotaryDirection() As RotaryDirection
        Get
            Return mRotaryDirection
        End Get
        Set(ByVal value As RotaryDirection)
            mRotaryDirection = value
        End Set
    End Property

    Private mPitch As Single = 0
    <Description("Sets or gets the X axis rotation"),
    Category("Custom"),
    DefaultValue(0)>
    Public Property Pitch() As Single
        Get
            Return mPitch * (180 / PI_S)
        End Get
        Set(ByVal Value As Single)
            mPitch = Value * (PI_S / 180)
            CalcAngle()
            RaiseEvent OnViewOrientationChanged(Pitch, Roll, Yaw)
        End Set
    End Property

    Private mRoll As Single = 0
    <Description("Sets or gets the Y axis rotation"),
    Category("Custom"),
    DefaultValue(0)>
    Public Property Roll() As Single
        Get
            Return mRoll * (180 / PI_S)
        End Get
        Set(ByVal Value As Single)
            mRoll = Value * (PI_S / 180)
            CalcAngle()
            RaiseEvent OnViewOrientationChanged(Pitch, Roll, Yaw)
        End Set
    End Property

    Private mYaw As Single = 0
    <Description("Sets or gets the Z axis rotation"),
    Category("Custom"),
    DefaultValue(0)>
    Public Property Yaw() As Single
        Get
            Return mYaw * (180 / PI_S)
        End Get
        Set(ByVal Value As Single)
            mYaw = Value * (PI_S / 180)
            CalcAngle()
            RaiseEvent OnViewOrientationChanged(Pitch, Roll, Yaw)
        End Set
    End Property

    Private mRotary As Single = 0
    <Description("Sets or gets the fourth axis position"),
    Category("Custom"),
    DefaultValue(0)>
    Public Property FourthAxis() As Single
        Set(ByVal Value As Single)
            mRotary = Value * (-RotaryDirection)
            CalcAngle()
        End Set
        Get
            Return mRotary
        End Get
    End Property

    Private mArcQuality As Single = VARIABLE_QUALITY
    Private mSegAngle As Single = ONE_RADIAN / 16 'angle of circular segments
    <Description("Sets the quality of arcs. >=8 AND <=1440"),
    Category("Custom"),
    DefaultValue(16)>
    Public WriteOnly Property ArcSegmentCount() As Integer
        Set(ByVal value As Integer)
            If mArcQuality = FIXED_QUALITY Then
                value = 36
            Else
                'Set min and max values
                If value < 8 Then value = 8
                If value > 720 Then value = 720
            End If
            mSegAngle = ONE_RADIAN / value
        End Set
    End Property

    Private Shared mMachineType As MachineType = MacGen.MachineType.MILL
    <Description("The type of machine"),
    Category("Custom"),
    DefaultValue(MachineType.MILL)>
    Public Property MachineType() As MachineType
        Get
            Return mMachineType
        End Get
        Set(ByVal value As MachineType)
            mMachineType = value
        End Set
    End Property

    Private Shared mLimits(5) As Single
    <Browsable(False)>
    Public Property Limits() As Single()
        Get
            Return mLimits
        End Get
        Set(ByVal value As Single())
            mLimits = value
        End Set
    End Property

    Private Shared mFilterUpperZ As Single = Single.NaN
    <Browsable(False)>
    Public Property FilterUpperZ() As Single
        Get
            Return mFilterUpperZ
        End Get
        Set(ByVal value As Single)
            mFilterUpperZ = value
        End Set
    End Property

    Private Shared mFilterLowerZ As Single = Single.NaN
    <Browsable(False)>
    Public Property FilterLowerZ() As Single
        Get
            Return mFilterLowerZ
        End Get
        Set(ByVal value As Single)
            mFilterLowerZ = value
        End Set
    End Property

    Private Shared mFilterZCrossing As Boolean
    <Browsable(False)>
    Public Property FilterZCrossing() As Boolean
        Get
            Return mFilterZCrossing
        End Get
        Set(ByVal value As Boolean)
            mFilterZCrossing = value
        End Set
    End Property

    Private Shared mFilterZ As Boolean
    <Browsable(False)>
    Public Property FilterZ() As Boolean
        Get
            Return mFilterZ
        End Get
        Set(ByVal value As Boolean)
            mFilterZ = value
        End Set
    End Property

    Private Shared mSelectedMotionIndex As Integer
    <Browsable(False)>
    Public Property SelectedMotionIndex() As Integer
        Set(ByVal value As Integer)
            mSelectedMotionIndex = value
        End Set
        Get
            If mSelectionHitIndices.Count = 0 Then
                Return -1
            Else
                Return mSelectedMotionIndex 'MotionRecords.IndexOf(mSelectionHits(0))
            End If
        End Get
    End Property

    Private Shared mRangeEnd As Integer
    <Browsable(False)>
    Public Property RangeEnd() As Integer
        Set(ByVal value As Integer)
            If value = 0 Then
                mRangeEnd = MotionRecords.Count - 1
            Else
                If value > MotionRecords.Count Then
                    mRangeEnd = MotionRecords.Count - 1
                Else
                    mRangeEnd = value
                End If
            End If
        End Set
        Get
            Return mRangeEnd
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property RangeMax() As Integer
        Get
            Return MotionRecords.Count - 1
        End Get
    End Property

    Private mTabletMode As Boolean
    <Browsable(False)>
    Public Property TabletMode() As Boolean
        Get
            Return mTabletMode
        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                mSelectionPixRect.Width = 24
                mSelectionPixRect.Height = 24
                rmbView.ImageScalingSize = New Size(24, 24)
            Else
                rmbView.ImageScalingSize = New Size(16, 16)
                mSelectionPixRect.Width = 6
                mSelectionPixRect.Height = 6
            End If
            mTabletMode = value
        End Set
    End Property

    Private Shared mRangeStart As Integer = 0
    <Browsable(False)>
    Public Property RangeStart() As Integer
        Set(ByVal value As Integer)
            mRangeStart = value
            If value > MotionRecords.Count Then
                mRangeStart = 0
            End If
        End Set
        Get
            Return mRangeStart
        End Get
    End Property

#End Region

#Region "Touch"
    ' touch move event handler
    ' EventArgs passed to Touch handlers
    Public Class WMTouchEventArgs
        Inherits System.EventArgs
        ' Private data members
        Private x As Integer
        ' touch x client coordinate in pixels
        Private y As Integer
        ' touch y client coordinate in pixels
        Private m_id As Integer
        ' contact ID
        Private m_mask As Integer
        ' mask which fields in the structure are valid
        Private m_flags As Integer
        ' flags
        Private m_time As Integer
        ' touch event time
        Private m_contactX As Integer
        ' x size of the contact area in pixels
        Private m_contactY As Integer
        ' y size of the contact area in pixels
        ' Access to data members
        Public Property LocationX() As Integer
            Get
                Return x
            End Get
            Set(ByVal value As Integer)
                x = value
            End Set
        End Property
        Public Property LocationY() As Integer
            Get
                Return y
            End Get
            Set(ByVal value As Integer)
                y = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return m_id
            End Get
            Set(ByVal value As Integer)
                m_id = value
            End Set
        End Property
        Public Property Flags() As Integer
            Get
                Return m_flags
            End Get
            Set(ByVal value As Integer)
                m_flags = value
            End Set
        End Property
        Public Property Mask() As Integer
            Get
                Return m_mask
            End Get
            Set(ByVal value As Integer)
                m_mask = value
            End Set
        End Property
        Public Property Time() As Integer
            Get
                Return m_time
            End Get
            Set(ByVal value As Integer)
                m_time = value
            End Set
        End Property
        Public Property ContactWidth() As Integer
            Get
                Return m_contactX
            End Get
            Set(ByVal value As Integer)
                m_contactX = value
            End Set
        End Property
        Public Property ContactHeight() As Integer
            Get
                Return m_contactY
            End Get
            Set(ByVal value As Integer)
                m_contactY = value
            End Set
        End Property
        Public ReadOnly Property IsPrimaryContact() As Boolean
            Get
                Return (m_flags And TOUCHEVENTF_PRIMARY) <> 0
            End Get
        End Property

    End Class

    Public Class WMDoubleTouchEventArgs
        Inherits System.EventArgs
        ' Private data members
        Private x(1) As Integer        ' touch x client coordinate in pixels
        Private y(1) As Integer        ' touch y client coordinate in pixels

        Public Property LocationsX() As Integer()
            Get
                Return x
            End Get
            Set(ByVal value As Integer())
                x = value
            End Set
        End Property
        Public Property LocationsY() As Integer()
            Get
                Return y
            End Get
            Set(ByVal value As Integer())
                y = value
            End Set
        End Property

        Public ReadOnly Property Distance() As Double
            Get
                Return Math.Sqrt((x(0) - x(1)) ^ 2) + (((y(0) - y(1)) ^ 2))
            End Get
        End Property
    End Class

    ' Multitouch/Touch glue (from winuser.h file)
    ' Since the managed layer between C# and WinAPI functions does not 
    ' exist at the moment for multi-touch related functions this part of 
    ' the code is required to replicate definitions from winuser.h file.

    ' Touch event window message constants [winuser.h]
    Private Const WM_TOUCH As Integer = &H240
    Private Const SM_TABLETPC As Integer = 86
    ' Touch event flags ((TOUCHINPUT.dwFlags) [winuser.h]
    Private Const TOUCHEVENTF_MOVE As Integer = &H1
    Private Const TOUCHEVENTF_DOWN As Integer = &H2
    Private Const TOUCHEVENTF_UP As Integer = &H4
    Private Const TOUCHEVENTF_INRANGE As Integer = &H8
    Private Const TOUCHEVENTF_PRIMARY As Integer = &H10
    Private Const TOUCHEVENTF_NOCOALESCE As Integer = &H20
    Private Const TOUCHEVENTF_PEN As Integer = &H40

    ' Touch input mask values (TOUCHINPUT.dwMask) [winuser.h]
    Private Const TOUCHINPUTMASKF_TIMEFROMSYSTEM As Integer = &H1
    ' the dwTime field contains a system generated value
    Private Const TOUCHINPUTMASKF_EXTRAINFO As Integer = &H2
    ' the dwExtraInfo field is valid
    Private Const TOUCHINPUTMASKF_CONTACTAREA As Integer = &H4
    ' the cxContact and cyContact fields are valid
    ' Touch API defined structures [winuser.h]
    <StructLayout(LayoutKind.Sequential)>
    Private Structure TOUCHINPUT
        Public x As Integer
        Public y As Integer
        Public hSource As System.IntPtr
        Public dwID As Integer
        Public dwFlags As Integer
        Public dwMask As Integer
        Public dwTime As Integer
        Public dwExtraInfo As System.IntPtr
        Public cxContact As Integer
        Public cyContact As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure POINTS
        Public x As Short
        Public y As Short
    End Structure

    ' Currently touch/multitouch access is done through unmanaged code
    ' We must p/invoke into user32 [winuser.h]
    <DllImport("user32")>
    Private Shared Function RegisterTouchWindow(ByVal hWnd As System.IntPtr, ByVal ulFlags As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32")>
    Private Shared Function GetSystemMetrics(ByVal smIndex As Integer) As Integer
    End Function

    <DllImport("user32")>
    Private Shared Function GetTouchInputInfo(ByVal hTouchInput As System.IntPtr, ByVal cInputs As Integer, <[In](), Out()> ByVal pInputs As TOUCHINPUT(), ByVal cbSize As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32")>
    Private Shared Sub CloseTouchInputHandle(ByVal lParam As System.IntPtr)
    End Sub

    ' Attributes
    Private touchInputSize As Integer
    ' size of TOUCHINPUT structure
    ' Private methods


    ' Window procedure. Receives WM_ messages.
    ' Translates WM_TOUCH window messages to touch events.
    ' Normally, touch events are sufficient for a derived class,
    ' but the window procedure can be overriden, if needed.
    ' in:
    '      m       message
    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
    Protected Overrides Sub WndProc(ByRef m As Message)
        ' Decode and handle WM_TOUCH message.
        Dim handled As Boolean
        Select Case m.Msg
            Case WM_TOUCH
                handled = DecodeTouch(m)
                Exit Select
            Case Else
                handled = False
                Exit Select
        End Select


        If handled Then
            ' Acknowledge event if handled.
            m.Result = New System.IntPtr(1)
        Else
            ' Call parent WndProc for default message processing.
            MyBase.WndProc(m)

        End If
    End Sub

    ' Extracts lower 16-bit word from an 32-bit int.
    ' in:
    '      number      int
    ' returns:
    '      lower word
    Private Shared Function LoWord(ByVal number As Integer) As Integer
        Return (number And &HFFFF)
    End Function

    ' Decodes and handles WM_TOUCH message.
    ' Unpacks message arguments and invokes appropriate touch events.
    ' in:
    '      m           window message
    ' returns:
    '      whether the message has been handled
    Private Function DecodeTouch(ByRef m As Message) As Boolean
        ' More than one touchinput may be associated with a touch message,
        ' so an array is needed to get all event information.
        ' Number of touch inputs, actual per-contact messages
        mTouchPointCount = LoWord(m.WParam.ToInt32())
        ' Array of TOUCHINPUT structures
        Dim inputs As TOUCHINPUT()
        ' Allocate the storage for the parameters of the per-contact messages
        ' Unpack message parameters into the array of TOUCHINPUT structures, each
        ' representing a message for one single contact.
        inputs = New TOUCHINPUT(mTouchPointCount - 1) {}
        If Not GetTouchInputInfo(m.LParam, mTouchPointCount, inputs, touchInputSize) Then
            ' Get touch info failed.
            Return False
        End If
        Static primaryDownPt As New Point
        Static secondaryDownPt As New Point
        Static primaryPt As New Point
        Static secondaryPt As New Point
        Static downTick As Integer = 0
        ' For each contact, dispatch the message to the appropriate message handler.
        Dim handled As Boolean = False
        'Debug.Print(mTouchPointCount.ToString)
        For i As Integer = 0 To mTouchPointCount - 1
            Dim ti As TOUCHINPUT = inputs(i)
            ' Convert message parameters into touch event arguments and handle the event.
            ' Convert the raw touchinput message into a touchevent.
            Dim te As New WMTouchEventArgs()
            ' Touch event arguments
            ' TOUCHINFO point coordinates and contact size is in 1/100 of a pixel convert it to pixels.
            ' Also convert screen to client coordinates.
            If ti.cxContact > 0 AndAlso ti.cyContact > 0 Then
                te.ContactHeight = ti.cyContact \ 100
                te.ContactWidth = ti.cxContact \ 100
                te.Id = ti.dwID
                Dim pt As Point = PointToClient(New Point(ti.x \ 100, ti.y \ 100))
                te.LocationX = pt.X
                te.LocationY = pt.Y
                If i = 0 Then
                    primaryPt = pt
                End If
                If i = 1 Then
                    secondaryPt = pt
                End If
            End If
            te.Time = ti.dwTime
            te.Mask = ti.dwMask
            te.Flags = ti.dwFlags

            ' Invoke the event handler.
            ' Touch event handler
            If (ti.dwFlags And TOUCHEVENTF_DOWN) <> 0 Then
                Dim dist As Double = Math.Sqrt(((primaryDownPt.X - te.LocationX) ^ 2) + ((primaryDownPt.Y - te.LocationY) ^ 2))
                Dim secondaryDist As Integer = CInt(Math.Sqrt(((secondaryDownPt.X - te.LocationX) ^ 2) + ((secondaryDownPt.Y - te.LocationY) ^ 2)))
                If (te.Time - downTick) < SystemInformation.DoubleClickTime AndAlso
                    dist < (SystemInformation.DoubleClickSize.Width) Then
                    RaiseEvent TouchDoubleTap(Me, te)
                Else
                    RaiseEvent Touchdown(Me, te)
                End If
                If (te.Time - downTick) < SystemInformation.DoubleClickTime AndAlso
                    secondaryDist < (SystemInformation.DoubleClickSize.Width) Then
                    Debug.Print(te.IsPrimaryContact.ToString)
                    RaiseEvent TouchDoubleDoubleTap(Me, te)
                End If
                If te.IsPrimaryContact Then
                    primaryDownPt.X = te.LocationX
                    primaryDownPt.Y = te.LocationY
                Else
                    secondaryDownPt.X = te.LocationX
                    secondaryDownPt.Y = te.LocationY
                End If
                downTick = te.Time

            ElseIf (ti.dwFlags And TOUCHEVENTF_UP) <> 0 Then
                mTouchPointCount -= 1
                RaiseEvent Touchup(Me, te)
            ElseIf (ti.dwFlags And TOUCHEVENTF_MOVE) <> 0 Then
                If mTouchPointCount = 1 Then
                    Dim primaryDist As Integer = CInt(Math.Sqrt(((primaryDownPt.X - te.LocationX) ^ 2) + ((primaryDownPt.Y - te.LocationY) ^ 2)))
                    If (te.Time - downTick) > SystemInformation.DoubleClickTime AndAlso primaryDist < SystemInformation.DoubleClickSize.Width Then
                        RaiseEvent TouchHold(Me, te)
                    Else
                        ContextMenuStrip = Nothing
                        RaiseEvent TouchMove(Me, te)
                    End If
                ElseIf mTouchPointCount = 2 AndAlso i = 1 Then 'pinching?
                    Dim dt As New WMDoubleTouchEventArgs
                    dt.LocationsX(0) = primaryPt.X
                    dt.LocationsY(0) = primaryPt.Y
                    dt.LocationsX(1) = secondaryPt.X
                    dt.LocationsY(1) = secondaryPt.Y
                    ContextMenuStrip = Nothing
                    RaiseEvent TouchPinching(Me, dt)
                Else
                    RaiseEvent TouchMove(Me, te)
                End If
            End If

            ' Mark this event as handled.
            handled = True
        Next

        CloseTouchInputHandle(m.LParam)

        Return handled
    End Function

#End Region



    Private Sub CalcAngle()
        mCosRot = CSng(Math.Cos(mRotary))
        mSinRot = CSng(Math.Sin(mRotary))
        mSinYaw = CSng(Math.Sin(mYaw))
        mCosYaw = CSng(Math.Cos(mYaw))
        mSinRoll = CSng(Math.Sin(mRoll))
        mCosRoll = CSng(Math.Cos(mRoll))
        mSinPitch = CSng(Math.Sin(mPitch))
        mCosPitch = CSng(Math.Cos(mPitch))
    End Sub

    Public Sub SetVisibleByLine(ByVal rangeStart As Integer, ByVal rangeEnd As Integer)
        For Each m As clsMotionRecord In MotionRecords
            m.Visible = True
            If m.Linenumber < rangeStart OrElse m.Linenumber > rangeEnd Then
                m.Visible = False
            End If
        Next
    End Sub

    Public Sub SetZFilter()
        If FilterZ Then
            For Each m As clsMotionRecord In MotionRecords
                With m
                    .FilterZ = True
                    'If either start or end is within upper and lower then show
                    If mFilterZCrossing Then
                        If (.Zpos <= mFilterUpperZ AndAlso .Zpos >= mFilterLowerZ) OrElse (.Zold <= mFilterUpperZ AndAlso .Zold >= mFilterLowerZ) Then
                            .FilterZ = False
                        End If

                    Else 'If both start and end are within bounds then show
                        If (.Zpos <= mFilterUpperZ AndAlso .Zpos >= mFilterLowerZ) AndAlso (.Zold <= mFilterUpperZ AndAlso .Zold >= mFilterLowerZ) Then
                            .FilterZ = False
                        End If
                    End If
                End With
            Next
        Else
            For Each m As clsMotionRecord In MotionRecords
                m.FilterZ = False
            Next
        End If


    End Sub


    Public Sub SetRangeByLine(ByVal rangeStart As Integer, ByVal rangeEnd As Integer)
        If rangeEnd = 0 Then
            Me.RangeStart = 0
            Me.RangeEnd = 0
        Else
            For r As Integer = 0 To MotionRecords.Count - 1
                Dim mot As clsMotionRecord = MotionRecords(r)
                If mot.Linenumber = rangeStart Then
                    Me.RangeStart = r
                End If

                If mot.Linenumber >= rangeEnd Then
                    Me.RangeEnd = r
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub MG_BasicViewer_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackColorChanged
        mInverseColor = Color.FromArgb(Not BackColor.R, Not BackColor.G, Not BackColor.B)
    End Sub

    Private Sub MG_BasicViewer_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If ReverseMouseWheel Then
            If Math.Sign(e.Delta) = 1 Then
                ZoomSceneAtMouse(1.1)
            Else
                ZoomSceneAtMouse(0.9)
            End If
        Else
            If Math.Sign(e.Delta) = -1 Then
                ZoomSceneAtMouse(1.1)
            Else
                ZoomSceneAtMouse(0.9)
            End If
        End If
        CreateDisplayListsAndDraw()
    End Sub

    Private Sub MG_BasicViewer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        mCurmanipMode = ViewManipMode
        SelectedMotionIndex = -1
        If e.Button = Windows.Forms.MouseButtons.Left Then
            TabletMode = False
            ContextMenuStrip = rmbView
            ' Make a note that we "have the mouse".
            If ViewManipMode = ManipMode.SELECTION Then
                If mSelectionHits.Count >= 1 Then
                    UpdateElementDetails()
                    SelectedMotionIndex = MotionRecords.IndexOf(mSelectionHits(0))
                    RaiseEvent OnSelection(mSelectionHits, 0)
                    If mSelectionHits.Count > 1 AndAlso Cursor = mSelectEtcCursor Then
                        ShowQuickPick()
                    End If
                End If
            End If
        End If

        ' Reset last.
        mLastPt.X = -1
        mLastPt.Y = -1
        ' Store the "starting point" for this rubber-band rectangle.
        mMouseDownPt.X = e.X
        mMouseDownPt.Y = e.Y
    End Sub

    Private Shared mSelectionColor As Color
    Public Property SelectionColor() As Color
        Get
            Return mSelectionColor
        End Get
        Set(ByVal value As Color)
            mSelectionColor = value
        End Set
    End Property

    Private Shared mLimitsColor As Color = Color.DarkGray
    Public Property LimitsColor() As Color
        Get
            Return mLimitsColor
        End Get
        Set(ByVal value As Color)
            mLimitsColor = value
        End Set
    End Property
    Private mCurrentCursorPos As Point
    <Browsable(False)>
    Public ReadOnly Property CursorPosition() As Point
        Get
            Return mCurrentCursorPos
        End Get
    End Property

    Private Sub MG_BasicViewer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Static Xold As Single
        Static Yold As Single
        If mTouchPointCount > 1 Then Return
        'Debug.Print("mousemove")
        Try
            Select Case e.Button
                Case Windows.Forms.MouseButtons.Left
                    mMouseDownAndMoving = True
                Case Windows.Forms.MouseButtons.Middle
                    mMouseDownAndMoving = True
                    ViewManipMode = ManipMode.ROTATE
                Case Windows.Forms.MouseButtons.Left Or Windows.Forms.MouseButtons.Right
                    mMouseDownAndMoving = True
                    ViewManipMode = ManipMode.PAN
                    ContextMenuStrip = Nothing
            End Select

            mCurrentCursorPos.X = e.X
            mCurrentCursorPos.Y = e.Y
            'Set the real coordinates of the mouse.
            'When the button whent down
            mMousePtF(0).X = mMouseDownPt.X
            mMousePtF(0).Y = mMouseDownPt.Y
            'The current location
            mMousePtF(1).X = e.X
            mMousePtF(1).Y = e.Y
            'The last location
            mMousePtF(2).X = Xold
            mMousePtF(2).Y = Yold
            'Transform the points
            mMtxFeedback.TransformPoints(mMousePtF)

            Select Case ViewManipMode
                Case ManipMode.FENCE
                    If (mMouseDownAndMoving) Then
                        ' Erase.
                        If (mLastPt.X <> -1) Then
                            DrawWinMouseRect(mMouseDownPt, mLastPt)
                        End If
                        ' Draw new rectangle.
                        DrawWinMouseRect(mMouseDownPt, mCurrentCursorPos)
                    End If
                Case ManipMode.PAN
                    If (mMouseDownAndMoving) Then
                        If mDynamicViewManipulation Then
                            If Not My.Computer.Keyboard.ShiftKeyDown Then
                                mArcQuality = FAST_QUALITY
                            End If
                            PanScene((mMousePtF(1).X - mMousePtF(2).X), mMousePtF(1).Y - mMousePtF(2).Y)
                            CreateDisplayListsAndDraw()
                        Else
                            If (mLastPt.X <> -1) Then
                                DrawWinMouseLine(mMouseDownPt, mLastPt)
                            End If
                            DrawWinMouseLine(mMouseDownPt, mCurrentCursorPos)
                        End If
                    End If
                Case ManipMode.ROTATE
                    If mMouseDownAndMoving Then
                        If mMouseDownPt.Y > Height - 20 Then 'near bottom X
                            Roll += Int(-Math.Sign(Xold - e.X)) * 3
                        ElseIf mMouseDownPt.X < 20 Then 'near left Z
                            Yaw += Int(-Math.Sign(Yold - e.Y)) * 3
                        ElseIf mMouseDownPt.X > Width - 20 Then 'near right Y
                            Pitch += Int(-Math.Sign(Yold - e.Y)) * 3
                        Else
                            Pitch += Int(-Math.Sign(Yold - e.Y)) * 3
                            Roll += Int(-Math.Sign(Xold - e.X)) * 3
                        End If
                        If mDynamicViewManipulation Then
                            If Not My.Computer.Keyboard.ShiftKeyDown Then
                                mArcQuality = FAST_QUALITY
                            End If
                            CreateDisplayListsAndDraw()
                        Else
                            DrawWcsOnlyToBuffer()
                        End If
                    End If
                Case ManipMode.ZOOM
                    If (mMouseDownAndMoving) Then
                        Dim zFact As Single
                        If e.Y > mMouseDownPt.Y Then
                            zFact = CSng(1 + ((e.Y - Yold) / Height))
                        Else
                            zFact = 1 / CSng(1 + (Math.Abs(e.Y - Yold) / Height))
                        End If
                        ZoomSceneAtCenter(zFact)
                        If mDynamicViewManipulation Then
                            If Not My.Computer.Keyboard.ShiftKeyDown Then
                                mArcQuality = FAST_QUALITY
                            End If
                            CreateDisplayListsAndDraw()
                            'Me.mArcQuality = 1.0
                        End If
                    End If
                Case ManipMode.SELECTION

                    'Get a small selection viewport for selection.
                    mSelectionRect.X = mMousePtF(1).X - mPixelF * mSelectionPixRect.Width / 2.0F
                    mSelectionRect.Y = mMousePtF(1).Y - mPixelF * mSelectionPixRect.Height / 2.0F
                    mSelectionRect.Width = mPixelF * mSelectionPixRect.Width
                    mSelectionRect.Height = mPixelF * mSelectionPixRect.Height

                    GetSelectionHits(mSelectionRect)
                    'Debug.Print(mDisplayLists.Count.ToString)
                    If IsNewSelection() Then
                        DrawAllSelectionOverlays(mSelectionHitIndices, -1)
                        DrawOverlay()
                        mLastSelectionHitIndices.Clear()
                        mLastSelectionHitIndices.AddRange(mSelectionHitIndices)
                    End If

                    RaiseEvent MouseLocation(mMousePtF(1).X, mMousePtF(1).Y)
            End Select
            ' Update last point.
            mLastPt = mCurrentCursorPos
            Xold = e.X
            Yold = e.Y
        Catch
            Debug.Assert(0 = 1, "MG_BasicViewer_MouseMove")
        End Try

    End Sub

    Private Function IsNewSelection() As Boolean
        If mSelectionHitIndices.Count = mLastSelectionHitIndices.Count Then
            For r As Integer = 0 To mLastSelectionHitIndices.Count - 1
                If mLastSelectionHitIndices(r) <> mLastSelectionHitIndices(r) Then
                    Return True
                End If
            Next
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub MG_BasicViewer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        'Dim curCursor As Cursor = Me.Cursor
        Try
            ' Set internal flag to know we no longer "have the mouse".
            mMouseDownAndMoving = False
            mArcQuality = VARIABLE_QUALITY
            ' Set flags to know that there is no "previous" line to reverse.
            mLastPt.X = -1
            mLastPt.Y = -1

            If Not mDynamicViewManipulation Then
                Cursor = Cursors.WaitCursor
            End If
            Select Case ViewManipMode
                Case ManipMode.PAN
                    If Not mDynamicViewManipulation Then
                        PanScene((mMousePtF(1).X - mMousePtF(0).X), mMousePtF(1).Y - mMousePtF(0).Y)
                    End If
                    CreateDisplayListsAndDraw()
                Case ManipMode.ROTATE
                    'If Not mDynamicViewManipulation Then
                    CreateDisplayListsAndDraw()
                'End If
                Case ManipMode.FENCE
                    If mMouseDownPt.X <> e.X AndAlso mMouseDownPt.Y <> e.Y Then
                        WindowViewport(mMousePtF(0).X, mMousePtF(0).Y, mMousePtF(1).X, mMousePtF(1).Y)
                        CreateDisplayListsAndDraw()
                    End If
                Case ManipMode.ZOOM
                    'If Not mDynamicViewManipulation Then
                    CreateDisplayListsAndDraw()
                    'End If
            End Select
            ViewManipMode = mCurmanipMode
            'Me.Cursor = curCursor
        Catch
            Debug.Assert(0 = 1, "MG_BasicViewer_MouseUp")
        End Try

    End Sub

    ' Convert and Normalize the points and draw the reversible frame.
    Private Sub DrawWinMouseRect(ByVal p1 As Point, ByVal p2 As Point)
        Dim rc As Rectangle
        ' Normalize the rectangle.
        If (p1.X < p2.X) Then
            rc.X = p1.X
            rc.Width = p2.X - p1.X
        Else
            rc.X = p2.X
            rc.Width = p1.X - p2.X
        End If
        If (p1.Y < p2.Y) Then
            rc.Y = p1.Y
            rc.Height = p2.Y - p1.Y
        Else
            rc.Y = p2.Y
            rc.Height = p1.Y - p2.Y
        End If

        'Draw the buffer
        If Not (mGfxBuff Is Nothing) Then
            mGfxBuff.Render()
        End If

        'Draw the selection overlay.
        mCurPen.Color = mInverseColor
        mCurPen.DashStyle = Drawing2D.DashStyle.Dot
        Using g As Graphics = Graphics.FromHwnd(Handle)
            g.DrawRectangle(mCurPen, rc)
        End Using
    End Sub

    Private Sub DrawSelectionRectangle(ByVal rc As Rectangle)
        'Draw the buffer
        If Not (mGfxBuff Is Nothing) Then
            mGfxBuff.Render()
        End If

        'Draw the selection overlay.
        mCurPen.Color = mInverseColor
        mCurPen.DashStyle = Drawing2D.DashStyle.Solid
        Using g As Graphics = Graphics.FromHwnd(Handle)
            g.DrawRectangle(mCurPen, rc)
        End Using
    End Sub

    Private Sub DrawWinMouseLine(ByVal p1 As Point, ByVal p2 As Point)
        'Draw the buffer
        If Not (mGfxBuff Is Nothing) Then
            mGfxBuff.Render()
        End If

        'Draw the selection overlay.
        mCurPen.Color = mInverseColor
        mCurPen.DashStyle = Drawing2D.DashStyle.Dash
        Using g As Graphics = Graphics.FromHwnd(Handle)
            g.DrawLine(mCurPen, p1, p2)
        End Using
    End Sub

    'Private Sub DrawZ_Plane()
    '    If Not (mGfxBuff Is Nothing) Then
    '        Using textBrush As New SolidBrush(Color.FromArgb(180, Not BackColor.R, Not BackColor.G, Not BackColor.B))
    '            mGfxBuff.Graphics.FillRectangle(textBrush, mExtentRectangle)
    '        End Using
    '    End If
    'End Sub

    Public Sub ZoomSceneAtMouse(ByVal zoomFactor As Single)
        Dim factor As Single = (1 - zoomFactor)

        Dim leftScale As Single = CSng((mCurrentCursorPos.X / mClientRect.Width))
        Dim rightScale As Single = 1.0F - leftScale
        leftScale = 1 - (leftScale * factor)
        rightScale = 1 - (rightScale * factor)

        Dim topScale As Single = CSng((mCurrentCursorPos.Y / mClientRect.Height))
        Dim bottomScale As Single = (1.0F - topScale)
        topScale = 1 - (topScale * factor)
        bottomScale = 1 - (bottomScale * factor)

        WindowViewport(mViewportCenter.X - ((mViewRect.Width / 2) * leftScale),
                       mViewportCenter.Y - ((mViewRect.Height / 2) * bottomScale),
                       mViewportCenter.X + ((mViewRect.Width / 2) * rightScale),
                       mViewportCenter.Y + ((mViewRect.Height / 2) * topScale))
    End Sub


    Public Sub ZoomSceneAtCenter(ByVal zoomFactor As Single)
        Dim newWid As Single = mViewRect.Width * zoomFactor
        Dim newHt As Single = mViewRect.Height * zoomFactor

        mViewRect.X += (mViewRect.Width - newWid) / 2
        mViewRect.Y += (mViewRect.Height - newHt) / 2
        mViewRect.Width = newWid
        mViewRect.Height = newHt
        mLongside = Math.Max(mViewRect.Width, mViewRect.Height)
        SetViewMatrix()
    End Sub

    Public Sub PanScene(ByVal deltaX As Single, ByVal deltaY As Single)
        mViewRect.X -= deltaX
        mViewRect.Y -= deltaY
        mViewportCenter.X -= deltaX
        mViewportCenter.Y -= deltaY
        SetViewMatrix()
    End Sub

    Public Sub WindowViewport(ByVal X1 As Single, ByVal Y1 As Single, ByVal X2 As Single, ByVal Y2 As Single)
        Dim temp As Single

        If (X1 > X2) Then 'convert window from right to left
            temp = X2
            X2 = X1
            X1 = temp
        End If

        If (Y1 > Y2) Then 'convert window from bottom to top
            temp = Y2
            Y2 = Y1
            Y1 = temp
        End If

        If Math.Abs(X2 - X1) < 0.01 Then
            Return
        End If
        If Math.Abs(Y2 - Y1) > 100000 Then
            Return
        End If

        mViewRect.X = X1
        mViewRect.Y = Y1
        mViewRect.Width = X2 - X1
        mViewRect.Height = Y2 - Y1
        AdjustAspect()
    End Sub

    Private Sub SetBufferContext()
        If mGfxBuff IsNot Nothing Then
            mGfxBuff.Dispose()
            mGfxBuff = Nothing
        End If
        ' Retrieves the BufferedGraphicsContext for the current application domain.
        mContext = BufferedGraphicsManager.Current
        ' Sets the maximum size for the primary graphics buffer
        mContext.MaximumBuffer = New Size(Width + 1, Height + 1)
        ' Allocates a graphics buffer the size of this control
        mGfxBuff = mContext.Allocate(CreateGraphics(), New Rectangle(0, 0, Width, Height))
        mGfx = mGfxBuff.Graphics
    End Sub

    ''' <summary>
    ''' Sets the matrix required to draw to the specified view
    ''' </summary>
    Private Sub SetViewMatrix()
        If Single.IsInfinity(mViewRect.Width) OrElse Single.IsInfinity(mViewRect.Height) Then Return
        If mViewRect.Width = 0 OrElse mViewRect.Height = 0 Then Return

        'The ratio between the actual size of the screen and the size of the graphics.
        mScaleToReal = (mClientRect.Width / mGfx.DpiX) / mViewRect.Width

        mMtxDraw.Reset()
        mMtxDraw.Scale(mScaleToReal, mScaleToReal)
        mMtxDraw.Translate(-mViewportCenter.X, mViewportCenter.Y)
        mMtxDraw.Translate((mViewRect.Width / 2.0F), (mViewRect.Height / 2.0F))
        mMtxDraw.Scale(1, -1) 'Flip the Y

        'The matrix for the triad is the same as the other geometry but without the scale
        mMtxWCS.Reset()
        mMtxWCS.Multiply(mMtxDraw)
        mMtxWCS.Scale(1 / mScaleToReal * mAxisIndicatorScale, 1 / mScaleToReal * mAxisIndicatorScale)

        mPixelF = ((1 / mGfx.DpiX) / mScaleToReal)
        mBlipSize = (mPixelF * 3.0F)

        SetFeedbackMatrix()
    End Sub

    ''' <summary>
    ''' Adjusts the aspect of the view to match the window aspect
    ''' </summary>
    Private Sub AdjustAspect()

        If mGfx.DpiX = 0 Then Return
        If Single.IsInfinity(mViewRect.Width) OrElse Single.IsInfinity(mViewRect.Height) Then Return
        If mViewRect.Width = 0 OrElse mViewRect.Height = 0 Then Return

        mViewportCenter.X = mViewRect.X + (mViewRect.Width / 2)
        mViewportCenter.Y = mViewRect.Y + (mViewRect.Height / 2)

        Dim winRatio As Single = CSng(mClientRect.Width / mClientRect.Height)
        Dim extRatio As Single = CSng(mViewRect.Width / mViewRect.Height)

        If winRatio >= extRatio Then 'height will max out or is equal
            mViewRect.Height = mViewRect.Height
            mViewRect.Width = mViewRect.Height * winRatio
            mViewRect.X = mViewportCenter.X - (mViewRect.Width * 0.5F)
            mViewRect.Y = mViewportCenter.Y - (mViewRect.Height * 0.5F)
        Else 'width will max out
            mViewRect.Height = mViewRect.Width / winRatio
            mViewRect.Width = mViewRect.Width
            mViewRect.X = mViewportCenter.X - (mViewRect.Width * 0.5F)
            mViewRect.Y = mViewportCenter.Y - (mViewRect.Height * 0.5F)
        End If

        SetViewMatrix()
    End Sub

    Private Sub SetFeedbackMatrix()
        mMtxFeedback.Reset()
        mMtxFeedback.Scale(mGfx.DpiX, mGfx.DpiY)
        mMtxFeedback.Multiply(mMtxDraw)
        mMtxFeedback.Invert()
    End Sub

    'I would like to take the graphics on the screen and print them to an area on the sheet.
    Public Sub PrintScreen(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal region As Rectangle, ByVal scaleMode As Integer, ByVal units As MachineUnits, ByVal scale As Single)
        Dim mtxWcs As New Drawing2D.Matrix
        Dim mtxDraw As New Drawing2D.Matrix
        Dim g As Graphics = e.Graphics
        Dim printMarginRectF As RectangleF = Nothing
        Dim gUnits As GraphicsUnit

        Dim clipRect As New Rectangle(region.Location, region.Size)
        clipRect.Inflate(1, 1)
        Dim clipRegion As New Region(clipRect)

        printMarginRectF.X = region.X / 100.0F
        printMarginRectF.Y = region.Y / 100.0F
        printMarginRectF.Width = region.Width / 100.0F
        printMarginRectF.Height = region.Height / 100.0F
        Dim scaleToReal As Single = printMarginRectF.Width / mViewRect.Width
        Select Case scaleMode
            Case 0
                mScaleToReal = printMarginRectF.Width / mViewRect.Width
            Case 1
                mScaleToReal = 1.0
            Case 2
                mScaleToReal = scale
        End Select

        If units = MachineUnits.ENGLISH Then
            gUnits = GraphicsUnit.Inch
        Else
            gUnits = GraphicsUnit.Millimeter
        End If

        mViewportCenter.X = mViewRect.X + (mViewRect.Width / 2)
        mViewportCenter.Y = mViewRect.Y + (mViewRect.Height / 2)

        mtxDraw.Reset()

        mtxDraw.Translate(printMarginRectF.X, printMarginRectF.Y)
        mtxDraw.Scale(mScaleToReal, mScaleToReal)
        If scaleMode <> 0 Then
            mtxDraw.Translate((mExtentRectangle.Width / 2.0F), (mExtentRectangle.Height / 2.0F))
        Else
            mtxDraw.Translate((mViewRect.Width / 2.0F), (mViewRect.Height / 2.0F))
        End If
        mtxDraw.Translate(-mViewportCenter.X, mViewportCenter.Y)
        mtxDraw.Scale(1, -1) 'Flip the Y

        'The matrix for the triad is the same as the other geometry but without the scale
        mtxWcs.Reset()
        mtxWcs.Multiply(mtxDraw)
        mtxWcs.Scale(1 / mScaleToReal, 1 / mScaleToReal)

        mPixelF = ((1 / g.DpiX) / mScaleToReal)
        mBlipSize = (mPixelF * 6.0F)
        CreateDisplayLists()

        mCurPen.Width = 0
        mCurPen.Color = Color.Black
        mCurPen.DashStyle = Drawing2D.DashStyle.Solid

        'SetInViewStatus(Me.mViewRect)
        mArcQuality = FIXED_QUALITY
        CreateDisplayLists()
        SetAllInVeiw()
        With g
            'Shift to the margin
            .Clip = clipRegion
            .PageUnit = gUnits
            .Transform.Translate(printMarginRectF.X, printMarginRectF.Y)
            .DrawRectangle(mCurPen, printMarginRectF.X, printMarginRectF.Y, printMarginRectF.Width, printMarginRectF.Height)

            .ResetTransform()
            .MultiplyTransform(mtxWcs)
            'Draw the axis indicator and axis lines
            For Each p As clsDisplayList In mWcsDisplayLists

                If p.DashStyle <> DashStyle.Solid Then
                    mWCSPen.DashStyle = DashStyle.Dash
                    'mWCSPen.DashPattern = mAxisDashStyle
                Else
                    mWCSPen.DashStyle = Drawing2D.DashStyle.Solid
                End If
                mWCSPen.Color = p.Color
                .DrawLines(mWCSPen, p.Points)
            Next
            .ResetTransform()

            'Now draw the toolpath
            .MultiplyTransform(mtxDraw)
            mCurPen.Width = 0
            For Each p As clsDisplayList In mDisplayLists
                If Not p.InView Then
                    Continue For
                End If
                mCurPen.DashStyle = p.DashStyle

                If p.Color = Color.White Then 'White on white is not good
                    mCurPen.Color = Color.Gray
                Else
                    mCurPen.Color = p.Color
                End If
                .DrawLines(mCurPen, p.Points)
            Next
        End With
        mArcQuality = VARIABLE_QUALITY

        If clipRegion IsNot Nothing Then clipRegion.Dispose()
    End Sub

    Public Sub CancelCreateDisplayList(ByVal value As Boolean)
        If value Then
            mCancelSlowDisplayList = True
        Else
            mAllowSlowDisplayList = True
        End If
    End Sub

    Private Sub DrawListsToGraphics(ByRef g As Graphics)
        If mGfxBuff Is Nothing Then Return
        Dim screenPoints() As PointF = Nothing
        Dim sw As New Stopwatch
        Dim limitDashStyle As Single() = New Single() {2.0F, 2.0F}

        Try
            mCurPen.Width = -1
            With g
                .SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
                '.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
                .PageUnit = GraphicsUnit.Inch
                .ResetTransform()
                .MultiplyTransform(mMtxWCS)

                'Draw the axis indicator and axis lines
                For Each p As clsDisplayList In mWcsDisplayLists
                    If mCancelSlowDisplayList Then Exit For
                    mWCSPen.DashStyle = p.DashStyle
                    If p.DashStyle = DashStyle.Custom Then
                        mWCSPen.DashPattern = mAxisDashStyle
                    End If
                    mWCSPen.Color = p.Color

                    If mAllowSlowDisplayList Then 'just draw
                        .DrawLines(mWCSPen, p.Points)
                    Else 'test for speed
                        sw.Start()
                        .DrawLines(mWCSPen, p.Points)
                        If sw.ElapsedMilliseconds > 2000 Then
                            RaiseEvent OnSlowDrawingAlert(Me)
                        End If
                    End If
                Next

                .ResetTransform()
                'Now draw the toolpath
                'Adjust the dash style to suit the view scale
                mRapidDashStyle(0) = 0.05F / mScaleToReal
                mRapidDashStyle(1) = 0.05F / mScaleToReal

                limitDashStyle(0) = 0.1F / mScaleToReal
                limitDashStyle(1) = 0.2F / mScaleToReal

                .MultiplyTransform(mMtxDraw)

                mCurPen.DashStyle = DashStyle.Solid
                'mCurPen.DashPattern = limitDashStyle
                If mLimitsDisplayLists.Count > 0 Then
                    mCurPen.Color = LimitsColor

                    For Each p As clsDisplayList In mLimitsDisplayLists
                        .DrawLines(mCurPen, p.Points)
                    Next
                End If
                For Each p As clsDisplayList In mDisplayLists
                    If mCancelSlowDisplayList Then Exit For
                    If Not p.InView Then
                        Continue For
                    End If
                    mCurPen.DashStyle = p.DashStyle
                    If p.DashStyle = DashStyle.Dash Then
                        mCurPen.DashPattern = mRapidDashStyle
                    End If
                    mCurPen.Color = p.Color
                    LineFixUp(p.Points)

                    If mAllowSlowDisplayList Then 'just draw
                        .DrawLines(mCurPen, p.Points)
                    Else 'test for speed
                        sw.Start()
                        .DrawLines(mCurPen, p.Points)
                        If sw.ElapsedMilliseconds > 2000 Then
                            RaiseEvent OnSlowDrawingAlert(Me)
                        End If
                    End If
                Next
            End With
        Catch
            Debug.Assert(False, "DrawListsToGraphics")
        Finally
            sw.Stop()
        End Try

    End Sub

    'I hate this!
    'A problem exists where if the line is extended beyond the screen and it is at a sight angle
    'then it will not display completly.
    'This seems to fix the problem without too much extra processing.
    Private Sub LineFixUp(ByRef pts() As PointF)
        If pts.Length = 2 Then
            If Math.Sqrt(((pts(0).X - pts(1).X) ^ 2) + ((pts(0).Y - pts(1).Y) ^ 2)) > mViewRect.Width Then

                If Math.Abs(pts(0).X - pts(1).X) < 0.001 Then
                    pts(0).X = (pts(0).X + pts(1).X) / 2
                    pts(1).X = pts(0).X
                    Return
                End If

                If Math.Abs(pts(0).Y - pts(1).Y) < 0.001 Then
                    pts(0).Y = (pts(0).Y + pts(1).Y) / 2
                    pts(1).Y = pts(0).Y
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub DrawWcsOnlyToBuffer()
        If mGfxBuff Is Nothing Then Return
        CreateWcs()
        With mGfx
            .Clear(BackColor)
            .PageUnit = GraphicsUnit.Inch
            .ResetTransform()
            .MultiplyTransform(mMtxWCS)
            'Draw the axis indicator and axis lines
            For Each p As clsDisplayList In mWcsDisplayLists
                mWCSPen.DashStyle = p.DashStyle
                mWCSPen.DashPattern = mAxisDashStyle
                mWCSPen.Color = p.Color
                .DrawLines(mWCSPen, p.Points)
            Next
        End With
        mGfxBuff.Render()
    End Sub

    Public Sub DrawOverlay()
        If mDisplayLists.Count = 0 Then Return
        If mSelectionHitIndices.Count = 0 Then Return
        mLastSelectedMotionRecord = mSelectionHits(0)

        Dim fontHeight As Integer = OverlayFont.Height
        Dim mr As clsMotionRecord = MotionBlockFromSelection()
        Dim mp As New Point(2, 2)
        Dim str As String
        'Draw the overlay.
        Using textBrush As New SolidBrush(Color.FromArgb(180, Not BackColor.R, Not BackColor.G, Not BackColor.B))
            Using g As Graphics = Graphics.FromHwnd(Handle)
                mp.X = 2 : mp.Y = 2
                textBrush.Color = Color.FromArgb(180, Not BackColor.R, Not BackColor.G, Not BackColor.B)
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                str = "T" & mr.Tool.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                g.DrawString(str, OverlayFont, textBrush, mp)
                mp.Offset(0, fontHeight + 2)
                g.DrawString(mr.Comp.ToString, OverlayFont, textBrush, mp)
                mp.Offset(0, fontHeight + 2)
                str = "S" & mr.Speed.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                g.DrawString(str, OverlayFont, textBrush, mp)
                mp.Offset(0, fontHeight + 2)
                str = "F" & mr.FeedRate.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                g.DrawString(str, OverlayFont, textBrush, mp)

                If DrawExtraOverlayInfo Then
                    Select Case mr.MotionType
                        Case Motion.CCARC, Motion.CWARC
                            'Type
                            'Center,Rad
                            'Start,End
                            'sAng,eAng
                            mp.Y = ClientRectangle.Height - ((2 + fontHeight) * 5)
                            str = mr.MotionType.ToString
                            str += " R" & mr.Rad.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            g.DrawString(str, OverlayFont, textBrush, mp)
                            mp.Offset(0, fontHeight + 2)
                            str = "CTR X" & mr.Xcentr.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " Y" & mr.Ycentr.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " Z" & mr.Zcentr.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            g.DrawString(str, OverlayFont, textBrush, mp)


                            mp.Offset(0, fontHeight + 2)
                            str = "X" & mr.Xold.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " > X" & mr.Xpos.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " Y" & mr.Yold.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " > Y" & mr.Ypos.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " Z" & mr.Zold.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " > Z" & mr.Zpos.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            g.DrawString(str, OverlayFont, textBrush, mp)

                            mp.Offset(0, fontHeight + 2)
                            str = "ANG " & AngleToDegrees(mr.Sang)
                            str += " > " & AngleToDegrees(mr.Eang)
                            g.DrawString(str, OverlayFont, textBrush, mp)
                        Case Motion.LINE, Motion.RAPID, Motion.HOLE_I, Motion.HOLE_R
                            mp.Y = ClientRectangle.Height - 2 - (fontHeight * 3)
                            g.DrawString(mr.MotionType.ToString, OverlayFont, textBrush, mp)

                            mp.Offset(0, fontHeight + 2)
                            str = "X" & mr.Xold.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " > X" & mr.Xpos.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " Y" & mr.Yold.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " > Y" & mr.Ypos.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " Z" & mr.Zold.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            str += " > Z" & mr.Zpos.ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
                            g.DrawString(str, OverlayFont, textBrush, mp)

                    End Select
                End If

                mp.Y = ClientRectangle.Height - 2 - fontHeight
                g.DrawString(mr.Codestring, OverlayFont, textBrush, mp)

            End Using
        End Using
    End Sub

    Private Function AngleToDegrees(ByVal angle As Single) As String
        Return (angle * (180.0 / Math.PI)).ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo)
    End Function

    Public Sub DrawTextOverlay(ByVal text As String)
        Dim fontHeight As Integer = OverlayFont.Height
        'Draw the overlay.
        Using textBrush As New SolidBrush(Color.FromArgb(180, Not BackColor.R, Not BackColor.G, Not BackColor.B))
            Using g As Graphics = Graphics.FromHwnd(Handle)
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                g.DrawString(text, OverlayFont, textBrush, New Point(2, ClientRectangle.Height - 2 - fontHeight))
            End Using
        End Using
    End Sub

    Private mWatermarkFont As New Font(System.Drawing.FontFamily.GenericMonospace, 46)
    Public Sub DrawWatermark(ByVal text As String)
        Dim mWatermarkFont As New Font(System.Drawing.FontFamily.GenericMonospace, 46)
        Dim fontHeight As Integer = mWatermarkFont.Height
        'Draw the overlay.
        Using textBrush As New SolidBrush(Color.FromArgb(50, Not BackColor.R, Not BackColor.G, Not BackColor.B))
            Using g As Graphics = Graphics.FromHwnd(Handle)
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                Dim mp As New Point(2, ClientRectangle.Height - 2 - fontHeight)
                g.DrawString(text, mWatermarkFont, textBrush, mp)
            End Using
        End Using
    End Sub

    Public Function MotionBlockFromSelection() As clsMotionRecord
        Return MotionRecords(mDisplayLists(mSelectionHitIndices(0)).MotionIndex)
    End Function

    Private Sub DrawSelectionOverlay(ByVal Indices As List(Of Integer), ByVal selIndex As Integer)
        Dim p As clsDisplayList
        If mDisplayLists.Count = 0 Then Return
        Try

            'Draw the entire buffer first
            If Not (mGfxBuff Is Nothing) Then
                mGfxBuff.Render()
            End If
            'Draw the selection overlay.
            mCurPen.Width = ((1 / mGfx.DpiX) / mScaleToReal) * 4
            Using g As Graphics = Graphics.FromHwnd(Handle)
                With g
                    .SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                    '.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                    .PageUnit = GraphicsUnit.Inch
                    .ResetTransform()
                    .MultiplyTransform(mMtxDraw)
                    If selIndex > -1 Then
                        p = mDisplayLists(Indices(selIndex))
                        If SelectionColor.IsEmpty Then
                            mCurPen.Color = p.Color
                        Else
                            mCurPen.Color = SelectionColor
                        End If
                        mCurPen.EndCap = Drawing2D.LineCap.ArrowAnchor
                        mCurPen.DashStyle = p.DashStyle
                        .DrawLines(mCurPen, p.Points)
                    Else
                        Dim ct As Integer = mDisplayLists.Count
                        For Each i As Integer In Indices
                            If i >= ct Then
                                Continue For
                            End If
                            p = mDisplayLists(i)
                            If SelectionColor.IsEmpty Then
                                mCurPen.Color = p.Color
                            Else
                                mCurPen.Color = SelectionColor
                            End If
                            mCurPen.EndCap = Drawing2D.LineCap.ArrowAnchor
                            mCurPen.DashStyle = p.DashStyle
                            .DrawLines(mCurPen, p.Points)
                        Next
                    End If
                End With
            End Using
            mCurPen.EndCap = Nothing
        Catch ex As Exception
            Debug.Assert(1 = 0, "DrawSelectionOverlay")
        End Try

    End Sub

    Private Sub MG_BasicViewer_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Try
            If Not mGfxBuff Is Nothing Then
                If mDrawOnPaint Then
                    mGfxBuff.Render()
                    'UpdateElementDetails()
                End If
            End If
        Catch
            Debug.Assert(1 = 0, "MG_BasicViewer_Paint")
        End Try
        'Debug.Print("MG_BasicViewer_Paint")
    End Sub

    Public Sub Init()
        If Not Visible Then Return
        Using ms As New System.IO.MemoryStream(My.Resources.SelectOne)
            mSelectCursor = New Cursor(ms)
        End Using
        Using ms As New System.IO.MemoryStream(My.Resources.SelectEtc)
            mSelectEtcCursor = New Cursor(ms)
        End Using

        mCancelSlowDisplayList = False
        mAllowSlowDisplayList = False

        SetBufferContext()
        mClientRect = ClientRectangle
        mSelectionHits.Clear()
        ArcSegmentCount = 16
        If mDisplayLists.Count = 0 Then
            WindowViewport(-2.0F, -2.0F, 2.0F, 2.0F)
            SetViewMatrix()
            DrawWcsOnlyToBuffer()
        Else
#If DEBUG Then
            FindExtents()
#End If
            DrawDisplayLists()
        End If
    End Sub

    Private Sub MG_BasicViewer_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Init()
    End Sub

    Private Function ArcLength(ByVal Xe As Single, ByVal Xs As Single,
                    ByVal Ye As Single, ByVal Ys As Single,
                    ByVal Ze As Single, ByVal Zs As Single,
                    ByVal r As Single, ByRef Startang As Single, ByRef Endang As Single, ByRef Wplane As Integer) As Single

        Dim sngTotalAngle As Single = Math.Abs(Startang - Endang)

        Select Case Wplane
            Case Motion.XY_PLN
                Return (Math.Abs(Ze - Zs) + ((sngTotalAngle / ONE_RADIAN) * (r * 2 * PI_S)))
            Case Motion.XZ_PLN
                Return (Math.Abs(Ye - Ys) + ((sngTotalAngle / ONE_RADIAN) * (r * 2 * PI_S)))
            Case Motion.YZ_PLN
                Return (Math.Abs(Xe - Xs) + ((sngTotalAngle / ONE_RADIAN) * (r * 2 * PI_S)))
        End Select
    End Function

#Region "TimeCalculations"
    Dim zeroFeedDetected As Boolean = False

    Public Sub CalculateTime(ByRef totalCutTime As Double, ByRef totalRapidTime As Double)
        totalCutTime = 0
        totalRapidTime = 0

        If MotionRecords.Count = 0 Then Return
        If mRangeEnd > MotionRecords.Count Then
            mRangeEnd = MotionRecords.Count - 1
        End If
        ArcSegmentCount = 36
        For mGfxIndex = mRangeStart To mRangeEnd
            mCurMotionRec = MotionRecords(mGfxIndex)
            If mCurMotionRec.MotionType <> Motion.RAPID AndAlso mCurMotionRec.FeedRate = 0 Then
                zeroFeedDetected = True
            End If
            CalculateMotionRecordLengthAndTime(totalCutTime, totalRapidTime)
        Next

    End Sub

    Private Sub CalculateMotionRecordLengthAndTime(ByRef totalCutTime As Double, ByRef totalRapidTime As Double)
        Dim cutTime As Double = 0
        Dim rapidTime As Double = 0
        Dim feedrate As Single = 0
        Dim rapidrate As Single = 0
        CalculateMotionRecordLength()

        If mCurMotionRec.Speed = 0 Then
            Return
        End If


        If mCurMotionRec.FeedRate = 0 Then
            feedrate = 0.0000001
        Else
            feedrate = mCurMotionRec.FeedRate
        End If
        rapidrate = mCurMotionRec.RapidRate

        With mCurMotionRec
            Select Case MachineType
                Case MacGen.MachineType.MILL
                    Select Case .FeedMode
                        Case FeedMode.UNIT_PER_MIN 'Default for mill
                            cutTime = (.CuttingLength / feedrate)
                        Case FeedMode.UNIT_PER_REV
                            cutTime = (.CuttingLength / feedrate) / .Speed
                    End Select
                    rapidTime = (.RapidLength / rapidrate)
                    totalCutTime += cutTime
                    totalRapidTime += rapidTime
                    .MotionTime = cutTime + rapidTime
                Case MacGen.MachineType.LATHEDIA, MacGen.MachineType.LATHERAD

                    Select Case .FeedMode
                        Case FeedMode.UNIT_PER_MIN
                            cutTime = (.CuttingLength / feedrate)
                            rapidTime = (.RapidLength / rapidrate)
                            totalCutTime += cutTime
                            totalRapidTime += rapidTime
                            .MotionTime = cutTime + rapidTime

                        Case FeedMode.UNIT_PER_REV 'Default for lathe
                            Select Case .SpeedMode
                                Case SpeedMode.SURFACE_SPEED 'G96 CONSTANT SURFACE SPEED ON
                                    Select Case .MotionType
                                        Case Motion.CCARC, Motion.CWARC
                                            cutTime = LathePolyArcTime() 'If this is an arc we need to break it into lines
                                            totalCutTime += cutTime
                                            .MotionTime = cutTime
                                        Case Motion.LINE
                                            cutTime = LatheCutTimeBySFPM(.Xold, .Xpos, .Zpos - .Zold, feedrate, .Speed, .MaxRpm, MachineType, .FeedMode)
                                            totalCutTime += cutTime
                                            .MotionTime = cutTime
                                        Case Motion.RAPID
                                            rapidTime = (.RapidLength / rapidrate) 'RPM makes no difference for rapid
                                            totalRapidTime += rapidTime
                                            .MotionTime = rapidTime
                                        Case Else 'Holes must be constant RPM
                                            cutTime = (.CuttingLength / feedrate) / .Speed
                                            rapidTime = (.RapidLength / rapidrate)
                                            totalCutTime += cutTime
                                            totalRapidTime += rapidTime
                                            .MotionTime = totalCutTime + totalRapidTime
                                    End Select

                                Case SpeedMode.RPM 'G97 CONSTANT SURFACE SPEED OFF / REVOLUTION PER MINUTE ON
                                    cutTime = (.CuttingLength / feedrate) / .Speed
                                    rapidTime = (.RapidLength / rapidrate) 'RPM makes no difference for rapid
                                    totalCutTime += cutTime
                                    totalRapidTime += rapidTime
                                    .MotionTime = cutTime + rapidTime
                            End Select
                    End Select
            End Select
        End With

    End Sub

    Private Function LathePolyArcTime() As Double
        Dim s As Integer 'counter
        Dim sngSegments As Integer ' number of angular segments
        Dim sngAngle As Single
        Dim sngTotalAngle As Single
        Dim arcDir As Single
        Dim arcTime As Double = 0
        With mCurMotionRec
            Select Case .MotionType
                Case Motion.CCARC
                    arcDir = 1
                Case Motion.CWARC
                    arcDir = -1
            End Select
            sngTotalAngle = Math.Abs(.Sang - .Eang)
            sngSegments = CInt(Int(sngTotalAngle / mSegAngle))
            'Re-calculate angle increment
            sngAngle = (arcDir * (sngTotalAngle / sngSegments))
            Select Case .ArcPlane
                Case Motion.XY_PLN
                    For s = 1 To sngSegments
                        arcTime += LatheCutTimeBySFPM(.Xold, .Xpos, .Ypos - .Yold, .FeedRate, .Speed, .MaxRpm, MachineType, .FeedMode)
                    Next s
                Case Motion.XZ_PLN
                    For s = 1 To sngSegments
                        arcTime += LatheCutTimeBySFPM(.Xold, .Xpos, .Zpos - .Zold, .FeedRate, .Speed, .MaxRpm, MachineType, .FeedMode)
                    Next s

                Case Motion.YZ_PLN
                    For s = 1 To sngSegments
                        arcTime += LatheCutTimeBySFPM(.Yold, .Ypos, .Zpos - .Zold, .FeedRate, .Speed, .MaxRpm, MachineType, .FeedMode)
                    Next s
            End Select
        End With
        Return arcTime
    End Function

    ''' <summary>
    ''' If we do not know RPM but the machine has a max RPM.
    ''' </summary>
    ''' <returns>Time in minutes to travel the distance</returns>
    ''' <remarks>Only works with linear moves</remarks>
    Private Function LatheCutTimeBySFPM(ByVal od As Single,
                                                                            ByVal id As Single,
                                                                            ByVal zDist As Single,
                                                                            ByVal feed As Single,
                                                                            ByVal speed As Single,
                                                                            ByVal maxRPM As Single,
                                                                            ByVal machineType As MacGen.MachineType,
                                                                            ByVal feedMode As FeedMode) As Double
        Dim rpmOd As Double
        Dim rpmId As Double
        Dim L, N, maxRpmDia As Double
        Dim retTime As Double
        Dim tmp As Single
        Dim travel As Double
        Dim surfaceInchesPerMin As Single


        'L = pi*N*(D+d)/2 where N = (D-d)/(2*t)

        od = Math.Abs(od)
        id = Math.Abs(id)
        'Perform all calcs using diameter.
        If machineType = MacGen.MachineType.LATHERAD Then
            od *= 2
            id *= 2
        End If

        If id > od Then 'swap
            tmp = id
            id = od
            od = tmp
        End If

        'Determine the rpm of the od and id.
        Select Case mCurMotionRec.Units
            Case MachineUnits.ENGLISH
                surfaceInchesPerMin = mCurMotionRec.Speed * 12.0F 'Convert ot furface feet to inches per min
            Case MachineUnits.METRIC
                surfaceInchesPerMin = mCurMotionRec.Speed * 39.37008F 'Convert surface meters to inches per min
        End Select

        'Determine the diameter where the rpm maxes out.
        maxRpmDia = surfaceInchesPerMin / maxRPM / Math.PI

        rpmOd = surfaceInchesPerMin / (Math.PI * od)
        rpmId = surfaceInchesPerMin / (Math.PI * id)
        mCurMotionRec.RPM = CSng(rpmOd)

        If od = id Then 'Const rpm
            If zDist = 0 Then Return 0
            travel = Math.Abs(zDist)
            If feedMode = MacGen.FeedMode.UNIT_PER_MIN Then
                Return travel * feed
            Else
                Return (travel / feed) / rpmOd
            End If
        Else '\ Variable rpm
            travel = Math.Sqrt(((od - id) ^ 2) + (zDist ^ 2))
        End If

        'Feed per minute requires no further calculations
        If feedMode = MacGen.FeedMode.UNIT_PER_MIN Then
            Return travel * feed
        End If


        If rpmOd > maxRPM Then 'RPM is constant
            retTime = (travel / feed) / maxRPM
        Else
            If rpmId > maxRPM Then
                Dim variableRpmLen As Double = (od - maxRpmDia)
                Dim fixedRpmLen As Double = (maxRpmDia - id)
                Dim ratio As Double = fixedRpmLen / variableRpmLen
                variableRpmLen = travel / ratio
                fixedRpmLen = travel - variableRpmLen

                'Variable RPM time
                N = variableRpmLen / feed 'Number of turns
                L = Math.PI * N * ((od + maxRpmDia) / 2) 'Length using the mean circumfrence
                retTime = L / surfaceInchesPerMin

                'Const RPM time
                retTime += (fixedRpmLen / feed) / maxRPM

            Else 'No max rpm calcs needed.
                N = travel / feed 'Number of turns
                L = Math.PI * N * ((od + id) / 2) 'Length using the mean circumfrence
                retTime = L / surfaceInchesPerMin
            End If

        End If

        Return retTime

    End Function

    Private Sub CalculateMotionRecordLength()
        Dim xleg1, yleg1, zleg1, xleg2, yleg2, zleg2 As Single

        Select Case mCurMotionRec.MotionType
            Case Motion.RAPID
                If mCurMotionRec.Rotate Then
                    CalculateLengthOfRotaryArc(mCurMotionRec.Xpos, mCurMotionRec.Xold, mCurMotionRec.Ypos, mCurMotionRec.Yold, mCurMotionRec.Zpos, mCurMotionRec.Zold, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                Else
                    If mDrawDogLeg Then
                        CalculateDogLegMotion(xleg1, yleg1, zleg1, xleg2, yleg2, zleg2)
                        mCurMotionRec.RapidLength = VectorLength(mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.Zold, xleg1, yleg1, zleg1)
                        mCurMotionRec.RapidLength += VectorLength(xleg1, yleg1, zleg1, xleg2, yleg2, zleg2)
                        mCurMotionRec.RapidLength += VectorLength(xleg2, yleg2, zleg2, mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos)
                    End If
                    mCurMotionRec.RapidLength = VectorLength(mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.Zold, mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos)
                End If

            Case Motion.HOLE_I, Motion.HOLE_R
                If DrawRapidLines Then
                    CalculateDogLegMotion(xleg1, yleg1, zleg1, xleg2, yleg2, zleg2)

                    'A rotary move is on the drill cycle line
                    If mCurMotionRec.Rotate Then
                        If mCurMotionRec.MotionType = Motion.HOLE_I Then 'Return to inital Z
                            CalculateLengthOfRotaryArc(mCurMotionRec.Xpos, mCurMotionRec.Xold, mCurMotionRec.Ypos, mCurMotionRec.Yold, mCurMotionRec.DrillClear, mCurMotionRec.DrillClear, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                        Else
                            CalculateLengthOfRotaryArc(mCurMotionRec.Xpos, mCurMotionRec.Xold, mCurMotionRec.Ypos, mCurMotionRec.Yold, mCurMotionRec.Rpoint, mCurMotionRec.Rpoint, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                        End If
                    Else
                        mCurMotionRec.RapidLength = VectorLength(mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.Zold, xleg1, yleg1, mCurMotionRec.Rpoint)
                        mCurMotionRec.RapidLength += VectorLength(xleg1, yleg1, mCurMotionRec.Rpoint, mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Rpoint)
                    End If
                End If

                mCurMotionRec.CuttingLength = VectorLength(mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Rpoint, mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos)
                mCurMotionRec.RapidLength += VectorLength(mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.DrillClear, mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos)

            Case Motion.LINE
                If mCurMotionRec.Rotate Then
                    CalculateLengthOfRotaryArc(mCurMotionRec.Xpos, mCurMotionRec.Xold, mCurMotionRec.Ypos, mCurMotionRec.Yold, mCurMotionRec.Zpos, mCurMotionRec.Zold, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                Else
                    mCurMotionRec.CuttingLength = VectorLength(mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.Zold, mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos)
                End If
            Case Motion.CCARC, Motion.CWARC
                mCurMotionRec.CuttingLength = ArcLength(mCurMotionRec.Xpos, mCurMotionRec.Xold, mCurMotionRec.Ypos, mCurMotionRec.Yold, mCurMotionRec.Zpos, mCurMotionRec.Zold, mCurMotionRec.Rad, mCurMotionRec.Sang, mCurMotionRec.Eang, mCurMotionRec.ArcPlane)
        End Select
    End Sub

    Private Sub CalculateLengthOfRotaryArc(ByVal Xe As Single, ByVal Xs As Single, ByVal Ye As Single, ByVal Ys As Single, ByVal Ze As Single, ByVal Zs As Single, ByVal Startang As Single, ByVal Endang As Single, ByVal ArcDir As Single)
        Dim rotSegs As Integer ' number of angular segments
        Dim totalAngle, radFromAxis As Single

        If RotaryType = RotaryMotionType.BMC Then 'Like BMC
            If ArcDir = -1 Then
                Endang = (Endang - ONE_RADIAN)
            Else
                If ArcDir = 1 AndAlso Endang < Startang Then 'take long way
                    Endang = ONE_RADIAN + Endang
                End If
            End If
        End If
        totalAngle = (Endang - Startang)
        rotSegs = CInt(Math.Abs(totalAngle / mSegAngle))

        Select Case RotaryPlane
            Case Axis.X  'X
                If mCurMotionRec.MotionType = Motion.RAPID Then
                    mCurMotionRec.RapidLength = (Math.Abs(Xe - Xs) + ((Math.Abs(totalAngle) / ONE_RADIAN) * (radFromAxis * 2 * PI_S)))
                Else
                    mCurMotionRec.CuttingLength = (Math.Abs(Xe - Xs) + ((Math.Abs(totalAngle) / ONE_RADIAN) * (radFromAxis * 2 * PI_S)))
                End If

            Case Axis.Y
                If mCurMotionRec.MotionType = Motion.RAPID Then
                    mCurMotionRec.RapidLength = (Math.Abs(Ye - Ys) + ((Math.Abs(totalAngle) / ONE_RADIAN) * (radFromAxis * 2 * PI_S)))
                Else
                    mCurMotionRec.CuttingLength = (Math.Abs(Ye - Ys) + ((Math.Abs(totalAngle) / ONE_RADIAN) * (radFromAxis * 2 * PI_S)))
                End If
            Case Axis.Z
                'Not implemented
        End Select
    End Sub

#End Region

#Region "Graphics"
    Private Sub PolyArc(ByVal Xctr As Single, ByVal Yctr As Single, ByVal Zctr As Single,
                    ByVal Xe As Single, ByVal Xs As Single,
                    ByVal Ye As Single, ByVal Ys As Single,
                    ByVal Ze As Single, ByVal Zs As Single,
                    ByVal r As Single, ByRef Startang As Single, ByRef Endang As Single,
                    ByVal ArcDir As Integer, ByRef Wplane As Integer)

        Dim s As Integer 'counter
        Dim sngSegments As Integer ' number of angular segments
        Dim helixSeg As Single
        Dim sngAngle As Single
        Dim sngTotalAngle As Single
        Dim circumference As Single = PI_S * (r * 2)
        sngTotalAngle = Math.Abs(Startang - Endang)
        Dim circLen As Single = circumference * (sngTotalAngle / ONE_RADIAN)
        sngSegments = CInt(Int(sngTotalAngle / mSegAngle))
        Dim dxfKey As String = String.Empty
        If SavingDXF Then
            Dim circ As Boolean = sngTotalAngle = ONE_RADIAN
            If ArcDir = -1 Then
                If circ Then
                    dxfKey = "@CW_CIRCLE"
                Else
                    dxfKey = "@CW_ARC"
                End If
            Else
                If circ Then
                    dxfKey = "@CCW_CIRCLE"
                Else
                    dxfKey = "@CCW_ARC"
                End If
            End If
        End If

        Dim doDXF As Boolean = SavingDXF
        'What we want here is to specify a chordial length the will result in  a segment count
        'If circLen / sngSegments < 0.01 Then
        '    'Debug.Print(CStr(circLen / sngSegments))
        '    'Debug.Print(sngSegments.ToString)
        '    sngSegments = CInt(circLen / 0.01)
        'End If

        'Re-calculate angle increment
        sngAngle = (ArcDir * (sngTotalAngle / sngSegments))
        SavingDXF = False
        LineEnd4D(Xs, Ys, Zs)
        SavingDXF = doDXF
        mPoints.Clear()
        Select Case Wplane
            Case Motion.XY_PLN
                helixSeg = (Ze - Zs) / sngSegments
                If SavingDXF Then
                    Output_DXF_Section(dxfKey, Xs, Ys, Zs, Xe, Ye, Ze)
                Else
                    For s = 1 To sngSegments
                        LineEnd4D(CSng(Xctr + (r * Math.Cos((s * sngAngle) + Startang))), CSng(Yctr + (r * Math.Sin((s * sngAngle) + Startang))), Zs + helixSeg * s)
                    Next s
                End If
            Case Motion.XZ_PLN
                helixSeg = (Ye - Ys) / sngSegments
                For s = 1 To sngSegments
                    LineEnd4D(CSng(Xctr + (r * Math.Cos((s * sngAngle) + Startang))), Ys + helixSeg * s, CSng(Zctr + (r * Math.Sin((s * sngAngle) + Startang))))
                Next s

            Case Motion.YZ_PLN
                helixSeg = (Xe - Xs) / sngSegments
                For s = 1 To sngSegments
                    LineEnd4D(Xs + helixSeg * s, CSng(Yctr + (r * Math.Cos((s * sngAngle) + Startang))), CSng(Zctr + (r * Math.Sin((s * sngAngle) + Startang))))
                Next s

        End Select
        SavingDXF = False
        LineEnd4D(Xe, Ye, Ze)
        SavingDXF = doDXF

    End Sub

    Private Sub DrawRotaryArc(ByVal Xe As Single, ByVal Xs As Single, ByVal Ye As Single, ByVal Ys As Single, ByVal Ze As Single, ByVal Zs As Single, ByVal Startang As Single, ByVal Endang As Single, ByVal ArcDir As Single)
        Dim s As Integer 'counter
        Dim rotSegs As Integer ' number of angular segments
        Dim axisSeg1, axisSeg3, angle, totalAngle, radFromAxis As Single

        If RotaryType = RotaryMotionType.BMC Then 'Like BMC
            If ArcDir = -1 Then
                Endang = (Endang - ONE_RADIAN)
            Else
                If ArcDir = 1 AndAlso Endang < Startang Then 'take long way
                    Endang = ONE_RADIAN + Endang
                End If
            End If
        End If
        totalAngle = (Endang - Startang)
        rotSegs = CInt(Math.Abs(totalAngle / mSegAngle))

        Select Case RotaryPlane
            Case Axis.X  'X
                Startang = (Startang + AngleFromPoint(Zs, Ys, False) * RotaryDirection) * RotaryDirection
                Endang = (Endang + AngleFromPoint(Zs, Ys, False) * RotaryDirection) * RotaryDirection

                'Re-calculate angle increment
                angle = (totalAngle / rotSegs) * RotaryDirection
                axisSeg1 = (Xe - Xs) / rotSegs
                axisSeg3 = (Ze - Zs) / rotSegs

                radFromAxis = VectorLength(0, Ys, Zs, 0, 0, 0)
                LineEnd3D(Xs, CSng(radFromAxis * Math.Sin(Startang)), CSng(radFromAxis * Math.Cos(Startang)))
                mPoints.Clear()
                For s = 1 To rotSegs
                    radFromAxis = VectorLength(0, Ys, Zs + (axisSeg3 * s), 0, 0, 0)
                    LineEnd3D(Xs + (axisSeg1 * s), CSng(radFromAxis * Math.Sin((s * angle) + Startang)), CSng(radFromAxis * Math.Cos((s * angle) + Startang)))
                Next s

            Case Axis.Y
                Startang = (Startang - AngleFromPoint(Zs, Xs, False) * RotaryDirection) * -RotaryDirection
                Endang = (Endang - AngleFromPoint(Zs, Xs, False) * RotaryDirection) * -RotaryDirection

                'Re-calculate angle increment
                angle = (totalAngle / rotSegs) * -RotaryDirection
                axisSeg1 = (Ye - Ys) / rotSegs
                axisSeg3 = (Ze - Zs) / rotSegs
                'Debug.Print Segments
                radFromAxis = VectorLength(Xs, 0, Zs, 0, 0, 0)
                LineEnd3D(CSng(radFromAxis * Math.Sin(Startang)), Ys, CSng(radFromAxis * Math.Cos(Startang)))
                mPoints.Clear()
                For s = 1 To rotSegs
                    radFromAxis = VectorLength(Xs, 0, Zs + (axisSeg3 * s), 0, 0, 0)
                    LineEnd3D(CSng(radFromAxis * Math.Sin((s * angle) + Startang)), Ys + (axisSeg1 * s), CSng(radFromAxis * Math.Cos((s * angle) + Startang)))
                Next s
            Case Axis.Z
                'Not implemented
        End Select
        LineEnd4D(Xe, Ye, Ze)
    End Sub

    Private Sub Line3D(ByVal Xs As Single, ByVal Ys As Single, ByVal Zs As Single, ByVal Xe As Single, ByVal Ye As Single, ByVal Ze As Single)
        Dim yawXs, yawYs, rollZs As Single
        Dim yawXe, yawYe, rollZe, temp As Single

        Select Case RotaryPlane
            Case Axis.X 'x
                'X-axis start pre-rotate
                temp = (mCosRot * Ys) - (mSinRot * Zs)
                Zs = (mSinRot * Ys) + (mCosRot * Zs)
                Ys = temp
                'end pre-rotate
                temp = (mCosRot * Ye) - (mSinRot * Ze)
                Ze = (mSinRot * Ye) + (mCosRot * Ze)
                Ye = temp
            Case Axis.Y 'y
                'Y-axis start pre-rotate
                temp = (mCosRot * Zs) - (mSinRot * Xs)
                Xs = (mCosRot * Xs) + (mSinRot * Zs)
                Zs = temp
                'end
                temp = (mCosRot * Ze) - (mSinRot * Xe)
                Xe = (mCosRot * Xe) + (mSinRot * Ze)
                Ze = temp
            Case Axis.Z 'z
                'Z-axis start pre-rotate
                temp = (mCosRot * Xs) - (mSinRot * Ys)
                Xs = (mSinRot * Xs) + (mCosRot * Ys)
                Ys = temp
                'end pre-rotate
                temp = (mCosRot * Xe) - (mSinRot * Ye)
                Xe = (mSinRot * Xe) + (mCosRot * Ye)
                Ye = temp

        End Select

        If SavingDXF Then Output_DXF_Section("@LINE", xOld, yOld, zOld, Xe, Ye, Ze)
        xOld = Xe
        yOld = Ye
        zOld = Ze

        'Start
        '===========================
        'Z twist
        yawXs = (mCosYaw * Xs) - (mSinYaw * Ys)
        yawYs = (mSinYaw * Xs) + (mCosYaw * Ys)

        'Y twist
        rollZs = (mCosRoll * Zs) - (mSinRoll * yawXs)
        yawXs = (mCosRoll * yawXs) + (mSinRoll * Zs) 'New X

        'X twist
        yawYs = (mCosPitch * yawYs) - (mSinPitch * rollZs) 'New Y

        'End
        '===========================
        'Z twist
        yawXe = (mCosYaw * Xe) - (mSinYaw * Ye)
        yawYe = (mSinYaw * Xe) + (mCosYaw * Ye)
        'Y twist

        rollZe = (mCosRoll * Ze) - (mSinRoll * yawXe)
        yawXe = (mCosRoll * yawXe) + (mSinRoll * Ze) 'New X
        'X twist
        yawYe = (mCosPitch * yawYe) - (mSinPitch * rollZe) 'New Y

        Line(yawXs, yawYs, yawXe, yawYe)
    End Sub

    Public Shared Function VectorLength(ByVal X1 As Single, ByVal Y1 As Single, ByVal Z1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal Z2 As Single) As Single
        Return CSng(Math.Sqrt(((X1 - x2) ^ 2) + ((Y1 - y2) ^ 2) + ((Z1 - Z2) ^ 2)))
    End Function

    Public Shared Function AngleFromPoint(ByVal x As Single, ByVal y As Single, ByVal deg As Boolean) As Single
        Dim theta As Single
        If x > 0 AndAlso y > 0 Then ' Quadrant 1
            theta = CSng(Math.Atan(y / x))
        ElseIf x < 0 AndAlso y > 0 Then  ' Quadrant 2
            theta = CSng(Math.Atan(y / x) + Math.PI)
        ElseIf x < 0 AndAlso y < 0 Then  ' Quadrant 3
            theta = CSng(Math.Atan(y / x) + Math.PI)
        ElseIf x > 0 AndAlso y < 0 Then  ' Quadrant 4
            theta = CSng(Math.Atan(y / x) + 2 * Math.PI)
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

    Private Sub LineEnd4D(ByVal Xe As Single, ByVal Ye As Single, ByVal Ze As Single)
        Dim yawXe, yawYe, rollZe, temp As Single

        Select Case RotaryPlane
            Case Axis.X 'x
                'X-axis start pre-rotate
                'end pre-rotate
                temp = (mCosRot * Ye) - (mSinRot * Ze)
                Ze = (mSinRot * Ye) + (mCosRot * Ze)
                Ye = temp
            Case Axis.Y 'y
                'Y-axis start pre-rotate
                'end
                temp = (mCosRot * Ze) - (mSinRot * Xe)
                Xe = (mCosRot * Xe) + (mSinRot * Ze)
                Ze = temp
            Case Axis.Z 'z
                'Z-axis start pre-rotate
                'end pre-rotate
                temp = (mCosRot * Xe) - (mSinRot * Ye)
                Xe = (mSinRot * Xe) + (mCosRot * Ye)
                Ye = temp
        End Select

        If SavingDXF Then Output_DXF_Section("@LINE", xOld, yOld, zOld, Xe, Ye, Ze)
        xOld = Xe
        yOld = Ye
        zOld = Ze


        'End
        '===========================
        'Z twist
        yawXe = (mCosYaw * Xe) - (mSinYaw * Ye)
        yawYe = (mSinYaw * Xe) + (mCosYaw * Ye)
        'Y twist
        rollZe = (mCosRoll * Ze) - (mSinRoll * yawXe)
        yawXe = (mCosRoll * yawXe) + (mSinRoll * Ze) 'New X
        'X twist
        yawYe = (mCosPitch * yawYe) - (mSinPitch * rollZe) 'New Y
        LineEnd(yawXe, yawYe)

    End Sub

    Private Sub Point3D(ByVal Xe As Single, ByVal Ye As Single, ByVal Ze As Single)
        xOld = Xe
        yOld = Ye
        zOld = Ze

        Dim yawXe, yawYe, rollZe As Single
        'End
        '===========================
        'Z twist
        yawXe = (mCosYaw * Xe) - (mSinYaw * Ye)
        yawYe = (mSinYaw * Xe) + (mCosYaw * Ye)
        'Y twist
        rollZe = (mCosRoll * Ze) - (mSinRoll * yawXe)
        yawXe = (mCosRoll * yawXe) + (mSinRoll * Ze) 'New X
        'X twist
        yawYe = (mCosPitch * yawYe) - (mSinPitch * rollZe) 'New Y

        mPoints.Add(New PointF(yawXe, yawYe))
        mLastPos.X = yawXe
        mLastPos.Y = yawYe

    End Sub

    Private Sub LineEnd3D(ByVal Xe As Single, ByVal Ye As Single, ByVal Ze As Single)
        If SavingDXF Then Output_DXF_Section("@LINE", xOld, yOld, zOld, Xe, Ye, Ze)
        xOld = Xe
        yOld = Ye
        zOld = Ze


        Dim yawXe, yawYe, rollZe As Single
        'End
        '===========================
        'Z twist
        yawXe = (mCosYaw * Xe) - (mSinYaw * Ye)
        yawYe = (mSinYaw * Xe) + (mCosYaw * Ye)
        'Y twist
        rollZe = (mCosRoll * Ze) - (mSinRoll * yawXe)
        yawXe = (mCosRoll * yawXe) + (mSinRoll * Ze) 'New X
        'X twist
        yawYe = (mCosPitch * yawYe) - (mSinPitch * rollZe) 'New Y
        LineEnd(yawXe, yawYe)
    End Sub

#Region "DXF"
    Public Sub SaveAsDXF(ByVal templateFile As String, ByVal dxfOutFile As String)
        mDxfOutFile = dxfOutFile
        '(?<SEC>@.[^@]*)
        '(?<WORD>\[.[^\[]*\])
        Dim sectionMatches As New System.Text.RegularExpressions.Regex("@.[^@]*", System.Text.RegularExpressions.RegexOptions.Singleline)
        Dim templateContents As String = IO.File.ReadAllText(templateFile)
        Dim sec As System.Text.RegularExpressions.Match = sectionMatches.Match(templateContents)
        Dim key As String
        Dim secName As String
        Dim secContents As String
        mSectionsDXF = New Dictionary(Of String, String)
        While sec.Success
            With sec
                secName = sec.Value.Substring(0, sec.Value.IndexOf(vbCrLf)).Trim
                secContents = sec.Value.Substring(sec.Value.IndexOf(vbCrLf) + 2).ToUpper
                'Debug.Print(secName)
                mSectionsDXF.Add(secName, secContents)
                sec = .NextMatch
            End With
        End While

        SavingDXF = True
        IO.File.WriteAllText(mDxfOutFile, String.Empty)
        key = "@START"
        Output_DXF_Section(key, 0, 0, 0, 0, 0, 0)

        CreateDisplayLists()

        key = "@END"
        Output_DXF_Section(key, 0, 0, 0, 0, 0, 0)
        SavingDXF = False
        mSectionsDXF.Clear()
        mSectionsDXF = Nothing
        'Process end
    End Sub

    Private Sub Output_DXF_Section(ByVal key As String)
        Output_DXF_Section(key, mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.Zold, mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos)
    End Sub

    Private Sub Output_DXF_Section(ByVal key As String, ByVal Xs As Single, ByVal Ys As Single, ByVal Zs As Single, ByVal Xe As Single, ByVal Ye As Single, ByVal Ze As Single)
        Dim words As New System.Text.RegularExpressions.Regex("\[.[^\[]*\]", System.Text.RegularExpressions.RegexOptions.Singleline)
        Dim retSec As String
        Dim rawSec As String
        If mSectionsDXF.ContainsKey(key) Then
            rawSec = mSectionsDXF(key)
            retSec = rawSec
            Dim wrd As System.Text.RegularExpressions.Match = words.Match(rawSec)
            While wrd.Success
                With wrd
                    Select Case wrd.Value.ToUpper
                        Case "[XPOS]"
                            retSec = retSec.Replace("[XPOS]", Format(Xe, "##0.0###"))
                        Case "[YPOS]"
                            retSec = retSec.Replace("[YPOS]", Format(Ye, "##0.0###"))
                        Case "[ZPOS]"
                            retSec = retSec.Replace("[ZPOS]", Format(Ze, "##0.0###"))
                        Case "[XOLD]"
                            retSec = retSec.Replace("[XOLD]", Format(Xs, "##0.0###"))
                        Case "[YOLD]"
                            retSec = retSec.Replace("[YOLD]", Format(Ys, "##0.0###"))
                        Case "[ZOLD]"
                            retSec = retSec.Replace("[ZOLD]", Format(Xs, "##0.0###"))
                        Case "[SANG]"
                            Dim sang As Single = CSng(mCurMotionRec.Sang * (180.0 / Math.PI))
                            retSec = retSec.Replace("[SANG]", Format(sang, "##0.0###"))
                        Case "[EANG]"
                            Dim eang As Single = CSng(mCurMotionRec.Eang * (180.0 / Math.PI))
                            retSec = retSec.Replace("[EANG]", Format(eang, "##0.0###"))
                        Case "[RAD]"
                            retSec = retSec.Replace("[RAD]", Format(mCurMotionRec.Rad, "##0.0###"))
                        Case "[XCENTR]"
                            retSec = retSec.Replace("[XCENTR]", Format(mCurMotionRec.Xcentr, "##0.0###"))
                        Case "[YCENTR]"
                            retSec = retSec.Replace("[YCENTR]", Format(mCurMotionRec.Ycentr, "##0.0###"))
                        Case "[RPOINT]"
                            retSec = retSec.Replace("[RPOINT]", Format(mCurMotionRec.Rpoint, "##0.0###"))
                        Case "[TOOL]"
                            retSec = retSec.Replace("[TOOL]", Format(mCurMotionRec.Tool, "##0.0###"))
                        Case Else
                            retSec = retSec.Replace(wrd.Value.ToUpper, String.Empty)
                    End Select
                    wrd = .NextMatch()
                End With
            End While
            IO.File.AppendAllText(mDxfOutFile, retSec)
        End If
    End Sub

#End Region

    Private Sub CalculateDogLegMotion(ByRef xleg1 As Single,
                                                          ByRef yleg1 As Single,
                                                          ByRef zleg1 As Single,
                                                          ByRef xleg2 As Single,
                                                          ByRef yleg2 As Single,
                                                          ByRef zleg2 As Single)

        Dim xleg, yleg, zleg As Single
        Dim xdir, ydir, zdir As Integer
        xdir = Math.Sign(mCurMotionRec.Xpos - mCurMotionRec.Xold)
        ydir = Math.Sign(mCurMotionRec.Ypos - mCurMotionRec.Yold)
        zdir = Math.Sign(mCurMotionRec.Zpos - mCurMotionRec.Zold)

        xleg = Math.Abs(mCurMotionRec.Xpos - mCurMotionRec.Xold)
        yleg = Math.Abs(mCurMotionRec.Ypos - mCurMotionRec.Yold)
        zleg = Math.Abs(mCurMotionRec.Zpos - mCurMotionRec.Zold)

        If xleg <= yleg AndAlso yleg <= zleg Then 'Long Z
            xleg1 = mCurMotionRec.Xpos
            yleg1 = mCurMotionRec.Yold + xleg * ydir
            zleg1 = mCurMotionRec.Zold + xleg * zdir
            xleg2 = mCurMotionRec.Xpos
            yleg2 = mCurMotionRec.Ypos
            zleg2 = mCurMotionRec.Zold + yleg * zdir
        ElseIf xleg <= zleg AndAlso zleg <= yleg Then
            xleg1 = mCurMotionRec.Xpos
            yleg1 = mCurMotionRec.Yold + xleg * ydir
            zleg1 = mCurMotionRec.Zold + xleg * zdir
            xleg2 = mCurMotionRec.Xpos
            yleg2 = mCurMotionRec.Yold + zleg * ydir
            zleg2 = mCurMotionRec.Zpos
        ElseIf zleg <= yleg AndAlso yleg <= xleg Then
            xleg1 = mCurMotionRec.Xold + zleg * xdir
            yleg1 = mCurMotionRec.Yold + zleg * ydir
            zleg1 = mCurMotionRec.Zpos
            xleg2 = mCurMotionRec.Xold + yleg * xdir
            yleg2 = mCurMotionRec.Ypos
            zleg2 = mCurMotionRec.Zpos
        ElseIf zleg <= xleg AndAlso xleg <= yleg Then
            xleg1 = mCurMotionRec.Xold + zleg * xdir
            yleg1 = mCurMotionRec.Yold + zleg * ydir
            zleg1 = mCurMotionRec.Zpos
            xleg2 = mCurMotionRec.Xpos
            yleg2 = mCurMotionRec.Yold + xleg * ydir
            zleg2 = mCurMotionRec.Zpos
        ElseIf yleg <= zleg AndAlso zleg <= xleg Then
            xleg1 = mCurMotionRec.Xold + yleg * xdir
            yleg1 = mCurMotionRec.Ypos
            zleg1 = mCurMotionRec.Zold + yleg * zdir
            xleg2 = mCurMotionRec.Xold + zleg * xdir
            yleg2 = mCurMotionRec.Ypos
            zleg2 = mCurMotionRec.Zpos
        ElseIf yleg <= xleg AndAlso xleg <= zleg Then
            xleg1 = mCurMotionRec.Xold + yleg * xdir
            yleg1 = mCurMotionRec.Ypos
            zleg1 = mCurMotionRec.Zold + yleg * zdir
            xleg2 = mCurMotionRec.Xpos
            yleg2 = mCurMotionRec.Ypos
            zleg2 = mCurMotionRec.Zold + xleg * zdir
        End If
    End Sub


    Private Sub DrawMotionRecord()
        Dim xleg1, yleg1, zleg1, xleg2, yleg2, zleg2 As Single
        'Create a display list using any existing points
        Dim toolLayer As clsToolLayer = Nothing

        'if the z is filtered then do not draw and clear the points
        If mCurMotionRec.FilterZ Then
            mPoints.Clear()
            Return
        End If

        'Create a display list using any existing points
        If ToolLayers.TryGetValue(mCurMotionRec.Tool, toolLayer) Then
            'If we change the tool color we need to make sure we set the tool layer.
            If MotionColorByMotionType Then
                mCurMotionRec.DrawColor = toolLayer.Color
            End If
            If toolLayer.Hidden Then
                LineEnd4D(mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos)
                mPoints.Clear()
                Return
            End If
        End If


        If mCurMotionRec.Rotate Then
            FourthAxis = mCurMotionRec.NewRotaryPos
            ArcSegmentCount = CInt(Int((mCurMotionRec.Zpos / mLongside) * 90) * mArcQuality)
        End If

        Select Case mCurMotionRec.MotionType
            Case Motion.RAPID
                mCurMotionColor = MotionColor_Rapid
                If DrawRapidLines Or mGfxIndex = 0 Then
                    If mCurMotionRec.Rotate Then
                        DrawRotaryArc(mCurMotionRec.Xpos, mCurMotionRec.Xold, mCurMotionRec.Ypos, mCurMotionRec.Yold, mCurMotionRec.Zpos, mCurMotionRec.Zold, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                    Else
                        If mDrawDogLeg Then
                            CalculateDogLegMotion(xleg1, yleg1, zleg1, xleg2, yleg2, zleg2)
                            LineEnd4D(xleg1, yleg1, zleg1)
                            LineEnd4D(xleg2, yleg2, zleg2)
                        End If
                        LineEnd4D(mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos)
                    End If
                End If

                CreateDisplayListItem(DashStyle.Dash) 'Draw any existing lines
                'Draw a rapid blip if required
                If DrawRapidPoints Then
                    'Set the last point
                    LineEnd4D(mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos)
                    mPoints.Clear()
                    DrawBlip(mLastPos)
                    CreateDisplayListItem(DashStyle.Solid)
                End If

            Case Motion.HOLE_I, Motion.HOLE_R
                If DrawRapidLines Then
                    If mDrawDogLeg Then
                        CalculateDogLegMotion(xleg1, yleg1, zleg1, xleg2, yleg2, zleg2)
                    End If

                    'A rotary move is on the drill cycle line
                    If mCurMotionRec.Rotate Then
                        If mCurMotionRec.MotionType = Motion.HOLE_I Then 'Return to inital Z
                            DrawRotaryArc(mCurMotionRec.Xpos, mCurMotionRec.Xold, mCurMotionRec.Ypos, mCurMotionRec.Yold, mCurMotionRec.DrillClear, mCurMotionRec.DrillClear, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                        Else
                            DrawRotaryArc(mCurMotionRec.Xpos, mCurMotionRec.Xold, mCurMotionRec.Ypos, mCurMotionRec.Yold, mCurMotionRec.Rpoint, mCurMotionRec.Rpoint, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                        End If
                        LineEnd4D(mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Rpoint)

                    Else

                        'Dog-leg hole positioning
                        If mCurMotionRec.MotionType = Motion.HOLE_I Then 'Return to inital Z
                            'Dog-leg
                            Line3D(mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.Zold, mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.DrillClear)
                            If mDrawDogLeg Then
                                'Line3D(mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.DrillClear, xleg2, yleg2, mCurMotionRec.DrillClear)
                                'LineEnd4D(mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.DrillClear)
                                LineEnd4D(xleg2, yleg2, mCurMotionRec.DrillClear)
                            End If
                            LineEnd4D(mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Rpoint)
                        Else
                            Line3D(mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.Zold, mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.Rpoint)
                            If mDrawDogLeg Then
                                LineEnd4D(xleg2, yleg2, mCurMotionRec.Rpoint)
                            End If
                            LineEnd4D(mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Rpoint)
                        End If
                    End If
                End If

                CreateDisplayListItem(DashStyle.Dash) 'Draw any existing lines
                'Draw the hole line
                mCurMotionColor = MotionColor_Line
                Line3D(mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Rpoint, mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos)
                If DrawRapidPoints Then 'Draw a small circle
                    CreateDisplayListItem(DashStyle.Solid) 'Draw any existing lines
                    ArcSegmentCount = 8
                    PolyArc(mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos,
                                                mCurMotionRec.Xpos + mBlipSize,
                                                mCurMotionRec.Xpos + mBlipSize,
                                                mCurMotionRec.Ypos, mCurMotionRec.Ypos,
                                                mCurMotionRec.Zpos, mCurMotionRec.Zpos,
                                                mBlipSize, 0, ONE_RADIAN, -1, 0)
                End If

            Case Motion.LINE
                mCurMotionColor = MotionColor_Line
                If mCurMotionRec.Rotate Then
                    DrawRotaryArc(mCurMotionRec.Xpos, mCurMotionRec.Xold, mCurMotionRec.Ypos, mCurMotionRec.Yold, mCurMotionRec.Zpos, mCurMotionRec.Zold, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                Else
                    Line3D(mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.Zold, mCurMotionRec.Xpos, mCurMotionRec.Ypos, mCurMotionRec.Zpos)
                End If
            Case Motion.CCARC
                mCurMotionColor = MotionColor_ArcCCW
                ArcSegmentCount = CInt(Int((mCurMotionRec.Rad / mViewRect.Width) * 360) * mArcQuality)
                PolyArc(mCurMotionRec.Xcentr, mCurMotionRec.Ycentr, mCurMotionRec.Zcentr, mCurMotionRec.Xpos, mCurMotionRec.Xold, mCurMotionRec.Ypos, mCurMotionRec.Yold, mCurMotionRec.Zpos, mCurMotionRec.Zold, mCurMotionRec.Rad, mCurMotionRec.Sang, mCurMotionRec.Eang, 1, mCurMotionRec.ArcPlane)
            Case Motion.CWARC
                mCurMotionColor = MotionColor_ArcCW
                ArcSegmentCount = CInt(Int((mCurMotionRec.Rad / mViewRect.Width) * 360) * mArcQuality)
                PolyArc(mCurMotionRec.Xcentr, mCurMotionRec.Ycentr, mCurMotionRec.Zcentr, mCurMotionRec.Xpos, mCurMotionRec.Xold, mCurMotionRec.Ypos, mCurMotionRec.Yold, mCurMotionRec.Zpos, mCurMotionRec.Zold, mCurMotionRec.Rad, mCurMotionRec.Sang, mCurMotionRec.Eang, -1, mCurMotionRec.ArcPlane)
        End Select
        CreateDisplayListItem(DashStyle.Solid)
        'Debug.Print("mDisplayLists.Count " & mDisplayLists.Count.ToString)
    End Sub

    'Draw un-rotated rectangle as a rapid point indication.   
    Private Sub DrawBlip(ByVal p As PointF)
        mPoints.Clear()
        With p
            Line(.X - mBlipSize, .Y - mBlipSize, .X + mBlipSize, .Y - mBlipSize)
            LineEnd(.X + mBlipSize, .Y + mBlipSize)
            LineEnd(.X - mBlipSize, .Y + mBlipSize)
            LineEnd(.X - mBlipSize, .Y - mBlipSize)
            LineEnd(.X, .Y)
        End With
    End Sub

    Public Overloads Sub Redraw(ByVal allSiblings As Boolean)
        If allSiblings AndAlso MG_BasicViewer.mAll_Siblings.Count > 0 Then
            For Each sib As MG_BasicViewer In MyNeighborhood
                If sib.Visible Then
                    sib.CreateDisplayListsAndDraw()
                End If
            Next
        Else
            CreateDisplayListsAndDraw()
        End If
    End Sub

    Public Sub FindExtents()
        If Not Visible Then Return
        If MotionRecords.Count = 0 Then Return
        Dim sw As New Stopwatch
        sw.Start()
        mExtentX(0) = Single.MaxValue
        mExtentX(1) = Single.MinValue
        mExtentY(0) = Single.MaxValue
        mExtentY(1) = Single.MinValue

        Dim drawRapidPointsStatus As Boolean = DrawRapidPoints
        DrawRapidPoints = False 'Disable rapid points for speed
        CreateDisplayLists()
        CreateLimitsBox()
        DrawRapidPoints = drawRapidPointsStatus

        For Each l As clsDisplayList In mLimitsDisplayLists
            For Each p As PointF In l.Points
                mExtentX(0) = Math.Min(mExtentX(0), p.X)
                mExtentX(1) = Math.Max(mExtentX(1), p.X)
                mExtentY(0) = Math.Min(mExtentY(0), p.Y)
                mExtentY(1) = Math.Max(mExtentY(1), p.Y)
            Next
        Next

        If MotionRecords.Count > 0 Then
            For Each l As clsDisplayList In mDisplayLists
                For Each p As PointF In l.Points
                    mExtentX(0) = Math.Min(mExtentX(0), p.X)
                    mExtentX(1) = Math.Max(mExtentX(1), p.X)
                    mExtentY(0) = Math.Min(mExtentY(0), p.Y)
                    mExtentY(1) = Math.Max(mExtentY(1), p.Y)
                Next
            Next
        Else
            mExtentX(0) = -1.0F
            mExtentX(1) = 1.0F
            mExtentY(0) = -1.0F
            mExtentY(1) = 1.0F
        End If

        sw.Stop()

        DynamicViewManipulation = sw.ElapsedMilliseconds < 200000

        mExtentRectangle.X = mExtentX(0)
        mExtentRectangle.Width = mExtentX(1) - mExtentX(0)
        mExtentRectangle.Y = mExtentY(0)
        mExtentRectangle.Height = mExtentY(1) - mExtentY(0)
        mExtentRectangle.Inflate(mExtentRectangle.Width * 0.01F, mExtentRectangle.Height * 0.01F)

        If mExtentRectangle.Width > 0 AndAlso mExtentRectangle.Height > 0 Then
            mViewRect.Inflate(mExtentRectangle.Width * 0.01F, mViewRect.Height * 0.01F)
            mViewRect = mExtentRectangle
            AdjustAspect()
        End If
    End Sub

    Private Sub CreateDisplayLists()
        mDisplayLists.Clear()
        mPoints.Clear()
        If MotionRecords.Count = 0 Then
            Return
        End If

        If mRangeEnd > MotionRecords.Count - 1 Then
            mRangeEnd = MotionRecords.Count - 1
        End If
        Try
            mCurMotionRec = MotionRecords(mRangeStart)
            If mCurMotionRec.Visible Then
                Point3D(mCurMotionRec.Xold, mCurMotionRec.Yold, mCurMotionRec.Zold)
            End If
            For mGfxIndex = mRangeStart To mRangeEnd
                mCurMotionRec = MotionRecords(mGfxIndex)
                If mCurMotionRec.Visible Then
                    DrawMotionRecord() 'Draws geometry
                End If
            Next

        Catch ex As Exception
            If mCurMotionRec IsNot Nothing Then
                Throw New DisplayException(ex.Message, mCurMotionRec.Codestring)
            Else
                Throw New DisplayException(ex.Message, "CreateDisplayLists failed")
            End If
        End Try
    End Sub

    Private Sub DrawDisplayLists()
#If DEBUG Then
        mStopWatch = New Stopwatch
        mStopWatch.Start()
#End If
        CreateWcs()
        CreateLimitsBox()

        SetInViewStatus(mViewRect)
        mGfx.Clear(BackColor)
        DrawListsToGraphics(mGfx)
        mGfxBuff.Render()
        ViewManipMode = ViewManipMode
#If DEBUG Then
        mStopWatch.Stop()
        DrawTextOverlay(mStopWatch.Elapsed.ToString)
#End If
    End Sub

    Private Sub CreateDisplayListsAndDraw()
        If Not Visible Then Return
        mSelectionHitIndices.Clear()
        CreateDisplayLists()
        DrawDisplayLists()
    End Sub

    Private Sub CreateLimitsBox()
        mLimitsDisplayLists.Clear()
        mPoints.Clear()
        If Not DrawAxisLimits Then Return

        'X=0,1
        'Y=2,3
        'Z=4,5
        Line3D(Limits(0), Limits(3), Limits(5), Limits(1), Limits(3), Limits(5))
        LineEnd3D(Limits(1), Limits(2), Limits(5))
        LineEnd3D(Limits(0), Limits(2), Limits(5))
        LineEnd3D(Limits(0), Limits(3), Limits(5))

        LineEnd3D(Limits(0), Limits(3), Limits(4))
        LineEnd3D(Limits(0), Limits(2), Limits(4))
        LineEnd3D(Limits(0), Limits(2), Limits(5))
        CreateLimitsPath()

        Line3D(Limits(0), Limits(2), Limits(4), Limits(1), Limits(2), Limits(4))
        LineEnd3D(Limits(1), Limits(2), Limits(5))
        CreateLimitsPath()
        Line3D(Limits(0), Limits(3), Limits(4), Limits(1), Limits(3), Limits(4))
        LineEnd3D(Limits(1), Limits(3), Limits(5))
        CreateLimitsPath()
        Line3D(Limits(1), Limits(2), Limits(4), Limits(1), Limits(3), Limits(4))
        CreateLimitsPath()

    End Sub

    Private Sub CreateWcs()
        If Not Visible Then Return
        mWcsDisplayLists.Clear()
        mPoints.Clear()
        FourthAxis = 0


        If DrawAxisLines Then
            'Y axis line
            Line3D(0.0F, 0.0F, 0.0F, 0.0F, -1000, 0)
            CreateWcsPath(Color.Gray, DashStyle.Custom)
            Line3D(0.0F, 0.0F, 0.0F, 0.0F, 1000, 0)
            CreateWcsPath(Color.Gray, DashStyle.Custom)

            'X axis line
            Line3D(0.0F, 0.0F, 0.0F, 1000, 0.0F, 0)
            CreateWcsPath(Color.Gray, DashStyle.Custom)
            Line3D(0.0F, 0.0F, 0.0F, -1000, 0.0F, 0)
            CreateWcsPath(Color.Gray, DashStyle.Custom)

            'Z Axis line
            Line3D(0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 1000)
            CreateWcsPath(Color.Gray, DashStyle.Custom)
            Line3D(0.0F, 0.0F, 0.0F, 0.0F, 0.0F, -1000)
            CreateWcsPath(Color.Gray, DashStyle.Custom)
        End If

        If DrawAxisIndicator Then
            'Axis indicators
            'X indicator
            Line3D(0.0F, 0.0F, 0.0F, 1.0F, 0.0F, 0)
            Line3D(1.0F, 0.0F, 0.0F, 0.9F, 0.05F, 0)
            Line3D(1.0F, 0.0F, 0.0F, 0.9F, -0.05F, 0)
            CreateWcsPath(Color.DarkKhaki, DashStyle.Solid)
            'Draw the letter X
            Line3D(0.7F, 0.1F, 0.0F, 0.9F, 0.4F, 0)
            CreateWcsPath(Color.DarkKhaki, DashStyle.Solid)
            Line3D(0.9F, 0.1F, 0.0F, 0.7F, 0.4F, 0)
            CreateWcsPath(Color.DarkKhaki, DashStyle.Solid)

            'Y indicator
            Line3D(0.0F, 0.0F, 0, 0.0F, 1.0F, 0)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            Line3D(0.0F, 1.0F, 0.0F, -0.05F, 0.9F, 0)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            Line3D(0.0F, 1.0F, 0.0F, 0.05F, 0.9F, 0)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            'Draw the letter Y
            Line3D(-0.2F, 0.7F, 0.0F, -0.2F, 0.85F, 0)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            Line3D(-0.2F, 0.85F, 0.0F, -0.3F, 1.0F, 0)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            Line3D(-0.2F, 0.85F, 0.0F, -0.1F, 1.0F, 0)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)

            'Z indicator
            Line3D(0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 1)
            Line3D(0.0F, 0.0F, 1.0F, 0.1F, 0.0F, 0.8)
            CreateWcsPath(Color.DarkRed, DashStyle.Solid)

            PolyArc(0.0F, 0.0F, 0.0F, 0.1F, 0.1F, 0.0F, 0.0F, 0.8F, 0.8F, 0.1F, 0.0F, ONE_RADIAN, 1, Axis.Z)
            CreateWcsPath(Color.DarkRed, DashStyle.Solid)

            'Draw the letter Z
            Line3D(-0.2F, 0.0F, 0.7F, -0.4F, 0.0F, 0.7)
            Line3D(-0.2F, 0.0F, 0.95F, -0.4F, 0.0F, 0.95)
            Line3D(-0.2F, 0.0F, 0.95F, -0.4F, 0.0F, 0.7)
            CreateWcsPath(Color.DarkRed, DashStyle.Solid)
        End If
    End Sub

    'Gathers the tools and creates ToolLayers from current colors
    Public Sub GatherToolsFromMotionRecords()
        Dim lastTool As Single
        ToolLayers.Clear()
        For Each blk As clsMotionRecord In MotionRecords
            If lastTool <> blk.Tool Then
                lastTool = blk.Tool
                If Not ToolLayers.ContainsKey(blk.Tool) Then
                    Dim tl As clsToolLayer = New clsToolLayer(blk.Tool, blk.DrawColor)
                    ToolLayers.Add(blk.Tool, tl)
                    'Debug.Print(tl.ToString)
                End If
            End If
        Next
        For Each sib As MG_BasicViewer In MyNeighborhood
            If sib.Name <> Name Then
                sib.ToolLayers = ToolLayers
            End If
        Next
    End Sub

    'Sets the selection based on a range
    Public Sub SetSelectionHits(ByVal rangeLnStart As Integer, ByVal rangeLnEnd As Integer, ByVal pIndex As Integer)
        Dim maxHits As Integer = 0
        Dim hitIndex As Integer = 0
        mSelectionHits.Clear()
        mSelectionHitIndices.Clear()
        If MotionRecords.Count > 0 Then
            For Each l As clsDisplayList In mDisplayLists
                If l.InView Then
                    If maxHits >= mMaxSelectionHits Then Exit For
                    If MotionRecords(l.MotionIndex).Linenumber >= rangeLnStart _
                    AndAlso MotionRecords(l.MotionIndex).Linenumber <= rangeLnEnd _
                    AndAlso MotionRecords(l.MotionIndex).ProgIndex = pIndex Then
                        mSelectionHits.Add(MotionRecords(l.MotionIndex))
                        mSelectionHitIndices.Add(hitIndex)
                        maxHits += 1
                    End If
                End If
                hitIndex += 1
            Next
        End If

        If mSelectionHitIndices.Count > 0 Then
            DrawAllSelectionOverlays(mSelectionHitIndices, -1)
            mLastSelectedMotionRecord = mSelectionHits(0)
            UpdateElementDetails()
        End If

    End Sub

    'Returns the number of hits inside the referenced rectangle.
    Private Sub GetSelectionHits(ByVal rect As RectangleF)
        Dim maxHits As Integer = 0
        Dim hitIndex As Integer = 0
        Dim cadRect As New clsCadRect(rect.X, rect.Y, rect.Width, rect.Height)
        mSelectionHits.Clear()
        mSelectionHitIndices.Clear()
        If MotionRecords.Count > 0 Then
            For Each l As clsDisplayList In mDisplayLists
                If l.InView Then
                    'Iterate in sets of 2 
                    For r As Integer = 0 To l.Points.Length - 2
                        If maxHits >= mMaxSelectionHits Then Return
                        If cadRect.IntersectsLine(l.Points(r), l.Points(r + 1)) Then
                            If Not mSelectionHits.Contains(MotionRecords(l.MotionIndex)) Then
                                mSelectionHits.Add(MotionRecords(l.MotionIndex))
                                mSelectionHitIndices.Add(hitIndex)
                                maxHits += 1
                                Exit For
                            End If
                        End If
                    Next
                End If
                hitIndex += 1
            Next
        End If
    End Sub

    Private Function GetDisplayIndexFromMotionIndex(ByVal motIdx As Integer) As Integer
        Dim ret As Integer = 0
        For Each l As clsDisplayList In mDisplayLists
            If l.MotionIndex = motIdx Then
                Return ret
                ret += 1
            End If
        Next
        Return -1
    End Function

    Public Sub SelectLastElement()
        mSelectionHits.Clear()
        mSelectionHitIndices.Clear()
        If MotionRecords.Count > 0 Then
            mSelectionHits.Add(MotionRecords(RangeEnd))
            mSelectionHitIndices.Add(mDisplayLists.Count - 1)
        End If
    End Sub

    Public Sub ClickLastElement()
        If mSelectionHits.Count > 0 Then
            RaiseEvent OnSelection(mSelectionHits, 0)
        End If
    End Sub

    Public Sub SetToolColor(ByVal tool As Single, ByVal clr As Color)
        For Each mr As clsMotionRecord In MotionRecords
            If mr.Tool = tool Then
                mr.DrawColor = clr
            End If
        Next
    End Sub

    Private Sub SetAllInVeiw()
        For Each l As clsDisplayList In mDisplayLists
            l.InView = True
        Next
    End Sub


    Private Sub SetInViewStatus(ByVal rect As RectangleF)
        Dim cadRect As New clsCadRect(rect.X, rect.Y, rect.Width, rect.Height)
        For Each l As clsDisplayList In mDisplayLists
            'Iterate in sets of 2 
            For r As Integer = 0 To l.Points.Length - 2
                l.InView = False
                If cadRect.IntersectsLine(l.Points(r), l.Points(r + 1)) Then
                    l.InView = True
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub ClearDisplayList()
        mDisplayLists.Clear()
        mPoints.Clear()
    End Sub

    Private Sub CreateDisplayListItem(ByVal drawStyle As Drawing2D.DashStyle)
        If (mPoints.Count < 2) Then Return
        Dim p As New clsDisplayList

        With p
            If MotionColorByMotionType Then
                .Color = mCurMotionColor
            Else
                .Color = mCurMotionRec.DrawColor
            End If
            .DashStyle = drawStyle
            .MotionIndex = mGfxIndex
            .Points = mPoints.ToArray
        End With
        mDisplayLists.Add(p)
        mPoints.Clear()
    End Sub

    'Limits lines and indicator
    Private Sub CreateLimitsPath()
        Dim p As New clsDisplayList
        If (mPoints.Count < 2) Then Return
        With p
            .Color = LimitsColor
            .DashStyle = DashStyle.Solid '(mCurMotion = Motion.RAPID)
            .Points = mPoints.ToArray
        End With
        mLimitsDisplayLists.Add(p)
        mPoints.Clear()
    End Sub

    'Axis lines and indicator
    Private Sub CreateWcsPath(ByVal clr As Color, ByVal drawStyle As Drawing2D.DashStyle)
        Dim p As New clsDisplayList
        If (mPoints.Count < 2) Then Return
        With p
            .Color = clr
            .DashStyle = drawStyle '(mCurMotion = Motion.RAPID)
            .Points = mPoints.ToArray
        End With
        mWcsDisplayLists.Add(p)
        mPoints.Clear()
    End Sub

    Private Sub LineEnd(ByVal x2 As Single, ByVal y2 As Single)
        'Code was removed that checked for a line of zero length.
        'This creates a problem because it will create an uneven number of display list in each viewport.
        mPoints.Add(mLastPos)
        mPoints.Add(New PointF(x2, y2))
        mLastPos.X = x2
        mLastPos.Y = y2
    End Sub

    Private Sub Line(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single)
        mPoints.Add(New PointF(x1, y1))
        mPoints.Add(New PointF(x2, y2))
        mLastPos.X = x2
        mLastPos.Y = y2
    End Sub

#End Region

    Private Sub MG_BasicViewer_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Visible = False Then
            'Reclaim a little memory
            mDisplayLists.Clear()
        End If
    End Sub

    Private Sub SetViewManipMode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuZoom.Click, mnuSelect.Click, mnuRotate.Click, mnuPan.Click, mnuFit.Click, mnuFence.Click
        Dim tag As String = sender.GetType.GetProperty("Tag").GetValue(sender, Nothing).ToString
        Select Case tag
            Case "Fit"
                SetView(ManipMode.FIT, My.Computer.Keyboard.ShiftKeyDown)
            Case "Pan"
                SetView(MG_BasicViewer.ManipMode.PAN)
            Case "Fence"
                SetView(MG_BasicViewer.ManipMode.FENCE)
            Case "Zoom"
                SetView(MG_BasicViewer.ManipMode.ZOOM)
            Case "Rotate"
                SetView(MG_BasicViewer.ManipMode.ROTATE)
            Case "Select"
                SetView(MG_BasicViewer.ManipMode.SELECTION)
        End Select
    End Sub

    Public Sub SetView(ByVal cmd As MG_BasicViewer.ManipMode, Optional ByVal fitAll As Boolean = False)
        Select Case cmd
            Case ManipMode.FIT
                If fitAll Then
                    For Each Sibling As MG_BasicViewer In MyNeighborhood
                        Sibling.FindExtents()
                    Next
                    Redraw(True)
                Else
                    FindExtents()
                    Redraw(False)
                End If
                RaiseEvent OnSetViewMode(ViewManipMode)
            Case ManipMode.PAN
                ViewManipMode = MG_BasicViewer.ManipMode.PAN
                RaiseEvent OnSetViewMode(ViewManipMode)
            Case ManipMode.FENCE
                ViewManipMode = MG_BasicViewer.ManipMode.FENCE
                RaiseEvent OnSetViewMode(ViewManipMode)
            Case ManipMode.ZOOM
                ViewManipMode = MG_BasicViewer.ManipMode.ZOOM
                RaiseEvent OnSetViewMode(ViewManipMode)
            Case ManipMode.ROTATE
                ViewManipMode = MG_BasicViewer.ManipMode.ROTATE
                RaiseEvent OnSetViewMode(ViewManipMode)
            Case ManipMode.SELECTION
                ViewManipMode = MG_BasicViewer.ManipMode.SELECTION
                RaiseEvent OnSetViewMode(ViewManipMode)
        End Select
    End Sub

    Private Sub NamedView(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTop.Click, mnuRight.Click, mnuIsometric.Click, mnuFront.Click
        Select Case DirectCast(sender, System.Windows.Forms.ToolStripMenuItem).Tag.ToString
            Case "Top"
                Pitch = 0
                Roll = 0
                Yaw = 0
            Case "Front"
                Pitch = 270
                Roll = 0
                Yaw = 360
            Case "Right"
                Pitch = 270
                Roll = 0
                Yaw = 270
            Case "ISO"
                Pitch = 315
                Roll = 0
                Yaw = 315
        End Select
        FindExtents()
        Redraw(False)
    End Sub

    Private Sub timerQuickPick_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timerQuickPick.Tick
        Static Xold As Single
        Static Yold As Single

        If ViewManipMode <> ManipMode.SELECTION Then
            Exit Sub
        End If
        Dim notMoving As Boolean = ((Xold = mCurrentCursorPos.X) AndAlso (Yold = mCurrentCursorPos.Y))

        If notMoving AndAlso mSelectionHits.Count > 1 Then
            Cursor = mSelectEtcCursor
            'Debug.Print("Quick")
        Else
            Cursor = mSelectCursor
            'Debug.Print("Normal")
        End If

        Xold = mCurrentCursorPos.X
        Yold = mCurrentCursorPos.Y
    End Sub

    Private Sub ShowQuickPick()
        timerQuickPick.Enabled = False
        Cursor = mSelectCursor
        mFrmQuickPick = New frmQuickPick
        For Each hit As clsMotionRecord In mSelectionHits
            mFrmQuickPick.lstQuickPick.Items.Add(hit.Codestring)
        Next
        mFrmQuickPick.Location = Windows.Forms.Cursor.Position
        mFrmQuickPick.TopMost = True
        mFrmQuickPick.ShowDialog()
        mFrmQuickPick.Dispose()
        timerQuickPick.Enabled = True
    End Sub


    Private Sub mFrmQuickPick_OnSingleSelect(ByVal selIdx As Integer) Handles mFrmQuickPick.OnSingleSelect

        'If Me.mSelectionHitIndices.Count > 0 Then
        DrawAllSelectionOverlays(mSelectionHitIndices, selIdx)
        'End If

        'DrawSelectionOverlay(Me.mSelectionHitIndices, selIdx)
        'For Each sib As MG_BasicViewer In MySiblings
        '    If Not ReferenceEquals(sib, Me) Then
        '        sib.DrawSelectionOverlay(Me.mSelectionHitIndices, selIdx)
        '    End If
        'Next
        ''Should behave as if the user clicked a single elementmSelectionHitIndices
        'DrawSelectionOverlay(Me.mSelectionHitIndices, selIdx)
        RaiseEvent OnSelection(mSelectionHits, selIdx)
    End Sub

    'Public Function HitIndexToMotionBlock(ByVal i As Integer) As clsMotionRecord
    '    Return MotionBlocks(Me.mDisplayLists(mSelectionHitIndices(i)).MotionIndex)
    'End Function

    Public Sub InitSiblingMotionBlocks(ByVal mb As List(Of clsMotionRecord))
        For Each Sibling As MG_BasicViewer In MyNeighborhood
            Sibling.mMotionRecords = mb
        Next
    End Sub

    Private Sub rmbView_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rmbView.Opening
        mRmbMenuOpen = True
    End Sub

    Private Sub rmbView_Closed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles rmbView.Closed
        mRmbMenuOpen = False
    End Sub

    Private mLastSelectedMotionRecord As New clsMotionRecord
    Private Shared WithEvents mFrmGraphicsDetails As frmGraphicsDetails
    Public Function ShowElementDetails() As Boolean
        Dim totalCutTime As Double = 0
        Dim totalRapidTime As Double = 0
        If mFrmGraphicsDetails Is Nothing Then
            CalculateTime(totalCutTime, totalRapidTime)
            mFrmGraphicsDetails = New frmGraphicsDetails(totalCutTime, totalRapidTime)
            mFrmGraphicsDetails.SetGraphData(mMotionRecords, totalCutTime + totalRapidTime)
            mFrmGraphicsDetails.Show(Me)
            ParentForm.Focus()
            UpdateElementDetails()

            If zeroFeedDetected Then
                MsgBox("A feedrate of zero was detected and will invalidate time calculations.", MsgBoxStyle.Information, "Feed Alert")
            End If

            RaiseEvent OnElementDetailsOpened()
            Return True
        Else
            mFrmGraphicsDetails.Close()
            Return False
        End If
    End Function

    Public Sub CloseGraphicsDetails()
        If mFrmGraphicsDetails IsNot Nothing Then
            mFrmGraphicsDetails.Close()
        End If
    End Sub

    Public Sub UpdateElementDetails()
        Dim totalCutTime, totalRapidTime As Double
        If mFrmGraphicsDetails IsNot Nothing Then
            CalculateTime(totalCutTime, totalRapidTime)
            mFrmGraphicsDetails.SetDetails(mLastSelectedMotionRecord)
            mFrmGraphicsDetails.SetGraphData(mMotionRecords, totalCutTime + totalRapidTime)
        End If
    End Sub

    Private Shared Sub mGraphicsDetails_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles mFrmGraphicsDetails.FormClosed
        mFrmGraphicsDetails = Nothing
        RaiseEvent OnElementDetailsClose()
    End Sub

    Private Sub MG_BasicViewer_TouchDoubleDoubleTap(sender As Object, e As WMTouchEventArgs) Handles Me.TouchDoubleDoubleTap
        FindExtents()
        Redraw(False)
    End Sub

    Private Sub MG_BasicViewer_TouchDoubleTap(sender As Object, e As WMTouchEventArgs) Handles Me.TouchDoubleTap
        If e.IsPrimaryContact Then '
            If ViewManipMode = ManipMode.PAN Then
                SetView(ManipMode.SELECTION)
            Else
                SetView(ManipMode.PAN)
            End If
        End If
    End Sub

    Dim pinchDist As Double = 0
    Private Sub MG_BasicViewer_TouchPinching(ByVal sender As Object, ByVal e As WMDoubleTouchEventArgs) Handles Me.TouchPinching
        Dim midPt As New Point((e.LocationsX(0) + e.LocationsX(1)) \ 2, (e.LocationsY(0) + e.LocationsY(1)) \ 2)
        mCurrentCursorPos = midPt
        If pinchDist <> 0 Then
            Dim factor As Double = Math.Round((pinchDist / e.Distance), 2)
            If factor <> 0 Then
                Dim curManipMode As ManipMode = ViewManipMode
                ViewManipMode = ManipMode.NONE
                ZoomSceneAtMouse(CSng(factor))
                CreateDisplayListsAndDraw()
                ViewManipMode = curManipMode
            End If

        End If
        pinchDist = e.Distance
    End Sub

    Private Sub MG_BasicViewer_Touchdown(ByVal sender As Object, ByVal e As WMTouchEventArgs) Handles Me.Touchdown
        ContextMenuStrip = Nothing
        pinchDist = 0
    End Sub

    Private Sub MG_BasicViewer_TouchHold(sender As Object, e As WMTouchEventArgs) Handles Me.TouchHold
        TabletMode = True
        ContextMenuStrip = rmbView
    End Sub


    Private Sub MG_BasicViewer_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' GetTouchInputInfo needs to be
        ' passed the size of the structure it will be filling.
        ' We get the size upfront so it can be used later.
        touchInputSize = Marshal.SizeOf(New TOUCHINPUT())
        Try
            ' Registering the window for multi-touch, using the default settings.
            ' p/invoking into user32.dll
            If Not RegisterTouchWindow(Handle, 0) Then
                Debug.Print("ERROR: Could not register window for multi-touch")
            End If

        Catch exception As Exception
            Debug.Print("ERROR: RegisterTouchWindow API not available")
            Debug.Print(exception.ToString())
        End Try
    End Sub


End Class
