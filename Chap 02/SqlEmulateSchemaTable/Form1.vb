Imports System.Data.SqlClient

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SchemaTableList As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SchemaTableList = New System.Windows.Forms.ListView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SchemaTableList
        '
        Me.SchemaTableList.Dock = System.Windows.Forms.DockStyle.Top
        Me.SchemaTableList.Name = "SchemaTableList"
        Me.SchemaTableList.Size = New System.Drawing.Size(880, 512)
        Me.SchemaTableList.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(736, 520)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Read Schema"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(880, 552)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.SchemaTableList})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Const SelectQuery As String = "SELECT * FROM Orders"
        Dim conn As SqlConnection = New SqlConnection _
            ("Data Source=(local);Initial Catalog=Northwind;uid=sa;pwd=sa;")

        ' Retrieving schema for columns from a single table
        Dim cmd As SqlCommand = New SqlCommand(SelectQuery, conn)

        ' Retrieve schema only
        conn.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SchemaOnly)

        ' Get references to schema information
        Dim SchemaTable As DataTable = reader.GetSchemaTable()

        ' Close and release the connection before processing results
        reader.Close()
        conn.Close()

        ' Display schema table column headers
        Dim col As DataColumn
        SchemaTableList.View = View.Details
        For Each col In SchemaTable.Columns
            SchemaTableList.Columns.Add(col.ColumnName, 100, HorizontalAlignment.Left)
        Next

        ' Display schema
        Dim row As DataRow
        Dim ColCount As Integer = SchemaTable.Columns.Count
        For Each row In SchemaTable.Rows
            Dim OrderDetails(ColCount) As String
            Dim ColIdx As Integer

            For ColIdx = 0 To ColCount - 1
                OrderDetails(ColIdx) = Convert.ToString(row(ColIdx))
            Next

            Dim NewItem As ListViewItem = New ListViewItem(OrderDetails)
            SchemaTableList.Items.Add(NewItem)
        Next
    End Sub
End Class
