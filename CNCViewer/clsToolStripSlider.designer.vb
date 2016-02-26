Partial Class ToolStripSlider
    Inherits System.Windows.Forms.ToolStripControlHost
    ' add an event that is subscribable from the designer.
    Public Event ValueChanged()

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If
    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New(CreateControlInstance)
        'This call is required by the Component Designer.
        InitializeComponent()
    End Sub

    '/ <summary>
    '/ Create the actual control, note this is static so it can be called from the
    '/ constructor.
    '/ </summary>
    Private Shared Function CreateControlInstance() As Control
        Dim t As TrackBar = New TrackBar()
        t.AutoSize = False
        t.Height = 10
        t.TickStyle = TickStyle.None
        t.Minimum = 100
        t.Minimum = 10
        ' Add other initialization code here.
        Return t
    End Function

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub
    '/ <summary>
    '/ Attach to events we want to re-wrap
    '/ </summary>
    '/ <param name="control"></param>
    Protected Overrides Sub OnSubscribeControlEvents(ByVal control As Control)
        MyBase.OnSubscribeControlEvents(control)
        AddHandler TrackBar.ValueChanged, AddressOf trackBar_ValueChanged
    End Sub
    '/ <summary>
    '/ Detach from events.
    '/ </summary>
    '/ <param name="control"></param>
    Protected Overrides Sub OnUnsubscribeControlEvents(ByVal control As Control)
        MyBase.OnUnsubscribeControlEvents(control)
        RemoveHandler TrackBar.ValueChanged, AddressOf trackBar_ValueChanged
    End Sub

    '/ <summary>
    '/ Routing for event
    '/ TrackBar.ValueChanged -> ToolStripTrackBar.ValueChanged
    '/ </summary>
    '/ <param name="sender"></param>
    '/ <param name="e"></param>
    Private Sub trackBar_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' when the trackbar value changes, fire an event.
        RaiseEvent ValueChanged()
    End Sub

    ' set other defaults that are interesting
    Protected Overrides ReadOnly Property DefaultSize() As Size
        Get
            Return New Size(200, 16)
        End Get
    End Property
End Class
