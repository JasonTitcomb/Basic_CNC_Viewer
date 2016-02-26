<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmViewerSetup
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
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents tabGeneral As System.Windows.Forms.TabPage
    Public WithEvents optMachineType2 As System.Windows.Forms.RadioButton
    Public WithEvents optMachineType1 As System.Windows.Forms.RadioButton
    Public WithEvents optMachineType3 As System.Windows.Forms.RadioButton
    Public WithEvents tabMachineType As System.Windows.Forms.TabPage
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label34 As System.Windows.Forms.Label
    Public WithEvents txtSubcall As System.Windows.Forms.TextBox
    Public WithEvents txtReturn As System.Windows.Forms.TextBox
    Public WithEvents txtBlockSkip As System.Windows.Forms.TextBox
    Public WithEvents txtProgramId As System.Windows.Forms.TextBox
    Public WithEvents txtEndmain As System.Windows.Forms.TextBox
    Public WithEvents cboPrecision As System.Windows.Forms.ComboBox
    Public WithEvents txtSubRepeats As System.Windows.Forms.TextBox
    Public WithEvents tabMachineSettings As System.Windows.Forms.TabPage
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtYZplane As System.Windows.Forms.TextBox
    Public WithEvents txtXZplane As System.Windows.Forms.TextBox
    Public WithEvents txtXYplane As System.Windows.Forms.TextBox
    Public WithEvents txtAbs As System.Windows.Forms.TextBox
    Public WithEvents txtInc As System.Windows.Forms.TextBox
    Public WithEvents txtRapid As System.Windows.Forms.TextBox
    Public WithEvents txtCWarc As System.Windows.Forms.TextBox
    Public WithEvents txtCCarc As System.Windows.Forms.TextBox
    Public WithEvents txtLinear As System.Windows.Forms.TextBox
    Public WithEvents tabMotionCodes As System.Windows.Forms.TabPage
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents txtDrills_0 As System.Windows.Forms.TextBox
    Public WithEvents txtDrills_1 As System.Windows.Forms.TextBox
    Public WithEvents txtDrills_2 As System.Windows.Forms.TextBox
    Public WithEvents txtDrills_3 As System.Windows.Forms.TextBox
    Public WithEvents txtDrills_4 As System.Windows.Forms.TextBox
    Public WithEvents txtDrills_5 As System.Windows.Forms.TextBox
    Public WithEvents txtDrills_6 As System.Windows.Forms.TextBox
    Public WithEvents txtDrills_7 As System.Windows.Forms.TextBox
    Public WithEvents txtDrills_8 As System.Windows.Forms.TextBox
    Public WithEvents txtDrills_9 As System.Windows.Forms.TextBox
    Public WithEvents txtDrills_10 As System.Windows.Forms.TextBox
    Public WithEvents txtDrillReturnInitialPln As System.Windows.Forms.TextBox
    Public WithEvents txtDrillReturnRapidPln As System.Windows.Forms.TextBox
    Public WithEvents txtDrillRapid As System.Windows.Forms.TextBox
    Public WithEvents tabDrilling As System.Windows.Forms.TabPage
    Public WithEvents VScroll1 As System.Windows.Forms.VScrollBar
    Public WithEvents optZ As System.Windows.Forms.RadioButton
    Public WithEvents optY As System.Windows.Forms.RadioButton
    Public WithEvents optX As System.Windows.Forms.RadioButton
    Public WithEvents Picture1 As System.Windows.Forms.Panel
    Public WithEvents btnTopView As System.Windows.Forms.Button
    Public WithEvents btnFrontView As System.Windows.Forms.Button
    Public WithEvents btnSideView As System.Windows.Forms.Button
    Public WithEvents btnIsoView As System.Windows.Forms.Button
    Public WithEvents btnLatheView As System.Windows.Forms.Button
    Public WithEvents tabView As System.Windows.Forms.TabPage
    Public WithEvents chkReverseRot As System.Windows.Forms.CheckBox
    Public WithEvents optRotateType1 As System.Windows.Forms.RadioButton
    Public WithEvents optRotateType2 As System.Windows.Forms.RadioButton
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents txtViewShift_0 As System.Windows.Forms.TextBox
    Public WithEvents txtViewShift_1 As System.Windows.Forms.TextBox
    Public WithEvents txtViewShift_2 As System.Windows.Forms.TextBox
    Public WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents Label31 As System.Windows.Forms.Label
    Public WithEvents Label32 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents cboRotPrecision As System.Windows.Forms.ComboBox
    Public WithEvents cboRotAxis As System.Windows.Forms.ComboBox
    Public WithEvents txtRotAxis As System.Windows.Forms.TextBox
    Public WithEvents Label33 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    Public WithEvents tabRotary As System.Windows.Forms.TabPage
    Public WithEvents Tab1 As System.Windows.Forms.TabControl
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Tab1 = New System.Windows.Forms.TabControl()
        Me.tabGeneral = New System.Windows.Forms.TabPage()
        Me.chkIgnoreSpaces = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboMachines = New System.Windows.Forms.ComboBox()
        Me.txtGlobalReplacements = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.tabMachineType = New System.Windows.Forms.TabPage()
        Me.chkInvertArcCenterValues = New System.Windows.Forms.CheckBox()
        Me.optMachineType2 = New System.Windows.Forms.RadioButton()
        Me.optMachineType1 = New System.Windows.Forms.RadioButton()
        Me.optMachineType3 = New System.Windows.Forms.RadioButton()
        Me.chkUVW = New System.Windows.Forms.CheckBox()
        Me.chkAbsCenter = New System.Windows.Forms.CheckBox()
        Me.tabMachineSettings = New System.Windows.Forms.TabPage()
        Me.btnLimitsColor = New System.Windows.Forms.Button()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.cboUnits = New System.Windows.Forms.ComboBox()
        Me.txtCommentChars = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblToolChange = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtSubcall = New System.Windows.Forms.TextBox()
        Me.txtHomeZValue = New System.Windows.Forms.TextBox()
        Me.txtHomeYValue = New System.Windows.Forms.TextBox()
        Me.txtHomeZAddress = New System.Windows.Forms.TextBox()
        Me.txtMaxZ = New System.Windows.Forms.TextBox()
        Me.txtMaxY = New System.Windows.Forms.TextBox()
        Me.txtMaxX = New System.Windows.Forms.TextBox()
        Me.txtMinZ = New System.Windows.Forms.TextBox()
        Me.txtMinY = New System.Windows.Forms.TextBox()
        Me.txtMinX = New System.Windows.Forms.TextBox()
        Me.txtHomeXValue = New System.Windows.Forms.TextBox()
        Me.txtHomeYAddress = New System.Windows.Forms.TextBox()
        Me.txtHomeXAddress = New System.Windows.Forms.TextBox()
        Me.txtToolChange = New System.Windows.Forms.TextBox()
        Me.txtReturnHome = New System.Windows.Forms.TextBox()
        Me.txtUnitsEnglish = New System.Windows.Forms.TextBox()
        Me.txtUnitsMetric = New System.Windows.Forms.TextBox()
        Me.txtReturn = New System.Windows.Forms.TextBox()
        Me.txtBlockSkip = New System.Windows.Forms.TextBox()
        Me.txtProgramId = New System.Windows.Forms.TextBox()
        Me.txtEndmain = New System.Windows.Forms.TextBox()
        Me.cboPrecision = New System.Windows.Forms.ComboBox()
        Me.txtSubRepeats = New System.Windows.Forms.TextBox()
        Me.tabSpeedFeed = New System.Windows.Forms.TabPage()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtSpeedModeSFM = New System.Windows.Forms.TextBox()
        Me.txtSpeedModeRPM = New System.Windows.Forms.TextBox()
        Me.txtMaxRpmCode = New System.Windows.Forms.TextBox()
        Me.txtFeedModeMin = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtFeedModeRev = New System.Windows.Forms.TextBox()
        Me.cboFeedPrecision = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtMaxRPMDefault = New System.Windows.Forms.TextBox()
        Me.txtRapidRate = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tabMotionCodes = New System.Windows.Forms.TabPage()
        Me.chkDogLeg = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtYZplane = New System.Windows.Forms.TextBox()
        Me.txtXZplane = New System.Windows.Forms.TextBox()
        Me.txtXYplane = New System.Windows.Forms.TextBox()
        Me.txtCompCancel = New System.Windows.Forms.TextBox()
        Me.txtCompRight = New System.Windows.Forms.TextBox()
        Me.txtCompLeft = New System.Windows.Forms.TextBox()
        Me.txtAbs = New System.Windows.Forms.TextBox()
        Me.txtInc = New System.Windows.Forms.TextBox()
        Me.txtRapid = New System.Windows.Forms.TextBox()
        Me.txtCWarc = New System.Windows.Forms.TextBox()
        Me.txtCCarc = New System.Windows.Forms.TextBox()
        Me.txtLinear = New System.Windows.Forms.TextBox()
        Me.tabDrilling = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtDrills_0 = New System.Windows.Forms.TextBox()
        Me.txtDrills_1 = New System.Windows.Forms.TextBox()
        Me.txtDrills_2 = New System.Windows.Forms.TextBox()
        Me.txtDrills_3 = New System.Windows.Forms.TextBox()
        Me.txtDrills_4 = New System.Windows.Forms.TextBox()
        Me.txtDrills_5 = New System.Windows.Forms.TextBox()
        Me.txtDrills_6 = New System.Windows.Forms.TextBox()
        Me.txtDrills_7 = New System.Windows.Forms.TextBox()
        Me.txtDrills_8 = New System.Windows.Forms.TextBox()
        Me.txtDrills_9 = New System.Windows.Forms.TextBox()
        Me.txtDrills_10 = New System.Windows.Forms.TextBox()
        Me.txtDrillReturnInitialPln = New System.Windows.Forms.TextBox()
        Me.txtDrillReturnRapidPln = New System.Windows.Forms.TextBox()
        Me.txtDrillRapid = New System.Windows.Forms.TextBox()
        Me.tabView = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.chkReverseMouseWheel = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkShowExtraOverlayInfo = New System.Windows.Forms.CheckBox()
        Me.lblFontSize = New System.Windows.Forms.Label()
        Me.cboSize = New System.Windows.Forms.ComboBox()
        Me.lblFont = New System.Windows.Forms.Label()
        Me.cboFont = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblColorSample = New System.Windows.Forms.Label()
        Me.pbColorPicker2 = New System.Windows.Forms.PictureBox()
        Me.pbToolColors = New System.Windows.Forms.PictureBox()
        Me.Picture1 = New System.Windows.Forms.Panel()
        Me.VScroll1 = New System.Windows.Forms.VScrollBar()
        Me.optZ = New System.Windows.Forms.RadioButton()
        Me.optY = New System.Windows.Forms.RadioButton()
        Me.optX = New System.Windows.Forms.RadioButton()
        Me.btnTopView = New System.Windows.Forms.Button()
        Me.btnFrontView = New System.Windows.Forms.Button()
        Me.btnSideView = New System.Windows.Forms.Button()
        Me.btnIsoView = New System.Windows.Forms.Button()
        Me.btnLatheView = New System.Windows.Forms.Button()
        Me.tabRotary = New System.Windows.Forms.TabPage()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.chkReverseRot = New System.Windows.Forms.CheckBox()
        Me.optRotateType1 = New System.Windows.Forms.RadioButton()
        Me.optRotateType2 = New System.Windows.Forms.RadioButton()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.txtViewShift_0 = New System.Windows.Forms.TextBox()
        Me.txtViewShift_1 = New System.Windows.Forms.TextBox()
        Me.txtViewShift_2 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.cboRotPrecision = New System.Windows.Forms.ComboBox()
        Me.cboRotAxis = New System.Windows.Forms.ComboBox()
        Me.txtRotAxis = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tabPrint = New System.Windows.Forms.TabPage()
        Me.txtPrintScale = New System.Windows.Forms.TextBox()
        Me.rdoPrintScaled = New System.Windows.Forms.RadioButton()
        Me.rdoPrintActualSize = New System.Windows.Forms.RadioButton()
        Me.rdoPrintAsShown = New System.Windows.Forms.RadioButton()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsSchemes = New System.Windows.Forms.ToolStrip()
        Me.tsbNewScheme = New System.Windows.Forms.ToolStripButton()
        Me.tsbSaveFile = New System.Windows.Forms.ToolStripButton()
        Me.tsbCopy = New System.Windows.Forms.ToolStripButton()
        Me.tsbRename = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.cboCCWarcColor = New MacGen.ColorCombo()
        Me.cboCWarcColor = New MacGen.ColorCombo()
        Me.cboLineColor = New MacGen.ColorCombo()
        Me.cboRapidColor = New MacGen.ColorCombo()
        Me.cboColor = New MacGen.ColorCombo()
        Me.MG_Viewer1 = New MacGen.MG_BasicViewer()
        Me.Tab1.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.tabMachineType.SuspendLayout()
        Me.tabMachineSettings.SuspendLayout()
        Me.tabSpeedFeed.SuspendLayout()
        Me.tabMotionCodes.SuspendLayout()
        Me.tabDrilling.SuspendLayout()
        Me.tabView.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbColorPicker2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbToolColors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Picture1.SuspendLayout()
        Me.tabRotary.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.tabPrint.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.tsSchemes.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.AcceptsReturn = True
        Me.txtSearch.BackColor = System.Drawing.SystemColors.Window
        Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSearch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSearch.Location = New System.Drawing.Point(258, 40)
        Me.txtSearch.MaxLength = 128
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.Size = New System.Drawing.Size(169, 20)
        Me.txtSearch.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtSearch, "If this string is found in the file then this setup is used.")
        '
        'Tab1
        '
        Me.Tab1.CausesValidation = False
        Me.Tab1.Controls.Add(Me.tabGeneral)
        Me.Tab1.Controls.Add(Me.tabMachineType)
        Me.Tab1.Controls.Add(Me.tabMachineSettings)
        Me.Tab1.Controls.Add(Me.tabSpeedFeed)
        Me.Tab1.Controls.Add(Me.tabMotionCodes)
        Me.Tab1.Controls.Add(Me.tabDrilling)
        Me.Tab1.Controls.Add(Me.tabView)
        Me.Tab1.Controls.Add(Me.tabRotary)
        Me.Tab1.Controls.Add(Me.tabPrint)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab1.ItemSize = New System.Drawing.Size(42, 20)
        Me.Tab1.Location = New System.Drawing.Point(0, 25)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedIndex = 0
        Me.Tab1.Size = New System.Drawing.Size(825, 503)
        Me.Tab1.TabIndex = 0
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.chkIgnoreSpaces)
        Me.tabGeneral.Controls.Add(Me.Label11)
        Me.tabGeneral.Controls.Add(Me.Label39)
        Me.tabGeneral.Controls.Add(Me.Label13)
        Me.tabGeneral.Controls.Add(Me.Label4)
        Me.tabGeneral.Controls.Add(Me.cboMachines)
        Me.tabGeneral.Controls.Add(Me.txtGlobalReplacements)
        Me.tabGeneral.Controls.Add(Me.txtDescription)
        Me.tabGeneral.Controls.Add(Me.txtSearch)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 24)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Size = New System.Drawing.Size(817, 475)
        Me.tabGeneral.TabIndex = 0
        Me.tabGeneral.Text = "General Settings"
        Me.tabGeneral.UseVisualStyleBackColor = True
        '
        'chkIgnoreSpaces
        '
        Me.chkIgnoreSpaces.AutoSize = True
        Me.chkIgnoreSpaces.Checked = Global.MacGen.My.MySettings.Default.IgnoreFileWhitespace
        Me.chkIgnoreSpaces.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIgnoreSpaces.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.MacGen.My.MySettings.Default, "IgnoreFileWhitespace", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkIgnoreSpaces.Location = New System.Drawing.Point(9, 352)
        Me.chkIgnoreSpaces.Name = "chkIgnoreSpaces"
        Me.chkIgnoreSpaces.Size = New System.Drawing.Size(184, 18)
        Me.chkIgnoreSpaces.TabIndex = 5
        Me.chkIgnoreSpaces.Text = "Ignore whitespace while parsing"
        Me.chkIgnoreSpaces.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Location = New System.Drawing.Point(8, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(105, 25)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Setup Name:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(8, 216)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(192, 21)
        Me.Label39.TabIndex = 4
        Me.Label39.Text = "Global Pre-process Replacements:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(8, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(105, 28)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Comments:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(255, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(172, 27)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Setup Search String:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cboMachines
        '
        Me.cboMachines.BackColor = System.Drawing.SystemColors.Window
        Me.cboMachines.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMachines.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMachines.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMachines.Location = New System.Drawing.Point(8, 38)
        Me.cboMachines.Name = "cboMachines"
        Me.cboMachines.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboMachines.Size = New System.Drawing.Size(169, 22)
        Me.cboMachines.TabIndex = 0
        '
        'txtGlobalReplacements
        '
        Me.txtGlobalReplacements.AcceptsReturn = True
        Me.txtGlobalReplacements.AcceptsTab = True
        Me.txtGlobalReplacements.BackColor = System.Drawing.SystemColors.Window
        Me.txtGlobalReplacements.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlobalReplacements.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGlobalReplacements.Location = New System.Drawing.Point(8, 240)
        Me.txtGlobalReplacements.MaxLength = 256
        Me.txtGlobalReplacements.Multiline = True
        Me.txtGlobalReplacements.Name = "txtGlobalReplacements"
        Me.txtGlobalReplacements.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGlobalReplacements.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGlobalReplacements.Size = New System.Drawing.Size(419, 96)
        Me.txtGlobalReplacements.TabIndex = 3
        Me.txtGlobalReplacements.Tag = "Global replacement regular expressions"
        '
        'txtDescription
        '
        Me.txtDescription.AcceptsReturn = True
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDescription.Location = New System.Drawing.Point(8, 106)
        Me.txtDescription.MaxLength = 256
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(419, 78)
        Me.txtDescription.TabIndex = 3
        Me.txtDescription.Tag = "Description of template file."
        '
        'tabMachineType
        '
        Me.tabMachineType.Controls.Add(Me.chkInvertArcCenterValues)
        Me.tabMachineType.Controls.Add(Me.optMachineType2)
        Me.tabMachineType.Controls.Add(Me.optMachineType1)
        Me.tabMachineType.Controls.Add(Me.optMachineType3)
        Me.tabMachineType.Controls.Add(Me.chkUVW)
        Me.tabMachineType.Controls.Add(Me.chkAbsCenter)
        Me.tabMachineType.Location = New System.Drawing.Point(4, 24)
        Me.tabMachineType.Name = "tabMachineType"
        Me.tabMachineType.Size = New System.Drawing.Size(817, 475)
        Me.tabMachineType.TabIndex = 1
        Me.tabMachineType.Text = "Machine Type"
        Me.tabMachineType.UseVisualStyleBackColor = True
        '
        'chkInvertArcCenterValues
        '
        Me.chkInvertArcCenterValues.AutoSize = True
        Me.chkInvertArcCenterValues.Location = New System.Drawing.Point(281, 49)
        Me.chkInvertArcCenterValues.Name = "chkInvertArcCenterValues"
        Me.chkInvertArcCenterValues.Size = New System.Drawing.Size(141, 18)
        Me.chkInvertArcCenterValues.TabIndex = 4
        Me.chkInvertArcCenterValues.Text = "Invert arc center values"
        Me.chkInvertArcCenterValues.UseVisualStyleBackColor = True
        '
        'optMachineType2
        '
        Me.optMachineType2.AutoSize = True
        Me.optMachineType2.Cursor = System.Windows.Forms.Cursors.Default
        Me.optMachineType2.Location = New System.Drawing.Point(24, 64)
        Me.optMachineType2.Name = "optMachineType2"
        Me.optMachineType2.Size = New System.Drawing.Size(82, 18)
        Me.optMachineType2.TabIndex = 1
        Me.optMachineType2.TabStop = True
        Me.optMachineType2.Text = "Lathe {Rad}"
        '
        'optMachineType1
        '
        Me.optMachineType1.AutoSize = True
        Me.optMachineType1.Checked = True
        Me.optMachineType1.Cursor = System.Windows.Forms.Cursors.Default
        Me.optMachineType1.Location = New System.Drawing.Point(24, 24)
        Me.optMachineType1.Name = "optMachineType1"
        Me.optMachineType1.Size = New System.Drawing.Size(81, 18)
        Me.optMachineType1.TabIndex = 0
        Me.optMachineType1.TabStop = True
        Me.optMachineType1.Text = "Lathe {Dia.}"
        '
        'optMachineType3
        '
        Me.optMachineType3.AutoSize = True
        Me.optMachineType3.Cursor = System.Windows.Forms.Cursors.Default
        Me.optMachineType3.Location = New System.Drawing.Point(24, 104)
        Me.optMachineType3.Name = "optMachineType3"
        Me.optMachineType3.Size = New System.Drawing.Size(158, 18)
        Me.optMachineType3.TabIndex = 2
        Me.optMachineType3.TabStop = True
        Me.optMachineType3.Text = "Mill {Output in X and Y axis}"
        '
        'chkUVW
        '
        Me.chkUVW.AutoSize = True
        Me.chkUVW.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkUVW.Location = New System.Drawing.Point(281, 105)
        Me.chkUVW.Name = "chkUVW"
        Me.chkUVW.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkUVW.Size = New System.Drawing.Size(180, 18)
        Me.chkUVW.TabIndex = 5
        Me.chkUVW.Text = "Use U,V,W for incremental shift."
        '
        'chkAbsCenter
        '
        Me.chkAbsCenter.AutoSize = True
        Me.chkAbsCenter.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAbsCenter.Location = New System.Drawing.Point(281, 25)
        Me.chkAbsCenter.Name = "chkAbsCenter"
        Me.chkAbsCenter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAbsCenter.Size = New System.Drawing.Size(191, 18)
        Me.chkAbsCenter.TabIndex = 3
        Me.chkAbsCenter.Text = "Arc center is an absolute position."
        '
        'tabMachineSettings
        '
        Me.tabMachineSettings.Controls.Add(Me.btnLimitsColor)
        Me.tabMachineSettings.Controls.Add(Me.Label56)
        Me.tabMachineSettings.Controls.Add(Me.Label55)
        Me.tabMachineSettings.Controls.Add(Me.cboUnits)
        Me.tabMachineSettings.Controls.Add(Me.txtCommentChars)
        Me.tabMachineSettings.Controls.Add(Me.Label2)
        Me.tabMachineSettings.Controls.Add(Me.Label46)
        Me.tabMachineSettings.Controls.Add(Me.Label43)
        Me.tabMachineSettings.Controls.Add(Me.Label45)
        Me.tabMachineSettings.Controls.Add(Me.Label42)
        Me.tabMachineSettings.Controls.Add(Me.Label58)
        Me.tabMachineSettings.Controls.Add(Me.Label57)
        Me.tabMachineSettings.Controls.Add(Me.Label54)
        Me.tabMachineSettings.Controls.Add(Me.Label44)
        Me.tabMachineSettings.Controls.Add(Me.Label41)
        Me.tabMachineSettings.Controls.Add(Me.lblToolChange)
        Me.tabMachineSettings.Controls.Add(Me.Label40)
        Me.tabMachineSettings.Controls.Add(Me.Label52)
        Me.tabMachineSettings.Controls.Add(Me.Label53)
        Me.tabMachineSettings.Controls.Add(Me.Label8)
        Me.tabMachineSettings.Controls.Add(Me.Label12)
        Me.tabMachineSettings.Controls.Add(Me.Label9)
        Me.tabMachineSettings.Controls.Add(Me.Label14)
        Me.tabMachineSettings.Controls.Add(Me.Label15)
        Me.tabMachineSettings.Controls.Add(Me.Label51)
        Me.tabMachineSettings.Controls.Add(Me.Label22)
        Me.tabMachineSettings.Controls.Add(Me.Label34)
        Me.tabMachineSettings.Controls.Add(Me.txtSubcall)
        Me.tabMachineSettings.Controls.Add(Me.txtHomeZValue)
        Me.tabMachineSettings.Controls.Add(Me.txtHomeYValue)
        Me.tabMachineSettings.Controls.Add(Me.txtHomeZAddress)
        Me.tabMachineSettings.Controls.Add(Me.txtMaxZ)
        Me.tabMachineSettings.Controls.Add(Me.txtMaxY)
        Me.tabMachineSettings.Controls.Add(Me.txtMaxX)
        Me.tabMachineSettings.Controls.Add(Me.txtMinZ)
        Me.tabMachineSettings.Controls.Add(Me.txtMinY)
        Me.tabMachineSettings.Controls.Add(Me.txtMinX)
        Me.tabMachineSettings.Controls.Add(Me.txtHomeXValue)
        Me.tabMachineSettings.Controls.Add(Me.txtHomeYAddress)
        Me.tabMachineSettings.Controls.Add(Me.txtHomeXAddress)
        Me.tabMachineSettings.Controls.Add(Me.txtToolChange)
        Me.tabMachineSettings.Controls.Add(Me.txtReturnHome)
        Me.tabMachineSettings.Controls.Add(Me.txtUnitsEnglish)
        Me.tabMachineSettings.Controls.Add(Me.txtUnitsMetric)
        Me.tabMachineSettings.Controls.Add(Me.txtReturn)
        Me.tabMachineSettings.Controls.Add(Me.txtBlockSkip)
        Me.tabMachineSettings.Controls.Add(Me.txtProgramId)
        Me.tabMachineSettings.Controls.Add(Me.txtEndmain)
        Me.tabMachineSettings.Controls.Add(Me.cboPrecision)
        Me.tabMachineSettings.Controls.Add(Me.txtSubRepeats)
        Me.tabMachineSettings.Location = New System.Drawing.Point(4, 24)
        Me.tabMachineSettings.Name = "tabMachineSettings"
        Me.tabMachineSettings.Size = New System.Drawing.Size(817, 475)
        Me.tabMachineSettings.TabIndex = 2
        Me.tabMachineSettings.Text = "Machine Settings"
        Me.tabMachineSettings.UseVisualStyleBackColor = True
        '
        'btnLimitsColor
        '
        Me.btnLimitsColor.BackgroundImage = Global.MacGen.My.Resources.Resources.ColorPicker
        Me.btnLimitsColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimitsColor.Location = New System.Drawing.Point(485, 301)
        Me.btnLimitsColor.Name = "btnLimitsColor"
        Me.btnLimitsColor.Size = New System.Drawing.Size(24, 23)
        Me.btnLimitsColor.TabIndex = 39
        Me.btnLimitsColor.UseVisualStyleBackColor = True
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(593, 305)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(23, 14)
        Me.Label56.TabIndex = 34
        Me.Label56.Text = "Min"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(516, 305)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(27, 14)
        Me.Label55.TabIndex = 33
        Me.Label55.Text = "Max"
        '
        'cboUnits
        '
        Me.cboUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnits.FormattingEnabled = True
        Me.cboUnits.Items.AddRange(New Object() {"Inch", "Metric"})
        Me.cboUnits.Location = New System.Drawing.Point(189, 67)
        Me.cboUnits.Name = "cboUnits"
        Me.cboUnits.Size = New System.Drawing.Size(83, 22)
        Me.cboUnits.TabIndex = 32
        '
        'txtCommentChars
        '
        Me.txtCommentChars.Location = New System.Drawing.Point(223, 198)
        Me.txtCommentChars.MaxLength = 8
        Me.txtCommentChars.Name = "txtCommentChars"
        Me.txtCommentChars.Size = New System.Drawing.Size(49, 20)
        Me.txtCommentChars.TabIndex = 13
        Me.txtCommentChars.Text = "();"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(449, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(150, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Sub program call:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label46.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(242, 388)
        Me.Label46.Name = "Label46"
        Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label46.Size = New System.Drawing.Size(46, 14)
        Me.Label46.TabIndex = 30
        Me.Label46.Text = "Z value:"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label43.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(87, 389)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label43.Size = New System.Drawing.Size(90, 20)
        Me.Label43.TabIndex = 28
        Me.Label43.Text = "Z address:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label45.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(241, 361)
        Me.Label45.Name = "Label45"
        Me.Label45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label45.Size = New System.Drawing.Size(47, 14)
        Me.Label45.TabIndex = 26
        Me.Label45.Text = "Y value:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label42.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(95, 360)
        Me.Label42.Name = "Label42"
        Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label42.Size = New System.Drawing.Size(82, 20)
        Me.Label42.TabIndex = 24
        Me.Label42.Text = "Y address:"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(426, 385)
        Me.Label58.Name = "Label58"
        Me.Label58.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label58.Size = New System.Drawing.Size(84, 20)
        Me.Label58.TabIndex = 22
        Me.Label58.Text = "Z limits:"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label57.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.Black
        Me.Label57.Location = New System.Drawing.Point(425, 358)
        Me.Label57.Name = "Label57"
        Me.Label57.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label57.Size = New System.Drawing.Size(84, 20)
        Me.Label57.TabIndex = 22
        Me.Label57.Text = "Y limits:"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label54.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.Black
        Me.Label54.Location = New System.Drawing.Point(426, 328)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label54.Size = New System.Drawing.Size(84, 20)
        Me.Label54.TabIndex = 22
        Me.Label54.Text = "X limits:"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label44.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(241, 331)
        Me.Label44.Name = "Label44"
        Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label44.Size = New System.Drawing.Size(46, 14)
        Me.Label44.TabIndex = 22
        Me.Label44.Text = "X value:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label41.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(95, 331)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label41.Size = New System.Drawing.Size(82, 20)
        Me.Label41.TabIndex = 20
        Me.Label41.Text = "X address:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblToolChange
        '
        Me.lblToolChange.BackColor = System.Drawing.Color.Transparent
        Me.lblToolChange.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblToolChange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToolChange.ForeColor = System.Drawing.Color.Black
        Me.lblToolChange.Location = New System.Drawing.Point(448, 252)
        Me.lblToolChange.Name = "lblToolChange"
        Me.lblToolChange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblToolChange.Size = New System.Drawing.Size(150, 20)
        Me.lblToolChange.TabIndex = 18
        Me.lblToolChange.Text = "Tool change:"
        Me.lblToolChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label40.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(27, 298)
        Me.Label40.Name = "Label40"
        Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label40.Size = New System.Drawing.Size(150, 20)
        Me.Label40.TabIndex = 16
        Me.Label40.Text = "Return to home:"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label52.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(448, 34)
        Me.Label52.Name = "Label52"
        Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label52.Size = New System.Drawing.Size(150, 20)
        Me.Label52.TabIndex = 2
        Me.Label52.Text = "English units:"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label53.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(449, 67)
        Me.Label53.Name = "Label53"
        Me.Label53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label53.Size = New System.Drawing.Size(150, 20)
        Me.Label53.TabIndex = 2
        Me.Label53.Text = "Metric units:"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(449, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(150, 20)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Return to main:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(36, 199)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(175, 20)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Comment characters:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(36, 163)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(175, 20)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Block skip characters:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(36, 129)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(175, 20)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Program identification:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(449, 161)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(150, 20)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Main program end:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label51.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(3, 71)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label51.Size = New System.Drawing.Size(175, 20)
        Me.Label51.TabIndex = 0
        Me.Label51.Text = "Default machine units:"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(2, 37)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(175, 20)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Machine precision:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(449, 227)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(150, 20)
        Me.Label34.TabIndex = 14
        Me.Label34.Text = "Repeat character:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSubcall
        '
        Me.txtSubcall.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubcall.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSubcall.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubcall.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSubcall.Location = New System.Drawing.Point(604, 191)
        Me.txtSubcall.MaxLength = 8
        Me.txtSubcall.Name = "txtSubcall"
        Me.txtSubcall.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSubcall.Size = New System.Drawing.Size(49, 20)
        Me.txtSubcall.TabIndex = 11
        Me.txtSubcall.Tag = "2Required"
        Me.txtSubcall.Text = "M98"
        '
        'txtHomeZValue
        '
        Me.txtHomeZValue.BackColor = System.Drawing.SystemColors.Window
        Me.txtHomeZValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHomeZValue.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomeZValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHomeZValue.Location = New System.Drawing.Point(305, 387)
        Me.txtHomeZValue.MaxLength = 8
        Me.txtHomeZValue.Name = "txtHomeZValue"
        Me.txtHomeZValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHomeZValue.Size = New System.Drawing.Size(80, 20)
        Me.txtHomeZValue.TabIndex = 31
        Me.txtHomeZValue.Tag = "2Required"
        Me.txtHomeZValue.Text = "0.0"
        '
        'txtHomeYValue
        '
        Me.txtHomeYValue.BackColor = System.Drawing.SystemColors.Window
        Me.txtHomeYValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHomeYValue.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomeYValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHomeYValue.Location = New System.Drawing.Point(305, 358)
        Me.txtHomeYValue.MaxLength = 8
        Me.txtHomeYValue.Name = "txtHomeYValue"
        Me.txtHomeYValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHomeYValue.Size = New System.Drawing.Size(80, 20)
        Me.txtHomeYValue.TabIndex = 27
        Me.txtHomeYValue.Tag = "2Required"
        Me.txtHomeYValue.Text = "0.0"
        '
        'txtHomeZAddress
        '
        Me.txtHomeZAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtHomeZAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHomeZAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomeZAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHomeZAddress.Location = New System.Drawing.Point(183, 388)
        Me.txtHomeZAddress.MaxLength = 1
        Me.txtHomeZAddress.Name = "txtHomeZAddress"
        Me.txtHomeZAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHomeZAddress.Size = New System.Drawing.Size(32, 20)
        Me.txtHomeZAddress.TabIndex = 29
        Me.txtHomeZAddress.Tag = "2Required"
        Me.txtHomeZAddress.Text = "W"
        '
        'txtMaxZ
        '
        Me.txtMaxZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtMaxZ.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxZ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMaxZ.Location = New System.Drawing.Point(516, 385)
        Me.txtMaxZ.MaxLength = 8
        Me.txtMaxZ.Name = "txtMaxZ"
        Me.txtMaxZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMaxZ.Size = New System.Drawing.Size(61, 20)
        Me.txtMaxZ.TabIndex = 36
        Me.txtMaxZ.Tag = "2Required"
        Me.txtMaxZ.Text = "0"
        '
        'txtMaxY
        '
        Me.txtMaxY.BackColor = System.Drawing.SystemColors.Window
        Me.txtMaxY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMaxY.Location = New System.Drawing.Point(515, 358)
        Me.txtMaxY.MaxLength = 8
        Me.txtMaxY.Name = "txtMaxY"
        Me.txtMaxY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMaxY.Size = New System.Drawing.Size(61, 20)
        Me.txtMaxY.TabIndex = 34
        Me.txtMaxY.Tag = "2Required"
        Me.txtMaxY.Text = "0"
        '
        'txtMaxX
        '
        Me.txtMaxX.BackColor = System.Drawing.SystemColors.Window
        Me.txtMaxX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMaxX.Location = New System.Drawing.Point(516, 328)
        Me.txtMaxX.MaxLength = 8
        Me.txtMaxX.Name = "txtMaxX"
        Me.txtMaxX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMaxX.Size = New System.Drawing.Size(61, 20)
        Me.txtMaxX.TabIndex = 32
        Me.txtMaxX.Tag = "2Required"
        Me.txtMaxX.Text = "0"
        '
        'txtMinZ
        '
        Me.txtMinZ.BackColor = System.Drawing.SystemColors.Window
        Me.txtMinZ.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinZ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMinZ.Location = New System.Drawing.Point(593, 385)
        Me.txtMinZ.MaxLength = 8
        Me.txtMinZ.Name = "txtMinZ"
        Me.txtMinZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMinZ.Size = New System.Drawing.Size(61, 20)
        Me.txtMinZ.TabIndex = 37
        Me.txtMinZ.Tag = "2Required"
        Me.txtMinZ.Text = "0"
        '
        'txtMinY
        '
        Me.txtMinY.BackColor = System.Drawing.SystemColors.Window
        Me.txtMinY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMinY.Location = New System.Drawing.Point(592, 358)
        Me.txtMinY.MaxLength = 8
        Me.txtMinY.Name = "txtMinY"
        Me.txtMinY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMinY.Size = New System.Drawing.Size(61, 20)
        Me.txtMinY.TabIndex = 35
        Me.txtMinY.Tag = "2Required"
        Me.txtMinY.Text = "0"
        '
        'txtMinX
        '
        Me.txtMinX.BackColor = System.Drawing.SystemColors.Window
        Me.txtMinX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMinX.Location = New System.Drawing.Point(593, 328)
        Me.txtMinX.MaxLength = 8
        Me.txtMinX.Name = "txtMinX"
        Me.txtMinX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMinX.Size = New System.Drawing.Size(61, 20)
        Me.txtMinX.TabIndex = 33
        Me.txtMinX.Tag = "2Required"
        Me.txtMinX.Text = "0"
        '
        'txtHomeXValue
        '
        Me.txtHomeXValue.BackColor = System.Drawing.SystemColors.Window
        Me.txtHomeXValue.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomeXValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHomeXValue.Location = New System.Drawing.Point(305, 330)
        Me.txtHomeXValue.MaxLength = 8
        Me.txtHomeXValue.Name = "txtHomeXValue"
        Me.txtHomeXValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHomeXValue.Size = New System.Drawing.Size(80, 20)
        Me.txtHomeXValue.TabIndex = 23
        Me.txtHomeXValue.Tag = "2Required"
        Me.txtHomeXValue.Text = "0.0"
        '
        'txtHomeYAddress
        '
        Me.txtHomeYAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtHomeYAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHomeYAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomeYAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHomeYAddress.Location = New System.Drawing.Point(183, 359)
        Me.txtHomeYAddress.MaxLength = 1
        Me.txtHomeYAddress.Name = "txtHomeYAddress"
        Me.txtHomeYAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHomeYAddress.Size = New System.Drawing.Size(32, 20)
        Me.txtHomeYAddress.TabIndex = 25
        Me.txtHomeYAddress.Tag = "2Required"
        Me.txtHomeYAddress.Text = "V"
        '
        'txtHomeXAddress
        '
        Me.txtHomeXAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtHomeXAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHomeXAddress.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomeXAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHomeXAddress.Location = New System.Drawing.Point(183, 330)
        Me.txtHomeXAddress.MaxLength = 1
        Me.txtHomeXAddress.Name = "txtHomeXAddress"
        Me.txtHomeXAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHomeXAddress.Size = New System.Drawing.Size(32, 20)
        Me.txtHomeXAddress.TabIndex = 21
        Me.txtHomeXAddress.Tag = "2Required"
        Me.txtHomeXAddress.Text = "U"
        '
        'txtToolChange
        '
        Me.txtToolChange.BackColor = System.Drawing.SystemColors.Window
        Me.txtToolChange.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtToolChange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToolChange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtToolChange.Location = New System.Drawing.Point(604, 252)
        Me.txtToolChange.MaxLength = 8
        Me.txtToolChange.Name = "txtToolChange"
        Me.txtToolChange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtToolChange.Size = New System.Drawing.Size(49, 20)
        Me.txtToolChange.TabIndex = 19
        Me.txtToolChange.Tag = "2Required"
        Me.txtToolChange.Text = "M06"
        '
        'txtReturnHome
        '
        Me.txtReturnHome.BackColor = System.Drawing.SystemColors.Window
        Me.txtReturnHome.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReturnHome.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturnHome.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReturnHome.Location = New System.Drawing.Point(183, 298)
        Me.txtReturnHome.MaxLength = 8
        Me.txtReturnHome.Name = "txtReturnHome"
        Me.txtReturnHome.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReturnHome.Size = New System.Drawing.Size(48, 20)
        Me.txtReturnHome.TabIndex = 17
        Me.txtReturnHome.Tag = "2Required"
        Me.txtReturnHome.Text = "G28"
        '
        'txtUnitsEnglish
        '
        Me.txtUnitsEnglish.BackColor = System.Drawing.SystemColors.Window
        Me.txtUnitsEnglish.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUnitsEnglish.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitsEnglish.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUnitsEnglish.Location = New System.Drawing.Point(604, 33)
        Me.txtUnitsEnglish.MaxLength = 8
        Me.txtUnitsEnglish.Name = "txtUnitsEnglish"
        Me.txtUnitsEnglish.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUnitsEnglish.Size = New System.Drawing.Size(49, 20)
        Me.txtUnitsEnglish.TabIndex = 3
        Me.txtUnitsEnglish.Tag = "2Required"
        Me.txtUnitsEnglish.Text = "G20"
        '
        'txtUnitsMetric
        '
        Me.txtUnitsMetric.BackColor = System.Drawing.SystemColors.Window
        Me.txtUnitsMetric.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUnitsMetric.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitsMetric.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUnitsMetric.Location = New System.Drawing.Point(605, 66)
        Me.txtUnitsMetric.MaxLength = 8
        Me.txtUnitsMetric.Name = "txtUnitsMetric"
        Me.txtUnitsMetric.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUnitsMetric.Size = New System.Drawing.Size(49, 20)
        Me.txtUnitsMetric.TabIndex = 3
        Me.txtUnitsMetric.Tag = "2Required"
        Me.txtUnitsMetric.Text = "G21"
        '
        'txtReturn
        '
        Me.txtReturn.BackColor = System.Drawing.SystemColors.Window
        Me.txtReturn.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReturn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReturn.Location = New System.Drawing.Point(605, 127)
        Me.txtReturn.MaxLength = 8
        Me.txtReturn.Name = "txtReturn"
        Me.txtReturn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReturn.Size = New System.Drawing.Size(49, 20)
        Me.txtReturn.TabIndex = 3
        Me.txtReturn.Tag = "2Required"
        Me.txtReturn.Text = "M99"
        '
        'txtBlockSkip
        '
        Me.txtBlockSkip.BackColor = System.Drawing.SystemColors.Window
        Me.txtBlockSkip.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBlockSkip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBlockSkip.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBlockSkip.Location = New System.Drawing.Point(223, 163)
        Me.txtBlockSkip.MaxLength = 8
        Me.txtBlockSkip.Name = "txtBlockSkip"
        Me.txtBlockSkip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBlockSkip.Size = New System.Drawing.Size(49, 20)
        Me.txtBlockSkip.TabIndex = 9
        Me.txtBlockSkip.Tag = "2Required"
        Me.txtBlockSkip.Text = "/*"
        '
        'txtProgramId
        '
        Me.txtProgramId.BackColor = System.Drawing.SystemColors.Window
        Me.txtProgramId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProgramId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProgramId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtProgramId.Location = New System.Drawing.Point(223, 128)
        Me.txtProgramId.MaxLength = 8
        Me.txtProgramId.Name = "txtProgramId"
        Me.txtProgramId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtProgramId.Size = New System.Drawing.Size(49, 20)
        Me.txtProgramId.TabIndex = 5
        Me.txtProgramId.Tag = "2Required"
        Me.txtProgramId.Text = ":P$O"
        '
        'txtEndmain
        '
        Me.txtEndmain.BackColor = System.Drawing.SystemColors.Window
        Me.txtEndmain.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEndmain.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndmain.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEndmain.Location = New System.Drawing.Point(605, 159)
        Me.txtEndmain.MaxLength = 8
        Me.txtEndmain.Name = "txtEndmain"
        Me.txtEndmain.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEndmain.Size = New System.Drawing.Size(49, 20)
        Me.txtEndmain.TabIndex = 7
        Me.txtEndmain.Tag = "2Required"
        Me.txtEndmain.Text = "M30"
        '
        'cboPrecision
        '
        Me.cboPrecision.BackColor = System.Drawing.SystemColors.Window
        Me.cboPrecision.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboPrecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrecision.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrecision.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPrecision.Items.AddRange(New Object() {"0.1", "0.01", "0.001", "0.0001", "0.00001", "0.000001", "0.0000001"})
        Me.cboPrecision.Location = New System.Drawing.Point(189, 36)
        Me.cboPrecision.Name = "cboPrecision"
        Me.cboPrecision.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPrecision.Size = New System.Drawing.Size(83, 22)
        Me.cboPrecision.TabIndex = 1
        '
        'txtSubRepeats
        '
        Me.txtSubRepeats.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubRepeats.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSubRepeats.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubRepeats.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSubRepeats.Location = New System.Drawing.Point(604, 223)
        Me.txtSubRepeats.MaxLength = 1
        Me.txtSubRepeats.Name = "txtSubRepeats"
        Me.txtSubRepeats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSubRepeats.Size = New System.Drawing.Size(25, 20)
        Me.txtSubRepeats.TabIndex = 15
        Me.txtSubRepeats.Tag = "2Required"
        Me.txtSubRepeats.Text = "L"
        '
        'tabSpeedFeed
        '
        Me.tabSpeedFeed.Controls.Add(Me.Label47)
        Me.tabSpeedFeed.Controls.Add(Me.Label50)
        Me.tabSpeedFeed.Controls.Add(Me.Label49)
        Me.tabSpeedFeed.Controls.Add(Me.Label48)
        Me.tabSpeedFeed.Controls.Add(Me.Label35)
        Me.tabSpeedFeed.Controls.Add(Me.txtSpeedModeSFM)
        Me.tabSpeedFeed.Controls.Add(Me.txtSpeedModeRPM)
        Me.tabSpeedFeed.Controls.Add(Me.txtMaxRpmCode)
        Me.tabSpeedFeed.Controls.Add(Me.txtFeedModeMin)
        Me.tabSpeedFeed.Controls.Add(Me.Label28)
        Me.tabSpeedFeed.Controls.Add(Me.txtFeedModeRev)
        Me.tabSpeedFeed.Controls.Add(Me.cboFeedPrecision)
        Me.tabSpeedFeed.Controls.Add(Me.Label30)
        Me.tabSpeedFeed.Controls.Add(Me.txtMaxRPMDefault)
        Me.tabSpeedFeed.Controls.Add(Me.txtRapidRate)
        Me.tabSpeedFeed.Controls.Add(Me.Label16)
        Me.tabSpeedFeed.Location = New System.Drawing.Point(4, 24)
        Me.tabSpeedFeed.Name = "tabSpeedFeed"
        Me.tabSpeedFeed.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSpeedFeed.Size = New System.Drawing.Size(817, 475)
        Me.tabSpeedFeed.TabIndex = 7
        Me.tabSpeedFeed.Text = "Speed/Feed"
        Me.tabSpeedFeed.UseVisualStyleBackColor = True
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(35, 39)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(178, 20)
        Me.Label47.TabIndex = 0
        Me.Label47.Text = "Max machine RPM:"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label50.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(62, 151)
        Me.Label50.Name = "Label50"
        Me.Label50.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label50.Size = New System.Drawing.Size(150, 20)
        Me.Label50.TabIndex = 6
        Me.Label50.Text = "Spindle speed SFPM:"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label49.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(62, 114)
        Me.Label49.Name = "Label49"
        Me.Label49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label49.Size = New System.Drawing.Size(150, 20)
        Me.Label49.TabIndex = 4
        Me.Label49.Text = "Spindle speed RPM:"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label48.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.Black
        Me.Label48.Location = New System.Drawing.Point(62, 74)
        Me.Label48.Name = "Label48"
        Me.Label48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label48.Size = New System.Drawing.Size(150, 20)
        Me.Label48.TabIndex = 2
        Me.Label48.Text = "Spindle speed clamp:"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(354, 41)
        Me.Label35.Name = "Label35"
        Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label35.Size = New System.Drawing.Size(150, 20)
        Me.Label35.TabIndex = 8
        Me.Label35.Text = "Feed mode (unit/min):"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSpeedModeSFM
        '
        Me.txtSpeedModeSFM.BackColor = System.Drawing.SystemColors.Window
        Me.txtSpeedModeSFM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSpeedModeSFM.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpeedModeSFM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSpeedModeSFM.Location = New System.Drawing.Point(218, 150)
        Me.txtSpeedModeSFM.MaxLength = 8
        Me.txtSpeedModeSFM.Name = "txtSpeedModeSFM"
        Me.txtSpeedModeSFM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSpeedModeSFM.Size = New System.Drawing.Size(49, 20)
        Me.txtSpeedModeSFM.TabIndex = 7
        Me.txtSpeedModeSFM.Tag = "3Required"
        Me.txtSpeedModeSFM.Text = "G96"
        '
        'txtSpeedModeRPM
        '
        Me.txtSpeedModeRPM.BackColor = System.Drawing.SystemColors.Window
        Me.txtSpeedModeRPM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSpeedModeRPM.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpeedModeRPM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSpeedModeRPM.Location = New System.Drawing.Point(218, 113)
        Me.txtSpeedModeRPM.MaxLength = 8
        Me.txtSpeedModeRPM.Name = "txtSpeedModeRPM"
        Me.txtSpeedModeRPM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSpeedModeRPM.Size = New System.Drawing.Size(49, 20)
        Me.txtSpeedModeRPM.TabIndex = 5
        Me.txtSpeedModeRPM.Tag = "3Required"
        Me.txtSpeedModeRPM.Text = "G97"
        '
        'txtMaxRpmCode
        '
        Me.txtMaxRpmCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtMaxRpmCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMaxRpmCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxRpmCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMaxRpmCode.Location = New System.Drawing.Point(218, 76)
        Me.txtMaxRpmCode.MaxLength = 8
        Me.txtMaxRpmCode.Name = "txtMaxRpmCode"
        Me.txtMaxRpmCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMaxRpmCode.Size = New System.Drawing.Size(49, 20)
        Me.txtMaxRpmCode.TabIndex = 3
        Me.txtMaxRpmCode.Tag = "3Required"
        Me.txtMaxRpmCode.Text = "G50"
        '
        'txtFeedModeMin
        '
        Me.txtFeedModeMin.BackColor = System.Drawing.SystemColors.Window
        Me.txtFeedModeMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFeedModeMin.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFeedModeMin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFeedModeMin.Location = New System.Drawing.Point(509, 40)
        Me.txtFeedModeMin.MaxLength = 8
        Me.txtFeedModeMin.Name = "txtFeedModeMin"
        Me.txtFeedModeMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFeedModeMin.Size = New System.Drawing.Size(49, 20)
        Me.txtFeedModeMin.TabIndex = 9
        Me.txtFeedModeMin.Tag = "3Required"
        Me.txtFeedModeMin.Text = "G98"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(353, 74)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(150, 20)
        Me.Label28.TabIndex = 10
        Me.Label28.Text = "Feed mode (unit/rev):"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFeedModeRev
        '
        Me.txtFeedModeRev.BackColor = System.Drawing.SystemColors.Window
        Me.txtFeedModeRev.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFeedModeRev.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFeedModeRev.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFeedModeRev.Location = New System.Drawing.Point(509, 73)
        Me.txtFeedModeRev.MaxLength = 8
        Me.txtFeedModeRev.Name = "txtFeedModeRev"
        Me.txtFeedModeRev.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFeedModeRev.Size = New System.Drawing.Size(49, 20)
        Me.txtFeedModeRev.TabIndex = 11
        Me.txtFeedModeRev.Tag = "3Required"
        Me.txtFeedModeRev.Text = "G99"
        '
        'cboFeedPrecision
        '
        Me.cboFeedPrecision.BackColor = System.Drawing.SystemColors.Window
        Me.cboFeedPrecision.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboFeedPrecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeedPrecision.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFeedPrecision.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFeedPrecision.Items.AddRange(New Object() {"10000.0", "1000.0", "100.0", "10.0", "1.0", "0.1", "0.01", "0.001", "0.0001", "0.00001"})
        Me.cboFeedPrecision.Location = New System.Drawing.Point(509, 102)
        Me.cboFeedPrecision.Name = "cboFeedPrecision"
        Me.cboFeedPrecision.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboFeedPrecision.Size = New System.Drawing.Size(65, 22)
        Me.cboFeedPrecision.TabIndex = 13
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(322, 103)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(175, 20)
        Me.Label30.TabIndex = 12
        Me.Label30.Text = "Feed precision:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMaxRPMDefault
        '
        Me.txtMaxRPMDefault.Location = New System.Drawing.Point(218, 39)
        Me.txtMaxRPMDefault.Name = "txtMaxRPMDefault"
        Me.txtMaxRPMDefault.Size = New System.Drawing.Size(65, 20)
        Me.txtMaxRPMDefault.TabIndex = 1
        Me.txtMaxRPMDefault.Tag = "3Required"
        Me.txtMaxRPMDefault.Text = "5000.0"
        '
        'txtRapidRate
        '
        Me.txtRapidRate.Location = New System.Drawing.Point(509, 132)
        Me.txtRapidRate.Name = "txtRapidRate"
        Me.txtRapidRate.Size = New System.Drawing.Size(65, 20)
        Me.txtRapidRate.TabIndex = 15
        Me.txtRapidRate.Tag = "3Required"
        Me.txtRapidRate.Text = "250.0"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(322, 133)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(175, 20)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Rapid rate:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabMotionCodes
        '
        Me.tabMotionCodes.Controls.Add(Me.chkDogLeg)
        Me.tabMotionCodes.Controls.Add(Me.Label21)
        Me.tabMotionCodes.Controls.Add(Me.Label20)
        Me.tabMotionCodes.Controls.Add(Me.Label19)
        Me.tabMotionCodes.Controls.Add(Me.Label38)
        Me.tabMotionCodes.Controls.Add(Me.Label37)
        Me.tabMotionCodes.Controls.Add(Me.Label36)
        Me.tabMotionCodes.Controls.Add(Me.Label18)
        Me.tabMotionCodes.Controls.Add(Me.Label17)
        Me.tabMotionCodes.Controls.Add(Me.Label7)
        Me.tabMotionCodes.Controls.Add(Me.Label10)
        Me.tabMotionCodes.Controls.Add(Me.Label5)
        Me.tabMotionCodes.Controls.Add(Me.Label1)
        Me.tabMotionCodes.Controls.Add(Me.txtYZplane)
        Me.tabMotionCodes.Controls.Add(Me.txtXZplane)
        Me.tabMotionCodes.Controls.Add(Me.txtXYplane)
        Me.tabMotionCodes.Controls.Add(Me.txtCompCancel)
        Me.tabMotionCodes.Controls.Add(Me.txtCompRight)
        Me.tabMotionCodes.Controls.Add(Me.txtCompLeft)
        Me.tabMotionCodes.Controls.Add(Me.txtAbs)
        Me.tabMotionCodes.Controls.Add(Me.txtInc)
        Me.tabMotionCodes.Controls.Add(Me.txtRapid)
        Me.tabMotionCodes.Controls.Add(Me.txtCWarc)
        Me.tabMotionCodes.Controls.Add(Me.txtCCarc)
        Me.tabMotionCodes.Controls.Add(Me.txtLinear)
        Me.tabMotionCodes.Location = New System.Drawing.Point(4, 24)
        Me.tabMotionCodes.Name = "tabMotionCodes"
        Me.tabMotionCodes.Size = New System.Drawing.Size(817, 475)
        Me.tabMotionCodes.TabIndex = 3
        Me.tabMotionCodes.Text = "Motion Codes"
        Me.tabMotionCodes.UseVisualStyleBackColor = True
        '
        'chkDogLeg
        '
        Me.chkDogLeg.AutoSize = True
        Me.chkDogLeg.Checked = True
        Me.chkDogLeg.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDogLeg.Location = New System.Drawing.Point(315, 33)
        Me.chkDogLeg.Name = "chkDogLeg"
        Me.chkDogLeg.Size = New System.Drawing.Size(97, 18)
        Me.chkDogLeg.TabIndex = 18
        Me.chkDogLeg.Text = "Dog-leg motion"
        Me.chkDogLeg.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(312, 192)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(75, 20)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "YZ Plane:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(312, 132)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(75, 20)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "XZ Plane:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(312, 72)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(75, 20)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "XY Plane:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(61, 290)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(150, 20)
        Me.Label38.TabIndex = 10
        Me.Label38.Text = "Cutter-comp cancel:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label37.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(61, 258)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label37.Size = New System.Drawing.Size(150, 20)
        Me.Label37.TabIndex = 10
        Me.Label37.Text = "Cutter-comp right:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(61, 226)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label36.Size = New System.Drawing.Size(150, 20)
        Me.Label36.TabIndex = 10
        Me.Label36.Text = "Cutter-comp left:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(61, 194)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(150, 20)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Absolute movement:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(61, 162)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(150, 20)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Incremental movement:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(61, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(150, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Counterclockwise arcs:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(61, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(150, 20)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Clockwise arcs:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(61, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(150, 20)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Linear  movement:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(61, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(150, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rapid positioning:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtYZplane
        '
        Me.txtYZplane.AcceptsReturn = True
        Me.txtYZplane.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtYZplane.Location = New System.Drawing.Point(396, 191)
        Me.txtYZplane.MaxLength = 4
        Me.txtYZplane.Name = "txtYZplane"
        Me.txtYZplane.Size = New System.Drawing.Size(75, 20)
        Me.txtYZplane.TabIndex = 17
        Me.txtYZplane.Tag = "4Required"
        Me.txtYZplane.Text = "G19"
        '
        'txtXZplane
        '
        Me.txtXZplane.AcceptsReturn = True
        Me.txtXZplane.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtXZplane.Location = New System.Drawing.Point(396, 131)
        Me.txtXZplane.MaxLength = 4
        Me.txtXZplane.Name = "txtXZplane"
        Me.txtXZplane.Size = New System.Drawing.Size(75, 20)
        Me.txtXZplane.TabIndex = 15
        Me.txtXZplane.Tag = "4Required"
        Me.txtXZplane.Text = "G18"
        '
        'txtXYplane
        '
        Me.txtXYplane.AcceptsReturn = True
        Me.txtXYplane.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtXYplane.Location = New System.Drawing.Point(396, 71)
        Me.txtXYplane.MaxLength = 4
        Me.txtXYplane.Name = "txtXYplane"
        Me.txtXYplane.Size = New System.Drawing.Size(75, 20)
        Me.txtXYplane.TabIndex = 13
        Me.txtXYplane.Tag = "4Required"
        Me.txtXYplane.Text = "G17"
        '
        'txtCompCancel
        '
        Me.txtCompCancel.AcceptsReturn = True
        Me.txtCompCancel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCompCancel.Location = New System.Drawing.Point(225, 288)
        Me.txtCompCancel.MaxLength = 4
        Me.txtCompCancel.Name = "txtCompCancel"
        Me.txtCompCancel.Size = New System.Drawing.Size(49, 20)
        Me.txtCompCancel.TabIndex = 11
        Me.txtCompCancel.Tag = "4Required"
        Me.txtCompCancel.Text = "G40"
        '
        'txtCompRight
        '
        Me.txtCompRight.AcceptsReturn = True
        Me.txtCompRight.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCompRight.Location = New System.Drawing.Point(225, 256)
        Me.txtCompRight.MaxLength = 4
        Me.txtCompRight.Name = "txtCompRight"
        Me.txtCompRight.Size = New System.Drawing.Size(49, 20)
        Me.txtCompRight.TabIndex = 11
        Me.txtCompRight.Tag = "4Required"
        Me.txtCompRight.Text = "G42"
        '
        'txtCompLeft
        '
        Me.txtCompLeft.AcceptsReturn = True
        Me.txtCompLeft.Location = New System.Drawing.Point(225, 224)
        Me.txtCompLeft.MaxLength = 4
        Me.txtCompLeft.Name = "txtCompLeft"
        Me.txtCompLeft.Size = New System.Drawing.Size(49, 20)
        Me.txtCompLeft.TabIndex = 11
        Me.txtCompLeft.Tag = "4Required"
        Me.txtCompLeft.Text = "G41"
        '
        'txtAbs
        '
        Me.txtAbs.AcceptsReturn = True
        Me.txtAbs.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAbs.Location = New System.Drawing.Point(225, 192)
        Me.txtAbs.MaxLength = 4
        Me.txtAbs.Name = "txtAbs"
        Me.txtAbs.Size = New System.Drawing.Size(49, 20)
        Me.txtAbs.TabIndex = 11
        Me.txtAbs.Tag = "4Required"
        Me.txtAbs.Text = "G90"
        '
        'txtInc
        '
        Me.txtInc.AcceptsReturn = True
        Me.txtInc.Location = New System.Drawing.Point(225, 160)
        Me.txtInc.MaxLength = 4
        Me.txtInc.Name = "txtInc"
        Me.txtInc.Size = New System.Drawing.Size(49, 20)
        Me.txtInc.TabIndex = 9
        Me.txtInc.Tag = "4Required"
        Me.txtInc.Text = "G91"
        '
        'txtRapid
        '
        Me.txtRapid.AcceptsReturn = True
        Me.txtRapid.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRapid.Location = New System.Drawing.Point(225, 32)
        Me.txtRapid.MaxLength = 4
        Me.txtRapid.Name = "txtRapid"
        Me.txtRapid.Size = New System.Drawing.Size(49, 20)
        Me.txtRapid.TabIndex = 1
        Me.txtRapid.Tag = "4Required"
        Me.txtRapid.Text = "G00"
        '
        'txtCWarc
        '
        Me.txtCWarc.AcceptsReturn = True
        Me.txtCWarc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCWarc.Location = New System.Drawing.Point(225, 128)
        Me.txtCWarc.MaxLength = 4
        Me.txtCWarc.Name = "txtCWarc"
        Me.txtCWarc.Size = New System.Drawing.Size(49, 20)
        Me.txtCWarc.TabIndex = 7
        Me.txtCWarc.Tag = "4Required"
        Me.txtCWarc.Text = "G02"
        '
        'txtCCarc
        '
        Me.txtCCarc.AcceptsReturn = True
        Me.txtCCarc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCCarc.Location = New System.Drawing.Point(225, 96)
        Me.txtCCarc.MaxLength = 4
        Me.txtCCarc.Name = "txtCCarc"
        Me.txtCCarc.Size = New System.Drawing.Size(49, 20)
        Me.txtCCarc.TabIndex = 5
        Me.txtCCarc.Tag = "4Required"
        Me.txtCCarc.Text = "G03"
        '
        'txtLinear
        '
        Me.txtLinear.AcceptsReturn = True
        Me.txtLinear.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLinear.Location = New System.Drawing.Point(225, 64)
        Me.txtLinear.MaxLength = 4
        Me.txtLinear.Name = "txtLinear"
        Me.txtLinear.Size = New System.Drawing.Size(49, 20)
        Me.txtLinear.TabIndex = 3
        Me.txtLinear.Tag = "4Required"
        Me.txtLinear.Text = "G01"
        '
        'tabDrilling
        '
        Me.tabDrilling.Controls.Add(Me.Label3)
        Me.tabDrilling.Controls.Add(Me.Label6)
        Me.tabDrilling.Controls.Add(Me.Label23)
        Me.tabDrilling.Controls.Add(Me.Label24)
        Me.tabDrilling.Controls.Add(Me.Label25)
        Me.tabDrilling.Controls.Add(Me.txtDrills_0)
        Me.tabDrilling.Controls.Add(Me.txtDrills_1)
        Me.tabDrilling.Controls.Add(Me.txtDrills_2)
        Me.tabDrilling.Controls.Add(Me.txtDrills_3)
        Me.tabDrilling.Controls.Add(Me.txtDrills_4)
        Me.tabDrilling.Controls.Add(Me.txtDrills_5)
        Me.tabDrilling.Controls.Add(Me.txtDrills_6)
        Me.tabDrilling.Controls.Add(Me.txtDrills_7)
        Me.tabDrilling.Controls.Add(Me.txtDrills_8)
        Me.tabDrilling.Controls.Add(Me.txtDrills_9)
        Me.tabDrilling.Controls.Add(Me.txtDrills_10)
        Me.tabDrilling.Controls.Add(Me.txtDrillReturnInitialPln)
        Me.tabDrilling.Controls.Add(Me.txtDrillReturnRapidPln)
        Me.tabDrilling.Controls.Add(Me.txtDrillRapid)
        Me.tabDrilling.Location = New System.Drawing.Point(4, 24)
        Me.tabDrilling.Name = "tabDrilling"
        Me.tabDrilling.Size = New System.Drawing.Size(817, 475)
        Me.tabDrilling.TabIndex = 4
        Me.tabDrilling.Text = "Drilling Cycles"
        Me.tabDrilling.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(233, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(150, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Drill cycle cancel code:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(54, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(89, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Drill cycle codes:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(233, 112)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(150, 20)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "Return to inital plane code:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(233, 152)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(150, 20)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "Return to rapid plane code:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(233, 192)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(150, 20)
        Me.Label25.TabIndex = 17
        Me.Label25.Text = "Rapid plane address character:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDrills_0
        '
        Me.txtDrills_0.AcceptsReturn = True
        Me.txtDrills_0.Location = New System.Drawing.Point(392, 72)
        Me.txtDrills_0.MaxLength = 4
        Me.txtDrills_0.Name = "txtDrills_0"
        Me.txtDrills_0.Size = New System.Drawing.Size(49, 20)
        Me.txtDrills_0.TabIndex = 10
        Me.txtDrills_0.Tag = "5Required"
        Me.txtDrills_0.Text = "G80"
        '
        'txtDrills_1
        '
        Me.txtDrills_1.AcceptsReturn = True
        Me.txtDrills_1.Location = New System.Drawing.Point(32, 72)
        Me.txtDrills_1.MaxLength = 4
        Me.txtDrills_1.Name = "txtDrills_1"
        Me.txtDrills_1.Size = New System.Drawing.Size(49, 20)
        Me.txtDrills_1.TabIndex = 0
        Me.txtDrills_1.Text = "G81"
        '
        'txtDrills_2
        '
        Me.txtDrills_2.AcceptsReturn = True
        Me.txtDrills_2.Location = New System.Drawing.Point(32, 104)
        Me.txtDrills_2.MaxLength = 4
        Me.txtDrills_2.Name = "txtDrills_2"
        Me.txtDrills_2.Size = New System.Drawing.Size(49, 20)
        Me.txtDrills_2.TabIndex = 2
        Me.txtDrills_2.Text = "G82"
        '
        'txtDrills_3
        '
        Me.txtDrills_3.AcceptsReturn = True
        Me.txtDrills_3.Location = New System.Drawing.Point(32, 136)
        Me.txtDrills_3.MaxLength = 4
        Me.txtDrills_3.Name = "txtDrills_3"
        Me.txtDrills_3.Size = New System.Drawing.Size(49, 20)
        Me.txtDrills_3.TabIndex = 4
        Me.txtDrills_3.Text = "G83"
        '
        'txtDrills_4
        '
        Me.txtDrills_4.AcceptsReturn = True
        Me.txtDrills_4.Location = New System.Drawing.Point(32, 168)
        Me.txtDrills_4.MaxLength = 4
        Me.txtDrills_4.Name = "txtDrills_4"
        Me.txtDrills_4.Size = New System.Drawing.Size(49, 20)
        Me.txtDrills_4.TabIndex = 6
        Me.txtDrills_4.Text = "G84"
        '
        'txtDrills_5
        '
        Me.txtDrills_5.AcceptsReturn = True
        Me.txtDrills_5.Location = New System.Drawing.Point(32, 200)
        Me.txtDrills_5.MaxLength = 4
        Me.txtDrills_5.Name = "txtDrills_5"
        Me.txtDrills_5.Size = New System.Drawing.Size(49, 20)
        Me.txtDrills_5.TabIndex = 8
        Me.txtDrills_5.Text = "G85"
        '
        'txtDrills_6
        '
        Me.txtDrills_6.AcceptsReturn = True
        Me.txtDrills_6.Location = New System.Drawing.Point(120, 72)
        Me.txtDrills_6.MaxLength = 4
        Me.txtDrills_6.Name = "txtDrills_6"
        Me.txtDrills_6.Size = New System.Drawing.Size(49, 20)
        Me.txtDrills_6.TabIndex = 1
        Me.txtDrills_6.Text = "G86"
        '
        'txtDrills_7
        '
        Me.txtDrills_7.AcceptsReturn = True
        Me.txtDrills_7.Location = New System.Drawing.Point(120, 104)
        Me.txtDrills_7.MaxLength = 4
        Me.txtDrills_7.Name = "txtDrills_7"
        Me.txtDrills_7.Size = New System.Drawing.Size(49, 20)
        Me.txtDrills_7.TabIndex = 3
        Me.txtDrills_7.Text = "G87"
        '
        'txtDrills_8
        '
        Me.txtDrills_8.AcceptsReturn = True
        Me.txtDrills_8.Location = New System.Drawing.Point(120, 136)
        Me.txtDrills_8.MaxLength = 4
        Me.txtDrills_8.Name = "txtDrills_8"
        Me.txtDrills_8.Size = New System.Drawing.Size(49, 20)
        Me.txtDrills_8.TabIndex = 5
        Me.txtDrills_8.Text = "G88"
        '
        'txtDrills_9
        '
        Me.txtDrills_9.AcceptsReturn = True
        Me.txtDrills_9.Location = New System.Drawing.Point(120, 168)
        Me.txtDrills_9.MaxLength = 4
        Me.txtDrills_9.Name = "txtDrills_9"
        Me.txtDrills_9.Size = New System.Drawing.Size(49, 20)
        Me.txtDrills_9.TabIndex = 7
        '
        'txtDrills_10
        '
        Me.txtDrills_10.AcceptsReturn = True
        Me.txtDrills_10.Location = New System.Drawing.Point(120, 200)
        Me.txtDrills_10.MaxLength = 4
        Me.txtDrills_10.Name = "txtDrills_10"
        Me.txtDrills_10.Size = New System.Drawing.Size(49, 20)
        Me.txtDrills_10.TabIndex = 9
        '
        'txtDrillReturnInitialPln
        '
        Me.txtDrillReturnInitialPln.AcceptsReturn = True
        Me.txtDrillReturnInitialPln.Location = New System.Drawing.Point(392, 112)
        Me.txtDrillReturnInitialPln.MaxLength = 4
        Me.txtDrillReturnInitialPln.Name = "txtDrillReturnInitialPln"
        Me.txtDrillReturnInitialPln.Size = New System.Drawing.Size(49, 20)
        Me.txtDrillReturnInitialPln.TabIndex = 11
        Me.txtDrillReturnInitialPln.Tag = "5Required"
        Me.txtDrillReturnInitialPln.Text = "G98"
        '
        'txtDrillReturnRapidPln
        '
        Me.txtDrillReturnRapidPln.AcceptsReturn = True
        Me.txtDrillReturnRapidPln.Location = New System.Drawing.Point(392, 152)
        Me.txtDrillReturnRapidPln.MaxLength = 4
        Me.txtDrillReturnRapidPln.Name = "txtDrillReturnRapidPln"
        Me.txtDrillReturnRapidPln.Size = New System.Drawing.Size(49, 20)
        Me.txtDrillReturnRapidPln.TabIndex = 12
        Me.txtDrillReturnRapidPln.Tag = "5Required"
        Me.txtDrillReturnRapidPln.Text = "G99"
        '
        'txtDrillRapid
        '
        Me.txtDrillRapid.AcceptsReturn = True
        Me.txtDrillRapid.Location = New System.Drawing.Point(392, 192)
        Me.txtDrillRapid.MaxLength = 1
        Me.txtDrillRapid.Name = "txtDrillRapid"
        Me.txtDrillRapid.Size = New System.Drawing.Size(25, 20)
        Me.txtDrillRapid.TabIndex = 13
        Me.txtDrillRapid.Tag = "5Required"
        Me.txtDrillRapid.Text = "R"
        '
        'tabView
        '
        Me.tabView.Controls.Add(Me.GroupBox3)
        Me.tabView.Controls.Add(Me.chkReverseMouseWheel)
        Me.tabView.Controls.Add(Me.GroupBox2)
        Me.tabView.Controls.Add(Me.GroupBox1)
        Me.tabView.Controls.Add(Me.MG_Viewer1)
        Me.tabView.Controls.Add(Me.Picture1)
        Me.tabView.Controls.Add(Me.btnTopView)
        Me.tabView.Controls.Add(Me.btnFrontView)
        Me.tabView.Controls.Add(Me.btnSideView)
        Me.tabView.Controls.Add(Me.btnIsoView)
        Me.tabView.Controls.Add(Me.btnLatheView)
        Me.tabView.Location = New System.Drawing.Point(4, 24)
        Me.tabView.Name = "tabView"
        Me.tabView.Size = New System.Drawing.Size(817, 475)
        Me.tabView.TabIndex = 5
        Me.tabView.Text = "View"
        Me.tabView.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboCCWarcColor)
        Me.GroupBox3.Controls.Add(Me.cboCWarcColor)
        Me.GroupBox3.Controls.Add(Me.cboLineColor)
        Me.GroupBox3.Controls.Add(Me.cboRapidColor)
        Me.GroupBox3.Controls.Add(Me.Label62)
        Me.GroupBox3.Controls.Add(Me.Label61)
        Me.GroupBox3.Controls.Add(Me.Label60)
        Me.GroupBox3.Controls.Add(Me.Label59)
        Me.GroupBox3.Location = New System.Drawing.Point(560, 209)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(239, 231)
        Me.GroupBox3.TabIndex = 76
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Global Motion Colors"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(26, 171)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(78, 14)
        Me.Label62.TabIndex = 0
        Me.Label62.Text = "CCW Arc color"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(26, 119)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(71, 14)
        Me.Label61.TabIndex = 0
        Me.Label61.Text = "CW Arc color"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(26, 68)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(64, 14)
        Me.Label60.TabIndex = 0
        Me.Label60.Text = "Linear color"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(26, 19)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(61, 14)
        Me.Label59.TabIndex = 0
        Me.Label59.Text = "Rapid color"
        '
        'chkReverseMouseWheel
        '
        Me.chkReverseMouseWheel.AutoSize = True
        Me.chkReverseMouseWheel.Location = New System.Drawing.Point(521, 32)
        Me.chkReverseMouseWheel.Name = "chkReverseMouseWheel"
        Me.chkReverseMouseWheel.Size = New System.Drawing.Size(135, 18)
        Me.chkReverseMouseWheel.TabIndex = 75
        Me.chkReverseMouseWheel.Text = "Reverse mouse wheel"
        Me.chkReverseMouseWheel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkShowExtraOverlayInfo)
        Me.GroupBox2.Controls.Add(Me.lblFontSize)
        Me.GroupBox2.Controls.Add(Me.cboSize)
        Me.GroupBox2.Controls.Add(Me.lblFont)
        Me.GroupBox2.Controls.Add(Me.cboFont)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 343)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(520, 97)
        Me.GroupBox2.TabIndex = 74
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Viewer Text"
        '
        'chkShowExtraOverlayInfo
        '
        Me.chkShowExtraOverlayInfo.AutoSize = True
        Me.chkShowExtraOverlayInfo.Location = New System.Drawing.Point(24, 72)
        Me.chkShowExtraOverlayInfo.Name = "chkShowExtraOverlayInfo"
        Me.chkShowExtraOverlayInfo.Size = New System.Drawing.Size(241, 18)
        Me.chkShowExtraOverlayInfo.TabIndex = 63
        Me.chkShowExtraOverlayInfo.Text = "Show e&xtra overlay information for elements"
        Me.chkShowExtraOverlayInfo.UseVisualStyleBackColor = True
        '
        'lblFontSize
        '
        Me.lblFontSize.Location = New System.Drawing.Point(318, 14)
        Me.lblFontSize.Name = "lblFontSize"
        Me.lblFontSize.Size = New System.Drawing.Size(50, 20)
        Me.lblFontSize.TabIndex = 62
        Me.lblFontSize.Text = "&Size"
        Me.lblFontSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSize
        '
        Me.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSize.FormattingEnabled = True
        Me.cboSize.Items.AddRange(New Object() {"6", "7", "8", "9", "10", "12", "13", "14", "15", "16"})
        Me.cboSize.Location = New System.Drawing.Point(322, 37)
        Me.cboSize.Name = "cboSize"
        Me.cboSize.Size = New System.Drawing.Size(52, 22)
        Me.cboSize.TabIndex = 60
        '
        'lblFont
        '
        Me.lblFont.Location = New System.Drawing.Point(24, 14)
        Me.lblFont.Name = "lblFont"
        Me.lblFont.Size = New System.Drawing.Size(50, 20)
        Me.lblFont.TabIndex = 61
        Me.lblFont.Text = "&Font"
        Me.lblFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFont
        '
        Me.cboFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFont.FormattingEnabled = True
        Me.cboFont.Location = New System.Drawing.Point(23, 37)
        Me.cboFont.Name = "cboFont"
        Me.cboFont.Size = New System.Drawing.Size(147, 22)
        Me.cboFont.TabIndex = 59
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblColorSample)
        Me.GroupBox1.Controls.Add(Me.cboColor)
        Me.GroupBox1.Controls.Add(Me.pbColorPicker2)
        Me.GroupBox1.Controls.Add(Me.pbToolColors)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 208)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(520, 112)
        Me.GroupBox1.TabIndex = 73
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Global Tool Colors"
        '
        'lblColorSample
        '
        Me.lblColorSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblColorSample.Location = New System.Drawing.Point(448, 16)
        Me.lblColorSample.Name = "lblColorSample"
        Me.lblColorSample.Size = New System.Drawing.Size(56, 40)
        Me.lblColorSample.TabIndex = 76
        '
        'pbColorPicker2
        '
        Me.pbColorPicker2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbColorPicker2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbColorPicker2.ErrorImage = Nothing
        Me.pbColorPicker2.Image = Global.MacGen.My.Resources.Resources.ColorPicker
        Me.pbColorPicker2.Location = New System.Drawing.Point(344, 16)
        Me.pbColorPicker2.Name = "pbColorPicker2"
        Me.pbColorPicker2.Size = New System.Drawing.Size(97, 45)
        Me.pbColorPicker2.TabIndex = 74
        Me.pbColorPicker2.TabStop = False
        '
        'pbToolColors
        '
        Me.pbToolColors.Location = New System.Drawing.Point(24, 20)
        Me.pbToolColors.Name = "pbToolColors"
        Me.pbToolColors.Size = New System.Drawing.Size(257, 65)
        Me.pbToolColors.TabIndex = 75
        Me.pbToolColors.TabStop = False
        '
        'Picture1
        '
        Me.Picture1.Controls.Add(Me.VScroll1)
        Me.Picture1.Controls.Add(Me.optZ)
        Me.Picture1.Controls.Add(Me.optY)
        Me.Picture1.Controls.Add(Me.optX)
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Picture1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Picture1.Location = New System.Drawing.Point(304, 32)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(211, 160)
        Me.Picture1.TabIndex = 6
        Me.Picture1.TabStop = True
        '
        'VScroll1
        '
        Me.VScroll1.Cursor = System.Windows.Forms.Cursors.Default
        Me.VScroll1.LargeChange = 45
        Me.VScroll1.Location = New System.Drawing.Point(8, 0)
        Me.VScroll1.Maximum = 404
        Me.VScroll1.Name = "VScroll1"
        Me.VScroll1.Size = New System.Drawing.Size(17, 160)
        Me.VScroll1.TabIndex = 52
        Me.VScroll1.TabStop = True
        '
        'optZ
        '
        Me.optZ.Cursor = System.Windows.Forms.Cursors.Default
        Me.optZ.Location = New System.Drawing.Point(40, 128)
        Me.optZ.Name = "optZ"
        Me.optZ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optZ.Size = New System.Drawing.Size(150, 17)
        Me.optZ.TabIndex = 2
        Me.optZ.TabStop = True
        Me.optZ.Text = "Z"
        '
        'optY
        '
        Me.optY.Cursor = System.Windows.Forms.Cursors.Default
        Me.optY.Location = New System.Drawing.Point(40, 72)
        Me.optY.Name = "optY"
        Me.optY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optY.Size = New System.Drawing.Size(150, 17)
        Me.optY.TabIndex = 1
        Me.optY.TabStop = True
        Me.optY.Text = "Y"
        '
        'optX
        '
        Me.optX.Checked = True
        Me.optX.Cursor = System.Windows.Forms.Cursors.Default
        Me.optX.Location = New System.Drawing.Point(40, 16)
        Me.optX.Name = "optX"
        Me.optX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optX.Size = New System.Drawing.Size(150, 17)
        Me.optX.TabIndex = 0
        Me.optX.TabStop = True
        Me.optX.Text = "X"
        '
        'btnTopView
        '
        Me.btnTopView.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnTopView.Location = New System.Drawing.Point(16, 32)
        Me.btnTopView.Name = "btnTopView"
        Me.btnTopView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnTopView.Size = New System.Drawing.Size(97, 25)
        Me.btnTopView.TabIndex = 0
        Me.btnTopView.Tag = "1"
        Me.btnTopView.Text = "To&p View"
        '
        'btnFrontView
        '
        Me.btnFrontView.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnFrontView.Location = New System.Drawing.Point(16, 63)
        Me.btnFrontView.Name = "btnFrontView"
        Me.btnFrontView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnFrontView.Size = New System.Drawing.Size(97, 25)
        Me.btnFrontView.TabIndex = 1
        Me.btnFrontView.Tag = "2"
        Me.btnFrontView.Text = "&Front View"
        '
        'btnSideView
        '
        Me.btnSideView.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSideView.Location = New System.Drawing.Point(16, 94)
        Me.btnSideView.Name = "btnSideView"
        Me.btnSideView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSideView.Size = New System.Drawing.Size(97, 25)
        Me.btnSideView.TabIndex = 2
        Me.btnSideView.Tag = "3"
        Me.btnSideView.Text = "Si&de View"
        '
        'btnIsoView
        '
        Me.btnIsoView.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnIsoView.Location = New System.Drawing.Point(16, 126)
        Me.btnIsoView.Name = "btnIsoView"
        Me.btnIsoView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIsoView.Size = New System.Drawing.Size(97, 25)
        Me.btnIsoView.TabIndex = 3
        Me.btnIsoView.Tag = "4"
        Me.btnIsoView.Text = "Is&ometric View"
        '
        'btnLatheView
        '
        Me.btnLatheView.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnLatheView.Location = New System.Drawing.Point(16, 157)
        Me.btnLatheView.Name = "btnLatheView"
        Me.btnLatheView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnLatheView.Size = New System.Drawing.Size(97, 25)
        Me.btnLatheView.TabIndex = 4
        Me.btnLatheView.Tag = "5"
        Me.btnLatheView.Text = "&Lathe View"
        '
        'tabRotary
        '
        Me.tabRotary.Controls.Add(Me.Frame1)
        Me.tabRotary.Controls.Add(Me.Frame2)
        Me.tabRotary.Controls.Add(Me.Frame3)
        Me.tabRotary.Location = New System.Drawing.Point(4, 24)
        Me.tabRotary.Name = "tabRotary"
        Me.tabRotary.Size = New System.Drawing.Size(817, 475)
        Me.tabRotary.TabIndex = 6
        Me.tabRotary.Text = "Rotary"
        Me.tabRotary.UseVisualStyleBackColor = True
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.chkReverseRot)
        Me.Frame1.Controls.Add(Me.optRotateType1)
        Me.Frame1.Controls.Add(Me.optRotateType2)
        Me.Frame1.Location = New System.Drawing.Point(8, 109)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(529, 73)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Direction"
        '
        'chkReverseRot
        '
        Me.chkReverseRot.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkReverseRot.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReverseRot.Location = New System.Drawing.Point(384, 31)
        Me.chkReverseRot.Name = "chkReverseRot"
        Me.chkReverseRot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkReverseRot.Size = New System.Drawing.Size(113, 17)
        Me.chkReverseRot.TabIndex = 2
        Me.chkReverseRot.Text = "Reverse direction."
        '
        'optRotateType1
        '
        Me.optRotateType1.Checked = True
        Me.optRotateType1.Cursor = System.Windows.Forms.Cursors.Default
        Me.optRotateType1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRotateType1.Location = New System.Drawing.Point(40, 16)
        Me.optRotateType1.Name = "optRotateType1"
        Me.optRotateType1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optRotateType1.Size = New System.Drawing.Size(265, 25)
        Me.optRotateType1.TabIndex = 0
        Me.optRotateType1.TabStop = True
        Me.optRotateType1.Text = "0 To 360 deg.    Sign determining direction"
        '
        'optRotateType2
        '
        Me.optRotateType2.Cursor = System.Windows.Forms.Cursors.Default
        Me.optRotateType2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRotateType2.Location = New System.Drawing.Point(40, 47)
        Me.optRotateType2.Name = "optRotateType2"
        Me.optRotateType2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optRotateType2.Size = New System.Drawing.Size(257, 20)
        Me.optRotateType2.TabIndex = 1
        Me.optRotateType2.Text = "Polar Angle.  Direction determined by values. "
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.txtViewShift_0)
        Me.Frame2.Controls.Add(Me.txtViewShift_1)
        Me.Frame2.Controls.Add(Me.txtViewShift_2)
        Me.Frame2.Controls.Add(Me.Label29)
        Me.Frame2.Controls.Add(Me.Label31)
        Me.Frame2.Controls.Add(Me.Label32)
        Me.Frame2.Location = New System.Drawing.Point(8, 188)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(529, 85)
        Me.Frame2.TabIndex = 2
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "View Shift"
        '
        'txtViewShift_0
        '
        Me.txtViewShift_0.AcceptsReturn = True
        Me.txtViewShift_0.BackColor = System.Drawing.SystemColors.Window
        Me.txtViewShift_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtViewShift_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtViewShift_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViewShift_0.Location = New System.Drawing.Point(114, 34)
        Me.txtViewShift_0.MaxLength = 7
        Me.txtViewShift_0.Name = "txtViewShift_0"
        Me.txtViewShift_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtViewShift_0.Size = New System.Drawing.Size(49, 20)
        Me.txtViewShift_0.TabIndex = 2
        Me.txtViewShift_0.Text = "0.0"
        Me.txtViewShift_0.WordWrap = False
        '
        'txtViewShift_1
        '
        Me.txtViewShift_1.AcceptsReturn = True
        Me.txtViewShift_1.BackColor = System.Drawing.SystemColors.Window
        Me.txtViewShift_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtViewShift_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtViewShift_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViewShift_1.Location = New System.Drawing.Point(224, 34)
        Me.txtViewShift_1.MaxLength = 7
        Me.txtViewShift_1.Name = "txtViewShift_1"
        Me.txtViewShift_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtViewShift_1.Size = New System.Drawing.Size(49, 20)
        Me.txtViewShift_1.TabIndex = 4
        Me.txtViewShift_1.Text = "0.0"
        '
        'txtViewShift_2
        '
        Me.txtViewShift_2.AcceptsReturn = True
        Me.txtViewShift_2.BackColor = System.Drawing.SystemColors.Window
        Me.txtViewShift_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtViewShift_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtViewShift_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtViewShift_2.Location = New System.Drawing.Point(343, 34)
        Me.txtViewShift_2.MaxLength = 7
        Me.txtViewShift_2.Name = "txtViewShift_2"
        Me.txtViewShift_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtViewShift_2.Size = New System.Drawing.Size(49, 20)
        Me.txtViewShift_2.TabIndex = 6
        Me.txtViewShift_2.Text = "0.0"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(85, 34)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(20, 20)
        Me.Label29.TabIndex = 1
        Me.Label29.Text = "X"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(195, 34)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(20, 20)
        Me.Label31.TabIndex = 3
        Me.Label31.Text = "Y"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(314, 34)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(20, 20)
        Me.Label32.TabIndex = 5
        Me.Label32.Text = "Z"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Frame3
        '
        Me.Frame3.Controls.Add(Me.cboRotPrecision)
        Me.Frame3.Controls.Add(Me.cboRotAxis)
        Me.Frame3.Controls.Add(Me.txtRotAxis)
        Me.Frame3.Controls.Add(Me.Label33)
        Me.Frame3.Controls.Add(Me.Label27)
        Me.Frame3.Controls.Add(Me.Label26)
        Me.Frame3.Location = New System.Drawing.Point(8, 14)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(529, 89)
        Me.Frame3.TabIndex = 0
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Settings"
        '
        'cboRotPrecision
        '
        Me.cboRotPrecision.BackColor = System.Drawing.SystemColors.Window
        Me.cboRotPrecision.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboRotPrecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRotPrecision.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRotPrecision.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboRotPrecision.Items.AddRange(New Object() {"1.0", "0.1", "0.01", "0.001", "0.0001", "0.00001", "0.000001"})
        Me.cboRotPrecision.Location = New System.Drawing.Point(384, 47)
        Me.cboRotPrecision.Name = "cboRotPrecision"
        Me.cboRotPrecision.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboRotPrecision.Size = New System.Drawing.Size(65, 22)
        Me.cboRotPrecision.TabIndex = 5
        '
        'cboRotAxis
        '
        Me.cboRotAxis.BackColor = System.Drawing.SystemColors.Window
        Me.cboRotAxis.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboRotAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRotAxis.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRotAxis.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboRotAxis.Items.AddRange(New Object() {"Z", "Y", "X"})
        Me.cboRotAxis.Location = New System.Drawing.Point(384, 16)
        Me.cboRotAxis.Name = "cboRotAxis"
        Me.cboRotAxis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboRotAxis.Size = New System.Drawing.Size(65, 22)
        Me.cboRotAxis.TabIndex = 3
        '
        'txtRotAxis
        '
        Me.txtRotAxis.AcceptsReturn = True
        Me.txtRotAxis.BackColor = System.Drawing.SystemColors.Window
        Me.txtRotAxis.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRotAxis.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRotAxis.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRotAxis.Location = New System.Drawing.Point(176, 20)
        Me.txtRotAxis.MaxLength = 1
        Me.txtRotAxis.Name = "txtRotAxis"
        Me.txtRotAxis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRotAxis.Size = New System.Drawing.Size(25, 20)
        Me.txtRotAxis.TabIndex = 1
        Me.txtRotAxis.Tag = "7Required"
        Me.txtRotAxis.Text = "B"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(275, 47)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(100, 20)
        Me.Label33.TabIndex = 4
        Me.Label33.Text = "Rotary precision:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(275, 20)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(100, 20)
        Me.Label27.TabIndex = 2
        Me.Label27.Text = "The rotational axis:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(60, 20)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(110, 20)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Rotary address label:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabPrint
        '
        Me.tabPrint.Controls.Add(Me.txtPrintScale)
        Me.tabPrint.Controls.Add(Me.rdoPrintScaled)
        Me.tabPrint.Controls.Add(Me.rdoPrintActualSize)
        Me.tabPrint.Controls.Add(Me.rdoPrintAsShown)
        Me.tabPrint.Location = New System.Drawing.Point(4, 24)
        Me.tabPrint.Name = "tabPrint"
        Me.tabPrint.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPrint.Size = New System.Drawing.Size(817, 475)
        Me.tabPrint.TabIndex = 8
        Me.tabPrint.Text = "Print"
        Me.tabPrint.UseVisualStyleBackColor = True
        '
        'txtPrintScale
        '
        Me.txtPrintScale.Enabled = False
        Me.txtPrintScale.Location = New System.Drawing.Point(144, 114)
        Me.txtPrintScale.Name = "txtPrintScale"
        Me.txtPrintScale.Size = New System.Drawing.Size(44, 20)
        Me.txtPrintScale.TabIndex = 4
        Me.txtPrintScale.Text = "1.0"
        '
        'rdoPrintScaled
        '
        Me.rdoPrintScaled.AutoSize = True
        Me.rdoPrintScaled.Location = New System.Drawing.Point(40, 114)
        Me.rdoPrintScaled.Name = "rdoPrintScaled"
        Me.rdoPrintScaled.Size = New System.Drawing.Size(81, 18)
        Me.rdoPrintScaled.TabIndex = 3
        Me.rdoPrintScaled.Text = "Print scaled"
        Me.rdoPrintScaled.UseVisualStyleBackColor = True
        '
        'rdoPrintActualSize
        '
        Me.rdoPrintActualSize.AutoSize = True
        Me.rdoPrintActualSize.Location = New System.Drawing.Point(40, 75)
        Me.rdoPrintActualSize.Name = "rdoPrintActualSize"
        Me.rdoPrintActualSize.Size = New System.Drawing.Size(101, 18)
        Me.rdoPrintActualSize.TabIndex = 2
        Me.rdoPrintActualSize.Text = "Print actual size"
        Me.rdoPrintActualSize.UseVisualStyleBackColor = True
        '
        'rdoPrintAsShown
        '
        Me.rdoPrintAsShown.AutoSize = True
        Me.rdoPrintAsShown.Checked = True
        Me.rdoPrintAsShown.Location = New System.Drawing.Point(40, 36)
        Me.rdoPrintAsShown.Name = "rdoPrintAsShown"
        Me.rdoPrintAsShown.Size = New System.Drawing.Size(98, 18)
        Me.rdoPrintAsShown.TabIndex = 1
        Me.rdoPrintAsShown.TabStop = True
        Me.rdoPrintAsShown.Text = "Print as shown"
        Me.rdoPrintAsShown.UseVisualStyleBackColor = True
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status})
        Me.StatusBar.Location = New System.Drawing.Point(0, 528)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(825, 22)
        Me.StatusBar.SizingGrip = False
        Me.StatusBar.TabIndex = 1
        Me.StatusBar.Text = "StatusStrip1"
        '
        'Status
        '
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(39, 17)
        Me.Status.Text = "Status"
        '
        'tsSchemes
        '
        Me.tsSchemes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsSchemes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNewScheme, Me.tsbSaveFile, Me.tsbCopy, Me.tsbRename, Me.tsbDelete})
        Me.tsSchemes.Location = New System.Drawing.Point(0, 0)
        Me.tsSchemes.Name = "tsSchemes"
        Me.tsSchemes.Size = New System.Drawing.Size(825, 25)
        Me.tsSchemes.TabIndex = 2
        Me.tsSchemes.Text = "ToolStrip1"
        '
        'tsbNewScheme
        '
        Me.tsbNewScheme.Image = Global.MacGen.My.Resources.Resources.newscheme_16
        Me.tsbNewScheme.Name = "tsbNewScheme"
        Me.tsbNewScheme.Size = New System.Drawing.Size(51, 22)
        Me.tsbNewScheme.Text = "&New"
        '
        'tsbSaveFile
        '
        Me.tsbSaveFile.Image = Global.MacGen.My.Resources.Resources.savefile_16
        Me.tsbSaveFile.Name = "tsbSaveFile"
        Me.tsbSaveFile.Size = New System.Drawing.Size(51, 22)
        Me.tsbSaveFile.Text = "&Save"
        '
        'tsbCopy
        '
        Me.tsbCopy.Image = Global.MacGen.My.Resources.Resources.copy_16
        Me.tsbCopy.Name = "tsbCopy"
        Me.tsbCopy.Size = New System.Drawing.Size(55, 22)
        Me.tsbCopy.Text = "&Copy"
        '
        'tsbRename
        '
        Me.tsbRename.Image = Global.MacGen.My.Resources.Resources.rename_16
        Me.tsbRename.Name = "tsbRename"
        Me.tsbRename.Size = New System.Drawing.Size(70, 22)
        Me.tsbRename.Text = "&Rename"
        '
        'tsbDelete
        '
        Me.tsbDelete.Image = Global.MacGen.My.Resources.Resources.delete_16
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(60, 22)
        Me.tsbDelete.Text = "&Delete"
        '
        'cboCCWarcColor
        '
        Me.cboCCWarcColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboCCWarcColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCCWarcColor.FormattingEnabled = True
        Me.cboCCWarcColor.Items.AddRange(New Object() {System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen})
        Me.cboCCWarcColor.Location = New System.Drawing.Point(29, 187)
        Me.cboCCWarcColor.Name = "cboCCWarcColor"
        Me.cboCCWarcColor.SelectedColor = System.Drawing.Color.Teal
        Me.cboCCWarcColor.Size = New System.Drawing.Size(163, 21)
        Me.cboCCWarcColor.TabIndex = 74
        '
        'cboCWarcColor
        '
        Me.cboCWarcColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboCWarcColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCWarcColor.FormattingEnabled = True
        Me.cboCWarcColor.Items.AddRange(New Object() {System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen})
        Me.cboCWarcColor.Location = New System.Drawing.Point(29, 136)
        Me.cboCWarcColor.Name = "cboCWarcColor"
        Me.cboCWarcColor.SelectedColor = System.Drawing.Color.Green
        Me.cboCWarcColor.Size = New System.Drawing.Size(163, 21)
        Me.cboCWarcColor.TabIndex = 74
        '
        'cboLineColor
        '
        Me.cboLineColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboLineColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLineColor.FormattingEnabled = True
        Me.cboLineColor.Items.AddRange(New Object() {System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen})
        Me.cboLineColor.Location = New System.Drawing.Point(29, 85)
        Me.cboLineColor.Name = "cboLineColor"
        Me.cboLineColor.SelectedColor = System.Drawing.Color.DodgerBlue
        Me.cboLineColor.Size = New System.Drawing.Size(163, 21)
        Me.cboLineColor.TabIndex = 74
        '
        'cboRapidColor
        '
        Me.cboRapidColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboRapidColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRapidColor.FormattingEnabled = True
        Me.cboRapidColor.Items.AddRange(New Object() {System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen})
        Me.cboRapidColor.Location = New System.Drawing.Point(29, 34)
        Me.cboRapidColor.Name = "cboRapidColor"
        Me.cboRapidColor.SelectedColor = System.Drawing.Color.OrangeRed
        Me.cboRapidColor.Size = New System.Drawing.Size(163, 21)
        Me.cboRapidColor.TabIndex = 74
        '
        'cboColor
        '
        Me.cboColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColor.FormattingEnabled = True
        Me.cboColor.Items.AddRange(New Object() {System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen, System.Drawing.SystemColors.Highlight, System.Drawing.Color.Transparent, System.Drawing.Color.AliceBlue, System.Drawing.Color.AntiqueWhite, System.Drawing.Color.Aqua, System.Drawing.Color.Aquamarine, System.Drawing.Color.Azure, System.Drawing.Color.Beige, System.Drawing.Color.Bisque, System.Drawing.Color.Black, System.Drawing.Color.BlanchedAlmond, System.Drawing.Color.Blue, System.Drawing.Color.BlueViolet, System.Drawing.Color.Brown, System.Drawing.Color.BurlyWood, System.Drawing.Color.CadetBlue, System.Drawing.Color.Chartreuse, System.Drawing.Color.Chocolate, System.Drawing.Color.Coral, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Cornsilk, System.Drawing.Color.Crimson, System.Drawing.Color.Cyan, System.Drawing.Color.DarkBlue, System.Drawing.Color.DarkCyan, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkKhaki, System.Drawing.Color.DarkMagenta, System.Drawing.Color.DarkOliveGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkOrchid, System.Drawing.Color.DarkRed, System.Drawing.Color.DarkSalmon, System.Drawing.Color.DarkSeaGreen, System.Drawing.Color.DarkSlateBlue, System.Drawing.Color.DarkSlateGray, System.Drawing.Color.DarkTurquoise, System.Drawing.Color.DarkViolet, System.Drawing.Color.DeepPink, System.Drawing.Color.DeepSkyBlue, System.Drawing.Color.DimGray, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Firebrick, System.Drawing.Color.FloralWhite, System.Drawing.Color.ForestGreen, System.Drawing.Color.Fuchsia, System.Drawing.Color.Gainsboro, System.Drawing.Color.GhostWhite, System.Drawing.Color.Gold, System.Drawing.Color.Goldenrod, System.Drawing.Color.Gray, System.Drawing.Color.Green, System.Drawing.Color.GreenYellow, System.Drawing.Color.Honeydew, System.Drawing.Color.HotPink, System.Drawing.Color.IndianRed, System.Drawing.Color.Indigo, System.Drawing.Color.Ivory, System.Drawing.Color.Khaki, System.Drawing.Color.Lavender, System.Drawing.Color.LavenderBlush, System.Drawing.Color.LawnGreen, System.Drawing.Color.LemonChiffon, System.Drawing.Color.LightBlue, System.Drawing.Color.LightCoral, System.Drawing.Color.LightCyan, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.LightGray, System.Drawing.Color.LightGreen, System.Drawing.Color.LightPink, System.Drawing.Color.LightSalmon, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.LightSlateGray, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.LightYellow, System.Drawing.Color.Lime, System.Drawing.Color.LimeGreen, System.Drawing.Color.Linen, System.Drawing.Color.Magenta, System.Drawing.Color.Maroon, System.Drawing.Color.MediumAquamarine, System.Drawing.Color.MediumBlue, System.Drawing.Color.MediumOrchid, System.Drawing.Color.MediumPurple, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.MediumSlateBlue, System.Drawing.Color.MediumSpringGreen, System.Drawing.Color.MediumTurquoise, System.Drawing.Color.MediumVioletRed, System.Drawing.Color.MidnightBlue, System.Drawing.Color.MintCream, System.Drawing.Color.MistyRose, System.Drawing.Color.Moccasin, System.Drawing.Color.NavajoWhite, System.Drawing.Color.Navy, System.Drawing.Color.OldLace, System.Drawing.Color.Olive, System.Drawing.Color.OliveDrab, System.Drawing.Color.Orange, System.Drawing.Color.OrangeRed, System.Drawing.Color.Orchid, System.Drawing.Color.PaleGoldenrod, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleTurquoise, System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PapayaWhip, System.Drawing.Color.PeachPuff, System.Drawing.Color.Peru, System.Drawing.Color.Pink, System.Drawing.Color.Plum, System.Drawing.Color.PowderBlue, System.Drawing.Color.Purple, System.Drawing.Color.Red, System.Drawing.Color.RosyBrown, System.Drawing.Color.RoyalBlue, System.Drawing.Color.SaddleBrown, System.Drawing.Color.Salmon, System.Drawing.Color.SandyBrown, System.Drawing.Color.SeaGreen, System.Drawing.Color.SeaShell, System.Drawing.Color.Sienna, System.Drawing.Color.Silver, System.Drawing.Color.SkyBlue, System.Drawing.Color.SlateBlue, System.Drawing.Color.SlateGray, System.Drawing.Color.Snow, System.Drawing.Color.SpringGreen, System.Drawing.Color.SteelBlue, System.Drawing.Color.Tan, System.Drawing.Color.Teal, System.Drawing.Color.Thistle, System.Drawing.Color.Tomato, System.Drawing.Color.Turquoise, System.Drawing.Color.Violet, System.Drawing.Color.Wheat, System.Drawing.Color.White, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Yellow, System.Drawing.Color.YellowGreen})
        Me.cboColor.Location = New System.Drawing.Point(344, 64)
        Me.cboColor.Name = "cboColor"
        Me.cboColor.SelectedColor = System.Drawing.Color.Black
        Me.cboColor.Size = New System.Drawing.Size(163, 21)
        Me.cboColor.TabIndex = 73
        '
        'MG_Viewer1
        '
        Me.MG_Viewer1.AxisIndicatorScale = 0.75!
        Me.MG_Viewer1.BackColor = System.Drawing.Color.Black
        Me.MG_Viewer1.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.MG_Viewer1.DrawExtraOverlayInfo = True
        Me.MG_Viewer1.DrawOnPaint = True
        Me.MG_Viewer1.DynamicViewManipulation = True
        Me.MG_Viewer1.FilterLowerZ = Single.NaN
        Me.MG_Viewer1.FilterUpperZ = Single.NaN
        Me.MG_Viewer1.FilterZ = False
        Me.MG_Viewer1.FilterZCrossing = False
        Me.MG_Viewer1.FourthAxis = 0!
        Me.MG_Viewer1.Limits = New Single() {0!, 0!, 0!, 0!, 0!, 0!}
        Me.MG_Viewer1.LimitsColor = System.Drawing.Color.DarkGray
        Me.MG_Viewer1.Location = New System.Drawing.Point(128, 32)
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
        Me.MG_Viewer1.Size = New System.Drawing.Size(160, 160)
        Me.MG_Viewer1.TabIndex = 5
        Me.MG_Viewer1.TabletMode = False
        Me.MG_Viewer1.ViewManipMode = MacGen.MG_BasicViewer.ManipMode.ROTATE
        Me.MG_Viewer1.Yaw = 0!
        '
        'frmViewerSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(825, 550)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.tsSchemes)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(45, 40)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewerSetup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Tag = " "
        Me.Text = " "
        Me.Tab1.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.tabGeneral.PerformLayout()
        Me.tabMachineType.ResumeLayout(False)
        Me.tabMachineType.PerformLayout()
        Me.tabMachineSettings.ResumeLayout(False)
        Me.tabMachineSettings.PerformLayout()
        Me.tabSpeedFeed.ResumeLayout(False)
        Me.tabSpeedFeed.PerformLayout()
        Me.tabMotionCodes.ResumeLayout(False)
        Me.tabMotionCodes.PerformLayout()
        Me.tabDrilling.ResumeLayout(False)
        Me.tabDrilling.PerformLayout()
        Me.tabView.ResumeLayout(False)
        Me.tabView.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.pbColorPicker2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbToolColors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Picture1.ResumeLayout(False)
        Me.tabRotary.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        Me.tabPrint.ResumeLayout(False)
        Me.tabPrint.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.tsSchemes.ResumeLayout(False)
        Me.tsSchemes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MG_Viewer1 As MacGen.MG_BasicViewer
    Public WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tsSchemes As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSaveFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbNewScheme As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Public WithEvents Label37 As System.Windows.Forms.Label
    Public WithEvents Label36 As System.Windows.Forms.Label
    Public WithEvents txtCompRight As System.Windows.Forms.TextBox
    Public WithEvents txtCompLeft As System.Windows.Forms.TextBox
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents txtCompCancel As System.Windows.Forms.TextBox
    Friend WithEvents tsbCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRename As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pbToolColors As System.Windows.Forms.PictureBox
    Friend WithEvents pbColorPicker2 As System.Windows.Forms.PictureBox
    Friend WithEvents cboColor As ColorCombo
    Friend WithEvents lblColorSample As System.Windows.Forms.Label
    Public WithEvents chkUVW As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFontSize As System.Windows.Forms.Label
    Friend WithEvents cboSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblFont As System.Windows.Forms.Label
    Friend WithEvents cboFont As System.Windows.Forms.ComboBox
    Public WithEvents Label39 As System.Windows.Forms.Label
    Private WithEvents cboMachines As System.Windows.Forms.ComboBox
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents txtSearch As System.Windows.Forms.TextBox
    Private WithEvents txtGlobalReplacements As System.Windows.Forms.TextBox
    Friend WithEvents txtCommentChars As System.Windows.Forms.TextBox
    Friend WithEvents chkInvertArcCenterValues As System.Windows.Forms.CheckBox
    Private WithEvents chkAbsCenter As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowExtraOverlayInfo As System.Windows.Forms.CheckBox
    Friend WithEvents chkReverseMouseWheel As System.Windows.Forms.CheckBox
    Public WithEvents Label46 As System.Windows.Forms.Label
    Public WithEvents Label45 As System.Windows.Forms.Label
    Public WithEvents Label44 As System.Windows.Forms.Label
    Public WithEvents txtHomeZValue As System.Windows.Forms.TextBox
    Public WithEvents txtHomeYValue As System.Windows.Forms.TextBox
    Public WithEvents txtHomeXValue As System.Windows.Forms.TextBox
    Public WithEvents Label43 As System.Windows.Forms.Label
    Public WithEvents Label42 As System.Windows.Forms.Label
    Public WithEvents Label41 As System.Windows.Forms.Label
    Public WithEvents Label40 As System.Windows.Forms.Label
    Public WithEvents txtHomeZAddress As System.Windows.Forms.TextBox
    Public WithEvents txtHomeYAddress As System.Windows.Forms.TextBox
    Public WithEvents txtHomeXAddress As System.Windows.Forms.TextBox
    Public WithEvents txtReturnHome As System.Windows.Forms.TextBox
    Public WithEvents lblToolChange As System.Windows.Forms.Label
    Public WithEvents txtToolChange As System.Windows.Forms.TextBox
    Friend WithEvents tabSpeedFeed As System.Windows.Forms.TabPage
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents txtFeedModeMin As System.Windows.Forms.TextBox
    Public WithEvents Label28 As System.Windows.Forms.Label
    Public WithEvents txtFeedModeRev As System.Windows.Forms.TextBox
    Public WithEvents cboFeedPrecision As System.Windows.Forms.ComboBox
    Public WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtRapidRate As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtMaxRPMDefault As System.Windows.Forms.TextBox
    Public WithEvents Label48 As System.Windows.Forms.Label
    Public WithEvents txtMaxRpmCode As System.Windows.Forms.TextBox
    Friend WithEvents chkDogLeg As System.Windows.Forms.CheckBox
    Public WithEvents txtSpeedModeSFM As System.Windows.Forms.TextBox
    Public WithEvents txtSpeedModeRPM As System.Windows.Forms.TextBox
    Public WithEvents Label50 As System.Windows.Forms.Label
    Public WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents cboUnits As System.Windows.Forms.ComboBox
    Public WithEvents Label51 As System.Windows.Forms.Label
    Public WithEvents Label52 As System.Windows.Forms.Label
    Public WithEvents Label53 As System.Windows.Forms.Label
    Public WithEvents txtUnitsEnglish As System.Windows.Forms.TextBox
    Public WithEvents txtUnitsMetric As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Public WithEvents Label57 As System.Windows.Forms.Label
    Public WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents txtMaxY As System.Windows.Forms.TextBox
    Public WithEvents txtMaxX As System.Windows.Forms.TextBox
    Public WithEvents txtMinY As System.Windows.Forms.TextBox
    Public WithEvents txtMinX As System.Windows.Forms.TextBox
    Public WithEvents Label58 As System.Windows.Forms.Label
    Public WithEvents txtMaxZ As System.Windows.Forms.TextBox
    Public WithEvents txtMinZ As System.Windows.Forms.TextBox
    Friend WithEvents tabPrint As System.Windows.Forms.TabPage
    Friend WithEvents rdoPrintScaled As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPrintActualSize As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPrintAsShown As System.Windows.Forms.RadioButton
    Friend WithEvents txtPrintScale As System.Windows.Forms.TextBox
    Friend WithEvents chkIgnoreSpaces As System.Windows.Forms.CheckBox
    Friend WithEvents btnLimitsColor As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cboRapidColor As ColorCombo
    Friend WithEvents Label62 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents cboCCWarcColor As ColorCombo
    Friend WithEvents cboCWarcColor As ColorCombo
    Friend WithEvents cboLineColor As ColorCombo
#End Region
End Class