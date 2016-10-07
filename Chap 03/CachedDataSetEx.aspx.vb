Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class CachedDataSetEx
  Inherits Page

  Protected WithEvents myDataGrid As DataGrid
  Protected WithEvents DataLocation As Label

  Protected Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs)
    Dim myDataSet As DataSet = CType(Cache.Get("CachedDataSet"), DataSet)

    If myDataSet Is Nothing Then
      DataLocation.Text = "<P><B>The data came from a connection " + _
                          "to the database.</B></P>"

      Dim myAdapter As New SqlDataAdapter( _
         "SELECT TOP 10 ProductID, ProductName, UnitPrice FROM Products;", _
         "server=localhost;database=Northwind;uid=sa;pwd=;")
      myDataSet = New DataSet()
      myAdapter.Fill(myDataSet, "Products")

      ' Add a key-value pair to the ExtendedProperties
      ' specifying what time the DataSet was created.
      myDataSet.ExtendedProperties.Add( _
                         "CreateTime", DateTime.Now.ToLongTimeString())

      ' Insert the DataSet object in cache, setting a null file
      ' dependency (this object does not depend on file changes)
      ' and a five minute expiration interval
      Cache.Insert("CachedDataSet", myDataSet, Nothing, _
                         DateTime.Now.AddMinutes(5), TimeSpan.Zero)
    Else
      DataLocation.Text = "<P><B>The data came from the cache. " + _
                   "It was created at: " + _
                   myDataSet.ExtendedProperties("CreateTime").ToString() + _
                   "</P><P>The current system time is: " + _
                   DateTime.Now.ToLongTimeString() + "</B></P>"
    End If

    myDataGrid.DataSource = myDataSet.Tables("Products")
    myDataGrid.DataBind()
  End Sub
End Class