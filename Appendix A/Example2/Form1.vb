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
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents sqlCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents sqlConnection1 As System.Data.SqlClient.SqlConnection
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.sqlCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.SuspendLayout()
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(6, 50)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(80, 16)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Last Name"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(6, 2)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(80, 16)
        Me.label1.TabIndex = 7
        Me.label1.Text = "First Name"
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(6, 74)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(272, 20)
        Me.txtLastName.TabIndex = 1
        Me.txtLastName.Text = ""
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(6, 26)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(272, 20)
        Me.txtFirstName.TabIndex = 0
        Me.txtFirstName.Text = ""
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(6, 114)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(280, 32)
        Me.btnInsert.TabIndex = 2
        Me.btnInsert.Text = "Insert"
        '
        'sqlCommand1
        '
        Me.sqlCommand1.CommandText = "InsertNewAuthor"
        Me.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure
        Me.sqlCommand1.Connection = Me.sqlConnection1
        Me.sqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.sqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.Char, 50, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.sqlCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.Char, 50, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '
        'sqlConnection1
        '
        Me.sqlConnection1.ConnectionString = "data source=.;initial catalog=WroxDB;persist security info=False;user id=sa;works" & _
        "tation id=BLTSERVER;packet size=4096"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 149)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label2, Me.label1, Me.txtLastName, Me.txtFirstName, Me.btnInsert})
        Me.Name = "Form1"
        Me.Text = "New Author"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Try
            If ((txtFirstName.TextLength > 0) And (txtLastName.TextLength > 0)) Then
                ' Open the connection to the database
                sqlConnection1.Open()

                ' Fill the stored procedure parameters with text fields values
                sqlCommand1.Parameters(1).Value = txtFirstName.Text
                sqlCommand1.Parameters(2).Value = txtLastName.Text

                ' Execute the stored procedure
                sqlCommand1.ExecuteNonQuery()

                ' Close the connection
                sqlConnection1.Close()

                ' Print to video the final result
                MessageBox.Show("The new author has been added with the following identifier: " & sqlCommand1.Parameters(0).Value)

                ' Clear text fields
                txtFirstName.Clear()
                txtLastName.Clear()
            End If
        Catch excpt As Exception
            ' If the connection has been opened, close it
            If (sqlConnection1.State = ConnectionState.Open) Then
                sqlConnection1.Close()
            End If

            ' Show error message
            MessageBox.Show(excpt.Message)
        End Try
    End Sub
End Class
