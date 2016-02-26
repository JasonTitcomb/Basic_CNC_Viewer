''' <summary>
''' Custom rectangle
''' </summary>
''' <remarks>
Public Class clsCadRect
    Private mX As Single
    Public Property X() As Single
        Get
            Return mX
        End Get
        Set(ByVal value As Single)
            mX = value
            mLeft = mX
            mRight = mLeft + mWidth
        End Set
    End Property
    Private my As Single
    Public Property Y() As Single
        Get
            Return my
        End Get
        Set(ByVal value As Single)
            my = value
            mTop = my + mHeight
            mBottom = my
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
            mTop = my + mHeight
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

    Public Function Contains(ByVal x As Single, ByVal y As Single) As Boolean
        Return x > Left AndAlso x < Right AndAlso y > Bottom AndAlso y < Top
    End Function

    Public Function IntersectsLine(ByVal p1 As PointF, ByVal p2 As PointF) As Boolean
        Return IntersectsLine(p1.X, p1.Y, p2.X, p2.Y)
    End Function

    Public Function IntersectsLine(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single) As Boolean
        'Trivial test completely inside
        If Me.Contains(x1, y1) OrElse Me.Contains(x2, y2) Then
            Return True
        End If
        'Trivial test outside
        If x1 < Me.Left AndAlso x2 < Me.Left Then
            Return False
        ElseIf x1 > Me.Right AndAlso x2 > Me.Right Then
            Return False
        ElseIf y1 < Me.Bottom AndAlso y2 < Me.Bottom Then
            Return False
        ElseIf y1 > Me.Top AndAlso y2 > Me.Top Then
            Return False
        End If

        'Trivial test vertical or horizontal
        If x1 = x2 Then
            Return True
        End If
        If y1 = y2 Then
            Return True
        End If

        Dim slope As Single = (y2 - y1) / (x2 - x1)
        Dim Yintercept As Single = y1 - (slope * x1)
        Dim iptX As Single
        Dim iptY As Single

        'Left edge
        iptX = Me.Left
        iptY = (slope * iptX) + Yintercept
        If iptY > Me.Bottom AndAlso iptY < Me.Top Then
            Return True
        End If

        'Right edge
        iptX = Me.Right
        If iptY > Me.Bottom AndAlso iptY < Me.Top Then
            Return True
        End If

        'Top edge
        iptY = Me.Top
        iptX = ((iptY - Yintercept) / slope)
        If iptX > Me.Left AndAlso iptX < Me.Right Then
            Return True
        End If

        'Bottom edge
        iptY = Me.Bottom
        iptX = ((iptY - Yintercept) / slope)
        If iptX > Me.Left AndAlso iptX < Me.Right Then
            Return True
        End If
        Return False
    End Function

End Class
