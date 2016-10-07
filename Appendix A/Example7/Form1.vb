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
    Friend WithEvents dgRemoved As System.Windows.Forms.DataGrid
    Friend WithEvents dgCurrent As System.Windows.Forms.DataGrid
    Friend WithEvents oleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents dbConn As System.Data.OleDb.OleDbConnection
    Friend WithEvents dvFlights As System.Data.DataView
    Friend WithEvents dvRemoved As System.Data.DataView
    Friend WithEvents daFlights As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents oleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents oleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents oleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgRemoved = New System.Windows.Forms.DataGrid()
        Me.dgCurrent = New System.Windows.Forms.DataGrid()
        Me.oleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.dbConn = New System.Data.OleDb.OleDbConnection()
        Me.dvFlights = New System.Data.DataView()
        Me.dvRemoved = New System.Data.DataView()
        Me.daFlights = New System.Data.OleDb.OleDbDataAdapter()
        Me.oleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.oleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.oleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
        CType(Me.dgRemoved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCurrent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvFlights, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvRemoved, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgRemoved
        '
        Me.dgRemoved.AlternatingBackColor = System.Drawing.Color.OldLace
        Me.dgRemoved.BackColor = System.Drawing.Color.OldLace
        Me.dgRemoved.BackgroundColor = System.Drawing.Color.Tan
        Me.dgRemoved.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgRemoved.CaptionBackColor = System.Drawing.Color.SaddleBrown
        Me.dgRemoved.CaptionForeColor = System.Drawing.Color.OldLace
        Me.dgRemoved.CaptionText = "Removed records..."
        Me.dgRemoved.DataMember = ""
        Me.dgRemoved.FlatMode = True
        Me.dgRemoved.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dgRemoved.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.dgRemoved.GridLineColor = System.Drawing.Color.Tan
        Me.dgRemoved.HeaderBackColor = System.Drawing.Color.Wheat
        Me.dgRemoved.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgRemoved.HeaderForeColor = System.Drawing.Color.SaddleBrown
        Me.dgRemoved.LinkColor = System.Drawing.Color.DarkSlateBlue
        Me.dgRemoved.Location = New System.Drawing.Point(8, 158)
        Me.dgRemoved.Name = "dgRemoved"
        Me.dgRemoved.ParentRowsBackColor = System.Drawing.Color.OldLace
        Me.dgRemoved.ParentRowsForeColor = System.Drawing.Color.DarkSlateGray
        Me.dgRemoved.ReadOnly = True
        Me.dgRemoved.SelectionBackColor = System.Drawing.Color.SlateGray
        Me.dgRemoved.SelectionForeColor = System.Drawing.Color.White
        Me.dgRemoved.Size = New System.Drawing.Size(488, 152)
        Me.dgRemoved.TabIndex = 3
        '
        'dgCurrent
        '
        Me.dgCurrent.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
        Me.dgCurrent.BackColor = System.Drawing.Color.Gainsboro
        Me.dgCurrent.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dgCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgCurrent.CaptionBackColor = System.Drawing.Color.DarkKhaki
        Me.dgCurrent.CaptionFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgCurrent.CaptionForeColor = System.Drawing.Color.Black
        Me.dgCurrent.CaptionText = "Current records..."
        Me.dgCurrent.DataMember = ""
        Me.dgCurrent.DataSource = Me.dvFlights
        Me.dgCurrent.FlatMode = True
        Me.dgCurrent.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.dgCurrent.ForeColor = System.Drawing.Color.Black
        Me.dgCurrent.GridLineColor = System.Drawing.Color.Silver
        Me.dgCurrent.HeaderBackColor = System.Drawing.Color.Black
        Me.dgCurrent.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgCurrent.HeaderForeColor = System.Drawing.Color.White
        Me.dgCurrent.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgCurrent.LinkColor = System.Drawing.Color.DarkSlateBlue
        Me.dgCurrent.Location = New System.Drawing.Point(8, 6)
        Me.dgCurrent.Name = "dgCurrent"
        Me.dgCurrent.ParentRowsBackColor = System.Drawing.Color.LightGray
        Me.dgCurrent.ParentRowsForeColor = System.Drawing.Color.Black
        Me.dgCurrent.SelectionBackColor = System.Drawing.Color.Firebrick
        Me.dgCurrent.SelectionForeColor = System.Drawing.Color.White
        Me.dgCurrent.Size = New System.Drawing.Size(488, 144)
        Me.dgCurrent.TabIndex = 2
        '
        'oleDbSelectCommand1
        '
        Me.oleDbSelectCommand1.CommandText = "SELECT FLIGHTCODE, LeaveFrom, GoingTo, Depart, Arrive FROM tabFlights"
        Me.oleDbSelectCommand1.Connection = Me.dbConn
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
        'dvFlights
        '
        Me.dvFlights.AllowEdit = False
        Me.dvFlights.AllowNew = False
        '
        'dvRemoved
        '
        Me.dvRemoved.AllowDelete = False
        Me.dvRemoved.AllowEdit = False
        Me.dvRemoved.AllowNew = False
        '
        'daFlights
        '
        Me.daFlights.DeleteCommand = Me.oleDbDeleteCommand1
        Me.daFlights.InsertCommand = Me.oleDbInsertCommand1
        Me.daFlights.SelectCommand = Me.oleDbSelectCommand1
        Me.daFlights.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tabFlights", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("FLIGHTCODE", "FLIGHTCODE"), New System.Data.Common.DataColumnMapping("LeaveFrom", "LeaveFrom"), New System.Data.Common.DataColumnMapping("GoingTo", "GoingTo"), New System.Data.Common.DataColumnMapping("Depart", "Depart"), New System.Data.Common.DataColumnMapping("Arrive", "Arrive")})})
        Me.daFlights.UpdateCommand = Me.oleDbUpdateCommand1
        '
        'oleDbDeleteCommand1
        '
        Me.oleDbDeleteCommand1.CommandText = "DELETE FROM tabFlights WHERE (FLIGHTCODE = ?) AND (Arrive = ?) AND (Depart = ?) A" & _
        "ND (GoingTo = ?) AND (LeaveFrom = ?)"
        Me.oleDbDeleteCommand1.Connection = Me.dbConn
        Me.oleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("FLIGHTCODE", System.Data.OleDb.OleDbType.Char, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FLIGHTCODE", System.Data.DataRowVersion.Original, Nothing))
        Me.oleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Arrive", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Arrive", System.Data.DataRowVersion.Original, Nothing))
        Me.oleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Depart", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Depart", System.Data.DataRowVersion.Original, Nothing))
        Me.oleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("GoingTo", System.Data.OleDb.OleDbType.Char, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "GoingTo", System.Data.DataRowVersion.Original, Nothing))
        Me.oleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("LeaveFrom", System.Data.OleDb.OleDbType.Char, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LeaveFrom", System.Data.DataRowVersion.Original, Nothing))
        '
        'oleDbInsertCommand1
        '
        Me.oleDbInsertCommand1.CommandText = "INSERT INTO tabFlights(FLIGHTCODE, LeaveFrom, GoingTo, Depart, Arrive) VALUES (?," & _
        " ?, ?, ?, ?); SELECT FLIGHTCODE, LeaveFrom, GoingTo, Depart, Arrive FROM tabFlig" & _
        "hts WHERE (FLIGHTCODE = ?)"
        Me.oleDbInsertCommand1.Connection = Me.dbConn
        Me.oleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("FLIGHTCODE", System.Data.OleDb.OleDbType.Char, 5, "FLIGHTCODE"))
        Me.oleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("LeaveFrom", System.Data.OleDb.OleDbType.Char, 50, "LeaveFrom"))
        Me.oleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("GoingTo", System.Data.OleDb.OleDbType.Char, 50, "GoingTo"))
        Me.oleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Depart", System.Data.OleDb.OleDbType.Date, 0, "Depart"))
        Me.oleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Arrive", System.Data.OleDb.OleDbType.Date, 0, "Arrive"))
        Me.oleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Select_FLIGHTCODE", System.Data.OleDb.OleDbType.Char, 5, "FLIGHTCODE"))
        '
        'oleDbUpdateCommand1
        '
        Me.oleDbUpdateCommand1.CommandText = "UPDATE tabFlights SET FLIGHTCODE = ?, LeaveFrom = ?, GoingTo = ?, Depart = ?, Arr" & _
        "ive = ? WHERE (FLIGHTCODE = ?) AND (Arrive = ?) AND (Depart = ?) AND (GoingTo = " & _
        "?) AND (LeaveFrom = ?); SELECT FLIGHTCODE, LeaveFrom, GoingTo, Depart, Arrive FR" & _
        "OM tabFlights WHERE (FLIGHTCODE = ?)"
        Me.oleDbUpdateCommand1.Connection = Me.dbConn
        Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("FLIGHTCODE", System.Data.OleDb.OleDbType.Char, 5, "FLIGHTCODE"))
        Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("LeaveFrom", System.Data.OleDb.OleDbType.Char, 50, "LeaveFrom"))
        Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("GoingTo", System.Data.OleDb.OleDbType.Char, 50, "GoingTo"))
        Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Depart", System.Data.OleDb.OleDbType.Date, 0, "Depart"))
        Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Arrive", System.Data.OleDb.OleDbType.Date, 0, "Arrive"))
        Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_FLIGHTCODE", System.Data.OleDb.OleDbType.Char, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FLIGHTCODE", System.Data.DataRowVersion.Original, Nothing))
        Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Arrive", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Arrive", System.Data.DataRowVersion.Original, Nothing))
        Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Depart", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Depart", System.Data.DataRowVersion.Original, Nothing))
        Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_GoingTo", System.Data.OleDb.OleDbType.Char, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "GoingTo", System.Data.DataRowVersion.Original, Nothing))
        Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_LeaveFrom", System.Data.OleDb.OleDbType.Char, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LeaveFrom", System.Data.DataRowVersion.Original, Nothing))
        Me.oleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Select_FLIGHTCODE", System.Data.OleDb.OleDbType.Char, 5, "FLIGHTCODE"))
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(504, 317)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgRemoved, Me.dgCurrent})
        Me.Name = "Form1"
        Me.Text = "Example7"
        CType(Me.dgRemoved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCurrent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvFlights, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvRemoved, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dsFlights As New ds()
        daFlights.Fill(dsFlights)
        dvFlights.Table = dsFlights.tabFlights
        dvRemoved.Table = dsFlights.tabFlights
        dvRemoved.RowStateFilter = DataViewRowState.Deleted
        dgRemoved.DataSource = dvRemoved
    End Sub
End Class
