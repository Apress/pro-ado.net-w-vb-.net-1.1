Imports System
Imports System.Data

Module SuppliedSchema
    Sub Main()
        Dim MyDS As New DataSet()
        MyDS.ReadXmlSchema("BooksComplex.xsd")

        Console.WriteLine("Supplied Relational Structure:")
        Dim Table As DataTable
        For Each Table In MyDS.Tables
            Console.WriteLine("Table {0}", Table.TableName)
            Dim Column As DataColumn
            For Each Column In Table.Columns
                Console.WriteLine("  {0}", Column.ColumnName)
            Next
        Next
    End Sub
End Module