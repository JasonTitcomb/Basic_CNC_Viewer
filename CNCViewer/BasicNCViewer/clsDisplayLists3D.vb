Imports System.Collections.Generic
Imports Abacus.SinglePrecision

Public Class clsDisplayLists3D
    Public DisplayList As New List(Of clsDisplayList3D)
    Public Item As clsDisplayList3D
    Private fourthAxisVector As Vector3
    Private fourthAxisDirection As Integer
    Private NullVector3 As New Vector3(0, 0, 0)
    Public PointOnKeypoint3D As Vector3
    Public PointOnKeypoint2D As Vector3
    Public HighlightKeypoint3D As Vector3
    Public KeyPointSet2D(2) As Vector3
    Public HighlightElement As clsMotionRecord
    Private masterScale As Single
    Public Property HasKeypoints As Boolean
    Public Property OnKeypoint As Boolean
    Public Property PointOn As Boolean
    Public Property HighlightKeypoint2D As PointF

    Public Sub Init(axis As Vector3, direction As Integer, scale As Single)
        fourthAxisVector = axis
        fourthAxisDirection = direction
        masterScale = scale
        Clear()
    End Sub

    Public Function CanDrawTarget() As Boolean
        Return PointOn Or OnKeypoint
    End Function

    Public Function HitTest(hitIndex As Integer, selrect As RectangleF, viewMatrix As Matrix44) As Boolean
        Dim bestMinDist As Single = Single.MaxValue
        Dim thisPointOn2d As Vector3

        OnKeypoint = False
        PointOn = False
        PointOnKeypoint3D = NullVector3
        If hitIndex < 0 OrElse DisplayList.Count = 0 Then Return False
        If hitIndex >= DisplayList.Count Then Return False
        Item = DisplayList(hitIndex)
        Dim locateRect As New clsCadRect(selrect.X, selrect.Y, selrect.Width, selrect.Height)
        Dim mouseCenter As New Vector3(locateRect.CenterX, locateRect.CenterY, 0)

        SetKeypointSetToView(viewMatrix)

        'If this is a line then there are just 3 keypoints.
        'If this is an arc or a rapid with dogleg then there are more.
        If Item.VectorList3D.Count > 0 Then
            For r As Integer = 0 To Item.VectorList3D.Count - 2
                Dim mv1 = Item.VectorList3D(r)
                Dim mv2 = Item.VectorList3D(r + 1)
                Dim dv1 = Vector3.Transform(mv1, viewMatrix)
                Dim dv2 = Vector3.Transform(mv2, viewMatrix)

                Dim mag = locateRect.IntersectsLine(dv1.X, dv1.Y, dv2.X, dv2.Y)
                'if mag is 0 then the start of the segment is inside the selection rectangle
                'If mag is 1 then the end of a segment is inside the selection rectangle
                If mag >= 0 And mag <= 1 Then 'point on
                    thisPointOn2d = Vector3.Lerp(dv1, dv2, mag)
                    'if we have a point on then keep testing to see if there is a better hit
                    'If PointOn Then 'already has a keypoint
                    Dim thisDist = Vector3.Distance(mouseCenter, thisPointOn2d)
                    If PointOn And thisDist < bestMinDist Then 'better solution
                        PointOnKeypoint3D = Vector3.Lerp(mv1, mv2, mag)
                        PointOnKeypoint2D = thisPointOn2d
                        bestMinDist = thisDist 'new best
                    Else
                        PointOnKeypoint3D = Vector3.Lerp(mv1, mv2, mag)
                        PointOnKeypoint2D = thisPointOn2d
                        HighlightKeypoint2D = New PointF(PointOnKeypoint2D.X, PointOnKeypoint2D.Y)
                        HighlightElement = Item.MotionParent
                        PointOn = True
                        bestMinDist = Vector3.Distance(mouseCenter, thisPointOn2d)
                        'Exit For
                    End If
                End If
            Next
        End If
        IsOverKeypoint(selrect)

        Return PointOn Or OnKeypoint()
    End Function

    Public Sub SetKeypointSetToView(viewMatrix As Matrix44)
        'Transform the model points to view points and test for a hit
        KeyPointSet2D(0) = Vector3.Transform(Item.Keypoints(0), viewMatrix)
        KeyPointSet2D(1) = Vector3.Transform(Item.Keypoints(1), viewMatrix)
        KeyPointSet2D(2) = Vector3.Transform(Item.Keypoints(2), viewMatrix)
        HasKeypoints = True
    End Sub
    Public Function IsOverKeypoint(selrect As RectangleF) As Boolean
        Dim locateRect As New clsCadRect(selrect.X, selrect.Y, selrect.Width, selrect.Height)
        OnKeypoint = False

        Dim mouseCenter As New Vector3(locateRect.CenterX, locateRect.CenterY, 0)
        HighlightKeypoint3D = NullVector3

        For r = 0 To 2
            If locateRect.Contains(KeyPointSet2D(r).X, KeyPointSet2D(r).Y) Then
                HighlightKeypoint3D = Item.Keypoints(r)
                PointOnKeypoint3D = HighlightKeypoint3D
                HighlightElement = Item.MotionParent
                OnKeypoint = True
            End If
        Next
        Return OnKeypoint
    End Function

    Public Sub AddList(mr As clsMotionRecord)
        Item = New clsDisplayList3D(mr)
        DisplayList.Add(Item)
        SetKeyPoints(mr, masterScale)
    End Sub
    Public Sub AddVector(v As Vector3)
        Item.VectorList3D.Add(v)
    End Sub
    Public Sub Clear()
        DisplayList.Clear()
        Item = Nothing
    End Sub
    Private Sub SetKeyPoints(mr As clsMotionRecord, masterScale As Single)
        If mr Is Nothing Then Exit Sub

        Dim prevRotMat = Matrix44.Identity()
        Dim curRotMat = Matrix44.Identity()
        prevRotMat = Matrix44.CreateFromAxisAngle(fourthAxisVector, mr.OldRotaryPos * -fourthAxisDirection)
        curRotMat = Matrix44.CreateFromAxisAngle(fourthAxisVector, mr.NewRotaryPos * -fourthAxisDirection)


        With Item
            Select Case mr.MotionType
                Case Motion.CCARC, Motion.CWARC
                    .Keypoints(0) = Vector3.Transform(New Vector3(mr.XYZold.X, mr.XYZold.Y, mr.XYZold.Z), prevRotMat)
                    .Keypoints(2) = Vector3.Transform(New Vector3(mr.XYZpos.X, mr.XYZpos.Y, mr.XYZpos.Z), curRotMat)
                    .Keypoints(1) = Vector3.Transform(New Vector3(mr.XYZcenter.X, mr.XYZcenter.Y, mr.XYZcenter.Z), curRotMat)
                Case Motion.LINE, Motion.RAPID
                    'This is a possible condition where the rot matrix is in transition
                    .Keypoints(0) = Vector3.Transform(New Vector3(mr.XYZold.X, mr.XYZold.Y, mr.XYZold.Z), prevRotMat)
                    .Keypoints(2) = Vector3.Transform(New Vector3(mr.XYZpos.X, mr.XYZpos.Y, mr.XYZpos.Z), curRotMat)
                    .Keypoints(1) = Vector3.Transform(New Vector3((mr.XYZpos.X + mr.XYZold.X) / 2, (mr.XYZpos.Y + mr.XYZold.Y) / 2, (mr.XYZpos.Z + mr.XYZold.Z) / 2), curRotMat)
                Case Else
                    .Keypoints(0) = Vector3.Transform(New Vector3(mr.XYZpos.X, mr.XYZpos.Y, mr.XYZold.Z), prevRotMat)
                    .Keypoints(2) = Vector3.Transform(New Vector3(mr.XYZpos.X, mr.XYZpos.Y, mr.XYZpos.Z), curRotMat)
                    .Keypoints(1) = Vector3.Transform(New Vector3(mr.XYZpos.X, mr.XYZpos.Y, (mr.XYZpos.Z + mr.XYZold.Z) / 2), curRotMat)
            End Select
            .Keypoints(0) = Vector3.Multiply(.Keypoints(0), masterScale)
            .Keypoints(1) = Vector3.Multiply(.Keypoints(1), masterScale)
            .Keypoints(2) = Vector3.Multiply(.Keypoints(2), masterScale)
        End With
    End Sub

End Class

Public Class clsDisplayList3D
    Public MotionParent As clsMotionRecord
    Public VectorList3D As List(Of Vector3)
    Public Keypoints(2) As Vector3
    Public Sub New(mr As clsMotionRecord)
        MotionParent = mr
        VectorList3D = New List(Of Vector3)
    End Sub
    Public Overrides Function ToString() As String
        Return MotionParent.Codestring
    End Function
End Class