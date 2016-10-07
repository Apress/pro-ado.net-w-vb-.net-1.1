Imports System.Data
Imports System.Data.SqlClient

Module ErrorSample

   Sub Main()
      Dim myConnection As SqlConnection
      Dim myDS As DataSet = New DataSet()
      Dim myDA As SqlDataAdapter

      myConnection = New SqlConnection( _
         "Server=(local);Initial Catalog=Northwind; " _
         & "Integrated Security=SSPI;")
      myConnection.Open()

      Try
         myDA = New SqlDataAdapter("SELECT * FROM Customer", myConnection)
         myDA.Fill(myDS, "Customers")
      Catch E As SqlException
         Console.WriteLine("A Data Exception Occurred.")
         Console.WriteLine("Source: {0}", E.Source)
         Console.WriteLine("Message: {0}", E.Message)
         If Not E.InnerException Is Nothing Then
            Console.WriteLine("Inner: {0}", E.InnerException.Message)
         End If
         End
      Catch RE As Exception
         Console.WriteLine("An unexpected Exception has occurred.")
         Console.WriteLine(RE.Message)
         End
      End Try
      Console.WriteLine("Filled DataSet")
      myDS.Dispose()
      myDA.Dispose()
      myConnection.Close()

   End Sub

End Module
