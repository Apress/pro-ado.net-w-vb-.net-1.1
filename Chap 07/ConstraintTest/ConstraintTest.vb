Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace ConstraintTest
    Class Class1
        Public Shared Sub Main()

            Dim cnn As New SqlConnection("server=(local);database=pubs;uid=sa;pwd=;")
            Dim da As New SqlDataAdapter("SELECT * FROM authors", cnn)
            Dim ds As New DataSet()
            da.Fill(ds, "Authors")
            Console.WriteLine("Creating Constraint")

            ' Create a new instance of our constraint, passing the phone column
            ' as the one to be constrained, and a name for our constraint
            Dim phoneConstraint As New USPhoneNumberConstraint( _
                          "phoneConstraint", ds.Tables("Authors").Columns("phone"))

            Console.WriteLine("Changing number to incorrect format")
            Try
                ds.Tables("Authors").Rows(0).BeginEdit()
                ds.Tables("Authors").Rows(0)("Phone") = "(123) 222-4568"
                ds.Tables("Authors").Rows(0).EndEdit()
            Catch e As ConstraintException
                Console.WriteLine("Constraint exception encountered")
                Console.WriteLine(e.ToString())
            End Try
        End Sub
    End Class
End Namespace