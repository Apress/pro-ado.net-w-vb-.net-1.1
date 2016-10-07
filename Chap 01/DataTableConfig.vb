Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        ' Create the connection
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("constring"))

        ' Create the command object
        Dim str As String = _
                        "SELECT EmployeeID, FirstName, LastName FROM Employees"
        Dim cmd As New SqlCommand(str, con)

        ' Create a new data adapter object, passing in the SELECT command
        Dim da As New SqlDataAdapter(cmd)

        ' Create a new DataSet
        Dim ds As New DataSet()

        ' Fill the DataSet, using the data adapter
        da.Fill(ds, "Employees")

        ' Display the column names
        Dim dc As DataColumn
        For Each dc In ds.Tables(0).Columns
            Console.Write("{0,15}", dc.ColumnName)
        Next

        ' Add a newline after the column headings
        Console.Write(vbCrLf)

        ' Display the data for each row. Loop through the rows first.
        Dim dr As DataRow
        For Each dr In ds.Tables(0).Rows

            ' Then loop through the columns for the current row.
            Dim i As Integer
            For i = 1 To ds.Tables(0).Columns.Count
                Console.Write("{0,15}", dr(i - 1))
            Next i

            ' Add a line break after every row
            Console.Write(vbCrLf)
        Next
    End Sub

End Module
