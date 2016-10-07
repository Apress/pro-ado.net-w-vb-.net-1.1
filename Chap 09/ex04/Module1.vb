Imports System.Data.Common
Imports System.Data.OleDb

Module Module1

    Sub Main()
        Dim dsUsers As New DataSet("Users")

        Try
            ' Define a connection object
            Dim dbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Password=;User ID=Admin;Data Source=..\..\db.mdb")

            ' Create a data adapter to retrieve records from db
            Dim daUsers As New OleDbDataAdapter("SELECT ID, fn, ln, cty, st FROM tabUsers", dbConn)

            ' Define each column to map
            Dim dcmUserID As New DataColumnMapping("ID", "UserID")
            Dim dcmFirstName As New DataColumnMapping("fn", "FirstName")
            Dim dcmLastName As New DataColumnMapping("ln", "LastName")
            Dim dcmCity As New DataColumnMapping("cty", "City")
            Dim dcmState As New DataColumnMapping("st", "State")

            ' Define the table containing the mapped columns
            Dim dtmUsers As New DataTableMapping("Table", "User")
            dtmUsers.ColumnMappings.Add(dcmUserID)
            dtmUsers.ColumnMappings.Add(dcmFirstName)
            dtmUsers.ColumnMappings.Add(dcmLastName)
            dtmUsers.ColumnMappings.Add(dcmCity)
            dtmUsers.ColumnMappings.Add(dcmState)

            ' Activate the mapping mechanism
            daUsers.TableMappings.Add(dtmUsers)

            ' Fill the dataset
            daUsers.Fill(dsUsers)

            ' Set the primary key in order to use the Find() method
            ' below.
            Dim dcaKey() As DataColumn = {dsUsers.Tables(0).Columns("UserID")}
            dsUsers.Tables(0).PrimaryKey = dcaKey

            ' Declare a command builder to create SQL instructions
            ' to create and update records.
            Dim cb = New OleDbCommandBuilder(daUsers)

            ' Update an existing record in the DataSet
            Dim r As DataRow = dsUsers.Tables(0).Rows.Find(3)

            If Not r Is Nothing Then
                r("FirstName") = "Venus"
                r("LastName") = "Williams"
                r("City") = "Houston"
                r("State") = "Texas"

                ' Update the record even in the database
                daUsers.Update(dsUsers.GetChanges())

                ' Align in-memory data with the data source ones
                dsUsers.AcceptChanges()

                ' Print successfully message
                Console.WriteLine("The record has been updated successfully.")
            Else
                Console.WriteLine("No record found...")
            End If
        Catch ex As Exception
            ' Reject DataSet changes
            dsUsers.RejectChanges()

            ' An error occurred. Show the error message
            Console.WriteLine(ex.Message)
        End Try
    End Sub

End Module