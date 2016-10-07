Imports System
Imports System.Data

Module FidelityTester
    Sub Main()
        Dim MyDS As New DataSet()

        ' Load the schema (inferring it won't demonstrate fidelity loss)
        MyDS.ReadXmlSchema("../Books.xsd")

        ' Load the original document data
        MyDS.ReadXml("../Books.xml")

        ' We're doing nothing to the data apart from writing it out
        ' to a new XML file so that we can compare before and after
        MyDS.WriteXml("../Books_After.xml")
    End Sub
End Module