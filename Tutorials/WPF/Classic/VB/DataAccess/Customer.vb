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
		Public Property FirstName() As String
			Get
				Return GetPropertyValue(Of String)(NameOf(FirstName))
			End Get
			Set(ByVal value As String)
				SetPropertyValue(NameOf(FirstName), value)
			End Set
		End Property
		Public Property LastName() As String
			Get
				Return GetPropertyValue(Of String)(NameOf(LastName))
			End Get
			Set(ByVal value As String)
				SetPropertyValue(NameOf(LastName), value)
			End Set
		End Property
		<PersistentAlias("Concat(FirstName, ' ', LastName)")>
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
