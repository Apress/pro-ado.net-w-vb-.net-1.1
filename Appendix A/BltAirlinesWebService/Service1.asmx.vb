Imports System.Web.Services

<WebService(Namespace := "http://tempuri.org/")> _
Public Class Service1
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents dbConn As System.Data.SqlClient.SqlConnection
    Friend WithEvents da As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents sqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents ds As BltAirlinesWebServiceVB.dsWebService
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dbConn = New System.Data.SqlClient.SqlConnection()
        Me.da = New System.Data.SqlClient.SqlDataAdapter()
        Me.sqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.ds = New BltAirlinesWebServiceVB.dsWebService()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "data source=.;initial catalog=BltAirlinesDB;persist security info=False;user id=s" & _
        "a;workstation id=BLTSERVER;packet size=4096"
        '
        'da
        '
        Me.da.SelectCommand = Me.sqlSelectCommand1
        Me.da.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tabFlights", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("FlightCode", "FlightCode"), New System.Data.Common.DataColumnMapping("LeavingFrom", "LeavingFrom"), New System.Data.Common.DataColumnMapping("GoingTo", "GoingTo"), New System.Data.Common.DataColumnMapping("Depart", "Depart"), New System.Data.Common.DataColumnMapping("Arrive", "Arrive")})})
        '
        'sqlSelectCommand1
        '
        Me.sqlSelectCommand1.CommandText = "spSelectFlights"
        Me.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure
        Me.sqlSelectCommand1.Connection = Me.dbConn
        Me.sqlSelectCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '
        'ds
        '
        Me.ds.DataSetName = "dsWebService"
        Me.ds.Locale = New System.Globalization.CultureInfo("en-US")
        Me.ds.Namespace = "http://tempuri.org/dsWebService.xsd"
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    '<WebMethod()> Public Function HelloWorld() As String
    '	HelloWorld = "Hello World"
    ' End Function

    <WebMethod()> Public Function RetrieveFlights() As dsWebService
        da.Fill(ds)
        Return ds
    End Function

End Class
