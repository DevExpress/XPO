Imports DevExpress.Xpo

Namespace XpoTutorial

	<NonPersistent> _
	<DeferredDeletion, OptimisticLocking>
	Public Class BaseObject
		Inherits PersistentBase

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Key(True)>
		Public Property Oid() As Integer
			Get
				Return GetPropertyValue(Of Integer)(NameOf(Oid))
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(NameOf(Oid), value)
			End Set
		End Property
	End Class
End Namespace
