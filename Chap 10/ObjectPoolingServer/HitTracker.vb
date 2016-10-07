Imports System.Data.SqlClient
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices

<ObjectPooling(MinPoolSize:=1, MaxPoolSize:=5, CreationTimeout:=90000), _
 JustInTimeActivation(True), ClassInterface(ClassInterfaceType.AutoDual)> _
Public Class HitTracker
    Inherits ServicedComponent

    Protected Overrides Function CanBePooled() As Boolean
        Return True
    End Function

    <AutoComplete()> _
    Public Sub AddUnique()
        mCommand = New SqlCommand("HitsUnique", mConnection)
        mCommand.CommandType = CommandType.StoredProcedure
        mCommand.Parameters.Add("@TodaysDate", mHitDateTime)

        mConnection.Open()
        mCommand.ExecuteNonQuery()
        mConnection.Close()
    End Sub

    <AutoComplete()> _
    Public Sub AddPageView()
        mCommand = New SqlCommand("HitsTotal", mConnection)
        mCommand.CommandType = CommandType.StoredProcedure
        mCommand.Parameters.Add("@TodaysDate", mHitDateTime)

        mConnection.Open()
        mCommand.ExecuteNonQuery()
        mConnection.Close()
    End Sub

    Private Const mcSqlConnString As String = _
        "Data Source=(local);User ID=sa;Password=;Initial Catalog=LocalHits"
    Private mConnection As SqlConnection = New SqlConnection(mcSqlConnString)
    Private mCommand As SqlCommand
    Private mHitDateTime As DateTime = DateTime.Today
End Class
