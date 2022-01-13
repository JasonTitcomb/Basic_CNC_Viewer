''' <remarks>
''' Jason Titcomb
''' www.CncEdit.com
''' https://github.com/JasonTitcomb/Basic_CNC_Viewer/blob/master/LICENSE.md
''' </remarks>

Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports Abacus.SinglePrecision
Imports System.Collections.Generic
Imports System.Linq

Public Enum MachineType
    LATHEDIA = 0
    LATHERAD = 1
    MILL = 2
End Enum

Public Enum MachineUnits
    ENGLISH
    METRIC
End Enum

Public Enum ArcAxis
    Z = 0
    Y = 1
    X = 2
End Enum

Public Enum Rot
    A = 0
    B = 1
    C = 2
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

Public Class MG_BasicViewer
    Implements IComponent
#Region "ConstructorDestructor"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Cursor = Me.mSelectCursor
        ' Add any initialization after the InitializeComponent() call.
        mAll_Siblings.Add(Me)

        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, False)
        ' Retrieves the BufferedGraphicsContext for the current application domain.
        mContext = BufferedGraphicsManager.Current
        isInitialized = False
        'Try
        '    If Dx3 Is Nothing Then
        '        Dx3 = New _3DconnexionDriver._3DconnexionDevice(My.Application.Info.ProductName)
        '        Dx3.InitDevice(Me.Handle)
        '        If Dx3.IsAvailable Then
        '            'mLog.LogAlert("3DconnexionDriver", Dx3.DeviceName)
        '        End If

        '    End If
        'Catch ex As Exception
        '    'mLog.LogAlert("3DconnexionDriver", ex.Message)
        'End Try


    End Sub


    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing Then

                mAll_Siblings.Remove(Me)
                DrawGraphicsOverlaysAllViews = DirectCast([Delegate].Remove(DrawGraphicsOverlaysAllViews, DrawGraphicsOverlaysAllViews), DrawAllSelectionOverlayDelegate)

                If mMtxText IsNot Nothing Then
                    mMtxText.Dispose()
                    mMtxText = Nothing
                End If

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
            GC.SuppressFinalize(Me)
        End Try
    End Sub

#End Region
    'public members
    Public ToolLayers As New Dictionary(Of Single, clsToolLayer)
    Private Shared mAll_Siblings As New List(Of MG_BasicViewer)
    Public Enum ManipMode
        NONE
        FENCE
        PAN
        ZOOM
        ROTATE
        SELECTION
        FIT
        SETROTATE
        MEASURE
    End Enum
    Public Event AfterViewManip(mode As ManipMode, viewRect As RectangleF)
    Public Event OnStatus(msg As String, index As Integer, max As Integer)
    Public Event OnSelection(hits As List(Of clsMotionRecord), i As Integer)
    Public Event OnHighlight(hits As List(Of clsMotionRecord), i As Integer)
    Public Event MouseLocation(x As Single, y As Single, z As Single)
    Public Event OnSetViewMode(mode As ManipMode)
    Public Event OnSlowDrawingAlert(vewCtrl As MG_BasicViewer)
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
    Public Event OnViewOrientationChanged(pitch As Single, roll As Single, yaw As Single)
    Public Shared Expired As Boolean = True
    Private Const NUMBERFORMAT As String = "##0.0###"
    'private members
    Private Const ONE_RADIAN As Single = Math.PI * 2
    Private Const QUARTER_RADIAN As Single = Math.PI / 2
    Private Const PI_S As Single = Math.PI
    'Private Const RAPIDRATE As Single = 100.0
    Private Const FAST_QUALITY As Single = 0.25
    Private Const VARIABLE_QUALITY As Single = 1.0
    Private Const FIXED_FINE_QUALITY As Single = 100.0
    Private Const ROTATE_BORDER As Single = 25
    Private mPixelF As Single
    Private mBlipSize As Single
    Private mEndPointSize As Single
    Private mBackStep As Boolean
    Private mLongside As Single = 2.0
    Private mLastPos As PointF
    Private mCurMotionRec As clsMotionRecord
    Private mMotRecIdx As Integer
    Private mCurMotionColor As Color = mRapidColor

    Private mExtentX(1) As Single
    Private mExtentY(1) As Single

    Private mExtentRectangle As RectangleF

    Private mPoints2D As New List(Of PointF)
    Private mDisplayLists2DSelectionIndices As New List(Of Integer)
    Private mSelectionHits As New List(Of clsMotionRecord)
    Private mDisplayLists2D As New List(Of clsDisplayList2D)
    Private mLimitsDisplayLists As New List(Of clsDisplayList2D)
    Private mGridDisplayLists As New List(Of clsDisplayList2D)

    Private mWcsDisplayLists As New List(Of clsDisplayList2D)

    Private mUserDisplayLists As New List(Of clsDisplayList2D)
    Private mUserMotionRecords As New List(Of clsUserRecord)

    Private mToolDiaDisplayLists As New List(Of clsDisplayList2D)
    Private mToolCompDisplayLists As New List(Of clsDisplayList2D)
    Private mMouseDownAndMoving As Boolean
    Private mMouseDownPt As Point
    Private mLastPt As Point

    Private mViewMatrix As Matrix44 = Matrix44.Identity
    Private mRotaryMatrix As Matrix44 = Matrix44.Identity
    Private mRotateAbout3D As Vector3
    Private mSelKeypoint3D As New Vector3
    Private mRotateAbout2DIndicator As PointF

    Private mMtxDraw As New Matrix
    Private mMtxText As New Matrix
    Private mMtxFeedback As New Matrix
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
    'Private mSelBuff As BufferedGraphics
    Private mGfx As Graphics
    Private WithEvents mFrmQuickPick As frmQuickPick
    Private mViewModeWhenMouseWasDown As ManipMode
    Private mInverseColor As Color
    'Define the delegate types
    Delegate Sub DrawAllSelectionOverlayDelegate(Indices As List(Of Integer), selIndex As Integer)
    Protected Friend DrawGraphicsOverlaysAllViews As DrawAllSelectionOverlayDelegate = AddressOf DrawGraphicsOverlay
    Delegate Sub DrawAllDelegate()
    Private Shared mCancelSlowDisplayList As Boolean
    Private Shared mAllowSlowDisplayList As Boolean
    Private mStopWatch As Stopwatch
    Private mSelectCursor As Cursor
    Private mSelectEtcCursor As Cursor
    Private mSetRotateCursor As Cursor
    Private mMeasureCursor As Cursor
    Private mMeasureKeypointCursor As Cursor
    'Private mSavingDXF As Boolean = False
    Private mDxfOutFile As String
    Private xOld, yOld, zOld As Single
    Private mSectionsDXF As Dictionary(Of String, String)
    Private mTouchPointCount As Integer = 0
    Private mDrawLinesMilliseconds As Long
    Private mFeedrateFont As New Font(OverlayFont, FontStyle.Regular)
    Private WithEvents mArcBall As New clsArcBall
    Private namedViews As New Dictionary(Of String, SavedView)
    Private mSavedView As SavedView
    Private viewHistory As New List(Of SavedView)
    Private viewHistoryIndex As Integer

    Private Shared mMeasurement As New clsMeasurement
    Private Shared mExtentCenter As Vector3
    Private Shared mDisplayLists3D As New clsDisplayLists3D
    Private Shared mRotaryVector As Vector3

    Public Overrides Property Cursor As Cursor = Cursors.Arrow

    Private Delegate Sub delLine3D(Xs As Single, Ys As Single, Zs As Single, Xe As Single, Ye As Single, Ze As Single)
    Private Delegate Sub delLineEnd3D(Xe As Single, Ye As Single, Ze As Single)
    Private Delegate Sub delDrawPolyArc(Xctr As Single, Yctr As Single, Zctr As Single,
                            Xe As Single, Xs As Single,
                            Ye As Single, Ys As Single,
                            Ze As Single, Zs As Single,
                            r As Single,
                            Startang As Single,
                            Endang As Single,
                            ArcDir As Integer,
                            Wplane As Integer)
    Private Line3D As delLine3D
    Private LineEnd3D As delLineEnd3D
    Private DrawPolyArc As delDrawPolyArc
    Private isInitialized As Boolean


    Private Enum enDrawMethod
        INIT
        DRAW
        DXF
    End Enum
    Private drawMethod As enDrawMethod
    Private Sub SetDrawDelegates(dm As enDrawMethod)
        drawMethod = dm
        Select Case drawMethod
            Case enDrawMethod.INIT
                Line3D = AddressOf Line3dInit
                LineEnd3D = AddressOf LineEnd3dInit
                DrawPolyArc = AddressOf PolyArcDraw
            Case enDrawMethod.DRAW
                Line3D = AddressOf Line3dDraw
                LineEnd3D = AddressOf LineEnd3dDraw
                DrawPolyArc = AddressOf PolyArcDraw
            Case enDrawMethod.DXF
                Line3D = AddressOf Line3dDxf
                LineEnd3D = AddressOf LineEnd3dDxf
                DrawPolyArc = AddressOf PolyArcDXF
        End Select
    End Sub

    Private Sub Line3dDxf(Xs As Single, Ys As Single, Zs As Single, Xe As Single, Ye As Single, Ze As Single)
        Dim sp = Vector3.Transform(New Vector3(Xs, Ys, Zs), mViewMatrix)
        Dim ep = Vector3.Transform(New Vector3(Xe, Ye, Ze), mViewMatrix)
        'We need to add 3d points to the displaylist so we can use inverse matrix to get the actual position
        'Line2D(sp.X, sp.Y, ep.X, ep.Y)
        Output_DXF_Section("@LINE", xOld, yOld, zOld, ep.X, ep.Y, ep.Z)
        xOld = ep.X
        yOld = ep.Y
        zOld = ep.Z
    End Sub

    Private Sub Line3dInit(Xs As Single, Ys As Single, Zs As Single, Xe As Single, Ye As Single, Ze As Single)
        Xs *= mMasterGfxAdjustScale
        Ys *= mMasterGfxAdjustScale
        Zs *= mMasterGfxAdjustScale
        Xe *= mMasterGfxAdjustScale
        Ye *= mMasterGfxAdjustScale
        Ze *= mMasterGfxAdjustScale
        mDisplayLists3D.AddVector(Vector3.Transform(New Vector3(Xs, Ys, Zs), mRotaryMatrix))
        mDisplayLists3D.AddVector(Vector3.Transform(New Vector3(Xe, Ye, Ze), mRotaryMatrix))
    End Sub

    Private Sub Line3dDraw(Xs As Single, Ys As Single, Zs As Single, Xe As Single, Ye As Single, Ze As Single)
        Xs *= mMasterGfxAdjustScale
        Ys *= mMasterGfxAdjustScale
        Zs *= mMasterGfxAdjustScale
        Xe *= mMasterGfxAdjustScale
        Ye *= mMasterGfxAdjustScale
        Ze *= mMasterGfxAdjustScale

        Dim sp = Vector3.Transform(New Vector3(Xs, Ys, Zs), mViewMatrix)
        Dim ep = Vector3.Transform(New Vector3(Xe, Ye, Ze), mViewMatrix)
        'We need to add 3d points to the displaylist so we can use inverse matrix to get the actual position
        Line2D(sp.X, sp.Y, ep.X, ep.Y)
        xOld = ep.X
        yOld = ep.Y
        zOld = ep.Z
    End Sub

    Private Sub LineEnd3dInit(Xe As Single, Ye As Single, Ze As Single)
        Xe *= mMasterGfxAdjustScale
        Ye *= mMasterGfxAdjustScale
        Ze *= mMasterGfxAdjustScale
        mDisplayLists3D.AddVector(Vector3.Transform(New Vector3(Xe, Ye, Ze), mRotaryMatrix))
    End Sub

    Private Sub LineEnd3dDraw(Xe As Single, Ye As Single, Ze As Single)
        Xe *= mMasterGfxAdjustScale
        Ye *= mMasterGfxAdjustScale
        Ze *= mMasterGfxAdjustScale
        Dim ep = Vector3.Transform(New Vector3(Xe, Ye, Ze), mViewMatrix)
        AddLineEndpoint(ep.X, ep.Y)
        xOld = ep.X
        yOld = ep.Y
        zOld = ep.Z
    End Sub
    Private Sub Point3dDraw(Xe As Single, Ye As Single, Ze As Single)
        Xe *= mMasterGfxAdjustScale
        Ye *= mMasterGfxAdjustScale
        Ze *= mMasterGfxAdjustScale
        Dim ep = Vector3.Transform(New Vector3(Xe, Ye, Ze), mViewMatrix)
        mPoints2D.Add(New PointF(ep.X, ep.Y))
    End Sub
    Private Sub LineEnd3dDxf(Xe As Single, Ye As Single, Ze As Single)
        Dim ep = Vector3.Transform(New Vector3(Xe, Ye, Ze), mViewMatrix)
        Output_DXF_Section("@LINE", xOld, yOld, zOld, ep.X, ep.Y, ep.Z)
        xOld = ep.X
        yOld = ep.Y
        zOld = ep.Z
    End Sub
    Public Function HasMouse() As Boolean
        Return ClientRectangle.Contains(PointToClient(Cursor.Position))
    End Function

    Public ReadOnly Property View() As SavedView
        Get
            Return mSavedView
        End Get
    End Property
    Public Sub SetMaxAxis(m As Double)
        If m > 5000 Then
            mMasterGfxAdjustScale = 1
        End If
    End Sub
    Public Sub SetView(v As SavedView)
        mSavedView = v
    End Sub
    Public Sub CaptureView()
        If Me.Visible Then
            Dim newView = mArcBall.ActiveMatrix
            mSavedView = New SavedView(newView, mViewRect, mRotateAbout3D)
        End If
    End Sub
    Public Sub RestoreView()
        If Me.Visible Then
            mArcBall.ActiveMatrix = mSavedView.m
            mViewRect = mSavedView.rect
            mRotateAbout3D = mSavedView.rotatePoint
            AdjustAspect()
            SetViewMatrix3D()
        End If
    End Sub

    Public Sub SaveView(Optional name As String = "")
        Dim newView = mArcBall.ActiveMatrix
        viewHistory.Add(New SavedView(newView, mViewRect, mRotateAbout3D))
        viewHistoryIndex = viewHistory.Count - 1
        If Not String.IsNullOrEmpty(name) Then
            namedViews.Add(name, New SavedView(newView, mViewRect, mRotateAbout3D))
        End If
    End Sub

    Public Sub SetPreviousView()
        If viewHistoryIndex > 0 Then
            viewHistoryIndex -= 1
            mArcBall.ActiveMatrix = viewHistory.Item(viewHistoryIndex).m
            mViewRect = viewHistory.Item(viewHistoryIndex).rect
            mRotateAbout3D = viewHistory.Item(viewHistoryIndex).rotatePoint
            AdjustAspect()
            SetViewMatrix3D()
        End If
    End Sub

    Public Sub SetNextView()
        If viewHistoryIndex < viewHistory.Count - 1 Then
            viewHistoryIndex += 1
            mArcBall.ActiveMatrix = viewHistory.Item(viewHistoryIndex).m
            mViewRect = viewHistory.Item(viewHistoryIndex).rect
            mRotateAbout3D = viewHistory.Item(viewHistoryIndex).rotatePoint

            AdjustAspect()
            SetViewMatrix3D()
        End If
    End Sub

    Public Sub ResetViewHistory()
        For Each s As MG_BasicViewer In mAll_Siblings
            s.viewHistory.Clear()
            s.viewHistoryIndex = 0
        Next
    End Sub

    Public Sub InitMyNeighbors()
        mMyNeighborhood.Clear()
        DrawGraphicsOverlaysAllViews = AddressOf DrawGraphicsOverlay

        For Each s As MG_BasicViewer In mAll_Siblings
            If s.Parent Is Me.Parent Then
                mMyNeighborhood.Add(s)
                If s IsNot Me Then 'We already added Me above so don't do it again.
                    Me.DrawGraphicsOverlaysAllViews = DirectCast([Delegate].Combine(DrawGraphicsOverlaysAllViews, New DrawAllSelectionOverlayDelegate(AddressOf s.DrawGraphicsOverlay)), DrawAllSelectionOverlayDelegate)
                End If
            End If
        Next

        For Each s As MG_BasicViewer In mAll_Siblings
            If s.Parent Is Me.Parent Then
                s.DrawGraphicsOverlaysAllViews = Me.DrawGraphicsOverlaysAllViews
                s.mMyNeighborhood = Me.mMyNeighborhood
            End If
        Next

    End Sub
    Private Sub DrawAllKeyPointsOverlay()
        For Each s As MG_BasicViewer In mAll_Siblings
            If s.Visible Then s.DrawKeyPointsOverlay()
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

    Private Shared mMasterGfxAdjustScale As Integer = 10
    Public Property MasterGfxAdjustScale As Integer
        Get
            Return mMasterGfxAdjustScale
        End Get
        Set(value As Integer)
            mMasterGfxAdjustScale = value
        End Set
    End Property

    Private Shared mMachineUnits As MachineUnits = MachineUnits.ENGLISH
    <Description("Set or get the display uvalue units"), Category("Custom")>
    Public Property MachineUnits() As MachineUnits
        Get
            Return mMachineUnits
        End Get
        Set(value As MachineUnits)
            mMachineUnits = value
        End Set
    End Property

    Private Shared mPerformLineFixup As Boolean = True
    <Description("Corrects graphics drawing gaps when lines are off screen"),
    Category("Custom"),
    DefaultValue(True)>
    Public Property PerformLineFixup() As Boolean
        Get
            Return mPerformLineFixup
        End Get
        Set(value As Boolean)
            mPerformLineFixup = value
        End Set
    End Property

    Private Shared mDrawOverlayText As Boolean = True
    <Description("Draw text overlay"),
    Category("Custom"),
    DefaultValue(True)>
    Public Property DrawOverlayText() As Boolean
        Get
            Return mDrawOverlayText
        End Get
        Set(value As Boolean)
            mDrawOverlayText = value
        End Set
    End Property

    Private mIsShared As Boolean = False
    <Description("Set or get whether or not the control uses shared drawing"),
    Category("Custom"),
    DefaultValue(False)>
    Public Property IsShared() As Boolean
        Get
            Return mIsShared
        End Get
        Set(value As Boolean)
            mIsShared = value
        End Set
    End Property

    Private mAllMotionRecords As New List(Of clsMotionRecord)
    <Browsable(False)>
    Public ReadOnly Property AllMotionRecords() As List(Of clsMotionRecord)
        Get
            Return mAllMotionRecords
        End Get
    End Property
    Public Sub SetMotionBlocks(mb As List(Of clsMotionRecord))
        mAllMotionRecords = mb
    End Sub

    Private Shared mMaxSelectionHits As Integer = 16
    <Description("Set or get the max number of elements that will be selected"),
    Category("Custom"),
    DefaultValue(False)>
    Public Property MaxSelectionHits() As Integer
        Get
            If ViewManipMode = ManipMode.MEASURE Or ViewManipMode = ManipMode.SETROTATE Then
                Return 1
            Else
                Return mMaxSelectionHits
            End If
        End Get
        Set(value As Integer)
            mMaxSelectionHits = value
        End Set
    End Property


    Private Shared mDrawFeedRates As Boolean
    <Description("Determines if the feedrates are drawn."),
    Category("Custom"),
    DefaultValue(False)>
    Public Property DrawFeedRates() As Boolean
        Get
            Return mDrawFeedRates
        End Get
        Set(value As Boolean)
            mDrawFeedRates = value
        End Set
    End Property

    Private Shared mDrawCutterComp As Boolean
    <Description("Determines if the cutter comp markers L R is drawn."),
    Category("Custom"),
    DefaultValue(False)>
    Public Property DrawCutterComp() As Boolean
        Get
            Return mDrawCutterComp
        End Get
        Set(value As Boolean)
            mDrawCutterComp = value
        End Set
    End Property

    Private Shared mDrawIncAbs As Boolean
    <Description("Determines if the incrementak or absolute markers L R are drawn."),
    Category("Custom"),
    DefaultValue(False)>
    Public Property DrawIncAbs() As Boolean
        Get
            Return mDrawIncAbs
        End Get
        Set(value As Boolean)
            mDrawIncAbs = value
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
        Set(value As Boolean)
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
        Set(value As Boolean)
            mColorByMotionType = value
        End Set
    End Property

    Private Shared mColorMotionByDefault As Boolean = False
    <Description("Use default color instead of tool colors."),
    Category("Custom"),
    DefaultValue(False)>
    Public Property DrawMotionWithDefaultColor() As Boolean
        Get
            Return mColorMotionByDefault
        End Get
        Set(value As Boolean)
            mColorMotionByDefault = value
        End Set
    End Property

    Private mMotionColorDefault As Color = Color.Blue
    <Description("default color."), Category("Custom")>
    Public Property MotionColor_Default() As Color
        Get
            Return mMotionColorDefault
        End Get
        Set(value As Color)
            mMotionColorDefault = value
        End Set
    End Property

    Private Shared mRapidColor As Color = Color.OrangeRed
    <Description("Rapid (G00) motion color."), Category("Custom")>
    Public Property MotionColor_Rapid() As Color
        Get
            Return mRapidColor
        End Get
        Set(value As Color)
            mRapidColor = value
        End Set
    End Property

    Private Shared mLinearColor As Color = Color.DodgerBlue
    <Description("Linear (G01) motion color."), Category("Custom")>
    Public Property MotionColor_Line() As Color
        Get
            Return mLinearColor
        End Get
        Set(value As Color)
            mLinearColor = value
        End Set
    End Property

    Private Shared mArcCWColor As Color = Color.DarkSeaGreen
    <Description("CW Arc motion color."), Category("Custom")>
    Public Property MotionColor_ArcCW() As Color
        Get
            Return mArcCWColor
        End Get
        Set(value As Color)
            mArcCWColor = value
        End Set
    End Property

    Private Shared mArcCCWColor As Color = Color.DarkTurquoise
    <Description("CCW Arc motion color."), Category("Custom")>
    Public Property MotionColor_ArcCCW() As Color
        Get
            Return mArcCCWColor
        End Get
        Set(value As Color)
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
        Set(value As Boolean)
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
        Set(value As Boolean)
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
        Set(value As Boolean)
            mReverseMouseWheel = value
        End Set
    End Property

    Private Shared mMB2Pan As Boolean = False
    <Description("MB2 Pan"),
    Category("Custom"),
    DefaultValue(False)>
    Public Property MB2Pan() As Boolean
        Get
            Return mMB2Pan
        End Get
        Set(value As Boolean)
            mMB2Pan = value
        End Set
    End Property

    Private Shared mMouseWheelZoomFactor As Single = 1.0
    <Description("Additional factor applied to mouse wheel zoom"),
    Category("Custom"),
    DefaultValue(1.0)>
    Public Property MouseWheelZoomFctor() As Single
        Get
            Return mMouseWheelZoomFactor
        End Get
        Set(value As Single)
            If value = 0 Then value = 1
            mMouseWheelZoomFactor = value
        End Set
    End Property

    Private Shared mOverlayFont As Font = New Font(FontFamily.GenericMonospace, 10)
    <Description("The font used for the text overlay."),
    Category("Custom")>
    Public Shared Property OverlayFont() As Font
        Get
            Return mOverlayFont
        End Get
        Set(value As Font)
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
        Set(value As Boolean)
            mDynamicViewManipulation = value
        End Set
    End Property

    Private Shared mViewManipMode As ManipMode = ManipMode.NONE
    <Description("Sets or gets the view manipulation mode"),
    Category("Custom"),
    DefaultValue(ManipMode.NONE), Browsable(False)>
    Public Property ViewManipMode() As ManipMode
        Get
            Return mViewManipMode
        End Get
        Set(value As ManipMode)
            Try
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
                        mMeasurement.Reset()
                    Case ManipMode.ZOOM
                        Cursor = Cursors.SizeNS
                    Case ManipMode.SETROTATE
                        Cursor = mSetRotateCursor
                    Case ManipMode.MEASURE
                        Cursor = mMeasureCursor
                End Select

                For Each Sibling As MG_BasicViewer In MyNeighborhood
                    If Sibling.Name <> Me.Name Then
                        Sibling.Cursor = Me.Cursor
                    End If
                Next

            Catch ex As Exception
                'TODO remove this if it does not help
            End Try
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
        Set(value As Single)
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
        Set(value As Boolean)
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
        Set(value As Boolean)
            mDrawAxisIndicator = value
        End Set
    End Property

    Private Shared mDrawEndPoints As Boolean = False
    <Description("Draw a point at the end of each element"),
    Category("Custom"),
    DefaultValue(False)>
    Public Property DrawEndPoints() As Boolean
        Get
            Return mDrawEndPoints
        End Get
        Set(value As Boolean)
            mDrawEndPoints = value
        End Set
    End Property

    Private Shared mDrawDirectionFlags As Boolean = False
    <Description("Draw a direction flag at the mid point of each element"),
    Category("Custom"),
    DefaultValue(False)>
    Public Property DrawDirectionFlags() As Boolean
        Get
            Return mDrawDirectionFlags
        End Get
        Set(value As Boolean)
            mDrawDirectionFlags = value
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
        Set(value As Boolean)
            mDrawAxisLimits = value
        End Set
    End Property

    Private Shared mDrawGrid As Boolean = False
    <Description("Draw grid"),
    Category("Custom"),
    DefaultValue(False)>
    Public Property DrawGrid() As Boolean
        Get
            Return mDrawGrid
        End Get
        Set(value As Boolean)
            mDrawGrid = value
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
        Set(value As Boolean)
            mDrawRapidLines = value
        End Set
    End Property

    Private Shared mDrawRapidPoints As Boolean = True
    <Description("Draw rapid tool motion points"),
    Category("Custom"),
    DefaultValue(True)>
    Public Property DrawRapidPoints() As Boolean
        Get
            Return mDrawRapidPoints AndAlso (Not mMouseDownAndMoving) AndAlso (Not drawMethod = enDrawMethod.INIT)
        End Get
        Set(value As Boolean)
            mDrawRapidPoints = value
        End Set
    End Property

    Private Shared mDrawToolDia As Boolean = True
    <Description("Draw tool circle"),
    Category("Custom"),
    DefaultValue(True)>
    Public Property DrawToolDia() As Boolean
        Get
            Return mDrawToolDia
        End Get
        Set(value As Boolean)
            mDrawToolDia = value
        End Set
    End Property

    Private Shared mArcAxis As ArcAxis = ArcAxis.Z
    <Description("Sets or gets the plane that arcs will be drawn on"),
    Category("Custom"),
    DefaultValue(ArcAxis.Z)>
    Public Property ArcAxis() As ArcAxis
        Get
            Return mArcAxis
        End Get
        Set(value As ArcAxis)
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
        Set(value As RotaryMotionType)
            mRotaryType = value
        End Set
    End Property

    Private Shared mRotaryPlane As ArcAxis = ArcAxis.X
    <Description("Sets or gets the plane that the fourth axis rotates on"),
    Category("Custom"),
    DefaultValue(ArcAxis.X)>
    Public Property RotaryPlane() As ArcAxis
        Get
            Return mRotaryPlane
        End Get
        Set(value As ArcAxis)
            mRotaryPlane = value
            Select Case value
                Case ArcAxis.X
                    mRotaryVector = New Vector3(1, 0, 0)
                Case ArcAxis.Y
                    mRotaryVector = New Vector3(0, 1, 0)
                Case ArcAxis.Z
                    mRotaryVector = New Vector3(0, 0, 1)
            End Select
        End Set
    End Property

    Private Shared mRotaryDirection As RotaryDirection = RotaryDirection.CW
    <Description("Sets or gets the direction of the fourth axis"),
    Category("Custom"),
    DefaultValue(RotaryDirection.CW)>
    Public Property RotaryDirection() As RotaryDirection
        Get
            Return mRotaryDirection
        End Get
        Set(value As RotaryDirection)
            mRotaryDirection = value
        End Set
    End Property

    Private mPitchX As Single = 0
    <Description("Sets or gets the X axis rotation"),
    Category("Custom"),
    DefaultValue(0)>
    Public Property Pitch() As Single
        Get
            Return mPitchX * (180 / PI_S)
        End Get
        Set(Value As Single)
            mPitchX = Value * (PI_S / 180)
            mArcBall.SetPitchRollYaw(mPitchX, mRollY, mYawZ)
            RaiseEvent OnViewOrientationChanged(Pitch, Roll, Yaw)
        End Set
    End Property

    Private mRollY As Single = 0
    <Description("Sets or gets the Y axis rotation"),
    Category("Custom"),
    DefaultValue(0)>
    Public Property Roll() As Single
        Get
            Return mRollY * (180 / PI_S)
        End Get
        Set(Value As Single)
            mRollY = Value * (PI_S / 180)
            mArcBall.SetPitchRollYaw(mPitchX, mRollY, mYawZ)
            RaiseEvent OnViewOrientationChanged(Pitch, Roll, Yaw)
        End Set
    End Property

    Private mYawZ As Single = 0
    <Description("Sets or gets the Z axis rotation"),
    Category("Custom"),
    DefaultValue(0)>
    Public Property Yaw() As Single
        Get
            Return mYawZ * (180 / PI_S)
        End Get
        Set(Value As Single)
            mYawZ = Value * (PI_S / 180)
            mArcBall.SetPitchRollYaw(mPitchX, mRollY, mYawZ)
            RaiseEvent OnViewOrientationChanged(Pitch, Roll, Yaw)
        End Set
    End Property

    Private mRotary As Single = 0
    <Description("Sets or gets the fourth axis position"),
    Category("Custom"),
    DefaultValue(0)>
    Public Property FourthAxis() As Single
        Set(Value As Single)
            If Value <> mRotary Then
                mRotary = Value
                mRotaryMatrix = Matrix44.Identity()
                If mRotary <> 0 Then
                    mRotaryMatrix = Matrix44.CreateFromAxisAngle(mRotaryVector, -mRotary * RotaryDirection)
                End If
                SetViewMatrix3D()
            End If
        End Set
        Get
            Return mRotary
        End Get
    End Property

    Private mArcQuality As Single = VARIABLE_QUALITY
    Private mSegAngle As Single = ONE_RADIAN / 16 'angle of circular segments
    Private mArcSegCount As Integer = 360
    <Description("Sets the quality of arcs. >=8 AND <=1440"),
    Category("Custom"),
    DefaultValue(16)>
    Public WriteOnly Property ArcSegmentCount() As Integer
        Set(value As Integer)
            If mArcQuality = FIXED_FINE_QUALITY Then
                mArcSegCount = 72
            Else
                'Set min and max values
                If value < 16 Then mArcSegCount = 16
                If value > 720 Then mArcSegCount = 720

                If mAllMotionRecords.Count < 5000 Then
                    mArcSegCount = 72
                End If
            End If
            mSegAngle = ONE_RADIAN / mArcSegCount
        End Set
    End Property

    Private Shared mMachineType As MachineType = MachineType.MILL
    <Description("The type of machine"),
    Category("Custom"),
    DefaultValue(MachineType.MILL)>
    Public Property MachineType() As MachineType
        Get
            Return mMachineType
        End Get
        Set(value As MachineType)
            mMachineType = value
        End Set
    End Property

    Private Shared mLimits(5) As Single
    <Browsable(False)>
    Public Property Limits() As Single()
        Get
            Return mLimits
        End Get
        Set(value As Single())
            mLimits = value
        End Set
    End Property

    Private Shared mFilterUpperZ As Single = Single.NaN
    <Browsable(False)>
    Public Property FilterUpperZ() As Single
        Get
            Return mFilterUpperZ
        End Get
        Set(value As Single)
            mFilterUpperZ = value
        End Set
    End Property

    Private Shared mFilterLowerZ As Single = Single.NaN
    <Browsable(False)>
    Public Property FilterLowerZ() As Single
        Get
            Return mFilterLowerZ
        End Get
        Set(value As Single)
            mFilterLowerZ = value
        End Set
    End Property

    Private Shared mFilterZCrossing As Boolean
    <Browsable(False)>
    Public Property FilterZCrossing() As Boolean
        Get
            Return mFilterZCrossing
        End Get
        Set(value As Boolean)
            mFilterZCrossing = value
        End Set
    End Property

    Private Shared mFilterZ As Boolean
    <Browsable(False)>
    Public Property FilterZ() As Boolean
        Get
            Return mFilterZ
        End Get
        Set(value As Boolean)
            mFilterZ = value
        End Set
    End Property

    Private Shared mSelectedMotionIndex As Integer
    <Browsable(False)>
    Public Property SelectedMotionIndex() As Integer
        Set(value As Integer)
            mSelectedMotionIndex = value
        End Set
        Get
            If mDisplayLists2DSelectionIndices.Count = 0 Then
                Return -1
            Else
                Return mSelectedMotionIndex 'MotionRecords.IndexOf(mSelectionHits(0))
            End If
        End Get
    End Property

    Private Shared mRangeEnd As Integer
    <Browsable(False)>
    Public Property RangeEnd() As Integer
        Set(value As Integer)
            If value = 0 Then
                mRangeEnd = AllMotionRecords.Count - 1
                mRangeStart = 0
            Else
                If value > AllMotionRecords.Count Then
                    mRangeEnd = AllMotionRecords.Count - 1
                    mRangeStart = 0
                Else
                    mRangeEnd = value
                End If
            End If
            If mRangeStart > mRangeEnd Then
                mRangeStart = 0
            End If
        End Set
        Get
            Return mRangeEnd
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property RangeMax() As Integer
        Get
            Return AllMotionRecords.Count - 1
        End Get
    End Property

    Private mTabletMode As Boolean
    <Browsable(False)>
    Public Property TabletMode() As Boolean
        Get
            Return mTabletMode
        End Get
        Set(value As Boolean)
            If value = True Then
                mSelectionPixRect.Width = 24
                mSelectionPixRect.Height = 24
            Else
                mSelectionPixRect.Width = 12
                mSelectionPixRect.Height = 12
            End If
            mTabletMode = value
            SetContextImages()
        End Set
    End Property

    Private Shared mRangeStart As Integer = 0
    <Browsable(False)>
    Public Property RangeStart() As Integer
        Set(value As Integer)
            mRangeStart = value
            If value > AllMotionRecords.Count Then
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
        Inherits EventArgs
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
            Set(value As Integer)
                x = value
            End Set
        End Property
        Public Property LocationY() As Integer
            Get
                Return y
            End Get
            Set(value As Integer)
                y = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return m_id
            End Get
            Set(value As Integer)
                m_id = value
            End Set
        End Property
        Public Property Flags() As Integer
            Get
                Return m_flags
            End Get
            Set(value As Integer)
                m_flags = value
            End Set
        End Property
        Public Property Mask() As Integer
            Get
                Return m_mask
            End Get
            Set(value As Integer)
                m_mask = value
            End Set
        End Property
        Public Property Time() As Integer
            Get
                Return m_time
            End Get
            Set(value As Integer)
                m_time = value
            End Set
        End Property
        Public Property ContactWidth() As Integer
            Get
                Return m_contactX
            End Get
            Set(value As Integer)
                m_contactX = value
            End Set
        End Property
        Public Property ContactHeight() As Integer
            Get
                Return m_contactY
            End Get
            Set(value As Integer)
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
        Inherits EventArgs
        ' Private data members
        Private x(1) As Integer        ' touch x client coordinate in pixels
        Private y(1) As Integer        ' touch y client coordinate in pixels

        Public Property LocationsX() As Integer()
            Get
                Return x
            End Get
            Set(value As Integer())
                x = value
            End Set
        End Property
        Public Property LocationsY() As Integer()
            Get
                Return y
            End Get
            Set(value As Integer())
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
    Private Const WM_INPUT As Integer = &HFF
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
    Private Const maxDrawTime As Integer = 500
    ' the cxContact and cyContact fields are valid
    ' Touch API defined structures [winuser.h]
    <StructLayout(LayoutKind.Sequential)>
    Private Structure TOUCHINPUT
        Public x As Integer
        Public y As Integer
        Public hSource As IntPtr
        Public dwID As Integer
        Public dwFlags As Integer
        Public dwMask As Integer
        Public dwTime As Integer
        Public dwExtraInfo As IntPtr
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
    Private Shared Function RegisterTouchWindow(hWnd As IntPtr, ulFlags As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32")>
    Private Shared Function GetSystemMetrics(smIndex As Integer) As Integer
    End Function

    <DllImport("user32")>
    Private Shared Function GetTouchInputInfo(hTouchInput As IntPtr, cInputs As Integer, <[In](), Out()> pInputs As TOUCHINPUT(), cbSize As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32")>
    Private Shared Sub CloseTouchInputHandle(lParam As IntPtr)
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
    Protected Overrides Sub WndProc(ByRef m As Message)
        ' Decode and handle WM_TOUCH message.
        'Debug.Print(m.Msg)
        'Debug.Print(WM_INPUT)
        Dim handled As Boolean
        Select Case m.Msg
            'Case 49661
            '    If Dx3.IsAvailable Then
            '        Dx3.ProcessWindowMessage(m.Msg, m.WParam, m.LParam)
            '        handled = True
            '    End If
            '    Exit Select
            'Case WM_INPUT
            '    If Dx3.IsAvailable Then
            '        Dx3.ProcessWindowMessage(m.Msg, m.WParam, m.LParam)
            '        handled = True
            '    End If
            '    Exit Select

            Case WM_TOUCH
                handled = DecodeTouch(m)
                Exit Select
            Case Else
                handled = False
                Exit Select
        End Select


        If handled Then
            ' Acknowledge event if handled.
            m.Result = New IntPtr(1)
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
    Private Shared Function LoWord(number As Integer) As Integer
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
                    'Debug.Print(te.IsPrimaryContact.ToString)
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
    Private Sub SetViewMatrix3D()
        'NOW USING A NEW MATRIX LIB THAT REQUIRES THE ORDER TO BE REVERSED.
        mViewMatrix = Matrix44.Identity()
        mViewMatrix *= mRotaryMatrix
        mViewMatrix.Translation += New Vector3(-mRotateAbout3D.X, -mRotateAbout3D.Y, -mRotateAbout3D.Z)
        mViewMatrix *= mArcBall.ActiveMatrix
    End Sub


    Public Sub SetVisibleByLine(rangeStart As Integer, rangeEnd As Integer)
        For Each m As clsMotionRecord In AllMotionRecords
            m.Visible = True
            If m.Linenumber < rangeStart OrElse m.Linenumber > rangeEnd Then
                m.Visible = False
            End If
        Next
    End Sub

    Public Sub SetZFilter()
        If FilterZ Then
            For Each m As clsMotionRecord In AllMotionRecords
                With m
                    .FilterZ = True
                    'If either start or end is within upper and lower then show
                    If mFilterZCrossing Then
                        If (.XYZpos.Z <= mFilterUpperZ AndAlso .XYZpos.Z >= mFilterLowerZ) OrElse (.XYZold.Z <= mFilterUpperZ AndAlso .XYZold.Z >= mFilterLowerZ) Then
                            .FilterZ = False
                        End If

                    Else 'If both start and end are within bounds then show
                        If (.XYZpos.Z <= mFilterUpperZ AndAlso .XYZpos.Z >= mFilterLowerZ) AndAlso (.XYZold.Z <= mFilterUpperZ AndAlso .XYZold.Z >= mFilterLowerZ) Then
                            .FilterZ = False
                        End If
                    End If
                End With
            Next
        Else
            For Each m As clsMotionRecord In AllMotionRecords
                m.FilterZ = False
            Next
        End If


    End Sub


    Public Sub SetRangeByLine(rangeStart As Integer, rangeEnd As Integer)
        If rangeEnd = 0 Then
            Me.RangeStart = 0
            Me.RangeEnd = 0
        Else
            For r As Integer = 0 To AllMotionRecords.Count - 1
                Dim mot As clsMotionRecord = AllMotionRecords(r)
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

    Private Sub MG_BasicViewer_BackColorChanged(sender As Object, e As EventArgs) Handles Me.BackColorChanged
        mInverseColor = Color.FromArgb(Not BackColor.R, Not BackColor.G, Not BackColor.B)
    End Sub

    Private Sub MG_BasicViewer_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If ReverseMouseWheel Then
            If Math.Sign(e.Delta) = 1 Then
                ZoomSceneAtMouse(CSng(1.1 * mMouseWheelZoomFactor))
            Else
                ZoomSceneAtMouse(CSng(0.9 / mMouseWheelZoomFactor))
            End If
        Else
            If Math.Sign(e.Delta) = -1 Then
                ZoomSceneAtMouse(CSng(1.1 * mMouseWheelZoomFactor))
            Else
                ZoomSceneAtMouse(CSng(0.9 / mMouseWheelZoomFactor))
            End If
        End If
        CreateDisplayListsAndDraw()
    End Sub

    'Public Function NearestKeyPoint2D(mousePt As PointF, p As clsDisplayList2D) As PointF
    '    Dim d1, d2 As Single
    '    Dim first = p.Points2d.First
    '    Dim last = p.Points2d.Last
    '    Dim mr = mAllMotionRecords(p.MotionIndex)

    '    Dim dist = Function(p1 As PointF, p2 As PointF)
    '                   Return Math.Sqrt((p1.X - p2.X) ^ 2 + (p1.Y - p2.Y) ^ 2)
    '               End Function

    '    d1 = dist(mousePt, first)
    '    d2 = dist(mousePt, last)
    '    mHighlightKeypoint2D.X = mDisplayLists3D.HighlightKeypoint2D.X
    '    mHighlightKeypoint2D.Y = mDisplayLists3D.HighlightKeypoint2D.Y
    '    mSelKeypoint3D = mDisplayLists3D.HighlightKeypoint3D
    '    'Return mHighlightKeypoint2D
    '    If d1 < d2 Then
    '        mSelKeypoint3D = GetVector3FromMotionRecord(mr, True)
    '        mHighlightKeypoint2D.X = first.X
    '        mHighlightKeypoint2D.Y = first.Y
    '        Return first
    '    Else
    '        mSelKeypoint3D = GetVector3FromMotionRecord(mr, False)
    '        mHighlightKeypoint2D.X = last.X
    '        mHighlightKeypoint2D.Y = last.Y
    '        Return last
    '    End If
    'End Function

    'Private Function GetVector3FromMotionRecord(mr As clsMotionRecord, start As Boolean) As Vector3
    '    mTempMatrix = Matrix44.Identity()
    '    If start Then
    '        mTempMatrix = Matrix44.CreateFromAxisAngle(mRotaryVector, -mr.OldRotaryPos * RotaryDirection)
    '        Return Vector3.Transform(New Vector3(mr.XYZold.X, mr.XYZold.Y, mr.XYZold.Z), mTempMatrix)
    '    Else
    '        mTempMatrix = Matrix44.CreateFromAxisAngle(mRotaryVector, -mr.NewRotaryPos * RotaryDirection)
    '        Return Vector3.Transform(New Vector3(mr.XYZpos.X, mr.XYZpos.Y, mr.XYZpos.Z), mTempMatrix)
    '    End If
    'End Function

    Private Sub MG_BasicViewer_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        SelectedMotionIndex = -1
        ContextMenuStrip = rmbView
        Try

            If e.Button = MouseButtons.Left Then
                ' Make a note that we "have the mouse".
                If ViewManipMode = ManipMode.SELECTION Then
                    If mSelectionHits.Count >= 1 Then
                        UpdateElementDetails()
                        SelectedMotionIndex = mSelectionHits(0).Index
                        RaiseEvent OnSelection(mSelectionHits, 0)
                        If mSelectionHits.Count > 1 AndAlso Cursor = Me.mSelectEtcCursor Then
                            ShowQuickPick()
                        End If
                    End If
                End If

                If ViewManipMode = ManipMode.SETROTATE Then
                    mSelKeypoint3D = mDisplayLists3D.PointOnKeypoint3D
                    If mSelectionHits.Count = 0 Then
                        mSelKeypoint3D = mExtentCenter
                    End If
                    SetRotatePoint(mSelKeypoint3D)
                    ViewManipMode = ManipMode.SELECTION
                    Redraw(True)
                End If

                If ViewManipMode = ManipMode.MEASURE Then
                    If mDisplayLists3D.IsOverKeypoint(mSelectionRect) Or mDisplayLists3D.PointOn Then
                        mMeasurement.SetKeypoint(mDisplayLists3D)
                    Else
                        'If we are not over an element or a keypoint then reset
                        SetView(ManipMode.SELECTION)
                    End If
                    Redraw(True)
                    DrawGraphicsOverlaysAllViews(mDisplayLists2DSelectionIndices, -1)
                End If

            End If

            If e.Button = MouseButtons.Middle Or ViewManipMode = ManipMode.ROTATE Then
                mArcBall.StartRotation(e.X, e.Y)
            End If
            mViewModeWhenMouseWasDown = ViewManipMode
        Catch ex As Exception
            Debug.Assert(0 = 1, "MG_BasicViewer_MouseDown")
        End Try
        ' Reset last.
        mLastPt.X = -1
        mLastPt.Y = -1
        ' Store the "starting point" for this rubber-band rectangle.
        mMouseDownPt.X = e.X
        mMouseDownPt.Y = e.Y
    End Sub

    Public Sub SetAllRotatePointToCenter()
        For Each viewer As MG_BasicViewer In MyNeighborhood
            viewer.SetRotatePoint(mExtentCenter)
        Next
    End Sub

    Private Sub SetRotatePoint(rotatePoint As Vector3)
        Static lastRotatePoint As Vector3
        'If lastRotatePoint = rotatePoint Then Return

        If Single.IsNaN(rotatePoint.X) Then
            rotatePoint = mExtentCenter
        End If

        mRotateAbout2DIndicator = Get2dFrom3D(rotatePoint)
        mRotateAbout3D = rotatePoint

        'move the translation from here to the arcball
        SetViewMatrix3D() 'After new rotate point

        'pan to compensate for the new rotation point
        PanScene(mRotateAbout2DIndicator.X, mRotateAbout2DIndicator.Y)
        'fix the 2d rotate point so it displays on screen ok
        mRotateAbout2DIndicator.X -= mRotateAbout2DIndicator.X
        mRotateAbout2DIndicator.Y -= mRotateAbout2DIndicator.Y
        lastRotatePoint = rotatePoint
    End Sub

    Private Shared mSelectionColor As Color
    Public Property SelectionColor() As Color
        Get
            Return mSelectionColor
        End Get
        Set(value As Color)
            mSelectionColor = value
        End Set
    End Property

    Private Shared mLimitsColor As Color = Color.DarkGray
    Public Property LimitsColor() As Color
        Get
            Return mLimitsColor
        End Get
        Set(value As Color)
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


    Private Sub TestForBorderRotateZone()
        If Not mMouseDownAndMoving Then
            If mCurrentCursorPos.Y > Height - ROTATE_BORDER Then 'near bottom X
                DrawTextOverlay("Rotate about Y")
            ElseIf mCurrentCursorPos.X < ROTATE_BORDER Then 'near left Z
                DrawTextOverlay("Rotate about Z")
            ElseIf mCurrentCursorPos.X > Width - ROTATE_BORDER Then 'near right Y
                DrawTextOverlay("Rotate about X")
            Else
                DrawTextOverlay("               ")
            End If
        End If
    End Sub

    Private Sub MG_BasicViewer_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Static Xold As Single
        Static Yold As Single
        If mTouchPointCount > 1 Then Return
        'Debug.Print("mousemove")
        Try
            Select Case e.Button
                Case MouseButtons.Left
                    mMouseDownAndMoving = True
                Case MouseButtons.Middle
                    mMouseDownAndMoving = True
                    If MB2Pan Then
                        ViewManipMode = ManipMode.PAN
                    Else
                        ViewManipMode = ManipMode.ROTATE
                    End If
                Case MouseButtons.Left, MouseButtons.Right
                    mMouseDownAndMoving = True
                    If MB2Pan Then
                        ViewManipMode = ManipMode.ROTATE
                    Else
                        ViewManipMode = ManipMode.PAN
                    End If
                    ContextMenuStrip = Nothing
            End Select

            mCurrentCursorPos.X = e.X
            mCurrentCursorPos.Y = e.Y
            'TestForBorderRotateZone()
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
                            If mDrawLinesMilliseconds > maxDrawTime Then
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
                        If mMouseDownPt.Y > Height - ROTATE_BORDER Then 'near bottom X
                            mArcBall.AddRotation(Maths.ToRadians(-Math.Sign(Xold - e.X)), New Vector3(0, 1, 0))
                        ElseIf mMouseDownPt.X < ROTATE_BORDER Then 'near left Z
                            mArcBall.AddRotation(Maths.ToRadians(-Math.Sign(Yold - e.Y)), New Vector3(0, 0, 1))
                        ElseIf mMouseDownPt.X > Width - ROTATE_BORDER Then 'near right Y
                            mArcBall.AddRotation(Maths.ToRadians(-Math.Sign(Yold - e.Y)), New Vector3(1, 0, 0))
                        Else
                            mArcBall.UpdateRotation(e.X, e.Y)
                            mArcBall.ApplyRotationMatrix()
                        End If

                        SetViewMatrix3D()
                        If mDynamicViewManipulation Then
                            If mDrawLinesMilliseconds > maxDrawTime Then
                                mArcQuality = FAST_QUALITY
                            End If
                            CreateDisplayListsAndDraw()
                            'DrawWinMouseLine(mMouseDownPt, e.Location)
                        Else
                            DrawWcsOnlyToBuffer()
                        End If
                    End If
                Case ManipMode.ZOOM
                    If (mMouseDownAndMoving) Then
                        Dim zFact As Single
                        If e.Y > mMouseDownPt.Y Then
                            zFact = 1 + ((e.Y - Yold) / Me.Height)
                        Else
                            zFact = 1 / (1 + (Math.Abs(e.Y - Yold) / Me.Height))
                        End If
                        ZoomSceneAtCenter(zFact)
                        If mDynamicViewManipulation Then
                            If mDrawLinesMilliseconds > maxDrawTime Then
                                mArcQuality = FAST_QUALITY
                            End If
                            CreateDisplayListsAndDraw()
                            'Me.mArcQuality = 1.0
                        End If
                    End If
                Case ManipMode.SELECTION, ManipMode.SETROTATE, ManipMode.MEASURE
                    SetSelectionRectangle()

                    Dim hitIndex = GetSelectionHits(mSelectionRect)
                    mDisplayLists3D.HitTest(hitIndex, mSelectionRect, mViewMatrix)
                    ReportMouseLocationInMachineUnits()
                    Select Case ViewManipMode
                        Case ManipMode.SELECTION
                            If SelectionChanged() Then
                                DrawGraphicsOverlaysAllViews(mDisplayLists2DSelectionIndices, -1)
                                DrawInfoOverlay()
                                RaiseEvent OnHighlight(mSelectionHits, 0)
                            End If

                        Case ManipMode.MEASURE
                            If mDisplayLists3D.IsOverKeypoint(mSelectionRect) Then
                                Me.Cursor = mMeasureKeypointCursor
                            Else
                                Me.Cursor = mMeasureCursor
                            End If
                            DrawGraphicsOverlaysAllViews(mDisplayLists2DSelectionIndices, -1)
                        Case ManipMode.SETROTATE
                            DrawAllKeyPointsOverlay()
                    End Select


            End Select
            ' Update last point.
            mLastPt = mCurrentCursorPos
            Xold = e.X
            Yold = e.Y
        Catch 'ex As Exception
            'Debug.Assert(0 = 1, "MG_BasicViewer_MouseMove")
        End Try

    End Sub
    Private Sub ReportMouseLocationInMachineUnits()
        Dim x, y, z As Single
        If mDisplayLists3D.CanDrawTarget Then
            x = Single.Parse(AdjustForUnits(mDisplayLists3D.PointOnKeypoint3D.X / mMasterGfxAdjustScale, mDisplayLists3D.Item.MotionParent.Units))
            y = Single.Parse(AdjustForUnits(mDisplayLists3D.PointOnKeypoint3D.Y / mMasterGfxAdjustScale, mDisplayLists3D.Item.MotionParent.Units))
            z = Single.Parse(AdjustForUnits(mDisplayLists3D.PointOnKeypoint3D.Z / mMasterGfxAdjustScale, mDisplayLists3D.Item.MotionParent.Units))
        End If
        RaiseEvent MouseLocation(x, y, z)
    End Sub

    Public Sub DrawKeypointIndicator(ByRef g As Graphics)
        Dim invColor = Color.FromArgb(100, mInverseColor)
        Dim d = mPixelF * 8
        Dim p As Vector3
        Dim kp(2) As Vector3

        With mDisplayLists3D
            kp(0) = Vector3.Transform(.Item.Keypoints(0), mViewMatrix)
            kp(1) = Vector3.Transform(.Item.Keypoints(1), mViewMatrix)
            kp(2) = Vector3.Transform(.Item.Keypoints(2), mViewMatrix)
            If .HasKeypoints Then
                Using kpPen As New Pen(mInverseColor)
                    kpPen.Width = 0
                    p = kp(0)
                    g.DrawLine(kpPen, p.X - d, p.Y, p.X + d, p.Y) '--
                    g.DrawLine(kpPen, p.X, p.Y - d, p.X, p.Y + d) '|

                    p = kp(2)
                    g.DrawLine(kpPen, p.X - d, p.Y, p.X + d, p.Y) '--
                    g.DrawLine(kpPen, p.X, p.Y - d, p.X, p.Y + d) '|

                    d /= 2
                    p = kp(1)
                    g.DrawLine(kpPen, p.X - d, p.Y, p.X + d, p.Y) '--
                    g.DrawLine(kpPen, p.X, p.Y - d, p.X, p.Y + d) '|
                End Using
            End If
        End With
    End Sub

    Private Sub SetSelectionRectangle()
        mSelectionPixRect.X = CInt(mMousePtF(1).X - mSelectionPixRect.Width / 2.0F)
        mSelectionPixRect.Y = CInt(mMousePtF(1).Y - mSelectionPixRect.Height / 2.0F)
        'Get a small selection viewport for selection.
        mSelectionRect.X = mMousePtF(1).X - mPixelF * mSelectionPixRect.Width / 2.0F
        mSelectionRect.Y = mMousePtF(1).Y - mPixelF * mSelectionPixRect.Height / 2.0F
        mSelectionRect.Width = mPixelF * mSelectionPixRect.Width
        mSelectionRect.Height = mPixelF * mSelectionPixRect.Height

    End Sub

    Private Sub DrawArcCenterExtensions(g As Graphics, mr As clsMotionRecord)
        mCurPen.Color = Color.FromArgb(64, Not BackColor.R, Not BackColor.G, Not BackColor.B)
        mCurPen.DashStyle = DashStyle.Solid
        mCurPen.Width = 0
        mPoints2D.Clear()
        FourthAxis = mr.NewRotaryPos
        Dim pos As New Vector3(mr.XYZpos.X, mr.XYZpos.Y, mr.XYZpos.Z)
        Dim old As New Vector3(mr.XYZold.X, mr.XYZold.Y, mr.XYZold.Z)
        Dim center As New Vector3(mr.XYZcenter.X, mr.XYZcenter.Y, mr.XYZcenter.Z)

        'in the case of a helix we need to average the axis positions
        Select Case mr.ArcPlane
            Case Motion.XY_PLN
                center.Z = (old.Z + pos.Z) / 2
            Case Motion.XZ_PLN
                center.Y = (old.Y + pos.Y) / 2
            Case Motion.YZ_PLN
                center.X = (old.X + pos.X) / 2
        End Select

        Line3D(center.X, center.Y, center.Z, old.X, old.Y, old.Z)
        Line3D(center.X, center.Y, center.Z, pos.X, pos.Y, pos.Z)
        FourthAxis = 0
        g.DrawLines(mCurPen, mPoints2D.ToArray)
    End Sub

    Private Function SelectionChanged() As Boolean
        Static lastHitindex As Integer = -2
        Dim thisHitindex As Integer
        Dim retval As Boolean = True
        If mDisplayLists2DSelectionIndices.Count > 0 Then
            thisHitindex = mDisplayLists2DSelectionIndices.First
        Else
            thisHitindex = -1 'no selection
        End If
        retval = (thisHitindex <> lastHitindex)
        lastHitindex = thisHitindex
        Return retval
    End Function

    Private Sub MG_BasicViewer_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        'Dim curCursor As Cursor = Me.Cursor
        Try
            If mArcBall.IsRotating Then
                mArcBall.stopRotation()
            End If
            ' Set internal flag to know we no longer "have the mouse".
            mMouseDownAndMoving = False
            Me.mArcQuality = VARIABLE_QUALITY
            ' Set flags to know that there is no "previous" line to reverse.
            mLastPt.X = -1
            mLastPt.Y = -1

            If Not mDynamicViewManipulation Then
                Me.Cursor = Cursors.WaitCursor
            End If
            Select Case ViewManipMode
                Case ManipMode.PAN
                    If Not mDynamicViewManipulation Then
                        PanScene((mMousePtF(1).X - mMousePtF(0).X), mMousePtF(1).Y - mMousePtF(0).Y)
                    End If
                    CreateDisplayListsAndDraw()
                    SaveView()

                Case ManipMode.ROTATE
                    CreateDisplayListsAndDraw()
                    SaveView()

                Case ManipMode.FENCE
                    If mMouseDownPt.X <> e.X AndAlso mMouseDownPt.Y <> e.Y Then
                        WindowViewport(mMousePtF(0).X, mMousePtF(0).Y, mMousePtF(1).X, mMousePtF(1).Y)
                        CreateDisplayListsAndDraw()
                        SaveView()
                    End If
                Case ManipMode.ZOOM
                    CreateDisplayListsAndDraw()
                    SaveView()

            End Select
            ViewManipMode = mViewModeWhenMouseWasDown


            'Me.Cursor = curCursor
        Catch
            Debug.Assert(0 = 1, "MG_BasicViewer_MouseUp")
        End Try

    End Sub

    ' Convert and Normalize the points and draw the reversible frame.
    Private Sub DrawWinMouseRect(p1 As Point, p2 As Point)
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
        mCurPen.DashStyle = DashStyle.Dot
        Using g As Graphics = Graphics.FromHwnd(Me.Handle)
            g.DrawRectangle(mCurPen, rc)
        End Using
    End Sub

    Private Sub DrawSelectionRectangle(rc As Rectangle)
        'Draw the buffer
        If Not (mGfxBuff Is Nothing) Then
            mGfxBuff.Render()
        End If

        'Draw the selection overlay.
        mCurPen.Color = mInverseColor
        mCurPen.Width = 0
        mCurPen.DashStyle = DashStyle.Solid
        Using g As Graphics = Graphics.FromHwnd(Me.Handle)
            g.DrawRectangle(mCurPen, rc)
        End Using
    End Sub

    Private Sub DrawWinMouseLine(p1 As Point, p2 As Point)
        'Draw the buffer
        If Not (mGfxBuff Is Nothing) Then
            mGfxBuff.Render()
        End If

        'Draw the selection overlay.
        mCurPen.Color = mInverseColor
        mCurPen.DashStyle = DashStyle.Dash
        Using g As Graphics = Graphics.FromHwnd(Me.Handle)
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

    Public Sub ZoomSceneAtMouse(zoomFactor As Single)
        Dim factor As Single = (1 - zoomFactor)

        Dim leftScale As Single = (mCurrentCursorPos.X / mClientRect.Width)
        Dim rightScale As Single = 1.0F - leftScale
        leftScale = 1 - (leftScale * factor)
        rightScale = 1 - (rightScale * factor)

        Dim topScale As Single = (mCurrentCursorPos.Y / mClientRect.Height)
        Dim bottomScale As Single = (1.0F - topScale)
        topScale = 1 - (topScale * factor)
        bottomScale = 1 - (bottomScale * factor)

        WindowViewport(mViewportCenter.X - ((mViewRect.Width / 2) * leftScale),
                       mViewportCenter.Y - ((mViewRect.Height / 2) * bottomScale),
                       mViewportCenter.X + ((mViewRect.Width / 2) * rightScale),
                       mViewportCenter.Y + ((mViewRect.Height / 2) * topScale))
    End Sub


    Public Sub ZoomSceneAtCenter(zoomFactor As Single)
        Dim newWid As Single = mViewRect.Width * zoomFactor
        Dim newHt As Single = mViewRect.Height * zoomFactor

        mViewRect.X += (mViewRect.Width - newWid) / 2
        mViewRect.Y += (mViewRect.Height - newHt) / 2
        mViewRect.Width = newWid
        mViewRect.Height = newHt
        mLongside = Math.Max(mViewRect.Width, mViewRect.Height)
        SetViewMatrix2D()
    End Sub

    Public Sub PanSceneTo(x As Single, y As Single)
        Dim deltaX, deltaY As Single
        deltaX = mViewportCenter.X - x
        deltaY = mViewportCenter.Y - y
        mViewRect.X -= deltaX
        mViewRect.Y -= deltaY
        mViewportCenter.X = x
        mViewportCenter.Y = y
        SetViewMatrix2D()
    End Sub

    Public Sub PanScene(deltaX As Single, deltaY As Single)
        mViewRect.X -= deltaX
        mViewRect.Y -= deltaY
        mViewportCenter.X -= deltaX
        mViewportCenter.Y -= deltaY
        SetViewMatrix2D()
    End Sub

    Public Sub WindowViewport(X1 As Single, Y1 As Single, X2 As Single, Y2 As Single)
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
        If Math.Abs(Y2 - Y1) > 1000000 Then
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

        'If mSelBuff IsNot Nothing Then
        '    mSelBuff.Dispose()
        '    mGfxBuff = Nothing
        'End If

        ' Retrieves the BufferedGraphicsContext for the current application domain.
        mContext = BufferedGraphicsManager.Current
        ' Sets the maximum size for the primary graphics buffer
        mContext.MaximumBuffer = New Size(Me.Width + 1, Me.Height + 1)
        ' Allocates a graphics buffer the size of this control
        mGfxBuff = mContext.Allocate(CreateGraphics(), New Rectangle(0, 0, Me.Width, Me.Height))
        'mSelBuff = mContext.Allocate(CreateGraphics(), New Rectangle(0, 0, Me.Width, Me.Height))
        mGfx = mGfxBuff.Graphics
    End Sub

    ''' <summary>
    ''' Sets the matrix required to draw to the specified view
    ''' </summary>
    Private Function SetViewMatrix2D() As Boolean
        If Single.IsInfinity(mViewRect.Width) OrElse Single.IsInfinity(mViewRect.Height) Then Return False
        If mViewRect.Width = 0 OrElse mViewRect.Height = 0 Then Return False

        'The ratio between the actual size of the screen and the size of the graphics.
        mScaleToReal = (mClientRect.Width / mGfx.DpiX) / mViewRect.Width

        'If mScaleToReal < 0.1 Then Return False

        mMtxDraw.Reset()
        mMtxDraw.Scale(mScaleToReal, mScaleToReal)
        mMtxDraw.Translate(-mViewportCenter.X, mViewportCenter.Y)
        mMtxDraw.Translate((mViewRect.Width / 2.0F), (mViewRect.Height / 2.0F))
        mMtxDraw.Scale(1, -1) 'Flip the Y


        'text
        mMtxText.Reset()
        mMtxText.Scale(mScaleToReal, mScaleToReal)
        mMtxText.Translate(-mViewportCenter.X, mViewportCenter.Y)
        mMtxText.Translate((mViewRect.Width / 2.0F), (mViewRect.Height / 2.0F))


        mPixelF = ((1 / mGfx.DpiX) / mScaleToReal)
        mBlipSize = (mPixelF * 3.0F)
        mEndPointSize = (mPixelF * 2.0F)
        mFeedrateFont = New Font(OverlayFont.FontFamily, mPixelF * 1000)
        SetFeedbackMatrix()
        Return True
    End Function

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
        mArcBall.SetWidthHeight(mClientRect.Width, mClientRect.Height)

        SetViewMatrix2D()
    End Sub

    Private Sub SetFeedbackMatrix()
        mMtxFeedback.Reset()
        mMtxFeedback.Scale(mGfx.DpiX, mGfx.DpiY)
        mMtxFeedback.Multiply(mMtxDraw)
        mMtxFeedback.Invert()
    End Sub

    'I would like to take the graphics on the screen and print them to an area on the sheet.
    Public Sub PrintScreen(e As Printing.PrintPageEventArgs, region As Rectangle, scaleMode As Integer, scale As Single)
        Dim mtxWcs As New Matrix
        Dim mtxDraw As New Matrix
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

        If MachineUnits = MachineUnits.ENGLISH Then
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

        mCurPen.Width = 0

        mCurPen.Color = Color.Black
        mCurPen.DashStyle = DashStyle.Solid

        mArcQuality = FIXED_FINE_QUALITY
        CreateDisplayListsFromMotionRecords()
        SetAllInVeiw()
        With g
            'Shift to the margin
            .Clip = clipRegion
            .PageUnit = gUnits
            .Transform.Translate(printMarginRectF.X, printMarginRectF.Y)
            .DrawRectangle(mCurPen, printMarginRectF.X, printMarginRectF.Y, printMarginRectF.Width, printMarginRectF.Height)

            .ResetTransform()
            .MultiplyTransform(mtxDraw)
            'Draw the axis indicator and axis lines
            mWCSPen.Width = 0
            For Each p As clsDisplayList2D In mWcsDisplayLists
                If p.DashStyle <> DashStyle.Solid Then
                    mWCSPen.DashStyle = DashStyle.Dash
                    mWCSPen.DashPattern = mAxisDashStyle
                Else
                    mWCSPen.DashStyle = DashStyle.Solid
                End If
                mWCSPen.Color = p.Color
                .DrawLines(mWCSPen, p.Points2d)
            Next
            '.ResetTransform()

            'Now draw the toolpath
            '.MultiplyTransform(mtxDraw)
            mCurPen.Width = 0
            For Each p As clsDisplayList2D In mDisplayLists2D
                If Not p.InView Then
                    Continue For
                End If
                mCurPen.DashStyle = p.DashStyle

                If p.Color = Color.White Then 'White on white is not good
                    mCurPen.Color = Color.Gray
                Else
                    mCurPen.Color = p.Color
                End If
                .DrawLines(mCurPen, p.Points2d)
            Next
        End With
        mArcQuality = VARIABLE_QUALITY

        If clipRegion IsNot Nothing Then clipRegion.Dispose()
    End Sub

    Public Sub CancelCreateDisplayList(value As Boolean)
        If value Then
            mCancelSlowDisplayList = True
        Else
            mAllowSlowDisplayList = True
        End If
    End Sub

    Private Function HasExtent() As Boolean
        If mExtentX(0) = 0 And mExtentX(1) = 0 And mExtentY(0) = 0 And mExtentY(1) = 0 Then
            Return False
        End If

        'If mExtentY(0) = 0 And mExtentY(1) = 0 Then
        '    Return False
        'End If
        Return True
    End Function

    Private Sub DrawListsToGraphics(ByRef g As Graphics)
        If mGfxBuff Is Nothing Then Return
        If Not HasExtent() Then
            Return
        End If

        Dim sw As New Stopwatch
        Dim limitDashStyle As Single() = New Single() {2.0F, 2.0F}

        Try
            mCurPen.Width = -1
            With g
                .SmoothingMode = SmoothingMode.HighSpeed
                .PageUnit = GraphicsUnit.Inch
                .ResetTransform()
                .MultiplyTransform(mMtxDraw)
                mAxisDashStyle(0) = 0.15F / mScaleToReal
                mAxisDashStyle(1) = 0.15F / mScaleToReal

                If mViewManipMode = ManipMode.ROTATE Then
                    DrawRotateTargetToGraphics(g, mRotateAbout2DIndicator)
                End If

                'Draw the axis indicator and axis lines
                mWCSPen.Width = 0
                For Each p As clsDisplayList2D In mWcsDisplayLists
                    If mCancelSlowDisplayList Then Exit For
                    mWCSPen.DashStyle = p.DashStyle
                    If p.DashStyle = DashStyle.Custom Then
                        mWCSPen.DashPattern = mAxisDashStyle
                    End If
                    mWCSPen.Color = p.Color
                    .DrawLines(mWCSPen, p.Points2d)
                Next

                'Now draw the toolpath
                'Adjust the dash style to suit the view scale
                mRapidDashStyle(0) = 0.05F / mScaleToReal
                mRapidDashStyle(1) = 0.05F / mScaleToReal

                limitDashStyle(0) = 0.1F / mScaleToReal
                limitDashStyle(1) = 0.2F / mScaleToReal


                mCurPen.DashStyle = DashStyle.Solid

                If mGridDisplayLists.Count > 0 Then
                    mCurPen.Color = LimitsColor
                    For Each p As clsDisplayList2D In mGridDisplayLists
                        .DrawLines(mCurPen, p.Points2d)
                    Next
                End If

                'mCurPen.DashStyle = DashStyle.Solid
                mCurPen.DashPattern = limitDashStyle
                If mLimitsDisplayLists.Count > 0 Then
                    mCurPen.Color = LimitsColor
                    For Each p As clsDisplayList2D In mLimitsDisplayLists
                        .DrawLines(mCurPen, p.Points2d)
                    Next
                End If

                For Each p As clsDisplayList2D In mDisplayLists2D
                    If mCancelSlowDisplayList Then Exit For
                    If Not p.InView Then
                        Continue For
                    End If
                    mCurPen.DashStyle = p.DashStyle
                    If p.DashStyle = DashStyle.Dash Then
                        mCurPen.DashPattern = mRapidDashStyle
                    End If
                    mCurPen.Color = p.Color

                    If PerformLineFixup Then LineFixUp(p.Points2d)

                    If mAllowSlowDisplayList Then 'just draw
                        .DrawLines(mCurPen, p.Points2d)
                    Else 'test for speed
                        sw.Start()
                        .DrawLines(mCurPen, p.Points2d)
                        mDrawLinesMilliseconds = sw.ElapsedMilliseconds
                        If sw.ElapsedMilliseconds > 2000 Then
                            RaiseEvent OnSlowDrawingAlert(Me)
                        End If
                    End If

                    If DrawEndPoints Then
                        DrawEndPoint(p.Points2d.Last)
                    End If

                Next
                DrawMeasurementToGraphics(g)
                For Each p As clsDisplayList2D In mToolCompDisplayLists
                    .DrawLines(mCurPen, p.Points2d)
                Next

                For Each p As clsDisplayList2D In mToolDiaDisplayLists
                    mCurPen.DashStyle = DashStyle.Dash
                    mCurPen.DashPattern = mRapidDashStyle
                    mCurPen.Color = p.Color
                    .DrawLines(mCurPen, p.Points2d)
                    '.FillClosedCurve(Brushes.Blue, p.Points2d)
                Next

                '.SmoothingMode = SmoothingMode.HighQuality
                For Each p As clsDisplayList2D In mUserDisplayLists
                    mCurPen.Color = p.Color
                    If p.Points2d.Length = 1 Then
                        DrawDot(p.Points2d.Last)
                    Else
                        mCurPen.DashStyle = p.DashStyle
                        If p.DashStyle <> DashStyle.Solid Then
                            mCurPen.DashPattern = mRapidDashStyle
                        End If
                        .DrawLines(mCurPen, p.Points2d)
                    End If
                Next
            End With

        Catch
            Debug.Assert(False, "DrawListsToGraphics")
        Finally
            sw.Stop()
        End Try

    End Sub

    Private Sub DrawDirectionFlag(g As Graphics, p As clsDisplayList2D)
        Dim rx As Double
        Dim ry As Double
        Dim sp As PointF
        Dim ep As PointF
        mCurPen.Width = -1
        mCurPen.EndCap = Nothing
        If p.Points2d.Length > 1 Then
            mPoints2D.Clear()
            Dim m = mAllMotionRecords(p.MotionIndex)


            Dim s = New Vector2(p.Points2d.First.X, p.Points2d.First.Y)
            Dim e = New Vector2(p.Points2d.Last.X, p.Points2d.Last.Y)
            Dim midpoint As Vector2

            If p.Points2d.Length = 2 Then
                midpoint = (s + e) / 2
            Else
                midpoint.X = p.Points2d(p.Points2d.Length \ 2).X
                midpoint.Y = p.Points2d(p.Points2d.Length \ 2).Y
            End If

            Dim v As Vector2 = (s - e)
            If v.Length < 0.0001 Then Return

            v.Normalise()
            v = v * (mBlipSize * 4)

            If Math.Abs((e - s).Length) < mBlipSize * 8 Then Return

            Dim comp = mAllMotionRecords(p.MotionIndex).Comp
            sp = New PointF(midpoint.X, midpoint.Y)

            Debug.Print(mArcBall.ActiveMatrix.Up.Z.ToString)

            If comp = CutterComp.OFF Or comp = CutterComp.RIGHT Then
                Rotate2D(40.0, v, rx, ry)
                ep = New PointF(midpoint.X + rx, midpoint.Y + ry)
                g.DrawLine(mCurPen, sp, ep)
            End If

            If comp = CutterComp.OFF Or comp = CutterComp.LEFT Then
                Rotate2D(-40.0, v, rx, ry)
                ep = New PointF(midpoint.X + rx, midpoint.Y + ry)
                g.DrawLine(mCurPen, sp, ep)
            End If

        End If
    End Sub
    Private Sub Rotate2D(a As Double, v As Vector2, ByRef rx As Double, ByRef ry As Double)
        'x = Cos(Theta) * x - Sin(Theta) * y
        'y = Sin(Theta) * x + Cos(Theta) * y 
        Dim ang = a / 180 * Math.PI
        Dim sina = Math.Sin(ang)
        Dim cosa = Math.Cos(ang)
        rx = cosa * v.X - sina * v.Y
        ry = sina * v.X + cosa * v.Y
    End Sub

    Private Sub DrawMeasurementToGraphics(ByRef g As Graphics)
        mMeasurement.Draw(g, mViewMatrix, BackColor, mFeedrateFont, mScaleToReal, mMasterGfxAdjustScale)
    End Sub

    Private Sub DrawDot(p As PointF)
        Dim size = ((1 / mGfx.DpiX) / mScaleToReal) * 3
        Dim w = New SizeF(size * 2, size * 2)
        Dim r = New SizeF(size, size)
        Dim rec As New RectangleF(p - r, w)
        Using sb As New SolidBrush(mCurPen.Color)
            mGfx.FillEllipse(sb, rec)
        End Using
    End Sub

    Private Sub DrawEndPoint(p As PointF)

        mCurPen.Width = ((1 / mGfx.DpiX) / mScaleToReal) * 4
        Dim ep As PointF = p
        Dim sp As PointF = p
        ep.X += mBlipSize / 2
        sp.X -= mBlipSize / 2
        mGfx.DrawLine(mCurPen, sp, ep)
        mCurPen.Width = -1
    End Sub

    Private Sub DrawRotateTargetToGraphics(g As Graphics, pt As PointF)
        Try
            Dim alpha = 100
            Dim dia = mPixelF * 10
            If ViewManipMode = ManipMode.SETROTATE Then
                dia = mPixelF * 20
                alpha = 200
            End If
            Dim clr = Color.FromArgb(alpha, mInverseColor)
            Using myPen As New Pen(clr, 0)
                myPen.Width = -1
                Dim targetrect As New RectangleF(pt.X - dia / 2, pt.Y - dia / 2, dia, dia)
                With g
                    .DrawArc(myPen, targetrect, 0, 360)
                    .DrawLine(myPen, pt.X - dia, pt.Y, pt.X + dia, pt.Y)
                    .DrawLine(myPen, pt.X, pt.Y - dia, pt.X, pt.Y + dia)
                End With
            End Using
        Catch
            Debug.Assert(False, "DrawKeyPointTargetToGraphics")
        End Try

    End Sub

    Private Sub DrawSpeedsFeedsToGraphics(ByRef g As Graphics, drawspeed As Boolean, drawcomp As Boolean)
        If mGfxBuff Is Nothing Then Return
        Dim screenPoints() As PointF = Nothing
        Static lastFeed As Double
        Static lastSpeed As Double
        Static lastComp As CutterComp = CutterComp.OFF
        Static lastMode As IncAbsMode = IncAbsMode.ABS
        Dim xOffset As Single = 0
        Try
            mCurPen.Width = -1
            With g
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                .PageUnit = GraphicsUnit.Inch
                .ResetTransform()
                .MultiplyTransform(mMtxText)

                mCurPen.DashStyle = DashStyle.Solid
                'mCurPen.DashPattern = limitDashStyle
                For Each p As clsDisplayList2D In mDisplayLists2D
                    mCurPen.DashStyle = DashStyle.Solid
                    mCurPen.Color = p.Color
                    Dim motionRec As clsMotionRecord = mAllMotionRecords(p.MotionIndex)
                    If drawspeed Then
                        If motionRec.FeedRate <> lastFeed AndAlso motionRec.FeedRate <> 0 Then

                            Dim str As String = "F" & motionRec.FeedRate
                            'Draw the overlay.
                            Dim fpt As New PointF(p.Points2d(p.Points2d.Count \ 2).X, -p.Points2d(p.Points2d.Count \ 2).Y)
                            If p.Points2d.Count = 2 Then
                                fpt.X = (p.Points2d(0).X + p.Points2d(1).X) / 2
                                fpt.Y = -(p.Points2d(0).Y + p.Points2d(1).Y) / 2
                            End If

                            Using textBrush As New SolidBrush(mCurPen.Color)
                                g.DrawString(str, mFeedrateFont, textBrush, fpt)
                            End Using
                            xOffset = g.MeasureString(str, mFeedrateFont).Width
                        End If
                    End If
                    'speed
                    If drawspeed AndAlso motionRec.Speed <> lastSpeed AndAlso motionRec.Speed <> 0 Then
                        Dim str As String = "S" & motionRec.Speed
                        'Draw the overlay.
                        Dim fpt As New PointF(p.Points2d(p.Points2d.Count \ 2).X, -p.Points2d(p.Points2d.Count \ 2).Y)
                        If p.Points2d.Count = 2 Then
                            fpt.X = ((p.Points2d(0).X + p.Points2d(1).X) / 2)
                            fpt.Y = (-(p.Points2d(0).Y + p.Points2d(1).Y) / 2)
                        End If
                        fpt.X += xOffset
                        Using textBrush As New SolidBrush(mCurPen.Color)
                            g.DrawString(str, mFeedrateFont, textBrush, fpt)
                        End Using
                        xOffset += g.MeasureString(str, mFeedrateFont).Width

                    End If

                    If motionRec.MotionType <> Motion.RAPID Then
                        lastFeed = motionRec.FeedRate
                    End If
                    lastSpeed = motionRec.Speed

                    If drawcomp AndAlso motionRec.Comp <> lastComp Then
                        Dim arrowSt As New PointF(p.Points2d(p.Points2d.Count \ 2).X, -p.Points2d(p.Points2d.Count \ 2).Y)
                        If p.Points2d.Count = 2 Then
                            arrowSt.X = ((p.Points2d(0).X + p.Points2d(1).X) / 2)
                            arrowSt.Y = (-(p.Points2d(0).Y + p.Points2d(1).Y) / 2)
                        End If

                        Select Case motionRec.Comp
                            Case CutterComp.LEFT
                                Using textBrush As New SolidBrush(mCurPen.Color)
                                    g.DrawString(" L", mFeedrateFont, textBrush, arrowSt)
                                End Using

                            Case CutterComp.RIGHT
                                Using textBrush As New SolidBrush(mCurPen.Color)
                                    g.DrawString(" R", mFeedrateFont, textBrush, arrowSt)
                                End Using
                            Case CutterComp.OFF
                                Using textBrush As New SolidBrush(mCurPen.Color)
                                    g.DrawString(" O", mFeedrateFont, textBrush, arrowSt)
                                End Using

                        End Select
                    End If
                    lastComp = motionRec.Comp
                    xOffset = 0
                Next
            End With
        Catch
            Debug.Assert(False, "DrawListsToGraphics")
        End Try

    End Sub


    'I hate this!
    'A problem exists where if the line is extended beyond the screen and it is at a sight angle
    'then it will not display completly.
    'This seems to fix the problem without too much extra processing.
    Private Sub LineFixUp(ByRef pts() As PointF)
        If pts.Length = 2 Then
            If Math.Sqrt(((pts(0).X - pts(1).X) ^ 2) + ((pts(0).Y - pts(1).Y) ^ 2)) > Me.mViewRect.Width Then

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
        If Not HasExtent() Then
            Return
        End If

        CreateWcs()
        With mGfx
            .Clear(BackColor)
            .PageUnit = GraphicsUnit.Inch
            .ResetTransform()
            .MultiplyTransform(mMtxDraw)
            'Draw the axis indicator and axis lines
            mWCSPen.Width = 0
            For Each p As clsDisplayList2D In mWcsDisplayLists
                mWCSPen.DashStyle = p.DashStyle
                mWCSPen.DashPattern = mAxisDashStyle
                mWCSPen.Color = p.Color
                .DrawLines(mWCSPen, p.Points2d)
            Next
        End With
        mGfxBuff.Render()
    End Sub

    Private Function AdjustForUnits(val As Single, mrUnits As MachineUnits) As String
        Select Case mrUnits
            Case MachineUnits.ENGLISH
                Return val.ToString(NUMBERFORMAT, Globalization.NumberFormatInfo.InvariantInfo)
            Case Else
                val *= 25.4F
                Return val.ToString(NUMBERFORMAT, Globalization.NumberFormatInfo.InvariantInfo)
        End Select
    End Function


    Public Sub DrawInfoOverlay()
        If mDrawOverlayText = False OrElse mDisplayLists2D.Count = 0 Then Return
        If mDisplayLists2DSelectionIndices.Count = 0 OrElse mSelectionHits.Count = 0 Then Return
        mLastSelectedMotionRecord = mSelectionHits(0)

        Dim fontHeight As Integer = OverlayFont.Height
        Dim mr As clsMotionRecord = MotionBlockFromSelection()
        Dim mp As New Point(2, 2)
        Dim str As String
        'Draw the overlay.
        Using textBrush As New SolidBrush(Color.FromArgb(180, Not BackColor.R, Not BackColor.G, Not BackColor.B))
            Using g As Graphics = Graphics.FromHwnd(Me.Handle)
                mp.X = 2 : mp.Y = 2
                textBrush.Color = Color.FromArgb(180, Not BackColor.R, Not BackColor.G, Not BackColor.B)
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

                str = "T" & mr.Tool.ToString(NUMBERFORMAT, Globalization.NumberFormatInfo.InvariantInfo)
                g.DrawString(str, OverlayFont, textBrush, mp)
                mp.Offset(0, fontHeight + 2)
                g.DrawString(mr.Comp.ToString, OverlayFont, textBrush, mp)
                mp.Offset(0, fontHeight + 2)

                str = "S" & mr.Speed.ToString(NUMBERFORMAT, Globalization.NumberFormatInfo.InvariantInfo)
                g.DrawString(str, OverlayFont, textBrush, mp)
                mp.Offset(0, fontHeight + 2)

                str = "F" & mr.FeedRate
                g.DrawString(str, OverlayFont, textBrush, mp)
                mp.Offset(0, fontHeight + 2)
                g.DrawString(mr.MotionMode.ToString, OverlayFont, textBrush, mp)

                mp.Offset(0, fontHeight + 2)
                str = IIf(mr.Units = MachineUnits.ENGLISH, "IN", "MM")
                g.DrawString(str, OverlayFont, textBrush, mp)

                mp.Offset(0, fontHeight + 2)
                g.DrawString(mr.OffsetString, OverlayFont, textBrush, mp)

                If DrawExtraOverlayInfo Then
                    CalculateMotionRecordLength(mr)

                    Select Case mr.MotionType
                        Case Motion.CCARC, Motion.CWARC
                            'Type
                            'Center,Rad
                            'Start,End
                            'sAng,eAng
                            mp.Y = Me.ClientRectangle.Height - ((2 + fontHeight) * 5)
                            str = mr.MotionType.ToString
                            str += " R" & AdjustForUnits(mr.Rad, mr.Units)
                            str += " " & mr.MotionMode.ToString
                            g.DrawString(str, OverlayFont, textBrush, mp)
                            mp.Offset(0, fontHeight + 2)
                            str = "CTR X" & AdjustForUnits(mr.XYZcenter.X, mr.Units)
                            str += " Y" & AdjustForUnits(mr.XYZcenter.Y, mr.Units)
                            str += " Z" & AdjustForUnits(mr.XYZcenter.Z, mr.Units)
                            g.DrawString(str, OverlayFont, textBrush, mp)


                            mp.Offset(0, fontHeight + 2)
                            str = "X" & AdjustForUnits(mr.XYZold.X, mr.Units)
                            str += " > X" & AdjustForUnits(mr.XYZpos.X, mr.Units)
                            str += " Y" & AdjustForUnits(mr.XYZold.Y, mr.Units)
                            str += " > Y" & AdjustForUnits(mr.XYZpos.Y, mr.Units)
                            str += " Z" & AdjustForUnits(mr.XYZold.Z, mr.Units)
                            str += " > Z" & AdjustForUnits(mr.XYZpos.Z, mr.Units)
                            g.DrawString(str, OverlayFont, textBrush, mp)

                            mp.Offset(0, fontHeight + 2)
                            str = "ANG " & AngleToDegrees(mr.Sang)
                            str += " > " & AngleToDegrees(mr.Eang)
                            g.DrawString(str, OverlayFont, textBrush, mp)
                        Case Motion.LINE, Motion.RAPID, Motion.HOLE_I, Motion.HOLE_R
                            mp.Y = Me.ClientRectangle.Height - 2 - (fontHeight * 3)
                            g.DrawString(mr.MotionType.ToString & " " & mr.MotionMode.ToString & " " & AdjustForUnits(mr.CuttingLength, mr.Units), OverlayFont, textBrush, mp)

                            mp.Offset(0, fontHeight + 2)
                            str = "X" & AdjustForUnits(mr.XYZold.X, mr.Units)
                            str += " > X" & AdjustForUnits(mr.XYZpos.X, mr.Units)
                            str += " Y" & AdjustForUnits(mr.XYZold.Y, mr.Units)
                            str += " > Y" & AdjustForUnits(mr.XYZpos.Y, mr.Units)
                            str += " Z" & AdjustForUnits(mr.XYZold.Z, mr.Units)
                            str += " > Z" & AdjustForUnits(mr.XYZpos.Z, mr.Units)
                            g.DrawString(str, OverlayFont, textBrush, mp)

                    End Select
                End If

                mp.Y = Me.ClientRectangle.Height - 2 - fontHeight
                g.DrawString(mr.Codestring, OverlayFont, textBrush, mp)

            End Using
        End Using
    End Sub

    Private Function AngleToDegrees(angle As Single) As String
        Return (angle * (180.0 / Math.PI)).ToString(NUMBERFORMAT, Globalization.NumberFormatInfo.InvariantInfo)
    End Function

    Public Sub DrawTextOverlay(text As String)
        Dim fontHeight As Integer = OverlayFont.Height
        'Draw the overlay.
        Using textBrush As New SolidBrush(Color.FromArgb(180, Not BackColor.R, Not BackColor.G, Not BackColor.B))
            Using g As Graphics = Graphics.FromHwnd(Me.Handle)
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                g.DrawString(text, OverlayFont, textBrush, New Point(2, Me.ClientRectangle.Height - 2 - fontHeight))
            End Using
        End Using
    End Sub

    Private mWatermarkFont As New Font(FontFamily.GenericMonospace, 46)
    Public Sub DrawWatermark(text As String)
        Dim mWatermarkFont As New Font(FontFamily.GenericMonospace, 46)
        Dim fontHeight As Integer = mWatermarkFont.Height
        'Draw the overlay.
        Using textBrush As New SolidBrush(Color.FromArgb(50, Not BackColor.R, Not BackColor.G, Not BackColor.B))
            Using g As Graphics = Graphics.FromHwnd(Handle)
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                Dim mp As New Point(2, Me.ClientRectangle.Height - 2 - fontHeight)
                g.DrawString(text, mWatermarkFont, textBrush, mp)
            End Using
        End Using
    End Sub
    Public Sub DrawGridToGraphics()
        Dim mWatermarkFont As New Font(FontFamily.GenericMonospace, 46)
        Dim fontHeight As Integer = mWatermarkFont.Height
        'Draw the overlay.
        Using textBrush As New SolidBrush(Color.FromArgb(50, Not BackColor.R, Not BackColor.G, Not BackColor.B))
            Using g As Graphics = Graphics.FromHwnd(Handle)
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                Dim mp As New Point(2, Me.ClientRectangle.Height - 2 - fontHeight)
                g.DrawString(Text, mWatermarkFont, textBrush, mp)
            End Using
        End Using
    End Sub
    Public Function MotionBlockFromSelection() As clsMotionRecord
        Return AllMotionRecords(mDisplayLists2D(mDisplayLists2DSelectionIndices(0)).MotionIndex)
    End Function

    Private Sub DrawKeyPointsOverlay()
        Try

            'Draw the entire buffer first
            If Not (mGfxBuff Is Nothing) Then
                mGfxBuff.Render()
            End If
            Using g As Graphics = Graphics.FromHwnd(Me.Handle)
                With g
                    .PageUnit = GraphicsUnit.Inch
                    .ResetTransform()
                    .MultiplyTransform(mMtxDraw)
                    .SmoothingMode = SmoothingMode.HighQuality

                    If ViewManipMode = ManipMode.SETROTATE And mDisplayLists3D.CanDrawTarget Then
                        DrawRotateTargetToGraphics(g, Get2dFrom3D(mDisplayLists3D.PointOnKeypoint3D))
                    End If

                    If (ViewManipMode = ManipMode.MEASURE) Then
                        DrawKeypointIndicator(g)
                        DrawMeasurementToGraphics(g)
                    End If

                End With
            End Using
            mCurPen.EndCap = Nothing
        Catch ex As Exception
            Debug.Assert(1 = 0, "DrawSelectionOverlay")
        End Try

    End Sub

    Private Sub DrawGraphicsOverlay(Indices As List(Of Integer), selIndex As Integer)
        Dim p As clsDisplayList2D
        If Not Visible Then Return
        If mDisplayLists2D.Count = 0 Then Return
        Try

            'Draw the entire buffer first
            If Not (mGfxBuff Is Nothing) Then
                mGfxBuff.Render()
            End If
            Using g As Graphics = Graphics.FromHwnd(Me.Handle)
                With g
                    '.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                    .PageUnit = GraphicsUnit.Inch
                    .ResetTransform()
                    .MultiplyTransform(mMtxDraw)
                    .SmoothingMode = SmoothingMode.HighQuality

                    If mSelectionHits.Count = 1 Then
                        If (mSelectionHits(0).MotionType = Motion.CCARC Or mSelectionHits(0).MotionType = Motion.CWARC) Then
                            DrawArcCenterExtensions(g, mSelectionHits(0))
                        End If

                    End If

                    'Draw the selection overlay.
                    mCurPen.Width = ((1 / mGfx.DpiX) / mScaleToReal) * 4
                    If selIndex > -1 Then
                        p = mDisplayLists2D(Indices(selIndex))
                        If SelectionColor.IsEmpty Then
                            mCurPen.Color = p.Color
                        Else
                            mCurPen.Color = SelectionColor
                        End If
                        mCurPen.EndCap = LineCap.ArrowAnchor
                        mCurPen.DashStyle = p.DashStyle
                        .DrawLines(mCurPen, p.Points2d)
                    Else
                        Dim ct As Integer = mDisplayLists2D.Count
                        For Each i As Integer In Indices
                            If i >= ct Then
                                Continue For
                            End If

                            p = mDisplayLists2D(i)

                            If SelectionColor.IsEmpty Then
                                mCurPen.Color = p.Color
                            Else
                                mCurPen.Color = SelectionColor
                            End If

                            mCurPen.EndCap = LineCap.ArrowAnchor
                            mCurPen.DashStyle = p.DashStyle
                            .DrawLines(mCurPen, p.Points2d)

                        Next
                    End If
                    If (ViewManipMode = ManipMode.MEASURE) Then
                        DrawKeypointIndicator(g)
                        DrawMeasurementToGraphics(g)
                    End If

                End With
            End Using
            mCurPen.EndCap = Nothing
        Catch ex As Exception
            Debug.Assert(1 = 0, "DrawSelectionOverlay")
        End Try

    End Sub

    Private Sub MG_BasicViewer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
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
        If Not Me.Visible Then Return

        SetDrawDelegates(enDrawMethod.DRAW)

        Using ms As New IO.MemoryStream(My.Resources.SelectOne)
            mSelectCursor = New Cursor(ms)
        End Using
        Using ms As New IO.MemoryStream(My.Resources.SelectEtc)
            mSelectEtcCursor = New Cursor(ms)
        End Using
        Using ms As New IO.MemoryStream(My.Resources.SetRotate)
            mSetRotateCursor = New Cursor(ms)
        End Using
        Using ms As New IO.MemoryStream(My.Resources.Measure)
            mMeasureCursor = New Cursor(ms)
        End Using
        Using ms As New IO.MemoryStream(My.Resources.MeasureKeypoint)
            mMeasureKeypointCursor = New Cursor(ms)
        End Using

        mCancelSlowDisplayList = False
        mAllowSlowDisplayList = False

        'Window is just warming up so get out because this causes a slow condition
        If ClientRectangle.Height < 10 Or ClientRectangle.Width < 10 Then Return

        mExtentLongest = 100
        'If mWcsDisplayLists.Count = 0 Then
        'CreateWcs()
        'End If
        SetBufferContext()
        mClientRect = ClientRectangle
        mSelectionHits.Clear()
        ArcSegmentCount = 16
        If Me.mDisplayLists2D.Count = 0 Then
            WindowViewport(-2.0F, -2.0F, 2.0F, 2.0F)
            If SetViewMatrix2D() Then
                DrawWcsOnlyToBuffer()
            End If
        Else
            CreateDisplayListsAndDraw()
        End If
        isInitialized = True
    End Sub

    Private Sub MG_BasicViewer_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Not Me.Disposing Then Init()
    End Sub

    Private Function ArcLength(Xe As Single, Xs As Single,
Ye As Single, Ys As Single,
Ze As Single, Zs As Single,
r As Single, ByRef Startang As Single, ByRef Endang As Single, ByRef Wplane As Integer) As Single

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

        If AllMotionRecords.Count = 0 Then Return
        If mRangeEnd > AllMotionRecords.Count Then
            mRangeEnd = AllMotionRecords.Count - 1
        End If

        Dim isCutting = Function(mr As clsMotionRecord)
                            Return mr.MotionType = Motion.LINE OrElse
                                    mr.MotionType = Motion.CCARC OrElse
                                    mr.MotionType = Motion.CWARC OrElse
                                    mr.MotionType = Motion.HOLE_I OrElse
                                    mr.MotionType = Motion.HOLE_R
                        End Function

        ArcSegmentCount = 36
        For mMotRecIdx = mRangeStart To mRangeEnd
            mCurMotionRec = AllMotionRecords(mMotRecIdx)
            If isCutting(mCurMotionRec) AndAlso mCurMotionRec.FeedRate = 0 Then
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

        CalculateMotionRecordLength(mCurMotionRec)

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
                Case MachineType.MILL
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
                Case MachineType.LATHEDIA, MachineType.LATHERAD

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
                                            cutTime = LatheCutTimeBySFPM(.XYZold.X, .XYZpos.X, .XYZpos.Z - .XYZold.Z, feedrate, .Speed, .MaxRpm, MachineType, .FeedMode)
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
                        arcTime += LatheCutTimeBySFPM(.XYZold.X, .XYZpos.X, .XYZpos.Y - .XYZold.Y, .FeedRate, .Speed, .MaxRpm, MachineType, .FeedMode)
                    Next s
                Case Motion.XZ_PLN
                    For s = 1 To sngSegments
                        arcTime += LatheCutTimeBySFPM(.XYZold.X, .XYZpos.X, .XYZpos.Z - .XYZold.Z, .FeedRate, .Speed, .MaxRpm, MachineType, .FeedMode)
                    Next s

                Case Motion.YZ_PLN
                    For s = 1 To sngSegments
                        arcTime += LatheCutTimeBySFPM(.XYZold.Y, .XYZpos.Y, .XYZpos.Z - .XYZold.Z, .FeedRate, .Speed, .MaxRpm, MachineType, .FeedMode)
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
    Private Function LatheCutTimeBySFPM(od As Single, id As Single,
zDist As Single,
feed As Single,
speed As Single,
maxRPM As Single,
machineType As MachineType,
feedMode As FeedMode) As Double
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
        If machineType = MachineType.LATHERAD Then
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
        mCurMotionRec.RPM = rpmOd

        If od = id Then 'Const rpm
            If zDist = 0 Then Return 0
            travel = Math.Abs(zDist)
            If feedMode = FeedMode.UNIT_PER_MIN Then
                Return travel * feed
            Else
                Return (travel / feed) / rpmOd
            End If
        Else '\ Variable rpm
            travel = Math.Sqrt(((od - id) ^ 2) + (zDist ^ 2))
        End If

        'Feed per minute requires no further calculations
        If feedMode = FeedMode.UNIT_PER_MIN Then
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

    Private Sub CalculateMotionRecordLength(mr As clsMotionRecord)
        Dim xleg1, yleg1, zleg1, xleg2, yleg2, zleg2 As Single

        Select Case mr.MotionType
            Case Motion.RAPID
                If mr.Rotate Then
                    CalculateLengthOfRotaryArc(mr, mr.XYZpos.X, mr.XYZold.X, mr.XYZpos.Y, mr.XYZold.Y, mr.XYZpos.Z, mr.XYZold.Z, mr.OldRotaryPos, mr.NewRotaryPos, mr.RotaryDir)
                Else
                    If mDrawDogLeg Then
                        CalculateDogLegMotion(xleg1, yleg1, zleg1, xleg2, yleg2, zleg2)
                        mr.RapidLength = VectorLength(mr.XYZold.X, mr.XYZold.Y, mr.XYZold.Z, xleg1, yleg1, zleg1)
                        mr.RapidLength += VectorLength(xleg1, yleg1, zleg1, xleg2, yleg2, zleg2)
                        mr.RapidLength += VectorLength(xleg2, yleg2, zleg2, mr.XYZpos.X, mr.XYZpos.Y, mr.XYZpos.Z)
                    End If
                    mr.RapidLength = VectorLength(mr.XYZold.X, mr.XYZold.Y, mr.XYZold.Z, mr.XYZpos.X, mr.XYZpos.Y, mr.XYZpos.Z)
                End If

            Case Motion.HOLE_I, Motion.HOLE_R
                If DrawRapidLines Then
                    CalculateDogLegMotion(xleg1, yleg1, zleg1, xleg2, yleg2, zleg2)

                    'A rotary move is on the drill cycle line
                    If mr.Rotate Then
                        If mr.MotionType = Motion.HOLE_I Then 'Return to inital Z
                            CalculateLengthOfRotaryArc(mr, mr.XYZpos.X, mr.XYZold.X, mr.XYZpos.Y, mr.XYZold.Y, mr.DrillClear, mr.DrillClear, mr.OldRotaryPos, mr.NewRotaryPos, mr.RotaryDir)
                        Else
                            CalculateLengthOfRotaryArc(mr, mr.XYZpos.X, mr.XYZold.X, mr.XYZpos.Y, mr.XYZold.Y, mr.Rpoint, mr.Rpoint, mr.OldRotaryPos, mr.NewRotaryPos, mr.RotaryDir)
                        End If
                    Else
                        mr.RapidLength = VectorLength(mr.XYZold.X, mr.XYZold.Y, mr.XYZold.Z, xleg1, yleg1, mr.Rpoint)
                        mr.RapidLength += VectorLength(xleg1, yleg1, mr.Rpoint, mr.XYZpos.X, mr.XYZpos.Y, mr.Rpoint)
                    End If
                End If

                mr.CuttingLength = VectorLength(mr.XYZpos.X, mr.XYZpos.Y, mr.Rpoint, mr.XYZpos.X, mr.XYZpos.Y, mr.XYZpos.Z)
                mr.RapidLength += VectorLength(mr.XYZpos.X, mr.XYZpos.Y, mr.DrillClear, mr.XYZpos.X, mr.XYZpos.Y, mr.XYZpos.Z)

            Case Motion.LINE
                If mr.Rotate Then
                    CalculateLengthOfRotaryArc(mr, mr.XYZpos.X, mr.XYZold.X, mr.XYZpos.Y, mr.XYZold.Y, mr.XYZpos.Z, mr.XYZold.Z, mr.OldRotaryPos, mr.NewRotaryPos, mr.RotaryDir)
                Else
                    mr.CuttingLength = VectorLength(mr.XYZold.X, mr.XYZold.Y, mr.XYZold.Z, mr.XYZpos.X, mr.XYZpos.Y, mr.XYZpos.Z)
                End If
            Case Motion.CCARC, Motion.CWARC
                mr.CuttingLength = ArcLength(mr.XYZpos.X, mr.XYZold.X, mr.XYZpos.Y, mr.XYZold.Y, mr.XYZpos.Z, mr.XYZold.Z, mr.Rad, mr.Sang, mr.Eang, mr.ArcPlane)
        End Select
    End Sub

    Private Sub CalculateLengthOfRotaryArc(mr As clsMotionRecord, Xe As Single, Xs As Single, Ye As Single, Ys As Single, Ze As Single, Zs As Single, Startang As Single, Endang As Single, ArcDir As Single)
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
            Case ArcAxis.X  'X
                If mr.MotionType = Motion.RAPID Then
                    mr.RapidLength = (Math.Abs(Xe - Xs) + ((Math.Abs(totalAngle) / ONE_RADIAN) * (radFromAxis * 2 * PI_S)))
                Else
                    mr.CuttingLength = (Math.Abs(Xe - Xs) + ((Math.Abs(totalAngle) / ONE_RADIAN) * (radFromAxis * 2 * PI_S)))
                End If

            Case ArcAxis.Y
                If mr.MotionType = Motion.RAPID Then
                    mr.RapidLength = (Math.Abs(Ye - Ys) + ((Math.Abs(totalAngle) / ONE_RADIAN) * (radFromAxis * 2 * PI_S)))
                Else
                    mr.CuttingLength = (Math.Abs(Ye - Ys) + ((Math.Abs(totalAngle) / ONE_RADIAN) * (radFromAxis * 2 * PI_S)))
                End If
            Case ArcAxis.Z
                'Not implemented
        End Select
    End Sub

#End Region

#Region "Graphics"
    Private Sub PolyArcDraw(Xctr As Single, Yctr As Single, Zctr As Single,
                            Xe As Single, Xs As Single,
                            Ye As Single, Ys As Single,
                            Ze As Single, Zs As Single,
                            r As Single,
                            Startang As Single,
                            Endang As Single,
                            ArcDir As Integer,
                            Wplane As Integer)
        If mViewRect.Width = 0 Then Return

        Dim s As Integer 'counter
        Dim sngSegments As Integer ' number of angular segments
        Dim helixSeg As Single
        Dim sngAngle As Single
        Dim sngTotalAngle As Single
        Dim circumference As Single = PI_S * (r * 2)
        sngTotalAngle = Math.Abs(Startang - Endang)
        Dim circLen As Single = circumference * (sngTotalAngle / ONE_RADIAN)
        'I need a ratio between the size of the screen and the length of the arc
        Dim ratioBetweenArcLenAndScreenSize = (circLen / (mViewRect.Width / mMasterGfxAdjustScale))
        '1 to 1 would = mArcQuality
        If mAllMotionRecords.Count < 5000 AndAlso ratioBetweenArcLenAndScreenSize < 1 Then
            ratioBetweenArcLenAndScreenSize = 1
        End If
        Dim circSegs = CInt(ratioBetweenArcLenAndScreenSize * mArcSegCount)
        'sngSegments = CInt(Int(sngTotalAngle / mSegAngle))
        sngSegments = circSegs

        'Re-calculate angle increment
        sngAngle = (ArcDir * (sngTotalAngle / sngSegments))

        LineEnd3D(Xs, Ys, Zs)
        mPoints2D.Clear()
        Select Case Wplane
            Case Motion.XY_PLN
                helixSeg = (Ze - Zs) / sngSegments
                For s = 1 To sngSegments
                    LineEnd3D(Xctr + (r * Math.Cos((s * sngAngle) + Startang)), (Yctr + (r * Math.Sin((s * sngAngle) + Startang))), Zs + helixSeg * s)
                Next s
            Case Motion.XZ_PLN
                helixSeg = (Ye - Ys) / sngSegments
                For s = 1 To sngSegments
                    LineEnd3D(Xctr + (r * Math.Cos((s * sngAngle) + Startang)), Ys + (helixSeg * s), Zctr + (r * Math.Sin((s * sngAngle) + Startang)))
                Next s

            Case Motion.YZ_PLN
                helixSeg = (Xe - Xs) / sngSegments
                For s = 1 To sngSegments
                    LineEnd3D(Xs + (helixSeg * s), Yctr + (r * Math.Cos((s * sngAngle) + Startang)), Zctr + (r * Math.Sin((s * sngAngle) + Startang)))
                Next s

        End Select
        LineEnd3D(Xe, Ye, Ze)
    End Sub
    Private Sub PolyArcDXF(Xctr As Single, Yctr As Single,
                            Zctr As Single, Xe As Single,
                            Xs As Single, Ye As Single,
                            Ys As Single, Ze As Single,
                            Zs As Single, r As Single,
                            Startang As Single,
                            Endang As Single,
                            ArcDir As Integer,
                            Wplane As Integer)

        Dim sngSegments As Integer ' number of angular segments
        Dim helixSeg As Single
        Dim sngAngle As Single
        Dim sngTotalAngle As Single
        Dim circumference As Single = PI_S * (r * 2)
        sngTotalAngle = Math.Abs(Startang - Endang)
        Dim circLen As Single = circumference * (sngTotalAngle / ONE_RADIAN)
        sngSegments = CInt(Int(sngTotalAngle / mSegAngle))
        Dim dxfKey As String = String.Empty

        Dim circ As Boolean = Math.Abs(sngTotalAngle - ONE_RADIAN) < 0.00001
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
        Dim ep = Vector3.Transform(New Vector3(Xe, Ye, Ze), mViewMatrix)
        Dim ctr = Vector3.Transform(New Vector3(Xctr, Yctr, Zctr), mViewMatrix)

        'Re-calculate angle increment
        sngAngle = (ArcDir * (sngTotalAngle / sngSegments))
        LineEnd3D(Xs, Ys, Zs)
        mPoints2D.Clear()
        Select Case Wplane
            Case Motion.XY_PLN
                helixSeg = (Ze - Zs) / sngSegments
                Output_DXF_Section(dxfKey, xOld, yOld, zOld, ep.X, ep.Y, ep.Z, ctr.X, ctr.Y, ctr.Z)
            Case Motion.XZ_PLN
            Case Motion.YZ_PLN
        End Select
        xOld = ep.X
        yOld = ep.Y
        zOld = ep.Z
    End Sub
    Private Sub DrawRotaryArc(Xe As Single, Xs As Single, Ye As Single, Ys As Single, Ze As Single, Zs As Single, Startang As Single, Endang As Single, ArcDir As Single)
        Dim s As Integer 'counter
        Dim rotSegs As Integer ' number of angular segments
        Dim axisSeg1, axisSeg3, totalAngle, radFromAxis As Single
        FourthAxis = 0!
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
            Case ArcAxis.X  'X
                Startang = (Startang + AngleFromPoint(Zs, Ys, False) * RotaryDirection) * RotaryDirection
                Endang = (Endang + AngleFromPoint(Zs, Ys, False) * RotaryDirection) * RotaryDirection

                'Re-calculate angle increment
                Dim angle = (totalAngle / rotSegs) * RotaryDirection
                axisSeg1 = (Xe - Xs) / rotSegs
                axisSeg3 = (Ze - Zs) / rotSegs

                radFromAxis = VectorLength(0, Ys, Zs, 0, 0, 0)
                LineEnd3D(Xs, (radFromAxis * Math.Sin(Startang)), (radFromAxis * Math.Cos(Startang)))
                mPoints2D.Clear()
                For s = 1 To rotSegs
                    radFromAxis = VectorLength(0, Ys, Zs + (axisSeg3 * s), 0, 0, 0)
                    LineEnd3D(Xs + (axisSeg1 * s), (radFromAxis * Math.Sin((s * angle) + Startang)), (radFromAxis * Math.Cos((s * angle) + Startang)))
                Next s
            Case ArcAxis.Y
                Startang = (Startang - AngleFromPoint(Zs, Xs, False) * RotaryDirection) * -RotaryDirection
                Endang = (Endang - AngleFromPoint(Zs, Xs, False) * RotaryDirection) * -RotaryDirection

                'Re-calculate angle increment
                Dim angle = (totalAngle / rotSegs) * -RotaryDirection
                axisSeg1 = (Ye - Ys) / rotSegs
                axisSeg3 = (Ze - Zs) / rotSegs
                radFromAxis = VectorLength(Xs, 0, Zs, 0, 0, 0)
                LineEnd3D((radFromAxis * Math.Sin(Startang)), Ys, (radFromAxis * Math.Cos(Startang)))
                mPoints2D.Clear()
                For s = 1 To rotSegs
                    radFromAxis = VectorLength(Xs, 0, Zs + (axisSeg3 * s), 0, 0, 0)
                    LineEnd3D((radFromAxis * Math.Sin((s * angle) + Startang)), Ys + (axisSeg1 * s), (radFromAxis * Math.Cos((s * angle) + Startang)))
                Next s
            Case ArcAxis.Z
                'Not implemented
        End Select
        'Here we set the new model matrix
        FourthAxis = mCurMotionRec.NewRotaryPos
        LineEnd3D(Xe, Ye, Ze)
    End Sub

    Private Sub LineScaled3D(Xs As Single, Ys As Single, Zs As Single, Xe As Single, Ye As Single, Ze As Single, scale As Single)
        Xs *= scale
        Ys *= scale
        Zs *= scale
        Xe *= scale
        Ye *= scale
        Ze *= scale
        Line3D(Xs, Ys, Zs, Xe, Ye, Ze)
    End Sub



    Private Sub DrawSinglePoint3D(Xe As Single, Ye As Single, Ze As Single, Optional prescale As Single = 0)
        Xe *= mMasterGfxAdjustScale
        Ye *= mMasterGfxAdjustScale
        Ze *= mMasterGfxAdjustScale
        Dim ep = Vector3.Transform(New Vector3(Xe, Ye, Ze), mViewMatrix)
        mPoints2D.Add(New PointF(ep.X, ep.Y))
        mLastPos.X = ep.X
        mLastPos.Y = ep.Y
        xOld = ep.X
        yOld = ep.Y
        zOld = ep.Z
    End Sub

    Private Function Get2dFrom3D(input As Vector3) As PointF
        Dim ep = Vector3.Transform(input, mViewMatrix)
        Return New PointF(ep.X, ep.Y)
    End Function

    Public Shared Function VectorLength(X1 As Double, Y1 As Double, Z1 As Double, x2 As Double, y2 As Double, Z2 As Double) As Double
        Return (Math.Sqrt(((X1 - x2) ^ 2) + ((Y1 - y2) ^ 2) + ((Z1 - Z2) ^ 2)))
    End Function

    Public Shared Function AngleFromPoint(x As Double, y As Double, deg As Boolean) As Single
        Dim theta As Double
        If x > 0 AndAlso y > 0 Then ' Quadrant 1
            theta = (Math.Atan(y / x))
        ElseIf x < 0 AndAlso y > 0 Then  ' Quadrant 2
            theta = (Math.Atan(y / x) + Math.PI)
        ElseIf x < 0 AndAlso y < 0 Then  ' Quadrant 3
            theta = (Math.Atan(y / x) + Math.PI)
        ElseIf x > 0 AndAlso y < 0 Then  ' Quadrant 4
            theta = (Math.Atan(y / x) + 2 * Math.PI)
        End If

        ' Exceptions for points landing on an axis
        If x > 0 AndAlso y = 0 Then '0
            theta = 0
        ElseIf x = 0 AndAlso y > 0 Then  '90
            theta = QUARTER_RADIAN
        ElseIf x < 0 AndAlso y = 0 Then  '180
            theta = Math.PI
        ElseIf x = 0 AndAlso y < 0 Then  '270
            theta = 3 * (QUARTER_RADIAN)
        End If

        ' if you want the angle in degrees use this conversion
        If deg Then
            theta = (theta * (180.0 / Math.PI))
        End If
        Return theta

    End Function



#Region "DXF"
    Public Sub SaveAsDXF(templateFile As String, dxfOutFile As String)
        mDxfOutFile = dxfOutFile
        '(?<SEC>@.[^@]*)
        '(?<WORD>\[.[^\[]*\])
        Dim sectionMatches As New Text.RegularExpressions.Regex("@.[^@]*", System.Text.RegularExpressions.RegexOptions.Singleline)
        Dim templateContents As String = IO.File.ReadAllText(templateFile)
        Dim sec As Text.RegularExpressions.Match = sectionMatches.Match(templateContents)
        Dim key As String
        Dim secName As String
        Dim secContents As String
        mSectionsDXF = New Dictionary(Of String, String)
        While sec.Success
            With sec
                secName = sec.Value.Substring(0, sec.Value.IndexOf(vbCrLf)).Trim
                secContents = sec.Value.Substring(sec.Value.IndexOf(vbCrLf) + 2).ToUpper
                mSectionsDXF.Add(secName, secContents)
                sec = .NextMatch
            End With
        End While

        'mSavingDXF = True
        SetDrawDelegates(enDrawMethod.DXF)

        IO.File.WriteAllText(mDxfOutFile, String.Empty)
        key = "@START"
        Output_DXF_Section(key, 0, 0, 0, 0, 0, 0)

        CreateDisplayListsFromMotionRecords()

        key = "@END"
        Output_DXF_Section(key, 0, 0, 0, 0, 0, 0)
        SetDrawDelegates(enDrawMethod.DRAW)
        'mSavingDXF = False
        mSectionsDXF.Clear()
        mSectionsDXF = Nothing
        'Process end
    End Sub

    Private Sub Output_DXF_Section(key As String)
        Output_DXF_Section(key, mCurMotionRec.XYZold.X, mCurMotionRec.XYZold.Y, mCurMotionRec.XYZold.Z, mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Z)
    End Sub

    Private Sub Output_DXF_Section(key As String, Xs As Single, Ys As Single, Zs As Single,
                                   Xe As Single, Ye As Single, Ze As Single,
                                   Optional Xc As Single = 0, Optional Yc As Single = 0, Optional Zc As Single = 0)
        Dim words As New Text.RegularExpressions.Regex("\[.[^\[]*\]", System.Text.RegularExpressions.RegexOptions.Singleline)
        Dim retSec As String
        Dim rawSec As String
        If mSectionsDXF.ContainsKey(key) Then
            rawSec = mSectionsDXF(key)
            retSec = rawSec
            Dim wrd As Text.RegularExpressions.Match = words.Match(rawSec)
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
                            retSec = retSec.Replace("[ZOLD]", Format(Zs, "##0.0###"))
                        Case "[SANG]"
                            Dim sang = (mCurMotionRec.Sang * (180.0 / Math.PI))
                            retSec = retSec.Replace("[SANG]", Format(sang, "##0.0###"))
                        Case "[EANG]"
                            Dim eang = (mCurMotionRec.Eang * (180.0 / Math.PI))
                            retSec = retSec.Replace("[EANG]", Format(eang, "##0.0###"))
                        Case "[RAD]"
                            retSec = retSec.Replace("[RAD]", Format(mCurMotionRec.Rad, "##0.0###"))
                        Case "[XCENTR]"
                            retSec = retSec.Replace("[XCENTR]", Format(Xc, "##0.0###"))
                        Case "[YCENTR]"
                            retSec = retSec.Replace("[YCENTR]", Format(Yc, "##0.0###"))
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

    Private Function CalculateDogLegMotion(ByRef xleg1 As Single,
                                                          ByRef yleg1 As Single,
                                                          ByRef zleg1 As Single,
                                                          ByRef xleg2 As Single,
                                                          ByRef yleg2 As Single,
                                                          ByRef zleg2 As Single) As Integer

        Dim xleg, yleg, zleg As Single
        Dim xdir, ydir, zdir As Integer
        xdir = Math.Sign(mCurMotionRec.XYZpos.X - mCurMotionRec.XYZold.X)
        ydir = Math.Sign(mCurMotionRec.XYZpos.Y - mCurMotionRec.XYZold.Y)
        zdir = Math.Sign(mCurMotionRec.XYZpos.Z - mCurMotionRec.XYZold.Z)

        xleg = Math.Abs(mCurMotionRec.XYZpos.X - mCurMotionRec.XYZold.X)
        yleg = Math.Abs(mCurMotionRec.XYZpos.Y - mCurMotionRec.XYZold.Y)
        zleg = Math.Abs(mCurMotionRec.XYZpos.Z - mCurMotionRec.XYZold.Z)
        If xleg <= yleg AndAlso yleg <= zleg Then 'Long Z
            xleg1 = mCurMotionRec.XYZpos.X
            yleg1 = mCurMotionRec.XYZold.Y + xleg * ydir
            zleg1 = mCurMotionRec.XYZold.Z + xleg * zdir
            xleg2 = mCurMotionRec.XYZpos.X
            yleg2 = mCurMotionRec.XYZpos.Y
            zleg2 = mCurMotionRec.XYZold.Z + yleg * zdir
        ElseIf xleg <= zleg AndAlso zleg <= yleg Then
            xleg1 = mCurMotionRec.XYZpos.X
            yleg1 = mCurMotionRec.XYZold.Y + xleg * ydir
            zleg1 = mCurMotionRec.XYZold.Z + xleg * zdir
            xleg2 = mCurMotionRec.XYZpos.X
            yleg2 = mCurMotionRec.XYZold.Y + zleg * ydir
            zleg2 = mCurMotionRec.XYZpos.Z
        ElseIf zleg <= yleg AndAlso yleg <= xleg Then
            xleg1 = mCurMotionRec.XYZold.X + zleg * xdir
            yleg1 = mCurMotionRec.XYZold.Y + zleg * ydir
            zleg1 = mCurMotionRec.XYZpos.Z
            xleg2 = mCurMotionRec.XYZold.X + yleg * xdir
            yleg2 = mCurMotionRec.XYZpos.Y
            zleg2 = mCurMotionRec.XYZpos.Z
        ElseIf zleg <= xleg AndAlso xleg <= yleg Then
            xleg1 = mCurMotionRec.XYZold.X + zleg * xdir
            yleg1 = mCurMotionRec.XYZold.Y + zleg * ydir
            zleg1 = mCurMotionRec.XYZpos.Z
            xleg2 = mCurMotionRec.XYZpos.X
            yleg2 = mCurMotionRec.XYZold.Y + xleg * ydir
            zleg2 = mCurMotionRec.XYZpos.Z
        ElseIf yleg <= zleg AndAlso zleg <= xleg Then
            xleg1 = mCurMotionRec.XYZold.X + yleg * xdir
            yleg1 = mCurMotionRec.XYZpos.Y
            zleg1 = mCurMotionRec.XYZold.Z + yleg * zdir
            xleg2 = mCurMotionRec.XYZold.X + zleg * xdir
            yleg2 = mCurMotionRec.XYZpos.Y
            zleg2 = mCurMotionRec.XYZpos.Z
        ElseIf yleg <= xleg AndAlso xleg <= zleg Then
            xleg1 = mCurMotionRec.XYZold.X + yleg * xdir
            yleg1 = mCurMotionRec.XYZpos.Y
            zleg1 = mCurMotionRec.XYZold.Z + yleg * zdir
            xleg2 = mCurMotionRec.XYZpos.X
            yleg2 = mCurMotionRec.XYZpos.Y
            zleg2 = mCurMotionRec.XYZold.Z + xleg * zdir
        End If
    End Function


    Private Sub DrawMotionRecord()
        Dim xleg1, yleg1, zleg1, xleg2, yleg2, zleg2 As Single
        'Create a display list using any existing points
        Dim toolLayer As clsToolLayer = Nothing

        'if the z is filtered then do not draw and clear the points
        If mCurMotionRec.FilterZ Then
            mPoints2D.Clear()
            Return
        End If

        If DrawMotionWithDefaultColor Then
            mCurMotionRec.DrawColor = MotionColor_Default
        Else
            'Create a display list using any existing points
            If ToolLayers.TryGetValue(mCurMotionRec.Tool, toolLayer) Then
                'If we change the tool color we need to make sure we set the tool layer.
                If Not MotionColorByMotionType Then
                    mCurMotionRec.DrawColor = toolLayer.Color
                End If
                If toolLayer.Hidden Then
                    LineEnd3D(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Z)
                    mPoints2D.Clear()
                    Return
                End If
            End If
        End If


        If mCurMotionRec.Rotate Then
            ArcSegmentCount = CInt(Int((mCurMotionRec.XYZpos.Z / mLongside) * 90) * mArcQuality)
        End If

        Select Case mCurMotionRec.MotionType
            Case Motion.RAPID
                mCurMotionColor = MotionColor_Rapid

                If mCurMotionRec.Rotate Then
                    If DrawRapidLines Then
                        DrawRotaryArc(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZold.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZold.Y, mCurMotionRec.XYZpos.Z, mCurMotionRec.XYZold.Z, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                    Else
                        FourthAxis = mCurMotionRec.NewRotaryPos
                        DrawSinglePoint3D(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Z)
                    End If
                Else
                    If DrawRapidLines Then
                        Line3D(mCurMotionRec.XYZold.X, mCurMotionRec.XYZold.Y, mCurMotionRec.XYZold.Z, mCurMotionRec.XYZold.X, mCurMotionRec.XYZold.Y, mCurMotionRec.XYZold.Z)
                        If mDrawDogLeg Then
                            CalculateDogLegMotion(xleg1, yleg1, zleg1, xleg2, yleg2, zleg2)
                            LineEnd3D(xleg1, yleg1, zleg1)
                            LineEnd3D(xleg2, yleg2, zleg2)
                        End If
                        LineEnd3D(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Z)
                    End If
                End If

                CreateDisplayListItem(DashStyle.Dash) 'Draw any existing lines
                'Draw a rapid blip if required
                If DrawRapidPoints Then
                    'Set the last point
                    LineEnd3D(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Z)
                    DrawBlip(mLastPos)
                    CreateDisplayListItem(DashStyle.Solid, False)
                End If


            Case Motion.HOLE_I, Motion.HOLE_R
                If DrawRapidLines Then
                    mCurMotionColor = MotionColor_Rapid
                    If mDrawDogLeg Then
                        CalculateDogLegMotion(xleg1, yleg1, zleg1, xleg2, yleg2, zleg2)
                    End If

                    'A rotary move is on the drill cycle line
                    If mCurMotionRec.Rotate Then
                        If mCurMotionRec.MotionType = Motion.HOLE_I Then 'Return to inital Z
                            DrawRotaryArc(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZold.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZold.Y, mCurMotionRec.DrillClear, mCurMotionRec.DrillClear, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                        Else
                            DrawRotaryArc(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZold.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZold.Y, mCurMotionRec.Rpoint, mCurMotionRec.Rpoint, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                        End If
                        LineEnd3D(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.Rpoint)
                    Else

                        'hole positioning
                        If mCurMotionRec.MotionType = Motion.HOLE_I Then 'Return to inital Z
                            Line3D(mCurMotionRec.XYZold.X, mCurMotionRec.XYZold.Y, mCurMotionRec.XYZold.Z, mCurMotionRec.XYZold.X, mCurMotionRec.XYZold.Y, mCurMotionRec.DrillClear)
                            If mDrawDogLeg Then
                                LineEnd3D(xleg2, yleg2, mCurMotionRec.DrillClear)
                            End If
                            LineEnd3D(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.DrillClear)
                            LineEnd3D(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.Rpoint)
                        Else
                            Line3D(mCurMotionRec.XYZold.X, mCurMotionRec.XYZold.Y, mCurMotionRec.XYZold.Z, mCurMotionRec.XYZold.X, mCurMotionRec.XYZold.Y, mCurMotionRec.DrillClear)
                            If mDrawDogLeg Then
                                LineEnd3D(xleg2, yleg2, mCurMotionRec.Rpoint)
                            End If
                            LineEnd3D(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.Rpoint)
                        End If
                    End If
                End If

                CreateDisplayListItem(DashStyle.Dash) 'Draw any existing lines
                'Draw the hole line
                mCurMotionColor = MotionColor_Line
                If DrawRapidPoints Then
                    LineEnd3D(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.Rpoint)
                    DrawBlipTriangle(mLastPos)
                    CreateDisplayListItem(DashStyle.Solid, False)
                End If

                'Drilling from R point
                Line3D(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.Rpoint, mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Z)
                If DrawRapidPoints Then 'Draw a small circle
                    CreateDisplayListItem(DashStyle.Solid) 'Draw any existing lines
                    ArcSegmentCount = 8
                    Dim r = mBlipSize / mMasterGfxAdjustScale
                    DrawPolyArc(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Z,
                                                mCurMotionRec.XYZpos.X + r,
                                                mCurMotionRec.XYZpos.X + r,
                                                mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Y,
                                                mCurMotionRec.XYZpos.Z, mCurMotionRec.XYZpos.Z,
                                                r, 0, ONE_RADIAN, -1, mCurMotionRec.ArcPlane)
                End If

            Case Motion.LINE
                mCurMotionColor = MotionColor_Line
                If mCurMotionRec.Rotate Then
                    DrawRotaryArc(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZold.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZold.Y, mCurMotionRec.XYZpos.Z, mCurMotionRec.XYZold.Z, mCurMotionRec.OldRotaryPos, mCurMotionRec.NewRotaryPos, mCurMotionRec.RotaryDir)
                Else
                    Line3D(mCurMotionRec.XYZold.X, mCurMotionRec.XYZold.Y, mCurMotionRec.XYZold.Z, mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Z)
                End If
            Case Motion.CCARC
                mCurMotionColor = MotionColor_ArcCCW
                DrawPolyArc(mCurMotionRec.XYZcenter.X, mCurMotionRec.XYZcenter.Y, mCurMotionRec.XYZcenter.Z, mCurMotionRec.XYZpos.X, mCurMotionRec.XYZold.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZold.Y, mCurMotionRec.XYZpos.Z, mCurMotionRec.XYZold.Z, mCurMotionRec.Rad, mCurMotionRec.Sang, mCurMotionRec.Eang, 1, mCurMotionRec.ArcPlane)
            Case Motion.CWARC
                mCurMotionColor = MotionColor_ArcCW
                DrawPolyArc(mCurMotionRec.XYZcenter.X, mCurMotionRec.XYZcenter.Y, mCurMotionRec.XYZcenter.Z, mCurMotionRec.XYZpos.X, mCurMotionRec.XYZold.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZold.Y, mCurMotionRec.XYZpos.Z, mCurMotionRec.XYZold.Z, mCurMotionRec.Rad, mCurMotionRec.Sang, mCurMotionRec.Eang, -1, mCurMotionRec.ArcPlane)
        End Select

        CreateDisplayListItem(DashStyle.Solid)


        'Debug.Print("mDisplayLists.Count " & mDisplayLists.Count.ToString)
    End Sub

    'Draw un-rotated rectangle as a rapid point indication.   
    Private Sub DrawBlip(p As PointF)
        mPoints2D.Clear()
        With p
            Line2D(.X - mBlipSize, .Y - mBlipSize, .X + mBlipSize, .Y - mBlipSize)
            AddLineEndpoint(.X + mBlipSize, .Y + mBlipSize)
            AddLineEndpoint(.X - mBlipSize, .Y + mBlipSize)
            AddLineEndpoint(.X - mBlipSize, .Y - mBlipSize)
            AddLineEndpoint(.X, .Y)
        End With
    End Sub
    Private Sub DrawBlipTriangle(p As PointF)
        mPoints2D.Clear()
        With p
            Line2D(.X, .Y, .X + mBlipSize, .Y + mBlipSize)
            AddLineEndpoint(.X - mBlipSize, .Y + mBlipSize)
            AddLineEndpoint(.X, .Y)
        End With
    End Sub
    Public Overloads Sub Redraw(allSiblings As Boolean)
        If allSiblings AndAlso mAll_Siblings.Count > 0 Then
            For Each sib As MG_BasicViewer In MyNeighborhood
                If sib.Visible Then
                    sib.CreateDisplayListsAndDraw()
                End If
            Next
        Else
            CreateDisplayListsAndDraw()
        End If
    End Sub

    Private Shared mExtentX3d(1) As Single
    Private Shared mExtentY3d(1) As Single
    Private Shared mExtentZ3d(1) As Single
    Private Shared mExtentLongest As Single
    Public Sub CalculateToolpath3DExtents()

        'If Not Visible Then Return
        If AllMotionRecords.Count = 0 Then Return
        Const smallFloat As Single = 0.1

        mExtentX3d(0) = smallFloat
        mExtentX3d(1) = -smallFloat
        mExtentY3d(0) = smallFloat
        mExtentY3d(1) = -smallFloat
        mExtentZ3d(0) = smallFloat
        mExtentZ3d(1) = -smallFloat
        Dim tempMatrix = mViewMatrix

        mViewMatrix = Matrix44.Identity()
        mViewMatrix *= mRotaryMatrix

        SetDrawDelegates(enDrawMethod.INIT)
        mArcQuality = FIXED_FINE_QUALITY
        mDisplayLists3D.Init(mRotaryVector, RotaryDirection, mMasterGfxAdjustScale)

        CreateDisplayListsFromMotionRecords()

        For Each dl In mDisplayLists3D.DisplayList
            For Each ex In dl.VectorList3D
                mExtentX3d(0) = Math.Min(mExtentX3d(0), ex.X)
                mExtentX3d(1) = Math.Max(mExtentX3d(1), ex.X)
                mExtentY3d(0) = Math.Min(mExtentY3d(0), ex.Y)
                mExtentY3d(1) = Math.Max(mExtentY3d(1), ex.Y)
                mExtentZ3d(0) = Math.Min(mExtentZ3d(0), ex.Z)
                mExtentZ3d(1) = Math.Max(mExtentZ3d(1), ex.Z)
            Next
        Next
        'I need to examine the extents and adjust the 
        mExtentLongest = 0
        mExtentLongest = Math.Max(mExtentLongest, Math.Abs(mExtentX3d(0)))
        mExtentLongest = Math.Max(mExtentLongest, Math.Abs(mExtentX3d(1)))
        mExtentLongest = Math.Max(mExtentLongest, Math.Abs(mExtentY3d(0)))
        mExtentLongest = Math.Max(mExtentLongest, Math.Abs(mExtentY3d(1)))
        mExtentLongest = Math.Max(mExtentLongest, Math.Abs(mExtentZ3d(0)))
        mExtentLongest = Math.Max(mExtentLongest, Math.Abs(mExtentZ3d(1)))

        mExtentLongest = Math.Max(mExtentLongest, smallFloat)
        '/ mMasterGfxAdjustScale
        mExtentCenter.X = (mExtentX3d(0) + mExtentX3d(1)) / 2.0
        mExtentCenter.Y = (mExtentY3d(0) + mExtentY3d(1)) / 2.0
        mExtentCenter.Z = (mExtentZ3d(0) + mExtentZ3d(1)) / 2.0
        FourthAxis = 0
        mViewMatrix = tempMatrix 'Restore the matrix to the view after calculating

        mArcQuality = VARIABLE_QUALITY
        SetDrawDelegates(enDrawMethod.DRAW)
    End Sub

    Public Sub FindViewExtents()
        If Not Visible Then Return
        'If AllMotionRecords.Count = 0 Then Return
        Dim sw As New Stopwatch
        sw.Start()
        mExtentX(0) = -1.0F
        mExtentX(1) = 1.0F
        mExtentY(0) = -1.0F
        mExtentY(1) = 1.0F

        SetViewMatrix3D()

        CreateDisplayListsFromMotionRecords()

        CreateLimitsBox()

        For Each l As clsDisplayList2D In mLimitsDisplayLists
            For Each p As PointF In l.Points2d
                mExtentX(0) = Math.Min(mExtentX(0), p.X)
                mExtentX(1) = Math.Max(mExtentX(1), p.X)
                mExtentY(0) = Math.Min(mExtentY(0), p.Y)
                mExtentY(1) = Math.Max(mExtentY(1), p.Y)
            Next
        Next

        If AllMotionRecords.Count > 0 Then
            For Each l As clsDisplayList2D In mDisplayLists2D
                If l.Selectable Then
                    For Each p As PointF In l.Points2d
                        mExtentX(0) = Math.Min(mExtentX(0), p.X)
                        mExtentX(1) = Math.Max(mExtentX(1), p.X)
                        mExtentY(0) = Math.Min(mExtentY(0), p.Y)
                        mExtentY(1) = Math.Max(mExtentY(1), p.Y)
                    Next
                End If
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
            CreateGridInMachineUnits()
            If mExtentRectangle.Width < 0.0001 Then
                mExtentRectangle.Width = 0.001
            End If

            If mExtentRectangle.Height < 0.0001 Then
                mExtentRectangle.Height = 0.001
            End If
            mViewRect.Inflate(mExtentRectangle.Width * 0.01F, mViewRect.Height * 0.01F)
            mViewRect = mExtentRectangle
            AdjustAspect()
        End If

        FourthAxis = 0
        SaveView()
        SetAllRotatePointToCenter()
    End Sub

    Private Sub CreateDisplayListsFromMotionRecords()
        mDisplayLists2D.Clear()
        mToolDiaDisplayLists.Clear()
        mToolCompDisplayLists.Clear()
        mUserDisplayLists.Clear()
        mPoints2D.Clear()

        If AllMotionRecords.Count = 0 Then
            Exit Sub
        End If

        If mRangeEnd > AllMotionRecords.Count - 1 Then
            mRangeEnd = AllMotionRecords.Count - 1
        End If
        Try
            mCurMotionRec = AllMotionRecords(mRangeStart)
            mMotRecIdx = 0
            If mCurMotionRec.Visible Then
                DrawSinglePoint3D(mCurMotionRec.XYZold.X, mCurMotionRec.XYZold.Y, mCurMotionRec.XYZold.Z)
                CreateDisplayListItem(DashStyle.Solid, False)
            End If
            For mMotRecIdx = 0 To mAllMotionRecords.Count - 1
                mCurMotionRec = AllMotionRecords(mMotRecIdx)
                If mMotRecIdx >= mRangeStart AndAlso mMotRecIdx <= mRangeEnd Then
                    If mCurMotionRec.Visible Then
                        If drawMethod = enDrawMethod.INIT Then
                            mDisplayLists3D.AddList(mCurMotionRec)
                        End If
                        DrawMotionRecord() 'Draws geometry
                        If DrawToolDia AndAlso mCurMotionRec.ToolDia > 0 Then
                            DrawToolCircle(mCurMotionRec.ToolDia)
                        End If
                    End If
                End If
            Next
            For Each ur In mUserMotionRecords
                Select Case ur.GraphicsType
                    Case UserGraphicsType.LINE
                        Line3D(ur.stVec.X, ur.stVec.Y, ur.stVec.Z, ur.endVec.X, ur.endVec.Y, ur.endVec.Z)
                        CreateUserPath(ur.DrawColor, DashStyle.Solid)
                    Case UserGraphicsType.CCARC
                        DrawPolyArc(ur.ctrVec.X, ur.ctrVec.Y, ur.ctrVec.Z,
                                    ur.endVec.X, ur.stVec.X,
                                    ur.endVec.Y, ur.stVec.Y,
                                    ur.endVec.Z, ur.stVec.Z,
                                    ur.Rad, ur.ArcSang, ur.ArcEang, 1, ur.ArcPlane)
                        CreateUserPath(ur.DrawColor, DashStyle.Solid)
                    Case UserGraphicsType.CWARC
                        DrawPolyArc(ur.ctrVec.X, ur.ctrVec.Y, ur.ctrVec.Z,
                                    ur.endVec.X, ur.stVec.X,
                                    ur.endVec.Y, ur.stVec.Y,
                                    ur.endVec.Z, ur.stVec.Z,
                                    ur.Rad, ur.ArcSang, ur.ArcEang, 1, ur.ArcPlane)
                        CreateUserPath(ur.DrawColor, DashStyle.Solid)
                    Case UserGraphicsType.POINT
                        Point3dDraw(ur.stVec.X, ur.stVec.Y, ur.stVec.Z)
                        CreateUserPath(ur.DrawColor, DashStyle.Solid)
                End Select
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
        'PrepareMatrix()
        CreateLimitsBox()
        SetInViewStatus(Me.mViewRect)
        CreateGridInMachineUnits()
        CreateWcs()
        mGfx.Clear(Me.BackColor)
        DrawListsToGraphics(mGfx)
        If DrawFeedRates Or DrawCutterComp Then
            DrawSpeedsFeedsToGraphics(mGfx, DrawFeedRates, DrawCutterComp)
        End If
        mGfxBuff.Render()
        Me.ViewManipMode = Me.ViewManipMode
    End Sub

    Private Sub CreateDisplayListsAndDraw()
        If Not Visible Then Return
        If Not isInitialized Then
            Init()
        End If
        mDisplayLists2DSelectionIndices.Clear()
        CreateDisplayListsFromMotionRecords()
        DrawDisplayLists()
    End Sub

    Public Function ExtentsToString() As String
        Return String.Format("minX{0} maxX{1} minY{2} maxY{3} minZ{4} maxZ{5}", mExtentX3d(0), mExtentX3d(1), mExtentY3d(0), mExtentY3d(1), mExtentZ3d(0), mExtentZ3d(1))
    End Function


    Private Sub CreateGridInMachineUnits(Optional spacing As Single = 1.0F)
        Dim x, y As Single
        Dim x1, y1, x2, y2 As Single
        mGridDisplayLists.Clear()
        mPoints2D.Clear()
        If Not DrawGrid Then Return
        x1 = mExtentX3d(0) / mMasterGfxAdjustScale
        x2 = mExtentX3d(1) / mMasterGfxAdjustScale
        y1 = mExtentY3d(0) / mMasterGfxAdjustScale
        y2 = mExtentY3d(1) / mMasterGfxAdjustScale
        Dim unit As Single = 1
        Dim unitAdjustment As Single
        'Dim detents(5) As Single

        If mMachineUnits = MachineUnits.ENGLISH Then
            'detents(0) = (1 / 32)
            'detents(1) = (1 / 16)
            'detents(2) = (1 / 8)
            'detents(3) = (1 / 4)
            'detents(4) = (1 / 2)
            'detents(5) = 1
            unit = (1 / 32) * mMasterGfxAdjustScale
            unitAdjustment = 1.0F
        Else
            'detents(0) = 0.0393701F
            'detents(1) = 0.0393701F * 10
            'detents(2) = 0.0393701F * 100
            'detents(3) = 0.0393701F * 1000
            'detents(4) = 0.0393701F * 10000
            'detents(5) = 0.0393701F * 100000
            unit = 0.0393701F
            unitAdjustment = 25.4F
        End If

        Dim maxgrid As Single = Math.Max((mViewRect.Width) / mMasterGfxAdjustScale, (mViewRect.Height) / mMasterGfxAdjustScale)
        Dim screenSteps As Single = maxgrid / 10

        'Dim det As Single = detents.First
        'Dim bestDetent As Single = detents.First
        'Dim deviation As Single = screenSteps Mod det
        'For r As Integer = 1 To detents.Count - 1
        '    det = detents(r)
        '    If screenSteps Mod det < deviation Then
        '        bestDetent = det
        '    End If
        'Next
        spacing = (screenSteps - (screenSteps Mod unit))

        If spacing = 0 Then
            If mMachineUnits = MachineUnits.ENGLISH Then
                spacing = (1 / 32) * mMasterGfxAdjustScale
            Else
                spacing = 0.0393701F
            End If
        End If

        'Debug.Print((spacing / unitAdjustment))
        x1 += spacing * Math.Sign(mExtentX3d(0))
        x2 += spacing * Math.Sign(mExtentX3d(1))
        y1 += spacing * Math.Sign(mExtentY3d(0))
        y2 += spacing * Math.Sign(mExtentY3d(1))


        Dim stp = spacing * Math.Sign(mExtentY3d(0))
        y -= stp
        Do While y > y1
            Line3D(x1, y, 0, x2, y, 0)
            CreateGridPath()
            y -= spacing
        Loop

        stp = spacing * Math.Sign(mExtentY3d(1))
        y += stp
        Do While y < y2
            Line3D(x1, y, 0, x2, y, 0)
            CreateGridPath()
            y += spacing
        Loop

        stp = spacing * Math.Sign(mExtentX3d(0))
        x -= stp
        Do While x > x1
            Line3D(x, y1, 0, x, y2, 0)
            CreateGridPath()
            x -= spacing
        Loop

        stp = spacing * Math.Sign(mExtentX3d(1))
        x += stp
        Do While x < x2
            Line3D(x, y1, 0, x, y2, 0)
            CreateGridPath()
            x += spacing
        Loop
    End Sub
    Private Sub CreateLimitsBox()
        mLimitsDisplayLists.Clear()
        mPoints2D.Clear()
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
        Me.CreateLimitsPath()

        Line3D(Limits(0), Limits(2), Limits(4), Limits(1), Limits(2), Limits(4))
        LineEnd3D(Limits(1), Limits(2), Limits(5))
        Me.CreateLimitsPath()
        Line3D(Limits(0), Limits(3), Limits(4), Limits(1), Limits(3), Limits(4))
        LineEnd3D(Limits(1), Limits(3), Limits(5))
        Me.CreateLimitsPath()
        Line3D(Limits(1), Limits(2), Limits(4), Limits(1), Limits(3), Limits(4))
        Me.CreateLimitsPath()

    End Sub

    Private Sub DrawToolCircle(toolDia As Double)
        mPoints2D.Clear()
        'FourthAxis = 0

        If Not Visible Then Return

        'ArcSegmentCount = 8
        If toolDia = 0 Then
            toolDia = mBlipSize
        End If
        Dim r = toolDia / 2
        DrawPolyArc(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Z,
                                                mCurMotionRec.XYZpos.X + r, mCurMotionRec.XYZpos.X + r,
                                                mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Y,
                                                mCurMotionRec.XYZpos.Z, mCurMotionRec.XYZpos.Z,
                                                r, 0, ONE_RADIAN, -1, mCurMotionRec.ArcPlane)
        CreateToolDiaPath(Color.Gray, DashStyle.Solid)
    End Sub

    Private Sub DrawCutterCompIndicator()
        mPoints2D.Clear()
        'FourthAxis = 0

        If Not Visible Then Return
        Dim m = mCurMotionRec

        ''ArcSegmentCount = 8
        'Dim r = toolDia / 2
        'DrawPolyArc(mCurMotionRec.XYZpos.X, mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Z,
        '                                        mCurMotionRec.XYZpos.X + r,
        '                                        mCurMotionRec.XYZpos.X + r,
        '                                        mCurMotionRec.XYZpos.Y, mCurMotionRec.XYZpos.Y,
        '                                        mCurMotionRec.XYZpos.Z, mCurMotionRec.XYZpos.Z,
        '                                        r, 0, ONE_RADIAN, -1, mCurMotionRec.ArcPlane)
        Dim s = m.XYZold
        Dim e = m.XYZpos
        'Dim midpoint As Vector3

        'If p.Points2d.Length = 2 Then
        '    midpoint = (s + e) / 2
        'Else
        '    midpoint.X = p.Points2d(p.Points2d.Length \ 2).X
        '    midpoint.Y = p.Points2d(p.Points2d.Length \ 2).Y
        'End If

        'Dim v As Vector2 = (s - e)
        'If v.Length < 0.0001 Then Return

        'v.Normalise()
        'v = v * (mBlipSize * 4)

        'If Math.Abs((e - s).Length) < mBlipSize * 8 Then Return

        'Dim comp = mAllMotionRecords(p.MotionIndex).Comp
        'sp = New PointF(midpoint.X, midpoint.Y)

        'Debug.Print(mArcBall.ActiveMatrix.Up.Z.ToString)

        'If comp = CutterComp.OFF Or comp = CutterComp.RIGHT Then
        '    Rotate2D(40.0, v, rx, ry)
        '    ep = New PointF(midpoint.X + rx, midpoint.Y + ry)
        '    g.DrawLine(mCurPen, sp, ep)
        'End If

        'If comp = CutterComp.OFF Or comp = CutterComp.LEFT Then
        '    Rotate2D(-40.0, v, rx, ry)
        '    ep = New PointF(midpoint.X + rx, midpoint.Y + ry)
        '    g.DrawLine(mCurPen, sp, ep)
        'End If

        CreateToolCompPath()
    End Sub

    Public Sub RemoveUserGraphics(Optional id As String = "*")
        If id = "*" Then
            mUserMotionRecords.Clear()
        Else
            mUserMotionRecords.RemoveAll(Function(i) i.ID = id)
        End If
    End Sub
    Public Sub AppendUserGraphics(u As clsUserRecord)
        mUserMotionRecords.Add(u)
    End Sub

    Private Sub CreateWcs()
        mWcsDisplayLists.Clear()
        mPoints2D.Clear()
        FourthAxis = 0

        If Not Visible Then Return
        If mExtentLongest = 0 Then
            mExtentLongest = 2
        End If


        mExtentX(0) = -mExtentLongest
        mExtentX(1) = mExtentLongest
        mExtentY(0) = -mExtentLongest
        mExtentY(1) = mExtentLongest


        ' mExtentX =
        Dim prescale = (1 / mScaleToReal * mAxisIndicatorScale) / mMasterGfxAdjustScale
        If DrawAxisLines Then
            'Y axis line
            LineScaled3D(0.0F, 0.0F, 0.0F, 0.0F, -mExtentLongest, 0, 1)
            Me.CreateWcsPath(Color.Gray, DashStyle.Custom)
            LineScaled3D(0.0F, 0.0F, 0.0F, 0.0F, mExtentLongest, 0, 1)
            Me.CreateWcsPath(Color.Gray, DashStyle.Custom)

            'X axis line
            LineScaled3D(0.0F, 0.0F, 0.0F, -mExtentLongest, 0.0F, 0, 1)
            Me.CreateWcsPath(Color.Gray, DashStyle.Custom)
            LineScaled3D(0.0F, 0.0F, 0.0F, mExtentLongest, 0.0F, 0, 1)
            Me.CreateWcsPath(Color.Gray, DashStyle.Custom)

            'Z Axis line
            LineScaled3D(0.0F, 0.0F, 0.0F, 0.0F, 0.0F, -mExtentLongest, 1)
            Me.CreateWcsPath(Color.Gray, DashStyle.Custom)
            LineScaled3D(0.0F, 0.0F, 0.0F, 0.0F, 0.0F, mExtentLongest, 1)
            Me.CreateWcsPath(Color.Gray, DashStyle.Custom)
        End If

        If DrawAxisIndicator Then
            'Axis indicators
            'X indicator
            LineScaled3D(0.0F, 0.0F, 0.0F, 1.0F, 0.0F, 0, prescale)
            LineScaled3D(1.0F, 0.0F, 0.0F, 0.9F, 0.05F, 0, prescale)
            LineScaled3D(1.0F, 0.0F, 0.0F, 0.9F, -0.05F, 0, prescale)
            CreateWcsPath(Color.DarkKhaki, DashStyle.Solid)
            'Draw the letter X
            LineScaled3D(0.7F, 0.1F, 0.0F, 0.9F, 0.4F, 0, prescale)
            CreateWcsPath(Color.DarkKhaki, DashStyle.Solid)
            LineScaled3D(0.9F, 0.1F, 0.0F, 0.7F, 0.4F, 0, prescale)
            CreateWcsPath(Color.DarkKhaki, DashStyle.Solid)

            'Y indicator
            LineScaled3D(0.0F, 0.0F, 0, 0.0F, 1.0F, 0, prescale)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            LineScaled3D(0.0F, 1.0F, 0.0F, -0.05F, 0.9F, 0, prescale)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            LineScaled3D(0.0F, 1.0F, 0.0F, 0.05F, 0.9F, 0, prescale)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            'Draw the letter Y
            LineScaled3D(-0.2F, 0.7F, 0.0F, -0.2F, 0.85F, 0, prescale)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            LineScaled3D(-0.2F, 0.85F, 0.0F, -0.3F, 1.0F, 0, prescale)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            LineScaled3D(-0.2F, 0.85F, 0.0F, -0.1F, 1.0F, 0, prescale)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)

            'Z indicator
            LineScaled3D(0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 1, prescale)
            LineScaled3D(0.0F, 0.0F, 1.0F, 0.1F, 0.0F, 0.8, prescale)
            CreateWcsPath(Color.DarkRed, DashStyle.Solid)

            DrawPolyArc(0.0F, 0.0F, 0.0F, 0.1F * prescale, 0.1F * prescale, 0.0F, 0.0F, 0.8F * prescale, 0.8F * prescale, 0.1F * prescale, 0.0F, ONE_RADIAN, 1, ArcAxis.Z)
            CreateWcsPath(Color.DarkRed, DashStyle.Solid)

            'Draw the letter Z
            LineScaled3D(-0.2F, 0.0F, 0.7F, -0.4F, 0.0F, 0.7, prescale)
            LineScaled3D(-0.2F, 0.0F, 0.95F, -0.4F, 0.0F, 0.95, prescale)
            LineScaled3D(-0.2F, 0.0F, 0.95F, -0.4F, 0.0F, 0.7, prescale)
            CreateWcsPath(Color.DarkRed, DashStyle.Solid)
        End If

    End Sub

    Private Sub DrawWorkOffsetIndicator()
        If DrawAxisIndicator And Visible Then
            Dim prescale = (2 / mScaleToReal * mAxisIndicatorScale) / mMasterGfxAdjustScale

            'Axis indicators
            'X indicator
            LineScaled3D(0.0F, 0.0F, 0.0F, 1.0F, 0.0F, 0, prescale)
            LineScaled3D(1.0F, 0.0F, 0.0F, 0.9F, 0.05F, 0, prescale)
            LineScaled3D(1.0F, 0.0F, 0.0F, 0.9F, -0.05F, 0, prescale)
            CreateWcsPath(Color.DarkKhaki, DashStyle.Solid)

            'Y indicator
            LineScaled3D(0.0F, 0.0F, 0, 0.0F, 1.0F, 0, prescale)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            LineScaled3D(0.0F, 1.0F, 0.0F, -0.05F, 0.9F, 0, prescale)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)
            LineScaled3D(0.0F, 1.0F, 0.0F, 0.05F, 0.9F, 0, prescale)
            CreateWcsPath(Color.DarkGreen, DashStyle.Solid)

            'Z indicator
            LineScaled3D(0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 1, prescale)
            LineScaled3D(0.0F, 0.0F, 1.0F, 0.1F, 0.0F, 0.8, prescale)
            CreateWcsPath(Color.DarkRed, DashStyle.Solid)
        End If
    End Sub


    'Gathers the tools and creates ToolLayers from current colors
    Public Sub GatherToolsFromMotionRecords()
        Dim lastTool As Single
        ToolLayers.Clear()
        For Each blk As clsMotionRecord In AllMotionRecords
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
            If sib.Name <> Me.Name Then
                sib.ToolLayers = Me.ToolLayers
            End If
        Next
    End Sub

    'Sets the selection based on a range
    Public Sub SetSelectionHits(ranges As List(Of Integer), pIndex As Integer)
        Dim maxHits As Integer = 0
        Dim hitIndex As Integer = 0
        mSelectionHits.Clear()
        mDisplayLists2DSelectionIndices.Clear()

        If AllMotionRecords.Count > 0 Then
            For Each l As clsDisplayList2D In mDisplayLists2D
                If l.InView Then
                    If maxHits >= MaxSelectionHits Then Exit For

                    If ranges.Contains(AllMotionRecords(l.MotionIndex).Linenumber) AndAlso AllMotionRecords(l.MotionIndex).ProgIndex = pIndex Then
                        mSelectionHits.Add(AllMotionRecords(l.MotionIndex))
                        mDisplayLists2DSelectionIndices.Add(hitIndex)
                        maxHits += 1
                    End If
                End If
                hitIndex += 1
            Next
        End If

        If Me.mDisplayLists2DSelectionIndices.Count > 0 Then
            DrawGraphicsOverlaysAllViews(Me.mDisplayLists2DSelectionIndices, -1)
            mLastSelectedMotionRecord = mSelectionHits(0)
            UpdateElementDetails()
        End If

    End Sub



    'Sets the selection based on a range
    Public Sub SetSelectionHits(rangeLnStart As Integer, rangeLnEnd As Integer, pIndex As Integer)
        Dim maxHits As Integer = 0
        Dim hitIndex As Integer = 0
        mSelectionHits.Clear()
        mDisplayLists2DSelectionIndices.Clear()

        If AllMotionRecords.Count > 0 Then
            For Each l As clsDisplayList2D In mDisplayLists2D
                If l.InView Then
                    If maxHits >= MaxSelectionHits Then Exit For
                    If AllMotionRecords(l.MotionIndex).Linenumber >= rangeLnStart _
                    AndAlso AllMotionRecords(l.MotionIndex).Linenumber <= rangeLnEnd Then
                        If pIndex = 0 OrElse AllMotionRecords(l.MotionIndex).ProgIndex = pIndex Then
                            mSelectionHits.Add(AllMotionRecords(l.MotionIndex))
                            mDisplayLists2DSelectionIndices.Add(hitIndex)
                            maxHits += 1
                        End If
                    End If
                End If
                hitIndex += 1
            Next
        End If

        If Me.mDisplayLists2DSelectionIndices.Count > 0 Then
            DrawGraphicsOverlaysAllViews(Me.mDisplayLists2DSelectionIndices, -1)
            mLastSelectedMotionRecord = mSelectionHits(0)
            UpdateElementDetails()
        End If

    End Sub

    ''' <returns>Index of first motion record</returns>
    Private Function GetSelectionHits(rect As RectangleF) As Integer
        Dim maxHits As Integer = 0
        Dim hitIndex As Integer = 0
        Dim cadRect As New clsCadRect(rect.X, rect.Y, rect.Width, rect.Height)
        mSelectionHits.Clear()
        mDisplayLists2DSelectionIndices.Clear()
        If AllMotionRecords.Count > 0 Then
            For Each l In mDisplayLists2D
                If l.InView And l.Selectable Then
                    'Iterate in sets of 2 
                    For r As Integer = 0 To l.Points2d.Length - 2
                        If maxHits >= MaxSelectionHits Then Exit For
                        Dim mag = cadRect.IntersectsLine(l.Points2d(r), l.Points2d(r + 1))
                        If mag > -1 Then
                            Dim mr = AllMotionRecords(l.MotionIndex)
                            If Not mSelectionHits.Contains(mr) Then
                                mSelectionHits.Add(mr)
                                mDisplayLists2DSelectionIndices.Add(hitIndex)
                                maxHits += 1
                                Exit For
                            End If
                        End If
                    Next
                End If
                hitIndex += 1
            Next
        End If

        If mSelectionHits.Count > 0 Then
            Return mSelectionHits.First.Index
        Else
            Return -1
        End If
    End Function



    Private Function GetDisplayIndexFromMotionIndex(motIdx As Integer) As Integer
        Dim ret As Integer = 0
        For Each l As clsDisplayList2D In mDisplayLists2D
            If l.MotionIndex = motIdx Then
                Return ret
                ret += 1
            End If
        Next
        Return -1
    End Function

    Public Sub SelectLastElement()
        mSelectionHits.Clear()
        mDisplayLists2DSelectionIndices.Clear()
        If AllMotionRecords.Count > 0 AndAlso RangeEnd > -1 Then
            mSelectionHits.Add(AllMotionRecords(RangeEnd))
            mDisplayLists2DSelectionIndices.Add(mDisplayLists2D.Count - 1)
        End If
    End Sub

    Public Sub ClickLastElement()
        If mSelectionHits.Count > 0 Then
            RaiseEvent OnSelection(mSelectionHits, 0)
        End If
    End Sub

    Public Sub SetToolColor(tool As Single, clr As Color)
        For Each mr As clsMotionRecord In AllMotionRecords
            If mr.Tool = tool Then
                mr.DrawColor = clr
            End If
        Next
    End Sub

    Private Sub SetAllInVeiw()
        For Each l As clsDisplayList2D In mDisplayLists2D
            l.InView = l.Points2d.Length > 1
        Next
    End Sub


    Private Sub SetInViewStatus(rect As RectangleF)
        Dim cadRect As New clsCadRect(rect.X, rect.Y, rect.Width, rect.Height)
        For Each l As clsDisplayList2D In mDisplayLists2D
            'Iterate in sets of 2 
            For r As Integer = 0 To l.Points2d.Length - 2
                l.InView = False
                If cadRect.IntersectsLine(l.Points2d(r), l.Points2d(r + 1)) > -1 Then
                    l.InView = True
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub CreateDisplayListItem(drawStyle As DashStyle, Optional selectable As Boolean = True)
        If (mPoints2D.Count < 1) Then Return
        Dim p As New clsDisplayList2D

        With p
            .Selectable = selectable
            If MotionColorByMotionType Then
                .Color = mCurMotionColor
            Else
                .Color = mCurMotionRec.DrawColor
            End If
            .DashStyle = drawStyle
            .MotionIndex = mMotRecIdx
            .Points2d = mPoints2D.ToArray
        End With
        mDisplayLists2D.Add(p)
        mPoints2D.Clear()
    End Sub

    'Limits lines and indicator
    Private Sub CreateLimitsPath()
        Dim p As New clsDisplayList2D
        If (mPoints2D.Count < 2) Then Return
        With p
            .Color = LimitsColor
            .DashStyle = DashStyle.Solid '(mCurMotion = Motion.RAPID)
            .Points2d = mPoints2D.ToArray
        End With
        mLimitsDisplayLists.Add(p)
        mPoints2D.Clear()
    End Sub

    Private Sub CreateGridPath()
        Dim p As New clsDisplayList2D
        If (mPoints2D.Count < 2) Then Return
        With p
            .Color = LimitsColor
            .DashStyle = DashStyle.Solid '(mCurMotion = Motion.RAPID)
            .Points2d = mPoints2D.ToArray
        End With
        mGridDisplayLists.Add(p)
        mPoints2D.Clear()
    End Sub

    Private Sub CreateToolDiaPath(clr As Color, drawStyle As DashStyle)
        Dim p As New clsDisplayList2D
        If (mPoints2D.Count < 2) Then Return
        With p
            .Color = clr
            .DashStyle = drawStyle '(mCurMotion = Motion.RAPID)
            .Points2d = mPoints2D.ToArray
        End With
        mToolDiaDisplayLists.Add(p)
        mPoints2D.Clear()
    End Sub

    Private Sub CreateToolCompPath()
        Dim p As New clsDisplayList2D
        If (mPoints2D.Count < 2) Then Return
        With p
            .Color = mCurMotionColor
            .DashStyle = DashStyle.Solid '(mCurMotion = Motion.RAPID)
            .Points2d = mPoints2D.ToArray
        End With
        mToolCompDisplayLists.Add(p)
        mPoints2D.Clear()
    End Sub
    Private Sub CreateUserPath(clr As Color, drawStyle As DashStyle)
        Dim p As New clsDisplayList2D
        'If (mPoints2D.Count < 2) Then Return
        With p
            .Color = clr
            '.DashStyle = drawStyle '(mCurMotion = Motion.RAPID)
            .Points2d = mPoints2D.ToArray
            .Selectable = True
            .InView = True

        End With
        mUserDisplayLists.Add(p)
        mPoints2D.Clear()
    End Sub


    'Axis lines and indicator
    Private Sub CreateWcsPath(clr As Color, drawStyle As DashStyle)
        Dim p As New clsDisplayList2D
        If (mPoints2D.Count < 2) Then Return
        With p
            .Color = clr
            .DashStyle = drawStyle '(mCurMotion = Motion.RAPID)
            .Points2d = mPoints2D.ToArray
        End With
        mWcsDisplayLists.Add(p)
        mPoints2D.Clear()
    End Sub

    Private Sub AddLineEndpoint(x2 As Single, y2 As Single)
        'Code was removed that checked for a line of zero length.
        'This creates a problem because it will create an uneven number of display list in each viewport.
        If mPoints2D.Count = 0 Then mPoints2D.Add(mLastPos) 'TODO
        mLastPos.X = x2
        mLastPos.Y = y2
        mPoints2D.Add(mLastPos)
    End Sub

    Private Sub Line2D(x1 As Single, y1 As Single, x2 As Single, y2 As Single)
        mPoints2D.Add(New PointF(x1, y1))
        mPoints2D.Add(New PointF(x2, y2))
        mLastPos.X = x2
        mLastPos.Y = y2
    End Sub

#End Region

    Private Sub MG_BasicViewer_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            'Reclaim a little memory
            Me.mDisplayLists2D.Clear()
        End If
    End Sub

    Private Sub SetViewManipMode(sender As System.Object, e As EventArgs) Handles mnuZoom.Click, mnuSelect.Click, mnuRotate.Click, mnuPan.Click, mnuFit.Click, mnuFence.Click, mnuSetRotate.Click, mnuMeasure.Click
        Dim tag As String = sender.GetType.GetProperty("Tag").GetValue(sender, Nothing).ToString
        Select Case tag
            Case "viewFit"
                SetView(ManipMode.FIT, My.Computer.Keyboard.ShiftKeyDown)
            Case "viewPan"
                SetView(ManipMode.PAN)
            Case "viewFence"
                SetView(ManipMode.FENCE)
            Case "viewZoom"
                SetView(ManipMode.ZOOM)
            Case "viewRotate"
                SetView(ManipMode.ROTATE)
            Case "Select"
                SetView(ManipMode.SELECTION)
            Case "setRotate"
                SetView(ManipMode.SETROTATE)
            Case "measure"
                SetView(ManipMode.MEASURE)
        End Select
    End Sub

    Public Sub SetView(cmd As ManipMode, Optional fitAll As Boolean = False)
        If cmd = ManipMode.FIT Then
            If fitAll Then
                For Each Sibling As MG_BasicViewer In MyNeighborhood
                    Sibling.FindViewExtents()
                Next
                Redraw(True)
            Else
                FindViewExtents()
                Redraw(False)
            End If
        End If
        ViewManipMode = cmd
        RaiseEvent OnSetViewMode(cmd)
    End Sub

    Public Sub SetView(x As Single, y As Single, z As Single)
        Pitch = x
        Roll = y
        Yaw = z
        SetViewMatrix3D()
        'FindviewExtents()
        Redraw(False)
    End Sub
    Public Sub SetNamedView(name As String)
        Select Case name
            Case "viewTop"
                Pitch = 0
                Roll = 0
                Yaw = 0
            Case "viewFront"
                Pitch = 270
                Roll = 0
                Yaw = 0
            Case "viewRight"
                Pitch = 270
                Roll = 0
                Yaw = 270
            Case "viewISO"
                Pitch = 315
                Roll = 0
                Yaw = 315
            Case "viewLathe"
                Pitch = 0
                Roll = 90
                Yaw = 90
        End Select
        SetViewMatrix3D()
        FindViewExtents()
        SaveView()
        Redraw(False)
    End Sub
    Private Sub NamedView(sender As System.Object, e As EventArgs) Handles mnuTop.Click, mnuRight.Click, mnuIsometric.Click, mnuFront.Click, mnuLathe.Click
        SetNamedView(DirectCast(sender, ToolStripMenuItem).Tag.ToString)
    End Sub

    Private Sub timerQuickPick_Tick(sender As Object, e As EventArgs) Handles timerQuickPick.Tick
        Static Xold As Single
        Static Yold As Single
        If ViewManipMode <> ManipMode.SELECTION Or RMBOpen Then
            Exit Sub
        End If

        If Not Me.Focused Then
            Return
        End If

        Dim notMoving As Boolean = ((Xold = mCurrentCursorPos.X) AndAlso (Yold = mCurrentCursorPos.Y))

        If notMoving AndAlso mSelectionHits.Count > 1 Then
            Me.Cursor = Me.mSelectEtcCursor
            'Debug.Print("Quick")
        Else
            Me.Cursor = Me.mSelectCursor
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
        mFrmQuickPick.Location = Cursor.Position
        mFrmQuickPick.TopMost = True
        mFrmQuickPick.ShowDialog()
        mFrmQuickPick.Dispose()
        timerQuickPick.Enabled = True
    End Sub


    Private Sub mFrmQuickPick_OnSingleSelect(selIdx As Integer) Handles mFrmQuickPick.OnSingleSelect

        'If Me.mSelectionHitIndices.Count > 0 Then
        DrawGraphicsOverlaysAllViews(Me.mDisplayLists2DSelectionIndices, selIdx)
        'End If

        'DrawSelectionOverlay(Me.mSelectionHitIndices, selIdx)
        'For Each sib As MG_BasicViewer In MySiblings
        '    If Not ReferenceEquals(sib, Me) Then
        '        sib.DrawSelectionOverlay(Me.mSelectionHitIndices, selIdx)
        '    End If
        'Next
        ''Should behave as if the user clicked a single elementmSelectionHitIndices
        'DrawSelectionOverlay(Me.mSelectionHitIndices, selIdx)
        RaiseEvent OnSelection(Me.mSelectionHits, selIdx)
    End Sub

    'Public Function HitIndexToMotionBlock(ByVal i As Integer) As clsMotionRecord
    '    Return MotionBlocks(Me.mDisplayLists(mSelectionHitIndices(i)).MotionIndex)
    'End Function

    Public Sub InitSiblingMotionBlocks(mb As List(Of clsMotionRecord))
        For Each Sibling As MG_BasicViewer In MyNeighborhood
            Sibling.mAllMotionRecords = mb
        Next
    End Sub
    Public Sub SetAllTouchDisplayMode(touch As Boolean)
        For Each Sibling As MG_BasicViewer In MyNeighborhood
            Sibling.TabletMode = touch
        Next
    End Sub
    Private Sub rmbView_Opening(sender As System.Object, e As CancelEventArgs) Handles rmbView.Opening
        mRmbMenuOpen = True
    End Sub

    Private Sub rmbView_Closed(sender As System.Object, e As ToolStripDropDownClosedEventArgs) Handles rmbView.Closed
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
            mFrmGraphicsDetails.SetGraphData(mAllMotionRecords, totalCutTime + totalRapidTime)
            mFrmGraphicsDetails.Show(Me)
            Me.ParentForm.Focus()
            UpdateElementDetails()

            If zeroFeedDetected Then
                MsgBox("Zero Feed", MsgBoxStyle.Information, "Feed Alert")
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
            mFrmGraphicsDetails.SetGraphData(mAllMotionRecords, totalCutTime + totalRapidTime)
        End If
    End Sub

    Private Shared Sub mGraphicsDetails_FormClosed(sender As Object, e As FormClosedEventArgs) Handles mFrmGraphicsDetails.FormClosed
        mFrmGraphicsDetails = Nothing
        RaiseEvent OnElementDetailsClose()
    End Sub

    Private Sub MG_BasicViewer_TouchDoubleDoubleTap(sender As Object, e As WMTouchEventArgs) Handles Me.TouchDoubleDoubleTap
        FindViewExtents()
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
    Private ReadOnly _View As SavedView

    Private Sub MG_BasicViewer_TouchPinching(sender As Object, e As WMDoubleTouchEventArgs) Handles Me.TouchPinching
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

    Private Sub MG_BasicViewer_Touchdown(sender As Object, e As WMTouchEventArgs) Handles Me.Touchdown
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
            If Not RegisterTouchWindow(Me.Handle, 0) Then
                'Debug.Print("ERROR: Could not register window for multi-touch")
            End If

        Catch exception As Exception
            'Debug.Print("ERROR: RegisterTouchWindow API not available")
            'Debug.Print(exception.ToString())
        End Try
    End Sub

    Private Sub MG_BasicViewer_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick
        If e.Button = MouseButtons.Middle Then
            FindViewExtents()
            Redraw(False)
            SaveView()
        End If
    End Sub

    Public Sub SetContextImages()
        Try
            If Me.ContextMenuStrip Is Nothing Then Return

            Dim cms As ContextMenuStrip = Me.ContextMenuStrip
            Dim fnt As Font
            Dim size As Integer
            If mTabletMode Then
                size = 32
                fnt = New Font(Me.Font.FontFamily, 20)
            Else
                size = 16
                fnt = New Font(Me.Font.FontFamily, 10)
            End If

            cms.SuspendLayout()
            cms.ImageScalingSize = New Size(size, size)
            For Each cmsb As ToolStripMenuItem In cms.Items
                cmsb.Font = fnt
                If cmsb.Tag IsNot Nothing Then
                    cmsb.Image = CType(My.Resources.ResourceManager.GetObject(cmsb.Tag.ToString & "_" & size), Image)
                End If

                For Each tsm As ToolStripMenuItem In cmsb.DropDownItems
                    If tsm.Tag IsNot Nothing Then
                        tsm.Image = CType(My.Resources.ResourceManager.GetObject(tsm.Tag.ToString & "_" & size), Image)
                    End If
                Next
            Next
            cms.ResumeLayout()
        Catch ex As Exception
            Debug.Assert(1 = 0, "SetContextImages")
        End Try

    End Sub

    Private Sub MG_BasicViewer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.Z
                    SetPreviousView()
                    CreateDisplayListsAndDraw()

                Case Keys.Y
                    SetNextView()
                    CreateDisplayListsAndDraw()
            End Select
        End If

        If e.KeyCode = Keys.Escape Then
            SetView(ManipMode.SELECTION)
            mSelKeypoint3D = mExtentCenter
            SetRotatePoint(mSelKeypoint3D)
        End If
    End Sub

    Private Sub MG_BasicViewer_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        timerQuickPick.Enabled = True
    End Sub

    Private Sub MG_BasicViewer_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        timerQuickPick.Enabled = False
    End Sub

    Private Sub MG_BasicViewer_TouchMove(sender As Object, e As WMTouchEventArgs) Handles Me.TouchMove
        Static Xold As Single
        Static Yold As Single

        If e.IsPrimaryContact And mTouchPointCount = 1 Then
            mArcBall.UpdateRotation(e.LocationX, e.LocationY)
            mArcBall.ApplyRotationMatrix()

            SetViewMatrix3D()
            If mDynamicViewManipulation Then
                If mDrawLinesMilliseconds > maxDrawTime Then
                    mArcQuality = FAST_QUALITY
                End If
                CreateDisplayListsAndDraw()
            Else
                DrawWcsOnlyToBuffer()
            End If
        End If
        Xold = e.LocationX
        Yold = e.LocationY
    End Sub


    'Private Sub Dx3_Motion(sender As Object, e As MotionEventArgs) Handles Dx3.Motion
    '    With Me
    '        .PanScene(e.TX \ 100, e.TY \ 100)
    '        .Redraw(False)
    '    End With
    '    '    'CreateDisplayListsAndDraw()
    '    '    'mArcBall.AddRotation(Maths.ToRadians(-Math.Sign(Yold - e.Y)), New Vector3(1, 0, 0))
    '    '    'mArcBall.UpdateRotation(e.X, e.Y)
    '    '    'mArcBall.ApplyRotationMatrix()
    '    '    'SetViewMatrix3D()

    'End Sub

    'Private Sub Dx3_Button(sender As Object, e As ButtonEventArgs) Handles Dx3.Button

    'End Sub

    'Private Sub Dx3_ZeroPoint(sender As Object, e As EventArgs) Handles Dx3.ZeroPoint

    'End Sub
End Class
