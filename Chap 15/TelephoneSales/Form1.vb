Imports Apress.ProADONET.OQProvider

Public Class Form1
   Inherits System.Windows.Forms.Form

   Private myConnection As OQConnection = New OQConnection()
   Private myDA As OQDataAdapter = New OQDataAdapter()
   Private SendCmd As OQCommand = New OQCommand()
   Private myDS As DataSet = New DataSet()

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
   Friend WithEvents button2 As System.Windows.Forms.Button
   Friend WithEvents button1 As System.Windows.Forms.Button
   Friend WithEvents dgItems As System.Windows.Forms.DataGrid
   Friend WithEvents cboShipMethod As System.Windows.Forms.ComboBox
   Friend WithEvents label7 As System.Windows.Forms.Label
   Friend WithEvents gbShipTo As System.Windows.Forms.GroupBox
   Friend WithEvents txtShipToCountry As System.Windows.Forms.TextBox
   Friend WithEvents label6 As System.Windows.Forms.Label
   Friend WithEvents txtShipToZip As System.Windows.Forms.TextBox
   Friend WithEvents label5 As System.Windows.Forms.Label
   Friend WithEvents txtShipToState As System.Windows.Forms.TextBox
   Friend WithEvents label4 As System.Windows.Forms.Label
   Friend WithEvents txtShipToCity As System.Windows.Forms.TextBox
   Friend WithEvents label3 As System.Windows.Forms.Label
   Friend WithEvents txtShipToAddr2 As System.Windows.Forms.TextBox
   Friend WithEvents txtShipToAddr1 As System.Windows.Forms.TextBox
   Friend WithEvents label2 As System.Windows.Forms.Label
   Friend WithEvents txtCustomerID As System.Windows.Forms.TextBox
   Friend WithEvents label1 As System.Windows.Forms.Label
   Friend WithEvents txtOrderID As System.Windows.Forms.TextBox
   Friend WithEvents label8 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.button2 = New System.Windows.Forms.Button()
      Me.button1 = New System.Windows.Forms.Button()
      Me.dgItems = New System.Windows.Forms.DataGrid()
      Me.cboShipMethod = New System.Windows.Forms.ComboBox()
      Me.label7 = New System.Windows.Forms.Label()
      Me.gbShipTo = New System.Windows.Forms.GroupBox()
      Me.txtShipToCountry = New System.Windows.Forms.TextBox()
      Me.label6 = New System.Windows.Forms.Label()
      Me.txtShipToZip = New System.Windows.Forms.TextBox()
      Me.label5 = New System.Windows.Forms.Label()
      Me.txtShipToState = New System.Windows.Forms.TextBox()
      Me.label4 = New System.Windows.Forms.Label()
      Me.txtShipToCity = New System.Windows.Forms.TextBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me.txtShipToAddr2 = New System.Windows.Forms.TextBox()
      Me.txtShipToAddr1 = New System.Windows.Forms.TextBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me.txtCustomerID = New System.Windows.Forms.TextBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me.txtOrderID = New System.Windows.Forms.TextBox()
      Me.label8 = New System.Windows.Forms.Label()
      CType(Me.dgItems, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.gbShipTo.SuspendLayout()
      Me.SuspendLayout()
      '
      'button2
      '
      Me.button2.Location = New System.Drawing.Point(8, 280)
      Me.button2.Name = "button2"
      Me.button2.Size = New System.Drawing.Size(96, 32)
      Me.button2.TabIndex = 21
      Me.button2.Text = "Open Order"
      '
      'button1
      '
      Me.button1.Location = New System.Drawing.Point(336, 280)
      Me.button1.Name = "button1"
      Me.button1.Size = New System.Drawing.Size(120, 32)
      Me.button1.TabIndex = 18
      Me.button1.Text = "Send Order"
      '
      'dgItems
      '
      Me.dgItems.CaptionText = "Order Items"
      Me.dgItems.DataMember = ""
      Me.dgItems.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.dgItems.Location = New System.Drawing.Point(8, 152)
      Me.dgItems.Name = "dgItems"
      Me.dgItems.Size = New System.Drawing.Size(448, 120)
      Me.dgItems.TabIndex = 17
      '
      'cboShipMethod
      '
      Me.cboShipMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboShipMethod.DropDownWidth = 104
      Me.cboShipMethod.Items.AddRange(New Object() {"USPS Priority", "USPS Standard", "FedEx"})
      Me.cboShipMethod.Location = New System.Drawing.Point(8, 80)
      Me.cboShipMethod.Name = "cboShipMethod"
      Me.cboShipMethod.Size = New System.Drawing.Size(104, 21)
      Me.cboShipMethod.TabIndex = 16
      '
      'label7
      '
      Me.label7.AutoSize = True
      Me.label7.Location = New System.Drawing.Point(8, 64)
      Me.label7.Name = "label7"
      Me.label7.Size = New System.Drawing.Size(68, 13)
      Me.label7.TabIndex = 15
      Me.label7.Text = "Ship Method"
      '
      'gbShipTo
      '
      Me.gbShipTo.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtShipToCountry, Me.label6, Me.txtShipToZip, Me.label5, Me.txtShipToState, Me.label4, Me.txtShipToCity, Me.label3, Me.txtShipToAddr2, Me.txtShipToAddr1, Me.label2})
      Me.gbShipTo.Location = New System.Drawing.Point(120, 8)
      Me.gbShipTo.Name = "gbShipTo"
      Me.gbShipTo.Size = New System.Drawing.Size(336, 136)
      Me.gbShipTo.TabIndex = 14
      Me.gbShipTo.TabStop = False
      Me.gbShipTo.Text = " Ship To (Leave Blank if to Customer's Address"
      '
      'txtShipToCountry
      '
      Me.txtShipToCountry.Location = New System.Drawing.Point(232, 104)
      Me.txtShipToCountry.Name = "txtShipToCountry"
      Me.txtShipToCountry.Size = New System.Drawing.Size(48, 20)
      Me.txtShipToCountry.TabIndex = 9
      Me.txtShipToCountry.Text = ""
      '
      'label6
      '
      Me.label6.AutoSize = True
      Me.label6.Location = New System.Drawing.Point(232, 88)
      Me.label6.Name = "label6"
      Me.label6.Size = New System.Drawing.Size(44, 13)
      Me.label6.TabIndex = 8
      Me.label6.Text = "Country"
      '
      'txtShipToZip
      '
      Me.txtShipToZip.Location = New System.Drawing.Point(168, 104)
      Me.txtShipToZip.Name = "txtShipToZip"
      Me.txtShipToZip.Size = New System.Drawing.Size(56, 20)
      Me.txtShipToZip.TabIndex = 7
      Me.txtShipToZip.Text = ""
      '
      'label5
      '
      Me.label5.AutoSize = True
      Me.label5.Location = New System.Drawing.Point(168, 88)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(20, 13)
      Me.label5.TabIndex = 6
      Me.label5.Text = "Zip"
      '
      'txtShipToState
      '
      Me.txtShipToState.Location = New System.Drawing.Point(128, 104)
      Me.txtShipToState.MaxLength = 2
      Me.txtShipToState.Name = "txtShipToState"
      Me.txtShipToState.Size = New System.Drawing.Size(24, 20)
      Me.txtShipToState.TabIndex = 5
      Me.txtShipToState.Text = ""
      '
      'label4
      '
      Me.label4.AutoSize = True
      Me.label4.Location = New System.Drawing.Point(128, 88)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(31, 13)
      Me.label4.TabIndex = 4
      Me.label4.Text = "State"
      '
      'txtShipToCity
      '
      Me.txtShipToCity.Location = New System.Drawing.Point(8, 104)
      Me.txtShipToCity.Name = "txtShipToCity"
      Me.txtShipToCity.TabIndex = 3
      Me.txtShipToCity.Text = ""
      '
      'label3
      '
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(8, 88)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(24, 13)
      Me.label3.TabIndex = 2
      Me.label3.Text = "City"
      '
      'txtShipToAddr2
      '
      Me.txtShipToAddr2.Location = New System.Drawing.Point(56, 56)
      Me.txtShipToAddr2.Name = "txtShipToAddr2"
      Me.txtShipToAddr2.Size = New System.Drawing.Size(272, 20)
      Me.txtShipToAddr2.TabIndex = 1
      Me.txtShipToAddr2.Text = ""
      '
      'txtShipToAddr1
      '
      Me.txtShipToAddr1.Location = New System.Drawing.Point(56, 24)
      Me.txtShipToAddr1.Name = "txtShipToAddr1"
      Me.txtShipToAddr1.Size = New System.Drawing.Size(272, 20)
      Me.txtShipToAddr1.TabIndex = 1
      Me.txtShipToAddr1.Text = ""
      '
      'label2
      '
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(8, 24)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(49, 13)
      Me.label2.TabIndex = 0
      Me.label2.Text = "Address:"
      '
      'txtCustomerID
      '
      Me.txtCustomerID.Location = New System.Drawing.Point(8, 32)
      Me.txtCustomerID.Name = "txtCustomerID"
      Me.txtCustomerID.Size = New System.Drawing.Size(104, 20)
      Me.txtCustomerID.TabIndex = 13
      Me.txtCustomerID.Text = ""
      '
      'label1
      '
      Me.label1.Location = New System.Drawing.Point(8, 16)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(72, 16)
      Me.label1.TabIndex = 12
      Me.label1.Text = "Customer ID:"
      '
      'txtOrderID
      '
      Me.txtOrderID.Location = New System.Drawing.Point(8, 120)
      Me.txtOrderID.Name = "txtOrderID"
      Me.txtOrderID.Size = New System.Drawing.Size(80, 20)
      Me.txtOrderID.TabIndex = 20
      Me.txtOrderID.Text = ""
      '
      'label8
      '
      Me.label8.AutoSize = True
      Me.label8.Location = New System.Drawing.Point(8, 104)
      Me.label8.Name = "label8"
      Me.label8.Size = New System.Drawing.Size(51, 13)
      Me.label8.TabIndex = 19
      Me.label8.Text = "Order ID:"
      '
      'Form1
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(464, 317)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button2, Me.button1, Me.dgItems, Me.cboShipMethod, Me.label7, Me.gbShipTo, Me.txtCustomerID, Me.label1, Me.txtOrderID, Me.label8})
      Me.Name = "Form1"
      Me.Text = "Distributed OE - Telephone Call Center"
      CType(Me.dgItems, System.ComponentModel.ISupportInitialize).EndInit()
      Me.gbShipTo.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub ClearOrder()
      Dim Order As DataRow = myDS.Tables("Orders").NewRow()

      Order("CustomerID") = "NEWCUST"
      Order("OrderID") = "NEWORDER"
      Order("ShipToAddr1") = ""
      Order("ShipToAddr2") = ""
      Order("ShipToCity") = ""
      Order("ShipToState") = ""
      Order("ShipToZip") = ""
      Order("ShipToCountry") = ""
      Order("ShipMethod") = ""
      myDS.Tables("Orders").Rows.Clear()
      myDS.Tables("Orders").Rows.Add(Order)
      myDS.Tables("OrderItems").Rows.Clear()

      button1.Enabled = True
   End Sub

   Private Sub Form1_Load(ByVal sender As System.Object, _
         ByVal e As System.EventArgs) Handles MyBase.Load
      myConnection.ConnectionString = ".\Private$\OQTester"
      myConnection.Open()
      SendCmd.Connection = myConnection
      SendCmd.CommandText = "Send"
      myDA.SendCommand = SendCmd

      myDA.FillSchema(myDS, SchemaType.Mapped)
      dgItems.DataSource = myDS.Tables("OrderItems")

      txtCustomerID.DataBindings.Add( _
         New Binding("Text", myDS.Tables("Orders"), "CustomerID"))
      txtOrderID.DataBindings.Add( _
         New Binding("Text", myDS.Tables("Orders"), "OrderID"))
      txtShipToAddr1.DataBindings.Add( _
         New Binding("Text", myDS.Tables("Orders"), "ShipToAddr1"))
      txtShipToAddr2.DataBindings.Add( _
         New Binding("Text", myDS.Tables("Orders"), "ShipToAddr2"))
      txtShipToCity.DataBindings.Add( _
         New Binding("Text", myDS.Tables("Orders"), "ShipToCity"))
      txtShipToState.DataBindings.Add( _
         New Binding("Text", myDS.Tables("Orders"), "ShipToState"))
      txtShipToCountry.DataBindings.Add( _
         New Binding("Text", myDS.Tables("Orders"), "ShipToCountry"))
      cboShipMethod.DataBindings.Add( _
         New Binding("Text", myDS.Tables("Orders"), "ShipMethod"))

      button1.Enabled = False
   End Sub

   Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
      myDA.Update(myDS)
      ClearOrder()
      button1.Enabled = False
      MessageBox.Show(Me, "Order Transmitted.")
   End Sub

   Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
      ClearOrder()
   End Sub
End Class
