Imports System
Imports System.Data

Module DataSetWriter
    Sub Main()
        Dim MyDS As New DataSet()
        MyDS.ReadXmlSchema("../Books.xsd")
        MyDS.ReadXml("../Books.xml")

        ' If we don't call AcceptChanges(), the DataSet thinks
        ' that _all_ data read from disk is "new". We only want
        ' the row that we add programmatically to appear as "new".
        MyDS.AcceptChanges()

        Console.WriteLine("Data loaded from disk.")

        Dim NewBook As DataRow = MyDS.Tables("Book").NewRow()
        NewBook("ISBN") = "1590594347"
        NewBook("Title") = "This ADO.NET Book"
        NewBook("Price") = 49.99
        MyDS.Tables("Book").Rows.Add(NewBook)

        ' With the new row added, the DataSet is storing
        ' "change" data. We can store this change as a DiffGram.
        MyDS.WriteXml("../Books_Changes.xml", XmlWriteMode.DiffGram)

        ' Now commit the changes and write the entire DataSet.
        MyDS.AcceptChanges()
        MyDS.WriteXml("../Books_New.xml", XmlWriteMode.IgnoreSchema)

        Console.WriteLine("Changes and entire DS have been written.")
    End Sub
End Module