Imports System.Data.SqlClient

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
    Friend WithEvents dg As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dg = New System.Windows.Forms.DataGrid()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg
        '
        Me.dg.AlternatingBackColor = System.Drawing.Color.LightGray
        Me.dg.BackColor = System.Drawing.Color.DarkGray
        Me.dg.CaptionBackColor = System.Drawing.Color.White
        Me.dg.CaptionFont = New System.Drawing.Font("Verdana", 10.0!)
        Me.dg.CaptionForeColor = System.Drawing.Color.Navy
        Me.dg.CaptionText = "Authors"
        Me.dg.DataMember = ""
        Me.dg.ForeColor = System.Drawing.Color.Black
        Me.dg.GridLineColor = System.Drawing.Color.Black
        Me.dg.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.dg.HeaderBackColor = System.Drawing.Color.Silver
        Me.dg.HeaderForeColor = System.Drawing.Color.Black
        Me.dg.LinkColor = System.Drawing.Color.Navy
        Me.dg.Location = New System.Drawing.Point(9, 7)
        Me.dg.Name = "dg"
        Me.dg.ParentRowsBackColor = System.Drawing.Color.White
        Me.dg.ParentRowsForeColor = System.Drawing.Color.Black
        Me.dg.SelectionBackColor = System.Drawing.Color.Navy
        Me.dg.SelectionForeColor = System.Drawing.Color.White
        Me.dg.Size = New System.Drawing.Size(352, 440)
        Me.dg.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(370, 455)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dg})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Author Editor"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private da As SqlDataAdapter
    Private ds As DataSet

    Private Sub Form1_Load(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles MyBase.Load
        ' Create a Connection object
        Dim dbConn As New SqlConnection("server=(local); database=pubs; integrated security=true")

        ' Create the data adapter object pointing to the authors table
        da = New SqlDataAdapter( _
              "SELECT au_id, au_lname, au_fname, phone FROM authors", dbConn)

        ' Fill the DataSet
        ds = New DataSet("Authors")
        da.Fill(ds)

        ' Display the records in a DataGrid component
        dg.DataSource = ds.Tables(0)
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, _
      ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ' Message box to prompt the save request
        If (MessageBox.Show("Do you want save the changes?", _
                            "Update", _
                            MessageBoxButtons.YesNo) = DialogResult.Yes) Then
            Try

                ' Create the insert, delete and update statements automatically
                Dim cb As New SqlCommandBuilder(da)

                ' Retrieve just the changed rows
                Dim dsChanges As DataSet = ds.GetChanges()

                If Not dsChanges Is Nothing Then

                    ' Update the database
                    da.Update(dsChanges)

                    ' Accept the changes within the DataSet
                    ds.AcceptChanges()
                End If
            Catch ex As Exception

                ' Error occurs, show the message
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class