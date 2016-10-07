Imports System
Imports System.Data
Imports System.Data.SqlClient

Module CommandSample

   Sub Main()
      Dim MyDS As DataSet = New DataSet()
      Dim Connection As SqlConnection = New SqlConnection( _
         "Data Source=(local); Initial Catalog=Northwind; " _
         & "Integrated Security=SSPI;")
      Connection.Open()

      Dim MyDA As SqlDataAdapter = New SqlDataAdapter()
      MyDA.SelectCommand = New SqlCommand("Sales by Year", Connection)
      MyDA.SelectCommand.CommandType = CommandType.StoredProcedure
      MyDA.SelectCommand.Parameters.Add(New SqlParameter("@Beginning_Date", _
         SqlDbType.DateTime))
      MyDA.SelectCommand.Parameters("@Beginning_Date").Value = _
         DateTime.Parse("01/01/1996")

      MyDA.SelectCommand.Parameters.Add(New SqlParameter("@Ending_Date", _
         SqlDbType.DateTime))
      MyDA.SelectCommand.Parameters("@Ending_Date").Value = _
        DateTime.Parse("01/01/1997")

      MyDA.Fill(MyDS, "SalesByYear")

      Dim _Column As DataColumn
      Dim tabChar = Chr(9)
      For Each _Column In MyDS.Tables("SalesByYear").Columns
         Console.Write("{0}" & tabChar, _Column.ColumnName)
      Next
      Console.WriteLine()
      Console.WriteLine( _
         "-----------------------------------------------------")

      Dim _Row As DataRow
      For Each _Row In MyDS.Tables("SalesByYear").Rows
         For Each _Column In MyDS.Tables("SalesByYear").Columns
            Console.Write("{0}" & tabChar, _Row(_Column))
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
