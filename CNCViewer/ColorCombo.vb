Imports System.Collections.Generic
Imports System.Linq

Public Class ColorCombo
    Inherits ComboBox
    Private mSelectedColor As Color = Color.Empty
    Private supportedColors As New List(Of Color)

    Public Sub New()
        DropDownStyle = ComboBoxStyle.DropDownList
        DrawMode = DrawMode.OwnerDrawVariable
        FormattingEnabled = False
        ' Set these just to show that the background color is important here
        'ForeColor = Color.White
        'BackColor = Color.FromArgb(32, 32, 32)

        supportedColors.AddRange(New ColorConverter().GetStandardValues().OfType(Of Color)().
        Where(Function(c) Not c.IsSystemColor).ToArray())

        ' This call is required by the Windows Form Designer.
        'InitializeComponent()
    End Sub

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)
        If DesignMode OrElse Me.Items.Count > 0 Then Return

        ' Preserves a previous selection if any
        Dim tmpCurrentColor = mSelectedColor
        Me.DisplayMember = "Name"
        Me.DataSource = supportedColors
        If Not tmpCurrentColor.Equals(Color.Empty) Then
            mSelectedColor = tmpCurrentColor
            SelectedColor = mSelectedColor
        End If
    End Sub

    Private flags As TextFormatFlags = TextFormatFlags.NoPadding Or TextFormatFlags.VerticalCenter
    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        e.DrawBackground()
        If e.Index < 0 Then Return

        Dim itemColor = supportedColors(e.Index)
        Dim colorRect = New Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Height - 2, e.Bounds.Height - 2)

        Using colorBrush As New SolidBrush(itemColor)
            e.Graphics.FillRectangle(colorBrush, colorRect)

            Dim textRect = New Rectangle(New Point(colorRect.Right + 6, e.Bounds.Y), e.Bounds.Size)
            TextRenderer.DrawText(e.Graphics, itemColor.Name, e.Font, textRect, e.ForeColor, Color.Transparent, flags)
        End Using

        e.DrawFocusRectangle()
        MyBase.OnDrawItem(e)
    End Sub

    Protected Overrides Sub OnMeasureItem(e As MeasureItemEventArgs)
        e.ItemHeight = Font.Height + 4
        MyBase.OnMeasureItem(e)
    End Sub

    Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
        If SelectedIndex >= 0 Then mSelectedColor = supportedColors(SelectedIndex)
        MyBase.OnSelectedIndexChanged(e)
    End Sub

    Protected Overrides Sub OnSelectionChangeCommitted(e As EventArgs)
        mSelectedColor = supportedColors(SelectedIndex)
        MyBase.OnSelectionChangeCommitted(e)
    End Sub

    Public Function AddColor(clr As Color) As Integer
        DataSource = Nothing
        supportedColors.Add(clr)
        DataSource = supportedColors
        Return supportedColors.Count - 1
    End Function

    Public Property SelectedColor As Color
        Get
            Return mSelectedColor
        End Get
        Set
            mSelectedColor = Value
            'If Not IsHandleCreated Then Return

            If mSelectedColor.IsKnownColor Then
                SelectedItem = mSelectedColor
            Else
                If supportedColors Is Nothing Then Return
                Dim smallestDist As Double = 255
                Dim currentDist As Double = 0
                Dim bestMatch As Integer = 0
                Dim idx As Integer = -1

                For Each c As Color In supportedColors
                    idx += 1
                    currentDist = ColorDistance(c, Value)
                    If currentDist < smallestDist Then
                        smallestDist = currentDist
                        bestMatch = idx
                    End If
                Next
                If supportedColors.Count >= bestMatch Then
                    mSelectedColor = supportedColors(bestMatch)
                    SelectedItem = mSelectedColor
                End If
            End If
        End Set
    End Property

    Private Function ColorDistance(clrA As Color, clrB As Color) As Double
        Dim r As Integer = CInt(clrA.R) - clrB.R
        Dim g As Integer = CInt(clrA.G) - clrB.G
        Dim b As Integer = CInt(clrA.B) - clrB.B
        Return Math.Sqrt(r * r + g * g + b * b)
    End Function

    Public Function GetKnownColor(c As Color, Optional ByVal tolerance As Double = 0) As Color
        For Each clr As Color In supportedColors
            If ColorDistance(c, clr) <= tolerance Then Return clr
        Next
        Return c
    End Function

    Public Function ContainsColor(c As Color) As Integer
        Dim idx As Integer = 0
        For Each clr As Color In Me.Items
            If c.ToArgb = clr.ToArgb Then Return idx
            idx += 1
        Next
        Return -1
    End Function
End Class
