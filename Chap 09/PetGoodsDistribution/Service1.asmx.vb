Imports System.Web.Services
Imports System.Data.OleDb

<WebService(Namespace:="http://tempuri.org/")> _
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
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

    <WebMethod()> Public Function RetrieveList() As DataSet
        ' Create a dataset that will contain products list
        Dim ds As New DataSet("Products")

        Try
            ' Create the connection object (Update the below accordingly)
            Dim dbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Password=;User ID=Admin;Data Source=C:\Documents and Settings\Sahil Malik\Desktop\Apress2\Malik4347\Sahil - After reviewing Chapters\Chap 09\Code\PetGoodsDistribution\pets.mdb")

            ' Create the data adapter specifying the SQL 
            ' statement used to fill the dataset
            Dim da As New OleDbDataAdapter("SELECT ID_PRODUCT, NAME, DESCRIPTION, QUANTITY, PRICE FROM Products", dbConn)

            da.Fill(ds)
        Catch
            ds = Nothing
        End Try

        ' return the dataset
        Return ds

    End Function

    <WebMethod()> Public Function Order(ByVal d As DataSet, ByVal iCustomerID As Integer) As DataSet

        ' Create a dataset that will contain orders list
        Dim ds As New DataSet("Orders")

        Try
            ' Create the connection object
            Dim dbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Password=;User ID=Admin;Data Source=C:\pets.mdb")

            ' Create the data adapter specifying the SQL 
            ' statement used to fill the dataset
            Dim da As New OleDbDataAdapter("SELECT ID_ORDER, ID_PRODUCT, ID_CUSTOMER, QUANTITY_ORDERED FROM Orders", dbConn)

            da.Fill(ds)

            ' Go through each row that has to be inserted
            Dim r As DataRow

            For Each r In d.Tables(0).Rows
                Dim newRow As DataRow = ds.Tables(0).NewRow()
                newRow("ID_PRODUCT") = r("ID_PRODUCT")
                newRow("QUANTITY_ORDERED") = r("QUANTITY")
                newRow("ID_CUSTOMER") = iCustomerID
                ds.Tables(0).Rows.Add(newRow)
            Next

            ' Update the database with new records
            Dim cm As New OleDbCommandBuilder(da)
            da.Update(ds.GetChanges())

            ' Update the available quantity
            UpdateQuantity(d)

            ' Return
            Return ds.GetChanges

        Catch
            Return Nothing
        End Try
    End Function

    Private Sub UpdateQuantity(ByVal d As DataSet)

        'Here should be some code for updating quantity in Products table with regards to order was made

    End Sub


End Class
