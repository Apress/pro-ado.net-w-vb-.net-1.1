Imports System.Xml.Serialization

Public Class MovieQuoteWithAttributes
    <XmlAttributeAttribute()> Public Quote As String
    <XmlAttributeAttribute()> Public ActorOrCharacter As String
    <XmlAttributeAttribute()> Public Movie As String

    Public Sub New()
        Dim mq As New MovieQuote()
        Quote = mq.Quote
        ActorOrCharacter = mq.ActorOrCharacter
        Movie = mq.Movie
    End Sub

End Class

' Movie
' An object that has elements and attributes.
Public Class Movie
    <XmlTextAttribute()> Public Title As String
    <XmlAttributeAttribute()> Public Quote As String
    <XmlAttributeAttribute()> Public ActorOrCharacter As String

    Public Sub New()
        Dim mq As New MovieQuote()
        Quote = mq.Quote
        ActorOrCharacter = mq.ActorOrCharacter
        Title = mq.Movie
    End Sub
End Class

' Quote
' Only the quote element of a Movie object.
Public Class Quote
    <XmlTextAttribute()> Public MovieQuote As String
    <XmlAttributeAttribute()> Public ActorOrCharacter As String
End Class


' ComplexMovie
' An object with an attribute, and an element that also has an attribute.
Public Class ComplexMovie
    <XmlElementAttribute(ElementName:="Quote")> _
    Public MovieQuote As Quote
    <XmlAttributeAttribute()> _
    Public Movie As String

    Public Sub New()
        Dim mq As New MovieQuote()
        Dim q As New Quote()
        q.MovieQuote = mq.Quote
        q.ActorOrCharacter = mq.ActorOrCharacter
        MovieQuote = q
        Movie = mq.Movie
    End Sub
End Class