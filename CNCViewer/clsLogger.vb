Imports System.IO
''' <remarks>
''' MacGen Programming
''' Jason Titcomb
''' https://github.com/JasonTitcomb/Basic_CNC_Viewer/blob/master/LICENSE.md
''' www.CncEdit.com
''' </remarks>
Public Class clsLogger
    Public Enabled As Boolean = True
    Private mLastException As Exception = Nothing
    Private mLogDir As String
    Private mLogFileAndDir As String
    Delegate Sub StatusEventHandler(ByVal msg As String)

    Public Event Status As StatusEventHandler
    Private mLogName As String = "Log.txt"
    Public Exceptions As New Generic.List(Of Exception)
    Public Alerts As New Generic.List(Of String)

    Public Property LogName() As String
        Get
            Return mLogName
        End Get
        Set(ByVal value As String)
            mLogName = value
        End Set
    End Property

#Region "Singleton Pattern"
    Private Shared mInstance As clsLogger
    'PRIVATE constructor can only be called from this class
    Private Sub New()
        Try
            Dim mLogDir As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, "Logs")
            If Not Directory.Exists(mLogDir) Then
                mLogDir = Directory.CreateDirectory(mLogDir).FullName
            End If
            mLogFileAndDir = mLogDir & "\" & mLogName
            If File.Exists(mLogFileAndDir) Then
                File.Delete(mLogFileAndDir)
            End If
        Catch
            Throw 'original exception
        End Try
    End Sub

    'Static method for creating the single instance of the Constructor
    Public Shared Function Instance() As clsLogger
        ' initialize if not already done
        If mInstance Is Nothing Then
            mInstance = New clsLogger()
        End If
        ' return the initialized instance of the Singleton Class
        Return mInstance
    End Function 'Instance

    Protected Sub Dispose(ByVal disposing As Boolean)
        mInstance = Nothing
    End Sub
#End Region

    Public ReadOnly Property LastException() As Exception
        Get
            Return mLastException
        End Get
    End Property

    Public Sub ClearLog()
        Try
            Exceptions.Clear()
            Alerts.Clear()
            File.Delete(mLogFileAndDir)
        Catch
        End Try
    End Sub

    Public Function ReadLogContents() As String
        Try
            Return My.Computer.FileSystem.ReadAllText(Me.mLogFileAndDir)
        Catch
            Return "Unable to read log file"
        End Try
    End Function

    Public Sub LogError(ByVal e As Exception)
        Dim logger As StreamWriter = Nothing
        Dim fs As FileStream
        If Not Enabled Then Return
        Try
            Exceptions.Add(e)
            mLastException = e
            fs = New FileStream(mLogFileAndDir, FileMode.Create Or FileMode.Append, FileAccess.Write, FileShare.Write)
            logger = New StreamWriter(fs)
            logger.WriteLine("Message:")
            logger.WriteLine(e.Message)

            logger.WriteLine("Source:")
            logger.WriteLine(e.Source)

            logger.WriteLine("TargetSite:")
            logger.WriteLine(e.TargetSite.ToString)

            logger.WriteLine("Stack:")
            logger.WriteLine(e.StackTrace)
            logger.WriteLine("--------------------------------------")
            RaiseEvent Status(e.Message)
        Finally
            If Not (logger Is Nothing) Then
                logger.Close()
                logger = Nothing
                fs = Nothing
            End If
        End Try
    End Sub

    Public Sub LogAlert(ByVal msg As String)
        Dim logger As StreamWriter = Nothing
        Dim fs As FileStream
        If Not Enabled Then Return
        Try
            Alerts.Add(msg)
            fs = New FileStream(mLogFileAndDir, FileMode.Create Or FileMode.Append, FileAccess.Write, FileShare.Write)
            logger = New StreamWriter(fs)
            logger.WriteLine("Alert: " & msg)
            logger.WriteLine("--------------------------------------")
            RaiseEvent Status(msg)
        Finally
            If Not (logger Is Nothing) Then
                logger.Close()
                logger = Nothing
                fs = Nothing
            End If
        End Try
    End Sub

End Class
