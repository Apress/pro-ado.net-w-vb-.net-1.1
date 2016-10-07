Imports System.IO

Public Class MovieQuotesDataSet
    Inherits System.Data.DataSet

    Public Sub New()
        'Open a FileStream to stream in the XML file
        Dim fs As New FileStream( _
          HttpContext.Current.Server.MapPath( _
          "MovieQuotes.xml"), _
          FileMode.Open, FileAccess.Read)
        Dim xmlStream As New StreamReader(fs)
        'Use the ReadXml() method to create a 
        'DataTable that represents the XML data
        MyBase.ReadXml(xmlStream)

    End Sub

End Class
