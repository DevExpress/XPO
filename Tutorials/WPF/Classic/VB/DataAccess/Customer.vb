Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace XpoTutorial

	Public Class Customer
		Inherits BaseObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private fFirstName As String
		Public Property FirstName() As String
			Get
				Return fFirstName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(NameOf(FirstName), fFirstName, value)
			End Set
		End Property
		Private fLastName As String
		Public Property LastName() As String
			Get
				Return fLastName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(NameOf(LastName), fLastName, value)
			End Set
		End Property
		<NonPersistent>
		Public ReadOnly Property ContactName() As String
			Get
				Return String.Concat(FirstName, " ", LastName)
			End Get
		End Property
		<Association("CustomerOrders")>
		Public ReadOnly Property Orders() As IList(Of Order)
			Get
				Return GetList(Of Order)(NameOf(Orders))
			End Get
		End Property
	End Class

End Namespace
