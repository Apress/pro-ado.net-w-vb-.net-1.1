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
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents sqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents sqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents sqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.sqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.sqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(2, 6)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(288, 24)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add a new row"
        '
        'sqlSelectCommand1
        '
        Me.sqlSelectCommand1.CommandText = "SELECT au_lname, au_fname, contract, au_id FROM authors"
        Me.sqlSelectCommand1.Connection = Me.sqlConnection1
        '
        'sqlConnection1
        '
        Me.sqlConnection1.ConnectionString = "data source=.;initial catalog=pubs;persist security info=False;user id=sa;worksta" & _
        "tion id=BLTSERVER;packet size=4096"
        '
        'sqlDataAdapter1
        '
        Me.sqlDataAdapter1.SelectCommand = Me.sqlSelectCommand1
        Me.sqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "authors", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("au_lname", "au_lname"), New System.Data.Common.DataColumnMapping("au_fname", "au_fname"), New System.Data.Common.DataColumnMapping("contract", "contract")})})
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 37)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAdd})
        Me.Name = "Form1"
        Me.Text = "Example5"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim ds As New dsAuthors()
        ds.authors.AddauthorsRow("222-22-2222", "Ferracchiati", "Fabio Claudio", True)
        Dim cb As New System.Data.SqlClient.SqlCommandBuilder(sqlDataAdapter1)
        sqlDataAdapter1.Update(ds.GetChanges())
        Me.Close()
    End Sub
End Class
