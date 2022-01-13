<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuickPick
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstQuickPick = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lstQuickPick
        '
        Me.lstQuickPick.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstQuickPick.FormattingEnabled = True
        Me.lstQuickPick.ItemHeight = 17
        Me.lstQuickPick.Location = New System.Drawing.Point(0, 0)
        Me.lstQuickPick.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lstQuickPick.Name = "lstQuickPick"
        Me.lstQuickPick.Size = New System.Drawing.Size(245, 90)
        Me.lstQuickPick.TabIndex = 0
        '
        'frmQuickPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(245, 90)
        Me.Controls.Add(Me.lstQuickPick)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmQuickPick"
        Me.Opacity = 0.8R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Selections"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents lstQuickPick As System.Windows.Forms.ListBox
End Class
