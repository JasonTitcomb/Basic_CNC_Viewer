Partial Class MG_RichTextBox
    Inherits System.Windows.Forms.RichTextBox

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)

    End Sub

    'Component overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TimerVisibleTextChanged = New System.Windows.Forms.Timer(Me.components)
        Me.IdleTime = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'TimerVisibleTextChanged
        '
        Me.TimerVisibleTextChanged.Interval = 200
        '
        'IdleTime
        '
        Me.IdleTime.Interval = 2000
        '
        'MG_RichTextBox
        '
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TimerVisibleTextChanged As System.Windows.Forms.Timer
    Friend WithEvents IdleTime As System.Windows.Forms.Timer

End Class
