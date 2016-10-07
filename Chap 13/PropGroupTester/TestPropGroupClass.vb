Imports System
Imports PropGroupAssembly

Module TestPropGroupClass
    Sub Main()
        Dim oClass As PropGroupClass = New PropGroupClass
        Dim strXML As String
        Dim fExist As Boolean

        Console.WriteLine("First Execution")
        strXML = oClass.FetchCategoryList(fExist)
        Console.WriteLine("From Cache: {0}", fExist)

        Console.WriteLine("Second Execution")
        strXML = oClass.FetchCategoryList(fExist)
        Console.WriteLine("From Cache: {0}", fExist)
    End Sub
End Module