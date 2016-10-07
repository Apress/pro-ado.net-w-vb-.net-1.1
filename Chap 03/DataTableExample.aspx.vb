Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class DataTableExample
  Inherits Page

  ' Declare the DataTable object at the class level
  Protected WithEvents myDataTable As DataTable

  ' Map the Web Form server controls
  Protected WithEvents productGrid As DataGrid
  Protected WithEvents eventsList As Label

  Private Sub MakeData()
    myDataTable = CType(Cache.Get("myDataTable"), DataTable)

    ' If myDataTable is not in the cache, create it
    If myDataTable Is Nothing Then
      myDataTable = New DataTable("Products")

      ' Build the Products schema
      myDataTable.Columns.Add("ID", Type.GetType("System.Int32"))
      myDataTable.Columns.Add("Name", Type.GetType("System.String"))
      myDataTable.Columns.Add("Category", Type.GetType("System.Int32"))

      ' Set up the ID column as the primary key
      Dim pk(1) As DataColumn
      pk(0) = myDataTable.Columns("ID")
      myDataTable.PrimaryKey = pk

      myDataTable.Columns("ID").AutoIncrement = True
      myDataTable.Columns("ID").AutoIncrementSeed = 1
      myDataTable.Columns("ID").ReadOnly = True

      Dim tempRow As DataRow

      ' Populate the Products table with 10 cars
      Dim i As Int32 = 0
      For i = 1 To 10
        tempRow = myDataTable.NewRow()

        ' Make every even row a Caterham Seven de Dion
        If Math.IEEERemainder(i, 2) = 0 Then
          tempRow("Name") = "Caterham Seven de Dion #" & i.ToString()
          tempRow("Category") = 1
        Else
          tempRow("Name") = "Dodge Viper #" & i.ToString()
          tempRow("Category") = 2
        End If

        myDataTable.Rows.Add(tempRow)
      Next i

      Cache.Insert("myDataTable", myDataTable)
    End If
  End Sub

  Private Sub BindData()

    ' Get the DataSet
    MakeData()

    ' Set the DataGrid.DataSource properties
    productGrid.DataSource = myDataTable

    ' Bind the DataGrid
    productGrid.DataBind()
  End Sub

  Private Sub ColumnChangingHandler(ByVal Sender As Object, _
                                    ByVal E As DataColumnChangeEventArgs) _
                                    Handles myDataTable.ColumnChanging

    EventsList.Text &= String.Format("<B>ColumnChanging Handler</B><BR>" & _
                                     "&nbsp;&nbsp;Column: {0}<BR>", _
                                     E.Column.ColumnName)

    Dim propValue As String = E.ProposedValue.ToString().ToLower()

    ' If the user changed the name of the car to anything
    ' with the word "pinto" in it, raise an exception.
    If E.Column.ColumnName = "Name" AndAlso _
       propValue.IndexOf("pinto") > -1 Then
      Throw(New System.Exception("Pintos are not allowed on this list."))
    Else
      EventsList.Text &= String.Format("&nbsp;&nbsp;Changing <I>{0}</I>" & _
                                       " to <I>{1}</I><BR>", _
                                       E.Row(E.Column.ColumnName), _
                                       E.ProposedValue)
    End If
  End Sub

  Private Sub ColumnChangedHandler(ByVal Sender As Object, _
                                   ByVal E As DataColumnChangeEventArgs) _
                                   Handles myDataTable. ColumnChanged

    EventsList.Text &= String.Format("<FONT COLOR=""RED"">" & _
                         "<B>ColumnChanged Handler</B></FONT><BR>" & _
                         "&nbsp;&nbsp;Column: {0}<BR>", E.Column.ColumnName)
    EventsList.Text &= String.Format("&nbsp;&nbsp;New Value: {0}<BR>", _
                                     E.ProposedValue)
  End Sub

  Private Sub RowChangingHandler(ByVal Sender As Object, _
                                 ByVal E As DataRowChangeEventArgs) _
                                 Handles MyDataTable.RowChanging

    EventsList.Text &= String.Format("<B>RowChanging Handler</B><BR>" & _
                                   "&nbsp;&nbsp;Row: {0}<BR>", E.Row("ID"))
    EventsList.Text &= String.Format("&nbsp;&nbsp;Action: {0}<BR>", _
                                     E.Action)
  End Sub

  Private Sub RowChangedHandler(ByVal Sender As Object, _
                                ByVal E As DataRowChangeEventArgs) _
                                Handles MyDataTable.RowChanged

    EventsList.Text &= String.Format("<FONT COLOR=""RED""><B>" & _
                                     "RowChanged Handler</B></FONT><BR>" & _
                                     "Row: {0}<BR>", E.Row("ID"))
    EventsList.Text &= String.Format("&nbsp;&nbsp;Action: {0}<BR>", _
                                     E.Action)
  End Sub

  Private Sub RowDeletingHandler(ByVal Sender As Object, _
                                 ByVal E As DataRowChangeEventArgs) _
                                 Handles MyDataTable.RowDeleting

    EventsList.Text &= String.Format("<B>RowDeleting Handler</B><BR>" & _
                                     "Row: {0}<BR>", E.Row("ID"))
    EventsList.Text &= String.Format("&nbsp;&nbsp;Action: {0}<BR>", _
                                     E.Action)
  End Sub

  Private Sub RowDeletedHandler(ByVal Sender As Object, _
                                ByVal E As DataRowChangeEventArgs) _
                                Handles MyDataTable.RowDeleted

    EventsList.Text &= "<FONT COLOR=""RED"">" & _
                       "<B>RowDeleted Handler</B></FONT><BR>"
    EventsList.Text &= String.Format("&nbsp;&nbsp;Action: {0}<BR>", _
                                     E.Action)
  End Sub

  Protected Sub DataGrid_OnEditCommand(ByVal Sender As Object, _
                                       ByVal E As DataGridCommandEventArgs)
    EventsList.Text = ""
    CType(Sender, DataGrid).EditItemIndex = e.Item.ItemIndex
    BindData()
  End Sub

  Protected Sub DataGrid_OnCancelCommand(ByVal Sender As Object, _
                                        ByVal E As DataGridCommandEventArgs)
    CType(Sender, DataGrid).EditItemIndex = -1
    BindData()
  End Sub

  Protected Sub DataGrid_OnUpdateCommand(ByVal Sender As Object, _
                                        ByVal E As DataGridCommandEventArgs)
    EventsList.Text = ""

    ' Cast the Sender object to its true type: it's the source DataGrid
    Dim senderGrid As DataGrid = CType(Sender, DataGrid)

    ' Invoke MakeData() to create the myDataTable object
    MakeData()

    ' Get the edited item values
    Dim Name As TextBox = CType(E.Item.Cells(3).Controls(0), TextBox)
    Dim Category As TextBox = CType(E.Item.Cells(4).Controls(0), TextBox)

    ' Get the PrimaryKey column text
    Dim item As String = E.Item.Cells(2).Text

    ' Get the DataRow from myDataTable
    Dim dr As DataRow = myDataTable.Rows.Find(Int32.Parse(item))

    ' Change DataRow values. This will raise the ColumnChanging event.
    Try
      dr(1) = Name.Text
      dr(2) = Int32.Parse(Category.Text)

      ' Commit changes to DataRow. This will raise the ColumnChanged event.
      dr.AcceptChanges()
    Catch ex As Exception
      EventsList.Text &= "<FONT COLOR=""RED""><B>Error: </FONT>" & _
                         ex.Message & "</B>"
    End Try

    ' Recache the DataTable
    Cache.Insert("myDataTable", myDataTable)

    ' Bind the DataGrid
    senderGrid.EditItemIndex = -1
    BindData()
  End Sub

  Protected Sub DataGrid_OnDeleteCommand(ByVal Sender As Object, _
                                        ByVal E As DataGridCommandEventArgs)
    EventsList.Text = ""

    ' Cast an object as the source DataGrid
    Dim senderGrid As DataGrid = CType(Sender, DataGrid)

    ' Get the Data and create a DataView to filter
    MakeData()

    ' Get the PrimaryKey column text
    Dim item As String = E.Item.Cells(2).Text

    ' Get the DataRow from myDataTable
    Dim dr As DataRow = myDataTable.Rows.Find(Int32.Parse(item))

    ' Use the Remove() method to delete the row
    myDataTable.Rows.Remove(dr)

    ' Recache the DataSet
    Cache.Insert("myDataTable", myDataTable)

    ' Bind the DataGrid
    senderGrid.EditItemIndex = -1
    BindData()
  End Sub

  Protected Sub Page_Load(ByVal Sender As Object, _
                          ByVal E As EventArgs) 
    If Not Page.IsPostBack Then

      ' Start with a fresh DataTable
      Cache.Remove("myDataTable")
    End If

    ' Create a new DataTable by calling the MakeData method
    MakeData()

    If Not Page.IsPostBack Then
      BindData()
    End If
  End Sub
End Class