Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Dim WithEvents con As SqlConnection

    Sub Main()
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("constring"))
        Dim cmd As New SqlCommand( _
                  "SELECT * FROM Customers WHERE Country = @country", con)
        cmd.Parameters.Add( _
                  New SqlParameter("@country", SqlDbType.VarChar, 50)).Value = "USA"

        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Console.WriteLine("{0} - {1}", reader.GetString(0), reader.GetString(1))
            End While
            reader.Close()
        Finally
            con.Close()
        End Try
    End Sub
End Module