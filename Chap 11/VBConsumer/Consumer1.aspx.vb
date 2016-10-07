Imports VBConsumer.localhost

Public Class Consumer1
    Inherits System.Web.UI.Page
    Protected WithEvents lowNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents highNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents webMethodResult As System.Web.UI.WebControls.Label

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
        If Page.IsPostBack Then
            'Create two integer objects to hold 
            'the low and high values
            Dim low As Int32 = Int32.Parse(lowNumber.Text.Trim())
            Dim high As Int32 = Int32.Parse(highNumber.Text.Trim())

            'Create an instance of the 
            'TrivialFunTools proxy client class
            Dim tft As New VBConsumer.Proxies.TrivialFunTools()

            'Invoke the Web service method and catch 
            'the return value
            Dim result As Int32 = tft.RandomNumberGenerator(low, high)
            'Set the return value to the Label.Text property
            webMethodResult.Text = _
             "<hr><b>Your number is: </b>" & _
             result.ToString()
        End If
    End Sub

End Class
