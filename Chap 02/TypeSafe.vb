Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("constring"))
        Dim cmd As New SqlCommand()

        cmd.CommandText = "SELECT * FROM Orders"
        cmd.Connection = con

        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            Dim OrderIDIdx As Integer = reader.GetOrdinal("OrderID")
            Dim OrderDateIdx As Integer = reader.GetOrdinal("OrderDate")
            Dim OrderFreightIdx As Integer = reader.GetOrdinal("Freight")

            Do
                While reader.Read()
                    Dim OrderID As Integer = reader.GetInt32(OrderIDIdx)
                    Dim OrderDate As DateTime = reader.GetDateTime(OrderDateIdx)
                    Dim OrderFreight As Decimal = reader.GetDecimal(OrderFreightIdx)

                    Console.WriteLine(OrderID & vbTab & OrderDate & vbTab & OrderFreight)
                End While
            Loop While reader.NextResult()

            reader.Close()
        Finally
            con.Close()
        End Try
    End Sub
End Module