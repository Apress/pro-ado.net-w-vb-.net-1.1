Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Module Module1
    Dim WithEvents con As SqlConnection

    Sub Main()
        Dim con As New SqlConnection(ConfigurationSettings.AppSettings("constring"))
        Dim cmd As New SqlCommand()

        cmd.CommandText = "SELECT * FROM Customers FOR XML AUTO, XMLDATA"
        cmd.Connection = con

        Try
            con.Open()
            Dim reader As XmlReader = cmd.ExecuteXmlReader()
            While reader.Read()
                Console.WriteLine(reader.ReadOuterXml())
            End While
            reader.Close()
        Finally
            con.Close()
        End Try
    End Sub
End Module