Imports DevExpress.Xpo

Namespace XpoTutorial
    Public Class Customer
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private fFirstName As String
        Public Property FirstName() As String
            Get
                Return fFirstName
            End Get
            Set(value As String)
                SetPropertyValue(NameOf(FirstName), fFirstName, value)
            End Set
        End Property
        Private fLastName As String
        Public Property LastName() As String
            Get
                Return fLastName
            End Get
            Set(value As String)
                SetPropertyValue(NameOf(LastName), fLastName, value)
            End Set
        End Property
        <PersistentAlias("Concat([FirstName], ' ', [LastName])")>
        Public ReadOnly Property ContactName() As String
            Get
                Return CType(EvaluateAlias(NameOf(ContactName)), String)
            End Get
        End Property
        <Association("CustomerOrders")>
        Public ReadOnly Property Orders() As XPCollection(Of Order)
            Get
                Return GetCollection(Of Order)(NameOf(Orders))
            End Get
        End Property
    End Class
End Namespace