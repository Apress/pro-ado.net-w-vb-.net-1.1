Public Class Consumer2
    Inherits System.Web.UI.Page
    Protected WithEvents Movie As System.Web.UI.WebControls.Label
    Protected WithEvents Quote As System.Web.UI.WebControls.Label
    Protected WithEvents ActorOrCharacter As System.Web.UI.WebControls.Label

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
        Dim tft As New localhost.TrivialFunTools()
        Dim myMovieQuote As New localhost.MovieQuote()
        myMovieQuote = tft.GetMovieQuoteObject()
        Movie.Text = myMovieQuote.Movie
        Quote.Text = myMovieQuote.Quote
        ActorOrCharacter.Text = myMovieQuote.ActorOrCharacter
    End Sub

End Class
