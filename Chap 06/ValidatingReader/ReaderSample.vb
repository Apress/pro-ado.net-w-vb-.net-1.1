Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema

Module ReaderSample

    Sub Main()
        Dim xtr As New XmlTextReader("../BooksComplex.xml")
        Dim xvr As New XmlValidatingReader(xtr)

        xvr.ValidationType = ValidationType.Schema
        AddHandler xvr.ValidationEventHandler, _
                   New ValidationEventHandler(AddressOf ValidationErrorHandler)

        ' Traverse the entire document. If something is wrong, an event
        ' will be thrown and we'll display it. We don't stop traversing,
        ' so one error could cascade and cause dozens more after it.
        While xvr.Read()
            If TypeOf xvr.SchemaType Is XmlSchemaComplexType Then
                Console.WriteLine("{0} - {1}", xvr.NodeType, xvr.Name)
                While xvr.MoveToNextAttribute()
                    Console.WriteLine("  {0} - {1}: {2}", _
                                        xvr.NodeType, xvr.Name, xvr.Value)
                End While
            End If
        End While
    End Sub

    Sub ValidationErrorHandler(ByVal sender As Object, _
                               ByVal args As ValidationEventArgs)
        Console.WriteLine("XML Document Validation Failure")
        Console.WriteLine()
        Console.WriteLine("The ValidatingReader Failed with severity : {0}", _
                                                                args.Severity)
        Console.WriteLine("The failure message was: {0}", args.Message)
    End Sub
End Module
