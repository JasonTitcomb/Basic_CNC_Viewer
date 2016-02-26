Public Class ColorCombo
    Inherits System.Windows.Forms.ComboBox
    Private mSelectedColor As Color = Nothing
    Private Sub ColorCombo_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        Try
            If e.Index < 0 Then
                e.DrawBackground()
                e.DrawFocusRectangle()
                Exit Try
            End If
            ' Get the Color object from the Items list
            Dim aColor As Color = CType(Me.Items(e.Index), Color)

            ' get a square using the bounds height
            Dim rect As Rectangle = New Rectangle _
               (4, e.Bounds.Top + 2, CInt(e.Bounds.Height * 1.5), _
               e.Bounds.Height - 4)


            ' call these methods first
            e.DrawBackground()
            e.DrawFocusRectangle()

            Dim textBrush As Brush
            ' change brush color if item is selected
            If e.State = Windows.Forms.DrawItemState.Selected Then
                textBrush = Brushes.White
            Else
                textBrush = Brushes.Black
            End If

            ' draw a rectangle and fill it
            Dim p As New Pen(aColor)
            Dim br As New SolidBrush(aColor)
            e.Graphics.DrawRectangle(p, rect)
            e.Graphics.FillRectangle(br, rect)

            ' draw a border
            rect.Inflate(1, 1)
            e.Graphics.DrawRectangle(Pens.Black, rect)
            ' draw the Color name
            e.Graphics.DrawString(aColor.Name, Me.Font, textBrush, rect.Width + 5, ((e.Bounds.Height - Me.Font.Height) \ 2) + e.Bounds.Top)

            p.Dispose()
            br.Dispose()

        Catch ex As Exception
            e.DrawBackground()
            e.DrawFocusRectangle()
        End Try
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Try
            Dim aColorName As String
            Items.Clear()
            Me.BeginUpdate()
            For Each aColorName In System.Enum.GetNames(GetType(System.Drawing.KnownColor))
                If aColorName.StartsWith("Active") _
                Or aColorName.StartsWith("Button") _
                Or aColorName.StartsWith("Window") _
                Or aColorName.StartsWith("Inactive") _
                Or aColorName.StartsWith("HighlightText") _
                Or aColorName.StartsWith("Control") _
                Or aColorName.StartsWith("Scroll") _
                Or aColorName.StartsWith("Menu") _
                Or aColorName.StartsWith("Gradient") _
                Or aColorName.StartsWith("App") _
                Or aColorName.StartsWith("Desktop") _
                Or aColorName.StartsWith("GrayText") _
                Or aColorName.StartsWith("HotTrack") _
                Or aColorName.StartsWith("Info") Then
                Else
                    Me.Items.Add(Color.FromName(aColorName))
                End If

            Next
            Me.EndUpdate()
        Catch
        End Try
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    ''' <summary>
    ''' Returns a named color if one matches else it returns the passed color
    ''' </summary>
    Public Function GetKnownColor(ByVal c As Color, Optional ByVal tolerance As Double = 0) As Color
        For Each clr As Color In Me.Items
            If ColorDistance(c, clr) <= tolerance Then
                Return clr
            End If
        Next
        Return c
    End Function

    ''' <summary>
    ''' Returns index if one matches
    ''' </summary>
    Public Function ContainsColor(ByVal c As Color) As Integer
        Dim idx As Integer = 0
        For Each clr As Color In Me.Items
            If c.ToArgb = clr.ToArgb Then
                Return idx
            End If
            idx += 1
        Next
        Return -1
    End Function

    Sub ColorCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectedIndexChanged
        If SelectedIndex >= 0 Then
            mSelectedColor = CType(SelectedItem, Color)
        End If
    End Sub
    Public Property SelectedColor() As Color
        Get
            'If mSelectedColor.Name = "Transparent" Then
            '    Return Color.Black
            'End If
            Return mSelectedColor
        End Get

        Set(ByVal value As Color)
            Try
                Dim smallestDist As Double = 255
                Dim currentDist As Double = 0
                Dim bestMatch As Color
                For Each c As Color In Me.Items
                    currentDist = ColorDistance(c, value)
                    If currentDist < smallestDist Then
                        smallestDist = currentDist
                        bestMatch = c
                    End If
                Next
                Me.SelectedItem = bestMatch
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End Set
    End Property

    Private Function ColorDistance(ByRef clrA As Color, ByRef clrB As Color) As Double
        Dim r As Long, g As Long, b As Long
        r = CShort(clrA.R) - CShort(clrB.R)
        g = CShort(clrA.G) - CShort(clrB.G)
        b = CShort(clrA.B) - CShort(clrB.B)
        Return Math.Sqrt(r * r + g * g + b * b)
    End Function
End Class
