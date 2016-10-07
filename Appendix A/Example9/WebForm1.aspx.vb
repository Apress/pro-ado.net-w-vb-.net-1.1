Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents dgFlights As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dbConn As System.Data.OleDb.OleDbConnection
    Protected WithEvents daFlights As System.Data.OleDb.OleDbDataAdapter
    Protected WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Protected WithEvents ds As Example9VB.dsFlights
    Protected WithEvents dvFlights As System.Data.DataView
    Protected WithEvents outputText As System.Web.UI.HtmlControls.HtmlGenericControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dbConn = New System.Data.OleDb.OleDbConnection()
        Me.daFlights = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.ds = New Example9VB.dsFlights()
        Me.dvFlights = New System.Data.DataView()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvFlights, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Password="""";User ID=Admin;Data Source=G:\ASPToda" & _
        "y\PRO.ADO.NET\527X Code\Ch03\VB.NET\Example7\bltairlines.mdb;Mode=Share Deny Non" & _
        "e;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path=""""" & _
        ";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locki" & _
        "ng Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions" & _
        "=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet" & _
        " OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet O" & _
        "LEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False"
        '
        'daFlights
        '
        Me.daFlights.SelectCommand = Me.OleDbSelectCommand1
        Me.daFlights.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tabFlights", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("FLIGHTCODE", "FLIGHTCODE"), New System.Data.Common.DataColumnMapping("LeaveFrom", "LeaveFrom"), New System.Data.Common.DataColumnMapping("GoingTo", "GoingTo"), New System.Data.Common.DataColumnMapping("Depart", "Depart"), New System.Data.Common.DataColumnMapping("Arrive", "Arrive"), New System.Data.Common.DataColumnMapping("FirstName", "FirstName"), New System.Data.Common.DataColumnMapping("LastName", "LastName"), New System.Data.Common.DataColumnMapping("ID_PILOT", "ID_PILOT")})})
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = "SELECT tabFlights.FLIGHTCODE, tabFlights.LeaveFrom, tabFlights.GoingTo, tabFlight" & _
        "s.Depart, tabFlights.Arrive, tabPilots.FirstName, tabPilots.LastName, tabPilots." & _
        "ID_PILOT FROM tabFlights INNER JOIN tabPilots ON tabFlights.ID_PILOT = tabPilots" & _
        ".ID_PILOT"
        Me.OleDbSelectCommand1.Connection = Me.dbConn
        '
        'ds
        '
        Me.ds.DataSetName = "dsFlights"
        Me.ds.Locale = New System.Globalization.CultureInfo("en-US")
        Me.ds.Namespace = "http://tempuri.org/dsFlights.xsd"
        '
        'dvFlights
        '
        Me.dvFlights.Table = Me.ds.tabFlights
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvFlights, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        daFlights.Fill(ds)
        dgFlights.DataBind()
    End Sub

    Private Sub dgFlights_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgFlights.SortCommand
        dvFlights.Sort = e.SortExpression
        dgFlights.DataBind()
    End Sub


    Private Sub dgFlights_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgFlights.SelectedIndexChanged
        Dim dgi As DataGridItem = CType(sender, DataGrid).SelectedItem

        outputText.InnerHtml = "The flight " & dgi.Cells(1).Text & " has been booked"
    End Sub

    Private Sub dgFlights_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgFlights.EditCommand
        dgFlights.EditItemIndex = e.Item.ItemIndex
        dgFlights.DataBind()
    End Sub

    Private Sub dgFlights_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgFlights.UpdateCommand
        outputText.InnerHtml = CType(e.Item.Cells(3).Controls(0), TextBox).Text
        dgFlights.DataBind()
    End Sub
End Class
