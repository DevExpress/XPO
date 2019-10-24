Imports DevExpress.Xpo
Namespace XpoTutorial
    Public Class Order
        Inherits XPObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private fProductName As String
        <Size(200)>
        Public Property ProductName() As String
            Get
                Return fProductName
            End Get
            Set(value As String)
                SetPropertyValue(NameOf(ProductName), fProductName, value)
            End Set
        End Property
        Private fOrderDate As DateTime
        Public Property OrderDate() As DateTime
            Get
                Return fOrderDate
            End Get
            Set(value As DateTime)
                SetPropertyValue(NameOf(OrderDate), fOrderDate, value)
            End Set
        End Property
        Private fFreight As Decimal
        Public Property Freight() As Decimal
            Get
                Return fFreight
            End Get
            Set(value As Decimal)
                SetPropertyValue(NameOf(Freight), fFreight, value)
            End Set
        End Property
        Private fCustomer As Customer
        <Association("CustomerOrders")>
        Public Property Customer() As Customer
            Get
                Return fCustomer
            End Get
            Set(value As Customer)
                SetPropertyValue(NameOf(Customer), fCustomer, value)
            End Set
        End Property
    End Class
End Namespace
