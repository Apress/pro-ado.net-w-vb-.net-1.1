<XmlRoot(ElementName:="Order"), _
 XmlInclude(GetType(OrderItem))> _
Public Class OrderObject
   Private _OrderItems As ArrayList
   Private _CustomerID As String
   Private _OrderID As String
   Private _ShipToName As String
   Private _ShipToAddr1 As String
   Private _ShipToAddr2 As String
   Private _ShipToCity As String
   Private _ShipToState As String
   Private _ShipToZip As String
   Private _ShipToCountry As String
   Private _ShipMethod As String

   Public Sub New()
      _OrderItems = New ArrayList()
   End Sub

   Public Sub New(ByVal CustomerID As String, ByVal OrderID As String, _
         ByVal ShipToName As String, ByVal ShipToAddr1 As String, _
         ByVal ShipToAddr2 As String, ByVal ShipToCity As String, _
         ByVal ShipToState As String, ByVal ShipToZip As String, _
         ByVal ShipToCountry As String, ByVal ShipMethod As String)
      _OrderItems = New ArrayList()
      _CustomerID = CustomerID
      _OrderID = OrderID
      _ShipToName = ShipToName
      _ShipToAddr1 = ShipToAddr1
      _ShipToAddr2 = ShipToAddr2
      _ShipToCity = ShipToCity
      _ShipToState = ShipToState
      _ShipToZip = ShipToZip
      _ShipToCountry = ShipToCountry
      _ShipMethod = ShipMethod
   End Sub

   Public Sub AddItem(ByVal StockNumber As String, _
         ByVal Quantity As Integer, ByVal Price As Single)
      Dim newItem As OrderItem = New OrderItem(StockNumber, _
         Quantity, Price, _OrderID)
      _OrderItems.Add(newItem)
   End Sub

   Public Sub ClearItems()
      _OrderItems.Clear()
   End Sub

   <XmlAttributeAttribute()> _
   Public Property CustomerID() As String
      Get
         Return _CustomerID
      End Get
      Set(ByVal Value As String)
         _CustomerID = Value
      End Set
   End Property

   <XmlAttributeAttribute()> _
   Public Property OrderID() As String
      Get
         Return _OrderID
      End Get
      Set(ByVal Value As String)
         _OrderID = Value
      End Set
   End Property

   <XmlAttributeAttribute()> _
   Public Property ShipToName() As String
      Get
         Return _ShipToName
      End Get
      Set(ByVal Value As String)
         _ShipToName = Value
      End Set
   End Property

   <XmlAttributeAttribute()> _
   Public Property ShipToAddr1() As String
      Get
         Return _ShipToAddr1
      End Get
      Set(ByVal Value As String)
         _ShipToAddr1 = Value
      End Set
   End Property

   <XmlAttributeAttribute()> _
   Public Property ShipToAddr2() As String
      Get
         Return _ShipToAddr2
      End Get
      Set(ByVal Value As String)
         _ShipToAddr2 = Value
      End Set
   End Property

   <XmlAttributeAttribute()> _
   Public Property ShipToCity() As String
      Get
         Return _ShipToCity
      End Get
      Set(ByVal Value As String)
         _ShipToCity = Value
      End Set
   End Property

   <XmlAttributeAttribute()> _
   Public Property ShipToState() As String
      Get
         Return _ShipToState
      End Get
      Set(ByVal Value As String)
         _ShipToState = Value
      End Set
   End Property

   <XmlAttributeAttribute()> _
   Public Property ShipToZip() As String
      Get
         Return _ShipToZip
      End Get
      Set(ByVal Value As String)
         _ShipToZip = Value
      End Set
   End Property

   <XmlAttributeAttribute()> _
   Public Property ShipToCountry() As String
      Get
         Return _ShipToCountry
      End Get
      Set(ByVal Value As String)
         _ShipToCountry = Value
      End Set
   End Property

   <XmlAttributeAttribute()> _
   Public Property ShipMethod() As String
      Get
         Return _ShipMethod
      End Get
      Set(ByVal Value As String)
         _ShipMethod = Value
      End Set
   End Property

   <XmlElementAttribute()> _
   Public ReadOnly Property OrderItems() As ArrayList
      Get
         Return _OrderItems
      End Get
   End Property
End Class
