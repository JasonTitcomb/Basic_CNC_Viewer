<Windows.Forms.Design.ToolStripItemDesignerAvailability _
(Windows.Forms.Design.ToolStripItemDesignerAvailability.ToolStrip)>
Friend Class ToolStripSlider
    Inherits ToolStripControlHost
    Public ReadOnly Property TrackBar() As TrackBar
        Get
            Return DirectCast(Control, TrackBar)
        End Get
    End Property
    Public Property Maximum() As Integer
        Get
            Return TrackBar.Maximum
        End Get
        Set(ByVal value As Integer)
            TrackBar.Maximum = value
        End Set
    End Property
    Public Property Minimum() As Integer
        Get
            Return TrackBar.Minimum
        End Get
        Set(ByVal value As Integer)
            TrackBar.Minimum = value
        End Set
    End Property
    Public Property Value() As Integer
        Get
            Return TrackBar.Value
        End Get
        Set(ByVal value As Integer)
            If value >= TrackBar.Minimum AndAlso value <= TrackBar.Maximum Then
                TrackBar.Value = value
            Else
                TrackBar.Value = TrackBar.Maximum
            End If
        End Set
    End Property

    <System.ComponentModel.Description("The value of the TrackBar / 100")>
    Public ReadOnly Property Ratio() As Double
        Get
            Return TrackBar.Value / 100
        End Get

    End Property
End Class
