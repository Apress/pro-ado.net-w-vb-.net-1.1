Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO

Module StreamSample

   Sub Main()
      Dim myConnection As SqlConnection = New SqlConnection( _
            "Server=(local); Initial Catalog=Northwind; " _
            & "Integrated Security=SSPI;")
      myConnection.Open()
      Dim myDA As SqlDataAdapter = New SqlDataAdapter( _
            "SELECT * FROM Customers", myConnection)
      Dim myDS As DataSet = New DataSet()

      myDA.Fill(myDS, "Customers")

      Console.WriteLine(myDS.GetXml())
      myConnection.Close()
      myDS.Dispose()
   End Sub

End Module
