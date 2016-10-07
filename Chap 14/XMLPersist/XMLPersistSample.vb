Imports System
Imports System.Data
Imports System.Data.SqlClient

Module XMLPersistSample

    Sub Main()
        Dim myDS As DataSet = New DataSet()
        myDS.ReadXml("..\..\Customers_ADO.XML")

        Console.WriteLine("Customers Table, Persisted from ADO 2.7")
        Dim Row As DataRow
        For Each Row In myDS.Tables("row").Rows
            Console.WriteLine("{0} from {1}", Row("ContactName"), _
                              Row("CompanyName"))
        Next
        Console.ReadLine()
        myDS.Dispose()
    End Sub

End Module
