Imports System

Module UnsecureClientSample

   Sub Main()
      Dim oClass As SecureLibrary.SecureClass = _
         New SecureLibrary.SecureClass()
      Console.WriteLine(oClass.GetSecureString())
   End Sub

End Module

