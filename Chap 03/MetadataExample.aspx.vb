Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class MetadataExample
  Inherits Page

  ' Map the Web Form server controls
  Protected WithEvents metadataDataGrid As DataGrid

  Protected Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs) 
    If Not Page.IsPostBack Then

      ' Create a new DataSet with name "Northwind"
      Dim myDataSet As New DataSet("Northwind")

      ' Create the SQL and ConnectionString values
      Dim mySqlStmt As String = "SELECT TOP 10 CustomerID, CompanyName, " & _
                                "ContactName, ContactTitle FROM Customers"
      Dim myConString As String = "server=localhost;database=Northwind;uid=sa;pwd=;"

      ' Construct a new SqlDataAdapter with the preceding values
      Dim myDataAdapter As New SqlDataAdapter(mySqlStmt, myConString)

      ' Invoke the Fill() method to create a new DataTable in the DataSet
      myDataAdapter.Fill(myDataSet, "Customers")

      metadataDataGrid.DataSource = myDataSet.Tables
      Page.DataBind()

    End If
  End Sub
End Class