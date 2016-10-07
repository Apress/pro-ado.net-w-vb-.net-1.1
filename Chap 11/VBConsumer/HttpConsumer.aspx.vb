Public Class HttpConsumer
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
        'Put user code to initialize the page here
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Add the TextBox values into the HTTP GET query string
        Dim httpGetUrl As String = _
          "http://localhost/ProADONET/VBProvider/" & _
          "TrivialFunTools.asmx/RandomNumberGenerator?LowNumber=" & _
          lowNumber.Text.Trim() & _
          "&HighNumber=" & _
          highNumber.Text.Trim()

        'Use an XmlDocument to load the XML returned from the Web service method
        Dim xmlDoc As New System.Xml.XmlDocument()
        xmlDoc.Load(httpGetUrl)

        'Pull the value out of the second node
        '  1st Node: <?xml version="1.0" encoding="utf-8" ?> 
        '  2nd Node: <int xmlns="http://www.dotnetjunkies.com">7</int> 
        webMethodResult.Text = "<hr><b>Your number is: </b>" & _
            xmlDoc.ChildNodes.Item(1).InnerText()
    End Sub
End Class
