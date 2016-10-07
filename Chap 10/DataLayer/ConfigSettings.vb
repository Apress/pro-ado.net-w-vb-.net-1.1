Imports System.Data.OracleClient
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc

Public Class ConfigSettings
    '
    ' Constructor
    '
    Public Sub New(ByVal Provider As DataProviderType, ByVal ConnString As String)
        mProvider = Provider
        mConnString = ConnString
    End Sub

    '
    ' Properties accessing the class members
    '
    ' Data provider
    Public Property Provider() As DataProviderType
        Get
            Return mProvider
        End Get
        Set(ByVal Value As DataProviderType)
            mProvider = Value
        End Set
    End Property

    ' Connection string to the backend database
    Public Property ConnectionString() As String
        Get
            Return mConnString
        End Get
        Set(ByVal Value As String)
            mConnString = Value
        End Set
    End Property

    '
    ' Internal class members
    '
    ' Data provider
    Private mProvider As DataProviderType

    ' Connection string to the backend database
    Private mConnString As String
End Class
