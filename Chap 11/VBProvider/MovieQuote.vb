Public Class MovieQuote

    Public Quote As String
    Public ActorOrCharacter As String
    Public Movie As String

    Public Sub New()
        Dim ds As New MovieQuotesDataSet()
        'Create a random number to select one of the quotes
        Dim randNumber As New Random()
        'The random number should be between 0 and 
        'the number of rows in the table
        Dim randomRow As Int32 = _
            randNumber.Next(0, ds.Tables(0).Rows.Count)
        'Set the MovieQuote properties using the
        'RandomRow as the DataRow index value
        Dim dr As DataRow = ds.Tables(0).Rows(randomRow)
        Quote = dr.Item("Quote").ToString()
        ActorOrCharacter = dr.Item("ActorOrCharacter").ToString()
        Movie = dr.Item("Movie").ToString()
    End Sub

End Class
