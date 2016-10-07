Public Class OQParameter
   Implements IDataParameter

   Private _Order As OrderObject

   Public Sub New()
   End Sub

   Public Sub New(ByVal Order As OrderObject)
      _Order = Order
   End Sub

   Public Property DbType() As DbType _
      Implements IDataParameter.DbType
      Get
         Return DbType.Object
      End Get
      Set(ByVal Value As DbType)
         ' do nothing
      End Set
   End Property

   Public Property Direction() As ParameterDirection _
      Implements IDataParameter.Direction
      Get
         Return ParameterDirection.Input
      End Get
      Set(ByVal Value As ParameterDirection)
         ' do nothing
      End Set
   End Property

   Public ReadOnly Property IsNullable() As Boolean _
      Implements IDataParameter.IsNullable
      Get
         Return False
      End Get
   End Property

   Public Property ParameterName() As String _
      Implements IDataParameter.ParameterName
      Get
         Return "Order"
      End Get
      Set(ByVal Value As String)
         ' do nothing
      End Set
   End Property

   Public Property SourceColumn() As String _
      Implements IDataParameter.SourceColumn
      Get
         Return ""
      End Get
      Set(ByVal Value As String)
         ' do nothing
      End Set
   End Property

   Public Property SourceVersion() As DataRowVersion _
      Implements IDataParameter.SourceVersion
      Get
         Return DataRowVersion.Original
      End Get
      Set(ByVal Value As DataRowVersion)
         ' do nothing
      End Set
   End Property

   Public Property Value() As Object _
      Implements IDataParameter.Value
      Get
         Return _Order
      End Get
      Set(ByVal Value As Object)
         _Order = CType(Value, OrderObject)
      End Set
   End Property
End Class
