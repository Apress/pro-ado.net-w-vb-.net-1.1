Public Class OQConnection
   Implements IDbConnection

   Private _cState As ConnectionState
   Private _ConnStr As String
   Private _TimeOutPeriod As Integer
   Private _AutoCreateQueue As Boolean

   Private _Queue As MessageQueue

   Public Sub New()
      _TimeOutPeriod = 3
      _cState = ConnectionState.Closed
      _AutoCreateQueue = True
   End Sub

   Friend Sub SetState(ByVal newState As ConnectionState)
      _cState = newState
   End Sub

   Public Property AutoCreateQueue() As Boolean
      Get
         Return _AutoCreateQueue
      End Get
      Set(ByVal Value As Boolean)
         _AutoCreateQueue = Value
      End Set
   End Property

   Friend ReadOnly Property MQ() As MessageQueue
      Get
         Return _Queue
      End Get
   End Property

   ' Implementation of IDbConnection interface

   ' <summary>
   ' Connection string. Can only be set when the connection is closed.
   ' </summary>
   Public Property ConnectionString() As String _
      Implements IDbConnection.ConnectionString
      Get
         Return _ConnStr
      End Get
      Set(ByVal Value As String)
         If (_cState <> ConnectionState.Closed) Then
            Throw New InvalidOperationException( _
                  "Cannot set the Connection String unless " _
                  & "the Connection is Closed.")
         Else
            _ConnStr = Value
         End If
      End Set
   End Property

   ' <summary>
   ' Timeout period of the connection in seconds.
   ' </summary>
   Public ReadOnly Property ConnectionTimeout() As Integer _
      Implements IDbConnection.ConnectionTimeout
      Get
         Return _TimeOutPeriod
      End Get
   End Property

   ' <summary>
   ' Database property. This will always return "", as this provider does not
   ' actually work with Databases.
   ' </summary>
   Public ReadOnly Property Database() As String _
      Implements IDbConnection.Database
      Get
         Return ""
      End Get
   End Property

   ' <summary>
   ' Indicates the current connection state.
   ' </summary>
   Public ReadOnly Property State() As ConnectionState _
      Implements IDbConnection.State
      Get
         Return _cState
      End Get
   End Property

   ' IDbConnection Methods

   Public Function BeginTransaction() As IDbTransaction _
         Implements IDbConnection.BeginTransaction
      Throw New NotSupportedException("Transactions Not " _
            & "Supported by this Provider")
   End Function

   Public Function BeginTransaction(ByVal iLevel As IsolationLevel) _
         As IDbTransaction _
         Implements IDbConnection.BeginTransaction
      Throw New NotSupportedException("Transactions Not " _
            & "Supported by this Provider")
   End Function

   Public Sub ChangeDatabase(ByVal databaseName As String) _
      Implements IDbConnection.ChangeDatabase
      Throw New NotSupportedException("Transactions Not " _
            & "Supported by this Provider")
   End Sub

   Public Function CreateCommand() As IDbCommand _
      Implements IDbConnection.CreateCommand
      Dim nCommand As OQCommand = New OQCommand()
      nCommand.Connection = Me
      Return nCommand
   End Function

   Public Sub Open() _
      Implements IDbConnection.Open
      If (Not MessageQueue.Exists(_ConnStr)) Then
         If (Not _AutoCreateQueue) Then
            Throw New InvalidOperationException("Cannot Open Queue: " _
                  & "Queue Does not Exist")
         Else
            _Queue = MessageQueue.Create(_ConnStr)
         End If
      Else
         _Queue = New MessageQueue(_ConnStr)
      End If
      _Queue.Formatter = New XmlMessageFormatter()
      _cState = ConnectionState.Open
   End Sub

   Public Sub Close() _
      Implements IDbConnection.Close
      _Queue.Dispose()
      _cState = ConnectionState.Closed
   End Sub

   Public Sub Dispose() _
      Implements IDisposable.Dispose
      _Queue.Dispose()
   End Sub
End Class
