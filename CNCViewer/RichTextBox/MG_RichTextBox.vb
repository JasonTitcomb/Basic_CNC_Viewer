Imports System.Collections.Generic
Imports System.Drawing
Public Class MG_RichTextBox

#Region "Win32"
    Private Const WM_USER As Integer = &H400S
    Private Const EM_SETTEXTMODE As Integer = (WM_USER + 89)
    Private Const EM_LINESCROLL As Integer = &HB6S
    Private Const EM_GETLINECOUNT As Integer = &HBAS
    Private Const EM_LINELENGTH As Integer = &HC1S
    Private Const EM_LINEINDEX As Integer = &HBBS
    Private Const EM_GETFIRSTVISIBLELINE As Integer = &HCES

    Private Const EM_GETEVENTMASK As Integer = (WM_USER + 59)
    Private Const EM_SETEVENTMASK As Integer = (WM_USER + 69)
    Private Const WM_SETREDRAW As Integer = 11
    Private Const WM_PAINT As Integer = &HFS
    Private Const ENM_NONE As Integer = &H0S
    Private Const EM_SETUNDOLIMIT As Integer = &H452
    Const EM_GETSCROLLPOS As Integer = WM_USER + 221

    Private Declare Auto Function SendMessage Lib "user32.dll" (
            ByVal hWnd As IntPtr,
            ByVal msg As Integer,
            ByVal wParam As Integer,
            ByVal lParam As IntPtr) As IntPtr

    Private Declare Auto Function SendScrollPosMessage _
                    Lib "user32.dll" Alias "SendMessage" (
                    ByVal hWnd As IntPtr,
                    ByVal Msg As Integer,
                    ByVal wParam As IntPtr,
                    ByRef lParam As Point) As Integer

#End Region
    Public TrapUndo As Boolean 'flag to indicate whether actions should be trapped
    Private UndoStack As New List(Of UndoData) 'collection of undo elements
    Private RedoStack As New List(Of UndoData) 'collection of redo elements
    Private mUndoFiles As New Collections.Specialized.StringCollection 'collection of redo elements
    Private mMaxUndo As Integer
    Private curElement As UndoData
    Private mSelectionBeforeAction As String
    Private bUndoingOrRedoing As Boolean
    Private mApplying As Boolean
    Private mGUID As String
    Private undoDir As String
    Private mSavedZoomFactor As Single
    Private mSavedSelStart As Integer
    Private mSavedSelLen As Integer
    Private mCursorPos As Integer
    Private Shared mClipRtf As String
    Private Shared mClipTxt As String
    Private Const NULLSTRING As String = ""
    Private mClientRectangle As Rectangle
    Private mClientTopPoint As New Point
    Private mClientBottomPoint As New Point
    Private mHighlightRect As Rectangle
    Private mMultiLineRangeBox As New Rectangle
    Private mMultiRangeBoxes As New List(Of Rectangle)
    Private mToolTipRect As Rectangle
    Private mMarkerRect As Rectangle

    Private mLineCountDirty As Boolean = True
    Private mLineCount As Integer = 0
    Private mRegEx As New System.Text.RegularExpressions.Regex(My.Resources.datRegexNcWords)
    Private mWatermarkFont As New Font(System.Drawing.FontFamily.GenericMonospace, 46)
    Private mTopLine As Integer
    Private mFirstCharIndexFromTopLine As Integer
    Private mScrollPoint As New Point
    Private mLastScrollPosY As Long
    Private mLineHeightPixels As Long

    Private Class mPage
        Public Invalid As Boolean
        Public Index As Integer
        Public StartRange As Integer
        Public EndRange As Integer
    End Class

    Public Enum PageChange
        Up
        Down
        Home
        [End]
    End Enum

    Private mFormattedPages As New List(Of mPage)
    Public Event AfterPageChange(ByVal sender As Object, ByVal p As PageChange)
    Public Event OnVisibleTextChanged()
    Public Event AfterVScroll()
    Public Event OnVScrollPosChanged(ByVal vPos As Long, ByVal vInc As Long)
    Public Event AfterUndoOrRedo(ByVal haveSelection As Boolean)
    Public Event OnApply()
    Public Event OnUndoRedoPush(ByVal p As UndoType, ByVal indexAdded As Integer, ByRef ud As UndoData)
    Public Event OnUndoRedoPop(ByVal p As UndoType, ByVal indexRemoved As Integer)
    Public Event OnUndoRedoClear(ByVal p As UndoType)
    Public Event OnIdleTime()
    Public Event CharCountChanged(ByVal position As Integer, ByVal lineCountChange As Integer)
    Public Event OnHighlightLine(ByVal sender As Object, ByVal pos As Integer)

    Private Structure typDragStatus
        Dim StartedByMe As Boolean
        Dim InProgress As Boolean
        Dim SourceRTB As MG_RichTextBox
        Dim SelRtf As String 'RTF text
        Dim SelText As String 'ASCII text
        Dim FromPos As Integer
        Dim ToPos As Integer
        Dim Effect As DragDropEffects
    End Structure
    Shared DragData As typDragStatus

    Public Enum UndoType
        MG_UNDO
        MG_REDO
    End Enum
    Public Enum OpTypes
        MG_OPERATE
        MG_TYPING
        MG_DELETE
        MG_CUT
        MG_PASTE
        MG_REPLACE
        MG_BACKSPACE
        MG_DRAG_MOVE
        MG_DRAG_COPY
        MG_DRAG_DROP
    End Enum

    Public Structure UndoData
        Public ChangeType As OpTypes
        Public OriginalSelStart As Integer 'Start position in text box
        Public OriginalSelLength As Integer 'Start length of the selecteed text
        Public FinalDropPosition As Integer
        Public SelRtf As String 'The selection that was replaced or deleted
        Public SelText As String 'The selection that was replaced or deleted
        Public Description As String 'The fragment to show in the undo list
        Public TextLen As Integer 'The length of the text added.
        Public Text As String 'Text that was added.
        Public Rtf As String 'Rtf text that was added from clipboard.
        Public FromPos As Integer 'New location in text box
        Public ResumeSelection As Boolean 'Do we return the selection state?
        'Public TotalTextLen As Long 'Ensure accuracy
        Public LineCountDelta As Integer 'The number of lines
        Public SavedToFile As Boolean 'Set when the entire file is saved to disk
    End Structure

    Protected Overrides Sub OnSelectionChanged(ByVal e As System.EventArgs)
        If Not Me.Locked Then
            MyBase.OnSelectionChanged(e)
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        If Not Me.Locked Then
            MyBase.OnTextChanged(e)
        End If
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not Me.Locked Then
            MyBase.OnKeyDown(e)
        End If
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Me.Locked Then
            MyBase.OnKeyPress(e)
        End If
    End Sub

    Protected Overrides Sub OnVScroll(ByVal e As System.EventArgs)
        If Not Me.Locked Then
            MyBase.OnVScroll(e)
        End If
    End Sub

    Public Sub New()
        MyBase.New()
        'This call is required by the Component Designer.
        InitializeComponent()
        'AllowDrop = False
        mGUID = System.Guid.NewGuid().ToString
        UndoDataFolder = IO.Path.Combine(My.Application.Info.DirectoryPath, "UndoData\")
        TrapUndo = True
        mMaxUndo = 100
        AllowApply = True
        SendMessage(Handle, EM_SETUNDOLIMIT, 0, IntPtr.Zero)
        SendScrollPosMessage(Handle, EM_GETSCROLLPOS, IntPtr.Zero, mScrollPoint)
        mLineHeightPixels = CInt((Font.Height * ZoomFactor))
        mLineCountDirty = True
    End Sub

    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property GUID() As String
        Get
            Return mGUID
        End Get
    End Property

    Private mAllowApply As Boolean
    Public Property AllowApply() As Boolean
        Get
            Return mAllowApply
        End Get
        Set(ByVal value As Boolean)
            mAllowApply = value
        End Set
    End Property

    Private mOnIdleDelay As Integer
    Public Property OnIdleDelay() As Integer
        Get
            Return mOnIdleDelay
        End Get
        Set(ByVal value As Integer)
            mOnIdleDelay = value
            Try
                If mOnIdleDelay > 0 Then
                    IdleTime.Interval = mOnIdleDelay
                End If
            Catch
            End Try
        End Set
    End Property

    Private mEnableOnVisibleTextChangedEvent As Boolean
    Public Property EnableOnVisibleTextChangedEvent() As Boolean
        Get
            Return mEnableOnVisibleTextChangedEvent
        End Get
        Set(ByVal value As Boolean)
            mEnableOnVisibleTextChangedEvent = value
        End Set
    End Property

    Private mOnVisibleTextChangedDelay As Integer
    Public Property OnVisibleTextChangedDelay() As Integer
        Get
            Return mOnVisibleTextChangedDelay
        End Get
        Set(ByVal value As Integer)
            mOnVisibleTextChangedDelay = value
            Try
                If mOnVisibleTextChangedDelay > 0 Then
                    TimerVisibleTextChanged.Interval = mOnVisibleTextChangedDelay
                End If
            Catch
            End Try
        End Set
    End Property

    Private Shared mOverstrikeMode As Boolean
    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property OverstrikeMode() As Boolean
        Get
            Return mOverstrikeMode
        End Get
    End Property


    '<System.ComponentModel.Description("The folder location to store undo files.")> _
    <System.ComponentModel.Browsable(False)>
    Public Property UndoDataFolder() As String
        Get
            Return undoDir
        End Get
        Set(ByVal value As String)
            If value.Length > 0 Then
                undoDir = value
            End If
        End Set
    End Property

    Private mTextRangeBoxColor As Color = Color.FromArgb(180, Not BackColor.R, Not BackColor.G, Not BackColor.B)
    Private mTextRangeBoxColorProp As Color = Color.Transparent
    <System.ComponentModel.Browsable(False)>
    Public Property TextRangeBoxColor() As Color
        Get
            Return mTextRangeBoxColor
        End Get
        Set(ByVal value As Color)
            mTextRangeBoxColorProp = value
            mTextRangeBoxColor = Color.FromArgb(180, value.R, value.G, value.B)
            If mTextRangeBoxColorProp = Color.Transparent Then
                mTextRangeBoxColor = Color.FromArgb(180, Not BackColor.R, Not BackColor.G, Not BackColor.B)
            End If
        End Set
    End Property

    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property LineCount() As Integer
        Get
            If mLineCountDirty Then
                mLineCount = SendMessage(Me.Handle, EM_GETLINECOUNT, 0, IntPtr.Zero).ToInt32 'MyBase.Lines.Length ' 
                If mLineCount > 0 Then mLineCountDirty = False
            End If
            Return mLineCount
        End Get
    End Property

    <System.ComponentModel.Browsable(False), System.ComponentModel.DefaultValue(True)>
    Public Property LineCountDirty() As Boolean
        Get
            Return mLineCountDirty
        End Get
        Set(ByVal value As Boolean)
            mLineCountDirty = value
        End Set
    End Property

    Private Shared mForceUpperCase As Boolean
    Public Property ForceUpperCase() As Boolean
        Get
            Return mForceUpperCase
        End Get
        Set(ByVal value As Boolean)
            mForceUpperCase = value
        End Set
    End Property

    Public Overloads Property RTF() As String
        Get
            Return MyBase.Rtf
        End Get
        Set(ByVal value As String)
            LineCountDirty = True
            MyBase.Rtf = value
        End Set
    End Property

    Public Overloads Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            LineCountDirty = True
            MyBase.Text = value
        End Set
    End Property

#Region "Range Formatting"

    Public Sub GetPaddedRange(ByRef rangeStart As Integer, ByRef rangeEnd As Integer, ByVal extraLines As Integer)
        Dim topLine, bottomLine As Integer
        topLine = FirstVisibleLine - extraLines
        If topLine < 0 Then topLine = 0
        bottomLine = LastVisibleLine + extraLines
        rangeStart = GetFirstCharIndexFromLine(topLine)
        rangeEnd = GetFirstCharIndexFromLine(bottomLine)
        If rangeEnd = -1 Then rangeEnd = TextLength
    End Sub

    Public Sub GetVisibleRange(ByRef rangeStart As Integer, ByRef rangeEnd As Integer)
        Dim topLine, bottomLine As Integer
        topLine = FirstVisibleLine
        bottomLine = LastVisibleLine
        rangeStart = GetFirstCharIndexFromLine(topLine)
        rangeEnd = GetFirstCharIndexFromLine(bottomLine)
    End Sub

    Public Sub GetRangeByLines(ByVal topLine As Integer, ByVal bottomLine As Integer, ByRef rangeStart As Integer, ByRef rangeEnd As Integer)
        rangeStart = GetFirstCharIndexFromLine(topLine)
        rangeEnd = GetFirstCharIndexFromLine(bottomLine)
    End Sub

    Public Sub AddPaddedRange(ByVal rangeStart As Integer, ByVal rangeEnd As Integer)
        Dim p As New mPage
        With p
            .Index = mFormattedPages.Count
            .StartRange = rangeStart
            .EndRange = rangeEnd
            .Invalid = False
        End With
        mFormattedPages.Add(p)
    End Sub

    Public Sub InvalidateAllPages()
        mFormattedPages.Clear()
    End Sub

    Public Sub InvalidatePage(ByVal rangeStart As Integer, ByVal rangeEnd As Integer)
        For Each p As mPage In mFormattedPages
            If rangeStart >= p.StartRange OrElse rangeEnd <= p.EndRange Then
                p.Invalid = True
            End If
        Next
    End Sub

    'See if the visible page is within a formatted range
    Public Function IsRangeFormatted(ByVal rangeStart As Integer, ByVal rangeEnd As Integer) As Boolean
        For Each p As mPage In mFormattedPages
            If rangeStart >= p.StartRange AndAlso rangeEnd <= p.EndRange Then
                Return (Not p.Invalid)
            End If
        Next
        Return False
    End Function

#End Region

    Public Sub SelectLine(ByVal line As Integer)
        Dim lineLen As Integer
        Dim lineStart As Integer
        lineStart = Me.GetFirstCharIndexOfCurrentLine()
        lineLen = Me.GetLineLength(lineStart) + 1
        SelectionStart = lineStart
        SelectionLength = lineLen
    End Sub

    Public Sub SelectCurrrentLine(ByRef selRtf As String, ByRef seltext As String)
        Dim lineLen As Integer
        Dim lineStart As Integer
        'Dim ln As Integer
        'ln = GetLineFromCharIndex(SelectionStart)
        lineStart = Me.GetFirstCharIndexOfCurrentLine()
        lineLen = Me.GetLineLength(SelectionStart) + 1
        SelectionStart = lineStart
        SelectionLength = lineLen
        selRtf = SelectedRtf
        seltext = SelectedText
    End Sub

    Public Sub SelectCurrrentLineToEnd(ByRef selRtf As String, ByRef seltext As String)
        Dim lineEnd As Integer
        Dim lineStart As Integer
        Dim CurPos As Integer
        'Dim ln As Integer
        'ln = GetLineFromCharIndex(SelectionStart)
        lineStart = Me.GetFirstCharIndexOfCurrentLine()
        lineEnd = lineStart + Me.GetLineLength(SelectionStart)
        CurPos = SelectionStart

        'SelectionStart = LineStart
        SelectionLength = lineEnd - SelectionStart

        selRtf = SelectedRtf
        seltext = SelectedText

    End Sub

    Private mFirstVisibleLine As Integer = 0
    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property FirstVisibleLine() As Integer
        Get
            'If Not Locked Then
            'Debug.Print("EM_GETFIRSTVISIBLELINE")
            mFirstVisibleLine = SendMessage(Handle, EM_GETFIRSTVISIBLELINE, 0, IntPtr.Zero).ToInt32
            'End If
            Return mFirstVisibleLine
        End Get
    End Property

    Public Sub SetFirstVisibleLine(ByVal line As Integer)
        Dim curTopLine As Integer = FirstVisibleLine
        If line <> curTopLine Then
            'Scroll the screen to the stored top line
            For ln As Integer = 0 To 500
                If line = curTopLine Then Exit For
                Dim pInt As New IntPtr(line - curTopLine)
                SendMessage(Handle, EM_LINESCROLL, 0, pInt)
                curTopLine = FirstVisibleLine
            Next
        End If
    End Sub

    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property FirstVisibleLineChar() As Integer
        Get
            Return GetFirstCharIndexFromLine(FirstVisibleLine)
        End Get
    End Property
    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property LastVisibleLine() As Integer
        Get
            Dim ret As Integer = CInt(FirstVisibleLine + (Bounds.Height / mLineHeightPixels))
            ret = Math.Min(ret, LineCount)
            Return Math.Min(ret, LineCount)
        End Get
    End Property

    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property LastVisibleLineChar() As Integer
        Get
            mClientBottomPoint.X = 0
            mClientBottomPoint.Y = mClientRectangle.Bottom - mClientRectangle.Top
            Return GetCharIndexFromPosition(mClientBottomPoint)
        End Get
    End Property

    Public Function GetLineLength(ByVal charIndex As Integer) As Integer
        Dim pInt As New IntPtr(charIndex)
        msg = Message.Create(Handle, EM_LINELENGTH, pInt, IntPtr.Zero)
        Me.DefWndProc(msg)
        Return msg.Result.ToInt32
    End Function

    Private Sub AddToUndoStack(ByVal newText As String, ByRef CommandType As OpTypes)
        Try
            If Not AllowApply Then Return
            If bUndoingOrRedoing Then
                curElement = Nothing
                bUndoingOrRedoing = False
                Exit Sub
            End If
            Lock()
            If RedoStack.Count > 0 Then
                ClearRedo()
            End If

            'Handle Insert and Overstrike mode
            If mOverstrikeMode AndAlso SelectionLength = 0 Then
                SelectionLength = 1
            End If


            'create new undo element
            curElement = New UndoData
            With curElement
                'unformatted text.
                'The rtf control does not do crlf so we need to strip them
                .Text = newText.Replace(vbCrLf, Chr(10))
                .TextLen = .Text.Length
                Select Case CommandType
                    Case OpTypes.MG_DRAG_MOVE
                        .FromPos = DragData.FromPos
                        .Rtf = mClipRtf
                    Case OpTypes.MG_DRAG_COPY
                        .FromPos = DragData.FromPos
                        .Rtf = mClipRtf

                    Case OpTypes.MG_DRAG_DROP
                        'This is a drag from other window.
                        .FromPos = DragData.FromPos
                        .Rtf = mClipRtf
                    'TODO test this
                    'SelectionStart = SelectionStart - .TextLen
                    'SelectionLength = .TextLen

                    Case OpTypes.MG_OPERATE 'Add spaces,remove spaces, replace
                        'Save the file to the undo folder
                        SaveFileForUndoRedo(curElement)
                        .Rtf = newText 'Just a description.
                    Case OpTypes.MG_PASTE, OpTypes.MG_REPLACE
                        .Rtf = mClipRtf
                    Case Else
                        'Add a CRLF to the input
                        If SelectedText.EndsWith(vbCrLf) Then
                            If newText = vbCr Then
                                Exit Sub
                            Else
                                .Text = newText & vbCrLf
                            End If
                        End If
                        .ResumeSelection = True
                End Select

                .ChangeType = CommandType
                SetCommandTypeName(curElement)

                'Store the current selection
                .OriginalSelStart = SelectionStart
                .OriginalSelLength = SelectionLength
                .SelRtf = SelectedRtf
                .SelText = SelectedText

                'Set the delta line count of this action
                Select Case CommandType
                    Case OpTypes.MG_DRAG_MOVE, OpTypes.MG_DRAG_COPY, OpTypes.MG_DRAG_DROP
                        .LineCountDelta = .Text.Split(Chr(10)).Length - 1
                    Case OpTypes.MG_OPERATE 'Add spaces,remove spaces, replace
                        .LineCountDelta = 0
                    Case OpTypes.MG_PASTE, OpTypes.MG_REPLACE
                        .LineCountDelta = (.Text.Split(Chr(10)).Length - 1) - (SelectedText.Split(Chr(10)).Length - 1)
                    Case OpTypes.MG_CUT, OpTypes.MG_DELETE
                        .LineCountDelta = -(.Text.Split(Chr(10)).Length - 1)
                    Case Else 'Typing
                        .LineCountDelta = (.Text.Split(Chr(10)).Length - 1) - (SelectedText.Split(Chr(10)).Length - 1)
                End Select

                'If the limit has been reached then push off the first item
                If UndoStack.Count >= MaxUndo Then
                    If UndoStack(0).ChangeType = OpTypes.MG_OPERATE Then
                        DeleteUndoFile(UndoStack(0).Text)
                    End If
                    UndoStack.RemoveAt(0)
                    RaiseEvent OnUndoRedoPop(UndoType.MG_UNDO, 0)
                End If
                'Carry out the action
                Apply()
                'Add it to the undo stack
                UndoStack.Add(curElement)
                RaiseEvent OnUndoRedoPush(UndoType.MG_UNDO, UndoStack.Count, curElement)
            End With

        Catch
            Locked = False
            ClearUndo()
            Throw
        End Try
        Locked = False

    End Sub

    'Saves the file for undo to a unique name.
    Private Sub SaveFileForUndoRedo(ByRef u As UndoData)
        Dim sFile As String
        Dim sFileToSave As String
        Dim idx As Integer
        Try
            'TODO add status event
            idx = UndoStack.Count
            sFile = undoDir & GUID & idx & "-UNDO.rtf|"
            sFile = sFile & undoDir & GUID & idx & "-REDO.rtf"
            sFileToSave = Split(sFile, "|")(0)
            If My.Computer.FileSystem.FileExists(sFileToSave) = False Then
                SaveFile(sFileToSave, System.Windows.Forms.RichTextBoxStreamType.RichText) 'Save as rich text to a temp file for undo
            End If
            u.Text = sFile
            u.SavedToFile = True
            mUndoFiles.Add(sFileToSave)
        Catch ex As Exception
            u.SavedToFile = False
            Throw
        End Try
    End Sub
    'Delete all the files that got created by this control
    Public Sub CleanUndoFiles()
        For Each f As String In mUndoFiles
            If My.Computer.FileSystem.FileExists(f) Then
                My.Computer.FileSystem.DeleteFile(f)
            End If
        Next
    End Sub

    'Reload the original file
    Private Sub FileRedo(ByRef sFiles As String)
        Dim sRedoFile As String
        Try
            sRedoFile = Split(sFiles, "|")(1)
            If My.Computer.FileSystem.FileExists(sRedoFile) Then
                LoadAndKeepLinePos(sRedoFile, System.Windows.Forms.RichTextBoxStreamType.RichText)
            End If
        Catch
            ClearUndo()
            Throw
        End Try
    End Sub

    'Reload the original file
    Private Sub FileUndo(ByRef sFiles As String)
        Dim sUndoFile As String
        Dim sRedoFile As String
        Try
            sUndoFile = Split(sFiles, "|")(0)
            sRedoFile = Split(sFiles, "|")(1)
            If My.Computer.FileSystem.FileExists(sRedoFile) = False Then
                SaveFile(sRedoFile, System.Windows.Forms.RichTextBoxStreamType.RichText) 'Save as rich text to a temp file for redo
            End If
            LoadAndKeepLinePos(sUndoFile, System.Windows.Forms.RichTextBoxStreamType.RichText)
        Catch
            ClearUndo()
            Throw
        End Try
    End Sub

    Private Sub Apply()
        With curElement

            Select Case .ChangeType
                Case OpTypes.MG_OPERATE 'Add spaces,remove spaces, replace
                    FileRedo((.Text))
                    SelectionStart = .OriginalSelStart
                    SelectionLength = .OriginalSelLength
                'RaiseEvent LineCountChanged(-1, -1)

                Case OpTypes.MG_TYPING
                    SelectionStart = .OriginalSelStart
                    SelectionLength = .OriginalSelLength

                    'CRLF
                    If .Text = vbLf Then
                        SelectedText = vbLf
                        RaiseEvent CharCountChanged(SelectionStart, .LineCountDelta)
                    Else
                        If ForceUpperCase Then
                            SelectedText = .Text.ToUpper()
                        Else
                            SelectedText = .Text
                        End If
                    End If

                Case OpTypes.MG_DELETE, OpTypes.MG_BACKSPACE
                    SelectionStart = .OriginalSelStart
                    SelectionLength = .OriginalSelLength
                    SelectedText = NULLSTRING
                    RaiseEvent CharCountChanged(SelectionStart, .LineCountDelta)

                Case OpTypes.MG_CUT
                    SelectionStart = .OriginalSelStart
                    SelectionLength = .OriginalSelLength

                    'Remove the text
                    SelectedText = NULLSTRING
                    RaiseEvent CharCountChanged(SelectionStart, .LineCountDelta)

                Case OpTypes.MG_DRAG_MOVE
                    'Actually do the drag-move.
                    'Move the cursor to the destination
                    SelectionStart = .OriginalSelStart
                    SelectionLength = 0
                    'Insert the text
                    SelectedRtf = .Rtf
                    RaiseEvent CharCountChanged(.OriginalSelStart, .LineCountDelta)

                    'In this case we remove the original text.'Cut from source

                    'Adjust for the fact that we just inserted some text

                    'If we dragged down.
                    If .OriginalSelStart > .FromPos Then
                        .FinalDropPosition = .OriginalSelStart - .TextLen
                        SelectionStart = .FromPos
                        RaiseEvent CharCountChanged(.FromPos, - .LineCountDelta)
                    Else 'we dragged up
                        .FinalDropPosition = .OriginalSelStart
                        SelectionStart = .FromPos + .TextLen
                        RaiseEvent CharCountChanged(.FromPos + .TextLen, - .LineCountDelta)
                    End If
                    SelectionLength = .TextLen
                    SelectedText = NULLSTRING

                'Restore selection to the drop point.
                Case OpTypes.MG_DRAG_COPY
                    'Actually do the drag-copy.
                    'Move the cursor
                    SelectionStart = .OriginalSelStart
                    SelectionLength = 0
                    'Insert the text
                    SelectedRtf = .Rtf
                    .FinalDropPosition = .OriginalSelStart
                    'Restore selection
                    SelectionStart = .OriginalSelStart
                    SelectionLength = .OriginalSelLength
                    RaiseEvent CharCountChanged(SelectionStart, .LineCountDelta)

                Case OpTypes.MG_DRAG_DROP
                    'Move the cursor
                    SelectionStart = .OriginalSelStart
                    SelectionLength = 0
                    'Insert the text.
                    'If we do not have any real rtf text the rtf will be the same as the text.
                    If .Rtf = .Text Then
                        SelectedText = .Rtf
                    Else
                        SelectedRtf = .Rtf
                    End If

                    .FinalDropPosition = .OriginalSelStart
                    'Restore selection
                    SelectionStart = .OriginalSelStart
                    SelectionLength = .OriginalSelLength
                    RaiseEvent CharCountChanged(SelectionStart, .LineCountDelta)

                Case OpTypes.MG_PASTE, OpTypes.MG_REPLACE
                    'Move the cursor
                    SelectionStart = .OriginalSelStart
                    'Set the selection
                    SelectionLength = .OriginalSelLength

                    'Insert the text
                    If .Rtf.Length > 0 Then
                        SelectedRtf = .Rtf
                    Else
                        If ForceUpperCase Then
                            SelectedText = .Text.ToUpper()
                        Else
                            SelectedText = .Text
                        End If
                    End If
                    RaiseEvent CharCountChanged(SelectionStart, .LineCountDelta)
                    'Restore selection
                    SelectionLength = 0
                    'SelStart = .SelStart + .TextLen
            End Select
            RaiseEvent OnApply()
        End With

    End Sub

    'Deletes all the redo files
    Private Sub DeleteUndoFile(ByRef sFile As String)
        Dim sRedoFile As String = Split(sFile, "|")(1)
        If My.Computer.FileSystem.FileExists(sRedoFile) Then
            My.Computer.FileSystem.DeleteFile(sRedoFile)
        End If
    End Sub

    Public Shadows Sub Undo()
        DoUndo()
    End Sub

    Private Sub DoUndo()
        Try
            If Not AllowApply Then Return
            bUndoingOrRedoing = True
            If UndoStack.Count > 0 Then
                Lock() 'Do not trap any changes
                'Do the reverse of the original action
                curElement = UndoStack.Item(UndoStack.Count - 1)
                With curElement

                    'Add to the redo
                    RedoStack.Add(curElement)
                    RaiseEvent OnUndoRedoPush(UndoType.MG_REDO, RedoStack.Count, curElement)
                    'Remove from the undo
                    UndoStack.RemoveAt(UndoStack.Count - 1)
                    RaiseEvent OnUndoRedoPop(UndoType.MG_UNDO, UndoStack.Count)

                    Select Case .ChangeType
                        Case OpTypes.MG_OPERATE 'Add spaces,remove spaces, replace
                            'Save for redo
                            FileUndo((.Text))
                            'Restore selection status
                            If .ResumeSelection Then
                                SelectionStart = .OriginalSelStart
                                SelectionLength = .OriginalSelLength
                            End If

                        Case OpTypes.MG_TYPING
                            'Remove what was typed and insert original text
                            SelectionStart = .OriginalSelStart
                            If .Text = vbLf Then
                                SelectionLength = 1
                            Else
                                SelectionLength = .TextLen
                            End If

                            If .OriginalSelLength = 0 Then
                                'Just remove the selected text
                                SelectedText = NULLSTRING
                            Else
                                SelectedRtf = .SelRtf
                            End If
                            'Restore selection status
                            If .ResumeSelection Then
                                SelectionStart = .OriginalSelStart
                                SelectionLength = .OriginalSelLength
                            End If
                            RaiseEvent CharCountChanged(SelectionStart, - .LineCountDelta)

                        Case OpTypes.MG_CUT
                            SelectionStart = .OriginalSelStart
                            SelectionLength = 0
                            'CRLF
                            If .TextLen = 1 Then
                                If Asc(.Text) = 13 Then SelectedText = vbCrLf
                            Else
                                SelectedRtf = .SelRtf
                            End If
                            'Restore selection status
                            If .ResumeSelection Then
                                SelectionStart = .OriginalSelStart
                                SelectionLength = .OriginalSelLength
                            End If
                            RaiseEvent CharCountChanged(SelectionStart, - .LineCountDelta)

                        Case OpTypes.MG_DELETE 'Put back what we deleted
                            SelectionStart = .OriginalSelStart
                            SelectionLength = 0
                            'CRLF
                            If .SelText = vbLf Then
                                SelectedText = vbCrLf
                            Else
                                SelectedRtf = .SelRtf
                            End If
                            'CRLF
                            'If .TextLen = 1 Then
                            '    If Asc(.Text) = 13 Then SelectedText = vbCrLf
                            'Else
                            '    SelectedRtf = .SelRtf
                            'End If

                            'Restore selection status
                            If .ResumeSelection Then
                                SelectionStart = .OriginalSelStart
                                SelectionLength = .OriginalSelLength
                            End If
                            RaiseEvent CharCountChanged(SelectionStart, - .LineCountDelta)

                        Case OpTypes.MG_BACKSPACE 'Put back what we deleted
                            SelectionStart = .OriginalSelStart
                            SelectionLength = 0
                            'CRLF
                            If .TextLen = 1 Then
                                If Asc(.Text) = 13 Then SelectedText = vbCrLf
                            Else
                                SelectedRtf = .SelRtf
                            End If
                            'Restore selection status
                            If .ResumeSelection Then
                                SelectionStart = .OriginalSelStart
                                SelectionLength = .OriginalSelLength
                            End If
                            RaiseEvent CharCountChanged(SelectionStart, - .LineCountDelta)

                        Case OpTypes.MG_DRAG_MOVE
                            'Actually undo the drag-move.
                            'Move the cursor to the destination
                            SelectionStart = .FinalDropPosition
                            SelectionLength = .TextLen
                            SelectedText = NULLSTRING
                            RaiseEvent CharCountChanged(.FinalDropPosition, - .LineCountDelta)

                            'In this case we remove the original text.'Cut from source
                            'Adjust for the fact that we just inserted some text
                            SelectionStart = .FromPos
                            SelectionLength = 0
                            'Insert the text
                            SelectedRtf = .Rtf
                            RaiseEvent CharCountChanged(.FromPos, .LineCountDelta)
                        Case OpTypes.MG_DRAG_COPY
                            'Restore original selection
                            SelectionStart = .OriginalSelStart
                            SelectionLength = .TextLen 'The original selection length is 0 so we cannot use it
                            'Cut from destination
                            SelectedText = NULLSTRING
                            'Restore selection
                            SelectionStart = .FromPos
                            SelectionLength = .OriginalSelLength
                            RaiseEvent CharCountChanged(SelectionStart, - .LineCountDelta)

                        Case OpTypes.MG_DRAG_DROP
                            'Restore original selection
                            SelectionStart = .FinalDropPosition
                            SelectionLength = .TextLen
                            SelectedText = NULLSTRING
                            RaiseEvent CharCountChanged(SelectionStart, - .LineCountDelta)
                        'Restore selection
                        '                SelStart = .FromLoc
                        '                SelLength = .SelLength
                        Case OpTypes.MG_PASTE, OpTypes.MG_DRAG_DROP, OpTypes.MG_REPLACE
                            'Select pasted text and restore original text.
                            SelectionStart = .OriginalSelStart
                            SelectionLength = .TextLen

                            'Restore original text
                            SelectedRtf = .SelRtf

                            'Restore selection status
                            If .ResumeSelection Then
                                SelectionStart = .OriginalSelStart
                                SelectionLength = .OriginalSelLength
                            End If
                            RaiseEvent CharCountChanged(SelectionStart, - .LineCountDelta)
                    End Select
                    Locked = False
                    bUndoingOrRedoing = False
                    'If .LineCountDelta <> 0 Then
                    '    RaiseEvent LineCountChanged(SelectionStart, .LineCountDelta)
                    'End If
                    RaiseEvent AfterUndoOrRedo(Me.SelectionLength > 0)
                    IdleTime.Enabled = True
                End With

            End If
            '    ValidateUndoRedo
        Catch
            ClearUndo()
            Locked = False
            bUndoingOrRedoing = False
            Throw
        End Try
    End Sub

    Public Shadows Sub Redo()
        DoRedo()
    End Sub
    Private Sub DoRedo()
        Try
            If Not AllowApply Then Return
            bUndoingOrRedoing = True
            If TrapUndo AndAlso RedoStack.Count > 0 Then
                Lock() 'Do not trap any changes
                'Do the original action
                curElement = RedoStack.Item(RedoStack.Count - 1)
                Apply()
                UndoStack.Add(curElement)
                RaiseEvent OnUndoRedoPush(UndoType.MG_UNDO, UndoStack.Count, curElement)
                RedoStack.RemoveAt(RedoStack.Count - 1)
                RaiseEvent OnUndoRedoPop(UndoType.MG_REDO, RedoStack.Count)
                Locked = False
                bUndoingOrRedoing = False
                RaiseEvent AfterUndoOrRedo(Me.SelectionLength > 0)
            End If
        Catch
            ClearUndo()
            Locked = False
            bUndoingOrRedoing = False
            Throw
        End Try
    End Sub

    <System.ComponentModel.Description("Causes events to be raised to initially populate the lists.")>
    Public Sub InitializeUndoRedoStacks()
        Dim c, ct As Integer
        ct = UndoStack.Count - 1
        RaiseEvent OnUndoRedoClear(UndoType.MG_UNDO)
        For c = ct To 0 Step -1
            RaiseEvent OnUndoRedoPush(UndoType.MG_UNDO, c, UndoStack(c))
        Next c
        RaiseEvent OnUndoRedoClear(UndoType.MG_REDO)
        ct = RedoStack.Count - 1
        For c = 0 To ct
            RaiseEvent OnUndoRedoPush(UndoType.MG_REDO, c, RedoStack(c))
        Next c
    End Sub

    'TODO If the undoto position is a file type then we can skip a lot
    Public Sub UndoTo(ByVal toIndex As Integer)
        Dim c, ct As Integer
        ct = UndoStack.Count - 1
        If toIndex > ct Then Exit Sub
        For c = 0 To toIndex
            DoUndo()
        Next c
        RaiseEvent AfterUndoOrRedo(Me.SelectionLength > 0)
    End Sub

    Public Sub RedoTo(ByVal toIndex As Integer)
        Dim c, ct As Integer
        ct = RedoStack.Count - 1
        If toIndex > ct Then Exit Sub
        For c = 0 To toIndex
            DoRedo()
        Next c
        RaiseEvent AfterUndoOrRedo(Me.SelectionLength > 0)
    End Sub

    Public Shadows Sub ClearUndo()
        Dim c, ct As Integer
        'remove all redo items because of the change
        ct = UndoStack.Count - 1
        RaiseEvent OnUndoRedoClear(UndoType.MG_UNDO)
        For c = ct To 0 Step -1
            If UndoStack(c).ChangeType = OpTypes.MG_OPERATE Then
                DeleteUndoFile(UndoStack(c).Text)
            End If
            UndoStack.RemoveAt(c)
        Next c
        ClearRedo()
    End Sub

    Public Sub ClearRedo()
        Dim c, ct As Integer
        ct = RedoStack.Count - 1
        RaiseEvent OnUndoRedoClear(UndoType.MG_REDO)
        For c = ct To 0 Step -1
            If RedoStack(c).ChangeType = OpTypes.MG_OPERATE Then
                DeleteUndoFile(RedoStack(c).Text)
            End If
            RedoStack.RemoveAt(c)
        Next c
    End Sub

    <System.ComponentModel.Browsable(False)>
    Public Shadows ReadOnly Property CanUndo() As Boolean
        Get
            CanUndo = UndoStack.Count > 0
        End Get
    End Property
    <System.ComponentModel.Browsable(False)>
    Public Shadows ReadOnly Property CanRedo() As Boolean
        Get
            CanRedo = RedoStack.Count > 0
        End Get
    End Property
    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property CanCut() As Boolean
        Get
            CanCut = (Not (Me.ReadOnly) AndAlso SelectionLength > 0)
        End Get
    End Property
    <System.ComponentModel.Browsable(False)>
    Public ReadOnly Property CanCopy() As Boolean
        Get
            CanCopy = (SelectionLength > 0)
        End Get
    End Property
    <System.ComponentModel.Browsable(False)>
    Public Shadows ReadOnly Property CanPaste() As Boolean
        Get
            If Clipboard.GetDataObject.GetDataPresent(DataFormats.Text) Then
                CanPaste = True
            ElseIf Clipboard.GetDataObject.GetDataPresent(DataFormats.UnicodeText) Then
                CanPaste = True
            ElseIf Clipboard.GetDataObject.GetDataPresent(DataFormats.OemText) Then
                CanPaste = True
            End If
        End Get
    End Property

    'Private mNativeUndoLimit As Integer = 0
    'Public Property NativeUndoLimit() As Integer
    '    Set(ByVal Value As Integer)
    '        mNativeUndoLimit = Value
    '        SendMessage(Handle, EM_SETUNDOLIMIT, mNativeUndoLimit, IntPtr.Zero)
    '    End Set
    '    Get
    '        Return mNativeUndoLimit
    '    End Get
    'End Property

    Public Property MaxUndo() As Integer
        Get
            MaxUndo = mMaxUndo
        End Get
        Set(ByVal Value As Integer)
            mMaxUndo = Value
        End Set
    End Property

    Public Shadows Sub DoCutSelected()
        Try
            If SelectionLength = 0 Then Exit Sub 'Nothing selected
            SetClipBoardData(SelectedText, SelectedRtf)
            AddToUndoStack(SelectedText, OpTypes.MG_CUT)
        Catch
            ClearUndo()
            Throw
        End Try
    End Sub

    Public Sub SetClipBoardData(ByVal sText As String, ByVal sRtf As String)
        Try
            mClipTxt = sText.Replace(Chr(10), vbCrLf)
            mClipRtf = sRtf
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(mClipTxt, TextDataFormat.Text)
        Catch
            Throw
        End Try
    End Sub

    Public Shadows Sub DoCopySelected()
        If SelectionLength = 0 Then Exit Sub 'Nothing selected
        'This is for some other program that may use the clipboard
        SetClipBoardData(SelectedText, SelectedRtf)
    End Sub

    Public Shadows Sub DoPaste()
        Dim clipText As String
        Try
            If My.Computer.Clipboard.ContainsText() Then
                clipText = My.Computer.Clipboard.GetText(TextDataFormat.Text)
                If clipText.Length > 0 Then
                    'If the text in the clipboard is not the same as myclip data then clear mClipRtf
                    If String.Compare(clipText, MG_RichTextBox.mClipTxt, False) <> 0 Then
                        mClipRtf = ""
                    End If
                    'This will look to see if we have rtf in mClipRtf
                    AddToUndoStack(clipText, OpTypes.MG_PASTE)
                End If
            ElseIf Not String.IsNullOrEmpty(mClipTxt) AndAlso Not String.IsNullOrEmpty(mClipRtf) Then
                'This will look to see if we have rtf in mClipRtf
                AddToUndoStack(mClipTxt, OpTypes.MG_PASTE)
            End If
        Catch
            ClearUndo()
            Throw
        End Try
    End Sub

    Public Sub DoReplaceSelected(ByVal sText As String, ByVal sRtf As String)
        Try
            mClipRtf = sRtf
            AddToUndoStack(sText, OpTypes.MG_REPLACE)
        Catch
            ClearUndo()
            Throw
        End Try
    End Sub

    Public Sub DoDocumentOperation(ByVal sDescription As String)
        Try
            AddToUndoStack(sDescription, OpTypes.MG_OPERATE)
        Catch
            ClearUndo()
            Throw
        End Try
    End Sub

    Private mFileName As String
    Public Shadows Sub LoadFile(ByVal fileName As String, ByVal streamType As RichTextBoxStreamType)
        mFileName = fileName
        mLineCountDirty = True
        MyBase.LoadFile(fileName, streamType)
    End Sub

    Public Property FileName() As String
        Get
            Return mFileName
        End Get
        Set(ByVal value As String)
            mFileName = value
        End Set
    End Property

    'Define the delete action to carried out by the Apply method.
    Public Sub DoDeleteSelected()
        Try
            Lock() 'Do not trap any changes
            'Nothing selected
            If SelectionLength = 0 Then
                'Just a test
                SelectionLength = 2
                If SelectedText = vbCrLf Then
                    'Deleting only a crlf
                    AddToUndoStack(SelectedText, OpTypes.MG_DELETE)
                Else
                    SelectionLength = 1
                    AddToUndoStack(SelectedText, OpTypes.MG_DELETE)
                End If
                curElement.ResumeSelection = False
            Else
                AddToUndoStack(SelectedText, OpTypes.MG_DELETE)
            End If

        Catch
            ClearUndo()
            Locked = False
            Throw
        End Try
        Locked = False
    End Sub

    Public Sub DoBackspace()
        Try
            If SelectionStart = 0 Then Exit Sub
            Lock() 'Do not trap any changes
            If SelectionLength = 0 Then 'Backspace only removed one character
                If SelectionStart > 1 Then
                    SelectionStart = SelectionStart - 1
                    'Set the selection to 2 just to test for crlf
                    SelectionLength = 2
                    If SelectedText = vbCrLf Then
                        AddToUndoStack(NULLSTRING, OpTypes.MG_BACKSPACE)
                    Else
                        SelectionLength = 1
                        AddToUndoStack(NULLSTRING, OpTypes.MG_BACKSPACE)
                    End If
                Else
                    SelectionStart = SelectionStart - 1
                    SelectionLength = 1
                    AddToUndoStack(NULLSTRING, OpTypes.MG_BACKSPACE)
                End If
                curElement.ResumeSelection = False
            Else
                AddToUndoStack(NULLSTRING, OpTypes.MG_BACKSPACE)
                curElement.ResumeSelection = True
            End If

        Catch ex As Exception
            ClearUndo()
            Locked = False
            Throw
        End Try
        Locked = False
    End Sub


    Private Sub SetCommandTypeName(ByRef u As UndoData)
        Dim numChar As Integer
        numChar = 8
        Select Case u.ChangeType
            Case OpTypes.MG_OPERATE
                u.Description = "Operate - "" " & u.Rtf & " """
            Case OpTypes.MG_TYPING
                If u.Text = vbCrLf Then
                    u.Description = "Typing - Enter"
                Else
                    u.Description = "Typing - "" " & Mid(u.Text, 1, numChar) & " """
                End If
            Case OpTypes.MG_CUT
                u.Description = "Cut - "" " & Mid(u.Text, 1, numChar) & " """
            Case OpTypes.MG_DELETE
                u.Description = "Delete - "" " & Mid(u.Text, 1, numChar) & " """
            Case OpTypes.MG_BACKSPACE
                u.Description = "Backspace - "" " & Mid(u.Text, 1, numChar) & " """
            Case OpTypes.MG_DRAG_MOVE
                u.Description = "DragMove - "" " & Mid(u.Text, 1, numChar) & " """
            Case OpTypes.MG_DRAG_COPY
                u.Description = "DragCopy - "" " & Mid(u.Text, 1, numChar) & " """
            Case OpTypes.MG_DRAG_DROP
                u.Description = "DragDrop - "" " & Mid(u.Text, 1, numChar) & " """
            Case OpTypes.MG_PASTE
                u.Description = "Paste - "" " & Mid(u.Text, 1, numChar) & " """
            Case OpTypes.MG_REPLACE
                u.Description = "Replace - "" " & Mid(u.Text, 1, numChar) & " """
        End Select

    End Sub

    Private Sub MG_RichTextBox_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackColorChanged
        If mTextRangeBoxColorProp = Color.Transparent Then
            mTextRangeBoxColor = Color.FromArgb(180, Not BackColor.R, Not BackColor.G, Not BackColor.B)
        End If
    End Sub

    Private Sub MG_RichTextBox_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ClientSizeChanged
        mClientRectangle = ClientRectangle
    End Sub

    Private Sub RtbUndoRedo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Integer = e.KeyValue

        If e.KeyCode = Keys.Insert Then
            mOverstrikeMode = Not mOverstrikeMode
            Exit Sub
        End If

        If e.Control Then
            If KeyCode = 120 OrElse KeyCode = 88 Then 'Ctrl+X
                DoCutSelected()
                e.SuppressKeyPress = True
                Exit Sub
            End If

            If KeyCode = 118 OrElse KeyCode = 86 Then 'Ctrl+V
                DoPaste()
                e.SuppressKeyPress = True
                Exit Sub
            End If

            If KeyCode = 99 OrElse KeyCode = 67 Then 'Ctrl+C
                DoCopySelected()
                e.SuppressKeyPress = True
                Exit Sub
            End If
            If KeyCode = 122 OrElse KeyCode = 90 Then 'Ctrl+Z
                DoUndo()
                e.SuppressKeyPress = True
                Exit Sub
            End If
            If KeyCode = 121 OrElse KeyCode = 89 Then 'Ctrl+Y
                DoRedo()
                e.SuppressKeyPress = True
                Exit Sub
            End If
        End If

        Select Case KeyCode
            Case System.Windows.Forms.Keys.Delete
                DoDeleteSelected()
                e.SuppressKeyPress = True

            Case System.Windows.Forms.Keys.Back
                DoBackspace()
                e.SuppressKeyPress = True
            Case System.Windows.Forms.Keys.Return
                AddToUndoStack(vbCrLf, OpTypes.MG_TYPING)
                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub RtbUndoRedo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        If TrapUndo Then
            If KeyAscii >= 32 AndAlso KeyAscii <= 126 Then
                AddToUndoStack(e.KeyChar.ToString, OpTypes.MG_TYPING)
                KeyAscii = 0
            End If
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        Else
            e.KeyChar = Chr(KeyAscii)
        End If

    End Sub

#Region "Win32 functions. locking and scrolling"
    Private mOldEventMask As IntPtr = IntPtr.Zero
    Private mLockStack As Integer = 0
    Private mScrollStack As Integer = 0
    Private msg As Message

    Public Property Locked() As Boolean
        Set(ByVal Value As Boolean)
            If Value Then
                Lock()
            Else
                UnLock()
            End If
        End Set
        Get
            Return (mLockStack > 0)
        End Get
    End Property

    'Private mPreventEvents As Boolean = True
    Public Sub Lock()
        mLockStack += 1
        If mLockStack > 1 Then Exit Sub
        mOldEventMask = IntPtr.Zero
        mOldEventMask = SendMessage(Handle, EM_SETEVENTMASK, ENM_NONE, IntPtr.Zero)
        SendMessage(Handle, WM_SETREDRAW, 0, IntPtr.Zero)
    End Sub

    Public Sub UnLock()
        mLockStack -= 1
        If mLockStack < 0 Then
            mLockStack = 0
            Exit Sub
        End If
        If mLockStack > 0 Then Exit Sub 'this seems to be killing events
        'Allow redraw
        SendMessage(Handle, WM_SETREDRAW, 1, IntPtr.Zero)
        'Allow events
        SendMessage(Handle, EM_SETEVENTMASK, ENM_NONE, mOldEventMask)
        'Show changes
        Invalidate(mClientRectangle, False)
    End Sub

    Public Sub SaveScroll()
        mScrollStack += 1
        If mScrollStack > 1 Then Exit Sub 'Prevent redundent calls if we have nested Save/Restore
        'The top line
        mTopLine = FirstVisibleLine
        mSavedZoomFactor = ZoomFactor
    End Sub

    Public Sub SaveScrollAndCursor(Optional ByVal preserveSelection As Boolean = True)
        'The top line
        SaveScroll()
        mSavedSelStart = SelectionStart
        If preserveSelection Then
            mSavedSelLen = SelectionLength
        Else
            mSavedSelLen = 0
        End If
    End Sub

    Public Sub Scroll(ByVal lines As Integer)
        Dim pInt As New IntPtr(lines)
        SendMessage(Handle, EM_LINESCROLL, 0, pInt)
    End Sub

    'Scroll the specified character to the center of the screen
    Public Sub ScrollLineToCenter(ByVal lineNo As Integer)
        Dim t As Integer = Me.FirstVisibleLine
        Dim b As Integer = Me.LastVisibleLine
        Dim ctr As Integer = (b + t) \ 2
        Dim pInt As New IntPtr(lineNo - ctr)
        SendMessage(Handle, EM_LINESCROLL, 0, pInt)
    End Sub

    'Scroll the specified character to the center of the screen
    Public Sub ScrollCharToCenter(ByVal charPos As Integer)
        Dim t As Integer = Me.FirstVisibleLine
        Dim b As Integer = Me.LastVisibleLine
        Dim ctr As Integer = (b + t) \ 2
        Dim lineNo As Integer = Me.GetLineFromCharIndex(charPos)
        Dim pInt As New IntPtr(lineNo - ctr)
        SendMessage(Handle, EM_LINESCROLL, 0, pInt)
    End Sub

    Public Sub RestoreScroll()
        mScrollStack -= 1
        If mScrollStack < 0 Then
            mScrollStack = 0
            Exit Sub
        End If
        If mScrollStack > 0 Then Exit Sub

        Dim curTopLine As Integer = FirstVisibleLine
        If mTopLine <> curTopLine Then
            Dim pInt As New IntPtr(mTopLine - curTopLine)
            'Find the start of the line
            'mFirstCharIndexFromTopLine = GetFirstCharIndexFromLine(mTopLine)
            'Scroll the screen to the stored top line
            For ln As Integer = 0 To 500
                If mTopLine = curTopLine Then Exit For
                SendMessage(Handle, EM_LINESCROLL, 0, pInt)
                curTopLine = FirstVisibleLine
            Next
        End If

        'Sideways scrolling
        SendMessage(Handle, EM_LINESCROLL, 1, IntPtr.Zero)
        If mSavedZoomFactor <> ZoomFactor Then
            ZoomFactor = mSavedZoomFactor
        End If
    End Sub

    Public Sub RestoreScrollAndCursor()
        'Restore cursor position
        SelectionStart = mSavedSelStart
        SelectionLength = mSavedSelLen
        RestoreScroll()
    End Sub

    Public Sub LoadAndKeepLinePos(ByRef LdFile As String, ByRef Filetype As System.Windows.Forms.RichTextBoxStreamType)
        'Find the location of the cursor
        SaveScrollAndCursor()
        'TODO add status
        'Lock the active window so the user can't edit it
        Lock()
        'Loads the default color scheme to avoid formatting with current text
        'Load the formatted file into the window
        Select Case Filetype
            Case RichTextBoxStreamType.PlainText
                Me.Text = My.Computer.FileSystem.ReadAllText(LdFile)
            Case RichTextBoxStreamType.RichNoOleObjs, RichTextBoxStreamType.RichText
                LoadFile(LdFile, Filetype)
        End Select
        RestoreScrollAndCursor()
        UnLock()
        mLineCountDirty = True
    End Sub
#End Region

#Region "DragDrop"
    ''' <summary>
    ''' Determine if the left mouse was clicked down within a selection range
    ''' </summary>
    Private Sub RtbUndoRedo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        DragData.StartedByMe = False
        DragData.InProgress = False
        DragData.SourceRTB = Nothing
        ClearInsertPosition()
        'This might be a drag start.
        'If the mouse is clicked and the selection is not 0 then the mouse was clicked ON the text
        'If text 
        If e.Location.X < Me.SelectionIndent Then
            Exit Sub
        End If

        If e.Button = System.Windows.Forms.MouseButtons.Left AndAlso SelectionLength > 0 Then
            Dim mouseCharPos As Integer = Me.GetCharIndexFromPosition(e.Location)
            If mouseCharPos > Me.SelectionStart AndAlso mouseCharPos < (SelectionStart + SelectionLength) Then
                DragData.StartedByMe = True
                Debug.WriteLine("DragData.StartedByMe")
            End If
        End If
    End Sub

    Public Sub SetDragEnterData(txt As String, rtf As String)
        DragData.SelRtf = rtf
        DragData.SelText = txt
        DragData.FromPos = -1
        DragData.SourceRTB = Nothing
        DragData.StartedByMe = False
    End Sub

    Private Sub RtbUndoRedo_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        'We alreaady started dragging so get out now
        If DragData.InProgress Then
            Exit Sub
        End If

        'If dragging has started and the left mouse is down
        If e.Button = System.Windows.Forms.MouseButtons.Left AndAlso SelectionLength > 0 AndAlso DragData.StartedByMe Then
            DragData.InProgress = True
            DragData.SelRtf = SelectedRtf
            DragData.SelText = SelectedText
            DragData.FromPos = SelectionStart
            DragData.SourceRTB = Me
            'Fill the data
            Dim data As New DataObject(DataFormats.Rtf, SelectedRtf)
            'Start drag-drop an allow move or copy
            DragData.Effect = DoDragDrop(data, DragDropEffects.Copy Or DragDropEffects.Move)
        Else
            DragData.StartedByMe = False
        End If
    End Sub

    Private Sub RtbUndoRedo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        DragData.StartedByMe = False
        DragData.InProgress = False
        Debug.WriteLine("MouseUp")
    End Sub

    Private Sub RtbUndoRedo_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        Debug.WriteLine("DragEnter")
        If e.Data.GetDataPresent(DataFormats.Rtf, True) Then
            If DragData.SourceRTB Is Nothing Then 'Drag started from away. Snippet?
                Debug.WriteLine("Copy")
                e.Effect = e.AllowedEffect And DragDropEffects.Copy
            Else
                If My.Computer.Keyboard.CtrlKeyDown Then
                    ' CTL KeyState for copy.
                    e.Effect = e.AllowedEffect And DragDropEffects.Copy
                Else
                    e.Effect = e.AllowedEffect And DragDropEffects.Move
                End If
                DragData.SourceRTB.ClearInsertPosition()
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
        DragData.InProgress = (e.Effect <> DragDropEffects.None)
        Me.Focus()
        Invalidate(Me.ClientRectangle)
        Debug.WriteLine(e.Effect)
    End Sub

    Private Sub MG_RichTextBox_DragOver(sender As Object, e As DragEventArgs) Handles Me.DragOver
        If DragData.InProgress Then
            Dim realPoint As Point = PointToClient(New Point(e.X, e.Y))
            Dim caretPos As Integer = GetCaretIndexFromPoint(realPoint)
            ClearInsertPosition()

            'If the drop location is not outside the selected text then exit.
            If DragData.StartedByMe Then
                If caretPos < DragData.FromPos OrElse caretPos > (DragData.FromPos + DragData.SelText.Length) Then
                    ShowInsertPosition(caretPos)
                End If
            Else
                ShowInsertPosition(caretPos)
            End If
        End If
    End Sub

    Private Sub RtbUndoRedo_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        Debug.WriteLine("DragDrop")
        'At this point I know where the selection was even though it is cleared by now.
        'I also know the current selection location.
        'I should be able to re-lelect the original text and delete it
        'then insert the dragged text into the current location.
        'If the CTRL key was down then I don't delete the original.

        Try
            DragData.StartedByMe = False
            DragData.InProgress = False
            DragData.ToPos = SelectionStart
            'Drag within the same window
            If DragData.SourceRTB Is Me Then
                mClipRtf = DragData.SelRtf
                If My.Computer.Keyboard.CtrlKeyDown Then
                    'Copy
                    AddToUndoStack(DragData.SelText, OpTypes.MG_DRAG_COPY)
                Else
                    'If the drop location is not outside the selected text then exit.
                    If SelectionStart > DragData.FromPos Then
                        If SelectionStart <= DragData.FromPos + DragData.SelText.Length Then
                            Exit Sub
                        End If
                    End If
                    'Move
                    AddToUndoStack(DragData.SelText, OpTypes.MG_DRAG_MOVE)
                End If
            Else
                If DragData.SourceRTB Is Nothing Then
                    'Foreign window. snipppets
                    mClipRtf = DragData.SelRtf
                    If mClipRtf.Length > 0 Then
                        AddToUndoStack(DragData.SelText, OpTypes.MG_DRAG_DROP)
                    End If
                Else 'Drag from other window
                    mClipRtf = DragData.SelRtf
                    If My.Computer.Keyboard.CtrlKeyDown Then 'Copy
                        AddToUndoStack(DragData.SelText, OpTypes.MG_DRAG_DROP)
                    Else
                        AddToUndoStack(DragData.SelText, OpTypes.MG_DRAG_DROP)
                        DragData.SourceRTB.DoDeleteSelected()
                    End If
                End If
            End If
        Catch ex As Exception
            ClearUndo()
        End Try
    End Sub
    ''' <remarks>
    ''' GetCharIndexFromPosition is missing one caret position, as there is one extra caret
    ''' position than there are characters (an extra one at the end).
    ''' </remarks>
    Private Function GetCaretIndexFromPoint(realPoint As Point) As Integer
        Dim index As Integer = GetCharIndexFromPosition(realPoint)
        If index = Text.Length - 1 Then
            Dim caretPoint As Point = GetPositionFromCharIndex(index)
            If (realPoint.X > caretPoint.X) OrElse (realPoint.Y > caretPoint.Y) Then
                index += 1
            End If
        End If
        Return index
    End Function
#End Region
    Private mVscrollTicks As Integer = 0
    Private Sub TimerVisibleTextChanged_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerVisibleTextChanged.Tick
        Static lastTopline As Integer = 0
        Dim fvl As Integer
        If mVscrollTicks = 0 Then
            RaiseEvent AfterVScroll()
            TimerVisibleTextChanged.Enabled = False
        Else
            fvl = FirstVisibleLine
        End If

        If lastTopline <> fvl Then
            RaiseEvent OnVisibleTextChanged()
        End If
        mVscrollTicks = 0
        lastTopline = fvl
    End Sub

    Private Sub MG_RichTextBox_VScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VScroll
        Dim pt As Point
        mLineHeightPixels = CInt((Font.Height * ZoomFactor))

        ' Check scrollposition after scrolling
        SendScrollPosMessage(Handle, EM_GETSCROLLPOS, IntPtr.Zero, pt)

        If (mLineCount * mLineHeightPixels) > UShort.MaxValue Then
            Dim scrollPosY As Long = CLng(pt.Y * mLineHeightPixels * (mLineCount / UShort.MaxValue))
            RaiseEvent OnVScrollPosChanged(scrollPosY, scrollPosY - mLastScrollPosY)
            mLastScrollPosY = scrollPosY
        Else
            RaiseEvent OnVScrollPosChanged(pt.Y, CInt(pt.Y - mLastScrollPosY))
            mLastScrollPosY = pt.Y
        End If

        'This does not fire after we delete some text
        mHighlightRect = Me.ClientRectangle
        If EnableOnVisibleTextChangedEvent Then
            TimerVisibleTextChanged.Enabled = True
            mVscrollTicks += 1
        End If
    End Sub

    Private Sub MG_RichTextBox_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        'We are zooming
        If My.Computer.Keyboard.CtrlKeyDown Then
            If EnableOnVisibleTextChangedEvent Then
                TimerVisibleTextChanged.Enabled = True
            End If
        End If
    End Sub

    Private mIdlePause As Boolean
    Private Sub IdleTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IdleTime.Tick
        If mIdlePause Then
            IdleTime.Enabled = False
            RaiseEvent OnIdleTime()
        End If
        mIdlePause = True
    End Sub

    Private Sub MG_RichTextBox_OnApply() Handles Me.OnApply
        'Enable the timer when the text changes
        If IdleTime.Interval > 0 Then
            IdleTime.Enabled = True
            mIdlePause = False
        End If
    End Sub

    Protected Overrides Sub OnMouseDoubleClick(ByVal e As System.Windows.Forms.MouseEventArgs)
        'Try to split the line into Addresses and see if the current selection falls within it
        Dim selStart As Integer = Me.SelectionStart
        Dim selLen As Integer = Me.SelectionLength
        Dim lineStart As Integer = selStart - 10 'Me.GetFirstCharIndexOfCurrentLine
        Dim lineLen As Integer = selStart + 20 'Me.GetLineLength(selStart)

        Try
            If lineStart < 0 Then lineStart = 0

            If (lineStart + lineLen) > Me.Text.Length Then
                lineLen = Me.Text.Length - lineStart
            End If

            Dim myLine As String = Me.Text.Substring(lineStart, lineLen)
            For Each w As System.Text.RegularExpressions.Match In mRegEx.Matches(myLine)
                If selStart >= (w.Index + lineStart) AndAlso selStart <= (w.Index + w.Length + lineStart) Then
                    If w.Length > selLen Then
                        Me.Lock()
                        Me.SelectionStart = w.Index + lineStart
                        Me.SelectionLength = w.Length
                        Me.UnLock()
                    End If
                End If
            Next
        Catch
        End Try
        MyBase.OnDoubleClick(e)
    End Sub

    Public Sub ClearLineHighlight()
        If mHighlightRect.Width > 0 Then
            mHighlightRect.Inflate(2, 2) 'for when we invalidate
            Me.Invalidate(mHighlightRect)
            mHighlightRect.Width = 0
        End If
    End Sub

    Public Sub DrawHighlightRectangle()
        If mHighlightRect.Width = 0 Then Return
        If mHighlightRect.Width <> ClientRectangle.Width Then
            'Force OS to process messages
            Update()
            Using selPen As New Pen(mTextRangeBoxColor)
                selPen.DashStyle = Drawing2D.DashStyle.Dot
                selPen.Width = 2
                Using gfx As Graphics = CreateGraphics()
                    gfx.DrawRectangle(selPen, mHighlightRect)
                End Using
            End Using
        End If
    End Sub

    Public Sub HighlightLineWithRectangle(ByVal l As Integer)
        Dim charPos As Integer = GetFirstCharIndexFromLine(l)
        DetermineHighlightRect(l)
        DrawHighlightRectangle()
        RaiseEvent OnHighlightLine(Me, charPos)
    End Sub

    Private Sub DetermineHighlightRect(ByVal lineNum As Integer)
        Dim charPos As Integer = GetFirstCharIndexFromLine(lineNum)
        Dim p2 As Point = GetPositionFromCharIndex(charPos - 1)
        Dim p1 As Point = GetPositionFromCharIndex(charPos)
        mHighlightRect.X = p1.X
        mHighlightRect.Y = p2.Y
        mHighlightRect.Width = p2.X - p1.X + 2
        mHighlightRect.Height = p1.Y - p2.Y
        If Me.SelectionIndent > 0 Then
            mHighlightRect.X -= 2
            mHighlightRect.Width += 2
        End If
    End Sub


    Public Sub HighlightSyntaxError(ByVal charPos As Integer, ByVal linePos As Integer)
        Dim p2 As Point = GetPositionFromCharIndex(charPos)

        Using selPen As New Pen(Color.Red)
            'selPen.DashStyle = Drawing2D.DashStyle.Dot
            'selPen.EndCap = Drawing2D.LineCap.ArrowAnchor
            Using gfx As Graphics = CreateGraphics()
                gfx.DrawLine(Pens.Red, p2.X - 2, p2.Y - 2, p2.X, p2.Y)
                gfx.DrawLine(selPen, p2.X, p2.Y, p2.X + 2, p2.Y - 2)
            End Using
        End Using
    End Sub

    Public Sub ClearTip()
        If mToolTipRect.Width > 0 Then
            mToolTipRect.Inflate(2, 2)
            Invalidate(mToolTipRect)
            mToolTipRect.Width = 0
            'Force OS to process messages
            Update()
        End If
    End Sub

    Public Sub ShowTipAlert(ByVal msg As String, ByVal position As Integer)
        Dim tp As Point
        Dim center As New Point
        Dim textSize As SizeF
        Dim rect As Rectangle
        Dim rad As Single = 8
        Dim inflation As Integer = 4
        Dim ul As PointF
        Dim ur As PointF
        Dim ll As PointF
        Dim lr As PointF

        tp = GetPositionFromCharIndex(position)

        Using gfx As Graphics = CreateGraphics()
            textSize = gfx.MeasureString(msg, Me.Font)
            rect = New Rectangle(tp.X, CInt(tp.Y - textSize.Height - (rad * 3)), CInt(textSize.Width), CInt(textSize.Height))

            If Not Bounds.Contains(rect) Then
                'Too far to the right
                If rect.Right > Bounds.Width Then
                    rect.X = Bounds.Width - rect.Width
                End If

                If rect.Width > Bounds.Width Then
                    rect.X = 1
                End If

                'Too close to the top
                If rect.Top < 0 Then
                    rect.Y += CInt(rect.Height + Me.SelectionFont.Height + (rad * 6))
                    tp.Y += Me.SelectionFont.Height
                End If
            End If

            rect.Inflate(inflation, inflation)
            ul = rect.Location
            ur.Y = rect.Top
            ur.X = rect.Right
            ll.X = rect.Left
            ll.Y = rect.Bottom
            lr.X = rect.Right
            lr.Y = rect.Bottom

            center.X = CInt((rect.Left + rect.Right) / 2)
            center.Y = CInt((rect.Top + rect.Bottom) / 2)

            mToolTipRect.X = rect.X
            mToolTipRect.Y = Math.Min(rect.Y, tp.Y)
            mToolTipRect.Width = rect.Width
            mToolTipRect.Height = Math.Max(rect.Bottom, tp.Y) - Math.Min(rect.Y, tp.Y)

            gfx.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            Using br As New SolidBrush(SystemColors.Info)
                Using path As New Drawing2D.GraphicsPath
                    path.AddLine(ul.X + rad, ul.Y, ur.X - rad, ur.Y)
                    path.AddArc(ur.X - rad, ur.Y, rad, rad, 270, 90) 'upper-right
                    path.AddLine(ur.X, ur.Y + rad, ur.X, lr.Y - rad)
                    path.AddArc(lr.X - rad, lr.Y - rad, rad, rad, 0, 90) 'lower-right
                    path.AddLine(lr.X - rad, lr.Y, ll.X + (rad * 3), ll.Y)

                    path.AddArc(ll.X, ll.Y - rad, rad, rad, 90, 90) 'lower-left
                    path.AddLine(ll.X, ll.Y - rad, ul.X, ul.Y + rad)
                    path.AddArc(ul.X, ul.Y, rad, rad, 180, 90) 'upper-right

                    path.CloseFigure()
                    gfx.FillPath(br, path)

                    path.Reset()
                    path.AddLine(tp.X, tp.Y, center.X, CInt(center.Y - (rect.Height / 3)))
                    path.AddLine(center.X, CInt(center.Y - (rect.Height / 3)), center.X, CInt(center.Y + (rect.Height / 3)))
                    'path.CloseFigure
                    'path.AddLine(center.X, CInt(center.Y + (rect.Height / 3)), tp.X, tp.Y)

                    path.CloseFigure()
                    gfx.FillPath(br, path)

                    Using txbr As New SolidBrush(SystemColors.InfoText)
                        gfx.DrawString(msg, Me.Font, txbr, rect.Left + inflation, rect.Top + inflation)
                    End Using
                    'Using brOutline As New Pen(mTextRangeBoxColor)
                    '    gfx.DrawPath(brOutline, path)
                    'End Using
                    'gfx.DrawPath(Pens.Black, path)
                    'gfx.DrawRectangle(Pens.Red, mToolTipRect)
                End Using
            End Using

        End Using
    End Sub

    Public Sub ClearInsertPosition()
        If mMarkerRect.Width > 0 Then
            mMarkerRect.Inflate(2, 2)
            Invalidate(mMarkerRect)
            mMarkerRect.Width = 0
            'Force OS to process messages
            Update()
        End If
    End Sub

    Public Sub ShowInsertPosition(ByVal pos As Integer)
        ' Create points that define polygon.
        Dim shiftX As Integer = CInt(15 * ZoomFactor)
        Dim shiftY As Integer = CInt(20 * ZoomFactor)
        Dim i As Point = GetPositionFromCharIndex(pos)
        Dim curvePoints As PointF() = {New PointF(i.X, i.Y),
                                        New PointF(i.X + shiftX \ 2, i.Y - shiftY \ 2),
                                        New PointF(i.X + shiftX \ 4, i.Y - shiftY \ 2),
                                        New PointF(i.X + shiftX \ 4, i.Y - shiftY),
                                        New PointF(i.X - shiftX \ 4, i.Y - shiftY),
                                        New PointF(i.X - shiftX \ 4, i.Y - shiftY \ 2),
                                        New PointF(i.X - shiftX \ 2, i.Y - shiftY \ 2)
                                        }
        With mMarkerRect
            .Width = shiftX
            .Height = shiftY
            .X = i.X - shiftX \ 2
            .Y = i.Y - shiftY
        End With
        'Force OS to process messages
        Update()

        Using selBrush As New SolidBrush(mTextRangeBoxColor)
            Using gfx As Graphics = CreateGraphics()
                gfx.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                gfx.FillPolygon(selBrush, curvePoints)
                'gfx.DrawRectangle(Pens.AliceBlue, mMarkerRect)
            End Using
        End Using
    End Sub

    Public Sub ClearMultiLineHighlight()
        For Each box As Rectangle In mMultiRangeBoxes
            If box.Width > 0 Then
                'box.Inflate(2, 2) 'for when we invalidate
                Me.Invalidate(box)
            End If
        Next
        mMultiLineRangeBox.Width = 0
        mMultiRangeBoxes.Clear()

    End Sub

    'Public Sub HighlightTextRangeWithColor(ByVal foreColor As Color, ByVal selStart As Integer, ByVal selLen As Integer)
    '    Dim charPoint As Point
    '    Dim originalSelStart As Integer = SelectionStart
    '    Using g As Graphics = Graphics.FromHwnd(Me.Handle)
    '        g.ScaleTransform(ZoomFactor, ZoomFactor)
    '        Using textBrush As New SolidBrush(foreColor)
    '            For r As Integer = selStart To selStart + selLen
    '                SelectionStart = r
    '                charPoint = GetPositionFromCharIndex(r)
    '                g.DrawString(Text(r), SelectionFont, textBrush, charPoint)
    '            Next
    '        End Using
    '    End Using
    '    SelectionStart = originalSelStart
    'End Sub

    Public Sub HighlightRangeWithOutline(ByVal selStart As Integer, ByVal selLen As Integer)
        Dim pts As New Generic.List(Of Point)
        Dim charPoint As Point
        Dim lf2 As Point
        Dim l As Integer = 1
        Dim maxX As Integer = 0
        Dim maxY As Integer = 0
        Dim minX As Integer = 5000
        Dim minY As Integer = 5000
        Dim multiLine As Boolean
        Dim lastLineHeight As Integer = CInt((Font.Height * ZoomFactor))
        Dim lastIsLF As Boolean = False
        Dim curLine As Integer
        Dim nextLineChar As Integer

        If selLen = 0 Then Return

        'Get the first point from the first character
        charPoint = GetPositionFromCharIndex(selStart)
        'Get the start position of the first line
        charPoint.X -= 1
        pts.Add(charPoint)

        'Get all the positions of a all the linefeeds
        Dim minChars As Integer = Math.Min(Me.Text.Length, (selStart + selLen))
        Dim prevY, prevX As Integer
        For l = selStart To minChars - 1

            If lastIsLF AndAlso Not multiLine Then
                multiLine = True
            End If

            lastIsLF = False
            If Text.Chars(l) = vbLf Then
                lastIsLF = True
                charPoint = GetPositionFromCharIndex(l)

                If pts.Count > 1 Then
                    multiLine = True
                    'this Y , prev X
                    lf2 = charPoint 'same Y
                    lf2.X = prevX
                    pts.Add(lf2) 'bottom of the last line
                    lastLineHeight = Math.Max(lastLineHeight, charPoint.Y - prevY)
                End If

                charPoint.X += 1
                pts.Add(charPoint)

                prevX = charPoint.X
                prevY = charPoint.Y

                'If the range of characters is off the screen bottom then quit.
                If charPoint.Y > ClientRectangle.Bottom Or charPoint.Y < 0 Then
                    Exit For
                End If
            End If
        Next

        'If we encountered a LF then we do not need to calculate this
        If Not lastIsLF Then
            charPoint = GetPositionFromCharIndex(selStart + selLen)
            pts.Add(charPoint)
            prevY = charPoint.Y
        End If

        'find the bottom of the last line
        curLine = GetLineFromCharIndex(selStart + selLen - 1)
        nextLineChar = GetFirstCharIndexFromLine(curLine + 1)

        'Get the height of the last line
        If nextLineChar > 1 Then
            lf2 = GetPositionFromCharIndex(nextLineChar)
            lastLineHeight = lf2.Y - prevY
        End If

        If multiLine Then 'multi-line
            If lastIsLF Then
                charPoint = GetPositionFromCharIndex(GetFirstCharIndexFromLine(GetLineFromCharIndex(selStart + selLen) - 1))
            Else
                charPoint = GetPositionFromCharIndex(GetFirstCharIndexFromLine(GetLineFromCharIndex(selStart + selLen)))
            End If

            charPoint.Y += lastLineHeight + 1
            charPoint.X -= 1
            pts.Add(charPoint) 'add the lower-left corner of the last line
        Else
            charPoint.Y += lastLineHeight + 1
            pts.Add(charPoint) 'add the lower-right corner of the last line
            charPoint.X = pts(0).X
            pts.Add(charPoint) 'add the lower-left corner of the last line
        End If

        For Each p As Point In pts
            maxX = Math.Max(p.X, maxX)
            maxY = Math.Max(p.Y, maxY)
            minX = Math.Min(p.X, minX)
            minY = Math.Min(p.Y, minY)
        Next
        mMultiLineRangeBox = Rectangle.FromLTRB(minX, minY, maxX, maxY)
        mMultiLineRangeBox.Inflate(2, 2)
        mMultiRangeBoxes.Add(mMultiLineRangeBox)
        'Force OS to process messages
        Update()


        Using selPen As New Pen(mTextRangeBoxColor)
            selPen.DashStyle = Drawing2D.DashStyle.Dot
            'selPen.DashPattern = New Single() {1.0F, 2.0F}
            selPen.DashOffset = 1
            selPen.Width = 2

            Using gfx As Graphics = CreateGraphics()
                If Not multiLine Then
                    gfx.DrawLine(selPen, pts(0), pts(1))
                    gfx.DrawLine(selPen, pts(1), pts(2)) '|
                    gfx.DrawLine(selPen, pts(2), pts(3)) '-----
                    gfx.DrawLine(selPen, pts(3), pts(0))

                Else
                    gfx.DrawLine(selPen, pts(0), pts(1))
                    Dim ln As Integer

                    For ln = 1 To pts.Count - 2
                        gfx.DrawLine(selPen, pts(ln).X, pts(ln).Y, pts(ln).X, pts(ln + 1).Y) '|
                        If Math.Abs(pts(ln).Y - pts(ln + 1).Y) > 1 OrElse Math.Abs(pts(ln).X - pts(ln + 1).X) > 1 Then
                            gfx.DrawLine(selPen, pts(ln).X, pts(ln + 1).Y, pts(ln + 1).X, pts(ln + 1).Y) '-----
                        End If
                    Next

                    'Draw up to the bottom of the first line
                    gfx.DrawLine(selPen, pts(ln).X, pts(ln).Y, pts(ln).X, pts(2).Y)
                    If pts(0).X <> pts(ln).X Then
                        'over to the first char
                        gfx.DrawLine(selPen, pts(ln).X, pts(2).Y, pts(0).X, pts(2).Y)
                    End If
                    'Close the poly
                    gfx.DrawLine(selPen, pts(0).X, pts(2).Y, pts(0).X, pts(0).Y)

                End If
            End Using
        End Using

    End Sub

    Private Function PointsTooClose(ByVal p1 As Point, ByVal p2 As Point) As Boolean
        Return Math.Abs(p1.X - p2.X) > 1 AndAlso Math.Abs(p1.Y - p2.Y) > 1
    End Function

    Public Sub DrawWatermark(ByVal text As String)
        Dim fontHeight As Integer = mWatermarkFont.Height
        'Draw the overlay.
        Using textBrush As New SolidBrush(Color.FromArgb(50, Not BackColor.R, Not BackColor.G, Not BackColor.B))
            Using g As Graphics = Graphics.FromHwnd(Me.Handle)
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                Dim mp As New Point(2, Me.ClientRectangle.Height - 2 - fontHeight)
                'Dim rect As New Rectangle(mp, g.MeasureString(text, mWatermarkFont).ToSize)
                'Dim s As SizeF = g.MeasureString(text, mWatermarkFont)
                Invalidate()
                Update()
                g.DrawString(text, mWatermarkFont, textBrush, mp)
            End Using
        End Using
    End Sub

    Private Sub LineCountChanged(ByVal position As Integer, ByVal lineCtChange As Integer) Handles Me.CharCountChanged
        mLineCountDirty = lineCtChange <> 0
    End Sub

End Class
