Imports System
Imports System.Data
Imports System.Data.SqlClient

Module CommandBuilderSample

   Sub Main()
      Dim MyDS As DataSet = New DataSet()
      Dim Connection As SqlConnection = New SqlConnection( _
         "Data Source=(local); Initial Catalog=Northwind; " _
         & "Integrated Security=SSPI;")
      Connection.Open()

      Dim MyDA As SqlDataAdapter = New SqlDataAdapter( _
             "SELECT * FROM [Order Details] OD", Connection)
      Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(MyDA)

        Console.WriteLine(myBuilder.GetUpdateCommand().CommandText)
   End Sub

End Module
