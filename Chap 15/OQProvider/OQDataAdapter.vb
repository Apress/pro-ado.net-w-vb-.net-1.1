Public Class OQDataAdapter
   Implements IDataAdapter

   Private _SendCommand As OQCommand
   Private _ReceiveCommand As OQCommand

   Public Sub New()
   End Sub

   Public Property MissingMappingAction() _
      As MissingMappingAction _
      Implements IDataAdapter.MissingMappingAction
      Get
         Return MissingMappingAction.Passthrough
      End Get
      Set(ByVal Value As MissingMappingAction)
         ' do nothing
      End Set
   End Property

   Public Property MissingSchemaAction() _
      As MissingSchemaAction _
      Implements IDataAdapter.MissingSchemaAction
      Get
         Return MissingSchemaAction.Add
      End Get
      Set(ByVal Value As MissingSchemaAction)
         ' do nothing
      End Set
   End Property

   Public ReadOnly Property TableMappings() As ITableMappingCollection _
      Implements IDataAdapter.TableMappings
      Get
         Return Nothing
      End Get
   End Property

   Public Function Fill(ByVal dataSet As DataSet) As Integer _
      Implements IDataAdapter.Fill
      If (_ReceiveCommand Is Nothing) Then
         Throw New OQException( _
            "Cannot Fill without a valid ReceiveCommand.")
      End If
      If (dataSet.Tables.Contains("Orders")) Then
         dataSet.Tables.Remove("Orders")
      End If
      FillSchema(dataSet, SchemaType.Mapped)
      Dim Orders As DataTable = dataSet.Tables("Orders")
      Dim OrderItems As DataTable = dataSet.Tables("OrderItems")

      Dim myReader As OQDataReader = _
         CType(_ReceiveCommand.ExecuteReader(), OQDataReader)
      Dim myOrder As OrderObject

      While (myReader.Read())
         myOrder = myReader.GetOrder()
         Dim newOrder As DataRow = Orders.NewRow()
         newOrder("CustomerID") = myOrder.CustomerID
         newOrder("OrderID") = myOrder.OrderID
         newOrder("ShipToName") = myOrder.ShipToName
         newOrder("ShipToAddr1") = myOrder.ShipToAddr1
         newOrder("ShipToAddr2") = myOrder.ShipToAddr2
         newOrder("ShipToCity") = myOrder.ShipToCity
         newOrder("ShipToState") = myOrder.ShipToState
         newOrder("ShipToCountry") = myOrder.ShipToCountry
         newOrder("ShipMethod") = myOrder.ShipMethod
         newOrder("ShipToZip") = myOrder.ShipToZip
         Orders.Rows.Add(newOrder)
         Dim itm As OrderItem
         For Each itm In myOrder.OrderItems
            Dim newItem As DataRow = OrderItems.NewRow()
            newItem("Quantity") = itm.Quantity
            newItem("StockNumber") = itm.StockNumber
            newItem("Price") = itm.Price
            newItem("OrderID") = myOrder.OrderID
            OrderItems.Rows.Add(newItem)
         Next
      End While
      ' this will make everything we just put into the DataSet
      ' appear as unchanged. This allows us to distinguish
      ' between items that came from the Queue and items that
      ' came from the DS.
      dataSet.AcceptChanges()
      Return 0
   End Function

   Public Function FillSchema(ByVal dataSet As DataSet, _
         ByVal schemaType As SchemaType) As DataTable() _
      Implements IDataAdapter.FillSchema
      Dim x(2) As DataTable
      Dim OID_Parent As DataColumn
      Dim OID_Child As DataColumn
      Dim ParentKeys(1) As DataColumn
      Dim ChildKeys(2) As DataColumn

      x(0) = New DataTable("Orders")
      x(1) = New DataTable("OrderItems")

      x(0).Columns.Add("CustomerID", GetType(String))
      x(0).Columns.Add("OrderID", GetType(String))
      x(0).Columns.Add("ShipToName", GetType(String))
      x(0).Columns.Add("ShipToAddr1", GetType(String))
      x(0).Columns.Add("ShipToAddr2", GetType(String))
      x(0).Columns.Add("ShipToCity", GetType(String))
      x(0).Columns.Add("ShipToState", GetType(String))
      x(0).Columns.Add("ShipToZip", GetType(String))
      x(0).Columns.Add("ShipToCountry", GetType(String))
      x(0).Columns.Add("ShipMethod", GetType(String))

      OID_Parent = x(0).Columns("OrderID")
      ParentKeys(0) = OID_Parent
      x(0).PrimaryKey = ParentKeys

      x(1).Columns.Add("Quantity", GetType(Integer))
      x(1).Columns.Add("StockNumber", GetType(String))
      x(1).Columns.Add("Price", GetType(Single))
      x(1).Columns.Add("OrderID", GetType(String))
      OID_Child = x(1).Columns("OrderID")
      ChildKeys(0) = OID_Child
      ChildKeys(1) = x(1).Columns("StockNumber")

      If (dataSet.Tables.Contains("Orders")) Then
         dataSet.Tables.Remove("Orders")
      End If
      If (dataSet.Tables.Contains("OrderItems")) Then
         dataSet.Tables.Remove("OrderItems")
      End If

      dataSet.Tables.Add(x(0))
      dataSet.Tables.Add(x(1))
      dataSet.Relations.Add("OrderItems", OID_Parent, _
         OID_Child, True)
      Return x
   End Function

   Public Function GetFillParameters() As IDataParameter() _
      Implements IDataAdapter.GetFillParameters
      Return Nothing
   End Function

   Public Function Update(ByVal dataSet As DataSet) As Integer _
      Implements IDataAdapter.Update

      Dim rowCount As Integer = 0
      If (_SendCommand Is Nothing) Then
         Throw New OQException( _
         "Cannot Update Queued DataSet without a valid SendCommand")
      End If

      Dim UpdatedOrders As DataRow() = _
         dataSet.Tables("Orders").Select("", "", DataViewRowState.Added)

      Dim _Order As DataRow
      For Each _Order In UpdatedOrders
         Dim Items As DataRow() = _Order.GetChildRows("OrderItems")
         Dim myOrder As OrderObject = New OrderObject()
         myOrder.CustomerID = _Order("CustomerID").ToString()
         myOrder.OrderID = _Order("OrderID").ToString()
         myOrder.ShipToName = _Order("ShipToName").ToString()
         myOrder.ShipToAddr1 = _Order("ShipToAddr1").ToString()
         myOrder.ShipToAddr2 = _Order("ShipToAddr2").ToString()
         myOrder.ShipToCity = _Order("ShipToCity").ToString()
         myOrder.ShipToState = _Order("ShipToState").ToString()
         myOrder.ShipToZip = _Order("ShipToZip").ToString()
         myOrder.ShipToCountry = _Order("ShipToCountry").ToString()
         myOrder.ShipMethod = _Order("ShipMethod").ToString()
         Dim _Item As DataRow
         For Each _Item In Items
            myOrder.AddItem(_Item("StockNumber").ToString(), _
                    CType(_Item("Quantity"), Integer), _
                    CType(_Item("Price"), Single))
         Next

         _SendCommand.Parameters("Order") = New OQParameter(myOrder)
         _SendCommand.ExecuteNonQuery()
         rowCount += 1
      Next
      dataSet.Tables("OrderItems").Clear()
      dataSet.Tables("Orders").Clear()
      Return rowCount
   End Function

   Public Property SendCommand() As OQCommand
      Get
         Return _SendCommand
      End Get
      Set(ByVal Value As OQCommand)
         _SendCommand = Value
      End Set
   End Property

   Public Property ReceiveCommand() As OQCommand
      Get
         Return _ReceiveCommand
      End Get
      Set(ByVal Value As OQCommand)
         _ReceiveCommand = Value
      End Set
   End Property
End Class
