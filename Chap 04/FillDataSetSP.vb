Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Module Module1
    Sub Main()

        ' Create a connection object
        Dim dbConn As New SqlConnection( _
                       "server=(local); database=pubs; integrated security=true")
        Dim cmd As New SqlCommand()

        cmd.CommandText = "spRetrieveAuthor"
        cmd.CommandType = System.Data.CommandType.StoredProcedure
        cmd.Connection = dbConn
        cmd.Parameters.Add(New SqlParameter("@au_id", SqlDbType.Char, 11, "au_id"))

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet("Author")
        da.SelectCommand.Parameters(0).Value = "172-32-1176"
        da.Fill(ds)

        If Not ds Is Nothing Then
            MessageBox.Show("Hi, author: " & _
                                   ds.Tables(0).Rows(0)("au_lname").ToString())
        End If


    End Sub
End Module