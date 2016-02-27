Public Class SimpleViewer
    Private mMotionBlocks As New Generic.List(Of clsMotionRecord)
    Private WithEvents mSetup As clsSettings = clsSettings.Instance
    Private WithEvents mParser As clsParser = clsParser.Instance
    Private mNcProgs As New System.Collections.Generic.List(Of clsProg)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim AppPath As String = My.Computer.FileSystem.CurrentDirectory
        Dim DatPath As String = IO.Path.Combine(AppPath, "Data")
        Dim machineFile As String = IO.Path.Combine(DatPath, "Mill.xml")
        mSetup.LoadMachine(machineFile)
        mParser.Init(mSetup.Machine)
        mParser.ProcessText("", Me.TextBox1.Text, mMotionBlocks, mNcProgs)

        MG_View1.IsShared = True
        MG_View2.IsShared = True

        MG_View1.ViewManipMode = MG_BasicViewer.ManipMode.SELECTION
        MG_View2.DrawExtraOverlayInfo = False

        'Iso view
        MG_View2.Pitch = 315
        MG_View2.Roll = 0
        MG_View2.Yaw = 315
        MG_View1.DrawRapidPoints = False
        MG_View1.MotionColorByMotionType = True
        MG_View1.InitMyNeighbors()
        MG_View1.InitSiblingMotionBlocks(mMotionBlocks)

        MG_View1.SetRangeByLine(0, 0)
        MG_View1.FindExtents()
        MG_View1.ZoomSceneAtCenter(1.1)

        MG_View2.FindExtents()
        MG_View2.ZoomSceneAtCenter(1.1)

        MG_View1.Redraw(True)

    End Sub

    Private Sub MG_View1_OnStatus(msg As String, index As Integer, max As Integer) Handles MG_View2.OnStatus, MG_View1.OnStatus
        Debug.Print(msg)
    End Sub

    Private Sub MG_View1_OnSelection(hits As Generic.List(Of clsMotionRecord), i As Integer) Handles MG_View1.OnSelection, MG_View2.OnSelection
        Debug.Print(hits(0).Codestring)
        Dim linenum As Integer = hits(0).Linenumber
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MG_View1.SetSelectionHits(21, 55, 0)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MG_View1.SetRangeByLine(0, 25)
        MG_View1.Redraw(True)

    End Sub

End Class