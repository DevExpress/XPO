Imports DevExpress.Xpo
Imports System

Namespace XpoTutorial

	Public Class Order
		Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private fProductName As String
        Public Property ProductName() As String
            Get
                Return fProductName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(NameOf(ProductName), fProductName, value)
            End Set
        End Property
        Private fOrderDate As Date
        Public Property OrderDate() As Date
            Get
                Return fOrderDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(NameOf(OrderDate), fOrderDate, value)
            End Set
        End Property
        Private fFreight As Decimal
        Public Property Freight() As Decimal
            Get
                Return fFreight
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(NameOf(Freight), fFreight, value)
            End Set
        End Property
        Private fCustomer As Customer
        <Association("CustomerOrders")>
		Public Property Customer() As Customer
			Get
                Return fCustomer
            End Get
			Set(ByVal value As Customer)
                SetPropertyValue(NameOf(Customer), fCustomer, value)
            End Set
		End Property
	End Class
End Namespace
