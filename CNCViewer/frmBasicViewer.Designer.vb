<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmBasicViewer
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBasicViewer))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Coordinates = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Progress = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tsbToggleEditor = New System.Windows.Forms.ToolStripButton()
        Me.tscboMachines = New System.Windows.Forms.ToolStripComboBox()
        Me.tsbSettings = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbDisplay = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuRapidLines = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRapidPoints = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAxisLines = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAxisindicator = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAxisLimits = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbToolsFilter = New System.Windows.Forms.ToolStripButton()
        Me.tsbZFilter = New System.Windows.Forms.ToolStripButton()
        Me.tsbScreens = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuOneScreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTwoScreens = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFourScreens = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbTouch = New System.Windows.Forms.ToolStripButton()
        Me.tsbHelp = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuWeb = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPan = New System.Windows.Forms.ToolStripButton()
        Me.tsbZoom = New System.Windows.Forms.ToolStripButton()
        Me.tsbRotate = New System.Windows.Forms.ToolStripButton()
        Me.tsbFence = New System.Windows.Forms.ToolStripButton()
        Me.tsbFit = New System.Windows.Forms.ToolStripButton()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbMotionColor = New System.Windows.Forms.ToolStripButton()
        Me.tsbBackColor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPlay = New System.Windows.Forms.ToolStripButton()
        Me.tsbElementDetails = New System.Windows.Forms.ToolStripButton()
        Me.tsbView = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmTop = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmFront = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmISO = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbSelect = New System.Windows.Forms.ToolStripButton()
        Me.mnuWebSite = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEmail = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTop = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFront = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIsometric = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrnDoc = New System.Drawing.Printing.PrintDocument()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.BreakPointSlider = New System.Windows.Forms.TrackBar()
        Me.CodeTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FileWatcher = New System.IO.FileSystemWatcher()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsbSaveFile = New System.Windows.Forms.ToolStripButton()
        Me.tsbSaveAs = New System.Windows.Forms.ToolStripButton()
        Me.tsbNewFile = New System.Windows.Forms.ToolStripButton()
        Me.tsCboScheme = New System.Windows.Forms.ToolStripComboBox()
        Me.tsbColorize = New System.Windows.Forms.ToolStripButton()
        Me.tsbAddSpaces = New System.Windows.Forms.ToolStripButton()
        Me.tsbAutoZoom = New System.Windows.Forms.ToolStripButton()
        Me.tsbPlot = New System.Windows.Forms.ToolStripButton()
        Me.tblScreens = New System.Windows.Forms.TableLayoutPanel()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.RTB = New MacGen.MG_RichTextBox(Me.components)
        Me.MG_Viewer4 = New MacGen.MG_BasicViewer()
        Me.MG_Viewer3 = New MacGen.MG_BasicViewer()
        Me.MG_Viewer2 = New MacGen.MG_BasicViewer()
        Me.MG_Viewer1 = New MacGen.MG_BasicViewer()
        Me.tsbSelectedColor = New MacGen.MG_ToolStripColorSplitButton()
        Me.NC_Player = New MacGen.NC_Player()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.BreakPointSlider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileWatcher, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.tblScreens.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Title = "Open File"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 698)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1194, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 19)
        Me.lblStatus.Text = "Ready"
        '
        'Coordinates
        '
        Me.Coordinates.Name = "Coordinates"
        Me.Coordinates.Size = New System.Drawing.Size(809, 19)
        Me.Coordinates.Spring = True
        Me.Coordinates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Progress
        '
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(100, 18)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbOpen, Me.tsbRefresh, Me.tsbToggleEditor, Me.tscboMachines, Me.tsbSettings, Me.ToolStripSeparator1, Me.tsbDisplay, Me.tsbToolsFilter, Me.tsbZFilter, Me.tsbScreens, Me.tsbTouch, Me.tsbHelp, Me.ToolStripSeparator2, Me.tsbPan, Me.tsbZoom, Me.tsbRotate, Me.tsbFence, Me.tsbFit, Me.tsbPrint, Me.ToolStripSeparator3, Me.tsbMotionColor, Me.tsbBackColor, Me.ToolStripSeparator4, Me.tsbPlay, Me.tsbSelectedColor, Me.tsbElementDetails, Me.tsbView, Me.tsbSelect})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1194, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Tag = "viewrotate"
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbOpen
        '
        Me.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbOpen.Image = Global.MacGen.My.Resources.Resources.open_16
        Me.tsbOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbOpen.Name = "tsbOpen"
        Me.tsbOpen.Size = New System.Drawing.Size(23, 22)
        Me.tsbOpen.Tag = "open"
        Me.tsbOpen.Text = "Open"
        '
        'tsbRefresh
        '
        Me.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRefresh.Enabled = False
        Me.tsbRefresh.Image = Global.MacGen.My.Resources.Resources.refresh_16
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(23, 22)
        Me.tsbRefresh.Tag = "refresh"
        Me.tsbRefresh.Text = "Refresh"
        '
        'tsbToggleEditor
        '
        Me.tsbToggleEditor.Checked = True
        Me.tsbToggleEditor.CheckOnClick = True
        Me.tsbToggleEditor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsbToggleEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbToggleEditor.Image = Global.MacGen.My.Resources.Resources.toggleedit_16
        Me.tsbToggleEditor.Name = "tsbToggleEditor"
        Me.tsbToggleEditor.Size = New System.Drawing.Size(23, 22)
        Me.tsbToggleEditor.Tag = "toggleedit"
        Me.tsbToggleEditor.Text = "Toggle Edit"
        Me.tsbToggleEditor.ToolTipText = "Toggle editor"
        '
        'tscboMachines
        '
        Me.tscboMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscboMachines.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tscboMachines.Name = "tscboMachines"
        Me.tscboMachines.Size = New System.Drawing.Size(132, 25)
        '
        'tsbSettings
        '
        Me.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSettings.Image = Global.MacGen.My.Resources.Resources.settings_16
        Me.tsbSettings.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsbSettings.Name = "tsbSettings"
        Me.tsbSettings.Size = New System.Drawing.Size(23, 22)
        Me.tsbSettings.Tag = "settings"
        Me.tsbSettings.Text = "Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbDisplay
        '
        Me.tsbDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDisplay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRapidLines, Me.mnuRapidPoints, Me.mnuAxisLines, Me.mnuAxisindicator, Me.mnuAxisLimits})
        Me.tsbDisplay.Image = Global.MacGen.My.Resources.Resources.viewoptions_16
        Me.tsbDisplay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbDisplay.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsbDisplay.Name = "tsbDisplay"
        Me.tsbDisplay.Size = New System.Drawing.Size(29, 22)
        Me.tsbDisplay.Tag = "viewoptions"
        Me.tsbDisplay.Text = "Display"
        '
        'mnuRapidLines
        '
        Me.mnuRapidLines.Checked = True
        Me.mnuRapidLines.CheckOnClick = True
        Me.mnuRapidLines.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuRapidLines.Image = Global.MacGen.My.Resources.Resources.showrapidlines_16
        Me.mnuRapidLines.Name = "mnuRapidLines"
        Me.mnuRapidLines.Size = New System.Drawing.Size(145, 22)
        Me.mnuRapidLines.Tag = "showrapidlines"
        Me.mnuRapidLines.Text = "Rapid &Lines"
        '
        'mnuRapidPoints
        '
        Me.mnuRapidPoints.Checked = True
        Me.mnuRapidPoints.CheckOnClick = True
        Me.mnuRapidPoints.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuRapidPoints.Image = Global.MacGen.My.Resources.Resources.showrapidpoints_16
        Me.mnuRapidPoints.Name = "mnuRapidPoints"
        Me.mnuRapidPoints.Size = New System.Drawing.Size(145, 22)
        Me.mnuRapidPoints.Tag = "showrapidpoints"
        Me.mnuRapidPoints.Text = "Rapid &Points"
        '
        'mnuAxisLines
        '
        Me.mnuAxisLines.Checked = True
        Me.mnuAxisLines.CheckOnClick = True
        Me.mnuAxisLines.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuAxisLines.Image = Global.MacGen.My.Resources.Resources.showaxislines_16
        Me.mnuAxisLines.Name = "mnuAxisLines"
        Me.mnuAxisLines.Size = New System.Drawing.Size(145, 22)
        Me.mnuAxisLines.Tag = "showaxislines"
        Me.mnuAxisLines.Text = "&Axis Lines"
        '
        'mnuAxisindicator
        '
        Me.mnuAxisindicator.Checked = True
        Me.mnuAxisindicator.CheckOnClick = True
        Me.mnuAxisindicator.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuAxisindicator.Image = Global.MacGen.My.Resources.Resources.showaxisindicator_16
        Me.mnuAxisindicator.Name = "mnuAxisindicator"
        Me.mnuAxisindicator.Size = New System.Drawing.Size(145, 22)
        Me.mnuAxisindicator.Tag = "showaxisindicator"
        Me.mnuAxisindicator.Text = "Axis &Indicator"
        '
        'mnuAxisLimits
        '
        Me.mnuAxisLimits.CheckOnClick = True
        Me.mnuAxisLimits.Image = Global.MacGen.My.Resources.Resources.showaxislimits_16
        Me.mnuAxisLimits.Name = "mnuAxisLimits"
        Me.mnuAxisLimits.Size = New System.Drawing.Size(145, 22)
        Me.mnuAxisLimits.Tag = "showaxislimits"
        Me.mnuAxisLimits.Text = "Axis Limits"
        '
        'tsbToolsFilter
        '
        Me.tsbToolsFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbToolsFilter.Image = Global.MacGen.My.Resources.Resources.toolsfilter_16
        Me.tsbToolsFilter.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsbToolsFilter.Name = "tsbToolsFilter"
        Me.tsbToolsFilter.Size = New System.Drawing.Size(23, 22)
        Me.tsbToolsFilter.Tag = "toolsfilter"
        Me.tsbToolsFilter.Text = "Toolsfilter"
        Me.tsbToolsFilter.ToolTipText = "Tool filter"
        '
        'tsbZFilter
        '
        Me.tsbZFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbZFilter.Image = Global.MacGen.My.Resources.Resources.zfilter_16
        Me.tsbZFilter.Name = "tsbZFilter"
        Me.tsbZFilter.Size = New System.Drawing.Size(23, 22)
        Me.tsbZFilter.Tag = "zfilter"
        Me.tsbZFilter.Text = "ZFilter"
        '
        'tsbScreens
        '
        Me.tsbScreens.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbScreens.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOneScreen, Me.mnuTwoScreens, Me.mnuFourScreens})
        Me.tsbScreens.Image = Global.MacGen.My.Resources.Resources.screens_16
        Me.tsbScreens.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsbScreens.Name = "tsbScreens"
        Me.tsbScreens.Size = New System.Drawing.Size(29, 22)
        Me.tsbScreens.Tag = "screens"
        Me.tsbScreens.Text = "Screens"
        '
        'mnuOneScreen
        '
        Me.mnuOneScreen.Image = Global.MacGen.My.Resources.Resources.onescreen_16
        Me.mnuOneScreen.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuOneScreen.Name = "mnuOneScreen"
        Me.mnuOneScreen.Size = New System.Drawing.Size(107, 22)
        Me.mnuOneScreen.Tag = "onescreen"
        Me.mnuOneScreen.Text = "&1 One"
        '
        'mnuTwoScreens
        '
        Me.mnuTwoScreens.Image = Global.MacGen.My.Resources.Resources.twoscreens_16
        Me.mnuTwoScreens.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuTwoScreens.Name = "mnuTwoScreens"
        Me.mnuTwoScreens.Size = New System.Drawing.Size(107, 22)
        Me.mnuTwoScreens.Tag = "twoscreens"
        Me.mnuTwoScreens.Text = "&2 Two"
        '
        'mnuFourScreens
        '
        Me.mnuFourScreens.Image = Global.MacGen.My.Resources.Resources.fourscreens_16
        Me.mnuFourScreens.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuFourScreens.Name = "mnuFourScreens"
        Me.mnuFourScreens.Size = New System.Drawing.Size(107, 22)
        Me.mnuFourScreens.Tag = "fourscreens"
        Me.mnuFourScreens.Text = "&4 Four"
        '
        'tsbTouch
        '
        Me.tsbTouch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbTouch.CheckOnClick = True
        Me.tsbTouch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbTouch.Image = Global.MacGen.My.Resources.Resources.touchmode_16
        Me.tsbTouch.Name = "tsbTouch"
        Me.tsbTouch.Size = New System.Drawing.Size(23, 22)
        Me.tsbTouch.Tag = "touchmode"
        Me.tsbTouch.Text = "Touch mode"
        '
        'tsbHelp
        '
        Me.tsbHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWeb})
        Me.tsbHelp.Image = Global.MacGen.My.Resources.Resources.help_16
        Me.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHelp.Name = "tsbHelp"
        Me.tsbHelp.Size = New System.Drawing.Size(29, 22)
        Me.tsbHelp.Tag = "help"
        Me.tsbHelp.Text = "Phone Home"
        '
        'mnuWeb
        '
        Me.mnuWeb.Image = Global.MacGen.My.Resources.Resources.website_16
        Me.mnuWeb.Name = "mnuWeb"
        Me.mnuWeb.Size = New System.Drawing.Size(98, 22)
        Me.mnuWeb.Tag = "website"
        Me.mnuWeb.Text = "&Web"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPan
        '
        Me.tsbPan.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbPan.CheckOnClick = True
        Me.tsbPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPan.Image = Global.MacGen.My.Resources.Resources.viewpan_16
        Me.tsbPan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbPan.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsbPan.Name = "tsbPan"
        Me.tsbPan.Size = New System.Drawing.Size(23, 22)
        Me.tsbPan.Tag = "viewpan"
        Me.tsbPan.Text = "Pan"
        '
        'tsbZoom
        '
        Me.tsbZoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbZoom.CheckOnClick = True
        Me.tsbZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbZoom.Image = Global.MacGen.My.Resources.Resources.viewzoom_16
        Me.tsbZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbZoom.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsbZoom.Name = "tsbZoom"
        Me.tsbZoom.Size = New System.Drawing.Size(23, 22)
        Me.tsbZoom.Tag = "viewzoom"
        Me.tsbZoom.Text = "Zoom"
        '
        'tsbRotate
        '
        Me.tsbRotate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbRotate.CheckOnClick = True
        Me.tsbRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRotate.Image = Global.MacGen.My.Resources.Resources.viewrotate_16
        Me.tsbRotate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbRotate.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsbRotate.Name = "tsbRotate"
        Me.tsbRotate.Size = New System.Drawing.Size(23, 22)
        Me.tsbRotate.Tag = "viewrotate"
        Me.tsbRotate.Text = "Rotate"
        '
        'tsbFence
        '
        Me.tsbFence.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbFence.CheckOnClick = True
        Me.tsbFence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbFence.Image = Global.MacGen.My.Resources.Resources.viewfence_16
        Me.tsbFence.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbFence.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsbFence.Name = "tsbFence"
        Me.tsbFence.Size = New System.Drawing.Size(23, 22)
        Me.tsbFence.Tag = "viewfence"
        Me.tsbFence.Text = "Fence"
        '
        'tsbFit
        '
        Me.tsbFit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbFit.Image = Global.MacGen.My.Resources.Resources.viewfit_16
        Me.tsbFit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbFit.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsbFit.Name = "tsbFit"
        Me.tsbFit.Size = New System.Drawing.Size(23, 22)
        Me.tsbFit.Tag = "viewfit"
        Me.tsbFit.Text = "Fit"
        Me.tsbFit.ToolTipText = "View Fit [Shift + Click All Views]"
        '
        'tsbPrint
        '
        Me.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrint.Image = Global.MacGen.My.Resources.Resources.print_16
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(23, 22)
        Me.tsbPrint.Tag = "print"
        Me.tsbPrint.Text = "Print"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbMotionColor
        '
        Me.tsbMotionColor.CheckOnClick = True
        Me.tsbMotionColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbMotionColor.Image = Global.MacGen.My.Resources.Resources.motion_color_16
        Me.tsbMotionColor.Name = "tsbMotionColor"
        Me.tsbMotionColor.Size = New System.Drawing.Size(23, 22)
        Me.tsbMotionColor.Tag = "motion_color"
        Me.tsbMotionColor.Text = "Motion Color"
        '
        'tsbBackColor
        '
        Me.tsbBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbBackColor.Image = Global.MacGen.My.Resources.Resources.backcolor_16
        Me.tsbBackColor.Name = "tsbBackColor"
        Me.tsbBackColor.Size = New System.Drawing.Size(23, 22)
        Me.tsbBackColor.Tag = "backcolor"
        Me.tsbBackColor.Text = "BackColor"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPlay
        '
        Me.tsbPlay.CheckOnClick = True
        Me.tsbPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPlay.Image = Global.MacGen.My.Resources.Resources.play_16
        Me.tsbPlay.Name = "tsbPlay"
        Me.tsbPlay.Size = New System.Drawing.Size(23, 22)
        Me.tsbPlay.Tag = "play"
        Me.tsbPlay.Text = "Player"
        '
        'tsbElementDetails
        '
        Me.tsbElementDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbElementDetails.Image = Global.MacGen.My.Resources.Resources.elementdetails_16
        Me.tsbElementDetails.Name = "tsbElementDetails"
        Me.tsbElementDetails.Size = New System.Drawing.Size(23, 22)
        Me.tsbElementDetails.Tag = "elementdetails"
        Me.tsbElementDetails.Text = "Element details"
        '
        'tsbView
        '
        Me.tsbView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmTop, Me.tsmFront, Me.tsmRight, Me.tsmISO})
        Me.tsbView.Image = Global.MacGen.My.Resources.Resources.viewfront_16
        Me.tsbView.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsbView.Name = "tsbView"
        Me.tsbView.Size = New System.Drawing.Size(29, 22)
        Me.tsbView.Tag = "viewfront"
        Me.tsbView.Text = "&View"
        '
        'tsmTop
        '
        Me.tsmTop.Image = Global.MacGen.My.Resources.Resources.viewtop_16
        Me.tsmTop.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsmTop.Name = "tsmTop"
        Me.tsmTop.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.tsmTop.Size = New System.Drawing.Size(160, 22)
        Me.tsmTop.Tag = "viewtop"
        Me.tsmTop.Text = "&Top"
        '
        'tsmFront
        '
        Me.tsmFront.Image = Global.MacGen.My.Resources.Resources.viewfront_16
        Me.tsmFront.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsmFront.Name = "tsmFront"
        Me.tsmFront.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.tsmFront.Size = New System.Drawing.Size(160, 22)
        Me.tsmFront.Tag = "viewfront"
        Me.tsmFront.Text = "&Front"
        '
        'tsmRight
        '
        Me.tsmRight.Image = Global.MacGen.My.Resources.Resources.viewright_16
        Me.tsmRight.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsmRight.Name = "tsmRight"
        Me.tsmRight.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.tsmRight.Size = New System.Drawing.Size(160, 22)
        Me.tsmRight.Tag = "viewright"
        Me.tsmRight.Text = "&Right"
        '
        'tsmISO
        '
        Me.tsmISO.Image = Global.MacGen.My.Resources.Resources.viewiso_16
        Me.tsmISO.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tsmISO.Name = "tsmISO"
        Me.tsmISO.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.tsmISO.Size = New System.Drawing.Size(160, 22)
        Me.tsmISO.Tag = "viewiso"
        Me.tsmISO.Text = "&Isometric"
        '
        'tsbSelect
        '
        Me.tsbSelect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbSelect.Checked = True
        Me.tsbSelect.CheckOnClick = True
        Me.tsbSelect.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSelect.Image = Global.MacGen.My.Resources.Resources.select_16
        Me.tsbSelect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSelect.Name = "tsbSelect"
        Me.tsbSelect.Size = New System.Drawing.Size(23, 22)
        Me.tsbSelect.Tag = "select"
        Me.tsbSelect.Text = "Select"
        '
        'mnuWebSite
        '
        Me.mnuWebSite.Image = Global.MacGen.My.Resources.Resources.website_16
        Me.mnuWebSite.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.mnuWebSite.Name = "mnuWebSite"
        Me.mnuWebSite.Size = New System.Drawing.Size(152, 22)
        Me.mnuWebSite.Tag = "website"
        Me.mnuWebSite.Text = "&Web Site"
        '
        'mnuEmail
        '
        Me.mnuEmail.Image = Global.MacGen.My.Resources.Resources.mail_16
        Me.mnuEmail.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.mnuEmail.Name = "mnuEmail"
        Me.mnuEmail.Size = New System.Drawing.Size(152, 22)
        Me.mnuEmail.Tag = "email"
        Me.mnuEmail.Text = "&Email  Support"
        '
        'mnuTop
        '
        Me.mnuTop.Image = Global.MacGen.My.Resources.Resources.viewtop_16
        Me.mnuTop.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuTop.Name = "mnuTop"
        Me.mnuTop.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.mnuTop.Size = New System.Drawing.Size(160, 22)
        Me.mnuTop.Tag = "viewtop"
        Me.mnuTop.Text = "&Top"
        '
        'mnuFront
        '
        Me.mnuFront.Image = Global.MacGen.My.Resources.Resources.viewfront_16
        Me.mnuFront.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuFront.Name = "mnuFront"
        Me.mnuFront.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mnuFront.Size = New System.Drawing.Size(160, 22)
        Me.mnuFront.Tag = "viewfront"
        Me.mnuFront.Text = "&Front"
        '
        'mnuRight
        '
        Me.mnuRight.Image = Global.MacGen.My.Resources.Resources.viewright_16
        Me.mnuRight.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuRight.Name = "mnuRight"
        Me.mnuRight.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.mnuRight.Size = New System.Drawing.Size(160, 22)
        Me.mnuRight.Tag = "viewright"
        Me.mnuRight.Text = "&Right"
        '
        'mnuIsometric
        '
        Me.mnuIsometric.Image = Global.MacGen.My.Resources.Resources.viewiso_16
        Me.mnuIsometric.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.mnuIsometric.Name = "mnuIsometric"
        Me.mnuIsometric.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.mnuIsometric.Size = New System.Drawing.Size(160, 22)
        Me.mnuIsometric.Tag = "viewiso"
        Me.mnuIsometric.Text = "&Isometric"
        '
        'PrnDoc
        '
        '
        'ColorDialog1
        '
        Me.ColorDialog1.SolidColorOnly = True
        '
        'BreakPointSlider
        '
        Me.BreakPointSlider.AutoSize = False
        Me.BreakPointSlider.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BreakPointSlider.Location = New System.Drawing.Point(0, 666)
        Me.BreakPointSlider.Margin = New System.Windows.Forms.Padding(0)
        Me.BreakPointSlider.Name = "BreakPointSlider"
        Me.BreakPointSlider.Size = New System.Drawing.Size(1194, 32)
        Me.BreakPointSlider.TabIndex = 8
        Me.BreakPointSlider.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'CodeTip
        '
        Me.CodeTip.AutoPopDelay = 3000
        Me.CodeTip.InitialDelay = 0
        Me.CodeTip.IsBalloon = True
        Me.CodeTip.ReshowDelay = 0
        Me.CodeTip.ShowAlways = True
        Me.CodeTip.UseAnimation = False
        Me.CodeTip.UseFading = False
        '
        'FileWatcher
        '
        Me.FileWatcher.EnableRaisingEvents = True
        Me.FileWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite
        Me.FileWatcher.SynchronizingObject = Me
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.RTB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip2)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tblScreens)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.SplitContainer1.Size = New System.Drawing.Size(1194, 609)
        Me.SplitContainer1.SplitterDistance = 387
        Me.SplitContainer1.TabIndex = 11
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSaveFile, Me.tsbSaveAs, Me.tsbNewFile, Me.tsCboScheme, Me.tsbColorize, Me.tsbAddSpaces, Me.tsbAutoZoom, Me.tsbPlot})
        Me.ToolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip2.Location = New System.Drawing.Point(4, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(383, 25)
        Me.ToolStrip2.TabIndex = 12
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbSaveFile
        '
        Me.tsbSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSaveFile.Enabled = False
        Me.tsbSaveFile.Image = Global.MacGen.My.Resources.Resources.savefile_16
        Me.tsbSaveFile.Name = "tsbSaveFile"
        Me.tsbSaveFile.Size = New System.Drawing.Size(23, 22)
        Me.tsbSaveFile.Tag = "savefile"
        Me.tsbSaveFile.Text = "Save"
        Me.tsbSaveFile.ToolTipText = "Save"
        '
        'tsbSaveAs
        '
        Me.tsbSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSaveAs.Image = Global.MacGen.My.Resources.Resources.savefileas_16
        Me.tsbSaveAs.Name = "tsbSaveAs"
        Me.tsbSaveAs.Size = New System.Drawing.Size(23, 22)
        Me.tsbSaveAs.Tag = "savefileas"
        Me.tsbSaveAs.Text = "Save As"
        '
        'tsbNewFile
        '
        Me.tsbNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNewFile.Image = Global.MacGen.My.Resources.Resources.newfile_16
        Me.tsbNewFile.Name = "tsbNewFile"
        Me.tsbNewFile.Size = New System.Drawing.Size(23, 22)
        Me.tsbNewFile.Tag = "newfile"
        Me.tsbNewFile.Text = "New"
        '
        'tsCboScheme
        '
        Me.tsCboScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tsCboScheme.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsCboScheme.Name = "tsCboScheme"
        Me.tsCboScheme.Size = New System.Drawing.Size(132, 25)
        '
        'tsbColorize
        '
        Me.tsbColorize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbColorize.Image = Global.MacGen.My.Resources.Resources.colorize_16
        Me.tsbColorize.Name = "tsbColorize"
        Me.tsbColorize.Size = New System.Drawing.Size(23, 22)
        Me.tsbColorize.Tag = "colorize"
        Me.tsbColorize.ToolTipText = "Colorize Text"
        '
        'tsbAddSpaces
        '
        Me.tsbAddSpaces.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAddSpaces.Image = Global.MacGen.My.Resources.Resources.addspaces_16
        Me.tsbAddSpaces.Name = "tsbAddSpaces"
        Me.tsbAddSpaces.Size = New System.Drawing.Size(23, 22)
        Me.tsbAddSpaces.Tag = "addspaces"
        Me.tsbAddSpaces.ToolTipText = "Add Spaces, [SHIFT] Remove"
        '
        'tsbAutoZoom
        '
        Me.tsbAutoZoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbAutoZoom.CheckOnClick = True
        Me.tsbAutoZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAutoZoom.Image = CType(resources.GetObject("tsbAutoZoom.Image"), System.Drawing.Image)
        Me.tsbAutoZoom.Name = "tsbAutoZoom"
        Me.tsbAutoZoom.Size = New System.Drawing.Size(23, 22)
        Me.tsbAutoZoom.Tag = "zoom_auto"
        Me.tsbAutoZoom.Text = "zoom_auto"
        Me.tsbAutoZoom.ToolTipText = "Auto-zoom"
        '
        'tsbPlot
        '
        Me.tsbPlot.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbPlot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPlot.Image = Global.MacGen.My.Resources.Resources.plot_16
        Me.tsbPlot.Name = "tsbPlot"
        Me.tsbPlot.Size = New System.Drawing.Size(23, 22)
        Me.tsbPlot.Tag = "plot"
        Me.tsbPlot.Text = "Plot"
        '
        'tblScreens
        '
        Me.tblScreens.BackColor = System.Drawing.Color.Black
        Me.tblScreens.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tblScreens.ColumnCount = 2
        Me.tblScreens.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblScreens.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblScreens.Controls.Add(Me.MG_Viewer4, 1, 1)
        Me.tblScreens.Controls.Add(Me.MG_Viewer3, 0, 1)
        Me.tblScreens.Controls.Add(Me.MG_Viewer2, 1, 0)
        Me.tblScreens.Controls.Add(Me.MG_Viewer1, 0, 0)
        Me.tblScreens.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblScreens.Location = New System.Drawing.Point(0, 0)
        Me.tblScreens.Margin = New System.Windows.Forms.Padding(0)
        Me.tblScreens.Name = "tblScreens"
        Me.tblScreens.RowCount = 2
        Me.tblScreens.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblScreens.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblScreens.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tblScreens.Size = New System.Drawing.Size(799, 609)
        Me.tblScreens.TabIndex = 7
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'RTB
        '
        Me.RTB.AllowApply = True
        Me.RTB.DetectUrls = False
        Me.RTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RTB.EnableOnVisibleTextChangedEvent = True
        Me.RTB.FileName = Nothing
        Me.RTB.ForceUpperCase = False
        Me.RTB.HideSelection = False
        Me.RTB.LineCountDirty = False
        Me.RTB.Location = New System.Drawing.Point(4, 25)
        Me.RTB.MaxUndo = 100
        Me.RTB.Name = "RTB"
        Me.RTB.OnIdleDelay = 500
        Me.RTB.OnVisibleTextChangedDelay = 100
        Me.RTB.Size = New System.Drawing.Size(383, 584)
        Me.RTB.TabIndex = 1
        Me.RTB.Text = ""
        Me.RTB.TextRangeBoxColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RTB.UndoDataFolder = "C:\Users\Jason\AppData\Local\Microsoft\VisualStudio\14.0\ProjectAssemblies\b7-yls" &
    "5a01\UndoData\"
        Me.RTB.WordWrap = False
        '
        'MG_Viewer4
        '
        Me.MG_Viewer4.AxisIndicatorScale = 0.75!
        Me.MG_Viewer4.BackColor = System.Drawing.Color.Black
        Me.MG_Viewer4.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.MG_Viewer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MG_Viewer4.DrawExtraOverlayInfo = True
        Me.MG_Viewer4.DrawOnPaint = True
        Me.MG_Viewer4.DynamicViewManipulation = True
        Me.MG_Viewer4.FilterLowerZ = Single.NaN
        Me.MG_Viewer4.FilterUpperZ = Single.NaN
        Me.MG_Viewer4.FilterZ = False
        Me.MG_Viewer4.FilterZCrossing = False
        Me.MG_Viewer4.FourthAxis = 0!
        Me.MG_Viewer4.IsShared = True
        Me.MG_Viewer4.Limits = New Single() {0!, 0!, 0!, 0!, 0!, 0!}
        Me.MG_Viewer4.LimitsColor = System.Drawing.Color.DarkGray
        Me.MG_Viewer4.Location = New System.Drawing.Point(400, 305)
        Me.MG_Viewer4.Margin = New System.Windows.Forms.Padding(0)
        Me.MG_Viewer4.MaxSelectionHits = 16
        Me.MG_Viewer4.MotionColor_ArcCCW = System.Drawing.Color.Teal
        Me.MG_Viewer4.MotionColor_ArcCW = System.Drawing.Color.ForestGreen
        Me.MG_Viewer4.MotionColor_Line = System.Drawing.Color.DodgerBlue
        Me.MG_Viewer4.MotionColor_Rapid = System.Drawing.Color.OrangeRed
        Me.MG_Viewer4.Name = "MG_Viewer4"
        Me.MG_Viewer4.Pitch = 0!
        Me.MG_Viewer4.RangeEnd = -1
        Me.MG_Viewer4.RangeStart = 0
        Me.MG_Viewer4.ReverseMouseWheel = True
        Me.MG_Viewer4.Roll = 0!
        Me.MG_Viewer4.RotaryType = MacGen.RotaryMotionType.BMC
        Me.MG_Viewer4.SelectedMotionIndex = -1
        Me.MG_Viewer4.SelectionColor = System.Drawing.Color.Empty
        Me.MG_Viewer4.Size = New System.Drawing.Size(398, 303)
        Me.MG_Viewer4.TabIndex = 3
        Me.MG_Viewer4.TabletMode = False
        Me.MG_Viewer4.ViewManipMode = MacGen.MG_BasicViewer.ManipMode.ROTATE
        Me.MG_Viewer4.Yaw = 0!
        '
        'MG_Viewer3
        '
        Me.MG_Viewer3.AxisIndicatorScale = 0.75!
        Me.MG_Viewer3.BackColor = System.Drawing.Color.Black
        Me.MG_Viewer3.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.MG_Viewer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MG_Viewer3.DrawExtraOverlayInfo = True
        Me.MG_Viewer3.DrawOnPaint = True
        Me.MG_Viewer3.DynamicViewManipulation = True
        Me.MG_Viewer3.FilterLowerZ = Single.NaN
        Me.MG_Viewer3.FilterUpperZ = Single.NaN
        Me.MG_Viewer3.FilterZ = False
        Me.MG_Viewer3.FilterZCrossing = False
        Me.MG_Viewer3.FourthAxis = 0!
        Me.MG_Viewer3.IsShared = True
        Me.MG_Viewer3.Limits = New Single() {0!, 0!, 0!, 0!, 0!, 0!}
        Me.MG_Viewer3.LimitsColor = System.Drawing.Color.DarkGray
        Me.MG_Viewer3.Location = New System.Drawing.Point(1, 305)
        Me.MG_Viewer3.Margin = New System.Windows.Forms.Padding(0)
        Me.MG_Viewer3.MaxSelectionHits = 16
        Me.MG_Viewer3.MotionColor_ArcCCW = System.Drawing.Color.Teal
        Me.MG_Viewer3.MotionColor_ArcCW = System.Drawing.Color.ForestGreen
        Me.MG_Viewer3.MotionColor_Line = System.Drawing.Color.DodgerBlue
        Me.MG_Viewer3.MotionColor_Rapid = System.Drawing.Color.OrangeRed
        Me.MG_Viewer3.Name = "MG_Viewer3"
        Me.MG_Viewer3.Pitch = 0!
        Me.MG_Viewer3.RangeEnd = -1
        Me.MG_Viewer3.RangeStart = 0
        Me.MG_Viewer3.ReverseMouseWheel = True
        Me.MG_Viewer3.Roll = 0!
        Me.MG_Viewer3.RotaryType = MacGen.RotaryMotionType.BMC
        Me.MG_Viewer3.SelectedMotionIndex = -1
        Me.MG_Viewer3.SelectionColor = System.Drawing.Color.Empty
        Me.MG_Viewer3.Size = New System.Drawing.Size(398, 303)
        Me.MG_Viewer3.TabIndex = 2
        Me.MG_Viewer3.TabletMode = False
        Me.MG_Viewer3.ViewManipMode = MacGen.MG_BasicViewer.ManipMode.ROTATE
        Me.MG_Viewer3.Yaw = 0!
        '
        'MG_Viewer2
        '
        Me.MG_Viewer2.AxisIndicatorScale = 0.75!
        Me.MG_Viewer2.BackColor = System.Drawing.Color.Black
        Me.MG_Viewer2.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.MG_Viewer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MG_Viewer2.DrawExtraOverlayInfo = True
        Me.MG_Viewer2.DrawOnPaint = True
        Me.MG_Viewer2.DynamicViewManipulation = True
        Me.MG_Viewer2.FilterLowerZ = Single.NaN
        Me.MG_Viewer2.FilterUpperZ = Single.NaN
        Me.MG_Viewer2.FilterZ = False
        Me.MG_Viewer2.FilterZCrossing = False
        Me.MG_Viewer2.FourthAxis = 0!
        Me.MG_Viewer2.IsShared = True
        Me.MG_Viewer2.Limits = New Single() {0!, 0!, 0!, 0!, 0!, 0!}
        Me.MG_Viewer2.LimitsColor = System.Drawing.Color.DarkGray
        Me.MG_Viewer2.Location = New System.Drawing.Point(400, 1)
        Me.MG_Viewer2.Margin = New System.Windows.Forms.Padding(0)
        Me.MG_Viewer2.MaxSelectionHits = 16
        Me.MG_Viewer2.MotionColor_ArcCCW = System.Drawing.Color.Teal
        Me.MG_Viewer2.MotionColor_ArcCW = System.Drawing.Color.ForestGreen
        Me.MG_Viewer2.MotionColor_Line = System.Drawing.Color.DodgerBlue
        Me.MG_Viewer2.MotionColor_Rapid = System.Drawing.Color.OrangeRed
        Me.MG_Viewer2.Name = "MG_Viewer2"
        Me.MG_Viewer2.Pitch = 0!
        Me.MG_Viewer2.RangeEnd = -1
        Me.MG_Viewer2.RangeStart = 0
        Me.MG_Viewer2.ReverseMouseWheel = True
        Me.MG_Viewer2.Roll = 0!
        Me.MG_Viewer2.RotaryType = MacGen.RotaryMotionType.BMC
        Me.MG_Viewer2.SelectedMotionIndex = -1
        Me.MG_Viewer2.SelectionColor = System.Drawing.Color.Empty
        Me.MG_Viewer2.Size = New System.Drawing.Size(398, 303)
        Me.MG_Viewer2.TabIndex = 1
        Me.MG_Viewer2.TabletMode = False
        Me.MG_Viewer2.ViewManipMode = MacGen.MG_BasicViewer.ManipMode.ROTATE
        Me.MG_Viewer2.Yaw = 0!
        '
        'MG_Viewer1
        '
        Me.MG_Viewer1.AxisIndicatorScale = 0.75!
        Me.MG_Viewer1.BackColor = System.Drawing.Color.Black
        Me.MG_Viewer1.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.MG_Viewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MG_Viewer1.DrawExtraOverlayInfo = True
        Me.MG_Viewer1.DrawOnPaint = True
        Me.MG_Viewer1.DynamicViewManipulation = True
        Me.MG_Viewer1.FilterLowerZ = Single.NaN
        Me.MG_Viewer1.FilterUpperZ = Single.NaN
        Me.MG_Viewer1.FilterZ = False
        Me.MG_Viewer1.FilterZCrossing = False
        Me.MG_Viewer1.FourthAxis = 0!
        Me.MG_Viewer1.IsShared = True
        Me.MG_Viewer1.Limits = New Single() {0!, 0!, 0!, 0!, 0!, 0!}
        Me.MG_Viewer1.LimitsColor = System.Drawing.Color.DarkGray
        Me.MG_Viewer1.Location = New System.Drawing.Point(1, 1)
        Me.MG_Viewer1.Margin = New System.Windows.Forms.Padding(0)
        Me.MG_Viewer1.MaxSelectionHits = 16
        Me.MG_Viewer1.MotionColor_ArcCCW = System.Drawing.Color.Teal
        Me.MG_Viewer1.MotionColor_ArcCW = System.Drawing.Color.ForestGreen
        Me.MG_Viewer1.MotionColor_Line = System.Drawing.Color.DodgerBlue
        Me.MG_Viewer1.MotionColor_Rapid = System.Drawing.Color.OrangeRed
        Me.MG_Viewer1.Name = "MG_Viewer1"
        Me.MG_Viewer1.Pitch = 0!
        Me.MG_Viewer1.RangeEnd = -1
        Me.MG_Viewer1.RangeStart = 0
        Me.MG_Viewer1.ReverseMouseWheel = True
        Me.MG_Viewer1.Roll = 0!
        Me.MG_Viewer1.RotaryType = MacGen.RotaryMotionType.BMC
        Me.MG_Viewer1.SelectedMotionIndex = -1
        Me.MG_Viewer1.SelectionColor = System.Drawing.Color.Empty
        Me.MG_Viewer1.Size = New System.Drawing.Size(398, 303)
        Me.MG_Viewer1.TabIndex = 0
        Me.MG_Viewer1.TabletMode = False
        Me.MG_Viewer1.ViewManipMode = MacGen.MG_BasicViewer.ManipMode.ROTATE
        Me.MG_Viewer1.Yaw = 0!
        '
        'tsbSelectedColor
        '
        Me.tsbSelectedColor.AllowNoneColor = True
        Me.tsbSelectedColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSelectedColor.Image = Global.MacGen.My.Resources.Resources.selectcolor_16
        Me.tsbSelectedColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSelectedColor.Name = "tsbSelectedColor"
        Me.tsbSelectedColor.ReplaceIconWithSelectedColor = False
        Me.tsbSelectedColor.SelectedColor = System.Drawing.Color.Empty
        Me.tsbSelectedColor.Size = New System.Drawing.Size(29, 22)
        Me.tsbSelectedColor.Tag = "selectcolor"
        Me.tsbSelectedColor.Text = "Selection color"
        Me.tsbSelectedColor.ToolTipText = "Selection Color"
        '
        'NC_Player
        '
        Me.NC_Player.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.NC_Player.LastTool = 0!
        Me.NC_Player.Location = New System.Drawing.Point(0, 634)
        Me.NC_Player.MinimumSize = New System.Drawing.Size(0, 32)
        Me.NC_Player.Name = "NC_Player"
        Me.NC_Player.OptionStop = False
        Me.NC_Player.Size = New System.Drawing.Size(1194, 32)
        Me.NC_Player.Speed = 1
        Me.NC_Player.TabIndex = 12
        Me.NC_Player.TouchMode = False
        '
        'frmBasicViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 720)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.NC_Player)
        Me.Controls.Add(Me.BreakPointSlider)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(68, 66)
        Me.MinimumSize = New System.Drawing.Size(425, 224)
        Me.Name = "frmBasicViewer"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = ""
        Me.Text = "Basic 3-D Viewer"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.BreakPointSlider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileWatcher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.tblScreens.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Coordinates As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Progress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuTop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFront As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIsometric As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbDisplay As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuRapidLines As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRapidPoints As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAxisLines As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAxisindicator As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbFit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbFence As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPan As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRotate As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbScreens As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuOneScreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTwoScreens As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFourScreens As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbZoom As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSelect As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbToolsFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents tscboMachines As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrnDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents tsbHelp As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuWebSite As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbBackColor As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents BreakPointSlider As System.Windows.Forms.TrackBar
    Private WithEvents CodeTip As System.Windows.Forms.ToolTip
    Friend WithEvents mnuEmail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileWatcher As System.IO.FileSystemWatcher
    Friend WithEvents tsbPlay As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbZFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSelectedColor As MG_ToolStripColorSplitButton
    Friend WithEvents tsbElementDetails As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuAxisLimits As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents RTB As MG_RichTextBox
    Friend WithEvents tblScreens As TableLayoutPanel
    Friend WithEvents MG_Viewer4 As MG_BasicViewer
    Friend WithEvents MG_Viewer3 As MG_BasicViewer
    Friend WithEvents MG_Viewer2 As MG_BasicViewer
    Friend WithEvents MG_Viewer1 As MG_BasicViewer
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsbSaveFile As ToolStripButton
    Friend WithEvents tsbToggleEditor As ToolStripButton
    Friend WithEvents tsbColorize As ToolStripButton
    Friend WithEvents tsbAddSpaces As ToolStripButton
    Friend WithEvents tsbPlot As ToolStripButton
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents tsbNewFile As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsbTouch As ToolStripButton
    Friend WithEvents NC_Player As NC_Player
    Friend WithEvents tsbView As ToolStripDropDownButton
    Friend WithEvents tsmTop As ToolStripMenuItem
    Friend WithEvents tsmFront As ToolStripMenuItem
    Friend WithEvents tsmRight As ToolStripMenuItem
    Friend WithEvents tsmISO As ToolStripMenuItem
    Friend WithEvents mnuWeb As ToolStripMenuItem
    Friend WithEvents tsbSaveAs As ToolStripButton
    Friend WithEvents tsCboScheme As ToolStripComboBox
    Friend WithEvents tsbAutoZoom As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbMotionColor As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
#End Region
End Class