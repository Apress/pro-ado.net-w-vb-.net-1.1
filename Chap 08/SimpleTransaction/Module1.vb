Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main(ByVal CmdArgs() As String)
        'Define variables
        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand
        Dim mytransaction As SqlTransaction
        Dim ConnectionString As String
        Dim stock As Integer
        Dim qty1, qty2, qty3 As Integer

        If CmdArgs.Length = 0 Then
            qty1 = 2
            qty2 = 4
            qty3 = 5
        Else
            qty1 = CmdArgs(0)
            qty2 = CmdArgs(1)
            qty3 = CmdArgs(2)
        End If

        'open a database connection
        ConnectionString = "User ID=sa;Initial Catalog=Northwind;" & _
                           "Data Source=(local)"
        myconnection = New SqlConnection(ConnectionString)
        myconnection.Open()

        'start a transaction
        mytransaction = myconnection.BeginTransaction()

        'configure command object to use transaction
        mycommand = New SqlCommand
        mycommand.Connection = myconnection
        mycommand.Transaction = mytransaction

        'execute various sql statements
        Try
            'insert into orders table
            mycommand.CommandText = "insert into orders(customerid," & _
                      "orderdate,requireddate) values('ALFKI', " & _
                      "GetDate(),DATEADD(d,15,GetDate()))"
            mycommand.ExecuteNonQuery()

            'store identity value for further queries
            mycommand.CommandText = "select @@identity from orders"
            Dim id As String = mycommand.ExecuteScalar().ToString()

            'insert product details
            mycommand.CommandText = "insert into [order details]" & _
                      "(orderid,productid,unitprice,quantity)" & _
                      " values(" & id & ",1,18," & qty1 & ")"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into [order details]" & _
                      "(orderid,productid,unitprice,quantity)" & _
                      "values(" & id & ",2,19," & qty2 & ")"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into [order details]" & _
                      "(orderid,productid,unitprice,quantity)" & _
                      "values(" & id & ",3,10," & qty3 & ")"
            mycommand.ExecuteNonQuery()

            'rollback if ordered quantity exceeds stock quantity
            mycommand.CommandText = "select unitsinstock from products " & _
                                    "where productid=1"
            stock = Integer.Parse(mycommand.ExecuteScalar().ToString())
            If stock < qty1 Then
                mytransaction.Rollback()
                Console.WriteLine("Quantity for Product ID 1 exceeds" & _
                                  "available stock")
                Console.ReadLine()
                Return
            End If
            mycommand.CommandText = "select unitsinstock from products " & _
                                    "where productid=2"
            stock = Integer.Parse(mycommand.ExecuteScalar().ToString())
            If stock < qty2 Then
                mytransaction.Rollback()
                Console.WriteLine("Quantity for Product ID 2 exceeds" & _
                                  "available stock")
                Console.ReadLine()
                Return
            End If
            mycommand.CommandText = "select unitsinstock from products " & _
                                    "where productid=3"
            stock = Integer.Parse(mycommand.ExecuteScalar().ToString())
            If stock < qty3 Then
                mytransaction.Rollback()
                Console.WriteLine("Quantity for Product ID 3 exceeds" & _
                                  "available stock")
                Console.ReadLine()
                Return
            End If
            mytransaction.Commit()
            Console.WriteLine("Your order has been successfully placed!")
            Console.WriteLine("Order ID :" & id)
            Console.ReadLine()
        Catch e As Exception
            Console.WriteLine(e.Message)
            Console.ReadLine()
        Finally
            myconnection.Close()
        End Try

    End Sub

End Module