Imports System
Imports System.Data

Module XmlDataReader

    Sub Main()
        Dim MyDS As New DataSet()
        MyDS.ReadXmlSchema("../Books.xsd")
        Console.WriteLine("Schema Loaded.")

        Dim Table As DataTable
        For Each Table In MyDS.Tables
            Console.WriteLine("Table {0}, {1} Columns", _
                              Table.TableName, Table.Columns.Count)
        Next

        MyDS.ReadXml("../Books.xml", XmlReadMode.IgnoreSchema)
        Console.WriteLine("Data Loaded.")
        Console.WriteLine()
        Dim Book As DataRow
        For Each Book In MyDS.Tables("Book").Rows
            Console.WriteLine("{0} : {1} - ${2}", _
                              Book("ISBN"), Book("Title"), Book("Price"))
        Next
    End Sub
End Module