Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Dim WithEvents con As SqlConnection

    Sub Main()
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("constring"))
        Dim cmd As New SqlCommand()

        cmd.CommandText = "DELETE FROM Employees WHERE FirstName = 'Derek'"
        cmd.Connection = con

        Try
            con.Open()
            Console.WriteLine("{0} - {1}", _
                            "cmd.ExecuteNonQuery()", cmd.ExecuteNonQuery().ToString())
        Finally
            con.Close()
        End Try
    End Sub
End Module