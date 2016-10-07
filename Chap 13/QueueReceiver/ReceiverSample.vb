Imports System
Imports System.Messaging
Imports System.IO

Module ReceiverSample

    Sub Main()
        Dim mQ As MessageQueue
        Dim mes As Message
        Dim X As String
        Dim br As BinaryReader

        If MessageQueue.Exists(".\Private$\HelloWorld") Then
            mQ = New MessageQueue(".\Private$\HelloWorld")
        Else
            Console.WriteLine("Queue doesn't exist.")
            Return
        End If

        Try
            mes = mQ.Receive(New TimeSpan(0, 0, 3))
            br = New BinaryReader(mes.BodyStream)
            X = New String(br.ReadChars(CType(mes.BodyStream.Length, Integer)))
            Console.WriteLine("Received Message: {0}", X)
        Catch
            Console.WriteLine("No Message to Receive.")
        End Try

    End Sub

End Module
