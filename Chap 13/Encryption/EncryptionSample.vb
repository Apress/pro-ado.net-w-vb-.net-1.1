Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security
Imports System.Security.Cryptography
Imports System.IO
Imports System.Xml

Module EncryptionSample

    Sub Main()
        Dim fs As FileStream = New FileStream("DSencrypted.dat", _
           FileMode.Create, FileAccess.Write)
        Dim MyDS As DataSet = New DataSet()
        Dim MyDS2 As DataSet = New DataSet()
        Dim Connection As SqlConnection = New SqlConnection( _
           "Initial Catalog=Northwind;Integrated Security=SSPI;" _
           & "Server=(local);")
        Connection.Open()
        Dim MyDA As SqlDataAdapter = New SqlDataAdapter( _
           "SELECT * FROM Customers", Connection)
        MyDA.Fill(MyDS, "Customers")

        Dim DES As DESCryptoServiceProvider = _
           New DESCryptoServiceProvider()

        Dim DESencrypter As ICryptoTransform = _
           DES.CreateEncryptor()
        Dim cryptStream As CryptoStream = _
           New CryptoStream(fs, DESencrypter, CryptoStreamMode.Write)

        MyDS.WriteXml(cryptStream, XmlWriteMode.WriteSchema)
        cryptStream.Close()

        Dim fsRead As FileStream = New FileStream("DSencrypted.dat", _
           FileMode.Open, FileAccess.Read)
        Dim DESdecrypter As ICryptoTransform = DES.CreateDecryptor()
        Dim decryptStream As CryptoStream = New CryptoStream(fsRead, _
           DESdecrypter, CryptoStreamMode.Read)
        Dim plainStreamR As XmlTextReader = New XmlTextReader(decryptStream)
        MyDS2.ReadXml(plainStreamR, XmlReadMode.ReadSchema)

        Console.WriteLine("Customers Table Successfully" _
           & " Encrypted and Decrypted.")
        Console.WriteLine("First Customer:")
        Dim _Column As DataColumn
        For Each _Column In MyDS2.Tables("Customers").Columns
            Console.Write("{0}, ", MyDS2.Tables("Customers").Rows(0)(_Column))
        Next
        Console.WriteLine()
    End Sub

End Module
