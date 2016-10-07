Imports Apress.ProADONET.OQProvider

Public Class frmMain
   Inherits System.Windows.Forms.Form

   Private myDS As DataSet

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
   Friend WithEvents dgOrders As System.Windows.Forms.DataGrid
   Friend WithEvents button1 As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.dgOrders = New System.Windows.Forms.DataGrid()
      Me.button1 = New System.Windows.Forms.Button()
      CType(Me.dgOrders, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'dgOrders
      '
      Me.dgOrders.AlternatingBackColor = System.Drawing.Color.White
      Me.dgOrders.BackColor = System.Drawing.Color.White
      Me.dgOrders.BackgroundColor = System.Drawing.Color.Ivory
      Me.dgOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.dgOrders.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
      Me.dgOrders.CaptionForeColor = System.Drawing.Color.Lavender
      Me.dgOrders.CaptionText = "Today's Orders"
      Me.dgOrders.DataMember = ""
      Me.dgOrders.FlatMode = True
      Me.dgOrders.Font = New System.Drawing.Font("Tahoma", 8.0!)
      Me.dgOrders.ForeColor = System.Drawing.Color.Black
      Me.dgOrders.GridLineColor = System.Drawing.Color.Wheat
      Me.dgOrders.HeaderBackColor = System.Drawing.Color.CadetBlue
      Me.dgOrders.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
      Me.dgOrders.HeaderForeColor = System.Drawing.Color.Black
      Me.dgOrders.LinkColor = System.Drawing.Color.DarkSlateBlue
      Me.dgOrders.Location = New System.Drawing.Point(8, 8)
      Me.dgOrders.Name = "dgOrders"
      Me.dgOrders.ParentRowsBackColor = System.Drawing.Color.Ivory
      Me.dgOrders.ParentRowsForeColor = System.Drawing.Color.Black
      Me.dgOrders.SelectionBackColor = System.Drawing.Color.Wheat
      Me.dgOrders.SelectionForeColor = System.Drawing.Color.DarkSlateBlue
      Me.dgOrders.Size = New System.Drawing.Size(392, 224)
      Me.dgOrders.TabIndex = 1
      '
      'button1
      '
      Me.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.button1.Location = New System.Drawing.Point(272, 240)
      Me.button1.Name = "button1"
      Me.button1.Size = New System.Drawing.Size(128, 24)
      Me.button1.TabIndex = 2
      Me.button1.Text = "Post Orders"
      '
      'frmMain
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(408, 269)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.dgOrders})
      Me.Name = "frmMain"
      Me.Text = "Distrubted OE Sample - Retail Interface"
      CType(Me.dgOrders, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      myDS = New DataSet()
      Dim oqDA As OQDataAdapter = New OQDataAdapter()
      oqDA.FillSchema(myDS, SchemaType.Mapped)
      oqDA = Nothing
      dgOrders.DataSource = myDS.Tables("Orders")
   End Sub

   Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
      Dim myConnection As OQConnection = New OQConnection()
      myConnection.ConnectionString = ".\Private$\OQTester"
      myConnection.Open()
      Dim oqDA As OQDataAdapter = New OQDataAdapter()
      Dim SendCmd As OQCommand = New OQCommand()
      SendCmd.CommandText = "Send"
      SendCmd.Connection = myConnection
      oqDA.SendCommand = SendCmd
      oqDA.Update(myDS)
      myConnection.Close()
      MessageBox.Show(Me, "Orders Transmitted.")
   End Sub
End Class
