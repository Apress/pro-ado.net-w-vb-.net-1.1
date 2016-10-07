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
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents lbFound As System.Windows.Forms.ListBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents sqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents sqlCommand1 As System.Data.SqlClient.SqlCommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.lbFound = New System.Windows.Forms.ListBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.sqlCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SuspendLayout()
        '
        'txtFind
        '
        Me.txtFind.Location = New System.Drawing.Point(46, 10)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(240, 20)
        Me.txtFind.TabIndex = 7
        Me.txtFind.Text = ""
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(6, 10)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(40, 16)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Find:"
        '
        'lbFound
        '
        Me.lbFound.Location = New System.Drawing.Point(6, 50)
        Me.lbFound.Name = "lbFound"
        Me.lbFound.Size = New System.Drawing.Size(280, 173)
        Me.lbFound.TabIndex = 5
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(6, 226)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(280, 32)
        Me.btnFind.TabIndex = 4
        Me.btnFind.Text = "Find"
        '
        'sqlConnection1
        '
        Me.sqlConnection1.ConnectionString = "data source=.;initial catalog=Northwind;persist security info=False;user id=sa;wo" & _
        "rkstation id=BLTSERVER;packet size=4096"
        '
        'sqlCommand1
        '
        Me.sqlCommand1.CommandText = "SELECT FirstName, LastName FROM Employees WHERE (LastName LIKE @Find)"
        Me.sqlCommand1.Connection = Me.sqlConnection1
        Me.sqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Find", System.Data.SqlDbType.NVarChar, 20, "LastName"))
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 269)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtFind, Me.label1, Me.lbFound, Me.btnFind})
        Me.Name = "Form1"
        Me.Text = "Looking for employees..."
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim drEmployee As SqlDataReader

        Try
            ' Open connection to the database
            sqlConnection1.Open()

            ' Fill the parameter with the value retrieved from the text field
            sqlCommand1.Parameters("@Find").Value = txtFind.Text

            ' Execute the query
            drEmployee = sqlCommand1.ExecuteReader()

            ' Fill the list box with the values retrieved
            lbFound.Items.Clear()
            While (drEmployee.Read())
                lbFound.Items.Add(drEmployee("FirstName").ToString() & " " & drEmployee("LastName").ToString())
            End While
        Catch ex As Exception
            ' Print error message
            MessageBox.Show(ex.Message)
        Finally
            ' Close data reader object and database connection
            If (Not drEmployee Is Nothing) Then
                drEmployee.Close()
            End If

            If (sqlConnection1.State = ConnectionState.Open) Then
                sqlConnection1.Close()
            End If
        End Try
    End Sub
End Class
