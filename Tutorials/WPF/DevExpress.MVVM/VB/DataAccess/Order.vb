Imports DevExpress.Xpo
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace XpoTutorial

	Public Class Order
		Inherits BaseObject
		Implements IEditableObject

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
        Private fFreight As Decimal?
        Public Property Freight() As Decimal?
			Get
				Return fFreight
			End Get
			Set(ByVal value? As Decimal)
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

		#Region "IEditableObject implementation"

		Private isEditing As Boolean
		Private oldProductName As String
		Private oldOrderDate As Date
		Private oldFreight? As Decimal
		Private oldCustomer As Customer

		Public Sub BeginEdit() Implements IEditableObject.BeginEdit
			If isEditing Then
				Throw New InvalidOperationException()
			End If
			oldProductName = ProductName
			oldOrderDate = OrderDate
			oldFreight = Freight
			oldCustomer = Customer
			isEditing = True
		End Sub

		Public Sub CancelEdit() Implements IEditableObject.CancelEdit
			If Not isEditing Then
				Throw New InvalidOperationException()
			End If
			ProductName = oldProductName
			OrderDate = oldOrderDate
			Freight = oldFreight
			Customer = oldCustomer
			isEditing = False
		End Sub

		Public Sub EndEdit() Implements IEditableObject.EndEdit
			If Not isEditing Then
				Throw New InvalidOperationException()
			End If
			isEditing = False
		End Sub

		#End Region
	End Class
End Namespace
