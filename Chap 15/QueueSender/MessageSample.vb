Imports System
Imports System.Messaging
Imports Apress.ProADONET.OQProvider

Module MessageSample

   Sub Main()
      ' Create an Order and populate it with some data.
      Dim myOrder As OrderObject = New OrderObject("HOFF", _
         "ORDER1", "Kevin Hoffman", "101 Queue Lane", _
         "", "ADOville", "MS", "000000", "USA", "FEDEX")

      ' Create a MessageQueue object and point it at OrderQueue.
      Dim mQ As MessageQueue
      If MessageQueue.Exists(".\Private$\OrderQueue") Then
         mQ = New MessageQueue(".\Private$\OrderQueue")
      Else
         mQ = MessageQueue.Create(".\Private$\OrderQueue")
      End If
      mQ.Formatter = New XmlMessageFormatter()

      ' Send an OrderObject object to the Queue. This automatically 
      ' invokes the XML serialization.
      mQ.Send(myOrder, myOrder.OrderID)

      Console.WriteLine("Order Sent to OrderQueue.")
   End Sub

End Module
