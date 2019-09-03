Imports DevExpress.Xpo

Namespace XpoTutorial

	<NonPersistent> _
	<DeferredDeletion, OptimisticLocking>
	Public Class BaseObject
		Inherits PersistentBase

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Key(True)> _
		<Persistent("OID")> _
		Private fOid As Integer
		<PersistentAlias("fOid")>
		Public Property Oid() As Integer
			Get
				Return fOid
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(NameOf(Oid), fOid, value)
			End Set
		End Property
	End Class
End Namespace
