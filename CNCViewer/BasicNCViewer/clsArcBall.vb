''' <remarks>
''' Jason Titcomb
''' www.CncEdit.com
''' https://github.com/JasonTitcomb/Basic_CNC_Viewer/blob/master/LICENSE.md
''' </remarks>
Imports Abacus.SinglePrecision

Public Class clsArcBall
    Private ballRAdius As Single
    Public IsRotating As Boolean
    Private width As Integer
    Private height As Integer
    Private startRotationVector As Vector3
    Private lastRotationVector As Vector3
    Private currentRotationVector As Vector3
    Private Const TRANSLATION_FACTOR = 0.01F
    Private transX, transY As Single
    Private currentTransX, currentTransY As Single
    Private startTransX, startTransY As Single
    Private mActiveMatrix As Matrix44
    Private lastMatrix As Matrix44
    Private screenPoints(2) As PointF
    Public Event OnLerpChanged(sender As Object, m As Matrix44)

    Public Sub LerpTo(m As Matrix44, count As Integer)

    End Sub
    Public Property ActiveMatrix As Matrix44
        Get
            Return mActiveMatrix
        End Get
        Set(value As Matrix44)
            mActiveMatrix = value
            lastMatrix = ActiveMatrix
        End Set
    End Property

    Public Sub New()
        ballRAdius = 600
        IsRotating = False
        width = height = 0
        mActiveMatrix = Matrix44.Identity
        lastMatrix = ActiveMatrix
    End Sub

    ''' <summary>
    ''' Set width and height of the current windows, it's needed every time you resize the window
    ''' </summary>
    Public Sub SetWidthHeight(w As Integer, h As Integer)
        width = w
        height = h
        ballRAdius = Math.Max(w / 2, h / 2) + 40
    End Sub

    Public Sub SetRadius(r As Single)
        ballRAdius = r
    End Sub
    ''' <summary>
    ''' Start the rotation. Use this method In association With the left click.
    ''' Here you must give directly the coordinates of the mouse. 
    ''' This method supposes that the 0,0 Is In the upper-left part Of the screen
    ''' param x Horizontal position Of the mouse (0,0) = upperleft corner (w,h) = lower right
    ''' param y Vertical position Of the mouse (0,0) = upperleft corner (w,h) = lower right
    ''' </summary>
    Public Sub StartRotation(x As Integer, y As Integer)
        screenPoints(0).X = x
        screenPoints(0).Y = y
        x = ((x) - (width / 2))
        y = ((height / 2) - y)

        startRotationVector = ConvertXyToVector(x, y)
        startRotationVector.Normalise()
        currentRotationVector = startRotationVector
        lastRotationVector = currentRotationVector
        IsRotating = Not Single.IsNaN(currentRotationVector.X)

        ' Debug.Print("Start")
    End Sub

    ''' <summary>
    ''' Use this method in association with the drag event
    ''' </summary>
    Public Sub UpdateRotation(x As Integer, y As Integer)
        x = ((x) - (width / 2))
        y = ((height / 2) - y)
        currentRotationVector = ConvertXyToVector(x, y)
    End Sub

    Public Sub stopRotation()
        ApplyRotationMatrix()
        lastMatrix = ActiveMatrix
        IsRotating = False
    End Sub

    Public Sub ApplyRotationMatrix()
        If IsRotating Then

            'Do some rotation according to start And current rotation vectors
            Dim rotVec As Vector3 = currentRotationVector - startRotationVector
            ' Calculate the length of the vector		
            Dim length = Vector3.Length(rotVec)

            If (length > 0.000001F) Then
                Dim rotationAxis As Vector3
                Vector3.Cross(currentRotationVector, startRotationVector, rotationAxis)
                If rotationAxis.LengthSquared < 0.000001F Then
                    Return
                End If
                rotationAxis = Vector3.Normalise(rotationAxis)

                rotationAxis.X *= -1
                rotationAxis.Y *= -1
                rotationAxis.Z *= -1

                Dim dotprod = Vector3.Dot(currentRotationVector, startRotationVector)
                IIf(dotprod > (1 - 0.0000000001), dotprod = 1.0, dotprod = dotprod)

                Dim rotationAngle = Math.Acos(dotprod) * 180.0F / Math.PI
                If Double.IsNaN(rotationAngle) Then Return

                Dim quat As Quaternion = Quaternion.CreateFromAxisAngle(rotationAxis, rotationAngle / 30)
                quat.Normalise()

                mActiveMatrix = lastMatrix * Matrix44.CreateFromQuaternion(quat)
                If Single.IsNaN(ActiveMatrix.R0C0) Then
                    Debug.Fail("Bad Matrix")
                End If
            End If
        End If
    End Sub

    Public Sub Reset()
        mActiveMatrix = Matrix44.Identity
        lastMatrix = mActiveMatrix
    End Sub

    Public Sub SetPitchRollYaw(x As Single, y As Single, z As Single)
        mActiveMatrix = Matrix44.CreateFromYawPitchRoll(y, x, z)
        lastMatrix = mActiveMatrix
    End Sub

    Public Sub AddRotation(angledeg As Single, axis As Vector3)
        mActiveMatrix = (lastMatrix * Matrix44.CreateFromAxisAngle(axis, angledeg))
        lastMatrix = mActiveMatrix
    End Sub

    ''' <summary>
    ''' Apply the translation matrix to the current transformation (zoom factor)
    ''' </summary>
    ''' <param name="reverse"></param>
    Private Sub ApplyTranslationMatrix(reverse As Boolean)
        Dim factor = IIf(reverse, -1.0F, 1.0F)
        Dim tx = transX + (currentTransX - startTransX) * TRANSLATION_FACTOR
        Dim ty = transY + (currentTransY - startTransY) * TRANSLATION_FACTOR
    End Sub

    ''' <summary>
    ''' Maps the mouse coordinates to points on a sphere
    ''' if the points lie outside the sphere, the z is 0, 
    ''' otherwise is \f$ \sqrt(r^2 - (x^2+y^2) ) \f$ where \f$ x,y \f$
    ''' </summary>
    Private Function ConvertXyToVector(x As Integer, y As Integer) As Vector3
        Dim d = x * x + y * y
        Dim radiusSquared = ballRAdius * ballRAdius
        If (d > radiusSquared) Then
            Return Vector3.Normalise(New Vector3(x, y, 0))
        Else
            Return Vector3.Normalise(New Vector3(x, y, Math.Sqrt(radiusSquared - d)))
        End If
    End Function
End Class
