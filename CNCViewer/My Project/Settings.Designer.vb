﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property ViewerSetupLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("ViewerSetupLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("ViewerSetupLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property RapidLines() As Boolean
            Get
                Return CType(Me("RapidLines"),Boolean)
            End Get
            Set
                Me("RapidLines") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property RapidPoints() As Boolean
            Get
                Return CType(Me("RapidPoints"),Boolean)
            End Get
            Set
                Me("RapidPoints") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property AxisLines() As Boolean
            Get
                Return CType(Me("AxisLines"),Boolean)
            End Get
            Set
                Me("AxisLines") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property AxisIndicator() As Boolean
            Get
                Return CType(Me("AxisIndicator"),Boolean)
            End Get
            Set
                Me("AxisIndicator") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Mill")>  _
        Public Property LastMachine() As String
            Get
                Return CType(Me("LastMachine"),String)
            End Get
            Set
                Me("LastMachine") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property SetupFormLocation() As Global.System.Drawing.Size
            Get
                Return CType(Me("SetupFormLocation"),Global.System.Drawing.Size)
            End Get
            Set
                Me("SetupFormLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("750, 750")>  _
        Public Property ViewFormSize() As Global.System.Drawing.Size
            Get
                Return CType(Me("ViewFormSize"),Global.System.Drawing.Size)
            End Get
            Set
                Me("ViewFormSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property Virgin() As Boolean
            Get
                Return CType(Me("Virgin"),Boolean)
            End Get
            Set
                Me("Virgin") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Black")>  _
        Public Property ViewsBackColor() As Global.System.Drawing.Color
            Get
                Return CType(Me("ViewsBackColor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("ViewsBackColor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("4")>  _
        Public Property Viewports() As Integer
            Get
                Return CType(Me("Viewports"),Integer)
            End Get
            Set
                Me("Viewports") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property ViewerPrintMode() As Integer
            Get
                Return CType(Me("ViewerPrintMode"),Integer)
            End Get
            Set
                Me("ViewerPrintMode") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property ViewPrintScale() As Single
            Get
                Return CType(Me("ViewPrintScale"),Single)
            End Get
            Set
                Me("ViewPrintScale") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Arial, 9pt")>  _
        Public Property ViewerOverlayFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("ViewerOverlayFont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("ViewerOverlayFont") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property ViewerShowExtraOverlayDetails() As Boolean
            Get
                Return CType(Me("ViewerShowExtraOverlayDetails"),Boolean)
            End Get
            Set
                Me("ViewerShowExtraOverlayDetails") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property ReverseMouseWheel() As Boolean
            Get
                Return CType(Me("ReverseMouseWheel"),Boolean)
            End Get
            Set
                Me("ReverseMouseWheel") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property ViewerSelectionColor() As Global.System.Drawing.Color
            Get
                Return CType(Me("ViewerSelectionColor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("ViewerSelectionColor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property IgnoreFileWhitespace() As Boolean
            Get
                Return CType(Me("IgnoreFileWhitespace"),Boolean)
            End Get
            Set
                Me("IgnoreFileWhitespace") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Version() As String
            Get
                Return CType(Me("Version"),String)
            End Get
            Set
                Me("Version") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property ViewerShowLimits() As Boolean
            Get
                Return CType(Me("ViewerShowLimits"),Boolean)
            End Get
            Set
                Me("ViewerShowLimits") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("64, 64, 64")>  _
        Public Property ViewerLimitsColor() As Global.System.Drawing.Color
            Get
                Return CType(Me("ViewerLimitsColor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("ViewerLimitsColor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property EditorVisible() As Boolean
            Get
                Return CType(Me("EditorVisible"),Boolean)
            End Get
            Set
                Me("EditorVisible") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Default")>  _
        Public Property ColorScheme() As String
            Get
                Return CType(Me("ColorScheme"),String)
            End Get
            Set
                Me("ColorScheme") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("300")>  _
        Public Property EditorWidth() As Integer
            Get
                Return CType(Me("EditorWidth"),Integer)
            End Get
            Set
                Me("EditorWidth") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property EditorZoom() As Single
            Get
                Return CType(Me("EditorZoom"),Single)
            End Get
            Set
                Me("EditorZoom") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property WindowState() As Integer
            Get
                Return CType(Me("WindowState"),Integer)
            End Get
            Set
                Me("WindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property TouchMode() As Boolean
            Get
                Return CType(Me("TouchMode"),Boolean)
            End Get
            Set
                Me("TouchMode") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property ShowPlayer() As Boolean
            Get
                Return CType(Me("ShowPlayer"),Boolean)
            End Get
            Set
                Me("ShowPlayer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property PlayerSpeed() As Integer
            Get
                Return CType(Me("PlayerSpeed"),Integer)
            End Get
            Set
                Me("PlayerSpeed") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property ToolColors() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("ToolColors"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("ToolColors") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property Setting() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("Setting"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("Setting") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property ViewerLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("ViewerLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("ViewerLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property PlayerOptionStop() As Boolean
            Get
                Return CType(Me("PlayerOptionStop"),Boolean)
            End Get
            Set
                Me("PlayerOptionStop") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property AutoZoom() As Boolean
            Get
                Return CType(Me("AutoZoom"),Boolean)
            End Get
            Set
                Me("AutoZoom") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("OrangeRed")>  _
        Public Property MotionColorRapid() As Global.System.Drawing.Color
            Get
                Return CType(Me("MotionColorRapid"),Global.System.Drawing.Color)
            End Get
            Set
                Me("MotionColorRapid") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("DodgerBlue")>  _
        Public Property MotionColorLinear() As Global.System.Drawing.Color
            Get
                Return CType(Me("MotionColorLinear"),Global.System.Drawing.Color)
            End Get
            Set
                Me("MotionColorLinear") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Green")>  _
        Public Property MotionColorCWArc() As Global.System.Drawing.Color
            Get
                Return CType(Me("MotionColorCWArc"),Global.System.Drawing.Color)
            End Get
            Set
                Me("MotionColorCWArc") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Teal")>  _
        Public Property MotionColorCCWArc() As Global.System.Drawing.Color
            Get
                Return CType(Me("MotionColorCCWArc"),Global.System.Drawing.Color)
            End Get
            Set
                Me("MotionColorCCWArc") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property ColorByMotionType() As Boolean
            Get
                Return CType(Me("ColorByMotionType"),Boolean)
            End Get
            Set
                Me("ColorByMotionType") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0, 0")>  _
        Public Property GraphicsDetailsLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("GraphicsDetailsLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("GraphicsDetailsLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("400, 350")>  _
        Public Property GraphicsDetailsSize() As Global.System.Drawing.Size
            Get
                Return CType(Me("GraphicsDetailsSize"),Global.System.Drawing.Size)
            End Get
            Set
                Me("GraphicsDetailsSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10")>  _
        Public Property GDIScaleFactor() As String
            Get
                Return CType(Me("GDIScaleFactor"),String)
            End Get
            Set
                Me("GDIScaleFactor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Auto")>  _
        Public Property EditorEncoding() As String
            Get
                Return CType(Me("EditorEncoding"),String)
            End Get
            Set
                Me("EditorEncoding") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property IgnoreWhitespace() As Boolean
            Get
                Return CType(Me("IgnoreWhitespace"),Boolean)
            End Get
            Set
                Me("IgnoreWhitespace") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property PerformLineFixup() As Boolean
            Get
                Return CType(Me("PerformLineFixup"),Boolean)
            End Get
            Set
                Me("PerformLineFixup") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property MB2Pan() As Boolean
            Get
                Return CType(Me("MB2Pan"),Boolean)
            End Get
            Set
                Me("MB2Pan") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property ScrollZoomAdjust() As Single
            Get
                Return CType(Me("ScrollZoomAdjust"),Single)
            End Get
            Set
                Me("ScrollZoomAdjust") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.MacGen.My.MySettings
            Get
                Return Global.MacGen.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
