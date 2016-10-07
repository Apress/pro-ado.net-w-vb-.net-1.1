Public Class OQException
   Inherits DataException

   Public Sub New()
   End Sub

   Public Sub New(ByVal message As String)
      MyBase.New(message)
   End Sub

   Public Sub New(ByVal message As String, ByVal inner As Exception)
      MyBase.new(message, inner)
   End Sub
End Class
