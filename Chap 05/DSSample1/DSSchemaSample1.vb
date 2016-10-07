Imports System
Imports System.Data

Module DSSchemaSample1
    Sub Main()
        Dim BookDataSet As DataSet = New DataSet()
        BookDataSet.ReadXmlSchema("BookDataSet.xsd")
        BookDataSet.ReadXml("Books.xml")

        Console.WriteLine("Recent Books:")
        Console.WriteLine("-------------")
        Dim xRow As DataRow
        For Each xRow In BookDataSet.Tables("Books").Rows
            Console.WriteLine("{0} by {1}", xRow("Title"), xRow("Publisher"))
        Next
    End Sub
End Module