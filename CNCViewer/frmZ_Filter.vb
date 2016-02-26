Public Class frmZ_Filter

    Private mUpperLimit As Single
    Public Property UpperLimit() As Single
        Get
            Return mUpperLimit
        End Get
        Set(ByVal value As Single)
            mUpperLimit = value
        End Set
    End Property

    Private mLowerLimit As Single
    Public Property LowerLimit() As Single
        Get
            Return mLowerLimit
        End Get
        Set(ByVal value As Single)
            mLowerLimit = value
        End Set
    End Property

    Private Sub txtNumOnly_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUpper.KeyPress, txtLower.KeyPress
        If "-1234567890.".Contains(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = Chr(Keys.Back) Then
            If CType(sender, TextBox).Text.Length = 1 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = Chr(Keys.Delete) Then
            If CType(sender, TextBox).Text.Length = 1 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click, btnApply.Click
        Try
            If Single.Parse(txtUpper.Text, Globalization.NumberFormatInfo.InvariantInfo) <= Single.Parse(txtLower.Text, Globalization.NumberFormatInfo.InvariantInfo) Then
                MsgBox(My.Resources.Resources.UpperLimitMustBeGreaterThanLowerLimit, MsgBoxStyle.Information, My.Resources.Resources.FilterRangeError)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(My.Resources.Resources.ErrorParsingValues, MsgBoxStyle.Information, My.Resources.Resources.FilterRangeError)
            Exit Sub
        End Try
        Me.Close()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtUpper.Text = UpperLimit.ToString("###0.0###")
        txtLower.Text = LowerLimit.ToString("###0.0###")
    End Sub
End Class