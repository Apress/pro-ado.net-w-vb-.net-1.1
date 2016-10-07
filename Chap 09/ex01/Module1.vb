Imports System.Data.OleDb

Module Module1

    Sub Main()
        Try
            ' Define a connection object
            Dim dbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Password=;User ID=Admin;Data Source=..\..\db.mdb")

            ' Create a data adapter to retrieve records from db
            Dim strSELECT As String = "SELECT ID AS UserID, fn AS FirstName, ln AS LastName, cty AS City, st AS State FROM tabUsers"
            Dim daUsers As New OleDbDataAdapter(strSELECT, dbConn)
            Dim dsUsers As New DataSet("Users")

            ' Fill the dataset
            daUsers.Fill(dsUsers)

            ' Go through the records and print them using the mapped names
            Dim r As DataRow
            For Each r In dsUsers.Tables(0).Rows
                Console.WriteLine("ID: {0}, FirstName: {1}, LastName: {2}, City: {3}, State: {4}", r("UserID"), r("FirstName"), r("LastName"), r("City"), r("State"))
            Next
        Catch ex As Exception

            ' An error occurred. Show the error message
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Module
