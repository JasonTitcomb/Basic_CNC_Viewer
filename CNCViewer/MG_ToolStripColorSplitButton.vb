Public Class MG_ToolStripColorSplitButton
    Inherits ToolStripDropDownButton
    Private Enum Colors16
        None
        Black
        White
        Red
        DarkRed
        LightGreen
        Green
        DarkGreen
        LightBlue
        Blue
        Navy
        DarkBlue
        Cyan
        DarkCyan
        Yellow
        GreenYellow
        Fuchsia
        HotPink
        Indigo
    End Enum

    Private Sub LoadColors()
        Dim aColorName As String
        Dim dropDownItem As ToolStripMenuItem
        DropDownItems.Clear()
        For Each aColorName In System.Enum.GetNames(GetType(Colors16))
            dropDownItem = New ToolStripMenuItem(aColorName)
            dropDownItem.Name = aColorName
            Dim bmp As System.Drawing.Bitmap = New Drawing.Bitmap(16, 16)
            Using g As Graphics = Graphics.FromImage(bmp)
                Using br As New SolidBrush(Color.FromName(aColorName))
                    g.FillRectangle(br, 0, 0, 16, 16)
                    g.DrawRectangle(SystemPens.ControlText, 0, 0, bmp.Width, bmp.Height)
                    dropDownItem.Image = bmp
                End Using
            End Using
            dropDownItem.AutoSize = True
            DropDownItems.Add(dropDownItem)
        Next
    End Sub

    Private Sub SetSelectedColor(ByVal clr As Color)
        Dim clrName As String = clr.Name
        For Each t As ToolStripMenuItem In Me.DropDownItems
            If t.Name = clrName Then
                Image = t.Image
                Text = t.Text
                Exit For
            End If
        Next
    End Sub

    Private mSelectedColor As Color
    <System.ComponentModel.Browsable(False)> _
    Public Property SelectedColor() As Color
        Get
            Return mSelectedColor
        End Get
        Set(ByVal value As Color)
            mSelectedColor = value
            SetSelectedColor(value)
        End Set
    End Property

    Private mReplaceIconWithColor As Boolean = False
    Public Property ReplaceIconWithSelectedColor() As Boolean
        Get
            Return mReplaceiconWithColor
        End Get
        Set(ByVal value As Boolean)
            mReplaceiconWithColor = value
        End Set
    End Property

    Private mAllowNoneColor As Boolean = False
    Public Property AllowNoneColor() As Boolean
        Get
            Return mAllowNoneColor
        End Get
        Set(ByVal value As Boolean)
            mAllowNoneColor = value
            If Not mAllowNoneColor Then
                Me.DropDownItems.RemoveByKey("None")
            End If
        End Set
    End Property

    Private Sub MyDropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Me.DropDownItemClicked
        If ReplaceIconWithSelectedColor Then
            Image = e.ClickedItem.Image
            Text = e.ClickedItem.Text
        End If
        If e.ClickedItem.Text = "None" Then
            mSelectedColor = Nothing
        Else
            mSelectedColor = Color.FromName(e.ClickedItem.Text)
        End If
    End Sub

    Public Sub New()
        LoadColors()
    End Sub
End Class
