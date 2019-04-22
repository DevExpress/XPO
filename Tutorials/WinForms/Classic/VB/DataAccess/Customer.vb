Imports DevExpress.Xpo

Namespace XpoTutorial

	Public Class Customer
		Inherits XPObject

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
                SetPropertyValue("LastName", value)
            End Set
		End Property
		<PersistentAlias("Concat([FirstName], ' ', [LastName])")>
		Public ReadOnly Property ContactName() As String
			Get
				Return DirectCast(EvaluateAlias(NameOf(ContactName)), String)
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
