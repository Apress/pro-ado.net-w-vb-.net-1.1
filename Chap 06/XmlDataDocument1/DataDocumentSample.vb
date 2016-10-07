Imports System
Imports System.Xml
Imports System.Data

Module DataDocumentSample
    Sub Main()
        Dim DSStudentClasses As New DataSet()
        Dim tmpNode As XmlNode

        ' Load the schema into the DataSet
        DSStudentClasses.ReadXmlSchema("../StudentClasses.xsd")

        ' Load the DataSet into the data document
        Dim XDocStudents As New XmlDataDocument(DSStudentClasses)

        ' Load the data into the data document
        XDocStudents.Load("../Students.xml")

        Console.WriteLine("Students in DataSet:")
        Dim Row As DataRow
        For Each Row In DSStudentClasses.Tables("Student").Rows

            ' If we try to access the locker combination or age, we'll
            ' throw an exception!
            Console.WriteLine("{0}:{1}", Row("Name"), Row("GPA"))
            tmpNode = XDocStudents.GetElementFromRow(Row)
            Console.WriteLine( _
                  "   Locker Combination (from XML, not DataSet): {0}", _
                  tmpNode.SelectSingleNode("LockerCombination").InnerText)

            ' De-comment the following lines to generate an exception
            'Console.WriteLine( _
            '      "   Locker Combination (from DataSet): {0}", _
            '      Row("LockerCombination"))

            Dim Subject As DataRow
            For Each Subject In Row.GetChildRows("StudentClasses")
                Console.WriteLine("   {0}", Subject("Title"))
            Next
        Next
    End Sub
End Module