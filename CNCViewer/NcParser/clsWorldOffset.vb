Imports Abacus.DoublePrecision
''' <summary>
''' Start with a zero offset
''' I believe that when a new work offset is selected then the G92, G68, G51, G52 get reset
''' A block with G53 implies that the following axees are in machine coordinates for just this one block.
''' G92, G68, G51, G52 get added to the current work offset.
''' G53 usually cancels all work offsets.
''' </summary>
Public Class WorldOffset
    Private Shared WorkOffset As Matrix44  'G54 world or work offset
    Private Shared WorkOffsetG52 As Matrix44 'G52 on top of world
    Private Shared WorkOffsetG92 As Matrix44 'G92 on top of world
    Private Shared Rotate As Matrix44 'on top of world
    Private Shared Scale As Matrix44 'on top of world
    Private Shared Mirror As Matrix44
    Private Shared Working As Matrix44
    Private Shared Initial As Matrix44
    Private Shared Suspended As Matrix44
    Private Shared IsSuspended As Boolean
    Private Shared MirrorAxis As Vector3
    Private Shared MirrorAbout As Vector3
    Private Shared RotAng As Double
    Public Shared ScaleFactor As Double = 1
    Public Shared TransformType As BlockShiftType
    Private Shared chrXYZ(2) As Char
    Private Shared wcs As WrkOffset

    Public Shared G52String As String = ""
    Public Shared G53String As String = ""
    Public Shared G92String As String = ""
    Public Shared ScaleString As String = ""
    Public Shared RotateString As String = ""
    Public Shared MirrorString As String = ""
    Private Shared _isIncremental As Boolean
    Private Shared _woldldString As String = "MACHINE"
    Public Shared ReadOnly Property WoldldString As String
        Get
            Return _woldldString
        End Get
    End Property

    Public Shared Property IsIncremental As Boolean
        Get
            Return _isIncremental
        End Get
        Set(value As Boolean)
            If _isIncremental <> value Then
                ApplyStack(value)
            End If
            _isIncremental = value
        End Set
    End Property

    Public Shared Sub SetShiftEnum(shiftType As BlockShiftType)
        TransformType = TransformType Or shiftType
    End Sub
    Public Shared Function IsShiftType(shiftType As BlockShiftType) As Boolean
        Return (TransformType And shiftType) = shiftType
    End Function

    Public Shared Function IsRotated() As Boolean
        Return RotAng <> 0.0F
    End Function

    ''' <summary>
    ''' Sets or resets the work offset and all other transforms
    ''' </summary>
    Public Shared Sub Init(shiftX As Double, shiftY As Double, shiftZ As Double, w As WrkOffset)
        wcs = w
        WorkOffset = Matrix44.Identity
        WorkOffsetG52 = Matrix44.Identity
        WorkOffsetG92 = Matrix44.Identity
        Rotate = Matrix44.Identity
        Scale = Matrix44.Identity
        Mirror = Matrix44.Identity
        Initial = Matrix44.Identity
        Working = Matrix44.Identity
        G52String = ""
        G53String = ""
        G92String = ""
        ScaleString = ""
        RotateString = ""
        MirrorString = ""
        Initial = Matrix44.CreateTranslation(shiftX, shiftY, shiftZ)
        Working *= Initial
        MirrorAxis = New Vector3(1, 1, 1)
        MirrorAbout = New Vector3(0, 0, 0)
        RotAng = 0
        ScaleFactor = 1
        _woldldString = wcs.ToString
        chrXYZ = "   ".ToCharArray
    End Sub
    Public Shared Sub Suspend()
        Suspended = Matrix44.Identity
        Suspended *= Working
        Working = Matrix44.Identity
        IsSuspended = True
        _woldldString = "MACHINE"
    End Sub
    Public Shared Sub Restore()
        If IsSuspended Then
            Working = Matrix44.Identity
            Working *= Suspended
            IsSuspended = False
            SetString()
        End If
    End Sub
    ''' <summary>
    ''' Sets or resets the work offset and all other transforms
    ''' </summary>
    Public Shared Sub SetOffset(w As WrkOffset)
        wcs = w
        WorkOffset = Matrix44.Identity
        Rotate = Matrix44.Identity
        Scale = Matrix44.Identity
        Mirror = Matrix44.Identity
        WorkOffset = Matrix44.CreateTranslation(w.X, w.Y, w.Z)
        'Can't set the rotation here. It needs to be done in the viewer
        'Rotate = Matrix44.CreateFromYawPitchRoll(Maths.ToRadians(w.A), Maths.ToRadians(w.B), Maths.ToRadians(w.C))
        'The rotation here is only for G51
        ApplyStack()
    End Sub

    ''' <summary>
    ''' Usually a G52 X Y Z value added t the current work offset
    ''' </summary>
    Public Shared Sub AddOffset(w As WrkOffset)
        Working = Matrix44.Identity
        WorkOffsetG92 = Matrix44.Identity 'G52 cancels G92

        WorkOffsetG52 = Matrix44.Identity
        WorkOffsetG52 *= Matrix44.CreateTranslation(w.X, w.Y, w.Z)
        'WorkOffsetG52 *= Matrix44.CreateFromYawPitchRoll(w.A, w.B, w.C)
        ApplyStack()
    End Sub

    ''' <summary>
    ''' Usually a G92 X Y Z value added t the current work offtet
    ''' </summary>
    Public Shared Sub ShiftOffset(w As WrkOffset)
        Working = Matrix44.Identity
        WorkOffsetG52 = Matrix44.Identity 'G92 cancels G52

        WorkOffsetG92 = Matrix44.Identity
        WorkOffsetG92 *= Matrix44.CreateTranslation(w.X, w.Y, w.Z)
        'WorkOffsetG92 *= Matrix44.CreateFromYawPitchRoll(w.A, w.B, w.C)
        ApplyStack()
    End Sub

    Private Shared Sub SetString()
        _woldldString = wcs.ToString
        If Not String.IsNullOrEmpty(G52String) Then
            _woldldString &= "+" & G52String
        End If
        If Not String.IsNullOrEmpty(G53String) Then
            _woldldString &= "+" & G53String
        End If
        If Not String.IsNullOrEmpty(G92String) Then
            _woldldString &= "+" & G92String
        End If
        If Not String.IsNullOrEmpty(ScaleString) Then
            _woldldString &= "+" & ScaleString
        End If
        If Not String.IsNullOrEmpty(RotateString) Then
            _woldldString &= "+" & RotateString
        End If
        If Not String.IsNullOrEmpty(MirrorString) Then
            _woldldString &= "+" & MirrorString & chrXYZ
        End If

    End Sub

    ''' <summary>
    ''' This could be a G68 rotation
    ''' </summary>
    Public Shared Sub SetRotationXY(x As Double, y As Double, z As Double, a As Double, inc As IncAbsMode)
        If inc = IncAbsMode.INC Then
            RotAng += a
        Else
            RotAng = a
        End If
        Working = Matrix44.Identity

        Rotate = Matrix44.Identity
        Rotate *= Matrix44.CreateTranslation(-x, -y, -z)
        Rotate *= Matrix44.CreateRotationZ(Maths.ToRadians(RotAng))
        Rotate *= Matrix44.CreateTranslation(x, y, z)

        ApplyStack()

    End Sub

    Public Shared Sub CancelRotation()
        SetRotationXY(0, 0, 0, 0, IncAbsMode.ABS)
        SetString()
    End Sub

    ''' <summary>
    ''' This could be a G51 scale
    ''' </summary>
    Public Shared Sub ScaleWorld(x As Double, y As Double, z As Double, p As Double)
        ScaleFactor = p
        Working = Matrix44.Identity
        Scale = Matrix44.Identity
        Scale *= Matrix44.CreateTranslation(-x, -y, -z)
        Scale *= Matrix44.CreateScale(ScaleFactor)
        Scale *= Matrix44.CreateTranslation(x, y, z)
        ApplyStack()
    End Sub

    Public Shared Sub CancelScale()
        ScaleWorld(0, 0, 0, 1)
        SetString()
    End Sub

    Public Shared Sub ApplyStack(Optional inc As Boolean = False)
        Working = Matrix44.Identity
        Working *= Rotate 'applied last
        Working *= Scale
        Working *= Mirror
        If Not inc Then
            Working *= WorkOffsetG92
            Working *= WorkOffsetG52
            Working *= WorkOffset
            Working *= Initial
        End If
        SetString()
    End Sub

    Public Shared Function MirrorIsOnlyOneAxis() As Boolean
        Return (MirrorAxis.X + MirrorAxis.Y + MirrorAxis.Z) = 1
    End Function
    Public Shared Sub MirrorAboutAxis(x As Double, y As Double, z As Double)
        Working = Matrix44.Identity
        Mirror = Matrix44.Identity
        If Not Double.IsNaN(x) Then
            MirrorAbout.X = x
            MirrorAxis.X = -1
            chrXYZ(0) = "X"c
        End If
        If Not Double.IsNaN(y) Then
            MirrorAbout.Y = y
            MirrorAxis.Y = -1
            chrXYZ(1) = "Y"c
        End If
        If Not Double.IsNaN(z) Then
            MirrorAbout.Z = z
            MirrorAxis.Z = -1
            chrXYZ(2) = "Z"c
        End If

        Mirror *= Matrix44.CreateTranslation(-MirrorAbout.X, -MirrorAbout.Y, -MirrorAbout.Z)
        Mirror *= Matrix44.CreateScale(MirrorAxis)
        Mirror *= Matrix44.CreateTranslation(MirrorAbout.X, MirrorAbout.Y, MirrorAbout.Z)

        Working *= Rotate 'applied last
        Working *= Scale
        Working *= Mirror
        Working *= WorkOffsetG92
        Working *= WorkOffsetG52
        Working *= WorkOffset
        Working *= Initial
        SetString()

    End Sub

    Public Shared Sub CancelMirrorAxis(x As Double, y As Double, z As Double)
        Working = Matrix44.Identity
        Mirror = Matrix44.Identity
        If x = 0 Then
            MirrorAxis.X = 1
            MirrorAbout.X = 0
            chrXYZ(0) = " "c
        End If
        If y = 0 Then
            MirrorAxis.Y = 1
            MirrorAbout.Y = 0
            chrXYZ(1) = " "c
        End If
        If z = 0 Then
            MirrorAxis.Z = 1
            MirrorAbout.Z = 0
            chrXYZ(2) = " "c
        End If

        Mirror *= Matrix44.CreateTranslation(-MirrorAbout.X, -MirrorAbout.Y, -MirrorAbout.Z)
        Mirror *= Matrix44.CreateScale(MirrorAxis)
        Mirror *= Matrix44.CreateTranslation(MirrorAbout.X, MirrorAbout.Y, MirrorAbout.Z)

        Working *= Rotate 'applied last
        Working *= Scale
        Working *= Mirror
        Working *= WorkOffset
        Working *= Initial
        SetString()

    End Sub
    Public Shared Sub InvertValue(ByRef v As Vector3)
        Dim inv As Matrix44 = Matrix44.Identity
        inv *= Working
        Dim pt = Matrix44.Transform(Matrix44.Invert(inv), v)
        v.X = pt.X
        v.Y = pt.Y
        v.Z = pt.Z
    End Sub
    Public Shared Function Apply(x As Double, y As Double, z As Double) As Vector3
        Dim input As New Vector3(x, y, z)
        Return Matrix44.Transform(Working, input)
    End Function
    Public Shared Sub Apply(ByRef v As Vector3)
        Dim pt = Matrix44.Transform(Working, v)
        v.X = pt.X
        v.Y = pt.Y
        v.Z = pt.Z
    End Sub

    Public Shared Sub ApplyRotationScaleMirror(ByRef v As Vector3)
        Dim RotSclMir As Matrix44 = Matrix44.Identity
        RotSclMir *= Rotate
        RotSclMir *= Scale
        RotSclMir *= Mirror
        Dim pt = Matrix44.Transform(RotSclMir, v)
        v.X = pt.X
        v.Y = pt.Y
        v.Z = pt.Z
    End Sub


    Public Shared Sub ApplyRotation(ByRef v As Vector3)
        Dim pt = Matrix44.Transform(Rotate, v)
        v.X = pt.X
        v.Y = pt.Y
        v.Z = pt.Z
    End Sub

    Public Shared Sub ApplyScale(ByRef v As Vector3)
        Dim pt = Matrix44.Transform(Scale, v)
        v.X = pt.X
        v.Y = pt.Y
        v.Z = pt.Z
    End Sub

    Public Shared Sub ApplyMirror(ByRef v As Vector3)
        Dim pt = Matrix44.Transform(Mirror, v)
        v.X = pt.X
        v.Y = pt.Y
        v.Z = pt.Z
    End Sub

    Public Shared Function ApplyZ(z As Double) As Double
        Dim v = New Vector3(0, 0, z)
        Dim pt = Matrix44.Transform(Working, v)
        Return pt.Z
    End Function
End Class
