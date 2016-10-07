<XmlRoot(ElementName:="OrderItem"), _
 Serializable()> _
Public Class OrderItem
   Private _Quantity As Integer
   Private _StockNumber As String
   Private _Price As Single
   Private _OrderID As String

   Public Sub New()
      _Quantity = 0
      _Price = 0
      _StockNumber = "--"
      _OrderID = ""
   End Sub

   Public Sub New(ByVal StockNumber As String, ByVal Quantity As Integer, _
         ByVal Price As Single, ByVal OrderID As String)
      _Quantity = Quantity
      _Price = Price
      _StockNumber = StockNumber
      _OrderID = OrderID
   End Sub

   <XmlAttributeAttribute()> _
   Public Property Quantity() As Integer
      Get
         Return _Quantity
      End Get
      Set(ByVal Value As Integer)
         _Quantity = Value
      End Set
   End Property

   <XmlAttributeAttribute()> _
   Public Property StockNumber() As String
      Get
         Return _StockNumber
      End Get
      Set(ByVal Value As String)
         _StockNumber = Value
      End Set
   End Property

   <XmlAttributeAttribute()> _
   Public Property Price() As Single
      Get
         Return _Price
      End Get
      Set(ByVal Value As Single)
         _Price = Value
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
End Class
