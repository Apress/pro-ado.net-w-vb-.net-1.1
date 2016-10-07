Imports System

Module SecureClientSample

   Sub Main()
      Dim oClass As SecureLibrary.SecureClass = New SecureLibrary.SecureClass()
      Console.WriteLine(oClass.GetSecureString())
   End Sub

End Module
