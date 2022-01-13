''' <remarks>
''' Jason Titcomb
''' www.CncEdit.com
''' https://github.com/JasonTitcomb/Basic_CNC_Viewer/blob/master/LICENSE.md
''' </remarks>

Option Strict Off
Option Explicit On
Imports System.Collections.Generic
Imports System.IO
Imports System.Text

Friend Class frmBasicViewer
    Inherits System.Windows.Forms.Form
    Private mMotionBlocks As New Generic.List(Of clsMotionRecord)
    Public AppPath As String 'Directory that program is installed in
    Public AppDataPath As String 'Directory that program is installed in
    Private showRapid As Boolean
    Private showPoints As Boolean
    Private cncFile As String
    Private WithEvents mLog As clsLogger = clsLogger.Instance
    Private WithEvents mParser As clsParser = clsParser.Instance
    Private WithEvents mSetup As clsSettings = clsSettings.Instance
    Private WithEvents MG_ViewerCurrent As MG_BasicViewer
    Private mFadeTimer As Timer
    Private mNcProgs As New System.Collections.Generic.List(Of clsProg)
    Private WithEvents mScheme As New clsColorScheme
    Private mArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
    Private mLastFolder As String
    Private Sub frmViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            MG_ViewerCurrent = Me.MG_Viewer1
            Me.WindowState = CType(My.Settings.WindowState, FormWindowState)

            If My.Settings.ToolColors Is Nothing Then
                My.Settings.ToolColors = New Specialized.StringCollection
                Dim cls() As String = {"-65536", "-16711936", "-256", "-16776961", "-12525360", "-65281", "-8388608", "-11179217", "-1468806", "-16777216", "-16728065", "-16744448", "-8355840", "-16777088", "-8388480", "-16744320", "-4144960", "-989556", "-16744448", "-8355840", "-16777088", "-8388480", "-16744320", "-40121", "-2031617", "-65536", "-16711936", "-256", "-16776961", "-12525360", "-65281", "-3730043"}
                My.Settings.ToolColors.AddRange(cls)
            End If

            MG_ViewerCurrent.MotionColor_Rapid = My.Settings.MotionColorRapid
            MG_ViewerCurrent.MotionColor_Line = My.Settings.MotionColorLinear
            MG_ViewerCurrent.MotionColor_ArcCCW = My.Settings.MotionColorCCWArc
            MG_ViewerCurrent.MotionColor_ArcCW = My.Settings.MotionColorCWArc


            If My.Application.IsNetworkDeployed Then
                AppPath = My.Application.Info.DirectoryPath
                AppDataPath = Deployment.Application.ApplicationDeployment.CurrentDeployment.DataDirectory
            Else
                AppPath = My.Application.Info.DirectoryPath
                AppDataPath = IO.Path.Combine(AppPath, "Data")
            End If

            If Not My.Computer.FileSystem.DirectoryExists(AppDataPath) Then
                My.Computer.FileSystem.CreateDirectory(AppDataPath)
            End If

            mSetup.LoadAllMachines(AppDataPath)

            If My.Settings.IgnoreFileWhitespace Then
                mParser.RegexNcWordsMatch = "[A-Z]\x20*([-+]?[0-9]*[\.,]?[0-9]*)"
            End If

            mParser.Init(mSetup.Machine)
            MG_ViewerCurrent.InitMyNeighbors()
            MG_ViewerCurrent.InitSiblingMotionBlocks(mMotionBlocks)
            Me.MG_ViewerCurrent.SelectionColor = My.Settings.ViewerSelectionColor

            tsbSelect.PerformClick()

            Dim ret As Integer = Me.tscboMachines.FindString(My.Settings.LastMachine)
            If ret >= 0 Then
                Me.tscboMachines.SelectedIndex = ret
            End If

            mScheme.DataFolder = IO.Path.Combine(AppDataPath, "Schemes")
            mScheme.Optimized = True
            LoadComboNames(mScheme.DataFolder, tsCboScheme, "*.xml")
            tsCboScheme.SelectedIndex = tsCboScheme.FindString("Default")
            tsbToggleEditor.Checked = My.Settings.EditorVisible
            SplitContainer1.SplitterDistance = My.Settings.EditorWidth
            tsbPlay.Checked = My.Settings.ShowPlayer
            tsbAutoZoom.Checked = My.Settings.AutoZoom
            NC_Player.Visible = tsbPlay.Checked
            NC_Player.Speed = My.Settings.PlayerSpeed
            NC_Player.OptionStop = My.Settings.PlayerOptionStop
            tsbTouch.Checked = My.Settings.TouchMode
            SetTouchModeDisplay(tsbTouch.Checked)
            RTB.ForceUpperCase = True
            RTB.ZoomFactor = My.Settings.EditorZoom

            '#If DEBUG Then
            '            My.Settings.Virgin = False
            '#End If

            'If My.Settings.Virgin = True Then
            If IO.File.Exists(AppDataPath & "\Samples\Mill.cnc") Then
                    OpenFile(AppDataPath & "\Samples\Mill.cnc")
                    SetDefaultViews()
                End If
            'End If

            Me.Location = My.Settings.ViewerLocation
            Me.Size = My.Settings.ViewFormSize
            Me.mnuRapidLines.Checked = My.Settings.RapidLines
            Me.mnuRapidPoints.Checked = My.Settings.RapidPoints
            Me.mnuAxisindicator.Checked = My.Settings.AxisIndicator
            Me.mnuAxisLines.Checked = My.Settings.AxisLines
            Me.mnuAxisLimits.Checked = My.Settings.ViewerShowLimits

            MG_ViewerCurrent.DrawExtraOverlayInfo = My.Settings.ViewerShowExtraOverlayDetails
            MG_ViewerCurrent.ReverseMouseWheel = My.Settings.ReverseMouseWheel
            MG_ViewerCurrent.Limits() = mSetup.Machine.Limits
            MG_ViewerCurrent.LimitsColor = My.Settings.ViewerLimitsColor

            DisplayCheckedChanged(Nothing, Nothing)
            tsbMotionColor.Checked = My.Settings.ColorByMotionType

            Select Case My.Settings.Viewports
                Case 1
                    mnuOneScreen.PerformClick()
                Case 2
                    mnuTwoScreens.PerformClick()
                Case 4
                    mnuFourScreens.PerformClick()
            End Select

            mArgs = My.Application.CommandLineArgs
            If mArgs.Count = 1 Then
                Dim commandFile As String = mArgs(0).Trim.Replace("""", "")
                If IO.File.Exists(commandFile) Then
                    OpenFile(commandFile)
                End If
            Else
                SetDefaultViews()
            End If

            SetViewersBgColor(My.Settings.ViewsBackColor)
            My.Settings.Virgin = False
            My.Settings.Version = My.Application.Info.Version.ToString
            SetTitleBar()

        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Private Sub SetTitleBar()
        Me.Text = "Basic 3-D Viewer - V" & My.Application.Info.Version.ToString
        If Not String.IsNullOrEmpty(RTB.FileName) Then
            Text &= "   " & LongDirFix(RTB.FileName)
        End If
    End Sub

    Private Sub SetTouchModeDisplay(touch As Boolean)
        ToolStripImageLoader.SetImageKeys(ToolStrip1, touch)
        ToolStripImageLoader.SetImageKeys(ToolStrip2, touch)
        NC_Player.TouchMode = touch
    End Sub

    Public Sub LoadScheme(ByVal schemeName As String)
        Try
            If schemeName.Length = 0 Then Return
            Me.mScheme.Load(schemeName)
            With RTB
                .Lock()
                .InvalidateAllPages()
                .BackColor = mScheme.ColorSettings.BackColor
                If mScheme.ColorSettings.TextRangeBoxColor.ToArgb = Color.FromKnownColor(KnownColor.Highlight).ToArgb Then
                    .TextRangeBoxColor = Color.FromArgb(Not .BackColor.R, Not .BackColor.G, Not .BackColor.B)
                Else
                    .TextRangeBoxColor = mScheme.ColorSettings.TextRangeBoxColor
                End If
                .Font = mScheme.StandardSettings(0).Font
                .ForeColor = mScheme.StandardSettings(0).Color
                .SelectionIndent = mScheme.ColorSettings.Indent
                If .TextLength = 0 Then
                    .RTF = mScheme.RtfHeader & " " & mScheme.RtfFooter
                    .SelectionStart = 0
                    .SelectionLength = 1
                    .SelectedText = ""
                End If
                .UnLock()
            End With
            ColorVisibleRangeText(True)
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub


    Private Sub frmViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Me.WindowState = FormWindowState.Normal Then
                My.Settings.ViewerLocation = Me.Location
                My.Settings.ViewFormSize = Me.Size
            End If
            My.Settings.LastMachine = Me.tscboMachines.SelectedItem.ToString
            My.Settings.RapidLines = Me.mnuRapidLines.Checked
            My.Settings.RapidPoints = Me.mnuRapidPoints.Checked
            My.Settings.AxisIndicator = Me.mnuAxisindicator.Checked
            My.Settings.AxisLines = Me.mnuAxisLines.Checked
            My.Settings.ViewerShowLimits = mnuAxisLimits.Checked
            My.Settings.TouchMode = tsbTouch.Checked
            My.Settings.EditorVisible = tsbToggleEditor.Checked
            My.Settings.EditorWidth = SplitContainer1.Panel1.Width
            My.Settings.EditorZoom = RTB.ZoomFactor
            My.Settings.WindowState = Me.WindowState
            My.Settings.ShowPlayer = tsbPlay.Checked
            My.Settings.PlayerSpeed = NC_Player.Speed
            My.Settings.PlayerOptionStop = NC_Player.OptionStop
            My.Settings.AutoZoom = tsbAutoZoom.Checked
            My.Settings.ColorByMotionType = tsbMotionColor.Checked
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub mnuOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbOpen.Click
        Try
            NC_Player.StopPlay()
            With Me.OpenFileDialog1
                .ShowDialog()
                Me.Refresh()
                If .FileName.Length > 0 Then
                    OpenFile(.FileName)
                    mLastFolder = Path.GetDirectoryName(.FileName)
                End If
            End With
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub OpenFile(ByVal fileName As String)
        cncFile = fileName
        mSetup.MatchMachineToFile(cncFile)
        Try
            Me.Cursor = Cursors.WaitCursor

            If SplitContainer1.Panel1Collapsed Then
                FileWatcher.Path = IO.Path.GetDirectoryName(cncFile)
                FileWatcher.Filter = IO.Path.GetFileName(cncFile)
            Else
                LoadFile(cncFile)
            End If
            ProcessText()
            MG_ViewerCurrent.SetAllRotatePointToCenter()

        Catch ex As Exception
            mLog.LogError(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
        InitAllViews()
    End Sub

    Private Sub LoadFile(ByVal sFileName As String, Optional ByVal reload As Boolean = False)
        Try
            Dim curZoom As Single = RTB.ZoomFactor
            With RTB
                If reload Then
                    .SaveScrollAndCursor()
                End If
                .Lock()
                If reload Then
                    .ClearUndo()
                End If

                .FileName = sFileName
                If sFileName.EndsWith(".RTF", StringComparison.OrdinalIgnoreCase) Then
                    .LoadFile(sFileName, RichTextBoxStreamType.RichText)
                    .AddPaddedRange(0, .TextLength)
                Else
                    'This is much slower but handles extended characters
                    SetRTF(My.Computer.FileSystem.ReadAllText(sFileName, Encoding.UTF8))
                    If Not reload Then
                        .SelectionStart = 0
                    End If
                    .InvalidateAllPages()
                End If
                If reload Then
                    .RestoreScrollAndCursor()
                End If
                .UnLock()
                .LineCountDirty = True
                tsbSaveFile.Enabled = False
                tsbRefresh.Enabled = True
            End With
            ColorVisibleRangeText(True)
            RTB.ZoomFactor = curZoom
            SetTitleBar()
        Catch ex As Exception
            mLog.LogError(ex)
            Throw
        End Try

    End Sub

    Private Sub InitAllViews()
        Try
            MG_ViewerCurrent = MG_Viewer1
            MG_ViewerCurrent.RangeEnd = 0
            MG_ViewerCurrent.Pitch = mSetup.Machine.ViewAngles(0)
            MG_ViewerCurrent.Roll = mSetup.Machine.ViewAngles(1)
            MG_ViewerCurrent.Yaw = mSetup.Machine.ViewAngles(2)

            MG_Viewer1.Init()
            MG_Viewer2.Init()
            MG_Viewer3.Init()
            MG_Viewer4.Init()

            MG_Viewer1.FindViewExtents()
            MG_Viewer2.FindViewExtents()
            MG_Viewer3.FindViewExtents()
            MG_Viewer4.FindViewExtents()
            MG_ViewerCurrent.Redraw(True)
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim tls As New Generic.Dictionary(Of Single, clsToolLayer)
            For Each tl As clsToolLayer In MG_ViewerCurrent.ToolLayers.Values
                Dim t As New clsToolLayer(tl.Number, tl.Color)
                t.Hidden = tl.Hidden
                tls.Add(tl.Number, t)
            Next

            If Not SplitContainer1.Panel1Collapsed Then
                LoadFile(cncFile, True)
            End If

            ProcessText()

            For Each tl As clsToolLayer In tls.Values
                If MG_ViewerCurrent.ToolLayers.ContainsKey(tl.Number) Then
                    MG_ViewerCurrent.ToolLayers(tl.Number).Hidden = tl.Hidden
                End If
            Next

        Catch ex As Exception
            mLog.LogError(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
        MG_ViewerCurrent.Redraw(True)
    End Sub

    Private Sub ProcessText()
        mLog.Alerts.Clear()
        mLog.Exceptions.Clear()
        lblStatus.Text = "Processing..."
        mMotionBlocks.Clear()
        RTB.ClearLineHighlight()

        mParser.LoadColorsFromSettings(My.Settings.ToolColors)
        mParser.ProcessText(RTB.FileName, RTB.Text, mMotionBlocks, mNcProgs)
        MG_ViewerCurrent.RangeEnd = MG_ViewerCurrent.AllMotionRecords.Count - 1

        BreakPointSlider.Maximum = MG_ViewerCurrent.AllMotionRecords.Count - 1
        If MG_ViewerCurrent.RangeEnd > MG_ViewerCurrent.AllMotionRecords.Count - 1 Then
            MG_ViewerCurrent.RangeEnd = MG_ViewerCurrent.AllMotionRecords.Count - 1
        End If
        MG_ViewerCurrent.GatherToolsFromMotionRecords()

        MG_ViewerCurrent.CalculateToolpath3DExtents()

        If mParser.ParseErrors.Count > 0 And mParser.ParseErrors.Count < 50 Then
            For Each p As clsParseError In mParser.ParseErrors
                ShowSyntaxError(p.CharPosition, p.LinePosition)
            Next
        End If
        lblStatus.Text = "Done"
        If MG_ViewerCurrent.AllMotionRecords.Count > 0 Then
            NC_Player.LastTool = MG_ViewerCurrent.AllMotionRecords(0).Tool
        End If
        Progress.Value = 0
    End Sub

    Private Sub ShowSyntaxError(ByVal charPos As Integer, ByVal linePos As Integer)
        RTB.ScrollLineToCenter(linePos)
        RTB.HighlightSyntaxError(charPos, linePos)
    End Sub


    Private Sub mnuViewOrient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTop.Click, mnuRight.Click, mnuIsometric.Click, mnuFront.Click, tsmTop.Click, tsmRight.Click, tsmISO.Click, tsmFront.Click
        Select Case CType(sender, System.Windows.Forms.ToolStripMenuItem).Tag.ToString
            Case "viewtop"
                MG_ViewerCurrent.Pitch = 0
                MG_ViewerCurrent.Roll = 0
                MG_ViewerCurrent.Yaw = 0
            Case "viewfront"
                MG_ViewerCurrent.Pitch = 270
                MG_ViewerCurrent.Roll = 0
                MG_ViewerCurrent.Yaw = 360
            Case "viewright"
                MG_ViewerCurrent.Pitch = 270
                MG_ViewerCurrent.Roll = 0
                MG_ViewerCurrent.Yaw = 270
            Case "viewiso"
                MG_ViewerCurrent.Pitch = 315
                MG_ViewerCurrent.Roll = 0
                MG_ViewerCurrent.Yaw = 315
        End Select
        MG_ViewerCurrent.FindViewExtents()
        MG_ViewerCurrent.Redraw(False)
    End Sub

    Private Sub MG_Viewer_MouseLocation(x As System.Single, y As System.Single, z As Single) Handles MG_ViewerCurrent.MouseLocation
        Try
            lblStatus.Text = "X=" & x.ToString("0.0000") & "   Y=" & y.ToString("0.0000") & "   Z=" & z.ToString("0.0000")
        Catch
        End Try
    End Sub

    Private Sub DisplayCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRapidPoints.CheckedChanged, mnuRapidLines.CheckedChanged, mnuAxisLines.CheckedChanged, mnuAxisindicator.CheckedChanged, mnuAxisLimits.CheckedChanged
        If MG_ViewerCurrent Is Nothing Then Return
        MG_ViewerCurrent.DrawRapidLines = mnuRapidLines.Checked
        MG_ViewerCurrent.DrawRapidPoints = mnuRapidPoints.Checked
        MG_ViewerCurrent.DrawAxisLines = mnuAxisLines.Checked
        MG_ViewerCurrent.DrawAxisIndicator = mnuAxisindicator.Checked
        MG_ViewerCurrent.DrawAxisLimits = mnuAxisLimits.Checked
        MG_ViewerCurrent.Redraw(True)
    End Sub

    Private Sub ViewButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbZoom.Click, tsbRotate.Click, tsbPan.Click, tsbFit.Click, tsbFence.Click, tsbSelect.Click
        Dim tag As String = sender.GetType.GetProperty("Tag").GetValue(sender, Nothing).ToString

        Select Case tag
            Case "viewfit"
                If My.Computer.Keyboard.ShiftKeyDown Then
                    MG_Viewer1.FindViewExtents()
                    MG_Viewer2.FindViewExtents()
                    MG_Viewer3.FindViewExtents()
                    MG_Viewer4.FindViewExtents()
                    MG_ViewerCurrent.Redraw(True)
                Else
                    MG_ViewerCurrent.FindViewExtents()
                    MG_ViewerCurrent.Redraw(False)
                End If
            Case "viewpan"
                MG_ViewerCurrent.ViewManipMode = MG_BasicViewer.ManipMode.PAN
                tsbPan.Checked = True
                tsbRotate.Checked = False
                tsbZoom.Checked = False
                tsbFence.Checked = False
                tsbSelect.Checked = False
            Case "viewfence"
                MG_ViewerCurrent.ViewManipMode = MG_BasicViewer.ManipMode.FENCE
                tsbFence.Checked = True
                tsbRotate.Checked = False
                tsbZoom.Checked = False
                tsbPan.Checked = False
                tsbSelect.Checked = False
            Case "viewzoom"
                MG_ViewerCurrent.ViewManipMode = MG_BasicViewer.ManipMode.ZOOM
                tsbZoom.Checked = True
                tsbRotate.Checked = False
                tsbFence.Checked = False
                tsbPan.Checked = False
                tsbSelect.Checked = False
            Case "viewrotate"
                MG_ViewerCurrent.ViewManipMode = MG_BasicViewer.ManipMode.ROTATE
                tsbRotate.Checked = True
                tsbZoom.Checked = False
                tsbFence.Checked = False
                tsbPan.Checked = False
                tsbSelect.Checked = False
            Case "select"
                MG_ViewerCurrent.ViewManipMode = MG_BasicViewer.ManipMode.SELECTION
                tsbRotate.Checked = False
                tsbZoom.Checked = False
                tsbFence.Checked = False
                tsbPan.Checked = False
                tsbSelect.Checked = True
        End Select
    End Sub

    Private Sub ScreensClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTwoScreens.Click, mnuOneScreen.Click, mnuFourScreens.Click
        Select Case CType(sender, ToolStripMenuItem).Tag.ToString
            Case "onescreen"
                Me.tblScreens.RowStyles(1).Height = 0
                Me.tblScreens.ColumnStyles(1).Width = 0
                MG_Viewer2.Visible = False
                MG_Viewer3.Visible = False
                MG_Viewer4.Visible = False
                My.Settings.Viewports = 1
            Case "twoscreens"
                Me.tblScreens.RowStyles(1).Height = 0
                Me.tblScreens.ColumnStyles(1).Width = 50
                MG_Viewer2.Visible = True
                MG_Viewer3.Visible = False
                MG_Viewer4.Visible = False
                My.Settings.Viewports = 2
            Case "fourscreens"
                Me.tblScreens.RowStyles(1).Height = 50
                Me.tblScreens.ColumnStyles(1).Width = 50
                MG_Viewer2.Visible = True
                MG_Viewer3.Visible = True
                MG_Viewer4.Visible = True
                My.Settings.Viewports = 4
        End Select
        SetDefaultViews()
    End Sub

    Private Sub ViewportActivated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MG_Viewer1.MouseEnter, MG_Viewer4.Click, MG_Viewer3.Click, MG_Viewer2.Click, MG_Viewer1.Click
        MG_ViewerCurrent = CType(sender, MG_BasicViewer)
    End Sub

    Private Sub SetDefaultViews()
        'Case "Top"
        MG_Viewer1.Pitch = 0.0F
        MG_Viewer1.Roll = 0.0F
        MG_Viewer1.Yaw = 0.0F
        MG_Viewer1.FindViewExtents()
        'Case "Front"
        MG_Viewer3.Pitch = 270.0F
        MG_Viewer3.Roll = 0.0F
        MG_Viewer3.Yaw = 360.0F
        MG_Viewer3.FindViewExtents()

        'Case "Right"
        MG_Viewer4.Pitch = 270.0F
        MG_Viewer4.Roll = 0.0F
        MG_Viewer4.Yaw = 270.0F
        MG_Viewer4.FindViewExtents()

        'Case "ISO"
        MG_Viewer2.Pitch = 315.0F
        MG_Viewer2.Roll = 0.0F
        MG_Viewer2.Yaw = 315.0F
        MG_Viewer2.FindViewExtents()
        MG_ViewerCurrent.Redraw(True)
    End Sub

    Private Sub mViewer_OnSelection(ByVal hits As System.Collections.Generic.List(Of clsMotionRecord), ByVal i As Integer) Handles MG_ViewerCurrent.OnSelection
        If hits.Count > 0 Then
            lblStatus.Text = hits(0).Codestring
            HighlightLine(hits(0).Linenumber)
        Else
            lblStatus.Text = ""
        End If
    End Sub

    Private Sub mViewer_OnSetViewMode(ByVal mode As MG_BasicViewer.ManipMode) Handles MG_ViewerCurrent.OnSetViewMode
        Select Case mode
            Case MG_BasicViewer.ManipMode.PAN
                tsbPan.Checked = True
                tsbRotate.Checked = False
                tsbZoom.Checked = False
                tsbFence.Checked = False
                tsbSelect.Checked = False
            Case MG_BasicViewer.ManipMode.FENCE
                tsbFence.Checked = True
                tsbRotate.Checked = False
                tsbZoom.Checked = False
                tsbPan.Checked = False
                tsbSelect.Checked = False
            Case MG_BasicViewer.ManipMode.ZOOM
                tsbZoom.Checked = True
                tsbRotate.Checked = False
                tsbFence.Checked = False
                tsbPan.Checked = False
                tsbSelect.Checked = False
            Case MG_BasicViewer.ManipMode.ROTATE
                tsbRotate.Checked = True
                tsbZoom.Checked = False
                tsbFence.Checked = False
                tsbPan.Checked = False
                tsbSelect.Checked = False
            Case MG_BasicViewer.ManipMode.SELECTION
                tsbRotate.Checked = False
                tsbZoom.Checked = False
                tsbFence.Checked = False
                tsbPan.Checked = False
                tsbSelect.Checked = True
        End Select
    End Sub

    Private Sub MG_Viewer_OnStatus(ByVal msg As String, ByVal index As Integer, ByVal max As Integer) Handles MG_ViewerCurrent.OnStatus
        lblStatus.Text = msg
        Progress.Maximum = max
        Progress.Value = index
        StatusStrip1.Refresh()
    End Sub

    Private Sub tsbTools_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbToolsFilter.Click
        Dim loc As New Point
        Dim nd As TreeNode
        Try
            loc = PointToScreen(tsbToolsFilter.Bounds.Location)
            loc.Offset(0, tsbToolsFilter.Bounds.Height)
            Using frm As New frmToolLayers
                frm.tvTools.Nodes.Clear()

                For Each tl As clsToolLayer In MG_ViewerCurrent.ToolLayers.Values
                    nd = frm.tvTools.Nodes.Add("Tool " & tl.Number.ToString)
                    nd.ForeColor = tl.Color
                    nd.Checked = Not tl.Hidden
                    nd.Tag = tl
                Next

                frm.tvTools.BackColor = Me.MG_Viewer1.BackColor
                frm.StartPosition = FormStartPosition.Manual
                frm.Location = loc
                If frm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    For Each nd In frm.tvTools.Nodes
                        CType(nd.Tag, clsToolLayer).Hidden = Not nd.Checked
                        CType(nd.Tag, clsToolLayer).Color = nd.ForeColor
                        My.Settings.ToolColors(nd.Index) = nd.ForeColor.ToArgb.ToString
                    Next
                End If
            End Using
            MG_ViewerCurrent.Redraw(True)
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub tsbSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSettings.Click
        Using frm As New frmViewerSetup
            frm.ShowDialog()
        End Using

        'Set the tool layers from the settings
        Dim r As Integer = 0
        For Each tl As clsToolLayer In MG_ViewerCurrent.ToolLayers.Values
            tl.Color = System.Drawing.Color.FromArgb(CInt(My.Settings.ToolColors(r)))
            r += 1
        Next

        MG_ViewerCurrent.MotionColor_Rapid = My.Settings.MotionColorRapid
        MG_ViewerCurrent.MotionColor_Line = My.Settings.MotionColorLinear
        MG_ViewerCurrent.MotionColor_ArcCCW = My.Settings.MotionColorCCWArc
        MG_ViewerCurrent.MotionColor_ArcCW = My.Settings.MotionColorCWArc

        tscboMachines.SelectedIndex = tscboMachines.FindStringExact(mSetup.MachineName)
        mSetup.ReloadCurrentMachine()
        tsbRefresh.PerformClick()
        InitAllViews()
        MG_Viewer1.FindViewExtents()
        MG_Viewer2.FindViewExtents()
        MG_Viewer3.FindViewExtents()
        MG_Viewer4.FindViewExtents()
        MG_ViewerCurrent.LimitsColor = My.Settings.ViewerLimitsColor

        MG_ViewerCurrent.Redraw(True)
    End Sub

    Private Sub mSetup_MachineActivated(ByVal m As clsMachine) Handles mSetup.MachineActivated
        With MG_Viewer1
            .RotaryDirection = m.RotaryDir
            .RotaryPlane = m.RotaryAxis
            .RotaryType = m.RotaryType
            .ViewManipMode = MG_BasicViewer.ManipMode.SELECTION
            .Limits() = m.Limits
        End With
        tscboMachines.SelectedIndex = tscboMachines.FindStringExact(m.Name)
    End Sub

    Private Sub mSetup_MachineAdded(ByVal name As String) Handles mSetup.MachineAdded
        tscboMachines.Items.Add(name)
    End Sub

    Private Sub mSetup_MachineDeleted(ByVal name As String) Handles mSetup.MachineDeleted
        Try
            tscboMachines.Items.RemoveAt(tscboMachines.FindStringExact(name))
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub tscboMachines_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tscboMachines.SelectedIndexChanged
        If String.Compare(Me.mSetup.MachineName, tscboMachines.SelectedItem.ToString) <> 0 Then
            Me.mSetup.MachineName = tscboMachines.SelectedItem.ToString
        End If
    End Sub

    Private Sub mSetup_MachinesCleared() Handles mSetup.MachinesCleared
        tscboMachines.Items.Clear()
    End Sub


    Private Sub frmViewer_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If MG_ViewerCurrent IsNot Nothing Then MG_ViewerCurrent.Redraw(True)
    End Sub


    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click
        Try
            Using dlg As New PrintDialog()
                dlg.Document = PrnDoc
                If (dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                    dlg.Document.Print()
                End If
            End Using
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub mnuWebSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWebSite.Click, mnuWeb.Click
        Try
            System.Diagnostics.Process.Start(My.Resources.datBasicViewerUrl & My.Application.Info.Version.ToString)
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub tsbBackColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBackColor.Click
        With Me.ColorDialog1
            If .ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                SetViewersBgColor(.Color)
                My.Settings.ViewsBackColor = .Color
            End If
        End With
    End Sub

    Private Sub SetViewersBgColor(ByVal clr As Color)
        Me.tblScreens.BackColor = clr
        MG_Viewer1.BackColor = clr
        MG_Viewer2.BackColor = clr
        MG_Viewer3.BackColor = clr
        MG_Viewer4.BackColor = clr
        MG_ViewerCurrent.Redraw(True)
    End Sub

    Private Sub mLogger_Status(ByVal msg As String) Handles mLog.Status
        lblStatus.Text = msg
        lblStatus.Image = My.Resources.warning
    End Sub

    Private Sub BreakPointSlider_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BreakPointSlider.ValueChanged
        With MG_ViewerCurrent
            .RangeEnd = BreakPointSlider.Value
            .Redraw(True)
            .SelectLastElement()
            .DrawTextOverlay(.RangeEnd.ToString & " - " & .RangeMax.ToString)
            If MG_ViewerCurrent.RangeEnd > 0 Then
                HighlightLine(MG_ViewerCurrent.AllMotionRecords(MG_ViewerCurrent.RangeEnd).Linenumber)
            End If

        End With
    End Sub

    Private Sub mnuEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEmail.Click
        Try
            Dim body As String = mLog.ReadLogContents.Replace(Environment.NewLine, "%0A")
            System.Diagnostics.Process.Start("mailto:" & My.Resources.datEmail & "?subject=MG_SUPPORT:" & My.Application.Info.ProductName & "&Body=" & body)
        Catch
        End Try
    End Sub

    Private Sub FileWatcher_Changed(ByVal sender As System.Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileWatcher.Changed
        tsbRefresh.PerformClick()
    End Sub

    Private Sub mProcessor_OnProgress(ByVal percent As Integer) Handles mParser.OnProgress
        If percent > 0 And percent < 101 Then
            Progress.Value = percent
        End If
    End Sub

    Private Sub frmBasicViewer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.Alt Then
                Select Case e.KeyCode
                    Case Keys.X
                        MG_ViewerCurrent.Pitch = CSng(MG_ViewerCurrent.Pitch + 45.0)
                        MG_ViewerCurrent.Redraw(False)
                    Case Keys.Y
                        MG_ViewerCurrent.Roll = CSng(MG_ViewerCurrent.Roll + 45.0)
                        MG_ViewerCurrent.Redraw(False)
                    Case Keys.Z
                        MG_ViewerCurrent.Yaw = CSng(MG_ViewerCurrent.Yaw + 45.0)
                        MG_ViewerCurrent.Redraw(False)
                End Select

            Else
                Select Case e.KeyCode
                    Case Keys.A
                        MG_ViewerCurrent.RangeStart = 0
                        MG_ViewerCurrent.Redraw(True)
                    Case Keys.B
                        If BreakPointSlider.Value > 1 Then
                            BreakPointSlider.Value -= 1
                        End If
                    Case Keys.C
                        MG_ViewerCurrent.RangeStart = BreakPointSlider.Value
                        MG_ViewerCurrent.Redraw(True)
                    Case Keys.S
                        If BreakPointSlider.Value < BreakPointSlider.Maximum Then
                            BreakPointSlider.Value += 1
                        End If
                    Case Keys.W
                        MG_ViewerCurrent.SetView(MG_BasicViewer.ManipMode.FENCE)
                    Case Keys.Escape
                        MG_ViewerCurrent.SetView(MG_BasicViewer.ManipMode.SELECTION)
                    Case Keys.P
                        MG_ViewerCurrent.SetView(MG_BasicViewer.ManipMode.PAN)
                    Case Keys.R
                        MG_ViewerCurrent.SetView(MG_BasicViewer.ManipMode.ROTATE)
                    Case Keys.Z
                        MG_ViewerCurrent.SetView(MG_BasicViewer.ManipMode.ZOOM)
                    Case Keys.F
                        MG_ViewerCurrent.SetView(MG_BasicViewer.ManipMode.FIT, My.Computer.Keyboard.ShiftKeyDown)
                End Select
            End If

        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub MG_Player_OnTick(ByVal n As Integer) Handles NC_Player.OnTick
        Dim bpv As Integer = BreakPointSlider.Value
        With MG_ViewerCurrent
            If n <= 0 Then
                bpv += 1
            Else
                bpv += (n * Math.Max(.RangeMax \ 1000, 1))
            End If

            If NC_Player.OptionStop Then
                For r As Integer = .RangeEnd To bpv
                    If NC_Player.LastTool <> .AllMotionRecords(r).Tool Then
                        NC_Player.LastTool = .AllMotionRecords(r).Tool
                        NC_Player.StopPlay()
                        bpv = r
                        Exit For
                    End If
                    If r = .RangeMax Then
                        NC_Player.LastTool = .AllMotionRecords(0).Tool
                        NC_Player.StopPlay()
                        bpv = r
                        Exit For
                    End If
                Next
            End If

            If bpv >= .RangeMax Then
                bpv = 0
            End If

        End With
        BreakPointSlider.Value = bpv
    End Sub

    Private Sub tsbPlay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPlay.CheckedChanged
        Try
            If tsbPlay.Checked Then
                NC_Player.Visible = True
            Else
                NC_Player.StopPlay()
                NC_Player.Visible = False
            End If
        Catch ex As Exception
            NC_Player.StopPlay()
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub MG_Viewer_OnSlowDrawingAlert(ByVal vewCtrl As MG_BasicViewer) Handles MG_Viewer1.OnSlowDrawingAlert
        Dim msg As String = Environment.NewLine & "World = " & vewCtrl.ViewRect.ToString
        If MsgBox(My.Resources.msgSlowGfxPerf & msg, MsgBoxStyle.YesNo Or MsgBoxStyle.Information, "Graphics Performance") = MsgBoxResult.Yes Then
            vewCtrl.CancelCreateDisplayList(True)
        Else
            vewCtrl.CancelCreateDisplayList(False)
        End If
    End Sub

    Private Sub tsbSelectedColor_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tsbSelectedColor.DropDownItemClicked
        My.Settings.ViewerSelectionColor = tsbSelectedColor.SelectedColor
        Me.MG_ViewerCurrent.SelectionColor = tsbSelectedColor.SelectedColor
    End Sub

    Private Sub tsbZFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbZFilter.Click
        Dim loc As New Point
        Try
            loc = PointToScreen(tsbZFilter.Bounds.Location)
            loc.Offset(0, tsbZFilter.Bounds.Height)
            With MG_ViewerCurrent

                Using frm As New frmZ_Filter
                    frm.UpperLimit = mParser.MaxZ
                    frm.LowerLimit = mParser.MinZ
                    If Single.IsNaN(.FilterUpperZ) Then
                        frm.txtUpper.Text = mParser.MaxZ.ToString("###0.0###")
                        frm.txtLower.Text = mParser.MinZ.ToString("###0.0###")
                    Else
                        frm.txtUpper.Text = .FilterUpperZ.ToString("###0.0###")
                        frm.txtLower.Text = .FilterLowerZ.ToString("###0.0###")
                        frm.rdoCrossing.Checked = .FilterZCrossing
                    End If
                    frm.StartPosition = FormStartPosition.Manual
                    frm.Location = loc


                    If frm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        If frm.txtUpper.Text.Length > 0 AndAlso frm.txtLower.Text.Length > 0 Then
                            .FilterZ = True
                            .FilterUpperZ = Single.Parse(frm.txtUpper.Text, Globalization.NumberFormatInfo.InvariantInfo)
                            .FilterLowerZ = Single.Parse(frm.txtLower.Text, Globalization.NumberFormatInfo.InvariantInfo)
                            .FilterZCrossing = frm.rdoCrossing.Checked
                        End If
                    Else
                        .FilterZ = False
                    End If
                End Using
                .SetZFilter()
                .Redraw(True)
            End With
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub tsbElementDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbElementDetails.Click
        Try
            tsbElementDetails.Checked = MG_ViewerCurrent.ShowElementDetails()
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    'Loads the combo with names
    Private Sub LoadComboNames(ByRef fo As String, ByRef cbo As ToolStripComboBox, ByVal searchPattern As String)
        Try
            cbo.BeginUpdate()
            cbo.Items.Clear()
            Dim fls As List(Of String) = GetDatFileNames(fo, searchPattern)
            For Each fl As String In fls
                cbo.Items.Add(fl)
            Next
            cbo.EndUpdate()
        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Private Function GetDatFileNames(ByRef fo As String, ByVal searchPattern As String) As List(Of String)
        Dim fls As String()
        Dim ret As New List(Of String)
        fls = Directory.GetFiles(fo, searchPattern)
        For Each f As String In fls
            Try
                ret.Add(IO.Path.GetFileNameWithoutExtension(f))
            Catch
            End Try
        Next
        Return ret
    End Function

    Private Sub tsCboScheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tsCboScheme.SelectedIndexChanged
        Try
            LoadScheme(tsCboScheme.Text)
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub tsbToggleEditor_CheckedChanged(sender As Object, e As EventArgs) Handles tsbToggleEditor.CheckedChanged
        Try
            If tsbToggleEditor.Checked Then
                SplitContainer1.SplitterDistance = My.Settings.EditorWidth
            Else
                My.Settings.EditorWidth = SplitContainer1.SplitterDistance
            End If
            SplitContainer1.Panel1Collapsed = Not tsbToggleEditor.Checked
        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub


    Private Sub ColorVisibleRangeText(Optional ByVal force As Boolean = False, Optional ByVal buildGutter As Boolean = True)
        Dim first As Integer
        Dim last As Integer
        Try
            With RTB
                .GetVisibleRange(first, last)
                If Not .IsRangeFormatted(first, last) Or force Then
                    .GetPaddedRange(first, last, 30)
                    .Lock()
                    .SaveScrollAndCursor()
                    ColorRangeText(first, last)

                    .AddPaddedRange(first, last)
                    .RestoreScrollAndCursor()

                    .UnLock()
                    RTB.DrawHighlightRectangle() 'Again
                End If
            End With
        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Friend Sub ColorRangeText(ByVal firstChar As Integer, ByVal lastChar As Integer)
        Try
            With RTB
                .SelectionStart = firstChar
                .SelectionLength = lastChar - firstChar
                If mScheme.ColorByMode AndAlso mScheme.Optimized Then
                    mScheme.InitRtf()
                    mScheme.GetLastMode(.Text.Substring(0, firstChar))
                End If
                mScheme.BuildRtf(.SelectedRtf, .SelectedText)
            End With
        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Public Sub ColorOneLine(ByVal line As Integer)
        With RTB
            .Lock()
            .SelectLine(line)
            mScheme.BuildRtf(.SelectedRtf, .SelectedText)
            .UnLock()
        End With
    End Sub

    Public Sub ColorAll(Optional ByVal force As Boolean = False)
        Try
            If force Then
                With RTB
                    .Lock()
                    .SaveScrollAndCursor()
                    mScheme.BuildRtf(.RTF, .Text)
                    .RestoreScrollAndCursor()
                    .AddPaddedRange(0, .TextLength)
                    .UnLock()
                End With
            End If
        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Private Sub SetRTF(ByVal t As String)
        Try
            With RTB
                mScheme.BuildRtf(.RTF, "" & Environment.NewLine)
                .SelectionStart = 0
                .SelectionLength = 2
                .SelectedText = t
                .SelectionStart = 0
                .ClearUndo()
            End With
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub tsbColorize_Click(sender As Object, e As EventArgs) Handles tsbColorize.Click
        ColorVisibleRangeText(True)
    End Sub

    Private Sub HighlightLine(ByVal lineNumber As Integer)
        Dim selstart As Integer
        Try
            RTB.ClearLineHighlight()
            If lineNumber > 0 Then
                selstart = RTB.GetFirstCharIndexFromLine(lineNumber - 1)
                'Do not scroll to center unless we are off the screen
                If selstart < RTB.FirstVisibleLineChar OrElse selstart > RTB.LastVisibleLineChar Then
                    RTB.ScrollLineToCenter(lineNumber)
                End If
                RTB.SelectionLength = 0
                ColorVisibleRangeText(False)
                RTB.HighlightLineWithRectangle(lineNumber)
            End If
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub RTB_SelectionChanged(sender As Object, e As EventArgs) Handles RTB.SelectionChanged
        Try
            RTB.ClearLineHighlight()
            Dim st As Integer = RTB.GetLineFromCharIndex(RTB.SelectionStart)
            Dim en As Integer = RTB.GetLineFromCharIndex(RTB.SelectionStart + RTB.SelectionLength)
            MG_ViewerCurrent.SetSelectionHits(st + 1, en + 1, 0)
        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Private Sub tsbSaveAs_Click(sender As Object, e As EventArgs) Handles tsbSaveAs.Click
        Try
            SaveFileAs()
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub


    Private Sub tsbSaveFile_Click(sender As Object, e As EventArgs) Handles tsbSaveFile.Click
        Try
            If RTB.FileName.Length > 0 Then
                SaveFile(RTB.FileName)
            Else
                SaveFileAs()
            End If
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub tsbPlot_Click(sender As Object, e As EventArgs) Handles tsbPlot.Click
        Try
            ProcessText()
            If tsbAutoZoom.Checked Then
                MG_Viewer1.FindViewExtents()
                MG_Viewer2.FindViewExtents()
                MG_Viewer3.FindViewExtents()
                MG_Viewer4.FindViewExtents()
            End If
            MG_ViewerCurrent.Redraw(True)
        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Private Function SaveFileAs() As Boolean
        Using SaveFileDialog
            With SaveFileDialog
                .InitialDirectory = mLastFolder
                .Filter = "Text (*.*)|*.*|Text (*.TXT)|*.TXT|Rich Text (*.RTF)|*.RTF"
                .Title = "Save"
                .CheckPathExists = False
                .CheckFileExists = False
                If .ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    SaveFile(.FileName)
                    RTB.FileName = .FileName
                    mLastFolder = Path.GetFullPath(.FileName)
                    tsbRefresh.Enabled = True
                    Return True
                Else
                    Return False
                End If
            End With
        End Using

    End Function

    Private Function SaveFile(filename As String) As Boolean
        If RTB.FileName.EndsWith(".RTF", StringComparison.OrdinalIgnoreCase) Then
            Me.RTB.SaveFile(filename, RichTextBoxStreamType.RichText)
        Else
            Me.RTB.SaveFile(filename, RichTextBoxStreamType.PlainText)
        End If
    End Function

    Private Sub tsbAddSpaces_Click(sender As Object, e As EventArgs) Handles tsbAddSpaces.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            With RTB
                .SaveScroll()
                .Lock()
                .InvalidateAllPages()
                If My.Computer.Keyboard.ShiftKeyDown Then
                    SetRTF(mScheme.ContractAll(.Text))
                Else
                    SetRTF(mScheme.ExpandAll(.Text))
                End If
                .RestoreScroll()
                ColorVisibleRangeText(True)
                .UnLock()
            End With
        Catch ex As Exception
            mLog.LogError(ex)
        Finally
            Me.Cursor = Cursors.Default
            RTB.UnLock()
        End Try

    End Sub

    Private Sub RTB_KeyUp(sender As Object, e As KeyEventArgs) Handles RTB.KeyUp
        If e.KeyCode = Keys.Return Then
            ColorVisibleRangeText(True)
            ProcessText()
            If tsbAutoZoom.Checked Then
                MG_Viewer1.FindViewExtents()
                MG_Viewer2.FindViewExtents()
                MG_Viewer3.FindViewExtents()
                MG_Viewer4.FindViewExtents()
            End If
            MG_ViewerCurrent.Redraw(True)
        End If
    End Sub

    Private Sub tsbNewFile_Click(sender As Object, e As EventArgs) Handles tsbNewFile.Click
        If tsbSaveFile.Enabled Then
            If MsgBox("Save file?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If RTB.FileName.Length > 0 Then
                    SaveFile(RTB.FileName)
                Else
                    SaveFileAs()
                End If
            End If
        End If
        RTB.FileName = ""
        cncFile = ""
        tsbRefresh.Enabled = False
        RTB.Clear()
        SetTitleBar()
        mMotionBlocks.Clear()
        MG_ViewerCurrent.InitSiblingMotionBlocks(mMotionBlocks)
        MG_ViewerCurrent.Redraw(True)
    End Sub

    Private Sub RTB_AfterVScroll() Handles RTB.AfterVScroll
        ColorVisibleRangeText()
    End Sub

    Private Sub tsbTouch_CheckedChanged(sender As Object, e As EventArgs) Handles tsbTouch.CheckedChanged
        SetTouchModeDisplay(tsbTouch.Checked)
    End Sub

    Private Sub RTB_OnApply() Handles RTB.OnApply
        tsbSaveFile.Enabled = True
    End Sub
    'Find the \/ nearest the max value
    Private Function LongDirFix(ByRef sInComming As String) As String
        Dim imax As Integer = 50
        Dim lenFull As Integer = sInComming.Length
        'If lenth is ok then exit function
        If lenFull <= imax Then
            Return sInComming
        Else
            Dim r As Integer
            For r = (lenFull - imax) To 1 Step -1
                If sInComming(r) = Path.DirectorySeparatorChar Then
                    Exit For
                End If
            Next
            Return sInComming.Substring(0, 3) & " ..." & sInComming.Substring(r)
        End If
    End Function

    Private Sub tsbMotionColor_Click(sender As Object, e As EventArgs) Handles tsbMotionColor.Click
        MG_ViewerCurrent.MotionColorByMotionType = tsbMotionColor.Checked
        MG_ViewerCurrent.Redraw(True)
    End Sub
End Class