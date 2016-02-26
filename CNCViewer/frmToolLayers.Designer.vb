<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmToolLayers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.tvTools = New System.Windows.Forms.TreeView
        Me.RMBSetColor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SetColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnDone = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.RMBSetColor.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvTools
        '
        Me.tvTools.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvTools.CheckBoxes = True
        Me.tvTools.ContextMenuStrip = Me.RMBSetColor
        Me.tvTools.HideSelection = False
        Me.tvTools.Location = New System.Drawing.Point(1, 0)
        Me.tvTools.Margin = New System.Windows.Forms.Padding(4)
        Me.tvTools.Name = "tvTools"
        Me.tvTools.ShowLines = False
        Me.tvTools.ShowPlusMinus = False
        Me.tvTools.ShowRootLines = False
        Me.tvTools.Size = New System.Drawing.Size(207, 200)
        Me.tvTools.TabIndex = 0
        '
        'RMBSetColor
        '
        Me.RMBSetColor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetColorToolStripMenuItem})
        Me.RMBSetColor.Name = "RMBSetColor"
        Me.RMBSetColor.Size = New System.Drawing.Size(140, 28)
        '
        'SetColorToolStripMenuItem
        '
        Me.SetColorToolStripMenuItem.Name = "SetColorToolStripMenuItem"
        Me.SetColorToolStripMenuItem.Size = New System.Drawing.Size(139, 24)
        Me.SetColorToolStripMenuItem.Text = "&Set Color"
        '
        'btnDone
        '
        Me.btnDone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDone.Location = New System.Drawing.Point(117, 236)
        Me.btnDone.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(68, 32)
        Me.btnDone.TabIndex = 1
        Me.btnDone.Text = "Apply"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(32, 236)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 32)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmToolLayers
        '
        Me.AcceptButton = Me.btnDone
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(212, 273)
        Me.ControlBox = False
        Me.Controls.Add(Me.tvTools)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDone)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmToolLayers"
        Me.RMBSetColor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tvTools As System.Windows.Forms.TreeView
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents RMBSetColor As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SetColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
End Class
