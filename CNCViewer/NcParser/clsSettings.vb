Option Strict On
Option Explicit On
Option Compare Text
Imports System.xml
Public Class clsSettings
    Public Machines As New Specialized.StringDictionary
    Public Machine As New clsMachine
    Private Const DATEXTENSION As String = ".xml"
    Private mDatFolder As String
    Public Event MachineAdded(ByVal n As String)
    Public Event MachineDeleted(ByVal n As String)
    Public Event MachineActivated(ByVal m As clsMachine)
    Public Event MachinesCleared()
    Private xmlSettings As New XmlDocument


#Region "Singleton"
    Private Shared mInstance As clsSettings
    'PRIVATE constructor can only be called from this class
    Private Sub New()
    End Sub

    Private Shared SyncLock_LOCK As New Object
    ''' <summary>
    ''' Static method for creating the single instance of the Constructor
    ''' </summary>
    Public Shared Function Instance() As clsSettings
        ' initialize if not already done
        SyncLock SyncLock_LOCK
            If mInstance Is Nothing Then
                mInstance = New clsSettings
            End If
        End SyncLock
        ' return the initialized instance of the Singleton Class
        Return mInstance
    End Function 'Instance
#End Region
    ''' <summary>
    ''' Sets or gets the folder containing the data files
    ''' </summary>
    Public Property DatFolder() As String
        Get
            Return mDatFolder
        End Get
        Set(ByVal value As String)
            If value.EndsWith("\") Then
                mDatFolder = value
            Else
                mDatFolder = value & "\"
            End If
        End Set
    End Property

    ''' <summary>
    ''' Sets or gets the name of the current machine
    ''' </summary>
    Public Property MachineName() As String
        Get
            Return Machine.Name
        End Get
        Set(ByVal value As String)
            If Machines.ContainsKey(value) Then
                If value <> Machine.Name Then
                    LoadMachine(DatFolder & value & DATEXTENSION)
                End If
                RaiseEvent MachineActivated(Machine)
            End If
        End Set
    End Property

    Public ReadOnly Property MachineSettingsXML() As String
        Get
            If IO.File.Exists(DatFolder & Machine.Name & DATEXTENSION) Then
                Return IO.File.ReadAllText(DatFolder & Machine.Name & DATEXTENSION)
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public Sub ReloadCurrentMachine()
        MachineName = MachineName
    End Sub

    Private Function GetSetting(ByVal name As String, Optional ByVal defaultVal As String = "") As String
        Dim node As XmlNode
        node = xmlSettings.DocumentElement.SelectSingleNode("//Machine/" & name)
        If node IsNot Nothing Then
            Return node.InnerText
        Else
            Return defaultVal
        End If
    End Function

    Private Sub PutSetting(ByVal name As String, ByVal value As String)
        Dim node As XmlNode
        node = xmlSettings.DocumentElement.SelectSingleNode("//Machine/" & name)
        If node IsNot Nothing Then
            node.InnerText = value
        Else
            If value.Length > 0 Then
                'Create a new node.
                Dim n As XmlElement = xmlSettings.CreateElement(name)
                n.InnerText = value
                xmlSettings.DocumentElement.AppendChild(n)
            End If
        End If
    End Sub

    Public Sub LoadMachine(ByVal sName As String)
        Dim r As Integer
        xmlSettings.Load(sName)
        With Machine
            .Name = GetSetting("Name")
            .MachineUnits = CType([Enum].Parse(GetType(MachineUnits), GetSetting("MachineUnits", MachineUnits.ENGLISH.ToString)), MachineUnits)
            .UnitsEnglishAddress = GetSetting("UnitsEnglishAddress", "G20")
            .UnitsMetricAddress = GetSetting("UnitsMetricAddress", "G21")
            .Description = Uri.UnescapeDataString(GetSetting("Description"))
            .AbsArcCenter = CBool(GetSetting("AbsArcCenter", "False"))
            .LatheMinus = CBool(GetSetting("LatheMinus", "False"))
            .HelixPitch = CBool(GetSetting("HelixPitch", "False"))
            .BlockSkip = GetSetting("BlockSkip", "/*")
            .Comments = GetSetting("Comments", "();*")
            .Endmain = GetSetting("Endmain", "M30")
            .MachineType = CType([Enum].Parse(GetType(MachineType), GetSetting("MachineType", MachineType.MILL.ToString)), MachineType)
            .RotaryAxis = CType([Enum].Parse(GetType(Axis), GetSetting("RotaryAxis", "X")), Axis)
            .RotaryDir = CType([Enum].Parse(GetType(RotaryDirection), GetSetting("RotaryDir", "CW")), RotaryDirection)
            .Precision = Integer.Parse(GetSetting("Precision", "4"), System.Globalization.NumberFormatInfo.InvariantInfo)
            .ProgramId = GetSetting("ProgramId", ":$O")
            .SubReturn = GetSetting("SubReturn", "M99")
            .RotPrecision = Integer.Parse(GetSetting("RotPrecision", "4"), System.Globalization.NumberFormatInfo.InvariantInfo)
            .RotaryType = CType([Enum].Parse(GetType(RotaryMotionType), GetSetting("RotaryType", "CAD")), RotaryMotionType)
            .Searchstring = GetSetting("Searchstring")
            For r = 0 To .ViewAngles.Length - 1
                .ViewAngles(r) = Single.Parse(GetSetting("ViewAngles_" & r.ToString, "0.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            Next
            For r = 0 To .ViewShift.Length - 1
                .ViewShift(r) = Single.Parse(GetSetting("ViewShift_" & r.ToString, "0.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            Next
            .Absolute = GetSetting("Absolute", "G90")
            .Incremental = GetSetting("Incremental", "G91")
            .CCArc = GetSetting("CCArc", "G03")
            .CWArc = GetSetting("CWArc", "G02")
            .DrillRapid = GetSetting("DrillRapid", "R")
            For r = 0 To .Drills.Length - 1
                .Drills(r) = GetSetting("Drills_" & r.ToString)
            Next
            .Linear = GetSetting("Linear", "G01")
            .Rapid = GetSetting("Rapid", "G00")
            .ReturnLevel(0) = GetSetting("ReturnLevel_0", "G98")
            .ReturnLevel(1) = GetSetting("ReturnLevel_1", "G99")
            .Rotary = GetSetting("Rotary", "B")
            .XYplane = GetSetting("XYplane", "G17")
            .XZplane = GetSetting("XZplane", "G18")
            .YZplane = GetSetting("YZplane", "G19")
            .Subcall = GetSetting("Subcall", "M98")
            .SubRepeats = GetSetting("SubRepeats", "L")

            .CompLeft = GetSetting("CompLeft", "G41")
            .CompRight = GetSetting("CompRight", "G42")
            .CompCancel = GetSetting("CompCancel", "G40")
            .FeedModeMin = GetSetting("FeedModeMin", "G98")
            .FeedModeRev = GetSetting("FeedModeRev", "G99")
            .FeedPrecision = CInt(GetSetting("FeedPrecision", "5"))

            .RapidRate = Single.Parse(GetSetting("RapidRate", "250.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            .MaxRpmAddress = GetSetting("MaxRpmAddress", "G50")
            .MaxRpmValue = Single.Parse(GetSetting("MaxRpmValue", "5000.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            .DogLegMotion = Boolean.Parse(GetSetting("DogLegMotion", "True"))
            .SpeedModeRPM = GetSetting("SpeedModeRPM", "G97")
            .SpeedModeSFM = GetSetting("SpeedModeSFM", "G96")

            .GlobalReplacements = Uri.UnescapeDataString(GetSetting("GlobalReplacements"))

            .ToolChange = GetSetting("ToolChange", "M06")
            .HomeCommand = GetSetting("HomeCommand", "G28")
            .HomeAddresses(0) = GetSetting("HomeAddresses0", "U")
            .HomeAddresses(1) = GetSetting("HomeAddresses1", "V")
            .HomeAddresses(2) = GetSetting("HomeAddresses2", "W")
            .HomeValues(0) = Single.Parse(GetSetting("HomeValues0", "0.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            .HomeValues(1) = Single.Parse(GetSetting("HomeValues1", "0.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            .HomeValues(2) = Single.Parse(GetSetting("HomeValues2", "0.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)

            .Limits(0) = Single.Parse(GetSetting("LimitsMaxX", "1000.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            .Limits(1) = Single.Parse(GetSetting("LimitsMinX", "-1000.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            .Limits(2) = Single.Parse(GetSetting("LimitsMaxY", "1000.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            .Limits(3) = Single.Parse(GetSetting("LimitsMinY", "-1000.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            .Limits(4) = Single.Parse(GetSetting("LimitsMaxZ", "1000.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            .Limits(5) = Single.Parse(GetSetting("LimitsMinZ", "-1000.0"), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)

            .ParserName = GetSetting("Parser", "FANUC_Parser")
            .EmitterName = GetSetting("Emitter", "GcodeEmitter")
            .CornerTreatments = CBool(GetSetting("CornerTreatments", "False"))
            .UseUVW = CBool(GetSetting("UseUVW", "False"))
            .InvertArcCenterValues = CBool(GetSetting("InvertArcCenterValues", "False"))
        End With

    End Sub

    Public Sub SaveMachine(ByVal MySetup As clsMachine)
        Dim sName As String = DatFolder & MySetup.Name & DATEXTENSION
        Dim r As Integer

        With MySetup
            PutSetting("Name", MySetup.Name)
            PutSetting("MachineUnits", .MachineUnits.ToString)
            PutSetting("UnitsEnglishAddress", .UnitsEnglishAddress)
            PutSetting("UnitsMetricAddress", .UnitsMetricAddress)
            PutSetting("Description", Uri.EscapeDataString(MySetup.Description))
            PutSetting("AbsArcCenter", .AbsArcCenter.ToString)
            PutSetting("LatheMinus", .LatheMinus.ToString)
            PutSetting("HelixPitch", .HelixPitch.ToString)
            PutSetting("BlockSkip", .BlockSkip)
            PutSetting("Comments", .Comments)
            PutSetting("Endmain", .Endmain.ToString)
            PutSetting("MachineType", .MachineType.ToString)
            PutSetting("RotaryAxis", .RotaryAxis.ToString)
            PutSetting("RotaryDir", .RotaryDir.ToString)
            PutSetting("Precision", .Precision.ToString)
            PutSetting("ProgramId", .ProgramId)
            PutSetting("SubReturn", .SubReturn)
            PutSetting("RotPrecision", .RotPrecision.ToString)
            PutSetting("RotaryType", .RotaryType.ToString)
            PutSetting("Searchstring", .Searchstring)
            For r = 0 To 2
                PutSetting("ViewAngles_" & r.ToString, .ViewAngles(r).ToString)
            Next
            For r = 0 To 2
                PutSetting("ViewShift_" & r.ToString, .ViewShift(r).ToString(System.Globalization.NumberFormatInfo.InvariantInfo))
            Next
            PutSetting("Absolute", .Absolute)
            PutSetting("Incremental", .Incremental)
            PutSetting("CCArc", .CCArc)
            PutSetting("CWArc", .CWArc)
            PutSetting("DrillRapid", .DrillRapid)
            For r = 0 To .Drills.Length - 1
                PutSetting("Drills_" & r.ToString, .Drills(r))
            Next
            PutSetting("Linear", .Linear)
            PutSetting("Rapid", .Rapid)
            PutSetting("ReturnLevel_0", .ReturnLevel(0))
            PutSetting("ReturnLevel_1", .ReturnLevel(1))
            PutSetting("Rotary", .Rotary)
            PutSetting("XYplane", .XYplane)
            PutSetting("XZplane", .XZplane)
            PutSetting("YZplane", .YZplane)
            PutSetting("Subcall", .Subcall)
            PutSetting("SubRepeats", .SubRepeats)
            PutSetting("RapidRate", .RapidRate.ToString)

            PutSetting("MaxRpmAddress", .MaxRpmAddress)
            PutSetting("MaxRpmValue", .MaxRpmValue.ToString)
            PutSetting("DogLegMotion", .DogLegMotion.ToString)

            PutSetting("FeedPrecision", .FeedPrecision.ToString)
            PutSetting("CompLeft", .CompLeft)
            PutSetting("CompRight", .CompRight)
            PutSetting("CompCancel", .CompCancel)
            PutSetting("FeedModeMin", .FeedModeMin)
            PutSetting("FeedModeRev", .FeedModeRev)

            PutSetting("SpeedModeRPM", .SpeedModeRPM)
            PutSetting("SpeedModeSFM", .SpeedModeSFM)

            PutSetting("UseUVW", .UseUVW.ToString)
            PutSetting("GlobalReplacements", Uri.EscapeDataString(.GlobalReplacements))
            PutSetting("InvertArcCenterValues", .InvertArcCenterValues.ToString)

            PutSetting("ToolChange", .ToolChange.ToString)
            PutSetting("HomeCommand", .HomeCommand.ToString)
            PutSetting("HomeAddress0", .HomeAddresses(0).ToString)
            PutSetting("HomeAddress1", .HomeAddresses(1).ToString)
            PutSetting("HomeAddress2", .HomeAddresses(2).ToString)
            PutSetting("HomeValues0", .HomeValues(0).ToString)
            PutSetting("HomeValues1", .HomeValues(1).ToString)
            PutSetting("HomeValues2", .HomeValues(2).ToString)

            PutSetting("LimitsMaxX", .Limits(0).ToString)
            PutSetting("LimitsMinX", .Limits(1).ToString)
            PutSetting("LimitsMaxY", .Limits(2).ToString)
            PutSetting("LimitsMinY", .Limits(3).ToString)
            PutSetting("LimitsMaxZ", .Limits(4).ToString)
            PutSetting("LimitsMinZ", .Limits(5).ToString)
            PutSetting("Parser", .ParserName)
            PutSetting("Emitter", .EmitterName)
            PutSetting("CornerTreatments", .CornerTreatments.ToString)
        End With
        xmlSettings.Save(sName)
    End Sub

    Public Function MachineExists(ByVal baseName As String) As Boolean
        Dim fileToFind As String = IO.Path.Combine(DatFolder, baseName & DATEXTENSION)
        Return IO.File.Exists(fileToFind)
    End Function


    Public Sub DeleteMachine(ByVal n As String)
        Dim fileToDelete As String = DatFolder & n & DATEXTENSION
        If IO.File.Exists(fileToDelete) Then
            IO.File.Delete(fileToDelete)
            Machines.Remove(n)
            RaiseEvent MachineDeleted(n)
        End If
    End Sub

    Public Sub AddMachine(ByVal key As String)
        Machines.Add(key, "")
        RaiseEvent MachineAdded(key)
    End Sub

    Public Sub RenameMachine(ByVal newName As String, ByVal copy As Boolean)
        Dim thisName As String = Machine.Name
        Machine.Name = newName
        SaveMachine(Machine)
        AddMachine(newName)
        If Not copy Then
            DeleteMachine(thisName)
        End If
    End Sub

    Public Sub LoadAllMachines(ByVal sDatFolder As String)
        DatFolder = sDatFolder
        Machines.Clear()
        RaiseEvent MachinesCleared()
        Dim fls As String() = IO.Directory.GetFiles(DatFolder, "*" & DATEXTENSION)
        For Each f As String In fls
            LoadMachine(f)
            Machines.Add(Machine.Name, Machine.Searchstring)
            RaiseEvent MachineAdded(Machine.Name)
        Next
    End Sub

    Public Sub LoadAllMachines()
        LoadAllMachines(DatFolder)
    End Sub

    'Open CNC file and get 50 lines of text
    Public Function MatchMachineToFile(ByVal sFullfile As String) As Boolean
        Dim ln As Integer = 0
        Dim sb As New System.Text.StringBuilder
        Dim sTemp As String
        If Machines.Count = 0 Then
            Machine = Nothing
            Return False
        End If

        Using fileReader As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(sFullfile)
            Do While fileReader.Peek >= 0
                If ln >= 50 Then Exit Do
                sb.Append(fileReader.ReadLine)
                ln += 1
            Loop
            fileReader.Close()
        End Using
        sTemp = sb.ToString
        sb.Length = 0
        Return MatchMachineToString(sTemp)
    End Function

    Public Function MatchMachineToString(ByVal text As String) As Boolean
        For Each m As DictionaryEntry In Machines
            If text.Contains(CStr(m.Value)) Then
                MachineName = CStr(m.Key)
                Return True
            End If
        Next
        Return False
    End Function

End Class
