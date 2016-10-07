Module OpenXMLDemo
    Sub DemoOpenXML()
        Const strConnection As String = _
            "Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind"
        Const strXMLDoc As String = _
            "<Top>" & _
                "<Region RegionID=""11"" RegionDescription=""UpTown""/>" & _
                "<Region RegionID=""22"" RegionDescription=""DownTown""/>" & _
            "</Top>"

        Dim sqlConnection As SqlConnection = New SqlConnection(strConnection)
        Dim openXMLCommand As SqlCommand = New SqlCommand("RegionInsert", sqlConnection)
        openXMLCommand.CommandType = CommandType.StoredProcedure

        Dim xmlDocParm As SqlParameter = _
            openXMLCommand.Parameters.Add("@xmlDoc", SqlDbType.NVarChar, 4000)
        xmlDocParm.Value = strXMLDoc

        sqlConnection.Open()

        openXMLCommand.ExecuteNonQuery()

        openXMLCommand.CommandText = "RegionUpdate"
        xmlDocParm.Value = strXMLDoc.Replace("Town", "City")
        openXMLCommand.ExecuteNonQuery()

        openXMLCommand.CommandText = "RegionDelete"
        openXMLCommand.ExecuteNonQuery()

        sqlConnection.Close()
    End Sub

    Sub Main()
        DemoOpenXML()
    End Sub
End Module
