Public Class OQParameterCollection
   Inherits System.Collections.CollectionBase
   Implements IDataParameterCollection

   Private _Param As OQParameter

   Public Sub New()
   End Sub

   Default Public Overloads Property Item(ByVal parameterName As String) As Object _
      Implements IDataParameterCollection.Item
      Get
         Return _Param
      End Get
      Set(ByVal Value As Object)
         _Param = CType(Value, OQParameter)
      End Set
   End Property

   Public Function Contains(ByVal parameterName As String) As Boolean _
      Implements IDataParameterCollection.Contains
      If ((parameterName = "Order") And (Not _Param Is Nothing)) Then
         Return True
      Else
         Return False
      End If
   End Function

   Public Function IndexOf(ByVal parameterName As String) As Integer _
      Implements IDataParameterCollection.IndexOf
      Return 0
   End Function

   Public Overloads Sub RemoveAt(ByVal parameterName As String) _
      Implements IDataParameterCollection.RemoveAt
      _Param = Nothing
   End Sub

End Class
