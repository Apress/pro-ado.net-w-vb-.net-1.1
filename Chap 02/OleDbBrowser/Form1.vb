Imports System.Data.OleDb

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OrderDetailsList As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OrderIDsList As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OrderDetailsList = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OrderIDsList = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(232, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 23)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Order Details"
        '
        'OrderDetailsList
        '
        Me.OrderDetailsList.Location = New System.Drawing.Point(232, 32)
        Me.OrderDetailsList.Name = "OrderDetailsList"
        Me.OrderDetailsList.Size = New System.Drawing.Size(352, 360)
        Me.OrderDetailsList.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Order IDs"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(504, 400)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Start"
        '
        'OrderIDsList
        '
        Me.OrderIDsList.ItemHeight = 16
        Me.OrderIDsList.Location = New System.Drawing.Point(8, 32)
        Me.OrderIDsList.Name = "OrderIDsList"
        Me.OrderIDsList.Size = New System.Drawing.Size(216, 356)
        Me.OrderIDsList.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(592, 432)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.OrderDetailsList, Me.Label1, Me.Button1, Me.OrderIDsList})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Const ConnString As String = _
        "Provider=SQLOLEDB;Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI;"
    Private Connection As OleDbConnection = New OleDbConnection(ConnString)

    Private ColumnsSet As Boolean = False

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim command As OleDbCommand = _
            New OleDbCommand("SELECT OrderID FROM Orders", Connection)

        Connection.Open()
        Dim reader As OleDbDataReader = command.ExecuteReader()
        Do While (reader.Read())
            OrderIDsList.Items.Add(reader.GetInt32(0))
        Loop
        reader.Close()
        Connection.Close()
    End Sub

    Private Sub OrderIDsList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderIDsList.SelectedIndexChanged
        Dim OrderID As Integer = Convert.ToInt32(OrderIDsList.SelectedItem)
        Dim StoredProcCommand As OleDbCommand = New OleDbCommand("CustOrdersDetail", Connection)
        With StoredProcCommand
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@OrderID", OrderID)
        End With

        Connection.Open()
        Dim RowList As ArrayList = New ArrayList()
        Dim reader As OleDbDataReader = StoredProcCommand.ExecuteReader()
        Do While reader.Read()
            Dim Values(reader.FieldCount) As Object
            reader.GetValues(Values)
            RowList.Add(Values)
        Loop

        If Not ColumnsSet Then
            Dim schema As DataTable = reader.GetSchemaTable()
            SetColumnHeaders(schema)
        End If
        reader.Close()
        Connection.Close()

        PopulateOrderDetails(RowList)
    End Sub

    Private Sub SetColumnHeaders(ByVal schema As DataTable)
        Dim row As DataRow

        OrderDetailsList.View = View.Details
        For Each row In schema.Rows
            OrderDetailsList.Columns.Add(row("ColumnName"), 100, HorizontalAlignment.Left)
        Next
        ColumnsSet = True
    End Sub

    Private Sub PopulateOrderDetails(ByVal RowList As ArrayList)
        OrderDetailsList.Items.Clear()

        Dim row As Object()
        For Each row In RowList
            Dim OrderDetails(row.Length) As String
            Dim col As Object
            Dim ColIdx As Integer

            For ColIdx = 0 To row.Length - 1
                OrderDetails(ColIdx) = Convert.ToString(row(ColIdx))
            Next

            Dim NewItem As ListViewItem = New ListViewItem(OrderDetails)
            OrderDetailsList.Items.Add(NewItem)
        Next
    End Sub
End Class
