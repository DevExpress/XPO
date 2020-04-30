Imports System
Imports DevExpress.Utils

Namespace WinFormsApplication.ViewModels
	Public NotInheritable Class ViewID
		Implements IEquatable(Of ViewID)

		Private ReadOnly viewType As Object
		Private ReadOnly id? As Integer
		Public Sub New(ByVal viewType As Object)
			Me.viewType = viewType
			Me.id = Nothing
		End Sub
		Public Sub New(ByVal viewType As Object, ByVal id As Integer)
			Me.viewType = viewType
			Me.id = id
		End Sub
		Public Overloads Function Equals(ByVal other As ViewID) As Boolean Implements IEquatable(Of ViewID).Equals
			Return (other IsNot Nothing) AndAlso Equals(viewType, other.viewType) AndAlso Equals(id, other.id)
		End Function
		Public Overrides Function Equals(ByVal obj As Object) As Boolean
			Return Equals(TryCast(obj, ViewID))
		End Function
		Public Overrides Function GetHashCode() As Integer
			Return HashCodeHelper.CalculateGeneric(viewType, id)
		End Function
	End Class
End Namespace
