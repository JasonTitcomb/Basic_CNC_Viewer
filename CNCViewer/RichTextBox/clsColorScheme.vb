Imports System.Collections.Generic
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
''' <summary>
''' This class contains everything required to generate the rtf text.
''' </summary>
''' <remarks></remarks>
Friend Class clsColorScheme
#Region "RTF code constants"
    Friend Const RTF_li As String = "\li"
    Friend Const RTF_f As String = "\f"
    Friend Const RTF_fs As String = "\fs"
    Friend Const RTF_cf As String = "\cf"
    Friend Const RTF_b As String = "\b"
    Friend Const RTF_b0 As String = "\b0"
    Friend Const RTF_i As String = "\i"
    Friend Const RTF_i0 As String = "\i0"
    Friend Const RTF_strike As String = "\strike"
    Friend Const RTF_strike0 As String = "\strike0"
    Friend Const RTF_ul As String = "\ul"
    Friend Const RTF_ul0 As String = "\ul0"
    Friend Const RTF_par As String = "\par "
    Friend Const RTF_pard As String = "\pard"
    Friend Const RTF_lcb As String = "{"
    Friend Const RTF_rcb As String = "}"
    Friend Const RTF_bs As String = "\"
    Friend Const RTF_lcbr As String = "\{"
    Friend Const RTF_rcbr As String = "\}"
    Friend Const RTF_bsr As String = "\\"
    Friend Const RTF_space As String = " "
#End Region
    Friend Enum Words
        All
        X_Pos
        Y_Pos
        Z_Pos
        G00
        G01
        G02
        G03
        G41
        G42
        G40
        G91
        G90
        Comment
        Skip
        Highlight
    End Enum

    Public Structure ReplacementMatch
        Dim Index As Integer
        Dim Replacement As String
        Dim Length As Integer
        Dim Highlighted As Boolean
    End Structure

    Friend Enum MatchType
        Simple
        Wildcard
        Regex
    End Enum


    Friend HighlightMatches As New List(Of ReplacementMatch)
    Private mLastCuttingMode As Words
    Private mDatFolder As String
    Private mDatName As String
    Private mDatFile As String
    Private mRegexModeWords As Regex

    Private mRegexFind As Regex
    Private mFindMatch As Match
    Private mLastMatchPos As Integer = 0
    Private mOpAddress(), mOpType(), mOpVal(), mOpFormat() As String
    Private mOpAddressCount As Integer
    Private mHighlight As Boolean
    Private mExcludeComments As Boolean
    Private mExistingNumbersOnly As Boolean
    Private mPreviousReplacementAdjustment As Integer
    Private mSelStart As Integer = 0
    Private mNewSelLen As Integer = 0
    Private mTextToFind As String = ""
    Private mFindReplacement As String = ""
    Private mFindRtfReplacement As String = ""
    Private mCommentString As String
    Private mCommentMatch As String
    Private mHasCommentMatch As Boolean
    Private mMatchType As MatchType
    'Renumbering
    Private mRegexSeqNumber As Regex
    Private mRenumberValue As Single = 0
    Private mRenumberInitialValue As Single = 0
    Private mJumpValue As Single = 0
    Private mJumpCounter As Single = 0
    Private mRenumberOperators(2) As Single
    Private mRenumberAddress As String
    Private mRenumberFormat As String
    Private mRenumberSkipRegexMatch As String
    Private mRenumberRestartChars As String
    Private mRenumberRegexMatch As String
    Private mRenumberExcludeBlankLines As Boolean
    Private mRenumberUpdateGOTO As Boolean
    Private mRenumberNewGOTO_Bad As Boolean
    Private mRenumberDuplicateSeqNumbers As Boolean

    Private mSbRtf As New StringBuilder(1024)
    Private mHighlightRtf As String
    Private Const STR_EOL As String = "\r?"
    Private mTextChangedBetweenLastMatch As Boolean
    'As the setting are loaded the event is raised
    Public Event OnEachSetting(ByVal one As clsOneSetting) 'As LoadSettingHandler
    Public Event OnStartLoading(ByVal backColor As Color, ByVal indent As Integer, ByVal gutterBackColor As Color, ByVal gutterForeColor As Color, ByVal bookmarkColor As Color, ByVal gutterFont As Font, ByVal textRangeBoxColor As Color) 'As StartLoadSettingsHandler
    Public Event OnEndLoading(ByVal indent As Integer) 'As EndLoadSettingsHandler
    Public Event OnSaveScheme(ByVal n As String) ' As OnSaveSchemeHandler
    Private mOldToNewSequenceNumbers As New Generic.Dictionary(Of Single, Single)
    Private mHighlightMatch As Boolean
    Private mTextToSearch As String
    Private mLog As clsLogger
#Region "XmlNames"
    Private Const xSCHEME As String = "Scheme"
    Private Const xBACKCOLOR As String = "BackColor"
    Private Const xBOOKMARKCOLOR As String = "BookmarkColor"
    Private Const xINDENT As String = "Indent"
    Private Const xGUTTERBACKCOLOR As String = "GutterBackColor"
    Private Const xGUTTERFORECOLOR As String = "GutterForeColor"
    Private Const xGUTTERFONT As String = "GutterFont"
    Private Const xTEXTRANGEBOX As String = "TextRangeBox"

    Private Const xNAME As String = "Name"
    Private Const xMATCHTEXT As String = "Match"
    Private Const xFORECLR As String = "Color"
    Private Const xFONT As String = "Font"
    Private Const xHEIGHT As String = "Height"
    Private Const xDESCRIPTION As String = "Desc"

    Private Const xSTANDARD As String = "StdSettings"
    Private Const xCUSTOM As String = "CustSettings"
    Private Const xWORD As String = "Word"
#End Region
    Private mRtfHeader As String 'The rtf fonts and colors to go at the top of the file
    Public Property RtfHeader() As String
        Get
            Return mRtfHeader
        End Get
        Set(ByVal value As String)
            mRtfHeader = value
        End Set
    End Property
    Private mRtfFooter As String 'The rtf code needed at the end of the file
    Public Property RtfFooter() As String
        Get
            Return mRtfFooter
        End Get
        Set(ByVal value As String)
            mRtfFooter = value
        End Set
    End Property

    Private mRegexWords As Regex
    Public ReadOnly Property RegexWords() As Regex
        Get
            Return mRegexWords
        End Get
    End Property

    Private mSkipChar As String
    Public ReadOnly Property SkipChar() As String
        Get
            Return mSkipChar
        End Get
    End Property

    Private mSettings As New clsColorSettings
    Public ReadOnly Property ColorSettings() As clsColorSettings
        Get
            Return mSettings
        End Get
    End Property
    Public ReadOnly Property StandardSettings() As List(Of clsOneSetting)
        Get
            Return Me.mSettings.StdSettings
        End Get
    End Property

    Public ReadOnly Property CustomSetings() As List(Of clsOneSetting)
        Get
            Return Me.mSettings.CstSettings
        End Get
    End Property
    Private mOptimized As Boolean
    <System.ComponentModel.DefaultValue(False)> _
    Public Property Optimized() As Boolean
        Get
            Return mOptimized
        End Get
        Set(ByVal value As Boolean)
            mOptimized = value
        End Set
    End Property

    Private mColorMode As Boolean
    Public Property ColorByMode() As Boolean
        Get
            Return mColorMode
        End Get
        Set(ByVal value As Boolean)
            mColorMode = value
            mLastCuttingMode = Words.G00
        End Set
    End Property

    Public Property TextToSearch() As String
        Get
            Return mTextToSearch
        End Get
        Set(ByVal value As String)
            mTextChangedBetweenLastMatch = True
            mTextToSearch = value
            mPreviousReplacementAdjustment = 0
        End Set
    End Property

    Public Property HighlightMatch() As Boolean
        Get
            Return mHighlightMatch
        End Get
        Set(ByVal value As Boolean)
            mHighlightMatch = value
        End Set
    End Property

    Public ReadOnly Property TextToFind() As String
        Get
            Return mTextToFind
        End Get
    End Property
    Public Property Replacement() As String
        Get
            Return mFindReplacement
        End Get
        Set(ByVal value As String)
            mFindReplacement = value
        End Set
    End Property

    Public Sub New()
        mLog = clsLogger.Instance
    End Sub

    Public Sub SetSchemeGeneral(ByVal indent As Integer, ByVal bColor As Color, ByVal gutterBackColor As Color, ByVal gutterForeColor As Color, ByVal bookmarkColor As Color, ByVal gutterFont As Font, ByVal textRangeColor As Color)
        With mSettings
            .TextRangeBoxColor = textRangeColor
            .BackColor = bColor
            .GutterBackColor = gutterBackColor
            .GutterForeColor = gutterForeColor
            .BookmarkColor = bookmarkColor
            .GutterFont = gutterFont
            .Indent = indent
            .StdSettings.Clear()
            .CstSettings.Clear()
        End With
    End Sub

    Public Sub SetSchemeItem(ByRef o As clsOneSetting)
        With o
            'One set of settings for one cnc word
            If Not .Custom Then
                StandardSettings.Add(o)
            Else
                CustomSetings.Add(o)
            End If
        End With
    End Sub

    Public Property DataFolder() As String
        Get
            Return mDatFolder
        End Get
        Set(ByVal value As String)
            mDatFolder = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return mDatName
        End Get
        Set(ByVal value As String)
            If value.Contains(Path.DirectorySeparatorChar) Then
                DataFolder = Path.GetDirectoryName(value)
            End If
            mDatName = Path.GetFileNameWithoutExtension(value)
            mDatFile = mDatName & ".xml"
        End Set
    End Property

    Public Function Load(ByVal baseFileName As String) As Boolean
        Dim settings As New XmlReaderSettings()
        Try
            Name = baseFileName
            CustomSetings.Clear()
            StandardSettings.Clear()
            With settings
                .ConformanceLevel = ConformanceLevel.Fragment
                .IgnoreWhitespace = True
                .IgnoreComments = True
                .IgnoreProcessingInstructions = True
                .DtdProcessing = DtdProcessing.Ignore
            End With
            Dim fullPath As String = Path.Combine(mDatFolder, mDatFile)
            If Not File.Exists(fullPath) Then
                fullPath = Directory.GetFiles(Path.GetDirectoryName(fullPath))(0)
            End If
            Using xReader As XmlReader = XmlReader.Create(fullPath, settings)
                With xReader
                    .ReadToDescendant(xSCHEME)
                    .ReadToDescendant(xBACKCOLOR)
                    Do Until .Name = xSTANDARD
                        Select Case .Name
                            Case xBOOKMARKCOLOR
                                mSettings.BookmarkColor = Color.FromArgb(.ReadElementContentAsInt)
                            Case xBACKCOLOR
                                mSettings.BackColor = Color.FromArgb(.ReadElementContentAsInt)
                            Case xGUTTERBACKCOLOR
                                mSettings.GutterBackColor = Color.FromArgb(.ReadElementContentAsInt)
                            Case xGUTTERFORECOLOR
                                mSettings.GutterForeColor = Color.FromArgb(.ReadElementContentAsInt)
                            Case xGUTTERFONT
                                mSettings.GutterFont = StringToFont(.ReadElementContentAsString)
                            Case xINDENT
                                mSettings.Indent = .ReadElementContentAsInt
                            Case xTEXTRANGEBOX
                                mSettings.TextRangeBoxColor = Color.FromArgb(.ReadElementContentAsInt)
                        End Select
                    Loop

                    RaiseEvent OnStartLoading(mSettings.BackColor, mSettings.Indent, mSettings.GutterBackColor, mSettings.GutterForeColor, mSettings.BookmarkColor, mSettings.GutterFont, mSettings.TextRangeBoxColor)

                    '.ReadToNextSibling(xSTANDARD)
                    ReadSettings(.ReadSubtree, False)

                    'Create a new xmlreader for the settings
                    .ReadToNextSibling(xCUSTOM)
                    ReadSettings(.ReadSubtree, True)
                End With
            End Using
            BuildRtfForThisScheme()
            RaiseEvent OnEndLoading(mSettings.Indent)
            Return True
        Catch ex As Exception
            mLog.LogError(ex)
            Return False
        End Try
    End Function

    Private Sub ReadSettings(ByRef x As XmlReader, ByVal cust As Boolean)
        'Read each word
        While x.ReadToFollowing(xWORD)
            x.ReadToDescendant(xNAME)
            Dim o As New clsOneSetting()
            With o
                .Custom = cust
                .Name = x.ReadElementContentAsString
                .MatchText = x.ReadElementContentAsString
                .Color = Color.FromArgb(x.ReadElementContentAsInt)
                .Font = StringToFont(x.ReadElementContentAsString)
                .Height = CSng(x.ReadElementContentAsDouble)
                .Description = x.ReadElementContentAsString
            End With
            If o.Custom Then
                CustomSetings.Add(o)
            Else
                StandardSettings.Add(o)
            End If
            RaiseEvent OnEachSetting(o)
        End While

    End Sub

    Public Function Save() As Boolean
        Dim xSettings As New XmlWriterSettings
        Try
            If Not BuildRtfForThisScheme() Then
                Return False
            End If

            xSettings.Indent = True
            Using xWriter As XmlWriter = XmlWriter.Create(mDatFolder & mDatFile, xSettings)
                With xWriter
                    .WriteStartDocument(True)
                    .WriteStartElement(xSCHEME)
                    .WriteElementString(xBACKCOLOR, mSettings.BackColor.ToArgb.ToString)
                    .WriteElementString(xGUTTERBACKCOLOR, mSettings.GutterBackColor.ToArgb.ToString)
                    .WriteElementString(xBOOKMARKCOLOR, mSettings.BookmarkColor.ToArgb.ToString)
                    .WriteElementString(xGUTTERFORECOLOR, mSettings.GutterForeColor.ToArgb.ToString)
                    .WriteElementString(xGUTTERFONT, FontToString(mSettings.GutterFont))
                    .WriteElementString(xTEXTRANGEBOX, mSettings.TextRangeBoxColor.ToArgb.ToString)
                    .WriteElementString(xINDENT, mSettings.Indent.ToString)

                    .WriteStartElement(xSTANDARD)
                    For Each s As clsOneSetting In StandardSettings
                        .WriteStartElement(xWORD)
                        .WriteElementString(xNAME, s.Name)
                        .WriteElementString(xMATCHTEXT, s.MatchText)
                        .WriteElementString(xFORECLR, s.Color.ToArgb.ToString)
                        .WriteElementString(xFONT, FontToString(s.Font))
                        .WriteElementString(xHEIGHT, s.Height.ToString)
                        .WriteElementString(xDESCRIPTION, s.Description)
                        .WriteEndElement()
                    Next
                    .WriteEndElement()

                    .WriteStartElement(xCUSTOM)
                    For Each s As clsOneSetting In CustomSetings
                        .WriteStartElement(xWORD)
                        .WriteElementString(xNAME, s.Name)
                        .WriteElementString(xMATCHTEXT, s.MatchText)
                        .WriteElementString(xFORECLR, s.Color.ToArgb.ToString)
                        .WriteElementString(xFONT, FontToString(s.Font))
                        .WriteElementString(xHEIGHT, s.Height.ToString)
                        .WriteElementString(xDESCRIPTION, s.Description)
                        .WriteEndElement()
                    Next
                    .WriteEndElement()

                    .WriteEndElement() 'Scheme
                End With
            End Using

            RaiseEvent OnSaveScheme(Me.Name)
            Return True
        Catch ex As Exception
            mLog.LogError(ex)
            Return (False)
        End Try
    End Function

    Public Function Rename(ByVal sNewName As String, ByVal copy As Boolean) As Boolean
        Try
            If Not copy Then
                File.Delete(mDatFolder & mDatFile)
            End If
            Name = sNewName
            Save()
            Return True
        Catch ex As Exception
            mLog.LogError(ex)
            Return False
        End Try
    End Function

    Public Function Delete() As Boolean
        Try
            'mIni.Sections.Clear()
            File.Delete(Path.Combine(mDatFolder, mDatFile))
            Return True
        Catch ex As Exception
            mLog.LogError(ex)
            Return (False)
        End Try
    End Function


    Private Function GetSingleRtfCodes(ByVal s As clsOneSetting) As String
        '{\rtf1\ansi\deff0{\fonttbl{\f0\fnil Arial;}}
        '{\colortbl ;\red128\green0\blue128;}
        '\uc1\pard\cf1\lang1033\f0\fs24 X}
        Dim sbRtf As New StringBuilder("{\rtf1\ansi\deff0{\fonttbl{\f0\fnil ")
        sbRtf.Append(s.Font.Name)
        sbRtf.Append(";}}")
        sbRtf.Append(vbCrLf)
        sbRtf.Append("{\colortbl ;")
        sbRtf.Append("\red")
        sbRtf.Append(s.Color.R)
        sbRtf.Append("\green")
        sbRtf.Append(s.Color.G)
        sbRtf.Append("\blue")
        sbRtf.Append(s.Color.B)
        sbRtf.Append(";}")
        sbRtf.Append(vbCrLf)
        sbRtf.Append("\uc1\pard\cf1\lang1033\f0")
        sbRtf.Append(RTF_fs)
        sbRtf.Append(s.Font.Size * 2)
        'Add to it the BOLD if needed
        If s.Font.Bold Then
            sbRtf.Append(RTF_b)
        End If

        'Add to it the ITALICS if needed
        If s.Font.Italic Then
            sbRtf.Append(RTF_i)
        End If

        'Add to it the STRIKE if needed
        If s.Font.Strikeout Then
            sbRtf.Append(RTF_strike)
        End If

        'Add to it the UNDERLINE if needed
        If s.Font.Underline Then
            sbRtf.Append(RTF_ul)
        End If
        sbRtf.Append(RTF_space)
        Return sbRtf.ToString

    End Function

    Private mRegexParseError As String
    Public ReadOnly Property RegexParseError() As String
        Get
            Return mRegexParseError
        End Get
    End Property

    'When the color scheme is selected from the list
    'this sub will prepare the settings for use
    Private Function BuildRtfForThisScheme() As Boolean
        Dim AddedFonts As New List(Of String)
        Dim AddedColors As New List(Of Color)
        'String builders
        'Dim mSbRtf As New StringBuilder
        Dim sbFntTbl As New StringBuilder
        Dim sbClrTbl As New StringBuilder
        Dim customRegExMatch As String = ""


        Try
            'Assigns a font number and builds the font table
            mSbRtf.Length = 0
            mSbRtf.Append("{\rtf1\ansi\deff0")
            sbFntTbl.Append("{\fonttbl")
            sbClrTbl.Append("{\colortbl")

            'Enumerate the fonts and assign a number
            For Each s As clsOneSetting In StandardSettings
                InsertRtfFontsAndColorsInHeader(sbFntTbl, sbClrTbl, s, AddedFonts, AddedColors)
            Next

            For Each s As clsOneSetting In CustomSetings
                If s.MatchText.Length > 0 Then
                    customRegExMatch += "|(" & s.MatchText & ")"
                    InsertRtfFontsAndColorsInHeader(sbFntTbl, sbClrTbl, s, AddedFonts, AddedColors)
                End If
            Next

            'End of font table
            sbFntTbl.Append("}")
            sbFntTbl.Append(vbCrLf)
            'End the color table
            sbClrTbl.Append("}")
            'Append the fonts
            mSbRtf.Append(sbFntTbl)
            mSbRtf.Append(sbClrTbl)
            mSbRtf.Append(vbCrLf)
            mSbRtf.Append("\viewkind4\uc1\pard\li")
            mSbRtf.Append(mSettings.Indent * 200)
            'sbRtf.Append(RTF_space)
            InitRtf()
            InsertRtfAsNeeded(StandardSettings(0))
            RtfHeader = mSbRtf.ToString

            mHighlightRtf = mSbRtf.ToString

            RtfFooter = "}"
            'Set defaults
            mCommentString = StandardSettings(Words.Comment).MatchText
            mSkipChar = "/"
            If StandardSettings(Words.Skip).MatchText.Length = 1 Then
                mSkipChar = StandardSettings(Words.Skip).MatchText.Chars(0)
            End If


            BuildCommentMatch()
            mRegexWords = New Regex(InsertCommment() & _
                                    Regex.Escape(mSkipChar) & _
                                    "\d*|\n" & customRegExMatch & "|[A-Z][-+0-9\.,]+" & _
                                    My.Resources.datRegexNcWords, RegexOptions.Compiled Or RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant)

            mRegexModeWords = New Regex(InsertCommment() & Regex.Escape(mSkipChar) & "\d*|G" & My.Resources.datRegexNcWords, RegexOptions.Compiled Or RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant)
            mHighlightRtf = GetSingleRtfCodes(StandardSettings(Words.Highlight))
            Return True
        Catch ex As Exception
            mRegexParseError = ex.Message
            Return False
        End Try

    End Function

    Private Sub InsertRtfFontsAndColorsInHeader(ByRef sbFntTbl As StringBuilder, ByRef sbClrTbl As StringBuilder, ByRef os As clsOneSetting, ByRef AddedFonts As List(Of String), ByRef AddedColors As List(Of Color))
        Dim sFontFamily As String
        Dim sFontName As String
        Dim fontNumber As Integer = 0
        Dim colorNumber As Integer = 0
        'Fonts=============
        sFontFamily = "fnil"
        sFontName = os.Font.Name
        'Do not add fonts already added
        fontNumber = AddedFonts.Count
        If Not AddedFonts.Contains(sFontName) Then
            os.FontTableNumber = fontNumber
            sbFntTbl.Append("{\f")
            sbFntTbl.Append(fontNumber)
            sbFntTbl.Append("\")
            sbFntTbl.Append(sFontFamily)
            sbFntTbl.Append(" ")
            sbFntTbl.Append(sFontName)
            sbFntTbl.Append(";}")
            AddedFonts.Add(sFontName)
        Else
            'Find the font number assigned
            For f As Integer = 0 To AddedFonts.Count - 1
                If sFontName = AddedFonts(f) Then
                    os.FontTableNumber = f
                    Exit For
                End If
            Next
        End If

        'Colors=============
        colorNumber = AddedColors.Count
        If Not AddedColors.Contains(os.Color) Then
            os.ColorTableNumber = colorNumber
            sbClrTbl.Append("\red")
            sbClrTbl.Append(os.Color.R)
            sbClrTbl.Append("\green")
            sbClrTbl.Append(os.Color.G)
            sbClrTbl.Append("\blue")
            sbClrTbl.Append(os.Color.B)
            sbClrTbl.Append(";")
            AddedColors.Add(os.Color)
        Else
            'Find the color number assigned
            For f As Integer = 0 To AddedColors.Count - 1
                If os.Color = AddedColors(f) Then
                    os.ColorTableNumber = f
                    Exit For
                End If
            Next
        End If

    End Sub

    'This will set incremental changes to the rtf settings
    '06/12/2005
    'JPT
    Private fontNumber As Integer = -1
    Private fontSize As Single = 0
    Private fontColor As Integer = -1
    Private bBold As Boolean
    Private bItalic As Boolean
    Private bStrike As Boolean
    Private bUderline As Boolean

    ''' <remarks>Forces the formatter to start fresh</remarks>
    Public Sub InitRtf()
        fontNumber = -1
        fontSize = 0
        fontColor = -1
    End Sub

    Private Function InsertRtfAsNeeded(ByRef cf As clsOneSetting) As Integer
        Dim sizeIncrease As Integer = 0
        Dim bChanged As Boolean = False
        'Any change in the font color or size
        If Not Optimized Then
            If fontNumber <> cf.FontTableNumber Then
                fontNumber = cf.FontTableNumber
                mSbRtf.Append(RTF_f)
                mSbRtf.Append(fontNumber)
                sizeIncrease += RTF_f.Length
                bChanged = True
            End If

            If fontSize <> cf.Font.Size * 2 Then
                fontSize = cf.Font.Size * 2
                mSbRtf.Append(RTF_fs)
                mSbRtf.Append(fontSize)
                sizeIncrease += RTF_fs.Length
                bChanged = True
            End If

        End If

        If fontColor <> cf.ColorTableNumber Then
            fontColor = cf.ColorTableNumber
            mSbRtf.Append(RTF_cf)
            mSbRtf.Append(fontColor)
            sizeIncrease += RTF_cf.Length
            bChanged = True
        End If

        'Add to it the BOLD if needed
        If bBold <> cf.Font.Bold Then
            bBold = cf.Font.Bold
            If bBold Then
                mSbRtf.Append(RTF_b)
                sizeIncrease += RTF_b.Length
            Else
                mSbRtf.Append(RTF_b0)
                sizeIncrease += RTF_b0.Length
            End If
            bChanged = True
        End If

        'Add to it the ITALICS if needed
        If bItalic <> cf.Font.Italic Then
            bItalic = cf.Font.Italic
            If bItalic Then
                mSbRtf.Append(RTF_i)
                sizeIncrease += RTF_i.Length
            Else
                mSbRtf.Append(RTF_i0)
                sizeIncrease += RTF_i0.Length
            End If
            bChanged = True
        End If

        'Add to it the STRIKE if needed
        If bStrike <> cf.Font.Strikeout Then
            bStrike = cf.Font.Strikeout
            If bStrike Then
                mSbRtf.Append(RTF_strike)
                sizeIncrease += RTF_strike.Length
            Else
                mSbRtf.Append(RTF_strike0)
                sizeIncrease += RTF_strike0.Length
            End If
            bChanged = True
        End If

        'Add to it the UNDERLINE if needed
        If bUderline <> cf.Font.Underline Then
            bUderline = cf.Font.Underline
            If bUderline Then
                mSbRtf.Append(RTF_ul)
                sizeIncrease += RTF_ul.Length
            Else
                mSbRtf.Append(RTF_ul0)
                sizeIncrease += RTF_ul0.Length
            End If
            bChanged = True
        End If

        If bChanged Then
            mSbRtf.Append(RTF_space)
        End If

        Return sizeIncrease
    End Function

    Private Sub EscapeRtf(ByRef sText As String)
        'This will cause problems with the rtf codes if we don't handle it.
        If sText.Contains(RTF_bs) Then
            sText = sText.Replace(RTF_bs, RTF_bsr)
        End If
        If sText.Contains(RTF_lcb) Then
            sText = sText.Replace(RTF_lcb, RTF_lcbr)
        End If
        If sText.Contains(RTF_rcb) Then
            sText = sText.Replace(RTF_rcb, RTF_rcbr)
        End If

    End Sub

    Public Function BuildHighlightRtf(ByVal selText As String, ByVal matches As List(Of ReplacementMatch)) As String
        Dim lastIndex As Integer = 0
        Dim lastLength As Integer = 0
        Dim bMatch As Boolean = False
        Dim newLines() As String
        Dim n As Integer, nlCt As Integer

        Dim w As ReplacementMatch
        EscapeRtf(selText)
        mSbRtf.Length = 0
        lastIndex = 0
        mSbRtf.Append(RtfHeader)
        'Get the matches
        For Each w In matches
            InsertRtfAsNeeded(StandardSettings(Words.All))
            newLines = selText.Substring(lastIndex, w.Index - lastIndex).Split(CChar(vbLf))
            nlCt = newLines.Length - 2
            For n = 0 To nlCt
                mSbRtf.Append(newLines(n))
                mSbRtf.Append(RTF_par)
                mSbRtf.Append(vbLf)
            Next
            mSbRtf.Append(newLines(n))
            InsertRtfAsNeeded(StandardSettings(Words.Highlight))
            mSbRtf.Append(w.Replacement)
            lastIndex = w.Index + w.Length
        Next

        InsertRtfAsNeeded(StandardSettings(Words.All))
        newLines = selText.Substring(lastIndex).Split(CChar(vbLf))
        nlCt = newLines.Length - 2
        For n = 0 To nlCt
            mSbRtf.Append(newLines(n))
            mSbRtf.Append(RTF_par)
            mSbRtf.Append(vbLf)
        Next
        mSbRtf.Append(newLines(n))
        mSbRtf.Append(RTF_par)

        mSbRtf.Append(RtfFooter)
        Return mSbRtf.ToString

    End Function



    ''' <summary>
    ''' Builds rtf text from the input string
    ''' </summary>
    Public Sub BuildRtf(ByRef selRTF As String, ByVal selText As String)
        Dim lastIndex As Integer = 0
        Dim lastLength As Integer = 0
        Dim multiLineString As Boolean = False
        Dim newLines() As String
        Dim n As Integer, nlCt As Integer
        Dim bMatch As Boolean = False
        Dim bMatchIsComment As Boolean = False
        Try

            'For each match in the string we first look for the most common.
            'Eval one match at a time'"\([^()]*\)|\n|[A-Z][-+]?[0-9]*\.?[0-9]"
            EscapeRtf(selText)
            mSbRtf.Length = 0
            'mSbRtf.EnsureCapacity(selText.Length * 2)
            lastIndex = 0
            lastLength = 0
            mSbRtf.Append(RtfHeader)
            If ColorByMode Then
                InsertRtfAsNeeded(StandardSettings(mLastCuttingMode))
            Else
                InsertRtfAsNeeded(StandardSettings(Words.All))
            End If
            'Get the matches
            Dim match As Match = mRegexWords.Match(selText)
            While match.Success
                With match
                    If .Length = 0 Then
                        Continue While
                    End If
                    'Prevent matching a letter without a number following
                    If Not bMatch Then
                        If Not ColorByMode Then
                            InsertRtfAsNeeded(StandardSettings(Words.All))
                        End If
                    End If
                    bMatch = False
                    If multiLineString Then
                        newLines = selText.Substring(lastIndex, .Index - lastIndex).Split(CChar(vbLf))
                        nlCt = newLines.Length - 2
                        For n = 0 To nlCt
                            mSbRtf.Append(newLines(n))
                            mSbRtf.Append(RTF_par)
                            mSbRtf.Append(vbLf)
                        Next
                        mSbRtf.Append(newLines(n))
                    Else
                        mSbRtf.Append(selText.Substring(lastIndex, .Index - lastIndex))
                    End If

                    If ColorByMode AndAlso bMatchIsComment Then
                        InsertRtfAsNeeded(StandardSettings(mLastCuttingMode))
                    End If

                    multiLineString = False
                    bMatchIsComment = False

                    If .Value = vbLf Then 'Is this a newline
                        mSbRtf.Append(RTF_par)
                    ElseIf MatchIsComment(match) Then
                        bMatchIsComment = True
                        'Comments. A comment match may have newline characters.
                        InsertRtfAsNeeded(StandardSettings(Words.Comment))
                        multiLineString = selText.IndexOf(vbLf, .Index, .Length) > -1
                        bMatch = True
                    Else
                        'Output word
                        'For each word we need to insert the chars in between the last match and this one.
                        If ColorByMode Then
                            bMatch = MatchCuttingMode(match)
                        Else

                            'Blockskip. /2 or /
                            If .Value.Chars(0) = mSkipChar Then
                                InsertRtfAsNeeded(StandardSettings(Words.Skip))
                                bMatch = True
                            End If

                            'Enumerate all the custom groups
                            'st will = 0 if no comment exists and 1 if one does
                            'Group(0) = comment if one exists

                            For r As Integer = 1 To CustomSetings.Count
                                If .Groups(r).Success Then
                                    InsertRtfAsNeeded(CustomSetings(r - 1))
                                    bMatch = True
                                    Exit For
                                End If
                            Next


                            If Not bMatch Then
                                'All other gcodes
                                bMatch = MatchNonCuttingMode(match)
                            End If
                        End If

                    End If
                    lastIndex = .Index
                    lastLength = .Length
                    match = .NextMatch()
                End With
            End While
            mSbRtf.Append(selText.Substring(lastIndex))
            mSbRtf.Append(RtfFooter)
            selRTF = mSbRtf.ToString

        Catch
        End Try

    End Sub


    ''' <summary>
    ''' Builds rtf text for the sample
    ''' </summary>
    Public Function BuildRtfSample(ByRef selRtf As String) As Boolean
        Dim strDisplay As String = ""
        If Not BuildRtfForThisScheme() Then
            selRtf = ""
            Return False
        End If
        InsertRtfAsNeeded(StandardSettings(Words.All))
        mSbRtf.Length = 0
        mSbRtf.Append(RtfHeader)
        For Each s As clsOneSetting In StandardSettings
            strDisplay = String.Copy(s.MatchText & " " & s.Description)
            EscapeRtf(strDisplay)
            InsertRtfAsNeeded(s)
            mSbRtf.Append(strDisplay)
            mSbRtf.Append(RTF_par)
            mSbRtf.Append(vbLf)
        Next

        For Each s As clsOneSetting In CustomSetings
            If s.MatchText.Length = 0 Then
                mRegexParseError = s.Description & " should not be an empty match."
                Return False
            End If
            strDisplay = String.Copy(s.MatchText & " " & s.Description)
            EscapeRtf(strDisplay)
            InsertRtfAsNeeded(s)
            mSbRtf.Append(strDisplay)
            mSbRtf.Append(RTF_par)
            mSbRtf.Append(vbLf)
        Next
        mSbRtf.Append(RTF_par)
        mSbRtf.Append(vbLf)
        mSbRtf.Append(RtfFooter)
        selRtf = mSbRtf.ToString
        Return True
    End Function
    'Returns the last mode of toolpath and also sets the internal flag
    Public Function GetLastMode(ByVal selText As String) As Integer
        Dim m As Match
        Dim matches As MatchCollection
        Dim r, ct As Integer
        matches = mRegexModeWords.Matches(selText)
        ct = matches.Count
        For r = ct - 1 To 0 Step -1
            m = matches(r)
            If m.Value.Chars(0) = "G"c Then
                Select Case CInt(SingleTryParse(m.Value.Substring(1)))
                    Case 0
                        mLastCuttingMode = Words.G00
                        Return mLastCuttingMode
                    Case 1
                        mLastCuttingMode = Words.G01
                        Return mLastCuttingMode
                    Case 2
                        mLastCuttingMode = Words.G02
                        Return mLastCuttingMode
                    Case 3
                        mLastCuttingMode = Words.G03
                        Return mLastCuttingMode
                    Case 41
                        mLastCuttingMode = Words.G41
                        Return mLastCuttingMode
                    Case 42
                        mLastCuttingMode = Words.G42
                        Return mLastCuttingMode
                    Case 90
                        mLastCuttingMode = Words.G90
                        Return mLastCuttingMode
                    Case 91
                        mLastCuttingMode = Words.G91
                        Return mLastCuttingMode
                End Select
            End If
        Next
    End Function

    Private Function MatchCuttingMode(ByVal w As Match) As Boolean
        If w.Value.Chars(0) = "G"c Then
            Select Case CInt(SingleTryParse(w.Value.Substring(1)))
                Case 0
                    mLastCuttingMode = Words.G00
                    InsertRtfAsNeeded(StandardSettings(Words.G00))
                    Return True
                Case 1
                    mLastCuttingMode = Words.G01
                    InsertRtfAsNeeded(StandardSettings(Words.G01))
                    Return True
                Case 2
                    mLastCuttingMode = Words.G02
                    InsertRtfAsNeeded(StandardSettings(Words.G02))
                    Return True
                Case 3
                    mLastCuttingMode = Words.G03
                    InsertRtfAsNeeded(StandardSettings(Words.G03))
                    Return True
                Case 40
                    InsertRtfAsNeeded(StandardSettings(mLastCuttingMode))
                    Return True
                Case 41
                    InsertRtfAsNeeded(StandardSettings(Words.G41))
                    Return True
                Case 42
                    InsertRtfAsNeeded(StandardSettings(Words.G42))
                    Return True
                Case 90
                    InsertRtfAsNeeded(StandardSettings(Words.G90))
                    Return True
                Case 91
                    InsertRtfAsNeeded(StandardSettings(Words.G91))
                    Return True
            End Select
        End If
        Return False
    End Function

    Private Function SingleTryParse(ByVal s As String) As Single
        Dim ret As Single = 0
        Single.TryParse(s, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, ret)
        Return ret
    End Function

    Private Function MatchNonCuttingMode(ByVal w As Match) As Boolean
        If w.Value.Chars(0) = "X"c Then
            InsertRtfAsNeeded(StandardSettings(Words.X_Pos))
            Return True
        ElseIf w.Value.Chars(0) = "Y"c Then
            InsertRtfAsNeeded(StandardSettings(Words.Y_Pos))
            Return True
        ElseIf w.Value.Chars(0) = "Z"c Then
            InsertRtfAsNeeded(StandardSettings(Words.Z_Pos))
            Return True
        End If

        If w.Value.Chars(0) = "G"c Then
            If w.Value.Substring(1).Length > 0 Then
                Dim ret As Single
                Single.TryParse(w.Value.Substring(1), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, ret)
                Select Case CInt(ret)
                    Case 0
                        InsertRtfAsNeeded(StandardSettings(Words.G00))
                        Return True
                    Case 1
                        InsertRtfAsNeeded(StandardSettings(Words.G01))
                        Return True
                    Case 2
                        InsertRtfAsNeeded(StandardSettings(Words.G02))
                        Return True
                    Case 3
                        InsertRtfAsNeeded(StandardSettings(Words.G03))
                        Return True
                    Case 40
                        InsertRtfAsNeeded(StandardSettings(Words.G40))
                        Return True
                    Case 41
                        InsertRtfAsNeeded(StandardSettings(Words.G41))
                        Return True
                    Case 42
                        InsertRtfAsNeeded(StandardSettings(Words.G42))
                        Return True
                    Case 90
                        InsertRtfAsNeeded(StandardSettings(Words.G90))
                        Return True
                    Case 91
                        InsertRtfAsNeeded(StandardSettings(Words.G91))
                        Return True
                End Select
            End If
        End If
        Return False
    End Function

    Private Function InsertCommment() As String
        If mCommentMatch.Length > 0 Then
            Return mCommentMatch & "|"
        Else
            Return ""
        End If
    End Function

    Public ReadOnly Property CommentRegexString() As String
        Get
            Return mCommentMatch
        End Get
    End Property

    Private Sub BuildCommentMatch(Optional ByVal allowPreceedingSpace As Boolean = False)
        mCommentMatch = ""
        mHasCommentMatch = False

        If mCommentString.Contains("(*)") Or mCommentString.Contains("()") Then 'Legacy support
            mCommentMatch = "\([^()]*\)"
        End If

        If mCommentString.Contains("{}") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= "{[^{}]*}"
        End If
        If mCommentString.Contains("[]") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= "\[[[]]*\]"
        End If
        If mCommentString.Contains("<>") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= "\<[<>]*\>"
        End If

        If mCommentString.Contains("""""") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= """.*"""
        End If

        'Single characters
        If mCommentString.Contains(";") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= ";.*" & STR_EOL
        End If
        If mCommentString.Contains(":") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= ":.*" & STR_EOL
        End If
        If mCommentString.Contains("'") Then
            If mCommentMatch.Length > 0 Then mCommentMatch &= "|"
            mCommentMatch &= "'.*" & STR_EOL
        End If

        If mCommentMatch.Length > 0 Then
            If allowPreceedingSpace Then
                mCommentMatch = "(?<Comment>\x20*" & mCommentMatch & ")"
            Else
                mCommentMatch = "(?<Comment>" & mCommentMatch & ")"
            End If
            mHasCommentMatch = True
        End If
    End Sub


    Friend Function MatchIsComment(ByVal m As Match) As Boolean
        Return m.Groups("Comment").Success
    End Function

    Public Function FilterJunk(ByRef sText As String) As String
        Dim match As String = My.Resources.datRegJunkFilter
        If match.Length = 0 Then
            Return JunkFilter(sText)
        Else
            Return Regex.Replace(sText, match, String.Empty, RegexOptions.Compiled Or RegexOptions.CultureInvariant)
        End If
    End Function

    'Some files only have only a line feed charecter.
    'this will fix that.
    Function JunkFilter(ByVal inStr As String) As String
        Dim Buff As String
        Dim CharVal As Integer
        Dim strBuilder As New StringBuilder
        Dim r As Integer

        Do Until r >= inStr.Length
            'Read until it finds something
            Buff = inStr(r) 'Get a chr
            CharVal = Asc(Buff)
            r += 1
            If CharVal > 32 And CharVal < 127 Then 'Found something
                strBuilder.Append(Buff)
                Exit Do
            End If
        Loop

        Do Until r >= inStr.Length
            Buff = inStr(r) 'Get a chr
            CharVal = Asc(Buff)
            r += 1
            If CharVal > 31 And CharVal < 127 Then 'Normal characters
                strBuilder.Append(Buff)
            End If

            If CharVal = 10 Then 'Line feed
                strBuilder.Append(vbCrLf)
            End If
        Loop

        If CharVal <> 10 Then 'If last was not a line feed
            strBuilder.Append(vbCrLf)
        End If
        Buff = strBuilder.ToString
        Return Buff 'Success!

    End Function

    Public Function ExpandAll(ByRef sText As String) As String
        Dim match As String = InsertCommment() & My.Resources.datRegExpandSpaces
        Return Regex.Replace(sText, match, AddressOf ExpandAllEvaluator, RegexOptions.Compiled Or RegexOptions.CultureInvariant)
    End Function

    Private Function ExpandAllEvaluator(ByVal m As Match) As String
        If MatchIsComment(m) Then
            Return m.Value
        End If
        If m.Value.Length = 2 Then
            Return m.Value.Insert(1, " ")
        Else
            Return m.Value
        End If
    End Function

    Public Function ContractAll(ByRef sText As String) As String
        Dim match As String = InsertCommment() & My.Resources.datContractSpaces
        Return Regex.Replace(sText, match, AddressOf ContractAllEvaluator, RegexOptions.Compiled Or RegexOptions.CultureInvariant)
    End Function

    Private Function ContractAllEvaluator(ByVal m As Match) As String
        If MatchIsComment(m) Then
            Return m.Value
        End If
        Return ""
    End Function


    Private Function FontToString(ByVal f As Font) As String
        If f Is Nothing Then Return String.Empty
        Return f.FontFamily.Name & _
        "|" & _
        f.Size.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) & _
        "|" & _
        f.Style & _
        "|" & _
        f.Unit & _
        "|" & _
        f.GdiCharSet.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) & _
        "|" & _
        f.GdiVerticalFont.ToString(System.Globalization.NumberFormatInfo.InvariantInfo)
    End Function

    Private Function StringToFont(ByVal s As String) As Font
        Try
            Dim sep As Char = "|"c
            Dim sp() As String = s.Split(sep)
            Return New Font(sp(0), _
             Single.Parse(sp(1), System.Globalization.NumberFormatInfo.InvariantInfo), _
             CType(sp(2), FontStyle), _
             CType(sp(3), GraphicsUnit), _
             Convert.ToByte(sp(4), System.Globalization.NumberFormatInfo.InvariantInfo), _
             Convert.ToBoolean(sp(5), System.Globalization.NumberFormatInfo.InvariantInfo))
        Catch
            Return Nothing
        End Try
    End Function
End Class
