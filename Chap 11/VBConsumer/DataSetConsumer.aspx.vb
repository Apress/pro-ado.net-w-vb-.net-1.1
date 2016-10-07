Imports System.IO

Public Class DataSetConsumer
    Inherits System.Web.UI.Page
    Protected WithEvents OriginalDataGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataToAddGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ResultGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Private WithEvents myDataSet As DataSet

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

    Private Sub GetData()
        myDataSet = New DataSet()

        'Open a FileStream to stream in the XML file
        Dim fs As New FileStream( _
         HttpContext.Current.Server.MapPath( _
         "MovieQuotes2.xml"), _
         FileMode.Open, FileAccess.Read)

        Dim xmlStream As New StreamReader(fs)
        'Use the ReadXml() method to create a 
        'DataTable that represents the XML data
        myDataSet.ReadXml(xmlStream)
        xmlStream.Close()

        Dim tft As New localhost.TrivialFunTools()

        OriginalDataGrid.DataSource = tft.GetAllMovieQuotes()
        DataToAddGrid.DataSource = myDataSet
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            GetData()
            Page.DataBind()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Populate myDataSet
        GetData()
        'Create the TrivialFunTools object
        Dim tft As New localhost.TrivialFunTools()
        'Invoke the AddMovieQuotes() method, passing in myDataSet
        'Put the returned DataSet into the myMergedDataSet object
        Dim myMergedDataSet As DataSet = tft.AddMovieQuotes(myDataSet)
        'Set the DataSource of the third DataGrid
        ResultGrid.DataSource = myMergedDataSet
        'Bind all of the controls
        Page.DataBind()
    End Sub
End Class
