Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO

Module SchemaGenerator
    Sub Main()
        ' Create a new instance of an XML schema
        Dim Schema As XmlSchema = New XmlSchema()

        ' Produce the following XSD in the document
        ' <element name="Book">
        Dim ElementBook As New XmlSchemaElement()
        Schema.Items.Add(ElementBook)
        ElementBook.Name = "Book"

        ' <complexType>
        Dim ComplexType As New XmlSchemaComplexType()
        ElementBook.SchemaType = ComplexType

        Dim Sequence As New XmlSchemaSequence()
        ComplexType.Particle = Sequence

        ' <element name="Title" ...
        Dim ElementTitle As New XmlSchemaElement()
        ElementTitle.Name = "Title"

        ' Indicate that the data type of the Title element is not just
        ' "any" string, but the string as defined by the W3C's namespace
        ElementTitle.SchemaTypeName = New XmlQualifiedName("string", _
                                       "http://www.w3.org/2001/XMLSchema")

        Dim ElementPublisher As New XmlSchemaElement()
        ElementPublisher.Name = "Publisher"
        ElementPublisher.SchemaTypeName = New XmlQualifiedName("string", _
                                       "http://www.w3.org/2001/XMLSchema")

        Sequence.Items.Add(ElementTitle)
        Sequence.Items.Add(ElementPublisher)

        ' Just because we used code to create all the nodes, it doesn't mean
        ' that the schema is automatically valid. We need to compile the schema
        ' before we write it to make sure it is valid.
        Schema.Compile(New ValidationEventHandler(AddressOf ValidationHandler))
        Schema.Write(Console.Out)
    End Sub

    Sub ValidationHandler(ByVal sender As Object, _
                          ByVal args As ValidationEventArgs)
        Console.WriteLine("Schema Validation Failed.")
        Console.WriteLine(args.Message)
    End Sub
End Module