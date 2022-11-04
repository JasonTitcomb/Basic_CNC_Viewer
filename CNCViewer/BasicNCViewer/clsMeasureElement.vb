
Imports System.Collections.Generic
Imports System.Drawing.Drawing2D
Imports Abacus.SinglePrecision
Partial Public Class clsMeasurement
    Private fromKeyPoint As Vector3
    Private toKeyPoint As Vector3
    Private newToKp(3) As Vector3

    Private el1Type As Motion
    Private el2Type As Motion
    Private onKeypoint1 As Boolean
    Private onKeypoint2 As Boolean
    Public Distance(3) As Single
    Public Angle As Single
    Private mKpts1(2) As Vector3
    Private mKpts2(2) As Vector3
    Private measurePen As New Pen(Color.White, 0)
    Private NullVec3 As New Vector3(Single.MinValue, Single.MinValue, Single.MinValue)
    Private mExtendTo As Vector3
    Private mExtendFrom As Vector3
    Private suffix As String = String.Empty
    Private mEl1 As clsMeasureElement
    Private mEl2 As clsMeasureElement

    Private Class clsMeasureElement
        Public ElementType As Motion
        Public OnKeypoint As Boolean
        Public KeyPoint As Vector3
        Public MousePoint As Vector3
        Public KeyPoints(2) As Vector3
        Public AllKeyPoints As List(Of Vector3)
        Public MotionRec As clsMotionRecord
        Public Sub New(kpSet As clsDisplayLists3D)
            MotionRec = kpSet.HighlightElement
            ElementType = kpSet.HighlightElement.MotionType
            OnKeypoint = kpSet.OnKeypoint
            KeyPoint = kpSet.HighlightKeypoint3D
            MousePoint = kpSet.PointOnKeypoint3D
            Array.Copy(kpSet.Item.Keypoints, KeyPoints, 3)
            AllKeyPoints = kpSet.Item.VectorList3D
        End Sub
        Public Function IsLinear() As Boolean
            Return ElementType = Motion.LINE
        End Function
    End Class
    Public Enum DimType
        NONE
        LINEAR
        ANGLE
    End Enum

    Private mDimType As DimType = DimType.NONE
    Public Sub Draw(g As Graphics, viewMat As Matrix44, backcolor As Color, fnt As Font, scale As Single, masterScale As Single)
        If mDimType = DimType.NONE Then Return 'not ready

        Dim invColor = Color.FromArgb(Not backcolor.R, Not backcolor.G, Not backcolor.B)
        Dim unitString As String = "in"
        Dim outputValue As String = String.Empty
        Dim fontHeight As Integer = fnt.Height
        Dim textrect As RectangleF
        Dim fpt As PointF
        Dim unitAdjustment As Single 'val *= 25.4F
        Dim units = mEl1.MotionRec.Units
        measurePen.Color = invColor
        Select Case units
            Case MachineUnits.ENGLISH
                unitString = "in"
                unitAdjustment = 1
            Case MachineUnits.METRIC
                unitString = "mm"
                unitAdjustment = 25.4F
        End Select

        Dim idx As Integer = 0
        Dim alignment As String = " 3D"
        'XYZ
        'XY
        'X
        'Y
        'Z
        If Math.Round(viewMat.Forward.X, 4) = -1 Then 'left
            alignment = " Z"
            idx = 1
        End If
        If Math.Round(viewMat.Forward.Y, 4) = -1 Then 'right
            alignment = " Z"
            idx = 1
        End If
        If Math.Round(viewMat.Forward.Z, 4) = -1 Then 'top
            alignment = " XY"
            idx = 3
        End If


        'Draw the overlay.
        Using textBrush As New SolidBrush(invColor)
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            measurePen.EndCap = LineCap.ArrowAnchor
            measurePen.StartCap = LineCap.ArrowAnchor
            measurePen.Width = ((1 / g.DpiX) / scale) * 3
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            measurePen.DashStyle = DashStyle.Solid

            Select Case mDimType
                Case DimType.LINEAR
                    outputValue = Math.Round(((Distance(idx) * unitAdjustment) / masterScale), 4) & unitString & suffix & alignment
                    'Transform the points to the view
                    Dim textsize = g.MeasureString(outputValue, fnt)
                    Dim startMeasurePoint = Matrix44.Transform(viewMat, fromKeyPoint)
                    Dim endMeasurePoint = Matrix44.Transform(viewMat, newToKp(idx))
                    'Draw the text half way between sp and ep
                    fpt = New PointF((startMeasurePoint.X + endMeasurePoint.X) / 2 - textsize.Width / 2, -(textsize.Height / 2) - (startMeasurePoint.Y + endMeasurePoint.Y) / 2)
                    textrect = New RectangleF(fpt, textsize)

                    'If this is a linear dimension then a simple line will do
                    g.DrawLine(measurePen, startMeasurePoint.X, startMeasurePoint.Y, endMeasurePoint.X, endMeasurePoint.Y)
                Case DimType.ANGLE
                    outputValue = Math.Round(Angle, 3) & "deg"
                    Dim startMeasurePoint = Matrix44.Transform(viewMat, fromKeyPoint)
                    Dim endMeasurePoint = Matrix44.Transform(viewMat, toKeyPoint)
                    Dim textsize = g.MeasureString(outputValue, fnt)

                    'Draw the text half way between sp and ep
                    fpt = New PointF((startMeasurePoint.X + endMeasurePoint.X) / 2 - textsize.Width / 2, -(textsize.Height / 2) - (startMeasurePoint.Y + endMeasurePoint.Y) / 2)
                    textrect = New RectangleF(fpt, textsize)

                    'If this is a linear dimension then a simple line will do
                    g.DrawLine(measurePen, startMeasurePoint.X, startMeasurePoint.Y, endMeasurePoint.X, endMeasurePoint.Y)
            End Select

            'Extension line
            If mExtendTo <> NullVec3 Then
                Dim expTo = Matrix44.Transform(viewMat, mExtendTo)
                Dim expFrom = Matrix44.Transform(viewMat, mExtendFrom)
                measurePen.Width = -1
                measurePen.DashStyle = DashStyle.Dot
                measurePen.Color = Color.FromArgb(100, Not backcolor.R, Not backcolor.G, Not backcolor.B)
                measurePen.EndCap = LineCap.NoAnchor
                measurePen.StartCap = LineCap.NoAnchor
                g.SmoothingMode = Drawing2D.SmoothingMode.None
                g.DrawLine(measurePen, expTo.X, expTo.Y, expFrom.X, expFrom.Y)
            End If
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.ScaleTransform(1, -1)
            Using fillbrush = New SolidBrush(backcolor)
                g.FillRectangle(fillbrush, textrect)
            End Using
            g.DrawString(outputValue, fnt, textBrush, fpt)
            g.ScaleTransform(1, -1)
        End Using
    End Sub

    Public Function SetKeypoint(kpSet As clsDisplayLists3D) As DimType
        Distance = {0, 0, 0, 0}
        Angle = 0
        mDimType = DimType.NONE
        If mEl1 IsNot Nothing AndAlso mEl2 IsNot Nothing Then
            mEl1 = Nothing
            mEl2 = Nothing
        End If
        'cases
        '1> single element
        '2> 2 elements
        '3> 2 keypoints
        '4> 1 element and one keypoint

        ' If the view is orthographic then pin the Z

        If mEl1 Is Nothing Then 'first kp not set yet
            mEl1 = New clsMeasureElement(kpSet)
        Else
            If mEl2 Is Nothing Then 'second kp not set yet
                mEl2 = New clsMeasureElement(kpSet)
            Else 'second kp is previously set so swap with first
                mEl1 = mEl2
                mEl2 = Nothing
            End If
        End If

        'line to line
        'line to arc
        'arc to arc

        suffix = ""
        If mEl1 IsNot Nothing AndAlso mEl2 IsNot Nothing Then
            If mEl1.OnKeypoint And mEl2.OnKeypoint Then
                fromKeyPoint = mEl1.KeyPoint
                toKeyPoint = mEl2.KeyPoint
            End If

            If Not mEl1.OnKeypoint And Not mEl2.OnKeypoint Then
                If Not IsAngleBetween(mEl1, mEl2) Then
                    SetNearestKpoints(mEl1, mEl2)
                    suffix = " min"
                End If
            End If

            If mEl1.OnKeypoint And Not mEl2.OnKeypoint Then
                fromKeyPoint = mEl1.KeyPoint
                toKeyPoint = PointToLineDist(fromKeyPoint, mEl2.KeyPoints)
                suffix = " perp"
            End If

            If Not mEl1.OnKeypoint And mEl2.OnKeypoint Then
                fromKeyPoint = mEl2.KeyPoint
                toKeyPoint = PointToLineDist(fromKeyPoint, mEl1.KeyPoints)
                suffix = " perp"
            End If

            If mDimType <> DimType.ANGLE Then
                newToKp(0) = New Vector3(toKeyPoint.X, toKeyPoint.Y, toKeyPoint.Z)
                Distance(0) = Vector3.Distance(fromKeyPoint, toKeyPoint)
                If Distance(0) > 0 Then
                    newToKp(1) = New Vector3(fromKeyPoint.X, toKeyPoint.Y, toKeyPoint.Z)
                    Distance(1) = Vector3.Distance(fromKeyPoint, newToKp(1))
                    newToKp(2) = New Vector3(toKeyPoint.X, fromKeyPoint.Y, toKeyPoint.Z)
                    Distance(2) = Vector3.Distance(fromKeyPoint, newToKp(2))
                    newToKp(3) = New Vector3(toKeyPoint.X, toKeyPoint.Y, fromKeyPoint.Z)
                    Distance(3) = Vector3.Distance(fromKeyPoint, newToKp(3))
                    mDimType = DimType.LINEAR
                End If
            End If
        End If
        Return mDimType
    End Function

    Private Function IsAngleBetween(el1 As clsMeasureElement, el2 As clsMeasureElement) As Boolean
        If el1.IsLinear And el2.IsLinear Then
            Dim v1 = Vector3.Subtract(el1.KeyPoints(0), el1.KeyPoints(2))
            Dim v2 = Vector3.Subtract(el2.KeyPoints(0), el2.KeyPoints(2))
            Angle = AngleBetween(v1, v2)

            If Angle <> 0 AndAlso Angle <> 180 AndAlso Angle <> 360 Then
                mDimType = DimType.ANGLE
                fromKeyPoint = el1.MousePoint
                toKeyPoint = el2.MousePoint
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub SetNearestKpoints(el1 As clsMeasureElement, el2 As clsMeasureElement)
        Dim minDistance = Single.MaxValue 'Vector3.Distance(kp1, kp2)
        For Each k1 In el1.AllKeyPoints
            For Each k2 In el2.AllKeyPoints
                If Vector3.Distance(k1, k2) < minDistance Then
                    fromKeyPoint = k1
                    toKeyPoint = k2
                    minDistance = Vector3.Distance(fromKeyPoint, toKeyPoint)
                End If
            Next
        Next

        Distance(0) = Vector3.Distance(fromKeyPoint, toKeyPoint)
    End Sub

    Private Function NearestKpoint(p As Vector3, ps() As Vector3) As Vector3
        Dim retvect As Vector3 = ps(0)
        Dim minDistance = Vector3.Distance(p, retvect)
        For Each k1 In ps
            If Vector3.Distance(k1, retvect) < minDistance Then
                minDistance = Vector3.Distance(k1, retvect)
                retvect = k1
            End If
        Next
        Return retvect
    End Function

    Private Function AngleBetween(ByVal vector1 As Vector3, ByVal vector2 As Vector3) As Single
        If vector1.Length = 0 Or vector2.Length = 0 Then
            Return 0
        End If
        Dim theta As Double

        vector1.Normalise()
        vector2.Normalise()
        Dim ratio As Double = Vector3.Dot(vector1, vector2)

        If ratio < 0 Then
            theta = Math.PI - 2.0 * Math.Asin((-vector1 - vector2).Length / 2.0)
        Else
            theta = 2.0 * Math.Asin((vector1 - vector2).Length / 2.0)
        End If

        Return (theta * (180.0 / Math.PI))
    End Function

    Public Sub Reset()
        mEl1 = Nothing
        mEl2 = Nothing
        Distance = {0, 0, 0, 0}
        fromKeyPoint = NullVec3
        toKeyPoint = NullVec3
        mDimType = DimType.NONE
    End Sub

    Private Function PointToLineDist(p As Vector3, kpoints() As Vector3) As Vector3
        Dim p1 = kpoints(0)
        Dim p2 = kpoints(2)

        Dim u As Vector3 = p2 - p1
        Dim pq = p - p1
        Dim w2 = pq - Vector3.Multiply(u, Vector3.Dot(pq, u) / u.LengthSquared)
        Dim perpP = p - w2
        mExtendTo = NullVec3
        If (perpP - p1).Length > u.Length Or (perpP - p2).Length > u.Length Then
            Dim dist1 = Vector3.Distance(perpP, kpoints(0))
            Dim dist2 = Vector3.Distance(perpP, kpoints(2))
            mExtendTo = If(dist1 < dist2, kpoints(0), kpoints(2))
            mExtendFrom = perpP
        End If
        Return perpP
    End Function
End Class


