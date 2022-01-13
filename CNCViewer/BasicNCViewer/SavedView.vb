Imports Abacus.SinglePrecision

<Serializable()>
Public Class SavedView
    Sub New()
    End Sub
    Sub New(m As Matrix44, rect As RectangleF, rotatePoint As Vector3)
        Me.m = m
        Me.rect = rect
        Me.rotatePoint = rotatePoint
    End Sub
    Public m As Matrix44
    Public rect As RectangleF
    Public rotatePoint As Vector3
End Class