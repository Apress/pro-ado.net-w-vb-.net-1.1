Public Class Client_SQL
    Inherits System.Web.UI.Page
    Protected WithEvents ddlDataSource As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlFunction As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents grdProducts As System.Web.UI.WebControls.DataGrid

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
        CreateDalObjects()

        Select Case UCase(ddlFunction.SelectedItem.Value)
            Case "SELECT"
                ShowProducts()

            Case "INSERT"
                InsertProduct()

            Case "EDIT"
                UpdateProduct()

            Case "DELETE"
                DeleteProduct()

            Case Else
                ShowProducts()
        End Select
    End Sub

    ' Display all product records
    Private Sub ShowProducts()
        Dim ds As DataSet = mDalCommands.ExecuteQuery( _
                    mDalConfig, DataLayer.ReturnType.DataSetType, mcSqlSelect)
        grdProducts.DataSource = ds
        grdProducts.DataBind()
        lblMessage.Text = ""
    End Sub

    ' Insert an arbitrary test product record
    Private Sub InsertProduct()
        mDalCommands.ExecuteNonQuery(mDalConfig, mcSqlInsert)
        ShowProducts()
        lblMessage.Text = "Record inserted"
    End Sub

    ' Edit the test product record created in InsertProduct
    Private Sub UpdateProduct()
        mDalCommands.ExecuteNonQuery(mDalConfig, mcSqlUpdate)
        ShowProducts()
        lblMessage.Text = "Record updated"
    End Sub

    ' Delete the modified test product record
    Private Sub DeleteProduct()
        mDalCommands.ExecuteNonQuery(mDalConfig, mcSqlDelete)
        ShowProducts()
        lblMessage.Text = "Record deleted"
    End Sub

    ' Create data layer configuration settings and commands objects 
    ' based on the selected data provider
    Private Sub CreateDalObjects()
        Select Case UCase(ddlDataSource.SelectedItem.Value)
            Case "ODBC"
                mDalConfig = New DataLayer.ConfigSettings( _
                    DataLayer.DataProviderType.Odbc, mcOdbcConnString)
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
    End Sub

    ' SQL Statements for testing
    Private Const mcTestProductOldName As String = "Macks Fried Chicken"
    Private Const mcTestProductNewName As String = "Macks Spicy Fried Chicken"
    Private Const mcSqlSelect As String = _
        "SELECT * FROM Products ORDER BY ProductID DESC"
    Private Const mcSqlInsert As String = _
        "INSERT INTO Products (ProductName) VALUES ('" & mcTestProductOldName & "')"
    Private Const mcSqlUpdate As String = _
        "UPDATE Products SET ProductName = '" & mcTestProductNewName & _
        "' WHERE ProductName = '" & mcTestProductOldName & "'"
    Private Const mcSqlDelete As String = _
        "DELETE FROM Products WHERE ProductName = '" & mcTestProductNewName & "'"

    ' Connection strings
    Private Const mcSqlConnString As String = _
        "Data Source=(local);User ID=sa;Password=;Initial Catalog=Northwind"
    Private Const mcOdbcConnString As String = "DSN=NorthWind;UID=sa"
    Private Const mcOleDbConnString As String = _
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Northwind.Mdb"
    Private Const mcOracleConnString As String = _
         "Data Source=Oracle8i;Integrated Security=SSPI"

    ' Data Layer configuration settings object
    Private mDalConfig As DataLayer.ConfigSettings
    Private mDalCommands As DataLayer.Commands
End Class
