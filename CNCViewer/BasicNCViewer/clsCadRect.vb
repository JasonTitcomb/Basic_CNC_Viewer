''' <remarks>
''' Jason Titcomb
''' www.CncEdit.com
''' https://github.com/JasonTitcomb/Basic_CNC_Viewer/blob/master/LICENSE.md
''' </remarks>
Public Class clsCadRect
    Private mXval As Single
    Public Property X() As Single
        Get
            Return mXval
        End Get
        Set(ByVal value As Single)
            mXval = value
            mLeft = mXval
            mRight = mLeft + mWidth
        End Set
    End Property
    Private mYval As Single
    Public Property Y() As Single
        Get
            Return mYval
        End Get
        Set(ByVal value As Single)
            mYval = value
            mTop = mYval + mHeight
            mBottom = mYval
        End Set
    End Property
    Private mLeft As Single
    Public ReadOnly Property Left() As Single
        Get
            Return mLeft
        End Get
    End Property
    Private mRight As Single
    Public ReadOnly Property Right() As Single
        Get
            Return mRight
        End Get
    End Property
    Private mWidth As Single
    Public Property Width() As Single
        Get
            Return mWidth
        End Get
        Set(ByVal value As Single)
            mWidth = value
            mRight = mLeft + mWidth
        End Set
    End Property
    Private mHeight As Single
    Public Property Height() As Single
        Get
            Return mHeight
        End Get
        Set(ByVal value As Single)
            mHeight = value
            mTop = mYval + mHeight
        End Set
    End Property
    Private mTop As Single
    Public ReadOnly Property Top() As Single
        Get
            Return mTop
        End Get
    End Property
    Private mBottom As Single

    Public ReadOnly Property Bottom() As Single
        Get
            Return mBottom
        End Get
    End Property
    Public ReadOnly Property CenterX As Single
        Get
            Return (Left + Right) / 2
        End Get
    End Property
    Public ReadOnly Property CenterY As Single
        Get
            Return (Top + Bottom) / 2
        End Get
    End Property
    Public Sub New()
        X = 0
        Y = 0
        Width = 0
        Height = 0
    End Sub

    Public Sub New(ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single)
        Me.X = x
        Me.Y = y
        Me.Width = width
        Me.Height = height
    End Sub
    Public Function Contains(p1 As PointF) As Boolean
        Return p1.X > Left AndAlso p1.X < Right AndAlso p1.Y > Bottom AndAlso p1.Y < Top
    End Function

    Public Function Contains(ByVal x As Single, ByVal y As Single) As Boolean
        Return x > Left AndAlso x < Right AndAlso y > Bottom AndAlso y < Top
    End Function

    Public Function IntersectsLine(p1 As PointF, p2 As PointF) As Single
        Return IntersectsLine(p1.X, p1.Y, p2.X, p2.Y)
    End Function

    Public Function IntersectsLine(x1 As Single, y1 As Single, x2 As Single, y2 As Single) As Single
        'Trivial test completely inside
        If Contains(x1, y1) Then
            Return 0
        End If
        If Contains(x2, y2) Then
            Return 1
        End If

        'Trivial test outside
        If x1 < Left AndAlso x2 < Left Then
            Return -1
        ElseIf x1 > Right AndAlso x2 > Right Then
            Return -1
        ElseIf y1 < Bottom AndAlso y2 < Bottom Then
            Return -1
        ElseIf y1 > Top AndAlso y2 > Top Then
            Return -1
        End If
        Dim ctrX = (Left + Right) / 2
        Dim ctrY = (Top + Bottom) / 2
        'Trivial test vertical or horizontal
        If x1 = x2 Then
            Return mag(ctrX, ctrY, x1, y1, x2, y2)
        End If
        If y1 = y2 Then
            Return mag(ctrX, ctrY, x1, y1, x2, y2)
        End If

        Dim slope As Single = (y2 - y1) / (x2 - x1)
        Dim Yintercept As Single = y1 - (slope * x1)
        Dim iptX As Single
        Dim iptY As Single

        'Left edge of selrect
        iptX = Left
        iptY = (slope * iptX) + Yintercept
        If iptY > Bottom AndAlso iptY < Top Then
            Return mag(ctrX, ctrY, x1, y1, x2, y2)
        End If

        'Right edge
        iptX = Right
        If iptY > Bottom AndAlso iptY < Top Then
            Return mag(ctrX, ctrY, x1, y1, x2, y2)
        End If

        'Top edge
        iptY = Top
        iptX = ((iptY - Yintercept) / slope)
        If iptX > Left AndAlso iptX < Right Then
            Return mag(ctrX, ctrY, x1, y1, x2, y2)
        End If

        'Bottom edge
        iptY = Bottom
        iptX = ((iptY - Yintercept) / slope)
        If iptX > Left AndAlso iptX < Right Then
            Return mag(ctrX, ctrY, x1, y1, x2, y2)
        End If
        Return -1
    End Function
    Private Function mag(ctrx As Single, ctry As Single, x1 As Single, y1 As Single, x2 As Single, y2 As Single) As Single
        Dim d1 = Distance2(ctrx, ctry, x1, y1)
        Dim d2 = Distance2(ctrx, ctry, x2, y2)
        Return d1 / (d1 + d2)
    End Function

    Private Function Distance2(X1 As Single, Y1 As Single, x2 As Single, y2 As Single) As Single
        Return Math.Sqrt(((X1 - x2) ^ 2) + ((Y1 - y2) ^ 2))
    End Function

End Class
