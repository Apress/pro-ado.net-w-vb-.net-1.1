Imports Apress.ProADONET.OQProvider

Public Class WebForm1
   Inherits System.Web.UI.Page
   Protected WithEvents lblInfo As System.Web.UI.WebControls.Label

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
      If (Page.IsPostBack) Then
         ' They hit the checkout button.
         Dim myConnection As OQConnection = New OQConnection()
         myConnection.ConnectionString = ".\Private$\OQTester"
         myConnection.Open()
         Dim SendCmd As OQCommand = New OQCommand()
         SendCmd.Connection = myConnection
         SendCmd.CommandText = "Send"

         Dim myOrder As OrderObject = New OrderObject( _
            "HOFF", _
            "ORDER99", _
            "Kevin", _
            "101 Nowhere", _
            "", _
            "Somewhere", _
            "OR", _
            "97201", _
            "USA", _
            "FedEx")

         myOrder.AddItem("MOVIE999", 12, 24.99F)
         Dim myParam As OQParameter = New OQParameter(myOrder)
         SendCmd.Parameters("Order") = myParam
         SendCmd.ExecuteNonQuery()

         lblInfo.Text = "Order has been sent to the warehouse for processing."
      End If
   End Sub

End Class
