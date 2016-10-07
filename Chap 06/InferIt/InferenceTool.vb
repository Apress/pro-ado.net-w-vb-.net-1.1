Imports System
Imports System.Data

Module InferenceTool

   Sub Main(ByVal args As String())
      Dim nsArray As String() = {""}
      If args.Length < 2 Then
         Console.WriteLine("InferIt Sample")
         Console.WriteLine("Copyright(c) 2004 Apress Press Ltd")
         Console.WriteLine("Usage: InferIt <Input.XML> <Output.XSD>")
      End If

      ' It doesn't get much simpler than this. The DataSet is doing
      ' all of the inference work for us.
      Dim MyDS As DataSet = New DataSet()
      MyDS.ReadXml(args(0))

      Console.WriteLine("Inference Tester.")
      Console.WriteLine("Inferred Relational Structure:")
      Dim myTable As DataTable
      For Each myTable In MyDS.Tables
         Console.WriteLine("Table {0}", myTable.TableName)
         Dim myColumn As DataColumn
         For Each myColumn In myTable.Columns
            Console.WriteLine("  {0}", myColumn.ColumnName)
         Next
      Next

      Console.WriteLine()
      Console.WriteLine("Inferred Relations:")
      Dim myRelation As DataRelation
      For Each myRelation In MyDS.Relations
         Console.WriteLine(myRelation.RelationName)
      Next
      MyDS.WriteXmlSchema(args(1))
   End Sub

End Module
