Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Dim WithEvents con As SqlConnection

    Sub Main()
        con = New SqlConnection(ConfigurationSettings.AppSettings("constring"))

        Dim cmd As New SqlCommand()
        cmd.CommandText = "SELECT TOP 5 * FROM Customers"
        cmd.Connection = con

        Try
            con.Open()

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Console.WriteLine( _
                       "{0} - {1}", reader.GetString(0), reader.GetString(1))
            End While
            reader.Close()
        Finally
            con.Close()
        End Try
    End Sub

    Sub con_StateChange(ByVal Sender As Object, _
                 ByVal E As StateChangeEventArgs) Handles con.StateChange
        Console.WriteLine( _
                   "{0} - {1}", "ConnectionState", E.CurrentState.ToString())
    End Sub
End Module
