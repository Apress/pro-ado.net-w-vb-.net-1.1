Imports System
Imports System.Data

Module SchemaSample2
    Sub Main()
        Dim BookDataSet As New DataSet()

        BookDataSet.ReadXmlSchema("BookDataSet.xsd")
        BookDataSet.ReadXml("Books.xml")

        Console.WriteLine("Relations Created:")
        Dim xRelation As DataRelation
        For Each xRelation In BookDataSet.Relations
            Console.WriteLine(xRelation.RelationName)
        Next

        Console.WriteLine("Apress Books")
        Console.WriteLine("----------")
        Console.WriteLine()

        Dim xRow As DataRow
        For Each xRow In BookDataSet.Tables("Books").Rows
            Console.WriteLine(xRow("Title"))

            ' Obtain child rows using the KeyTitleRef relation
            Dim zRow As DataRow
            For Each zRow In xRow.GetChildRows("KeyTitleRef")
                Console.WriteLine("  {0}", zRow("Rating"))
            Next
        Next
    End Sub
End Module