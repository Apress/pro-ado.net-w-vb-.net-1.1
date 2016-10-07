Public Class frmOrders
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
    Friend WithEvents dgProducts As System.Windows.Forms.DataGrid
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnRetrieve As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgProducts = New System.Windows.Forms.DataGrid()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnRetrieve = New System.Windows.Forms.Button()
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgProducts
        '
        Me.dgProducts.AllowSorting = False
        Me.dgProducts.AlternatingBackColor = System.Drawing.Color.White
        Me.dgProducts.BackColor = System.Drawing.Color.White
        Me.dgProducts.BackgroundColor = System.Drawing.Color.Ivory
        Me.dgProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgProducts.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
        Me.dgProducts.CaptionForeColor = System.Drawing.Color.Lavender
        Me.dgProducts.CaptionText = "Products"
        Me.dgProducts.DataMember = ""
        Me.dgProducts.FlatMode = True
        Me.dgProducts.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dgProducts.ForeColor = System.Drawing.Color.Black
        Me.dgProducts.GridLineColor = System.Drawing.Color.Wheat
        Me.dgProducts.HeaderBackColor = System.Drawing.Color.CadetBlue
        Me.dgProducts.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgProducts.HeaderForeColor = System.Drawing.Color.Black
        Me.dgProducts.LinkColor = System.Drawing.Color.DarkSlateBlue
        Me.dgProducts.Location = New System.Drawing.Point(8, 7)
        Me.dgProducts.Name = "dgProducts"
        Me.dgProducts.ParentRowsBackColor = System.Drawing.Color.Ivory
        Me.dgProducts.ParentRowsForeColor = System.Drawing.Color.Black
        Me.dgProducts.ReadOnly = True
        Me.dgProducts.SelectionBackColor = System.Drawing.Color.Wheat
        Me.dgProducts.SelectionForeColor = System.Drawing.Color.DarkSlateBlue
        Me.dgProducts.Size = New System.Drawing.Size(416, 208)
        Me.dgProducts.TabIndex = 6
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Ivory
        Me.btnExit.Location = New System.Drawing.Point(432, 191)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Exit"
        '
        'btnRetrieve
        '
        Me.btnRetrieve.BackColor = System.Drawing.Color.GhostWhite
        Me.btnRetrieve.ForeColor = System.Drawing.Color.Black
        Me.btnRetrieve.Location = New System.Drawing.Point(432, 7)
        Me.btnRetrieve.Name = "btnRetrieve"
        Me.btnRetrieve.TabIndex = 4
        Me.btnRetrieve.Text = "Retrieve"
        '
        'frmOrders
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.DarkCyan
        Me.ClientSize = New System.Drawing.Size(514, 223)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgProducts, Me.btnExit, Me.btnRetrieve})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Order material"
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public ds As DataSet

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnRetrieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetrieve.Click
        ' Change mouse pointer to wait cursor
        Me.Cursor = Cursors.WaitCursor

        ' create an object from the web service
        Dim service As New localhost.Service1()

        ' Retrieve the products’ list
        ds = service.RetrieveList()

        ' Restore the original cursor
        Me.Cursor = Cursors.Default

        If Not ds Is Nothing Then
            ' Fill the data grid with the dataset content
            dgProducts.DataSource = ds.Tables(0)
        Else
            MessageBox.Show("Unable to retrieve the list")
        End If
    End Sub

    Private Sub dgProducts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProducts.DoubleClick
        ' Retrieve the current row index selected
        Dim iIndex As Integer = CType(sender, DataGrid).CurrentRowIndex

        ' If the row is valid
        If iIndex <> -1 Then
            ' Create an object from the Submit form
            Dim dialog As New frmSubmit()

            ' Pass to submit form some parameters
            dialog.iIndex = iIndex
            dialog.dsSubmit = ds
            ' Show the modal submit form
            dialog.ShowDialog()

            ' Refresh the product list
            btnRetrieve_Click(sender, e)
        End If
    End Sub
End Class
