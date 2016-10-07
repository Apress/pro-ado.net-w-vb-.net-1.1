Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand
        Dim mytransaction As SqlTransaction
        Dim myreader As SqlDataReader

        'open a database connection
        myconnection = New SqlConnection("User ID=sa;Initial Catalog=Northwind;Data Source=(local)")
        myconnection.Open()

        'start a transaction
        mytransaction = myconnection.BeginTransaction()

        'configure command object to use transaction
        mycommand = New SqlCommand()
        mycommand.Connection = myconnection
        mycommand.Transaction = mytransaction

        'execute various sql statements
        Try
            'insert into orders table
            mycommand.CommandText = "insert into orders default values"
            mycommand.ExecuteNonQuery()
            mytransaction.Save("firstorder")
            mycommand.CommandText = "insert into orders default values"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into orders default values"
            mycommand.ExecuteNonQuery()
            mytransaction.Rollback("firstorder")

            mycommand.CommandText = "insert into orders default values"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into orders default values"
            mycommand.ExecuteNonQuery()
            mytransaction.Commit()

            mycommand.CommandText = "select top 3 orderid from orders order by orderid desc"
            myreader = mycommand.ExecuteReader()
            Console.WriteLine("Last 3 Orders")
            While myreader.Read()
                Console.WriteLine(myreader.GetInt32(0))
            End While
        Catch e As Exception
            Console.WriteLine(e.Message)
            Console.ReadLine()
        Finally
            myconnection.Close()
        End Try
    End Sub
End Module
