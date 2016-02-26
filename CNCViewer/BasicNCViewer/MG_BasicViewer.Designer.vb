<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MG_BasicViewer
    Inherits System.Windows.Forms.UserControl
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MG_BasicViewer))
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
        Me.timerQuickPick = New System.Windows.Forms.Timer(Me.components)
        Me.rmbView.SuspendLayout()
        Me.SuspendLayout()
        '
        'rmbView
        '
        Me.rmbView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelect, Me.mnuFit, Me.mnuFence, Me.mnuPan, Me.mnuRotate, Me.mnuZoom, Me.ToolStripMenuItem1})
        Me.rmbView.Name = "rmbView"
        Me.rmbView.Size = New System.Drawing.Size(109, 158)
        '
        'mnuSelect
        '
        Me.mnuSelect.Image = CType(resources.GetObject("mnuSelect.Image"), System.Drawing.Image)
        Me.mnuSelect.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuSelect.Name = "mnuSelect"
        Me.mnuSelect.Size = New System.Drawing.Size(108, 22)
        Me.mnuSelect.Tag = "Select"
        Me.mnuSelect.Text = "Select"
        '
        'mnuFit
        '
        Me.mnuFit.Image = CType(resources.GetObject("mnuFit.Image"), System.Drawing.Image)
        Me.mnuFit.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuFit.Name = "mnuFit"
        Me.mnuFit.Size = New System.Drawing.Size(108, 22)
        Me.mnuFit.Tag = "Fit"
        Me.mnuFit.Text = "Fit"
        '
        'mnuFence
        '
        Me.mnuFence.Image = CType(resources.GetObject("mnuFence.Image"), System.Drawing.Image)
        Me.mnuFence.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuFence.Name = "mnuFence"
        Me.mnuFence.Size = New System.Drawing.Size(108, 22)
        Me.mnuFence.Tag = "Fence"
        Me.mnuFence.Text = "Fence"
        '
        'mnuPan
        '
        Me.mnuPan.Image = CType(resources.GetObject("mnuPan.Image"), System.Drawing.Image)
        Me.mnuPan.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuPan.Name = "mnuPan"
        Me.mnuPan.Size = New System.Drawing.Size(108, 22)
        Me.mnuPan.Tag = "Pan"
        Me.mnuPan.Text = "Pan"
        '
        'mnuRotate
        '
        Me.mnuRotate.Image = CType(resources.GetObject("mnuRotate.Image"), System.Drawing.Image)
        Me.mnuRotate.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuRotate.Name = "mnuRotate"
        Me.mnuRotate.Size = New System.Drawing.Size(108, 22)
        Me.mnuRotate.Tag = "Rotate"
        Me.mnuRotate.Text = "Rotate"
        '
        'mnuZoom
        '
        Me.mnuZoom.Image = CType(resources.GetObject("mnuZoom.Image"), System.Drawing.Image)
        Me.mnuZoom.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuZoom.Name = "mnuZoom"
        Me.mnuZoom.Size = New System.Drawing.Size(108, 22)
        Me.mnuZoom.Tag = "Zoom"
        Me.mnuZoom.Text = "Zoom"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTop, Me.mnuFront, Me.mnuRight, Me.mnuIsometric})
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripMenuItem1.Text = "Views"
        '
        'mnuTop
        '
        Me.mnuTop.Image = CType(resources.GetObject("mnuTop.Image"), System.Drawing.Image)
        Me.mnuTop.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuTop.Name = "mnuTop"
        Me.mnuTop.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.mnuTop.Size = New System.Drawing.Size(160, 22)
        Me.mnuTop.Tag = "Top"
        Me.mnuTop.Text = "Top"
        '
        'mnuFront
        '
        Me.mnuFront.Image = CType(resources.GetObject("mnuFront.Image"), System.Drawing.Image)
        Me.mnuFront.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuFront.Name = "mnuFront"
        Me.mnuFront.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mnuFront.Size = New System.Drawing.Size(160, 22)
        Me.mnuFront.Tag = "Front"
        Me.mnuFront.Text = "Front"
        '
        'mnuRight
        '
        Me.mnuRight.Image = CType(resources.GetObject("mnuRight.Image"), System.Drawing.Image)
        Me.mnuRight.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuRight.Name = "mnuRight"
        Me.mnuRight.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.mnuRight.Size = New System.Drawing.Size(160, 22)
        Me.mnuRight.Tag = "Right"
        Me.mnuRight.Text = "Right"
        '
        'mnuIsometric
        '
        Me.mnuIsometric.Image = CType(resources.GetObject("mnuIsometric.Image"), System.Drawing.Image)
        Me.mnuIsometric.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuIsometric.Name = "mnuIsometric"
        Me.mnuIsometric.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.mnuIsometric.Size = New System.Drawing.Size(160, 22)
        Me.mnuIsometric.Tag = "ISO"
        Me.mnuIsometric.Text = "Isometric"
        '
        'timerQuickPick
        '
        Me.timerQuickPick.Interval = 1000
        '
        'MG_BasicViewer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ContextMenuStrip = Me.rmbView
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


End Class
