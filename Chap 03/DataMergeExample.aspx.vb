Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

public class DataMergeExample
    Inherits Page

	'Map the Web Form server controls
	Protected WithEvents DataGrid1, DataGrid2, DataGrid3 As DataGrid
	Protected WithEvents PreserveChanges As RadioButtonList
	Protected WithEvents AddSchema As CheckBox
	
	'Create a New DataSet with the DataSetName value "Northwind"
	Private WithEvents myDataSet As New DataSet("Northwind")
	'Declare class-level DataSets for the clone and merged DataSets
	Private WithEvents myOtherDataSet As New DataSet()
	Private WithEvents myMergedDataSet As DataSet
		
	Private Sub MakeData()
		'Create the T-SQL and ConnectionString values
		Dim mySqlStmt As String = "SELECT TOP 5 ProductID, ProductName, UnitsInStock " + _
			"FROM Products ORDER BY ProductID"
		Dim myConString As String = "server=localhost;database=Northwind;uid=sa;pwd=;"
		
		'Construct a New SqlDataAdapter with the preceding values
		Dim myDataAdapter As New SqlDataAdapter(mySqlStmt, myConString)

		'Invoke the Fill() method to create a New DataTable in the DataSet
		myDataAdapter.Fill(myDataSet, "Products")
		
		'Define the DataSet.Primary key and make the column read-only
		Dim pk(1) As DataColumn
		pk(0) = myDataSet.Tables("Products").Columns("ProductID")
		myDataSet.Tables("Products").PrimaryKey = pk
		myDataSet.Tables("Products").Columns("ProductID").ReadOnly = True
		
		myDataSet.EnforceConstraints = True
		
		'Create a second DataSet with an additional column
		mySqlStmt ="SELECT TOP 10 ProductID, ProductName, UnitsInStock, Discontinued " + _
			"FROM Products ORDER BY ProductID"
		myDataAdapter.SelectCommand.CommandText = mySqlStmt
		myDataAdapter.Fill(myOtherDataSet, "Products")
		
		'Define the DataSet.Primary key
		pk(0) = myOtherDataSet.Tables("Products").Columns("ProductID")
		myOtherDataSet.Tables("Products").PrimaryKey = pk
		myOtherDataSet.Tables("Products").Columns("ProductID").ReadOnly = True

		myOtherDataSet.EnforceConstraints = True
	End Sub
	
	Private Sub BindData()
		'If the myDataSet object has no tables, invoke MakeData()
		If myDataSet.Tables.Count < 1 Then
			MakeData()
		End If
		
		'Set the DataSource properties for the main DataGrids
		DataGrid1.DataSource = myDataSet
		DataGrid2.DataSource = myOtherDataSet
		
		'Bind the DataGrids
		Page.DataBind()
	End Sub
	
'*********************************************************************'
'********************** DataGrid Event Handlers **********************'
'*********************************************************************'
	
	Protected Sub DataGrid_OnEditCommand(ByVal Sender As Object, ByVal E As DataGridCommandEventArgs)
		CType(Sender, DataGrid).EditItemIndex = e.Item.ItemIndex
		BindData()
	End Sub
	
	Protected Sub DataGrid_OnCancelCommand(ByVal Sender As Object, ByVal E As DataGridCommandEventArgs)
		CType(Sender, DataGrid).EditItemIndex = -1
		BindData()
	End Sub

	Protected Sub DataGrid_OnUpdateCommand(ByVal Sender As Object, ByVal E As DataGridCommandEventArgs)
		'Cast an object as the source DataGrid
 		Dim senderGrid As DataGrid = CType(Sender, DataGrid)

 		'Invoke MakeData() to create the DataSet objects
 		MakeData()		
		
		'Get the edited item values
		Dim ProductName As TextBox = CType(E.Item.Cells(2).Controls(0), TextBox)
		Dim UnitsInStock As TextBox = CType(E.Item.Cells(3).Controls(0), TextBox)
		Dim Discontinued As TextBox = CType(E.Item.Cells(4).Controls(0), TextBox)

 		'Get the PrimaryKey column text 
		Dim ProductID As String = E.Item.Cells(1).Text
		
		'Get the DataRow from myDataTable
		Dim dr As DataRow = myOtherDataSet.Tables("Products").Rows.Find(Int32.Parse(ProductID))
		
		'Change the DataRow values
		dr("ProductName") = ProductName.Text
		dr("UnitsInStock") = Int16.Parse(UnitsInStock.Text)
		
		If Discontinued.Text.ToLower() = "false"
			dr("Discontinued") = 0
		Else
			dr("Discontinued") = 1
		End If
 		
 		'Commit the changes to the DataRow
		dr.AcceptChanges()
		
	        'Bind the DataGrid 
		senderGrid.EditItemIndex = -1
		
		myMergedDataSet = myDataSet.Copy()
		myMergedDataSet.EnforceConstraints = True
		
		'Create a boolean value indicating whether or not to preserve changes
		Dim _preserveChanges As Boolean
		
		If PreserveChanges.SelectedItem.Value = "1" Then
			_preserveChanges = True
		Else
			_preserveChanges = False
		End If
		
		'Merge the DataSet Imports the AddSchema value
		If AddSchema.Checked Then
			myMergedDataSet.Merge(myOtherDataSet, 	_preserveChanges, MissingSchemaAction.Add)
		Else
		
			myMergedDataSet.Merge(myOtherDataSet, 	_preserveChanges, MissingSchemaAction.Ignore)		
		End If
		
		'Set the DataGrid3 DataSource and bind it
		DataGrid3.DataSource = myMergedDataSet
		DataGrid3.DataBind()
		
		BindData()
	End SUb
	
'*********************************************************************'
'******************** End DataGrid Event Handlers ********************'
'*********************************************************************'

	Protected Sub MergeFailedHandler(ByVal Sender As Object, ByVal E As MergeFailedEventArgs) Handles myDataSet.MergeFailed, myOtherDataSet.MergeFailed, myMergedDataSet.MergeFailed
		 Response.Write(e.Conflict)
	End Sub

	Protected Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs)
		If Not Page.IsPostBack Then
			'Create a New DataSet by invoking
			'the MakeData() method
			MakeData()
			'Bind the data to the server controls
			BindData()
		End If		
	End Sub
End Class