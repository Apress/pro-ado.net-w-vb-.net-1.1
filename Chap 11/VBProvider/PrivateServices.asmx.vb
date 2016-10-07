Imports System.Web.Services
Imports System.Web.Services.Protocols

<WebService(Description:="This is a Web service that demonstrates " & _
  "SOAP Authentication.", _
  Namespace:="http://www.dotnetjunkies.com")> _
Public Class PrivateServices
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

    'Create a property of the Web Service that is 
    'the SOAP Header class
    Public Header As mySoapHeader

    <WebMethod(Description:="Get a secret that no " & _
        "one else can get."), _
        SoapHeader("Header")> _
    Public Function GetMySecret() As String
        If Header.ValidUser() Then
            Return "This is my secret."
        Else
            Return "The username or password was incorrect."
        End If
    End Function

End Class

Public Class mySoapHeader
    Inherits SoapHeader

    Public Username As String
    Public Password As String

    Public Function ValidUser() As Boolean
        If Username = "WillyWonka" AndAlso Password = "GoldenTicket" Then
            Return True
        Else
            Return False
        End If
    End Function

End Class