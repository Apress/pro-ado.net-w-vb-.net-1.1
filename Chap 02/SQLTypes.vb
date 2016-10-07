Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Module Module1
    Sub Main()
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("constring"))
        Dim cmd As New SqlCommand()

        cmd.CommandText = "SELECT OrderID, OrderDate, Freight FROM Orders"
        cmd.Connection = con

        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            Dim OrderIDIdx As Integer = reader.GetOrdinal("OrderID")
            Dim OrderDateIdx As Integer = reader.GetOrdinal("OrderDate")
            Dim OrderFreightIdx As Integer = reader.GetOrdinal("Freight")

            While reader.Read()
                Dim OrderID As SqlInt32 = reader.GetSqlInt32(OrderIDIdx)
                Dim OrderDate As SqlDateTime = reader.GetSqlDateTime(OrderDateIdx)
                Dim OrderFreight As SqlMoney = reader.GetSqlMoney(OrderFreightIdx)

                Console.WriteLine(OrderID.ToString() & vbTab & _
                                OrderDate.ToString() & vbTab & OrderFreight.ToString())
            End While
            reader.Close()
        Finally
            con.Close()
        End Try
    End Sub
End Module