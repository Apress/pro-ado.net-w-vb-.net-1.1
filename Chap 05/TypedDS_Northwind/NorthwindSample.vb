Imports System
Imports System.Data
Imports System.Data.SqlClient

Module NorthwindSample
    Sub Main()
        Dim Connection As New SqlConnection( _
           "Server=(local);Initial Catalog=Northwind;Integrated Security=SSPI;")
        Connection.Open()

        Dim CustomersDA As New SqlDataAdapter( _
                                       "SELECT * FROM Customers", Connection)
        Dim OrdersDA As New SqlDataAdapter( _
                                       "SELECT * FROM Orders", Connection)
        Dim CustOrders As New CustomerOrders()

        CustomersDA.Fill(CustOrders, "Customers")
        OrdersDA.Fill(CustOrders, "Orders")

        Dim FirstCustomer As CustomerOrders.CustomersRow = _
                                      CustOrders.Customers(0)
        Console.WriteLine("{0}'s Freight Charges To Date:", _
                                      FirstCustomer.ContactName)
        Dim Order As CustomerOrders.OrdersRow
        For Each Order In FirstCustomer.GetOrdersRows()
            Console.WriteLine("Order: Freight: {0:C}, Date: {1}", _
                          Order.Freight, Order.OrderDate.ToShortDateString())
        Next
    End Sub
End Module