Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

Module SerializeSample

   Sub Main()
      Dim Connection As SqlConnection = New SqlConnection( _
        "Server=(local); Initial Catalog=Northwind; " _
        & "Integrated Security=SSPI;")
      Dim MyDA As SqlDataAdapter = New SqlDataAdapter( _
         "SELECT * FROM Customers", Connection)
      Dim MyDS As DataSet = New DataSet()
      Dim MyDS2 As DataSet = New DataSet()
      MyDA.Fill(MyDS, "Customers")

      Dim s As Stream = File.Open("MyDS.soap", _
         FileMode.Create, FileAccess.ReadWrite)
      Dim sf As SoapFormatter = New SoapFormatter()
      sf.Serialize(s, MyDS)
      s.Close()

      Console.WriteLine("Serialization Complete.")
      Console.WriteLine("De-Serializing Graph from SOAP Envelope...")
      Dim r As Stream = File.Open("MyDS.soap", _
         FileMode.Open, FileAccess.Read)
      Dim sf2 As SoapFormatter = New SoapFormatter()
      MyDS2 = CType(sf2.Deserialize(r), DataSet)
      r.Close()

      Console.WriteLine( _
         "After Deserialization, MyDS2 contains {0} Customers", _
         MyDS2.Tables("Customers").Rows.Count)

      Console.WriteLine("Serializing DataSet into an XML DOM...")
      Dim xStream As Stream = File.Open("MyDS2.xml", _
         FileMode.Create, FileAccess.ReadWrite)
      Dim xs As XmlSerializer = New XmlSerializer(GetType(DataSet))
      xs.Serialize(xStream, MyDS2)
      xStream.Close()

      Console.WriteLine("Now Serializing to Binary Format...")
      Dim bs As Stream = File.Open("MyDS2.bin", _
         FileMode.Create, FileAccess.ReadWrite)
      Dim bf As BinaryFormatter = New BinaryFormatter()
      bf.Serialize(bs, MyDS2)
      bs.Close()
   End Sub

End Module
