Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Module DBSchema
    Sub Main()
        ' Create the data adapter object pointing to the authors table
        Dim da As New SqlDataAdapter( _
                   "SELECT au_id, au_lname, au_fname, phone FROM authors", _
                   "server=(local);database=pubs;integrated security=sspi")

        Dim ds As New DataSet("Authors")
        da.FillSchema(ds, SchemaType.Source)
        ds.ReadXml("..\SampleData.xml")

        Dim Table As DataTable = ds.Tables(0)
        Dim numCols As Integer = Table.Columns.Count

        Dim Row As DataRow
        For Each Row In Table.Rows
            Dim i As Integer
            For i = 0 To numCols - 1
                Console.WriteLine(Table.Columns(i).ColumnName & " = " & Row(i))
            Next
            Console.WriteLine()
        Next
    End Sub
End Module