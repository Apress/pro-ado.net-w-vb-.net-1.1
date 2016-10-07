Public Class Client_StoredProc
    Inherits System.Web.UI.Page
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents grdProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlDataSource As System.Web.UI.WebControls.DropDownList

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RunStoredProc()
    End Sub

    Private Sub RunStoredProc()
        Dim StoredProcName As String = mcStoredProc

        Select Case UCase(ddlDataSource.SelectedItem.Value)
            Case "ODBC"
                mDalConfig = New DataLayer.ConfigSettings( _
                    DataLayer.DataProviderType.Odbc, mcOdbcConnString)
                StoredProcName = "{call [Sales by Year](?, ?)}"

            Case "OLEDB"
                mDalConfig = New DataLayer.ConfigSettings( _
                    DataLayer.DataProviderType.OleDb, mcOleDbConnString)

            Case "SQL"
                mDalConfig = New DataLayer.ConfigSettings( _
                    DataLayer.DataProviderType.Sql, mcSqlConnString)

            Case "ORACLE"
                mDalConfig = New DataLayer.ConfigSettings( _
                    DataLayer.DataProviderType.Oracle, mcOracleConnString)

            Case Else
                mDalConfig = New DataLayer.ConfigSettings( _
                    DataLayer.DataProviderType.Sql, mcSqlConnString)
        End Select

        mDalCommands = New DataLayer.Commands()
        Dim ds As DataSet = mDalCommands.ExecuteQuery( _
                    mDalConfig, DataLayer.ReturnType.DataSetType, _
                    StoredProcName, CommandType.StoredProcedure, _
                    New DataLayer.Pair(mcStartDateParamName, mStartDateParamValue), _
                    New DataLayer.Pair(mcEndDateParamName, mEndDateParamValue))

        grdProducts.DataSource = ds
        grdProducts.DataBind()
    End Sub

    ' Stored procedure name and parameter values
    Private Const mcStoredProc As String = "[Sales by Year]"
    Private Const mcStartDateParamName As String = "@Beginning_Date"
    Private mStartDateParamValue As DateTime = New DateTime(1996, 7, 1)
    Private Const mcEndDateParamName As String = "@Ending_Date"
    Private mEndDateParamValue As DateTime = New DateTime(1996, 8, 1)

    ' Connection strings
    Private Const mcOdbcConnString As String = "DSN=NorthWind;UID=sa"
    Private Const mcOleDbConnString As String = _
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Northwind.Mdb"
    Private Const mcSqlConnString As String = _
        "Data Source=(local);User ID=sa;Password=;Initial Catalog=Northwind"
    Private Const mcOracleConnString As String = _
         "Data Source=Oracle8i;Integrated Security=SSPI"

    ' Data Layer configuration settings object
    Private mDalConfig As DataLayer.ConfigSettings
    Private mDalCommands As DataLayer.Commands
End Class
