Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Dim WithEvents con As SqlConnection

    Sub Main()
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("constring"))
        Dim cmd As New SqlCommand()

        cmd.CommandText = "SELECT COUNT(*) FROM Customers"
        cmd.Connection = con

        Try
            con.Open()
            Console.WriteLine("{0} - {1}", _
                            "cmd.ExecuteScalar()", cmd.ExecuteScalar().ToString())
        Finally
            con.Close()
        End Try
    End Sub
End Module