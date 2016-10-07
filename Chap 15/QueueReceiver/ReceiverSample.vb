Imports System
Imports System.Messaging
Imports System.Xml.Serialization
Imports System.IO
Imports Apress.ProADONET.OQProvider

Module ReceiverSample

   Sub Main()
      ' Get queue reference
      Dim mQ As MessageQueue
      If MessageQueue.Exists(".\Private$\OrderQueue") Then
         mQ = New MessageQueue(".\Private$\OrderQueue")
      Else
         Console.WriteLine("Queue doesn't exist.")
         Return
      End If

      ' Get message and extract order
      Dim msg As Message = mQ.Receive(New TimeSpan(0, 0, 3))
      Dim sr As StreamReader = New StreamReader(msg.BodyStream)
      Dim xs As XmlSerializer = New XmlSerializer(GetType(OrderObject))
      Dim myOrder As OrderObject = CType(xs.Deserialize(sr), OrderObject)

      ' Do something with received Order...
   End Sub

End Module
