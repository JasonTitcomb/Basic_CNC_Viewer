Imports System.Collections.Generic
Imports System.ComponentModel

Friend Class frmGraphicsDetails
    Private mDetails As New clsDetails
    Private mRapidRate As Single

    Public Sub SetDetails(ByVal m As clsMotionRecord)

        If mDetails.mLastRecord Is Nothing Then
            mDetails.MotionUnits = m.Units
        End If

        If mDetails.mElement IsNot Nothing Then
            mDetails.mLastRecord = mDetails.mElement
        End If
        mDetails.mElement = m
        Select Case mDetails.mElement.Units
            Case MachineUnits.ENGLISH
                mDetails.NUMBERFORMAT = "##0.0###"
                mDetails.surfaceInchesPerMin = m.Speed * 12.0F 'Convert ot surface feet to inches per min
            Case MachineUnits.METRIC
                mDetails.NUMBERFORMAT = "###0.0##"
                mDetails.surfaceInchesPerMin = m.Speed * 39.37008F 'Convert surface meters to inches per min
        End Select
        Me.pgDetails.SelectedObject = mDetails
    End Sub

    Private Class clsDetails
        Friend mTotalCutTime As Double
        Friend mTotalRapidTime As Double
        Friend mElement As clsMotionRecord
        Friend NUMBERFORMAT As String = "##0.0###"
        Friend surfaceInchesPerMin As Single
        Friend mLastRecord As clsMotionRecord

        Private Function GetStartDist() As String
            Dim delta As Single
            delta = Distance3(mElement.Xold, mElement.Yold, mElement.Zold, mLastRecord.Xold, mLastRecord.Yold, mLastRecord.Zold)
            Return AdjustForUnits(delta)
        End Function

        Private Function GetEndDist() As String
            Dim delta As Single
            delta = Distance3(mElement.Xpos, mElement.Ypos, mElement.Zpos, mLastRecord.Xpos, mLastRecord.Ypos, mLastRecord.Zpos)
            Return AdjustForUnits(delta)
        End Function

        Private Function GetLenDiff() As String
            Dim len1, len2 As Single
            len1 = Distance3(mElement.Xpos, mElement.Ypos, mElement.Zpos, mElement.Xold, mElement.Yold, mElement.Zold)
            len2 = Distance3(mLastRecord.Xpos, mLastRecord.Ypos, mLastRecord.Zpos, mLastRecord.Xold, mLastRecord.Yold, mLastRecord.Zold)
            Return AdjustForUnits(Math.Abs(len1 - len2))

        End Function

        Private Function Distance3(ByVal X1 As Single, ByVal Y1 As Single, ByVal Z1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal Z2 As Single) As Single
            Return CSng(System.Math.Sqrt(((X1 - x2) ^ 2) + ((Y1 - y2) ^ 2) + ((Z1 - Z2) ^ 2)))
        End Function

        Private Function AdjustForUnits(ByVal val As Single) As String
            If MotionUnits <> MachineUnits.ENGLISH Then
                val *= 25.4F
            End If
            Select Case MotionUnits
                Case MachineUnits.ENGLISH
                    Return val.ToString(NUMBERFORMAT & " in")
                Case Else
                    Return val.ToString(NUMBERFORMAT & " mm")
            End Select

        End Function

        <Description("The cnc line of code"),
         Category("Element")>
        Public Property CodeLine() As String
            Get
                Return mElement.Codestring
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The motion type of the element"),
         Category("Element")>
        Public Property MotionType() As Motion
            Get
                Return mElement.MotionType
            End Get
            Set(ByVal value As Motion)

            End Set
        End Property

        <Description("The motion units"),
      Category("Element")>
        Private mUnits As MachineUnits
        Public Property MotionUnits() As MachineUnits
            Get
                Return mUnits
            End Get
            Set(ByVal value As MachineUnits)
                mUnits = value
            End Set
        End Property

        <Description("The last position of the element"),
         Category("Element")>
        Public Property LastPosition() As String
            Get
                Return "X" & mElement.Xold.ToString(NUMBERFORMAT) & ", Y" & mElement.Yold.ToString(NUMBERFORMAT) & ", Z" & mElement.Zold.ToString(NUMBERFORMAT)
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The current position of the element"),
         Category("Element")>
        Public Property CurrentPosition() As String
            Get
                Return "X" & mElement.Xpos.ToString(NUMBERFORMAT) & ", Y" & mElement.Ypos.ToString(NUMBERFORMAT) & ", Z" & mElement.Zpos.ToString(NUMBERFORMAT)
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("Line angle in XY plane"),
          Category("Element")>
        Public Property LineAngle_XY() As String
            Get
                If MotionType = Motion.LINE Then
                    Dim angle As Single = MG_BasicViewer.AngleFromPoint(mElement.Xpos - mElement.Xold, mElement.Ypos - mElement.Yold, False)
                    Return RadianAngleToDegString(angle)
                Else
                    Return "-"
                End If
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("Line angle in YZ plane"),
        Category("Element")>
        Public Property LineAngle_YZ() As String
            Get
                If MotionType = Motion.LINE Then
                    Dim angle As Single = MG_BasicViewer.AngleFromPoint(mElement.Ypos - mElement.Yold, mElement.Zpos - mElement.Zold, False)
                    Return RadianAngleToDegString(angle)
                Else
                    Return "-"
                End If
            End Get
            Set(ByVal value As String)

            End Set
        End Property
        <Description("Line angle in ZX plane"),
        Category("Element")>
        Public Property LineAngle_ZX() As String
            Get
                If MotionType = Motion.LINE Then
                    Dim angle As Single = MG_BasicViewer.AngleFromPoint(mElement.Zpos - mElement.Zold, mElement.Xpos - mElement.Xold, False)
                    Return RadianAngleToDegString(angle)
                Else
                    Return "-"
                End If
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The current rotary position of the element"),
         Category("Element")>
        Public Property RotaryPosition() As String
            Get
                Return RadianAngleToDegString(mElement.OldRotaryPos) & ", " & RadianAngleToDegString(mElement.NewRotaryPos)
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The center of the arc"),
         Category("Element")>
        Public Property ArcCenter() As String
            Get
                If MotionType = Motion.CCARC Or MotionType = Motion.CWARC Then
                    Return "X" & mElement.Xcentr.ToString(NUMBERFORMAT) & ", Y" & mElement.Ycentr.ToString(NUMBERFORMAT) & ", Z" & mElement.Zcentr.ToString(NUMBERFORMAT)
                Else
                    Return "-"
                End If
            End Get
            Set(ByVal value As String)

            End Set
        End Property


        <Description("The start angle of the arc"),
         Category("Element")>
        Public Property ArcStartAngle() As String
            Get
                If MotionType = Motion.CCARC Or MotionType = Motion.CWARC Then
                    Return RadianAngleToDegString(mElement.Sang)
                Else
                    Return "-"
                End If
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The end angle of the arc"),
         Category("Element")>
        Public Property ArcEndAngle() As String
            Get
                If MotionType = Motion.CCARC Or MotionType = Motion.CWARC Then
                    Return RadianAngleToDegString(mElement.Eang)
                Else
                    Return "-"
                End If
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The radius of the arc"), Category("Element")>
        Public Property ArcRadius() As String
            Get
                If MotionType = Motion.CCARC Or MotionType = Motion.CWARC Then
                    Return AdjustForUnits(mElement.Rad)
                Else
                    Return "-"
                End If
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The plane the arc is on"), Category("Element")>
        Public Property ArcPlane() As String
            Get
                Select Case mElement.ArcPlane
                    Case 0
                        Return "XY_PLN"
                    Case 1
                        Return "XZ_PLN"
                    Case 2
                        Return "YZ_PLN"
                End Select
                Return CType(mElement.ArcPlane, Motion).ToString
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The current tool"), Category("Element")>
        Public Property Tool() As String
            Get
                Return mElement.Tool.ToString(NUMBERFORMAT)
            End Get
            Set(ByVal value As String)

            End Set
        End Property


        <Description("Line numbers"),
 Category("Measure")>
        Public Property SequenceNumbers() As String
            Get
                If mLastRecord Is Nothing Then
                    Return "Select a second element"
                Else
                    Try
                        Return mElement.Linenumber & " - " & mLastRecord.Linenumber
                    Catch ex As Exception
                        Return "Error"
                    End Try
                End If
            End Get
            Set(ByVal value As String)

            End Set
        End Property



        <Description("The distance between the start points in 3D"),
  Category("Measure")>
        Public Property DistanceBetweenStarts() As String
            Get
                If mLastRecord Is Nothing Then
                    Return "Select a second element"
                Else
                    Try
                        Return GetStartDist()
                    Catch ex As Exception
                        Return "Error"
                    End Try
                End If
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The distance between the end points in 3D"),
Category("Measure")>
        Public Property DistanceBetweenEnds() As String
            Get
                If mLastRecord Is Nothing Then
                    Return "Select a second element"
                Else
                    Try
                        Return GetEndDist()
                    Catch ex As Exception
                        Return "Error"
                    End Try
                End If
            End Get
            Set(ByVal value As String)

            End Set
        End Property


        <Description("The difference in length"),
 Category("Measure")>
        Public Property LenghtDifference() As String
            Get
                If mLastRecord Is Nothing Then
                    Return "Select a second element"
                Else
                    Try
                        Return GetLenDiff()
                    Catch ex As Exception
                        Return "Error"
                    End Try
                End If
            End Get
            Set(ByVal value As String)

            End Set
        End Property


        <Description("The cutter compensation side of the selected element"),
      Category("Element")>
        Public Property CutterComp() As String
            Get
                Return mElement.Comp.ToString()
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("Feed mode"),
        Category("Speed Feed")>
        Public Property FeedMode() As FeedMode
            Get
                Return mElement.FeedMode
            End Get
            Set(ByVal value As FeedMode)

            End Set
        End Property

        <Description("Speed mode RPM or SFPM"),
        Category("Speed Feed")>
        Public Property SpeedMode() As SpeedMode
            Get
                Return mElement.SpeedMode
            End Get
            Set(ByVal value As SpeedMode)

            End Set
        End Property

        <Description("The current speed"),
          Category("Speed Feed")>
        Public Property Speed() As String
            Get
                Return mElement.Speed.ToString(NUMBERFORMAT)
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The calculated RPM"),
          Category("Speed Feed")>
        Public Property RPM() As String
            Get
                Select Case mElement.SpeedMode
                    Case MacGen.SpeedMode.SURFACE_SPEED
                        Return Math.Round(mElement.RPM, 0).ToString(NUMBERFORMAT)
                    Case MacGen.SpeedMode.RPM
                        Return "-"
                End Select
                Return "?"
            End Get
            Set(ByVal value As String)

            End Set
        End Property


        <Description("The current feed rate"),
          Category("Speed Feed")>
        Public Property Feed() As String
            Get
                Return mElement.FeedRate.ToString(NUMBERFORMAT)
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The cutting length of the selected element"),
          Category("Speed Feed")>
        Public Property CuttingLength() As String
            Get
                Return AdjustForUnits(mElement.CuttingLength)
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The rapid length of the selected element"),
          Category("Speed Feed")>
        Public Property RapidLength() As String
            Get
                Return AdjustForUnits(mElement.RapidLength)
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("Maximum RPM"),
       Category("Speed Feed")>
        Public Property MaxRpm() As String
            Get
                Return mElement.MaxRpm.ToString(NUMBERFORMAT)
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The diameter at which the RPM reaches maximum"),
       Category("Speed Feed")>
        Public Property MaxRpmDiameter() As String
            Get
                Select Case mElement.SpeedMode
                    Case MacGen.SpeedMode.SURFACE_SPEED
                        'Determine the diameter where the rpm maxes out.
                        Dim max As Double = (surfaceInchesPerMin / Math.PI / mElement.MaxRpm)
                        Return max.ToString(NUMBERFORMAT)
                    Case MacGen.SpeedMode.RPM
                        Return "-"
                End Select
                Return "?"
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The motion time of the selected element  dd:hh:mm:ss"), _
        Category("Time")> _
        Public Property ElementTime() As String
            Get
                Return FormatTime(mElement.MotionTime)
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        Private mTotalTime As Single
        <Description("The total cutting time dd:hh:mm:ss"), _
        Category("Time")> _
        Public Property TotalCutTime() As String
            Get
                Return FormatTime(mTotalCutTime)
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        <Description("The total rapid time based on unit/min  dd:hh:mm:ss"), _
        Category("Time")> _
        Public Property TotalRapidTime() As String
            Get
                Return FormatTime(mTotalRapidTime)
            End Get
            Set(ByVal value As String)

            End Set
        End Property
        <Description("The total time based on unit/min  dd:hh:mm:ss"), _
        Category("Time")> _
        Public Property TotalTime() As String
            Get
                Return FormatTime(mTotalRapidTime + mTotalCutTime)
            End Get
            Set(ByVal value As String)

            End Set
        End Property

        Friend Function FormatTime(ByVal t As Double) As String

            If Double.IsInfinity(t) Then
                Return "0"
            End If

            If Double.IsNaN(t) Then
                Return "0"
            End If

            If t < 0.0000001 Then
                Return "0"
            End If

            Dim s As String = TimeSpan.FromMinutes(t).ToString
            If s.Contains("."c) AndAlso (s.LastIndexOf("."c) + 3) < s.Length Then
                Return s.Substring(0, s.LastIndexOf(".") + 3)
            Else
                Return s
            End If
        End Function

        Private Function RadianAngleToDegString(ByVal angle As Single) As String
            Return (angle * (180.0 / Math.PI)).ToString(NUMBERFORMAT, System.Globalization.NumberFormatInfo.InvariantInfo) & "°"
        End Function
    End Class

    Private Sub frmGraphicsDetails_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.GraphicsDetailsLocation = Me.Location
        My.Settings.GraphicsDetailsSize = Me.Size
        My.Settings.Save()
    End Sub

    Private Sub frmGraphicsDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            For Each c As Control In Me.pgDetails.Controls
                Dim toolStrip As ToolStrip = TryCast(c, ToolStrip)
                If toolStrip IsNot Nothing Then
                    ' Found toolstrip
                    toolStrip.Items(4).Visible = False
                    Dim tsbPrint As ToolStripButton
                    'Printing
                    tsbPrint = New System.Windows.Forms.ToolStripButton()
                    With tsbPrint
                        .ToolTipText = "Print"
                        .Image = My.Resources.PrintHS
                        AddHandler .Click, AddressOf Print_Clicked
                    End With
                    toolStrip.Items.Add(tsbPrint)
                    Exit For
                End If

            Next
            Me.Location = My.Settings.GraphicsDetailsLocation
            EnsureFormIsOnScreen(Me)
            Me.Size = My.Settings.GraphicsDetailsSize
        Catch
        End Try
    End Sub

    Friend Sub SetGraphData(ByVal mrs As List(Of clsMotionRecord), ByVal totalTime As Double)
        Dim tool As Single
        Dim lastTool As Single
        Dim toolTime As Double = 0
        Dim percentTime As Integer
        Dim toolColor As Color
        Dim tooltext As String = ""

        If mrs.Count = 0 Then Return

        Try

            tool = mrs(0).Tool
            toolColor = mrs(0).DrawColor
            MG_Graph1.ClearAllBars()

            For Each m As clsMotionRecord In mrs
                toolTime += m.MotionTime

                If tool <> m.Tool Then
                    tooltext = "T" & tool.ToString
                    If totalTime > 0 Then
                        percentTime = CInt(100 * (toolTime / totalTime))
                    Else
                        percentTime = 0
                    End If
                    MG_Graph1.AddColorBar(toolColor, tooltext & "   " & mDetails.FormatTime(toolTime), percentTime)
                    tool = m.Tool
                    toolTime = 0
                    toolColor = m.DrawColor
                End If
                lastTool = m.Tool
            Next

            If totalTime > 0 Then
                percentTime = CInt(100 * (toolTime / totalTime))
            Else
                percentTime = 0
            End If
            tooltext = "T" & lastTool.ToString
            MG_Graph1.AddColorBar(toolColor, tooltext & "   " & mDetails.FormatTime(toolTime), percentTime)
            MG_Graph1.Invalidate()
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Sub

    Private Sub EnsureFormIsOnScreen(ByVal f As Form)
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

    Private Sub Print_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim prn As New Printing.PrintDocument
            ' Handle the page events
            AddHandler prn.PrintPage, AddressOf Me.PrintPageHandler
            ' Do the print (Printing handled by the print page handler)
            prn.Print()
            ' Remove the page handler
            RemoveHandler prn.PrintPage, AddressOf Me.PrintPageHandler
        Catch
        End Try
    End Sub

    Private Sub PrintPageHandler(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)
        Try
            Dim output As String = "Element Details"
            Dim props As Reflection.PropertyInfo() = GetType(clsDetails).GetProperties()
            Dim fnt As Font = New Font(Me.Font.FontFamily, 16, FontStyle.Regular)

            Dim ht As Single = args.Graphics.MeasureString(output, fnt).Height
            Dim vpos As Single = 50
            args.Graphics.DrawString(output, fnt, Brushes.Black, 50, vpos)

            For Each prop As Reflection.PropertyInfo In props
                Dim oVal As Object = prop.GetValue(mDetails, Nothing)
                If oVal IsNot Nothing Then
                    output = prop.Name & vbTab & oVal.ToString
                    vpos += ht
                    args.Graphics.DrawString(output, fnt, Brushes.Black, 50, vpos)
                End If
            Next
            ' Have we printed enough pages?
            args.HasMorePages = False
        Catch
        End Try

    End Sub


    Public Sub New(ByVal cutTime As Double, ByVal rapTime As Double)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mDetails.mTotalCutTime = cutTime
        mDetails.mTotalRapidTime = rapTime
    End Sub
End Class