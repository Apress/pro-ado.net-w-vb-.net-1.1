Imports System.Data.SqlClient

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
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtAuthor As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(314, 72)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 23)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(50, 72)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(40, 23)
        Me.btnNext.TabIndex = 9
        Me.btnNext.Text = ">"
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(10, 72)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(40, 23)
        Me.btnPrev.TabIndex = 8
        Me.btnPrev.Text = "<"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(10, 40)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(40, 23)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Title"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(50, 40)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(344, 20)
        Me.txtTitle.TabIndex = 5
        Me.txtTitle.Text = ""
        '
        'txtAuthor
        '
        Me.txtAuthor.Location = New System.Drawing.Point(50, 8)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(344, 20)
        Me.txtAuthor.TabIndex = 6
        Me.txtAuthor.Text = ""
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(10, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(40, 23)
        Me.label1.TabIndex = 4
        Me.label1.Text = "Author"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(404, 102)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExit, Me.btnNext, Me.btnPrev, Me.label2, Me.txtTitle, Me.txtAuthor, Me.label1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DataSet_FewRecords"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private da As SqlDataAdapter
    Private iCurr As Integer = 0
    Private iMax As Integer = 0

    Private Sub frmMain_Load(ByVal sender As System.Object, _
                 ByVal e As System.EventArgs) Handles MyBase.Load

        ' Create a connection object
        Dim dbConn As New SqlConnection( _
                   "server=(local); database=pubs; integrated security=true")

        Try

            ' Retrieve maximum number of records
            dbConn.Open()
            Dim cmd = New SqlCommand("SELECT COUNT(authors.au_fname) " & _
                     "FROM (authors INNER JOIN titleauthor ON " & _
                     "authors.au_id = titleauthor.au_id) INNER JOIN " & _
                     "titles ON titleauthor.title_id = titles.title_id", dbConn)
            iMax = CInt(cmd.ExecuteScalar()) - 1
        Finally
            dbConn.Close()
        End Try

        ' Create the data adapter object pointing to the authors table
        da = New SqlDataAdapter("SELECT authors.au_fname, " & _
                   "authors.au_lname, titles.title FROM " & _
                   "(authors INNER JOIN titleauthor ON " & _
                   "authors.au_id = titleauthor.au_id) INNER JOIN " & _
                   "titles ON titleauthor.title_id = titles.title_id", dbConn)

        Dim ds As New DataSet("Authors")

        ' Fill the DataSet
        da.Fill(ds, iCurr, 1, "AuthorAndTitle")

        FillForm(ds)

    End Sub

    Sub FillForm(ByVal ds As DataSet)
        txtAuthor.Text = ds.Tables("AuthorAndTitle").Rows(0)("au_fname") & _
                         " " & ds.Tables("AuthorAndTitle").Rows(0)("au_lname")
        txtTitle.Text = ds.Tables("AuthorAndTitle").Rows(0)("title").ToString()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, _
                           ByVal e As System.EventArgs) Handles btnNext.Click
        If iCurr < iMax Then
            Dim ds As New DataSet("Authors")

            iCurr = iCurr + 1

            ' Fill the DataSet
            da.Fill(ds, iCurr, 1, "AuthorAndTitle")

            FillForm(ds)
        End If
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, _
                           ByVal e As System.EventArgs) Handles btnPrev.Click
        If iCurr > 0 Then
            Dim ds As New DataSet("Authors")

            iCurr = iCurr - 1

            ' Fill the DataSet
            da.Fill(ds, iCurr, 1, "AuthorAndTitle")

            FillForm(ds)
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class