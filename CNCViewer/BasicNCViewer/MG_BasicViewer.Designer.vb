<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MG_BasicViewer
    Inherits System.Windows.Forms.UserControl
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.rmbView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFence = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRotate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuZoom = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTop = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFront = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIsometric = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLathe = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSetRotate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMeasure = New System.Windows.Forms.ToolStripMenuItem()
        Me.timerQuickPick = New System.Windows.Forms.Timer(Me.components)
        Me.rmbView.SuspendLayout()
        Me.SuspendLayout()
        '
        'rmbView
        '
        Me.rmbView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelect, Me.mnuFit, Me.mnuFence, Me.mnuPan, Me.mnuRotate, Me.mnuZoom, Me.ToolStripMenuItem1, Me.mnuSetRotate, Me.mnuMeasure})
        Me.rmbView.Name = "rmbView"
        Me.rmbView.Size = New System.Drawing.Size(159, 202)
        Me.rmbView.Tag = "measire"
        '
        'mnuSelect
        '
        Me.mnuSelect.Image = Global.MacGen.My.Resources.Resources.select_16
        Me.mnuSelect.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuSelect.Name = "mnuSelect"
        Me.mnuSelect.Size = New System.Drawing.Size(180, 22)
        Me.mnuSelect.Tag = "select"
        Me.mnuSelect.Text = "Select"
        '
        'mnuFit
        '
        Me.mnuFit.Image = Global.MacGen.My.Resources.Resources.viewFit_16
        Me.mnuFit.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuFit.Name = "mnuFit"
        Me.mnuFit.Size = New System.Drawing.Size(180, 22)
        Me.mnuFit.Tag = "viewFit"
        Me.mnuFit.Text = "Fit"
        '
        'mnuFence
        '
        Me.mnuFence.Image = Global.MacGen.My.Resources.Resources.viewFence_16
        Me.mnuFence.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuFence.Name = "mnuFence"
        Me.mnuFence.Size = New System.Drawing.Size(180, 22)
        Me.mnuFence.Tag = "viewFence"
        Me.mnuFence.Text = "Fence"
        '
        'mnuPan
        '
        Me.mnuPan.Image = Global.MacGen.My.Resources.Resources.viewPan_16
        Me.mnuPan.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuPan.Name = "mnuPan"
        Me.mnuPan.Size = New System.Drawing.Size(180, 22)
        Me.mnuPan.Tag = "viewPan"
        Me.mnuPan.Text = "Pan"
        '
        'mnuRotate
        '
        Me.mnuRotate.Image = Global.MacGen.My.Resources.Resources.viewRotate_16
        Me.mnuRotate.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuRotate.Name = "mnuRotate"
        Me.mnuRotate.Size = New System.Drawing.Size(180, 22)
        Me.mnuRotate.Tag = "viewRotate"
        Me.mnuRotate.Text = "Rotate"
        '
        'mnuZoom
        '
        Me.mnuZoom.Image = Global.MacGen.My.Resources.Resources.viewZoom_16
        Me.mnuZoom.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuZoom.Name = "mnuZoom"
        Me.mnuZoom.Size = New System.Drawing.Size(180, 22)
        Me.mnuZoom.Tag = "viewZoom"
        Me.mnuZoom.Text = "Zoom"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTop, Me.mnuFront, Me.mnuRight, Me.mnuIsometric, Me.mnuLathe})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem1.Tag = "views"
        Me.ToolStripMenuItem1.Text = "Views"
        '
        'mnuTop
        '
        Me.mnuTop.Image = Global.MacGen.My.Resources.Resources.viewTop_16
        Me.mnuTop.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuTop.Name = "mnuTop"
        Me.mnuTop.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.mnuTop.Size = New System.Drawing.Size(180, 22)
        Me.mnuTop.Tag = "viewTop"
        Me.mnuTop.Text = "Top"
        '
        'mnuFront
        '
        Me.mnuFront.Image = Global.MacGen.My.Resources.Resources.viewFront_16
        Me.mnuFront.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuFront.Name = "mnuFront"
        Me.mnuFront.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mnuFront.Size = New System.Drawing.Size(180, 22)
        Me.mnuFront.Tag = "viewFront"
        Me.mnuFront.Text = "Front"
        '
        'mnuRight
        '
        Me.mnuRight.Image = Global.MacGen.My.Resources.Resources.viewRight_16
        Me.mnuRight.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuRight.Name = "mnuRight"
        Me.mnuRight.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.mnuRight.Size = New System.Drawing.Size(180, 22)
        Me.mnuRight.Tag = "viewRight"
        Me.mnuRight.Text = "Right"
        '
        'mnuIsometric
        '
        Me.mnuIsometric.Image = Global.MacGen.My.Resources.Resources.viewISO_16
        Me.mnuIsometric.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuIsometric.Name = "mnuIsometric"
        Me.mnuIsometric.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.mnuIsometric.Size = New System.Drawing.Size(180, 22)
        Me.mnuIsometric.Tag = "viewISO"
        Me.mnuIsometric.Text = "Isometric"
        '
        'mnuLathe
        '
        Me.mnuLathe.Name = "mnuLathe"
        Me.mnuLathe.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.mnuLathe.Size = New System.Drawing.Size(180, 22)
        Me.mnuLathe.Tag = "viewLathe"
        Me.mnuLathe.Text = "Lathe XZ"
        '
        'mnuSetRotate
        '
        Me.mnuSetRotate.Name = "mnuSetRotate"
        Me.mnuSetRotate.Size = New System.Drawing.Size(180, 22)
        Me.mnuSetRotate.Tag = "setRotate"
        Me.mnuSetRotate.Text = "Set Rotate Point"
        '
        'mnuMeasure
        '
        Me.mnuMeasure.Name = "mnuMeasure"
        Me.mnuMeasure.Size = New System.Drawing.Size(180, 22)
        Me.mnuMeasure.Tag = "measure"
        Me.mnuMeasure.Text = "Measure"
        '
        'timerQuickPick
        '
        Me.timerQuickPick.Enabled = True
        Me.timerQuickPick.Interval = 1000
        '
        'MG_BasicViewer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ContextMenuStrip = Me.rmbView
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Name = "MG_BasicViewer"
        Me.Size = New System.Drawing.Size(209, 202)
        Me.rmbView.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mnuSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFence As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRotate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZoom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFront As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIsometric As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents rmbView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents timerQuickPick As System.Windows.Forms.Timer
    Friend WithEvents mnuSetRotate As ToolStripMenuItem
    Friend WithEvents mnuMeasure As ToolStripMenuItem
    Friend WithEvents mnuLathe As ToolStripMenuItem
End Class
