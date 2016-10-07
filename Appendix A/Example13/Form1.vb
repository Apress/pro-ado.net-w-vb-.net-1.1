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
    Friend WithEvents ds As Example13.dsOrder
    Friend WithEvents dataGrid1 As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ds = New Example13.dsOrder()
        Me.dataGrid1 = New System.Windows.Forms.DataGrid()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ds
        '
        Me.ds.DataSetName = "dsOrder"
        Me.ds.Locale = New System.Globalization.CultureInfo("en-US")
        Me.ds.Namespace = "http://tempuri.org/dsOrder.xsd"
        '
        'dataGrid1
        '
        Me.dataGrid1.CaptionText = "Orders"
        Me.dataGrid1.DataMember = ""
        Me.dataGrid1.DataSource = Me.ds
        Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dataGrid1.Location = New System.Drawing.Point(8, 8)
        Me.dataGrid1.Name = "dataGrid1"
        Me.dataGrid1.Size = New System.Drawing.Size(544, 96)
        Me.dataGrid1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(560, 157)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dataGrid1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds.Order.AddOrderRow(1, "MPAD100", "Fabio Claudio Ferracchiati")
        ds.Basket.AddBasketRow("MPAD100", "Mouse Pad Wrox Logo", 122)
    End Sub
End Class
