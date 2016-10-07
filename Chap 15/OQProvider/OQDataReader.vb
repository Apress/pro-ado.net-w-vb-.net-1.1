Public Class OQDataReader
   Implements IDataReader

   Private _Connection As OQConnection
   Private _Message As Message
   Private _Order As OrderObject
   Private _ReadCount As Integer

   Friend Sub New()
      _Order = New OrderObject()
      _ReadCount = 0
   End Sub

   Friend Sub New(ByVal Connection As OQConnection)
      _Connection = Connection
      _Order = New OrderObject()
      _ReadCount = 0
   End Sub

   Public Function GetOrder() As OrderObject
      If (_ReadCount = 0) Then
         Throw New IndexOutOfRangeException( _
            "Must first call Read method to load current data.")
      End If
      Return _Order
   End Function

   Public ReadOnly Property Depth() As Integer _
      Implements IDataReader.Depth
      Get
         Return 0
      End Get
   End Property

   Public ReadOnly Property IsClosed() As Boolean _
      Implements IDataReader.IsClosed
      Get
         Return False
      End Get
   End Property

   Public ReadOnly Property RecordsAffected() As Integer _
      Implements IDataReader.RecordsAffected
      Get
         Return 0
      End Get
   End Property

   Public ReadOnly Property FieldCount() As Integer _
      Implements IDataReader.FieldCount
      Get
         Return 1
      End Get
   End Property

   Default Public ReadOnly Property Item(ByVal name As String) _
      Implements IDataReader.Item
      Get
         If (_ReadCount = 0) Then
            Throw New IndexOutOfRangeException( _
               "Must first call Read method to load current data.")
         End If
         If (name <> "Order") Then
            Throw New IndexOutOfRangeException("No Such Column")
         End If

         Return _Order
      End Get
   End Property

   Default Public ReadOnly Property Item(ByVal i As Integer) _
      Implements IDataReader.Item
      Get
         If (_ReadCount = 0) Then
            Throw New IndexOutOfRangeException( _
               "Must first call Read method to load current data.")
         End If
         If (i > 0) Then
            Throw New IndexOutOfRangeException("No Such Column")
         End If

         Return _Order
      End Get
   End Property

   Public Function GetBoolean(ByVal i As Integer) As Boolean _
      Implements IDataReader.GetBoolean
      Throw New NotSupportedException()
   End Function

   Public Function GetByte(ByVal i As Integer) As Byte _
      Implements IDataReader.GetByte
      Throw New NotSupportedException()
   End Function

   Public Function GetBytes(ByVal i As Integer, _
         ByVal fieldOffset As Long, ByVal buffer As Byte(), _
         ByVal bufferoffset As Integer, _
         ByVal length As Integer) As Long _
      Implements IDataReader.GetBytes
      Throw New NotSupportedException()
   End Function

   Public Function GetChar(ByVal i As Integer) As Char _
      Implements IDataReader.GetChar
      Throw New NotSupportedException()
   End Function

   Public Function GetChars(ByVal i As Integer, _
         ByVal fieldoffset As Long, ByVal buffer As Char(), _
         ByVal bufferoffset As Integer, _
         ByVal length As Integer) As Long _
      Implements IDataReader.GetChars
      Throw New NotSupportedException()
   End Function

   Public Function GetGuid(ByVal i As Integer) As Guid _
      Implements IDataReader.GetGuid
      Throw New NotSupportedException()
   End Function

   Public Function GetInt16(ByVal i As Integer) As Int16 _
      Implements IDataReader.GetInt16
      Throw New NotSupportedException()
   End Function

   Public Function GetInt32(ByVal i As Integer) As Int32 _
      Implements IDataReader.GetInt32
      Throw New NotSupportedException()
   End Function

   Public Function GetInt64(ByVal i As Integer) As Int64 _
   Implements IDataReader.GetInt64
      Throw New NotSupportedException()
   End Function

   Public Function GetDataTypeName(ByVal i As Integer) As String _
      Implements IDataReader.GetDataTypeName
      Return "OrderObject"
   End Function

   Public Function GetFloat(ByVal i As Integer) As Single _
      Implements IDataReader.GetFloat
      Throw New NotSupportedException()
   End Function

   Public Function GetDouble(ByVal i As Integer) As Double _
      Implements IDataReader.GetDouble
      Throw New NotSupportedException()
   End Function

   Public Function GetString(ByVal i As Integer) As String _
      Implements IDataReader.GetString
      Throw New NotSupportedException()
   End Function

   Public Function GetDecimal(ByVal i As Integer) As Decimal _
   Implements IDataReader.GetDecimal
      Throw New NotSupportedException()
   End Function

   Public Function GetDateTime(ByVal i As Integer) As DateTime _
      Implements IDataReader.GetDateTime
      Throw New NotSupportedException()
   End Function

   Public Function GetData(ByVal i As Integer) As IDataReader _
      Implements IDataReader.GetData
      Throw New NotSupportedException( _
         "Nested Data/GetData Not Supported.")
   End Function

   Public Function IsDBNull(ByVal i As Integer) As Boolean _
   Implements IDataReader.IsDBNull
      Return False
   End Function

   Public Function GetName(ByVal i As Integer) As String _
      Implements IDataReader.GetName
      Return "Order"
   End Function

   Public Function GetFieldType(ByVal i As Integer) As Type _
      Implements IDataReader.GetFieldType
      If (_ReadCount = 0) Then
         Throw New IndexOutOfRangeException( _
            "Must first call Read method to load current data.")
      End If
      If (i > 0) Then
         Throw New ArgumentOutOfRangeException( _
            "Only Possible Column Index is 0")
      End If
      Return GetType(OrderObject)
   End Function

   Public Function GetValue(ByVal i As Integer) As Object _
      Implements IDataReader.GetValue
      If (_ReadCount = 0) Then
         Throw New IndexOutOfRangeException( _
            "Must first call Read method to load current data.")
      End If
      If (i > 0) Then
         Throw New ArgumentOutOfRangeException( _
            "Only Possible Column Index is 0")
      End If
      Return _Order
   End Function

   Public Function GetValues(ByVal values As Object()) As Integer _
      Implements IDataReader.GetValues
      If (_ReadCount = 0) Then
         Throw New IndexOutOfRangeException( _
            "Must first call Read method to load current data.")
      End If
      values(0) = _Order
      Return 0
   End Function

   Public Function GetOrdinal(ByVal name As String) As Integer _
      Implements IDataReader.GetOrdinal
      If (_ReadCount = 0) Then
         Throw New IndexOutOfRangeException( _
            "Must first call Read method to load current data.")
      End If
      If (name <> "Order") Then
         Throw New IndexOutOfRangeException("No such Column")
      End If
      Return 0
   End Function

   Public Sub Close() _
      Implements IDataReader.Close
   End Sub

   Public Function GetSchemaTable() As DataTable _
      Implements IDataReader.GetSchemaTable
      Throw New NotSupportedException()
   End Function

   Public Function NextResult() As Boolean _
      Implements IDataReader.NextResult
      Return False
   End Function

   Public Function Read() As Boolean _
      Implements IDataReader.Read
      If (_Connection Is Nothing) Then
         Throw New OQException("Invalid Connection Object")
      End If
      If (_Connection.State <> ConnectionState.Open) Then
         Throw New OQException("Connection must be open before Reading")
      End If
      If (_Connection.MQ Is Nothing) Then
         Throw New OQException("Connection's Internal Queue is invalid.")
      End If

      Try
         _Connection.SetState(ConnectionState.Fetching)
         _Message = _Connection.MQ.Receive(New TimeSpan(0, 0, _
                    _Connection.ConnectionTimeout))
         Dim reader As StreamReader = New StreamReader(_Message.BodyStream)
         Dim xs As XmlSerializer = New XmlSerializer(GetType(OrderObject))
         _Order = CType(xs.Deserialize(reader), OrderObject)
         xs = Nothing
         reader = Nothing
         _ReadCount += 1
         Return True
      Catch e As MessageQueueException
         Return False
      Catch e As InvalidOperationException
         Return False
      Finally
         _Connection.SetState(ConnectionState.Open)
      End Try
   End Function

   Public Sub Dispose() _
      Implements IDisposable.Dispose
      _Connection.Dispose()
      _Message.Dispose()
   End Sub

End Class
