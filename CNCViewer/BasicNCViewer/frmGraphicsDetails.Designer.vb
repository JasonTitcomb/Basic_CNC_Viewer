<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraphicsDetails
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.pgDetails = New System.Windows.Forms.PropertyGrid()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.MG_Graph1 = New MacGen.MG_Graph()
        Me.TabControl1.SuspendLayout()
        Me.Tab1.SuspendLayout()
        Me.Tab2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Tab1)
        Me.TabControl1.Controls.Add(Me.Tab2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(666, 651)
        Me.TabControl1.TabIndex = 1
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.pgDetails)
        Me.Tab1.Location = New System.Drawing.Point(4, 26)
        Me.Tab1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Tab1.Size = New System.Drawing.Size(658, 621)
        Me.Tab1.TabIndex = 0
        Me.Tab1.Text = "Details"
        Me.Tab1.UseVisualStyleBackColor = True
        '
        'pgDetails
        '
        Me.pgDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgDetails.Location = New System.Drawing.Point(2, 3)
        Me.pgDetails.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pgDetails.Name = "pgDetails"
        Me.pgDetails.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.pgDetails.Size = New System.Drawing.Size(654, 615)
        Me.pgDetails.TabIndex = 1
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.MG_Graph1)
        Me.Tab2.Location = New System.Drawing.Point(4, 26)
        Me.Tab2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Tab2.Size = New System.Drawing.Size(658, 621)
        Me.Tab2.TabIndex = 1
        Me.Tab2.Text = "Tool Time"
        Me.Tab2.UseVisualStyleBackColor = True
        '
        'MG_Graph1
        '
        Me.MG_Graph1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MG_Graph1.Location = New System.Drawing.Point(2, 3)
        Me.MG_Graph1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MG_Graph1.Name = "MG_Graph1"
        Me.MG_Graph1.Size = New System.Drawing.Size(654, 615)
        Me.MG_Graph1.TabIndex = 0
        Me.MG_Graph1.Text = "MG_Graph1"
        '
        'frmGraphicsDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 651)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(231, 250)
        Me.Name = "frmGraphicsDetails"
        Me.Text = "Graphics Details"
        Me.TabControl1.ResumeLayout(False)
        Me.Tab1.ResumeLayout(False)
        Me.Tab2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Tab1 As System.Windows.Forms.TabPage
    Friend WithEvents Tab2 As System.Windows.Forms.TabPage
    Friend WithEvents pgDetails As System.Windows.Forms.PropertyGrid
    Friend WithEvents MG_Graph1 As MacGen.MG_Graph
End Class
