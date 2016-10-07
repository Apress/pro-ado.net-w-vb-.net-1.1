Public Class Pair
    Public Sub New(ByVal First As Object, ByVal Second As Object)
        mFirst = First
        mSecond = Second
    End Sub

    Public Property First() As Object
        Get
            Return mFirst
        End Get
        Set(ByVal Value As Object)
            mFirst = Value
        End Set
    End Property

    Public Property Second() As Object
        Get
            Return mSecond
        End Get
        Set(ByVal Value As Object)
            mSecond = Value
        End Set
    End Property

    Private mFirst As Object
    Private mSecond As Object
End Class
