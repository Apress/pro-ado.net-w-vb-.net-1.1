Imports System.Data.Common
Imports System.Data.OleDb

Public Class frmSubmit
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
    Friend WithEvents groupBox As System.Windows.Forms.GroupBox
    Friend WithEvents txtQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents lbText As System.Windows.Forms.Label
    Friend WithEvents button2 As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.groupBox = New System.Windows.Forms.GroupBox()
        Me.txtQuantity = New System.Windows.Forms.NumericUpDown()
        Me.label2 = New System.Windows.Forms.Label()
        Me.lbText = New System.Windows.Forms.Label()
        Me.button2 = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.groupBox.SuspendLayout()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupBox
        '
        Me.groupBox.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.groupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtQuantity, Me.label2, Me.lbText})
        Me.groupBox.ForeColor = System.Drawing.Color.White
        Me.groupBox.Location = New System.Drawing.Point(10, 14)
        Me.groupBox.Name = "groupBox"
        Me.groupBox.Size = New System.Drawing.Size(320, 264)
        Me.groupBox.TabIndex = 3
        Me.groupBox.TabStop = False
        Me.groupBox.Text = "Product ID "
        '
        'txtQuantity
        '
        Me.txtQuantity.BackColor = System.Drawing.Color.Ivory
        Me.txtQuantity.Location = New System.Drawing.Point(88, 232)
        Me.txtQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.ReadOnly = True
        Me.txtQuantity.Size = New System.Drawing.Size(216, 20)
        Me.txtQuantity.TabIndex = 4
        Me.txtQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'label2
        '
        Me.label2.BackColor = System.Drawing.Color.Ivory
        Me.label2.Font = New System.Drawing.Font("Verdana", 8.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(8, 232)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(70, 20)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Quantity"
        '
        'lbText
        '
        Me.lbText.BackColor = System.Drawing.Color.Ivory
        Me.lbText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbText.ForeColor = System.Drawing.Color.Black
        Me.lbText.Location = New System.Drawing.Point(8, 16)
        Me.lbText.Name = "lbText"
        Me.lbText.Size = New System.Drawing.Size(296, 208)
        Me.lbText.TabIndex = 3
        '
        'button2
        '
        Me.button2.BackColor = System.Drawing.Color.Ivory
        Me.button2.ForeColor = System.Drawing.Color.Black
        Me.button2.Location = New System.Drawing.Point(338, 254)
        Me.button2.Name = "button2"
        Me.button2.TabIndex = 4
        Me.button2.Text = "Cancel"
        '
        'btnSubmit
        '
        Me.btnSubmit.BackColor = System.Drawing.Color.GhostWhite
        Me.btnSubmit.ForeColor = System.Drawing.Color.Black
        Me.btnSubmit.Location = New System.Drawing.Point(338, 22)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 24)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "Submit"
        '
        'frmSubmit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.DarkCyan
        Me.ClientSize = New System.Drawing.Size(422, 293)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox, Me.button2, Me.btnSubmit})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSubmit"
        Me.Text = "Select the required quantity and submit..."
        Me.groupBox.ResumeLayout(False)
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public iIndex As Integer
    Public dsSubmit As DataSet

    Private Sub frmSubmit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim drSubmit As DataRow
        drSubmit = dsSubmit.Tables(0).Rows(iIndex)
        groupBox.Text = groupBox.Text & drSubmit("ID_PRODUCT")
        Dim txt As String = "NAME: " & drSubmit("NAME") & vbCrLf & vbCrLf & "DESCRIPTION: " & _
            drSubmit("DESCRIPTION") & vbCrLf & vbCrLf & "PRICE: " & drSubmit("PRICE") & "$"
        lbText.Text = txt
        txtQuantity.Maximum = CInt(drSubmit("QUANTITY"))
        txtQuantity.Value = CInt(drSubmit("QUANTITY"))
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim service As New localhost.Service1()
        dsSubmit.Tables(0).Rows(iIndex)("QUANTITY") = txtQuantity.Value
        Dim ds As DataSet = service.Order(dsSubmit.GetChanges(DataRowState.Modified), 1) ' 1 is the Customer ID assigned by the supplier

        If Not ds Is Nothing Then
            MessageBox.Show("Your order was accepted.")
            Me.Close()
        Else

            MessageBox.Show("Error occurred during order processing.")
        End If
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        Me.Close()
    End Sub

    Public Function Order(ByVal d As DataSet, ByVal iCustomerID As Integer) As DataSet

        ' Create a dataset that will contain orders list
        Dim ds As New DataSet("Orders")

        'Try
        ' Create the connection object
        Dim dbConn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Password=;User ID=Admin;Data Source=C:\pets.mdb")

        ' Create the data adapter specifying the SQL 
        ' statement used to fill the dataset
        Dim da As New OleDbDataAdapter("SELECT ID_ORDER, ID_PRODUCT, ID_CUSTOMER, QUANTITY_ORDERED FROM Orders", dbConn)

        da.Fill(ds)

        ' Go through each row that has to be inserted
        Dim r As DataRow

        For Each r In d.Tables(0).Rows
            Dim newRow As DataRow = ds.Tables(0).NewRow()
            newRow("ID_PRODUCT") = r("ID_PRODUCT")
            newRow("QUANTITY_ORDERED") = r("QUANTITY")
            newRow("ID_CUSTOMER") = iCustomerID
            ds.Tables(0).Rows.Add(newRow)
        Next

        ' Update the database with new records
        Dim cm As New OleDbCommandBuilder(da)
        da.Update(ds.GetChanges())

        ' Update the available quantity
        UpdateQuantity(d)

        ' Return
        Return ds.GetChanges

        'Catch
        'Return Nothing
        'End Try
    End Function

    Private Sub UpdateQuantity(ByVal d As DataSet)

        'Here should be some code for updating quantity in Products table with regards to order was made

    End Sub

End Class
