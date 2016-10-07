Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Dim WithEvents con As SqlConnection

    Sub Main()
        con = New SqlConnection( _
                 ConfigurationSettings.AppSettings("constring"))

        Dim cmd As New SqlCommand()
        cmd.CommandText = "PRINT('This raises an InfoMessage event')"
        cmd.Connection = con

        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Finally
            con.Close()
        End Try
    End Sub

    Sub con_InfoMessage(ByVal Sender As Object, _
                 ByVal E As SqlInfoMessageEventArgs) Handles con.InfoMessage
        Console.WriteLine( _
                   "{0} - {1}", "InfoMessage", E.Errors.Item(0).ToString())
    End Sub
End Module