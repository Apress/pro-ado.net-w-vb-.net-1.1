Imports System
Imports System.Xml

Module XmlDocumentDemo
    Sub Main()
        Dim FakeQuantity As Integer
        Dim Doc As New XmlDocument()
        Dim newAtt As XmlAttribute
        Dim TempNode As XmlElement

        ' Use the XmlDeclaration class to place the
        ' <?xml version="1.0"?> declaration at the top of our XML file
        Dim dec As XmlDeclaration = Doc.CreateXmlDeclaration("1.0", _
                                         Nothing, Nothing)
        Doc.AppendChild(dec)
        Dim DocRoot As XmlElement = Doc.CreateElement("Orders")
        Doc.AppendChild(DocRoot)

        ' Generate a couple of phony orders
        Dim x As Integer
        For x = 0 To 11
            Dim Order As XmlNode = Doc.CreateElement("Order")
            newAtt = Doc.CreateAttribute("Quantity")
            FakeQuantity = 10 * x + x
            newAtt.Value = FakeQuantity.ToString()
            Order.Attributes.Append(newAtt)
            DocRoot.AppendChild(Order)
        Next

        ' Saves the XML document. We can use a filename or an XmlTextWriter
        ' as the parameter.
        Doc.Save("../OutDocument.xml")

        ' This effectively wipes the document and re-loads
        ' it with the data just generated.
        Doc.Load("../OutDocument.xml")
        Console.WriteLine("Orders Loaded:")

        For x = 0 To DocRoot.ChildNodes.Count - 1
            TempNode = CType(DocRoot.ChildNodes(x), XmlElement)
            Console.WriteLine("Order Quantity: {0}", _
                 TempNode.GetAttribute("Quantity"))
        Next
    End Sub
End Module