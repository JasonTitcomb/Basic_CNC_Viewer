Imports Abacus.DoublePrecision

Public Class BlendCalculatorXY
    Public P1 As Vector2
    Public P2 As Vector2
    Public IJK As Vector2
    Public Ctr As Vector2
    Private length As Double
    Private delta As Vector2
    Public Sub New(st As Vector2, en As Vector2)
        P1 = st
        P2 = en
        length = Vector2.Distance(P1, P2)
        delta = P2 - P1
    End Sub
    Public Sub TrimEnd(trimLen As Double)
        Dim lenFactor As Double = 1.0F - (trimLen / length)
        Dim newLen = length - trimLen
        If lenFactor >= 0 AndAlso lenFactor <= 1 Then
            P2 = Vector2.Lerp(P1, P2, lenFactor)
        End If
    End Sub

    Public Sub FindCenter(trimLen As Double, r As Double, direction As Double)
        Dim lenFactor As Double = 1.0F - (trimLen / length)
        Dim newLen = length - trimLen
        If direction <> 0 Then
            Dim rdelt = Vector2.Multiply(delta, CDbl(r / length))
            If direction = 1 Then 'perpendicular vector CCW CW
                IJK = New Vector2(-rdelt.Y, rdelt.X)
            Else
                IJK = New Vector2(rdelt.Y, -rdelt.X)
            End If
            Ctr = P2 + IJK
        End If
    End Sub

    Public Sub TrimStart(trimLen As Double)
        Dim delt As Vector2 = P1 - P2
        If delt.Length = 0 Then Return
        delt.Normalise()
        delt = Vector2.Multiply(delt, trimLen)
        P1 -= delt
    End Sub
End Class
