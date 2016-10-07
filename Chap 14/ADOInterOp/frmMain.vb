Public Class frmMain
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
   Friend WithEvents lbCustomers As System.Windows.Forms.ListBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lbCustomers = New System.Windows.Forms.ListBox()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(8, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(128, 23)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Northwind Customers:"
      '
      'lbCustomers
      '
      Me.lbCustomers.Location = New System.Drawing.Point(8, 32)
      Me.lbCustomers.Name = "lbCustomers"
      Me.lbCustomers.Size = New System.Drawing.Size(280, 238)
      Me.lbCustomers.TabIndex = 1
      '
      'frmMain
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(292, 273)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lbCustomers, Me.Label1})
      Me.Name = "frmMain"
      Me.Text = "ADO InterOp Example"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub frmMain_Load(ByVal sender As System.Object, _
                 ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Connection As ADODB.Connection = New ADODB.Connection()
        Connection.Open("DRIVER={SQL Server};SERVER=sahilmalik;" _
                       & "DATABASE=Northwind;", "sa", "sa", 0)
        Dim RS As ADODB.Recordset = New ADODB.Recordset()
        RS.Open("SELECT * FROM Customers", _
                 Connection, _
                 ADODB.CursorTypeEnum.adOpenDynamic, _
                 ADODB.LockTypeEnum.adLockReadOnly, 0)
        While Not RS.EOF
            lbCustomers.Items.Add(RS.Fields("ContactName").Value _
                        & " From " & RS.Fields("CompanyName").Value)
            RS.MoveNext()
        End While
        RS.Close()
        Connection.Close()
   End Sub
End Class
