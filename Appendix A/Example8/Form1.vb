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
    Friend WithEvents dgFlights As System.Windows.Forms.DataGrid
    Friend WithEvents dbConn As System.Data.OleDb.OleDbConnection
    Friend WithEvents daFlights As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents oleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents dvFlights As System.Data.DataView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgFlights = New System.Windows.Forms.DataGrid()
        Me.dvFlights = New System.Data.DataView()
        Me.dbConn = New System.Data.OleDb.OleDbConnection()
        Me.daFlights = New System.Data.OleDb.OleDbDataAdapter()
        Me.oleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
        CType(Me.dgFlights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvFlights, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgFlights
        '
        Me.dgFlights.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
        Me.dgFlights.BackColor = System.Drawing.Color.Gainsboro
        Me.dgFlights.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dgFlights.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgFlights.CaptionBackColor = System.Drawing.Color.DarkKhaki
        Me.dgFlights.CaptionFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgFlights.CaptionForeColor = System.Drawing.Color.Black
        Me.dgFlights.DataMember = ""
        Me.dgFlights.DataSource = Me.dvFlights
        Me.dgFlights.FlatMode = True
        Me.dgFlights.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.dgFlights.ForeColor = System.Drawing.Color.Black
        Me.dgFlights.GridLineColor = System.Drawing.Color.Silver
        Me.dgFlights.HeaderBackColor = System.Drawing.Color.Black
        Me.dgFlights.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgFlights.HeaderForeColor = System.Drawing.Color.White
        Me.dgFlights.LinkColor = System.Drawing.Color.DarkSlateBlue
        Me.dgFlights.Location = New System.Drawing.Point(8, 6)
        Me.dgFlights.Name = "dgFlights"
        Me.dgFlights.ParentRowsBackColor = System.Drawing.Color.LightGray
        Me.dgFlights.ParentRowsForeColor = System.Drawing.Color.Black
        Me.dgFlights.SelectionBackColor = System.Drawing.Color.Firebrick
        Me.dgFlights.SelectionForeColor = System.Drawing.Color.White
        Me.dgFlights.Size = New System.Drawing.Size(496, 168)
        Me.dgFlights.TabIndex = 1
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Password="""";User ID=Admin;Data Source=G:\ASPToda" & _
        "y\PRO.ADO.NET\527X Code\Ch03\VB.NET\Example7\bltairlines.mdb;Mode=Share Deny Non" & _
        "e;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path=""""" & _
        ";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locki" & _
        "ng Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions" & _
        "=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet" & _
        " OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet O" & _
        "LEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False"
        '
        'daFlights
        '
        Me.daFlights.SelectCommand = Me.oleDbSelectCommand1
        Me.daFlights.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tabFlights", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("FLIGHTCODE", "FLIGHTCODE"), New System.Data.Common.DataColumnMapping("LeaveFrom", "LeaveFrom"), New System.Data.Common.DataColumnMapping("GoingTo", "GoingTo"), New System.Data.Common.DataColumnMapping("Depart", "Depart"), New System.Data.Common.DataColumnMapping("Arrive", "Arrive")})})
        '
        'oleDbSelectCommand1
        '
        Me.oleDbSelectCommand1.CommandText = "SELECT FLIGHTCODE, LeaveFrom, GoingTo, Depart, Arrive FROM tabFlights"
        Me.oleDbSelectCommand1.Connection = Me.dbConn
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(512, 181)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgFlights})
        Me.Name = "Form1"
        Me.Text = "Example8"
        CType(Me.dgFlights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvFlights, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New dsFlights()
        daFlights.Fill(ds)
        dvFlights.Table = ds.tabFlights
        dvFlights.RowFilter = "FLIGHTCODE='BA101'"
    End Sub
End Class
