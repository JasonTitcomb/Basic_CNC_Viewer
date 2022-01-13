Public Class frmQuickPick
    Public Event OnSingleSelect(ByVal index As Integer)

    Private Sub lstQuickPick_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles lstQuickPick.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub lstQuickPick_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles lstQuickPick.SelectedIndexChanged
        If lstQuickPick.SelectedIndex >= 0 Then
            RaiseEvent OnSingleSelect(lstQuickPick.SelectedIndex)
        End If
    End Sub
End Class