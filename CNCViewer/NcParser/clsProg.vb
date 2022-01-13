Imports System.CodeDom
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Public Class clsProg
    Public Main As Boolean
    Public Label As String
    Public Value As Double
    'Public Index As Integer
    Public Contents As String
    Public TimesCalled As Integer = 0
    Public StartLine As Integer
    Public StartChar As Integer
    Public BlockSkip As Double = 0
    Public FileName As String
    Public SequenceNumbers As New List(Of SeqNumber)
    Public SequenceTarget As SeqNumber
    Public Words As Regex
    Public Shared MatchString As String
    Public CurMatch As Match
    Public LineNum As Integer
    Public Const BLKSKIP As String = "BLKSKIP"
    Public Const COMMENT As String = "CMT"
    Public Const DELIMIT As String = "DELIMT"
    Public Const PROG_START As String = "PRS"
    Public Const VARIABLE As String = "VAR"
    Public Const KEYWORD As String = "KEY"
    Public Const ADDRESS As String = "ADR"
    Public Const SYMBOL As String = "SYM"
    Public Const NUMBER As String = "NUM"
    Public Const EOB_EOL As String = "EOB"
    Public Const ELS_ERR As String = "ERR"
    Public Const STR_LIT As String = "STR"
    Public Const SKIP As String = "SKP"
    Private mCommentMatch As String

    Public Sub New(blockSkip As String, commentStr As String, ignoreWhitespace As Boolean)
        '"([A-Z]{1,2})([-+]?[0-9]*[\.,]*[0-9]*)"
        '"([A-Z]{1,2}\x20*)([-+]?[0-9]*[\.,]*[0-9]*)"
        blockSkip = blockSkip.Replace("*"c, String.Empty)
        commentStr = commentStr.Replace("*"c, String.Empty)
        mCommentMatch = BuildCommentMatch(commentStr)
        Dim skipChars As String = ""
        If blockSkip IsNot Nothing Then
            For Each c As Char In blockSkip.ToCharArray
                skipChars += Regex.Escape(c)
            Next
        End If

        Dim sb As New Text.StringBuilder

        sb.Append(mCommentMatch)
        sb.Append("(?<").Append(BLKSKIP).Append(">").Append(skipChars).Append("[0-9]*)|")
        sb.Append("(?<" & DELIMIT & ">,)|")
        'sb.Append("(?<" & KEYWORD & ">IF|THEN|EQ|NE|GT|LT|LE|GE|GOTO|END|AND|OR|[A-Z]{2,})|")
        If ignoreWhitespace Then
            sb.Append("(?<").Append(ADDRESS).Append(">([A-Z]{1,2}\x20*)([-+]?[0-9]*[\.,]*[0-9]*))|")
        Else
            sb.Append("(?<").Append(ADDRESS).Append(">([A-Z]{1,2})([-+]?[0-9]*[\.,]?[0-9]*))|")
        End If
        'sb.Append("(?<" & SYMBOL & ">[+\-\[\]=\*/])|")

        sb.Append("(?<").Append(EOB_EOL).Append(">;?\u0020*\u000d?\u000a)|")
        sb.Append("(?<").Append(SKIP).Append(">%)|")
        sb.Append("(?<").Append(ELS_ERR).Append(">\S)")
        MatchString = sb.ToString
        Words = New Regex(MatchString, RegexOptions.Compiled)
        LineNum = 1
    End Sub

    Public Shared Function BuildCommentMatch(commentSetting As String) As String

        Dim commentMatch = ""
        If commentSetting.Contains("(*)") OrElse commentSetting.Contains("()") Then 'Legacy support
            commentMatch = "\([^()]*\)"
        End If

        If commentSetting.Contains("{}") Then
            If commentMatch.Length > 0 Then commentMatch &= "|"
            commentMatch &= "{[^{}]*}"
        End If
        If commentSetting.Contains("[]") Then
            If commentMatch.Length > 0 Then commentMatch &= "|"
            commentMatch &= "\[[[]]*\]"
        End If
        If commentSetting.Contains("<>") Then
            If commentMatch.Length > 0 Then commentMatch &= "|"
            commentMatch &= "\<[<>]*\>"
        End If

        If commentSetting.Contains("""""") Then
            If commentMatch.Length > 0 Then commentMatch &= "|"
            commentMatch &= """.*"""
        End If

        'Double characters
        If commentSetting.Contains("*") Then
            If commentMatch.Length > 0 Then commentMatch &= "|"
            commentMatch &= "\*.*$"
        End If

        If commentSetting.Contains(";") Then
            If commentMatch.Length > 0 Then commentMatch &= "|"
            commentMatch &= ";.*$"
        End If
        If commentSetting.Contains(":") Then
            If commentMatch.Length > 0 Then commentMatch &= "|"
            commentMatch &= ":.*$"
        End If
        If commentSetting.Contains("'") Then
            If commentMatch.Length > 0 Then commentMatch &= "|"
            commentMatch &= "'.*$"
        End If
        If commentMatch = "" Then commentMatch = "\([^()]*\)" 'default

        Return "(?m)(?<" & COMMENT & ">(?s-imnx:)" & commentMatch & ")|"
    End Function

    Public Structure SeqNumber
        Public Sub New(p As Integer, ln As Integer, val As Double)
            matchPos = p
            seqNum = val
            lineNo = ln
        End Sub
        Dim matchPos As Integer
        Dim seqNum As Double
        Dim lineNo As Integer
    End Structure

    Public Function MatchPositionInFile() As Integer
        Return CurMatch.Index + Me.StartChar
    End Function
    Public Function IsComment() As Boolean
        Return CurMatch.Groups(COMMENT).Success
    End Function

    Public Function IsError() As Boolean
        Return CurMatch.Groups(ELS_ERR).Success
    End Function

    Public Function IsAddress() As Boolean
        Return CurMatch.Groups(ADDRESS).Success
    End Function

    Public Function IsEOL() As Boolean
        If CurMatch.Groups(EOB_EOL).Success Then
            LineNum += 1
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetNextMatch(startAt As Integer) As Match
        CurMatch = Words.Match(Contents, startAt)
        Return CurMatch
    End Function

    Public Function GetNextMatch() As Match
        CurMatch = CurMatch.NextMatch
        Return CurMatch
    End Function
    Public Function CurMatchVal() As String
        Dim retStr = ""
        If CurMatch IsNot Nothing Then
            retStr = CurMatch.Value
        End If
        Return retStr
    End Function

    Public Function GetLastMatchIndex() As Integer
        Return CurMatch.Index + StartChar
    End Function

    Public Function FindSeqPos(seqNum As Double) As Integer
        SequenceTarget = SequenceNumbers.Find(Function(x) x.seqNum = seqNum)
        Return SequenceTarget.matchPos
    End Function
    Public Function HasFollowingParam(label As String) As Boolean
        Dim m As Match = CurMatch.NextMatch
        Do While m.Success
            If m.Groups(EOB_EOL).Success Then
                Exit Do
            End If
            If m.Groups(ADDRESS).Success Then
                If m.Groups(1).Value = label Then
                    Return True
                End If
            End If
            m = m.NextMatch
        Loop
        Return False
    End Function
    'Public OpenFile As Boolean
    Public Shared Function GetCurrentProgFile(ByVal prgs As Generic.List(Of clsProg), ByVal idx As Integer) As String
        Return prgs(idx).FileName
    End Function

    Public Function MatchGroupName() As String
        Dim gpidx As Integer = 0
        For Each gp As Group In CurMatch.Groups
            If gp.Success Then
                Return gp.ToString
            End If
            gpidx += 1
        Next
        Return ELS_ERR
    End Function
    Public Overrides Function ToString() As String
        Return Me.Label & Me.Value
    End Function
End Class
