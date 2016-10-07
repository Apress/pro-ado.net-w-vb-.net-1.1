Imports System.Data.SqlClient

Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents SortList As System.Web.UI.WebControls.DropDownList
    Protected WithEvents SortDirection As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents FilterList As System.Web.UI.WebControls.DropDownList
    Protected WithEvents FilterCriteria As System.Web.UI.WebControls.TextBox
    Protected WithEvents submit As System.Web.UI.WebControls.Button
    Protected WithEvents Authors As System.Web.UI.WebControls.DataGrid

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

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) Handles MyBase.Load

        ' If there is no view or columns in the cache then create them
        Dim AuthorView As DataView = CType(Cache("Authors"), DataView)
        Dim Columns As DataColumnCollection = _
                                     CType(Cache("Columns"), DataColumnCollection)

        ' If the data was not in the cache then we load it
        If (AuthorView Is Nothing Or Columns Is Nothing) Then

            ' Load the data into the DataSet
            Dim AuthorConnection As New SqlConnection( _
                                    "server=(local);database=pubs;uid=sa;pwd=;")
            Dim AuthorAdapter As New SqlDataAdapter( _
                              "SELECT * FROM Authors", AuthorConnection)
            Dim AuthorDataSet As New DataSet()

            AuthorAdapter.Fill(AuthorDataSet)

            ' Set the view and column variables
            Columns = AuthorDataSet.Tables(0).Columns
            AuthorView = AuthorDataSet.Tables(0).DefaultView

            ' Insert the items into the cache, setting a 20 minute timeout
            Cache.Insert("Authors", AuthorView, Nothing, _
                               System.DateTime.Now.AddMinutes(20), System.TimeSpan.Zero)
            Cache.Insert("Columns", AuthorDataSet.Tables(0).Columns, Nothing, _
                               System.DateTime.Now.AddMinutes(20), System.TimeSpan.Zero)
        End If

        ' If we are posting back, then filter and sort the view
        If IsPostBack Then

            ' Sort the view
            AuthorView.Sort = SortList.SelectedItem.Text & " " & _
                              SortDirection.SelectedItem.Text

            ' Set the filter if one exists, or set it to nothing
            If (FilterCriteria.Text <> String.Empty) Then
                AuthorView.RowFilter = FilterList.SelectedItem.Text & _
                                       "= '" & FilterCriteria.Text & "'"
            Else
                AuthorView.RowFilter = ""
            End If
        End If

        ' Set the source of the drop-down lists to be the columns
        SortList.DataSource = Columns
        FilterList.DataSource = Columns

        ' Set the source of the DataGrid to be the view
        Authors.DataSource = AuthorView

        ' Databind all of the controls
        DataBind()
    End Sub
End Class
