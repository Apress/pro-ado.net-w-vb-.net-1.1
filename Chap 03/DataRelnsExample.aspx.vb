Option Explicit

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class DataRelnsExample
  Inherits Page

  ' Map the Web Form server controls
  Protected WithEvents customersDataGrid As DataGrid
  Protected WithEvents ordersDataGrid As DataGrid

  ' Declare the DataSet object at the class level
  Protected myDataSet As DataSet

  Private Sub MakeData()
    myDataSet = CType(Cache.Get("myDataSet"), DataSet)

    ' If myDataSet is not in the cache, create it
    If myDataSet Is Nothing Then
      myDataSet = New DataSet("Northwind")

      ' Create the SQL and ConnectionString values
      Dim mySqlStmt As String = "SELECT CustomerID, CompanyName, " & _
            "ContactName, ContactTitle FROM Customers ORDER BY CustomerID"
      Dim myConString As String = _
            "server=localhost;database=Northwind;uid=sa;pwd=;"

      ' Construct a new SqlDataAdapter with the preceding values
      Dim myDataAdapter As New SqlDataAdapter(mySqlStmt, myConString)

      ' Invoke the Fill() method to create a new DataTable in the DataSet
      myDataAdapter.Fill(myDataSet, "Customers")

      ' Change the DataAdapter's SelectCommand and fill another table
      mySqlStmt = "SELECT OrderID, CustomerID,OrderDate, " & _
                  "RequiredDate, ShippedDate FROM Orders " & _
                  "ORDER BY CustomerID"
      myDataAdapter.SelectCommand.CommandText = mySqlStmt

      myDataAdapter.Fill(myDataSet, "Orders")

      Dim pk(1) As DataColumn
      pk(0) = myDataSet.Tables("Customers").Columns("CustomerID")
      myDataSet.Tables("Customers").PrimaryKey = pk

      ' Create a relation ship between Customers and Orders
      myDataSet.Relations.Add("CustomersToOrders", _
                      myDataSet.Tables("Customers").Columns("CustomerID"), _
                      myDataSet.Tables("Orders").Columns("CustomerID"))

      Cache.Insert("myDataSet", myDataSet)
    End If
  End Sub

  Private Sub BindData()
    customersDataGrid.DataSource = myDataSet.Tables("Customers")
    ordersDataGrid.DataSource = myDataSet.Tables("Orders")
    Page.DataBind()
  End Sub

  Protected Sub DeleteCustomer(ByVal Sender As Object, _
                               ByVal E As DataGridCommandEventArgs)

    MakeData()

    ' Find the DataRow based on the primary key value
    Dim myDataRow As DataRow = _
               myDataSet.Tables("Customers").Rows.Find(E.Item.Cells(1).Text)

    ' Remove the DataRow from the DataSet and bind the server control
    myDataSet.Tables("Customers").Rows.Remove(myDataRow)
    BindData()
  End Sub

  Protected Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs)
    If Not Page.IsPostBack Then

      ' Create a new DataSet by invoking the MakeData() method
      MakeData()

      ' Bind the data to the server controls
      BindData()
    End If
  End Sub
End Class