Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("constring"))
        Dim cmd As New SqlCommand()

        cmd.CommandText = "SELECT * FROM Categories; SELECT * FROM Customers"
        cmd.Connection = con

        Try
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            Do
                While reader.Read()
                    Console.WriteLine(reader(0) & vbTab & reader(1))
                End While
            Loop While reader.NextResult()

            reader.Close()
        Finally
            con.Close()
        End Try
    End Sub
End Module