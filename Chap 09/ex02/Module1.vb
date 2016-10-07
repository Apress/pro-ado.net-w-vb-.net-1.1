Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Common

Module Module1

    Sub DoDataMappings(ByVal da As OleDbDataAdapter)
        Try
            ' Define an array of column to map
            Dim dcmMappedColumns() As DataColumnMapping = { _
                      New DataColumnMapping("ID", "UserID"), _
                      New DataColumnMapping("fn", "FirstName"), _
                      New DataColumnMapping("ln", "LastName"), _
                      New DataColumnMapping("cty", "City"), _
                      New DataColumnMapping("st", "State")}

            ' Define the table containing the mapped columns
            Dim dtmUsers As New DataTableMapping("Table", "tabUsers", _
            dcmMappedColumns)

            ' Activate the mapping mechanism
            da.TableMappings.Add(dtmUsers)
        Catch ex As Exception

            ' An error occurred. Show the error message
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub Main()
        Try
            ' Define a connection object
            Dim dbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Password=;User ID=Admin;Data Source=..\..\db.mdb")

            ' Create a data adapter to retrieve records from db
            Dim daUsers As New OleDbDataAdapter("SELECT ID, fn, ln, cty, st FROM tabUsers", dbConn)
            Dim dsUsers As New DataSet("User")

            DoDataMappings(daUsers)

            ' Fill the dataset
            daUsers.Fill(dsUsers)

            ' Go through the records and print them using the mapped names
            Dim r As DataRow
            For Each r In dsUsers.Tables("tabUsers").Rows
                Console.WriteLine("ID: {0}, FirstName: {1}, LastName: {2}, City: {3}, State: {4}", r("UserID"), r("FirstName"), r("LastName"), r("City"), r("State"))
            Next
        Catch ex As Exception
            ' An error occurred. Show the error message
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Module