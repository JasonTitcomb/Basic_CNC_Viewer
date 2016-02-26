Imports System.IO

Public Class ToolStripImageLoader
    Public Shared Sub SetImageKeys(ts As ToolStrip, touch As Boolean)
        Dim fnt As Font
        Dim size As Integer
        If touch Then
            size = 32
            fnt = New Font("Consalas", 20)
        Else
            size = 16
            fnt = New Font("Consalas", 10)
        End If

        ts.SuspendLayout()
        ts.ImageScalingSize = New Size(size, size)
        For Each tsb As ToolStripItem In ts.Items
            If TypeOf (tsb) Is ToolStripComboBox Then
                tsb.Font = fnt
            End If
            If TypeOf (tsb) Is ToolStripButton Then
                If tsb.Tag IsNot Nothing Then
                    tsb.Image = CType(My.Resources.ResourceManager.GetObject(tsb.Tag.ToString & "_" & size), Image)
                End If
            End If
            If TypeOf (tsb) Is ToolStripDropDownButton Then
                tsb.Image = CType(My.Resources.ResourceManager.GetObject(tsb.Tag.ToString & "_" & size), Image)
                Dim tsdb As ToolStripDropDownButton = DirectCast(tsb, ToolStripDropDownButton)
                For Each tsm As ToolStripMenuItem In tsdb.DropDownItems
                    If tsm.Tag IsNot Nothing Then
                        tsm.Image = CType(My.Resources.ResourceManager.GetObject(tsm.Tag.ToString & "_" & size), Image)
                    End If
                Next
            End If
        Next
        ts.ResumeLayout()
    End Sub
End Class
