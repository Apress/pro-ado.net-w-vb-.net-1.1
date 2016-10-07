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
    Friend WithEvents button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button1.Location = New System.Drawing.Point(10, 8)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(240, 64)
        Me.button1.TabIndex = 1
        Me.button1.Text = "Update a record"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(260, 81)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Row Updating"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dbConn As New SqlConnection("server=(local)\NetSDK; database=pubs; integrated security=true")
    Dim WithEvents da As New SqlDataAdapter("SELECT au_id, au_lname, au_fname, phone FROM authors", dbConn)

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click

        Dim cb As New SqlCommandBuilder(da)
        Dim ds As New DataSet("Authors")

        da.Fill(ds)
        ds.Tables(0).Rows(0)("au_lname") = "Biggins"
        da.Update(ds.GetChanges())
    End Sub


    Private Sub da_RowUpdating(ByVal sender As Object, _
                               ByVal e As SqlRowUpdatingEventArgs) _
                               Handles da.RowUpdating

        ' Only perform processing if this is an UPDATE statement
        If (e.StatementType = StatementType.Update) Then

            ' Check that the original record is not changed
            Dim strSQL As String = "SELECT au_id, au_lname, au_fname, phone " & _
                                   "FROM authors WHERE "
            strSQL &= "au_id='" & e.Row("au_id", DataRowVersion.Original)
            strSQL &= "' AND "
            strSQL &= "au_lname='" & e.Row("au_lname", DataRowVersion.Original)
            strSQL &= "' AND "
            strSQL &= "au_fname='" & e.Row("au_fname", DataRowVersion.Original)
            strSQl &= "' AND "
            strSQL &= "phone='" & e.Row("phone", DataRowVersion.Original) & "'"

            ' Open the connection
            dbConn.Open()

            ' Create a command to retrieve the number of records affected
            Dim cmm As New SqlCommand(strSQL, dbConn)

            ' If the number of records retrieved is zero, the record has changed
            If (cmm.ExecuteNonQuery() = 0) Then
                ' Display the confirm message
                If (MessageBox.Show("The record you are attempting to modify has " & _
                                    "already changed by another user. Do you " & _
                                    "want to overwrite it?", "Update", _
                                    MessageBoxButtons.YesNo) = DialogResult.No) Then

                    ' Skip the update for the current row
                    e.Status = UpdateStatus.SkipCurrentRow
                End If
            End If

            ' Close the connection
            dbConn.Close()

        End If
    End Sub
End Class
