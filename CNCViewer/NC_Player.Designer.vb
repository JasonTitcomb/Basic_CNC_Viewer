<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NC_Player
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.StepTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbPlay = New System.Windows.Forms.ToolStripButton()
        Me.tsbStop = New System.Windows.Forms.ToolStripButton()
        Me.tsbPause = New System.Windows.Forms.ToolStripButton()
        Me.tbSpeed = New MacGen.ToolStripSlider(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StepTimer
        '
        Me.StepTimer.Interval = 1000
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.CanOverflow = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbPlay, Me.tsbStop, Me.tsbPause, Me.tbSpeed})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(2, 4, 1, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(675, 33)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbPlay
        '
        Me.tsbPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPlay.Image = Global.MacGen.My.Resources.Resources.startplayer_16
        Me.tsbPlay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbPlay.Name = "tsbPlay"
        Me.tsbPlay.Size = New System.Drawing.Size(23, 26)
        Me.tsbPlay.Tag = "startplayer"
        Me.tsbPlay.Text = "Play"
        '
        'tsbStop
        '
        Me.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbStop.Image = Global.MacGen.My.Resources.Resources.stopplayer_16
        Me.tsbStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbStop.Name = "tsbStop"
        Me.tsbStop.Size = New System.Drawing.Size(23, 26)
        Me.tsbStop.Tag = "stopplayer"
        Me.tsbStop.Text = "Stop"
        '
        'tsbPause
        '
        Me.tsbPause.CheckOnClick = True
        Me.tsbPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPause.Image = Global.MacGen.My.Resources.Resources.pauseplayer_16
        Me.tsbPause.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbPause.Name = "tsbPause"
        Me.tsbPause.Size = New System.Drawing.Size(23, 26)
        Me.tsbPause.Tag = "pauseplayer"
        Me.tsbPause.Text = "Pause"
        '
        'tbSpeed
        '
        Me.tbSpeed.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.tbSpeed.Maximum = 20
        Me.tbSpeed.Minimum = 0
        Me.tbSpeed.Name = "tbSpeed"
        Me.tbSpeed.Size = New System.Drawing.Size(600, 27)
        Me.tbSpeed.ToolTipText = "Play speed"
        Me.tbSpeed.Value = 1
        '
        'NC_Player
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "NC_Player"
        Me.Size = New System.Drawing.Size(675, 33)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StepTimer As Timer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbPlay As ToolStripButton
    Friend WithEvents tsbStop As ToolStripButton
    Friend WithEvents tsbPause As ToolStripButton
    Friend WithEvents tbSpeed As ToolStripSlider
End Class
