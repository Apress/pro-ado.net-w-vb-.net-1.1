Imports System
Imports System.Runtime.InteropServices

Class PInvokeTest

   <DllImport("winmm.dll")> _
   Public Shared Function sndPlaySound(ByVal lpszSound As String, ByVal flags As UInt32) As Boolean
   End Function

   Public Shared Sub Main()
      sndPlaySound("Windows XP Startup", New UInt32())
   End Sub

End Class
