Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class Chapter7
    Inherits System.Windows.Forms.Form

    Private connectionString As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        connectionString = "server=(local);database=Northwind;uid=sa;pwd=;"

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

    Friend WithEvents OutputText As System.Windows.Forms.TextBox
    Friend WithEvents BoundCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Grid2 As System.Windows.Forms.DataGrid
    Friend WithEvents Grid1 As System.Windows.Forms.DataGrid
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Private WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem32 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem33 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem34 As System.Windows.Forms.MenuItem
    Friend WithEvents ExitItem As System.Windows.Forms.MenuItem
    Friend WithEvents UniqueConstraintItem As System.Windows.Forms.MenuItem
    Friend WithEvents SimpleConstraintItem As System.Windows.Forms.MenuItem
    Friend WithEvents MultiColumnConstrainItem As System.Windows.Forms.MenuItem
    Friend WithEvents AcceptRejectItem As System.Windows.Forms.MenuItem
    Friend WithEvents SimpleRelationItem As System.Windows.Forms.MenuItem
    Friend WithEvents GetChildRowsItem As System.Windows.Forms.MenuItem
    Friend WithEvents GetChildRowsVersionItem As System.Windows.Forms.MenuItem
    Friend WithEvents DataViewItem As System.Windows.Forms.MenuItem
    Friend WithEvents SortingDataViewItem As System.Windows.Forms.MenuItem
    Friend WithEvents FilteringDataViewItem As System.Windows.Forms.MenuItem
    Friend WithEvents FilterDataViewVersionItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditingDataViewItem As System.Windows.Forms.MenuItem
    Friend WithEvents DataViewManagerItem As System.Windows.Forms.MenuItem
    Friend WithEvents ChildDataViewItem As System.Windows.Forms.MenuItem
    Friend WithEvents SimpleBindingItem As System.Windows.Forms.MenuItem
    Friend WithEvents ListBindingItem As System.Windows.Forms.MenuItem
    Friend WithEvents DataMemberBinding As System.Windows.Forms.MenuItem
    Friend WithEvents RelationNested As System.Windows.Forms.MenuItem
    Private WithEvents mainMenu As System.Windows.Forms.MainMenu

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OutputText = New System.Windows.Forms.TextBox()
        Me.BoundCombo = New System.Windows.Forms.ComboBox()
        Me.Grid2 = New System.Windows.Forms.DataGrid()
        Me.Grid1 = New System.Windows.Forms.DataGrid()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.MenuItem12 = New System.Windows.Forms.MenuItem()
        Me.MenuItem13 = New System.Windows.Forms.MenuItem()
        Me.MenuItem14 = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.MenuItem16 = New System.Windows.Forms.MenuItem()
        Me.MenuItem17 = New System.Windows.Forms.MenuItem()
        Me.MenuItem18 = New System.Windows.Forms.MenuItem()
        Me.MenuItem19 = New System.Windows.Forms.MenuItem()
        Me.MenuItem20 = New System.Windows.Forms.MenuItem()
        Me.MenuItem21 = New System.Windows.Forms.MenuItem()
        Me.MenuItem22 = New System.Windows.Forms.MenuItem()
        Me.MenuItem23 = New System.Windows.Forms.MenuItem()
        Me.MenuItem24 = New System.Windows.Forms.MenuItem()
        Me.MenuItem25 = New System.Windows.Forms.MenuItem()
        Me.MenuItem28 = New System.Windows.Forms.MenuItem()
        Me.mainMenu = New System.Windows.Forms.MainMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.ExitItem = New System.Windows.Forms.MenuItem()
        Me.MenuItem27 = New System.Windows.Forms.MenuItem()
        Me.MenuItem29 = New System.Windows.Forms.MenuItem()
        Me.UniqueConstraintItem = New System.Windows.Forms.MenuItem()
        Me.MenuItem31 = New System.Windows.Forms.MenuItem()
        Me.SimpleConstraintItem = New System.Windows.Forms.MenuItem()
        Me.MultiColumnConstrainItem = New System.Windows.Forms.MenuItem()
        Me.AcceptRejectItem = New System.Windows.Forms.MenuItem()
        Me.MenuItem32 = New System.Windows.Forms.MenuItem()
        Me.SimpleRelationItem = New System.Windows.Forms.MenuItem()
        Me.GetChildRowsItem = New System.Windows.Forms.MenuItem()
        Me.GetChildRowsVersionItem = New System.Windows.Forms.MenuItem()
        Me.RelationNested = New System.Windows.Forms.MenuItem()
        Me.MenuItem33 = New System.Windows.Forms.MenuItem()
        Me.DataViewItem = New System.Windows.Forms.MenuItem()
        Me.SortingDataViewItem = New System.Windows.Forms.MenuItem()
        Me.FilteringDataViewItem = New System.Windows.Forms.MenuItem()
        Me.FilterDataViewVersionItem = New System.Windows.Forms.MenuItem()
        Me.EditingDataViewItem = New System.Windows.Forms.MenuItem()
        Me.DataViewManagerItem = New System.Windows.Forms.MenuItem()
        Me.ChildDataViewItem = New System.Windows.Forms.MenuItem()
        Me.MenuItem34 = New System.Windows.Forms.MenuItem()
        Me.SimpleBindingItem = New System.Windows.Forms.MenuItem()
        Me.ListBindingItem = New System.Windows.Forms.MenuItem()
        Me.DataMemberBinding = New System.Windows.Forms.MenuItem()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OutputText
        '
        Me.OutputText.BackColor = System.Drawing.SystemColors.ControlDark
        Me.OutputText.Location = New System.Drawing.Point(16, 400)
        Me.OutputText.Multiline = True
        Me.OutputText.Name = "OutputText"
        Me.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.OutputText.Size = New System.Drawing.Size(712, 104)
        Me.OutputText.TabIndex = 7
        Me.OutputText.Text = ""
        '
        'BoundCombo
        '
        Me.BoundCombo.DropDownWidth = 121
        Me.BoundCombo.Location = New System.Drawing.Point(736, 16)
        Me.BoundCombo.Name = "BoundCombo"
        Me.BoundCombo.Size = New System.Drawing.Size(121, 21)
        Me.BoundCombo.TabIndex = 6
        Me.BoundCombo.Text = "comboBox1"
        '
        'Grid2
        '
        Me.Grid2.DataMember = ""
        Me.Grid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid2.Location = New System.Drawing.Point(16, 200)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Size = New System.Drawing.Size(712, 192)
        Me.Grid2.TabIndex = 5
        '
        'Grid1
        '
        Me.Grid1.DataMember = ""
        Me.Grid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid1.Location = New System.Drawing.Point(16, 24)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(712, 168)
        Me.Grid1.TabIndex = 4
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = -1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3, Me.MenuItem9, Me.MenuItem14, Me.MenuItem22})
        Me.MenuItem2.Text = "Actions"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 0
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem4, Me.MenuItem5})
        Me.MenuItem3.Text = "Constraints"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 0
        Me.MenuItem4.Text = "Unique Constraint"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 1
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem6, Me.MenuItem7, Me.MenuItem8})
        Me.MenuItem5.Text = "Foreign Key Constraint"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 0
        Me.MenuItem6.Text = "Simple Constraint"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 1
        Me.MenuItem7.Text = "Multi-Column constraint"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 2
        Me.MenuItem8.Text = "AcceptReject Rule"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 1
        Me.MenuItem9.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem10, Me.MenuItem11, Me.MenuItem12, Me.MenuItem13})
        Me.MenuItem9.Text = "Relations"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 0
        Me.MenuItem10.Text = "Simple Relation"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 1
        Me.MenuItem11.Text = "GetChildRows"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 2
        Me.MenuItem12.Text = "GetChildRows w/ row version"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 3
        Me.MenuItem13.Text = "Nested Property"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 2
        Me.MenuItem14.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem15, Me.MenuItem16, Me.MenuItem17, Me.MenuItem18, Me.MenuItem19, Me.MenuItem20, Me.MenuItem21})
        Me.MenuItem14.Text = "DataViews"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 0
        Me.MenuItem15.Text = "Simple DataView"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 1
        Me.MenuItem16.Text = "Sorting DataView"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 2
        Me.MenuItem17.Text = "Filtering DataView"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 3
        Me.MenuItem18.Text = "Filter DataView w/Version"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 4
        Me.MenuItem19.Text = "Editing DataView"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 5
        Me.MenuItem20.Text = "DataView Manager"
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 6
        Me.MenuItem21.Text = "Child DataView"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 3
        Me.MenuItem22.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem23, Me.MenuItem24, Me.MenuItem25})
        Me.MenuItem22.Text = "DataBinding"
        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 0
        Me.MenuItem23.Text = "Simple Grid Binding"
        '
        'MenuItem24
        '
        Me.MenuItem24.Index = 1
        Me.MenuItem24.Text = "List Binding"
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 2
        Me.MenuItem25.Text = "Using DataMember in Binding"
        '
        'MenuItem28
        '
        Me.MenuItem28.Index = -1
        Me.MenuItem28.Text = ""
        '
        'mainMenu
        '
        Me.mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem27})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ExitItem})
        Me.MenuItem1.Text = "File"
        '
        'ExitItem
        '
        Me.ExitItem.Index = 0
        Me.ExitItem.Text = "Exit"
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 1
        Me.MenuItem27.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem29, Me.MenuItem32, Me.MenuItem33, Me.MenuItem34})
        Me.MenuItem27.Text = "Actions"
        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 0
        Me.MenuItem29.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.UniqueConstraintItem, Me.MenuItem31})
        Me.MenuItem29.Text = "Constraints"
        '
        'UniqueConstraintItem
        '
        Me.UniqueConstraintItem.Index = 0
        Me.UniqueConstraintItem.Text = "UniqueConstraint"
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 1
        Me.MenuItem31.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.SimpleConstraintItem, Me.MultiColumnConstrainItem, Me.AcceptRejectItem})
        Me.MenuItem31.Text = "ForeignKey Constraints"
        '
        'SimpleConstraintItem
        '
        Me.SimpleConstraintItem.Index = 0
        Me.SimpleConstraintItem.Text = "Simple Constraint"
        '
        'MultiColumnConstrainItem
        '
        Me.MultiColumnConstrainItem.Index = 1
        Me.MultiColumnConstrainItem.Text = "Multi Column Constraint"
        '
        'AcceptRejectItem
        '
        Me.AcceptRejectItem.Index = 2
        Me.AcceptRejectItem.Text = "Accept Reject Rule"
        '
        'MenuItem32
        '
        Me.MenuItem32.Index = 1
        Me.MenuItem32.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.SimpleRelationItem, Me.GetChildRowsItem, Me.GetChildRowsVersionItem, Me.RelationNested})
        Me.MenuItem32.Text = "Relations"
        '
        'SimpleRelationItem
        '
        Me.SimpleRelationItem.Index = 0
        Me.SimpleRelationItem.Text = "Simple Relation"
        '
        'GetChildRowsItem
        '
        Me.GetChildRowsItem.Index = 1
        Me.GetChildRowsItem.Text = "Get Child Rows"
        '
        'GetChildRowsVersionItem
        '
        Me.GetChildRowsVersionItem.Index = 2
        Me.GetChildRowsVersionItem.Text = "Get Child Rows w/Version"
        '
        'RelationNested
        '
        Me.RelationNested.Index = 3
        Me.RelationNested.Text = "Nested Property"
        '
        'MenuItem33
        '
        Me.MenuItem33.Index = 2
        Me.MenuItem33.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.DataViewItem, Me.SortingDataViewItem, Me.FilteringDataViewItem, Me.FilterDataViewVersionItem, Me.EditingDataViewItem, Me.DataViewManagerItem, Me.ChildDataViewItem})
        Me.MenuItem33.Text = "Data Views"
        '
        'DataViewItem
        '
        Me.DataViewItem.Index = 0
        Me.DataViewItem.Text = "Simple DataView"
        '
        'SortingDataViewItem
        '
        Me.SortingDataViewItem.Index = 1
        Me.SortingDataViewItem.Text = "Sorting DataView"
        '
        'FilteringDataViewItem
        '
        Me.FilteringDataViewItem.Index = 2
        Me.FilteringDataViewItem.Text = "Filtering DataView"
        '
        'FilterDataViewVersionItem
        '
        Me.FilterDataViewVersionItem.Index = 3
        Me.FilterDataViewVersionItem.Text = "Filtering DataView w/Version"
        '
        'EditingDataViewItem
        '
        Me.EditingDataViewItem.Index = 4
        Me.EditingDataViewItem.Text = "Editing DataView"
        '
        'DataViewManagerItem
        '
        Me.DataViewManagerItem.Index = 5
        Me.DataViewManagerItem.Text = "DataViewManager"
        '
        'ChildDataViewItem
        '
        Me.ChildDataViewItem.Index = 6
        Me.ChildDataViewItem.Text = "Child DataView"
        '
        'MenuItem34
        '
        Me.MenuItem34.Index = 3
        Me.MenuItem34.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.SimpleBindingItem, Me.ListBindingItem, Me.DataMemberBinding})
        Me.MenuItem34.Text = "Binding"
        '
        'SimpleBindingItem
        '
        Me.SimpleBindingItem.Index = 0
        Me.SimpleBindingItem.Text = "Simple Grid  Binding"
        '
        'ListBindingItem
        '
        Me.ListBindingItem.Index = 1
        Me.ListBindingItem.Text = "List Binding"
        '
        'DataMemberBinding
        '
        Me.DataMemberBinding.Index = 2
        Me.DataMemberBinding.Text = "Using DataMember in binding"
        '
        'Chapter9
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(864, 541)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.OutputText, Me.BoundCombo, Me.Grid2, Me.Grid1})
        Me.Menu = Me.mainMenu
        Me.Name = "Chapter9"
        Me.Text = "Chapter07"
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub UniqueConstraintItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UniqueConstraintItem.Click

        PrepareUI()

        Dim constraintDS As DataSet = LoadDataSet()

        'create the unique constraint passing in the columns to constrain
        Dim constrainedColumn As DataColumn = constraintDS.Tables("Customers").Columns("Phone")
        Dim uniqueContact = New UniqueConstraint(constrainedColumn)

        'add the constraint to the constraints collection of the table
        constraintDS.Tables("Customers").Constraints.Add(uniqueContact)

        'do not allow null values in the phone column
        constraintDS.Tables("Customers").Columns("Phone").AllowDBNull = False

        'set the datasoure of the grid to the table with the constraint
        Grid1.DataSource = constraintDS.Tables("customers").DefaultView

        SetMessage("A unique constraint has been placed on the phone column.")
    End Sub

    Private Sub SimpleConstraintItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleConstraintItem.Click
        PrepareUI()

        Dim simpleForeign As DataSet = LoadDataSet()

        'create a new foreign key constraint between the customers
        'and orders tables on the customer id field
        Dim Parent As DataColumn = simpleForeign.Tables("Customers").Columns("CustomerID")
        Dim Child As DataColumn = simpleForeign.Tables("Orders").Columns("CustomerID")
        Dim customerIDConstraint As New ForeignKeyConstraint(Parent, Child)

        'add the constraint to the child table
        simpleForeign.Tables("Orders").Constraints.Add(customerIDConstraint)

        'set up the UI
        Grid1.DataSource = simpleForeign.Tables("Customers").DefaultView
        Grid2.DataSource = simpleForeign.Tables("Orders").DefaultView

        SetMessage("A foreign key constraint has been placed on the two tables using the CustomerID field")
    End Sub

    Private Sub MultiColumnConstrainItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultiColumnConstrainItem.Click
        MessageBox.Show("No implementation provided, see the code for information.")

        '''this code will not run as is because there is no customer id in the 
        '''order details table. It is provided as an example of how to create a
        '''multi column foreign key constraint 
        Dim multiData As DataSet = LoadDataSet()
        Dim Parents As DataColumn() = New DataColumn() _
        {multiData.Tables("Orders").Columns("OrderID"), _
        multiData.Tables("Orders").Columns("CustomerID")}

        Dim Children As DataColumn() = New DataColumn() _
        {multiData.Tables("OrderDetails").Columns("OrderID"), _
        multiData.Tables("OrderDetails").Columns("CustomerID")}

        Dim multiConstraint As ForeignKeyConstraint = New ForeignKeyConstraint(Parents, Children)

        multiData.Tables("OrderDetails").Constraints.Add(multiConstraint)


    End Sub

    Private Sub AcceptRejectItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcceptRejectItem.Click
        PrepareUI()

        Dim simpleForeign As DataSet = LoadDataSet()

        'create a new foreign key constraint on the customer id columns
        Dim Parent As DataColumn = simpleForeign.Tables("Customers").Columns("CustomerID")
        Dim Child As DataColumn = simpleForeign.Tables("Orders").Columns("CustomerID")
        Dim customerIDConstraint As New ForeignKeyConstraint(Parent, Child)

        'indicate that on accept or reject, the changes should cascade
        'to the related child rows
        customerIDConstraint.AcceptRejectRule = AcceptRejectRule.Cascade

        'indicate that when an item in the parent is deleted, the 
        'related child records should have their key value set to null
        customerIDConstraint.DeleteRule = Rule.SetNull

        'indicate that when the parent is updated, the child rows
        'should also be updated to match
        customerIDConstraint.UpdateRule = Rule.Cascade

        'add the constraint to the child table
        simpleForeign.Tables("Orders").Constraints.Add(customerIDConstraint)

        'set the grid sources to the two tables
        Grid1.DataSource = simpleForeign.Tables("Customers").DefaultView
        Grid2.DataSource = simpleForeign.Tables("Orders").DefaultView

        SetMessage("A foreign key constraint has been set on the two tables with the following rules:" & vbCrLf & vbCrLf & "AcceptRejectRule:Cascade" & vbCrLf & vbCrLf & "DeleteRule:SetNull" & vbCrLf & vbCrLf & "UpdateRule:Cascade")

    End Sub

    Private Sub SimpleRelationItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleRelationItem.Click
        PrepareUI()

        Dim relationData As DataSet = LoadDataSet()

        'create a new relation giving it a name and identifying the columns
        'to relate on
        Dim Parent As DataColumn = relationData.Tables("Customers").Columns("Customerid")
        Dim Child As DataColumn = relationData.Tables("Orders").Columns("customerid")

        Dim customerRelation As New DataRelation("customerRelation", Parent, Child)

        'add the relation to the dataset's relation property(DataRelationCollection)
        relationData.Relations.Add(customerRelation)

        'set the data source of the grid to the default view for the parent table
        Grid1.DataSource = relationData.Tables("customers").DefaultView

        SetMessage("A data relation has been created between the tables using the customerID column.")

    End Sub

    Private Sub GetChildRowsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetChildRowsItem.Click
        PrepareUI()
        Dim childrenData As DataSet = LoadDataSet()

        'create the relation and add it to the collection
        'for the dataset
        Dim Parent As DataColumn = childrenData.Tables("Customers").Columns("Customerid")
        Dim Child As DataColumn = childrenData.Tables("Orders").Columns("customerid")

        Dim customerRelation As New DataRelation("customerRelation", Parent, Child)
        childrenData.Relations.Add(customerRelation)

        'set the datasource of the grid to the customers table
        Grid1.DataSource = childrenData.Tables("customers").DefaultView

        'hook up the event handler so we can update the 
        'child grid when a new row is selected
        AddHandler Grid1.CurrentCellChanged, AddressOf Me.CurrentCellChangedEventHandler

        SetMessage("Clicking the parent table will use the GetChildRows method to get related rows into the child table.")
    End Sub


    'this event handler gets the child rows and puts them in the child grid
    Private Sub CurrentCellChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)

        'instance values
        Dim rows As DataRow()
        Dim rowIndex As Integer

        'get the row number of the selected cell
        rowIndex = CType(sender, DataGrid).CurrentCell.RowNumber

        'use the row number to get the value of the key (customerID)
        Dim Key As String = CType(sender, DataGrid)(rowIndex, 0).ToString()

        'use the key to find the row we selected in the data source
        Dim sourceView As DataView = CType(CType(sender, DataGrid).DataSource, DataView)
        Dim row As DataRow = sourceView.Table.Rows.Find(Key)
        rows = row.GetChildRows("customerRelation")

        'merge the child rows into a new dataset and set the source of the
        'child table to the default view of the initial table
        Dim tmpData As New DataSet()
        tmpData.Merge(rows)
        Grid2.DataSource = tmpData.Tables(0).DefaultView
    End Sub

    Private Sub GetChildRowsVersionItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetChildRowsVersionItem.Click
        PrepareUI()

        Dim childrenData As DataSet = LoadDataSet()
        Dim Parent As DataColumn = childrenData.Tables("Customers").Columns("Customerid")
        Dim Child As DataColumn = childrenData.Tables("Orders").Columns("customerid")
        Dim customerRelation As New DataRelation("customerRelation", Parent, Child)
        childrenData.Relations.Add(customerRelation)

        'set datasource and hook up event handler for the row changing event
        Grid1.DataSource = childrenData.Tables("customers").DefaultView
        AddHandler childrenData.Tables("customers").RowChanging, AddressOf Me.RelationOnRowChange

        SetMessage("Clicking on the parent grid will get the child rows with the original version.")
    End Sub

    Private Sub RelationOnRowChange(ByVal sender As Object, ByVal args As DataRowChangeEventArgs)

        Dim childRows As DataRow()

        'we use the Has Version method to test if the row exists first
        Dim row As DataRow
        Dim HasVersion As Boolean = False
        For Each row In args.Row.GetChildRows("customerRelation")
            If row.HasVersion(DataRowVersion.Original) Then
                HasVersion = True
            End If
        Next

        'if the version exists, then we'll get that version and display it
        If HasVersion Then
            childRows = args.Row.GetChildRows("customerRelation", DataRowVersion.Original)
        End If

        Dim temp As New DataSet()
        temp.Merge(childRows)

        Grid2.DataSource = temp.Tables(0).DefaultView
    End Sub

    Private Sub RelationNested_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RelationNested.Click, MenuItem13.Click

        Dim nested As DataSet = LoadDataSet()

        'create a data relation using customers and orders
        Dim parentColumns As DataColumn()
        parentColumns = New DataColumn() {nested.Tables("customers").Columns("customerid")}

        Dim childColumns As DataColumn()
        childColumns = New DataColumn() {nested.Tables("orders").Columns("customerid")}

        Dim customerIDrelation As DataRelation = New DataRelation("CustomerOrderRelation", parentColumns, childColumns)

        'create a data relation using orders and order details
        parentColumns = New DataColumn() {nested.Tables("orders").Columns("orderid")}

        childColumns = New DataColumn() {nested.Tables("orderdetails").Columns("orderid")}

        Dim orderDetailsRelation As DataRelation = New DataRelation("OrderDetailsRelation", parentColumns, childColumns)

        'add the relations to the dataset collection of relations
        nested.Relations.Add(customerIDrelation)
        nested.Relations.Add(orderDetailsRelation)

        'indicate that the relation should be nested and show the XML
        customerIDrelation.Nested = True
        orderDetailsRelation.Nested = True

        MessageBox.Show(Me, nested.GetXml(), "Nested XML from DataSet")

    End Sub


    Private Sub DataViewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataViewItem.Click
        PrepareUI()

        Dim firstFilter As DataSet = LoadDataSet()

        'create a new dataview
        Dim tableFilter As New DataView(firstFilter.Tables("customers"))

        'set the filter for the dataview and bind to the ui
        tableFilter.RowFilter = "CustomerID = 'ALFKI'"
        Grid1.DataSource = tableFilter

        SetMessage("A DataView has been used as the source for the top grid filtering the data on the customer id")

    End Sub

    Private Sub SortingDataViewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SortingDataViewItem.Click
        PrepareUI()

        Dim firstSort As DataSet = LoadDataSet()

        'create the data view object and set the table to the 
        'customers table by passing it in the constructor
        Dim tableSort As New DataView(firstSort.Tables("customers"))

        'set the sort criteria for the view
        tableSort.Sort = "Region DESC, City ASC"

        'apply the view as the source for the grid
        Grid1.DataSource = tableSort

        SetMessage("A data view sorted by region (descending) and city (ascending) has been used as source of the first grid.")

    End Sub

    Private Sub FilteringDataViewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilteringDataViewItem.Click
        PrepareUI()

        Dim dataFilter As DataSet = LoadDataSet()

        'create a new data view based on the customers table
        Dim tableFilter As New DataView(dataFilter.Tables("customers"))

        'set the row filter property of the view to filter the 
        'viewable rows
        tableFilter.RowFilter = "Country='UK' AND City='Cowes'"

        'bind data to the grid
        Grid1.DataSource = tableFilter

        SetMessage("The row filter of the source dataview has been set to:" & vbCrLf & "Country='UK' AND City='Cowes'")

    End Sub

    Private Sub FilterDataViewVersionItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterDataViewVersionItem.Click
        PrepareUI()

        Dim filterVersion As DataSet = LoadDataSet()

        'create two new views on the customers table
        Dim currentView As New DataView(filterVersion.Tables("customers"))
        Dim originalView As New DataView(filterVersion.Tables("customers"))

        'set the rowstatefilter property for each view
        currentView.RowStateFilter = DataViewRowState.CurrentRows
        originalView.RowStateFilter = DataViewRowState.ModifiedOriginal

        'set the two grids to these views
        Grid1.DataSource = currentView
        Grid2.DataSource = originalView

        SetMessage("The lower grid uses a dataview that shows only the original version of modified rows, while the upper grid holds the current version. Edit the top grid to begin populating the lower.")

    End Sub

    Private Sub EditingDataViewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditingDataViewItem.Click
        PrepareUI()
        Dim viewEditSet As DataSet = LoadDataSet()

        'indicate that the user cannot delete items
        viewEditSet.Tables("Orders").DefaultView.AllowDelete = False

        'indicate that the user cannot add new items
        viewEditSet.Tables("Orders").DefaultView.AllowNew = False

        'indicate that the user can edit the current items
        viewEditSet.Tables("Orders").DefaultView.AllowEdit = True

        'set the source of the grid to this view
        Grid1.DataSource = viewEditSet.Tables("Orders").DefaultView

        SetMessage("The view for the grid has been set to prohibit deleting or adding but allow editing.")

    End Sub

    Private Sub DataViewManagerItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataViewManagerItem.Click
        PrepareUI()

        Dim ManagerData As DataSet = LoadDataSet()

        'create a new dataviewmanager based on the dataset
        Dim manager As New DataViewManager(ManagerData)

        'sort the data in the view for the orders table based on the
        'order date in ascending order
        manager.DataViewSettings("Orders").Sort = "OrderDate DESC"

        'set the grid source to be the manager and the member
        'to be the orders table
        Grid1.DataSource = manager
        Grid1.DataMember = "Orders"

        SetMessage("A dataview manager was used as the source for the grid.")

    End Sub

    Private Sub ChildDataViewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChildDataViewItem.Click
        PrepareUI()

        Dim childViewSet As DataSet = LoadDataSet()

        'define columns
        Dim Parent As DataColumn = childViewSet.Tables("Customers").Columns("customerid")
        Dim Child As DataColumn = childViewSet.Tables("orders").Columns("customerid")

        'create new relation
        Dim childViewRelation As New DataRelation("CustomerOrderRelation", Parent, Child)
        childViewSet.Relations.Add(childViewRelation)

        'use the child dataview for the lower grid
        Grid1.DataSource = childViewSet.Tables(0).DefaultView
        Grid2.DataSource = childViewSet.Tables(0).DefaultView(0).CreateChildView(childViewRelation)

        SetMessage("The second data grid has as its source, the result of a CreateChildView method call on the first view.")
    End Sub

    Private Function LoadDataSet() As System.Data.DataSet
        'create connection and other data objects
        Dim nwindConnection As New SqlConnection(connectionString)
        Dim nwindAdapter As New SqlDataAdapter("select * from customers; select * from orders; select * from [order details]", nwindConnection)

        Dim nwindDataSet As New DataSet()

        'fill the dataset, getting key values
        nwindAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
        nwindAdapter.Fill(nwindDataSet)

        'name all of the tables appropriately
        nwindDataSet.Tables(0).TableName = "Customers"
        nwindDataSet.Tables(1).TableName = "Orders"
        nwindDataSet.Tables(2).TableName = "OrderDetails"

        'return the filled dataset
        Return nwindDataSet
    End Function

    'helper method to clean up the ui objects before moving to another action
    Public Sub PrepareUI()

        Grid1.DataSource = Nothing
        Grid1.DataMember = String.Empty
        Grid2.DataSource = Nothing
        Grid2.DataMember = String.Empty
        BoundCombo.DataSource = Nothing
        BoundCombo.DisplayMember = String.Empty
        BoundCombo.ValueMember = String.Empty
        OutputText.Text = String.Empty
        RemoveHandler Grid1.CurrentCellChanged, AddressOf Me.CurrentCellChangedEventHandler
    End Sub

    'helper method to set the text of the message text box
    Public Sub SetMessage(ByVal message As String)

        OutputText.Text = message
    End Sub

    Private Sub SimpleBindingItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleBindingItem.Click
        PrepareUI()
        Dim bindingData As DataSet = LoadDataSet()

        'bind the grid to the default view of the customers table
        Grid1.DataSource = bindingData.Tables("customers").DefaultView

        SetMessage("A simple example of binding the data in a data table to a UI element using the DataView.")

    End Sub

    Private Sub ListBindingItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBindingItem.Click
        PrepareUI()

        Dim listSet As DataSet = LoadDataSet()

        'set the datasource of the list to the default view
        'of the customers table
        BoundCombo.DataSource = listSet.Tables("Customers").DefaultView

        'now we identify the item to be displayed
        BoundCombo.DisplayMember = "CompanyName"

        'and identify the item to maintain as
        'the value of the item 
        BoundCombo.ValueMember = "CustomerID"

        SetMessage("A simple example of binding data to a combox box using the displaymember and valuemember properties.")

    End Sub

    Private Sub DataMemberBinding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataMemberBinding.Click
        PrepareUI()
        Dim MemberSet As DataSet = LoadDataSet()

        'set the datasource to the dataset
        Grid1.DataSource = MemberSet

        'provide the name of a data table to indicate the item
        'within the source to use for the data
        Grid1.DataMember = "Customers"

        SetMessage("An example of binding data using the DataMember property.")
    End Sub

    Private Sub ExitItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitItem.Click
        Me.Close()

    End Sub

End Class