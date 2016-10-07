Public Class OQCommand
   Implements IDbCommand

   Private _TimeOutPeriod As Integer
   Private _Connection As OQConnection
   Private _CmdText As String
   Private _UpdatedRowSource As UpdateRowSource = UpdateRowSource.None
   Private _Parameters As OQParameterCollection = New OQParameterCollection()

   Public Sub New()
   End Sub

   Public Property CommandText() As String _
      Implements IDbCommand.CommandText
      Get
         Return _CmdText
      End Get
      Set(ByVal Value As String)
         If ((Value <> "Send") And (Value <> "Receive")) Then
            Throw New NotSupportedException("CommandText Must be " _
               & "either Send or Receive")
         Else
            _CmdText = Value
         End If
      End Set
   End Property

   Public Property CommandTimeout() As Integer _
      Implements IDbCommand.CommandTimeout
      Get
         Return _TimeOutPeriod
      End Get
      Set(ByVal Value As Integer)
         _TimeOutPeriod = Value
      End Set
   End Property

   Public Property CommandType() As CommandType _
      Implements IDbCommand.CommandType
      Get
         Return CommandType.Text
      End Get
      Set(ByVal Value As CommandType)
         If (Value <> CommandType.Text) Then
            Throw New NotSupportedException("Only supported " _
               & "CommandType is Text")
         End If
      End Set
   End Property

   Public Property Connection() As IDbConnection _
      Implements IDbCommand.Connection
      Get
         Return _Connection
      End Get
      Set(ByVal Value As IDbConnection)
         _Connection = CType(Value, OQConnection)
      End Set
   End Property

   Public ReadOnly Property Parameters() As IDataParameterCollection _
      Implements IDbCommand.Parameters
      Get
         Return _Parameters
      End Get
   End Property

   Public Property Transaction() As IDbTransaction _
      Implements IDbCommand.Transaction
      Get
         Return Nothing
      End Get
      Set(ByVal Value As IDbTransaction)
         Throw New NotSupportedException()
      End Set
   End Property

   Public Property UpdatedRowSource() As UpdateRowSource _
      Implements IDbCommand.UpdatedRowSource
      Get
         Return _UpdatedRowSource
      End Get
      Set(ByVal Value As UpdateRowSource)
         _UpdatedRowSource = Value
      End Set
   End Property

   ' IDbCommand Methods (Required)

   Public Sub Cancel() _
      Implements IDbCommand.Cancel
      Throw New NotSupportedException()
   End Sub

   Public Function CreateParameter() As IDbDataParameter _
      Implements IDbCommand.CreateParameter
      Return New OQParameter()
   End Function

   Public Function ExecuteNonQuery() As Integer _
      Implements IDbCommand.ExecuteNonQuery
      _Connection.SetState(ConnectionState.Executing)
      If (_Parameters.Contains("Order")) Then
         Dim tmpParam As OQParameter = _
            CType(_Parameters("Order"), OQParameter)
         Dim tmpOrder As OrderObject = _
            CType(tmpParam.Value, OrderObject)
         _Connection.MQ.Send(tmpOrder, tmpOrder.OrderID)
         _Connection.SetState(ConnectionState.Open)
         Return 1
      Else
         Throw New IndexOutOfRangeException( _
            "Order Parameter does not exist.")
      End If
   End Function

   Public Function ExecuteReader() As IDataReader _
      Implements IDbCommand.ExecuteReader
      Return New OQDataReader(_Connection)
   End Function

   Public Function ExecuteReader(ByVal behavior As CommandBehavior) _
      As IDataReader Implements IDbCommand.ExecuteReader
      Return New OQDataReader(_Connection)
   End Function

   Public Function ExecuteScalar() As Object Implements IDbCommand.ExecuteScalar
      Return Nothing
   End Function

   Public Sub Prepare() Implements IDbCommand.Prepare
      ' do nothing.
   End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      _Connection.Dispose()
   End Sub
End Class
