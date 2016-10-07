Imports System
Imports System.Data

Module TypedSetDemo
    Sub Main()
        Dim myDS As New BookDataSet()
        myDS.ReadXml("Books.xml")

        Console.WriteLine("Relations Found:")
        Dim xRelation As DataRelation
        For Each xRelation In myDS.Relations
            Console.WriteLine(xRelation.RelationName)
        Next

        Console.WriteLine("Apress Books and Reviews")
        Console.WriteLine("----------------------")

        Dim Book As BookDataSet.BooksRow
        For Each Book In myDS.Books.Rows
            Console.WriteLine(Book.Title)

            Dim Review As BookDataSet.BookReviewsRow
            For Each Review In Book.GetBookReviewsRows()
                Console.WriteLine("  {0}", Review.Rating)
            Next
        Next
    End Sub
End Module