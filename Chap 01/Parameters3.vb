Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Dim WithEvents con As SqlConnection

    Sub Main()
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("constring"))
        Dim cmd As New SqlCommand("GetCountryAndOutputParam", con)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.Add( _
            New SqlParameter("@country", SqlDbType.VarChar, 50)).Value = "USA"
        cmd.Parameters.Add(New SqlParameter("@count", SqlDbType.Int))
        cmd.Parameters("@count").Direction = ParameterDirection.Output

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

        Console.WriteLine("{0} - {1}", _
                          "Count", cmd.Parameters("@count").Value.ToString())
    End Sub
End Module