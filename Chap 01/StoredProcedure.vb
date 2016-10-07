Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Dim WithEvents con As SqlConnection

    Sub Main()
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("constring"))
        Dim cmd As New SqlCommand("Ten Most Expensive Products", con)
        cmd.CommandType = CommandType.StoredProcedure

        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Console.WriteLine("{0} - {1:C}", _
                                  reader.GetString(0), reader.GetDecimal(1))
            End While
            reader.Close()
        Finally
            con.Close()
        End Try
    End Sub
End Module