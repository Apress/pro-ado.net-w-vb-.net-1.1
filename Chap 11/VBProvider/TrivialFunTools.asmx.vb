Imports System.Web.Services

<WebService(Description:="This is a collection of silly Web services " & _
"that demonstrate various Web service capabilities.", _
Namespace:="http://www.dotnetjunkies.com")> _
Public Class TrivialFunTools
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

    <WebMethod(Description:="Generate a random number between " & _
        "two values.<br>This Web service demonstrates how a " & _
        "basic Web service works.")> _
    Public Function RandomNumberGenerator(ByVal LowNumber As Int32, ByVal HighNumber As Int32) As Int32
        Dim RandNumber As New Random()
        Return RandNumber.Next(LowNumber, HighNumber)
    End Function

    ' GetAllMovieQuotes - Get all movie quotes.
    ' This Web serives shows how you can return a DataSet.
    <WebMethod(Description:="Get all movie quotes.<br>" & _
      "This Web service shows how you can return a DataSet.")> _
    Public Function GetAllMovieQuotes() As DataSet
        Dim myDataSet As New MovieQuotesDataSet()
        Return myDataSet
    End Function

    ' AddMovieQuotes - Adds a DataSet of MovieQuotes to the existing DataSet.
    ' This Web serives shows how you can use a DataSet as an input argument.
    <WebMethod(Description:="Add movie quotes.<br>" & _
       "This Web serives shows how you can use a DataSet " & _
       "as an input argument.")> _
    Public Function AddMovieQuotes(ByVal MovieQuotes As DataSet) As DataSet
        Dim myDataSet As New MovieQuotesDataSet()
        myDataSet.Merge(MovieQuotes, False, MissingSchemaAction.Add)
        Return myDataSet
    End Function

    ' GetMovieQuoteObject - Get a random MovieQuote object. 
    ' This Web serives shows how you can return a custom object as XML.
    <WebMethod(Description:="Get a random MovieQuote object.<br>" & _
      "This Web serives shows how you can return a custom object as XML.")> _
    Public Function GetMovieQuoteObject() As MovieQuote
        Dim mq As New MovieQuote()
        Return mq
    End Function

    ' GetComplexMovieObject - Get a random ComplexMovie object. 
    ' This Web serives shows how you can return a custom object as XML.
    <WebMethod(Description:="Get a random ComplexMovie object.<br>" & _
      "This Web serives shows how you can return a custom object as XML.")> _
    Public Function GetComplexMovieObject() As ComplexMovie
        Dim cm As New ComplexMovie()
        Return cm
    End Function

End Class
