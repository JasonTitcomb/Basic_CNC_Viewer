<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZ_Filter
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
        Me.txtUpper = New System.Windows.Forms.TextBox
        Me.txtLower = New System.Windows.Forms.TextBox
        Me.lblUpper = New System.Windows.Forms.Label
        Me.lblLower = New System.Windows.Forms.Label
        Me.rdoCrossing = New System.Windows.Forms.RadioButton
        Me.rdoContained = New System.Windows.Forms.RadioButton
        Me.btnDone = New System.Windows.Forms.Button
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtUpper
        '
        Me.txtUpper.Location = New System.Drawing.Point(72, 8)
        Me.txtUpper.Name = "txtUpper"
        Me.txtUpper.Size = New System.Drawing.Size(84, 20)
        Me.txtUpper.TabIndex = 0
        '
        'txtLower
        '
        Me.txtLower.Location = New System.Drawing.Point(72, 40)
        Me.txtLower.Name = "txtLower"
        Me.txtLower.Size = New System.Drawing.Size(84, 20)
        Me.txtLower.TabIndex = 1
        '
        'lblUpper
        '
        Me.lblUpper.AutoSize = True
        Me.lblUpper.Location = New System.Drawing.Point(8, 8)
        Me.lblUpper.Name = "lblUpper"
        Me.lblUpper.Size = New System.Drawing.Size(51, 13)
        Me.lblUpper.TabIndex = 2
        Me.lblUpper.Text = "Upper <="
        '
        'lblLower
        '
        Me.lblLower.AutoSize = True
        Me.lblLower.Location = New System.Drawing.Point(8, 40)
        Me.lblLower.Name = "lblLower"
        Me.lblLower.Size = New System.Drawing.Size(51, 13)
        Me.lblLower.TabIndex = 3
        Me.lblLower.Text = "Lower >="
        '
        'rdoCrossing
        '
        Me.rdoCrossing.AutoSize = True
        Me.rdoCrossing.Location = New System.Drawing.Point(96, 96)
        Me.rdoCrossing.Name = "rdoCrossing"
        Me.rdoCrossing.Size = New System.Drawing.Size(65, 17)
        Me.rdoCrossing.TabIndex = 6
        Me.rdoCrossing.Text = "Crossing"
        Me.rdoCrossing.UseVisualStyleBackColor = True
        '
        'rdoContained
        '
        Me.rdoContained.AutoSize = True
        Me.rdoContained.Checked = True
        Me.rdoContained.Location = New System.Drawing.Point(16, 96)
        Me.rdoContained.Name = "rdoContained"
        Me.rdoContained.Size = New System.Drawing.Size(73, 17)
        Me.rdoContained.TabIndex = 7
        Me.rdoContained.TabStop = True
        Me.rdoContained.Text = "Contained"
        Me.rdoContained.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDone.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDone.Location = New System.Drawing.Point(24, 128)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(56, 26)
        Me.btnDone.TabIndex = 9
        Me.btnDone.Text = "Cancel"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnApply.Location = New System.Drawing.Point(96, 128)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(59, 26)
        Me.btnApply.TabIndex = 9
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(72, 64)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(80, 23)
        Me.btnReset.TabIndex = 10
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'frmZ_Filter
        '
        Me.AcceptButton = Me.btnApply
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnDone
        Me.ClientSize = New System.Drawing.Size(178, 165)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.rdoContained)
        Me.Controls.Add(Me.rdoCrossing)
        Me.Controls.Add(Me.lblLower)
        Me.Controls.Add(Me.lblUpper)
        Me.Controls.Add(Me.txtLower)
        Me.Controls.Add(Me.txtUpper)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmZ_Filter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUpper As System.Windows.Forms.TextBox
    Friend WithEvents txtLower As System.Windows.Forms.TextBox
    Friend WithEvents lblUpper As System.Windows.Forms.Label
    Friend WithEvents lblLower As System.Windows.Forms.Label
    Friend WithEvents rdoCrossing As System.Windows.Forms.RadioButton
    Friend WithEvents rdoContained As System.Windows.Forms.RadioButton
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
End Class
