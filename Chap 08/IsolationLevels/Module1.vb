Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Dim myconnection1, myconnection2 As SqlConnection
        Dim mycommand1, mycommand2 As SqlCommand
        Dim mytransaction1, mytransaction2 As SqlTransaction
        Dim myreader As SqlDataReader
        Dim ConnectionString As String

        'open a database connection
        ConnectionString = "User ID=sa;Initial Catalog=Northwind;Data Source=(local)"
        myconnection1 = New SqlConnection(ConnectionString)
        myconnection2 = New SqlConnection(ConnectionString)

        Try
            myconnection1.Open()
            myconnection2.Open()

            'start a transaction
            mytransaction1 = myconnection1.BeginTransaction()
            mytransaction2 = myconnection2.BeginTransaction(IsolationLevel.ReadUncommitted)

            'configure command object to use transaction
            mycommand1 = New SqlCommand()
            mycommand1.Connection = myconnection1
            mycommand1.Transaction = mytransaction1

            mycommand2 = New SqlCommand()
            mycommand2.Connection = myconnection2
            mycommand2.Transaction = mytransaction2

            'execute various sql statements

            mycommand1.CommandText = "insert into orders default values"
            mycommand1.ExecuteNonQuery()
            mycommand1.CommandText = "insert into orders default values"
            mycommand1.ExecuteNonQuery()

            mycommand2.CommandText = "select top 2 orderid from orders order by orderid desc"
            myreader = mycommand2.ExecuteReader()
            Console.WriteLine("Last 2 Orders - Transaction is pending")
            Console.WriteLine("======================================")
            While myreader.Read()

                Console.WriteLine(myreader.GetInt32(0))
            End While
            myreader.Close()
            Console.ReadLine()

            mytransaction1.Rollback()
            mycommand2.CommandText = "select top 2 orderid from orders order by orderid desc"
            myreader = mycommand2.ExecuteReader()

            Console.WriteLine("Last 2 Orders - Transaction rolled back")
            Console.WriteLine("=======================================")
            While myreader.Read()
                Console.WriteLine(myreader.GetInt32(0))
            End While
            Console.ReadLine()
        Catch e As Exception
            Console.WriteLine(e.Message)
            Console.ReadLine()
        Finally
            myconnection1.Close()
            myconnection2.Close()
        End Try
    End Sub
End Module


