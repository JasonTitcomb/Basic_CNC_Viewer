Friend Class frmToolLayers
    Private Sub tvTools_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvTools.AfterCheck
        If e.Action = TreeViewAction.Unknown Then Return
        If My.Computer.Keyboard.ShiftKeyDown Then
            For Each nd As TreeNode In tvTools.Nodes
                If nd.Equals(e.Node) Then
                    Exit For
                End If
                nd.Checked = e.Node.Checked
            Next
        End If
    End Sub

    'Private Sub tvTools_BeforeSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvTools.BeforeSelect
    '    e.Cancel = True
    'End Sub

    Private Sub btnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click, btnCancel.Click
        Me.Close()
    End Sub

    Private Sub SetColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetColorToolStripMenuItem.Click
        Using ColorDialog1
            With ColorDialog1
                .Color = tvTools.SelectedNode.ForeColor
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    tvTools.SelectedNode.ForeColor = .Color
                End If
            End With
        End Using
    End Sub
End Class