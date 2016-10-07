Public Class frmMain
   Inherits System.Windows.Forms.Form

    Private Books As BookDataSet

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Books = New BookDataSet()
        Books.ReadXml("../Books.xml")
        dgBooks.DataSource = Books.Books
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
    Friend WithEvents dgBooks As System.Windows.Forms.DataGrid
    Friend WithEvents btnSumScores As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgBooks = New System.Windows.Forms.DataGrid()
        Me.btnSumScores = New System.Windows.Forms.Button()
        CType(Me.dgBooks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgBooks
        '
        Me.dgBooks.DataMember = ""
        Me.dgBooks.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgBooks.Location = New System.Drawing.Point(8, 8)
        Me.dgBooks.Name = "dgBooks"
        Me.dgBooks.Size = New System.Drawing.Size(616, 328)
        Me.dgBooks.TabIndex = 0
        '
        'btnSumScores
        '
        Me.btnSumScores.Location = New System.Drawing.Point(272, 344)
        Me.btnSumScores.Name = "btnSumScores"
        Me.btnSumScores.TabIndex = 1
        Me.btnSumScores.Text = "Sum Scores"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(632, 373)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSumScores, Me.dgBooks})
        Me.Name = "frmMain"
        Me.Text = "Annotated Typed Dataset Binding Example"
        CType(Me.dgBooks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

   Private Sub btnSumScores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSumScores.Click
      Dim sum As Integer = 0

      Dim Book As BookDataSet.Book
        For Each Book In Books.Books
            Dim Review As BookDataSet.BookReview
            For Each Review In Book.Reviews()
                sum += CType(Review.Rating, Integer)
            Next
        Next
        MessageBox.Show(Me, "Score Total: " + sum.ToString())
   End Sub
End Class