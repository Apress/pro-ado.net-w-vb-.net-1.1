Imports System
Imports System.Messaging

Module MessageSample

   Sub Main()
      Dim Greeting As String = "Hello World!"
      Dim mQ As MessageQueue
      If MessageQueue.Exists(".\Private$\HelloWorld") Then
         mQ = New MessageQueue(".\Private$\HelloWorld")
      Else
         mQ = MessageQueue.Create(".\Private$\HelloWorld")
      End If

      mQ.Send(Greeting, "HelloWorld")
      Console.WriteLine("Greeting Message Sent to Private Queue.")
   End Sub

End Module
