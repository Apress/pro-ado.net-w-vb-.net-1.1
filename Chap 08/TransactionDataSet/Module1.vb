Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim ConnectionString As String
        Dim myconnection As SqlConnection
        Dim mytransaction As SqlTransaction
        Dim mycommand1 As SqlCommand
        Dim myparam As SqlParameter
        Dim da As SqlDataAdapter
        Dim ds As New DataSet()
        Dim args() As String = Environment.GetCommandLineArgs

        ConnectionString = "User ID=sa;Initial Catalog=Northwind;Data Source=(local)"
        myconnection = New SqlConnection(ConnectionString)
        myconnection.Open()

        da = New SqlDataAdapter("select * from [order details] where orderid=10365", myconnection)
        da.Fill(ds, "orderdetails")
        myconnection.Close()

        ds.Tables(0).Rows(0)("Quantity") = 11
        'ds.Tables(0).Rows(1)("Quantity") = 11
        'ds.Tables(0).Rows(2)("Quantity") = 2

        mycommand1 = New SqlCommand("update [order details] set quantity=@qty " & "where orderid=@ordid and productid=@prdid", myconnection)
        myparam = New SqlParameter("@qty", SqlDbType.SmallInt)
        myparam.SourceColumn = "Quantity"
        myparam.SourceVersion = DataRowVersion.Current
        mycommand1.Parameters.Add(myparam)

        myparam = New SqlParameter("@ordid", SqlDbType.Int)
        myparam.SourceColumn = "OrderID"
        myparam.SourceVersion = DataRowVersion.Current
        mycommand1.Parameters.Add(myparam)

        myparam = New SqlParameter("@prdid", SqlDbType.Int)
        myparam.SourceColumn = "ProductID"
        myparam.SourceVersion = DataRowVersion.Current
        mycommand1.Parameters.Add(myparam)

        myconnection.Open()
        mytransaction = myconnection.BeginTransaction()
        mycommand1.Transaction = mytransaction
        da.UpdateCommand = mycommand1
        Try
            da.Update(ds, "orderdetails")
            mytransaction.Commit()
            Console.WriteLine("Order modified successfully !")
            Console.ReadLine()
        Catch e As Exception
            mytransaction.Rollback()
            Console.WriteLine(e.Message)
            Console.ReadLine()
        Finally
            myconnection.Close()
        End Try
    End Sub
End Module
