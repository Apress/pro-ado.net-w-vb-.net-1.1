Imports System.Data.OracleClient
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Xml

Public Class Commands
    '
    ' Execute an SQL statement that will return a result
    ' This function has several overloaded versions
    '
    ' Accepts a dynamic SQL statement
    Public Function ExecuteQuery(ByVal Config As ConfigSettings, _
                                 ByVal ResultType As ReturnType, ByVal CommandText As String) As Object
        CreateCommand(Config, CommandText, CommandType.Text)
        Return ExecuteQuery(Config, ResultType)
    End Function

    ' Accepts a stored procedure with parameter name/value pairs
    Public Function ExecuteQuery(ByVal config As ConfigSettings, _
                                 ByVal ResultType As ReturnType, ByVal CommandText As String, _
                                 ByVal CommandType As CommandType, ByVal ParamArray Params() As Pair) As Object
        CreateCommand(config, CommandText, CommandType, Params)
        Return ExecuteQuery(config, ResultType)
    End Function

    ' This function is the one that performs the real work
    Private Function ExecuteQuery(ByVal Config As ConfigSettings, ByVal ResultType As ReturnType) As Object
        Connect(Config)
        mCommand.Connection = mConnection

        If ResultType = ReturnType.DataReaderType Then
            Return mCommand.ExecuteReader(CommandBehavior.CloseConnection)
        End If

        Dim Adapter As IDataAdapter = CreateAdapter(Config)
        Dim ds As DataSet = New DataSet()
        Adapter.Fill(ds)
        mConnection.Close()

        If ResultType = ReturnType.DataSetType Then
            Return ds
        Else
            Return New XmlDataDocument(ds)
        End If
    End Function

    '
    ' Execute an SQL statement that will not return a result
    ' This function has several overloaded versions
    '
    ' Accepts a dynamic SQL statement
    Public Sub ExecuteNonQuery(ByVal config As ConfigSettings, ByVal CommandText As String)
        CreateCommand(config, CommandText, CommandType.Text)
        ExecuteNonQuery(config)
    End Sub

    ' Accepts a stored procedure with parameter name/value pairs
    Public Sub ExecuteNonQuery(ByVal config As ConfigSettings, ByVal CommandText As String, _
                               ByVal CommandType As CommandType, ByVal ParamArray Params() As Pair)
        CreateCommand(config, CommandText, CommandType, Params)
        ExecuteNonQuery(config)
    End Sub

    ' This function is the one that performs the real work
    Private Sub ExecuteNonQuery(ByVal config As ConfigSettings)
        Connect(config)
        mCommand.Connection = mConnection
        mCommand.ExecuteNonQuery()
        mConnection.Close()
    End Sub

    ' Create and open a provider specific connection
    Private Sub Connect(ByVal Config As ConfigSettings)
        Select Case Config.Provider
            Case DataProviderType.Odbc
                mConnection = New OdbcConnection(Config.ConnectionString)

            Case DataProviderType.OleDb
                mConnection = New OleDbConnection(Config.ConnectionString)

            Case DataProviderType.Sql
                mConnection = New SqlConnection(Config.ConnectionString)

            Case DataProviderType.Oracle
                mConnection = New OracleConnection(Config.ConnectionString)
        End Select

        mConnection.Open()
    End Sub

    ' Create a provider specific command object with a SQL Statement
    Private Sub CreateCommand(ByVal Config As ConfigSettings, _
                              ByVal CommandText As String, _
                              ByVal CommandType As System.Data.CommandType, _
                              ByVal ParamArray Params() As Pair)
        Dim Param As Pair

        Select Case Config.Provider
            Case DataProviderType.Odbc
                mCommand = New OdbcCommand(CommandText)

                Dim OdbcParam As OdbcParameter
                For Each Param In Params
                    OdbcParam = New OdbcParameter(Param.First.ToString(), Param.Second)
                    mCommand.Parameters.Add(OdbcParam)
                Next

            Case DataProviderType.OleDb
                mCommand = New OleDbCommand(CommandText)

                Dim OleDbParam As OleDbParameter
                For Each Param In Params
                    OleDbParam = New OleDbParameter(Param.First.ToString(), Param.Second)
                    mCommand.Parameters.Add(OleDbParam)
                Next

            Case DataProviderType.Sql
                mCommand = New SqlCommand(CommandText)

                Dim SqlParam As SqlParameter
                For Each Param In Params
                    SqlParam = New SqlParameter(Param.First.ToString(), Param.Second)
                    mCommand.Parameters.Add(SqlParam)
                Next

            Case DataProviderType.Oracle
                mCommand = New OracleCommand(CommandText)

                Dim OracleParam As OracleParameter
                For Each Param In Params
                    OracleParam = New OracleParameter(Param.First.ToString(), Param.Second)
                    mCommand.Parameters.Add(OracleParam)
                Next
        End Select

        mCommand.CommandType = CommandType
    End Sub

    ' Create a provider specific data adapter object
    Private Function CreateAdapter(ByVal Config As ConfigSettings) As IDataAdapter
        Select Case Config.Provider
            Case DataProviderType.Odbc
                Return New OdbcDataAdapter(mCommand)

            Case DataProviderType.OleDb
                Return New OleDbDataAdapter(mCommand)

            Case DataProviderType.Sql
                Return New SqlDataAdapter(mCommand)

            Case DataProviderType.Oracle
                Return New OracleDataAdapter(mCommand)
        End Select
    End Function

    '
    ' Internal class members
    '
    ' Generic connection 
    ' - must be instantiated to a data provider specific connection
    Private mConnection As IDbConnection

    ' Command object to access the backend database
    Private mCommand As IDbCommand

End Class
