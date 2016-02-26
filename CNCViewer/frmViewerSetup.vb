Option Strict On
Option Explicit On
Friend Class frmViewerSetup
    Inherits System.Windows.Forms.Form
    Private WithEvents mLog As clsLogger = clsLogger.Instance
    Private WithEvents mSetup As clsSettings = clsSettings.Instance
    Private mMachine As clsMachine
    Private mDirty As Boolean
    Private mSelToolClrRect As New Rectangle(0, 0, 16, 32)
    Private mToolIndex As Integer = -1
    Private Const FORCE_DECIMAL As String = "INTEGER"

    Public Property DirtySetup() As Boolean
        Get
            Return mDirty
        End Get
        Set(ByVal value As Boolean)
            mDirty = value
            Status.Text = "Dirty = " & value.ToString
        End Set
    End Property

    Private Sub cboMachines_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboMachines.SelectedIndexChanged
        If mSetup.MachineName <> cboMachines.SelectedItem.ToString Then 'Move to new record
            If Me.ChangedMsg Then
                SaveFields(mMachine.Name)
                DirtySetup = False
            End If
            mSetup.MachineName = cboMachines.SelectedItem.ToString
            FillFields() 'reads in data
        End If
    End Sub

    Function ChangedMsg() As Boolean
        ChangedMsg = False
        If DirtySetup Then
            DirtySetup = False
            If MsgBox(My.Resources.msgPromptToSave, MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.MsgBoxSetForeground) = MsgBoxResult.Yes Then
                ChangedMsg = True
            End If
        End If
    End Function

    Private Sub cbo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboPrecision.SelectedIndexChanged, cboFeedPrecision.SelectedIndexChanged, cboUnits.SelectedIndexChanged
        DirtySetup = True
    End Sub

    Private Sub cboRotAxis_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboRotAxis.SelectedIndexChanged
        DirtySetup = True
    End Sub

    Private Sub cboRotPrecision_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboRotPrecision.SelectedIndexChanged
        DirtySetup = True
    End Sub

    Private Sub chkAbsCenter_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAbsCenter.CheckStateChanged
        DirtySetup = True
    End Sub

    Private Sub chkUVW_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUVW.CheckStateChanged, chkInvertArcCenterValues.CheckStateChanged
        DirtySetup = True
    End Sub
    Private Sub chkReverseRot_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkReverseRot.CheckStateChanged
        DirtySetup = True
    End Sub

    Private Sub frmSetup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Me.ChangedMsg Then
                SaveFields(mMachine.Name)
                DirtySetup = False
            End If
            My.Settings.ViewerSetupLocation = Me.Location

            If rdoPrintAsShown.Checked Then
                My.Settings.ViewerPrintMode = 0
            End If
            If rdoPrintActualSize.Checked Then
                My.Settings.ViewerPrintMode = 1
            End If

            If rdoPrintScaled.Checked Then
                My.Settings.ViewerPrintMode = 2
            End If

            My.Settings.MotionColorRapid = cboRapidColor.SelectedColor
            My.Settings.MotionColorLinear = cboLineColor.SelectedColor
            My.Settings.MotionColorCCWArc = cboCCWarcColor.SelectedColor
            My.Settings.MotionColorCWArc = cboCWarcColor.SelectedColor


            My.Settings.ViewPrintScale = Single.Parse(txtPrintScale.Text, Globalization.NumberFormatInfo.InvariantInfo)
            mSetup = Nothing
            mLog = Nothing
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub frmSetup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Try
            Dim curMachine As String = mSetup.Machine.Name
            Me.Location = My.Settings.ViewerSetupLocation
            cboPrecision.Items.Add(FORCE_DECIMAL)

            EnsureFormIsOnScreen(Me)

            mSetup.LoadAllMachines()
            If cboMachines.Items.Count = 0 Then
                NewMachine("Sample")
            End If

            DirtySetup = False

            If curMachine IsNot Nothing Then
                cboMachines.SelectedIndex = cboMachines.FindStringExact(curMachine)
            Else
                cboMachines.SelectedIndex = cboMachines.FindStringExact(mSetup.Machine.Name)
            End If
            mMachine = mSetup.Machine

            FillFields() 'reads in data
            LoadFontsList()

            cboSize.Text = CStr(CInt(My.Settings.ViewerOverlayFont.Size))
            cboFont.Text = My.Settings.ViewerOverlayFont.FontFamily.Name
            chkShowExtraOverlayInfo.Checked = My.Settings.ViewerShowExtraOverlayDetails
            chkReverseMouseWheel.Checked = My.Settings.ReverseMouseWheel
            Select Case My.Settings.ViewerPrintMode
                Case 0
                    rdoPrintAsShown.Checked = True
                Case 1
                    rdoPrintActualSize.Checked = True
                Case 2
                    rdoPrintScaled.Checked = True
            End Select
            txtPrintScale.Text = My.Settings.ViewPrintScale.ToString("##0.0###")

            cboRapidColor.SelectedColor = My.Settings.MotionColorRapid
            cboLineColor.SelectedColor = My.Settings.MotionColorLinear
            cboCCWarcColor.SelectedColor = My.Settings.MotionColorCCWArc
            cboCWarcColor.SelectedColor = My.Settings.MotionColorCWArc

            DirtySetup = False
            Me.MG_Viewer1.Init()
            Me.MG_Viewer1.WindowViewport(-2.0F, 2.0F, 2.0F, -2.0F)
            Status.Text = "Ready"
        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Private Function LoadFontsList() As Boolean
        Dim ff As FontFamily
        Me.Cursor = Cursors.WaitCursor
        cboFont.BeginUpdate()
        For Each ff In System.Drawing.FontFamily.Families
            If ff.IsStyleAvailable(FontStyle.Regular And FontStyle.Bold And FontStyle.Italic And FontStyle.Underline) Then
                cboFont.Items.Add(ff.Name)
            End If
        Next
        cboFont.EndUpdate()
        Me.Cursor = Cursors.Default
    End Function

    Private Function GetOverlayFont() As Font
        Dim style As FontStyle
        Dim size As Integer = 10
        If cboSize.Text.Length > 0 Then
            size = Integer.Parse(cboSize.Text)
        End If
        style = FontStyle.Regular
        Return New Font(cboFont.Text, size, style)
    End Function

    Public Sub mnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub mnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tsbDelete.Click
        If MsgBox(My.Resources.msgConfirmDelete, MsgBoxStyle.YesNo Or MsgBoxStyle.MsgBoxSetForeground) = MsgBoxResult.Yes Then
            mSetup.DeleteMachine(mMachine.Name)
        End If
    End Sub

    Public Sub mnuNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tsbNewScheme.Click
        Dim newname As String
        If Me.ChangedMsg Then
            SaveFields(mMachine.Name)
            DirtySetup = False
        End If

        Using frm As New frmNewSetup
            If frmNewSetup.ShowDialog() = Windows.Forms.DialogResult.OK Then
                newname = frmNewSetup.GetName
                frmNewSetup.Close()
            Else
                Exit Sub
            End If
        End Using

        NewMachine(newname)
        cboMachines.SelectedIndex = cboMachines.FindStringExact(newname)
        'mSetup.MachineName = cboMachines.SelectedItem.ToString
    End Sub

    Private Sub tsbCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCopy.Click
        RenameMachine(True)
    End Sub


    Private Sub tsbRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRename.Click
        RenameMachine(False)
    End Sub

    Private Sub RenameMachine(ByVal copy As Boolean)
        Try
            Dim inc As Integer = 1
            Dim newName As String = mMachine.Name & "_" & inc.ToString

            If Me.ChangedMsg Then
                SaveFields(mMachine.Name)
                DirtySetup = False
            End If

            Using frm As New frmNewSetup
                Do
                    If frmNewSetup.ShowDialog(newName) = Windows.Forms.DialogResult.OK Then
                        newName = frmNewSetup.GetName
                        frmNewSetup.Close()
                    Else
                        Exit Sub
                    End If

                    If Not mSetup.MachineExists(newName) Then
                        Exit Do
                    Else
                        newName &= inc.ToString
                    End If
                    inc += 1
                Loop
            End Using

            mSetup.RenameMachine(newName, copy)
            cboMachines.SelectedIndex = cboMachines.FindStringExact(newName)

        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub


    Public Sub mnuSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tsbSaveFile.Click
        SaveFields(mMachine.Name)
        DirtySetup = False
    End Sub

    Private Sub NewMachine(ByVal newname As String)
        Try
            If Trim(newname) = "" Then Exit Sub
            'Check to see if name is in use
            If cboMachines.FindString(newname) > -1 Then
                MsgBox("The name " & newname & " is already in use.", MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxSetForeground)
                Exit Sub
            End If

            optMachineType3.Checked = True
            txtDescription.Text = "Milling setup file"
            txtGlobalReplacements.Text = ""
            txtSearch.Text = newname
            txtProgramId.Text = ":$O"
            txtSubcall.Text = "M98"
            txtSubRepeats.Text = "L"
            txtReturn.Text = "M99"
            txtEndmain.Text = "M30"
            txtBlockSkip.Text = "/*"
            cboPrecision.SelectedIndex = 3
            cboFeedPrecision.SelectedIndex = 2
            txtCommentChars.Text = "();"
            txtRapidRate.Text = "100.0"
            txtRapid.Text = "G00"
            txtLinear.Text = "G01"
            txtCCarc.Text = "G03"
            txtCWarc.Text = "G02"
            txtAbs.Text = "G90"
            txtInc.Text = "G91"
            txtCompLeft.Text = "G41"
            txtCompRight.Text = "G42"
            txtCompCancel.Text = "G40"
            txtXYplane.Text = "G17"
            txtXZplane.Text = "G18"
            txtYZplane.Text = "G19"
            Me.txtDrillRapid.Text = "R"
            Me.txtDrillReturnInitialPln.Text = "G98"
            Me.txtDrillReturnRapidPln.Text = "G99"
            Me.txtDrills_0.Text = "G80"
            Me.txtDrills_1.Text = "G81"
            Me.txtDrills_2.Text = "G82"
            Me.txtDrills_3.Text = "G83"
            Me.txtDrills_4.Text = "G84"
            Me.txtDrills_5.Text = "G85"
            Me.txtDrills_6.Text = "G86"
            Me.txtDrills_7.Text = "G87"
            Me.txtDrills_8.Text = "G88"
            Me.txtDrills_9.Text = ""
            Me.txtDrills_10.Text = ""
            Me.optMachineType1.Checked = True 'Mill
            'Rotary tab
            cboRotPrecision.SelectedIndex = 3
            txtRotAxis.Text = "B"
            cboRotAxis.SelectedIndex = 2 'X
            chkReverseRot.CheckState = System.Windows.Forms.CheckState.Unchecked
            txtViewShift_0.Text = "0.0"
            txtViewShift_1.Text = "0.0"
            txtViewShift_2.Text = "0.0"
            Me.optRotateType1.Checked = True
            txtReturnHome.Text = "G28"
            txtToolChange.Text = "M06"
            txtHomeXAddress.Text = "U"
            txtHomeXValue.Text = "0.0"
            txtHomeXAddress.Text = "V"
            txtHomeXValue.Text = "0.0"
            txtHomeXAddress.Text = "W"
            txtHomeXValue.Text = "0.0"
            txtMaxRPMDefault.Text = "5000"
            txtMaxRpmCode.Text = "G50"
            txtSpeedModeRPM.Text = "G97"
            txtSpeedModeSFM.Text = "G96"
            txtUnitsEnglish.Text = "G20"
            txtUnitsMetric.Text = "G21"
            cboUnits.SelectedIndex = 0
            mSetup.AddMachine(newname)
            SaveFields(newname)
            mSetup.MachineName = newname
            DirtySetup = False
        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Private Sub FillFields()
        Try
            Me.chkIgnoreSpaces.Checked = My.Settings.IgnoreFileWhitespace
            With mMachine

                txtDescription.Text = .Description
                txtGlobalReplacements.Text = .GlobalReplacements
                txtProgramId.Text = .ProgramId
                txtSubcall.Text = .Subcall
                txtSubRepeats.Text = .SubRepeats
                txtReturn.Text = .SubReturn
                txtEndmain.Text = .Endmain
                txtBlockSkip.Text = .BlockSkip

                If .Precision = 0 Then
                    cboPrecision.SelectedIndex = cboPrecision.FindStringExact(FORCE_DECIMAL)
                Else
                    cboPrecision.SelectedIndex = .Precision - 1
                End If

                cboUnits.SelectedIndex = .MachineUnits
                txtUnitsEnglish.Text = .UnitsEnglishAddress
                txtUnitsMetric.Text = .UnitsMetricAddress

                cboFeedPrecision.SelectedIndex = .FeedPrecision + 4
                txtFeedModeMin.Text = .FeedModeMin
                txtFeedModeRev.Text = .FeedModeRev
                txtSpeedModeRPM.Text = .SpeedModeRPM
                txtSpeedModeSFM.Text = .SpeedModeSFM

                txtCommentChars.Text = .Comments
                optMachineType1.Checked = (.MachineType = MachineType.LATHEDIA)
                optMachineType2.Checked = (.MachineType = MachineType.LATHERAD)
                optMachineType3.Checked = (.MachineType = MachineType.MILL)
                txtRapidRate.Text = .RapidRate.ToString("#0.0#", System.Globalization.NumberFormatInfo.InvariantInfo)

                txtMaxRpmCode.Text = .MaxRpmAddress
                txtMaxRPMDefault.Text = .MaxRpmValue.ToString("#0.0#", System.Globalization.NumberFormatInfo.InvariantInfo)
                chkDogLeg.Checked = .DogLegMotion

                txtSearch.Text = .Searchstring
                txtRapid.Text = .Rapid
                txtLinear.Text = .Linear
                txtCCarc.Text = .CCArc
                txtCWarc.Text = .CWArc
                txtAbs.Text = .Absolute
                txtInc.Text = .Incremental
                txtXYplane.Text = .XYplane
                txtXZplane.Text = .XZplane
                txtYZplane.Text = .YZplane
                txtCompLeft.Text = .CompLeft
                txtCompRight.Text = .CompRight
                txtCompCancel.Text = .CompCancel

                txtViewShift_0.Text = .ViewShift(0).ToString("#0.0#", System.Globalization.NumberFormatInfo.InvariantInfo)
                txtViewShift_1.Text = .ViewShift(1).ToString("#0.0#", System.Globalization.NumberFormatInfo.InvariantInfo)
                txtViewShift_2.Text = .ViewShift(2).ToString("#0.0#", System.Globalization.NumberFormatInfo.InvariantInfo)

                Me.MG_Viewer1.Pitch = .ViewAngles(0)
                Me.MG_Viewer1.Roll = .ViewAngles(1)
                Me.MG_Viewer1.Yaw = .ViewAngles(2)
                chkAbsCenter.Checked = .AbsArcCenter

                For n As Integer = 0 To .Drills.Length - 1 'Get drill cycles
                    Me.tabDrilling.Controls("txtDrills_" & n).Text = .Drills(n)
                Next n
                txtDrillRapid.Text = .DrillRapid
                txtDrillReturnInitialPln.Text = .ReturnLevel(0)
                txtDrillReturnRapidPln.Text = .ReturnLevel(1)

                cboRotPrecision.SelectedIndex = .RotPrecision - 1
                txtRotAxis.Text = .Rotary
                cboRotAxis.SelectedIndex = .RotaryAxis
                optRotateType1.Checked = (.RotaryType = RotaryMotionType.BMC)
                optRotateType2.Checked = (.RotaryType = RotaryMotionType.CAD)
                chkReverseRot.Checked = (.RotaryDir = RotaryDirection.CCW)
                chkUVW.Checked = .UseUVW
                chkInvertArcCenterValues.Checked = .InvertArcCenterValues


                'Home
                txtToolChange.Text = .ToolChange
                txtReturnHome.Text = .HomeCommand
                txtHomeXAddress.Text = .HomeAddresses(0)
                txtHomeYAddress.Text = .HomeAddresses(1)
                txtHomeZAddress.Text = .HomeAddresses(2)
                txtHomeXValue.Text = .HomeValues(0).ToString("###0.0####")
                txtHomeYValue.Text = .HomeValues(1).ToString("###0.0####")
                txtHomeZValue.Text = .HomeValues(2).ToString("###0.0####")

                txtMaxX.Text = .Limits(0).ToString("###0.0####")
                txtMinX.Text = .Limits(1).ToString("###0.0####")
                txtMaxY.Text = .Limits(2).ToString("###0.0####")
                txtMinY.Text = .Limits(3).ToString("###0.0####")
                txtMaxZ.Text = .Limits(4).ToString("###0.0####")
                txtMinZ.Text = .Limits(5).ToString("###0.0####")
            End With


            DirtySetup = False

        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Private Sub SaveFields(ByVal name As String)
        Dim tagText As String
        If mMachine Is Nothing Then Return

        My.Settings.IgnoreFileWhitespace = chkIgnoreSpaces.Checked

        Try
            For Each tab As TabPage In Me.Tab1.TabPages
                For Each t As Control In tab.Controls
                    If Not t.Tag Is Nothing Then
                        tagText = t.Tag.ToString
                        If tagText.Contains("Required") AndAlso t.Text.Length = 0 Then
                            Tab1.SelectedIndex = CInt(Val(tagText))
                            t.Focus()
                            MsgBox("Field information required", MsgBoxStyle.MsgBoxSetForeground, "Blank Field")
                            Exit For
                        End If
                    End If
                Next
            Next

            With mMachine

                .Name = name
                .MachineUnits = CType(cboUnits.SelectedIndex, MachineUnits)
                .UnitsEnglishAddress = txtUnitsEnglish.Text
                .UnitsMetricAddress = txtUnitsMetric.Text

                .Description = txtDescription.Text.Trim
                .GlobalReplacements = txtGlobalReplacements.Text
                .ProgramId = txtProgramId.Text.Trim
                .Subcall = txtSubcall.Text.Trim
                .SubRepeats = txtSubRepeats.Text.Trim
                .SubReturn = txtReturn.Text.Trim
                .Endmain = txtEndmain.Text.Trim
                .BlockSkip = txtBlockSkip.Text.Trim
                .Comments = txtCommentChars.Text
                .RapidRate = Single.Parse(txtRapidRate.Text, System.Globalization.NumberFormatInfo.InvariantInfo)
                .MaxRpmAddress = txtMaxRpmCode.Text
                .MaxRpmValue = Single.Parse(txtMaxRPMDefault.Text, System.Globalization.NumberFormatInfo.InvariantInfo)
                .DogLegMotion = chkDogLeg.Checked

                If cboPrecision.Text = FORCE_DECIMAL Then
                    .Precision = 0
                Else
                    .Precision = cboPrecision.SelectedIndex + 1
                End If
                .Searchstring = txtSearch.Text.Trim
                .Rapid = txtRapid.Text.Trim
                .Linear = txtLinear.Text.Trim
                .CCArc = txtCCarc.Text.Trim
                .CWArc = txtCWarc.Text.Trim
                .Absolute = txtAbs.Text.Trim
                .Incremental = txtInc.Text.Trim

                .CompLeft = txtCompLeft.Text
                .CompRight = txtCompRight.Text
                .CompCancel = txtCompCancel.Text

                .XYplane = txtXYplane.Text.Trim
                .XZplane = txtXZplane.Text.Trim
                .YZplane = txtYZplane.Text.Trim

                .RotPrecision = cboRotPrecision.SelectedIndex + 1
                .FeedPrecision = cboFeedPrecision.SelectedIndex + -4

                .Rotary = txtRotAxis.Text.Trim
                .RotaryAxis = DirectCast(cboRotAxis.SelectedIndex, Axis)
                .RotaryType = DirectCast(CInt(Me.optRotateType1.Checked), RotaryMotionType)
                .FeedModeMin = txtFeedModeMin.Text
                .FeedModeRev = txtFeedModeRev.Text
                .SpeedModeRPM = txtSpeedModeRPM.Text
                .SpeedModeSFM = txtSpeedModeSFM.Text

                Select Case chkReverseRot.CheckState
                    Case CheckState.Unchecked 'unchecked
                        .RotaryDir = DirectCast(1, RotaryDirection)
                    Case CheckState.Checked
                        .RotaryDir = DirectCast(-1, RotaryDirection)
                End Select

                .ViewShift(0) = Single.Parse(txtViewShift_0.Text, System.Globalization.NumberFormatInfo.InvariantInfo)
                .ViewShift(1) = Single.Parse(txtViewShift_1.Text, System.Globalization.NumberFormatInfo.InvariantInfo)
                .ViewShift(2) = Single.Parse(txtViewShift_2.Text, System.Globalization.NumberFormatInfo.InvariantInfo)

                .ViewAngles(0) = Me.MG_Viewer1.Pitch
                .ViewAngles(1) = Me.MG_Viewer1.Roll
                .ViewAngles(2) = Me.MG_Viewer1.Yaw

                .AbsArcCenter = chkAbsCenter.Checked 'store the arc center checkbox

                For n As Integer = 0 To .Drills.Length - 1 'Set drill cycles
                    .Drills(n) = Me.tabDrilling.Controls("txtDrills_" & n).Text.Trim
                Next n
                .DrillRapid = txtDrillRapid.Text
                .ReturnLevel(0) = Me.txtDrillReturnInitialPln.Text.Trim
                .ReturnLevel(1) = Me.txtDrillReturnRapidPln.Text.Trim

                If optMachineType1.Checked Then
                    .MachineType = MachineType.LATHEDIA
                ElseIf optMachineType2.Checked Then
                    .MachineType = MachineType.LATHERAD
                ElseIf optMachineType3.Checked Then
                    .MachineType = MachineType.MILL
                End If

                If Me.optRotateType1.Checked Then
                    .RotaryType = RotaryMotionType.BMC
                ElseIf optRotateType2.Checked Then
                    .RotaryType = RotaryMotionType.CAD
                End If

                If Me.chkReverseRot.Checked Then
                    .RotaryDir = RotaryDirection.CCW
                Else
                    .RotaryDir = RotaryDirection.CW
                End If

                .UseUVW = Me.chkUVW.Checked
                .InvertArcCenterValues = chkInvertArcCenterValues.Checked

                'Home
                .ToolChange = txtToolChange.Text
                .HomeCommand = txtReturnHome.Text
                .HomeAddresses(0) = txtHomeXAddress.Text
                .HomeAddresses(1) = txtHomeYAddress.Text
                .HomeAddresses(2) = txtHomeZAddress.Text
                .HomeValues(0) = Single.Parse(txtHomeXValue.Text, Globalization.NumberFormatInfo.InvariantInfo)
                .HomeValues(1) = Single.Parse(txtHomeYValue.Text, Globalization.NumberFormatInfo.InvariantInfo)
                .HomeValues(2) = Single.Parse(txtHomeZValue.Text, Globalization.NumberFormatInfo.InvariantInfo)

                .Limits(0) = Single.Parse(txtMaxX.Text, Globalization.NumberFormatInfo.InvariantInfo)
                .Limits(1) = Single.Parse(txtMinX.Text, Globalization.NumberFormatInfo.InvariantInfo)
                .Limits(2) = Single.Parse(txtMaxY.Text, Globalization.NumberFormatInfo.InvariantInfo)
                .Limits(3) = Single.Parse(txtMinY.Text, Globalization.NumberFormatInfo.InvariantInfo)
                .Limits(4) = Single.Parse(txtMaxZ.Text, Globalization.NumberFormatInfo.InvariantInfo)
                .Limits(5) = Single.Parse(txtMinZ.Text, Globalization.NumberFormatInfo.InvariantInfo)

                mSetup.SaveMachine(mMachine)
            End With

        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Private Sub ValidateKeys(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubRepeats.KeyPress, txtSubcall.KeyPress, txtReturn.KeyPress, txtProgramId.KeyPress, txtEndmain.KeyPress, txtBlockSkip.KeyPress, txtYZplane.KeyPress, txtXZplane.KeyPress, txtXYplane.KeyPress, txtRapid.KeyPress, txtLinear.KeyPress, txtInc.KeyPress, txtDrills_9.KeyPress, txtDrills_8.KeyPress, txtDrills_7.KeyPress, txtDrills_6.KeyPress, txtDrills_5.KeyPress, txtDrills_4.KeyPress, txtDrills_3.KeyPress, txtDrills_2.KeyPress, txtDrills_10.KeyPress, txtDrills_1.KeyPress, txtDrills_0.KeyPress, txtDrillReturnRapidPln.KeyPress, txtDrillReturnInitialPln.KeyPress, txtDrillRapid.KeyPress, txtCWarc.KeyPress, txtCCarc.KeyPress, txtAbs.KeyPress, txtCompLeft.KeyPress, txtCompRight.KeyPress, txtCompCancel.KeyPress, txtReturnHome.KeyPress, txtToolChange.KeyPress, txtUnitsMetric.KeyPress, txtUnitsEnglish.KeyPress
        Dim ret As Boolean = " ".Contains(e.KeyChar)
        e.Handled = ret
        If Not ret Then
            DirtySetup = True
        End If
    End Sub

    Private Sub ValidateSingleAddress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHomeZAddress.KeyPress, txtHomeYAddress.KeyPress, txtHomeXAddress.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
        Dim KeyAscii As Integer = AscW(e.KeyChar)
        If KeyAscii > 64 AndAlso KeyAscii < 91 OrElse KeyAscii = 127 OrElse KeyAscii = 8 Then 'number or backspace
        Else
            KeyAscii = 0
        End If
        e.KeyChar = ChrW(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If Not e.Handled Then
            DirtySetup = True
        End If
    End Sub


    Private Sub ValidateNumberValue(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtViewShift_2.KeyPress, txtViewShift_1.KeyPress, txtViewShift_0.KeyPress, txtHomeZValue.KeyPress, txtHomeYValue.KeyPress, txtHomeXValue.KeyPress, txtMaxX.KeyPress, txtMinX.KeyPress, txtMaxY.KeyPress, txtMinY.KeyPress, txtMaxZ.KeyPress, txtMinZ.KeyPress, txtPrintScale.KeyPress

        Dim KeyAscii As Integer = AscW(e.KeyChar)
        If KeyAscii > 47 AndAlso KeyAscii < 58 OrElse KeyAscii = 8 OrElse KeyAscii = 45 OrElse KeyAscii = 46 OrElse KeyAscii = 127 Then 'number or backspace
        Else
            KeyAscii = 0
        End If
        e.KeyChar = ChrW(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If Not e.Handled Then
            DirtySetup = True
        End If
    End Sub

    Private Sub Logger_Status(ByVal msg As String) Handles mLog.Status
        Status.Text = msg
    End Sub

    Private Sub optMachineType1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMachineType3.CheckedChanged, optMachineType2.CheckedChanged, optMachineType1.CheckedChanged
        DirtySetup = True
    End Sub

    Private Sub SetViewOrient(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLatheView.Click, btnIsoView.Click, btnSideView.Click, btnFrontView.Click, btnTopView.Click
        With Me.MG_Viewer1
            Select Case CInt(DirectCast(sender, Button).Tag)
                Case 0 'Defaults
                    .Pitch = mMachine.ViewAngles(0)
                    .Roll = mMachine.ViewAngles(1)
                    .Yaw = mMachine.ViewAngles(2)
                Case 1
                    .Pitch = 0.0F
                    .Roll = 0.0F
                    .Yaw = 0.0F
                Case 2 'front
                    .Pitch = 270.0F
                    .Roll = 0.0F
                    .Yaw = 360.0F

                Case 3 'side
                    .Pitch = 270.0F
                    .Roll = 0.0F
                    .Yaw = 270.0F
                Case 4 'iso
                    .Pitch = 315.0F
                    .Roll = 0.0F
                    .Yaw = 315.0F

                Case 5 'lathe
                    .Pitch = 0.0F
                    .Roll = 90.0F
                    .Yaw = 90.0F
            End Select
            .Redraw(False)
        End With
        DirtySetup = True
    End Sub

    Private Sub MakeDirty(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged, txtDescription.TextChanged, txtSubRepeats.TextChanged, txtSubcall.TextChanged, txtReturn.TextChanged, txtProgramId.TextChanged, txtEndmain.TextChanged, txtBlockSkip.TextChanged, txtYZplane.TextChanged, txtXZplane.TextChanged, txtXYplane.TextChanged, txtViewShift_2.TextChanged, txtViewShift_1.TextChanged, txtViewShift_0.TextChanged, txtRotAxis.TextChanged, txtRapid.TextChanged, txtLinear.TextChanged, txtInc.TextChanged, txtDrills_9.TextChanged, txtDrills_8.TextChanged, txtDrills_7.TextChanged, txtDrills_6.TextChanged, txtDrills_5.TextChanged, txtDrills_4.TextChanged, txtDrills_3.TextChanged, txtDrills_2.TextChanged, txtDrills_10.TextChanged, txtDrills_1.TextChanged, txtDrills_0.TextChanged, txtDrillReturnRapidPln.TextChanged, txtDrillReturnInitialPln.TextChanged, txtDrillRapid.TextChanged, txtCWarc.TextChanged, txtCCarc.TextChanged, txtAbs.TextChanged, txtCompRight.TextChanged, txtCompLeft.TextChanged, txtCompCancel.TextChanged, txtGlobalReplacements.TextChanged, txtHomeZValue.TextChanged, txtHomeYValue.TextChanged, txtHomeXValue.TextChanged, txtReturnHome.TextChanged, txtHomeZAddress.TextChanged, txtHomeYAddress.TextChanged, txtHomeXAddress.TextChanged, txtToolChange.TextChanged, txtRapidRate.TextChanged, txtFeedModeRev.TextChanged, txtFeedModeMin.TextChanged, txtMaxRPMDefault.TextChanged, txtMaxRpmCode.TextChanged, txtSpeedModeSFM.TextChanged, txtSpeedModeRPM.TextChanged, txtUnitsMetric.TextChanged, txtUnitsEnglish.TextChanged, txtMaxY.TextChanged, txtMinY.TextChanged, txtMinX.TextChanged, txtMaxZ.TextChanged, txtMinz.TextChanged, txtMaxX.TextChanged
        DirtySetup = True
    End Sub

    Private Sub VScroll1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VScroll1.ValueChanged
        With Me.MG_Viewer1
            If Me.optX.Checked Then 'X
                .Pitch = VScroll1.Value
            ElseIf optY.Checked Then
                .Roll = VScroll1.Value
            ElseIf optZ.Checked Then
                .Yaw = VScroll1.Value
            End If
            .Redraw(False)
        End With
        DirtySetup = True
    End Sub

    Private Sub mSetup_MachineActivated(ByVal m As clsMachine) Handles mSetup.MachineActivated
        mMachine = mSetup.Machine
        cboMachines.SelectedIndex = cboMachines.FindStringExact(m.Name)
    End Sub

    Private Sub mSetup_MachineAdded(ByVal name As String) Handles mSetup.MachineAdded
        cboMachines.Items.Add(name)
    End Sub

    Private Sub mSetup_MachineDeleted(ByVal name As String) Handles mSetup.MachineDeleted
        Try
            cboMachines.Items.RemoveAt(cboMachines.FindStringExact(name))
            Me.cboMachines.SelectedIndex = 0
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub mSetup_MachinesCleared() Handles mSetup.MachinesCleared
        cboMachines.Items.Clear()
    End Sub

    Private Sub optRotateType1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRotateType1.CheckedChanged, optRotateType2.CheckedChanged
        DirtySetup = True
    End Sub

    Private Sub tabView_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tabView.Paint
        MG_Viewer1.Redraw(False)
    End Sub

    Private Sub txtRapidRate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRapidRate.KeyPress, txtMaxRPMDefault.KeyPress
        Dim ret As Boolean = Not "1234567890.".Contains(e.KeyChar)
        e.Handled = ret
        If Not ret Then
            DirtySetup = True
        End If
    End Sub

    Private Sub pbToolColors_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbToolColors.Paint
        Dim rect As New Rectangle(0, 0, 16, 32)
        Try
            Using br As New SolidBrush(Color.Black)
                For r As Integer = 0 To 15
                    br.Color = System.Drawing.Color.FromArgb(CInt(My.Settings.ToolColors(r)))
                    rect.X = r * 16
                    e.Graphics.FillRectangle(br, rect)
                    e.Graphics.DrawRectangle(Pens.Black, rect)
                    e.Graphics.DrawString(r.ToString, Me.Font, Brushes.Black, rect.X + 1, rect.Y + 1)
                Next
                rect.Y = 32
                For r As Integer = 0 To 15
                    br.Color = System.Drawing.Color.FromArgb(CInt(My.Settings.ToolColors(r + 16)))
                    rect.X = r * 16
                    e.Graphics.FillRectangle(br, rect)
                    e.Graphics.DrawRectangle(Pens.Black, rect)
                    e.Graphics.DrawString((r + 16).ToString, Me.Font, Brushes.Black, rect.X + 1, rect.Y + 1)
                Next
            End Using
            e.Graphics.DrawRectangle(Pens.Black, mSelToolClrRect)
        Catch
        End Try

    End Sub

    Private Sub pbColorPicker2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbColorPicker2.MouseDown
        Try
            'Me.cboColor.GetKnownColor(lblColorSample.BackColor, 0.5)
            If mToolIndex >= 0 Then
                My.Settings.ToolColors(mToolIndex) = lblColorSample.BackColor.ToArgb.ToString
                pbToolColors.Invalidate()
            End If
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub pbColorPicker2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbColorPicker2.MouseMove
        Try
            Using myBitmap As New Bitmap(pbColorPicker2.Image)
                Dim c As Color = myBitmap.GetPixel(e.X, e.Y)
                lblColorSample.BackColor = c
            End Using
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub pbToolColors_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbToolColors.MouseDown
        Dim col As Integer = 0
        Dim row As Integer = 0
        Try
            row = e.Y \ 32
            col = e.X \ 16
            mToolIndex = (row * 16) + col
            mSelToolClrRect.X = col * 16
            mSelToolClrRect.Y = row * 32
            mSelToolClrRect.Width = 16
            mSelToolClrRect.Height = 32
            mSelToolClrRect.Inflate(-1, -1)
            pbToolColors.Invalidate()
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub cboColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColor.SelectedIndexChanged
        Try
            lblColorSample.BackColor = cboColor.SelectedColor
            If mToolIndex > -1 Then
                My.Settings.ToolColors(mToolIndex) = lblColorSample.BackColor.ToArgb.ToString
                pbToolColors.Invalidate()
            End If
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub

    Private Sub SetViewerFont(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSize.SelectedIndexChanged, cboFont.SelectedIndexChanged
        Try
            My.Settings.ViewerOverlayFont = GetOverlayFont()
            MG_BasicViewer.OverlayFont = My.Settings.ViewerOverlayFont
            Me.MG_Viewer1.Refresh()
            Me.MG_Viewer1.DrawTextOverlay("Sample")
        Catch ex As Exception
            mLog.LogError(ex)
        End Try

    End Sub

    Private Sub MG_Viewer1_OnViewOrientationChanged(ByVal pitch As System.Single, ByVal roll As System.Single, ByVal yaw As System.Single) Handles MG_Viewer1.OnViewOrientationChanged
        optX.Text = "X=" & pitch.ToString("0.0")
        optY.Text = "Y=" & roll.ToString("0.0")
        optZ.Text = "Z=" & yaw.ToString("0.0")
    End Sub

    Private Sub chkShowExtraOverlayInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowExtraOverlayInfo.CheckedChanged
        My.Settings.ViewerShowExtraOverlayDetails = chkShowExtraOverlayInfo.Checked
        MG_Viewer1.DrawExtraOverlayInfo = My.Settings.ViewerShowExtraOverlayDetails
    End Sub

    Private Sub chkReverseMouseWheel_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkReverseMouseWheel.CheckedChanged
        My.Settings.ReverseMouseWheel = chkReverseMouseWheel.Checked
        MG_Viewer1.ReverseMouseWheel = My.Settings.ReverseMouseWheel
    End Sub

    Private Sub chkDogLeg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDogLeg.CheckedChanged
        DirtySetup = True
    End Sub

    Private Sub rdoPrintScaled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPrintScaled.CheckedChanged
        txtPrintScale.Enabled = rdoPrintScaled.Checked
    End Sub

    Public Sub EnsureFormIsOnScreen(ByVal f As Form)
        Dim isOnOneScreen As Boolean = False
        For Each s As Screen In Screen.AllScreens()
            If s.Bounds.Contains(f.Left + 100, f.Top + 100) Then
                isOnOneScreen = True
            End If
        Next
        If Not isOnOneScreen Then
            f.Location = New Point(10, 10)
        End If
    End Sub

    Private Sub btnLimitsColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimitsColor.Click
        Try
            With Me.ColorDialog1
                .AllowFullOpen = True
                .CustomColors = New Integer() {System.Drawing.ColorTranslator.ToWin32(My.Settings.ViewerLimitsColor)}

                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    MG_Viewer1.LimitsColor = .Color
                    My.Settings.ViewerLimitsColor = .Color
                End If
            End With
        Catch ex As Exception
            mLog.LogError(ex)
        End Try
    End Sub


End Class