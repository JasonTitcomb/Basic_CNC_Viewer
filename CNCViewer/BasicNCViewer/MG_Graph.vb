Imports System.Collections.Generic

Public Class MG_Graph
    Inherits Control
    Private mColorBars As New List(Of clsColorBar)
    Private mBorder As Rectangle
    Private mForecolorPen As Pen
    Private mBarPen As Pen
    Private mBarBrush As Brush
    Private mBarTextBrush As Brush
    Private mBar As Rectangle
    Private mMaxWidth As Integer
    Private mPadding As Integer = 3

    Public Sub AddColorBar(ByVal clr As Color, ByVal txt As String, ByVal val As Integer)
        mColorBars.Add(New clsColorBar(clr, txt, val))
    End Sub
    Public Sub ClearAllBars()
        mColorBars.Clear()
    End Sub
    Private Sub MG_Graph_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawRectangle(mForecolorPen, mBorder)
        mBar.Y = mPadding

        Dim maxBar As Integer
        Dim barScale As Double
        For Each b As clsColorBar In mColorBars
            maxBar = Math.Max(maxBar, CInt(b.Value))
        Next
        barScale = mMaxWidth / maxBar

        For Each b As clsColorBar In mColorBars
            mBarPen.Color = b.Color
            mBar.Width = CInt(barScale * b.Value)
            e.Graphics.DrawRectangle(mBarPen, mBar)
            e.Graphics.FillRectangle(b.Brush, mBar)
            e.Graphics.DrawRectangle(mForecolorPen, mBar)
            e.Graphics.DrawString(b.Text, Me.Font, mBarTextBrush, mBar.Left + mPadding, mBar.Top)
            mBar.Y += mBar.Height + mPadding
        Next
    End Sub

    Private Sub MG_Graph_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        mBorder = ClientRectangle
        mBorder.Inflate(-1, -1)
        mForecolorPen.Color = Me.ForeColor
        mBar.X = mPadding
        mBar.Y = mPadding
        mBar.Height = Me.FontHeight + 2
        mMaxWidth = Me.Width - mPadding * 2
        Me.Refresh()
    End Sub

    Public Sub New()
        mForecolorPen = New Pen(Me.ForeColor)
        mBarPen = New Pen(Me.ForeColor)
        mBarBrush = New SolidBrush(Color.AliceBlue)
        mBarTextBrush = New SolidBrush(Me.ForeColor)
    End Sub
End Class
