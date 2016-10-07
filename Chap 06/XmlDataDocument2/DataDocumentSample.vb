Imports System
Imports System.Xml
Imports System.Data

Module DataDocumentSample
    Sub Main()
        Dim StudentClasses As New Students()
        Dim XDocStudents As New XmlDataDocument(StudentClasses)
        XDocStudents.Load("../Students.xml")

        Console.WriteLine("Students in Typed DataSet:")
        Dim Student As Students.StudentRow
        For Each Student In StudentClasses.Student.Rows
            Console.WriteLine("{0}:{1}", Student.Name, Student.GPA)
            Dim Subject As Students._ClassRow
            For Each Subject In Student.GetClassRows()
                Console.WriteLine("   {0} in Room {1}", Subject.Title, Subject.Room)
            Next
        Next

        Console.WriteLine()
        Console.WriteLine("Students who have classes in Room 100:")
        Console.WriteLine("--------------------------------------")
        Dim tmpNodes As XmlNodeList = _
                   XDocStudents.SelectNodes("//Student/Class[@Room='100']")
        Dim i As Integer
        For i = 0 To tmpNodes.Count - 1
            Console.WriteLine("{0}", _
                     tmpNodes(i).ParentNode.SelectSingleNode("Name").InnerText)
        Next
    End Sub
End Module