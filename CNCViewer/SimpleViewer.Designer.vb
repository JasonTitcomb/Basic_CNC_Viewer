<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimpleViewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SimpleViewer))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.MG_View2 = New MacGen.MG_BasicViewer()
        Me.MG_View1 = New MacGen.MG_BasicViewer()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(30, 28)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(366, 534)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(30, 569)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Plot All"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(286, 569)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Select"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(124, 569)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Plot Range"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'MG_View2
        '
        Me.MG_View2.AxisIndicatorScale = 0.75!
        Me.MG_View2.BackColor = System.Drawing.Color.Black
        Me.MG_View2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MG_View2.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.MG_View2.DrawExtraOverlayInfo = True
        Me.MG_View2.DrawOnPaint = True
        Me.MG_View2.DynamicViewManipulation = True
        Me.MG_View2.FilterLowerZ = Single.NaN
        Me.MG_View2.FilterUpperZ = Single.NaN
        Me.MG_View2.FilterZ = False
        Me.MG_View2.FilterZCrossing = False
        Me.MG_View2.FourthAxis = 0!
        Me.MG_View2.Limits = New Single() {0!, 0!, 0!, 0!, 0!, 0!}
        Me.MG_View2.LimitsColor = System.Drawing.Color.DarkGray
        Me.MG_View2.Location = New System.Drawing.Point(486, 316)
        Me.MG_View2.MaxSelectionHits = 16
        Me.MG_View2.MotionColor_ArcCCW = System.Drawing.Color.Teal
        Me.MG_View2.MotionColor_ArcCW = System.Drawing.Color.ForestGreen
        Me.MG_View2.MotionColor_Line = System.Drawing.Color.DodgerBlue
        Me.MG_View2.MotionColor_Rapid = System.Drawing.Color.OrangeRed
        Me.MG_View2.Name = "MG_View2"
        Me.MG_View2.Pitch = 0!
        Me.MG_View2.RangeEnd = -1
        Me.MG_View2.RangeStart = 0
        Me.MG_View2.ReverseMouseWheel = True
        Me.MG_View2.Roll = 0!
        Me.MG_View2.RotaryType = MacGen.Globals.RotaryMotionType.BMC
        Me.MG_View2.SelectedMotionIndex = -1
        Me.MG_View2.SelectionColor = System.Drawing.Color.Empty
        Me.MG_View2.Size = New System.Drawing.Size(250, 250)
        Me.MG_View2.TabIndex = 1
        Me.MG_View2.TabletMode = False
        Me.MG_View2.ViewManipMode = MacGen.MG_BasicViewer.ManipMode.ROTATE
        Me.MG_View2.Yaw = 0!
        '
        'MG_View1
        '
        Me.MG_View1.AxisIndicatorScale = 0.75!
        Me.MG_View1.BackColor = System.Drawing.Color.Black
        Me.MG_View1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MG_View1.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.MG_View1.DrawExtraOverlayInfo = True
        Me.MG_View1.DrawOnPaint = True
        Me.MG_View1.DynamicViewManipulation = True
        Me.MG_View1.FilterLowerZ = Single.NaN
        Me.MG_View1.FilterUpperZ = Single.NaN
        Me.MG_View1.FilterZ = False
        Me.MG_View1.FilterZCrossing = False
        Me.MG_View1.FourthAxis = 0!
        Me.MG_View1.Limits = New Single() {0!, 0!, 0!, 0!, 0!, 0!}
        Me.MG_View1.LimitsColor = System.Drawing.Color.DarkGray
        Me.MG_View1.Location = New System.Drawing.Point(486, 28)
        Me.MG_View1.MaxSelectionHits = 16
        Me.MG_View1.MotionColor_ArcCCW = System.Drawing.Color.Teal
        Me.MG_View1.MotionColor_ArcCW = System.Drawing.Color.ForestGreen
        Me.MG_View1.MotionColor_Line = System.Drawing.Color.DodgerBlue
        Me.MG_View1.MotionColor_Rapid = System.Drawing.Color.OrangeRed
        Me.MG_View1.Name = "MG_View1"
        Me.MG_View1.Pitch = 0!
        Me.MG_View1.RangeEnd = -1
        Me.MG_View1.RangeStart = 0
        Me.MG_View1.ReverseMouseWheel = True
        Me.MG_View1.Roll = 0!
        Me.MG_View1.RotaryType = MacGen.Globals.RotaryMotionType.BMC
        Me.MG_View1.SelectedMotionIndex = -1
        Me.MG_View1.SelectionColor = System.Drawing.Color.Empty
        Me.MG_View1.Size = New System.Drawing.Size(250, 250)
        Me.MG_View1.TabIndex = 0
        Me.MG_View1.TabletMode = False
        Me.MG_View1.ViewManipMode = MacGen.MG_BasicViewer.ManipMode.ROTATE
        Me.MG_View1.Yaw = 0!
        '
        'SimpleViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 599)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MG_View2)
        Me.Controls.Add(Me.MG_View1)
        Me.Name = "SimpleViewer"
        Me.Text = "SimpleViewer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MG_View1 As MG_BasicViewer
    Friend WithEvents MG_View2 As MG_BasicViewer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
