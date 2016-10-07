Imports System.Data.SqlClient

Public Class Form1
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'load the data into a data set
        Dim PubsConnection As New SqlConnection("server=(local);database=pubs;uid=sa;pwd=;")
		Dim PubsAdapter As New SqlDataAdapter("Select * from authors; Select * from titles; select * from titleauthor", PubsConnection)
		Dim PubsDataSet As New DataSet()

		'identify that we want the primary key
		PubsAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
		PubsAdapter.Fill(PubsDataSet)

		'name tables
		PubsDataSet.Tables(0).TableName = "Authors"
		PubsDataSet.Tables(1).TableName = "Titles"
		PubsDataSet.Tables(2).TableName = "TitleAuthor"

		'create two new data relations allowing the constraints to 
		'be created as well
		Dim AuthorTitleParent = New DataRelation("AuthorTitleParent", PubsDataSet.Tables("Authors").Columns("au_id"), PubsDataSet.Tables("TitleAuthor").Columns("au_id"))
		Dim AuthorTitleChild = New DataRelation("AuthorChildParent", PubsDataSet.Tables("Titles").Columns("title_id"), PubsDataSet.Tables("TitleAuthor").Columns("title_id"))

		'add the relations to the dataset
		PubsDataSet.Relations.Add(AuthorTitleParent)
		PubsDataSet.Relations.Add(AuthorTitleChild)

		'create a dataview of the data 
		Dim AuthorView As New DataView(PubsDataSet.Tables("Authors"))

		'restrict the access to the authors table 
		AuthorView.AllowDelete = False
		AuthorView.AllowEdit = True
		AuthorView.AllowNew = True

		'set the grid source to the author view
		Grid1.DataSource = AuthorView

		'hook up the event handler
		AddHandler Grid1.CurrentCellChanged, AddressOf Me.Grid1_CellChanging

	End Sub

	Private Sub Grid1_CellChanging(ByVal sender As Object, ByVal eArgs As EventArgs)

		Dim grid As DataGrid = CType(sender, DataGrid)
		Dim view As DataView = CType(grid.DataSource, DataView)

		If CType(sender, DataGrid).CurrentCell.RowNumber < view.Table.Rows.Count Then

			'instance values
			Dim rows As DataRow()
			Dim rowIndex As Integer

			'get the row number of the selected cell
			rowIndex = CType(sender, DataGrid).CurrentCell.RowNumber

			'use the row number to get the value of the key (customerID)
			Dim Key As String = CType(sender, DataGrid)(rowIndex, 0).ToString()

			'use the key to find the row we selected in the data source
			rows = view.Table.Rows.Find(Key).GetChildRows("AuthorTitleParent")

			Dim tmpData As New DataSet()
			Dim row As DataRow

			For Each row In rows
				tmpData.Merge(row.GetParentRows("AuthorChildParent"))
			Next


			'if there is no data to be displayed, then don't display 
			'the data in the grid.  If there is, create a view and display it
			If (tmpData.Tables.Count > 0) Then

				Dim TitleView As New DataView(tmpData.Tables(0))
				TitleView.AllowDelete = False
				TitleView.AllowEdit = True
				TitleView.AllowNew = True

				TitleView.Sort = "Title ASC"

				Grid2.DataSource = tmpData.Tables(0).DefaultView

			Else

				Grid2.DataSource = Nothing
			End If
		End If
	End Sub


	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	Friend WithEvents Grid2 As System.Windows.Forms.DataGrid
	Friend WithEvents Grid1 As System.Windows.Forms.DataGrid

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Grid2 = New System.Windows.Forms.DataGrid()
        Me.Grid1 = New System.Windows.Forms.DataGrid()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid2
        '
        Me.Grid2.CaptionText = "Titles"
        Me.Grid2.DataMember = ""
        Me.Grid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid2.Location = New System.Drawing.Point(16, 200)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Size = New System.Drawing.Size(664, 184)
        Me.Grid2.TabIndex = 4
        '
        'Grid1
        '
        Me.Grid1.CaptionText = "Authors"
        Me.Grid1.DataMember = ""
        Me.Grid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid1.Location = New System.Drawing.Point(16, 8)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(664, 176)
        Me.Grid1.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(704, 405)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Grid2, Me.Grid1})
        Me.Name = "Form1"
        Me.Text = "WinForm Sample"
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
