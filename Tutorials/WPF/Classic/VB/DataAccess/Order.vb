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
'INSTANT VB NOTE: The field productName was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private productName_Renamed As String
		Public Property ProductName() As String
			Get
				Return productName_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue(NameOf(ProductName), productName_Renamed, value)
			End Set
		End Property
		Public Property OrderDate() As Date
			Get
				Return GetPropertyValue(Of Date)(NameOf(OrderDate))
			End Get
			Set(ByVal value As Date)
				SetPropertyValue(NameOf(OrderDate), value)
			End Set
		End Property
		Public Property Freight() As Decimal?
			Get
				Return GetPropertyValue(Of Decimal?)(NameOf(Freight))
			End Get
			Set(ByVal value? As Decimal)
				SetPropertyValue(NameOf(Freight), value)
			End Set
		End Property
		<Association("CustomerOrders")>
		Public Property Customer() As Customer
			Get
				Return GetPropertyValue(Of Customer)(NameOf(Customer))
			End Get
			Set(ByVal value As Customer)
				SetPropertyValue(NameOf(Customer), value)
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
