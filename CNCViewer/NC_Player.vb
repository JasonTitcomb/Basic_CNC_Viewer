Public Class NC_Player
    Public Event OnTick(ByVal stepVal As Integer)
    Private mTouchMode As Boolean
    Private Sub NC_Player_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler tbSpeed.TrackBar.ValueChanged, AddressOf tbSpeed_ValueChanged
        tbSpeed.TrackBar.TickStyle = TickStyle.BottomRight
    End Sub

    Public Property TouchMode() As Boolean
        Get
            Return mTouchMode
        End Get
        Set(ByVal value As Boolean)
            mTouchMode = value
            Dim size As Integer
            If mTouchMode Then
                size = 32
            Else
                size = 16
            End If
            Me.Height = size + 10
            ToolStrip1.Width = Me.Width
            tsbPlay.Image = CType(My.Resources.ResourceManager.GetObject(tsbPlay.Tag.ToString & "_" & size), Image)
            tsbPause.Image = CType(My.Resources.ResourceManager.GetObject(tsbPause.Tag.ToString & "_" & size), Image)
            tsbStop.Image = CType(My.Resources.ResourceManager.GetObject(tsbStop.Tag.ToString & "_" & size), Image)
        End Set
    End Property

    Public Property Speed() As Integer
        Get
            Return tbSpeed.Value
        End Get
        Set(ByVal value As Integer)
            tbSpeed.Value = value
        End Set
    End Property

    Private mLastTool As Single
    Public Property LastTool() As Single
        Get
            Return mLastTool
        End Get
        Set(ByVal value As Single)
            mLastTool = value
        End Set
    End Property

    Public ReadOnly Property Playing() As Boolean
        Get
            Return StepTimer.Enabled
        End Get
    End Property

    Public Property OptionStop() As Boolean
        Get
            Return tsbPause.Checked
        End Get
        Set(value As Boolean)
            tsbPause.Checked = value
        End Set
    End Property

    Public Sub StopPlay()
        StepTimer.Enabled = False
    End Sub

    Private Sub tbSpeed_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'The smallest value we want is 1
        If tbSpeed.Value > 10 Then
            StepTimer.Interval = 10
        Else
            StepTimer.Interval = 1000 - (tbSpeed.Value * 100) + 10
        End If
        Debug.Print(StepTimer.Interval.ToString)
    End Sub

    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPlay.Click
        StepTimer.Enabled = True
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbStop.Click
        StepTimer.Enabled = False
        mLastTool = -1
    End Sub

    Private Sub StepTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StepTimer.Tick
        RaiseEvent OnTick(tbSpeed.Value - (tbSpeed.Maximum \ 2))
    End Sub


End Class
