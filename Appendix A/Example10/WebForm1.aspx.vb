Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents dgBasket As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ds As Example10VB.basket

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ds = New Example10VB.basket()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'ds
        '
        Me.ds.DataSetName = "basket"
        Me.ds.Locale = New System.Globalization.CultureInfo("en-US")
        Me.ds.Namespace = "http://tempuri.org/basket.xsd"
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ds.Basket.AddBasketRow("CPT100", "Mouse PAD", 1)
        dgBasket.DataBind()

    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub dgBasket_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgBasket.UpdateCommand
        Dim strQTY As String = CType(e.Item.Cells(3).Controls(0), TextBox).Text
        ds.Basket(0).Qty = System.Int16.Parse(strQTY)
        dgBasket.EditItemIndex = -1
        dgBasket.DataBind()
    End Sub

    Private Sub dgBasket_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgBasket.CancelCommand
        dgBasket.EditItemIndex = -1
        dgBasket.DataBind()
    End Sub
End Class
