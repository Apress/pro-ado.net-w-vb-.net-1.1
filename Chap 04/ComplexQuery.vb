Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Sub Main()

        ' Create a connection object
        Dim dbConn As New SqlConnection( _
                       "server=(local); database=pubs; integrated security=true")
        Dim ds As New DataSet("AuthorsAndTitles")

        ' Create the data adapter object pointing to the authors table
        Dim daAuthors As New SqlDataAdapter( _
                       "SELECT au_id, au_fname, au_lname FROM authors", dbConn)

        ' Fill the DataSet with author
        daAuthors.Fill(ds, "Author")

        ' Create the data adapter object pointing to the titleauthor table
        Dim daTitleAuthor As New SqlDataAdapter( _
                       "SELECT au_id, title_id FROM titleauthor", dbConn)

        ' Fill the DataSet with titleauthor
        daTitleAuthor.Fill(ds, "TitleAuthor")

        ' Create the data adapter object pointing to the titles table
        Dim daTitle As New SqlDataAdapter( _
                       "SELECT title_id, title FROM titles", dbConn)

        ' Fill the DataSet with titles
        daTitle.Fill(ds, "Titles")

        ' Define a primary key and other properties for each table
        ds.Tables("Titles").Columns("title_id").Unique = True
        ds.Tables("Titles").Columns("title_id").AllowDBNull = False
        ds.Tables("Titles").PrimaryKey = _
                  New DataColumn() {ds.Tables("Titles").Columns("title_id")}

        ds.Tables("Author").Columns("au_id").Unique = True
        ds.Tables("Author").Columns("au_id").AllowDBNull = False
        ds.Tables("Author").PrimaryKey = _
                  New DataColumn() {ds.Tables("Author").Columns("au_id")}

        ds.Tables("TitleAuthor").PrimaryKey = _
                  New DataColumn() {ds.Tables("TitleAuthor").Columns("au_id"), _
                                    ds.Tables("TitleAuthor").Columns("title_id")}

        ' Define constraints (primary-foreign key relationships)
        Dim fk1 As New ForeignKeyConstraint("authorstitleauthor", _
                                    ds.Tables("Author").Columns("au_id"), _
                                    ds.Tables("TitleAuthor").Columns("au_id"))
        ds.Tables("TitleAuthor").Constraints.Add(fk1)

        Dim fk2 As New ForeignKeyConstraint("titlestitleauthor", _
                                    ds.Tables("Titles").Columns("title_id"), _
                                    ds.Tables("TitleAuthor").Columns("title_id"))
        ds.Tables("TitleAuthor").Constraints.Add(fk2)

        ' Write the related XML document representing the DataSet
        ds.WriteXml("c:\join.xml", XmlWriteMode.WriteSchema)
    End Sub
End Module