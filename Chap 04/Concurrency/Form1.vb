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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCatID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewCatName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCatName As System.Windows.Forms.Label
    Friend WithEvents btnUpdateSQL As System.Windows.Forms.Button
    Friend WithEvents btnUpdateSP As System.Windows.Forms.Button
    Friend WithEvents btnUpdateDS As System.Windows.Forms.Button
    Friend WithEvents btnReadDS As System.Windows.Forms.Button
    Friend WithEvents btnReadCmd As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCatID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNewCatName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnReadCmd = New System.Windows.Forms.Button()
        Me.lblCatName = New System.Windows.Forms.Label()
        Me.btnUpdateSQL = New System.Windows.Forms.Button()
        Me.btnUpdateSP = New System.Windows.Forms.Button()
        Me.btnUpdateDS = New System.Windows.Forms.Button()
        Me.btnReadDS = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Category ID:"
        '
        'txtCatID
        '
        Me.txtCatID.Location = New System.Drawing.Point(136, 16)
        Me.txtCatID.Name = "txtCatID"
        Me.txtCatID.Size = New System.Drawing.Size(138, 20)
        Me.txtCatID.TabIndex = 1
        Me.txtCatID.Text = "1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Category Name:"
        '
        'txtNewCatName
        '
        Me.txtNewCatName.Location = New System.Drawing.Point(132, 68)
        Me.txtNewCatName.Name = "txtNewCatName"
        Me.txtNewCatName.Size = New System.Drawing.Size(431, 20)
        Me.txtNewCatName.TabIndex = 5
        Me.txtNewCatName.Text = "txtNewCatName"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "New Category Name:"
        '
        'btnReadCmd
        '
        Me.btnReadCmd.Location = New System.Drawing.Point(278, 8)
        Me.btnReadCmd.Name = "btnReadCmd"
        Me.btnReadCmd.Size = New System.Drawing.Size(137, 21)
        Me.btnReadCmd.TabIndex = 6
        Me.btnReadCmd.Text = "Read (Command)"
        '
        'lblCatName
        '
        Me.lblCatName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCatName.Location = New System.Drawing.Point(132, 38)
        Me.lblCatName.Name = "lblCatName"
        Me.lblCatName.Size = New System.Drawing.Size(431, 22)
        Me.lblCatName.TabIndex = 7
        Me.lblCatName.Text = "lblCatName"
        '
        'btnUpdateSQL
        '
        Me.btnUpdateSQL.Location = New System.Drawing.Point(132, 98)
        Me.btnUpdateSQL.Name = "btnUpdateSQL"
        Me.btnUpdateSQL.Size = New System.Drawing.Size(137, 22)
        Me.btnUpdateSQL.TabIndex = 8
        Me.btnUpdateSQL.Text = "Update (SQL)"
        '
        'btnUpdateSP
        '
        Me.btnUpdateSP.Location = New System.Drawing.Point(278, 98)
        Me.btnUpdateSP.Name = "btnUpdateSP"
        Me.btnUpdateSP.Size = New System.Drawing.Size(137, 22)
        Me.btnUpdateSP.TabIndex = 9
        Me.btnUpdateSP.Text = "Update (Stored Proc)"
        '
        'btnUpdateDS
        '
        Me.btnUpdateDS.Location = New System.Drawing.Point(424, 98)
        Me.btnUpdateDS.Name = "btnUpdateDS"
        Me.btnUpdateDS.Size = New System.Drawing.Size(137, 22)
        Me.btnUpdateDS.TabIndex = 10
        Me.btnUpdateDS.Text = "Update (DataSet)"
        '
        'btnReadDS
        '
        Me.btnReadDS.Location = New System.Drawing.Point(424, 8)
        Me.btnReadDS.Name = "btnReadDS"
        Me.btnReadDS.Size = New System.Drawing.Size(137, 21)
        Me.btnReadDS.TabIndex = 11
        Me.btnReadDS.Text = "Read (DataSet)"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(569, 128)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReadDS, Me.btnUpdateDS, Me.btnUpdateSP, Me.btnUpdateSQL, Me.lblCatName, Me.btnReadCmd, Me.txtNewCatName, Me.Label3, Me.Label2, Me.txtCatID, Me.Label1})
        Me.Name = "Form1"
        Me.Text = "Concurrency Examples"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Connection string used by all functions
    Private Const ConnString As String = _
        "data source=(local)\netsdk;initial catalog=Northwind;integrated security=SSPI"

    ' Build a SQL SELECT query to read a category record from the database
    Private Function BuildSelectQuery(ByVal CatID As Int32) As String
        Return "SELECT CategoryName, CategoryID FROM Categories " & _
               "WHERE CategoryID = " & CatID
    End Function

    ' Given a category ID, read its name from database
    Private Function ReadCatName(ByVal CatID As Int32) As String
        Dim SelectQuery As String = BuildSelectQuery(CatID)
        Dim cn As New SqlConnection(ConnString)
        Dim cmd As New SqlCommand(SelectQuery, cn)

        cn.Open()
        Dim CatName As String = cmd.ExecuteScalar()
        cn.Close()

        Return CatName
    End Function

    ' Read a category record from database using a DataReader
    Private Sub btnReadCmd_Click(ByVal sender As System.Object, _
                      ByVal e As System.EventArgs) Handles btnReadCmd.Click
        lblCatName.Text = ReadCatName(Convert.ToInt32(txtCatID.Text))
    End Sub

    ' Update category name using a SQL UPDATE statement
    Private Sub btnUpdateSQL_Click(ByVal sender As System.Object, _
                      ByVal e As System.EventArgs) Handles btnUpdateSQL.Click
        Dim UpdateQuery As String = _
        "UPDATE Categories " & _
        "SET CategoryName = '" & txtNewCatName.Text.ToString() & "'" & _
        "WHERE CategoryID = " & Convert.ToInt32(txtCatID.Text) & _
        "AND CategoryName = '" & lblCatName.Text.ToString() & "'"

        Dim cn As New SqlConnection(ConnString)
        Dim cmd As New SqlCommand(UpdateQuery, cn)

        cn.Open()
        Dim RecUpdated As Int32 = cmd.ExecuteNonQuery()
        cn.Close()

        ' Check the number of records updated
        If RecUpdated = 1 Then
            MessageBox.Show("Record updated successfully")
        Else
            MessageBox.Show("Failed to update record")
        End If
    End Sub

    ' Update category name using a stored procedure
    Private Sub btnUpdateSP_Click(ByVal sender As System.Object, _
                     ByVal e As System.EventArgs) Handles btnUpdateSP.Click
        Dim cn As New SqlConnection(ConnString)
        Dim cmd As New SqlCommand("spUpdateCategoryName", cn)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@CatID", Convert.ToInt32(txtCatID.Text))
        cmd.Parameters.Add("@OriginalCatName", lblCatName.Text.ToString())
        cmd.Parameters.Add("@NewCatName", txtNewCatName.Text.ToString())

        cn.Open()
        Dim RecUpdated As Int32 = cmd.ExecuteNonQuery()
        cn.Close()

        ' Check the number of records updated
        If RecUpdated = 1 Then
            MessageBox.Show("Record updated successfully")
        Else
            MessageBox.Show("Failed to update record")
        End If
    End Sub

    ' DataSet storing category data
    Private CatDS As DataSet

    Private Sub btnReadDS_Click(ByVal sender As System.Object, _
                      ByVal e As System.EventArgs) Handles btnReadDS.Click
        Dim SelectQuery As String = _
                        BuildSelectQuery(Convert.ToInt32(txtCatID.Text))
        Dim cn As New SqlConnection(ConnString)
        Dim cmd As New SqlCommand(SelectQuery, cn)
        Dim da As New SqlDataAdapter(cmd)

        CatDS = New DataSet()

        cn.Open()
        da.Fill(CatDS, "Categories")
        cn.Close()

        lblCatName.Text = CatDS.Tables("Categories").Rows(0)("CategoryName")
    End Sub

    ' Update category name using a DataSet
    Private Sub btnUpdateDS_Click(ByVal sender As System.Object, _
                      ByVal e As System.EventArgs) Handles btnUpdateDS.Click
        Dim CatRow As DataRow = CatDS.Tables("Categories").Rows(0)
        CatRow("CategoryName") = txtNewCatName.Text.ToString()

        Dim SelectQuery As String = BuildSelectQuery(CatRow("CategoryID"))
        Dim cn As New SqlConnection(ConnString)
        Dim da As New SqlDataAdapter(SelectQuery, cn)
        Dim cb As New SqlCommandBuilder(da)

        Try
            cn.Open()
            da.Update(CatDS, "Categories")
            MessageBox.Show("Record updated successfully")
        Catch x As DBConcurrencyException
            MessageBox.Show("Fail to update record: " & x.Message)
        Catch x As Exception
            MessageBox.Show("Fail to update record: " & x.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    ' The RowUpdating event handler
    Private Sub OnRowUpdating(ByVal sender As Object, _
                              ByVal e As SqlRowUpdatingEventArgs)
        Dim CatID As String = e.Row("CategoryID", DataRowVersion.Original)
        Dim OriginalCatName As String = _
                        e.Row("CategoryName", DataRowVersion.Original)
        Dim CatNameInDB As String = ReadCatName(CatID)

        If OriginalCatName <> CatNameInDB Then

            ' We have a concurrency violation
            e.Status = UpdateStatus.ErrorsOccurred
            e.Errors = New Exception( _
                          "Category name has changed since loaded:" & vbCrLf & _
                          "Loaded value = " & OriginalCatName & vbCrLf & _
                          "Current value = " & CatNameInDB)
        End If
    End Sub
End Class
