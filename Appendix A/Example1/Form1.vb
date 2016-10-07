Imports Microsoft.Win32
Imports System.Data.OleDb

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
    Friend WithEvents button1 As System.Windows.Forms.Button
    Friend WithEvents sb As System.Windows.Forms.StatusBar
    Friend WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.sb = New System.Windows.Forms.StatusBar()
        Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button1.Location = New System.Drawing.Point(10, 8)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(272, 232)
        Me.button1.TabIndex = 2
        Me.button1.Text = "Retrieve data"
        '
        'sb
        '
        Me.sb.Location = New System.Drawing.Point(0, 253)
        Me.sb.Name = "sb"
        Me.sb.Size = New System.Drawing.Size(292, 20)
        Me.sb.TabIndex = 3
        Me.sb.Text = "Ready"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.sb, Me.button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WROX")
        OleDbConnection1.ConnectionString = key.GetValue("ConnectionString").ToString()
    End Sub


    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        Dim da As New OleDbDataAdapter("SELECT ID FROM tabUsers", OleDbConnection1)
        Dim ds As New DataSet("ds")
        da.Fill(ds)
    End Sub

    Private Sub OleDbConnection1_StateChange(ByVal sender As Object, ByVal e As System.Data.StateChangeEventArgs) Handles OleDbConnection1.StateChange
        Dim strMessage As String
        strMessage = "Connection state changed from " & e.OriginalState.ToString() & " to " & e.CurrentState.ToString()
        sb.Text = strMessage
    End Sub
End Class
