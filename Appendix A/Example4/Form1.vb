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
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents dgEmployees As System.Windows.Forms.DataGrid
    Friend WithEvents sqlSelectEmployees As System.Data.SqlClient.SqlCommand
    Friend WithEvents dbConn As System.Data.SqlClient.SqlConnection
    Friend WithEvents sqlUpdateEmployee As System.Data.SqlClient.SqlCommand
    Friend WithEvents daEmployee As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents sqlDeleteEmployee As System.Data.SqlClient.SqlCommand
    Friend WithEvents sqlInsertEmployee As System.Data.SqlClient.SqlCommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.dgEmployees = New System.Windows.Forms.DataGrid()
        Me.sqlSelectEmployees = New System.Data.SqlClient.SqlCommand()
        Me.dbConn = New System.Data.SqlClient.SqlConnection()
        Me.sqlUpdateEmployee = New System.Data.SqlClient.SqlCommand()
        Me.daEmployee = New System.Data.SqlClient.SqlDataAdapter()
        Me.sqlDeleteEmployee = New System.Data.SqlClient.SqlCommand()
        Me.sqlInsertEmployee = New System.Data.SqlClient.SqlCommand()
        CType(Me.dgEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(9, 288)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(512, 23)
        Me.btnConfirm.TabIndex = 3
        Me.btnConfirm.Text = "Confirm"
        '
        'dgEmployees
        '
        Me.dgEmployees.CaptionBackColor = System.Drawing.Color.Firebrick
        Me.dgEmployees.CaptionFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgEmployees.CaptionText = "Employees"
        Me.dgEmployees.DataMember = ""
        Me.dgEmployees.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEmployees.Location = New System.Drawing.Point(9, 8)
        Me.dgEmployees.Name = "dgEmployees"
        Me.dgEmployees.Size = New System.Drawing.Size(512, 272)
        Me.dgEmployees.TabIndex = 2
        '
        'sqlSelectEmployees
        '
        Me.sqlSelectEmployees.CommandText = "SELECT Title, FirstName, LastName, HomePhone, EmployeeID FROM Employees"
        Me.sqlSelectEmployees.Connection = Me.dbConn
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "data source=.;initial catalog=Northwind;persist security info=False;user id=sa;wo" & _
        "rkstation id=BLTSERVER;packet size=4096"
        '
        'sqlUpdateEmployee
        '
        Me.sqlUpdateEmployee.CommandText = "UPDATE Employees SET Title = @Title, FirstName = @FirstName, LastName = @LastName" & _
        ", HomePhone = @HomePhone WHERE (EmployeeID = @Original_EmployeeID) AND (FirstNam" & _
        "e = @Original_FirstName) AND (HomePhone = @Original_HomePhone OR @Original_HomeP" & _
        "hone1 IS NULL AND HomePhone IS NULL) AND (LastName = @Original_LastName) AND (Ti" & _
        "tle = @Original_Title OR @Original_Title1 IS NULL AND Title IS NULL); SELECT Tit" & _
        "le, FirstName, LastName, HomePhone, EmployeeID FROM Employees WHERE (EmployeeID " & _
        "= @Select_EmployeeID)"
        Me.sqlUpdateEmployee.Connection = Me.dbConn
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Current, Nothing))
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 10, "FirstName"))
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20, "LastName"))
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HomePhone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "HomePhone", System.Data.DataRowVersion.Current, Nothing))
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_FirstName", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FirstName", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HomePhone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "HomePhone", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HomePhone1", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "HomePhone", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_LastName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastName", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title1", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlUpdateEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Select_EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"))
        '
        'daEmployee
        '
        Me.daEmployee.DeleteCommand = Me.sqlDeleteEmployee
        Me.daEmployee.InsertCommand = Me.sqlInsertEmployee
        Me.daEmployee.SelectCommand = Me.sqlSelectEmployees
        Me.daEmployee.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Employees", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Title", "Title"), New System.Data.Common.DataColumnMapping("FirstName", "FirstName"), New System.Data.Common.DataColumnMapping("LastName", "LastName"), New System.Data.Common.DataColumnMapping("HomePhone", "HomePhone")})})
        Me.daEmployee.UpdateCommand = Me.sqlUpdateEmployee
        '
        'sqlDeleteEmployee
        '
        Me.sqlDeleteEmployee.CommandText = "DELETE FROM Employees WHERE (EmployeeID = @EmployeeID) AND (FirstName = @FirstNam" & _
        "e) AND (HomePhone = @HomePhone OR @HomePhone1 IS NULL AND HomePhone IS NULL) AND" & _
        " (LastName = @LastName) AND (Title = @Title OR @Title1 IS NULL AND Title IS NULL" & _
        ")"
        Me.sqlDeleteEmployee.Connection = Me.dbConn
        Me.sqlDeleteEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlDeleteEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FirstName", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlDeleteEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HomePhone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "HomePhone", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlDeleteEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HomePhone1", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "HomePhone", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlDeleteEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastName", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlDeleteEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
        Me.sqlDeleteEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title1", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
        '
        'sqlInsertEmployee
        '
        Me.sqlInsertEmployee.CommandText = "INSERT INTO Employees(Title, FirstName, LastName, HomePhone) VALUES (@Title, @Fir" & _
        "stName, @LastName, @HomePhone); SELECT Title, FirstName, LastName, HomePhone, Em" & _
        "ployeeID FROM Employees WHERE (EmployeeID = @@IDENTITY)"
        Me.sqlInsertEmployee.Connection = Me.dbConn
        Me.sqlInsertEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Current, Nothing))
        Me.sqlInsertEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 10, "FirstName"))
        Me.sqlInsertEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20, "LastName"))
        Me.sqlInsertEmployee.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HomePhone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "HomePhone", System.Data.DataRowVersion.Current, Nothing))
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(530, 319)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnConfirm, Me.dgEmployees})
        Me.Name = "Form1"
        Me.Text = "Example4"
        CType(Me.dgEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim ds As dsEmployee

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ds = New dsEmployee()
        daEmployee.Fill(ds)
        dgEmployees.DataSource = ds.Employees
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Try
            Dim dsModifies As New DataSet("dsModifies")

            dsModifies = ds.GetChanges()

            If Not dsModifies Is Nothing Then
                daEmployee.Update(dsModifies)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
