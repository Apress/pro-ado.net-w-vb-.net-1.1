Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents dgBasket As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ds As Example11VB.dsBasket
    Protected WithEvents dvBasket As System.Data.DataView

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ds = New Example11VB.dsBasket()
        Me.dvBasket = New System.Data.DataView()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvBasket, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'ds
        '
        Me.ds.DataSetName = "dsBasket"
        Me.ds.Locale = New System.Globalization.CultureInfo("en-US")
        Me.ds.Namespace = "http://tempuri.org/dsBasket.xsd"
        '
        'dvBasket
        '
        Me.dvBasket.Table = Me.ds.Basket
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvBasket, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ds.Basket.AddBasketRow("MPAD100", "Mouse Pad Wrox Logo", 2)
        ds.Basket.AddBasketRow("PTON101", "Printer toner", 1)
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Page.IsPostBack = False Then
            dgBasket.DataBind()
        End If
    End Sub

    Private Sub dgBasket_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgBasket.DeleteCommand
        Dim row As dsBasket.BasketRow = ds.Basket.FindBySKU(e.Item.Cells(1).Text)
        ds.Basket.RemoveBasketRow(row)

        dgBasket.DataBind()
    End Sub

    Private Sub dgBasket_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgBasket.SortCommand
        dvBasket.Sort = e.SortExpression
        dgBasket.DataBind()
    End Sub
End Class
