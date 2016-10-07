Module ForXMLDemo
    Sub ShowOffForXMLRaw()
        Try
            Dim strQuery As String = _
                    "SELECT FirstName, LastName FROM Employees " & _
                    "ORDER BY LastName, FirstName FOR XML RAW, XMLDATA"
            Dim strConnection As String = _
                "Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind"
            Dim sqlConnection As SqlConnection = New SqlConnection(strConnection)
            Dim forXMLCommand As SqlCommand = New SqlCommand(strQuery, sqlConnection)

            sqlConnection.Open()

            Dim ds As DataSet = New DataSet
            ds.ReadXml(forXMLCommand.ExecuteXmlReader(), XmlReadMode.Fragment)
            ds.WriteXml("DemoOutRaw.xml")
        Catch ex As Exception
            Console.Error.WriteLine(ex)
        End Try
    End Sub

    Sub ShowOffForXMLAuto()
        Try
            Dim strConnection As String = _
                "Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind"
            Dim sqlConnection As SqlConnection = New SqlConnection(strConnection)
            sqlConnection.Open()

            Dim forXMLCommand As SqlCommand = New SqlCommand("RegionTerritory")
            forXMLCommand.CommandType = CommandType.StoredProcedure
            forXMLCommand.Connection = sqlConnection

            Dim ds As DataSet = New DataSet
            ds.ReadXml(forXMLCommand.ExecuteXmlReader(), XmlReadMode.Fragment)
            ds.WriteXml("DemoOutAuto.xml", XmlWriteMode.IgnoreSchema)
        Catch ex As Exception
            Console.Error.WriteLine(ex)
        End Try
    End Sub

    Dim strConnectionForDBWhereFamilyResides As String = _
        "Data Source=(local);Integrated Security=SSPI;Initial Catalog=FamilyDB"

    Dim strForXMLExplicit As String = _
        "SELECT 1 AS Tag, 0 AS Parent, GrandParentID AS [GParent!1!], " & _
                "GrandParentName AS [GParent!1!OrderByGrandParentName!hide], " & _
                "RTRIM(GrandParentName) AS [GParent!1!GParentName], " & _
                "Diary AS [GParent!1!!xmltext], " & _
                "0 AS [Son!2!SonID], " & _
                "'' AS [Son!2!OrderBySonName!hide], " & _
                "'' AS [Son!2!SonName], " & _
                "'' AS [Son!2!!CDATA], " & _
                "0 AS [Daughter!3!DaughterID!element], " & _
                "'' AS [Daughter!3!OrderByDaughterName!hide], " & _
                "'' AS [Daughter!3!DaughterName!element], " & _
                "'' AS [Daughter!3!SomeData!element], " & _
                "0 AS [GrandKid!4!ChildOfSonID!element], " & _
                "'' AS [GrandKid!4!OrderByChildOfSonName!hide], " & _
                "'' AS [GrandKid!4!ChildOfSonName!element], " & _
                "'' AS [GrandKid!4!GrandKidData!xml] " & _
       "FROM GrandParent " & _
       "UNION ALL " & _
       "SELECT 2 AS Tag, 1 AS Parent, 0,  " & _
               "G.GrandParentName AS [GParent!1!OrderByGrandParentName!hide]," & _
               "''," & _
               "''," & _
               "SonID," & _
               "RTRIM(SonName)," & _
               "RTRIM(SonName)," & _
               "PermanentRecord," & _
               "0," & _
               "''," & _
               "''," & _
               "''," & _
               "0," & _
               "''," & _
               "''," & _
               "'' " & _
       "FROM GrandParent AS G, Son AS S " & _
       "WHERE G.GrandParentID=S.GrandParentID " & _
       "UNION ALL " & _
       " SELECT 3 AS Tag, 1 AS Parent, 0, " & _
                "G.GrandParentName AS [GParent!1!OrderByGrandParentName!hide]," & _
                "''," & _
                "''," & _
                "0," & _
                "''," & _
                "''," & _
                "''," & _
                "DaughterID," & _
                "RTRIM(DaughterName)," & _
                "RTRIM(DaughterName)," & _
                "SomeData," & _
                "0," & _
                "''," & _
                "''," & _
                "'' " & _
        "FROM GrandParent AS G, Daughter AS D " & _
        "WHERE G.GrandParentID=D.GrandParentID " & _
        "UNION ALL " & _
        "SELECT 4 AS Tag, 2 AS Parent, 0, " & _
                "G.GrandParentName AS [GParent!1!OrderByGrandParentName!hide]," & _
                "''," & _
                "''," & _
                "0," & _
                "RTRIM(S.SonName)," & _
                "''," & _
                "''," & _
                "0," & _
                "''," & _
                "''," & _
                "''," & _
                "CS.ChildOfSonID," & _
                "RTRIM(CS.ChildOfSonName)," & _
                "RTRIM(CS.ChildOfSonName)," & _
                "CS.GrandKidData " & _
        "FROM GrandParent AS G, Son AS S, ChildOfSon AS CS " & _
        "WHERE G.GrandParentID=S.GrandParentID AND S.SonID=CS.SonID " & _
        "ORDER BY [GParent!1!OrderByGrandParentName!hide], " & _
                "[Son!2!OrderBySonName!hide], " & _
                "[Daughter!3!OrderByDaughterName!hide], " & _
                "[GrandKid!4!OrderByChildOfSonName!hide] " & _
        "FOR XML EXPLICIT"

    Sub ShowOffForXMLExplicitInSourceSQL(ByVal connection As SqlConnection)
        Dim forXMLCommand As SqlCommand = _
            New SqlCommand(strForXMLExplicit, connection)
        Dim reader As XmlReader = forXMLCommand.ExecuteXmlReader()
        Dim ds As DataSet = New DataSet

        ds.ReadXml(reader, XmlReadMode.Fragment)
        reader.Close()
    End Sub

    Dim strForXMLExplicitStoredProc As String = "ForXMLExplicitDemo"

    Sub ShowOffForXMLExplicitInStoredProc(ByVal connection As SqlConnection)
        Dim forXMLCommand As SqlCommand = _
                New SqlCommand(strForXMLExplicitStoredProc, connection)
        forXMLCommand.CommandType = CommandType.StoredProcedure

        Dim reader As XmlReader = forXMLCommand.ExecuteXmlReader()
        Dim ds As DataSet = New DataSet

        ds.ReadXml(reader, XmlReadMode.Fragment)
        reader.Close()
    End Sub

    Sub CompareExplicit()
        Dim connection As SqlConnection = Nothing
        Dim dateTimeStart As DateTime
        Dim timeSpanSQLInSource As TimeSpan
        Dim timeSpanStoredProc As TimeSpan
        Dim innerCount As Integer
        Dim outerCount As Integer
        Dim maxInnerCount As Integer = 1000

        Try
            connection = New SqlConnection(strConnectionForDBWhereFamilyResides)
            connection.Open()
            For outerCount = 1 To 5
                dateTimeStart = DateTime.Now
                For innerCount = 1 To maxInnerCount
                    ShowOffForXMLExplicitInSourceSQL(connection)
                Next innerCount
                timeSpanSQLInSource = DateTime.Now.Subtract(dateTimeStart)

                dateTimeStart = DateTime.Now
                For innerCount = 1 To maxInnerCount
                    ShowOffForXMLExplicitInStoredProc(connection)
                Next innerCount
                timeSpanStoredProc = DateTime.Now.Subtract(dateTimeStart)

                Console.WriteLine("{0} -- SQL in source: {1}, Stored Proc: {2}", _
                                    outerCount, timeSpanSQLInSource, timeSpanStoredProc)
            Next outerCount
        Catch ex As Exception
            Console.Error.WriteLine(ex)
        Finally
            If Not (connection Is Nothing) Then
                connection.Close()
                connection = Nothing
            End If
        End Try
    End Sub

    Sub Main()
        ' CompareExplicit()
        ' ShowOffForXMLRaw()
        ShowOffForXMLAuto()
        Console.WriteLine("Hit enter to continue ..")
        Console.ReadLine()
    End Sub
End Module
