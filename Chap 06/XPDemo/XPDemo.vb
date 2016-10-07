Imports System.Xml

Module XPathDemo
    Sub Main()
        Dim XDoc As New XmlDocument()
        XDoc.Load("../Orders.xml")

        ' The following XPath translates to: "For all those Customers whose
        ' 'Name' attribute begins with 'A', select all Order nodes beneath.
        Dim XNodes As XmlNodeList
        XNodes = XDoc.DocumentElement.SelectNodes( _
                                  "//Customer[starts-with(@Name, 'A')]/Order")

        ' Here's the above using the XPath notation without shorthand.
        ' XNodes = XDoc.DocumentElement.SelectNodes( _
        '          "descendant::Customer[starts-with(attribute::Name, 'A')]" & _
        '                                                       "/child::Order")
        Console.WriteLine("Found {0} Nodes", XNodes.Count)

        Dim XNode As XmlNode
        For Each XNode In XNodes
            Console.WriteLine("Customer {0} ordered {1} {2}", _
                     XNode.ParentNode.Attributes.GetNamedItem("Name").Value, _
                     XNode.Attributes.GetNamedItem("Quantity").Value, _
                     XNode.InnerText)
        Next
    End Sub
End Module